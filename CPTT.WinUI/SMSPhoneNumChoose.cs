using System;
using System.Drawing;
using System.Data;
using System.Threading;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using CPTT.BusinessFacade;

namespace CPTT.WinUI
{
	/// <summary>
	/// Summary description for SMSPhoneNumChoose.
	/// </summary>
	public class SMSPhoneNumChoose : DevExpress.XtraEditors.XtraForm
	{
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.XtraEditors.TextEdit textEdit_Send_StuName;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Send_StuClass;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Send_StuGrade;
		private DevExpress.XtraEditors.TextEdit textEdit_Send_StuNumber;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_StuNumber;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_StuClass;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_StuGrade;
		private DevExpress.Utils.Frames.NotePanel notePanel_Send_StuName;
		private DevExpress.XtraEditors.GroupControl groupControl2;
		private DevExpress.XtraGrid.GridControl gridControl2;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraEditors.SimpleButton simpleButton_EditPhoneNum;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private GetStuInfoByCondition getStuInfoByCondition;
		private string getGradeNumberFromCombo = "0";
		private DataSet PhoneNum;
		private DataView PhoneNumView;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		public string chosenPhoneNum = string.Empty;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SMSPhoneNumChoose()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			DataSet TeaDept = new RolesSystem().GetRolesDuty(Convert.ToInt32(Thread.CurrentPrincipal.Identity.Name));

			PhoneNum = new SMSInfoSystem().GetAllStuPhoneNum();//学生卡
			PhoneNumView = PhoneNum.Tables[0].DefaultView;
			
			string rowFilter = string.Empty;

			if(Thread.CurrentPrincipal.Identity.Name.ToLower()=="admin")
				return;

