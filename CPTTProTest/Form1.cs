using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using CPTT.BusinessFacade;
using CPTT.SystemFramework;
using CTRLSERIALLib;
using DevExpress.XtraPrinting;

namespace CPTTProTest
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;

		private HandleComClass handleComClass;
		private bool comPortIsBusy;
		private HandleComData handleComData;
		private ControlFrame responseFrame;

		#region timer参数设置
		public const double QUERY_TIMER_INTERVAL = 300;//问询帧发送时间间隔
		public const double TIMESYNCH_TIMER_INTERVAL = 5*60*1000;//时间同步间隔设置
		#endregion

		#region Protocol参数设置
		public const byte QUERY_TOKEN = 0x02;
		public const byte TIME_SYNCH_TOKEN = 0x04;
		#endregion

		#region Response参数设置
		public const byte RECEIVE_SUCCESS_TOKEN = 0x0b;
		#endregion

		#region 通讯帧参数设置
		public const int CONTROL_FRAME_LENGTH = 7;
		public const byte FRAME_SEQUENCE_VALUE = 0;
		#endregion

		#region 日志参数设置
		public const string EXCEPTION_LOG_TITLE = "异常信息";
		#endregion

		#region 串口参数设置
		public const int COM1_PORT_NUMBER = 1;
		public const int COM_BAUD_RATE = 9600;
		#endregion
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog2;
		private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
		private DevExpress.XtraPrinting.Preview.PrintPreviewBar printPreviewBar1;
		private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton1;
		private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton2;
		private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton3;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton4;
		private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton5;
		private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton6;
		private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton7;
		private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton8;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton9;
		private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton10;
		private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton11;
		private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton12;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton13;
		private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton14;
		private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton15;
		private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton16;
		private System.Windows.Forms.ToolBarButton toolBarButton4;
		private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton17;
		private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton18;
		private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton19;
		private System.Windows.Forms.ToolBarButton toolBarButton5;
		private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton20;
		private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton21;
		private System.Windows.Forms.ToolBarButton toolBarButton6;
		private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton22;
		private DevExpress.XtraPrinting.Control.PrintControl printControl1;
		private DevExpress.XtraPrinting.Link link1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.HelpProvider helpProvider1;
		private System.Windows.Forms.TextBox textBox1;
		private System.ComponentModel.IContainer components;

		public Form1()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//

			responseFrame = new ControlFrame();
			responseFrame.sym = new byte[]{(byte)'*',(byte)'*'};
			responseFrame.desAddr = 1;
			responseFrame.srcAddr = 0;
			responseFrame.response = Form1.RECEIVE_SUCCESS_TOKEN;
			responseFrame.seq = Form1.FRAME_SEQUENCE_VALUE;
			responseFrame.computeCheckSum();

			handleComClass = new HandleComClass();
			handleComClass.Start(Form1.COM1_PORT_NUMBER,Form1.COM_BAUD_RATE,1);
			handleComClass.DataArrived += new _IHandleComEvents_DataArrivedEventHandler(handleComClass_DataArrived);

			handleComData = new HandleComData(this.InsertMorningCheckData);
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.button1 = new System.Windows.Forms.Button();
			this.printPreviewDialog2 = new System.Windows.Forms.PrintPreviewDialog();
			this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
			this.link1 = new DevExpress.XtraPrinting.Link(this.components);
			this.printPreviewBar1 = new DevExpress.XtraPrinting.Preview.PrintPreviewBar();
			this.printPreviewBarButton1 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
			this.printPreviewBarButton2 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
			this.printPreviewBarButton3 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.printPreviewBarButton4 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
			this.printPreviewBarButton5 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
			this.printPreviewBarButton6 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
			this.printPreviewBarButton7 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
			this.printPreviewBarButton8 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.printPreviewBarButton9 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
			this.printPreviewBarButton10 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
			this.printPreviewBarButton11 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
			this.printPreviewBarButton12 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
			this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
			this.printPreviewBarButton13 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
			this.printPreviewBarButton14 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
			this.printPreviewBarButton15 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
			this.printPreviewBarButton16 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
			this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
			this.printPreviewBarButton17 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
			this.printPreviewBarButton18 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
			this.printPreviewBarButton19 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
			this.toolBarButton5 = new System.Windows.Forms.ToolBarButton();
			this.printPreviewBarButton20 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
			this.printPreviewBarButton21 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
			this.toolBarButton6 = new System.Windows.Forms.ToolBarButton();
			this.printPreviewBarButton22 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
			this.printControl1 = new DevExpress.XtraPrinting.Control.PrintControl();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.helpProvider1 = new System.Windows.Forms.HelpProvider();
			this.textBox1 = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(120, 72);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(64, 32);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// printPreviewDialog2
			// 
			this.printPreviewDialog2.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreviewDialog2.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog2.ClientSize = new System.Drawing.Size(400, 300);
			this.printPreviewDialog2.Enabled = true;
			this.printPreviewDialog2.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog2.Icon")));
			this.printPreviewDialog2.Location = new System.Drawing.Point(47, 14);
			this.printPreviewDialog2.MinimumSize = new System.Drawing.Size(375, 250);
			this.printPreviewDialog2.Name = "printPreviewDialog2";
			this.printPreviewDialog2.TransparencyKey = System.Drawing.Color.Empty;
			this.printPreviewDialog2.Visible = false;
			// 
			// printingSystem1
			// 
			this.printingSystem1.Links.AddRange(new object[] {
																 this.link1});
			// 
			// link1
			// 
			this.link1.PrintingSystem = this.printingSystem1;
			// 
			// printPreviewBar1
			// 
			this.printPreviewBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.printPreviewBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																								this.printPreviewBarButton1,
																								this.printPreviewBarButton2,
																								this.printPreviewBarButton3,
																								this.toolBarButton1,
																								this.printPreviewBarButton4,
																								this.printPreviewBarButton5,
																								this.printPreviewBarButton6,
																								this.printPreviewBarButton7,
																								this.printPreviewBarButton8,
																								this.toolBarButton2,
																								this.printPreviewBarButton9,
																								this.printPreviewBarButton10,
																								this.printPreviewBarButton11,
																								this.printPreviewBarButton12,
																								this.toolBarButton3,
																								this.printPreviewBarButton13,
																								this.printPreviewBarButton14,
																								this.printPreviewBarButton15,
																								this.printPreviewBarButton16,
																								this.toolBarButton4,
																								this.printPreviewBarButton17,
																								this.printPreviewBarButton18,
																								this.printPreviewBarButton19,
																								this.toolBarButton5,
																								this.printPreviewBarButton20,
																								this.printPreviewBarButton21,
																								this.toolBarButton6,
																								this.printPreviewBarButton22});
			this.printPreviewBar1.ButtonSize = new System.Drawing.Size(16, 16);
			this.printPreviewBar1.DropDownArrows = true;
			this.printPreviewBar1.Location = new System.Drawing.Point(0, 0);
			this.printPreviewBar1.Name = "printPreviewBar1";
			this.printPreviewBar1.PrintControl = this.printControl1;
			this.printPreviewBar1.ShowToolTips = true;
			this.printPreviewBar1.Size = new System.Drawing.Size(560, 72);
			this.printPreviewBar1.TabIndex = 1;
			// 
			// printPreviewBarButton1
			// 
			this.printPreviewBarButton1.Command = DevExpress.XtraPrinting.PrintingSystemCommand.DocumentMap;
			this.printPreviewBarButton1.Enabled = false;
			this.printPreviewBarButton1.ImageIndex = 19;
			this.printPreviewBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.printPreviewBarButton1.ToolTipText = "Document Map";
			// 
			// printPreviewBarButton2
			// 
			this.printPreviewBarButton2.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Find;
			this.printPreviewBarButton2.Enabled = false;
			this.printPreviewBarButton2.ImageIndex = 20;
			this.printPreviewBarButton2.ToolTipText = "Search";
			// 
			// printPreviewBarButton3
			// 
			this.printPreviewBarButton3.Command = DevExpress.XtraPrinting.PrintingSystemCommand.HandTool;
			this.printPreviewBarButton3.Enabled = false;
			this.printPreviewBarButton3.ImageIndex = 16;
			this.printPreviewBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.printPreviewBarButton3.ToolTipText = "Hand Tool";
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// printPreviewBarButton4
			// 
			this.printPreviewBarButton4.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Customize;
			this.printPreviewBarButton4.Enabled = false;
			this.printPreviewBarButton4.ImageIndex = 14;
			this.printPreviewBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.printPreviewBarButton4.ToolTipText = "Customize";
			// 
			// printPreviewBarButton5
			// 
			this.printPreviewBarButton5.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Print;
			this.printPreviewBarButton5.Enabled = false;
			this.printPreviewBarButton5.ImageIndex = 0;
			this.printPreviewBarButton5.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.printPreviewBarButton5.ToolTipText = "Print";
			// 
			// printPreviewBarButton6
			// 
			this.printPreviewBarButton6.Command = DevExpress.XtraPrinting.PrintingSystemCommand.PrintDirect;
			this.printPreviewBarButton6.Enabled = false;
			this.printPreviewBarButton6.ImageIndex = 1;
			this.printPreviewBarButton6.ToolTipText = "Print Direct";
			// 
			// printPreviewBarButton7
			// 
			this.printPreviewBarButton7.Command = DevExpress.XtraPrinting.PrintingSystemCommand.PageSetup;
			this.printPreviewBarButton7.Enabled = false;
			this.printPreviewBarButton7.ImageIndex = 2;
			this.printPreviewBarButton7.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.printPreviewBarButton7.ToolTipText = "Page Setup";
			// 
			// printPreviewBarButton8
			// 
			this.printPreviewBarButton8.Command = DevExpress.XtraPrinting.PrintingSystemCommand.EditPageHF;
			this.printPreviewBarButton8.Enabled = false;
			this.printPreviewBarButton8.ImageIndex = 15;
			this.printPreviewBarButton8.ToolTipText = "Header And Footer";
			// 
			// toolBarButton2
			// 
			this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// printPreviewBarButton9
			// 
			this.printPreviewBarButton9.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Magnifier;
			this.printPreviewBarButton9.Enabled = false;
			this.printPreviewBarButton9.ImageIndex = 3;
			this.printPreviewBarButton9.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.printPreviewBarButton9.ToolTipText = "Magnifier";
			// 
			// printPreviewBarButton10
			// 
			this.printPreviewBarButton10.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ZoomIn;
			this.printPreviewBarButton10.Enabled = false;
			this.printPreviewBarButton10.ImageIndex = 4;
			this.printPreviewBarButton10.ToolTipText = "缩小";
			// 
			// printPreviewBarButton11
			// 
			this.printPreviewBarButton11.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ZoomOut;
			this.printPreviewBarButton11.Enabled = false;
			this.printPreviewBarButton11.ImageIndex = 5;
			this.printPreviewBarButton11.ToolTipText = "Zoom Out";
			// 
			// printPreviewBarButton12
			// 
			this.printPreviewBarButton12.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Zoom;
			this.printPreviewBarButton12.Enabled = false;
			this.printPreviewBarButton12.ImageIndex = 6;
			this.printPreviewBarButton12.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
			this.printPreviewBarButton12.ToolTipText = "Zoom";
			// 
			// toolBarButton3
			// 
			this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// printPreviewBarButton13
			// 
			this.printPreviewBarButton13.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ShowFirstPage;
			this.printPreviewBarButton13.Enabled = false;
			this.printPreviewBarButton13.ImageIndex = 7;
			this.printPreviewBarButton13.ToolTipText = "First Page";
			// 
			// printPreviewBarButton14
			// 
			this.printPreviewBarButton14.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ShowPrevPage;
			this.printPreviewBarButton14.Enabled = false;
			this.printPreviewBarButton14.ImageIndex = 8;
			this.printPreviewBarButton14.ToolTipText = "Previous Page";
			// 
			// printPreviewBarButton15
			// 
			this.printPreviewBarButton15.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ShowNextPage;
			this.printPreviewBarButton15.Enabled = false;
			this.printPreviewBarButton15.ImageIndex = 9;
			this.printPreviewBarButton15.ToolTipText = "Next Page";
			// 
			// printPreviewBarButton16
			// 
			this.printPreviewBarButton16.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ShowLastPage;
			this.printPreviewBarButton16.Enabled = false;
			this.printPreviewBarButton16.ImageIndex = 10;
			this.printPreviewBarButton16.ToolTipText = "Last Page";
			// 
			// toolBarButton4
			// 
			this.toolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// printPreviewBarButton17
			// 
			this.printPreviewBarButton17.Command = DevExpress.XtraPrinting.PrintingSystemCommand.MultiplePages;
			this.printPreviewBarButton17.Enabled = false;
			this.printPreviewBarButton17.ImageIndex = 11;
			this.printPreviewBarButton17.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.printPreviewBarButton17.ToolTipText = "Multiple Pages";
			// 
			// printPreviewBarButton18
			// 
			this.printPreviewBarButton18.Command = DevExpress.XtraPrinting.PrintingSystemCommand.FillBackground;
			this.printPreviewBarButton18.Enabled = false;
			this.printPreviewBarButton18.ImageIndex = 12;
			this.printPreviewBarButton18.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.printPreviewBarButton18.ToolTipText = "Background";
			// 
			// printPreviewBarButton19
			// 
			this.printPreviewBarButton19.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Watermark;
			this.printPreviewBarButton19.Enabled = false;
			this.printPreviewBarButton19.ImageIndex = 21;
			this.printPreviewBarButton19.ToolTipText = "Watermark";
			// 
			// toolBarButton5
			// 
			this.toolBarButton5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// printPreviewBarButton20
			// 
			this.printPreviewBarButton20.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportFile;
			this.printPreviewBarButton20.Enabled = false;
			this.printPreviewBarButton20.ImageIndex = 18;
			this.printPreviewBarButton20.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
			this.printPreviewBarButton20.ToolTipText = "Export Document...";
			// 
			// printPreviewBarButton21
			// 
			this.printPreviewBarButton21.Command = DevExpress.XtraPrinting.PrintingSystemCommand.SendFile;
			this.printPreviewBarButton21.Enabled = false;
			this.printPreviewBarButton21.ImageIndex = 17;
			this.printPreviewBarButton21.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
			this.printPreviewBarButton21.ToolTipText = "Send e-mail...";
			// 
			// toolBarButton6
			// 
			this.toolBarButton6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// printPreviewBarButton22
			// 
			this.printPreviewBarButton22.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ClosePreview;
			this.printPreviewBarButton22.Enabled = false;
			this.printPreviewBarButton22.ImageIndex = 13;
			this.printPreviewBarButton22.ToolTipText = "Close Preview";
			// 
			// printControl1
			// 
			this.printControl1.IsMetric = true;
			this.printControl1.Location = new System.Drawing.Point(48, 112);
			this.printControl1.Name = "printControl1";
			this.printControl1.PrintingSystem = this.printingSystem1;
			this.printControl1.Size = new System.Drawing.Size(488, 344);
			this.printControl1.TabIndex = 2;
			this.printControl1.TabStop = false;
			this.printControl1.Text = "printControl1";
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(256, 48);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(160, 56);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			// 
			// helpProvider1
			// 
			this.helpProvider1.HelpNamespace = "G:\\ReleaseFile\\(8-10)ReleaseWithoutCheckCard\\创智智能晨检网络管理系统联机丛书.chm";
			// 
			// textBox1
			// 
			this.helpProvider1.SetHelpKeyword(this.textBox1, "硬件");
			this.helpProvider1.SetHelpNavigator(this.textBox1, System.Windows.Forms.HelpNavigator.KeywordIndex);
			this.helpProvider1.SetHelpString(this.textBox1, "");
			this.textBox1.Location = new System.Drawing.Point(440, 80);
			this.textBox1.Name = "textBox1";
			this.helpProvider1.SetShowHelp(this.textBox1, true);
			this.textBox1.TabIndex = 4;
			this.textBox1.Text = "textBox1";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(560, 445);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.printControl1);
			this.Controls.Add(this.printPreviewBar1);
			this.Controls.Add(this.button1);
			this.helpProvider1.SetHelpString(this, "");
			this.Name = "Form1";
			this.helpProvider1.SetShowHelp(this, false);
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion



		//利用委托处理串口数据
		private delegate void HandleComData(byte[] morningCheckData);

		private void InsertMorningCheckData(byte[] morningCheckData)
		{
			try
			{
				DataFrame dataFrame = DataFrame.convertToFrame(morningCheckData);

				new MorningCheckInfoSystem().InsertMorningCheckInfo(dataFrame);

				comPortIsBusy = true;
				handleComClass.WriteSerialCmd(Form1.CONTROL_FRAME_LENGTH,responseFrame.convertToBytes());
				comPortIsBusy = false;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			throw new Exception("tex");
//			Rectangle r = new Rectangle(0, 0, 150, 50);
//			string caption = "Hello World!";
//
//
//
//			printingSystem1.Begin();
//			BrickGraphics g = printingSystem1.Graph;
//
//			g.BackColor = Color.White;
//			g.BorderColor = Color.Black;
//			g.Font = g.DefaultFont;
//			g.StringFormat = g.StringFormat.ChangeLineAlignment(StringAlignment.Near);
//			g.DrawString(caption, Color.Black, r, BorderSide.None);
//
//			printingSystem1.End();
//
//			Graphics gra = groupBox1.CreateGraphics();
//
////			DataFrame timeSynchFrame = new DataFrame();
////			timeSynchFrame.sym = new byte[]{(byte)'@',(byte)'@'};
////			timeSynchFrame.desAddr = 1;
////			timeSynchFrame.comFrameLen = 15;
////			timeSynchFrame.srcAddr = 0;
////			timeSynchFrame.protocol = Form1.TIME_SYNCH_TOKEN;
////			timeSynchFrame.seq = Form1.FRAME_SEQUENCE_VALUE;
////			
////			timeSynchFrame.frameData = new byte[7];
////			timeSynchFrame.frameData[0] = (byte)(DateTime.Now.Year%100);//2位年数
////			timeSynchFrame.frameData[1] = (byte)DateTime.Now.Month;//月
////			timeSynchFrame.frameData[2] = (byte)DateTime.Now.Day;//日
////			timeSynchFrame.frameData[3] = (byte)DateTime.Now.DayOfWeek;//星期
////			timeSynchFrame.frameData[4] = (byte)DateTime.Now.Hour;//时
////			timeSynchFrame.frameData[5] = (byte)DateTime.Now.Minute;//分
////			timeSynchFrame.frameData[6] = (byte)DateTime.Now.Second;//秒
////			timeSynchFrame.computeCheckSum();
////
////			comPortIsBusy = true;
////			handleComClass.WriteSerialCmd(timeSynchFrame.comFrameLen,timeSynchFrame.frameToBytes());
////			comPortIsBusy = false;
//
//			ControlFrame controlFrame = new ControlFrame();
//			controlFrame.sym = new byte[]{(byte)'*',(byte)'*'};
//			controlFrame.desAddr = 1;
//			controlFrame.srcAddr = 0;
//			controlFrame.response = Form1.QUERY_TOKEN;
//			controlFrame.seq = Form1.FRAME_SEQUENCE_VALUE;
//			controlFrame.computeCheckSum();
//
//			handleComClass.WriteSerialCmd(Form1.CONTROL_FRAME_LENGTH,controlFrame.convertToBytes());//发送问询帧

//			int num = 1121;
//
//			int tmp = num%100;
//			int tmp0 = num/100;
//			int tmp1=  tmp0/10;
//			tmp1 <<= 4;
//			tmp1 += tmp0%10;
//
//			testEvent test = new testEvent();
//
//			test.SendCardSuccessed += new CPTTProTest.testEvent.SendCardSuccessedHandler(test_SendCardSuccessed);

//			test.testE();

//			DataFrame sendCardFrame = new DataFrame();
//
//			sendCardFrame.sym = new byte[]{(byte)'@',(byte)'@'};
//			sendCardFrame.desAddr = 0;
//			sendCardFrame.comFrameLen = 14;
//			sendCardFrame.frameData = new byte[6];
//			sendCardFrame.seq = Util.FRAME_SEQUENCE_VALUE;
//
//			int stuNumber = 1102;
//			int stuCardNumber;
//			unchecked
//			{
//				stuCardNumber = (int)2202612709;
//			}
//
//
//			sendCardFrame.desAddr = 2;
//			sendCardFrame.protocol = Util.SEND_CARD_SUCCESS_TOKEN;
//
//			sendCardFrame.frameData[0] = (byte)(stuNumber % 100);
//		
//			int tmp = stuNumber / 100;
//			int stuClassNum = tmp / 10;
//			stuClassNum <<= 4;
//			stuClassNum += tmp % 10;
//		
//			sendCardFrame.frameData[1] = (byte)stuClassNum;
//
//			Util.FillCard(sendCardFrame,stuCardNumber,0);
//
//			sendCardFrame.computeCheckSum();
//
//			handleComClass.WriteSerialCmd(sendCardFrame.comFrameLen,sendCardFrame.frameToBytes());//发送问询帧



		}

		private void handleComClass_DataArrived(int size, ref object vBuf)
		{
			byte[] ReceiveData = (byte[])vBuf;

			if(ReceiveData.Length == 19)//如果是刷卡通讯帧则处理
			{
				handleComData(ReceiveData);
			}
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

		private void test_SendCardSuccessed()
		{
			MessageBox.Show("xx");
		}

		private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			Util.WriteLog(e.Exception.Message.ToString(),Util.EXCEPTION_LOG_TITLE);

			if(DialogResult.Abort == MessageBox.Show("程序发生未知异常,请关闭程序重新打开","系统错误",MessageBoxButtons.AbortRetryIgnore,
				MessageBoxIcon.Warning))
			{
				Application.DoEvents();
				Application.ExitThread();
			}
		}
	}
}
