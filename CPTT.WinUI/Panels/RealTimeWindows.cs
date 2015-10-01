using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using CPTT.BusinessFacade;

namespace CPTT.WinUI.Panels
{
	/// <summary>
	/// Summary description for RealTimeWindows.
	/// </summary>
	public class RealTimeWindows : DevExpress.XtraEditors.XtraUserControl
	{
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.XtraEditors.GroupControl groupControl2;
		private CPTT.WinUI.Panels.PaneCaption paneCaption_Stu;
		private CPTT.WinUI.Panels.PaneCaption paneCaption_Tea;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private System.Timers.Timer timer_SelectInfo;

		private DataSet stuRealInfo;
		private DataSet teaRealInfo;
		private DevExpress.XtraGrid.GridControl gridControl_Tea;
		private DevExpress.XtraGrid.GridControl gridControl_Stu;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraEditors.GroupControl groupControl3;
		private DevExpress.XtraGrid.GridControl gridControl_Tran;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;

		private DataSet stuReal = new DataSet();
		private DataTable dt = new DataTable();

		private MainForm mainForm;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RealTimeWindows(MainForm mainForm)
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call

			this.mainForm = mainForm;

			if(!Thread.CurrentPrincipal.IsInRole("园长")
				&&Thread.CurrentPrincipal.Identity.Name.ToLower()!="admin")
			{
				groupControl2.Visible=false;
			}

			DataColumn number = new DataColumn("number",Type.GetType("System.Int32"));
			dt.Columns.Add(number);
			DataColumn name = new DataColumn("name",Type.GetType("System.String"));
			dt.Columns.Add(name);
			DataColumn time = new DataColumn("time",Type.GetType("System.DateTime"));
			dt.Columns.Add(time);
			DataColumn state = new DataColumn("state",Type.GetType("System.String"));
			dt.Columns.Add(state);

