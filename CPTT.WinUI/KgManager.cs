//==================================================================================
// 创智智能晨检网络管理系统4.0
//==================================================================================
// Copyright @2005 Shanghai Chuangzhi Toy&Technology Corporation All rights reserved.
//本计算机程序受版权法和国际条约保护.
// 如未经授权而擅自复制或传播本程序(或其中任何部分),将受到严厉的民事及刑事制裁,
//并将在法律许可的范围内受到最大程度的起诉!
//==================================================================================

using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;

using Microsoft.Practices.EnterpriseLibrary.Configuration;
using CPTT.BusinessFacade;
using CPTT.SystemFramework;

namespace CPTT.WinUI
{
	/// <summary>
	/// Summary description for KgManager.
	/// </summary>
	public class KgManager : DevExpress.XtraEditors.XtraForm
	{
		private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		internal const string USERSTYLEPROFILE_CONFIG_NAME = "UserStyleProfile";

		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private UserStyle userStyle;
		private DataSet MachineInfo;
		private DataSet ClassMachineInfo;
		private System.Timers.Timer timer_AssignAddr;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraEditors.SimpleButton simpleButton3;
		private DevExpress.XtraEditors.GroupControl groupControl2;
		private DevExpress.XtraEditors.SimpleButton simpleButton4;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_StuCardSerCond;
		private DevExpress.XtraEditors.SimpleButton simpleButton5;
		private Login login;
		private byte originalAddr;
		private byte currentAddr;
		private System.Timers.Timer timer_SetMachineVolumn;
		private bool hasAssignedSucceed = true;

