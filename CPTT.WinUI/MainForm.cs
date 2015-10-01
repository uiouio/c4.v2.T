//==================================================================================
// 创智智能晨检网络管理系统4.0
//==================================================================================
// Copyright @2005 Shanghai Chuangzhi Toy&Technology Corporation All rights reserved.
//本计算机程序受版权法和国际条约保护.
// 如未经授权而擅自复制或传播本程序(或其中任何部分),将受到严厉的民事及刑事制裁,
//并将在法律许可的范围内受到最大程度的起诉!
//==================================================================================

#define DisableSessionTimeout


using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.Threading;
using System.IO;
using CPTT.BusinessFacade;

using CPTT.SystemFramework;
using Microsoft.Practices.EnterpriseLibrary.Configuration;

namespace CPTT.WinUI
{
	/// <summary>
	/// Summary description for MainForm.
	/// </summary>
	public class MainForm : DevExpress.XtraEditors.XtraForm
	{
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
		private DevExpress.XtraBars.BarSubItem barSubItem_System;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_Exit;
		private DevExpress.XtraBars.BarSubItem barSubItem_Windows;
		private DevExpress.XtraBars.BarSubItem barSubItem_Style;
		private DevExpress.XtraBars.BarSubItem barSubItem_Tools;
		private DevExpress.XtraBars.BarSubItem barSubItem_Help;
		private DevExpress.XtraNavBar.NavBarControl navBarControl_Main;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_Logout;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_DutyInfo;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_Help;
		private DevExpress.XtraNavBar.NavBarGroup navBarGroup_TeacherInfo;
		private DevExpress.XtraNavBar.NavBarGroup navBarGroup_StudentInfo;
		private DevExpress.XtraBars.BarStaticItem barStaticItem_SystemInfo;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_CarDataSynch;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_Options;
		private DevExpress.XtraNavBar.NavBarItem navBarItem_TeaBaseInfo;
		private DevExpress.XtraNavBar.NavBarItem navBarItem_StuBaseInfo;
		private DevExpress.XtraNavBar.NavBarItem navBarItem_TeaDutyInfo;
		private DevExpress.XtraNavBar.NavBarItem navBarItem_StuDutyInfo;
		private DevExpress.XtraNavBar.NavBarItem navBarItem_StuHealth;
		private DevExpress.XtraNavBar.NavBarGroup navBarGroup_GardenInfo;
		private DevExpress.XtraNavBar.NavBarItem navBarItem_GardenInfo;
		private DevExpress.XtraNavBar.NavBarGroup navBarGroup_GardenAffair;
		private DevExpress.XtraNavBar.NavBarItem navBarItem_SMSInfo;
		private DevExpress.XtraNavBar.NavBarItem navBarItem_AffairNotify;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_Camera;
		private DevExpress.XtraBars.BarManager barManager_Main;
		private DevExpress.XtraBars.Bar barMain;
		private DevExpress.XtraBars.Bar barToolBar;
		private DevExpress.XtraBars.BarStaticItem barStaticItem_SystemDate;
		private DevExpress.XtraBars.BarStaticItem barStaticItem_Custom;
		private System.Windows.Forms.PictureBox pictureBox_Border;
		private DevExpress.XtraNavBar.NavBarItem navBarItem_Finance;
		private DevExpress.XtraEditors.SplitterControl splitterControlMain;
		private CPTT.WinUI.Panels.PaneCaption paneCaption_Title;
		private System.Windows.Forms.ImageList imageList_ToolBarIcon;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_DefaultSkin;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_WinXPSkin;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_OfficeXP;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_Office2000;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_Office2003;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_About;
		private DevExpress.XtraBars.Bar barStatus;
		private DevExpress.XtraBars.BarStaticItem barStaticItem_Ready;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_CustomDefine;
		private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
		private DevExpress.XtraBars.Docking.DockManager dockManager_CurrentStuCheckInfo;
		private DevExpress.XtraBars.Docking.DockPanel currentStuCheckInfo;
		private DevExpress.XtraNavBar.NavBarItem navBarItem_CardManagement;
		private System.Windows.Forms.PictureBox pictureBox_BackLogo;
		private System.ComponentModel.IContainer components = null;
		private CPTT.WinUI.Panels.RealTimeWindows realTimeWindows;

		internal const string USERSTYLEPROFILE_CONFIG_NAME = "UserStyleProfile";
		internal bool MORNINGCHECK_WINDOWS_SHOW = true;
		private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerRight;
		private DevExpress.XtraEditors.PanelControl panelControl_Center;
		public CPTT.WinUI.Panels.StudentMorningCheckInfo studentMorningCheckInfo1;
		private CPTT.WinUI.Panels.TeacherBaseInfo teacherBaseInfo1;
		private CPTT.WinUI.Panels.StudentBaseInfo studentBaseInfo1;
        private CPTT.WinUI.Panels.Camera cameraPanel;
		private CPTT.WinUI.Panels.GardenInfo gardenInfo1;
		private CPTT.WinUI.Panels.TeacherOnDutyInfo teacherOnDutyInfo1;
		private CPTT.WinUI.Panels.CardManagement cardManagement2;
		private CPTT.WinUI.Panels.TransactionReminding transactionReminding1;
		private CPTT.WinUI.Panels.FinanManagement2 finanManagement2;
		private System.Windows.Forms.NotifyIcon notifyIcon_MainForm;
		private System.Windows.Forms.ContextMenu contextMenu_NotifyIcon;
		private System.Windows.Forms.MenuItem menuItem_ShowMainForm;
		private System.Windows.Forms.MenuItem menuItem_Exit;
		private CPTT.WinUI.Panels.RealtimeInfo_Teacher realtimeInfo_Teacher1;
		private CPTT.WinUI.Panels.SmsInfo smsInfo1;
		private CPTT.WinUI.Panels.RealtimeInfo realtimeInfo1;
		public DevExpress.XtraNavBar.NavBarItem navBarItem_RealTimeInfo;
		private CPTT.WinUI.Panels.StudentVisitInfo studentVisitInfo1;
		private DevExpress.XtraNavBar.NavBarItem navBarItem_StuVisit;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_PrintSetting;
		private CPTT.WinUI.Panels.FinanManagement finanManagement1;
		private CPTT.WinUI.Panels.NutritionManagement nutritionManagement1;
		private DevExpress.XtraBars.BarButtonItem barButtonItem1;
		public DevExpress.XtraNavBar.NavBarItem navBarItem_RealtimeInfo_Teacher; 
		private UserStyle userStyle;
		private HealthManagementSystem healthManagementSystem;
		private System.Timers.Timer timerSynSession;
		private UtilSystem utilSystem;

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			userStyle = new UserStyle();

			MenuDisplayByRole();

			//加载皮肤名称集
			loadSkinName();

			//加载用户选择的窗体风格信息
			loadUserStyleProfile();

			healthManagementSystem = new HealthManagementSystem();

