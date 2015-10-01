
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

using CPTT.BusinessFacade;
using CPTT.SystemFramework;

namespace CPTT.WinUI.Panels
{
	/// <summary>
	/// Summary description for TransactionReminding.
	/// </summary>
	public class TransactionReminding : DevExpress.XtraEditors.XtraUserControl
	{
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Send_TeaGrade;
		private DevExpress.XtraEditors.TextEdit textEdit_Send_TeaName;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_TeaName;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_TeaNumber;
		private DevExpress.XtraEditors.TextEdit textEdit_Send_TeaNumber;
		private DevExpress.Utils.Frames.NotePanel notePanel19;
		private DevExpress.Utils.Frames.NotePanel notePanel20;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Send_TeaClass;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.XtraEditors.GroupControl groupControl3;
		private DevExpress.XtraEditors.SimpleButton simpleButton_EditPhoneNum;
		private DevExpress.XtraEditors.GroupControl groupControl4;
		private DevExpress.XtraGrid.GridControl gridControl2;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;

		private GetStuInfoByCondition getStuInfoByCondition;
		private string getGradeNumberFromCombo = "0";
		private DataSet TeaList;
		private DataView TeaView;
		private DevExpress.XtraEditors.MemoEdit memoEdit_SendContent;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
		private DevExpress.Utils.Frames.NotePanel notePanel_SendMsgContent;
		private DevExpress.Utils.Frames.NotePanel notePanel_SendMsgTitle;
		private DevExpress.XtraEditors.TextEdit textEdit_SendMsgTitle;
		private DevExpress.Utils.Frames.NotePanel notePanel_Realtime_GraphicSearch;
		private DevExpress.XtraBars.BarManager barManager1;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
		private DevExpress.XtraBars.PopupMenu popupMenu1;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_MsgRefresh;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_MsgDelete;
		private DevExpress.XtraEditors.GroupControl groupControl5;
		private DevExpress.XtraEditors.GroupControl groupControl6;
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.Utils.Frames.NotePanel notePanel1;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_Mode;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Send_Mode;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private DevExpress.XtraBars.PopupMenu popupMenu2;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_RecAdd;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_RecDel;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_RecReset;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
		private DevExpress.Utils.Frames.NotePanel notePanel_SerType;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_SerType;
		private DevExpress.Utils.Frames.NotePanel notePanel_MsgDate;
		private DevExpress.XtraEditors.TextEdit textEdit_SerContent;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_MsgDate;
		private DevExpress.Utils.Frames.NotePanel notePanel_HasRead;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_HasRead;
		private DataSet dsNeedToMerge;
		private string msgTimeType = "全部";
		private string msgReadType = "";
		private string msgSerContent = "";
		private string msgSerType = "全部";
		private System.Windows.Forms.HelpProvider helpProvider_TransactionInfo;

		private Login loginForm;

		public TransactionReminding()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call

//			TeaList = new CardInfoSystem().GetTeaCardInfoList();//教师卡
//			TeaView = TeaList.Tables[0].DefaultView;
//
//			gridControl1.DataSource = TeaView;

			getStuInfoByCondition = new GetStuInfoByCondition();

			comboBoxEdit_Send_TeaGrade.Properties.Items.Clear();
			comboBoxEdit_Send_TeaGrade.Properties.Items.AddRange(new object[]{"全部"});
			comboBoxEdit_Send_TeaGrade.SelectedItem = "全部";
			foreach(DataRow deptRow in new RealtimeInfoStat_TeacherSystem().GetTeaDept().Tables[0].Rows)
			{
				comboBoxEdit_Send_TeaGrade.Properties.Items.AddRange(
					new object[]{deptRow[0].ToString()});
			}

			SelectTeaCardInfo(textEdit_Send_TeaName.Text.Trim(),textEdit_Send_TeaNumber.Text.Trim(),
				comboBoxEdit_Send_TeaGrade.SelectedItem.ToString(),comboBoxEdit_Send_TeaClass.SelectedItem.ToString().Trim());

			LoadTranInfo();

			#region 帮助
			helpProvider_TransactionInfo.HelpNamespace = System.IO.Path.GetDirectoryName(Application.ExecutablePath)
				+ CPTT.SystemFramework.Util.HELP_FILE_NAME;