		public KgManager(Login login)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.login = login;
			loadUserStyleProfile();
			timer_AssignAddr.Interval = CPTT.SystemFramework.Util.SEND_CARD_TIMER_OVERTIME;
			timer_SetMachineVolumn.Interval = 20 * 1000;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region 加载窗体风格
		//根据配置文件加载窗体风格
		private void loadUserStyleProfile()
		{
			try
			{
				userStyle = ConfigurationManager.GetConfiguration(USERSTYLEPROFILE_CONFIG_NAME) as UserStyle;
				string windowsStyle = userStyle.StyleName;
				string windowsSkin = userStyle.SkinName;

				if(windowsStyle.Equals("Default"))
				{
					DevExpress.LookAndFeel.UserLookAndFeel.Default.SetDefaultStyle();
				}
				else if(windowsStyle.Equals("WindowsXP"))
				{
					DevExpress.LookAndFeel.UserLookAndFeel.Default.SetWindowsXPStyle();
				}
				else if(windowsStyle.Equals("OfficeXP"))
				{
					DevExpress.LookAndFeel.UserLookAndFeel.Default.SetOffice2003Style();
				}
				else if(windowsStyle.Equals("Office2000"))
				{
					DevExpress.LookAndFeel.UserLookAndFeel.Default.SetDefaultStyle();
				}
				else if(windowsStyle.Equals("Office2003"))
				{
					DevExpress.LookAndFeel.UserLookAndFeel.Default.SetOffice2003Style();
				}
				else if(windowsStyle.Equals("Skin"))
				{
					DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(windowsSkin);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message,"系统信息",MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
		}
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KgManager));
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.notePanel_Send_StuCardSerCond = new DevExpress.Utils.Frames.NotePanel();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.timer_AssignAddr = new System.Timers.Timer();
            this.timer_SetMachineVolumn = new System.Timers.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timer_AssignAddr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timer_SetMachineVolumn)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xtraTabControl1.Appearance.Options.UseBackColor = true;
            this.xtraTabControl1.AppearancePage.HeaderActive.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.xtraTabControl1.AppearancePage.HeaderActive.ForeColor = System.Drawing.Color.DarkOrange;
            this.xtraTabControl1.AppearancePage.HeaderActive.Options.UseFont = true;
            this.xtraTabControl1.AppearancePage.HeaderActive.Options.UseForeColor = true;
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(608, 365);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xtraTabPage1.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabPage1.Controls.Add(this.groupControl2);
            this.xtraTabPage1.Controls.Add(this.groupControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(602, 336);
            this.xtraTabPage1.Text = "硬件设置功能";
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.simpleButton4);
            this.groupControl2.Location = new System.Drawing.Point(88, 232);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(448, 88);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Step Two:设定容量";
            // 
            // simpleButton4
            // 
            this.simpleButton4.Location = new System.Drawing.Point(160, 33);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(128, 23);
            this.simpleButton4.TabIndex = 2;
            this.simpleButton4.Text = "设定门口机容量";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.notePanel_Send_StuCardSerCond);
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Controls.Add(this.simpleButton2);
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Controls.Add(this.simpleButton3);
            this.groupControl1.Controls.Add(this.simpleButton5);
            this.groupControl1.Location = new System.Drawing.Point(18, 8);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(568, 208);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Step One:初始配置";
            // 
            // notePanel_Send_StuCardSerCond
            // 
            this.notePanel_Send_StuCardSerCond.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.notePanel_Send_StuCardSerCond.Dock = System.Windows.Forms.DockStyle.Top;
            this.notePanel_Send_StuCardSerCond.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.notePanel_Send_StuCardSerCond.ForeColor = System.Drawing.Color.Orange;
            this.notePanel_Send_StuCardSerCond.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Send_StuCardSerCond.Location = new System.Drawing.Point(2, 22);
            this.notePanel_Send_StuCardSerCond.MaxRows = 5;
            this.notePanel_Send_StuCardSerCond.Name = "notePanel_Send_StuCardSerCond";
            this.notePanel_Send_StuCardSerCond.ParentAutoHeight = true;
            this.notePanel_Send_StuCardSerCond.Size = new System.Drawing.Size(564, 23);
            this.notePanel_Send_StuCardSerCond.TabIndex = 24;
            this.notePanel_Send_StuCardSerCond.TabStop = false;
            this.notePanel_Send_StuCardSerCond.Text = "请注意一次只能分配一台门口机地址";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(48, 56);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(96, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "新增门口机";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(32, 158);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(128, 23);
            this.simpleButton2.TabIndex = 0;
            this.simpleButton2.Text = "分配地址 --> 设备";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(176, 56);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(368, 136);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn4});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "设备地址";
            this.gridColumn2.FieldName = "machine_address";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "状态";
            this.gridColumn4.FieldName = "machine_state";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(48, 90);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(96, 23);
            this.simpleButton3.TabIndex = 0;
            this.simpleButton3.Text = "修改地址";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButton5
            // 
            this.simpleButton5.Location = new System.Drawing.Point(48, 124);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new System.Drawing.Size(96, 23);
            this.simpleButton5.TabIndex = 0;
            this.simpleButton5.Text = "删除门口机";
            this.simpleButton5.Click += new System.EventHandler(this.simpleButton5_Click);
            // 
            // timer_AssignAddr
            // 
            this.timer_AssignAddr.SynchronizingObject = this;
            this.timer_AssignAddr.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_AssignAddr_Elapsed);
            // 
            // timer_SetMachineVolumn
            // 
            this.timer_SetMachineVolumn.SynchronizingObject = this;
            // 
            // KgManager
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(608, 365);
            this.Controls.Add(this.xtraTabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "KgManager";
            this.ShowInTaskbar = false;
            this.Text = "硬件配置管理";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.KgManager_Closing);
            this.Load += new System.EventHandler(this.KgManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timer_AssignAddr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timer_SetMachineVolumn)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Initial Data Load
		private void KgManager_Load(object sender, System.EventArgs e)
		{
			login.AssignAddressSuccessed += new CPTT.WinUI.Login.AssignAddressSuccessedHandler(login_AssignAddressSuccessed);
//			login.SetMachineVolumnSuccessed += new CPTT.WinUI.Login.SetMachineVolumnSuccessedHandler(login_SetMachineVolumnSuccessed);

			MachineInfo = new MachineSystem().GetMachineAddrList();

			DataTable dt = MachineInfo.Tables[0];

			DataColumn dc = new DataColumn("machine_state",System.Type.GetType("System.String"));
			dt.Columns.Add(dc);

			gridControl1.DataSource = dt;

			ClassMachineInfo = new MachineSystem().GetClassMachineAddrList();

//			gridControl2.DataSource = ClassMachineInfo.Tables[0];
		}
		#endregion

		#region add,update,delete machine and assign address
		//add
		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			if(CheckMachinState())
			{
				MessageBox.Show("请完成分配动作.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);

				return;
			}

			DataRow[] rows = MachineInfo.Tables[0].Select("","machine_address asc");
			DataRow rw = MachineInfo.Tables[0].NewRow();
			int newAddress;

			if(rows.Length>0)
			{
				int minAddress = Convert.ToInt32(rows[0]["machine_address"]);
				int maxAddress = Convert.ToInt32(rows[rows.Length-1]["machine_address"]);

				if(minAddress-1 > 0)
				{
					newAddress = minAddress - 1;
				}
				else
				{
					newAddress = maxAddress + 1;
				}

				rw[1] = 0;
				rw[0] = newAddress;
				rw["machine_state"] = "待分配";
			}
			else
			{
				newAddress = 1;
				rw[1] = 0;
				rw[0] = newAddress;
				rw["machine_state"] = "待分配";
			}

			MachineInfo.Tables[0].Rows.Add(rw);

			originalAddr = 0xff;
			currentAddr = Convert.ToByte(newAddress);
		}
		
		private bool CheckMachinState()
		{
			bool hasModifyMachine = false;

			for(int i = 0;i < gridView1.RowCount;i ++)
			{
				if(gridView1.GetDataRow(i)["machine_state"].ToString().Equals("待分配")
					||gridView1.GetDataRow(i)["machine_state"].ToString().Equals("待修改"))
				{
					hasModifyMachine = true;
				}
			}

			return hasModifyMachine;
		}

		//assign
		private void simpleButton2_Click(object sender, System.EventArgs e)
		{
			hasAssignedSucceed = true;

			if(gridView1.RowCount == 0)
			{
				MessageBox.Show("没有要分配的设备.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}

			if(!gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["machine_state"].ToString().Equals("待分配")
				&&!gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["machine_state"].ToString().Equals("待修改"))
			{
				MessageBox.Show("只有状态为待修改或待分配的记录才能进行分配,请选择正确的行记录.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}

			Login.COM_PORT_IS_BUSY = true;

			login.SuspendAllThread();
			login.assignAddress = new Thread(new ThreadStart(AssignAddress));
			login.assignAddress.IsBackground = true;
			login.assignAddress.Priority = ThreadPriority.Normal;
			login.assignAddress.Start();
		}

		private void AssignAddress()
		{
			simpleButton2.Enabled = false;

			DataFrame sendCardFrame = new DataFrame();

			sendCardFrame.sym = new byte[]{(byte)'@',(byte)'@'};
			sendCardFrame.desAddr = originalAddr;
			sendCardFrame.srcAddr = 0;
			sendCardFrame.seq = CPTT.SystemFramework.Util.FRAME_SEQUENCE_VALUE;
			sendCardFrame.protocol = CPTT.SystemFramework.Util.ASSIGN_DOOR_ADDRESS;
			sendCardFrame.comFrameLen = 9;
			sendCardFrame.frameData = new byte[1];
			sendCardFrame.frameData[0] = currentAddr;

			sendCardFrame.computeCheckSum();

			//Monitor.Enter(Login.handleComClass);
			Monitor.Enter(Login.syncRoot);
			try
			{
				Login.handleComClass.WriteSerialCmd(sendCardFrame.comFrameLen,sendCardFrame.frameToBytes());//发送问询帧
			}
			finally
			{
				Monitor.Exit(Login.syncRoot);
			}

			timer_AssignAddr.Enabled = true;
			login.assignAddress.Suspend();

			if ( hasAssignedSucceed )
			{
				if(originalAddr == 0xff)
				{
					int rowAffected = new MachineSystem().InsertMachine(Convert.ToInt32(currentAddr));
				}
				else
				{
					int rowsAffected = new MachineSystem().UpdateMachine(Convert.ToInt32(originalAddr)
						,Convert.ToInt32(currentAddr));

					//				if(rowsAffected==0)
					//				{
					//					MessageBox.Show("地址修改插入数据库失败,请重试.","系统信息!",
					//						MessageBoxButtons.OK,MessageBoxIcon.Information);
					//				}
				}

				MachineInfo = new MachineSystem().GetMachineAddrList();

				DataTable dt = MachineInfo.Tables[0];

				DataColumn dc = new DataColumn("machine_state",System.Type.GetType("System.String"));
				dt.Columns.Add(dc);

				gridControl1.DataSource = dt;

				login.ResumeQueryThread();

				MessageBox.Show("分配地址成功.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				
				login.assignAddress.Abort();
			}
		}

		//assign address successed
		private void login_AssignAddressSuccessed()
		{
			timer_AssignAddr.Enabled = false;
			assignAddrTryTime = 0;
			simpleButton2.Enabled = true;
			Login.COM_PORT_IS_BUSY = false;

			login.assignAddress.Resume();
//			for(int i = 0;i < gridView1.RowCount;i ++)
//			{
//				if(gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["machine_state"].ToString().Equals("待分配")
//					||gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["machine_state"].ToString().Equals("待修改"))
//				{
//					gridView1.SetRowCellValue(i,gridView1.Columns[1],"");
//				}
//			}
		}

		//assign address overtime
		private int assignAddrTryTime = 0;
		private void timer_AssignAddr_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			timer_AssignAddr.Enabled = false;

			if(assignAddrTryTime<5)//重试5次
			{
				try
				{
					login.assignAddress.Abort();
				}
				catch
				{
					login.assignAddress = new Thread(new ThreadStart(AssignAddress));
					login.assignAddress.IsBackground = true;
					login.assignAddress.Priority = ThreadPriority.Normal;
					login.assignAddress.Start();
				}

				assignAddrTryTime ++;
			}
			else
			{
				try
				{
					login.assignAddress.Resume();
				}
				catch
				{}
				finally
				{
					hasAssignedSucceed = false;
					Login.COM_PORT_IS_BUSY = false;
					simpleButton2.Enabled = true;
				}

				assignAddrTryTime = 0;
//				login.ResumeThread();
				login.ResumeQueryThread();

				MessageBox.Show("分配地址超时,请重试.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);

				login.assignAddress.Abort();
			}
		}

		//delete
		private void simpleButton5_Click(object sender, System.EventArgs e)
		{
			if(gridView1.RowCount <= 1)
			{
				MessageBox.Show("至少应该保证有一台门口机处于工作状态，删除失败！");
				return;
			}

			if(DialogResult.Yes != MessageBox.Show("确定删除?","系统信息!",
				MessageBoxButtons.YesNo,MessageBoxIcon.Information))
			{
				return;
			}

//			if(gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["machine_state"].ToString().Equals("待分配")
//				||gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["machine_state"].ToString().Equals("待修改"))
//			{
//				MessageBox.Show("只有状态不为待修改和待分配的记录才能进行删除,请选择正确的行记录.","系统信息!",
//					MessageBoxButtons.OK,MessageBoxIcon.Information);
//
//				return;
//			}

			int machineAddr = Convert.ToInt32(gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["machine_address"]);

			int rowsAffected = new MachineSystem().DeleteMachine(machineAddr);

			gridView1.DeleteRow(gridView1.GetSelectedRows()[0]);

//			if(rowsAffected>0)
//			{
//				gridView1.DeleteRow(gridView1.GetSelectedRows()[0]);
//			}
//			else
//			{
//				MessageBox.Show("删除失败,请重试.","系统信息!",
//					MessageBoxButtons.OK,MessageBoxIcon.Information);
//			}
		}
		
		//update
		private void simpleButton3_Click(object sender, System.EventArgs e)
		{
			if(CheckMachinState())
			{
				MessageBox.Show("请完成分配动作.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);

				return;
			}

			int machineAddr = Convert.ToInt32(gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["machine_address"]);

			ModifiMachineAddress diagForm = new ModifiMachineAddress();
			diagForm.StartPosition = FormStartPosition.CenterScreen;

			diagForm.ShowDialog();

			int modifyMachineAddr = diagForm.ModifyAddress;

			MachineInfo = new MachineSystem().GetMachineAddrList();

			DataTable dt = MachineInfo.Tables[0];

			DataRow[] rows =dt.Select("machine_address='"+modifyMachineAddr.ToString()+"'");

			if(rows.Length>0)
			{
				MessageBox.Show("地址冲突,请修改地址重试.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}
			else
			{
				gridView1.SetRowCellValue(gridView1.GetSelectedRows()[0],gridView1.Columns[0],modifyMachineAddr);
				gridView1.SetRowCellValue(gridView1.GetSelectedRows()[0],gridView1.Columns[1],"待修改");

				originalAddr = Convert.ToByte(machineAddr);
				currentAddr = Convert.ToByte(modifyMachineAddr);
			}
		}

		private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
		{
			if(gridView1.GetDataRow(e.RowHandle)["machine_state"].ToString().Equals("待分配")
				&&e.Column.AbsoluteIndex == 1)
			{
				e.Appearance.ForeColor = Color.DarkOrange;
			}
			else if(gridView1.GetDataRow(e.RowHandle)["machine_state"].ToString().Equals("待修改")
				&&e.Column.AbsoluteIndex == 1)
			{
				e.Appearance.ForeColor = Color.DarkSeaGreen;
			}
		}
		#endregion

		#region set machine volumn
		private void simpleButton4_Click(object sender, System.EventArgs e)
		{
//			if(gridView2.RowCount == 0)
//			{
//				MessageBox.Show("没有班级记录,请先填写班级记录.","系统信息!",
//					MessageBoxButtons.OK,MessageBoxIcon.Information);
//				return;
//			}
//
//			Login.COM_PORT_IS_BUSY = true;
//
//			setMachineVolumn = new Thread(new ThreadStart(SetMachineVolumn));
//			setMachineVolumn.IsBackground = true;
//			setMachineVolumn.Priority = ThreadPriority.Normal;
//			setMachineVolumn.Start();
		
			SetMachineVol setMachineVol = new SetMachineVol(this.login);
			setMachineVol.ShowDialog();
		}

//		private void SetMachineVolumn()
//		{
//			simpleButton4.Enabled = false;
//
//			int classCount = gridView2.DataRowCount;
//
//			DataFrame sendCardFrame = new DataFrame();
//
//			sendCardFrame.sym = new byte[]{(byte)'@',(byte)'@'};
//			sendCardFrame.srcAddr = 0;
//			sendCardFrame.seq = CPTT.SystemFramework.Util.FRAME_SEQUENCE_VALUE;
//			sendCardFrame.protocol = CPTT.SystemFramework.Util.SET_DOOR_VOLUME;
//			sendCardFrame.comFrameLen = (byte)(8 + classCount *2);
//			sendCardFrame.frameData = new byte[classCount * 2];
//			
//			int index = 0;
//			for(int i = 0;i < classCount;i ++)
//			{
//				int machineVolumn = Convert.ToInt32(gridView2.GetDataRow(i)["machine_volumn"]);
//				if(machineVolumn>=0)
//				{
//					machineVolumn = machineVolumn;
//				}
//				else
//				{
//					machineVolumn = 0 - machineVolumn;
//				}
//				sendCardFrame.frameData[index] = Convert.ToByte(gridView2.GetDataRow(i)["machine_address"]);
//				sendCardFrame.frameData[index+1] = Convert.ToByte(machineVolumn);
//
//				index += 2;
//			}
//
//			foreach(DataRow machineAddr in MachineInfo.Tables[0].Rows)
//			{
//				sendCardFrame.desAddr = Convert.ToByte(machineAddr["machine_address"]);
//
//				sendCardFrame.computeCheckSum();
//
//				Monitor.Enter(Login.handleComClass);
//				Login.handleComClass.WriteSerialCmd(sendCardFrame.comFrameLen,sendCardFrame.frameToBytes());//发送问询帧
//				Monitor.Exit(Login.handleComClass);
//
//				timer_SetMachineVolumn.Enabled = true;
//				setMachineVolumn.Suspend();
//			}
//
//			setVolumnTryTime = 0;
//			simpleButton4.Enabled = true;
//			Login.COM_PORT_IS_BUSY = false;
//
//			MessageBox.Show("容量设定成功.","系统信息!",
//				MessageBoxButtons.OK,MessageBoxIcon.Information);
//		}
//
//		//set machine volumn overtime
//		private int setVolumnTryTime = 0;
//		private void timer_SetMachineVolumn_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
//		{
//			timer_SetMachineVolumn.Enabled = false;
//
//			if(setVolumnTryTime<1)//重试1次
//			{
//				try
//				{
//					setMachineVolumn.Abort();
//				}
//				catch
//				{
//					setMachineVolumn = new Thread(new ThreadStart(SetMachineVolumn));
//					setMachineVolumn.IsBackground = true;
//					setMachineVolumn.Priority = ThreadPriority.Normal;
//					setMachineVolumn.Start();
//				}
//
//				setVolumnTryTime ++;
//			}
//			else
//			{
//				try
//				{
//					setMachineVolumn.Abort();
//				}
//				catch
//				{}
//				finally
//				{
//					Login.COM_PORT_IS_BUSY = false;
//					simpleButton4.Enabled = true;
//				}
//
//				setVolumnTryTime = 0;
//				MessageBox.Show("设定容量超时,请重试.","系统信息!",
//					MessageBoxButtons.OK,MessageBoxIcon.Information);
//			}
//		}
//
//		//set machine volumn successed
//		private void login_SetMachineVolumnSuccessed()
//		{
//			timer_SetMachineVolumn.Enabled = false;
//			setMachineVolumn.Resume();
//
//			for(int i = 0;i < gridView2.DataRowCount;i ++)
//			{
//				int machineAddr = Convert.ToInt32(gridView2.GetDataRow(i)["machine_address"]);
//				int machineVolumn = Convert.ToInt32(gridView2.GetDataRow(i)["machine_volumn"]);
//				new MachineSystem().InsertClassMachine(machineAddr,machineVolumn);
//			}
//		}
		#endregion

		private void KgManager_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				timer_AssignAddr.Enabled = false;

				if(null!=login.assignAddress)
				{
					login.assignAddress.Abort();
				}
			//	login.ResumeThread();
			}
			catch
			{
				login.assignAddress.Resume();
				login.assignAddress.Abort();
			}
			finally
			{
				Login.COM_PORT_IS_BUSY = false;
			}
		}
	}
}

