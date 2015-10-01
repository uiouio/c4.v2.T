//==================================================================================
// 创智智能晨检网络管理系统4.0
//==================================================================================
// Copyright @2005 Shanghai Chuangzhi Toy&Technology Corporation All rights reserved.
//本计算机程序受版权法和国际条约保护.
// 如未经授权而擅自复制或传播本程序(或其中任何部分),将受到严厉的民事及刑事制裁,
//并将在法律许可的范围内受到最大程度的起诉!
//==================================================================================

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using CPTT.BusinessFacade;
using CPTT.SystemFramework;

namespace CPTT.WinUI.Panels
{
	/// <summary>
	/// Summary description for TeacherBaseInfo.
	/// </summary>
	public class TeacherBaseInfo : DevExpress.XtraEditors.XtraUserControl
	{
		private DevExpress.XtraTab.XtraTabControl xtraTabControl_TeaBaseInfo;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage_TeaBaseInfoMgmt;
		private DevExpress.Utils.Frames.NotePanel notePanel_TeaBaseInfoTitle;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Class;
		private DevExpress.Utils.Frames.NotePanel notePanel_Class;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Grade;
		private DevExpress.Utils.Frames.NotePanel notePanel_Grade;
		private DevExpress.Utils.Frames.NotePanel notePanel1;
		private DevExpress.XtraEditors.TextEdit textEdit_Number;
		private DevExpress.XtraEditors.TextEdit textEdit_Name;
		private DevExpress.Utils.Frames.NotePanel notePanel_Number;
		private DevExpress.Utils.Frames.NotePanel notePanel_Name;
		private DevExpress.XtraEditors.DataNavigator dataNavigator1;
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private DevExpress.XtraEditors.SimpleButton simpleButton_SaveButton;
		private DevExpress.XtraEditors.SimpleButton simpleButton_ModifyButton;
		private DevExpress.XtraEditors.SimpleButton simpleButton_NewFile;
		private DevExpress.XtraEditors.GroupControl groupControl2;
		private DevExpress.Utils.Frames.NotePanel notePanel_KidBaseInfoTitle;
		private DevExpress.Utils.Frames.NotePanel notePanel_KidName;
		private DevExpress.Utils.Frames.NotePanel notePanel2;
		private DevExpress.Utils.Frames.NotePanel notePanel3;
		private DevExpress.Utils.Frames.NotePanel notePanel5;
		private DevExpress.Utils.Frames.NotePanel notePanel6;
		private DevExpress.Utils.Frames.NotePanel notePanel7;
		private DevExpress.Utils.Frames.NotePanel notePanel10;
		private DevExpress.Utils.Frames.NotePanel notePanel11;
		private DevExpress.Utils.Frames.NotePanel notePanel12;
		private System.Windows.Forms.Label label_ReqOfKidName;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.GroupControl groupControl3;
		private DevExpress.Utils.Frames.NotePanel notePanel4;
		private DevExpress.Utils.Frames.NotePanel notePanel8;
		private DevExpress.Utils.Frames.NotePanel notePanel9;
		private DevExpress.Utils.Frames.NotePanel notePanel13;
		private DevExpress.Utils.Frames.NotePanel notePanel14;
		private DevExpress.Utils.Frames.NotePanel notePanel15;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.Utils.Frames.NotePanel notePanel16;
		private System.Windows.Forms.OpenFileDialog openFileDialog_ChooseImg;
		private DevExpress.XtraBars.PopupMenu popupMenu1;
		private DevExpress.XtraBars.BarManager barManager1;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
		private DevExpress.XtraBars.BarButtonItem barButtonItem1;
		private DevExpress.Utils.Frames.NotePanel notePanel17;
		private DevExpress.XtraEditors.ComboBoxEdit tLevel;
		private DevExpress.XtraEditors.ComboBoxEdit tDept;
		private DevExpress.XtraEditors.TextEdit tAddr;
		private DevExpress.XtraEditors.ComboBoxEdit tRecord;
		private DevExpress.XtraEditors.ComboBoxEdit tSex;
		private DevExpress.XtraEditors.TextEdit tWorkPhone;
		private DevExpress.XtraEditors.TextEdit tPhone;
		private DevExpress.XtraEditors.TextEdit tHomePhone;
		private DevExpress.XtraEditors.TextEdit tNumber;
		private DevExpress.XtraEditors.TextEdit tName;
		private DevExpress.XtraEditors.ComboBoxEdit tMarrige;
		private DevExpress.XtraEditors.ComboBoxEdit tTechnicalPost;
		private DevExpress.XtraEditors.DateEdit tJoinDate;
		private DevExpress.XtraEditors.DateEdit tEnterTime;
		private DevExpress.XtraEditors.ComboBoxEdit tDuty;
		private DevExpress.XtraEditors.SimpleButton simpleButton_WriteButton;
		private string tID;
		private DevExpress.XtraEditors.TextEdit textEdit_tID;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_TeaInfo_Refresh;
		private DevExpress.XtraBars.PopupMenu popupMenu2;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_TeaInfo_LoadPic;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_TeaInfo_DeletePic;
		private byte[] imageDataBuffer;
		private DevExpress.XtraEditors.PictureEdit pictureEdit_LoadImageData;

		private TeaBaseInfoPrintSystem teaBaseInfoPrintSystem;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Privilege;
		private DevExpress.XtraEditors.TextEdit textEdit_UserPwd;
		private System.Windows.Forms.SaveFileDialog saveFileDialog_Report;
		private MemoryStream imageMSReader;
		
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.HelpProvider helpProvider_Help;
		private RolesSystem rolesSystem;

