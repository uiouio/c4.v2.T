using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;

using Microsoft.Practices.EnterpriseLibrary.Configuration;
using CPTT.BusinessFacade;
using CPTT.SystemFramework;


namespace CPTT.WinUI
{
	/// <summary>
	/// SetMachineVol 的摘要说明。
	/// </summary>
	public class SetMachineVol : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.GroupControl groupControl2;
		private DevExpress.XtraEditors.SimpleButton simpleButton4;
		private DevExpress.XtraGrid.GridControl gridControl2;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		internal const string USERSTYLEPROFILE_CONFIG_NAME = "UserStyleProfile";
		private UserStyle userStyle;
		private DataSet MachineInfo;
		private DataSet ClassMachineInfo;
		private Login login;
		private System.Timers.Timer timer_SetMachineVolumn;
		private DevExpress.Utils.Frames.NotePanel notePanel_TerminalMachine;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_TerminalMachine;
		private bool hasSetMachineVol = true;
		private DevExpress.Utils.Frames.NotePanel notePanel_BatchMode;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_BatchMode;
		private bool batchMode = true;
		private int getMachineNo = 1;
		private byte currentMachineAddr = 0;
		private int currentGradeNumber = 0;
		private bool isLast = false;
		private System.Windows.Forms.Button btnTest1;
		private System.Windows.Forms.Button btnTest2;
		private bool setVolumeFailed = false;
		private bool hasSendSetVolumnToken = false;
        private SynchronizationContext current;

		public SetMachineVol(Login login)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			this.login = login;
			loadUserStyleProfile();