			if(!Thread.CurrentPrincipal.IsInRole("园长")
				&&!Thread.CurrentPrincipal.IsInRole("保健"))
			{
				rowFilter = rowFilter + "stu_grade = '"
					+TeaDept.Tables[0].Rows[0][0].ToString()+"'";
				rowFilter = rowFilter + " and stu_class = '"
					+TeaDept.Tables[0].Rows[0][1].ToString()+"'";
				
			}
			PhoneNumView.RowFilter = rowFilter;
			gridControl2.DataSource = PhoneNumView;
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.textEdit_Send_StuName = new DevExpress.XtraEditors.TextEdit();
			this.comboBoxEdit_Send_StuClass = new DevExpress.XtraEditors.ComboBoxEdit();
			this.comboBoxEdit_Send_StuGrade = new DevExpress.XtraEditors.ComboBoxEdit();
			this.textEdit_Send_StuNumber = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_Send_StuNumber = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_Send_StuClass = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_Send_StuGrade = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_Send_StuName = new DevExpress.Utils.Frames.NotePanel();
			this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
			this.simpleButton_EditPhoneNum = new DevExpress.XtraEditors.SimpleButton();
			this.gridControl2 = new DevExpress.XtraGrid.GridControl();
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_Send_StuName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Send_StuClass.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Send_StuGrade.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_Send_StuNumber.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
			this.groupControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			this.SuspendLayout();
			// 
			// groupControl1
			// 
			this.groupControl1.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.groupControl1.Appearance.Options.UseBackColor = true;
			this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.DarkOrange;
			this.groupControl1.AppearanceCaption.Options.UseFont = true;
			this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
			this.groupControl1.Controls.Add(this.textEdit_Send_StuName);
			this.groupControl1.Controls.Add(this.comboBoxEdit_Send_StuClass);
			this.groupControl1.Controls.Add(this.comboBoxEdit_Send_StuGrade);
			this.groupControl1.Controls.Add(this.textEdit_Send_StuNumber);
			this.groupControl1.Controls.Add(this.notePanel_Send_StuNumber);
			this.groupControl1.Controls.Add(this.notePanel_Send_StuClass);
			this.groupControl1.Controls.Add(this.notePanel_Send_StuGrade);
			this.groupControl1.Controls.Add(this.notePanel_Send_StuName);
			this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl1.Location = new System.Drawing.Point(0, 0);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(432, 100);
			this.groupControl1.TabIndex = 0;
			this.groupControl1.Text = "请输入检索号码条件";
			// 
			// textEdit_Send_StuName
			// 
			this.textEdit_Send_StuName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textEdit_Send_StuName.EditValue = "";
			this.textEdit_Send_StuName.Location = new System.Drawing.Point(140, 23);
			this.textEdit_Send_StuName.Name = "textEdit_Send_StuName";
			this.textEdit_Send_StuName.Size = new System.Drawing.Size(64, 23);
			this.textEdit_Send_StuName.TabIndex = 48;
			this.textEdit_Send_StuName.EditValueChanged += new System.EventHandler(this.textEdit_Send_StuName_EditValueChanged);
			// 
			// comboBoxEdit_Send_StuClass
			// 
			this.comboBoxEdit_Send_StuClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxEdit_Send_StuClass.EditValue = "全部";
			this.comboBoxEdit_Send_StuClass.Location = new System.Drawing.Point(300, 55);
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
			this.comboBoxEdit_Send_StuClass.TabIndex = 47;
			this.comboBoxEdit_Send_StuClass.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_Send_StuClass_SelectedIndexChanged);
			// 
			// comboBoxEdit_Send_StuGrade
			// 
			this.comboBoxEdit_Send_StuGrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxEdit_Send_StuGrade.EditValue = "全部";
			this.comboBoxEdit_Send_StuGrade.Location = new System.Drawing.Point(140, 55);
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
			this.comboBoxEdit_Send_StuGrade.TabIndex = 46;
			this.comboBoxEdit_Send_StuGrade.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_Send_StuGrade_SelectedIndexChanged);
			// 
			// textEdit_Send_StuNumber
			// 
			this.textEdit_Send_StuNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textEdit_Send_StuNumber.EditValue = "";
			this.textEdit_Send_StuNumber.Location = new System.Drawing.Point(300, 23);
			this.textEdit_Send_StuNumber.Name = "textEdit_Send_StuNumber";
			// 
			// textEdit_Send_StuNumber.Properties
			// 
			this.textEdit_Send_StuNumber.Properties.Mask.EditMask = "d4";
			this.textEdit_Send_StuNumber.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.textEdit_Send_StuNumber.Size = new System.Drawing.Size(64, 23);
			this.textEdit_Send_StuNumber.TabIndex = 45;
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
			this.notePanel_Send_StuNumber.Location = new System.Drawing.Point(228, 23);
			this.notePanel_Send_StuNumber.MaxRows = 5;
			this.notePanel_Send_StuNumber.Name = "notePanel_Send_StuNumber";
			this.notePanel_Send_StuNumber.ParentAutoHeight = true;
			this.notePanel_Send_StuNumber.Size = new System.Drawing.Size(64, 22);
			this.notePanel_Send_StuNumber.TabIndex = 44;
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
			this.notePanel_Send_StuClass.Location = new System.Drawing.Point(228, 55);
			this.notePanel_Send_StuClass.MaxRows = 5;
			this.notePanel_Send_StuClass.Name = "notePanel_Send_StuClass";
			this.notePanel_Send_StuClass.ParentAutoHeight = true;
			this.notePanel_Send_StuClass.Size = new System.Drawing.Size(64, 22);
			this.notePanel_Send_StuClass.TabIndex = 43;
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
			this.notePanel_Send_StuGrade.Location = new System.Drawing.Point(68, 55);
			this.notePanel_Send_StuGrade.MaxRows = 5;
			this.notePanel_Send_StuGrade.Name = "notePanel_Send_StuGrade";
			this.notePanel_Send_StuGrade.ParentAutoHeight = true;
			this.notePanel_Send_StuGrade.Size = new System.Drawing.Size(64, 22);
			this.notePanel_Send_StuGrade.TabIndex = 42;
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
			this.notePanel_Send_StuName.Location = new System.Drawing.Point(68, 23);
			this.notePanel_Send_StuName.MaxRows = 5;
			this.notePanel_Send_StuName.Name = "notePanel_Send_StuName";
			this.notePanel_Send_StuName.ParentAutoHeight = true;
			this.notePanel_Send_StuName.Size = new System.Drawing.Size(64, 22);
			this.notePanel_Send_StuName.TabIndex = 41;
			this.notePanel_Send_StuName.TabStop = false;
			this.notePanel_Send_StuName.Text = "姓  名:";
			// 
			// groupControl2
			// 
			this.groupControl2.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.groupControl2.Appearance.Options.UseBackColor = true;
			this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.groupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.DarkOrange;
			this.groupControl2.AppearanceCaption.Options.UseFont = true;
			this.groupControl2.AppearanceCaption.Options.UseForeColor = true;
			this.groupControl2.Controls.Add(this.simpleButton_EditPhoneNum);
			this.groupControl2.Controls.Add(this.gridControl2);
			this.groupControl2.Controls.Add(this.simpleButton1);
			this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl2.Location = new System.Drawing.Point(0, 100);
			this.groupControl2.Name = "groupControl2";
			this.groupControl2.Size = new System.Drawing.Size(432, 193);
			this.groupControl2.TabIndex = 1;
			this.groupControl2.Text = "选择要发送的号码";
			// 
			// simpleButton_EditPhoneNum
			// 
			this.simpleButton_EditPhoneNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButton_EditPhoneNum.Location = new System.Drawing.Point(128, 24);
			this.simpleButton_EditPhoneNum.Name = "simpleButton_EditPhoneNum";
			this.simpleButton_EditPhoneNum.Size = new System.Drawing.Size(72, 24);
			this.simpleButton_EditPhoneNum.TabIndex = 24;
			this.simpleButton_EditPhoneNum.Text = "全选";
			this.simpleButton_EditPhoneNum.Click += new System.EventHandler(this.simpleButton_EditPhoneNum_Click);
			// 
			// gridControl2
			// 
			this.gridControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
			// 
			// gridControl2.EmbeddedNavigator
			// 
			this.gridControl2.EmbeddedNavigator.Name = "";
			this.gridControl2.Location = new System.Drawing.Point(3, 54);
			this.gridControl2.MainView = this.gridView2;
			this.gridControl2.Name = "gridControl2";
			this.gridControl2.Size = new System.Drawing.Size(426, 136);
			this.gridControl2.TabIndex = 23;
			this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.gridView2});
			// 
			// gridView2
			// 
			this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn1,
																							 this.gridColumn2,
																							 this.gridColumn3,
																							 this.gridColumn4,
																							 this.gridColumn5,
																							 this.gridColumn6});
			this.gridView2.GridControl = this.gridControl2;
			this.gridView2.Name = "gridView2";
			this.gridView2.OptionsBehavior.Editable = false;
			this.gridView2.OptionsCustomization.AllowFilter = false;
			this.gridView2.OptionsCustomization.AllowGroup = false;
			this.gridView2.OptionsView.ShowFilterPanel = false;
			this.gridView2.OptionsView.ShowFooter = true;
			this.gridView2.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "学号";
			this.gridColumn1.FieldName = "info_stuNumber";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			this.gridColumn1.Width = 43;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "姓名";
			this.gridColumn2.FieldName = "info_stuName";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			this.gridColumn2.Width = 44;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "年级";
			this.gridColumn3.FieldName = "stu_grade";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 2;
			this.gridColumn3.Width = 42;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "班级";
			this.gridColumn4.FieldName = "stu_class";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 3;
			this.gridColumn4.Width = 41;
			// 
			// gridColumn5
			// 
			this.gridColumn5.Caption = "持有手机家长姓名";
			this.gridColumn5.FieldName = "familial_name";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.Visible = true;
			this.gridColumn5.VisibleIndex = 4;
			this.gridColumn5.Width = 111;
			// 
			// gridColumn6
			// 
			this.gridColumn6.Caption = "手机号码";
			this.gridColumn6.FieldName = "mobilePhone_number";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 5;
			this.gridColumn6.Width = 128;
			// 
			// simpleButton1
			// 
			this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButton1.Location = new System.Drawing.Point(232, 24);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new System.Drawing.Size(72, 24);
			this.simpleButton1.TabIndex = 24;
			this.simpleButton1.Text = "单选";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// SMSPhoneNumChoose
			// 
			this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(432, 293);
			this.Controls.Add(this.groupControl2);
			this.Controls.Add(this.groupControl1);
			this.Name = "SMSPhoneNumChoose";
			this.ShowInTaskbar = false;
			this.Text = "选择要发送短信的手机号码";
			this.Load += new System.EventHandler(this.SMSPhoneNumChoose_Load);
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.textEdit_Send_StuName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Send_StuClass.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Send_StuGrade.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_Send_StuNumber.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
			this.groupControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Initial Data Load
		private void SMSPhoneNumChoose_Load(object sender, System.EventArgs e)
		{
			getStuInfoByCondition = new GetStuInfoByCondition();

			PhoneNum = new SMSInfoSystem().GetAllStuPhoneNum();//学生卡
			PhoneNumView = PhoneNum.Tables[0].DefaultView;

			gridControl2.DataSource = PhoneNumView;

			comboBoxEdit_Send_StuGrade.Properties.Items.Clear();
			comboBoxEdit_Send_StuGrade.Properties.Items.AddRange(new object[]{"全部"});
			comboBoxEdit_Send_StuGrade.SelectedItem = "全部";
			foreach(DataRow getGradeList in getStuInfoByCondition.getGradeInfo("","").Tables[0].Rows)
			{
				comboBoxEdit_Send_StuGrade.Properties.Items.AddRange(
					new object[]{getGradeList[1].ToString()});
			}

		}
		#endregion

		#region filtrate the data
		private void textEdit_Send_StuName_EditValueChanged(object sender, System.EventArgs e)
		{
			if(PhoneNumView!=null)
			{
				SelectPhoneInfo(textEdit_Send_StuName.Text.Trim(),textEdit_Send_StuNumber.Text.Trim(),
					comboBoxEdit_Send_StuGrade.SelectedItem.ToString().Trim(), comboBoxEdit_Send_StuClass
					.SelectedItem.ToString().Trim());
			}
		}

		private void textEdit_Send_StuNumber_EditValueChanged(object sender, System.EventArgs e)
		{
			if(PhoneNumView!=null)
			{
				SelectPhoneInfo(textEdit_Send_StuName.Text.Trim(),textEdit_Send_StuNumber.Text.Trim(),
					comboBoxEdit_Send_StuGrade.SelectedItem.ToString().Trim(), comboBoxEdit_Send_StuClass
					.SelectedItem.ToString().Trim());
			}
		}

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
				SelectPhoneInfo(textEdit_Send_StuName.Text.Trim(),textEdit_Send_StuNumber.Text.Trim(),
					comboBoxEdit_Send_StuGrade.SelectedItem.ToString().Trim(), comboBoxEdit_Send_StuClass
					.SelectedItem.ToString().Trim());
			}
			else
			{
				SelectPhoneInfo(textEdit_Send_StuName.Text.Trim(),textEdit_Send_StuNumber.Text.Trim(),
					string.Empty,comboBoxEdit_Send_StuClass.SelectedItem.ToString().Trim());
			}
		}

		private void comboBoxEdit_Send_StuClass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(!comboBoxEdit_Send_StuClass.SelectedItem.ToString().Equals("全部"))
			{
				SelectPhoneInfo(textEdit_Send_StuName.Text.Trim(),textEdit_Send_StuNumber.Text.Trim(),
					comboBoxEdit_Send_StuGrade.SelectedItem.ToString().Trim(), comboBoxEdit_Send_StuClass
					.SelectedItem.ToString().Trim());
			}
			else
			{
				SelectPhoneInfo(textEdit_Send_StuName.Text.Trim(),textEdit_Send_StuNumber.Text.Trim(),
					comboBoxEdit_Send_StuGrade.SelectedItem.ToString().Trim(),string.Empty);
			}
		}

		private void SelectPhoneInfo(string name,string id,string grade,string className)
		{
			DataSet TeaDept = new RolesSystem().GetRolesDuty(Convert.ToInt32(Thread.CurrentPrincipal.Identity.Name));

			string rowFilter = string.Empty;
			
			if(!Thread.CurrentPrincipal.IsInRole("园长")
				&&!Thread.CurrentPrincipal.IsInRole("保健"))
			{
				rowFilter = "info_stuName like '%"+name+"%'";

				rowFilter = rowFilter + " and stu_grade = '"
					+TeaDept.Tables[0].Rows[0][0].ToString()+"'";
				rowFilter = rowFilter + " and stu_class = '"
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
					rowFilter = rowFilter + " and stu_grade like '%'";
				}
				else
				{
					rowFilter = rowFilter + " and stu_grade like '%"+
						grade+"%'";
				}

				if(className.Equals("全部"))
				{
					rowFilter = rowFilter + " and stu_class like '%'";
				}
				else
				{
					rowFilter = rowFilter + " and stu_class like '%"+className+"%'";
				}

				if(id.Length==4)
				{
					rowFilter += " and info_stuNumber="+id; 
				}
			}

			PhoneNumView.RowFilter = rowFilter;
			gridControl2.DataSource = PhoneNumView;

			if(gridView2.RowCount==0)
				return;
		}
		#endregion

		#region choose the phone number
		//multi
		private void simpleButton_EditPhoneNum_Click(object sender, System.EventArgs e)
		{
			chosenPhoneNum = string.Empty;

			if(gridView2.RowCount!=0)
			{
				for(int i=0;i<gridView2.RowCount;i++)
				{
					chosenPhoneNum += gridView2.GetDataRow(i)["mobilePhone_number"].ToString();
					chosenPhoneNum += ",";
				}
			}
			this.Close();
		}

		//single
		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			chosenPhoneNum = string.Empty;

			if(gridView2.RowCount!=0)
			{
				chosenPhoneNum = gridView2.GetDataRow(
					gridView2.GetSelectedRows()[0])["mobilePhone_number"].ToString();
			}
			this.Close();
		}
		#endregion
	}
}

