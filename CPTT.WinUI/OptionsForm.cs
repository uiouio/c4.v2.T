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
using System.Linq;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Xml;
using System.Threading;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using CPTT.SystemFramework;
using CPTT.BusinessFacade;
using Microsoft.Practices.EnterpriseLibrary.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
using System.Threading;
using System.Dynamic;
using CameraLib;

namespace CPTT.WinUI
{
	/// <summary>
	/// Summary description for OptionsForm.
	/// </summary>
	public class OptionsForm : DevExpress.XtraEditors.XtraForm
	{
		private DevExpress.XtraTab.XtraTabControl xtraTabControl_Options;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage_ComPortSet;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage_AutoShutDown;
        private IContainer components;

		internal const string USERSTYLEPROFILE_CONFIG_NAME = "UserStyleProfile";
		private DevExpress.XtraEditors.GroupControl groupControl_ComPortSet;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton4;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private DevExpress.XtraEditors.GroupControl groupControl2;
		private DevExpress.XtraEditors.SimpleButton simpleButton3;
		private DevExpress.Utils.Frames.NotePanel notePanel2;
		private DevExpress.Utils.Frames.NotePanel notePanel_ShutDownTime;
		private DevExpress.XtraEditors.TimeEdit timeEdit_DutyStartTime;
		private DevExpress.XtraEditors.CheckEdit checkEdit1;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage_AutoSendSmsTimeSet;
		private DevExpress.XtraEditors.GroupControl groupControl3;
		private DevExpress.Utils.Frames.NotePanel notePanel3;
		private DevExpress.XtraEditors.SimpleButton simpleButton4;
		private DevExpress.Utils.Frames.NotePanel notePanel4;
		private DevExpress.Utils.Frames.NotePanel notePanel5;
		private DevExpress.Utils.Frames.NotePanel notePanel6;
		private DevExpress.XtraEditors.SimpleButton simpleButton5;
		private UserStyle userStyle;
		private ArrayList settings;
		private bool isAutoShutDown;
		private DateTime shutDownTime;
		private DevExpress.XtraEditors.SimpleButton simpleButton6;
		private DevExpress.XtraEditors.SimpleButton simpleButton7;
		private DevExpress.XtraEditors.CheckEdit checkEdit2;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
		private DevExpress.XtraEditors.GroupControl groupControl4;
		private DevExpress.Utils.Frames.NotePanel notePanel1;
		private DevExpress.XtraEditors.SimpleButton simpleButton8;
		private DevExpress.Utils.Frames.NotePanel notePanel7;
		private DevExpress.XtraEditors.SimpleButton simpleButton9;
		private DevExpress.XtraEditors.TextEdit textEdit_NewPwd;
		private DevExpress.XtraEditors.TextEdit textEdit_ConfirmPwd;
		private DevExpress.Utils.Frames.NotePanel notePanel8;
		private DevExpress.XtraEditors.TextEdit textEdit_OldPwd;
		private DevExpress.XtraEditors.TimeEdit timeEdit_SMSMorningTime;
		private DevExpress.XtraEditors.TimeEdit timeEdit_SMSNightTime;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		private DevExpress.XtraEditors.SimpleButton simpleButton10;
		private DevExpress.XtraEditors.TextEdit textEdit_UpdateAddress;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
		private DevExpress.XtraEditors.GroupControl groupControl5;
		private DevExpress.XtraEditors.SimpleButton simpleButton11;
		private DevExpress.XtraEditors.SimpleButton simpleButton12;
		private DevExpress.XtraEditors.TextEdit textEdit_DBUser;
		private DevExpress.Utils.Frames.NotePanel notePanel9;
		private DevExpress.Utils.Frames.NotePanel notePanel10;
		private DevExpress.XtraEditors.TextEdit textEdit_DBPwd;
		private DevExpress.Utils.Frames.NotePanel notePanel11;
		private DevExpress.XtraEditors.TextEdit textEdit_DBName;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
		private DevExpress.XtraEditors.GroupControl groupControl6;
		private DevExpress.XtraEditors.GroupControl groupControl7;
		private DevExpress.XtraEditors.GroupControl groupControl8;
		private DevExpress.Utils.Frames.NotePanel notePanel_BatchCreate_Grade;
		private DevExpress.Utils.Frames.NotePanel notePanel_BatchCreate_Class;
		private DevExpress.Utils.Frames.NotePanel notePanel_BatchCreate_Name;
		private DevExpress.Utils.Frames.NotePanel notePanel_BatchCreate_Number;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_BatchCreate_Grade;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_BatchCreate_Class;
		private DevExpress.XtraEditors.TextEdit textEdit_BatchCreate_Name;
		private DevExpress.XtraEditors.TextEdit textEdit_BatchCreate_Number;
		private DevExpress.Utils.Frames.NotePanel notePanel_BatchCreate_Type;
		private DevExpress.Utils.Frames.NotePanel notePanel_BatchCreate_Load;
		private DevExpress.Utils.Frames.NotePanel notePanel_BatchCreate_ClassNumbers;
		private DevExpress.Utils.Frames.NotePanel notePanel_BatchCreate_TerminalNumbers;
		private DevExpress.Utils.Frames.NotePanel notePanel_ClassVol;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_BatchCreate_Type;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_BatchCreate_Load;
		private DevExpress.XtraEditors.TextEdit textEdit_BatchCreate_ClassNumbers;
		private DevExpress.XtraEditors.TextEdit textEdit_BatchCreate_TerminalNumbers;
		private DevExpress.XtraEditors.TextEdit textEdit_ClassVol;
		private DevExpress.XtraGrid.GridControl gridControl_BatchCreate_Grade;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraBars.BarManager barManager1;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
		private DevExpress.XtraBars.PopupMenu popupMenu1;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage_BatchCreate;
		private Login loginForm;
		private string getGradeNumberFromCombo = "";
		private string getClassNumberFromCombo = "";
		private string getName = "";
		private string getSelNumber = "";
		private string getCardNumber = "";
		private bool isForStu  = false;
		private OptionSystem optionSystem;
		private Option option;

		private DevExpress.Utils.Frames.NotePanel notePanel_BatchCreate_CardNumber;
		private DevExpress.XtraEditors.TextEdit textEdit_BatchCreate_CardNumber;
		private DevExpress.XtraGrid.GridControl gridControl_BatchCreate_Class;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraGrid.GridControl gridControl_BatchCreate_StuBasicInfo;
		private DevExpress.XtraGrid.GridControl gridControl_BatchCreate_StuCard;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
		private DevExpress.XtraGrid.GridControl gridControl1_BatchCreate_TeaBasicInfo;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
		private DevExpress.XtraGrid.GridControl gridControl_BatchCreate_TeaCard;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn30;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn32;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn34;
		private DevExpress.XtraGrid.GridControl gridControl_BatchCreate_Machine;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn36;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn37;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_Refresh;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_Modify;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_Delete;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn38;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn39;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn40;
		private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView advBandedGridView1;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn9;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn10;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn11;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn12;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn13;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn14;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn15;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn16;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn17;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn41;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn42;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn43;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn44;
		private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn45;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn46;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn47;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn48;
		private System.Windows.Forms.OpenFileDialog openFileDialog_LoadStuInfoXLS;
		private DevExpress.XtraBars.BarButtonItem barButtonItem1;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_Add;
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_Save;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage_UpdateGrade;
		private DevExpress.XtraEditors.SplitterControl splitterControl1;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
		private DevExpress.XtraEditors.GroupControl groupControl9;
		private DevExpress.Utils.Frames.NotePanel notePanel_SrcGrade;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_SrcGrade;
		private DevExpress.Utils.Frames.NotePanel notePanel_DestGrade;
		private DevExpress.XtraEditors.TextEdit textEdit_DestGrade;
		private DevExpress.XtraEditors.TextEdit textEdit_DestClass;
		private DevExpress.Utils.Frames.NotePanel notePanel_DestClass;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_SrcClass;
		private DevExpress.Utils.Frames.NotePanel notePanel_SrcClass;
		private DevExpress.Utils.Frames.NotePanel notePanel12;
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private DevExpress.XtraEditors.GroupControl groupControl10;
		private DevExpress.XtraGrid.GridControl gridControl_StudentAdjust;
		private DevExpress.Utils.Frames.NotePanel notePanel13;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn49;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn51;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn54;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn55;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn56;
		private DevExpress.XtraEditors.SimpleButton simpleButton_LoadTable;
		private DevExpress.XtraEditors.SimpleButton simpleButton_Submit;
		private DevExpress.Utils.Frames.NotePanel notePanel_GradeNumber;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_GradeNumber;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_ClassNumber;
		private DevExpress.Utils.Frames.NotePanel notePanel_ClassNumber;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage_TerminalServ;
		private DevExpress.XtraBars.PopupMenu popupMenu2;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_DeleteSession;
		private DevExpress.XtraGrid.GridControl gridControl_SessionUser;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView8;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView9;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn50;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn52;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn53;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn57;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
		private DevExpress.XtraEditors.GroupControl groupControl11;
		private DevExpress.XtraEditors.SimpleButton smbRoot;
		private System.Windows.Forms.TextBox tbxBackUpRoot;
		private DevExpress.XtraEditors.GroupControl groupControl12;
		private DevExpress.XtraEditors.SimpleButton smbBackUp;
		private System.Windows.Forms.SaveFileDialog saveFileDialog_createbackup;
		private System.Windows.Forms.SaveFileDialog saveFileDialog_BatchCreate;
		private System.Windows.Forms.RadioButton rbtStart;
		private System.Windows.Forms.RadioButton rbtIdle;
		private System.Windows.Forms.RadioButton rbtDefault;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage5;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox tbxUploadUrl;

		private Hashtable htUpdateInfo = new Hashtable();
        private DevExpress.XtraTab.XtraTabPage xtraTabPage6;
        private GroupControl groupControl13;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn58;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn59;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn60;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn61;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn62;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn63;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn64;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox4;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit3;

        private static System.Threading.Timer backupTimer = new System.Threading.Timer(DoBackupPeriodically, null, 60  * 1000, Timeout.Infinite);

		public OptionsForm(Login loginForm)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			option = new Option();

			if(!Thread.CurrentPrincipal.IsInRole("园长")
				&&!Thread.CurrentPrincipal.IsInRole("保健")
				&&Thread.CurrentPrincipal.Identity.Name.ToLower() != "admin")
			{
				xtraTabPage_ComPortSet.PageVisible = false;
			}

			if(Thread.CurrentPrincipal.Identity.Name.ToLower() != "admin")
			{
				xtraTabPage_AutoSendSmsTimeSet.PageVisible = false;
			}

			if(Thread.CurrentPrincipal.Identity.Name.ToLower() != "admin")
			{
				xtraTabPage2.PageVisible = false;
			}

			if(Thread.CurrentPrincipal.Identity.Name.ToLower() != "admin")
			{
				xtraTabPage3.PageVisible = false;
			}

			if(Thread.CurrentPrincipal.Identity.Name.ToLower() != "admin")
			{
				xtraTabPage_BatchCreate.PageVisible = false;
			}

			if(!Thread.CurrentPrincipal.IsInRole("园长")
				&&Thread.CurrentPrincipal.Identity.Name.ToLower()!="admin")
			{
				xtraTabPage_TerminalServ.PageVisible = false;
			}

			if(!Thread.CurrentPrincipal.IsInRole("园长")
				&&Thread.CurrentPrincipal.Identity.Name.ToLower()!="admin")
			{
				xtraTabPage4.PageVisible = false;
			}

			if (Thread.CurrentPrincipal.Identity.Name.ToLower() != "admin")
			{
				comboBoxEdit_BatchCreate_Load.Properties.Items.Remove("学生信息表(复杂)");
			}

			loadUserStyleProfile();
			this.loginForm = loginForm;
            


			this.tbxUploadUrl.Text = "http://xdd.xindoudou.cn/2/partner/sync";

			optionSystem = new OptionSystem();

