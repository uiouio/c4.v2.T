using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MSXML2;

using CPTT.BusinessFacade;

namespace CPTT.WinUI.Panels
{
	/// <summary>
	/// Summary description for SendNewSms.
	/// </summary>
	public class SendNewSms : DevExpress.XtraEditors.XtraUserControl
	{
		private DevExpress.XtraEditors.ListBoxControl listBoxControl_Template;
		private DevExpress.Utils.Frames.NotePanel notePanel_SendTo;
		private DevExpress.Utils.Frames.NotePanel notePanel1;
		private DevExpress.XtraEditors.MemoEdit memoEdit_Content;
		private DevExpress.XtraEditors.MemoEdit memoEdit1;
		private DevExpress.XtraEditors.SimpleButton simpleButton_ImportPhoneNum;
		private DevExpress.XtraEditors.SimpleButton simpleButton_UseTemplate;
		private DevExpress.XtraEditors.SimpleButton simpleButton_SendSms;
		private DevExpress.XtraEditors.SimpleButton simpleButton_Reset;
		private DevExpress.Utils.Frames.NotePanel notePanel_DutyDetailsTitle;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private string sendMobilePhone = string.Empty;
		private DataSet SMSTemp;

		public SendNewSms()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call
			SMSTemp = new SMSInfoSystem().GetAllSMSTemp();
			listBoxControl_Template.DataSource = SMSTemp.Tables[0];