			this.helpProvider_TransactionInfo.SetHelpKeyword(this,"事务提醒功能");
			this.helpProvider_TransactionInfo.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.KeywordIndex);
			this.helpProvider_TransactionInfo.SetHelpString(this, "");
			this.helpProvider_TransactionInfo.SetShowHelp(this, true);
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
			this.comboBoxEdit_Send_TeaGrade = new DevExpress.XtraEditors.ComboBoxEdit();
			this.textEdit_Send_TeaName = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_Send_TeaName = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_Send_TeaNumber = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_Send_TeaNumber = new DevExpress.XtraEditors.TextEdit();
			this.notePanel19 = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel20 = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_Send_TeaClass = new DevExpress.XtraEditors.ComboBoxEdit();
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.groupControl6 = new DevExpress.XtraEditors.GroupControl();
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
			this.comboBoxEdit_Send_Mode = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_Send_Mode = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel1 = new DevExpress.Utils.Frames.NotePanel();
			this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
			this.textEdit_SendMsgTitle = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_SendMsgTitle = new DevExpress.Utils.Frames.NotePanel();
			this.memoEdit_SendContent = new DevExpress.XtraEditors.MemoEdit();
			this.simpleButton_EditPhoneNum = new DevExpress.XtraEditors.SimpleButton();
			this.notePanel_SendMsgContent = new DevExpress.Utils.Frames.NotePanel();
			this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
			this.comboBoxEdit_HasRead = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_HasRead = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_MsgDate = new DevExpress.XtraEditors.ComboBoxEdit();
			this.textEdit_SerContent = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_MsgDate = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_SerType = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_SerType = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_Realtime_GraphicSearch = new DevExpress.Utils.Frames.NotePanel();
			this.gridControl2 = new DevExpress.XtraGrid.GridControl();
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.barManager1 = new DevExpress.XtraBars.BarManager();
			this.popupMenu2 = new DevExpress.XtraBars.PopupMenu();
			this.barButtonItem_RecAdd = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem_RecDel = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem_RecReset = new DevExpress.XtraBars.BarButtonItem();
			this.popupMenu1 = new DevExpress.XtraBars.PopupMenu();
			this.barButtonItem_MsgRefresh = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem_MsgDelete = new DevExpress.XtraBars.BarButtonItem();
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			this.helpProvider_TransactionInfo = new System.Windows.Forms.HelpProvider();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Send_TeaGrade.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_Send_TeaName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_Send_TeaNumber.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Send_TeaClass.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl6)).BeginInit();
			this.groupControl6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
			this.groupControl5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Send_Mode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
			this.groupControl3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_SendMsgTitle.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit_SendContent.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
			this.groupControl4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_HasRead.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_MsgDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_SerContent.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_SerType.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
			this.SuspendLayout();
			// 
			// comboBoxEdit_Send_TeaGrade
			// 
			this.comboBoxEdit_Send_TeaGrade.EditValue = "全部";
			this.comboBoxEdit_Send_TeaGrade.Location = new System.Drawing.Point(112, 56);
			this.comboBoxEdit_Send_TeaGrade.Name = "comboBoxEdit_Send_TeaGrade";
			// 
			// comboBoxEdit_Send_TeaGrade.Properties
			// 
			this.comboBoxEdit_Send_TeaGrade.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_Send_TeaGrade.Properties.Items.AddRange(new object[] {
																					   "全部"});
			this.comboBoxEdit_Send_TeaGrade.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_Send_TeaGrade.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_Send_TeaGrade.TabIndex = 40;
			this.comboBoxEdit_Send_TeaGrade.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_Send_TeaGrade_SelectedIndexChanged);
			// 
			// textEdit_Send_TeaName
			// 
			this.textEdit_Send_TeaName.EditValue = "";
			this.textEdit_Send_TeaName.Location = new System.Drawing.Point(112, 152);
			this.textEdit_Send_TeaName.Name = "textEdit_Send_TeaName";
			this.textEdit_Send_TeaName.Size = new System.Drawing.Size(88, 23);
			this.textEdit_Send_TeaName.TabIndex = 37;
			this.textEdit_Send_TeaName.EditValueChanged += new System.EventHandler(this.textEdit_Send_TeaName_EditValueChanged);
			// 
			// notePanel_Send_TeaName
			// 
			this.notePanel_Send_TeaName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_Send_TeaName.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_Send_TeaName.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_Send_TeaName.ForeColor = System.Drawing.Color.Black;
			this.notePanel_Send_TeaName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Send_TeaName.Location = new System.Drawing.Point(24, 152);
			this.notePanel_Send_TeaName.MaxRows = 5;
			this.notePanel_Send_TeaName.Name = "notePanel_Send_TeaName";
			this.notePanel_Send_TeaName.ParentAutoHeight = true;
			this.notePanel_Send_TeaName.Size = new System.Drawing.Size(80, 22);
			this.notePanel_Send_TeaName.TabIndex = 36;
			this.notePanel_Send_TeaName.TabStop = false;
			this.notePanel_Send_TeaName.Text = "  姓  名:";
			// 
			// notePanel_Send_TeaNumber
			// 
			this.notePanel_Send_TeaNumber.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_Send_TeaNumber.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_Send_TeaNumber.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_Send_TeaNumber.ForeColor = System.Drawing.Color.Black;
			this.notePanel_Send_TeaNumber.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Send_TeaNumber.Location = new System.Drawing.Point(24, 120);
			this.notePanel_Send_TeaNumber.MaxRows = 5;
			this.notePanel_Send_TeaNumber.Name = "notePanel_Send_TeaNumber";
			this.notePanel_Send_TeaNumber.ParentAutoHeight = true;
			this.notePanel_Send_TeaNumber.Size = new System.Drawing.Size(80, 22);
			this.notePanel_Send_TeaNumber.TabIndex = 33;
			this.notePanel_Send_TeaNumber.TabStop = false;
			this.notePanel_Send_TeaNumber.Text = "  工  号:";
			// 
			// textEdit_Send_TeaNumber
			// 
			this.textEdit_Send_TeaNumber.EditValue = "";
			this.textEdit_Send_TeaNumber.Location = new System.Drawing.Point(112, 120);
			this.textEdit_Send_TeaNumber.Name = "textEdit_Send_TeaNumber";
			this.textEdit_Send_TeaNumber.Size = new System.Drawing.Size(88, 23);
			this.textEdit_Send_TeaNumber.TabIndex = 38;
			this.textEdit_Send_TeaNumber.EditValueChanged += new System.EventHandler(this.textEdit_Send_TeaNumber_EditValueChanged);
			// 
			// notePanel19
			// 
			this.notePanel19.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel19.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel19.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel19.ForeColor = System.Drawing.Color.Black;
			this.notePanel19.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel19.Location = new System.Drawing.Point(24, 56);
			this.notePanel19.MaxRows = 5;
			this.notePanel19.Name = "notePanel19";
			this.notePanel19.ParentAutoHeight = true;
			this.notePanel19.Size = new System.Drawing.Size(80, 22);
			this.notePanel19.TabIndex = 34;
			this.notePanel19.TabStop = false;
			this.notePanel19.Text = "  部  门: ";
			// 
			// notePanel20
			// 
			this.notePanel20.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel20.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel20.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel20.ForeColor = System.Drawing.Color.Black;
			this.notePanel20.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel20.Location = new System.Drawing.Point(24, 88);
			this.notePanel20.MaxRows = 5;
			this.notePanel20.Name = "notePanel20";
			this.notePanel20.ParentAutoHeight = true;
			this.notePanel20.Size = new System.Drawing.Size(80, 22);
			this.notePanel20.TabIndex = 35;
			this.notePanel20.TabStop = false;
			this.notePanel20.Text = "  岗  位:";
			// 
			// comboBoxEdit_Send_TeaClass
			// 
			this.comboBoxEdit_Send_TeaClass.EditValue = "全部";
			this.comboBoxEdit_Send_TeaClass.Location = new System.Drawing.Point(112, 88);
			this.comboBoxEdit_Send_TeaClass.Name = "comboBoxEdit_Send_TeaClass";
			// 
			// comboBoxEdit_Send_TeaClass.Properties
			// 
			this.comboBoxEdit_Send_TeaClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_Send_TeaClass.Properties.Items.AddRange(new object[] {
																					   "全部"});
			this.comboBoxEdit_Send_TeaClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_Send_TeaClass.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_Send_TeaClass.TabIndex = 39;
			this.comboBoxEdit_Send_TeaClass.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_Send_TeaClass_SelectedIndexChanged);
			// 
			// groupControl1
			// 
			this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.OrangeRed;
			this.groupControl1.AppearanceCaption.Options.UseFont = true;
			this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
			this.groupControl1.Controls.Add(this.groupControl6);
			this.groupControl1.Controls.Add(this.groupControl5);
			this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
			this.groupControl1.Location = new System.Drawing.Point(0, 0);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(224, 540);
			this.groupControl1.TabIndex = 24;
			this.groupControl1.Text = "发送目的";
			// 
			// groupControl6
			// 
			this.groupControl6.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl6.AppearanceCaption.ForeColor = System.Drawing.Color.DimGray;
			this.groupControl6.AppearanceCaption.Options.UseFont = true;
			this.groupControl6.AppearanceCaption.Options.UseForeColor = true;
			this.groupControl6.Controls.Add(this.gridControl1);
			this.groupControl6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl6.Location = new System.Drawing.Point(3, 240);
			this.groupControl6.Name = "groupControl6";
			this.groupControl6.Size = new System.Drawing.Size(218, 297);
			this.groupControl6.TabIndex = 26;
			this.groupControl6.Text = "待发送人员列表";
			// 
			// gridControl1
			// 
			this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl1.EmbeddedNavigator
			// 
			this.gridControl1.EmbeddedNavigator.Name = "";
			this.gridControl1.Location = new System.Drawing.Point(3, 18);
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.barManager1.SetPopupContextMenu(this.gridControl1, this.popupMenu2);
			this.gridControl1.Size = new System.Drawing.Size(212, 276);
			this.gridControl1.TabIndex = 26;
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn1,
																							 this.gridColumn2,
																							 this.gridColumn3,
																							 this.gridColumn4,
																							 this.gridColumn5});
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsBehavior.Editable = false;
			this.gridView1.OptionsCustomization.AllowFilter = false;
			this.gridView1.OptionsCustomization.AllowGroup = false;
			this.gridView1.OptionsView.ShowFilterPanel = false;
			this.gridView1.OptionsView.ShowFooter = true;
			this.gridView1.OptionsView.ShowGroupPanel = false;
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
			this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
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
			this.gridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
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
			this.gridColumn3.Caption = "部门";
			this.gridColumn3.FieldName = "T_Depart";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.OptionsColumn.AllowEdit = false;
			this.gridColumn3.OptionsColumn.AllowFocus = false;
			this.gridColumn3.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn3.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn3.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn3.OptionsColumn.ReadOnly = true;
			this.gridColumn3.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 2;
			// 
			// gridColumn4
			// 
			this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn4.Caption = "岗位";
			this.gridColumn4.FieldName = "T_Duty";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.OptionsColumn.AllowEdit = false;
			this.gridColumn4.OptionsColumn.AllowFocus = false;
			this.gridColumn4.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn4.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn4.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn4.OptionsColumn.ReadOnly = true;
			this.gridColumn4.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 3;
			// 
			// gridColumn5
			// 
			this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn5.Caption = "gridColumn5";
			this.gridColumn5.FieldName = "info_stuID";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.OptionsColumn.AllowEdit = false;
			this.gridColumn5.OptionsColumn.AllowFocus = false;
			this.gridColumn5.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn5.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn5.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn5.OptionsColumn.ReadOnly = true;
			this.gridColumn5.OptionsColumn.ShowInCustomizationForm = false;
			// 
			// groupControl5
			// 
			this.groupControl5.Appearance.ForeColor = System.Drawing.Color.Black;
			this.groupControl5.Appearance.Options.UseForeColor = true;
			this.groupControl5.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl5.AppearanceCaption.ForeColor = System.Drawing.Color.DimGray;
			this.groupControl5.AppearanceCaption.Options.UseFont = true;
			this.groupControl5.AppearanceCaption.Options.UseForeColor = true;
			this.groupControl5.Controls.Add(this.comboBoxEdit_Send_Mode);
			this.groupControl5.Controls.Add(this.notePanel_Send_Mode);
			this.groupControl5.Controls.Add(this.notePanel1);
			this.groupControl5.Controls.Add(this.notePanel_Send_TeaName);
			this.groupControl5.Controls.Add(this.textEdit_Send_TeaName);
			this.groupControl5.Controls.Add(this.notePanel19);
			this.groupControl5.Controls.Add(this.comboBoxEdit_Send_TeaGrade);
			this.groupControl5.Controls.Add(this.notePanel20);
			this.groupControl5.Controls.Add(this.comboBoxEdit_Send_TeaClass);
			this.groupControl5.Controls.Add(this.notePanel_Send_TeaNumber);
			this.groupControl5.Controls.Add(this.textEdit_Send_TeaNumber);
			this.groupControl5.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl5.Location = new System.Drawing.Point(3, 18);
			this.groupControl5.Name = "groupControl5";
			this.groupControl5.Size = new System.Drawing.Size(218, 222);
			this.groupControl5.TabIndex = 25;
			this.groupControl5.Text = "查找要发送信息的同事";
			// 
			// comboBoxEdit_Send_Mode
			// 
			this.comboBoxEdit_Send_Mode.EditValue = "自动获取";
			this.comboBoxEdit_Send_Mode.Location = new System.Drawing.Point(112, 184);
			this.comboBoxEdit_Send_Mode.Name = "comboBoxEdit_Send_Mode";
			// 
			// comboBoxEdit_Send_Mode.Properties
			// 
			this.comboBoxEdit_Send_Mode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																														   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_Send_Mode.Properties.Items.AddRange(new object[] {
																				   "自动获取",
																				   "自行添加"});
			this.comboBoxEdit_Send_Mode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_Send_Mode.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_Send_Mode.TabIndex = 52;
			this.comboBoxEdit_Send_Mode.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_Send_Mode_SelectedIndexChanged);
			// 
			// notePanel_Send_Mode
			// 
			this.notePanel_Send_Mode.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_Send_Mode.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_Send_Mode.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_Send_Mode.ForeColor = System.Drawing.Color.Black;
			this.notePanel_Send_Mode.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Send_Mode.Location = new System.Drawing.Point(24, 184);
			this.notePanel_Send_Mode.MaxRows = 5;
			this.notePanel_Send_Mode.Name = "notePanel_Send_Mode";
			this.notePanel_Send_Mode.ParentAutoHeight = true;
			this.notePanel_Send_Mode.Size = new System.Drawing.Size(80, 22);
			this.notePanel_Send_Mode.TabIndex = 51;
			this.notePanel_Send_Mode.TabStop = false;
			this.notePanel_Send_Mode.Text = "添加模式:";
			this.notePanel_Send_Mode.Click += new System.EventHandler(this.notePanel_Send_Mode_Click);
			// 
			// notePanel1
			// 
			this.notePanel1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.notePanel1.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel1.Location = new System.Drawing.Point(3, 18);
			this.notePanel1.MaxRows = 5;
			this.notePanel1.Name = "notePanel1";
			this.notePanel1.ParentAutoHeight = true;
			this.notePanel1.Size = new System.Drawing.Size(212, 23);
			this.notePanel1.TabIndex = 50;
			this.notePanel1.TabStop = false;
			this.notePanel1.Text = "请点击模式标签进行自行添加";
			// 
			// groupControl3
			// 
			this.groupControl3.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.groupControl3.AppearanceCaption.ForeColor = System.Drawing.Color.DarkOrange;
			this.groupControl3.AppearanceCaption.Options.UseFont = true;
			this.groupControl3.AppearanceCaption.Options.UseForeColor = true;
			this.groupControl3.Controls.Add(this.textEdit_SendMsgTitle);
			this.groupControl3.Controls.Add(this.notePanel_SendMsgTitle);
			this.groupControl3.Controls.Add(this.memoEdit_SendContent);
			this.groupControl3.Controls.Add(this.simpleButton_EditPhoneNum);
			this.groupControl3.Controls.Add(this.notePanel_SendMsgContent);
			this.groupControl3.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl3.Location = new System.Drawing.Point(224, 0);
			this.groupControl3.Name = "groupControl3";
			this.groupControl3.Size = new System.Drawing.Size(548, 144);
			this.groupControl3.TabIndex = 25;
			this.groupControl3.Text = "发送信息";
			// 
			// textEdit_SendMsgTitle
			// 
			this.textEdit_SendMsgTitle.EditValue = "";
			this.textEdit_SendMsgTitle.Location = new System.Drawing.Point(128, 24);
			this.textEdit_SendMsgTitle.Name = "textEdit_SendMsgTitle";
			this.textEdit_SendMsgTitle.Size = new System.Drawing.Size(320, 23);
			this.textEdit_SendMsgTitle.TabIndex = 43;
			// 
			// notePanel_SendMsgTitle
			// 
			this.notePanel_SendMsgTitle.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_SendMsgTitle.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_SendMsgTitle.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_SendMsgTitle.ForeColor = System.Drawing.Color.Black;
			this.notePanel_SendMsgTitle.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_SendMsgTitle.Location = new System.Drawing.Point(40, 24);
			this.notePanel_SendMsgTitle.MaxRows = 5;
			this.notePanel_SendMsgTitle.Name = "notePanel_SendMsgTitle";
			this.notePanel_SendMsgTitle.ParentAutoHeight = true;
			this.notePanel_SendMsgTitle.Size = new System.Drawing.Size(80, 22);
			this.notePanel_SendMsgTitle.TabIndex = 42;
			this.notePanel_SendMsgTitle.TabStop = false;
			this.notePanel_SendMsgTitle.Text = "信息主题:";
			// 
			// memoEdit_SendContent
			// 
			this.memoEdit_SendContent.EditValue = "";
			this.memoEdit_SendContent.Location = new System.Drawing.Point(128, 56);
			this.memoEdit_SendContent.Name = "memoEdit_SendContent";
			this.memoEdit_SendContent.Size = new System.Drawing.Size(320, 72);
			this.memoEdit_SendContent.TabIndex = 41;
			// 
			// simpleButton_EditPhoneNum
			// 
			this.simpleButton_EditPhoneNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButton_EditPhoneNum.Location = new System.Drawing.Point(416, 104);
			this.simpleButton_EditPhoneNum.Name = "simpleButton_EditPhoneNum";
			this.simpleButton_EditPhoneNum.Size = new System.Drawing.Size(72, 24);
			this.simpleButton_EditPhoneNum.TabIndex = 40;
			this.simpleButton_EditPhoneNum.Text = "发送";
			this.simpleButton_EditPhoneNum.Click += new System.EventHandler(this.simpleButton_EditPhoneNum_Click);
			// 
			// notePanel_SendMsgContent
			// 
			this.notePanel_SendMsgContent.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_SendMsgContent.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_SendMsgContent.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_SendMsgContent.ForeColor = System.Drawing.Color.Black;
			this.notePanel_SendMsgContent.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_SendMsgContent.Location = new System.Drawing.Point(40, 56);
			this.notePanel_SendMsgContent.MaxRows = 5;
			this.notePanel_SendMsgContent.Name = "notePanel_SendMsgContent";
			this.notePanel_SendMsgContent.ParentAutoHeight = true;
			this.notePanel_SendMsgContent.Size = new System.Drawing.Size(80, 22);
			this.notePanel_SendMsgContent.TabIndex = 38;
			this.notePanel_SendMsgContent.TabStop = false;
			this.notePanel_SendMsgContent.Text = "信息内容:";
			// 
			// groupControl4
			// 
			this.groupControl4.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.groupControl4.AppearanceCaption.ForeColor = System.Drawing.Color.DarkOrange;
			this.groupControl4.AppearanceCaption.Options.UseFont = true;
			this.groupControl4.AppearanceCaption.Options.UseForeColor = true;
			this.groupControl4.Controls.Add(this.comboBoxEdit_HasRead);
			this.groupControl4.Controls.Add(this.notePanel_HasRead);
			this.groupControl4.Controls.Add(this.comboBoxEdit_MsgDate);
			this.groupControl4.Controls.Add(this.textEdit_SerContent);
			this.groupControl4.Controls.Add(this.notePanel_MsgDate);
			this.groupControl4.Controls.Add(this.comboBoxEdit_SerType);
			this.groupControl4.Controls.Add(this.notePanel_SerType);
			this.groupControl4.Controls.Add(this.notePanel_Realtime_GraphicSearch);
			this.groupControl4.Controls.Add(this.gridControl2);
			this.groupControl4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl4.Location = new System.Drawing.Point(224, 144);
			this.groupControl4.Name = "groupControl4";
			this.groupControl4.Size = new System.Drawing.Size(548, 396);
			this.groupControl4.TabIndex = 26;
			this.groupControl4.Text = "已收到的提醒";
			// 
			// comboBoxEdit_HasRead
			// 
			this.comboBoxEdit_HasRead.EditValue = "全部";
			this.comboBoxEdit_HasRead.Location = new System.Drawing.Point(480, 48);
			this.comboBoxEdit_HasRead.Name = "comboBoxEdit_HasRead";
			// 
			// comboBoxEdit_HasRead.Properties
			// 
			this.comboBoxEdit_HasRead.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																														 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_HasRead.Properties.Items.AddRange(new object[] {
																				 "全部",
																				 "已阅读",
																				 "未阅读"});
			this.comboBoxEdit_HasRead.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_HasRead.Size = new System.Drawing.Size(80, 23);
			this.comboBoxEdit_HasRead.TabIndex = 56;
			this.comboBoxEdit_HasRead.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_HasRead_SelectedIndexChanged);
			// 
			// notePanel_HasRead
			// 
			this.notePanel_HasRead.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_HasRead.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_HasRead.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_HasRead.ForeColor = System.Drawing.Color.Black;
			this.notePanel_HasRead.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_HasRead.Location = new System.Drawing.Point(392, 48);
			this.notePanel_HasRead.MaxRows = 5;
			this.notePanel_HasRead.Name = "notePanel_HasRead";
			this.notePanel_HasRead.ParentAutoHeight = true;
			this.notePanel_HasRead.Size = new System.Drawing.Size(80, 22);
			this.notePanel_HasRead.TabIndex = 55;
			this.notePanel_HasRead.TabStop = false;
			this.notePanel_HasRead.Text = "阅读情况:";
			// 
			// comboBoxEdit_MsgDate
			// 
			this.comboBoxEdit_MsgDate.EditValue = "全部";
			this.comboBoxEdit_MsgDate.Location = new System.Drawing.Point(288, 48);
			this.comboBoxEdit_MsgDate.Name = "comboBoxEdit_MsgDate";
			// 
			// comboBoxEdit_MsgDate.Properties
			// 
			this.comboBoxEdit_MsgDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																														 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_MsgDate.Properties.Items.AddRange(new object[] {
																				 "全部",
																				 "最近三天",
																				 "最近一周",
																				 "最近一月",
																				 "最近一年"});
			this.comboBoxEdit_MsgDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_MsgDate.Size = new System.Drawing.Size(96, 23);
			this.comboBoxEdit_MsgDate.TabIndex = 54;
			this.comboBoxEdit_MsgDate.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_MsgDate_SelectedIndexChanged);
			// 
			// textEdit_SerContent
			// 
			this.textEdit_SerContent.EditValue = "";
			this.textEdit_SerContent.Location = new System.Drawing.Point(8, 72);
			this.textEdit_SerContent.Name = "textEdit_SerContent";
			this.textEdit_SerContent.Size = new System.Drawing.Size(552, 23);
			this.textEdit_SerContent.TabIndex = 53;
			this.textEdit_SerContent.EditValueChanged += new System.EventHandler(this.textEdit_SerContent_EditValueChanged);
			// 
			// notePanel_MsgDate
			// 
			this.notePanel_MsgDate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MsgDate.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MsgDate.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MsgDate.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MsgDate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MsgDate.Location = new System.Drawing.Point(200, 48);
			this.notePanel_MsgDate.MaxRows = 5;
			this.notePanel_MsgDate.Name = "notePanel_MsgDate";
			this.notePanel_MsgDate.ParentAutoHeight = true;
			this.notePanel_MsgDate.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MsgDate.TabIndex = 52;
			this.notePanel_MsgDate.TabStop = false;
			this.notePanel_MsgDate.Text = "信息时间:";
			// 
			// comboBoxEdit_SerType
			// 
			this.comboBoxEdit_SerType.EditValue = "全部";
			this.comboBoxEdit_SerType.Location = new System.Drawing.Point(96, 48);
			this.comboBoxEdit_SerType.Name = "comboBoxEdit_SerType";
			// 
			// comboBoxEdit_SerType.Properties
			// 
			this.comboBoxEdit_SerType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																														 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_SerType.Properties.Items.AddRange(new object[] {
																				 "全部",
																				 "发信人",
																				 "信息主题",
																				 "信息内容"});
			this.comboBoxEdit_SerType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_SerType.Size = new System.Drawing.Size(96, 23);
			this.comboBoxEdit_SerType.TabIndex = 51;
			this.comboBoxEdit_SerType.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_SerType_SelectedIndexChanged);
			// 
			// notePanel_SerType
			// 
			this.notePanel_SerType.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_SerType.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_SerType.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_SerType.ForeColor = System.Drawing.Color.Black;
			this.notePanel_SerType.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_SerType.Location = new System.Drawing.Point(8, 48);
			this.notePanel_SerType.MaxRows = 5;
			this.notePanel_SerType.Name = "notePanel_SerType";
			this.notePanel_SerType.ParentAutoHeight = true;
			this.notePanel_SerType.Size = new System.Drawing.Size(80, 22);
			this.notePanel_SerType.TabIndex = 50;
			this.notePanel_SerType.TabStop = false;
			this.notePanel_SerType.Text = "查询类型:";
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
			this.notePanel_Realtime_GraphicSearch.Size = new System.Drawing.Size(542, 23);
			this.notePanel_Realtime_GraphicSearch.TabIndex = 49;
			this.notePanel_Realtime_GraphicSearch.TabStop = false;
			this.notePanel_Realtime_GraphicSearch.Text = "双击指定信息以获取该信息的内容";
			// 
			// gridControl2
			// 
			this.gridControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
			// 
			// gridControl2.EmbeddedNavigator
			// 
			this.gridControl2.EmbeddedNavigator.Name = "";
			this.gridControl2.Location = new System.Drawing.Point(3, 33);
			this.gridControl2.MainView = this.gridView2;
			this.gridControl2.Name = "gridControl2";
			this.barManager1.SetPopupContextMenu(this.gridControl2, this.popupMenu1);
			this.gridControl2.Size = new System.Drawing.Size(542, 360);
			this.gridControl2.TabIndex = 23;
			this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.gridView2});
			this.gridControl2.DoubleClick += new System.EventHandler(this.gridControl2_DoubleClick);
			// 
			// gridView2
			// 
			this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn6,
																							 this.gridColumn7,
																							 this.gridColumn8,
																							 this.gridColumn10,
																							 this.gridColumn9});
			this.gridView2.GridControl = this.gridControl2;
			this.gridView2.Name = "gridView2";
			this.gridView2.OptionsBehavior.Editable = false;
			this.gridView2.OptionsCustomization.AllowFilter = false;
			this.gridView2.OptionsCustomization.AllowGroup = false;
			this.gridView2.OptionsView.ShowFilterPanel = false;
			this.gridView2.OptionsView.ShowFooter = true;
			this.gridView2.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn6
			// 
			this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn6.Caption = "发信人";
			this.gridColumn6.FieldName = "T_Name";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.OptionsColumn.AllowEdit = false;
			this.gridColumn6.OptionsColumn.AllowFocus = false;
			this.gridColumn6.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn6.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn6.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn6.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn6.OptionsColumn.ReadOnly = true;
			this.gridColumn6.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 0;
			this.gridColumn6.Width = 93;
			// 
			// gridColumn7
			// 
			this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn7.Caption = "信息时间";
			this.gridColumn7.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
			this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.gridColumn7.FieldName = "SendDate";
			this.gridColumn7.Name = "gridColumn7";
			this.gridColumn7.OptionsColumn.AllowEdit = false;
			this.gridColumn7.OptionsColumn.AllowFocus = false;
			this.gridColumn7.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn7.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn7.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn7.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn7.OptionsColumn.ReadOnly = true;
			this.gridColumn7.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn7.Visible = true;
			this.gridColumn7.VisibleIndex = 1;
			this.gridColumn7.Width = 152;
			// 
			// gridColumn8
			// 
			this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn8.Caption = "信息主题";
			this.gridColumn8.DisplayFormat.FormatString = "content";
			this.gridColumn8.FieldName = "Title";
			this.gridColumn8.Name = "gridColumn8";
			this.gridColumn8.OptionsColumn.AllowEdit = false;
			this.gridColumn8.OptionsColumn.AllowFocus = false;
			this.gridColumn8.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn8.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn8.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn8.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn8.OptionsColumn.ReadOnly = true;
			this.gridColumn8.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn8.Visible = true;
			this.gridColumn8.VisibleIndex = 2;
			this.gridColumn8.Width = 195;
			// 
			// gridColumn10
			// 
			this.gridColumn10.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn10.Caption = "阅读情况";
			this.gridColumn10.FieldName = "HasRead";
			this.gridColumn10.Name = "gridColumn10";
			this.gridColumn10.OptionsColumn.AllowEdit = false;
			this.gridColumn10.OptionsColumn.AllowFocus = false;
			this.gridColumn10.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn10.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn10.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn10.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn10.OptionsColumn.ReadOnly = true;
			this.gridColumn10.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn10.Visible = true;
			this.gridColumn10.VisibleIndex = 3;
			this.gridColumn10.Width = 85;
			// 
			// gridColumn9
			// 
			this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn9.Caption = "gridColumn9";
			this.gridColumn9.FieldName = "TransactionID";
			this.gridColumn9.Name = "gridColumn9";
			this.gridColumn9.OptionsColumn.AllowEdit = false;
			this.gridColumn9.OptionsColumn.AllowFocus = false;
			this.gridColumn9.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn9.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn9.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn9.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn9.OptionsColumn.ReadOnly = true;
			this.gridColumn9.OptionsColumn.ShowInCustomizationForm = false;
			// 
			// barManager1
			// 
			this.barManager1.DockControls.Add(this.barDockControlTop);
			this.barManager1.DockControls.Add(this.barDockControlBottom);
			this.barManager1.DockControls.Add(this.barDockControlLeft);
			this.barManager1.DockControls.Add(this.barDockControlRight);
			this.barManager1.Form = this;
			this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
																				  this.barButtonItem_MsgRefresh,
																				  this.barButtonItem_MsgDelete,
																				  this.barButtonItem_RecAdd,
																				  this.barButtonItem_RecDel,
																				  this.barButtonItem_RecReset});
			this.barManager1.MaxItemId = 5;
			// 
			// popupMenu2
			// 
			this.popupMenu2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
																									new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_RecAdd),
																									new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_RecDel),
																									new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_RecReset)});
			this.popupMenu2.Manager = this.barManager1;
			this.popupMenu2.Name = "popupMenu2";
			// 
			// barButtonItem_RecAdd
			// 
			this.barButtonItem_RecAdd.Caption = "记录添加";
			this.barButtonItem_RecAdd.Id = 2;
			this.barButtonItem_RecAdd.Name = "barButtonItem_RecAdd";
			this.barButtonItem_RecAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_RecAdd_ItemClick);
			// 
			// barButtonItem_RecDel
			// 
			this.barButtonItem_RecDel.Caption = "记录删除";
			this.barButtonItem_RecDel.Id = 3;
			this.barButtonItem_RecDel.Name = "barButtonItem_RecDel";
			this.barButtonItem_RecDel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_RecDel_ItemClick);
			// 
			// barButtonItem_RecReset
			// 
			this.barButtonItem_RecReset.Caption = "记录重置";
			this.barButtonItem_RecReset.Id = 4;
			this.barButtonItem_RecReset.Name = "barButtonItem_RecReset";
			this.barButtonItem_RecReset.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_RecReset_ItemClick);
			// 
			// popupMenu1
			// 
			this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
																									new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_MsgRefresh),
																									new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_MsgDelete)});
			this.popupMenu1.Manager = this.barManager1;
			this.popupMenu1.Name = "popupMenu1";
			// 
			// barButtonItem_MsgRefresh
			// 
			this.barButtonItem_MsgRefresh.Caption = "信息刷新";
			this.barButtonItem_MsgRefresh.Id = 0;
			this.barButtonItem_MsgRefresh.Name = "barButtonItem_MsgRefresh";
			this.barButtonItem_MsgRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_MsgRefresh_ItemClick);
			// 
			// barButtonItem_MsgDelete
			// 
			this.barButtonItem_MsgDelete.Caption = "信息删除";
			this.barButtonItem_MsgDelete.Id = 1;
			this.barButtonItem_MsgDelete.Name = "barButtonItem_MsgDelete";
			this.barButtonItem_MsgDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_MsgDelete_ItemClick);
			// 
			// TransactionReminding
			// 
			this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.Appearance.Options.UseBackColor = true;
			this.Controls.Add(this.groupControl4);
			this.Controls.Add(this.groupControl3);
			this.Controls.Add(this.groupControl1);
			this.Controls.Add(this.barDockControlTop);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Name = "TransactionReminding";
			this.Size = new System.Drawing.Size(772, 540);
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Send_TeaGrade.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_Send_TeaName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_Send_TeaNumber.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Send_TeaClass.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl6)).EndInit();
			this.groupControl6.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
			this.groupControl5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Send_Mode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
			this.groupControl3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.textEdit_SendMsgTitle.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit_SendContent.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
			this.groupControl4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_HasRead.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_MsgDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_SerContent.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_SerType.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region binding teacher info
		private void comboBoxEdit_Send_TeaGrade_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			comboBoxEdit_Send_TeaClass.Properties.Items.Clear();
			comboBoxEdit_Send_TeaClass.Properties.Items.AddRange(new object[]{"全部"});
			comboBoxEdit_Send_TeaClass.SelectedItem = "全部";
			if(getStuInfoByCondition.getGradeInfo(comboBoxEdit_Send_TeaGrade.SelectedItem.ToString(),"").Tables[0].Rows.Count > 0)
			{
				//根据年级选择获取年级编号
				getGradeNumberFromCombo = getStuInfoByCondition.getGradeInfo(
					comboBoxEdit_Send_TeaGrade.SelectedItem.ToString(),"").Tables[0].Rows[0][0].ToString();
				foreach(DataRow getClassList in getStuInfoByCondition.getClassInfo("","",
					getGradeNumberFromCombo).Tables[0].Rows)
				{
					comboBoxEdit_Send_TeaClass.Properties.Items.AddRange(
						new object[]{getClassList[1].ToString()});
				}
			}

			//根据年级查询所选信息