            gridControl1.DataSource = new CameraSystem().GetCameraInfo();
            var machineSet = new MachineSystem().GetMachineAddrList();
            if (machineSet != null && machineSet.Tables.Count >= 1)
            {
                foreach (DataRow item in machineSet.Tables[0].Rows)
                {
                    repositoryItemComboBox4.Items.Add(string.Format("{0}号门口机", item["machine_address"]));
                }
            }
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.xtraTabControl_Options = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.textEdit_DBUser = new DevExpress.XtraEditors.TextEdit();
            this.notePanel9 = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel10 = new DevExpress.Utils.Frames.NotePanel();
            this.textEdit_DBPwd = new DevExpress.XtraEditors.TextEdit();
            this.notePanel11 = new DevExpress.Utils.Frames.NotePanel();
            this.textEdit_DBName = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton11 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton12 = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPage_ComPortSet = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl_ComPortSet = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.simpleButton6 = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPage_AutoShutDown = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.timeEdit_DutyStartTime = new DevExpress.XtraEditors.TimeEdit();
            this.notePanel_ShutDownTime = new DevExpress.Utils.Frames.NotePanel();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
            this.notePanel2 = new DevExpress.Utils.Frames.NotePanel();
            this.xtraTabPage_AutoSendSmsTimeSet = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.timeEdit_SMSMorningTime = new DevExpress.XtraEditors.TimeEdit();
            this.notePanel3 = new DevExpress.Utils.Frames.NotePanel();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.notePanel5 = new DevExpress.Utils.Frames.NotePanel();
            this.timeEdit_SMSNightTime = new DevExpress.XtraEditors.TimeEdit();
            this.notePanel6 = new DevExpress.Utils.Frames.NotePanel();
            this.simpleButton7 = new DevExpress.XtraEditors.SimpleButton();
            this.notePanel4 = new DevExpress.Utils.Frames.NotePanel();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.textEdit_NewPwd = new DevExpress.XtraEditors.TextEdit();
            this.notePanel1 = new DevExpress.Utils.Frames.NotePanel();
            this.simpleButton8 = new DevExpress.XtraEditors.SimpleButton();
            this.notePanel7 = new DevExpress.Utils.Frames.NotePanel();
            this.simpleButton9 = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit_ConfirmPwd = new DevExpress.XtraEditors.TextEdit();
            this.notePanel8 = new DevExpress.Utils.Frames.NotePanel();
            this.textEdit_OldPwd = new DevExpress.XtraEditors.TextEdit();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.textEdit_UpdateAddress = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton10 = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPage_BatchCreate = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl8 = new DevExpress.XtraEditors.GroupControl();
            this.textEdit_ClassVol = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_BatchCreate_TerminalNumbers = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_BatchCreate_ClassNumbers = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_ClassVol = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_BatchCreate_TerminalNumbers = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_BatchCreate_ClassNumbers = new DevExpress.Utils.Frames.NotePanel();
            this.groupControl6 = new DevExpress.XtraEditors.GroupControl();
            this.textEdit_BatchCreate_CardNumber = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_BatchCreate_CardNumber = new DevExpress.Utils.Frames.NotePanel();
            this.comboBoxEdit_BatchCreate_Load = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEdit_BatchCreate_Type = new DevExpress.XtraEditors.ComboBoxEdit();
            this.textEdit_BatchCreate_Number = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_BatchCreate_Name = new DevExpress.XtraEditors.TextEdit();
            this.comboBoxEdit_BatchCreate_Class = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEdit_BatchCreate_Grade = new DevExpress.XtraEditors.ComboBoxEdit();
            this.notePanel_BatchCreate_Load = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_BatchCreate_Type = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_BatchCreate_Number = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_BatchCreate_Name = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_BatchCreate_Class = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_BatchCreate_Grade = new DevExpress.Utils.Frames.NotePanel();
            this.groupControl7 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_BatchCreate_Machine = new DevExpress.XtraGrid.GridControl();
            this.gridView7 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn48 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn47 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridControl_BatchCreate_TeaCard = new DevExpress.XtraGrid.GridControl();
            this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn34 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn46 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1_BatchCreate_TeaBasicInfo = new DevExpress.XtraGrid.GridControl();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl_BatchCreate_StuCard = new DevExpress.XtraGrid.GridControl();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn45 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl_BatchCreate_StuBasicInfo = new DevExpress.XtraGrid.GridControl();
            this.advBandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColumn10 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn41 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn44 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn42 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn43 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridControl_BatchCreate_Class = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn39 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn40 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl_BatchCreate_Grade = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn38 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabPage_UpdateGrade = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl9 = new DevExpress.XtraEditors.GroupControl();
            this.comboBoxEdit_ClassNumber = new DevExpress.XtraEditors.ComboBoxEdit();
            this.notePanel_ClassNumber = new DevExpress.Utils.Frames.NotePanel();
            this.comboBoxEdit_GradeNumber = new DevExpress.XtraEditors.ComboBoxEdit();
            this.notePanel_GradeNumber = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel12 = new DevExpress.Utils.Frames.NotePanel();
            this.textEdit_DestClass = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_DestClass = new DevExpress.Utils.Frames.NotePanel();
            this.comboBoxEdit_SrcClass = new DevExpress.XtraEditors.ComboBoxEdit();
            this.notePanel_SrcClass = new DevExpress.Utils.Frames.NotePanel();
            this.textEdit_DestGrade = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_DestGrade = new DevExpress.Utils.Frames.NotePanel();
            this.comboBoxEdit_SrcGrade = new DevExpress.XtraEditors.ComboBoxEdit();
            this.notePanel_SrcGrade = new DevExpress.Utils.Frames.NotePanel();
            this.groupControl10 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_StudentAdjust = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn49 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn51 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn54 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn55 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn56 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.notePanel13 = new DevExpress.Utils.Frames.NotePanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton_Submit = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_LoadTable = new DevExpress.XtraEditors.SimpleButton();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.xtraTabPage_TerminalServ = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl_SessionUser = new DevExpress.XtraGrid.GridControl();
            this.gridView9 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn50 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn52 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn53 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn57 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView8 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl11 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl12 = new DevExpress.XtraEditors.GroupControl();
            this.rbtDefault = new System.Windows.Forms.RadioButton();
            this.rbtIdle = new System.Windows.Forms.RadioButton();
            this.rbtStart = new System.Windows.Forms.RadioButton();
            this.smbBackUp = new DevExpress.XtraEditors.SimpleButton();
            this.tbxBackUpRoot = new System.Windows.Forms.TextBox();
            this.smbRoot = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPage5 = new DevExpress.XtraTab.XtraTabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxUploadUrl = new System.Windows.Forms.TextBox();
            this.xtraTabPage6 = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl13 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView10 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn58 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox4 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumn59 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumn60 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn61 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumn62 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumn63 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn64 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem_Refresh = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Modify = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Delete = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Add = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Save = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_DeleteSession = new DevExpress.XtraBars.BarButtonItem();
            this.repositoryItemButtonEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.popupMenu2 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.openFileDialog_LoadStuInfoXLS = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog_BatchCreate = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog_createbackup = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_Options)).BeginInit();
            this.xtraTabControl_Options.SuspendLayout();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_DBUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_DBPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_DBName.Properties)).BeginInit();
            this.xtraTabPage_ComPortSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_ComPortSet)).BeginInit();
            this.groupControl_ComPortSet.SuspendLayout();
            this.xtraTabPage_AutoShutDown.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_DutyStartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).BeginInit();
            this.xtraTabPage_AutoSendSmsTimeSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_SMSMorningTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_SMSNightTime.Properties)).BeginInit();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_NewPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_ConfirmPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_OldPwd.Properties)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_UpdateAddress.Properties)).BeginInit();
            this.xtraTabPage_BatchCreate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl8)).BeginInit();
            this.groupControl8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_ClassVol.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_BatchCreate_TerminalNumbers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_BatchCreate_ClassNumbers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).BeginInit();
            this.groupControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_BatchCreate_CardNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_BatchCreate_Load.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_BatchCreate_Type.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_BatchCreate_Number.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_BatchCreate_Name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_BatchCreate_Class.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_BatchCreate_Grade.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).BeginInit();
            this.groupControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_BatchCreate_Machine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_BatchCreate_TeaCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1_BatchCreate_TeaBasicInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_BatchCreate_StuCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_BatchCreate_StuBasicInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_BatchCreate_Class)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_BatchCreate_Grade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.xtraTabPage_UpdateGrade.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl9)).BeginInit();
            this.groupControl9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_ClassNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_GradeNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_DestClass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_SrcClass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_DestGrade.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_SrcGrade.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl10)).BeginInit();
            this.groupControl10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_StudentAdjust)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.xtraTabPage_TerminalServ.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_SessionUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView8)).BeginInit();
            this.xtraTabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl11)).BeginInit();
            this.groupControl11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl12)).BeginInit();
            this.groupControl12.SuspendLayout();
            this.xtraTabPage5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.xtraTabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl13)).BeginInit();
            this.groupControl13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl_Options
            // 
            this.xtraTabControl_Options.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xtraTabControl_Options.Appearance.Options.UseBackColor = true;
            this.xtraTabControl_Options.AppearancePage.HeaderActive.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.xtraTabControl_Options.AppearancePage.HeaderActive.ForeColor = System.Drawing.Color.DarkOrange;
            this.xtraTabControl_Options.AppearancePage.HeaderActive.Options.UseFont = true;
            this.xtraTabControl_Options.AppearancePage.HeaderActive.Options.UseForeColor = true;
            this.xtraTabControl_Options.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl_Options.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl_Options.Name = "xtraTabControl_Options";
            this.xtraTabControl_Options.SelectedTabPage = this.xtraTabPage3;
            this.xtraTabControl_Options.Size = new System.Drawing.Size(688, 429);
            this.xtraTabControl_Options.TabIndex = 0;
            this.xtraTabControl_Options.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage_ComPortSet,
            this.xtraTabPage_AutoShutDown,
            this.xtraTabPage_AutoSendSmsTimeSet,
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3,
            this.xtraTabPage_BatchCreate,
            this.xtraTabPage_UpdateGrade,
            this.xtraTabPage_TerminalServ,
            this.xtraTabPage4,
            this.xtraTabPage5,
            this.xtraTabPage6});
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xtraTabPage3.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabPage3.Controls.Add(this.groupControl5);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(682, 400);
            this.xtraTabPage3.Text = "配置数据库";
            // 
            // groupControl5
            // 
            this.groupControl5.Controls.Add(this.textEdit_DBUser);
            this.groupControl5.Controls.Add(this.notePanel9);
            this.groupControl5.Controls.Add(this.notePanel10);
            this.groupControl5.Controls.Add(this.textEdit_DBPwd);
            this.groupControl5.Controls.Add(this.notePanel11);
            this.groupControl5.Controls.Add(this.textEdit_DBName);
            this.groupControl5.Controls.Add(this.simpleButton11);
            this.groupControl5.Controls.Add(this.simpleButton12);
            this.groupControl5.Location = new System.Drawing.Point(168, 56);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(342, 256);
            this.groupControl5.TabIndex = 2;
            this.groupControl5.Text = "服务器配置";
            // 
            // textEdit_DBUser
            // 
            this.textEdit_DBUser.EditValue = "";
            this.textEdit_DBUser.Location = new System.Drawing.Point(153, 93);
            this.textEdit_DBUser.Name = "textEdit_DBUser";
            this.textEdit_DBUser.Size = new System.Drawing.Size(152, 20);
            this.textEdit_DBUser.TabIndex = 23;
            // 
            // notePanel9
            // 
            this.notePanel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel9.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel9.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel9.ForeColor = System.Drawing.Color.Black;
            this.notePanel9.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel9.Location = new System.Drawing.Point(38, 93);
            this.notePanel9.MaxRows = 5;
            this.notePanel9.Name = "notePanel9";
            this.notePanel9.ParentAutoHeight = true;
            this.notePanel9.Size = new System.Drawing.Size(104, 22);
            this.notePanel9.TabIndex = 21;
            this.notePanel9.TabStop = false;
            this.notePanel9.Text = "     用户名:";
            // 
            // notePanel10
            // 
            this.notePanel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel10.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel10.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel10.ForeColor = System.Drawing.Color.Black;
            this.notePanel10.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel10.Location = new System.Drawing.Point(38, 125);
            this.notePanel10.MaxRows = 5;
            this.notePanel10.Name = "notePanel10";
            this.notePanel10.ParentAutoHeight = true;
            this.notePanel10.Size = new System.Drawing.Size(104, 22);
            this.notePanel10.TabIndex = 19;
            this.notePanel10.TabStop = false;
            this.notePanel10.Text = "      密   码:";
            // 
            // textEdit_DBPwd
            // 
            this.textEdit_DBPwd.EditValue = "";
            this.textEdit_DBPwd.Location = new System.Drawing.Point(153, 125);
            this.textEdit_DBPwd.Name = "textEdit_DBPwd";
            this.textEdit_DBPwd.Properties.PasswordChar = '*';
            this.textEdit_DBPwd.Size = new System.Drawing.Size(152, 20);
            this.textEdit_DBPwd.TabIndex = 24;
            // 
            // notePanel11
            // 
            this.notePanel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel11.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel11.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel11.ForeColor = System.Drawing.Color.Black;
            this.notePanel11.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel11.Location = new System.Drawing.Point(38, 61);
            this.notePanel11.MaxRows = 5;
            this.notePanel11.Name = "notePanel11";
            this.notePanel11.ParentAutoHeight = true;
            this.notePanel11.Size = new System.Drawing.Size(104, 22);
            this.notePanel11.TabIndex = 20;
            this.notePanel11.TabStop = false;
            this.notePanel11.Text = "数据库实例名:";
            // 
            // textEdit_DBName
            // 
            this.textEdit_DBName.EditValue = "";
            this.textEdit_DBName.Location = new System.Drawing.Point(153, 61);
            this.textEdit_DBName.Name = "textEdit_DBName";
            this.textEdit_DBName.Size = new System.Drawing.Size(152, 20);
            this.textEdit_DBName.TabIndex = 22;
            // 
            // simpleButton11
            // 
            this.simpleButton11.Location = new System.Drawing.Point(75, 168);
            this.simpleButton11.Name = "simpleButton11";
            this.simpleButton11.Size = new System.Drawing.Size(85, 23);
            this.simpleButton11.TabIndex = 1;
            this.simpleButton11.Text = "测试连接";
            this.simpleButton11.Click += new System.EventHandler(this.simpleButton11_Click);
            // 
            // simpleButton12
            // 
            this.simpleButton12.Location = new System.Drawing.Point(182, 168);
            this.simpleButton12.Name = "simpleButton12";
            this.simpleButton12.Size = new System.Drawing.Size(85, 23);
            this.simpleButton12.TabIndex = 1;
            this.simpleButton12.Text = "保存设置";
            this.simpleButton12.Click += new System.EventHandler(this.simpleButton12_Click);
            // 
            // xtraTabPage_ComPortSet
            // 
            this.xtraTabPage_ComPortSet.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xtraTabPage_ComPortSet.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabPage_ComPortSet.Controls.Add(this.groupControl_ComPortSet);
            this.xtraTabPage_ComPortSet.Name = "xtraTabPage_ComPortSet";
            this.xtraTabPage_ComPortSet.Size = new System.Drawing.Size(682, 400);
            this.xtraTabPage_ComPortSet.Text = "串口设定";
            // 
            // groupControl_ComPortSet
            // 
            this.groupControl_ComPortSet.Controls.Add(this.simpleButton1);
            this.groupControl_ComPortSet.Controls.Add(this.radioButton1);
            this.groupControl_ComPortSet.Controls.Add(this.radioButton2);
            this.groupControl_ComPortSet.Controls.Add(this.radioButton3);
            this.groupControl_ComPortSet.Controls.Add(this.radioButton4);
            this.groupControl_ComPortSet.Controls.Add(this.simpleButton6);
            this.groupControl_ComPortSet.Location = new System.Drawing.Point(184, 64);
            this.groupControl_ComPortSet.Name = "groupControl_ComPortSet";
            this.groupControl_ComPortSet.Size = new System.Drawing.Size(312, 216);
            this.groupControl_ComPortSet.TabIndex = 0;
            this.groupControl_ComPortSet.Text = "请选择管理机同电脑连接的串口";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(160, 184);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(56, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "确定";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(40, 32);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(104, 24);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "串口1";
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(168, 32);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(104, 24);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.Text = "串口2";
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(168, 80);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(104, 24);
            this.radioButton3.TabIndex = 0;
            this.radioButton3.Text = "串口4";
            // 
            // radioButton4
            // 
            this.radioButton4.Location = new System.Drawing.Point(40, 80);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(104, 24);
            this.radioButton4.TabIndex = 0;
            this.radioButton4.Text = "串口3";
            // 
            // simpleButton6
            // 
            this.simpleButton6.Location = new System.Drawing.Point(232, 184);
            this.simpleButton6.Name = "simpleButton6";
            this.simpleButton6.Size = new System.Drawing.Size(56, 23);
            this.simpleButton6.TabIndex = 1;
            this.simpleButton6.Text = "取消";
            this.simpleButton6.Click += new System.EventHandler(this.simpleButton6_Click);
            // 
            // xtraTabPage_AutoShutDown
            // 
            this.xtraTabPage_AutoShutDown.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xtraTabPage_AutoShutDown.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabPage_AutoShutDown.Controls.Add(this.groupControl2);
            this.xtraTabPage_AutoShutDown.Controls.Add(this.notePanel2);
            this.xtraTabPage_AutoShutDown.Name = "xtraTabPage_AutoShutDown";
            this.xtraTabPage_AutoShutDown.Size = new System.Drawing.Size(682, 400);
            this.xtraTabPage_AutoShutDown.Text = "关机时间设置";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.checkEdit1);
            this.groupControl2.Controls.Add(this.timeEdit_DutyStartTime);
            this.groupControl2.Controls.Add(this.notePanel_ShutDownTime);
            this.groupControl2.Controls.Add(this.simpleButton3);
            this.groupControl2.Controls.Add(this.simpleButton5);
            this.groupControl2.Controls.Add(this.checkEdit2);
            this.groupControl2.Location = new System.Drawing.Point(168, 48);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(312, 216);
            this.groupControl2.TabIndex = 8;
            this.groupControl2.Text = "设置";
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(68, 128);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "启动时自动运行";
            this.checkEdit1.Size = new System.Drawing.Size(180, 19);
            this.checkEdit1.TabIndex = 16;
            // 
            // timeEdit_DutyStartTime
            // 
            this.timeEdit_DutyStartTime.EditValue = new System.DateTime(2005, 8, 29, 0, 0, 0, 0);
            this.timeEdit_DutyStartTime.Location = new System.Drawing.Point(156, 48);
            this.timeEdit_DutyStartTime.Name = "timeEdit_DutyStartTime";
            this.timeEdit_DutyStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeEdit_DutyStartTime.Size = new System.Drawing.Size(88, 20);
            this.timeEdit_DutyStartTime.TabIndex = 15;
            // 
            // notePanel_ShutDownTime
            // 
            this.notePanel_ShutDownTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_ShutDownTime.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_ShutDownTime.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_ShutDownTime.ForeColor = System.Drawing.Color.Black;
            this.notePanel_ShutDownTime.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_ShutDownTime.Location = new System.Drawing.Point(68, 48);
            this.notePanel_ShutDownTime.MaxRows = 5;
            this.notePanel_ShutDownTime.Name = "notePanel_ShutDownTime";
            this.notePanel_ShutDownTime.ParentAutoHeight = true;
            this.notePanel_ShutDownTime.Size = new System.Drawing.Size(80, 22);
            this.notePanel_ShutDownTime.TabIndex = 14;
            this.notePanel_ShutDownTime.TabStop = false;
            this.notePanel_ShutDownTime.Text = "关机时间";
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(160, 184);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(56, 23);
            this.simpleButton3.TabIndex = 1;
            this.simpleButton3.Text = "确定";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButton5
            // 
            this.simpleButton5.Location = new System.Drawing.Point(232, 184);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new System.Drawing.Size(56, 23);
            this.simpleButton5.TabIndex = 1;
            this.simpleButton5.Text = "取消";
            this.simpleButton5.Click += new System.EventHandler(this.simpleButton5_Click);
            // 
            // checkEdit2
            // 
            this.checkEdit2.Location = new System.Drawing.Point(68, 88);
            this.checkEdit2.Name = "checkEdit2";
            this.checkEdit2.Properties.Caption = "开启自动关机";
            this.checkEdit2.Size = new System.Drawing.Size(180, 19);
            this.checkEdit2.TabIndex = 16;
            this.checkEdit2.CheckedChanged += new System.EventHandler(this.checkEdit2_CheckedChanged);
            // 
            // notePanel2
            // 
            this.notePanel2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.notePanel2.ForeColor = System.Drawing.Color.Gray;
            this.notePanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel2.Location = new System.Drawing.Point(168, 280);
            this.notePanel2.MaxRows = 5;
            this.notePanel2.Name = "notePanel2";
            this.notePanel2.ParentAutoHeight = true;
            this.notePanel2.Size = new System.Drawing.Size(272, 23);
            this.notePanel2.TabIndex = 9;
            this.notePanel2.TabStop = false;
            this.notePanel2.Text = "自动关机功能已启动";
            this.notePanel2.Visible = false;
            // 
            // xtraTabPage_AutoSendSmsTimeSet
            // 
            this.xtraTabPage_AutoSendSmsTimeSet.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xtraTabPage_AutoSendSmsTimeSet.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabPage_AutoSendSmsTimeSet.Controls.Add(this.groupControl3);
            this.xtraTabPage_AutoSendSmsTimeSet.Controls.Add(this.notePanel4);
            this.xtraTabPage_AutoSendSmsTimeSet.Name = "xtraTabPage_AutoSendSmsTimeSet";
            this.xtraTabPage_AutoSendSmsTimeSet.Size = new System.Drawing.Size(682, 400);
            this.xtraTabPage_AutoSendSmsTimeSet.Text = "短信功能设置";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.timeEdit_SMSMorningTime);
            this.groupControl3.Controls.Add(this.notePanel3);
            this.groupControl3.Controls.Add(this.simpleButton4);
            this.groupControl3.Controls.Add(this.notePanel5);
            this.groupControl3.Controls.Add(this.timeEdit_SMSNightTime);
            this.groupControl3.Controls.Add(this.notePanel6);
            this.groupControl3.Controls.Add(this.simpleButton7);
            this.groupControl3.Location = new System.Drawing.Point(168, 56);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(312, 216);
            this.groupControl3.TabIndex = 10;
            this.groupControl3.Text = "设置";
            // 
            // timeEdit_SMSMorningTime
            // 
            this.timeEdit_SMSMorningTime.EditValue = new System.DateTime(2005, 8, 29, 0, 0, 0, 0);
            this.timeEdit_SMSMorningTime.Location = new System.Drawing.Point(152, 96);
            this.timeEdit_SMSMorningTime.Name = "timeEdit_SMSMorningTime";
            this.timeEdit_SMSMorningTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeEdit_SMSMorningTime.Size = new System.Drawing.Size(88, 20);
            this.timeEdit_SMSMorningTime.TabIndex = 15;
            // 
            // notePanel3
            // 
            this.notePanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel3.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel3.ForeColor = System.Drawing.Color.Black;
            this.notePanel3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel3.Location = new System.Drawing.Point(64, 96);
            this.notePanel3.MaxRows = 5;
            this.notePanel3.Name = "notePanel3";
            this.notePanel3.ParentAutoHeight = true;
            this.notePanel3.Size = new System.Drawing.Size(80, 22);
            this.notePanel3.TabIndex = 14;
            this.notePanel3.TabStop = false;
            this.notePanel3.Text = "迟到时间";
            // 
            // simpleButton4
            // 
            this.simpleButton4.Location = new System.Drawing.Point(160, 184);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(56, 23);
            this.simpleButton4.TabIndex = 1;
            this.simpleButton4.Text = "确定";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // notePanel5
            // 
            this.notePanel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel5.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel5.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel5.ForeColor = System.Drawing.Color.Black;
            this.notePanel5.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel5.Location = new System.Drawing.Point(64, 128);
            this.notePanel5.MaxRows = 5;
            this.notePanel5.Name = "notePanel5";
            this.notePanel5.ParentAutoHeight = true;
            this.notePanel5.Size = new System.Drawing.Size(80, 22);
            this.notePanel5.TabIndex = 14;
            this.notePanel5.TabStop = false;
            this.notePanel5.Text = "晚接时间";
            // 
            // timeEdit_SMSNightTime
            // 
            this.timeEdit_SMSNightTime.EditValue = new System.DateTime(2005, 8, 29, 0, 0, 0, 0);
            this.timeEdit_SMSNightTime.Location = new System.Drawing.Point(152, 128);
            this.timeEdit_SMSNightTime.Name = "timeEdit_SMSNightTime";
            this.timeEdit_SMSNightTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeEdit_SMSNightTime.Size = new System.Drawing.Size(88, 20);
            this.timeEdit_SMSNightTime.TabIndex = 15;
            // 
            // notePanel6
            // 
            this.notePanel6.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.notePanel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.notePanel6.ForeColor = System.Drawing.Color.Gray;
            this.notePanel6.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel6.Location = new System.Drawing.Point(2, 22);
            this.notePanel6.MaxRows = 5;
            this.notePanel6.Name = "notePanel6";
            this.notePanel6.ParentAutoHeight = true;
            this.notePanel6.Size = new System.Drawing.Size(308, 52);
            this.notePanel6.TabIndex = 11;
            this.notePanel6.TabStop = false;
            this.notePanel6.Text = "当每日时间到达迟到时间,晚接时间,如果注册过短信服务的学生仍为到校,系统将会自动向手机发出信息提示!";
            // 
            // simpleButton7
            // 
            this.simpleButton7.Location = new System.Drawing.Point(232, 184);
            this.simpleButton7.Name = "simpleButton7";
            this.simpleButton7.Size = new System.Drawing.Size(56, 23);
            this.simpleButton7.TabIndex = 1;
            this.simpleButton7.Text = "取消";
            this.simpleButton7.Click += new System.EventHandler(this.simpleButton7_Click);
            // 
            // notePanel4
            // 
            this.notePanel4.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.notePanel4.ForeColor = System.Drawing.Color.Gray;
            this.notePanel4.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel4.Location = new System.Drawing.Point(184, 288);
            this.notePanel4.MaxRows = 5;
            this.notePanel4.Name = "notePanel4";
            this.notePanel4.ParentAutoHeight = true;
            this.notePanel4.Size = new System.Drawing.Size(272, 23);
            this.notePanel4.TabIndex = 11;
            this.notePanel4.TabStop = false;
            this.notePanel4.Text = "短信自动发送时间设定成功";
            this.notePanel4.Visible = false;
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xtraTabPage1.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabPage1.Controls.Add(this.groupControl4);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(682, 400);
            this.xtraTabPage1.Text = "修改个人密码";
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.textEdit_NewPwd);
            this.groupControl4.Controls.Add(this.notePanel1);
            this.groupControl4.Controls.Add(this.simpleButton8);
            this.groupControl4.Controls.Add(this.notePanel7);
            this.groupControl4.Controls.Add(this.simpleButton9);
            this.groupControl4.Controls.Add(this.textEdit_ConfirmPwd);
            this.groupControl4.Controls.Add(this.notePanel8);
            this.groupControl4.Controls.Add(this.textEdit_OldPwd);
            this.groupControl4.Location = new System.Drawing.Point(176, 64);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(312, 216);
            this.groupControl4.TabIndex = 11;
            this.groupControl4.Text = "请输入修改密码";
            // 
            // textEdit_NewPwd
            // 
            this.textEdit_NewPwd.EditValue = "";
            this.textEdit_NewPwd.Location = new System.Drawing.Point(160, 72);
            this.textEdit_NewPwd.Name = "textEdit_NewPwd";
            this.textEdit_NewPwd.Properties.PasswordChar = '*';
            this.textEdit_NewPwd.Size = new System.Drawing.Size(88, 20);
            this.textEdit_NewPwd.TabIndex = 17;
            // 
            // notePanel1
            // 
            this.notePanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel1.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel1.ForeColor = System.Drawing.Color.Black;
            this.notePanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel1.Location = new System.Drawing.Point(72, 72);
            this.notePanel1.MaxRows = 5;
            this.notePanel1.Name = "notePanel1";
            this.notePanel1.ParentAutoHeight = true;
            this.notePanel1.Size = new System.Drawing.Size(80, 22);
            this.notePanel1.TabIndex = 14;
            this.notePanel1.TabStop = false;
            this.notePanel1.Text = "修改密码";
            // 
            // simpleButton8
            // 
            this.simpleButton8.Location = new System.Drawing.Point(128, 144);
            this.simpleButton8.Name = "simpleButton8";
            this.simpleButton8.Size = new System.Drawing.Size(56, 23);
            this.simpleButton8.TabIndex = 1;
            this.simpleButton8.Text = "确定";
            this.simpleButton8.Click += new System.EventHandler(this.simpleButton8_Click);
            // 
            // notePanel7
            // 
            this.notePanel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel7.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel7.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel7.ForeColor = System.Drawing.Color.Black;
            this.notePanel7.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel7.Location = new System.Drawing.Point(72, 104);
            this.notePanel7.MaxRows = 5;
            this.notePanel7.Name = "notePanel7";
            this.notePanel7.ParentAutoHeight = true;
            this.notePanel7.Size = new System.Drawing.Size(80, 22);
            this.notePanel7.TabIndex = 14;
            this.notePanel7.TabStop = false;
            this.notePanel7.Text = "确认密码";
            // 
            // simpleButton9
            // 
            this.simpleButton9.Location = new System.Drawing.Point(192, 144);
            this.simpleButton9.Name = "simpleButton9";
            this.simpleButton9.Size = new System.Drawing.Size(56, 23);
            this.simpleButton9.TabIndex = 1;
            this.simpleButton9.Text = "取消";
            this.simpleButton9.Click += new System.EventHandler(this.simpleButton9_Click);
            // 
            // textEdit_ConfirmPwd
            // 
            this.textEdit_ConfirmPwd.EditValue = "";
            this.textEdit_ConfirmPwd.Location = new System.Drawing.Point(160, 104);
            this.textEdit_ConfirmPwd.Name = "textEdit_ConfirmPwd";
            this.textEdit_ConfirmPwd.Properties.PasswordChar = '*';
            this.textEdit_ConfirmPwd.Size = new System.Drawing.Size(88, 20);
            this.textEdit_ConfirmPwd.TabIndex = 18;
            // 
            // notePanel8
            // 
            this.notePanel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel8.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel8.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel8.ForeColor = System.Drawing.Color.Black;
            this.notePanel8.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel8.Location = new System.Drawing.Point(72, 40);
            this.notePanel8.MaxRows = 5;
            this.notePanel8.Name = "notePanel8";
            this.notePanel8.ParentAutoHeight = true;
            this.notePanel8.Size = new System.Drawing.Size(80, 22);
            this.notePanel8.TabIndex = 14;
            this.notePanel8.TabStop = false;
            this.notePanel8.Text = "原始密码";
            // 
            // textEdit_OldPwd
            // 
            this.textEdit_OldPwd.EditValue = "";
            this.textEdit_OldPwd.Location = new System.Drawing.Point(160, 40);
            this.textEdit_OldPwd.Name = "textEdit_OldPwd";
            this.textEdit_OldPwd.Properties.PasswordChar = '*';
            this.textEdit_OldPwd.Size = new System.Drawing.Size(88, 20);
            this.textEdit_OldPwd.TabIndex = 16;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xtraTabPage2.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabPage2.Controls.Add(this.groupControl1);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(682, 400);
            this.xtraTabPage2.Text = "配置自动更新地址";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.textEdit_UpdateAddress);
            this.groupControl1.Controls.Add(this.simpleButton2);
            this.groupControl1.Controls.Add(this.simpleButton10);
            this.groupControl1.Location = new System.Drawing.Point(176, 64);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(312, 216);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "请输入自动更新网络地址";
            // 
            // textEdit_UpdateAddress
            // 
            this.textEdit_UpdateAddress.EditValue = "";
            this.textEdit_UpdateAddress.Location = new System.Drawing.Point(52, 72);
            this.textEdit_UpdateAddress.Name = "textEdit_UpdateAddress";
            this.textEdit_UpdateAddress.Size = new System.Drawing.Size(208, 20);
            this.textEdit_UpdateAddress.TabIndex = 17;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(160, 168);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(56, 23);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "确定";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton10
            // 
            this.simpleButton10.Location = new System.Drawing.Point(232, 168);
            this.simpleButton10.Name = "simpleButton10";
            this.simpleButton10.Size = new System.Drawing.Size(56, 23);
            this.simpleButton10.TabIndex = 1;
            this.simpleButton10.Text = "取消";
            this.simpleButton10.Click += new System.EventHandler(this.simpleButton10_Click);
            // 
            // xtraTabPage_BatchCreate
            // 
            this.xtraTabPage_BatchCreate.Controls.Add(this.splitContainerControl1);
            this.xtraTabPage_BatchCreate.Name = "xtraTabPage_BatchCreate";
            this.xtraTabPage_BatchCreate.Size = new System.Drawing.Size(682, 400);
            this.xtraTabPage_BatchCreate.Text = "批量数据生成";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl8);
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl6);
            this.splitContainerControl1.Panel1.Text = "splitContainerControl1_Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl7);
            this.splitContainerControl1.Panel2.Text = "splitContainerControl1_Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(682, 400);
            this.splitContainerControl1.SplitterPosition = 213;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl8
            // 
            this.groupControl8.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl8.AppearanceCaption.Options.UseFont = true;
            this.groupControl8.Controls.Add(this.textEdit_ClassVol);
            this.groupControl8.Controls.Add(this.textEdit_BatchCreate_TerminalNumbers);
            this.groupControl8.Controls.Add(this.textEdit_BatchCreate_ClassNumbers);
            this.groupControl8.Controls.Add(this.notePanel_ClassVol);
            this.groupControl8.Controls.Add(this.notePanel_BatchCreate_TerminalNumbers);
            this.groupControl8.Controls.Add(this.notePanel_BatchCreate_ClassNumbers);
            this.groupControl8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl8.Location = new System.Drawing.Point(0, 256);
            this.groupControl8.Name = "groupControl8";
            this.groupControl8.Size = new System.Drawing.Size(213, 144);
            this.groupControl8.TabIndex = 1;
            this.groupControl8.Text = "硬件信息修改";
            // 
            // textEdit_ClassVol
            // 
            this.textEdit_ClassVol.EditValue = "";
            this.textEdit_ClassVol.Location = new System.Drawing.Point(104, 96);
            this.textEdit_ClassVol.Name = "textEdit_ClassVol";
            this.textEdit_ClassVol.Size = new System.Drawing.Size(96, 20);
            this.textEdit_ClassVol.TabIndex = 32;
            // 
            // textEdit_BatchCreate_TerminalNumbers
            // 
            this.textEdit_BatchCreate_TerminalNumbers.EditValue = "";
            this.textEdit_BatchCreate_TerminalNumbers.Location = new System.Drawing.Point(104, 64);
            this.textEdit_BatchCreate_TerminalNumbers.Name = "textEdit_BatchCreate_TerminalNumbers";
            this.textEdit_BatchCreate_TerminalNumbers.Size = new System.Drawing.Size(96, 20);
            this.textEdit_BatchCreate_TerminalNumbers.TabIndex = 31;
            // 
            // textEdit_BatchCreate_ClassNumbers
            // 
            this.textEdit_BatchCreate_ClassNumbers.EditValue = "";
            this.textEdit_BatchCreate_ClassNumbers.Location = new System.Drawing.Point(104, 32);
            this.textEdit_BatchCreate_ClassNumbers.Name = "textEdit_BatchCreate_ClassNumbers";
            this.textEdit_BatchCreate_ClassNumbers.Size = new System.Drawing.Size(96, 20);
            this.textEdit_BatchCreate_ClassNumbers.TabIndex = 30;
            // 
            // notePanel_ClassVol
            // 
            this.notePanel_ClassVol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_ClassVol.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_ClassVol.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_ClassVol.ForeColor = System.Drawing.Color.Black;
            this.notePanel_ClassVol.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_ClassVol.Location = new System.Drawing.Point(16, 96);
            this.notePanel_ClassVol.MaxRows = 5;
            this.notePanel_ClassVol.Name = "notePanel_ClassVol";
            this.notePanel_ClassVol.ParentAutoHeight = true;
            this.notePanel_ClassVol.Size = new System.Drawing.Size(80, 22);
            this.notePanel_ClassVol.TabIndex = 24;
            this.notePanel_ClassVol.TabStop = false;
            this.notePanel_ClassVol.Text = "教室容量:";
            // 
            // notePanel_BatchCreate_TerminalNumbers
            // 
            this.notePanel_BatchCreate_TerminalNumbers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_BatchCreate_TerminalNumbers.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_BatchCreate_TerminalNumbers.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_BatchCreate_TerminalNumbers.ForeColor = System.Drawing.Color.Black;
            this.notePanel_BatchCreate_TerminalNumbers.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_BatchCreate_TerminalNumbers.Location = new System.Drawing.Point(16, 64);
            this.notePanel_BatchCreate_TerminalNumbers.MaxRows = 5;
            this.notePanel_BatchCreate_TerminalNumbers.Name = "notePanel_BatchCreate_TerminalNumbers";
            this.notePanel_BatchCreate_TerminalNumbers.ParentAutoHeight = true;
            this.notePanel_BatchCreate_TerminalNumbers.Size = new System.Drawing.Size(80, 22);
            this.notePanel_BatchCreate_TerminalNumbers.TabIndex = 23;
            this.notePanel_BatchCreate_TerminalNumbers.TabStop = false;
            this.notePanel_BatchCreate_TerminalNumbers.Text = "主机总数:";
            // 
            // notePanel_BatchCreate_ClassNumbers
            // 
            this.notePanel_BatchCreate_ClassNumbers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_BatchCreate_ClassNumbers.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_BatchCreate_ClassNumbers.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_BatchCreate_ClassNumbers.ForeColor = System.Drawing.Color.Black;
            this.notePanel_BatchCreate_ClassNumbers.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_BatchCreate_ClassNumbers.Location = new System.Drawing.Point(16, 32);
            this.notePanel_BatchCreate_ClassNumbers.MaxRows = 5;
            this.notePanel_BatchCreate_ClassNumbers.Name = "notePanel_BatchCreate_ClassNumbers";
            this.notePanel_BatchCreate_ClassNumbers.ParentAutoHeight = true;
            this.notePanel_BatchCreate_ClassNumbers.Size = new System.Drawing.Size(80, 22);
            this.notePanel_BatchCreate_ClassNumbers.TabIndex = 22;
            this.notePanel_BatchCreate_ClassNumbers.TabStop = false;
            this.notePanel_BatchCreate_ClassNumbers.Text = "班级总数:";
            // 
            // groupControl6
            // 
            this.groupControl6.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl6.AppearanceCaption.Options.UseFont = true;
            this.groupControl6.Controls.Add(this.textEdit_BatchCreate_CardNumber);
            this.groupControl6.Controls.Add(this.notePanel_BatchCreate_CardNumber);
            this.groupControl6.Controls.Add(this.comboBoxEdit_BatchCreate_Load);
            this.groupControl6.Controls.Add(this.comboBoxEdit_BatchCreate_Type);
            this.groupControl6.Controls.Add(this.textEdit_BatchCreate_Number);
            this.groupControl6.Controls.Add(this.textEdit_BatchCreate_Name);
            this.groupControl6.Controls.Add(this.comboBoxEdit_BatchCreate_Class);
            this.groupControl6.Controls.Add(this.comboBoxEdit_BatchCreate_Grade);
            this.groupControl6.Controls.Add(this.notePanel_BatchCreate_Load);
            this.groupControl6.Controls.Add(this.notePanel_BatchCreate_Type);
            this.groupControl6.Controls.Add(this.notePanel_BatchCreate_Number);
            this.groupControl6.Controls.Add(this.notePanel_BatchCreate_Name);
            this.groupControl6.Controls.Add(this.notePanel_BatchCreate_Class);
            this.groupControl6.Controls.Add(this.notePanel_BatchCreate_Grade);
            this.groupControl6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl6.Location = new System.Drawing.Point(0, 0);
            this.groupControl6.Name = "groupControl6";
            this.groupControl6.Size = new System.Drawing.Size(213, 256);
            this.groupControl6.TabIndex = 0;
            this.groupControl6.Text = "信息查询";
            // 
            // textEdit_BatchCreate_CardNumber
            // 
            this.textEdit_BatchCreate_CardNumber.EditValue = "";
            this.textEdit_BatchCreate_CardNumber.Location = new System.Drawing.Point(104, 152);
            this.textEdit_BatchCreate_CardNumber.Name = "textEdit_BatchCreate_CardNumber";
            this.textEdit_BatchCreate_CardNumber.Size = new System.Drawing.Size(96, 20);
            this.textEdit_BatchCreate_CardNumber.TabIndex = 34;
            this.textEdit_BatchCreate_CardNumber.EditValueChanged += new System.EventHandler(this.textEdit_BatchCreate_CardNumber_EditValueChanged);
            // 
            // notePanel_BatchCreate_CardNumber
            // 
            this.notePanel_BatchCreate_CardNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_BatchCreate_CardNumber.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_BatchCreate_CardNumber.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_BatchCreate_CardNumber.ForeColor = System.Drawing.Color.Black;
            this.notePanel_BatchCreate_CardNumber.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_BatchCreate_CardNumber.Location = new System.Drawing.Point(16, 152);
            this.notePanel_BatchCreate_CardNumber.MaxRows = 5;
            this.notePanel_BatchCreate_CardNumber.Name = "notePanel_BatchCreate_CardNumber";
            this.notePanel_BatchCreate_CardNumber.ParentAutoHeight = true;
            this.notePanel_BatchCreate_CardNumber.Size = new System.Drawing.Size(80, 22);
            this.notePanel_BatchCreate_CardNumber.TabIndex = 33;
            this.notePanel_BatchCreate_CardNumber.TabStop = false;
            this.notePanel_BatchCreate_CardNumber.Text = "  卡  号:";
            // 
            // comboBoxEdit_BatchCreate_Load
            // 
            this.comboBoxEdit_BatchCreate_Load.EditValue = "未选择";
            this.comboBoxEdit_BatchCreate_Load.Location = new System.Drawing.Point(104, 216);
            this.comboBoxEdit_BatchCreate_Load.Name = "comboBoxEdit_BatchCreate_Load";
            this.comboBoxEdit_BatchCreate_Load.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_BatchCreate_Load.Properties.Items.AddRange(new object[] {
            "学生信息表(简单)",
            "学生信息表(复杂)",
            "教师信息表",
            "生成卡号新增表",
            "载入卡号新增表"});
            this.comboBoxEdit_BatchCreate_Load.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_BatchCreate_Load.Size = new System.Drawing.Size(96, 20);
            this.comboBoxEdit_BatchCreate_Load.TabIndex = 32;
            this.comboBoxEdit_BatchCreate_Load.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_BatchCreate_Load_SelectedIndexChanged);
            // 
            // comboBoxEdit_BatchCreate_Type
            // 
            this.comboBoxEdit_BatchCreate_Type.EditValue = "未选择";
            this.comboBoxEdit_BatchCreate_Type.Location = new System.Drawing.Point(104, 184);
            this.comboBoxEdit_BatchCreate_Type.Name = "comboBoxEdit_BatchCreate_Type";
            this.comboBoxEdit_BatchCreate_Type.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_BatchCreate_Type.Properties.Items.AddRange(new object[] {
            "年级表(含部门)",
            "班级表(含岗位)",
            "学生基本信息表",
            "学生卡号表",
            "教师基本信息表",
            "教师卡号表",
            "硬件配置表"});
            this.comboBoxEdit_BatchCreate_Type.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_BatchCreate_Type.Size = new System.Drawing.Size(96, 20);
            this.comboBoxEdit_BatchCreate_Type.TabIndex = 31;
            this.comboBoxEdit_BatchCreate_Type.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_BatchCreate_Type_SelectedIndexChanged);
            // 
            // textEdit_BatchCreate_Number
            // 
            this.textEdit_BatchCreate_Number.EditValue = "";
            this.textEdit_BatchCreate_Number.Location = new System.Drawing.Point(104, 120);
            this.textEdit_BatchCreate_Number.Name = "textEdit_BatchCreate_Number";
            this.textEdit_BatchCreate_Number.Size = new System.Drawing.Size(96, 20);
            this.textEdit_BatchCreate_Number.TabIndex = 30;
            this.textEdit_BatchCreate_Number.EditValueChanged += new System.EventHandler(this.textEdit_BatchCreate_Number_EditValueChanged);
            // 
            // textEdit_BatchCreate_Name
            // 
            this.textEdit_BatchCreate_Name.EditValue = "";
            this.textEdit_BatchCreate_Name.Location = new System.Drawing.Point(104, 88);
            this.textEdit_BatchCreate_Name.Name = "textEdit_BatchCreate_Name";
            this.textEdit_BatchCreate_Name.Size = new System.Drawing.Size(96, 20);
            this.textEdit_BatchCreate_Name.TabIndex = 29;
            this.textEdit_BatchCreate_Name.EditValueChanged += new System.EventHandler(this.textEdit_BatchCreate_Name_EditValueChanged);
            // 
            // comboBoxEdit_BatchCreate_Class
            // 
            this.comboBoxEdit_BatchCreate_Class.EditValue = "全部";
            this.comboBoxEdit_BatchCreate_Class.Location = new System.Drawing.Point(104, 56);
            this.comboBoxEdit_BatchCreate_Class.Name = "comboBoxEdit_BatchCreate_Class";
            this.comboBoxEdit_BatchCreate_Class.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_BatchCreate_Class.Properties.Items.AddRange(new object[] {
            "全部"});
            this.comboBoxEdit_BatchCreate_Class.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_BatchCreate_Class.Size = new System.Drawing.Size(96, 20);
            this.comboBoxEdit_BatchCreate_Class.TabIndex = 28;
            this.comboBoxEdit_BatchCreate_Class.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_BatchCreate_Class_SelectedIndexChanged);
            // 
            // comboBoxEdit_BatchCreate_Grade
            // 
            this.comboBoxEdit_BatchCreate_Grade.EditValue = "全部";
            this.comboBoxEdit_BatchCreate_Grade.Location = new System.Drawing.Point(104, 24);
            this.comboBoxEdit_BatchCreate_Grade.Name = "comboBoxEdit_BatchCreate_Grade";
            this.comboBoxEdit_BatchCreate_Grade.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_BatchCreate_Grade.Properties.Items.AddRange(new object[] {
            "全部"});
            this.comboBoxEdit_BatchCreate_Grade.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_BatchCreate_Grade.Size = new System.Drawing.Size(96, 20);
            this.comboBoxEdit_BatchCreate_Grade.TabIndex = 27;
            this.comboBoxEdit_BatchCreate_Grade.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_BatchCreate_Grade_SelectedIndexChanged);
            // 
            // notePanel_BatchCreate_Load
            // 
            this.notePanel_BatchCreate_Load.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_BatchCreate_Load.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_BatchCreate_Load.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_BatchCreate_Load.ForeColor = System.Drawing.Color.Black;
            this.notePanel_BatchCreate_Load.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_BatchCreate_Load.Location = new System.Drawing.Point(16, 216);
            this.notePanel_BatchCreate_Load.MaxRows = 5;
            this.notePanel_BatchCreate_Load.Name = "notePanel_BatchCreate_Load";
            this.notePanel_BatchCreate_Load.ParentAutoHeight = true;
            this.notePanel_BatchCreate_Load.Size = new System.Drawing.Size(80, 22);
            this.notePanel_BatchCreate_Load.TabIndex = 26;
            this.notePanel_BatchCreate_Load.TabStop = false;
            this.notePanel_BatchCreate_Load.Text = "  载  入:";
            // 
            // notePanel_BatchCreate_Type
            // 
            this.notePanel_BatchCreate_Type.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_BatchCreate_Type.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_BatchCreate_Type.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_BatchCreate_Type.ForeColor = System.Drawing.Color.Black;
            this.notePanel_BatchCreate_Type.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_BatchCreate_Type.Location = new System.Drawing.Point(16, 184);
            this.notePanel_BatchCreate_Type.MaxRows = 5;
            this.notePanel_BatchCreate_Type.Name = "notePanel_BatchCreate_Type";
            this.notePanel_BatchCreate_Type.ParentAutoHeight = true;
            this.notePanel_BatchCreate_Type.Size = new System.Drawing.Size(80, 22);
            this.notePanel_BatchCreate_Type.TabIndex = 25;
            this.notePanel_BatchCreate_Type.TabStop = false;
            this.notePanel_BatchCreate_Type.Text = "  类  型:";
            // 
            // notePanel_BatchCreate_Number
            // 
            this.notePanel_BatchCreate_Number.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_BatchCreate_Number.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_BatchCreate_Number.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_BatchCreate_Number.ForeColor = System.Drawing.Color.Black;
            this.notePanel_BatchCreate_Number.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_BatchCreate_Number.Location = new System.Drawing.Point(16, 120);
            this.notePanel_BatchCreate_Number.MaxRows = 5;
            this.notePanel_BatchCreate_Number.Name = "notePanel_BatchCreate_Number";
            this.notePanel_BatchCreate_Number.ParentAutoHeight = true;
            this.notePanel_BatchCreate_Number.Size = new System.Drawing.Size(80, 22);
            this.notePanel_BatchCreate_Number.TabIndex = 24;
            this.notePanel_BatchCreate_Number.TabStop = false;
            this.notePanel_BatchCreate_Number.Text = "  学  号:";
            // 
            // notePanel_BatchCreate_Name
            // 
            this.notePanel_BatchCreate_Name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_BatchCreate_Name.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_BatchCreate_Name.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_BatchCreate_Name.ForeColor = System.Drawing.Color.Black;
            this.notePanel_BatchCreate_Name.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_BatchCreate_Name.Location = new System.Drawing.Point(16, 88);
            this.notePanel_BatchCreate_Name.MaxRows = 5;
            this.notePanel_BatchCreate_Name.Name = "notePanel_BatchCreate_Name";
            this.notePanel_BatchCreate_Name.ParentAutoHeight = true;
            this.notePanel_BatchCreate_Name.Size = new System.Drawing.Size(80, 22);
            this.notePanel_BatchCreate_Name.TabIndex = 23;
            this.notePanel_BatchCreate_Name.TabStop = false;
            this.notePanel_BatchCreate_Name.Text = "  姓  名:";
            // 
            // notePanel_BatchCreate_Class
            // 
            this.notePanel_BatchCreate_Class.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_BatchCreate_Class.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_BatchCreate_Class.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_BatchCreate_Class.ForeColor = System.Drawing.Color.Black;
            this.notePanel_BatchCreate_Class.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_BatchCreate_Class.Location = new System.Drawing.Point(16, 56);
            this.notePanel_BatchCreate_Class.MaxRows = 5;
            this.notePanel_BatchCreate_Class.Name = "notePanel_BatchCreate_Class";
            this.notePanel_BatchCreate_Class.ParentAutoHeight = true;
            this.notePanel_BatchCreate_Class.Size = new System.Drawing.Size(80, 22);
            this.notePanel_BatchCreate_Class.TabIndex = 22;
            this.notePanel_BatchCreate_Class.TabStop = false;
            this.notePanel_BatchCreate_Class.Text = "  班  级:";
            // 
            // notePanel_BatchCreate_Grade
            // 
            this.notePanel_BatchCreate_Grade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_BatchCreate_Grade.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_BatchCreate_Grade.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_BatchCreate_Grade.ForeColor = System.Drawing.Color.Black;
            this.notePanel_BatchCreate_Grade.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_BatchCreate_Grade.Location = new System.Drawing.Point(16, 24);
            this.notePanel_BatchCreate_Grade.MaxRows = 5;
            this.notePanel_BatchCreate_Grade.Name = "notePanel_BatchCreate_Grade";
            this.notePanel_BatchCreate_Grade.ParentAutoHeight = true;
            this.notePanel_BatchCreate_Grade.Size = new System.Drawing.Size(80, 22);
            this.notePanel_BatchCreate_Grade.TabIndex = 21;
            this.notePanel_BatchCreate_Grade.TabStop = false;
            this.notePanel_BatchCreate_Grade.Text = "  年  级:";
            // 
            // groupControl7
            // 
            this.groupControl7.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl7.AppearanceCaption.Options.UseFont = true;
            this.groupControl7.Controls.Add(this.gridControl_BatchCreate_Machine);
            this.groupControl7.Controls.Add(this.gridControl_BatchCreate_TeaCard);
            this.groupControl7.Controls.Add(this.gridControl1_BatchCreate_TeaBasicInfo);
            this.groupControl7.Controls.Add(this.gridControl_BatchCreate_StuCard);
            this.groupControl7.Controls.Add(this.gridControl_BatchCreate_StuBasicInfo);
            this.groupControl7.Controls.Add(this.gridControl_BatchCreate_Class);
            this.groupControl7.Controls.Add(this.gridControl_BatchCreate_Grade);
            this.groupControl7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl7.Location = new System.Drawing.Point(0, 0);
            this.groupControl7.Name = "groupControl7";
            this.groupControl7.Size = new System.Drawing.Size(464, 400);
            this.groupControl7.TabIndex = 0;
            this.groupControl7.Text = "信息列表";
            // 
            // gridControl_BatchCreate_Machine
            // 
            this.gridControl_BatchCreate_Machine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_BatchCreate_Machine.Location = new System.Drawing.Point(2, 22);
            this.gridControl_BatchCreate_Machine.MainView = this.gridView7;
            this.gridControl_BatchCreate_Machine.Name = "gridControl_BatchCreate_Machine";
            this.gridControl_BatchCreate_Machine.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2});
            this.gridControl_BatchCreate_Machine.Size = new System.Drawing.Size(460, 376);
            this.gridControl_BatchCreate_Machine.TabIndex = 6;
            this.gridControl_BatchCreate_Machine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView7});
            // 
            // gridView7
            // 
            this.gridView7.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn48,
            this.gridColumn47,
            this.gridColumn35,
            this.gridColumn36,
            this.gridColumn37});
            this.gridView7.GridControl = this.gridControl_BatchCreate_Machine;
            this.gridView7.Name = "gridView7";
            this.gridView7.OptionsCustomization.AllowFilter = false;
            this.gridView7.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView7.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn48
            // 
            this.gridColumn48.Caption = "gridColumn48";
            this.gridColumn48.FieldName = "Address";
            this.gridColumn48.Name = "gridColumn48";
            this.gridColumn48.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn48.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn48.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn48.OptionsColumn.AllowMove = false;
            this.gridColumn48.OptionsColumn.AllowSize = false;
            this.gridColumn48.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn48.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // gridColumn47
            // 
            this.gridColumn47.Caption = "gridColumn47";
            this.gridColumn47.FieldName = "Type";
            this.gridColumn47.Name = "gridColumn47";
            this.gridColumn47.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn47.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn47.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn47.OptionsColumn.AllowMove = false;
            this.gridColumn47.OptionsColumn.AllowSize = false;
            this.gridColumn47.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn47.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // gridColumn35
            // 
            this.gridColumn35.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn35.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn35.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn35.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn35.Caption = "硬件地址";
            this.gridColumn35.FieldName = "machine_address";
            this.gridColumn35.Name = "gridColumn35";
            this.gridColumn35.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn35.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn35.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn35.OptionsColumn.AllowMove = false;
            this.gridColumn35.OptionsColumn.AllowSize = false;
            this.gridColumn35.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn35.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn35.Visible = true;
            this.gridColumn35.VisibleIndex = 0;
            // 
            // gridColumn36
            // 
            this.gridColumn36.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn36.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn36.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn36.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn36.Caption = "硬件类型";
            this.gridColumn36.FieldName = "machine_type";
            this.gridColumn36.Name = "gridColumn36";
            this.gridColumn36.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn36.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn36.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn36.OptionsColumn.AllowMove = false;
            this.gridColumn36.OptionsColumn.AllowSize = false;
            this.gridColumn36.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn36.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn36.Visible = true;
            this.gridColumn36.VisibleIndex = 1;
            // 
            // gridColumn37
            // 
            this.gridColumn37.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn37.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn37.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn37.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn37.Caption = "硬件容量";
            this.gridColumn37.FieldName = "machine_volumn";
            this.gridColumn37.Name = "gridColumn37";
            this.gridColumn37.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn37.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn37.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn37.OptionsColumn.AllowMove = false;
            this.gridColumn37.OptionsColumn.AllowSize = false;
            this.gridColumn37.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn37.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn37.Visible = true;
            this.gridColumn37.VisibleIndex = 2;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // gridControl_BatchCreate_TeaCard
            // 
            this.gridControl_BatchCreate_TeaCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_BatchCreate_TeaCard.Location = new System.Drawing.Point(2, 22);
            this.gridControl_BatchCreate_TeaCard.MainView = this.gridView6;
            this.gridControl_BatchCreate_TeaCard.Name = "gridControl_BatchCreate_TeaCard";
            this.gridControl_BatchCreate_TeaCard.Size = new System.Drawing.Size(460, 376);
            this.gridControl_BatchCreate_TeaCard.TabIndex = 5;
            this.gridControl_BatchCreate_TeaCard.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView6});
            // 
            // gridView6
            // 
            this.gridView6.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn30,
            this.gridColumn31,
            this.gridColumn32,
            this.gridColumn33,
            this.gridColumn34,
            this.gridColumn46});
            this.gridView6.GridControl = this.gridControl_BatchCreate_TeaCard;
            this.gridView6.Name = "gridView6";
            this.gridView6.OptionsBehavior.Editable = false;
            this.gridView6.OptionsCustomization.AllowFilter = false;
            this.gridView6.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView6.OptionsView.ShowGroupPanel = false;
            this.gridView6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView6_KeyDown);
            // 
            // gridColumn30
            // 
            this.gridColumn30.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn30.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn30.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn30.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn30.Caption = "工号";
            this.gridColumn30.FieldName = "T_Number";
            this.gridColumn30.Name = "gridColumn30";
            this.gridColumn30.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn30.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn30.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn30.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn30.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn30.Visible = true;
            this.gridColumn30.VisibleIndex = 0;
            this.gridColumn30.Width = 79;
            // 
            // gridColumn31
            // 
            this.gridColumn31.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn31.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn31.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn31.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn31.Caption = "姓名";
            this.gridColumn31.FieldName = "T_Name";
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn31.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn31.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn31.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn31.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn31.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn31.Visible = true;
            this.gridColumn31.VisibleIndex = 1;
            this.gridColumn31.Width = 80;
            // 
            // gridColumn32
            // 
            this.gridColumn32.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn32.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn32.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn32.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn32.Caption = "卡号";
            this.gridColumn32.FieldName = "info_teaCardNumber";
            this.gridColumn32.Name = "gridColumn32";
            this.gridColumn32.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn32.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn32.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn32.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn32.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn32.Visible = true;
            this.gridColumn32.VisibleIndex = 2;
            this.gridColumn32.Width = 120;
            // 
            // gridColumn33
            // 
            this.gridColumn33.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn33.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn33.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn33.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn33.Caption = "制卡日期";
            this.gridColumn33.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.gridColumn33.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn33.FieldName = "info_teaCardSendDate";
            this.gridColumn33.Name = "gridColumn33";
            this.gridColumn33.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn33.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn33.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn33.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn33.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn33.Visible = true;
            this.gridColumn33.VisibleIndex = 3;
            this.gridColumn33.Width = 159;
            // 
            // gridColumn34
            // 
            this.gridColumn34.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn34.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn34.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn34.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn34.Caption = "gridColumn34";
            this.gridColumn34.FieldName = "info_teaBasicID";
            this.gridColumn34.Name = "gridColumn34";
            this.gridColumn34.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn34.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn34.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn34.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn34.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // gridColumn46
            // 
            this.gridColumn46.Caption = "gridColumn46";
            this.gridColumn46.FieldName = "info_teaCardSeq";
            this.gridColumn46.MinWidth = 10;
            this.gridColumn46.Name = "gridColumn46";
            // 
            // gridControl1_BatchCreate_TeaBasicInfo
            // 
            this.gridControl1_BatchCreate_TeaBasicInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1_BatchCreate_TeaBasicInfo.Location = new System.Drawing.Point(2, 22);
            this.gridControl1_BatchCreate_TeaBasicInfo.MainView = this.gridView5;
            this.gridControl1_BatchCreate_TeaBasicInfo.Name = "gridControl1_BatchCreate_TeaBasicInfo";
            this.gridControl1_BatchCreate_TeaBasicInfo.Size = new System.Drawing.Size(460, 376);
            this.gridControl1_BatchCreate_TeaBasicInfo.TabIndex = 4;
            this.gridControl1_BatchCreate_TeaBasicInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView5});
            // 
            // gridView5
            // 
            this.gridView5.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn24,
            this.gridColumn25,
            this.gridColumn26,
            this.gridColumn27,
            this.gridColumn28,
            this.gridColumn29});
            this.gridView5.GridControl = this.gridControl1_BatchCreate_TeaBasicInfo;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsCustomization.AllowFilter = false;
            this.gridView5.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView5.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn24
            // 
            this.gridColumn24.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn24.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn24.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn24.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn24.Caption = "姓名";
            this.gridColumn24.FieldName = "T_Name";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn24.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn24.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn24.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn24.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 0;
            // 
            // gridColumn25
            // 
            this.gridColumn25.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn25.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn25.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn25.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn25.Caption = "工号";
            this.gridColumn25.FieldName = "T_Number";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn25.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn25.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn25.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn25.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 1;
            // 
            // gridColumn26
            // 
            this.gridColumn26.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn26.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn26.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn26.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn26.Caption = "部门";
            this.gridColumn26.FieldName = "T_Depart";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn26.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn26.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn26.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn26.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 2;
            // 
            // gridColumn27
            // 
            this.gridColumn27.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn27.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn27.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn27.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn27.Caption = "岗位";
            this.gridColumn27.FieldName = "T_Duty";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn27.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn27.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn27.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn27.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 3;
            // 
            // gridColumn28
            // 
            this.gridColumn28.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn28.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn28.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn28.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn28.Caption = "性别";
            this.gridColumn28.FieldName = "T_Sex";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn28.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn28.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn28.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn28.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 4;
            // 
            // gridColumn29
            // 
            this.gridColumn29.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn29.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn29.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn29.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn29.Caption = "gridColumn29";
            this.gridColumn29.FieldName = "T_ID";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn29.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn29.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn29.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn29.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // gridControl_BatchCreate_StuCard
            // 
            this.gridControl_BatchCreate_StuCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_BatchCreate_StuCard.Location = new System.Drawing.Point(2, 22);
            this.gridControl_BatchCreate_StuCard.MainView = this.gridView4;
            this.gridControl_BatchCreate_StuCard.Name = "gridControl_BatchCreate_StuCard";
            this.gridControl_BatchCreate_StuCard.Size = new System.Drawing.Size(460, 376);
            this.gridControl_BatchCreate_StuCard.TabIndex = 3;
            this.gridControl_BatchCreate_StuCard.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView4});
            this.gridControl_BatchCreate_StuCard.Visible = false;
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn45});
            this.gridView4.GridControl = this.gridControl_BatchCreate_StuCard;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsBehavior.Editable = false;
            this.gridView4.OptionsCustomization.AllowFilter = false;
            this.gridView4.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            this.gridView4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView4_KeyDown);
            // 
            // gridColumn18
            // 
            this.gridColumn18.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn18.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn18.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn18.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn18.Caption = "学号";
            this.gridColumn18.FieldName = "info_stuNumber";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn18.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn18.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn18.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn18.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 0;
            this.gridColumn18.Width = 58;
            // 
            // gridColumn19
            // 
            this.gridColumn19.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn19.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn19.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn19.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn19.Caption = "姓名";
            this.gridColumn19.FieldName = "info_stuName";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn19.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn19.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn19.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn19.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 1;
            this.gridColumn19.Width = 71;
            // 
            // gridColumn20
            // 
            this.gridColumn20.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn20.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn20.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn20.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn20.Caption = "卡号";
            this.gridColumn20.FieldName = "info_stuCardNumber";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn20.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn20.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn20.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn20.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 2;
            this.gridColumn20.Width = 94;
            // 
            // gridColumn21
            // 
            this.gridColumn21.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn21.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn21.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn21.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn21.Caption = "持卡人";
            this.gridColumn21.FieldName = "info_stuCardHolder";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn21.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn21.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn21.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn21.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 3;
            this.gridColumn21.Width = 60;
            // 
            // gridColumn22
            // 
            this.gridColumn22.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn22.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn22.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn22.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn22.Caption = "制卡日期";
            this.gridColumn22.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.gridColumn22.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn22.FieldName = "info_stuCardSendDate";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn22.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn22.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn22.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn22.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 4;
            this.gridColumn22.Width = 155;
            // 
            // gridColumn23
            // 
            this.gridColumn23.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn23.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn23.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn23.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn23.Caption = "gridColumn23";
            this.gridColumn23.FieldName = "info_stuBasicID";
            this.gridColumn23.MinWidth = 10;
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn23.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn23.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn23.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn23.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // gridColumn45
            // 
            this.gridColumn45.Caption = "gridColumn45";
            this.gridColumn45.FieldName = "info_stuCardSeq";
            this.gridColumn45.Name = "gridColumn45";
            // 
            // gridControl_BatchCreate_StuBasicInfo
            // 
            this.gridControl_BatchCreate_StuBasicInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl_BatchCreate_StuBasicInfo.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl_BatchCreate_StuBasicInfo.Location = new System.Drawing.Point(2, 22);
            this.gridControl_BatchCreate_StuBasicInfo.MainView = this.advBandedGridView1;
            this.gridControl_BatchCreate_StuBasicInfo.Name = "gridControl_BatchCreate_StuBasicInfo";
            this.gridControl_BatchCreate_StuBasicInfo.Size = new System.Drawing.Size(460, 376);
            this.gridControl_BatchCreate_StuBasicInfo.TabIndex = 2;
            this.gridControl_BatchCreate_StuBasicInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.advBandedGridView1});
            this.gridControl_BatchCreate_StuBasicInfo.Visible = false;
            // 
            // advBandedGridView1
            // 
            this.advBandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.advBandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn41,
            this.gridColumn42,
            this.gridColumn43,
            this.gridColumn44});
            this.advBandedGridView1.GridControl = this.gridControl_BatchCreate_StuBasicInfo;
            this.advBandedGridView1.Name = "advBandedGridView1";
            this.advBandedGridView1.OptionsCustomization.AllowFilter = false;
            this.advBandedGridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.advBandedGridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "幼儿基本信息";
            this.gridBand1.Columns.Add(this.gridColumn10);
            this.gridBand1.Columns.Add(this.gridColumn11);
            this.gridBand1.Columns.Add(this.gridColumn41);
            this.gridBand1.Columns.Add(this.gridColumn16);
            this.gridBand1.Columns.Add(this.gridColumn44);
            this.gridBand1.Columns.Add(this.gridColumn15);
            this.gridBand1.Columns.Add(this.gridColumn9);
            this.gridBand1.Columns.Add(this.gridColumn12);
            this.gridBand1.Columns.Add(this.gridColumn42);
            this.gridBand1.Columns.Add(this.gridColumn14);
            this.gridBand1.Columns.Add(this.gridColumn43);
            this.gridBand1.Columns.Add(this.gridColumn13);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 441;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.Caption = "姓名";
            this.gridColumn10.FieldName = "info_stuName";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn10.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn10.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn10.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn10.OptionsColumn.FixedWidth = true;
            this.gridColumn10.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.Width = 65;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn11.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn11.Caption = "年级号";
            this.gridColumn11.FieldName = "info_stuGrade";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn11.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn11.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn11.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn11.OptionsColumn.FixedWidth = true;
            this.gridColumn11.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.Width = 51;
            // 
            // gridColumn41
            // 
            this.gridColumn41.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn41.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn41.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn41.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn41.Caption = "家庭电话";
            this.gridColumn41.FieldName = "info_stuFatherLinkPhone";
            this.gridColumn41.Name = "gridColumn41";
            this.gridColumn41.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn41.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn41.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn41.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn41.OptionsColumn.FixedWidth = true;
            this.gridColumn41.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn41.Visible = true;
            this.gridColumn41.Width = 72;
            // 
            // gridColumn16
            // 
            this.gridColumn16.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn16.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn16.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn16.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn16.Caption = "入园时间";
            this.gridColumn16.FieldName = "info_stuEntryDate";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn16.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn16.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn16.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn16.OptionsColumn.FixedWidth = true;
            this.gridColumn16.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn16.Visible = true;
            this.gridColumn16.Width = 72;
            // 
            // gridColumn44
            // 
            this.gridColumn44.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn44.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn44.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn44.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn44.Caption = "电子邮件";
            this.gridColumn44.FieldName = "info_stuEMailAddr";
            this.gridColumn44.MinWidth = 10;
            this.gridColumn44.Name = "gridColumn44";
            this.gridColumn44.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn44.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn44.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn44.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn44.OptionsColumn.FixedWidth = true;
            this.gridColumn44.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn44.Visible = true;
            this.gridColumn44.Width = 89;
            // 
            // gridColumn15
            // 
            this.gridColumn15.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn15.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn15.Caption = "托管";
            this.gridColumn15.FieldName = "info_stuEntryStatus";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn15.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn15.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn15.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn15.OptionsColumn.FixedWidth = true;
            this.gridColumn15.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.Width = 92;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.Caption = "学号";
            this.gridColumn9.FieldName = "info_stuNumber";
            this.gridColumn9.MinWidth = 10;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn9.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn9.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn9.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn9.OptionsColumn.FixedWidth = true;
            this.gridColumn9.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn9.RowIndex = 1;
            this.gridColumn9.Visible = true;
            this.gridColumn9.Width = 65;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn12.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn12.Caption = "班级号";
            this.gridColumn12.FieldName = "info_stuClass";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn12.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn12.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn12.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn12.OptionsColumn.FixedWidth = true;
            this.gridColumn12.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn12.RowIndex = 1;
            this.gridColumn12.Visible = true;
            this.gridColumn12.Width = 51;
            // 
            // gridColumn42
            // 
            this.gridColumn42.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn42.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn42.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn42.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn42.Caption = "家庭住址";
            this.gridColumn42.FieldName = "info_stuFamilyAddr";
            this.gridColumn42.MinWidth = 10;
            this.gridColumn42.Name = "gridColumn42";
            this.gridColumn42.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn42.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn42.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn42.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn42.OptionsColumn.FixedWidth = true;
            this.gridColumn42.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn42.RowIndex = 1;
            this.gridColumn42.Visible = true;
            this.gridColumn42.Width = 72;
            // 
            // gridColumn14
            // 
            this.gridColumn14.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn14.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn14.Caption = "生日";
            this.gridColumn14.FieldName = "info_stuBirthDay";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn14.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn14.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn14.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn14.OptionsColumn.FixedWidth = true;
            this.gridColumn14.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn14.RowIndex = 1;
            this.gridColumn14.Visible = true;
            this.gridColumn14.Width = 72;
            // 
            // gridColumn43
            // 
            this.gridColumn43.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn43.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn43.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn43.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn43.Caption = "邮编";
            this.gridColumn43.FieldName = "info_stuZipCode";
            this.gridColumn43.Name = "gridColumn43";
            this.gridColumn43.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn43.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn43.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn43.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn43.OptionsColumn.FixedWidth = true;
            this.gridColumn43.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn43.RowIndex = 1;
            this.gridColumn43.Visible = true;
            this.gridColumn43.Width = 89;
            // 
            // gridColumn13
            // 
            this.gridColumn13.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn13.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn13.Caption = "性别";
            this.gridColumn13.FieldName = "info_stuGender";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn13.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn13.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn13.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn13.OptionsColumn.FixedWidth = true;
            this.gridColumn13.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn13.RowIndex = 1;
            this.gridColumn13.Visible = true;
            this.gridColumn13.Width = 92;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "gridColumn17";
            this.gridColumn17.FieldName = "info_stuID";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn17.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn17.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn17.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn17.OptionsColumn.FixedWidth = true;
            this.gridColumn17.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn17.Visible = true;
            this.gridColumn17.Width = 147;
            // 
            // gridControl_BatchCreate_Class
            // 
            this.gridControl_BatchCreate_Class.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_BatchCreate_Class.Location = new System.Drawing.Point(2, 22);
            this.gridControl_BatchCreate_Class.MainView = this.gridView2;
            this.gridControl_BatchCreate_Class.Name = "gridControl_BatchCreate_Class";
            this.gridControl_BatchCreate_Class.Size = new System.Drawing.Size(460, 376);
            this.gridControl_BatchCreate_Class.TabIndex = 1;
            this.gridControl_BatchCreate_Class.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            this.gridControl_BatchCreate_Class.Visible = false;
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn39,
            this.gridColumn40});
            this.gridView2.GridControl = this.gridControl_BatchCreate_Class;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "班级号(岗位号)";
            this.gridColumn4.FieldName = "info_classNumber";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn4.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn4.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 93;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "班级名(岗位名)";
            this.gridColumn5.FieldName = "info_className";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn5.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn5.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 96;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "年级号(部门号)";
            this.gridColumn6.FieldName = "info_gradeNumber";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn6.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn6.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            this.gridColumn6.Width = 100;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "对应地址";
            this.gridColumn7.FieldName = "info_machineAddr";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn7.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn7.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            this.gridColumn7.Width = 66;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.Caption = "备注";
            this.gridColumn8.FieldName = "info_classRemark";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn8.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn8.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn8.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn8.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            this.gridColumn8.Width = 83;
            // 
            // gridColumn39
            // 
            this.gridColumn39.Caption = "gridColumn39";
            this.gridColumn39.FieldName = "ClassNumber";
            this.gridColumn39.Name = "gridColumn39";
            // 
            // gridColumn40
            // 
            this.gridColumn40.Caption = "gridColumn40";
            this.gridColumn40.FieldName = "GradeNumber";
            this.gridColumn40.Name = "gridColumn40";
            // 
            // gridControl_BatchCreate_Grade
            // 
            this.gridControl_BatchCreate_Grade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_BatchCreate_Grade.Location = new System.Drawing.Point(2, 22);
            this.gridControl_BatchCreate_Grade.MainView = this.gridView1;
            this.gridControl_BatchCreate_Grade.Name = "gridControl_BatchCreate_Grade";
            this.gridControl_BatchCreate_Grade.Size = new System.Drawing.Size(460, 376);
            this.gridControl_BatchCreate_Grade.TabIndex = 0;
            this.gridControl_BatchCreate_Grade.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl_BatchCreate_Grade.Visible = false;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn38});
            this.gridView1.GridControl = this.gridControl_BatchCreate_Grade;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "年级号(部门号)";
            this.gridColumn1.FieldName = "info_gradeNumber";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn1.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 146;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "年级名(部门名)";
            this.gridColumn2.FieldName = "info_gradeName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.OptionsColumn.AllowMove = false;
            this.gridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn2.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 168;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "年级备注(部门备注)";
            this.gridColumn3.FieldName = "info_gradeRemark";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn3.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.OptionsColumn.AllowMove = false;
            this.gridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn3.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 340;
            // 
            // gridColumn38
            // 
            this.gridColumn38.Caption = "gridColumn38";
            this.gridColumn38.FieldName = "GradeNumber";
            this.gridColumn38.Name = "gridColumn38";
            // 
            // xtraTabPage_UpdateGrade
            // 
            this.xtraTabPage_UpdateGrade.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xtraTabPage_UpdateGrade.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabPage_UpdateGrade.Controls.Add(this.splitContainerControl2);
            this.xtraTabPage_UpdateGrade.Controls.Add(this.splitterControl1);
            this.xtraTabPage_UpdateGrade.Name = "xtraTabPage_UpdateGrade";
            this.xtraTabPage_UpdateGrade.PageVisible = false;
            this.xtraTabPage_UpdateGrade.Size = new System.Drawing.Size(682, 400);
            this.xtraTabPage_UpdateGrade.Text = "年班升级";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Location = new System.Drawing.Point(5, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.groupControl9);
            this.splitContainerControl2.Panel1.Text = "splitContainerControl2_Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.groupControl10);
            this.splitContainerControl2.Panel2.Controls.Add(this.panelControl1);
            this.splitContainerControl2.Panel2.Text = "splitContainerControl2_Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(677, 400);
            this.splitContainerControl2.SplitterPosition = 220;
            this.splitContainerControl2.TabIndex = 1;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // groupControl9
            // 
            this.groupControl9.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl9.AppearanceCaption.Options.UseFont = true;
            this.groupControl9.Controls.Add(this.comboBoxEdit_ClassNumber);
            this.groupControl9.Controls.Add(this.notePanel_ClassNumber);
            this.groupControl9.Controls.Add(this.comboBoxEdit_GradeNumber);
            this.groupControl9.Controls.Add(this.notePanel_GradeNumber);
            this.groupControl9.Controls.Add(this.notePanel12);
            this.groupControl9.Controls.Add(this.textEdit_DestClass);
            this.groupControl9.Controls.Add(this.notePanel_DestClass);
            this.groupControl9.Controls.Add(this.comboBoxEdit_SrcClass);
            this.groupControl9.Controls.Add(this.notePanel_SrcClass);
            this.groupControl9.Controls.Add(this.textEdit_DestGrade);
            this.groupControl9.Controls.Add(this.notePanel_DestGrade);
            this.groupControl9.Controls.Add(this.comboBoxEdit_SrcGrade);
            this.groupControl9.Controls.Add(this.notePanel_SrcGrade);
            this.groupControl9.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl9.Location = new System.Drawing.Point(0, 0);
            this.groupControl9.Name = "groupControl9";
            this.groupControl9.Size = new System.Drawing.Size(220, 256);
            this.groupControl9.TabIndex = 0;
            this.groupControl9.Text = "年班变更";
            // 
            // comboBoxEdit_ClassNumber
            // 
            this.comboBoxEdit_ClassNumber.EditValue = "";
            this.comboBoxEdit_ClassNumber.Location = new System.Drawing.Point(112, 152);
            this.comboBoxEdit_ClassNumber.Name = "comboBoxEdit_ClassNumber";
            this.comboBoxEdit_ClassNumber.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_ClassNumber.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_ClassNumber.Size = new System.Drawing.Size(88, 20);
            this.comboBoxEdit_ClassNumber.TabIndex = 39;
            this.comboBoxEdit_ClassNumber.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_ClassNumber_SelectedIndexChanged);
            // 
            // notePanel_ClassNumber
            // 
            this.notePanel_ClassNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_ClassNumber.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_ClassNumber.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_ClassNumber.ForeColor = System.Drawing.Color.Black;
            this.notePanel_ClassNumber.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_ClassNumber.Location = new System.Drawing.Point(16, 152);
            this.notePanel_ClassNumber.MaxRows = 5;
            this.notePanel_ClassNumber.Name = "notePanel_ClassNumber";
            this.notePanel_ClassNumber.ParentAutoHeight = true;
            this.notePanel_ClassNumber.Size = new System.Drawing.Size(80, 22);
            this.notePanel_ClassNumber.TabIndex = 38;
            this.notePanel_ClassNumber.TabStop = false;
            this.notePanel_ClassNumber.Text = " 班级号:";
            // 
            // comboBoxEdit_GradeNumber
            // 
            this.comboBoxEdit_GradeNumber.EditValue = "";
            this.comboBoxEdit_GradeNumber.Location = new System.Drawing.Point(112, 56);
            this.comboBoxEdit_GradeNumber.Name = "comboBoxEdit_GradeNumber";
            this.comboBoxEdit_GradeNumber.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_GradeNumber.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_GradeNumber.Size = new System.Drawing.Size(88, 20);
            this.comboBoxEdit_GradeNumber.TabIndex = 37;
            this.comboBoxEdit_GradeNumber.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_GradeNumber_SelectedIndexChanged);
            // 
            // notePanel_GradeNumber
            // 
            this.notePanel_GradeNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_GradeNumber.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_GradeNumber.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_GradeNumber.ForeColor = System.Drawing.Color.Black;
            this.notePanel_GradeNumber.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_GradeNumber.Location = new System.Drawing.Point(16, 56);
            this.notePanel_GradeNumber.MaxRows = 5;
            this.notePanel_GradeNumber.Name = "notePanel_GradeNumber";
            this.notePanel_GradeNumber.ParentAutoHeight = true;
            this.notePanel_GradeNumber.Size = new System.Drawing.Size(80, 22);
            this.notePanel_GradeNumber.TabIndex = 36;
            this.notePanel_GradeNumber.TabStop = false;
            this.notePanel_GradeNumber.Text = " 年级号:";
            // 
            // notePanel12
            // 
            this.notePanel12.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.notePanel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.notePanel12.ForeColor = System.Drawing.Color.OrangeRed;
            this.notePanel12.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel12.Location = new System.Drawing.Point(2, 22);
            this.notePanel12.MaxRows = 5;
            this.notePanel12.Name = "notePanel12";
            this.notePanel12.ParentAutoHeight = true;
            this.notePanel12.Size = new System.Drawing.Size(216, 23);
            this.notePanel12.TabIndex = 35;
            this.notePanel12.TabStop = false;
            this.notePanel12.Text = "整体调整";
            // 
            // textEdit_DestClass
            // 
            this.textEdit_DestClass.EditValue = "";
            this.textEdit_DestClass.Location = new System.Drawing.Point(112, 216);
            this.textEdit_DestClass.Name = "textEdit_DestClass";
            this.textEdit_DestClass.Size = new System.Drawing.Size(88, 20);
            this.textEdit_DestClass.TabIndex = 34;
            this.textEdit_DestClass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textEdit_DestClass_KeyDown);
            // 
            // notePanel_DestClass
            // 
            this.notePanel_DestClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_DestClass.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_DestClass.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_DestClass.ForeColor = System.Drawing.Color.Black;
            this.notePanel_DestClass.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_DestClass.Location = new System.Drawing.Point(16, 216);
            this.notePanel_DestClass.MaxRows = 5;
            this.notePanel_DestClass.Name = "notePanel_DestClass";
            this.notePanel_DestClass.ParentAutoHeight = true;
            this.notePanel_DestClass.Size = new System.Drawing.Size(80, 22);
            this.notePanel_DestClass.TabIndex = 33;
            this.notePanel_DestClass.TabStop = false;
            this.notePanel_DestClass.Text = "现班级名:";
            // 
            // comboBoxEdit_SrcClass
            // 
            this.comboBoxEdit_SrcClass.EditValue = "";
            this.comboBoxEdit_SrcClass.Location = new System.Drawing.Point(112, 184);
            this.comboBoxEdit_SrcClass.Name = "comboBoxEdit_SrcClass";
            this.comboBoxEdit_SrcClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_SrcClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_SrcClass.Size = new System.Drawing.Size(88, 20);
            this.comboBoxEdit_SrcClass.TabIndex = 32;
            // 
            // notePanel_SrcClass
            // 
            this.notePanel_SrcClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_SrcClass.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_SrcClass.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_SrcClass.ForeColor = System.Drawing.Color.Black;
            this.notePanel_SrcClass.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_SrcClass.Location = new System.Drawing.Point(16, 184);
            this.notePanel_SrcClass.MaxRows = 5;
            this.notePanel_SrcClass.Name = "notePanel_SrcClass";
            this.notePanel_SrcClass.ParentAutoHeight = true;
            this.notePanel_SrcClass.Size = new System.Drawing.Size(80, 22);
            this.notePanel_SrcClass.TabIndex = 31;
            this.notePanel_SrcClass.TabStop = false;
            this.notePanel_SrcClass.Text = "原班级名:";
            // 
            // textEdit_DestGrade
            // 
            this.textEdit_DestGrade.EditValue = "";
            this.textEdit_DestGrade.Location = new System.Drawing.Point(112, 120);
            this.textEdit_DestGrade.Name = "textEdit_DestGrade";
            this.textEdit_DestGrade.Size = new System.Drawing.Size(88, 20);
            this.textEdit_DestGrade.TabIndex = 30;
            this.textEdit_DestGrade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textEdit_DestGrade_KeyDown);
            // 
            // notePanel_DestGrade
            // 
            this.notePanel_DestGrade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_DestGrade.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_DestGrade.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_DestGrade.ForeColor = System.Drawing.Color.Black;
            this.notePanel_DestGrade.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_DestGrade.Location = new System.Drawing.Point(16, 120);
            this.notePanel_DestGrade.MaxRows = 5;
            this.notePanel_DestGrade.Name = "notePanel_DestGrade";
            this.notePanel_DestGrade.ParentAutoHeight = true;
            this.notePanel_DestGrade.Size = new System.Drawing.Size(80, 22);
            this.notePanel_DestGrade.TabIndex = 29;
            this.notePanel_DestGrade.TabStop = false;
            this.notePanel_DestGrade.Text = "现年级名:";
            // 
            // comboBoxEdit_SrcGrade
            // 
            this.comboBoxEdit_SrcGrade.EditValue = "";
            this.comboBoxEdit_SrcGrade.Location = new System.Drawing.Point(112, 88);
            this.comboBoxEdit_SrcGrade.Name = "comboBoxEdit_SrcGrade";
            this.comboBoxEdit_SrcGrade.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_SrcGrade.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_SrcGrade.Size = new System.Drawing.Size(88, 20);
            this.comboBoxEdit_SrcGrade.TabIndex = 28;
            // 
            // notePanel_SrcGrade
            // 
            this.notePanel_SrcGrade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_SrcGrade.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_SrcGrade.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_SrcGrade.ForeColor = System.Drawing.Color.Black;
            this.notePanel_SrcGrade.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_SrcGrade.Location = new System.Drawing.Point(16, 88);
            this.notePanel_SrcGrade.MaxRows = 5;
            this.notePanel_SrcGrade.Name = "notePanel_SrcGrade";
            this.notePanel_SrcGrade.ParentAutoHeight = true;
            this.notePanel_SrcGrade.Size = new System.Drawing.Size(80, 22);
            this.notePanel_SrcGrade.TabIndex = 22;
            this.notePanel_SrcGrade.TabStop = false;
            this.notePanel_SrcGrade.Text = "原年级名:";
            // 
            // groupControl10
            // 
            this.groupControl10.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl10.AppearanceCaption.Options.UseFont = true;
            this.groupControl10.Controls.Add(this.gridControl_StudentAdjust);
            this.groupControl10.Controls.Add(this.notePanel13);
            this.groupControl10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl10.Location = new System.Drawing.Point(0, 40);
            this.groupControl10.Name = "groupControl10";
            this.groupControl10.Size = new System.Drawing.Size(452, 360);
            this.groupControl10.TabIndex = 1;
            this.groupControl10.Text = "不匹配学生信息列表";
            // 
            // gridControl_StudentAdjust
            // 
            this.gridControl_StudentAdjust.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_StudentAdjust.Location = new System.Drawing.Point(2, 45);
            this.gridControl_StudentAdjust.MainView = this.gridView3;
            this.gridControl_StudentAdjust.Name = "gridControl_StudentAdjust";
            this.gridControl_StudentAdjust.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControl_StudentAdjust.Size = new System.Drawing.Size(448, 313);
            this.gridControl_StudentAdjust.TabIndex = 37;
            this.gridControl_StudentAdjust.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            this.gridControl_StudentAdjust.DoubleClick += new System.EventHandler(this.gridControl_StudentAdjust_DoubleClick);
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn49,
            this.gridColumn51,
            this.gridColumn54,
            this.gridColumn55,
            this.gridColumn56});
            this.gridView3.GridControl = this.gridControl_StudentAdjust;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsCustomization.AllowFilter = false;
            this.gridView3.OptionsView.ShowAutoFilterRow = true;
            this.gridView3.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn49
            // 
            this.gridColumn49.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn49.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn49.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn49.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn49.Caption = "是否新生";
            this.gridColumn49.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn49.FieldName = "info_checkType";
            this.gridColumn49.Name = "gridColumn49";
            this.gridColumn49.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn49.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn49.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn49.OptionsColumn.AllowMove = false;
            this.gridColumn49.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn49.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn49.Visible = true;
            this.gridColumn49.VisibleIndex = 0;
            this.gridColumn49.Width = 71;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // gridColumn51
            // 
            this.gridColumn51.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn51.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn51.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn51.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn51.Caption = "姓名";
            this.gridColumn51.FieldName = "info_stuName";
            this.gridColumn51.Name = "gridColumn51";
            this.gridColumn51.OptionsColumn.AllowEdit = false;
            this.gridColumn51.OptionsColumn.AllowFocus = false;
            this.gridColumn51.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn51.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn51.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn51.OptionsColumn.AllowMove = false;
            this.gridColumn51.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn51.OptionsColumn.ReadOnly = true;
            this.gridColumn51.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn51.Visible = true;
            this.gridColumn51.VisibleIndex = 1;
            this.gridColumn51.Width = 48;
            // 
            // gridColumn54
            // 
            this.gridColumn54.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn54.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn54.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn54.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn54.Caption = "年级号";
            this.gridColumn54.FieldName = "info_stuGrade";
            this.gridColumn54.Name = "gridColumn54";
            this.gridColumn54.OptionsColumn.AllowEdit = false;
            this.gridColumn54.OptionsColumn.AllowFocus = false;
            this.gridColumn54.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn54.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn54.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn54.OptionsColumn.AllowMove = false;
            this.gridColumn54.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn54.OptionsColumn.ReadOnly = true;
            this.gridColumn54.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn54.Visible = true;
            this.gridColumn54.VisibleIndex = 2;
            this.gridColumn54.Width = 45;
            // 
            // gridColumn55
            // 
            this.gridColumn55.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn55.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn55.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn55.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn55.Caption = "班级号";
            this.gridColumn55.FieldName = "info_stuClass";
            this.gridColumn55.Name = "gridColumn55";
            this.gridColumn55.OptionsColumn.AllowEdit = false;
            this.gridColumn55.OptionsColumn.AllowFocus = false;
            this.gridColumn55.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn55.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn55.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn55.OptionsColumn.AllowMove = false;
            this.gridColumn55.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn55.OptionsColumn.ReadOnly = true;
            this.gridColumn55.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn55.Visible = true;
            this.gridColumn55.VisibleIndex = 3;
            this.gridColumn55.Width = 48;
            // 
            // gridColumn56
            // 
            this.gridColumn56.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn56.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn56.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn56.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn56.Caption = "入园类型";
            this.gridColumn56.FieldName = "info_type";
            this.gridColumn56.Name = "gridColumn56";
            this.gridColumn56.OptionsColumn.AllowEdit = false;
            this.gridColumn56.OptionsColumn.AllowFocus = false;
            this.gridColumn56.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn56.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn56.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn56.OptionsColumn.AllowMove = false;
            this.gridColumn56.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn56.OptionsColumn.ReadOnly = true;
            this.gridColumn56.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn56.Visible = true;
            this.gridColumn56.VisibleIndex = 4;
            this.gridColumn56.Width = 61;
            // 
            // notePanel13
            // 
            this.notePanel13.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.notePanel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.notePanel13.ForeColor = System.Drawing.Color.OrangeRed;
            this.notePanel13.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel13.Location = new System.Drawing.Point(2, 22);
            this.notePanel13.MaxRows = 5;
            this.notePanel13.Name = "notePanel13";
            this.notePanel13.ParentAutoHeight = true;
            this.notePanel13.Size = new System.Drawing.Size(448, 23);
            this.notePanel13.TabIndex = 36;
            this.notePanel13.TabStop = false;
            this.notePanel13.Text = "学生个别调整";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton_Submit);
            this.panelControl1.Controls.Add(this.simpleButton_LoadTable);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(452, 40);
            this.panelControl1.TabIndex = 0;
            // 
            // simpleButton_Submit
            // 
            this.simpleButton_Submit.Location = new System.Drawing.Point(120, 8);
            this.simpleButton_Submit.Name = "simpleButton_Submit";
            this.simpleButton_Submit.Size = new System.Drawing.Size(96, 23);
            this.simpleButton_Submit.TabIndex = 3;
            this.simpleButton_Submit.Text = "提交调整操作";
            this.simpleButton_Submit.Click += new System.EventHandler(this.simpleButton_Submit_Click);
            // 
            // simpleButton_LoadTable
            // 
            this.simpleButton_LoadTable.Location = new System.Drawing.Point(8, 8);
            this.simpleButton_LoadTable.Name = "simpleButton_LoadTable";
            this.simpleButton_LoadTable.Size = new System.Drawing.Size(104, 23);
            this.simpleButton_LoadTable.TabIndex = 2;
            this.simpleButton_LoadTable.Text = "载入学生调整表";
            this.simpleButton_LoadTable.Click += new System.EventHandler(this.simpleButton_LoadTable_Click);
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(0, 0);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 400);
            this.splitterControl1.TabIndex = 0;
            this.splitterControl1.TabStop = false;
            // 
            // xtraTabPage_TerminalServ
            // 
            this.xtraTabPage_TerminalServ.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xtraTabPage_TerminalServ.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabPage_TerminalServ.Controls.Add(this.gridControl_SessionUser);
            this.xtraTabPage_TerminalServ.Name = "xtraTabPage_TerminalServ";
            this.xtraTabPage_TerminalServ.Size = new System.Drawing.Size(682, 400);
            this.xtraTabPage_TerminalServ.Text = "终端服务管理";
            // 
            // gridControl_SessionUser
            // 
            this.gridControl_SessionUser.Location = new System.Drawing.Point(136, 80);
            this.gridControl_SessionUser.MainView = this.gridView9;
            this.gridControl_SessionUser.Name = "gridControl_SessionUser";
            this.gridControl_SessionUser.Size = new System.Drawing.Size(448, 232);
            this.gridControl_SessionUser.TabIndex = 0;
            this.gridControl_SessionUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView9,
            this.gridView8});
            // 
            // gridView9
            // 
            this.gridView9.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn50,
            this.gridColumn52,
            this.gridColumn53,
            this.gridColumn57});
            this.gridView9.GridControl = this.gridControl_SessionUser;
            this.gridView9.Name = "gridView9";
            this.gridView9.OptionsCustomization.AllowFilter = false;
            this.gridView9.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView9.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn50
            // 
            this.gridColumn50.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn50.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn50.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn50.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn50.Caption = "登陆用户";
            this.gridColumn50.FieldName = "session_LoginUser";
            this.gridColumn50.Name = "gridColumn50";
            this.gridColumn50.OptionsColumn.AllowEdit = false;
            this.gridColumn50.OptionsColumn.AllowFocus = false;
            this.gridColumn50.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn50.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn50.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn50.OptionsColumn.AllowMove = false;
            this.gridColumn50.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn50.OptionsColumn.FixedWidth = true;
            this.gridColumn50.OptionsColumn.ReadOnly = true;
            this.gridColumn50.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn50.Visible = true;
            this.gridColumn50.VisibleIndex = 0;
            // 
            // gridColumn52
            // 
            this.gridColumn52.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn52.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn52.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn52.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn52.Caption = "登陆IP";
            this.gridColumn52.FieldName = "session_LoginIP";
            this.gridColumn52.Name = "gridColumn52";
            this.gridColumn52.OptionsColumn.AllowEdit = false;
            this.gridColumn52.OptionsColumn.AllowFocus = false;
            this.gridColumn52.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn52.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn52.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn52.OptionsColumn.AllowMove = false;
            this.gridColumn52.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn52.OptionsColumn.FixedWidth = true;
            this.gridColumn52.OptionsColumn.ReadOnly = true;
            this.gridColumn52.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn52.Visible = true;
            this.gridColumn52.VisibleIndex = 1;
            // 
            // gridColumn53
            // 
            this.gridColumn53.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn53.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn53.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn53.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn53.Caption = "登陆时间";
            this.gridColumn53.FieldName = "session_LoginDate";
            this.gridColumn53.Name = "gridColumn53";
            this.gridColumn53.OptionsColumn.AllowEdit = false;
            this.gridColumn53.OptionsColumn.AllowFocus = false;
            this.gridColumn53.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn53.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn53.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn53.OptionsColumn.AllowMove = false;
            this.gridColumn53.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn53.OptionsColumn.FixedWidth = true;
            this.gridColumn53.OptionsColumn.ReadOnly = true;
            this.gridColumn53.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn53.Visible = true;
            this.gridColumn53.VisibleIndex = 2;
            // 
            // gridColumn57
            // 
            this.gridColumn57.Caption = "MAC地址";
            this.gridColumn57.FieldName = "session_LoginMac";
            this.gridColumn57.Name = "gridColumn57";
            // 
            // gridView8
            // 
            this.gridView8.GridControl = this.gridControl_SessionUser;
            this.gridView8.Name = "gridView8";
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xtraTabPage4.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabPage4.Controls.Add(this.groupControl11);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(682, 400);
            this.xtraTabPage4.Text = "数据备份";
            // 
            // groupControl11
            // 
            this.groupControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl11.Appearance.Options.UseFont = true;
            this.groupControl11.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl11.AppearanceCaption.Options.UseFont = true;
            this.groupControl11.Controls.Add(this.groupControl12);
            this.groupControl11.Controls.Add(this.tbxBackUpRoot);
            this.groupControl11.Controls.Add(this.smbRoot);
            this.groupControl11.Location = new System.Drawing.Point(120, 48);
            this.groupControl11.Name = "groupControl11";
            this.groupControl11.Size = new System.Drawing.Size(448, 280);
            this.groupControl11.TabIndex = 0;
            this.groupControl11.Text = "数据备份";
            // 
            // groupControl12
            // 
            this.groupControl12.Controls.Add(this.rbtDefault);
            this.groupControl12.Controls.Add(this.rbtIdle);
            this.groupControl12.Controls.Add(this.rbtStart);
            this.groupControl12.Controls.Add(this.smbBackUp);
            this.groupControl12.Location = new System.Drawing.Point(32, 64);
            this.groupControl12.Name = "groupControl12";
            this.groupControl12.Size = new System.Drawing.Size(384, 192);
            this.groupControl12.TabIndex = 4;
            this.groupControl12.Text = "备份方案";
            // 
            // rbtDefault
            // 
            this.rbtDefault.Checked = true;
            this.rbtDefault.Location = new System.Drawing.Point(80, 96);
            this.rbtDefault.Name = "rbtDefault";
            this.rbtDefault.Size = new System.Drawing.Size(136, 24);
            this.rbtDefault.TabIndex = 6;
            this.rbtDefault.TabStop = true;
            this.rbtDefault.Text = "系统默认的备份";
            // 
            // rbtIdle
            // 
            this.rbtIdle.Location = new System.Drawing.Point(80, 64);
            this.rbtIdle.Name = "rbtIdle";
            this.rbtIdle.Size = new System.Drawing.Size(200, 24);
            this.rbtIdle.TabIndex = 5;
            this.rbtIdle.Text = "每当CPU闲置时进行备份";
            // 
            // rbtStart
            // 
            this.rbtStart.Location = new System.Drawing.Point(80, 32);
            this.rbtStart.Name = "rbtStart";
            this.rbtStart.Size = new System.Drawing.Size(200, 24);
            this.rbtStart.TabIndex = 4;
            this.rbtStart.Text = "每当重新启动系统时进行备份";
            // 
            // smbBackUp
            // 
            this.smbBackUp.Location = new System.Drawing.Point(136, 136);
            this.smbBackUp.Name = "smbBackUp";
            this.smbBackUp.Size = new System.Drawing.Size(85, 23);
            this.smbBackUp.TabIndex = 3;
            this.smbBackUp.Text = "执行备份";
            this.smbBackUp.Click += new System.EventHandler(this.smbBackUp_Click);
            // 
            // tbxBackUpRoot
            // 
            this.tbxBackUpRoot.Location = new System.Drawing.Point(128, 40);
            this.tbxBackUpRoot.Name = "tbxBackUpRoot";
            this.tbxBackUpRoot.ReadOnly = true;
            this.tbxBackUpRoot.Size = new System.Drawing.Size(288, 22);
            this.tbxBackUpRoot.TabIndex = 3;
            // 
            // smbRoot
            // 
            this.smbRoot.Location = new System.Drawing.Point(32, 40);
            this.smbRoot.Name = "smbRoot";
            this.smbRoot.Size = new System.Drawing.Size(85, 23);
            this.smbRoot.TabIndex = 2;
            this.smbRoot.Text = "备份路径";
            this.smbRoot.Click += new System.EventHandler(this.smbRoot_Click);
            // 
            // xtraTabPage5
            // 
            this.xtraTabPage5.Controls.Add(this.groupBox1);
            this.xtraTabPage5.Name = "xtraTabPage5";
            this.xtraTabPage5.Size = new System.Drawing.Size(682, 400);
            this.xtraTabPage5.Text = "数据上传";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbxUploadUrl);
            this.groupBox1.Location = new System.Drawing.Point(128, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 216);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据上传";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "确定";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "地址:";
            // 
            // tbxUploadUrl
            // 
            this.tbxUploadUrl.Location = new System.Drawing.Point(60, 46);
            this.tbxUploadUrl.Name = "tbxUploadUrl";
            this.tbxUploadUrl.Size = new System.Drawing.Size(320, 22);
            this.tbxUploadUrl.TabIndex = 0;
            // 
            // xtraTabPage6
            // 
            this.xtraTabPage6.Controls.Add(this.groupControl13);
            this.xtraTabPage6.Name = "xtraTabPage6";
            this.xtraTabPage6.Size = new System.Drawing.Size(682, 400);
            this.xtraTabPage6.Text = "监控配置";
            // 
            // groupControl13
            // 
            this.groupControl13.Controls.Add(this.gridControl1);
            this.groupControl13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl13.Location = new System.Drawing.Point(0, 0);
            this.groupControl13.Name = "groupControl13";
            this.groupControl13.Size = new System.Drawing.Size(682, 400);
            this.groupControl13.TabIndex = 0;
            this.groupControl13.Text = "摄像机列表(按回车键新增)";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 22);
            this.gridControl1.MainView = this.gridView10;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemComboBox2,
            this.repositoryItemComboBox3,
            this.repositoryItemButtonEdit1,
            this.repositoryItemButtonEdit2,
            this.repositoryItemComboBox4,
            this.repositoryItemButtonEdit3});
            this.gridControl1.Size = new System.Drawing.Size(678, 376);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView10});
            // 
            // gridView10
            // 
            this.gridView10.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn58,
            this.gridColumn59,
            this.gridColumn60,
            this.gridColumn61,
            this.gridColumn62,
            this.gridColumn63,
            this.gridColumn64});
            this.gridView10.GridControl = this.gridControl1;
            this.gridView10.Name = "gridView10";
            this.gridView10.OptionsView.ShowGroupPanel = false;
            this.gridView10.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView10_KeyDown);
            // 
            // gridColumn58
            // 
            this.gridColumn58.Caption = "门口机";
            this.gridColumn58.ColumnEdit = this.repositoryItemComboBox4;
            this.gridColumn58.FieldName = "machineName";
            this.gridColumn58.Name = "gridColumn58";
            this.gridColumn58.Visible = true;
            this.gridColumn58.VisibleIndex = 0;
            // 
            // repositoryItemComboBox4
            // 
            this.repositoryItemComboBox4.AutoHeight = false;
            this.repositoryItemComboBox4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox4.Name = "repositoryItemComboBox4";
            // 
            // gridColumn59
            // 
            this.gridColumn59.Caption = "摄像机";
            this.gridColumn59.ColumnEdit = this.repositoryItemComboBox1;
            this.gridColumn59.FieldName = "cameraName";
            this.gridColumn59.Name = "gridColumn59";
            this.gridColumn59.Visible = true;
            this.gridColumn59.VisibleIndex = 1;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "线路1",
            "线路2",
            "线路3",
            "线路4"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // gridColumn60
            // 
            this.gridColumn60.Caption = "摄像机地址";
            this.gridColumn60.FieldName = "cameraAddr";
            this.gridColumn60.Name = "gridColumn60";
            this.gridColumn60.Visible = true;
            this.gridColumn60.VisibleIndex = 2;
            // 
            // gridColumn61
            // 
            this.gridColumn61.Caption = "视频码流";
            this.gridColumn61.ColumnEdit = this.repositoryItemComboBox2;
            this.gridColumn61.FieldName = "cameraStream";
            this.gridColumn61.Name = "gridColumn61";
            this.gridColumn61.Visible = true;
            this.gridColumn61.VisibleIndex = 3;
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.Items.AddRange(new object[] {
            "RTSP"});
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            // 
            // gridColumn62
            // 
            this.gridColumn62.Caption = "视频编码";
            this.gridColumn62.ColumnEdit = this.repositoryItemComboBox3;
            this.gridColumn62.FieldName = "cameraEncoding";
            this.gridColumn62.Name = "gridColumn62";
            this.gridColumn62.Visible = true;
            this.gridColumn62.VisibleIndex = 4;
            // 
            // repositoryItemComboBox3
            // 
            this.repositoryItemComboBox3.AutoHeight = false;
            this.repositoryItemComboBox3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox3.Items.AddRange(new object[] {
            "H.264"});
            this.repositoryItemComboBox3.Name = "repositoryItemComboBox3";
            // 
            // gridColumn63
            // 
            this.gridColumn63.Caption = "操作1";
            this.gridColumn63.ColumnEdit = this.repositoryItemButtonEdit1;
            this.gridColumn63.FieldName = "op1";
            this.gridColumn63.Name = "gridColumn63";
            this.gridColumn63.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gridColumn63.Visible = true;
            this.gridColumn63.VisibleIndex = 5;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "保存", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.repositoryItemButtonEdit1.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEdit1_ButtonClick);
            // 
            // gridColumn64
            // 
            this.gridColumn64.Caption = "操作2";
            this.gridColumn64.ColumnEdit = this.repositoryItemButtonEdit2;
            this.gridColumn64.FieldName = "op2";
            this.gridColumn64.Name = "gridColumn64";
            this.gridColumn64.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gridColumn64.Visible = true;
            this.gridColumn64.VisibleIndex = 6;
            // 
            // repositoryItemButtonEdit2
            // 
            this.repositoryItemButtonEdit2.AutoHeight = false;
            this.repositoryItemButtonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "删除", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.repositoryItemButtonEdit2.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            this.repositoryItemButtonEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit2.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEdit2_ButtonClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem_Refresh,
            this.barButtonItem_Modify,
            this.barButtonItem_Delete,
            this.barButtonItem1,
            this.barButtonItem_Add,
            this.barButtonItem_Save,
            this.barButtonItem_DeleteSession});
            this.barManager1.MaxItemId = 7;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(688, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 429);
            this.barDockControlBottom.Size = new System.Drawing.Size(688, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 429);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(688, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 429);
            // 
            // barButtonItem_Refresh
            // 
            this.barButtonItem_Refresh.Caption = "刷新记录";
            this.barButtonItem_Refresh.Id = 0;
            this.barButtonItem_Refresh.Name = "barButtonItem_Refresh";
            this.barButtonItem_Refresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Refresh_ItemClick);
            // 
            // barButtonItem_Modify
            // 
            this.barButtonItem_Modify.Caption = "修改记录";
            this.barButtonItem_Modify.Id = 1;
            this.barButtonItem_Modify.Name = "barButtonItem_Modify";
            this.barButtonItem_Modify.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Modify_ItemClick);
            // 
            // barButtonItem_Delete
            // 
            this.barButtonItem_Delete.Caption = "删除记录";
            this.barButtonItem_Delete.Id = 2;
            this.barButtonItem_Delete.Name = "barButtonItem_Delete";
            this.barButtonItem_Delete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Delete_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 3;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem_Add
            // 
            this.barButtonItem_Add.Caption = "添加条空记录";
            this.barButtonItem_Add.Id = 4;
            this.barButtonItem_Add.Name = "barButtonItem_Add";
            this.barButtonItem_Add.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Add_ItemClick);
            // 
            // barButtonItem_Save
            // 
            this.barButtonItem_Save.Caption = "保存这条记录";
            this.barButtonItem_Save.Id = 5;
            this.barButtonItem_Save.Name = "barButtonItem_Save";
            this.barButtonItem_Save.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Save_ItemClick);
            // 
            // barButtonItem_DeleteSession
            // 
            this.barButtonItem_DeleteSession.Caption = "断开";
            this.barButtonItem_DeleteSession.Id = 6;
            this.barButtonItem_DeleteSession.Name = "barButtonItem_DeleteSession";
            this.barButtonItem_DeleteSession.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_DeleteSession_ItemClick);
            // 
            // repositoryItemButtonEdit3
            // 
            this.repositoryItemButtonEdit3.AutoHeight = false;
            this.repositoryItemButtonEdit3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.repositoryItemButtonEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.SpinRight)});
            this.repositoryItemButtonEdit3.Name = "repositoryItemButtonEdit3";
            this.repositoryItemButtonEdit3.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit3.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEdit3_ButtonClick);
            // 
            // popupMenu2
            // 
            this.popupMenu2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_DeleteSession)});
            this.popupMenu2.Manager = this.barManager1;
            this.popupMenu2.Name = "popupMenu2";
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Refresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Add),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Save),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Modify),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Delete)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // OptionsForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(688, 429);
            this.Controls.Add(this.xtraTabControl_Options);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OptionsForm";
            this.ShowInTaskbar = false;
            this.Text = "选项";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_Options)).EndInit();
            this.xtraTabControl_Options.ResumeLayout(false);
            this.xtraTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_DBUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_DBPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_DBName.Properties)).EndInit();
            this.xtraTabPage_ComPortSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_ComPortSet)).EndInit();
            this.groupControl_ComPortSet.ResumeLayout(false);
            this.xtraTabPage_AutoShutDown.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_DutyStartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).EndInit();
            this.xtraTabPage_AutoSendSmsTimeSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_SMSMorningTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_SMSNightTime.Properties)).EndInit();
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_NewPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_ConfirmPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_OldPwd.Properties)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_UpdateAddress.Properties)).EndInit();
            this.xtraTabPage_BatchCreate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl8)).EndInit();
            this.groupControl8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_ClassVol.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_BatchCreate_TerminalNumbers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_BatchCreate_ClassNumbers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).EndInit();
            this.groupControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_BatchCreate_CardNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_BatchCreate_Load.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_BatchCreate_Type.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_BatchCreate_Number.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_BatchCreate_Name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_BatchCreate_Class.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_BatchCreate_Grade.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).EndInit();
            this.groupControl7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_BatchCreate_Machine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_BatchCreate_TeaCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1_BatchCreate_TeaBasicInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_BatchCreate_StuCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_BatchCreate_StuBasicInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_BatchCreate_Class)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_BatchCreate_Grade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.xtraTabPage_UpdateGrade.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl9)).EndInit();
            this.groupControl9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_ClassNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_GradeNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_DestClass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_SrcClass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_DestGrade.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_SrcGrade.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl10)).EndInit();
            this.groupControl10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_StudentAdjust)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.xtraTabPage_TerminalServ.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_SessionUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView8)).EndInit();
            this.xtraTabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl11)).EndInit();
            this.groupControl11.ResumeLayout(false);
            this.groupControl11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl12)).EndInit();
            this.groupControl12.ResumeLayout(false);
            this.xtraTabPage5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.xtraTabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl13)).EndInit();
            this.groupControl13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void OptionsForm_Load(object sender, System.EventArgs e)
		{
			if ( Thread.CurrentPrincipal.Identity.Name.ToLower() != "admin" )
			{
				xtraTabPage_ComPortSet.PageVisible = false;
				//xtraTabPage_BatchCreate.PageVisible = false;
			}
			else
			{
				comboBoxEdit_BatchCreate_Grade.SelectedItem = "全部";
				foreach(DataRow getGradeList in optionSystem.getGradeInfo("","",false).Tables[0].Rows)
				{
					comboBoxEdit_BatchCreate_Grade.Properties.Items.AddRange(
						new object[]{getGradeList[1].ToString()});
				}
			}

			settings = ConfigurationManager.GetConfiguration("CustomizeSettings") as ArrayList;

			isAutoShutDown = Convert.ToBoolean((settings[2] as XmlNode[])[1].InnerText);
			shutDownTime = Convert.ToDateTime((settings[3] as XmlNode[])[1].InnerText);
			
			textEdit_UpdateAddress.Text = (settings[6] as XmlNode[])[1].InnerText;

			if(isAutoShutDown)
			{
				notePanel2.Visible = true;
				checkEdit1.Enabled = true;
				timeEdit_DutyStartTime.Time = shutDownTime;
				checkEdit2.Checked = true;
				checkEdit1.Checked = true;
			}
			else
			{
				notePanel2.Visible = false;
				checkEdit1.Enabled = false;
				timeEdit_DutyStartTime.Time = DateTime.Now;
				checkEdit1.Checked = false;
				checkEdit2.Checked = false;
			}

			int COMNum = Convert.ToInt32((settings[1] as XmlNode[])[1].InnerText);
			if(COMNum == 1)
			{
				radioButton1.Checked = true;
			}
			else if(COMNum == 2)
			{
				radioButton2.Checked = true;
			}
			else if(COMNum == 3)
			{
				radioButton3.Checked = true;
			}
			else if(COMNum == 4)
			{
				radioButton4.Checked = true;
			}

			DataTable dtGradeNumberList = optionSystem.GetGradeNumberList();
			comboBoxEdit_GradeNumber.Properties.Items.Clear();

			if ( dtGradeNumberList.Rows.Count > 0 )
			{
				foreach(DataRow dr in dtGradeNumberList.Rows)
				{
					comboBoxEdit_GradeNumber.Properties.Items.AddRange(
						new object[]{dr["info_gradeNumber"].ToString()});
				}

				comboBoxEdit_GradeNumber.SelectedIndex = 0;
			}
			else comboBoxEdit_GradeNumber.Properties.Items.AddRange(new object[]{"无法获取年级信息！"});

			DataTable dtLoginUser = new UtilSystem().GetSessionDetails();

			if ( dtLoginUser != null ) gridControl_SessionUser.DataSource = dtLoginUser;

		}

		#region set auto shutdown computer
		private void simpleButton3_Click(object sender, System.EventArgs e)
		{
			settings = ConfigurationManager.GetConfiguration("CustomizeSettings") as ArrayList;

			if(checkEdit2.Checked)
			{
				(settings[2] as XmlNode[])[1].InnerText = checkEdit1.Checked.ToString();
				(settings[3] as XmlNode[])[1].InnerText = timeEdit_DutyStartTime.Time.ToString();
				ConfigurationManager.WriteConfiguration("CustomizeSettings",settings);
				loginForm.timer_AutoShutDown.Enabled = true;
				notePanel2.Visible = true;
			}
			else
			{
				(settings[2] as XmlNode[])[1].InnerText = checkEdit1.Checked.ToString();
				(settings[3] as XmlNode[])[1].InnerText = timeEdit_DutyStartTime.Time.ToString();
				ConfigurationManager.WriteConfiguration("CustomizeSettings",settings);
				loginForm.timer_AutoShutDown.Enabled = false;
				notePanel2.Visible = false;
			}

			MessageBox.Show("保存成功.","系统信息!",
				MessageBoxButtons.OK,MessageBoxIcon.Information);
			this.Close();
		}

		private void simpleButton5_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void checkEdit2_CheckedChanged(object sender, System.EventArgs e)
		{
			if(checkEdit2.Checked)
			{
				checkEdit1.Enabled = true;
			}
			else
			{
				checkEdit1.Checked = false;
				checkEdit1.Enabled = false;
			}
		}
		#endregion

		#region set com port
		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			settings = ConfigurationManager.GetConfiguration("CustomizeSettings") as ArrayList;

			int COMNum = 1;
			if(radioButton1.Checked == true)
			{
				COMNum = 1;
			}
			else if(radioButton2.Checked == true)
			{
				COMNum = 2;
			}
			else if(radioButton3.Checked == true)
			{
				COMNum = 3;
			}
			else if(radioButton4.Checked == true)
			{
				COMNum = 4;
			}
		
			(settings[1] as XmlNode[])[1].InnerText = COMNum.ToString();
			ConfigurationManager.WriteConfiguration("CustomizeSettings",settings);

			MessageBox.Show("保存成功.","系统信息!",
				MessageBoxButtons.OK,MessageBoxIcon.Information);
			this.Close();
		}

		private void simpleButton6_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#endregion

		#region change user password
		private void simpleButton8_Click(object sender, System.EventArgs e)
		{
			if(!textEdit_NewPwd.Text.Equals(textEdit_ConfirmPwd.Text))
			{
				MessageBox.Show("二次密码输入不一致.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);

				return;
			}

			if(new UserSystem().ChangePwd(textEdit_OldPwd.Text,textEdit_NewPwd.Text)==-1)
			{
				MessageBox.Show("原始密码错误.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("密码修改成功.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				this.Close();
			}
		}

		private void simpleButton9_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#endregion

		#region set SMS auto send time
		private void simpleButton4_Click(object sender, System.EventArgs e)
		{
			settings = ConfigurationManager.GetConfiguration("CustomizeSettings") as ArrayList;

			(settings[4] as XmlNode[])[1].InnerText = timeEdit_SMSMorningTime.Time.ToString();
			(settings[5] as XmlNode[])[1].InnerText = timeEdit_SMSNightTime.Time.ToString();
			ConfigurationManager.WriteConfiguration("CustomizeSettings",settings);
			notePanel4.Visible = true;

			MessageBox.Show("保存成功.","系统信息!",
				MessageBoxButtons.OK,MessageBoxIcon.Information);
			this.Close();
		}

		private void simpleButton7_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#endregion

		#region set auto update webaddress
		private void simpleButton2_Click(object sender, System.EventArgs e)
		{
			if(textEdit_UpdateAddress.Text.Trim()==string.Empty)
			{
				MessageBox.Show("地址不能为空.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}

			settings = ConfigurationManager.GetConfiguration("CustomizeSettings") as ArrayList;

			(settings[6] as XmlNode[])[1].InnerText = textEdit_UpdateAddress.Text;
			ConfigurationManager.WriteConfiguration("CustomizeSettings",settings);

			MessageBox.Show("保存成功.","系统信息!",
				MessageBoxButtons.OK,MessageBoxIcon.Information);
			this.Close();
		}

		private void simpleButton10_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#endregion

		#region set db connection string
		private void simpleButton11_Click(object sender, System.EventArgs e)
		{
			string DBName=textEdit_DBName.Text.Trim();
			string DBUser=textEdit_DBUser.Text.Trim();
			string DBUserPwd=textEdit_DBPwd.Text.Trim();

			SqlConnection sqlConn = null;

			if(DBName.Equals(string.Empty)||DBUser.Equals(string.Empty))
			{
				MessageBox.Show("请检查填写是否合法.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}

			try
			{
				sqlConn = new SqlConnection("Data Source = "+DBName
					+";Persist Security Info = false;User ID = "+DBUser
					+";Password = "+DBUserPwd+";Initial Catalog = CTPPDB;");
				sqlConn.Open();
				MessageBox.Show("成功连接数据库!","成功!",MessageBoxButtons.OK,
					MessageBoxIcon.Information);
				sqlConn.Close();
			}
			catch(Exception ex)
			{
				if(sqlConn!=null)
				{
					sqlConn.Close();
				}

				MessageBox.Show(ex.Message+"连接数据库失败,请查找原因!","系统信息!",MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
		}

		private void simpleButton12_Click(object sender, System.EventArgs e)
		{
			string DBName=textEdit_DBName.Text.Trim();
			string DBUser=textEdit_DBUser.Text.Trim();
			string DBUserPwd=textEdit_DBPwd.Text.Trim();

			if(DBName.Equals(string.Empty)||DBUser.Equals(string.Empty))
			{
				MessageBox.Show("请检查填写是否合法.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}

			try
			{
				DatabaseSettings dbSettings = (DatabaseSettings)ConfigurationManager.GetConfiguration("dataConfiguration");
				dbSettings.ConnectionStrings[0].Parameters["server"].Value=DBName;
				dbSettings.ConnectionStrings[0].Parameters["User ID"].Value=DBUser;
				dbSettings.ConnectionStrings[0].Parameters["Password"].Value=DBUserPwd;

				ConfigurationManager.WriteConfiguration("dataConfiguration",dbSettings);

				MessageBox.Show("保存成功!","系统信息!",MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message,"系统信息!",MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
		}
		#endregion

		#region batch data created
		private void comboBoxEdit_BatchCreate_Grade_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			comboBoxEdit_BatchCreate_Class.Properties.Items.Clear();
			comboBoxEdit_BatchCreate_Class.Properties.Items.AddRange(new object[]{"全部"});
			comboBoxEdit_BatchCreate_Class.SelectedItem = "全部";
			
			if(optionSystem.getGradeInfo(comboBoxEdit_BatchCreate_Grade.SelectedItem.ToString(),"",isForStu).Tables[0].Rows.Count > 0)
			{
				//根据年级选择获取年级编号
				getGradeNumberFromCombo = optionSystem.getGradeInfo(
					comboBoxEdit_BatchCreate_Grade.SelectedItem.ToString(),"",isForStu).Tables[0].Rows[0][0].ToString();
				foreach(DataRow getClassList in optionSystem.getClassInfo("","",
					getGradeNumberFromCombo,isForStu).Tables[0].Rows)
				{
					comboBoxEdit_BatchCreate_Class.Properties.Items.AddRange(
						new object[]{getClassList[1].ToString()});
				}
			}	

			if ( comboBoxEdit_BatchCreate_Type.SelectedItem.ToString().Equals("教师基本信息表") ||
				comboBoxEdit_BatchCreate_Type.SelectedItem.ToString().Equals("教师卡号表"))
				getGradeNumberFromCombo = comboBoxEdit_BatchCreate_Grade.SelectedItem.ToString();

			if ( comboBoxEdit_BatchCreate_Grade.SelectedItem.ToString().Equals("全部") )
			{
				getGradeNumberFromCombo = "";
				getClassNumberFromCombo = "";
			}
			
			if ( getName.Equals(string.Empty) && getSelNumber.Equals(string.Empty) )
				DataListShow(getGradeNumberFromCombo,getClassNumberFromCombo,getName,getSelNumber,getCardNumber);

		}

		private void comboBoxEdit_BatchCreate_Class_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( comboBoxEdit_BatchCreate_Class.SelectedItem.ToString().Equals("全部") )
				getClassNumberFromCombo = "";
			else
			{
				if ( comboBoxEdit_BatchCreate_Type.SelectedItem.ToString().Equals("教师基本信息表") ||
					comboBoxEdit_BatchCreate_Type.SelectedItem.ToString().Equals("教师卡号表"))
					getClassNumberFromCombo = comboBoxEdit_BatchCreate_Class.SelectedItem.ToString();
				else
					getClassNumberFromCombo = optionSystem.getClassInfo(
						comboBoxEdit_BatchCreate_Class.SelectedItem.ToString(),"","",isForStu).Tables[0].Rows[0][0].ToString();
			}
			
			if ( getName.Equals(string.Empty) && getSelNumber.Equals(string.Empty) )
				DataListShow(getGradeNumberFromCombo,getClassNumberFromCombo,getName,getSelNumber,getCardNumber);
		}

		private void textEdit_BatchCreate_Name_EditValueChanged(object sender, System.EventArgs e)
		{
			getName = textEdit_BatchCreate_Name.Text.Trim();

			if ( getSelNumber.Equals(string.Empty) )
			{
				if ( getName.Equals(string.Empty) )
					DataListShow(getGradeNumberFromCombo,getClassNumberFromCombo,"","",getCardNumber);
				else
					DataListShow("","",getName,getSelNumber,getCardNumber);
			}
		}

		private void textEdit_BatchCreate_Number_EditValueChanged(object sender, System.EventArgs e)
		{
			getSelNumber = textEdit_BatchCreate_Number.Text.Trim();

			if ( getSelNumber.Equals(string.Empty) )
				DataListShow(getGradeNumberFromCombo,getClassNumberFromCombo,"","",getCardNumber);
			else
				DataListShow("","","",getSelNumber,getCardNumber);
		}

		private void textEdit_BatchCreate_CardNumber_EditValueChanged(object sender, System.EventArgs e)
		{
			getCardNumber = textEdit_BatchCreate_CardNumber.Text.Trim();

			DataListShow(getGradeNumberFromCombo,getClassNumberFromCombo,getName,getSelNumber,getCardNumber);
		}

		private void comboBoxEdit_BatchCreate_Type_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( comboBoxEdit_BatchCreate_Type.SelectedItem.ToString().Equals("学生基本信息表") ||
				comboBoxEdit_BatchCreate_Type.SelectedItem.ToString().Equals("学生卡号表") )
			{
				comboBoxEdit_BatchCreate_Grade.Properties.Items.Clear();
				comboBoxEdit_BatchCreate_Grade.Properties.Items.AddRange(new object[]{"全部"});
				comboBoxEdit_BatchCreate_Grade.SelectedItem = "全部";
				foreach(DataRow getGradeList in optionSystem.getGradeInfo("","",true).Tables[0].Rows)
				{
					comboBoxEdit_BatchCreate_Grade.Properties.Items.AddRange(
						new object[]{getGradeList[1].ToString()});
				}

				isForStu = true;

				DataListShow(getGradeNumberFromCombo,getClassNumberFromCombo,getName,getSelNumber,getCardNumber);
			}
			else
			{
				comboBoxEdit_BatchCreate_Grade.Properties.Items.Clear();
				comboBoxEdit_BatchCreate_Grade.Properties.Items.AddRange(new object[]{"全部"});
				comboBoxEdit_BatchCreate_Grade.SelectedItem = "全部";
				foreach(DataRow getGradeList in optionSystem.getGradeInfo("","",false).Tables[0].Rows)
				{
					comboBoxEdit_BatchCreate_Grade.Properties.Items.AddRange(
						new object[]{getGradeList[1].ToString()});
				}

				isForStu = false;

				DataListShow(getGradeNumberFromCombo,getClassNumberFromCombo,getName,getSelNumber,getCardNumber);
			}
		}

		private void barButtonItem_Refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			DataListShow(getGradeNumberFromCombo,getClassNumberFromCombo,getName,getSelNumber,getCardNumber);
		}

		private void barButtonItem_Modify_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			DataListModify();
			DataListShow(getGradeNumberFromCombo,getClassNumberFromCombo,getName,getSelNumber,getCardNumber);
		}

		private void barButtonItem_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			DataListDelete();
			DataListShow(getGradeNumberFromCombo,getClassNumberFromCombo,getName,getSelNumber,getCardNumber);
		}

		private void barButtonItem_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			DataListAdd();
		}

		private void barButtonItem_Save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			DataListSave();
			//gridControl_BatchCreate_Machine.EmbeddedNavigator.Buttons.EndEdit.DoClick();
            gridControl_BatchCreate_Machine.EmbeddedNavigator.Buttons.DoClick(gridControl_BatchCreate_Machine.EmbeddedNavigator.Buttons.EndEdit);
			DataListShow(getGradeNumberFromCombo,getClassNumberFromCombo,getName,getSelNumber,getCardNumber);	
		}

		private void comboBoxEdit_BatchCreate_Load_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( comboBoxEdit_BatchCreate_Load.SelectedItem.ToString().Equals("学生信息表(复杂)") )
			{
				string message = "是否确认打开学生信息导入表？";
				string caption = "消息提示框!";
				string terminalNumbers = string.Empty;
				string machineVol = string.Empty;
				
				DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
				if ( messageResult == DialogResult.Yes )
				{
					if ( !textEdit_BatchCreate_ClassNumbers.Text.Equals(string.Empty) )
					{
						try
						{
							int classNumbers = Convert.ToInt32(textEdit_BatchCreate_ClassNumbers.Text.Replace(" ",""));
							
							if (classNumbers > 81)
							{
								MessageBox.Show("班级总数量不能大于81！");
								return;
							}

							if(openFileDialog_LoadStuInfoXLS.ShowDialog() == DialogResult.OK)          
							{         
								DataSet dsStuInfoXls = new DataSet();
								Hashtable className = new Hashtable();
								optionSystem.ReadStuInfoXLS(ref dsStuInfoXls,Path.GetFullPath(openFileDialog_LoadStuInfoXLS.FileName),classNumbers,ref className);
								for ( int tables=0; tables<classNumbers; tables++ )
								{
									int stuNumber = 1;
									option.ClassName = className[tables].ToString().Replace(" ","");

									foreach ( DataRow infoRow in dsStuInfoXls.Tables[tables].Rows )
									{
										Guid guid = Guid.NewGuid();
										bool isOk = false;
										string msg = string.Empty;
										int rtnMsg = 0;

										option.StuID = guid.ToString();

										if ( infoRow[0] is DBNull && infoRow[1] is DBNull && infoRow[2] is DBNull 
											&& infoRow[3] is DBNull && infoRow[4] is DBNull && infoRow[5] is DBNull 
											&& infoRow[6] is DBNull && infoRow[7] is DBNull)
											break;

									ToGradeInfo:
										msg = optionSystem.CheckStuInfo_Grade(infoRow[0].ToString(),ref isOk);
										rtnMsg = CheckValidMsg(msg,ref isOk,infoRow[3].ToString(),option.ClassName);
										if ( rtnMsg == 2 )
											continue;
										else if ( rtnMsg == -1 )
											return;
										else if ( rtnMsg == 1 )
										{
											try
											{
												infoRow[0] = DebugErrors(msg,"年级编号:").Replace(" ","");
												goto ToGradeInfo;
											}
											catch
											{
												goto ToGradeInfo;
											}
										}
										option.StuGrade = infoRow[0].ToString().Replace(" ","");

									ToClassInfo:
										msg = optionSystem.CheckStuInfo_Class(infoRow[1].ToString(),ref isOk);
										rtnMsg = CheckValidMsg(msg,ref isOk,infoRow[3].ToString(),option.ClassName);
										if ( rtnMsg == 2 )
											continue;
										else if ( rtnMsg == -1 )
											return;
										else if ( rtnMsg == 1 )
										{
											try
											{
												infoRow[1] = DebugErrors(msg,"班级编号:").Replace(" ","");
												goto ToClassInfo;
											}
											catch
											{
												goto ToClassInfo;
											}
										}
										option.StuClass = infoRow[1].ToString().Replace(" ","");

									ToGenderInfo:
										msg = optionSystem.CheckStuInfo_Gender(infoRow[2].ToString(),ref isOk);
										rtnMsg = CheckValidMsg(msg,ref isOk,infoRow[3].ToString(),option.ClassName);
										if ( rtnMsg == 2 )
											continue;
										else if ( rtnMsg == -1 )
											return;
										else if ( rtnMsg == 1 )
										{
											try
											{
												infoRow[2] = DebugErrors(msg,"性别:").Trim();
												goto ToGenderInfo;
											}
											catch
											{
												goto ToGenderInfo;
											}
										}
										option.StuGender = infoRow[2].ToString().Trim();

									ToNameInfo:
										msg = optionSystem.CheckStuInfo_Name(infoRow[3].ToString(),ref isOk);
										rtnMsg = CheckValidMsg(msg,ref isOk,infoRow[3].ToString(),option.ClassName);
										if ( rtnMsg == 2 )
											continue;
										else if ( rtnMsg == -1 )
											return;
										else if ( rtnMsg == 1 )
										{
											try
											{
												infoRow[3] = DebugErrors(msg,"姓名:").Replace(" ","");
												goto ToNameInfo;
											}
											catch
											{
												goto ToNameInfo;
											}
										}
										option.StuName = infoRow[3].ToString().Replace(" ","");
										
									ToBirthdayInfo:
										msg = optionSystem.CheckStuInfo_Birthday(infoRow[4].ToString(),infoRow[12].ToString(),ref isOk);
										rtnMsg = CheckValidMsg(msg,ref isOk,infoRow[3].ToString(),option.ClassName);
										if ( rtnMsg == 2 )
											continue;
										else if ( rtnMsg == -1 )
											return;
										else if ( rtnMsg == 1 )
										{
											try
											{
												infoRow[4] = DebugErrors(msg,"生日:");
											}
											catch
											{
												goto ToBirthdayInfo;
											}
											goto ToBirthdayInfo;
										}
										option.StuBirthday = Convert.ToDateTime(infoRow[4]);
										option.StuEnterDate = Convert.ToDateTime(infoRow[12]);

									ToTypeInfo:
										msg = optionSystem.CheckStuInfo_Type(infoRow[5].ToString(),ref isOk);
										rtnMsg = CheckValidMsg(msg,ref isOk,infoRow[3].ToString(),option.ClassName);
										if ( rtnMsg == 2 )
											continue;
										else if ( rtnMsg == -1 )
											return;
										else if ( rtnMsg == 1 )
										{
											try
											{
												infoRow[5] = DebugErrors(msg,"日托/全托").Replace(" ","");
												goto ToTypeInfo;
											}
											catch
											{
												goto ToTypeInfo;
											}
										}
										option.StuEntryStatus = infoRow[5].ToString().Replace(" ","");

										option.StuNumber = (Convert.ToInt32(infoRow[0])*1000+Convert.ToInt32(infoRow[1])*100+stuNumber).ToString();
										option.GradeName = infoRow[7].ToString().Replace(" ","");
										option.GradeRemark = infoRow[6].ToString().Replace(" ","");
										option.StuParent1 = infoRow[8].ToString().Replace(" ","");
										option.StuParent1_Phone = infoRow[9].ToString().Replace(" ","");
										option.StuParent2 = infoRow[10].ToString();
										option.StuParent2_Phone = infoRow[11].ToString().Replace(" ","");

										
										int rowsAffected = optionSystem.InsertStuInfo(option);

                                        optionSystem.InsertStuParentInfo(option);

										if ( rowsAffected == -1 )
										{
											isOk = false;
											rtnMsg = CheckValidMsg("年级名或年级备注无法被识别,年级备注应该只有[托班],[小班],[中班],[大班],[特色班]等情况！",ref isOk,infoRow[3].ToString(),option.ClassName);
											if ( rtnMsg == 2 )
												continue;
											else if ( rtnMsg == -1 )
												return;
											else if ( rtnMsg == 1 )
												MessageBox.Show("由于年级备注错误，调试失败，该记录被跳过！");
										}
										if ( rowsAffected == 0 )
										{
											MessageBox.Show("网络连接失败，请检查网络文档！");
											return;
										}

										for ( int cardSeq=1,ver=0; cardSeq<=5; cardSeq++,ver++ )
										{
											if ( infoRow[cardSeq+12+ver] is DBNull )
											{
												break;
											}
											else
											{
											ToStuHolderInfo:
												msg = optionSystem.CheckStuCardInfo_Holder(infoRow[cardSeq+13+ver].ToString(),ref isOk);
												rtnMsg = CheckValidMsg(msg,ref isOk,infoRow[3].ToString(),option.ClassName);
												if ( rtnMsg == 2 )
													continue;
												else if ( rtnMsg == -1 )
													return;
												else if ( rtnMsg == 1 )
												{
													try
													{
														infoRow[cardSeq+13+ver] = DebugErrors(msg,"持卡人:").Replace(" ","");
														goto ToStuHolderInfo;
													}
													catch
													{
														goto ToStuHolderInfo;
													}
												}
												
											ToStuCardSendDateInfo:
												msg = optionSystem.CheckStuCardInfo_SendDate(infoRow[23].ToString(),infoRow[12].ToString(),ref isOk);
												rtnMsg = CheckValidMsg(msg,ref isOk,infoRow[3].ToString(),option.ClassName);
												if ( rtnMsg == 2 )
													continue;
												else if ( rtnMsg == -1 )
													return;
												else if ( rtnMsg == 1 )
												{
													try
													{
														infoRow[23] = DebugErrors(msg,"制卡日期:").Replace(" ","");
													}
													catch
													{
														goto ToStuCardSendDateInfo;
													}
													goto ToStuCardSendDateInfo;
												}

											ToStuCardInfo:
												int cardAffected = optionSystem.InsertStuCardInfo(guid.ToString(),infoRow[cardSeq+12+ver].ToString().Replace(" ",""),infoRow[cardSeq+13+ver].ToString().Replace(" ",""),Convert.ToDateTime(infoRow[23]),cardSeq);
												if ( cardAffected == -1 )
												{
					
													isOk = false;
													rtnMsg = CheckValidMsg("卡号重复",ref isOk,infoRow[3].ToString(),option.ClassName);
													if ( rtnMsg == 2 )
														continue;
													else if ( rtnMsg == -1 )
														return;
													else if ( rtnMsg == 1 )
													{
														try
														{
															infoRow[cardSeq+12+ver] = DebugErrors(msg,"卡号").Replace(" ","");
															goto ToStuCardInfo;
														}
														catch
														{
															goto ToStuCardInfo;
														}
													}
												}

												if ( cardAffected == 0 )
												{
													MessageBox.Show("网络连接失败，请检查网络文档！");
													return;
												}
											}
										}
										stuNumber ++;
									}
								}

								terminalNumbers = textEdit_BatchCreate_TerminalNumbers.Text.Trim();

							ToTerminalNumbers:
								if ( !terminalNumbers.Equals(string.Empty) )
								{
									try
									{
										terminalNumbers = Convert.ToInt32(terminalNumbers).ToString();
									}
									catch
									{
										bool isOk = false;
										int rtnMsg = CheckValidMsg("主机总数应该为数字，小数将自动被取整！",ref isOk,"学生信息导入样表","");
										if ( rtnMsg == 2 || rtnMsg == -1)
											return;
										else if ( rtnMsg == 1 )
										{
											try
											{
												terminalNumbers = DebugErrors("主机总数应该为数字，小数将自动被取整！","主机总数:");
												goto ToTerminalNumbers;
											}
											catch
											{
												goto ToTerminalNumbers;
											}
										}
									}
								}

								machineVol = textEdit_ClassVol.Text.Trim();

							ToMachineVol:
								if ( !machineVol.Equals(string.Empty) )
								{
									string msg = "教室机容量应该为数字，小数将自动被取整！";
									try
									{
										machineVol = "-" + Convert.ToInt32(machineVol).ToString();
											
										int totalVol = Math.Abs(Convert.ToInt32(machineVol) * classNumbers) + 140;

										if (SystemFramework.Util.CardVersion == 5)
										{
											if (totalVol > 1000000)
											{
												throw new Exception("volumn error");
											}
										}
									}
									catch(Exception ex)
									{
										if (ex.Message.Equals("volumn error"))
										{
											msg = "所有教室容量总合不能超过1000000!";
										}

										bool isOk = false;
										int rtnMsg = CheckValidMsg(msg,ref isOk,"学生信息导入样表","");
										if ( rtnMsg == 2 || rtnMsg == -1 )
											return;
										else if ( rtnMsg == 1 )
										{
											try
											{
												machineVol = DebugErrors(msg,"教室容量:");
												goto ToMachineVol;
											}
											catch
											{
												goto ToMachineVol;
											}
										}
									}
								}

								optionSystem.InsertMachine(terminalNumbers,machineVol);

								MessageBox.Show("批量数据生成完毕！");
							}
						}
						catch(Exception ex)
						{
							MessageBox.Show("班级数量应该为数字，小数将自动取整！");
						}
					}
					else
						MessageBox.Show("班级数量或主机数量不应该为空！");
				}
			}

			else if ( comboBoxEdit_BatchCreate_Load.SelectedItem.ToString().Equals("教师信息表") )
			{
				string message = "是否确认打开教师信息导入表？";
				string caption = "消息提示框!";
				DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
				if ( messageResult == DialogResult.Yes )
				{
					if(openFileDialog_LoadStuInfoXLS.ShowDialog() == DialogResult.OK) 
					{
						DataSet dsTeaInfoXls = new DataSet();
						int teaNumber = 9101;
						optionSystem.ReadTeaInfoXLS(ref dsTeaInfoXls,Path.GetFullPath(openFileDialog_LoadStuInfoXLS.FileName));
						foreach ( DataRow infoRow in dsTeaInfoXls.Tables[0].Rows )
						{
							Guid guid = Guid.NewGuid();
							bool isOk = false;
							string msg = string.Empty;
							int rtnMsg = 0;

							if ( infoRow[0] is DBNull && infoRow[1] is DBNull && infoRow[2] is DBNull 
								&& infoRow[3] is DBNull && infoRow[4] is DBNull && infoRow[5] is DBNull )
								break;
							
						ToTeaNameInfo:
							msg = optionSystem.CheckStuInfo_Name(infoRow[0].ToString(),ref isOk);
							rtnMsg = CheckValidMsg(msg,ref isOk,infoRow[0].ToString(),"");
							if ( rtnMsg == 2 )
								continue;
							else if ( rtnMsg == -1 )
								return;
							else if ( rtnMsg == 1 )
							{
								try
								{
									infoRow[0] = DebugErrors(msg,"教师姓名:").Replace(" ","");
									goto ToTeaNameInfo;
								}
								catch
								{
									goto ToTeaNameInfo;
								}
							}
							option.TeaName = infoRow[0].ToString().Replace(" ","");

						ToTeaDeptInfo:
							msg = optionSystem.CheckTeaInfo_Dept(infoRow[1].ToString(),ref isOk);
							rtnMsg = CheckValidMsg(msg,ref isOk,infoRow[0].ToString(),"");
							if ( rtnMsg == 2 )
								continue;
							else if ( rtnMsg == -1 )
								return;
							else if ( rtnMsg == 1 )
							{
								try
								{
									infoRow[1] = DebugErrors(msg,"教师部门:").Replace(" ","");
									goto ToTeaDeptInfo;
								}
								catch
								{
									goto ToTeaDeptInfo;
								}
							}
							option.TeaDept = infoRow[1].ToString().Replace(" ","");

						ToTeaDutyInfo:
							msg = optionSystem.CheckTeaInfo_Duty(infoRow[2].ToString(),ref isOk);
							rtnMsg = CheckValidMsg(msg,ref isOk,infoRow[0].ToString(),"");
							if ( rtnMsg == 2 )
								continue;
							else if ( rtnMsg == -1 )
								return;
							else if ( rtnMsg == 1 )
							{
								try
								{
									infoRow[2] = DebugErrors(msg,"教师岗位:").Replace(" ","");
									goto ToTeaDutyInfo;
								}
								catch
								{
									goto ToTeaDutyInfo;
								}
							}
							option.TeaDuty = infoRow[2].ToString().Replace(" ","");

						ToTeaAuthorityInfo:
							msg = optionSystem.CheckTeaInfo_Authority(infoRow[3].ToString(),ref isOk);
							rtnMsg = CheckValidMsg(msg,ref isOk,infoRow[0].ToString(),"");
							if ( rtnMsg == 2 )
								continue;
							else if ( rtnMsg == -1 )
								return;
							else if ( rtnMsg == 1 )
							{
								try
								{
									infoRow[3] = DebugErrors(msg,"教师权限:").Replace(" ","");
									goto ToTeaAuthorityInfo;
								}
								catch
								{
									goto ToTeaAuthorityInfo;
								}
							}
							option.TeaAuthority = infoRow[3].ToString().Replace(" ","");

						ToTeaGenderInfo:
							msg = optionSystem.CheckStuInfo_Gender(infoRow[4].ToString(),ref isOk);
							rtnMsg = CheckValidMsg(msg,ref isOk,infoRow[0].ToString(),"");
							if ( rtnMsg == 2 )
								continue;
							else if ( rtnMsg == -1 )
								return;
							else if ( rtnMsg == 1 )
							{
								try
								{
									infoRow[4] = DebugErrors(msg,"教师性别:").Replace(" ","");
									goto ToTeaGenderInfo;
								}
								catch
								{	
									goto ToTeaGenderInfo;
								}
							}
							option.TeaGender = infoRow[4].ToString().Replace(" ","");

							option.TeaID = guid.ToString();
							option.TeaNumber = teaNumber.ToString();
							option.TeaOfficePhone = infoRow[5].ToString().Replace(" ","");

							optionSystem.InsertTeaInfo(option);

							for ( int cardSeq=1; cardSeq<=5; cardSeq++ )
							{
								if ( infoRow[cardSeq+5] is DBNull )
								{
									break;
								}
								else
								{											
								ToTeaCardSendDateInfo:
									msg = optionSystem.CheckTeaInfo_CardSendDate(infoRow[11].ToString(),ref isOk);
									rtnMsg = CheckValidMsg(msg,ref isOk,infoRow[0].ToString(),"");
									if ( rtnMsg == 2 )
										continue;
									else if ( rtnMsg == -1 )
										return;
									else if ( rtnMsg == 1 )
									{
										try
										{
											infoRow[11] = DebugErrors(msg,"制卡日期:").Replace(" ","");
										}
										catch
										{
											goto ToTeaCardSendDateInfo;
										}
										goto ToTeaCardSendDateInfo;
									}

								ToTeaCardInfo:
									int cardAffected = optionSystem.InsertTeaCardInfo(guid.ToString(),infoRow[cardSeq+5].ToString().Replace(" ",""),Convert.ToDateTime(infoRow[11]),cardSeq);

									if ( cardAffected == -1 )
									{
										isOk = false;
										rtnMsg = CheckValidMsg("卡号重复",ref isOk,infoRow[0].ToString(),"");
										if ( rtnMsg == 2 )
											continue;
										else if ( rtnMsg == -1 )
											return;
										else if ( rtnMsg == 1 )
										{
											try
											{
												infoRow[cardSeq+5] = DebugErrors(msg,"卡号").Replace(" ","");
												goto ToTeaCardInfo;
											}
											catch
											{
												goto ToTeaCardInfo;
											}
										}
									}

									if ( cardAffected == 0 )
									{
										MessageBox.Show("网络连接失败，请检查网络文档！");
										return;
									}
								}
							}
							
							if (++teaNumber % 100 > 70 )
								teaNumber = teaNumber + 30;

//							if ( teaNumber++ == 9170 )
//								teaNumber = 9201;
							
						}
					}

					MessageBox.Show("批量数据生成完毕！");
				}
			}
			else if ( comboBoxEdit_BatchCreate_Load.SelectedItem.ToString().Equals("生成卡号新增表") )
			{
				string message = "是否生成卡号新增表？";
				string caption = "消息提示框!";
				DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
				if ( messageResult == DialogResult.Yes )
				{
					if(openFileDialog_LoadStuInfoXLS.ShowDialog() == DialogResult.OK) 
					{
						optionSystem.WriteStuCardInfoXLS(Path.GetFullPath(openFileDialog_LoadStuInfoXLS.FileName));
					}
				}
				
			}
			else if (comboBoxEdit_BatchCreate_Load.SelectedItem.ToString().Equals("载入卡号新增表"))
			{
				string message = "是否确认打开卡号新增表？";
				string caption = "消息提示框!";
				DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
				if ( messageResult == DialogResult.Yes )
				{
					if(openFileDialog_LoadStuInfoXLS.ShowDialog() == DialogResult.OK) 
					{
						DataSet dsReadStuCardInfo = new DataSet();
						optionSystem.ReadStuCardInfoXLS(ref dsReadStuCardInfo,Path.GetFullPath(openFileDialog_LoadStuInfoXLS.FileName));
						foreach ( DataRow infoRow in dsReadStuCardInfo.Tables[0].Rows )
						{
							bool isOk = false;
							string msg = string.Empty;
							int rtnMsg = 0;

							if ( infoRow[0] is DBNull && infoRow[1] is DBNull )
								break;

						ToStuNumberInfo:
							msg = optionSystem.CheckStuInfo_Number(infoRow[0].ToString(),ref isOk);
							rtnMsg = CheckValidMsg(msg,ref isOk,infoRow[1].ToString(),"");
							if ( rtnMsg == 2 )
								continue;
							else if ( rtnMsg == -1 )
								return;
							else if ( rtnMsg == 1 )
							{
								try
								{
									infoRow[0] = DebugErrors(msg,"学生学号:").Replace(" ","");
									goto ToStuNumberInfo;
								}
								catch
								{
									goto ToStuNumberInfo;
								}
							}		

							for ( int cardSeq=1,ver=0; cardSeq<=5; cardSeq++,ver++ )
							{
								if ( infoRow[cardSeq+1+ver] is DBNull )
								{
									break;
								}
								else
								{
								ToStuHolderInfo_Card:
									msg = optionSystem.CheckStuCardInfo_Holder(infoRow[cardSeq+2+ver].ToString(),ref isOk);
									rtnMsg = CheckValidMsg(msg,ref isOk,infoRow[0].ToString(),"");
									if ( rtnMsg == 2 )
										continue;
									else if ( rtnMsg == -1 )
										return;
									else if ( rtnMsg == 1 )
									{
										try
										{
											infoRow[cardSeq+2+ver] = DebugErrors(msg,"持卡人:").Replace(" ","");
											goto ToStuHolderInfo_Card;
										}
										catch
										{
											goto ToStuHolderInfo_Card;
										}
									}

								ToStuCardSendDateInfo_Card:
									msg = optionSystem.CheckTeaInfo_CardSendDate(infoRow[12].ToString(),ref isOk);
									rtnMsg = CheckValidMsg(msg,ref isOk,infoRow[0].ToString(),"");
									if ( rtnMsg == 2 )
										continue;
									else if ( rtnMsg == -1 )
										return;
									else if ( rtnMsg == 1 )
									{
										try
										{
											infoRow[12] = DebugErrors(msg,"制卡日期:").Replace(" ","");
										}
										catch
										{
											goto ToStuCardSendDateInfo_Card;
										}
										goto ToStuCardSendDateInfo_Card;
									}

								ToStuCardInfo_Card:
									int cardAffected = optionSystem.InsertNewAddCardInfo(infoRow[0].ToString().Replace(" ",""),infoRow[cardSeq+1+ver].ToString().Replace(" ",""),infoRow[cardSeq+2+ver].ToString().Replace(" ",""),Convert.ToDateTime(infoRow[12]));
									if ( cardAffected == -1 )
									{
										isOk = false;
										rtnMsg = CheckValidMsg("卡号重复",ref isOk,infoRow[0].ToString(),"");
										if ( rtnMsg == 2 )
											continue;
										else if ( rtnMsg == -1 )
											return;
										else if ( rtnMsg == 1 )
										{
											try
											{
												infoRow[cardSeq+1+ver] = DebugErrors(msg,"卡号:").Replace(" ","");
												goto ToStuCardInfo_Card;
											}
											catch
											{
												goto ToStuCardInfo_Card;
											}
										}
									}
									else if ( cardAffected == -2 )
									{
										isOk = false;
										rtnMsg = CheckValidMsg("该学生已经有5张卡",ref isOk,infoRow[0].ToString(),"");
										if ( rtnMsg == 2 )
											break;
										else if ( rtnMsg == -1 )
											return;
										else if ( rtnMsg == 1 )
										{
											MessageBox.Show("当前卡被跳过，原因是该学生已经有5张卡！");
											break;
										}
										break;
									}
									else if ( cardAffected == -3 )
									{
										isOk = false;
										rtnMsg = CheckValidMsg("该学生不存在",ref isOk,infoRow[0].ToString(),"");
										break;
									}
									else if ( cardAffected == 0 )
									{
										MessageBox.Show("网络连接失败，请检查网络文档！");
										return;
									}
								}
							}
						}	

						MessageBox.Show("卡号新增完毕！");
					}
				}
			}
			else
			{
//				string createMsg = "是否要生成简单学生信息表样本?";
//				string createCaption = "消息提示框!";
				string terminalNumbers = string.Empty;
				string machineVol = string.Empty;
//				DialogResult createMsgResult = MessageBox.Show(createMsg,createCaption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
//				if ( createMsgResult == DialogResult.Yes )
//				{
//					MessageBox.Show("数据填写完之后请务必另存为一个另外的路径!");
//					optionSystem.CreateStudentBaseSimpleTable();
//				}
//				else
//				{
					string loadMsg = "是否要载入简单学生信息表?";
					string loadCaption = "消息提示框!";
					DialogResult loadMsgResult = MessageBox.Show(loadMsg,loadCaption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
					if (loadMsgResult == DialogResult.Yes)
					{
						if ( !textEdit_BatchCreate_ClassNumbers.Text.Equals(string.Empty) )
						{
							try
							{
								int classNumbers = Convert.ToInt32(textEdit_BatchCreate_ClassNumbers.Text.Replace(" ",""));

								if (classNumbers > 81)
								{
									MessageBox.Show("班级总数量不能大于81！");
									return;
								}

								if(openFileDialog_LoadStuInfoXLS.ShowDialog() == DialogResult.OK)          
								{         
									DataSet dsStuInfoXls = new DataSet();
									Hashtable className = new Hashtable();
									optionSystem.ReadStuInfoXLS(ref dsStuInfoXls,Path.GetFullPath(openFileDialog_LoadStuInfoXLS.FileName),classNumbers,ref className);
									for ( int tables=0; tables<classNumbers; tables++ )
									{
										int stuNumber = 1;
										option.ClassName = className[tables].ToString().Replace(" ","");

										foreach ( DataRow infoRow in dsStuInfoXls.Tables[tables].Rows )
										{
											Guid guid = Guid.NewGuid();
											bool isOk = false;
											string msg = string.Empty;
											int rtnMsg = 0;

											option.StuID = guid.ToString();

											if ( infoRow[0] is DBNull && infoRow[1] is DBNull && infoRow[2] is DBNull 
												&& infoRow[3] is DBNull && infoRow[4] is DBNull && infoRow[5] is DBNull 
												&& infoRow[6] is DBNull && infoRow[7] is DBNull && infoRow[8] is DBNull)
											{
												break;
											}

										ToGradeInfo:
											msg = optionSystem.CheckStuInfo_Grade(infoRow[0].ToString(),ref isOk);
											rtnMsg = CheckValidMsg(msg,ref isOk,infoRow[3].ToString(),option.ClassName);
											if ( rtnMsg == 2 )
												continue;
											else if ( rtnMsg == -1 )
												return;
											else if ( rtnMsg == 1 )
											{
												try
												{
													infoRow[0] = DebugErrors(msg,"年级编号:").Replace(" ","");
													goto ToGradeInfo;
												}
												catch
												{
													goto ToGradeInfo;
												}
											}
											option.StuGrade = infoRow[0].ToString().Replace(" ","");

										ToClassInfo:
											msg = optionSystem.CheckStuInfo_Class(infoRow[1].ToString(),ref isOk);
											rtnMsg = CheckValidMsg(msg,ref isOk,infoRow[3].ToString(),option.ClassName);
											if ( rtnMsg == 2 )
												continue;
											else if ( rtnMsg == -1 )
												return;
											else if ( rtnMsg == 1 )
											{
												try
												{
													infoRow[1] = DebugErrors(msg,"班级编号:").Replace(" ","");
													goto ToClassInfo;
												}
												catch
												{
													goto ToClassInfo;
												}
											}
											option.StuClass = infoRow[1].ToString().Replace(" ","");

										ToGenderInfo:
											msg = optionSystem.CheckStuInfo_Gender(infoRow[2].ToString(),ref isOk);
											rtnMsg = CheckValidMsg(msg,ref isOk,infoRow[3].ToString(),option.ClassName);
											if ( rtnMsg == 2 )
												continue;
											else if ( rtnMsg == -1 )
												return;
											else if ( rtnMsg == 1 )
											{
												try
												{
													infoRow[2] = DebugErrors(msg,"性别:").Trim();
													goto ToGenderInfo;
												}
												catch
												{
													goto ToGenderInfo;
												}
											}
											option.StuGender = infoRow[2].ToString().Trim();

										ToNameInfo:
											msg = optionSystem.CheckStuInfo_Name(infoRow[3].ToString(),ref isOk);
											rtnMsg = CheckValidMsg(msg,ref isOk,infoRow[3].ToString(),option.ClassName);
											if ( rtnMsg == 2 )
												continue;
											else if ( rtnMsg == -1 )
												return;
											else if ( rtnMsg == 1 )
											{
												try
												{
													infoRow[3] = DebugErrors(msg,"姓名:").Replace(" ","");
													goto ToNameInfo;
												}
												catch
												{
													goto ToNameInfo;
												}
											}
											option.StuName = infoRow[3].ToString().Replace(" ","");
										
										ToBirthdayInfo:
											msg = optionSystem.CheckStuInfo_Birthday(infoRow[4].ToString(),infoRow[8].ToString(),ref isOk);
											rtnMsg = CheckValidMsg(msg,ref isOk,infoRow[3].ToString(),option.ClassName);
											if ( rtnMsg == 2 )
												continue;
											else if ( rtnMsg == -1 )
												return;
											else if ( rtnMsg == 1 )
											{
												try
												{
													infoRow[4] = DebugErrors(msg,"生日:");
												}
												catch
												{
													goto ToBirthdayInfo;
												}
												goto ToBirthdayInfo;
											}
											option.StuBirthday = Convert.ToDateTime(infoRow[4]);
											option.StuEnterDate = Convert.ToDateTime(infoRow[8]);


										ToTypeInfo:
											msg = optionSystem.CheckStuInfo_Type(infoRow[5].ToString(),ref isOk);
											rtnMsg = CheckValidMsg(msg,ref isOk,infoRow[3].ToString(),option.ClassName);
											if ( rtnMsg == 2 )
												continue;
											else if ( rtnMsg == -1 )
												return;
											else if ( rtnMsg == 1 )
											{
												try
												{
													infoRow[5] = DebugErrors(msg,"日托/全托").Replace(" ","");
													goto ToTypeInfo;
												}
												catch
												{
													goto ToTypeInfo;
												}
											}
											option.StuEntryStatus = infoRow[5].ToString().Replace(" ","");

											option.StuNumber = (Convert.ToInt32(infoRow[0])*1000+Convert.ToInt32(infoRow[1])*100+stuNumber).ToString();
											option.GradeName = infoRow[7].ToString().Replace(" ","");
											option.GradeRemark = infoRow[6].ToString().Replace(" ","");
											option.StuEmail = string.Empty;
											option.StuPhone = string.Empty;
											option.StuFamilyAddr = string.Empty;
											option.StuZipCode = string.Empty;
										
											int rowsAffected = optionSystem.InsertStuInfo(option);

											if ( rowsAffected == -1 )
											{
												isOk = false;
												rtnMsg = CheckValidMsg("年级名或年级备注无法被识别,年级备注应该只有[托班],[小班],[中班],[大班],[特色班]等情况！",ref isOk,infoRow[3].ToString(),option.ClassName);
												if ( rtnMsg == 2 )
													continue;
												else if ( rtnMsg == -1 )
													return;
												else if ( rtnMsg == 1 )
													MessageBox.Show("由于年级备注错误，调试失败，该记录被跳过！");
											}
											if ( rowsAffected == 0 )
											{
												MessageBox.Show("网络连接失败，请检查网络文档！");
												return;
											}

											stuNumber ++;
										}
									}

									terminalNumbers = textEdit_BatchCreate_TerminalNumbers.Text.Trim();

								ToTerminalNumbers:
									if ( !terminalNumbers.Equals(string.Empty) )
									{
										try
										{
											terminalNumbers = Convert.ToInt32(terminalNumbers).ToString();
										}
										catch
										{
											bool isOk = false;
											int rtnMsg = CheckValidMsg("主机总数应该为数字，小数将自动被取整！",ref isOk,"学生信息导入样表","");
											if ( rtnMsg == 2 || rtnMsg == -1)
												return;
											else if ( rtnMsg == 1 )
											{
												try
												{
													terminalNumbers = DebugErrors("主机总数应该为数字，小数将自动被取整！","主机总数:");
													goto ToTerminalNumbers;
												}
												catch
												{
													goto ToTerminalNumbers;
												}
											}
										}
									}

									machineVol = textEdit_ClassVol.Text.Trim();

								ToMachineVol:
									if ( !machineVol.Equals(string.Empty) )
									{
										string msg = "教室机容量应该为数字，小数将自动被取整！";
										try
										{
											machineVol = "-" + Convert.ToInt32(machineVol).ToString();
											
											int totalVol = Math.Abs(Convert.ToInt32(machineVol) * classNumbers);

											if (totalVol > 10000)
											{
												throw new Exception("volumn error");
											}
										}
										catch(Exception ex)
										{
											if (ex.Message.Equals("volumn error"))
											{
												msg = "所有教室容量总合不能超过10000!";
											}

											bool isOk = false;
											int rtnMsg = CheckValidMsg(msg,ref isOk,"学生信息导入样表","");
											if ( rtnMsg == 2 || rtnMsg == -1 )
												return;
											else if ( rtnMsg == 1 )
											{
												try
												{
													machineVol = DebugErrors(msg,"教室容量:");
													goto ToMachineVol;
												}
												catch
												{
													goto ToMachineVol;
												}
											}
										}
									}

									optionSystem.InsertMachine(terminalNumbers,machineVol);

									MessageBox.Show("批量数据生成完毕！");
								}
							}
							catch(Exception ex)
							{
								MessageBox.Show("班级数量应该为数字，小数将自动取整！");
							}
						}
						else
							MessageBox.Show("班级数量或主机数量不应该为空！");
					}
//				}
			}
	
		}

		private void DataListShow(string getGrade,string getClass,string getName,string getNumber,string getCardNumber)
		{
			if ( comboBoxEdit_BatchCreate_Type.SelectedItem.ToString().Equals("年级表(含部门)") )
			{
				gridControl_BatchCreate_Grade.Visible = true;
				gridControl_BatchCreate_Class.Visible = false;
				gridControl_BatchCreate_StuBasicInfo.Visible = false;
				gridControl_BatchCreate_StuCard.Visible = false;
				gridControl1_BatchCreate_TeaBasicInfo.Visible = false;
				gridControl_BatchCreate_TeaCard.Visible = false;
				gridControl_BatchCreate_Machine.Visible = false;

				DataSet dsGradeInfo;dsGradeInfo = null;
				dsGradeInfo = optionSystem.getGradeInfo("",getGrade,isForStu);

				if ( dsGradeInfo != null )
					gridControl_BatchCreate_Grade.DataSource = dsGradeInfo.Tables[0];
			}
			else if ( comboBoxEdit_BatchCreate_Type.SelectedItem.ToString().Equals("班级表(含岗位)") )
			{
				gridControl_BatchCreate_Class.Visible = true;
				gridControl_BatchCreate_Grade.Visible = false;
				gridControl_BatchCreate_StuBasicInfo.Visible = false;
				gridControl_BatchCreate_StuCard.Visible = false;
				gridControl1_BatchCreate_TeaBasicInfo.Visible = false;
				gridControl_BatchCreate_TeaCard.Visible = false;
				gridControl_BatchCreate_Machine.Visible = false;

				DataSet dsClassInfo = null;
				dsClassInfo = optionSystem.getClassInfo("",getClass,getGrade,isForStu);
				
				if ( dsClassInfo != null )
					gridControl_BatchCreate_Class.DataSource = dsClassInfo.Tables[0];
			}
			else if ( comboBoxEdit_BatchCreate_Type.SelectedItem.ToString().Equals("学生基本信息表") )
			{
				gridControl_BatchCreate_StuBasicInfo.Visible = true;
				gridControl_BatchCreate_Class.Visible = false;
				gridControl_BatchCreate_Grade.Visible = false;
				gridControl_BatchCreate_StuCard.Visible = false;
				gridControl1_BatchCreate_TeaBasicInfo.Visible = false;
				gridControl_BatchCreate_TeaCard.Visible = false;
				gridControl_BatchCreate_Machine.Visible = false;

				DataSet dsStuBasicInfo = null;
				dsStuBasicInfo = optionSystem.getStuBasicInfo(getGrade,getClass,getName,getNumber);

				if ( dsStuBasicInfo != null )
					gridControl_BatchCreate_StuBasicInfo.DataSource = dsStuBasicInfo.Tables[0];
			}
			else if ( comboBoxEdit_BatchCreate_Type.SelectedItem.ToString().Equals("学生卡号表") )
			{
				gridControl_BatchCreate_StuCard.Visible = true;
				gridControl_BatchCreate_StuBasicInfo.Visible = false;
				gridControl_BatchCreate_Class.Visible = false;
				gridControl_BatchCreate_Grade.Visible = false;
				gridControl1_BatchCreate_TeaBasicInfo.Visible = false;
				gridControl_BatchCreate_TeaCard.Visible = false;
				gridControl_BatchCreate_Machine.Visible = false;

				DataSet dsStuCard = null;
				dsStuCard = optionSystem.GetStuCard(getGrade,getClass,getName,getNumber,getCardNumber);

				if ( dsStuCard != null )
					gridControl_BatchCreate_StuCard.DataSource = dsStuCard.Tables[0];
			}
			else if ( comboBoxEdit_BatchCreate_Type.SelectedItem.ToString().Equals("教师基本信息表") )
			{
				gridControl1_BatchCreate_TeaBasicInfo.Visible = true;
				gridControl_BatchCreate_StuCard.Visible = false;
				gridControl_BatchCreate_StuBasicInfo.Visible = false;
				gridControl_BatchCreate_Class.Visible = false;
				gridControl_BatchCreate_Grade.Visible = false;
				gridControl_BatchCreate_TeaCard.Visible = false;
				gridControl_BatchCreate_Machine.Visible = false;

				DataSet dsTeaBasicInfo = null;
				dsTeaBasicInfo = optionSystem.GetTeaBasicInfo(getGrade,getClass,getName,getNumber);

				if ( dsTeaBasicInfo != null )
					gridControl1_BatchCreate_TeaBasicInfo.DataSource = dsTeaBasicInfo.Tables[0];
			}
			else if ( comboBoxEdit_BatchCreate_Type.SelectedItem.ToString().Equals("教师卡号表") )
			{
				gridControl_BatchCreate_TeaCard.Visible = true;
				gridControl1_BatchCreate_TeaBasicInfo.Visible = false;
				gridControl_BatchCreate_StuCard.Visible = false;
				gridControl_BatchCreate_StuBasicInfo.Visible = false;
				gridControl_BatchCreate_Class.Visible = false;
				gridControl_BatchCreate_Grade.Visible = false;
				gridControl_BatchCreate_Machine.Visible = false;

				DataSet dsTeaCard = null;
				dsTeaCard = optionSystem.GetTeaCard(getGrade,getClass,getName,getNumber,getCardNumber);

				if ( dsTeaCard != null )
					gridControl_BatchCreate_TeaCard.DataSource = dsTeaCard.Tables[0];
			}
			else
			{
				gridControl_BatchCreate_Machine.Visible = true;
				gridControl_BatchCreate_TeaCard.Visible = false;
				gridControl1_BatchCreate_TeaBasicInfo.Visible = false;
				gridControl_BatchCreate_StuCard.Visible = false;
				gridControl_BatchCreate_StuBasicInfo.Visible = false;
				gridControl_BatchCreate_Class.Visible = false;
				gridControl_BatchCreate_Grade.Visible = false;

				DataSet dsMachine = null;
				dsMachine = optionSystem.GetMachine();

				if ( dsMachine != null )
					gridControl_BatchCreate_Machine.DataSource = dsMachine.Tables[0];
			}
		}

		private void DataListModify()
		{
			string message = "是否确认要更新数据？";
			string caption = "消息提示框!";

			if ( comboBoxEdit_BatchCreate_Type.SelectedItem.ToString().Equals("年级表(含部门)") )
			{
				if ( gridView1.RowCount > 0 )
				{
					DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
					if ( messageResult == DialogResult.Yes )
					{
						string getOriNumber = gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["GradeNumber"].ToString();
						string getChNumber = gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["info_gradeNumber"].ToString();
						string getChName = gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["info_gradeName"].ToString();
						string getChRemark = gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["info_gradeRemark"].ToString();
				
						int rowsAffected = optionSystem.UpdateGradeInfo(getOriNumber,getChNumber,getChName,getChRemark);

						if ( rowsAffected == -1 )
							MessageBox.Show("年级号或年级名存在重名,更新失败！");
						else if ( rowsAffected == 0 )
							MessageBox.Show("网络连接失败，请检查网络文档！");
						else
							MessageBox.Show("更新成功！");
					}
				}
				else
					MessageBox.Show("不存在的数据！","系统信息",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
			}
			else if ( comboBoxEdit_BatchCreate_Type.SelectedItem.ToString().Equals("班级表(含岗位)") )
			{
				if ( gridView2.RowCount > 0 )
				{
					DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
					if ( messageResult == DialogResult.Yes )
					{
						string getOriClassNumber = gridView2.GetDataRow(gridView2.GetSelectedRows()[0])["ClassNumber"].ToString();
						string getOriGradeNumber = gridView2.GetDataRow(gridView2.GetSelectedRows()[0])["GradeNumber"].ToString();
						string getChClassNumber = gridView2.GetDataRow(gridView2.GetSelectedRows()[0])["info_classNumber"].ToString();
						string getChGradeNumber = gridView2.GetDataRow(gridView2.GetSelectedRows()[0])["info_gradeNumber"].ToString();
						string getChClassName = gridView2.GetDataRow(gridView2.GetSelectedRows()[0])["info_className"].ToString();
						string getChRemark = gridView2.GetDataRow(gridView2.GetSelectedRows()[0])["info_classRemark"].ToString();

						int rowsAffected = optionSystem.UpdateClassInfo(getOriClassNumber,getOriGradeNumber,getChClassNumber,
							getChGradeNumber,getChClassName,getChRemark);

						if ( rowsAffected == -1 )
							MessageBox.Show("地址或班级存在重名，更新失败！");
						else if ( rowsAffected == 0 )
							MessageBox.Show("网络连接失败，请检查网络文档！");
						else
							MessageBox.Show("更新成功！");
					}	
				}
				else
					MessageBox.Show("不存在的数据！","系统信息",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
			}
			else if ( comboBoxEdit_BatchCreate_Type.SelectedItem.ToString().Equals("学生基本信息表") )
			{
				if ( advBandedGridView1.RowCount > 0 )
				{
					DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
					if ( messageResult == DialogResult.Yes )
					{
						option.StuID = advBandedGridView1.GetDataRow(advBandedGridView1.GetSelectedRows()[0])["info_stuID"].ToString();
						option.StuNumber = advBandedGridView1.GetDataRow(advBandedGridView1.GetSelectedRows()[0])["info_stuNumber"].ToString();
						option.StuName = advBandedGridView1.GetDataRow(advBandedGridView1.GetSelectedRows()[0])["info_stuName"].ToString();
						option.StuGrade = advBandedGridView1.GetDataRow(advBandedGridView1.GetSelectedRows()[0])["info_stuGrade"].ToString();
						option.StuClass = advBandedGridView1.GetDataRow(advBandedGridView1.GetSelectedRows()[0])["info_stuClass"].ToString();
						option.StuPhone = advBandedGridView1.GetDataRow(advBandedGridView1.GetSelectedRows()[0])["info_stuFatherLinkPhone"].ToString();
						option.StuFamilyAddr = advBandedGridView1.GetDataRow(advBandedGridView1.GetSelectedRows()[0])["info_stuFamilyAddr"].ToString();
						option.StuBirthday = Convert.ToDateTime(advBandedGridView1.GetDataRow(advBandedGridView1.GetSelectedRows()[0])["info_stuBirthDay"]);
						option.StuEnterDate = Convert.ToDateTime(advBandedGridView1.GetDataRow(advBandedGridView1.GetSelectedRows()[0])["info_stuEntryDate"]);
						option.StuEmail = advBandedGridView1.GetDataRow(advBandedGridView1.GetSelectedRows()[0])["info_stuEMailAddr"].ToString();
						option.StuZipCode = advBandedGridView1.GetDataRow(advBandedGridView1.GetSelectedRows()[0])["info_stuZipCode"].ToString();
						option.StuGender = advBandedGridView1.GetDataRow(advBandedGridView1.GetSelectedRows()[0])["info_stuGender"].ToString();
						option.StuEntryStatus = advBandedGridView1.GetDataRow(advBandedGridView1.GetSelectedRows()[0])["info_stuEntryStatus"].ToString();
						
						int rowsAffected = optionSystem.CheckStuValidation(option);

						if ( rowsAffected == -1 )
							MessageBox.Show("学号重复，更新失败！");
						else if ( rowsAffected == -2 )
							MessageBox.Show("输入的信息不符实际！");
						else if ( rowsAffected == -3 )
							MessageBox.Show("学号应为数字！");
						else if ( rowsAffected == 0 )
							MessageBox.Show("网络连接失败，请检查网络文档！");
						else
							MessageBox.Show("更新成功！");
					}
				}
				else
					MessageBox.Show("不存在的数据！","系统信息",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
			}
			else if ( comboBoxEdit_BatchCreate_Type.SelectedItem.ToString().Equals("学生卡号表") )
			{
				if ( gridView4.RowCount > 0 )
				{
					DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
					if ( messageResult == DialogResult.Yes )
					{
						string getID = gridView4.GetDataRow(gridView4.GetSelectedRows()[0])["info_stuBasicID"].ToString();
						string getNumber = gridView4.GetDataRow(gridView4.GetSelectedRows()[0])["info_stuCardNumber"].ToString();
						string getHolder = gridView4.GetDataRow(gridView4.GetSelectedRows()[0])["info_stuCardHolder"].ToString();
						int getSeq = Convert.ToInt32(gridView4.GetDataRow(gridView4.GetSelectedRows()[0])["info_stuCardSeq"]);
						DateTime getDate = Convert.ToDateTime(gridView4.GetDataRow(gridView4.GetSelectedRows()[0])["info_stuCardSendDate"]);

						int rowsAffected = optionSystem.UpdateStuCardInfo(getID,getCardNumber,getHolder,getSeq,getDate);
						
						if ( rowsAffected == -1 )
							MessageBox.Show("卡号重复，更新失败！");
						else if ( rowsAffected == 0 )
							MessageBox.Show("网络连接失败，请检查网络文档！");
						else
							MessageBox.Show("更新成功！");
					}
				}
				else
					MessageBox.Show("不存在的数据！","系统信息",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
			}
			else if ( comboBoxEdit_BatchCreate_Type.SelectedItem.ToString().Equals("教师基本信息表") )
			{
				if ( gridView5.RowCount > 0 )
				{
					DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
					if ( messageResult == DialogResult.Yes )
					{
						string getID = gridView5.GetDataRow(gridView5.GetSelectedRows()[0])["T_ID"].ToString();
						string getName = gridView5.GetDataRow(gridView5.GetSelectedRows()[0])["T_Name"].ToString();
						string getNumber = gridView5.GetDataRow(gridView5.GetSelectedRows()[0])["T_Number"].ToString();
						string getDept = gridView5.GetDataRow(gridView5.GetSelectedRows()[0])["T_Depart"].ToString();
						string getDuty = gridView5.GetDataRow(gridView5.GetSelectedRows()[0])["T_Duty"].ToString();
						string getGender = gridView5.GetDataRow(gridView5.GetSelectedRows()[0])["T_Sex"].ToString();

						int rowsAffected = optionSystem.CheckTeaValidation(getID,getName,getNumber,getDept,getDuty,getGender);

						if ( rowsAffected == -1 )
							MessageBox.Show("教师工号重复，更新失败！");
						else if ( rowsAffected == -2 )
							MessageBox.Show("教师工号范围为9101-9169,9201-9269");
						else if ( rowsAffected == 0 )
							MessageBox.Show("网络连接失败，请检查网络文档！");
						else
							MessageBox.Show("更新成功！");
					}
				}
				else
					MessageBox.Show("不存在的数据！","系统信息",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
			}
			else if ( comboBoxEdit_BatchCreate_Type.SelectedItem.ToString().Equals("教师卡号表") )
			{
				if ( gridView6.RowCount > 0 )
				{
					DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
					if ( messageResult == DialogResult.Yes )
					{
						string getID = gridView6.GetDataRow(gridView6.GetSelectedRows()[0])["info_teaBasicID"].ToString();
						string getNumber = gridView6.GetDataRow(gridView6.GetSelectedRows()[0])["info_teaCardNumber"].ToString();
						int getSeq = Convert.ToInt32(gridView6.GetDataRow(gridView6.GetSelectedRows()[0])["info_teaCardSeq"]);
						DateTime getDate = Convert.ToDateTime(gridView6.GetDataRow(gridView6.GetSelectedRows()[0])["info_teaCardSendDate"]);

						int rowsAffected = optionSystem.UpdateTeaCardInfo(getID,getNumber,getSeq,getDate);

						if ( rowsAffected == -1 )
							MessageBox.Show("卡号重复，更新失败！");
						else if ( rowsAffected == 0 )
							MessageBox.Show("网络连接失败，请检查网络文档！");
						else
							MessageBox.Show("更新成功！");
					}	
				}	
				else
					MessageBox.Show("不存在的数据！","系统信息",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
			}
			else
			{
				if ( gridView7.RowCount > 0 )
				{
					DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
					if ( messageResult == DialogResult.Yes )
					{
						int getOriMachineAddr = Convert.ToInt32(gridView7.GetDataRow(gridView7.GetSelectedRows()[0])["Address"]);
						int getOriMachineType = Convert.ToInt32(gridView7.GetDataRow(gridView7.GetSelectedRows()[0])["Type"]);
						int getChMachineAddr = Convert.ToInt32(gridView7.GetDataRow(gridView7.GetSelectedRows()[0])["machine_address"]);
						int getChMachineType = Convert.ToInt32(gridView7.GetDataRow(gridView7.GetSelectedRows()[0])["machine_type"]);
						int getChMachineVol = Convert.ToInt32(gridView7.GetDataRow(gridView7.GetSelectedRows()[0])["machine_volumn"]);

						int rowsAffected = optionSystem.UpdateMachineInfo(getOriMachineAddr,getOriMachineType,getChMachineAddr,getChMachineType,getChMachineVol);

						if ( rowsAffected == -1 )
							MessageBox.Show("有硬件地址重复，更新失败！");
						else if ( rowsAffected == 0 )
							MessageBox.Show("网络连接失败，请检查网络文档！");
						else
							MessageBox.Show("更新成功！");
					}	
				}	
				else
					MessageBox.Show("不存在的数据！","系统信息",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
			}
		}

		private void DataListDelete()
		{
			string message = "是否确认要删除数据？";
			string caption = "消息提示框!";

			if ( comboBoxEdit_BatchCreate_Type.SelectedItem.ToString().Equals("年级表(含部门)") )
			{
				if ( gridView1.RowCount > 0 )
				{
					DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
					if ( messageResult == DialogResult.Yes )
					{
						string getOriNumber = gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["GradeNumber"].ToString();

						int rowsAffected = optionSystem.DeleteGradeInfo(getOriNumber);

						if ( rowsAffected <= 0 )
							MessageBox.Show("网络连接失败，请检查网络文档！");
						else
							MessageBox.Show("删除完毕！");
					}
				}
				else
					MessageBox.Show("不存在的数据！","系统信息",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
			}
			else if ( comboBoxEdit_BatchCreate_Type.SelectedItem.ToString().Equals("班级表(含岗位)") )
			{
				if ( gridView2.RowCount > 0 )
				{
					DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
					if ( messageResult == DialogResult.Yes )
					{
						string getOriClassNumber = gridView2.GetDataRow(gridView2.GetSelectedRows()[0])["ClassNumber"].ToString();
						string getOriGradeNumber = gridView2.GetDataRow(gridView2.GetSelectedRows()[0])["GradeNumber"].ToString();

						int rowsAffected = optionSystem.DeleteClassInfo(getOriClassNumber,getOriGradeNumber);

						if ( rowsAffected <= 0 )
							MessageBox.Show("网络连接失败，请检查网络文档！");
						else
							MessageBox.Show("删除完毕！");
					}
				}
				else
					MessageBox.Show("不存在的数据！","系统信息",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
			}	
			else if ( comboBoxEdit_BatchCreate_Type.SelectedItem.ToString().Equals("学生基本信息表") )
			{
				if ( advBandedGridView1.RowCount > 0 )
				{
					DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
					if ( messageResult == DialogResult.Yes )
					{
						string getID = advBandedGridView1.GetDataRow(advBandedGridView1.GetSelectedRows()[0])["info_stuID"].ToString();

						int rowsAffected = optionSystem.DeleteStudentInfo(getID);

						if ( rowsAffected <= 0 )
							MessageBox.Show("网络连接失败，请检查网络");
						else
							MessageBox.Show("删除完毕！");
					}
				}
				else
					MessageBox.Show("不存在的数据！","系统信息",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
			}
			else if ( comboBoxEdit_BatchCreate_Type.SelectedItem.ToString().Equals("学生卡号表") )
			{
				if ( gridView4.RowCount > 0 )
				{
					DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
					if ( messageResult == DialogResult.Yes )
					{
						string getID = gridView4.GetDataRow(gridView4.GetSelectedRows()[0])["info_stuBasicID"].ToString();
						int getSeq = Convert.ToInt32(gridView4.GetDataRow(gridView4.GetSelectedRows()[0])["info_stuCardSeq"]);

						int rowsAffected = optionSystem.DeleteStuCardInfo(getID,getSeq);

						if ( rowsAffected <= 0 )
							MessageBox.Show("网络连接失败，请检查网络");
						else
							MessageBox.Show("删除完毕！");
					}
				}
				else
					MessageBox.Show("不存在的数据！","系统信息",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
			}
			else if ( comboBoxEdit_BatchCreate_Type.SelectedItem.ToString().Equals("教师基本信息表") )
			{
				if ( gridView5.RowCount > 0 )
				{
					DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
					if ( messageResult == DialogResult.Yes )
					{
						string getID = gridView5.GetDataRow(gridView5.GetSelectedRows()[0])["T_ID"].ToString();
						string getNumber = gridView5.GetDataRow(gridView5.GetSelectedRows()[0])["T_Number"].ToString();

						int rowsAffected = optionSystem.DeleteTeaInfo(getID,getNumber);

						
						if ( rowsAffected <= 0 )
							MessageBox.Show("网络连接失败，请检查网络");
						else
							MessageBox.Show("删除完毕！");
					}
				}
				else
					MessageBox.Show("不存在的数据！","系统信息",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
			}
			else if ( comboBoxEdit_BatchCreate_Type.SelectedItem.ToString().Equals("教师卡号表") )
			{
				if ( gridView6.RowCount > 0 )
				{
					DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
					if ( messageResult == DialogResult.Yes )
					{
						string getID = gridView6.GetDataRow(gridView6.GetSelectedRows()[0])["info_teaBasicID"].ToString();
						int getSeq = Convert.ToInt32(gridView6.GetDataRow(gridView6.GetSelectedRows()[0])["info_teaCardSeq"]);

						int rowsAffected = optionSystem.DeleteTeaCardInfo(getID,getSeq);
						
						if ( rowsAffected <= 0 )
							MessageBox.Show("网络连接失败，请检查网络");
						else
							MessageBox.Show("删除完毕！");
					}
				}
				else
					MessageBox.Show("不存在的数据！","系统信息",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
			}
			else
			{
				if ( gridView7.RowCount > 0 )
				{
					DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
					if ( messageResult == DialogResult.Yes )
					{
						int getMachineAddr = Convert.ToInt32(gridView7.GetDataRow(gridView7.GetSelectedRows()[0])["machine_address"]);
						int getMachineType = Convert.ToInt32(gridView7.GetDataRow(gridView7.GetSelectedRows()[0])["machine_type"]);

						int rowsAffected = optionSystem.DeleteMachineInfo(getMachineAddr,getMachineType);
						
						if ( rowsAffected <= 0 )
							MessageBox.Show("网络连接失败，请检查网络");
						else
							MessageBox.Show("删除完毕！");
					}
				}
			}
		}

		private void DataListAdd()
		{
			if ( gridControl_BatchCreate_Machine.Visible )
                gridControl_BatchCreate_Machine.EmbeddedNavigator.Buttons.DoClick(gridControl_BatchCreate_Machine.EmbeddedNavigator.Buttons.Append);
				//gridControl_BatchCreate_Machine.EmbeddedNavigator.Buttons.Append.DoClick();
			else
				MessageBox.Show("添加空记录操作只允许在Machine表中进行！");
		}	

		private void DataListSave()
		{	
			if ( gridControl_BatchCreate_Machine.Visible )
			{
				if ( gridView7.RowCount > 0 )
				{
					string getAddr = gridView7.GetDataRow(gridView7.GetSelectedRows()[0])["machine_address"].ToString();
					string getType = gridView7.GetDataRow(gridView7.GetSelectedRows()[0])["machine_type"].ToString();
					string getVol = gridView7.GetDataRow(gridView7.GetSelectedRows()[0])["machine_volumn"].ToString();
					bool isOk = false;
					string rtnMsg = optionSystem.CheckMachine(getAddr,getType,getVol,ref isOk);
					if ( isOk )
					{
						string message = "是否保存这条记录？";
						string caption = "系统信息";
						DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
						if ( messageResult == DialogResult.Yes )
						{
			
							int rowsAffected = optionSystem.InsertMachine(getAddr,getType,getVol);

							if ( rowsAffected == -1 )
								MessageBox.Show("有硬件地址重复，更新失败！");
							else if ( rowsAffected == 0 )
								MessageBox.Show("网络连接失败，请检查网络文档！");
							else
								MessageBox.Show("保存成功！");
						}	
					}
					else
						MessageBox.Show(rtnMsg);
				}
			}
			else
				MessageBox.Show("保存记录只允许在Machine表中进行！");
		}

		private int CheckValidMsg(string getMsg,ref bool isOk,string getName,string getClassName)
		{
			string message = "在处理名为["+getClassName+"]["+getName+"]的记录时发生错误，错误记录信息标识为：\n"+getMsg+"\n是否继续？";
			string caption = "系统信息";
			
			if ( !isOk )
			{
				isOk = false;

				DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.AbortRetryIgnore,MessageBoxIcon.Question);
				if ( messageResult == DialogResult.Abort )
					return -1;
				else if ( messageResult == DialogResult.Retry )
					return 1;
				else
					return 2;
			}
			else
			{
				isOk = false;
				return 0;
			}
		}

		private string DebugErrors(string errTitle,string errMsg)
		{
			DebugErrors debugErr = new DebugErrors(errTitle,errMsg);
			debugErr.ShowDialog();

			return debugErr.DebugErrorContent();
		}

		#endregion

		#region Update Grade 
		private void textEdit_DestGrade_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if ( e.KeyCode == Keys.Enter )
			{
				string message = "是否确认更改年级名？";
				string caption = "消息提示框!";
				
				DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
				if ( messageResult == DialogResult.Yes )
				{
					int rtnValue = optionSystem.UpdateGradeNameByNumber(comboBoxEdit_GradeNumber.SelectedItem.ToString(),textEdit_DestGrade.Text.Replace(" ",""));

					if ( rtnValue == 0 ) MessageBox.Show("年级名更新失败！");
					else if ( rtnValue == -1 ) MessageBox.Show("网络连接失败！");
					else MessageBox.Show("年级名更新成功！");

					BindingGradeNumber();
				}
			}
		}

		private void textEdit_DestClass_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if ( e.KeyCode == Keys.Enter )
			{
				string message = "是否确认更改班级名？";
				string caption = "消息提示框!";
				
				DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
				if ( messageResult == DialogResult.Yes )
				{
					int rtnValue = optionSystem.UpdateClassNameByNumber(comboBoxEdit_GradeNumber.SelectedItem.ToString(),
						comboBoxEdit_ClassNumber.SelectedItem.ToString(),textEdit_DestClass.Text.Replace(" ",""));

					if ( rtnValue == 0 ) MessageBox.Show("班级名更新失败！");
					else if ( rtnValue == -1 ) MessageBox.Show("网络连接失败！");
					else MessageBox.Show("班级名更新成功！");

					BindingClassNumber();
				}
			}
		}

		private void simpleButton_LoadTable_Click(object sender, System.EventArgs e)
		{
			if(openFileDialog_LoadStuInfoXLS.ShowDialog() == DialogResult.OK) 
			{
				DataTable dtUpdateGradeInfo = optionSystem.ReadUpdateGradeInfo(Path.GetFullPath(openFileDialog_LoadStuInfoXLS.FileName));

				if ( dtUpdateGradeInfo.Rows.Count > 0)
				{
					for ( int i=dtUpdateGradeInfo.Rows.Count; i> 0; i-- )
					{
						DataRow dr = dtUpdateGradeInfo.Rows[i-1];

						TryName:
						{
							bool isOk = false;
							string result = optionSystem.CheckName(dr[0].ToString(),ref isOk);

							if ( !isOk )
							{
								ShowErrorHandling(dr[0].ToString(),dr[1].ToString(),dr[2].ToString(),dr[3].ToString(),3,result);
								dr[0] = htUpdateInfo["name"];
								goto TryName;
							}
						}

						TryGrade:
						{
							bool isOk = false;
							string result = optionSystem.CheckIsGradeExists(dr[1].ToString(),ref isOk);

							if ( !isOk )
							{
								ShowErrorHandling(dr[0].ToString(),dr[1].ToString(),dr[2].ToString(),dr[3].ToString(),0,result);
								dr[1] = htUpdateInfo["grade"];
								goto TryGrade;
							}
						}

						TryClass:
						{
							bool isOk = false;
							string result = optionSystem.CheckIsClassExists(dr[1].ToString(),dr[2].ToString(),ref isOk);

							if ( !isOk )
							{
								ShowErrorHandling(dr[0].ToString(),dr[1].ToString(),dr[2].ToString(),dr[3].ToString(),1,result);
								dr[2] = htUpdateInfo["class"];
								goto TryClass;
							}
						}

						TryType:
						{
							bool isOk = false;
							string result = optionSystem.CheckType(dr[3].ToString(),ref isOk);

							if ( !isOk )
							{
								ShowErrorHandling(dr[0].ToString(),dr[1].ToString(),dr[2].ToString(),dr[3].ToString(),2,result);
								dr[3] = htUpdateInfo["type"];
								goto TryType;
							}
						}

						if ( optionSystem.UpdateStudentForGradeChange(dr[0].ToString().Replace(" ",""),Convert.ToInt32(dr[1]),Convert.ToInt32(dr[2]),dr[3].ToString().Replace(" ","")) )
						{
							dr.Delete();
							dr.AcceptChanges();
						}
					}
				}

				if ( dtUpdateGradeInfo.Rows.Count > 0 )
				{
					MessageBox.Show("系统检测到有新的学生，请在不匹配信息列表中指定该些学生是新生还是由其他错误引起的！","系统信息",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
					gridControl_StudentAdjust.DataSource = dtUpdateGradeInfo;
				}
			}
		}

		private void simpleButton_Submit_Click(object sender, System.EventArgs e)
		{
			for( int i=gridView3.DataRowCount-1; i>=0; i-- )
			{
				TryName:
				{
					bool isOk = false;

					string stuName = gridView3.GetDataRow(i)["info_stuName"].ToString().Replace(" ","");
					int gradeNumber = Convert.ToInt32(gridView3.GetDataRow(i)["info_stuGrade"]);
					int classNumber = Convert.ToInt32(gridView3.GetDataRow(i)["info_stuClass"]);
					string stuType = gridView3.GetDataRow(i)["info_type"].ToString().Replace(" ","");

					string result = optionSystem.CheckName(stuName,ref isOk);

					if ( !isOk )
					{
						ShowErrorHandling(stuName,gradeNumber.ToString(),classNumber.ToString(),stuType.ToString(),3,result);
						gridView3.SetRowCellValue(i,"info_stuName",htUpdateInfo["name"]);
						goto TryName;
					}
				}

				TryGrade:
				{
					bool isOk = false;

					string stuName = gridView3.GetDataRow(i)["info_stuName"].ToString().Replace(" ","");
					int gradeNumber = Convert.ToInt32(gridView3.GetDataRow(i)["info_stuGrade"]);
					int classNumber = Convert.ToInt32(gridView3.GetDataRow(i)["info_stuClass"]);
					string stuType = gridView3.GetDataRow(i)["info_type"].ToString().Replace(" ","");

					string result = optionSystem.CheckIsGradeExists(gradeNumber.ToString(),ref isOk);

					if ( !isOk )
					{
						ShowErrorHandling(stuName,gradeNumber.ToString(),classNumber.ToString(),stuType.ToString(),0,result);
						gridView3.SetRowCellValue(i,"info_stuGrade",htUpdateInfo["grade"]);
						goto TryGrade;
					}
				}

				TryClass:
				{
					bool isOk = false;

					string stuName = gridView3.GetDataRow(i)["info_stuName"].ToString().Replace(" ","");
					int gradeNumber = Convert.ToInt32(gridView3.GetDataRow(i)["info_stuGrade"]);
					int classNumber = Convert.ToInt32(gridView3.GetDataRow(i)["info_stuClass"]);
					string stuType = gridView3.GetDataRow(i)["info_type"].ToString().Replace(" ","");

					string result = optionSystem.CheckIsClassExists(gradeNumber.ToString(),classNumber.ToString(),ref isOk);

					if ( !isOk )
					{
						ShowErrorHandling(stuName,gradeNumber.ToString(),classNumber.ToString(),stuType.ToString(),1,result);
						gridView3.SetRowCellValue(i,"info_stuClass",htUpdateInfo["class"]);
						goto TryClass;
					}
				}

				TryType:
				{
					bool isOk = false;

					string stuName = gridView3.GetDataRow(i)["info_stuName"].ToString().Replace(" ","");
					int gradeNumber = Convert.ToInt32(gridView3.GetDataRow(i)["info_stuGrade"]);
					int classNumber = Convert.ToInt32(gridView3.GetDataRow(i)["info_stuClass"]);
					string stuType = gridView3.GetDataRow(i)["info_type"].ToString().Replace(" ","");

					string result = optionSystem.CheckType(stuType,ref isOk);

					if ( !isOk )
					{
						ShowErrorHandling(stuName,gradeNumber.ToString(),classNumber.ToString(),stuType.ToString(),2,result);
						gridView3.SetRowCellValue(i,"info_type",htUpdateInfo["type"]);
						goto TryType;
					}
				}

				if ( gridView3.GetDataRow(i)["info_checkType"].ToString().Equals("True") )
				{
					int rtnValue = optionSystem.InsertNewStudentForGradeChange(gridView3.GetDataRow(i)["info_stuName"].ToString().Replace(" ",""),Convert.ToInt32(gridView3.GetDataRow(i)["info_stuGrade"])
						,Convert.ToInt32(gridView3.GetDataRow(i)["info_stuClass"]),gridView3.GetDataRow(i)["info_type"].ToString().Replace(" ",""));

					if ( rtnValue > 0 ) gridView3.DeleteRow(i);
				}
				else
				{
					bool rtnValue = optionSystem.UpdateStudentForGradeChange(gridView3.GetDataRow(i)["info_stuName"].ToString().Replace(" ",""),Convert.ToInt32(gridView3.GetDataRow(i)["info_stuGrade"])
						,Convert.ToInt32(gridView3.GetDataRow(i)["info_stuClass"]),gridView3.GetDataRow(i)["info_type"].ToString().Replace(" ",""));

					if ( rtnValue ) gridView3.DeleteRow(i);
				}
			}

			MessageBox.Show("新生录入完毕，请在学生基本信息中补全学生其他信息，并进行发卡！","系统信息",MessageBoxButtons.YesNo,MessageBoxIcon.Information);

			if ( gridView3.RowCount > 0 ) MessageBox.Show("系统检测到还存在无法匹配的学生，是否以前输入的学生名与现在所使用的学生名不符？请在不匹配信息列表中双击该学生，并用学号查询重试！","系统信息",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
				
		}

		private void comboBoxEdit_GradeNumber_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindingGradeNumber();
		}

		private void comboBoxEdit_ClassNumber_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindingClassNumber();
		}

		private void BindingGradeNumber()
		{
			DataTable dtGradeName = optionSystem.GetGradeNameByNumber(comboBoxEdit_GradeNumber.SelectedItem.ToString());
			DataTable dtClassNumberList = optionSystem.GetClassNumberList(comboBoxEdit_GradeNumber.SelectedItem.ToString());
			comboBoxEdit_SrcGrade.Properties.Items.Clear();
			comboBoxEdit_ClassNumber.Properties.Items.Clear();

			if ( dtGradeName.Rows.Count > 0 )
			{
				comboBoxEdit_SrcGrade.Properties.Items.AddRange(new object[]{dtGradeName.Rows[0]["info_gradeName"]});
				textEdit_DestGrade.Enabled = true;
			}
			else
			{
				comboBoxEdit_SrcGrade.Properties.Items.AddRange(new object[]{"无法获取年级信息！"});
				textEdit_DestGrade.Enabled = false;
			}

			comboBoxEdit_SrcGrade.SelectedIndex = 0;

			if ( dtClassNumberList.Rows.Count > 0 )
			{
				foreach ( DataRow dr in dtClassNumberList.Rows )
					comboBoxEdit_ClassNumber.Properties.Items.AddRange(new object[]{dr["info_classNumber"]});

				textEdit_DestClass.Enabled = true;
			}
			else
			{
				comboBoxEdit_ClassNumber.Properties.Items.AddRange(new object[]{"无法获取班级信息！"});
				textEdit_DestClass.Enabled = false;
			}


			//wrong
			comboBoxEdit_ClassNumber.SelectedIndex = 0;

			DataTable dtClassName = optionSystem.GetClassNameByNumber(comboBoxEdit_GradeNumber.SelectedItem.ToString(),
				comboBoxEdit_ClassNumber.SelectedItem.ToString());

			comboBoxEdit_SrcClass.Properties.Items.Clear();

			if ( dtClassName.Rows.Count > 0 )
			{
				foreach ( DataRow dr in dtClassName.Rows )
					comboBoxEdit_SrcClass.Properties.Items.AddRange(new object[]{dr["info_className"]});

				textEdit_DestClass.Enabled = true;
			}
			else
			{
				comboBoxEdit_SrcClass.Properties.Items.AddRange(new object[]{"无法获取班级信息！"});

				textEdit_DestClass.Enabled  = false;
			}

			comboBoxEdit_SrcClass.SelectedIndex = 0;
		}

		private void BindingClassNumber()
		{
			DataTable dtClassName = optionSystem.GetClassNameByNumber(comboBoxEdit_GradeNumber.SelectedItem.ToString(),
				comboBoxEdit_ClassNumber.SelectedItem.ToString());

			comboBoxEdit_SrcClass.Properties.Items.Clear();

			if ( dtClassName.Rows.Count > 0 )
			{
				foreach ( DataRow dr in dtClassName.Rows )
					comboBoxEdit_SrcClass.Properties.Items.AddRange(new object[]{dr["info_className"]});

				textEdit_DestClass.Enabled = true;
			}
			else
			{
				comboBoxEdit_SrcClass.Properties.Items.AddRange(new object[]{"无法获取班级信息！"});
				textEdit_DestClass.Enabled = false;
			}

			comboBoxEdit_SrcClass.SelectedIndex = 0;
		}

		private void ShowErrorHandling(string getName,string getGrade,string getClass,string getType,int errorCode,string errorMsg)
		{
			ErrorHandlingForGradeChange errorHandling = new ErrorHandlingForGradeChange(getName,getGrade,getClass,getType,errorCode,errorMsg);
			errorHandling.StartPosition = FormStartPosition.CenterScreen;
			errorHandling.ShowDialog();
				
			htUpdateInfo = errorHandling.UpdateInfo;
		}
		#endregion

		#region backup
		private void smbRoot_Click(object sender, System.EventArgs e)
		{
			if(saveFileDialog_createbackup.ShowDialog() == DialogResult.OK)
			{
				string backupFileName = saveFileDialog_createbackup.FileName;
				if (backupFileName.IndexOf(".") >= 0)
				{
					tbxBackUpRoot.Text = string.Empty;
					MessageBox.Show("文件名含有非法字符，请重试！");
					return;
				}

				tbxBackUpRoot.Text = backupFileName+".scb";
                new OptionSystem().AddOrUpdateBackupPath(tbxBackUpRoot.Text.Trim());
			}
		}

		private void smbBackUp_Click(object sender, System.EventArgs e)
		{
			DialogResult messageResult = MessageBox.Show("您是否确定要备份数据？","数据备份",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult == DialogResult.Yes )
			{
				if (!tbxBackUpRoot.Text.Equals(string.Empty))
				{
					int type = 3;
					if (rbtStart.Checked) type = 1;
					else if (rbtIdle.Checked) type = 2;
					else type = 3;
				
					if (optionSystem.ExecuteBackupFully(tbxBackUpRoot.Text.Trim()))
					{
                        string root = tbxBackUpRoot.Text.Substring(0, tbxBackUpRoot.Text.IndexOf(".scb")) + ".sdib";
                        if (!optionSystem.ExecuteBackupDiff(root))
                        {
                            MessageBox.Show("数据备份中出现未知错误，请检查网络连接，然后重启软件后重试！");
                        }
                        else
                        {
                            MessageBox.Show("备份已成功完成！");
                        }

                        //if (!optionSystem.AddBackupJob(type,tbxBackUpRoot.Text.Trim()))
                        //{
                        //    MessageBox.Show("数据备份中出现未知错误，请检查网络连接，然后重启软件后重试！");
                        //}
                        //else
                        //{
                        //    string root = tbxBackUpRoot.Text.Substring(0,tbxBackUpRoot.Text.IndexOf(".scb")) + ".sdib";
                        //    if (!optionSystem.ExecuteBackupDiff(root))
                        //    {
                        //        MessageBox.Show("数据备份中出现未知错误，请检查网络连接，然后重启软件后重试！");
                        //    }
                        //    else
                        //    {
                        //        MessageBox.Show("备份已成功完成！");
                        //    }
                        //}
					}
					else MessageBox.Show("数据备份中出现未知错误，请检查网络连接，然后重启软件后重试！");
				}
				else MessageBox.Show("请先选择备份保存路径！");
			}
		}
		#endregion

        #region Camera
        private void gridView10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                var dt = gridControl1.DataSource as DataTable;
                if (dt != null)
                {
                    dt.Rows.Add(dt.NewRow());
                }
            }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var rowIndex = gridView10.FocusedRowHandle;
            var row = gridView10.GetDataRow(rowIndex);
            dynamic camera = new ExpandoObject();

            if (row["machineName"] is DBNull)
            {
                MessageBox.Show("请选择摄像头所在的门口机!", "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (row["cameraName"] is DBNull)
            {
                MessageBox.Show("请选择摄像头所在的线路!", "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (row["cameraAddr"] is DBNull)
            {
                MessageBox.Show("摄像头地址必须填写!", "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (row["cameraStream"] is DBNull)
            {
                MessageBox.Show("请选择图像传输码流!", "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (row["cameraEncoding"] is DBNull)
            {
                MessageBox.Show("请选择图像编码格式!", "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!repositoryItemComboBox4.Items.Contains(row["machineName"].ToString()))
            {
                MessageBox.Show("不正确的门口机!", "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!repositoryItemComboBox1.Items.Contains(row["cameraName"].ToString()))
            {
                MessageBox.Show("不正确的摄像头线路!", "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!repositoryItemComboBox2.Items.Contains(row["cameraStream"].ToString()))
            {
                MessageBox.Show("不正确的视频码流!", "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!repositoryItemComboBox3.Items.Contains(row["cameraEncoding"].ToString()))
            {
                MessageBox.Show("不正确的视频编码!", "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            camera.idx = row["idx"] is DBNull ? -1 : Convert.ToInt32(row["idx"]);
            camera.MachineNo = Convert.ToInt32(row["machineName"].ToString().Replace("号门口机", string.Empty));
            camera.Name = row["cameraName"].ToString();
            camera.Addr = row["cameraAddr"].ToString();
            camera.Stream = row["cameraStream"].ToString();
            camera.Encoding = row["cameraEncoding"].ToString();
            camera.Credentials = string.Empty;

            new CameraSystem().AddOrUpdateCamera(camera);
        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var rowIndex = gridView10.FocusedRowHandle;
            var row = gridView10.GetDataRow(rowIndex);
            if (!(row["idx"] is DBNull))
            {
                new CameraSystem().DeleteCamera(Convert.ToInt32(row["idx"]));
            }
            gridView10.DeleteRow(rowIndex);
            gridControl1.Refresh();
        }

        private void repositoryItemButtonEdit3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var rowIndex = gridView10.FocusedRowHandle;
            var row = gridView10.GetDataRow(rowIndex);
            if (row["cameraStream"].ToString().Equals("JPEG"))
            {
                var jpegStream = new JPEGStream();
                jpegStream.Source = row["cameraAddr"].ToString();
                var credential = row["credentials"].ToString();
                if (credential.Split(':').Length == 2)
                {
                    jpegStream.Login = credential.Split(':')[0];
                    jpegStream.Password = credential.Split(':')[1];
                    jpegStream.ForceBasicAuthentication = true;
                }
                if (jpegStream.TestConnecting())
                {
                    MessageBox.Show("线路连接成功！", "成功了!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else 
                {
                    MessageBox.Show("线路连接失败！", "失败了!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        private void gridControl_StudentAdjust_DoubleClick(object sender, System.EventArgs e)
		{
			int selectedRow = gridView3.GetSelectedRows()[0];

			string stuName = gridView3.GetDataRow(selectedRow)["info_stuName"].ToString();
			string stuGrade = gridView3.GetDataRow(selectedRow)["info_stuGrade"].ToString();
			string stuClass = gridView3.GetDataRow(selectedRow)["info_stuClass"].ToString();
			string stuType = gridView3.GetDataRow(selectedRow)["info_type"].ToString();

			ErrorHandlingForGradeChange errorHandling = new ErrorHandlingForGradeChange(stuName,stuGrade,stuClass,stuType,3,"无法找到匹配的幼儿信息！");
			errorHandling.StartPosition = FormStartPosition.CenterScreen;
			errorHandling.ShowDialog();
			
			htUpdateInfo = errorHandling.UpdateInfo;

			gridView3.SetRowCellValue(selectedRow,"info_stuName",htUpdateInfo["name"].ToString());
			gridView3.SetRowCellValue(selectedRow,"info_stuGrade",htUpdateInfo["grade"].ToString());
			gridView3.SetRowCellValue(selectedRow,"info_stuClass",htUpdateInfo["class"].ToString());
			gridView3.SetRowCellValue(selectedRow,"info_type",htUpdateInfo["type"].ToString());
		}

		private void barButtonItem_DeleteSession_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			string message = "断开所选用户？";
			string caption = "消息提示框!";
			int selectedRow = gridView9.GetSelectedRows()[0];

			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult == DialogResult.Yes )
			{
				int retVal = new UtilSystem().DeleteSessionClient(gridView9.GetDataRow(selectedRow)["session_LoginMac"].ToString());

				if ( retVal == 1 ) gridControl_SessionUser.DataSource = new UtilSystem().GetSessionDetails();
				else MessageBox.Show("断开操作失败，请重试！");
			}

		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			DataSet ds = new UtilSystem().GetUploadInfoForXDD();
			if (ds != null && ds.Tables.Count == 2)
			{
				try
				{
					SystemFramework.Util.UploadInfoToXDD(ds.Tables[0].Rows[0]["info_gardenID"].ToString(), ds.Tables[0].Rows[0]["info_gardenName"].ToString(), ds.Tables[1]);
					MessageBox.Show("数据上传成功！");
				}
				catch(Exception)
				{
					MessageBox.Show("数据上传失败！");
				}
			}
		}

        private static void DoBackupPeriodically(object state)
        {
            backupTimer.Change(Timeout.Infinite, Timeout.Infinite);
            var path = new OptionSystem().GetBackupPath();
            if (!string.IsNullOrEmpty(path))
            {
                string root = path.Substring(0, path.IndexOf(".scb")) + ".sdib";
                new OptionSystem().ExecuteBackupDiff(root);
            }
            backupTimer.Change(60 * 1000, Timeout.Infinite);
        }

        private void gridView4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46)
            {
                var rows = gridView4.GetSelectedRows();
                if (rows.Length >= 1)
                {
                    var rowIdx = rows[0];
                    var row = (gridView4.GetRow(rowIdx) as System.Data.DataRowView).Row;

                    var diagResult = MessageBox.Show(string.Format("是否要删除卡号为[{0}]的记录？", row[2].ToString()), "卡记录删除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (diagResult == System.Windows.Forms.DialogResult.Yes)
                    {
                        new CardInfoSystem().DeleteCardInfo(row[2].ToString());
                        gridView4.DeleteRow(rowIdx);
                        gridView4.RefreshData();
                    }
                }
            }
        }

        private void gridView6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46)
            {
                var rows = gridView6.GetSelectedRows();
                if (rows.Length >= 1)
                {
                    var rowIdx = rows[0];
                    var row = (gridView6.GetRow(rowIdx) as System.Data.DataRowView).Row;

                    var diagResult = MessageBox.Show(string.Format("是否要删除卡号为[{0}]的记录？", row[2].ToString()), "卡记录删除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (diagResult == System.Windows.Forms.DialogResult.Yes)
                    {
                        new CardInfoSystem().DeleteTeaCardInfo(row[2].ToString());
                        gridView6.DeleteRow(rowIdx);
                        gridView6.RefreshData();
                    }
                }
            }
        }
	}
}

