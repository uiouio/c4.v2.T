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
	/// Summary description for PhoneNum.
	/// </summary>
	public class PhoneNum : DevExpress.XtraEditors.XtraUserControl
	{
		private DevExpress.Utils.Frames.NotePanel notePanel_DutyDetailsTitle;
		private DevExpress.XtraEditors.GroupControl groupControl2;
		private DevExpress.XtraEditors.TextEdit textEdit_Send_StuName;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Send_StuClass;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Send_StuGrade;
		private DevExpress.XtraEditors.TextEdit textEdit_Send_StuNumber;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_StuNumber;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_StuClass;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_StuGrade;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_StuName;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.XtraEditors.SimpleButton simpleButton_EditPhoneNum;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private GetStuInfoByCondition getStuInfoByCondition;
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private string getGradeNumberFromCombo = "0";
		private DataSet StuList;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraEditors.GroupControl groupControl3;
		private DevExpress.XtraEditors.GroupControl groupControl4;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		private DevExpress.Utils.Frames.NotePanel notePanel1;
		private DevExpress.Utils.Frames.NotePanel notePanel2;
		private DevExpress.XtraEditors.TextEdit textEdit1;
		private DevExpress.XtraEditors.TextEdit textEdit2;
		private DevExpress.XtraGrid.GridControl gridControl2;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private DataView StuView;

		public PhoneNum()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call

			getStuInfoByCondition = new GetStuInfoByCondition();

			StuList = new CardInfoSystem().GetStuCardInfoList();//学生卡

			if(Thread.CurrentPrincipal.Identity.Name.ToLower()=="admin")
				return;

			DataSet TeaDept = new RolesSystem().GetRolesDuty(Convert.ToInt32(Thread.CurrentPrincipal.Identity.Name));

			string rowFilter = string.Empty;

			if(!Thread.CurrentPrincipal.IsInRole("园长")
				&&!Thread.CurrentPrincipal.IsInRole("保健"))
			{
				rowFilter = rowFilter + "info_gradeName = '"
					+TeaDept.Tables[0].Rows[0][0].ToString()+"'";
				rowFilter = rowFilter + " and info_className = '"
					+TeaDept.Tables[0].Rows[0][1].ToString()+"'";
			}

			StuView = StuList.Tables[0].DefaultView;
			StuView.RowFilter = rowFilter;

			gridControl1.DataSource = StuView;


			comboBoxEdit_Send_StuGrade.Properties.Items.Clear();
			comboBoxEdit_Send_StuGrade.Properties.Items.AddRange(new object[]{"全部"});
			comboBoxEdit_Send_StuGrade.SelectedItem = "全部";
			foreach(DataRow getGradeList in getStuInfoByCondition.getGradeInfo("","").Tables[0].Rows)
			{
				comboBoxEdit_Send_StuGrade.Properties.Items.AddRange(
					new object[]{getGradeList[1].ToString()});
			}
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
			this.notePanel_DutyDetailsTitle = new DevExpress.Utils.Frames.NotePanel();
			this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
			this.textEdit_Send_StuName = new DevExpress.XtraEditors.TextEdit();
			this.comboBoxEdit_Send_StuClass = new DevExpress.XtraEditors.ComboBoxEdit();
			this.comboBoxEdit_Send_StuGrade = new DevExpress.XtraEditors.ComboBoxEdit();
			this.textEdit_Send_StuNumber = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_Send_StuNumber = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_Send_StuClass = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_Send_StuGrade = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_Send_StuName = new DevExpress.Utils.Frames.NotePanel();
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
			this.simpleButton_EditPhoneNum = new DevExpress.XtraEditors.SimpleButton();
			this.notePanel1 = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel2 = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
			this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
			this.gridControl2 = new DevExpress.XtraGrid.GridControl();
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
			this.groupControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_Send_StuName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Send_StuClass.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Send_StuGrade.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_Send_StuNumber.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
			this.groupControl3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
			this.groupControl4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			this.SuspendLayout();
			// 
			// notePanel_DutyDetailsTitle
			// 
			this.notePanel_DutyDetailsTitle.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel_DutyDetailsTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel_DutyDetailsTitle.ForeColor = System.Drawing.Color.Gray;
			this.notePanel_DutyDetailsTitle.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_DutyDetailsTitle.Location = new System.Drawing.Point(0, 0);
			this.notePanel_DutyDetailsTitle.MaxRows = 5;
			this.notePanel_DutyDetailsTitle.Name = "notePanel_DutyDetailsTitle";
			this.notePanel_DutyDetailsTitle.ParentAutoHeight = true;
			this.notePanel_DutyDetailsTitle.Size = new System.Drawing.Size(584, 23);
			this.notePanel_DutyDetailsTitle.TabIndex = 14;
			this.notePanel_DutyDetailsTitle.TabStop = false;
			this.notePanel_DutyDetailsTitle.Text = "查看编辑号码簿";
			// 
			// groupControl2
			// 
			this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.groupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.DarkOrange;
			this.groupControl2.AppearanceCaption.Options.UseFont = true;
			this.groupControl2.AppearanceCaption.Options.UseForeColor = true;
			this.groupControl2.Controls.Add(this.textEdit_Send_StuName);
			this.groupControl2.Controls.Add(this.comboBoxEdit_Send_StuClass);
			this.groupControl2.Controls.Add(this.comboBoxEdit_Send_StuGrade);
			this.groupControl2.Controls.Add(this.textEdit_Send_StuNumber);
			this.groupControl2.Controls.Add(this.notePanel_Send_StuNumber);
			this.groupControl2.Controls.Add(this.notePanel_Send_StuClass);
			this.groupControl2.Controls.Add(this.notePanel_Send_StuGrade);
			this.groupControl2.Controls.Add(this.notePanel_Send_StuName);
			this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl2.Location = new System.Drawing.Point(0, 23);
			this.groupControl2.Name = "groupControl2";
			this.groupControl2.Size = new System.Drawing.Size(584, 81);
			this.groupControl2.TabIndex = 22;
			this.groupControl2.Text = "查找条件";
			// 
			// textEdit_Send_StuName
			// 
			this.textEdit_Send_StuName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textEdit_Send_StuName.EditValue = "";
			this.textEdit_Send_StuName.Location = new System.Drawing.Point(96, 32);
			this.textEdit_Send_StuName.Name = "textEdit_Send_StuName";
			this.textEdit_Send_StuName.Size = new System.Drawing.Size(56, 23);
			this.textEdit_Send_StuName.TabIndex = 40;
			this.textEdit_Send_StuName.EditValueChanged += new System.EventHandler(this.textEdit_Send_StuName_EditValueChanged);
			// 
			// comboBoxEdit_Send_StuClass
			// 
			this.comboBoxEdit_Send_StuClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxEdit_Send_StuClass.EditValue = "全部";
			this.comboBoxEdit_Send_StuClass.Location = new System.Drawing.Point(494, 32);
			this.comboBoxEdit_Send_StuClass.Name = "comboBoxEdit_Send_StuClass";
			// 
			// comboBoxEdit_Send_StuClass.Properties
			// 
			this.comboBoxEdit_Send_StuClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_Send_StuClass.Properties.Items.AddRange(new object[] {
																					   "全部"});
			this.comboBoxEdit_Send_StuClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_Send_StuClass.Size = new System.Drawing.Size(64, 23);
			this.comboBoxEdit_Send_StuClass.TabIndex = 39;
			this.comboBoxEdit_Send_StuClass.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_Send_StuClass_SelectedIndexChanged);
			// 
			// comboBoxEdit_Send_StuGrade
			// 
			this.comboBoxEdit_Send_StuGrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxEdit_Send_StuGrade.EditValue = "全部";
			this.comboBoxEdit_Send_StuGrade.Location = new System.Drawing.Point(356, 32);
			this.comboBoxEdit_Send_StuGrade.Name = "comboBoxEdit_Send_StuGrade";
			// 
			// comboBoxEdit_Send_StuGrade.Properties
			// 
			this.comboBoxEdit_Send_StuGrade.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_Send_StuGrade.Properties.Items.AddRange(new object[] {
																					   "全部"});
			this.comboBoxEdit_Send_StuGrade.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_Send_StuGrade.Size = new System.Drawing.Size(64, 23);
			this.comboBoxEdit_Send_StuGrade.TabIndex = 38;
			this.comboBoxEdit_Send_StuGrade.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_Send_StuGrade_SelectedIndexChanged);
			// 
			// textEdit_Send_StuNumber
			// 
			this.textEdit_Send_StuNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textEdit_Send_StuNumber.EditValue = "";
			this.textEdit_Send_StuNumber.Location = new System.Drawing.Point(226, 32);
			this.textEdit_Send_StuNumber.Name = "textEdit_Send_StuNumber";
			// 
			// textEdit_Send_StuNumber.Properties
			// 
			this.textEdit_Send_StuNumber.Properties.Mask.EditMask = "d4";
			this.textEdit_Send_StuNumber.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.textEdit_Send_StuNumber.Size = new System.Drawing.Size(56, 23);
			this.textEdit_Send_StuNumber.TabIndex = 37;
			this.textEdit_Send_StuNumber.EditValueChanged += new System.EventHandler(this.textEdit_Send_StuNumber_EditValueChanged);
			// 
			// notePanel_Send_StuNumber
			// 
			this.notePanel_Send_StuNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.notePanel_Send_StuNumber.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_Send_StuNumber.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_Send_StuNumber.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_Send_StuNumber.ForeColor = System.Drawing.Color.Black;
			this.notePanel_Send_StuNumber.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Send_StuNumber.Location = new System.Drawing.Point(157, 32);
			this.notePanel_Send_StuNumber.MaxRows = 5;
			this.notePanel_Send_StuNumber.Name = "notePanel_Send_StuNumber";
			this.notePanel_Send_StuNumber.ParentAutoHeight = true;
			this.notePanel_Send_StuNumber.Size = new System.Drawing.Size(64, 22);
			this.notePanel_Send_StuNumber.TabIndex = 36;
			this.notePanel_Send_StuNumber.TabStop = false;
			this.notePanel_Send_StuNumber.Text = "学  号:";
			// 
			// notePanel_Send_StuClass
			// 
			this.notePanel_Send_StuClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.notePanel_Send_StuClass.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_Send_StuClass.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_Send_StuClass.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_Send_StuClass.ForeColor = System.Drawing.Color.Black;
			this.notePanel_Send_StuClass.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Send_StuClass.Location = new System.Drawing.Point(425, 32);
			this.notePanel_Send_StuClass.MaxRows = 5;
			this.notePanel_Send_StuClass.Name = "notePanel_Send_StuClass";
			this.notePanel_Send_StuClass.ParentAutoHeight = true;
			this.notePanel_Send_StuClass.Size = new System.Drawing.Size(64, 22);
			this.notePanel_Send_StuClass.TabIndex = 35;
			this.notePanel_Send_StuClass.TabStop = false;
			this.notePanel_Send_StuClass.Text = "班  级:";
			// 
			// notePanel_Send_StuGrade
			// 
			this.notePanel_Send_StuGrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.notePanel_Send_StuGrade.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_Send_StuGrade.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_Send_StuGrade.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_Send_StuGrade.ForeColor = System.Drawing.Color.Black;
			this.notePanel_Send_StuGrade.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Send_StuGrade.Location = new System.Drawing.Point(287, 32);
			this.notePanel_Send_StuGrade.MaxRows = 5;
			this.notePanel_Send_StuGrade.Name = "notePanel_Send_StuGrade";
			this.notePanel_Send_StuGrade.ParentAutoHeight = true;
			this.notePanel_Send_StuGrade.Size = new System.Drawing.Size(64, 22);
			this.notePanel_Send_StuGrade.TabIndex = 34;
			this.notePanel_Send_StuGrade.TabStop = false;
			this.notePanel_Send_StuGrade.Text = "年  级:";
			// 
			// notePanel_Send_StuName
			// 
			this.notePanel_Send_StuName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.notePanel_Send_StuName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_Send_StuName.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_Send_StuName.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_Send_StuName.ForeColor = System.Drawing.Color.Black;
			this.notePanel_Send_StuName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Send_StuName.Location = new System.Drawing.Point(27, 32);
			this.notePanel_Send_StuName.MaxRows = 5;
			this.notePanel_Send_StuName.Name = "notePanel_Send_StuName";
			this.notePanel_Send_StuName.ParentAutoHeight = true;
			this.notePanel_Send_StuName.Size = new System.Drawing.Size(64, 22);
			this.notePanel_Send_StuName.TabIndex = 33;
			this.notePanel_Send_StuName.TabStop = false;
			this.notePanel_Send_StuName.Text = "姓  名:";
			// 
			// groupControl1
			// 
			this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.DarkOrange;
			this.groupControl1.AppearanceCaption.Options.UseFont = true;
			this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
			this.groupControl1.Controls.Add(this.groupControl3);
			this.groupControl1.Controls.Add(this.gridControl1);
			this.groupControl1.Controls.Add(this.groupControl4);
			this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl1.Location = new System.Drawing.Point(0, 104);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(584, 384);
			this.groupControl1.TabIndex = 23;
			this.groupControl1.Text = "编辑号码簿";
			// 
			// groupControl3
			// 
			this.groupControl3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupControl3.Controls.Add(this.simpleButton_EditPhoneNum);
			this.groupControl3.Controls.Add(this.notePanel1);
			this.groupControl3.Controls.Add(this.notePanel2);
			this.groupControl3.Controls.Add(this.textEdit1);
			this.groupControl3.Controls.Add(this.textEdit2);
			this.groupControl3.Location = new System.Drawing.Point(232, 24);
			this.groupControl3.Name = "groupControl3";
			this.groupControl3.Size = new System.Drawing.Size(336, 160);
			this.groupControl3.TabIndex = 24;
			this.groupControl3.Text = "对选定学生新增号码";
			// 
			// simpleButton_EditPhoneNum
			// 
			this.simpleButton_EditPhoneNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButton_EditPhoneNum.Location = new System.Drawing.Point(240, 120);
			this.simpleButton_EditPhoneNum.Name = "simpleButton_EditPhoneNum";
			this.simpleButton_EditPhoneNum.Size = new System.Drawing.Size(72, 24);
			this.simpleButton_EditPhoneNum.TabIndex = 22;
			this.simpleButton_EditPhoneNum.Text = "新增";
			this.simpleButton_EditPhoneNum.Click += new System.EventHandler(this.simpleButton_EditPhoneNum_Click);
			// 
			// notePanel1
			// 
			this.notePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.notePanel1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel1.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel1.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel1.ForeColor = System.Drawing.Color.Black;
			this.notePanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel1.Location = new System.Drawing.Point(32, 40);
			this.notePanel1.MaxRows = 5;
			this.notePanel1.Name = "notePanel1";
			this.notePanel1.ParentAutoHeight = true;
			this.notePanel1.Size = new System.Drawing.Size(128, 22);
			this.notePanel1.TabIndex = 34;
			this.notePanel1.TabStop = false;
			this.notePanel1.Text = "持有手机家长姓名:";
			// 
			// notePanel2
			// 
			this.notePanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.notePanel2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel2.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel2.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel2.ForeColor = System.Drawing.Color.Black;
			this.notePanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel2.Location = new System.Drawing.Point(32, 80);
			this.notePanel2.MaxRows = 5;
			this.notePanel2.Name = "notePanel2";
			this.notePanel2.ParentAutoHeight = true;
			this.notePanel2.Size = new System.Drawing.Size(128, 22);
			this.notePanel2.TabIndex = 34;
			this.notePanel2.TabStop = false;
			this.notePanel2.Text = "注册服务手机号码:";
			// 
			// textEdit1
			// 
			this.textEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textEdit1.EditValue = "";
			this.textEdit1.Location = new System.Drawing.Point(168, 40);
			this.textEdit1.Name = "textEdit1";
			this.textEdit1.Size = new System.Drawing.Size(136, 23);
			this.textEdit1.TabIndex = 37;
			// 
			// textEdit2
			// 
			this.textEdit2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textEdit2.EditValue = "";
			this.textEdit2.Location = new System.Drawing.Point(168, 80);
			this.textEdit2.Name = "textEdit2";
			this.textEdit2.Size = new System.Drawing.Size(136, 23);
			this.textEdit2.TabIndex = 37;
			this.textEdit2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textEdit2_KeyPress);
			// 
			// gridControl1
			// 
			this.gridControl1.Dock = System.Windows.Forms.DockStyle.Left;
			// 
			// gridControl1.EmbeddedNavigator
			// 
			this.gridControl1.EmbeddedNavigator.Name = "";
			this.gridControl1.Location = new System.Drawing.Point(3, 18);
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.Size = new System.Drawing.Size(221, 363);
			this.gridControl1.TabIndex = 23;
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
			this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "学号";
			this.gridColumn1.FieldName = "info_stuNumber";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "姓名";
			this.gridColumn2.FieldName = "info_stuName";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "年级";
			this.gridColumn3.FieldName = "info_gradeName";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 2;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "班级";
			this.gridColumn4.FieldName = "info_className";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 3;
			// 
			// gridColumn5
			// 
			this.gridColumn5.Caption = "gridColumn5";
			this.gridColumn5.FieldName = "info_stuID";
			this.gridColumn5.Name = "gridColumn5";
			// 
			// groupControl4
			// 
			this.groupControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupControl4.Controls.Add(this.gridControl2);
			this.groupControl4.Controls.Add(this.simpleButton2);
			this.groupControl4.Location = new System.Drawing.Point(232, 192);
			this.groupControl4.Name = "groupControl4";
			this.groupControl4.Size = new System.Drawing.Size(336, 184);
			this.groupControl4.TabIndex = 24;
			this.groupControl4.Text = "显示选定学生已添加号码";
			// 
			// gridControl2
			// 
			this.gridControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			// 
			// gridControl2.EmbeddedNavigator
			// 
			this.gridControl2.EmbeddedNavigator.Name = "";
			this.gridControl2.Location = new System.Drawing.Point(3, 56);
			this.gridControl2.MainView = this.gridView2;
			this.gridControl2.Name = "gridControl2";
			this.gridControl2.Size = new System.Drawing.Size(346, 128);
			this.gridControl2.TabIndex = 22;
			this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.gridView2});
			// 
			// gridView2
			// 
			this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn6,
																							 this.gridColumn7,
																							 this.gridColumn8});
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
			this.gridColumn6.Caption = "持有手机家长姓名";
			this.gridColumn6.FieldName = "familial_name";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 0;
			// 
			// gridColumn7
			// 
			this.gridColumn7.Caption = "注册手机号码";
			this.gridColumn7.FieldName = "mobilePhone_number";
			this.gridColumn7.Name = "gridColumn7";
			this.gridColumn7.Visible = true;
			this.gridColumn7.VisibleIndex = 1;
			// 
			// gridColumn8
			// 
			this.gridColumn8.Caption = "gridColumn8";
			this.gridColumn8.FieldName = "smsInfo_id";
			this.gridColumn8.Name = "gridColumn8";
			// 
			// simpleButton2
			// 
			this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButton2.Location = new System.Drawing.Point(240, 16);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.Size = new System.Drawing.Size(72, 24);
			this.simpleButton2.TabIndex = 21;
			this.simpleButton2.Text = "删除";
			this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
			// 
			// PhoneNum
			// 
			this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.Appearance.Options.UseBackColor = true;
			this.Controls.Add(this.groupControl1);
			this.Controls.Add(this.groupControl2);
			this.Controls.Add(this.notePanel_DutyDetailsTitle);
			this.Name = "PhoneNum";
			this.Size = new System.Drawing.Size(584, 488);
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
			this.groupControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.textEdit_Send_StuName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Send_StuClass.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Send_StuGrade.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_Send_StuNumber.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
			this.groupControl3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
			this.groupControl4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region load student into
		private void comboBoxEdit_Send_StuGrade_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			comboBoxEdit_Send_StuClass.Properties.Items.Clear();
			comboBoxEdit_Send_StuClass.Properties.Items.AddRange(new object[]{"全部"});
			comboBoxEdit_Send_StuClass.SelectedItem = "全部";
			if(getStuInfoByCondition.getGradeInfo(comboBoxEdit_Send_StuGrade.SelectedItem.ToString(),"").Tables[0].Rows.Count > 0)
			{
				//根据年级选择获取年级编号
				getGradeNumberFromCombo = getStuInfoByCondition.getGradeInfo(
					comboBoxEdit_Send_StuGrade.SelectedItem.ToString(),"").Tables[0].Rows[0][0].ToString();
				foreach(DataRow getClassList in getStuInfoByCondition.getClassInfo("","",
					getGradeNumberFromCombo).Tables[0].Rows)
				{
					comboBoxEdit_Send_StuClass.Properties.Items.AddRange(
						new object[]{getClassList[1].ToString()});
				}
			}

			//根据年级查询所选信息
			if(!comboBoxEdit_Send_StuGrade.SelectedItem.ToString().Equals("全部"))
			{
				SelectStuCardInfo(textEdit_Send_StuName.Text.Trim(),textEdit_Send_StuNumber.Text.Trim(),
					comboBoxEdit_Send_StuGrade.SelectedItem.ToString().Trim(), comboBoxEdit_Send_StuClass
					.SelectedItem.ToString().Trim());
			}
			else
			{
				SelectStuCardInfo(textEdit_Send_StuName.Text.Trim(),textEdit_Send_StuNumber.Text.Trim(),
					string.Empty,comboBoxEdit_Send_StuClass.SelectedItem.ToString().Trim());
			}
		}

		private void comboBoxEdit_Send_StuClass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(!comboBoxEdit_Send_StuClass.SelectedItem.ToString().Equals("全部"))
			{
				SelectStuCardInfo(textEdit_Send_StuName.Text.Trim(),textEdit_Send_StuNumber.Text.Trim(),
					comboBoxEdit_Send_StuGrade.SelectedItem.ToString().Trim(), comboBoxEdit_Send_StuClass
					.SelectedItem.ToString().Trim());
			}
			else
			{
				SelectStuCardInfo(textEdit_Send_StuName.Text.Trim(),textEdit_Send_StuNumber.Text.Trim(),
					comboBoxEdit_Send_StuGrade.SelectedItem.ToString().Trim(),string.Empty);
			}
		}

		private void textEdit_Send_StuName_EditValueChanged(object sender, System.EventArgs e)
		{
			if(StuView!=null)
			{
				SelectStuCardInfo(textEdit_Send_StuName.Text.Trim(),textEdit_Send_StuNumber.Text.Trim(),
					comboBoxEdit_Send_StuGrade.SelectedItem.ToString().Trim(), comboBoxEdit_Send_StuClass
					.SelectedItem.ToString().Trim());
			}
		}

		private void textEdit_Send_StuNumber_EditValueChanged(object sender, System.EventArgs e)
		{
			if(StuView!=null)
			{
				SelectStuCardInfo(textEdit_Send_StuName.Text.Trim(),textEdit_Send_StuNumber.Text.Trim(),
					comboBoxEdit_Send_StuGrade.SelectedItem.ToString().Trim(), comboBoxEdit_Send_StuClass
					.SelectedItem.ToString().Trim());
			}
		}

		//过滤DataView
		private void SelectStuCardInfo(string name,string id,string grade,string className)
		{
			string rowFilter = string.Empty;
			
			DataSet TeaDept = new RolesSystem().GetRolesDuty(Convert.ToInt32(Thread.CurrentPrincipal.Identity.Name));

			if(!Thread.CurrentPrincipal.IsInRole("园长")
				&&!Thread.CurrentPrincipal.IsInRole("保健"))
			{
				rowFilter = "info_stuName like '%"+name+"%'";
				rowFilter = rowFilter + " and info_gradeName = '"
					+TeaDept.Tables[0].Rows[0][0].ToString()+"'";

				rowFilter = rowFilter + " and info_className = '"
					+TeaDept.Tables[0].Rows[0][1].ToString()+"'";

				if(id.Length==4)
				{
					rowFilter += " and info_stuNumber="+id; 
				}
			}
			else
			{
				rowFilter = "info_stuName like '%"+name+"%'";

				if(grade.Equals("全部"))
				{
					rowFilter = rowFilter + " and info_gradeName like '%'";
				}
				else
				{
					rowFilter = rowFilter + " and info_gradeName like '%"+
						grade+"%'";
				}

				if(className.Equals("全部"))
				{
					rowFilter = rowFilter + " and info_className like '%'";
				}
				else
				{
					rowFilter = rowFilter + " and info_className like '%"+className+"%'";
				}

				if(id.Length==4)
				{
					rowFilter += " and info_stuNumber="+id; 
				}
			}

			StuView.RowFilter = rowFilter;
			gridControl1.DataSource = StuView;

			if(gridView1.RowCount==0)
				return;
			
			string selectedStuID = (gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["info_stuID"]).ToString();
			DisplayStuPhoneNum(selectedStuID);
		}

		private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			string selectedStuID = (gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["info_stuID"]).ToString();
			DisplayStuPhoneNum(selectedStuID);
		}

		private void DisplayStuPhoneNum(string stuID)
		{
			DataSet stuPhoneNum = new SMSInfoSystem().GetStuPhoneNum(stuID);
			gridControl2.DataSource = stuPhoneNum.Tables[0];
		}
		#endregion

		#region add new Phone number
		private void simpleButton_EditPhoneNum_Click(object sender, System.EventArgs e)
		{
			if(gridView1.GetSelectedRows().Length==0)
			{
				MessageBox.Show("请先选定一个要添加的学生.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}
		
			if(textEdit1.Text.Trim()==string.Empty||
				textEdit2.Text.Trim()==string.Empty
				||textEdit2.Text.Trim().Length!=11)
			{
				MessageBox.Show("家长姓名和号码必须填写.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}

			string stuid = gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["info_stuID"].ToString();
			string familialName = textEdit1.Text.Trim();
			string mobilePhoneNum = textEdit2.Text.Trim();
			string stuGrade = gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["info_gradeName"].ToString();
			string stuClass = gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["info_className"].ToString();

			if(new SMSInfoSystem().InsertSMSPhoneNum(stuid,familialName,mobilePhoneNum,
				stuGrade,stuClass)>0)
			{
				DisplayStuPhoneNum(stuid);
				textEdit1.Text = string.Empty;
				textEdit1.Text = string.Empty;
				MessageBox.Show("插入成功.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		#endregion

		#region delete Phone number
		private void simpleButton2_Click(object sender, System.EventArgs e)
		{
			if(gridView2.RowCount==0)
			{
				MessageBox.Show("请先选定一个要删除的学生号码.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}

			int smsInfo_id = Convert.ToInt32(gridView2.GetDataRow(gridView2.GetSelectedRows()[0])["smsInfo_id"]);

			if(new SMSInfoSystem().DeleteSMSPhoneNum(smsInfo_id)>0)
			{
				gridView2.DeleteRow(gridView2.GetSelectedRows()[0]);
				MessageBox.Show("删除成功.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		#endregion

		#region validate the mobile phone number
		private void textEdit2_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(!Char.IsDigit(e.KeyChar)&&!Char.IsControl(e.KeyChar))
			{
				MessageBox.Show("请输入正确的11位手机号码!","出错了!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				e.Handled = true;
			}

			if(textEdit2.Text.Trim().Length>10)
			{
				MessageBox.Show("请输入正确的11位手机号码!","出错了!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				e.Handled = true;
			}
		}
		#endregion

	}
}

