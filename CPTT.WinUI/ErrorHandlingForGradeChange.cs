using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data;
using CPTT.BusinessFacade;

namespace CPTT.WinUI
{
	/// <summary>
	/// Summary description for ErrorHandlingForGradeChange.
	/// </summary>
	public class ErrorHandlingForGradeChange : DevExpress.XtraEditors.XtraForm
	{
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.Utils.Frames.NotePanel notePanel3;
		private DevExpress.Utils.Frames.NotePanel notePanel2;
		private DevExpress.Utils.Frames.NotePanel notePanel1;
		private DevExpress.Utils.Frames.NotePanel notePanel_ErrorSrc;
		private DevExpress.Utils.Frames.NotePanel notePanel4;
		private DevExpress.XtraEditors.TextEdit tetClass;
		private DevExpress.XtraEditors.TextEdit tetGrade;
		private DevExpress.XtraEditors.TextEdit tetNumber;
		private DevExpress.XtraEditors.TextEdit tetName;
		private DevExpress.XtraEditors.TextEdit tetType;
		private DevExpress.XtraEditors.SimpleButton btnExit;
		private DevExpress.XtraEditors.SimpleButton btnSubmit;
		private DevExpress.XtraEditors.SimpleButton btmSearch;

		private string _name = string.Empty;
		private string _grade = string.Empty;
		private string _class = string.Empty;
		private string _type = string.Empty;
		private Hashtable htUpdateInfo = new Hashtable();
		private DevExpress.Utils.Frames.NotePanel notePanel_Name;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ErrorHandlingForGradeChange(string getName,string getGrade,string getClass,string getType,int errorCode,string errorMsg)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			_name = getName;
			_grade = getGrade;
			_class = getClass;
			_type = getType;

			tetName.Text = _name;
			tetGrade.Text = _grade;
			tetClass.Text = _class;
			tetType.Text = _type;

			switch ( errorCode )
			{
				case 0: notePanel1.BackColor2 = Color.Red;
					break;
				case 1: notePanel2.BackColor2 = Color.Red;
					break;
				case 2: notePanel3.BackColor2 = Color.Red;
					break;
				case 3: notePanel_Name.BackColor2 = Color.Red;
					break;
				default:
					break;
			}