			utilSystem = new UtilSystem();

#if DisableSessionTimeout
			timerSynSession.Enabled = false;
#endif

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.barManager_Main = new DevExpress.XtraBars.BarManager();
			this.barMain = new DevExpress.XtraBars.Bar();
			this.barSubItem_System = new DevExpress.XtraBars.BarSubItem();
			this.barButtonItem_PrintSetting = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem_Logout = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem_Exit = new DevExpress.XtraBars.BarButtonItem();
			this.barSubItem_Tools = new DevExpress.XtraBars.BarSubItem();
			this.barButtonItem_CustomDefine = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem_CarDataSynch = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem_Options = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
			this.barSubItem_Windows = new DevExpress.XtraBars.BarSubItem();
			this.barButtonItem_DutyInfo = new DevExpress.XtraBars.BarButtonItem();
			this.barSubItem_Style = new DevExpress.XtraBars.BarSubItem();
			this.barButtonItem_DefaultSkin = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem_WinXPSkin = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem_OfficeXP = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem_Office2000 = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem_Office2003 = new DevExpress.XtraBars.BarButtonItem();
			this.barSubItem_Help = new DevExpress.XtraBars.BarSubItem();
			this.barButtonItem_Help = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem_About = new DevExpress.XtraBars.BarButtonItem();
			this.barToolBar = new DevExpress.XtraBars.Bar();
			this.barStatus = new DevExpress.XtraBars.Bar();
			this.barStaticItem_Ready = new DevExpress.XtraBars.BarStaticItem();
			this.barStaticItem_SystemInfo = new DevExpress.XtraBars.BarStaticItem();
			this.barStaticItem_SystemDate = new DevExpress.XtraBars.BarStaticItem();
			this.barStaticItem_Custom = new DevExpress.XtraBars.BarStaticItem();
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			this.dockManager_CurrentStuCheckInfo = new DevExpress.XtraBars.Docking.DockManager();
			this.hideContainerRight = new DevExpress.XtraBars.Docking.AutoHideContainer();
			this.currentStuCheckInfo = new DevExpress.XtraBars.Docking.DockPanel();
			this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
			this.imageList_ToolBarIcon = new System.Windows.Forms.ImageList(this.components);
			this.pictureBox_Border = new System.Windows.Forms.PictureBox();
			this.navBarControl_Main = new DevExpress.XtraNavBar.NavBarControl();
			this.navBarGroup_GardenInfo = new DevExpress.XtraNavBar.NavBarGroup();
			this.navBarItem_GardenInfo = new DevExpress.XtraNavBar.NavBarItem();
			this.navBarGroup_TeacherInfo = new DevExpress.XtraNavBar.NavBarGroup();
			this.navBarItem_TeaBaseInfo = new DevExpress.XtraNavBar.NavBarItem();
			this.navBarItem_TeaDutyInfo = new DevExpress.XtraNavBar.NavBarItem();
			this.navBarGroup_StudentInfo = new DevExpress.XtraNavBar.NavBarGroup();
			this.navBarItem_StuBaseInfo = new DevExpress.XtraNavBar.NavBarItem();
			this.navBarItem_StuDutyInfo = new DevExpress.XtraNavBar.NavBarItem();
			this.navBarItem_RealTimeInfo = new DevExpress.XtraNavBar.NavBarItem();
			this.navBarItem_StuHealth = new DevExpress.XtraNavBar.NavBarItem();
			this.navBarItem_StuVisit = new DevExpress.XtraNavBar.NavBarItem();
			this.navBarGroup_GardenAffair = new DevExpress.XtraNavBar.NavBarGroup();
			this.navBarItem_CardManagement = new DevExpress.XtraNavBar.NavBarItem();
			this.navBarItem_Finance = new DevExpress.XtraNavBar.NavBarItem();
			this.navBarItem_SMSInfo = new DevExpress.XtraNavBar.NavBarItem();
			this.navBarItem_AffairNotify = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem_Camera = new DevExpress.XtraNavBar.NavBarItem();
			this.splitterControlMain = new DevExpress.XtraEditors.SplitterControl();
			this.paneCaption_Title = new CPTT.WinUI.Panels.PaneCaption();
			this.pictureBox_BackLogo = new System.Windows.Forms.PictureBox();
			this.panelControl_Center = new DevExpress.XtraEditors.PanelControl();
			this.nutritionManagement1 = new CPTT.WinUI.Panels.NutritionManagement();
			this.finanManagement1 = new CPTT.WinUI.Panels.FinanManagement();
			this.realtimeInfo_Teacher1 = new CPTT.WinUI.Panels.RealtimeInfo_Teacher();
			this.smsInfo1 = new CPTT.WinUI.Panels.SmsInfo();
//			this.gardenInfo1 = new CPTT.WinUI.Panels.GardenInfo();
//			this.teacherOnDutyInfo1 = new CPTT.WinUI.Panels.TeacherOnDutyInfo();
			this.studentVisitInfo1 = new CPTT.WinUI.Panels.StudentVisitInfo();
			this.realtimeInfo1 = new CPTT.WinUI.Panels.RealtimeInfo();
			this.teacherBaseInfo1 = new CPTT.WinUI.Panels.TeacherBaseInfo();
			this.studentBaseInfo1 = new CPTT.WinUI.Panels.StudentBaseInfo();
            this.cameraPanel = new CPTT.WinUI.Panels.Camera();
			this.studentMorningCheckInfo1 = new CPTT.WinUI.Panels.StudentMorningCheckInfo();
			this.cardManagement2 = new CPTT.WinUI.Panels.CardManagement();
			this.realTimeWindows = new CPTT.WinUI.Panels.RealTimeWindows(this);
			this.transactionReminding1 = new CPTT.WinUI.Panels.TransactionReminding();
			this.notifyIcon_MainForm = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenu_NotifyIcon = new System.Windows.Forms.ContextMenu();
			this.menuItem_ShowMainForm = new System.Windows.Forms.MenuItem();
			this.menuItem_Exit = new System.Windows.Forms.MenuItem();
			this.navBarItem_RealtimeInfo_Teacher = new DevExpress.XtraNavBar.NavBarItem();
			this.timerSynSession = new System.Timers.Timer();
			((System.ComponentModel.ISupportInitialize)(this.timerSynSession)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.barManager_Main)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dockManager_CurrentStuCheckInfo)).BeginInit();
			this.hideContainerRight.SuspendLayout();
			this.currentStuCheckInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.navBarControl_Main)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl_Center)).BeginInit();
			this.panelControl_Center.SuspendLayout();
			this.SuspendLayout();
			// 
			// barManager_Main
			// 
			this.barManager_Main.AllowCustomization = false;
			this.barManager_Main.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
																				 this.barMain,
																				 this.barToolBar,
																				 this.barStatus});
			this.barManager_Main.DockControls.Add(this.barDockControlTop);
			this.barManager_Main.DockControls.Add(this.barDockControlBottom);
			this.barManager_Main.DockControls.Add(this.barDockControlLeft);
			this.barManager_Main.DockControls.Add(this.barDockControlRight);
			this.barManager_Main.DockManager = this.dockManager_CurrentStuCheckInfo;
			this.barManager_Main.Form = this;
			this.barManager_Main.Images = this.imageList_ToolBarIcon;
			this.barManager_Main.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
																					  this.barSubItem_System,
																					  this.barButtonItem_Exit,
																					  this.barSubItem_Windows,
																					  this.barSubItem_Style,
																					  this.barSubItem_Tools,
																					  this.barSubItem_Help,
																					  this.barButtonItem_Logout,
																					  this.barButtonItem_DutyInfo,
																					  this.barButtonItem_Help,
																					  this.barButtonItem_About,
																					  this.barStaticItem_SystemInfo,
																					  this.barStaticItem_SystemDate,
																					  this.barStaticItem_Custom,
																					  this.barButtonItem_CarDataSynch,
																					  this.barButtonItem_Options,
																					  this.barButtonItem_DefaultSkin,
																					  this.barButtonItem_WinXPSkin,
																					  this.barButtonItem_OfficeXP,
																					  this.barButtonItem_Office2000,
																					  this.barButtonItem_Office2003,
																					  this.barStaticItem_Ready,
																					  this.barButtonItem_CustomDefine,
																					  this.barButtonItem_PrintSetting,
																					  this.barButtonItem1});
			this.barManager_Main.LargeImages = this.imageList_ToolBarIcon;
			this.barManager_Main.MainMenu = this.barMain;
			this.barManager_Main.MaxItemId = 32;
			this.barManager_Main.StatusBar = this.barStatus;
			// 
			// barMain
			// 
			this.barMain.BarName = "主菜单";
			this.barMain.DockCol = 0;
			this.barMain.DockRow = 0;
			this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
			this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
																								 new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem_System, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
																								 new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem_Tools, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
																								 new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem_Windows, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
																								 new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem_Help, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
			this.barMain.OptionsBar.AllowQuickCustomization = false;
			this.barMain.OptionsBar.MultiLine = true;
			this.barMain.OptionsBar.UseWholeRow = true;
			this.barMain.Text = "主菜单";
			// 
			// barSubItem_System
			// 
			this.barSubItem_System.Caption = "系统(&S)";
			this.barSubItem_System.Id = 0;
			this.barSubItem_System.ImageIndex = 6;
			this.barSubItem_System.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
																										   new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_PrintSetting),
																										   new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Logout),
																										   new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Exit)});
			this.barSubItem_System.Name = "barSubItem_System";
			// 
			// barButtonItem_PrintSetting
			// 
			this.barButtonItem_PrintSetting.Caption = "打印设置";
			this.barButtonItem_PrintSetting.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem_PrintSetting.Glyph")));
			this.barButtonItem_PrintSetting.Id = 29;
			this.barButtonItem_PrintSetting.Name = "barButtonItem_PrintSetting";
			this.barButtonItem_PrintSetting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
			// 
			// barButtonItem_Logout
			// 
			this.barButtonItem_Logout.Caption = "注销(&O)";
			this.barButtonItem_Logout.Hint = "注销";
			this.barButtonItem_Logout.Id = 10;
			this.barButtonItem_Logout.ImageIndex = 7;
			this.barButtonItem_Logout.Name = "barButtonItem_Logout";
			this.barButtonItem_Logout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Logout_ItemClick);
			// 
			// barButtonItem_Exit
			// 
			this.barButtonItem_Exit.Caption = "退出(&X)";
			this.barButtonItem_Exit.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem_Exit.Glyph")));
			this.barButtonItem_Exit.Id = 2;
			this.barButtonItem_Exit.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X));
			this.barButtonItem_Exit.Name = "barButtonItem_Exit";
			this.barButtonItem_Exit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Exit_ItemClick);
			// 
			// barSubItem_Tools
			// 
			this.barSubItem_Tools.Caption = "工具(&T)";
			this.barSubItem_Tools.Glyph = ((System.Drawing.Image)(resources.GetObject("barSubItem_Tools.Glyph")));
			this.barSubItem_Tools.Id = 7;
			this.barSubItem_Tools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
																										  new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_CustomDefine),
																										  new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_CarDataSynch),
																										  new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Options),
																										  new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
			this.barSubItem_Tools.Name = "barSubItem_Tools";
			// 
			// barButtonItem_CustomDefine
			// 
			this.barButtonItem_CustomDefine.Caption = "自定义信息维护(&C)";
			this.barButtonItem_CustomDefine.Hint = "自定义信息维护";
			this.barButtonItem_CustomDefine.Id = 28;
			this.barButtonItem_CustomDefine.ImageIndex = 10;
			this.barButtonItem_CustomDefine.Name = "barButtonItem_CustomDefine";
			this.barButtonItem_CustomDefine.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_CustomDefine_ItemClick);
			// 
			// barButtonItem_CarDataSynch
			// 
			this.barButtonItem_CarDataSynch.Caption = "车载机数据同步(&Y)";
			this.barButtonItem_CarDataSynch.Hint = "车载机数据同步";
			this.barButtonItem_CarDataSynch.Id = 20;
			this.barButtonItem_CarDataSynch.ImageIndex = 11;
			this.barButtonItem_CarDataSynch.Name = "barButtonItem_CarDataSynch";
			this.barButtonItem_CarDataSynch.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
			// 
			// barButtonItem_Options
			// 
			this.barButtonItem_Options.Caption = "选项(&O)";
			this.barButtonItem_Options.Id = 21;
			this.barButtonItem_Options.ImageIndex = 15;
			this.barButtonItem_Options.Name = "barButtonItem_Options";
			this.barButtonItem_Options.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Options_ItemClick);
			// 
			// barButtonItem1
			// 
			this.barButtonItem1.Caption = "硬件配置管理(&K)";
			this.barButtonItem1.Id = 31;
			this.barButtonItem1.ImageIndex = 11;
			this.barButtonItem1.Name = "barButtonItem1";
			this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
			// 
			// barSubItem_Windows
			// 
			this.barSubItem_Windows.Caption = "窗口(&W)";
			this.barSubItem_Windows.Id = 3;
			this.barSubItem_Windows.ImageIndex = 13;
			this.barSubItem_Windows.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
																											new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_DutyInfo),
																											new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem_Style)});
			this.barSubItem_Windows.Name = "barSubItem_Windows";
			// 
			// barButtonItem_DutyInfo
			// 
			this.barButtonItem_DutyInfo.Caption = "实时出勤信息窗口(&D)";
			this.barButtonItem_DutyInfo.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem_DutyInfo.Glyph")));
			this.barButtonItem_DutyInfo.Hint = "实时晨检出勤窗口";
			this.barButtonItem_DutyInfo.Id = 11;
			this.barButtonItem_DutyInfo.ImageIndex = 8;
			this.barButtonItem_DutyInfo.Name = "barButtonItem_DutyInfo";
			this.barButtonItem_DutyInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_DutyInfo_ItemClick);
			// 
			// barSubItem_Style
			// 
			this.barSubItem_Style.Caption = "窗体风格(&S)";
			this.barSubItem_Style.Id = 6;
			this.barSubItem_Style.ImageIndex = 8;
			this.barSubItem_Style.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
																										  new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_DefaultSkin),
																										  new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_WinXPSkin),
																										  new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_OfficeXP),
																										  new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Office2000),
																										  new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Office2003)});
			this.barSubItem_Style.Name = "barSubItem_Style";
			// 
			// barButtonItem_DefaultSkin
			// 
			this.barButtonItem_DefaultSkin.Caption = "默认";
			this.barButtonItem_DefaultSkin.Id = 22;
			this.barButtonItem_DefaultSkin.Name = "barButtonItem_DefaultSkin";
			this.barButtonItem_DefaultSkin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_DefaultSkin_ItemClick);
			// 
			// barButtonItem_WinXPSkin
			// 
			this.barButtonItem_WinXPSkin.Caption = "Windows XP";
			this.barButtonItem_WinXPSkin.Id = 23;
			this.barButtonItem_WinXPSkin.ImageIndex = 0;
			this.barButtonItem_WinXPSkin.Name = "barButtonItem_WinXPSkin";
			this.barButtonItem_WinXPSkin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_WinXPSkin_ItemClick);
			// 
			// barButtonItem_OfficeXP
			// 
			this.barButtonItem_OfficeXP.Caption = "Office XP";
			this.barButtonItem_OfficeXP.Id = 24;
			this.barButtonItem_OfficeXP.ImageIndex = 1;
			this.barButtonItem_OfficeXP.Name = "barButtonItem_OfficeXP";
			this.barButtonItem_OfficeXP.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_OfficeXP_ItemClick);
			// 
			// barButtonItem_Office2000
			// 
			this.barButtonItem_Office2000.Caption = "Office 2000";
			this.barButtonItem_Office2000.Id = 25;
			this.barButtonItem_Office2000.ImageIndex = 2;
			this.barButtonItem_Office2000.Name = "barButtonItem_Office2000";
			this.barButtonItem_Office2000.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Office2000_ItemClick);
			// 
			// barButtonItem_Office2003
			// 
			this.barButtonItem_Office2003.Caption = "Office 2003";
			this.barButtonItem_Office2003.Id = 26;
			this.barButtonItem_Office2003.ImageIndex = 3;
			this.barButtonItem_Office2003.Name = "barButtonItem_Office2003";
			this.barButtonItem_Office2003.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Office2003_ItemClick);
			// 
			// barSubItem_Help
			// 
			this.barSubItem_Help.Caption = "帮助(&H)";
			this.barSubItem_Help.Id = 8;
			this.barSubItem_Help.ImageIndex = 4;
			this.barSubItem_Help.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
																										 new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Help),
																										 new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_About)});
			this.barSubItem_Help.Name = "barSubItem_Help";
			// 
			// barButtonItem_Help
			// 
			this.barButtonItem_Help.Caption = "系统帮助(&H)";
			this.barButtonItem_Help.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem_Help.Glyph")));
			this.barButtonItem_Help.Id = 12;
			this.barButtonItem_Help.Name = "barButtonItem_Help";
			this.barButtonItem_Help.ItemClick+=new ItemClickEventHandler(barButtonItem_Help_ItemClick);
			// 
			// barButtonItem_About
			// 
			this.barButtonItem_About.Caption = "关于创智智能晨检网络管理系统(&A)";
			this.barButtonItem_About.Id = 15;
			this.barButtonItem_About.ImageIndex = 9;
			this.barButtonItem_About.Name = "barButtonItem_About";
			this.barButtonItem_About.ItemClick+=new ItemClickEventHandler(barButtonItem_About_ItemClick);
			// 
			// barToolBar
			// 
			this.barToolBar.BarName = "辅助工具栏";
			this.barToolBar.DockCol = 0;
			this.barToolBar.DockRow = 1;
			this.barToolBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
			this.barToolBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
																									new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem_Logout, DevExpress.XtraBars.BarItemPaintStyle.Standard),
																									new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem_CustomDefine, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard),
																									new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem_CarDataSynch, DevExpress.XtraBars.BarItemPaintStyle.Standard),
																									new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem_DutyInfo, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard)});
			this.barToolBar.OptionsBar.AllowQuickCustomization = false;
			this.barToolBar.Text = "辅助工具栏";
			// 
			// barStatus
			// 
			this.barStatus.BarName = "状态栏";
			this.barStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
			this.barStatus.DockCol = 0;
			this.barStatus.DockRow = 0;
			this.barStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
			this.barStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
																								   new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem_Ready, true),
																								   new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barStaticItem_SystemInfo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
																								   new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem_SystemDate),
																								   new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem_Custom)});
			this.barStatus.OptionsBar.AllowQuickCustomization = false;
			this.barStatus.OptionsBar.DrawDragBorder = false;
			this.barStatus.OptionsBar.DrawSizeGrip = true;
			this.barStatus.OptionsBar.UseWholeRow = true;
			this.barStatus.Text = "状态栏";
			// 
			// barStaticItem_Ready
			// 
			this.barStaticItem_Ready.AutoSize = DevExpress.XtraBars.BarStaticItemSize.None;
			this.barStaticItem_Ready.Caption = "就绪";
			this.barStaticItem_Ready.Id = 27;
			this.barStaticItem_Ready.Name = "barStaticItem_Ready";
			this.barStaticItem_Ready.TextAlignment = System.Drawing.StringAlignment.Near;
			this.barStaticItem_Ready.Width = 150;
			// 
			// barStaticItem_SystemInfo
			// 
			this.barStaticItem_SystemInfo.AutoSize = DevExpress.XtraBars.BarStaticItemSize.None;
			this.barStaticItem_SystemInfo.Caption = "创智智能晨检网络管理系统"+SystemFramework.Util.PROJECT_VERSION;
			this.barStaticItem_SystemInfo.Id = 16;
			this.barStaticItem_SystemInfo.Name = "barStaticItem_SystemInfo";
			this.barStaticItem_SystemInfo.TextAlignment = System.Drawing.StringAlignment.Near;
			this.barStaticItem_SystemInfo.Width = 300;
			// 
			// barStaticItem_SystemDate
			// 
			this.barStaticItem_SystemDate.AutoSize = DevExpress.XtraBars.BarStaticItemSize.None;
			this.barStaticItem_SystemDate.Id = 18;
			this.barStaticItem_SystemDate.Name = "barStaticItem_SystemDate";
			this.barStaticItem_SystemDate.TextAlignment = System.Drawing.StringAlignment.Center;
			this.barStaticItem_SystemDate.Width = 200;
			// 
			// barStaticItem_Custom
			// 
			this.barStaticItem_Custom.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring;
			this.barStaticItem_Custom.Id = 19;
			this.barStaticItem_Custom.Name = "barStaticItem_Custom";
			this.barStaticItem_Custom.TextAlignment = System.Drawing.StringAlignment.Near;
			this.barStaticItem_Custom.Width = 32;
			// 
			// barDockControlTop
			// 
			this.barDockControlTop.Appearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.barDockControlTop.Appearance.BackColor2 = System.Drawing.Color.DarkGray;
			this.barDockControlTop.Appearance.Options.UseBackColor = true;
			// 
			// dockManager_CurrentStuCheckInfo
			// 
			this.dockManager_CurrentStuCheckInfo.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
																																	 this.hideContainerRight});
			this.dockManager_CurrentStuCheckInfo.Form = this;
			this.dockManager_CurrentStuCheckInfo.TopZIndexControls.AddRange(new string[] {
																							 "DevExpress.XtraBars.BarDockControl",
																							 "System.Windows.Forms.StatusBar"});
			// 
			// hideContainerRight
			// 
			this.hideContainerRight.Controls.Add(this.currentStuCheckInfo);
			this.hideContainerRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.hideContainerRight.Location = new System.Drawing.Point(932, 52);
			this.hideContainerRight.Name = "hideContainerRight";
			this.hideContainerRight.Size = new System.Drawing.Size(20, 559);
			//
			//realTimeWindows
			//
			this.realTimeWindows.Location = new System.Drawing.Point(200,40);
			this.realTimeWindows.Name = "realTimeWindows";
			this.realTimeWindows.Size = new System.Drawing.Size(40,40);
			this.realTimeWindows.TabIndex = 4;
			this.realTimeWindows.Visible = true;
			// 
			// currentStuCheckInfo
			// 
			this.currentStuCheckInfo.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.currentStuCheckInfo.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(1)), true);
			this.currentStuCheckInfo.Appearance.Options.UseBackColor = true;
			this.currentStuCheckInfo.Appearance.Options.UseFont = true;
			this.currentStuCheckInfo.BackColor = System.Drawing.Color.WhiteSmoke;
			this.currentStuCheckInfo.Controls.Add(this.dockPanel1_Container);
			this.currentStuCheckInfo.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
			this.currentStuCheckInfo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(1)), true);
			this.currentStuCheckInfo.ID = new System.Guid("51b4d356-ef66-4435-8cec-78ddcc6c1c48");
			this.currentStuCheckInfo.Location = new System.Drawing.Point(0, 0);
			this.currentStuCheckInfo.Name = "currentStuCheckInfo";
			this.currentStuCheckInfo.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
			this.currentStuCheckInfo.SavedIndex = 0;
			this.currentStuCheckInfo.Size = new System.Drawing.Size(200, 566);
			this.currentStuCheckInfo.Text = "实时出勤信息  ";
			this.currentStuCheckInfo.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
			this.currentStuCheckInfo.Controls.Add(realTimeWindows);
			this.realTimeWindows.Dock = DockStyle.Fill;
			// 
			// dockPanel1_Container
			// 
			this.dockPanel1_Container.Location = new System.Drawing.Point(4, 22);
			this.dockPanel1_Container.Name = "dockPanel1_Container";
			this.dockPanel1_Container.Size = new System.Drawing.Size(192, 540);
			this.dockPanel1_Container.TabIndex = 0;
			// 
			// imageList_ToolBarIcon
			// 
			this.imageList_ToolBarIcon.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList_ToolBarIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_ToolBarIcon.ImageStream")));
			this.imageList_ToolBarIcon.TransparentColor = System.Drawing.Color.Empty;
			// 
			// pictureBox_Border
			// 
			this.pictureBox_Border.Dock = System.Windows.Forms.DockStyle.Left;
			this.pictureBox_Border.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Border.Image")));
			this.pictureBox_Border.Location = new System.Drawing.Point(0, 52);
			this.pictureBox_Border.Name = "pictureBox_Border";
			this.pictureBox_Border.Size = new System.Drawing.Size(32, 559);
			this.pictureBox_Border.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox_Border.TabIndex = 5;
			this.pictureBox_Border.TabStop = false;
			// 
			// navBarControl_Main
			// 
			this.navBarControl_Main.ActiveGroup = this.navBarGroup_GardenInfo;
			this.navBarControl_Main.AllowDrop = true;
			this.navBarControl_Main.Appearance.GroupHeaderActive.Options.UseTextOptions = true;
			this.navBarControl_Main.Appearance.GroupHeaderActive.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.navBarControl_Main.Appearance.Item.Options.UseTextOptions = true;
			this.navBarControl_Main.Appearance.Item.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.navBarControl_Main.Appearance.ItemActive.Options.UseTextOptions = true;
			this.navBarControl_Main.Appearance.ItemActive.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.navBarControl_Main.BackColor = System.Drawing.Color.WhiteSmoke;
			this.navBarControl_Main.Dock = System.Windows.Forms.DockStyle.Left;
			this.navBarControl_Main.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
																								this.navBarGroup_GardenInfo,
																								this.navBarGroup_TeacherInfo,
																								this.navBarGroup_StudentInfo,
																								this.navBarGroup_GardenAffair});
			this.navBarControl_Main.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
																							  this.navBarItem_GardenInfo,
																							  this.navBarItem_TeaBaseInfo,
																							  this.navBarItem_StuBaseInfo,
																							  this.navBarItem_TeaDutyInfo,
																							  this.navBarItem_StuDutyInfo,
																							  this.navBarItem_StuHealth,
																							  this.navBarItem_SMSInfo,
																							  this.navBarItem_AffairNotify,
																							  this.navBarItem_Finance,
																							  this.navBarItem_CardManagement,
																							  this.navBarItem_RealTimeInfo,
																							  this.navBarItem_StuVisit,
																							  this.navBarItem_RealtimeInfo_Teacher,
                                                                                              this.navBarItem_Camera});
			this.navBarControl_Main.Location = new System.Drawing.Point(32, 52);
			this.navBarControl_Main.Name = "navBarControl_Main";
			this.navBarControl_Main.Size = new System.Drawing.Size(168, 559);
			this.navBarControl_Main.TabIndex = 6;
			this.navBarControl_Main.Text = "主导航栏";
			this.navBarControl_Main.HotTrackedLinkChanged += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarControl_Main_HotTrackedLinkChanged);
			this.navBarControl_Main.MouseLeave += new System.EventHandler(this.navBarControl_Main_MouseLeave);
			// 
			// navBarGroup_GardenInfo
			// 
			this.navBarGroup_GardenInfo.Appearance.Options.UseTextOptions = true;
			this.navBarGroup_GardenInfo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.navBarGroup_GardenInfo.AppearanceHotTracked.Options.UseTextOptions = true;
			this.navBarGroup_GardenInfo.AppearanceHotTracked.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.navBarGroup_GardenInfo.AppearancePressed.Options.UseTextOptions = true;
			this.navBarGroup_GardenInfo.AppearancePressed.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.navBarGroup_GardenInfo.Caption = "园所信息管理";
			this.navBarGroup_GardenInfo.DragDropFlags = DevExpress.XtraNavBar.NavBarDragDrop.None;
			this.navBarGroup_GardenInfo.Expanded = true;
			this.navBarGroup_GardenInfo.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText;
			this.navBarGroup_GardenInfo.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
																										  new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_GardenInfo)});
