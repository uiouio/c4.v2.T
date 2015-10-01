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
	/// Summary description for FinanManagement.
	/// </summary>
	public class FinanManagement : DevExpress.XtraEditors.XtraUserControl
	{
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
		private DevExpress.XtraEditors.TextEdit textEdit_Number;
		private DevExpress.XtraEditors.TextEdit textEdit_Name;
		private DevExpress.Utils.Frames.NotePanel notePanel_Number;
		private DevExpress.Utils.Frames.NotePanel notePanel_Name;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Class;
		private DevExpress.Utils.Frames.NotePanel notePanel_Class;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Grade;
		private DevExpress.Utils.Frames.NotePanel notePanel_Grade;
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView advBandedGridView1;
		private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn1;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn2;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn3;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn4;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn5;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn6;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn7;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn8;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn9;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn10;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn11;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn12;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn13;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn14;
		private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
		private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
		private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
		private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
		private DevExpress.Utils.Frames.NotePanel notePanel_WelcomePanel;
		private DevExpress.XtraEditors.GroupControl groupControl_FinanInfo;
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
		private DevExpress.XtraEditors.GroupControl groupControl_FinanQuery;
		private DevExpress.XtraEditors.DateEdit dateEdit_BalanceMonth;
		private DevExpress.Utils.Frames.NotePanel notePanel_BalanceMonth;
		private DevExpress.Utils.Frames.NotePanel notePanel_FinanQuery;
		private DevExpress.XtraGrid.GridControl gridControl_FinanInfo;
		private DevExpress.XtraEditors.SimpleButton simpleButton_DataPrint;
		private DevExpress.XtraEditors.SimpleButton simpleButton_MonthBalance;
		private DevExpress.XtraEditors.SimpleButton simpleButton_History;
		private DevExpress.Utils.Frames.NotePanel notePanel_SearchMonth;
		private DevExpress.XtraEditors.DateEdit dateEdit_SearchMonth;
		private DevExpress.XtraEditors.SimpleButton simpleButton_ChargeSave;
		private DevExpress.XtraEditors.MemoEdit memoEdit_Remark;
		private GetStuInfoByCondition getStuInfoByCondition;
		private FinanInfoSystem finanInfoSystem;
		private string getGradeNumberFromCombo;
		private string getClassNumberFromCombo;
		private DataSet dsFinanInfo = null;
		private DevExpress.Utils.Frames.NotePanel notePanel1;
		private DevExpress.XtraEditors.SimpleButton simpleButton_DataModify;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn15;
		private DevExpress.XtraEditors.SimpleButton simpleButton_DeleteData;
		private FinanMgmtInfoPrintSystem finanMgmtInfoPrintSystem;
		private System.Windows.Forms.SaveFileDialog saveFileDialog_Report;
		private System.Windows.Forms.HelpProvider helpProvider_FinanInfo;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FinanManagement()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call
			
			getStuInfoByCondition = new GetStuInfoByCondition();
			finanInfoSystem = new FinanInfoSystem();
			finanMgmtInfoPrintSystem = new FinanMgmtInfoPrintSystem();

			#region 帮助
			helpProvider_FinanInfo.HelpNamespace = System.IO.Path.GetDirectoryName(Application.ExecutablePath)
				+ CPTT.SystemFramework.Util.HELP_FILE_NAME;

			this.helpProvider_FinanInfo.SetHelpKeyword(this,"简单财务功能");
			this.helpProvider_FinanInfo.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.KeywordIndex);
			this.helpProvider_FinanInfo.SetHelpString(this, "");
			this.helpProvider_FinanInfo.SetShowHelp(this, true);
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
			this.notePanel_WelcomePanel = new DevExpress.Utils.Frames.NotePanel();
			this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
			this.groupControl_FinanInfo = new DevExpress.XtraEditors.GroupControl();
			this.notePanel1 = new DevExpress.Utils.Frames.NotePanel();
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
			this.groupControl_FinanQuery = new DevExpress.XtraEditors.GroupControl();
			this.dateEdit_SearchMonth = new DevExpress.XtraEditors.DateEdit();
			this.notePanel_SearchMonth = new DevExpress.Utils.Frames.NotePanel();
			this.dateEdit_BalanceMonth = new DevExpress.XtraEditors.DateEdit();
			this.notePanel_BalanceMonth = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_Number = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_Name = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_Number = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_Name = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_Class = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_Class = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_Grade = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_Grade = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_FinanQuery = new DevExpress.Utils.Frames.NotePanel();
			this.gridControl_FinanInfo = new DevExpress.XtraGrid.GridControl();
			this.advBandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
			this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
			this.bandedGridColumn15 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.bandedGridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.bandedGridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
			this.bandedGridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.bandedGridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
			this.bandedGridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.bandedGridColumn7 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.bandedGridColumn6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.bandedGridColumn9 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.bandedGridColumn8 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.bandedGridColumn10 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
			this.bandedGridColumn12 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.bandedGridColumn11 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
			this.bandedGridColumn13 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.bandedGridColumn14 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.simpleButton_DeleteData = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_DataModify = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_ChargeSave = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_History = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_DataPrint = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_MonthBalance = new DevExpress.XtraEditors.SimpleButton();
			this.saveFileDialog_Report = new System.Windows.Forms.SaveFileDialog();
			this.helpProvider_FinanInfo = new System.Windows.Forms.HelpProvider();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
			this.splitContainerControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_FinanInfo)).BeginInit();
			this.groupControl_FinanInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit_Remark.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_ExtraCharge.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_CommCharge.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MilkCharge.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_NightCharge.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_AdmCharge.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MessCharge.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_AdmRestoreDays.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MessRestoreDays.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_FinanQuery)).BeginInit();
			this.groupControl_FinanQuery.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_SearchMonth.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_BalanceMonth.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_Number.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_Name.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Class.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Grade.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_FinanInfo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			this.SuspendLayout();
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
			this.notePanel_WelcomePanel.Size = new System.Drawing.Size(772, 23);
			this.notePanel_WelcomePanel.TabIndex = 4;
			this.notePanel_WelcomePanel.TabStop = false;
			this.notePanel_WelcomePanel.Text = "财务信息管理";
			// 
			// splitContainerControl1
			// 
			this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl1.Location = new System.Drawing.Point(0, 23);
			this.splitContainerControl1.Name = "splitContainerControl1";
			this.splitContainerControl1.Panel1.Controls.Add(this.groupControl_FinanInfo);
			this.splitContainerControl1.Panel1.Controls.Add(this.groupControl_FinanQuery);
			this.splitContainerControl1.Panel1.Text = "splitContainerControl1_Panel1";
			this.splitContainerControl1.Panel2.Controls.Add(this.gridControl_FinanInfo);
			this.splitContainerControl1.Panel2.Controls.Add(this.panelControl1);
			this.splitContainerControl1.Panel2.Text = "splitContainerControl1_Panel2";
			this.splitContainerControl1.Size = new System.Drawing.Size(772, 517);
			this.splitContainerControl1.SplitterPosition = 193;
			this.splitContainerControl1.TabIndex = 5;
			this.splitContainerControl1.Text = "splitContainerControl1";
			// 
			// groupControl_FinanInfo
			// 
			this.groupControl_FinanInfo.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_FinanInfo.AppearanceCaption.Options.UseFont = true;
			this.groupControl_FinanInfo.Controls.Add(this.notePanel1);
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
			this.groupControl_FinanInfo.Location = new System.Drawing.Point(0, 248);
			this.groupControl_FinanInfo.Name = "groupControl_FinanInfo";
			this.groupControl_FinanInfo.Size = new System.Drawing.Size(187, 263);
			this.groupControl_FinanInfo.TabIndex = 1;
			this.groupControl_FinanInfo.Text = "财务信息";
			// 
			// notePanel1
			// 
			this.notePanel1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel1.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel1.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel1.ForeColor = System.Drawing.Color.Black;
			this.notePanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel1.Location = new System.Drawing.Point(16, 224);
			this.notePanel1.MaxRows = 5;
			this.notePanel1.Name = "notePanel1";
			this.notePanel1.ParentAutoHeight = true;
			this.notePanel1.Size = new System.Drawing.Size(160, 22);
			this.notePanel1.TabIndex = 60;
			this.notePanel1.TabStop = false;
			this.notePanel1.Text = "             备  注:";
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
			// groupControl_FinanQuery
			// 
			this.groupControl_FinanQuery.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_FinanQuery.AppearanceCaption.Options.UseFont = true;
			this.groupControl_FinanQuery.Controls.Add(this.dateEdit_SearchMonth);
			this.groupControl_FinanQuery.Controls.Add(this.notePanel_SearchMonth);
			this.groupControl_FinanQuery.Controls.Add(this.dateEdit_BalanceMonth);
			this.groupControl_FinanQuery.Controls.Add(this.notePanel_BalanceMonth);
			this.groupControl_FinanQuery.Controls.Add(this.textEdit_Number);
			this.groupControl_FinanQuery.Controls.Add(this.textEdit_Name);
			this.groupControl_FinanQuery.Controls.Add(this.notePanel_Number);
			this.groupControl_FinanQuery.Controls.Add(this.notePanel_Name);
			this.groupControl_FinanQuery.Controls.Add(this.comboBoxEdit_Class);
			this.groupControl_FinanQuery.Controls.Add(this.notePanel_Class);
			this.groupControl_FinanQuery.Controls.Add(this.comboBoxEdit_Grade);
			this.groupControl_FinanQuery.Controls.Add(this.notePanel_Grade);
			this.groupControl_FinanQuery.Controls.Add(this.notePanel_FinanQuery);
			this.groupControl_FinanQuery.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_FinanQuery.Location = new System.Drawing.Point(0, 0);
			this.groupControl_FinanQuery.Name = "groupControl_FinanQuery";
			this.groupControl_FinanQuery.Size = new System.Drawing.Size(187, 248);
			this.groupControl_FinanQuery.TabIndex = 0;
			this.groupControl_FinanQuery.Text = "信息查询";
			// 
			// dateEdit_SearchMonth
			// 
			this.dateEdit_SearchMonth.EditValue = new System.DateTime(2005, 12, 20, 0, 0, 0, 0);
			this.dateEdit_SearchMonth.Location = new System.Drawing.Point(88, 216);
			this.dateEdit_SearchMonth.Name = "dateEdit_SearchMonth";
			// 
			// dateEdit_SearchMonth.Properties
			// 
			this.dateEdit_SearchMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																														 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit_SearchMonth.Properties.DisplayFormat.FormatString = "yyyy年M月";
			this.dateEdit_SearchMonth.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dateEdit_SearchMonth.Properties.Mask.EditMask = "d";
			this.dateEdit_SearchMonth.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
			this.dateEdit_SearchMonth.Size = new System.Drawing.Size(88, 23);
			this.dateEdit_SearchMonth.TabIndex = 47;
			// 
			// notePanel_SearchMonth
			// 
			this.notePanel_SearchMonth.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_SearchMonth.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_SearchMonth.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_SearchMonth.ForeColor = System.Drawing.Color.Black;
			this.notePanel_SearchMonth.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_SearchMonth.Location = new System.Drawing.Point(16, 216);
			this.notePanel_SearchMonth.MaxRows = 5;
			this.notePanel_SearchMonth.Name = "notePanel_SearchMonth";
			this.notePanel_SearchMonth.ParentAutoHeight = true;
			this.notePanel_SearchMonth.Size = new System.Drawing.Size(64, 22);
			this.notePanel_SearchMonth.TabIndex = 46;
			this.notePanel_SearchMonth.TabStop = false;
			this.notePanel_SearchMonth.Text = "查询月:";
			// 
			// dateEdit_BalanceMonth
			// 
			this.dateEdit_BalanceMonth.EditValue = new System.DateTime(2005, 12, 20, 0, 0, 0, 0);
			this.dateEdit_BalanceMonth.Location = new System.Drawing.Point(88, 184);
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
			this.notePanel_BalanceMonth.Location = new System.Drawing.Point(16, 184);
			this.notePanel_BalanceMonth.MaxRows = 5;
			this.notePanel_BalanceMonth.Name = "notePanel_BalanceMonth";
			this.notePanel_BalanceMonth.ParentAutoHeight = true;
			this.notePanel_BalanceMonth.Size = new System.Drawing.Size(64, 22);
			this.notePanel_BalanceMonth.TabIndex = 43;
			this.notePanel_BalanceMonth.TabStop = false;
			this.notePanel_BalanceMonth.Text = "结算月:";
			// 
			// textEdit_Number
			// 
			this.textEdit_Number.EditValue = "";
			this.textEdit_Number.Location = new System.Drawing.Point(88, 152);
			this.textEdit_Number.Name = "textEdit_Number";
			this.textEdit_Number.Size = new System.Drawing.Size(80, 23);
			this.textEdit_Number.TabIndex = 42;
			// 
			// textEdit_Name
			// 
			this.textEdit_Name.EditValue = "";
			this.textEdit_Name.Location = new System.Drawing.Point(88, 120);
			this.textEdit_Name.Name = "textEdit_Name";
			this.textEdit_Name.Size = new System.Drawing.Size(80, 23);
			this.textEdit_Name.TabIndex = 41;
			// 
			// notePanel_Number
			// 
			this.notePanel_Number.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_Number.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_Number.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_Number.ForeColor = System.Drawing.Color.Black;
			this.notePanel_Number.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Number.Location = new System.Drawing.Point(16, 152);
			this.notePanel_Number.MaxRows = 5;
			this.notePanel_Number.Name = "notePanel_Number";
			this.notePanel_Number.ParentAutoHeight = true;
			this.notePanel_Number.Size = new System.Drawing.Size(65, 22);
			this.notePanel_Number.TabIndex = 40;
			this.notePanel_Number.TabStop = false;
			this.notePanel_Number.Text = "学  号:";
			// 
			// notePanel_Name
			// 
			this.notePanel_Name.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_Name.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_Name.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_Name.ForeColor = System.Drawing.Color.Black;
			this.notePanel_Name.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Name.Location = new System.Drawing.Point(16, 120);
			this.notePanel_Name.MaxRows = 5;
			this.notePanel_Name.Name = "notePanel_Name";
			this.notePanel_Name.ParentAutoHeight = true;
			this.notePanel_Name.Size = new System.Drawing.Size(65, 22);
			this.notePanel_Name.TabIndex = 39;
			this.notePanel_Name.TabStop = false;
			this.notePanel_Name.Text = "姓  名:";
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
			this.comboBoxEdit_Class.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_Class.Size = new System.Drawing.Size(80, 23);
			this.comboBoxEdit_Class.TabIndex = 38;
			this.comboBoxEdit_Class.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_Class_SelectedIndexChanged);
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
			this.notePanel_FinanQuery.Size = new System.Drawing.Size(181, 23);
			this.notePanel_FinanQuery.TabIndex = 19;
			this.notePanel_FinanQuery.TabStop = false;
			this.notePanel_FinanQuery.Text = "您要查找哪个班级？";
			// 
			// gridControl_FinanInfo
			// 
			this.gridControl_FinanInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl_FinanInfo.EmbeddedNavigator
			// 
			this.gridControl_FinanInfo.EmbeddedNavigator.Name = "";
			this.gridControl_FinanInfo.Location = new System.Drawing.Point(0, 40);
			this.gridControl_FinanInfo.MainView = this.advBandedGridView1;
			this.gridControl_FinanInfo.Name = "gridControl_FinanInfo";
			this.gridControl_FinanInfo.Size = new System.Drawing.Size(569, 471);
			this.gridControl_FinanInfo.TabIndex = 1;
			this.gridControl_FinanInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																												 this.advBandedGridView1,
																												 this.gridView1});
			this.gridControl_FinanInfo.Load += new System.EventHandler(this.gridControl_FinanInfo_Load);
			// 
			// advBandedGridView1
			// 
			this.advBandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
																										   this.gridBand1,
																										   this.gridBand2,
																										   this.gridBand3,
																										   this.gridBand4,
																										   this.gridBand5});
			this.advBandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
																													 this.bandedGridColumn1,
																													 this.bandedGridColumn2,
																													 this.bandedGridColumn3,
																													 this.bandedGridColumn4,
																													 this.bandedGridColumn5,
																													 this.bandedGridColumn6,
																													 this.bandedGridColumn7,
																													 this.bandedGridColumn8,
																													 this.bandedGridColumn9,
																													 this.bandedGridColumn10,
																													 this.bandedGridColumn11,
																													 this.bandedGridColumn12,
																													 this.bandedGridColumn13,
																													 this.bandedGridColumn14,
																													 this.bandedGridColumn15});
			this.advBandedGridView1.GridControl = this.gridControl_FinanInfo;
			this.advBandedGridView1.Name = "advBandedGridView1";
			this.advBandedGridView1.OptionsCustomization.AllowFilter = false;
			this.advBandedGridView1.OptionsView.ShowFilterPanel = false;
			this.advBandedGridView1.OptionsView.ShowGroupPanel = false;
			// 
			// gridBand1
			// 
			this.gridBand1.AppearanceHeader.ForeColor = System.Drawing.Color.Red;
			this.gridBand1.AppearanceHeader.Options.UseForeColor = true;
			this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
			this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridBand1.Caption = "学生信息";
			this.gridBand1.Columns.Add(this.bandedGridColumn15);
			this.gridBand1.Columns.Add(this.bandedGridColumn1);
			this.gridBand1.Columns.Add(this.bandedGridColumn2);
			this.gridBand1.Name = "gridBand1";
			this.gridBand1.Width = 150;
			// 
			// bandedGridColumn15
			// 
			this.bandedGridColumn15.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn15.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn15.AutoFillDown = true;
			this.bandedGridColumn15.Caption = "学号";
			this.bandedGridColumn15.FieldName = "info_stuNumber";
			this.bandedGridColumn15.Name = "bandedGridColumn15";
			this.bandedGridColumn15.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn15.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn15.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn15.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn15.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn15.OptionsColumn.AllowMove = false;
			this.bandedGridColumn15.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn15.OptionsColumn.FixedWidth = true;
			this.bandedGridColumn15.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn15.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn15.Visible = true;
			this.bandedGridColumn15.Width = 50;
			// 
			// bandedGridColumn1
			// 
			this.bandedGridColumn1.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn1.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn1.AutoFillDown = true;
			this.bandedGridColumn1.Caption = "姓名";
			this.bandedGridColumn1.FieldName = "info_stuName";
			this.bandedGridColumn1.Name = "bandedGridColumn1";
			this.bandedGridColumn1.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn1.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn1.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn1.OptionsColumn.AllowMove = false;
			this.bandedGridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn1.OptionsColumn.FixedWidth = true;
			this.bandedGridColumn1.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn1.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn1.Visible = true;
			this.bandedGridColumn1.Width = 50;
			// 
			// bandedGridColumn2
			// 
			this.bandedGridColumn2.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn2.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn2.AutoFillDown = true;
			this.bandedGridColumn2.Caption = "班级";
			this.bandedGridColumn2.FieldName = "info_className";
			this.bandedGridColumn2.MinWidth = 10;
			this.bandedGridColumn2.Name = "bandedGridColumn2";
			this.bandedGridColumn2.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn2.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn2.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn2.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn2.OptionsColumn.AllowMove = false;
			this.bandedGridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn2.OptionsColumn.FixedWidth = true;
			this.bandedGridColumn2.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn2.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn2.Visible = true;
			this.bandedGridColumn2.Width = 50;
			// 
			// gridBand2
			// 
			this.gridBand2.AppearanceHeader.ForeColor = System.Drawing.Color.Red;
			this.gridBand2.AppearanceHeader.Options.UseForeColor = true;
			this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
			this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridBand2.Caption = "本月结算";
			this.gridBand2.Columns.Add(this.bandedGridColumn3);
			this.gridBand2.Columns.Add(this.bandedGridColumn4);
			this.gridBand2.Name = "gridBand2";
			this.gridBand2.Width = 120;
			// 
			// bandedGridColumn3
			// 
			this.bandedGridColumn3.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn3.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn3.AutoFillDown = true;
			this.bandedGridColumn3.Caption = "应交天数";
			this.bandedGridColumn3.FieldName = "info_needHandDays";
			this.bandedGridColumn3.Name = "bandedGridColumn3";
			this.bandedGridColumn3.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn3.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn3.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn3.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn3.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn3.OptionsColumn.AllowMove = false;
			this.bandedGridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn3.OptionsColumn.FixedWidth = true;
			this.bandedGridColumn3.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn3.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn3.Visible = true;
			this.bandedGridColumn3.Width = 60;
			// 
			// bandedGridColumn4
			// 
			this.bandedGridColumn4.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn4.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn4.AutoFillDown = true;
			this.bandedGridColumn4.Caption = "停伙天数";
			this.bandedGridColumn4.FieldName = "info_messStopDays";
			this.bandedGridColumn4.Name = "bandedGridColumn4";
			this.bandedGridColumn4.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn4.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn4.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn4.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn4.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn4.OptionsColumn.AllowMove = false;
			this.bandedGridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn4.OptionsColumn.FixedWidth = true;
			this.bandedGridColumn4.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn4.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn4.Visible = true;
			this.bandedGridColumn4.Width = 60;
			// 
			// gridBand3
			// 
			this.gridBand3.AppearanceHeader.ForeColor = System.Drawing.Color.Red;
			this.gridBand3.AppearanceHeader.Options.UseForeColor = true;
			this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
			this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridBand3.Caption = "各项费用";
			this.gridBand3.Columns.Add(this.bandedGridColumn5);
			this.gridBand3.Columns.Add(this.bandedGridColumn7);
			this.gridBand3.Columns.Add(this.bandedGridColumn6);
			this.gridBand3.Columns.Add(this.bandedGridColumn9);
			this.gridBand3.Columns.Add(this.bandedGridColumn8);
			this.gridBand3.Columns.Add(this.bandedGridColumn10);
			this.gridBand3.Name = "gridBand3";
			this.gridBand3.Width = 195;
			// 
			// bandedGridColumn5
			// 
			this.bandedGridColumn5.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn5.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.bandedGridColumn5.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn5.Caption = "管理费";
			this.bandedGridColumn5.FieldName = "info_admCharge";
			this.bandedGridColumn5.Name = "bandedGridColumn5";
			this.bandedGridColumn5.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn5.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn5.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn5.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn5.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn5.OptionsColumn.AllowMove = false;
			this.bandedGridColumn5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn5.OptionsColumn.FixedWidth = true;
			this.bandedGridColumn5.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn5.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn5.Visible = true;
			this.bandedGridColumn5.Width = 65;
			// 
			// bandedGridColumn7
			// 
			this.bandedGridColumn7.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn7.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn7.Caption = "伙食费";
			this.bandedGridColumn7.FieldName = "info_messCharge";
			this.bandedGridColumn7.Name = "bandedGridColumn7";
			this.bandedGridColumn7.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn7.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn7.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn7.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn7.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn7.OptionsColumn.AllowMove = false;
			this.bandedGridColumn7.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn7.OptionsColumn.FixedWidth = true;
			this.bandedGridColumn7.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn7.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn7.Visible = true;
			this.bandedGridColumn7.Width = 65;
			// 
			// bandedGridColumn6
			// 
			this.bandedGridColumn6.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn6.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn6.Caption = "晚托费";
			this.bandedGridColumn6.FieldName = "info_nightCharge";
			this.bandedGridColumn6.Name = "bandedGridColumn6";
			this.bandedGridColumn6.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn6.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn6.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn6.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn6.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn6.OptionsColumn.AllowMove = false;
			this.bandedGridColumn6.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn6.OptionsColumn.FixedWidth = true;
			this.bandedGridColumn6.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn6.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn6.Visible = true;
			this.bandedGridColumn6.Width = 65;
			// 
			// bandedGridColumn9
			// 
			this.bandedGridColumn9.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn9.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn9.Caption = "代办费";
			this.bandedGridColumn9.FieldName = "info_commCharge";
			this.bandedGridColumn9.Name = "bandedGridColumn9";
			this.bandedGridColumn9.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn9.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn9.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn9.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn9.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn9.OptionsColumn.AllowMove = false;
			this.bandedGridColumn9.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn9.OptionsColumn.FixedWidth = true;
			this.bandedGridColumn9.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn9.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn9.RowIndex = 1;
			this.bandedGridColumn9.Visible = true;
			this.bandedGridColumn9.Width = 65;
			// 
			// bandedGridColumn8
			// 
			this.bandedGridColumn8.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn8.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn8.Caption = "牛奶费";
			this.bandedGridColumn8.FieldName = "info_milkCharge";
			this.bandedGridColumn8.Name = "bandedGridColumn8";
			this.bandedGridColumn8.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn8.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn8.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn8.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn8.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn8.OptionsColumn.AllowMove = false;
			this.bandedGridColumn8.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn8.OptionsColumn.FixedWidth = true;
			this.bandedGridColumn8.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn8.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn8.RowIndex = 1;
			this.bandedGridColumn8.Visible = true;
			this.bandedGridColumn8.Width = 65;
			// 
			// bandedGridColumn10
			// 
			this.bandedGridColumn10.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn10.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn10.Caption = "附加费";
			this.bandedGridColumn10.FieldName = "info_extraCharge";
			this.bandedGridColumn10.Name = "bandedGridColumn10";
			this.bandedGridColumn10.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn10.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn10.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn10.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn10.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn10.OptionsColumn.AllowMove = false;
			this.bandedGridColumn10.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn10.OptionsColumn.FixedWidth = true;
			this.bandedGridColumn10.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn10.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn10.RowIndex = 1;
			this.bandedGridColumn10.Visible = true;
			this.bandedGridColumn10.Width = 65;
			// 
			// gridBand4
			// 
			this.gridBand4.AppearanceHeader.ForeColor = System.Drawing.Color.Red;
			this.gridBand4.AppearanceHeader.Options.UseForeColor = true;
			this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
			this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridBand4.Caption = "退费信息";
			this.gridBand4.Columns.Add(this.bandedGridColumn12);
			this.gridBand4.Columns.Add(this.bandedGridColumn11);
			this.gridBand4.Name = "gridBand4";
			this.gridBand4.Width = 75;
			// 
			// bandedGridColumn12
			// 
			this.bandedGridColumn12.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn12.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn12.Caption = "管理退费";
			this.bandedGridColumn12.FieldName = "info_admRestoreCharge";
			this.bandedGridColumn12.Name = "bandedGridColumn12";
			this.bandedGridColumn12.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn12.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn12.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn12.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn12.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn12.OptionsColumn.AllowMove = false;
			this.bandedGridColumn12.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn12.OptionsColumn.FixedWidth = true;
			this.bandedGridColumn12.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn12.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn12.Visible = true;
			// 
			// bandedGridColumn11
			// 
			this.bandedGridColumn11.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn11.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn11.Caption = "伙食退费";
			this.bandedGridColumn11.FieldName = "info_messRestoreCharge";
			this.bandedGridColumn11.Name = "bandedGridColumn11";
			this.bandedGridColumn11.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn11.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn11.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn11.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn11.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn11.OptionsColumn.AllowMove = false;
			this.bandedGridColumn11.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn11.OptionsColumn.FixedWidth = true;
			this.bandedGridColumn11.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn11.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn11.RowIndex = 1;
			this.bandedGridColumn11.Visible = true;
			// 
			// gridBand5
			// 
			this.gridBand5.AppearanceHeader.ForeColor = System.Drawing.Color.Red;
			this.gridBand5.AppearanceHeader.Options.UseForeColor = true;
			this.gridBand5.AppearanceHeader.Options.UseTextOptions = true;
			this.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridBand5.Caption = "备注信息";
			this.gridBand5.Columns.Add(this.bandedGridColumn13);
			this.gridBand5.Columns.Add(this.bandedGridColumn14);
			this.gridBand5.Name = "gridBand5";
			this.gridBand5.Width = 80;
			// 
			// bandedGridColumn13
			// 
			this.bandedGridColumn13.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn13.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn13.Caption = "实收金额";
			this.bandedGridColumn13.FieldName = "info_currency";
			this.bandedGridColumn13.Name = "bandedGridColumn13";
			this.bandedGridColumn13.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn13.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn13.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn13.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn13.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn13.OptionsColumn.AllowMove = false;
			this.bandedGridColumn13.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn13.OptionsColumn.FixedWidth = true;
			this.bandedGridColumn13.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn13.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn13.Visible = true;
			this.bandedGridColumn13.Width = 80;
			// 
			// bandedGridColumn14
			// 
			this.bandedGridColumn14.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn14.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn14.Caption = "备注";
			this.bandedGridColumn14.FieldName = "info_remark";
			this.bandedGridColumn14.Name = "bandedGridColumn14";
			this.bandedGridColumn14.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn14.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn14.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn14.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn14.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn14.OptionsColumn.AllowMove = false;
			this.bandedGridColumn14.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn14.OptionsColumn.FixedWidth = true;
			this.bandedGridColumn14.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn14.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn14.RowIndex = 1;
			this.bandedGridColumn14.Visible = true;
			this.bandedGridColumn14.Width = 80;
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn2,
																							 this.gridColumn1,
																							 this.gridColumn4,
																							 this.gridColumn5,
																							 this.gridColumn6,
																							 this.gridColumn7,
																							 this.gridColumn8,
																							 this.gridColumn9,
																							 this.gridColumn10,
																							 this.gridColumn13,
																							 this.gridColumn11,
																							 this.gridColumn12,
																							 this.gridColumn14,
																							 this.gridColumn15});
			this.gridView1.GridControl = this.gridControl_FinanInfo;
			this.gridView1.Name = "gridView1";
			// 
			// gridColumn2
			// 
			this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn2.Caption = "姓名";
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
			this.gridColumn2.VisibleIndex = 0;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "班级";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 13;
			this.gridColumn1.Width = 20;
			// 
			// gridColumn4
			// 
			this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn4.Caption = "应交天数";
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
			this.gridColumn4.VisibleIndex = 1;
			this.gridColumn4.Width = 106;
			// 
			// gridColumn5
			// 
			this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn5.Caption = "停伙天数";
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
			this.gridColumn5.VisibleIndex = 2;
			this.gridColumn5.Width = 83;
			// 
			// gridColumn6
			// 
			this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn6.Caption = "管理费";
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
			this.gridColumn6.VisibleIndex = 3;
			// 
			// gridColumn7
			// 
			this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn7.Caption = "晚托费";
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
			this.gridColumn7.VisibleIndex = 4;
			// 
			// gridColumn8
			// 
			this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn8.Caption = "伙食费";
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
			this.gridColumn8.VisibleIndex = 5;
			// 
			// gridColumn9
			// 
			this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn9.Caption = "牛奶费";
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
			this.gridColumn9.VisibleIndex = 6;
			this.gridColumn9.Width = 65;
			// 
			// gridColumn10
			// 
			this.gridColumn10.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn10.Caption = "代办费";
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
			this.gridColumn10.VisibleIndex = 7;
			// 
			// gridColumn13
			// 
			this.gridColumn13.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn13.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn13.Caption = "附加费";
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
			this.gridColumn13.VisibleIndex = 10;
			// 
			// gridColumn11
			// 
			this.gridColumn11.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn11.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn11.Caption = "伙食退费";
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
			this.gridColumn11.VisibleIndex = 8;
			// 
			// gridColumn12
			// 
			this.gridColumn12.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn12.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn12.Caption = "管理退费";
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
			this.gridColumn12.VisibleIndex = 9;
			// 
			// gridColumn14
			// 
			this.gridColumn14.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn14.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn14.Caption = "实收金额";
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
			this.gridColumn14.VisibleIndex = 11;
			// 
			// gridColumn15
			// 
			this.gridColumn15.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn15.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn15.Caption = "备注";
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
			this.gridColumn15.VisibleIndex = 12;
			// 
			// panelControl1
			// 
			this.panelControl1.Controls.Add(this.simpleButton_DeleteData);
			this.panelControl1.Controls.Add(this.simpleButton_DataModify);
			this.panelControl1.Controls.Add(this.simpleButton_ChargeSave);
			this.panelControl1.Controls.Add(this.simpleButton_History);
			this.panelControl1.Controls.Add(this.simpleButton_DataPrint);
			this.panelControl1.Controls.Add(this.simpleButton_MonthBalance);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl1.Location = new System.Drawing.Point(0, 0);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(569, 40);
			this.panelControl1.TabIndex = 0;
			this.panelControl1.Text = "panelControl1";
			// 
			// simpleButton_DeleteData
			// 
			this.simpleButton_DeleteData.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_DeleteData.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_DeleteData.Appearance.Options.UseFont = true;
			this.simpleButton_DeleteData.Appearance.Options.UseForeColor = true;
			this.simpleButton_DeleteData.Location = new System.Drawing.Point(336, 8);
			this.simpleButton_DeleteData.Name = "simpleButton_DeleteData";
			this.simpleButton_DeleteData.Size = new System.Drawing.Size(72, 26);
			this.simpleButton_DeleteData.TabIndex = 14;
			this.simpleButton_DeleteData.Tag = 4;
			this.simpleButton_DeleteData.Text = "存根删除";
			this.simpleButton_DeleteData.Click += new System.EventHandler(this.simpleButton_DeleteData_Click);
			// 
			// simpleButton_DataModify
			// 
			this.simpleButton_DataModify.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_DataModify.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_DataModify.Appearance.Options.UseFont = true;
			this.simpleButton_DataModify.Appearance.Options.UseForeColor = true;
			this.simpleButton_DataModify.Location = new System.Drawing.Point(96, 8);
			this.simpleButton_DataModify.Name = "simpleButton_DataModify";
			this.simpleButton_DataModify.Size = new System.Drawing.Size(72, 26);
			this.simpleButton_DataModify.TabIndex = 13;
			this.simpleButton_DataModify.Tag = 4;
			this.simpleButton_DataModify.Text = "数据修改";
			this.simpleButton_DataModify.Click += new System.EventHandler(this.simpleButton_DataModify_Click);
			// 
			// simpleButton_ChargeSave
			// 
			this.simpleButton_ChargeSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_ChargeSave.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_ChargeSave.Appearance.Options.UseFont = true;
			this.simpleButton_ChargeSave.Appearance.Options.UseForeColor = true;
			this.simpleButton_ChargeSave.Location = new System.Drawing.Point(256, 8);
			this.simpleButton_ChargeSave.Name = "simpleButton_ChargeSave";
			this.simpleButton_ChargeSave.Size = new System.Drawing.Size(72, 26);
			this.simpleButton_ChargeSave.TabIndex = 12;
			this.simpleButton_ChargeSave.Tag = 4;
			this.simpleButton_ChargeSave.Text = "费用存根";
			this.simpleButton_ChargeSave.Click += new System.EventHandler(this.simpleButton_ChargeSave_Click);
			// 
			// simpleButton_History
			// 
			this.simpleButton_History.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_History.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_History.Appearance.Options.UseFont = true;
			this.simpleButton_History.Appearance.Options.UseForeColor = true;
			this.simpleButton_History.Location = new System.Drawing.Point(176, 8);
			this.simpleButton_History.Name = "simpleButton_History";
			this.simpleButton_History.Size = new System.Drawing.Size(72, 26);
			this.simpleButton_History.TabIndex = 11;
			this.simpleButton_History.Tag = 4;
			this.simpleButton_History.Text = "历史查询";
			this.simpleButton_History.Click += new System.EventHandler(this.simpleButton_History_Click);
			// 
			// simpleButton_DataPrint
			// 
			this.simpleButton_DataPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_DataPrint.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_DataPrint.Appearance.Options.UseFont = true;
			this.simpleButton_DataPrint.Appearance.Options.UseForeColor = true;
			this.simpleButton_DataPrint.Location = new System.Drawing.Point(416, 8);
			this.simpleButton_DataPrint.Name = "simpleButton_DataPrint";
			this.simpleButton_DataPrint.Size = new System.Drawing.Size(72, 26);
			this.simpleButton_DataPrint.TabIndex = 9;
			this.simpleButton_DataPrint.Tag = 4;
			this.simpleButton_DataPrint.Text = "数据打印";
			this.simpleButton_DataPrint.Click += new System.EventHandler(this.simpleButton_DataPrint_Click);
			// 
			// simpleButton_MonthBalance
			// 
			this.simpleButton_MonthBalance.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_MonthBalance.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_MonthBalance.Appearance.Options.UseFont = true;
			this.simpleButton_MonthBalance.Appearance.Options.UseForeColor = true;
			this.simpleButton_MonthBalance.Location = new System.Drawing.Point(16, 8);
			this.simpleButton_MonthBalance.Name = "simpleButton_MonthBalance";
			this.simpleButton_MonthBalance.Size = new System.Drawing.Size(72, 26);
			this.simpleButton_MonthBalance.TabIndex = 8;
			this.simpleButton_MonthBalance.Tag = 4;
			this.simpleButton_MonthBalance.Text = "本月结算";
			this.simpleButton_MonthBalance.Click += new System.EventHandler(this.simpleButton_MonthBalance_Click);
			// 
			// FinanManagement
			// 
			this.Controls.Add(this.splitContainerControl1);
			this.Controls.Add(this.notePanel_WelcomePanel);
			this.Name = "FinanManagement";
			this.Size = new System.Drawing.Size(772, 540);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
			this.splitContainerControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl_FinanInfo)).EndInit();
			this.groupControl_FinanInfo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.memoEdit_Remark.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_ExtraCharge.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_CommCharge.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MilkCharge.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_NightCharge.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_AdmCharge.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MessCharge.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_AdmRestoreDays.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MessRestoreDays.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_FinanQuery)).EndInit();
			this.groupControl_FinanQuery.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_SearchMonth.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_BalanceMonth.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_Number.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_Name.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Class.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Grade.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_FinanInfo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void gridControl_FinanInfo_Load(object sender, System.EventArgs e)
		{
			foreach(DataRow getGradeList in getStuInfoByCondition.getGradeInfo("","").Tables[0].Rows)
			{
				comboBoxEdit_Grade.Properties.Items.AddRange(
					new object[]{getGradeList[1].ToString()});
			}

			dateEdit_BalanceMonth.EditValue = DateTime.Now.Date;
			dateEdit_SearchMonth.EditValue = DateTime.Now.Date;

			if ( Thread.CurrentPrincipal.Identity.Name.ToLower() == "admin" )
			{
				simpleButton_ChargeSave.Enabled = false;
				simpleButton_DataModify.Enabled = false;
				simpleButton_DataPrint.Enabled = false;
				simpleButton_DeleteData.Enabled = false;
				simpleButton_History.Enabled = false;
				simpleButton_MonthBalance.Enabled = false;
			}

			if ( Thread.CurrentPrincipal.IsInRole("园长") )
				notePanel_WelcomePanel.Text = new HealthManagementSystem().GetTeaName(Thread.CurrentPrincipal.Identity.Name)
					+ "园长欢迎您进入教师财务信息管理";
			if ( Thread.CurrentPrincipal.IsInRole("财务") )
				notePanel_WelcomePanel.Text = new HealthManagementSystem().GetTeaName(Thread.CurrentPrincipal.Identity.Name)
					+ "教师欢迎您进入教师财务信息管理";

		}

		private void comboBoxEdit_Grade_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			comboBoxEdit_Class.Properties.Items.Clear();
			comboBoxEdit_Class.Properties.Items.AddRange(new object[]{"全部"});
			comboBoxEdit_Class.SelectedItem = "全部";
			if ( getStuInfoByCondition.getGradeInfo(comboBoxEdit_Grade.SelectedItem.ToString(),"").Tables[0].Rows.Count>0 )
			{
				getGradeNumberFromCombo = getStuInfoByCondition.getGradeInfo(
					comboBoxEdit_Grade.SelectedItem.ToString(),"").Tables[0].Rows[0][0].ToString();
				foreach(DataRow getClassList in getStuInfoByCondition.getClassInfo("","",
					getGradeNumberFromCombo).Tables[0].Rows)
				{
					comboBoxEdit_Class.Properties.Items.AddRange(
						new object[]{getClassList[1].ToString()});
				}
			}
		}

		private void comboBoxEdit_Class_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(!comboBoxEdit_Class.SelectedItem.ToString().Equals("全部"))
				getClassNumberFromCombo = getStuInfoByCondition.getClassInfo(
					comboBoxEdit_Class.SelectedItem.ToString(),"","").Tables[0].Rows[0][0].ToString();
		}

		#region 本月结算
		private void simpleButton_MonthBalance_Click(object sender, System.EventArgs e)
		{

			if(textEdit_Name.Text.Equals("")  && textEdit_Number.Text.Equals(""))
			{
				if ( comboBoxEdit_Grade.SelectedItem.ToString().Equals("全部") )
				{
					DataInit("","","","",(DateTime)dateEdit_BalanceMonth.EditValue,false);
					ComponentInit();
				}
				else if ( comboBoxEdit_Class.SelectedItem.ToString().Equals("全部") )
				{
					DataInit(getGradeNumberFromCombo,"","","",(DateTime)dateEdit_BalanceMonth.EditValue,false);
					ComponentInit();
				}
				else
				{
					DataInit(getGradeNumberFromCombo,getClassNumberFromCombo,"","",(DateTime)dateEdit_BalanceMonth.EditValue,false);
					ComponentInit();
				}
			}
			else
			{
				if ( textEdit_Number.Text.Equals("") )
				{
					DataInit("","",textEdit_Name.Text.Replace(" ",""),"",(DateTime)dateEdit_BalanceMonth.EditValue,false);
					ComponentInit();
				}
				else
				{
					DataInit("","","",textEdit_Number.Text.Replace(" ",""),(DateTime)dateEdit_BalanceMonth.EditValue,false);
					ComponentInit();
				}
			}
		}
		#endregion

		#region 修改
		private void simpleButton_DataModify_Click(object sender, System.EventArgs e)
		{
			string message = "是否确认修改这些数据？";
			string caption = "消息提示框!";
			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult == DialogResult.Yes )
			{
				DataInit("","","","",(DateTime)dateEdit_BalanceMonth.EditValue,true);
				ComponentInit();
			}

		}
		#endregion

		#region 保存
		private void simpleButton_ChargeSave_Click(object sender, System.EventArgs e)
		{
			string message = "是否确认保存这些数据？";
			string caption = "消息提示框!";
			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult == DialogResult.Yes )
			{
				finanInfoSystem.InsertFinanInfo(dsFinanInfo,(DateTime)dateEdit_BalanceMonth.EditValue,
					Convert.ToInt32(textEdit_MessRestoreDays.Text.Replace(" ","")),Convert.ToInt32(textEdit_AdmRestoreDays.Text.Replace(" ","")));
				MessageBox.Show("保存完毕！");
			}
			
		}
		#endregion

		#region 历史记录
		private void simpleButton_History_Click(object sender, System.EventArgs e)
		{
			if(textEdit_Name.Text.Equals("")  && textEdit_Number.Text.Equals(""))
			{
				if ( comboBoxEdit_Grade.SelectedItem.ToString().Equals("全部") )
				{
					TextUnBindings();
					dsFinanInfo = finanInfoSystem.GetFinanInfoHistoryInfo("","","","",(DateTime)dateEdit_SearchMonth.EditValue);
					ComponentInit();
					TextBindings();
				}
				else if ( comboBoxEdit_Class.SelectedItem.ToString().Equals("全部") )
				{
					TextUnBindings();
					dsFinanInfo = finanInfoSystem.GetFinanInfoHistoryInfo(getGradeNumberFromCombo,"","","",
						(DateTime)dateEdit_SearchMonth.EditValue);
					ComponentInit();
					TextBindings();
				}
				else
				{
					TextUnBindings();
					dsFinanInfo = finanInfoSystem.GetFinanInfoHistoryInfo(getGradeNumberFromCombo,getClassNumberFromCombo,"","",
						(DateTime)dateEdit_SearchMonth.EditValue);
					ComponentInit();
					TextBindings();
				}
			}
			else
			{
				if ( textEdit_Number.Text.Equals("") )
				{
					TextUnBindings();
					dsFinanInfo = finanInfoSystem.GetFinanInfoHistoryInfo("","",textEdit_Name.Text.Replace(" ",""),"",
						(DateTime)dateEdit_SearchMonth.EditValue);
					ComponentInit();
					TextBindings();
				}
				else
				{
					TextUnBindings();
					dsFinanInfo = finanInfoSystem.GetFinanInfoHistoryInfo("","","",textEdit_Number.Text.Replace(" ",""),
						(DateTime)dateEdit_SearchMonth.EditValue);
					ComponentInit();
					TextBindings();
				}
			}
		}
		#endregion

		#region 删除
		private void simpleButton_DeleteData_Click(object sender, System.EventArgs e)
		{
			string message = "是否确认删除这些数据？";
			string caption = "消息提示框!";
			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult == DialogResult.Yes )
			{
				finanInfoSystem.DeleteFinanInfo((DateTime)dateEdit_SearchMonth.EditValue);
				MessageBox.Show("删除信息成功！");
			}
		}
		#endregion

		#region 打印
		private void simpleButton_DataPrint_Click(object sender, System.EventArgs e)
		{
			if ( dsFinanInfo != null)
			{
				if ( dsFinanInfo.Tables[0].Rows.Count > 0 )
				{
					string savePath;
					saveFileDialog_Report.Filter = "Excel文件|*.xls";

					if ( saveFileDialog_Report.ShowDialog() != DialogResult.OK )
						return;

					savePath = saveFileDialog_Report.FileName;

					MessageBox.Show("即将生成报表，由于数据比较复杂，可能花费您较长时间等待，按确定之后请稍候！");

					finanMgmtInfoPrintSystem.FinanMgmtInfoPrint(dsFinanInfo,savePath);

					MessageBox.Show("报表生成完毕！");
				}
				else
					MessageBox.Show("报表生成之前，请先做数据统计！");
			}
			else
				MessageBox.Show("报表生成之前，请先做数据统计！");
		}
		#endregion

		#region 帮助
		private void simpleButton_Help_Click(object sender, System.EventArgs e)
		{
			
		}
		#endregion

		private void DataInit(string getGrade,string getClass,string getName,string getNumber,DateTime getDate,bool isModify)
		{
			try
			{
				finanInfoSystem.SetMessRestoreDays(Convert.ToInt32(textEdit_MessRestoreDays.Text));
				finanInfoSystem.SetAdmRestoreDays(Convert.ToInt32(textEdit_AdmRestoreDays.Text));
				finanInfoSystem.SetMessCharge(Convert.ToDouble(textEdit_MessCharge.Text.Replace("￥","")));
				finanInfoSystem.SetAdmCharge(Convert.ToDouble(textEdit_AdmCharge.Text.Replace("￥","")));
				finanInfoSystem.SetNightCharge(Convert.ToDouble(textEdit_NightCharge.Text.Replace("￥","")));
				finanInfoSystem.SetMilkCharge(Convert.ToDouble(textEdit_MilkCharge.Text.Replace("￥","")));
				finanInfoSystem.SetCommCharge(Convert.ToDouble(textEdit_CommCharge.Text.Replace("￥","")));
				finanInfoSystem.SetExtraCharge(Convert.ToDouble(textEdit_ExtraCharge.Text.Replace("￥","")));
				finanInfoSystem.SetRemark(memoEdit_Remark.Text);
				if ( !isModify )
				{
					dsFinanInfo = finanInfoSystem.GetContiAbsForMessDetail(getGrade,
						getClass,getName,getNumber,(DateTime)dateEdit_BalanceMonth.EditValue);
				}
				else
				{
					dsFinanInfo = finanInfoSystem.GetFinanInfo(dsFinanInfo,
						advBandedGridView1.GetDataRow(advBandedGridView1.GetSelectedRows()[0])[0].ToString(),
						(DateTime)dateEdit_BalanceMonth.EditValue);
				}
			}
			catch
			{
				MessageBox.Show("请在退费指定天数以及费用内输入正确的数字！");
			}
		}

		private void ComponentInit()    
		{
			try
			{
				gridControl_FinanInfo.DataSource = dsFinanInfo.Tables[0];
				memoEdit_Remark.DataBindings.Clear();
				memoEdit_Remark.DataBindings.Add("EditValue",dsFinanInfo.Tables[0],"info_remark");
			}
			catch
			{
				MessageBox.Show("如果该费用选项不存在，请填零！"+
					"\n如果该退费天数选项不存在，请填入当月最大天数！");
			}
		}

		private void TextBindings()
		{
			textEdit_MessRestoreDays.DataBindings.Add("EditValue",dsFinanInfo.Tables[0],"info_messRestoreDays");
			textEdit_AdmRestoreDays.DataBindings.Add("EditValue",dsFinanInfo.Tables[0],"info_admRestoreDays");
			textEdit_MessCharge.DataBindings.Add("EditValue",dsFinanInfo.Tables[0],"info_messCharge");
			textEdit_AdmCharge.DataBindings.Add("EditValue",dsFinanInfo.Tables[0],"info_admCharge");
			textEdit_NightCharge.DataBindings.Add("EditValue",dsFinanInfo.Tables[0],"info_nightCharge");
			textEdit_CommCharge.DataBindings.Add("EditValue",dsFinanInfo.Tables[0],"info_commCharge");
			textEdit_ExtraCharge.DataBindings.Add("EditValue",dsFinanInfo.Tables[0],"info_extraCharge");
			textEdit_MilkCharge.DataBindings.Add("EditValue",dsFinanInfo.Tables[0],"info_milkCharge");
		}

		private void TextUnBindings()
		{
			textEdit_MessRestoreDays.DataBindings.Clear();
			textEdit_AdmRestoreDays.DataBindings.Clear();
			textEdit_MessCharge.DataBindings.Clear();
			textEdit_AdmCharge.DataBindings.Clear();
			textEdit_NightCharge.DataBindings.Clear();
			textEdit_CommCharge.DataBindings.Clear();
			textEdit_ExtraCharge.DataBindings.Clear();
			textEdit_MilkCharge.DataBindings.Clear();
			memoEdit_Remark.DataBindings.Clear();
		}
	}
}

