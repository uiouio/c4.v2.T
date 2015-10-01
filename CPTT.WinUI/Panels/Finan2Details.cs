using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using CPTT.BusinessFacade;

namespace CPTT.WinUI.Panels
{
	/// <summary>
	/// Summary description for Finan2Details.
	/// </summary>
	public class Finan2Details : DevExpress.XtraEditors.XtraForm
	{
		private DevExpress.Utils.Frames.NotePanel notePanel_FinanQuery;
		private DevExpress.Utils.Frames.NotePanel notePanel1;
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraEditors.TextEdit txtTemplateName;
		private DevExpress.XtraEditors.SimpleButton btnAdd;
		private DevExpress.XtraEditors.SimpleButton btnSave;
		private System.ComponentModel.IContainer components;
		private bool _modify = false;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
		private string _templateName = string.Empty;
		private DataTable _dtTemplateContents;
		private DevExpress.XtraGrid.Columns.GridColumn fullDays;
		private DevExpress.XtraGrid.Columns.GridColumn fullDaysSpend;
		private DevExpress.XtraGrid.Columns.GridColumn halfDaysSpend;
		private DevExpress.XtraGrid.Columns.GridColumn perDaySpend;
		private DevExpress.XtraGrid.Columns.GridColumn noSpendMonth;
		private DevExpress.XtraGrid.Columns.GridColumn halfSpendMonth;
		private DevExpress.Utils.ToolTipController toolTipController1;
		private CustomStyleFormatCondition _cn;
		private DevExpress.XtraEditors.SimpleButton btnDelete;
		private DevExpress.XtraGrid.Columns.GridColumn 费用名;
		private DevExpress.XtraGrid.Columns.GridColumn 指定年级;
		private Hashtable _htColumnValidator = new Hashtable();
		private DevExpress.XtraGrid.Columns.GridColumn 指定班级;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
	
		public delegate void SaveSucceedHandler();
		public static event SaveSucceedHandler OnSaveSucceeded;
		private int _templateId = 0;

