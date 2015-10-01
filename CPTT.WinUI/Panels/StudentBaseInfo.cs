using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CPTT.BusinessFacade;
using CPTT.SystemFramework;
using System.IO;
using System.Threading;

namespace CPTT.WinUI.Panels
{
	/// <summary>
	/// Summary description for StudentBaseInfo.
	/// </summary>
	public class StudentBaseInfo : DevExpress.XtraEditors.XtraUserControl
	{
		private DevExpress.XtraTab.XtraTabControl xtraTabControl_StuBaseInfo;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage_StuBaseInfoMgmt;
		private DevExpress.XtraEditors.SplitterControl splitterControl1;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl_StuBaseInfo;
		private DevExpress.XtraEditors.SimpleButton simpleButton_NewFile;
		private DevExpress.XtraEditors.SimpleButton simpleButton_BlankButton;
		private DevExpress.XtraEditors.SimpleButton simpleButton_SaveButton;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.XtraEditors.TextEdit textEdit_KidName;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_KidGender;
		private DevExpress.Utils.Frames.NotePanel notePanel_KidName;
		private DevExpress.Utils.Frames.NotePanel notePanel_KidGender;
		private DevExpress.Utils.Frames.NotePanel notePanel_Birthday;
		private DevExpress.Utils.Frames.NotePanel notePanel_EnrollTime;
		private DevExpress.Utils.Frames.NotePanel notePanel_KidOrigin;
		private DevExpress.Utils.Frames.NotePanel notePanel_EnrollKind;
		private DevExpress.Utils.Frames.NotePanel notePanel_KidNumber;
		private System.Windows.Forms.Label label_RegOfEnrollKind;
		private System.Windows.Forms.Label label_RegOfEnrollTime;
		private System.Windows.Forms.Label label_RegOfBirthday;
		private System.Windows.Forms.Label label_RegOfKidGender;
		private System.Windows.Forms.Label label_ReqOfKidName;
		private DevExpress.XtraEditors.GroupControl groupControl2;
		private DevExpress.Utils.Frames.NotePanel notePanel_KidBaseInfoTitle;
		private DevExpress.XtraEditors.GroupControl groupControl3;
		private DevExpress.Utils.Frames.NotePanel notePanel19;
		private DevExpress.XtraEditors.TextEdit textEdit_MOWorkingAddr;
		private DevExpress.XtraEditors.TextEdit textEdit_MOPhone;
		private DevExpress.XtraEditors.TextEdit textEdit_MOName;
		private DevExpress.Utils.Frames.NotePanel notePanel_MOPhone;
		private DevExpress.Utils.Frames.NotePanel notePanel_MOName;
		private DevExpress.XtraEditors.TextEdit textEdit_FAWorkingAddr;
		private DevExpress.Utils.Frames.NotePanel notePanel_FAWorkingAddr;
		private DevExpress.XtraEditors.TextEdit textEdit_FAPhone;
		private DevExpress.Utils.Frames.NotePanel notePanel_FAPhone;
		private DevExpress.XtraEditors.TextEdit textEdit_FAName;
		private DevExpress.Utils.Frames.NotePanel notePanel_FAName;
		private DevExpress.XtraEditors.TextEdit textEdit_ILLHistory;
		private DevExpress.XtraEditors.TextEdit textEdit_EMail;
		private DevExpress.XtraEditors.TextEdit textEdit_BankID;
		private DevExpress.Utils.Frames.NotePanel notePanel_ILLHistory;
		private DevExpress.Utils.Frames.NotePanel notePanel_EMail;
		private DevExpress.Utils.Frames.NotePanel notePanel_BankID;
		private DevExpress.XtraEditors.TextEdit textEdit_Street;
		private DevExpress.XtraEditors.TextEdit textEdit_JUWei;
		private DevExpress.Utils.Frames.NotePanel notePanel_ZIPCode;
		private DevExpress.Utils.Frames.NotePanel notePanel_Phone;
		private DevExpress.XtraEditors.TextEdit textEdit_ZIPCode;
		private DevExpress.XtraEditors.TextEdit textEdit_Native;
		private DevExpress.XtraEditors.TextEdit textEdit_Nationality;
		private DevExpress.Utils.Frames.NotePanel notePanel_JUWei;
		private DevExpress.Utils.Frames.NotePanel notePanel_Street;
		private DevExpress.Utils.Frames.NotePanel notePanel_Native;
		private DevExpress.Utils.Frames.NotePanel notePanel_Nationality;
		private DevExpress.XtraEditors.GroupControl groupControl4;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.Utils.Frames.NotePanel notePanel_Grade;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Grade;
		private DevExpress.Utils.Frames.NotePanel notePanel_Class;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Class;
		private DevExpress.XtraGrid.GridControl gridControl_ShowStu;
		private DevExpress.XtraBars.BarManager barManager1;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
		private DevExpress.XtraBars.PopupMenu popupMenu1;
		private DevExpress.XtraBars.BarButtonItem barButtonItem1;
		private DevExpress.XtraBars.BarButtonItem barButtonItem2;
		private DevExpress.XtraEditors.TextEdit textEdit_Number;
		private DevExpress.XtraEditors.TextEdit textEdit_Name;
		private DevExpress.Utils.Frames.NotePanel notePanel_Number;
		private DevExpress.Utils.Frames.NotePanel notePanel_Name;
		private DevExpress.Utils.Frames.NotePanel notePanel1;
		private System.ComponentModel.IContainer components = null;
		private DevExpress.XtraEditors.DataNavigator dataNavigator_SerStu;
		private DevExpress.XtraEditors.TextEdit textEdit_RegNote;
		private DevExpress.Utils.Frames.NotePanel notePanel_HuKouAddr;
		private DevExpress.XtraEditors.TextEdit textEdit_HuKouAddr;
		private DevExpress.Utils.Frames.NotePanel notePanel_FamilyAddr;
		private DevExpress.XtraEditors.TextEdit textEdit_FamilyAddr;
		private GetStuInfoByCondition getStuInfoByCondition;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn_stuNumber;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn_stuName;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn_stuClass;
		private DevExpress.XtraEditors.DateEdit dateEdit_EntryDate;
		private string getGradeNumberFromCombo = "0";
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_EntryStatus;
		private string getClassNumberFromCombo = "0";
		private StuValidationCheck stuValidationCheck;
		private Students students;
		private Guid guid;
		private DevExpress.XtraEditors.PictureEdit pictureEdit_LoadImageData;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private DevExpress.XtraEditors.TextEdit textEdit_GUID;
		private byte[] imageDataBuffer;
		private DevExpress.XtraEditors.TextEdit textEdit_KidOrigin;
		private DevExpress.XtraEditors.SimpleButton simpleButton_printButton;
		private StuBaseInfoPrintSystem stuBaseInfoPrintSystem;
		private DevExpress.XtraBars.PopupMenu popupMenu2;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_Refresh;
		private System.Windows.Forms.SaveFileDialog saveFileDialog_Report;
		private DevExpress.XtraEditors.DateEdit dateEdit_Birthday;
		private RolesSystem rolesSystem;
		private System.Windows.Forms.HelpProvider helpProvider_StuBaseInfo;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private MemoryStream imageMSReader;
		private DevExpress.XtraEditors.TextEdit textEdit_StuDefaultNumber;
		private bool isNewAdd = false;

		public StudentBaseInfo()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call
			getStuInfoByCondition = new GetStuInfoByCondition();
			stuValidationCheck = new StuValidationCheck();
			students = new Students();
			stuBaseInfoPrintSystem = new StuBaseInfoPrintSystem();
			rolesSystem = new RolesSystem();

			#region 帮助
			this.helpProvider_StuBaseInfo.HelpNamespace = System.IO.Path.GetDirectoryName(Application.ExecutablePath)
				+ CPTT.SystemFramework.Util.HELP_FILE_NAME;

