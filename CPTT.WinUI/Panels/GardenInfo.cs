//==================================================================================
// 创智智能晨检网络管理系统4.0
//==================================================================================
// Copyright @2005 Shanghai Chuangzhi Toy&Technology Corporation All rights reserved.
//本计算机程序受版权法和国际条约保护.
// 如未经授权而擅自复制或传播本程序(或其中任何部分),将受到严厉的民事及刑事制裁,
//并将在法律许可的范围内受到最大程度的起诉!
//==================================================================================

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using DevExpress.XtraEditors;

using CPTT.BusinessFacade;
using CPTT.SystemFramework;

namespace CPTT.WinUI.Panels
{
	/// <summary>
	/// Summary description for GardenInfo.
	/// </summary>
	public class GardenInfo : DevExpress.XtraEditors.XtraUserControl
	{
		private DevExpress.XtraEditors.GroupControl groupControl_GardenInfo;
		private DevExpress.Utils.Frames.NotePanel pnlHint_GardenName;
		private DevExpress.XtraEditors.SimpleButton simpleButton_GardenInfoSave;
		private DevExpress.XtraEditors.TextEdit textEdit_GardenName;
		private DevExpress.Utils.Frames.NotePanel notePanel_GardenAddress;
		private DevExpress.Utils.Frames.NotePanel notePanel_GardenContact;
		private DevExpress.Utils.Frames.NotePanel notePanel_GardenRemark;
		private DevExpress.Utils.Frames.NotePanel notePanel_GardenInfoTitle;
		private DevExpress.XtraEditors.TextEdit textEdit_GardenAddress;
		private DevExpress.XtraEditors.TextEdit textEdit_GardenContact;
		private DevExpress.XtraEditors.SimpleButton simpleButton_GardenInfoReset;
		private DevExpress.Utils.Frames.NotePanel notePanel1;
		private DevExpress.Utils.Frames.NotePanel notePanel4;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl_GradeClassInfo;
		private DevExpress.XtraTab.XtraTabControl xtraTabControl_GradeInfo;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage_AddGrade;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage_GradeModify;
		private DevExpress.XtraTab.XtraTabControl xtraTabControl_ClassInfo;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage_ClassAdd;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage_ClassModify;
		private DevExpress.Utils.Frames.NotePanel notePanel_GradeName;
		private DevExpress.Utils.Frames.NotePanel notePanel_GradeRemark;
		private DevExpress.XtraEditors.TextEdit textEdit_GradeName;
		private DevExpress.XtraEditors.SimpleButton simpleButton_GradeInfoSave;
		private DevExpress.XtraEditors.SimpleButton simpleButton_ClassSave;
		private DevExpress.XtraEditors.TextEdit textEdit_ClassName;
		private DevExpress.Utils.Frames.NotePanel notePanel_ClassName;
		private DevExpress.Utils.Frames.NotePanel notePanel_ClassRemark;
		private DevExpress.XtraEditors.TextEdit textEdit_ClassRemark;
		private DevExpress.XtraEditors.SimpleButton simpleButton_ClassReSet;
		private DevExpress.Utils.Frames.NotePanel notePanel_GradeNameModify;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_GradeModify;
		private DevExpress.Utils.Frames.NotePanel notePanel_GradeModify;
		private DevExpress.XtraEditors.SimpleButton simpleButton_GradeModify;
		private DevExpress.XtraEditors.SimpleButton simpleButton_GradeModiReset;
		private DevExpress.XtraEditors.SimpleButton simpleButton_ClassModi;
		private DevExpress.XtraEditors.SimpleButton simpleButton_ClassModiReset;
		private DevExpress.XtraEditors.TextEdit textEdit_ClassModifyRemark;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_ClassNameModify;
		private DevExpress.Utils.Frames.NotePanel notePanel_ClassModifyName;
		private DevExpress.Utils.Frames.NotePanel notePanel_ClassModifyRemark;
		private System.Windows.Forms.Label label_ReqOfGarName;
		private System.Windows.Forms.Label label_ReqOfGadeName;
		private System.Windows.Forms.Label label_ReqOfGadeMdiName;
		private System.Windows.Forms.Label label_ReqOfClassName;
		private System.Windows.Forms.Label label_ReqOfClassMdiName;
		private DevExpress.Utils.Frames.NotePanel notePanel2;
		private DevExpress.XtraBars.PopupMenu popupMenu1;
		private DevExpress.XtraBars.BarManager barManager1;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
		private DevExpress.XtraBars.BarButtonItem barButtonItem1;
		private System.Windows.Forms.OpenFileDialog openFileDialog_SaveImage;
		private DevExpress.XtraEditors.PictureEdit pictureEdit_GardenImage;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private DevExpress.XtraEditors.TextEdit textEdit_GardenRegCode;
		private DevExpress.XtraEditors.TextEdit textEdit_GardenFeature;

		private DataSet gardenInfo;
		private System.Windows.Forms.Label label1;
		private DevExpress.Utils.Frames.NotePanel notePanel_GradeForClass;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
		private DevExpress.Utils.Frames.NotePanel notePanel3;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.SimpleButton simpleButton_DeleteClass;
		private DevExpress.XtraEditors.SimpleButton simpleButton_DeleteGrade;
		private DevExpress.XtraEditors.SimpleButton simpleButton_GradeInfoReset;
		private byte[] writeInImage;
		private DataSet gradeInfoList;
		private DataSet classesInfoList;
		private int gradeID;
		private DevExpress.XtraEditors.RadioGroup radioGroup_Grade;
		private DevExpress.XtraEditors.RadioGroup radioGroup_Class;
		private DevExpress.Utils.Frames.NotePanel notePanel5;
		private DevExpress.Utils.Frames.NotePanel notePanel6;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_GradeRemark;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_GradeRemarkModify;
		private System.Windows.Forms.HelpProvider helpProvider_GardenInfo;
		private DevExpress.Utils.Frames.NotePanel notePanel_gradeNumber;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_gradeNumber;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_classNumber;
		private DevExpress.Utils.Frames.NotePanel notePanel_classNumber;
		private System.Windows.Forms.Label label4;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_GradeForClass;
		private DevExpress.XtraEditors.SimpleButton smbSave;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.XtraGrid.GridControl gdMachineInfo;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraEditors.TextEdit txtVol;
		private DevExpress.Utils.Frames.NotePanel notePanel8;
		private DevExpress.XtraEditors.TextEdit txtTerminal;
		private DevExpress.Utils.Frames.NotePanel notePanel7;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage_Machine;
		private DevExpress.XtraEditors.SimpleButton smbDelete;
		private int classID;

		public GardenInfo()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call
			LoadGardenInfo();

			helpProvider_GardenInfo.HelpNamespace = Path.GetDirectoryName(Application.ExecutablePath)
				+ CPTT.SystemFramework.Util.HELP_FILE_NAME;

