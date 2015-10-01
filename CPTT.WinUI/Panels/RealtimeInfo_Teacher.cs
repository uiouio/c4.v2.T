using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using CPTT.BusinessFacade;
using System.Threading;

namespace CPTT.WinUI.Panels
{
	/// <summary>
	/// Summary description for RealtimeInfo_Teacher.
	/// </summary>
	public class RealtimeInfo_Teacher : DevExpress.XtraEditors.XtraUserControl
	{
		private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraEditors.GroupControl groupControl1_Realtime_Data;
		private DevExpress.XtraEditors.GroupControl groupControl_RealtimeStat_Dept;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Realtime_DataState;
		private DevExpress.Utils.Frames.NotePanel notePanel_Realtime_DataState;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Realtime_DataDept;
		private DevExpress.Utils.Frames.NotePanel notePanel_Realtime_DataDept;
		private DevExpress.Utils.Frames.NotePanel notePanel_Realtime_DataSearch;
		private DevExpress.XtraEditors.SimpleButton simpleButton_RealTime_DataSer;
		private DevExpress.XtraEditors.SimpleButton simpleButton_RealTime_DataPrint;
		private DevExpress.XtraGrid.GridControl gridControl_DataMorning;
		private DevExpress.XtraGrid.GridControl gridControl_DataBack;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
		private System.Windows.Forms.SaveFileDialog saveFileDialog_Report;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private RealtimeInfoStat_TeacherSystem realTimeInfoStat_TeacherSystem;
		private string getDeptNameFromCombo = "";
		private string getDataStateFromCombo = "上班情况";
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
		private DevExpress.XtraEditors.PanelControl panelControl2;
		private DevExpress.XtraEditors.GroupControl groupControl_Realtime_Graphic;
		private DevExpress.XtraEditors.GroupControl groupControl_Realtime_GraphicDeptInfo;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Realtime_GraphicState;
		private DevExpress.Utils.Frames.NotePanel notePanel_Realtime_GraphicState;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Realtime_GraphicDept;
		private DevExpress.Utils.Frames.NotePanel notePanel_Realtime_GraphicDept;
		private DevExpress.Utils.Frames.NotePanel notePanel_Realtime_GraphicSearch;
		private DevExpress.XtraEditors.SimpleButton simpleButton_Realtime_GraphicPrint;
		private DevExpress.XtraEditors.GroupControl groupControl_Realtime_GraphicShow;
		private DevExpress.XtraEditors.PanelControl panelControl_Realtime_GraphicShow;
		private DataSet dsRealTimeInfoStat_Teacher;

		private string getDeptNameFromCombo_Graphic = "";
		private string getStateFromCombo_Graphic = "上班情况";
		private Bitmap myImage;
		private DevExpress.XtraEditors.SimpleButton simpleButton_RealTime_GraphicSer;
		private System.Windows.Forms.HelpProvider helpProvider_RealtimeInfo_Teacher;

		private RolesSystem rolesSystem;

		public RealtimeInfo_Teacher()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call
			
			realTimeInfoStat_TeacherSystem = new RealtimeInfoStat_TeacherSystem();
			rolesSystem = new RolesSystem();

			#region 帮助
			helpProvider_RealtimeInfo_Teacher.HelpNamespace = System.IO.Path.GetDirectoryName(Application.ExecutablePath)
				+ CPTT.SystemFramework.Util.HELP_FILE_NAME;

			this.helpProvider_RealtimeInfo_Teacher.SetHelpKeyword(this.xtraTabPage1,"教师图形统计");
			this.helpProvider_RealtimeInfo_Teacher.SetHelpNavigator(this.xtraTabPage1, System.Windows.Forms.HelpNavigator.KeywordIndex);
			this.helpProvider_RealtimeInfo_Teacher.SetHelpString(this.xtraTabPage1, "");
			this.helpProvider_RealtimeInfo_Teacher.SetShowHelp(this.xtraTabPage1, true);

