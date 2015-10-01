using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CPTT.WinUI
{
	/// <summary>
	/// Summary description for ModifiMachineAddress.
	/// </summary>
	public class ModifiMachineAddress : DevExpress.XtraEditors.XtraForm
	{
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.XtraEditors.ButtonEdit buttonEdit1;
		public int ModifyAddress;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ModifiMachineAddress()
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
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.buttonEdit1 = new DevExpress.XtraEditors.ButtonEdit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).BeginInit();
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
			this.groupControl1.Controls.Add(this.buttonEdit1);
			this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl1.Location = new System.Drawing.Point(0, 0);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(216, 69);
			this.groupControl1.TabIndex = 0;
			this.groupControl1.Text = "请填入修改地址";
			// 
			// buttonEdit1
			// 
			this.buttonEdit1.EditValue = "";
			this.buttonEdit1.Location = new System.Drawing.Point(71, 32);
			this.buttonEdit1.Name = "buttonEdit1";
			// 
			// buttonEdit1.Properties
			// 
			this.buttonEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												new DevExpress.XtraEditors.Controls.EditorButton()});
			this.buttonEdit1.Properties.Mask.EditMask = "d";
			this.buttonEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.buttonEdit1.Size = new System.Drawing.Size(75, 23);
			this.buttonEdit1.TabIndex = 1;
			this.buttonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit1_ButtonClick);
			this.buttonEdit1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.buttonEdit1_KeyPress);
			// 
			// ModifiMachineAddress
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(216, 69);
			this.Controls.Add(this.groupControl1);
			this.Name = "ModifiMachineAddress";
			this.ShowInTaskbar = false;
			this.Text = "修改机器地址";
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
		{
			if(buttonEdit1.Text.Trim().Length == 0)
			{
				MessageBox.Show("请填入要修改的地址.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}
			ModifyAddress = Convert.ToInt32(buttonEdit1.Text);
			this.Close();
		}

		private void buttonEdit1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar == '\r')
			{
				if(buttonEdit1.Text.Trim().Length == 0)
				{
					MessageBox.Show("请填入要修改的地址.","系统信息!",
						MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				ModifyAddress = Convert.ToInt32(buttonEdit1.Text);
				this.Close();
			}
		}
	}
}

