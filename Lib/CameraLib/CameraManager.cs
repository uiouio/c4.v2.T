using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;
using System.Collections.Concurrent;

namespace CameraLib
{
    public class CameraManager
    {
        private ConcurrentDictionary<string, Camera> cameraMap;
        private CameraMonitor monitor;
        public CameraManager()
        {
            this.cameraMap = new ConcurrentDictionary<string, Camera>();
            this.monitor = new CameraMonitor(this.cameraMap);
        }

        public CameraMonitor Monitor { get { return monitor; } }

        public Camera RegisterNew(string deviceName, IVideoSource videoSource)
        {
            Camera camera = null;
            var dir = CheckAndGetDeviceFolder(deviceName);
            if (!cameraMap.TryGetValue(deviceName, out camera))
            {
                camera = new Camera(deviceName, videoSource, new VideoStore(string.Format(@"{0}\{1}", dir, deviceName)));
                cameraMap[deviceName] = camera;
            }

            return camera;
        }

        public Camera GetCamera(string deviceName)
        {
            Camera camera = null;
            cameraMap.TryGetValue(deviceName, out camera);
            return camera;
        }

        public IEnumerable<Camera> GetCameras(string fuzzyName = ".+")
        {
            foreach (var camera in cameraMap.Values)
            {
                var regex = new Regex(fuzzyName);
                if (regex.Match(camera.DeviceName).Success)
                {
                    yield return camera;
                }
            }
        }

        public void Close()
        {
            foreach (var camera in cameraMap.Values)
            {
                camera.Stop();
            }
        }

        private string CheckAndGetDeviceFolder(string deviceName)
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory + @"video\";
            if (!Directory.Exists(dir + deviceName))
                Directory.CreateDirectory(dir + deviceName);
            return dir;
        }

        public class CameraMonitor
        {
            private Timer timer;
            private ConcurrentDictionary<string, Camera> cameraMap;
            private const int CHECK_INTERVAL = 5 * 1000;
            public delegate void OnCameraStateReport(string deviceName, CameraState state);
            public CameraMonitor(ConcurrentDictionary<string, Camera> cameraMap)
            {
                this.cameraMap = cameraMap;
                this.timer = new Timer(DoCheck, null, CHECK_INTERVAL, Timeout.Infinite);
            }

            public event OnCameraStateReport OnStateReport;

            private void DoCheck(object state)
            {
                timer.Change(Timeout.Infinite, Timeout.Infinite);
                try
                {
                    var cameras = cameraMap.Values.ToArray();
                    var handler = OnStateReport;
                    foreach (var camera in cameras)
                        if (handler != null)
                            OnStateReport(camera.DeviceName, camera.State);
                }
                catch (Exception ex)
                {
                    //todo
                }
                finally
                {
                    timer.Change(CHECK_INTERVAL, Timeout.Infinite);
                }
            }
        }
    }
}
