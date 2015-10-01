//==================================================================================
// 创智智能晨检网络管理系统4.0
//==================================================================================
// Copyright @2005 Shanghai Chuangzhi Toy&Technology Corporation All rights reserved.
//本计算机程序受版权法和国际条约保护.
// 如未经授权而擅自复制或传播本程序(或其中任何部分),将受到严厉的民事及刑事制裁,
//并将在法律许可的范围内受到最大程度的起诉!
//==================================================================================

using System;
using System.Drawing;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using CPTT.SystemFramework;
using CPTT.BusinessFacade;
using Microsoft.Practices.EnterpriseLibrary.Configuration;

namespace CPTT.WinUI
{
	/// <summary>
	/// Summary description for CustomInfoDefine.
	/// </summary>
	public class CustomInfoDefine : DevExpress.XtraEditors.XtraForm
	{
		private DevExpress.XtraEditors.GroupControl groupControl_CustomInfo;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl_CustomInfo;
		private DevExpress.Utils.Frames.NotePanel notePanel_TeaCustomInfo;
		private DevExpress.Utils.Frames.NotePanel notePanel_StuCustomInfo;
		private DevExpress.XtraGrid.GridControl gridControl_TeaCustomInfo;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn_TeaPressKey;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn_TeaPressKeyInfo;
		private DevExpress.XtraGrid.GridControl gridControl_StuCustomInfo;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn_StuPressKey;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn_StuPressKeyInfo;
		private System.ComponentModel.IContainer components;
		internal const string USERSTYLEPROFILE_CONFIG_NAME = "UserStyleProfile";
		private DevExpress.XtraEditors.SimpleButton simpleButton_SaveTea;
		private DevExpress.XtraEditors.SimpleButton simpleButton_SaveStu;

		private UserStyle userStyle;

		private DataSet stuState;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		private DataSet teaState;
		private bool isForStudent;
		private bool isSendCustomButtonSucceed = false;
		private System.Windows.Forms.Timer syncCustomButtonTimer;
		private Login login;
		private int syncRetryTime = 0;
		private int lastSyncIndex = 0;

		public CustomInfoDefine(Login login)
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

			LoadTeaStateInfo();