			listBoxControl_Template.DisplayMember = "templet_name";
			listBoxControl_Template.ValueMember = "templet_content";
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
			this.listBoxControl_Template = new DevExpress.XtraEditors.ListBoxControl();
			this.notePanel_SendTo = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel1 = new DevExpress.Utils.Frames.NotePanel();
			this.memoEdit_Content = new DevExpress.XtraEditors.MemoEdit();
			this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
			this.simpleButton_ImportPhoneNum = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_UseTemplate = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_SendSms = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_Reset = new DevExpress.XtraEditors.SimpleButton();
			this.notePanel_DutyDetailsTitle = new DevExpress.Utils.Frames.NotePanel();
			((System.ComponentModel.ISupportInitialize)(this.listBoxControl_Template)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit_Content.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// listBoxControl_Template
			// 
			this.listBoxControl_Template.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxControl_Template.ItemHeight = 16;
			this.listBoxControl_Template.Location = new System.Drawing.Point(416, 144);
			this.listBoxControl_Template.Name = "listBoxControl_Template";
			this.listBoxControl_Template.Size = new System.Drawing.Size(152, 240);
			this.listBoxControl_Template.TabIndex = 0;
			this.listBoxControl_Template.Visible = false;
			this.listBoxControl_Template.Click += new System.EventHandler(this.listBoxControl_Template_Click);
			// 
			// notePanel_SendTo
			// 
			this.notePanel_SendTo.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_SendTo.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_SendTo.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_SendTo.ForeColor = System.Drawing.Color.Black;
			this.notePanel_SendTo.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_SendTo.Location = new System.Drawing.Point(24, 64);
			this.notePanel_SendTo.MaxRows = 5;
			this.notePanel_SendTo.Name = "notePanel_SendTo";
			this.notePanel_SendTo.ParentAutoHeight = true;
			this.notePanel_SendTo.Size = new System.Drawing.Size(80, 22);
			this.notePanel_SendTo.TabIndex = 5;
			this.notePanel_SendTo.TabStop = false;
			this.notePanel_SendTo.Text = "目标号码";
			// 
			// notePanel1
			// 
			this.notePanel1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel1.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel1.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel1.ForeColor = System.Drawing.Color.Black;
			this.notePanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel1.Location = new System.Drawing.Point(24, 144);
			this.notePanel1.MaxRows = 5;
			this.notePanel1.Name = "notePanel1";
			this.notePanel1.ParentAutoHeight = true;
			this.notePanel1.Size = new System.Drawing.Size(80, 22);
			this.notePanel1.TabIndex = 5;
			this.notePanel1.TabStop = false;
			this.notePanel1.Text = "内容";
			// 
			// memoEdit_Content
			// 
			this.memoEdit_Content.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.memoEdit_Content.EditValue = "";
			this.memoEdit_Content.Location = new System.Drawing.Point(112, 144);
			this.memoEdit_Content.Name = "memoEdit_Content";
			this.memoEdit_Content.Size = new System.Drawing.Size(280, 240);
			this.memoEdit_Content.TabIndex = 7;
			this.memoEdit_Content.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.memoEdit_Content_KeyPress);
			// 
			// memoEdit1
			// 
			this.memoEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.memoEdit1.EditValue = "";
			this.memoEdit1.Location = new System.Drawing.Point(112, 64);
			this.memoEdit1.Name = "memoEdit1";
			// 
			// memoEdit1.Properties
			// 
			this.memoEdit1.Properties.ReadOnly = true;
			this.memoEdit1.Size = new System.Drawing.Size(280, 32);
			this.memoEdit1.TabIndex = 7;
			// 
			// simpleButton_ImportPhoneNum
			// 
			this.simpleButton_ImportPhoneNum.Location = new System.Drawing.Point(112, 32);
			this.simpleButton_ImportPhoneNum.Name = "simpleButton_ImportPhoneNum";
			this.simpleButton_ImportPhoneNum.Size = new System.Drawing.Size(128, 24);
			this.simpleButton_ImportPhoneNum.TabIndex = 8;
			this.simpleButton_ImportPhoneNum.Text = "从号码簿导入号码";
			this.simpleButton_ImportPhoneNum.Click += new System.EventHandler(this.simpleButton_ImportPhoneNum_Click);
			// 
			// simpleButton_UseTemplate
			// 
			this.simpleButton_UseTemplate.Location = new System.Drawing.Point(112, 112);
			this.simpleButton_UseTemplate.Name = "simpleButton_UseTemplate";
			this.simpleButton_UseTemplate.Size = new System.Drawing.Size(128, 24);
			this.simpleButton_UseTemplate.TabIndex = 8;
			this.simpleButton_UseTemplate.Text = "使用模板编写内容";
			this.simpleButton_UseTemplate.Click += new System.EventHandler(this.simpleButton_UseTemplate_Click);
			// 
			// simpleButton_SendSms
			// 
			this.simpleButton_SendSms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButton_SendSms.Location = new System.Drawing.Point(248, 392);
			this.simpleButton_SendSms.Name = "simpleButton_SendSms";
			this.simpleButton_SendSms.Size = new System.Drawing.Size(64, 24);
			this.simpleButton_SendSms.TabIndex = 10;
			this.simpleButton_SendSms.Text = "发送";
			this.simpleButton_SendSms.Click += new System.EventHandler(this.simpleButton_SendSms_Click);
			// 
			// simpleButton_Reset
			// 
			this.simpleButton_Reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButton_Reset.Location = new System.Drawing.Point(328, 392);
			this.simpleButton_Reset.Name = "simpleButton_Reset";
			this.simpleButton_Reset.Size = new System.Drawing.Size(64, 24);
			this.simpleButton_Reset.TabIndex = 9;
			this.simpleButton_Reset.Text = "重置";
			this.simpleButton_Reset.Click += new System.EventHandler(this.simpleButton_Reset_Click);
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
			this.notePanel_DutyDetailsTitle.TabIndex = 11;
			this.notePanel_DutyDetailsTitle.TabStop = false;
			this.notePanel_DutyDetailsTitle.Text = "请注意发送内容不能超过70个字";
			// 
			// SendNewSms
			// 
			this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.Appearance.Options.UseBackColor = true;
			this.Controls.Add(this.notePanel_DutyDetailsTitle);
			this.Controls.Add(this.simpleButton_SendSms);
			this.Controls.Add(this.simpleButton_Reset);
			this.Controls.Add(this.simpleButton_ImportPhoneNum);
			this.Controls.Add(this.memoEdit_Content);
			this.Controls.Add(this.notePanel_SendTo);
			this.Controls.Add(this.listBoxControl_Template);
			this.Controls.Add(this.notePanel1);
			this.Controls.Add(this.memoEdit1);
			this.Controls.Add(this.simpleButton_UseTemplate);
			this.Name = "SendNewSms";
			this.Size = new System.Drawing.Size(584, 488);
			((System.ComponentModel.ISupportInitialize)(this.listBoxControl_Template)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit_Content.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		//显示模板列表
		private void simpleButton_UseTemplate_Click(object sender, System.EventArgs e)
		{
			listBoxControl_Template.Visible = true;
		}

		private void simpleButton_ImportPhoneNum_Click(object sender, System.EventArgs e)
		{
			SMSPhoneNumChoose smsPhone = new SMSPhoneNumChoose();
			smsPhone.StartPosition = FormStartPosition.CenterScreen;
			smsPhone.ShowDialog();

			if(smsPhone.chosenPhoneNum!=string.Empty)
			{
				memoEdit1.Text = smsPhone.chosenPhoneNum.Substring(
					0,smsPhone.chosenPhoneNum.Length-1);
				sendMobilePhone = smsPhone.chosenPhoneNum.Substring(
					0,smsPhone.chosenPhoneNum.Length-1);
			}
		}

		#region send sms
		private void simpleButton_SendSms_Click(object sender, System.EventArgs e)
		{
			if(memoEdit_Content.Text.Trim()==string.Empty)
			{
				MessageBox.Show("发送内容不能为空.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}

			if(memoEdit1.Text.Trim()==string.Empty)
			{
				MessageBox.Show("目标号码为空.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}

			sendSMS(sendMobilePhone);
		}

		private void sendSMS(string sendMobilePhone)
		{
			if(sendMobilePhone.Length==11)
			{
				try
				{
					string spNumber = string.Empty;

					switch(sendMobilePhone.Substring(2,1))
					{
						case "0":
							spNumber = "9002733";
							break;
						case "1":
							spNumber = "9002733";
							break;
						case "2":
							spNumber = "9002733";
							break;
						case "3":
							spNumber = "9002733";
							break;
						case "4":
							spNumber = "9002733";
							break;
						case "5":
							spNumber = "8002733";
							break;
						case "6":
							spNumber = "8002733";
							break;
						case "7":
							spNumber = "8002733";
							break;
						case "8":
							spNumber = "8002733";
							break;
						case "9":
							spNumber = "8002733";
							break;
					}

					string url = "http://202.96.236.81:7783/testDownMsg.asp?"
						+"UID=sap&psd=0F3E419C71C500FA1FC8&source="+spNumber+"&mobile="
						+sendMobilePhone+"&message="+memoEdit_Content.Text;

					MSXML2.XMLHTTPClass xmlHttp = new MSXML2.XMLHTTPClass();
					xmlHttp.open("POST" , url , false , null , null  );          
					xmlHttp.setRequestHeader( "Accept-Lauguage" , "zh-cn" );    

					xmlHttp.send( null );          
                                    
					if(xmlHttp.status == 200)
					{
						if(xmlHttp.responseText == "0")
						{

							MessageBox.Show("短信发送成功!","成功!",
								MessageBoxButtons.OK,MessageBoxIcon.Information);
						}
						else
						{

							MessageBox.Show("短信发送失败,请重试!","出错了!",
								MessageBoxButtons.OK,MessageBoxIcon.Information);
							return;
						}
					}
					else
					{	
						MessageBox.Show("短信发送失败,请重试!","出错了!",
							MessageBoxButtons.OK,MessageBoxIcon.Information);
						return;
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}

			else
			{
				sendMobilePhone = sendMobilePhone.Substring(0,sendMobilePhone.Length-1);

				string[] sendMobilePhones = sendMobilePhone.Split(new char[]{','});

				foreach(string phoneNumber in sendMobilePhones)
				{
					try
					{
						string spNumber = string.Empty;

						switch(phoneNumber.Substring(2,1))
						{
							case "0":
								spNumber = "9002733";
								break;
							case "1":
								spNumber = "9002733";
								break;
							case "2":
								spNumber = "9002733";
								break;
							case "3":
								spNumber = "9002733";
								break;
							case "4":
								spNumber = "9002733";
								break;
							case "5":
								spNumber = "8002733";
								break;
							case "6":
								spNumber = "8002733";
								break;
							case "7":
								spNumber = "8002733";
								break;
							case "8":
								spNumber = "8002733";
								break;
							case "9":
								spNumber = "8002733";
								break;
						}

						string url = "http://202.96.236.81:7783/testDownMsg.asp?"
							+"UID=sap&psd=0F3E419C71C500FA1FC8&source="+spNumber+"&mobile="
							+phoneNumber+"&message="+memoEdit_Content.Text;

						XMLHTTP xmlHttp = new XMLHTTPClass();
						xmlHttp.open("POST" , url , false , null , null  );          
						xmlHttp.setRequestHeader( "Accept-Lauguage" , "zh-cn" );

						xmlHttp.send(null);

						if(xmlHttp.status == 200)
						{
							if(xmlHttp.responseText == "0")
							{
							}
							else
							{

								MessageBox.Show("短信发送失败,请重试!","出错了!",
									MessageBoxButtons.OK,MessageBoxIcon.Information);
								return;
							}
						}
						else
						{	
							MessageBox.Show("短信发送失败,请重试!","出错了!",
								MessageBoxButtons.OK,MessageBoxIcon.Information);
							return;
						}
					}
					catch(Exception ex)
					{
						MessageBox.Show(ex.Message,"出错了!",
							MessageBoxButtons.OK,MessageBoxIcon.Information);
					}
				}

				MessageBox.Show("操作完成!","完成!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		private void memoEdit_Content_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(memoEdit_Content.Text.Trim().Length>70)
			{
				MessageBox.Show("发送内容不能超过70个字.","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				e.Handled = true;
			}
		}

		private void simpleButton_Reset_Click(object sender, System.EventArgs e)
		{
			memoEdit1.Text = string.Empty;
			memoEdit_Content.Text = string.Empty;
		}
		#endregion

		private void listBoxControl_Template_Click(object sender, System.EventArgs e)
		{
			memoEdit_Content.Text = listBoxControl_Template.SelectedValue.ToString();
		}
	}
}