//			this.navBarGroup_GardenInfo.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup_GardenInfo.LargeImage")));
			this.navBarGroup_GardenInfo.Name = "navBarGroup_GardenInfo";
			// 
			// navBarItem_GardenInfo
			// 
			this.navBarItem_GardenInfo.Caption = "基本信息管理";
			this.navBarItem_GardenInfo.Name = "navBarItem_GardenInfo";
//			this.navBarItem_GardenInfo.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItem_GardenInfo.SmallImage")));
			this.navBarItem_GardenInfo.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_GardenInfo_LinkClicked);
			// 
			// navBarGroup_TeacherInfo
			// 
			this.navBarGroup_TeacherInfo.Appearance.Options.UseTextOptions = true;
			this.navBarGroup_TeacherInfo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.navBarGroup_TeacherInfo.Caption = "教师信息管理";
			this.navBarGroup_TeacherInfo.Expanded = true;
			this.navBarGroup_TeacherInfo.DragDropFlags = DevExpress.XtraNavBar.NavBarDragDrop.None;
			this.navBarGroup_TeacherInfo.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText;
			this.navBarGroup_TeacherInfo.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
																										   new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_TeaBaseInfo),
																										   new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_RealtimeInfo_Teacher),
																										   new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_TeaDutyInfo)});