//			if(!comboBoxEdit_Send_TeaGrade.SelectedItem.ToString().Equals("全部"))
//			{
				SelectTeaCardInfo(textEdit_Send_TeaName.Text.Trim(),textEdit_Send_TeaNumber.Text.Trim(),
					comboBoxEdit_Send_TeaGrade.SelectedItem.ToString().Trim(), comboBoxEdit_Send_TeaClass
					.SelectedItem.ToString().Trim());
//			}
//			else
//			{
//				SelectTeaCardInfo(textEdit_Send_TeaName.Text.Trim(),textEdit_Send_TeaNumber.Text.Trim(),
//					comboBoxEdit_Send_TeaGrade.SelectedItem.ToString(),comboBoxEdit_Send_TeaClass.SelectedItem.ToString().Trim());
//			}
		}

		private void comboBoxEdit_Send_TeaClass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
//			if(!comboBoxEdit_Send_TeaClass.SelectedItem.ToString().Equals("全部"))
//			{
				SelectTeaCardInfo(textEdit_Send_TeaName.Text.Trim(),textEdit_Send_TeaNumber.Text.Trim(),
					comboBoxEdit_Send_TeaGrade.SelectedItem.ToString().Trim(), comboBoxEdit_Send_TeaClass
					.SelectedItem.ToString().Trim());
