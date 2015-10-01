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
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using System.IO;
using CPTT.BusinessFacade;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using CPTT.BusinessRule;

namespace CPTT.WinUI.Panels
{
	/// <summary>
	/// StudentMorningCheckInfo 的摘要说明。
	/// </summary>
	public class StudentMorningCheckInfo : System.Windows.Forms.UserControl
	{
		private DevExpress.XtraTab.XtraTabControl xtraTabControl_CheckInfo;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage_MorningCheck;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage_BackHomeCheck;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage_FreeDefinition;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Status;
		private DevExpress.Utils.Frames.NotePanel notePanel_Status;
		private DevExpress.XtraEditors.GroupControl groupControl_InfoStaticMornig;
		private DevExpress.XtraEditors.TextEdit textEdit_DayAmount;
		private DevExpress.XtraEditors.TextEdit textEdit_ShouldArr;
		private DevExpress.XtraEditors.TextEdit textEdit_Watch;
		private DevExpress.XtraEditors.TextEdit textEdit_Ill;
		private DevExpress.XtraEditors.TextEdit textEdit_Absence;
		private DevExpress.XtraEditors.TextEdit textEdit_Health;
		private DevExpress.Utils.Frames.NotePanel notePanel_DayAmount;
		private DevExpress.Utils.Frames.NotePanel notePanel_ShouldArr;
		private DevExpress.Utils.Frames.NotePanel notePanel_Absence;
		private DevExpress.Utils.Frames.NotePanel notePanel_Watch;
		private DevExpress.Utils.Frames.NotePanel notePanel_Ill;
		private DevExpress.Utils.Frames.NotePanel notePanel_Health;
		private DevExpress.XtraEditors.GroupControl groupControl_FastSerMorning;
		private DevExpress.XtraEditors.GroupControl groupControl_TimeStatusMorning;
		private DevExpress.Utils.Frames.NotePanel notePanel_BegTimeMorning;
		private DevExpress.Utils.Frames.NotePanel notePanel_EndTimeMorning;
		private DevExpress.XtraEditors.GroupControl groupControl_NumberNameMorning;
		private DevExpress.Utils.Frames.NotePanel notePanel_NumberMorning;
		private DevExpress.Utils.Frames.NotePanel notePanel_NameMorning;
		private DevExpress.XtraEditors.GroupControl groupControl_GradeClassMorning;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_ClassMorning;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_GradeMorning;
		private DevExpress.Utils.Frames.NotePanel notePanel1_GradeMorning;
		private DevExpress.Utils.Frames.NotePanel notePanel1_ClassMorning;
		private DevExpress.Utils.Frames.NotePanel notePanel_GradeClassMorning;
		private DevExpress.Utils.Frames.NotePanel notePanel_TimeStatusMorning;
		private DevExpress.Utils.Frames.NotePanel notePanel_NumberNameMorning;
		private DevExpress.Utils.Frames.NotePanel notePanel1_SerCondMorning;
		private DevExpress.XtraEditors.SimpleButton simpleButton_SearchMorning;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
		private DevExpress.XtraEditors.GroupControl groupControl_FastSerBack;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_BackCond;
		private DevExpress.Utils.Frames.NotePanel notePanel_BackCond;
		private DevExpress.Utils.Frames.NotePanel notePanel_BegTimeBack;
		private DevExpress.Utils.Frames.NotePanel notePanel_EndTimeBack;
		private DevExpress.XtraEditors.GroupControl groupControl_NumberNameBack;
		private DevExpress.XtraEditors.TextEdit textEdit_NameBack;
		private DevExpress.XtraEditors.TextEdit textEdit_NumberBack;
		private DevExpress.Utils.Frames.NotePanel notePanel_NumberBack;
		private DevExpress.Utils.Frames.NotePanel notePanel1_NameBack;
		private DevExpress.XtraEditors.GroupControl groupControl_GradeClassBack;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_ClassBack;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_GradeBack;
		private DevExpress.Utils.Frames.NotePanel notePanel1_GradeBack;
		private DevExpress.Utils.Frames.NotePanel notePanel1_ClassBack;
		private DevExpress.Utils.Frames.NotePanel notePanel_GradeClassBack;
		private DevExpress.Utils.Frames.NotePanel notePanel_TimeConBack;
		private DevExpress.Utils.Frames.NotePanel notePanel_NumberNameBack;
		private DevExpress.Utils.Frames.NotePanel notePanel_SerCondBack;
		private DevExpress.XtraEditors.GroupControl groupControl_TimeCondBack;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl3;
		private DevExpress.XtraEditors.GroupControl groupControl_FastSerFreeDef;
		private DevExpress.Utils.Frames.NotePanel notePanel_FreeDef;
		private DevExpress.Utils.Frames.NotePanel notePanel_BegTimeFreeDef;
		private DevExpress.Utils.Frames.NotePanel notePanel_EndTimeFreeDef;
		private DevExpress.XtraEditors.TextEdit textEdit_NameFreeDef;
		private DevExpress.XtraEditors.TextEdit textEdit_NumberFreeDef;
		private DevExpress.Utils.Frames.NotePanel notePanel_NumberFreeDef;
		private DevExpress.Utils.Frames.NotePanel notePanel_NameFreeDef;
		private DevExpress.Utils.Frames.NotePanel notePanel_GradeClassFreeDef;
		private DevExpress.Utils.Frames.NotePanel notePanel_TimeStatusFreeDef;
		private DevExpress.Utils.Frames.NotePanel notePanel_NumberNameFreeDef;
		private DevExpress.Utils.Frames.NotePanel notePanel1_SerCondFreeDef;
		private DevExpress.XtraEditors.SimpleButton simpleButton_SearchBack;
		private DevExpress.XtraEditors.GroupControl groupControl_NumberNameFreeDef;
		private DevExpress.XtraEditors.GroupControl groupControl_GradeClassFreeDef;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_ClassFreeDef;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_GradeFreeDef;
		private DevExpress.Utils.Frames.NotePanel notePanel_GradeFreeDef;
		private DevExpress.Utils.Frames.NotePanel notePanel_ClassFreeDef;
		private DevExpress.XtraEditors.SimpleButton simpleButton_SearchFreeDef;
		private DevExpress.XtraEditors.GroupControl groupControl_TimeStatusFreeDef;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage_MoreReport;
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private DevExpress.XtraGrid.GridControl gridControl_MorningInfo;
		private DevExpress.XtraEditors.PanelControl panelControl2;
		private DevExpress.XtraGrid.GridControl gridControl_BackInfo;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraEditors.PanelControl panelControl3;
		private DevExpress.XtraGrid.GridControl gridControl_FreeDef;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
		private GetStuInfoByCondition getStuInfoByCondition;
		private StuAttendCalc stuAttendCalc;
		private StudentCheckInfo stuCheckInfo;
		private string getMorGradeNumberFromCombo;
		private string getMorClassNumberFromCombo;
		private string getBackGradeNumberFromCombo;
		private string getBackClassNumberFromCombo;
		private string getCustomGradeNumberFromCombo;
		private string getCustomClassNumberFromCombo;
		private string getRepGradeNumberFromCombo;
		private string getRepClassNumberFromCombo;
		private string getMorningStateFromCombo = "";
		private string getBackStateFromCombo = "已接走";
		private string getCustomStateFromCombo = "";
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_CustomStatusDef;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox_Status;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox_CustomState;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl4;
		private DevExpress.XtraEditors.PanelControl panelControl4;
		private DevExpress.XtraEditors.GroupControl groupControl_FastSerReport;
		private DevExpress.Utils.Frames.NotePanel notePanel_SerCondReport;
		private DevExpress.XtraEditors.GroupControl groupControl_PreviewReport;
		private DevExpress.XtraEditors.SimpleButton simpleButton_PreviewReport;
		private DevExpress.XtraEditors.SimpleButton simpleButton_PrintReport;
		private DevExpress.Utils.Frames.NotePanel notePanel_GradeReport;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_GradeReport;
		private DevExpress.Utils.Frames.NotePanel notePanel_ClassReport;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_ClassReport;
		private DevExpress.Utils.Frames.NotePanel notePanel_BegDateReport;
		private DevExpress.Utils.Frames.NotePanel notePanel_EndDateReport;
		private StuMorningCheckInfoPrintSystem stuMorningCheckInfoPrintSystem;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_PrintType;
		private DevExpress.Utils.Frames.NotePanel notePanel_PrintType;
		private Bitmap myImage = null;
		private string getOrigState;
		private bool showUpdate = true;
		private DevExpress.Utils.Frames.NotePanel notePanel_TimeModeMorning;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_TimeModeMorning;
		private DevExpress.XtraEditors.TextEdit textEdit_BegTimeMorning;
		private DevExpress.XtraEditors.TextEdit textEdit_EndTimeMorning;

		private bool isFullDateMorning = false;
		private string morBegDate;
		private string morEndDate;
		private DevExpress.XtraEditors.TextEdit textEdit_BegTimeBack;
		private DevExpress.XtraEditors.TextEdit textEdit_EndTimeBack;
		private DevExpress.Utils.Frames.NotePanel notePanel_TimeModeBack;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_TimeModeBack;

		private bool isFullDateBack = false;
		private string backBegDate;
		private string backEndDate;
		private DevExpress.Utils.Frames.NotePanel notePanel_TimeMode_FreeDef;
		private DevExpress.XtraEditors.TextEdit textEdit_BegTimeFreeDef;
		private DevExpress.XtraEditors.TextEdit textEdit_EndTimeFreeDef;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_TimeModeFreeDef;

		private bool isFullDateFreeDef = false;
		private string freeDefBegDate;
		private string freeDefEndDate;
		private DevExpress.Utils.Frames.NotePanel notePanel_SpecificDateMorning;
		private DevExpress.XtraEditors.DateEdit dateEdit_SpecificDateMorning;
		private DevExpress.Utils.Frames.NotePanel notePanel_SpecificDateBack;
		private DevExpress.XtraEditors.DateEdit dateEdit_SpecificDateBack;
		private DevExpress.Utils.Frames.NotePanel notePanel_SpecificDateFreeDef;
		private DevExpress.XtraEditors.DateEdit dateEdit_SpecificDateFreeDef;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.Utils.Frames.NotePanel notePanel_HasGone;
		private DevExpress.XtraEditors.TextEdit textEdit_HasGone;
		private DevExpress.Utils.Frames.NotePanel notePanel_HasnotGone;
		private DevExpress.XtraEditors.TextEdit textEdit_HasnotGone;
		private DevExpress.Utils.Frames.NotePanel notePanel_ShouldGo;
		private DevExpress.XtraEditors.TextEdit textEdit_ShouldGo;
		private DevExpress.XtraEditors.SimpleButton simpleButton_PrintBack;
		private DevExpress.XtraEditors.SimpleButton simpleButton_PrintMorning;

		private DataSet dsMorningCheckInfo;
		private DataSet dsBackCheckInfo;
		private string morPath = Directory.GetCurrentDirectory() + @"\report\MorningCheckInfo.xls";
		private string morDestPath = Directory.GetCurrentDirectory() + @"\report\MorningCheckInfoCopy.xls";
		private System.Windows.Forms.SaveFileDialog saveFileDialog_Report;
		private DevExpress.Utils.Frames.NotePanel notePanel_HaveArr;
		private DevExpress.XtraEditors.TextEdit textEdit_HaveArr;
		private DevExpress.Utils.Frames.NotePanel notePanel_NumberReport;
		private DevExpress.Utils.Frames.NotePanel notePanel_NameReport;
		private DevExpress.XtraEditors.TextEdit textEdit_NameReport;
		private DevExpress.XtraEditors.TextEdit textEdit_NumberReport;
		private DevExpress.XtraEditors.TextEdit textEdit_BegDateReport;
		private DevExpress.XtraEditors.TextEdit textEdit_EndDateReport;
		private DevExpress.XtraEditors.TextEdit textEdit_CurRecTimeBinding;
		private DevExpress.XtraEditors.TextEdit textEdit_OrigStateBinding;
		private DevExpress.XtraEditors.TextEdit textEdit_NameMorning;
		private DevExpress.XtraEditors.TextEdit textEdit_NumberMorning;
		private RolesSystem rolesSystem;
		private System.Windows.Forms.HelpProvider helpProvider_StuMorningCheckInfo;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private Panel panel1;
        private TreeView treeView1;
        private Panel panel2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedComboBoxEdit1;
        private ComboBox comboBox1;
        private Label label1;
        private ProgressBar progressBar1;

        private SynchronizationContext context = null;

		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public StudentMorningCheckInfo()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();

			// TODO: 在 InitializeComponent 调用后添加任何初始化
			getStuInfoByCondition = new GetStuInfoByCondition();
			stuAttendCalc = new StuAttendCalc();
			stuCheckInfo = new StudentCheckInfo();
			stuMorningCheckInfoPrintSystem = new StuMorningCheckInfoPrintSystem();
			rolesSystem = new RolesSystem();

			#region 帮助
			helpProvider_StuMorningCheckInfo.HelpNamespace = System.IO.Path.GetDirectoryName(Application.ExecutablePath)
				+ CPTT.SystemFramework.Util.HELP_FILE_NAME;

			this.helpProvider_StuMorningCheckInfo.SetHelpKeyword(this.xtraTabPage_MorningCheck,"幼儿晨检信息查询");
			this.helpProvider_StuMorningCheckInfo.SetHelpNavigator(this.xtraTabPage_MorningCheck, System.Windows.Forms.HelpNavigator.KeywordIndex);
			this.helpProvider_StuMorningCheckInfo.SetHelpString(this.xtraTabPage_MorningCheck, "");
			this.helpProvider_StuMorningCheckInfo.SetShowHelp(this.xtraTabPage_MorningCheck, true);

			this.helpProvider_StuMorningCheckInfo.SetHelpKeyword(this.xtraTabPage_BackHomeCheck,"幼儿晚接信息查询");
			this.helpProvider_StuMorningCheckInfo.SetHelpNavigator(this.xtraTabPage_BackHomeCheck, System.Windows.Forms.HelpNavigator.KeywordIndex);
			this.helpProvider_StuMorningCheckInfo.SetHelpString(this.xtraTabPage_BackHomeCheck, "");
			this.helpProvider_StuMorningCheckInfo.SetShowHelp(this.xtraTabPage_BackHomeCheck, true);

			this.helpProvider_StuMorningCheckInfo.SetHelpKeyword(this.xtraTabPage_FreeDefinition,"幼儿自定义信息查询");
			this.helpProvider_StuMorningCheckInfo.SetHelpNavigator(this.xtraTabPage_FreeDefinition, System.Windows.Forms.HelpNavigator.KeywordIndex);
			this.helpProvider_StuMorningCheckInfo.SetHelpString(this.xtraTabPage_FreeDefinition, "");
			this.helpProvider_StuMorningCheckInfo.SetShowHelp(this.xtraTabPage_FreeDefinition, true);

			this.helpProvider_StuMorningCheckInfo.SetHelpKeyword(this.xtraTabPage_MoreReport,"晨检信息综合统计报表");
			this.helpProvider_StuMorningCheckInfo.SetHelpNavigator(this.xtraTabPage_MoreReport, System.Windows.Forms.HelpNavigator.KeywordIndex);
			this.helpProvider_StuMorningCheckInfo.SetHelpString(this.xtraTabPage_MoreReport, "");
			this.helpProvider_StuMorningCheckInfo.SetShowHelp(this.xtraTabPage_MoreReport, true);
			#endregion
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