//			this.navBarGroup_TeacherInfo.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup_TeacherInfo.LargeImage")));
			this.navBarGroup_TeacherInfo.Name = "navBarGroup_TeacherInfo";
			// 
			// navBarItem_TeaBaseInfo
			// 
			this.navBarItem_TeaBaseInfo.Caption = "基本信息管理";
			this.navBarItem_TeaBaseInfo.Name = "navBarItem_TeaBaseInfo";
//			this.navBarItem_TeaBaseInfo.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItem_TeaBaseInfo.SmallImage")));
			this.navBarItem_TeaBaseInfo.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_TeaBaseInfo_LinkClicked);
			// 
			// navBarItem_TeaDutyInfo
			// 
			this.navBarItem_TeaDutyInfo.Caption = "出勤信息管理";
			this.navBarItem_TeaDutyInfo.Name = "navBarItem_TeaDutyInfo";
//			this.navBarItem_TeaDutyInfo.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItem_TeaDutyInfo.SmallImage")));
			this.navBarItem_TeaDutyInfo.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_TeaDutyInfo_LinkClicked);
			// 
			// navBarGroup_StudentInfo
			// 
			this.navBarGroup_StudentInfo.Appearance.Options.UseTextOptions = true;
			this.navBarGroup_StudentInfo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.navBarGroup_StudentInfo.Caption = "学生信息管理";
			this.navBarGroup_StudentInfo.Expanded = true;
			this.navBarGroup_StudentInfo.DragDropFlags = DevExpress.XtraNavBar.NavBarDragDrop.None;
			this.navBarGroup_StudentInfo.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText;
			this.navBarGroup_StudentInfo.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
																										   new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_StuBaseInfo),
																										   new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_StuDutyInfo),
																										   new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_RealTimeInfo),
																										   new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_StuHealth),
																										   new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_StuVisit)});
//			this.navBarGroup_StudentInfo.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup_StudentInfo.LargeImage")));
			this.navBarGroup_StudentInfo.Name = "navBarGroup_StudentInfo";
			// 
			// navBarItem_StuBaseInfo
			// 
			this.navBarItem_StuBaseInfo.Caption = "基本信息管理";
			this.navBarItem_StuBaseInfo.Name = "navBarItem_StuBaseInfo";
//			this.navBarItem_StuBaseInfo.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItem_StuBaseInfo.SmallImage")));
			this.navBarItem_StuBaseInfo.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_StuBaseInfo_LinkClicked);
			// 
			// navBarItem_StuDutyInfo
			// 
			this.navBarItem_StuDutyInfo.Caption = "出勤信息管理";
			this.navBarItem_StuDutyInfo.Name = "navBarItem_StuDutyInfo";
//			this.navBarItem_StuDutyInfo.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItem_StuDutyInfo.SmallImage")));
			this.navBarItem_StuDutyInfo.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_StuDutyInfo_LinkClicked);
			// 
			// navBarItem_RealTimeInfo
			// 
			this.navBarItem_RealTimeInfo.Caption = "实时统计信息";
			this.navBarItem_RealTimeInfo.Name = "navBarItem_RealTimeInfo";
//			this.navBarItem_RealTimeInfo.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItem_RealTimeInfo.SmallImage")));
			this.navBarItem_RealTimeInfo.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_RealTimeInfo_LinkClicked);
			// 
			// navBarItem_StuHealth
			// 
			this.navBarItem_StuHealth.Caption = "健康保健管理";
			this.navBarItem_StuHealth.Name = "navBarItem_StuHealth";
