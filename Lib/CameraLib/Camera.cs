using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CameraLib
{
    public class Camera
    {
        private string deviceName;
        private DateTime lastFrameTime;
        private IVideoSource videoSource;
        private Bitmap lastVideoFrame;
        private Bitmap lastImageFrame;
        private Video video;
        private Action<object, NewFrameEventArgs> newFrameHandler;
        public Camera(string deviceName, IVideoSource videoSource, VideoStore videoStore)
        {
            this.deviceName = deviceName;
            this.lastFrameTime = DateTime.MinValue;
            this.video = new Video(videoStore);
            this.videoSource = videoSource;
            this.videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
        }

        public void RegisterNewFrameHandler(Action<object, NewFrameEventArgs> handler)
        {
            if (newFrameHandler == null)
                newFrameHandler = handler;
        }

        void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            this.lastFrameTime = DateTime.Now;

            var videoFrameTmp = lastVideoFrame;
            var imageFrameTmp = lastImageFrame;

            lastVideoFrame = eventArgs.Frame;

            try
            {
                lastImageFrame = (Bitmap)eventArgs.Frame.Clone();
                video.AddFrame(lastVideoFrame);
                if (newFrameHandler != null)
                    newFrameHandler(this, new NewFrameEventArgs(lastImageFrame));
            }
            catch (Exception ex)
            {
                //todo
            }
            finally
            {
                if (videoFrameTmp != null)
                    videoFrameTmp.Dispose();
                if (imageFrameTmp != null)
                    imageFrameTmp.Dispose();
            }
        }

        public void SaveCurrentVideo()
        {
            video.Close();
        }

        public void Start()
        {
            videoSource.Start();
        }

        public void Stop()
        {
            try
            {
                videoSource.SignalToStop();
                video.Close();
            }
            catch (Exception ex)
            {
                //todo
            }
        }

        public void Replay(string path, string slibingPath, long offset)
        {
            video.Replay(path, slibingPath, offset);
        }

        public string DeviceName
        {
            get { return deviceName; }
        }

        public Video Video { get { return video; } }

        public VideoStore Store { get { return video.Store; } }

        public override bool Equals(object obj)
        {
            var other = obj as Camera;
            if (other == null)
                return false;
            return this.DeviceName.Equals(other.DeviceName);
        }

        public override int GetHashCode()
        {
            return this.DeviceName.GetHashCode();
        }

        public CameraState State
        {
            get
            {
                CameraState state = CameraState.Working;
                if (videoSource.IsRunning)
                {
                    if (lastFrameTime.AddSeconds(10) < DateTime.Now)
                        state = CameraState.Error;
                }
                else
                    state = CameraState.Stopped;

                return state;
            }
        }
    }
}
