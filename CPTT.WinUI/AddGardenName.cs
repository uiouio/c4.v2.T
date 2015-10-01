using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CPTT.BusinessFacade;

namespace CPTT.WinUI
{
	/// <summary>
	/// Summary description for AddGardenName.
	/// </summary>
	public class AddGardenName : DevExpress.XtraEditors.XtraForm
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private DevExpress.Utils.Frames.NotePanel notePanel_ErrorSrc;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AddGardenName()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AddGardenName));
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.notePanel_ErrorSrc = new DevExpress.Utils.Frames.NotePanel();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(80, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "园所名称";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(168, 56);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(176, 21);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(184, 88);
			this.button1.Name = "button1";
			this.button1.TabIndex = 2;
			this.button1.Text = "确定";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// notePanel_ErrorSrc
			// 
			this.notePanel_ErrorSrc.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel_ErrorSrc.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel_ErrorSrc.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel_ErrorSrc.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_ErrorSrc.Location = new System.Drawing.Point(0, 0);
			this.notePanel_ErrorSrc.MaxRows = 5;
			this.notePanel_ErrorSrc.Name = "notePanel_ErrorSrc";
			this.notePanel_ErrorSrc.ParentAutoHeight = true;
			this.notePanel_ErrorSrc.Size = new System.Drawing.Size(464, 23);
			this.notePanel_ErrorSrc.TabIndex = 7;
			this.notePanel_ErrorSrc.TabStop = false;
			this.notePanel_ErrorSrc.Text = "为方便管理，请再次填写园所名称，系统将自动为您分配一个全国唯一ID";
			// 
			// AddGardenName
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(464, 133);
			this.Controls.Add(this.notePanel_ErrorSrc);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AddGardenName";
			this.Text = "园所名称确认";
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			if (textBox1.Text.Trim().Length == 0)
			{
				MessageBox.Show("名字不能为空！");
			}
			else
			{
				new UtilSystem().AddUniqueGardenStatus(textBox1.Text.Trim());
				this.Close();
			}
		}
	}
}