//			this.navBarItem_StuHealth.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItem_StuHealth.SmallImage")));
			this.navBarItem_StuHealth.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_StuHealth_LinkClicked);
			// 
			// navBarItem_StuVisit
			// 
			this.navBarItem_StuVisit.Caption = "家访信息管理";
			this.navBarItem_StuVisit.Name = "navBarItem_StuVisit";
			this.navBarItem_StuVisit.Visible = false;
			this.navBarItem_StuVisit.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_StuVisit_LinkClicked);
			// 
			// navBarGroup_GardenAffair
			// 
			this.navBarGroup_GardenAffair.Appearance.Options.UseTextOptions = true;
			this.navBarGroup_GardenAffair.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.navBarGroup_GardenAffair.Caption = "园务辅助功能";
			this.navBarGroup_GardenAffair.Expanded = true;
			this.navBarGroup_GardenAffair.DragDropFlags = DevExpress.XtraNavBar.NavBarDragDrop.None;
			this.navBarGroup_GardenAffair.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText;
			this.navBarGroup_GardenAffair.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
																											new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_CardManagement),
																											new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_Finance),
																											new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_SMSInfo),
																											new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_AffairNotify),
                                                                                                            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_Camera)});
//			this.navBarGroup_GardenAffair.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup_GardenAffair.LargeImage")));
			this.navBarGroup_GardenAffair.Name = "navBarGroup_GardenAffair";
			// 
			// navBarItem_CardManagement
			// 
			this.navBarItem_CardManagement.Caption = "晨检卡管理";
			this.navBarItem_CardManagement.Name = "navBarItem_CardManagement";
//			this.navBarItem_CardManagement.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItem_CardManagement.SmallImage")));
			this.navBarItem_CardManagement.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_CardManagement_LinkClicked);
			// 
			// navBarItem_Finance
			// 
			this.navBarItem_Finance.Caption = "财务功能";
			this.navBarItem_Finance.Name = "navBarItem_Finance";
//			this.navBarItem_Finance.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItem_Finance.SmallImage")));
			this.navBarItem_Finance.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_Finance_LinkClicked);
			// 
			// navBarItem_SMSInfo
			// 
			this.navBarItem_SMSInfo.Caption = "短信功能";
			this.navBarItem_SMSInfo.Name = "navBarItem_SMSInfo";
//			this.navBarItem_SMSInfo.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItem_SMSInfo.SmallImage")));
			this.navBarItem_SMSInfo.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_SMSInfo_LinkClicked);
			// 
			// navBarItem_AffairNotify
			// 
			this.navBarItem_AffairNotify.Caption = "事务提醒功能";
			this.navBarItem_AffairNotify.Name = "navBarItem_AffairNotify";
//			this.navBarItem_AffairNotify.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItem_AffairNotify.SmallImage")));
			this.navBarItem_AffairNotify.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_AffairNotify_LinkClicked);
            // 
            // navBarItem_Camera
            // 
            this.navBarItem_Camera.Caption = "摄像监控";
            this.navBarItem_Camera.Name = "navBarItem_Camera";
            //			this.navBarItem_AffairNotify.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItem_AffairNotify.SmallImage")));
            this.navBarItem_Camera.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_Camera_LinkClicked);

			// 
			// splitterControlMain
			// 
			this.splitterControlMain.Location = new System.Drawing.Point(200, 52);
			this.splitterControlMain.Name = "splitterControlMain";
			this.splitterControlMain.Size = new System.Drawing.Size(4, 559);
			this.splitterControlMain.TabIndex = 8;
			this.splitterControlMain.TabStop = false;
			// 
			// paneCaption_Title
			// 
			this.paneCaption_Title.AllowActive = false;
			this.paneCaption_Title.AntiAlias = false;
			this.paneCaption_Title.Caption = "客服电话：021-58455584  021-50879915 公司网址：www.shchuangzhi.com";
			this.paneCaption_Title.Dock = System.Windows.Forms.DockStyle.Top;
			this.paneCaption_Title.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
			this.paneCaption_Title.InactiveGradientHighColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.paneCaption_Title.InactiveGradientLowColor = System.Drawing.Color.DarkGray;
			this.paneCaption_Title.Location = new System.Drawing.Point(204, 52);
			this.paneCaption_Title.Name = "paneCaption_Title";
			this.paneCaption_Title.Size = new System.Drawing.Size(728, 28);
			this.paneCaption_Title.TabIndex = 9;
			// 
			// pictureBox_BackLogo
			// 
			this.pictureBox_BackLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_BackLogo.BackgroundImage")));
			this.pictureBox_BackLogo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox_BackLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_BackLogo.Image")));
			this.pictureBox_BackLogo.Location = new System.Drawing.Point(204, 80);
			this.pictureBox_BackLogo.Name = "pictureBox_BackLogo";
			this.pictureBox_BackLogo.Size = new System.Drawing.Size(728, 531);
			this.pictureBox_BackLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox_BackLogo.TabIndex = 17;
			this.pictureBox_BackLogo.TabStop = false;
			// 
			// panelControl_Center
			// 
//			this.panelControl_Center.Controls.Add(this.gardenInfo1);
//			this.panelControl_Center.Controls.Add(this.smsInfo1);
//			this.panelControl_Center.Controls.Add(this.teacherOnDutyInfo1);
//			this.panelControl_Center.Controls.Add(this.realtimeInfo_Teacher1);
//			this.panelControl_Center.Controls.Add(this.nutritionManagement1);
//			this.panelControl_Center.Controls.Add(this.finanManagement1);
//			this.panelControl_Center.Controls.Add(this.studentVisitInfo1);
//			this.panelControl_Center.Controls.Add(this.realtimeInfo1);
//			this.panelControl_Center.Controls.Add(this.teacherBaseInfo1);
//			this.panelControl_Center.Controls.Add(this.studentBaseInfo1);
//			this.panelControl_Center.Controls.Add(this.studentMorningCheckInfo1);
//			this.panelControl_Center.Controls.Add(this.cardManagement2);
//			this.panelControl_Center.Controls.Add(this.transactionReminding1);
			this.panelControl_Center.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelControl_Center.Location = new System.Drawing.Point(204, 80);
			this.panelControl_Center.Name = "panelControl_Center";
			this.panelControl_Center.Size = new System.Drawing.Size(728, 531);
			this.panelControl_Center.TabIndex = 25;
			this.panelControl_Center.Text = "panelControlCenter";
			this.panelControl_Center.Visible = false;
			//
			//gardenInfo1
			//
//			this.gardenInfo1.Location = new System.Drawing.Point(40,40);
//			this.gardenInfo1.Name = "gardenInfo1";
//			this.gardenInfo1.Size = new System.Drawing.Size(40,40);
//			this.gardenInfo1.TabIndex = 4;
//			this.gardenInfo1.Visible = false;
			//
			//teacherOnDutyInfo1
			//
//			this.teacherOnDutyInfo1.Location = new System.Drawing.Point(30,30);
//			this.teacherOnDutyInfo1.Name = "teacherOnDutyInfo1";
//			this.teacherOnDutyInfo1.Size = new System.Drawing.Size(30,30);
//			this.teacherOnDutyInfo1.TabIndex = 3;
//			this.teacherOnDutyInfo1.Visible = false;
			//
			//smsInfo1
			//
