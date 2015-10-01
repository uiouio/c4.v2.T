using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using CPTT.BusinessFacade;
using DevExpress.XtraEditors;

namespace CPTT.WinUI.Panels
{
	/// <summary>
	/// Summary description for FinanManagement2.
	/// </summary>
	public class FinanManagement2 : DevExpress.XtraEditors.XtraUserControl
	{
		private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
		private DevExpress.XtraEditors.GroupControl groupControl_FinanQuery;
		private DevExpress.XtraEditors.DateEdit dateEdit_BalanceMonth;
		private DevExpress.Utils.Frames.NotePanel notePanel_BalanceMonth;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Class;
		private DevExpress.Utils.Frames.NotePanel notePanel_Class;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Grade;
		private DevExpress.Utils.Frames.NotePanel notePanel_Grade;
		private DevExpress.Utils.Frames.NotePanel notePanel_FinanQuery;
		private DevExpress.XtraEditors.MemoEdit memoEdit_Remark;
		private DevExpress.XtraEditors.TextEdit textEdit_ExtraCharge;
		private DevExpress.Utils.Frames.NotePanel notePanel_ExtraCharge;
		private DevExpress.Utils.Frames.NotePanel notePanel_CommCharge;
		private DevExpress.XtraEditors.TextEdit textEdit_CommCharge;
		private DevExpress.XtraEditors.TextEdit textEdit_MilkCharge;
		private DevExpress.XtraEditors.TextEdit textEdit_NightCharge;
		private DevExpress.Utils.Frames.NotePanel notePanel_MilkCharge;
		private DevExpress.Utils.Frames.NotePanel notePanel_NightCharge;
		private DevExpress.XtraEditors.TextEdit textEdit_AdmCharge;
		private DevExpress.Utils.Frames.NotePanel notePanel_AdmCharge;
		private DevExpress.XtraEditors.TextEdit textEdit_MessCharge;
		private DevExpress.Utils.Frames.NotePanel notePanel_MessCharge;
		private DevExpress.XtraEditors.TextEdit textEdit_AdmRestoreDays;
		private DevExpress.Utils.Frames.NotePanel notePanel_AdmRestoreDays;
		private DevExpress.XtraEditors.TextEdit textEdit_MessRestoreDays;
		private DevExpress.Utils.Frames.NotePanel notePanel_MessRestoreDays;
		private DevExpress.XtraEditors.GroupControl groupControl_FinanInfo;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.Utils.Frames.NotePanel notePanel1;
		private DevExpress.XtraEditors.PanelControl panelControl2;
		private DevExpress.XtraBars.BarManager barManager1;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
		private DevExpress.XtraEditors.RadioGroup radioGroup_mode;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_template;
		private DevExpress.XtraEditors.SimpleButton btnStat;
		private GetStuInfoByCondition getStuInfoByCondition;
		private FinanInfoSystem finanInfoSystem;
		private FinanMgmtInfoPrintSystem finanMgmtInfoPrintSystem;
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		DataTable dtGrade = null;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private DevExpress.XtraEditors.SimpleButton btnConfirm;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
		private DevExpress.XtraEditors.GroupControl groupControl2;
		private DevExpress.XtraEditors.DateEdit dateEdit_BalanceMonth2;
		private DevExpress.Utils.Frames.NotePanel notePanel2;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_class2;
		private DevExpress.Utils.Frames.NotePanel notePanel3;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_grade2;
		private DevExpress.Utils.Frames.NotePanel notePanel4;
		private DevExpress.Utils.Frames.NotePanel notePanel5;
		private DevExpress.Utils.Frames.NotePanel notePanel6;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_template2;
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private DevExpress.XtraEditors.SimpleButton btnSearch;
		private DevExpress.XtraGrid.GridControl gridControl2;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraEditors.SimpleButton btnReport2;
		private DevExpress.XtraEditors.SimpleButton btnReport;
		private int _templateId = 0;
		private DataTable _dtForReport1 = null;
		private System.Windows.Forms.SaveFileDialog saveFileDialog_Report;
		private DataTable _dtForReport2 = null;

		public FinanManagement2()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call

			getStuInfoByCondition = new GetStuInfoByCondition();
			finanInfoSystem = new FinanInfoSystem();
			finanMgmtInfoPrintSystem = new FinanMgmtInfoPrintSystem();

			dtGrade = getStuInfoByCondition.getGradeInfo("","").Tables[0];

			foreach(DataRow getGradeList in dtGrade.Rows)
			{
				comboBoxEdit_Grade.Properties.Items.AddRange(
					new object[]{getGradeList[1].ToString()});
			}
			comboBoxEdit_Grade.SelectedIndex = 0;

			foreach(DataRow getGradeList in dtGrade.Rows)
			{
				comboBoxEdit_grade2.Properties.Items.AddRange(
					new object[]{getGradeList[1].ToString()});
			}
			comboBoxEdit_grade2.SelectedIndex = 0;


			dateEdit_BalanceMonth.EditValue = DateTime.Now.Date;
			dateEdit_BalanceMonth2.EditValue = DateTime.Now.Date;

			if ( Thread.CurrentPrincipal.Identity.Name.ToLower() == "admin" )
			{
				btnStat.Enabled = false;
				btnSearch.Enabled = false;
				btnReport2.Enabled = false;
			}

			InitTemplate();