		public TeacherBaseInfo()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call
			helpProvider_Help.HelpNamespace = Path.GetDirectoryName(Application.ExecutablePath)
				+ CPTT.SystemFramework.Util.HELP_FILE_NAME;
			teaBaseInfoPrintSystem = new TeaBaseInfoPrintSystem();
			rolesSystem = new RolesSystem();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(TeacherBaseInfo));
			this.xtraTabControl_TeaBaseInfo = new DevExpress.XtraTab.XtraTabControl();
			this.xtraTabPage_TeaBaseInfoMgmt = new DevExpress.XtraTab.XtraTabPage();
			this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.dataNavigator1 = new DevExpress.XtraEditors.DataNavigator();
			this.textEdit_Number = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_Name = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_Number = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_Name = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel1 = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_Class = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_Class = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_Grade = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_Grade = new DevExpress.Utils.Frames.NotePanel();
			this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tTechnicalPost = new DevExpress.XtraEditors.ComboBoxEdit();
			this.tLevel = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel15 = new DevExpress.Utils.Frames.NotePanel();
			this.tJoinDate = new DevExpress.XtraEditors.DateEdit();
			this.tEnterTime = new DevExpress.XtraEditors.DateEdit();
			this.notePanel14 = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel13 = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel9 = new DevExpress.Utils.Frames.NotePanel();
			this.tDuty = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel8 = new DevExpress.Utils.Frames.NotePanel();
			this.tDept = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel4 = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_tID = new DevExpress.XtraEditors.TextEdit();
			this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
			this.label2 = new System.Windows.Forms.Label();
			this.label_ReqOfKidName = new System.Windows.Forms.Label();
			this.pictureEdit_LoadImageData = new DevExpress.XtraEditors.PictureEdit();
			this.tAddr = new DevExpress.XtraEditors.TextEdit();
			this.notePanel12 = new DevExpress.Utils.Frames.NotePanel();
			this.tRecord = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel11 = new DevExpress.Utils.Frames.NotePanel();
			this.tSex = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel10 = new DevExpress.Utils.Frames.NotePanel();
			this.tWorkPhone = new DevExpress.XtraEditors.TextEdit();
			this.notePanel7 = new DevExpress.Utils.Frames.NotePanel();
			this.tPhone = new DevExpress.XtraEditors.TextEdit();
			this.notePanel6 = new DevExpress.Utils.Frames.NotePanel();
			this.tHomePhone = new DevExpress.XtraEditors.TextEdit();
			this.notePanel5 = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_UserPwd = new DevExpress.XtraEditors.TextEdit();
			this.tNumber = new DevExpress.XtraEditors.TextEdit();
			this.tName = new DevExpress.XtraEditors.TextEdit();
			this.notePanel3 = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel2 = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_KidName = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_KidBaseInfoTitle = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_Privilege = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel16 = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel17 = new DevExpress.Utils.Frames.NotePanel();
			this.tMarrige = new DevExpress.XtraEditors.ComboBoxEdit();
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.simpleButton_WriteButton = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_SaveButton = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_ModifyButton = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_NewFile = new DevExpress.XtraEditors.SimpleButton();
			this.notePanel_TeaBaseInfoTitle = new DevExpress.Utils.Frames.NotePanel();
			this.barManager1 = new DevExpress.XtraBars.BarManager();
			this.popupMenu1 = new DevExpress.XtraBars.PopupMenu();
			this.barButtonItem_TeaInfo_Refresh = new DevExpress.XtraBars.BarButtonItem();
			this.popupMenu2 = new DevExpress.XtraBars.PopupMenu();
			this.barButtonItem_TeaInfo_LoadPic = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem_TeaInfo_DeletePic = new DevExpress.XtraBars.BarButtonItem();
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
			this.openFileDialog_ChooseImg = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog_Report = new System.Windows.Forms.SaveFileDialog();
			this.helpProvider_Help = new System.Windows.Forms.HelpProvider();
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_TeaBaseInfo)).BeginInit();
			this.xtraTabControl_TeaBaseInfo.SuspendLayout();
			this.xtraTabPage_TeaBaseInfoMgmt.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
			this.splitContainerControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_Number.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_Name.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Class.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Grade.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
			this.groupControl3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tTechnicalPost.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tLevel.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tJoinDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tEnterTime.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tDuty.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tDept.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_tID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
			this.groupControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureEdit_LoadImageData.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tAddr.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tRecord.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tSex.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tWorkPhone.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tPhone.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tHomePhone.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_UserPwd.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tNumber.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Privilege.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tMarrige.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).BeginInit();
			this.SuspendLayout();
			// 
			// xtraTabControl_TeaBaseInfo
			// 
			this.xtraTabControl_TeaBaseInfo.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.xtraTabControl_TeaBaseInfo.Appearance.Options.UseBackColor = true;
			this.xtraTabControl_TeaBaseInfo.AppearancePage.HeaderActive.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.xtraTabControl_TeaBaseInfo.AppearancePage.HeaderActive.ForeColor = System.Drawing.Color.DarkOrange;
			this.xtraTabControl_TeaBaseInfo.AppearancePage.HeaderActive.Options.UseFont = true;
			this.xtraTabControl_TeaBaseInfo.AppearancePage.HeaderActive.Options.UseForeColor = true;
			this.xtraTabControl_TeaBaseInfo.Controls.Add(this.xtraTabPage_TeaBaseInfoMgmt);
			this.xtraTabControl_TeaBaseInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.helpProvider_Help.SetHelpKeyword(this.xtraTabControl_TeaBaseInfo, "教师基本信息管理");
			this.helpProvider_Help.SetHelpNavigator(this.xtraTabControl_TeaBaseInfo, System.Windows.Forms.HelpNavigator.KeywordIndex);
			this.helpProvider_Help.SetHelpString(this.xtraTabControl_TeaBaseInfo, "");
			this.xtraTabControl_TeaBaseInfo.Location = new System.Drawing.Point(0, 0);
			this.xtraTabControl_TeaBaseInfo.Name = "xtraTabControl_TeaBaseInfo";
			this.xtraTabControl_TeaBaseInfo.SelectedTabPage = this.xtraTabPage_TeaBaseInfoMgmt;
			this.helpProvider_Help.SetShowHelp(this.xtraTabControl_TeaBaseInfo, true);
			this.xtraTabControl_TeaBaseInfo.Size = new System.Drawing.Size(772, 540);
			this.xtraTabControl_TeaBaseInfo.TabIndex = 0;
			this.xtraTabControl_TeaBaseInfo.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
																									   this.xtraTabPage_TeaBaseInfoMgmt});
			this.xtraTabControl_TeaBaseInfo.Text = "基本信息管理";
			// 
			// xtraTabPage_TeaBaseInfoMgmt
			// 
			this.xtraTabPage_TeaBaseInfoMgmt.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
			this.xtraTabPage_TeaBaseInfoMgmt.Appearance.PageClient.Options.UseBackColor = true;
			this.xtraTabPage_TeaBaseInfoMgmt.Controls.Add(this.splitContainerControl1);
			this.xtraTabPage_TeaBaseInfoMgmt.Controls.Add(this.notePanel_TeaBaseInfoTitle);
			this.xtraTabPage_TeaBaseInfoMgmt.Name = "xtraTabPage_TeaBaseInfoMgmt";
			this.xtraTabPage_TeaBaseInfoMgmt.Size = new System.Drawing.Size(768, 515);
			this.xtraTabPage_TeaBaseInfoMgmt.Text = "基本信息管理";
			// 
			// splitContainerControl1
			// 
			this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl1.Location = new System.Drawing.Point(0, 23);
			this.splitContainerControl1.Name = "splitContainerControl1";
			this.splitContainerControl1.Panel1.Controls.Add(this.gridControl1);
			this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1);
			this.splitContainerControl1.Panel1.Text = "splitContainerControl1_Panel1";
			this.splitContainerControl1.Panel2.Controls.Add(this.groupControl3);
			this.splitContainerControl1.Panel2.Controls.Add(this.groupControl2);
			this.splitContainerControl1.Panel2.Controls.Add(this.panelControl1);
			this.splitContainerControl1.Panel2.Text = "splitContainerControl1_Panel2";
			this.splitContainerControl1.Size = new System.Drawing.Size(768, 492);
			this.splitContainerControl1.SplitterPosition = 200;
			this.splitContainerControl1.TabIndex = 4;
			this.splitContainerControl1.Text = "splitContainerControl1";
			// 
			// gridControl1
			// 
			this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl1.EmbeddedNavigator
			// 
			this.gridControl1.EmbeddedNavigator.Name = "";
			this.gridControl1.Location = new System.Drawing.Point(0, 224);
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.barManager1.SetPopupContextMenu(this.gridControl1, this.popupMenu1);
			this.gridControl1.Size = new System.Drawing.Size(194, 262);
			this.gridControl1.TabIndex = 1;
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn1,
																							 this.gridColumn2,
																							 this.gridColumn3});
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsCustomization.AllowFilter = false;
			this.gridView1.OptionsView.ShowFilterPanel = false;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
			// 
			// gridColumn1
			// 
			this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn1.Caption = "工号";
			this.gridColumn1.FieldName = "T_Number";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.OptionsColumn.AllowEdit = false;
			this.gridColumn1.OptionsColumn.AllowFocus = false;
			this.gridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn1.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn1.OptionsColumn.AllowMove = false;
			this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn1.OptionsColumn.FixedWidth = true;
			this.gridColumn1.OptionsColumn.ReadOnly = true;
			this.gridColumn1.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			// 
			// gridColumn2
			// 
			this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn2.Caption = "姓名";
			this.gridColumn2.FieldName = "T_Name";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.OptionsColumn.AllowEdit = false;
			this.gridColumn2.OptionsColumn.AllowFocus = false;
			this.gridColumn2.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn2.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn2.OptionsColumn.AllowMove = false;
			this.gridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn2.OptionsColumn.FixedWidth = true;
			this.gridColumn2.OptionsColumn.ReadOnly = true;
			this.gridColumn2.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			// 
			// gridColumn3
			// 
			this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn3.Caption = "岗位";
			this.gridColumn3.FieldName = "T_Duty";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.OptionsColumn.AllowEdit = false;
			this.gridColumn3.OptionsColumn.AllowFocus = false;
			this.gridColumn3.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn3.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn3.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn3.OptionsColumn.AllowMove = false;
			this.gridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn3.OptionsColumn.FixedWidth = true;
			this.gridColumn3.OptionsColumn.ReadOnly = true;
			this.gridColumn3.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 2;
			// 
			// groupControl1
			// 
			this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl1.AppearanceCaption.Options.UseFont = true;
			this.groupControl1.Controls.Add(this.dataNavigator1);
			this.groupControl1.Controls.Add(this.textEdit_Number);
			this.groupControl1.Controls.Add(this.textEdit_Name);
			this.groupControl1.Controls.Add(this.notePanel_Number);
			this.groupControl1.Controls.Add(this.notePanel_Name);
			this.groupControl1.Controls.Add(this.notePanel1);
			this.groupControl1.Controls.Add(this.comboBoxEdit_Class);
			this.groupControl1.Controls.Add(this.notePanel_Class);
			this.groupControl1.Controls.Add(this.comboBoxEdit_Grade);
			this.groupControl1.Controls.Add(this.notePanel_Grade);
			this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl1.Location = new System.Drawing.Point(0, 0);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(194, 224);
			this.groupControl1.TabIndex = 0;
			this.groupControl1.Text = "本园教师";
			// 
			// dataNavigator1
			// 
			this.dataNavigator1.Buttons.Append.Visible = false;
			this.dataNavigator1.Buttons.CancelEdit.Visible = false;
			this.dataNavigator1.Buttons.EndEdit.Visible = false;
			this.dataNavigator1.Buttons.First.Hint = "第一条记录";
			this.dataNavigator1.Buttons.Last.Hint = "最后一条记录";
			this.dataNavigator1.Buttons.Next.Hint = "下一条记录";
			this.dataNavigator1.Buttons.NextPage.Visible = false;
			this.dataNavigator1.Buttons.Prev.Hint = "上一条记录";
			this.dataNavigator1.Buttons.PrevPage.Visible = false;
			this.dataNavigator1.Buttons.Remove.Visible = false;
			this.dataNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dataNavigator1.Location = new System.Drawing.Point(3, 189);
			this.dataNavigator1.Name = "dataNavigator1";
			this.dataNavigator1.Size = new System.Drawing.Size(188, 32);
			this.dataNavigator1.TabIndex = 35;
			this.dataNavigator1.Text = "dataNavigator1";
			this.dataNavigator1.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.End;
			// 
			// textEdit_Number
			// 
			this.textEdit_Number.EditValue = "";
			this.textEdit_Number.Location = new System.Drawing.Point(88, 152);
			this.textEdit_Number.Name = "textEdit_Number";
			this.textEdit_Number.Size = new System.Drawing.Size(79, 23);
			this.textEdit_Number.TabIndex = 34;
			this.textEdit_Number.EditValueChanged += new System.EventHandler(this.textEdit_Number_EditValueChanged);
			// 
			// textEdit_Name
			// 
			this.textEdit_Name.EditValue = "";
			this.textEdit_Name.Location = new System.Drawing.Point(88, 120);
			this.textEdit_Name.Name = "textEdit_Name";
			this.textEdit_Name.Size = new System.Drawing.Size(79, 23);
			this.textEdit_Name.TabIndex = 33;
			this.textEdit_Name.EditValueChanged += new System.EventHandler(this.textEdit_Name_EditValueChanged);
			// 
			// notePanel_Number
			// 
			this.notePanel_Number.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_Number.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_Number.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_Number.ForeColor = System.Drawing.Color.Black;
			this.notePanel_Number.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Number.Location = new System.Drawing.Point(15, 152);
			this.notePanel_Number.MaxRows = 5;
			this.notePanel_Number.Name = "notePanel_Number";
			this.notePanel_Number.ParentAutoHeight = true;
			this.notePanel_Number.Size = new System.Drawing.Size(65, 22);
			this.notePanel_Number.TabIndex = 32;
			this.notePanel_Number.TabStop = false;
			this.notePanel_Number.Text = "工  号:";
			// 
			// notePanel_Name
			// 
			this.notePanel_Name.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_Name.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_Name.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_Name.ForeColor = System.Drawing.Color.Black;
			this.notePanel_Name.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Name.Location = new System.Drawing.Point(15, 120);
			this.notePanel_Name.MaxRows = 5;
			this.notePanel_Name.Name = "notePanel_Name";
			this.notePanel_Name.ParentAutoHeight = true;
			this.notePanel_Name.Size = new System.Drawing.Size(65, 22);
			this.notePanel_Name.TabIndex = 31;
			this.notePanel_Name.TabStop = false;
			this.notePanel_Name.Text = "姓  名:";
			// 
			// notePanel1
			// 
			this.notePanel1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel1.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel1.Location = new System.Drawing.Point(3, 18);
			this.notePanel1.MaxRows = 5;
			this.notePanel1.Name = "notePanel1";
			this.notePanel1.ParentAutoHeight = true;
			this.notePanel1.Size = new System.Drawing.Size(188, 23);
			this.notePanel1.TabIndex = 18;
			this.notePanel1.TabStop = false;
			this.notePanel1.Text = "您要查找哪位教师？";
			// 
			// comboBoxEdit_Class
			// 
			this.comboBoxEdit_Class.EditValue = "全部";
			this.comboBoxEdit_Class.Location = new System.Drawing.Point(88, 88);
			this.comboBoxEdit_Class.Name = "comboBoxEdit_Class";
			// 
			// comboBoxEdit_Class.Properties
			// 
			this.comboBoxEdit_Class.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_Class.Properties.Items.AddRange(new object[] {
																			   "全部"});
			this.comboBoxEdit_Class.Size = new System.Drawing.Size(79, 23);
			this.comboBoxEdit_Class.TabIndex = 17;
			this.comboBoxEdit_Class.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_Class_SelectedIndexChanged);
			// 
			// notePanel_Class
			// 
			this.notePanel_Class.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_Class.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_Class.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_Class.ForeColor = System.Drawing.Color.Black;
			this.notePanel_Class.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Class.Location = new System.Drawing.Point(17, 88);
			this.notePanel_Class.MaxRows = 5;
			this.notePanel_Class.Name = "notePanel_Class";
			this.notePanel_Class.ParentAutoHeight = true;
			this.notePanel_Class.Size = new System.Drawing.Size(64, 22);
			this.notePanel_Class.TabIndex = 16;
			this.notePanel_Class.TabStop = false;
			this.notePanel_Class.Text = "岗  位:";
			// 
			// comboBoxEdit_Grade
			// 
			this.comboBoxEdit_Grade.EditValue = "全部";
			this.comboBoxEdit_Grade.Location = new System.Drawing.Point(88, 56);
			this.comboBoxEdit_Grade.Name = "comboBoxEdit_Grade";
			// 
			// comboBoxEdit_Grade.Properties
			// 
			this.comboBoxEdit_Grade.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_Grade.Properties.Items.AddRange(new object[] {
																			   "全部"});
			this.comboBoxEdit_Grade.Size = new System.Drawing.Size(79, 23);
			this.comboBoxEdit_Grade.TabIndex = 15;
			this.comboBoxEdit_Grade.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_Grade_SelectedIndexChanged);
			// 
			// notePanel_Grade
			// 
			this.notePanel_Grade.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_Grade.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_Grade.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_Grade.ForeColor = System.Drawing.Color.Black;
			this.notePanel_Grade.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Grade.Location = new System.Drawing.Point(17, 56);
			this.notePanel_Grade.MaxRows = 5;
			this.notePanel_Grade.Name = "notePanel_Grade";
			this.notePanel_Grade.ParentAutoHeight = true;
			this.notePanel_Grade.Size = new System.Drawing.Size(64, 22);
			this.notePanel_Grade.TabIndex = 14;
			this.notePanel_Grade.TabStop = false;
			this.notePanel_Grade.Text = "部  门:";
			// 
			// groupControl3
			// 
			this.groupControl3.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl3.AppearanceCaption.Options.UseFont = true;
			this.groupControl3.Controls.Add(this.label4);
			this.groupControl3.Controls.Add(this.label3);
			this.groupControl3.Controls.Add(this.tTechnicalPost);
			this.groupControl3.Controls.Add(this.tLevel);
			this.groupControl3.Controls.Add(this.notePanel15);
			this.groupControl3.Controls.Add(this.tJoinDate);
			this.groupControl3.Controls.Add(this.tEnterTime);
			this.groupControl3.Controls.Add(this.notePanel14);
			this.groupControl3.Controls.Add(this.notePanel13);
			this.groupControl3.Controls.Add(this.notePanel9);
			this.groupControl3.Controls.Add(this.tDuty);
			this.groupControl3.Controls.Add(this.notePanel8);
			this.groupControl3.Controls.Add(this.tDept);
			this.groupControl3.Controls.Add(this.notePanel4);
			this.groupControl3.Controls.Add(this.textEdit_tID);
			this.groupControl3.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl3.Location = new System.Drawing.Point(0, 296);
			this.groupControl3.Name = "groupControl3";
			this.groupControl3.Size = new System.Drawing.Size(558, 176);
			this.groupControl3.TabIndex = 2;
			this.groupControl3.Text = "教师工作信息";
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.ForeColor = System.Drawing.Color.Red;
			this.label4.Location = new System.Drawing.Point(48, 76);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(16, 16);
			this.label4.TabIndex = 55;
			this.label4.Text = "*";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(48, 36);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(16, 16);
			this.label3.TabIndex = 54;
			this.label3.Text = "*";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tTechnicalPost
			// 
			this.tTechnicalPost.EditValue = "中级职称";
			this.tTechnicalPost.Location = new System.Drawing.Point(160, 112);
			this.tTechnicalPost.Name = "tTechnicalPost";
			// 
			// tTechnicalPost.Properties
			// 
			this.tTechnicalPost.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.tTechnicalPost.Properties.Items.AddRange(new object[] {
																		   "中级职称",
																		   "高级职称"});
			this.tTechnicalPost.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.tTechnicalPost.Size = new System.Drawing.Size(88, 23);
			this.tTechnicalPost.TabIndex = 53;
			// 
			// tLevel
			// 
			this.tLevel.EditValue = "一级教师";
			this.tLevel.Location = new System.Drawing.Point(400, 32);
			this.tLevel.Name = "tLevel";
			// 
			// tLevel.Properties
			// 
			this.tLevel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																										   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.tLevel.Properties.Items.AddRange(new object[] {
																   "一级教师",
																   "二级教师",
																   "三级教师",
																   "特级教师"});
			this.tLevel.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.tLevel.Size = new System.Drawing.Size(88, 23);
			this.tLevel.TabIndex = 52;
			// 
			// notePanel15
			// 
			this.notePanel15.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel15.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel15.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel15.ForeColor = System.Drawing.Color.Black;
			this.notePanel15.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel15.Location = new System.Drawing.Point(280, 32);
			this.notePanel15.MaxRows = 5;
			this.notePanel15.Name = "notePanel15";
			this.notePanel15.ParentAutoHeight = true;
			this.notePanel15.Size = new System.Drawing.Size(104, 22);
			this.notePanel15.TabIndex = 51;
			this.notePanel15.TabStop = false;
			this.notePanel15.Text = "   教师等级:";
			// 
			// tJoinDate
			// 
			this.tJoinDate.EditValue = new System.DateTime(2005, 5, 21, 0, 0, 0, 0);
			this.tJoinDate.Location = new System.Drawing.Point(400, 72);
			this.tJoinDate.Name = "tJoinDate";
			// 
			// tJoinDate.Properties
			// 
			this.tJoinDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.tJoinDate.Properties.Mask.EditMask = "d";
			this.tJoinDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
			this.tJoinDate.Size = new System.Drawing.Size(88, 23);
			this.tJoinDate.TabIndex = 50;
			// 
			// tEnterTime
			// 
			this.tEnterTime.EditValue = new System.DateTime(2005, 5, 21, 0, 0, 0, 0);
			this.tEnterTime.Location = new System.Drawing.Point(400, 112);
			this.tEnterTime.Name = "tEnterTime";
			// 
			// tEnterTime.Properties
			// 
			this.tEnterTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.tEnterTime.Properties.Mask.EditMask = "d";
			this.tEnterTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
			this.tEnterTime.Size = new System.Drawing.Size(88, 23);
			this.tEnterTime.TabIndex = 49;
			// 
			// notePanel14
			// 
			this.notePanel14.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel14.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel14.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel14.ForeColor = System.Drawing.Color.Black;
			this.notePanel14.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel14.Location = new System.Drawing.Point(280, 112);
			this.notePanel14.MaxRows = 5;
			this.notePanel14.Name = "notePanel14";
			this.notePanel14.ParentAutoHeight = true;
			this.notePanel14.Size = new System.Drawing.Size(104, 22);
			this.notePanel14.TabIndex = 48;
			this.notePanel14.TabStop = false;
			this.notePanel14.Text = "   入园时间:";
			// 
			// notePanel13
			// 
			this.notePanel13.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel13.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel13.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel13.ForeColor = System.Drawing.Color.Black;
			this.notePanel13.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel13.Location = new System.Drawing.Point(280, 72);
			this.notePanel13.MaxRows = 5;
			this.notePanel13.Name = "notePanel13";
			this.notePanel13.ParentAutoHeight = true;
			this.notePanel13.Size = new System.Drawing.Size(104, 22);
			this.notePanel13.TabIndex = 47;
			this.notePanel13.TabStop = false;
			this.notePanel13.Text = "参加工作时间:";
			// 
			// notePanel9
			// 
			this.notePanel9.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel9.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel9.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel9.ForeColor = System.Drawing.Color.Black;
			this.notePanel9.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel9.Location = new System.Drawing.Point(72, 112);
			this.notePanel9.MaxRows = 5;
			this.notePanel9.Name = "notePanel9";
			this.notePanel9.ParentAutoHeight = true;
			this.notePanel9.Size = new System.Drawing.Size(80, 22);
			this.notePanel9.TabIndex = 45;
			this.notePanel9.TabStop = false;
			this.notePanel9.Text = "  职  称:";
			// 
			// tDuty
			// 
			this.tDuty.EditValue = "";
			this.tDuty.Location = new System.Drawing.Point(160, 72);
			this.tDuty.Name = "tDuty";
			// 
			// tDuty.Properties
			// 
			this.tDuty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																										  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.tDuty.Size = new System.Drawing.Size(88, 23);
			this.tDuty.TabIndex = 44;
			// 
			// notePanel8
			// 
			this.notePanel8.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel8.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel8.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel8.ForeColor = System.Drawing.Color.Black;
			this.notePanel8.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel8.Location = new System.Drawing.Point(72, 72);
			this.notePanel8.MaxRows = 5;
			this.notePanel8.Name = "notePanel8";
			this.notePanel8.ParentAutoHeight = true;
			this.notePanel8.Size = new System.Drawing.Size(80, 22);
			this.notePanel8.TabIndex = 43;
			this.notePanel8.TabStop = false;
			this.notePanel8.Text = "  岗  位:";
			// 
			// tDept
			// 
			this.tDept.EditValue = "";
			this.tDept.Location = new System.Drawing.Point(160, 32);
			this.tDept.Name = "tDept";
			// 
			// tDept.Properties
			// 
			this.tDept.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																										  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.tDept.Size = new System.Drawing.Size(88, 23);
			this.tDept.TabIndex = 26;
			this.tDept.SelectedIndexChanged += new System.EventHandler(this.tDept_SelectedIndexChanged);
			// 
			// notePanel4
			// 
			this.notePanel4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel4.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel4.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel4.ForeColor = System.Drawing.Color.Black;
			this.notePanel4.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel4.Location = new System.Drawing.Point(72, 32);
			this.notePanel4.MaxRows = 5;
			this.notePanel4.Name = "notePanel4";
			this.notePanel4.ParentAutoHeight = true;
			this.notePanel4.Size = new System.Drawing.Size(80, 22);
			this.notePanel4.TabIndex = 25;
			this.notePanel4.TabStop = false;
			this.notePanel4.Text = "所属部门:";
			// 
			// textEdit_tID
			// 
			this.textEdit_tID.EditValue = "textEdit1";
			this.textEdit_tID.Location = new System.Drawing.Point(376, 40);
			this.textEdit_tID.Name = "textEdit_tID";
			// 
			// textEdit_tID.Properties
			// 
			this.textEdit_tID.Properties.AutoHeight = false;
			this.textEdit_tID.Size = new System.Drawing.Size(8, 8);
			this.textEdit_tID.TabIndex = 52;
			// 
			// groupControl2
			// 
			this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl2.AppearanceCaption.Options.UseFont = true;
			this.groupControl2.Controls.Add(this.label2);
			this.groupControl2.Controls.Add(this.label_ReqOfKidName);
			this.groupControl2.Controls.Add(this.pictureEdit_LoadImageData);
			this.groupControl2.Controls.Add(this.tAddr);
			this.groupControl2.Controls.Add(this.notePanel12);
			this.groupControl2.Controls.Add(this.tRecord);
			this.groupControl2.Controls.Add(this.notePanel11);
			this.groupControl2.Controls.Add(this.tSex);
			this.groupControl2.Controls.Add(this.notePanel10);
			this.groupControl2.Controls.Add(this.tWorkPhone);
			this.groupControl2.Controls.Add(this.notePanel7);
			this.groupControl2.Controls.Add(this.tPhone);
			this.groupControl2.Controls.Add(this.notePanel6);
			this.groupControl2.Controls.Add(this.tHomePhone);
			this.groupControl2.Controls.Add(this.notePanel5);
			this.groupControl2.Controls.Add(this.textEdit_UserPwd);
			this.groupControl2.Controls.Add(this.tNumber);
			this.groupControl2.Controls.Add(this.tName);
			this.groupControl2.Controls.Add(this.notePanel3);
			this.groupControl2.Controls.Add(this.notePanel2);
			this.groupControl2.Controls.Add(this.notePanel_KidName);
			this.groupControl2.Controls.Add(this.notePanel_KidBaseInfoTitle);
			this.groupControl2.Controls.Add(this.comboBoxEdit_Privilege);
			this.groupControl2.Controls.Add(this.notePanel16);
			this.groupControl2.Controls.Add(this.notePanel17);
			this.groupControl2.Controls.Add(this.tMarrige);
			this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl2.Location = new System.Drawing.Point(0, 40);
			this.groupControl2.Name = "groupControl2";
			this.groupControl2.Size = new System.Drawing.Size(558, 256);
			this.groupControl2.TabIndex = 1;
			this.groupControl2.Text = "教师基本信息";
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.Color.Red;
			this.label2.Location = new System.Drawing.Point(24, 124);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(16, 16);
			this.label2.TabIndex = 51;
			this.label2.Text = "*";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label_ReqOfKidName
			// 
			this.label_ReqOfKidName.BackColor = System.Drawing.Color.Transparent;
			this.label_ReqOfKidName.ForeColor = System.Drawing.Color.Red;
			this.label_ReqOfKidName.Location = new System.Drawing.Point(24, 60);
			this.label_ReqOfKidName.Name = "label_ReqOfKidName";
			this.label_ReqOfKidName.Size = new System.Drawing.Size(16, 16);
			this.label_ReqOfKidName.TabIndex = 49;
			this.label_ReqOfKidName.Text = "*";
			this.label_ReqOfKidName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pictureEdit_LoadImageData
			// 
			this.pictureEdit_LoadImageData.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureEdit_LoadImageData.BackgroundImage")));
			this.pictureEdit_LoadImageData.Location = new System.Drawing.Point(432, 56);
			this.pictureEdit_LoadImageData.Name = "pictureEdit_LoadImageData";
			this.barManager1.SetPopupContextMenu(this.pictureEdit_LoadImageData, this.popupMenu2);
			// 
			// pictureEdit_LoadImageData.Properties
			// 
			this.pictureEdit_LoadImageData.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.pictureEdit_LoadImageData.Properties.Appearance.Options.UseBackColor = true;
			this.pictureEdit_LoadImageData.Properties.NullText = "   像素800*600";
			this.pictureEdit_LoadImageData.Properties.ShowMenu = false;
			this.pictureEdit_LoadImageData.Size = new System.Drawing.Size(112, 120);
			this.pictureEdit_LoadImageData.TabIndex = 48;
			// 
			// tAddr
			// 
			this.tAddr.EditValue = "";
			this.tAddr.Location = new System.Drawing.Point(136, 216);
			this.tAddr.Name = "tAddr";
			this.tAddr.Size = new System.Drawing.Size(272, 23);
			this.tAddr.TabIndex = 47;
			// 
			// notePanel12
			// 
			this.notePanel12.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel12.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel12.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel12.ForeColor = System.Drawing.Color.Black;
			this.notePanel12.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel12.Location = new System.Drawing.Point(48, 216);
			this.notePanel12.MaxRows = 5;
			this.notePanel12.Name = "notePanel12";
			this.notePanel12.ParentAutoHeight = true;
			this.notePanel12.Size = new System.Drawing.Size(80, 22);
			this.notePanel12.TabIndex = 46;
			this.notePanel12.TabStop = false;
			this.notePanel12.Text = "  地  址:";
			// 
			// tRecord
			// 
			this.tRecord.EditValue = "本科";
			this.tRecord.Location = new System.Drawing.Point(320, 56);
			this.tRecord.Name = "tRecord";
			// 
			// tRecord.Properties
			// 
			this.tRecord.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.tRecord.Properties.Items.AddRange(new object[] {
																	"高中",
																	"大专",
																	"本科",
																	"硕士",
																	"博士",
																	"博士后"});
			this.tRecord.Size = new System.Drawing.Size(88, 23);
			this.tRecord.TabIndex = 45;
			// 
			// notePanel11
			// 
			this.notePanel11.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel11.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel11.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel11.ForeColor = System.Drawing.Color.Black;
			this.notePanel11.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel11.Location = new System.Drawing.Point(232, 56);
			this.notePanel11.MaxRows = 5;
			this.notePanel11.Name = "notePanel11";
			this.notePanel11.ParentAutoHeight = true;
			this.notePanel11.Size = new System.Drawing.Size(80, 22);
			this.notePanel11.TabIndex = 44;
			this.notePanel11.TabStop = false;
			this.notePanel11.Text = "  学  历:";
			// 
			// tSex
			// 
			this.tSex.EditValue = "男";
			this.tSex.Location = new System.Drawing.Point(136, 152);
			this.tSex.Name = "tSex";
			// 
			// tSex.Properties
			// 
			this.tSex.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																										 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.tSex.Properties.Items.AddRange(new object[] {
																 "男",
																 "女"});
			this.tSex.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.tSex.Size = new System.Drawing.Size(80, 23);
			this.tSex.TabIndex = 43;
			// 
			// notePanel10
			// 
			this.notePanel10.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel10.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel10.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel10.ForeColor = System.Drawing.Color.Black;
			this.notePanel10.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel10.Location = new System.Drawing.Point(48, 152);
			this.notePanel10.MaxRows = 5;
			this.notePanel10.Name = "notePanel10";
			this.notePanel10.ParentAutoHeight = true;
			this.notePanel10.Size = new System.Drawing.Size(80, 22);
			this.notePanel10.TabIndex = 42;
			this.notePanel10.TabStop = false;
			this.notePanel10.Text = "  性  别:";
			// 
			// tWorkPhone
			// 
			this.tWorkPhone.EditValue = "";
			this.tWorkPhone.Location = new System.Drawing.Point(320, 152);
			this.tWorkPhone.Name = "tWorkPhone";
			this.tWorkPhone.Size = new System.Drawing.Size(88, 23);
			this.tWorkPhone.TabIndex = 36;
			// 
			// notePanel7
			// 
			this.notePanel7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel7.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel7.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel7.ForeColor = System.Drawing.Color.Black;
			this.notePanel7.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel7.Location = new System.Drawing.Point(232, 152);
			this.notePanel7.MaxRows = 5;
			this.notePanel7.Name = "notePanel7";
			this.notePanel7.ParentAutoHeight = true;
			this.notePanel7.Size = new System.Drawing.Size(80, 22);
			this.notePanel7.TabIndex = 35;
			this.notePanel7.TabStop = false;
			this.notePanel7.Text = "办公电话:";
			// 
			// tPhone
			// 
			this.tPhone.EditValue = "";
			this.tPhone.Location = new System.Drawing.Point(320, 120);
			this.tPhone.Name = "tPhone";
			this.tPhone.Size = new System.Drawing.Size(88, 23);
			this.tPhone.TabIndex = 34;
			// 
			// notePanel6
			// 
			this.notePanel6.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel6.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel6.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel6.ForeColor = System.Drawing.Color.Black;
			this.notePanel6.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel6.Location = new System.Drawing.Point(232, 120);
			this.notePanel6.MaxRows = 5;
			this.notePanel6.Name = "notePanel6";
			this.notePanel6.ParentAutoHeight = true;
			this.notePanel6.Size = new System.Drawing.Size(80, 22);
			this.notePanel6.TabIndex = 33;
			this.notePanel6.TabStop = false;
			this.notePanel6.Text = "手机号码:";
			// 
			// tHomePhone
			// 
			this.tHomePhone.EditValue = "";
			this.tHomePhone.Location = new System.Drawing.Point(320, 88);
			this.tHomePhone.Name = "tHomePhone";
			this.tHomePhone.Size = new System.Drawing.Size(88, 23);
			this.tHomePhone.TabIndex = 32;
			// 
			// notePanel5
			// 
			this.notePanel5.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel5.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel5.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel5.ForeColor = System.Drawing.Color.Black;
			this.notePanel5.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel5.Location = new System.Drawing.Point(232, 88);
			this.notePanel5.MaxRows = 5;
			this.notePanel5.Name = "notePanel5";
			this.notePanel5.ParentAutoHeight = true;
			this.notePanel5.Size = new System.Drawing.Size(80, 22);
			this.notePanel5.TabIndex = 31;
			this.notePanel5.TabStop = false;
			this.notePanel5.Text = "家庭电话:";
			// 
			// textEdit_UserPwd
			// 
			this.textEdit_UserPwd.EditValue = "1234";
			this.textEdit_UserPwd.Location = new System.Drawing.Point(136, 120);
			this.textEdit_UserPwd.Name = "textEdit_UserPwd";
			// 
			// textEdit_UserPwd.Properties
			// 
			this.textEdit_UserPwd.Properties.PasswordChar = '*';
			this.textEdit_UserPwd.Properties.ReadOnly = true;
			this.textEdit_UserPwd.Size = new System.Drawing.Size(80, 23);
			this.textEdit_UserPwd.TabIndex = 30;
			// 
			// tNumber
			// 
			this.tNumber.EditValue = "";
			this.tNumber.Location = new System.Drawing.Point(136, 88);
			this.tNumber.Name = "tNumber";
			this.tNumber.Size = new System.Drawing.Size(80, 23);
			this.tNumber.TabIndex = 29;
			// 
			// tName
			// 
			this.tName.EditValue = "";
			this.tName.Location = new System.Drawing.Point(136, 56);
			this.tName.Name = "tName";
			this.tName.Size = new System.Drawing.Size(80, 23);
			this.tName.TabIndex = 28;
			// 
			// notePanel3
			// 
			this.notePanel3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel3.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel3.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel3.ForeColor = System.Drawing.Color.Black;
			this.notePanel3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel3.Location = new System.Drawing.Point(48, 120);
			this.notePanel3.MaxRows = 5;
			this.notePanel3.Name = "notePanel3";
			this.notePanel3.ParentAutoHeight = true;
			this.notePanel3.Size = new System.Drawing.Size(80, 22);
			this.notePanel3.TabIndex = 26;
			this.notePanel3.TabStop = false;
			this.notePanel3.Text = "登陆密码:";
			// 
			// notePanel2
			// 
			this.notePanel2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel2.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel2.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel2.ForeColor = System.Drawing.Color.Black;
			this.notePanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel2.Location = new System.Drawing.Point(48, 87);
			this.notePanel2.MaxRows = 5;
			this.notePanel2.Name = "notePanel2";
			this.notePanel2.ParentAutoHeight = true;
			this.notePanel2.Size = new System.Drawing.Size(80, 22);
			this.notePanel2.TabIndex = 25;
			this.notePanel2.TabStop = false;
			this.notePanel2.Text = "教师工号:";
			// 
			// notePanel_KidName
			// 
			this.notePanel_KidName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_KidName.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_KidName.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_KidName.ForeColor = System.Drawing.Color.Black;
			this.notePanel_KidName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_KidName.Location = new System.Drawing.Point(48, 56);
			this.notePanel_KidName.MaxRows = 5;
			this.notePanel_KidName.Name = "notePanel_KidName";
			this.notePanel_KidName.ParentAutoHeight = true;
			this.notePanel_KidName.Size = new System.Drawing.Size(80, 22);
			this.notePanel_KidName.TabIndex = 24;
			this.notePanel_KidName.TabStop = false;
			this.notePanel_KidName.Text = "教师姓名:";
			// 
			// notePanel_KidBaseInfoTitle
			// 
			this.notePanel_KidBaseInfoTitle.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel_KidBaseInfoTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel_KidBaseInfoTitle.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel_KidBaseInfoTitle.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_KidBaseInfoTitle.Location = new System.Drawing.Point(3, 18);
			this.notePanel_KidBaseInfoTitle.MaxRows = 5;
			this.notePanel_KidBaseInfoTitle.Name = "notePanel_KidBaseInfoTitle";
			this.notePanel_KidBaseInfoTitle.ParentAutoHeight = true;
			this.notePanel_KidBaseInfoTitle.Size = new System.Drawing.Size(552, 23);
			this.notePanel_KidBaseInfoTitle.TabIndex = 23;
			this.notePanel_KidBaseInfoTitle.TabStop = false;
			this.notePanel_KidBaseInfoTitle.Text = "教师基本信息(*为必须填写)";
			// 
			// comboBoxEdit_Privilege
			// 
			this.comboBoxEdit_Privilege.EditValue = "一般";
			this.comboBoxEdit_Privilege.Location = new System.Drawing.Point(320, 184);
			this.comboBoxEdit_Privilege.Name = "comboBoxEdit_Privilege";
			// 
			// comboBoxEdit_Privilege.Properties
			// 
			this.comboBoxEdit_Privilege.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																														   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_Privilege.Properties.Items.AddRange(new object[] {
																				   "园长",
																				   "一般",
																				   "保健",
																				   "班主任",
																				   "财务"});
			this.comboBoxEdit_Privilege.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_Privilege.TabIndex = 43;
			this.comboBoxEdit_Privilege.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_Privilege_SelectedIndexChanged);
			// 
			// notePanel16
			// 
			this.notePanel16.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel16.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel16.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel16.ForeColor = System.Drawing.Color.Black;
			this.notePanel16.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel16.Location = new System.Drawing.Point(232, 184);
			this.notePanel16.MaxRows = 5;
			this.notePanel16.Name = "notePanel16";
			this.notePanel16.ParentAutoHeight = true;
			this.notePanel16.Size = new System.Drawing.Size(80, 22);
			this.notePanel16.TabIndex = 42;
			this.notePanel16.TabStop = false;
			this.notePanel16.Text = "  权  限:";
			// 
			// notePanel17
			// 
			this.notePanel17.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel17.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel17.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel17.ForeColor = System.Drawing.Color.Black;
			this.notePanel17.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel17.Location = new System.Drawing.Point(48, 184);
			this.notePanel17.MaxRows = 5;
			this.notePanel17.Name = "notePanel17";
			this.notePanel17.ParentAutoHeight = true;
			this.notePanel17.Size = new System.Drawing.Size(80, 22);
			this.notePanel17.TabIndex = 42;
			this.notePanel17.TabStop = false;
			this.notePanel17.Text = "  婚   否:";
			// 
			// tMarrige
			// 
			this.tMarrige.EditValue = "是";
			this.tMarrige.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.tMarrige.Location = new System.Drawing.Point(136, 184);
			this.tMarrige.Name = "tMarrige";
			// 
			// tMarrige.Properties
			// 
			this.tMarrige.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.tMarrige.Properties.Items.AddRange(new object[] {
																	 "是",
																	 "否"});
			this.tMarrige.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.tMarrige.Size = new System.Drawing.Size(80, 23);
			this.tMarrige.TabIndex = 43;
			// 
			// panelControl1
			// 
			this.panelControl1.Controls.Add(this.simpleButton_WriteButton);
			this.panelControl1.Controls.Add(this.simpleButton_SaveButton);
			this.panelControl1.Controls.Add(this.simpleButton_ModifyButton);
			this.panelControl1.Controls.Add(this.simpleButton_NewFile);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl1.Location = new System.Drawing.Point(0, 0);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(558, 40);
			this.panelControl1.TabIndex = 0;
			this.panelControl1.Text = "panelControl1";
			// 
			// simpleButton_WriteButton
			// 
			this.simpleButton_WriteButton.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_WriteButton.Appearance.Options.UseForeColor = true;
			this.simpleButton_WriteButton.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_WriteButton.Image")));
			this.simpleButton_WriteButton.Location = new System.Drawing.Point(272, 8);
			this.simpleButton_WriteButton.Name = "simpleButton_WriteButton";
			this.simpleButton_WriteButton.Size = new System.Drawing.Size(80, 26);
			this.simpleButton_WriteButton.TabIndex = 13;
			this.simpleButton_WriteButton.Text = "打 印";
			this.simpleButton_WriteButton.Click += new System.EventHandler(this.simpleButton_WriteButton_Click);
			// 
			// simpleButton_SaveButton
			// 
			this.simpleButton_SaveButton.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_SaveButton.Appearance.Options.UseForeColor = true;
			this.simpleButton_SaveButton.Enabled = false;
			this.simpleButton_SaveButton.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_SaveButton.Image")));
			this.simpleButton_SaveButton.Location = new System.Drawing.Point(96, 8);
			this.simpleButton_SaveButton.Name = "simpleButton_SaveButton";
			this.simpleButton_SaveButton.Size = new System.Drawing.Size(80, 26);
			this.simpleButton_SaveButton.TabIndex = 9;
			this.simpleButton_SaveButton.Text = "保 存";
			this.simpleButton_SaveButton.Click += new System.EventHandler(this.simpleButton_SaveButton_Click);
			// 
			// simpleButton_ModifyButton
			// 
			this.simpleButton_ModifyButton.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_ModifyButton.Appearance.Options.UseForeColor = true;
			this.simpleButton_ModifyButton.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_ModifyButton.Image")));
			this.simpleButton_ModifyButton.Location = new System.Drawing.Point(184, 8);
			this.simpleButton_ModifyButton.Name = "simpleButton_ModifyButton";
			this.simpleButton_ModifyButton.Size = new System.Drawing.Size(80, 26);
			this.simpleButton_ModifyButton.TabIndex = 8;
			this.simpleButton_ModifyButton.Text = "修 改";
			this.simpleButton_ModifyButton.Click += new System.EventHandler(this.simpleButton_ModifyButton_Click);
			// 
			// simpleButton_NewFile
			// 
			this.simpleButton_NewFile.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_NewFile.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_NewFile.Appearance.Options.UseFont = true;
			this.simpleButton_NewFile.Appearance.Options.UseForeColor = true;
			this.simpleButton_NewFile.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_NewFile.Image")));
			this.simpleButton_NewFile.Location = new System.Drawing.Point(8, 8);
			this.simpleButton_NewFile.Name = "simpleButton_NewFile";
			this.simpleButton_NewFile.Size = new System.Drawing.Size(80, 26);
			this.simpleButton_NewFile.TabIndex = 7;
			this.simpleButton_NewFile.Tag = 4;
			this.simpleButton_NewFile.Text = "新 建";
			this.simpleButton_NewFile.Click += new System.EventHandler(this.simpleButton_NewFile_Click);
			// 
			// notePanel_TeaBaseInfoTitle
			// 
			this.notePanel_TeaBaseInfoTitle.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel_TeaBaseInfoTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel_TeaBaseInfoTitle.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel_TeaBaseInfoTitle.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_TeaBaseInfoTitle.Location = new System.Drawing.Point(0, 0);
			this.notePanel_TeaBaseInfoTitle.MaxRows = 5;
			this.notePanel_TeaBaseInfoTitle.Name = "notePanel_TeaBaseInfoTitle";
			this.notePanel_TeaBaseInfoTitle.ParentAutoHeight = true;
			this.notePanel_TeaBaseInfoTitle.Size = new System.Drawing.Size(768, 23);
			this.notePanel_TeaBaseInfoTitle.TabIndex = 3;
			this.notePanel_TeaBaseInfoTitle.TabStop = false;
			this.notePanel_TeaBaseInfoTitle.Text = "某某教师欢迎进入基本信息管理";
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
																				  this.barButtonItem_TeaInfo_Refresh,
																				  this.barButtonItem_TeaInfo_LoadPic,
																				  this.barButtonItem_TeaInfo_DeletePic});
			this.barManager1.MaxItemId = 4;
			// 
			// popupMenu1
			// 
			this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
																									new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_TeaInfo_Refresh)});
			this.popupMenu1.Manager = this.barManager1;
			this.popupMenu1.Name = "popupMenu1";
			// 
			// barButtonItem_TeaInfo_Refresh
			// 
			this.barButtonItem_TeaInfo_Refresh.Caption = "刷新";
			this.barButtonItem_TeaInfo_Refresh.Id = 1;
			this.barButtonItem_TeaInfo_Refresh.Name = "barButtonItem_TeaInfo_Refresh";
			this.barButtonItem_TeaInfo_Refresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_TeaInfo_Refresh_ItemClick);
			// 
			// popupMenu2
			// 
			this.popupMenu2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
																									new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_TeaInfo_LoadPic),
																									new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_TeaInfo_DeletePic)});
			this.popupMenu2.Manager = this.barManager1;
			this.popupMenu2.Name = "popupMenu2";
			// 
			// barButtonItem_TeaInfo_LoadPic
			// 
			this.barButtonItem_TeaInfo_LoadPic.Caption = "载入图片";
			this.barButtonItem_TeaInfo_LoadPic.Id = 2;
			this.barButtonItem_TeaInfo_LoadPic.Name = "barButtonItem_TeaInfo_LoadPic";
			this.barButtonItem_TeaInfo_LoadPic.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_TeaInfo_LoadPic_ItemClick);
			// 
			// barButtonItem_TeaInfo_DeletePic
			// 
			this.barButtonItem_TeaInfo_DeletePic.Caption = "删除图片";
			this.barButtonItem_TeaInfo_DeletePic.Id = 3;
			this.barButtonItem_TeaInfo_DeletePic.Name = "barButtonItem_TeaInfo_DeletePic";
			this.barButtonItem_TeaInfo_DeletePic.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_TeaInfo_DeletePic_ItemClick);
			// 
			// barButtonItem1
			// 
			this.barButtonItem1.Caption = "加载图片";
			this.barButtonItem1.Id = 0;
			this.barButtonItem1.Name = "barButtonItem1";
			// 
			// helpProvider_Help
			// 
			this.helpProvider_Help.HelpNamespace = "";
			// 
			// TeacherBaseInfo
			// 
			this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.Appearance.Options.UseBackColor = true;
			this.Controls.Add(this.xtraTabControl_TeaBaseInfo);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlTop);
			this.Name = "TeacherBaseInfo";
			this.Size = new System.Drawing.Size(772, 540);
			this.Load += new System.EventHandler(this.TeacherBaseInfo_Load);
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_TeaBaseInfo)).EndInit();
			this.xtraTabControl_TeaBaseInfo.ResumeLayout(false);
			this.xtraTabPage_TeaBaseInfoMgmt.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
			this.splitContainerControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.textEdit_Number.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_Name.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Class.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Grade.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
			this.groupControl3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tTechnicalPost.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tLevel.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tJoinDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tEnterTime.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tDuty.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tDept.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_tID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
			this.groupControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureEdit_LoadImageData.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tAddr.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tRecord.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tSex.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tWorkPhone.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tPhone.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tHomePhone.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_UserPwd.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tNumber.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Privilege.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tMarrige.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region 页面加载显示
		private void TeacherBaseInfo_Load(object sender, System.EventArgs e)
		{
			LoadDropDownList();
			loadPage(new TeacherBaseSystem().SearchTcBaseInfoByCondition("","","",""));

			if ( Thread.CurrentPrincipal.Identity.Name.ToLower() == "admin" )
			{
//				simpleButton_ModifyButton.Enabled = false;
//				simpleButton_NewFile.Enabled = false;
//				simpleButton_SaveButton.Enabled = false;
//				simpleButton_WriteButton.Enabled = false;

				notePanel_TeaBaseInfoTitle.Text = " 系统管理员欢迎您进入教师基本信息检索";
			}

			if ( Thread.CurrentPrincipal.IsInRole("班主任") || Thread.CurrentPrincipal.IsInRole("财务")
				|| Thread.CurrentPrincipal.IsInRole("保健") || Thread.CurrentPrincipal.IsInRole("一般") )
			{
				SetNormalTeacherAuthority();
			}

			if ( Thread.CurrentPrincipal.Identity.Name.ToLower() != "admin" )
				notePanel_TeaBaseInfoTitle.Text = new HealthManagementSystem().GetTeaName(Thread.CurrentPrincipal.Identity.Name) 
					+ "教师欢迎您进入教师基本信息检索";

			if ( Thread.CurrentPrincipal.IsInRole("园长") )
				notePanel_TeaBaseInfoTitle.Text = new HealthManagementSystem().GetTeaName(Thread.CurrentPrincipal.Identity.Name)
					+ "园长欢迎您进入教师基本信息检索";
		}
		#endregion

		#region 控件绑定
		private void loadPage(DataSet comingDs)
		{
			TextDataUnBindings();
			TextDataClear();			
			
			DataSet ds = comingDs;
			
			if ( ds.Tables[0].Rows.Count > 0 )
			{

				dataNavigator1.DataSource = ds.Tables[0];
				gridControl1.DataSource = ds.Tables[0];

				if ( Thread.CurrentPrincipal.Identity.Name.ToLower() != "admin" && !Thread.CurrentPrincipal.IsInRole("园长") )
				{
					foreach(DataRow matchRow in ds.Tables[0].Rows)
					{
						if ( !matchRow["T_Number"].ToString().Equals(Thread.CurrentPrincipal.Identity.Name) )
							matchRow.Delete();
					}
				}

//				gridView1.MoveFirst();

				textEdit_tID.DataBindings.Add("EditValue",ds.Tables[0],"T_ID");
				tName.DataBindings.Add("Text",ds.Tables[0],"T_Name");
				tNumber.DataBindings.Add("Text",ds.Tables[0],"T_Number");
				tRecord.DataBindings.Add("Text",ds.Tables[0],"T_Career");
				tHomePhone.DataBindings.Add("Text",ds.Tables[0],"T_Home_Tel");
				tPhone.DataBindings.Add("Text",ds.Tables[0],"T_Phone");
				tSex.DataBindings.Add("Text",ds.Tables[0],"T_Sex");
				tWorkPhone.DataBindings.Add("Text",ds.Tables[0],"T_Work_Tel");
				tMarrige.DataBindings.Add("Text",ds.Tables[0],"T_Merrige");
				tAddr.DataBindings.Add("Text",ds.Tables[0],"T_Addr");
				tDept.DataBindings.Add("Text",ds.Tables[0],"T_Depart");
				tLevel.DataBindings.Add("Text",ds.Tables[0],"T_Level");
				tDuty.DataBindings.Add("Text",ds.Tables[0],"T_Duty");
				tEnterTime.DataBindings.Add("EditValue",ds.Tables[0],"T_Enter_Time");
				tTechnicalPost.DataBindings.Add("Text",ds.Tables[0],"T_Technical_Post");
				tJoinDate.DataBindings.Add("EditValue",ds.Tables[0],"T_Work_Time");	
				pictureEdit_LoadImageData.DataBindings.Add("EditValue",ds.Tables[0],"T_Image");

				if ( gridView1.RowCount > 0 )
				{
					if(new UserSystem().GetUserRole(tNumber.Text)!=string.Empty)
					{
						comboBoxEdit_Privilege.SelectedItem = new UserSystem().GetUserRole(tNumber.Text);
					}
					
					simpleButton_ModifyButton.Enabled = true;
					
				}
				else
					simpleButton_ModifyButton.Enabled = false;
			}
			else
				gridControl1.DataSource = null;

			if ( Thread.CurrentPrincipal.IsInRole("班主任") || Thread.CurrentPrincipal.IsInRole("财务")
				|| Thread.CurrentPrincipal.IsInRole("保健") || Thread.CurrentPrincipal.IsInRole("一般") )
			{
				SetNormalTeacherAuthority();
			}
		}
		#endregion

		#region 为部门和所属部门下拉菜单赋值
		private void LoadDropDownList()
		{
			comboBoxEdit_Grade.Properties.Items.Clear();	
			tDept.Properties.Items.Clear();
			comboBoxEdit_Grade.Properties.Items.Add("全部");

			DataSet gradeInfo = new GradeSystem().GetGradeInfoList(1);
			
			if(gradeInfo.Tables[0].Rows.Count>0)
			{
				foreach(DataRow grade in gradeInfo.Tables[0].Rows)
				{
					comboBoxEdit_Grade.Properties.Items.Add(grade["info_gradeName"].ToString());
					tDept.Properties.Items.Add(grade["info_gradeName"].ToString());
				}
			}

		}
		#endregion

		#region 根据所属部门改变，绑定岗位信息
		private void tDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
			tDuty.Properties.Items.Clear();
			
			DataSet gradeInfo = new GradeSystem().GetGradeInfoList(1);
			DataSet classInfo = new ClassSystem().GetClassInfoList();
			if ( classInfo.Tables[0].Rows.Count > 0 )
			{				
				if ( tDept.SelectedIndex != -1 )
				{
					foreach ( DataRow grade in gradeInfo.Tables[0].Rows )
					{
						if ( grade["info_gradeName"].ToString().Equals(tDept.SelectedItem.ToString()) )
						{
							foreach (  DataRow classes in classInfo.Tables[0].Rows )
							{
								 if ( Convert.ToInt32(classes["info_gradeNumber"]) == Convert.ToInt32(grade["info_gradeNumber"]) )
									tDuty.Properties.Items.AddRange(new object[]{ classes["info_className"].ToString() });						
							}
						}
					}
					
					if ( tDuty.Properties.Items.Count == 0 )
						tDuty.Text = "班级不存在";
					else
						tDuty.SelectedItem = tDuty.Properties.Items[0].ToString();
				}
				else
					tDuty.SelectedIndex = -1;
			}			
		}
		#endregion

		#region 处理姓名输入事件
		private void textEdit_Name_EditValueChanged(object sender, System.EventArgs e)
		{
			loadPage(new TeacherBaseSystem().SearchTcBaseInfoByCondition(comboBoxEdit_Grade.SelectedItem.ToString().Replace(" ",""),
				comboBoxEdit_Class.SelectedItem.ToString().Replace(" ",""),textEdit_Name.Text.Replace(" ",""),textEdit_Number.Text.Replace(" ","")));
			simpleButton_SaveButton.Enabled = false;
		}
		#endregion

		#region 处理工号输入事件
		private void textEdit_Number_EditValueChanged(object sender, System.EventArgs e)
		{
			loadPage(new TeacherBaseSystem().SearchTcBaseInfoByCondition(comboBoxEdit_Grade.SelectedItem.ToString().Replace(" ",""),
				comboBoxEdit_Class.SelectedItem.ToString().Replace(" ",""),textEdit_Name.Text.Replace(" ",""),textEdit_Number.Text.Replace(" ","")));
			simpleButton_SaveButton.Enabled = false;
		}
		#endregion

		#region 处理部门选择改变事件
		private void comboBoxEdit_Grade_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			comboBoxEdit_Class.Properties.Items.Clear();
