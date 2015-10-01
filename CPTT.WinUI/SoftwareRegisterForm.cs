using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CPTT.WinUI
{
	/// <summary>
	/// Summary description for SoftwareRegisterForm.
	/// </summary>
	public class SoftwareRegisterForm : DevExpress.XtraEditors.XtraForm
	{
		private System.Windows.Forms.Button btnSubmit;
		private System.Windows.Forms.Label lblSn;
		private System.Windows.Forms.TextBox tbxSn;
		private static string getSn = string.Empty;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SoftwareRegisterForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public static string GetSn
		{
			get { return getSn; }
			set { getSn = value; }
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SoftwareRegisterForm));
			this.btnSubmit = new System.Windows.Forms.Button();
			this.lblSn = new System.Windows.Forms.Label();
			this.tbxSn = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnSubmit
			// 
			this.btnSubmit.Location = new System.Drawing.Point(280, 88);
			this.btnSubmit.Name = "btnSubmit";
			this.btnSubmit.TabIndex = 0;
			this.btnSubmit.Text = "提交";
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			// 
			// lblSn
			// 
			this.lblSn.Location = new System.Drawing.Point(104, 40);
			this.lblSn.Name = "lblSn";
			this.lblSn.Size = new System.Drawing.Size(64, 23);
			this.lblSn.TabIndex = 1;
			this.lblSn.Text = "序列号：";
			this.lblSn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbxSn
			// 
			this.tbxSn.Location = new System.Drawing.Point(168, 40);
			this.tbxSn.Name = "tbxSn";
			this.tbxSn.Size = new System.Drawing.Size(392, 21);
			this.tbxSn.TabIndex = 2;
			this.tbxSn.Text = "";
			// 
			// SoftwareRegisterForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(632, 133);
			this.Controls.Add(this.tbxSn);
			this.Controls.Add(this.lblSn);
			this.Controls.Add(this.btnSubmit);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "SoftwareRegisterForm";
			this.Text = "序列号输入框";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			getSn = tbxSn.Text.Trim();
			this.Close();
		}


	}
}

