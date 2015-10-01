using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using CPTT.BusinessFacade;
using System.IO;
using System.Threading;

namespace CPTT.WinUI.Panels
{
	/// <summary>
	/// Summary description for RealtimeInfo.
	/// </summary>
	public class RealtimeInfo : DevExpress.XtraEditors.XtraUserControl
	{
		private GetStuInfoByCondition getStuInfoByCondition;
		private RealtimeSumInfo realTimeSumInfo;
		private string getGradeNumberFromCombo;
		private string getClassNumberFromCombo;
		private string getRealTimeOption = "晨检";
		private DataSet dsRealtimeBackInfo = null;
		private DataSet dsRealtimeMorningInfo = null;
		private string morningPath = Directory.GetCurrentDirectory() + @"\report\RealtimeMorningInfo.xls";
		private string morningDestPath = Directory.GetCurrentDirectory() + @"\report\RealtimeMorningInfoCopy.xls";
		private string backPath = Directory.GetCurrentDirectory() + @"\report\RealtimeBackInfo.xls";
		private string backDestPath = Directory.GetCurrentDirectory() + @"\report\RealtimeBackInfoCopy.xls";
		private RealtimeInfoPrintSystem realTimeInfoPrintSystem;
		private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
		private DevExpress.XtraEditors.GroupControl groupControl_RealTime;
		private DevExpress.XtraEditors.GroupControl groupControl_RealTimeStat;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_RealTimeOption;
		private DevExpress.Utils.Frames.NotePanel notePanel_RealTimeOption;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_RealTimeClass;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_RealTimeGrade;
		private DevExpress.Utils.Frames.NotePanel notePanel1_RealTimeGrade;
		private DevExpress.Utils.Frames.NotePanel notePanel1_RealTimeClass;
		private DevExpress.Utils.Frames.NotePanel notePanel_RealTime;
		private DevExpress.XtraGrid.GridControl gridControl_RealTimeBack;
		private DevExpress.XtraGrid.GridControl gridControl_RealTimeMorning;
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private DevExpress.XtraEditors.SimpleButton simpleButton_RealTimeQuery;
		private DevExpress.XtraEditors.SimpleButton simpleButton_RealTimePrint;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
		private DevExpress.XtraEditors.GroupControl groupControl1_Realtime_Graphic;
		private DevExpress.XtraEditors.GroupControl groupControl_RealtimeStat_Graphic;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Realtime_GraphicState;
		private DevExpress.Utils.Frames.NotePanel notePanel_Realtime_GraphicState;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Realtime_GraphicClass;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Realtime_GraphicGrade;
		private DevExpress.Utils.Frames.NotePanel notePanel_Realtime_GraphicGrade;
		private DevExpress.Utils.Frames.NotePanel notePanel_Realtime_GraphicClass;
		private DevExpress.Utils.Frames.NotePanel notePanel_Realtime_Graphic;
		private DevExpress.XtraEditors.PanelControl panelControl2;
		private DevExpress.XtraEditors.SimpleButton simpleButton_Realtime_GraphicPrint;
		private DevExpress.XtraEditors.GroupControl groupControl_Realtime_GraphicShow;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private string getGraphicGradeFromCombo = "";
		private string getGraphicClassFromCombo = "";
		private string getGraphicStateFromCombo = "晨检";
		private Bitmap myImage;
		private DevExpress.XtraEditors.PanelControl panelControl_Realtime_GraphicShow;
		private System.Windows.Forms.SaveFileDialog saveFileDialog_Report;
		private DevExpress.XtraEditors.SimpleButton simpleButton_RealTimeQuery_Graphic;
		private System.Windows.Forms.HelpProvider helpProvider_RealtimeInfo_Student;
		private RolesSystem rolesSystem;

		public RealtimeInfo()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call
			getStuInfoByCondition = new GetStuInfoByCondition();
			realTimeSumInfo = new RealtimeSumInfo();
			realTimeInfoPrintSystem = new RealtimeInfoPrintSystem();
			rolesSystem = new RolesSystem();

			#region 帮助
			helpProvider_RealtimeInfo_Student.HelpNamespace = System.IO.Path.GetDirectoryName(Application.ExecutablePath)
				+ CPTT.SystemFramework.Util.HELP_FILE_NAME;

			this.helpProvider_RealtimeInfo_Student.SetHelpKeyword(this.xtraTabPage1,"学生图形统计");
			this.helpProvider_RealtimeInfo_Student.SetHelpNavigator(this.xtraTabPage1, System.Windows.Forms.HelpNavigator.KeywordIndex);
			this.helpProvider_RealtimeInfo_Student.SetHelpString(this.xtraTabPage1, "");
			this.helpProvider_RealtimeInfo_Student.SetShowHelp(this.xtraTabPage1, true);