			LoadStuStateInfo();
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CustomInfoDefine));
			this.groupControl_CustomInfo = new DevExpress.XtraEditors.GroupControl();
			this.splitContainerControl_CustomInfo = new DevExpress.XtraEditors.SplitContainerControl();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			this.gridControl_TeaCustomInfo = new DevExpress.XtraGrid.GridControl();
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn_TeaPressKey = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn_TeaPressKeyInfo = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.notePanel_TeaCustomInfo = new DevExpress.Utils.Frames.NotePanel();
			this.simpleButton_SaveTea = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			this.gridControl_StuCustomInfo = new DevExpress.XtraGrid.GridControl();
			this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn_StuPressKey = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn_StuPressKeyInfo = new DevExpress.XtraGrid.Columns.GridColumn();
			this.notePanel_StuCustomInfo = new DevExpress.Utils.Frames.NotePanel();
			this.simpleButton_SaveStu = new DevExpress.XtraEditors.SimpleButton();
			this.syncCustomButtonTimer = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.groupControl_CustomInfo)).BeginInit();
			this.groupControl_CustomInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl_CustomInfo)).BeginInit();
			this.splitContainerControl_CustomInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_TeaCustomInfo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_StuCustomInfo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
			this.SuspendLayout();
			// 
			// groupControl_CustomInfo
			// 
			this.groupControl_CustomInfo.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.groupControl_CustomInfo.Appearance.Options.UseBackColor = true;
			this.groupControl_CustomInfo.Controls.Add(this.splitContainerControl_CustomInfo);
			this.groupControl_CustomInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl_CustomInfo.Location = new System.Drawing.Point(0, 0);
			this.groupControl_CustomInfo.Name = "groupControl_CustomInfo";
			this.groupControl_CustomInfo.Size = new System.Drawing.Size(688, 325);
			this.groupControl_CustomInfo.TabIndex = 0;
			this.groupControl_CustomInfo.Text = "自定义信息设置";
			// 
			// splitContainerControl_CustomInfo
			// 
			this.splitContainerControl_CustomInfo.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitContainerControl_CustomInfo.Location = new System.Drawing.Point(3, 18);
			this.splitContainerControl_CustomInfo.Name = "splitContainerControl_CustomInfo";
			this.splitContainerControl_CustomInfo.Panel1.Controls.Add(this.simpleButton1);
			this.splitContainerControl_CustomInfo.Panel1.Controls.Add(this.gridControl_TeaCustomInfo);
			this.splitContainerControl_CustomInfo.Panel1.Controls.Add(this.notePanel_TeaCustomInfo);
			this.splitContainerControl_CustomInfo.Panel1.Controls.Add(this.simpleButton_SaveTea);
			this.splitContainerControl_CustomInfo.Panel1.Text = "splitContainerControl1_Panel1";
			this.splitContainerControl_CustomInfo.Panel2.Controls.Add(this.simpleButton2);
			this.splitContainerControl_CustomInfo.Panel2.Controls.Add(this.gridControl_StuCustomInfo);
			this.splitContainerControl_CustomInfo.Panel2.Controls.Add(this.notePanel_StuCustomInfo);
			this.splitContainerControl_CustomInfo.Panel2.Controls.Add(this.simpleButton_SaveStu);
			this.splitContainerControl_CustomInfo.Panel2.Text = "splitContainerControl1_Panel2";
			this.splitContainerControl_CustomInfo.Size = new System.Drawing.Size(682, 286);
			this.splitContainerControl_CustomInfo.SplitterPosition = 340;
			this.splitContainerControl_CustomInfo.TabIndex = 0;
			this.splitContainerControl_CustomInfo.Text = "splitContainerControl1";
			// 
			// simpleButton1
			// 
			this.simpleButton1.Location = new System.Drawing.Point(264, 32);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new System.Drawing.Size(64, 23);
			this.simpleButton1.TabIndex = 7;
			this.simpleButton1.Text = "全部清空";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// gridControl_TeaCustomInfo
			// 
			// 
			// gridControl_TeaCustomInfo.EmbeddedNavigator
			// 
			this.gridControl_TeaCustomInfo.EmbeddedNavigator.Name = "";
			this.gridControl_TeaCustomInfo.Location = new System.Drawing.Point(0, 64);
			this.gridControl_TeaCustomInfo.MainView = this.gridView2;
			this.gridControl_TeaCustomInfo.Name = "gridControl_TeaCustomInfo";
			this.gridControl_TeaCustomInfo.Size = new System.Drawing.Size(332, 216);
			this.gridControl_TeaCustomInfo.TabIndex = 6;
			this.gridControl_TeaCustomInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																													 this.gridView2,
																													 this.gridView1});
			// 
			// gridView2
			// 
			this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn_TeaPressKey,
																							 this.gridColumn_TeaPressKeyInfo});
			this.gridView2.GridControl = this.gridControl_TeaCustomInfo;
			this.gridView2.Name = "gridView2";
			this.gridView2.OptionsCustomization.AllowFilter = false;
			this.gridView2.OptionsCustomization.AllowGroup = false;
			this.gridView2.OptionsView.ShowFilterPanel = false;
			this.gridView2.OptionsView.ShowFooter = true;
			this.gridView2.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn_TeaPressKey
			// 
			this.gridColumn_TeaPressKey.Caption = "按键值";
			this.gridColumn_TeaPressKey.FieldName = "teafs_state";
			this.gridColumn_TeaPressKey.Name = "gridColumn_TeaPressKey";
			this.gridColumn_TeaPressKey.OptionsColumn.AllowEdit = false;
			this.gridColumn_TeaPressKey.Visible = true;
			this.gridColumn_TeaPressKey.VisibleIndex = 0;
			// 
			// gridColumn_TeaPressKeyInfo
			// 
			this.gridColumn_TeaPressKeyInfo.Caption = "按键定义";
			this.gridColumn_TeaPressKeyInfo.FieldName = "teafs_name";
			this.gridColumn_TeaPressKeyInfo.Name = "gridColumn_TeaPressKeyInfo";
			this.gridColumn_TeaPressKeyInfo.Visible = true;
			this.gridColumn_TeaPressKeyInfo.VisibleIndex = 1;
			// 
			// gridView1
			// 
			this.gridView1.GridControl = this.gridControl_TeaCustomInfo;
			this.gridView1.Name = "gridView1";
			// 
			// notePanel_TeaCustomInfo
			// 
			this.notePanel_TeaCustomInfo.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel_TeaCustomInfo.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel_TeaCustomInfo.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel_TeaCustomInfo.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_TeaCustomInfo.Location = new System.Drawing.Point(0, 0);
			this.notePanel_TeaCustomInfo.MaxRows = 5;
			this.notePanel_TeaCustomInfo.Name = "notePanel_TeaCustomInfo";
			this.notePanel_TeaCustomInfo.ParentAutoHeight = true;
			this.notePanel_TeaCustomInfo.Size = new System.Drawing.Size(334, 23);
			this.notePanel_TeaCustomInfo.TabIndex = 5;
			this.notePanel_TeaCustomInfo.TabStop = false;
			this.notePanel_TeaCustomInfo.Text = "教师自定义:(最多定义10条)";
			// 
			// simpleButton_SaveTea
			// 
			this.simpleButton_SaveTea.Location = new System.Drawing.Point(200, 32);
			this.simpleButton_SaveTea.Name = "simpleButton_SaveTea";
			this.simpleButton_SaveTea.Size = new System.Drawing.Size(56, 23);
			this.simpleButton_SaveTea.TabIndex = 1;
			this.simpleButton_SaveTea.Text = "保存";
			this.simpleButton_SaveTea.Click += new System.EventHandler(this.simpleButton_SaveTea_Click);
			// 
			// simpleButton2
			// 
			this.simpleButton2.Location = new System.Drawing.Point(256, 32);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.Size = new System.Drawing.Size(64, 23);
			this.simpleButton2.TabIndex = 8;
			this.simpleButton2.Text = "全部清空";
			this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
			// 
			// gridControl_StuCustomInfo
			// 
			// 
			// gridControl_StuCustomInfo.EmbeddedNavigator
			// 
			this.gridControl_StuCustomInfo.EmbeddedNavigator.Name = "";
			this.gridControl_StuCustomInfo.Location = new System.Drawing.Point(0, 64);
			this.gridControl_StuCustomInfo.MainView = this.gridView3;
			this.gridControl_StuCustomInfo.Name = "gridControl_StuCustomInfo";
			this.gridControl_StuCustomInfo.Size = new System.Drawing.Size(334, 216);
			this.gridControl_StuCustomInfo.TabIndex = 6;
			this.gridControl_StuCustomInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																													 this.gridView3});
			// 
			// gridView3
			// 
			this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn_StuPressKey,
																							 this.gridColumn_StuPressKeyInfo});
			this.gridView3.GridControl = this.gridControl_StuCustomInfo;
			this.gridView3.Name = "gridView3";
			this.gridView3.OptionsCustomization.AllowFilter = false;
			this.gridView3.OptionsCustomization.AllowGroup = false;
			this.gridView3.OptionsView.ShowFilterPanel = false;
			this.gridView3.OptionsView.ShowFooter = true;
			this.gridView3.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn_StuPressKey
			// 
			this.gridColumn_StuPressKey.Caption = "按键值";
			this.gridColumn_StuPressKey.FieldName = "state_flowState";
			this.gridColumn_StuPressKey.Name = "gridColumn_StuPressKey";
			this.gridColumn_StuPressKey.OptionsColumn.AllowEdit = false;
			this.gridColumn_StuPressKey.Visible = true;
			this.gridColumn_StuPressKey.VisibleIndex = 0;
			// 
			// gridColumn_StuPressKeyInfo
			// 
			this.gridColumn_StuPressKeyInfo.Caption = "按键定义";
			this.gridColumn_StuPressKeyInfo.FieldName = "state_flowStateName";
			this.gridColumn_StuPressKeyInfo.Name = "gridColumn_StuPressKeyInfo";
			this.gridColumn_StuPressKeyInfo.Visible = true;
			this.gridColumn_StuPressKeyInfo.VisibleIndex = 1;
			// 
			// notePanel_StuCustomInfo
			// 
			this.notePanel_StuCustomInfo.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel_StuCustomInfo.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel_StuCustomInfo.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel_StuCustomInfo.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_StuCustomInfo.Location = new System.Drawing.Point(0, 0);
			this.notePanel_StuCustomInfo.MaxRows = 5;
			this.notePanel_StuCustomInfo.Name = "notePanel_StuCustomInfo";
			this.notePanel_StuCustomInfo.ParentAutoHeight = true;
			this.notePanel_StuCustomInfo.Size = new System.Drawing.Size(332, 23);
			this.notePanel_StuCustomInfo.TabIndex = 5;
			this.notePanel_StuCustomInfo.TabStop = false;
			this.notePanel_StuCustomInfo.Text = "学生自定义(最多定义7条)";
			// 
			// simpleButton_SaveStu
			// 
			this.simpleButton_SaveStu.Location = new System.Drawing.Point(192, 32);
			this.simpleButton_SaveStu.Name = "simpleButton_SaveStu";
			this.simpleButton_SaveStu.Size = new System.Drawing.Size(56, 23);
			this.simpleButton_SaveStu.TabIndex = 1;
			this.simpleButton_SaveStu.Text = "保存";
			this.simpleButton_SaveStu.Click += new System.EventHandler(this.simpleButton_SaveStu_Click);
			// 
			// syncCustomButtonTimer
			// 
			this.syncCustomButtonTimer.Tick += new System.EventHandler(this.syncCustomButtonTimer_Tick);
			// 
			// CustomInfoDefine
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(688, 325);
			this.Controls.Add(this.groupControl_CustomInfo);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "CustomInfoDefine";
			this.ShowInTaskbar = false;
			this.Text = "自定义信息维护";
			this.Load += new System.EventHandler(this.CustomInfoDefine_Load);
			((System.ComponentModel.ISupportInitialize)(this.groupControl_CustomInfo)).EndInit();
			this.groupControl_CustomInfo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl_CustomInfo)).EndInit();
			this.splitContainerControl_CustomInfo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl_TeaCustomInfo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_StuCustomInfo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region restriction on both admin and tourist
		private void CustomInfoDefine_Load(object sender, System.EventArgs e)
		{
			if ( System.Threading.Thread.CurrentPrincipal.Identity.Name.ToLower() == "admin" || System.Threading.Thread.CurrentPrincipal.IsInRole("一般"))
			{
				gridColumn_StuPressKeyInfo.OptionsColumn.AllowEdit = false;
				gridColumn_TeaPressKeyInfo.OptionsColumn.AllowEdit = false;
			}

			login.SendCustomButtonInfoSucceed +=new CPTT.WinUI.Login.SendCustomButtonInfoHandler(login_SendCustomButtonInfoSucceed);
		}
		#endregion

		#region load initial Info
		private void LoadTeaStateInfo()
		{
			teaState = new FlowStateSystem().GetTeaState();

			int count = teaState.Tables[0].Rows.Count;

			for(int i=0;i<count;i++)
			{
				teaState.Tables[0].Rows[i][0] = i;
			}
			


			gridControl_TeaCustomInfo.DataSource = teaState.Tables[0];
		}

		private void LoadStuStateInfo()
		{
			stuState = new FlowStateSystem().GetStuState();

			int count = stuState.Tables[0].Rows.Count;

			for(int i=0;i<count;i++)
			{
				stuState.Tables[0].Rows[i][0] = i;
			}

			gridControl_StuCustomInfo.DataSource = stuState.Tables[0];
		}
		#endregion

		#region save update
		private void simpleButton_SaveTea_Click(object sender, System.EventArgs e)
		{
//			isForStudent = false;
//			lastSyncIndex = 0;
//			isSendCustomButtonSucceed = false;
//			BeginToSendCustomButtonInfo();
//			simpleButton_SaveStu.Enabled = false;
//			simpleButton_SaveTea.Enabled = false;

			/*以上是新功能*/



			FlowStateSystem flowStateSystem = new FlowStateSystem();

			for(int i=0;i<gridView2.RowCount;i++)
			{
				Int16 stateID = (Int16)(Convert.ToInt16(gridView2.GetDataRow(i)["teafs_state"])+2);
				string stateName = gridView2.GetDataRow(i)["teafs_name"].ToString();
				flowStateSystem.UpdateTeaState(stateID,stateName);
//				if (isSendCustomButtonSucceed)
//				{
//					flowStateSystem.UpdateTeaState(stateID,stateName);
//				}
//				else
//				{
//					MessageBox.Show("保存失败，请重试！", "系统信息!", MessageBoxButtons.OK, MessageBoxIcon.Error);
//					return;
//				}
			}

			MessageBox.Show("保存成功.","系统信息!",
				MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		private void simpleButton_SaveStu_Click(object sender, System.EventArgs e)
		{
//			isForStudent = true;
//			lastSyncIndex = 0;
//			isSendCustomButtonSucceed = false;
//			simpleButton_SaveStu.Enabled = false;
//			simpleButton_SaveTea.Enabled = false;
//			BeginToSendCustomButtonInfo();

/*以上是新功能*/

			FlowStateSystem flowStateSystem = new FlowStateSystem();

			for(int i=0;i<gridView3.RowCount;i++)
			{
				Int16 stateID = (Int16)(Convert.ToInt16(gridView3.GetDataRow(i)["state_flowState"])+5);
				string stateName = gridView3.GetDataRow(i)["state_flowStateName"].ToString();
				flowStateSystem.UpdateStuState(stateID,stateName);
				//BeginToSendCustomButtonInfo();

//				if (isSendCustomButtonSucceed)
//				{
//					flowStateSystem.UpdateStuState(stateID,stateName);
//				}
//				else
//				{
//					MessageBox.Show("保存失败，请重试！", "系统信息!", MessageBoxButtons.OK, MessageBoxIcon.Error);
//					return;
//				}
			}

			MessageBox.Show("保存成功.","系统信息!",
				MessageBoxButtons.OK,MessageBoxIcon.Information);
			
		}
		#endregion

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			FlowStateSystem flowStateSystem = new FlowStateSystem();
			flowStateSystem.ClearFlowState(2);
			gridControl_TeaCustomInfo.DataSource = flowStateSystem.GetTeaState().Tables[0];
			MessageBox.Show("清空完毕！");
		}

		private void simpleButton2_Click(object sender, System.EventArgs e)
		{
			FlowStateSystem flowStateSystem = new FlowStateSystem();
			flowStateSystem.ClearFlowState(1);
			gridControl_StuCustomInfo.DataSource = flowStateSystem.GetStuState().Tables[0];
			MessageBox.Show("清空完毕！");
		}

		private void BeginToSendCustomButtonInfo()
		{
			Login.COM_PORT_IS_BUSY = true;

			login.SuspendAllThread();
			login.syncCustomButtonThread = new Thread(new ThreadStart(SendCustomButton));
			login.syncCustomButtonThread.IsBackground = true;
			login.syncCustomButtonThread.Priority = ThreadPriority.Normal;
			login.syncCustomButtonThread.Start();
		}

		private void SendCustomButton()
		{
			try
			{
				DevExpress.XtraGrid.Views.Grid.GridView view = isForStudent ? gridView3 : gridView2;
				int stateID = 0;
				string stateName = "";
				for(int i = lastSyncIndex; i < view.RowCount; i++)
				{
					stateID = Convert.ToInt32(view.GetDataRow(i)[0]);
					stateName = view.GetDataRow(i)[1].ToString();
					DoSendCustomButton(isForStudent ? stateID : stateID + 7, stateName);
					if (isSendCustomButtonSucceed)
					{
						if (isForStudent)
						{
							new FlowStateSystem().UpdateStuState(Convert.ToInt16(stateID + 5), stateName);
						}
						else
						{
							new FlowStateSystem().UpdateTeaState(Convert.ToInt16(stateID + 2), stateName);
						}
						lastSyncIndex++;
					}
					else
					{
						MessageBox.Show("保存失败，请重试！", "系统信息!", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
				MessageBox.Show("保存成功.","系统信息!", MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			finally
			{
				Login.COM_PORT_IS_BUSY = false;
				syncRetryTime = 0;
				simpleButton_SaveStu.Enabled = true;
				simpleButton_SaveTea.Enabled = true;
				login.ResumeQueryThread();
			}
		}

		private void DoSendCustomButton(int stateID, string stateName)
		{
			foreach(DataRow row in new MachineSystem().GetMachineAddrList().Tables[0].Rows)
			{
				DataFrame data = new DataFrame();
				data.sym = new byte[]{(byte)'@',(byte)'@'};
				data.desAddr = Convert.ToByte(row[0]);
				data.srcAddr = 0;
				data.protocol = CPTT.SystemFramework.Util.SEND_CUSTOMBUTTON_TOKEN;
				data.seq = CPTT.SystemFramework.Util.FRAME_SEQUENCE_VALUE;
				byte[] nameBytes = System.Text.Encoding.GetEncoding("gb2312").GetBytes(stateName);
				data.comFrameLen = Convert.ToByte(11 + nameBytes.Length);
				data.frameData = new byte[3 + nameBytes.Length];
				data.frameData[0] = (byte)stateID;
				data.frameData[1] = (byte)0x10;
				for(int i = 0; i < nameBytes.Length; i++)
					data.frameData[2 + i] = nameBytes[i];
				data.frameData[data.frameData.Length - 1] = Convert.ToByte(nameBytes.Length);
				data.computeCheckSum();
	
				Monitor.Enter(Login.syncRoot);
				try
				{
					Login.handleComClass.WriteSerialCmd(data.comFrameLen, data.frameToBytes());//发送问询帧
				}
				finally
				{
					Monitor.Exit(Login.syncRoot);
				}
	
				syncCustomButtonTimer.Enabled = true;
				login.syncCustomButtonThread.Suspend();
			}
		}

		private void login_SendCustomButtonInfoSucceed()
		{
			syncCustomButtonTimer.Enabled = false;
			try
			{
				login.syncCustomButtonThread.Resume();
			}
			catch
			{}
			finally
			{
				Login.COM_PORT_IS_BUSY = false;
				syncRetryTime = 0;
				simpleButton_SaveStu.Enabled = true;
				simpleButton_SaveTea.Enabled = true;
				login.ResumeQueryThread();
			}
		}

		private void syncCustomButtonTimer_Tick(object sender, System.EventArgs e)
		{
			syncCustomButtonTimer.Enabled = false;

			if(syncRetryTime<5)//重试5次
			{
				try
				{
					login.syncCustomButtonThread.Abort();
				}
				catch
				{
					login.syncCustomButtonThread = new Thread(new ThreadStart(SendCustomButton));
					login.syncCustomButtonThread.IsBackground = true;
					login.syncCustomButtonThread.Priority = ThreadPriority.Normal;
					login.syncCustomButtonThread.Start();
				}

				syncRetryTime ++;
			}
			else
			{
				try
				{
					login.syncCustomButtonThread.Resume();
				}
				catch {  }
				finally
				{
					isSendCustomButtonSucceed = false;
					Login.COM_PORT_IS_BUSY = false;
					syncRetryTime = 0;
					simpleButton_SaveStu.Enabled = true;
					simpleButton_SaveTea.Enabled = true;
					login.ResumeQueryThread();
				}
			}
		}
	}
}

