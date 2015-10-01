using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vlc.DotNet.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace CameraLib2
{
    public partial class MediaPlayer : Form
    {
        private IPCamera camera;
        private DateTime playTime;
        private string fileName;
        private long startPos;
        private int duration;
        private SynchronizationContext context;
        public MediaPlayer(IPCamera camera, string fileName, long startPos, int duration)
        {
            InitializeComponent();
            this.camera = camera;
            this.fileName = fileName;
            this.startPos = startPos;
            this.duration = duration;
            this.Controls.Add(camera.Player);
            context = SynchronizationContext.Current;
        }

        protected override void OnLoad(EventArgs e)
        {
            camera.Player.Play(new System.IO.FileInfo(fileName));
            new Task(() =>
            {
                if (startPos > 0)
                {
                    System.Threading.Thread.Sleep(8000);
                    camera.Player.Time = startPos * 1000;
                }
                playTime = DateTime.Now;
                new Task(() =>
                {
                    while (true)
                    {
                        if (camera.Player.IsPlaying)
                        {
                            if (DateTime.Now > playTime.AddSeconds(duration))
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                        Thread.Sleep(500);
                    }
                    context.Send((_) => this.Close(), null);
                }).Start();
            }).Start();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            camera.Dispose();
        }
    }
}