//			}
//			else
//			{
//				SelectTeaCardInfo(textEdit_Send_TeaName.Text.Trim(),textEdit_Send_TeaNumber.Text.Trim(),
//					comboBoxEdit_Send_TeaGrade.SelectedItem.ToString().Trim(),string.Empty);
//			}
		}

		private void textEdit_Send_TeaName_EditValueChanged(object sender, System.EventArgs e)
		{
//			if ( TeaView != null )
//			{
				SelectTeaCardInfo(textEdit_Send_TeaName.Text.Trim(),textEdit_Send_TeaNumber.Text.Trim(),
					comboBoxEdit_Send_TeaGrade.SelectedItem.ToString().Trim(), comboBoxEdit_Send_TeaClass
					.SelectedItem.ToString().Trim());
//			}
		}

		private void textEdit_Send_TeaNumber_EditValueChanged(object sender, System.EventArgs e)
		{
//			if ( TeaView != null )
//			{
				SelectTeaCardInfo(textEdit_Send_TeaName.Text.Trim(),textEdit_Send_TeaNumber.Text.Trim(),
					comboBoxEdit_Send_TeaGrade.SelectedItem.ToString().Trim(), comboBoxEdit_Send_TeaClass
					.SelectedItem.ToString().Trim());
//			}
		}

		//过滤DataView
		private void SelectTeaCardInfo(string name,string id,string grade,string className)
		{
			//			string rowFilter = string.Empty;
			//			
			//			rowFilter = "T_Name like '%"+name+"%'";
			//
			//			if(grade.Equals("全部"))
			//			{
			//				rowFilter = rowFilter + " and T_Depart like '%'";
			//			}
			//			else
			//			{
			//				rowFilter = rowFilter + " and T_Depart like '%"+
			//					grade+"%'";
			//			}
			//
			//			if(className.Equals("全部"))
			//			{
			//				rowFilter = rowFilter + " and T_Duty like '%'";
			//			}
			//			else
			//			{
			//				rowFilter = rowFilter + " and T_Duty like '%"+className+"%'";
			//			}
			//
			//			if(id.Length==4)
			//			{
			//				rowFilter += "and T_Number="+id; 
			//			}
			//
			//			TeaView.RowFilter = rowFilter;

			if ( name.Equals("") && id.Equals("") )
			{
				if ( grade.Equals("全部") )
					TeaList = new TransactionSystem().GetTeaInfoListForTran("","","","");
				else
				{
					if ( className.Equals("全部") )
						TeaList = new TransactionSystem().GetTeaInfoListForTran(grade,"","","");
					else
						TeaList = new TransactionSystem().GetTeaInfoListForTran(grade,className,"","");
				}
			}
			else
			{
				if ( id.Equals("") )
					TeaList = new TransactionSystem().GetTeaInfoListForTran("","",name,"");
				else
					TeaList = new TransactionSystem().GetTeaInfoListForTran("","","",id);
			}

			if ( TeaList != null )
			{
				if ( comboBoxEdit_Send_Mode.SelectedIndex == 0 )
					gridControl1.DataSource = TeaList.Tables[0];
			}
		}
		#endregion

		#region send transaction
		private void simpleButton_EditPhoneNum_Click(object sender, System.EventArgs e)
		{
			if ( memoEdit_SendContent.Text.Trim() == string.Empty || textEdit_SendMsgTitle.Text.Trim() == string.Empty )
			{
				MessageBox.Show("发送内容或标题不能为空.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}

			while ( true )
			{			
				if ( gridView1.RowCount != 0 )
				{
					string sendFrom = Thread.CurrentPrincipal.Identity.Name;
					string sendTo = gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["T_Number"].ToString();
					string sendTitle = textEdit_SendMsgTitle.Text.Trim();
					DateTime sendDate = DateTime.Now;
					string content = memoEdit_SendContent.Text.Trim();

					if(sendFrom.Equals(sendTo))
					{
						gridView1.DeleteRow(0);
						continue;
					}

					if ( new TransactionSystem().InsertTransaction(sendFrom,sendTo,sendDate,content,sendTitle) <= 0 )
					{
						MessageBox.Show("发送失败,请检查网络！","系统信息!",
							MessageBoxButtons.OK,MessageBoxIcon.Information);
						break;
					}
					else
					{
						gridView1.DeleteRow(0);
					}
				}
				else
					break;
			}

			dsNeedToMerge = null;
			gridControl1.DataSource = null;

			MessageBox.Show("信息发送成功！","系统信息!",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}
		#endregion

		#region load transaction info
		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			LoadTranInfo();
		}

		private void LoadTranInfo()
		{
//			string tNumber = Thread.CurrentPrincipal.Identity.Name;
//
//			DataSet tranInfo = new TransactionSystem().GetTransactionByTNumber(tNumber);
//			DataView tranView = tranInfo.Tables[0].DefaultView;
//
//			gridControl2.DataSource = tranView;

			TranSearch(msgSerType,msgSerContent,msgSerContent,msgSerContent,msgTimeType,msgReadType);
		}
		#endregion

		private void simpleButton2_Click(object sender, System.EventArgs e)
		{
			if ( gridView2.GetSelectedRows().Length > 0 )
			{
				int tranID = Convert.ToInt32(gridView2.GetDataRow(
					gridView2.GetSelectedRows()[0])["TransactionID"]);
				new TransactionSystem().DeleteTransaction(tranID);

				LoadTranInfo();
			}
			else
			{
				MessageBox.Show("请先选择要删除的信息.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}

		private void barButtonItem_MsgRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			LoadTranInfo();
		}

		private void barButtonItem_MsgDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if ( gridView2.GetSelectedRows().Length > 0 )
			{
				int tranID = Convert.ToInt32(gridView2.GetDataRow(
					gridView2.GetSelectedRows()[0])["TransactionID"]);
				new TransactionSystem().DeleteTransaction(tranID);

				LoadTranInfo();
			}
			else
			{
				MessageBox.Show("请先选择要删除的信息.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}

		private void gridControl2_DoubleClick(object sender, System.EventArgs e)
		{
			if ( gridView2.GetSelectedRows().Length > 0 )
				MessageBox.Show("内容:\n"+new TransactionSystem().GetMsgContent(Convert.ToInt32(gridView2.GetDataRow(
					gridView2.GetSelectedRows()[0])["TransactionID"])),"系统信息",MessageBoxButtons.OK);

			LoadTranInfo();
			
			this.loginForm = (Login)(this.ParentForm.Owner);
			loginForm.TranMsgStatusChange();
			
		}

		private void notePanel_Send_Mode_Click(object sender, System.EventArgs e)
		{
			if ( comboBoxEdit_Send_Mode.SelectedIndex == 1 )
			{
				if ( TeaList != null )
				{
					if ( dsNeedToMerge == null )
					{
						dsNeedToMerge = TeaList;
						gridControl1.DataSource = dsNeedToMerge.Tables[0];
					}
					else
					{
						dsNeedToMerge.Merge(TeaList.Tables[0]);
						gridControl1.DataSource = dsNeedToMerge.Tables[0];
					}
				}
				else
					MessageBox.Show("您要添加的用户不存在，请重试！");
			}
			else
				MessageBox.Show("您所选择的模式可能存在问题，信息用户添加失败！");
		}

		private void comboBoxEdit_Send_Mode_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			dsNeedToMerge = null;

			if ( comboBoxEdit_Send_Mode.SelectedIndex == 1 )
				gridControl1.DataSource = null;
		}

		private void barButtonItem_RecReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if ( comboBoxEdit_Send_Mode.SelectedIndex == 1 )
			{
				dsNeedToMerge = null;
				gridControl1.DataSource = null;
			}
		}

		private void comboBoxEdit_SerType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			msgSerType = comboBoxEdit_SerType.SelectedItem.ToString();
			TranSearch(msgSerType,msgSerContent,msgSerContent,msgSerContent,msgTimeType,msgReadType);
		}

		private void comboBoxEdit_MsgDate_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			msgTimeType = comboBoxEdit_MsgDate.SelectedItem.ToString();
			TranSearch(msgSerType,msgSerContent,msgSerContent,msgSerContent,msgTimeType,msgReadType);
		}

		private void comboBoxEdit_HasRead_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( comboBoxEdit_HasRead.SelectedItem.ToString().Equals("全部") )
				msgReadType = "";
			else if ( comboBoxEdit_HasRead.SelectedItem.ToString().Equals("已阅读") )
				msgReadType = "√";
			else
				msgReadType = "○";

			TranSearch(msgSerType,msgSerContent,msgSerContent,msgSerContent,msgTimeType,msgReadType);
		}

		private void textEdit_SerContent_EditValueChanged(object sender, System.EventArgs e)
		{
			msgSerContent = textEdit_SerContent.Text.Trim();
			TranSearch(msgSerType,msgSerContent,msgSerContent,msgSerContent,msgTimeType,msgReadType);
		}

		private void TranSearch(string msgSerType,string sendFrom,string content,string title,string timeType,string readType)
		{
			DataSet dsTranSearch = null;

			if ( msgSerType.Equals("全部") )
				dsTranSearch = new TransactionSystem().TranSearch(Thread.CurrentPrincipal.Identity.Name,"","","",msgTimeType,msgReadType);
			else if ( msgSerType.Equals("发信人") )
				dsTranSearch = new TransactionSystem().TranSearch(Thread.CurrentPrincipal.Identity.Name,sendFrom,"","",msgTimeType,msgReadType);
			else if ( msgSerType.Equals("信息内容") )
				dsTranSearch = new TransactionSystem().TranSearch(Thread.CurrentPrincipal.Identity.Name,"",content,"",msgTimeType,msgReadType);
			else 
				dsTranSearch = new TransactionSystem().TranSearch(Thread.CurrentPrincipal.Identity.Name,"","",title,msgTimeType,msgReadType);

			if ( dsTranSearch != null )
				gridControl2.DataSource = dsTranSearch.Tables[0];
		}

		private void barButtonItem_RecAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if ( comboBoxEdit_Send_Mode.SelectedIndex == 1 )
			{
				if ( TeaList != null )
				{
					if ( dsNeedToMerge == null )
					{
						dsNeedToMerge = TeaList;
						gridControl1.DataSource = dsNeedToMerge.Tables[0];
					}
					else
					{
						dsNeedToMerge.Merge(TeaList.Tables[0]);
						gridControl1.DataSource = dsNeedToMerge.Tables[0];
					}
				}
				else
					MessageBox.Show("您要添加的用户不存在，请重试！");
			}
			else
				MessageBox.Show("您所选择的模式可能存在问题，信息用户添加失败！");
		}

		private void barButtonItem_RecDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			gridView1.DeleteRow(gridView1.GetSelectedRows()[0]);
		}
	}
}