			timer_SetMachineVolumn.Interval = 30 * 1000;
            current = SynchronizationContext.Current;
		}

		/// <summary>
		/// 清理所有正在使用的资源。
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

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
			this.btnTest2 = new System.Windows.Forms.Button();
			this.btnTest1 = new System.Windows.Forms.Button();
			this.comboBoxEdit_BatchMode = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_BatchMode = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_TerminalMachine = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_TerminalMachine = new DevExpress.Utils.Frames.NotePanel();
			this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
			this.gridControl2 = new DevExpress.XtraGrid.GridControl();
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.timer_SetMachineVolumn = new System.Timers.Timer();
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
			this.groupControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_BatchMode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_TerminalMachine.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.timer_SetMachineVolumn)).BeginInit();
			this.SuspendLayout();
			// 
			// groupControl2
			// 
			this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.groupControl2.AppearanceCaption.Options.UseFont = true;
			this.groupControl2.Controls.Add(this.btnTest2);
			this.groupControl2.Controls.Add(this.btnTest1);
			this.groupControl2.Controls.Add(this.comboBoxEdit_BatchMode);
			this.groupControl2.Controls.Add(this.notePanel_BatchMode);
			this.groupControl2.Controls.Add(this.comboBoxEdit_TerminalMachine);
			this.groupControl2.Controls.Add(this.notePanel_TerminalMachine);
			this.groupControl2.Controls.Add(this.simpleButton4);
			this.groupControl2.Controls.Add(this.gridControl2);
			this.groupControl2.Location = new System.Drawing.Point(24, 14);
			this.groupControl2.Name = "groupControl2";
			this.groupControl2.Size = new System.Drawing.Size(528, 178);
			this.groupControl2.TabIndex = 2;
			this.groupControl2.Text = "Step Two:设定容量";
			// 
			// btnTest2
			// 
			this.btnTest2.Location = new System.Drawing.Point(104, 104);
			this.btnTest2.Name = "btnTest2";
			this.btnTest2.TabIndex = 17;
			this.btnTest2.Text = "班级名成功";
			this.btnTest2.Visible = false;
			this.btnTest2.Click += new System.EventHandler(this.btnTest2_Click);
			// 
			// btnTest1
			// 
			this.btnTest1.Location = new System.Drawing.Point(8, 104);
			this.btnTest1.Name = "btnTest1";
			this.btnTest1.TabIndex = 16;
			this.btnTest1.Text = "容量成功";
			this.btnTest1.Visible = false;
			this.btnTest1.Click += new System.EventHandler(this.btnTest_Click);
			// 
			// comboBoxEdit_BatchMode
			// 
			this.comboBoxEdit_BatchMode.EditValue = "群分模式";
			this.comboBoxEdit_BatchMode.Location = new System.Drawing.Point(120, 72);
			this.comboBoxEdit_BatchMode.Name = "comboBoxEdit_BatchMode";
			// 
			// comboBoxEdit_BatchMode.Properties
			// 
			this.comboBoxEdit_BatchMode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																														   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_BatchMode.Properties.Items.AddRange(new object[] {
																				   "群分模式",
																				   "单分模式"});
			this.comboBoxEdit_BatchMode.Size = new System.Drawing.Size(80, 23);
			this.comboBoxEdit_BatchMode.TabIndex = 15;
			this.comboBoxEdit_BatchMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_BatchMode_SelectedIndexChanged);
			// 
			// notePanel_BatchMode
			// 
			this.notePanel_BatchMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.notePanel_BatchMode.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_BatchMode.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_BatchMode.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_BatchMode.ForeColor = System.Drawing.Color.Black;
			this.notePanel_BatchMode.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_BatchMode.Location = new System.Drawing.Point(32, 72);
			this.notePanel_BatchMode.MaxRows = 5;
			this.notePanel_BatchMode.Name = "notePanel_BatchMode";
			this.notePanel_BatchMode.ParentAutoHeight = true;
			this.notePanel_BatchMode.Size = new System.Drawing.Size(80, 22);
			this.notePanel_BatchMode.TabIndex = 14;
			this.notePanel_BatchMode.TabStop = false;
			this.notePanel_BatchMode.Text = "分配模式:";
			// 
			// comboBoxEdit_TerminalMachine
			// 
			this.comboBoxEdit_TerminalMachine.EditValue = "1";
			this.comboBoxEdit_TerminalMachine.Location = new System.Drawing.Point(120, 40);
			this.comboBoxEdit_TerminalMachine.Name = "comboBoxEdit_TerminalMachine";
			// 
			// comboBoxEdit_TerminalMachine.Properties
			// 
			this.comboBoxEdit_TerminalMachine.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_TerminalMachine.Size = new System.Drawing.Size(80, 23);
			this.comboBoxEdit_TerminalMachine.TabIndex = 13;
			this.comboBoxEdit_TerminalMachine.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_TerminalMachine_SelectedIndexChanged);
			// 
			// notePanel_TerminalMachine
			// 
			this.notePanel_TerminalMachine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.notePanel_TerminalMachine.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_TerminalMachine.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_TerminalMachine.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_TerminalMachine.ForeColor = System.Drawing.Color.Black;
			this.notePanel_TerminalMachine.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_TerminalMachine.Location = new System.Drawing.Point(32, 40);
			this.notePanel_TerminalMachine.MaxRows = 5;
			this.notePanel_TerminalMachine.Name = "notePanel_TerminalMachine";
			this.notePanel_TerminalMachine.ParentAutoHeight = true;
			this.notePanel_TerminalMachine.Size = new System.Drawing.Size(80, 22);
			this.notePanel_TerminalMachine.TabIndex = 12;
			this.notePanel_TerminalMachine.TabStop = false;
			this.notePanel_TerminalMachine.Text = " 门口机:";
			// 
			// simpleButton4
			// 
			this.simpleButton4.Location = new System.Drawing.Point(56, 136);
			this.simpleButton4.Name = "simpleButton4";
			this.simpleButton4.Size = new System.Drawing.Size(128, 23);
			this.simpleButton4.TabIndex = 2;
			this.simpleButton4.Text = "设定门口机容量";
			this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
			// 
			// gridControl2
			// 
			this.gridControl2.Dock = System.Windows.Forms.DockStyle.Right;
			// 
			// gridControl2.EmbeddedNavigator
			// 
			this.gridControl2.EmbeddedNavigator.Name = "";
			this.gridControl2.Location = new System.Drawing.Point(229, 18);
			this.gridControl2.MainView = this.gridView2;
			this.gridControl2.Name = "gridControl2";
			this.gridControl2.Size = new System.Drawing.Size(296, 157);
			this.gridControl2.TabIndex = 3;
			this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.gridView2});
			// 
			// gridView2
			// 
			this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn5,
																							 this.gridColumn6});
			this.gridView2.GridControl = this.gridControl2;
			this.gridView2.Name = "gridView2";
			this.gridView2.OptionsCustomization.AllowFilter = false;
			this.gridView2.OptionsCustomization.AllowGroup = false;
			this.gridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
			this.gridView2.OptionsView.ShowFilterPanel = false;
			this.gridView2.OptionsView.ShowFooter = true;
			this.gridView2.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn5
			// 
			this.gridColumn5.Caption = "班级编号";
			this.gridColumn5.FieldName = "machine_address";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.Visible = true;
			this.gridColumn5.VisibleIndex = 0;
			// 
			// gridColumn6
			// 
			this.gridColumn6.Caption = "班级容量";
			this.gridColumn6.FieldName = "machine_volumn";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 1;
			// 
			// timer_SetMachineVolumn
			// 
			this.timer_SetMachineVolumn.SynchronizingObject = this;
			this.timer_SetMachineVolumn.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_SetMachineVolumn_Elapsed);
			// 
			// SetMachineVol
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(568, 221);
			this.Controls.Add(this.groupControl2);
			this.Name = "SetMachineVol";
			this.ShowInTaskbar = false;
			this.Text = "SetMachineVol";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.SetMachineVol_Closing);
			this.Load += new System.EventHandler(this.SetMachineVol_Load);
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
			this.groupControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_BatchMode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_TerminalMachine.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.timer_SetMachineVolumn)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void SetMachineVol_Load(object sender, System.EventArgs e)
		{
//			login.SetMachineVolumnSuccessed -= new CPTT.WinUI.Login.SetMachineVolumnSuccessedHandler(login_SetMachineVolumnSuccessed);
//			login.SendClassNameSucceed -= new CPTT.WinUI.Login.SendClassNameSuccessHandler(login_SendClassNameSucceed);
//			
//			login.SetMachineVolumnSuccessed += new CPTT.WinUI.Login.SetMachineVolumnSuccessedHandler(login_SetMachineVolumnSuccessed);
//			login.SendClassNameSucceed += new CPTT.WinUI.Login.SendClassNameSuccessHandler(login_SendClassNameSucceed);

			this.login.SetVol = this;

			MachineInfo = new MachineSystem().GetMachineAddrList();

			ClassMachineInfo = new MachineSystem().GetClassMachineAddrList();

			gridControl2.DataSource = ClassMachineInfo.Tables[0];

			if ( MachineInfo.Tables[0].Rows.Count > 0 )
			{
				foreach(DataRow row in MachineInfo.Tables[0].Rows)
					comboBoxEdit_TerminalMachine.Properties.Items.AddRange(new object[]{row["machine_address"]});
			}
			if (ClassMachineInfo.Tables[0].Rows.Count > 0)
				currentGradeNumber = Convert.ToInt32(ClassMachineInfo.Tables[0].Rows[0]["info_gradeNumber"]);
		}

		public void login_SetMachineVolumnSuccessed()
		{
			timer_SetMachineVolumn.Enabled = false;
//			Login.COM_PORT_IS_BUSY = false;
//			login.setMachineVolumn.Resume();
			
			if (hasSendSetVolumnToken)
			{
				Thread thread = new Thread(new ThreadStart(SendClassName));
				thread.IsBackground = true;
				thread.Start();

				hasSendSetVolumnToken = false;

				for(int i = 0;i < gridView2.DataRowCount;i ++)
				{
					int machineAddr = Convert.ToInt32(gridView2.GetDataRow(i)["machine_address"]);
					int machineVolumn = Convert.ToInt32(gridView2.GetDataRow(i)["machine_volumn"]);
					new MachineSystem().InsertClassMachine(machineAddr,machineVolumn);
				}
			}

//			simpleButton4.Enabled = true;
		}

		private void simpleButton4_Click(object sender, System.EventArgs e)
		{
			hasSetMachineVol = true;

			if(gridView2.RowCount == 0)
			{
				MessageBox.Show("没有班级记录,请先填写班级记录.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}

			Login.COM_PORT_IS_BUSY = true;

			login.SuspendAllThread();
			login.setMachineVolumn = new Thread(new ThreadStart(SetMachineVolumn));
			login.setMachineVolumn.IsBackground = true;
			login.setMachineVolumn.Priority = ThreadPriority.Normal;
			login.setMachineVolumn.Start();
		}

		private void SetMachineVolumn()
		{
            current.Send((_) => simpleButton4.Enabled = false, null);

			int classCount = gridView2.DataRowCount;

			DataFrame sendCardFrame = new DataFrame();

			sendCardFrame.sym = new byte[]{(byte)'@',(byte)'@'};
			sendCardFrame.srcAddr = 0;
			sendCardFrame.seq = CPTT.SystemFramework.Util.FRAME_SEQUENCE_VALUE;
			sendCardFrame.protocol = CPTT.SystemFramework.Util.SET_DOOR_VOLUME;
			sendCardFrame.comFrameLen = (byte)(8 + (classCount+5) *2); //(byte)(8 + (classCount+2) *2);
			sendCardFrame.frameData = new byte[(classCount+5) * 2]; //new byte[(classCount+2) * 2]
			int machineVolumn = 0;

			int index = 0;
			for(int i = 0;i < classCount;i ++)
			{
				machineVolumn = Convert.ToInt32(gridView2.GetDataRow(i)["machine_volumn"]);
				if(machineVolumn>=0)
				{
					machineVolumn = machineVolumn;
				}
				else
				{
					machineVolumn = 0 - machineVolumn;
				}

				int classNum = Convert.ToInt32(gridView2.GetDataRow(i)["machine_address"]);
				classNum = classNum/10*16 + classNum%10;
				sendCardFrame.frameData[index++] = Convert.ToByte(classNum);
				sendCardFrame.frameData[index++] = Convert.ToByte(machineVolumn);
			}

			sendCardFrame.frameData[index] = Convert.ToByte((91/10*16 + 91%10));
			sendCardFrame.frameData[index + 1] = Convert.ToByte(70);
			sendCardFrame.frameData[index + 2] = Convert.ToByte((92 / 10 * 16 + 92 % 10));
			sendCardFrame.frameData[index + 3] = Convert.ToByte(70);
			sendCardFrame.frameData[index + 4] = Convert.ToByte((93 / 10 * 16 + 93 % 10));
			sendCardFrame.frameData[index + 5] = Convert.ToByte(70);
			sendCardFrame.frameData[index + 6] = Convert.ToByte((94 / 10 * 16 + 94 % 10));
			sendCardFrame.frameData[index + 7] = Convert.ToByte(70);
			sendCardFrame.frameData[index + 8] = Convert.ToByte((95 / 10 * 16 + 95 % 10));
			sendCardFrame.frameData[index + 9] = Convert.ToByte(70);

			//last is 28->81
			if (classCount > 81)
			{
				MessageBox.Show("学生班级数量不能超过81,请重试.", "系统信息!",
					MessageBoxButtons.OK, MessageBoxIcon.Information);

				Login.COM_PORT_IS_BUSY = false;

				login.ResumeQueryThread();

				simpleButton4.Enabled = true;
					
				return;
			}

			//special edition for people volume expanding
			//the last max volume is 1200->1420
			//the last max volume is 1420->3000
			if (SystemFramework.Util.CardVersion == 5)
			{
				if ((classCount * machineVolumn + 140) > 3000)
				{
					MessageBox.Show("超出门口机容量,请重试.", "系统信息!",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					Login.COM_PORT_IS_BUSY = false;

					login.ResumeQueryThread();

					simpleButton4.Enabled = true;
					return;
				}
			}

			isLast = false;
			if ( batchMode )
			{
				foreach(DataRow machineAddr in MachineInfo.Tables[0].Rows)
				{
					if (setVolumeFailed)
						break;

					isLast = false;

					currentMachineAddr = Convert.ToByte(machineAddr["machine_address"]);
					sendCardFrame.desAddr = currentMachineAddr;

					sendCardFrame.computeCheckSum();

					Monitor.Enter(Login.syncRoot);
					try
					{
						hasSendSetVolumnToken = true;
						Login.handleComClass.WriteSerialCmd(sendCardFrame.comFrameLen,sendCardFrame.frameToBytes());//发送问询帧
					}
					catch(Exception)
					{
						hasSendSetVolumnToken = false;
					}
					finally
					{
						Monitor.Exit(Login.syncRoot);
					}

					//								timer_SetMachineVolumn.Enabled = true;
					login.setMachineVolumn.Suspend();
				}
			}
			else
			{
				currentMachineAddr = Convert.ToByte(getMachineNo);
				sendCardFrame.desAddr = Convert.ToByte(getMachineNo);
				sendCardFrame.computeCheckSum();
				Monitor.Enter(Login.syncRoot);
				try
				{
					Login.handleComClass.WriteSerialCmd(sendCardFrame.comFrameLen,sendCardFrame.frameToBytes());//发送问询帧
					hasSendSetVolumnToken = true;
				}
				finally
				{
					Monitor.Exit(Login.syncRoot);
				}

				//								timer_SetMachineVolumn.Enabled = true;
				login.setMachineVolumn.Suspend();
			}

			if ( hasSetMachineVol )
			{
				setVolumnTryTime = 0;
                current.Send((_) => simpleButton4.Enabled = true, null);
				Login.COM_PORT_IS_BUSY = false;

				login.ResumeQueryThread();

				MessageBox.Show("容量设定成功.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);

				login.setMachineVolumn.Abort();
			}

			currentGradeNumber = 0;
			currentMachineAddr = 0;
			isLast = false;
			setVolumeFailed = false;
		}

		private int setVolumnTryTime = 0;
		private void timer_SetMachineVolumn_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			timer_SetMachineVolumn.Enabled = false;

			if(setVolumnTryTime<1)//重试1次
			{
				try
				{
					login.setMachineVolumn.Abort();
				}
				catch
				{
					login.setMachineVolumn = new Thread(new ThreadStart(SetMachineVolumn));
					login.setMachineVolumn.IsBackground = true;
					login.setMachineVolumn.Priority = ThreadPriority.Normal;
					login.setMachineVolumn.Start();
				}

				setVolumnTryTime ++;
			}
			else
			{
				try
				{
//					login.setMachineVolumn.Abort();
					login.setMachineVolumn.Resume();
				}
				catch
				{}
				finally
				{
					hasSetMachineVol = false;
					Login.COM_PORT_IS_BUSY = false;
					simpleButton4.Enabled = true;
				}

				setVolumnTryTime = 0;
//				login.ResumeThread();
				login.ResumeQueryThread();
				MessageBox.Show("设定容量超时,请重试.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}

		private void SetMachineVol_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				login.setMachineVolumn.Abort();
//				login.ResumeThread();

				timer_SetMachineVolumn.Enabled = false;
			}
			catch
			{
				login.setMachineVolumn.Resume();
				login.setMachineVolumn.Abort();
			}
			finally
			{
				isLast = false;
				setVolumeFailed = false;
				hasSendSetVolumnToken = false;
				currentMachineAddr = 0;
				if (ClassMachineInfo.Tables[0].Rows.Count > 0)
					currentGradeNumber = Convert.ToInt32(ClassMachineInfo.Tables[0].Rows[0]["info_gradeNumber"]);
				if ( Login.COM_PORT_IS_BUSY )
				{
					Login.COM_PORT_IS_BUSY = false;
					login.ResumeQueryThread();
				}
				this.Dispose();
//				else
//					Login.COM_PORT_IS_BUSY = false;
			}
		}

		private void comboBoxEdit_TerminalMachine_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			getMachineNo = Convert.ToInt32(comboBoxEdit_TerminalMachine.SelectedItem.ToString());
		}

		private void comboBoxEdit_BatchMode_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( comboBoxEdit_BatchMode.SelectedIndex == 0 )
				batchMode = true;
			else
				batchMode = false;
		}

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			int rtnState = new MachineSystem().CreateClassMachine();

			if (rtnState > 0)
			{
				ClassMachineInfo = new MachineSystem().GetClassMachineAddrList();

				gridControl2.DataSource = ClassMachineInfo.Tables[0];
			}
			else
			{
				MessageBox.Show("班级生成失败，请重试！");
			}
			
		}

		private void SendClassName()
		{
			if (currentMachineAddr == 0)
			{
				setVolumeFailed = true;
				login.setMachineVolumn.Resume();
				MessageBox.Show(string.Format("对门口机{0}设定容量失败！", currentMachineAddr));
				return;
			}

			DataFrame data = new DataFrame();
			data.sym = new byte[]{(byte)'@',(byte)'@'};
			data.desAddr = currentMachineAddr;
			data.srcAddr = 0;
			data.protocol = CPTT.SystemFramework.Util.SEND_CLASSNAME_TOKEN;
			data.seq = CPTT.SystemFramework.Util.FRAME_SEQUENCE_VALUE;
			
			ArrayList nameList = new ArrayList();
			ArrayList numberList = new ArrayList();
			int totalNameLength = 0;
		
			int classNumberTemp = 0;
			for(int i = 0;i < gridView2.DataRowCount;i ++)
			{
				int gradeNumber = Convert.ToInt32(gridView2.GetDataRow(i)["info_gradeNumber"]);
				if (currentGradeNumber != gradeNumber)
				{
					if (currentGradeNumber < gradeNumber)
					{
						currentGradeNumber = gradeNumber;
						break;
					}
				}
				else
				{
					byte[] nameBytes = System.Text.Encoding.GetEncoding("gb2312").GetBytes(gridView2.GetDataRow(i)["info_className"].ToString());
					nameList.Add(nameBytes);
					totalNameLength += nameBytes.Length;
					classNumberTemp = Convert.ToInt32(gridView2.GetDataRow(i)["machine_address"]);
					int classNum = classNumberTemp;
					classNum = classNum/10*16 + classNum%10;
					numberList.Add(classNum);
				}

				if (i == gridView2.DataRowCount - 1)
					isLast = true;

			}
			
			if (nameList.Count != numberList.Count)
			{
				setVolumeFailed = true;
				login.setMachineVolumn.Resume();
				MessageBox.Show(string.Format("对门口机{0}设定容量失败！", currentMachineAddr));
				return;
			}

			//numberList.Count * 2 其中包括一个字节描述namebytes的长度
			//1个字节描述年级
			data.comFrameLen = Convert.ToByte(8 + 1 + numberList.Count * 2 + totalNameLength);
			data.frameData = new byte[1 + numberList.Count * 2 + totalNameLength];

			DataSet gradeInfo = new GradeSystem().GetGradeInfo(classNumberTemp / 10);
			int gradeNumberMapping = 5;
			if (gradeInfo.Tables.Count > 0)
			{
				string gradeName = gradeInfo.Tables[0].Rows[0]["info_gradeName"].ToString();
				switch(gradeName)
				{
					case "托班":gradeNumberMapping = 1;
						break;
					case "小班":gradeNumberMapping = 2;
						break;
					case "中班":gradeNumberMapping = 3;
						break;
					case "大班":gradeNumberMapping = 4;
						break;
					default:gradeNumberMapping = 5;
						break;
				}
			}

			data.frameData[0] = Convert.ToByte(gradeNumberMapping);
			int cursor = 1;
			for(int i = 0; i < nameList.Count; i++)
			{
				data.frameData[cursor++] = Convert.ToByte(numberList[i]);
				byte[] nameBytes = (byte[])nameList[i];
				data.frameData[cursor++] = Convert.ToByte(nameBytes.Length);
				for(int j = 0; j < nameBytes.Length; j++)
				{
					data.frameData[cursor++] = nameBytes[j];
				}
			}

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
		}

		public void login_SendClassNameSucceed()
		{
			if (!isLast)
			{
				Thread thread = new Thread(new ThreadStart(SendClassName));
				thread.IsBackground = true;
				thread.Start();
			}
			else
			{
				hasSetMachineVol = true;
				login.setMachineVolumn.Resume();
				if (ClassMachineInfo.Tables[0].Rows.Count > 0)
					currentGradeNumber = Convert.ToInt32(ClassMachineInfo.Tables[0].Rows[0]["info_gradeNumber"]);
			}
		}

		private void btnTest_Click(object sender, System.EventArgs e)
		{
			login_SetMachineVolumnSuccessed();
		}

		private void btnTest2_Click(object sender, System.EventArgs e)
		{
			login_SendClassNameSucceed();
		}
	}
}
