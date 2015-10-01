using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CPTT.WinUI
{
	/// <summary>
	/// Summary description for DebugErrors.
	/// </summary>
	public class DebugErrors : DevExpress.XtraEditors.XtraForm
	{
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.Utils.Frames.NotePanel notePanel_ErrorMsg;
		private DevExpress.XtraEditors.TextEdit textEdit_ErrorMsg;
		private DevExpress.Utils.Frames.NotePanel notePanel_ErrorSrc;
		private DevExpress.XtraEditors.SimpleButton simpleButton_Confirm;
		private DevExpress.XtraEditors.SimpleButton simpleButton_Close;
		private string errContent;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DebugErrors(string errTitle,string errMsg)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			notePanel_ErrorSrc.Text += errTitle;
			notePanel_ErrorMsg.Text = errMsg;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebugErrors));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton_Close = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_Confirm = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit_ErrorMsg = new DevExpress.XtraEditors.TextEdit();
            this.notePanel_ErrorMsg = new DevExpress.Utils.Frames.NotePanel();
            this.notePanel_ErrorSrc = new DevExpress.Utils.Frames.NotePanel();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_ErrorMsg.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.simpleButton_Close);
            this.groupControl1.Controls.Add(this.simpleButton_Confirm);
            this.groupControl1.Controls.Add(this.textEdit_ErrorMsg);
            this.groupControl1.Controls.Add(this.notePanel_ErrorMsg);
            this.groupControl1.Controls.Add(this.notePanel_ErrorSrc);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(520, 157);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "调试面版";
            // 
            // simpleButton_Close
            // 
            this.simpleButton_Close.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_Close.Appearance.ForeColor = System.Drawing.Color.Black;
            this.simpleButton_Close.Appearance.Options.UseFont = true;
            this.simpleButton_Close.Appearance.Options.UseForeColor = true;
            this.simpleButton_Close.Location = new System.Drawing.Point(288, 104);
            this.simpleButton_Close.Name = "simpleButton_Close";
            this.simpleButton_Close.Size = new System.Drawing.Size(88, 26);
            this.simpleButton_Close.TabIndex = 28;
            this.simpleButton_Close.Tag = 4;
            this.simpleButton_Close.Text = "退 出";
            this.simpleButton_Close.Visible = false;
            this.simpleButton_Close.Click += new System.EventHandler(this.simpleButton_Close_Click);
            // 
            // simpleButton_Confirm
            // 
            this.simpleButton_Confirm.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_Confirm.Appearance.ForeColor = System.Drawing.Color.Black;
            this.simpleButton_Confirm.Appearance.Options.UseFont = true;
            this.simpleButton_Confirm.Appearance.Options.UseForeColor = true;
            this.simpleButton_Confirm.Location = new System.Drawing.Point(176, 104);
            this.simpleButton_Confirm.Name = "simpleButton_Confirm";
            this.simpleButton_Confirm.Size = new System.Drawing.Size(88, 26);
            this.simpleButton_Confirm.TabIndex = 27;
            this.simpleButton_Confirm.Tag = 4;
            this.simpleButton_Confirm.Text = "确 定";
            this.simpleButton_Confirm.Click += new System.EventHandler(this.simpleButton_Confirm_Click);
            // 
            // textEdit_ErrorMsg
            // 
            this.textEdit_ErrorMsg.EditValue = "";
            this.textEdit_ErrorMsg.Location = new System.Drawing.Point(216, 64);
            this.textEdit_ErrorMsg.Name = "textEdit_ErrorMsg";
            this.textEdit_ErrorMsg.Size = new System.Drawing.Size(232, 20);
            this.textEdit_ErrorMsg.TabIndex = 26;
            // 
            // notePanel_ErrorMsg
            // 
            this.notePanel_ErrorMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.notePanel_ErrorMsg.BackColor2 = System.Drawing.Color.DarkGray;
            this.notePanel_ErrorMsg.Font = new System.Drawing.Font("Tahoma", 8F);
            this.notePanel_ErrorMsg.ForeColor = System.Drawing.Color.Black;
            this.notePanel_ErrorMsg.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_ErrorMsg.Location = new System.Drawing.Point(120, 64);
            this.notePanel_ErrorMsg.MaxRows = 5;
            this.notePanel_ErrorMsg.Name = "notePanel_ErrorMsg";
            this.notePanel_ErrorMsg.ParentAutoHeight = true;
            this.notePanel_ErrorMsg.Size = new System.Drawing.Size(80, 21);
            this.notePanel_ErrorMsg.TabIndex = 25;
            this.notePanel_ErrorMsg.TabStop = false;
            // 
            // notePanel_ErrorSrc
            // 
            this.notePanel_ErrorSrc.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.notePanel_ErrorSrc.Dock = System.Windows.Forms.DockStyle.Top;
            this.notePanel_ErrorSrc.ForeColor = System.Drawing.Color.OrangeRed;
            this.notePanel_ErrorSrc.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.notePanel_ErrorSrc.Location = new System.Drawing.Point(2, 22);
            this.notePanel_ErrorSrc.MaxRows = 5;
            this.notePanel_ErrorSrc.Name = "notePanel_ErrorSrc";
            this.notePanel_ErrorSrc.ParentAutoHeight = true;
            this.notePanel_ErrorSrc.Size = new System.Drawing.Size(516, 23);
            this.notePanel_ErrorSrc.TabIndex = 6;
            this.notePanel_ErrorSrc.TabStop = false;
            this.notePanel_ErrorSrc.Text = "错误源:";
            // 
            // DebugErrors
            // 
            this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(520, 157);
            this.Controls.Add(this.groupControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DebugErrors";
            this.Text = "错误调试";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_ErrorMsg.Properties)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void simpleButton_Confirm_Click(object sender, System.EventArgs e)
		{
			this.errContent = textEdit_ErrorMsg.Text.Trim();
			this.Close();
		}

		private void simpleButton_Close_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		public string DebugErrorContent()
		{
			return this.errContent;
		}
	}
}

