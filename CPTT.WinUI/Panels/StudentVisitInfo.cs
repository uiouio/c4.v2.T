using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CPTT.BusinessFacade;
using System.IO;
using System.Threading;

namespace CPTT.WinUI.Panels
{
	/// <summary>
	/// Summary description for StudentVisitInfo.
	/// </summary>
	public class StudentVisitInfo : DevExpress.XtraEditors.XtraUserControl
	{
		private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
		private DevExpress.Utils.Frames.NotePanel notePanel_WelcomePanel;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl_Mgmt;
		private DevExpress.XtraEditors.GroupControl groupControl_MgmtClass;
		private DevExpress.XtraEditors.DataNavigator dataNavigator_Mgmt;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_MgmtClass;
		private DevExpress.Utils.Frames.NotePanel notePanel_MgmtClass;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_MgmtGrade;
		private DevExpress.Utils.Frames.NotePanel notePanel_MgmtGrade;
		private DevExpress.Utils.Frames.NotePanel notePanel_MgmtQuery;
		private DevExpress.XtraEditors.SimpleButton simpleButton_MgmtSave;
		private DevExpress.XtraEditors.SimpleButton simpleButton_Mgmt2DaysAbs;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage_InfoMgmt;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage_InfoQuery;
		private DevExpress.Utils.Frames.NotePanel notePanel_MgmtDate;
		private DevExpress.XtraEditors.DateEdit dateEdit_MgmtDate;
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private DevExpress.XtraEditors.GroupControl groupControl_MgmtParentLink;
		private DevExpress.XtraEditors.TextEdit textEdit_MgmtMOWorkingAddr;
		private DevExpress.Utils.Frames.NotePanel notePanel_MgmtMOWorkingAddr;
		private DevExpress.XtraEditors.TextEdit textEdit_MgmtMOPhone;
		private DevExpress.XtraEditors.TextEdit textEdit_MgmtMOName;
		private DevExpress.Utils.Frames.NotePanel notePanel_MgmtMOPhone;
		private DevExpress.Utils.Frames.NotePanel notePanel_MgmtMOName;
		private DevExpress.XtraEditors.TextEdit textEdit_MgmtFAWorkingAddr;
		private DevExpress.Utils.Frames.NotePanel notePanel_MgmtFAWorkingAddr;
		private DevExpress.XtraEditors.TextEdit textEdit_MgmtFAPhone;
		private DevExpress.Utils.Frames.NotePanel notePanel_MgmtFAPhone;
		private DevExpress.XtraEditors.TextEdit textEdit_MgmtFAName;
		private DevExpress.Utils.Frames.NotePanel notePanel_MgmtFAName;
		private DevExpress.Utils.Frames.NotePanel notePanel_MgmtFamilyAddr;
		private DevExpress.XtraEditors.TextEdit textEdit_MgmtFamilyAddr;
		private DevExpress.XtraEditors.GroupControl groupControl_VisitInfoInput;
		private DevExpress.Utils.Frames.NotePanel notePanel_MgmtVisState;
		private DevExpress.Utils.Frames.NotePanel notePanel_MgmtAbsReason;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_MgmtVisState;
		private DevExpress.Utils.Frames.NotePanel notePanel_MgmtVisDate;
		private DevExpress.XtraEditors.DateEdit dateEdit_MgmtVisDate;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_MgmtAbsReason;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.GridControl gridControl_Mgmt;
		private DevExpress.XtraEditors.MemoEdit memoEdit_MgmtAbsRemark;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
		private DevExpress.Utils.Frames.NotePanel notePanel_VisitInfoPanel;
		private DevExpress.XtraEditors.GroupControl groupControl_VisitInfoClass;
		private DevExpress.Utils.Frames.NotePanel notePanel_VisitInfoQuery;
		private DevExpress.Utils.Frames.NotePanel notePanel_VisitInfoClass;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_VisitInfoGrade;
		private DevExpress.Utils.Frames.NotePanel notePanel_VisitInfoGrade;
		private DevExpress.Utils.Frames.NotePanel notePanel_VisistInfoName;
		private DevExpress.Utils.Frames.NotePanel notePanel_VisitInfoNumber;
		private DevExpress.Utils.Frames.NotePanel notePanel_VisitInfoBegDate;
		private DevExpress.Utils.Frames.NotePanel notePanel_VisitInfoEndDate;
		private DevExpress.XtraEditors.DateEdit dateEdit_VisitInfoBegDate;
		private DevExpress.XtraEditors.DateEdit dateEdit_VisitInfoEndDate;
		private DevExpress.XtraEditors.TextEdit textEdit_VisitInfoName;
		private DevExpress.XtraEditors.TextEdit textEdit_VisitInfoNumber;
		private DevExpress.XtraEditors.PanelControl panelControl2;
		private DevExpress.XtraEditors.SimpleButton simpleButton_VisitInfoSearch;
		private DevExpress.XtraEditors.SimpleButton simpleButton_VisitInfoModify;
		private DevExpress.XtraGrid.GridControl gridControl_VisitInfo;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraEditors.MemoEdit memoEdit_VisInfoAbsRemark;
		private DevExpress.Utils.Frames.NotePanel notePanel_VisInfoVisMode;
		private DevExpress.Utils.Frames.NotePanel notePanel_VisInfoAbsReason;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_VisInfoVisMode;
		private DevExpress.Utils.Frames.NotePanel notePanel_VisInfoVisDate;
		private DevExpress.XtraEditors.DateEdit dateEdit_VisInfoVisDate;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_VisInfoAbsReason;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_VisitInfoClass;
		private DevExpress.XtraEditors.GroupControl groupControl_VisitInfo;
		private GetStuInfoByCondition getStuInfoByCondition;
		private StuVisitInfoSystem stuVisitInfoSystem;
		private string getMgmtGradeFromCombo;
		private string getMgmtClassFromCombo;
		private string getVisInfoGradeFromCombo;
		private string getVisInfoClassFromCombo;
		private string getSourceReason;
		private string getSourceMode;
		private DateTime getSourceDate;
		private string getSourceSign;
		private string getSourceRemark;
		private DataSet dsAbsDetailInfo = null;
		private DevExpress.XtraEditors.SimpleButton simpleButton_VisitInfoDelete;
		private DevExpress.XtraEditors.SimpleButton simpleButton_VisitInfoBack;
		private DevExpress.XtraEditors.SimpleButton simpleButton_VisitInfoPrint;
		private StuVisitInfoPrintSystem stuVisitInfoPrintSystem;
		private System.Windows.Forms.SaveFileDialog saveFileDialog_Report;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private HealthManagementSystem healthManagementSystem;
		private System.Windows.Forms.HelpProvider helpProvider_StuVisitInfo;
		private RolesSystem rolesSystem;

		public StudentVisitInfo()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call
			getStuInfoByCondition = new GetStuInfoByCondition();
			stuVisitInfoSystem = new StuVisitInfoSystem();
			stuVisitInfoPrintSystem = new StuVisitInfoPrintSystem();
			healthManagementSystem = new HealthManagementSystem();	
			rolesSystem = new RolesSystem();	
			
			#region  帮助
			helpProvider_StuVisitInfo.HelpNamespace = System.IO.Path.GetDirectoryName(Application.ExecutablePath)
				+ CPTT.SystemFramework.Util.HELP_FILE_NAME;

			this.helpProvider_StuVisitInfo.SetHelpKeyword(this.xtraTabPage_InfoMgmt,"幼儿家访信息管理");
			this.helpProvider_StuVisitInfo.SetHelpNavigator(this.xtraTabPage_InfoMgmt, System.Windows.Forms.HelpNavigator.KeywordIndex);
			this.helpProvider_StuVisitInfo.SetHelpString(this.xtraTabPage_InfoMgmt, "");
			this.helpProvider_StuVisitInfo.SetShowHelp(this.xtraTabPage_InfoMgmt, true);