//			comboBoxEdit_Class.Text = "";
			comboBoxEdit_Class.Properties.Items.Add("全部");
			comboBoxEdit_Class.SelectedItem = "全部";
			DataSet gradeInfo = new GradeSystem().GetGradeInfoList(1);
			DataSet classInfo = new ClassSystem().GetClassInfoList();
			if(classInfo.Tables[0].Rows.Count>0)
			{
				if(comboBoxEdit_Grade.SelectedItem.ToString().Equals("全部"))
				{
					foreach(DataRow classes in classInfo.Tables[0].Rows)
					{
						comboBoxEdit_Class.Properties.Items.Add(classes["info_className"].ToString());
					}
				}
				else
				{
					foreach(DataRow grade in gradeInfo.Tables[0].Rows)
					{
						if(grade["info_gradeName"].ToString().Equals(comboBoxEdit_Grade.SelectedItem.ToString()))
						{
							foreach(DataRow classes in classInfo.Tables[0].Rows)
							{
								if(Convert.ToInt32(classes["info_gradeNumber"]) == Convert.ToInt32(grade["info_gradeNumber"]))
								{
									comboBoxEdit_Class.Properties.Items.Add(classes["info_className"].ToString());
								}
								
							}
						}
					}			
				}					
			}

			loadPage(new TeacherBaseSystem().SearchTcBaseInfoByCondition(comboBoxEdit_Grade.SelectedItem.ToString().Replace(" ",""),
				comboBoxEdit_Class.SelectedItem.ToString().Replace(" ",""),textEdit_Name.Text.Replace(" ",""),textEdit_Number.Text.Replace(" ","")));
			simpleButton_SaveButton.Enabled = false;
		}
		#endregion

		#region 处理岗位选择改变事件
		private void comboBoxEdit_Class_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			loadPage(new TeacherBaseSystem().SearchTcBaseInfoByCondition(comboBoxEdit_Grade.SelectedItem.ToString().Replace(" ",""),
				comboBoxEdit_Class.SelectedItem.ToString().Replace(" ",""),textEdit_Name.Text.Replace(" ",""),textEdit_Number.Text.Replace(" ","")));
			simpleButton_SaveButton.Enabled = false;
		}
		#endregion

		#region 控件清空 
		private void TextDataClear()
		{
			tName.Text = string.Empty;
			tNumber.Text = string.Empty;
			tRecord.SelectedIndex = 1;
			tHomePhone.Text = string.Empty;
			tPhone.Text = string.Empty;
			tSex.SelectedIndex = 1;
			tWorkPhone.Text = string.Empty;
			tMarrige.SelectedIndex = 1;
			tAddr.Text = string.Empty;
			tDept.SelectedIndex = -1;
			tLevel.SelectedIndex = 1;
			tDuty.SelectedIndex = -1;
			tEnterTime.Text = string.Empty;
			tTechnicalPost.SelectedIndex = 1;
			tJoinDate.Text = string.Empty;
			textEdit_tID.EditValue = string.Empty;
			pictureEdit_LoadImageData.EditValue = null;
		}
		#endregion

		#region 取消控件绑定
		private void TextDataUnBindings()
		{
			tName.DataBindings.Clear();
			tNumber.DataBindings.Clear();
			tRecord.DataBindings.Clear();
			tHomePhone.DataBindings.Clear();
			tPhone.DataBindings.Clear();
			tSex.DataBindings.Clear();
			tWorkPhone.DataBindings.Clear();
			tMarrige.DataBindings.Clear();
			tAddr.DataBindings.Clear();
			tDept.DataBindings.Clear();
			tLevel.DataBindings.Clear();
			tDuty.DataBindings.Clear();
			tEnterTime.DataBindings.Clear();
			tTechnicalPost.DataBindings.Clear();
			tJoinDate.DataBindings.Clear();
			textEdit_tID.DataBindings.Clear();
			pictureEdit_LoadImageData.DataBindings.Clear();

			comboBoxEdit_Privilege.SelectedIndex = 0;
		}
		#endregion

		#region 新建卡按钮
		private void simpleButton_NewFile_Click(object sender, System.EventArgs e)
		{
            dataNavigator1.Buttons.DoClick(dataNavigator1.Buttons.Append);
			//dataNavigator1.Buttons.Append.DoClick();
			TextDataClear();
			tDept.Text = new GradeSystem().GetGradeInfoList(1).Tables[0].Rows[0]["info_gradeName"].ToString();
//			tDuty.Text = new ClassSystem().GetClassInfo(1,1).Tables[0].Rows[0]["info_className"].ToString();
			tJoinDate.DateTime = DateTime.Now;
			tEnterTime.DateTime = DateTime.Now;
			simpleButton_SaveButton.Enabled = true;
			simpleButton_ModifyButton.Enabled = false;
			comboBoxEdit_Privilege.Enabled = true;
			comboBoxEdit_Privilege.SelectedIndex = 1;
			
		}
		#endregion

		#region 保存卡按钮
		private void simpleButton_SaveButton_Click(object sender, System.EventArgs e)
		{		
			tID = textEdit_tID.EditValue.ToString();
			TeacherBase tcBase = new TeacherBase();
			TeacherBaseSystem tcBaseSystem = new TeacherBaseSystem();
			DialogResult messageResult = MessageBox.Show("是否确认保存这些数据？","消息提示框！",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult == DialogResult.Yes )
			{
				try
				{
					bool doDataInsertLoopOnce = true;
					TeacherCheckInfo teacherCheckInfo = new TeacherCheckInfo();
					while(doDataInsertLoopOnce)
					{
						tcBase.TCareer = tRecord.SelectedItem.ToString().Replace(" ","");
						tcBase.TMerrige = tMarrige.SelectedItem.ToString().Replace(" ","");						
						tcBase.TDepart = tDept.SelectedItem.ToString().Replace(" ","");
						tcBase.TLevel = tLevel.SelectedItem.ToString().Replace(" ","");
						tcBase.TDuty = tDuty.SelectedItem.ToString().Replace(" ","");
						tcBase.TTechnicalPost = tTechnicalPost.SelectedItem.ToString().Replace(" ","");
						if ( !tID.Equals("") )
							tcBase.TID = tID;
						else
							tcBase.TID = Guid.NewGuid().ToString();

						if(!teacherCheckInfo.isValidTcName(tName.Text.Replace(" ","")))
						{
							MessageBox.Show("教师姓名请正确填写！");
							break;
						}
						else{tcBase.TName = tName.Text.Replace(" ","");}

                        //获取顺序工号
						if ( tNumber.Text.Equals("") )
						{
							tcBase.TNumber = teacherCheckInfo.getSerialTcNumber();

							if ( tcBase.TNumber.Equals("-1") )
							{
								MessageBox.Show("已超出系统所允许的最大教师数量！");
								break;
							}

						}
						else
						{
							if ( !teacherCheckInfo.isValidTcNumber(tNumber.Text.Replace(" ","")))
							{
								MessageBox.Show("请确保输入的工号是有效工号！");
								break;
							}
							else
							{
								if ( !teacherCheckInfo.hasSameNumber( tNumber.Text.Replace(" ",""),
									tcBase.TID ) )
								{
									MessageBox.Show("您所选择的教师工号已经存在，请更换！");
									break;
								}
							}
							tcBase.TNumber = tNumber.Text.Replace(" ","");
						}

						if(!teacherCheckInfo.isValidTcHomePhone(tHomePhone.Text.Replace(" ","")))
						{
							tcBase.THomeTel = "未填写";
							MessageBox.Show("教师家庭电话填写不正确！");
							break;
						}
						else
							tcBase.THomeTel = tHomePhone.Text.Replace(" ","");
						
						if(!teacherCheckInfo.isValidTcTime(Convert.ToDateTime(tEnterTime.Text.Replace(" ","")),Convert.ToDateTime(tJoinDate.Text.Replace(" ",""))))
						{
							MessageBox.Show("时间填写不当，请重新输入！");
							break;
						}
						else
						{
							tcBase.TWorkTime = Convert.ToDateTime(tEnterTime.Text.Replace(" ",""));
							tcBase.TEnterTime = Convert.ToDateTime(tJoinDate.Text.Replace(" ",""));
						}
						if(!teacherCheckInfo.isValidTcSex(tSex.Text.Replace(" ","")))
						{
							MessageBox.Show("教师性别不正确！");
							break;
						}
						else
							tcBase.TSex = tSex.Text.Replace(" ","");
						if(!teacherCheckInfo.isValidTcWorkPhone(tWorkPhone.Text.Replace(" ","")))
						{
							tcBase.TWorkTel = "未填写";
							MessageBox.Show("教师办公电话填写不正确，请正确填写！");
							break;
						}
						else
							tcBase.TWorkTel = tWorkPhone.Text.Replace(" ","");

						if(!teacherCheckInfo.isValidTcPhone(tPhone.Text.Replace(" ","")))
						{
							tcBase.TPhone = "未填写";
							MessageBox.Show("教师手机号码不正确！");
							break;
							
						}
						else
							tcBase.TPhone = tPhone.Text.Replace(" ","");


						tcBase.TAddr = tAddr.Text.Replace(" ","");

						if ( pictureEdit_LoadImageData.Image == null )
							imageDataBuffer = null;
						else
						{
							imageMSReader = new MemoryStream();
							pictureEdit_LoadImageData.Image.Save(imageMSReader,ImageFormat.Jpeg);
							imageDataBuffer = imageMSReader.ToArray();
						}
						tcBase.ImageData = imageDataBuffer;
						
						tcBaseSystem.InsertTcBaseInfo(tcBase);

						new UserSystem().CreateUserAccount(tcBase.TNumber,
							textEdit_UserPwd.Text);

						new UserSystem().AddUserRole(tcBase.TNumber,
							comboBoxEdit_Privilege.SelectedItem.ToString());

						MessageBox.Show("保存完毕！");
						doDataInsertLoopOnce = false;

                        dataNavigator1.Buttons.DoClick(dataNavigator1.Buttons.CancelEdit);
						//dataNavigator1.Buttons.CancelEdit.DoClick();
						//刷新绑定信息
						TextDataUnBindings();
						loadPage(new TeacherBaseSystem().SearchTcBaseInfoByCondition("","","",""));

						simpleButton_SaveButton.Enabled = false;
						simpleButton_ModifyButton.Enabled = true;
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}
		#endregion

		#region 修改卡按钮
		private void simpleButton_ModifyButton_Click(object sender, System.EventArgs e)
		{
			tID = textEdit_tID.EditValue.ToString();
			TeacherBase tcBase = new TeacherBase();
			TeacherBaseSystem tcBaseSystem = new TeacherBaseSystem();
			DialogResult messageResult = MessageBox.Show("是否确认保存修改内容？","消息提示框！",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult == DialogResult.Yes )
			{
				try
				{
					bool doDataInsertLoopOnce = true;
					TeacherCheckInfo teacherCheckInfo = new TeacherCheckInfo();
					while(doDataInsertLoopOnce)
					{
						tcBase.TCareer = tRecord.SelectedItem.ToString().Replace(" ","");
						tcBase.TMerrige = tMarrige.SelectedItem.ToString().Replace(" ","");
						tcBase.TAddr = tAddr.Text.Replace(" ","");
						tcBase.TDepart = tDept.SelectedItem.ToString().Replace(" ","");
						tcBase.TLevel = tLevel.SelectedItem.ToString().Replace(" ","");
						tcBase.TDuty = tDuty.SelectedItem.ToString().Replace(" ","");
						tcBase.TTechnicalPost = tTechnicalPost.SelectedItem.ToString().Replace(" ","");
						tcBase.TID = tID;

						if(!teacherCheckInfo.isValidTcName(tName.Text.Replace(" ","")))
						{
							MessageBox.Show("教师姓名请正确填写！");
							break;
						}
						else
							tcBase.TName = tName.Text.Replace(" ","");

						if ( gridView1.RowCount > 0 )
						{
							if ( teacherCheckInfo.hasCard(tID,tNumber.Text))
							{
								MessageBox.Show("该教师已经发过卡，修改工号会存在潜在风险，修改失败！");
								break;
							}
							else
							{
								//获取顺序工号
								if ( tNumber.Text.Equals("") )
									tcBase.TNumber = teacherCheckInfo.getSerialTcNumber();
								else
								{
							
									if ( !teacherCheckInfo.isValidTcNumber(tNumber.Text.Replace(" ","")))
									{
										MessageBox.Show("请确保输入的工号是有效工号！");
										break;
									}
									else
									{
										if ( !teacherCheckInfo.hasSameNumber( tNumber.Text.Replace(" ",""),
											tcBase.TID ) )
										{
											MessageBox.Show("您所选择的教师工号已经存在，请更换！");
											break;
										}
									}
									tcBase.TNumber = tNumber.Text.Replace(" ","");
								}
							}
						}
						else
							MessageBox.Show("教师记录不存在还无法进行修改！");

						if(!teacherCheckInfo.isValidTcHomePhone(tHomePhone.Text.Replace(" ","")))
						{
							MessageBox.Show("教师家庭电话填写不正确！");
							break;
						}
						else
							tcBase.THomeTel = tHomePhone.Text.Replace(" ","");
						
						if(!teacherCheckInfo.isValidTcTime(tEnterTime.DateTime.Date,tJoinDate.DateTime.Date))
						{
							MessageBox.Show("时间填写不当，请重新输入！");
							break;
						}
						else
						{
							tcBase.TEnterTime = Convert.ToDateTime(tEnterTime.Text.Replace(" ",""));
							tcBase.TWorkTime  = Convert.ToDateTime(tJoinDate.Text.Replace(" ",""));}
						if(!teacherCheckInfo.isValidTcSex(tSex.Text.Replace(" ","")))
						{
							MessageBox.Show("教师性别不正确！");
							break;
						}
						else
							tcBase.TSex = tSex.Text.Replace(" ","");

						if(!teacherCheckInfo.isValidTcWorkPhone(tWorkPhone.Text.Replace(" ","")))
						{
							MessageBox.Show("教师办公电话填写不正确，请正确填写！");
							break;
						}
						else
							tcBase.TWorkTel = tWorkPhone.Text.Replace(" ","");

						if(!teacherCheckInfo.isValidTcPhone(tPhone.Text.Replace(" ","")))
						{
							MessageBox.Show("教师手机号码不正确！");
							break;
						}
						else
							tcBase.TPhone = tPhone.Text.Replace(" ","");
						
						if ( pictureEdit_LoadImageData.Image == null )
							imageDataBuffer = null;
						else
						{
							imageMSReader = new MemoryStream();
							pictureEdit_LoadImageData.Image.Save(imageMSReader,ImageFormat.Jpeg);
							imageDataBuffer = imageMSReader.ToArray();
						}
						tcBase.ImageData = imageDataBuffer;

						tcBaseSystem.UpdateTcBaseInfo(tcBase);
			

						if(!gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["T_Number"].ToString().Equals(tcBase.TNumber))
						{
							new UserSystem().DeleteUserAccount(gridView1.GetDataRow(gridView1.GetSelectedRows()[0])
								["T_Number"].ToString());

							new UserSystem().CreateUserAccount(tcBase.TNumber,textEdit_UserPwd.Text);
						}

						int rtnValue = new UserSystem().UpdateUserRole(tcBase.TNumber,comboBoxEdit_Privilege.SelectedItem.ToString());

						if (rtnValue == -1) MessageBox.Show("如果您执行此修改，系统将不存在最高权限，这是不允许的，修改失败！");
						else if (rtnValue == 0)
						{
							new UserSystem().DeleteUserAccount(tcBase.TNumber);
							new UserSystem().CreateUserAccount(tcBase.TNumber,textEdit_UserPwd.Text);
							new UserSystem().AddUserRole(tcBase.TNumber,comboBoxEdit_Privilege.SelectedItem.ToString());
							MessageBox.Show("修改完毕！");
						}
						else MessageBox.Show("修改完毕！");

						doDataInsertLoopOnce = false;

						//刷新绑定信息
						TextDataUnBindings();
						TextDataClear();
//						loadPage(new TeacherBaseSystem().SearchTcBaseInfoByCondition("","","",""));
						loadPage(new TeacherBaseSystem().SearchTcBaseInfoByCondition(comboBoxEdit_Grade.SelectedItem.ToString().Replace(" ",""),
							comboBoxEdit_Class.SelectedItem.ToString().Replace(" ",""),textEdit_Name.Text.Replace(" ",""),textEdit_Number.Text.Replace(" ","")));

					}
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}
		#endregion

//		#region 删除卡按钮
//		private void simpleButton_DeleteButton_Click(object sender, System.EventArgs e)
//		{
//			tID = textEdit_tID.EditValue.ToString();
//			TeacherBaseSystem tcBaseSystem = new TeacherBaseSystem();
//			DialogResult messageResult = MessageBox.Show("是否确认删除此条记录？","消息提示框！",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
//			if ( messageResult == DialogResult.Yes )
//			{
//				try
//				{
//					tcBaseSystem.DeleteTcBaseInfo(tID);
//
//					new UserSystem().DeleteUserAccount(tNumber.Text);
//
//					MessageBox.Show("删除完毕！");				
//
//					//刷新绑定信息
//					TextDataUnBindings();
//					TextDataClear();
//					loadPage(new TeacherBaseSystem().SearchTcBaseInfoByCondition("","","",""));
//				}
//				catch(Exception ex)
//				{
//					MessageBox.Show(ex.Message);
//				}
//			}
//		}
//		#endregion

		#region 打印卡按钮
		private void simpleButton_WriteButton_Click(object sender, System.EventArgs e)
		{
			string savePath;
			saveFileDialog_Report.Filter = "Excel文件|*.xls";

			if ( saveFileDialog_Report.ShowDialog() != DialogResult.OK )
				return;

			savePath = saveFileDialog_Report.FileName;

			MessageBox.Show("正在生成报表，按确定之后请稍候！");
			SetPrintMemeber();
			teaBaseInfoPrintSystem.TeaBaseInfoPrint(savePath);
			MessageBox.Show("报表生成完毕！");
		}
		#endregion				

		#region 帮助
		private void simpleButton_Help_Click(object sender, System.EventArgs e)
		{
		
		}
		#endregion

		#region 刷新
		private void barButtonItem_TeaInfo_Refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			LoadDropDownList();
			loadPage(new TeacherBaseSystem().SearchTcBaseInfoByCondition(comboBoxEdit_Grade.SelectedItem.ToString().Replace(" ",""),
				comboBoxEdit_Class.SelectedItem.ToString().Replace(" ",""),textEdit_Name.Text.Replace(" ",""),textEdit_Number.Text.Replace(" ","")));
			simpleButton_SaveButton.Enabled = false;
			simpleButton_ModifyButton.Enabled = true;
		}
		#endregion

		#region 载入图片
		private void barButtonItem_TeaInfo_LoadPic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			openFileDialog_ChooseImg.Filter = "图像文件(*.bmp;*.jpg;*.jpeg;*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
			if(openFileDialog_ChooseImg.ShowDialog() == DialogResult.OK)
			{
				try
				{
					
					MemoryStream imageMSReader = new MemoryStream();
					Bitmap imageData = new Bitmap(openFileDialog_ChooseImg.FileName);
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

		#region 删除图片
		private void barButtonItem_TeaInfo_DeletePic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			pictureEdit_LoadImageData.EditValue = null;
			imageDataBuffer = null;
		}
		#endregion

		#region 打印成员
		private void SetPrintMemeber()
		{
			teaBaseInfoPrintSystem.SetName(tName.Text);
			teaBaseInfoPrintSystem.SetGender(tSex.Text);
			teaBaseInfoPrintSystem.SetDegree(tRecord.Text);
			teaBaseInfoPrintSystem.SetHomeTel(tHomePhone.Text);
			teaBaseInfoPrintSystem.SetPhone(tPhone.Text);
			teaBaseInfoPrintSystem.SetWorkTel(tWorkPhone.Text);
			teaBaseInfoPrintSystem.SetMarriage(tMarrige.Text);
			teaBaseInfoPrintSystem.SetAddr(tAddr.Text);
			teaBaseInfoPrintSystem.SetDept(tDept.Text);
			teaBaseInfoPrintSystem.SetDuty(tDuty.Text);
			teaBaseInfoPrintSystem.SetJobEva(tTechnicalPost.Text);
			teaBaseInfoPrintSystem.SetLevel(tLevel.Text);
			teaBaseInfoPrintSystem.SetWorkDate(tJoinDate.DateTime.Date);
			teaBaseInfoPrintSystem.SetEnterDate(tEnterTime.DateTime.Date);
			if ( pictureEdit_LoadImageData.EditValue == null || pictureEdit_LoadImageData.EditValue is DBNull)
				teaBaseInfoPrintSystem.NeedPrintPicture = false;
			else
				teaBaseInfoPrintSystem.NeedPrintPicture = true;

			teaBaseInfoPrintSystem.SetPicture(pictureEdit_LoadImageData.Image);

		}	
		#endregion

		#region 显示所处角色
		private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			if(gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["T_Number"].ToString()==string.Empty)
			{
				return;
			}

			if(new UserSystem().GetUserRole(gridView1.GetDataRow(gridView1.GetSelectedRows()[0])
				["T_Number"].ToString()) != string.Empty)
			{
				comboBoxEdit_Privilege.SelectedItem = new UserSystem().GetUserRole(gridView1.GetDataRow(gridView1.GetSelectedRows()[0])
					["T_Number"].ToString());
			}
			else
			{
				comboBoxEdit_Privilege.SelectedItem = "一般";
			}

		}
		#endregion

		#region 不允许修改园长的权限
		private void comboBoxEdit_Privilege_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( Thread.CurrentPrincipal.Identity.Name.ToLower() != "shchuangzhi" )
			{
				if ( comboBoxEdit_Privilege.SelectedItem.ToString().Equals("园长") )
					comboBoxEdit_Privilege.Enabled = false;
				else
					comboBoxEdit_Privilege.Enabled = true;
			}
		}
		#endregion 

		private void SetNormalTeacherAuthority()
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

			simpleButton_NewFile.Enabled = false;
			tRecord.Enabled = false;
			tTechnicalPost.Enabled = false;
			tNumber.Enabled = false;
			tJoinDate.Enabled = false;
			tEnterTime.Enabled = false;
			tLevel.Enabled = false;
			comboBoxEdit_Privilege.Enabled = false;
			tDept.Enabled = false;
			tDuty.Enabled = false;
			tName.Enabled = false;
			tSex.Enabled = false;
		}
	}
}