			this.helpProvider_StuBaseInfo.SetHelpKeyword(this.xtraTabControl_StuBaseInfo,"学生基本信息管理");
			this.helpProvider_StuBaseInfo.SetHelpNavigator(this.xtraTabControl_StuBaseInfo, System.Windows.Forms.HelpNavigator.KeywordIndex);
			this.helpProvider_StuBaseInfo.SetHelpString(this.xtraTabControl_StuBaseInfo, "");
			this.helpProvider_StuBaseInfo.SetShowHelp(this.xtraTabControl_StuBaseInfo, true);
			#endregion
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentBaseInfo));
            this.xtraTabControl_StuBaseInfo = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage_StuBaseInfoMgmt = new DevExpress.XtraTab.XtraTabPage();
            this.notePanel1 = new DevExpress.Utils.Frames.NotePanel();
            this.splitContainerControl_StuBaseInfo = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControl_ShowStu = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_stuNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_stuName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_stuClass = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.dataNavigator_SerStu = new DevExpress.XtraEditors.DataNavigator();
            this.textEdit_Number = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_Name = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_Number = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_Name = new DevExpress.Utils.Frames.NotePanel();
            this.comboBoxEdit_Class = new DevExpress.XtraEditors.ComboBoxEdit();
            this.notePanel_Class = new DevExpress.Utils.Frames.NotePanel();
            this.comboBoxEdit_Grade = new DevExpress.XtraEditors.ComboBoxEdit();
            this.notePanel_Grade = new DevExpress.Utils.Frames.NotePanel();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_printButton = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.textEdit_MOWorkingAddr = new DevExpress.XtraEditors.TextEdit();
            this.notePanel19 = new DevExpress.Utils.Frames.NotePanel();
            this.textEdit_MOPhone = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_MOName = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_MOPhone = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_MOName = new DevExpress.Utils.Frames.NotePanel();
            this.textEdit_FAWorkingAddr = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_FAWorkingAddr = new DevExpress.Utils.Frames.NotePanel();
            this.textEdit_FAPhone = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_FAPhone = new DevExpress.Utils.Frames.NotePanel();
            this.textEdit_FAName = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_FAName = new DevExpress.Utils.Frames.NotePanel();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.notePanel_HuKouAddr = new DevExpress.Utils.Frames.NotePanel();
            this.textEdit_HuKouAddr = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_FamilyAddr = new DevExpress.Utils.Frames.NotePanel();
            this.textEdit_ILLHistory = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_EMail = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_BankID = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_ILLHistory = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_EMail = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_BankID = new DevExpress.Utils.Frames.NotePanel();
            this.textEdit_Street = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_JUWei = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_ZIPCode = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_Phone = new DevExpress.Utils.Frames.NotePanel();
            this.textEdit_ZIPCode = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_RegNote = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_Native = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_Nationality = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_JUWei = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_Street = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_Native = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_Nationality = new DevExpress.Utils.Frames.NotePanel();
            this.textEdit_FamilyAddr = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.textEdit_StuDefaultNumber = new DevExpress.XtraEditors.TextEdit();
            this.dateEdit_Birthday = new DevExpress.XtraEditors.DateEdit();
            this.textEdit_KidOrigin = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_GUID = new DevExpress.XtraEditors.TextEdit();
            this.dateEdit_EntryDate = new DevExpress.XtraEditors.DateEdit();
            this.label_RegOfEnrollKind = new System.Windows.Forms.Label();
            this.label_RegOfEnrollTime = new System.Windows.Forms.Label();
            this.label_RegOfBirthday = new System.Windows.Forms.Label();
            this.label_RegOfKidGender = new System.Windows.Forms.Label();
            this.label_ReqOfKidName = new System.Windows.Forms.Label();
            this.notePanel_KidBaseInfoTitle = new DevExpress.Utils.Frames.NotePanel();
            this.pictureEdit_LoadImageData = new DevExpress.XtraEditors.PictureEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem_Refresh = new DevExpress.XtraBars.BarButtonItem();
            this.comboBoxEdit_EntryStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.notePanel_KidNumber = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_EnrollKind = new DevExpress.Utils.Frames.NotePanel();
            this.comboBoxEdit_KidGender = new DevExpress.XtraEditors.ComboBoxEdit();
            this.textEdit_KidName = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_KidOrigin = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_EnrollTime = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_Birthday = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_KidGender = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_KidName = new DevExpress.Utils.Frames.NotePanel();
            this.simpleButton_BlankButton = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_SaveButton = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_NewFile = new DevExpress.XtraEditors.SimpleButton();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.popupMenu2 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.saveFileDialog_Report = new System.Windows.Forms.SaveFileDialog();
            this.helpProvider_StuBaseInfo = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_StuBaseInfo)).BeginInit();
            this.xtraTabControl_StuBaseInfo.SuspendLayout();
            this.xtraTabPage_StuBaseInfoMgmt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl_StuBaseInfo)).BeginInit();
            this.splitContainerControl_StuBaseInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ShowStu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Number.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Class.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Grade.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_MOWorkingAddr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_MOPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_MOName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_FAWorkingAddr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_FAPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_FAName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_HuKouAddr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_ILLHistory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_EMail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_BankID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Street.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_JUWei.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_ZIPCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_RegNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Native.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Nationality.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_FamilyAddr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_StuDefaultNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_Birthday.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_Birthday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_KidOrigin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_GUID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_EntryDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_EntryDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit_LoadImageData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_EntryStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_KidGender.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_KidName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl_StuBaseInfo
            // 
            this.xtraTabControl_StuBaseInfo.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xtraTabControl_StuBaseInfo.Appearance.Options.UseBackColor = true;
            this.xtraTabControl_StuBaseInfo.AppearancePage.HeaderActive.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.xtraTabControl_StuBaseInfo.AppearancePage.HeaderActive.ForeColor = System.Drawing.Color.DarkOrange;
            this.xtraTabControl_StuBaseInfo.AppearancePage.HeaderActive.Options.UseFont = true;
            this.xtraTabControl_StuBaseInfo.AppearancePage.HeaderActive.Options.UseForeColor = true;
            this.xtraTabControl_StuBaseInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl_StuBaseInfo.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl_StuBaseInfo.Name = "xtraTabControl_StuBaseInfo";
            this.xtraTabControl_StuBaseInfo.SelectedTabPage = this.xtraTabPage_StuBaseInfoMgmt;
            this.xtraTabControl_StuBaseInfo.Size = new System.Drawing.Size(772, 704);
            this.xtraTabControl_StuBaseInfo.TabIndex = 1;
            this.xtraTabControl_StuBaseInfo.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage_StuBaseInfoMgmt});
            // 
            // xtraTabPage_StuBaseInfoMgmt
            // 
            this.xtraTabPage_StuBaseInfoMgmt.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xtraTabPage_StuBaseInfoMgmt.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabPage_StuBaseInfoMgmt.Controls.Add(this.notePanel1);
            this.xtraTabPage_StuBaseInfoMgmt.Controls.Add(this.splitContainerControl_StuBaseInfo);
            this.xtraTabPage_StuBaseInfoMgmt.Name = "xtraTabPage_StuBaseInfoMgmt";
            this.xtraTabPage_StuBaseInfoMgmt.Size = new System.Drawing.Size(766, 675);
            this.xtraTabPage_StuBaseInfoMgmt.Text = "基本信息管理";
            // 
            // notePanel1
            // 
            this.notePanel1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.notePanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.notePanel1.ForeColor = System.Drawing.Color.OrangeRed;
            this.notePanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel1.Location = new System.Drawing.Point(0, 0);
            this.notePanel1.MaxRows = 5;
            this.notePanel1.Name = "notePanel1";
            this.notePanel1.ParentAutoHeight = true;
            this.notePanel1.Size = new System.Drawing.Size(766, 23);
            this.notePanel1.TabIndex = 5;
            this.notePanel1.TabStop = false;
            this.notePanel1.Text = "某某老师欢迎进入学生基本信息检索";
            // 
            // splitContainerControl_StuBaseInfo
            // 
            this.splitContainerControl_StuBaseInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl_StuBaseInfo.Location = new System.Drawing.Point(0, 24);
            this.splitContainerControl_StuBaseInfo.Name = "splitContainerControl_StuBaseInfo";
            this.splitContainerControl_StuBaseInfo.Panel1.Controls.Add(this.gridControl_ShowStu);
            this.splitContainerControl_StuBaseInfo.Panel1.Controls.Add(this.groupControl4);
            this.splitContainerControl_StuBaseInfo.Panel1.Text = "splitContainerControl1_Panel1";
            this.splitContainerControl_StuBaseInfo.Panel2.Controls.Add(this.simpleButton1);
            this.splitContainerControl_StuBaseInfo.Panel2.Controls.Add(this.simpleButton_printButton);
            this.splitContainerControl_StuBaseInfo.Panel2.Controls.Add(this.groupControl3);
            this.splitContainerControl_StuBaseInfo.Panel2.Controls.Add(this.groupControl2);
            this.splitContainerControl_StuBaseInfo.Panel2.Controls.Add(this.groupControl1);
            this.splitContainerControl_StuBaseInfo.Panel2.Controls.Add(this.simpleButton_BlankButton);
            this.splitContainerControl_StuBaseInfo.Panel2.Controls.Add(this.simpleButton_SaveButton);
            this.splitContainerControl_StuBaseInfo.Panel2.Controls.Add(this.simpleButton_NewFile);
            this.splitContainerControl_StuBaseInfo.Panel2.Text = "splitContainerControl1_Panel2";
            this.splitContainerControl_StuBaseInfo.Size = new System.Drawing.Size(770, 544);
            this.splitContainerControl_StuBaseInfo.SplitterPosition = 200;
            this.splitContainerControl_StuBaseInfo.TabIndex = 4;
            this.splitContainerControl_StuBaseInfo.Text = "splitContainerControl1";
            // 
            // gridControl_ShowStu
            // 
            this.gridControl_ShowStu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_ShowStu.Location = new System.Drawing.Point(0, 192);
            this.gridControl_ShowStu.MainView = this.gridView1;
            this.gridControl_ShowStu.Name = "gridControl_ShowStu";
            this.gridControl_ShowStu.Size = new System.Drawing.Size(200, 352);
            this.gridControl_ShowStu.TabIndex = 1;
            this.gridControl_ShowStu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_stuNumber,
            this.gridColumn_stuName,
            this.gridColumn_stuClass});
            this.gridView1.GridControl = this.gridControl_ShowStu;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn_stuNumber
            // 
            this.gridColumn_stuNumber.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn_stuNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn_stuNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn_stuNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn_stuNumber.Caption = "学号";
            this.gridColumn_stuNumber.FieldName = "info_stuNumber";
            this.gridColumn_stuNumber.Name = "gridColumn_stuNumber";
            this.gridColumn_stuNumber.OptionsColumn.AllowEdit = false;
            this.gridColumn_stuNumber.OptionsColumn.AllowFocus = false;
            this.gridColumn_stuNumber.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn_stuNumber.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn_stuNumber.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn_stuNumber.OptionsColumn.AllowMove = false;
            this.gridColumn_stuNumber.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn_stuNumber.OptionsColumn.FixedWidth = true;
            this.gridColumn_stuNumber.OptionsColumn.ReadOnly = true;
            this.gridColumn_stuNumber.OptionsFilter.AllowFilter = false;
            this.gridColumn_stuNumber.Visible = true;
            this.gridColumn_stuNumber.VisibleIndex = 0;
            this.gridColumn_stuNumber.Width = 53;
            // 
            // gridColumn_stuName
            // 
            this.gridColumn_stuName.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn_stuName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn_stuName.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn_stuName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn_stuName.Caption = "姓名";
            this.gridColumn_stuName.FieldName = "info_stuName";
            this.gridColumn_stuName.Name = "gridColumn_stuName";
            this.gridColumn_stuName.OptionsColumn.AllowEdit = false;
            this.gridColumn_stuName.OptionsColumn.AllowFocus = false;
            this.gridColumn_stuName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn_stuName.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn_stuName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn_stuName.OptionsColumn.AllowMove = false;
            this.gridColumn_stuName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn_stuName.OptionsColumn.FixedWidth = true;
            this.gridColumn_stuName.OptionsColumn.ReadOnly = true;
            this.gridColumn_stuName.Visible = true;
            this.gridColumn_stuName.VisibleIndex = 1;
            this.gridColumn_stuName.Width = 62;
            // 
            // gridColumn_stuClass
            // 
            this.gridColumn_stuClass.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn_stuClass.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn_stuClass.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn_stuClass.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn_stuClass.Caption = "班级";
            this.gridColumn_stuClass.FieldName = "info_className";
            this.gridColumn_stuClass.Name = "gridColumn_stuClass";
            this.gridColumn_stuClass.OptionsColumn.AllowEdit = false;
            this.gridColumn_stuClass.OptionsColumn.AllowFocus = false;
            this.gridColumn_stuClass.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn_stuClass.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn_stuClass.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn_stuClass.OptionsColumn.AllowMove = false;
            this.gridColumn_stuClass.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn_stuClass.OptionsColumn.FixedWidth = true;
            this.gridColumn_stuClass.OptionsColumn.ReadOnly = true;
            this.gridColumn_stuClass.Visible = true;
            this.gridColumn_stuClass.VisibleIndex = 2;
            this.gridColumn_stuClass.Width = 65;
            // 
            // groupControl4
            // 
            this.groupControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl4.Appearance.Options.UseFont = true;
            this.groupControl4.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl4.AppearanceCaption.Options.UseFont = true;
            this.groupControl4.Controls.Add(this.dataNavigator_SerStu);
            this.groupControl4.Controls.Add(this.textEdit_Number);
            this.groupControl4.Controls.Add(this.textEdit_Name);
            this.groupControl4.Controls.Add(this.notePanel_Number);
            this.groupControl4.Controls.Add(this.notePanel_Name);
            this.groupControl4.Controls.Add(this.comboBoxEdit_Class);
            this.groupControl4.Controls.Add(this.notePanel_Class);
            this.groupControl4.Controls.Add(this.comboBoxEdit_Grade);
            this.groupControl4.Controls.Add(this.notePanel_Grade);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl4.Location = new System.Drawing.Point(0, 0);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(200, 192);
            this.groupControl4.TabIndex = 0;
            this.groupControl4.Text = "我的班级";
            // 
            // dataNavigator_SerStu
            // 
            this.dataNavigator_SerStu.Buttons.Append.Hint = "新建卡";
            this.dataNavigator_SerStu.Buttons.Append.Visible = false;
            this.dataNavigator_SerStu.Buttons.CancelEdit.Visible = false;
            this.dataNavigator_SerStu.Buttons.EndEdit.Visible = false;
            this.dataNavigator_SerStu.Buttons.First.Hint = "第一条记录";
            this.dataNavigator_SerStu.Buttons.Last.Hint = "最后一条记录";
            this.dataNavigator_SerStu.Buttons.Next.Hint = "下一条记录";
            this.dataNavigator_SerStu.Buttons.NextPage.Visible = false;
            this.dataNavigator_SerStu.Buttons.Prev.Hint = "上一条记录";
            this.dataNavigator_SerStu.Buttons.PrevPage.Visible = false;
            this.dataNavigator_SerStu.Buttons.Remove.Visible = false;
            this.dataNavigator_SerStu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataNavigator_SerStu.Location = new System.Drawing.Point(2, 162);
            this.dataNavigator_SerStu.Name = "dataNavigator_SerStu";
            this.dataNavigator_SerStu.ShowToolTips = true;
            this.dataNavigator_SerStu.Size = new System.Drawing.Size(196, 28);
            this.dataNavigator_SerStu.TabIndex = 31;
            this.dataNavigator_SerStu.Text = "dataNavigator1";
            this.dataNavigator_SerStu.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.End;
            // 
            // textEdit_Number
            // 
            this.textEdit_Number.EditValue = "";
            this.textEdit_Number.Location = new System.Drawing.Point(88, 128);
            this.textEdit_Number.Name = "textEdit_Number";
            this.textEdit_Number.Size = new System.Drawing.Size(88, 20);
            this.textEdit_Number.TabIndex = 30;
            this.textEdit_Number.EditValueChanged += new System.EventHandler(this.textEdit_Number_EditValueChanged);
            // 
            // textEdit_Name
            // 
            this.textEdit_Name.EditValue = "";
            this.textEdit_Name.Location = new System.Drawing.Point(88, 96);
            this.textEdit_Name.Name = "textEdit_Name";
            this.textEdit_Name.Size = new System.Drawing.Size(88, 20);
            this.textEdit_Name.TabIndex = 29;
            this.textEdit_Name.EditValueChanged += new System.EventHandler(this.textEdit_Name_EditValueChanged);
            // 
            // notePanel_Number
            // 
            this.notePanel_Number.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Number.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Number.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Number.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Number.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Number.Location = new System.Drawing.Point(16, 128);
            this.notePanel_Number.MaxRows = 5;
            this.notePanel_Number.Name = "notePanel_Number";
            this.notePanel_Number.ParentAutoHeight = true;
            this.notePanel_Number.Size = new System.Drawing.Size(64, 22);
            this.notePanel_Number.TabIndex = 16;
            this.notePanel_Number.TabStop = false;
            this.notePanel_Number.Text = "学  号:";
            // 
            // notePanel_Name
            // 
            this.notePanel_Name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Name.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Name.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Name.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Name.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Name.Location = new System.Drawing.Point(16, 96);
            this.notePanel_Name.MaxRows = 5;
            this.notePanel_Name.Name = "notePanel_Name";
            this.notePanel_Name.ParentAutoHeight = true;
            this.notePanel_Name.Size = new System.Drawing.Size(64, 22);
            this.notePanel_Name.TabIndex = 15;
            this.notePanel_Name.TabStop = false;
            this.notePanel_Name.Text = "姓  名:";
            // 
            // comboBoxEdit_Class
            // 
            this.comboBoxEdit_Class.EditValue = "全部";
            this.comboBoxEdit_Class.Location = new System.Drawing.Point(88, 64);
            this.comboBoxEdit_Class.Name = "comboBoxEdit_Class";
            this.comboBoxEdit_Class.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_Class.Properties.Items.AddRange(new object[] {
            "全部"});
            this.comboBoxEdit_Class.Size = new System.Drawing.Size(88, 20);
            this.comboBoxEdit_Class.TabIndex = 13;
            this.comboBoxEdit_Class.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_Class_SelectedIndexChanged);
            // 
            // notePanel_Class
            // 
            this.notePanel_Class.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Class.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Class.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Class.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Class.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Class.Location = new System.Drawing.Point(16, 64);
            this.notePanel_Class.MaxRows = 5;
            this.notePanel_Class.Name = "notePanel_Class";
            this.notePanel_Class.ParentAutoHeight = true;
            this.notePanel_Class.Size = new System.Drawing.Size(64, 22);
            this.notePanel_Class.TabIndex = 12;
            this.notePanel_Class.TabStop = false;
            this.notePanel_Class.Text = "班  级:";
            // 
            // comboBoxEdit_Grade
            // 
            this.comboBoxEdit_Grade.EditValue = "全部";
            this.comboBoxEdit_Grade.Location = new System.Drawing.Point(88, 32);
            this.comboBoxEdit_Grade.Name = "comboBoxEdit_Grade";
            this.comboBoxEdit_Grade.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_Grade.Properties.Items.AddRange(new object[] {
            "全部"});
            this.comboBoxEdit_Grade.Size = new System.Drawing.Size(88, 20);
            this.comboBoxEdit_Grade.TabIndex = 11;
            this.comboBoxEdit_Grade.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_Grade_SelectedIndexChanged);
            // 
            // notePanel_Grade
            // 
            this.notePanel_Grade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Grade.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Grade.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Grade.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Grade.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Grade.Location = new System.Drawing.Point(16, 32);
            this.notePanel_Grade.MaxRows = 5;
            this.notePanel_Grade.Name = "notePanel_Grade";
            this.notePanel_Grade.ParentAutoHeight = true;
            this.notePanel_Grade.Size = new System.Drawing.Size(64, 22);
            this.notePanel_Grade.TabIndex = 5;
            this.notePanel_Grade.TabStop = false;
            this.notePanel_Grade.Text = "年  级:";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(370, 2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(96, 26);
            this.simpleButton1.TabIndex = 12;
            this.simpleButton1.Text = "导出信息";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton_printButton
            // 
            this.simpleButton_printButton.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
            this.simpleButton_printButton.Appearance.Options.UseForeColor = true;
            this.simpleButton_printButton.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_printButton.Image")));
            this.simpleButton_printButton.Location = new System.Drawing.Point(280, 2);
            this.simpleButton_printButton.Name = "simpleButton_printButton";
            this.simpleButton_printButton.Size = new System.Drawing.Size(80, 26);
            this.simpleButton_printButton.TabIndex = 11;
            this.simpleButton_printButton.Text = "打  印";
            this.simpleButton_printButton.Click += new System.EventHandler(this.simpleButton_printButton_Click);
            // 
            // groupControl3
            // 
            this.groupControl3.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl3.AppearanceCaption.Options.UseFont = true;
            this.groupControl3.Controls.Add(this.textEdit_MOWorkingAddr);
            this.groupControl3.Controls.Add(this.notePanel19);
            this.groupControl3.Controls.Add(this.textEdit_MOPhone);
            this.groupControl3.Controls.Add(this.textEdit_MOName);
            this.groupControl3.Controls.Add(this.notePanel_MOPhone);
            this.groupControl3.Controls.Add(this.notePanel_MOName);
            this.groupControl3.Controls.Add(this.textEdit_FAWorkingAddr);
            this.groupControl3.Controls.Add(this.notePanel_FAWorkingAddr);
            this.groupControl3.Controls.Add(this.textEdit_FAPhone);
            this.groupControl3.Controls.Add(this.notePanel_FAPhone);
            this.groupControl3.Controls.Add(this.textEdit_FAName);
            this.groupControl3.Controls.Add(this.notePanel_FAName);
            this.groupControl3.Location = new System.Drawing.Point(0, 384);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(600, 152);
            this.groupControl3.TabIndex = 9;
            this.groupControl3.Text = "幼儿父母信息";
            // 
            // textEdit_MOWorkingAddr
            // 
            this.textEdit_MOWorkingAddr.EditValue = "";
            this.textEdit_MOWorkingAddr.Location = new System.Drawing.Point(120, 120);
            this.textEdit_MOWorkingAddr.Name = "textEdit_MOWorkingAddr";
            this.textEdit_MOWorkingAddr.Size = new System.Drawing.Size(432, 20);
            this.textEdit_MOWorkingAddr.TabIndex = 54;
            // 
            // notePanel19
            // 
            this.notePanel19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel19.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel19.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel19.ForeColor = System.Drawing.Color.Black;
            this.notePanel19.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel19.Location = new System.Drawing.Point(32, 120);
            this.notePanel19.MaxRows = 5;
            this.notePanel19.Name = "notePanel19";
            this.notePanel19.ParentAutoHeight = true;
            this.notePanel19.Size = new System.Drawing.Size(80, 22);
            this.notePanel19.TabIndex = 53;
            this.notePanel19.TabStop = false;
            this.notePanel19.Text = "工作单位:";
            // 
            // textEdit_MOPhone
            // 
            this.textEdit_MOPhone.EditValue = "";
            this.textEdit_MOPhone.Location = new System.Drawing.Point(408, 88);
            this.textEdit_MOPhone.Name = "textEdit_MOPhone";
            this.textEdit_MOPhone.Size = new System.Drawing.Size(144, 20);
            this.textEdit_MOPhone.TabIndex = 52;
            // 
            // textEdit_MOName
            // 
            this.textEdit_MOName.EditValue = "";
            this.textEdit_MOName.Location = new System.Drawing.Point(120, 88);
            this.textEdit_MOName.Name = "textEdit_MOName";
            this.textEdit_MOName.Size = new System.Drawing.Size(184, 20);
            this.textEdit_MOName.TabIndex = 51;
            // 
            // notePanel_MOPhone
            // 
            this.notePanel_MOPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_MOPhone.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_MOPhone.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_MOPhone.ForeColor = System.Drawing.Color.Black;
            this.notePanel_MOPhone.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_MOPhone.Location = new System.Drawing.Point(320, 88);
            this.notePanel_MOPhone.MaxRows = 5;
            this.notePanel_MOPhone.Name = "notePanel_MOPhone";
            this.notePanel_MOPhone.ParentAutoHeight = true;
            this.notePanel_MOPhone.Size = new System.Drawing.Size(80, 22);
            this.notePanel_MOPhone.TabIndex = 50;
            this.notePanel_MOPhone.TabStop = false;
            this.notePanel_MOPhone.Text = "联系电话:";
            // 
            // notePanel_MOName
            // 
            this.notePanel_MOName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_MOName.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_MOName.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_MOName.ForeColor = System.Drawing.Color.Black;
            this.notePanel_MOName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_MOName.Location = new System.Drawing.Point(32, 88);
            this.notePanel_MOName.MaxRows = 5;
            this.notePanel_MOName.Name = "notePanel_MOName";
            this.notePanel_MOName.ParentAutoHeight = true;
            this.notePanel_MOName.Size = new System.Drawing.Size(80, 22);
            this.notePanel_MOName.TabIndex = 49;
            this.notePanel_MOName.TabStop = false;
            this.notePanel_MOName.Text = "母亲姓名:";
            // 
            // textEdit_FAWorkingAddr
            // 
            this.textEdit_FAWorkingAddr.EditValue = "";
            this.textEdit_FAWorkingAddr.Location = new System.Drawing.Point(120, 56);
            this.textEdit_FAWorkingAddr.Name = "textEdit_FAWorkingAddr";
            this.textEdit_FAWorkingAddr.Size = new System.Drawing.Size(432, 20);
            this.textEdit_FAWorkingAddr.TabIndex = 48;
            // 
            // notePanel_FAWorkingAddr
            // 
            this.notePanel_FAWorkingAddr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_FAWorkingAddr.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_FAWorkingAddr.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_FAWorkingAddr.ForeColor = System.Drawing.Color.Black;
            this.notePanel_FAWorkingAddr.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_FAWorkingAddr.Location = new System.Drawing.Point(32, 56);
            this.notePanel_FAWorkingAddr.MaxRows = 5;
            this.notePanel_FAWorkingAddr.Name = "notePanel_FAWorkingAddr";
            this.notePanel_FAWorkingAddr.ParentAutoHeight = true;
            this.notePanel_FAWorkingAddr.Size = new System.Drawing.Size(80, 22);
            this.notePanel_FAWorkingAddr.TabIndex = 32;
            this.notePanel_FAWorkingAddr.TabStop = false;
            this.notePanel_FAWorkingAddr.Text = "工作单位:";
            // 
            // textEdit_FAPhone
            // 
            this.textEdit_FAPhone.EditValue = "";
            this.textEdit_FAPhone.Location = new System.Drawing.Point(408, 24);
            this.textEdit_FAPhone.Name = "textEdit_FAPhone";
            this.textEdit_FAPhone.Size = new System.Drawing.Size(144, 20);
            this.textEdit_FAPhone.TabIndex = 31;
            // 
            // notePanel_FAPhone
            // 
            this.notePanel_FAPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_FAPhone.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_FAPhone.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_FAPhone.ForeColor = System.Drawing.Color.Black;
            this.notePanel_FAPhone.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_FAPhone.Location = new System.Drawing.Point(320, 24);
            this.notePanel_FAPhone.MaxRows = 5;
            this.notePanel_FAPhone.Name = "notePanel_FAPhone";
            this.notePanel_FAPhone.ParentAutoHeight = true;
            this.notePanel_FAPhone.Size = new System.Drawing.Size(80, 22);
            this.notePanel_FAPhone.TabIndex = 30;
            this.notePanel_FAPhone.TabStop = false;
            this.notePanel_FAPhone.Text = "联系电话:";
            // 
            // textEdit_FAName
            // 
            this.textEdit_FAName.EditValue = "";
            this.textEdit_FAName.Location = new System.Drawing.Point(120, 24);
            this.textEdit_FAName.Name = "textEdit_FAName";
            this.textEdit_FAName.Size = new System.Drawing.Size(184, 20);
            this.textEdit_FAName.TabIndex = 29;
            // 
            // notePanel_FAName
            // 
            this.notePanel_FAName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_FAName.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_FAName.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_FAName.ForeColor = System.Drawing.Color.Black;
            this.notePanel_FAName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_FAName.Location = new System.Drawing.Point(32, 24);
            this.notePanel_FAName.MaxRows = 5;
            this.notePanel_FAName.Name = "notePanel_FAName";
            this.notePanel_FAName.ParentAutoHeight = true;
            this.notePanel_FAName.Size = new System.Drawing.Size(80, 22);
            this.notePanel_FAName.TabIndex = 25;
            this.notePanel_FAName.TabStop = false;
            this.notePanel_FAName.Text = "父亲姓名:";
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.notePanel_HuKouAddr);
            this.groupControl2.Controls.Add(this.textEdit_HuKouAddr);
            this.groupControl2.Controls.Add(this.notePanel_FamilyAddr);
            this.groupControl2.Controls.Add(this.textEdit_ILLHistory);
            this.groupControl2.Controls.Add(this.textEdit_EMail);
            this.groupControl2.Controls.Add(this.textEdit_BankID);
            this.groupControl2.Controls.Add(this.notePanel_ILLHistory);
            this.groupControl2.Controls.Add(this.notePanel_EMail);
            this.groupControl2.Controls.Add(this.notePanel_BankID);
            this.groupControl2.Controls.Add(this.textEdit_Street);
            this.groupControl2.Controls.Add(this.textEdit_JUWei);
            this.groupControl2.Controls.Add(this.notePanel_ZIPCode);
            this.groupControl2.Controls.Add(this.notePanel_Phone);
            this.groupControl2.Controls.Add(this.textEdit_ZIPCode);
            this.groupControl2.Controls.Add(this.textEdit_RegNote);
            this.groupControl2.Controls.Add(this.textEdit_Native);
            this.groupControl2.Controls.Add(this.textEdit_Nationality);
            this.groupControl2.Controls.Add(this.notePanel_JUWei);
            this.groupControl2.Controls.Add(this.notePanel_Street);
            this.groupControl2.Controls.Add(this.notePanel_Native);
            this.groupControl2.Controls.Add(this.notePanel_Nationality);
            this.groupControl2.Controls.Add(this.textEdit_FamilyAddr);
            this.groupControl2.Location = new System.Drawing.Point(0, 192);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(600, 192);
            this.groupControl2.TabIndex = 8;
            this.groupControl2.Text = "幼儿扩展信息";
            // 
            // notePanel_HuKouAddr
            // 
            this.notePanel_HuKouAddr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_HuKouAddr.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_HuKouAddr.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_HuKouAddr.ForeColor = System.Drawing.Color.Black;
            this.notePanel_HuKouAddr.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_HuKouAddr.Location = new System.Drawing.Point(33, 152);
            this.notePanel_HuKouAddr.MaxRows = 5;
            this.notePanel_HuKouAddr.Name = "notePanel_HuKouAddr";
            this.notePanel_HuKouAddr.ParentAutoHeight = true;
            this.notePanel_HuKouAddr.Size = new System.Drawing.Size(80, 22);
            this.notePanel_HuKouAddr.TabIndex = 44;
            this.notePanel_HuKouAddr.TabStop = false;
            this.notePanel_HuKouAddr.Text = "户口地址:";
            // 
            // textEdit_HuKouAddr
            // 
            this.textEdit_HuKouAddr.EditValue = "";
            this.textEdit_HuKouAddr.Location = new System.Drawing.Point(120, 152);
            this.textEdit_HuKouAddr.Name = "textEdit_HuKouAddr";
            this.textEdit_HuKouAddr.Size = new System.Drawing.Size(432, 20);
            this.textEdit_HuKouAddr.TabIndex = 43;
            // 
            // notePanel_FamilyAddr
            // 
            this.notePanel_FamilyAddr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_FamilyAddr.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_FamilyAddr.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_FamilyAddr.ForeColor = System.Drawing.Color.Black;
            this.notePanel_FamilyAddr.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_FamilyAddr.Location = new System.Drawing.Point(33, 120);
            this.notePanel_FamilyAddr.MaxRows = 5;
            this.notePanel_FamilyAddr.Name = "notePanel_FamilyAddr";
            this.notePanel_FamilyAddr.ParentAutoHeight = true;
            this.notePanel_FamilyAddr.Size = new System.Drawing.Size(80, 22);
            this.notePanel_FamilyAddr.TabIndex = 42;
            this.notePanel_FamilyAddr.TabStop = false;
            this.notePanel_FamilyAddr.Text = "家庭地址:";
            // 
            // textEdit_ILLHistory
            // 
            this.textEdit_ILLHistory.EditValue = "";
            this.textEdit_ILLHistory.Location = new System.Drawing.Point(472, 88);
            this.textEdit_ILLHistory.Name = "textEdit_ILLHistory";
            this.textEdit_ILLHistory.Size = new System.Drawing.Size(80, 20);
            this.textEdit_ILLHistory.TabIndex = 41;
            // 
            // textEdit_EMail
            // 
            this.textEdit_EMail.EditValue = "";
            this.textEdit_EMail.Location = new System.Drawing.Point(296, 88);
            this.textEdit_EMail.Name = "textEdit_EMail";
            this.textEdit_EMail.Size = new System.Drawing.Size(80, 20);
            this.textEdit_EMail.TabIndex = 40;
            // 
            // textEdit_BankID
            // 
            this.textEdit_BankID.EditValue = "";
            this.textEdit_BankID.Location = new System.Drawing.Point(120, 88);
            this.textEdit_BankID.Name = "textEdit_BankID";
            this.textEdit_BankID.Size = new System.Drawing.Size(80, 20);
            this.textEdit_BankID.TabIndex = 39;
            // 
            // notePanel_ILLHistory
            // 
            this.notePanel_ILLHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_ILLHistory.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_ILLHistory.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_ILLHistory.ForeColor = System.Drawing.Color.Black;
            this.notePanel_ILLHistory.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_ILLHistory.Location = new System.Drawing.Point(385, 88);
            this.notePanel_ILLHistory.MaxRows = 5;
            this.notePanel_ILLHistory.Name = "notePanel_ILLHistory";
            this.notePanel_ILLHistory.ParentAutoHeight = true;
            this.notePanel_ILLHistory.Size = new System.Drawing.Size(79, 22);
            this.notePanel_ILLHistory.TabIndex = 38;
            this.notePanel_ILLHistory.TabStop = false;
            this.notePanel_ILLHistory.Text = "病史记录:";
            // 
            // notePanel_EMail
            // 
            this.notePanel_EMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_EMail.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_EMail.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_EMail.ForeColor = System.Drawing.Color.Black;
            this.notePanel_EMail.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_EMail.Location = new System.Drawing.Point(209, 88);
            this.notePanel_EMail.MaxRows = 5;
            this.notePanel_EMail.Name = "notePanel_EMail";
            this.notePanel_EMail.ParentAutoHeight = true;
            this.notePanel_EMail.Size = new System.Drawing.Size(79, 22);
            this.notePanel_EMail.TabIndex = 37;
            this.notePanel_EMail.TabStop = false;
            this.notePanel_EMail.Text = "电子邮件:";
            // 
            // notePanel_BankID
            // 
            this.notePanel_BankID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_BankID.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_BankID.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_BankID.ForeColor = System.Drawing.Color.Black;
            this.notePanel_BankID.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_BankID.Location = new System.Drawing.Point(33, 88);
            this.notePanel_BankID.MaxRows = 5;
            this.notePanel_BankID.Name = "notePanel_BankID";
            this.notePanel_BankID.ParentAutoHeight = true;
            this.notePanel_BankID.Size = new System.Drawing.Size(79, 22);
            this.notePanel_BankID.TabIndex = 36;
            this.notePanel_BankID.TabStop = false;
            this.notePanel_BankID.Text = "银行卡号:";
            // 
            // textEdit_Street
            // 
            this.textEdit_Street.EditValue = "";
            this.textEdit_Street.Location = new System.Drawing.Point(472, 24);
            this.textEdit_Street.Name = "textEdit_Street";
            this.textEdit_Street.Size = new System.Drawing.Size(80, 20);
            this.textEdit_Street.TabIndex = 35;
            // 
            // textEdit_JUWei
            // 
            this.textEdit_JUWei.EditValue = "";
            this.textEdit_JUWei.Location = new System.Drawing.Point(472, 56);
            this.textEdit_JUWei.Name = "textEdit_JUWei";
            this.textEdit_JUWei.Size = new System.Drawing.Size(80, 20);
            this.textEdit_JUWei.TabIndex = 34;
            // 
            // notePanel_ZIPCode
            // 
            this.notePanel_ZIPCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_ZIPCode.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_ZIPCode.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_ZIPCode.ForeColor = System.Drawing.Color.Black;
            this.notePanel_ZIPCode.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_ZIPCode.Location = new System.Drawing.Point(209, 56);
            this.notePanel_ZIPCode.MaxRows = 5;
            this.notePanel_ZIPCode.Name = "notePanel_ZIPCode";
            this.notePanel_ZIPCode.ParentAutoHeight = true;
            this.notePanel_ZIPCode.Size = new System.Drawing.Size(79, 22);
            this.notePanel_ZIPCode.TabIndex = 33;
            this.notePanel_ZIPCode.TabStop = false;
            this.notePanel_ZIPCode.Text = "邮政编码:";
            // 
            // notePanel_Phone
            // 
            this.notePanel_Phone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Phone.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Phone.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Phone.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Phone.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Phone.Location = new System.Drawing.Point(209, 24);
            this.notePanel_Phone.MaxRows = 5;
            this.notePanel_Phone.Name = "notePanel_Phone";
            this.notePanel_Phone.ParentAutoHeight = true;
            this.notePanel_Phone.Size = new System.Drawing.Size(79, 22);
            this.notePanel_Phone.TabIndex = 32;
            this.notePanel_Phone.TabStop = false;
            this.notePanel_Phone.Text = "短信注册:";
            // 
            // textEdit_ZIPCode
            // 
            this.textEdit_ZIPCode.EditValue = "";
            this.textEdit_ZIPCode.Location = new System.Drawing.Point(296, 56);
            this.textEdit_ZIPCode.Name = "textEdit_ZIPCode";
            this.textEdit_ZIPCode.Size = new System.Drawing.Size(80, 20);
            this.textEdit_ZIPCode.TabIndex = 31;
            // 
            // textEdit_RegNote
            // 
            this.textEdit_RegNote.EditValue = "";
            this.textEdit_RegNote.Location = new System.Drawing.Point(296, 24);
            this.textEdit_RegNote.Name = "textEdit_RegNote";
            this.textEdit_RegNote.Size = new System.Drawing.Size(80, 20);
            this.textEdit_RegNote.TabIndex = 30;
            // 
            // textEdit_Native
            // 
            this.textEdit_Native.EditValue = "";
            this.textEdit_Native.Location = new System.Drawing.Point(120, 56);
            this.textEdit_Native.Name = "textEdit_Native";
            this.textEdit_Native.Size = new System.Drawing.Size(80, 20);
            this.textEdit_Native.TabIndex = 29;
            // 
            // textEdit_Nationality
            // 
            this.textEdit_Nationality.EditValue = "";
            this.textEdit_Nationality.Location = new System.Drawing.Point(120, 24);
            this.textEdit_Nationality.Name = "textEdit_Nationality";
            this.textEdit_Nationality.Size = new System.Drawing.Size(80, 20);
            this.textEdit_Nationality.TabIndex = 28;
            // 
            // notePanel_JUWei
            // 
            this.notePanel_JUWei.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_JUWei.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_JUWei.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_JUWei.ForeColor = System.Drawing.Color.Black;
            this.notePanel_JUWei.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_JUWei.Location = new System.Drawing.Point(385, 56);
            this.notePanel_JUWei.MaxRows = 5;
            this.notePanel_JUWei.Name = "notePanel_JUWei";
            this.notePanel_JUWei.ParentAutoHeight = true;
            this.notePanel_JUWei.Size = new System.Drawing.Size(79, 22);
            this.notePanel_JUWei.TabIndex = 27;
            this.notePanel_JUWei.TabStop = false;
            this.notePanel_JUWei.Text = "所在里委:";
            // 
            // notePanel_Street
            // 
            this.notePanel_Street.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Street.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Street.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Street.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Street.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Street.Location = new System.Drawing.Point(385, 24);
            this.notePanel_Street.MaxRows = 5;
            this.notePanel_Street.Name = "notePanel_Street";
            this.notePanel_Street.ParentAutoHeight = true;
            this.notePanel_Street.Size = new System.Drawing.Size(79, 22);
            this.notePanel_Street.TabIndex = 26;
            this.notePanel_Street.TabStop = false;
            this.notePanel_Street.Text = "所在街道:";
            // 
            // notePanel_Native
            // 
            this.notePanel_Native.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Native.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Native.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Native.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Native.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Native.Location = new System.Drawing.Point(33, 56);
            this.notePanel_Native.MaxRows = 5;
            this.notePanel_Native.Name = "notePanel_Native";
            this.notePanel_Native.ParentAutoHeight = true;
            this.notePanel_Native.Size = new System.Drawing.Size(78, 22);
            this.notePanel_Native.TabIndex = 25;
            this.notePanel_Native.TabStop = false;
            this.notePanel_Native.Text = "幼儿籍贯:";
            // 
            // notePanel_Nationality
            // 
            this.notePanel_Nationality.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Nationality.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Nationality.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Nationality.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Nationality.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Nationality.Location = new System.Drawing.Point(33, 24);
            this.notePanel_Nationality.MaxRows = 5;
            this.notePanel_Nationality.Name = "notePanel_Nationality";
            this.notePanel_Nationality.ParentAutoHeight = true;
            this.notePanel_Nationality.Size = new System.Drawing.Size(78, 22);
            this.notePanel_Nationality.TabIndex = 24;
            this.notePanel_Nationality.TabStop = false;
            this.notePanel_Nationality.Text = "幼儿国籍:";
            // 
            // textEdit_FamilyAddr
            // 
            this.textEdit_FamilyAddr.EditValue = "";
            this.textEdit_FamilyAddr.Location = new System.Drawing.Point(120, 120);
            this.textEdit_FamilyAddr.Name = "textEdit_FamilyAddr";
            this.textEdit_FamilyAddr.Size = new System.Drawing.Size(432, 20);
            this.textEdit_FamilyAddr.TabIndex = 45;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.textEdit_StuDefaultNumber);
            this.groupControl1.Controls.Add(this.dateEdit_Birthday);
            this.groupControl1.Controls.Add(this.textEdit_KidOrigin);
            this.groupControl1.Controls.Add(this.textEdit_GUID);
            this.groupControl1.Controls.Add(this.dateEdit_EntryDate);
            this.groupControl1.Controls.Add(this.label_RegOfEnrollKind);
            this.groupControl1.Controls.Add(this.label_RegOfEnrollTime);
            this.groupControl1.Controls.Add(this.label_RegOfBirthday);
            this.groupControl1.Controls.Add(this.label_RegOfKidGender);
            this.groupControl1.Controls.Add(this.label_ReqOfKidName);
            this.groupControl1.Controls.Add(this.notePanel_KidBaseInfoTitle);
            this.groupControl1.Controls.Add(this.pictureEdit_LoadImageData);
            this.groupControl1.Controls.Add(this.comboBoxEdit_EntryStatus);
            this.groupControl1.Controls.Add(this.notePanel_KidNumber);
            this.groupControl1.Controls.Add(this.notePanel_EnrollKind);
            this.groupControl1.Controls.Add(this.comboBoxEdit_KidGender);
            this.groupControl1.Controls.Add(this.textEdit_KidName);
            this.groupControl1.Controls.Add(this.notePanel_KidOrigin);
            this.groupControl1.Controls.Add(this.notePanel_EnrollTime);
            this.groupControl1.Controls.Add(this.notePanel_Birthday);
            this.groupControl1.Controls.Add(this.notePanel_KidGender);
            this.groupControl1.Controls.Add(this.notePanel_KidName);
            this.groupControl1.Location = new System.Drawing.Point(0, 32);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(600, 160);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "幼儿基本信息";
            // 
            // textEdit_StuDefaultNumber
            // 
            this.textEdit_StuDefaultNumber.EditValue = "";
            this.textEdit_StuDefaultNumber.Location = new System.Drawing.Point(344, 72);
            this.textEdit_StuDefaultNumber.Name = "textEdit_StuDefaultNumber";
            this.textEdit_StuDefaultNumber.Size = new System.Drawing.Size(88, 20);
            this.textEdit_StuDefaultNumber.TabIndex = 36;
            // 
            // dateEdit_Birthday
            // 
            this.dateEdit_Birthday.EditValue = null;
            this.dateEdit_Birthday.Location = new System.Drawing.Point(120, 100);
            this.dateEdit_Birthday.Name = "dateEdit_Birthday";
            this.dateEdit_Birthday.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_Birthday.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit_Birthday.Size = new System.Drawing.Size(104, 20);
            this.dateEdit_Birthday.TabIndex = 35;
            // 
            // textEdit_KidOrigin
            // 
            this.textEdit_KidOrigin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEdit_KidOrigin.EditValue = "";
            this.textEdit_KidOrigin.Location = new System.Drawing.Point(344, 96);
            this.textEdit_KidOrigin.Name = "textEdit_KidOrigin";
            this.textEdit_KidOrigin.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.textEdit_KidOrigin.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.textEdit_KidOrigin.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit_KidOrigin.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit_KidOrigin.Size = new System.Drawing.Size(86, 23);
            this.textEdit_KidOrigin.TabIndex = 33;
            // 
            // textEdit_GUID
            // 
            this.textEdit_GUID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEdit_GUID.EditValue = "";
            this.textEdit_GUID.Location = new System.Drawing.Point(416, 88);
            this.textEdit_GUID.Name = "textEdit_GUID";
            this.textEdit_GUID.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.textEdit_GUID.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.textEdit_GUID.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit_GUID.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit_GUID.Properties.AutoHeight = false;
            this.textEdit_GUID.Properties.ReadOnly = true;
            this.textEdit_GUID.Size = new System.Drawing.Size(14, 8);
            this.textEdit_GUID.TabIndex = 32;
            // 
            // dateEdit_EntryDate
            // 
            this.dateEdit_EntryDate.EditValue = null;
            this.dateEdit_EntryDate.Location = new System.Drawing.Point(120, 128);
            this.dateEdit_EntryDate.Name = "dateEdit_EntryDate";
            this.dateEdit_EntryDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_EntryDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit_EntryDate.Size = new System.Drawing.Size(104, 20);
            this.dateEdit_EntryDate.TabIndex = 30;
            // 
            // label_RegOfEnrollKind
            // 
            this.label_RegOfEnrollKind.BackColor = System.Drawing.Color.Transparent;
            this.label_RegOfEnrollKind.ForeColor = System.Drawing.Color.Red;
            this.label_RegOfEnrollKind.Location = new System.Drawing.Point(240, 50);
            this.label_RegOfEnrollKind.Name = "label_RegOfEnrollKind";
            this.label_RegOfEnrollKind.Size = new System.Drawing.Size(16, 16);
            this.label_RegOfEnrollKind.TabIndex = 27;
            this.label_RegOfEnrollKind.Text = "*";
            this.label_RegOfEnrollKind.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_RegOfEnrollTime
            // 
            this.label_RegOfEnrollTime.BackColor = System.Drawing.Color.Transparent;
            this.label_RegOfEnrollTime.ForeColor = System.Drawing.Color.Red;
            this.label_RegOfEnrollTime.Location = new System.Drawing.Point(8, 132);
            this.label_RegOfEnrollTime.Name = "label_RegOfEnrollTime";
            this.label_RegOfEnrollTime.Size = new System.Drawing.Size(16, 16);
            this.label_RegOfEnrollTime.TabIndex = 26;
            this.label_RegOfEnrollTime.Text = "*";
            this.label_RegOfEnrollTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_RegOfBirthday
            // 
            this.label_RegOfBirthday.BackColor = System.Drawing.Color.Transparent;
            this.label_RegOfBirthday.ForeColor = System.Drawing.Color.Red;
            this.label_RegOfBirthday.Location = new System.Drawing.Point(8, 104);
            this.label_RegOfBirthday.Name = "label_RegOfBirthday";
            this.label_RegOfBirthday.Size = new System.Drawing.Size(16, 16);
            this.label_RegOfBirthday.TabIndex = 25;
            this.label_RegOfBirthday.Text = "*";
            this.label_RegOfBirthday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_RegOfKidGender
            // 
            this.label_RegOfKidGender.BackColor = System.Drawing.Color.Transparent;
            this.label_RegOfKidGender.ForeColor = System.Drawing.Color.Red;
            this.label_RegOfKidGender.Location = new System.Drawing.Point(8, 78);
            this.label_RegOfKidGender.Name = "label_RegOfKidGender";
            this.label_RegOfKidGender.Size = new System.Drawing.Size(16, 16);
            this.label_RegOfKidGender.TabIndex = 24;
            this.label_RegOfKidGender.Text = "*";
            this.label_RegOfKidGender.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_ReqOfKidName
            // 
            this.label_ReqOfKidName.BackColor = System.Drawing.Color.Transparent;
            this.label_ReqOfKidName.ForeColor = System.Drawing.Color.Red;
            this.label_ReqOfKidName.Location = new System.Drawing.Point(8, 52);
            this.label_ReqOfKidName.Name = "label_ReqOfKidName";
            this.label_ReqOfKidName.Size = new System.Drawing.Size(16, 16);
            this.label_ReqOfKidName.TabIndex = 23;
            this.label_ReqOfKidName.Text = "*";
            this.label_ReqOfKidName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // notePanel_KidBaseInfoTitle
            // 
            this.notePanel_KidBaseInfoTitle.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.notePanel_KidBaseInfoTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.notePanel_KidBaseInfoTitle.ForeColor = System.Drawing.Color.OrangeRed;
            this.notePanel_KidBaseInfoTitle.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_KidBaseInfoTitle.Location = new System.Drawing.Point(2, 22);
            this.notePanel_KidBaseInfoTitle.MaxRows = 5;
            this.notePanel_KidBaseInfoTitle.Name = "notePanel_KidBaseInfoTitle";
            this.notePanel_KidBaseInfoTitle.ParentAutoHeight = true;
            this.notePanel_KidBaseInfoTitle.Size = new System.Drawing.Size(596, 23);
            this.notePanel_KidBaseInfoTitle.TabIndex = 22;
            this.notePanel_KidBaseInfoTitle.TabStop = false;
            this.notePanel_KidBaseInfoTitle.Text = "幼儿基本信息管理(*为必须填写)";
            // 
            // pictureEdit_LoadImageData
            // 
            this.pictureEdit_LoadImageData.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureEdit_LoadImageData.BackgroundImage")));
            this.pictureEdit_LoadImageData.Location = new System.Drawing.Point(440, 48);
            this.pictureEdit_LoadImageData.MenuManager = this.barManager1;
            this.pictureEdit_LoadImageData.Name = "pictureEdit_LoadImageData";
            this.barManager1.SetPopupContextMenu(this.pictureEdit_LoadImageData, this.popupMenu1);
            this.pictureEdit_LoadImageData.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit_LoadImageData.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit_LoadImageData.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.pictureEdit_LoadImageData.Properties.NullText = "图片相素:800*600";
            this.pictureEdit_LoadImageData.Properties.ShowMenu = false;
            this.pictureEdit_LoadImageData.Size = new System.Drawing.Size(112, 104);
            this.pictureEdit_LoadImageData.TabIndex = 20;
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem_Refresh});
            this.barManager1.MaxItemId = 3;
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "添加图片";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "删除图片";
            this.barButtonItem2.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.Glyph")));
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(772, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 704);
            this.barDockControlBottom.Size = new System.Drawing.Size(772, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 704);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(772, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 704);
            // 
            // barButtonItem_Refresh
            // 
            this.barButtonItem_Refresh.Caption = "刷新";
            this.barButtonItem_Refresh.Id = 2;
            this.barButtonItem_Refresh.Name = "barButtonItem_Refresh";
            this.barButtonItem_Refresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Refresh_ItemClick);
            // 
            // comboBoxEdit_EntryStatus
            // 
            this.comboBoxEdit_EntryStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxEdit_EntryStatus.EditValue = "日托";
            this.comboBoxEdit_EntryStatus.Location = new System.Drawing.Point(344, 48);
            this.comboBoxEdit_EntryStatus.Name = "comboBoxEdit_EntryStatus";
            this.comboBoxEdit_EntryStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_EntryStatus.Properties.Items.AddRange(new object[] {
            "日托",
            "全托"});
            this.comboBoxEdit_EntryStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_EntryStatus.Size = new System.Drawing.Size(88, 23);
            this.comboBoxEdit_EntryStatus.TabIndex = 17;
            // 
            // notePanel_KidNumber
            // 
            this.notePanel_KidNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_KidNumber.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_KidNumber.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_KidNumber.ForeColor = System.Drawing.Color.Black;
            this.notePanel_KidNumber.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_KidNumber.Location = new System.Drawing.Point(256, 72);
            this.notePanel_KidNumber.MaxRows = 5;
            this.notePanel_KidNumber.Name = "notePanel_KidNumber";
            this.notePanel_KidNumber.ParentAutoHeight = true;
            this.notePanel_KidNumber.Size = new System.Drawing.Size(80, 22);
            this.notePanel_KidNumber.TabIndex = 16;
            this.notePanel_KidNumber.TabStop = false;
            this.notePanel_KidNumber.Text = "幼儿学号:";
            // 
            // notePanel_EnrollKind
            // 
            this.notePanel_EnrollKind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_EnrollKind.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_EnrollKind.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_EnrollKind.ForeColor = System.Drawing.Color.Black;
            this.notePanel_EnrollKind.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_EnrollKind.Location = new System.Drawing.Point(256, 48);
            this.notePanel_EnrollKind.MaxRows = 5;
            this.notePanel_EnrollKind.Name = "notePanel_EnrollKind";
            this.notePanel_EnrollKind.ParentAutoHeight = true;
            this.notePanel_EnrollKind.Size = new System.Drawing.Size(80, 22);
            this.notePanel_EnrollKind.TabIndex = 14;
            this.notePanel_EnrollKind.TabStop = false;
            this.notePanel_EnrollKind.Text = "入托方式:";
            // 
            // comboBoxEdit_KidGender
            // 
            this.comboBoxEdit_KidGender.EditValue = "男";
            this.comboBoxEdit_KidGender.Location = new System.Drawing.Point(120, 74);
            this.comboBoxEdit_KidGender.Name = "comboBoxEdit_KidGender";
            this.comboBoxEdit_KidGender.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_KidGender.Properties.Items.AddRange(new object[] {
            "男",
            "女"});
            this.comboBoxEdit_KidGender.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_KidGender.Size = new System.Drawing.Size(104, 20);
            this.comboBoxEdit_KidGender.TabIndex = 10;
            // 
            // textEdit_KidName
            // 
            this.textEdit_KidName.EditValue = "";
            this.textEdit_KidName.Location = new System.Drawing.Point(120, 48);
            this.textEdit_KidName.Name = "textEdit_KidName";
            this.textEdit_KidName.Size = new System.Drawing.Size(104, 20);
            this.textEdit_KidName.TabIndex = 9;
            // 
            // notePanel_KidOrigin
            // 
            this.notePanel_KidOrigin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_KidOrigin.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_KidOrigin.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_KidOrigin.ForeColor = System.Drawing.Color.Black;
            this.notePanel_KidOrigin.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_KidOrigin.Location = new System.Drawing.Point(256, 96);
            this.notePanel_KidOrigin.MaxRows = 5;
            this.notePanel_KidOrigin.Name = "notePanel_KidOrigin";
            this.notePanel_KidOrigin.ParentAutoHeight = true;
            this.notePanel_KidOrigin.Size = new System.Drawing.Size(80, 22);
            this.notePanel_KidOrigin.TabIndex = 8;
            this.notePanel_KidOrigin.TabStop = false;
            this.notePanel_KidOrigin.Text = "新生来源:";
            // 
            // notePanel_EnrollTime
            // 
            this.notePanel_EnrollTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_EnrollTime.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_EnrollTime.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_EnrollTime.ForeColor = System.Drawing.Color.Black;
            this.notePanel_EnrollTime.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_EnrollTime.Location = new System.Drawing.Point(32, 126);
            this.notePanel_EnrollTime.MaxRows = 5;
            this.notePanel_EnrollTime.Name = "notePanel_EnrollTime";
            this.notePanel_EnrollTime.ParentAutoHeight = true;
            this.notePanel_EnrollTime.Size = new System.Drawing.Size(78, 22);
            this.notePanel_EnrollTime.TabIndex = 7;
            this.notePanel_EnrollTime.TabStop = false;
            this.notePanel_EnrollTime.Text = "入园日期:";
            // 
            // notePanel_Birthday
            // 
            this.notePanel_Birthday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Birthday.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Birthday.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Birthday.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Birthday.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Birthday.Location = new System.Drawing.Point(32, 100);
            this.notePanel_Birthday.MaxRows = 5;
            this.notePanel_Birthday.Name = "notePanel_Birthday";
            this.notePanel_Birthday.ParentAutoHeight = true;
            this.notePanel_Birthday.Size = new System.Drawing.Size(78, 22);
            this.notePanel_Birthday.TabIndex = 6;
            this.notePanel_Birthday.TabStop = false;
            this.notePanel_Birthday.Text = "出生日期:";
            // 
            // notePanel_KidGender
            // 
            this.notePanel_KidGender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_KidGender.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_KidGender.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_KidGender.ForeColor = System.Drawing.Color.Black;
            this.notePanel_KidGender.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_KidGender.Location = new System.Drawing.Point(32, 74);
            this.notePanel_KidGender.MaxRows = 5;
            this.notePanel_KidGender.Name = "notePanel_KidGender";
            this.notePanel_KidGender.ParentAutoHeight = true;
            this.notePanel_KidGender.Size = new System.Drawing.Size(78, 22);
            this.notePanel_KidGender.TabIndex = 5;
            this.notePanel_KidGender.TabStop = false;
            this.notePanel_KidGender.Text = "幼儿性别:";
            // 
            // notePanel_KidName
            // 
            this.notePanel_KidName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_KidName.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_KidName.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_KidName.ForeColor = System.Drawing.Color.Black;
            this.notePanel_KidName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_KidName.Location = new System.Drawing.Point(32, 48);
            this.notePanel_KidName.MaxRows = 5;
            this.notePanel_KidName.Name = "notePanel_KidName";
            this.notePanel_KidName.ParentAutoHeight = true;
            this.notePanel_KidName.Size = new System.Drawing.Size(80, 22);
            this.notePanel_KidName.TabIndex = 4;
            this.notePanel_KidName.TabStop = false;
            this.notePanel_KidName.Text = "幼儿姓名:";
            // 
            // simpleButton_BlankButton
            // 
            this.simpleButton_BlankButton.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
            this.simpleButton_BlankButton.Appearance.Options.UseForeColor = true;
            this.simpleButton_BlankButton.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_BlankButton.Image")));
            this.simpleButton_BlankButton.Location = new System.Drawing.Point(192, 2);
            this.simpleButton_BlankButton.Name = "simpleButton_BlankButton";
            this.simpleButton_BlankButton.Size = new System.Drawing.Size(80, 26);
            this.simpleButton_BlankButton.TabIndex = 5;
            this.simpleButton_BlankButton.Text = "重  置";
            this.simpleButton_BlankButton.Click += new System.EventHandler(this.simpleButton_BlankButton_Click);
            // 
            // simpleButton_SaveButton
            // 
            this.simpleButton_SaveButton.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
            this.simpleButton_SaveButton.Appearance.Options.UseForeColor = true;
            this.simpleButton_SaveButton.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_SaveButton.Image")));
            this.simpleButton_SaveButton.Location = new System.Drawing.Point(104, 2);
            this.simpleButton_SaveButton.Name = "simpleButton_SaveButton";
            this.simpleButton_SaveButton.Size = new System.Drawing.Size(84, 26);
            this.simpleButton_SaveButton.TabIndex = 3;
            this.simpleButton_SaveButton.Text = "保  存";
            this.simpleButton_SaveButton.Click += new System.EventHandler(this.simpleButton_SaveButton_Click);
            // 
            // simpleButton_NewFile
            // 
            this.simpleButton_NewFile.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_NewFile.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
            this.simpleButton_NewFile.Appearance.Options.UseFont = true;
            this.simpleButton_NewFile.Appearance.Options.UseForeColor = true;
            this.simpleButton_NewFile.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_NewFile.Image")));
            this.simpleButton_NewFile.Location = new System.Drawing.Point(8, 2);
            this.simpleButton_NewFile.Name = "simpleButton_NewFile";
            this.simpleButton_NewFile.Size = new System.Drawing.Size(88, 26);
            this.simpleButton_NewFile.TabIndex = 1;
            this.simpleButton_NewFile.Tag = 4;
            this.simpleButton_NewFile.Text = "新  建";
            this.simpleButton_NewFile.Click += new System.EventHandler(this.simpleButton_NewFile_Click);
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(0, 0);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 482);
            this.splitterControl1.TabIndex = 0;
            this.splitterControl1.TabStop = false;
            // 
            // popupMenu2
            // 
            this.popupMenu2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Refresh)});
            this.popupMenu2.Manager = this.barManager1;
            this.popupMenu2.Name = "popupMenu2";
            // 
            // StudentBaseInfo
            // 
            this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Appearance.Options.UseBackColor = true;
            this.Controls.Add(this.xtraTabControl_StuBaseInfo);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "StudentBaseInfo";
            this.Size = new System.Drawing.Size(772, 704);
            this.Load += new System.EventHandler(this.StudentBaseInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_StuBaseInfo)).EndInit();
            this.xtraTabControl_StuBaseInfo.ResumeLayout(false);
            this.xtraTabPage_StuBaseInfoMgmt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl_StuBaseInfo)).EndInit();
            this.splitContainerControl_StuBaseInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ShowStu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Number.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Class.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Grade.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_MOWorkingAddr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_MOPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_MOName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_FAWorkingAddr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_FAPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_FAName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_HuKouAddr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_ILLHistory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_EMail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_BankID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Street.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_JUWei.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_ZIPCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_RegNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Native.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Nationality.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_FamilyAddr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_StuDefaultNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_Birthday.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_Birthday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_KidOrigin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_GUID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_EntryDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_EntryDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit_LoadImageData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_EntryStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_KidGender.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_KidName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region 当窗体加载时获取年级信息
		private void StudentBaseInfo_Load(object sender, System.EventArgs e)
		{
			comboBoxEdit_Grade.SelectedItem = "全部";
			foreach(DataRow getGradeList in getStuInfoByCondition.getGradeInfo("","").Tables[0].Rows)
			{
				comboBoxEdit_Grade.Properties.Items.AddRange(
					new object[]{getGradeList[1].ToString()});
			}

			TextDataUnBanding();
			TextDataBanding("","","","");

			//保健，财务，创智管理员权限
			if ( Thread.CurrentPrincipal.Identity.Name.ToLower() == "admin" || Thread.CurrentPrincipal.IsInRole("财务")
				|| Thread.CurrentPrincipal.IsInRole("保健"))
			{
				simpleButton_BlankButton.Enabled = false;
				simpleButton_NewFile.Enabled = false;
				simpleButton_printButton.Enabled = false;
				simpleButton_SaveButton.Enabled = false;
			}

			//班主任权限
			if ( Thread.CurrentPrincipal.IsInRole("班主任") )
			{
				DataSet dsRolesDuty = rolesSystem.GetRolesDuty(Convert.ToInt32(Thread.CurrentPrincipal.Identity.Name));
				string gradeName = dsRolesDuty.Tables[0].Rows[0][0].ToString();
				string className = dsRolesDuty.Tables[0].Rows[0][1].ToString();

				comboBoxEdit_Grade.Properties.Items.Clear();
				comboBoxEdit_Grade.Properties.Items.AddRange(new object[]{gradeName});
				comboBoxEdit_Grade.SelectedItem = gradeName;
				comboBoxEdit_Class.Properties.Items.Clear();
				comboBoxEdit_Class.Properties.Items.AddRange(new object[]{className});
				comboBoxEdit_Class.SelectedItem = className;
			}
			
			if ( Thread.CurrentPrincipal.Identity.Name.ToLower() != "admin" )
				notePanel1.Text = new HealthManagementSystem().GetTeaName(Thread.CurrentPrincipal.Identity.Name) 
										+ "教师欢迎您进入学生基本信息检索";

			if ( Thread.CurrentPrincipal.Identity.Name.ToLower() == "admin" )
				notePanel1.Text = "创智管理员欢迎您进入学生基本信息检索";

			if ( Thread.CurrentPrincipal.IsInRole("园长") )
				notePanel1.Text = new HealthManagementSystem().GetTeaName(Thread.CurrentPrincipal.Identity.Name)
										+ "园长欢迎您进入学生基本信息检索";
		}
		#endregion

		#region 新建卡事件处理
		private void simpleButton_NewFile_Click(object sender, System.EventArgs e)
		{
            dataNavigator_SerStu.Buttons.DoClick(dataNavigator_SerStu.Buttons.Append);
			//dataNavigator_SerStu.Buttons.Append.DoClick();
			comboBoxEdit_EntryStatus.SelectedItem = "日托";
			dateEdit_Birthday.DateTime = DateTime.Now;
			dateEdit_EntryDate.DateTime = DateTime.Now;
			comboBoxEdit_KidGender.SelectedItem = "男";
//			getGradeNumberFromCombo = "0";
//			getClassNumberFromCombo = "0";

			isNewAdd = true;
		}
		#endregion

		#region 保存卡事件处理
		private void simpleButton_SaveButton_Click(object sender, System.EventArgs e)
		{
			string message = "是否确认保存这些数据？";
			string caption = "消息提示框!";
			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult == DialogResult.Yes )
			{
				try
				{
					bool doDataInsertLoopOnce = true;
					guid = Guid.NewGuid();
					while(doDataInsertLoopOnce)
					{

						#region 字段检验调用

						if (!isNewAdd)
						{
							if ( gridView1.RowCount > 0 )
							{
								if ( !gridView1.GetDataRow(gridView1.GetSelectedRows()[0])[1].ToString().Equals("") )
								{
									//								string s = gridView1.GetDataRow(gridView1.GetSelectedRows()[0])[1].ToString();
									//								string t = s;
									getGradeNumberFromCombo = gridView1.GetDataRow(gridView1.GetSelectedRows()[0])[1].ToString().Substring(0,1);
									getClassNumberFromCombo = gridView1.GetDataRow(gridView1.GetSelectedRows()[0])[1].ToString().Substring(1,1);
								}
							}
						}

						if ( !stuValidationCheck.isValidGrade(getGradeNumberFromCombo) )
						{
							MessageBox.Show("请为幼儿安排所在年级");
							break;
						}

						if ( !stuValidationCheck.isValidClass(getClassNumberFromCombo) )
						{
							MessageBox.Show("请为幼儿安排所在班级");
							break;
						}

						if ( !stuValidationCheck.isValidStuName(textEdit_KidName.Text.Replace(" ","")) )
						{
							MessageBox.Show("幼儿姓名不能为空！");
							break;
						}	

						if ( !stuValidationCheck.isValidStuGender(comboBoxEdit_KidGender.Text) )
						{
							MessageBox.Show("幼儿性别不正确！");
							break;
						}

						if ( !stuValidationCheck.isValidEntryStatus(comboBoxEdit_EntryStatus.Text.Replace(" ","")) )
						{
							MessageBox.Show("幼儿托管类型不正确！");
							break;
						}
						
						if ( gridView1.RowCount > 0 )
						{
							if ( stuValidationCheck.HasCard(textEdit_GUID.Text,textEdit_StuDefaultNumber.Text))
							{
								MessageBox.Show("该学生已经发过卡，修改学号会存在潜在风险，修改失败！");
								break;
							}
							else
							{
								//获取顺序学号
								if ( textEdit_StuDefaultNumber.Text.Equals("") )
								{
									if ( Convert.ToInt32(getGradeNumberFromCombo) <= 8 )
									{
										bool overValidNumber = false;
										stuValidationCheck.getSerialStuNumber(getGradeNumberFromCombo,getClassNumberFromCombo,ref overValidNumber);
										if ( overValidNumber )
										{
											MessageBox.Show("班级最大能容纳99名幼儿，该幼儿学号不符合要求，请重试");
											break;
										}
									}
									else
									{
										MessageBox.Show("对不起，软件默认年级最大数应为8个，该年级无法分配幼儿，请更换年级后重试！");
										break;
									}
								}

								else
								{
									if ( !stuValidationCheck.isValidStuNumber(textEdit_StuDefaultNumber.Text.Replace(" ","")) )
									{
										MessageBox.Show("请确保输入的学号是有效学号！");
										break;
									}
									else
									{
										bool overValidNumber = false;
										bool isThisClass = true;
										if ( !textEdit_GUID.Text.Equals("")  )
										{
											if ( !stuValidationCheck.hasSameNumber(textEdit_StuDefaultNumber.Text.Replace(" ",""),
												textEdit_GUID.Text.Replace(" ",""),ref overValidNumber,ref isThisClass,getClassNumberFromCombo,getGradeNumberFromCombo) )
											{
												if ( isThisClass )
												{
													if ( overValidNumber )
													{
														MessageBox.Show("班级最大能容纳99名幼儿，该幼儿学号不符合要求，请重试");
														break;
													}
													else
													{
														MessageBox.Show("您所修改的幼儿学号已经存在，请更换！");
														break;
													}
												}
												else
												{
													MessageBox.Show("该幼儿的学号不属于该班级，请重试");
													break;
												}
											}
										}
										else
										{
											if ( !stuValidationCheck.hasSameNumber( textEdit_StuDefaultNumber.Text.Replace(" ",""),
												guid.ToString() ,ref overValidNumber,ref isThisClass,getClassNumberFromCombo,getGradeNumberFromCombo) )
											{
												if ( isThisClass )
												{
													if ( overValidNumber )
													{
														MessageBox.Show("班级最大能容纳99名幼儿，该幼儿学号不符合要求，请重试");
														break;
													}
													else
													{
														MessageBox.Show("您所修改的幼儿学号已经存在，请更换！");
														break;
													}
												}
												else
												{
													MessageBox.Show("该幼儿的学号不属于该班级，请重试试");
													break;
												}
											}
										}
									}
								}
							}
						}

						if(!stuValidationCheck.isValidRegNote(textEdit_RegNote.Text.Replace(" ","")))
						{
							MessageBox.Show("请确保手机输入号码是有效号码！");
							break;
						}
	
						if(!stuValidationCheck.isValidEmail(textEdit_EMail.Text.Replace(" ","")))
						{
							MessageBox.Show("邮件地址格式不正确！");
							break;
						}
	
						if( !stuValidationCheck.isValidDate((DateTime)dateEdit_Birthday.EditValue,(DateTime)
							dateEdit_EntryDate.EditValue) )
						{
							MessageBox.Show("生日和入园日期不得为空，如已填写，请确保两者正确的逻辑关系！");
							break;
						}
						#endregion

						#region 无须检验字段
						if ( !textEdit_GUID.Text.Equals("") )
							stuValidationCheck.getStuGuid(textEdit_GUID.Text);
						else
							stuValidationCheck.getStuGuid(guid.ToString());
						stuValidationCheck.getStuOrigin(textEdit_KidOrigin.Text.Replace(" ",""));
						stuValidationCheck.getStuNationality(textEdit_Nationality.Text.Replace(" ",""));
						stuValidationCheck.getStuNative(textEdit_Native.Text.Replace(" ",""));
						stuValidationCheck.getStuJieDao(textEdit_Street.Text.Replace(" ",""));
						stuValidationCheck.getStuLiWei(textEdit_JUWei.Text.Replace(" ",""));
						stuValidationCheck.getStuFamilyAddr(textEdit_FamilyAddr.Text.Replace(" ",""));
						stuValidationCheck.getStuHuKouAddr(textEdit_HuKouAddr.Text.Replace(" ",""));
						stuValidationCheck.getStuZipCode(textEdit_ZIPCode.Text.Replace(" ",""));
						stuValidationCheck.getStuSickHistory(textEdit_ILLHistory.Text.Replace(" ",""));
						stuValidationCheck.getStuBankID(textEdit_BankID.Text.Replace(" ",""));
						stuValidationCheck.getStuFatherName(textEdit_FAName.Text.Replace(" ",""));
						stuValidationCheck.getStuFatherLinkPhone(textEdit_FAPhone.Text.Replace(" ",""));
						stuValidationCheck.getStuFatherWorkPlace(textEdit_FAWorkingAddr.Text.Replace(" ",""));
						stuValidationCheck.getStuMotherName(textEdit_MOName.Text.Replace(" ",""));
						stuValidationCheck.getStuMotherLinkPhone(textEdit_MOPhone.Text.Replace(" ",""));
						stuValidationCheck.getStuMotherWorkPlace(textEdit_MOWorkingAddr.Text.Replace(" ",""));

						if ( pictureEdit_LoadImageData.Image == null )
							imageDataBuffer = null;
						else
						{
							imageMSReader = new MemoryStream();
							pictureEdit_LoadImageData.Image.Save(imageMSReader,ImageFormat.Jpeg);
							imageDataBuffer = imageMSReader.ToArray();
						}
						stuValidationCheck.getStuGraphLocation(imageDataBuffer);
						#endregion
					
						#region 学生信息插入
						stuValidationCheck.doStuBasicInfoInsert();
						stuValidationCheck.doStuDetailInfoInsert();
						stuValidationCheck.doStuParentInfoInsert();
						#endregion

						MessageBox.Show("保存完毕！");
						doDataInsertLoopOnce = false;
						isNewAdd = false;

						//刷新绑定信息
						TextDataUnBanding();
						TextDataBanding(getGradeNumberFromCombo,getClassNumberFromCombo,
							textEdit_Name.Text.Replace(" ",""),textEdit_Number.Text.Replace(" ",""));
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}
		#endregion
		
//		#region 删除卡事件处理
//		private void simpleButton_DeleteButton_Click(object sender, System.EventArgs e)
//		{
//			string message = "是否确认删除这些数据？";
//			string caption = "消息提示框!";
//			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
//			if ( messageResult == DialogResult.Yes )
//			{
//				try
//				{
//					stuValidationCheck.getStuGuid(textEdit_GUID.Text.Replace(" ",""));
//					stuValidationCheck.doStuBasicInfoDelete();
//					stuValidationCheck.doStuDetailInfoDelete();
//					stuValidationCheck.doStuParentInfoDelete();
//
//					MessageBox.Show("删除完毕！");
//					TextDataUnBanding();
//					TextDataBanding(getGradeNumberFromCombo,getClassNumberFromCombo,
//						textEdit_Name.Text.Replace(" ",""),textEdit_Number.Text.Replace(" ",""));
//				}
//				catch(Exception ex)
//				{
//					MessageBox.Show(ex.Message);
//				}
//			}
//		}
//		#endregion

		#region 清空卡事件处理
		private void simpleButton_BlankButton_Click(object sender, System.EventArgs e)
		{
			string message = "是否确清空当前数据？";
			string caption = "消息提示框!";
			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult == DialogResult.Yes )
			{
				TextDataClear();
			}
		}
		#endregion

		#region 打印
		private void simpleButton_printButton_Click(object sender, System.EventArgs e)
		{
			string savePath;
			saveFileDialog_Report.Filter = "Excel文件|*.xls";

			if ( saveFileDialog_Report.ShowDialog() != DialogResult.OK )
				return;

			savePath = saveFileDialog_Report.FileName;

			SetPrintMember();
			stuBaseInfoPrintSystem.StuBaseInfoPrint(savePath);

			MessageBox.Show("打印完毕！");
		}
		#endregion

		#region 帮助事件处理
		private void simpleButton_Help_Click(object sender, System.EventArgs e)
		{

		}
		#endregion

		#region 图片位置指定并放入流中
		private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			openFileDialog1.Filter = "图像文件(*.bmp;*.jpg;*.jpeg;*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
			if(openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				try
				{
					
					imageMSReader = new MemoryStream();
					Bitmap imageData = new Bitmap(openFileDialog1.FileName);
					pictureEdit_LoadImageData.EditValue = imageData;
					imageData.Save(imageMSReader,ImageFormat.Jpeg);
					imageDataBuffer = imageMSReader.ToArray();
				}
				catch
				{
					MessageBox.Show("图片没找到或损坏，请更换图片！");
				}

			}
		}
		#endregion

		#region 清空图片
		private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			pictureEdit_LoadImageData.EditValue = null;
		}
		#endregion

		#region 根据获取的年级信息获取班级信息,并绑定相应控件
		private void comboBoxEdit_Grade_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			comboBoxEdit_Class.Properties.Items.Clear();
			comboBoxEdit_Class.Properties.Items.AddRange(new object[]{"全部"});
			comboBoxEdit_Class.SelectedItem = "全部";
			if(getStuInfoByCondition.getGradeInfo(comboBoxEdit_Grade.SelectedItem.ToString(),"").Tables[0].Rows.Count > 0)
			{
				//根据年级选择获取年级编号
				getGradeNumberFromCombo = getStuInfoByCondition.getGradeInfo(
					comboBoxEdit_Grade.SelectedItem.ToString(),"").Tables[0].Rows[0][0].ToString();
				foreach(DataRow getClassList in getStuInfoByCondition.getClassInfo("","",
					getGradeNumberFromCombo).Tables[0].Rows)
				{
					comboBoxEdit_Class.Properties.Items.AddRange(
						new object[]{getClassList[1].ToString()});
				}

				//处理指定的年级事件,如果特定姓名或学号已经存在则不进行处理
				if(textEdit_Name.Text.Equals("") && textEdit_Number.Text.Equals(""))
				{
					TextDataUnBanding();
					TextDataBanding(getGradeNumberFromCombo,"","","");
				}
	
			}	
			else
			{
				//处理年级选定项为”全部“事件
				if(textEdit_Name.Text.Equals("") && textEdit_Number.Text.Equals(""))
				{
					TextDataUnBanding();
					TextDataBanding("","","","");
				}
			}

			if ( comboBoxEdit_Grade.SelectedItem.ToString().Equals("全部") )
				getClassNumberFromCombo = "0";

			isNewAdd = false;
		}
		#endregion

		#region 处理班级选择事件
		private void comboBoxEdit_Class_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(textEdit_Name.Text.Equals("") && textEdit_Number.Text.Equals(""))
			{
				if(comboBoxEdit_Class.SelectedItem.ToString().Equals("全部"))
				{
					TextDataUnBanding();
					TextDataBanding(getGradeNumberFromCombo,"","","");
				}
				else
				{
					getClassNumberFromCombo = getStuInfoByCondition.getClassInfo(
						comboBoxEdit_Class.SelectedItem.ToString(),"","").Tables[0].Rows[0][0].ToString();
					TextDataUnBanding();
					TextDataBanding(getGradeNumberFromCombo,getClassNumberFromCombo,"","");
				}
			}

			if ( comboBoxEdit_Class.SelectedItem.ToString().Equals("全部") )
				getClassNumberFromCombo = "0";

			isNewAdd = false;
		}
		#endregion

		#region  处理姓名输入事件
		private void textEdit_Name_EditValueChanged(object sender, System.EventArgs e)
		{
			if(textEdit_Number.Text.Equals(""))
			{
				TextDataUnBanding();

				//处理当姓名为空时，其上控件是否有值选定
				if(!textEdit_Name.Text.Equals(""))
				{
					TextDataBanding("","",textEdit_Name.Text.Replace(" ",""),"");
				}
				else
				{
					if(comboBoxEdit_Grade.SelectedItem.ToString().Equals("全部"))
					{
						TextDataBanding("","","","");
					}
					else if(comboBoxEdit_Class.SelectedItem.ToString().Equals("全部"))
					{
						TextDataBanding(getGradeNumberFromCombo,"","","");
					}
					else
					{
						TextDataBanding(getGradeNumberFromCombo,getClassNumberFromCombo,"","");
					}
				}
			}

			isNewAdd = false;
		}
		#endregion

		#region 处理学号输入事件
		private void textEdit_Number_EditValueChanged(object sender, System.EventArgs e)
		{
			TextDataUnBanding();

			//处理当学号为空时，其上控件是否有值选定
			if(!textEdit_Number.Text.Equals(""))
			{
				
				TextDataBanding("","","",textEdit_Number.Text.Replace(" ",""));
			}
			else
			{
				if(textEdit_Name.Text.Equals(""))
				{
					if(comboBoxEdit_Grade.SelectedItem.ToString().Equals("全部"))
					{
						TextDataBanding("","","","");
					}
					else if(comboBoxEdit_Class.SelectedItem.ToString().Equals("全部"))
					{
						TextDataBanding(getGradeNumberFromCombo,"","","");
					}
					else
					{
						TextDataBanding(getGradeNumberFromCombo,getClassNumberFromCombo,"","");
					}
				}
				else
				{
					TextDataBanding("","",textEdit_Name.Text,"");
				}
			}

			isNewAdd = false;
		}
		#endregion

		#region 控件绑定
		private void TextDataBanding(string getGradeNumber,string getClassNumber,string getStuName,string getStuNumber)
		{
			try
			{
				//dataNavigator_SerStu.Buttons.CancelEdit.DoClick();
                dataNavigator_SerStu.Buttons.DoClick(dataNavigator_SerStu.Buttons.CancelEdit);
				gridView1.MoveFirst();

				//获取查询后的学生信息数据集
				DataSet dataBandings = getStuInfoByCondition.GetStuInfo(
					getGradeNumber,getClassNumber,getStuName,getStuNumber);

				if ( Thread.CurrentPrincipal.IsInRole("班主任") )
				{
					if ( dataBandings.Tables[0].Rows.Count > 0 )
					{
						foreach(DataRow matchRow in dataBandings.Tables[0].Rows)
						{
							if ( !matchRow["info_className"].Equals(rolesSystem.GetRolesDuty(Convert.ToInt32(Thread.CurrentPrincipal.Identity.Name)).Tables[0].Rows[0][1].ToString()) )
								matchRow.Delete();
						}
					}
				}
			
				//获取dataGrid里面显示学生学号，姓名，班级信息
				gridControl_ShowStu.DataSource = dataBandings.Tables[0];

				//绑定到数据导航栏

				dataNavigator_SerStu.DataSource = dataBandings.Tables[0];

				//guid
				textEdit_GUID.DataBindings.Add("EditValue",dataBandings.Tables[0],"info_stuID");

				//姓名
				textEdit_KidName.DataBindings.Add("EditValue",dataBandings.Tables[0],"info_stuName");

				//性别
				comboBoxEdit_KidGender.DataBindings.Add("EditValue",dataBandings.Tables[0],"info_stuGender");
			
				//生日
				dateEdit_Birthday.DataBindings.Add("EditValue",dataBandings.Tables[0],"info_stuBirthDay");

				//入园注册时间
				dateEdit_EntryDate.DataBindings.Add("EditValue",dataBandings.Tables[0],"info_stuEntryDate");

				//入园状态
				comboBoxEdit_EntryStatus.DataBindings.Add("EditValue",dataBandings.Tables[0],"info_stuEntryStatus");

				//系统指定学生显示学号（自动分配）
				textEdit_StuDefaultNumber.DataBindings.Add("EditValue",dataBandings.Tables[0],"info_stuNumber");

				//学生来源
				textEdit_KidOrigin.DataBindings.Add("EditValue",dataBandings.Tables[0],"info_stuOrigin");

				//国籍
				textEdit_Nationality.DataBindings.Add("EditValue",dataBandings.Tables[0],"info_stuNationality");

				//籍贯
				textEdit_Native.DataBindings.Add("EditValue",dataBandings.Tables[0],"info_stuNative");

				//银行帐号
				textEdit_BankID.DataBindings.Add("EditValue",dataBandings.Tables[0],"info_stuBankID");

				//幼儿照片
				pictureEdit_LoadImageData.DataBindings.Add("EditValue",dataBandings.Tables[0],"info_stuGraphLocation");
			
				//短信注册号码
				textEdit_RegNote.DataBindings.Add("EditValue",dataBandings.Tables[0],"info_stuRegNote");

				//邮编
				textEdit_ZIPCode.DataBindings.Add("EditValue",dataBandings.Tables[0],"info_stuZipCode");

				//邮件
				textEdit_EMail.DataBindings.Add("EditValue",dataBandings.Tables[0],"info_stuEMailAddr");

				//街道
				textEdit_Street.DataBindings.Add("EditValue",dataBandings.Tables[0],"info_stuJieDao");

				//里委
				textEdit_JUWei.DataBindings.Add("EditValue",dataBandings.Tables[0],"info_stuLiWei");

				//病史
				textEdit_ILLHistory.DataBindings.Add("EditValue",dataBandings.Tables[0],"info_stuSickHistory");

				//家庭住址
				textEdit_FamilyAddr.DataBindings.Add("EditValue",dataBandings.Tables[0],"info_stuFamilyAddr");

				//户口住址
				textEdit_HuKouAddr.DataBindings.Add("EditValue",dataBandings.Tables[0],"info_stuHuKouAddr");
			
				//父亲姓名
				textEdit_FAName.DataBindings.Add("EditValue",dataBandings.Tables[0],"info_stuFatherName");

				//父亲联系电话
				textEdit_FAPhone.DataBindings.Add("EditValue",dataBandings.Tables[0],"info_stuFatherLinkPhone");

				//父亲工作单位
				textEdit_FAWorkingAddr.DataBindings.Add("EditValue",dataBandings.Tables[0],"info_stuFatherWorkPlace");

				//母亲姓名
				textEdit_MOName.DataBindings.Add("EditValue",dataBandings.Tables[0],"info_stuMotherName");

				//母亲联系电话
				textEdit_MOPhone.DataBindings.Add("EditValue",dataBandings.Tables[0],"info_stuMotherLinkPhone");

				//母亲工作单位
				textEdit_MOWorkingAddr.DataBindings.Add("EditValue",dataBandings.Tables[0],"info_stuMotherWorkPlace");

				
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}
		#endregion

		#region 撤消控件绑定
		private void TextDataUnBanding()
		{
			textEdit_KidName.DataBindings.Clear();
			comboBoxEdit_KidGender.DataBindings.Clear();
			dateEdit_Birthday.DataBindings.Clear();
			dateEdit_EntryDate.DataBindings.Clear();		
			comboBoxEdit_EntryStatus.DataBindings.Clear();
			textEdit_StuDefaultNumber.DataBindings.Clear();
			textEdit_KidOrigin.DataBindings.Clear();
			textEdit_Nationality.DataBindings.Clear();
			textEdit_Native.DataBindings.Clear();		
			textEdit_BankID.DataBindings.Clear();
			pictureEdit_LoadImageData.DataBindings.Clear();
			textEdit_RegNote.DataBindings.Clear();
			textEdit_ZIPCode.DataBindings.Clear();
			textEdit_EMail.DataBindings.Clear();
			textEdit_Street.DataBindings.Clear();
			textEdit_JUWei.DataBindings.Clear();
			textEdit_ILLHistory.DataBindings.Clear();
			textEdit_FamilyAddr.DataBindings.Clear();
			textEdit_HuKouAddr.DataBindings.Clear();
			textEdit_FAName.DataBindings.Clear();
			textEdit_FAPhone.DataBindings.Clear();
			textEdit_FAWorkingAddr.DataBindings.Clear();
			textEdit_MOName.DataBindings.Clear();
			textEdit_MOPhone.DataBindings.Clear();
			textEdit_MOWorkingAddr.DataBindings.Clear();
			textEdit_GUID.DataBindings.Clear();
		}

		#endregion

		#region 控件清空
		private void TextDataClear()
		{
			textEdit_KidName.Text = "";
			comboBoxEdit_KidGender.Text = "男";
			dateEdit_Birthday.Text = "";
			dateEdit_EntryDate.Text = "";
			comboBoxEdit_EntryStatus.Text = "日托";
			textEdit_KidOrigin.Text = "";
			textEdit_Nationality.Text = "";
			textEdit_Native.Text = "";		
			textEdit_BankID.Text = "";
			textEdit_RegNote.Text = "";
			textEdit_ZIPCode.Text = "";
			textEdit_EMail.Text = "";
			textEdit_Street.Text = "";
			textEdit_JUWei.Text = "";
			textEdit_ILLHistory.Text = "";
			textEdit_FamilyAddr.Text = "";
			textEdit_HuKouAddr.Text = "";
			textEdit_FAName.Text = "";
			textEdit_FAPhone.Text = "";
			textEdit_FAWorkingAddr.Text = "";
			textEdit_MOName.Text = "";
			textEdit_MOPhone.Text = "";
			textEdit_MOWorkingAddr.Text = "";
			pictureEdit_LoadImageData.EditValue = null;
		}
		#endregion

		#region 刷新
		private void barButtonItem_Refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			TextDataUnBanding();
			TextDataBanding(getGradeNumberFromCombo,getClassNumberFromCombo,
				textEdit_Name.Text.Replace(" ",""),textEdit_Number.Text.Replace(" ",""));
		}
		#endregion

		#region 打印成员
		private void SetPrintMember()
		{
			stuBaseInfoPrintSystem.SetName(textEdit_KidName.Text);
			stuBaseInfoPrintSystem.SetEntryStatus(comboBoxEdit_EntryStatus.SelectedItem.ToString());
			stuBaseInfoPrintSystem.SetGender(comboBoxEdit_KidGender.SelectedItem.ToString());
			stuBaseInfoPrintSystem.SetLeaveDate(DateTime.MinValue);
			stuBaseInfoPrintSystem.SetBirthday(dateEdit_Birthday.DateTime.Date);
			stuBaseInfoPrintSystem.SetNumber(textEdit_StuDefaultNumber.Text);
			stuBaseInfoPrintSystem.SetEntryDate(dateEdit_EntryDate.DateTime.Date);
			stuBaseInfoPrintSystem.SetOrigin(textEdit_KidOrigin.Text);
			stuBaseInfoPrintSystem.SetNationality(textEdit_Nationality.Text);
			stuBaseInfoPrintSystem.SetZipCode(textEdit_ZIPCode.Text);
			stuBaseInfoPrintSystem.SetJieDao(textEdit_Street.Text);
			stuBaseInfoPrintSystem.SetLiWei(textEdit_JUWei.Text);
			stuBaseInfoPrintSystem.SetNative(textEdit_Native.Text);
			stuBaseInfoPrintSystem.SetFamilyAddr(textEdit_FamilyAddr.Text);
			stuBaseInfoPrintSystem.SetHuKouAddr(textEdit_HuKouAddr.Text);
			stuBaseInfoPrintSystem.SetSickHistory(textEdit_ILLHistory.Text);
			stuBaseInfoPrintSystem.SetFatherName(textEdit_FAName.Text);
			stuBaseInfoPrintSystem.SetFatherPhone(textEdit_FAPhone.Text);
			stuBaseInfoPrintSystem.SetFatherWorkPlace(textEdit_FAWorkingAddr.Text);
			stuBaseInfoPrintSystem.SetMotherName(textEdit_MOName.Text);
			stuBaseInfoPrintSystem.SetMotherPhone(textEdit_MOPhone.Text);
			stuBaseInfoPrintSystem.SetMotherWorkPlace(textEdit_MOWorkingAddr.Text);
			if ( pictureEdit_LoadImageData.EditValue == null || pictureEdit_LoadImageData.EditValue is DBNull)
				stuBaseInfoPrintSystem.NeedPrintPicture = false;
			else
				stuBaseInfoPrintSystem.NeedPrintPicture = true;
			stuBaseInfoPrintSystem.SetPicture(pictureEdit_LoadImageData.Image);

		}
		#endregion

		#region 导出信息处理
		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			string savePath;
			saveFileDialog_Report.Filter = "Excel文件|*.xls";

			if ( saveFileDialog_Report.ShowDialog() != DialogResult.OK )
				return;

			savePath = saveFileDialog_Report.FileName;

			DataSet dsExportData = getStuInfoByCondition.GetExportData(
				comboBoxEdit_Grade.SelectedItem.ToString().Equals("全部")?"":getGradeNumberFromCombo,
				comboBoxEdit_Class.SelectedItem.ToString().Equals("全部")?"":getClassNumberFromCombo,
				textEdit_Number.Text,textEdit_Name.Text);

			if (dsExportData != null)
			{
				if (dsExportData.Tables.Count == 2)
				{
					stuBaseInfoPrintSystem.AllStuInfoPrint(dsExportData,savePath);

					MessageBox.Show("报表生成完毕！");
				}
				else MessageBox.Show("没有需要导出的数据");
			}
			else MessageBox.Show("没有需要导出的数据");
		}
		#endregion
	}
}

