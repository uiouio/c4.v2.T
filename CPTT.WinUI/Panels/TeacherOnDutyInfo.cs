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
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraPrinting;

using ZedGraph;
using CPTT.BusinessFacade;
using CPTT.SystemFramework;

namespace CPTT.WinUI.Panels
{
	/// <summary>
	/// Summary description for TeacherOnDutyInfo.
	/// </summary>
	public class TeacherOnDutyInfo : DevExpress.XtraEditors.XtraUserControl
	{
		private DevExpress.XtraTab.XtraTabControl xtraTabControl_TeaDutyDetailInfo;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage_TeaDutyDetails;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage_TeaOnDutyInfo;
		private DevExpress.XtraEditors.GroupControl groupControl_TeaDutyDetailsMgmt;
		private DevExpress.XtraEditors.GroupControl groupControl_TeaDutyAsign;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage_TeaOnDutyReports;
		private DevExpress.Utils.Frames.NotePanel pnlHint_DutyName;
		private DevExpress.Utils.Frames.NotePanel notePanel_DutyStartTime;
		private DevExpress.Utils.Frames.NotePanel notePanel_DutyEndTime;
		private DevExpress.Utils.Frames.NotePanel notePanel_DutyRemark;
		private System.Windows.Forms.Label label_ReqOfDutyName;
		private System.Windows.Forms.Label label_ReqOfDutyStartTime;
		private System.Windows.Forms.Label label_ReqOfDutyEndTime;
		private DevExpress.Utils.Frames.NotePanel notePanel_DutyDetailsTitle;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl_DutyMgmt;
		private DevExpress.XtraEditors.DataNavigator dataNavigator_DutyDetails;
		private DevExpress.Utils.Frames.NotePanel notePanel_TeaDutyAsignSearTitle;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.Utils.Frames.NotePanel notePanel2;
		private DevExpress.XtraEditors.SimpleButton simpleButton_SaveDutyAsign;
		private DevExpress.Utils.Frames.NotePanel notePanel_AsignDutyByTeaID;
		private DevExpress.Utils.Frames.NotePanel notePannotePanel_AsignDutyByTeaGrade;
		private DevExpress.Utils.Frames.NotePanel notePannotePanel_AsignDutyByTeaName;
		private DevExpress.Utils.Frames.NotePanel notePannotePanel_AsignDutyByTeaClass;
		private DevExpress.XtraEditors.GroupControl groupControl_TeaDutyDetailsSearch;
		private DevExpress.XtraEditors.TextEdit textEdit_AddDutyName;
		private DevExpress.XtraEditors.TextEdit textEdit_AddDutyRemark;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_DutySearTeaClass;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_DutySearTeaGarde;
		private DevExpress.XtraEditors.TextEdit textEdit_DutySearTeaID;
		private DevExpress.XtraEditors.TextEdit textEdit_DutySearTeaName;
		private DevExpress.Utils.Frames.NotePanel notePanel_TeaDutyDetailsSearByID;
		private DevExpress.Utils.Frames.NotePanel notePanel_TeaDutyDetailSearByName;
		private DevExpress.Utils.Frames.NotePanel notePanel_TeaDutyDetailsSearByGrade;
		private DevExpress.Utils.Frames.NotePanel notePanel_TeaDutyDetailsSearByClass;
		private DevExpress.Utils.Frames.NotePanel notePanel_TeaDutyDetailsSearByStartTime;
		private DevExpress.Utils.Frames.NotePanel notePanel_TeaDutyDetailsSearByEndTime;
		private DevExpress.XtraEditors.GroupControl groupControl_TeaDutyDetails;
		private DevExpress.XtraEditors.TextEdit textEdit_TeaDutyDetailsSearByID;
		private DevExpress.XtraEditors.TextEdit textEdit_TeaDutyDetailsSearByName;
		private DevExpress.XtraEditors.SimpleButton simpleButton_SearTeaDutyDetails;
		private DevExpress.XtraEditors.DateEdit dateEdit_TeaDutyDetailsSearByStartTime;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_TeaDutyDetailsSearByGrade;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_TeaDutyDetailsSearByClass;
		private DevExpress.XtraEditors.DateEdit dateEdit_TeaDutyDetailsSearByEndTime;
		private DevExpress.XtraEditors.GroupControl groupControl_TeaDutyDetailsStatistic;
		private DevExpress.XtraEditors.GroupControl groupControl_TeaDutyOutDetails;
		private DevExpress.XtraGrid.GridControl gridControl_TeaDutyAsign;
		private DevExpress.XtraGrid.GridControl gridControl_TeaDutyDetails;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraGrid.GridControl gridControl_TeaOutDetails;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
		private DevExpress.XtraEditors.GroupControl groupControl_TeaDutyReportsSear;
		private DevExpress.XtraEditors.SimpleButton simpleButton_ReportAnalysis;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		private DevExpress.XtraEditors.SimpleButton simpleButton_TeaSearForDuty;

		private GetStuInfoByCondition getStuInfoByCondition;
		private DataSet DutyInfo;
		private DataSet	AllTeaDutyInfo;
		private DataView AllTeadutyInfoView;
		private DevExpress.XtraEditors.TextEdit textEdit_DutyStartTime;
		private DevExpress.XtraEditors.TextEdit textEdit_DutyEndTime;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
		private DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit repositoryItemPopupContainerEdit1;
		private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView advBandedGridView1;
		private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
		private DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
		private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl1;
		private DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit repositoryItemPopupContainerEdit2;
		private DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit repositoryItemPopupContainerEdit3;
		private DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit repositoryItemPopupContainerEdit4;
		private DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit repositoryItemPopupContainerEdit5;
		private DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit repositoryItemPopupContainerEdit6;
		private DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit repositoryItemPopupContainerEdit7;
		private DevExpress.XtraEditors.PopupContainerControl popupContainerControl2;
		private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl2;
		private DevExpress.XtraEditors.PopupContainerControl popupContainerControl3;
		private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl3;
		private DevExpress.XtraEditors.PopupContainerControl popupContainerControl4;
		private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl4;
		private DevExpress.XtraEditors.PopupContainerControl popupContainerControl5;
		private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl5;
		private DevExpress.XtraEditors.PopupContainerControl popupContainerControl6;
		private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl6;
		private DevExpress.XtraEditors.PopupContainerControl popupContainerControl7;
		private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.Utils.ToolTipController toolTipController1;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn30;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn32;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
		private System.Windows.Forms.SaveFileDialog saveFileDialog_Report;
		private DevExpress.XtraEditors.SimpleButton simpleButton3;
		private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
		private DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit repositoryItemPopupContainerEdit8;
		private DevExpress.XtraEditors.PopupContainerControl popupContainerControl_Remarks;
		private DevExpress.XtraEditors.MemoEdit memoEdit_Remarks;
		private DevExpress.XtraEditors.GroupControl groupControl_Graph;
		private DevExpress.XtraEditors.DateEdit dateEdit1;
		private DevExpress.Utils.Frames.NotePanel notePanel6;
		private DevExpress.Utils.Frames.NotePanel notePanel7;
		private DevExpress.XtraEditors.DateEdit dateEdit2;
		private System.ComponentModel.IContainer components;
		private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView advBandedGridView2;
		private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn13;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn14;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn15;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn16;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn17;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn18;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn19;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn20;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn21;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn22;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn23;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn24;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn25;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn34;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn35;

		private ZedGraphControl zedGraphControl_TeaDuty;
		private bool appendClick = false;
		private DevExpress.Utils.Frames.NotePanel notePanel_TeaOut;
		private DevExpress.Utils.Frames.NotePanel notePanel_TeaShouldAttend;
		private DevExpress.Utils.Frames.NotePanel notePanel_TeaOnTime;
		private DevExpress.Utils.Frames.NotePanel notePanel_TeaOffTime;
		private DevExpress.Utils.Frames.NotePanel notePanel_TeaAttend;
		private DevExpress.Utils.Frames.NotePanel notePanel_TeaAbsence;
		private DevExpress.XtraEditors.TextEdit textEdit_TeaOnTime;
		private DevExpress.XtraEditors.TextEdit textEdit_TeaOffTime;
		private DevExpress.XtraEditors.TextEdit textEdit_TeaAbsence;
		private DevExpress.XtraEditors.TextEdit textEdit_TeaAttend;
		private DevExpress.XtraEditors.TextEdit textEdit_TeaShouldAttend;
		private DevExpress.XtraEditors.TextEdit textEdit_TeaOut;
		private DevExpress.Utils.Frames.NotePanel notePanel_DutyHistory;
		private DevExpress.XtraEditors.DateEdit dateEdit_DutyHistory;
		private DevExpress.XtraEditors.SimpleButton simpleButton_LoadHisDuty;
		private DevExpress.XtraEditors.SimpleButton simpleButton_LoadCurDuty;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Graphic_TeaDept;
		private DevExpress.XtraEditors.TextEdit textEdit_Graphic_TeaID;
		private DevExpress.Utils.Frames.NotePanel notePanel_Graphic_TeaID;
		private DevExpress.Utils.Frames.NotePanel notePanel_Graphic_TeaName;
		private DevExpress.Utils.Frames.NotePanel notePanel_Graphic_TeaDept;
		private DevExpress.Utils.Frames.NotePanel notePanel_Graphic_TeaDuty;
		private DevExpress.XtraEditors.TextEdit textEdit_Graphic_TeaName;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Graphic_TeaDuty;
		private DevExpress.Utils.Frames.NotePanel notePanel_TeaDutyDetailsSerType;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_TeaDutyDetailsSerType;
		private DevExpress.XtraGrid.GridControl gridControl_TeaDutyNormal;
		private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView advBandedGridView3;
		private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn1;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn2;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn3;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn4;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn5;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn6;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn7;
		private DevExpress.XtraEditors.SimpleButton simpleButton_TeaDutySave;
		private DevExpress.XtraGrid.GridControl gridControl_TeaDutySummary;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
		private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView advBandedGridView4;
		private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn8;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn9;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn10;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn11;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn12;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn13;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn14;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn15;

		private RolesSystem rolesSystem;

		// the default option for teacher duty is normal

		private DataSet dsTeaDutyDetail;
		private DataSet dsTeaDutyNormal;
		private DataSet dsTeaDutySummary;
		private System.Windows.Forms.HelpProvider helpProvider_DutyInfo;
		private DataSet dsTeaOutDetail;
		private DevExpress.Utils.Frames.NotePanel notePanel_TeaDutyDetailsFlowType;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_TeaDutyDetailsFlowType;
		private DevExpress.XtraEditors.SimpleButton simpleButton4;
		private bool isSaveNextDuty = false;

		public TeacherOnDutyInfo()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call

			getStuInfoByCondition = new GetStuInfoByCondition();
			rolesSystem = new RolesSystem();

			dateEdit_TeaDutyDetailsSearByStartTime.EditValue = DateTime.Now;
			dateEdit_TeaDutyDetailsSearByEndTime.EditValue = DateTime.Now;
			dateEdit1.EditValue = DateTime.Now;
			dateEdit2.EditValue = DateTime.Now;
			dateEdit_DutyHistory.EditValue = DateTime.Now;

			LoadGradeClassInfo();

			DutyInfo = new DutySystem().GetDutyInfoList();

			BindDutyData();

			dataNavigator_DutyDetails.DataSource = DutyInfo.Tables[0];

			if(!Thread.CurrentPrincipal.IsInRole("园长") && Thread.CurrentPrincipal.Identity.Name.ToLower() != "admin" )
			{
				DataSet dsRolesDuty = rolesSystem.GetRolesDuty(Convert.ToInt32(Thread.CurrentPrincipal.Identity.Name));
				string gradeName = dsRolesDuty.Tables[0].Rows[0][0].ToString();
				string className = dsRolesDuty.Tables[0].Rows[0][1].ToString();

				comboBoxEdit_TeaDutyDetailsSearByGrade.Properties.Items.Clear();
				comboBoxEdit_TeaDutyDetailsSearByGrade.Properties.Items.AddRange(new object[]{gradeName});
				comboBoxEdit_TeaDutyDetailsSearByGrade.SelectedItem = gradeName;
				comboBoxEdit_TeaDutyDetailsSearByClass.Properties.Items.Clear();
				comboBoxEdit_TeaDutyDetailsSearByClass.Properties.Items.AddRange(new object[]{className});
				comboBoxEdit_TeaDutyDetailsSearByClass.SelectedItem = className;
			
				textEdit_TeaDutyDetailsSearByName.Text = new HealthManagementSystem().GetTeaName(Thread.CurrentPrincipal.Identity.Name);
				textEdit_TeaDutyDetailsSearByName.Properties.ReadOnly = true;
				textEdit_TeaDutyDetailsSearByID.Text = Thread.CurrentPrincipal.Identity.Name;
				textEdit_TeaDutyDetailsSearByID.Properties.ReadOnly = true;

				simpleButton_SaveDutyAsign.Enabled = false;

				dataNavigator_DutyDetails.Buttons.Append.Visible = false;
				dataNavigator_DutyDetails.Buttons.Remove.Visible = false;
				dataNavigator_DutyDetails.Buttons.EndEdit.Visible = false;
				xtraTabPage_TeaOnDutyReports.PageVisible = false;
	
				this.gridColumn4.OptionsColumn.AllowEdit = false;
				this.gridColumn5.OptionsColumn.AllowEdit = false;
				this.gridColumn6.OptionsColumn.AllowEdit = false;
				this.gridColumn7.OptionsColumn.AllowEdit = false;
				this.gridColumn8.OptionsColumn.AllowEdit = false;
				this.gridColumn9.OptionsColumn.AllowEdit = false;
				this.gridColumn10.OptionsColumn.AllowEdit = false;

			}
			if ( Thread.CurrentPrincipal.Identity.Name.ToLower() == "admin" )
			{
				simpleButton_SearTeaDutyDetails.Enabled = false;
				simpleButton3.Enabled = false;
				simpleButton_LoadHisDuty.Enabled = false;
				simpleButton_TeaDutySave.Enabled = false;
			}

			simpleButton3.Enabled = false;

			LoadSelectTeaDutyInfo();

			simpleButton1_Click(null,null);

			#region 帮助
			helpProvider_DutyInfo.HelpNamespace = System.IO.Path.GetDirectoryName(Application.ExecutablePath)
				+ CPTT.SystemFramework.Util.HELP_FILE_NAME;

			this.helpProvider_DutyInfo.SetHelpKeyword(this.xtraTabPage_TeaDutyDetails,"班次管理");
			this.helpProvider_DutyInfo.SetHelpNavigator(this.xtraTabPage_TeaDutyDetails, System.Windows.Forms.HelpNavigator.KeywordIndex);
			this.helpProvider_DutyInfo.SetHelpString(this.xtraTabPage_TeaDutyDetails, "");
			this.helpProvider_DutyInfo.SetShowHelp(this.xtraTabPage_TeaDutyDetails, true);

			this.helpProvider_DutyInfo.SetHelpKeyword(this.xtraTabPage_TeaOnDutyInfo,"出勤信息");
			this.helpProvider_DutyInfo.SetHelpNavigator(this.xtraTabPage_TeaOnDutyInfo, System.Windows.Forms.HelpNavigator.KeywordIndex);
			this.helpProvider_DutyInfo.SetHelpString(this.xtraTabPage_TeaOnDutyInfo, "");
			this.helpProvider_DutyInfo.SetShowHelp(this.xtraTabPage_TeaOnDutyInfo, true);