			Finan2Details.OnSaveSucceeded += new Finan2Details.SaveSucceedHandler(InitTemplate);
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
			this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
			this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.btnConfirm = new DevExpress.XtraEditors.SimpleButton();
			this.radioGroup_mode = new DevExpress.XtraEditors.RadioGroup();
			this.notePanel1 = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_template = new DevExpress.XtraEditors.ComboBoxEdit();
			this.groupControl_FinanQuery = new DevExpress.XtraEditors.GroupControl();
			this.dateEdit_BalanceMonth = new DevExpress.XtraEditors.DateEdit();
			this.notePanel_BalanceMonth = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_Class = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_Class = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_Grade = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_Grade = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_FinanQuery = new DevExpress.Utils.Frames.NotePanel();
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
			this.btnReport = new DevExpress.XtraEditors.SimpleButton();
			this.btnStat = new DevExpress.XtraEditors.SimpleButton();
			this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
			this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
			this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
			this.notePanel6 = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_template2 = new DevExpress.XtraEditors.ComboBoxEdit();
			this.dateEdit_BalanceMonth2 = new DevExpress.XtraEditors.DateEdit();
			this.notePanel2 = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_class2 = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel3 = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_grade2 = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel4 = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel5 = new DevExpress.Utils.Frames.NotePanel();
			this.gridControl2 = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.btnReport2 = new DevExpress.XtraEditors.SimpleButton();
			this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
			this.memoEdit_Remark = new DevExpress.XtraEditors.MemoEdit();
			this.textEdit_ExtraCharge = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_ExtraCharge = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_CommCharge = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_CommCharge = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_MilkCharge = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_NightCharge = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_MilkCharge = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_NightCharge = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_AdmCharge = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_AdmCharge = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_MessCharge = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_MessCharge = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_AdmRestoreDays = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_AdmRestoreDays = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_MessRestoreDays = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_MessRestoreDays = new DevExpress.Utils.Frames.NotePanel();
			this.groupControl_FinanInfo = new DevExpress.XtraEditors.GroupControl();
			this.barManager1 = new DevExpress.XtraBars.BarManager();
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			this.saveFileDialog_Report = new System.Windows.Forms.SaveFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
			this.xtraTabControl1.SuspendLayout();
			this.xtraTabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
			this.splitContainerControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.radioGroup_mode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_template.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_FinanQuery)).BeginInit();
			this.groupControl_FinanQuery.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_BalanceMonth.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Class.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Grade.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
			this.panelControl2.SuspendLayout();
			this.xtraTabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
			this.splitContainerControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
			this.groupControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_template2.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_BalanceMonth2.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_class2.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_grade2.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit_Remark.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_ExtraCharge.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_CommCharge.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MilkCharge.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_NightCharge.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_AdmCharge.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MessCharge.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_AdmRestoreDays.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MessRestoreDays.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_FinanInfo)).BeginInit();
			this.groupControl_FinanInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
			this.SuspendLayout();
			// 
			// xtraTabControl1
			// 
			this.xtraTabControl1.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.xtraTabControl1.Appearance.Options.UseBackColor = true;
			this.xtraTabControl1.AppearancePage.HeaderActive.ForeColor = System.Drawing.Color.DarkOrange;
			this.xtraTabControl1.AppearancePage.HeaderActive.Options.UseForeColor = true;
			this.xtraTabControl1.Controls.Add(this.xtraTabPage1);
			this.xtraTabControl1.Controls.Add(this.xtraTabPage2);
			this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
			this.xtraTabControl1.Name = "xtraTabControl1";
			this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
			this.xtraTabControl1.Size = new System.Drawing.Size(772, 540);
			this.xtraTabControl1.TabIndex = 0;
			this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
																							this.xtraTabPage1,
																							this.xtraTabPage2});
			this.xtraTabControl1.Text = "xtraTabControl1";
			// 
			// xtraTabPage1
			// 
			this.xtraTabPage1.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
			this.xtraTabPage1.Appearance.PageClient.Options.UseBackColor = true;
			this.xtraTabPage1.Controls.Add(this.splitContainerControl1);
			this.xtraTabPage1.Name = "xtraTabPage1";
			this.xtraTabPage1.Size = new System.Drawing.Size(768, 515);
			this.xtraTabPage1.Text = "财务统计";
			// 
			// splitContainerControl1
			// 
			this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
			this.splitContainerControl1.Name = "splitContainerControl1";
			this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1);
			this.splitContainerControl1.Panel1.Controls.Add(this.groupControl_FinanQuery);
			this.splitContainerControl1.Panel1.Text = "splitContainerControl1_Panel1";
			this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
			this.splitContainerControl1.Panel2.Controls.Add(this.panelControl2);
			this.splitContainerControl1.Panel2.Text = "splitContainerControl1_Panel2";
			this.splitContainerControl1.Size = new System.Drawing.Size(768, 515);
			this.splitContainerControl1.SplitterPosition = 202;
			this.splitContainerControl1.TabIndex = 0;
			this.splitContainerControl1.Text = "splitContainerControl1";
			// 
			// groupControl1
			// 
			this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl1.AppearanceCaption.Options.UseFont = true;
			this.groupControl1.Controls.Add(this.btnConfirm);
			this.groupControl1.Controls.Add(this.radioGroup_mode);
			this.groupControl1.Controls.Add(this.notePanel1);
			this.groupControl1.Controls.Add(this.comboBoxEdit_template);
			this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl1.Location = new System.Drawing.Point(0, 152);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(196, 357);
			this.groupControl1.TabIndex = 2;
			this.groupControl1.Text = "财务信息";
			// 
			// btnConfirm
			// 
			this.btnConfirm.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnConfirm.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.btnConfirm.Appearance.Options.UseFont = true;
			this.btnConfirm.Appearance.Options.UseForeColor = true;
			this.btnConfirm.Location = new System.Drawing.Point(16, 96);
			this.btnConfirm.Name = "btnConfirm";
			this.btnConfirm.Size = new System.Drawing.Size(72, 26);
			this.btnConfirm.TabIndex = 47;
			this.btnConfirm.Tag = 4;
			this.btnConfirm.Text = "执行操作";
			this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
			// 
			// radioGroup_mode
			// 
			this.radioGroup_mode.EditValue = 1;
			this.radioGroup_mode.Location = new System.Drawing.Point(16, 56);
			this.radioGroup_mode.Name = "radioGroup_mode";
			// 
			// radioGroup_mode.Properties
			// 
			this.radioGroup_mode.Properties.Columns = 3;
			this.radioGroup_mode.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
																													new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "修改"),
																													new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "添加"),
																													new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "删除")});
			this.radioGroup_mode.Size = new System.Drawing.Size(152, 32);
			this.radioGroup_mode.TabIndex = 46;
			// 
			// notePanel1
			// 
			this.notePanel1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel1.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel1.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel1.ForeColor = System.Drawing.Color.Black;
			this.notePanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel1.Location = new System.Drawing.Point(16, 24);
			this.notePanel1.MaxRows = 5;
			this.notePanel1.Name = "notePanel1";
			this.notePanel1.ParentAutoHeight = true;
			this.notePanel1.Size = new System.Drawing.Size(64, 22);
			this.notePanel1.TabIndex = 44;
			this.notePanel1.TabStop = false;
			this.notePanel1.Text = "模  板:";
			// 
			// comboBoxEdit_template
			// 
			this.comboBoxEdit_template.EditValue = "没有模板";
			this.comboBoxEdit_template.Location = new System.Drawing.Point(88, 24);
			this.comboBoxEdit_template.Name = "comboBoxEdit_template";
			// 
			// comboBoxEdit_template.Properties
			// 
			this.comboBoxEdit_template.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																														  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_template.Properties.Items.AddRange(new object[] {
																				  "没有模板"});
			this.comboBoxEdit_template.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_template.Size = new System.Drawing.Size(80, 23);
			this.comboBoxEdit_template.TabIndex = 0;
			this.comboBoxEdit_template.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_template_SelectedIndexChanged);
			// 
			// groupControl_FinanQuery
			// 
			this.groupControl_FinanQuery.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_FinanQuery.AppearanceCaption.Options.UseFont = true;
			this.groupControl_FinanQuery.Controls.Add(this.dateEdit_BalanceMonth);
			this.groupControl_FinanQuery.Controls.Add(this.notePanel_BalanceMonth);
			this.groupControl_FinanQuery.Controls.Add(this.comboBoxEdit_Class);
			this.groupControl_FinanQuery.Controls.Add(this.notePanel_Class);
			this.groupControl_FinanQuery.Controls.Add(this.comboBoxEdit_Grade);
			this.groupControl_FinanQuery.Controls.Add(this.notePanel_Grade);
			this.groupControl_FinanQuery.Controls.Add(this.notePanel_FinanQuery);
			this.groupControl_FinanQuery.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_FinanQuery.Location = new System.Drawing.Point(0, 0);
			this.groupControl_FinanQuery.Name = "groupControl_FinanQuery";
			this.groupControl_FinanQuery.Size = new System.Drawing.Size(196, 152);
			this.groupControl_FinanQuery.TabIndex = 1;
			this.groupControl_FinanQuery.Text = "信息查询";
			// 
			// dateEdit_BalanceMonth
			// 
			this.dateEdit_BalanceMonth.EditValue = new System.DateTime(2005, 12, 20, 0, 0, 0, 0);
			this.dateEdit_BalanceMonth.Location = new System.Drawing.Point(88, 120);
			this.dateEdit_BalanceMonth.Name = "dateEdit_BalanceMonth";
			// 
			// dateEdit_BalanceMonth.Properties
			// 
			this.dateEdit_BalanceMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																														  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit_BalanceMonth.Properties.DisplayFormat.FormatString = "yyyy年M月";
			this.dateEdit_BalanceMonth.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dateEdit_BalanceMonth.Properties.Mask.EditMask = "d";
			this.dateEdit_BalanceMonth.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
			this.dateEdit_BalanceMonth.Size = new System.Drawing.Size(88, 23);
			this.dateEdit_BalanceMonth.TabIndex = 45;
			// 
			// notePanel_BalanceMonth
			// 
			this.notePanel_BalanceMonth.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_BalanceMonth.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_BalanceMonth.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_BalanceMonth.ForeColor = System.Drawing.Color.Black;
			this.notePanel_BalanceMonth.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_BalanceMonth.Location = new System.Drawing.Point(16, 120);
			this.notePanel_BalanceMonth.MaxRows = 5;
			this.notePanel_BalanceMonth.Name = "notePanel_BalanceMonth";
			this.notePanel_BalanceMonth.ParentAutoHeight = true;
			this.notePanel_BalanceMonth.Size = new System.Drawing.Size(64, 22);
			this.notePanel_BalanceMonth.TabIndex = 43;
			this.notePanel_BalanceMonth.TabStop = false;
			this.notePanel_BalanceMonth.Text = "结算月:";
			// 
			// comboBoxEdit_Class
			// 
			this.comboBoxEdit_Class.EditValue = "";
			this.comboBoxEdit_Class.Location = new System.Drawing.Point(88, 88);
			this.comboBoxEdit_Class.Name = "comboBoxEdit_Class";
			// 
			// comboBoxEdit_Class.Properties
			// 
			this.comboBoxEdit_Class.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_Class.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_Class.Size = new System.Drawing.Size(80, 23);
			this.comboBoxEdit_Class.TabIndex = 38;
			// 
			// notePanel_Class
			// 
			this.notePanel_Class.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_Class.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_Class.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_Class.ForeColor = System.Drawing.Color.Black;
			this.notePanel_Class.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Class.Location = new System.Drawing.Point(16, 88);
			this.notePanel_Class.MaxRows = 5;
			this.notePanel_Class.Name = "notePanel_Class";
			this.notePanel_Class.ParentAutoHeight = true;
			this.notePanel_Class.Size = new System.Drawing.Size(64, 22);
			this.notePanel_Class.TabIndex = 37;
			this.notePanel_Class.TabStop = false;
			this.notePanel_Class.Text = "班  级:";
			// 
			// comboBoxEdit_Grade
			// 
			this.comboBoxEdit_Grade.EditValue = "";
			this.comboBoxEdit_Grade.Location = new System.Drawing.Point(88, 56);
			this.comboBoxEdit_Grade.Name = "comboBoxEdit_Grade";
			// 
			// comboBoxEdit_Grade.Properties
			// 
			this.comboBoxEdit_Grade.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_Grade.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_Grade.Size = new System.Drawing.Size(80, 23);
			this.comboBoxEdit_Grade.TabIndex = 36;
			this.comboBoxEdit_Grade.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_Grade_SelectedIndexChanged);
			// 
			// notePanel_Grade
			// 
			this.notePanel_Grade.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_Grade.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_Grade.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_Grade.ForeColor = System.Drawing.Color.Black;
			this.notePanel_Grade.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Grade.Location = new System.Drawing.Point(16, 56);
			this.notePanel_Grade.MaxRows = 5;
			this.notePanel_Grade.Name = "notePanel_Grade";
			this.notePanel_Grade.ParentAutoHeight = true;
			this.notePanel_Grade.Size = new System.Drawing.Size(64, 22);
			this.notePanel_Grade.TabIndex = 35;
			this.notePanel_Grade.TabStop = false;
			this.notePanel_Grade.Text = "年  级:";
			// 
			// notePanel_FinanQuery
			// 
			this.notePanel_FinanQuery.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel_FinanQuery.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel_FinanQuery.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel_FinanQuery.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_FinanQuery.Location = new System.Drawing.Point(3, 18);
			this.notePanel_FinanQuery.MaxRows = 5;
			this.notePanel_FinanQuery.Name = "notePanel_FinanQuery";
			this.notePanel_FinanQuery.ParentAutoHeight = true;
			this.notePanel_FinanQuery.Size = new System.Drawing.Size(190, 23);
			this.notePanel_FinanQuery.TabIndex = 19;
			this.notePanel_FinanQuery.TabStop = false;
			this.notePanel_FinanQuery.Text = "您要查找哪个班级？";
			// 
			// gridControl1
			// 
			this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl1.EmbeddedNavigator
			// 
			this.gridControl1.EmbeddedNavigator.Name = "";
			this.gridControl1.Location = new System.Drawing.Point(0, 40);
			this.gridControl1.MainView = this.gridView2;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.Size = new System.Drawing.Size(556, 469);
			this.gridControl1.TabIndex = 2;
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.gridView2});
			// 
			// gridView2
			// 
			this.gridView2.GridControl = this.gridControl1;
			this.gridView2.Name = "gridView2";
			this.gridView2.OptionsCustomization.AllowFilter = false;
			this.gridView2.OptionsCustomization.AllowGroup = false;
			this.gridView2.OptionsView.ShowFilterPanel = false;
			this.gridView2.OptionsView.ShowGroupPanel = false;
			// 
			// panelControl2
			// 
			this.panelControl2.Controls.Add(this.btnReport);
			this.panelControl2.Controls.Add(this.btnStat);
			this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl2.Location = new System.Drawing.Point(0, 0);
			this.panelControl2.Name = "panelControl2";
			this.panelControl2.Size = new System.Drawing.Size(556, 40);
			this.panelControl2.TabIndex = 1;
			this.panelControl2.Text = "panelControl2";
			// 
			// btnReport
			// 
			this.btnReport.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnReport.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.btnReport.Appearance.Options.UseFont = true;
			this.btnReport.Appearance.Options.UseForeColor = true;
			this.btnReport.Location = new System.Drawing.Point(104, 8);
			this.btnReport.Name = "btnReport";
			this.btnReport.Size = new System.Drawing.Size(72, 26);
			this.btnReport.TabIndex = 10;
			this.btnReport.Tag = 4;
			this.btnReport.Text = "报表";
			this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
			// 
			// btnStat
			// 
			this.btnStat.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnStat.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.btnStat.Appearance.Options.UseFont = true;
			this.btnStat.Appearance.Options.UseForeColor = true;
			this.btnStat.Location = new System.Drawing.Point(16, 8);
			this.btnStat.Name = "btnStat";
			this.btnStat.Size = new System.Drawing.Size(72, 26);
			this.btnStat.TabIndex = 8;
			this.btnStat.Tag = 4;
			this.btnStat.Text = "统计";
			this.btnStat.Click += new System.EventHandler(this.btnStat_Click);
			// 
			// xtraTabPage2
			// 
			this.xtraTabPage2.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
			this.xtraTabPage2.Appearance.PageClient.Options.UseBackColor = true;
			this.xtraTabPage2.Controls.Add(this.splitContainerControl2);
			this.xtraTabPage2.Name = "xtraTabPage2";
			this.xtraTabPage2.Size = new System.Drawing.Size(768, 515);
			this.xtraTabPage2.Text = "历史查询";
			// 
			// splitContainerControl2
			// 
			this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
			this.splitContainerControl2.Name = "splitContainerControl2";
			this.splitContainerControl2.Panel1.Controls.Add(this.groupControl2);
			this.splitContainerControl2.Panel1.Text = "splitContainerControl2_Panel1";
			this.splitContainerControl2.Panel2.Controls.Add(this.gridControl2);
			this.splitContainerControl2.Panel2.Controls.Add(this.panelControl1);
			this.splitContainerControl2.Panel2.Text = "splitContainerControl2_Panel2";
			this.splitContainerControl2.Size = new System.Drawing.Size(768, 515);
			this.splitContainerControl2.SplitterPosition = 201;
			this.splitContainerControl2.TabIndex = 0;
			this.splitContainerControl2.Text = "splitContainerControl2";
			// 
			// groupControl2
			// 
			this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl2.AppearanceCaption.Options.UseFont = true;
			this.groupControl2.Controls.Add(this.notePanel6);
			this.groupControl2.Controls.Add(this.comboBoxEdit_template2);
			this.groupControl2.Controls.Add(this.dateEdit_BalanceMonth2);
			this.groupControl2.Controls.Add(this.notePanel2);
			this.groupControl2.Controls.Add(this.comboBoxEdit_class2);
			this.groupControl2.Controls.Add(this.notePanel3);
			this.groupControl2.Controls.Add(this.comboBoxEdit_grade2);
			this.groupControl2.Controls.Add(this.notePanel4);
			this.groupControl2.Controls.Add(this.notePanel5);
			this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl2.Location = new System.Drawing.Point(0, 0);
			this.groupControl2.Name = "groupControl2";
			this.groupControl2.Size = new System.Drawing.Size(195, 192);
			this.groupControl2.TabIndex = 2;
			this.groupControl2.Text = "信息查询";
			// 
			// notePanel6
			// 
			this.notePanel6.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel6.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel6.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel6.ForeColor = System.Drawing.Color.Black;
			this.notePanel6.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel6.Location = new System.Drawing.Point(16, 120);
			this.notePanel6.MaxRows = 5;
			this.notePanel6.Name = "notePanel6";
			this.notePanel6.ParentAutoHeight = true;
			this.notePanel6.Size = new System.Drawing.Size(64, 22);
			this.notePanel6.TabIndex = 47;
			this.notePanel6.TabStop = false;
			this.notePanel6.Text = "模  板:";
			// 
			// comboBoxEdit_template2
			// 
			this.comboBoxEdit_template2.EditValue = "没有模板";
			this.comboBoxEdit_template2.Location = new System.Drawing.Point(88, 120);
			this.comboBoxEdit_template2.Name = "comboBoxEdit_template2";
			// 
			// comboBoxEdit_template2.Properties
			// 
			this.comboBoxEdit_template2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																														   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_template2.Properties.Items.AddRange(new object[] {
																				   "没有模板"});
			this.comboBoxEdit_template2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_template2.Size = new System.Drawing.Size(80, 23);
			this.comboBoxEdit_template2.TabIndex = 46;
			// 
			// dateEdit_BalanceMonth2
			// 
			this.dateEdit_BalanceMonth2.EditValue = new System.DateTime(2005, 12, 20, 0, 0, 0, 0);
			this.dateEdit_BalanceMonth2.Location = new System.Drawing.Point(88, 152);
			this.dateEdit_BalanceMonth2.Name = "dateEdit_BalanceMonth2";
			// 
			// dateEdit_BalanceMonth2.Properties
			// 
			this.dateEdit_BalanceMonth2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																														   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit_BalanceMonth2.Properties.DisplayFormat.FormatString = "yyyy年M月";
			this.dateEdit_BalanceMonth2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dateEdit_BalanceMonth2.Properties.Mask.EditMask = "d";
			this.dateEdit_BalanceMonth2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
			this.dateEdit_BalanceMonth2.Size = new System.Drawing.Size(88, 23);
			this.dateEdit_BalanceMonth2.TabIndex = 45;
			// 
			// notePanel2
			// 
			this.notePanel2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel2.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel2.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel2.ForeColor = System.Drawing.Color.Black;
			this.notePanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel2.Location = new System.Drawing.Point(16, 152);
			this.notePanel2.MaxRows = 5;
			this.notePanel2.Name = "notePanel2";
			this.notePanel2.ParentAutoHeight = true;
			this.notePanel2.Size = new System.Drawing.Size(64, 22);
			this.notePanel2.TabIndex = 43;
			this.notePanel2.TabStop = false;
			this.notePanel2.Text = "结算月:";
			// 
			// comboBoxEdit_class2
			// 
			this.comboBoxEdit_class2.EditValue = "";
			this.comboBoxEdit_class2.Location = new System.Drawing.Point(88, 88);
			this.comboBoxEdit_class2.Name = "comboBoxEdit_class2";
			// 
			// comboBoxEdit_class2.Properties
			// 
			this.comboBoxEdit_class2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																														new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_class2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_class2.Size = new System.Drawing.Size(80, 23);
			this.comboBoxEdit_class2.TabIndex = 38;
			// 
			// notePanel3
			// 
			this.notePanel3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel3.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel3.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel3.ForeColor = System.Drawing.Color.Black;
			this.notePanel3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel3.Location = new System.Drawing.Point(16, 88);
			this.notePanel3.MaxRows = 5;
			this.notePanel3.Name = "notePanel3";
			this.notePanel3.ParentAutoHeight = true;
			this.notePanel3.Size = new System.Drawing.Size(64, 22);
			this.notePanel3.TabIndex = 37;
			this.notePanel3.TabStop = false;
			this.notePanel3.Text = "班  级:";
			// 
			// comboBoxEdit_grade2
			// 
			this.comboBoxEdit_grade2.EditValue = "";
			this.comboBoxEdit_grade2.Location = new System.Drawing.Point(88, 56);
			this.comboBoxEdit_grade2.Name = "comboBoxEdit_grade2";
			// 
			// comboBoxEdit_grade2.Properties
			// 
			this.comboBoxEdit_grade2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																														new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_grade2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_grade2.Size = new System.Drawing.Size(80, 23);
			this.comboBoxEdit_grade2.TabIndex = 36;
			this.comboBoxEdit_grade2.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_grade2_SelectedIndexChanged);
			// 
			// notePanel4
			// 
			this.notePanel4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel4.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel4.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel4.ForeColor = System.Drawing.Color.Black;
			this.notePanel4.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel4.Location = new System.Drawing.Point(16, 56);
			this.notePanel4.MaxRows = 5;
			this.notePanel4.Name = "notePanel4";
			this.notePanel4.ParentAutoHeight = true;
			this.notePanel4.Size = new System.Drawing.Size(64, 22);
			this.notePanel4.TabIndex = 35;
			this.notePanel4.TabStop = false;
			this.notePanel4.Text = "年  级:";
			// 
			// notePanel5
			// 
			this.notePanel5.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel5.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel5.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel5.Location = new System.Drawing.Point(3, 18);
			this.notePanel5.MaxRows = 5;
			this.notePanel5.Name = "notePanel5";
			this.notePanel5.ParentAutoHeight = true;
			this.notePanel5.Size = new System.Drawing.Size(189, 23);
			this.notePanel5.TabIndex = 19;
			this.notePanel5.TabStop = false;
			this.notePanel5.Text = "您要查找哪个班级？";
			// 
			// gridControl2
			// 
			this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl2.EmbeddedNavigator
			// 
			this.gridControl2.EmbeddedNavigator.Name = "";
			this.gridControl2.Location = new System.Drawing.Point(0, 40);
			this.gridControl2.MainView = this.gridView1;
			this.gridControl2.Name = "gridControl2";
			this.gridControl2.Size = new System.Drawing.Size(557, 469);
			this.gridControl2.TabIndex = 3;
			this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.GridControl = this.gridControl2;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsCustomization.AllowFilter = false;
			this.gridView1.OptionsCustomization.AllowGroup = false;
			this.gridView1.OptionsView.ShowFilterPanel = false;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			// 
			// panelControl1
			// 
			this.panelControl1.Controls.Add(this.btnReport2);
			this.panelControl1.Controls.Add(this.btnSearch);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl1.Location = new System.Drawing.Point(0, 0);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(557, 40);
			this.panelControl1.TabIndex = 2;
			this.panelControl1.Text = "panelControl1";
			// 
			// btnReport2
			// 
			this.btnReport2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnReport2.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.btnReport2.Appearance.Options.UseFont = true;
			this.btnReport2.Appearance.Options.UseForeColor = true;
			this.btnReport2.Location = new System.Drawing.Point(104, 8);
			this.btnReport2.Name = "btnReport2";
			this.btnReport2.Size = new System.Drawing.Size(72, 26);
			this.btnReport2.TabIndex = 9;
			this.btnReport2.Tag = 4;
			this.btnReport2.Text = "报表";
			this.btnReport2.Click += new System.EventHandler(this.btnReport2_Click);
			// 
			// btnSearch
			// 
			this.btnSearch.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnSearch.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.btnSearch.Appearance.Options.UseFont = true;
			this.btnSearch.Appearance.Options.UseForeColor = true;
			this.btnSearch.Location = new System.Drawing.Point(16, 8);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(72, 26);
			this.btnSearch.TabIndex = 8;
			this.btnSearch.Tag = 4;
			this.btnSearch.Text = "查询";
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// memoEdit_Remark
			// 
			this.memoEdit_Remark.EditValue = "";
			this.memoEdit_Remark.Location = new System.Drawing.Point(16, 248);
			this.memoEdit_Remark.Name = "memoEdit_Remark";
			this.memoEdit_Remark.Size = new System.Drawing.Size(160, 72);
			this.memoEdit_Remark.TabIndex = 59;
			// 
			// textEdit_ExtraCharge
			// 
			this.textEdit_ExtraCharge.EditValue = "";
			this.textEdit_ExtraCharge.Location = new System.Drawing.Point(104, 200);
			this.textEdit_ExtraCharge.Name = "textEdit_ExtraCharge";
			this.textEdit_ExtraCharge.Size = new System.Drawing.Size(72, 23);
			this.textEdit_ExtraCharge.TabIndex = 57;
			// 
			// notePanel_ExtraCharge
			// 
			this.notePanel_ExtraCharge.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_ExtraCharge.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_ExtraCharge.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_ExtraCharge.ForeColor = System.Drawing.Color.Black;
			this.notePanel_ExtraCharge.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_ExtraCharge.Location = new System.Drawing.Point(16, 200);
			this.notePanel_ExtraCharge.MaxRows = 5;
			this.notePanel_ExtraCharge.Name = "notePanel_ExtraCharge";
			this.notePanel_ExtraCharge.ParentAutoHeight = true;
			this.notePanel_ExtraCharge.Size = new System.Drawing.Size(80, 22);
			this.notePanel_ExtraCharge.TabIndex = 56;
			this.notePanel_ExtraCharge.TabStop = false;
			this.notePanel_ExtraCharge.Text = " 附加费:";
			// 
			// notePanel_CommCharge
			// 
			this.notePanel_CommCharge.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_CommCharge.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_CommCharge.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_CommCharge.ForeColor = System.Drawing.Color.Black;
			this.notePanel_CommCharge.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_CommCharge.Location = new System.Drawing.Point(16, 176);
			this.notePanel_CommCharge.MaxRows = 5;
			this.notePanel_CommCharge.Name = "notePanel_CommCharge";
			this.notePanel_CommCharge.ParentAutoHeight = true;
			this.notePanel_CommCharge.Size = new System.Drawing.Size(80, 22);
			this.notePanel_CommCharge.TabIndex = 55;
			this.notePanel_CommCharge.TabStop = false;
			this.notePanel_CommCharge.Text = " 代办费:";
			// 
			// textEdit_CommCharge
			// 
			this.textEdit_CommCharge.EditValue = "";
			this.textEdit_CommCharge.Location = new System.Drawing.Point(104, 176);
			this.textEdit_CommCharge.Name = "textEdit_CommCharge";
			this.textEdit_CommCharge.Size = new System.Drawing.Size(72, 23);
			this.textEdit_CommCharge.TabIndex = 54;
			// 
			// textEdit_MilkCharge
			// 
			this.textEdit_MilkCharge.EditValue = "";
			this.textEdit_MilkCharge.Location = new System.Drawing.Point(104, 152);
			this.textEdit_MilkCharge.Name = "textEdit_MilkCharge";
			this.textEdit_MilkCharge.Size = new System.Drawing.Size(72, 23);
			this.textEdit_MilkCharge.TabIndex = 53;
			// 
			// textEdit_NightCharge
			// 
			this.textEdit_NightCharge.EditValue = "";
			this.textEdit_NightCharge.Location = new System.Drawing.Point(104, 128);
			this.textEdit_NightCharge.Name = "textEdit_NightCharge";
			this.textEdit_NightCharge.Size = new System.Drawing.Size(72, 23);
			this.textEdit_NightCharge.TabIndex = 52;
			// 
			// notePanel_MilkCharge
			// 
			this.notePanel_MilkCharge.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MilkCharge.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MilkCharge.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MilkCharge.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MilkCharge.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MilkCharge.Location = new System.Drawing.Point(16, 152);
			this.notePanel_MilkCharge.MaxRows = 5;
			this.notePanel_MilkCharge.Name = "notePanel_MilkCharge";
			this.notePanel_MilkCharge.ParentAutoHeight = true;
			this.notePanel_MilkCharge.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MilkCharge.TabIndex = 51;
			this.notePanel_MilkCharge.TabStop = false;
			this.notePanel_MilkCharge.Text = " 牛奶费:";
			// 
			// notePanel_NightCharge
			// 
			this.notePanel_NightCharge.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_NightCharge.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_NightCharge.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_NightCharge.ForeColor = System.Drawing.Color.Black;
			this.notePanel_NightCharge.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_NightCharge.Location = new System.Drawing.Point(16, 128);
			this.notePanel_NightCharge.MaxRows = 5;
			this.notePanel_NightCharge.Name = "notePanel_NightCharge";
			this.notePanel_NightCharge.ParentAutoHeight = true;
			this.notePanel_NightCharge.Size = new System.Drawing.Size(80, 22);
			this.notePanel_NightCharge.TabIndex = 50;
			this.notePanel_NightCharge.TabStop = false;
			this.notePanel_NightCharge.Text = " 晚托费:";
			// 
			// textEdit_AdmCharge
			// 
			this.textEdit_AdmCharge.EditValue = "";
			this.textEdit_AdmCharge.Location = new System.Drawing.Point(104, 104);
			this.textEdit_AdmCharge.Name = "textEdit_AdmCharge";
			this.textEdit_AdmCharge.Size = new System.Drawing.Size(72, 23);
			this.textEdit_AdmCharge.TabIndex = 49;
			// 
			// notePanel_AdmCharge
			// 
			this.notePanel_AdmCharge.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_AdmCharge.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_AdmCharge.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_AdmCharge.ForeColor = System.Drawing.Color.Black;
			this.notePanel_AdmCharge.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_AdmCharge.Location = new System.Drawing.Point(16, 104);
			this.notePanel_AdmCharge.MaxRows = 5;
			this.notePanel_AdmCharge.Name = "notePanel_AdmCharge";
			this.notePanel_AdmCharge.ParentAutoHeight = true;
			this.notePanel_AdmCharge.Size = new System.Drawing.Size(80, 22);
			this.notePanel_AdmCharge.TabIndex = 48;
			this.notePanel_AdmCharge.TabStop = false;
			this.notePanel_AdmCharge.Text = " 管理费:";
			// 
			// textEdit_MessCharge
			// 
			this.textEdit_MessCharge.EditValue = "";
			this.textEdit_MessCharge.Location = new System.Drawing.Point(104, 80);
			this.textEdit_MessCharge.Name = "textEdit_MessCharge";
			this.textEdit_MessCharge.Size = new System.Drawing.Size(72, 23);
			this.textEdit_MessCharge.TabIndex = 47;
			// 
			// notePanel_MessCharge
			// 
			this.notePanel_MessCharge.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MessCharge.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MessCharge.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MessCharge.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MessCharge.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MessCharge.Location = new System.Drawing.Point(16, 80);
			this.notePanel_MessCharge.MaxRows = 5;
			this.notePanel_MessCharge.Name = "notePanel_MessCharge";
			this.notePanel_MessCharge.ParentAutoHeight = true;
			this.notePanel_MessCharge.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MessCharge.TabIndex = 46;
			this.notePanel_MessCharge.TabStop = false;
			this.notePanel_MessCharge.Text = " 伙食费:";
			// 
			// textEdit_AdmRestoreDays
			// 
			this.textEdit_AdmRestoreDays.EditValue = "";
			this.textEdit_AdmRestoreDays.Location = new System.Drawing.Point(104, 56);
			this.textEdit_AdmRestoreDays.Name = "textEdit_AdmRestoreDays";
			this.textEdit_AdmRestoreDays.Size = new System.Drawing.Size(72, 23);
			this.textEdit_AdmRestoreDays.TabIndex = 45;
			// 
			// notePanel_AdmRestoreDays
			// 
			this.notePanel_AdmRestoreDays.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_AdmRestoreDays.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_AdmRestoreDays.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_AdmRestoreDays.ForeColor = System.Drawing.Color.Black;
			this.notePanel_AdmRestoreDays.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_AdmRestoreDays.Location = new System.Drawing.Point(16, 56);
			this.notePanel_AdmRestoreDays.MaxRows = 5;
			this.notePanel_AdmRestoreDays.Name = "notePanel_AdmRestoreDays";
			this.notePanel_AdmRestoreDays.ParentAutoHeight = true;
			this.notePanel_AdmRestoreDays.Size = new System.Drawing.Size(80, 22);
			this.notePanel_AdmRestoreDays.TabIndex = 44;
			this.notePanel_AdmRestoreDays.TabStop = false;
			this.notePanel_AdmRestoreDays.Text = "退管天数:";
			// 
			// textEdit_MessRestoreDays
			// 
			this.textEdit_MessRestoreDays.EditValue = "";
			this.textEdit_MessRestoreDays.Location = new System.Drawing.Point(104, 32);
			this.textEdit_MessRestoreDays.Name = "textEdit_MessRestoreDays";
			this.textEdit_MessRestoreDays.Size = new System.Drawing.Size(72, 23);
			this.textEdit_MessRestoreDays.TabIndex = 43;
			// 
			// notePanel_MessRestoreDays
			// 
			this.notePanel_MessRestoreDays.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MessRestoreDays.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MessRestoreDays.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MessRestoreDays.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MessRestoreDays.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MessRestoreDays.Location = new System.Drawing.Point(16, 32);
			this.notePanel_MessRestoreDays.MaxRows = 5;
			this.notePanel_MessRestoreDays.Name = "notePanel_MessRestoreDays";
			this.notePanel_MessRestoreDays.ParentAutoHeight = true;
			this.notePanel_MessRestoreDays.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MessRestoreDays.TabIndex = 42;
			this.notePanel_MessRestoreDays.TabStop = false;
			this.notePanel_MessRestoreDays.Text = "退伙天数:";
			// 
			// groupControl_FinanInfo
			// 
			this.groupControl_FinanInfo.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_FinanInfo.AppearanceCaption.Options.UseFont = true;
			this.groupControl_FinanInfo.Controls.Add(this.memoEdit_Remark);
			this.groupControl_FinanInfo.Controls.Add(this.textEdit_ExtraCharge);
			this.groupControl_FinanInfo.Controls.Add(this.notePanel_ExtraCharge);
			this.groupControl_FinanInfo.Controls.Add(this.notePanel_CommCharge);
			this.groupControl_FinanInfo.Controls.Add(this.textEdit_CommCharge);
			this.groupControl_FinanInfo.Controls.Add(this.textEdit_MilkCharge);
			this.groupControl_FinanInfo.Controls.Add(this.textEdit_NightCharge);
			this.groupControl_FinanInfo.Controls.Add(this.notePanel_MilkCharge);
			this.groupControl_FinanInfo.Controls.Add(this.notePanel_NightCharge);
			this.groupControl_FinanInfo.Controls.Add(this.textEdit_AdmCharge);
			this.groupControl_FinanInfo.Controls.Add(this.notePanel_AdmCharge);
			this.groupControl_FinanInfo.Controls.Add(this.textEdit_MessCharge);
			this.groupControl_FinanInfo.Controls.Add(this.notePanel_MessCharge);
			this.groupControl_FinanInfo.Controls.Add(this.textEdit_AdmRestoreDays);
			this.groupControl_FinanInfo.Controls.Add(this.notePanel_AdmRestoreDays);
			this.groupControl_FinanInfo.Controls.Add(this.textEdit_MessRestoreDays);
			this.groupControl_FinanInfo.Controls.Add(this.notePanel_MessRestoreDays);
			this.groupControl_FinanInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl_FinanInfo.Location = new System.Drawing.Point(0, 232);
			this.groupControl_FinanInfo.Name = "groupControl_FinanInfo";
			this.groupControl_FinanInfo.Size = new System.Drawing.Size(192, 277);
			this.groupControl_FinanInfo.TabIndex = 2;
			this.groupControl_FinanInfo.Text = "财务信息";
			// 
			// barManager1
			// 
			this.barManager1.DockControls.Add(this.barDockControlTop);
			this.barManager1.DockControls.Add(this.barDockControlBottom);
			this.barManager1.DockControls.Add(this.barDockControlLeft);
			this.barManager1.DockControls.Add(this.barDockControlRight);
			this.barManager1.Form = this;
			this.barManager1.MaxItemId = 0;
			// 
			// FinanManagement2
			// 
			this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.Appearance.Options.UseBackColor = true;
			this.Controls.Add(this.xtraTabControl1);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlTop);
			this.Name = "FinanManagement2";
			this.Size = new System.Drawing.Size(772, 540);
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
			this.xtraTabControl1.ResumeLayout(false);
			this.xtraTabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
			this.splitContainerControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.radioGroup_mode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_template.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_FinanQuery)).EndInit();
			this.groupControl_FinanQuery.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_BalanceMonth.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Class.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Grade.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
			this.panelControl2.ResumeLayout(false);
			this.xtraTabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
			this.splitContainerControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
			this.groupControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_template2.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_BalanceMonth2.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_class2.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_grade2.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.memoEdit_Remark.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_ExtraCharge.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_CommCharge.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MilkCharge.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_NightCharge.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_AdmCharge.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MessCharge.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_AdmRestoreDays.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MessRestoreDays.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_FinanInfo)).EndInit();
			this.groupControl_FinanInfo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private DataTable DataForReport1
		{
			get
			{
				return _dtForReport1;
			}
		}

		private DataTable DataForReport2
		{
			get
			{
				return _dtForReport2;
			}
		}

		private void InitTemplate()
		{
			DataTable dtTemplate = finanInfoSystem.GetTemplate(null);
			if (dtTemplate != null && dtTemplate.Rows.Count != 0)
			{
				comboBoxEdit_template.Properties.Items.Clear();
				comboBoxEdit_template2.Properties.Items.Clear();
				foreach(DataRow dr in dtTemplate.Rows)
				{
					comboBoxEdit_template.Properties.Items.AddRange(
						new object[]{dr["templateName"].ToString()});
					comboBoxEdit_template2.Properties.Items.AddRange(
						new object[]{dr["templateName"].ToString()});
				}

				comboBoxEdit_template.SelectedIndex = 0;
				comboBoxEdit_template2.SelectedIndex = 0;
				radioGroup_mode.SelectedIndex = -1;
			}
			else
			{
				comboBoxEdit_template.Properties.Items.Clear();
				comboBoxEdit_template.Properties.Items.Add("没有模板");
				comboBoxEdit_template.SelectedIndex = 0;
				comboBoxEdit_template2.Properties.Items.Clear();
				comboBoxEdit_template2.Properties.Items.Add("没有模板");
				comboBoxEdit_template2.SelectedIndex = 0;
			}
		}

		private int TemplateID
		{
			get
			{
				return _templateId;
			}
			set
			{
				_templateId = value;
			}
		}

		private void btnStat_Click(object sender, System.EventArgs e)
		{
			ArrayList list;
			DataTable dtStat = finanInfoSystem.MakingFinanceStat(comboBoxEdit_template.SelectedItem.ToString(), 
				comboBoxEdit_Grade.SelectedItem.ToString(), comboBoxEdit_Class.SelectedItem.ToString(),
				(DateTime)dateEdit_BalanceMonth.EditValue, out list);
			if (dtStat == null || dtStat.Rows.Count == 0)
			{
				MessageBox.Show("数据不存在，请重试！");
			}
			else
			{
				if (dtStat.Columns.Count == 3)
				{
					MessageBox.Show("定义的模板无法用在所选项目上！");
				}
				else
				{
					DataTable dtTemp = dtStat.Copy();
					if (list.Count != 0)
					{
						foreach(string name in list)
						{
							dtTemp.Columns.Remove(name);
						}

						dtTemp.AcceptChanges();

						if (dtTemp.Columns.Count <= 3)
						{
							MessageBox.Show("定义的模板无法用在所选项目上！");
							return;
						}
					}

					try
					{
						gridView2.Columns.Clear();
						gridControl1.DataSource = dtTemp;
						gridControl1.RefreshDataSource();

						_dtForReport1 = dtTemp;
						
						finanInfoSystem.AddFinanceStatTable(comboBoxEdit_template.SelectedItem.ToString(), dtStat.Columns);
						finanInfoSystem.AddFinanceStatHistory(dtStat, comboBoxEdit_template.SelectedItem.ToString(), 
							(DateTime)dateEdit_BalanceMonth.EditValue);
					}
					catch
					{
						MessageBox.Show("统计失败，请重试！");
					}
				}
			}
		}

		private void comboBoxEdit_Grade_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			comboBoxEdit_Class.Properties.Items.Clear();
			if ( getStuInfoByCondition.getGradeInfo(comboBoxEdit_Grade.SelectedItem.ToString(),"").Tables[0].Rows.Count > 0 )
			{
				string getGradeNumberFromCombo = getStuInfoByCondition.getGradeInfo(
					comboBoxEdit_Grade.SelectedItem.ToString(),"").Tables[0].Rows[0][0].ToString();
				foreach(DataRow getClassList in getStuInfoByCondition.getClassInfo("","",
					getGradeNumberFromCombo).Tables[0].Rows)
				{
					comboBoxEdit_Class.Properties.Items.AddRange(
						new object[]{getClassList[1].ToString()});
				}

				comboBoxEdit_Class.SelectedIndex = 0;
			}
		}

		private void comboBoxEdit_template_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DataTable dtTemplate = finanInfoSystem.GetTemplate(comboBoxEdit_template.SelectedItem.ToString());
			if (dtTemplate != null && dtTemplate.Rows.Count != 0)
			{
				TemplateID = Convert.ToInt32(dtTemplate.Rows[0]["templateID"]);
			}
		}

		private void btnConfirm_Click(object sender, System.EventArgs e)
		{
			if (radioGroup_mode.SelectedIndex == 0)
			{
				if (!comboBoxEdit_template.SelectedItem.ToString().Equals("没有模板"))
				{
					Finan2Details finanDetails = new Finan2Details(true, comboBoxEdit_template.SelectedItem.ToString(), TemplateID, dtGrade);
					finanDetails.StartPosition = FormStartPosition.CenterScreen;
					finanDetails.ShowDialog();
				}
				else
				{
					MessageBox.Show("模板不存在，无法进行修改操作！");
				}
			}
			else if (radioGroup_mode.SelectedIndex == 1)
			{
				Finan2Details finanDetails = new Finan2Details(false, string.Empty, 0, dtGrade);
				finanDetails.StartPosition = FormStartPosition.CenterScreen;
				finanDetails.ShowDialog();
			}
			else if (radioGroup_mode.SelectedIndex == 2)
			{
				if (!comboBoxEdit_template.SelectedItem.ToString().Equals("没有模板"))
				{
					DialogResult messageResult = MessageBox.Show("删除模板将删除该模板下的所有数据，是否确认删除选中的模板？","消息提示框！",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
					if (messageResult == DialogResult.Yes)
					{
						try
						{
							finanInfoSystem.DeleteTemplate(comboBoxEdit_template.SelectedItem.ToString());
							gridControl1.DataSource = null;
							InitTemplate();
							MessageBox.Show("删除成功");
						}
						catch
						{
							MessageBox.Show("删除失败，请重试！");
						}
					}
				}
			}
		}

		private void btnReport_Click(object sender, System.EventArgs e)
		{
			DataTable dtReport = DataForReport1.Copy();
			if (dtReport != null && dtReport.Rows.Count > 0)
			{
				if (!dtReport.Columns.Contains("总计"))
				{
					dtReport.Columns.Add(new DataColumn("总计", Type.GetType("System.String")));
				}
				foreach (DataRow dr in dtReport.Rows)
				{
					double total = 0;
					for (int column = 3; column < dtReport.Columns.Count - 1; column++)
					{
						total += Convert.ToDouble(dr[column]);
					}
					dr["总计"] = total.ToString();
				}

				string savePath;
				saveFileDialog_Report.Filter = "Excel文件|*.xls";

				if ( saveFileDialog_Report.ShowDialog() != DialogResult.OK )
					return;

				savePath = saveFileDialog_Report.FileName;
				new FinanMgmtInfoPrintSystem().FinanceStatPrint(dtReport, comboBoxEdit_Class.SelectedItem.ToString(),
					(DateTime)dateEdit_BalanceMonth.EditValue, savePath);

				MessageBox.Show("打印完毕！");
			}
			else
			{
				MessageBox.Show("没有要使用的数据！");
			}
		}

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			DataTable dtTemplateContents = finanInfoSystem.GetTemplateContents(comboBoxEdit_template2.SelectedItem.ToString());
			if (dtTemplateContents == null || dtTemplateContents.Rows.Count == 0)
			{
				MessageBox.Show("没有要使用的数据，请查看模板是否正确！");
			}
			else
			{
				DataTable dtHistory = finanInfoSystem.GetFinanceStatHistory(comboBoxEdit_template2.SelectedItem.ToString(),
					comboBoxEdit_class2.SelectedItem.ToString(), (DateTime)dateEdit_BalanceMonth2.EditValue);
				if (dtHistory == null || dtHistory.Rows.Count == 0)
				{
					MessageBox.Show("没有要使用的数据，请查看班级,时间或模板是否选择正确！");
					return;
				}
				DataTable dtFiltered = finanInfoSystem.FilterTemplateContents(comboBoxEdit_template2.SelectedItem.ToString(),
					comboBoxEdit_grade2.SelectedItem.ToString(), comboBoxEdit_class2.SelectedItem.ToString());
				if (dtFiltered != null && dtFiltered.Rows.Count > 0)
				{
					for (int i = dtHistory.Columns.Count - 2; i >= 3; i--)
					{
						DataRow[] drTemp = dtFiltered.Select(string.Format("name = '{0}' AND grade = '不选择'", 
							dtHistory.Columns[i].ColumnName));
						if (drTemp.Length != 0)
						{
							continue;
						}
						else
						{
							drTemp = dtFiltered.Select(string.Format("name = '{0}' AND grade = '{2}' AND (class = '{1}' OR class = '不选择')", 
								dtHistory.Columns[i].ColumnName, comboBoxEdit_class2.SelectedItem.ToString(), 
								comboBoxEdit_grade2.SelectedItem.ToString()));
							if (drTemp.Length == 0)
							{
								dtHistory.Columns.Remove(dtHistory.Columns[i]);
							}
						}
					}

					dtHistory.AcceptChanges();
				}

				DataTable dtTemp = dtHistory.Copy();
				dtTemp.Columns.RemoveAt(dtTemp.Columns.Count - 1);
				dtTemp.AcceptChanges();

				if (dtTemp.Columns.Count <= 3)
				{
					MessageBox.Show("定义的模板无法用在所选项目上！");
					return;
				}

				_dtForReport2 = dtHistory;

				gridView1.Columns.Clear();
				gridControl2.DataSource = dtTemp;
				gridControl2.RefreshDataSource();
			}
		}

		private void btnReport2_Click(object sender, System.EventArgs e)
		{
			if (DataForReport2 != null && DataForReport2.Rows.Count > 0)
			{
				string savePath;
				saveFileDialog_Report.Filter = "Excel文件|*.xls";

				if ( saveFileDialog_Report.ShowDialog() != DialogResult.OK )
					return;

				savePath = saveFileDialog_Report.FileName;
				new FinanMgmtInfoPrintSystem().FinanceStatPrint(DataForReport2, comboBoxEdit_class2.SelectedItem.ToString(),
					(DateTime)dateEdit_BalanceMonth2.EditValue, savePath);

				MessageBox.Show("打印完毕！");
			}
			else
			{
				MessageBox.Show("没有要使用的数据！");
			}
		}	

		private void comboBoxEdit_grade2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			comboBoxEdit_class2.Properties.Items.Clear();
			if ( getStuInfoByCondition.getGradeInfo(comboBoxEdit_grade2.SelectedItem.ToString(),"").Tables[0].Rows.Count > 0 )
			{
				string getGradeNumberFromCombo = getStuInfoByCondition.getGradeInfo(
					comboBoxEdit_grade2.SelectedItem.ToString(),"").Tables[0].Rows[0][0].ToString();
				foreach(DataRow getClassList in getStuInfoByCondition.getClassInfo("","",
					getGradeNumberFromCombo).Tables[0].Rows)
				{
					comboBoxEdit_class2.Properties.Items.AddRange(
						new object[]{getClassList[1].ToString()});
				}

				comboBoxEdit_class2.SelectedIndex = 0;
			}
		}
	}
}