			this.helpProvider_RealtimeInfo_Teacher.SetHelpKeyword(this.xtraTabPage2,"教师数据统计");
			this.helpProvider_RealtimeInfo_Teacher.SetHelpNavigator(this.xtraTabPage2, System.Windows.Forms.HelpNavigator.KeywordIndex);
			this.helpProvider_RealtimeInfo_Teacher.SetHelpString(this.xtraTabPage2, "");
			this.helpProvider_RealtimeInfo_Teacher.SetShowHelp(this.xtraTabPage2, true);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(RealtimeInfo_Teacher));
			this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
			this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
			this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
			this.groupControl_Realtime_Graphic = new DevExpress.XtraEditors.GroupControl();
			this.groupControl_Realtime_GraphicDeptInfo = new DevExpress.XtraEditors.GroupControl();
			this.comboBoxEdit_Realtime_GraphicState = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_Realtime_GraphicState = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_Realtime_GraphicDept = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_Realtime_GraphicDept = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_Realtime_GraphicSearch = new DevExpress.Utils.Frames.NotePanel();
			this.groupControl_Realtime_GraphicShow = new DevExpress.XtraEditors.GroupControl();
			this.panelControl_Realtime_GraphicShow = new DevExpress.XtraEditors.PanelControl();
			this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
			this.simpleButton_RealTime_GraphicSer = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_Realtime_GraphicPrint = new DevExpress.XtraEditors.SimpleButton();
			this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
			this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
			this.groupControl1_Realtime_Data = new DevExpress.XtraEditors.GroupControl();
			this.groupControl_RealtimeStat_Dept = new DevExpress.XtraEditors.GroupControl();
			this.comboBoxEdit_Realtime_DataState = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_Realtime_DataState = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_Realtime_DataDept = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_Realtime_DataDept = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_Realtime_DataSearch = new DevExpress.Utils.Frames.NotePanel();
			this.gridControl_DataBack = new DevExpress.XtraGrid.GridControl();
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridControl_DataMorning = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.simpleButton_RealTime_DataSer = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_RealTime_DataPrint = new DevExpress.XtraEditors.SimpleButton();
			this.saveFileDialog_Report = new System.Windows.Forms.SaveFileDialog();
			this.helpProvider_RealtimeInfo_Teacher = new System.Windows.Forms.HelpProvider();
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
			this.xtraTabControl1.SuspendLayout();
			this.xtraTabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
			this.splitContainerControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_Realtime_Graphic)).BeginInit();
			this.groupControl_Realtime_Graphic.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_Realtime_GraphicDeptInfo)).BeginInit();
			this.groupControl_Realtime_GraphicDeptInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Realtime_GraphicState.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Realtime_GraphicDept.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_Realtime_GraphicShow)).BeginInit();
			this.groupControl_Realtime_GraphicShow.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.panelControl_Realtime_GraphicShow)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
			this.panelControl2.SuspendLayout();
			this.xtraTabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
			this.splitContainerControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1_Realtime_Data)).BeginInit();
			this.groupControl1_Realtime_Data.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_RealtimeStat_Dept)).BeginInit();
			this.groupControl_RealtimeStat_Dept.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Realtime_DataState.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Realtime_DataDept.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_DataBack)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_DataMorning)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// xtraTabControl1
			// 
			this.xtraTabControl1.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.xtraTabControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xtraTabControl1.Appearance.Options.UseBackColor = true;
			this.xtraTabControl1.Appearance.Options.UseFont = true;
			this.xtraTabControl1.AppearancePage.HeaderActive.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xtraTabControl1.AppearancePage.HeaderActive.ForeColor = System.Drawing.Color.DarkOrange;
			this.xtraTabControl1.AppearancePage.HeaderActive.Options.UseFont = true;
			this.xtraTabControl1.AppearancePage.HeaderActive.Options.UseForeColor = true;
			this.xtraTabControl1.AppearancePage.HeaderHotTracked.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xtraTabControl1.AppearancePage.HeaderHotTracked.Options.UseFont = true;
			this.xtraTabControl1.Controls.Add(this.xtraTabPage1);
			this.xtraTabControl1.Controls.Add(this.xtraTabPage2);
			this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
			this.xtraTabControl1.Name = "xtraTabControl1";
			this.xtraTabControl1.SelectedTabPage = this.xtraTabPage2;
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
			this.xtraTabPage1.Controls.Add(this.splitContainerControl2);
			this.xtraTabPage1.Name = "xtraTabPage1";
			this.xtraTabPage1.Size = new System.Drawing.Size(768, 515);
			this.xtraTabPage1.Text = "图形统计";
			// 
			// splitContainerControl2
			// 
			this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
			this.splitContainerControl2.Name = "splitContainerControl2";
			this.splitContainerControl2.Panel1.Controls.Add(this.groupControl_Realtime_Graphic);
			this.splitContainerControl2.Panel1.Text = "splitContainerControl2_Panel1";
			this.splitContainerControl2.Panel2.Controls.Add(this.groupControl_Realtime_GraphicShow);
			this.splitContainerControl2.Panel2.Controls.Add(this.panelControl2);
			this.splitContainerControl2.Panel2.Text = "splitContainerControl2_Panel2";
			this.splitContainerControl2.Size = new System.Drawing.Size(768, 515);
			this.splitContainerControl2.SplitterPosition = 208;
			this.splitContainerControl2.TabIndex = 0;
			this.splitContainerControl2.Text = "splitContainerControl2";
			this.splitContainerControl2.SizeChanged += new System.EventHandler(this.splitContainerControl2_SizeChanged);
			// 
			// groupControl_Realtime_Graphic
			// 
			this.groupControl_Realtime_Graphic.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_Realtime_Graphic.Appearance.Options.UseFont = true;
			this.groupControl_Realtime_Graphic.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_Realtime_Graphic.AppearanceCaption.Options.UseFont = true;
			this.groupControl_Realtime_Graphic.Controls.Add(this.groupControl_Realtime_GraphicDeptInfo);
			this.groupControl_Realtime_Graphic.Controls.Add(this.notePanel_Realtime_GraphicSearch);
			this.groupControl_Realtime_Graphic.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl_Realtime_Graphic.Location = new System.Drawing.Point(0, 0);
			this.groupControl_Realtime_Graphic.Name = "groupControl_Realtime_Graphic";
			this.groupControl_Realtime_Graphic.Size = new System.Drawing.Size(202, 509);
			this.groupControl_Realtime_Graphic.TabIndex = 3;
			this.groupControl_Realtime_Graphic.Text = "实时窗口统计";
			this.groupControl_Realtime_Graphic.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl_Realtime_Graphic_Paint);
			// 
			// groupControl_Realtime_GraphicDeptInfo
			// 
			this.groupControl_Realtime_GraphicDeptInfo.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_Realtime_GraphicDeptInfo.AppearanceCaption.Options.UseFont = true;
			this.groupControl_Realtime_GraphicDeptInfo.Controls.Add(this.comboBoxEdit_Realtime_GraphicState);
			this.groupControl_Realtime_GraphicDeptInfo.Controls.Add(this.notePanel_Realtime_GraphicState);
			this.groupControl_Realtime_GraphicDeptInfo.Controls.Add(this.comboBoxEdit_Realtime_GraphicDept);
			this.groupControl_Realtime_GraphicDeptInfo.Controls.Add(this.notePanel_Realtime_GraphicDept);
			this.groupControl_Realtime_GraphicDeptInfo.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_Realtime_GraphicDeptInfo.Location = new System.Drawing.Point(3, 41);
			this.groupControl_Realtime_GraphicDeptInfo.Name = "groupControl_Realtime_GraphicDeptInfo";
			this.groupControl_Realtime_GraphicDeptInfo.Size = new System.Drawing.Size(196, 119);
			this.groupControl_Realtime_GraphicDeptInfo.TabIndex = 7;
			this.groupControl_Realtime_GraphicDeptInfo.Text = "统计状态和部门信息";
			// 
			// comboBoxEdit_Realtime_GraphicState
			// 
			this.comboBoxEdit_Realtime_GraphicState.EditValue = "上班情况";
			this.comboBoxEdit_Realtime_GraphicState.Location = new System.Drawing.Point(88, 72);
			this.comboBoxEdit_Realtime_GraphicState.Name = "comboBoxEdit_Realtime_GraphicState";
			// 
			// comboBoxEdit_Realtime_GraphicState.Properties
			// 
			this.comboBoxEdit_Realtime_GraphicState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																	   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_Realtime_GraphicState.Properties.Items.AddRange(new object[] {
																							   "上班情况",
																							   "下班情况"});
			this.comboBoxEdit_Realtime_GraphicState.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_Realtime_GraphicState.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_Realtime_GraphicState.TabIndex = 24;
			this.comboBoxEdit_Realtime_GraphicState.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_Realtime_GraphicState_SelectedIndexChanged);
			// 
			// notePanel_Realtime_GraphicState
			// 
			this.notePanel_Realtime_GraphicState.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_Realtime_GraphicState.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_Realtime_GraphicState.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_Realtime_GraphicState.ForeColor = System.Drawing.Color.Black;
			this.notePanel_Realtime_GraphicState.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Realtime_GraphicState.Location = new System.Drawing.Point(16, 72);
			this.notePanel_Realtime_GraphicState.MaxRows = 5;
			this.notePanel_Realtime_GraphicState.Name = "notePanel_Realtime_GraphicState";
			this.notePanel_Realtime_GraphicState.ParentAutoHeight = true;
			this.notePanel_Realtime_GraphicState.Size = new System.Drawing.Size(64, 22);
			this.notePanel_Realtime_GraphicState.TabIndex = 23;
			this.notePanel_Realtime_GraphicState.TabStop = false;
			this.notePanel_Realtime_GraphicState.Text = "类  型:";
			// 
			// comboBoxEdit_Realtime_GraphicDept
			// 
			this.comboBoxEdit_Realtime_GraphicDept.EditValue = "全部";
			this.comboBoxEdit_Realtime_GraphicDept.Location = new System.Drawing.Point(88, 32);
			this.comboBoxEdit_Realtime_GraphicDept.Name = "comboBoxEdit_Realtime_GraphicDept";
			// 
			// comboBoxEdit_Realtime_GraphicDept.Properties
			// 
			this.comboBoxEdit_Realtime_GraphicDept.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																	  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_Realtime_GraphicDept.Properties.Items.AddRange(new object[] {
																							  "全部"});
			this.comboBoxEdit_Realtime_GraphicDept.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_Realtime_GraphicDept.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_Realtime_GraphicDept.TabIndex = 21;
			this.comboBoxEdit_Realtime_GraphicDept.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_Realtime_GraphicDept_SelectedIndexChanged);
			// 
			// notePanel_Realtime_GraphicDept
			// 
			this.notePanel_Realtime_GraphicDept.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_Realtime_GraphicDept.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_Realtime_GraphicDept.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_Realtime_GraphicDept.ForeColor = System.Drawing.Color.Black;
			this.notePanel_Realtime_GraphicDept.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Realtime_GraphicDept.Location = new System.Drawing.Point(16, 32);
			this.notePanel_Realtime_GraphicDept.MaxRows = 5;
			this.notePanel_Realtime_GraphicDept.Name = "notePanel_Realtime_GraphicDept";
			this.notePanel_Realtime_GraphicDept.ParentAutoHeight = true;
			this.notePanel_Realtime_GraphicDept.Size = new System.Drawing.Size(64, 22);
			this.notePanel_Realtime_GraphicDept.TabIndex = 19;
			this.notePanel_Realtime_GraphicDept.TabStop = false;
			this.notePanel_Realtime_GraphicDept.Text = "部  门:";
			// 
			// notePanel_Realtime_GraphicSearch
			// 
			this.notePanel_Realtime_GraphicSearch.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel_Realtime_GraphicSearch.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel_Realtime_GraphicSearch.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.notePanel_Realtime_GraphicSearch.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel_Realtime_GraphicSearch.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Realtime_GraphicSearch.Location = new System.Drawing.Point(3, 18);
			this.notePanel_Realtime_GraphicSearch.MaxRows = 5;
			this.notePanel_Realtime_GraphicSearch.Name = "notePanel_Realtime_GraphicSearch";
			this.notePanel_Realtime_GraphicSearch.ParentAutoHeight = true;
			this.notePanel_Realtime_GraphicSearch.Size = new System.Drawing.Size(196, 23);
			this.notePanel_Realtime_GraphicSearch.TabIndex = 6;
			this.notePanel_Realtime_GraphicSearch.TabStop = false;
			this.notePanel_Realtime_GraphicSearch.Text = "搜索条件";
			// 
			// groupControl_Realtime_GraphicShow
			// 
			this.groupControl_Realtime_GraphicShow.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_Realtime_GraphicShow.AppearanceCaption.Options.UseFont = true;
			this.groupControl_Realtime_GraphicShow.Controls.Add(this.panelControl_Realtime_GraphicShow);
			this.groupControl_Realtime_GraphicShow.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl_Realtime_GraphicShow.Location = new System.Drawing.Point(0, 48);
			this.groupControl_Realtime_GraphicShow.Name = "groupControl_Realtime_GraphicShow";
			this.groupControl_Realtime_GraphicShow.Size = new System.Drawing.Size(550, 461);
			this.groupControl_Realtime_GraphicShow.TabIndex = 1;
			this.groupControl_Realtime_GraphicShow.Text = "图形预览";
			// 
			// panelControl_Realtime_GraphicShow
			// 
			this.panelControl_Realtime_GraphicShow.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.panelControl_Realtime_GraphicShow.Appearance.Options.UseBackColor = true;
			this.panelControl_Realtime_GraphicShow.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelControl_Realtime_GraphicShow.Location = new System.Drawing.Point(3, 18);
			this.panelControl_Realtime_GraphicShow.Name = "panelControl_Realtime_GraphicShow";
			this.panelControl_Realtime_GraphicShow.Size = new System.Drawing.Size(544, 440);
			this.panelControl_Realtime_GraphicShow.TabIndex = 0;
			this.panelControl_Realtime_GraphicShow.Text = "panelControl3";
			this.panelControl_Realtime_GraphicShow.Resize += new System.EventHandler(this.panelControl_Realtime_GraphicShow_Resize);
			// 
			// panelControl2
			// 
			this.panelControl2.Controls.Add(this.simpleButton_RealTime_GraphicSer);
			this.panelControl2.Controls.Add(this.simpleButton_Realtime_GraphicPrint);
			this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl2.Location = new System.Drawing.Point(0, 0);
			this.panelControl2.Name = "panelControl2";
			this.panelControl2.Size = new System.Drawing.Size(550, 48);
			this.panelControl2.TabIndex = 0;
			this.panelControl2.Text = "panelControl2";
			// 
			// simpleButton_RealTime_GraphicSer
			// 
			this.simpleButton_RealTime_GraphicSer.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_RealTime_GraphicSer.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_RealTime_GraphicSer.Appearance.Options.UseFont = true;
			this.simpleButton_RealTime_GraphicSer.Appearance.Options.UseForeColor = true;
			this.simpleButton_RealTime_GraphicSer.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_RealTime_GraphicSer.Image")));
			this.simpleButton_RealTime_GraphicSer.Location = new System.Drawing.Point(16, 12);
			this.simpleButton_RealTime_GraphicSer.Name = "simpleButton_RealTime_GraphicSer";
			this.simpleButton_RealTime_GraphicSer.Size = new System.Drawing.Size(88, 26);
			this.simpleButton_RealTime_GraphicSer.TabIndex = 15;
			this.simpleButton_RealTime_GraphicSer.Tag = 4;
			this.simpleButton_RealTime_GraphicSer.Text = "搜  索";
			this.simpleButton_RealTime_GraphicSer.Click += new System.EventHandler(this.simpleButton_RealTime_GraphicSer_Click);
			// 
			// simpleButton_Realtime_GraphicPrint
			// 
			this.simpleButton_Realtime_GraphicPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_Realtime_GraphicPrint.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_Realtime_GraphicPrint.Appearance.Options.UseFont = true;
			this.simpleButton_Realtime_GraphicPrint.Appearance.Options.UseForeColor = true;
			this.simpleButton_Realtime_GraphicPrint.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_Realtime_GraphicPrint.Image")));
			this.simpleButton_Realtime_GraphicPrint.Location = new System.Drawing.Point(112, 11);
			this.simpleButton_Realtime_GraphicPrint.Name = "simpleButton_Realtime_GraphicPrint";
			this.simpleButton_Realtime_GraphicPrint.Size = new System.Drawing.Size(104, 26);
			this.simpleButton_Realtime_GraphicPrint.TabIndex = 13;
			this.simpleButton_Realtime_GraphicPrint.Tag = 4;
			this.simpleButton_Realtime_GraphicPrint.Text = "图形打印";
			this.simpleButton_Realtime_GraphicPrint.Click += new System.EventHandler(this.simpleButton_Realtime_GraphicPrint_Click);
			// 
			// xtraTabPage2
			// 
			this.xtraTabPage2.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
			this.xtraTabPage2.Appearance.PageClient.Options.UseBackColor = true;
			this.xtraTabPage2.Controls.Add(this.splitContainerControl1);
			this.xtraTabPage2.Name = "xtraTabPage2";
			this.xtraTabPage2.Size = new System.Drawing.Size(768, 515);
			this.xtraTabPage2.Text = "数据统计";
			// 
			// splitContainerControl1
			// 
			this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
			this.splitContainerControl1.Name = "splitContainerControl1";
			this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1_Realtime_Data);
			this.splitContainerControl1.Panel1.Text = "splitContainerControl1_Panel1";
			this.splitContainerControl1.Panel2.Controls.Add(this.gridControl_DataBack);
			this.splitContainerControl1.Panel2.Controls.Add(this.gridControl_DataMorning);
			this.splitContainerControl1.Panel2.Controls.Add(this.panelControl1);
			this.splitContainerControl1.Panel2.Text = "splitContainerControl1_Panel2";
			this.splitContainerControl1.Size = new System.Drawing.Size(768, 515);
			this.splitContainerControl1.SplitterPosition = 217;
			this.splitContainerControl1.TabIndex = 0;
			this.splitContainerControl1.Text = "splitContainerControl1";
			// 
			// groupControl1_Realtime_Data
			// 
			this.groupControl1_Realtime_Data.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl1_Realtime_Data.Appearance.Options.UseFont = true;
			this.groupControl1_Realtime_Data.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl1_Realtime_Data.AppearanceCaption.Options.UseFont = true;
			this.groupControl1_Realtime_Data.Controls.Add(this.groupControl_RealtimeStat_Dept);
			this.groupControl1_Realtime_Data.Controls.Add(this.notePanel_Realtime_DataSearch);
			this.groupControl1_Realtime_Data.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl1_Realtime_Data.Location = new System.Drawing.Point(0, 0);
			this.groupControl1_Realtime_Data.Name = "groupControl1_Realtime_Data";
			this.groupControl1_Realtime_Data.Size = new System.Drawing.Size(211, 509);
			this.groupControl1_Realtime_Data.TabIndex = 2;
			this.groupControl1_Realtime_Data.Text = "实时窗口统计";
			// 
			// groupControl_RealtimeStat_Dept
			// 
			this.groupControl_RealtimeStat_Dept.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_RealtimeStat_Dept.AppearanceCaption.Options.UseFont = true;
			this.groupControl_RealtimeStat_Dept.Controls.Add(this.comboBoxEdit_Realtime_DataState);
			this.groupControl_RealtimeStat_Dept.Controls.Add(this.notePanel_Realtime_DataState);
			this.groupControl_RealtimeStat_Dept.Controls.Add(this.comboBoxEdit_Realtime_DataDept);
			this.groupControl_RealtimeStat_Dept.Controls.Add(this.notePanel_Realtime_DataDept);
			this.groupControl_RealtimeStat_Dept.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_RealtimeStat_Dept.Location = new System.Drawing.Point(3, 41);
			this.groupControl_RealtimeStat_Dept.Name = "groupControl_RealtimeStat_Dept";
			this.groupControl_RealtimeStat_Dept.Size = new System.Drawing.Size(205, 119);
			this.groupControl_RealtimeStat_Dept.TabIndex = 7;
			this.groupControl_RealtimeStat_Dept.Text = "统计状态和部门信息";
			// 
			// comboBoxEdit_Realtime_DataState
			// 
			this.comboBoxEdit_Realtime_DataState.EditValue = "上班情况";
			this.comboBoxEdit_Realtime_DataState.Location = new System.Drawing.Point(88, 72);
			this.comboBoxEdit_Realtime_DataState.Name = "comboBoxEdit_Realtime_DataState";
			// 
			// comboBoxEdit_Realtime_DataState.Properties
			// 
			this.comboBoxEdit_Realtime_DataState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																	new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_Realtime_DataState.Properties.Items.AddRange(new object[] {
																							"上班情况",
																							"下班情况"});
			this.comboBoxEdit_Realtime_DataState.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_Realtime_DataState.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_Realtime_DataState.TabIndex = 24;
			this.comboBoxEdit_Realtime_DataState.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_Realtime_DataState_SelectedIndexChanged);
			// 
			// notePanel_Realtime_DataState
			// 
			this.notePanel_Realtime_DataState.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_Realtime_DataState.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_Realtime_DataState.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_Realtime_DataState.ForeColor = System.Drawing.Color.Black;
			this.notePanel_Realtime_DataState.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Realtime_DataState.Location = new System.Drawing.Point(16, 72);
			this.notePanel_Realtime_DataState.MaxRows = 5;
			this.notePanel_Realtime_DataState.Name = "notePanel_Realtime_DataState";
			this.notePanel_Realtime_DataState.ParentAutoHeight = true;
			this.notePanel_Realtime_DataState.Size = new System.Drawing.Size(64, 22);
			this.notePanel_Realtime_DataState.TabIndex = 23;
			this.notePanel_Realtime_DataState.TabStop = false;
			this.notePanel_Realtime_DataState.Text = "类  型:";
			// 
			// comboBoxEdit_Realtime_DataDept
			// 
			this.comboBoxEdit_Realtime_DataDept.EditValue = "全部";
			this.comboBoxEdit_Realtime_DataDept.Location = new System.Drawing.Point(88, 32);
			this.comboBoxEdit_Realtime_DataDept.Name = "comboBoxEdit_Realtime_DataDept";
			// 
			// comboBoxEdit_Realtime_DataDept.Properties
			// 
			this.comboBoxEdit_Realtime_DataDept.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_Realtime_DataDept.Properties.Items.AddRange(new object[] {
																						   "全部"});
			this.comboBoxEdit_Realtime_DataDept.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_Realtime_DataDept.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_Realtime_DataDept.TabIndex = 21;
			this.comboBoxEdit_Realtime_DataDept.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_Realtime_DataDept_SelectedIndexChanged);
			// 
			// notePanel_Realtime_DataDept
			// 
			this.notePanel_Realtime_DataDept.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_Realtime_DataDept.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_Realtime_DataDept.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_Realtime_DataDept.ForeColor = System.Drawing.Color.Black;
			this.notePanel_Realtime_DataDept.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Realtime_DataDept.Location = new System.Drawing.Point(16, 32);
			this.notePanel_Realtime_DataDept.MaxRows = 5;
			this.notePanel_Realtime_DataDept.Name = "notePanel_Realtime_DataDept";
			this.notePanel_Realtime_DataDept.ParentAutoHeight = true;
			this.notePanel_Realtime_DataDept.Size = new System.Drawing.Size(64, 22);
			this.notePanel_Realtime_DataDept.TabIndex = 19;
			this.notePanel_Realtime_DataDept.TabStop = false;
			this.notePanel_Realtime_DataDept.Text = "部  门:";
			// 
			// notePanel_Realtime_DataSearch
			// 
			this.notePanel_Realtime_DataSearch.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel_Realtime_DataSearch.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel_Realtime_DataSearch.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.notePanel_Realtime_DataSearch.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel_Realtime_DataSearch.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Realtime_DataSearch.Location = new System.Drawing.Point(3, 18);
			this.notePanel_Realtime_DataSearch.MaxRows = 5;
			this.notePanel_Realtime_DataSearch.Name = "notePanel_Realtime_DataSearch";
			this.notePanel_Realtime_DataSearch.ParentAutoHeight = true;
			this.notePanel_Realtime_DataSearch.Size = new System.Drawing.Size(205, 23);
			this.notePanel_Realtime_DataSearch.TabIndex = 6;
			this.notePanel_Realtime_DataSearch.TabStop = false;
			this.notePanel_Realtime_DataSearch.Text = "搜索条件";
			// 
			// gridControl_DataBack
			// 
			this.gridControl_DataBack.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl_DataBack.EmbeddedNavigator
			// 
			this.gridControl_DataBack.EmbeddedNavigator.Name = "";
			this.gridControl_DataBack.Location = new System.Drawing.Point(0, 48);
			this.gridControl_DataBack.MainView = this.gridView2;
			this.gridControl_DataBack.Name = "gridControl_DataBack";
			this.gridControl_DataBack.Size = new System.Drawing.Size(541, 461);
			this.gridControl_DataBack.TabIndex = 2;
			this.gridControl_DataBack.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																												this.gridView2});
			this.gridControl_DataBack.Visible = false;
			// 
			// gridView2
			// 
			this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn8,
																							 this.gridColumn9,
																							 this.gridColumn10,
																							 this.gridColumn11,
																							 this.gridColumn12,
																							 this.gridColumn13});
			this.gridView2.GridControl = this.gridControl_DataBack;
			this.gridView2.Name = "gridView2";
			this.gridView2.OptionsCustomization.AllowFilter = false;
			this.gridView2.OptionsView.ShowFilterPanel = false;
			this.gridView2.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn8
			// 
			this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn8.Caption = "部门";
			this.gridColumn8.FieldName = "info_gradeName";
			this.gridColumn8.Name = "gridColumn8";
			this.gridColumn8.OptionsColumn.AllowEdit = false;
			this.gridColumn8.OptionsColumn.AllowFocus = false;
			this.gridColumn8.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn8.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn8.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn8.OptionsColumn.AllowMove = false;
			this.gridColumn8.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn8.OptionsColumn.ReadOnly = true;
			this.gridColumn8.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn8.Visible = true;
			this.gridColumn8.VisibleIndex = 0;
			this.gridColumn8.Width = 66;
			// 
			// gridColumn9
			// 
			this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn9.Caption = "离开";
			this.gridColumn9.FieldName = "info_leaveOnTime";
			this.gridColumn9.Name = "gridColumn9";
			this.gridColumn9.OptionsColumn.AllowEdit = false;
			this.gridColumn9.OptionsColumn.AllowFocus = false;
			this.gridColumn9.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn9.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn9.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn9.OptionsColumn.AllowMove = false;
			this.gridColumn9.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn9.OptionsColumn.ReadOnly = true;
			this.gridColumn9.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn9.Visible = true;
			this.gridColumn9.VisibleIndex = 1;
			this.gridColumn9.Width = 102;
			// 
			// gridColumn10
			// 
			this.gridColumn10.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn10.Caption = "早退";
			this.gridColumn10.FieldName = "info_leaveNotOnTime";
			this.gridColumn10.Name = "gridColumn10";
			this.gridColumn10.OptionsColumn.AllowEdit = false;
			this.gridColumn10.OptionsColumn.AllowFocus = false;
			this.gridColumn10.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn10.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn10.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn10.OptionsColumn.AllowMove = false;
			this.gridColumn10.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn10.OptionsColumn.ReadOnly = true;
			this.gridColumn10.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn10.Visible = true;
			this.gridColumn10.VisibleIndex = 2;
			this.gridColumn10.Width = 91;
			// 
			// gridColumn11
			// 
			this.gridColumn11.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn11.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn11.Caption = "应离开";
			this.gridColumn11.FieldName = "info_shouldLeave";
			this.gridColumn11.Name = "gridColumn11";
			this.gridColumn11.OptionsColumn.AllowEdit = false;
			this.gridColumn11.OptionsColumn.AllowFocus = false;
			this.gridColumn11.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn11.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn11.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn11.OptionsColumn.AllowMove = false;
			this.gridColumn11.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn11.OptionsColumn.ReadOnly = true;
			this.gridColumn11.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn11.Visible = true;
			this.gridColumn11.VisibleIndex = 3;
			// 
			// gridColumn12
			// 
			this.gridColumn12.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn12.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn12.Caption = "剩余";
			this.gridColumn12.FieldName = "info_remain";
			this.gridColumn12.Name = "gridColumn12";
			this.gridColumn12.OptionsColumn.AllowEdit = false;
			this.gridColumn12.OptionsColumn.AllowFocus = false;
			this.gridColumn12.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn12.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn12.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn12.OptionsColumn.AllowMove = false;
			this.gridColumn12.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn12.OptionsColumn.ReadOnly = true;
			this.gridColumn12.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn12.Visible = true;
			this.gridColumn12.VisibleIndex = 4;
			this.gridColumn12.Width = 93;
			// 
			// gridColumn13
			// 
			this.gridColumn13.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn13.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn13.Caption = "离开率";
			this.gridColumn13.FieldName = "info_leavePer";
			this.gridColumn13.Name = "gridColumn13";
			this.gridColumn13.OptionsColumn.AllowEdit = false;
			this.gridColumn13.OptionsColumn.AllowFocus = false;
			this.gridColumn13.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn13.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn13.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn13.OptionsColumn.AllowMove = false;
			this.gridColumn13.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn13.OptionsColumn.ReadOnly = true;
			this.gridColumn13.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn13.Visible = true;
			this.gridColumn13.VisibleIndex = 5;
			this.gridColumn13.Width = 97;
			// 
			// gridControl_DataMorning
			// 
			this.gridControl_DataMorning.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl_DataMorning.EmbeddedNavigator
			// 
			this.gridControl_DataMorning.EmbeddedNavigator.Name = "";
			this.gridControl_DataMorning.Location = new System.Drawing.Point(0, 48);
			this.gridControl_DataMorning.MainView = this.gridView1;
			this.gridControl_DataMorning.Name = "gridControl_DataMorning";
			this.gridControl_DataMorning.Size = new System.Drawing.Size(541, 461);
			this.gridControl_DataMorning.TabIndex = 1;
			this.gridControl_DataMorning.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																												   this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn1,
																							 this.gridColumn2,
																							 this.gridColumn3,
																							 this.gridColumn4,
																							 this.gridColumn5,
																							 this.gridColumn6,
																							 this.gridColumn7});
			this.gridView1.GridControl = this.gridControl_DataMorning;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsCustomization.AllowFilter = false;
			this.gridView1.OptionsView.ShowFilterPanel = false;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn1
			// 
			this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn1.Caption = "部门";
			this.gridColumn1.FieldName = "info_gradeName";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.OptionsColumn.AllowEdit = false;
			this.gridColumn1.OptionsColumn.AllowFocus = false;
			this.gridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn1.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn1.OptionsColumn.AllowMove = false;
			this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn1.OptionsColumn.ReadOnly = true;
			this.gridColumn1.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			this.gridColumn1.Width = 66;
			// 
			// gridColumn2
			// 
			this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn2.Caption = "准时";
			this.gridColumn2.FieldName = "info_onTime";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.OptionsColumn.AllowEdit = false;
			this.gridColumn2.OptionsColumn.AllowFocus = false;
			this.gridColumn2.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn2.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn2.OptionsColumn.AllowMove = false;
			this.gridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn2.OptionsColumn.ReadOnly = true;
			this.gridColumn2.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			this.gridColumn2.Width = 86;
			// 
			// gridColumn3
			// 
			this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn3.Caption = "迟到";
			this.gridColumn3.FieldName = "info_notOnTime";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.OptionsColumn.AllowEdit = false;
			this.gridColumn3.OptionsColumn.AllowFocus = false;
			this.gridColumn3.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn3.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn3.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn3.OptionsColumn.AllowMove = false;
			this.gridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn3.OptionsColumn.ReadOnly = true;
			this.gridColumn3.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 2;
			this.gridColumn3.Width = 82;
			// 
			// gridColumn4
			// 
			this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn4.Caption = "应到";
			this.gridColumn4.FieldName = "info_shouldAtt";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.OptionsColumn.AllowEdit = false;
			this.gridColumn4.OptionsColumn.AllowFocus = false;
			this.gridColumn4.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn4.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn4.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn4.OptionsColumn.AllowMove = false;
			this.gridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn4.OptionsColumn.ReadOnly = true;
			this.gridColumn4.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 3;
			this.gridColumn4.Width = 54;
			// 
			// gridColumn5
			// 
			this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn5.Caption = "实到";
			this.gridColumn5.FieldName = "info_haveAtt";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.OptionsColumn.AllowEdit = false;
			this.gridColumn5.OptionsColumn.AllowFocus = false;
			this.gridColumn5.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn5.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn5.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn5.OptionsColumn.AllowMove = false;
			this.gridColumn5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn5.OptionsColumn.ReadOnly = true;
			this.gridColumn5.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn5.Visible = true;
			this.gridColumn5.VisibleIndex = 4;
			this.gridColumn5.Width = 54;
			// 
			// gridColumn6
			// 
			this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn6.Caption = "缺席";
			this.gridColumn6.FieldName = "info_absence";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.OptionsColumn.AllowEdit = false;
			this.gridColumn6.OptionsColumn.AllowFocus = false;
			this.gridColumn6.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn6.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn6.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn6.OptionsColumn.AllowMove = false;
			this.gridColumn6.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn6.OptionsColumn.ReadOnly = true;
			this.gridColumn6.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 5;
			this.gridColumn6.Width = 90;
			// 
			// gridColumn7
			// 
			this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn7.Caption = "出勤率";
			this.gridColumn7.FieldName = "info_attPer";
			this.gridColumn7.Name = "gridColumn7";
			this.gridColumn7.OptionsColumn.AllowEdit = false;
			this.gridColumn7.OptionsColumn.AllowFocus = false;
			this.gridColumn7.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn7.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn7.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn7.OptionsColumn.AllowMove = false;
			this.gridColumn7.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn7.OptionsColumn.ReadOnly = true;
			this.gridColumn7.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn7.Visible = true;
			this.gridColumn7.VisibleIndex = 6;
			this.gridColumn7.Width = 98;
			// 
			// panelControl1
			// 
			this.panelControl1.Controls.Add(this.simpleButton_RealTime_DataSer);
			this.panelControl1.Controls.Add(this.simpleButton_RealTime_DataPrint);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl1.Location = new System.Drawing.Point(0, 0);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(541, 48);
			this.panelControl1.TabIndex = 0;
			this.panelControl1.Text = "panelControl1";
			// 
			// simpleButton_RealTime_DataSer
			// 
			this.simpleButton_RealTime_DataSer.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_RealTime_DataSer.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_RealTime_DataSer.Appearance.Options.UseFont = true;
			this.simpleButton_RealTime_DataSer.Appearance.Options.UseForeColor = true;
			this.simpleButton_RealTime_DataSer.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_RealTime_DataSer.Image")));
			this.simpleButton_RealTime_DataSer.Location = new System.Drawing.Point(8, 8);
			this.simpleButton_RealTime_DataSer.Name = "simpleButton_RealTime_DataSer";
			this.simpleButton_RealTime_DataSer.Size = new System.Drawing.Size(88, 26);
			this.simpleButton_RealTime_DataSer.TabIndex = 10;
			this.simpleButton_RealTime_DataSer.Tag = 4;
			this.simpleButton_RealTime_DataSer.Text = "搜  索";
			this.simpleButton_RealTime_DataSer.Click += new System.EventHandler(this.simpleButton_RealTime_DataSer_Click);
			// 
			// simpleButton_RealTime_DataPrint
			// 
			this.simpleButton_RealTime_DataPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_RealTime_DataPrint.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_RealTime_DataPrint.Appearance.Options.UseFont = true;
			this.simpleButton_RealTime_DataPrint.Appearance.Options.UseForeColor = true;
			this.simpleButton_RealTime_DataPrint.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_RealTime_DataPrint.Image")));
			this.simpleButton_RealTime_DataPrint.Location = new System.Drawing.Point(112, 8);
			this.simpleButton_RealTime_DataPrint.Name = "simpleButton_RealTime_DataPrint";
			this.simpleButton_RealTime_DataPrint.Size = new System.Drawing.Size(88, 26);
			this.simpleButton_RealTime_DataPrint.TabIndex = 11;
			this.simpleButton_RealTime_DataPrint.Tag = 4;
			this.simpleButton_RealTime_DataPrint.Text = "报  表";
			this.simpleButton_RealTime_DataPrint.Click += new System.EventHandler(this.simpleButton_RealTime_DataPrint_Click);
			// 
			// RealtimeInfo_Teacher
			// 
			this.Controls.Add(this.xtraTabControl1);
			this.Name = "RealtimeInfo_Teacher";
			this.Size = new System.Drawing.Size(772, 540);
			this.Load += new System.EventHandler(this.RealtimeInfo_Teacher_Load);
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
			this.xtraTabControl1.ResumeLayout(false);
			this.xtraTabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
			this.splitContainerControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl_Realtime_Graphic)).EndInit();
			this.groupControl_Realtime_Graphic.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl_Realtime_GraphicDeptInfo)).EndInit();
			this.groupControl_Realtime_GraphicDeptInfo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Realtime_GraphicState.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Realtime_GraphicDept.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_Realtime_GraphicShow)).EndInit();
			this.groupControl_Realtime_GraphicShow.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.panelControl_Realtime_GraphicShow)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
			this.panelControl2.ResumeLayout(false);
			this.xtraTabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
			this.splitContainerControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl1_Realtime_Data)).EndInit();
			this.groupControl1_Realtime_Data.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl_RealtimeStat_Dept)).EndInit();
			this.groupControl_RealtimeStat_Dept.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Realtime_DataState.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Realtime_DataDept.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_DataBack)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_DataMorning)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void RealtimeInfo_Teacher_Load(object sender, System.EventArgs e)
		{
			foreach(DataRow deptRow in realTimeInfoStat_TeacherSystem.GetTeaDept().Tables[0].Rows )
			{
				comboBoxEdit_Realtime_DataDept.Properties.Items.AddRange(new object[]{ deptRow[0].ToString() });
				comboBoxEdit_Realtime_GraphicDept.Properties.Items.AddRange(new object[]{deptRow[0].ToString()});
			}

			gridControl_DataMorning.DataSource = GetRealTimeInfoStat_Teacher().Tables[0];

			if ( Thread.CurrentPrincipal.Identity.Name.ToLower() == "admin" )
			{
				simpleButton_RealTime_DataPrint.Enabled = false;
				simpleButton_Realtime_GraphicPrint.Enabled = false;
			}


			simpleButton_RealTime_DataSer_Click(null, null);
		}

		private void comboBoxEdit_Realtime_DataDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( comboBoxEdit_Realtime_DataDept.SelectedIndex == 0 )
				getDeptNameFromCombo = "";
			else
				getDeptNameFromCombo = comboBoxEdit_Realtime_DataDept.SelectedItem.ToString();
		}

		private void comboBoxEdit_Realtime_DataState_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( comboBoxEdit_Realtime_DataState.SelectedIndex == 0 )
			{
				getDataStateFromCombo = "上班情况";
				gridControl_DataMorning.Visible = true;
				gridControl_DataBack.Visible = false;
			}
			else
			{
				getDataStateFromCombo = "下班情况";
				gridControl_DataBack.Visible = true;
				gridControl_DataMorning.Visible = false;
			}
		}

		private void simpleButton_RealTime_DataSer_Click(object sender, System.EventArgs e)
		{
			if ( getDataStateFromCombo.Equals("上班情况") )
				gridControl_DataMorning.DataSource = GetRealTimeInfoStat_Teacher().Tables[0];
			else
				gridControl_DataBack.DataSource = GetRealTimeInfoStat_Teacher().Tables[0];
		}

		private void simpleButton_RealTime_DataPrint_Click(object sender, System.EventArgs e)
		{
			string savePath;
			saveFileDialog_Report.Filter = "Excel文件|*.xls";


			if ( saveFileDialog_Report.ShowDialog() != DialogResult.OK )
				return;

			savePath = saveFileDialog_Report.FileName;

			new RealtimeInfoStat_TeacherPrintSystem().PrintRealtimeInfoStat_Teacher(dsRealTimeInfoStat_Teacher,savePath,getDataStateFromCombo);
			
			MessageBox.Show("报表生成完毕！");
		}

		private DataSet GetRealTimeInfoStat_Teacher()
		{
			dsRealTimeInfoStat_Teacher = realTimeInfoStat_TeacherSystem.GetRealtimeInfoStat_Teacher(getDeptNameFromCombo,getDataStateFromCombo);
			return dsRealTimeInfoStat_Teacher;
		}

		private void simpleButton_Realtime_GraphicPrint_Click(object sender, System.EventArgs e)
		{
            //if ( PrintImage == null )
            //    MessageBox.Show("在打印图形报表前，请先对图形报表进行预览！");
            //else
            //{
            //    PrintForm printForm = PrintForm.getInstance();
            //    BrickGraphics g = printForm.getPrintInstance().Graph;
            //    printForm.getPrintInstance().Begin();
            //    g.BackColor = Color.White;
            //    g.BorderColor = Color.Black;
            //    g.Font = g.DefaultFont;
            //    g.StringFormat = g.StringFormat.ChangeLineAlignment(StringAlignment.Near);
            //    g.DrawImage(PrintImage, new RectangleF(2000, 50, 700,500), BorderSide.All, Color.White);
            //    printForm.getPrintInstance().End();
            //    printForm.Show();
            //}
		}

		private void comboBoxEdit_Realtime_GraphicDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( comboBoxEdit_Realtime_GraphicDept.SelectedIndex == 0 )
				getDeptNameFromCombo_Graphic = "";
			else
				getDeptNameFromCombo_Graphic = comboBoxEdit_Realtime_GraphicDept.SelectedItem.ToString();
			
			PrintImage = new RealtimeInfoStat_TeacherPrintSystem().PrintRealtimeInfoStat_Teacher_Graphic(getDeptNameFromCombo_Graphic,panelControl_Realtime_GraphicShow,getStateFromCombo_Graphic);
		}

		private void comboBoxEdit_Realtime_GraphicState_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( comboBoxEdit_Realtime_GraphicState.SelectedIndex == 0 )
				getStateFromCombo_Graphic = "上班情况";
			else
				getStateFromCombo_Graphic = "下班情况";

			PrintImage = new RealtimeInfoStat_TeacherPrintSystem().PrintRealtimeInfoStat_Teacher_Graphic(getDeptNameFromCombo_Graphic,panelControl_Realtime_GraphicShow,getStateFromCombo_Graphic);
		}


		private void panelControl_Realtime_GraphicShow_Resize(object sender, System.EventArgs e)
		{
			PrintImage = new RealtimeInfoStat_TeacherPrintSystem().PrintRealtimeInfoStat_Teacher_Graphic(getDeptNameFromCombo_Graphic,panelControl_Realtime_GraphicShow,getStateFromCombo_Graphic);
		}

		private void splitContainerControl2_SizeChanged(object sender, System.EventArgs e)
		{
			PrintImage = new RealtimeInfoStat_TeacherPrintSystem().PrintRealtimeInfoStat_Teacher_Graphic(getDeptNameFromCombo_Graphic,panelControl_Realtime_GraphicShow,getStateFromCombo_Graphic);
		}

		private void simpleButton_RealTime_GraphicSer_Click(object sender, System.EventArgs e)
		{
			PrintImage = new RealtimeInfoStat_TeacherPrintSystem().PrintRealtimeInfoStat_Teacher_Graphic(getDeptNameFromCombo_Graphic,panelControl_Realtime_GraphicShow,getStateFromCombo_Graphic);
		}

		private void groupControl_Realtime_Graphic_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		private Bitmap PrintImage
		{
			get { return this.myImage; }
			set { this.myImage = value; }
		}
	}
}