			this.helpProvider_RealtimeInfo_Student.SetHelpKeyword(this.xtraTabPage2,"学生数据统计");
			this.helpProvider_RealtimeInfo_Student.SetHelpNavigator(this.xtraTabPage2, System.Windows.Forms.HelpNavigator.KeywordIndex);
			this.helpProvider_RealtimeInfo_Student.SetHelpString(this.xtraTabPage2, "");
			this.helpProvider_RealtimeInfo_Student.SetShowHelp(this.xtraTabPage2, true);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(RealtimeInfo));
			this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
			this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
			this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
			this.groupControl1_Realtime_Graphic = new DevExpress.XtraEditors.GroupControl();
			this.groupControl_RealtimeStat_Graphic = new DevExpress.XtraEditors.GroupControl();
			this.comboBoxEdit_Realtime_GraphicState = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_Realtime_GraphicState = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_Realtime_GraphicClass = new DevExpress.XtraEditors.ComboBoxEdit();
			this.comboBoxEdit_Realtime_GraphicGrade = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_Realtime_GraphicGrade = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_Realtime_GraphicClass = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_Realtime_Graphic = new DevExpress.Utils.Frames.NotePanel();
			this.groupControl_Realtime_GraphicShow = new DevExpress.XtraEditors.GroupControl();
			this.panelControl_Realtime_GraphicShow = new DevExpress.XtraEditors.PanelControl();
			this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
			this.simpleButton_RealTimeQuery_Graphic = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_Realtime_GraphicPrint = new DevExpress.XtraEditors.SimpleButton();
			this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
			this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
			this.groupControl_RealTime = new DevExpress.XtraEditors.GroupControl();
			this.groupControl_RealTimeStat = new DevExpress.XtraEditors.GroupControl();
			this.comboBoxEdit_RealTimeOption = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_RealTimeOption = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_RealTimeClass = new DevExpress.XtraEditors.ComboBoxEdit();
			this.comboBoxEdit_RealTimeGrade = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel1_RealTimeGrade = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel1_RealTimeClass = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_RealTime = new DevExpress.Utils.Frames.NotePanel();
			this.gridControl_RealTimeMorning = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridControl_RealTimeBack = new DevExpress.XtraGrid.GridControl();
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.simpleButton_RealTimeQuery = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_RealTimePrint = new DevExpress.XtraEditors.SimpleButton();
			this.saveFileDialog_Report = new System.Windows.Forms.SaveFileDialog();
			this.helpProvider_RealtimeInfo_Student = new System.Windows.Forms.HelpProvider();
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
			this.xtraTabControl1.SuspendLayout();
			this.xtraTabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
			this.splitContainerControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1_Realtime_Graphic)).BeginInit();
			this.groupControl1_Realtime_Graphic.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_RealtimeStat_Graphic)).BeginInit();
			this.groupControl_RealtimeStat_Graphic.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Realtime_GraphicState.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Realtime_GraphicClass.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Realtime_GraphicGrade.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_Realtime_GraphicShow)).BeginInit();
			this.groupControl_Realtime_GraphicShow.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.panelControl_Realtime_GraphicShow)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
			this.panelControl2.SuspendLayout();
			this.xtraTabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
			this.splitContainerControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_RealTime)).BeginInit();
			this.groupControl_RealTime.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_RealTimeStat)).BeginInit();
			this.groupControl_RealTimeStat.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_RealTimeOption.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_RealTimeClass.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_RealTimeGrade.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_RealTimeMorning)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_RealTimeBack)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
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
			this.xtraTabControl1.SelectedTabPage = this.xtraTabPage2;
			this.xtraTabControl1.Size = new System.Drawing.Size(772, 540);
			this.xtraTabControl1.TabIndex = 0;
			this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
																							this.xtraTabPage1,
																							this.xtraTabPage2});
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
			this.splitContainerControl2.Panel1.Controls.Add(this.groupControl1_Realtime_Graphic);
			this.splitContainerControl2.Panel1.Text = "splitContainerControl2_Panel1";
			this.splitContainerControl2.Panel2.Controls.Add(this.groupControl_Realtime_GraphicShow);
			this.splitContainerControl2.Panel2.Controls.Add(this.panelControl2);
			this.splitContainerControl2.Panel2.Text = "splitContainerControl2_Panel2";
			this.splitContainerControl2.Size = new System.Drawing.Size(768, 515);
			this.splitContainerControl2.SplitterPosition = 207;
			this.splitContainerControl2.TabIndex = 0;
			this.splitContainerControl2.Text = "splitContainerControl2";
			this.splitContainerControl2.SizeChanged += new System.EventHandler(this.splitContainerControl2_SizeChanged);
			// 
			// groupControl1_Realtime_Graphic
			// 
			this.groupControl1_Realtime_Graphic.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl1_Realtime_Graphic.Appearance.Options.UseFont = true;
			this.groupControl1_Realtime_Graphic.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl1_Realtime_Graphic.AppearanceCaption.Options.UseFont = true;
			this.groupControl1_Realtime_Graphic.Controls.Add(this.groupControl_RealtimeStat_Graphic);
			this.groupControl1_Realtime_Graphic.Controls.Add(this.notePanel_Realtime_Graphic);
			this.groupControl1_Realtime_Graphic.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl1_Realtime_Graphic.Location = new System.Drawing.Point(0, 0);
			this.groupControl1_Realtime_Graphic.Name = "groupControl1_Realtime_Graphic";
			this.groupControl1_Realtime_Graphic.Size = new System.Drawing.Size(201, 509);
			this.groupControl1_Realtime_Graphic.TabIndex = 1;
			this.groupControl1_Realtime_Graphic.Text = "实时窗口统计";
			// 
			// groupControl_RealtimeStat_Graphic
			// 
			this.groupControl_RealtimeStat_Graphic.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_RealtimeStat_Graphic.AppearanceCaption.Options.UseFont = true;
			this.groupControl_RealtimeStat_Graphic.Controls.Add(this.comboBoxEdit_Realtime_GraphicState);
			this.groupControl_RealtimeStat_Graphic.Controls.Add(this.notePanel_Realtime_GraphicState);
			this.groupControl_RealtimeStat_Graphic.Controls.Add(this.comboBoxEdit_Realtime_GraphicClass);
			this.groupControl_RealtimeStat_Graphic.Controls.Add(this.comboBoxEdit_Realtime_GraphicGrade);
			this.groupControl_RealtimeStat_Graphic.Controls.Add(this.notePanel_Realtime_GraphicGrade);
			this.groupControl_RealtimeStat_Graphic.Controls.Add(this.notePanel_Realtime_GraphicClass);
			this.groupControl_RealtimeStat_Graphic.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_RealtimeStat_Graphic.Location = new System.Drawing.Point(3, 41);
			this.groupControl_RealtimeStat_Graphic.Name = "groupControl_RealtimeStat_Graphic";
			this.groupControl_RealtimeStat_Graphic.Size = new System.Drawing.Size(195, 143);
			this.groupControl_RealtimeStat_Graphic.TabIndex = 7;
			this.groupControl_RealtimeStat_Graphic.Text = "统计状态和班级信息";
			// 
			// comboBoxEdit_Realtime_GraphicState
			// 
			this.comboBoxEdit_Realtime_GraphicState.EditValue = "晨检";
			this.comboBoxEdit_Realtime_GraphicState.Location = new System.Drawing.Point(88, 96);
			this.comboBoxEdit_Realtime_GraphicState.Name = "comboBoxEdit_Realtime_GraphicState";
			// 
			// comboBoxEdit_Realtime_GraphicState.Properties
			// 
			this.comboBoxEdit_Realtime_GraphicState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																	   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_Realtime_GraphicState.Properties.Items.AddRange(new object[] {
																							   "晨检",
																							   "晚接"});
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
			this.notePanel_Realtime_GraphicState.Location = new System.Drawing.Point(16, 96);
			this.notePanel_Realtime_GraphicState.MaxRows = 5;
			this.notePanel_Realtime_GraphicState.Name = "notePanel_Realtime_GraphicState";
			this.notePanel_Realtime_GraphicState.ParentAutoHeight = true;
			this.notePanel_Realtime_GraphicState.Size = new System.Drawing.Size(64, 22);
			this.notePanel_Realtime_GraphicState.TabIndex = 23;
			this.notePanel_Realtime_GraphicState.TabStop = false;
			this.notePanel_Realtime_GraphicState.Text = "类  型:";
			// 
			// comboBoxEdit_Realtime_GraphicClass
			// 
			this.comboBoxEdit_Realtime_GraphicClass.EditValue = "全部";
			this.comboBoxEdit_Realtime_GraphicClass.Location = new System.Drawing.Point(88, 64);
			this.comboBoxEdit_Realtime_GraphicClass.Name = "comboBoxEdit_Realtime_GraphicClass";
			// 
			// comboBoxEdit_Realtime_GraphicClass.Properties
			// 
			this.comboBoxEdit_Realtime_GraphicClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																	   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_Realtime_GraphicClass.Properties.Items.AddRange(new object[] {
																							   "全部"});
			this.comboBoxEdit_Realtime_GraphicClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_Realtime_GraphicClass.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_Realtime_GraphicClass.TabIndex = 22;
			this.comboBoxEdit_Realtime_GraphicClass.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_Realtime_GraphicClass_SelectedIndexChanged);
			// 
			// comboBoxEdit_Realtime_GraphicGrade
			// 
			this.comboBoxEdit_Realtime_GraphicGrade.EditValue = "全部";
			this.comboBoxEdit_Realtime_GraphicGrade.Location = new System.Drawing.Point(88, 32);
			this.comboBoxEdit_Realtime_GraphicGrade.Name = "comboBoxEdit_Realtime_GraphicGrade";
			// 
			// comboBoxEdit_Realtime_GraphicGrade.Properties
			// 
			this.comboBoxEdit_Realtime_GraphicGrade.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																	   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_Realtime_GraphicGrade.Properties.Items.AddRange(new object[] {
																							   "全部"});
			this.comboBoxEdit_Realtime_GraphicGrade.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_Realtime_GraphicGrade.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_Realtime_GraphicGrade.TabIndex = 21;
			this.comboBoxEdit_Realtime_GraphicGrade.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_Realtime_GraphicGrade_SelectedIndexChanged);
			// 
			// notePanel_Realtime_GraphicGrade
			// 
			this.notePanel_Realtime_GraphicGrade.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_Realtime_GraphicGrade.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_Realtime_GraphicGrade.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_Realtime_GraphicGrade.ForeColor = System.Drawing.Color.Black;
			this.notePanel_Realtime_GraphicGrade.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Realtime_GraphicGrade.Location = new System.Drawing.Point(16, 32);
			this.notePanel_Realtime_GraphicGrade.MaxRows = 5;
			this.notePanel_Realtime_GraphicGrade.Name = "notePanel_Realtime_GraphicGrade";
			this.notePanel_Realtime_GraphicGrade.ParentAutoHeight = true;
			this.notePanel_Realtime_GraphicGrade.Size = new System.Drawing.Size(64, 22);
			this.notePanel_Realtime_GraphicGrade.TabIndex = 19;
			this.notePanel_Realtime_GraphicGrade.TabStop = false;
			this.notePanel_Realtime_GraphicGrade.Text = "年  级:";
			// 
			// notePanel_Realtime_GraphicClass
			// 
			this.notePanel_Realtime_GraphicClass.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_Realtime_GraphicClass.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_Realtime_GraphicClass.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_Realtime_GraphicClass.ForeColor = System.Drawing.Color.Black;
			this.notePanel_Realtime_GraphicClass.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Realtime_GraphicClass.Location = new System.Drawing.Point(16, 64);
			this.notePanel_Realtime_GraphicClass.MaxRows = 5;
			this.notePanel_Realtime_GraphicClass.Name = "notePanel_Realtime_GraphicClass";
			this.notePanel_Realtime_GraphicClass.ParentAutoHeight = true;
			this.notePanel_Realtime_GraphicClass.Size = new System.Drawing.Size(64, 22);
			this.notePanel_Realtime_GraphicClass.TabIndex = 20;
			this.notePanel_Realtime_GraphicClass.TabStop = false;
			this.notePanel_Realtime_GraphicClass.Text = "班  级:";
			// 
			// notePanel_Realtime_Graphic
			// 
			this.notePanel_Realtime_Graphic.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel_Realtime_Graphic.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel_Realtime_Graphic.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.notePanel_Realtime_Graphic.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel_Realtime_Graphic.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Realtime_Graphic.Location = new System.Drawing.Point(3, 18);
			this.notePanel_Realtime_Graphic.MaxRows = 5;
			this.notePanel_Realtime_Graphic.Name = "notePanel_Realtime_Graphic";
			this.notePanel_Realtime_Graphic.ParentAutoHeight = true;
			this.notePanel_Realtime_Graphic.Size = new System.Drawing.Size(195, 23);
			this.notePanel_Realtime_Graphic.TabIndex = 6;
			this.notePanel_Realtime_Graphic.TabStop = false;
			this.notePanel_Realtime_Graphic.Text = "搜索条件";
			// 
			// groupControl_Realtime_GraphicShow
			// 
			this.groupControl_Realtime_GraphicShow.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.groupControl_Realtime_GraphicShow.Appearance.Options.UseBackColor = true;
			this.groupControl_Realtime_GraphicShow.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_Realtime_GraphicShow.AppearanceCaption.Options.UseFont = true;
			this.groupControl_Realtime_GraphicShow.Controls.Add(this.panelControl_Realtime_GraphicShow);
			this.groupControl_Realtime_GraphicShow.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl_Realtime_GraphicShow.Location = new System.Drawing.Point(0, 48);
			this.groupControl_Realtime_GraphicShow.Name = "groupControl_Realtime_GraphicShow";
			this.groupControl_Realtime_GraphicShow.Size = new System.Drawing.Size(551, 461);
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
			this.panelControl_Realtime_GraphicShow.Size = new System.Drawing.Size(545, 440);
			this.panelControl_Realtime_GraphicShow.TabIndex = 0;
			this.panelControl_Realtime_GraphicShow.Text = "panelControl3";
			this.panelControl_Realtime_GraphicShow.Resize += new System.EventHandler(this.panelControl_Realtime_GraphicShow_Resize);
			// 
			// panelControl2
			// 
			this.panelControl2.Controls.Add(this.simpleButton_RealTimeQuery_Graphic);
			this.panelControl2.Controls.Add(this.simpleButton_Realtime_GraphicPrint);
			this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl2.Location = new System.Drawing.Point(0, 0);
			this.panelControl2.Name = "panelControl2";
			this.panelControl2.Size = new System.Drawing.Size(551, 48);
			this.panelControl2.TabIndex = 0;
			this.panelControl2.Text = "panelControl2";
			// 
			// simpleButton_RealTimeQuery_Graphic
			// 
			this.simpleButton_RealTimeQuery_Graphic.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_RealTimeQuery_Graphic.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_RealTimeQuery_Graphic.Appearance.Options.UseFont = true;
			this.simpleButton_RealTimeQuery_Graphic.Appearance.Options.UseForeColor = true;
			this.simpleButton_RealTimeQuery_Graphic.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_RealTimeQuery_Graphic.Image")));
			this.simpleButton_RealTimeQuery_Graphic.Location = new System.Drawing.Point(16, 11);
			this.simpleButton_RealTimeQuery_Graphic.Name = "simpleButton_RealTimeQuery_Graphic";
			this.simpleButton_RealTimeQuery_Graphic.Size = new System.Drawing.Size(88, 26);
			this.simpleButton_RealTimeQuery_Graphic.TabIndex = 13;
			this.simpleButton_RealTimeQuery_Graphic.Tag = 4;
			this.simpleButton_RealTimeQuery_Graphic.Text = "搜  索";
			this.simpleButton_RealTimeQuery_Graphic.Click += new System.EventHandler(this.simpleButton_RealTimeQuery_Graphic_Click);
			// 
			// simpleButton_Realtime_GraphicPrint
			// 
			this.simpleButton_Realtime_GraphicPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_Realtime_GraphicPrint.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_Realtime_GraphicPrint.Appearance.Options.UseFont = true;
			this.simpleButton_Realtime_GraphicPrint.Appearance.Options.UseForeColor = true;
			this.simpleButton_Realtime_GraphicPrint.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_Realtime_GraphicPrint.Image")));
			this.simpleButton_Realtime_GraphicPrint.Location = new System.Drawing.Point(112, 12);
			this.simpleButton_Realtime_GraphicPrint.Name = "simpleButton_Realtime_GraphicPrint";
			this.simpleButton_Realtime_GraphicPrint.Size = new System.Drawing.Size(104, 26);
			this.simpleButton_Realtime_GraphicPrint.TabIndex = 11;
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
			this.splitContainerControl1.Panel1.Controls.Add(this.groupControl_RealTime);
			this.splitContainerControl1.Panel1.Text = "splitContainerControl1_Panel1";
			this.splitContainerControl1.Panel2.Controls.Add(this.gridControl_RealTimeMorning);
			this.splitContainerControl1.Panel2.Controls.Add(this.gridControl_RealTimeBack);
			this.splitContainerControl1.Panel2.Controls.Add(this.panelControl1);
			this.splitContainerControl1.Panel2.Text = "splitContainerControl1_Panel2";
			this.splitContainerControl1.Size = new System.Drawing.Size(768, 515);
			this.splitContainerControl1.SplitterPosition = 201;
			this.splitContainerControl1.TabIndex = 2;
			this.splitContainerControl1.Text = "splitContainerControl1";
			// 
			// groupControl_RealTime
			// 
			this.groupControl_RealTime.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_RealTime.Appearance.Options.UseFont = true;
			this.groupControl_RealTime.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_RealTime.AppearanceCaption.Options.UseFont = true;
			this.groupControl_RealTime.Controls.Add(this.groupControl_RealTimeStat);
			this.groupControl_RealTime.Controls.Add(this.notePanel_RealTime);
			this.groupControl_RealTime.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl_RealTime.Location = new System.Drawing.Point(0, 0);
			this.groupControl_RealTime.Name = "groupControl_RealTime";
			this.groupControl_RealTime.Size = new System.Drawing.Size(195, 509);
			this.groupControl_RealTime.TabIndex = 0;
			this.groupControl_RealTime.Text = "实时窗口统计";
			// 
			// groupControl_RealTimeStat
			// 
			this.groupControl_RealTimeStat.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_RealTimeStat.AppearanceCaption.Options.UseFont = true;
			this.groupControl_RealTimeStat.Controls.Add(this.comboBoxEdit_RealTimeOption);
			this.groupControl_RealTimeStat.Controls.Add(this.notePanel_RealTimeOption);
			this.groupControl_RealTimeStat.Controls.Add(this.comboBoxEdit_RealTimeClass);
			this.groupControl_RealTimeStat.Controls.Add(this.comboBoxEdit_RealTimeGrade);
			this.groupControl_RealTimeStat.Controls.Add(this.notePanel1_RealTimeGrade);
			this.groupControl_RealTimeStat.Controls.Add(this.notePanel1_RealTimeClass);
			this.groupControl_RealTimeStat.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_RealTimeStat.Location = new System.Drawing.Point(3, 41);
			this.groupControl_RealTimeStat.Name = "groupControl_RealTimeStat";
			this.groupControl_RealTimeStat.Size = new System.Drawing.Size(189, 150);
			this.groupControl_RealTimeStat.TabIndex = 7;
			this.groupControl_RealTimeStat.Text = "统计状态和班级信息";
			// 
			// comboBoxEdit_RealTimeOption
			// 
			this.comboBoxEdit_RealTimeOption.EditValue = "晨检";
			this.comboBoxEdit_RealTimeOption.Location = new System.Drawing.Point(88, 96);
			this.comboBoxEdit_RealTimeOption.Name = "comboBoxEdit_RealTimeOption";
			// 
			// comboBoxEdit_RealTimeOption.Properties
			// 
			this.comboBoxEdit_RealTimeOption.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_RealTimeOption.Properties.Items.AddRange(new object[] {
																						"晨检",
																						"晚接"});
			this.comboBoxEdit_RealTimeOption.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_RealTimeOption.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_RealTimeOption.TabIndex = 24;
			this.comboBoxEdit_RealTimeOption.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_RealTimeOption_SelectedIndexChanged);
			// 
			// notePanel_RealTimeOption
			// 
			this.notePanel_RealTimeOption.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_RealTimeOption.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_RealTimeOption.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_RealTimeOption.ForeColor = System.Drawing.Color.Black;
			this.notePanel_RealTimeOption.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_RealTimeOption.Location = new System.Drawing.Point(16, 96);
			this.notePanel_RealTimeOption.MaxRows = 5;
			this.notePanel_RealTimeOption.Name = "notePanel_RealTimeOption";
			this.notePanel_RealTimeOption.ParentAutoHeight = true;
			this.notePanel_RealTimeOption.Size = new System.Drawing.Size(64, 22);
			this.notePanel_RealTimeOption.TabIndex = 23;
			this.notePanel_RealTimeOption.TabStop = false;
			this.notePanel_RealTimeOption.Text = "类  型:";
			// 
			// comboBoxEdit_RealTimeClass
			// 
			this.comboBoxEdit_RealTimeClass.EditValue = "全部";
			this.comboBoxEdit_RealTimeClass.Location = new System.Drawing.Point(88, 64);
			this.comboBoxEdit_RealTimeClass.Name = "comboBoxEdit_RealTimeClass";
			// 
			// comboBoxEdit_RealTimeClass.Properties
			// 
			this.comboBoxEdit_RealTimeClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_RealTimeClass.Properties.Items.AddRange(new object[] {
																					   "全部"});
			this.comboBoxEdit_RealTimeClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_RealTimeClass.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_RealTimeClass.TabIndex = 22;
			this.comboBoxEdit_RealTimeClass.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_RealTimeClass_SelectedIndexChanged);
			// 
			// comboBoxEdit_RealTimeGrade
			// 
			this.comboBoxEdit_RealTimeGrade.EditValue = "全部";
			this.comboBoxEdit_RealTimeGrade.Location = new System.Drawing.Point(88, 32);
			this.comboBoxEdit_RealTimeGrade.Name = "comboBoxEdit_RealTimeGrade";
			// 
			// comboBoxEdit_RealTimeGrade.Properties
			// 
			this.comboBoxEdit_RealTimeGrade.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_RealTimeGrade.Properties.Items.AddRange(new object[] {
																					   "全部"});
			this.comboBoxEdit_RealTimeGrade.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_RealTimeGrade.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_RealTimeGrade.TabIndex = 21;
			this.comboBoxEdit_RealTimeGrade.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_RealTimeGrade_SelectedIndexChanged);
			// 
			// notePanel1_RealTimeGrade
			// 
			this.notePanel1_RealTimeGrade.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel1_RealTimeGrade.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel1_RealTimeGrade.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel1_RealTimeGrade.ForeColor = System.Drawing.Color.Black;
			this.notePanel1_RealTimeGrade.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel1_RealTimeGrade.Location = new System.Drawing.Point(16, 32);
			this.notePanel1_RealTimeGrade.MaxRows = 5;
			this.notePanel1_RealTimeGrade.Name = "notePanel1_RealTimeGrade";
			this.notePanel1_RealTimeGrade.ParentAutoHeight = true;
			this.notePanel1_RealTimeGrade.Size = new System.Drawing.Size(64, 22);
			this.notePanel1_RealTimeGrade.TabIndex = 19;
			this.notePanel1_RealTimeGrade.TabStop = false;
			this.notePanel1_RealTimeGrade.Text = "年  级:";
			// 
			// notePanel1_RealTimeClass
			// 
			this.notePanel1_RealTimeClass.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel1_RealTimeClass.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel1_RealTimeClass.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel1_RealTimeClass.ForeColor = System.Drawing.Color.Black;
			this.notePanel1_RealTimeClass.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel1_RealTimeClass.Location = new System.Drawing.Point(16, 64);
			this.notePanel1_RealTimeClass.MaxRows = 5;
			this.notePanel1_RealTimeClass.Name = "notePanel1_RealTimeClass";
			this.notePanel1_RealTimeClass.ParentAutoHeight = true;
			this.notePanel1_RealTimeClass.Size = new System.Drawing.Size(64, 22);
			this.notePanel1_RealTimeClass.TabIndex = 20;
			this.notePanel1_RealTimeClass.TabStop = false;
			this.notePanel1_RealTimeClass.Text = "班  级:";
			// 
			// notePanel_RealTime
			// 
			this.notePanel_RealTime.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel_RealTime.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel_RealTime.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.notePanel_RealTime.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel_RealTime.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_RealTime.Location = new System.Drawing.Point(3, 18);
			this.notePanel_RealTime.MaxRows = 5;
			this.notePanel_RealTime.Name = "notePanel_RealTime";
			this.notePanel_RealTime.ParentAutoHeight = true;
			this.notePanel_RealTime.Size = new System.Drawing.Size(189, 23);
			this.notePanel_RealTime.TabIndex = 6;
			this.notePanel_RealTime.TabStop = false;
			this.notePanel_RealTime.Text = "搜索条件";
			// 
			// gridControl_RealTimeMorning
			// 
			this.gridControl_RealTimeMorning.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl_RealTimeMorning.EmbeddedNavigator
			// 
			this.gridControl_RealTimeMorning.EmbeddedNavigator.Name = "";
			this.gridControl_RealTimeMorning.Location = new System.Drawing.Point(0, 40);
			this.gridControl_RealTimeMorning.MainView = this.gridView1;
			this.gridControl_RealTimeMorning.Name = "gridControl_RealTimeMorning";
			this.gridControl_RealTimeMorning.Size = new System.Drawing.Size(557, 469);
			this.gridControl_RealTimeMorning.TabIndex = 1;
			this.gridControl_RealTimeMorning.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
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
																							 this.gridColumn13,
																							 this.gridColumn6,
																							 this.gridColumn7});
			this.gridView1.GridControl = this.gridControl_RealTimeMorning;
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
			this.gridColumn1.Caption = "班级";
			this.gridColumn1.FieldName = "info_className";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.OptionsColumn.AllowEdit = false;
			this.gridColumn1.OptionsColumn.AllowFocus = false;
			this.gridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn1.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn1.OptionsColumn.ReadOnly = true;
			this.gridColumn1.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			this.gridColumn1.Width = 50;
			// 
			// gridColumn2
			// 
			this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn2.Caption = "健康";
			this.gridColumn2.FieldName = "info_health";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.OptionsColumn.AllowEdit = false;
			this.gridColumn2.OptionsColumn.AllowFocus = false;
			this.gridColumn2.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn2.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn2.OptionsColumn.ReadOnly = true;
			this.gridColumn2.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			this.gridColumn2.Width = 97;
			// 
			// gridColumn3
			// 
			this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn3.Caption = "观察";
			this.gridColumn3.FieldName = "info_watch";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.OptionsColumn.AllowEdit = false;
			this.gridColumn3.OptionsColumn.AllowFocus = false;
			this.gridColumn3.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn3.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn3.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn3.OptionsColumn.ReadOnly = true;
			this.gridColumn3.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 2;
			this.gridColumn3.Width = 67;
			// 
			// gridColumn4
			// 
			this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn4.Caption = "服药";
			this.gridColumn4.FieldName = "info_ill";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.OptionsColumn.AllowEdit = false;
			this.gridColumn4.OptionsColumn.AllowFocus = false;
			this.gridColumn4.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn4.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn4.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn4.OptionsColumn.ReadOnly = true;
			this.gridColumn4.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 3;
			this.gridColumn4.Width = 72;
			// 
			// gridColumn5
			// 
			this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn5.Caption = "应出勤";
			this.gridColumn5.FieldName = "info_shouldAtt";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.OptionsColumn.AllowEdit = false;
			this.gridColumn5.OptionsColumn.AllowFocus = false;
			this.gridColumn5.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn5.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn5.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn5.OptionsColumn.ReadOnly = true;
			this.gridColumn5.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn5.Visible = true;
			this.gridColumn5.VisibleIndex = 4;
			this.gridColumn5.Width = 55;
			// 
			// gridColumn13
			// 
			this.gridColumn13.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn13.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn13.Caption = "已出勤";
			this.gridColumn13.FieldName = "info_haveAtt";
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
			this.gridColumn13.Width = 50;
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
			this.gridColumn6.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn6.OptionsColumn.ReadOnly = true;
			this.gridColumn6.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 6;
			this.gridColumn6.Width = 87;
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
			this.gridColumn7.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn7.OptionsColumn.ReadOnly = true;
			this.gridColumn7.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn7.Visible = true;
			this.gridColumn7.VisibleIndex = 7;
			this.gridColumn7.Width = 66;
			// 
			// gridControl_RealTimeBack
			// 
			this.gridControl_RealTimeBack.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl_RealTimeBack.EmbeddedNavigator
			// 
			this.gridControl_RealTimeBack.EmbeddedNavigator.Name = "";
			this.gridControl_RealTimeBack.Location = new System.Drawing.Point(0, 40);
			this.gridControl_RealTimeBack.MainView = this.gridView2;
			this.gridControl_RealTimeBack.Name = "gridControl_RealTimeBack";
			this.gridControl_RealTimeBack.Size = new System.Drawing.Size(557, 469);
			this.gridControl_RealTimeBack.TabIndex = 2;
			this.gridControl_RealTimeBack.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																													this.gridView2});
			this.gridControl_RealTimeBack.Visible = false;
			// 
			// gridView2
			// 
			this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn8,
																							 this.gridColumn9,
																							 this.gridColumn10,
																							 this.gridColumn11,
																							 this.gridColumn12});
			this.gridView2.GridControl = this.gridControl_RealTimeBack;
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
			this.gridColumn8.Caption = "班级";
			this.gridColumn8.FieldName = "info_className";
			this.gridColumn8.Name = "gridColumn8";
			this.gridColumn8.OptionsColumn.AllowEdit = false;
			this.gridColumn8.OptionsColumn.AllowFocus = false;
			this.gridColumn8.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn8.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn8.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn8.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn8.OptionsColumn.FixedWidth = true;
			this.gridColumn8.OptionsColumn.ReadOnly = true;
			this.gridColumn8.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn8.Visible = true;
			this.gridColumn8.VisibleIndex = 0;
			this.gridColumn8.Width = 71;
			// 
			// gridColumn9
			// 
			this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn9.Caption = "已接走";
			this.gridColumn9.FieldName = "info_hasGone";
			this.gridColumn9.Name = "gridColumn9";
			this.gridColumn9.OptionsColumn.AllowEdit = false;
			this.gridColumn9.OptionsColumn.AllowFocus = false;
			this.gridColumn9.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn9.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn9.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn9.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn9.OptionsColumn.FixedWidth = true;
			this.gridColumn9.OptionsColumn.ReadOnly = true;
			this.gridColumn9.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn9.Visible = true;
			this.gridColumn9.VisibleIndex = 1;
			// 
			// gridColumn10
			// 
			this.gridColumn10.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn10.Caption = "应接走";
			this.gridColumn10.FieldName = "info_shouldGo";
			this.gridColumn10.Name = "gridColumn10";
			this.gridColumn10.OptionsColumn.AllowEdit = false;
			this.gridColumn10.OptionsColumn.AllowFocus = false;
			this.gridColumn10.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn10.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn10.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn10.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn10.OptionsColumn.FixedWidth = true;
			this.gridColumn10.OptionsColumn.ReadOnly = true;
			this.gridColumn10.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn10.Visible = true;
			this.gridColumn10.VisibleIndex = 2;
			// 
			// gridColumn11
			// 
			this.gridColumn11.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn11.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn11.Caption = "未接走";
			this.gridColumn11.FieldName = "info_notGone";
			this.gridColumn11.Name = "gridColumn11";
			this.gridColumn11.OptionsColumn.AllowEdit = false;
			this.gridColumn11.OptionsColumn.AllowFocus = false;
			this.gridColumn11.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn11.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn11.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn11.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn11.OptionsColumn.FixedWidth = true;
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
			this.gridColumn12.Caption = "接走率";
			this.gridColumn12.FieldName = "info_goPer";
			this.gridColumn12.Name = "gridColumn12";
			this.gridColumn12.OptionsColumn.AllowEdit = false;
			this.gridColumn12.OptionsColumn.AllowFocus = false;
			this.gridColumn12.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn12.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn12.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn12.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn12.OptionsColumn.FixedWidth = true;
			this.gridColumn12.OptionsColumn.ReadOnly = true;
			this.gridColumn12.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn12.Visible = true;
			this.gridColumn12.VisibleIndex = 4;
			// 
			// panelControl1
			// 
			this.panelControl1.Controls.Add(this.simpleButton_RealTimeQuery);
			this.panelControl1.Controls.Add(this.simpleButton_RealTimePrint);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl1.Location = new System.Drawing.Point(0, 0);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(557, 40);
			this.panelControl1.TabIndex = 0;
			this.panelControl1.Text = "panelControl1";
			// 
			// simpleButton_RealTimeQuery
			// 
			this.simpleButton_RealTimeQuery.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_RealTimeQuery.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_RealTimeQuery.Appearance.Options.UseFont = true;
			this.simpleButton_RealTimeQuery.Appearance.Options.UseForeColor = true;
			this.simpleButton_RealTimeQuery.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_RealTimeQuery.Image")));
			this.simpleButton_RealTimeQuery.Location = new System.Drawing.Point(16, 8);
			this.simpleButton_RealTimeQuery.Name = "simpleButton_RealTimeQuery";
			this.simpleButton_RealTimeQuery.Size = new System.Drawing.Size(88, 26);
			this.simpleButton_RealTimeQuery.TabIndex = 7;
			this.simpleButton_RealTimeQuery.Tag = 4;
			this.simpleButton_RealTimeQuery.Text = "搜  索";
			this.simpleButton_RealTimeQuery.Click += new System.EventHandler(this.simpleButton_RealTimeQuery_Click);
			// 
			// simpleButton_RealTimePrint
			// 
			this.simpleButton_RealTimePrint.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_RealTimePrint.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_RealTimePrint.Appearance.Options.UseFont = true;
			this.simpleButton_RealTimePrint.Appearance.Options.UseForeColor = true;
			this.simpleButton_RealTimePrint.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_RealTimePrint.Image")));
			this.simpleButton_RealTimePrint.Location = new System.Drawing.Point(120, 8);
			this.simpleButton_RealTimePrint.Name = "simpleButton_RealTimePrint";
			this.simpleButton_RealTimePrint.Size = new System.Drawing.Size(88, 26);
			this.simpleButton_RealTimePrint.TabIndex = 8;
			this.simpleButton_RealTimePrint.Tag = 4;
			this.simpleButton_RealTimePrint.Text = "报  表";
			this.simpleButton_RealTimePrint.Click += new System.EventHandler(this.simpleButton_RealTimePrint_Click);
			// 
			// RealtimeInfo
			// 
			this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.Appearance.Options.UseBackColor = true;
			this.Controls.Add(this.xtraTabControl1);
			this.Name = "RealtimeInfo";
			this.Size = new System.Drawing.Size(772, 540);
			this.Load += new System.EventHandler(this.RealtimeInfo_Load);
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
			this.xtraTabControl1.ResumeLayout(false);
			this.xtraTabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
			this.splitContainerControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl1_Realtime_Graphic)).EndInit();
			this.groupControl1_Realtime_Graphic.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl_RealtimeStat_Graphic)).EndInit();
			this.groupControl_RealtimeStat_Graphic.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Realtime_GraphicState.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Realtime_GraphicClass.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Realtime_GraphicGrade.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_Realtime_GraphicShow)).EndInit();
			this.groupControl_Realtime_GraphicShow.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.panelControl_Realtime_GraphicShow)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
			this.panelControl2.ResumeLayout(false);
			this.xtraTabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
			this.splitContainerControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl_RealTime)).EndInit();
			this.groupControl_RealTime.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl_RealTimeStat)).EndInit();
			this.groupControl_RealTimeStat.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_RealTimeOption.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_RealTimeClass.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_RealTimeGrade.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_RealTimeMorning)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_RealTimeBack)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void RealtimeInfo_Load(object sender, System.EventArgs e)
		{
			foreach(DataRow getGradeList in getStuInfoByCondition.getGradeInfo("","").Tables[0].Rows)
			{
				comboBoxEdit_RealTimeGrade.Properties.Items.AddRange(
					new object[]{getGradeList[1].ToString()});		
			}

			foreach(DataRow getGradeList in getStuInfoByCondition.getGradeInfo("","").Tables[0].Rows)
			{
				comboBoxEdit_Realtime_GraphicGrade.Properties.Items.AddRange(
					new object[]{getGradeList[1].ToString()});
			}

			//一般教师和创智管理员权限
			if ( Thread.CurrentPrincipal.IsInRole("一般") || Thread.CurrentPrincipal.Identity.Name.ToLower() == "admin" 
				|| Thread.CurrentPrincipal.IsInRole("财务"))
			{
				simpleButton_RealTimePrint.Enabled = false;
				simpleButton_Realtime_GraphicPrint.Enabled = false;
			}

			simpleButton_RealTimeQuery_Click(null, null);
		}

		private void comboBoxEdit_RealTimeGrade_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			comboBoxEdit_RealTimeClass.Properties.Items.Clear();
			comboBoxEdit_RealTimeClass.Properties.Items.AddRange(new object[]{"全部"});
			comboBoxEdit_RealTimeClass.SelectedItem = "全部";
			if ( getStuInfoByCondition.getGradeInfo(comboBoxEdit_RealTimeGrade.SelectedItem.ToString(),"").Tables[0].Rows.Count>0 )
			{
				getGradeNumberFromCombo = getStuInfoByCondition.getGradeInfo(
					comboBoxEdit_RealTimeGrade.SelectedItem.ToString(),"").Tables[0].Rows[0][0].ToString();
				foreach(DataRow getClassList in getStuInfoByCondition.getClassInfo("","",
					getGradeNumberFromCombo).Tables[0].Rows)
				{
					comboBoxEdit_RealTimeClass.Properties.Items.AddRange(
						new object[]{getClassList[1].ToString()});
				}
			}
		}

		private void comboBoxEdit_RealTimeClass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(!comboBoxEdit_RealTimeClass.SelectedItem.ToString().Equals("全部"))
				getClassNumberFromCombo = getStuInfoByCondition.getClassInfo(
					comboBoxEdit_RealTimeClass.SelectedItem.ToString(),"","").Tables[0].Rows[0][0].ToString();
		}

		private void comboBoxEdit_RealTimeOption_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( comboBoxEdit_RealTimeOption.SelectedItem.ToString().Equals("晨检") )
			{
				getRealTimeOption = comboBoxEdit_RealTimeOption.SelectedItem.ToString();
				gridControl_RealTimeMorning.Visible = true;
				gridControl_RealTimeBack.Visible = false;
			}
			else
			{
				getRealTimeOption = comboBoxEdit_RealTimeOption.SelectedItem.ToString();
				gridControl_RealTimeBack.Visible = true;
				gridControl_RealTimeMorning.Visible = false;
			}
		}

		private void simpleButton_RealTimeQuery_Click(object sender, System.EventArgs e)
		{
			if ( getRealTimeOption.Equals("晨检") )
			{
				if ( comboBoxEdit_RealTimeGrade.SelectedItem.ToString().Equals("全部"))
				{
					dsRealtimeMorningInfo = realTimeSumInfo.getRealtimeMorningInfo(DateTime.Now,"","");
					gridControl_RealTimeMorning.DataSource = dsRealtimeMorningInfo.Tables[0];
				}
				else if ( comboBoxEdit_RealTimeClass.SelectedItem.ToString().Equals("全部") )
				{
					dsRealtimeMorningInfo = realTimeSumInfo.getRealtimeMorningInfo(DateTime.Now,getGradeNumberFromCombo,"");
					gridControl_RealTimeMorning.DataSource = dsRealtimeMorningInfo.Tables[0];
				}
				else
				{
					dsRealtimeMorningInfo = realTimeSumInfo.getRealtimeMorningInfo(DateTime.Now,getGradeNumberFromCombo,getClassNumberFromCombo);
					gridControl_RealTimeMorning.DataSource = dsRealtimeMorningInfo.Tables[0];
				}
			}
			else
			{
				if ( comboBoxEdit_RealTimeGrade.SelectedItem.ToString().Equals("全部") )
				{
					dsRealtimeBackInfo = realTimeSumInfo.getRealtimeBackInfo(DateTime.Now,"","");
					gridControl_RealTimeBack.DataSource = dsRealtimeBackInfo.Tables[0];
				}
				else if ( comboBoxEdit_RealTimeClass.SelectedItem.ToString().Equals("全部") )
				{
					dsRealtimeBackInfo = realTimeSumInfo.getRealtimeBackInfo(DateTime.Now,getGradeNumberFromCombo,"");
					gridControl_RealTimeBack.DataSource = dsRealtimeBackInfo.Tables[0];
				}
				else
				{
					dsRealtimeBackInfo = realTimeSumInfo.getRealtimeBackInfo(DateTime.Now,getGradeNumberFromCombo,getClassNumberFromCombo);
					gridControl_RealTimeBack.DataSource = dsRealtimeBackInfo.Tables[0];
				}
			}
		}

		private void simpleButton_RealTimePrint_Click(object sender, System.EventArgs e)
		{
			//班主任权限
			if ( Thread.CurrentPrincipal.IsInRole("班主任") )
			{
				comboBoxEdit_RealTimeGrade.SelectedItem = rolesSystem.GetRolesDuty(Convert.ToInt32(Thread.CurrentPrincipal.Identity.Name)).Tables[0].Rows[0][0].ToString();
				comboBoxEdit_RealTimeClass.SelectedItem = rolesSystem.GetRolesDuty(Convert.ToInt32(Thread.CurrentPrincipal.Identity.Name)).Tables[0].Rows[0][1].ToString();
				simpleButton_RealTimeQuery.PerformClick();
			}

			string savePath;
			saveFileDialog_Report.Filter = "Excel文件|*.xls";

			if ( saveFileDialog_Report.ShowDialog() != DialogResult.OK )
				return;

			savePath = saveFileDialog_Report.FileName;

			if ( getRealTimeOption.Equals("晨检") )
			{
				if ( dsRealtimeMorningInfo != null )
					realTimeInfoPrintSystem.RealtimeMorningInfoPrint(dsRealtimeMorningInfo,savePath);
				else
					MessageBox.Show("报表生成之前，请先对当日晨检信息进行统计！");

				MessageBox.Show("报表生成完毕！");

			}
			else
			{
				if ( dsRealtimeBackInfo != null )
					realTimeInfoPrintSystem.RealtimeBackInfoPrint(dsRealtimeBackInfo,savePath);
				else
					MessageBox.Show("报表生成之前，请先对当日晚接信息进行统计！");

				MessageBox.Show("报表生成完毕！");
			}

		}

		private void comboBoxEdit_Realtime_GraphicGrade_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			comboBoxEdit_Realtime_GraphicClass.Properties.Items.Clear();
			comboBoxEdit_Realtime_GraphicClass.Properties.Items.AddRange(new object[]{"全部"});
			comboBoxEdit_Realtime_GraphicClass.SelectedItem = "全部";
			if(getStuInfoByCondition.getGradeInfo(comboBoxEdit_Realtime_GraphicGrade.SelectedItem.ToString(),"").Tables[0].Rows.Count > 0)
			{
				//根据年级选择获取年级编号
				getGraphicGradeFromCombo = getStuInfoByCondition.getGradeInfo(
					comboBoxEdit_Realtime_GraphicGrade.SelectedItem.ToString(),"").Tables[0].Rows[0][0].ToString();
				foreach(DataRow getClassList in getStuInfoByCondition.getClassInfo("","",
					getGraphicGradeFromCombo).Tables[0].Rows)
				{
					comboBoxEdit_Realtime_GraphicClass.Properties.Items.AddRange(
						new object[]{getClassList[1].ToString()});
				}
			}	

			if ( comboBoxEdit_Realtime_GraphicGrade.SelectedItem.ToString().Equals("全部") )
			{
				getGraphicGradeFromCombo = "";
				getGraphicClassFromCombo = "";
			}

			PrintImage = realTimeInfoPrintSystem.RealtimeInfoPrint_Graphic(getGraphicGradeFromCombo,getGraphicClassFromCombo,panelControl_Realtime_GraphicShow,getGraphicStateFromCombo);
		}

		private void comboBoxEdit_Realtime_GraphicClass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( comboBoxEdit_Realtime_GraphicClass.SelectedItem.ToString().Equals("全部") )
				getGraphicClassFromCombo = "";
			else
				getGraphicClassFromCombo = getStuInfoByCondition.getClassInfo(
					comboBoxEdit_Realtime_GraphicClass.SelectedItem.ToString(),"","").Tables[0].Rows[0][0].ToString();

			PrintImage = realTimeInfoPrintSystem.RealtimeInfoPrint_Graphic(getGraphicGradeFromCombo,getGraphicClassFromCombo,panelControl_Realtime_GraphicShow,getGraphicStateFromCombo);
		}

		private void comboBoxEdit_Realtime_GraphicState_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( comboBoxEdit_Realtime_GraphicState.SelectedIndex == 0 )
				getGraphicStateFromCombo = "晨检";
			else
				getGraphicStateFromCombo = "晚接";

			PrintImage = realTimeInfoPrintSystem.RealtimeInfoPrint_Graphic(getGraphicGradeFromCombo,getGraphicClassFromCombo,panelControl_Realtime_GraphicShow,getGraphicStateFromCombo);
		}

		//窗体装载时发生
		private void splitContainerControl2_SizeChanged(object sender, System.EventArgs e)
		{
			PrintImage = realTimeInfoPrintSystem.RealtimeInfoPrint_Graphic(getGraphicGradeFromCombo,getGraphicClassFromCombo,panelControl_Realtime_GraphicShow,getGraphicStateFromCombo);
		}

		//用户拖动窗体，调整图形大小
		private void panelControl_Realtime_GraphicShow_Resize(object sender, System.EventArgs e)
		{
			PrintImage = realTimeInfoPrintSystem.RealtimeInfoPrint_Graphic(getGraphicGradeFromCombo,getGraphicClassFromCombo,panelControl_Realtime_GraphicShow,getGraphicStateFromCombo);
		}

		private void simpleButton_Realtime_GraphicPrint_Click(object sender, System.EventArgs e)
		{
			//班主任权限
			if ( Thread.CurrentPrincipal.IsInRole("班主任") )
			{
				comboBoxEdit_Realtime_GraphicGrade.SelectedItem = rolesSystem.GetRolesDuty(Convert.ToInt32(Thread.CurrentPrincipal.Identity.Name)).Tables[0].Rows[0][0].ToString();
				comboBoxEdit_Realtime_GraphicClass.SelectedItem = rolesSystem.GetRolesDuty(Convert.ToInt32(Thread.CurrentPrincipal.Identity.Name)).Tables[0].Rows[0][1].ToString();
			}

			if ( PrintImage == null )
				MessageBox.Show("在打印图形报表前，请先对图形报表进行预览！");
			else
			{
                //PrintForm printForm = PrintForm.getInstance();
                //BrickGraphics g = printForm.getPrintInstance().Graph;
                //printForm.getPrintInstance().Begin();
                //g.BackColor = Color.White;
                //g.BorderColor = Color.Black;
                //g.Font = g.DefaultFont;
                //g.StringFormat = g.StringFormat.ChangeLineAlignment(StringAlignment.Near);
                //g.DrawImage(PrintImage, new RectangleF(2000, 50, 700,500), BorderSide.All, Color.White);
                //printForm.getPrintInstance().End();
                //printForm.Show();
			}
		}

		private void simpleButton_RealTimeQuery_Graphic_Click(object sender, System.EventArgs e)
		{
			PrintImage = realTimeInfoPrintSystem.RealtimeInfoPrint_Graphic(getGraphicGradeFromCombo,getGraphicClassFromCombo,panelControl_Realtime_GraphicShow,getGraphicStateFromCombo);
		}

		private Bitmap PrintImage
		{
			get { return this.myImage; }
			set { this.myImage = value; }
		}
	}
}