//			this.smsInfo1.Location = new System.Drawing.Point(50,50);
//			this.smsInfo1.Name = "smsInfo1";
//			this.smsInfo1.Size = new System.Drawing.Size(50,50);
//			this.smsInfo1.TabIndex = 6;
//			this.smsInfo1.Visible = false;
//			//
//			//realtimeInfo_Teacher1
//			//
//			this.realtimeInfo_Teacher1.Location = new System.Drawing.Point(60,60);
//			this.realtimeInfo_Teacher1.Name = "realtimeInfo_Teacher1";
//			this.realtimeInfo_Teacher1.Size = new System.Drawing.Size(60,60);
//			this.realtimeInfo_Teacher1.TabIndex = 12;
//			this.realtimeInfo_Teacher1.Visible = false;
//			//
//			// nutritionManagement1
//			// 
//			this.nutritionManagement1.Location = new System.Drawing.Point(232, 336);
//			this.nutritionManagement1.Name = "nutritionManagement1";
//			this.nutritionManagement1.Size = new System.Drawing.Size(144, 128);
//			this.nutritionManagement1.TabIndex = 10;
//			this.nutritionManagement1.Visible = false;
//			// 
//			// finanManagement1
//			// 
//			this.finanManagement1.Location = new System.Drawing.Point(264, 152);
//			this.finanManagement1.Name = "finanManagement1";
//			this.finanManagement1.Size = new System.Drawing.Size(88, 56);
//			this.finanManagement1.TabIndex = 9;
//			this.finanManagement1.Visible = false;
//			// 
//			// studentVisitInfo1
//			// 
//			this.studentVisitInfo1.Location = new System.Drawing.Point(48, 160);
//			this.studentVisitInfo1.Name = "studentVisitInfo1";
//			this.studentVisitInfo1.Size = new System.Drawing.Size(136, 120);
//			this.studentVisitInfo1.TabIndex = 8;
//			// 
//			// realtimeInfo1
//			// 
//			this.realtimeInfo1.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
//			this.realtimeInfo1.Appearance.Options.UseBackColor = true;
//			this.realtimeInfo1.Location = new System.Drawing.Point(96, 88);
//			this.realtimeInfo1.Name = "realtimeInfo1";
//			this.realtimeInfo1.Size = new System.Drawing.Size(120, 48);
//			this.realtimeInfo1.TabIndex = 7;
//			this.realtimeInfo1.Visible = false;
//			// 
//			// teacherBaseInfo1
//			// 
//			this.teacherBaseInfo1.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
//			this.teacherBaseInfo1.Appearance.Options.UseBackColor = true;
//			this.teacherBaseInfo1.Location = new System.Drawing.Point(216, 32);
//			this.teacherBaseInfo1.Name = "teacherBaseInfo1";
//			this.teacherBaseInfo1.Size = new System.Drawing.Size(136, 112);
//			this.teacherBaseInfo1.TabIndex = 1;
//			this.teacherBaseInfo1.Visible = false;
//			// 
//			// studentBaseInfo1
//			// 
//			this.studentBaseInfo1.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
//			this.studentBaseInfo1.Appearance.Options.UseBackColor = true;
//			this.studentBaseInfo1.Location = new System.Drawing.Point(384, 32);
//			this.studentBaseInfo1.Name = "studentBaseInfo1";
//			this.studentBaseInfo1.Size = new System.Drawing.Size(136, 112);
//			this.studentBaseInfo1.TabIndex = 2;
//			this.studentBaseInfo1.Visible = false;
//			// 
//			// studentMorningCheckInfo1
//			// 
//			this.studentMorningCheckInfo1.BackColor = System.Drawing.Color.WhiteSmoke;
//			this.studentMorningCheckInfo1.Location = new System.Drawing.Point(48, 32);
//			this.studentMorningCheckInfo1.Name = "studentMorningCheckInfo1";
//			this.studentMorningCheckInfo1.Size = new System.Drawing.Size(136, 112);
//			this.studentMorningCheckInfo1.TabIndex = 0;
//			this.studentMorningCheckInfo1.Visible = false;
//			// 
//			// cardManagement2
//			// 
//			this.cardManagement2.Location = new System.Drawing.Point(384, 184);
//			this.cardManagement2.Name = "cardManagement2";
//			this.cardManagement2.Size = new System.Drawing.Size(136, 112);
//			this.cardManagement2.TabIndex = 5;
//			this.cardManagement2.Visible = false;
//			// 
//			// transactionReminding1
//			// 
//			this.transactionReminding1.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
//			this.transactionReminding1.Appearance.Options.UseBackColor = true;
//			this.transactionReminding1.Location = new System.Drawing.Point(96, 88);
//			this.transactionReminding1.Name = "transactionReminding1";
//			this.transactionReminding1.Size = new System.Drawing.Size(120, 250);
//			this.transactionReminding1.TabIndex = 11;
//			this.transactionReminding1.Visible = false;
			// 
			// notifyIcon_MainForm
			// 
			this.notifyIcon_MainForm.ContextMenu = this.contextMenu_NotifyIcon;
			this.notifyIcon_MainForm.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon_MainForm.Icon")));
			this.notifyIcon_MainForm.Text = "创智智能晨检网络管理系统"+SystemFramework.Util.PROJECT_VERSION;
			this.notifyIcon_MainForm.DoubleClick += new System.EventHandler(this.notifyIcon_MainForm_DoubleClick);
			// 
			// contextMenu_NotifyIcon
			// 
			this.contextMenu_NotifyIcon.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																								   this.menuItem_ShowMainForm,
																								   this.menuItem_Exit});
			// 
			// menuItem_ShowMainForm
			// 
			this.menuItem_ShowMainForm.Index = 0;
			this.menuItem_ShowMainForm.Text = "显示主窗体";
			this.menuItem_ShowMainForm.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// menuItem_Exit
			// 
			this.menuItem_Exit.Index = 1;
			this.menuItem_Exit.Text = "退出";
			this.menuItem_Exit.Click += new System.EventHandler(this.menuItem_Exit_Click);
			// 
			// navBarItem_RealtimeInfo_Teacher
			// 
			this.navBarItem_RealtimeInfo_Teacher.Caption = "实时统计信息";
			this.navBarItem_RealtimeInfo_Teacher.Name = "navBarItem_RealtimeInfo_Teacher";
			this.navBarItem_RealtimeInfo_Teacher.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_RealtimeInfo_Teacher_LinkClicked);
			// 
			// timerSynSession
			// 
			this.timerSynSession.Enabled = true;
			this.timerSynSession.Interval = 5000;
			this.timerSynSession.SynchronizingObject = this;
			this.timerSynSession.Elapsed += new System.Timers.ElapsedEventHandler(this.timerSynSession_Elapsed);
			// 
			// MainForm
			// 
			this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(952, 629);
			this.Controls.Add(this.panelControl_Center);
			this.Controls.Add(this.pictureBox_BackLogo);
			this.Controls.Add(this.paneCaption_Title);
			this.Controls.Add(this.splitterControlMain);
			this.Controls.Add(this.navBarControl_Main);
			this.Controls.Add(this.pictureBox_Border);
			this.Controls.Add(this.hideContainerRight);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlTop);
			this.Name = "创智智能晨检网络管理系统"+SystemFramework.Util.PROJECT_VERSION;
			this.Text = "创智智能晨检网络管理系统"+SystemFramework.Util.PROJECT_VERSION;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon_MainForm.Icon")));
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.timerSynSession)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.barManager_Main)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dockManager_CurrentStuCheckInfo)).EndInit();
			this.hideContainerRight.ResumeLayout(false);
			this.currentStuCheckInfo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.navBarControl_Main)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl_Center)).EndInit();
			this.panelControl_Center.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void MainForm_Load(object sender, System.EventArgs e)
		{
			//使窗体初始最大化
			pictureBox_Border.Visible = false;
			
			this.WindowState = FormWindowState.Maximized;

			if ( Thread.CurrentPrincipal.Identity.Name.ToLower() != "admin" )
				barStaticItem_SystemInfo.Caption = healthManagementSystem.GetTeaName(Thread.CurrentPrincipal.Identity.Name)
					+ " 欢迎您使用创智智能晨检网络管理系统"+SystemFramework.Util.PROJECT_VERSION;
			else
				barStaticItem_SystemInfo.Caption = "系统管理员"
					+ " 欢迎您使用创智智能晨检网络管理系统"+SystemFramework.Util.PROJECT_VERSION;
			
			barStaticItem_SystemDate.Caption = "今天是 : " + DateTime.Now.ToString("yyyy-MM-dd") 
				+ " " + DateTime.Now.ToString("dddd");

			SetMsgStatus();


			vis();
			
			this.realtimeInfo1 = new CPTT.WinUI.Panels.RealtimeInfo();
			this.realtimeInfo1.Name = "realtimeInfo1";
			
			this.panelControl_Center.Controls.Add(this.realtimeInfo1);
			realtimeInfo1.Dock = DockStyle.Fill;
			this.realtimeInfo1.Visible = true;

			navBarItem_SMSInfo.Visible = false;
		}


		#region 加载Skin名称
		string skinPrefix = "风格:";
		private void loadSkinName()
		{
			barManager_Main.ForceInitialize();
			foreach(DevExpress.Skins.SkinContainer skinCnt in DevExpress.Skins.SkinManager.Default.Skins)
			{
				BarButtonItem item = new BarButtonItem(barManager_Main,skinPrefix+skinCnt.SkinName);
				barSubItem_Style.AddItem(item);
				item.ItemClick += new ItemClickEventHandler(item_ItemClick);
			}
		}

		private void item_ItemClick(object sender, ItemClickEventArgs e)
		{
			string skinName = e.Item.Caption.Replace(skinPrefix,"");
			DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(skinName);
			barManager_Main.GetController().PaintStyleName = "Skin";

			try
			{
				userStyle.StyleName = "Skin";
				userStyle.SkinName = skinName;
				ConfigurationManager.WriteConfiguration(USERSTYLEPROFILE_CONFIG_NAME,userStyle);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message,"系统信息",MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
		}
		#endregion

		#region 更换窗体风格
		//如果上次用户选择过窗体风格则加载上次选择的风格,否则加载默认的风格
		private void loadUserStyleProfile()
		{
			try
			{
				userStyle = ConfigurationManager.GetConfiguration(USERSTYLEPROFILE_CONFIG_NAME) as UserStyle;
				string windowsStyle = userStyle.StyleName;
				string windowsSkin = userStyle.SkinName;

				if(windowsStyle.Equals("Default"))
				{
					barManager_Main.GetController().PaintStyleName = "Default";
					barManager_Main.GetController().ResetStyleDefaults();
					DevExpress.LookAndFeel.UserLookAndFeel.Default.SetDefaultStyle();
				}
				else if(windowsStyle.Equals("WindowsXP"))
				{
					barManager_Main.GetController().PaintStyleName = "WindowsXP";
					barManager_Main.GetController().ResetStyleDefaults();
					DevExpress.LookAndFeel.UserLookAndFeel.Default.SetWindowsXPStyle();
					navBarControl_Main.View = new DevExpress.XtraNavBar.ViewInfo.AdvExplorerBarViewInfoRegistrator();
				}
				else if(windowsStyle.Equals("OfficeXP"))
				{
					barManager_Main.GetController().PaintStyleName = "OfficeXP";
					barManager_Main.GetController().ResetStyleDefaults();
					DevExpress.LookAndFeel.UserLookAndFeel.Default.SetOffice2003Style();
					navBarControl_Main.View = new DevExpress.XtraNavBar.ViewInfo.Office3ViewInfoRegistrator();
				}
				else if(windowsStyle.Equals("Office2000"))
				{
					barManager_Main.GetController().PaintStyleName = "Office2000";
					barManager_Main.GetController().ResetStyleDefaults();
					DevExpress.LookAndFeel.UserLookAndFeel.Default.SetDefaultStyle();
					navBarControl_Main.View = new DevExpress.XtraNavBar.ViewInfo.BaseViewInfoRegistrator();
				}
				else if(windowsStyle.Equals("Office2003"))
				{
					barManager_Main.GetController().PaintStyleName = "Office2003";
					barManager_Main.GetController().ResetStyleDefaults();
					DevExpress.LookAndFeel.UserLookAndFeel.Default.SetOffice2003Style();
					navBarControl_Main.View = new DevExpress.XtraNavBar.ViewInfo.NavigationPaneViewInfoRegistrator();
				}
				else if(windowsStyle.Equals("Skin"))
				{
					DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(windowsSkin);
					barManager_Main.GetController().PaintStyleName = "Skin";
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message,"系统信息",MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
		}
		//应用默认样式
		private void barButtonItem_DefaultSkin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			barManager_Main.GetController().PaintStyleName = "Default";
			barManager_Main.GetController().ResetStyleDefaults();
			DevExpress.LookAndFeel.UserLookAndFeel.Default.SetDefaultStyle();

			try
			{
				userStyle.StyleName = "Default";
				userStyle.SkinName = string.Empty;
				ConfigurationManager.WriteConfiguration(USERSTYLEPROFILE_CONFIG_NAME,userStyle);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message,"系统信息",MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
		}

		//应用Windows XP样式
		private void barButtonItem_WinXPSkin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			barManager_Main.GetController().PaintStyleName = "WindowsXP";
			barManager_Main.GetController().ResetStyleDefaults();
			DevExpress.LookAndFeel.UserLookAndFeel.Default.SetWindowsXPStyle();
			navBarControl_Main.View = new DevExpress.XtraNavBar.ViewInfo.AdvExplorerBarViewInfoRegistrator();

			try
			{
				userStyle.StyleName = "WindowsXP";
				userStyle.SkinName = string.Empty;
				ConfigurationManager.WriteConfiguration(USERSTYLEPROFILE_CONFIG_NAME,userStyle);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message,"系统信息",MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
		}

		//应用Office XP样式
		private void barButtonItem_OfficeXP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			barManager_Main.GetController().PaintStyleName = "OfficeXP";
			barManager_Main.GetController().ResetStyleDefaults();
			DevExpress.LookAndFeel.UserLookAndFeel.Default.SetOffice2003Style();
			navBarControl_Main.View = new DevExpress.XtraNavBar.ViewInfo.Office3ViewInfoRegistrator();

			try
			{
				userStyle.StyleName = "OfficeXP";
				userStyle.SkinName = string.Empty;
				ConfigurationManager.WriteConfiguration(USERSTYLEPROFILE_CONFIG_NAME,userStyle);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message,"系统信息",MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}			
		}

		//应用Office 2000样式
		private void barButtonItem_Office2000_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			barManager_Main.GetController().PaintStyleName = "Office2000";
			barManager_Main.GetController().ResetStyleDefaults();
			DevExpress.LookAndFeel.UserLookAndFeel.Default.SetDefaultStyle();
			navBarControl_Main.View = new DevExpress.XtraNavBar.ViewInfo.BaseViewInfoRegistrator();

			try
			{
				userStyle.StyleName = "Office2000";
				userStyle.SkinName = string.Empty;
				ConfigurationManager.WriteConfiguration(USERSTYLEPROFILE_CONFIG_NAME,userStyle);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message,"系统信息",MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
		}

		//应用Office 2003样式
		private void barButtonItem_Office2003_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			barManager_Main.GetController().PaintStyleName = "Office2003";
			barManager_Main.GetController().ResetStyleDefaults();
			DevExpress.LookAndFeel.UserLookAndFeel.Default.SetOffice2003Style();
			navBarControl_Main.View = new DevExpress.XtraNavBar.ViewInfo.NavigationPaneViewInfoRegistrator();

			try
			{
				userStyle.StyleName = "Office2003";
				userStyle.SkinName = string.Empty;
				ConfigurationManager.WriteConfiguration(USERSTYLEPROFILE_CONFIG_NAME,userStyle);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message,"系统信息",MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
		}
		#endregion

		//随着选取Link的改变更改Title标题
		private void navBarControl_Main_HotTrackedLinkChanged(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			if(e.Link!=null)
			{
				barStaticItem_Ready.Caption = e.Link.Caption;
			}
		}

		//随着选取Link的改变更改状态栏信息显示
		private void navBarControl_Main_MouseLeave(object sender, System.EventArgs e)
		{
			barStaticItem_Ready.Caption = "就绪";
		}

		//根据权限设置菜单显示
		private void MenuDisplayByRole()
		{
			//园所信息
			if(!Thread.CurrentPrincipal.IsInRole("园长")
				&&Thread.CurrentPrincipal.Identity.Name.ToLower()!="admin")
			{
				navBarGroup_GardenInfo.Visible=false;
			}

			//教师实时统计
			if(!Thread.CurrentPrincipal.IsInRole("园长")
				&&Thread.CurrentPrincipal.Identity.Name.ToLower()!="admin")
			{
				navBarItem_RealtimeInfo_Teacher.Visible=false;
			}

			//学生基本信息
			if(!Thread.CurrentPrincipal.IsInRole("园长")
				&&!Thread.CurrentPrincipal.IsInRole("班主任")
				&&!Thread.CurrentPrincipal.IsInRole("保健")
				&&!Thread.CurrentPrincipal.IsInRole("财务")
				&&Thread.CurrentPrincipal.Identity.Name.ToLower()!="admin")
			{
				navBarItem_StuBaseInfo.Visible=false;
			}

			//学生健康保健信息
			if(!Thread.CurrentPrincipal.IsInRole("园长")
				&&!Thread.CurrentPrincipal.IsInRole("班主任")
				&&!Thread.CurrentPrincipal.IsInRole("保健")
				&&Thread.CurrentPrincipal.Identity.Name.ToLower()!="admin")
			{
				navBarItem_StuHealth.Visible=false;
			}

			//学生家访信息
			if(!Thread.CurrentPrincipal.IsInRole("园长")
				&&!Thread.CurrentPrincipal.IsInRole("班主任")
				&&!Thread.CurrentPrincipal.IsInRole("保健")
				&&Thread.CurrentPrincipal.Identity.Name.ToLower()!="admin")
			{
				navBarItem_StuVisit.Visible=false;
			}

			//卡信息
			if(!Thread.CurrentPrincipal.IsInRole("园长")
				&&!Thread.CurrentPrincipal.IsInRole("保健")
				&&!Thread.CurrentPrincipal.IsInRole("财务")
				&&Thread.CurrentPrincipal.Identity.Name.ToLower()!="admin")
			{
				navBarItem_CardManagement.Visible=false;
			}

			//简单财务管理
			if(!Thread.CurrentPrincipal.IsInRole("财务")
				&&!Thread.CurrentPrincipal.IsInRole("园长")
				&&Thread.CurrentPrincipal.Identity.Name.ToLower()!="admin")
			{
				navBarItem_Finance.Visible=false;
			}

			//短信信息
			if(!Thread.CurrentPrincipal.IsInRole("园长")
				&&!Thread.CurrentPrincipal.IsInRole("班主任")
				&&!Thread.CurrentPrincipal.IsInRole("保健"))
			{
				navBarItem_SMSInfo.Visible=false;
			}

			//事务提醒
			if(!Thread.CurrentPrincipal.IsInRole("园长")
				&&!Thread.CurrentPrincipal.IsInRole("一般")
				&&!Thread.CurrentPrincipal.IsInRole("班主任")
				&&!Thread.CurrentPrincipal.IsInRole("保健")
				&&!Thread.CurrentPrincipal.IsInRole("财务"))
			{
				navBarItem_AffairNotify.Visible=false;
			}

			//KGManager
			if(Thread.CurrentPrincipal.Identity.Name.ToLower() != "admin")
			{
				barButtonItem1.Visibility = BarItemVisibility.Never;
			}

			if(Thread.CurrentPrincipal.Identity.Name.ToLower() != "admin" && !Thread.CurrentPrincipal.IsInRole("园长") && !Thread.CurrentPrincipal.IsInRole("保健"))
			{
				barButtonItem_CustomDefine.Visibility = BarItemVisibility.Never;
			}
		}

		public void vis()
		{
			pictureBox_BackLogo.Visible = false;

			gardenInfo1 = null;
			teacherBaseInfo1 = null;
			teacherOnDutyInfo1 = null;
			studentBaseInfo1 = null;
			studentMorningCheckInfo1 = null;
			cardManagement2 = null;
			smsInfo1 = null;
			realtimeInfo1 = null;
			studentVisitInfo1 = null;
			finanManagement1 = null;
			finanManagement2 = null;
			nutritionManagement1 = null;
			transactionReminding1 = null;
			realtimeInfo_Teacher1 = null;

			GC.Collect();
            
			panelControl_Center.Controls.Clear();
			panelControl_Center.Visible = true;
		}

		private void navBarItem_GardenInfo_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			vis();
			this.gardenInfo1 = new CPTT.WinUI.Panels.GardenInfo();
			this.gardenInfo1.Name = "gardenInfo1";
			this.panelControl_Center.Controls.Add(this.gardenInfo1);
			gardenInfo1.Dock = DockStyle.Fill;
			gardenInfo1.Visible = true;
		}

		private void navBarItem_TeaBaseInfo_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			vis();
			this.teacherBaseInfo1 = new CPTT.WinUI.Panels.TeacherBaseInfo();
			this.teacherBaseInfo1.Name = "teacherBaseInfo1";
			this.panelControl_Center.Controls.Add(this.teacherBaseInfo1);
			teacherBaseInfo1.Dock = DockStyle.Fill;
			teacherBaseInfo1.Visible = true;
		}

		private void navBarItem_RealtimeInfo_Teacher_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			vis();
			
			this.realtimeInfo_Teacher1 = new CPTT.WinUI.Panels.RealtimeInfo_Teacher();
			this.realtimeInfo_Teacher1.Name = "realtimeInfo_Teacher1";
			this.panelControl_Center.Controls.Add(this.realtimeInfo_Teacher1);
			
			realtimeInfo_Teacher1.Visible = true;
		}

		private void navBarItem_TeaDutyInfo_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			vis();

			this.teacherOnDutyInfo1 = new CPTT.WinUI.Panels.TeacherOnDutyInfo();
			this.teacherOnDutyInfo1.Name = "teacherOnDutyInfo1";
			this.panelControl_Center.Controls.Add(this.teacherOnDutyInfo1);
			teacherOnDutyInfo1.Dock = DockStyle.Fill;
			this.teacherOnDutyInfo1.Visible = true;

		}

		private void navBarItem_RealTimeInfo_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			vis();
			
			this.realtimeInfo1 = new CPTT.WinUI.Panels.RealtimeInfo();
			this.realtimeInfo1.Name = "realtimeInfo1";
			
			this.panelControl_Center.Controls.Add(this.realtimeInfo1);
			realtimeInfo1.Dock = DockStyle.Fill;
			this.realtimeInfo1.Visible = true;
		}

		private void navBarItem_StuHealth_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			vis();

			this.nutritionManagement1 = new CPTT.WinUI.Panels.NutritionManagement();
			this.nutritionManagement1.Name = "nutritionManagement1";
			
			this.panelControl_Center.Controls.Add(this.nutritionManagement1);
			nutritionManagement1.Dock = DockStyle.Fill;
			this.nutritionManagement1.Visible = true;

