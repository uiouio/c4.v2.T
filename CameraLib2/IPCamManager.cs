using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using Vlc.DotNet.Forms;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace CameraLib2
{
    public class IPCameraManager
    {
        private LiveCameraMonitor monitor;
        private IList<IPCamera> liveCameras = new List<IPCamera>();
        private static IPCameraManager manager = new IPCameraManager();
        private IPCameraManager()
        {
            this.monitor = new LiveCameraMonitor();
            KillRecProc();
        }

        public static IPCameraManager Instance { get { return manager; } }
        public void Add(CameraAddress addr)
        {
            IPCamera camera = null;
            if (!TryGet(addr, out camera)) liveCameras.Add(new IPCamera(addr, monitor));
        }

        public bool TryGet(CameraAddress addr, out IPCamera camera)
        {
            camera = null;
            var exists = false;
            foreach (var cam in liveCameras)
            {
                if (cam.Address == addr)
                {
                    camera = cam;
                    exists = true;
                    break;
                }
            }
            return exists;
        }

        public void PlayAll(Control[] hosts)
        {
            if (hosts.Length == 0) return;
            if (liveCameras.Count > hosts.Length) return;
            for (var i = 0; i < hosts.Length; i++)
            {
                if (i < liveCameras.Count) liveCameras[i].Play(hosts[i]);
            }
            CosnoleUtil.HideConsole();
        }

        public IList<IPCamera> ListCamerasToReplay(DateTime checkInTime)
        {
            var camerasToReplay = new List<IPCamera>();
            var directoriesToReplay = Directory.GetDirectories(AppDomain.CurrentDomain.BaseDirectory + "video").ToList();
            foreach (var dir in directoriesToReplay)
            {
                var fileNamesToLong = Directory.GetFiles(dir)
                    .Where(f => Path.GetExtension(f).Equals(".avi"))
                    .Select(f => Convert.ToInt64(Path.GetFileNameWithoutExtension(f)))
                    .OrderByDescending(d => d);
                foreach (var file in fileNamesToLong)
                {
                    camerasToReplay.Add(new IPCamera(string.Format(@"{0}\{1}.avi", dir, file)));
                    if (file <= TimeUtil.ToTimestamp(checkInTime)) break;
                }
            }
            return camerasToReplay;
        }

        public IList<IPCamera> ListCamerasToReplay(string machineAddr, DateTime checkInTime)
        {
            var directoriesToReplay = new List<string>();
            var camerasToReplay = new List<IPCamera>();
            var directories = Directory.GetDirectories(AppDomain.CurrentDomain.BaseDirectory + "video");
            foreach(var dir in directories)
            {
                var split = new DirectoryInfo(dir).Name.Split('.');
                if (split.Length == 2)
                {
                    if (split[1].Equals(machineAddr)) directoriesToReplay.Add(dir);
                }
            }
            foreach (var dir in directoriesToReplay)
            {
                var fileNamesToLong = Directory.GetFiles(dir)
                    .Where(f => Path.GetExtension(f).Equals(".avi"))
                    .Select(f => Convert.ToInt64(Path.GetFileNameWithoutExtension(f)))
                    .OrderBy(d => d)
                    .ToArray();
                var idx = Array.BinarySearch<long>(fileNamesToLong, TimeUtil.ToTimestamp(checkInTime));
                if (idx >= 0)
                {
                    var camera = new IPCamera(string.Format(@"{0}\{1}.avi", dir, fileNamesToLong[idx]));
                    camerasToReplay.Add(camera);
                    if (!camera.IsRecLongEnoughToPlay(checkInTime))
                    {
                        if (idx != fileNamesToLong.Length - 1) camerasToReplay.Add(new IPCamera(string.Format(@"{0}\{1}.avi", dir, fileNamesToLong[idx + 1])));
                    }
                }
                else
                {
                    idx = ~idx;
                    if (idx != 0)
                    {
                        var camera = new IPCamera(string.Format(@"{0}\{1}.avi", dir, fileNamesToLong[idx - 1]));
                        camerasToReplay.Add(camera);
                        if (!camera.IsRecLongEnoughToPlay(checkInTime))
                        {
                            camerasToReplay.Add(new IPCamera(string.Format(@"{0}\{1}.avi", dir, fileNamesToLong[idx])));
                        }
                    }
                }
            }
            return camerasToReplay;
        }

        public void CloseAll()
        {
            foreach (var cam in liveCameras) cam.Dispose();
            liveCameras.Clear();
        }

        private void KillRecProc()
        {
            foreach (var proc in Process.GetProcessesByName("ffmpeg")) proc.Kill();
        }
    }

    public class IPCamera : IDisposable
    {
        private CameraAddress addr;
        private VlcControl player;
        private string recPath;
        private bool isPlaying;
        private LiveCameraMonitor monitor;
        private Process process;
        private const int REPLAY_DURATION = 10;
        private bool isDisposed = false;

        public IPCamera(string fileName)
            :this(CameraAddress.Parse(fileName), null)
        {
            this.recPath = fileName;
        }

        public IPCamera(CameraAddress addr, LiveCameraMonitor monitor)
        {
            this.addr = addr;
            this.monitor = monitor;
            this.player = new VlcControl { Name = string.Format("{0}.{1}", addr.Line, addr.MachineAddr), Dock = DockStyle.Fill };
            this.Prepare();
        }

        public VlcControl Player { get { return player; } }
        public CameraAddress Address { get { return addr; } }
        public string RecordPath { get { return recPath; } }
        public bool IsLive { get { return player != null; } }

        public void Play(Control host)
        {
            if (!string.IsNullOrEmpty(addr.StreamAddr) && IsLive && !isPlaying)
            {
                var fileName = string.Format(@"{0}\{1}.avi", GetDir(), TimeUtil.ToTimestamp(DateTime.Now));
                if (File.Exists(fileName)) File.Delete(fileName);
                process = StartRtspRec(fileName);
                host.Controls[0].Visible = false;
                host.Controls.Add(player);
                player.Play(new FileInfo(fileName));
                monitor.Watch(this);
                recPath = fileName;
                isPlaying = true;
            }
        }

        public void Replay(DateTime checkInTime, bool blockUntiVideoExit = false)
        {
            if (isDisposed)
            {
                this.player = new VlcControl { Name = string.Format("{0}.{1}", addr.Line, addr.MachineAddr), Dock = DockStyle.Fill };
                this.Prepare();
                isDisposed = false;
            }

            CosnoleUtil.HideConsole();

            var startPos = Convert.ToInt64(Path.GetFileNameWithoutExtension(recPath));
            if (TimeUtil.ToTimestamp(checkInTime) < startPos)
            {
                new MediaPlayer(this, recPath, -1, REPLAY_DURATION).ShowDialog();
            }
            else
            {
                //rec is 1.5 secs slower than live movie
                new MediaPlayer(this, recPath, TimeUtil.ToTimestamp(checkInTime.AddSeconds(1.5)) - startPos, REPLAY_DURATION).ShowDialog();
            }
            

            //var proc = new Process();
            //proc.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + @"lib\vlc\vlc.exe";
            //var startPos = Convert.ToInt64(Path.GetFileNameWithoutExtension(recPath));
            //if (TimeUtil.ToTimestamp(checkInTime) < startPos)
            //    proc.StartInfo.Arguments = string.Format(" {0} --run-time=10 --play-and-exit", recPath);
            //else
            //    proc.StartInfo.Arguments = string.Format(" {0} --start-time={1} --run-time={2} --play-and-exit", recPath, TimeUtil.ToTimestamp(checkInTime) - startPos, REPLAY_DURATION);
            //proc.StartInfo.CreateNoWindow = true;
            //proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //proc.Start();
            //if (blockUntiVideoExit) proc.WaitForExit();
        }

        public bool IsRecLongEnoughToPlay(DateTime checkInTime)
        {
            var isLongEnough = false;
            var proc = new Process();
            proc.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + @"lib\ffmpeg.exe";
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.Arguments = string.Format(" -i \"{0}\"", recPath);
            proc.Start();
            while (true)
            {
                if (!proc.StandardError.EndOfStream)
                {
                    var line = proc.StandardError.ReadLine();
                    if (line.Contains("Duration"))
                    {
                        DateTime time = DateTime.Now;
                        var videoLen = line.Trim().Substring(10, 8);
                        var secs = 0L;
                        if (!DateTime.TryParse(videoLen, out time))
                            secs = TimeUtil.ToTimestamp(DateTime.Now) - Convert.ToInt64(Path.GetFileNameWithoutExtension(recPath));
                        else 
                            secs = (long)time.TimeOfDay.TotalSeconds;
                        var expectedLen = TimeUtil.ToTimestamp(checkInTime) - Convert.ToInt64(Path.GetFileNameWithoutExtension(recPath)) + REPLAY_DURATION;
                        isLongEnough = secs - expectedLen >= 0;
                        break;
                    }
                }
            }
            proc.WaitForExit();
            return isLongEnough;
        }

        public void Dispose()
        {
            isDisposed = true;
            if (player.IsPlaying) player.Stop();
            if (process != null)
                process.StandardInput.WriteLine("q");
        }

        private Process StartRtspRec(string fileName) 
        {
            var proc = new Process();
            proc.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + @"lib\ffmpeg.exe";
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.Arguments = string.Format(" -i \"{0}\" -b:v 64k -s 1280x720 -vcodec libx264 -r 24 \"{1}\"", addr.StreamAddr, fileName);
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();
            //proc.StandardInput.WriteLine(string.Format(" -i \"{0}\" -b:v 64k -s 1280x720 -vcodec copy \"{1}\" -r 24", addr.StreamAddr, fileName));
            //proc.StartInfo.Arguments = string.Format(" -i \"{0}\" -b:v 64k -s 1280x720 -vcodec libx264 -r 24 \"{1}\"", addr.StreamAddr, fileName);
            //proc.StartInfo.Arguments = string.Format(" -i \"{0}\" -b:v 64k -s 1280x720 -vcodec copy \"{1}\" -r 24", addr.StreamAddr, fileName);
            //proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //proc.StartInfo.RedirectStandardInput = true;
            return proc;
        }

        private string GetDir()
        {
            var basedir = AppDomain.CurrentDomain.BaseDirectory + "video";
            if (!Directory.Exists(basedir)) Directory.CreateDirectory(basedir);
            var cameraDir = string.Format(@"{0}\{1}.{2}", basedir, addr.Line, addr.MachineAddr);
            if (!Directory.Exists(cameraDir)) Directory.CreateDirectory(cameraDir);
            return cameraDir;
        }

        private void Prepare()
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory + "lib";
            var currentAssembly = Assembly.GetEntryAssembly();
            if (AssemblyName.GetAssemblyName(currentAssembly.Location).ProcessorArchitecture == ProcessorArchitecture.X86)
                player.VlcLibDirectory = new DirectoryInfo(string.Format(@"{0}\{1}", dir, "x86"));
            else
                player.VlcLibDirectory = new DirectoryInfo(string.Format(@"{0}\{1}", dir, "x64"));
        }
    }

    public class CameraAddress
    {
        public string Line { get; set; }
        public string StreamAddr { get; set; }
        public string MachineAddr { get; set; }

        public bool Equals(CameraAddress other)
        {
            if (string.IsNullOrEmpty(Line) || string.IsNullOrEmpty(other.Line)) return false;
            if (string.IsNullOrEmpty(MachineAddr) || string.IsNullOrEmpty(other.MachineAddr)) return false;
            return Line.Equals(other.Line) && MachineAddr.Equals(other.MachineAddr);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is CameraAddress && Equals((CameraAddress)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (string.IsNullOrEmpty(MachineAddr) ? 0 : MachineAddr.GetHashCode() * 397) ^ (string.IsNullOrEmpty(Line) ? 0 : Line.GetHashCode());
            }
        }

        public static CameraAddress Parse(string fileName)
        {
            CameraAddress addr = null;
            if (!string.IsNullOrEmpty(fileName))
            {
                var match = new Regex(@".+\\(\d+.\d+)\\\d+.avi").Match(fileName);
                if (match.Success) addr = new CameraAddress { Line = match.Groups[1].Value.Split('.')[0], MachineAddr = match.Groups[1].Value.Split('.')[0] };
            }
            return addr;
        }
    }

    public class LiveCameraMonitor
    {
        private object syncRoot = new object();
        private IList<IPCamera> liveCameras = new List<IPCamera>();
        public LiveCameraMonitor()
        {
            new Task(() =>
            {
                while (true)
                {
                    Thread.Sleep(1500);
                    IPCamera[] lives = null;
                    lock (syncRoot)
                    {
                        lives = new IPCamera[liveCameras.Count];
                        liveCameras.CopyTo(lives, 0);
                    }
                    foreach (var camera in lives)
                    {
                        try
                        {
                            if (!camera.Player.IsPlaying) camera.Player.Play(new FileInfo(camera.RecordPath));
                        }
                        catch (Exception) { }
                    }
                }
            }, TaskCreationOptions.LongRunning).Start();
        }

        public void Watch(IPCamera camera)
        {
            if (!IsUnderWatching(camera))
            {
                lock (syncRoot)
                {
                    liveCameras.Add(camera);
                }
            }
        }

        private bool IsUnderWatching(IPCamera camera)
        {
            foreach (var cam in liveCameras) if (cam.Address == camera.Address) return true;
            return false;
        }
    }
}