		#region 组件设计器生成的代码
		/// <summary> 
		/// 设计器支持所需的方法 - 不要使用代码编辑器 
		/// 修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentMorningCheckInfo));
            this.xtraTabControl_CheckInfo = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage_MorningCheck = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl_InfoStaticMornig = new DevExpress.XtraEditors.GroupControl();
            this.textEdit_HaveArr = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_HaveArr = new DevExpress.Utils.Frames.NotePanel();
            this.textEdit_DayAmount = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_ShouldArr = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_Watch = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_Ill = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_Absence = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_Health = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_DayAmount = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_ShouldArr = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_Absence = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_Watch = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_Ill = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_Health = new DevExpress.Utils.Frames.NotePanel();
            this.textEdit_CurRecTimeBinding = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_OrigStateBinding = new DevExpress.XtraEditors.TextEdit();
            this.groupControl_FastSerMorning = new DevExpress.XtraEditors.GroupControl();
            this.groupControl_TimeStatusMorning = new DevExpress.XtraEditors.GroupControl();
            this.dateEdit_SpecificDateMorning = new DevExpress.XtraEditors.DateEdit();
            this.notePanel_SpecificDateMorning = new DevExpress.Utils.Frames.NotePanel();
            this.textEdit_EndTimeMorning = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_BegTimeMorning = new DevExpress.XtraEditors.TextEdit();
            this.comboBoxEdit_TimeModeMorning = new DevExpress.XtraEditors.ComboBoxEdit();
            this.notePanel_TimeModeMorning = new DevExpress.Utils.Frames.NotePanel();
            this.comboBoxEdit_Status = new DevExpress.XtraEditors.ComboBoxEdit();
            this.notePanel_Status = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_BegTimeMorning = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_EndTimeMorning = new DevExpress.Utils.Frames.NotePanel();
            this.groupControl_NumberNameMorning = new DevExpress.XtraEditors.GroupControl();
            this.textEdit_NumberMorning = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_NameMorning = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_NumberMorning = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_NameMorning = new DevExpress.Utils.Frames.NotePanel();
            this.groupControl_GradeClassMorning = new DevExpress.XtraEditors.GroupControl();
            this.comboBoxEdit_ClassMorning = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEdit_GradeMorning = new DevExpress.XtraEditors.ComboBoxEdit();
            this.notePanel1_GradeMorning = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel1_ClassMorning = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_GradeClassMorning = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_TimeStatusMorning = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_NumberNameMorning = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel1_SerCondMorning = new DevExpress.Utils.Frames.NotePanel();
            this.gridControl_MorningInfo = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox_Status = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton_PrintMorning = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_SearchMorning = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPage_BackHomeCheck = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.textEdit_ShouldGo = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_ShouldGo = new DevExpress.Utils.Frames.NotePanel();
            this.textEdit_HasnotGone = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_HasnotGone = new DevExpress.Utils.Frames.NotePanel();
            this.textEdit_HasGone = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_HasGone = new DevExpress.Utils.Frames.NotePanel();
            this.groupControl_FastSerBack = new DevExpress.XtraEditors.GroupControl();
            this.groupControl_TimeCondBack = new DevExpress.XtraEditors.GroupControl();
            this.dateEdit_SpecificDateBack = new DevExpress.XtraEditors.DateEdit();
            this.notePanel_SpecificDateBack = new DevExpress.Utils.Frames.NotePanel();
            this.comboBoxEdit_TimeModeBack = new DevExpress.XtraEditors.ComboBoxEdit();
            this.notePanel_TimeModeBack = new DevExpress.Utils.Frames.NotePanel();
            this.textEdit_EndTimeBack = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_BegTimeBack = new DevExpress.XtraEditors.TextEdit();
            this.comboBoxEdit_BackCond = new DevExpress.XtraEditors.ComboBoxEdit();
            this.notePanel_BackCond = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_BegTimeBack = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_EndTimeBack = new DevExpress.Utils.Frames.NotePanel();
            this.groupControl_NumberNameBack = new DevExpress.XtraEditors.GroupControl();
            this.textEdit_NameBack = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_NumberBack = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_NumberBack = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel1_NameBack = new DevExpress.Utils.Frames.NotePanel();
            this.groupControl_GradeClassBack = new DevExpress.XtraEditors.GroupControl();
            this.comboBoxEdit_ClassBack = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEdit_GradeBack = new DevExpress.XtraEditors.ComboBoxEdit();
            this.notePanel1_GradeBack = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel1_ClassBack = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_GradeClassBack = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_TimeConBack = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_NumberNameBack = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_SerCondBack = new DevExpress.Utils.Frames.NotePanel();
            this.gridControl_BackInfo = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton_PrintBack = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_SearchBack = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPage_FreeDefinition = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl3 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl_FastSerFreeDef = new DevExpress.XtraEditors.GroupControl();
            this.groupControl_TimeStatusFreeDef = new DevExpress.XtraEditors.GroupControl();
            this.dateEdit_SpecificDateFreeDef = new DevExpress.XtraEditors.DateEdit();
            this.notePanel_SpecificDateFreeDef = new DevExpress.Utils.Frames.NotePanel();
            this.comboBoxEdit_TimeModeFreeDef = new DevExpress.XtraEditors.ComboBoxEdit();
            this.textEdit_EndTimeFreeDef = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_BegTimeFreeDef = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_TimeMode_FreeDef = new DevExpress.Utils.Frames.NotePanel();
            this.comboBoxEdit_CustomStatusDef = new DevExpress.XtraEditors.ComboBoxEdit();
            this.notePanel_FreeDef = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_BegTimeFreeDef = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_EndTimeFreeDef = new DevExpress.Utils.Frames.NotePanel();
            this.groupControl_NumberNameFreeDef = new DevExpress.XtraEditors.GroupControl();
            this.textEdit_NameFreeDef = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_NumberFreeDef = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_NumberFreeDef = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_NameFreeDef = new DevExpress.Utils.Frames.NotePanel();
            this.groupControl_GradeClassFreeDef = new DevExpress.XtraEditors.GroupControl();
            this.comboBoxEdit_ClassFreeDef = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEdit_GradeFreeDef = new DevExpress.XtraEditors.ComboBoxEdit();
            this.notePanel_GradeFreeDef = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_ClassFreeDef = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_GradeClassFreeDef = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_TimeStatusFreeDef = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_NumberNameFreeDef = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel1_SerCondFreeDef = new DevExpress.Utils.Frames.NotePanel();
            this.gridControl_FreeDef = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox_CustomState = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton_SearchFreeDef = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPage_MoreReport = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl4 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl_FastSerReport = new DevExpress.XtraEditors.GroupControl();
            this.textEdit_EndDateReport = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_BegDateReport = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_NumberReport = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_NameReport = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_NumberReport = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_NameReport = new DevExpress.Utils.Frames.NotePanel();
            this.comboBoxEdit_PrintType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.notePanel_PrintType = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_EndDateReport = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_BegDateReport = new DevExpress.Utils.Frames.NotePanel();
            this.comboBoxEdit_ClassReport = new DevExpress.XtraEditors.ComboBoxEdit();
            this.notePanel_ClassReport = new DevExpress.Utils.Frames.NotePanel();
            this.comboBoxEdit_GradeReport = new DevExpress.XtraEditors.ComboBoxEdit();
            this.notePanel_GradeReport = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_SerCondReport = new DevExpress.Utils.Frames.NotePanel();
            this.groupControl_PreviewReport = new DevExpress.XtraEditors.GroupControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton_PrintReport = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_PreviewReport = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.checkedComboBoxEdit1 = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.saveFileDialog_Report = new System.Windows.Forms.SaveFileDialog();
            this.helpProvider_StuMorningCheckInfo = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_CheckInfo)).BeginInit();
            this.xtraTabControl_CheckInfo.SuspendLayout();
            this.xtraTabPage_MorningCheck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_InfoStaticMornig)).BeginInit();
            this.groupControl_InfoStaticMornig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_HaveArr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_DayAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_ShouldArr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Watch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Ill.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Absence.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Health.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_CurRecTimeBinding.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_OrigStateBinding.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_FastSerMorning)).BeginInit();
            this.groupControl_FastSerMorning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_TimeStatusMorning)).BeginInit();
            this.groupControl_TimeStatusMorning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_SpecificDateMorning.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_SpecificDateMorning.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_EndTimeMorning.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_BegTimeMorning.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_TimeModeMorning.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Status.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_NumberNameMorning)).BeginInit();
            this.groupControl_NumberNameMorning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_NumberMorning.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_NameMorning.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_GradeClassMorning)).BeginInit();
            this.groupControl_GradeClassMorning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_ClassMorning.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_GradeMorning.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_MorningInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox_Status)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.xtraTabPage_BackHomeCheck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_ShouldGo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_HasnotGone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_HasGone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_FastSerBack)).BeginInit();
            this.groupControl_FastSerBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_TimeCondBack)).BeginInit();
            this.groupControl_TimeCondBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_SpecificDateBack.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_SpecificDateBack.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_TimeModeBack.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_EndTimeBack.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_BegTimeBack.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_BackCond.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_NumberNameBack)).BeginInit();
            this.groupControl_NumberNameBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_NameBack.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_NumberBack.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_GradeClassBack)).BeginInit();
            this.groupControl_GradeClassBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_ClassBack.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_GradeBack.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_BackInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.xtraTabPage_FreeDefinition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).BeginInit();
            this.splitContainerControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_FastSerFreeDef)).BeginInit();
            this.groupControl_FastSerFreeDef.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_TimeStatusFreeDef)).BeginInit();
            this.groupControl_TimeStatusFreeDef.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_SpecificDateFreeDef.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_SpecificDateFreeDef.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_TimeModeFreeDef.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_EndTimeFreeDef.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_BegTimeFreeDef.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_CustomStatusDef.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_NumberNameFreeDef)).BeginInit();
            this.groupControl_NumberNameFreeDef.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_NameFreeDef.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_NumberFreeDef.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_GradeClassFreeDef)).BeginInit();
            this.groupControl_GradeClassFreeDef.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_ClassFreeDef.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_GradeFreeDef.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_FreeDef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox_CustomState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.xtraTabPage_MoreReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl4)).BeginInit();
            this.splitContainerControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_FastSerReport)).BeginInit();
            this.groupControl_FastSerReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_EndDateReport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_BegDateReport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_NumberReport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_NameReport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_PrintType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_ClassReport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_GradeReport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_PreviewReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl_CheckInfo
            // 
            this.xtraTabControl_CheckInfo.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xtraTabControl_CheckInfo.Appearance.Options.UseBackColor = true;
            this.xtraTabControl_CheckInfo.AppearancePage.HeaderActive.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtraTabControl_CheckInfo.AppearancePage.HeaderActive.ForeColor = System.Drawing.Color.DarkOrange;
            this.xtraTabControl_CheckInfo.AppearancePage.HeaderActive.Options.UseFont = true;
            this.xtraTabControl_CheckInfo.AppearancePage.HeaderActive.Options.UseForeColor = true;
            this.xtraTabControl_CheckInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl_CheckInfo.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl_CheckInfo.Name = "xtraTabControl_CheckInfo";
            this.xtraTabControl_CheckInfo.SelectedTabPage = this.xtraTabPage_MorningCheck;
            this.xtraTabControl_CheckInfo.Size = new System.Drawing.Size(772, 540);
            this.xtraTabControl_CheckInfo.TabIndex = 0;
            this.xtraTabControl_CheckInfo.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage_MorningCheck,
            this.xtraTabPage_BackHomeCheck,
            this.xtraTabPage_FreeDefinition,
            this.xtraTabPage_MoreReport,
            this.xtraTabPage1});
            // 
            // xtraTabPage_MorningCheck
            // 
            this.xtraTabPage_MorningCheck.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xtraTabPage_MorningCheck.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabPage_MorningCheck.Controls.Add(this.splitContainerControl1);
            this.xtraTabPage_MorningCheck.Name = "xtraTabPage_MorningCheck";
            this.xtraTabPage_MorningCheck.Size = new System.Drawing.Size(766, 511);
            this.xtraTabPage_MorningCheck.Text = "幼儿晨检信息查询";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl_InfoStaticMornig);
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl_FastSerMorning);
            this.splitContainerControl1.Panel1.Text = "splitContainerControl1_Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl_MorningInfo);
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl1);
            this.splitContainerControl1.Panel2.Text = "splitContainerControl1_Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(766, 511);
            this.splitContainerControl1.SplitterPosition = 239;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl_InfoStaticMornig
            // 
            this.groupControl_InfoStaticMornig.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_InfoStaticMornig.AppearanceCaption.Options.UseFont = true;
            this.groupControl_InfoStaticMornig.Controls.Add(this.textEdit_HaveArr);
            this.groupControl_InfoStaticMornig.Controls.Add(this.notePanel_HaveArr);
            this.groupControl_InfoStaticMornig.Controls.Add(this.textEdit_DayAmount);
            this.groupControl_InfoStaticMornig.Controls.Add(this.textEdit_ShouldArr);
            this.groupControl_InfoStaticMornig.Controls.Add(this.textEdit_Watch);
            this.groupControl_InfoStaticMornig.Controls.Add(this.textEdit_Ill);
            this.groupControl_InfoStaticMornig.Controls.Add(this.textEdit_Absence);
            this.groupControl_InfoStaticMornig.Controls.Add(this.textEdit_Health);
            this.groupControl_InfoStaticMornig.Controls.Add(this.notePanel_DayAmount);
            this.groupControl_InfoStaticMornig.Controls.Add(this.notePanel_ShouldArr);
            this.groupControl_InfoStaticMornig.Controls.Add(this.notePanel_Absence);
            this.groupControl_InfoStaticMornig.Controls.Add(this.notePanel_Watch);
            this.groupControl_InfoStaticMornig.Controls.Add(this.notePanel_Ill);
            this.groupControl_InfoStaticMornig.Controls.Add(this.notePanel_Health);
            this.groupControl_InfoStaticMornig.Controls.Add(this.textEdit_CurRecTimeBinding);
            this.groupControl_InfoStaticMornig.Controls.Add(this.textEdit_OrigStateBinding);
            this.groupControl_InfoStaticMornig.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl_InfoStaticMornig.Location = new System.Drawing.Point(0, 312);
            this.groupControl_InfoStaticMornig.Name = "groupControl_InfoStaticMornig";
            this.groupControl_InfoStaticMornig.Size = new System.Drawing.Size(239, 256);
            this.groupControl_InfoStaticMornig.TabIndex = 8;
            this.groupControl_InfoStaticMornig.Text = "晨检信息统计";
            // 
            // textEdit_HaveArr
            // 
            this.textEdit_HaveArr.EditValue = "";
            this.textEdit_HaveArr.Location = new System.Drawing.Point(88, 128);
            this.textEdit_HaveArr.Name = "textEdit_HaveArr";
            this.textEdit_HaveArr.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_HaveArr.Properties.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.textEdit_HaveArr.Properties.Appearance.Options.UseFont = true;
            this.textEdit_HaveArr.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit_HaveArr.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit_HaveArr.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEdit_HaveArr.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.AntiqueWhite;
            this.textEdit_HaveArr.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.textEdit_HaveArr.Size = new System.Drawing.Size(128, 24);
            this.textEdit_HaveArr.TabIndex = 27;
            // 
            // notePanel_HaveArr
            // 
            this.notePanel_HaveArr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_HaveArr.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_HaveArr.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_HaveArr.ForeColor = System.Drawing.Color.Black;
            this.notePanel_HaveArr.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_HaveArr.Location = new System.Drawing.Point(16, 128);
            this.notePanel_HaveArr.MaxRows = 5;
            this.notePanel_HaveArr.Name = "notePanel_HaveArr";
            this.notePanel_HaveArr.ParentAutoHeight = true;
            this.notePanel_HaveArr.Size = new System.Drawing.Size(64, 22);
            this.notePanel_HaveArr.TabIndex = 26;
            this.notePanel_HaveArr.TabStop = false;
            this.notePanel_HaveArr.Text = "实出勤:";
            // 
            // textEdit_DayAmount
            // 
            this.textEdit_DayAmount.EditValue = "";
            this.textEdit_DayAmount.Location = new System.Drawing.Point(128, 224);
            this.textEdit_DayAmount.Name = "textEdit_DayAmount";
            this.textEdit_DayAmount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_DayAmount.Properties.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.textEdit_DayAmount.Properties.Appearance.Options.UseFont = true;
            this.textEdit_DayAmount.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit_DayAmount.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit_DayAmount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEdit_DayAmount.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.AntiqueWhite;
            this.textEdit_DayAmount.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.textEdit_DayAmount.Size = new System.Drawing.Size(88, 24);
            this.textEdit_DayAmount.TabIndex = 25;
            // 
            // textEdit_ShouldArr
            // 
            this.textEdit_ShouldArr.EditValue = "";
            this.textEdit_ShouldArr.Location = new System.Drawing.Point(128, 192);
            this.textEdit_ShouldArr.Name = "textEdit_ShouldArr";
            this.textEdit_ShouldArr.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_ShouldArr.Properties.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.textEdit_ShouldArr.Properties.Appearance.Options.UseFont = true;
            this.textEdit_ShouldArr.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit_ShouldArr.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit_ShouldArr.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEdit_ShouldArr.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.AntiqueWhite;
            this.textEdit_ShouldArr.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.textEdit_ShouldArr.Size = new System.Drawing.Size(88, 24);
            this.textEdit_ShouldArr.TabIndex = 24;
            // 
            // textEdit_Watch
            // 
            this.textEdit_Watch.EditValue = "";
            this.textEdit_Watch.Location = new System.Drawing.Point(88, 96);
            this.textEdit_Watch.Name = "textEdit_Watch";
            this.textEdit_Watch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_Watch.Properties.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.textEdit_Watch.Properties.Appearance.Options.UseFont = true;
            this.textEdit_Watch.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit_Watch.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit_Watch.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEdit_Watch.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.AntiqueWhite;
            this.textEdit_Watch.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.textEdit_Watch.Size = new System.Drawing.Size(128, 24);
            this.textEdit_Watch.TabIndex = 23;
            // 
            // textEdit_Ill
            // 
            this.textEdit_Ill.EditValue = "";
            this.textEdit_Ill.Location = new System.Drawing.Point(88, 64);
            this.textEdit_Ill.Name = "textEdit_Ill";
            this.textEdit_Ill.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_Ill.Properties.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.textEdit_Ill.Properties.Appearance.Options.UseFont = true;
            this.textEdit_Ill.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit_Ill.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit_Ill.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEdit_Ill.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.AntiqueWhite;
            this.textEdit_Ill.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.textEdit_Ill.Size = new System.Drawing.Size(128, 24);
            this.textEdit_Ill.TabIndex = 22;
            // 
            // textEdit_Absence
            // 
            this.textEdit_Absence.EditValue = "";
            this.textEdit_Absence.Location = new System.Drawing.Point(88, 160);
            this.textEdit_Absence.Name = "textEdit_Absence";
            this.textEdit_Absence.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_Absence.Properties.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.textEdit_Absence.Properties.Appearance.Options.UseFont = true;
            this.textEdit_Absence.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit_Absence.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit_Absence.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEdit_Absence.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.AntiqueWhite;
            this.textEdit_Absence.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.textEdit_Absence.Size = new System.Drawing.Size(128, 24);
            this.textEdit_Absence.TabIndex = 21;
            // 
            // textEdit_Health
            // 
            this.textEdit_Health.EditValue = "";
            this.textEdit_Health.Location = new System.Drawing.Point(88, 32);
            this.textEdit_Health.Name = "textEdit_Health";
            this.textEdit_Health.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_Health.Properties.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.textEdit_Health.Properties.Appearance.Options.UseFont = true;
            this.textEdit_Health.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit_Health.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit_Health.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEdit_Health.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.AntiqueWhite;
            this.textEdit_Health.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.textEdit_Health.Size = new System.Drawing.Size(128, 24);
            this.textEdit_Health.TabIndex = 20;
            // 
            // notePanel_DayAmount
            // 
            this.notePanel_DayAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_DayAmount.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_DayAmount.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_DayAmount.ForeColor = System.Drawing.Color.Black;
            this.notePanel_DayAmount.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_DayAmount.Location = new System.Drawing.Point(16, 224);
            this.notePanel_DayAmount.MaxRows = 5;
            this.notePanel_DayAmount.Name = "notePanel_DayAmount";
            this.notePanel_DayAmount.ParentAutoHeight = true;
            this.notePanel_DayAmount.Size = new System.Drawing.Size(104, 22);
            this.notePanel_DayAmount.TabIndex = 10;
            this.notePanel_DayAmount.TabStop = false;
            this.notePanel_DayAmount.Text = "应到天数总和:";
            // 
            // notePanel_ShouldArr
            // 
            this.notePanel_ShouldArr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_ShouldArr.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_ShouldArr.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_ShouldArr.ForeColor = System.Drawing.Color.Black;
            this.notePanel_ShouldArr.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_ShouldArr.Location = new System.Drawing.Point(16, 192);
            this.notePanel_ShouldArr.MaxRows = 5;
            this.notePanel_ShouldArr.Name = "notePanel_ShouldArr";
            this.notePanel_ShouldArr.ParentAutoHeight = true;
            this.notePanel_ShouldArr.Size = new System.Drawing.Size(104, 22);
            this.notePanel_ShouldArr.TabIndex = 9;
            this.notePanel_ShouldArr.TabStop = false;
            this.notePanel_ShouldArr.Text = "应到人数总和:";
            // 
            // notePanel_Absence
            // 
            this.notePanel_Absence.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Absence.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Absence.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Absence.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Absence.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Absence.Location = new System.Drawing.Point(16, 160);
            this.notePanel_Absence.MaxRows = 5;
            this.notePanel_Absence.Name = "notePanel_Absence";
            this.notePanel_Absence.ParentAutoHeight = true;
            this.notePanel_Absence.Size = new System.Drawing.Size(64, 22);
            this.notePanel_Absence.TabIndex = 8;
            this.notePanel_Absence.TabStop = false;
            this.notePanel_Absence.Text = "缺  席:";
            // 
            // notePanel_Watch
            // 
            this.notePanel_Watch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Watch.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Watch.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Watch.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Watch.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Watch.Location = new System.Drawing.Point(16, 96);
            this.notePanel_Watch.MaxRows = 5;
            this.notePanel_Watch.Name = "notePanel_Watch";
            this.notePanel_Watch.ParentAutoHeight = true;
            this.notePanel_Watch.Size = new System.Drawing.Size(64, 22);
            this.notePanel_Watch.TabIndex = 7;
            this.notePanel_Watch.TabStop = false;
            this.notePanel_Watch.Text = "观  察:";
            // 
            // notePanel_Ill
            // 
            this.notePanel_Ill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Ill.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Ill.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Ill.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Ill.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Ill.Location = new System.Drawing.Point(16, 64);
            this.notePanel_Ill.MaxRows = 5;
            this.notePanel_Ill.Name = "notePanel_Ill";
            this.notePanel_Ill.ParentAutoHeight = true;
            this.notePanel_Ill.Size = new System.Drawing.Size(64, 22);
            this.notePanel_Ill.TabIndex = 6;
            this.notePanel_Ill.TabStop = false;
            this.notePanel_Ill.Text = "服  药:";
            // 
            // notePanel_Health
            // 
            this.notePanel_Health.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Health.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Health.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Health.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Health.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Health.Location = new System.Drawing.Point(16, 32);
            this.notePanel_Health.MaxRows = 5;
            this.notePanel_Health.Name = "notePanel_Health";
            this.notePanel_Health.ParentAutoHeight = true;
            this.notePanel_Health.Size = new System.Drawing.Size(64, 22);
            this.notePanel_Health.TabIndex = 5;
            this.notePanel_Health.TabStop = false;
            this.notePanel_Health.Text = "健  康:";
            // 
            // textEdit_CurRecTimeBinding
            // 
            this.textEdit_CurRecTimeBinding.EditValue = "";
            this.textEdit_CurRecTimeBinding.Location = new System.Drawing.Point(136, 40);
            this.textEdit_CurRecTimeBinding.Name = "textEdit_CurRecTimeBinding";
            this.textEdit_CurRecTimeBinding.Properties.AutoHeight = false;
            this.textEdit_CurRecTimeBinding.Size = new System.Drawing.Size(16, 8);
            this.textEdit_CurRecTimeBinding.TabIndex = 12;
            // 
            // textEdit_OrigStateBinding
            // 
            this.textEdit_OrigStateBinding.EditValue = "";
            this.textEdit_OrigStateBinding.Location = new System.Drawing.Point(136, 72);
            this.textEdit_OrigStateBinding.Name = "textEdit_OrigStateBinding";
            this.textEdit_OrigStateBinding.Properties.AutoHeight = false;
            this.textEdit_OrigStateBinding.Size = new System.Drawing.Size(8, 8);
            this.textEdit_OrigStateBinding.TabIndex = 11;
            // 
            // groupControl_FastSerMorning
            // 
            this.groupControl_FastSerMorning.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_FastSerMorning.AppearanceCaption.Options.UseFont = true;
            this.groupControl_FastSerMorning.Controls.Add(this.groupControl_TimeStatusMorning);
            this.groupControl_FastSerMorning.Controls.Add(this.groupControl_NumberNameMorning);
            this.groupControl_FastSerMorning.Controls.Add(this.groupControl_GradeClassMorning);
            this.groupControl_FastSerMorning.Controls.Add(this.notePanel_GradeClassMorning);
            this.groupControl_FastSerMorning.Controls.Add(this.notePanel_TimeStatusMorning);
            this.groupControl_FastSerMorning.Controls.Add(this.notePanel_NumberNameMorning);
            this.groupControl_FastSerMorning.Controls.Add(this.notePanel1_SerCondMorning);
            this.groupControl_FastSerMorning.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl_FastSerMorning.Location = new System.Drawing.Point(0, 0);
            this.groupControl_FastSerMorning.Name = "groupControl_FastSerMorning";
            this.groupControl_FastSerMorning.Size = new System.Drawing.Size(239, 312);
            this.groupControl_FastSerMorning.TabIndex = 7;
            this.groupControl_FastSerMorning.Text = "快速搜索";
            // 
            // groupControl_TimeStatusMorning
            // 
            this.groupControl_TimeStatusMorning.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_TimeStatusMorning.AppearanceCaption.ForeColor = System.Drawing.Color.Black;
            this.groupControl_TimeStatusMorning.AppearanceCaption.Options.UseFont = true;
            this.groupControl_TimeStatusMorning.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl_TimeStatusMorning.Controls.Add(this.dateEdit_SpecificDateMorning);
            this.groupControl_TimeStatusMorning.Controls.Add(this.notePanel_SpecificDateMorning);
            this.groupControl_TimeStatusMorning.Controls.Add(this.textEdit_EndTimeMorning);
            this.groupControl_TimeStatusMorning.Controls.Add(this.textEdit_BegTimeMorning);
            this.groupControl_TimeStatusMorning.Controls.Add(this.comboBoxEdit_TimeModeMorning);
            this.groupControl_TimeStatusMorning.Controls.Add(this.notePanel_TimeModeMorning);
            this.groupControl_TimeStatusMorning.Controls.Add(this.comboBoxEdit_Status);
            this.groupControl_TimeStatusMorning.Controls.Add(this.notePanel_Status);
            this.groupControl_TimeStatusMorning.Controls.Add(this.notePanel_BegTimeMorning);
            this.groupControl_TimeStatusMorning.Controls.Add(this.notePanel_EndTimeMorning);
            this.groupControl_TimeStatusMorning.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl_TimeStatusMorning.Location = new System.Drawing.Point(2, -114);
            this.groupControl_TimeStatusMorning.Name = "groupControl_TimeStatusMorning";
            this.groupControl_TimeStatusMorning.Size = new System.Drawing.Size(235, 184);
            this.groupControl_TimeStatusMorning.TabIndex = 22;
            this.groupControl_TimeStatusMorning.Text = "指定搜索的时间和晨检状态";
            this.groupControl_TimeStatusMorning.Visible = false;
            // 
            // dateEdit_SpecificDateMorning
            // 
            this.dateEdit_SpecificDateMorning.EditValue = new System.DateTime(2005, 1, 31, 0, 0, 0, 0);
            this.dateEdit_SpecificDateMorning.Location = new System.Drawing.Point(104, 24);
            this.dateEdit_SpecificDateMorning.Name = "dateEdit_SpecificDateMorning";
            this.dateEdit_SpecificDateMorning.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_SpecificDateMorning.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit_SpecificDateMorning.Size = new System.Drawing.Size(112, 20);
            this.dateEdit_SpecificDateMorning.TabIndex = 24;
            // 
            // notePanel_SpecificDateMorning
            // 
            this.notePanel_SpecificDateMorning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_SpecificDateMorning.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_SpecificDateMorning.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_SpecificDateMorning.ForeColor = System.Drawing.Color.Black;
            this.notePanel_SpecificDateMorning.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_SpecificDateMorning.Location = new System.Drawing.Point(16, 24);
            this.notePanel_SpecificDateMorning.MaxRows = 5;
            this.notePanel_SpecificDateMorning.Name = "notePanel_SpecificDateMorning";
            this.notePanel_SpecificDateMorning.ParentAutoHeight = true;
            this.notePanel_SpecificDateMorning.Size = new System.Drawing.Size(80, 22);
            this.notePanel_SpecificDateMorning.TabIndex = 23;
            this.notePanel_SpecificDateMorning.TabStop = false;
            this.notePanel_SpecificDateMorning.Text = "指定日期:";
            // 
            // textEdit_EndTimeMorning
            // 
            this.textEdit_EndTimeMorning.EditValue = "";
            this.textEdit_EndTimeMorning.Location = new System.Drawing.Point(104, 88);
            this.textEdit_EndTimeMorning.Name = "textEdit_EndTimeMorning";
            this.textEdit_EndTimeMorning.Properties.DisplayFormat.FormatString = "d";
            this.textEdit_EndTimeMorning.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.textEdit_EndTimeMorning.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.textEdit_EndTimeMorning.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.textEdit_EndTimeMorning.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.textEdit_EndTimeMorning.Size = new System.Drawing.Size(112, 20);
            this.textEdit_EndTimeMorning.TabIndex = 22;
            // 
            // textEdit_BegTimeMorning
            // 
            this.textEdit_BegTimeMorning.EditValue = "";
            this.textEdit_BegTimeMorning.Location = new System.Drawing.Point(104, 56);
            this.textEdit_BegTimeMorning.Name = "textEdit_BegTimeMorning";
            this.textEdit_BegTimeMorning.Properties.DisplayFormat.FormatString = "d";
            this.textEdit_BegTimeMorning.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.textEdit_BegTimeMorning.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.textEdit_BegTimeMorning.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.textEdit_BegTimeMorning.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.textEdit_BegTimeMorning.Size = new System.Drawing.Size(112, 20);
            this.textEdit_BegTimeMorning.TabIndex = 21;
            // 
            // comboBoxEdit_TimeModeMorning
            // 
            this.comboBoxEdit_TimeModeMorning.EditValue = "模糊时间";
            this.comboBoxEdit_TimeModeMorning.Location = new System.Drawing.Point(104, 120);
            this.comboBoxEdit_TimeModeMorning.Name = "comboBoxEdit_TimeModeMorning";
            this.comboBoxEdit_TimeModeMorning.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_TimeModeMorning.Properties.Items.AddRange(new object[] {
            "模糊时间",
            "精确时间"});
            this.comboBoxEdit_TimeModeMorning.Size = new System.Drawing.Size(112, 20);
            this.comboBoxEdit_TimeModeMorning.TabIndex = 20;
            this.comboBoxEdit_TimeModeMorning.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_TimeModeMorning_SelectedIndexChanged);
            // 
            // notePanel_TimeModeMorning
            // 
            this.notePanel_TimeModeMorning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_TimeModeMorning.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_TimeModeMorning.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_TimeModeMorning.ForeColor = System.Drawing.Color.Black;
            this.notePanel_TimeModeMorning.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_TimeModeMorning.Location = new System.Drawing.Point(16, 120);
            this.notePanel_TimeModeMorning.MaxRows = 5;
            this.notePanel_TimeModeMorning.Name = "notePanel_TimeModeMorning";
            this.notePanel_TimeModeMorning.ParentAutoHeight = true;
            this.notePanel_TimeModeMorning.Size = new System.Drawing.Size(80, 22);
            this.notePanel_TimeModeMorning.TabIndex = 19;
            this.notePanel_TimeModeMorning.TabStop = false;
            this.notePanel_TimeModeMorning.Text = "时间模式:";
            // 
            // comboBoxEdit_Status
            // 
            this.comboBoxEdit_Status.EditValue = "全部";
            this.comboBoxEdit_Status.Location = new System.Drawing.Point(104, 152);
            this.comboBoxEdit_Status.Name = "comboBoxEdit_Status";
            this.comboBoxEdit_Status.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_Status.Properties.Items.AddRange(new object[] {
            "全部"});
            this.comboBoxEdit_Status.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_Status.Size = new System.Drawing.Size(112, 20);
            this.comboBoxEdit_Status.TabIndex = 18;
            this.comboBoxEdit_Status.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_Status_SelectedIndexChanged);
            // 
            // notePanel_Status
            // 
            this.notePanel_Status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Status.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Status.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Status.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Status.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Status.Location = new System.Drawing.Point(16, 152);
            this.notePanel_Status.MaxRows = 5;
            this.notePanel_Status.Name = "notePanel_Status";
            this.notePanel_Status.ParentAutoHeight = true;
            this.notePanel_Status.Size = new System.Drawing.Size(80, 22);
            this.notePanel_Status.TabIndex = 17;
            this.notePanel_Status.TabStop = false;
            this.notePanel_Status.Text = "晨检状态:";
            // 
            // notePanel_BegTimeMorning
            // 
            this.notePanel_BegTimeMorning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_BegTimeMorning.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_BegTimeMorning.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_BegTimeMorning.ForeColor = System.Drawing.Color.Black;
            this.notePanel_BegTimeMorning.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_BegTimeMorning.Location = new System.Drawing.Point(16, 56);
            this.notePanel_BegTimeMorning.MaxRows = 5;
            this.notePanel_BegTimeMorning.Name = "notePanel_BegTimeMorning";
            this.notePanel_BegTimeMorning.ParentAutoHeight = true;
            this.notePanel_BegTimeMorning.Size = new System.Drawing.Size(80, 22);
            this.notePanel_BegTimeMorning.TabIndex = 14;
            this.notePanel_BegTimeMorning.TabStop = false;
            this.notePanel_BegTimeMorning.Text = "起始时间:";
            // 
            // notePanel_EndTimeMorning
            // 
            this.notePanel_EndTimeMorning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_EndTimeMorning.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_EndTimeMorning.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_EndTimeMorning.ForeColor = System.Drawing.Color.Black;
            this.notePanel_EndTimeMorning.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_EndTimeMorning.Location = new System.Drawing.Point(16, 88);
            this.notePanel_EndTimeMorning.MaxRows = 5;
            this.notePanel_EndTimeMorning.Name = "notePanel_EndTimeMorning";
            this.notePanel_EndTimeMorning.ParentAutoHeight = true;
            this.notePanel_EndTimeMorning.Size = new System.Drawing.Size(80, 22);
            this.notePanel_EndTimeMorning.TabIndex = 13;
            this.notePanel_EndTimeMorning.TabStop = false;
            this.notePanel_EndTimeMorning.Text = "结束时间:";
            // 
            // groupControl_NumberNameMorning
            // 
            this.groupControl_NumberNameMorning.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_NumberNameMorning.AppearanceCaption.ForeColor = System.Drawing.Color.Black;
            this.groupControl_NumberNameMorning.AppearanceCaption.Options.UseFont = true;
            this.groupControl_NumberNameMorning.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl_NumberNameMorning.Controls.Add(this.textEdit_NumberMorning);
            this.groupControl_NumberNameMorning.Controls.Add(this.textEdit_NameMorning);
            this.groupControl_NumberNameMorning.Controls.Add(this.notePanel_NumberMorning);
            this.groupControl_NumberNameMorning.Controls.Add(this.notePanel_NameMorning);
            this.groupControl_NumberNameMorning.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl_NumberNameMorning.Location = new System.Drawing.Point(2, 70);
            this.groupControl_NumberNameMorning.Name = "groupControl_NumberNameMorning";
            this.groupControl_NumberNameMorning.Size = new System.Drawing.Size(235, 120);
            this.groupControl_NumberNameMorning.TabIndex = 21;
            this.groupControl_NumberNameMorning.Text = "指定搜索的学号和姓名";
            this.groupControl_NumberNameMorning.Visible = false;
            // 
            // textEdit_NumberMorning
            // 
            this.textEdit_NumberMorning.EditValue = "";
            this.textEdit_NumberMorning.Location = new System.Drawing.Point(104, 72);
            this.textEdit_NumberMorning.Name = "textEdit_NumberMorning";
            this.textEdit_NumberMorning.Size = new System.Drawing.Size(112, 20);
            this.textEdit_NumberMorning.TabIndex = 14;
            // 
            // textEdit_NameMorning
            // 
            this.textEdit_NameMorning.EditValue = "";
            this.textEdit_NameMorning.Location = new System.Drawing.Point(104, 32);
            this.textEdit_NameMorning.Name = "textEdit_NameMorning";
            this.textEdit_NameMorning.Size = new System.Drawing.Size(112, 20);
            this.textEdit_NameMorning.TabIndex = 13;
            // 
            // notePanel_NumberMorning
            // 
            this.notePanel_NumberMorning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_NumberMorning.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_NumberMorning.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_NumberMorning.ForeColor = System.Drawing.Color.Black;
            this.notePanel_NumberMorning.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_NumberMorning.Location = new System.Drawing.Point(16, 72);
            this.notePanel_NumberMorning.MaxRows = 5;
            this.notePanel_NumberMorning.Name = "notePanel_NumberMorning";
            this.notePanel_NumberMorning.ParentAutoHeight = true;
            this.notePanel_NumberMorning.Size = new System.Drawing.Size(80, 22);
            this.notePanel_NumberMorning.TabIndex = 10;
            this.notePanel_NumberMorning.TabStop = false;
            this.notePanel_NumberMorning.Text = "  学  号:";
            // 
            // notePanel_NameMorning
            // 
            this.notePanel_NameMorning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_NameMorning.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_NameMorning.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_NameMorning.ForeColor = System.Drawing.Color.Black;
            this.notePanel_NameMorning.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_NameMorning.Location = new System.Drawing.Point(16, 32);
            this.notePanel_NameMorning.MaxRows = 5;
            this.notePanel_NameMorning.Name = "notePanel_NameMorning";
            this.notePanel_NameMorning.ParentAutoHeight = true;
            this.notePanel_NameMorning.Size = new System.Drawing.Size(80, 22);
            this.notePanel_NameMorning.TabIndex = 9;
            this.notePanel_NameMorning.TabStop = false;
            this.notePanel_NameMorning.Text = "  姓  名:";
            // 
            // groupControl_GradeClassMorning
            // 
            this.groupControl_GradeClassMorning.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_GradeClassMorning.AppearanceCaption.Options.UseFont = true;
            this.groupControl_GradeClassMorning.Controls.Add(this.comboBoxEdit_ClassMorning);
            this.groupControl_GradeClassMorning.Controls.Add(this.comboBoxEdit_GradeMorning);
            this.groupControl_GradeClassMorning.Controls.Add(this.notePanel1_GradeMorning);
            this.groupControl_GradeClassMorning.Controls.Add(this.notePanel1_ClassMorning);
            this.groupControl_GradeClassMorning.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl_GradeClassMorning.Location = new System.Drawing.Point(2, 190);
            this.groupControl_GradeClassMorning.Name = "groupControl_GradeClassMorning";
            this.groupControl_GradeClassMorning.Size = new System.Drawing.Size(235, 120);
            this.groupControl_GradeClassMorning.TabIndex = 20;
            this.groupControl_GradeClassMorning.Text = "指定搜索的年级和班级";
            this.groupControl_GradeClassMorning.Visible = false;
            // 
            // comboBoxEdit_ClassMorning
            // 
            this.comboBoxEdit_ClassMorning.EditValue = "全部";
            this.comboBoxEdit_ClassMorning.Location = new System.Drawing.Point(104, 72);
            this.comboBoxEdit_ClassMorning.Name = "comboBoxEdit_ClassMorning";
            this.comboBoxEdit_ClassMorning.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_ClassMorning.Properties.Items.AddRange(new object[] {
            "全部"});
            this.comboBoxEdit_ClassMorning.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_ClassMorning.Size = new System.Drawing.Size(112, 20);
            this.comboBoxEdit_ClassMorning.TabIndex = 18;
            this.comboBoxEdit_ClassMorning.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_ClassMorning_SelectedIndexChanged);
            // 
            // comboBoxEdit_GradeMorning
            // 
            this.comboBoxEdit_GradeMorning.EditValue = "全部";
            this.comboBoxEdit_GradeMorning.Location = new System.Drawing.Point(104, 32);
            this.comboBoxEdit_GradeMorning.Name = "comboBoxEdit_GradeMorning";
            this.comboBoxEdit_GradeMorning.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_GradeMorning.Properties.Items.AddRange(new object[] {
            "全部"});
            this.comboBoxEdit_GradeMorning.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_GradeMorning.Size = new System.Drawing.Size(112, 20);
            this.comboBoxEdit_GradeMorning.TabIndex = 17;
            this.comboBoxEdit_GradeMorning.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_GradeMorning_SelectedIndexChanged);
            // 
            // notePanel1_GradeMorning
            // 
            this.notePanel1_GradeMorning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel1_GradeMorning.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel1_GradeMorning.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel1_GradeMorning.ForeColor = System.Drawing.Color.Black;
            this.notePanel1_GradeMorning.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel1_GradeMorning.Location = new System.Drawing.Point(16, 32);
            this.notePanel1_GradeMorning.MaxRows = 5;
            this.notePanel1_GradeMorning.Name = "notePanel1_GradeMorning";
            this.notePanel1_GradeMorning.ParentAutoHeight = true;
            this.notePanel1_GradeMorning.Size = new System.Drawing.Size(80, 22);
            this.notePanel1_GradeMorning.TabIndex = 4;
            this.notePanel1_GradeMorning.TabStop = false;
            this.notePanel1_GradeMorning.Text = "  年  级:";
            // 
            // notePanel1_ClassMorning
            // 
            this.notePanel1_ClassMorning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel1_ClassMorning.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel1_ClassMorning.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel1_ClassMorning.ForeColor = System.Drawing.Color.Black;
            this.notePanel1_ClassMorning.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel1_ClassMorning.Location = new System.Drawing.Point(16, 72);
            this.notePanel1_ClassMorning.MaxRows = 5;
            this.notePanel1_ClassMorning.Name = "notePanel1_ClassMorning";
            this.notePanel1_ClassMorning.ParentAutoHeight = true;
            this.notePanel1_ClassMorning.Size = new System.Drawing.Size(80, 22);
            this.notePanel1_ClassMorning.TabIndex = 16;
            this.notePanel1_ClassMorning.TabStop = false;
            this.notePanel1_ClassMorning.Text = "  班  级:";
            // 
            // notePanel_GradeClassMorning
            // 
            this.notePanel_GradeClassMorning.BackColor = System.Drawing.Color.LawnGreen;
            this.notePanel_GradeClassMorning.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_GradeClassMorning.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_GradeClassMorning.ForeColor = System.Drawing.Color.Black;
            this.notePanel_GradeClassMorning.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_GradeClassMorning.Location = new System.Drawing.Point(16, 48);
            this.notePanel_GradeClassMorning.MaxRows = 5;
            this.notePanel_GradeClassMorning.Name = "notePanel_GradeClassMorning";
            this.notePanel_GradeClassMorning.ParentAutoHeight = true;
            this.notePanel_GradeClassMorning.Size = new System.Drawing.Size(200, 22);
            this.notePanel_GradeClassMorning.TabIndex = 19;
            this.notePanel_GradeClassMorning.TabStop = false;
            this.notePanel_GradeClassMorning.Text = "年级和班级:";
            this.notePanel_GradeClassMorning.Click += new System.EventHandler(this.notePanel_GradeClass_Click_1);
            // 
            // notePanel_TimeStatusMorning
            // 
            this.notePanel_TimeStatusMorning.BackColor = System.Drawing.Color.LawnGreen;
            this.notePanel_TimeStatusMorning.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_TimeStatusMorning.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_TimeStatusMorning.ForeColor = System.Drawing.Color.Black;
            this.notePanel_TimeStatusMorning.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_TimeStatusMorning.Location = new System.Drawing.Point(16, 98);
            this.notePanel_TimeStatusMorning.MaxRows = 5;
            this.notePanel_TimeStatusMorning.Name = "notePanel_TimeStatusMorning";
            this.notePanel_TimeStatusMorning.ParentAutoHeight = true;
            this.notePanel_TimeStatusMorning.Size = new System.Drawing.Size(200, 22);
            this.notePanel_TimeStatusMorning.TabIndex = 18;
            this.notePanel_TimeStatusMorning.TabStop = false;
            this.notePanel_TimeStatusMorning.Text = "时间和状态:";
            this.notePanel_TimeStatusMorning.Click += new System.EventHandler(this.notePanel_TimeStatus_Click_1);
            // 
            // notePanel_NumberNameMorning
            // 
            this.notePanel_NumberNameMorning.BackColor = System.Drawing.Color.LawnGreen;
            this.notePanel_NumberNameMorning.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_NumberNameMorning.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_NumberNameMorning.ForeColor = System.Drawing.Color.Black;
            this.notePanel_NumberNameMorning.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_NumberNameMorning.Location = new System.Drawing.Point(16, 74);
            this.notePanel_NumberNameMorning.MaxRows = 5;
            this.notePanel_NumberNameMorning.Name = "notePanel_NumberNameMorning";
            this.notePanel_NumberNameMorning.ParentAutoHeight = true;
            this.notePanel_NumberNameMorning.Size = new System.Drawing.Size(200, 22);
            this.notePanel_NumberNameMorning.TabIndex = 17;
            this.notePanel_NumberNameMorning.TabStop = false;
            this.notePanel_NumberNameMorning.Text = "学号和姓名:";
            this.notePanel_NumberNameMorning.Click += new System.EventHandler(this.notePanel_NumberName_Click_1);
            // 
            // notePanel1_SerCondMorning
            // 
            this.notePanel1_SerCondMorning.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.notePanel1_SerCondMorning.Dock = System.Windows.Forms.DockStyle.Top;
            this.notePanel1_SerCondMorning.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notePanel1_SerCondMorning.ForeColor = System.Drawing.Color.OrangeRed;
            this.notePanel1_SerCondMorning.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel1_SerCondMorning.Location = new System.Drawing.Point(2, 22);
            this.notePanel1_SerCondMorning.MaxRows = 5;
            this.notePanel1_SerCondMorning.Name = "notePanel1_SerCondMorning";
            this.notePanel1_SerCondMorning.ParentAutoHeight = true;
            this.notePanel1_SerCondMorning.Size = new System.Drawing.Size(235, 23);
            this.notePanel1_SerCondMorning.TabIndex = 5;
            this.notePanel1_SerCondMorning.TabStop = false;
            this.notePanel1_SerCondMorning.Text = "您要搜索的条件？";
            // 
            // gridControl_MorningInfo
            // 
            this.gridControl_MorningInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_MorningInfo.Location = new System.Drawing.Point(0, 40);
            this.gridControl_MorningInfo.MainView = this.gridView1;
            this.gridControl_MorningInfo.Name = "gridControl_MorningInfo";
            this.gridControl_MorningInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox_Status});
            this.gridControl_MorningInfo.Size = new System.Drawing.Size(522, 471);
            this.gridControl_MorningInfo.TabIndex = 7;
            this.gridControl_MorningInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
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
            this.gridColumn6});
            this.gridView1.GridControl = this.gridControl_MorningInfo;
            this.gridView1.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "晨检序号";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn1.FieldName = "info_stuOrderNumber";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn1.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn1.OptionsFilter.AllowFilter = false;
            this.gridColumn1.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn1.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 76;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "幼儿班级";
            this.gridColumn2.FieldName = "info_className";
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
            this.gridColumn2.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn2.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 65;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "幼儿学号";
            this.gridColumn3.FieldName = "info_stuNumber";
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
            this.gridColumn3.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn3.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 65;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "幼儿姓名";
            this.gridColumn4.FieldName = "info_stuName";
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
            this.gridColumn4.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn4.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 66;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "入园时间";
            this.gridColumn5.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn5.FieldName = "flow_stuFlowEnterDate";
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
            this.gridColumn5.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn5.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 162;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "入园状态";
            this.gridColumn6.ColumnEdit = this.repositoryItemComboBox_Status;
            this.gridColumn6.FieldName = "state_flowStateName";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn6.OptionsColumn.FixedWidth = true;
            this.gridColumn6.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn6.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn6.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // repositoryItemComboBox_Status
            // 
            this.repositoryItemComboBox_Status.AutoHeight = false;
            this.repositoryItemComboBox_Status.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox_Status.Items.AddRange(new object[] {
            "健康",
            "服药",
            "观察",
            "缺席"});
            this.repositoryItemComboBox_Status.Name = "repositoryItemComboBox_Status";
            this.repositoryItemComboBox_Status.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton_PrintMorning);
            this.panelControl1.Controls.Add(this.simpleButton_SearchMorning);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(522, 40);
            this.panelControl1.TabIndex = 6;
            // 
            // simpleButton_PrintMorning
            // 
            this.simpleButton_PrintMorning.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_PrintMorning.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
            this.simpleButton_PrintMorning.Appearance.Options.UseFont = true;
            this.simpleButton_PrintMorning.Appearance.Options.UseForeColor = true;
            this.simpleButton_PrintMorning.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_PrintMorning.Image")));
            this.simpleButton_PrintMorning.Location = new System.Drawing.Point(120, 8);
            this.simpleButton_PrintMorning.Name = "simpleButton_PrintMorning";
            this.simpleButton_PrintMorning.Size = new System.Drawing.Size(92, 26);
            this.simpleButton_PrintMorning.TabIndex = 5;
            this.simpleButton_PrintMorning.Tag = 4;
            this.simpleButton_PrintMorning.Text = "报  表";
            this.simpleButton_PrintMorning.Click += new System.EventHandler(this.simpleButton_PrintMorning_Click);
            // 
            // simpleButton_SearchMorning
            // 
            this.simpleButton_SearchMorning.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_SearchMorning.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
            this.simpleButton_SearchMorning.Appearance.Options.UseFont = true;
            this.simpleButton_SearchMorning.Appearance.Options.UseForeColor = true;
            this.simpleButton_SearchMorning.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_SearchMorning.Image")));
            this.simpleButton_SearchMorning.Location = new System.Drawing.Point(16, 8);
            this.simpleButton_SearchMorning.Name = "simpleButton_SearchMorning";
            this.simpleButton_SearchMorning.Size = new System.Drawing.Size(92, 26);
            this.simpleButton_SearchMorning.TabIndex = 2;
            this.simpleButton_SearchMorning.Tag = 4;
            this.simpleButton_SearchMorning.Text = "搜  索";
            this.simpleButton_SearchMorning.Click += new System.EventHandler(this.simpleButton_SearchMorning_Click);
            // 
            // xtraTabPage_BackHomeCheck
            // 
            this.xtraTabPage_BackHomeCheck.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xtraTabPage_BackHomeCheck.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabPage_BackHomeCheck.Controls.Add(this.splitContainerControl2);
            this.xtraTabPage_BackHomeCheck.Name = "xtraTabPage_BackHomeCheck";
            this.xtraTabPage_BackHomeCheck.Size = new System.Drawing.Size(766, 511);
            this.xtraTabPage_BackHomeCheck.Text = "幼儿晚接信息查询";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl2.Panel1.Controls.Add(this.groupControl_FastSerBack);
            this.splitContainerControl2.Panel1.Text = "splitContainerControl2_Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.gridControl_BackInfo);
            this.splitContainerControl2.Panel2.Controls.Add(this.panelControl2);
            this.splitContainerControl2.Panel2.Text = "splitContainerControl2_Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(766, 511);
            this.splitContainerControl2.SplitterPosition = 238;
            this.splitContainerControl2.TabIndex = 0;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.textEdit_ShouldGo);
            this.groupControl1.Controls.Add(this.notePanel_ShouldGo);
            this.groupControl1.Controls.Add(this.textEdit_HasnotGone);
            this.groupControl1.Controls.Add(this.notePanel_HasnotGone);
            this.groupControl1.Controls.Add(this.textEdit_HasGone);
            this.groupControl1.Controls.Add(this.notePanel_HasGone);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 320);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(238, 136);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Text = "晚接信息统计";
            // 
            // textEdit_ShouldGo
            // 
            this.textEdit_ShouldGo.EditValue = "";
            this.textEdit_ShouldGo.Location = new System.Drawing.Point(104, 96);
            this.textEdit_ShouldGo.Name = "textEdit_ShouldGo";
            this.textEdit_ShouldGo.Properties.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.textEdit_ShouldGo.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit_ShouldGo.Size = new System.Drawing.Size(120, 20);
            this.textEdit_ShouldGo.TabIndex = 10;
            // 
            // notePanel_ShouldGo
            // 
            this.notePanel_ShouldGo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_ShouldGo.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_ShouldGo.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_ShouldGo.ForeColor = System.Drawing.Color.Black;
            this.notePanel_ShouldGo.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_ShouldGo.Location = new System.Drawing.Point(16, 96);
            this.notePanel_ShouldGo.MaxRows = 5;
            this.notePanel_ShouldGo.Name = "notePanel_ShouldGo";
            this.notePanel_ShouldGo.ParentAutoHeight = true;
            this.notePanel_ShouldGo.Size = new System.Drawing.Size(80, 22);
            this.notePanel_ShouldGo.TabIndex = 9;
            this.notePanel_ShouldGo.TabStop = false;
            this.notePanel_ShouldGo.Text = " 应接走:";
            // 
            // textEdit_HasnotGone
            // 
            this.textEdit_HasnotGone.EditValue = "";
            this.textEdit_HasnotGone.Location = new System.Drawing.Point(104, 64);
            this.textEdit_HasnotGone.Name = "textEdit_HasnotGone";
            this.textEdit_HasnotGone.Properties.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.textEdit_HasnotGone.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit_HasnotGone.Size = new System.Drawing.Size(120, 20);
            this.textEdit_HasnotGone.TabIndex = 8;
            // 
            // notePanel_HasnotGone
            // 
            this.notePanel_HasnotGone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_HasnotGone.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_HasnotGone.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_HasnotGone.ForeColor = System.Drawing.Color.Black;
            this.notePanel_HasnotGone.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_HasnotGone.Location = new System.Drawing.Point(16, 64);
            this.notePanel_HasnotGone.MaxRows = 5;
            this.notePanel_HasnotGone.Name = "notePanel_HasnotGone";
            this.notePanel_HasnotGone.ParentAutoHeight = true;
            this.notePanel_HasnotGone.Size = new System.Drawing.Size(80, 22);
            this.notePanel_HasnotGone.TabIndex = 7;
            this.notePanel_HasnotGone.TabStop = false;
            this.notePanel_HasnotGone.Text = " 未接走:";
            // 
            // textEdit_HasGone
            // 
            this.textEdit_HasGone.EditValue = "";
            this.textEdit_HasGone.Location = new System.Drawing.Point(104, 32);
            this.textEdit_HasGone.Name = "textEdit_HasGone";
            this.textEdit_HasGone.Properties.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.textEdit_HasGone.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit_HasGone.Size = new System.Drawing.Size(120, 20);
            this.textEdit_HasGone.TabIndex = 6;
            // 
            // notePanel_HasGone
            // 
            this.notePanel_HasGone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_HasGone.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_HasGone.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_HasGone.ForeColor = System.Drawing.Color.Black;
            this.notePanel_HasGone.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_HasGone.Location = new System.Drawing.Point(16, 32);
            this.notePanel_HasGone.MaxRows = 5;
            this.notePanel_HasGone.Name = "notePanel_HasGone";
            this.notePanel_HasGone.ParentAutoHeight = true;
            this.notePanel_HasGone.Size = new System.Drawing.Size(80, 22);
            this.notePanel_HasGone.TabIndex = 5;
            this.notePanel_HasGone.TabStop = false;
            this.notePanel_HasGone.Text = " 已接走:";
            // 
            // groupControl_FastSerBack
            // 
            this.groupControl_FastSerBack.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_FastSerBack.AppearanceCaption.Options.UseFont = true;
            this.groupControl_FastSerBack.Controls.Add(this.groupControl_TimeCondBack);
            this.groupControl_FastSerBack.Controls.Add(this.groupControl_NumberNameBack);
            this.groupControl_FastSerBack.Controls.Add(this.groupControl_GradeClassBack);
            this.groupControl_FastSerBack.Controls.Add(this.notePanel_GradeClassBack);
            this.groupControl_FastSerBack.Controls.Add(this.notePanel_TimeConBack);
            this.groupControl_FastSerBack.Controls.Add(this.notePanel_NumberNameBack);
            this.groupControl_FastSerBack.Controls.Add(this.notePanel_SerCondBack);
            this.groupControl_FastSerBack.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl_FastSerBack.Location = new System.Drawing.Point(0, 0);
            this.groupControl_FastSerBack.Name = "groupControl_FastSerBack";
            this.groupControl_FastSerBack.Size = new System.Drawing.Size(238, 320);
            this.groupControl_FastSerBack.TabIndex = 8;
            this.groupControl_FastSerBack.Text = "快速搜索";
            // 
            // groupControl_TimeCondBack
            // 
            this.groupControl_TimeCondBack.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_TimeCondBack.AppearanceCaption.ForeColor = System.Drawing.Color.Black;
            this.groupControl_TimeCondBack.AppearanceCaption.Options.UseFont = true;
            this.groupControl_TimeCondBack.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl_TimeCondBack.Controls.Add(this.dateEdit_SpecificDateBack);
            this.groupControl_TimeCondBack.Controls.Add(this.notePanel_SpecificDateBack);
            this.groupControl_TimeCondBack.Controls.Add(this.comboBoxEdit_TimeModeBack);
            this.groupControl_TimeCondBack.Controls.Add(this.notePanel_TimeModeBack);
            this.groupControl_TimeCondBack.Controls.Add(this.textEdit_EndTimeBack);
            this.groupControl_TimeCondBack.Controls.Add(this.textEdit_BegTimeBack);
            this.groupControl_TimeCondBack.Controls.Add(this.comboBoxEdit_BackCond);
            this.groupControl_TimeCondBack.Controls.Add(this.notePanel_BackCond);
            this.groupControl_TimeCondBack.Controls.Add(this.notePanel_BegTimeBack);
            this.groupControl_TimeCondBack.Controls.Add(this.notePanel_EndTimeBack);
            this.groupControl_TimeCondBack.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl_TimeCondBack.Location = new System.Drawing.Point(2, -106);
            this.groupControl_TimeCondBack.Name = "groupControl_TimeCondBack";
            this.groupControl_TimeCondBack.Size = new System.Drawing.Size(234, 184);
            this.groupControl_TimeCondBack.TabIndex = 22;
            this.groupControl_TimeCondBack.Text = "指定搜索的时间和晚接情况";
            this.groupControl_TimeCondBack.Visible = false;
            // 
            // dateEdit_SpecificDateBack
            // 
            this.dateEdit_SpecificDateBack.EditValue = new System.DateTime(2005, 1, 31, 0, 0, 0, 0);
            this.dateEdit_SpecificDateBack.Location = new System.Drawing.Point(104, 24);
            this.dateEdit_SpecificDateBack.Name = "dateEdit_SpecificDateBack";
            this.dateEdit_SpecificDateBack.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_SpecificDateBack.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit_SpecificDateBack.Size = new System.Drawing.Size(112, 20);
            this.dateEdit_SpecificDateBack.TabIndex = 24;
            // 
            // notePanel_SpecificDateBack
            // 
            this.notePanel_SpecificDateBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_SpecificDateBack.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_SpecificDateBack.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_SpecificDateBack.ForeColor = System.Drawing.Color.Black;
            this.notePanel_SpecificDateBack.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_SpecificDateBack.Location = new System.Drawing.Point(16, 24);
            this.notePanel_SpecificDateBack.MaxRows = 5;
            this.notePanel_SpecificDateBack.Name = "notePanel_SpecificDateBack";
            this.notePanel_SpecificDateBack.ParentAutoHeight = true;
            this.notePanel_SpecificDateBack.Size = new System.Drawing.Size(80, 22);
            this.notePanel_SpecificDateBack.TabIndex = 23;
            this.notePanel_SpecificDateBack.TabStop = false;
            this.notePanel_SpecificDateBack.Text = "指定日期:";
            // 
            // comboBoxEdit_TimeModeBack
            // 
            this.comboBoxEdit_TimeModeBack.EditValue = "模糊时间";
            this.comboBoxEdit_TimeModeBack.Location = new System.Drawing.Point(104, 120);
            this.comboBoxEdit_TimeModeBack.Name = "comboBoxEdit_TimeModeBack";
            this.comboBoxEdit_TimeModeBack.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_TimeModeBack.Properties.Items.AddRange(new object[] {
            "模糊时间",
            "精确时间"});
            this.comboBoxEdit_TimeModeBack.Size = new System.Drawing.Size(112, 20);
            this.comboBoxEdit_TimeModeBack.TabIndex = 22;
            this.comboBoxEdit_TimeModeBack.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_TimeModeBack_SelectedIndexChanged);
            // 
            // notePanel_TimeModeBack
            // 
            this.notePanel_TimeModeBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_TimeModeBack.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_TimeModeBack.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_TimeModeBack.ForeColor = System.Drawing.Color.Black;
            this.notePanel_TimeModeBack.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_TimeModeBack.Location = new System.Drawing.Point(16, 120);
            this.notePanel_TimeModeBack.MaxRows = 5;
            this.notePanel_TimeModeBack.Name = "notePanel_TimeModeBack";
            this.notePanel_TimeModeBack.ParentAutoHeight = true;
            this.notePanel_TimeModeBack.Size = new System.Drawing.Size(80, 22);
            this.notePanel_TimeModeBack.TabIndex = 21;
            this.notePanel_TimeModeBack.TabStop = false;
            this.notePanel_TimeModeBack.Text = "时间模式";
            // 
            // textEdit_EndTimeBack
            // 
            this.textEdit_EndTimeBack.EditValue = "";
            this.textEdit_EndTimeBack.Location = new System.Drawing.Point(104, 88);
            this.textEdit_EndTimeBack.Name = "textEdit_EndTimeBack";
            this.textEdit_EndTimeBack.Properties.DisplayFormat.FormatString = "d";
            this.textEdit_EndTimeBack.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.textEdit_EndTimeBack.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.textEdit_EndTimeBack.Properties.Mask.EditMask = "d";
            this.textEdit_EndTimeBack.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.textEdit_EndTimeBack.Size = new System.Drawing.Size(112, 20);
            this.textEdit_EndTimeBack.TabIndex = 20;
            // 
            // textEdit_BegTimeBack
            // 
            this.textEdit_BegTimeBack.EditValue = "";
            this.textEdit_BegTimeBack.Location = new System.Drawing.Point(104, 56);
            this.textEdit_BegTimeBack.Name = "textEdit_BegTimeBack";
            this.textEdit_BegTimeBack.Properties.DisplayFormat.FormatString = "d";
            this.textEdit_BegTimeBack.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.textEdit_BegTimeBack.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.textEdit_BegTimeBack.Properties.Mask.EditMask = "d";
            this.textEdit_BegTimeBack.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.textEdit_BegTimeBack.Size = new System.Drawing.Size(112, 20);
            this.textEdit_BegTimeBack.TabIndex = 19;
            // 
            // comboBoxEdit_BackCond
            // 
            this.comboBoxEdit_BackCond.EditValue = "已接走";
            this.comboBoxEdit_BackCond.Location = new System.Drawing.Point(104, 152);
            this.comboBoxEdit_BackCond.Name = "comboBoxEdit_BackCond";
            this.comboBoxEdit_BackCond.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_BackCond.Properties.Items.AddRange(new object[] {
            "已接走",
            "未接走"});
            this.comboBoxEdit_BackCond.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_BackCond.Size = new System.Drawing.Size(112, 20);
            this.comboBoxEdit_BackCond.TabIndex = 18;
            this.comboBoxEdit_BackCond.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_BackCond_SelectedIndexChanged);
            // 
            // notePanel_BackCond
            // 
            this.notePanel_BackCond.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_BackCond.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_BackCond.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_BackCond.ForeColor = System.Drawing.Color.Black;
            this.notePanel_BackCond.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_BackCond.Location = new System.Drawing.Point(16, 152);
            this.notePanel_BackCond.MaxRows = 5;
            this.notePanel_BackCond.Name = "notePanel_BackCond";
            this.notePanel_BackCond.ParentAutoHeight = true;
            this.notePanel_BackCond.Size = new System.Drawing.Size(80, 22);
            this.notePanel_BackCond.TabIndex = 17;
            this.notePanel_BackCond.TabStop = false;
            this.notePanel_BackCond.Text = "晚接情况:";
            // 
            // notePanel_BegTimeBack
            // 
            this.notePanel_BegTimeBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_BegTimeBack.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_BegTimeBack.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_BegTimeBack.ForeColor = System.Drawing.Color.Black;
            this.notePanel_BegTimeBack.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_BegTimeBack.Location = new System.Drawing.Point(16, 56);
            this.notePanel_BegTimeBack.MaxRows = 5;
            this.notePanel_BegTimeBack.Name = "notePanel_BegTimeBack";
            this.notePanel_BegTimeBack.ParentAutoHeight = true;
            this.notePanel_BegTimeBack.Size = new System.Drawing.Size(80, 22);
            this.notePanel_BegTimeBack.TabIndex = 14;
            this.notePanel_BegTimeBack.TabStop = false;
            this.notePanel_BegTimeBack.Text = "起始时间";
            // 
            // notePanel_EndTimeBack
            // 
            this.notePanel_EndTimeBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_EndTimeBack.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_EndTimeBack.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_EndTimeBack.ForeColor = System.Drawing.Color.Black;
            this.notePanel_EndTimeBack.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_EndTimeBack.Location = new System.Drawing.Point(16, 88);
            this.notePanel_EndTimeBack.MaxRows = 5;
            this.notePanel_EndTimeBack.Name = "notePanel_EndTimeBack";
            this.notePanel_EndTimeBack.ParentAutoHeight = true;
            this.notePanel_EndTimeBack.Size = new System.Drawing.Size(80, 22);
            this.notePanel_EndTimeBack.TabIndex = 13;
            this.notePanel_EndTimeBack.TabStop = false;
            this.notePanel_EndTimeBack.Text = "结束时间";
            // 
            // groupControl_NumberNameBack
            // 
            this.groupControl_NumberNameBack.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_NumberNameBack.AppearanceCaption.ForeColor = System.Drawing.Color.Black;
            this.groupControl_NumberNameBack.AppearanceCaption.Options.UseFont = true;
            this.groupControl_NumberNameBack.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl_NumberNameBack.Controls.Add(this.textEdit_NameBack);
            this.groupControl_NumberNameBack.Controls.Add(this.textEdit_NumberBack);
            this.groupControl_NumberNameBack.Controls.Add(this.notePanel_NumberBack);
            this.groupControl_NumberNameBack.Controls.Add(this.notePanel1_NameBack);
            this.groupControl_NumberNameBack.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl_NumberNameBack.Location = new System.Drawing.Point(2, 78);
            this.groupControl_NumberNameBack.Name = "groupControl_NumberNameBack";
            this.groupControl_NumberNameBack.Size = new System.Drawing.Size(234, 120);
            this.groupControl_NumberNameBack.TabIndex = 21;
            this.groupControl_NumberNameBack.Text = "指定搜索的学号和姓名";
            this.groupControl_NumberNameBack.Visible = false;
            // 
            // textEdit_NameBack
            // 
            this.textEdit_NameBack.EditValue = "";
            this.textEdit_NameBack.Location = new System.Drawing.Point(104, 32);
            this.textEdit_NameBack.Name = "textEdit_NameBack";
            this.textEdit_NameBack.Size = new System.Drawing.Size(112, 20);
            this.textEdit_NameBack.TabIndex = 12;
            // 
            // textEdit_NumberBack
            // 
            this.textEdit_NumberBack.EditValue = "";
            this.textEdit_NumberBack.Location = new System.Drawing.Point(104, 72);
            this.textEdit_NumberBack.Name = "textEdit_NumberBack";
            this.textEdit_NumberBack.Size = new System.Drawing.Size(112, 20);
            this.textEdit_NumberBack.TabIndex = 11;
            // 
            // notePanel_NumberBack
            // 
            this.notePanel_NumberBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_NumberBack.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_NumberBack.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_NumberBack.ForeColor = System.Drawing.Color.Black;
            this.notePanel_NumberBack.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_NumberBack.Location = new System.Drawing.Point(16, 72);
            this.notePanel_NumberBack.MaxRows = 5;
            this.notePanel_NumberBack.Name = "notePanel_NumberBack";
            this.notePanel_NumberBack.ParentAutoHeight = true;
            this.notePanel_NumberBack.Size = new System.Drawing.Size(80, 22);
            this.notePanel_NumberBack.TabIndex = 10;
            this.notePanel_NumberBack.TabStop = false;
            this.notePanel_NumberBack.Text = "  学  号:";
            // 
            // notePanel1_NameBack
            // 
            this.notePanel1_NameBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel1_NameBack.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel1_NameBack.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel1_NameBack.ForeColor = System.Drawing.Color.Black;
            this.notePanel1_NameBack.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel1_NameBack.Location = new System.Drawing.Point(16, 32);
            this.notePanel1_NameBack.MaxRows = 5;
            this.notePanel1_NameBack.Name = "notePanel1_NameBack";
            this.notePanel1_NameBack.ParentAutoHeight = true;
            this.notePanel1_NameBack.Size = new System.Drawing.Size(80, 22);
            this.notePanel1_NameBack.TabIndex = 9;
            this.notePanel1_NameBack.TabStop = false;
            this.notePanel1_NameBack.Text = "  姓  名:";
            // 
            // groupControl_GradeClassBack
            // 
            this.groupControl_GradeClassBack.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_GradeClassBack.AppearanceCaption.Options.UseFont = true;
            this.groupControl_GradeClassBack.Controls.Add(this.comboBoxEdit_ClassBack);
            this.groupControl_GradeClassBack.Controls.Add(this.comboBoxEdit_GradeBack);
            this.groupControl_GradeClassBack.Controls.Add(this.notePanel1_GradeBack);
            this.groupControl_GradeClassBack.Controls.Add(this.notePanel1_ClassBack);
            this.groupControl_GradeClassBack.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl_GradeClassBack.Location = new System.Drawing.Point(2, 198);
            this.groupControl_GradeClassBack.Name = "groupControl_GradeClassBack";
            this.groupControl_GradeClassBack.Size = new System.Drawing.Size(234, 120);
            this.groupControl_GradeClassBack.TabIndex = 20;
            this.groupControl_GradeClassBack.Text = "指定搜索的年级和班级";
            this.groupControl_GradeClassBack.Visible = false;
            // 
            // comboBoxEdit_ClassBack
            // 
            this.comboBoxEdit_ClassBack.EditValue = "全部";
            this.comboBoxEdit_ClassBack.Location = new System.Drawing.Point(104, 72);
            this.comboBoxEdit_ClassBack.Name = "comboBoxEdit_ClassBack";
            this.comboBoxEdit_ClassBack.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_ClassBack.Properties.Items.AddRange(new object[] {
            "全部"});
            this.comboBoxEdit_ClassBack.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_ClassBack.Size = new System.Drawing.Size(112, 20);
            this.comboBoxEdit_ClassBack.TabIndex = 18;
            this.comboBoxEdit_ClassBack.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_ClassBack_SelectedIndexChanged);
            // 
            // comboBoxEdit_GradeBack
            // 
            this.comboBoxEdit_GradeBack.EditValue = "全部";
            this.comboBoxEdit_GradeBack.Location = new System.Drawing.Point(104, 32);
            this.comboBoxEdit_GradeBack.Name = "comboBoxEdit_GradeBack";
            this.comboBoxEdit_GradeBack.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_GradeBack.Properties.Items.AddRange(new object[] {
            "全部"});
            this.comboBoxEdit_GradeBack.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_GradeBack.Size = new System.Drawing.Size(112, 20);
            this.comboBoxEdit_GradeBack.TabIndex = 17;
            this.comboBoxEdit_GradeBack.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_GradeBack_SelectedIndexChanged);
            // 
            // notePanel1_GradeBack
            // 
            this.notePanel1_GradeBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel1_GradeBack.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel1_GradeBack.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel1_GradeBack.ForeColor = System.Drawing.Color.Black;
            this.notePanel1_GradeBack.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel1_GradeBack.Location = new System.Drawing.Point(16, 32);
            this.notePanel1_GradeBack.MaxRows = 5;
            this.notePanel1_GradeBack.Name = "notePanel1_GradeBack";
            this.notePanel1_GradeBack.ParentAutoHeight = true;
            this.notePanel1_GradeBack.Size = new System.Drawing.Size(80, 22);
            this.notePanel1_GradeBack.TabIndex = 4;
            this.notePanel1_GradeBack.TabStop = false;
            this.notePanel1_GradeBack.Text = "  年  级:";
            // 
            // notePanel1_ClassBack
            // 
            this.notePanel1_ClassBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel1_ClassBack.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel1_ClassBack.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel1_ClassBack.ForeColor = System.Drawing.Color.Black;
            this.notePanel1_ClassBack.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel1_ClassBack.Location = new System.Drawing.Point(16, 72);
            this.notePanel1_ClassBack.MaxRows = 5;
            this.notePanel1_ClassBack.Name = "notePanel1_ClassBack";
            this.notePanel1_ClassBack.ParentAutoHeight = true;
            this.notePanel1_ClassBack.Size = new System.Drawing.Size(80, 22);
            this.notePanel1_ClassBack.TabIndex = 16;
            this.notePanel1_ClassBack.TabStop = false;
            this.notePanel1_ClassBack.Text = "  班  级:";
            // 
            // notePanel_GradeClassBack
            // 
            this.notePanel_GradeClassBack.BackColor = System.Drawing.Color.Yellow;
            this.notePanel_GradeClassBack.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_GradeClassBack.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notePanel_GradeClassBack.ForeColor = System.Drawing.Color.Black;
            this.notePanel_GradeClassBack.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_GradeClassBack.Location = new System.Drawing.Point(16, 50);
            this.notePanel_GradeClassBack.MaxRows = 5;
            this.notePanel_GradeClassBack.Name = "notePanel_GradeClassBack";
            this.notePanel_GradeClassBack.ParentAutoHeight = true;
            this.notePanel_GradeClassBack.Size = new System.Drawing.Size(200, 22);
            this.notePanel_GradeClassBack.TabIndex = 19;
            this.notePanel_GradeClassBack.TabStop = false;
            this.notePanel_GradeClassBack.Text = "年级和班级:";
            this.notePanel_GradeClassBack.Click += new System.EventHandler(this.notePanel_GradeClassBack_Click);
            // 
            // notePanel_TimeConBack
            // 
            this.notePanel_TimeConBack.BackColor = System.Drawing.Color.Yellow;
            this.notePanel_TimeConBack.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_TimeConBack.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_TimeConBack.ForeColor = System.Drawing.Color.Black;
            this.notePanel_TimeConBack.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_TimeConBack.Location = new System.Drawing.Point(16, 98);
            this.notePanel_TimeConBack.MaxRows = 5;
            this.notePanel_TimeConBack.Name = "notePanel_TimeConBack";
            this.notePanel_TimeConBack.ParentAutoHeight = true;
            this.notePanel_TimeConBack.Size = new System.Drawing.Size(200, 22);
            this.notePanel_TimeConBack.TabIndex = 18;
            this.notePanel_TimeConBack.TabStop = false;
            this.notePanel_TimeConBack.Text = "时间和情况:";
            this.notePanel_TimeConBack.Click += new System.EventHandler(this.notePanel_TimeConBack_Click);
            // 
            // notePanel_NumberNameBack
            // 
            this.notePanel_NumberNameBack.BackColor = System.Drawing.Color.Yellow;
            this.notePanel_NumberNameBack.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_NumberNameBack.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_NumberNameBack.ForeColor = System.Drawing.Color.Black;
            this.notePanel_NumberNameBack.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_NumberNameBack.Location = new System.Drawing.Point(16, 74);
            this.notePanel_NumberNameBack.MaxRows = 5;
            this.notePanel_NumberNameBack.Name = "notePanel_NumberNameBack";
            this.notePanel_NumberNameBack.ParentAutoHeight = true;
            this.notePanel_NumberNameBack.Size = new System.Drawing.Size(200, 22);
            this.notePanel_NumberNameBack.TabIndex = 17;
            this.notePanel_NumberNameBack.TabStop = false;
            this.notePanel_NumberNameBack.Text = "学号和姓名:";
            this.notePanel_NumberNameBack.Click += new System.EventHandler(this.notePanel_NumberNameBack_Click);
            // 
            // notePanel_SerCondBack
            // 
            this.notePanel_SerCondBack.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.notePanel_SerCondBack.Dock = System.Windows.Forms.DockStyle.Top;
            this.notePanel_SerCondBack.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notePanel_SerCondBack.ForeColor = System.Drawing.Color.OrangeRed;
            this.notePanel_SerCondBack.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_SerCondBack.Location = new System.Drawing.Point(2, 22);
            this.notePanel_SerCondBack.MaxRows = 5;
            this.notePanel_SerCondBack.Name = "notePanel_SerCondBack";
            this.notePanel_SerCondBack.ParentAutoHeight = true;
            this.notePanel_SerCondBack.Size = new System.Drawing.Size(234, 23);
            this.notePanel_SerCondBack.TabIndex = 5;
            this.notePanel_SerCondBack.TabStop = false;
            this.notePanel_SerCondBack.Text = "您要搜索的条件？";
            // 
            // gridControl_BackInfo
            // 
            this.gridControl_BackInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_BackInfo.Location = new System.Drawing.Point(0, 40);
            this.gridControl_BackInfo.MainView = this.gridView2;
            this.gridControl_BackInfo.Name = "gridControl_BackInfo";
            this.gridControl_BackInfo.Size = new System.Drawing.Size(523, 471);
            this.gridControl_BackInfo.TabIndex = 9;
            this.gridControl_BackInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13});
            this.gridView2.GridControl = this.gridControl_BackInfo;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "序号";
            this.gridColumn7.FieldName = "info_stuOrderNumber";
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
            this.gridColumn7.VisibleIndex = 0;
            this.gridColumn7.Width = 62;
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
            this.gridColumn8.OptionsColumn.AllowMove = false;
            this.gridColumn8.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn8.OptionsColumn.FixedWidth = true;
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            this.gridColumn8.Width = 62;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.Caption = "学号";
            this.gridColumn9.FieldName = "info_stuNumber";
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
            this.gridColumn9.VisibleIndex = 2;
            this.gridColumn9.Width = 57;
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
            this.gridColumn10.VisibleIndex = 3;
            this.gridColumn10.Width = 59;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn11.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn11.Caption = "离园时间";
            this.gridColumn11.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn11.FieldName = "flow_stuFlowBackDate";
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
            this.gridColumn11.VisibleIndex = 4;
            this.gridColumn11.Width = 165;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn12.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn12.Caption = "接走情况";
            this.gridColumn12.FieldName = "state_flowStateName";
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
            this.gridColumn12.VisibleIndex = 5;
            this.gridColumn12.Width = 81;
            // 
            // gridColumn13
            // 
            this.gridColumn13.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn13.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn13.Caption = "接领家长";
            this.gridColumn13.FieldName = "info_stuCardHolder";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn13.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn13.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn13.OptionsColumn.AllowMove = false;
            this.gridColumn13.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn13.OptionsColumn.FixedWidth = true;
            this.gridColumn13.OptionsColumn.ReadOnly = true;
            this.gridColumn13.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 6;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton_PrintBack);
            this.panelControl2.Controls.Add(this.simpleButton_SearchBack);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(523, 40);
            this.panelControl2.TabIndex = 8;
            // 
            // simpleButton_PrintBack
            // 
            this.simpleButton_PrintBack.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_PrintBack.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
            this.simpleButton_PrintBack.Appearance.Options.UseFont = true;
            this.simpleButton_PrintBack.Appearance.Options.UseForeColor = true;
            this.simpleButton_PrintBack.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_PrintBack.Image")));
            this.simpleButton_PrintBack.Location = new System.Drawing.Point(112, 8);
            this.simpleButton_PrintBack.Name = "simpleButton_PrintBack";
            this.simpleButton_PrintBack.Size = new System.Drawing.Size(92, 26);
            this.simpleButton_PrintBack.TabIndex = 8;
            this.simpleButton_PrintBack.Tag = 4;
            this.simpleButton_PrintBack.Text = "报  表";
            this.simpleButton_PrintBack.Click += new System.EventHandler(this.simpleButton_PrintBack_Click);
            // 
            // simpleButton_SearchBack
            // 
            this.simpleButton_SearchBack.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_SearchBack.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
            this.simpleButton_SearchBack.Appearance.Options.UseFont = true;
            this.simpleButton_SearchBack.Appearance.Options.UseForeColor = true;
            this.simpleButton_SearchBack.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_SearchBack.Image")));
            this.simpleButton_SearchBack.Location = new System.Drawing.Point(8, 8);
            this.simpleButton_SearchBack.Name = "simpleButton_SearchBack";
            this.simpleButton_SearchBack.Size = new System.Drawing.Size(92, 26);
            this.simpleButton_SearchBack.TabIndex = 5;
            this.simpleButton_SearchBack.Tag = 4;
            this.simpleButton_SearchBack.Text = "搜  索";
            this.simpleButton_SearchBack.Click += new System.EventHandler(this.simpleButton_SearchBack_Click);
            // 
            // xtraTabPage_FreeDefinition
            // 
            this.xtraTabPage_FreeDefinition.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xtraTabPage_FreeDefinition.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabPage_FreeDefinition.Controls.Add(this.splitContainerControl3);
            this.xtraTabPage_FreeDefinition.Name = "xtraTabPage_FreeDefinition";
            this.xtraTabPage_FreeDefinition.Size = new System.Drawing.Size(766, 511);
            this.xtraTabPage_FreeDefinition.Text = "幼儿自定义信息查询";
            // 
            // splitContainerControl3
            // 
            this.splitContainerControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl3.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl3.Name = "splitContainerControl3";
            this.splitContainerControl3.Panel1.Controls.Add(this.groupControl_FastSerFreeDef);
            this.splitContainerControl3.Panel1.Text = "splitContainerControl3_Panel1";
            this.splitContainerControl3.Panel2.Controls.Add(this.gridControl_FreeDef);
            this.splitContainerControl3.Panel2.Controls.Add(this.panelControl3);
            this.splitContainerControl3.Panel2.Text = "splitContainerControl3_Panel2";
            this.splitContainerControl3.Size = new System.Drawing.Size(766, 511);
            this.splitContainerControl3.SplitterPosition = 253;
            this.splitContainerControl3.TabIndex = 0;
            this.splitContainerControl3.Text = "splitContainerControl3";
            // 
            // groupControl_FastSerFreeDef
            // 
            this.groupControl_FastSerFreeDef.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_FastSerFreeDef.AppearanceCaption.Options.UseFont = true;
            this.groupControl_FastSerFreeDef.Controls.Add(this.groupControl_TimeStatusFreeDef);
            this.groupControl_FastSerFreeDef.Controls.Add(this.groupControl_NumberNameFreeDef);
            this.groupControl_FastSerFreeDef.Controls.Add(this.groupControl_GradeClassFreeDef);
            this.groupControl_FastSerFreeDef.Controls.Add(this.notePanel_GradeClassFreeDef);
            this.groupControl_FastSerFreeDef.Controls.Add(this.notePanel_TimeStatusFreeDef);
            this.groupControl_FastSerFreeDef.Controls.Add(this.notePanel_NumberNameFreeDef);
            this.groupControl_FastSerFreeDef.Controls.Add(this.notePanel1_SerCondFreeDef);
            this.groupControl_FastSerFreeDef.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl_FastSerFreeDef.Location = new System.Drawing.Point(0, 0);
            this.groupControl_FastSerFreeDef.Name = "groupControl_FastSerFreeDef";
            this.groupControl_FastSerFreeDef.Size = new System.Drawing.Size(253, 336);
            this.groupControl_FastSerFreeDef.TabIndex = 9;
            this.groupControl_FastSerFreeDef.Text = "快速搜索";
            // 
            // groupControl_TimeStatusFreeDef
            // 
            this.groupControl_TimeStatusFreeDef.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_TimeStatusFreeDef.AppearanceCaption.ForeColor = System.Drawing.Color.Black;
            this.groupControl_TimeStatusFreeDef.AppearanceCaption.Options.UseFont = true;
            this.groupControl_TimeStatusFreeDef.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl_TimeStatusFreeDef.Controls.Add(this.dateEdit_SpecificDateFreeDef);
            this.groupControl_TimeStatusFreeDef.Controls.Add(this.notePanel_SpecificDateFreeDef);
            this.groupControl_TimeStatusFreeDef.Controls.Add(this.comboBoxEdit_TimeModeFreeDef);
            this.groupControl_TimeStatusFreeDef.Controls.Add(this.textEdit_EndTimeFreeDef);
            this.groupControl_TimeStatusFreeDef.Controls.Add(this.textEdit_BegTimeFreeDef);
            this.groupControl_TimeStatusFreeDef.Controls.Add(this.notePanel_TimeMode_FreeDef);
            this.groupControl_TimeStatusFreeDef.Controls.Add(this.comboBoxEdit_CustomStatusDef);
            this.groupControl_TimeStatusFreeDef.Controls.Add(this.notePanel_FreeDef);
            this.groupControl_TimeStatusFreeDef.Controls.Add(this.notePanel_BegTimeFreeDef);
            this.groupControl_TimeStatusFreeDef.Controls.Add(this.notePanel_EndTimeFreeDef);
            this.groupControl_TimeStatusFreeDef.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl_TimeStatusFreeDef.Location = new System.Drawing.Point(2, -98);
            this.groupControl_TimeStatusFreeDef.Name = "groupControl_TimeStatusFreeDef";
            this.groupControl_TimeStatusFreeDef.Size = new System.Drawing.Size(249, 192);
            this.groupControl_TimeStatusFreeDef.TabIndex = 22;
            this.groupControl_TimeStatusFreeDef.Text = "指定搜索的时间和自定义状态";
            this.groupControl_TimeStatusFreeDef.Visible = false;
            // 
            // dateEdit_SpecificDateFreeDef
            // 
            this.dateEdit_SpecificDateFreeDef.EditValue = new System.DateTime(2005, 1, 31, 0, 0, 0, 0);
            this.dateEdit_SpecificDateFreeDef.Location = new System.Drawing.Point(104, 32);
            this.dateEdit_SpecificDateFreeDef.Name = "dateEdit_SpecificDateFreeDef";
            this.dateEdit_SpecificDateFreeDef.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_SpecificDateFreeDef.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit_SpecificDateFreeDef.Size = new System.Drawing.Size(120, 20);
            this.dateEdit_SpecificDateFreeDef.TabIndex = 24;
            // 
            // notePanel_SpecificDateFreeDef
            // 
            this.notePanel_SpecificDateFreeDef.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_SpecificDateFreeDef.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_SpecificDateFreeDef.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_SpecificDateFreeDef.ForeColor = System.Drawing.Color.Black;
            this.notePanel_SpecificDateFreeDef.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_SpecificDateFreeDef.Location = new System.Drawing.Point(16, 32);
            this.notePanel_SpecificDateFreeDef.MaxRows = 5;
            this.notePanel_SpecificDateFreeDef.Name = "notePanel_SpecificDateFreeDef";
            this.notePanel_SpecificDateFreeDef.ParentAutoHeight = true;
            this.notePanel_SpecificDateFreeDef.Size = new System.Drawing.Size(80, 22);
            this.notePanel_SpecificDateFreeDef.TabIndex = 23;
            this.notePanel_SpecificDateFreeDef.TabStop = false;
            this.notePanel_SpecificDateFreeDef.Text = "起始时间";
            // 
            // comboBoxEdit_TimeModeFreeDef
            // 
            this.comboBoxEdit_TimeModeFreeDef.EditValue = "模糊时间";
            this.comboBoxEdit_TimeModeFreeDef.Location = new System.Drawing.Point(104, 128);
            this.comboBoxEdit_TimeModeFreeDef.Name = "comboBoxEdit_TimeModeFreeDef";
            this.comboBoxEdit_TimeModeFreeDef.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_TimeModeFreeDef.Properties.Items.AddRange(new object[] {
            "模糊时间",
            "精确时间"});
            this.comboBoxEdit_TimeModeFreeDef.Size = new System.Drawing.Size(120, 20);
            this.comboBoxEdit_TimeModeFreeDef.TabIndex = 22;
            this.comboBoxEdit_TimeModeFreeDef.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_TimeModeFreeDef_SelectedIndexChanged);
            // 
            // textEdit_EndTimeFreeDef
            // 
            this.textEdit_EndTimeFreeDef.EditValue = "";
            this.textEdit_EndTimeFreeDef.Location = new System.Drawing.Point(104, 96);
            this.textEdit_EndTimeFreeDef.Name = "textEdit_EndTimeFreeDef";
            this.textEdit_EndTimeFreeDef.Properties.DisplayFormat.FormatString = "d";
            this.textEdit_EndTimeFreeDef.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.textEdit_EndTimeFreeDef.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.textEdit_EndTimeFreeDef.Properties.Mask.EditMask = "d";
            this.textEdit_EndTimeFreeDef.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.textEdit_EndTimeFreeDef.Size = new System.Drawing.Size(120, 20);
            this.textEdit_EndTimeFreeDef.TabIndex = 21;
            // 
            // textEdit_BegTimeFreeDef
            // 
            this.textEdit_BegTimeFreeDef.EditValue = "";
            this.textEdit_BegTimeFreeDef.Location = new System.Drawing.Point(104, 64);
            this.textEdit_BegTimeFreeDef.Name = "textEdit_BegTimeFreeDef";
            this.textEdit_BegTimeFreeDef.Properties.DisplayFormat.FormatString = "d";
            this.textEdit_BegTimeFreeDef.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.textEdit_BegTimeFreeDef.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.textEdit_BegTimeFreeDef.Properties.Mask.EditMask = "d";
            this.textEdit_BegTimeFreeDef.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.textEdit_BegTimeFreeDef.Size = new System.Drawing.Size(120, 20);
            this.textEdit_BegTimeFreeDef.TabIndex = 20;
            // 
            // notePanel_TimeMode_FreeDef
            // 
            this.notePanel_TimeMode_FreeDef.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_TimeMode_FreeDef.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_TimeMode_FreeDef.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_TimeMode_FreeDef.ForeColor = System.Drawing.Color.Black;
            this.notePanel_TimeMode_FreeDef.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_TimeMode_FreeDef.Location = new System.Drawing.Point(16, 128);
            this.notePanel_TimeMode_FreeDef.MaxRows = 5;
            this.notePanel_TimeMode_FreeDef.Name = "notePanel_TimeMode_FreeDef";
            this.notePanel_TimeMode_FreeDef.ParentAutoHeight = true;
            this.notePanel_TimeMode_FreeDef.Size = new System.Drawing.Size(80, 22);
            this.notePanel_TimeMode_FreeDef.TabIndex = 19;
            this.notePanel_TimeMode_FreeDef.TabStop = false;
            this.notePanel_TimeMode_FreeDef.Text = "结束时间";
            // 
            // comboBoxEdit_CustomStatusDef
            // 
            this.comboBoxEdit_CustomStatusDef.EditValue = "全部";
            this.comboBoxEdit_CustomStatusDef.Location = new System.Drawing.Point(104, 160);
            this.comboBoxEdit_CustomStatusDef.Name = "comboBoxEdit_CustomStatusDef";
            this.comboBoxEdit_CustomStatusDef.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_CustomStatusDef.Properties.Items.AddRange(new object[] {
            "全部"});
            this.comboBoxEdit_CustomStatusDef.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_CustomStatusDef.Size = new System.Drawing.Size(120, 20);
            this.comboBoxEdit_CustomStatusDef.TabIndex = 18;
            this.comboBoxEdit_CustomStatusDef.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_CustomStatusDef_SelectedIndexChanged);
            // 
            // notePanel_FreeDef
            // 
            this.notePanel_FreeDef.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_FreeDef.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_FreeDef.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_FreeDef.ForeColor = System.Drawing.Color.Black;
            this.notePanel_FreeDef.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_FreeDef.Location = new System.Drawing.Point(16, 160);
            this.notePanel_FreeDef.MaxRows = 5;
            this.notePanel_FreeDef.Name = "notePanel_FreeDef";
            this.notePanel_FreeDef.ParentAutoHeight = true;
            this.notePanel_FreeDef.Size = new System.Drawing.Size(80, 22);
            this.notePanel_FreeDef.TabIndex = 17;
            this.notePanel_FreeDef.TabStop = false;
            this.notePanel_FreeDef.Text = "定义状态:";
            // 
            // notePanel_BegTimeFreeDef
            // 
            this.notePanel_BegTimeFreeDef.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_BegTimeFreeDef.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_BegTimeFreeDef.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_BegTimeFreeDef.ForeColor = System.Drawing.Color.Black;
            this.notePanel_BegTimeFreeDef.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_BegTimeFreeDef.Location = new System.Drawing.Point(16, 64);
            this.notePanel_BegTimeFreeDef.MaxRows = 5;
            this.notePanel_BegTimeFreeDef.Name = "notePanel_BegTimeFreeDef";
            this.notePanel_BegTimeFreeDef.ParentAutoHeight = true;
            this.notePanel_BegTimeFreeDef.Size = new System.Drawing.Size(80, 22);
            this.notePanel_BegTimeFreeDef.TabIndex = 14;
            this.notePanel_BegTimeFreeDef.TabStop = false;
            this.notePanel_BegTimeFreeDef.Text = "起始时间";
            // 
            // notePanel_EndTimeFreeDef
            // 
            this.notePanel_EndTimeFreeDef.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_EndTimeFreeDef.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_EndTimeFreeDef.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_EndTimeFreeDef.ForeColor = System.Drawing.Color.Black;
            this.notePanel_EndTimeFreeDef.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_EndTimeFreeDef.Location = new System.Drawing.Point(16, 96);
            this.notePanel_EndTimeFreeDef.MaxRows = 5;
            this.notePanel_EndTimeFreeDef.Name = "notePanel_EndTimeFreeDef";
            this.notePanel_EndTimeFreeDef.ParentAutoHeight = true;
            this.notePanel_EndTimeFreeDef.Size = new System.Drawing.Size(80, 22);
            this.notePanel_EndTimeFreeDef.TabIndex = 13;
            this.notePanel_EndTimeFreeDef.TabStop = false;
            this.notePanel_EndTimeFreeDef.Text = "结束时间";
            // 
            // groupControl_NumberNameFreeDef
            // 
            this.groupControl_NumberNameFreeDef.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_NumberNameFreeDef.AppearanceCaption.ForeColor = System.Drawing.Color.Black;
            this.groupControl_NumberNameFreeDef.AppearanceCaption.Options.UseFont = true;
            this.groupControl_NumberNameFreeDef.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl_NumberNameFreeDef.Controls.Add(this.textEdit_NameFreeDef);
            this.groupControl_NumberNameFreeDef.Controls.Add(this.textEdit_NumberFreeDef);
            this.groupControl_NumberNameFreeDef.Controls.Add(this.notePanel_NumberFreeDef);
            this.groupControl_NumberNameFreeDef.Controls.Add(this.notePanel_NameFreeDef);
            this.groupControl_NumberNameFreeDef.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl_NumberNameFreeDef.Location = new System.Drawing.Point(2, 94);
            this.groupControl_NumberNameFreeDef.Name = "groupControl_NumberNameFreeDef";
            this.groupControl_NumberNameFreeDef.Size = new System.Drawing.Size(249, 120);
            this.groupControl_NumberNameFreeDef.TabIndex = 21;
            this.groupControl_NumberNameFreeDef.Text = "指定搜索的学号和姓名";
            this.groupControl_NumberNameFreeDef.Visible = false;
            // 
            // textEdit_NameFreeDef
            // 
            this.textEdit_NameFreeDef.EditValue = "";
            this.textEdit_NameFreeDef.Location = new System.Drawing.Point(104, 32);
            this.textEdit_NameFreeDef.Name = "textEdit_NameFreeDef";
            this.textEdit_NameFreeDef.Size = new System.Drawing.Size(120, 20);
            this.textEdit_NameFreeDef.TabIndex = 12;
            // 
            // textEdit_NumberFreeDef
            // 
            this.textEdit_NumberFreeDef.EditValue = "";
            this.textEdit_NumberFreeDef.Location = new System.Drawing.Point(104, 72);
            this.textEdit_NumberFreeDef.Name = "textEdit_NumberFreeDef";
            this.textEdit_NumberFreeDef.Size = new System.Drawing.Size(120, 20);
            this.textEdit_NumberFreeDef.TabIndex = 11;
            // 
            // notePanel_NumberFreeDef
            // 
            this.notePanel_NumberFreeDef.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_NumberFreeDef.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_NumberFreeDef.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_NumberFreeDef.ForeColor = System.Drawing.Color.Black;
            this.notePanel_NumberFreeDef.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_NumberFreeDef.Location = new System.Drawing.Point(16, 72);
            this.notePanel_NumberFreeDef.MaxRows = 5;
            this.notePanel_NumberFreeDef.Name = "notePanel_NumberFreeDef";
            this.notePanel_NumberFreeDef.ParentAutoHeight = true;
            this.notePanel_NumberFreeDef.Size = new System.Drawing.Size(80, 22);
            this.notePanel_NumberFreeDef.TabIndex = 10;
            this.notePanel_NumberFreeDef.TabStop = false;
            this.notePanel_NumberFreeDef.Text = "  学  号:";
            // 
            // notePanel_NameFreeDef
            // 
            this.notePanel_NameFreeDef.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_NameFreeDef.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_NameFreeDef.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_NameFreeDef.ForeColor = System.Drawing.Color.Black;
            this.notePanel_NameFreeDef.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_NameFreeDef.Location = new System.Drawing.Point(16, 32);
            this.notePanel_NameFreeDef.MaxRows = 5;
            this.notePanel_NameFreeDef.Name = "notePanel_NameFreeDef";
            this.notePanel_NameFreeDef.ParentAutoHeight = true;
            this.notePanel_NameFreeDef.Size = new System.Drawing.Size(80, 22);
            this.notePanel_NameFreeDef.TabIndex = 9;
            this.notePanel_NameFreeDef.TabStop = false;
            this.notePanel_NameFreeDef.Text = "  姓  名:";
            // 
            // groupControl_GradeClassFreeDef
            // 
            this.groupControl_GradeClassFreeDef.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_GradeClassFreeDef.AppearanceCaption.Options.UseFont = true;
            this.groupControl_GradeClassFreeDef.Controls.Add(this.comboBoxEdit_ClassFreeDef);
            this.groupControl_GradeClassFreeDef.Controls.Add(this.comboBoxEdit_GradeFreeDef);
            this.groupControl_GradeClassFreeDef.Controls.Add(this.notePanel_GradeFreeDef);
            this.groupControl_GradeClassFreeDef.Controls.Add(this.notePanel_ClassFreeDef);
            this.groupControl_GradeClassFreeDef.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl_GradeClassFreeDef.Location = new System.Drawing.Point(2, 214);
            this.groupControl_GradeClassFreeDef.Name = "groupControl_GradeClassFreeDef";
            this.groupControl_GradeClassFreeDef.Size = new System.Drawing.Size(249, 120);
            this.groupControl_GradeClassFreeDef.TabIndex = 20;
            this.groupControl_GradeClassFreeDef.Text = "指定搜索的年级和班级";
            this.groupControl_GradeClassFreeDef.Visible = false;
            // 
            // comboBoxEdit_ClassFreeDef
            // 
            this.comboBoxEdit_ClassFreeDef.EditValue = "全部";
            this.comboBoxEdit_ClassFreeDef.Location = new System.Drawing.Point(104, 72);
            this.comboBoxEdit_ClassFreeDef.Name = "comboBoxEdit_ClassFreeDef";
            this.comboBoxEdit_ClassFreeDef.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_ClassFreeDef.Properties.Items.AddRange(new object[] {
            "全部"});
            this.comboBoxEdit_ClassFreeDef.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_ClassFreeDef.Size = new System.Drawing.Size(120, 20);
            this.comboBoxEdit_ClassFreeDef.TabIndex = 18;
            this.comboBoxEdit_ClassFreeDef.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_ClassFreeDef_SelectedIndexChanged);
            // 
            // comboBoxEdit_GradeFreeDef
            // 
            this.comboBoxEdit_GradeFreeDef.EditValue = "全部";
            this.comboBoxEdit_GradeFreeDef.Location = new System.Drawing.Point(104, 32);
            this.comboBoxEdit_GradeFreeDef.Name = "comboBoxEdit_GradeFreeDef";
            this.comboBoxEdit_GradeFreeDef.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_GradeFreeDef.Properties.Items.AddRange(new object[] {
            "全部"});
            this.comboBoxEdit_GradeFreeDef.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_GradeFreeDef.Size = new System.Drawing.Size(120, 20);
            this.comboBoxEdit_GradeFreeDef.TabIndex = 17;
            this.comboBoxEdit_GradeFreeDef.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_GradeFreeDef_SelectedIndexChanged);
            // 
            // notePanel_GradeFreeDef
            // 
            this.notePanel_GradeFreeDef.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_GradeFreeDef.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_GradeFreeDef.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_GradeFreeDef.ForeColor = System.Drawing.Color.Black;
            this.notePanel_GradeFreeDef.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_GradeFreeDef.Location = new System.Drawing.Point(16, 32);
            this.notePanel_GradeFreeDef.MaxRows = 5;
            this.notePanel_GradeFreeDef.Name = "notePanel_GradeFreeDef";
            this.notePanel_GradeFreeDef.ParentAutoHeight = true;
            this.notePanel_GradeFreeDef.Size = new System.Drawing.Size(80, 22);
            this.notePanel_GradeFreeDef.TabIndex = 4;
            this.notePanel_GradeFreeDef.TabStop = false;
            this.notePanel_GradeFreeDef.Text = "  年  级:";
            // 
            // notePanel_ClassFreeDef
            // 
            this.notePanel_ClassFreeDef.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_ClassFreeDef.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_ClassFreeDef.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_ClassFreeDef.ForeColor = System.Drawing.Color.Black;
            this.notePanel_ClassFreeDef.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_ClassFreeDef.Location = new System.Drawing.Point(16, 72);
            this.notePanel_ClassFreeDef.MaxRows = 5;
            this.notePanel_ClassFreeDef.Name = "notePanel_ClassFreeDef";
            this.notePanel_ClassFreeDef.ParentAutoHeight = true;
            this.notePanel_ClassFreeDef.Size = new System.Drawing.Size(80, 22);
            this.notePanel_ClassFreeDef.TabIndex = 16;
            this.notePanel_ClassFreeDef.TabStop = false;
            this.notePanel_ClassFreeDef.Text = "  班  级:";
            // 
            // notePanel_GradeClassFreeDef
            // 
            this.notePanel_GradeClassFreeDef.BackColor = System.Drawing.Color.LightGray;
            this.notePanel_GradeClassFreeDef.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_GradeClassFreeDef.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notePanel_GradeClassFreeDef.ForeColor = System.Drawing.Color.Black;
            this.notePanel_GradeClassFreeDef.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_GradeClassFreeDef.Location = new System.Drawing.Point(16, 50);
            this.notePanel_GradeClassFreeDef.MaxRows = 5;
            this.notePanel_GradeClassFreeDef.Name = "notePanel_GradeClassFreeDef";
            this.notePanel_GradeClassFreeDef.ParentAutoHeight = true;
            this.notePanel_GradeClassFreeDef.Size = new System.Drawing.Size(208, 22);
            this.notePanel_GradeClassFreeDef.TabIndex = 19;
            this.notePanel_GradeClassFreeDef.TabStop = false;
            this.notePanel_GradeClassFreeDef.Text = "年级和班级:";
            this.notePanel_GradeClassFreeDef.Click += new System.EventHandler(this.notePanel_GradeClassFreeDef_Click);
            // 
            // notePanel_TimeStatusFreeDef
            // 
            this.notePanel_TimeStatusFreeDef.BackColor = System.Drawing.Color.LightGray;
            this.notePanel_TimeStatusFreeDef.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_TimeStatusFreeDef.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_TimeStatusFreeDef.ForeColor = System.Drawing.Color.Black;
            this.notePanel_TimeStatusFreeDef.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_TimeStatusFreeDef.Location = new System.Drawing.Point(16, 98);
            this.notePanel_TimeStatusFreeDef.MaxRows = 5;
            this.notePanel_TimeStatusFreeDef.Name = "notePanel_TimeStatusFreeDef";
            this.notePanel_TimeStatusFreeDef.ParentAutoHeight = true;
            this.notePanel_TimeStatusFreeDef.Size = new System.Drawing.Size(208, 22);
            this.notePanel_TimeStatusFreeDef.TabIndex = 18;
            this.notePanel_TimeStatusFreeDef.TabStop = false;
            this.notePanel_TimeStatusFreeDef.Text = "时间和状态:";
            this.notePanel_TimeStatusFreeDef.Click += new System.EventHandler(this.notePanel_TimeStatusFreeDef_Click);
            // 
            // notePanel_NumberNameFreeDef
            // 
            this.notePanel_NumberNameFreeDef.BackColor = System.Drawing.Color.LightGray;
            this.notePanel_NumberNameFreeDef.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_NumberNameFreeDef.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_NumberNameFreeDef.ForeColor = System.Drawing.Color.Black;
            this.notePanel_NumberNameFreeDef.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_NumberNameFreeDef.Location = new System.Drawing.Point(16, 74);
            this.notePanel_NumberNameFreeDef.MaxRows = 5;
            this.notePanel_NumberNameFreeDef.Name = "notePanel_NumberNameFreeDef";
            this.notePanel_NumberNameFreeDef.ParentAutoHeight = true;
            this.notePanel_NumberNameFreeDef.Size = new System.Drawing.Size(208, 22);
            this.notePanel_NumberNameFreeDef.TabIndex = 17;
            this.notePanel_NumberNameFreeDef.TabStop = false;
            this.notePanel_NumberNameFreeDef.Text = "学号和姓名:";
            this.notePanel_NumberNameFreeDef.Click += new System.EventHandler(this.notePanel_NumberNameFreeDef_Click);
            // 
            // notePanel1_SerCondFreeDef
            // 
            this.notePanel1_SerCondFreeDef.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.notePanel1_SerCondFreeDef.Dock = System.Windows.Forms.DockStyle.Top;
            this.notePanel1_SerCondFreeDef.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notePanel1_SerCondFreeDef.ForeColor = System.Drawing.Color.OrangeRed;
            this.notePanel1_SerCondFreeDef.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel1_SerCondFreeDef.Location = new System.Drawing.Point(2, 22);
            this.notePanel1_SerCondFreeDef.MaxRows = 5;
            this.notePanel1_SerCondFreeDef.Name = "notePanel1_SerCondFreeDef";
            this.notePanel1_SerCondFreeDef.ParentAutoHeight = true;
            this.notePanel1_SerCondFreeDef.Size = new System.Drawing.Size(249, 23);
            this.notePanel1_SerCondFreeDef.TabIndex = 5;
            this.notePanel1_SerCondFreeDef.TabStop = false;
            this.notePanel1_SerCondFreeDef.Text = "您要搜索的条件？";
            // 
            // gridControl_FreeDef
            // 
            this.gridControl_FreeDef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_FreeDef.Location = new System.Drawing.Point(0, 40);
            this.gridControl_FreeDef.MainView = this.gridView3;
            this.gridControl_FreeDef.Name = "gridControl_FreeDef";
            this.gridControl_FreeDef.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox_CustomState,
            this.repositoryItemComboBox1});
            this.gridControl_FreeDef.Size = new System.Drawing.Size(508, 471);
            this.gridControl_FreeDef.TabIndex = 12;
            this.gridControl_FreeDef.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19});
            this.gridView3.GridControl = this.gridControl_FreeDef;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsCustomization.AllowFilter = false;
            this.gridView3.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridView3.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView3_RowCellStyle);
            this.gridView3.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView3_FocusedRowChanged);
            this.gridView3.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView3_CellValueChanged);
            // 
            // gridColumn14
            // 
            this.gridColumn14.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn14.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn14.Caption = "序号";
            this.gridColumn14.FieldName = "info_stuOrderNumber";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn14.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn14.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn14.OptionsColumn.AllowMove = false;
            this.gridColumn14.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn14.OptionsColumn.FixedWidth = true;
            this.gridColumn14.OptionsColumn.ReadOnly = true;
            this.gridColumn14.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 0;
            this.gridColumn14.Width = 63;
            // 
            // gridColumn15
            // 
            this.gridColumn15.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn15.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn15.Caption = "班级";
            this.gridColumn15.FieldName = "info_className";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            this.gridColumn15.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn15.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn15.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn15.OptionsColumn.AllowMove = false;
            this.gridColumn15.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn15.OptionsColumn.FixedWidth = true;
            this.gridColumn15.OptionsColumn.ReadOnly = true;
            this.gridColumn15.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 1;
            this.gridColumn15.Width = 64;
            // 
            // gridColumn16
            // 
            this.gridColumn16.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn16.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn16.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn16.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn16.Caption = "学号";
            this.gridColumn16.FieldName = "info_stuNumber";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.AllowFocus = false;
            this.gridColumn16.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn16.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn16.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn16.OptionsColumn.AllowMove = false;
            this.gridColumn16.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn16.OptionsColumn.FixedWidth = true;
            this.gridColumn16.OptionsColumn.ReadOnly = true;
            this.gridColumn16.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 2;
            this.gridColumn16.Width = 63;
            // 
            // gridColumn17
            // 
            this.gridColumn17.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn17.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn17.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn17.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn17.Caption = "姓名";
            this.gridColumn17.FieldName = "info_stuName";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.AllowFocus = false;
            this.gridColumn17.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn17.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn17.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn17.OptionsColumn.AllowMove = false;
            this.gridColumn17.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn17.OptionsColumn.FixedWidth = true;
            this.gridColumn17.OptionsColumn.ReadOnly = true;
            this.gridColumn17.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 3;
            this.gridColumn17.Width = 58;
            // 
            // gridColumn18
            // 
            this.gridColumn18.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn18.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn18.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn18.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn18.Caption = "状态记录时间";
            this.gridColumn18.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.gridColumn18.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn18.FieldName = "flow_stuFlowEnterDate";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.AllowFocus = false;
            this.gridColumn18.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn18.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn18.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn18.OptionsColumn.AllowMove = false;
            this.gridColumn18.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn18.OptionsColumn.FixedWidth = true;
            this.gridColumn18.OptionsColumn.ReadOnly = true;
            this.gridColumn18.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 4;
            this.gridColumn18.Width = 117;
            // 
            // gridColumn19
            // 
            this.gridColumn19.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn19.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn19.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn19.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn19.Caption = "自定义状态";
            this.gridColumn19.ColumnEdit = this.repositoryItemComboBox_CustomState;
            this.gridColumn19.FieldName = "state_flowStateName";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn19.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn19.OptionsColumn.AllowMove = false;
            this.gridColumn19.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn19.OptionsColumn.FixedWidth = true;
            this.gridColumn19.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 5;
            // 
            // repositoryItemComboBox_CustomState
            // 
            this.repositoryItemComboBox_CustomState.AutoHeight = false;
            this.repositoryItemComboBox_CustomState.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox_CustomState.Name = "repositoryItemComboBox_CustomState";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.simpleButton_SearchFreeDef);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(508, 40);
            this.panelControl3.TabIndex = 11;
            // 
            // simpleButton_SearchFreeDef
            // 
            this.simpleButton_SearchFreeDef.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_SearchFreeDef.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
            this.simpleButton_SearchFreeDef.Appearance.Options.UseFont = true;
            this.simpleButton_SearchFreeDef.Appearance.Options.UseForeColor = true;
            this.simpleButton_SearchFreeDef.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_SearchFreeDef.Image")));
            this.simpleButton_SearchFreeDef.Location = new System.Drawing.Point(16, 8);
            this.simpleButton_SearchFreeDef.Name = "simpleButton_SearchFreeDef";
            this.simpleButton_SearchFreeDef.Size = new System.Drawing.Size(92, 26);
            this.simpleButton_SearchFreeDef.TabIndex = 8;
            this.simpleButton_SearchFreeDef.Tag = 4;
            this.simpleButton_SearchFreeDef.Text = "搜  索";
            this.simpleButton_SearchFreeDef.Click += new System.EventHandler(this.simpleButton_SearchFreeDef_Click);
            // 
            // xtraTabPage_MoreReport
            // 
            this.xtraTabPage_MoreReport.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xtraTabPage_MoreReport.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabPage_MoreReport.Controls.Add(this.splitContainerControl4);
            this.xtraTabPage_MoreReport.Name = "xtraTabPage_MoreReport";
            this.xtraTabPage_MoreReport.Size = new System.Drawing.Size(766, 511);
            this.xtraTabPage_MoreReport.Text = "晨检信息综合统计报表";
            // 
            // splitContainerControl4
            // 
            this.splitContainerControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl4.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl4.Name = "splitContainerControl4";
            this.splitContainerControl4.Panel1.Controls.Add(this.groupControl_FastSerReport);
            this.splitContainerControl4.Panel1.Text = "splitContainerControl4_Panel1";
            this.splitContainerControl4.Panel2.Controls.Add(this.groupControl_PreviewReport);
            this.splitContainerControl4.Panel2.Controls.Add(this.panelControl4);
            this.splitContainerControl4.Panel2.Text = "splitContainerControl4_Panel2";
            this.splitContainerControl4.Size = new System.Drawing.Size(766, 511);
            this.splitContainerControl4.SplitterPosition = 233;
            this.splitContainerControl4.TabIndex = 0;
            this.splitContainerControl4.Text = "splitContainerControl4";
            // 
            // groupControl_FastSerReport
            // 
            this.groupControl_FastSerReport.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_FastSerReport.AppearanceCaption.Options.UseFont = true;
            this.groupControl_FastSerReport.Controls.Add(this.textEdit_EndDateReport);
            this.groupControl_FastSerReport.Controls.Add(this.textEdit_BegDateReport);
            this.groupControl_FastSerReport.Controls.Add(this.textEdit_NumberReport);
            this.groupControl_FastSerReport.Controls.Add(this.textEdit_NameReport);
            this.groupControl_FastSerReport.Controls.Add(this.notePanel_NumberReport);
            this.groupControl_FastSerReport.Controls.Add(this.notePanel_NameReport);
            this.groupControl_FastSerReport.Controls.Add(this.comboBoxEdit_PrintType);
            this.groupControl_FastSerReport.Controls.Add(this.notePanel_PrintType);
            this.groupControl_FastSerReport.Controls.Add(this.notePanel_EndDateReport);
            this.groupControl_FastSerReport.Controls.Add(this.notePanel_BegDateReport);
            this.groupControl_FastSerReport.Controls.Add(this.comboBoxEdit_ClassReport);
            this.groupControl_FastSerReport.Controls.Add(this.notePanel_ClassReport);
            this.groupControl_FastSerReport.Controls.Add(this.comboBoxEdit_GradeReport);
            this.groupControl_FastSerReport.Controls.Add(this.notePanel_GradeReport);
            this.groupControl_FastSerReport.Controls.Add(this.notePanel_SerCondReport);
            this.groupControl_FastSerReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl_FastSerReport.Location = new System.Drawing.Point(0, 0);
            this.groupControl_FastSerReport.Name = "groupControl_FastSerReport";
            this.groupControl_FastSerReport.Size = new System.Drawing.Size(233, 304);
            this.groupControl_FastSerReport.TabIndex = 8;
            this.groupControl_FastSerReport.Text = "快速搜索";
            // 
            // textEdit_EndDateReport
            // 
            this.textEdit_EndDateReport.EditValue = "";
            this.textEdit_EndDateReport.Location = new System.Drawing.Point(104, 224);
            this.textEdit_EndDateReport.Name = "textEdit_EndDateReport";
            this.textEdit_EndDateReport.Properties.DisplayFormat.FormatString = "d";
            this.textEdit_EndDateReport.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.textEdit_EndDateReport.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.textEdit_EndDateReport.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.textEdit_EndDateReport.Size = new System.Drawing.Size(88, 20);
            this.textEdit_EndDateReport.TabIndex = 21;
            // 
            // textEdit_BegDateReport
            // 
            this.textEdit_BegDateReport.EditValue = "";
            this.textEdit_BegDateReport.Location = new System.Drawing.Point(104, 192);
            this.textEdit_BegDateReport.Name = "textEdit_BegDateReport";
            this.textEdit_BegDateReport.Properties.DisplayFormat.FormatString = "d";
            this.textEdit_BegDateReport.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.textEdit_BegDateReport.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.textEdit_BegDateReport.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.textEdit_BegDateReport.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.textEdit_BegDateReport.Size = new System.Drawing.Size(88, 20);
            this.textEdit_BegDateReport.TabIndex = 20;
            // 
            // textEdit_NumberReport
            // 
            this.textEdit_NumberReport.EditValue = "";
            this.textEdit_NumberReport.Location = new System.Drawing.Point(104, 160);
            this.textEdit_NumberReport.Name = "textEdit_NumberReport";
            this.textEdit_NumberReport.Size = new System.Drawing.Size(88, 20);
            this.textEdit_NumberReport.TabIndex = 19;
            // 
            // textEdit_NameReport
            // 
            this.textEdit_NameReport.EditValue = "";
            this.textEdit_NameReport.Location = new System.Drawing.Point(104, 128);
            this.textEdit_NameReport.Name = "textEdit_NameReport";
            this.textEdit_NameReport.Size = new System.Drawing.Size(88, 20);
            this.textEdit_NameReport.TabIndex = 18;
            // 
            // notePanel_NumberReport
            // 
            this.notePanel_NumberReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_NumberReport.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_NumberReport.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_NumberReport.ForeColor = System.Drawing.Color.Black;
            this.notePanel_NumberReport.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_NumberReport.Location = new System.Drawing.Point(16, 160);
            this.notePanel_NumberReport.MaxRows = 5;
            this.notePanel_NumberReport.Name = "notePanel_NumberReport";
            this.notePanel_NumberReport.ParentAutoHeight = true;
            this.notePanel_NumberReport.Size = new System.Drawing.Size(80, 22);
            this.notePanel_NumberReport.TabIndex = 17;
            this.notePanel_NumberReport.TabStop = false;
            this.notePanel_NumberReport.Text = "  学  号:    ";
            // 
            // notePanel_NameReport
            // 
            this.notePanel_NameReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_NameReport.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_NameReport.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_NameReport.ForeColor = System.Drawing.Color.Black;
            this.notePanel_NameReport.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_NameReport.Location = new System.Drawing.Point(16, 128);
            this.notePanel_NameReport.MaxRows = 5;
            this.notePanel_NameReport.Name = "notePanel_NameReport";
            this.notePanel_NameReport.ParentAutoHeight = true;
            this.notePanel_NameReport.Size = new System.Drawing.Size(80, 22);
            this.notePanel_NameReport.TabIndex = 16;
            this.notePanel_NameReport.TabStop = false;
            this.notePanel_NameReport.Text = "  姓  名:    ";
            // 
            // comboBoxEdit_PrintType
            // 
            this.comboBoxEdit_PrintType.EditValue = "年班统计表";
            this.comboBoxEdit_PrintType.Location = new System.Drawing.Point(104, 256);
            this.comboBoxEdit_PrintType.Name = "comboBoxEdit_PrintType";
            this.comboBoxEdit_PrintType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_PrintType.Properties.Items.AddRange(new object[] {
            "年班统计表",
            "年班柱图表",
            "年班饼图表",
            "个人统计表",
            "个人详细表"});
            this.comboBoxEdit_PrintType.Size = new System.Drawing.Size(88, 20);
            this.comboBoxEdit_PrintType.TabIndex = 15;
            // 
            // notePanel_PrintType
            // 
            this.notePanel_PrintType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_PrintType.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_PrintType.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_PrintType.ForeColor = System.Drawing.Color.Black;
            this.notePanel_PrintType.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_PrintType.Location = new System.Drawing.Point(16, 256);
            this.notePanel_PrintType.MaxRows = 5;
            this.notePanel_PrintType.Name = "notePanel_PrintType";
            this.notePanel_PrintType.ParentAutoHeight = true;
            this.notePanel_PrintType.Size = new System.Drawing.Size(80, 22);
            this.notePanel_PrintType.TabIndex = 14;
            this.notePanel_PrintType.TabStop = false;
            this.notePanel_PrintType.Text = "报表类型:    ";
            // 
            // notePanel_EndDateReport
            // 
            this.notePanel_EndDateReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_EndDateReport.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_EndDateReport.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_EndDateReport.ForeColor = System.Drawing.Color.Black;
            this.notePanel_EndDateReport.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_EndDateReport.Location = new System.Drawing.Point(16, 224);
            this.notePanel_EndDateReport.MaxRows = 5;
            this.notePanel_EndDateReport.Name = "notePanel_EndDateReport";
            this.notePanel_EndDateReport.ParentAutoHeight = true;
            this.notePanel_EndDateReport.Size = new System.Drawing.Size(80, 22);
            this.notePanel_EndDateReport.TabIndex = 11;
            this.notePanel_EndDateReport.TabStop = false;
            this.notePanel_EndDateReport.Text = "结束时间:    ";
            // 
            // notePanel_BegDateReport
            // 
            this.notePanel_BegDateReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_BegDateReport.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_BegDateReport.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_BegDateReport.ForeColor = System.Drawing.Color.Black;
            this.notePanel_BegDateReport.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_BegDateReport.Location = new System.Drawing.Point(16, 192);
            this.notePanel_BegDateReport.MaxRows = 5;
            this.notePanel_BegDateReport.Name = "notePanel_BegDateReport";
            this.notePanel_BegDateReport.ParentAutoHeight = true;
            this.notePanel_BegDateReport.Size = new System.Drawing.Size(80, 22);
            this.notePanel_BegDateReport.TabIndex = 10;
            this.notePanel_BegDateReport.TabStop = false;
            this.notePanel_BegDateReport.Text = "开始时间:    ";
            // 
            // comboBoxEdit_ClassReport
            // 
            this.comboBoxEdit_ClassReport.EditValue = "全部";
            this.comboBoxEdit_ClassReport.Location = new System.Drawing.Point(104, 96);
            this.comboBoxEdit_ClassReport.Name = "comboBoxEdit_ClassReport";
            this.comboBoxEdit_ClassReport.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_ClassReport.Properties.Items.AddRange(new object[] {
            "全部"});
            this.comboBoxEdit_ClassReport.Size = new System.Drawing.Size(88, 20);
            this.comboBoxEdit_ClassReport.TabIndex = 9;
            this.comboBoxEdit_ClassReport.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_ClassReport_SelectedIndexChanged);
            // 
            // notePanel_ClassReport
            // 
            this.notePanel_ClassReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_ClassReport.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_ClassReport.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_ClassReport.ForeColor = System.Drawing.Color.Black;
            this.notePanel_ClassReport.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_ClassReport.Location = new System.Drawing.Point(16, 97);
            this.notePanel_ClassReport.MaxRows = 5;
            this.notePanel_ClassReport.Name = "notePanel_ClassReport";
            this.notePanel_ClassReport.ParentAutoHeight = true;
            this.notePanel_ClassReport.Size = new System.Drawing.Size(80, 22);
            this.notePanel_ClassReport.TabIndex = 8;
            this.notePanel_ClassReport.TabStop = false;
            this.notePanel_ClassReport.Text = "  班  级:    ";
            // 
            // comboBoxEdit_GradeReport
            // 
            this.comboBoxEdit_GradeReport.EditValue = "全部";
            this.comboBoxEdit_GradeReport.Location = new System.Drawing.Point(104, 64);
            this.comboBoxEdit_GradeReport.Name = "comboBoxEdit_GradeReport";
            this.comboBoxEdit_GradeReport.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_GradeReport.Properties.Items.AddRange(new object[] {
            "全部"});
            this.comboBoxEdit_GradeReport.Size = new System.Drawing.Size(88, 20);
            this.comboBoxEdit_GradeReport.TabIndex = 7;
            this.comboBoxEdit_GradeReport.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_GradeReport_SelectedIndexChanged);
            // 
            // notePanel_GradeReport
            // 
            this.notePanel_GradeReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_GradeReport.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_GradeReport.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_GradeReport.ForeColor = System.Drawing.Color.Black;
            this.notePanel_GradeReport.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_GradeReport.Location = new System.Drawing.Point(16, 64);
            this.notePanel_GradeReport.MaxRows = 5;
            this.notePanel_GradeReport.Name = "notePanel_GradeReport";
            this.notePanel_GradeReport.ParentAutoHeight = true;
            this.notePanel_GradeReport.Size = new System.Drawing.Size(80, 22);
            this.notePanel_GradeReport.TabIndex = 6;
            this.notePanel_GradeReport.TabStop = false;
            this.notePanel_GradeReport.Text = "  年  级:    ";
            // 
            // notePanel_SerCondReport
            // 
            this.notePanel_SerCondReport.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.notePanel_SerCondReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.notePanel_SerCondReport.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notePanel_SerCondReport.ForeColor = System.Drawing.Color.OrangeRed;
            this.notePanel_SerCondReport.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_SerCondReport.Location = new System.Drawing.Point(2, 22);
            this.notePanel_SerCondReport.MaxRows = 5;
            this.notePanel_SerCondReport.Name = "notePanel_SerCondReport";
            this.notePanel_SerCondReport.ParentAutoHeight = true;
            this.notePanel_SerCondReport.Size = new System.Drawing.Size(229, 23);
            this.notePanel_SerCondReport.TabIndex = 5;
            this.notePanel_SerCondReport.TabStop = false;
            this.notePanel_SerCondReport.Text = "您要搜索的条件？";
            // 
            // groupControl_PreviewReport
            // 
            this.groupControl_PreviewReport.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_PreviewReport.Appearance.Options.UseFont = true;
            this.groupControl_PreviewReport.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_PreviewReport.AppearanceCaption.Options.UseFont = true;
            this.groupControl_PreviewReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl_PreviewReport.Location = new System.Drawing.Point(0, 48);
            this.groupControl_PreviewReport.Name = "groupControl_PreviewReport";
            this.groupControl_PreviewReport.Size = new System.Drawing.Size(528, 463);
            this.groupControl_PreviewReport.TabIndex = 1;
            this.groupControl_PreviewReport.Text = "图形报表预览";
            this.groupControl_PreviewReport.Resize += new System.EventHandler(this.groupControl_PreviewReport_Resize);
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.simpleButton_PrintReport);
            this.panelControl4.Controls.Add(this.simpleButton_PreviewReport);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl4.Location = new System.Drawing.Point(0, 0);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(528, 48);
            this.panelControl4.TabIndex = 0;
            // 
            // simpleButton_PrintReport
            // 
            this.simpleButton_PrintReport.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_PrintReport.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
            this.simpleButton_PrintReport.Appearance.Options.UseFont = true;
            this.simpleButton_PrintReport.Appearance.Options.UseForeColor = true;
            this.simpleButton_PrintReport.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_PrintReport.Image")));
            this.simpleButton_PrintReport.Location = new System.Drawing.Point(112, 8);
            this.simpleButton_PrintReport.Name = "simpleButton_PrintReport";
            this.simpleButton_PrintReport.Size = new System.Drawing.Size(120, 26);
            this.simpleButton_PrintReport.TabIndex = 4;
            this.simpleButton_PrintReport.Tag = 4;
            this.simpleButton_PrintReport.Text = "图形报表打印";
            this.simpleButton_PrintReport.Click += new System.EventHandler(this.simpleButton_PrintReport_Click);
            // 
            // simpleButton_PreviewReport
            // 
            this.simpleButton_PreviewReport.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_PreviewReport.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
            this.simpleButton_PreviewReport.Appearance.Options.UseFont = true;
            this.simpleButton_PreviewReport.Appearance.Options.UseForeColor = true;
            this.simpleButton_PreviewReport.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_PreviewReport.Image")));
            this.simpleButton_PreviewReport.Location = new System.Drawing.Point(8, 8);
            this.simpleButton_PreviewReport.Name = "simpleButton_PreviewReport";
            this.simpleButton_PreviewReport.Size = new System.Drawing.Size(96, 26);
            this.simpleButton_PreviewReport.TabIndex = 3;
            this.simpleButton_PreviewReport.Tag = 4;
            this.simpleButton_PreviewReport.Text = "报表预览";
            this.simpleButton_PreviewReport.Click += new System.EventHandler(this.simpleButton_PreviewReport_Click);
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.panel1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(766, 511);
            this.xtraTabPage1.Text = "成长记录报表";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(766, 511);
            this.panel1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 31);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(766, 480);
            this.treeView1.TabIndex = 1;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.simpleButton1);
            this.panel2.Controls.Add(this.checkedComboBoxEdit1);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(766, 31);
            this.panel2.TabIndex = 0;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(547, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "生成报表";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // checkedComboBoxEdit1
            // 
            this.checkedComboBoxEdit1.EditValue = "";
            this.checkedComboBoxEdit1.Location = new System.Drawing.Point(470, 6);
            this.checkedComboBoxEdit1.Name = "checkedComboBoxEdit1";
            this.checkedComboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedComboBoxEdit1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("1月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("2月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("3月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("4月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("5月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("6月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("7月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("8月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("9月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("10月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("11月"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("12月")});
            this.checkedComboBoxEdit1.Size = new System.Drawing.Size(71, 20);
            this.checkedComboBoxEdit1.TabIndex = 3;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "2014年",
            "2015年",
            "2016年",
            "2017年",
            "2018年",
            "2019年",
            "2020年"});
            this.comboBox1.Location = new System.Drawing.Point(325, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(139, 20);
            this.comboBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(628, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(316, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // StudentMorningCheckInfo
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.xtraTabControl_CheckInfo);
            this.Name = "StudentMorningCheckInfo";
            this.Size = new System.Drawing.Size(772, 540);
            this.Load += new System.EventHandler(this.StudentMorningCheckInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_CheckInfo)).EndInit();
            this.xtraTabControl_CheckInfo.ResumeLayout(false);
            this.xtraTabPage_MorningCheck.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_InfoStaticMornig)).EndInit();
            this.groupControl_InfoStaticMornig.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_HaveArr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_DayAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_ShouldArr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Watch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Ill.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Absence.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Health.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_CurRecTimeBinding.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_OrigStateBinding.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_FastSerMorning)).EndInit();
            this.groupControl_FastSerMorning.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_TimeStatusMorning)).EndInit();
            this.groupControl_TimeStatusMorning.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_SpecificDateMorning.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_SpecificDateMorning.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_EndTimeMorning.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_BegTimeMorning.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_TimeModeMorning.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Status.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_NumberNameMorning)).EndInit();
            this.groupControl_NumberNameMorning.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_NumberMorning.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_NameMorning.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_GradeClassMorning)).EndInit();
            this.groupControl_GradeClassMorning.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_ClassMorning.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_GradeMorning.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_MorningInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox_Status)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.xtraTabPage_BackHomeCheck.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_ShouldGo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_HasnotGone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_HasGone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_FastSerBack)).EndInit();
            this.groupControl_FastSerBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_TimeCondBack)).EndInit();
            this.groupControl_TimeCondBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_SpecificDateBack.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_SpecificDateBack.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_TimeModeBack.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_EndTimeBack.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_BegTimeBack.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_BackCond.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_NumberNameBack)).EndInit();
            this.groupControl_NumberNameBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_NameBack.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_NumberBack.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_GradeClassBack)).EndInit();
            this.groupControl_GradeClassBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_ClassBack.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_GradeBack.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_BackInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.xtraTabPage_FreeDefinition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).EndInit();
            this.splitContainerControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_FastSerFreeDef)).EndInit();
            this.groupControl_FastSerFreeDef.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_TimeStatusFreeDef)).EndInit();
            this.groupControl_TimeStatusFreeDef.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_SpecificDateFreeDef.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_SpecificDateFreeDef.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_TimeModeFreeDef.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_EndTimeFreeDef.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_BegTimeFreeDef.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_CustomStatusDef.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_NumberNameFreeDef)).EndInit();
            this.groupControl_NumberNameFreeDef.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_NameFreeDef.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_NumberFreeDef.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_GradeClassFreeDef)).EndInit();
            this.groupControl_GradeClassFreeDef.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_ClassFreeDef.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_GradeFreeDef.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_FreeDef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox_CustomState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.xtraTabPage_MoreReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl4)).EndInit();
            this.splitContainerControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_FastSerReport)).EndInit();
            this.groupControl_FastSerReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_EndDateReport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_BegDateReport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_NumberReport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_NameReport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_PrintType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_ClassReport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_GradeReport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_PreviewReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region 更换查询面板
		private void notePanel_GradeClass_Click_1(object sender, System.EventArgs e)
		{
			this.groupControl_GradeClassMorning.Visible = true;
			this.groupControl_NumberNameMorning.Visible = false;
			this.groupControl_TimeStatusMorning.Visible = false;
			
			this.notePanel_GradeClassMorning.BackColor = System.Drawing.Color.Azure;
			this.notePanel_GradeClassMorning.BackColor2 = System.Drawing.Color.DarkViolet;
			
			this.notePanel_NumberNameMorning.BackColor = System.Drawing.Color.LawnGreen;
			this.notePanel_NumberNameMorning.BackColor2 = System.Drawing.Color.DarkGray;

			this.notePanel_TimeStatusMorning.BackColor = System.Drawing.Color.LawnGreen;
			this.notePanel_TimeStatusMorning.BackColor2 = System.Drawing.Color.DarkGray;
		}

		private void notePanel_NumberName_Click_1(object sender, System.EventArgs e)
		{
			this.groupControl_NumberNameMorning.Visible = true;
			this.groupControl_GradeClassMorning.Visible = false;
			this.groupControl_TimeStatusMorning.Visible = false;

			this.notePanel_NumberNameMorning.BackColor = System.Drawing.Color.Azure;
			this.notePanel_NumberNameMorning.BackColor2 = System.Drawing.Color.DarkViolet;
			
			this.notePanel_GradeClassMorning.BackColor = System.Drawing.Color.LawnGreen;
			this.notePanel_GradeClassMorning.BackColor2 = System.Drawing.Color.DarkGray;

			this.notePanel_TimeStatusMorning.BackColor = System.Drawing.Color.LawnGreen;
			this.notePanel_TimeStatusMorning.BackColor2 = System.Drawing.Color.DarkGray;

		}

		private void notePanel_TimeStatus_Click_1(object sender, System.EventArgs e)
		{
			this.groupControl_TimeStatusMorning.Visible = true;
			this.groupControl_GradeClassMorning.Visible = false;
			this.groupControl_NumberNameMorning.Visible = false;

			this.notePanel_TimeStatusMorning.BackColor = System.Drawing.Color.Azure;
			this.notePanel_TimeStatusMorning.BackColor2 = System.Drawing.Color.DarkViolet;
			
			this.notePanel_GradeClassMorning.BackColor = System.Drawing.Color.LawnGreen;
			this.notePanel_GradeClassMorning.BackColor2 = System.Drawing.Color.DarkGray;

			this.notePanel_NumberNameMorning.BackColor = System.Drawing.Color.LawnGreen;
			this.notePanel_NumberNameMorning.BackColor2 = System.Drawing.Color.DarkGray;
	
		}

		private void notePanel_GradeClassBack_Click(object sender, System.EventArgs e)
		{
			this.groupControl_GradeClassBack.Visible = true;
			this.groupControl_NumberNameBack.Visible = false;
			this.groupControl_TimeCondBack.Visible = false;

			this.notePanel_GradeClassBack.BackColor = System.Drawing.Color.Azure;
			this.notePanel_GradeClassBack.BackColor2 = System.Drawing.Color.DarkViolet;

			this.notePanel_NumberNameBack.BackColor = System.Drawing.Color.Yellow;
			this.notePanel_NumberNameBack.BackColor2 = System.Drawing.Color.DarkGray;

			this.notePanel_TimeConBack.BackColor = System.Drawing.Color.Yellow;
			this.notePanel_TimeConBack.BackColor2 = System.Drawing.Color.DarkGray;
		}

		private void notePanel_NumberNameBack_Click(object sender, System.EventArgs e)
		{
			this.groupControl_NumberNameBack.Visible = true;
			this.groupControl_GradeClassBack.Visible = false;
			this.groupControl_TimeCondBack.Visible = false;

			this.notePanel_NumberNameBack.BackColor = System.Drawing.Color.Azure;
			this.notePanel_NumberNameBack.BackColor2 = System.Drawing.Color.DarkViolet;

			this.notePanel_GradeClassBack.BackColor = System.Drawing.Color.Yellow;
			this.notePanel_GradeClassBack.BackColor2 = System.Drawing.Color.DarkGray;
			
			this.notePanel_TimeConBack.BackColor = System.Drawing.Color.Yellow;
			this.notePanel_TimeConBack.BackColor2 = System.Drawing.Color.DarkGray;

		}

		private void notePanel_TimeConBack_Click(object sender, System.EventArgs e)
		{
			this.groupControl_TimeCondBack.Visible = true;
			this.groupControl_GradeClassBack.Visible = false;
			this.groupControl_NumberNameBack.Visible = false;
			
			this.notePanel_TimeConBack.BackColor = System.Drawing.Color.Azure;
			this.notePanel_TimeConBack.BackColor2 = System.Drawing.Color.DarkViolet;

			this.notePanel_GradeClassBack.BackColor = System.Drawing.Color.Yellow;
			this.notePanel_GradeClassBack.BackColor2 = System.Drawing.Color.DarkGray;

			this.notePanel_NumberNameBack.BackColor = System.Drawing.Color.Yellow;
			this.notePanel_NumberNameBack.BackColor2 = System.Drawing.Color.DarkGray;

		}

		private void notePanel_GradeClassFreeDef_Click(object sender, System.EventArgs e)
		{
			this.groupControl_GradeClassFreeDef.Visible = true;
			this.groupControl_NumberNameFreeDef.Visible = false;
			this.groupControl_TimeStatusFreeDef.Visible = false;

			this.notePanel_GradeClassFreeDef.BackColor = System.Drawing.Color.Azure;
			this.notePanel_GradeClassFreeDef.BackColor2 = System.Drawing.Color.DarkViolet;

			this.notePanel_NumberNameFreeDef.BackColor = System.Drawing.Color.LightGray;
			this.notePanel_NumberNameFreeDef.BackColor2 = System.Drawing.Color.DarkGray;

			this.notePanel_TimeStatusFreeDef.BackColor = System.Drawing.Color.LightGray;
			this.notePanel_TimeStatusFreeDef.BackColor2 = System.Drawing.Color.DarkGray;
		}

		private void notePanel_NumberNameFreeDef_Click(object sender, System.EventArgs e)
		{
			this.groupControl_NumberNameFreeDef.Visible = true;
			this.groupControl_GradeClassFreeDef.Visible = false;
			this.groupControl_TimeStatusFreeDef.Visible = false;

			this.notePanel_NumberNameFreeDef.BackColor = System.Drawing.Color.Azure;
			this.notePanel_NumberNameFreeDef.BackColor2 = System.Drawing.Color.DarkViolet;

			this.notePanel_GradeClassFreeDef.BackColor = System.Drawing.Color.LightGray;
			this.notePanel_GradeClassFreeDef.BackColor2 = System.Drawing.Color.DarkGray;

			this.notePanel_TimeStatusFreeDef.BackColor = System.Drawing.Color.LightGray;
			this.notePanel_TimeStatusFreeDef.BackColor2 = System.Drawing.Color.DarkGray;
		}

		private void notePanel_TimeStatusFreeDef_Click(object sender, System.EventArgs e)
		{
			this.groupControl_TimeStatusFreeDef.Visible = true;
			this.groupControl_GradeClassFreeDef.Visible = false;
			this.groupControl_NumberNameFreeDef.Visible = false;
		
			this.notePanel_TimeStatusFreeDef.BackColor = System.Drawing.Color.Azure;
			this.notePanel_TimeStatusFreeDef.BackColor2 = System.Drawing.Color.DarkViolet;

			this.notePanel_GradeClassFreeDef.BackColor = System.Drawing.Color.LightGray;
			this.notePanel_GradeClassFreeDef.BackColor2 = System.Drawing.Color.DarkGray;

			this.notePanel_NumberNameFreeDef.BackColor = System.Drawing.Color.LightGray;
			this.notePanel_NumberNameFreeDef.BackColor2 = System.Drawing.Color.DarkGray;
		}

		#endregion

		#region 窗体加载时，数据初始化
		private void StudentMorningCheckInfo_Load(object sender, System.EventArgs e)
		{
			textEdit_BegTimeMorning.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
			textEdit_EndTimeMorning.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
			dateEdit_SpecificDateMorning.EditValue = DateTime.Now.Date;
			//晨检年级处理
			foreach(DataRow getGradeList in getStuInfoByCondition.getGradeInfo("","").Tables[0].Rows)
			{
				comboBoxEdit_GradeMorning.Properties.Items.AddRange(
					new object[]{getGradeList[1].ToString()});
			}

			//晨检状态处理
			foreach(DataRow getStatusList in stuCheckInfo.GetStuStatusList().Tables[0].Rows)
			{
				comboBoxEdit_Status.Properties.Items.AddRange(new object[]{getStatusList[0].ToString()});
			}

			textEdit_BegTimeBack.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
			textEdit_EndTimeBack.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
			dateEdit_SpecificDateBack.EditValue = DateTime.Now.Date;
			//晚接年级处理
			foreach(DataRow getGradeList in getStuInfoByCondition.getGradeInfo("","").Tables[0].Rows)
			{
				comboBoxEdit_GradeBack.Properties.Items.AddRange(
					new object[]{getGradeList[1].ToString()});
			}

			textEdit_BegTimeFreeDef.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
			textEdit_EndTimeFreeDef.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
			dateEdit_SpecificDateFreeDef.EditValue = DateTime.Now.Date;
			//自定义年级处理
			foreach( DataRow getGradeList in getStuInfoByCondition.getGradeInfo("","").Tables[0].Rows )
			{
				comboBoxEdit_GradeFreeDef.Properties.Items.AddRange(
					new object[]{getGradeList[1].ToString()});
			}

			foreach( DataRow getGradeList in getStuInfoByCondition.getGradeInfo("","").Tables[0].Rows )
			{
				comboBoxEdit_GradeReport.Properties.Items.AddRange(
					new object[]{getGradeList[1].ToString()});
			}

			//自定义状态处理
			foreach(DataRow getCustomStatusList in stuCheckInfo.GetStuCustomStatusList().Tables[0].Rows)
			{
				comboBoxEdit_CustomStatusDef.Properties.Items.AddRange(
					new object[]{getCustomStatusList[0].ToString()});
				this.repositoryItemComboBox_CustomState.Items.AddRange(
					new object[]{getCustomStatusList[0].ToString()});
			}

			textEdit_BegDateReport.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
			textEdit_EndDateReport.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd");

			//一般教师，财务，创智管理员权限
			if ( Thread.CurrentPrincipal.Identity.Name.ToLower() == "admin" || Thread.CurrentPrincipal.IsInRole("一般"))
			{
				simpleButton_PreviewReport.Enabled = false;
				simpleButton_PrintBack.Enabled = false;
				simpleButton_PrintMorning.Enabled = false;
				simpleButton_PrintReport.Enabled = false;
				this.gridColumn6.OptionsColumn.AllowEdit = false;
			}	

			if ( Thread.CurrentPrincipal.IsInRole("财务") )
			{
				this.gridColumn6.OptionsColumn.AllowEdit = false;
			}

			if ( Thread.CurrentPrincipal.IsInRole("班主任") )
			{
				DataSet dsRolesDuty = rolesSystem.GetRolesDuty(Convert.ToInt32(Thread.CurrentPrincipal.Identity.Name));
				string gradeName = dsRolesDuty.Tables[0].Rows[0][0].ToString();
				string className = dsRolesDuty.Tables[0].Rows[0][1].ToString();

				comboBoxEdit_GradeReport.Properties.Items.Clear();
				comboBoxEdit_GradeReport.Properties.Items.AddRange(new object[]{gradeName});
				comboBoxEdit_GradeReport.SelectedItem = gradeName;
				comboBoxEdit_ClassReport.Properties.Items.Clear();
				comboBoxEdit_ClassReport.Properties.Items.AddRange(new object[]{className});
				comboBoxEdit_ClassReport.SelectedItem = className;
			}

	
			simpleButton_SearchMorning_Click(null,null);
			simpleButton_SearchBack_Click(null, null);
			simpleButton_SearchFreeDef_Click(null, null);

            this.context = SynchronizationContext.Current;

            OnGroupUpTabInilitized();
		}
		#endregion

		#region 处理晨检年级选择事件
		private void comboBoxEdit_GradeMorning_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			comboBoxEdit_ClassMorning.Properties.Items.Clear();
			comboBoxEdit_ClassMorning.Properties.Items.AddRange(new object[]{"全部"});
			comboBoxEdit_ClassMorning.SelectedItem = "全部";
			if ( getStuInfoByCondition.getGradeInfo(comboBoxEdit_GradeMorning.SelectedItem.ToString(),"").Tables[0].Rows.Count>0 )
			{
				getMorGradeNumberFromCombo = getStuInfoByCondition.getGradeInfo(
					comboBoxEdit_GradeMorning.SelectedItem.ToString(),"").Tables[0].Rows[0][0].ToString();
				foreach(DataRow getClassList in getStuInfoByCondition.getClassInfo("","",
					getMorGradeNumberFromCombo).Tables[0].Rows)
				{
					comboBoxEdit_ClassMorning.Properties.Items.AddRange(
						new object[]{getClassList[1].ToString()});
				}
			}

		}
		#endregion

		#region 处理晨检班级选择事件
		private void comboBoxEdit_ClassMorning_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(!comboBoxEdit_ClassMorning.SelectedItem.ToString().Equals("全部"))
				getMorClassNumberFromCombo = getStuInfoByCondition.getClassInfo(
					comboBoxEdit_ClassMorning.SelectedItem.ToString(),"","").Tables[0].Rows[0][0].ToString();
		}
		#endregion

		#region 晨检查询事件处理
		private void simpleButton_SearchMorning_Click(object sender, System.EventArgs e)
		{
			if ( !isFullDateMorning )
			{
				morBegDate = Convert.ToDateTime(textEdit_BegTimeMorning.EditValue).Date.ToString("yyyy-MM-dd");
				morEndDate = Convert.ToDateTime(textEdit_EndTimeMorning.EditValue).Date.ToString("yyyy-MM-dd");
			}
			else
			{
				morBegDate = dateEdit_SpecificDateMorning.DateTime.Date.ToString("yyyy-MM-dd") + " " + Convert.ToDateTime(textEdit_BegTimeMorning.EditValue).ToLongTimeString();
				morEndDate = dateEdit_SpecificDateMorning.DateTime.Date.ToString("yyyy-MM-dd") + " " + Convert.ToDateTime(textEdit_EndTimeMorning.EditValue).ToLongTimeString();
			}
			if ( Convert.ToDateTime(morBegDate) <= Convert.ToDateTime(morEndDate) )
			{
				try
				{
					//没有指定特定学生的情况
					if(textEdit_NameMorning.Text.Equals("")  && textEdit_NumberMorning.Text.Equals(""))
					{
						if(comboBoxEdit_GradeMorning.SelectedItem.ToString().Equals("全部"))
						{
							stuAttendCalc.GetStuAttendCalcForClass("","",morBegDate,morEndDate,"健康");
							textEdit_Health.Text = stuAttendCalc.GetHealthAttend(true);

							stuAttendCalc.GetStuAttendCalcForClass("","",morBegDate,morEndDate,"服药");
							textEdit_Ill.Text = stuAttendCalc.GetIllAttend(true);
			
							stuAttendCalc.GetStuAttendCalcForClass("","",morBegDate,morEndDate,"观察");
							textEdit_Watch.Text = stuAttendCalc.GetWatchAttend(true);

							textEdit_HaveArr.Text = stuAttendCalc.GetHaveAttended(true);
						
							textEdit_Absence.Text = stuAttendCalc.GetAbsence(true);

							textEdit_ShouldArr.Text = stuAttendCalc.GetShouldAttend(true);

							textEdit_DayAmount.Text = stuAttendCalc.GetDayAmount();

							gridControl_MorningInfo.DataSource = GetMorningCheckInfo("","","","",
								morBegDate,morEndDate,getMorningStateFromCombo).Tables[0];
						}
						else if(comboBoxEdit_ClassMorning.SelectedItem.ToString().Equals("全部"))
						{
							stuAttendCalc.GetStuAttendCalcForClass(getMorGradeNumberFromCombo,"",morBegDate,morEndDate,"健康");
							textEdit_Health.Text = stuAttendCalc.GetHealthAttend(true);

							stuAttendCalc.GetStuAttendCalcForClass(getMorGradeNumberFromCombo,"",morBegDate,morEndDate,"服药");
							textEdit_Ill.Text = stuAttendCalc.GetIllAttend(true);

							stuAttendCalc.GetStuAttendCalcForClass(getMorGradeNumberFromCombo,"",morBegDate,morEndDate,"观察");
							textEdit_Watch.Text = stuAttendCalc.GetWatchAttend(true);
							
							textEdit_HaveArr.Text = stuAttendCalc.GetHaveAttended(true);

							textEdit_Absence.Text = stuAttendCalc.GetAbsence(true);

							textEdit_ShouldArr.Text = stuAttendCalc.GetShouldAttend(true);

							textEdit_DayAmount.Text = stuAttendCalc.GetDayAmount();

							gridControl_MorningInfo.DataSource = GetMorningCheckInfo(getMorGradeNumberFromCombo,"","","",
								morBegDate,morEndDate,getMorningStateFromCombo).Tables[0];
						}
						else
						{
							stuAttendCalc.GetStuAttendCalcForClass(getMorGradeNumberFromCombo,getMorClassNumberFromCombo,
								morBegDate,morEndDate,"健康");
							textEdit_Health.Text = stuAttendCalc.GetHealthAttend(true);

							stuAttendCalc.GetStuAttendCalcForClass(getMorGradeNumberFromCombo,getMorClassNumberFromCombo,
								morBegDate,morEndDate,"服药");
							textEdit_Ill.Text = stuAttendCalc.GetIllAttend(true);

							stuAttendCalc.GetStuAttendCalcForClass(getMorGradeNumberFromCombo,getMorClassNumberFromCombo,
								morBegDate,morEndDate,"观察");
							textEdit_Watch.Text = stuAttendCalc.GetWatchAttend(true);

							textEdit_HaveArr.Text = stuAttendCalc.GetHaveAttended(true);

							textEdit_Absence.Text = stuAttendCalc.GetAbsence(true);

							textEdit_ShouldArr.Text = stuAttendCalc.GetShouldAttend(true);

							textEdit_DayAmount.Text = stuAttendCalc.GetDayAmount();

							gridControl_MorningInfo.DataSource = GetMorningCheckInfo(getMorGradeNumberFromCombo,
								getMorClassNumberFromCombo,"","",morBegDate,morEndDate,getMorningStateFromCombo).Tables[0];
						}
						
					}
					else
					{
						if ( textEdit_NumberMorning.Text.Equals("") )
						{
							stuAttendCalc.GetStuAttendCalcForSolo(textEdit_NameMorning.Text.Replace(" ",""),
								"",morBegDate,morEndDate,"健康");
							textEdit_Health.Text = stuAttendCalc.GetHealthAttend(false);

							stuAttendCalc.GetStuAttendCalcForSolo(textEdit_NameMorning.Text.Replace(" ",""),
								"",morBegDate,morEndDate,"服药");
							textEdit_Ill.Text = stuAttendCalc.GetIllAttend(false);

							stuAttendCalc.GetStuAttendCalcForSolo(textEdit_NameMorning.Text.Replace(" ",""),
								"",morBegDate,morEndDate,"观察");
							textEdit_Watch.Text = stuAttendCalc.GetWatchAttend(false);

							textEdit_HaveArr.Text = stuAttendCalc.GetHaveAttended(false);

							textEdit_Absence.Text = stuAttendCalc.GetAbsence(false);

							textEdit_ShouldArr.Text = stuAttendCalc.GetShouldAttend(false);

							textEdit_DayAmount.Text = stuAttendCalc.GetDayAmount();

							gridControl_MorningInfo.DataSource = GetMorningCheckInfo("","",
								textEdit_NameMorning.Text.Replace(" ",""),"",morBegDate,morEndDate,getMorningStateFromCombo).Tables[0];
						}
						else
						{
							stuAttendCalc.GetStuAttendCalcForSolo("",textEdit_NumberMorning.Text.Replace(" ",""),
								morBegDate,morEndDate,"健康");
							textEdit_Health.Text = stuAttendCalc.GetHealthAttend(false);

							stuAttendCalc.GetStuAttendCalcForSolo("",textEdit_NumberMorning.Text.Replace(" ",""),
								morBegDate,morEndDate,"服药");
							textEdit_Ill.Text = stuAttendCalc.GetIllAttend(false);

							stuAttendCalc.GetStuAttendCalcForSolo("",textEdit_NumberMorning.Text.Replace(" ",""),
								morBegDate,morEndDate,"观察");
							textEdit_Watch.Text = stuAttendCalc.GetWatchAttend(false);

							textEdit_HaveArr.Text = stuAttendCalc.GetHaveAttended(false);

							textEdit_Absence.Text = stuAttendCalc.GetAbsence(false);

							textEdit_ShouldArr.Text = stuAttendCalc.GetShouldAttend(false);

							textEdit_DayAmount.Text = stuAttendCalc.GetDayAmount();

							gridControl_MorningInfo.DataSource = GetMorningCheckInfo("","","",
								textEdit_NumberMorning.Text.Replace(" ",""),morBegDate,morEndDate,getMorningStateFromCombo).Tables[0];

							gridView1.RefreshData();
						}
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}   
			else
				MessageBox.Show("请选择正确的时间段！");
		}
		#endregion

		#region 晨检状态选择
		private void comboBoxEdit_Status_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( comboBoxEdit_Status.SelectedItem.ToString().Equals("全部") )
				getMorningStateFromCombo = "";
			else
				getMorningStateFromCombo = comboBoxEdit_Status.SelectedItem.ToString();
		}
		#endregion

		#region 晨检时间模式切换
		private void comboBoxEdit_TimeModeMorning_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( comboBoxEdit_TimeModeMorning.SelectedIndex == 0 )
			{
				textEdit_BegTimeMorning.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
				textEdit_BegTimeMorning.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
				textEdit_EndTimeMorning.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
				textEdit_EndTimeMorning.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
				textEdit_BegTimeMorning.Properties.Mask.EditMask = "yyyy-MM-dd";
				textEdit_BegTimeMorning.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
				textEdit_EndTimeMorning.Properties.Mask.EditMask = "yyyy-MM-dd";
				textEdit_EndTimeMorning.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
				dateEdit_SpecificDateMorning.Enabled = false;
				isFullDateMorning = false;
			}
			else
			{
				textEdit_BegTimeMorning.Properties.DisplayFormat.FormatString = "HH:mm:ss";
				textEdit_BegTimeMorning.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
				textEdit_EndTimeMorning.Properties.DisplayFormat.FormatString = "HH:mm:ss";
				textEdit_EndTimeMorning.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
				textEdit_BegTimeMorning.Properties.Mask.EditMask = "HH:mm:ss";
				textEdit_BegTimeMorning.EditValue = DateTime.Now.ToLongTimeString();
				textEdit_EndTimeMorning.Properties.Mask.EditMask = "HH:mm:ss";
				textEdit_EndTimeMorning.EditValue = DateTime.Now.ToLongTimeString();
				dateEdit_SpecificDateMorning.Enabled = true;
				isFullDateMorning = true;
			}
		}
		#endregion

		private DataSet GetMorningCheckInfo(string getGrade,string getClass,string getName,string getNumber,string getBegDate,string getEndDate,string getState)
		{
			dsMorningCheckInfo = stuCheckInfo.GetStuMorningCheckInfo(getGrade,getClass,getName,getNumber,getBegDate,getEndDate,getState);
			textEdit_CurRecTimeBinding.DataBindings.Clear();
			textEdit_OrigStateBinding.DataBindings.Clear();
			textEdit_CurRecTimeBinding.DataBindings.Add("EditValue",dsMorningCheckInfo.Tables[0],"flow_curRecTime");
			textEdit_OrigStateBinding.DataBindings.Add("EditValue",dsMorningCheckInfo.Tables[0],"state_flowStateName");
			return dsMorningCheckInfo;
		}

		#region 处理晚接年级选择事件
		private void comboBoxEdit_GradeBack_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			comboBoxEdit_ClassBack.Properties.Items.Clear();
			comboBoxEdit_ClassBack.Properties.Items.AddRange(new object[]{"全部"});
			comboBoxEdit_ClassBack.SelectedItem = "全部";
			if ( getStuInfoByCondition.getGradeInfo(comboBoxEdit_GradeBack.SelectedItem.ToString(),"").Tables[0].Rows.Count>0 )
			{
				getBackGradeNumberFromCombo = getStuInfoByCondition.getGradeInfo(
					comboBoxEdit_GradeBack.SelectedItem.ToString(),"").Tables[0].Rows[0][0].ToString();
				foreach(DataRow getClassList in getStuInfoByCondition.getClassInfo("","",
					getBackGradeNumberFromCombo).Tables[0].Rows)
				{
					comboBoxEdit_ClassBack.Properties.Items.AddRange(
						new object[]{getClassList[1].ToString()});
				}
			}
		}
		#endregion

		#region 处理晚接班级选择事件
		private void comboBoxEdit_ClassBack_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(!comboBoxEdit_ClassBack.SelectedItem.ToString().Equals("全部"))
				getBackClassNumberFromCombo = getStuInfoByCondition.getClassInfo(
					comboBoxEdit_ClassBack.SelectedItem.ToString(),"","").Tables[0].Rows[0][0].ToString();
		}
		#endregion

		#region 晚接查询事件处理
		private void simpleButton_SearchBack_Click(object sender, System.EventArgs e)
		{
			if ( !isFullDateBack )
			{
				backBegDate = Convert.ToDateTime(textEdit_BegTimeBack.EditValue).Date.ToString("yyyy-MM-dd");
				backEndDate = Convert.ToDateTime(textEdit_EndTimeBack.EditValue).Date.ToString("yyyy-MM-dd");
			}
			else
			{
				backBegDate = dateEdit_SpecificDateBack.DateTime.Date.ToString("yyyy-MM-dd") + " " + Convert.ToDateTime(textEdit_BegTimeBack.EditValue).ToLongTimeString();
				backEndDate = dateEdit_SpecificDateBack.DateTime.Date.ToString("yyyy-MM-dd") + " " + Convert.ToDateTime(textEdit_EndTimeBack.EditValue).ToLongTimeString();
			}
			if ( Convert.ToDateTime(backBegDate) <= Convert.ToDateTime(backEndDate) )
			{
				try
				{
					if( textEdit_NameBack.Text.Equals("") && textEdit_NumberBack.Text.Equals("") )
					{
						if(comboBoxEdit_GradeBack.SelectedItem.ToString().Equals("全部"))
						{
							stuAttendCalc.DoStuBackCalc("","","","",backBegDate,backEndDate);
							
							textEdit_HasGone.Text = stuAttendCalc.HasGoneNumber();
							textEdit_HasnotGone.Text = stuAttendCalc.HasnotGoneNumber();
							textEdit_ShouldGo.Text = stuAttendCalc.ShouldGo();

							gridControl_BackInfo.DataSource = GetBackCheckInfo("","",
								"","",backBegDate,backEndDate,getBackStateFromCombo).Tables[0];
						}

						else if( comboBoxEdit_ClassBack.SelectedItem.ToString().Equals("全部") )
						{

							stuAttendCalc.DoStuBackCalc(getBackGradeNumberFromCombo,"","","",backBegDate,backEndDate);
							
							textEdit_HasGone.Text = stuAttendCalc.HasGoneNumber();
							textEdit_HasnotGone.Text = stuAttendCalc.HasnotGoneNumber();
							textEdit_ShouldGo.Text = stuAttendCalc.ShouldGo();

							gridControl_BackInfo.DataSource = GetBackCheckInfo(getBackGradeNumberFromCombo,"",
								"","",backBegDate,backEndDate,getBackStateFromCombo).Tables[0];
						}

						else
						{
							stuAttendCalc.DoStuBackCalc(getBackGradeNumberFromCombo,getBackClassNumberFromCombo,"","",backBegDate,backEndDate);
							
							textEdit_HasGone.Text = stuAttendCalc.HasGoneNumber();
							textEdit_HasnotGone.Text = stuAttendCalc.HasnotGoneNumber();
							textEdit_ShouldGo.Text = stuAttendCalc.ShouldGo();

							gridControl_BackInfo.DataSource = GetBackCheckInfo(getBackGradeNumberFromCombo,
								getBackClassNumberFromCombo,"","",backBegDate,backEndDate,getBackStateFromCombo).Tables[0];
						}
					}

					else
					{
						if( textEdit_NumberBack.Text.Equals("") )
						{
							stuAttendCalc.DoStuBackCalc("","",textEdit_NameBack.Text.Replace(" ",""),"",backBegDate,backEndDate);
							
							textEdit_HasGone.Text = stuAttendCalc.HasGoneNumber();
							textEdit_HasnotGone.Text = stuAttendCalc.HasnotGoneNumber();
							textEdit_ShouldGo.Text = stuAttendCalc.ShouldGo();

								gridControl_BackInfo.DataSource = GetBackCheckInfo("","",textEdit_NameBack.Text.Replace(" ",""),
									"",backBegDate,backEndDate,getBackStateFromCombo).Tables[0];
						}
						else
						{
							stuAttendCalc.DoStuBackCalc("","","",textEdit_NumberBack.Text.Replace(" ",""),backBegDate,backEndDate);
							
							textEdit_HasGone.Text = stuAttendCalc.HasGoneNumber();
							textEdit_HasnotGone.Text = stuAttendCalc.HasnotGoneNumber();
							textEdit_ShouldGo.Text = stuAttendCalc.ShouldGo();

							gridControl_BackInfo.DataSource = GetBackCheckInfo("","","",textEdit_NumberBack.Text.Replace(" ",""),
								backBegDate,backEndDate,getBackStateFromCombo).Tables[0];
						}
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
			else
				MessageBox.Show("请选择正确的时间段！");
		}
		#endregion

		#region 晚接状态选择
		private void comboBoxEdit_BackCond_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			getBackStateFromCombo = comboBoxEdit_BackCond.SelectedItem.ToString();
		}
		#endregion

		#region 晚接时间模式切换
		private void comboBoxEdit_TimeModeBack_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( comboBoxEdit_TimeModeBack.SelectedIndex == 0 )
			{
				textEdit_BegTimeBack.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
				textEdit_BegTimeBack.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
				textEdit_EndTimeBack.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
				textEdit_EndTimeBack.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
				textEdit_BegTimeBack.Properties.Mask.EditMask = "yyyy-MM-dd";
				textEdit_BegTimeBack.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
				textEdit_EndTimeBack.Properties.Mask.EditMask = "yyyy-MM-dd";
				textEdit_EndTimeBack.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
				dateEdit_SpecificDateBack.Enabled = false;
				isFullDateBack = false;
			}
			else
			{
				textEdit_BegTimeBack.Properties.DisplayFormat.FormatString = "HH:mm:ss";
				textEdit_BegTimeBack.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
				textEdit_EndTimeBack.Properties.DisplayFormat.FormatString = "HH:mm:ss";
				textEdit_EndTimeBack.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
				textEdit_BegTimeBack.Properties.Mask.EditMask = "HH:mm:ss";
				textEdit_BegTimeBack.EditValue = DateTime.Now.ToLongTimeString();
				textEdit_EndTimeBack.Properties.Mask.EditMask = "HH:mm:ss";
				textEdit_EndTimeBack.EditValue = DateTime.Now.ToLongTimeString();
				dateEdit_SpecificDateBack.Enabled = true;
				isFullDateBack = true;
			}
		}
		#endregion

		private DataSet GetBackCheckInfo(string getGrade,string getClass,string getName,string getNumber,string getBegDate,string getEndDate,string getState)
		{
			dsBackCheckInfo = stuCheckInfo.GetStuBackHomeCheckInfo(getGrade,getClass,getName,getNumber,getBegDate,getEndDate,getState);
			
			return dsBackCheckInfo;
		}

		#region 处理自定义年级选择事件
		private void comboBoxEdit_GradeFreeDef_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			comboBoxEdit_ClassFreeDef.Properties.Items.Clear();
			comboBoxEdit_ClassFreeDef.Properties.Items.AddRange(new object[]{"全部"});
			comboBoxEdit_ClassFreeDef.SelectedItem = "全部";
			if ( getStuInfoByCondition.getGradeInfo(comboBoxEdit_GradeFreeDef.SelectedItem.ToString(),"").Tables[0].Rows.Count>0 )
			{
				getCustomGradeNumberFromCombo = getStuInfoByCondition.getGradeInfo(
					comboBoxEdit_GradeFreeDef.SelectedItem.ToString(),"").Tables[0].Rows[0][0].ToString();
				foreach(DataRow getClassList in getStuInfoByCondition.getClassInfo("","",
					getCustomGradeNumberFromCombo).Tables[0].Rows)
				{
					comboBoxEdit_ClassFreeDef.Properties.Items.AddRange(
						new object[]{getClassList[1].ToString()});
				}
			}
		}
		#endregion

		#region 处理自定义班级选择事件
		private void comboBoxEdit_ClassFreeDef_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(!comboBoxEdit_ClassFreeDef.SelectedItem.ToString().Equals("全部"))
				getCustomClassNumberFromCombo = getStuInfoByCondition.getClassInfo(
					comboBoxEdit_ClassFreeDef.SelectedItem.ToString(),"","").Tables[0].Rows[0][0].ToString();
		}
		#endregion

		#region 处理打印年级选择事件
		private void comboBoxEdit_GradeReport_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			comboBoxEdit_ClassReport.Properties.Items.Clear();
			comboBoxEdit_ClassReport.Properties.Items.AddRange(new object[]{"全部"});
			comboBoxEdit_ClassReport.SelectedItem = "全部";
			if ( getStuInfoByCondition.getGradeInfo(comboBoxEdit_GradeReport.SelectedItem.ToString(),"").Tables[0].Rows.Count>0 )
			{
				getRepGradeNumberFromCombo = getStuInfoByCondition.getGradeInfo(
					comboBoxEdit_GradeReport.SelectedItem.ToString(),"").Tables[0].Rows[0][0].ToString();
				foreach(DataRow getClassList in getStuInfoByCondition.getClassInfo("","",
					getRepGradeNumberFromCombo).Tables[0].Rows)
				{
					comboBoxEdit_ClassReport.Properties.Items.AddRange(
						new object[]{getClassList[1].ToString()});
				}
			}
		}
		#endregion

		#region 处理打印班级选择时间
		private void comboBoxEdit_ClassReport_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(!comboBoxEdit_ClassReport.SelectedItem.ToString().Equals("全部"))
				getRepClassNumberFromCombo = getStuInfoByCondition.getClassInfo(
					comboBoxEdit_ClassReport.SelectedItem.ToString(),"","").Tables[0].Rows[0][0].ToString();
		}
		#endregion

		#region 自定义查询事件处理
		private void simpleButton_SearchFreeDef_Click(object sender, System.EventArgs e)
		{
			if ( !isFullDateFreeDef )
			{
				freeDefBegDate = Convert.ToDateTime(textEdit_BegTimeFreeDef.EditValue).Date.ToString("yyyy-MM-dd");
				freeDefEndDate = Convert.ToDateTime(textEdit_EndTimeFreeDef.EditValue).Date.ToString("yyyy-MM-dd");
			}
			else
			{
				freeDefBegDate = dateEdit_SpecificDateFreeDef.DateTime.Date.ToString("yyyy-MM-dd") + " " + Convert.ToDateTime(textEdit_BegTimeFreeDef.EditValue).ToLongTimeString();
				freeDefEndDate = dateEdit_SpecificDateFreeDef.DateTime.Date.ToString("yyyy-MM-dd") + " " + Convert.ToDateTime(textEdit_EndTimeFreeDef.EditValue).ToLongTimeString();
			}
			if ( Convert.ToDateTime(freeDefBegDate) <= Convert.ToDateTime(freeDefEndDate) )
			{
				try
				{
					if( textEdit_NameFreeDef.Text.Equals("") && textEdit_NumberFreeDef.Text.Equals("") )
					{
						if(comboBoxEdit_GradeFreeDef.SelectedItem.ToString().Equals("全部"))
						{
							gridControl_FreeDef.DataSource = stuCheckInfo.GetStuCustomCheckInfo("","",
								"","",freeDefBegDate,freeDefEndDate,getCustomStateFromCombo).Tables[0];
						}

						else if( comboBoxEdit_ClassFreeDef.SelectedItem.ToString().Equals("全部") )
						{
							gridControl_FreeDef.DataSource = stuCheckInfo.GetStuCustomCheckInfo(getCustomGradeNumberFromCombo,"",
								"","",freeDefBegDate,freeDefEndDate,getCustomStateFromCombo).Tables[0];
						}

						else
						{
							gridControl_FreeDef.DataSource = stuCheckInfo.GetStuCustomCheckInfo(getCustomGradeNumberFromCombo,
								getCustomClassNumberFromCombo,"","",freeDefBegDate,freeDefEndDate,getCustomStateFromCombo).Tables[0];
						}
					}

					else
					{
						if( textEdit_NumberFreeDef.Text.Equals("") )
							gridControl_FreeDef.DataSource = stuCheckInfo.GetStuCustomCheckInfo("","",textEdit_NameFreeDef.Text.Replace(" ",""),
								"",freeDefBegDate,freeDefEndDate,getCustomStateFromCombo).Tables[0];
						else
							gridControl_FreeDef.DataSource = stuCheckInfo.GetStuCustomCheckInfo("","","",textEdit_NumberFreeDef.Text.Replace(" ",""),
								freeDefBegDate,freeDefEndDate,getCustomStateFromCombo).Tables[0];
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
			else
				MessageBox.Show("请选择正确的时间段！");
		}
		#endregion

		#region 自定义状态选择
		private void comboBoxEdit_CustomStatusDef_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( comboBoxEdit_CustomStatusDef.SelectedItem.ToString().Equals("全部"))
				getCustomStateFromCombo = "";
			else
				getCustomStateFromCombo = comboBoxEdit_CustomStatusDef.SelectedItem.ToString();
		}
		#endregion

		#region 自定义时间模式
		private void comboBoxEdit_TimeModeFreeDef_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( comboBoxEdit_TimeModeFreeDef.SelectedIndex == 0 )
			{
				textEdit_BegTimeFreeDef.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
				textEdit_BegTimeFreeDef.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
				textEdit_EndTimeFreeDef.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
				textEdit_EndTimeFreeDef.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
				textEdit_BegTimeFreeDef.Properties.Mask.EditMask = "yyyy-MM-dd";
				textEdit_BegTimeFreeDef.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
				textEdit_EndTimeFreeDef.Properties.Mask.EditMask = "yyyy-MM-dd";
				textEdit_EndTimeFreeDef.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
				dateEdit_SpecificDateFreeDef.Enabled = false;
				isFullDateFreeDef = false;
			}
			else
			{
				textEdit_BegTimeFreeDef.Properties.DisplayFormat.FormatString = "HH:mm:ss";
				textEdit_BegTimeFreeDef.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
				textEdit_EndTimeFreeDef.Properties.DisplayFormat.FormatString = "HH:mm:ss";
				textEdit_EndTimeFreeDef.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
				textEdit_BegTimeFreeDef.Properties.Mask.EditMask = "HH:mm:ss";
				textEdit_BegTimeFreeDef.EditValue = DateTime.Now.ToLongTimeString();
				textEdit_EndTimeFreeDef.Properties.Mask.EditMask = "HH:mm:ss";
				textEdit_EndTimeFreeDef.EditValue = DateTime.Now.ToLongTimeString();
				dateEdit_SpecificDateFreeDef.Enabled = true;
				isFullDateFreeDef = true;
			}
		}
		#endregion

		#region 更新晨检状态
		private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			if ( showUpdate )
			{
				if ( Thread.CurrentPrincipal.IsInRole("班主任") )
				{
					if ( !gridView1.GetDataRow(gridView1.GetSelectedRows()[0])[2].ToString().Equals(rolesSystem.GetRolesDuty(Convert.ToInt32(Thread.CurrentPrincipal.Identity.Name)).Tables[0].Rows[0][1]) )
					{
						showUpdate = false;
						MessageBox.Show("该幼儿不属于您的班级，更新状态失败！");
						gridView1.SetRowCellValue(gridView1.GetSelectedRows()[0],"state_flowStateName",getOrigState);	
						return;
					}
				}
				string message = "是否确认要更新晨检状态？";
				string caption = "消息提示框!";
				int getSelectedRow = gridView1.GetSelectedRows()[0];
				DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
				if ( messageResult == DialogResult.Yes )
				{
					// 获取选定行的学生学号
					string getStuNumber = gridView1.GetDataRow(gridView1.GetSelectedRows()[0])[1].ToString();
					// 获取选定行的学生出勤日期
					string getStuEnterDate = gridView1.GetDataRow(gridView1.GetSelectedRows()[0])[3].ToString();
					// 获取选定行的学生的状态
					string getStuState = gridView1.GetDataRow(gridView1.GetSelectedRows()[0])[4].ToString();
					// 状态更新
					DateTime recTime = DateTime.Now;
					DateTime enterTime = DateTime.Now;
					try
					{
						recTime = Convert.ToDateTime(textEdit_CurRecTimeBinding.Text);
						enterTime = Convert.ToDateTime(getStuEnterDate);
					}
					catch
					{
					
					}

					if (Convert.ToDateTime(textEdit_BegTimeMorning.EditValue).AddDays(1) <= DateTime.Now)
					{
						enterTime = recTime;
					}
					stuCheckInfo.UpdateState(getStuNumber,enterTime.ToString("yyyy-MM-dd HH:mm:ss"), getStuState,recTime.ToString("yyyy-MM-dd HH:mm:ss"),textEdit_OrigStateBinding.Text);
					// 更新之后刷新统计集
					RefreshStatistics();

					MessageBox.Show("更新完毕！");

					simpleButton_SearchMorning.PerformClick();
				}
				else
				{
					showUpdate = false;
					gridView1.SetRowCellValue(getSelectedRow,"state_flowStateName",getOrigState);
				}
			}

			showUpdate = true;
		}
		#endregion

		#region 更新自定义状态
		private void gridView3_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			if ( showUpdate )
			{
				if ( Thread.CurrentPrincipal.IsInRole("班主任") )
				{
					if ( !gridView3.GetDataRow(gridView3.GetSelectedRows()[0])[2].ToString().Equals(rolesSystem.GetRolesDuty(Convert.ToInt32(Thread.CurrentPrincipal.Identity.Name)).Tables[0].Rows[0][1]) )
					{
						showUpdate = false;
						MessageBox.Show("该幼儿不属于您的班级，更新状态失败！");
						gridView3.SetRowCellValue(gridView3.GetSelectedRows()[0],"state_flowStateName",getOrigState);	
						return;
					}
				}
				string message = "是否确认要更新自定义状态？";
				string caption = "消息提示框!";
				int getSelectedRow = gridView3.GetSelectedRows()[0];
				DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
				if ( messageResult == DialogResult.Yes )
				{
					string getStuNumber = gridView3.GetDataRow(gridView3.GetSelectedRows()[0])[1].ToString();
					string getStuEnterDate = gridView3.GetDataRow(gridView3.GetSelectedRows()[0])[3].ToString();
					string getStuState = gridView3.GetDataRow(gridView3.GetSelectedRows()[0])[4].ToString();
					DateTime recTime = DateTime.Now;
					DateTime enterTime = DateTime.Now;
					try
					{
						recTime = Convert.ToDateTime(textEdit_CurRecTimeBinding.Text);
						enterTime = Convert.ToDateTime(getStuEnterDate);
					}
					catch
					{}

					if (Convert.ToDateTime(textEdit_BegTimeMorning.EditValue).AddDays(1) <= DateTime.Now)
					{
						enterTime = recTime;
					}
					stuCheckInfo.UpdateState(getStuNumber,enterTime.ToString("yyyy-MM-dd HH:mm:ss"), getStuState,recTime.ToString("yyyy-MM-dd HH:mm:ss"),textEdit_OrigStateBinding.Text);

					MessageBox.Show("更新完毕！");
				}
				else
				{
					showUpdate = false;
					gridView3.SetRowCellValue(getSelectedRow,"state_flowStateName",getOrigState);
				}
			}

			showUpdate = true;
		}
		#endregion
	
		#region 更新统计
		private void RefreshStatistics()
		{
			try
			{
				if ( !isFullDateMorning )
				{
					morBegDate = Convert.ToDateTime(textEdit_BegTimeMorning.EditValue).Date.ToString("yyyy-MM-dd");
					morEndDate = Convert.ToDateTime(textEdit_EndTimeMorning.EditValue).Date.ToString("yyyy-MM-dd");
				}
				else
				{
					morBegDate = Convert.ToDateTime(textEdit_BegTimeMorning.EditValue).ToString("yyyy-MM-dd HH:mm:ss");
					morEndDate = Convert.ToDateTime(textEdit_EndTimeMorning.EditValue).ToString("yyyy-MM-dd HH:mm:ss");
				}

				//没有指定特定学生的情况
				if(textEdit_NameMorning.Text.Equals("")  && textEdit_NumberMorning.Text.Equals(""))
				{
					if(comboBoxEdit_GradeMorning.SelectedItem.ToString().Equals("全部"))
					{
						stuAttendCalc.GetStuAttendCalcForClass("","",morBegDate,morEndDate,"健康");
						textEdit_Health.Text = stuAttendCalc.GetHealthAttend(true);

						stuAttendCalc.GetStuAttendCalcForClass("","",morBegDate,morEndDate,"服药");
						textEdit_Ill.Text = stuAttendCalc.GetIllAttend(true);
			
						stuAttendCalc.GetStuAttendCalcForClass("","",morBegDate,morEndDate,"观察");
						textEdit_Watch.Text = stuAttendCalc.GetWatchAttend(true);

						textEdit_HaveArr.Text = stuAttendCalc.GetHaveAttended(true);
						
						textEdit_Absence.Text = stuAttendCalc.GetAbsence(true);
					}
					else if(comboBoxEdit_ClassMorning.SelectedItem.ToString().Equals("全部"))
					{
						stuAttendCalc.GetStuAttendCalcForClass(getMorGradeNumberFromCombo,"",morBegDate,morEndDate,"健康");
						textEdit_Health.Text = stuAttendCalc.GetHealthAttend(true);

						stuAttendCalc.GetStuAttendCalcForClass(getMorGradeNumberFromCombo,"",morBegDate,morEndDate,"服药");
						textEdit_Ill.Text = stuAttendCalc.GetIllAttend(true);

						stuAttendCalc.GetStuAttendCalcForClass(getMorGradeNumberFromCombo,"",morBegDate,morEndDate,"观察");
						textEdit_Watch.Text = stuAttendCalc.GetWatchAttend(true);
				
						textEdit_HaveArr.Text = stuAttendCalc.GetHaveAttended(true);

						textEdit_Absence.Text = stuAttendCalc.GetAbsence(true);
						
					}
					else
					{
						stuAttendCalc.GetStuAttendCalcForClass(getMorGradeNumberFromCombo,getMorClassNumberFromCombo,
							morBegDate,morEndDate,"健康");
						textEdit_Health.Text = stuAttendCalc.GetHealthAttend(true);

						stuAttendCalc.GetStuAttendCalcForClass(getMorGradeNumberFromCombo,getMorClassNumberFromCombo,
							morBegDate,morEndDate,"服药");
						textEdit_Ill.Text = stuAttendCalc.GetIllAttend(true);

						stuAttendCalc.GetStuAttendCalcForClass(getMorGradeNumberFromCombo,getMorClassNumberFromCombo,
							morBegDate,morEndDate,"观察");
						textEdit_Watch.Text = stuAttendCalc.GetWatchAttend(true);

						textEdit_HaveArr.Text = stuAttendCalc.GetHaveAttended(true);

						textEdit_Absence.Text = stuAttendCalc.GetAbsence(true);
					}
						
				}
				else
				{
					if ( textEdit_NumberMorning.Text.Equals("") )
					{
						stuAttendCalc.GetStuAttendCalcForSolo(textEdit_NameMorning.Text.Replace(" ",""),
							"",morBegDate,morEndDate,"健康");
						textEdit_Health.Text = stuAttendCalc.GetHealthAttend(false);

						stuAttendCalc.GetStuAttendCalcForSolo(textEdit_NameMorning.Text.Replace(" ",""),
							"",morBegDate,morEndDate,"服药");
						textEdit_Ill.Text = stuAttendCalc.GetIllAttend(false);

						stuAttendCalc.GetStuAttendCalcForSolo(textEdit_NameMorning.Text.Replace(" ",""),
							"",morBegDate,morEndDate,"观察");
						textEdit_Watch.Text = stuAttendCalc.GetWatchAttend(false);

						textEdit_HaveArr.Text = stuAttendCalc.GetHaveAttended(false);

						textEdit_Absence.Text = stuAttendCalc.GetAbsence(false);
					}
					else
					{
						stuAttendCalc.GetStuAttendCalcForSolo("",textEdit_NumberMorning.Text.Replace(" ",""),
							morBegDate,morEndDate,"健康");
						textEdit_Health.Text = stuAttendCalc.GetHealthAttend(false);

						stuAttendCalc.GetStuAttendCalcForSolo("",textEdit_NumberMorning.Text.Replace(" ",""),
							morBegDate,morEndDate,"服药");
						textEdit_Ill.Text = stuAttendCalc.GetIllAttend(false);

						stuAttendCalc.GetStuAttendCalcForSolo("",textEdit_NumberMorning.Text.Replace(" ",""),
							morBegDate,morEndDate,"观察");
						textEdit_Watch.Text = stuAttendCalc.GetWatchAttend(false);

						textEdit_HaveArr.Text = stuAttendCalc.GetHaveAttended(false);

						textEdit_Absence.Text = stuAttendCalc.GetAbsence(false);
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		#endregion                            

		#region 帮助事件处理
		private void simpleButton_HelpMorning_Click(object sender, System.EventArgs e)
		{
		}
		#endregion

		#region 对不同的修改状态进行标识(晨检状态)
		private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
		{
			for ( int manuModifyRow = 0; manuModifyRow < stuCheckInfo.GetCellManualModify().Count; manuModifyRow+=2 )
			{
				// 获取需要对修改做出标识的行号和列号
//				if ( e.RowHandle == Convert.ToInt32(stuCheckInfo.GetCellManualModify()[manuModifyRow]) 
//					&& e.Column.VisibleIndex == 5)
//				{
//					e.Appearance.BackColor = Color.BlueViolet;
//				}
				if ( Convert.ToInt32(gridView1.GetDataRow(e.RowHandle)[1]) == Convert.ToInt32(stuCheckInfo.GetCellManualModify()[manuModifyRow])
					&& gridView1.GetDataRow(e.RowHandle)[3].ToString().Equals(stuCheckInfo.GetCellManualModify()[manuModifyRow+1].ToString())
					&& e.Column.VisibleIndex == 5)
				{
					e.Appearance.BackColor = Color.BlueViolet;
				}
			}

			for ( int manuInputRow = 0; manuInputRow < stuCheckInfo.GetCellManualInput().Count; manuInputRow+=2 )
			{
//				if ( e.RowHandle == Convert.ToInt32(stuCheckInfo.GetCellManualInput()[manuInputRow])
//					&& e.Column.VisibleIndex == 5)
//				{
//					e.Appearance.BackColor = Color.Red;
//				}
				if ( Convert.ToInt32(gridView1.GetDataRow(e.RowHandle)[1]) == Convert.ToInt32(stuCheckInfo.GetCellManualInput()[manuInputRow])
					&& gridView1.GetDataRow(e.RowHandle)[3].ToString().Equals(stuCheckInfo.GetCellManualInput()[manuInputRow+1].ToString())
					&& e.Column.VisibleIndex == 5)
				{
					e.Appearance.BackColor = Color.Red;
				}
			}
		}
		#endregion

		#region 对不的修改状态进行标识(自定义状态)
		private void gridView3_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
		{
			for ( int manuModifyRow = 0; manuModifyRow < stuCheckInfo.GetCustomManualModify().Count; manuModifyRow +=2 )
			{
				if ( Convert.ToInt32(gridView3.GetDataRow(e.RowHandle)[1]) == Convert.ToInt32(stuCheckInfo.GetCustomManualModify()[manuModifyRow])
					&& gridView3.GetDataRow(e.RowHandle)[3].ToString().Equals(stuCheckInfo.GetCustomManualModify()[manuModifyRow+1].ToString())
					&& e.Column.VisibleIndex == 5)
				{
					e.Appearance.BackColor = Color.BlueViolet;
				}
			}

			for ( int manuInputRow = 0; manuInputRow < stuCheckInfo.GetCustomManualInput().Count; manuInputRow +=2 )
			{
				if ( Convert.ToInt32(gridView3.GetDataRow(e.RowHandle)[1]) == Convert.ToInt32(stuCheckInfo.GetCustomManualInput()[manuInputRow])
					&& gridView3.GetDataRow(e.RowHandle)[3].ToString().Equals(stuCheckInfo.GetCustomManualInput()[manuInputRow+1].ToString())
					&& e.Column.VisibleIndex == 5)
				{
					e.Appearance.BackColor = Color.Red;
				}
			}
		}
		#endregion	

		#region 处理预览事件
		private void simpleButton_PreviewReport_Click(object sender, System.EventArgs e)
		{
			PerformeReportPreview();
		}
		#endregion

		#region 处理打印事件
		private void simpleButton_PrintReport_Click(object sender, System.EventArgs e)
		{
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
                //g.DrawImage(PrintImage, new RectangleF(1000, 100, 800,500), BorderSide.All, Color.White);
                //printForm.getPrintInstance().End();
                //printForm.Show();
			}
		}
		#endregion

		#region 获取晨检状态未变化前的状态
		private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			if ( gridView1.RowCount != 0 )
			{
				showUpdate = true;
				getOrigState = gridView1.GetDataRow(gridView1.GetSelectedRows()[0])[4].ToString();
			}
		}
		#endregion

		#region 获取自定义状态未变化前的状态
		private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			if ( gridView3.RowCount != 0 )
			{
				showUpdate = true;
				getOrigState = gridView3.GetDataRow(gridView3.GetSelectedRows()[0])[4].ToString();
			}
		}	
		#endregion

		#region 晨检打印
		private void simpleButton_PrintMorning_Click(object sender, System.EventArgs e)
		{
			
			if ( dsMorningCheckInfo.Tables[0].Rows.Count > 0 )
			{
				if ( Thread.CurrentPrincipal.IsInRole("班主任") )
				{
					DataSet dsRolesInDuty = rolesSystem.GetRolesDuty(Convert.ToInt32(Thread.CurrentPrincipal.Identity.Name));
					string getGrade = dsRolesInDuty.Tables[0].Rows[0][0].ToString();
					string getClass = dsRolesInDuty.Tables[0].Rows[0][1].ToString();
					dsMorningCheckInfo = stuCheckInfo.GetStuMorningCheckInfo(getStuInfoByCondition.getGradeInfo(getGrade,"").Tables[0].Rows[0][0].ToString(),getStuInfoByCondition.getClassInfo(
						getClass,"","").Tables[0].Rows[0][0].ToString(),
						textEdit_NameMorning.Text.Replace(" ",""),textEdit_NumberMorning.Text.Replace(" ",""),morBegDate,morEndDate,getMorningStateFromCombo);
				}
			}
			
			if ( gridView1.RowCount == 0 )
			{
				MessageBox.Show("没有要导出的数据!","系统信息!",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}

			saveFileDialog_Report.Filter = "Excel文件|*.xls";

			if ( saveFileDialog_Report.ShowDialog() != DialogResult.OK )
				return;

			string savePath = saveFileDialog_Report.FileName;

			stuMorningCheckInfoPrintSystem.PrintMorningCheckInfo(dsMorningCheckInfo,morBegDate,morEndDate,savePath);

			MessageBox.Show("报表生成完毕！");

			
		}
		#endregion

		#region 晚接打印
		private void simpleButton_PrintBack_Click(object sender, System.EventArgs e)
		{
		
			if ( dsBackCheckInfo.Tables[0].Rows.Count > 0 )
			{
				if ( Thread.CurrentPrincipal.IsInRole("班主任") )
				{
					DataSet dsRolesInDuty = rolesSystem.GetRolesDuty(Convert.ToInt32(Thread.CurrentPrincipal.Identity.Name));
					string getGrade = dsRolesInDuty.Tables[0].Rows[0][0].ToString();
					string getClass = dsRolesInDuty.Tables[0].Rows[0][1].ToString();
					dsBackCheckInfo = stuCheckInfo.GetStuBackHomeCheckInfo(getStuInfoByCondition.getGradeInfo(getGrade,"").Tables[0].Rows[0][0].ToString(),getStuInfoByCondition.getClassInfo(
						getClass,"","").Tables[0].Rows[0][0].ToString(),
						textEdit_NameBack.Text.Replace(" ",""),textEdit_NumberBack.Text.Replace(" ",""),morBegDate,morEndDate,getBackStateFromCombo);
				}
			}

			if ( gridView2.RowCount == 0 )
			{
				MessageBox.Show("没有要导出的数据!","系统信息!",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}
			
			saveFileDialog_Report.Filter = "Excel文件|*.xls";

			if ( saveFileDialog_Report.ShowDialog() != DialogResult.OK )
				return;

			string savePath = saveFileDialog_Report.FileName;

			stuMorningCheckInfoPrintSystem.PrintBackCheckInfo(dsBackCheckInfo,backBegDate,backEndDate,savePath);

			MessageBox.Show("报表生成完毕！");
		}
		#endregion

		//获取打印image对象
		private Bitmap PrintImage
		{
			get { return this.myImage; }
			set { this.myImage = value; }
		}

		private void PerformeReportPreview()
		{
			string savePath;
			string overMsg = string.Empty;
			DateTime getBegDate = Convert.ToDateTime(textEdit_BegDateReport.EditValue);
			DateTime getEndDate = Convert.ToDateTime(textEdit_EndDateReport.EditValue);

			if ( comboBoxEdit_PrintType.SelectedIndex == 0 || comboBoxEdit_PrintType.SelectedIndex >= 3 )
			{
				saveFileDialog_Report.Filter = "Excel文件|*.xls";

				if ( saveFileDialog_Report.ShowDialog() != DialogResult.OK )
					return;

				savePath = saveFileDialog_Report.FileName;

				overMsg = "报表已经生成！";
			}
			else
			{
				savePath = "No Path";
				overMsg = string.Empty;
			}

			if (  getBegDate<= getEndDate )
			{
				if ( textEdit_NameReport.Text.Equals("") && textEdit_NumberReport.Text.Equals("") )
				{

					if ( comboBoxEdit_GradeReport.SelectedItem.ToString().Equals("全部") )
					{

						if ( comboBoxEdit_PrintType.SelectedIndex >= 3 && textEdit_NameReport.Text.Equals("") && textEdit_NumberReport.Text.Equals("") )
						{
							MessageBox.Show("个人统计或个人详细报表不适合做全年级统计，请指定一个班级或个人进行分析！");
							return;
						}

						PrintImage = stuMorningCheckInfoPrintSystem.MorningCheckInfoStatPrint(getBegDate,
							getEndDate,"","","","",comboBoxEdit_PrintType.SelectedIndex,
							groupControl_PreviewReport,savePath);

					}
					else
					{
						if ( comboBoxEdit_ClassReport.SelectedItem.ToString().Equals("全部") )
						{
							if ( comboBoxEdit_PrintType.SelectedIndex >= 3 && textEdit_NameReport.Text.Equals("") && textEdit_NumberReport.Text.Equals("") )
							{
								MessageBox.Show("个人统计或个人详细报表不适合做年级统计，请指定一个班级或个人进行分析！");
								return;
							}

							PrintImage = stuMorningCheckInfoPrintSystem.MorningCheckInfoStatPrint(getBegDate,
								getEndDate,getRepGradeNumberFromCombo,"","","",comboBoxEdit_PrintType.SelectedIndex,
								groupControl_PreviewReport,savePath);
						}
						else
						{
							PrintImage = stuMorningCheckInfoPrintSystem.MorningCheckInfoStatPrint(getBegDate,
								getEndDate,getRepGradeNumberFromCombo,getRepClassNumberFromCombo,
								"","",comboBoxEdit_PrintType.SelectedIndex,groupControl_PreviewReport,savePath);
						}
					}
				}
				else
				{
					if ( textEdit_NumberReport.Text.Equals("") )
					{
						if ( Thread.CurrentPrincipal.IsInRole("班主任") )
						{
							bool isMatch = false;
							if ( stuCheckInfo.GetClassName(textEdit_NameReport.Text.Replace(" ",""),"").Tables[0].Rows.Count > 0 )
							{
								foreach(DataRow matchRow in stuCheckInfo.GetClassName(textEdit_NameReport.Text.Replace(" ",""),"").Tables[0].Rows)
								{
									if ( matchRow["info_className"].ToString().Equals(rolesSystem.GetRolesDuty(Convert.ToInt32(Thread.CurrentPrincipal.Identity.Name)).Tables[0].Rows[0][1].ToString()) )
									{
										isMatch = true;
										break;
									}
								}
							}

							if ( isMatch )
								PrintImage = stuMorningCheckInfoPrintSystem.MorningCheckInfoStatPrint(getBegDate,
									getEndDate,"","",textEdit_NameReport.Text.Replace(" ",""),"",
									comboBoxEdit_PrintType.SelectedIndex,groupControl_PreviewReport,savePath);
							else
							{
								MessageBox.Show("该幼儿不属于本班级！");
								return;
							}
						}
						else
							PrintImage = stuMorningCheckInfoPrintSystem.MorningCheckInfoStatPrint(getBegDate,
								getEndDate,"","",textEdit_NameReport.Text.Replace(" ",""),"",
								comboBoxEdit_PrintType.SelectedIndex,groupControl_PreviewReport,savePath);
					}
					else
					{
						if ( Thread.CurrentPrincipal.IsInRole("班主任") )
						{
							bool isMatch = false;
							if ( stuCheckInfo.GetClassName("",textEdit_NumberReport.Text.Replace(" ","")).Tables[0].Rows.Count > 0 )
							{
								foreach(DataRow matchRow in stuCheckInfo.GetClassName("",textEdit_NumberReport.Text.Replace(" ","")).Tables[0].Rows)
								{
									if ( matchRow["info_className"].ToString().Equals(rolesSystem.GetRolesDuty(Convert.ToInt32(Thread.CurrentPrincipal.Identity.Name)).Tables[0].Rows[0][1].ToString()) )
									{
										isMatch = true;
										break;
									}
								}
							}

							if ( isMatch )
								PrintImage = stuMorningCheckInfoPrintSystem.MorningCheckInfoStatPrint(getBegDate,
									getEndDate,"","","",textEdit_NumberReport.Text.Replace(" ",""),
									comboBoxEdit_PrintType.SelectedIndex,groupControl_PreviewReport,savePath);
							else
							{
								MessageBox.Show("该幼儿不属于本班级！");
								return;
							}
						}
						else
							PrintImage = stuMorningCheckInfoPrintSystem.MorningCheckInfoStatPrint(getBegDate,
								getEndDate,"","","",textEdit_NumberReport.Text.Replace(" ",""),
								comboBoxEdit_PrintType.SelectedIndex,groupControl_PreviewReport,savePath);
					}
				}

				if ( !overMsg.Equals(string.Empty) )
					MessageBox.Show(overMsg);
			}
			else
				MessageBox.Show("开始时间不应该大于结束时间！");
		}

		private void groupControl_PreviewReport_Resize(object sender, System.EventArgs e)
		{
			//comboBoxEdit_PrintType.SelectedIndex = 1;
			//PerformeReportPreview();
		}

        private void OnGroupUpTabInilitized()
        {
            ShowGrowUpReportPath();
            comboBox1.SelectedItem = DateTime.Now.ToString("yyyy年");
            label1.Visible = false;
        }

        private void ShowGrowUpReportPath()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + @"report\成长记录报表";
            var root = new TreeNode("成长记录报表");
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(root);
            this.AppendNode(root, path);
        }

        private void AppendNode(TreeNode root, string rootPath)
        {
            var dirs = Directory.GetDirectories(rootPath);
            if (dirs.Length != 0)
            {
                foreach (var dir in dirs)
                {
                    var node = new TreeNode(new DirectoryInfo(dir).Name);
                    node.Tag = new Tuple<bool, string>(false, dir);
                    this.AppendNode(node, dir);
                    root.Nodes.Add(node);
                }
            }
            else
            {
                foreach (var file in Directory.GetFiles(rootPath).Where(f => Path.GetExtension(f) == ".xls"))
                {
                    var node = new TreeNode(new FileInfo(file).Name);
                    node.Tag = new Tuple<bool, string>(true, file);
                    root.Nodes.Add(node);
                }
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var tuple = e.Node.Tag as Tuple<bool, string>;
            if (tuple != null)
            {
                if (tuple.Item1)
                {
                    using (var process = new Process())
                    {
                        process.StartInfo.WorkingDirectory = Path.GetDirectoryName(tuple.Item2);
                        process.StartInfo.CreateNoWindow = true;
                        process.StartInfo.FileName = new FileInfo(tuple.Item2).Name;
                        process.Start();
                    }
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var tuple = new GrowUpReport().GetGradeAndClassCount();

            label1.Visible = true;
            var year = comboBox1.SelectedItem.ToString().Replace("年", string.Empty);
            var date = checkedComboBoxEdit1.EditValue.ToString();
            var selectedDate = date.Split(',').Select(d => new DateTime(Convert.ToInt32(year), Convert.ToInt32(d.Replace("月", string.Empty)), 1)).ToArray();
            int reportCreate = 0;
            var gardenName = new GardenInfoSystem().GetGardenInfo().Tables[0].Rows[0]["info_gardenName"].ToString();
            //班级数量*天数+班级数量+2*年级数量*天数+年级数量+3*天数
            int totalReportCount = tuple.Item2 * (selectedDate.Length + 1) + tuple.Item1 * (2 * selectedDate.Length + 1) + 3 * selectedDate.Length;
            progressBar1.Maximum = totalReportCount;
            Action notify = () =>
                {
                    context.Send(d => label1.Text = string.Format("一大波报表正在生成，已经生成:{0}/{1}", ++reportCreate, totalReportCount), null);
                    context.Send(d => progressBar1.Value = reportCreate, null);
                };
            new Task(() =>
                {
                    new GrowUpReport().GenerateReportsPersonByPerson(gardenName, selectedDate, notify); //个人汇总
                    new GrowUpReport().GenerateReportsByClass(gardenName, selectedDate, notify); //班级统计汇总
                    new GrowUpReport().GenerateReportsByGrade(gardenName, selectedDate, notify); //年级统计汇总
                    new GrowUpReport().GenerateStatsReports(gardenName, selectedDate, notify); //年级汇总
                    new GrowUpReport().GenerateCheckReports(gardenName, selectedDate, notify); //幼儿体验，幼儿体验汇总
                    context.Post(d => 
                        {
                            label1.Text = "全部生成完成";
                            simpleButton1.Enabled = true;
                            progressBar1.Value = progressBar1.Maximum;
                            ShowGrowUpReportPath();
                        }, null);
                }).Start();
            simpleButton1.Enabled = false;
        }
	}
}