			notePanel_ErrorSrc.Text = errorMsg;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ErrorHandlingForGradeChange));
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.btmSearch = new DevExpress.XtraEditors.SimpleButton();
			this.btnSubmit = new DevExpress.XtraEditors.SimpleButton();
			this.btnExit = new DevExpress.XtraEditors.SimpleButton();
			this.tetType = new DevExpress.XtraEditors.TextEdit();
			this.notePanel4 = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_ErrorSrc = new DevExpress.Utils.Frames.NotePanel();
			this.tetClass = new DevExpress.XtraEditors.TextEdit();
			this.notePanel3 = new DevExpress.Utils.Frames.NotePanel();
			this.tetGrade = new DevExpress.XtraEditors.TextEdit();
			this.notePanel2 = new DevExpress.Utils.Frames.NotePanel();
			this.tetNumber = new DevExpress.XtraEditors.TextEdit();
			this.notePanel1 = new DevExpress.Utils.Frames.NotePanel();
			this.tetName = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_Name = new DevExpress.Utils.Frames.NotePanel();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tetType.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tetClass.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tetGrade.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tetNumber.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tetName.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// groupControl1
			// 
			this.groupControl1.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.groupControl1.Appearance.Options.UseBackColor = true;
			this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl1.AppearanceCaption.Options.UseFont = true;
			this.groupControl1.Controls.Add(this.btmSearch);
			this.groupControl1.Controls.Add(this.btnSubmit);
			this.groupControl1.Controls.Add(this.btnExit);
			this.groupControl1.Controls.Add(this.tetType);
			this.groupControl1.Controls.Add(this.notePanel4);
			this.groupControl1.Controls.Add(this.notePanel_ErrorSrc);
			this.groupControl1.Controls.Add(this.tetClass);
			this.groupControl1.Controls.Add(this.notePanel3);
			this.groupControl1.Controls.Add(this.tetGrade);
			this.groupControl1.Controls.Add(this.notePanel2);
			this.groupControl1.Controls.Add(this.tetNumber);
			this.groupControl1.Controls.Add(this.notePanel1);
			this.groupControl1.Controls.Add(this.tetName);
			this.groupControl1.Controls.Add(this.notePanel_Name);
			this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl1.Location = new System.Drawing.Point(0, 0);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(472, 341);
			this.groupControl1.TabIndex = 0;
			this.groupControl1.Text = "调试面版";
			// 
			// btmSearch
			// 
			this.btmSearch.Location = new System.Drawing.Point(344, 96);
			this.btmSearch.Name = "btmSearch";
			this.btmSearch.Size = new System.Drawing.Size(72, 23);
			this.btmSearch.TabIndex = 60;
			this.btmSearch.Text = "搜索";
			this.btmSearch.Click += new System.EventHandler(this.btmSearch_Click);
			// 
			// btnSubmit
			// 
			this.btnSubmit.Location = new System.Drawing.Point(144, 240);
			this.btnSubmit.Name = "btnSubmit";
			this.btnSubmit.Size = new System.Drawing.Size(72, 23);
			this.btnSubmit.TabIndex = 59;
			this.btnSubmit.Text = "确定";
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(232, 240);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(72, 23);
			this.btnExit.TabIndex = 58;
			this.btnExit.Text = "退出";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// tetType
			// 
			this.tetType.EditValue = "";
			this.tetType.Location = new System.Drawing.Point(184, 192);
			this.tetType.Name = "tetType";
			this.tetType.Size = new System.Drawing.Size(152, 23);
			this.tetType.TabIndex = 57;
			// 
			// notePanel4
			// 
			this.notePanel4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel4.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel4.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel4.ForeColor = System.Drawing.Color.Black;
			this.notePanel4.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel4.Location = new System.Drawing.Point(96, 96);
			this.notePanel4.MaxRows = 5;
			this.notePanel4.Name = "notePanel4";
			this.notePanel4.ParentAutoHeight = true;
			this.notePanel4.Size = new System.Drawing.Size(80, 22);
			this.notePanel4.TabIndex = 56;
			this.notePanel4.TabStop = false;
			this.notePanel4.Text = "  学  号：";
			// 
			// notePanel_ErrorSrc
			// 
			this.notePanel_ErrorSrc.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel_ErrorSrc.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel_ErrorSrc.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel_ErrorSrc.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_ErrorSrc.Location = new System.Drawing.Point(3, 18);
			this.notePanel_ErrorSrc.MaxRows = 5;
			this.notePanel_ErrorSrc.Name = "notePanel_ErrorSrc";
			this.notePanel_ErrorSrc.ParentAutoHeight = true;
			this.notePanel_ErrorSrc.Size = new System.Drawing.Size(466, 23);
			this.notePanel_ErrorSrc.TabIndex = 53;
			this.notePanel_ErrorSrc.TabStop = false;
			this.notePanel_ErrorSrc.Text = "错误信息:";
			// 
			// tetClass
			// 
			this.tetClass.EditValue = "";
			this.tetClass.Location = new System.Drawing.Point(184, 159);
			this.tetClass.Name = "tetClass";
			this.tetClass.Size = new System.Drawing.Size(152, 23);
			this.tetClass.TabIndex = 52;
			// 
			// notePanel3
			// 
			this.notePanel3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel3.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel3.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel3.ForeColor = System.Drawing.Color.Black;
			this.notePanel3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel3.Location = new System.Drawing.Point(96, 192);
			this.notePanel3.MaxRows = 5;
			this.notePanel3.Name = "notePanel3";
			this.notePanel3.ParentAutoHeight = true;
			this.notePanel3.Size = new System.Drawing.Size(80, 22);
			this.notePanel3.TabIndex = 51;
			this.notePanel3.TabStop = false;
			this.notePanel3.Text = "  类  型：";
			// 
			// tetGrade
			// 
			this.tetGrade.EditValue = "";
			this.tetGrade.Location = new System.Drawing.Point(184, 127);
			this.tetGrade.Name = "tetGrade";
			this.tetGrade.Size = new System.Drawing.Size(152, 23);
			this.tetGrade.TabIndex = 50;
			// 
			// notePanel2
			// 
			this.notePanel2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel2.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel2.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel2.ForeColor = System.Drawing.Color.Black;
			this.notePanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel2.Location = new System.Drawing.Point(96, 160);
			this.notePanel2.MaxRows = 5;
			this.notePanel2.Name = "notePanel2";
			this.notePanel2.ParentAutoHeight = true;
			this.notePanel2.Size = new System.Drawing.Size(80, 22);
			this.notePanel2.TabIndex = 49;
			this.notePanel2.TabStop = false;
			this.notePanel2.Text = "  班  级：";
			// 
			// tetNumber
			// 
			this.tetNumber.EditValue = "";
			this.tetNumber.Location = new System.Drawing.Point(184, 95);
			this.tetNumber.Name = "tetNumber";
			this.tetNumber.Size = new System.Drawing.Size(152, 23);
			this.tetNumber.TabIndex = 48;
			// 
			// notePanel1
			// 
			this.notePanel1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel1.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel1.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel1.ForeColor = System.Drawing.Color.Black;
			this.notePanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel1.Location = new System.Drawing.Point(96, 128);
			this.notePanel1.MaxRows = 5;
			this.notePanel1.Name = "notePanel1";
			this.notePanel1.ParentAutoHeight = true;
			this.notePanel1.Size = new System.Drawing.Size(80, 22);
			this.notePanel1.TabIndex = 47;
			this.notePanel1.TabStop = false;
			this.notePanel1.Text = "  年  级：";
			// 
			// tetName
			// 
			this.tetName.EditValue = "";
			this.tetName.Location = new System.Drawing.Point(184, 63);
			this.tetName.Name = "tetName";
			this.tetName.Size = new System.Drawing.Size(152, 23);
			this.tetName.TabIndex = 46;
			// 
			// notePanel_Name
			// 
			this.notePanel_Name.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_Name.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_Name.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_Name.ForeColor = System.Drawing.Color.Black;
			this.notePanel_Name.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Name.Location = new System.Drawing.Point(96, 63);
			this.notePanel_Name.MaxRows = 5;
			this.notePanel_Name.Name = "notePanel_Name";
			this.notePanel_Name.ParentAutoHeight = true;
			this.notePanel_Name.Size = new System.Drawing.Size(80, 22);
			this.notePanel_Name.TabIndex = 45;
			this.notePanel_Name.TabStop = false;
			this.notePanel_Name.Text = "  姓  名：";
			// 
			// ErrorHandlingForGradeChange
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(472, 341);
			this.Controls.Add(this.groupControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ErrorHandlingForGradeChange";
			this.Text = "年班升级错误修正";
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tetType.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tetClass.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tetGrade.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tetNumber.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tetName.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btmSearch_Click(object sender, System.EventArgs e)
		{
			DataTable dtStuName = new OptionSystem().GetStuNameByNumber(tetNumber.Text);

			if ( dtStuName != null )
			{
				if ( dtStuName.Rows.Count > 0 ) tetName.Text = dtStuName.Rows[0]["info_stuName"].ToString();
				else MessageBox.Show("该学号学生不存在！");
			}
		}

		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			htUpdateInfo.Add("name",tetName.Text);
			htUpdateInfo.Add("grade",tetGrade.Text);
			htUpdateInfo.Add("class",tetClass.Text);
			htUpdateInfo.Add("type",tetType.Text);

			this.Close();
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			htUpdateInfo.Add("name",tetName.Text);
			htUpdateInfo.Add("grade",tetGrade.Text);
			htUpdateInfo.Add("class",tetClass.Text);
			htUpdateInfo.Add("type",tetType.Text);

			this.Close();
		}

		public Hashtable UpdateInfo
		{
			get 
			{
				return htUpdateInfo;
			}
		}
	}
}