			stuReal.Tables.Add(dt);
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
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.gridControl_Stu = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.paneCaption_Stu = new CPTT.WinUI.Panels.PaneCaption();
			this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
			this.gridControl_Tea = new DevExpress.XtraGrid.GridControl();
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.paneCaption_Tea = new CPTT.WinUI.Panels.PaneCaption();
			this.timer_SelectInfo = new System.Timers.Timer();
			this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
			this.gridControl_Tran = new DevExpress.XtraGrid.GridControl();
			this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_Stu)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
			this.groupControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_Tea)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.timer_SelectInfo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
			this.groupControl3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_Tran)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
			this.SuspendLayout();
			// 
			// groupControl1
			// 
			this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.DarkOrange;
			this.groupControl1.AppearanceCaption.Options.UseFont = true;
			this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
			this.groupControl1.Controls.Add(this.gridControl_Stu);
			this.groupControl1.Controls.Add(this.paneCaption_Stu);
			this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl1.Location = new System.Drawing.Point(0, 0);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(200, 232);
			this.groupControl1.TabIndex = 0;
			this.groupControl1.Text = "学生刷卡信息提示";
			// 
			// gridControl_Stu
			// 
			this.gridControl_Stu.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl_Stu.EmbeddedNavigator
			// 
			this.gridControl_Stu.EmbeddedNavigator.Name = "";
			this.gridControl_Stu.Location = new System.Drawing.Point(3, 44);
			this.gridControl_Stu.MainView = this.gridView1;
			this.gridControl_Stu.Name = "gridControl_Stu";
			this.gridControl_Stu.Size = new System.Drawing.Size(194, 185);
			this.gridControl_Stu.TabIndex = 1;
			this.gridControl_Stu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										   this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn1,
																							 this.gridColumn2,
																							 this.gridColumn3,
																							 this.gridColumn4});
			this.gridView1.GridControl = this.gridControl_Stu;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsBehavior.Editable = false;
			this.gridView1.OptionsCustomization.AllowFilter = false;
			this.gridView1.OptionsCustomization.AllowGroup = false;
			this.gridView1.OptionsCustomization.AllowSort = false;
			this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
			this.gridView1.OptionsSelection.UseIndicatorForSelection = false;
			this.gridView1.OptionsView.ShowColumnHeaders = false;
			this.gridView1.OptionsView.ShowFilterPanel = false;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			this.gridView1.OptionsView.ShowIndicator = false;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "gridColumn1";
			this.gridColumn1.FieldName = "number";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "gridColumn2";
			this.gridColumn2.FieldName = "name";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "gridColumn3";
			this.gridColumn3.DisplayFormat.FormatString = "HH:mm";
			this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.gridColumn3.FieldName = "time";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 2;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "gridColumn4";
			this.gridColumn4.FieldName = "state";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 3;
			// 
			// paneCaption_Stu
			// 
			this.paneCaption_Stu.AllowActive = false;
			this.paneCaption_Stu.AntiAlias = false;
			this.paneCaption_Stu.Caption = "当前已到校学生总数为:";
			this.paneCaption_Stu.Dock = System.Windows.Forms.DockStyle.Top;
			this.paneCaption_Stu.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.paneCaption_Stu.InactiveGradientHighColor = System.Drawing.Color.Silver;
			this.paneCaption_Stu.InactiveGradientLowColor = System.Drawing.Color.Gray;
			this.paneCaption_Stu.Location = new System.Drawing.Point(3, 18);
			this.paneCaption_Stu.Name = "paneCaption_Stu";
			this.paneCaption_Stu.Size = new System.Drawing.Size(194, 26);
			this.paneCaption_Stu.TabIndex = 0;
			this.paneCaption_Stu.Click += new System.EventHandler(this.paneCaption_Stu_Click);
			// 
			// groupControl2
			// 
			this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.groupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.DarkOrange;
			this.groupControl2.AppearanceCaption.Options.UseFont = true;
			this.groupControl2.AppearanceCaption.Options.UseForeColor = true;
			this.groupControl2.Controls.Add(this.gridControl_Tea);
			this.groupControl2.Controls.Add(this.paneCaption_Tea);
			this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl2.Location = new System.Drawing.Point(0, 232);
			this.groupControl2.Name = "groupControl2";
			this.groupControl2.Size = new System.Drawing.Size(200, 208);
			this.groupControl2.TabIndex = 1;
			this.groupControl2.Text = "教师刷卡信息提示";
			// 
			// gridControl_Tea
			// 
			this.gridControl_Tea.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl_Tea.EmbeddedNavigator
			// 
			this.gridControl_Tea.EmbeddedNavigator.Name = "";
			this.gridControl_Tea.Location = new System.Drawing.Point(3, 44);
			this.gridControl_Tea.MainView = this.gridView2;
			this.gridControl_Tea.Name = "gridControl_Tea";
			this.gridControl_Tea.Size = new System.Drawing.Size(194, 161);
			this.gridControl_Tea.TabIndex = 1;
			this.gridControl_Tea.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										   this.gridView2});
			// 
			// gridView2
			// 
			this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn5,
																							 this.gridColumn6,
																							 this.gridColumn7,
																							 this.gridColumn8});
			this.gridView2.GridControl = this.gridControl_Tea;
			this.gridView2.Name = "gridView2";
			this.gridView2.OptionsBehavior.Editable = false;
			this.gridView2.OptionsCustomization.AllowColumnMoving = false;
			this.gridView2.OptionsCustomization.AllowFilter = false;
			this.gridView2.OptionsCustomization.AllowGroup = false;
			this.gridView2.OptionsCustomization.AllowSort = false;
			this.gridView2.OptionsMenu.EnableColumnMenu = false;
			this.gridView2.OptionsView.ShowColumnHeaders = false;
			this.gridView2.OptionsView.ShowFilterPanel = false;
			this.gridView2.OptionsView.ShowGroupPanel = false;
			this.gridView2.OptionsView.ShowIndicator = false;
			// 
			// gridColumn5
			// 
			this.gridColumn5.Caption = "gridColumn5";
			this.gridColumn5.FieldName = "T_Number";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.Visible = true;
			this.gridColumn5.VisibleIndex = 0;
			// 
			// gridColumn6
			// 
			this.gridColumn6.Caption = "gridColumn6";
			this.gridColumn6.FieldName = "T_Name";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 1;
			// 
			// gridColumn7
			// 
			this.gridColumn7.Caption = "gridColumn7";
			this.gridColumn7.DisplayFormat.FormatString = "HH:mm";
			this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.gridColumn7.FieldName = "teaflow_date";
			this.gridColumn7.Name = "gridColumn7";
			this.gridColumn7.Visible = true;
			this.gridColumn7.VisibleIndex = 2;
			// 
			// gridColumn8
			// 
			this.gridColumn8.Caption = "gridColumn8";
			this.gridColumn8.DisplayFormat.FormatString = "teafs_name";
			this.gridColumn8.FieldName = "teafs_name";
			this.gridColumn8.Name = "gridColumn8";
			this.gridColumn8.Visible = true;
			this.gridColumn8.VisibleIndex = 3;
			// 
			// paneCaption_Tea
			// 
			this.paneCaption_Tea.AllowActive = false;
			this.paneCaption_Tea.AntiAlias = false;
			this.paneCaption_Tea.Caption = "当前已到校教师总数为:10人";
			this.paneCaption_Tea.Dock = System.Windows.Forms.DockStyle.Top;
			this.paneCaption_Tea.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.paneCaption_Tea.InactiveGradientHighColor = System.Drawing.Color.Silver;
			this.paneCaption_Tea.InactiveGradientLowColor = System.Drawing.Color.Gray;
			this.paneCaption_Tea.Location = new System.Drawing.Point(3, 18);
			this.paneCaption_Tea.Name = "paneCaption_Tea";
			this.paneCaption_Tea.Size = new System.Drawing.Size(194, 26);
			this.paneCaption_Tea.TabIndex = 0;
			// 
			// timer_SelectInfo
			// 
			this.timer_SelectInfo.Enabled = true;
			this.timer_SelectInfo.Interval = 5000;
			this.timer_SelectInfo.SynchronizingObject = this;
			this.timer_SelectInfo.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_SelectInfo_Elapsed);
			// 
			// groupControl3
			// 
			this.groupControl3.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.groupControl3.AppearanceCaption.ForeColor = System.Drawing.Color.DarkOrange;
			this.groupControl3.AppearanceCaption.Options.UseFont = true;
			this.groupControl3.AppearanceCaption.Options.UseForeColor = true;
			this.groupControl3.Controls.Add(this.gridControl_Tran);
			this.groupControl3.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl3.Location = new System.Drawing.Point(0, 440);
			this.groupControl3.Name = "groupControl3";
			this.groupControl3.Size = new System.Drawing.Size(200, 172);
			this.groupControl3.TabIndex = 2;
			this.groupControl3.Text = "晨检异常提醒";
			// 
			// gridControl_Tran
			// 
			this.gridControl_Tran.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl_Tran.EmbeddedNavigator
			// 
			this.gridControl_Tran.EmbeddedNavigator.Name = "";
			this.gridControl_Tran.Location = new System.Drawing.Point(3, 18);
			this.gridControl_Tran.MainView = this.gridView3;
			this.gridControl_Tran.Name = "gridControl_Tran";
			this.gridControl_Tran.Size = new System.Drawing.Size(194, 151);
			this.gridControl_Tran.TabIndex = 0;
			this.gridControl_Tran.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											this.gridView3});
			// 
			// gridView3
			// 
			this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn9,
																							 this.gridColumn10,
																							 this.gridColumn11});
			this.gridView3.GridControl = this.gridControl_Tran;
			this.gridView3.Name = "gridView3";
			this.gridView3.OptionsBehavior.Editable = false;
			this.gridView3.OptionsCustomization.AllowFilter = false;
			this.gridView3.OptionsCustomization.AllowGroup = false;
			this.gridView3.OptionsCustomization.AllowSort = false;
			this.gridView3.OptionsView.ShowColumnHeaders = false;
			this.gridView3.OptionsView.ShowFilterPanel = false;
			this.gridView3.OptionsView.ShowGroupPanel = false;
			this.gridView3.OptionsView.ShowIndicator = false;
			// 
			// gridColumn9
			// 
			this.gridColumn9.Caption = "gridColumn9";
			this.gridColumn9.FieldName = "info_stuName";
			this.gridColumn9.Name = "gridColumn9";
			this.gridColumn9.Visible = true;
			this.gridColumn9.VisibleIndex = 0;
			// 
			// gridColumn10
			// 
			this.gridColumn10.Caption = "gridColumn10";
			this.gridColumn10.FieldName = "info_stuNumber";
			this.gridColumn10.Name = "gridColumn10";
			this.gridColumn10.Visible = true;
			this.gridColumn10.VisibleIndex = 1;
			// 
			// gridColumn11
			// 
			this.gridColumn11.Caption = "gridColumn11";
			this.gridColumn11.FieldName = "state_flowStateName";
			this.gridColumn11.Name = "gridColumn11";
			this.gridColumn11.Visible = true;
			this.gridColumn11.VisibleIndex = 2;
			// 
			// RealTimeWindows
			// 
			this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.Appearance.Options.UseBackColor = true;
			this.Controls.Add(this.groupControl3);
			this.Controls.Add(this.groupControl2);
			this.Controls.Add(this.groupControl1);
			this.Name = "RealTimeWindows";
			this.Size = new System.Drawing.Size(200, 588);
			this.Load += new System.EventHandler(this.RealTimeWindows_Load);
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl_Stu)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
			this.groupControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl_Tea)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.timer_SelectInfo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
			this.groupControl3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl_Tran)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Load Initial Data
		private void RealTimeWindows_Load(object sender, System.EventArgs e)
		{
			LoadStuInfo();
			LoadTeaInfo();
			LoadDoseInfo();
		}

		private void LoadStuInfo()
		{
			int sumTotal;

			stuRealInfo = new MorningCheckInfoSystem().GetStuRealTimeWindowsInfo(
				out sumTotal,DateTime.Now);

//			foreach(DataRow row in stuRealInfo.Tables[0].Rows)
//			{
//				if(row["flow_stuFlowEnterState"].ToString().Equals("0")
//					||row["flow_stuFlowEnterState"].ToString().Equals("2")
//					||row["flow_stuFlowEnterState"].ToString().Equals("3"))
//				{
//					DataRow newRow = dt.NewRow();
//
//					newRow[0] = row["info_stuNumber"];
//					newRow[1] = row["info_stuName"];
//					newRow[2] = row["flow_stuFlowEnterDate"];
//					newRow[3] = row["state_flowStateName"]; 
//
//					dt.Rows.Add(newRow);
//				}
//
//				if(row["flow_stuFlowBackState"].ToString().Equals("1"))
//				{
//					DataRow newRow = dt.NewRow();
//
//					newRow[0] = row["info_stuNumber"];
//					newRow[1] = row["info_stuName"];
//					newRow[2] = row["flow_stuFlowBackDate"];
//					newRow[3] = row["info_stuCardHolder"]; 
//					
//					dt.Rows.Add(newRow);
//				}
//			}
			
			stuReal.Tables[0].Rows.Clear();
			foreach(DataRow row in stuRealInfo.Tables[0].Rows)
			{
				DataRow newRow = dt.NewRow();

				newRow[0] = row["info_stuNumber"];
				newRow[1] = row["info_stuName"];
				newRow[2] = row["RecTime"];

				if ( row["RecState"].ToString().Equals("0") || row["RecState"].ToString().Equals("2") || row["RecState"].ToString().Equals("3") )
					newRow[3] = row["state_flowStateName"]; 
				else if ( row["RecState"].ToString().Equals("1") )
					newRow[3] = row["info_stuCardHolder"]; 

				dt.Rows.Add(newRow);
			}

//			DataView stuRealInfoView = stuReal.Tables[0].DefaultView;
//
//			stuRealInfoView.Sort = "time desc";

			gridControl_Stu.DataSource = stuReal.Tables[0];

			paneCaption_Stu.Caption =  string.Format("当前已到校学生总数为:{0}, 上传学生总数为:{1}", sumTotal, Login.uploadCount);
		}

		private void LoadTeaInfo()
		{
			int sumTotal;

			teaRealInfo = new MorningCheckInfoSystem().GetTeaRealTimeWindowsInfo(
				out sumTotal,DateTime.Now);

			DataView teaRealInfoView = teaRealInfo.Tables[0].DefaultView;
			teaRealInfoView.Sort = "teaflow_date desc";

			gridControl_Tea.DataSource = teaRealInfoView;
			paneCaption_Tea.Caption = string.Format("当前已到校教师总数为:{0}, 上传教师总数为:{1}", sumTotal, 0);
		}

		private void LoadDoseInfo()
		{
			DataSet doseInfo = new MorningCheckInfoSystem().GetTranRealTimeWindowsInfo(
				DateTime.Now);

			gridControl_Tran.DataSource = doseInfo.Tables[0];
		}
		#endregion

		#region Timer event
		private void timer_SelectInfo_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			LoadStuInfo();
			LoadTeaInfo();
			LoadDoseInfo();
		}
		#endregion

		private void paneCaption_Stu_Click(object sender, System.EventArgs e)
		{
			mainForm.vis();
			mainForm.studentMorningCheckInfo1.Visible = true;
		}
	}
}