//			MessageBox.Show("该版本是精简版，您无法使用该功能！",
//				"系统信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		private void navBarItem_StuBaseInfo_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			vis();

			this.studentBaseInfo1 = new CPTT.WinUI.Panels.StudentBaseInfo();
			this.studentBaseInfo1.Name = "studentBaseInfo1";
			
			this.panelControl_Center.Controls.Add(this.studentBaseInfo1);
			studentBaseInfo1.Dock = DockStyle.Fill;
			this.studentBaseInfo1.Visible = true;
		}

		private void navBarItem_StuDutyInfo_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			vis();

			this.studentMorningCheckInfo1 = new CPTT.WinUI.Panels.StudentMorningCheckInfo();
			this.studentMorningCheckInfo1.Name = "studentMorningCheckInfo1";
			
			this.panelControl_Center.Controls.Add(this.studentMorningCheckInfo1);
			studentMorningCheckInfo1.Dock = DockStyle.Fill;
			this.studentMorningCheckInfo1.Visible = true;
		}

		private void navBarItem_CardManagement_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			vis();

			this.cardManagement2 = new CPTT.WinUI.Panels.CardManagement();
			this.cardManagement2.Name = "cardManagement2";
			
			this.panelControl_Center.Controls.Add(this.cardManagement2);
			cardManagement2.Dock = DockStyle.Fill;
			this.cardManagement2.Visible = true;