			this.helpProvider_StuVisitInfo.SetHelpKeyword(this.xtraTabPage_InfoQuery,"幼儿家访信息检索");
			this.helpProvider_StuVisitInfo.SetHelpNavigator(this.xtraTabPage_InfoQuery, System.Windows.Forms.HelpNavigator.KeywordIndex);
			this.helpProvider_StuVisitInfo.SetHelpString(this.xtraTabPage_InfoQuery, "");
			this.helpProvider_StuVisitInfo.SetShowHelp(this.xtraTabPage_InfoQuery, true);
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
			this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
			this.xtraTabPage_InfoMgmt = new DevExpress.XtraTab.XtraTabPage();
			this.splitContainerControl_Mgmt = new DevExpress.XtraEditors.SplitContainerControl();
			this.gridControl_Mgmt = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.groupControl_MgmtClass = new DevExpress.XtraEditors.GroupControl();
			this.dateEdit_MgmtDate = new DevExpress.XtraEditors.DateEdit();
			this.notePanel_MgmtDate = new DevExpress.Utils.Frames.NotePanel();
			this.dataNavigator_Mgmt = new DevExpress.XtraEditors.DataNavigator();
			this.comboBoxEdit_MgmtClass = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_MgmtClass = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_MgmtGrade = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_MgmtGrade = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_MgmtQuery = new DevExpress.Utils.Frames.NotePanel();
			this.groupControl_VisitInfoInput = new DevExpress.XtraEditors.GroupControl();
			this.memoEdit_MgmtAbsRemark = new DevExpress.XtraEditors.MemoEdit();
			this.notePanel_MgmtVisState = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_MgmtAbsReason = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_MgmtVisState = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_MgmtVisDate = new DevExpress.Utils.Frames.NotePanel();
			this.dateEdit_MgmtVisDate = new DevExpress.XtraEditors.DateEdit();
			this.comboBoxEdit_MgmtAbsReason = new DevExpress.XtraEditors.ComboBoxEdit();
			this.groupControl_MgmtParentLink = new DevExpress.XtraEditors.GroupControl();
			this.textEdit_MgmtMOWorkingAddr = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_MgmtMOWorkingAddr = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_MgmtMOPhone = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_MgmtMOName = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_MgmtMOPhone = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_MgmtMOName = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_MgmtFAWorkingAddr = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_MgmtFAWorkingAddr = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_MgmtFAPhone = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_MgmtFAPhone = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_MgmtFAName = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_MgmtFAName = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_MgmtFamilyAddr = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_MgmtFamilyAddr = new DevExpress.XtraEditors.TextEdit();
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.simpleButton_Mgmt2DaysAbs = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_MgmtSave = new DevExpress.XtraEditors.SimpleButton();
			this.notePanel_WelcomePanel = new DevExpress.Utils.Frames.NotePanel();
			this.xtraTabPage_InfoQuery = new DevExpress.XtraTab.XtraTabPage();
			this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
			this.groupControl_VisitInfoClass = new DevExpress.XtraEditors.GroupControl();
			this.textEdit_VisitInfoNumber = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_VisitInfoName = new DevExpress.XtraEditors.TextEdit();
			this.dateEdit_VisitInfoEndDate = new DevExpress.XtraEditors.DateEdit();
			this.dateEdit_VisitInfoBegDate = new DevExpress.XtraEditors.DateEdit();
			this.notePanel_VisitInfoEndDate = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_VisitInfoBegDate = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_VisitInfoNumber = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_VisistInfoName = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_VisitInfoClass = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_VisitInfoClass = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_VisitInfoGrade = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_VisitInfoGrade = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_VisitInfoQuery = new DevExpress.Utils.Frames.NotePanel();
			this.groupControl_VisitInfo = new DevExpress.XtraEditors.GroupControl();
			this.memoEdit_VisInfoAbsRemark = new DevExpress.XtraEditors.MemoEdit();
			this.notePanel_VisInfoVisMode = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_VisInfoAbsReason = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_VisInfoVisMode = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_VisInfoVisDate = new DevExpress.Utils.Frames.NotePanel();
			this.dateEdit_VisInfoVisDate = new DevExpress.XtraEditors.DateEdit();
			this.comboBoxEdit_VisInfoAbsReason = new DevExpress.XtraEditors.ComboBoxEdit();
			this.gridControl_VisitInfo = new DevExpress.XtraGrid.GridControl();
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
			this.simpleButton_VisitInfoPrint = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_VisitInfoBack = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_VisitInfoDelete = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_VisitInfoSearch = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_VisitInfoModify = new DevExpress.XtraEditors.SimpleButton();
			this.notePanel_VisitInfoPanel = new DevExpress.Utils.Frames.NotePanel();
			this.saveFileDialog_Report = new System.Windows.Forms.SaveFileDialog();
			this.helpProvider_StuVisitInfo = new System.Windows.Forms.HelpProvider();
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
			this.xtraTabControl1.SuspendLayout();
			this.xtraTabPage_InfoMgmt.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl_Mgmt)).BeginInit();
			this.splitContainerControl_Mgmt.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_Mgmt)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MgmtClass)).BeginInit();
			this.groupControl_MgmtClass.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_MgmtDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_MgmtClass.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_MgmtGrade.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_VisitInfoInput)).BeginInit();
			this.groupControl_VisitInfoInput.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit_MgmtAbsRemark.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_MgmtVisState.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_MgmtVisDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_MgmtAbsReason.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MgmtParentLink)).BeginInit();
			this.groupControl_MgmtParentLink.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MgmtMOWorkingAddr.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MgmtMOPhone.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MgmtMOName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MgmtFAWorkingAddr.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MgmtFAPhone.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MgmtFAName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MgmtFamilyAddr.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			this.xtraTabPage_InfoQuery.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
			this.splitContainerControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_VisitInfoClass)).BeginInit();
			this.groupControl_VisitInfoClass.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_VisitInfoNumber.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_VisitInfoName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_VisitInfoEndDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_VisitInfoBegDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_VisitInfoClass.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_VisitInfoGrade.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_VisitInfo)).BeginInit();
			this.groupControl_VisitInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit_VisInfoAbsRemark.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_VisInfoVisMode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_VisInfoVisDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_VisInfoAbsReason.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_VisitInfo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
			this.panelControl2.SuspendLayout();
			this.SuspendLayout();
			// 
			// xtraTabControl1
			// 
			this.xtraTabControl1.Controls.Add(this.xtraTabPage_InfoMgmt);
			this.xtraTabControl1.Controls.Add(this.xtraTabPage_InfoQuery);
			this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
			this.xtraTabControl1.Name = "xtraTabControl1";
			this.xtraTabControl1.SelectedTabPage = this.xtraTabPage_InfoMgmt;
			this.xtraTabControl1.Size = new System.Drawing.Size(772, 540);
			this.xtraTabControl1.TabIndex = 0;
			this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
																							this.xtraTabPage_InfoMgmt,
																							this.xtraTabPage_InfoQuery});
			this.xtraTabControl1.Text = "xtraTabControl1";
			// 
			// xtraTabPage_InfoMgmt
			// 
			this.xtraTabPage_InfoMgmt.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
			this.xtraTabPage_InfoMgmt.Appearance.PageClient.Options.UseBackColor = true;
			this.xtraTabPage_InfoMgmt.Controls.Add(this.splitContainerControl_Mgmt);
			this.xtraTabPage_InfoMgmt.Controls.Add(this.notePanel_WelcomePanel);
			this.xtraTabPage_InfoMgmt.Name = "xtraTabPage_InfoMgmt";
			this.xtraTabPage_InfoMgmt.Size = new System.Drawing.Size(768, 515);
			this.xtraTabPage_InfoMgmt.Text = "幼儿家访信息管理";
			// 
			// splitContainerControl_Mgmt
			// 
			this.splitContainerControl_Mgmt.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl_Mgmt.Location = new System.Drawing.Point(0, 23);
			this.splitContainerControl_Mgmt.Name = "splitContainerControl_Mgmt";
			this.splitContainerControl_Mgmt.Panel1.Controls.Add(this.gridControl_Mgmt);
			this.splitContainerControl_Mgmt.Panel1.Controls.Add(this.groupControl_MgmtClass);
			this.splitContainerControl_Mgmt.Panel1.Text = "splitContainerControl1_Panel1";
			this.splitContainerControl_Mgmt.Panel2.Controls.Add(this.groupControl_VisitInfoInput);
			this.splitContainerControl_Mgmt.Panel2.Controls.Add(this.groupControl_MgmtParentLink);
			this.splitContainerControl_Mgmt.Panel2.Controls.Add(this.panelControl1);
			this.splitContainerControl_Mgmt.Panel2.Text = "splitContainerControl1_Panel2";
			this.splitContainerControl_Mgmt.Size = new System.Drawing.Size(768, 492);
			this.splitContainerControl_Mgmt.SplitterPosition = 208;
			this.splitContainerControl_Mgmt.TabIndex = 12;
			this.splitContainerControl_Mgmt.Text = "splitContainerControl1";
			// 
			// gridControl_Mgmt
			// 
			this.gridControl_Mgmt.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl_Mgmt.EmbeddedNavigator
			// 
			this.gridControl_Mgmt.EmbeddedNavigator.Name = "";
			this.gridControl_Mgmt.Location = new System.Drawing.Point(0, 192);
			this.gridControl_Mgmt.MainView = this.gridView1;
			this.gridControl_Mgmt.Name = "gridControl_Mgmt";
			this.gridControl_Mgmt.Size = new System.Drawing.Size(202, 294);
			this.gridControl_Mgmt.TabIndex = 1;
			this.gridControl_Mgmt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn1,
																							 this.gridColumn2,
																							 this.gridColumn3});
			this.gridView1.GridControl = this.gridControl_Mgmt;
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
			this.gridColumn1.Caption = "学号";
			this.gridColumn1.FieldName = "info_stuNumber";
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
			this.gridColumn2.FieldName = "info_stuName";
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
			this.gridColumn3.Caption = "班级";
			this.gridColumn3.FieldName = "info_className";
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
			// groupControl_MgmtClass
			// 
			this.groupControl_MgmtClass.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_MgmtClass.AppearanceCaption.Options.UseFont = true;
			this.groupControl_MgmtClass.Controls.Add(this.dateEdit_MgmtDate);
			this.groupControl_MgmtClass.Controls.Add(this.notePanel_MgmtDate);
			this.groupControl_MgmtClass.Controls.Add(this.dataNavigator_Mgmt);
			this.groupControl_MgmtClass.Controls.Add(this.comboBoxEdit_MgmtClass);
			this.groupControl_MgmtClass.Controls.Add(this.notePanel_MgmtClass);
			this.groupControl_MgmtClass.Controls.Add(this.comboBoxEdit_MgmtGrade);
			this.groupControl_MgmtClass.Controls.Add(this.notePanel_MgmtGrade);
			this.groupControl_MgmtClass.Controls.Add(this.notePanel_MgmtQuery);
			this.groupControl_MgmtClass.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_MgmtClass.Location = new System.Drawing.Point(0, 0);
			this.groupControl_MgmtClass.Name = "groupControl_MgmtClass";
			this.groupControl_MgmtClass.Size = new System.Drawing.Size(202, 192);
			this.groupControl_MgmtClass.TabIndex = 0;
			this.groupControl_MgmtClass.Text = "我的班级";
			// 
			// dateEdit_MgmtDate
			// 
			this.dateEdit_MgmtDate.EditValue = new System.DateTime(2005, 1, 24, 0, 0, 0, 0);
			this.dateEdit_MgmtDate.Location = new System.Drawing.Point(96, 120);
			this.dateEdit_MgmtDate.Name = "dateEdit_MgmtDate";
			// 
			// dateEdit_MgmtDate.Properties
			// 
			this.dateEdit_MgmtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit_MgmtDate.Properties.DisplayFormat.FormatString = "yyyy年M月";
			this.dateEdit_MgmtDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dateEdit_MgmtDate.Properties.Mask.EditMask = "d";
			this.dateEdit_MgmtDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
			this.dateEdit_MgmtDate.Size = new System.Drawing.Size(88, 23);
			this.dateEdit_MgmtDate.TabIndex = 20;
			// 
			// notePanel_MgmtDate
			// 
			this.notePanel_MgmtDate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MgmtDate.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MgmtDate.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MgmtDate.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MgmtDate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MgmtDate.Location = new System.Drawing.Point(16, 120);
			this.notePanel_MgmtDate.MaxRows = 5;
			this.notePanel_MgmtDate.Name = "notePanel_MgmtDate";
			this.notePanel_MgmtDate.ParentAutoHeight = true;
			this.notePanel_MgmtDate.Size = new System.Drawing.Size(64, 22);
			this.notePanel_MgmtDate.TabIndex = 19;
			this.notePanel_MgmtDate.TabStop = false;
			this.notePanel_MgmtDate.Text = "日  期:";
			// 
			// dataNavigator_Mgmt
			// 
			this.dataNavigator_Mgmt.Buttons.Append.Visible = false;
			this.dataNavigator_Mgmt.Buttons.CancelEdit.Visible = false;
			this.dataNavigator_Mgmt.Buttons.EndEdit.Visible = false;
			this.dataNavigator_Mgmt.Buttons.First.Hint = "第一条记录";
			this.dataNavigator_Mgmt.Buttons.Last.Hint = "最后一条记录";
			this.dataNavigator_Mgmt.Buttons.Next.Hint = "下一条记录";
			this.dataNavigator_Mgmt.Buttons.NextPage.Visible = false;
			this.dataNavigator_Mgmt.Buttons.Prev.Hint = "上一条";
			this.dataNavigator_Mgmt.Buttons.PrevPage.Visible = false;
			this.dataNavigator_Mgmt.Buttons.Remove.Visible = false;
			this.dataNavigator_Mgmt.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dataNavigator_Mgmt.Location = new System.Drawing.Point(3, 157);
			this.dataNavigator_Mgmt.Name = "dataNavigator_Mgmt";
			this.dataNavigator_Mgmt.ShowToolTips = true;
			this.dataNavigator_Mgmt.Size = new System.Drawing.Size(196, 32);
			this.dataNavigator_Mgmt.TabIndex = 18;
			this.dataNavigator_Mgmt.Text = "dataNavigator1";
			this.dataNavigator_Mgmt.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.End;
			// 
			// comboBoxEdit_MgmtClass
			// 
			this.comboBoxEdit_MgmtClass.EditValue = "全部";
			this.comboBoxEdit_MgmtClass.Location = new System.Drawing.Point(96, 88);
			this.comboBoxEdit_MgmtClass.Name = "comboBoxEdit_MgmtClass";
			// 
			// comboBoxEdit_MgmtClass.Properties
			// 
			this.comboBoxEdit_MgmtClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																														   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_MgmtClass.Properties.Items.AddRange(new object[] {
																				   "全部"});
			this.comboBoxEdit_MgmtClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_MgmtClass.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_MgmtClass.TabIndex = 17;
			this.comboBoxEdit_MgmtClass.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_MgmtClass_SelectedIndexChanged);
			// 
			// notePanel_MgmtClass
			// 
			this.notePanel_MgmtClass.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MgmtClass.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MgmtClass.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MgmtClass.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MgmtClass.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MgmtClass.Location = new System.Drawing.Point(16, 88);
			this.notePanel_MgmtClass.MaxRows = 5;
			this.notePanel_MgmtClass.Name = "notePanel_MgmtClass";
			this.notePanel_MgmtClass.ParentAutoHeight = true;
			this.notePanel_MgmtClass.Size = new System.Drawing.Size(64, 22);
			this.notePanel_MgmtClass.TabIndex = 16;
			this.notePanel_MgmtClass.TabStop = false;
			this.notePanel_MgmtClass.Text = "班  级:";
			// 
			// comboBoxEdit_MgmtGrade
			// 
			this.comboBoxEdit_MgmtGrade.EditValue = "全部";
			this.comboBoxEdit_MgmtGrade.Location = new System.Drawing.Point(96, 56);
			this.comboBoxEdit_MgmtGrade.Name = "comboBoxEdit_MgmtGrade";
			// 
			// comboBoxEdit_MgmtGrade.Properties
			// 
			this.comboBoxEdit_MgmtGrade.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																														   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_MgmtGrade.Properties.Items.AddRange(new object[] {
																				   "全部"});
			this.comboBoxEdit_MgmtGrade.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_MgmtGrade.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_MgmtGrade.TabIndex = 15;
			this.comboBoxEdit_MgmtGrade.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_MgmtGrade_SelectedIndexChanged);
			// 
			// notePanel_MgmtGrade
			// 
			this.notePanel_MgmtGrade.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MgmtGrade.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MgmtGrade.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MgmtGrade.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MgmtGrade.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MgmtGrade.Location = new System.Drawing.Point(16, 56);
			this.notePanel_MgmtGrade.MaxRows = 5;
			this.notePanel_MgmtGrade.Name = "notePanel_MgmtGrade";
			this.notePanel_MgmtGrade.ParentAutoHeight = true;
			this.notePanel_MgmtGrade.Size = new System.Drawing.Size(64, 22);
			this.notePanel_MgmtGrade.TabIndex = 14;
			this.notePanel_MgmtGrade.TabStop = false;
			this.notePanel_MgmtGrade.Text = "年  级:";
			// 
			// notePanel_MgmtQuery
			// 
			this.notePanel_MgmtQuery.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel_MgmtQuery.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel_MgmtQuery.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel_MgmtQuery.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MgmtQuery.Location = new System.Drawing.Point(3, 18);
			this.notePanel_MgmtQuery.MaxRows = 5;
			this.notePanel_MgmtQuery.Name = "notePanel_MgmtQuery";
			this.notePanel_MgmtQuery.ParentAutoHeight = true;
			this.notePanel_MgmtQuery.Size = new System.Drawing.Size(196, 23);
			this.notePanel_MgmtQuery.TabIndex = 7;
			this.notePanel_MgmtQuery.TabStop = false;
			this.notePanel_MgmtQuery.Text = "您需要查询哪个班级？";
			// 
			// groupControl_VisitInfoInput
			// 
			this.groupControl_VisitInfoInput.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_VisitInfoInput.AppearanceCaption.Options.UseFont = true;
			this.groupControl_VisitInfoInput.Controls.Add(this.memoEdit_MgmtAbsRemark);
			this.groupControl_VisitInfoInput.Controls.Add(this.notePanel_MgmtVisState);
			this.groupControl_VisitInfoInput.Controls.Add(this.notePanel_MgmtAbsReason);
			this.groupControl_VisitInfoInput.Controls.Add(this.comboBoxEdit_MgmtVisState);
			this.groupControl_VisitInfoInput.Controls.Add(this.notePanel_MgmtVisDate);
			this.groupControl_VisitInfoInput.Controls.Add(this.dateEdit_MgmtVisDate);
			this.groupControl_VisitInfoInput.Controls.Add(this.comboBoxEdit_MgmtAbsReason);
			this.groupControl_VisitInfoInput.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_VisitInfoInput.Location = new System.Drawing.Point(0, 248);
			this.groupControl_VisitInfoInput.Name = "groupControl_VisitInfoInput";
			this.groupControl_VisitInfoInput.Size = new System.Drawing.Size(550, 160);
			this.groupControl_VisitInfoInput.TabIndex = 16;
			this.groupControl_VisitInfoInput.Text = "家访信息录入";
			// 
			// memoEdit_MgmtAbsRemark
			// 
			this.memoEdit_MgmtAbsRemark.EditValue = "";
			this.memoEdit_MgmtAbsRemark.Location = new System.Drawing.Point(216, 32);
			this.memoEdit_MgmtAbsRemark.Name = "memoEdit_MgmtAbsRemark";
			this.memoEdit_MgmtAbsRemark.Size = new System.Drawing.Size(320, 104);
			this.memoEdit_MgmtAbsRemark.TabIndex = 108;
			// 
			// notePanel_MgmtVisState
			// 
			this.notePanel_MgmtVisState.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MgmtVisState.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MgmtVisState.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MgmtVisState.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MgmtVisState.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MgmtVisState.Location = new System.Drawing.Point(24, 72);
			this.notePanel_MgmtVisState.MaxRows = 5;
			this.notePanel_MgmtVisState.Name = "notePanel_MgmtVisState";
			this.notePanel_MgmtVisState.ParentAutoHeight = true;
			this.notePanel_MgmtVisState.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MgmtVisState.TabIndex = 104;
			this.notePanel_MgmtVisState.TabStop = false;
			this.notePanel_MgmtVisState.Text = "访问方式:";
			// 
			// notePanel_MgmtAbsReason
			// 
			this.notePanel_MgmtAbsReason.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MgmtAbsReason.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MgmtAbsReason.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MgmtAbsReason.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MgmtAbsReason.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MgmtAbsReason.Location = new System.Drawing.Point(24, 32);
			this.notePanel_MgmtAbsReason.MaxRows = 5;
			this.notePanel_MgmtAbsReason.Name = "notePanel_MgmtAbsReason";
			this.notePanel_MgmtAbsReason.ParentAutoHeight = true;
			this.notePanel_MgmtAbsReason.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MgmtAbsReason.TabIndex = 102;
			this.notePanel_MgmtAbsReason.TabStop = false;
			this.notePanel_MgmtAbsReason.Text = "缺席原因:";
			// 
			// comboBoxEdit_MgmtVisState
			// 
			this.comboBoxEdit_MgmtVisState.EditValue = "上门";
			this.comboBoxEdit_MgmtVisState.Location = new System.Drawing.Point(120, 72);
			this.comboBoxEdit_MgmtVisState.Name = "comboBoxEdit_MgmtVisState";
			// 
			// comboBoxEdit_MgmtVisState.Properties
			// 
			this.comboBoxEdit_MgmtVisState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_MgmtVisState.Properties.Items.AddRange(new object[] {
																					  "上门",
																					  "电话"});
			this.comboBoxEdit_MgmtVisState.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_MgmtVisState.Size = new System.Drawing.Size(80, 23);
			this.comboBoxEdit_MgmtVisState.TabIndex = 105;
			// 
			// notePanel_MgmtVisDate
			// 
			this.notePanel_MgmtVisDate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MgmtVisDate.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MgmtVisDate.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MgmtVisDate.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MgmtVisDate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
			this.notePanel_MgmtVisDate.Location = new System.Drawing.Point(24, 112);
			this.notePanel_MgmtVisDate.MaxRows = 5;
			this.notePanel_MgmtVisDate.Name = "notePanel_MgmtVisDate";
			this.notePanel_MgmtVisDate.ParentAutoHeight = true;
			this.notePanel_MgmtVisDate.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MgmtVisDate.TabIndex = 106;
			this.notePanel_MgmtVisDate.TabStop = false;
			this.notePanel_MgmtVisDate.Text = "访问时间:";
			// 
			// dateEdit_MgmtVisDate
			// 
			this.dateEdit_MgmtVisDate.EditValue = new System.DateTime(2005, 4, 11, 0, 0, 0, 0);
			this.dateEdit_MgmtVisDate.Location = new System.Drawing.Point(120, 112);
			this.dateEdit_MgmtVisDate.Name = "dateEdit_MgmtVisDate";
			// 
			// dateEdit_MgmtVisDate.Properties
			// 
			this.dateEdit_MgmtVisDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																														 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit_MgmtVisDate.Properties.Mask.EditMask = "d";
			this.dateEdit_MgmtVisDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
			this.dateEdit_MgmtVisDate.Size = new System.Drawing.Size(80, 23);
			this.dateEdit_MgmtVisDate.TabIndex = 107;
			// 
			// comboBoxEdit_MgmtAbsReason
			// 
			this.comboBoxEdit_MgmtAbsReason.EditValue = "患病";
			this.comboBoxEdit_MgmtAbsReason.Location = new System.Drawing.Point(120, 32);
			this.comboBoxEdit_MgmtAbsReason.Name = "comboBoxEdit_MgmtAbsReason";
			// 
			// comboBoxEdit_MgmtAbsReason.Properties
			// 
			this.comboBoxEdit_MgmtAbsReason.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_MgmtAbsReason.Properties.Items.AddRange(new object[] {
																					   "患病",
																					   "家中有人",
																					   "走亲戚",
																					   "其他"});
			this.comboBoxEdit_MgmtAbsReason.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_MgmtAbsReason.Size = new System.Drawing.Size(80, 23);
			this.comboBoxEdit_MgmtAbsReason.TabIndex = 103;
			// 
			// groupControl_MgmtParentLink
			// 
			this.groupControl_MgmtParentLink.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_MgmtParentLink.AppearanceCaption.Options.UseFont = true;
			this.groupControl_MgmtParentLink.Controls.Add(this.textEdit_MgmtMOWorkingAddr);
			this.groupControl_MgmtParentLink.Controls.Add(this.notePanel_MgmtMOWorkingAddr);
			this.groupControl_MgmtParentLink.Controls.Add(this.textEdit_MgmtMOPhone);
			this.groupControl_MgmtParentLink.Controls.Add(this.textEdit_MgmtMOName);
			this.groupControl_MgmtParentLink.Controls.Add(this.notePanel_MgmtMOPhone);
			this.groupControl_MgmtParentLink.Controls.Add(this.notePanel_MgmtMOName);
			this.groupControl_MgmtParentLink.Controls.Add(this.textEdit_MgmtFAWorkingAddr);
			this.groupControl_MgmtParentLink.Controls.Add(this.notePanel_MgmtFAWorkingAddr);
			this.groupControl_MgmtParentLink.Controls.Add(this.textEdit_MgmtFAPhone);
			this.groupControl_MgmtParentLink.Controls.Add(this.notePanel_MgmtFAPhone);
			this.groupControl_MgmtParentLink.Controls.Add(this.textEdit_MgmtFAName);
			this.groupControl_MgmtParentLink.Controls.Add(this.notePanel_MgmtFAName);
			this.groupControl_MgmtParentLink.Controls.Add(this.notePanel_MgmtFamilyAddr);
			this.groupControl_MgmtParentLink.Controls.Add(this.textEdit_MgmtFamilyAddr);
			this.groupControl_MgmtParentLink.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_MgmtParentLink.Location = new System.Drawing.Point(0, 40);
			this.groupControl_MgmtParentLink.Name = "groupControl_MgmtParentLink";
			this.groupControl_MgmtParentLink.Size = new System.Drawing.Size(550, 208);
			this.groupControl_MgmtParentLink.TabIndex = 15;
			this.groupControl_MgmtParentLink.Text = "幼儿家长联系方式";
			// 
			// textEdit_MgmtMOWorkingAddr
			// 
			this.textEdit_MgmtMOWorkingAddr.EditValue = "";
			this.textEdit_MgmtMOWorkingAddr.Location = new System.Drawing.Point(104, 128);
			this.textEdit_MgmtMOWorkingAddr.Name = "textEdit_MgmtMOWorkingAddr";
			this.textEdit_MgmtMOWorkingAddr.Size = new System.Drawing.Size(432, 23);
			this.textEdit_MgmtMOWorkingAddr.TabIndex = 108;
			// 
			// notePanel_MgmtMOWorkingAddr
			// 
			this.notePanel_MgmtMOWorkingAddr.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MgmtMOWorkingAddr.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MgmtMOWorkingAddr.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MgmtMOWorkingAddr.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MgmtMOWorkingAddr.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MgmtMOWorkingAddr.Location = new System.Drawing.Point(16, 128);
			this.notePanel_MgmtMOWorkingAddr.MaxRows = 5;
			this.notePanel_MgmtMOWorkingAddr.Name = "notePanel_MgmtMOWorkingAddr";
			this.notePanel_MgmtMOWorkingAddr.ParentAutoHeight = true;
			this.notePanel_MgmtMOWorkingAddr.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MgmtMOWorkingAddr.TabIndex = 107;
			this.notePanel_MgmtMOWorkingAddr.TabStop = false;
			this.notePanel_MgmtMOWorkingAddr.Text = "工作单位:";
			// 
			// textEdit_MgmtMOPhone
			// 
			this.textEdit_MgmtMOPhone.EditValue = "";
			this.textEdit_MgmtMOPhone.Location = new System.Drawing.Point(392, 96);
			this.textEdit_MgmtMOPhone.Name = "textEdit_MgmtMOPhone";
			this.textEdit_MgmtMOPhone.Size = new System.Drawing.Size(144, 23);
			this.textEdit_MgmtMOPhone.TabIndex = 106;
			// 
			// textEdit_MgmtMOName
			// 
			this.textEdit_MgmtMOName.EditValue = "";
			this.textEdit_MgmtMOName.Location = new System.Drawing.Point(104, 96);
			this.textEdit_MgmtMOName.Name = "textEdit_MgmtMOName";
			this.textEdit_MgmtMOName.Size = new System.Drawing.Size(184, 23);
			this.textEdit_MgmtMOName.TabIndex = 105;
			// 
			// notePanel_MgmtMOPhone
			// 
			this.notePanel_MgmtMOPhone.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MgmtMOPhone.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MgmtMOPhone.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MgmtMOPhone.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MgmtMOPhone.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MgmtMOPhone.Location = new System.Drawing.Point(304, 96);
			this.notePanel_MgmtMOPhone.MaxRows = 5;
			this.notePanel_MgmtMOPhone.Name = "notePanel_MgmtMOPhone";
			this.notePanel_MgmtMOPhone.ParentAutoHeight = true;
			this.notePanel_MgmtMOPhone.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MgmtMOPhone.TabIndex = 104;
			this.notePanel_MgmtMOPhone.TabStop = false;
			this.notePanel_MgmtMOPhone.Text = "联系电话:";
			// 
			// notePanel_MgmtMOName
			// 
			this.notePanel_MgmtMOName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MgmtMOName.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MgmtMOName.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MgmtMOName.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MgmtMOName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MgmtMOName.Location = new System.Drawing.Point(16, 96);
			this.notePanel_MgmtMOName.MaxRows = 5;
			this.notePanel_MgmtMOName.Name = "notePanel_MgmtMOName";
			this.notePanel_MgmtMOName.ParentAutoHeight = true;
			this.notePanel_MgmtMOName.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MgmtMOName.TabIndex = 103;
			this.notePanel_MgmtMOName.TabStop = false;
			this.notePanel_MgmtMOName.Text = "母亲姓名:";
			// 
			// textEdit_MgmtFAWorkingAddr
			// 
			this.textEdit_MgmtFAWorkingAddr.EditValue = "";
			this.textEdit_MgmtFAWorkingAddr.Location = new System.Drawing.Point(104, 64);
			this.textEdit_MgmtFAWorkingAddr.Name = "textEdit_MgmtFAWorkingAddr";
			this.textEdit_MgmtFAWorkingAddr.Size = new System.Drawing.Size(432, 23);
			this.textEdit_MgmtFAWorkingAddr.TabIndex = 102;
			// 
			// notePanel_MgmtFAWorkingAddr
			// 
			this.notePanel_MgmtFAWorkingAddr.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MgmtFAWorkingAddr.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MgmtFAWorkingAddr.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MgmtFAWorkingAddr.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MgmtFAWorkingAddr.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MgmtFAWorkingAddr.Location = new System.Drawing.Point(16, 64);
			this.notePanel_MgmtFAWorkingAddr.MaxRows = 5;
			this.notePanel_MgmtFAWorkingAddr.Name = "notePanel_MgmtFAWorkingAddr";
			this.notePanel_MgmtFAWorkingAddr.ParentAutoHeight = true;
			this.notePanel_MgmtFAWorkingAddr.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MgmtFAWorkingAddr.TabIndex = 101;
			this.notePanel_MgmtFAWorkingAddr.TabStop = false;
			this.notePanel_MgmtFAWorkingAddr.Text = "工作单位:";
			// 
			// textEdit_MgmtFAPhone
			// 
			this.textEdit_MgmtFAPhone.EditValue = "";
			this.textEdit_MgmtFAPhone.Location = new System.Drawing.Point(392, 32);
			this.textEdit_MgmtFAPhone.Name = "textEdit_MgmtFAPhone";
			this.textEdit_MgmtFAPhone.Size = new System.Drawing.Size(144, 23);
			this.textEdit_MgmtFAPhone.TabIndex = 100;
			// 
			// notePanel_MgmtFAPhone
			// 
			this.notePanel_MgmtFAPhone.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MgmtFAPhone.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MgmtFAPhone.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MgmtFAPhone.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MgmtFAPhone.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MgmtFAPhone.Location = new System.Drawing.Point(304, 32);
			this.notePanel_MgmtFAPhone.MaxRows = 5;
			this.notePanel_MgmtFAPhone.Name = "notePanel_MgmtFAPhone";
			this.notePanel_MgmtFAPhone.ParentAutoHeight = true;
			this.notePanel_MgmtFAPhone.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MgmtFAPhone.TabIndex = 99;
			this.notePanel_MgmtFAPhone.TabStop = false;
			this.notePanel_MgmtFAPhone.Text = "联系电话:";
			// 
			// textEdit_MgmtFAName
			// 
			this.textEdit_MgmtFAName.EditValue = "";
			this.textEdit_MgmtFAName.Location = new System.Drawing.Point(104, 32);
			this.textEdit_MgmtFAName.Name = "textEdit_MgmtFAName";
			this.textEdit_MgmtFAName.Size = new System.Drawing.Size(184, 23);
			this.textEdit_MgmtFAName.TabIndex = 98;
			// 
			// notePanel_MgmtFAName
			// 
			this.notePanel_MgmtFAName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MgmtFAName.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MgmtFAName.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MgmtFAName.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MgmtFAName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MgmtFAName.Location = new System.Drawing.Point(16, 32);
			this.notePanel_MgmtFAName.MaxRows = 5;
			this.notePanel_MgmtFAName.Name = "notePanel_MgmtFAName";
			this.notePanel_MgmtFAName.ParentAutoHeight = true;
			this.notePanel_MgmtFAName.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MgmtFAName.TabIndex = 97;
			this.notePanel_MgmtFAName.TabStop = false;
			this.notePanel_MgmtFAName.Text = "父亲姓名:";
			// 
			// notePanel_MgmtFamilyAddr
			// 
			this.notePanel_MgmtFamilyAddr.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MgmtFamilyAddr.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MgmtFamilyAddr.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MgmtFamilyAddr.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MgmtFamilyAddr.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MgmtFamilyAddr.Location = new System.Drawing.Point(16, 160);
			this.notePanel_MgmtFamilyAddr.MaxRows = 5;
			this.notePanel_MgmtFamilyAddr.Name = "notePanel_MgmtFamilyAddr";
			this.notePanel_MgmtFamilyAddr.ParentAutoHeight = true;
			this.notePanel_MgmtFamilyAddr.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MgmtFamilyAddr.TabIndex = 95;
			this.notePanel_MgmtFamilyAddr.TabStop = false;
			this.notePanel_MgmtFamilyAddr.Text = "家庭地址:";
			// 
			// textEdit_MgmtFamilyAddr
			// 
			this.textEdit_MgmtFamilyAddr.EditValue = "";
			this.textEdit_MgmtFamilyAddr.Location = new System.Drawing.Point(104, 160);
			this.textEdit_MgmtFamilyAddr.Name = "textEdit_MgmtFamilyAddr";
			this.textEdit_MgmtFamilyAddr.Size = new System.Drawing.Size(432, 23);
			this.textEdit_MgmtFamilyAddr.TabIndex = 96;
			// 
			// panelControl1
			// 
			this.panelControl1.Controls.Add(this.simpleButton_Mgmt2DaysAbs);
			this.panelControl1.Controls.Add(this.simpleButton_MgmtSave);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl1.Location = new System.Drawing.Point(0, 0);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(550, 40);
			this.panelControl1.TabIndex = 14;
			this.panelControl1.Text = "panelControl1";
			// 
			// simpleButton_Mgmt2DaysAbs
			// 
			this.simpleButton_Mgmt2DaysAbs.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_Mgmt2DaysAbs.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_Mgmt2DaysAbs.Appearance.Options.UseFont = true;
			this.simpleButton_Mgmt2DaysAbs.Appearance.Options.UseForeColor = true;
			this.simpleButton_Mgmt2DaysAbs.Location = new System.Drawing.Point(8, 8);
			this.simpleButton_Mgmt2DaysAbs.Name = "simpleButton_Mgmt2DaysAbs";
			this.simpleButton_Mgmt2DaysAbs.Size = new System.Drawing.Size(72, 26);
			this.simpleButton_Mgmt2DaysAbs.TabIndex = 8;
			this.simpleButton_Mgmt2DaysAbs.Tag = 4;
			this.simpleButton_Mgmt2DaysAbs.Text = "检  索";
			this.simpleButton_Mgmt2DaysAbs.Click += new System.EventHandler(this.simpleButton_Mgmt2DaysAbs_Click);
			// 
			// simpleButton_MgmtSave
			// 
			this.simpleButton_MgmtSave.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_MgmtSave.Appearance.Options.UseForeColor = true;
			this.simpleButton_MgmtSave.Location = new System.Drawing.Point(88, 8);
			this.simpleButton_MgmtSave.Name = "simpleButton_MgmtSave";
			this.simpleButton_MgmtSave.Size = new System.Drawing.Size(72, 26);
			this.simpleButton_MgmtSave.TabIndex = 13;
			this.simpleButton_MgmtSave.Text = "保  存";
			this.simpleButton_MgmtSave.Click += new System.EventHandler(this.simpleButton_MgmtSave_Click);
			// 
			// notePanel_WelcomePanel
			// 
			this.notePanel_WelcomePanel.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel_WelcomePanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel_WelcomePanel.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel_WelcomePanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_WelcomePanel.Location = new System.Drawing.Point(0, 0);
			this.notePanel_WelcomePanel.MaxRows = 5;
			this.notePanel_WelcomePanel.Name = "notePanel_WelcomePanel";
			this.notePanel_WelcomePanel.ParentAutoHeight = true;
			this.notePanel_WelcomePanel.Size = new System.Drawing.Size(768, 23);
			this.notePanel_WelcomePanel.TabIndex = 9;
			this.notePanel_WelcomePanel.TabStop = false;
			this.notePanel_WelcomePanel.Text = "本月连续两天幼儿缺席检索与家访信息录入";
			// 
			// xtraTabPage_InfoQuery
			// 
			this.xtraTabPage_InfoQuery.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
			this.xtraTabPage_InfoQuery.Appearance.PageClient.Options.UseBackColor = true;
			this.xtraTabPage_InfoQuery.Controls.Add(this.splitContainerControl1);
			this.xtraTabPage_InfoQuery.Controls.Add(this.notePanel_VisitInfoPanel);
			this.xtraTabPage_InfoQuery.Name = "xtraTabPage_InfoQuery";
			this.xtraTabPage_InfoQuery.Size = new System.Drawing.Size(768, 515);
			this.xtraTabPage_InfoQuery.Text = "幼儿家访信息检索";
			// 
			// splitContainerControl1
			// 
			this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl1.Location = new System.Drawing.Point(0, 23);
			this.splitContainerControl1.Name = "splitContainerControl1";
			this.splitContainerControl1.Panel1.Controls.Add(this.groupControl_VisitInfoClass);
			this.splitContainerControl1.Panel1.Text = "splitContainerControl1_Panel1";
			this.splitContainerControl1.Panel2.Controls.Add(this.groupControl_VisitInfo);
			this.splitContainerControl1.Panel2.Controls.Add(this.gridControl_VisitInfo);
			this.splitContainerControl1.Panel2.Controls.Add(this.panelControl2);
			this.splitContainerControl1.Panel2.Text = "splitContainerControl1_Panel2";
			this.splitContainerControl1.Size = new System.Drawing.Size(768, 492);
			this.splitContainerControl1.SplitterPosition = 199;
			this.splitContainerControl1.TabIndex = 11;
			this.splitContainerControl1.Text = "splitContainerControl1";
			// 
			// groupControl_VisitInfoClass
			// 
			this.groupControl_VisitInfoClass.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_VisitInfoClass.AppearanceCaption.Options.UseFont = true;
			this.groupControl_VisitInfoClass.Controls.Add(this.textEdit_VisitInfoNumber);
			this.groupControl_VisitInfoClass.Controls.Add(this.textEdit_VisitInfoName);
			this.groupControl_VisitInfoClass.Controls.Add(this.dateEdit_VisitInfoEndDate);
			this.groupControl_VisitInfoClass.Controls.Add(this.dateEdit_VisitInfoBegDate);
			this.groupControl_VisitInfoClass.Controls.Add(this.notePanel_VisitInfoEndDate);
			this.groupControl_VisitInfoClass.Controls.Add(this.notePanel_VisitInfoBegDate);
			this.groupControl_VisitInfoClass.Controls.Add(this.notePanel_VisitInfoNumber);
			this.groupControl_VisitInfoClass.Controls.Add(this.notePanel_VisistInfoName);
			this.groupControl_VisitInfoClass.Controls.Add(this.comboBoxEdit_VisitInfoClass);
			this.groupControl_VisitInfoClass.Controls.Add(this.notePanel_VisitInfoClass);
			this.groupControl_VisitInfoClass.Controls.Add(this.comboBoxEdit_VisitInfoGrade);
			this.groupControl_VisitInfoClass.Controls.Add(this.notePanel_VisitInfoGrade);
			this.groupControl_VisitInfoClass.Controls.Add(this.notePanel_VisitInfoQuery);
			this.groupControl_VisitInfoClass.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_VisitInfoClass.Location = new System.Drawing.Point(0, 0);
			this.groupControl_VisitInfoClass.Name = "groupControl_VisitInfoClass";
			this.groupControl_VisitInfoClass.Size = new System.Drawing.Size(193, 256);
			this.groupControl_VisitInfoClass.TabIndex = 0;
			this.groupControl_VisitInfoClass.Text = "我的班级";
			// 
			// textEdit_VisitInfoNumber
			// 
			this.textEdit_VisitInfoNumber.EditValue = "";
			this.textEdit_VisitInfoNumber.Location = new System.Drawing.Point(96, 152);
			this.textEdit_VisitInfoNumber.Name = "textEdit_VisitInfoNumber";
			this.textEdit_VisitInfoNumber.Size = new System.Drawing.Size(88, 23);
			this.textEdit_VisitInfoNumber.TabIndex = 30;
			// 
			// textEdit_VisitInfoName
			// 
			this.textEdit_VisitInfoName.EditValue = "";
			this.textEdit_VisitInfoName.Location = new System.Drawing.Point(96, 120);
			this.textEdit_VisitInfoName.Name = "textEdit_VisitInfoName";
			this.textEdit_VisitInfoName.Size = new System.Drawing.Size(88, 23);
			this.textEdit_VisitInfoName.TabIndex = 29;
			// 
			// dateEdit_VisitInfoEndDate
			// 
			this.dateEdit_VisitInfoEndDate.EditValue = new System.DateTime(2005, 5, 20, 0, 0, 0, 0);
			this.dateEdit_VisitInfoEndDate.Location = new System.Drawing.Point(104, 216);
			this.dateEdit_VisitInfoEndDate.Name = "dateEdit_VisitInfoEndDate";
			// 
			// dateEdit_VisitInfoEndDate.Properties
			// 
			this.dateEdit_VisitInfoEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit_VisitInfoEndDate.Properties.Mask.EditMask = "d";
			this.dateEdit_VisitInfoEndDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
			this.dateEdit_VisitInfoEndDate.Size = new System.Drawing.Size(80, 23);
			this.dateEdit_VisitInfoEndDate.TabIndex = 28;
			// 
			// dateEdit_VisitInfoBegDate
			// 
			this.dateEdit_VisitInfoBegDate.EditValue = new System.DateTime(2005, 5, 20, 0, 0, 0, 0);
			this.dateEdit_VisitInfoBegDate.Location = new System.Drawing.Point(104, 184);
			this.dateEdit_VisitInfoBegDate.Name = "dateEdit_VisitInfoBegDate";
			// 
			// dateEdit_VisitInfoBegDate.Properties
			// 
			this.dateEdit_VisitInfoBegDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit_VisitInfoBegDate.Properties.Mask.EditMask = "d";
			this.dateEdit_VisitInfoBegDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
			this.dateEdit_VisitInfoBegDate.Size = new System.Drawing.Size(80, 23);
			this.dateEdit_VisitInfoBegDate.TabIndex = 27;
			// 
			// notePanel_VisitInfoEndDate
			// 
			this.notePanel_VisitInfoEndDate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_VisitInfoEndDate.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_VisitInfoEndDate.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_VisitInfoEndDate.ForeColor = System.Drawing.Color.Black;
			this.notePanel_VisitInfoEndDate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_VisitInfoEndDate.Location = new System.Drawing.Point(16, 216);
			this.notePanel_VisitInfoEndDate.MaxRows = 5;
			this.notePanel_VisitInfoEndDate.Name = "notePanel_VisitInfoEndDate";
			this.notePanel_VisitInfoEndDate.ParentAutoHeight = true;
			this.notePanel_VisitInfoEndDate.Size = new System.Drawing.Size(80, 22);
			this.notePanel_VisitInfoEndDate.TabIndex = 26;
			this.notePanel_VisitInfoEndDate.TabStop = false;
			this.notePanel_VisitInfoEndDate.Text = "结束时间:";
			// 
			// notePanel_VisitInfoBegDate
			// 
			this.notePanel_VisitInfoBegDate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_VisitInfoBegDate.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_VisitInfoBegDate.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_VisitInfoBegDate.ForeColor = System.Drawing.Color.Black;
			this.notePanel_VisitInfoBegDate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_VisitInfoBegDate.Location = new System.Drawing.Point(16, 184);
			this.notePanel_VisitInfoBegDate.MaxRows = 5;
			this.notePanel_VisitInfoBegDate.Name = "notePanel_VisitInfoBegDate";
			this.notePanel_VisitInfoBegDate.ParentAutoHeight = true;
			this.notePanel_VisitInfoBegDate.Size = new System.Drawing.Size(80, 22);
			this.notePanel_VisitInfoBegDate.TabIndex = 25;
			this.notePanel_VisitInfoBegDate.TabStop = false;
			this.notePanel_VisitInfoBegDate.Text = "起始时间:";
			// 
			// notePanel_VisitInfoNumber
			// 
			this.notePanel_VisitInfoNumber.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_VisitInfoNumber.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_VisitInfoNumber.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_VisitInfoNumber.ForeColor = System.Drawing.Color.Black;
			this.notePanel_VisitInfoNumber.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_VisitInfoNumber.Location = new System.Drawing.Point(16, 152);
			this.notePanel_VisitInfoNumber.MaxRows = 5;
			this.notePanel_VisitInfoNumber.Name = "notePanel_VisitInfoNumber";
			this.notePanel_VisitInfoNumber.ParentAutoHeight = true;
			this.notePanel_VisitInfoNumber.Size = new System.Drawing.Size(64, 22);
			this.notePanel_VisitInfoNumber.TabIndex = 24;
			this.notePanel_VisitInfoNumber.TabStop = false;
			this.notePanel_VisitInfoNumber.Text = "学  号:";
			// 
			// notePanel_VisistInfoName
			// 
			this.notePanel_VisistInfoName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_VisistInfoName.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_VisistInfoName.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_VisistInfoName.ForeColor = System.Drawing.Color.Black;
			this.notePanel_VisistInfoName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_VisistInfoName.Location = new System.Drawing.Point(16, 120);
			this.notePanel_VisistInfoName.MaxRows = 5;
			this.notePanel_VisistInfoName.Name = "notePanel_VisistInfoName";
			this.notePanel_VisistInfoName.ParentAutoHeight = true;
			this.notePanel_VisistInfoName.Size = new System.Drawing.Size(64, 22);
			this.notePanel_VisistInfoName.TabIndex = 22;
			this.notePanel_VisistInfoName.TabStop = false;
			this.notePanel_VisistInfoName.Text = "姓  名:";
			// 
			// comboBoxEdit_VisitInfoClass
			// 
			this.comboBoxEdit_VisitInfoClass.EditValue = "全部";
			this.comboBoxEdit_VisitInfoClass.Location = new System.Drawing.Point(96, 88);
			this.comboBoxEdit_VisitInfoClass.Name = "comboBoxEdit_VisitInfoClass";
			// 
			// comboBoxEdit_VisitInfoClass.Properties
			// 
			this.comboBoxEdit_VisitInfoClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_VisitInfoClass.Properties.Items.AddRange(new object[] {
																						"全部"});
			this.comboBoxEdit_VisitInfoClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_VisitInfoClass.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_VisitInfoClass.TabIndex = 21;
			this.comboBoxEdit_VisitInfoClass.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_VisitInfoClass_SelectedIndexChanged);
			// 
			// notePanel_VisitInfoClass
			// 
			this.notePanel_VisitInfoClass.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_VisitInfoClass.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_VisitInfoClass.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_VisitInfoClass.ForeColor = System.Drawing.Color.Black;
			this.notePanel_VisitInfoClass.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_VisitInfoClass.Location = new System.Drawing.Point(16, 88);
			this.notePanel_VisitInfoClass.MaxRows = 5;
			this.notePanel_VisitInfoClass.Name = "notePanel_VisitInfoClass";
			this.notePanel_VisitInfoClass.ParentAutoHeight = true;
			this.notePanel_VisitInfoClass.Size = new System.Drawing.Size(64, 22);
			this.notePanel_VisitInfoClass.TabIndex = 20;
			this.notePanel_VisitInfoClass.TabStop = false;
			this.notePanel_VisitInfoClass.Text = "班  级:";
			// 
			// comboBoxEdit_VisitInfoGrade
			// 
			this.comboBoxEdit_VisitInfoGrade.EditValue = "全部";
			this.comboBoxEdit_VisitInfoGrade.Location = new System.Drawing.Point(96, 56);
			this.comboBoxEdit_VisitInfoGrade.Name = "comboBoxEdit_VisitInfoGrade";
			// 
			// comboBoxEdit_VisitInfoGrade.Properties
			// 
			this.comboBoxEdit_VisitInfoGrade.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_VisitInfoGrade.Properties.Items.AddRange(new object[] {
																						"全部"});
			this.comboBoxEdit_VisitInfoGrade.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_VisitInfoGrade.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_VisitInfoGrade.TabIndex = 19;
			this.comboBoxEdit_VisitInfoGrade.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_VisitInfoGrade_SelectedIndexChanged);
			// 
			// notePanel_VisitInfoGrade
			// 
			this.notePanel_VisitInfoGrade.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_VisitInfoGrade.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_VisitInfoGrade.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_VisitInfoGrade.ForeColor = System.Drawing.Color.Black;
			this.notePanel_VisitInfoGrade.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_VisitInfoGrade.Location = new System.Drawing.Point(16, 56);
			this.notePanel_VisitInfoGrade.MaxRows = 5;
			this.notePanel_VisitInfoGrade.Name = "notePanel_VisitInfoGrade";
			this.notePanel_VisitInfoGrade.ParentAutoHeight = true;
			this.notePanel_VisitInfoGrade.Size = new System.Drawing.Size(64, 22);
			this.notePanel_VisitInfoGrade.TabIndex = 18;
			this.notePanel_VisitInfoGrade.TabStop = false;
			this.notePanel_VisitInfoGrade.Text = "年  级:";
			// 
			// notePanel_VisitInfoQuery
			// 
			this.notePanel_VisitInfoQuery.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel_VisitInfoQuery.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel_VisitInfoQuery.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel_VisitInfoQuery.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_VisitInfoQuery.Location = new System.Drawing.Point(3, 18);
			this.notePanel_VisitInfoQuery.MaxRows = 5;
			this.notePanel_VisitInfoQuery.Name = "notePanel_VisitInfoQuery";
			this.notePanel_VisitInfoQuery.ParentAutoHeight = true;
			this.notePanel_VisitInfoQuery.Size = new System.Drawing.Size(187, 23);
			this.notePanel_VisitInfoQuery.TabIndex = 11;
			this.notePanel_VisitInfoQuery.TabStop = false;
			this.notePanel_VisitInfoQuery.Text = "您要查找哪些小朋友？";
			// 
			// groupControl_VisitInfo
			// 
			this.groupControl_VisitInfo.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_VisitInfo.AppearanceCaption.Options.UseFont = true;
			this.groupControl_VisitInfo.Controls.Add(this.memoEdit_VisInfoAbsRemark);
			this.groupControl_VisitInfo.Controls.Add(this.notePanel_VisInfoVisMode);
			this.groupControl_VisitInfo.Controls.Add(this.notePanel_VisInfoAbsReason);
			this.groupControl_VisitInfo.Controls.Add(this.comboBoxEdit_VisInfoVisMode);
			this.groupControl_VisitInfo.Controls.Add(this.notePanel_VisInfoVisDate);
			this.groupControl_VisitInfo.Controls.Add(this.dateEdit_VisInfoVisDate);
			this.groupControl_VisitInfo.Controls.Add(this.comboBoxEdit_VisInfoAbsReason);
			this.groupControl_VisitInfo.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_VisitInfo.Location = new System.Drawing.Point(0, 40);
			this.groupControl_VisitInfo.Name = "groupControl_VisitInfo";
			this.groupControl_VisitInfo.Size = new System.Drawing.Size(559, 168);
			this.groupControl_VisitInfo.TabIndex = 2;
			this.groupControl_VisitInfo.Text = "家访详细信息";
			this.groupControl_VisitInfo.Visible = false;
			// 
			// memoEdit_VisInfoAbsRemark
			// 
			this.memoEdit_VisInfoAbsRemark.EditValue = "";
			this.memoEdit_VisInfoAbsRemark.Location = new System.Drawing.Point(211, 32);
			this.memoEdit_VisInfoAbsRemark.Name = "memoEdit_VisInfoAbsRemark";
			this.memoEdit_VisInfoAbsRemark.Size = new System.Drawing.Size(320, 104);
			this.memoEdit_VisInfoAbsRemark.TabIndex = 115;
			// 
			// notePanel_VisInfoVisMode
			// 
			this.notePanel_VisInfoVisMode.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_VisInfoVisMode.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_VisInfoVisMode.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_VisInfoVisMode.ForeColor = System.Drawing.Color.Black;
			this.notePanel_VisInfoVisMode.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_VisInfoVisMode.Location = new System.Drawing.Point(19, 72);
			this.notePanel_VisInfoVisMode.MaxRows = 5;
			this.notePanel_VisInfoVisMode.Name = "notePanel_VisInfoVisMode";
			this.notePanel_VisInfoVisMode.ParentAutoHeight = true;
			this.notePanel_VisInfoVisMode.Size = new System.Drawing.Size(80, 22);
			this.notePanel_VisInfoVisMode.TabIndex = 111;
			this.notePanel_VisInfoVisMode.TabStop = false;
			this.notePanel_VisInfoVisMode.Text = "访问方式:";
			// 
			// notePanel_VisInfoAbsReason
			// 
			this.notePanel_VisInfoAbsReason.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_VisInfoAbsReason.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_VisInfoAbsReason.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_VisInfoAbsReason.ForeColor = System.Drawing.Color.Black;
			this.notePanel_VisInfoAbsReason.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_VisInfoAbsReason.Location = new System.Drawing.Point(19, 32);
			this.notePanel_VisInfoAbsReason.MaxRows = 5;
			this.notePanel_VisInfoAbsReason.Name = "notePanel_VisInfoAbsReason";
			this.notePanel_VisInfoAbsReason.ParentAutoHeight = true;
			this.notePanel_VisInfoAbsReason.Size = new System.Drawing.Size(80, 22);
			this.notePanel_VisInfoAbsReason.TabIndex = 109;
			this.notePanel_VisInfoAbsReason.TabStop = false;
			this.notePanel_VisInfoAbsReason.Text = "缺席原因:";
			// 
			// comboBoxEdit_VisInfoVisMode
			// 
			this.comboBoxEdit_VisInfoVisMode.EditValue = "上门";
			this.comboBoxEdit_VisInfoVisMode.Location = new System.Drawing.Point(115, 72);
			this.comboBoxEdit_VisInfoVisMode.Name = "comboBoxEdit_VisInfoVisMode";
			// 
			// comboBoxEdit_VisInfoVisMode.Properties
			// 
			this.comboBoxEdit_VisInfoVisMode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_VisInfoVisMode.Properties.Items.AddRange(new object[] {
																						"上门",
																						"电话"});
			this.comboBoxEdit_VisInfoVisMode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_VisInfoVisMode.Size = new System.Drawing.Size(80, 23);
			this.comboBoxEdit_VisInfoVisMode.TabIndex = 112;
			// 
			// notePanel_VisInfoVisDate
			// 
			this.notePanel_VisInfoVisDate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_VisInfoVisDate.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_VisInfoVisDate.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_VisInfoVisDate.ForeColor = System.Drawing.Color.Black;
			this.notePanel_VisInfoVisDate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
			this.notePanel_VisInfoVisDate.Location = new System.Drawing.Point(19, 112);
			this.notePanel_VisInfoVisDate.MaxRows = 5;
			this.notePanel_VisInfoVisDate.Name = "notePanel_VisInfoVisDate";
			this.notePanel_VisInfoVisDate.ParentAutoHeight = true;
			this.notePanel_VisInfoVisDate.Size = new System.Drawing.Size(80, 22);
			this.notePanel_VisInfoVisDate.TabIndex = 113;
			this.notePanel_VisInfoVisDate.TabStop = false;
			this.notePanel_VisInfoVisDate.Text = "访问时间:";
			// 
			// dateEdit_VisInfoVisDate
			// 
			this.dateEdit_VisInfoVisDate.EditValue = new System.DateTime(2005, 4, 11, 0, 0, 0, 0);
			this.dateEdit_VisInfoVisDate.Location = new System.Drawing.Point(115, 112);
			this.dateEdit_VisInfoVisDate.Name = "dateEdit_VisInfoVisDate";
			// 
			// dateEdit_VisInfoVisDate.Properties
			// 
			this.dateEdit_VisInfoVisDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit_VisInfoVisDate.Properties.Mask.EditMask = "d";
			this.dateEdit_VisInfoVisDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
			this.dateEdit_VisInfoVisDate.Size = new System.Drawing.Size(80, 23);
			this.dateEdit_VisInfoVisDate.TabIndex = 114;
			// 
			// comboBoxEdit_VisInfoAbsReason
			// 
			this.comboBoxEdit_VisInfoAbsReason.EditValue = "患病";
			this.comboBoxEdit_VisInfoAbsReason.Location = new System.Drawing.Point(115, 32);
			this.comboBoxEdit_VisInfoAbsReason.Name = "comboBoxEdit_VisInfoAbsReason";
			// 
			// comboBoxEdit_VisInfoAbsReason.Properties
			// 
			this.comboBoxEdit_VisInfoAbsReason.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_VisInfoAbsReason.Properties.Items.AddRange(new object[] {
																						  "患病",
																						  "家中有人",
																						  "走亲戚",
																						  "其他"});
			this.comboBoxEdit_VisInfoAbsReason.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_VisInfoAbsReason.Size = new System.Drawing.Size(80, 23);
			this.comboBoxEdit_VisInfoAbsReason.TabIndex = 110;
			// 
			// gridControl_VisitInfo
			// 
			this.gridControl_VisitInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl_VisitInfo.EmbeddedNavigator
			// 
			this.gridControl_VisitInfo.EmbeddedNavigator.Name = "";
			this.gridControl_VisitInfo.Location = new System.Drawing.Point(0, 40);
			this.gridControl_VisitInfo.MainView = this.gridView2;
			this.gridControl_VisitInfo.Name = "gridControl_VisitInfo";
			this.gridControl_VisitInfo.Size = new System.Drawing.Size(559, 446);
			this.gridControl_VisitInfo.TabIndex = 1;
			this.gridControl_VisitInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																												 this.gridView2});
			// 
			// gridView2
			// 
			this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn4,
																							 this.gridColumn5,
																							 this.gridColumn6,
																							 this.gridColumn7,
																							 this.gridColumn8,
																							 this.gridColumn9,
																							 this.gridColumn10,
																							 this.gridColumn11,
																							 this.gridColumn12});
			this.gridView2.GridControl = this.gridControl_VisitInfo;
			this.gridView2.Name = "gridView2";
			this.gridView2.OptionsCustomization.AllowFilter = false;
			this.gridView2.OptionsView.ShowFilterPanel = false;
			this.gridView2.OptionsView.ShowGroupPanel = false;
			this.gridView2.DoubleClick += new System.EventHandler(this.gridView2_DoubleClick);
			this.gridView2.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView2_FocusedRowChanged);
			// 
			// gridColumn4
			// 
			this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gridColumn4.AppearanceCell.Options.UseFont = true;
			this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn4.Caption = "序号";
			this.gridColumn4.FieldName = "info_stuOrderNumber";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.OptionsColumn.AllowEdit = false;
			this.gridColumn4.OptionsColumn.AllowFocus = false;
			this.gridColumn4.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn4.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn4.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn4.OptionsColumn.AllowMove = false;
			this.gridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn4.OptionsColumn.FixedWidth = true;
			this.gridColumn4.OptionsColumn.ReadOnly = true;
			this.gridColumn4.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 0;
			this.gridColumn4.Width = 48;
			// 
			// gridColumn5
			// 
			this.gridColumn5.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gridColumn5.AppearanceCell.Options.UseFont = true;
			this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn5.Caption = "班级";
			this.gridColumn5.FieldName = "info_className";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.OptionsColumn.AllowEdit = false;
			this.gridColumn5.OptionsColumn.AllowFocus = false;
			this.gridColumn5.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn5.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn5.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn5.OptionsColumn.AllowMove = false;
			this.gridColumn5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn5.OptionsColumn.FixedWidth = true;
			this.gridColumn5.OptionsColumn.ReadOnly = true;
			this.gridColumn5.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn5.Visible = true;
			this.gridColumn5.VisibleIndex = 1;
			this.gridColumn5.Width = 53;
			// 
			// gridColumn6
			// 
			this.gridColumn6.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gridColumn6.AppearanceCell.Options.UseFont = true;
			this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn6.Caption = "学号";
			this.gridColumn6.FieldName = "info_stuNumber";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.OptionsColumn.AllowEdit = false;
			this.gridColumn6.OptionsColumn.AllowFocus = false;
			this.gridColumn6.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn6.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn6.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn6.OptionsColumn.AllowMove = false;
			this.gridColumn6.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn6.OptionsColumn.FixedWidth = true;
			this.gridColumn6.OptionsColumn.ReadOnly = true;
			this.gridColumn6.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 2;
			this.gridColumn6.Width = 49;
			// 
			// gridColumn7
			// 
			this.gridColumn7.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gridColumn7.AppearanceCell.Options.UseFont = true;
			this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn7.Caption = "姓名";
			this.gridColumn7.FieldName = "info_stuName";
			this.gridColumn7.Name = "gridColumn7";
			this.gridColumn7.OptionsColumn.AllowEdit = false;
			this.gridColumn7.OptionsColumn.AllowFocus = false;
			this.gridColumn7.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn7.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn7.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn7.OptionsColumn.AllowMove = false;
			this.gridColumn7.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn7.OptionsColumn.FixedWidth = true;
			this.gridColumn7.OptionsColumn.ReadOnly = true;
			this.gridColumn7.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn7.Visible = true;
			this.gridColumn7.VisibleIndex = 3;
			this.gridColumn7.Width = 51;
			// 
			// gridColumn8
			// 
			this.gridColumn8.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gridColumn8.AppearanceCell.Options.UseFont = true;
			this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn8.Caption = "家访日期";
			this.gridColumn8.DisplayFormat.FormatString = "yyyy-MM-dd";
			this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.gridColumn8.FieldName = "info_visitDate";
			this.gridColumn8.Name = "gridColumn8";
			this.gridColumn8.OptionsColumn.AllowEdit = false;
			this.gridColumn8.OptionsColumn.AllowFocus = false;
			this.gridColumn8.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn8.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn8.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn8.OptionsColumn.AllowMove = false;
			this.gridColumn8.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn8.OptionsColumn.FixedWidth = true;
			this.gridColumn8.OptionsColumn.ReadOnly = true;
			this.gridColumn8.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn8.Visible = true;
			this.gridColumn8.VisibleIndex = 4;
			// 
			// gridColumn9
			// 
			this.gridColumn9.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gridColumn9.AppearanceCell.Options.UseFont = true;
			this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn9.Caption = "访问方式";
			this.gridColumn9.FieldName = "info_visitMode";
			this.gridColumn9.Name = "gridColumn9";
			this.gridColumn9.OptionsColumn.AllowEdit = false;
			this.gridColumn9.OptionsColumn.AllowFocus = false;
			this.gridColumn9.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn9.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn9.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn9.OptionsColumn.AllowMove = false;
			this.gridColumn9.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn9.OptionsColumn.FixedWidth = true;
			this.gridColumn9.OptionsColumn.ReadOnly = true;
			this.gridColumn9.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn9.Visible = true;
			this.gridColumn9.VisibleIndex = 5;
			this.gridColumn9.Width = 60;
			// 
			// gridColumn10
			// 
			this.gridColumn10.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gridColumn10.AppearanceCell.Options.UseFont = true;
			this.gridColumn10.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn10.Caption = "缺席原因";
			this.gridColumn10.FieldName = "info_absReason";
			this.gridColumn10.Name = "gridColumn10";
			this.gridColumn10.OptionsColumn.AllowEdit = false;
			this.gridColumn10.OptionsColumn.AllowFocus = false;
			this.gridColumn10.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn10.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn10.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn10.OptionsColumn.AllowMove = false;
			this.gridColumn10.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn10.OptionsColumn.FixedWidth = true;
			this.gridColumn10.OptionsColumn.ReadOnly = true;
			this.gridColumn10.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn10.Visible = true;
			this.gridColumn10.VisibleIndex = 6;
			this.gridColumn10.Width = 58;
			// 
			// gridColumn11
			// 
			this.gridColumn11.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gridColumn11.AppearanceCell.Options.UseFont = true;
			this.gridColumn11.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn11.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn11.Caption = "教师签名";
			this.gridColumn11.FieldName = "info_visitTeaSign";
			this.gridColumn11.Name = "gridColumn11";
			this.gridColumn11.OptionsColumn.AllowEdit = false;
			this.gridColumn11.OptionsColumn.AllowFocus = false;
			this.gridColumn11.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn11.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn11.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn11.OptionsColumn.AllowMove = false;
			this.gridColumn11.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn11.OptionsColumn.FixedWidth = true;
			this.gridColumn11.OptionsColumn.ReadOnly = true;
			this.gridColumn11.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn11.Visible = true;
			this.gridColumn11.VisibleIndex = 7;
			this.gridColumn11.Width = 63;
			// 
			// gridColumn12
			// 
			this.gridColumn12.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gridColumn12.AppearanceCell.Options.UseFont = true;
			this.gridColumn12.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn12.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn12.Caption = "详细信息";
			this.gridColumn12.FieldName = "info_absRemark";
			this.gridColumn12.Name = "gridColumn12";
			this.gridColumn12.OptionsColumn.AllowEdit = false;
			this.gridColumn12.OptionsColumn.AllowFocus = false;
			this.gridColumn12.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn12.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn12.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn12.OptionsColumn.AllowMove = false;
			this.gridColumn12.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn12.OptionsColumn.FixedWidth = true;
			this.gridColumn12.OptionsColumn.ReadOnly = true;
			this.gridColumn12.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn12.Visible = true;
			this.gridColumn12.VisibleIndex = 8;
			// 
			// panelControl2
			// 
			this.panelControl2.Controls.Add(this.simpleButton_VisitInfoPrint);
			this.panelControl2.Controls.Add(this.simpleButton_VisitInfoBack);
			this.panelControl2.Controls.Add(this.simpleButton_VisitInfoDelete);
			this.panelControl2.Controls.Add(this.simpleButton_VisitInfoSearch);
			this.panelControl2.Controls.Add(this.simpleButton_VisitInfoModify);
			this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl2.Location = new System.Drawing.Point(0, 0);
			this.panelControl2.Name = "panelControl2";
			this.panelControl2.Size = new System.Drawing.Size(559, 40);
			this.panelControl2.TabIndex = 0;
			this.panelControl2.Text = "panelControl2";
			// 
			// simpleButton_VisitInfoPrint
			// 
			this.simpleButton_VisitInfoPrint.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_VisitInfoPrint.Appearance.Options.UseForeColor = true;
			this.simpleButton_VisitInfoPrint.Location = new System.Drawing.Point(336, 8);
			this.simpleButton_VisitInfoPrint.Name = "simpleButton_VisitInfoPrint";
			this.simpleButton_VisitInfoPrint.Size = new System.Drawing.Size(72, 26);
			this.simpleButton_VisitInfoPrint.TabIndex = 19;
			this.simpleButton_VisitInfoPrint.Text = "报  表";
			this.simpleButton_VisitInfoPrint.Click += new System.EventHandler(this.simpleButton_VisitInfoPrint_Click);
			// 
			// simpleButton_VisitInfoBack
			// 
			this.simpleButton_VisitInfoBack.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_VisitInfoBack.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_VisitInfoBack.Appearance.Options.UseFont = true;
			this.simpleButton_VisitInfoBack.Appearance.Options.UseForeColor = true;
			this.simpleButton_VisitInfoBack.Location = new System.Drawing.Point(16, 8);
			this.simpleButton_VisitInfoBack.Name = "simpleButton_VisitInfoBack";
			this.simpleButton_VisitInfoBack.Size = new System.Drawing.Size(72, 26);
			this.simpleButton_VisitInfoBack.TabIndex = 18;
			this.simpleButton_VisitInfoBack.Tag = 4;
			this.simpleButton_VisitInfoBack.Text = "返  回";
			this.simpleButton_VisitInfoBack.Click += new System.EventHandler(this.simpleButton_VisitInfoBack_Click);
			// 
			// simpleButton_VisitInfoDelete
			// 
			this.simpleButton_VisitInfoDelete.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_VisitInfoDelete.Appearance.Options.UseForeColor = true;
			this.simpleButton_VisitInfoDelete.Location = new System.Drawing.Point(256, 8);
			this.simpleButton_VisitInfoDelete.Name = "simpleButton_VisitInfoDelete";
			this.simpleButton_VisitInfoDelete.Size = new System.Drawing.Size(72, 26);
			this.simpleButton_VisitInfoDelete.TabIndex = 17;
			this.simpleButton_VisitInfoDelete.Text = "删  除";
			this.simpleButton_VisitInfoDelete.Click += new System.EventHandler(this.simpleButton_VisitInfoDelete_Click);
			// 
			// simpleButton_VisitInfoSearch
			// 
			this.simpleButton_VisitInfoSearch.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_VisitInfoSearch.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_VisitInfoSearch.Appearance.Options.UseFont = true;
			this.simpleButton_VisitInfoSearch.Appearance.Options.UseForeColor = true;
			this.simpleButton_VisitInfoSearch.Location = new System.Drawing.Point(96, 8);
			this.simpleButton_VisitInfoSearch.Name = "simpleButton_VisitInfoSearch";
			this.simpleButton_VisitInfoSearch.Size = new System.Drawing.Size(72, 26);
			this.simpleButton_VisitInfoSearch.TabIndex = 14;
			this.simpleButton_VisitInfoSearch.Tag = 4;
			this.simpleButton_VisitInfoSearch.Text = "检  索";
			this.simpleButton_VisitInfoSearch.Click += new System.EventHandler(this.simpleButton_VisitInfoSearch_Click);
			// 
			// simpleButton_VisitInfoModify
			// 
			this.simpleButton_VisitInfoModify.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_VisitInfoModify.Appearance.Options.UseForeColor = true;
			this.simpleButton_VisitInfoModify.Location = new System.Drawing.Point(176, 8);
			this.simpleButton_VisitInfoModify.Name = "simpleButton_VisitInfoModify";
			this.simpleButton_VisitInfoModify.Size = new System.Drawing.Size(72, 26);
			this.simpleButton_VisitInfoModify.TabIndex = 16;
			this.simpleButton_VisitInfoModify.Text = "修  改";
			this.simpleButton_VisitInfoModify.Click += new System.EventHandler(this.simpleButton_VisitInfoModify_Click);
			// 
			// notePanel_VisitInfoPanel
			// 
			this.notePanel_VisitInfoPanel.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel_VisitInfoPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel_VisitInfoPanel.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel_VisitInfoPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_VisitInfoPanel.Location = new System.Drawing.Point(0, 0);
			this.notePanel_VisitInfoPanel.MaxRows = 5;
			this.notePanel_VisitInfoPanel.Name = "notePanel_VisitInfoPanel";
			this.notePanel_VisitInfoPanel.ParentAutoHeight = true;
			this.notePanel_VisitInfoPanel.Size = new System.Drawing.Size(768, 23);
			this.notePanel_VisitInfoPanel.TabIndex = 10;
			this.notePanel_VisitInfoPanel.TabStop = false;
			this.notePanel_VisitInfoPanel.Text = "家访信息检索与修改";
			// 
			// StudentVisitInfo
			// 
			this.Controls.Add(this.xtraTabControl1);
			this.Name = "StudentVisitInfo";
			this.Size = new System.Drawing.Size(772, 540);
			this.Load += new System.EventHandler(this.StudentVisitInfo_Load);
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
			this.xtraTabControl1.ResumeLayout(false);
			this.xtraTabPage_InfoMgmt.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl_Mgmt)).EndInit();
			this.splitContainerControl_Mgmt.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl_Mgmt)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MgmtClass)).EndInit();
			this.groupControl_MgmtClass.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_MgmtDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_MgmtClass.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_MgmtGrade.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_VisitInfoInput)).EndInit();
			this.groupControl_VisitInfoInput.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.memoEdit_MgmtAbsRemark.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_MgmtVisState.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_MgmtVisDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_MgmtAbsReason.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MgmtParentLink)).EndInit();
			this.groupControl_MgmtParentLink.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MgmtMOWorkingAddr.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MgmtMOPhone.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MgmtMOName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MgmtFAWorkingAddr.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MgmtFAPhone.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MgmtFAName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MgmtFamilyAddr.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			this.xtraTabPage_InfoQuery.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
			this.splitContainerControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl_VisitInfoClass)).EndInit();
			this.groupControl_VisitInfoClass.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.textEdit_VisitInfoNumber.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_VisitInfoName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_VisitInfoEndDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_VisitInfoBegDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_VisitInfoClass.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_VisitInfoGrade.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_VisitInfo)).EndInit();
			this.groupControl_VisitInfo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.memoEdit_VisInfoAbsRemark.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_VisInfoVisMode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_VisInfoVisDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_VisInfoAbsReason.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_VisitInfo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
			this.panelControl2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void StudentVisitInfo_Load(object sender, System.EventArgs e)
		{
			#region 时间初始化
			dateEdit_MgmtDate.EditValue = DateTime.Now.Date;
			dateEdit_MgmtVisDate.EditValue = DateTime.Now.Date;
			dateEdit_VisInfoVisDate.EditValue = DateTime.Now.Date;
			dateEdit_VisitInfoBegDate.EditValue = DateTime.Now.Date;
			dateEdit_VisitInfoEndDate.EditValue = DateTime.Now.Date;
			#endregion

			//晨检年级处理
			foreach(DataRow getGradeList in getStuInfoByCondition.getGradeInfo("","").Tables[0].Rows)
			{
				comboBoxEdit_MgmtGrade.Properties.Items.AddRange(
					new object[]{getGradeList[1].ToString()});
			}

			foreach(DataRow getGradeList in getStuInfoByCondition.getGradeInfo("","").Tables[0].Rows)
			{
				comboBoxEdit_VisitInfoGrade.Properties.Items.AddRange(
					new object[]{getGradeList[1].ToString()});
			}

			this.simpleButton_MgmtSave.Enabled = false;
			this.simpleButton_VisitInfoDelete.Enabled = false;
			this.simpleButton_VisitInfoModify.Enabled = false;

			#region 权限初始化
			if ( Thread.CurrentPrincipal.Identity.Name.ToLower() == "admin" || Thread.CurrentPrincipal.IsInRole("保健") )
			{
				simpleButton_MgmtSave.Enabled = false;
				simpleButton_VisitInfoBack.Enabled = false;
				simpleButton_VisitInfoDelete.Enabled = false;
				simpleButton_VisitInfoModify.Enabled = false;
				simpleButton_VisitInfoPrint.Enabled = false;
			}

			if ( Thread.CurrentPrincipal.IsInRole("班主任") )
			{
				DataSet dsRolesDuty = rolesSystem.GetRolesDuty(Convert.ToInt32(Thread.CurrentPrincipal.Identity.Name));
				string gradeName = dsRolesDuty.Tables[0].Rows[0][0].ToString();
				string className = dsRolesDuty.Tables[0].Rows[0][1].ToString();

				comboBoxEdit_MgmtGrade.Properties.Items.Clear();
				comboBoxEdit_MgmtGrade.Properties.Items.AddRange(new object[]{gradeName});
				comboBoxEdit_MgmtGrade.SelectedItem = gradeName;
				comboBoxEdit_MgmtClass.Properties.Items.Clear();
				comboBoxEdit_MgmtClass.Properties.Items.AddRange(new object[]{className});
				comboBoxEdit_MgmtClass.SelectedItem = className;

				comboBoxEdit_VisitInfoGrade.Properties.Items.Clear();
				comboBoxEdit_VisitInfoGrade.Properties.Items.AddRange(new object[]{gradeName});
				comboBoxEdit_VisitInfoGrade.SelectedItem = gradeName;
				comboBoxEdit_VisitInfoClass.Properties.Items.Clear();
				comboBoxEdit_VisitInfoClass.Properties.Items.AddRange(new object[]{className});
				comboBoxEdit_VisitInfoClass.SelectedItem = className;
			}
			#endregion
		}

		private void comboBoxEdit_MgmtGrade_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			comboBoxEdit_MgmtClass.Properties.Items.Clear();
			comboBoxEdit_MgmtClass.Properties.Items.AddRange(new object[]{"全部"});
			comboBoxEdit_MgmtClass.SelectedItem = "全部";
			if ( getStuInfoByCondition.getGradeInfo(comboBoxEdit_MgmtGrade.SelectedItem.ToString(),"").Tables[0].Rows.Count>0 )
			{
				getMgmtGradeFromCombo = getStuInfoByCondition.getGradeInfo(
					comboBoxEdit_MgmtGrade.SelectedItem.ToString(),"").Tables[0].Rows[0][0].ToString();
				foreach(DataRow getClassList in getStuInfoByCondition.getClassInfo("","",
					getMgmtGradeFromCombo).Tables[0].Rows)
				{
					comboBoxEdit_MgmtClass.Properties.Items.AddRange(
						new object[]{getClassList[1].ToString()});
				}
			}
		}

		private void comboBoxEdit_MgmtClass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(!comboBoxEdit_MgmtClass.SelectedItem.ToString().Equals("全部"))
				getMgmtClassFromCombo = getStuInfoByCondition.getClassInfo(
					comboBoxEdit_MgmtClass.SelectedItem.ToString(),"","").Tables[0].Rows[0][0].ToString();
		}

		private void simpleButton_Mgmt2DaysAbs_Click(object sender, System.EventArgs e)
		{
			UnDataBindings();
			if(comboBoxEdit_MgmtGrade.SelectedItem.ToString().Equals("全部"))
			{
				TextDataBindings("","",(DateTime)dateEdit_MgmtDate.EditValue);
			}
			else if ( comboBoxEdit_MgmtClass.SelectedItem.ToString().Equals("全部") ) 
			{
				TextDataBindings(getMgmtGradeFromCombo,"",(DateTime)dateEdit_MgmtDate.EditValue);
			}
			else
			{
				TextDataBindings(getMgmtGradeFromCombo,getMgmtClassFromCombo,(DateTime)dateEdit_MgmtDate.EditValue);
			}

			if ( Thread.CurrentPrincipal.Identity.Name.ToLower() != "admin" || Thread.CurrentPrincipal.IsInRole("保健"))
				this.simpleButton_MgmtSave.Enabled = true;
	
		}

		private void simpleButton_MgmtSave_Click(object sender, System.EventArgs e)
		{
			string message = "是否确认保存这些数据？";
			string caption = "消息提示框!";
			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult == DialogResult.Yes )
			{
				if ( gridView1.RowCount != 0 )
				{
					stuVisitInfoSystem.GetNumber(Convert.ToInt32(gridView1.GetDataRow(
						gridView1.GetSelectedRows()[0])[0]));
					stuVisitInfoSystem.GetReason(comboBoxEdit_MgmtAbsReason.SelectedItem.ToString());
					stuVisitInfoSystem.GetMode(comboBoxEdit_MgmtVisState.SelectedItem.ToString());
					stuVisitInfoSystem.GetDate((DateTime)dateEdit_MgmtVisDate.EditValue);
					///
					///权限
					///
					stuVisitInfoSystem.GetSign(healthManagementSystem.GetTeaName(Thread.CurrentPrincipal.Identity.Name));

					//////
					stuVisitInfoSystem.GetRemark(memoEdit_MgmtAbsRemark.Text);	
	
					if ( stuVisitInfoSystem.DoAbsenceInfoInsert() == 1 )
						MessageBox.Show("您要保存记录的信息已经存在！");
					else if ( stuVisitInfoSystem.DoAbsenceInfoInsert() == -1 )
						MessageBox.Show("保存出错，请重试。如果错误仍旧存在，请重新启动软件！");
					else
						MessageBox.Show("保存完毕！");
				}
				else
					MessageBox.Show("没有指定幼儿，保存失败！");
			}
		}

		private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
		
			memoEdit_MgmtAbsRemark.Text = stuVisitInfoSystem.GetAbsenceDetailInMonth(Convert.ToInt32(gridView1.GetDataRow(
				gridView1.GetSelectedRows()[0])[0]),(DateTime)dateEdit_MgmtDate.EditValue);
		}


		private void comboBoxEdit_VisitInfoGrade_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			comboBoxEdit_VisitInfoClass.Properties.Items.Clear();
			comboBoxEdit_VisitInfoClass.Properties.Items.AddRange(new object[]{"全部"});
			comboBoxEdit_VisitInfoClass.SelectedItem = "全部";
			if ( getStuInfoByCondition.getGradeInfo(comboBoxEdit_VisitInfoGrade.SelectedItem.ToString(),"").Tables[0].Rows.Count>0 )
			{
				getVisInfoGradeFromCombo = getStuInfoByCondition.getGradeInfo(
					comboBoxEdit_VisitInfoGrade.SelectedItem.ToString(),"").Tables[0].Rows[0][0].ToString();
				foreach(DataRow getClassList in getStuInfoByCondition.getClassInfo("","",
					getVisInfoGradeFromCombo).Tables[0].Rows)
				{
					comboBoxEdit_VisitInfoClass.Properties.Items.AddRange(
						new object[]{getClassList[1].ToString()});
				}
			}
		}

		private void comboBoxEdit_VisitInfoClass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(!comboBoxEdit_VisitInfoClass.SelectedItem.ToString().Equals("全部"))
				getVisInfoClassFromCombo = getStuInfoByCondition.getClassInfo(
					comboBoxEdit_VisitInfoClass.SelectedItem.ToString(),"","").Tables[0].Rows[0][0].ToString();
		}

		private void simpleButton_VisitInfoSearch_Click(object sender, System.EventArgs e)
		{
			if ( dateEdit_VisitInfoBegDate.DateTime.Date <= dateEdit_VisitInfoEndDate.DateTime.Date )
			{
				if(textEdit_VisitInfoName.Text.Equals("")  && textEdit_VisitInfoNumber.Text.Equals(""))
				{
					if(comboBoxEdit_VisitInfoGrade.SelectedItem.ToString().Equals("全部"))
					{
						DetailAbsUnBindings();
						DetailAbsBindings("","","","",(DateTime)dateEdit_VisitInfoBegDate.EditValue,
							(DateTime)dateEdit_VisitInfoEndDate.EditValue);
					}
					
					else if ( comboBoxEdit_VisitInfoClass.SelectedItem.ToString().Equals("全部") )
					{
						DetailAbsUnBindings();
						DetailAbsBindings(getVisInfoGradeFromCombo,"","","",
							(DateTime)dateEdit_VisitInfoBegDate.EditValue,(DateTime)dateEdit_VisitInfoEndDate.EditValue);
					}

					else
					{
						DetailAbsUnBindings();
						DetailAbsBindings(getVisInfoGradeFromCombo,getVisInfoClassFromCombo,"","",
							(DateTime)dateEdit_VisitInfoBegDate.EditValue,(DateTime)dateEdit_VisitInfoEndDate.EditValue);
					}
				}
				else
				{
					if ( textEdit_VisitInfoNumber.Text.Equals("") )
					{
						DetailAbsUnBindings();
						DetailAbsBindings("","",textEdit_VisitInfoName.Text.Replace(" ",""),"",
							(DateTime)dateEdit_VisitInfoBegDate.EditValue,(DateTime)dateEdit_VisitInfoEndDate.EditValue);
					}

					else
					{
						DetailAbsUnBindings();
						DetailAbsBindings("","","",textEdit_VisitInfoNumber.Text.Replace(" ",""),
							(DateTime)dateEdit_VisitInfoBegDate.EditValue,(DateTime)dateEdit_VisitInfoEndDate.EditValue);
					}
				}

				if ( gridView2.RowCount > 0  )
					GetSourceValue();
			}

			if ( Thread.CurrentPrincipal.Identity.Name.ToLower() != "admin" || Thread.CurrentPrincipal.IsInRole("保健") )
				this.simpleButton_VisitInfoDelete.Enabled = true;
		}

		private void simpleButton_VisitInfoModify_Click(object sender, System.EventArgs e)
		{
			string message = "是否确认更改这些数据？";
			string caption = "消息提示框!";
			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult == DialogResult.Yes )
			{
				stuVisitInfoSystem.GetNumber(Convert.ToInt32(gridView2.GetDataRow(gridView2.GetSelectedRows()[0])[0]));
				stuVisitInfoSystem.GetSourceReason(getSourceReason);
				stuVisitInfoSystem.GetSourceMode(getSourceMode);
				stuVisitInfoSystem.GetSourceDate(getSourceDate);
				stuVisitInfoSystem.GetSourceSign(getSourceSign);
				stuVisitInfoSystem.GetSourceRemark(getSourceRemark);
				stuVisitInfoSystem.GetReason(comboBoxEdit_VisInfoAbsReason.SelectedItem.ToString());
				stuVisitInfoSystem.GetMode(comboBoxEdit_VisInfoVisMode.SelectedItem.ToString());
				///
				///权限
				///
				stuVisitInfoSystem.GetSign(healthManagementSystem.GetTeaName(Thread.CurrentPrincipal.Identity.Name));
				stuVisitInfoSystem.GetDate((DateTime)dateEdit_VisInfoVisDate.EditValue);
				stuVisitInfoSystem.GetRemark(memoEdit_VisInfoAbsRemark.Text);

				stuVisitInfoSystem.DoAbsenceInfoUpdate();
				MessageBox.Show("更新完毕！");
			}
			
			simpleButton_VisitInfoBack.PerformClick();
		}

		private void simpleButton_VisitInfoDelete_Click(object sender, System.EventArgs e)
		{
			string message = "是否确认删除这些数据？";
			string caption = "消息提示框!";
			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult == DialogResult.Yes )
			{
				stuVisitInfoSystem.GetNumber(Convert.ToInt32(gridView2.GetDataRow(gridView2.GetSelectedRows()[0])[0]));
				stuVisitInfoSystem.GetSourceReason(getSourceReason);
				stuVisitInfoSystem.GetSourceMode(getSourceMode);
				stuVisitInfoSystem.GetSourceDate(getSourceDate);
//				stuVisitInfoSystem.GetSourceSign(getSourceSign);
//				stuVisitInfoSystem.GetSourceRemark(getSourceRemark);

				stuVisitInfoSystem.DoAbsenceInfoDelete();
				MessageBox.Show("删除完毕！");
			}
			simpleButton_VisitInfoSearch.PerformClick();
		}

		private void simpleButton_VisitInfoBack_Click(object sender, System.EventArgs e)
		{
			gridControl_VisitInfo.Visible = true;
			groupControl_VisitInfo.Visible = false;

			simpleButton_VisitInfoSearch.Enabled = true;
			simpleButton_VisitInfoModify.Enabled = false;
			simpleButton_VisitInfoDelete.Enabled = true;
			simpleButton_VisitInfoSearch.PerformClick();
		}

		private void simpleButton_VisitInfoPrint_Click(object sender, System.EventArgs e)
		{
			if ( dsAbsDetailInfo != null )
			{
				string savePath;
				saveFileDialog_Report.Filter = "Excel文件|*.xls";

				if ( saveFileDialog_Report.ShowDialog() != DialogResult.OK )
					return;

				savePath = saveFileDialog_Report.FileName;

				MessageBox.Show("即将生成报表，按确定之后请稍候！");

				stuVisitInfoPrintSystem.VisitInfoPrint(dsAbsDetailInfo,dateEdit_VisitInfoBegDate.DateTime.Date,
					dateEdit_VisitInfoEndDate.DateTime.Date,savePath);

				MessageBox.Show("报表生成完毕！");
			}
			else
				MessageBox.Show("报表生成之前，请先做数据统计！");
		}

		private void simpleButton_VisitInfoHelp_Click(object sender, System.EventArgs e)
		{
		}

		
		private void gridView2_DoubleClick(object sender, System.EventArgs e)
		{
			if ( Thread.CurrentPrincipal.Identity.Name.ToLower() != "admin" || Thread.CurrentPrincipal.IsInRole("保健") ) 
			{
				gridControl_VisitInfo.Visible = false;
				groupControl_VisitInfo.Visible = true;

				simpleButton_VisitInfoSearch.Enabled = false;
				simpleButton_VisitInfoDelete.Enabled = false;
				simpleButton_VisitInfoModify.Enabled = true;
			}
		}

		private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			GetSourceValue();
		}

		private void TextDataBindings(string getGrade,string getClass,DateTime getDate)
		{
			DataSet dsVisitInfo = stuVisitInfoSystem.Get2DaysAbsence(getGrade,getClass,getDate);
			if ( dsVisitInfo.Tables[0].Rows.Count == 0 )
			{
				dataNavigator_Mgmt.DataSource = null;
				gridControl_Mgmt.DataSource = null;
				memoEdit_MgmtAbsRemark.EditValue = null;
				ParentInfoClear();
			}
			else
			{
				dataNavigator_Mgmt.DataSource = dsVisitInfo.Tables[0];
				gridControl_Mgmt.DataSource = dsVisitInfo.Tables[0];
			
				textEdit_MgmtFAName.DataBindings.Add("EditValue",dsVisitInfo.Tables[0],"info_stuFatherName");
				textEdit_MgmtFAWorkingAddr.DataBindings.Add("EditValue",dsVisitInfo.Tables[0],"info_stuFatherWorkPlace");
				textEdit_MgmtFAPhone.DataBindings.Add("EditValue",dsVisitInfo.Tables[0],"info_stuFatherLinkPhone");
				textEdit_MgmtMOName.DataBindings.Add("EditValue",dsVisitInfo.Tables[0],"info_stuMotherName");
				textEdit_MgmtMOWorkingAddr.DataBindings.Add("EditValue",dsVisitInfo.Tables[0],"info_stuMotherWorkPlace");
				textEdit_MgmtMOPhone.DataBindings.Add("EditValue",dsVisitInfo.Tables[0],"info_stuMotherLinkPhone");
				textEdit_MgmtFamilyAddr.DataBindings.Add("EditValue",dsVisitInfo.Tables[0],"info_stuFamilyAddr");
			}

		}

		private void UnDataBindings()
		{
			textEdit_MgmtFamilyAddr.DataBindings.Clear();
			textEdit_MgmtFAName.DataBindings.Clear();
			textEdit_MgmtFAPhone.DataBindings.Clear();
			textEdit_MgmtFAWorkingAddr.DataBindings.Clear();
			textEdit_MgmtMOName.DataBindings.Clear();
			textEdit_MgmtMOPhone.DataBindings.Clear();
			textEdit_MgmtMOWorkingAddr.DataBindings.Clear();
		}

		private void ParentInfoClear()
		{
			textEdit_MgmtFamilyAddr.EditValue = null;
			textEdit_MgmtFAName.EditValue = null;
			textEdit_MgmtFAPhone.EditValue = null;
			textEdit_MgmtFAWorkingAddr.EditValue = null;
			textEdit_MgmtMOName.EditValue = null;
			textEdit_MgmtMOPhone.EditValue = null;
			textEdit_MgmtMOWorkingAddr.EditValue = null;
		}

		private void DetailAbsBindings(string getGrade,string getClass,string getName,string getNumber,
			DateTime getBegDate,DateTime getEndDate)
		{
			dsAbsDetailInfo = stuVisitInfoSystem.GetAbsenceDetail(getGrade,getClass,getName,getNumber,
				getBegDate,getEndDate);
		
			if ( Thread.CurrentPrincipal.IsInRole("班主任") )
			{
				if ( dsAbsDetailInfo.Tables[0].Rows.Count > 0 )
				{
					foreach(DataRow matchRow in dsAbsDetailInfo.Tables[0].Rows)
					{
						if ( !matchRow["info_className"].Equals(rolesSystem.GetRolesDuty(Convert.ToInt32(Thread.CurrentPrincipal.Identity.Name)).Tables[0].Rows[0][1].ToString()) )
							matchRow.Delete();
					}
				}
			}

			if ( dsAbsDetailInfo.Tables[0].Rows.Count == 0 )
				gridControl_VisitInfo.DataSource = null;
			else
			{
				gridControl_VisitInfo.DataSource = dsAbsDetailInfo.Tables[0];

				comboBoxEdit_VisInfoAbsReason.DataBindings.Add("EditValue",dsAbsDetailInfo.Tables[0],"info_absReason");
				comboBoxEdit_VisInfoVisMode.DataBindings.Add("EditValue",dsAbsDetailInfo.Tables[0],"info_visitMode");
				dateEdit_VisInfoVisDate.DataBindings.Add("EditValue",dsAbsDetailInfo.Tables[0],"info_visitDate");
				memoEdit_VisInfoAbsRemark.DataBindings.Add("EditValue",dsAbsDetailInfo.Tables[0],"info_absRemark");
			}
		}

		private void DetailAbsUnBindings()
		{
			comboBoxEdit_VisInfoAbsReason.DataBindings.Clear();
			comboBoxEdit_VisInfoVisMode.DataBindings.Clear();
			dateEdit_VisInfoVisDate.DataBindings.Clear();
			memoEdit_VisInfoAbsRemark.DataBindings.Clear();
		}

		private void GetSourceValue()
		{
			getSourceReason = gridView2.GetDataRow(gridView2.GetSelectedRows()[0])[5].ToString();
			getSourceMode  = gridView2.GetDataRow(gridView2.GetSelectedRows()[0])[4].ToString();
			getSourceDate = Convert.ToDateTime(gridView2.GetDataRow(gridView2.GetSelectedRows()[0])[3]);
			///
			///权限
			///
			getSourceSign = healthManagementSystem.GetTeaName(Thread.CurrentPrincipal.Identity.Name);
			getSourceRemark = gridView2.GetDataRow(gridView2.GetSelectedRows()[0])[7].ToString();
		}

		private void simpleButton_MgmtHelp_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}

