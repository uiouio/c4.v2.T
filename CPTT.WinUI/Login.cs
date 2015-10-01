//==================================================================================
// 创智智能晨检网络管理系统4.0
//==================================================================================
// Copyright @2005 Shanghai Chuangzhi Toy&Technology Corporation All rights reserved.
//本计算机程序受版权法和国际条约保护.
// 如未经授权而擅自复制或传播本程序(或其中任何部分),将受到严厉的民事及刑事制裁,
//并将在法律许可的范围内受到最大程度的起诉!
//==================================================================================

//未修改的问题：默认服务器为客户端，因此当服务器第一次连接的时候提示已超过最大客户端连接数
#define SoftwareRegister
#undef SoftwareRegister
#define MaxClients
#undef MaxClients

using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.ServiceProcess;
using System.Xml;
using CPTT.BusinessFacade;
using CPTT.SystemFramework;
using CTRLSERIALLib;
using Microsoft.Practices.EnterpriseLibrary.Configuration;
using Microsoft.Win32;
using RexDataProtector;
using System.Threading.Tasks;
using CPTT.BusinessRule;


namespace CPTT.WinUI
{
	/// <summary>
	/// Summary description for Login.
	/// </summary>
	public class Login : DevExpress.XtraEditors.XtraForm
	{
		public DevExpress.XtraEditors.SimpleButton simpleButton_Login;
		private DevExpress.XtraEditors.TextEdit textEdit_UserLoginID;
		private System.Windows.Forms.Label label_LoginID;
		private System.Windows.Forms.Label label_LoginPwd;
		private DevExpress.XtraEditors.TextEdit textEdit_UserLoginPwd;
		private DevExpress.XtraEditors.SimpleButton simpleButton_Register;
		private DevExpress.XtraEditors.SimpleButton simpleButton_Exit;

		private MainForm mainForm = null;
		private UserSystem userSystem;

		private Point mouseOffset;
		public System.Windows.Forms.Timer fadeTimer;
		private System.ComponentModel.IContainer components;

		public bool formShowing = true;

		public User loginUser;
		private UtilSystem utilSystem;

		public static bool COM_PORT_IS_BUSY = false;
		public static HandleCom handleComClass;
		public static object syncRoot = new object();

		private HandleComData handleComData;
		private ControlFrame controlFrame;
		private ControlFrame responseFrame;
		private MachineSystem machineSystem;
		private DataSet machineAddrList;
		private Thread prepareForCheckThread;
		private ArrayList _alUnAuthenticatedHardWare;
		private ArrayList _alAuthenticatedHardWare;
		private int _registerDays;
		public System.Timers.Timer timer_AutoShutDown;
		public bool isAutoShutDown;
		private System.Timers.Timer timer_MedicineRemind;
		public DateTime shutDownTime;

		public delegate void SendCardSuccessedHandler();
		public delegate void SendCardFailedHandler();
		public delegate void ValidateCardInfoReturnHandler(byte[] receiveData);
		public delegate void LogoutCardSuccessedHandler();
		public delegate void SynchTimeSuccessedHandler();
		public delegate void AssignAddressSuccessedHandler();
		public delegate void SetMachineVolumnSuccessedHandler();
		public delegate void HardWareAuthenticationSucceedHandler(byte srcAddr);
		public delegate void SendUserNameSuccessHandler();
		public delegate void SendCustomButtonInfoHandler();
		public delegate void SendClassNameSuccessHandler();

		public event SendCardSuccessedHandler SendCardSuccessed;
		public event SendCardFailedHandler SendCardFailed;
		public event ValidateCardInfoReturnHandler ValidateCardInfoReturn;
		public event LogoutCardSuccessedHandler LogtouCardSuccessed;
		public event SynchTimeSuccessedHandler SynchTimeSuccessed; 
		public event AssignAddressSuccessedHandler AssignAddressSuccessed;
		public event SetMachineVolumnSuccessedHandler SetMachineVolumnSuccessed;
		public event HardWareAuthenticationSucceedHandler HardWareAuthenticationSucceed;
		public event SendUserNameSuccessHandler SendUserNameSucceed;
		public event SendCustomButtonInfoHandler SendCustomButtonInfoSucceed;
		public event SendClassNameSuccessHandler SendClassNameSucceed;

		private static DateTime _lastSyncDate = DateTime.Now;

		private DataSet _dsUpload;

		private Thread _upLoadDataThread;

		private bool isAllowedToResponse = false;

        public static int uploadCount = 0;
        public static int uploadTeacherCount = 0;

		#region Thread Control
		public Thread queryThread;

		public Thread sendCardThread;
		public Thread validateCardThread;
		public Thread leaveCardThread;
		public Thread receiveFromCar;
		public Thread synchDateThread;
		public Thread syncCustomButtonThread;

		public Thread assignAddress;
		private DevExpress.XtraEditors.SimpleButton simpleButton_Service;
		private System.Timers.Timer timer_DetectDate;
		private DevExpress.XtraEditors.SimpleButton simpleButton_restore;
		public Thread setMachineVolumn;

		public void ResumeThread()
		{
			queryThread = new Thread(new ThreadStart(SendQuery));
			queryThread.IsBackground = true;
			queryThread.Priority = ThreadPriority.Normal;
			queryThread.Start();
//			queryThread.Resume();
		}

		public void SuspendAllThread()
		{
			if(null!=queryThread)
			{
				try
				{
//					queryThread.Abort();
					queryThread.Suspend();
				}
				catch
				{
				}
			}

			if(null!=sendCardThread)
			{
				try
				{
					sendCardThread.Abort();
				}
				catch
				{
				}
			}

			if(null!=validateCardThread)
			{
				try
				{
					validateCardThread.Abort();
				}
				catch
				{
				}
			}

			if(null!=leaveCardThread)
			{
				try
				{
					leaveCardThread.Abort();
				}
				catch
				{
				}
			}

			if(null!=receiveFromCar)
			{
				try
				{
					receiveFromCar.Abort();
				}
				catch
				{
				}
			}

			if(null!=synchDateThread)
			{
				try
				{
					synchDateThread.Abort();
				}
				catch
				{
				}
			}

			if(null!=assignAddress)
			{
				try
				{
					assignAddress.Abort();
				}
				catch
				{
				}
			}

			if(null!=setMachineVolumn)
			{
				try
				{
					setMachineVolumn.Abort();
				}
				catch
				{
				}
			}
			if (null != syncCustomButtonThread)
			{
				try
				{
					syncCustomButtonThread.Abort();
				}
				catch
				{
				}
			}
		}

		public void ResumeQueryThread()
		{
			if ( null != queryThread )
			{
				try
				{
					queryThread.Resume();
				}
				catch
				{}
			}
		}
		#endregion

