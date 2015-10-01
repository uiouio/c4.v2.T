using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CPTT.WinUI.Panels
{
	/// <summary>
	/// Summary description for SmsInfo.
	/// </summary>
	public class SmsInfo : DevExpress.XtraEditors.XtraUserControl
	{
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl_Sms;
		private DevExpress.XtraNavBar.NavBarControl navBarControl1;
		private DevExpress.XtraNavBar.NavBarGroup navBarGroup_SmsMenu;
		private DevExpress.XtraNavBar.NavBarItem navBarItem_SendNewSms;
		private DevExpress.XtraNavBar.NavBarItem navBarItem_ReceiveBox;
		private DevExpress.XtraNavBar.NavBarItem navBarItem_PhoneNum;
		private DevExpress.XtraNavBar.NavBarItem navBarItem_Template;
		private CPTT.WinUI.Panels.PaneCaption paneCaption_Title;
		private CPTT.WinUI.Panels.SendNewSms sendNewSms1;
		private CPTT.WinUI.Panels.SmsReceiveBox smsReceiveBox1;
		private CPTT.WinUI.Panels.SendedSmsBox sendedSmsBox1;
		private CPTT.WinUI.Panels.PhoneNum phoneNum1;
		private CPTT.WinUI.Panels.EditTemplate editTemplate1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SmsInfo()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call

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
			this.splitContainerControl_Sms = new DevExpress.XtraEditors.SplitContainerControl();
			this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
			this.navBarGroup_SmsMenu = new DevExpress.XtraNavBar.NavBarGroup();
			this.navBarItem_SendNewSms = new DevExpress.XtraNavBar.NavBarItem();
			this.navBarItem_ReceiveBox = new DevExpress.XtraNavBar.NavBarItem();
			this.navBarItem_PhoneNum = new DevExpress.XtraNavBar.NavBarItem();
			this.navBarItem_Template = new DevExpress.XtraNavBar.NavBarItem();
			this.editTemplate1 = new CPTT.WinUI.Panels.EditTemplate();
			this.sendedSmsBox1 = new CPTT.WinUI.Panels.SendedSmsBox();
			this.smsReceiveBox1 = new CPTT.WinUI.Panels.SmsReceiveBox();
			this.phoneNum1 = new PhoneNum();
			this.sendNewSms1 = new CPTT.WinUI.Panels.SendNewSms();
			this.paneCaption_Title = new CPTT.WinUI.Panels.PaneCaption();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl_Sms)).BeginInit();
			this.splitContainerControl_Sms.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainerControl_Sms
			// 
			this.splitContainerControl_Sms.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl_Sms.Location = new System.Drawing.Point(0, 0);
			this.splitContainerControl_Sms.Name = "splitContainerControl_Sms";
			this.splitContainerControl_Sms.Panel1.Controls.Add(this.navBarControl1);
			this.splitContainerControl_Sms.Panel1.Text = "splitContainerControl1_Panel1";
			this.splitContainerControl_Sms.Panel2.Controls.Add(this.editTemplate1);
			this.splitContainerControl_Sms.Panel2.Controls.Add(this.sendedSmsBox1);
			this.splitContainerControl_Sms.Panel2.Controls.Add(this.smsReceiveBox1);
			this.splitContainerControl_Sms.Panel2.Controls.Add(this.sendNewSms1);
			this.splitContainerControl_Sms.Panel2.Controls.Add(this.phoneNum1);
			this.splitContainerControl_Sms.Panel2.Controls.Add(this.paneCaption_Title);
			this.splitContainerControl_Sms.Panel2.Text = "splitContainerControl1_Panel2";
			this.splitContainerControl_Sms.Size = new System.Drawing.Size(772, 540);
			this.splitContainerControl_Sms.SplitterPosition = 155;
			this.splitContainerControl_Sms.TabIndex = 0;
			this.splitContainerControl_Sms.Text = "splitContainerControl1";
			// 
			// navBarControl1
			// 
			this.navBarControl1.ActiveGroup = this.navBarGroup_SmsMenu;
			this.navBarControl1.AllowDrop = true;
			this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
																							this.navBarGroup_SmsMenu});
			this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
																						  this.navBarItem_SendNewSms,
																						  this.navBarItem_ReceiveBox,
																						  this.navBarItem_PhoneNum,
																						  this.navBarItem_Template});
			this.navBarControl1.Location = new System.Drawing.Point(0, 0);
			this.navBarControl1.Name = "navBarControl1";
			this.navBarControl1.Size = new System.Drawing.Size(149, 184);
			this.navBarControl1.TabIndex = 0;
			this.navBarControl1.Text = "navBarControl1";
			// 
			// navBarGroup_SmsMenu
			// 
			this.navBarGroup_SmsMenu.Caption = "操作菜单";
			this.navBarGroup_SmsMenu.Expanded = true;
			this.navBarGroup_SmsMenu.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsList;
			this.navBarGroup_SmsMenu.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
																									   new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_SendNewSms),
																									   new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_ReceiveBox),
																									   new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_PhoneNum),
																									   new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_Template)});
			this.navBarGroup_SmsMenu.Name = "navBarGroup_SmsMenu";
			// 
			// navBarItem_SendNewSms
			// 
			this.navBarItem_SendNewSms.Caption = "发送新短信";
			this.navBarItem_SendNewSms.Name = "navBarItem_SendNewSms";
			this.navBarItem_SendNewSms.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_SendNewSms_LinkClicked);
			// 
			// navBarItem_ReceiveBox
			// 
			this.navBarItem_ReceiveBox.Caption = "收件箱";
			this.navBarItem_ReceiveBox.Name = "navBarItem_ReceiveBox";
			this.navBarItem_ReceiveBox.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_ReceiveBox_LinkClicked);
			// 
			// navBarItem_PhoneNum
			// 
			this.navBarItem_PhoneNum.Caption = "号码簿";
			this.navBarItem_PhoneNum.Name = "navBarItem_PhoneNum";
			this.navBarItem_PhoneNum.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_PhoneNum_LinkClicked);
			// 
			// navBarItem_Template
			// 
			this.navBarItem_Template.Caption = "模板编辑";
			this.navBarItem_Template.Name = "navBarItem_Template";
			this.navBarItem_Template.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_Template_LinkClicked);
			// 
			// editTemplate1
			// 
			this.editTemplate1.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.editTemplate1.Appearance.Options.UseBackColor = true;
			this.editTemplate1.Location = new System.Drawing.Point(240, 232);
			this.editTemplate1.Name = "editTemplate1";
			this.editTemplate1.Size = new System.Drawing.Size(144, 128);
			this.editTemplate1.TabIndex = 15;
			this.editTemplate1.Visible = false;
			// 
			// sendedSmsBox1
			// 
			this.sendedSmsBox1.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.sendedSmsBox1.Appearance.Options.UseBackColor = true;
			this.sendedSmsBox1.Location = new System.Drawing.Point(400, 64);
			this.sendedSmsBox1.Name = "sendedSmsBox1";
			this.sendedSmsBox1.Size = new System.Drawing.Size(144, 128);
			this.sendedSmsBox1.TabIndex = 13;
			this.sendedSmsBox1.Visible = false;
			// 
			// smsReceiveBox1
			// 
			this.smsReceiveBox1.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.smsReceiveBox1.Appearance.Options.UseBackColor = true;
			this.smsReceiveBox1.Location = new System.Drawing.Point(240, 64);
			this.smsReceiveBox1.Name = "smsReceiveBox1";
			this.smsReceiveBox1.Size = new System.Drawing.Size(144, 128);
			this.smsReceiveBox1.TabIndex = 12;
			this.smsReceiveBox1.Visible = false;
			// 
			// phoneNum1
			// 
			this.phoneNum1.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.phoneNum1.Appearance.Options.UseBackColor = true;
			this.phoneNum1.Location = new System.Drawing.Point(72, 264);
			this.phoneNum1.Name = "phoneNum1";
			this.phoneNum1.Size = new System.Drawing.Size(144, 128);
			this.phoneNum1.TabIndex = 11;
			this.phoneNum1.Visible = false;
			// 
			// sendNewSms1
			// 
			this.sendNewSms1.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.sendNewSms1.Appearance.Options.UseBackColor = true;
			this.sendNewSms1.Location = new System.Drawing.Point(72, 64);
			this.sendNewSms1.Name = "sendNewSms1";
			this.sendNewSms1.Size = new System.Drawing.Size(144, 128);
			this.sendNewSms1.TabIndex = 11;
			this.sendNewSms1.Visible = false;
			// 
			// paneCaption_Title
			// 
			this.paneCaption_Title.AllowActive = false;
			this.paneCaption_Title.AntiAlias = false;
			this.paneCaption_Title.Caption = "发送新短信";
			this.paneCaption_Title.Dock = System.Windows.Forms.DockStyle.Top;
			this.paneCaption_Title.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
			this.paneCaption_Title.InactiveGradientHighColor = System.Drawing.Color.DimGray;
			this.paneCaption_Title.InactiveGradientLowColor = System.Drawing.Color.LightGray;
			this.paneCaption_Title.Location = new System.Drawing.Point(0, 0);
			this.paneCaption_Title.Name = "paneCaption_Title";
			this.paneCaption_Title.Size = new System.Drawing.Size(607, 28);
			this.paneCaption_Title.TabIndex = 10;
			// 
			// SmsInfo
			// 
			this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.Appearance.Options.UseBackColor = true;
			this.Controls.Add(this.splitContainerControl_Sms);
			this.Name = "SmsInfo";
			this.Size = new System.Drawing.Size(772, 540);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl_Sms)).EndInit();
			this.splitContainerControl_Sms.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void vis()
		{
			sendNewSms1.Visible = false;
			sendNewSms1.Dock = DockStyle.Fill;
			smsReceiveBox1.Visible = false;
			smsReceiveBox1.Dock = DockStyle.Fill;
			sendedSmsBox1.Visible = false;
			sendedSmsBox1.Dock = DockStyle.Fill;
			phoneNum1.Visible = false;
			phoneNum1.Dock = DockStyle.Fill;
			editTemplate1.Visible = false;
			editTemplate1.Dock = DockStyle.Fill;

		}

		private void navBarItem_SendNewSms_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			vis();
			sendNewSms1.Visible = true;
			paneCaption_Title.Caption = "发送新短信";
		}

		private void navBarItem_ReceiveBox_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			vis();
			smsReceiveBox1.Visible = true;
			paneCaption_Title.Caption = "收件箱";
		}

		private void navBarItem_SendedBox_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			vis();
			sendedSmsBox1.Visible = true;
			paneCaption_Title.Caption = "收件箱";
		}

		private void navBarItem_PhoneNum_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			vis();
			phoneNum1.Visible = true;
			paneCaption_Title.Caption = "号码簿";
		}

		private void navBarItem_Template_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			vis();
			editTemplate1.Visible = true;
			paneCaption_Title.Caption = "编辑模板";
		}
	}
}

