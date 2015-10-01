using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using CameraLib.AVI;

namespace CameraLib
{
    public class Video
    {
        private VideoStore store;
        private AviManager aviManager;
        private VideoStream videoStream;
        private string currentStoreName;
        private const int VIDEO_FRAME_RATE = 11;
        private object syncRoot = new object();
        public Video(VideoStore store)
        {
            this.store = store;
            this.currentStoreName = string.Empty;
        }

        public string CurrentStoreName
        {
            get { return currentStoreName; }
        }

        public VideoStore Store { get { return store; } }

        public void AddFrame(Bitmap frame)
        {
            var storeName = store.GetStoreName();
            if (!storeName.Equals(currentStoreName))
            {
                this.Close();
            }
            lock (syncRoot)
            {
                if (aviManager == null)
                {
                    aviManager = new AviManager(storeName, false);
                    videoStream = aviManager.AddVideoStream(true, VIDEO_FRAME_RATE, frame);
                    currentStoreName = storeName;
                }
                else
                    videoStream.AddFrame(frame);
            }
        }

        public void Replay(string path, string slibingPath, long offset)
        {
            var fileName = Path.GetFileName(path);
            long startOffset = 0;
            if (long.TryParse(fileName.Replace(".cam", string.Empty), out startOffset))
            {
                var byPassTime = Convert.ToInt32((TimeUtil.FromTimestamp(offset) - TimeUtil.FromTimestamp(startOffset)).TotalSeconds);
                var process = new Process();
                process.StartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
                process.StartInfo.FileName = "vlc.exe";
                process.StartInfo.Arguments = string.Format(" {0} :start-time={1} {2} --play-and-exit", path, byPassTime, !string.IsNullOrEmpty(slibingPath) ? slibingPath : string.Empty);
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.Start();
            }
        }

        public void Close()
        {
            if (aviManager != null)
            {
                try
                {
                    lock (syncRoot)
                    {
                        aviManager.Close();
                        if (!string.IsNullOrEmpty(currentStoreName))
                        {
                            store.Save(currentStoreName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    //todo
                }
                finally
                {
                    aviManager = null;
                    videoStream = null;
                }
            }
        }
    }
}