		public Login()
		{
			utilSystem = new UtilSystem();

#if MaxClients
			int maxClients = utilSystem.GetMaxClients();

			if ( maxClients != -1 ) CPTT.SystemFramework.Util.MaxClients = maxClients;
			else 
			{
				MessageBox.Show("初始化服务器会话状态时发生严重错误,请与供应商联系！");
				return;
			}
#endif

			_alUnAuthenticatedHardWare = HardWareAuthentication.GetUnAuthorizedHardWare();
			_alAuthenticatedHardWare = HardWareAuthentication.GetAuthorizedHardWare();
			_registerDays = HardWareAuthentication.GetDaysValid;

			//显示Splash
//			Splash splash = new Splash();
//			splash.StartPosition = FormStartPosition.CenterScreen;
//			splash.Show();

			//初始化LoginForm
			InitializeComponent();

			userSystem = new UserSystem();
			
			ArrayList settings = ConfigurationManager.GetConfiguration("CustomizeSettings") as ArrayList;

			isAutoShutDown = Convert.ToBoolean((settings[2] as XmlNode[])[1].InnerText);
//			shutDownTime = Convert.ToDateTime((settings[3] as XmlNode[])[1].InnerText);

			if(isAutoShutDown)
			{
				timer_AutoShutDown.Enabled = true;
			}

//			appUpdater_ForCTPP.UpdateUrl = CPTT.SystemFramework.Util.AUTO_UPDATE_ADDRESS;

			prepareForCheckThread = new Thread(new ThreadStart(PrepareForCheck));
			prepareForCheckThread.IsBackground = true;
			prepareForCheckThread.Priority = ThreadPriority.Normal;
			prepareForCheckThread.Start();

			//splash.Close();

			//初始化查询线程
			if(!COM_PORT_IS_BUSY)
			{
				handleComClass = new HandleCom();
				handleComClass.Start(CPTT.SystemFramework.Util.COM1_PORT_NUMBER,CPTT.SystemFramework.Util.COM_BAUD_RATE,1);
				handleComClass.DataArrived += new _IHandleComEvents_DataArrivedEventHandler(handleComClass_DataArrived);

				machineSystem = new MachineSystem();
		
				queryThread = new Thread(new ThreadStart(SendQuery));
				queryThread.IsBackground = true;
				queryThread.Priority = ThreadPriority.Normal;
				queryThread.Start();

//				queryThread = new Thread(new ThreadStart(SendHardWareAuthenticationToken));
//				queryThread.IsBackground = true;
//				queryThread.Priority = ThreadPriority.Normal;
//				queryThread.Start();

				controlFrame = new ControlFrame();

				responseFrame = new ControlFrame();

				responseFrame.sym = new byte[]{(byte)'*',(byte)'*'};
				//			responseFrame.desAddr = 1;
				responseFrame.srcAddr = 0;
				responseFrame.response = CPTT.SystemFramework.Util.RECEIVE_SUCCESS_TOKEN;
				responseFrame.seq = CPTT.SystemFramework.Util.FRAME_SEQUENCE_VALUE;

				handleComData = new HandleComData(this.InsertMorningCheckData);
			}

			this.StartPosition = FormStartPosition.CenterScreen;

//			this.Opacity = 0.0;
//			Activate();
//			Refresh();
//			fadeTimer.Start();
//			Refresh();

			textEdit_UserLoginID.Text="";
			textEdit_UserLoginPwd.Text="";
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Login));
			this.simpleButton_Login = new DevExpress.XtraEditors.SimpleButton();
			this.textEdit_UserLoginID = new DevExpress.XtraEditors.TextEdit();
			this.label_LoginID = new System.Windows.Forms.Label();
			this.label_LoginPwd = new System.Windows.Forms.Label();
			this.textEdit_UserLoginPwd = new DevExpress.XtraEditors.TextEdit();
			this.simpleButton_Register = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_Exit = new DevExpress.XtraEditors.SimpleButton();
			this.fadeTimer = new System.Windows.Forms.Timer(this.components);
			this.timer_AutoShutDown = new System.Timers.Timer();
			this.timer_MedicineRemind = new System.Timers.Timer();
			this.simpleButton_Service = new DevExpress.XtraEditors.SimpleButton();
			this.timer_DetectDate = new System.Timers.Timer();
			this.simpleButton_restore = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_UserLoginID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_UserLoginPwd.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.timer_AutoShutDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.timer_MedicineRemind)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.timer_DetectDate)).BeginInit();
			this.SuspendLayout();
			// 
			// simpleButton_Login
			// 
			this.simpleButton_Login.Location = new System.Drawing.Point(296, 296);
			this.simpleButton_Login.Name = "simpleButton_Login";
			this.simpleButton_Login.TabIndex = 3;
			this.simpleButton_Login.Text = "登陆";
			this.simpleButton_Login.Click += new System.EventHandler(this.simpleButton_Login_Click);
			// 
			// textEdit_UserLoginID
			// 
			this.textEdit_UserLoginID.EditValue = "";
			this.textEdit_UserLoginID.Location = new System.Drawing.Point(384, 216);
			this.textEdit_UserLoginID.Name = "textEdit_UserLoginID";
			// 
			// textEdit_UserLoginID.Properties
			// 
			this.textEdit_UserLoginID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
			this.textEdit_UserLoginID.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.textEdit_UserLoginID.Properties.Appearance.BorderColor = System.Drawing.Color.Lime;
			this.textEdit_UserLoginID.Properties.Appearance.ForeColor = System.Drawing.Color.Gray;
			this.textEdit_UserLoginID.Properties.Appearance.Options.UseBackColor = true;
			this.textEdit_UserLoginID.Properties.Appearance.Options.UseBorderColor = true;
			this.textEdit_UserLoginID.Properties.Appearance.Options.UseForeColor = true;
			this.textEdit_UserLoginID.Size = new System.Drawing.Size(112, 21);
			this.textEdit_UserLoginID.TabIndex = 1;
			// 
			// label_LoginID
			// 
			this.label_LoginID.BackColor = System.Drawing.Color.Transparent;
			this.label_LoginID.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label_LoginID.ForeColor = System.Drawing.Color.White;
			this.label_LoginID.Location = new System.Drawing.Point(288, 216);
			this.label_LoginID.Name = "label_LoginID";
			this.label_LoginID.Size = new System.Drawing.Size(72, 23);
			this.label_LoginID.TabIndex = 6;
			this.label_LoginID.Text = "用户名 :";
			this.label_LoginID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label_LoginPwd
			// 
			this.label_LoginPwd.BackColor = System.Drawing.Color.Transparent;
			this.label_LoginPwd.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label_LoginPwd.ForeColor = System.Drawing.Color.White;
			this.label_LoginPwd.Location = new System.Drawing.Point(288, 256);
			this.label_LoginPwd.Name = "label_LoginPwd";
			this.label_LoginPwd.Size = new System.Drawing.Size(72, 23);
			this.label_LoginPwd.TabIndex = 7;
			this.label_LoginPwd.Text = "密  码 :";
			this.label_LoginPwd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textEdit_UserLoginPwd
			// 
			this.textEdit_UserLoginPwd.EditValue = "";
			this.textEdit_UserLoginPwd.Location = new System.Drawing.Point(384, 256);
			this.textEdit_UserLoginPwd.Name = "textEdit_UserLoginPwd";
			// 
			// textEdit_UserLoginPwd.Properties
			// 
			this.textEdit_UserLoginPwd.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.textEdit_UserLoginPwd.Properties.Appearance.BorderColor = System.Drawing.Color.Lime;
			this.textEdit_UserLoginPwd.Properties.Appearance.ForeColor = System.Drawing.Color.Gray;
			this.textEdit_UserLoginPwd.Properties.Appearance.Options.UseBackColor = true;
			this.textEdit_UserLoginPwd.Properties.Appearance.Options.UseBorderColor = true;
			this.textEdit_UserLoginPwd.Properties.Appearance.Options.UseForeColor = true;
			this.textEdit_UserLoginPwd.Properties.PasswordChar = '*';
			this.textEdit_UserLoginPwd.Properties.Enter += new System.EventHandler(this.textEdit_UserLoginPwd_Properties_Enter);
			this.textEdit_UserLoginPwd.Size = new System.Drawing.Size(112, 21);
			this.textEdit_UserLoginPwd.TabIndex = 2;
			// 
			// simpleButton_Register
			// 
			this.simpleButton_Register.Location = new System.Drawing.Point(376, 360);
			this.simpleButton_Register.Name = "simpleButton_Register";
			this.simpleButton_Register.TabIndex = 4;
			this.simpleButton_Register.Text = "序列号";
			this.simpleButton_Register.Visible = false;
			this.simpleButton_Register.Click += new System.EventHandler(this.simpleButton_Register_Click);
			// 
			// simpleButton_Exit
			// 
			this.simpleButton_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButton_Exit.Location = new System.Drawing.Point(376, 296);
			this.simpleButton_Exit.Name = "simpleButton_Exit";
			this.simpleButton_Exit.TabIndex = 5;
			this.simpleButton_Exit.Text = "退出";
			this.simpleButton_Exit.Click += new System.EventHandler(this.simpleButton_Exit_Click);
			// 
			// fadeTimer
			// 
			this.fadeTimer.Tick += new System.EventHandler(this.fadeTimer_Tick);
			// 
			// timer_AutoShutDown
			// 
			this.timer_AutoShutDown.Interval = 30000;
			this.timer_AutoShutDown.SynchronizingObject = this;
			this.timer_AutoShutDown.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_AutoShutDown_Elapsed);
			// 
			// timer_MedicineRemind
			// 
			this.timer_MedicineRemind.Interval = 40000;
			this.timer_MedicineRemind.SynchronizingObject = this;
			this.timer_MedicineRemind.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_MedicineRemind_Elapsed);
			// 
			// simpleButton_Service
			// 
			this.simpleButton_Service.Location = new System.Drawing.Point(456, 296);
			this.simpleButton_Service.Name = "simpleButton_Service";
			this.simpleButton_Service.TabIndex = 8;
			this.simpleButton_Service.Text = "服务器";
			this.simpleButton_Service.Click += new System.EventHandler(this.simpleButton_Service_Click);
			// 
			// timer_DetectDate
			// 
			this.timer_DetectDate.Enabled = true;
			this.timer_DetectDate.Interval = 3600000;
			this.timer_DetectDate.SynchronizingObject = this;
			this.timer_DetectDate.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_DetectDate_Elapsed);
			// 
			// simpleButton_restore
			// 
			this.simpleButton_restore.Location = new System.Drawing.Point(376, 328);
			this.simpleButton_restore.Name = "simpleButton_restore";
			this.simpleButton_restore.TabIndex = 9;
			this.simpleButton_restore.Text = "还原";
			this.simpleButton_restore.Click += new System.EventHandler(this.simpleButton_restore_Click);
			// 
			// Login
			// 
			this.AcceptButton = this.simpleButton_Login;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.CancelButton = this.simpleButton_Exit;
			this.ClientSize = new System.Drawing.Size(566, 600);
			this.Controls.Add(this.simpleButton_restore);
			this.Controls.Add(this.simpleButton_Service);
			this.Controls.Add(this.simpleButton_Login);
			this.Controls.Add(this.textEdit_UserLoginID);
			this.Controls.Add(this.label_LoginID);
			this.Controls.Add(this.label_LoginPwd);
			this.Controls.Add(this.textEdit_UserLoginPwd);
			this.Controls.Add(this.simpleButton_Register);
			this.Controls.Add(this.simpleButton_Exit);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.LookAndFeel.SkinName = "Stardust";
			this.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.LookAndFeel.UseDefaultLookAndFeel = false;
			this.LookAndFeel.UseWindowsXPTheme = false;
			this.Name = "Login";
			this.Text = "Login";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Login_Closing);
			this.Load += new System.EventHandler(this.Login_Load);
			this.VisibleChanged += new System.EventHandler(this.Login_VisibleChanged);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Login_MouseMove);
			((System.ComponentModel.ISupportInitialize)(this.textEdit_UserLoginID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_UserLoginPwd.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.timer_AutoShutDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.timer_MedicineRemind)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.timer_DetectDate)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			//关闭AutoService服务开启软件中查询线程
			try
			{
				ServiceController AutoService = new ServiceController(CPTT.SystemFramework.Util.AUTO_SERVICE_NAME);
				if(AutoService.Status.Equals(ServiceControllerStatus.Running))
				{
					AutoService.Stop();

//					COM_PORT_IS_BUSY = false;
				}
			}
			catch(Exception ex)
			{
				CPTT.SystemFramework.Util.WriteLog(ex.Message,CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);
			}

			//处理未捕获异常
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
			Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

			//得到正在运行的实例
			Process instance = runningInstance();

			if(instance == null)
			{
				//如果没有正在运行的实例就创建一个新实例
				Application.Run(new Login());
			}
			else
			{

				//处理发现的已运行实例
				handleRunningInstance(instance);
			}
		}

		#region 软件开启时接替问询服务进行问询
		//问询指令
		private void SendQuery()
		{
			while(true)
			{
				if(!COM_PORT_IS_BUSY)
				{
					machineAddrList = machineSystem.GetMachineAddrList();

					if ( machineAddrList != null )
					{
						if ( machineAddrList.Tables[0].Rows.Count > 0 )
						{
							foreach(DataRow machineAddr in machineAddrList.Tables[0].Rows)
							{
								ControlFrame controlFrame = new ControlFrame();
								controlFrame.sym = new byte[]{(byte)'*',(byte)'*'};
								controlFrame.desAddr = Convert.ToByte(machineAddr["machine_address"]);
								controlFrame.srcAddr = 0;
								controlFrame.response = CPTT.SystemFramework.Util.QUERY_TOKEN;
								controlFrame.seq = CPTT.SystemFramework.Util.FRAME_SEQUENCE_VALUE;
								controlFrame.computeCheckSum();

								Monitor.Enter(syncRoot);
								try
								{
									//Monitor.Enter(handleComClass);
									handleComClass.WriteSerialCmd(CPTT.SystemFramework.Util.CONTROL_FRAME_LENGTH,controlFrame.convertToBytes());//发送问询帧
								}
								finally
								{
									Monitor.Exit(syncRoot);
								}
								//Monitor.Exit(handleComClass);

								Thread.Sleep(CPTT.SystemFramework.Util.QUERY_TIMER_INTERVAL);
							}
							
							if (_lastSyncDate.AddMinutes(10) <= DateTime.Now)
							{
								foreach(DataRow machineAddr in machineAddrList.Tables[0].Rows)
								{
									SynchDate(machineAddr["machine_address"]);
								}

								_lastSyncDate = DateTime.Now;
							}
						}
						else Thread.Sleep(CPTT.SystemFramework.Util.QUERY_NULL_INTERVAL);
					}
					else Thread.Sleep(1000);
//
//					if ( _alAuthenticatedHardWare.Count > 0 )
//					{
//						foreach(object o in _alAuthenticatedHardWare)
//						{
//							ControlFrame controlFrame = new ControlFrame();
//							controlFrame.sym = new byte[]{(byte)'*',(byte)'*'};
//							controlFrame.desAddr = Convert.ToByte(o.ToString());
//							controlFrame.srcAddr = 0;
//							controlFrame.response = CPTT.SystemFramework.Util.QUERY_TOKEN;
//							controlFrame.seq = CPTT.SystemFramework.Util.FRAME_SEQUENCE_VALUE;
//							controlFrame.computeCheckSum();
//
//							Monitor.Enter(handleComClass);
//							handleComClass.WriteSerialCmd(CPTT.SystemFramework.Util.CONTROL_FRAME_LENGTH,controlFrame.convertToBytes());//发送问询帧
//							Monitor.Exit(handleComClass);
//
//							Thread.Sleep(CPTT.SystemFramework.Util.QUERY_TIMER_INTERVAL);
//						}
//					}
//					else Thread.Sleep(CPTT.SystemFramework.Util.QUERY_NULL_INTERVAL);
				}
			}
		}

		//handle data from com when arrived
		private void handleComClass_DataArrived(int size, ref object vBuf)
		{
			try
			{
				//Monitor.Enter(handleComClass);
				Monitor.Enter(syncRoot);
				byte[] ReceiveData = (byte[])vBuf;
				byte sym = ReceiveData[0];

				//			if(!CPTT.SystemFramework.Util.ComputeCheckSum(ReceiveData))
				//				return;

				//			byte sym = ReceiveData[0];

				if ( !CPTT.SystemFramework.Util.IsValidFrame(ReceiveData,ref sym,ref ReceiveData) ) return;

				//ctrl frame arrived(command frame)
				if(sym == '*')
				{
					byte response = ReceiveData[4];
			
					//confirm the type of data to handle
					switch(response)
					{
						case 0x00:  //no data to be responded
							break;
						case 0x02:  //query frame for getting data
							break;
						case 0x03:  //has set addr(this machine)
							if(AssignAddressSuccessed != null)
							{
								AssignAddressSuccessed();
							}
							break;
						case 0x04:  //has set time
							if(SynchTimeSuccessed != null)
							{
								SynchTimeSuccessed();
							}
							break;
						case 0x05:  //card-sent frame received and run successfully
							if(SendCardSuccessed != null)
							{
								SendCardSuccessed();
							}
							break;
						case 0x06: //card-logout frame received and run successfully
							break;
						case 0x07: //school-leaving frame received and run successfully
							if(LogtouCardSuccessed != null)
							{
								LogtouCardSuccessed();
							}
							break;
						case 0x09: //class-adjusting frame received and run successfully
							break;
						case 0x0a: //terminal-adjusting frame received and run successfully
							this.SetVol.login_SetMachineVolumnSuccessed();
//							if(SetMachineVolumnSuccessed != null)
//							{
//								
//								//this.SetVol.setma
//								//SetMachineVolumnSuccessed();
//							}
							break;
						case 0x0b: //response to previous frame
							break;
						case 0x0c: //reponse to failure of card-sending
							if(SendCardFailed != null)
							{
								SendCardFailed();
							}
							break;
						case 0x0d: //hardware authentication succeed
							if ( HardWareAuthenticationSucceed != null )
							{
								if ( ReceiveData[2] == 0 ) HandleHardWareAuthenticationSucceed(ReceiveData[3]);
							}
							break;
						case 0x11:
							if (SendUserNameSucceed != null)
								SendUserNameSucceed();
							break;
						case 0x12:
							if (SendCustomButtonInfoSucceed != null)
								SendCustomButtonInfoSucceed();
							break;
						case 0x14:
							this.SetVol.login_SendClassNameSucceed();
//							if (SendClassNameSucceed != null)
//							{
//								SendClassNameSucceed();
//							}
							break;
					}
				}

				else if(sym == '@')//数据帧头长度为7
				{
					byte protocol = ReceiveData[5];

					switch(protocol)
					{
						case 0x00:
							break;
						case 0x02:
							break;
						case 0x03:
							break;
						case 0x04:
							break;
						case 0x05:

							break;
						case 0x06:
							break;
						case 0x07:
							break;
						case 0x08:
							if(ReceiveData[2]==0)//如果是发向管理机的数据帧则做处理
							{
								handleComData(ReceiveData);
							}
							break;
						case 0x09:
							break;
						case 0x0a:
							break;
						case 0x0b:
							if(ValidateCardInfoReturn != null)
							{
								ValidateCardInfoReturn(ReceiveData);
							}
							break;
						case 0x0c:
							break;
						case 0x0d:
							break;
						case 0xff:
							break;
					}
				}
			}
			catch(Exception ex)
			{
				CPTT.SystemFramework.Util.WriteLog(ex.Message,CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);
			}
			catch
			{
				CPTT.SystemFramework.Util.WriteLog("unhandled exception",CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);
			}
			finally
			{
				Monitor.Exit(syncRoot);
			}
		}

		//利用委托处理串口数据
		private delegate void HandleComData(byte[] morningCheckData);

		private void InsertMorningCheckData(byte[] morningCheckData)
		{
			try
			{
				CPTT.SystemFramework.Util.WriteLog(string.Format("data come, length={0}", morningCheckData.Length),CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);
				DataFrame dataFrame = DataFrame.convertToFrame(morningCheckData);
				int rowsAffected = new MorningCheckInfoSystem().InsertMorningCheckInfo(dataFrame);

				if(rowsAffected > 0)
				{
					responseFrame.desAddr = dataFrame.srcAddr;
					responseFrame.computeCheckSum();
					SuspendAllThread();
					handleComClass.WriteSerialCmd(CPTT.SystemFramework.Util.CONTROL_FRAME_LENGTH,responseFrame.convertToBytes());
					
				}
			}
			finally
			{
				ResumeQueryThread();
			}
		}
		#endregion

		private void PrepareForCheck()
		{
			new PrepareForStuCheckInfoSystem().DoPreparingCheckInfo();

            if (Util.IsUploadVersion)
            {
                _upLoadDataThread = new Thread(new ThreadStart(DoUploadData));
                _upLoadDataThread.IsBackground = true;
                _upLoadDataThread.Priority = ThreadPriority.Normal;
                _upLoadDataThread.Start();

                _upLoadDataThread = new Thread(new ThreadStart(DoDownloadData));
                _upLoadDataThread.IsBackground = true;
                _upLoadDataThread.Priority = ThreadPriority.Normal;
                _upLoadDataThread.Start();

                //new System.Threading.Tasks.Task(DownloadGrowUpReportData, TaskCreationOptions.LongRunning).Start();
                //new System.Threading.Tasks.Task(DownloadGrowUpCheckReportData, TaskCreationOptions.LongRunning).Start();
            }
		}

        //private void UploadDataForXDD()
        //{
        //    while (true)
        //    {
        //        int uploadVersion = 1;
        //        try
        //        {
        //            uploadCount = 0;
        //            DataTable dt = new UtilSystem().GetUploadDataForXDD();
        //            if (dt != null && dt.Rows.Count > 0)
        //            {
        //                SystemFramework.Util.UploadDataToXDD(dt);
        //            }
        //            uploadCount = dt.Rows.Count;
        //        }
        //        catch(Exception ex)
        //        {
        //            SystemFramework.Util.WriteLog(ex.Message, SystemFramework.Util.EXCEPTION_LOG_TITLE);
        //        }
        //        finally
        //        {
        //            uploadVersion++;
        //        }

        //        Thread.Sleep(300000);
        //    }
        //}

        //private void UploadInfoforXDD()
        //{
        //    DataSet ds = new UtilSystem().GetUploadInfoForXDD();
        //    if (ds != null && ds.Tables.Count == 2)
        //    {
        //        SystemFramework.Util.UploadInfoToXDD(ds.Tables[0].Rows[0]["info_gardenID"].ToString(), ds.Tables[0].Rows[0]["info_gardenName"].ToString(), ds.Tables[1]);
        //    }
        //}

        private void DoUploadData()
        {
            while (true)
            {
                int uploadVersion = 1;
                try
                {

                    uploadCount = 0;
                    uploadTeacherCount = 0;
                    DataTable dt = new UtilSystem().GetUploadDataForYlm();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        YlmfDataUploader.StudentInfoUpload.UploadDataToYlmf(dt);
                    }
                    uploadCount = dt.Rows.Count;

                    dt = new UtilSystem().GetUploadDataForYlm_teacher();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        YlmfDataUploader.TeacherInfoUpload.UploadDataToYlmf(dt);
                    }

                    uploadTeacherCount = dt.Rows.Count;
                }
                catch (Exception ex)
                {
                    SystemFramework.Util.WriteLog(ex.ToString(), SystemFramework.Util.EXCEPTION_LOG_TITLE);
                }
                finally
                {
                    uploadVersion++;

                }

                Thread.Sleep(300000);
            }
        }

        private void DoDownloadData()
        {
            while (true)
            {
                try
                {
                    var tuple = new UtilSystem().GetDownloadRevAndID();
                    if (!string.IsNullOrEmpty(tuple.Item6))
                    {
                        YlmfDataDownload.StudentInfoDownload.DownloadLog log = null;
                        int totalCount = 0;
                        int succCount = 0;
                        foreach (var student in YlmfDataDownload.StudentInfoDownload.GetDownloadData(tuple.Item6, tuple.Item1, out log))
                        {
                            try
                            {
                                totalCount++;
                                if (new UtilSystem().InsertDownloadStudentInfo(
                                    student.id,
                                    student.gradeid,
                                    student.gradename,
                                    student.gradetype,
                                    student.classid,
                                    student.className,
                                    student.name,
                                    student.ValidStudentNumber,
                                    student.ValidBirthday,
                                    student.ValidGender,
                                    student.ValidEnterType,
                                    student.ValidEnterDate,
                                    student.HasLeftSchool))
                                {
                                    succCount++;
                                }
                            }
                            catch (Exception ex)
                            {
                                SystemFramework.Util.WriteLog(ex.ToString(), SystemFramework.Util.EXCEPTION_LOG_TITLE);
                            }
                        }
                        if (succCount > 0 && log != null)
                            new UtilSystem().InsertDownloadLog(log.lastupttime, log.Raw, succCount, totalCount, 0);


                        totalCount = 0;
                        succCount = 0;
                        YlmfDataDownload.StudentSignInInfoDownload.DownloadLog studentSignInLog = null;
                        foreach (var signIn in YlmfDataDownload.StudentSignInInfoDownload.GetDownloadData(tuple.Item6, tuple.Item3, out studentSignInLog))
                        {
                            try
                            {
                                totalCount++;
                                if (new UtilSystem().InsertSignIn(signIn.ValidStudentNumber, signIn.Time, signIn.Status))
                                {
                                    succCount++;
                                }
                            }
                            catch (Exception ex)
                            {
                                SystemFramework.Util.WriteLog(ex.ToString(), SystemFramework.Util.EXCEPTION_LOG_TITLE);
                            }
                        }
                        if (succCount > 0 && log != null)
                            new UtilSystem().InsertDownloadLog(log.lastupttime, log.Raw, succCount, totalCount, 2);

                        totalCount = 0;
                        succCount = 0;
                        YlmfDataDownload.TeacherInfoDownload.DownloadLog teacherLog = null;

                        new UtilSystem().InsertDefaultDeptAndDuty();

                        foreach (var teacher in YlmfDataDownload.TeacherInfoDownload.GetDownloadData(tuple.Item6, tuple.Item2, out teacherLog))
                        {
                            try
                            {
                                totalCount++;
                                if (new UtilSystem().InsertDownloadTeacherInfo(
                                    teacher.id,
                                    "教务",
                                    "教务",
                                    teacher.name,
                                    Convert.ToInt32(teacher.teacherNum),
                                    teacher.gender == 0 ? "女" : "男"))
                                {
                                    succCount++;
                                }
                            }
                            catch (Exception ex)
                            {
                                SystemFramework.Util.WriteLog(ex.ToString(), SystemFramework.Util.EXCEPTION_LOG_TITLE);
                            }
                        }
                        if (succCount > 0 && log != null)
                            new UtilSystem().InsertDownloadLog(log.lastupttime, log.Raw, succCount, totalCount, 1);
                    }
                }
                catch (Exception ex)
                {
                    SystemFramework.Util.WriteLog(ex.ToString(), SystemFramework.Util.EXCEPTION_LOG_TITLE);
                }
                Thread.Sleep(1000 * 60 * 5);
            }
        }

        private static void DownloadGrowUpReportData()
        {
            while (true)
            {
                int totalCount = 0;
                int succCount = 0;
                try
                {
                    var tuple = new UtilSystem().GetDownloadRevAndID();
                    var reportHistory = new List<dynamic>();
                    YlmfDataDownload.GrowUpReportDownload.DownloadLog log = null;
                    if (!string.IsNullOrEmpty(tuple.Item6))
                    {
                        var dt = new ClassSystem().GetGetClassAndGrade();
                        if (dt != null)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                var rev = new UtilSystem().GetDownloadRev(row["info_className"].ToString(), 3);
                                log = YlmfDataDownload.GrowUpReportDownload.GetDownloadData(tuple.Item6, row["info_className"].ToString(), rev);
                                if (log.code == 1)
                                {
                                    foreach (var studentReport in log.result.list)
                                    {
                                        var studentNumber = studentReport.studentNum;
                                        var referrerID = studentReport.id;
                                        succCount = 1;
                                        totalCount = 1;
                                        foreach (var report in studentReport.reportList)
                                        {
                                            reportHistory.Add(new
                                            {
                                                gradeName = row["info_gradeName"].ToString(),
                                                className = row["info_className"].ToString(),
                                                referrerID = referrerID,
                                                studentNo = studentNumber,
                                                recorderName = report.name,
                                                type = report.type,
                                                date = report.time,
                                                detail = report.reportDetail
                                            });
                                        }

                                        new UtilSystem().InsertDownloadLog(log.lastupttime, log.Raw, succCount, totalCount, 3, row["info_className"].ToString());
                                    }
                                }
                            }

                            foreach (var item in reportHistory)
                            {
                                int reportID = 0;
                                new UtilSystem().InsertGrowUpReportHistory(item.gradeName, item.className, item.referrerID, item.studentNo, item.recorderName, item.type, item.date, out reportID);
                                if (reportID > 0)
                                {
                                    var reportDetail = item.detail as IList<YlmfDataDownload.GrowUpReportDownload.ReportItem>;
                                    foreach (var detail in reportDetail)
                                    {
                                        totalCount++;
                                        try
                                        {
                                            new UtilSystem().InsertGrowUpReportDetail(reportID, item.studentNo, detail.category, detail.item, detail.content, detail.picUrl, item.date);
                                            succCount++;
                                        }
                                        catch (Exception ex)
                                        {
                                            SystemFramework.Util.WriteLog(ex.ToString(), SystemFramework.Util.EXCEPTION_LOG_TITLE);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    SystemFramework.Util.WriteLog(ex.ToString(), SystemFramework.Util.EXCEPTION_LOG_TITLE);
                }
                if (succCount == 0)
                    Thread.Sleep(1000 * 60 * 20);
            }
        }

        private static void DownloadGrowUpCheckReportData()
        {
            while (true)
            {
                int totalCount = 0;
                int succCount = 0;
                try
                {
                    var tuple = new UtilSystem().GetDownloadRevAndID();
                    var reportHistory = new List<dynamic>();
                    YlmfDataDownload.GrowUpCheckReportDownload.DownloadLog log = null;
                    if (!string.IsNullOrEmpty(tuple.Item6))
                    {
                        var dt = new ClassSystem().GetGetClassAndGrade();
                        if (dt != null)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                var rev = new UtilSystem().GetDownloadRev(row["info_className"].ToString(), 4);
                                log = YlmfDataDownload.GrowUpCheckReportDownload.GetDownloadData(tuple.Item6, row["info_className"].ToString(), rev);
                                if (log.code == 1)
                                {
                                    foreach (var studentReport in log.result.list)
                                    {
                                        succCount = 1;
                                        totalCount = 1;
                                        var studentNumber = studentReport.studentNum;
                                        var referrerID = studentReport.id;
                                        foreach (var report in studentReport.reportList)
                                        {
                                            reportHistory.Add(new
                                            {
                                                referrerID = referrerID,
                                                studentNo = studentNumber,
                                                date = report.time,
                                                detail = report.reportDetail
                                            });
                                        }

                                        new UtilSystem().InsertDownloadLog(log.lastupttime, log.Raw, succCount, totalCount, 4, row["info_className"].ToString());
                                    }
                                }
                            }

                            foreach (var item in reportHistory)
                            {
                                int reportID = 0;
                                new UtilSystem().InsertGrowUpCheckReportHistory(item.studentNo, item.referrerID, item.date, out reportID);
                                if (reportID > 0)
                                {
                                    var reportDetail = item.detail as IList<YlmfDataDownload.GrowUpCheckReportDownload.ReportItem>;
                                    foreach (var detail in reportDetail)
                                    {
                                        totalCount++;
                                        try
                                        {
                                            new UtilSystem().InsertGrowUpCheckReportDetail(reportID, detail.resultType, detail.type);
                                            succCount++;
                                        }
                                        catch (Exception ex)
                                        {
                                            SystemFramework.Util.WriteLog(ex.ToString(), SystemFramework.Util.EXCEPTION_LOG_TITLE);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    SystemFramework.Util.WriteLog(ex.ToString(), SystemFramework.Util.EXCEPTION_LOG_TITLE);
                }
                if (succCount == 0)
                    Thread.Sleep(1000 * 60 * 20);
            }
        }

        //private void UploadData()
        //{
        //    while (true)
        //    {
        //        int uploadVersion = 1;
        //        try
        //        {
					
        //            _dsUpload = new UtilSystem().GetUploadData();
        //            if (_dsUpload != null && _dsUpload.Tables.Count >= 2)
        //            {
        //                SystemFramework.Util.WriteLog(string.Format("Try to upload records  {0} on time:{1}", _dsUpload.Tables[1].Rows.Count, DateTime.Now), 
        //                    SystemFramework.Util.EXCEPTION_LOG_TITLE);


        //                object o = SystemFramework.Util.UploadData(SystemFramework.Util.WebserviceURL,
        //                    "DataCenterWebService", SystemFramework.Util.WebserviceClassName,
        //                    SystemFramework.Util.WebServiceMethod, new object[]{_dsUpload}, new ArrayList());

        //                if (_dsUpload.Tables.Count > 2)
        //                {
        //                    foreach(DataRow dr in _dsUpload.Tables[2].Rows)
        //                    {
        //                        new UtilSystem().UpdateUploadState(dr["studentId"].ToString());
        //                    }
        //                }
					
        //                SystemFramework.Util.WriteLog("Upload succeed", SystemFramework.Util.EXCEPTION_LOG_TITLE);
        //            }
        //        }
        //        catch(Exception ex)
        //        {
        //            SystemFramework.Util.WriteLog(ex.Message, SystemFramework.Util.EXCEPTION_LOG_TITLE);
        //        }
        //        finally
        //        {
        //            uploadVersion++;
					
        //        }

        //        Thread.Sleep(300000);
        //    }
        //}

		private void WebSerivceCallBack(IAsyncResult ar)
		{
			try
			{
				SystemFramework.Util.WriteLog(string.Format("Count Uploaded {0} on time:{1}", _dsUpload.Tables[1].Rows.Count, DateTime.Now), 
					SystemFramework.Util.EXCEPTION_LOG_TITLE);
			}
			catch
			{
				SystemFramework.Util.WriteLog(string.Format("Count Uploaded {0} on time:{1}", 0, DateTime.Now), 
					SystemFramework.Util.EXCEPTION_LOG_TITLE);
			}
		}

		#region 处理未捕获异常
		private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			CPTT.SystemFramework.Util.WriteLog(e.ExceptionObject.ToString(),CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);

//			if(DialogResult.Abort == MessageBox.Show("程序发生未知异常,请关闭程序重新打开","系统错误",MessageBoxButtons.AbortRetryIgnore,
//				MessageBoxIcon.Warning))
//			{
//				Application.DoEvents();
//				Application.ExitThread();
//			}
		}

		private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
//			CPTT.SystemFramework.Util.WriteLog(e.Exception.Message.ToString(),CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);
//
//			if(DialogResult.Abort == MessageBox.Show("程序发生未知异常,请关闭程序重新打开","系统错误",MessageBoxButtons.AbortRetryIgnore,
//				MessageBoxIcon.Warning))
//			{
//				Application.DoEvents();
//				Application.ExitThread();
//			}
		}
		#endregion

		#region 只允许加载一个实列
		private const int WS_SHOWNORMAL = 1;

		public static Process runningInstance()
		{
			Process current = Process.GetCurrentProcess();
			Process[] processes = Process.GetProcessesByName(current.ProcessName);

			//遍历所有相同名称正在运行的实例
			foreach(Process process in processes)
			{
				if(process.Id != current.Id)
				{
					//确保从EXE文件运行
					if(Assembly.GetExecutingAssembly().Location.Replace("/","\\")
						==current.MainModule.FileName)
					{
						//返回发现的实例
						return process;
					}
				}
			}

			//如果没有发现已启动的实例返回null
			return null;
		}

		public static void handleRunningInstance(Process instance)
		{
			//确保窗口没有被最小化或最大化
			ShowWindowAsync(instance.MainWindowHandle,WS_SHOWNORMAL);

			//设置实例为foreground window
			SetForegroundWindow(instance.MainWindowHandle);
		}

		[DllImport("User32.dll")]
		private static extern bool ShowWindowAsync(IntPtr hWnd,int cmdShow);

		[DllImport("User32.dll")]
		private static extern bool SetForegroundWindow(IntPtr hWnd);

		#endregion

		#region 当鼠标按下时可移动窗体
		private void Login_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			mouseOffset = new Point(-e.X,-e.Y);
		}

		private void Login_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left)
			{
				Point mousePosition = Control.MousePosition;
				mousePosition.Offset(mouseOffset.X,mouseOffset.Y);
				this.Location = mousePosition;
			}
		}
		#endregion

		#region Load MainForm
		private void LoadMainForm()
		{
			mainForm = new MainForm();
		}
		#endregion

		#region 登陆,窗体淡出隐藏
		private void textEdit_UserLoginPwd_Properties_Enter(object sender, System.EventArgs e)
		{
			//当密码输入框被激活时选中全部内容
			textEdit_UserLoginPwd.SelectAll();
		}

		private void simpleButton_Login_Click(object sender, System.EventArgs e)
		{
            StartSqlExpressIfStopped();


			simpleButton_Login.Enabled = false;

			string userLoginID = textEdit_UserLoginID.Text.Trim();
			string userPassword = textEdit_UserLoginPwd.Text.Trim();

			new UserSystem().DeleteSpecialRole();

#if SoftwareRegister
			try
			{
				RegistryKey softwareKey = Registry.LocalMachine.OpenSubKey("Software");
				RegistryKey winSysDataKey = softwareKey.OpenSubKey("WindowsDataSystem");

				if ( winSysDataKey == null )
				{
					MessageBox.Show("您还未进行注册，请用供应商提供的序列号进行注册！","系统信息!",
						MessageBoxButtons.OK,MessageBoxIcon.Information);

					return;
				}

				RegistryKey ctppKey = winSysDataKey.OpenSubKey("Corporation");

				if ( ctppKey == null )
				{
					MessageBox.Show("您还未进行注册，请用供应商提供的序列号进行注册！","系统信息!",
						MessageBoxButtons.OK,MessageBoxIcon.Information);

					return;
				}
				else
				{
					DateTime createDate = Convert.ToDateTime(ctppKey.GetValue("CreateDate"));

					if ( Convert.ToInt32(ctppKey.GetValue("RegisterUser")) == 1 )
					{
						if ( Convert.ToInt32(ctppKey.GetValue("RegisterDays")) >= 30 )
						{
							MessageBox.Show("您的软件已经过期，请与您的供应商取得联系！","系统信息!",
								MessageBoxButtons.OK,MessageBoxIcon.Information);

							return;
						}
						else if ( 30 - Convert.ToInt32(ctppKey.GetValue("RegisterDays")) <= 5 )
						{
							if ( createDate.Date < DateTime.Now.Date || createDate > DateTime.Now ) 
							{
								int registerDays = Convert.ToInt32(ctppKey.GetValue("RegisterDays"))+1;
		
								ctppKey.Close();
								winSysDataKey.Close();
								softwareKey.Close();

								softwareKey = Registry.LocalMachine.OpenSubKey("Software",true);
								winSysDataKey = softwareKey.CreateSubKey("WindowsDataSystem");
								ctppKey = winSysDataKey.CreateSubKey("Corporation");

								ctppKey.SetValue("CreateDate",DateTime.Now);
								ctppKey.SetValue("RegisterDays",registerDays);
							}

							string messageShow = string.Format("您的软件还有{0}天即将过期，请与您的供应商取得联系！",
								30-Convert.ToInt32(ctppKey.GetValue("RegisterDays")));
	
							MessageBox.Show(messageShow,"系统信息!",MessageBoxButtons.OK,MessageBoxIcon.Information);
						}
						else
						{
							if ( createDate.Date < DateTime.Now.Date || createDate > DateTime.Now ) 
							{
								int registerDays = Convert.ToInt32(ctppKey.GetValue("RegisterDays"))+1;

								ctppKey.Close();
								winSysDataKey.Close();
								softwareKey.Close();

								softwareKey = Registry.LocalMachine.OpenSubKey("Software",true);
								winSysDataKey = softwareKey.CreateSubKey("WindowsDataSystem");
								ctppKey = winSysDataKey.CreateSubKey("Corporation");

								ctppKey.SetValue("CreateDate",DateTime.Now);
								ctppKey.SetValue("RegisterDays",registerDays);
							}
						}
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("在登录系统的时候出现未知程序错误，请与您的供应商取得联系！","系统信息!",MessageBoxButtons.OK,MessageBoxIcon.Information);
				CPTT.SystemFramework.Util.WriteLog(ex.Message,CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);

				return;
			}
#endif

			if(!userLoginID.Equals(string.Empty)&&!userPassword.Equals(string.Empty))
			{
				loginUser = new User(userLoginID,userPassword);

				int loginState = 0;

				try
				{
					loginState = userSystem.userLogin(loginUser);

					//					if(loginState == -1)
					//					{
					//						MessageBox.Show("该用户不存在,请重试!!","系统信息!",
					//							MessageBoxButtons.OK,MessageBoxIcon.Information);
					//						textEdit_UserLoginID.Focus();
					//						return;
					//					}
					//					else if(loginState == 2)
					//					{
					//						MessageBox.Show("密码错误,请重试!!","系统信息!",
					//							MessageBoxButtons.OK,MessageBoxIcon.Information);
					//						textEdit_UserLoginPwd.SelectAll();
					//						return;
					//					}
					//					else 
					if(loginState == 1)
					{
						textEdit_UserLoginID.Text = string.Empty;
						textEdit_UserLoginPwd.Text = string.Empty;

						AssignUniqueGardenID();

#if MaxClients
						if ( utilSystem.IsSessionClient(Thread.CurrentPrincipal.Identity.Name) )
						{
							if ( utilSystem.UpdateSessionClient(Thread.CurrentPrincipal.Identity.Name) != 1 )
							{
								MessageBox.Show("更新服务器会话时发生错误，请联系供应商");
								return;
							}
						}
						else
						{
							if ( utilSystem.GetCurrentClients() < CPTT.SystemFramework.Util.MaxClients )
							{
								if ( utilSystem.InsertSessionClient(Thread.CurrentPrincipal.Identity.Name) != 1 )
								{
									MessageBox.Show("更新服务器会话时发生错误，请联系供应商");
									return;
								}
							}
							else
							{
								MessageBox.Show("服务器最大连接数已满，登陆失败！");
								return;
							}
						}
#endif

						//加载MainForm
						mainForm = new MainForm();

						formShowing = false;
						//fadeTimer.Start();
					

						this.Visible = false;
						mainForm.Owner = this;
						mainForm.WindowState = FormWindowState.Maximized;
						mainForm.Refresh();
						mainForm.Show();
					}
					else
					{
						MessageBox.Show("登陆帐号错误,请检查用户名与密码是否正确!!","系统信息!",
							MessageBoxButtons.OK,MessageBoxIcon.Information);

						textEdit_UserLoginPwd.SelectAll();

						simpleButton_Login.Enabled = true;
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show("登陆时发生异常,请重试!!","系统信息!",
						MessageBoxButtons.OK,MessageBoxIcon.Warning);
					CPTT.SystemFramework.Util.WriteLog(ex.Message,CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);

					simpleButton_Login.Enabled = true;
				}
			}
			else
			{
				MessageBox.Show("用户名和密码都必须填写!","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Warning);
				textEdit_UserLoginID.Focus();

				simpleButton_Login.Enabled = true;
			}

		}
		#endregion

		#region 序列号注册
		private void simpleButton_Register_Click(object sender, System.EventArgs e)
		{

#if SoftwareRegister
			SoftwareRegisterForm softwareRegisterForm = new SoftwareRegisterForm();
			softwareRegisterForm.StartPosition = FormStartPosition.CenterScreen;
			softwareRegisterForm.ShowDialog();
			string getSn = SoftwareRegisterForm.GetSn;

			DataProtector dp = new DataProtector(DataProtector.Store.USE_MACHINE_STORE);
			try
			{
				byte[] dataToDecrypt = Convert.FromBase64String(getSn);
				byte[] key = Encoding.ASCII.GetBytes(DataProtector.SetRegisterKeyString());

				string getRetrivedSn = Encoding.ASCII.GetString(dp.RegisterSnDecrypt(dataToDecrypt,key));
				string getInitSn = new DataProtector().InitInfoDecryp(getRetrivedSn);
				string getRetrivedProvince = getInitSn.Substring(0,getInitSn.IndexOf(",",0));
				string getRetrivedUser = getInitSn.Substring(getInitSn.IndexOf("#",0)+1,getInitSn.IndexOf("@",0)-getInitSn.IndexOf("#",0)-1);

				if ( getRetrivedProvince.Equals(CPTT.SystemFramework.Util.PROVINCE_INFO) )
				{
					try
					{
						RegistryKey softwareKey = Registry.LocalMachine.OpenSubKey("Software",true);
						RegistryKey winSysDataKey = softwareKey.CreateSubKey("WindowsDataSystem");
						RegistryKey ctppKey = winSysDataKey.CreateSubKey("Corporation");

						if ( getRetrivedUser.Equals(CPTT.SystemFramework.Util.IS_AGENT_INFO) )
						{
							ctppKey.SetValue("CreateDate",(object)DateTime.Now.Date);
							ctppKey.SetValue("RegisterUser",(object)0);
							ctppKey.SetValue("RegisterDays",(object)254);

							MessageBox.Show("序列号更新成功！\n您已经成为VIP用户，将享有软件所提供的服务，感谢您使用本软件，祝您使用愉快！","系统信息!",
								MessageBoxButtons.OK,MessageBoxIcon.Information);
						}
						else
						{
							if ( ctppKey.GetValue("RegisterUser") == null )
							{
								ctppKey.SetValue("CreateDate",(object)DateTime.Now);
								ctppKey.SetValue("RegisterUser",(object)1);
								ctppKey.SetValue("RegisterDays",(object)1);

								MessageBox.Show("序列号更新成功！\n感谢您使用本软件，祝您使用愉快！","系统信息!",
									MessageBoxButtons.OK,MessageBoxIcon.Information);
							}
							else 
							{
								MessageBox.Show("该序列号所扮演的角色不比当前系统注册角色新，序列号更新失败！","系统信息!",
									MessageBoxButtons.OK,MessageBoxIcon.Information);
								return;
							}
						}
					}
					catch(Exception ex)
					{
						MessageBox.Show("注册时出现未知错误，请与供应商联系！","系统信息!",
							MessageBoxButtons.OK,MessageBoxIcon.Warning);

						CPTT.SystemFramework.Util.WriteLog(ex.Message,CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);

						return;
					}
				}
				else MessageBox.Show("您所填写的序列号是非法序列号，请与供应商联系！","系统信息!",
						 MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}
			catch(Exception ex)
			{
				MessageBox.Show("您所填写的序列号是非法序列号，请与供应商联系！","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Warning);

				CPTT.SystemFramework.Util.WriteLog(ex.Message,CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);

				return;
			}
#endif
		}
		#endregion

		#region 退出程序
		private void simpleButton_Exit_Click(object sender, System.EventArgs e)
		{
			this.Close();
			Application.DoEvents();
			Application.Exit();
		}
		#endregion

		#region 窗体淡入淡出效果
		private void fadeTimer_Tick(object sender, System.EventArgs e)
		{
			if(formShowing)
			{
				double d = 1000.0 / fadeTimer.Interval / 100.0;
				if (Opacity + d >= 1.0)
				{
					Opacity = 1.0;
					fadeTimer.Stop();
				}
				else
				{
					Opacity += d;
				}
			}
			else
			{
				double d = 1000.0 / fadeTimer.Interval / 100.0;
				if (Opacity - d <= 0.0)
				{
					Opacity = 0.0;
					fadeTimer.Stop();

					this.Visible = false;
					mainForm.Owner = this;
					mainForm.WindowState = FormWindowState.Maximized;
					mainForm.Refresh();
					mainForm.Show();
				}
				else
				{
					Opacity -= d;
				}
			}
		}
		#endregion

		#region 应用程序退出时
		private void Login_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				ServiceController AutoService = new ServiceController(CPTT.SystemFramework.Util.AUTO_SERVICE_NAME);
				if(AutoService.Status.Equals(ServiceControllerStatus.Stopped))
				{
					handleComClass.Stop();
					AutoService.Start();
					Application.Exit();
				}
			}
			catch(Exception ex)
			{
				CPTT.SystemFramework.Util.WriteLog(ex.Message,CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);
			}
		}
		#endregion

		#region 自动关机功能
		[StructLayout(LayoutKind.Sequential, Pack=1)]
			internal struct TokPriv1Luid
		{
			public int Count;
			public long Luid;
			public int Attr;
		}

		[DllImport("kernel32.dll", ExactSpelling=true) ]
		internal static extern IntPtr GetCurrentProcess();

		[DllImport("advapi32.dll", ExactSpelling=true, SetLastError=true) ]
		internal static extern bool OpenProcessToken( IntPtr h, int acc, ref IntPtr phtok );

		[DllImport("advapi32.dll", SetLastError=true) ]
		internal static extern bool LookupPrivilegeValue( string host, string name, ref long pluid );

		[DllImport("advapi32.dll", ExactSpelling=true, SetLastError=true) ]
		internal static extern bool AdjustTokenPrivileges( IntPtr htok, bool disall,
			ref TokPriv1Luid newst, int len, IntPtr prev, IntPtr relen );

		[DllImport("user32.dll", ExactSpelling=true, SetLastError=true) ]
		internal static extern bool ExitWindowsEx( int flag, int rea );

		internal const int SE_PRIVILEGE_ENABLED = 0x00000002;
		internal const int TOKEN_QUERY = 0x00000008;
		internal const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;
		internal const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";
		internal const int EWX_LOGOFF = 0x00000000;
		internal const int EWX_SHUTDOWN = 0x00000001;
		internal const int EWX_REBOOT = 0x00000002;
		internal const int EWX_FORCE = 0x00000004;
		internal const int EWX_POWEROFF = 0x00000008;
		internal const int EWX_FORCEIFHUNG = 0x00000010;

		private void DoExitWin( int flag )
		{
			bool ok;
			TokPriv1Luid tp;
			IntPtr hproc = GetCurrentProcess();
			IntPtr htok = IntPtr.Zero;
			ok = OpenProcessToken( hproc, TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, ref htok );
			tp.Count = 1;
			tp.Luid = 0;
			tp.Attr = SE_PRIVILEGE_ENABLED;
			ok = LookupPrivilegeValue( null, SE_SHUTDOWN_NAME, ref tp.Luid );
			ok = AdjustTokenPrivileges( htok, false, ref tp, 0, IntPtr.Zero, IntPtr.Zero );
			ok = ExitWindowsEx( flag | EWX_FORCE, 0 );
		}

		private void timer_AutoShutDown_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			ArrayList settings = ConfigurationManager.GetConfiguration("CustomizeSettings") as ArrayList;

			shutDownTime = Convert.ToDateTime((settings[3] as XmlNode[])[1].InnerText);

			string timeNow = DateTime.Now.ToString("HH:mm");
			string timeToShutDown = shutDownTime.ToString("HH:mm");

			if(timeNow.Equals(timeToShutDown))
			{
				DoExitWin(EWX_SHUTDOWN);
			}
		}
		#endregion

		#region 自动时间同步
		private void SynchDate(object machineAddr)
		{
			try
			{
				DataFrame controlFrame = new DataFrame();
				controlFrame.sym = new byte[]{(byte)'@',(byte)'@'};
				controlFrame.desAddr = Convert.ToByte(machineAddr);
				controlFrame.comFrameLen = 15;
				controlFrame.srcAddr = 0;
				controlFrame.protocol = CPTT.SystemFramework.Util.TIME_SYNCH_TOKEN;
				controlFrame.seq = CPTT.SystemFramework.Util.FRAME_SEQUENCE_VALUE;
				controlFrame.frameData = new byte[7];

				controlFrame.frameData[0] = Convert.ToByte(DateTime.Now.Year%100);
				controlFrame.frameData[1] = Convert.ToByte((byte)DateTime.Now.Month);
				controlFrame.frameData[2] = Convert.ToByte((byte)DateTime.Now.Day);                            
				controlFrame.frameData[3] = Convert.ToByte((byte)(DateTime.Now.DayOfWeek+1));
				controlFrame.frameData[4] = Convert.ToByte((byte)DateTime.Now.Hour);
				controlFrame.frameData[5] = Convert.ToByte((byte)DateTime.Now.Minute);
				controlFrame.frameData[6] = Convert.ToByte((byte)DateTime.Now.Second);

				controlFrame.computeCheckSum();

				//Monitor.Enter(Login.handleComClass);
				Monitor.Enter(Login.syncRoot);
				try
				{
					Login.handleComClass.WriteSerialCmd(controlFrame.comFrameLen,controlFrame.frameToBytes());//发送问询帧
				}
				finally
				{
					Monitor.Exit(Login.syncRoot); 
				}
				//			Login.handleComClass.WriteSerialCmd(15,new byte[]{(byte)'@',(byte)'@',1,15,0,4,0,
				//				06,10,5,1,22,22,22,236});
				//Monitor.Exit(Login.handleComClass);

				Thread.Sleep((int)CPTT.SystemFramework.Util.SEND_CARD_TIMER_OVERTIME);
			}
			catch
			{
			}
		}

		#endregion

		private void Login_VisibleChanged(object sender, System.EventArgs e)
		{
			textEdit_UserLoginID.Focus();
		}

		private void timer_MedicineRemind_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			string timeNow = DateTime.Now.ToString("HH:mm");

			DataSet doseInfo = new HealthManagementSystem().GetDoseInfo(string.Empty,string.Empty,string.Empty,string.Empty,
				DateTime.Now,DateTime.Now,string.Empty);

			if(doseInfo.Tables[0].Rows.Count>0)
			{
				foreach(DataRow row in doseInfo.Tables[0].Rows)
				{
					string timeToDose = Convert.ToDateTime(row["medicine_time"]).ToString("HH:mm");

					if(timeNow.Equals(timeToDose))
					{
						MessageBox.Show("有学生需要服药,请您注意.","系统信息!",
							MessageBoxButtons.OK,MessageBoxIcon.Information);
					}
				}
			}
		}

		//事务提醒用户持有信息数量重显示
		public void TranMsgStatusChange()
		{
			mainForm.SetMsgStatus();
		}

		private void simpleButton_Service_Click(object sender, System.EventArgs e)
		{
			ConfigForm configFrom = new ConfigForm();
			configFrom.StartPosition = FormStartPosition.CenterScreen;
			configFrom.ShowDialog();
		}

		private void timer_DetectDate_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{

#if SoftwareRegister
			try
			{
				RegistryKey softwareKey = Registry.LocalMachine.OpenSubKey("Software");
				RegistryKey winSysDataKey = softwareKey.OpenSubKey("WindowsDataSystem");

				if ( winSysDataKey == null )
				{
					return;
				}

				RegistryKey ctppKey = winSysDataKey.OpenSubKey("Corporation");

				if ( ctppKey == null )
				{
					return;
				}
				else
				{
					DateTime createDate = Convert.ToDateTime(ctppKey.GetValue("CreateDate"));

					if ( Convert.ToInt32(ctppKey.GetValue("RegisterUser")) == 1 )
					{
						if ( Convert.ToInt32(ctppKey.GetValue("RegisterDays")) >= 30 )
						{
							return;
						}
						else
						{
							if ( DateTime.Now.Date > createDate.Date ) 
							{
								int registerDays = Convert.ToInt32(ctppKey.GetValue("RegisterDays"))+1;

								ctppKey.Close();
								winSysDataKey.Close();
								softwareKey.Close();

								softwareKey = Registry.LocalMachine.OpenSubKey("Software",true);
								winSysDataKey = softwareKey.CreateSubKey("WindowsDataSystem");
								ctppKey = winSysDataKey.CreateSubKey("Corporation");

								ctppKey.SetValue("CreateDate",DateTime.Now);
								ctppKey.SetValue("RegisterDays",registerDays);
							}
						}
					}
				}
			}
			catch(Exception ex)
			{
				CPTT.SystemFramework.Util.WriteLog(ex.Message,CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);
				return;
			}
#endif
		}

		private void SendHardWareAuthenticationToken()
		{
			while(true)
			{
				if ( _alUnAuthenticatedHardWare != null )
				{
					if ( _alUnAuthenticatedHardWare.Count > 0 )
					{
						for ( int i=0; i<_alUnAuthenticatedHardWare.Count; i++ )
						{
							DataFrame authenticationToken = new DataFrame();

							authenticationToken.sym = new byte[]{(byte)'@',(byte)'@'};
							authenticationToken.srcAddr = 0;
							authenticationToken.seq = CPTT.SystemFramework.Util.FRAME_SEQUENCE_VALUE;
							authenticationToken.protocol = CPTT.SystemFramework.Util.HARDWARE_AUTHENTICATION;
							authenticationToken.comFrameLen = (byte)9;
							authenticationToken.frameData = new byte[1];

							// need modify
							if ( _registerDays != -1 )
							{
								if ( _registerDays >= 40 )
									authenticationToken.frameData[0] = Convert.ToByte(254);
								else
									authenticationToken.frameData[0] = Convert.ToByte(_registerDays);
							}
							else continue;

							authenticationToken.desAddr = Convert.ToByte(_alUnAuthenticatedHardWare[i].ToString());

							authenticationToken.computeCheckSum();

							//Monitor.Enter(handleComClass);
							Monitor.Enter(syncRoot);
							try
							{
								handleComClass.WriteSerialCmd(authenticationToken.comFrameLen,authenticationToken.frameToBytes());//发送问询帧
							}
							finally
							{
								Monitor.Exit(syncRoot);
							}

							Thread.Sleep(SystemFramework.Util.QUERY_AUTHENTICATION_INTERVAL);
						}
					}
					else Thread.Sleep(CPTT.SystemFramework.Util.QUERY_NULL_INTERVAL);
				}
				else
				{
					MessageBox.Show("数据库连接失败！");
					break;
				}
			}
		}

		private void HandleHardWareAuthenticationSucceed(byte srcAddr)
		{
			int getSrcAddr = Convert.ToInt16(srcAddr);
			HardWareAuthentication.SetAuthorizedHardWare(getSrcAddr);
			HardWareAuthentication.SetUnAuthorizedHardWare(getSrcAddr);
		}

		private void Login_Load(object sender, System.EventArgs e)
		{
			HardWareAuthenticationSucceed += new HardWareAuthenticationSucceedHandler(this.HandleHardWareAuthenticationSucceed);
		}

		private void simpleButton_restore_Click(object sender, System.EventArgs e)
		{
			this.SuspendAllThread();
			RestoreForm restoreForm = new RestoreForm(this);
			restoreForm.StartPosition = FormStartPosition.CenterScreen;
			restoreForm.ShowDialog();
		}

		private void AssignUniqueGardenID()
		{
			bool hasAssigned = new UtilSystem().CheckHasAssignedUniqueGardenID();
			if (!hasAssigned)
			{
				AddGardenName newAdd = new AddGardenName();
				newAdd.StartPosition = FormStartPosition.CenterScreen;
				newAdd.ShowDialog();
			}
		}

		private SetMachineVol setVol;
		public SetMachineVol SetVol 
		{
			get { return setVol; }
			set { setVol = value; }
		}

		#region auto update
//		private void appUpdater_ForCTPP_OnUpdateComplete(object sender, Microsoft.Samples.AppUpdater.UpdateCompleteEventArgs e)
//		{
//			MessageBox.Show("下载完成程序将重新启动,请稍候.","系统信息!",
//				MessageBoxButtons.OK,MessageBoxIcon.Information);
//			appUpdater_ForCTPP.RestartApp();
//		}
//
//		private void appUpdater_ForCTPP_OnUpdateDetected(object sender, System.EventArgs e)
//		{
//			if(DialogResult.Yes	== MessageBox.Show("有新版本存在是否要自动升级.","系统信息!",
//				MessageBoxButtons.YesNo,MessageBoxIcon.Information))
//			{
//				appUpdater_ForCTPP.DownloadUpdate();
//			}
//		}
		#endregion

        private void StartSqlExpressIfStopped()
        {
            try
            {
                using (System.ServiceProcess.ServiceController control = new ServiceController("MSSQLSERVER"))
                {
                    if (control.Status == System.ServiceProcess.ServiceControllerStatus.Stopped)
                    {
                        control.Start();
                    }
                }
            }
            catch (Exception)
            {
            }

            try
            {
                using (System.ServiceProcess.ServiceController control = new ServiceController("MSSQL$SQLEXPRESS"))
                {
                    if (control.Status == System.ServiceProcess.ServiceControllerStatus.Stopped)
                    {
                        control.Start();
                    }
                }
            }
            catch (Exception)
            {
            }
        }
	}
}