		public Finan2Details()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public Finan2Details(bool isModify,string templateName,int templateId, DataTable dtGrade) : this()
		{
			_modify = isModify;
			_templateName = templateName;
			_templateId = templateId;
			InitColumnValidator();
			InitNewTemplateContents();
			InitGirdView(dtGrade);
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Finan2Details));
			this.notePanel_FinanQuery = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel1 = new DevExpress.Utils.Frames.NotePanel();
			this.txtTemplateName = new DevExpress.XtraEditors.TextEdit();
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.费用名 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.fullDays = new DevExpress.XtraGrid.Columns.GridColumn();
			this.fullDaysSpend = new DevExpress.XtraGrid.Columns.GridColumn();
			this.halfDaysSpend = new DevExpress.XtraGrid.Columns.GridColumn();
			this.perDaySpend = new DevExpress.XtraGrid.Columns.GridColumn();
			this.noSpendMonth = new DevExpress.XtraGrid.Columns.GridColumn();
			this.halfSpendMonth = new DevExpress.XtraGrid.Columns.GridColumn();
			this.指定年级 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.指定班级 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
			this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.txtTemplateName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// notePanel_FinanQuery
			// 
			this.notePanel_FinanQuery.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel_FinanQuery.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel_FinanQuery.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel_FinanQuery.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_FinanQuery.Location = new System.Drawing.Point(0, 0);
			this.notePanel_FinanQuery.MaxRows = 5;
			this.notePanel_FinanQuery.Name = "notePanel_FinanQuery";
			this.notePanel_FinanQuery.ParentAutoHeight = true;
			this.notePanel_FinanQuery.Size = new System.Drawing.Size(632, 23);
			this.notePanel_FinanQuery.TabIndex = 47;
			this.notePanel_FinanQuery.TabStop = false;
			this.notePanel_FinanQuery.Text = "不用的项目请用\"-\"表示。\"排除月\"用于\"不来不交费\",有多个的话，请用\",\"隔开";
			// 
			// notePanel1
			// 
			this.notePanel1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel1.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel1.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel1.ForeColor = System.Drawing.Color.Black;
			this.notePanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel1.Location = new System.Drawing.Point(24, 40);
			this.notePanel1.MaxRows = 5;
			this.notePanel1.Name = "notePanel1";
			this.notePanel1.ParentAutoHeight = true;
			this.notePanel1.Size = new System.Drawing.Size(80, 22);
			this.notePanel1.TabIndex = 48;
			this.notePanel1.TabStop = false;
			this.notePanel1.Text = "模板名称";
			// 
			// txtTemplateName
			// 
			this.txtTemplateName.EditValue = "";
			this.txtTemplateName.Location = new System.Drawing.Point(120, 40);
			this.txtTemplateName.Name = "txtTemplateName";
			this.txtTemplateName.Size = new System.Drawing.Size(152, 23);
			this.txtTemplateName.TabIndex = 49;
			// 
			// gridControl1
			// 
			// 
			// gridControl1.EmbeddedNavigator
			// 
			this.gridControl1.EmbeddedNavigator.Name = "";
			this.gridControl1.Location = new System.Drawing.Point(24, 112);
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																												  this.repositoryItemComboBox1,
																												  this.repositoryItemComboBox2});
			this.gridControl1.Size = new System.Drawing.Size(560, 312);
			this.gridControl1.TabIndex = 50;
			this.gridControl1.ToolTipController = this.toolTipController1;
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.费用名,
																							 this.fullDays,
																							 this.fullDaysSpend,
																							 this.halfDaysSpend,
																							 this.perDaySpend,
																							 this.noSpendMonth,
																							 this.halfSpendMonth,
																							 this.指定年级,
																							 this.指定班级});
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsCustomization.AllowFilter = false;
			this.gridView1.OptionsView.ShowFilterPanel = false;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			// 
			// 费用名
			// 
			this.费用名.AppearanceCell.Options.UseTextOptions = true;
			this.费用名.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.费用名.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.费用名.AppearanceHeader.Options.UseTextOptions = true;
			this.费用名.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.费用名.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.费用名.Caption = "费用名";
			this.费用名.FieldName = "费用名";
			this.费用名.Name = "费用名";
			this.费用名.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
			this.费用名.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.费用名.OptionsColumn.FixedWidth = true;
			this.费用名.Visible = true;
			this.费用名.VisibleIndex = 0;
			this.费用名.Width = 60;
			// 
			// fullDays
			// 
			this.fullDays.AppearanceCell.Options.UseTextOptions = true;
			this.fullDays.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.fullDays.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.fullDays.AppearanceHeader.Options.UseTextOptions = true;
			this.fullDays.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.fullDays.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.fullDays.Caption = "全勤天数";
			this.fullDays.FieldName = "fullDays";
			this.fullDays.Name = "fullDays";
			this.fullDays.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
			this.fullDays.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.fullDays.OptionsColumn.FixedWidth = true;
			this.fullDays.Visible = true;
			this.fullDays.VisibleIndex = 1;
			this.fullDays.Width = 60;
			// 
			// fullDaysSpend
			// 
			this.fullDaysSpend.AppearanceCell.Options.UseTextOptions = true;
			this.fullDaysSpend.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.fullDaysSpend.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.fullDaysSpend.AppearanceHeader.Options.UseTextOptions = true;
			this.fullDaysSpend.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.fullDaysSpend.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.fullDaysSpend.Caption = "全勤费用";
			this.fullDaysSpend.FieldName = "fullDaysSpend";
			this.fullDaysSpend.Name = "fullDaysSpend";
			this.fullDaysSpend.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
			this.fullDaysSpend.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.fullDaysSpend.OptionsColumn.FixedWidth = true;
			this.fullDaysSpend.Visible = true;
			this.fullDaysSpend.VisibleIndex = 2;
			this.fullDaysSpend.Width = 60;
			// 
			// halfDaysSpend
			// 
			this.halfDaysSpend.AppearanceCell.Options.UseTextOptions = true;
			this.halfDaysSpend.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.halfDaysSpend.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.halfDaysSpend.AppearanceHeader.Options.UseTextOptions = true;
			this.halfDaysSpend.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.halfDaysSpend.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.halfDaysSpend.Caption = "半勤费用";
			this.halfDaysSpend.FieldName = "halfDaysSpend";
			this.halfDaysSpend.Name = "halfDaysSpend";
			this.halfDaysSpend.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
			this.halfDaysSpend.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.halfDaysSpend.OptionsColumn.FixedWidth = true;
			this.halfDaysSpend.Visible = true;
			this.halfDaysSpend.VisibleIndex = 3;
			this.halfDaysSpend.Width = 60;
			// 
			// perDaySpend
			// 
			this.perDaySpend.AppearanceCell.Options.UseTextOptions = true;
			this.perDaySpend.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.perDaySpend.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.perDaySpend.AppearanceHeader.Options.UseTextOptions = true;
			this.perDaySpend.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.perDaySpend.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.perDaySpend.Caption = "出勤一次费用";
			this.perDaySpend.FieldName = "perDaySpend";
			this.perDaySpend.Name = "perDaySpend";
			this.perDaySpend.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
			this.perDaySpend.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.perDaySpend.OptionsColumn.FixedWidth = true;
			this.perDaySpend.Visible = true;
			this.perDaySpend.VisibleIndex = 4;
			this.perDaySpend.Width = 89;
			// 
			// noSpendMonth
			// 
			this.noSpendMonth.AppearanceCell.Options.UseTextOptions = true;
			this.noSpendMonth.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.noSpendMonth.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.noSpendMonth.AppearanceHeader.Options.UseTextOptions = true;
			this.noSpendMonth.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.noSpendMonth.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.noSpendMonth.Caption = "排除月";
			this.noSpendMonth.FieldName = "noSpendMonth";
			this.noSpendMonth.Name = "noSpendMonth";
			this.noSpendMonth.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
			this.noSpendMonth.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.noSpendMonth.OptionsColumn.FixedWidth = true;
			this.noSpendMonth.Visible = true;
			this.noSpendMonth.VisibleIndex = 5;
			this.noSpendMonth.Width = 47;
			// 
			// halfSpendMonth
			// 
			this.halfSpendMonth.AppearanceCell.Options.UseTextOptions = true;
			this.halfSpendMonth.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.halfSpendMonth.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.halfSpendMonth.AppearanceHeader.Options.UseTextOptions = true;
			this.halfSpendMonth.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.halfSpendMonth.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.halfSpendMonth.Caption = "半价月";
			this.halfSpendMonth.FieldName = "halfSpendMonth";
			this.halfSpendMonth.Name = "halfSpendMonth";
			this.halfSpendMonth.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
			this.halfSpendMonth.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.halfSpendMonth.OptionsColumn.FixedWidth = true;
			this.halfSpendMonth.Visible = true;
			this.halfSpendMonth.VisibleIndex = 6;
			this.halfSpendMonth.Width = 47;
			// 
			// 指定年级
			// 
			this.指定年级.Caption = "指定年级";
			this.指定年级.ColumnEdit = this.repositoryItemComboBox1;
			this.指定年级.FieldName = "指定年级";
			this.指定年级.Name = "指定年级";
			this.指定年级.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
			this.指定年级.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.指定年级.OptionsColumn.FixedWidth = true;
			this.指定年级.Visible = true;
			this.指定年级.VisibleIndex = 7;
			// 
			// repositoryItemComboBox1
			// 
			this.repositoryItemComboBox1.AutoHeight = false;
			this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemComboBox1.Items.AddRange(new object[] {
																		 "不选择"});
			this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
			this.repositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.repositoryItemComboBox1.SelectedIndexChanged += new System.EventHandler(this.repositoryItemComboBox1_SelectedIndexChanged);
			// 
			// 指定班级
			// 
			this.指定班级.Caption = "指定班级";
			this.指定班级.ColumnEdit = this.repositoryItemComboBox2;
			this.指定班级.FieldName = "指定班级";
			this.指定班级.Name = "指定班级";
			this.指定班级.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
			this.指定班级.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.指定班级.OptionsColumn.FixedWidth = true;
			this.指定班级.Visible = true;
			this.指定班级.VisibleIndex = 8;
			// 
			// repositoryItemComboBox2
			// 
			this.repositoryItemComboBox2.AutoHeight = false;
			this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemComboBox2.Items.AddRange(new object[] {
																		 "不选择"});
			this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
			this.repositoryItemComboBox2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			// 
			// toolTipController1
			// 
			this.toolTipController1.GetActiveObjectInfo += new DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventHandler(this.toolTipController1_GetActiveObjectInfo);
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(24, 80);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(64, 23);
			this.btnAdd.TabIndex = 51;
			this.btnAdd.Text = "添加一行";
			this.btnAdd.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(192, 80);
			this.btnSave.Name = "btnSave";
			this.btnSave.TabIndex = 52;
			this.btnSave.Text = "保存全部";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(104, 80);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.TabIndex = 53;
			this.btnDelete.Text = "删除行";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// Finan2Details
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(632, 461);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.gridControl1);
			this.Controls.Add(this.txtTemplateName);
			this.Controls.Add(this.notePanel1);
			this.Controls.Add(this.notePanel_FinanQuery);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Finan2Details";
			this.Text = "收费细节";
			this.Load += new System.EventHandler(this.Finan2Details_Load);
			((System.ComponentModel.ISupportInitialize)(this.txtTemplateName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private bool IsModify
		{
			get
			{
				return _modify;
			}
		}

		private string TemplateName
		{
			get
			{
				return _templateName;
			}
		}

		private int TemplateID
		{
			get			
			{
				return _templateId;
			}
		}

		private DataTable TemplateContents
		{
			get
			{
				return _dtTemplateContents;
			}
			set
			{
				_dtTemplateContents = value;
			}
		}

		private Hashtable ColumnValidator
		{
			get
			{
				return _htColumnValidator;
			}
		}

		private void InitColumnValidator()
		{
			_htColumnValidator.Add("费用名", new MessageModel(@"^\w+$", 
				"费用名不能为空，不能重复，且必须是中文，英文，或数字！"));
			_htColumnValidator.Add("fullDays", new MessageModel(@"^\d+$|^-{1}$",
				"全勤天数必须是有效的数字，如果不需要，请用\"-\"表示"));
			_htColumnValidator.Add("fullDaysSpend", new MessageModel(@"^\d+$|^[1-9]\d*\.\d*$|^0\.\d*[1-9]\d*$|^-{1}$",
				"全勤费用必须是有效的数字，如果不需要，请用\"-\"表示"));
			_htColumnValidator.Add("halfDaysSpend", new MessageModel(@"^\d+$|^[1-9]\d*\.\d*$|^0\.\d*[1-9]\d*$|^-{1}$",
				"半勤费用必须是有效的数字，如果不需要，请用\"-\"表示"));
			_htColumnValidator.Add("perDaySpend", new MessageModel(@"^\d+$|^[1-9]\d*\.\d*$|^0\.\d*[1-9]\d*$|^-{1}$",
				"一次出勤费用必须是有效的数字，如果不需要，请用\"-\"表示"));
			_htColumnValidator.Add("noSpendMonth", new MessageModel(@"^\d{1,2}$|^(\d{1,2},)+\d{1,2}$|^-{1}$",
				"排除月必须是有效的数字，如果有多个月份，需用\",\"进行分隔，如果不需要，请用\"-\"表示"));
			_htColumnValidator.Add("halfSpendMonth",new MessageModel(@"^\d{1,2}$|^(\d{1,2},)+\d{1,2}$|^-{1}$",
				"半价月必须是有效的数字，如果有多个月份，需用\",\"进行分隔，如果不需要，请用\"-\"表示"));
		}

		private struct MessageModel
		{
			private string _expression;
			private string _message;

			public MessageModel(string expression, string message)
			{
				_expression = expression;
				_message = message;
			}

			public string Expression
			{
				get
				{
					return _expression;
				}
				set
				{
					_expression = value;
				}
			}

			public string Message
			{
				get
				{
					return _message;
				}
				set
				{
					_message = value;
				}
			}
		}

		private void InitGirdView(DataTable dtGrade)
		{
			_cn = new CustomStyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.NotEqual, 
				gridView1.Columns["费用名"], null, ((MessageModel)ColumnValidator["费用名"]).Expression);
			_cn.Appearance.BackColor = Color.Red;
			_cn.Appearance.ForeColor = Color.White;
			gridView1.FormatConditions.Add(_cn);

			
			_cn = new CustomStyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.NotEqual, 
				gridView1.Columns["fullDays"], null, ((MessageModel)ColumnValidator["fullDays"]).Expression);
			_cn.Appearance.BackColor = Color.Red;
			_cn.Appearance.ForeColor = Color.White;
			gridView1.FormatConditions.Add(_cn); 

			_cn = new CustomStyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.NotEqual, 
				gridView1.Columns["fullDaysSpend"], null, ((MessageModel)ColumnValidator["fullDaysSpend"]).Expression);
			_cn.Appearance.BackColor = Color.Red;
			_cn.Appearance.ForeColor = Color.White;
			gridView1.FormatConditions.Add(_cn); 

			_cn = new CustomStyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.NotEqual, 
				gridView1.Columns["halfDaysSpend"], null, ((MessageModel)ColumnValidator["halfDaysSpend"]).Expression);
			_cn.Appearance.BackColor = Color.Red;
			_cn.Appearance.ForeColor = Color.White;
			gridView1.FormatConditions.Add(_cn); 

			_cn = new CustomStyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.NotEqual, 
				gridView1.Columns["perDaySpend"], null, ((MessageModel)ColumnValidator["perDaySpend"]).Expression);
			_cn.Appearance.BackColor = Color.Red;
			_cn.Appearance.ForeColor = Color.White;
			gridView1.FormatConditions.Add(_cn); 

			_cn = new CustomStyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.NotEqual, 
				gridView1.Columns["noSpendMonth"], null, ((MessageModel)ColumnValidator["noSpendMonth"]).Expression);
			_cn.Appearance.BackColor = Color.Red;
			_cn.Appearance.ForeColor = Color.White;
			gridView1.FormatConditions.Add(_cn);

			_cn = new CustomStyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.NotEqual, 
				gridView1.Columns["halfSpendMonth"], null, ((MessageModel)ColumnValidator["halfSpendMonth"]).Expression);
			_cn.Appearance.BackColor = Color.Red;
			_cn.Appearance.ForeColor = Color.White;
			gridView1.FormatConditions.Add(_cn);

			foreach(DataRow getGradeList in dtGrade.Rows)
			{
				repositoryItemComboBox1.Items.AddRange(
					new object[]{getGradeList[1].ToString()});
			}
		}

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			bool result = new FinanInfoSystem().IsFinanceStatExisted(TemplateName);
			if (result)
			{
				btnAdd.Enabled = false;
				btnDelete.Enabled = false;
				MessageBox.Show("该模板正在使用，添加或删除操作都会影响数据的完整性，我们建议您重新增加一个模板以反映这次使用！");
			}
			else
			{
				gridView1.AddNewRow();
			}
		}

		private void InitNewTemplateContents()
		{
			_dtTemplateContents = new DataTable();
			_dtTemplateContents.Columns.AddRange(new DataColumn[]{	new DataColumn("费用名", Type.GetType("System.String")), new DataColumn("fullDays", Type.GetType("System.String")),
																	 new DataColumn("fullDaysSpend", Type.GetType("System.String")), new DataColumn("halfDaysSpend", Type.GetType("System.String")),
																	 new DataColumn("perDaySpend", Type.GetType("System.String")), new DataColumn("noSpendMonth", Type.GetType("System.String")),
																	 new DataColumn("halfSpendMonth", Type.GetType("System.String")), new DataColumn("指定年级", Type.GetType("System.String")), 
																	 new DataColumn("指定班级", Type.GetType("System.String"))});
			_dtTemplateContents.PrimaryKey = new DataColumn[] { _dtTemplateContents.Columns["费用名"],
				_dtTemplateContents.Columns["指定年级"], _dtTemplateContents.Columns["指定班级"]};
		}

		public void Finan2Details_Load(object sender, EventArgs e)
		{		
			if (IsModify)
			{
				txtTemplateName.Text = TemplateName;
				DataTable dtTempalteContents = new FinanInfoSystem().GetTemplateContents(TemplateName);
				if (dtTempalteContents != null && dtTempalteContents.Rows.Count != 0)
				{
					TemplateContents = dtTempalteContents;
					TemplateContents.Columns["name"].ColumnName = "费用名";
					TemplateContents.Columns["grade"].ColumnName = "指定年级";
					TemplateContents.Columns["class"].ColumnName = "指定班级";
					费用名.FieldName = "费用名";
					指定年级.FieldName = "指定年级";
					指定班级.FieldName = "指定班级";
					TemplateContents.PrimaryKey = new DataColumn[]{TemplateContents.Columns["费用名"], 
																	  TemplateContents.Columns["指定年级"], TemplateContents.Columns["指定班级"]};
					gridControl1.DataSource = TemplateContents;
				}
				else
				{
					gridControl1.DataSource = TemplateContents;
					MessageBox.Show("您指定的模板不存在，您现在可以添加一个模板");
				}
			}
			else
			{
				gridControl1.DataSource = TemplateContents;
			}
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if (!Regex.Match(txtTemplateName.Text, @"^\w+$", RegexOptions.IgnoreCase).Success)
			{
				MessageBox.Show("模板名字不能为空，且必须是中文，英文，或数字！");
				return;
			}

			if (!IsValidToSave())
			{
				MessageBox.Show("保存数据中出现错误，请检查红色单元格内的错误提示！");
			}
			else
			{
				try
				{
					DateTime date = DateTime.Now;
					DataTable dtAddToTemplate = TemplateContents.Clone();
					foreach(DataRow dr in TemplateContents.Rows)
					{
						new FinanInfoSystem().AddTemplateContents(TemplateID, txtTemplateName.Text.Trim(), dr, date);
					}

					new FinanInfoSystem().DeleteTemplateContents(null, null, null, TemplateID, date);

					MessageBox.Show("保存成功！");
					OnSaveSucceeded();
					this.Close();
				}
				catch
				{
					MessageBox.Show("保存中出现错误，请重试！");
				}
			}
		}

		private bool IsValidToSave()
		{
			bool result = false;

			if (TemplateContents.Rows.Count == 0)
			{
				return false;
			}

			foreach(DataRow dr in TemplateContents.Rows)
			{
				result = Regex.Match(dr["费用名"].ToString(), ((MessageModel)ColumnValidator["费用名"]).Expression,
					RegexOptions.IgnoreCase).Success;
				result &= Regex.Match(dr["fullDays"].ToString(), ((MessageModel)ColumnValidator["fullDays"]).Expression,
					RegexOptions.IgnoreCase).Success;
				result &= Regex.Match(dr["fullDaysSpend"].ToString(), ((MessageModel)ColumnValidator["fullDaysSpend"]).Expression,
					RegexOptions.IgnoreCase).Success;
				result &= Regex.Match(dr["halfDaysSpend"].ToString(), ((MessageModel)ColumnValidator["halfDaysSpend"]).Expression,
					RegexOptions.IgnoreCase).Success;
				result &= Regex.Match(dr["perDaySpend"].ToString(), ((MessageModel)ColumnValidator["perDaySpend"]).Expression,
					RegexOptions.IgnoreCase).Success;
				result &= Regex.Match(dr["noSpendMonth"].ToString(), ((MessageModel)ColumnValidator["noSpendMonth"]).Expression,
					RegexOptions.IgnoreCase).Success;
				result &= Regex.Match(dr["halfSpendMonth"].ToString(), ((MessageModel)ColumnValidator["halfSpendMonth"]).Expression,
					RegexOptions.IgnoreCase).Success;

				if (!result)
				{
					return false;
				}
			}

			return true;
		}

		private string GetCellHintText(GridView view, int rowHandle, DevExpress.XtraGrid.Columns.GridColumn column) 
		{
			string ret = view.GetRowCellDisplayText(rowHandle, column);
			bool result = Regex.Match(ret, ((MessageModel)ColumnValidator[column.Name]).Expression, RegexOptions.IgnoreCase).Success;
			if (!result)
			{
				return ((MessageModel)ColumnValidator[column.Name]).Message;
			}
			else
			{
				return ret + " 是有效的数据";
			}
		}

		private void toolTipController1_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
		{
			if(e.SelectedControl != gridControl1)
			{
				return;
			}

			ToolTipControlInfo info = null;
			try 
			{
				GridView view = gridControl1.GetViewAt(e.ControlMousePosition) as GridView;
				if(view == null) return;
				GridHitInfo hi = view.CalcHitInfo(e.ControlMousePosition);
				if(hi.InRowCell) 
				{
					info = new ToolTipControlInfo(new CellToolTipInfo(hi.RowHandle, hi.Column, "cell"), 
						GetCellHintText(view, hi.RowHandle, hi.Column));
					return;
				}
			}
			finally 
			{
				e.Info = info;
			}
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			DialogResult messageResult = MessageBox.Show("是否确认删除选中行？","消息提示框！",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if (messageResult == DialogResult.Yes)
			{
				try
				{
					if (gridView1.GetSelectedRows()[0] < 0)
					{
						gridView1.DeleteRow(gridView1.GetSelectedRows()[0]);
					}
					else
					{
						string name = gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["费用名"].ToString();
						string grade = gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["指定年级"].ToString();
						string className = gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["指定班级"].ToString();
						new FinanInfoSystem().DeleteTemplateContents(name, grade, className, int.MinValue, DateTime.MinValue);
						TemplateContents.Rows.Remove(gridView1.GetDataRow(gridView1.GetSelectedRows()[0]));
						TemplateContents.AcceptChanges();
					}
				}
				catch
				{
					MessageBox.Show("删除失败，请重试！");
				}
			}
		}

		private void repositoryItemComboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int i = gridView1.GetSelectedRows()[0];
			repositoryItemComboBox2.Items.Clear();
			DevExpress.XtraEditors.ComboBoxEdit cbeGrade = (DevExpress.XtraEditors.ComboBoxEdit)sender;
			string grade = cbeGrade.SelectedItem.ToString();
			if (grade.Length != 0  && !grade.Equals("不选择"))
			{
				repositoryItemComboBox2.Items.Add("不选择");
				GetStuInfoByCondition getStuInfoByCondition = new GetStuInfoByCondition();
				string getGradeNumberFromCombo = getStuInfoByCondition.getGradeInfo(
					grade,"").Tables[0].Rows[0][0].ToString();
				foreach(DataRow getClassList in getStuInfoByCondition.getClassInfo("","",
					getGradeNumberFromCombo).Tables[0].Rows)
				{
					repositoryItemComboBox2.Items.AddRange(
						new object[]{getClassList[1].ToString()});
				}
			}
			else 
			{
				if (grade.Equals("不选择"))
				{
					repositoryItemComboBox2.Items.Clear();
					repositoryItemComboBox2.Items.Add("不选择");
				}
			}

			gridView1.SetRowCellValue(i, gridView1.Columns["指定班级"], null);
			gridView1.SetRowCellValue(i, gridView1.Columns["指定年级"], grade);
		}

		private class CustomStyleFormatCondition : DevExpress.XtraGrid.StyleFormatCondition
		{
			public CustomStyleFormatCondition(
				DevExpress.XtraGrid.FormatConditionEnum condition, DevExpress.XtraGrid.Columns.GridColumn column, 
				object tag, object pattern) : base(condition, column, tag, pattern)
			{
				//
				// TODO: 在此处添加构造函数逻辑
				//
			}

			public override bool IsValid
			{
				get
				{
					return base.Condition == FormatConditionEnum.NotEqual;
				}
			}
		}
	}
}