//			MessageBox.Show("该版本是演示，您无法使用该功能！",
//				"系统信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		private void navBarItem_Finance_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			vis();

//			this.finanManagement1 = new CPTT.WinUI.Panels.FinanManagement();
//			this.finanManagement1.Name = "finanManagement1";

			this.finanManagement2 = new CPTT.WinUI.Panels.FinanManagement2();
			this.finanManagement2.Name = "finanManagement2";
			
//			this.panelControl_Center.Controls.Add(this.finanManagement1);
			this.panelControl_Center.Controls.Add(this.finanManagement2);
			//finanManagement1.Dock = DockStyle.Fill;
			this.finanManagement2.Visible = true;

//			finanManagement1.Dock = DockStyle.Fill;
//			this.finanManagement1.Visible = true;

//			MessageBox.Show("该版本是精简版，您无法使用该功能！",
//				"系统信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		private void navBarItem_SMSInfo_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			vis();

			this.smsInfo1 = new CPTT.WinUI.Panels.SmsInfo();
			this.smsInfo1.Name = "smsInfo1";
			
			this.panelControl_Center.Controls.Add(this.smsInfo1);
			smsInfo1.Dock = DockStyle.Fill;
			this.smsInfo1.Visible = true;
//
//			MessageBox.Show("该版本是精简版，您无法使用该功能！",
//				"系统信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		private void navBarItem_StuVisit_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			vis();

			this.studentVisitInfo1 = new CPTT.WinUI.Panels.StudentVisitInfo();
			this.studentVisitInfo1.Name = "studentVisitInfo1";
			
			this.panelControl_Center.Controls.Add(this.studentVisitInfo1);
			studentVisitInfo1.Dock = DockStyle.Fill;
			this.studentVisitInfo1.Visible = true;

//			MessageBox.Show("该版本是精简版，您无法使用该功能！",
//				"系统信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		private void navBarItem_AffairNotify_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			vis();

			this.transactionReminding1 = new CPTT.WinUI.Panels.TransactionReminding();
			this.transactionReminding1.Name = "transactionReminding1";
			
			this.panelControl_Center.Controls.Add(this.transactionReminding1);
			transactionReminding1.Dock = DockStyle.Fill;
			this.transactionReminding1.Visible = true;

//			MessageBox.Show("该版本是精简版，您无法使用该功能！",
//				"系统信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

        private void navBarItem_Camera_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            vis();
            this.panelControl_Center.Controls.Add(this.cameraPanel);
            this.cameraPanel.OnLoad();
            this.cameraPanel.Name = "Camera";
            this.cameraPanel.Dock = DockStyle.Fill;
            this.cameraPanel.Visible = true;
            //vis();

            //this.transactionReminding1 = new CPTT.WinUI.Panels.TransactionReminding();
            //this.transactionReminding1.Name = "transactionReminding1";

            //this.panelControl_Center.Controls.Add(this.transactionReminding1);
            //transactionReminding1.Dock = DockStyle.Fill;
            //this.transactionReminding1.Visible = true;

            //			MessageBox.Show("该版本是精简版，您无法使用该功能！",
            //				"系统信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

		//显示自定义信息维护窗口
		private void barButtonItem_CustomDefine_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			Login login = (Login)(this.Owner);
			CustomInfoDefine customInfoDefine = new CustomInfoDefine(login);
			customInfoDefine.StartPosition = FormStartPosition.CenterScreen;
			customInfoDefine.ShowDialog();
		}

		//显示选项卡
		private void barButtonItem_Options_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			Login login = (Login)(this.Owner);
			OptionsForm optionsForm = new OptionsForm(login);
			optionsForm.StartPosition = FormStartPosition.CenterScreen;
			optionsForm.ShowDialog();
		}

		private void timerSynSession_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			if ( utilSystem.IsSessionClient(Thread.CurrentPrincipal.Identity.Name) )
			{
				utilSystem.UpdateSessionClient(Thread.CurrentPrincipal.Identity.Name);
			}
			else 
			{
				timerSynSession.Enabled = false;
				MessageBox.Show("当前用户会话状态已处于断开状态，系统即将关闭！");
				
				this.Owner.Close();
				this.Close();
				Application.DoEvents();
				Application.Exit();

				utilSystem.DeleteSessionClient(CPTT.SystemFramework.Util.MacAddress);

				return;
			}

			if ( utilSystem.GetCurrentClients() > CPTT.SystemFramework.Util.MaxClients )
			{
				timerSynSession.Enabled = false;
				MessageBox.Show("系统检测到当前数据服务产生异常，为保护数据安全，系统即将关闭！");
				
				this.Owner.Close();
				this.Close();
				Application.DoEvents();
				Application.Exit();

				utilSystem.DeleteSessionClient(CPTT.SystemFramework.Util.MacAddress);

				return;
			}
		}

		private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
            this.cameraPanel.OnClose();

			utilSystem.DeleteSessionClient(CPTT.SystemFramework.Util.MacAddress);

			//关闭整个程序
			this.Owner.Close();
			Application.DoEvents();
			Application.Exit();
		}

		//调整实时晨检信息窗口,如果没有则显示如果有则隐藏
		private void barButtonItem_DutyInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{	

			if(MORNINGCHECK_WINDOWS_SHOW)
			{
				currentStuCheckInfo.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
				MORNINGCHECK_WINDOWS_SHOW = false;
//				studentMorningCheckInfo1.Refresh();
			}
			else
			{
				currentStuCheckInfo.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
				MORNINGCHECK_WINDOWS_SHOW = true;
//				studentMorningCheckInfo1.Refresh();
			}
		}

		//退出系统
		private void barButtonItem_Exit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			utilSystem.DeleteSessionClient(CPTT.SystemFramework.Util.MacAddress);

			this.Owner.Close();
			this.Close();
			Application.DoEvents();
			Application.Exit();
		}

		//注销系统
		private void barButtonItem_Logout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			Login login = (Login)(this.Owner);
			login.simpleButton_Login.Enabled = true;
			//login.Opacity = 0.0;
			//login.formShowing = true;
			//login.fadeTimer.Enabled = true;
			login.Visible = true;
			this.Visible = false;
		}

		
		//最小化到Notify窗口
		private void MainForm_Resize(object sender, System.EventArgs e)
		{
			if(this.WindowState == FormWindowState.Minimized)
			{
				this.Visible = false;
				notifyIcon_MainForm.Visible = true;
			}
		}

		//点击NotifyIcon显示主窗体
		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			this.Visible = true;
			this.WindowState = FormWindowState.Maximized;
			this.MaximizeBox = true;
			this.MaximizeBox = false;
			notifyIcon_MainForm.Visible = false;
		}

		//点击NotifyIcon退出整个程序
		private void menuItem_Exit_Click(object sender, System.EventArgs e)
		{
			utilSystem.DeleteSessionClient(CPTT.SystemFramework.Util.MacAddress);

			this.Owner.Close();
			this.Close();
			Application.DoEvents();
			Application.Exit();
		}

		//双击NotifyIcon显示主窗体
		private void notifyIcon_MainForm_DoubleClick(object sender, System.EventArgs e)
		{
			this.Visible = true;
			this.WindowState = FormWindowState.Maximized;
			this.MaximizeBox = true;
			this.MaximizeBox = false;
			notifyIcon_MainForm.Visible = false;
		}

		//显示Kgmanager
		private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			Login login = (Login)(this.Owner);
			KgManager kgManager = new KgManager(login);
			kgManager.StartPosition = FormStartPosition.CenterScreen;
			kgManager.ShowDialog();
		}

		//help
		private void barButtonItem_Help_ItemClick(object sender, ItemClickEventArgs e)
		{	
			System.Diagnostics.Process.Start(Path.GetDirectoryName(Application.ExecutablePath)
				+@"\\创智智能晨检网络管理系统（第四代）联机丛书.chm");
		}

		//about
		private void barButtonItem_About_ItemClick(object sender, ItemClickEventArgs e)
		{
			AboutForm about = new AboutForm();
			about.StartPosition = FormStartPosition.CenterScreen;
			about.ShowDialog();
		}

		public void SetMsgStatus()
		{
			int getMsgNumbers = new TransactionSystem().GetMsgNumbers(Thread.CurrentPrincipal.Identity.Name);

			if ( getMsgNumbers > 0 )
			{
				barStaticItem_Custom.Caption = "您的信箱里有"+getMsgNumbers+"条未读信息，请收阅！";
				barStatus.Appearance.ForeColor = System.Drawing.Color.Red;
			}
			else
			{
				barStaticItem_Custom.Caption = "";
				barStatus.Appearance.ForeColor = System.Drawing.Color.Black;
			}
		}
	}
}

