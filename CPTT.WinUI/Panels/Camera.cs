using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Data;
using CPTT.SystemFramework;
using CPTT.BusinessFacade;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System.Threading.Tasks;
using CameraLib2;

namespace CPTT.WinUI.Panels
{
    public partial class Camera : DevExpress.XtraEditors.XtraUserControl
    {
        private SynchronizationContext context;
        private static bool hasLoad = false;
        public Camera()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.ProcessExit +=new EventHandler(CurrentDomain_ProcessExit);
            this.context = SynchronizationContext.Current;
        }

        public void OnLoad()
        {
            if (!hasLoad)
            {
                dateEdit1.DateTime = DateTime.Now;
                var cameraTable = new CameraSystem().GetCameraInfo();
                if (cameraTable.Rows.Count > 0)
                {
                    foreach (DataRow item in cameraTable.Rows)
                    {
                        IPCameraManager.Instance.Add(new CameraAddress
                        {
                            Line = item["cameraName"].ToString().Replace("线路", string.Empty),
                            MachineAddr = item["machineName"].ToString().Replace("号门口机", string.Empty),
                            StreamAddr = item["cameraAddr"].ToString()
                        });
                    }
                    gridControl1.DataSource = cameraTable;
                    hasLoad = true;
                    IPCameraManager.Instance.PlayAll(new Panel[] { panel1, panel2, panel3, panel4 });
                }
            }
        }

        public void OnClose()
        {
            try
            {
                IPCameraManager.Instance.CloseAll();
            }
            catch (Exception) { }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private void repositoryItemButtonEdit3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                var rowIndex = gridView2.FocusedRowHandle;
                var list = gridView2.DataSource as List<LookupBinding>;
                if (rowIndex < list.Count)
                {
                    var item = list[rowIndex];
                    item.Camera.Replay(item.checkInTimestamp);
                }
            }
            catch (Exception) { MessageBox.Show("回放出现异常!"); }
        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
        }

        void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            IPCameraManager.Instance.CloseAll();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
            var key = comboBoxEdit1.EditValue as string;
            var time = (DateTime)dateEdit1.EditValue;
            var beginTime = time.Date.ToString("yyyy-MM-dd HH:mm:ss");
            var endTime = time.Date.AddSeconds(86399).ToString("yyyy-MM-dd HH:mm:ss");
            int val = 0;

            var videoMap = new Dictionary<long, IList<IPCamera>>();
            if (!key.Equals("所有##"))
            {
                if (int.TryParse(key, out val))
                    dt = new CameraSystem().GetCheckInfo(val, string.Empty, beginTime, endTime, comboBoxEdit2.SelectedIndex);
                else
                    dt = new CameraSystem().GetCheckInfo(0, key, beginTime, endTime, comboBoxEdit2.SelectedIndex);

                var machineCol = comboBoxEdit2.SelectedIndex == 0 ? "flow_stuEnterFromMachine" : "flow_stuBackFromMachine";
                var dateCol = comboBoxEdit2.SelectedIndex == 0 ? "flow_stuFlowEnterDate" : "flow_stuFlowBackDate";
                foreach (DataRow dr in dt.Rows)
                {
                    var machineAddr = dr[machineCol].ToString();
                    var checkInTime =  Convert.ToDateTime(dr[dateCol]);
                    var checkInTimestamp = TimeUtil.ToTimestamp(checkInTime);
                    if (!videoMap.ContainsKey(checkInTimestamp))
                    {
                        videoMap.Add(checkInTimestamp, IPCameraManager.Instance.ListCamerasToReplay(machineAddr, checkInTime));
                    }
                }
            }
            else
            {
                var checkInTime = time.AddHours(6);
                videoMap.Add(TimeUtil.ToTimestamp(checkInTime), IPCameraManager.Instance.ListCamerasToReplay(checkInTime));
            }

            var lookupBinding = new List<LookupBinding>();
            foreach (var kvp in videoMap)
            {
                foreach (var camera in kvp.Value)
                {
                    lookupBinding.Add(new LookupBinding
                    {
                        machineName = string.Format("{0}号门口机", camera.Address.MachineAddr),
                        cameraName = string.Format("线路{0}", camera.Address.Line),
                        videoTimestamp = TimeUtil.FromTimestamp(Convert.ToInt64(Path.GetFileNameWithoutExtension(camera.RecordPath))),
                        op = "1",
                        Camera = camera,
                        checkInTimestamp = TimeUtil.FromTimestamp(kvp.Key)
                    });
                }
            }

            gridControl2.DataSource = lookupBinding;
            label7.Text = string.Format("总共发现{0}个相关视频", lookupBinding.Count);
        }

        public class LookupBinding
        {
            public string machineName { get; set; }
            public string cameraName { get; set; }
            public DateTime videoTimestamp { get; set; }
            public DateTime checkInTimestamp { get; set; }
            public int replayDuration { get; set; }
            public string time { get { return videoTimestamp.ToString("HH:mm:ss"); } set { } }
            public string op { get; set; }
            public IPCamera Camera { get; set; }
        }
    }
}