			this.helpProvider_DutyInfo.SetHelpKeyword(this.xtraTabPage_TeaOnDutyReports,"出勤信息分析");
			this.helpProvider_DutyInfo.SetHelpNavigator(this.xtraTabPage_TeaOnDutyReports, System.Windows.Forms.HelpNavigator.KeywordIndex);
			this.helpProvider_DutyInfo.SetHelpString(this.xtraTabPage_TeaOnDutyReports, "");
			this.helpProvider_DutyInfo.SetShowHelp(this.xtraTabPage_TeaOnDutyReports, true);
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
            this.advBandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridControl_TeaDutyAsign = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPopupContainerEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.checkedListBoxControl1 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPopupContainerEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
            this.popupContainerControl2 = new DevExpress.XtraEditors.PopupContainerControl();
            this.checkedListBoxControl2 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPopupContainerEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
            this.popupContainerControl3 = new DevExpress.XtraEditors.PopupContainerControl();
            this.checkedListBoxControl3 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPopupContainerEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
            this.popupContainerControl4 = new DevExpress.XtraEditors.PopupContainerControl();
            this.checkedListBoxControl4 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPopupContainerEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
            this.popupContainerControl5 = new DevExpress.XtraEditors.PopupContainerControl();
            this.checkedListBoxControl5 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPopupContainerEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
            this.popupContainerControl6 = new DevExpress.XtraEditors.PopupContainerControl();
            this.checkedListBoxControl6 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPopupContainerEdit7 = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
            this.popupContainerControl7 = new DevExpress.XtraEditors.PopupContainerControl();
            this.checkedListBoxControl7 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.xtraTabControl_TeaDutyDetailInfo = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage_TeaDutyDetails = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl_TeaDutyAsign = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton_SaveDutyAsign = new DevExpress.XtraEditors.SimpleButton();
            this.notePanel2 = new DevExpress.Utils.Frames.NotePanel();
            this.groupControl_TeaDutyDetailsMgmt = new DevExpress.XtraEditors.GroupControl();
            this.splitContainerControl_DutyMgmt = new DevExpress.XtraEditors.SplitContainerControl();
            this.textEdit_DutyStartTime = new DevExpress.XtraEditors.TextEdit();
            this.dataNavigator_DutyDetails = new DevExpress.XtraEditors.DataNavigator();
            this.notePanel_DutyDetailsTitle = new DevExpress.Utils.Frames.NotePanel();
            this.pnlHint_DutyName = new DevExpress.Utils.Frames.NotePanel();
            this.label_ReqOfDutyName = new System.Windows.Forms.Label();
            this.textEdit_AddDutyName = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_DutyStartTime = new DevExpress.Utils.Frames.NotePanel();
            this.label_ReqOfDutyEndTime = new System.Windows.Forms.Label();
            this.notePanel_DutyRemark = new DevExpress.Utils.Frames.NotePanel();
            this.textEdit_AddDutyRemark = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_DutyEndTime = new DevExpress.Utils.Frames.NotePanel();
            this.label_ReqOfDutyStartTime = new System.Windows.Forms.Label();
            this.textEdit_DutyEndTime = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton_TeaDutySave = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_LoadCurDuty = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_LoadHisDuty = new DevExpress.XtraEditors.SimpleButton();
            this.dateEdit_DutyHistory = new DevExpress.XtraEditors.DateEdit();
            this.notePanel_DutyHistory = new DevExpress.Utils.Frames.NotePanel();
            this.comboBoxEdit_DutySearTeaClass = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEdit_DutySearTeaGarde = new DevExpress.XtraEditors.ComboBoxEdit();
            this.textEdit_DutySearTeaID = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_AsignDutyByTeaID = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_TeaDutyAsignSearTitle = new DevExpress.Utils.Frames.NotePanel();
            this.notePannotePanel_AsignDutyByTeaGrade = new DevExpress.Utils.Frames.NotePanel();
            this.notePannotePanel_AsignDutyByTeaName = new DevExpress.Utils.Frames.NotePanel();
            this.notePannotePanel_AsignDutyByTeaClass = new DevExpress.Utils.Frames.NotePanel();
            this.textEdit_DutySearTeaName = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton_TeaSearForDuty = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPage_TeaOnDutyInfo = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl_TeaDutyDetailsStatistic = new DevExpress.XtraEditors.GroupControl();
            this.textEdit_TeaOut = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_TeaShouldAttend = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_TeaAttend = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_TeaAbsence = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_TeaOffTime = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_TeaOnTime = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_TeaOut = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_TeaShouldAttend = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_TeaOnTime = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_TeaOffTime = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_TeaAttend = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_TeaAbsence = new DevExpress.Utils.Frames.NotePanel();
            this.groupControl_TeaDutyDetailsSearch = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.comboBoxEdit_TeaDutyDetailsFlowType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.notePanel_TeaDutyDetailsFlowType = new DevExpress.Utils.Frames.NotePanel();
            this.comboBoxEdit_TeaDutyDetailsSerType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.notePanel_TeaDutyDetailsSerType = new DevExpress.Utils.Frames.NotePanel();
            this.simpleButton_SearTeaDutyDetails = new DevExpress.XtraEditors.SimpleButton();
            this.dateEdit_TeaDutyDetailsSearByStartTime = new DevExpress.XtraEditors.DateEdit();
            this.comboBoxEdit_TeaDutyDetailsSearByGrade = new DevExpress.XtraEditors.ComboBoxEdit();
            this.textEdit_TeaDutyDetailsSearByID = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_TeaDutyDetailsSearByID = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_TeaDutyDetailSearByName = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_TeaDutyDetailsSearByGrade = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_TeaDutyDetailsSearByClass = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_TeaDutyDetailsSearByStartTime = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_TeaDutyDetailsSearByEndTime = new DevExpress.Utils.Frames.NotePanel();
            this.textEdit_TeaDutyDetailsSearByName = new DevExpress.XtraEditors.TextEdit();
            this.comboBoxEdit_TeaDutyDetailsSearByClass = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dateEdit_TeaDutyDetailsSearByEndTime = new DevExpress.XtraEditors.DateEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl_TeaDutyDetails = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_TeaDutySummary = new DevExpress.XtraGrid.GridControl();
            this.advBandedGridView4 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn8 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn10 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn12 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn14 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn9 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn11 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn13 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn15 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControl_TeaDutyNormal = new DevExpress.XtraGrid.GridControl();
            this.advBandedGridView3 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn7 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.popupContainerControl_Remarks = new DevExpress.XtraEditors.PopupContainerControl();
            this.memoEdit_Remarks = new DevExpress.XtraEditors.MemoEdit();
            this.gridControl_TeaDutyDetails = new DevExpress.XtraGrid.GridControl();
            this.advBandedGridView2 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColumn13 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemPopupContainerEdit8 = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
            this.gridColumn34 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn35 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl_TeaDutyOutDetails = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_TeaOutDetails = new DevExpress.XtraGrid.GridControl();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabPage_TeaOnDutyReports = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl_Graph = new DevExpress.XtraEditors.GroupControl();
            this.groupControl_TeaDutyReportsSear = new DevExpress.XtraEditors.GroupControl();
            this.comboBoxEdit_Graphic_TeaDept = new DevExpress.XtraEditors.ComboBoxEdit();
            this.textEdit_Graphic_TeaID = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_Graphic_TeaID = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_Graphic_TeaName = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_Graphic_TeaDept = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_Graphic_TeaDuty = new DevExpress.Utils.Frames.NotePanel();
            this.textEdit_Graphic_TeaName = new DevExpress.XtraEditors.TextEdit();
            this.comboBoxEdit_Graphic_TeaDuty = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.notePanel6 = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel7 = new DevExpress.Utils.Frames.NotePanel();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.simpleButton_ReportAnalysis = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.saveFileDialog_Report = new System.Windows.Forms.SaveFileDialog();
            this.helpProvider_DutyInfo = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_TeaDutyAsign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl2)).BeginInit();
            this.popupContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl3)).BeginInit();
            this.popupContainerControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl4)).BeginInit();
            this.popupContainerControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl5)).BeginInit();
            this.popupContainerControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl6)).BeginInit();
            this.popupContainerControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl7)).BeginInit();
            this.popupContainerControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_TeaDutyDetailInfo)).BeginInit();
            this.xtraTabControl_TeaDutyDetailInfo.SuspendLayout();
            this.xtraTabPage_TeaDutyDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_TeaDutyAsign)).BeginInit();
            this.groupControl_TeaDutyAsign.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_TeaDutyDetailsMgmt)).BeginInit();
            this.groupControl_TeaDutyDetailsMgmt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl_DutyMgmt)).BeginInit();
            this.splitContainerControl_DutyMgmt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_DutyStartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_AddDutyName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_AddDutyRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_DutyEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_DutyHistory.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_DutyHistory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_DutySearTeaClass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_DutySearTeaGarde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_DutySearTeaID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_DutySearTeaName.Properties)).BeginInit();
            this.xtraTabPage_TeaOnDutyInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_TeaDutyDetailsStatistic)).BeginInit();
            this.groupControl_TeaDutyDetailsStatistic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_TeaOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_TeaShouldAttend.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_TeaAttend.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_TeaAbsence.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_TeaOffTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_TeaOnTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_TeaDutyDetailsSearch)).BeginInit();
            this.groupControl_TeaDutyDetailsSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_TeaDutyDetailsFlowType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_TeaDutyDetailsSerType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_TeaDutyDetailsSearByStartTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_TeaDutyDetailsSearByStartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_TeaDutyDetailsSearByGrade.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_TeaDutyDetailsSearByID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_TeaDutyDetailsSearByName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_TeaDutyDetailsSearByClass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_TeaDutyDetailsSearByEndTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_TeaDutyDetailsSearByEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_TeaDutyDetails)).BeginInit();
            this.groupControl_TeaDutyDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_TeaDutySummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_TeaDutyNormal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl_Remarks)).BeginInit();
            this.popupContainerControl_Remarks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_Remarks.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_TeaDutyDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_TeaDutyOutDetails)).BeginInit();
            this.groupControl_TeaDutyOutDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_TeaOutDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            this.xtraTabPage_TeaOnDutyReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Graph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_TeaDutyReportsSear)).BeginInit();
            this.groupControl_TeaDutyReportsSear.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Graphic_TeaDept.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Graphic_TeaID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Graphic_TeaName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Graphic_TeaDuty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // advBandedGridView1
            // 
            this.advBandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.advBandedGridView1.GridControl = this.gridControl_TeaDutyAsign;
            this.advBandedGridView1.Name = "advBandedGridView1";
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Name = "gridBand1";
            // 
            // gridControl_TeaDutyAsign
            // 
            this.gridControl_TeaDutyAsign.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl_TeaDutyAsign.Location = new System.Drawing.Point(3, 80);
            this.gridControl_TeaDutyAsign.MainView = this.gridView1;
            this.gridControl_TeaDutyAsign.Name = "gridControl_TeaDutyAsign";
            this.gridControl_TeaDutyAsign.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.repositoryItemPopupContainerEdit1,
            this.repositoryItemPopupContainerEdit2,
            this.repositoryItemPopupContainerEdit3,
            this.repositoryItemPopupContainerEdit4,
            this.repositoryItemPopupContainerEdit5,
            this.repositoryItemPopupContainerEdit6,
            this.repositoryItemPopupContainerEdit7});
            this.gridControl_TeaDutyAsign.Size = new System.Drawing.Size(760, 220);
            this.gridControl_TeaDutyAsign.TabIndex = 0;
            this.gridControl_TeaDutyAsign.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.advBandedGridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn1});
            this.gridView1.GridControl = this.gridControl_TeaDutyAsign;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "工号";
            this.gridColumn2.FieldName = "T_Number";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 41;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "教师姓名";
            this.gridColumn3.FieldName = "T_Name";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 59;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "岗位";
            this.gridColumn11.FieldName = "T_Depart";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 2;
            this.gridColumn11.Width = 59;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "部门";
            this.gridColumn12.FieldName = "T_Duty";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 3;
            this.gridColumn12.Width = 56;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "周一班次";
            this.gridColumn4.ColumnEdit = this.repositoryItemPopupContainerEdit1;
            this.gridColumn4.FieldName = "teaonduty_monday";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 83;
            // 
            // repositoryItemPopupContainerEdit1
            // 
            this.repositoryItemPopupContainerEdit1.AutoHeight = false;
            this.repositoryItemPopupContainerEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemPopupContainerEdit1.Name = "repositoryItemPopupContainerEdit1";
            this.repositoryItemPopupContainerEdit1.PopupControl = this.popupContainerControl1;
            this.repositoryItemPopupContainerEdit1.QueryResultValue += new DevExpress.XtraEditors.Controls.QueryResultValueEventHandler(this.repositoryItemPopupContainerEdit1_QueryResultValue);
            this.repositoryItemPopupContainerEdit1.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.repositoryItemPopupContainerEdit1_QueryPopUp);
            // 
            // popupContainerControl1
            // 
            this.popupContainerControl1.Controls.Add(this.checkedListBoxControl1);
            this.popupContainerControl1.Location = new System.Drawing.Point(8, 120);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(200, 100);
            this.popupContainerControl1.TabIndex = 6;
            // 
            // checkedListBoxControl1
            // 
            this.checkedListBoxControl1.CheckOnClick = true;
            this.checkedListBoxControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxControl1.ItemHeight = 16;
            this.checkedListBoxControl1.Location = new System.Drawing.Point(0, 0);
            this.checkedListBoxControl1.Name = "checkedListBoxControl1";
            this.checkedListBoxControl1.Size = new System.Drawing.Size(200, 100);
            this.checkedListBoxControl1.TabIndex = 0;
            this.checkedListBoxControl1.ToolTipController = this.toolTipController1;
            this.checkedListBoxControl1.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Error;
            this.checkedListBoxControl1.Click += new System.EventHandler(this.checkedListBoxControl1_Click);
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "周二班次";
            this.gridColumn5.ColumnEdit = this.repositoryItemPopupContainerEdit2;
            this.gridColumn5.FieldName = "teaonduty_tuesday";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 77;
            // 
            // repositoryItemPopupContainerEdit2
            // 
            this.repositoryItemPopupContainerEdit2.AutoHeight = false;
            this.repositoryItemPopupContainerEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemPopupContainerEdit2.Name = "repositoryItemPopupContainerEdit2";
            this.repositoryItemPopupContainerEdit2.PopupControl = this.popupContainerControl2;
            this.repositoryItemPopupContainerEdit2.QueryResultValue += new DevExpress.XtraEditors.Controls.QueryResultValueEventHandler(this.repositoryItemPopupContainerEdit2_QueryResultValue);
            this.repositoryItemPopupContainerEdit2.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.repositoryItemPopupContainerEdit2_QueryPopUp);
            // 
            // popupContainerControl2
            // 
            this.popupContainerControl2.Controls.Add(this.checkedListBoxControl2);
            this.popupContainerControl2.Location = new System.Drawing.Point(224, 24);
            this.popupContainerControl2.Name = "popupContainerControl2";
            this.popupContainerControl2.Size = new System.Drawing.Size(200, 100);
            this.popupContainerControl2.TabIndex = 7;
            // 
            // checkedListBoxControl2
            // 
            this.checkedListBoxControl2.CheckOnClick = true;
            this.checkedListBoxControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxControl2.ItemHeight = 16;
            this.checkedListBoxControl2.Location = new System.Drawing.Point(0, 0);
            this.checkedListBoxControl2.Name = "checkedListBoxControl2";
            this.checkedListBoxControl2.Size = new System.Drawing.Size(200, 100);
            this.checkedListBoxControl2.TabIndex = 0;
            this.checkedListBoxControl2.ToolTipController = this.toolTipController1;
            this.checkedListBoxControl2.Click += new System.EventHandler(this.checkedListBoxControl2_Click);
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "周三班次";
            this.gridColumn6.ColumnEdit = this.repositoryItemPopupContainerEdit3;
            this.gridColumn6.FieldName = "teaonduty_wednesday";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 74;
            // 
            // repositoryItemPopupContainerEdit3
            // 
            this.repositoryItemPopupContainerEdit3.AutoHeight = false;
            this.repositoryItemPopupContainerEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemPopupContainerEdit3.Name = "repositoryItemPopupContainerEdit3";
            this.repositoryItemPopupContainerEdit3.PopupControl = this.popupContainerControl3;
            this.repositoryItemPopupContainerEdit3.QueryResultValue += new DevExpress.XtraEditors.Controls.QueryResultValueEventHandler(this.repositoryItemPopupContainerEdit3_QueryResultValue);
            this.repositoryItemPopupContainerEdit3.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.repositoryItemPopupContainerEdit3_QueryPopUp);
            // 
            // popupContainerControl3
            // 
            this.popupContainerControl3.Controls.Add(this.checkedListBoxControl3);
            this.popupContainerControl3.Location = new System.Drawing.Point(224, 120);
            this.popupContainerControl3.Name = "popupContainerControl3";
            this.popupContainerControl3.Size = new System.Drawing.Size(200, 100);
            this.popupContainerControl3.TabIndex = 8;
            // 
            // checkedListBoxControl3
            // 
            this.checkedListBoxControl3.CheckOnClick = true;
            this.checkedListBoxControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxControl3.ItemHeight = 16;
            this.checkedListBoxControl3.Location = new System.Drawing.Point(0, 0);
            this.checkedListBoxControl3.Name = "checkedListBoxControl3";
            this.checkedListBoxControl3.Size = new System.Drawing.Size(200, 100);
            this.checkedListBoxControl3.TabIndex = 0;
            this.checkedListBoxControl3.ToolTipController = this.toolTipController1;
            this.checkedListBoxControl3.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Exclamation;
            this.checkedListBoxControl3.Click += new System.EventHandler(this.checkedListBoxControl3_Click);
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "周四班次";
            this.gridColumn7.ColumnEdit = this.repositoryItemPopupContainerEdit4;
            this.gridColumn7.FieldName = "teaonduty_thursday";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            this.gridColumn7.Width = 73;
            // 
            // repositoryItemPopupContainerEdit4
            // 
            this.repositoryItemPopupContainerEdit4.AutoHeight = false;
            this.repositoryItemPopupContainerEdit4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemPopupContainerEdit4.Name = "repositoryItemPopupContainerEdit4";
            this.repositoryItemPopupContainerEdit4.PopupControl = this.popupContainerControl4;
            this.repositoryItemPopupContainerEdit4.QueryResultValue += new DevExpress.XtraEditors.Controls.QueryResultValueEventHandler(this.repositoryItemPopupContainerEdit4_QueryResultValue);
            this.repositoryItemPopupContainerEdit4.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.repositoryItemPopupContainerEdit4_QueryPopUp);
            // 
            // popupContainerControl4
            // 
            this.popupContainerControl4.Controls.Add(this.checkedListBoxControl4);
            this.popupContainerControl4.Location = new System.Drawing.Point(16, 16);
            this.popupContainerControl4.Name = "popupContainerControl4";
            this.popupContainerControl4.Size = new System.Drawing.Size(200, 100);
            this.popupContainerControl4.TabIndex = 9;
            // 
            // checkedListBoxControl4
            // 
            this.checkedListBoxControl4.CheckOnClick = true;
            this.checkedListBoxControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxControl4.ItemHeight = 16;
            this.checkedListBoxControl4.Location = new System.Drawing.Point(0, 0);
            this.checkedListBoxControl4.Name = "checkedListBoxControl4";
            this.checkedListBoxControl4.Size = new System.Drawing.Size(200, 100);
            this.checkedListBoxControl4.TabIndex = 0;
            this.checkedListBoxControl4.ToolTipController = this.toolTipController1;
            this.checkedListBoxControl4.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Application;
            this.checkedListBoxControl4.Click += new System.EventHandler(this.checkedListBoxControl4_Click);
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "周五班次";
            this.gridColumn8.ColumnEdit = this.repositoryItemPopupContainerEdit5;
            this.gridColumn8.FieldName = "teaonduty_friday";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 8;
            this.gridColumn8.Width = 70;
            // 
            // repositoryItemPopupContainerEdit5
            // 
            this.repositoryItemPopupContainerEdit5.AutoHeight = false;
            this.repositoryItemPopupContainerEdit5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemPopupContainerEdit5.Name = "repositoryItemPopupContainerEdit5";
            this.repositoryItemPopupContainerEdit5.PopupControl = this.popupContainerControl5;
            this.repositoryItemPopupContainerEdit5.QueryResultValue += new DevExpress.XtraEditors.Controls.QueryResultValueEventHandler(this.repositoryItemPopupContainerEdit5_QueryResultValue);
            this.repositoryItemPopupContainerEdit5.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.repositoryItemPopupContainerEdit5_QueryPopUp);
            // 
            // popupContainerControl5
            // 
            this.popupContainerControl5.Controls.Add(this.checkedListBoxControl5);
            this.popupContainerControl5.Location = new System.Drawing.Point(0, 224);
            this.popupContainerControl5.Name = "popupContainerControl5";
            this.popupContainerControl5.Size = new System.Drawing.Size(200, 100);
            this.popupContainerControl5.TabIndex = 10;
            // 
            // checkedListBoxControl5
            // 
            this.checkedListBoxControl5.CheckOnClick = true;
            this.checkedListBoxControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxControl5.ItemHeight = 16;
            this.checkedListBoxControl5.Location = new System.Drawing.Point(0, 0);
            this.checkedListBoxControl5.Name = "checkedListBoxControl5";
            this.checkedListBoxControl5.Size = new System.Drawing.Size(200, 100);
            this.checkedListBoxControl5.TabIndex = 0;
            this.checkedListBoxControl5.ToolTipController = this.toolTipController1;
            this.checkedListBoxControl5.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Hand;
            this.checkedListBoxControl5.Click += new System.EventHandler(this.checkedListBoxControl5_Click);
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "周六班次";
            this.gridColumn9.ColumnEdit = this.repositoryItemPopupContainerEdit6;
            this.gridColumn9.FieldName = "teaonduty_saturday";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Width = 70;
            // 
            // repositoryItemPopupContainerEdit6
            // 
            this.repositoryItemPopupContainerEdit6.AutoHeight = false;
            this.repositoryItemPopupContainerEdit6.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemPopupContainerEdit6.Name = "repositoryItemPopupContainerEdit6";
            this.repositoryItemPopupContainerEdit6.PopupControl = this.popupContainerControl6;
            this.repositoryItemPopupContainerEdit6.QueryResultValue += new DevExpress.XtraEditors.Controls.QueryResultValueEventHandler(this.repositoryItemPopupContainerEdit6_QueryResultValue);
            this.repositoryItemPopupContainerEdit6.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.repositoryItemPopupContainerEdit6_QueryPopUp);
            // 
            // popupContainerControl6
            // 
            this.popupContainerControl6.Controls.Add(this.checkedListBoxControl6);
            this.popupContainerControl6.Location = new System.Drawing.Point(232, 232);
            this.popupContainerControl6.Name = "popupContainerControl6";
            this.popupContainerControl6.Size = new System.Drawing.Size(200, 100);
            this.popupContainerControl6.TabIndex = 11;
            // 
            // checkedListBoxControl6
            // 
            this.checkedListBoxControl6.CheckOnClick = true;
            this.checkedListBoxControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxControl6.ItemHeight = 16;
            this.checkedListBoxControl6.Location = new System.Drawing.Point(0, 0);
            this.checkedListBoxControl6.Name = "checkedListBoxControl6";
            this.checkedListBoxControl6.Size = new System.Drawing.Size(200, 100);
            this.checkedListBoxControl6.TabIndex = 0;
            this.checkedListBoxControl6.ToolTipController = this.toolTipController1;
            this.checkedListBoxControl6.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Warning;
            this.checkedListBoxControl6.Click += new System.EventHandler(this.checkedListBoxControl6_Click);
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "周末班次";
            this.gridColumn10.ColumnEdit = this.repositoryItemPopupContainerEdit7;
            this.gridColumn10.FieldName = "teaonduty_sunday";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Width = 83;
            // 
            // repositoryItemPopupContainerEdit7
            // 
            this.repositoryItemPopupContainerEdit7.AutoHeight = false;
            this.repositoryItemPopupContainerEdit7.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemPopupContainerEdit7.Name = "repositoryItemPopupContainerEdit7";
            this.repositoryItemPopupContainerEdit7.PopupControl = this.popupContainerControl7;
            this.repositoryItemPopupContainerEdit7.QueryResultValue += new DevExpress.XtraEditors.Controls.QueryResultValueEventHandler(this.repositoryItemPopupContainerEdit7_QueryResultValue);
            this.repositoryItemPopupContainerEdit7.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.repositoryItemPopupContainerEdit7_QueryPopUp);
            // 
            // popupContainerControl7
            // 
            this.popupContainerControl7.Controls.Add(this.checkedListBoxControl7);
            this.popupContainerControl7.Location = new System.Drawing.Point(432, 48);
            this.popupContainerControl7.Name = "popupContainerControl7";
            this.popupContainerControl7.Size = new System.Drawing.Size(200, 100);
            this.popupContainerControl7.TabIndex = 12;
            // 
            // checkedListBoxControl7
            // 
            this.checkedListBoxControl7.CheckOnClick = true;
            this.checkedListBoxControl7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxControl7.ItemHeight = 16;
            this.checkedListBoxControl7.Location = new System.Drawing.Point(0, 0);
            this.checkedListBoxControl7.Name = "checkedListBoxControl7";
            this.checkedListBoxControl7.Size = new System.Drawing.Size(200, 100);
            this.checkedListBoxControl7.TabIndex = 0;
            this.checkedListBoxControl7.ToolTipController = this.toolTipController1;
            this.checkedListBoxControl7.ToolTipIconType = DevExpress.Utils.ToolTipIconType.WindLogo;
            this.checkedListBoxControl7.Click += new System.EventHandler(this.checkedListBoxControl7_Click);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Teacher_ID";
            this.gridColumn1.FieldName = "T_ID";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // xtraTabControl_TeaDutyDetailInfo
            // 
            this.xtraTabControl_TeaDutyDetailInfo.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xtraTabControl_TeaDutyDetailInfo.Appearance.Options.UseBackColor = true;
            this.xtraTabControl_TeaDutyDetailInfo.AppearancePage.HeaderActive.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.xtraTabControl_TeaDutyDetailInfo.AppearancePage.HeaderActive.ForeColor = System.Drawing.Color.DarkOrange;
            this.xtraTabControl_TeaDutyDetailInfo.AppearancePage.HeaderActive.Options.UseFont = true;
            this.xtraTabControl_TeaDutyDetailInfo.AppearancePage.HeaderActive.Options.UseForeColor = true;
            this.xtraTabControl_TeaDutyDetailInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl_TeaDutyDetailInfo.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl_TeaDutyDetailInfo.Name = "xtraTabControl_TeaDutyDetailInfo";
            this.xtraTabControl_TeaDutyDetailInfo.SelectedTabPage = this.xtraTabPage_TeaOnDutyInfo;
            this.xtraTabControl_TeaDutyDetailInfo.Size = new System.Drawing.Size(772, 540);
            this.xtraTabControl_TeaDutyDetailInfo.TabIndex = 0;
            this.xtraTabControl_TeaDutyDetailInfo.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage_TeaDutyDetails,
            this.xtraTabPage_TeaOnDutyInfo,
            this.xtraTabPage_TeaOnDutyReports});
            // 
            // xtraTabPage_TeaDutyDetails
            // 
            this.xtraTabPage_TeaDutyDetails.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xtraTabPage_TeaDutyDetails.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabPage_TeaDutyDetails.Controls.Add(this.groupControl_TeaDutyAsign);
            this.xtraTabPage_TeaDutyDetails.Controls.Add(this.groupControl_TeaDutyDetailsMgmt);
            this.xtraTabPage_TeaDutyDetails.Name = "xtraTabPage_TeaDutyDetails";
            this.xtraTabPage_TeaDutyDetails.Size = new System.Drawing.Size(766, 511);
            this.xtraTabPage_TeaDutyDetails.Text = "班次管理";
            // 
            // groupControl_TeaDutyAsign
            // 
            this.groupControl_TeaDutyAsign.Controls.Add(this.popupContainerControl7);
            this.groupControl_TeaDutyAsign.Controls.Add(this.popupContainerControl6);
            this.groupControl_TeaDutyAsign.Controls.Add(this.popupContainerControl5);
            this.groupControl_TeaDutyAsign.Controls.Add(this.popupContainerControl4);
            this.groupControl_TeaDutyAsign.Controls.Add(this.popupContainerControl3);
            this.groupControl_TeaDutyAsign.Controls.Add(this.popupContainerControl2);
            this.groupControl_TeaDutyAsign.Controls.Add(this.popupContainerControl1);
            this.groupControl_TeaDutyAsign.Controls.Add(this.simpleButton_SaveDutyAsign);
            this.groupControl_TeaDutyAsign.Controls.Add(this.notePanel2);
            this.groupControl_TeaDutyAsign.Controls.Add(this.gridControl_TeaDutyAsign);
            this.groupControl_TeaDutyAsign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl_TeaDutyAsign.Location = new System.Drawing.Point(0, 208);
            this.groupControl_TeaDutyAsign.Name = "groupControl_TeaDutyAsign";
            this.groupControl_TeaDutyAsign.Size = new System.Drawing.Size(766, 303);
            this.groupControl_TeaDutyAsign.TabIndex = 1;
            this.groupControl_TeaDutyAsign.Text = "班次分配";
            // 
            // simpleButton_SaveDutyAsign
            // 
            this.simpleButton_SaveDutyAsign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton_SaveDutyAsign.Location = new System.Drawing.Point(646, 48);
            this.simpleButton_SaveDutyAsign.Name = "simpleButton_SaveDutyAsign";
            this.simpleButton_SaveDutyAsign.Size = new System.Drawing.Size(96, 24);
            this.simpleButton_SaveDutyAsign.TabIndex = 5;
            this.simpleButton_SaveDutyAsign.Text = "更新当前班次";
            this.simpleButton_SaveDutyAsign.Click += new System.EventHandler(this.simpleButton_SaveDutyAsign_Click);
            // 
            // notePanel2
            // 
            this.notePanel2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.notePanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.notePanel2.ForeColor = System.Drawing.Color.OrangeRed;
            this.notePanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel2.Location = new System.Drawing.Point(2, 22);
            this.notePanel2.MaxRows = 5;
            this.notePanel2.Name = "notePanel2";
            this.notePanel2.ParentAutoHeight = true;
            this.notePanel2.Size = new System.Drawing.Size(762, 23);
            this.notePanel2.TabIndex = 4;
            this.notePanel2.TabStop = false;
            this.notePanel2.Text = "班次信息";
            // 
            // groupControl_TeaDutyDetailsMgmt
            // 
            this.groupControl_TeaDutyDetailsMgmt.Controls.Add(this.splitContainerControl_DutyMgmt);
            this.groupControl_TeaDutyDetailsMgmt.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl_TeaDutyDetailsMgmt.Location = new System.Drawing.Point(0, 0);
            this.groupControl_TeaDutyDetailsMgmt.Name = "groupControl_TeaDutyDetailsMgmt";
            this.groupControl_TeaDutyDetailsMgmt.Size = new System.Drawing.Size(766, 208);
            this.groupControl_TeaDutyDetailsMgmt.TabIndex = 0;
            // 
            // splitContainerControl_DutyMgmt
            // 
            this.splitContainerControl_DutyMgmt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl_DutyMgmt.Location = new System.Drawing.Point(2, 22);
            this.splitContainerControl_DutyMgmt.Name = "splitContainerControl_DutyMgmt";
            this.splitContainerControl_DutyMgmt.Panel1.Controls.Add(this.textEdit_DutyStartTime);
            this.splitContainerControl_DutyMgmt.Panel1.Controls.Add(this.dataNavigator_DutyDetails);
            this.splitContainerControl_DutyMgmt.Panel1.Controls.Add(this.notePanel_DutyDetailsTitle);
            this.splitContainerControl_DutyMgmt.Panel1.Controls.Add(this.pnlHint_DutyName);
            this.splitContainerControl_DutyMgmt.Panel1.Controls.Add(this.label_ReqOfDutyName);
            this.splitContainerControl_DutyMgmt.Panel1.Controls.Add(this.textEdit_AddDutyName);
            this.splitContainerControl_DutyMgmt.Panel1.Controls.Add(this.notePanel_DutyStartTime);
            this.splitContainerControl_DutyMgmt.Panel1.Controls.Add(this.label_ReqOfDutyEndTime);
            this.splitContainerControl_DutyMgmt.Panel1.Controls.Add(this.notePanel_DutyRemark);
            this.splitContainerControl_DutyMgmt.Panel1.Controls.Add(this.textEdit_AddDutyRemark);
            this.splitContainerControl_DutyMgmt.Panel1.Controls.Add(this.notePanel_DutyEndTime);
            this.splitContainerControl_DutyMgmt.Panel1.Controls.Add(this.label_ReqOfDutyStartTime);
            this.splitContainerControl_DutyMgmt.Panel1.Controls.Add(this.textEdit_DutyEndTime);
            this.splitContainerControl_DutyMgmt.Panel1.Text = "splitContainerControl2_Panel1";
            this.splitContainerControl_DutyMgmt.Panel2.Controls.Add(this.simpleButton_TeaDutySave);
            this.splitContainerControl_DutyMgmt.Panel2.Controls.Add(this.simpleButton_LoadCurDuty);
            this.splitContainerControl_DutyMgmt.Panel2.Controls.Add(this.simpleButton_LoadHisDuty);
            this.splitContainerControl_DutyMgmt.Panel2.Controls.Add(this.dateEdit_DutyHistory);
            this.splitContainerControl_DutyMgmt.Panel2.Controls.Add(this.notePanel_DutyHistory);
            this.splitContainerControl_DutyMgmt.Panel2.Controls.Add(this.comboBoxEdit_DutySearTeaClass);
            this.splitContainerControl_DutyMgmt.Panel2.Controls.Add(this.comboBoxEdit_DutySearTeaGarde);
            this.splitContainerControl_DutyMgmt.Panel2.Controls.Add(this.textEdit_DutySearTeaID);
            this.splitContainerControl_DutyMgmt.Panel2.Controls.Add(this.notePanel_AsignDutyByTeaID);
            this.splitContainerControl_DutyMgmt.Panel2.Controls.Add(this.notePanel_TeaDutyAsignSearTitle);
            this.splitContainerControl_DutyMgmt.Panel2.Controls.Add(this.notePannotePanel_AsignDutyByTeaGrade);
            this.splitContainerControl_DutyMgmt.Panel2.Controls.Add(this.notePannotePanel_AsignDutyByTeaName);
            this.splitContainerControl_DutyMgmt.Panel2.Controls.Add(this.notePannotePanel_AsignDutyByTeaClass);
            this.splitContainerControl_DutyMgmt.Panel2.Controls.Add(this.textEdit_DutySearTeaName);
            this.splitContainerControl_DutyMgmt.Panel2.Controls.Add(this.simpleButton_TeaSearForDuty);
            this.splitContainerControl_DutyMgmt.Panel2.Text = "splitContainerControl2_Panel2";
            this.splitContainerControl_DutyMgmt.Size = new System.Drawing.Size(762, 184);
            this.splitContainerControl_DutyMgmt.SplitterPosition = 324;
            this.splitContainerControl_DutyMgmt.TabIndex = 0;
            this.splitContainerControl_DutyMgmt.Text = "splitContainerControl2";
            // 
            // textEdit_DutyStartTime
            // 
            this.textEdit_DutyStartTime.EditValue = "";
            this.textEdit_DutyStartTime.Location = new System.Drawing.Point(120, 61);
            this.textEdit_DutyStartTime.Name = "textEdit_DutyStartTime";
            this.textEdit_DutyStartTime.Properties.DisplayFormat.FormatString = "HH:mm:ss";
            this.textEdit_DutyStartTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.textEdit_DutyStartTime.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.textEdit_DutyStartTime.Properties.Mask.EditMask = "HH:mm:ss";
            this.textEdit_DutyStartTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.textEdit_DutyStartTime.Size = new System.Drawing.Size(160, 20);
            this.textEdit_DutyStartTime.TabIndex = 12;
            // 
            // dataNavigator_DutyDetails
            // 
            this.dataNavigator_DutyDetails.Buttons.Append.Hint = "添加一条新记录";
            this.dataNavigator_DutyDetails.Buttons.CancelEdit.Hint = "取消修改";
            this.dataNavigator_DutyDetails.Buttons.EndEdit.Hint = "保存修改";
            this.dataNavigator_DutyDetails.Buttons.First.Hint = "查看第一条记录";
            this.dataNavigator_DutyDetails.Buttons.Last.Hint = "查看最后一条记录";
            this.dataNavigator_DutyDetails.Buttons.Next.Hint = "查看下一条记录";
            this.dataNavigator_DutyDetails.Buttons.NextPage.Hint = "跳至下一页";
            this.dataNavigator_DutyDetails.Buttons.Prev.Hint = "查看前一条记录";
            this.dataNavigator_DutyDetails.Buttons.PrevPage.Hint = "跳至前一页";
            this.dataNavigator_DutyDetails.Buttons.Remove.Hint = "删除此条记录";
            this.dataNavigator_DutyDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataNavigator_DutyDetails.Location = new System.Drawing.Point(0, 160);
            this.dataNavigator_DutyDetails.Name = "dataNavigator_DutyDetails";
            this.dataNavigator_DutyDetails.ShowToolTips = true;
            this.dataNavigator_DutyDetails.Size = new System.Drawing.Size(324, 24);
            this.dataNavigator_DutyDetails.TabIndex = 10;
            this.dataNavigator_DutyDetails.Text = "班次信息管理";
            this.dataNavigator_DutyDetails.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.End;
            this.dataNavigator_DutyDetails.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dataNavigator_DutyDetails_ButtonClick);
            // 
            // notePanel_DutyDetailsTitle
            // 
            this.notePanel_DutyDetailsTitle.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.notePanel_DutyDetailsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.notePanel_DutyDetailsTitle.ForeColor = System.Drawing.Color.OrangeRed;
            this.notePanel_DutyDetailsTitle.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_DutyDetailsTitle.Location = new System.Drawing.Point(0, 0);
            this.notePanel_DutyDetailsTitle.MaxRows = 5;
            this.notePanel_DutyDetailsTitle.Name = "notePanel_DutyDetailsTitle";
            this.notePanel_DutyDetailsTitle.ParentAutoHeight = true;
            this.notePanel_DutyDetailsTitle.Size = new System.Drawing.Size(324, 23);
            this.notePanel_DutyDetailsTitle.TabIndex = 2;
            this.notePanel_DutyDetailsTitle.TabStop = false;
            this.notePanel_DutyDetailsTitle.Text = "班次详细信息管理(*为必须填写)";
            // 
            // pnlHint_DutyName
            // 
            this.pnlHint_DutyName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlHint_DutyName.BackColor2 = System.Drawing.Color.DarkGray;
            this.pnlHint_DutyName.Font = new System.Drawing.Font("Tahoma", 8F);
            this.pnlHint_DutyName.ForeColor = System.Drawing.Color.Black;
            this.pnlHint_DutyName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pnlHint_DutyName.Location = new System.Drawing.Point(24, 32);
            this.pnlHint_DutyName.MaxRows = 5;
            this.pnlHint_DutyName.Name = "pnlHint_DutyName";
            this.pnlHint_DutyName.ParentAutoHeight = true;
            this.pnlHint_DutyName.Size = new System.Drawing.Size(80, 22);
            this.pnlHint_DutyName.TabIndex = 3;
            this.pnlHint_DutyName.TabStop = false;
            this.pnlHint_DutyName.Text = "班次名称";
            // 
            // label_ReqOfDutyName
            // 
            this.label_ReqOfDutyName.ForeColor = System.Drawing.Color.Red;
            this.label_ReqOfDutyName.Location = new System.Drawing.Point(8, 32);
            this.label_ReqOfDutyName.Name = "label_ReqOfDutyName";
            this.label_ReqOfDutyName.Size = new System.Drawing.Size(16, 16);
            this.label_ReqOfDutyName.TabIndex = 6;
            this.label_ReqOfDutyName.Text = "*";
            this.label_ReqOfDutyName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textEdit_AddDutyName
            // 
            this.textEdit_AddDutyName.EditValue = "";
            this.textEdit_AddDutyName.Location = new System.Drawing.Point(120, 32);
            this.textEdit_AddDutyName.Name = "textEdit_AddDutyName";
            this.textEdit_AddDutyName.Size = new System.Drawing.Size(160, 20);
            this.textEdit_AddDutyName.TabIndex = 4;
            this.textEdit_AddDutyName.EditValueChanged += new System.EventHandler(this.textEdit_AddDutyName_EditValueChanged);
            this.textEdit_AddDutyName.Leave += new System.EventHandler(this.textEdit_AddDutyName_Leave);
            // 
            // notePanel_DutyStartTime
            // 
            this.notePanel_DutyStartTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_DutyStartTime.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_DutyStartTime.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_DutyStartTime.ForeColor = System.Drawing.Color.Black;
            this.notePanel_DutyStartTime.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_DutyStartTime.Location = new System.Drawing.Point(24, 61);
            this.notePanel_DutyStartTime.MaxRows = 5;
            this.notePanel_DutyStartTime.Name = "notePanel_DutyStartTime";
            this.notePanel_DutyStartTime.ParentAutoHeight = true;
            this.notePanel_DutyStartTime.Size = new System.Drawing.Size(80, 22);
            this.notePanel_DutyStartTime.TabIndex = 3;
            this.notePanel_DutyStartTime.TabStop = false;
            this.notePanel_DutyStartTime.Text = "起始时间";
            // 
            // label_ReqOfDutyEndTime
            // 
            this.label_ReqOfDutyEndTime.ForeColor = System.Drawing.Color.Red;
            this.label_ReqOfDutyEndTime.Location = new System.Drawing.Point(8, 64);
            this.label_ReqOfDutyEndTime.Name = "label_ReqOfDutyEndTime";
            this.label_ReqOfDutyEndTime.Size = new System.Drawing.Size(16, 16);
            this.label_ReqOfDutyEndTime.TabIndex = 8;
            this.label_ReqOfDutyEndTime.Text = "*";
            this.label_ReqOfDutyEndTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // notePanel_DutyRemark
            // 
            this.notePanel_DutyRemark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_DutyRemark.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_DutyRemark.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_DutyRemark.ForeColor = System.Drawing.Color.Black;
            this.notePanel_DutyRemark.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_DutyRemark.Location = new System.Drawing.Point(24, 119);
            this.notePanel_DutyRemark.MaxRows = 5;
            this.notePanel_DutyRemark.Name = "notePanel_DutyRemark";
            this.notePanel_DutyRemark.ParentAutoHeight = true;
            this.notePanel_DutyRemark.Size = new System.Drawing.Size(80, 22);
            this.notePanel_DutyRemark.TabIndex = 3;
            this.notePanel_DutyRemark.TabStop = false;
            this.notePanel_DutyRemark.Text = "  备  注";
            // 
            // textEdit_AddDutyRemark
            // 
            this.textEdit_AddDutyRemark.EditValue = "";
            this.textEdit_AddDutyRemark.Location = new System.Drawing.Point(120, 120);
            this.textEdit_AddDutyRemark.Name = "textEdit_AddDutyRemark";
            this.textEdit_AddDutyRemark.Size = new System.Drawing.Size(160, 20);
            this.textEdit_AddDutyRemark.TabIndex = 4;
            // 
            // notePanel_DutyEndTime
            // 
            this.notePanel_DutyEndTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_DutyEndTime.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_DutyEndTime.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_DutyEndTime.ForeColor = System.Drawing.Color.Black;
            this.notePanel_DutyEndTime.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_DutyEndTime.Location = new System.Drawing.Point(24, 90);
            this.notePanel_DutyEndTime.MaxRows = 5;
            this.notePanel_DutyEndTime.Name = "notePanel_DutyEndTime";
            this.notePanel_DutyEndTime.ParentAutoHeight = true;
            this.notePanel_DutyEndTime.Size = new System.Drawing.Size(80, 22);
            this.notePanel_DutyEndTime.TabIndex = 3;
            this.notePanel_DutyEndTime.TabStop = false;
            this.notePanel_DutyEndTime.Text = "结束时间";
            // 
            // label_ReqOfDutyStartTime
            // 
            this.label_ReqOfDutyStartTime.ForeColor = System.Drawing.Color.Red;
            this.label_ReqOfDutyStartTime.Location = new System.Drawing.Point(8, 88);
            this.label_ReqOfDutyStartTime.Name = "label_ReqOfDutyStartTime";
            this.label_ReqOfDutyStartTime.Size = new System.Drawing.Size(16, 16);
            this.label_ReqOfDutyStartTime.TabIndex = 7;
            this.label_ReqOfDutyStartTime.Text = "*";
            this.label_ReqOfDutyStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textEdit_DutyEndTime
            // 
            this.textEdit_DutyEndTime.EditValue = "";
            this.textEdit_DutyEndTime.Location = new System.Drawing.Point(120, 90);
            this.textEdit_DutyEndTime.Name = "textEdit_DutyEndTime";
            this.textEdit_DutyEndTime.Properties.DisplayFormat.FormatString = "d";
            this.textEdit_DutyEndTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.textEdit_DutyEndTime.Properties.Mask.EditMask = "HH:mm:ss";
            this.textEdit_DutyEndTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.textEdit_DutyEndTime.Size = new System.Drawing.Size(160, 20);
            this.textEdit_DutyEndTime.TabIndex = 16;
            this.textEdit_DutyEndTime.Tag = "";
            // 
            // simpleButton_TeaDutySave
            // 
            this.simpleButton_TeaDutySave.Location = new System.Drawing.Point(224, 136);
            this.simpleButton_TeaDutySave.Name = "simpleButton_TeaDutySave";
            this.simpleButton_TeaDutySave.Size = new System.Drawing.Size(88, 24);
            this.simpleButton_TeaDutySave.TabIndex = 13;
            this.simpleButton_TeaDutySave.Text = "下周班保存";
            this.simpleButton_TeaDutySave.Click += new System.EventHandler(this.simpleButton_TeaDutySave_Click);
            // 
            // simpleButton_LoadCurDuty
            // 
            this.simpleButton_LoadCurDuty.Enabled = false;
            this.simpleButton_LoadCurDuty.Location = new System.Drawing.Point(128, 136);
            this.simpleButton_LoadCurDuty.Name = "simpleButton_LoadCurDuty";
            this.simpleButton_LoadCurDuty.Size = new System.Drawing.Size(88, 24);
            this.simpleButton_LoadCurDuty.TabIndex = 12;
            this.simpleButton_LoadCurDuty.Text = "本周班载入";
            this.simpleButton_LoadCurDuty.Click += new System.EventHandler(this.simpleButton_LoadCurDuty_Click);
            // 
            // simpleButton_LoadHisDuty
            // 
            this.simpleButton_LoadHisDuty.Location = new System.Drawing.Point(32, 136);
            this.simpleButton_LoadHisDuty.Name = "simpleButton_LoadHisDuty";
            this.simpleButton_LoadHisDuty.Size = new System.Drawing.Size(88, 24);
            this.simpleButton_LoadHisDuty.TabIndex = 11;
            this.simpleButton_LoadHisDuty.Text = "历史班载入";
            this.simpleButton_LoadHisDuty.Click += new System.EventHandler(this.simpleButton_LoadHisDuty_Click);
            // 
            // dateEdit_DutyHistory
            // 
            this.dateEdit_DutyHistory.EditValue = new System.DateTime(2006, 3, 23, 0, 0, 0, 0);
            this.dateEdit_DutyHistory.Location = new System.Drawing.Point(120, 96);
            this.dateEdit_DutyHistory.Name = "dateEdit_DutyHistory";
            this.dateEdit_DutyHistory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_DutyHistory.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit_DutyHistory.Size = new System.Drawing.Size(88, 20);
            this.dateEdit_DutyHistory.TabIndex = 10;
            // 
            // notePanel_DutyHistory
            // 
            this.notePanel_DutyHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_DutyHistory.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_DutyHistory.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_DutyHistory.ForeColor = System.Drawing.Color.Black;
            this.notePanel_DutyHistory.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_DutyHistory.Location = new System.Drawing.Point(32, 96);
            this.notePanel_DutyHistory.MaxRows = 5;
            this.notePanel_DutyHistory.Name = "notePanel_DutyHistory";
            this.notePanel_DutyHistory.ParentAutoHeight = true;
            this.notePanel_DutyHistory.Size = new System.Drawing.Size(80, 22);
            this.notePanel_DutyHistory.TabIndex = 9;
            this.notePanel_DutyHistory.TabStop = false;
            this.notePanel_DutyHistory.Text = "班次时间";
            // 
            // comboBoxEdit_DutySearTeaClass
            // 
            this.comboBoxEdit_DutySearTeaClass.EditValue = "全部";
            this.comboBoxEdit_DutySearTeaClass.Location = new System.Drawing.Point(312, 64);
            this.comboBoxEdit_DutySearTeaClass.Name = "comboBoxEdit_DutySearTeaClass";
            this.comboBoxEdit_DutySearTeaClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_DutySearTeaClass.Properties.Items.AddRange(new object[] {
            "全部"});
            this.comboBoxEdit_DutySearTeaClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_DutySearTeaClass.Size = new System.Drawing.Size(88, 20);
            this.comboBoxEdit_DutySearTeaClass.TabIndex = 7;
            this.comboBoxEdit_DutySearTeaClass.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_DutySearTeaClass_SelectedIndexChanged);
            // 
            // comboBoxEdit_DutySearTeaGarde
            // 
            this.comboBoxEdit_DutySearTeaGarde.EditValue = "全部";
            this.comboBoxEdit_DutySearTeaGarde.Location = new System.Drawing.Point(120, 64);
            this.comboBoxEdit_DutySearTeaGarde.Name = "comboBoxEdit_DutySearTeaGarde";
            this.comboBoxEdit_DutySearTeaGarde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_DutySearTeaGarde.Properties.Items.AddRange(new object[] {
            "全部"});
            this.comboBoxEdit_DutySearTeaGarde.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_DutySearTeaGarde.Size = new System.Drawing.Size(88, 20);
            this.comboBoxEdit_DutySearTeaGarde.TabIndex = 6;
            this.comboBoxEdit_DutySearTeaGarde.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_DutySearTeaGarde_SelectedIndexChanged);
            // 
            // textEdit_DutySearTeaID
            // 
            this.textEdit_DutySearTeaID.EditValue = "";
            this.textEdit_DutySearTeaID.Location = new System.Drawing.Point(120, 32);
            this.textEdit_DutySearTeaID.Name = "textEdit_DutySearTeaID";
            this.textEdit_DutySearTeaID.Size = new System.Drawing.Size(88, 20);
            this.textEdit_DutySearTeaID.TabIndex = 5;
            // 
            // notePanel_AsignDutyByTeaID
            // 
            this.notePanel_AsignDutyByTeaID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_AsignDutyByTeaID.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_AsignDutyByTeaID.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_AsignDutyByTeaID.ForeColor = System.Drawing.Color.Black;
            this.notePanel_AsignDutyByTeaID.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_AsignDutyByTeaID.Location = new System.Drawing.Point(32, 32);
            this.notePanel_AsignDutyByTeaID.MaxRows = 5;
            this.notePanel_AsignDutyByTeaID.Name = "notePanel_AsignDutyByTeaID";
            this.notePanel_AsignDutyByTeaID.ParentAutoHeight = true;
            this.notePanel_AsignDutyByTeaID.Size = new System.Drawing.Size(80, 22);
            this.notePanel_AsignDutyByTeaID.TabIndex = 4;
            this.notePanel_AsignDutyByTeaID.TabStop = false;
            this.notePanel_AsignDutyByTeaID.Text = "教师工号";
            // 
            // notePanel_TeaDutyAsignSearTitle
            // 
            this.notePanel_TeaDutyAsignSearTitle.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.notePanel_TeaDutyAsignSearTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.notePanel_TeaDutyAsignSearTitle.ForeColor = System.Drawing.Color.OrangeRed;
            this.notePanel_TeaDutyAsignSearTitle.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_TeaDutyAsignSearTitle.Location = new System.Drawing.Point(0, 0);
            this.notePanel_TeaDutyAsignSearTitle.MaxRows = 5;
            this.notePanel_TeaDutyAsignSearTitle.Name = "notePanel_TeaDutyAsignSearTitle";
            this.notePanel_TeaDutyAsignSearTitle.ParentAutoHeight = true;
            this.notePanel_TeaDutyAsignSearTitle.Size = new System.Drawing.Size(433, 23);
            this.notePanel_TeaDutyAsignSearTitle.TabIndex = 3;
            this.notePanel_TeaDutyAsignSearTitle.TabStop = false;
            this.notePanel_TeaDutyAsignSearTitle.Text = "**班次载入时间以一周为准";
            // 
            // notePannotePanel_AsignDutyByTeaGrade
            // 
            this.notePannotePanel_AsignDutyByTeaGrade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePannotePanel_AsignDutyByTeaGrade.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePannotePanel_AsignDutyByTeaGrade.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePannotePanel_AsignDutyByTeaGrade.ForeColor = System.Drawing.Color.Black;
            this.notePannotePanel_AsignDutyByTeaGrade.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePannotePanel_AsignDutyByTeaGrade.Location = new System.Drawing.Point(32, 64);
            this.notePannotePanel_AsignDutyByTeaGrade.MaxRows = 5;
            this.notePannotePanel_AsignDutyByTeaGrade.Name = "notePannotePanel_AsignDutyByTeaGrade";
            this.notePannotePanel_AsignDutyByTeaGrade.ParentAutoHeight = true;
            this.notePannotePanel_AsignDutyByTeaGrade.Size = new System.Drawing.Size(80, 22);
            this.notePannotePanel_AsignDutyByTeaGrade.TabIndex = 4;
            this.notePannotePanel_AsignDutyByTeaGrade.TabStop = false;
            this.notePannotePanel_AsignDutyByTeaGrade.Text = "所在部门";
            // 
            // notePannotePanel_AsignDutyByTeaName
            // 
            this.notePannotePanel_AsignDutyByTeaName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePannotePanel_AsignDutyByTeaName.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePannotePanel_AsignDutyByTeaName.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePannotePanel_AsignDutyByTeaName.ForeColor = System.Drawing.Color.Black;
            this.notePannotePanel_AsignDutyByTeaName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePannotePanel_AsignDutyByTeaName.Location = new System.Drawing.Point(224, 32);
            this.notePannotePanel_AsignDutyByTeaName.MaxRows = 5;
            this.notePannotePanel_AsignDutyByTeaName.Name = "notePannotePanel_AsignDutyByTeaName";
            this.notePannotePanel_AsignDutyByTeaName.ParentAutoHeight = true;
            this.notePannotePanel_AsignDutyByTeaName.Size = new System.Drawing.Size(80, 22);
            this.notePannotePanel_AsignDutyByTeaName.TabIndex = 4;
            this.notePannotePanel_AsignDutyByTeaName.TabStop = false;
            this.notePannotePanel_AsignDutyByTeaName.Text = "教师姓名";
            // 
            // notePannotePanel_AsignDutyByTeaClass
            // 
            this.notePannotePanel_AsignDutyByTeaClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePannotePanel_AsignDutyByTeaClass.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePannotePanel_AsignDutyByTeaClass.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePannotePanel_AsignDutyByTeaClass.ForeColor = System.Drawing.Color.Black;
            this.notePannotePanel_AsignDutyByTeaClass.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePannotePanel_AsignDutyByTeaClass.Location = new System.Drawing.Point(224, 64);
            this.notePannotePanel_AsignDutyByTeaClass.MaxRows = 5;
            this.notePannotePanel_AsignDutyByTeaClass.Name = "notePannotePanel_AsignDutyByTeaClass";
            this.notePannotePanel_AsignDutyByTeaClass.ParentAutoHeight = true;
            this.notePannotePanel_AsignDutyByTeaClass.Size = new System.Drawing.Size(80, 22);
            this.notePannotePanel_AsignDutyByTeaClass.TabIndex = 4;
            this.notePannotePanel_AsignDutyByTeaClass.TabStop = false;
            this.notePannotePanel_AsignDutyByTeaClass.Text = "岗位";
            // 
            // textEdit_DutySearTeaName
            // 
            this.textEdit_DutySearTeaName.EditValue = "";
            this.textEdit_DutySearTeaName.Location = new System.Drawing.Point(312, 32);
            this.textEdit_DutySearTeaName.Name = "textEdit_DutySearTeaName";
            this.textEdit_DutySearTeaName.Size = new System.Drawing.Size(88, 20);
            this.textEdit_DutySearTeaName.TabIndex = 5;
            // 
            // simpleButton_TeaSearForDuty
            // 
            this.simpleButton_TeaSearForDuty.Location = new System.Drawing.Point(320, 136);
            this.simpleButton_TeaSearForDuty.Name = "simpleButton_TeaSearForDuty";
            this.simpleButton_TeaSearForDuty.Size = new System.Drawing.Size(88, 24);
            this.simpleButton_TeaSearForDuty.TabIndex = 8;
            this.simpleButton_TeaSearForDuty.Text = "班次检索";
            this.simpleButton_TeaSearForDuty.Click += new System.EventHandler(this.simpleButton_TeaSearForDuty_Click);
            // 
            // xtraTabPage_TeaOnDutyInfo
            // 
            this.xtraTabPage_TeaOnDutyInfo.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xtraTabPage_TeaOnDutyInfo.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabPage_TeaOnDutyInfo.Controls.Add(this.groupControl_TeaDutyDetailsStatistic);
            this.xtraTabPage_TeaOnDutyInfo.Controls.Add(this.groupControl_TeaDutyDetailsSearch);
            this.xtraTabPage_TeaOnDutyInfo.Controls.Add(this.groupControl_TeaDutyDetails);
            this.xtraTabPage_TeaOnDutyInfo.Controls.Add(this.groupControl_TeaDutyOutDetails);
            this.xtraTabPage_TeaOnDutyInfo.Name = "xtraTabPage_TeaOnDutyInfo";
            this.xtraTabPage_TeaOnDutyInfo.Size = new System.Drawing.Size(766, 511);
            this.xtraTabPage_TeaOnDutyInfo.Text = "出勤信息";
            // 
            // groupControl_TeaDutyDetailsStatistic
            // 
            this.groupControl_TeaDutyDetailsStatistic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl_TeaDutyDetailsStatistic.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_TeaDutyDetailsStatistic.AppearanceCaption.Options.UseFont = true;
            this.groupControl_TeaDutyDetailsStatistic.Controls.Add(this.textEdit_TeaOut);
            this.groupControl_TeaDutyDetailsStatistic.Controls.Add(this.textEdit_TeaShouldAttend);
            this.groupControl_TeaDutyDetailsStatistic.Controls.Add(this.textEdit_TeaAttend);
            this.groupControl_TeaDutyDetailsStatistic.Controls.Add(this.textEdit_TeaAbsence);
            this.groupControl_TeaDutyDetailsStatistic.Controls.Add(this.textEdit_TeaOffTime);
            this.groupControl_TeaDutyDetailsStatistic.Controls.Add(this.textEdit_TeaOnTime);
            this.groupControl_TeaDutyDetailsStatistic.Controls.Add(this.notePanel_TeaOut);
            this.groupControl_TeaDutyDetailsStatistic.Controls.Add(this.notePanel_TeaShouldAttend);
            this.groupControl_TeaDutyDetailsStatistic.Controls.Add(this.notePanel_TeaOnTime);
            this.groupControl_TeaDutyDetailsStatistic.Controls.Add(this.notePanel_TeaOffTime);
            this.groupControl_TeaDutyDetailsStatistic.Controls.Add(this.notePanel_TeaAttend);
            this.groupControl_TeaDutyDetailsStatistic.Controls.Add(this.notePanel_TeaAbsence);
            this.groupControl_TeaDutyDetailsStatistic.Location = new System.Drawing.Point(480, 304);
            this.groupControl_TeaDutyDetailsStatistic.Name = "groupControl_TeaDutyDetailsStatistic";
            this.groupControl_TeaDutyDetailsStatistic.Size = new System.Drawing.Size(288, 208);
            this.groupControl_TeaDutyDetailsStatistic.TabIndex = 1;
            this.groupControl_TeaDutyDetailsStatistic.Text = "出勤数据统计";
            // 
            // textEdit_TeaOut
            // 
            this.textEdit_TeaOut.EditValue = "";
            this.textEdit_TeaOut.Location = new System.Drawing.Point(160, 248);
            this.textEdit_TeaOut.Name = "textEdit_TeaOut";
            this.textEdit_TeaOut.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_TeaOut.Properties.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
            this.textEdit_TeaOut.Properties.Appearance.Options.UseFont = true;
            this.textEdit_TeaOut.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit_TeaOut.Size = new System.Drawing.Size(120, 20);
            this.textEdit_TeaOut.TabIndex = 13;
            // 
            // textEdit_TeaShouldAttend
            // 
            this.textEdit_TeaShouldAttend.EditValue = "";
            this.textEdit_TeaShouldAttend.Location = new System.Drawing.Point(160, 200);
            this.textEdit_TeaShouldAttend.Name = "textEdit_TeaShouldAttend";
            this.textEdit_TeaShouldAttend.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_TeaShouldAttend.Properties.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
            this.textEdit_TeaShouldAttend.Properties.Appearance.Options.UseFont = true;
            this.textEdit_TeaShouldAttend.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit_TeaShouldAttend.Size = new System.Drawing.Size(120, 20);
            this.textEdit_TeaShouldAttend.TabIndex = 12;
            // 
            // textEdit_TeaAttend
            // 
            this.textEdit_TeaAttend.EditValue = "";
            this.textEdit_TeaAttend.Location = new System.Drawing.Point(160, 160);
            this.textEdit_TeaAttend.Name = "textEdit_TeaAttend";
            this.textEdit_TeaAttend.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_TeaAttend.Properties.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
            this.textEdit_TeaAttend.Properties.Appearance.Options.UseFont = true;
            this.textEdit_TeaAttend.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit_TeaAttend.Size = new System.Drawing.Size(120, 20);
            this.textEdit_TeaAttend.TabIndex = 11;
            // 
            // textEdit_TeaAbsence
            // 
            this.textEdit_TeaAbsence.EditValue = "";
            this.textEdit_TeaAbsence.Location = new System.Drawing.Point(160, 120);
            this.textEdit_TeaAbsence.Name = "textEdit_TeaAbsence";
            this.textEdit_TeaAbsence.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_TeaAbsence.Properties.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
            this.textEdit_TeaAbsence.Properties.Appearance.Options.UseFont = true;
            this.textEdit_TeaAbsence.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit_TeaAbsence.Size = new System.Drawing.Size(120, 20);
            this.textEdit_TeaAbsence.TabIndex = 10;
            // 
            // textEdit_TeaOffTime
            // 
            this.textEdit_TeaOffTime.EditValue = "";
            this.textEdit_TeaOffTime.Location = new System.Drawing.Point(160, 80);
            this.textEdit_TeaOffTime.Name = "textEdit_TeaOffTime";
            this.textEdit_TeaOffTime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_TeaOffTime.Properties.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
            this.textEdit_TeaOffTime.Properties.Appearance.Options.UseFont = true;
            this.textEdit_TeaOffTime.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit_TeaOffTime.Size = new System.Drawing.Size(120, 20);
            this.textEdit_TeaOffTime.TabIndex = 9;
            // 
            // textEdit_TeaOnTime
            // 
            this.textEdit_TeaOnTime.EditValue = "";
            this.textEdit_TeaOnTime.Location = new System.Drawing.Point(160, 40);
            this.textEdit_TeaOnTime.Name = "textEdit_TeaOnTime";
            this.textEdit_TeaOnTime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_TeaOnTime.Properties.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
            this.textEdit_TeaOnTime.Properties.Appearance.Options.UseFont = true;
            this.textEdit_TeaOnTime.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit_TeaOnTime.Size = new System.Drawing.Size(120, 20);
            this.textEdit_TeaOnTime.TabIndex = 8;
            // 
            // notePanel_TeaOut
            // 
            this.notePanel_TeaOut.BackColor = System.Drawing.Color.Orange;
            this.notePanel_TeaOut.ForeColor = System.Drawing.Color.White;
            this.notePanel_TeaOut.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_TeaOut.Location = new System.Drawing.Point(56, 248);
            this.notePanel_TeaOut.MaxRows = 5;
            this.notePanel_TeaOut.Name = "notePanel_TeaOut";
            this.notePanel_TeaOut.ParentAutoHeight = true;
            this.notePanel_TeaOut.Size = new System.Drawing.Size(88, 23);
            this.notePanel_TeaOut.TabIndex = 7;
            this.notePanel_TeaOut.TabStop = false;
            this.notePanel_TeaOut.Text = "  外  出";
            // 
            // notePanel_TeaShouldAttend
            // 
            this.notePanel_TeaShouldAttend.BackColor = System.Drawing.Color.Orange;
            this.notePanel_TeaShouldAttend.ForeColor = System.Drawing.Color.White;
            this.notePanel_TeaShouldAttend.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_TeaShouldAttend.Location = new System.Drawing.Point(56, 200);
            this.notePanel_TeaShouldAttend.MaxRows = 5;
            this.notePanel_TeaShouldAttend.Name = "notePanel_TeaShouldAttend";
            this.notePanel_TeaShouldAttend.ParentAutoHeight = true;
            this.notePanel_TeaShouldAttend.Size = new System.Drawing.Size(88, 23);
            this.notePanel_TeaShouldAttend.TabIndex = 6;
            this.notePanel_TeaShouldAttend.TabStop = false;
            this.notePanel_TeaShouldAttend.Text = " 应出勤";
            // 
            // notePanel_TeaOnTime
            // 
            this.notePanel_TeaOnTime.BackColor = System.Drawing.Color.Orange;
            this.notePanel_TeaOnTime.ForeColor = System.Drawing.Color.White;
            this.notePanel_TeaOnTime.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_TeaOnTime.Location = new System.Drawing.Point(56, 40);
            this.notePanel_TeaOnTime.MaxRows = 5;
            this.notePanel_TeaOnTime.Name = "notePanel_TeaOnTime";
            this.notePanel_TeaOnTime.ParentAutoHeight = true;
            this.notePanel_TeaOnTime.Size = new System.Drawing.Size(88, 23);
            this.notePanel_TeaOnTime.TabIndex = 5;
            this.notePanel_TeaOnTime.TabStop = false;
            this.notePanel_TeaOnTime.Text = "  迟  到";
            // 
            // notePanel_TeaOffTime
            // 
            this.notePanel_TeaOffTime.BackColor = System.Drawing.Color.Orange;
            this.notePanel_TeaOffTime.ForeColor = System.Drawing.Color.White;
            this.notePanel_TeaOffTime.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_TeaOffTime.Location = new System.Drawing.Point(56, 80);
            this.notePanel_TeaOffTime.MaxRows = 5;
            this.notePanel_TeaOffTime.Name = "notePanel_TeaOffTime";
            this.notePanel_TeaOffTime.ParentAutoHeight = true;
            this.notePanel_TeaOffTime.Size = new System.Drawing.Size(88, 23);
            this.notePanel_TeaOffTime.TabIndex = 5;
            this.notePanel_TeaOffTime.TabStop = false;
            this.notePanel_TeaOffTime.Text = "  早  退";
            // 
            // notePanel_TeaAttend
            // 
            this.notePanel_TeaAttend.BackColor = System.Drawing.Color.Orange;
            this.notePanel_TeaAttend.ForeColor = System.Drawing.Color.White;
            this.notePanel_TeaAttend.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_TeaAttend.Location = new System.Drawing.Point(56, 160);
            this.notePanel_TeaAttend.MaxRows = 5;
            this.notePanel_TeaAttend.Name = "notePanel_TeaAttend";
            this.notePanel_TeaAttend.ParentAutoHeight = true;
            this.notePanel_TeaAttend.Size = new System.Drawing.Size(88, 23);
            this.notePanel_TeaAttend.TabIndex = 5;
            this.notePanel_TeaAttend.TabStop = false;
            this.notePanel_TeaAttend.Text = " 实出勤";
            // 
            // notePanel_TeaAbsence
            // 
            this.notePanel_TeaAbsence.BackColor = System.Drawing.Color.Orange;
            this.notePanel_TeaAbsence.ForeColor = System.Drawing.Color.White;
            this.notePanel_TeaAbsence.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_TeaAbsence.Location = new System.Drawing.Point(56, 120);
            this.notePanel_TeaAbsence.MaxRows = 5;
            this.notePanel_TeaAbsence.Name = "notePanel_TeaAbsence";
            this.notePanel_TeaAbsence.ParentAutoHeight = true;
            this.notePanel_TeaAbsence.Size = new System.Drawing.Size(88, 23);
            this.notePanel_TeaAbsence.TabIndex = 5;
            this.notePanel_TeaAbsence.TabStop = false;
            this.notePanel_TeaAbsence.Text = "  缺  勤";
            // 
            // groupControl_TeaDutyDetailsSearch
            // 
            this.groupControl_TeaDutyDetailsSearch.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_TeaDutyDetailsSearch.AppearanceCaption.Options.UseFont = true;
            this.groupControl_TeaDutyDetailsSearch.Controls.Add(this.simpleButton4);
            this.groupControl_TeaDutyDetailsSearch.Controls.Add(this.comboBoxEdit_TeaDutyDetailsFlowType);
            this.groupControl_TeaDutyDetailsSearch.Controls.Add(this.notePanel_TeaDutyDetailsFlowType);
            this.groupControl_TeaDutyDetailsSearch.Controls.Add(this.comboBoxEdit_TeaDutyDetailsSerType);
            this.groupControl_TeaDutyDetailsSearch.Controls.Add(this.notePanel_TeaDutyDetailsSerType);
            this.groupControl_TeaDutyDetailsSearch.Controls.Add(this.simpleButton_SearTeaDutyDetails);
            this.groupControl_TeaDutyDetailsSearch.Controls.Add(this.dateEdit_TeaDutyDetailsSearByStartTime);
            this.groupControl_TeaDutyDetailsSearch.Controls.Add(this.comboBoxEdit_TeaDutyDetailsSearByGrade);
            this.groupControl_TeaDutyDetailsSearch.Controls.Add(this.textEdit_TeaDutyDetailsSearByID);
            this.groupControl_TeaDutyDetailsSearch.Controls.Add(this.notePanel_TeaDutyDetailsSearByID);
            this.groupControl_TeaDutyDetailsSearch.Controls.Add(this.notePanel_TeaDutyDetailSearByName);
            this.groupControl_TeaDutyDetailsSearch.Controls.Add(this.notePanel_TeaDutyDetailsSearByGrade);
            this.groupControl_TeaDutyDetailsSearch.Controls.Add(this.notePanel_TeaDutyDetailsSearByClass);
            this.groupControl_TeaDutyDetailsSearch.Controls.Add(this.notePanel_TeaDutyDetailsSearByStartTime);
            this.groupControl_TeaDutyDetailsSearch.Controls.Add(this.notePanel_TeaDutyDetailsSearByEndTime);
            this.groupControl_TeaDutyDetailsSearch.Controls.Add(this.textEdit_TeaDutyDetailsSearByName);
            this.groupControl_TeaDutyDetailsSearch.Controls.Add(this.comboBoxEdit_TeaDutyDetailsSearByClass);
            this.groupControl_TeaDutyDetailsSearch.Controls.Add(this.dateEdit_TeaDutyDetailsSearByEndTime);
            this.groupControl_TeaDutyDetailsSearch.Controls.Add(this.simpleButton1);
            this.groupControl_TeaDutyDetailsSearch.Controls.Add(this.simpleButton3);
            this.groupControl_TeaDutyDetailsSearch.Location = new System.Drawing.Point(0, 0);
            this.groupControl_TeaDutyDetailsSearch.Name = "groupControl_TeaDutyDetailsSearch";
            this.groupControl_TeaDutyDetailsSearch.Size = new System.Drawing.Size(264, 304);
            this.groupControl_TeaDutyDetailsSearch.TabIndex = 0;
            this.groupControl_TeaDutyDetailsSearch.Text = "出勤信息检索条件";
            // 
            // simpleButton4
            // 
            this.simpleButton4.Location = new System.Drawing.Point(200, 272);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(60, 23);
            this.simpleButton4.TabIndex = 13;
            this.simpleButton4.Text = "统计报表";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // comboBoxEdit_TeaDutyDetailsFlowType
            // 
            this.comboBoxEdit_TeaDutyDetailsFlowType.EditValue = "全部";
            this.comboBoxEdit_TeaDutyDetailsFlowType.Location = new System.Drawing.Point(136, 214);
            this.comboBoxEdit_TeaDutyDetailsFlowType.Name = "comboBoxEdit_TeaDutyDetailsFlowType";
            this.comboBoxEdit_TeaDutyDetailsFlowType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_TeaDutyDetailsFlowType.Properties.Items.AddRange(new object[] {
            "上班",
            "下班",
            "全部"});
            this.comboBoxEdit_TeaDutyDetailsFlowType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_TeaDutyDetailsFlowType.Size = new System.Drawing.Size(112, 20);
            this.comboBoxEdit_TeaDutyDetailsFlowType.TabIndex = 12;
            // 
            // notePanel_TeaDutyDetailsFlowType
            // 
            this.notePanel_TeaDutyDetailsFlowType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_TeaDutyDetailsFlowType.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_TeaDutyDetailsFlowType.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_TeaDutyDetailsFlowType.ForeColor = System.Drawing.Color.Black;
            this.notePanel_TeaDutyDetailsFlowType.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_TeaDutyDetailsFlowType.Location = new System.Drawing.Point(32, 214);
            this.notePanel_TeaDutyDetailsFlowType.MaxRows = 5;
            this.notePanel_TeaDutyDetailsFlowType.Name = "notePanel_TeaDutyDetailsFlowType";
            this.notePanel_TeaDutyDetailsFlowType.ParentAutoHeight = true;
            this.notePanel_TeaDutyDetailsFlowType.Size = new System.Drawing.Size(88, 22);
            this.notePanel_TeaDutyDetailsFlowType.TabIndex = 11;
            this.notePanel_TeaDutyDetailsFlowType.TabStop = false;
            this.notePanel_TeaDutyDetailsFlowType.Text = "状          态";
            // 
            // comboBoxEdit_TeaDutyDetailsSerType
            // 
            this.comboBoxEdit_TeaDutyDetailsSerType.EditValue = "一般查询";
            this.comboBoxEdit_TeaDutyDetailsSerType.Location = new System.Drawing.Point(136, 246);
            this.comboBoxEdit_TeaDutyDetailsSerType.Name = "comboBoxEdit_TeaDutyDetailsSerType";
            this.comboBoxEdit_TeaDutyDetailsSerType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_TeaDutyDetailsSerType.Properties.Items.AddRange(new object[] {
            "一般查询",
            "精确查询",
            "综合查询"});
            this.comboBoxEdit_TeaDutyDetailsSerType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_TeaDutyDetailsSerType.Size = new System.Drawing.Size(112, 20);
            this.comboBoxEdit_TeaDutyDetailsSerType.TabIndex = 10;
            this.comboBoxEdit_TeaDutyDetailsSerType.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_TeaDutyDetailsSerType_SelectedIndexChanged);
            // 
            // notePanel_TeaDutyDetailsSerType
            // 
            this.notePanel_TeaDutyDetailsSerType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_TeaDutyDetailsSerType.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_TeaDutyDetailsSerType.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_TeaDutyDetailsSerType.ForeColor = System.Drawing.Color.Black;
            this.notePanel_TeaDutyDetailsSerType.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_TeaDutyDetailsSerType.Location = new System.Drawing.Point(32, 246);
            this.notePanel_TeaDutyDetailsSerType.MaxRows = 5;
            this.notePanel_TeaDutyDetailsSerType.Name = "notePanel_TeaDutyDetailsSerType";
            this.notePanel_TeaDutyDetailsSerType.ParentAutoHeight = true;
            this.notePanel_TeaDutyDetailsSerType.Size = new System.Drawing.Size(88, 22);
            this.notePanel_TeaDutyDetailsSerType.TabIndex = 9;
            this.notePanel_TeaDutyDetailsSerType.TabStop = false;
            this.notePanel_TeaDutyDetailsSerType.Text = "查 询 类 型";
            // 
            // simpleButton_SearTeaDutyDetails
            // 
            this.simpleButton_SearTeaDutyDetails.Location = new System.Drawing.Point(70, 272);
            this.simpleButton_SearTeaDutyDetails.Name = "simpleButton_SearTeaDutyDetails";
            this.simpleButton_SearTeaDutyDetails.Size = new System.Drawing.Size(64, 23);
            this.simpleButton_SearTeaDutyDetails.TabIndex = 8;
            this.simpleButton_SearTeaDutyDetails.Text = "出勤报表";
            this.simpleButton_SearTeaDutyDetails.Click += new System.EventHandler(this.simpleButton_SearTeaDutyDetails_Click);
            // 
            // dateEdit_TeaDutyDetailsSearByStartTime
            // 
            this.dateEdit_TeaDutyDetailsSearByStartTime.EditValue = new System.DateTime(2005, 12, 31, 0, 0, 0, 0);
            this.dateEdit_TeaDutyDetailsSearByStartTime.Location = new System.Drawing.Point(136, 148);
            this.dateEdit_TeaDutyDetailsSearByStartTime.Name = "dateEdit_TeaDutyDetailsSearByStartTime";
            this.dateEdit_TeaDutyDetailsSearByStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_TeaDutyDetailsSearByStartTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit_TeaDutyDetailsSearByStartTime.Size = new System.Drawing.Size(112, 20);
            this.dateEdit_TeaDutyDetailsSearByStartTime.TabIndex = 7;
            // 
            // comboBoxEdit_TeaDutyDetailsSearByGrade
            // 
            this.comboBoxEdit_TeaDutyDetailsSearByGrade.EditValue = "全部";
            this.comboBoxEdit_TeaDutyDetailsSearByGrade.Location = new System.Drawing.Point(136, 84);
            this.comboBoxEdit_TeaDutyDetailsSearByGrade.Name = "comboBoxEdit_TeaDutyDetailsSearByGrade";
            this.comboBoxEdit_TeaDutyDetailsSearByGrade.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_TeaDutyDetailsSearByGrade.Properties.Items.AddRange(new object[] {
            "全部"});
            this.comboBoxEdit_TeaDutyDetailsSearByGrade.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_TeaDutyDetailsSearByGrade.Size = new System.Drawing.Size(112, 20);
            this.comboBoxEdit_TeaDutyDetailsSearByGrade.TabIndex = 6;
            this.comboBoxEdit_TeaDutyDetailsSearByGrade.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_TeaDutyDetailsSearByGrade_SelectedIndexChanged);
            // 
            // textEdit_TeaDutyDetailsSearByID
            // 
            this.textEdit_TeaDutyDetailsSearByID.EditValue = "";
            this.textEdit_TeaDutyDetailsSearByID.Location = new System.Drawing.Point(136, 24);
            this.textEdit_TeaDutyDetailsSearByID.Name = "textEdit_TeaDutyDetailsSearByID";
            this.textEdit_TeaDutyDetailsSearByID.Size = new System.Drawing.Size(112, 20);
            this.textEdit_TeaDutyDetailsSearByID.TabIndex = 5;
            // 
            // notePanel_TeaDutyDetailsSearByID
            // 
            this.notePanel_TeaDutyDetailsSearByID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_TeaDutyDetailsSearByID.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_TeaDutyDetailsSearByID.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_TeaDutyDetailsSearByID.ForeColor = System.Drawing.Color.Black;
            this.notePanel_TeaDutyDetailsSearByID.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_TeaDutyDetailsSearByID.Location = new System.Drawing.Point(32, 24);
            this.notePanel_TeaDutyDetailsSearByID.MaxRows = 5;
            this.notePanel_TeaDutyDetailsSearByID.Name = "notePanel_TeaDutyDetailsSearByID";
            this.notePanel_TeaDutyDetailsSearByID.ParentAutoHeight = true;
            this.notePanel_TeaDutyDetailsSearByID.Size = new System.Drawing.Size(88, 22);
            this.notePanel_TeaDutyDetailsSearByID.TabIndex = 4;
            this.notePanel_TeaDutyDetailsSearByID.TabStop = false;
            this.notePanel_TeaDutyDetailsSearByID.Text = "教 师 工 号";
            // 
            // notePanel_TeaDutyDetailSearByName
            // 
            this.notePanel_TeaDutyDetailSearByName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_TeaDutyDetailSearByName.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_TeaDutyDetailSearByName.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_TeaDutyDetailSearByName.ForeColor = System.Drawing.Color.Black;
            this.notePanel_TeaDutyDetailSearByName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_TeaDutyDetailSearByName.Location = new System.Drawing.Point(32, 56);
            this.notePanel_TeaDutyDetailSearByName.MaxRows = 5;
            this.notePanel_TeaDutyDetailSearByName.Name = "notePanel_TeaDutyDetailSearByName";
            this.notePanel_TeaDutyDetailSearByName.ParentAutoHeight = true;
            this.notePanel_TeaDutyDetailSearByName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.notePanel_TeaDutyDetailSearByName.Size = new System.Drawing.Size(88, 22);
            this.notePanel_TeaDutyDetailSearByName.TabIndex = 4;
            this.notePanel_TeaDutyDetailSearByName.TabStop = false;
            this.notePanel_TeaDutyDetailSearByName.Text = "教 师 姓 名";
            // 
            // notePanel_TeaDutyDetailsSearByGrade
            // 
            this.notePanel_TeaDutyDetailsSearByGrade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_TeaDutyDetailsSearByGrade.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_TeaDutyDetailsSearByGrade.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_TeaDutyDetailsSearByGrade.ForeColor = System.Drawing.Color.Black;
            this.notePanel_TeaDutyDetailsSearByGrade.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_TeaDutyDetailsSearByGrade.Location = new System.Drawing.Point(32, 88);
            this.notePanel_TeaDutyDetailsSearByGrade.MaxRows = 5;
            this.notePanel_TeaDutyDetailsSearByGrade.Name = "notePanel_TeaDutyDetailsSearByGrade";
            this.notePanel_TeaDutyDetailsSearByGrade.ParentAutoHeight = true;
            this.notePanel_TeaDutyDetailsSearByGrade.Size = new System.Drawing.Size(88, 22);
            this.notePanel_TeaDutyDetailsSearByGrade.TabIndex = 4;
            this.notePanel_TeaDutyDetailsSearByGrade.TabStop = false;
            this.notePanel_TeaDutyDetailsSearByGrade.Text = "所 在 部 门";
            // 
            // notePanel_TeaDutyDetailsSearByClass
            // 
            this.notePanel_TeaDutyDetailsSearByClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_TeaDutyDetailsSearByClass.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_TeaDutyDetailsSearByClass.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_TeaDutyDetailsSearByClass.ForeColor = System.Drawing.Color.Black;
            this.notePanel_TeaDutyDetailsSearByClass.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_TeaDutyDetailsSearByClass.Location = new System.Drawing.Point(32, 120);
            this.notePanel_TeaDutyDetailsSearByClass.MaxRows = 5;
            this.notePanel_TeaDutyDetailsSearByClass.Name = "notePanel_TeaDutyDetailsSearByClass";
            this.notePanel_TeaDutyDetailsSearByClass.ParentAutoHeight = true;
            this.notePanel_TeaDutyDetailsSearByClass.Size = new System.Drawing.Size(88, 22);
            this.notePanel_TeaDutyDetailsSearByClass.TabIndex = 4;
            this.notePanel_TeaDutyDetailsSearByClass.TabStop = false;
            this.notePanel_TeaDutyDetailsSearByClass.Text = "岗          位";
            // 
            // notePanel_TeaDutyDetailsSearByStartTime
            // 
            this.notePanel_TeaDutyDetailsSearByStartTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_TeaDutyDetailsSearByStartTime.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_TeaDutyDetailsSearByStartTime.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_TeaDutyDetailsSearByStartTime.ForeColor = System.Drawing.Color.Black;
            this.notePanel_TeaDutyDetailsSearByStartTime.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_TeaDutyDetailsSearByStartTime.Location = new System.Drawing.Point(32, 152);
            this.notePanel_TeaDutyDetailsSearByStartTime.MaxRows = 5;
            this.notePanel_TeaDutyDetailsSearByStartTime.Name = "notePanel_TeaDutyDetailsSearByStartTime";
            this.notePanel_TeaDutyDetailsSearByStartTime.ParentAutoHeight = true;
            this.notePanel_TeaDutyDetailsSearByStartTime.Size = new System.Drawing.Size(88, 22);
            this.notePanel_TeaDutyDetailsSearByStartTime.TabIndex = 4;
            this.notePanel_TeaDutyDetailsSearByStartTime.TabStop = false;
            this.notePanel_TeaDutyDetailsSearByStartTime.Text = "起 始 时 间";
            // 
            // notePanel_TeaDutyDetailsSearByEndTime
            // 
            this.notePanel_TeaDutyDetailsSearByEndTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_TeaDutyDetailsSearByEndTime.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_TeaDutyDetailsSearByEndTime.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_TeaDutyDetailsSearByEndTime.ForeColor = System.Drawing.Color.Black;
            this.notePanel_TeaDutyDetailsSearByEndTime.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_TeaDutyDetailsSearByEndTime.Location = new System.Drawing.Point(32, 184);
            this.notePanel_TeaDutyDetailsSearByEndTime.MaxRows = 5;
            this.notePanel_TeaDutyDetailsSearByEndTime.Name = "notePanel_TeaDutyDetailsSearByEndTime";
            this.notePanel_TeaDutyDetailsSearByEndTime.ParentAutoHeight = true;
            this.notePanel_TeaDutyDetailsSearByEndTime.Size = new System.Drawing.Size(88, 22);
            this.notePanel_TeaDutyDetailsSearByEndTime.TabIndex = 4;
            this.notePanel_TeaDutyDetailsSearByEndTime.TabStop = false;
            this.notePanel_TeaDutyDetailsSearByEndTime.Text = "结 束 时 间";
            // 
            // textEdit_TeaDutyDetailsSearByName
            // 
            this.textEdit_TeaDutyDetailsSearByName.EditValue = "";
            this.textEdit_TeaDutyDetailsSearByName.Location = new System.Drawing.Point(136, 52);
            this.textEdit_TeaDutyDetailsSearByName.Name = "textEdit_TeaDutyDetailsSearByName";
            this.textEdit_TeaDutyDetailsSearByName.Size = new System.Drawing.Size(112, 20);
            this.textEdit_TeaDutyDetailsSearByName.TabIndex = 5;
            // 
            // comboBoxEdit_TeaDutyDetailsSearByClass
            // 
            this.comboBoxEdit_TeaDutyDetailsSearByClass.EditValue = "全部";
            this.comboBoxEdit_TeaDutyDetailsSearByClass.Location = new System.Drawing.Point(136, 116);
            this.comboBoxEdit_TeaDutyDetailsSearByClass.Name = "comboBoxEdit_TeaDutyDetailsSearByClass";
            this.comboBoxEdit_TeaDutyDetailsSearByClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_TeaDutyDetailsSearByClass.Properties.Items.AddRange(new object[] {
            "全部"});
            this.comboBoxEdit_TeaDutyDetailsSearByClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_TeaDutyDetailsSearByClass.Size = new System.Drawing.Size(112, 20);
            this.comboBoxEdit_TeaDutyDetailsSearByClass.TabIndex = 6;
            this.comboBoxEdit_TeaDutyDetailsSearByClass.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_TeaDutyDetailsSearByClass_SelectedIndexChanged);
            // 
            // dateEdit_TeaDutyDetailsSearByEndTime
            // 
            this.dateEdit_TeaDutyDetailsSearByEndTime.EditValue = new System.DateTime(2005, 12, 31, 0, 0, 0, 0);
            this.dateEdit_TeaDutyDetailsSearByEndTime.Location = new System.Drawing.Point(136, 182);
            this.dateEdit_TeaDutyDetailsSearByEndTime.Name = "dateEdit_TeaDutyDetailsSearByEndTime";
            this.dateEdit_TeaDutyDetailsSearByEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_TeaDutyDetailsSearByEndTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit_TeaDutyDetailsSearByEndTime.Size = new System.Drawing.Size(112, 20);
            this.dateEdit_TeaDutyDetailsSearByEndTime.TabIndex = 7;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(8, 272);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(60, 23);
            this.simpleButton1.TabIndex = 8;
            this.simpleButton1.Text = "检索";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(136, 272);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(60, 23);
            this.simpleButton3.TabIndex = 8;
            this.simpleButton3.Text = "外出报表";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // groupControl_TeaDutyDetails
            // 
            this.groupControl_TeaDutyDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl_TeaDutyDetails.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_TeaDutyDetails.AppearanceCaption.Options.UseFont = true;
            this.groupControl_TeaDutyDetails.Controls.Add(this.gridControl_TeaDutySummary);
            this.groupControl_TeaDutyDetails.Controls.Add(this.gridControl_TeaDutyNormal);
            this.groupControl_TeaDutyDetails.Controls.Add(this.popupContainerControl_Remarks);
            this.groupControl_TeaDutyDetails.Controls.Add(this.gridControl_TeaDutyDetails);
            this.groupControl_TeaDutyDetails.Location = new System.Drawing.Point(264, 0);
            this.groupControl_TeaDutyDetails.Name = "groupControl_TeaDutyDetails";
            this.groupControl_TeaDutyDetails.Size = new System.Drawing.Size(504, 304);
            this.groupControl_TeaDutyDetails.TabIndex = 0;
            this.groupControl_TeaDutyDetails.Text = "出勤信息";
            // 
            // gridControl_TeaDutySummary
            // 
            this.gridControl_TeaDutySummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_TeaDutySummary.Location = new System.Drawing.Point(2, 22);
            this.gridControl_TeaDutySummary.MainView = this.advBandedGridView4;
            this.gridControl_TeaDutySummary.Name = "gridControl_TeaDutySummary";
            this.gridControl_TeaDutySummary.Size = new System.Drawing.Size(500, 280);
            this.gridControl_TeaDutySummary.TabIndex = 3;
            this.gridControl_TeaDutySummary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.advBandedGridView4,
            this.gridView3});
            this.gridControl_TeaDutySummary.Visible = false;
            // 
            // advBandedGridView4
            // 
            this.advBandedGridView4.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand4});
            this.advBandedGridView4.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn8,
            this.bandedGridColumn9,
            this.bandedGridColumn10,
            this.bandedGridColumn11,
            this.bandedGridColumn12,
            this.bandedGridColumn13,
            this.bandedGridColumn14,
            this.bandedGridColumn15});
            this.advBandedGridView4.GridControl = this.gridControl_TeaDutySummary;
            this.advBandedGridView4.Name = "advBandedGridView4";
            this.advBandedGridView4.OptionsCustomization.AllowFilter = false;
            this.advBandedGridView4.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.advBandedGridView4.OptionsView.ShowGroupPanel = false;
            // 
            // gridBand4
            // 
            this.gridBand4.Caption = "教师出勤综合信息";
            this.gridBand4.Columns.Add(this.bandedGridColumn8);
            this.gridBand4.Columns.Add(this.bandedGridColumn10);
            this.gridBand4.Columns.Add(this.bandedGridColumn12);
            this.gridBand4.Columns.Add(this.bandedGridColumn14);
            this.gridBand4.Columns.Add(this.bandedGridColumn9);
            this.gridBand4.Columns.Add(this.bandedGridColumn11);
            this.gridBand4.Columns.Add(this.bandedGridColumn13);
            this.gridBand4.Columns.Add(this.bandedGridColumn15);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.Width = 589;
            // 
            // bandedGridColumn8
            // 
            this.bandedGridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn8.Caption = "教师姓名";
            this.bandedGridColumn8.FieldName = "T_Name";
            this.bandedGridColumn8.Name = "bandedGridColumn8";
            this.bandedGridColumn8.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn8.OptionsColumn.AllowFocus = false;
            this.bandedGridColumn8.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridColumn8.OptionsColumn.AllowIncrementalSearch = false;
            this.bandedGridColumn8.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridColumn8.OptionsColumn.AllowMove = false;
            this.bandedGridColumn8.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.bandedGridColumn8.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn8.OptionsColumn.ShowInCustomizationForm = false;
            this.bandedGridColumn8.Visible = true;
            this.bandedGridColumn8.Width = 145;
            // 
            // bandedGridColumn10
            // 
            this.bandedGridColumn10.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn10.Caption = "迟到";
            this.bandedGridColumn10.FieldName = "Late";
            this.bandedGridColumn10.Name = "bandedGridColumn10";
            this.bandedGridColumn10.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn10.OptionsColumn.AllowFocus = false;
            this.bandedGridColumn10.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridColumn10.OptionsColumn.AllowIncrementalSearch = false;
            this.bandedGridColumn10.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridColumn10.OptionsColumn.AllowMove = false;
            this.bandedGridColumn10.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.bandedGridColumn10.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn10.OptionsColumn.ShowInCustomizationForm = false;
            this.bandedGridColumn10.Visible = true;
            this.bandedGridColumn10.Width = 145;
            // 
            // bandedGridColumn12
            // 
            this.bandedGridColumn12.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn12.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn12.Caption = "缺席";
            this.bandedGridColumn12.FieldName = "Absence";
            this.bandedGridColumn12.Name = "bandedGridColumn12";
            this.bandedGridColumn12.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn12.OptionsColumn.AllowFocus = false;
            this.bandedGridColumn12.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridColumn12.OptionsColumn.AllowIncrementalSearch = false;
            this.bandedGridColumn12.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridColumn12.OptionsColumn.AllowMove = false;
            this.bandedGridColumn12.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.bandedGridColumn12.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn12.OptionsColumn.ShowInCustomizationForm = false;
            this.bandedGridColumn12.Visible = true;
            this.bandedGridColumn12.Width = 145;
            // 
            // bandedGridColumn14
            // 
            this.bandedGridColumn14.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn14.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn14.Caption = "应出勤";
            this.bandedGridColumn14.FieldName = "ShouldAttend";
            this.bandedGridColumn14.Name = "bandedGridColumn14";
            this.bandedGridColumn14.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn14.OptionsColumn.AllowFocus = false;
            this.bandedGridColumn14.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridColumn14.OptionsColumn.AllowIncrementalSearch = false;
            this.bandedGridColumn14.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridColumn14.OptionsColumn.AllowMove = false;
            this.bandedGridColumn14.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.bandedGridColumn14.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn14.OptionsColumn.ShowInCustomizationForm = false;
            this.bandedGridColumn14.Visible = true;
            this.bandedGridColumn14.Width = 154;
            // 
            // bandedGridColumn9
            // 
            this.bandedGridColumn9.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn9.Caption = "教师工号";
            this.bandedGridColumn9.FieldName = "T_Number";
            this.bandedGridColumn9.Name = "bandedGridColumn9";
            this.bandedGridColumn9.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn9.OptionsColumn.AllowFocus = false;
            this.bandedGridColumn9.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridColumn9.OptionsColumn.AllowIncrementalSearch = false;
            this.bandedGridColumn9.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridColumn9.OptionsColumn.AllowMove = false;
            this.bandedGridColumn9.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.bandedGridColumn9.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn9.OptionsColumn.ShowInCustomizationForm = false;
            this.bandedGridColumn9.RowIndex = 1;
            this.bandedGridColumn9.Visible = true;
            this.bandedGridColumn9.Width = 145;
            // 
            // bandedGridColumn11
            // 
            this.bandedGridColumn11.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn11.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn11.Caption = "早退";
            this.bandedGridColumn11.FieldName = "OffTime";
            this.bandedGridColumn11.Name = "bandedGridColumn11";
            this.bandedGridColumn11.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn11.OptionsColumn.AllowFocus = false;
            this.bandedGridColumn11.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridColumn11.OptionsColumn.AllowIncrementalSearch = false;
            this.bandedGridColumn11.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridColumn11.OptionsColumn.AllowMove = false;
            this.bandedGridColumn11.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.bandedGridColumn11.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn11.OptionsColumn.ShowInCustomizationForm = false;
            this.bandedGridColumn11.RowIndex = 1;
            this.bandedGridColumn11.Visible = true;
            this.bandedGridColumn11.Width = 145;
            // 
            // bandedGridColumn13
            // 
            this.bandedGridColumn13.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn13.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn13.Caption = "实出勤";
            this.bandedGridColumn13.FieldName = "Attend";
            this.bandedGridColumn13.Name = "bandedGridColumn13";
            this.bandedGridColumn13.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn13.OptionsColumn.AllowFocus = false;
            this.bandedGridColumn13.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridColumn13.OptionsColumn.AllowIncrementalSearch = false;
            this.bandedGridColumn13.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridColumn13.OptionsColumn.AllowMove = false;
            this.bandedGridColumn13.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.bandedGridColumn13.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn13.OptionsColumn.ShowInCustomizationForm = false;
            this.bandedGridColumn13.RowIndex = 1;
            this.bandedGridColumn13.Visible = true;
            this.bandedGridColumn13.Width = 145;
            // 
            // bandedGridColumn15
            // 
            this.bandedGridColumn15.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn15.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn15.Caption = "外出";
            this.bandedGridColumn15.FieldName = "Out";
            this.bandedGridColumn15.Name = "bandedGridColumn15";
            this.bandedGridColumn15.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn15.OptionsColumn.AllowFocus = false;
            this.bandedGridColumn15.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridColumn15.OptionsColumn.AllowIncrementalSearch = false;
            this.bandedGridColumn15.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridColumn15.OptionsColumn.AllowMove = false;
            this.bandedGridColumn15.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.bandedGridColumn15.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn15.OptionsColumn.ShowInCustomizationForm = false;
            this.bandedGridColumn15.RowIndex = 1;
            this.bandedGridColumn15.Visible = true;
            this.bandedGridColumn15.Width = 154;
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.gridControl_TeaDutySummary;
            this.gridView3.Name = "gridView3";
            // 
            // gridControl_TeaDutyNormal
            // 
            this.gridControl_TeaDutyNormal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_TeaDutyNormal.Location = new System.Drawing.Point(2, 22);
            this.gridControl_TeaDutyNormal.MainView = this.advBandedGridView3;
            this.gridControl_TeaDutyNormal.Name = "gridControl_TeaDutyNormal";
            this.gridControl_TeaDutyNormal.Size = new System.Drawing.Size(500, 280);
            this.gridControl_TeaDutyNormal.TabIndex = 2;
            this.gridControl_TeaDutyNormal.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.advBandedGridView3});
            // 
            // advBandedGridView3
            // 
            this.advBandedGridView3.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand3});
            this.advBandedGridView3.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn1,
            this.bandedGridColumn2,
            this.bandedGridColumn3,
            this.bandedGridColumn4,
            this.bandedGridColumn5,
            this.bandedGridColumn6,
            this.bandedGridColumn7});
            this.advBandedGridView3.GridControl = this.gridControl_TeaDutyNormal;
            this.advBandedGridView3.Name = "advBandedGridView3";
            this.advBandedGridView3.OptionsCustomization.AllowFilter = false;
            this.advBandedGridView3.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.advBandedGridView3.OptionsView.ShowGroupPanel = false;
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "教师出勤信息";
            this.gridBand3.Columns.Add(this.bandedGridColumn1);
            this.gridBand3.Columns.Add(this.bandedGridColumn2);
            this.gridBand3.Columns.Add(this.bandedGridColumn3);
            this.gridBand3.Columns.Add(this.bandedGridColumn4);
            this.gridBand3.Columns.Add(this.bandedGridColumn5);
            this.gridBand3.Columns.Add(this.bandedGridColumn6);
            this.gridBand3.Columns.Add(this.bandedGridColumn7);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.Width = 645;
            // 
            // bandedGridColumn1
            // 
            this.bandedGridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn1.Caption = "序号";
            this.bandedGridColumn1.FieldName = "T_OrderNumber";
            this.bandedGridColumn1.Name = "bandedGridColumn1";
            this.bandedGridColumn1.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn1.OptionsColumn.AllowFocus = false;
            this.bandedGridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridColumn1.OptionsColumn.AllowIncrementalSearch = false;
            this.bandedGridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridColumn1.OptionsColumn.AllowMove = false;
            this.bandedGridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.bandedGridColumn1.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn1.OptionsColumn.ShowInCustomizationForm = false;
            this.bandedGridColumn1.Visible = true;
            this.bandedGridColumn1.Width = 67;
            // 
            // bandedGridColumn2
            // 
            this.bandedGridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn2.Caption = "教师姓名";
            this.bandedGridColumn2.FieldName = "T_Name";
            this.bandedGridColumn2.Name = "bandedGridColumn2";
            this.bandedGridColumn2.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn2.OptionsColumn.AllowFocus = false;
            this.bandedGridColumn2.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridColumn2.OptionsColumn.AllowIncrementalSearch = false;
            this.bandedGridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridColumn2.OptionsColumn.AllowMove = false;
            this.bandedGridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.bandedGridColumn2.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn2.OptionsColumn.ShowInCustomizationForm = false;
            this.bandedGridColumn2.Visible = true;
            this.bandedGridColumn2.Width = 86;
            // 
            // bandedGridColumn3
            // 
            this.bandedGridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn3.Caption = "教师工号";
            this.bandedGridColumn3.FieldName = "T_Number";
            this.bandedGridColumn3.Name = "bandedGridColumn3";
            this.bandedGridColumn3.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn3.OptionsColumn.AllowFocus = false;
            this.bandedGridColumn3.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridColumn3.OptionsColumn.AllowIncrementalSearch = false;
            this.bandedGridColumn3.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridColumn3.OptionsColumn.AllowMove = false;
            this.bandedGridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.bandedGridColumn3.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn3.OptionsColumn.ShowInCustomizationForm = false;
            this.bandedGridColumn3.Visible = true;
            this.bandedGridColumn3.Width = 87;
            // 
            // bandedGridColumn4
            // 
            this.bandedGridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn4.Caption = "所在部门";
            this.bandedGridColumn4.FieldName = "T_Depart";
            this.bandedGridColumn4.Name = "bandedGridColumn4";
            this.bandedGridColumn4.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn4.OptionsColumn.AllowFocus = false;
            this.bandedGridColumn4.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridColumn4.OptionsColumn.AllowIncrementalSearch = false;
            this.bandedGridColumn4.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridColumn4.OptionsColumn.AllowMove = false;
            this.bandedGridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.bandedGridColumn4.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn4.OptionsColumn.ShowInCustomizationForm = false;
            this.bandedGridColumn4.Visible = true;
            this.bandedGridColumn4.Width = 84;
            // 
            // bandedGridColumn5
            // 
            this.bandedGridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn5.Caption = "岗位";
            this.bandedGridColumn5.FieldName = "T_Duty";
            this.bandedGridColumn5.Name = "bandedGridColumn5";
            this.bandedGridColumn5.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn5.OptionsColumn.AllowFocus = false;
            this.bandedGridColumn5.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridColumn5.OptionsColumn.AllowIncrementalSearch = false;
            this.bandedGridColumn5.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridColumn5.OptionsColumn.AllowMove = false;
            this.bandedGridColumn5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.bandedGridColumn5.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn5.OptionsColumn.ShowInCustomizationForm = false;
            this.bandedGridColumn5.Visible = true;
            this.bandedGridColumn5.Width = 78;
            // 
            // bandedGridColumn6
            // 
            this.bandedGridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn6.Caption = "记录时间";
            this.bandedGridColumn6.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.bandedGridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.bandedGridColumn6.FieldName = "teaflow_date";
            this.bandedGridColumn6.Name = "bandedGridColumn6";
            this.bandedGridColumn6.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn6.OptionsColumn.AllowFocus = false;
            this.bandedGridColumn6.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridColumn6.OptionsColumn.AllowIncrementalSearch = false;
            this.bandedGridColumn6.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridColumn6.OptionsColumn.AllowMove = false;
            this.bandedGridColumn6.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.bandedGridColumn6.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn6.OptionsColumn.ShowInCustomizationForm = false;
            this.bandedGridColumn6.Visible = true;
            this.bandedGridColumn6.Width = 127;
            // 
            // bandedGridColumn7
            // 
            this.bandedGridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn7.Caption = "记录状态";
            this.bandedGridColumn7.FieldName = "teafs_name";
            this.bandedGridColumn7.Name = "bandedGridColumn7";
            this.bandedGridColumn7.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn7.OptionsColumn.AllowFocus = false;
            this.bandedGridColumn7.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridColumn7.OptionsColumn.AllowIncrementalSearch = false;
            this.bandedGridColumn7.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridColumn7.OptionsColumn.AllowMove = false;
            this.bandedGridColumn7.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.bandedGridColumn7.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn7.OptionsColumn.ShowInCustomizationForm = false;
            this.bandedGridColumn7.Visible = true;
            this.bandedGridColumn7.Width = 116;
            // 
            // popupContainerControl_Remarks
            // 
            this.popupContainerControl_Remarks.Controls.Add(this.memoEdit_Remarks);
            this.popupContainerControl_Remarks.Location = new System.Drawing.Point(48, 120);
            this.popupContainerControl_Remarks.Name = "popupContainerControl_Remarks";
            this.popupContainerControl_Remarks.Size = new System.Drawing.Size(200, 100);
            this.popupContainerControl_Remarks.TabIndex = 1;
            // 
            // memoEdit_Remarks
            // 
            this.memoEdit_Remarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoEdit_Remarks.EditValue = "";
            this.memoEdit_Remarks.Location = new System.Drawing.Point(0, 0);
            this.memoEdit_Remarks.Name = "memoEdit_Remarks";
            this.memoEdit_Remarks.Size = new System.Drawing.Size(200, 100);
            this.memoEdit_Remarks.TabIndex = 0;
            // 
            // gridControl_TeaDutyDetails
            // 
            this.gridControl_TeaDutyDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_TeaDutyDetails.Location = new System.Drawing.Point(2, 22);
            this.gridControl_TeaDutyDetails.MainView = this.advBandedGridView2;
            this.gridControl_TeaDutyDetails.Name = "gridControl_TeaDutyDetails";
            this.gridControl_TeaDutyDetails.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.repositoryItemPopupContainerEdit8});
            this.gridControl_TeaDutyDetails.Size = new System.Drawing.Size(500, 280);
            this.gridControl_TeaDutyDetails.TabIndex = 0;
            this.gridControl_TeaDutyDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.advBandedGridView2,
            this.gridView2});
            // 
            // advBandedGridView2
            // 
            this.advBandedGridView2.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2});
            this.advBandedGridView2.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn24,
            this.gridColumn25,
            this.gridColumn34,
            this.gridColumn35});
            this.advBandedGridView2.GridControl = this.gridControl_TeaDutyDetails;
            this.advBandedGridView2.Name = "advBandedGridView2";
            this.advBandedGridView2.OptionsCustomization.AllowFilter = false;
            this.advBandedGridView2.OptionsCustomization.AllowGroup = false;
            this.advBandedGridView2.OptionsDetail.EnableDetailToolTip = true;
            this.advBandedGridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.advBandedGridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "教师出勤详细信息";
            this.gridBand2.Columns.Add(this.gridColumn13);
            this.gridBand2.Columns.Add(this.gridColumn14);
            this.gridBand2.Columns.Add(this.gridColumn15);
            this.gridBand2.Columns.Add(this.gridColumn16);
            this.gridBand2.Columns.Add(this.gridColumn17);
            this.gridBand2.Columns.Add(this.gridColumn18);
            this.gridBand2.Columns.Add(this.gridColumn19);
            this.gridBand2.Columns.Add(this.gridColumn20);
            this.gridBand2.Columns.Add(this.gridColumn21);
            this.gridBand2.Columns.Add(this.gridColumn22);
            this.gridBand2.Columns.Add(this.gridColumn23);
            this.gridBand2.Columns.Add(this.gridColumn24);
            this.gridBand2.Columns.Add(this.gridColumn25);
            this.gridBand2.Columns.Add(this.gridColumn34);
            this.gridBand2.Columns.Add(this.gridColumn35);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.Width = 602;
            // 
            // gridColumn13
            // 
            this.gridColumn13.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn13.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn13.Caption = "姓名";
            this.gridColumn13.FieldName = "T_Name";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.Width = 44;
            // 
            // gridColumn14
            // 
            this.gridColumn14.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn14.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn14.Caption = "工号";
            this.gridColumn14.FieldName = "T_Number";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.Width = 41;
            // 
            // gridColumn15
            // 
            this.gridColumn15.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn15.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn15.Caption = "部门";
            this.gridColumn15.FieldName = "T_Depart";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.Width = 41;
            // 
            // gridColumn16
            // 
            this.gridColumn16.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn16.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn16.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn16.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn16.Caption = "岗位";
            this.gridColumn16.FieldName = "T_Duty";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.Visible = true;
            this.gridColumn16.Width = 45;
            // 
            // gridColumn17
            // 
            this.gridColumn17.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn17.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn17.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn17.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn17.Caption = "日期";
            this.gridColumn17.FieldName = "teaondutyanaly_date";
            this.gridColumn17.MinWidth = 10;
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.Width = 49;
            // 
            // gridColumn18
            // 
            this.gridColumn18.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn18.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn18.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn18.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn18.Caption = "入校时间";
            this.gridColumn18.DisplayFormat.FormatString = "g";
            this.gridColumn18.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn18.FieldName = "teaondutyanaly_entertime";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.Width = 68;
            // 
            // gridColumn19
            // 
            this.gridColumn19.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn19.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn19.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn19.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn19.Caption = "离校时间";
            this.gridColumn19.DisplayFormat.FormatString = "g";
            this.gridColumn19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn19.FieldName = "teaondutyanaly_leavetime";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowEdit = false;
            this.gridColumn19.Visible = true;
            this.gridColumn19.Width = 60;
            // 
            // gridColumn20
            // 
            this.gridColumn20.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn20.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn20.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn20.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn20.Caption = "班次";
            this.gridColumn20.FieldName = "teaduty_name";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsColumn.AllowEdit = false;
            this.gridColumn20.Visible = true;
            this.gridColumn20.Width = 48;
            // 
            // gridColumn21
            // 
            this.gridColumn21.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn21.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn21.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn21.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn21.Caption = "迟到";
            this.gridColumn21.FieldName = "teaondutyanaly_isontime";
            this.gridColumn21.MinWidth = 10;
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.AllowEdit = false;
            this.gridColumn21.Visible = true;
            this.gridColumn21.Width = 34;
            // 
            // gridColumn22
            // 
            this.gridColumn22.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn22.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn22.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn22.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn22.Caption = "早退";
            this.gridColumn22.FieldName = "teaondutyanaly_isofftime";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.OptionsColumn.AllowEdit = false;
            this.gridColumn22.Visible = true;
            this.gridColumn22.Width = 41;
            // 
            // gridColumn23
            // 
            this.gridColumn23.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn23.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn23.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn23.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn23.Caption = "缺勤";
            this.gridColumn23.FieldName = "teaondutyanaly_isabsence";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsColumn.AllowEdit = false;
            this.gridColumn23.Visible = true;
            this.gridColumn23.Width = 34;
            // 
            // gridColumn24
            // 
            this.gridColumn24.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn24.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn24.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn24.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn24.Caption = "外出";
            this.gridColumn24.FieldName = "teaondutyanaly_isout";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.OptionsColumn.AllowEdit = false;
            this.gridColumn24.Visible = true;
            this.gridColumn24.Width = 38;
            // 
            // gridColumn25
            // 
            this.gridColumn25.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn25.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn25.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn25.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn25.Caption = "备注";
            this.gridColumn25.ColumnEdit = this.repositoryItemPopupContainerEdit8;
            this.gridColumn25.FieldName = "teaondutyanaly_remark";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.Visible = true;
            this.gridColumn25.Width = 108;
            // 
            // repositoryItemPopupContainerEdit8
            // 
            this.repositoryItemPopupContainerEdit8.AutoHeight = false;
            this.repositoryItemPopupContainerEdit8.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemPopupContainerEdit8.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.repositoryItemPopupContainerEdit8.Name = "repositoryItemPopupContainerEdit8";
            this.repositoryItemPopupContainerEdit8.PopupControl = this.popupContainerControl_Remarks;
            this.repositoryItemPopupContainerEdit8.ShowPopupCloseButton = false;
            this.repositoryItemPopupContainerEdit8.QueryResultValue += new DevExpress.XtraEditors.Controls.QueryResultValueEventHandler(this.repositoryItemPopupContainerEdit8_QueryResultValue);
            this.repositoryItemPopupContainerEdit8.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.repositoryItemPopupContainerEdit8_QueryPopUp);
            // 
            // gridColumn34
            // 
            this.gridColumn34.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn34.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn34.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn34.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn34.Caption = "tID";
            this.gridColumn34.FieldName = "teaondutyanaly_teaid";
            this.gridColumn34.Name = "gridColumn34";
            // 
            // gridColumn35
            // 
            this.gridColumn35.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn35.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn35.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn35.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn35.Caption = "dutyID";
            this.gridColumn35.FieldName = "teaondutyanaly_number";
            this.gridColumn35.MinWidth = 10;
            this.gridColumn35.Name = "gridColumn35";
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl_TeaDutyDetails;
            this.gridView2.Name = "gridView2";
            // 
            // groupControl_TeaDutyOutDetails
            // 
            this.groupControl_TeaDutyOutDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupControl_TeaDutyOutDetails.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_TeaDutyOutDetails.AppearanceCaption.Options.UseFont = true;
            this.groupControl_TeaDutyOutDetails.Controls.Add(this.gridControl_TeaOutDetails);
            this.groupControl_TeaDutyOutDetails.Location = new System.Drawing.Point(2, 304);
            this.groupControl_TeaDutyOutDetails.Name = "groupControl_TeaDutyOutDetails";
            this.groupControl_TeaDutyOutDetails.Size = new System.Drawing.Size(478, 208);
            this.groupControl_TeaDutyOutDetails.TabIndex = 1;
            this.groupControl_TeaDutyOutDetails.Text = "外出详细信息";
            // 
            // gridControl_TeaOutDetails
            // 
            this.gridControl_TeaOutDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_TeaOutDetails.Location = new System.Drawing.Point(2, 22);
            this.gridControl_TeaOutDetails.MainView = this.gridView4;
            this.gridControl_TeaOutDetails.Name = "gridControl_TeaOutDetails";
            this.gridControl_TeaOutDetails.Size = new System.Drawing.Size(474, 184);
            this.gridControl_TeaOutDetails.TabIndex = 0;
            this.gridControl_TeaOutDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView4});
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn26,
            this.gridColumn27,
            this.gridColumn28,
            this.gridColumn29,
            this.gridColumn30,
            this.gridColumn31,
            this.gridColumn32,
            this.gridColumn33});
            this.gridView4.GridControl = this.gridControl_TeaOutDetails;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsBehavior.Editable = false;
            this.gridView4.OptionsCustomization.AllowFilter = false;
            this.gridView4.OptionsCustomization.AllowGroup = false;
            this.gridView4.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView4.OptionsView.ShowFooter = true;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "姓名";
            this.gridColumn26.FieldName = "T_Name";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.OptionsColumn.AllowEdit = false;
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 0;
            this.gridColumn26.Width = 44;
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "工号";
            this.gridColumn27.FieldName = "T_Number";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.OptionsColumn.AllowEdit = false;
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 1;
            this.gridColumn27.Width = 40;
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "部门";
            this.gridColumn28.FieldName = "T_Depart";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.OptionsColumn.AllowEdit = false;
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 2;
            this.gridColumn28.Width = 46;
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "岗位";
            this.gridColumn29.FieldName = "T_Duty";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.OptionsColumn.AllowEdit = false;
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 3;
            this.gridColumn29.Width = 45;
            // 
            // gridColumn30
            // 
            this.gridColumn30.Caption = "外出时班次";
            this.gridColumn30.FieldName = "teaduty_name";
            this.gridColumn30.Name = "gridColumn30";
            this.gridColumn30.OptionsColumn.AllowEdit = false;
            this.gridColumn30.Visible = true;
            this.gridColumn30.VisibleIndex = 4;
            this.gridColumn30.Width = 73;
            // 
            // gridColumn31
            // 
            this.gridColumn31.Caption = "外出时间";
            this.gridColumn31.DisplayFormat.FormatString = "g";
            this.gridColumn31.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn31.FieldName = "teaout_leavetime";
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn31.OptionsColumn.AllowEdit = false;
            this.gridColumn31.Visible = true;
            this.gridColumn31.VisibleIndex = 5;
            this.gridColumn31.Width = 59;
            // 
            // gridColumn32
            // 
            this.gridColumn32.Caption = "外出归来时间";
            this.gridColumn32.DisplayFormat.FormatString = "g";
            this.gridColumn32.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn32.FieldName = "teaout_backtime";
            this.gridColumn32.Name = "gridColumn32";
            this.gridColumn32.OptionsColumn.AllowEdit = false;
            this.gridColumn32.Visible = true;
            this.gridColumn32.VisibleIndex = 6;
            this.gridColumn32.Width = 84;
            // 
            // gridColumn33
            // 
            this.gridColumn33.Caption = "外出原因";
            this.gridColumn33.FieldName = "teafs_name";
            this.gridColumn33.Name = "gridColumn33";
            this.gridColumn33.OptionsColumn.AllowEdit = false;
            this.gridColumn33.Visible = true;
            this.gridColumn33.VisibleIndex = 7;
            this.gridColumn33.Width = 64;
            // 
            // xtraTabPage_TeaOnDutyReports
            // 
            this.xtraTabPage_TeaOnDutyReports.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xtraTabPage_TeaOnDutyReports.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabPage_TeaOnDutyReports.Controls.Add(this.groupControl_Graph);
            this.xtraTabPage_TeaOnDutyReports.Controls.Add(this.groupControl_TeaDutyReportsSear);
            this.xtraTabPage_TeaOnDutyReports.Name = "xtraTabPage_TeaOnDutyReports";
            this.xtraTabPage_TeaOnDutyReports.Size = new System.Drawing.Size(766, 511);
            this.xtraTabPage_TeaOnDutyReports.Text = "出勤信息分析";
            // 
            // groupControl_Graph
            // 
            this.groupControl_Graph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl_Graph.Location = new System.Drawing.Point(200, 8);
            this.groupControl_Graph.Name = "groupControl_Graph";
            this.groupControl_Graph.Size = new System.Drawing.Size(568, 392);
            this.groupControl_Graph.TabIndex = 2;
            this.groupControl_Graph.Text = "分析图形";
            this.groupControl_Graph.Resize += new System.EventHandler(this.groupControl_Graph_Resize);
            // 
            // groupControl_TeaDutyReportsSear
            // 
            this.groupControl_TeaDutyReportsSear.Controls.Add(this.comboBoxEdit_Graphic_TeaDept);
            this.groupControl_TeaDutyReportsSear.Controls.Add(this.textEdit_Graphic_TeaID);
            this.groupControl_TeaDutyReportsSear.Controls.Add(this.notePanel_Graphic_TeaID);
            this.groupControl_TeaDutyReportsSear.Controls.Add(this.notePanel_Graphic_TeaName);
            this.groupControl_TeaDutyReportsSear.Controls.Add(this.notePanel_Graphic_TeaDept);
            this.groupControl_TeaDutyReportsSear.Controls.Add(this.notePanel_Graphic_TeaDuty);
            this.groupControl_TeaDutyReportsSear.Controls.Add(this.textEdit_Graphic_TeaName);
            this.groupControl_TeaDutyReportsSear.Controls.Add(this.comboBoxEdit_Graphic_TeaDuty);
            this.groupControl_TeaDutyReportsSear.Controls.Add(this.dateEdit1);
            this.groupControl_TeaDutyReportsSear.Controls.Add(this.notePanel6);
            this.groupControl_TeaDutyReportsSear.Controls.Add(this.notePanel7);
            this.groupControl_TeaDutyReportsSear.Controls.Add(this.dateEdit2);
            this.groupControl_TeaDutyReportsSear.Controls.Add(this.simpleButton_ReportAnalysis);
            this.groupControl_TeaDutyReportsSear.Controls.Add(this.simpleButton2);
            this.groupControl_TeaDutyReportsSear.Location = new System.Drawing.Point(8, 8);
            this.groupControl_TeaDutyReportsSear.Name = "groupControl_TeaDutyReportsSear";
            this.groupControl_TeaDutyReportsSear.Size = new System.Drawing.Size(184, 272);
            this.groupControl_TeaDutyReportsSear.TabIndex = 1;
            this.groupControl_TeaDutyReportsSear.Text = "总出勤情况报表";
            // 
            // comboBoxEdit_Graphic_TeaDept
            // 
            this.comboBoxEdit_Graphic_TeaDept.EditValue = "全部";
            this.comboBoxEdit_Graphic_TeaDept.Location = new System.Drawing.Point(88, 88);
            this.comboBoxEdit_Graphic_TeaDept.Name = "comboBoxEdit_Graphic_TeaDept";
            this.comboBoxEdit_Graphic_TeaDept.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_Graphic_TeaDept.Properties.Items.AddRange(new object[] {
            "全部"});
            this.comboBoxEdit_Graphic_TeaDept.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_Graphic_TeaDept.Size = new System.Drawing.Size(88, 20);
            this.comboBoxEdit_Graphic_TeaDept.TabIndex = 20;
            this.comboBoxEdit_Graphic_TeaDept.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_Graphic_TeaDept_SelectedIndexChanged);
            // 
            // textEdit_Graphic_TeaID
            // 
            this.textEdit_Graphic_TeaID.EditValue = "";
            this.textEdit_Graphic_TeaID.Location = new System.Drawing.Point(88, 24);
            this.textEdit_Graphic_TeaID.Name = "textEdit_Graphic_TeaID";
            this.textEdit_Graphic_TeaID.Size = new System.Drawing.Size(88, 20);
            this.textEdit_Graphic_TeaID.TabIndex = 18;
            // 
            // notePanel_Graphic_TeaID
            // 
            this.notePanel_Graphic_TeaID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Graphic_TeaID.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Graphic_TeaID.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Graphic_TeaID.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Graphic_TeaID.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Graphic_TeaID.Location = new System.Drawing.Point(8, 24);
            this.notePanel_Graphic_TeaID.MaxRows = 5;
            this.notePanel_Graphic_TeaID.Name = "notePanel_Graphic_TeaID";
            this.notePanel_Graphic_TeaID.ParentAutoHeight = true;
            this.notePanel_Graphic_TeaID.Size = new System.Drawing.Size(72, 22);
            this.notePanel_Graphic_TeaID.TabIndex = 16;
            this.notePanel_Graphic_TeaID.TabStop = false;
            this.notePanel_Graphic_TeaID.Text = "教师工号";
            // 
            // notePanel_Graphic_TeaName
            // 
            this.notePanel_Graphic_TeaName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Graphic_TeaName.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Graphic_TeaName.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Graphic_TeaName.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Graphic_TeaName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Graphic_TeaName.Location = new System.Drawing.Point(8, 56);
            this.notePanel_Graphic_TeaName.MaxRows = 5;
            this.notePanel_Graphic_TeaName.Name = "notePanel_Graphic_TeaName";
            this.notePanel_Graphic_TeaName.ParentAutoHeight = true;
            this.notePanel_Graphic_TeaName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.notePanel_Graphic_TeaName.Size = new System.Drawing.Size(72, 22);
            this.notePanel_Graphic_TeaName.TabIndex = 13;
            this.notePanel_Graphic_TeaName.TabStop = false;
            this.notePanel_Graphic_TeaName.Text = "教师姓名";
            // 
            // notePanel_Graphic_TeaDept
            // 
            this.notePanel_Graphic_TeaDept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Graphic_TeaDept.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Graphic_TeaDept.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Graphic_TeaDept.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Graphic_TeaDept.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Graphic_TeaDept.Location = new System.Drawing.Point(8, 88);
            this.notePanel_Graphic_TeaDept.MaxRows = 5;
            this.notePanel_Graphic_TeaDept.Name = "notePanel_Graphic_TeaDept";
            this.notePanel_Graphic_TeaDept.ParentAutoHeight = true;
            this.notePanel_Graphic_TeaDept.Size = new System.Drawing.Size(72, 22);
            this.notePanel_Graphic_TeaDept.TabIndex = 14;
            this.notePanel_Graphic_TeaDept.TabStop = false;
            this.notePanel_Graphic_TeaDept.Text = "所在部门";
            // 
            // notePanel_Graphic_TeaDuty
            // 
            this.notePanel_Graphic_TeaDuty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_Graphic_TeaDuty.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_Graphic_TeaDuty.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_Graphic_TeaDuty.ForeColor = System.Drawing.Color.Black;
            this.notePanel_Graphic_TeaDuty.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_Graphic_TeaDuty.Location = new System.Drawing.Point(8, 120);
            this.notePanel_Graphic_TeaDuty.MaxRows = 5;
            this.notePanel_Graphic_TeaDuty.Name = "notePanel_Graphic_TeaDuty";
            this.notePanel_Graphic_TeaDuty.ParentAutoHeight = true;
            this.notePanel_Graphic_TeaDuty.Size = new System.Drawing.Size(72, 22);
            this.notePanel_Graphic_TeaDuty.TabIndex = 15;
            this.notePanel_Graphic_TeaDuty.TabStop = false;
            this.notePanel_Graphic_TeaDuty.Text = "岗位";
            // 
            // textEdit_Graphic_TeaName
            // 
            this.textEdit_Graphic_TeaName.EditValue = "";
            this.textEdit_Graphic_TeaName.Location = new System.Drawing.Point(88, 56);
            this.textEdit_Graphic_TeaName.Name = "textEdit_Graphic_TeaName";
            this.textEdit_Graphic_TeaName.Size = new System.Drawing.Size(88, 20);
            this.textEdit_Graphic_TeaName.TabIndex = 17;
            // 
            // comboBoxEdit_Graphic_TeaDuty
            // 
            this.comboBoxEdit_Graphic_TeaDuty.EditValue = "全部";
            this.comboBoxEdit_Graphic_TeaDuty.Location = new System.Drawing.Point(88, 120);
            this.comboBoxEdit_Graphic_TeaDuty.Name = "comboBoxEdit_Graphic_TeaDuty";
            this.comboBoxEdit_Graphic_TeaDuty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_Graphic_TeaDuty.Properties.Items.AddRange(new object[] {
            "全部"});
            this.comboBoxEdit_Graphic_TeaDuty.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_Graphic_TeaDuty.Size = new System.Drawing.Size(88, 20);
            this.comboBoxEdit_Graphic_TeaDuty.TabIndex = 19;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = new System.DateTime(2005, 12, 31, 0, 0, 0, 0);
            this.dateEdit1.Location = new System.Drawing.Point(88, 152);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(88, 20);
            this.dateEdit1.TabIndex = 12;
            // 
            // notePanel6
            // 
            this.notePanel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel6.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel6.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel6.ForeColor = System.Drawing.Color.Black;
            this.notePanel6.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel6.Location = new System.Drawing.Point(8, 152);
            this.notePanel6.MaxRows = 5;
            this.notePanel6.Name = "notePanel6";
            this.notePanel6.ParentAutoHeight = true;
            this.notePanel6.Size = new System.Drawing.Size(72, 22);
            this.notePanel6.TabIndex = 10;
            this.notePanel6.TabStop = false;
            this.notePanel6.Text = "起始时间";
            // 
            // notePanel7
            // 
            this.notePanel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel7.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel7.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel7.ForeColor = System.Drawing.Color.Black;
            this.notePanel7.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel7.Location = new System.Drawing.Point(8, 184);
            this.notePanel7.MaxRows = 5;
            this.notePanel7.Name = "notePanel7";
            this.notePanel7.ParentAutoHeight = true;
            this.notePanel7.Size = new System.Drawing.Size(72, 22);
            this.notePanel7.TabIndex = 9;
            this.notePanel7.TabStop = false;
            this.notePanel7.Text = "结束时间";
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = new System.DateTime(2005, 12, 31, 0, 0, 0, 0);
            this.dateEdit2.Location = new System.Drawing.Point(88, 184);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit2.Size = new System.Drawing.Size(88, 20);
            this.dateEdit2.TabIndex = 11;
            // 
            // simpleButton_ReportAnalysis
            // 
            this.simpleButton_ReportAnalysis.Location = new System.Drawing.Point(24, 224);
            this.simpleButton_ReportAnalysis.Name = "simpleButton_ReportAnalysis";
            this.simpleButton_ReportAnalysis.Size = new System.Drawing.Size(64, 23);
            this.simpleButton_ReportAnalysis.TabIndex = 8;
            this.simpleButton_ReportAnalysis.Text = "分析";
            this.simpleButton_ReportAnalysis.Click += new System.EventHandler(this.simpleButton_ReportAnalysis_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(96, 224);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(64, 23);
            this.simpleButton2.TabIndex = 8;
            this.simpleButton2.Text = "生成报表";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // TeacherOnDutyInfo
            // 
            this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Appearance.Options.UseBackColor = true;
            this.Controls.Add(this.xtraTabControl_TeaDutyDetailInfo);
            this.Name = "TeacherOnDutyInfo";
            this.Size = new System.Drawing.Size(772, 540);
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_TeaDutyAsign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl2)).EndInit();
            this.popupContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl3)).EndInit();
            this.popupContainerControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl4)).EndInit();
            this.popupContainerControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl5)).EndInit();
            this.popupContainerControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl6)).EndInit();
            this.popupContainerControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl7)).EndInit();
            this.popupContainerControl7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_TeaDutyDetailInfo)).EndInit();
            this.xtraTabControl_TeaDutyDetailInfo.ResumeLayout(false);
            this.xtraTabPage_TeaDutyDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_TeaDutyAsign)).EndInit();
            this.groupControl_TeaDutyAsign.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_TeaDutyDetailsMgmt)).EndInit();
            this.groupControl_TeaDutyDetailsMgmt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl_DutyMgmt)).EndInit();
            this.splitContainerControl_DutyMgmt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_DutyStartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_AddDutyName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_AddDutyRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_DutyEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_DutyHistory.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_DutyHistory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_DutySearTeaClass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_DutySearTeaGarde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_DutySearTeaID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_DutySearTeaName.Properties)).EndInit();
            this.xtraTabPage_TeaOnDutyInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_TeaDutyDetailsStatistic)).EndInit();
            this.groupControl_TeaDutyDetailsStatistic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_TeaOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_TeaShouldAttend.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_TeaAttend.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_TeaAbsence.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_TeaOffTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_TeaOnTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_TeaDutyDetailsSearch)).EndInit();
            this.groupControl_TeaDutyDetailsSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_TeaDutyDetailsFlowType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_TeaDutyDetailsSerType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_TeaDutyDetailsSearByStartTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_TeaDutyDetailsSearByStartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_TeaDutyDetailsSearByGrade.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_TeaDutyDetailsSearByID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_TeaDutyDetailsSearByName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_TeaDutyDetailsSearByClass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_TeaDutyDetailsSearByEndTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_TeaDutyDetailsSearByEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_TeaDutyDetails)).EndInit();
            this.groupControl_TeaDutyDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_TeaDutySummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_TeaDutyNormal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl_Remarks)).EndInit();
            this.popupContainerControl_Remarks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_Remarks.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_TeaDutyDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_TeaDutyOutDetails)).EndInit();
            this.groupControl_TeaDutyOutDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_TeaOutDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            this.xtraTabPage_TeaOnDutyReports.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Graph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_TeaDutyReportsSear)).EndInit();
            this.groupControl_TeaDutyReportsSear.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Graphic_TeaDept.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Graphic_TeaID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Graphic_TeaName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Graphic_TeaDuty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region graph reports
		private void simpleButton_ReportAnalysis_Click(object sender, System.EventArgs e)
		{
			PerformeReportAnalysis();
		}

		private void simpleButton2_Click(object sender, System.EventArgs e)
		{
		}
		#endregion

		#region bind the duty data to the contral
		private void BindDutyData()
		{
			textEdit_AddDutyName.DataBindings.Add("EditValue",DutyInfo.Tables[0],"Teaduty_Name");
			textEdit_DutyStartTime.DataBindings.Add("Text",DutyInfo.Tables[0],"Teaduty_Begtime");
			textEdit_DutyEndTime.DataBindings.Add("Text",DutyInfo.Tables[0],"Teaduty_Endtime");
			textEdit_AddDutyRemark.DataBindings.Add("EditValue",DutyInfo.Tables[0],"Teaduty_Remark");
		}

		private void UnBindDutyData()
		{
			textEdit_AddDutyName.DataBindings.Clear();
			textEdit_DutyStartTime.DataBindings.Clear();
			textEdit_DutyEndTime.DataBindings.Clear();
			textEdit_AddDutyRemark.DataBindings.Clear();
		}
		#endregion

		#region load Grade&Class Info
		private void LoadGradeClassInfo()
		{
//			foreach(DataRow getGradeList in getStuInfoByCondition.getGradeInfo("","").Tables[0].Rows)
//			{
//				comboBoxEdit_DutySearTeaGarde.Properties.Items.AddRange(
//					new object[]{getGradeList[1].ToString()});
//				comboBoxEdit_TeaDutyDetailsSearByGrade.Properties.Items.AddRange(
//					new object[]{getGradeList[1].ToString()});
//			}
			DataSet deptInfo = new GradeSystem().GetGradeInfoList(1);

			if ( deptInfo.Tables[0].Rows.Count > 0 )
			{
				foreach(DataRow dept in deptInfo.Tables[0].Rows)
				{
					comboBoxEdit_DutySearTeaGarde.Properties.Items.AddRange(new object[]{dept[1].ToString()});
					comboBoxEdit_TeaDutyDetailsSearByGrade.Properties.Items.AddRange(new object[]{dept[1].ToString()});
					comboBoxEdit_Graphic_TeaDept.Properties.Items.AddRange(new object[]{dept[1].ToString()});
				}
			}
		}

		//班次页面
		private void comboBoxEdit_DutySearTeaGarde_SelectedIndexChanged(object sender, System.EventArgs e)
		{
//			if(getStuInfoByCondition.getGradeInfo(comboBoxEdit_DutySearTeaGarde.SelectedItem.ToString(),"").Tables[0].Rows.Count > 0)
//			{
//				comboBoxEdit_DutySearTeaClass.Properties.Items.Clear();
//				comboBoxEdit_DutySearTeaClass.Properties.Items.AddRange(new object[]{"全部"});
//				comboBoxEdit_DutySearTeaClass.SelectedItem = "全部";
//
//				//根据年级选择获取年级编号
//				getGradeNumberFromCombo = getStuInfoByCondition.getGradeInfo(
//					comboBoxEdit_DutySearTeaGarde.SelectedItem.ToString(),"").Tables[0].Rows[0][0].ToString();
//
//				foreach(DataRow getClassList in getStuInfoByCondition.getClassInfo("","",
//					getGradeNumberFromCombo).Tables[0].Rows)
//				{
//					comboBoxEdit_DutySearTeaClass.Properties.Items.AddRange(
//						new object[]{getClassList[1].ToString()});
//				}
//			}

			comboBoxEdit_DutySearTeaClass.Properties.Items.Clear();
			comboBoxEdit_DutySearTeaClass.Properties.Items.Add("全部");
			comboBoxEdit_DutySearTeaClass.SelectedItem = "全部";

			DataSet deptInfo = new GradeSystem().GetGradeInfoList(1);
			DataSet dutyInfo = new ClassSystem().GetClassInfoList();

			if ( dutyInfo.Tables[0].Rows.Count > 0 )
			{
				if ( comboBoxEdit_DutySearTeaGarde.SelectedItem.ToString().Equals("全部") )
				{
					foreach ( DataRow duty in dutyInfo.Tables[0].Rows )
					{
						comboBoxEdit_DutySearTeaClass.Properties.Items.Add(duty["info_className"].ToString());
					}
				}
				else
				{
					foreach ( DataRow dept in deptInfo.Tables[0].Rows )
					{
						if ( dept["info_gradeName"].ToString().Equals(comboBoxEdit_DutySearTeaGarde.SelectedItem.ToString()) )
						{
							foreach ( DataRow duty in dutyInfo.Tables[0].Rows )
							{
								if(Convert.ToInt32(duty["info_gradeNumber"]) == Convert.ToInt32(dept["info_gradeNumber"]))
								{
									comboBoxEdit_DutySearTeaClass.Properties.Items.Add(duty["info_className"].ToString());
								}	
							}
						}
					}			
				}					
			}	
		}

		private void comboBoxEdit_DutySearTeaClass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		//出勤页面
		private void comboBoxEdit_TeaDutyDetailsSearByGrade_SelectedIndexChanged(object sender, System.EventArgs e)
		{
//			if(getStuInfoByCondition.getGradeInfo(comboBoxEdit_TeaDutyDetailsSearByGrade.SelectedItem.ToString(),"").Tables[0].Rows.Count > 0)
//			{
//
//				comboBoxEdit_TeaDutyDetailsSearByClass.Properties.Items.Clear();
//				comboBoxEdit_TeaDutyDetailsSearByClass.Properties.Items.AddRange(new object[]{"全部"});
//				comboBoxEdit_TeaDutyDetailsSearByClass.SelectedItem = "全部";
//
//				//根据年级选择获取年级编号
//				getGradeNumberFromCombo = getStuInfoByCondition.getGradeInfo(
//					comboBoxEdit_TeaDutyDetailsSearByGrade.SelectedItem.ToString(),"").Tables[0].Rows[0][0].ToString();
//				foreach(DataRow getClassList in getStuInfoByCondition.getClassInfo("","",
//					getGradeNumberFromCombo).Tables[0].Rows)
//				{
//					comboBoxEdit_TeaDutyDetailsSearByClass.Properties.Items.AddRange(
//						new object[]{getClassList[1].ToString()});
//				}
//			}

			comboBoxEdit_TeaDutyDetailsSearByClass.Properties.Items.Clear();
			comboBoxEdit_TeaDutyDetailsSearByClass.Properties.Items.Add("全部");
			comboBoxEdit_TeaDutyDetailsSearByClass.SelectedItem = "全部";

			DataSet deptInfo = new GradeSystem().GetGradeInfoList(1);
			DataSet dutyInfo = new ClassSystem().GetClassInfoList();

			if ( dutyInfo.Tables[0].Rows.Count > 0 )
			{
				if ( comboBoxEdit_TeaDutyDetailsSearByGrade.SelectedItem.ToString().Equals("全部") )
				{
//					foreach ( DataRow duty in dutyInfo.Tables[0].Rows )
//					{
//						comboBoxEdit_TeaDutyDetailsSearByClass.Properties.Items.Add(duty["info_className"].ToString());
//					}
				}
				else
				{
					foreach ( DataRow dept in deptInfo.Tables[0].Rows )
					{
						if ( dept["info_gradeName"].ToString().Equals(comboBoxEdit_TeaDutyDetailsSearByGrade.SelectedItem.ToString()) )
						{
							foreach ( DataRow duty in dutyInfo.Tables[0].Rows )
							{
								if(Convert.ToInt32(duty["info_gradeNumber"]) == Convert.ToInt32(dept["info_gradeNumber"]))
								{
									comboBoxEdit_TeaDutyDetailsSearByClass.Properties.Items.Add(duty["info_className"].ToString());
								}
								
							}
						}
					}			
				}					
			}
		}

		private void comboBoxEdit_TeaDutyDetailsSearByClass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
		#endregion

		#region rewrite navigator
		private void dataNavigator_DutyDetails_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
		{
			appendClick = false;
			dataNavigator_DutyDetails.Buttons.Append.Enabled = true;

			switch(e.Button.ButtonType)
			{
				case NavigatorButtonType.Append:
					dataNavigator_DutyDetails.Buttons.Append.Enabled = false;
					appendClick = true;
					e.Handled = false;
					break;

				case NavigatorButtonType.Remove:
					if(DialogResult.Yes==(MessageBox.Show("确定要删除这条信息?","系统信息!",
						MessageBoxButtons.YesNo,MessageBoxIcon.Information)))
					{
						e.Handled = false;	
					}
					break;
				case NavigatorButtonType.EndEdit:
					e.Handled = true;
					

					if(!validateDataInfo())
					{
						dataNavigator_DutyDetails.Buttons.Append.Enabled = true;
						return;
					}

					dataNavigator_DutyDetails.BindingContext[DutyInfo.Tables[0]].EndCurrentEdit();

					if(DutyInfo.HasChanges())
					{
						int position = dataNavigator_DutyDetails.Position;
						int rowsEffected = new DutySystem().UpdateDutyInfoList(DutyInfo);

						if(rowsEffected>0)
						{
							DutyInfo = new DutySystem().GetDutyInfoList();
							if(dataNavigator_DutyDetails.BindingContext[DutyInfo.Tables[0]].Bindings.Count==0)
							{
								UnBindDutyData();
								BindDutyData();

								dataNavigator_DutyDetails.DataSource = DutyInfo.Tables[0];
								dataNavigator_DutyDetails.Position = position;
							}
							
							MessageBox.Show("保存成功.","系统信息!",MessageBoxButtons.OK,
								MessageBoxIcon.Information);
						}
					}

					
					dataNavigator_DutyDetails.Buttons.Append.Enabled = true;
					break;

				case NavigatorButtonType.CancelEdit:
					e.Handled = true;
					UnBindDutyData();
					DutyInfo = new DutySystem().GetDutyInfoList();
					dataNavigator_DutyDetails.DataSource = DutyInfo.Tables[0];
					BindDutyData();
					break;
			}
		}
		#endregion

		#region data validate
		private void textEdit_AddDutyName_Leave(object sender, System.EventArgs e)
		{
			if ( !appendClick )
			{
				string dutyName = textEdit_AddDutyName.Text;

				if(DutyInfo.Tables[0].Select("Teaduty_Name='"+dutyName+"'").Length>0
					&&DutyInfo.HasChanges())
				{
					MessageBox.Show("班次名称已存在,请更改!!","系统信息!",
						MessageBoxButtons.OK,MessageBoxIcon.Information);

					textEdit_AddDutyName.SelectAll();
				}
			}
		}

		private bool validateDataInfo()
		{
			if(textEdit_AddDutyName.Text.Trim().Length == 0)
			{
				MessageBox.Show("班次名称必须填写!!","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				textEdit_AddDutyName.SelectAll();
				return false;
			}
			else if(textEdit_DutyStartTime.Text.Trim().Length == 0)
			{
				MessageBox.Show("班次起始时间必须填写!!","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				textEdit_DutyStartTime.SelectAll();
				return false;
			}
			else if(textEdit_DutyEndTime.Text.Trim().Length == 0)
			{
				MessageBox.Show("班次结束时间必须填写!!","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				textEdit_DutyEndTime.SelectAll();
				return false;
			}
			else if(textEdit_DutyEndTime.Text.CompareTo(textEdit_DutyStartTime.Text)<=0)
			{
				MessageBox.Show("班次起始时间必须大于结束时间!!","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				textEdit_DutyStartTime.SelectAll();
				return false;
			}
			else
			{
				return true;
			}
		}
		#endregion

		#region select the teacher info
		private void simpleButton_TeaSearForDuty_Click(object sender, System.EventArgs e)
		{
			LoadSelectTeaDutyInfo();
		}

		private void LoadSelectTeaDutyInfo()
		{
			AllTeaDutyInfo = new DutySystem().GetAllTeaDutyInfo();
			AllTeadutyInfoView = AllTeaDutyInfo.Tables[0].DefaultView;

			string selectString = string.Empty;
			
			if ( Thread.CurrentPrincipal.IsInRole("园长") || Thread.CurrentPrincipal.Identity.Name.ToLower() == "admin" )
			{
				if(textEdit_DutySearTeaID.Text.Trim().Length != 0)
				{
					selectString += "T_Number like '%"+textEdit_DutySearTeaID.Text.Trim()+"%' ";
				}
				else
				{
					selectString += "T_Number like '%' ";
				}

				if(textEdit_DutySearTeaName.Text.Trim().Length != 0)
				{
					selectString += "and T_Name like '%"+textEdit_DutySearTeaName.Text.Trim()+"%' ";
				}
				else
				{
					selectString += "and T_Name like '%' ";
				}

				if(!comboBoxEdit_DutySearTeaGarde.SelectedItem.ToString().Equals("全部"))
				{
					selectString += "and T_Depart like '%"+comboBoxEdit_DutySearTeaGarde.SelectedItem.ToString()+"%' ";
				}
				else
				{
					selectString += "and T_Depart like '%' ";
				}

				if(!comboBoxEdit_DutySearTeaClass.SelectedItem.ToString().Equals("全部"))
				{
					selectString += "and T_Duty like '%"+comboBoxEdit_DutySearTeaClass.SelectedItem.ToString()+"%' ";
				}
				else
				{
					selectString += "and T_Duty like '%' ";
				}
			}
			else
			{
				selectString += "T_Number ='"+Thread.CurrentPrincipal.Identity.Name+"'";
			}

			AllTeadutyInfoView.RowFilter = selectString;

			LoadDutyInfoToCheckBox();

			gridControl_TeaDutyAsign.DataSource = AllTeadutyInfoView;

			for(int i = 0;i < gridView1.RowCount;i ++)
			{
				string mondayDuty = GetDutyNames(gridView1.GetDataRow(i)["teaonduty_monday"].ToString());
				string tuesdayDuty = GetDutyNames(gridView1.GetDataRow(i)["teaonduty_tuesday"].ToString());
				string wednesdayDuty = GetDutyNames(gridView1.GetDataRow(i)["teaonduty_wednesday"].ToString());
				string thursdayDuty = GetDutyNames(gridView1.GetDataRow(i)["teaonduty_thursday"].ToString());
				string fridayDuty = GetDutyNames(gridView1.GetDataRow(i)["teaonduty_friday"].ToString());
				string saturdayDuty = GetDutyNames(gridView1.GetDataRow(i)["teaonduty_saturday"].ToString());
				string sundayDuty = GetDutyNames(gridView1.GetDataRow(i)["teaonduty_sunday"].ToString());
				
				gridView1.SetRowCellValue(i,gridView1.Columns[4],mondayDuty);
				gridView1.SetRowCellValue(i,gridView1.Columns[5],tuesdayDuty);
				gridView1.SetRowCellValue(i,gridView1.Columns[6],wednesdayDuty);
				gridView1.SetRowCellValue(i,gridView1.Columns[7],thursdayDuty);
				gridView1.SetRowCellValue(i,gridView1.Columns[8],fridayDuty);
				gridView1.SetRowCellValue(i,gridView1.Columns[9],saturdayDuty);
				gridView1.SetRowCellValue(i,gridView1.Columns[10],sundayDuty);
			}
		}
		#endregion

		#region save teacher duty info
		private void simpleButton_SaveDutyAsign_Click(object sender, System.EventArgs e)
		{
			for(int i = 0;i < gridView1.RowCount;i ++)
			{
				string tID = gridView1.GetDataRow(i)["T_ID"].ToString();
				string mondayDuty = GetDutyNumbers(gridView1.GetDataRow(i)["teaonduty_monday"].ToString());
				string tuesdayDuty = GetDutyNumbers(gridView1.GetDataRow(i)["teaonduty_tuesday"].ToString());
				string wednesdayDuty = GetDutyNumbers(gridView1.GetDataRow(i)["teaonduty_wednesday"].ToString());
				string thursdayDuty = GetDutyNumbers(gridView1.GetDataRow(i)["teaonduty_thursday"].ToString());
				string fridayDuty = GetDutyNumbers(gridView1.GetDataRow(i)["teaonduty_friday"].ToString());
				string saturdayDuty = GetDutyNumbers(gridView1.GetDataRow(i)["teaonduty_saturday"].ToString());
				string sundayDuty = GetDutyNumbers(gridView1.GetDataRow(i)["teaonduty_sunday"].ToString());

				int rowsEffected = 0;

				rowsEffected = new DutySystem().UpdateTeaDutyDetail(tID,sundayDuty,mondayDuty,
					tuesdayDuty,wednesdayDuty,thursdayDuty,fridayDuty,saturdayDuty);
			}

			if ( !isSaveNextDuty )
				MessageBox.Show("保存完毕!","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);

		}

		private string GetDutyNumbers(string dutyNames)
		{
			if(dutyNames.Trim().Length == 0)
				return string.Empty;

			string[] splitDutyNames = dutyNames.Split(new char[]{','});

			string retrieveDutyNumbers = string.Empty;

			foreach(string dutyName in splitDutyNames)
			{
				string selectedFilter = "Teaduty_Name = '"  +dutyName+"'";

				DataRow[] dutyDetail = DutyInfo.Tables[0].Select(selectedFilter);

				if(dutyDetail.Length !=0)
				{
					retrieveDutyNumbers = retrieveDutyNumbers + 
						dutyDetail[0]["Teaduty_Dutynumber"].ToString() + ",";
				}
			}

			return retrieveDutyNumbers;

		}

		private string GetDutyNames(string dutyNumbers)
		{
			if(dutyNumbers.Trim().Length == 0)
				return string.Empty;

			string[] splitDutyNumbers = dutyNumbers.Substring(0,dutyNumbers.Length -1)
				.Split(new char[]{','});

			string retrieveDutyNames = string.Empty;

			foreach(string dutyNumber in splitDutyNumbers)
			{
				string selectedFilter = "Teaduty_Dutynumber = '"  +dutyNumber+"'";

				DataRow[] dutyDetail = DutyInfo.Tables[0].Select(selectedFilter);

				if(dutyDetail.Length !=0)
				{
					retrieveDutyNames = retrieveDutyNames + 
						dutyDetail[0]["Teaduty_Name"].ToString() + ",";
				}
			}

			if(retrieveDutyNames.Length > 0)
			{
				retrieveDutyNames = retrieveDutyNames.Substring(0,retrieveDutyNames.Length - 1);
			}

			return retrieveDutyNames;
		}

		#endregion

		#region load&display the chosen DutyInfo
		private void LoadDutyInfoToCheckBox()
		{
			checkedListBoxControl1.Items.Clear();
			checkedListBoxControl2.Items.Clear();
			checkedListBoxControl3.Items.Clear();
			checkedListBoxControl4.Items.Clear();
			checkedListBoxControl5.Items.Clear();
			checkedListBoxControl6.Items.Clear();
			checkedListBoxControl7.Items.Clear();

			foreach(DataRow rw in DutyInfo.Tables[0].Rows)
			{
				checkedListBoxControl1.Items.Add(new CheckedListBoxItem(rw["Teaduty_Name"]));
				checkedListBoxControl2.Items.Add(new CheckedListBoxItem(rw["Teaduty_Name"]));
				checkedListBoxControl3.Items.Add(new CheckedListBoxItem(rw["Teaduty_Name"]));
				checkedListBoxControl4.Items.Add(new CheckedListBoxItem(rw["Teaduty_Name"]));
				checkedListBoxControl5.Items.Add(new CheckedListBoxItem(rw["Teaduty_Name"]));
				checkedListBoxControl6.Items.Add(new CheckedListBoxItem(rw["Teaduty_Name"]));
				checkedListBoxControl7.Items.Add(new CheckedListBoxItem(rw["Teaduty_Name"]));
			}
		}

		private void repositoryItemPopupContainerEdit1_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
		{
			string chosenDutyName = string.Empty;
			for(int i = 0;i < checkedListBoxControl1.CheckedItems.Count;i ++)
			{
				chosenDutyName = chosenDutyName + checkedListBoxControl1.CheckedItems[i] + ",";
			}
			if(chosenDutyName.Length > 0)
			{
				e.Value = chosenDutyName.Substring(0,chosenDutyName.Length -1);
			}
			else
			{
				e.Value = chosenDutyName;
			}
		}

		private void repositoryItemPopupContainerEdit2_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
		{
			string chosenDutyName = string.Empty;
			for(int i = 0;i < checkedListBoxControl2.CheckedItems.Count;i ++)
			{
				chosenDutyName = chosenDutyName + checkedListBoxControl2.CheckedItems[i] + ",";
			}
			if(chosenDutyName.Length > 0)
			{
				e.Value = chosenDutyName.Substring(0,chosenDutyName.Length -1);
			}
			else
			{
				e.Value = chosenDutyName;
			}
		}

		private void repositoryItemPopupContainerEdit3_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
		{
			string chosenDutyName = string.Empty;
			for(int i = 0;i < checkedListBoxControl3.CheckedItems.Count;i ++)
			{
				chosenDutyName = chosenDutyName + checkedListBoxControl3.CheckedItems[i] + ",";
			}
			if(chosenDutyName.Length > 0)
			{
				e.Value = chosenDutyName.Substring(0,chosenDutyName.Length -1);
			}
			else
			{
				e.Value = chosenDutyName;
			}
		}

		private void repositoryItemPopupContainerEdit4_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
		{
			string chosenDutyName = string.Empty;
			for(int i = 0;i < checkedListBoxControl4.CheckedItems.Count;i ++)
			{
				chosenDutyName = chosenDutyName + checkedListBoxControl4.CheckedItems[i] + ",";
			}
			if(chosenDutyName.Length > 0)
			{
				e.Value = chosenDutyName.Substring(0,chosenDutyName.Length -1);
			}
			else
			{
				e.Value = chosenDutyName;
			}
		}

		private void repositoryItemPopupContainerEdit5_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
		{
			string chosenDutyName = string.Empty;
			for(int i = 0;i < checkedListBoxControl5.CheckedItems.Count;i ++)
			{
				chosenDutyName = chosenDutyName + checkedListBoxControl5.CheckedItems[i] + ",";
			}
			if(chosenDutyName.Length > 0)
			{
				e.Value = chosenDutyName.Substring(0,chosenDutyName.Length -1);
			}
			else
			{
				e.Value = chosenDutyName;
			}
		}

		private void repositoryItemPopupContainerEdit6_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
		{
			string chosenDutyName = string.Empty;
			for(int i = 0;i < checkedListBoxControl6.CheckedItems.Count;i ++)
			{
				chosenDutyName = chosenDutyName + checkedListBoxControl6.CheckedItems[i] + ",";
			}

			if(chosenDutyName.Length > 0)
			{
				e.Value = chosenDutyName.Substring(0,chosenDutyName.Length -1);
			}
			else
			{
				e.Value = chosenDutyName;
			}
		}

		private void repositoryItemPopupContainerEdit7_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
		{
			string chosenDutyName = string.Empty;
			for(int i = 0;i < checkedListBoxControl7.CheckedItems.Count;i ++)
			{
				chosenDutyName = chosenDutyName + checkedListBoxControl7.CheckedItems[i] + ",";
			}
			if(chosenDutyName.Length > 0)
			{
				e.Value = chosenDutyName.Substring(0,chosenDutyName.Length -1);
			}
			else
			{
				e.Value = chosenDutyName;
			}
		}

		private void repositoryItemPopupContainerEdit1_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
		{
			BaseEdit editor = sender as BaseEdit;
			foreach(CheckedListBoxItem item in checkedListBoxControl1.Items) 
				item.CheckState = (editor.EditValue.ToString().IndexOf(item.Value.ToString()) > -1)
					? CheckState.Checked : CheckState.Unchecked;
			checkedListBoxControl1.SelectedIndex = 0;
		}

		private void repositoryItemPopupContainerEdit2_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
		{
			BaseEdit editor = sender as BaseEdit;
			foreach(CheckedListBoxItem item in checkedListBoxControl2.Items) 
				item.CheckState = (editor.EditValue.ToString().IndexOf(item.Value.ToString()) > -1)
					? CheckState.Checked : CheckState.Unchecked;
			checkedListBoxControl1.SelectedIndex = 0;
		}

		private void repositoryItemPopupContainerEdit3_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
		{
			BaseEdit editor = sender as BaseEdit;
			foreach(CheckedListBoxItem item in checkedListBoxControl3.Items) 
				item.CheckState = (editor.EditValue.ToString().IndexOf(item.Value.ToString()) > -1)
					? CheckState.Checked : CheckState.Unchecked;
			checkedListBoxControl1.SelectedIndex = 0;
		}

		private void repositoryItemPopupContainerEdit4_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
		{
			BaseEdit editor = sender as BaseEdit;
			foreach(CheckedListBoxItem item in checkedListBoxControl4.Items) 
				item.CheckState = (editor.EditValue.ToString().IndexOf(item.Value.ToString()) > -1)
					? CheckState.Checked : CheckState.Unchecked;
			checkedListBoxControl1.SelectedIndex = 0;
		}

		private void repositoryItemPopupContainerEdit5_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
		{
			BaseEdit editor = sender as BaseEdit;
			foreach(CheckedListBoxItem item in checkedListBoxControl5.Items) 
				item.CheckState = (editor.EditValue.ToString().IndexOf(item.Value.ToString()) > -1)
					? CheckState.Checked : CheckState.Unchecked;
			checkedListBoxControl1.SelectedIndex = 0;
		}

		private void repositoryItemPopupContainerEdit6_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
		{
			BaseEdit editor = sender as BaseEdit;
			foreach(CheckedListBoxItem item in checkedListBoxControl6.Items) 
				item.CheckState = (editor.EditValue.ToString().IndexOf(item.Value.ToString()) > -1)
					? CheckState.Checked : CheckState.Unchecked;
			checkedListBoxControl1.SelectedIndex = 0;
		}

		private void repositoryItemPopupContainerEdit7_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
		{
			BaseEdit editor = sender as BaseEdit;
			foreach(CheckedListBoxItem item in checkedListBoxControl7.Items) 
				item.CheckState = (editor.EditValue.ToString().IndexOf(item.Value.ToString()) > -1)
					? CheckState.Checked : CheckState.Unchecked;
			checkedListBoxControl1.SelectedIndex = 0;
		}
		#endregion

		#region show Chosen Duty Tips
		private void checkedListBoxControl1_Click(object sender, System.EventArgs e)
		{
			if(checkedListBoxControl1.SelectedItem != null)
			{
				string selectedValue = checkedListBoxControl1.SelectedValue.ToString();
				string selectedFilter = "Teaduty_Name = '"  +selectedValue+"'";

				DataRow[] dutyDetail = DutyInfo.Tables[0].Select(selectedFilter);

				string tips = "班次起始时间:"+dutyDetail[0]["Teaduty_Begtime"].ToString()
					+" 结束时间:" + dutyDetail[0]["Teaduty_Endtime"].ToString();

				toolTipController1.ShowHint(tips);
			}
		}

		private void checkedListBoxControl4_Click(object sender, System.EventArgs e)
		{
			if(checkedListBoxControl4.SelectedItem != null)
			{
				string selectedValue = checkedListBoxControl4.SelectedValue.ToString();
				string selectedFilter = "Teaduty_Name = '"  +selectedValue+"'";

				DataRow[] dutyDetail = DutyInfo.Tables[0].Select(selectedFilter);

				string tips = "班次起始时间:"+dutyDetail[0]["Teaduty_Begtime"].ToString()
					+" 结束时间:" + dutyDetail[0]["Teaduty_Endtime"].ToString();

				toolTipController1.ShowHint(tips);
			}
		}

		private void checkedListBoxControl5_Click(object sender, System.EventArgs e)
		{
			if(checkedListBoxControl5.SelectedItem != null)
			{
				string selectedValue = checkedListBoxControl5.SelectedValue.ToString();
				string selectedFilter = "Teaduty_Name = '"  +selectedValue+"'";

				DataRow[] dutyDetail = DutyInfo.Tables[0].Select(selectedFilter);

				string tips = "班次起始时间:"+dutyDetail[0]["Teaduty_Begtime"].ToString()
					+" 结束时间:" + dutyDetail[0]["Teaduty_Endtime"].ToString();

				toolTipController1.ShowHint(tips);
			}
		}

		private void checkedListBoxControl2_Click(object sender, System.EventArgs e)
		{
			if(checkedListBoxControl2.SelectedItem != null)
			{
				string selectedValue = checkedListBoxControl2.SelectedValue.ToString();
				string selectedFilter = "Teaduty_Name = '"  +selectedValue+"'";

				DataRow[] dutyDetail = DutyInfo.Tables[0].Select(selectedFilter);

				string tips = "班次起始时间:"+dutyDetail[0]["Teaduty_Begtime"].ToString()
					+" 结束时间:" + dutyDetail[0]["Teaduty_Endtime"].ToString();

				toolTipController1.ShowHint(tips);
			}
		}

		private void checkedListBoxControl3_Click(object sender, System.EventArgs e)
		{
			if(checkedListBoxControl3.SelectedItem != null)
			{
				string selectedValue = checkedListBoxControl3.SelectedValue.ToString();
				string selectedFilter = "Teaduty_Name = '"  +selectedValue+"'";

				DataRow[] dutyDetail = DutyInfo.Tables[0].Select(selectedFilter);

				string tips = "班次起始时间:"+dutyDetail[0]["Teaduty_Begtime"].ToString()
					+" 结束时间:" + dutyDetail[0]["Teaduty_Endtime"].ToString();

				toolTipController1.ShowHint(tips);
			}
		}

		private void checkedListBoxControl6_Click(object sender, System.EventArgs e)
		{
			if(checkedListBoxControl6.SelectedItem != null)
			{
				string selectedValue = checkedListBoxControl6.SelectedValue.ToString();
				string selectedFilter = "Teaduty_Name = '"  +selectedValue+"'";

				DataRow[] dutyDetail = DutyInfo.Tables[0].Select(selectedFilter);

				string tips = "班次起始时间:"+dutyDetail[0]["Teaduty_Begtime"].ToString()
					+" 结束时间:" + dutyDetail[0]["Teaduty_Endtime"].ToString();

				toolTipController1.ShowHint(tips);
			}	
		}

		private void checkedListBoxControl7_Click(object sender, System.EventArgs e)
		{
			if(checkedListBoxControl7.SelectedItem != null)
			{
				string selectedValue = checkedListBoxControl7.SelectedValue.ToString();
				string selectedFilter = "Teaduty_Name = '"  +selectedValue+"'";

				DataRow[] dutyDetail = DutyInfo.Tables[0].Select(selectedFilter);

				string tips = "班次起始时间:"+dutyDetail[0]["Teaduty_Begtime"].ToString()
					+" 结束时间:" + dutyDetail[0]["Teaduty_Endtime"].ToString();

				toolTipController1.ShowHint(tips);
			}
		}
		#endregion

		#region Teacher Duty Details
		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			if ( comboBoxEdit_TeaDutyDetailsSerType.SelectedIndex == 0 )
				SearchTeaDutyNormal();
			else if ( comboBoxEdit_TeaDutyDetailsSerType.SelectedIndex == 1 )
				SearchTeaDutyDetails();
			else 
				SearchTeaDutySummary();
		}

		private void SearchTeaDutyDetails()
		{
			if(dateEdit_TeaDutyDetailsSearByStartTime.Text.Trim().Length == 0)
			{
				MessageBox.Show("起始时间必须选择!!","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}
			else if(dateEdit_TeaDutyDetailsSearByEndTime.Text.Trim().Length == 0)
			{
				MessageBox.Show("结束时间必须选择!!","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}
			else if(Convert.ToDateTime(dateEdit_TeaDutyDetailsSearByStartTime.DateTime.ToString("yyyy-MM-dd"))>
				Convert.ToDateTime(dateEdit_TeaDutyDetailsSearByEndTime.DateTime.ToString("yyyy-MM-dd")))
			{
				MessageBox.Show("选择结束时间必须大于开始时间!!","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}

			string startTime = dateEdit_TeaDutyDetailsSearByStartTime.DateTime.ToString("yyyy-MM-dd");
			string endTime = dateEdit_TeaDutyDetailsSearByEndTime.DateTime.ToString("yyyy-MM-dd");

			if ( dateEdit_TeaDutyDetailsSearByStartTime.DateTime.Date <= dateEdit_TeaDutyDetailsSearByEndTime.DateTime.Date  )
			{
				if(textEdit_TeaDutyDetailsSearByID.Text.Equals("")  && textEdit_TeaDutyDetailsSearByName.Text.Equals(""))
				{
					if(comboBoxEdit_TeaDutyDetailsSearByGrade.SelectedItem.ToString().Equals("全部"))
					{
						gridDutyDetail(startTime,endTime,"","","","");
						gridDutyOut(dateEdit_TeaDutyDetailsSearByStartTime.DateTime.Date,dateEdit_TeaDutyDetailsSearByEndTime.DateTime.Date,"","","","");

					}
					else if(comboBoxEdit_TeaDutyDetailsSearByClass.SelectedItem.ToString().Equals("全部"))
					{
						gridDutyDetail(startTime,endTime,comboBoxEdit_TeaDutyDetailsSearByGrade.SelectedItem.ToString(),"","","");
						gridDutyOut(dateEdit_TeaDutyDetailsSearByStartTime.DateTime.Date,
							dateEdit_TeaDutyDetailsSearByEndTime.DateTime.Date,comboBoxEdit_TeaDutyDetailsSearByGrade.SelectedItem.ToString(),"","","");
					}
					else
					{
						gridDutyDetail(startTime,endTime,comboBoxEdit_TeaDutyDetailsSearByGrade.SelectedItem.ToString(),comboBoxEdit_TeaDutyDetailsSearByClass.SelectedItem.ToString(),"","");
						gridDutyOut(dateEdit_TeaDutyDetailsSearByStartTime.DateTime.Date,dateEdit_TeaDutyDetailsSearByEndTime.DateTime.Date,comboBoxEdit_TeaDutyDetailsSearByGrade.SelectedItem.ToString(),comboBoxEdit_TeaDutyDetailsSearByClass.SelectedItem.ToString(),"","");
					}
						
				}
				else
				{
					if ( textEdit_TeaDutyDetailsSearByID.Text.Equals("") )
					{
						gridDutyDetail(startTime,endTime,"","",textEdit_TeaDutyDetailsSearByName.Text.Trim(),"");
						gridDutyOut(dateEdit_TeaDutyDetailsSearByStartTime.DateTime.Date,
							dateEdit_TeaDutyDetailsSearByEndTime.DateTime.Date,"","",textEdit_TeaDutyDetailsSearByName.Text.Trim(),"");
					}
					else
					{
						gridDutyDetail(startTime,endTime,"","","",textEdit_TeaDutyDetailsSearByID.Text.Trim());
						gridDutyOut(dateEdit_TeaDutyDetailsSearByStartTime.DateTime.Date,
							dateEdit_TeaDutyDetailsSearByEndTime.DateTime.Date,"","","",textEdit_TeaDutyDetailsSearByID.Text.Trim());
					}
				}
			}

//			DutyDetailsView = DutyDetails.Tables[0].DefaultView;
//
//			OutDetails = new DutySystem().GetTeaOutDetails(dateEdit_TeaDutyDetailsSearByStartTime.DateTime,
//				dateEdit_TeaDutyDetailsSearByEndTime.DateTime);
//			OutDetailsView = OutDetails.Tables[0].DefaultView;
//
//			string selectString = string.Empty;
//			string outSelectString = string.Empty;

//			if ( Thread.CurrentPrincipal.IsInRole("园长") || Thread.CurrentPrincipal.Identity.Name.ToLower() == "admin" )
//			{
				
//			}
//			else
//			{
//				selectString += "T_Number ='"+Thread.CurrentPrincipal.Identity.Name+"'";
//				outSelectString += "T_Number ='"+Thread.CurrentPrincipal.Identity.Name+"'";
//			}

//			DutyDetailsView.RowFilter = selectString;
//			gridControl_TeaDutyDetails.DataSource = DutyDetailsView;
//
//			OutDetailsView.RowFilter = outSelectString;
//			gridControl_TeaOutDetails.DataSource = OutDetailsView;

			CalcTeaDutyInfo();
		}

		private void SearchTeaDutyNormal()
		{
			if ( dateEdit_TeaDutyDetailsSearByStartTime.DateTime.Date <= dateEdit_TeaDutyDetailsSearByEndTime.DateTime.Date  )
			{
				if(textEdit_TeaDutyDetailsSearByID.Text.Equals("")  && textEdit_TeaDutyDetailsSearByName.Text.Equals(""))
				{
					if(comboBoxEdit_TeaDutyDetailsSearByGrade.SelectedItem.ToString().Equals("全部"))
					{
						gridDutyNormal("","","","",dateEdit_TeaDutyDetailsSearByStartTime.DateTime.Date,dateEdit_TeaDutyDetailsSearByEndTime.DateTime.Date,
							comboBoxEdit_TeaDutyDetailsFlowType.SelectedIndex == 2 ? 100 : comboBoxEdit_TeaDutyDetailsFlowType.SelectedIndex);

					}
					else if(comboBoxEdit_TeaDutyDetailsSearByClass.SelectedItem.ToString().Equals("全部"))
					{
						gridDutyNormal(comboBoxEdit_TeaDutyDetailsSearByGrade.SelectedItem.ToString(),"","","",dateEdit_TeaDutyDetailsSearByStartTime.DateTime.Date,
							dateEdit_TeaDutyDetailsSearByEndTime.DateTime.Date,
							comboBoxEdit_TeaDutyDetailsFlowType.SelectedIndex == 2 ? 100 : comboBoxEdit_TeaDutyDetailsFlowType.SelectedIndex);
					}
					else
					{
						gridDutyNormal(comboBoxEdit_TeaDutyDetailsSearByGrade.SelectedItem.ToString(),comboBoxEdit_TeaDutyDetailsSearByClass.SelectedItem.ToString(),
							"","",dateEdit_TeaDutyDetailsSearByStartTime.DateTime.Date,dateEdit_TeaDutyDetailsSearByEndTime.DateTime.Date,
							comboBoxEdit_TeaDutyDetailsFlowType.SelectedIndex == 2 ? 100 : comboBoxEdit_TeaDutyDetailsFlowType.SelectedIndex);
					}
						
				}
				else
				{
					if ( textEdit_TeaDutyDetailsSearByID.Text.Equals("") )
					{
						gridDutyNormal("","",textEdit_TeaDutyDetailsSearByName.Text.Trim(),"",dateEdit_TeaDutyDetailsSearByStartTime.DateTime.Date,
							dateEdit_TeaDutyDetailsSearByEndTime.DateTime.Date,
							comboBoxEdit_TeaDutyDetailsFlowType.SelectedIndex == 2 ? 100 : comboBoxEdit_TeaDutyDetailsFlowType.SelectedIndex);
					}
					else
					{
						gridDutyNormal("","","",textEdit_TeaDutyDetailsSearByID.Text.Trim(),dateEdit_TeaDutyDetailsSearByStartTime.DateTime.Date,
							dateEdit_TeaDutyDetailsSearByEndTime.DateTime.Date,
							comboBoxEdit_TeaDutyDetailsFlowType.SelectedIndex == 2 ? 100 : comboBoxEdit_TeaDutyDetailsFlowType.SelectedIndex);
					}
				}
			}
			else
				MessageBox.Show("选择结束时间必须大于开始时间!!","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		private void SearchTeaDutySummary()
		{
			if ( dateEdit_TeaDutyDetailsSearByStartTime.DateTime.Date <= dateEdit_TeaDutyDetailsSearByEndTime.DateTime.Date )
			{
				if(textEdit_TeaDutyDetailsSearByID.Text.Equals("")  && textEdit_TeaDutyDetailsSearByName.Text.Equals(""))
				{
					if(comboBoxEdit_TeaDutyDetailsSearByGrade.SelectedItem.ToString().Equals("全部"))
					{
						gridDutySummary(dateEdit_TeaDutyDetailsSearByStartTime.DateTime.Date,
							dateEdit_TeaDutyDetailsSearByEndTime.DateTime.Date,"","","","");

					}
					else if(comboBoxEdit_TeaDutyDetailsSearByClass.SelectedItem.ToString().Equals("全部"))
					{
						gridDutySummary(dateEdit_TeaDutyDetailsSearByStartTime.DateTime.Date,
							dateEdit_TeaDutyDetailsSearByEndTime.DateTime.Date,comboBoxEdit_TeaDutyDetailsSearByGrade.SelectedItem.ToString(),
							"","","");
					}
					else
					{
						gridDutySummary(dateEdit_TeaDutyDetailsSearByStartTime.DateTime.Date,
							dateEdit_TeaDutyDetailsSearByEndTime.DateTime.Date,comboBoxEdit_TeaDutyDetailsSearByGrade.SelectedItem.ToString(),
							comboBoxEdit_TeaDutyDetailsSearByClass.SelectedItem.ToString(),"","");
					}
						
				}
				else
				{
					if ( textEdit_TeaDutyDetailsSearByID.Text.Equals("") )
					{
						gridDutySummary(dateEdit_TeaDutyDetailsSearByStartTime.DateTime.Date,
							dateEdit_TeaDutyDetailsSearByEndTime.DateTime.Date,"","",textEdit_TeaDutyDetailsSearByName.Text,"");
					}
					else
					{
						gridDutySummary(dateEdit_TeaDutyDetailsSearByStartTime.DateTime.Date,
							dateEdit_TeaDutyDetailsSearByEndTime.DateTime.Date,"","","",textEdit_TeaDutyDetailsSearByID.Text);
					}
				}
			}
			else
				MessageBox.Show("选择结束时间必须大于开始时间!!","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);

			CalcTeaDutyInfo();
		}
	
		private void CalcTeaDutyInfo()
		{
			string[] getStat = new string[6];
			if(textEdit_TeaDutyDetailsSearByID.Text.Equals("")  && textEdit_TeaDutyDetailsSearByName.Text.Equals(""))
			{
				if(comboBoxEdit_TeaDutyDetailsSearByGrade.SelectedItem.ToString().Equals("全部"))
				{
					getStat = new DutySystem().CalcTeaDutyInfo(dateEdit_TeaDutyDetailsSearByStartTime.DateTime.Date,
						dateEdit_TeaDutyDetailsSearByEndTime.DateTime.Date,"","","","");

				}
				else if(comboBoxEdit_TeaDutyDetailsSearByClass.SelectedItem.ToString().Equals("全部"))
				{
					getStat = new DutySystem().CalcTeaDutyInfo(dateEdit_TeaDutyDetailsSearByStartTime.DateTime.Date,
						dateEdit_TeaDutyDetailsSearByEndTime.DateTime.Date,comboBoxEdit_TeaDutyDetailsSearByGrade.SelectedItem.ToString(),
						"","","");
				}
				else
				{
					getStat = new DutySystem().CalcTeaDutyInfo(dateEdit_TeaDutyDetailsSearByStartTime.DateTime.Date,
						dateEdit_TeaDutyDetailsSearByEndTime.DateTime.Date,comboBoxEdit_TeaDutyDetailsSearByGrade.SelectedItem.ToString(),
						comboBoxEdit_TeaDutyDetailsSearByClass.SelectedItem.ToString(),"","");
				}
						
			}
			else
			{
				if ( textEdit_TeaDutyDetailsSearByID.Text.Equals("") )
				{
					getStat = new DutySystem().CalcTeaDutyInfo(dateEdit_TeaDutyDetailsSearByStartTime.DateTime.Date,
						dateEdit_TeaDutyDetailsSearByEndTime.DateTime.Date,"","",textEdit_TeaDutyDetailsSearByName.Text,"");
				}
				else
				{
					getStat = new DutySystem().CalcTeaDutyInfo(dateEdit_TeaDutyDetailsSearByStartTime.DateTime.Date,
						dateEdit_TeaDutyDetailsSearByEndTime.DateTime.Date,"","","",textEdit_TeaDutyDetailsSearByID.Text);
				}
			}

			textEdit_TeaOnTime.Text = getStat[0];
			textEdit_TeaOffTime.Text = getStat[1];
			textEdit_TeaAbsence.Text = getStat[2];
			textEdit_TeaAttend.Text = getStat[3];
			textEdit_TeaShouldAttend.Text = getStat[4];
			textEdit_TeaOut.Text = getStat[5];
		}

		#endregion

		#region create teacher duty details excel report
		private void simpleButton_SearTeaDutyDetails_Click(object sender, System.EventArgs e)
		{
			saveFileDialog_Report.Filter = "Excel文件|*.xls";

			if(saveFileDialog_Report.ShowDialog()!=DialogResult.OK)
				return;

			string savePath = saveFileDialog_Report.FileName;

			if ( comboBoxEdit_TeaDutyDetailsSerType.SelectedIndex == 0 )
			{
				if ( advBandedGridView3.RowCount == 0 )
				{ 
					MessageBox.Show("没有要导出的数据!","系统信息!",
						MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}

				new DutySystem().ImportTeaDutyNormalReports(dsTeaDutyNormal,savePath,dateEdit_TeaDutyDetailsSearByStartTime.DateTime.Date,dateEdit_TeaDutyDetailsSearByEndTime.DateTime.Date);

				MessageBox.Show("报表生成完毕!","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			else if ( comboBoxEdit_TeaDutyDetailsSerType.SelectedIndex == 1 )
			{
				if ( advBandedGridView2.RowCount == 0 )
				{ 
					MessageBox.Show("没有要导出的数据!","系统信息!",
						MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}

				new DutySystem().ImportTeaDutyDetailsReports(dsTeaDutyDetail,savePath,dateEdit_TeaDutyDetailsSearByStartTime.DateTime.Date,dateEdit_TeaDutyDetailsSearByEndTime.DateTime.Date);

				MessageBox.Show("报表生成完毕!","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			else
			{
				if ( advBandedGridView4.RowCount == 0 )
				{ 
					MessageBox.Show("没有要导出的数据!","系统信息!",
						MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}

				new DutySystem().ImportTeaDutySummaryReports(dsTeaDutySummary,savePath,dateEdit_TeaDutyDetailsSearByStartTime.DateTime.Date,dateEdit_TeaDutyDetailsSearByEndTime.DateTime.Date);

				MessageBox.Show("报表生成完毕!","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}

		private void simpleButton3_Click(object sender, System.EventArgs e)
		{

			saveFileDialog_Report.Filter = "Excel文件|*.xls";

			if(saveFileDialog_Report.ShowDialog()!=DialogResult.OK)
				return;

			string savePath = saveFileDialog_Report.FileName;
	
			if ( gridView4.RowCount == 0 )
			{
				MessageBox.Show("没有要导出的数据!","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}

			new DutySystem().ImportTeaOutDetailsReports(dsTeaOutDetail,savePath,dateEdit_TeaDutyDetailsSearByStartTime.DateTime.Date,dateEdit_TeaDutyDetailsSearByEndTime.DateTime.Date);

			MessageBox.Show("报表生成完毕!","系统信息!",
				MessageBoxButtons.OK,MessageBoxIcon.Information);
		}
		#endregion

		#region 打印全部统计
		private void simpleButton4_Click(object sender, System.EventArgs e)
		{
			saveFileDialog_Report.Filter = "Excel文件|*.xls";

			if(saveFileDialog_Report.ShowDialog()!=DialogResult.OK)
				return;

			string savePath = saveFileDialog_Report.FileName;

			new DutySystem().ExportTeacherAllReports(savePath, Convert.ToDateTime(dateEdit_TeaDutyDetailsSearByStartTime.EditValue), Convert.ToDateTime(dateEdit_TeaDutyDetailsSearByEndTime.EditValue));

			MessageBox.Show("报表生成完毕！");
		}
		#endregion

		#region save remarks
		private void repositoryItemPopupContainerEdit8_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
		{
			e.Value = memoEdit_Remarks.Text;

			int teaOndutyID = Convert.ToInt32(advBandedGridView2.GetDataRow(
				advBandedGridView2.GetSelectedRows()[0])["teaondutyanaly_number"]);

			new DutySystem().UpdateTeaOndutyRemarks(teaOndutyID,memoEdit_Remarks.Text.Trim());
		}

		private void repositoryItemPopupContainerEdit8_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
		{
			memoEdit_Remarks.Text = advBandedGridView2.GetRowCellValue(
				advBandedGridView2.GetSelectedRows()[0],advBandedGridView2.Columns[12]).ToString();
		}
		#endregion

		private void textEdit_AddDutyName_EditValueChanged(object sender, System.EventArgs e)
		{
			if ( appendClick )
			{
				foreach ( DataRow dutyInfoRow in new DutySystem().GetDutyInfoList().Tables[0].Rows)
				{
					if ( textEdit_AddDutyName.EditValue.ToString().Equals(dutyInfoRow["Teaduty_Name"]))
					{
						dataNavigator_DutyDetails.Buttons.Append.Enabled = false;
						MessageBox.Show("班次名称已存在,请更改!!","系统信息!",MessageBoxButtons.OK,MessageBoxIcon.Information);
						break;
					}
				}
			}
		}
		#region load history or current duty
		private void simpleButton_LoadHisDuty_Click(object sender, System.EventArgs e)
		{
			if ( !isSaveNextDuty )
			{
				string message = "是否要装载历史班次记录？";
				string caption = "消息提示框!";
				DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
				if ( messageResult == DialogResult.Yes )
				{
					int getErrorMsg = new DutySystem().UpdateDutyInfo(dateEdit_DutyHistory.DateTime.Date.AddDays(7),false);
					if ( getErrorMsg == -1)
						MessageBox.Show("该时间段内的班次不存在，请重新选择！");
				
					simpleButton_LoadHisDuty.ForeColor = Color.OrangeRed;
					simpleButton_LoadCurDuty.ForeColor = Color.Black;
				}

				simpleButton_LoadCurDuty.Enabled = true;
				simpleButton_TeaSearForDuty.PerformClick();
			}
			else
			{
				int getErrorMsg = new DutySystem().UpdateDutyInfo(dateEdit_DutyHistory.DateTime.Date.AddYears(10),false);
			}
		}

		private void simpleButton_LoadCurDuty_Click(object sender, System.EventArgs e)
		{
			string message = "是否要装载本周班次？";
			string caption = "消息提示框!";
			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult == DialogResult.Yes )
			{
				int getErrorMsg = new DutySystem().UpdateDutyInfo(dateEdit_DutyHistory.DateTime.Date.AddDays(7),true);
				if ( getErrorMsg == -1 )
					MessageBox.Show("当前班次即是本周班次，不用载入！");
			}

			simpleButton_LoadHisDuty.ForeColor = Color.Black;
			simpleButton_LoadCurDuty.ForeColor = Color.OrangeRed;

			simpleButton_LoadCurDuty.Enabled = false;

			simpleButton_TeaSearForDuty.PerformClick();
		}
		#endregion

		private void comboBoxEdit_Graphic_TeaDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			comboBoxEdit_Graphic_TeaDuty.Properties.Items.Clear();
			comboBoxEdit_Graphic_TeaDuty.Properties.Items.Add("全部");
			comboBoxEdit_Graphic_TeaDuty.SelectedItem = "全部";

			DataSet deptInfo = new GradeSystem().GetGradeInfoList(1);
			DataSet dutyInfo = new ClassSystem().GetClassInfoList();

			if ( dutyInfo.Tables[0].Rows.Count > 0 )
			{
				if ( comboBoxEdit_Graphic_TeaDept.SelectedItem.ToString().Equals("全部") )
				{
//					foreach ( DataRow duty in dutyInfo.Tables[0].Rows )
//					{
//						comboBoxEdit_Graphic_TeaDuty.Properties.Items.Add(duty["info_className"].ToString());
//					}
				}
				else
				{
					foreach ( DataRow dept in deptInfo.Tables[0].Rows )
					{
						if ( dept["info_gradeName"].ToString().Equals(comboBoxEdit_Graphic_TeaDept.SelectedItem.ToString()) )
						{
							foreach ( DataRow duty in dutyInfo.Tables[0].Rows )
							{
								if(Convert.ToInt32(duty["info_gradeNumber"]) == Convert.ToInt32(dept["info_gradeNumber"]))
								{
									comboBoxEdit_Graphic_TeaDuty.Properties.Items.Add(duty["info_className"].ToString());
								}		
							}
						}
					}			
				}					
			}
		}

		#region select type option
		private void comboBoxEdit_TeaDutyDetailsSerType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( comboBoxEdit_TeaDutyDetailsSerType.SelectedIndex == 0 )
			{
				gridControl_TeaDutyNormal.Visible = true;
				gridControl_TeaDutyDetails.Visible = false;
				gridControl_TeaDutySummary.Visible = false;
				simpleButton3.Enabled = false;
			}
			else if ( comboBoxEdit_TeaDutyDetailsSerType.SelectedIndex == 1 )
			{
				gridControl_TeaDutyNormal.Visible = false;
				gridControl_TeaDutyDetails.Visible = true;
				gridControl_TeaDutySummary.Visible = false;
				simpleButton3.Enabled = true;
			}
			else
			{
				gridControl_TeaDutyNormal.Visible = false;
				gridControl_TeaDutyDetails.Visible = false;
				gridControl_TeaDutySummary.Visible = true;
				simpleButton3.Enabled = true;
			}
		}
		#endregion

		private void gridDutyNormal(string getDept,string getDuty,string getName,string getNumber,DateTime getBegDate,DateTime getEndDate, int state)
		{
				
			dsTeaDutyNormal = new DutySystem().GetTeaDutyNormail(getDept,getDuty,getName,getNumber,getBegDate,getEndDate,state);

			if ( dsTeaDutyNormal.Tables[0] != null )
				gridControl_TeaDutyNormal.DataSource = dsTeaDutyNormal.Tables[0];

			textEdit_TeaAbsence.Text = string.Empty;
			textEdit_TeaAttend.Text = string.Empty;
			textEdit_TeaOnTime.Text = string.Empty;
			textEdit_TeaOffTime.Text = string.Empty;
			textEdit_TeaOut.Text = string.Empty;
			textEdit_TeaShouldAttend.Text = string.Empty;
		}

		private void gridDutyDetail(string begDate,string endDate,string getDept,string getDuty,string getName,string getNumber)
		{
			dsTeaDutyDetail = new DutySystem().GetTeaDutyDetails(begDate,endDate,getDept,getDuty,getName,getNumber);

			if ( dsTeaDutyDetail.Tables[0] != null )
			{
				foreach(DataRow detailsRow in dsTeaDutyDetail.Tables[0].Rows)
				{
					switch(detailsRow["teaondutyanaly_ISOntime"].ToString())
					{
//						case "是":  detailsRow["teaondutyanaly_ISOntime"] = "否";
//							break;
//						case "否":  detailsRow["teaondutyanaly_ISOntime"] = "是";
//							break;
//						default:	detailsRow["teaondutyanaly_ISOntime"] = string.Empty;
//							break;

						case "是":  detailsRow["teaondutyanaly_ISOntime"] = string.Empty;
							break;
						case "否":  detailsRow["teaondutyanaly_ISOntime"] = "√";
							break;
						default:	detailsRow["teaondutyanaly_ISOntime"] = string.Empty;
							break;
					}

					switch(detailsRow["teaondutyanaly_ISOfftime"].ToString())
					{
						case "是":	detailsRow["teaondutyanaly_ISOfftime"] = "√";
							break;
						case "否":	detailsRow["teaondutyanaly_ISOfftime"] = string.Empty;
							break;
						default:	detailsRow["teaondutyanaly_ISOfftime"] = string.Empty;
							break;
					}

					switch(detailsRow["teaondutyanaly_ISAbsence"].ToString())
					{
						case "是":	detailsRow["teaondutyanaly_ISAbsence"] = "√";
							break;
						case "否":	detailsRow["teaondutyanaly_ISAbsence"] = string.Empty;
							break;
						default:	detailsRow["teaondutyanaly_ISAbsence"] = string.Empty;
							break;
					}

					switch(detailsRow["teaondutyanaly_ISOut"].ToString())
					{
						case "是":	detailsRow["teaondutyanaly_ISOut"] = "√";
							break;
						case "否":	detailsRow["teaondutyanaly_ISOut"] = string.Empty;
							break;
						default:	detailsRow["teaondutyanaly_ISOut"] = string.Empty;
							break;
					}
				}

				gridControl_TeaDutyDetails.DataSource = dsTeaDutyDetail.Tables[0];
			}
		}

		private void gridDutySummary(DateTime getBegDate,DateTime getEndDate,string getDept,string getDuty,string getName,string getNumber)
		{
			dsTeaDutySummary = new DutySystem().BuildDutySummary(getBegDate,getEndDate,getDept,getDuty,getName,getNumber);

			if ( dsTeaDutySummary.Tables[0] != null )
				gridControl_TeaDutySummary.DataSource = dsTeaDutySummary.Tables[0];
		}

		private void gridDutyOut(DateTime getBegDate,DateTime getEndDate,string getDept,string getDuty,string getName,string getNumber)
		{
			dsTeaOutDetail = new DutySystem().GetTeaOutDetails(getBegDate,getEndDate,getDept,getDuty,getName,getNumber);

			if ( dsTeaOutDetail.Tables[0] != null )
				gridControl_TeaOutDetails.DataSource = dsTeaOutDetail.Tables[0];
		}

		private void simpleButton_TeaDutySave_Click(object sender, System.EventArgs e)
		{
			isSaveNextDuty = true;
			simpleButton_LoadHisDuty.PerformClick();
			simpleButton_SaveDutyAsign.PerformClick();
			simpleButton_LoadCurDuty.Enabled = true;

			if ( new DutySystem().SaveCurDuty() >= 1 )
				MessageBox.Show("保存完毕！");
			else
				MessageBox.Show("保存失败！");

			isSaveNextDuty = false;
		}

		private void groupControl_Graph_Resize(object sender, System.EventArgs e)
		{
			PerformeReportAnalysis();
		}

		private void PerformeReportAnalysis()
		{
			//			ZedGraphDemo demo = new ComboDemo();
			//			groupControl1.Controls.Clear();
			//			groupControl1.Controls.Add(demo.ZedGraphControl);
			//
			//			demo.ZedGraphControl.Width = groupControl1.Width;
			//			demo.ZedGraphControl.Height	= groupControl1.Height;
			//
			//			demo.ZedGraphControl.Anchor	= AnchorStyles.Left | AnchorStyles.Top  
			//				| AnchorStyles.Right | AnchorStyles.Bottom;
			//
			//			demo.ZedGraphControl.AxisChange();

			if(dateEdit1.Text.Trim().Length == 0)
			{
				MessageBox.Show("起始时间必须选择!!","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}
			else if(dateEdit2.Text.Trim().Length == 0)
			{
				MessageBox.Show("结束时间必须选择!!","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}
			else if(dateEdit1.DateTime.Date>dateEdit2.DateTime.Date)
			{
				MessageBox.Show("选择结束时间必须大于开始时间!!","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}
			
			zedGraphControl_TeaDuty = new ZedGraphControl();
			groupControl_Graph.Controls.Clear();
			groupControl_Graph.Controls.Add(zedGraphControl_TeaDuty);
			zedGraphControl_TeaDuty.Dock = DockStyle.Fill;
				
			double[] getStat = new double[6];
			if(textEdit_Graphic_TeaID.Text.Equals("")  && textEdit_Graphic_TeaName.Text.Equals(""))
			{
				if(comboBoxEdit_Graphic_TeaDept.SelectedItem.ToString().Equals("全部"))
				{
					getStat = new DutySystem().CalcTeaDutyInfoForGraphic(dateEdit1.DateTime.Date,dateEdit2.DateTime.Date,"","","","");

				}
				else if(comboBoxEdit_Graphic_TeaDuty.SelectedItem.ToString().Equals("全部"))
				{
					getStat = new DutySystem().CalcTeaDutyInfoForGraphic(dateEdit1.DateTime.Date,dateEdit2.DateTime.Date,
						comboBoxEdit_Graphic_TeaDept.SelectedItem.ToString(),"","","");
				}
				else
				{
					getStat = new DutySystem().CalcTeaDutyInfoForGraphic(dateEdit1.DateTime.Date,dateEdit2.DateTime.Date,comboBoxEdit_Graphic_TeaDept.SelectedItem.ToString(),
						comboBoxEdit_Graphic_TeaDuty.SelectedItem.ToString(),"","");
				}						
			}
			else
			{
				if ( textEdit_Graphic_TeaID.Text.Equals("") )
				{
					getStat = new DutySystem().CalcTeaDutyInfoForGraphic(dateEdit1.DateTime.Date,dateEdit2.DateTime.Date,"","",textEdit_Graphic_TeaName.Text,"");
				}
				else
				{
					getStat = new DutySystem().CalcTeaDutyInfoForGraphic(dateEdit1.DateTime.Date,dateEdit2.DateTime.Date,"","","",textEdit_Graphic_TeaID.Text);
				}
			}


			double lateRate = getStat[0]*100;
			double earlyRate = getStat[1]*100;
			double absenceRate = getStat[2]*100;
			double outRate = getStat[3]*100;

			GraphPane graphPane = zedGraphControl_TeaDuty.GraphPane;

			graphPane.Title = "教师出勤统计图表";
			graphPane.XAxis.Title = "统计项目\n统计日期"+dateEdit1.DateTime.ToString("yyyy-MM-dd")
				+"至"+dateEdit2.DateTime.ToString("yyyy-MM-dd");
			graphPane.YAxis.Title = "百分比\n";

			double[] x = { 200, 400, 600, 800 };
			double[] y = { lateRate, earlyRate, absenceRate, outRate };
			BarItem bar = graphPane.AddBar( "出勤统计", x, y, Color.SteelBlue );
			// Fill the bars with a RosyBrown-White-RosyBrown gradient
			bar.Bar.Fill = new Fill( Color.RosyBrown, Color.White, Color.RosyBrown );

			// Make each cluster 100 user scale units wide.  This is needed because the X Axis
			// type is Linear rather than Text or Ordinal
			graphPane.ClusterScaleWidth = 100;
			// Bars are stacked
			graphPane.BarType = BarType.Stack;

			// Enable the X and Y axis grids
			graphPane.XAxis.IsShowGrid = true;
			graphPane.YAxis.IsShowGrid = true;

			// Manually set the scale maximums according to user preference
			graphPane.XAxis.Max = 1000;
			graphPane.YAxis.Max = 120;

			// Add a text item to decorate the graph
			TextItem textLate = new TextItem("迟到率"+lateRate.ToString("f2")+"%",
				200F, (float)(lateRate+5) );
			// Align the text such that the Bottom-Center is at (175, 80) in user scale coordinates
			textLate.Location.AlignH = AlignH.Center;
			textLate.Location.AlignV = AlignV.Bottom;
			textLate.FontSpec.Fill = new Fill( Color.White, Color.PowderBlue, 45F );
			textLate.FontSpec.StringAlignment = StringAlignment.Near;
			graphPane.GraphItemList.Add( textLate );

			// Add a text item to decorate the graph
			TextItem textEarly = new TextItem("早退率"+earlyRate.ToString("f2")+"%",
				400F, (float)(earlyRate+5) );
			// Align the text such that the Bottom-Center is at (175, 80) in user scale coordinates
			textEarly.Location.AlignH = AlignH.Center;
			textEarly.Location.AlignV = AlignV.Bottom;
			textEarly.FontSpec.Fill = new Fill( Color.White, Color.PowderBlue, 45F );
			textEarly.FontSpec.StringAlignment = StringAlignment.Near;
			graphPane.GraphItemList.Add( textEarly );

			// Add a text item to decorate the graph
			TextItem textAbsence = new TextItem("缺席率"+absenceRate.ToString("f2")+"%",
				600F, (float)(absenceRate+5) );
			// Align the text such that the Bottom-Center is at (175, 80) in user scale coordinates
			textAbsence.Location.AlignH = AlignH.Center;
			textAbsence.Location.AlignV = AlignV.Bottom;
			textAbsence.FontSpec.Fill = new Fill( Color.White, Color.PowderBlue, 45F );
			textAbsence.FontSpec.StringAlignment = StringAlignment.Near;
			graphPane.GraphItemList.Add( textAbsence );

			// Add a text item to decorate the graph
			TextItem textOut = new TextItem("出勤率"+outRate.ToString("f2")+"%",
				800F, (float)(outRate+5) );
			// Align the text such that the Bottom-Center is at (175, 80) in user scale coordinates
			textOut.Location.AlignH = AlignH.Center;
			textOut.Location.AlignV = AlignV.Bottom;
			textOut.FontSpec.Fill = new Fill( Color.White, Color.PowderBlue, 45F );
			textOut.FontSpec.StringAlignment = StringAlignment.Near;
			graphPane.GraphItemList.Add( textOut );

			// Add a BoxItem to show a colored band behind the graph data
			BoxItem box = new BoxItem( new RectangleF( 0, 132, 1000, 10 ),
				Color.Empty, Color.FromArgb( 225, 245, 225) );
			box.Location.CoordinateFrame = CoordType.AxisXYScale;
			// Align the left-top of the box to (0, 110)
			box.Location.AlignH = AlignH.Left;
			box.Location.AlignV = AlignV.Top;
			// place the box behind the axis items, so the grid is drawn on top of it
			box.ZOrder = ZOrder.E_BehindAxis;
			graphPane.GraphItemList.Add( box );

			// Fill the pane background with a gradient
			graphPane.PaneFill = new Fill( Color.WhiteSmoke, Color.Lavender, 0F );
			// Fill the axis background with a gradient
			graphPane.AxisFill = new Fill( Color.FromArgb( 255, 255, 245),
				Color.FromArgb( 255, 255, 190), 90F );

			zedGraphControl_TeaDuty.IsShowContextMenu = false;
			zedGraphControl_TeaDuty.IsEnableZoom = false;
			zedGraphControl_TeaDuty.AxisChange();
		}	

	}
}

