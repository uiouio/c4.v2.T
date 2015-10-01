using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Xml;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;


namespace CPTT.WinUI
{
	/// <summary>
	/// Summary description for ConfigForm.
	/// </summary>
	public class ConfigForm : DevExpress.XtraEditors.XtraForm
	{
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.Utils.Frames.NotePanel notePanel_SrvName;
		private DevExpress.Utils.Frames.NotePanel notePanel_SrvUserName;
		private DevExpress.XtraEditors.TextEdit textEdit_SrvName;
		private DevExpress.XtraEditors.TextEdit textEdit_SrvUserName;
		private DevExpress.XtraEditors.SimpleButton simpleButton_TryConnect;
		private DevExpress.XtraEditors.SimpleButton simpleButton_SaveConnect;
		private DevExpress.Utils.Frames.NotePanel notePanel_SrvUserPwd;
		private DevExpress.XtraEditors.TextEdit textEdit_SrvUserPwd;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private bool hasTryConnSucceed = false;

		public ConfigForm()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ConfigForm));
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.notePanel_SrvName = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_SrvUserPwd = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_SrvUserName = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_SrvName = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_SrvUserName = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_SrvUserPwd = new DevExpress.XtraEditors.TextEdit();
			this.simpleButton_TryConnect = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_SaveConnect = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_SrvName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_SrvUserName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_SrvUserPwd.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// groupControl1
			// 
			this.groupControl1.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.groupControl1.Appearance.Options.UseBackColor = true;
			this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl1.AppearanceCaption.Options.UseFont = true;
			this.groupControl1.Controls.Add(this.simpleButton_SaveConnect);
			this.groupControl1.Controls.Add(this.simpleButton_TryConnect);
			this.groupControl1.Controls.Add(this.textEdit_SrvUserPwd);
			this.groupControl1.Controls.Add(this.textEdit_SrvUserName);
			this.groupControl1.Controls.Add(this.textEdit_SrvName);
			this.groupControl1.Controls.Add(this.notePanel_SrvUserName);
			this.groupControl1.Controls.Add(this.notePanel_SrvUserPwd);
			this.groupControl1.Controls.Add(this.notePanel_SrvName);
			this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl1.Location = new System.Drawing.Point(0, 0);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(440, 261);
			this.groupControl1.TabIndex = 0;
			this.groupControl1.Text = "服务器配置";
			// 
			// notePanel_SrvName
			// 
			this.notePanel_SrvName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_SrvName.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_SrvName.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_SrvName.ForeColor = System.Drawing.Color.Black;
			this.notePanel_SrvName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_SrvName.Location = new System.Drawing.Point(88, 48);
			this.notePanel_SrvName.MaxRows = 5;
			this.notePanel_SrvName.Name = "notePanel_SrvName";
			this.notePanel_SrvName.ParentAutoHeight = true;
			this.notePanel_SrvName.Size = new System.Drawing.Size(128, 22);
			this.notePanel_SrvName.TabIndex = 27;
			this.notePanel_SrvName.TabStop = false;
			this.notePanel_SrvName.Text = "   服务器实例名:";
			// 
			// notePanel_SrvUserPwd
			// 
			this.notePanel_SrvUserPwd.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_SrvUserPwd.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_SrvUserPwd.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_SrvUserPwd.ForeColor = System.Drawing.Color.Black;
			this.notePanel_SrvUserPwd.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_SrvUserPwd.Location = new System.Drawing.Point(88, 128);
			this.notePanel_SrvUserPwd.MaxRows = 5;
			this.notePanel_SrvUserPwd.Name = "notePanel_SrvUserPwd";
			this.notePanel_SrvUserPwd.ParentAutoHeight = true;
			this.notePanel_SrvUserPwd.Size = new System.Drawing.Size(128, 22);
			this.notePanel_SrvUserPwd.TabIndex = 28;
			this.notePanel_SrvUserPwd.TabStop = false;
			this.notePanel_SrvUserPwd.Text = "  服务器登陆密码:";
			// 
			// notePanel_SrvUserName
			// 
			this.notePanel_SrvUserName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_SrvUserName.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_SrvUserName.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_SrvUserName.ForeColor = System.Drawing.Color.Black;
			this.notePanel_SrvUserName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_SrvUserName.Location = new System.Drawing.Point(88, 88);
			this.notePanel_SrvUserName.MaxRows = 5;
			this.notePanel_SrvUserName.Name = "notePanel_SrvUserName";
			this.notePanel_SrvUserName.ParentAutoHeight = true;
			this.notePanel_SrvUserName.Size = new System.Drawing.Size(128, 22);
			this.notePanel_SrvUserName.TabIndex = 29;
			this.notePanel_SrvUserName.TabStop = false;
			this.notePanel_SrvUserName.Text = "服务器登陆用户名:";
			// 
			// textEdit_SrvName
			// 
			this.textEdit_SrvName.EditValue = "";
			this.textEdit_SrvName.Location = new System.Drawing.Point(232, 48);
			this.textEdit_SrvName.Name = "textEdit_SrvName";
			this.textEdit_SrvName.Size = new System.Drawing.Size(144, 23);
			this.textEdit_SrvName.TabIndex = 30;
			// 
			// textEdit_SrvUserName
			// 
			this.textEdit_SrvUserName.EditValue = "";
			this.textEdit_SrvUserName.Location = new System.Drawing.Point(232, 88);
			this.textEdit_SrvUserName.Name = "textEdit_SrvUserName";
			this.textEdit_SrvUserName.Size = new System.Drawing.Size(144, 23);
			this.textEdit_SrvUserName.TabIndex = 31;
			// 
			// textEdit_SrvUserPwd
			// 
			this.textEdit_SrvUserPwd.EditValue = "";
			this.textEdit_SrvUserPwd.Location = new System.Drawing.Point(232, 128);
			this.textEdit_SrvUserPwd.Name = "textEdit_SrvUserPwd";
			// 
			// textEdit_SrvUserPwd.Properties
			// 
			this.textEdit_SrvUserPwd.Properties.PasswordChar = '*';
			this.textEdit_SrvUserPwd.Size = new System.Drawing.Size(144, 23);
			this.textEdit_SrvUserPwd.TabIndex = 32;
			// 
			// simpleButton_TryConnect
			// 
			this.simpleButton_TryConnect.Appearance.ForeColor = System.Drawing.Color.Black;
			this.simpleButton_TryConnect.Appearance.Options.UseForeColor = true;
			this.simpleButton_TryConnect.Location = new System.Drawing.Point(120, 176);
			this.simpleButton_TryConnect.Name = "simpleButton_TryConnect";
			this.simpleButton_TryConnect.Size = new System.Drawing.Size(96, 26);
			this.simpleButton_TryConnect.TabIndex = 33;
			this.simpleButton_TryConnect.Text = "测试连接";
			this.simpleButton_TryConnect.Click += new System.EventHandler(this.simpleButton_TryConnect_Click);
			// 
			// simpleButton_SaveConnect
			// 
			this.simpleButton_SaveConnect.Appearance.ForeColor = System.Drawing.Color.Black;
			this.simpleButton_SaveConnect.Appearance.Options.UseForeColor = true;
			this.simpleButton_SaveConnect.Location = new System.Drawing.Point(232, 176);
			this.simpleButton_SaveConnect.Name = "simpleButton_SaveConnect";
			this.simpleButton_SaveConnect.Size = new System.Drawing.Size(88, 26);
			this.simpleButton_SaveConnect.TabIndex = 34;
			this.simpleButton_SaveConnect.Text = "保存设置";
			this.simpleButton_SaveConnect.Click += new System.EventHandler(this.simpleButton_SaveConnect_Click);
			// 
			// ConfigForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(440, 261);
			this.Controls.Add(this.groupControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ConfigForm";
			this.Text = "服务器配置框";
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.textEdit_SrvName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_SrvUserName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_SrvUserPwd.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void simpleButton_TryConnect_Click(object sender, System.EventArgs e)
		{
			string DBName = textEdit_SrvName.Text.Trim();
			string DBUser = textEdit_SrvUserName.Text.Trim();
			string DBUserPwd = textEdit_SrvUserPwd.Text.Trim();

			SqlConnection sqlConn = null;

			if ( DBName.Equals(string.Empty) || DBUser.Equals(string.Empty) )
			{
				MessageBox.Show("请检查填写是否合法.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}

			try
			{
				sqlConn = new SqlConnection("Data Source = "+DBName
					+";Persist Security Info = false;User ID = "+DBUser
					+";Password = "+DBUserPwd+";Initial Catalog = CTPPDB;");
				sqlConn.Open();
				MessageBox.Show("成功连接数据库!","成功!",MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				hasTryConnSucceed = true;
				sqlConn.Close();
			}
			catch(Exception ex)
			{
				if ( sqlConn != null )
				{
					sqlConn.Close();
				}

				MessageBox.Show(ex.Message+"连接数据库失败,请查找原因!","系统信息!",MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				hasTryConnSucceed = false;
			}
		}

		private void simpleButton_SaveConnect_Click(object sender, System.EventArgs e)
		{
			if ( hasTryConnSucceed )
			{
				string DBName = textEdit_SrvName.Text.Trim();
				string DBUser = textEdit_SrvUserName.Text.Trim();
				string DBUserPwd = textEdit_SrvUserPwd.Text.Trim();

				if ( DBName.Equals(string.Empty) || DBUser.Equals(string.Empty) )
				{
					MessageBox.Show("请检查填写是否合法.","系统信息!",
						MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}

				try
				{
					DatabaseSettings dbSettings = (DatabaseSettings)ConfigurationManager.GetConfiguration("dataConfiguration");
					dbSettings.ConnectionStrings[0].Parameters["server"].Value=DBName;
					dbSettings.ConnectionStrings[0].Parameters["User ID"].Value=DBUser;
					dbSettings.ConnectionStrings[0].Parameters["Password"].Value=DBUserPwd;
					ConfigurationManager.WriteConfiguration("dataConfiguration",dbSettings);

					MessageBox.Show("保存成功!","系统信息!",MessageBoxButtons.OK,
						MessageBoxIcon.Information);
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message,"系统信息!",MessageBoxButtons.OK,
						MessageBoxIcon.Information);
				}

				this.Close();
			}
			else
				MessageBox.Show("连接测试不成功，请先测试！");
		}
	}
}