			this.helpProvider_GardenInfo.SetHelpKeyword(this,"园所信息管理");
			this.helpProvider_GardenInfo.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.KeywordIndex);
			this.helpProvider_GardenInfo.SetHelpString(this, "");
			this.helpProvider_GardenInfo.SetShowHelp(this, true);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(GardenInfo));
			this.groupControl_GardenInfo = new DevExpress.XtraEditors.GroupControl();
			this.pictureEdit_GardenImage = new DevExpress.XtraEditors.PictureEdit();
			this.barManager1 = new DevExpress.XtraBars.BarManager();
			this.popupMenu1 = new DevExpress.XtraBars.PopupMenu();
			this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			this.textEdit_GardenFeature = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_GardenRegCode = new DevExpress.XtraEditors.TextEdit();
			this.notePanel2 = new DevExpress.Utils.Frames.NotePanel();
			this.label_ReqOfGarName = new System.Windows.Forms.Label();
			this.simpleButton_GardenInfoSave = new DevExpress.XtraEditors.SimpleButton();
			this.textEdit_GardenName = new DevExpress.XtraEditors.TextEdit();
			this.pnlHint_GardenName = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_GardenAddress = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_GardenContact = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_GardenRemark = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_GardenInfoTitle = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_GardenAddress = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_GardenContact = new DevExpress.XtraEditors.TextEdit();
			this.simpleButton_GardenInfoReset = new DevExpress.XtraEditors.SimpleButton();
			this.splitContainerControl_GradeClassInfo = new DevExpress.XtraEditors.SplitContainerControl();
			this.xtraTabControl_GradeInfo = new DevExpress.XtraTab.XtraTabControl();
			this.xtraTabPage_AddGrade = new DevExpress.XtraTab.XtraTabPage();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBoxEdit_gradeNumber = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_gradeNumber = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_GradeRemark = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel5 = new DevExpress.Utils.Frames.NotePanel();
			this.radioGroup_Grade = new DevExpress.XtraEditors.RadioGroup();
			this.label_ReqOfGadeName = new System.Windows.Forms.Label();
			this.simpleButton_GradeInfoSave = new DevExpress.XtraEditors.SimpleButton();
			this.textEdit_GradeName = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_GradeName = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_GradeRemark = new DevExpress.Utils.Frames.NotePanel();
			this.simpleButton_GradeInfoReset = new DevExpress.XtraEditors.SimpleButton();
			this.xtraTabPage_GradeModify = new DevExpress.XtraTab.XtraTabPage();
			this.comboBoxEdit_GradeRemarkModify = new DevExpress.XtraEditors.ComboBoxEdit();
			this.label_ReqOfGadeMdiName = new System.Windows.Forms.Label();
			this.simpleButton_GradeModify = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_GradeModiReset = new DevExpress.XtraEditors.SimpleButton();
			this.comboBoxEdit_GradeModify = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_GradeNameModify = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_GradeModify = new DevExpress.Utils.Frames.NotePanel();
			this.simpleButton_DeleteGrade = new DevExpress.XtraEditors.SimpleButton();
			this.xtraTabPage_Machine = new DevExpress.XtraTab.XtraTabPage();
			this.smbDelete = new DevExpress.XtraEditors.SimpleButton();
			this.smbSave = new DevExpress.XtraEditors.SimpleButton();
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.gdMachineInfo = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.txtVol = new DevExpress.XtraEditors.TextEdit();
			this.notePanel8 = new DevExpress.Utils.Frames.NotePanel();
			this.txtTerminal = new DevExpress.XtraEditors.TextEdit();
			this.notePanel7 = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel1 = new DevExpress.Utils.Frames.NotePanel();
			this.xtraTabControl_ClassInfo = new DevExpress.XtraTab.XtraTabControl();
			this.xtraTabPage_ClassAdd = new DevExpress.XtraTab.XtraTabPage();
			this.label4 = new System.Windows.Forms.Label();
			this.comboBoxEdit_classNumber = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_classNumber = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel6 = new DevExpress.Utils.Frames.NotePanel();
			this.label_ReqOfClassName = new System.Windows.Forms.Label();
			this.simpleButton_ClassSave = new DevExpress.XtraEditors.SimpleButton();
			this.textEdit_ClassName = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_ClassRemark = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_ClassRemark = new DevExpress.XtraEditors.TextEdit();
			this.simpleButton_ClassReSet = new DevExpress.XtraEditors.SimpleButton();
			this.notePanel_ClassName = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_GradeForClass = new DevExpress.Utils.Frames.NotePanel();
			this.label1 = new System.Windows.Forms.Label();
			this.radioGroup_Class = new DevExpress.XtraEditors.RadioGroup();
			this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
			this.xtraTabPage_ClassModify = new DevExpress.XtraTab.XtraTabPage();
			this.comboBoxEdit_GradeForClass = new DevExpress.XtraEditors.ComboBoxEdit();
			this.label_ReqOfClassMdiName = new System.Windows.Forms.Label();
			this.simpleButton_ClassModi = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_ClassModiReset = new DevExpress.XtraEditors.SimpleButton();
			this.textEdit_ClassModifyRemark = new DevExpress.XtraEditors.TextEdit();
			this.comboBoxEdit_ClassNameModify = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_ClassModifyName = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_ClassModifyRemark = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel3 = new DevExpress.Utils.Frames.NotePanel();
			this.label2 = new System.Windows.Forms.Label();
			this.simpleButton_DeleteClass = new DevExpress.XtraEditors.SimpleButton();
			this.notePanel4 = new DevExpress.Utils.Frames.NotePanel();
			this.openFileDialog_SaveImage = new System.Windows.Forms.OpenFileDialog();
			this.helpProvider_GardenInfo = new System.Windows.Forms.HelpProvider();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_GardenInfo)).BeginInit();
			this.groupControl_GardenInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureEdit_GardenImage.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_GardenFeature.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_GardenRegCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_GardenName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_GardenAddress.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_GardenContact.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl_GradeClassInfo)).BeginInit();
			this.splitContainerControl_GradeClassInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_GradeInfo)).BeginInit();
			this.xtraTabControl_GradeInfo.SuspendLayout();
			this.xtraTabPage_AddGrade.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_gradeNumber.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_GradeRemark.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.radioGroup_Grade.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_GradeName.Properties)).BeginInit();
			this.xtraTabPage_GradeModify.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_GradeRemarkModify.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_GradeModify.Properties)).BeginInit();
			this.xtraTabPage_Machine.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gdMachineInfo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtVol.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTerminal.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_ClassInfo)).BeginInit();
			this.xtraTabControl_ClassInfo.SuspendLayout();
			this.xtraTabPage_ClassAdd.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_classNumber.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_ClassName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_ClassRemark.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.radioGroup_Class.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
			this.xtraTabPage_ClassModify.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_GradeForClass.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_ClassModifyRemark.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_ClassNameModify.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// groupControl_GardenInfo
			// 
			this.groupControl_GardenInfo.Controls.Add(this.pictureEdit_GardenImage);
			this.groupControl_GardenInfo.Controls.Add(this.textEdit_GardenFeature);
			this.groupControl_GardenInfo.Controls.Add(this.textEdit_GardenRegCode);
			this.groupControl_GardenInfo.Controls.Add(this.notePanel2);
			this.groupControl_GardenInfo.Controls.Add(this.label_ReqOfGarName);
			this.groupControl_GardenInfo.Controls.Add(this.simpleButton_GardenInfoSave);
			this.groupControl_GardenInfo.Controls.Add(this.textEdit_GardenName);
			this.groupControl_GardenInfo.Controls.Add(this.pnlHint_GardenName);
			this.groupControl_GardenInfo.Controls.Add(this.notePanel_GardenAddress);
			this.groupControl_GardenInfo.Controls.Add(this.notePanel_GardenContact);
			this.groupControl_GardenInfo.Controls.Add(this.notePanel_GardenRemark);
			this.groupControl_GardenInfo.Controls.Add(this.notePanel_GardenInfoTitle);
			this.groupControl_GardenInfo.Controls.Add(this.textEdit_GardenAddress);
			this.groupControl_GardenInfo.Controls.Add(this.textEdit_GardenContact);
			this.groupControl_GardenInfo.Controls.Add(this.simpleButton_GardenInfoReset);
			this.groupControl_GardenInfo.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_GardenInfo.Location = new System.Drawing.Point(0, 0);
			this.groupControl_GardenInfo.Name = "groupControl_GardenInfo";
			this.groupControl_GardenInfo.Size = new System.Drawing.Size(772, 256);
			this.groupControl_GardenInfo.TabIndex = 0;
			this.groupControl_GardenInfo.Text = "请录入园所基本信息";
			// 
			// pictureEdit_GardenImage
			// 
			this.pictureEdit_GardenImage.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.pictureEdit_GardenImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureEdit_GardenImage.BackgroundImage")));
			this.pictureEdit_GardenImage.Location = new System.Drawing.Point(536, 56);
			this.pictureEdit_GardenImage.MenuManager = this.barManager1;
			this.pictureEdit_GardenImage.Name = "pictureEdit_GardenImage";
			this.barManager1.SetPopupContextMenu(this.pictureEdit_GardenImage, this.popupMenu1);
			// 
			// pictureEdit_GardenImage.Properties
			// 
			this.pictureEdit_GardenImage.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.pictureEdit_GardenImage.Properties.Appearance.Options.UseBackColor = true;
			this.pictureEdit_GardenImage.Properties.NullText = "指定位置没有找到园所图片";
			this.pictureEdit_GardenImage.Size = new System.Drawing.Size(192, 152);
			this.pictureEdit_GardenImage.TabIndex = 9;
			// 
			// barManager1
			// 
			this.barManager1.DockControls.Add(this.barDockControlTop);
			this.barManager1.DockControls.Add(this.barDockControlBottom);
			this.barManager1.DockControls.Add(this.barDockControlLeft);
			this.barManager1.DockControls.Add(this.barDockControlRight);
			this.barManager1.Form = this;
			this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
																				  this.barButtonItem1});
			this.barManager1.MaxItemId = 1;
			// 
			// popupMenu1
			// 
			this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
																									new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
			this.popupMenu1.Manager = this.barManager1;
			this.popupMenu1.Name = "popupMenu1";
			// 
			// barButtonItem1
			// 
			this.barButtonItem1.Caption = " 加载图片";
			this.barButtonItem1.Id = 0;
			this.barButtonItem1.Name = "barButtonItem1";
			this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
			// 
			// textEdit_GardenFeature
			// 
			this.textEdit_GardenFeature.EditValue = "";
			this.textEdit_GardenFeature.Location = new System.Drawing.Point(120, 184);
			this.textEdit_GardenFeature.Name = "textEdit_GardenFeature";
			this.textEdit_GardenFeature.Size = new System.Drawing.Size(392, 23);
			this.textEdit_GardenFeature.TabIndex = 8;
			// 
			// textEdit_GardenRegCode
			// 
			this.textEdit_GardenRegCode.EditValue = "";
			this.textEdit_GardenRegCode.Location = new System.Drawing.Point(120, 88);
			this.textEdit_GardenRegCode.Name = "textEdit_GardenRegCode";
			this.textEdit_GardenRegCode.Size = new System.Drawing.Size(392, 23);
			this.textEdit_GardenRegCode.TabIndex = 7;
			// 
			// notePanel2
			// 
			this.notePanel2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel2.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel2.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel2.ForeColor = System.Drawing.Color.Black;
			this.notePanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel2.Location = new System.Drawing.Point(24, 88);
			this.notePanel2.MaxRows = 5;
			this.notePanel2.Name = "notePanel2";
			this.notePanel2.ParentAutoHeight = true;
			this.notePanel2.Size = new System.Drawing.Size(80, 22);
			this.notePanel2.TabIndex = 6;
			this.notePanel2.TabStop = false;
			this.notePanel2.Text = "园所代码:";
			// 
			// label_ReqOfGarName
			// 
			this.label_ReqOfGarName.ForeColor = System.Drawing.Color.Red;
			this.label_ReqOfGarName.Location = new System.Drawing.Point(8, 56);
			this.label_ReqOfGarName.Name = "label_ReqOfGarName";
			this.label_ReqOfGarName.Size = new System.Drawing.Size(16, 16);
			this.label_ReqOfGarName.TabIndex = 5;
			this.label_ReqOfGarName.Text = "*";
			this.label_ReqOfGarName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// simpleButton_GardenInfoSave
			// 
			this.simpleButton_GardenInfoSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.simpleButton_GardenInfoSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
			this.simpleButton_GardenInfoSave.Appearance.Options.UseFont = true;
			this.simpleButton_GardenInfoSave.Location = new System.Drawing.Point(552, 216);
			this.simpleButton_GardenInfoSave.Name = "simpleButton_GardenInfoSave";
			this.simpleButton_GardenInfoSave.Size = new System.Drawing.Size(72, 24);
			this.simpleButton_GardenInfoSave.TabIndex = 4;
			this.simpleButton_GardenInfoSave.Text = "保存";
			this.simpleButton_GardenInfoSave.Click += new System.EventHandler(this.simpleButton_GardenInfoSave_Click);
			// 
			// textEdit_GardenName
			// 
			this.textEdit_GardenName.EditValue = "";
			this.textEdit_GardenName.Location = new System.Drawing.Point(120, 56);
			this.textEdit_GardenName.Name = "textEdit_GardenName";
			this.textEdit_GardenName.Size = new System.Drawing.Size(392, 23);
			this.textEdit_GardenName.TabIndex = 2;
			// 
			// pnlHint_GardenName
			// 
			this.pnlHint_GardenName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.pnlHint_GardenName.BackColor2 = System.Drawing.Color.DarkGray;
			this.pnlHint_GardenName.Font = new System.Drawing.Font("Tahoma", 8F);
			this.pnlHint_GardenName.ForeColor = System.Drawing.Color.Black;
			this.pnlHint_GardenName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.pnlHint_GardenName.Location = new System.Drawing.Point(24, 56);
			this.pnlHint_GardenName.MaxRows = 5;
			this.pnlHint_GardenName.Name = "pnlHint_GardenName";
			this.pnlHint_GardenName.ParentAutoHeight = true;
			this.pnlHint_GardenName.Size = new System.Drawing.Size(80, 22);
			this.pnlHint_GardenName.TabIndex = 1;
			this.pnlHint_GardenName.TabStop = false;
			this.pnlHint_GardenName.Text = "园所名称:";
			// 
			// notePanel_GardenAddress
			// 
			this.notePanel_GardenAddress.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_GardenAddress.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_GardenAddress.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_GardenAddress.ForeColor = System.Drawing.Color.Black;
			this.notePanel_GardenAddress.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_GardenAddress.Location = new System.Drawing.Point(24, 120);
			this.notePanel_GardenAddress.MaxRows = 5;
			this.notePanel_GardenAddress.Name = "notePanel_GardenAddress";
			this.notePanel_GardenAddress.ParentAutoHeight = true;
			this.notePanel_GardenAddress.Size = new System.Drawing.Size(80, 22);
			this.notePanel_GardenAddress.TabIndex = 1;
			this.notePanel_GardenAddress.TabStop = false;
			this.notePanel_GardenAddress.Text = "园所地址:";
			// 
			// notePanel_GardenContact
			// 
			this.notePanel_GardenContact.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_GardenContact.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_GardenContact.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_GardenContact.ForeColor = System.Drawing.Color.Black;
			this.notePanel_GardenContact.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_GardenContact.Location = new System.Drawing.Point(24, 152);
			this.notePanel_GardenContact.MaxRows = 5;
			this.notePanel_GardenContact.Name = "notePanel_GardenContact";
			this.notePanel_GardenContact.ParentAutoHeight = true;
			this.notePanel_GardenContact.Size = new System.Drawing.Size(80, 22);
			this.notePanel_GardenContact.TabIndex = 1;
			this.notePanel_GardenContact.TabStop = false;
			this.notePanel_GardenContact.Text = "联系方式:";
			// 
			// notePanel_GardenRemark
			// 
			this.notePanel_GardenRemark.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_GardenRemark.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_GardenRemark.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_GardenRemark.ForeColor = System.Drawing.Color.Black;
			this.notePanel_GardenRemark.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_GardenRemark.Location = new System.Drawing.Point(24, 184);
			this.notePanel_GardenRemark.MaxRows = 5;
			this.notePanel_GardenRemark.Name = "notePanel_GardenRemark";
			this.notePanel_GardenRemark.ParentAutoHeight = true;
			this.notePanel_GardenRemark.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.notePanel_GardenRemark.Size = new System.Drawing.Size(80, 22);
			this.notePanel_GardenRemark.TabIndex = 1;
			this.notePanel_GardenRemark.TabStop = false;
			this.notePanel_GardenRemark.Text = "园所特色";
			// 
			// notePanel_GardenInfoTitle
			// 
			this.notePanel_GardenInfoTitle.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel_GardenInfoTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel_GardenInfoTitle.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel_GardenInfoTitle.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_GardenInfoTitle.Location = new System.Drawing.Point(3, 18);
			this.notePanel_GardenInfoTitle.MaxRows = 5;
			this.notePanel_GardenInfoTitle.Name = "notePanel_GardenInfoTitle";
			this.notePanel_GardenInfoTitle.ParentAutoHeight = true;
			this.notePanel_GardenInfoTitle.Size = new System.Drawing.Size(766, 23);
			this.notePanel_GardenInfoTitle.TabIndex = 1;
			this.notePanel_GardenInfoTitle.TabStop = false;
			this.notePanel_GardenInfoTitle.Text = "请仔细填写资料,以便我们的客服人员能更好的为您服务.谢谢合作!";
			// 
			// textEdit_GardenAddress
			// 
			this.textEdit_GardenAddress.EditValue = "";
			this.textEdit_GardenAddress.Location = new System.Drawing.Point(120, 120);
			this.textEdit_GardenAddress.Name = "textEdit_GardenAddress";
			this.textEdit_GardenAddress.Size = new System.Drawing.Size(392, 23);
			this.textEdit_GardenAddress.TabIndex = 2;
			// 
			// textEdit_GardenContact
			// 
			this.textEdit_GardenContact.EditValue = "";
			this.textEdit_GardenContact.Location = new System.Drawing.Point(120, 152);
			this.textEdit_GardenContact.Name = "textEdit_GardenContact";
			this.textEdit_GardenContact.Size = new System.Drawing.Size(392, 23);
			this.textEdit_GardenContact.TabIndex = 2;
			// 
			// simpleButton_GardenInfoReset
			// 
			this.simpleButton_GardenInfoReset.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.simpleButton_GardenInfoReset.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
			this.simpleButton_GardenInfoReset.Appearance.Options.UseFont = true;
			this.simpleButton_GardenInfoReset.Location = new System.Drawing.Point(640, 216);
			this.simpleButton_GardenInfoReset.Name = "simpleButton_GardenInfoReset";
			this.simpleButton_GardenInfoReset.Size = new System.Drawing.Size(72, 24);
			this.simpleButton_GardenInfoReset.TabIndex = 4;
			this.simpleButton_GardenInfoReset.Text = "重置";
			this.simpleButton_GardenInfoReset.Click += new System.EventHandler(this.simpleButton_GardenInfoReset_Click);
			// 
			// splitContainerControl_GradeClassInfo
			// 
			this.splitContainerControl_GradeClassInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl_GradeClassInfo.Location = new System.Drawing.Point(0, 256);
			this.splitContainerControl_GradeClassInfo.Name = "splitContainerControl_GradeClassInfo";
			this.splitContainerControl_GradeClassInfo.Panel1.Controls.Add(this.xtraTabControl_GradeInfo);
			this.splitContainerControl_GradeClassInfo.Panel1.Controls.Add(this.notePanel1);
			this.splitContainerControl_GradeClassInfo.Panel1.Text = "splitContainerControl1_Panel1";
			this.splitContainerControl_GradeClassInfo.Panel2.Controls.Add(this.xtraTabControl_ClassInfo);
			this.splitContainerControl_GradeClassInfo.Panel2.Controls.Add(this.notePanel4);
			this.splitContainerControl_GradeClassInfo.Panel2.Text = "splitContainerControl1_Panel2";
			this.splitContainerControl_GradeClassInfo.Size = new System.Drawing.Size(772, 284);
			this.splitContainerControl_GradeClassInfo.SplitterPosition = 364;
			this.splitContainerControl_GradeClassInfo.TabIndex = 1;
			this.splitContainerControl_GradeClassInfo.Text = "splitContainerControl1";
			// 
			// xtraTabControl_GradeInfo
			// 
			this.xtraTabControl_GradeInfo.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.xtraTabControl_GradeInfo.Appearance.Options.UseBackColor = true;
			this.xtraTabControl_GradeInfo.AppearancePage.HeaderActive.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.xtraTabControl_GradeInfo.AppearancePage.HeaderActive.ForeColor = System.Drawing.Color.DarkOrange;
			this.xtraTabControl_GradeInfo.AppearancePage.HeaderActive.Options.UseFont = true;
			this.xtraTabControl_GradeInfo.AppearancePage.HeaderActive.Options.UseForeColor = true;
			this.xtraTabControl_GradeInfo.Controls.Add(this.xtraTabPage_AddGrade);
			this.xtraTabControl_GradeInfo.Controls.Add(this.xtraTabPage_GradeModify);
			this.xtraTabControl_GradeInfo.Controls.Add(this.xtraTabPage_Machine);
			this.xtraTabControl_GradeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.xtraTabControl_GradeInfo.Location = new System.Drawing.Point(0, 23);
			this.xtraTabControl_GradeInfo.Name = "xtraTabControl_GradeInfo";
			this.xtraTabControl_GradeInfo.SelectedTabPage = this.xtraTabPage_Machine;
			this.xtraTabControl_GradeInfo.Size = new System.Drawing.Size(358, 255);
			this.xtraTabControl_GradeInfo.TabIndex = 6;
			this.xtraTabControl_GradeInfo.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
																									 this.xtraTabPage_AddGrade,
																									 this.xtraTabPage_GradeModify,
																									 this.xtraTabPage_Machine});
			this.xtraTabControl_GradeInfo.Text = "年级资料";
			// 
			// xtraTabPage_AddGrade
			// 
			this.xtraTabPage_AddGrade.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
			this.xtraTabPage_AddGrade.Appearance.PageClient.Options.UseBackColor = true;
			this.xtraTabPage_AddGrade.Controls.Add(this.label3);
			this.xtraTabPage_AddGrade.Controls.Add(this.comboBoxEdit_gradeNumber);
			this.xtraTabPage_AddGrade.Controls.Add(this.notePanel_gradeNumber);
			this.xtraTabPage_AddGrade.Controls.Add(this.comboBoxEdit_GradeRemark);
			this.xtraTabPage_AddGrade.Controls.Add(this.notePanel5);
			this.xtraTabPage_AddGrade.Controls.Add(this.radioGroup_Grade);
			this.xtraTabPage_AddGrade.Controls.Add(this.label_ReqOfGadeName);
			this.xtraTabPage_AddGrade.Controls.Add(this.simpleButton_GradeInfoSave);
			this.xtraTabPage_AddGrade.Controls.Add(this.textEdit_GradeName);
			this.xtraTabPage_AddGrade.Controls.Add(this.notePanel_GradeName);
			this.xtraTabPage_AddGrade.Controls.Add(this.notePanel_GradeRemark);
			this.xtraTabPage_AddGrade.Controls.Add(this.simpleButton_GradeInfoReset);
			this.xtraTabPage_AddGrade.Name = "xtraTabPage_AddGrade";
			this.xtraTabPage_AddGrade.Size = new System.Drawing.Size(354, 230);
			this.xtraTabPage_AddGrade.Text = "添加年级信息";
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(32, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(16, 16);
			this.label3.TabIndex = 26;
			this.label3.Text = "*";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// comboBoxEdit_gradeNumber
			// 
			this.comboBoxEdit_gradeNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxEdit_gradeNumber.EditValue = "";
			this.comboBoxEdit_gradeNumber.Location = new System.Drawing.Point(144, 64);
			this.comboBoxEdit_gradeNumber.Name = "comboBoxEdit_gradeNumber";
			// 
			// comboBoxEdit_gradeNumber.Properties
			// 
			this.comboBoxEdit_gradeNumber.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_gradeNumber.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_gradeNumber.Size = new System.Drawing.Size(171, 23);
			this.comboBoxEdit_gradeNumber.TabIndex = 25;
			// 
			// notePanel_gradeNumber
			// 
			this.notePanel_gradeNumber.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_gradeNumber.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_gradeNumber.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_gradeNumber.ForeColor = System.Drawing.Color.Black;
			this.notePanel_gradeNumber.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_gradeNumber.Location = new System.Drawing.Point(48, 64);
			this.notePanel_gradeNumber.MaxRows = 5;
			this.notePanel_gradeNumber.Name = "notePanel_gradeNumber";
			this.notePanel_gradeNumber.ParentAutoHeight = true;
			this.notePanel_gradeNumber.Size = new System.Drawing.Size(80, 22);
			this.notePanel_gradeNumber.TabIndex = 24;
			this.notePanel_gradeNumber.TabStop = false;
			this.notePanel_gradeNumber.Text = "可用编号";
			// 
			// comboBoxEdit_GradeRemark
			// 
			this.comboBoxEdit_GradeRemark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxEdit_GradeRemark.EditValue = "托班";
			this.comboBoxEdit_GradeRemark.Location = new System.Drawing.Point(144, 96);
			this.comboBoxEdit_GradeRemark.Name = "comboBoxEdit_GradeRemark";
			// 
			// comboBoxEdit_GradeRemark.Properties
			// 
			this.comboBoxEdit_GradeRemark.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_GradeRemark.Properties.Items.AddRange(new object[] {
																					 "托班",
																					 "小班",
																					 "中班",
																					 "大班",
																					 "特色班"});
			this.comboBoxEdit_GradeRemark.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_GradeRemark.Size = new System.Drawing.Size(171, 23);
			this.comboBoxEdit_GradeRemark.TabIndex = 23;
			this.comboBoxEdit_GradeRemark.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_GradeRemark_SelectedIndexChanged);
			// 
			// notePanel5
			// 
			this.notePanel5.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel5.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel5.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel5.ForeColor = System.Drawing.Color.Black;
			this.notePanel5.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel5.Location = new System.Drawing.Point(48, 128);
			this.notePanel5.MaxRows = 5;
			this.notePanel5.Name = "notePanel5";
			this.notePanel5.ParentAutoHeight = true;
			this.notePanel5.Size = new System.Drawing.Size(80, 22);
			this.notePanel5.TabIndex = 8;
			this.notePanel5.TabStop = false;
			this.notePanel5.Text = "选择类型";
			// 
			// radioGroup_Grade
			// 
			this.radioGroup_Grade.EditValue = "0";
			this.radioGroup_Grade.Location = new System.Drawing.Point(144, 128);
			this.radioGroup_Grade.Name = "radioGroup_Grade";
			// 
			// radioGroup_Grade.Properties
			// 
			this.radioGroup_Grade.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
																													 new DevExpress.XtraEditors.Controls.RadioGroupItem("0", "学生年级"),
																													 new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "教师部门")});
			this.radioGroup_Grade.Size = new System.Drawing.Size(168, 32);
			this.radioGroup_Grade.TabIndex = 7;
			this.radioGroup_Grade.SelectedIndexChanged += new System.EventHandler(this.radioGroup_Grade_SelectedIndexChanged);
			// 
			// label_ReqOfGadeName
			// 
			this.label_ReqOfGadeName.ForeColor = System.Drawing.Color.Red;
			this.label_ReqOfGadeName.Location = new System.Drawing.Point(32, 32);
			this.label_ReqOfGadeName.Name = "label_ReqOfGadeName";
			this.label_ReqOfGadeName.Size = new System.Drawing.Size(16, 16);
			this.label_ReqOfGadeName.TabIndex = 6;
			this.label_ReqOfGadeName.Text = "*";
			this.label_ReqOfGadeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// simpleButton_GradeInfoSave
			// 
			this.simpleButton_GradeInfoSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButton_GradeInfoSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
			this.simpleButton_GradeInfoSave.Appearance.Options.UseFont = true;
			this.simpleButton_GradeInfoSave.Location = new System.Drawing.Point(243, 168);
			this.simpleButton_GradeInfoSave.Name = "simpleButton_GradeInfoSave";
			this.simpleButton_GradeInfoSave.Size = new System.Drawing.Size(72, 24);
			this.simpleButton_GradeInfoSave.TabIndex = 5;
			this.simpleButton_GradeInfoSave.Text = "保存";
			this.simpleButton_GradeInfoSave.Click += new System.EventHandler(this.simpleButton_GradeInfoSave_Click);
			// 
			// textEdit_GradeName
			// 
			this.textEdit_GradeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textEdit_GradeName.EditValue = "";
			this.textEdit_GradeName.Location = new System.Drawing.Point(144, 32);
			this.textEdit_GradeName.Name = "textEdit_GradeName";
			this.textEdit_GradeName.Size = new System.Drawing.Size(171, 23);
			this.textEdit_GradeName.TabIndex = 4;
			// 
			// notePanel_GradeName
			// 
			this.notePanel_GradeName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_GradeName.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_GradeName.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_GradeName.ForeColor = System.Drawing.Color.Black;
			this.notePanel_GradeName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_GradeName.Location = new System.Drawing.Point(48, 32);
			this.notePanel_GradeName.MaxRows = 5;
			this.notePanel_GradeName.Name = "notePanel_GradeName";
			this.notePanel_GradeName.ParentAutoHeight = true;
			this.notePanel_GradeName.Size = new System.Drawing.Size(80, 22);
			this.notePanel_GradeName.TabIndex = 3;
			this.notePanel_GradeName.TabStop = false;
			this.notePanel_GradeName.Text = "年级名称";
			// 
			// notePanel_GradeRemark
			// 
			this.notePanel_GradeRemark.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_GradeRemark.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_GradeRemark.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_GradeRemark.ForeColor = System.Drawing.Color.Black;
			this.notePanel_GradeRemark.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_GradeRemark.Location = new System.Drawing.Point(48, 96);
			this.notePanel_GradeRemark.MaxRows = 5;
			this.notePanel_GradeRemark.Name = "notePanel_GradeRemark";
			this.notePanel_GradeRemark.ParentAutoHeight = true;
			this.notePanel_GradeRemark.Size = new System.Drawing.Size(80, 22);
			this.notePanel_GradeRemark.TabIndex = 2;
			this.notePanel_GradeRemark.TabStop = false;
			this.notePanel_GradeRemark.Text = "备        注";
			// 
			// simpleButton_GradeInfoReset
			// 
			this.simpleButton_GradeInfoReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButton_GradeInfoReset.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
			this.simpleButton_GradeInfoReset.Appearance.Options.UseFont = true;
			this.simpleButton_GradeInfoReset.Location = new System.Drawing.Point(243, 200);
			this.simpleButton_GradeInfoReset.Name = "simpleButton_GradeInfoReset";
			this.simpleButton_GradeInfoReset.Size = new System.Drawing.Size(72, 24);
			this.simpleButton_GradeInfoReset.TabIndex = 5;
			this.simpleButton_GradeInfoReset.Text = "重置";
			this.simpleButton_GradeInfoReset.Visible = false;
			this.simpleButton_GradeInfoReset.Click += new System.EventHandler(this.simpleButton_GradeInfoReset_Click);
			// 
			// xtraTabPage_GradeModify
			// 
			this.xtraTabPage_GradeModify.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
			this.xtraTabPage_GradeModify.Appearance.PageClient.Options.UseBackColor = true;
			this.xtraTabPage_GradeModify.Controls.Add(this.comboBoxEdit_GradeRemarkModify);
			this.xtraTabPage_GradeModify.Controls.Add(this.label_ReqOfGadeMdiName);
			this.xtraTabPage_GradeModify.Controls.Add(this.simpleButton_GradeModify);
			this.xtraTabPage_GradeModify.Controls.Add(this.simpleButton_GradeModiReset);
			this.xtraTabPage_GradeModify.Controls.Add(this.comboBoxEdit_GradeModify);
			this.xtraTabPage_GradeModify.Controls.Add(this.notePanel_GradeNameModify);
			this.xtraTabPage_GradeModify.Controls.Add(this.notePanel_GradeModify);
			this.xtraTabPage_GradeModify.Controls.Add(this.simpleButton_DeleteGrade);
			this.xtraTabPage_GradeModify.Name = "xtraTabPage_GradeModify";
			this.xtraTabPage_GradeModify.Size = new System.Drawing.Size(354, 230);
			this.xtraTabPage_GradeModify.Text = "修改年级信息";
			// 
			// comboBoxEdit_GradeRemarkModify
			// 
			this.comboBoxEdit_GradeRemarkModify.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxEdit_GradeRemarkModify.EditValue = "托班";
			this.comboBoxEdit_GradeRemarkModify.Location = new System.Drawing.Point(144, 72);
			this.comboBoxEdit_GradeRemarkModify.Name = "comboBoxEdit_GradeRemarkModify";
			// 
			// comboBoxEdit_GradeRemarkModify.Properties
			// 
			this.comboBoxEdit_GradeRemarkModify.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_GradeRemarkModify.Properties.Items.AddRange(new object[] {
																						   "托班",
																						   "小班",
																						   "中班",
																						   "大班",
																						   "特色班"});
			this.comboBoxEdit_GradeRemarkModify.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_GradeRemarkModify.Size = new System.Drawing.Size(171, 23);
			this.comboBoxEdit_GradeRemarkModify.TabIndex = 23;
			// 
			// label_ReqOfGadeMdiName
			// 
			this.label_ReqOfGadeMdiName.ForeColor = System.Drawing.Color.Red;
			this.label_ReqOfGadeMdiName.Location = new System.Drawing.Point(32, 40);
			this.label_ReqOfGadeMdiName.Name = "label_ReqOfGadeMdiName";
			this.label_ReqOfGadeMdiName.Size = new System.Drawing.Size(16, 16);
			this.label_ReqOfGadeMdiName.TabIndex = 20;
			this.label_ReqOfGadeMdiName.Text = "*";
			this.label_ReqOfGadeMdiName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// simpleButton_GradeModify
			// 
			this.simpleButton_GradeModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButton_GradeModify.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
			this.simpleButton_GradeModify.Appearance.Options.UseFont = true;
			this.simpleButton_GradeModify.Location = new System.Drawing.Point(251, 104);
			this.simpleButton_GradeModify.Name = "simpleButton_GradeModify";
			this.simpleButton_GradeModify.Size = new System.Drawing.Size(64, 24);
			this.simpleButton_GradeModify.TabIndex = 19;
			this.simpleButton_GradeModify.Text = "修改";
			this.simpleButton_GradeModify.Click += new System.EventHandler(this.simpleButton_GradeModify_Click);
			// 
			// simpleButton_GradeModiReset
			// 
			this.simpleButton_GradeModiReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButton_GradeModiReset.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
			this.simpleButton_GradeModiReset.Appearance.Options.UseFont = true;
			this.simpleButton_GradeModiReset.Location = new System.Drawing.Point(251, 136);
			this.simpleButton_GradeModiReset.Name = "simpleButton_GradeModiReset";
			this.simpleButton_GradeModiReset.Size = new System.Drawing.Size(64, 24);
			this.simpleButton_GradeModiReset.TabIndex = 18;
			this.simpleButton_GradeModiReset.Text = "重置";
			this.simpleButton_GradeModiReset.Visible = false;
			this.simpleButton_GradeModiReset.Click += new System.EventHandler(this.simpleButton_GradeModiReset_Click);
			// 
			// comboBoxEdit_GradeModify
			// 
			this.comboBoxEdit_GradeModify.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxEdit_GradeModify.EditValue = "";
			this.comboBoxEdit_GradeModify.Location = new System.Drawing.Point(144, 40);
			this.comboBoxEdit_GradeModify.Name = "comboBoxEdit_GradeModify";
			// 
			// comboBoxEdit_GradeModify.Properties
			// 
			this.comboBoxEdit_GradeModify.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_GradeModify.Size = new System.Drawing.Size(171, 23);
			this.comboBoxEdit_GradeModify.TabIndex = 15;
			this.comboBoxEdit_GradeModify.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_GradeModify_SelectedIndexChanged);
			// 
			// notePanel_GradeNameModify
			// 
			this.notePanel_GradeNameModify.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_GradeNameModify.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_GradeNameModify.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_GradeNameModify.ForeColor = System.Drawing.Color.Black;
			this.notePanel_GradeNameModify.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_GradeNameModify.Location = new System.Drawing.Point(48, 40);
			this.notePanel_GradeNameModify.MaxRows = 5;
			this.notePanel_GradeNameModify.Name = "notePanel_GradeNameModify";
			this.notePanel_GradeNameModify.ParentAutoHeight = true;
			this.notePanel_GradeNameModify.Size = new System.Drawing.Size(80, 22);
			this.notePanel_GradeNameModify.TabIndex = 14;
			this.notePanel_GradeNameModify.TabStop = false;
			this.notePanel_GradeNameModify.Text = "年级名称";
			// 
			// notePanel_GradeModify
			// 
			this.notePanel_GradeModify.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_GradeModify.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_GradeModify.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_GradeModify.ForeColor = System.Drawing.Color.Black;
			this.notePanel_GradeModify.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_GradeModify.Location = new System.Drawing.Point(48, 72);
			this.notePanel_GradeModify.MaxRows = 5;
			this.notePanel_GradeModify.Name = "notePanel_GradeModify";
			this.notePanel_GradeModify.ParentAutoHeight = true;
			this.notePanel_GradeModify.Size = new System.Drawing.Size(80, 22);
			this.notePanel_GradeModify.TabIndex = 14;
			this.notePanel_GradeModify.TabStop = false;
			this.notePanel_GradeModify.Text = "备       注";
			// 
			// simpleButton_DeleteGrade
			// 
			this.simpleButton_DeleteGrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButton_DeleteGrade.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
			this.simpleButton_DeleteGrade.Appearance.Options.UseFont = true;
			this.simpleButton_DeleteGrade.Location = new System.Drawing.Point(179, 136);
			this.simpleButton_DeleteGrade.Name = "simpleButton_DeleteGrade";
			this.simpleButton_DeleteGrade.Size = new System.Drawing.Size(64, 24);
			this.simpleButton_DeleteGrade.TabIndex = 19;
			this.simpleButton_DeleteGrade.Text = "删除";
			this.simpleButton_DeleteGrade.Visible = false;
			this.simpleButton_DeleteGrade.Click += new System.EventHandler(this.simpleButton_DeleteGrade_Click);
			// 
			// xtraTabPage_Machine
			// 
			this.xtraTabPage_Machine.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
			this.xtraTabPage_Machine.Appearance.PageClient.Options.UseBackColor = true;
			this.xtraTabPage_Machine.Controls.Add(this.smbDelete);
			this.xtraTabPage_Machine.Controls.Add(this.smbSave);
			this.xtraTabPage_Machine.Controls.Add(this.groupControl1);
			this.xtraTabPage_Machine.Controls.Add(this.txtVol);
			this.xtraTabPage_Machine.Controls.Add(this.notePanel8);
			this.xtraTabPage_Machine.Controls.Add(this.txtTerminal);
			this.xtraTabPage_Machine.Controls.Add(this.notePanel7);
			this.xtraTabPage_Machine.Name = "xtraTabPage_Machine";
			this.xtraTabPage_Machine.Size = new System.Drawing.Size(354, 230);
			this.xtraTabPage_Machine.Text = "门口机设定";
			// 
			// smbDelete
			// 
			this.smbDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.smbDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
			this.smbDelete.Appearance.Options.UseFont = true;
			this.smbDelete.Location = new System.Drawing.Point(88, 56);
			this.smbDelete.Name = "smbDelete";
			this.smbDelete.Size = new System.Drawing.Size(56, 24);
			this.smbDelete.TabIndex = 32;
			this.smbDelete.Text = "删除";
			this.smbDelete.Click += new System.EventHandler(this.smbDelete_Click);
			// 
			// smbSave
			// 
			this.smbSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.smbSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
			this.smbSave.Appearance.Options.UseFont = true;
			this.smbSave.Location = new System.Drawing.Point(24, 56);
			this.smbSave.Name = "smbSave";
			this.smbSave.Size = new System.Drawing.Size(56, 24);
			this.smbSave.TabIndex = 31;
			this.smbSave.Text = "保存";
			this.smbSave.Click += new System.EventHandler(this.smbSave_Click);
			// 
			// groupControl1
			// 
			this.groupControl1.Controls.Add(this.gdMachineInfo);
			this.groupControl1.Location = new System.Drawing.Point(181, 11);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(160, 208);
			this.groupControl1.TabIndex = 30;
			this.groupControl1.Text = "显示";
			// 
			// gdMachineInfo
			// 
			this.gdMachineInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gdMachineInfo.EmbeddedNavigator
			// 
			this.gdMachineInfo.EmbeddedNavigator.Name = "";
			this.gdMachineInfo.Location = new System.Drawing.Point(3, 18);
			this.gdMachineInfo.MainView = this.gridView1;
			this.gdMachineInfo.Name = "gdMachineInfo";
			this.gdMachineInfo.Size = new System.Drawing.Size(154, 187);
			this.gdMachineInfo.TabIndex = 0;
			this.gdMachineInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										 this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn1});
			this.gridView1.GridControl = this.gdMachineInfo;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsCustomization.AllowFilter = false;
			this.gridView1.OptionsView.ShowFilterPanel = false;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn1
			// 
			this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn1.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.gridColumn1.Caption = "已分配的门口机地址";
			this.gridColumn1.FieldName = "machine_address";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.OptionsColumn.AllowEdit = false;
			this.gridColumn1.OptionsColumn.AllowFocus = false;
			this.gridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn1.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn1.OptionsColumn.FixedWidth = true;
			this.gridColumn1.OptionsColumn.ReadOnly = true;
			this.gridColumn1.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			// 
			// txtVol
			// 
			this.txtVol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtVol.EditValue = "70";
			this.txtVol.Location = new System.Drawing.Point(88, 104);
			this.txtVol.Name = "txtVol";
			this.txtVol.Size = new System.Drawing.Size(75, 23);
			this.txtVol.TabIndex = 29;
			this.txtVol.Visible = false;
			// 
			// notePanel8
			// 
			this.notePanel8.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel8.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel8.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel8.ForeColor = System.Drawing.Color.Black;
			this.notePanel8.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel8.Location = new System.Drawing.Point(8, 104);
			this.notePanel8.MaxRows = 5;
			this.notePanel8.Name = "notePanel8";
			this.notePanel8.ParentAutoHeight = true;
			this.notePanel8.Size = new System.Drawing.Size(72, 22);
			this.notePanel8.TabIndex = 28;
			this.notePanel8.TabStop = false;
			this.notePanel8.Text = "容   量";
			this.notePanel8.Visible = false;
			// 
			// txtTerminal
			// 
			this.txtTerminal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtTerminal.EditValue = "";
			this.txtTerminal.Location = new System.Drawing.Point(93, 19);
			this.txtTerminal.Name = "txtTerminal";
			this.txtTerminal.Size = new System.Drawing.Size(75, 23);
			this.txtTerminal.TabIndex = 27;
			// 
			// notePanel7
			// 
			this.notePanel7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel7.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel7.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel7.ForeColor = System.Drawing.Color.Black;
			this.notePanel7.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel7.Location = new System.Drawing.Point(13, 19);
			this.notePanel7.MaxRows = 5;
			this.notePanel7.Name = "notePanel7";
			this.notePanel7.ParentAutoHeight = true;
			this.notePanel7.Size = new System.Drawing.Size(72, 22);
			this.notePanel7.TabIndex = 26;
			this.notePanel7.TabStop = false;
			this.notePanel7.Text = "门口机";
			// 
			// notePanel1
			// 
			this.notePanel1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel1.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel1.Location = new System.Drawing.Point(0, 0);
			this.notePanel1.MaxRows = 5;
			this.notePanel1.Name = "notePanel1";
			this.notePanel1.ParentAutoHeight = true;
			this.notePanel1.Size = new System.Drawing.Size(358, 23);
			this.notePanel1.TabIndex = 2;
			this.notePanel1.TabStop = false;
			this.notePanel1.Text = "年级资料(*为必须填写)";
			// 
			// xtraTabControl_ClassInfo
			// 
			this.xtraTabControl_ClassInfo.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.xtraTabControl_ClassInfo.Appearance.Options.UseBackColor = true;
			this.xtraTabControl_ClassInfo.AppearancePage.HeaderActive.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.xtraTabControl_ClassInfo.AppearancePage.HeaderActive.ForeColor = System.Drawing.Color.DarkOrange;
			this.xtraTabControl_ClassInfo.AppearancePage.HeaderActive.Options.UseFont = true;
			this.xtraTabControl_ClassInfo.AppearancePage.HeaderActive.Options.UseForeColor = true;
			this.xtraTabControl_ClassInfo.Controls.Add(this.xtraTabPage_ClassAdd);
			this.xtraTabControl_ClassInfo.Controls.Add(this.xtraTabPage_ClassModify);
			this.xtraTabControl_ClassInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.xtraTabControl_ClassInfo.Location = new System.Drawing.Point(0, 23);
			this.xtraTabControl_ClassInfo.Name = "xtraTabControl_ClassInfo";
			this.xtraTabControl_ClassInfo.SelectedTabPage = this.xtraTabPage_ClassAdd;
			this.xtraTabControl_ClassInfo.Size = new System.Drawing.Size(398, 255);
			this.xtraTabControl_ClassInfo.TabIndex = 4;
			this.xtraTabControl_ClassInfo.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
																									 this.xtraTabPage_ClassAdd,
																									 this.xtraTabPage_ClassModify});
			this.xtraTabControl_ClassInfo.Text = "班级资料";
			// 
			// xtraTabPage_ClassAdd
			// 
			this.xtraTabPage_ClassAdd.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
			this.xtraTabPage_ClassAdd.Appearance.PageClient.Options.UseBackColor = true;
			this.xtraTabPage_ClassAdd.Controls.Add(this.label4);
			this.xtraTabPage_ClassAdd.Controls.Add(this.comboBoxEdit_classNumber);
			this.xtraTabPage_ClassAdd.Controls.Add(this.notePanel_classNumber);
			this.xtraTabPage_ClassAdd.Controls.Add(this.notePanel6);
			this.xtraTabPage_ClassAdd.Controls.Add(this.label_ReqOfClassName);
			this.xtraTabPage_ClassAdd.Controls.Add(this.simpleButton_ClassSave);
			this.xtraTabPage_ClassAdd.Controls.Add(this.textEdit_ClassName);
			this.xtraTabPage_ClassAdd.Controls.Add(this.notePanel_ClassRemark);
			this.xtraTabPage_ClassAdd.Controls.Add(this.textEdit_ClassRemark);
			this.xtraTabPage_ClassAdd.Controls.Add(this.simpleButton_ClassReSet);
			this.xtraTabPage_ClassAdd.Controls.Add(this.notePanel_ClassName);
			this.xtraTabPage_ClassAdd.Controls.Add(this.notePanel_GradeForClass);
			this.xtraTabPage_ClassAdd.Controls.Add(this.label1);
			this.xtraTabPage_ClassAdd.Controls.Add(this.radioGroup_Class);
			this.xtraTabPage_ClassAdd.Controls.Add(this.comboBoxEdit1);
			this.xtraTabPage_ClassAdd.Name = "xtraTabPage_ClassAdd";
			this.xtraTabPage_ClassAdd.Size = new System.Drawing.Size(394, 230);
			this.xtraTabPage_ClassAdd.Text = "添加班级信息";
			// 
			// label4
			// 
			this.label4.ForeColor = System.Drawing.Color.Red;
			this.label4.Location = new System.Drawing.Point(48, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(16, 16);
			this.label4.TabIndex = 28;
			this.label4.Text = "*";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// comboBoxEdit_classNumber
			// 
			this.comboBoxEdit_classNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxEdit_classNumber.EditValue = "";
			this.comboBoxEdit_classNumber.Location = new System.Drawing.Point(162, 96);
			this.comboBoxEdit_classNumber.Name = "comboBoxEdit_classNumber";
			// 
			// comboBoxEdit_classNumber.Properties
			// 
			this.comboBoxEdit_classNumber.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_classNumber.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_classNumber.Size = new System.Drawing.Size(179, 23);
			this.comboBoxEdit_classNumber.TabIndex = 27;
			// 
			// notePanel_classNumber
			// 
			this.notePanel_classNumber.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_classNumber.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_classNumber.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_classNumber.ForeColor = System.Drawing.Color.Black;
			this.notePanel_classNumber.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_classNumber.Location = new System.Drawing.Point(66, 96);
			this.notePanel_classNumber.MaxRows = 5;
			this.notePanel_classNumber.Name = "notePanel_classNumber";
			this.notePanel_classNumber.ParentAutoHeight = true;
			this.notePanel_classNumber.Size = new System.Drawing.Size(80, 22);
			this.notePanel_classNumber.TabIndex = 26;
			this.notePanel_classNumber.TabStop = false;
			this.notePanel_classNumber.Text = "可用编号";
			// 
			// notePanel6
			// 
			this.notePanel6.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel6.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel6.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel6.ForeColor = System.Drawing.Color.Black;
			this.notePanel6.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel6.Location = new System.Drawing.Point(64, 160);
			this.notePanel6.MaxRows = 5;
			this.notePanel6.Name = "notePanel6";
			this.notePanel6.ParentAutoHeight = true;
			this.notePanel6.Size = new System.Drawing.Size(80, 22);
			this.notePanel6.TabIndex = 20;
			this.notePanel6.TabStop = false;
			this.notePanel6.Text = "选择类型";
			// 
			// label_ReqOfClassName
			// 
			this.label_ReqOfClassName.ForeColor = System.Drawing.Color.Red;
			this.label_ReqOfClassName.Location = new System.Drawing.Point(48, 64);
			this.label_ReqOfClassName.Name = "label_ReqOfClassName";
			this.label_ReqOfClassName.Size = new System.Drawing.Size(16, 16);
			this.label_ReqOfClassName.TabIndex = 18;
			this.label_ReqOfClassName.Text = "*";
			this.label_ReqOfClassName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// simpleButton_ClassSave
			// 
			this.simpleButton_ClassSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButton_ClassSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
			this.simpleButton_ClassSave.Appearance.Options.UseFont = true;
			this.simpleButton_ClassSave.Location = new System.Drawing.Point(277, 200);
			this.simpleButton_ClassSave.Name = "simpleButton_ClassSave";
			this.simpleButton_ClassSave.Size = new System.Drawing.Size(64, 24);
			this.simpleButton_ClassSave.TabIndex = 17;
			this.simpleButton_ClassSave.Text = "保存";
			this.simpleButton_ClassSave.Click += new System.EventHandler(this.simpleButton_ClassSave_Click);
			// 
			// textEdit_ClassName
			// 
			this.textEdit_ClassName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textEdit_ClassName.EditValue = "";
			this.textEdit_ClassName.Location = new System.Drawing.Point(160, 64);
			this.textEdit_ClassName.Name = "textEdit_ClassName";
			this.textEdit_ClassName.Size = new System.Drawing.Size(181, 23);
			this.textEdit_ClassName.TabIndex = 15;
			// 
			// notePanel_ClassRemark
			// 
			this.notePanel_ClassRemark.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_ClassRemark.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_ClassRemark.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_ClassRemark.ForeColor = System.Drawing.Color.Black;
			this.notePanel_ClassRemark.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_ClassRemark.Location = new System.Drawing.Point(64, 128);
			this.notePanel_ClassRemark.MaxRows = 5;
			this.notePanel_ClassRemark.Name = "notePanel_ClassRemark";
			this.notePanel_ClassRemark.ParentAutoHeight = true;
			this.notePanel_ClassRemark.Size = new System.Drawing.Size(80, 22);
			this.notePanel_ClassRemark.TabIndex = 12;
			this.notePanel_ClassRemark.TabStop = false;
			this.notePanel_ClassRemark.Text = "班级备注";
			// 
			// textEdit_ClassRemark
			// 
			this.textEdit_ClassRemark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textEdit_ClassRemark.EditValue = "";
			this.textEdit_ClassRemark.Location = new System.Drawing.Point(160, 128);
			this.textEdit_ClassRemark.Name = "textEdit_ClassRemark";
			this.textEdit_ClassRemark.Size = new System.Drawing.Size(181, 23);
			this.textEdit_ClassRemark.TabIndex = 14;
			// 
			// simpleButton_ClassReSet
			// 
			this.simpleButton_ClassReSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButton_ClassReSet.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
			this.simpleButton_ClassReSet.Appearance.Options.UseFont = true;
			this.simpleButton_ClassReSet.Location = new System.Drawing.Point(61, 200);
			this.simpleButton_ClassReSet.Name = "simpleButton_ClassReSet";
			this.simpleButton_ClassReSet.Size = new System.Drawing.Size(64, 24);
			this.simpleButton_ClassReSet.TabIndex = 16;
			this.simpleButton_ClassReSet.Text = "重置";
			this.simpleButton_ClassReSet.Visible = false;
			this.simpleButton_ClassReSet.Click += new System.EventHandler(this.simpleButton_ClassReSet_Click);
			// 
			// notePanel_ClassName
			// 
			this.notePanel_ClassName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_ClassName.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_ClassName.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_ClassName.ForeColor = System.Drawing.Color.Black;
			this.notePanel_ClassName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_ClassName.Location = new System.Drawing.Point(64, 64);
			this.notePanel_ClassName.MaxRows = 5;
			this.notePanel_ClassName.Name = "notePanel_ClassName";
			this.notePanel_ClassName.ParentAutoHeight = true;
			this.notePanel_ClassName.Size = new System.Drawing.Size(80, 22);
			this.notePanel_ClassName.TabIndex = 13;
			this.notePanel_ClassName.TabStop = false;
			this.notePanel_ClassName.Text = "班级名称";
			// 
			// notePanel_GradeForClass
			// 
			this.notePanel_GradeForClass.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_GradeForClass.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_GradeForClass.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_GradeForClass.ForeColor = System.Drawing.Color.Black;
			this.notePanel_GradeForClass.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_GradeForClass.Location = new System.Drawing.Point(64, 32);
			this.notePanel_GradeForClass.MaxRows = 5;
			this.notePanel_GradeForClass.Name = "notePanel_GradeForClass";
			this.notePanel_GradeForClass.ParentAutoHeight = true;
			this.notePanel_GradeForClass.Size = new System.Drawing.Size(80, 22);
			this.notePanel_GradeForClass.TabIndex = 13;
			this.notePanel_GradeForClass.TabStop = false;
			this.notePanel_GradeForClass.Text = "所在年级";
			// 
			// label1
			// 
			this.label1.ForeColor = System.Drawing.Color.Red;
			this.label1.Location = new System.Drawing.Point(48, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(16, 16);
			this.label1.TabIndex = 18;
			this.label1.Text = "*";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// radioGroup_Class
			// 
			this.radioGroup_Class.EditValue = "0";
			this.radioGroup_Class.Location = new System.Drawing.Point(160, 160);
			this.radioGroup_Class.Name = "radioGroup_Class";
			// 
			// radioGroup_Class.Properties
			// 
			this.radioGroup_Class.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
																													 new DevExpress.XtraEditors.Controls.RadioGroupItem("0", "学生班级"),
																													 new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "教师岗位")});
			this.radioGroup_Class.Size = new System.Drawing.Size(184, 32);
			this.radioGroup_Class.TabIndex = 7;
			this.radioGroup_Class.SelectedIndexChanged += new System.EventHandler(this.radioGroup_Class_SelectedIndexChanged);
			// 
			// comboBoxEdit1
			// 
			this.comboBoxEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxEdit1.EditValue = "";
			this.comboBoxEdit1.Location = new System.Drawing.Point(160, 32);
			this.comboBoxEdit1.Name = "comboBoxEdit1";
			// 
			// comboBoxEdit1.Properties
			// 
			this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit1.Size = new System.Drawing.Size(181, 23);
			this.comboBoxEdit1.TabIndex = 22;
			this.comboBoxEdit1.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit1_SelectedIndexChanged);
			// 
			// xtraTabPage_ClassModify
			// 
			this.xtraTabPage_ClassModify.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
			this.xtraTabPage_ClassModify.Appearance.PageClient.Options.UseBackColor = true;
			this.xtraTabPage_ClassModify.Controls.Add(this.comboBoxEdit_GradeForClass);
			this.xtraTabPage_ClassModify.Controls.Add(this.label_ReqOfClassMdiName);
			this.xtraTabPage_ClassModify.Controls.Add(this.simpleButton_ClassModi);
			this.xtraTabPage_ClassModify.Controls.Add(this.simpleButton_ClassModiReset);
			this.xtraTabPage_ClassModify.Controls.Add(this.textEdit_ClassModifyRemark);
			this.xtraTabPage_ClassModify.Controls.Add(this.comboBoxEdit_ClassNameModify);
			this.xtraTabPage_ClassModify.Controls.Add(this.notePanel_ClassModifyName);
			this.xtraTabPage_ClassModify.Controls.Add(this.notePanel_ClassModifyRemark);
			this.xtraTabPage_ClassModify.Controls.Add(this.notePanel3);
			this.xtraTabPage_ClassModify.Controls.Add(this.label2);
			this.xtraTabPage_ClassModify.Controls.Add(this.simpleButton_DeleteClass);
			this.xtraTabPage_ClassModify.Name = "xtraTabPage_ClassModify";
			this.xtraTabPage_ClassModify.Size = new System.Drawing.Size(394, 230);
			this.xtraTabPage_ClassModify.Text = "修改班级信息";
			// 
			// comboBoxEdit_GradeForClass
			// 
			this.comboBoxEdit_GradeForClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxEdit_GradeForClass.EditValue = "";
			this.comboBoxEdit_GradeForClass.Location = new System.Drawing.Point(160, 40);
			this.comboBoxEdit_GradeForClass.Name = "comboBoxEdit_GradeForClass";
			// 
			// comboBoxEdit_GradeForClass.Properties
			// 
			this.comboBoxEdit_GradeForClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_GradeForClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_GradeForClass.Size = new System.Drawing.Size(197, 23);
			this.comboBoxEdit_GradeForClass.TabIndex = 27;
			this.comboBoxEdit_GradeForClass.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_GradeForClass_SelectedIndexChanged);
			// 
			// label_ReqOfClassMdiName
			// 
			this.label_ReqOfClassMdiName.ForeColor = System.Drawing.Color.Red;
			this.label_ReqOfClassMdiName.Location = new System.Drawing.Point(48, 72);
			this.label_ReqOfClassMdiName.Name = "label_ReqOfClassMdiName";
			this.label_ReqOfClassMdiName.Size = new System.Drawing.Size(16, 16);
			this.label_ReqOfClassMdiName.TabIndex = 26;
			this.label_ReqOfClassMdiName.Text = "*";
			this.label_ReqOfClassMdiName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// simpleButton_ClassModi
			// 
			this.simpleButton_ClassModi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButton_ClassModi.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
			this.simpleButton_ClassModi.Appearance.Options.UseFont = true;
			this.simpleButton_ClassModi.Location = new System.Drawing.Point(293, 136);
			this.simpleButton_ClassModi.Name = "simpleButton_ClassModi";
			this.simpleButton_ClassModi.Size = new System.Drawing.Size(64, 24);
			this.simpleButton_ClassModi.TabIndex = 25;
			this.simpleButton_ClassModi.Text = "修改";
			this.simpleButton_ClassModi.Click += new System.EventHandler(this.simpleButton_ClassModi_Click);
			// 
			// simpleButton_ClassModiReset
			// 
			this.simpleButton_ClassModiReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButton_ClassModiReset.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
			this.simpleButton_ClassModiReset.Appearance.Options.UseFont = true;
			this.simpleButton_ClassModiReset.Location = new System.Drawing.Point(181, 192);
			this.simpleButton_ClassModiReset.Name = "simpleButton_ClassModiReset";
			this.simpleButton_ClassModiReset.Size = new System.Drawing.Size(64, 24);
			this.simpleButton_ClassModiReset.TabIndex = 24;
			this.simpleButton_ClassModiReset.Text = "重置";
			this.simpleButton_ClassModiReset.Visible = false;
			this.simpleButton_ClassModiReset.Click += new System.EventHandler(this.simpleButton_ClassModiReset_Click);
			// 
			// textEdit_ClassModifyRemark
			// 
			this.textEdit_ClassModifyRemark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textEdit_ClassModifyRemark.EditValue = "";
			this.textEdit_ClassModifyRemark.Location = new System.Drawing.Point(160, 104);
			this.textEdit_ClassModifyRemark.Name = "textEdit_ClassModifyRemark";
			this.textEdit_ClassModifyRemark.Size = new System.Drawing.Size(197, 23);
			this.textEdit_ClassModifyRemark.TabIndex = 23;
			// 
			// comboBoxEdit_ClassNameModify
			// 
			this.comboBoxEdit_ClassNameModify.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxEdit_ClassNameModify.EditValue = "";
			this.comboBoxEdit_ClassNameModify.Location = new System.Drawing.Point(160, 72);
			this.comboBoxEdit_ClassNameModify.Name = "comboBoxEdit_ClassNameModify";
			// 
			// comboBoxEdit_ClassNameModify.Properties
			// 
			this.comboBoxEdit_ClassNameModify.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_ClassNameModify.Size = new System.Drawing.Size(197, 23);
			this.comboBoxEdit_ClassNameModify.TabIndex = 22;
			this.comboBoxEdit_ClassNameModify.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_ClassNameModify_SelectedIndexChanged);
			// 
			// notePanel_ClassModifyName
			// 
			this.notePanel_ClassModifyName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_ClassModifyName.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_ClassModifyName.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_ClassModifyName.ForeColor = System.Drawing.Color.Black;
			this.notePanel_ClassModifyName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_ClassModifyName.Location = new System.Drawing.Point(64, 72);
			this.notePanel_ClassModifyName.MaxRows = 5;
			this.notePanel_ClassModifyName.Name = "notePanel_ClassModifyName";
			this.notePanel_ClassModifyName.ParentAutoHeight = true;
			this.notePanel_ClassModifyName.Size = new System.Drawing.Size(80, 22);
			this.notePanel_ClassModifyName.TabIndex = 20;
			this.notePanel_ClassModifyName.TabStop = false;
			this.notePanel_ClassModifyName.Text = "班级名称";
			// 
			// notePanel_ClassModifyRemark
			// 
			this.notePanel_ClassModifyRemark.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_ClassModifyRemark.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_ClassModifyRemark.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_ClassModifyRemark.ForeColor = System.Drawing.Color.Black;
			this.notePanel_ClassModifyRemark.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_ClassModifyRemark.Location = new System.Drawing.Point(64, 104);
			this.notePanel_ClassModifyRemark.MaxRows = 5;
			this.notePanel_ClassModifyRemark.Name = "notePanel_ClassModifyRemark";
			this.notePanel_ClassModifyRemark.ParentAutoHeight = true;
			this.notePanel_ClassModifyRemark.Size = new System.Drawing.Size(80, 22);
			this.notePanel_ClassModifyRemark.TabIndex = 21;
			this.notePanel_ClassModifyRemark.TabStop = false;
			this.notePanel_ClassModifyRemark.Text = "班级备注";
			// 
			// notePanel3
			// 
			this.notePanel3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel3.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel3.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel3.ForeColor = System.Drawing.Color.Black;
			this.notePanel3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel3.Location = new System.Drawing.Point(64, 40);
			this.notePanel3.MaxRows = 5;
			this.notePanel3.Name = "notePanel3";
			this.notePanel3.ParentAutoHeight = true;
			this.notePanel3.Size = new System.Drawing.Size(80, 22);
			this.notePanel3.TabIndex = 20;
			this.notePanel3.TabStop = false;
			this.notePanel3.Text = "所在年级";
			// 
			// label2
			// 
			this.label2.ForeColor = System.Drawing.Color.Red;
			this.label2.Location = new System.Drawing.Point(48, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(16, 16);
			this.label2.TabIndex = 26;
			this.label2.Text = "*";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// simpleButton_DeleteClass
			// 
			this.simpleButton_DeleteClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButton_DeleteClass.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
			this.simpleButton_DeleteClass.Appearance.Options.UseFont = true;
			this.simpleButton_DeleteClass.Location = new System.Drawing.Point(69, 136);
			this.simpleButton_DeleteClass.Name = "simpleButton_DeleteClass";
			this.simpleButton_DeleteClass.Size = new System.Drawing.Size(64, 24);
			this.simpleButton_DeleteClass.TabIndex = 25;
			this.simpleButton_DeleteClass.Text = "删除";
			this.simpleButton_DeleteClass.Visible = false;
			this.simpleButton_DeleteClass.Click += new System.EventHandler(this.simpleButton_DeleteClass_Click);
			// 
			// notePanel4
			// 
			this.notePanel4.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel4.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel4.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel4.Location = new System.Drawing.Point(0, 0);
			this.notePanel4.MaxRows = 5;
			this.notePanel4.Name = "notePanel4";
			this.notePanel4.ParentAutoHeight = true;
			this.notePanel4.Size = new System.Drawing.Size(398, 23);
			this.notePanel4.TabIndex = 3;
			this.notePanel4.TabStop = false;
			this.notePanel4.Text = "班级资料(*为必须填写)";
			// 
			// GardenInfo
			// 
			this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.Appearance.Options.UseBackColor = true;
			this.Controls.Add(this.splitContainerControl_GradeClassInfo);
			this.Controls.Add(this.groupControl_GardenInfo);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlTop);
			this.Name = "GardenInfo";
			this.Size = new System.Drawing.Size(772, 540);
			((System.ComponentModel.ISupportInitialize)(this.groupControl_GardenInfo)).EndInit();
			this.groupControl_GardenInfo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureEdit_GardenImage.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_GardenFeature.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_GardenRegCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_GardenName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_GardenAddress.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_GardenContact.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl_GradeClassInfo)).EndInit();
			this.splitContainerControl_GradeClassInfo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_GradeInfo)).EndInit();
			this.xtraTabControl_GradeInfo.ResumeLayout(false);
			this.xtraTabPage_AddGrade.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_gradeNumber.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_GradeRemark.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.radioGroup_Grade.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_GradeName.Properties)).EndInit();
			this.xtraTabPage_GradeModify.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_GradeRemarkModify.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_GradeModify.Properties)).EndInit();
			this.xtraTabPage_Machine.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gdMachineInfo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtVol.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTerminal.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_ClassInfo)).EndInit();
			this.xtraTabControl_ClassInfo.ResumeLayout(false);
			this.xtraTabPage_ClassAdd.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_classNumber.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_ClassName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_ClassRemark.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.radioGroup_Class.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
			this.xtraTabPage_ClassModify.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_GradeForClass.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_ClassModifyRemark.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_ClassNameModify.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		//如果已存在园所信息则加载
		private void LoadGardenInfo()
		{
			//权限
			if ( Thread.CurrentPrincipal.Identity.Name.ToLower() == "admin" )
			{
                //simpleButton_ClassModi.Enabled = false;
                //simpleButton_ClassModiReset.Enabled = false;
                //simpleButton_ClassReSet.Enabled = false;
                //simpleButton_ClassSave.Enabled = false;
                //simpleButton_DeleteClass.Enabled = false;
                //simpleButton_DeleteGrade.Enabled = false;
                //simpleButton_GardenInfoReset.Enabled = false;
                //simpleButton_GardenInfoSave.Enabled = false;
                //simpleButton_GradeInfoReset.Enabled = false;
                //simpleButton_GradeInfoSave.Enabled = false;
                //simpleButton_GradeModify.Enabled = false;
                //simpleButton_GradeModiReset.Enabled = false;
			}

			GardenInfoSystem gardenInfoSystem = new GardenInfoSystem();

			try
			{
				//获取garden信息
				gardenInfo = gardenInfoSystem.GetGardenInfo();

				if(gardenInfo.Tables[0].Rows.Count > 0)
				{
					textEdit_GardenName.Text = gardenInfo.Tables[0].Rows[0]["info_gardenName"].ToString();
					textEdit_GardenRegCode.Text = gardenInfo.Tables[0].Rows[0]["info_gardenRegCode"].ToString();
					textEdit_GardenAddress.Text = gardenInfo.Tables[0].Rows[0]["info_gardenAddr"].ToString();
					textEdit_GardenContact.Text = gardenInfo.Tables[0].Rows[0]["info_gardenContact"].ToString();
					textEdit_GardenFeature.Text = gardenInfo.Tables[0].Rows[0]["info_gardenFeature"].ToString();

					if(gardenInfo.Tables[0].Rows[0]["info_gardenGraphLocation"]!=System.DBNull.Value)
					{
						byte[] imageByte = (byte[])gardenInfo.Tables[0].Rows[0]["info_gardenGraphLocation"];

						if(imageByte.Length>0)
						{
							pictureEdit_GardenImage.Image = Image.FromStream(new MemoryStream(imageByte));
						}
					}

					simpleButton_GardenInfoSave.Text = "修改";
				}

				radioGroup_Grade.SelectedIndex = 0;
				radioGroup_Class.SelectedIndex = 0;

				BindMacineInfo();
				
			}
			catch(Exception ex)
			{
				CPTT.SystemFramework.Util.WriteLog(ex.Message,CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);
				MessageBox.Show("加载园所信息错误,请重试.","系统提示!",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}

		//选择图片
		private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			openFileDialog_SaveImage.Filter = "图像文件(*.bmp;*.jpg;*.jpeg;*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

			if(openFileDialog_SaveImage.ShowDialog() == DialogResult.OK)
			{
				try
				{
					Image image = Image.FromFile(openFileDialog_SaveImage.FileName);

					MemoryStream ms = new MemoryStream();
					image.Save(ms,System.Drawing.Imaging.ImageFormat.Jpeg);
				
					if(ms.Length < 200*1024)
					{
						pictureEdit_GardenImage.Image = image;
						writeInImage = ms.ToArray();
					}
					else
					{
						MessageBox.Show("图片大小大于200K,请重新上传.","系统提示!",MessageBoxButtons.OK,MessageBoxIcon.Information);
					}
				}
				catch(Exception ex)
				{
					CPTT.SystemFramework.Util.WriteLog(ex.Message,CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);
					MessageBox.Show("图片加载错误,请重试.","系统提示!",MessageBoxButtons.OK,MessageBoxIcon.Information);
				}
			}
		}

		//保存园所信息
		private void simpleButton_GardenInfoSave_Click(object sender, System.EventArgs e)
		{
		
			if(!validateDataIsEmpty())//校验数据是否合法
			{
				CPTT.SystemFramework.GardenInfo gardenInfoInstance = new CPTT.SystemFramework.GardenInfo();

				if(gardenInfo.Tables[0].Rows.Count == 0)//数据库中没有园所数据做插入
				{
					gardenInfoInstance.GardenID = Guid.NewGuid().ToString();
					gardenInfoInstance.GardenName = textEdit_GardenName.Text.Trim();
					gardenInfoInstance.GardenRegCode = textEdit_GardenRegCode.Text.Trim();
					gardenInfoInstance.GardenAddr = textEdit_GardenAddress.Text.Trim();
					gardenInfoInstance.GardenContact = textEdit_GardenContact.Text.Trim();
					gardenInfoInstance.GardenFeature = textEdit_GardenFeature.Text.Trim();
					gardenInfoInstance.GardenImage = writeInImage;

					try
					{
						int rowEffected = 0;
						GardenInfoSystem gardenInfoSystem = new GardenInfoSystem();
						rowEffected = gardenInfoSystem.InsertGardenInfo(gardenInfoInstance);
	
						if(rowEffected > 0)
						{
							MessageBox.Show("园所信息插入成功!","系统提示!",MessageBoxButtons.OK,MessageBoxIcon.Information);
						}
						else
						{
							MessageBox.Show("园所信息插入失败,请重试!","系统提示!",MessageBoxButtons.OK,MessageBoxIcon.Information);
						}
					}
					catch(Exception ex)
					{
						CPTT.SystemFramework.Util.WriteLog(ex.Message,CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);
						MessageBox.Show("园所信息插入失败,请重试!","系统提示!",MessageBoxButtons.OK,MessageBoxIcon.Information);
					}
				}
				else//数据库中存在园所信息做修改
				{
					gardenInfoInstance.GardenID = gardenInfo.Tables[0].Rows[0]["info_gardenID"].ToString();
					gardenInfoInstance.GardenName = textEdit_GardenName.Text.Trim();
					gardenInfoInstance.GardenRegCode = textEdit_GardenRegCode.Text.Trim();
					gardenInfoInstance.GardenAddr = textEdit_GardenAddress.Text.Trim();
					gardenInfoInstance.GardenContact = textEdit_GardenContact.Text.Trim();
					gardenInfoInstance.GardenFeature = textEdit_GardenFeature.Text.Trim();
					gardenInfoInstance.GardenImage = writeInImage;

					try
					{
						int rowEffected = 0;
						GardenInfoSystem gardenInfoSystem = new GardenInfoSystem();
						rowEffected = gardenInfoSystem.UpdateGardenInfo(gardenInfoInstance);
	
						if(rowEffected > 0)
						{
							MessageBox.Show("园所信息修改成功!","系统提示!",MessageBoxButtons.OK,MessageBoxIcon.Information);
						}
						else
						{
							MessageBox.Show("园所信息修改失败,请重试!","系统提示!",MessageBoxButtons.OK,MessageBoxIcon.Information);
						}
					}
					catch(Exception ex)
					{
						CPTT.SystemFramework.Util.WriteLog(ex.Message,CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);
						MessageBox.Show("园所信息修改失败,请重试!","系统提示!",MessageBoxButtons.OK,MessageBoxIcon.Information);
					}
				}
			}
			else
			{
				MessageBox.Show("请检查数据填写是否规范!","系统提示!",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}

		//数据校验(改进时可调整到Facade层)
		private bool validateDataIsEmpty()
		{
			bool checkHasEmpty = true;

			if(textEdit_GardenName.Text.Trim() != string.Empty)
			{
				checkHasEmpty = false;
			}

			return checkHasEmpty;
		}

		//点击button重置园所数据
		private void simpleButton_GardenInfoReset_Click(object sender, System.EventArgs e)
		{
			if(DialogResult.Yes != 
						MessageBox.Show("进行重置信息有可能在没有保存的情况下丢失!\n确认?","系统信息!",
							MessageBoxButtons.YesNo,MessageBoxIcon.Warning))
				return;
			resetGardenData();
		}

		//重置园所数据
		private void resetGardenData()
		{
			textEdit_GardenName.Text = string.Empty;
			textEdit_GardenRegCode.Text = string.Empty;
			textEdit_GardenAddress.Text = string.Empty;
			textEdit_GardenContact.Text = string.Empty;
			textEdit_GardenFeature.Text = string.Empty;
			pictureEdit_GardenImage.Image = null;
		}

		//保存年级信息
		private void simpleButton_GradeInfoSave_Click(object sender, System.EventArgs e)
		{
			if(textEdit_GradeName.Text.Trim() != string.Empty)//检查数据是否合法
			{
				Grade grade = new Grade();
				grade.GradeName = textEdit_GradeName.Text.Trim();

				if (comboBoxEdit_gradeNumber.SelectedItem.ToString().Equals("已到达年级最大容量"))
				{
					MessageBox.Show("年级容量已经到达最大容量，无法进行添加操作！");
					return;
				}

				if (radioGroup_Grade.SelectedIndex == 0) grade.GradeID = Convert.ToInt32(comboBoxEdit_gradeNumber.SelectedItem);
				else grade.GradeID = 0;
				grade.GradeRemark = comboBoxEdit_GradeRemark.SelectedItem.ToString();
				grade.GradeType = radioGroup_Grade.SelectedIndex.ToString();

				int rowsAffected = 0;

				try
				{
					rowsAffected = new GradeSystem().InsertGradeInfo(grade);

					if(rowsAffected > 0)
					{
						//清空文本框
						resetGradeInfoAdd();

						MessageBox.Show("插入成功.","系统信息!",MessageBoxButtons.OK,MessageBoxIcon.Information);
						gradeDataBinding();//重新绑定年级信息
					}
					else if(rowsAffected == -1)
					{
						string info = radioGroup_Grade.SelectedIndex == 0 ? "年级" : "部门";
						MessageBox.Show(info+"名称重复,请更改名称后重试","系统信息!",
							MessageBoxButtons.OK,MessageBoxIcon.Warning);
					}						 
					else
					{
						MessageBox.Show("插入失败,请重试","系统信息!",
							MessageBoxButtons.OK,MessageBoxIcon.Warning);
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show("插入失败,请重试","系统信息!",
						MessageBoxButtons.OK,MessageBoxIcon.Information);
					CPTT.SystemFramework.Util.WriteLog(ex.Message,CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);
				}
			}
			else
			{
				MessageBox.Show("*号为必须填写内容,请检查输入","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}
		}

		//清空年级添加文本框
		private void resetGradeInfoAdd()
		{
			textEdit_GradeName.Text = "";
//			textEdit_GradeRemark.Text = "";
		}

		//年级信息重置按钮
		private void simpleButton_GradeInfoReset_Click(object sender, System.EventArgs e)
		{
			resetGradeInfoAdd();
		}

		private void radioGroup_Class_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ClassDataBinding();

			gradeInfoList = new GradeSystem().GetGradeInfoList(radioGroup_Class.SelectedIndex);
			comboBoxEdit1.Properties.Items.Clear();
			comboBoxEdit1.SelectedIndex = -1;
			comboBoxEdit_GradeForClass.Properties.Items.Clear();
			comboBoxEdit_GradeForClass.SelectedIndex = -1;

			foreach(DataRow gradeInfo in gradeInfoList.Tables[0].Rows)
			{
				comboBoxEdit_GradeForClass.Properties.Items.Add(gradeInfo["info_gradeName"].ToString());
				comboBoxEdit1.Properties.Items.Add(gradeInfo["info_gradeName"].ToString());
			}

			if (radioGroup_Class.SelectedIndex == 0)
			{
				xtraTabPage_ClassAdd.Text = "添加班级信息";
				xtraTabPage_ClassModify.Text = "修改班级信息";

				notePanel_GradeForClass.Text = "年级名称:";
				notePanel_ClassName.Text = "班级名称:";
				notePanel_ClassRemark.Text = "班级备注:";
				notePanel3.Text = "年级名称:";
				notePanel_ClassModifyName.Text = "班级名称:";
				notePanel_ClassRemark.Text = "班级备注:";
				notePanel_ClassModifyRemark.Text = "班级备注:";
				
				comboBoxEdit_classNumber.Enabled = true;

			}
			else
			{
				xtraTabPage_ClassAdd.Text = "添加岗位信息";
				xtraTabPage_ClassModify.Text = "修改岗位信息";

				notePanel_GradeForClass.Text = "部门名称:";
				notePanel_ClassName.Text = "岗位名称:";
				notePanel_ClassRemark.Text = "岗位备注:";
				notePanel3.Text = "部门名称:";
				notePanel_ClassModifyName.Text = "岗位名称:";
				notePanel_ClassRemark.Text = "岗位备注:";
				notePanel_ClassModifyRemark.Text = "岗位备注:";

				comboBoxEdit_classNumber.Text = "自动生成";
				comboBoxEdit_classNumber.Enabled = false;
				
			}
	}

		private void comboBoxEdit_GradeForClass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (comboBoxEdit_GradeForClass.SelectedIndex != -1)
				{
					classesInfoList = new ClassSystem().GetClassInfoList();
					gradeInfoList = new GradeSystem().GetGradeInfoList(radioGroup_Class.SelectedIndex);
					comboBoxEdit_ClassNameModify.Properties.Items.Clear();
					textEdit_ClassModifyRemark.Text = string.Empty;
					foreach(DataRow gradeInfo in gradeInfoList.Tables[0].Rows)
					{
						if(gradeInfo["info_gradeName"].ToString().Equals(comboBoxEdit_GradeForClass.SelectedItem.ToString()))
						{
							foreach(DataRow classInfo in classesInfoList.Tables[0].Rows)
							{
								if(Convert.ToInt32(classInfo["info_gradeNumber"]) == Convert.ToInt32(gradeInfo["info_gradeNumber"]))
								{
									comboBoxEdit_ClassNameModify.Properties.Items.Add(classInfo["info_className"].ToString());
								}							
							}
						}
					}	
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("班级信息绑定失败,请重试","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				CPTT.SystemFramework.Util.WriteLog(ex.Message,CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);
			}
			finally
			{
				comboBoxEdit_ClassNameModify.SelectedIndex = -1;
			}
		}

		private void comboBoxEdit_GradeRemark_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void radioGroup_Grade_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			gradeDataBinding();

			comboBoxEdit_GradeModify.Text = "";

			if ( radioGroup_Grade.SelectedIndex == 0 )
			{
				comboBoxEdit_GradeRemark.Properties.Items.Clear();
				comboBoxEdit_GradeRemark.Properties.Items.AddRange(new object[]{"托班","小班","中班","大班","特色班"});
				comboBoxEdit_GradeRemark.SelectedItem = "托班";
				comboBoxEdit_GradeRemark.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
				
				xtraTabPage_AddGrade.Text = "添加年级信息";
				xtraTabPage_GradeModify.Text = "修改年级信息";

				notePanel_GradeName.Text = "年级名称";
				notePanel_GradeNameModify.Text = "年级名称";

				comboBoxEdit_GradeRemark.Enabled = true;
				
				notePanel_GradeModify.Visible = true;
				comboBoxEdit_GradeRemarkModify.Visible = true;
				
			}
			else
			{
				comboBoxEdit_GradeRemark.Properties.Items.Clear();
				comboBoxEdit_GradeRemark.Text = "教师";
				comboBoxEdit_GradeRemark.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;

				comboBoxEdit_gradeNumber.Text = "自动生成";
				comboBoxEdit_gradeNumber.Enabled = false;

				xtraTabPage_AddGrade.Text = "添加部门信息";
				xtraTabPage_GradeModify.Text = "修改部门信息";

				notePanel_GradeName.Text = "部门名称";
				notePanel_GradeNameModify.Text = "部门名称";

				comboBoxEdit_gradeNumber.Enabled = false;
				comboBoxEdit_GradeRemark.Enabled = false;

				notePanel_GradeModify.Visible = false;
				comboBoxEdit_GradeRemarkModify.Visible = false;
			}

		}

		private object[] GetAvailableNumber(DataSet dsType,int availType)
		{
			ArrayList dynNumber = new ArrayList();
			if (availType == 0) dynNumber.AddRange(new object[]{1,2,3,4,5,6,7,8});
			else dynNumber.AddRange(new object[]{1,2,3,4,5,6,7,8,9});

			for (int row = 0;row < dsType.Tables[0].Rows.Count;row++)
			{
				dynNumber.Remove(dsType.Tables[0].Rows[row][0]);
			}

			return dynNumber.ToArray();
		}

		//年级信息修改数据绑定
		private void gradeDataBinding()
		{
			try
			{
				gradeInfoList = new GradeSystem().GetGradeInfoList(radioGroup_Grade.SelectedIndex);
				comboBoxEdit_GradeModify.Properties.Items.Clear();
				comboBoxEdit_GradeForClass.Properties.Items.Clear();
				comboBoxEdit1.Properties.Items.Clear();
				comboBoxEdit1.SelectedIndex = -1;
				comboBoxEdit_GradeForClass.SelectedIndex = -1;

				foreach(DataRow gradeInfo in gradeInfoList.Tables[0].Rows)
				{
					comboBoxEdit_GradeModify.Properties.Items.Add(gradeInfo["info_gradeName"].ToString());
				}

				gradeInfoList = new GradeSystem().GetGradeInfoList(radioGroup_Class.SelectedIndex <= 0 ? 0 : 1);
				
				foreach(DataRow gradeInfo in gradeInfoList.Tables[0].Rows)
				{
					comboBoxEdit_GradeForClass.Properties.Items.Add(gradeInfo["info_gradeName"].ToString());
					comboBoxEdit1.Properties.Items.Add(gradeInfo["info_gradeName"].ToString());
				}

				if (radioGroup_Grade.SelectedIndex != 1)
				{
					comboBoxEdit_gradeNumber.Properties.Items.Clear();
					object[] availableGradeNumber = GetAvailableNumber(new GradeSystem().GetGradeNumber(),0);
					if (availableGradeNumber.Length != 0)
					{
						comboBoxEdit_gradeNumber.Properties.Items.AddRange(availableGradeNumber);
						comboBoxEdit_gradeNumber.Enabled = true;
					}
					else
					{
						comboBoxEdit_gradeNumber.Properties.Items.AddRange(new object[]{"已经到达年级最大容量"});
						comboBoxEdit_gradeNumber.Enabled = false;
					}
					comboBoxEdit_gradeNumber.SelectedIndex = 0;
				}

			}
			catch(Exception ex)
			{
				MessageBox.Show("年级信息绑定失败,请重试","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				CPTT.SystemFramework.Util.WriteLog(ex.Message,CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);
			}
		}

		private void ClassDataBinding()
		{
			if (radioGroup_Class.SelectedIndex != 1)
			{
				object[] availableClassNumber = GetAvailableNumber(new GradeSystem().GetClassNumber(comboBoxEdit1.SelectedItem==null?"":comboBoxEdit1.SelectedItem.ToString()),1);
				comboBoxEdit_classNumber.Properties.Items.Clear();
				if (availableClassNumber.Length != 0) 
				{
					comboBoxEdit_classNumber.Properties.Items.AddRange(availableClassNumber);
					comboBoxEdit_classNumber.Enabled = true;
				}
				else
				{
					comboBoxEdit_classNumber.Properties.Items.AddRange(new object[]{"已到达班级最大容量"});
					comboBoxEdit_classNumber.Enabled = false;
				}

				comboBoxEdit_classNumber.SelectedIndex = 0;
			}
		}

		//根据年级变化显示年级备注
		private void comboBoxEdit_GradeModify_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(comboBoxEdit_GradeModify.SelectedIndex>-1)
			{
				string gradeName = comboBoxEdit_GradeModify.SelectedItem.ToString();
			
				if(gradeInfoList.Tables[0].Rows.Count>0)
				{
					foreach(DataRow gradeInfo in gradeInfoList.Tables[0].Rows)
					{
						if(gradeInfo["info_gradeName"].ToString().Equals(gradeName))
						{
							gradeID = Convert.ToInt32(gradeInfo["info_gradeNumber"]);

							if ( Convert.ToInt32(gradeInfo["info_gradeNumber"]) > 0 )
							{
								comboBoxEdit_GradeRemarkModify.Properties.Items.Clear();
								comboBoxEdit_GradeRemarkModify.Properties.Items.AddRange(new object[]{"托班","小班","中班","大班","特色班"});
								comboBoxEdit_GradeRemarkModify.SelectedItem = "托班";
								comboBoxEdit_GradeRemarkModify.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
								comboBoxEdit_GradeRemarkModify.SelectedItem = gradeInfo["info_gradeRemark"].ToString();
								
							}
							else
							{
								comboBoxEdit_GradeRemarkModify.Properties.Items.Clear();
								comboBoxEdit_GradeRemarkModify.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
								comboBoxEdit_GradeRemarkModify.Text = gradeInfo["info_gradeRemark"].ToString();
							}
						}
					}
				}
			}
		}

		//修改年级信息
		private void simpleButton_GradeModify_Click(object sender, System.EventArgs e)
		{
//			if(DialogResult.Yes != 
//				MessageBox.Show("确认修改?","系统信息!",
//				MessageBoxButtons.OK,MessageBoxIcon.Warning))
//				return;
			string message = "是否确认修改？";
			string caption = "消息提示框!";
			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult != DialogResult.Yes )
				return;

			int rowsAffected = 0;
			Grade grade = new Grade();
			grade.GradeID = gradeID;
			grade.GradeName = comboBoxEdit_GradeModify.SelectedItem.ToString();
			grade.GradeRemark = comboBoxEdit_GradeRemarkModify.SelectedItem.ToString();

			if(grade.GradeName!=string.Empty)
			{
				try
				{
					rowsAffected = new GradeSystem().UpdateGradeInfo(grade);

					if(rowsAffected>0)
					{
						MessageBox.Show(radioGroup_Grade.SelectedIndex == 0?"年级名称修改成功":"部门名称修改成功","系统信息!",
							MessageBoxButtons.OK,MessageBoxIcon.Information);
						gradeDataBinding();
//						gradeModifyInfoReset();
					}
					else if(rowsAffected == -1)
					{
						MessageBox.Show("年级名称已存在,请重试","系统信息!",
							MessageBoxButtons.OK,MessageBoxIcon.Warning);
					}
					else
					{
						MessageBox.Show("年级信息修改失败,请重试","系统信息!",
							MessageBoxButtons.OK,MessageBoxIcon.Warning);
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show("年级信息修改失败,请重试","系统信息!",
						MessageBoxButtons.OK,MessageBoxIcon.Warning);
					CPTT.SystemFramework.Util.WriteLog(ex.Message,CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);
				}
			}
			else
			{
				MessageBox.Show("请先选择要修改的年级","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}
		}

		//重置年级修改信息
		private void simpleButton_GradeModiReset_Click(object sender, System.EventArgs e)
		{
			gradeModifyInfoReset();
		}

		//清空年级修改信息数据
		private void gradeModifyInfoReset()
		{
			comboBoxEdit_GradeRemarkModify.DataBindings.Clear();
//			comboBoxEdit_GradeModify.SelectedIndex = -1;
//			textEdit_GradeModify.Text = "";
		}

		//删除年级信息
		private void simpleButton_DeleteGrade_Click(object sender, System.EventArgs e)
		{
			int rowsAffected = 0;

			if(comboBoxEdit_GradeModify.SelectedIndex!=-1)
			{
				try
				{
					rowsAffected = new GradeSystem().DeleteGradeInfo(gradeID);
				
					if(rowsAffected>0)
					{
						gradeDataBinding();
						gradeModifyInfoReset();
					}
					else
					{
						MessageBox.Show("年级信息删除失败,请重试","系统信息!",
							MessageBoxButtons.OK,MessageBoxIcon.Warning);
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show("年级信息删除失败,请重试","系统信息!",
						MessageBoxButtons.OK,MessageBoxIcon.Warning);
					CPTT.SystemFramework.Util.WriteLog(ex.Message,CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);
				}
			}
			else
			{
				MessageBox.Show("请先选择要删除的年级","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}
		}

		//清空班级添加文本框
		private void resetClassInfoAdd()
		{
			comboBoxEdit_GradeForClass.SelectedIndex = -1;
			textEdit_ClassName.Text = string.Empty;
			textEdit_ClassRemark.Text = string.Empty;
		}

		//清空班级添加信息的重置按钮
		private void simpleButton_ClassReSet_Click(object sender, System.EventArgs e)
		{
			resetClassInfoAdd();
		}
         
		//根据年级信息绑定班级信息
		private void comboBoxEdit1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			textEdit_ClassName.Text = string.Empty;

			if (radioGroup_Class.SelectedIndex != 1)
			{
				object[] availableClassNumber = GetAvailableNumber(new GradeSystem().GetClassNumber(comboBoxEdit1.SelectedItem==null?"":comboBoxEdit1.SelectedItem.ToString()),1);
				comboBoxEdit_classNumber.Properties.Items.Clear();

				if (availableClassNumber.Length != 0) 
				{
					comboBoxEdit_classNumber.Properties.Items.AddRange(availableClassNumber);
					comboBoxEdit_classNumber.Enabled = true;
				}
				else
				{
					comboBoxEdit_classNumber.Properties.Items.AddRange(new object[]{"已到达班级最大容量"});
					comboBoxEdit_classNumber.Enabled = false;
				}

				comboBoxEdit_classNumber.SelectedIndex = 0;
			}
		}

		//保存班级信息
		private void simpleButton_ClassSave_Click(object sender, System.EventArgs e)
		{		
			if(comboBoxEdit1.SelectedIndex != -1 && textEdit_ClassName.Text != string.Empty)
			{
				Classes classes = new Classes();
				classes.InfoClassName = textEdit_ClassName.Text.Trim();
				classes.InfoClassRemark = textEdit_ClassRemark.Text.Trim();
				
				if (comboBoxEdit_classNumber.SelectedItem.ToString().Equals("已经到达班级最大容量"))
				{
					MessageBox.Show("班级容量已经到达最大容量，无法进行添加操作！");
					return;
				}
				
				if (radioGroup_Class.SelectedIndex == 0) classes.InfoClassNumber = Convert.ToInt32(comboBoxEdit_classNumber.SelectedItem);
				else classes.InfoClassNumber = 0;

				classes.ClassType = radioGroup_Class.SelectedIndex.ToString();
				int rowsAffected = 0;
				try
				{
					rowsAffected = new ClassSystem().InsertClassInfo(classes,comboBoxEdit1.SelectedItem.ToString());

					if(rowsAffected > 0)
					{
						//清空文本框
						resetClassInfoAdd();

						MessageBox.Show("插入成功.","系统信息!",MessageBoxButtons.OK,MessageBoxIcon.Information);

						//重新绑定班级信息
						ClassDataBinding();
					}
					else if(rowsAffected == -1)
					{
						string info = radioGroup_Class.SelectedIndex==0?"班级":"岗位";
						MessageBox.Show(info+"名称重复,请更改名称后重试","系统信息!",
							MessageBoxButtons.OK,MessageBoxIcon.Warning);
					}	
					else if(rowsAffected == -2)
					{
						MessageBox.Show("该部门的教师岗位由系统内定为班主任，您无法对该项目进行操作！","系统信息!",
							MessageBoxButtons.OK,MessageBoxIcon.Warning);
					}
					else if (rowsAffected == -3)
					{
						MessageBox.Show("班级总合不能超过28，添加失败!","系统信息!",
							MessageBoxButtons.OK,MessageBoxIcon.Warning);
					}
					else
					{
						MessageBox.Show("插入失败,请重试","系统信息!",
							MessageBoxButtons.OK,MessageBoxIcon.Warning);
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show("插入失败,请重试","系统信息!",
						MessageBoxButtons.OK,MessageBoxIcon.Information);
					CPTT.SystemFramework.Util.WriteLog(ex.Message,CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);
				}
			}
			else
			{
				MessageBox.Show("*号为必须填写内容,请检查输入","系统信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}

			textEdit_ClassName.Text = string.Empty;
			
		}

		//清空修改班级文本框
		private void simpleButton_ClassModiReset_Click(object sender, System.EventArgs e)
		{
			resetClassInfo();
		}

		private void resetClassInfo()
		{			
			comboBoxEdit1.SelectedIndex = 0;
			comboBoxEdit_ClassNameModify.Properties.Items.Clear();
//			
//			textEdit_ClassModifyRemark.Text = "";
		}
		//根据班级信息显示班级备注	
		private void comboBoxEdit_ClassNameModify_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string className = comboBoxEdit_ClassNameModify.SelectedItem.ToString();

			if(classesInfoList.Tables[0].Rows.Count>0)
			{
				foreach(DataRow classInfo in classesInfoList.Tables[0].Rows)
				{
					if(classInfo["info_className"].ToString().Equals(className))
					{
						textEdit_ClassModifyRemark.Text = classInfo["info_classRemark"].ToString();
						gradeID = Convert.ToInt32(classInfo["info_gradeNumber"]);
						classID = Convert.ToInt32(classInfo["info_classNumber"]);
					}
				}
			}
		}

		//删除班级信息
		private void simpleButton_DeleteClass_Click(object sender, System.EventArgs e)
		{
			int rowsAffected = 0;

			if(comboBoxEdit_ClassNameModify.SelectedIndex!=-1)
			{
				try
				{
					rowsAffected = new ClassSystem().DeleteClassInfo(classID,gradeID);
				
					if(rowsAffected>0)
					{
						resetClassInfo();
						gradeDataBinding();
					}
					else
					{
						MessageBox.Show("班级信息删除失败,请重试","系统信息!",
							MessageBoxButtons.OK,MessageBoxIcon.Warning);
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show("班级信息删除失败,请重试","系统信息!",
						MessageBoxButtons.OK,MessageBoxIcon.Warning);
					CPTT.SystemFramework.Util.WriteLog(ex.Message,CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);
				}
			}
			else
			{
				MessageBox.Show("请先选择要删除的班级","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}
		}

		//修改班级信息按钮
		private void simpleButton_ClassModi_Click(object sender, System.EventArgs e)
		{
			string message = "是否确认修改？";
			string caption = "消息提示框!";
			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult != DialogResult.Yes )
				return;

			int rowsAffected = 0;
			Classes classes = new Classes(); 
			classes.ClassInfoGradeNumber = gradeID;
			classes.InfoClassNumber = classID;
			classes.InfoClassName = comboBoxEdit_ClassNameModify.SelectedItem.ToString();
			classes.InfoClassRemark = textEdit_ClassModifyRemark.Text.Trim();

			if(classes.InfoClassName != string.Empty)
			{
				try
				{
					rowsAffected = new ClassSystem().UpdateClassInfo(classes);

					if(rowsAffected > 0)
					{
						MessageBox.Show(radioGroup_Class.SelectedIndex==0?"班级":"岗位"+"信息修改成功","系统信息!",
							MessageBoxButtons.OK,MessageBoxIcon.Information);
						gradeDataBinding();
						resetClassInfo();
					}
					else
					{
						MessageBox.Show(radioGroup_Class.SelectedIndex==0?"班级":"岗位"+"信息修改失败,请重试","系统信息!",
							MessageBoxButtons.OK,MessageBoxIcon.Warning);
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show(radioGroup_Class.SelectedIndex==0?"班级":"岗位"+"信息修改失败,请重试","系统信息!",
						MessageBoxButtons.OK,MessageBoxIcon.Warning);
					CPTT.SystemFramework.Util.WriteLog(ex.Message,CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);
				}
			}
			else
			{
				MessageBox.Show("请先选择要修改的信息","系统信息!",
					MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}
		}

		private void smbSave_Click(object sender, System.EventArgs e)
		{
			if (CheckMachineInfo(txtTerminal.Text))
			{
				UnBindingMachineInfo();
				int rtnValue = new GardenInfoSystem().AddNewMachine(Convert.ToInt32(txtTerminal.Text));

				if (rtnValue == 1) MessageBox.Show("操作成功！");
				else MessageBox.Show("操作失败！");

				BindMacineInfo();
			}
		}	

		private void smbDelete_Click(object sender, System.EventArgs e)
		{
			UnBindingMachineInfo();

			int addr = Convert.ToInt32(gridView1.GetDataRow(gridView1.GetSelectedRows()[0])[0]);
			
			int rtnValue = new GardenInfoSystem().DeleteMachine(addr);

			if (rtnValue == 1) 
			{
				MessageBox.Show("操作成功！");
			}
			else
			{
				if (rtnValue == -1)
				{
					MessageBox.Show("至少应该保证有一台门口机处于工作状态，删除失败！");
				}
				else
				{
					MessageBox.Show("操作失败！");
				}
			}

			BindMacineInfo();
		}

		private void BindMacineInfo()
		{
			DataSet dsMachineInfo = new GardenInfoSystem().GetMachineInfo();
			if (dsMachineInfo != null)
			{
				if (dsMachineInfo.Tables[0].Rows.Count > 0)
				{
					gdMachineInfo.DataSource = dsMachineInfo.Tables[0];
					txtTerminal.DataBindings.Add("EditValue",dsMachineInfo.Tables[0],"machine_address");
					txtVol.DataBindings.Add("EditValue",dsMachineInfo.Tables[0],"machine_volumn");
				}
			}
		}

		private void UnBindingMachineInfo()
		{
			gdMachineInfo.DataBindings.Clear();
			txtTerminal.DataBindings.Clear();
			txtVol.DataBindings.Clear();
		}

		private bool CheckMachineInfo(string machineAddr)
		{
			try
			{
				int mAddr = Convert.ToInt32(machineAddr);
				if (mAddr <= 0 || mAddr > 127)
				{
					throw new Exception();
				}

				return true;
			}
			catch(Exception ex)
			{
				CPTT.SystemFramework.Util.WriteLog(ex.Message,CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);
				MessageBox.Show("地址设定不符合规范！");
				return false;
			}
		}
	}	
}

