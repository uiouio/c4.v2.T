
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using CPTT.BusinessFacade;
using CPTT.SystemFramework;
using System.Threading;

namespace CPTT.WinUI.Panels
{
	/// <summary>
	/// Summary description for NutritionManagement.
	/// </summary>
	public class NutritionManagement : DevExpress.XtraEditors.XtraUserControl
	{
		private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.Utils.Frames.NotePanel notePanel7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
		private DevExpress.XtraEditors.GroupControl groupControl_FoodCategory;
		private DevExpress.XtraTreeList.TreeList treeList_FoodStock;
		private DevExpress.XtraEditors.TextEdit textEdit_FoodSearch;
		private DevExpress.XtraEditors.SimpleButton simpleButton_FoodAdd;
		private DevExpress.XtraEditors.SimpleButton simpleButton_FoodSave;
		private DevExpress.XtraEditors.SimpleButton simpleButton_FoodDelete;
		private DevExpress.XtraGrid.GridControl gridControl_FoodNutrition;
		private DevExpress.XtraEditors.GroupControl groupControl_FoodNutrition;
		private DevExpress.XtraEditors.GroupControl groupControl_FoodNutModify;
		private DevExpress.Utils.Frames.NotePanel notePanel_FoodName;
		private DevExpress.Utils.Frames.NotePanel notePanel_FoodCategory;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_FoodCategory;
		private DevExpress.Utils.Frames.NotePanel notePanel_Protein;
		private DevExpress.Utils.Frames.NotePanel notePanel_Fat;
		private DevExpress.Utils.Frames.NotePanel notePanel_Carbohydrate;
		private DevExpress.XtraEditors.TextEdit textEdit_Protein;
		private DevExpress.XtraEditors.TextEdit textEdit_Fat;
		private DevExpress.XtraEditors.TextEdit textEdit_Carbohydrate;
		private DevExpress.Utils.Frames.NotePanel notePanel_FoodRemark;
		private DevExpress.XtraEditors.MemoEdit memoEdit_FoodRemark;
		private System.ComponentModel.IContainer components;
		private FoodManagementSystem foodManagementSystem;
		private DevExpress.XtraEditors.TextEdit textEdit_Energy;
		private DevExpress.Utils.Frames.NotePanel notePanel_Energy;
		private DevExpress.XtraEditors.SimpleButton simpleButton_FoodBack;
		private DevExpress.XtraEditors.TextEdit textEdit_BindingID;
		private DevExpress.XtraEditors.TextEdit textEdit_FoodName;
		private System.Windows.Forms.ImageList imageList1;
		private DevExpress.XtraEditors.SimpleButton simpleButton_FoodModify;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
		private DevExpress.XtraEditors.PanelControl panelControl2;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
		private DevExpress.Utils.Frames.NotePanel notePanel_Recipe_BegDate;
		private DevExpress.XtraEditors.DateEdit dateEdit_Recipe_BegDate;
		private DevExpress.Utils.Frames.NotePanel notePanel_Recipe_EndDate;
		private DevExpress.XtraEditors.DateEdit dateEdit_Recipe_EndDate;
		private DevExpress.Utils.Frames.NotePanel notePanel_Recipe_RecipeCategory;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Recipe_RecipeCategory;
		private DevExpress.Utils.Frames.NotePanel notePanel_Recipe;
		private DevExpress.Utils.Frames.NotePanel notePanel_Recipe_FoodName;
		private DevExpress.XtraEditors.TextEdit textEdit_Recipe_FoodName;
		private DevExpress.XtraEditors.GroupControl groupControl_RecipeOpr;
		private DevExpress.XtraEditors.SimpleButton simpleButton_RecipeModify;
		private DevExpress.XtraEditors.SimpleButton simpleButton_RecipeSave;
		private DevExpress.XtraEditors.GroupControl groupControl_RecipeSer;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_RecipeSer_FoodCategory;
		private DevExpress.Utils.Frames.NotePanel notePanel_RecipeSer_FoodCategory;
		private DevExpress.XtraEditors.TextEdit textEdit_RecipeSer_FoodName;
		private DevExpress.Utils.Frames.NotePanel notePanel_RecipeSer_FoodName;
		private DevExpress.XtraEditors.GroupControl groupControl_RecipeLogin;
		private DevExpress.XtraEditors.TextEdit textEdit_RecipeLogin_Name;
		private DevExpress.Utils.Frames.NotePanel notePanel_RecipeLogin_Name;
		private DevExpress.XtraEditors.DateEdit dateEdit_RecipeLogin_Date;
		private DevExpress.Utils.Frames.NotePanel notePanel_RecipeLogin_Date;
		private DevExpress.XtraEditors.TextEdit textEdit_RecipeLogin_FoodTake;
		private DevExpress.Utils.Frames.NotePanel notePanel_RecipeLogin_FoodTake;
		private DevExpress.Utils.Frames.NotePanel notePanel_RecipeLogin_FoodName;
		private string getFoodCateName = "";
		private DevExpress.Utils.ToolTipController toolTipController1;
		private string getRecFoodCateName = "";
		private DevExpress.XtraEditors.TextEdit textEdit_RecipeLogin_FoodName;
		private DevExpress.XtraEditors.TextEdit textEdit_RecipeLogin_BindingID;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl3;
		private DevExpress.XtraEditors.PanelControl panelControl3;
		private DevExpress.XtraEditors.GroupControl groupControl_MealAdd;
		private DevExpress.Utils.Frames.NotePanel notePanel_MealNameAdd;
		private DevExpress.Utils.Frames.NotePanel notePanel_MealName;
		private DevExpress.XtraEditors.TextEdit textEdit_MealRemark;
		private DevExpress.Utils.Frames.NotePanel notePanel_MealRemark;
		private DevExpress.XtraEditors.GroupControl groupControl_MealLogin;
		private DevExpress.XtraEditors.CheckEdit checkEdit_Breakfast;
		private DevExpress.XtraEditors.CheckEdit checkEdit_Lunch;
		private DevExpress.XtraEditors.CheckEdit checkEdit_Snack;
		private DevExpress.Utils.Frames.NotePanel notePanel_MealArr;
		private DevExpress.XtraEditors.SimpleButton simpleButton_MealSave;
		private DevExpress.XtraEditors.SimpleButton simpleButton_MealAdd;
		private DevExpress.XtraEditors.GroupControl groupControl_MealPreview;
		private DevExpress.XtraEditors.GroupControl groupControl_MealArr;
		private DevExpress.Utils.Frames.NotePanel notePanel_MealArr_Name;
		private DevExpress.Utils.Frames.NotePanel notePanel_MealArr_Grade;
		private DevExpress.XtraEditors.CheckEdit checkEdit_MealArr_gOne;
		private DevExpress.XtraEditors.CheckEdit checkEdit_MealArr_gTwo;
		private DevExpress.XtraEditors.CheckEdit checkEdit_MealArr_gThree;
		private DevExpress.XtraEditors.CheckEdit checkEdit_MealArr_gFour;
		private DevExpress.XtraEditors.CheckEdit checkEdit_MealArr_gFive;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl4;
		private DevExpress.XtraEditors.CheckEdit checkEdit_MealArr_IsUsed;
		private DevExpress.Utils.Frames.NotePanel notePanel_GradeArr;
		private DevExpress.Utils.Frames.NotePanel notePanel_MealArr_ePreview;
		private System.Windows.Forms.Label label_Breakfast;
		private System.Windows.Forms.Label label_Super;
		private System.Windows.Forms.Label label_Snack;
		private System.Windows.Forms.Label label_Lunch;
		private DevExpress.XtraEditors.TextEdit textEdit_MealID;
		private DevExpress.XtraEditors.TextEdit textEdit_MealName;
		private DevExpress.XtraEditors.CheckEdit checkEdit_Dinner;
		private DevExpress.XtraEditors.SimpleButton simpleButton_MealDelete;
		private DevExpress.XtraEditors.SimpleButton simpleButton_MealBack;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_MealArr_Name;
		private DevExpress.XtraBars.BarManager barManager1;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
		private DevExpress.XtraBars.PopupMenu popupMenu1;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_MealRefresh;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl5;
		private DevExpress.XtraEditors.PanelControl panelControl4;
		private DevExpress.XtraEditors.GroupControl groupControl_Meal_Search;
		private DevExpress.Utils.Frames.NotePanel notePanel_Meal_Search;
		private DevExpress.Utils.Frames.NotePanel notePanel_Meal_BegDate;
		private DevExpress.XtraEditors.DateEdit dateEdit_Meal_BegDate;
		private DevExpress.Utils.Frames.NotePanel notePanel_Meal_EndDate;
		private DevExpress.XtraEditors.DateEdit dateEdit_Meal_EndDate;
		private DevExpress.XtraEditors.SimpleButton simpleButton_Meal_PrintReport;
		private DevExpress.XtraEditors.SimpleButton simpleButton_Meal_PreviewReport;
		private DevExpress.XtraEditors.GroupControl groupControl_Meal_ReportPreview;
		private string[] ColumnHints = new string[] { "食物名称", "蛋白质含量","脂肪含量",
															"碳水化合物含量","能量含量","食物备注" };

		private string path = Directory.GetCurrentDirectory() + @"\report\nutrition.xls";
		private string destPath = Directory.GetCurrentDirectory() + @"\report\nutritionCopy.xls";
		private DevExpress.XtraTab.XtraTabPage xtraTabPage5;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage6;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl6;
		private DevExpress.XtraEditors.PanelControl panelControl5;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl7;
		private DevExpress.XtraEditors.PanelControl panelControl6;
		private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView advBandedGridView1;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn2;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn3;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn4;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn5;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn6;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn7;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn8;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn9;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn10;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn11;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn12;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn13;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn14;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn15;
		private DevExpress.XtraEditors.GroupControl groupControl_HInputSer;
		private DevExpress.Utils.Frames.NotePanel notePanel_HInputGender;
		private DevExpress.XtraEditors.DataNavigator dataNavigator_HInputNav;
		private DevExpress.XtraEditors.TextEdit textEdit_HInputNumber;
		private DevExpress.XtraEditors.TextEdit textEdit_HInputName;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_HInputClass;
		private DevExpress.Utils.Frames.NotePanel notePanel_HInputClass;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_HInputGrade;
		private DevExpress.Utils.Frames.NotePanel notePanel_HInputGrade;
		private DevExpress.Utils.Frames.NotePanel notePanel_HInputSer;
		private DevExpress.Utils.Frames.NotePanel notePanel_HInputNumber;
		private DevExpress.Utils.Frames.NotePanel notePanel_HInputName;
		private DevExpress.XtraEditors.SimpleButton simpleButton_HInputSave;
		private DevExpress.XtraEditors.GroupControl groupControl_HInputDiagInfo;
		private DevExpress.XtraEditors.GroupControl groupControl_HInputDiagResult;
		private DevExpress.Utils.Frames.NotePanel notePanel_DiagResultAge;
		private DevExpress.Utils.Frames.NotePanel notePanel_HInputDaigInfo;
		private DevExpress.Utils.Frames.NotePanel notePanel_DiagWeight;
		private DevExpress.Utils.Frames.NotePanel notePanel_DiagHeight;
		private DevExpress.XtraEditors.DateEdit dateEdit_DiagCheckDate;
		private DevExpress.Utils.Frames.NotePanel notePanel_DiagCheckDate;
		private DevExpress.XtraEditors.SimpleButton simpleButton_HInputDiag;
		private DevExpress.XtraEditors.TextEdit textEdit_DiagResultHeight;
		private DevExpress.XtraEditors.TextEdit textEdit_DiagResultWeight;
		private DevExpress.Utils.Frames.NotePanel notePanel_DiagResultWeight;
		private DevExpress.Utils.Frames.NotePanel notePanel_DiagResultNut;
		private DevExpress.Utils.Frames.NotePanel notePanel_DiagResultWHO;
		private DevExpress.Utils.Frames.NotePanel notePanel_DiagResultHeight;
		private DevExpress.XtraEditors.TextEdit textEdit_DiagResultWHO;
		private DevExpress.XtraEditors.TextEdit textEdit_DiagResultNut;
		private DevExpress.XtraEditors.TextEdit textEdit_DiagResultAge;
		private DevExpress.XtraEditors.MemoEdit memoEdit_DiagRemark;
		private DevExpress.Utils.Frames.NotePanel notePanel_DiagRemark;
		private DevExpress.XtraEditors.TextEdit textEdit_DiagWeight;
		private DevExpress.XtraEditors.TextEdit textEdit_DiagHeight;
		private DevExpress.XtraGrid.GridControl gridControl_HInputStu;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
		private FoodManagementPrintSystem foodManagementPrintSystem;
		private string getGradeNumberFromCombo = "0";
		private string getClassNumberFromCombo = "0";
		private string getGender = "";
		private GetStuInfoByCondition getStuInfoByCondition;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_HInputGender;
		private DevExpress.Utils.Frames.NotePanel notePanel_HInputBirthday;
		private DevExpress.Utils.Frames.NotePanel notePanel_DiagCheckName;
		private DevExpress.XtraEditors.TextEdit textEdit_DiagCheckBindingID;
		private DevExpress.XtraEditors.TextEdit textEdit_DiagCheckName;
		private DevExpress.Utils.Frames.NotePanel notePanel_DiagCheckGender;
		private DevExpress.XtraEditors.TextEdit textEdit_DiagCheckGender;
		private DevExpress.Utils.Frames.NotePanel notePanel1;
		private DevExpress.XtraEditors.TextEdit textEdit_HInputBirthday;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_HInputStd;
		private DevExpress.Utils.Frames.NotePanel notePanel_HInputStd;
		private DevExpress.XtraEditors.SimpleButton simpleButton_HInputModify;
		private DevExpress.XtraEditors.SimpleButton simpleButton_HInputDelete;
		private HealthManagementSystem healthManagementSystem;
		private HealthMgmt healthMgmt;
		private DevExpress.XtraEditors.GroupControl groupControl_HOutputPrintType;
		private DevExpress.XtraEditors.CheckEdit checkEdit_HOutputPrintType3rd;
		private DevExpress.XtraEditors.CheckEdit checkEdit_HOutputPrintType2nd;
		private DevExpress.XtraEditors.CheckEdit checkEdit_HOutputPrintType1st;
		private DevExpress.XtraEditors.GroupControl groupControl_HOutputSer;
		private DevExpress.XtraEditors.DateEdit dateEdit_HOutputEndDate;
		private DevExpress.XtraEditors.DateEdit dateEdit_HOutputBegDate;
		private DevExpress.Utils.Frames.NotePanel notePanel_HOutputEndDate;
		private DevExpress.Utils.Frames.NotePanel notePanel_HOutputBegDate;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_HOutputGender;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_HOutputResult;
		private DevExpress.Utils.Frames.NotePanel notePanel_HOutputResult;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_HOutputType;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_HOutputAge;
		private DevExpress.Utils.Frames.NotePanel notePanel_HOutputType;
		private DevExpress.Utils.Frames.NotePanel notePanel_HOutputAge;
		private DevExpress.XtraEditors.TextEdit textEdit_HOutputNumber;
		private DevExpress.XtraEditors.TextEdit textEdit_HOutputName;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_HOutputClass;
		private DevExpress.Utils.Frames.NotePanel notePanel_HOutputClass;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_HOutputGrade;
		private DevExpress.Utils.Frames.NotePanel notePanel_HOutputGrade;
		private DevExpress.Utils.Frames.NotePanel notePanel_HOutputNumber;
		private DevExpress.Utils.Frames.NotePanel notePanel_HOutputName;
		private DevExpress.Utils.Frames.NotePanel notePanel_HOutputGender;
		private DevExpress.XtraGrid.GridControl gridControl_HOutputGridShow;
		private DevExpress.XtraEditors.SimpleButton simpleButton_HOutputPrint;
		private bool isCityStd = true;
		private string getOutputGrade = "";
		private string getOutputClass = "";
		private string getOutputGender = "";
		private string getOutputType = "";
		private string getOutputResult = "";
		private string getOutputName = "";
		private string getOutputNumber = "";
		private string getOutputAge = "";
		private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
		private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
		private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
		private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
		private string healthPath = Directory.GetCurrentDirectory() + @"\report\health.xls";
		private string healthDestPath = Directory.GetCurrentDirectory() + @"\report\healthCopy.xls";
		private HealthManagementPrintSystem healthManagementPrintSystem;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage7;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage8;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage9;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl8;
		private DevExpress.XtraEditors.GroupControl groupControl_WatchSer;
		private DevExpress.XtraEditors.TextEdit textEdit_WatchNumber;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_WatchClass;
		private DevExpress.Utils.Frames.NotePanel notePanel_WatchClass;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_WatchGrade;
		private DevExpress.Utils.Frames.NotePanel notePanel_WatchGrade;
		private DevExpress.Utils.Frames.NotePanel notePanel_WatchNumber;
		private DevExpress.Utils.Frames.NotePanel notePanel_WatchName;
		private DevExpress.Utils.Frames.NotePanel notePanel_WatchState;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_WatchState;
		private DevExpress.XtraEditors.GroupControl groupControl_WatchStuList;
		private DevExpress.XtraEditors.PanelControl panelControl7;
		private DevExpress.XtraEditors.GroupControl groupControl_WatchMorningRec;
		private DevExpress.XtraEditors.TextEdit textEdit_WatchMorningNumber;
		private DevExpress.XtraEditors.TextEdit textEdit_WatchMorningName;
		private DevExpress.Utils.Frames.NotePanel notePanel_WatchMorningNumber;
		private DevExpress.Utils.Frames.NotePanel notePanel_WatchMorningName;
		private DevExpress.XtraEditors.TextEdit textEdit_WatchMorningTreat;
		private DevExpress.Utils.Frames.NotePanel notePanel_WatchMorningTreat;
		private DevExpress.XtraEditors.TextEdit textEdit_WatchMorningOState;
		private DevExpress.Utils.Frames.NotePanel notePanel_WatchMorningOState;
		private DevExpress.Utils.Frames.NotePanel notePanel_WatchMorningMouth;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_WatchMorningHeat;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_WatchMorningMouth;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_WatchMorningSpirit;
		private DevExpress.Utils.Frames.NotePanel notePanel_WatchMorningHeat;
		private DevExpress.Utils.Frames.NotePanel notePanel_WatchMorningSkin;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_WatchMorningSkin;
		private DevExpress.Utils.Frames.NotePanel notePanel_WatchMorningSpirit;
		private DevExpress.XtraEditors.SimpleButton simpleButton_WatchHandle;
		private DevExpress.XtraEditors.SimpleButton simpleButton_WatchReport;
		private DevExpress.XtraEditors.GroupControl groupControl_WatchRecList;
		private DevExpress.Utils.Frames.NotePanel notePanel_WatchStuList;
		private DevExpress.Utils.Frames.NotePanel notePanel_WatchRecList;
		private DevExpress.XtraGrid.GridControl gridControl_WatchRecList;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn30;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn32;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn34;
		private DevExpress.XtraEditors.GroupControl groupControl_WatchWholeDay;
		private DevExpress.XtraEditors.GroupControl groupControl_WatchWholeDayReg;
		private DevExpress.Utils.Frames.NotePanel notePanel_WatchWholeDayMovement;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_WatchWholeDayMovement;
		private DevExpress.Utils.Frames.NotePanel notePanel_WatchWholeDaySpirit;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_WatchWholeDaySpirit;
		private DevExpress.Utils.Frames.NotePanel notePanel_WatchWholeDayAppetite;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_WatchWholeDayAppetite;
		private DevExpress.Utils.Frames.NotePanel notePanel_WatchWholeDayStool;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_WatchWholeDayStool;
		private DevExpress.Utils.Frames.NotePanel notePanel_WatchWholeDaySleep;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_WatchWholeDaySleep;
		private DevExpress.Utils.Frames.NotePanel notePanel_WatchWholeDayCough;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_WatchWholeDayCough;
		private DevExpress.XtraEditors.GroupControl groupControl_WatchWholDayHandle;
		private DevExpress.XtraEditors.CheckEdit checkEdit_WatchWholeDayCtrAct;
		private DevExpress.XtraEditors.CheckEdit checkEdit_WatchWholeDayLifeAttention;
		private DevExpress.XtraEditors.CheckEdit checkEdit_WatchWholeDayCtrSeafood;
		private DevExpress.XtraEditors.CheckEdit checkEdit_WatchWholeDayHeat;
		private DataSet dsHealthOutput;
		private DevExpress.XtraEditors.SimpleButton simpleButton_WatchBack;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
		private DevExpress.XtraGrid.GridControl gridControl_WatchStuList;
		private string getWatchGrade = "";
		private string getWatchClass = "";
		private string getWatchName = "";
		private string getWatchNumber = "";
		private DevExpress.XtraEditors.TextEdit textEdit_WatchWholeDayElse;
		private DevExpress.Utils.Frames.NotePanel notePanel_WatchWholeDayElse;
		private DevExpress.Utils.Frames.NotePanel notePanel_WatchBegDate;
		private DevExpress.Utils.Frames.NotePanel notePanel_WatchEndDate;
		private DevExpress.XtraEditors.DateEdit dateEdit_WatchBegDate;
		private DevExpress.XtraEditors.DateEdit dateEdit_WatchEndDate;
		private DevExpress.XtraEditors.SimpleButton simpleButton_WatchDelete;
		private string getWatchState = "";

		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl9;
		private DevExpress.XtraEditors.PanelControl panelControl8;
		private DevExpress.XtraBars.PopupMenu popupMenu2;
		private DevExpress.XtraEditors.GroupControl groupControl_MedReg_Ser;
		private DevExpress.XtraEditors.TextEdit textEdit_MedReg_Number;
		private DevExpress.XtraEditors.TextEdit textEdit_MedReg_Name;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_MedReg_Class;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedReg_Class;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_MedReg_Grade;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedReg_Grade;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedReg_Number;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedReg_Name;
		private DevExpress.XtraEditors.GroupControl groupControl_MedReg_StuList;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedReg_Ser;
		private DevExpress.XtraEditors.SimpleButton simpleButton_MedReg_Reg;
		private DevExpress.XtraEditors.GroupControl groupControl_MedReg_DiagInfo;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedReg_Diag;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_MedReg_Diag;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedReg_UpperSym;
		private DevExpress.XtraEditors.TextEdit textEdit_MedReg_UpperSym;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedReg_LungSym;
		private DevExpress.XtraEditors.TextEdit textEdit_MedReg_LungSym;
		private DevExpress.Utils.Frames.NotePanel notePanel__MedReg_ThroatSym;
		private DevExpress.XtraEditors.TextEdit textEdit_MedReg_ThroatSym;
		private DevExpress.XtraEditors.TextEdit textEdit_MedReg_AbdomenSym;
		private DevExpress.XtraEditors.TextEdit textEdit_MedReg_SkinSym;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedReg_EnteronSym;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedReg_AbdomenSym;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedReg_SkinSym;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedReg_FacialSym;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedReg_Else;
		private DevExpress.XtraEditors.TextEdit textEdit_MedReg_FacialSym;
		private DevExpress.XtraEditors.TextEdit textEdit_MedReg_Else;
		private DevExpress.XtraEditors.ListBoxControl listBoxControl_MedReg_MedInfo;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedReg_MedName;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedReg_MedType;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedReg_MedTake;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedReg_Taketimes;
		private DevExpress.XtraEditors.TextEdit textEdit_MedReg_MedType;
		private DevExpress.XtraEditors.TextEdit textEdit_MedReg_MedTake;
		private DevExpress.XtraEditors.TextEdit textEdit_MedReg_Taketimes;
		private DevExpress.XtraEditors.SimpleButton simpleButton_MedReg_Save;
		private DevExpress.XtraEditors.SimpleButton simpleButton_MedReg_MedCarrAdd;
		private DevExpress.XtraEditors.SimpleButton simpleButton_MedReg_MedCarrDel;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_MedReg_MedAdd;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_MedReg_MedModify;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_MedReg_MedDel;
		private DevExpress.XtraEditors.GroupControl groupControl_MedReg_MedCarrInfo;
		private DevExpress.XtraEditors.GroupControl groupControl_MedReg_MedInfo;
		private DevExpress.XtraEditors.SimpleButton simpleButton_MedReg_Back;
		private DataSet dsWholeDayWatch;
		private string getMedRegGrade = "";
		private string getMedRegClass = "";
		private string getMedRegStuName = "";
		private DevExpress.XtraEditors.TextEdit textEdit_MedReg_EnteronSym;
		private DevExpress.XtraEditors.TextEdit textEdit_MedReg_MedName;
		private string getMedRegStuNumber = "";
		private DevExpress.XtraEditors.ListBoxControl listBoxControl_MedReg_MedCarrInfo;
		private DataSet dsMedInfo;
		private string getMedName;
		private string getMedCategory;
		private int getMedInfoID;
		private int getMedCarrInfoID = 0;
		private string listMedInfo;
		private DevExpress.XtraEditors.SimpleButton simpleButton_MedReg_Modify;
		private string listMedCarrInfo;
		private DevExpress.Utils.Frames.NotePanel notePanel2;
		private DevExpress.XtraGrid.GridControl gridControl_MedReg_StuList;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView9;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn36;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn37;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn38;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl10;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView10;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn39;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn40;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn41;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn42;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn43;
		private DevExpress.XtraEditors.PanelControl panelControl9;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView11;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView12;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn44;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn45;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn46;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn47;
		private DevExpress.XtraEditors.GroupControl groupControl_MedRec_Ser;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedRec_Ser;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_MedRec_Class;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedRec_Class;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_MedRec_Grade;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedRec_Grade;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedRec_Number;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedRec_Name;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedRec_BegDate;
		private DevExpress.XtraEditors.DateEdit dateEdit_MedRec_BegDate;
		private DevExpress.XtraEditors.GroupControl groupControl_MedRec_AbnStuList;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedRec_AbnStuList;
		private DevExpress.XtraGrid.GridControl gridControl_MedRec_AbnStuList;
		private DevExpress.XtraEditors.SimpleButton simpleButton_MedRec_Back;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedRec_EndDate;
		private DevExpress.XtraEditors.DateEdit dateEdit_MedRec_EndDate;
		private DevExpress.XtraEditors.GroupControl groupControl_MedRec_DoseRec;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedRec_DoseRec;
		private DevExpress.XtraGrid.GridControl gridControl_MedRec_DoseRec;
		private DevExpress.XtraEditors.GroupControl groupControl_MedRec_DiagAndDoseAdd;
		private DevExpress.XtraEditors.GroupControl groupControl_MedRec_DiagInfo;
		private DevExpress.XtraEditors.TextEdit textEdit_MedRec_Else;
		private DevExpress.XtraEditors.TextEdit textEdit_MedRec_FacialSym;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedRec_Else;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedRec_FacialSym;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedRec_SkinSym;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedRec_AbdomenSym;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedRec_EnteronSym;
		private DevExpress.XtraEditors.TextEdit textEdit_MedRec_SkinSym;
		private DevExpress.XtraEditors.TextEdit textEdit_MedRec_AbdomenSym;
		private DevExpress.XtraEditors.TextEdit textEdit_MedRec_EnteronSym;
		private DevExpress.XtraEditors.TextEdit textEdit_MedRec_ThroatSym;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedRec_ThroatSym;
		private DevExpress.XtraEditors.TextEdit textEdit_MedRec_LungSym;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedRec_LungSym;
		private DevExpress.XtraEditors.TextEdit textEdit_MedRec_UpperSym;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedRec_UpperSym;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedRec_Diag;
		private DevExpress.XtraEditors.GroupControl groupControl_MedRec_DoseAdd;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedRec_MedName;
		private DevExpress.XtraEditors.TextEdit textEdit_MedRec_MedName;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedRec_MedTake;
		private DevExpress.XtraEditors.TextEdit textEdit_MedRec_MedTake;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedRec_TakeDate;
		private DevExpress.XtraEditors.TimeEdit timeEdit_MedRec_TakeTime;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_MedRec_TakeRule;
		private DevExpress.XtraEditors.ListBoxControl listBoxControl_MedRec_MedCarrInfo;
		private DevExpress.Utils.Frames.NotePanel notePanel_MedRec_TakeRule;
		private DevExpress.XtraEditors.TextEdit textEdit_MedRec_Diag;
		private DevExpress.XtraEditors.SimpleButton simpleButton_MedRec_Add;
		private string dClickNum;
		private string getMedRecGrade = "";
		private string getMedRecClass = "";
		private string getMedRecStuName = "";
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn48;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn49;
		private DevExpress.XtraEditors.TextEdit textEdit_MedRec_DoseRecDiaID;
		private DevExpress.XtraEditors.TextEdit textEdit_MedRec_AbnDiaID;
		private DevExpress.XtraEditors.TextEdit textEdit_MedRec_Name;
		private DevExpress.XtraEditors.TextEdit textEdit_MedRec_Number;
		private string getMedRecStuNumber = "";
		private DevExpress.XtraEditors.SimpleButton simpleButton_MedRec_Report;
		private string getTakeDate;
		private string stuNumber;
		private DevExpress.XtraBars.PopupMenu popupMenu3;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_MedRec_MultiSer;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_MedRec_MedDel;
		private DevExpress.XtraBars.PopupMenu popupMenu4;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_RecipeRefresh;
		private DevExpress.XtraBars.BarButtonItem barButtonItem_RecipeDelete;
		private bool isInserDoseRec = true;
		private DataSet dsDoseInfo;
		private DevExpress.Utils.Frames.NotePanel notePanel3;
		private DevExpress.XtraGrid.GridControl gridControl_MealPreview;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
		private DevExpress.XtraEditors.SimpleButton simpleButton_MealAppend;
		private DevExpress.XtraEditors.PanelControl panelControl10;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
		private DevExpress.Utils.Frames.NotePanel notePanel4;
		private DevExpress.XtraGrid.GridControl gridControl_Recipe_FoodNutrition;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView14;
		private DevExpress.XtraEditors.PanelControl panelControl11;
		private DevExpress.Utils.Frames.NotePanel notePanel5;
		private DevExpress.XtraGrid.GridControl gridControl_RecipeLogin;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView13;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn50;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn51;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn52;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn53;
		private System.Windows.Forms.SaveFileDialog saveFileDialog_Report;
		private DevExpress.XtraEditors.TextEdit textEdit_WatchName;
		private DevExpress.XtraEditors.SimpleButton simpleButton_WatchSearch;
		private DevExpress.XtraEditors.SimpleButton simpleButton_HOutputSearch;
		private bool clickPerformedOnce = true;
		private RolesSystem rolesSystem;
		private DevExpress.XtraEditors.SimpleButton simpleButton_AbnormalSer;
		private DevExpress.XtraEditors.SimpleButton simpleButton_MedReg_Ser;
		private bool isThisTeacher = true;
		private System.Windows.Forms.HelpProvider helpProvider_NutritionInfo;
		private DevExpress.Utils.Frames.NotePanel notePanel6;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_HInputRegion;
		private string teaAuthority = string.Empty;
		private DevExpress.Utils.Frames.NotePanel notePanel8;
		private DevExpress.Utils.Frames.NotePanel notePanel9;
		private DevExpress.Utils.Frames.NotePanel notePanel10;
		private DevExpress.XtraEditors.TextEdit textEdit_DiagResultUnderWeight;
		private DevExpress.XtraEditors.TextEdit textEdit_DiagResultStunting;
		private DevExpress.XtraEditors.TextEdit textEdit_DiagResultWasting;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_HOutputRegion;
		private DevExpress.Utils.Frames.NotePanel notePanel11;
		private DevExpress.XtraGrid.GridControl gridControl_HOutputNchsGrid;
		private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView advBandedGridView2;
		private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
		private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn1;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn16;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn17;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn18;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn19;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn20;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn21;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn22;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn23;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn24;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn25;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn26;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn27;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn28;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn29;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn30;
		private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand7;
		private bool inputNationalRegion = false;
		private DevExpress.XtraEditors.CheckEdit checkEdit_HOutputPrintType4th;
		private bool outputNationalRegion = false;
		private DevExpress.XtraEditors.TextEdit textEdit_DiagResultHeightWeight;
		private DevExpress.XtraEditors.TextEdit textEdit_DiagResultWHOPer;
		private DevExpress.XtraEditors.TextEdit textEdit_DiagResultX;
		private string useVersion = string.Empty;

		public NutritionManagement()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call
			foodManagementSystem = new FoodManagementSystem();
			foodManagementPrintSystem = new FoodManagementPrintSystem();
			getStuInfoByCondition = new GetStuInfoByCondition();
			healthManagementSystem = new HealthManagementSystem();
			healthMgmt = new HealthMgmt();
			healthManagementPrintSystem = new HealthManagementPrintSystem();
			rolesSystem = new RolesSystem();

			useVersion = CPTT.SystemFramework.Util.UseVersion;

			#region 帮助
			helpProvider_NutritionInfo.HelpNamespace = System.IO.Path.GetDirectoryName(Application.ExecutablePath)
				+ CPTT.SystemFramework.Util.HELP_FILE_NAME;

			this.helpProvider_NutritionInfo.SetHelpKeyword(this.xtraTabPage1,"食物库存管理");
			this.helpProvider_NutritionInfo.SetHelpNavigator(this.xtraTabPage1, System.Windows.Forms.HelpNavigator.KeywordIndex);
			this.helpProvider_NutritionInfo.SetHelpString(this.xtraTabPage1, "");
			this.helpProvider_NutritionInfo.SetShowHelp(this.xtraTabPage1, true);

			this.helpProvider_NutritionInfo.SetHelpKeyword(this.xtraTabPage2,"每日食谱安排");
			this.helpProvider_NutritionInfo.SetHelpNavigator(this.xtraTabPage2, System.Windows.Forms.HelpNavigator.KeywordIndex);
			this.helpProvider_NutritionInfo.SetHelpString(this.xtraTabPage2, "");
			this.helpProvider_NutritionInfo.SetShowHelp(this.xtraTabPage2, true);

			this.helpProvider_NutritionInfo.SetHelpKeyword(this.xtraTabPage3,"集体膳食安排");
			this.helpProvider_NutritionInfo.SetHelpNavigator(this.xtraTabPage3, System.Windows.Forms.HelpNavigator.KeywordIndex);
			this.helpProvider_NutritionInfo.SetHelpString(this.xtraTabPage3, "");
			this.helpProvider_NutritionInfo.SetShowHelp(this.xtraTabPage3, true);

			this.helpProvider_NutritionInfo.SetHelpKeyword(this.xtraTabPage4,"膳食营养综合统计表");
			this.helpProvider_NutritionInfo.SetHelpNavigator(this.xtraTabPage4, System.Windows.Forms.HelpNavigator.KeywordIndex);
			this.helpProvider_NutritionInfo.SetHelpString(this.xtraTabPage4, "");
			this.helpProvider_NutritionInfo.SetShowHelp(this.xtraTabPage4, true);

			this.helpProvider_NutritionInfo.SetHelpKeyword(this.xtraTabPage5,"幼儿身体评测登记");
			this.helpProvider_NutritionInfo.SetHelpNavigator(this.xtraTabPage5, System.Windows.Forms.HelpNavigator.KeywordIndex);
			this.helpProvider_NutritionInfo.SetHelpString(this.xtraTabPage5, "");
			this.helpProvider_NutritionInfo.SetShowHelp(this.xtraTabPage5, true);

			this.helpProvider_NutritionInfo.SetHelpKeyword(this.xtraTabPage6,"幼儿评测结果浏览及打印");
			this.helpProvider_NutritionInfo.SetHelpNavigator(this.xtraTabPage6, System.Windows.Forms.HelpNavigator.KeywordIndex);
			this.helpProvider_NutritionInfo.SetHelpString(this.xtraTabPage6, "");
			this.helpProvider_NutritionInfo.SetShowHelp(this.xtraTabPage6, true);

			this.helpProvider_NutritionInfo.SetHelpKeyword(this.xtraTabPage7,"晨检及全日观察");
			this.helpProvider_NutritionInfo.SetHelpNavigator(this.xtraTabPage7, System.Windows.Forms.HelpNavigator.KeywordIndex);
			this.helpProvider_NutritionInfo.SetHelpString(this.xtraTabPage7, "");
			this.helpProvider_NutritionInfo.SetShowHelp(this.xtraTabPage7, true);

			this.helpProvider_NutritionInfo.SetHelpKeyword(this.xtraTabPage8,"服药登记");
			this.helpProvider_NutritionInfo.SetHelpNavigator(this.xtraTabPage8, System.Windows.Forms.HelpNavigator.KeywordIndex);
			this.helpProvider_NutritionInfo.SetHelpString(this.xtraTabPage8, "");
			this.helpProvider_NutritionInfo.SetShowHelp(this.xtraTabPage8, true);

			this.helpProvider_NutritionInfo.SetHelpKeyword(this.xtraTabPage9,"服药记录");
			this.helpProvider_NutritionInfo.SetHelpNavigator(this.xtraTabPage9, System.Windows.Forms.HelpNavigator.KeywordIndex);
			this.helpProvider_NutritionInfo.SetHelpString(this.xtraTabPage9, "");
			this.helpProvider_NutritionInfo.SetShowHelp(this.xtraTabPage9, true);

			#endregion	
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NutritionManagement));
			this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
			this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
			this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
			this.groupControl_FoodCategory = new DevExpress.XtraEditors.GroupControl();
			this.treeList_FoodStock = new DevExpress.XtraTreeList.TreeList();
			this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.groupControl_FoodNutModify = new DevExpress.XtraEditors.GroupControl();
			this.textEdit_FoodName = new DevExpress.XtraEditors.TextEdit();
			this.notePanel7 = new DevExpress.Utils.Frames.NotePanel();
			this.memoEdit_FoodRemark = new DevExpress.XtraEditors.MemoEdit();
			this.notePanel_FoodRemark = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_Energy = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_Carbohydrate = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_Fat = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_Protein = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_Energy = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_Carbohydrate = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_Fat = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_Protein = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_FoodCategory = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_FoodCategory = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_FoodName = new DevExpress.Utils.Frames.NotePanel();
			this.groupControl_FoodNutrition = new DevExpress.XtraEditors.GroupControl();
			this.gridControl_FoodNutrition = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.simpleButton_FoodModify = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_FoodBack = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_FoodDelete = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_FoodSave = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_FoodAdd = new DevExpress.XtraEditors.SimpleButton();
			this.textEdit_FoodSearch = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_BindingID = new DevExpress.XtraEditors.TextEdit();
			this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
			this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
			this.panelControl10 = new DevExpress.XtraEditors.PanelControl();
			this.gridControl_Recipe_FoodNutrition = new DevExpress.XtraGrid.GridControl();
			this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.notePanel4 = new DevExpress.Utils.Frames.NotePanel();
			this.groupControl_RecipeLogin = new DevExpress.XtraEditors.GroupControl();
			this.textEdit_RecipeLogin_FoodName = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_RecipeLogin_Name = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_RecipeLogin_Name = new DevExpress.Utils.Frames.NotePanel();
			this.dateEdit_RecipeLogin_Date = new DevExpress.XtraEditors.DateEdit();
			this.notePanel_RecipeLogin_Date = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_RecipeLogin_FoodTake = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_RecipeLogin_FoodTake = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_RecipeLogin_BindingID = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_RecipeLogin_FoodName = new DevExpress.Utils.Frames.NotePanel();
			this.groupControl_RecipeSer = new DevExpress.XtraEditors.GroupControl();
			this.comboBoxEdit_RecipeSer_FoodCategory = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_RecipeSer_FoodCategory = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_RecipeSer_FoodName = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_RecipeSer_FoodName = new DevExpress.Utils.Frames.NotePanel();
			this.groupControl_RecipeOpr = new DevExpress.XtraEditors.GroupControl();
			this.simpleButton_RecipeModify = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_RecipeSave = new DevExpress.XtraEditors.SimpleButton();
			this.panelControl11 = new DevExpress.XtraEditors.PanelControl();
			this.gridControl_RecipeLogin = new DevExpress.XtraGrid.GridControl();
			this.gridView13 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn50 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn51 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn52 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn53 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.notePanel5 = new DevExpress.Utils.Frames.NotePanel();
			this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
			this.textEdit_Recipe_FoodName = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_Recipe_FoodName = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_Recipe = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_Recipe_RecipeCategory = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_Recipe_RecipeCategory = new DevExpress.Utils.Frames.NotePanel();
			this.dateEdit_Recipe_EndDate = new DevExpress.XtraEditors.DateEdit();
			this.notePanel_Recipe_EndDate = new DevExpress.Utils.Frames.NotePanel();
			this.dateEdit_Recipe_BegDate = new DevExpress.XtraEditors.DateEdit();
			this.notePanel_Recipe_BegDate = new DevExpress.Utils.Frames.NotePanel();
			this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
			this.splitContainerControl3 = new DevExpress.XtraEditors.SplitContainerControl();
			this.groupControl_MealLogin = new DevExpress.XtraEditors.GroupControl();
			this.notePanel_MealArr = new DevExpress.Utils.Frames.NotePanel();
			this.checkEdit_Snack = new DevExpress.XtraEditors.CheckEdit();
			this.checkEdit_Dinner = new DevExpress.XtraEditors.CheckEdit();
			this.checkEdit_Lunch = new DevExpress.XtraEditors.CheckEdit();
			this.checkEdit_Breakfast = new DevExpress.XtraEditors.CheckEdit();
			this.groupControl_MealAdd = new DevExpress.XtraEditors.GroupControl();
			this.textEdit_MealName = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_MealRemark = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_MealRemark = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_MealID = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_MealName = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_MealNameAdd = new DevExpress.Utils.Frames.NotePanel();
			this.groupControl_MealArr = new DevExpress.XtraEditors.GroupControl();
			this.splitContainerControl4 = new DevExpress.XtraEditors.SplitContainerControl();
			this.notePanel_GradeArr = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_MealArr_Grade = new DevExpress.Utils.Frames.NotePanel();
			this.checkEdit_MealArr_gThree = new DevExpress.XtraEditors.CheckEdit();
			this.notePanel_MealArr_Name = new DevExpress.Utils.Frames.NotePanel();
			this.checkEdit_MealArr_gTwo = new DevExpress.XtraEditors.CheckEdit();
			this.checkEdit_MealArr_gOne = new DevExpress.XtraEditors.CheckEdit();
			this.comboBoxEdit_MealArr_Name = new DevExpress.XtraEditors.ComboBoxEdit();
			this.checkEdit_MealArr_gFour = new DevExpress.XtraEditors.CheckEdit();
			this.checkEdit_MealArr_gFive = new DevExpress.XtraEditors.CheckEdit();
			this.checkEdit_MealArr_IsUsed = new DevExpress.XtraEditors.CheckEdit();
			this.label_Lunch = new System.Windows.Forms.Label();
			this.label_Snack = new System.Windows.Forms.Label();
			this.label_Super = new System.Windows.Forms.Label();
			this.label_Breakfast = new System.Windows.Forms.Label();
			this.notePanel_MealArr_ePreview = new DevExpress.Utils.Frames.NotePanel();
			this.groupControl_MealPreview = new DevExpress.XtraEditors.GroupControl();
			this.gridControl_MealPreview = new DevExpress.XtraGrid.GridControl();
			this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.notePanel3 = new DevExpress.Utils.Frames.NotePanel();
			this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
			this.simpleButton_MealBack = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_MealAppend = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_MealDelete = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_MealSave = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_MealAdd = new DevExpress.XtraEditors.SimpleButton();
			this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
			this.splitContainerControl5 = new DevExpress.XtraEditors.SplitContainerControl();
			this.groupControl_Meal_Search = new DevExpress.XtraEditors.GroupControl();
			this.dateEdit_Meal_EndDate = new DevExpress.XtraEditors.DateEdit();
			this.notePanel_Meal_EndDate = new DevExpress.Utils.Frames.NotePanel();
			this.dateEdit_Meal_BegDate = new DevExpress.XtraEditors.DateEdit();
			this.notePanel_Meal_BegDate = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_Meal_Search = new DevExpress.Utils.Frames.NotePanel();
			this.groupControl_Meal_ReportPreview = new DevExpress.XtraEditors.GroupControl();
			this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
			this.simpleButton_Meal_PrintReport = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_Meal_PreviewReport = new DevExpress.XtraEditors.SimpleButton();
			this.xtraTabPage5 = new DevExpress.XtraTab.XtraTabPage();
			this.splitContainerControl6 = new DevExpress.XtraEditors.SplitContainerControl();
			this.gridControl_HInputStu = new DevExpress.XtraGrid.GridControl();
			this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.groupControl_HInputSer = new DevExpress.XtraEditors.GroupControl();
			this.comboBoxEdit_HInputGender = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_HInputGender = new DevExpress.Utils.Frames.NotePanel();
			this.dataNavigator_HInputNav = new DevExpress.XtraEditors.DataNavigator();
			this.textEdit_HInputNumber = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_HInputName = new DevExpress.XtraEditors.TextEdit();
			this.comboBoxEdit_HInputClass = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_HInputClass = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_HInputGrade = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_HInputGrade = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_HInputSer = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_HInputNumber = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_HInputName = new DevExpress.Utils.Frames.NotePanel();
			this.groupControl_HInputDiagInfo = new DevExpress.XtraEditors.GroupControl();
			this.comboBoxEdit_HInputRegion = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel6 = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_HInputStd = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_HInputStd = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_DiagCheckName = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_DiagCheckBindingID = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_DiagCheckName = new DevExpress.Utils.Frames.NotePanel();
			this.groupControl_HInputDiagResult = new DevExpress.XtraEditors.GroupControl();
			this.textEdit_DiagResultX = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_DiagResultWHOPer = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_DiagResultHeightWeight = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_DiagResultUnderWeight = new DevExpress.XtraEditors.TextEdit();
			this.notePanel8 = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel9 = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel10 = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_DiagResultStunting = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_DiagResultWasting = new DevExpress.XtraEditors.TextEdit();
			this.notePanel1 = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_DiagResultHeight = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_DiagResultWeight = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_DiagResultWeight = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_DiagResultNut = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_DiagResultWHO = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_DiagResultHeight = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_DiagResultAge = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_DiagResultWHO = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_DiagResultNut = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_DiagResultAge = new DevExpress.XtraEditors.TextEdit();
			this.memoEdit_DiagRemark = new DevExpress.XtraEditors.MemoEdit();
			this.notePanel_DiagRemark = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_DiagWeight = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_DiagHeight = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_HInputDaigInfo = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_DiagWeight = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_DiagHeight = new DevExpress.Utils.Frames.NotePanel();
			this.dateEdit_DiagCheckDate = new DevExpress.XtraEditors.DateEdit();
			this.notePanel_DiagCheckDate = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_HInputBirthday = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_HInputBirthday = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_DiagCheckGender = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_DiagCheckGender = new DevExpress.XtraEditors.TextEdit();
			this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
			this.simpleButton_HInputModify = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_HInputDelete = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_HInputSave = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_HInputDiag = new DevExpress.XtraEditors.SimpleButton();
			this.xtraTabPage6 = new DevExpress.XtraTab.XtraTabPage();
			this.splitContainerControl7 = new DevExpress.XtraEditors.SplitContainerControl();
			this.groupControl_HOutputPrintType = new DevExpress.XtraEditors.GroupControl();
			this.checkEdit_HOutputPrintType4th = new DevExpress.XtraEditors.CheckEdit();
			this.checkEdit_HOutputPrintType3rd = new DevExpress.XtraEditors.CheckEdit();
			this.checkEdit_HOutputPrintType2nd = new DevExpress.XtraEditors.CheckEdit();
			this.checkEdit_HOutputPrintType1st = new DevExpress.XtraEditors.CheckEdit();
			this.groupControl_HOutputSer = new DevExpress.XtraEditors.GroupControl();
			this.comboBoxEdit_HOutputRegion = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel11 = new DevExpress.Utils.Frames.NotePanel();
			this.dateEdit_HOutputEndDate = new DevExpress.XtraEditors.DateEdit();
			this.dateEdit_HOutputBegDate = new DevExpress.XtraEditors.DateEdit();
			this.notePanel_HOutputEndDate = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_HOutputBegDate = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_HOutputGender = new DevExpress.XtraEditors.ComboBoxEdit();
			this.comboBoxEdit_HOutputResult = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_HOutputResult = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_HOutputType = new DevExpress.XtraEditors.ComboBoxEdit();
			this.comboBoxEdit_HOutputAge = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_HOutputType = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_HOutputAge = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_HOutputNumber = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_HOutputName = new DevExpress.XtraEditors.TextEdit();
			this.comboBoxEdit_HOutputClass = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_HOutputClass = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_HOutputGrade = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_HOutputGrade = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_HOutputNumber = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_HOutputName = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_HOutputGender = new DevExpress.Utils.Frames.NotePanel();
			this.gridControl_HOutputNchsGrid = new DevExpress.XtraGrid.GridControl();
			this.advBandedGridView2 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
			this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
			this.bandedGridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.bandedGridColumn16 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
			this.bandedGridColumn19 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.bandedGridColumn17 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.bandedGridColumn23 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.bandedGridColumn18 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
			this.bandedGridColumn20 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.bandedGridColumn21 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.bandedGridColumn22 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.bandedGridColumn26 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.bandedGridColumn29 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.bandedGridColumn30 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.bandedGridColumn24 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.bandedGridColumn25 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.bandedGridColumn27 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.bandedGridColumn28 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.gridControl_HOutputGridShow = new DevExpress.XtraGrid.GridControl();
			this.advBandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
			this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
			this.bandedGridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
			this.bandedGridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.bandedGridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.bandedGridColumn6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.bandedGridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
			this.bandedGridColumn7 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.bandedGridColumn8 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.bandedGridColumn10 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.bandedGridColumn12 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.bandedGridColumn15 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.bandedGridColumn9 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.bandedGridColumn11 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.bandedGridColumn13 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
			this.bandedGridColumn14 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
			this.simpleButton_HOutputSearch = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_HOutputPrint = new DevExpress.XtraEditors.SimpleButton();
			this.xtraTabPage7 = new DevExpress.XtraTab.XtraTabPage();
			this.splitContainerControl8 = new DevExpress.XtraEditors.SplitContainerControl();
			this.groupControl_WatchMorningRec = new DevExpress.XtraEditors.GroupControl();
			this.textEdit_WatchMorningTreat = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_WatchMorningTreat = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_WatchMorningOState = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_WatchMorningOState = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_WatchMorningMouth = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_WatchMorningHeat = new DevExpress.XtraEditors.ComboBoxEdit();
			this.comboBoxEdit_WatchMorningMouth = new DevExpress.XtraEditors.ComboBoxEdit();
			this.comboBoxEdit_WatchMorningSpirit = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_WatchMorningHeat = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_WatchMorningSkin = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_WatchMorningSkin = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_WatchMorningSpirit = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_WatchMorningNumber = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_WatchMorningName = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_WatchMorningNumber = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_WatchMorningName = new DevExpress.Utils.Frames.NotePanel();
			this.groupControl_WatchStuList = new DevExpress.XtraEditors.GroupControl();
			this.gridControl_WatchStuList = new DevExpress.XtraGrid.GridControl();
			this.gridView7 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.notePanel_WatchStuList = new DevExpress.Utils.Frames.NotePanel();
			this.groupControl_WatchSer = new DevExpress.XtraEditors.GroupControl();
			this.textEdit_WatchName = new DevExpress.XtraEditors.TextEdit();
			this.dateEdit_WatchEndDate = new DevExpress.XtraEditors.DateEdit();
			this.dateEdit_WatchBegDate = new DevExpress.XtraEditors.DateEdit();
			this.notePanel_WatchEndDate = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_WatchBegDate = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_WatchState = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_WatchState = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_WatchNumber = new DevExpress.XtraEditors.TextEdit();
			this.comboBoxEdit_WatchClass = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_WatchClass = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_WatchGrade = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_WatchGrade = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_WatchNumber = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_WatchName = new DevExpress.Utils.Frames.NotePanel();
			this.groupControl_WatchWholeDay = new DevExpress.XtraEditors.GroupControl();
			this.groupControl_WatchWholDayHandle = new DevExpress.XtraEditors.GroupControl();
			this.checkEdit_WatchWholeDayHeat = new DevExpress.XtraEditors.CheckEdit();
			this.checkEdit_WatchWholeDayCtrSeafood = new DevExpress.XtraEditors.CheckEdit();
			this.checkEdit_WatchWholeDayLifeAttention = new DevExpress.XtraEditors.CheckEdit();
			this.checkEdit_WatchWholeDayCtrAct = new DevExpress.XtraEditors.CheckEdit();
			this.groupControl_WatchWholeDayReg = new DevExpress.XtraEditors.GroupControl();
			this.textEdit_WatchWholeDayElse = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_WatchWholeDayElse = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_WatchWholeDayCough = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_WatchWholeDayCough = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_WatchWholeDaySleep = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_WatchWholeDaySleep = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_WatchWholeDayStool = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_WatchWholeDayStool = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_WatchWholeDayAppetite = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_WatchWholeDayAppetite = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_WatchWholeDaySpirit = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_WatchWholeDaySpirit = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_WatchWholeDayMovement = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_WatchWholeDayMovement = new DevExpress.Utils.Frames.NotePanel();
			this.groupControl_WatchRecList = new DevExpress.XtraEditors.GroupControl();
			this.gridControl_WatchRecList = new DevExpress.XtraGrid.GridControl();
			this.gridView8 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn34 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.notePanel_WatchRecList = new DevExpress.Utils.Frames.NotePanel();
			this.panelControl7 = new DevExpress.XtraEditors.PanelControl();
			this.simpleButton_WatchSearch = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_WatchBack = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_WatchDelete = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_WatchReport = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_WatchHandle = new DevExpress.XtraEditors.SimpleButton();
			this.xtraTabPage8 = new DevExpress.XtraTab.XtraTabPage();
			this.splitContainerControl9 = new DevExpress.XtraEditors.SplitContainerControl();
			this.groupControl_MedReg_StuList = new DevExpress.XtraEditors.GroupControl();
			this.gridControl_MedReg_StuList = new DevExpress.XtraGrid.GridControl();
			this.gridView9 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn38 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.notePanel2 = new DevExpress.Utils.Frames.NotePanel();
			this.groupControl_MedReg_Ser = new DevExpress.XtraEditors.GroupControl();
			this.notePanel_MedReg_Ser = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_MedReg_Number = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_MedReg_Name = new DevExpress.XtraEditors.TextEdit();
			this.comboBoxEdit_MedReg_Class = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_MedReg_Class = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_MedReg_Grade = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_MedReg_Grade = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_MedReg_Number = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_MedReg_Name = new DevExpress.Utils.Frames.NotePanel();
			this.groupControl_MedReg_MedInfo = new DevExpress.XtraEditors.GroupControl();
			this.textEdit_MedReg_MedName = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_MedReg_Taketimes = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_MedReg_MedTake = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_MedReg_MedType = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_MedReg_Taketimes = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_MedReg_MedTake = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_MedReg_MedType = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_MedReg_MedName = new DevExpress.Utils.Frames.NotePanel();
			this.groupControl_MedReg_MedCarrInfo = new DevExpress.XtraEditors.GroupControl();
			this.listBoxControl_MedReg_MedCarrInfo = new DevExpress.XtraEditors.ListBoxControl();
			this.simpleButton_MedReg_MedCarrDel = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_MedReg_MedCarrAdd = new DevExpress.XtraEditors.SimpleButton();
			this.listBoxControl_MedReg_MedInfo = new DevExpress.XtraEditors.ListBoxControl();
			this.groupControl_MedReg_DiagInfo = new DevExpress.XtraEditors.GroupControl();
			this.textEdit_MedReg_Else = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_MedReg_FacialSym = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_MedReg_Else = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_MedReg_FacialSym = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_MedReg_SkinSym = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_MedReg_AbdomenSym = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_MedReg_EnteronSym = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_MedReg_SkinSym = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_MedReg_AbdomenSym = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_MedReg_EnteronSym = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_MedReg_ThroatSym = new DevExpress.XtraEditors.TextEdit();
			this.notePanel__MedReg_ThroatSym = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_MedReg_LungSym = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_MedReg_LungSym = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_MedReg_UpperSym = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_MedReg_UpperSym = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_MedReg_Diag = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_MedReg_Diag = new DevExpress.Utils.Frames.NotePanel();
			this.panelControl8 = new DevExpress.XtraEditors.PanelControl();
			this.simpleButton_MedReg_Ser = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_MedReg_Modify = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_MedReg_Reg = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_MedReg_Save = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_MedReg_Back = new DevExpress.XtraEditors.SimpleButton();
			this.xtraTabPage9 = new DevExpress.XtraTab.XtraTabPage();
			this.splitContainerControl10 = new DevExpress.XtraEditors.SplitContainerControl();
			this.groupControl_MedRec_AbnStuList = new DevExpress.XtraEditors.GroupControl();
			this.gridControl_MedRec_AbnStuList = new DevExpress.XtraGrid.GridControl();
			this.gridView10 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn39 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn40 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn41 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn42 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn43 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.notePanel_MedRec_AbnStuList = new DevExpress.Utils.Frames.NotePanel();
			this.groupControl_MedRec_Ser = new DevExpress.XtraEditors.GroupControl();
			this.textEdit_MedRec_Number = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_MedRec_Name = new DevExpress.XtraEditors.TextEdit();
			this.dateEdit_MedRec_EndDate = new DevExpress.XtraEditors.DateEdit();
			this.notePanel_MedRec_EndDate = new DevExpress.Utils.Frames.NotePanel();
			this.dateEdit_MedRec_BegDate = new DevExpress.XtraEditors.DateEdit();
			this.notePanel_MedRec_BegDate = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_MedRec_Ser = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_MedRec_DoseRecDiaID = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_MedRec_AbnDiaID = new DevExpress.XtraEditors.TextEdit();
			this.comboBoxEdit_MedRec_Class = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_MedRec_Class = new DevExpress.Utils.Frames.NotePanel();
			this.comboBoxEdit_MedRec_Grade = new DevExpress.XtraEditors.ComboBoxEdit();
			this.notePanel_MedRec_Grade = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_MedRec_Number = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_MedRec_Name = new DevExpress.Utils.Frames.NotePanel();
			this.groupControl_MedRec_DiagAndDoseAdd = new DevExpress.XtraEditors.GroupControl();
			this.groupControl_MedRec_DoseAdd = new DevExpress.XtraEditors.GroupControl();
			this.notePanel_MedRec_TakeRule = new DevExpress.Utils.Frames.NotePanel();
			this.listBoxControl_MedRec_MedCarrInfo = new DevExpress.XtraEditors.ListBoxControl();
			this.comboBoxEdit_MedRec_TakeRule = new DevExpress.XtraEditors.ComboBoxEdit();
			this.timeEdit_MedRec_TakeTime = new DevExpress.XtraEditors.TimeEdit();
			this.notePanel_MedRec_TakeDate = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_MedRec_MedTake = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_MedRec_MedTake = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_MedRec_MedName = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_MedRec_MedName = new DevExpress.Utils.Frames.NotePanel();
			this.groupControl_MedRec_DiagInfo = new DevExpress.XtraEditors.GroupControl();
			this.textEdit_MedRec_Diag = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_MedRec_Else = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_MedRec_FacialSym = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_MedRec_Else = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_MedRec_FacialSym = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_MedRec_SkinSym = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_MedRec_AbdomenSym = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_MedRec_EnteronSym = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_MedRec_SkinSym = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_MedRec_AbdomenSym = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_MedRec_EnteronSym = new DevExpress.XtraEditors.TextEdit();
			this.textEdit_MedRec_ThroatSym = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_MedRec_ThroatSym = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_MedRec_LungSym = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_MedRec_LungSym = new DevExpress.Utils.Frames.NotePanel();
			this.textEdit_MedRec_UpperSym = new DevExpress.XtraEditors.TextEdit();
			this.notePanel_MedRec_UpperSym = new DevExpress.Utils.Frames.NotePanel();
			this.notePanel_MedRec_Diag = new DevExpress.Utils.Frames.NotePanel();
			this.groupControl_MedRec_DoseRec = new DevExpress.XtraEditors.GroupControl();
			this.gridControl_MedRec_DoseRec = new DevExpress.XtraGrid.GridControl();
			this.gridView11 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn49 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn48 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn44 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn45 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn46 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn47 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridView12 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.notePanel_MedRec_DoseRec = new DevExpress.Utils.Frames.NotePanel();
			this.panelControl9 = new DevExpress.XtraEditors.PanelControl();
			this.simpleButton_AbnormalSer = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_MedRec_Report = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_MedRec_Add = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_MedRec_Back = new DevExpress.XtraEditors.SimpleButton();
			this.barManager1 = new DevExpress.XtraBars.BarManager();
			this.popupMenu4 = new DevExpress.XtraBars.PopupMenu();
			this.barButtonItem_RecipeRefresh = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem_RecipeDelete = new DevExpress.XtraBars.BarButtonItem();
			this.popupMenu1 = new DevExpress.XtraBars.PopupMenu();
			this.barButtonItem_MealRefresh = new DevExpress.XtraBars.BarButtonItem();
			this.popupMenu2 = new DevExpress.XtraBars.PopupMenu();
			this.barButtonItem_MedReg_MedAdd = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem_MedReg_MedModify = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem_MedReg_MedDel = new DevExpress.XtraBars.BarButtonItem();
			this.popupMenu3 = new DevExpress.XtraBars.PopupMenu();
			this.barButtonItem_MedRec_MultiSer = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem_MedRec_MedDel = new DevExpress.XtraBars.BarButtonItem();
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			this.gridView14 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.saveFileDialog_Report = new System.Windows.Forms.SaveFileDialog();
			this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.helpProvider_NutritionInfo = new System.Windows.Forms.HelpProvider();
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
			this.xtraTabControl1.SuspendLayout();
			this.xtraTabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
			this.splitContainerControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_FoodCategory)).BeginInit();
			this.groupControl_FoodCategory.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.treeList_FoodStock)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_FoodNutModify)).BeginInit();
			this.groupControl_FoodNutModify.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_FoodName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit_FoodRemark.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_Energy.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_Carbohydrate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_Fat.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_Protein.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_FoodCategory.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_FoodNutrition)).BeginInit();
			this.groupControl_FoodNutrition.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_FoodNutrition)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_FoodSearch.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_BindingID.Properties)).BeginInit();
			this.xtraTabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
			this.splitContainerControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.panelControl10)).BeginInit();
			this.panelControl10.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_Recipe_FoodNutrition)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_RecipeLogin)).BeginInit();
			this.groupControl_RecipeLogin.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_RecipeLogin_FoodName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_RecipeLogin_Name.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_RecipeLogin_Date.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_RecipeLogin_FoodTake.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_RecipeLogin_BindingID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_RecipeSer)).BeginInit();
			this.groupControl_RecipeSer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_RecipeSer_FoodCategory.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_RecipeSer_FoodName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_RecipeOpr)).BeginInit();
			this.groupControl_RecipeOpr.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.panelControl11)).BeginInit();
			this.panelControl11.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_RecipeLogin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView13)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
			this.panelControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_Recipe_FoodName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Recipe_RecipeCategory.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_Recipe_EndDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_Recipe_BegDate.Properties)).BeginInit();
			this.xtraTabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).BeginInit();
			this.splitContainerControl3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MealLogin)).BeginInit();
			this.groupControl_MealLogin.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_Snack.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_Dinner.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_Lunch.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_Breakfast.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MealAdd)).BeginInit();
			this.groupControl_MealAdd.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MealName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MealRemark.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MealID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MealArr)).BeginInit();
			this.groupControl_MealArr.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl4)).BeginInit();
			this.splitContainerControl4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_MealArr_gThree.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_MealArr_gTwo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_MealArr_gOne.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_MealArr_Name.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_MealArr_gFour.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_MealArr_gFive.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_MealArr_IsUsed.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MealPreview)).BeginInit();
			this.groupControl_MealPreview.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_MealPreview)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
			this.panelControl3.SuspendLayout();
			this.xtraTabPage4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl5)).BeginInit();
			this.splitContainerControl5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_Meal_Search)).BeginInit();
			this.groupControl_Meal_Search.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_Meal_EndDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_Meal_BegDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_Meal_ReportPreview)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
			this.panelControl4.SuspendLayout();
			this.xtraTabPage5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl6)).BeginInit();
			this.splitContainerControl6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_HInputStu)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_HInputSer)).BeginInit();
			this.groupControl_HInputSer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_HInputGender.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_HInputNumber.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_HInputName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_HInputClass.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_HInputGrade.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_HInputDiagInfo)).BeginInit();
			this.groupControl_HInputDiagInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_HInputRegion.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_HInputStd.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_DiagCheckName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_DiagCheckBindingID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_HInputDiagResult)).BeginInit();
			this.groupControl_HInputDiagResult.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_DiagResultX.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_DiagResultWHOPer.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_DiagResultHeightWeight.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_DiagResultUnderWeight.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_DiagResultStunting.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_DiagResultWasting.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_DiagResultHeight.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_DiagResultWeight.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_DiagResultWHO.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_DiagResultNut.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_DiagResultAge.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit_DiagRemark.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_DiagWeight.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_DiagHeight.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_DiagCheckDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_HInputBirthday.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_DiagCheckGender.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
			this.panelControl5.SuspendLayout();
			this.xtraTabPage6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl7)).BeginInit();
			this.splitContainerControl7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_HOutputPrintType)).BeginInit();
			this.groupControl_HOutputPrintType.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_HOutputPrintType4th.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_HOutputPrintType3rd.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_HOutputPrintType2nd.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_HOutputPrintType1st.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_HOutputSer)).BeginInit();
			this.groupControl_HOutputSer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_HOutputRegion.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_HOutputEndDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_HOutputBegDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_HOutputGender.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_HOutputResult.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_HOutputType.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_HOutputAge.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_HOutputNumber.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_HOutputName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_HOutputClass.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_HOutputGrade.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_HOutputNchsGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.advBandedGridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_HOutputGridShow)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
			this.panelControl6.SuspendLayout();
			this.xtraTabPage7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl8)).BeginInit();
			this.splitContainerControl8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_WatchMorningRec)).BeginInit();
			this.groupControl_WatchMorningRec.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_WatchMorningTreat.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_WatchMorningOState.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_WatchMorningHeat.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_WatchMorningMouth.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_WatchMorningSpirit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_WatchMorningSkin.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_WatchMorningNumber.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_WatchMorningName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_WatchStuList)).BeginInit();
			this.groupControl_WatchStuList.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_WatchStuList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_WatchSer)).BeginInit();
			this.groupControl_WatchSer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_WatchName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_WatchEndDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_WatchBegDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_WatchState.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_WatchNumber.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_WatchClass.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_WatchGrade.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_WatchWholeDay)).BeginInit();
			this.groupControl_WatchWholeDay.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_WatchWholDayHandle)).BeginInit();
			this.groupControl_WatchWholDayHandle.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_WatchWholeDayHeat.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_WatchWholeDayCtrSeafood.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_WatchWholeDayLifeAttention.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_WatchWholeDayCtrAct.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_WatchWholeDayReg)).BeginInit();
			this.groupControl_WatchWholeDayReg.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_WatchWholeDayElse.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_WatchWholeDayCough.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_WatchWholeDaySleep.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_WatchWholeDayStool.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_WatchWholeDayAppetite.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_WatchWholeDaySpirit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_WatchWholeDayMovement.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_WatchRecList)).BeginInit();
			this.groupControl_WatchRecList.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_WatchRecList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView8)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl7)).BeginInit();
			this.panelControl7.SuspendLayout();
			this.xtraTabPage8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl9)).BeginInit();
			this.splitContainerControl9.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MedReg_StuList)).BeginInit();
			this.groupControl_MedReg_StuList.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_MedReg_StuList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView9)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MedReg_Ser)).BeginInit();
			this.groupControl_MedReg_Ser.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedReg_Number.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedReg_Name.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_MedReg_Class.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_MedReg_Grade.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MedReg_MedInfo)).BeginInit();
			this.groupControl_MedReg_MedInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedReg_MedName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedReg_Taketimes.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedReg_MedTake.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedReg_MedType.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MedReg_MedCarrInfo)).BeginInit();
			this.groupControl_MedReg_MedCarrInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.listBoxControl_MedReg_MedCarrInfo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.listBoxControl_MedReg_MedInfo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MedReg_DiagInfo)).BeginInit();
			this.groupControl_MedReg_DiagInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedReg_Else.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedReg_FacialSym.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedReg_SkinSym.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedReg_AbdomenSym.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedReg_EnteronSym.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedReg_ThroatSym.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedReg_LungSym.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedReg_UpperSym.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_MedReg_Diag.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl8)).BeginInit();
			this.panelControl8.SuspendLayout();
			this.xtraTabPage9.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl10)).BeginInit();
			this.splitContainerControl10.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MedRec_AbnStuList)).BeginInit();
			this.groupControl_MedRec_AbnStuList.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_MedRec_AbnStuList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView10)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MedRec_Ser)).BeginInit();
			this.groupControl_MedRec_Ser.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedRec_Number.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedRec_Name.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_MedRec_EndDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_MedRec_BegDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedRec_DoseRecDiaID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedRec_AbnDiaID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_MedRec_Class.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_MedRec_Grade.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MedRec_DiagAndDoseAdd)).BeginInit();
			this.groupControl_MedRec_DiagAndDoseAdd.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MedRec_DoseAdd)).BeginInit();
			this.groupControl_MedRec_DoseAdd.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.listBoxControl_MedRec_MedCarrInfo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_MedRec_TakeRule.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.timeEdit_MedRec_TakeTime.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedRec_MedTake.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedRec_MedName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MedRec_DiagInfo)).BeginInit();
			this.groupControl_MedRec_DiagInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedRec_Diag.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedRec_Else.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedRec_FacialSym.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedRec_SkinSym.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedRec_AbdomenSym.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedRec_EnteronSym.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedRec_ThroatSym.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedRec_LungSym.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedRec_UpperSym.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MedRec_DoseRec)).BeginInit();
			this.groupControl_MedRec_DoseRec.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_MedRec_DoseRec)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView11)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView12)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl9)).BeginInit();
			this.panelControl9.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView14)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
			this.SuspendLayout();
			// 
			// xtraTabControl1
			// 
			this.xtraTabControl1.AppearancePage.HeaderActive.ForeColor = System.Drawing.Color.DarkOrange;
			this.xtraTabControl1.AppearancePage.HeaderActive.Options.UseForeColor = true;
			this.xtraTabControl1.Controls.Add(this.xtraTabPage1);
			this.xtraTabControl1.Controls.Add(this.xtraTabPage2);
			this.xtraTabControl1.Controls.Add(this.xtraTabPage3);
			this.xtraTabControl1.Controls.Add(this.xtraTabPage4);
			this.xtraTabControl1.Controls.Add(this.xtraTabPage5);
			this.xtraTabControl1.Controls.Add(this.xtraTabPage6);
			this.xtraTabControl1.Controls.Add(this.xtraTabPage7);
			this.xtraTabControl1.Controls.Add(this.xtraTabPage8);
			this.xtraTabControl1.Controls.Add(this.xtraTabPage9);
			this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
			this.xtraTabControl1.Name = "xtraTabControl1";
			this.xtraTabControl1.SelectedTabPage = this.xtraTabPage9;
			this.xtraTabControl1.Size = new System.Drawing.Size(772, 540);
			this.xtraTabControl1.TabIndex = 0;
			this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
																							this.xtraTabPage1,
																							this.xtraTabPage2,
																							this.xtraTabPage3,
																							this.xtraTabPage4,
																							this.xtraTabPage5,
																							this.xtraTabPage6,
																							this.xtraTabPage7,
																							this.xtraTabPage8,
																							this.xtraTabPage9});
			this.xtraTabControl1.Text = "xtraTabControl1";
			// 
			// xtraTabPage1
			// 
			this.xtraTabPage1.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
			this.xtraTabPage1.Appearance.PageClient.Options.UseBackColor = true;
			this.xtraTabPage1.Controls.Add(this.splitContainerControl1);
			this.xtraTabPage1.Name = "xtraTabPage1";
			this.xtraTabPage1.PageVisible = false;
			this.xtraTabPage1.Size = new System.Drawing.Size(768, 515);
			this.xtraTabPage1.Text = "食物库存管理";
			// 
			// splitContainerControl1
			// 
			this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
			this.splitContainerControl1.Name = "splitContainerControl1";
			this.splitContainerControl1.Panel1.Controls.Add(this.groupControl_FoodCategory);
			this.splitContainerControl1.Panel1.Text = "splitContainerControl1_Panel1";
			this.splitContainerControl1.Panel2.Controls.Add(this.groupControl_FoodNutModify);
			this.splitContainerControl1.Panel2.Controls.Add(this.groupControl_FoodNutrition);
			this.splitContainerControl1.Panel2.Controls.Add(this.panelControl1);
			this.splitContainerControl1.Panel2.Text = "splitContainerControl1_Panel2";
			this.splitContainerControl1.Size = new System.Drawing.Size(768, 515);
			this.splitContainerControl1.SplitterPosition = 175;
			this.splitContainerControl1.TabIndex = 0;
			this.splitContainerControl1.Text = "splitContainerControl1";
			// 
			// groupControl_FoodCategory
			// 
			this.groupControl_FoodCategory.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_FoodCategory.AppearanceCaption.Options.UseFont = true;
			this.groupControl_FoodCategory.Controls.Add(this.treeList_FoodStock);
			this.groupControl_FoodCategory.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_FoodCategory.Location = new System.Drawing.Point(0, 0);
			this.groupControl_FoodCategory.Name = "groupControl_FoodCategory";
			this.groupControl_FoodCategory.Size = new System.Drawing.Size(169, 272);
			this.groupControl_FoodCategory.TabIndex = 0;
			this.groupControl_FoodCategory.Text = "食物库存分类";
			// 
			// treeList_FoodStock
			// 
			this.treeList_FoodStock.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
																											  this.treeListColumn1});
			this.treeList_FoodStock.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeList_FoodStock.Location = new System.Drawing.Point(3, 18);
			this.treeList_FoodStock.Name = "treeList_FoodStock";
			this.treeList_FoodStock.Size = new System.Drawing.Size(163, 251);
			this.treeList_FoodStock.StateImageList = this.imageList1;
			this.treeList_FoodStock.TabIndex = 0;
			this.treeList_FoodStock.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList_FoodStock_FocusedNodeChanged);
			// 
			// treeListColumn1
			// 
			this.treeListColumn1.Caption = "食物库存";
			this.treeListColumn1.FieldName = "食物库存";
			this.treeListColumn1.Name = "treeListColumn1";
			this.treeListColumn1.OptionsColumn.AllowEdit = false;
			this.treeListColumn1.OptionsColumn.AllowMove = false;
			this.treeListColumn1.OptionsColumn.AllowMoveToCustomizationForm = false;
			this.treeListColumn1.OptionsColumn.AllowSize = false;
			this.treeListColumn1.VisibleIndex = 0;
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// groupControl_FoodNutModify
			// 
			this.groupControl_FoodNutModify.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_FoodNutModify.AppearanceCaption.Options.UseFont = true;
			this.groupControl_FoodNutModify.Controls.Add(this.textEdit_FoodName);
			this.groupControl_FoodNutModify.Controls.Add(this.notePanel7);
			this.groupControl_FoodNutModify.Controls.Add(this.memoEdit_FoodRemark);
			this.groupControl_FoodNutModify.Controls.Add(this.notePanel_FoodRemark);
			this.groupControl_FoodNutModify.Controls.Add(this.textEdit_Energy);
			this.groupControl_FoodNutModify.Controls.Add(this.textEdit_Carbohydrate);
			this.groupControl_FoodNutModify.Controls.Add(this.textEdit_Fat);
			this.groupControl_FoodNutModify.Controls.Add(this.textEdit_Protein);
			this.groupControl_FoodNutModify.Controls.Add(this.notePanel_Energy);
			this.groupControl_FoodNutModify.Controls.Add(this.notePanel_Carbohydrate);
			this.groupControl_FoodNutModify.Controls.Add(this.notePanel_Fat);
			this.groupControl_FoodNutModify.Controls.Add(this.notePanel_Protein);
			this.groupControl_FoodNutModify.Controls.Add(this.comboBoxEdit_FoodCategory);
			this.groupControl_FoodNutModify.Controls.Add(this.notePanel_FoodCategory);
			this.groupControl_FoodNutModify.Controls.Add(this.notePanel_FoodName);
			this.groupControl_FoodNutModify.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_FoodNutModify.Location = new System.Drawing.Point(0, 64);
			this.groupControl_FoodNutModify.Name = "groupControl_FoodNutModify";
			this.groupControl_FoodNutModify.Size = new System.Drawing.Size(583, 272);
			this.groupControl_FoodNutModify.TabIndex = 2;
			this.groupControl_FoodNutModify.Text = "成份修改与保存";
			// 
			// textEdit_FoodName
			// 
			this.textEdit_FoodName.EditValue = "";
			this.textEdit_FoodName.Location = new System.Drawing.Point(152, 64);
			this.textEdit_FoodName.Name = "textEdit_FoodName";
			this.textEdit_FoodName.Size = new System.Drawing.Size(96, 23);
			this.textEdit_FoodName.TabIndex = 45;
			// 
			// notePanel7
			// 
			this.notePanel7.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel7.ForeColor = System.Drawing.Color.Gray;
			this.notePanel7.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel7.Location = new System.Drawing.Point(3, 18);
			this.notePanel7.MaxRows = 5;
			this.notePanel7.Name = "notePanel7";
			this.notePanel7.ParentAutoHeight = true;
			this.notePanel7.Size = new System.Drawing.Size(577, 23);
			this.notePanel7.TabIndex = 44;
			this.notePanel7.TabStop = false;
			this.notePanel7.Text = "注: 食物营成份以(克/斤)计算";
			// 
			// memoEdit_FoodRemark
			// 
			this.memoEdit_FoodRemark.EditValue = "";
			this.memoEdit_FoodRemark.Location = new System.Drawing.Point(272, 96);
			this.memoEdit_FoodRemark.Name = "memoEdit_FoodRemark";
			this.memoEdit_FoodRemark.Size = new System.Drawing.Size(208, 152);
			this.memoEdit_FoodRemark.TabIndex = 43;
			// 
			// notePanel_FoodRemark
			// 
			this.notePanel_FoodRemark.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_FoodRemark.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_FoodRemark.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_FoodRemark.ForeColor = System.Drawing.Color.Black;
			this.notePanel_FoodRemark.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_FoodRemark.Location = new System.Drawing.Point(272, 64);
			this.notePanel_FoodRemark.MaxRows = 5;
			this.notePanel_FoodRemark.Name = "notePanel_FoodRemark";
			this.notePanel_FoodRemark.ParentAutoHeight = true;
			this.notePanel_FoodRemark.Size = new System.Drawing.Size(208, 22);
			this.notePanel_FoodRemark.TabIndex = 42;
			this.notePanel_FoodRemark.TabStop = false;
			this.notePanel_FoodRemark.Text = "                     备  注:";
			// 
			// textEdit_Energy
			// 
			this.textEdit_Energy.EditValue = "";
			this.textEdit_Energy.Location = new System.Drawing.Point(152, 224);
			this.textEdit_Energy.Name = "textEdit_Energy";
			this.textEdit_Energy.Size = new System.Drawing.Size(96, 23);
			this.textEdit_Energy.TabIndex = 40;
			// 
			// textEdit_Carbohydrate
			// 
			this.textEdit_Carbohydrate.EditValue = "";
			this.textEdit_Carbohydrate.Location = new System.Drawing.Point(152, 192);
			this.textEdit_Carbohydrate.Name = "textEdit_Carbohydrate";
			this.textEdit_Carbohydrate.Size = new System.Drawing.Size(96, 23);
			this.textEdit_Carbohydrate.TabIndex = 39;
			// 
			// textEdit_Fat
			// 
			this.textEdit_Fat.EditValue = "";
			this.textEdit_Fat.Location = new System.Drawing.Point(152, 160);
			this.textEdit_Fat.Name = "textEdit_Fat";
			this.textEdit_Fat.Size = new System.Drawing.Size(96, 23);
			this.textEdit_Fat.TabIndex = 38;
			// 
			// textEdit_Protein
			// 
			this.textEdit_Protein.EditValue = "";
			this.textEdit_Protein.Location = new System.Drawing.Point(152, 128);
			this.textEdit_Protein.Name = "textEdit_Protein";
			this.textEdit_Protein.Size = new System.Drawing.Size(96, 23);
			this.textEdit_Protein.TabIndex = 37;
			// 
			// notePanel_Energy
			// 
			this.notePanel_Energy.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_Energy.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_Energy.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_Energy.ForeColor = System.Drawing.Color.Black;
			this.notePanel_Energy.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Energy.Location = new System.Drawing.Point(40, 224);
			this.notePanel_Energy.MaxRows = 5;
			this.notePanel_Energy.Name = "notePanel_Energy";
			this.notePanel_Energy.ParentAutoHeight = true;
			this.notePanel_Energy.Size = new System.Drawing.Size(96, 22);
			this.notePanel_Energy.TabIndex = 36;
			this.notePanel_Energy.TabStop = false;
			this.notePanel_Energy.Text = "     热  量:";
			// 
			// notePanel_Carbohydrate
			// 
			this.notePanel_Carbohydrate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_Carbohydrate.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_Carbohydrate.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_Carbohydrate.ForeColor = System.Drawing.Color.Black;
			this.notePanel_Carbohydrate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Carbohydrate.Location = new System.Drawing.Point(40, 192);
			this.notePanel_Carbohydrate.MaxRows = 5;
			this.notePanel_Carbohydrate.Name = "notePanel_Carbohydrate";
			this.notePanel_Carbohydrate.ParentAutoHeight = true;
			this.notePanel_Carbohydrate.Size = new System.Drawing.Size(96, 22);
			this.notePanel_Carbohydrate.TabIndex = 35;
			this.notePanel_Carbohydrate.TabStop = false;
			this.notePanel_Carbohydrate.Text = "碳水化合物:";
			// 
			// notePanel_Fat
			// 
			this.notePanel_Fat.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_Fat.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_Fat.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_Fat.ForeColor = System.Drawing.Color.Black;
			this.notePanel_Fat.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Fat.Location = new System.Drawing.Point(40, 160);
			this.notePanel_Fat.MaxRows = 5;
			this.notePanel_Fat.Name = "notePanel_Fat";
			this.notePanel_Fat.ParentAutoHeight = true;
			this.notePanel_Fat.Size = new System.Drawing.Size(96, 22);
			this.notePanel_Fat.TabIndex = 34;
			this.notePanel_Fat.TabStop = false;
			this.notePanel_Fat.Text = "  脂肪含量:";
			// 
			// notePanel_Protein
			// 
			this.notePanel_Protein.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_Protein.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_Protein.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_Protein.ForeColor = System.Drawing.Color.Black;
			this.notePanel_Protein.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Protein.Location = new System.Drawing.Point(40, 128);
			this.notePanel_Protein.MaxRows = 5;
			this.notePanel_Protein.Name = "notePanel_Protein";
			this.notePanel_Protein.ParentAutoHeight = true;
			this.notePanel_Protein.Size = new System.Drawing.Size(96, 22);
			this.notePanel_Protein.TabIndex = 33;
			this.notePanel_Protein.TabStop = false;
			this.notePanel_Protein.Text = "蛋白质含量:";
			// 
			// comboBoxEdit_FoodCategory
			// 
			this.comboBoxEdit_FoodCategory.EditValue = "其他";
			this.comboBoxEdit_FoodCategory.Location = new System.Drawing.Point(152, 96);
			this.comboBoxEdit_FoodCategory.Name = "comboBoxEdit_FoodCategory";
			// 
			// comboBoxEdit_FoodCategory.Properties
			// 
			this.comboBoxEdit_FoodCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_FoodCategory.Properties.Items.AddRange(new object[] {
																					  "肉禽水产类",
																					  "水果类",
																					  "蔬菜类",
																					  "粮食类",
																					  "调味品",
																					  "糕点",
																					  "豆制品",
																					  "乳类",
																					  "菌藻类",
																					  "其他"});
			this.comboBoxEdit_FoodCategory.Size = new System.Drawing.Size(96, 23);
			this.comboBoxEdit_FoodCategory.TabIndex = 32;
			// 
			// notePanel_FoodCategory
			// 
			this.notePanel_FoodCategory.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_FoodCategory.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_FoodCategory.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_FoodCategory.ForeColor = System.Drawing.Color.Black;
			this.notePanel_FoodCategory.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_FoodCategory.Location = new System.Drawing.Point(40, 96);
			this.notePanel_FoodCategory.MaxRows = 5;
			this.notePanel_FoodCategory.Name = "notePanel_FoodCategory";
			this.notePanel_FoodCategory.ParentAutoHeight = true;
			this.notePanel_FoodCategory.Size = new System.Drawing.Size(96, 22);
			this.notePanel_FoodCategory.TabIndex = 31;
			this.notePanel_FoodCategory.TabStop = false;
			this.notePanel_FoodCategory.Text = "  食物类别:";
			// 
			// notePanel_FoodName
			// 
			this.notePanel_FoodName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_FoodName.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_FoodName.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_FoodName.ForeColor = System.Drawing.Color.Black;
			this.notePanel_FoodName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_FoodName.Location = new System.Drawing.Point(40, 64);
			this.notePanel_FoodName.MaxRows = 5;
			this.notePanel_FoodName.Name = "notePanel_FoodName";
			this.notePanel_FoodName.ParentAutoHeight = true;
			this.notePanel_FoodName.Size = new System.Drawing.Size(96, 22);
			this.notePanel_FoodName.TabIndex = 13;
			this.notePanel_FoodName.TabStop = false;
			this.notePanel_FoodName.Text = "   食物名:";
			// 
			// groupControl_FoodNutrition
			// 
			this.groupControl_FoodNutrition.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_FoodNutrition.AppearanceCaption.Options.UseFont = true;
			this.groupControl_FoodNutrition.Controls.Add(this.gridControl_FoodNutrition);
			this.groupControl_FoodNutrition.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl_FoodNutrition.Location = new System.Drawing.Point(0, 64);
			this.groupControl_FoodNutrition.Name = "groupControl_FoodNutrition";
			this.groupControl_FoodNutrition.Size = new System.Drawing.Size(583, 445);
			this.groupControl_FoodNutrition.TabIndex = 1;
			this.groupControl_FoodNutrition.Text = "食物营养成份";
			// 
			// gridControl_FoodNutrition
			// 
			this.gridControl_FoodNutrition.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl_FoodNutrition.EmbeddedNavigator
			// 
			this.gridControl_FoodNutrition.EmbeddedNavigator.Name = "";
			this.gridControl_FoodNutrition.Location = new System.Drawing.Point(3, 18);
			this.gridControl_FoodNutrition.MainView = this.gridView1;
			this.gridControl_FoodNutrition.Name = "gridControl_FoodNutrition";
			this.gridControl_FoodNutrition.Size = new System.Drawing.Size(577, 424);
			this.gridControl_FoodNutrition.TabIndex = 1;
			this.gridControl_FoodNutrition.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																													 this.gridView1});
			this.gridControl_FoodNutrition.DoubleClick += new System.EventHandler(this.gridControl_FoodNutrition_DoubleClick);
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn1,
																							 this.gridColumn2,
																							 this.gridColumn3,
																							 this.gridColumn4,
																							 this.gridColumn5,
																							 this.gridColumn6});
			this.gridView1.GridControl = this.gridControl_FoodNutrition;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsCustomization.AllowFilter = false;
			this.gridView1.OptionsView.ShowFilterPanel = false;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn1
			// 
			this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn1.Caption = "食物名称";
			this.gridColumn1.FieldName = "FoodNut_FoodName";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.OptionsColumn.AllowEdit = false;
			this.gridColumn1.OptionsColumn.AllowFocus = false;
			this.gridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn1.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn1.OptionsColumn.AllowMove = false;
			this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn1.OptionsColumn.FixedWidth = true;
			this.gridColumn1.OptionsColumn.ReadOnly = true;
			this.gridColumn1.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			// 
			// gridColumn2
			// 
			this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn2.Caption = "蛋白质";
			this.gridColumn2.FieldName = "FoodNut_Protein";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.OptionsColumn.AllowEdit = false;
			this.gridColumn2.OptionsColumn.AllowFocus = false;
			this.gridColumn2.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn2.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn2.OptionsColumn.AllowMove = false;
			this.gridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn2.OptionsColumn.FixedWidth = true;
			this.gridColumn2.OptionsColumn.ReadOnly = true;
			this.gridColumn2.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			// 
			// gridColumn3
			// 
			this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn3.Caption = "脂肪";
			this.gridColumn3.FieldName = "FoodNut_Fat";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.OptionsColumn.AllowEdit = false;
			this.gridColumn3.OptionsColumn.AllowFocus = false;
			this.gridColumn3.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn3.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn3.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn3.OptionsColumn.AllowMove = false;
			this.gridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn3.OptionsColumn.FixedWidth = true;
			this.gridColumn3.OptionsColumn.ReadOnly = true;
			this.gridColumn3.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 2;
			// 
			// gridColumn4
			// 
			this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn4.Caption = "碳水化合物";
			this.gridColumn4.FieldName = "FoodNut_Carbohydrate";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.OptionsColumn.AllowEdit = false;
			this.gridColumn4.OptionsColumn.AllowFocus = false;
			this.gridColumn4.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn4.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn4.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn4.OptionsColumn.AllowMove = false;
			this.gridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn4.OptionsColumn.FixedWidth = true;
			this.gridColumn4.OptionsColumn.ReadOnly = true;
			this.gridColumn4.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 3;
			// 
			// gridColumn5
			// 
			this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn5.Caption = "热量";
			this.gridColumn5.FieldName = "FoodNut_Energy";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.OptionsColumn.AllowEdit = false;
			this.gridColumn5.OptionsColumn.AllowFocus = false;
			this.gridColumn5.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn5.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn5.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn5.OptionsColumn.AllowMove = false;
			this.gridColumn5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn5.OptionsColumn.FixedWidth = true;
			this.gridColumn5.OptionsColumn.ReadOnly = true;
			this.gridColumn5.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn5.Visible = true;
			this.gridColumn5.VisibleIndex = 4;
			// 
			// gridColumn6
			// 
			this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn6.Caption = "备注";
			this.gridColumn6.FieldName = "FoodNut_Remark";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.OptionsColumn.AllowEdit = false;
			this.gridColumn6.OptionsColumn.AllowFocus = false;
			this.gridColumn6.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn6.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn6.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn6.OptionsColumn.AllowMove = false;
			this.gridColumn6.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn6.OptionsColumn.FixedWidth = true;
			this.gridColumn6.OptionsColumn.ReadOnly = true;
			this.gridColumn6.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 5;
			// 
			// panelControl1
			// 
			this.panelControl1.Controls.Add(this.simpleButton_FoodModify);
			this.panelControl1.Controls.Add(this.simpleButton_FoodBack);
			this.panelControl1.Controls.Add(this.simpleButton_FoodDelete);
			this.panelControl1.Controls.Add(this.simpleButton_FoodSave);
			this.panelControl1.Controls.Add(this.simpleButton_FoodAdd);
			this.panelControl1.Controls.Add(this.textEdit_FoodSearch);
			this.panelControl1.Controls.Add(this.textEdit_BindingID);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl1.Location = new System.Drawing.Point(0, 0);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(583, 64);
			this.panelControl1.TabIndex = 0;
			this.panelControl1.Text = "panelControl1";
			// 
			// simpleButton_FoodModify
			// 
			this.simpleButton_FoodModify.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_FoodModify.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_FoodModify.Appearance.Options.UseFont = true;
			this.simpleButton_FoodModify.Appearance.Options.UseForeColor = true;
			this.simpleButton_FoodModify.Enabled = false;
			this.simpleButton_FoodModify.Location = new System.Drawing.Point(304, 8);
			this.simpleButton_FoodModify.Name = "simpleButton_FoodModify";
			this.simpleButton_FoodModify.Size = new System.Drawing.Size(88, 26);
			this.simpleButton_FoodModify.TabIndex = 31;
			this.simpleButton_FoodModify.Tag = 4;
			this.simpleButton_FoodModify.Text = "修  改";
			this.simpleButton_FoodModify.Click += new System.EventHandler(this.simpleButton_FoodModify_Click);
			// 
			// simpleButton_FoodBack
			// 
			this.simpleButton_FoodBack.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_FoodBack.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_FoodBack.Appearance.Options.UseFont = true;
			this.simpleButton_FoodBack.Appearance.Options.UseForeColor = true;
			this.simpleButton_FoodBack.Location = new System.Drawing.Point(16, 8);
			this.simpleButton_FoodBack.Name = "simpleButton_FoodBack";
			this.simpleButton_FoodBack.Size = new System.Drawing.Size(88, 26);
			this.simpleButton_FoodBack.TabIndex = 6;
			this.simpleButton_FoodBack.Tag = 4;
			this.simpleButton_FoodBack.Text = "返  回";
			this.simpleButton_FoodBack.Click += new System.EventHandler(this.simpleButton_FoodBack_Click);
			// 
			// simpleButton_FoodDelete
			// 
			this.simpleButton_FoodDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_FoodDelete.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_FoodDelete.Appearance.Options.UseFont = true;
			this.simpleButton_FoodDelete.Appearance.Options.UseForeColor = true;
			this.simpleButton_FoodDelete.Location = new System.Drawing.Point(400, 8);
			this.simpleButton_FoodDelete.Name = "simpleButton_FoodDelete";
			this.simpleButton_FoodDelete.Size = new System.Drawing.Size(88, 26);
			this.simpleButton_FoodDelete.TabIndex = 4;
			this.simpleButton_FoodDelete.Tag = 4;
			this.simpleButton_FoodDelete.Text = "删  除";
			this.simpleButton_FoodDelete.Click += new System.EventHandler(this.simpleButton_FoodDelete_Click);
			// 
			// simpleButton_FoodSave
			// 
			this.simpleButton_FoodSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_FoodSave.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_FoodSave.Appearance.Options.UseFont = true;
			this.simpleButton_FoodSave.Appearance.Options.UseForeColor = true;
			this.simpleButton_FoodSave.Enabled = false;
			this.simpleButton_FoodSave.Location = new System.Drawing.Point(208, 8);
			this.simpleButton_FoodSave.Name = "simpleButton_FoodSave";
			this.simpleButton_FoodSave.Size = new System.Drawing.Size(88, 26);
			this.simpleButton_FoodSave.TabIndex = 3;
			this.simpleButton_FoodSave.Tag = 4;
			this.simpleButton_FoodSave.Text = "保  存";
			this.simpleButton_FoodSave.Click += new System.EventHandler(this.simpleButton_FoodSave_Click);
			// 
			// simpleButton_FoodAdd
			// 
			this.simpleButton_FoodAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_FoodAdd.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_FoodAdd.Appearance.Options.UseFont = true;
			this.simpleButton_FoodAdd.Appearance.Options.UseForeColor = true;
			this.simpleButton_FoodAdd.Location = new System.Drawing.Point(112, 8);
			this.simpleButton_FoodAdd.Name = "simpleButton_FoodAdd";
			this.simpleButton_FoodAdd.Size = new System.Drawing.Size(88, 26);
			this.simpleButton_FoodAdd.TabIndex = 2;
			this.simpleButton_FoodAdd.Tag = 4;
			this.simpleButton_FoodAdd.Text = "新  增";
			this.simpleButton_FoodAdd.Click += new System.EventHandler(this.simpleButton_FoodAdd_Click);
			// 
			// textEdit_FoodSearch
			// 
			this.textEdit_FoodSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.textEdit_FoodSearch.EditValue = "";
			this.textEdit_FoodSearch.Location = new System.Drawing.Point(3, 38);
			this.textEdit_FoodSearch.Name = "textEdit_FoodSearch";
			this.textEdit_FoodSearch.Size = new System.Drawing.Size(577, 23);
			this.textEdit_FoodSearch.TabIndex = 0;
			this.textEdit_FoodSearch.EditValueChanged += new System.EventHandler(this.textEdit_FoodSearch_EditValueChanged);
			// 
			// textEdit_BindingID
			// 
			this.textEdit_BindingID.EditValue = "";
			this.textEdit_BindingID.Location = new System.Drawing.Point(536, 48);
			this.textEdit_BindingID.Name = "textEdit_BindingID";
			// 
			// textEdit_BindingID.Properties
			// 
			this.textEdit_BindingID.Properties.AutoHeight = false;
			this.textEdit_BindingID.Size = new System.Drawing.Size(8, 8);
			this.textEdit_BindingID.TabIndex = 30;
			// 
			// xtraTabPage2
			// 
			this.xtraTabPage2.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
			this.xtraTabPage2.Appearance.PageClient.Options.UseBackColor = true;
			this.xtraTabPage2.Controls.Add(this.splitContainerControl2);
			this.xtraTabPage2.Name = "xtraTabPage2";
			this.xtraTabPage2.PageVisible = false;
			this.xtraTabPage2.Size = new System.Drawing.Size(768, 515);
			this.xtraTabPage2.Text = "每日食谱安排";
			// 
			// splitContainerControl2
			// 
			this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
			this.splitContainerControl2.Name = "splitContainerControl2";
			this.splitContainerControl2.Panel1.Controls.Add(this.panelControl10);
			this.splitContainerControl2.Panel1.Controls.Add(this.groupControl_RecipeLogin);
			this.splitContainerControl2.Panel1.Controls.Add(this.groupControl_RecipeSer);
			this.splitContainerControl2.Panel1.Controls.Add(this.groupControl_RecipeOpr);
			this.splitContainerControl2.Panel1.Text = "splitContainerControl2_Panel1";
			this.splitContainerControl2.Panel2.Controls.Add(this.panelControl11);
			this.splitContainerControl2.Panel2.Controls.Add(this.panelControl2);
			this.splitContainerControl2.Panel2.Text = "splitContainerControl2_Panel2";
			this.splitContainerControl2.Size = new System.Drawing.Size(768, 515);
			this.splitContainerControl2.SplitterPosition = 270;
			this.splitContainerControl2.TabIndex = 0;
			this.splitContainerControl2.Text = "splitContainerControl2";
			// 
			// panelControl10
			// 
			this.panelControl10.Controls.Add(this.gridControl_Recipe_FoodNutrition);
			this.panelControl10.Controls.Add(this.notePanel4);
			this.panelControl10.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelControl10.Location = new System.Drawing.Point(0, 312);
			this.panelControl10.Name = "panelControl10";
			this.panelControl10.Size = new System.Drawing.Size(264, 197);
			this.panelControl10.TabIndex = 41;
			this.panelControl10.Text = "panelControl10";
			// 
			// gridControl_Recipe_FoodNutrition
			// 
			this.gridControl_Recipe_FoodNutrition.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl_Recipe_FoodNutrition.EmbeddedNavigator
			// 
			this.gridControl_Recipe_FoodNutrition.EmbeddedNavigator.Name = "";
			this.gridControl_Recipe_FoodNutrition.Location = new System.Drawing.Point(3, 26);
			this.gridControl_Recipe_FoodNutrition.MainView = this.gridView4;
			this.gridControl_Recipe_FoodNutrition.Name = "gridControl_Recipe_FoodNutrition";
			this.gridControl_Recipe_FoodNutrition.Size = new System.Drawing.Size(258, 168);
			this.gridControl_Recipe_FoodNutrition.TabIndex = 47;
			this.gridControl_Recipe_FoodNutrition.ToolTipController = this.toolTipController1;
			this.gridControl_Recipe_FoodNutrition.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																															this.gridView4,
																															this.gridView2});
			this.gridControl_Recipe_FoodNutrition.DoubleClick += new System.EventHandler(this.gridControl_Recipe_FoodNutrition_DoubleClick);
			// 
			// gridView4
			// 
			this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn7,
																							 this.gridColumn8,
																							 this.gridColumn9,
																							 this.gridColumn10,
																							 this.gridColumn11,
																							 this.gridColumn16});
			this.gridView4.GridControl = this.gridControl_Recipe_FoodNutrition;
			this.gridView4.Name = "gridView4";
			this.gridView4.OptionsCustomization.AllowFilter = false;
			this.gridView4.OptionsView.ShowFilterPanel = false;
			this.gridView4.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn7
			// 
			this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn7.Caption = "食物名";
			this.gridColumn7.FieldName = "FoodNut_FoodName";
			this.gridColumn7.Name = "gridColumn7";
			this.gridColumn7.OptionsColumn.AllowEdit = false;
			this.gridColumn7.OptionsColumn.AllowFocus = false;
			this.gridColumn7.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn7.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn7.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn7.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn7.OptionsColumn.ReadOnly = true;
			this.gridColumn7.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn7.Visible = true;
			this.gridColumn7.VisibleIndex = 0;
			// 
			// gridColumn8
			// 
			this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn8.Caption = "蛋白质";
			this.gridColumn8.FieldName = "FoodNut_Protein";
			this.gridColumn8.Name = "gridColumn8";
			this.gridColumn8.OptionsColumn.AllowEdit = false;
			this.gridColumn8.OptionsColumn.AllowFocus = false;
			this.gridColumn8.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn8.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn8.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn8.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn8.OptionsColumn.ReadOnly = true;
			this.gridColumn8.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn8.Visible = true;
			this.gridColumn8.VisibleIndex = 1;
			// 
			// gridColumn9
			// 
			this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn9.Caption = "脂肪";
			this.gridColumn9.FieldName = "FoodNut_Fat";
			this.gridColumn9.Name = "gridColumn9";
			this.gridColumn9.OptionsColumn.AllowEdit = false;
			this.gridColumn9.OptionsColumn.AllowFocus = false;
			this.gridColumn9.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn9.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn9.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn9.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn9.OptionsColumn.ReadOnly = true;
			this.gridColumn9.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn9.Visible = true;
			this.gridColumn9.VisibleIndex = 2;
			// 
			// gridColumn10
			// 
			this.gridColumn10.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn10.Caption = "碳水化合物";
			this.gridColumn10.FieldName = "FoodNut_Carbohydrate";
			this.gridColumn10.Name = "gridColumn10";
			this.gridColumn10.OptionsColumn.AllowEdit = false;
			this.gridColumn10.OptionsColumn.AllowFocus = false;
			this.gridColumn10.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn10.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn10.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn10.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn10.OptionsColumn.ReadOnly = true;
			this.gridColumn10.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn10.Visible = true;
			this.gridColumn10.VisibleIndex = 3;
			// 
			// gridColumn11
			// 
			this.gridColumn11.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn11.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn11.Caption = "能量";
			this.gridColumn11.FieldName = "FoodNut_Energy";
			this.gridColumn11.Name = "gridColumn11";
			this.gridColumn11.OptionsColumn.AllowEdit = false;
			this.gridColumn11.OptionsColumn.AllowFocus = false;
			this.gridColumn11.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn11.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn11.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn11.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn11.OptionsColumn.ReadOnly = true;
			this.gridColumn11.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn11.Visible = true;
			this.gridColumn11.VisibleIndex = 4;
			// 
			// gridColumn16
			// 
			this.gridColumn16.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn16.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn16.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn16.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn16.Caption = "备注";
			this.gridColumn16.FieldName = "FoodNut_Remark";
			this.gridColumn16.Name = "gridColumn16";
			this.gridColumn16.OptionsColumn.AllowEdit = false;
			this.gridColumn16.OptionsColumn.AllowFocus = false;
			this.gridColumn16.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn16.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn16.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn16.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn16.OptionsColumn.ReadOnly = true;
			this.gridColumn16.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn16.Visible = true;
			this.gridColumn16.VisibleIndex = 5;
			// 
			// toolTipController1
			// 
			this.toolTipController1.GetActiveObjectInfo += new DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventHandler(this.toolTipController1_GetActiveObjectInfo);
			// 
			// gridView2
			// 
			this.gridView2.GridControl = this.gridControl_Recipe_FoodNutrition;
			this.gridView2.Name = "gridView2";
			// 
			// notePanel4
			// 
			this.notePanel4.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel4.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel4.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel4.Location = new System.Drawing.Point(3, 3);
			this.notePanel4.MaxRows = 5;
			this.notePanel4.Name = "notePanel4";
			this.notePanel4.ParentAutoHeight = true;
			this.notePanel4.Size = new System.Drawing.Size(258, 23);
			this.notePanel4.TabIndex = 46;
			this.notePanel4.TabStop = false;
			this.notePanel4.Text = "双击在食物用料登记处获取食物名称";
			// 
			// groupControl_RecipeLogin
			// 
			this.groupControl_RecipeLogin.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_RecipeLogin.AppearanceCaption.Options.UseFont = true;
			this.groupControl_RecipeLogin.Controls.Add(this.textEdit_RecipeLogin_FoodName);
			this.groupControl_RecipeLogin.Controls.Add(this.textEdit_RecipeLogin_Name);
			this.groupControl_RecipeLogin.Controls.Add(this.notePanel_RecipeLogin_Name);
			this.groupControl_RecipeLogin.Controls.Add(this.dateEdit_RecipeLogin_Date);
			this.groupControl_RecipeLogin.Controls.Add(this.notePanel_RecipeLogin_Date);
			this.groupControl_RecipeLogin.Controls.Add(this.textEdit_RecipeLogin_FoodTake);
			this.groupControl_RecipeLogin.Controls.Add(this.notePanel_RecipeLogin_FoodTake);
			this.groupControl_RecipeLogin.Controls.Add(this.textEdit_RecipeLogin_BindingID);
			this.groupControl_RecipeLogin.Controls.Add(this.notePanel_RecipeLogin_FoodName);
			this.groupControl_RecipeLogin.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_RecipeLogin.Location = new System.Drawing.Point(0, 152);
			this.groupControl_RecipeLogin.Name = "groupControl_RecipeLogin";
			this.groupControl_RecipeLogin.Size = new System.Drawing.Size(264, 160);
			this.groupControl_RecipeLogin.TabIndex = 40;
			this.groupControl_RecipeLogin.Text = "食物用料登记";
			// 
			// textEdit_RecipeLogin_FoodName
			// 
			this.textEdit_RecipeLogin_FoodName.EditValue = "";
			this.textEdit_RecipeLogin_FoodName.Location = new System.Drawing.Point(128, 24);
			this.textEdit_RecipeLogin_FoodName.Name = "textEdit_RecipeLogin_FoodName";
			// 
			// textEdit_RecipeLogin_FoodName.Properties
			// 
			this.textEdit_RecipeLogin_FoodName.Properties.Enabled = false;
			this.textEdit_RecipeLogin_FoodName.Size = new System.Drawing.Size(88, 23);
			this.textEdit_RecipeLogin_FoodName.TabIndex = 34;
			// 
			// textEdit_RecipeLogin_Name
			// 
			this.textEdit_RecipeLogin_Name.EditValue = "";
			this.textEdit_RecipeLogin_Name.Location = new System.Drawing.Point(128, 120);
			this.textEdit_RecipeLogin_Name.Name = "textEdit_RecipeLogin_Name";
			this.textEdit_RecipeLogin_Name.Size = new System.Drawing.Size(88, 23);
			this.textEdit_RecipeLogin_Name.TabIndex = 33;
			// 
			// notePanel_RecipeLogin_Name
			// 
			this.notePanel_RecipeLogin_Name.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_RecipeLogin_Name.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_RecipeLogin_Name.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_RecipeLogin_Name.ForeColor = System.Drawing.Color.Black;
			this.notePanel_RecipeLogin_Name.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_RecipeLogin_Name.Location = new System.Drawing.Point(40, 120);
			this.notePanel_RecipeLogin_Name.MaxRows = 5;
			this.notePanel_RecipeLogin_Name.Name = "notePanel_RecipeLogin_Name";
			this.notePanel_RecipeLogin_Name.ParentAutoHeight = true;
			this.notePanel_RecipeLogin_Name.Size = new System.Drawing.Size(80, 22);
			this.notePanel_RecipeLogin_Name.TabIndex = 32;
			this.notePanel_RecipeLogin_Name.TabStop = false;
			this.notePanel_RecipeLogin_Name.Text = "菜谱名称:";
			// 
			// dateEdit_RecipeLogin_Date
			// 
			this.dateEdit_RecipeLogin_Date.EditValue = new System.DateTime(2005, 11, 17, 0, 0, 0, 0);
			this.dateEdit_RecipeLogin_Date.Location = new System.Drawing.Point(128, 88);
			this.dateEdit_RecipeLogin_Date.Name = "dateEdit_RecipeLogin_Date";
			// 
			// dateEdit_RecipeLogin_Date.Properties
			// 
			this.dateEdit_RecipeLogin_Date.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit_RecipeLogin_Date.Properties.Enabled = false;
			this.dateEdit_RecipeLogin_Date.Properties.Mask.EditMask = "d";
			this.dateEdit_RecipeLogin_Date.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
			this.dateEdit_RecipeLogin_Date.Size = new System.Drawing.Size(88, 23);
			this.dateEdit_RecipeLogin_Date.TabIndex = 31;
			// 
			// notePanel_RecipeLogin_Date
			// 
			this.notePanel_RecipeLogin_Date.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_RecipeLogin_Date.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_RecipeLogin_Date.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_RecipeLogin_Date.ForeColor = System.Drawing.Color.Black;
			this.notePanel_RecipeLogin_Date.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_RecipeLogin_Date.Location = new System.Drawing.Point(40, 88);
			this.notePanel_RecipeLogin_Date.MaxRows = 5;
			this.notePanel_RecipeLogin_Date.Name = "notePanel_RecipeLogin_Date";
			this.notePanel_RecipeLogin_Date.ParentAutoHeight = true;
			this.notePanel_RecipeLogin_Date.Size = new System.Drawing.Size(80, 22);
			this.notePanel_RecipeLogin_Date.TabIndex = 30;
			this.notePanel_RecipeLogin_Date.TabStop = false;
			this.notePanel_RecipeLogin_Date.Text = "登记日期:";
			// 
			// textEdit_RecipeLogin_FoodTake
			// 
			this.textEdit_RecipeLogin_FoodTake.EditValue = "";
			this.textEdit_RecipeLogin_FoodTake.Location = new System.Drawing.Point(128, 56);
			this.textEdit_RecipeLogin_FoodTake.Name = "textEdit_RecipeLogin_FoodTake";
			this.textEdit_RecipeLogin_FoodTake.Size = new System.Drawing.Size(88, 23);
			this.textEdit_RecipeLogin_FoodTake.TabIndex = 29;
			// 
			// notePanel_RecipeLogin_FoodTake
			// 
			this.notePanel_RecipeLogin_FoodTake.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_RecipeLogin_FoodTake.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_RecipeLogin_FoodTake.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_RecipeLogin_FoodTake.ForeColor = System.Drawing.Color.Black;
			this.notePanel_RecipeLogin_FoodTake.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_RecipeLogin_FoodTake.Location = new System.Drawing.Point(40, 56);
			this.notePanel_RecipeLogin_FoodTake.MaxRows = 5;
			this.notePanel_RecipeLogin_FoodTake.Name = "notePanel_RecipeLogin_FoodTake";
			this.notePanel_RecipeLogin_FoodTake.ParentAutoHeight = true;
			this.notePanel_RecipeLogin_FoodTake.Size = new System.Drawing.Size(80, 22);
			this.notePanel_RecipeLogin_FoodTake.TabIndex = 28;
			this.notePanel_RecipeLogin_FoodTake.TabStop = false;
			this.notePanel_RecipeLogin_FoodTake.Text = "  摄入量:";
			// 
			// textEdit_RecipeLogin_BindingID
			// 
			this.textEdit_RecipeLogin_BindingID.EditValue = "";
			this.textEdit_RecipeLogin_BindingID.Location = new System.Drawing.Point(200, 24);
			this.textEdit_RecipeLogin_BindingID.Name = "textEdit_RecipeLogin_BindingID";
			// 
			// textEdit_RecipeLogin_BindingID.Properties
			// 
			this.textEdit_RecipeLogin_BindingID.Properties.AutoHeight = false;
			this.textEdit_RecipeLogin_BindingID.Properties.Enabled = false;
			this.textEdit_RecipeLogin_BindingID.Size = new System.Drawing.Size(8, 16);
			this.textEdit_RecipeLogin_BindingID.TabIndex = 27;
			// 
			// notePanel_RecipeLogin_FoodName
			// 
			this.notePanel_RecipeLogin_FoodName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_RecipeLogin_FoodName.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_RecipeLogin_FoodName.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_RecipeLogin_FoodName.ForeColor = System.Drawing.Color.Black;
			this.notePanel_RecipeLogin_FoodName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_RecipeLogin_FoodName.Location = new System.Drawing.Point(40, 24);
			this.notePanel_RecipeLogin_FoodName.MaxRows = 5;
			this.notePanel_RecipeLogin_FoodName.Name = "notePanel_RecipeLogin_FoodName";
			this.notePanel_RecipeLogin_FoodName.ParentAutoHeight = true;
			this.notePanel_RecipeLogin_FoodName.Size = new System.Drawing.Size(80, 22);
			this.notePanel_RecipeLogin_FoodName.TabIndex = 26;
			this.notePanel_RecipeLogin_FoodName.TabStop = false;
			this.notePanel_RecipeLogin_FoodName.Text = "食物名称:";
			// 
			// groupControl_RecipeSer
			// 
			this.groupControl_RecipeSer.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_RecipeSer.Appearance.Options.UseFont = true;
			this.groupControl_RecipeSer.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_RecipeSer.AppearanceCaption.Options.UseFont = true;
			this.groupControl_RecipeSer.Controls.Add(this.comboBoxEdit_RecipeSer_FoodCategory);
			this.groupControl_RecipeSer.Controls.Add(this.notePanel_RecipeSer_FoodCategory);
			this.groupControl_RecipeSer.Controls.Add(this.textEdit_RecipeSer_FoodName);
			this.groupControl_RecipeSer.Controls.Add(this.notePanel_RecipeSer_FoodName);
			this.groupControl_RecipeSer.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_RecipeSer.Location = new System.Drawing.Point(0, 56);
			this.groupControl_RecipeSer.Name = "groupControl_RecipeSer";
			this.groupControl_RecipeSer.Size = new System.Drawing.Size(264, 96);
			this.groupControl_RecipeSer.TabIndex = 39;
			this.groupControl_RecipeSer.Text = "食物查询";
			// 
			// comboBoxEdit_RecipeSer_FoodCategory
			// 
			this.comboBoxEdit_RecipeSer_FoodCategory.EditValue = "全部";
			this.comboBoxEdit_RecipeSer_FoodCategory.Location = new System.Drawing.Point(128, 56);
			this.comboBoxEdit_RecipeSer_FoodCategory.Name = "comboBoxEdit_RecipeSer_FoodCategory";
			// 
			// comboBoxEdit_RecipeSer_FoodCategory.Properties
			// 
			this.comboBoxEdit_RecipeSer_FoodCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																		new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_RecipeSer_FoodCategory.Properties.Items.AddRange(new object[] {
																								"肉禽水产类",
																								"水果类",
																								"蔬菜类",
																								"粮食类",
																								"调味品",
																								"糕点",
																								"豆制品",
																								"乳类",
																								"菌藻类",
																								"其他"});
			this.comboBoxEdit_RecipeSer_FoodCategory.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_RecipeSer_FoodCategory.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_RecipeSer_FoodCategory.TabIndex = 27;
			this.comboBoxEdit_RecipeSer_FoodCategory.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_RecipeSer_FoodCategory_SelectedIndexChanged);
			// 
			// notePanel_RecipeSer_FoodCategory
			// 
			this.notePanel_RecipeSer_FoodCategory.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_RecipeSer_FoodCategory.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_RecipeSer_FoodCategory.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_RecipeSer_FoodCategory.ForeColor = System.Drawing.Color.Black;
			this.notePanel_RecipeSer_FoodCategory.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_RecipeSer_FoodCategory.Location = new System.Drawing.Point(40, 56);
			this.notePanel_RecipeSer_FoodCategory.MaxRows = 5;
			this.notePanel_RecipeSer_FoodCategory.Name = "notePanel_RecipeSer_FoodCategory";
			this.notePanel_RecipeSer_FoodCategory.ParentAutoHeight = true;
			this.notePanel_RecipeSer_FoodCategory.Size = new System.Drawing.Size(80, 22);
			this.notePanel_RecipeSer_FoodCategory.TabIndex = 26;
			this.notePanel_RecipeSer_FoodCategory.TabStop = false;
			this.notePanel_RecipeSer_FoodCategory.Text = "食物分类:";
			// 
			// textEdit_RecipeSer_FoodName
			// 
			this.textEdit_RecipeSer_FoodName.EditValue = "";
			this.textEdit_RecipeSer_FoodName.Location = new System.Drawing.Point(128, 24);
			this.textEdit_RecipeSer_FoodName.Name = "textEdit_RecipeSer_FoodName";
			this.textEdit_RecipeSer_FoodName.Size = new System.Drawing.Size(88, 23);
			this.textEdit_RecipeSer_FoodName.TabIndex = 25;
			this.textEdit_RecipeSer_FoodName.EditValueChanged += new System.EventHandler(this.textEdit_RecipeSer_FoodName_EditValueChanged);
			// 
			// notePanel_RecipeSer_FoodName
			// 
			this.notePanel_RecipeSer_FoodName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_RecipeSer_FoodName.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_RecipeSer_FoodName.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_RecipeSer_FoodName.ForeColor = System.Drawing.Color.Black;
			this.notePanel_RecipeSer_FoodName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_RecipeSer_FoodName.Location = new System.Drawing.Point(40, 24);
			this.notePanel_RecipeSer_FoodName.MaxRows = 5;
			this.notePanel_RecipeSer_FoodName.Name = "notePanel_RecipeSer_FoodName";
			this.notePanel_RecipeSer_FoodName.ParentAutoHeight = true;
			this.notePanel_RecipeSer_FoodName.Size = new System.Drawing.Size(80, 22);
			this.notePanel_RecipeSer_FoodName.TabIndex = 24;
			this.notePanel_RecipeSer_FoodName.TabStop = false;
			this.notePanel_RecipeSer_FoodName.Text = "食物名称:";
			// 
			// groupControl_RecipeOpr
			// 
			this.groupControl_RecipeOpr.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_RecipeOpr.AppearanceCaption.Options.UseFont = true;
			this.groupControl_RecipeOpr.Controls.Add(this.simpleButton_RecipeModify);
			this.groupControl_RecipeOpr.Controls.Add(this.simpleButton_RecipeSave);
			this.groupControl_RecipeOpr.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_RecipeOpr.Location = new System.Drawing.Point(0, 0);
			this.groupControl_RecipeOpr.Name = "groupControl_RecipeOpr";
			this.groupControl_RecipeOpr.Size = new System.Drawing.Size(264, 56);
			this.groupControl_RecipeOpr.TabIndex = 38;
			this.groupControl_RecipeOpr.Text = "食谱操作";
			// 
			// simpleButton_RecipeModify
			// 
			this.simpleButton_RecipeModify.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_RecipeModify.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_RecipeModify.Appearance.Options.UseFont = true;
			this.simpleButton_RecipeModify.Appearance.Options.UseForeColor = true;
			this.simpleButton_RecipeModify.Enabled = false;
			this.simpleButton_RecipeModify.Location = new System.Drawing.Point(144, 24);
			this.simpleButton_RecipeModify.Name = "simpleButton_RecipeModify";
			this.simpleButton_RecipeModify.Size = new System.Drawing.Size(72, 26);
			this.simpleButton_RecipeModify.TabIndex = 40;
			this.simpleButton_RecipeModify.Tag = 4;
			this.simpleButton_RecipeModify.Text = "修改";
			this.simpleButton_RecipeModify.Click += new System.EventHandler(this.simpleButton_RecipeModify_Click);
			// 
			// simpleButton_RecipeSave
			// 
			this.simpleButton_RecipeSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_RecipeSave.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_RecipeSave.Appearance.Options.UseFont = true;
			this.simpleButton_RecipeSave.Appearance.Options.UseForeColor = true;
			this.simpleButton_RecipeSave.Enabled = false;
			this.simpleButton_RecipeSave.Location = new System.Drawing.Point(48, 24);
			this.simpleButton_RecipeSave.Name = "simpleButton_RecipeSave";
			this.simpleButton_RecipeSave.Size = new System.Drawing.Size(72, 26);
			this.simpleButton_RecipeSave.TabIndex = 38;
			this.simpleButton_RecipeSave.Tag = 4;
			this.simpleButton_RecipeSave.Text = "保存";
			this.simpleButton_RecipeSave.Click += new System.EventHandler(this.simpleButton_RecipeSave_Click);
			// 
			// panelControl11
			// 
			this.panelControl11.Controls.Add(this.gridControl_RecipeLogin);
			this.panelControl11.Controls.Add(this.notePanel5);
			this.panelControl11.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelControl11.Location = new System.Drawing.Point(0, 112);
			this.panelControl11.Name = "panelControl11";
			this.panelControl11.Size = new System.Drawing.Size(488, 397);
			this.panelControl11.TabIndex = 26;
			this.panelControl11.Text = "panelControl11";
			// 
			// gridControl_RecipeLogin
			// 
			this.gridControl_RecipeLogin.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl_RecipeLogin.EmbeddedNavigator
			// 
			this.gridControl_RecipeLogin.EmbeddedNavigator.Name = "";
			this.gridControl_RecipeLogin.Location = new System.Drawing.Point(3, 26);
			this.gridControl_RecipeLogin.MainView = this.gridView13;
			this.gridControl_RecipeLogin.Name = "gridControl_RecipeLogin";
			this.barManager1.SetPopupContextMenu(this.gridControl_RecipeLogin, this.popupMenu4);
			this.gridControl_RecipeLogin.Size = new System.Drawing.Size(482, 368);
			this.gridControl_RecipeLogin.TabIndex = 34;
			this.gridControl_RecipeLogin.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																												   this.gridView13});
			this.gridControl_RecipeLogin.Click += new System.EventHandler(this.gridControl_RecipeLogin_Click);
			// 
			// gridView13
			// 
			this.gridView13.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							  this.gridColumn50,
																							  this.gridColumn51,
																							  this.gridColumn52,
																							  this.gridColumn53});
			this.gridView13.GridControl = this.gridControl_RecipeLogin;
			this.gridView13.Name = "gridView13";
			this.gridView13.OptionsCustomization.AllowFilter = false;
			this.gridView13.OptionsView.ShowFilterPanel = false;
			this.gridView13.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn50
			// 
			this.gridColumn50.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn50.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn50.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn50.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn50.Caption = "食物名称";
			this.gridColumn50.FieldName = "FoodNut_FoodName";
			this.gridColumn50.Name = "gridColumn50";
			this.gridColumn50.OptionsColumn.AllowEdit = false;
			this.gridColumn50.OptionsColumn.AllowFocus = false;
			this.gridColumn50.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn50.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn50.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn50.OptionsColumn.AllowMove = false;
			this.gridColumn50.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn50.OptionsColumn.FixedWidth = true;
			this.gridColumn50.OptionsColumn.ReadOnly = true;
			this.gridColumn50.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn50.Visible = true;
			this.gridColumn50.VisibleIndex = 0;
			// 
			// gridColumn51
			// 
			this.gridColumn51.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn51.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn51.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn51.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn51.Caption = "登记日期";
			this.gridColumn51.FieldName = "ACCFood_AddTime";
			this.gridColumn51.Name = "gridColumn51";
			this.gridColumn51.OptionsColumn.AllowEdit = false;
			this.gridColumn51.OptionsColumn.AllowFocus = false;
			this.gridColumn51.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn51.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn51.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn51.OptionsColumn.AllowMove = false;
			this.gridColumn51.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn51.OptionsColumn.FixedWidth = true;
			this.gridColumn51.OptionsColumn.ReadOnly = true;
			this.gridColumn51.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn51.Visible = true;
			this.gridColumn51.VisibleIndex = 1;
			// 
			// gridColumn52
			// 
			this.gridColumn52.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn52.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn52.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn52.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn52.Caption = "摄入量";
			this.gridColumn52.FieldName = "ACCFood_TakeAmount";
			this.gridColumn52.Name = "gridColumn52";
			this.gridColumn52.OptionsColumn.AllowEdit = false;
			this.gridColumn52.OptionsColumn.AllowFocus = false;
			this.gridColumn52.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn52.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn52.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn52.OptionsColumn.AllowMove = false;
			this.gridColumn52.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn52.OptionsColumn.FixedWidth = true;
			this.gridColumn52.OptionsColumn.ReadOnly = true;
			this.gridColumn52.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn52.Visible = true;
			this.gridColumn52.VisibleIndex = 2;
			// 
			// gridColumn53
			// 
			this.gridColumn53.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn53.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn53.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn53.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn53.Caption = "菜谱名称";
			this.gridColumn53.FieldName = "ACCFood_Remark";
			this.gridColumn53.Name = "gridColumn53";
			this.gridColumn53.OptionsColumn.AllowEdit = false;
			this.gridColumn53.OptionsColumn.AllowFocus = false;
			this.gridColumn53.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn53.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn53.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn53.OptionsColumn.AllowMove = false;
			this.gridColumn53.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn53.OptionsColumn.FixedWidth = true;
			this.gridColumn53.OptionsColumn.ReadOnly = true;
			this.gridColumn53.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn53.Visible = true;
			this.gridColumn53.VisibleIndex = 3;
			// 
			// notePanel5
			// 
			this.notePanel5.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel5.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel5.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel5.Location = new System.Drawing.Point(3, 3);
			this.notePanel5.MaxRows = 5;
			this.notePanel5.Name = "notePanel5";
			this.notePanel5.ParentAutoHeight = true;
			this.notePanel5.Size = new System.Drawing.Size(482, 23);
			this.notePanel5.TabIndex = 33;
			this.notePanel5.TabStop = false;
			this.notePanel5.Text = "选中一行可以在食物用料登记处对当日的食谱用料进行修改";
			// 
			// panelControl2
			// 
			this.panelControl2.Controls.Add(this.textEdit_Recipe_FoodName);
			this.panelControl2.Controls.Add(this.notePanel_Recipe_FoodName);
			this.panelControl2.Controls.Add(this.notePanel_Recipe);
			this.panelControl2.Controls.Add(this.comboBoxEdit_Recipe_RecipeCategory);
			this.panelControl2.Controls.Add(this.notePanel_Recipe_RecipeCategory);
			this.panelControl2.Controls.Add(this.dateEdit_Recipe_EndDate);
			this.panelControl2.Controls.Add(this.notePanel_Recipe_EndDate);
			this.panelControl2.Controls.Add(this.dateEdit_Recipe_BegDate);
			this.panelControl2.Controls.Add(this.notePanel_Recipe_BegDate);
			this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl2.Location = new System.Drawing.Point(0, 0);
			this.panelControl2.Name = "panelControl2";
			this.panelControl2.Size = new System.Drawing.Size(488, 112);
			this.panelControl2.TabIndex = 25;
			this.panelControl2.Text = "panelControl2";
			// 
			// textEdit_Recipe_FoodName
			// 
			this.textEdit_Recipe_FoodName.EditValue = "";
			this.textEdit_Recipe_FoodName.Location = new System.Drawing.Point(352, 40);
			this.textEdit_Recipe_FoodName.Name = "textEdit_Recipe_FoodName";
			this.textEdit_Recipe_FoodName.Size = new System.Drawing.Size(88, 23);
			this.textEdit_Recipe_FoodName.TabIndex = 34;
			this.textEdit_Recipe_FoodName.EditValueChanged += new System.EventHandler(this.textEdit_Recipe_FoodName_EditValueChanged);
			// 
			// notePanel_Recipe_FoodName
			// 
			this.notePanel_Recipe_FoodName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_Recipe_FoodName.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_Recipe_FoodName.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_Recipe_FoodName.ForeColor = System.Drawing.Color.Black;
			this.notePanel_Recipe_FoodName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Recipe_FoodName.Location = new System.Drawing.Point(256, 40);
			this.notePanel_Recipe_FoodName.MaxRows = 5;
			this.notePanel_Recipe_FoodName.Name = "notePanel_Recipe_FoodName";
			this.notePanel_Recipe_FoodName.ParentAutoHeight = true;
			this.notePanel_Recipe_FoodName.Size = new System.Drawing.Size(80, 22);
			this.notePanel_Recipe_FoodName.TabIndex = 33;
			this.notePanel_Recipe_FoodName.TabStop = false;
			this.notePanel_Recipe_FoodName.Text = "食物名称:";
			// 
			// notePanel_Recipe
			// 
			this.notePanel_Recipe.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel_Recipe.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel_Recipe.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel_Recipe.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Recipe.Location = new System.Drawing.Point(3, 3);
			this.notePanel_Recipe.MaxRows = 5;
			this.notePanel_Recipe.Name = "notePanel_Recipe";
			this.notePanel_Recipe.ParentAutoHeight = true;
			this.notePanel_Recipe.Size = new System.Drawing.Size(482, 23);
			this.notePanel_Recipe.TabIndex = 32;
			this.notePanel_Recipe.TabStop = false;
			this.notePanel_Recipe.Text = "查询您已设置的食谱，摄入量以\"斤\"计算";
			// 
			// comboBoxEdit_Recipe_RecipeCategory
			// 
			this.comboBoxEdit_Recipe_RecipeCategory.EditValue = "全部";
			this.comboBoxEdit_Recipe_RecipeCategory.Location = new System.Drawing.Point(152, 40);
			this.comboBoxEdit_Recipe_RecipeCategory.Name = "comboBoxEdit_Recipe_RecipeCategory";
			// 
			// comboBoxEdit_Recipe_RecipeCategory.Properties
			// 
			this.comboBoxEdit_Recipe_RecipeCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																	   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_Recipe_RecipeCategory.Properties.Items.AddRange(new object[] {
																							   "全部",
																							   "肉禽水产类",
																							   "水果类",
																							   "蔬菜类",
																							   "粮食类",
																							   "调味品",
																							   "糕点",
																							   "豆制品",
																							   "乳类",
																							   "菌藻类",
																							   "其他"});
			this.comboBoxEdit_Recipe_RecipeCategory.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_Recipe_RecipeCategory.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_Recipe_RecipeCategory.TabIndex = 30;
			this.comboBoxEdit_Recipe_RecipeCategory.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_Recipe_RecipeCategory_SelectedIndexChanged);
			// 
			// notePanel_Recipe_RecipeCategory
			// 
			this.notePanel_Recipe_RecipeCategory.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_Recipe_RecipeCategory.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_Recipe_RecipeCategory.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_Recipe_RecipeCategory.ForeColor = System.Drawing.Color.Black;
			this.notePanel_Recipe_RecipeCategory.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Recipe_RecipeCategory.Location = new System.Drawing.Point(56, 40);
			this.notePanel_Recipe_RecipeCategory.MaxRows = 5;
			this.notePanel_Recipe_RecipeCategory.Name = "notePanel_Recipe_RecipeCategory";
			this.notePanel_Recipe_RecipeCategory.ParentAutoHeight = true;
			this.notePanel_Recipe_RecipeCategory.Size = new System.Drawing.Size(80, 22);
			this.notePanel_Recipe_RecipeCategory.TabIndex = 29;
			this.notePanel_Recipe_RecipeCategory.TabStop = false;
			this.notePanel_Recipe_RecipeCategory.Text = "食谱分类:";
			// 
			// dateEdit_Recipe_EndDate
			// 
			this.dateEdit_Recipe_EndDate.EditValue = new System.DateTime(2005, 11, 17, 0, 0, 0, 0);
			this.dateEdit_Recipe_EndDate.Location = new System.Drawing.Point(352, 72);
			this.dateEdit_Recipe_EndDate.Name = "dateEdit_Recipe_EndDate";
			// 
			// dateEdit_Recipe_EndDate.Properties
			// 
			this.dateEdit_Recipe_EndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit_Recipe_EndDate.Properties.Mask.EditMask = "d";
			this.dateEdit_Recipe_EndDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
			this.dateEdit_Recipe_EndDate.Size = new System.Drawing.Size(88, 23);
			this.dateEdit_Recipe_EndDate.TabIndex = 28;
			// 
			// notePanel_Recipe_EndDate
			// 
			this.notePanel_Recipe_EndDate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_Recipe_EndDate.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_Recipe_EndDate.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_Recipe_EndDate.ForeColor = System.Drawing.Color.Black;
			this.notePanel_Recipe_EndDate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Recipe_EndDate.Location = new System.Drawing.Point(256, 72);
			this.notePanel_Recipe_EndDate.MaxRows = 5;
			this.notePanel_Recipe_EndDate.Name = "notePanel_Recipe_EndDate";
			this.notePanel_Recipe_EndDate.ParentAutoHeight = true;
			this.notePanel_Recipe_EndDate.Size = new System.Drawing.Size(80, 22);
			this.notePanel_Recipe_EndDate.TabIndex = 27;
			this.notePanel_Recipe_EndDate.TabStop = false;
			this.notePanel_Recipe_EndDate.Text = "结束时间:";
			// 
			// dateEdit_Recipe_BegDate
			// 
			this.dateEdit_Recipe_BegDate.EditValue = new System.DateTime(2005, 11, 17, 0, 0, 0, 0);
			this.dateEdit_Recipe_BegDate.Location = new System.Drawing.Point(152, 72);
			this.dateEdit_Recipe_BegDate.Name = "dateEdit_Recipe_BegDate";
			// 
			// dateEdit_Recipe_BegDate.Properties
			// 
			this.dateEdit_Recipe_BegDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit_Recipe_BegDate.Properties.Mask.EditMask = "d";
			this.dateEdit_Recipe_BegDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
			this.dateEdit_Recipe_BegDate.Size = new System.Drawing.Size(88, 23);
			this.dateEdit_Recipe_BegDate.TabIndex = 26;
			// 
			// notePanel_Recipe_BegDate
			// 
			this.notePanel_Recipe_BegDate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_Recipe_BegDate.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_Recipe_BegDate.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_Recipe_BegDate.ForeColor = System.Drawing.Color.Black;
			this.notePanel_Recipe_BegDate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Recipe_BegDate.Location = new System.Drawing.Point(56, 72);
			this.notePanel_Recipe_BegDate.MaxRows = 5;
			this.notePanel_Recipe_BegDate.Name = "notePanel_Recipe_BegDate";
			this.notePanel_Recipe_BegDate.ParentAutoHeight = true;
			this.notePanel_Recipe_BegDate.Size = new System.Drawing.Size(80, 22);
			this.notePanel_Recipe_BegDate.TabIndex = 25;
			this.notePanel_Recipe_BegDate.TabStop = false;
			this.notePanel_Recipe_BegDate.Text = "起始时间:";
			// 
			// xtraTabPage3
			// 
			this.xtraTabPage3.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
			this.xtraTabPage3.Appearance.PageClient.Options.UseBackColor = true;
			this.xtraTabPage3.Controls.Add(this.splitContainerControl3);
			this.xtraTabPage3.Name = "xtraTabPage3";
			this.xtraTabPage3.PageVisible = false;
			this.xtraTabPage3.Size = new System.Drawing.Size(768, 515);
			this.xtraTabPage3.Text = "集体膳食安排";
			// 
			// splitContainerControl3
			// 
			this.splitContainerControl3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl3.Location = new System.Drawing.Point(0, 0);
			this.splitContainerControl3.Name = "splitContainerControl3";
			this.splitContainerControl3.Panel1.Controls.Add(this.groupControl_MealLogin);
			this.splitContainerControl3.Panel1.Controls.Add(this.groupControl_MealAdd);
			this.splitContainerControl3.Panel1.Text = "splitContainerControl3_Panel1";
			this.splitContainerControl3.Panel2.Controls.Add(this.groupControl_MealArr);
			this.splitContainerControl3.Panel2.Controls.Add(this.groupControl_MealPreview);
			this.splitContainerControl3.Panel2.Controls.Add(this.panelControl3);
			this.splitContainerControl3.Panel2.Text = "splitContainerControl3_Panel2";
			this.splitContainerControl3.Size = new System.Drawing.Size(768, 515);
			this.splitContainerControl3.SplitterPosition = 239;
			this.splitContainerControl3.TabIndex = 0;
			this.splitContainerControl3.Text = "splitContainerControl3";
			// 
			// groupControl_MealLogin
			// 
			this.groupControl_MealLogin.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_MealLogin.AppearanceCaption.Options.UseFont = true;
			this.groupControl_MealLogin.Controls.Add(this.notePanel_MealArr);
			this.groupControl_MealLogin.Controls.Add(this.checkEdit_Snack);
			this.groupControl_MealLogin.Controls.Add(this.checkEdit_Dinner);
			this.groupControl_MealLogin.Controls.Add(this.checkEdit_Lunch);
			this.groupControl_MealLogin.Controls.Add(this.checkEdit_Breakfast);
			this.groupControl_MealLogin.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_MealLogin.Location = new System.Drawing.Point(0, 152);
			this.groupControl_MealLogin.Name = "groupControl_MealLogin";
			this.groupControl_MealLogin.Size = new System.Drawing.Size(233, 144);
			this.groupControl_MealLogin.TabIndex = 1;
			this.groupControl_MealLogin.Text = "用餐登记";
			// 
			// notePanel_MealArr
			// 
			this.notePanel_MealArr.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel_MealArr.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel_MealArr.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel_MealArr.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MealArr.Location = new System.Drawing.Point(3, 18);
			this.notePanel_MealArr.MaxRows = 5;
			this.notePanel_MealArr.Name = "notePanel_MealArr";
			this.notePanel_MealArr.ParentAutoHeight = true;
			this.notePanel_MealArr.Size = new System.Drawing.Size(227, 23);
			this.notePanel_MealArr.TabIndex = 34;
			this.notePanel_MealArr.TabStop = false;
			this.notePanel_MealArr.Text = "添加您的膳食安排";
			// 
			// checkEdit_Snack
			// 
			this.checkEdit_Snack.Location = new System.Drawing.Point(128, 96);
			this.checkEdit_Snack.Name = "checkEdit_Snack";
			// 
			// checkEdit_Snack.Properties
			// 
			this.checkEdit_Snack.Properties.Caption = "点心";
			this.checkEdit_Snack.Size = new System.Drawing.Size(56, 19);
			this.checkEdit_Snack.TabIndex = 3;
			// 
			// checkEdit_Dinner
			// 
			this.checkEdit_Dinner.Location = new System.Drawing.Point(48, 96);
			this.checkEdit_Dinner.Name = "checkEdit_Dinner";
			// 
			// checkEdit_Dinner.Properties
			// 
			this.checkEdit_Dinner.Properties.Caption = "晚餐";
			this.checkEdit_Dinner.Size = new System.Drawing.Size(56, 19);
			this.checkEdit_Dinner.TabIndex = 2;
			// 
			// checkEdit_Lunch
			// 
			this.checkEdit_Lunch.Location = new System.Drawing.Point(128, 64);
			this.checkEdit_Lunch.Name = "checkEdit_Lunch";
			// 
			// checkEdit_Lunch.Properties
			// 
			this.checkEdit_Lunch.Properties.Caption = "午餐";
			this.checkEdit_Lunch.Size = new System.Drawing.Size(56, 19);
			this.checkEdit_Lunch.TabIndex = 1;
			// 
			// checkEdit_Breakfast
			// 
			this.checkEdit_Breakfast.Location = new System.Drawing.Point(48, 64);
			this.checkEdit_Breakfast.Name = "checkEdit_Breakfast";
			// 
			// checkEdit_Breakfast.Properties
			// 
			this.checkEdit_Breakfast.Properties.Caption = "早餐";
			this.checkEdit_Breakfast.Size = new System.Drawing.Size(56, 19);
			this.checkEdit_Breakfast.TabIndex = 0;
			// 
			// groupControl_MealAdd
			// 
			this.groupControl_MealAdd.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_MealAdd.AppearanceCaption.Options.UseFont = true;
			this.groupControl_MealAdd.Controls.Add(this.textEdit_MealName);
			this.groupControl_MealAdd.Controls.Add(this.textEdit_MealRemark);
			this.groupControl_MealAdd.Controls.Add(this.notePanel_MealRemark);
			this.groupControl_MealAdd.Controls.Add(this.textEdit_MealID);
			this.groupControl_MealAdd.Controls.Add(this.notePanel_MealName);
			this.groupControl_MealAdd.Controls.Add(this.notePanel_MealNameAdd);
			this.groupControl_MealAdd.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_MealAdd.Location = new System.Drawing.Point(0, 0);
			this.groupControl_MealAdd.Name = "groupControl_MealAdd";
			this.groupControl_MealAdd.Size = new System.Drawing.Size(233, 152);
			this.groupControl_MealAdd.TabIndex = 0;
			this.groupControl_MealAdd.Text = "膳食添加";
			// 
			// textEdit_MealName
			// 
			this.textEdit_MealName.EditValue = "";
			this.textEdit_MealName.Location = new System.Drawing.Point(112, 64);
			this.textEdit_MealName.Name = "textEdit_MealName";
			this.textEdit_MealName.Size = new System.Drawing.Size(96, 23);
			this.textEdit_MealName.TabIndex = 38;
			// 
			// textEdit_MealRemark
			// 
			this.textEdit_MealRemark.EditValue = "";
			this.textEdit_MealRemark.Location = new System.Drawing.Point(112, 96);
			this.textEdit_MealRemark.Name = "textEdit_MealRemark";
			this.textEdit_MealRemark.Size = new System.Drawing.Size(96, 23);
			this.textEdit_MealRemark.TabIndex = 37;
			// 
			// notePanel_MealRemark
			// 
			this.notePanel_MealRemark.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MealRemark.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MealRemark.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MealRemark.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MealRemark.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MealRemark.Location = new System.Drawing.Point(24, 96);
			this.notePanel_MealRemark.MaxRows = 5;
			this.notePanel_MealRemark.Name = "notePanel_MealRemark";
			this.notePanel_MealRemark.ParentAutoHeight = true;
			this.notePanel_MealRemark.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MealRemark.TabIndex = 36;
			this.notePanel_MealRemark.TabStop = false;
			this.notePanel_MealRemark.Text = "膳食说明:";
			// 
			// textEdit_MealID
			// 
			this.textEdit_MealID.EditValue = "";
			this.textEdit_MealID.Location = new System.Drawing.Point(184, 64);
			this.textEdit_MealID.Name = "textEdit_MealID";
			// 
			// textEdit_MealID.Properties
			// 
			this.textEdit_MealID.Properties.AutoHeight = false;
			this.textEdit_MealID.Size = new System.Drawing.Size(8, 16);
			this.textEdit_MealID.TabIndex = 35;
			// 
			// notePanel_MealName
			// 
			this.notePanel_MealName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MealName.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MealName.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MealName.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MealName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MealName.Location = new System.Drawing.Point(24, 61);
			this.notePanel_MealName.MaxRows = 5;
			this.notePanel_MealName.Name = "notePanel_MealName";
			this.notePanel_MealName.ParentAutoHeight = true;
			this.notePanel_MealName.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MealName.TabIndex = 34;
			this.notePanel_MealName.TabStop = false;
			this.notePanel_MealName.Text = "膳食名称:";
			// 
			// notePanel_MealNameAdd
			// 
			this.notePanel_MealNameAdd.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel_MealNameAdd.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel_MealNameAdd.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel_MealNameAdd.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MealNameAdd.Location = new System.Drawing.Point(3, 18);
			this.notePanel_MealNameAdd.MaxRows = 5;
			this.notePanel_MealNameAdd.Name = "notePanel_MealNameAdd";
			this.notePanel_MealNameAdd.ParentAutoHeight = true;
			this.notePanel_MealNameAdd.Size = new System.Drawing.Size(227, 23);
			this.notePanel_MealNameAdd.TabIndex = 33;
			this.notePanel_MealNameAdd.TabStop = false;
			this.notePanel_MealNameAdd.Text = "添加您的膳食名称";
			// 
			// groupControl_MealArr
			// 
			this.groupControl_MealArr.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_MealArr.AppearanceCaption.Options.UseFont = true;
			this.groupControl_MealArr.Controls.Add(this.splitContainerControl4);
			this.groupControl_MealArr.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_MealArr.Location = new System.Drawing.Point(0, 312);
			this.groupControl_MealArr.Name = "groupControl_MealArr";
			this.groupControl_MealArr.Size = new System.Drawing.Size(519, 224);
			this.groupControl_MealArr.TabIndex = 2;
			this.groupControl_MealArr.Text = "膳食设置";
			this.groupControl_MealArr.Visible = false;
			// 
			// splitContainerControl4
			// 
			this.splitContainerControl4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl4.Location = new System.Drawing.Point(3, 18);
			this.splitContainerControl4.Name = "splitContainerControl4";
			this.splitContainerControl4.Panel1.Controls.Add(this.notePanel_GradeArr);
			this.splitContainerControl4.Panel1.Controls.Add(this.notePanel_MealArr_Grade);
			this.splitContainerControl4.Panel1.Controls.Add(this.checkEdit_MealArr_gThree);
			this.splitContainerControl4.Panel1.Controls.Add(this.notePanel_MealArr_Name);
			this.splitContainerControl4.Panel1.Controls.Add(this.checkEdit_MealArr_gTwo);
			this.splitContainerControl4.Panel1.Controls.Add(this.checkEdit_MealArr_gOne);
			this.splitContainerControl4.Panel1.Controls.Add(this.comboBoxEdit_MealArr_Name);
			this.splitContainerControl4.Panel1.Controls.Add(this.checkEdit_MealArr_gFour);
			this.splitContainerControl4.Panel1.Controls.Add(this.checkEdit_MealArr_gFive);
			this.splitContainerControl4.Panel1.Controls.Add(this.checkEdit_MealArr_IsUsed);
			this.splitContainerControl4.Panel1.Text = "splitContainerControl4_Panel1";
			this.splitContainerControl4.Panel2.Controls.Add(this.label_Lunch);
			this.splitContainerControl4.Panel2.Controls.Add(this.label_Snack);
			this.splitContainerControl4.Panel2.Controls.Add(this.label_Super);
			this.splitContainerControl4.Panel2.Controls.Add(this.label_Breakfast);
			this.splitContainerControl4.Panel2.Controls.Add(this.notePanel_MealArr_ePreview);
			this.splitContainerControl4.Panel2.Text = "splitContainerControl4_Panel2";
			this.splitContainerControl4.Size = new System.Drawing.Size(513, 203);
			this.splitContainerControl4.SplitterPosition = 242;
			this.splitContainerControl4.TabIndex = 0;
			this.splitContainerControl4.Text = "splitContainerControl4";
			// 
			// notePanel_GradeArr
			// 
			this.notePanel_GradeArr.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel_GradeArr.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel_GradeArr.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel_GradeArr.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_GradeArr.Location = new System.Drawing.Point(0, 0);
			this.notePanel_GradeArr.MaxRows = 5;
			this.notePanel_GradeArr.Name = "notePanel_GradeArr";
			this.notePanel_GradeArr.ParentAutoHeight = true;
			this.notePanel_GradeArr.Size = new System.Drawing.Size(236, 23);
			this.notePanel_GradeArr.TabIndex = 44;
			this.notePanel_GradeArr.TabStop = false;
			this.notePanel_GradeArr.Text = "膳食适用年级安排";
			// 
			// notePanel_MealArr_Grade
			// 
			this.notePanel_MealArr_Grade.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MealArr_Grade.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MealArr_Grade.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MealArr_Grade.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MealArr_Grade.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MealArr_Grade.Location = new System.Drawing.Point(16, 72);
			this.notePanel_MealArr_Grade.MaxRows = 5;
			this.notePanel_MealArr_Grade.Name = "notePanel_MealArr_Grade";
			this.notePanel_MealArr_Grade.ParentAutoHeight = true;
			this.notePanel_MealArr_Grade.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MealArr_Grade.TabIndex = 37;
			this.notePanel_MealArr_Grade.TabStop = false;
			this.notePanel_MealArr_Grade.Text = "适用年级:";
			// 
			// checkEdit_MealArr_gThree
			// 
			this.checkEdit_MealArr_gThree.Location = new System.Drawing.Point(112, 96);
			this.checkEdit_MealArr_gThree.Name = "checkEdit_MealArr_gThree";
			// 
			// checkEdit_MealArr_gThree.Properties
			// 
			this.checkEdit_MealArr_gThree.Properties.Caption = "中班";
			this.checkEdit_MealArr_gThree.Size = new System.Drawing.Size(56, 19);
			this.checkEdit_MealArr_gThree.TabIndex = 40;
			// 
			// notePanel_MealArr_Name
			// 
			this.notePanel_MealArr_Name.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MealArr_Name.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MealArr_Name.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MealArr_Name.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MealArr_Name.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MealArr_Name.Location = new System.Drawing.Point(16, 40);
			this.notePanel_MealArr_Name.MaxRows = 5;
			this.notePanel_MealArr_Name.Name = "notePanel_MealArr_Name";
			this.notePanel_MealArr_Name.ParentAutoHeight = true;
			this.notePanel_MealArr_Name.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MealArr_Name.TabIndex = 35;
			this.notePanel_MealArr_Name.TabStop = false;
			this.notePanel_MealArr_Name.Text = "餐次名称:";
			// 
			// checkEdit_MealArr_gTwo
			// 
			this.checkEdit_MealArr_gTwo.Location = new System.Drawing.Point(168, 72);
			this.checkEdit_MealArr_gTwo.Name = "checkEdit_MealArr_gTwo";
			// 
			// checkEdit_MealArr_gTwo.Properties
			// 
			this.checkEdit_MealArr_gTwo.Properties.Caption = "小班";
			this.checkEdit_MealArr_gTwo.Size = new System.Drawing.Size(48, 19);
			this.checkEdit_MealArr_gTwo.TabIndex = 39;
			// 
			// checkEdit_MealArr_gOne
			// 
			this.checkEdit_MealArr_gOne.Location = new System.Drawing.Point(112, 72);
			this.checkEdit_MealArr_gOne.Name = "checkEdit_MealArr_gOne";
			// 
			// checkEdit_MealArr_gOne.Properties
			// 
			this.checkEdit_MealArr_gOne.Properties.Caption = "托班";
			this.checkEdit_MealArr_gOne.Size = new System.Drawing.Size(56, 19);
			this.checkEdit_MealArr_gOne.TabIndex = 38;
			// 
			// comboBoxEdit_MealArr_Name
			// 
			this.comboBoxEdit_MealArr_Name.EditValue = "";
			this.comboBoxEdit_MealArr_Name.Location = new System.Drawing.Point(112, 40);
			this.comboBoxEdit_MealArr_Name.Name = "comboBoxEdit_MealArr_Name";
			// 
			// comboBoxEdit_MealArr_Name.Properties
			// 
			this.comboBoxEdit_MealArr_Name.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_MealArr_Name.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_MealArr_Name.Size = new System.Drawing.Size(104, 23);
			this.comboBoxEdit_MealArr_Name.TabIndex = 36;
			this.comboBoxEdit_MealArr_Name.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_MealArr_Name_SelectedIndexChanged);
			// 
			// checkEdit_MealArr_gFour
			// 
			this.checkEdit_MealArr_gFour.Location = new System.Drawing.Point(168, 96);
			this.checkEdit_MealArr_gFour.Name = "checkEdit_MealArr_gFour";
			// 
			// checkEdit_MealArr_gFour.Properties
			// 
			this.checkEdit_MealArr_gFour.Properties.Caption = "大班";
			this.checkEdit_MealArr_gFour.Size = new System.Drawing.Size(48, 19);
			this.checkEdit_MealArr_gFour.TabIndex = 41;
			// 
			// checkEdit_MealArr_gFive
			// 
			this.checkEdit_MealArr_gFive.Location = new System.Drawing.Point(112, 120);
			this.checkEdit_MealArr_gFive.Name = "checkEdit_MealArr_gFive";
			// 
			// checkEdit_MealArr_gFive.Properties
			// 
			this.checkEdit_MealArr_gFive.Properties.Caption = "特色班";
			this.checkEdit_MealArr_gFive.Size = new System.Drawing.Size(72, 19);
			this.checkEdit_MealArr_gFive.TabIndex = 42;
			// 
			// checkEdit_MealArr_IsUsed
			// 
			this.checkEdit_MealArr_IsUsed.Location = new System.Drawing.Point(112, 144);
			this.checkEdit_MealArr_IsUsed.Name = "checkEdit_MealArr_IsUsed";
			// 
			// checkEdit_MealArr_IsUsed.Properties
			// 
			this.checkEdit_MealArr_IsUsed.Properties.Caption = "是否启用";
			this.checkEdit_MealArr_IsUsed.Size = new System.Drawing.Size(72, 19);
			this.checkEdit_MealArr_IsUsed.TabIndex = 43;
			// 
			// label_Lunch
			// 
			this.label_Lunch.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label_Lunch.ForeColor = System.Drawing.Color.Tomato;
			this.label_Lunch.Location = new System.Drawing.Point(136, 56);
			this.label_Lunch.Name = "label_Lunch";
			this.label_Lunch.Size = new System.Drawing.Size(88, 24);
			this.label_Lunch.TabIndex = 53;
			this.label_Lunch.Text = "午餐:  35%";
			// 
			// label_Snack
			// 
			this.label_Snack.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label_Snack.ForeColor = System.Drawing.Color.Tomato;
			this.label_Snack.Location = new System.Drawing.Point(136, 104);
			this.label_Snack.Name = "label_Snack";
			this.label_Snack.Size = new System.Drawing.Size(88, 24);
			this.label_Snack.TabIndex = 52;
			this.label_Snack.Text = "点心:  15%";
			// 
			// label_Super
			// 
			this.label_Super.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label_Super.ForeColor = System.Drawing.Color.Tomato;
			this.label_Super.Location = new System.Drawing.Point(24, 104);
			this.label_Super.Name = "label_Super";
			this.label_Super.Size = new System.Drawing.Size(88, 24);
			this.label_Super.TabIndex = 51;
			this.label_Super.Text = "晚餐:  30%";
			// 
			// label_Breakfast
			// 
			this.label_Breakfast.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label_Breakfast.ForeColor = System.Drawing.Color.Tomato;
			this.label_Breakfast.Location = new System.Drawing.Point(24, 56);
			this.label_Breakfast.Name = "label_Breakfast";
			this.label_Breakfast.Size = new System.Drawing.Size(88, 24);
			this.label_Breakfast.TabIndex = 50;
			this.label_Breakfast.Text = "早餐:  20%";
			// 
			// notePanel_MealArr_ePreview
			// 
			this.notePanel_MealArr_ePreview.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel_MealArr_ePreview.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel_MealArr_ePreview.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel_MealArr_ePreview.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MealArr_ePreview.Location = new System.Drawing.Point(0, 0);
			this.notePanel_MealArr_ePreview.MaxRows = 5;
			this.notePanel_MealArr_ePreview.Name = "notePanel_MealArr_ePreview";
			this.notePanel_MealArr_ePreview.ParentAutoHeight = true;
			this.notePanel_MealArr_ePreview.Size = new System.Drawing.Size(261, 23);
			this.notePanel_MealArr_ePreview.TabIndex = 45;
			this.notePanel_MealArr_ePreview.TabStop = false;
			this.notePanel_MealArr_ePreview.Text = "热量分配一览";
			// 
			// groupControl_MealPreview
			// 
			this.groupControl_MealPreview.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_MealPreview.AppearanceCaption.Options.UseFont = true;
			this.groupControl_MealPreview.Controls.Add(this.gridControl_MealPreview);
			this.groupControl_MealPreview.Controls.Add(this.notePanel3);
			this.groupControl_MealPreview.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_MealPreview.Location = new System.Drawing.Point(0, 48);
			this.groupControl_MealPreview.Name = "groupControl_MealPreview";
			this.groupControl_MealPreview.Size = new System.Drawing.Size(519, 264);
			this.groupControl_MealPreview.TabIndex = 1;
			this.groupControl_MealPreview.Text = "餐次设置一览";
			// 
			// gridControl_MealPreview
			// 
			this.gridControl_MealPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl_MealPreview.EmbeddedNavigator
			// 
			this.gridControl_MealPreview.EmbeddedNavigator.Name = "";
			this.gridControl_MealPreview.Location = new System.Drawing.Point(3, 41);
			this.gridControl_MealPreview.MainView = this.gridView5;
			this.gridControl_MealPreview.Name = "gridControl_MealPreview";
			this.barManager1.SetPopupContextMenu(this.gridControl_MealPreview, this.popupMenu1);
			this.gridControl_MealPreview.Size = new System.Drawing.Size(513, 220);
			this.gridControl_MealPreview.TabIndex = 36;
			this.gridControl_MealPreview.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																												   this.gridView5});
			this.gridControl_MealPreview.DoubleClick += new System.EventHandler(this.gridControl_MealPreview_DoubleClick);
			// 
			// gridView5
			// 
			this.gridView5.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn17,
																							 this.gridColumn18,
																							 this.gridColumn19,
																							 this.gridColumn20});
			this.gridView5.GridControl = this.gridControl_MealPreview;
			this.gridView5.Name = "gridView5";
			this.gridView5.OptionsCustomization.AllowFilter = false;
			this.gridView5.OptionsView.ShowFilterPanel = false;
			this.gridView5.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn17
			// 
			this.gridColumn17.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn17.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn17.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn17.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn17.Caption = "膳食名称";
			this.gridColumn17.FieldName = "FoodArr_Name";
			this.gridColumn17.Name = "gridColumn17";
			this.gridColumn17.OptionsColumn.AllowEdit = false;
			this.gridColumn17.OptionsColumn.AllowFocus = false;
			this.gridColumn17.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn17.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn17.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn17.OptionsColumn.AllowMove = false;
			this.gridColumn17.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn17.OptionsColumn.ReadOnly = true;
			this.gridColumn17.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn17.Visible = true;
			this.gridColumn17.VisibleIndex = 0;
			this.gridColumn17.Width = 92;
			// 
			// gridColumn18
			// 
			this.gridColumn18.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn18.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn18.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn18.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn18.Caption = "膳食说明";
			this.gridColumn18.FieldName = "FoodArr_Remark";
			this.gridColumn18.Name = "gridColumn18";
			this.gridColumn18.OptionsColumn.AllowEdit = false;
			this.gridColumn18.OptionsColumn.AllowFocus = false;
			this.gridColumn18.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn18.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn18.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn18.OptionsColumn.AllowMove = false;
			this.gridColumn18.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn18.OptionsColumn.ReadOnly = true;
			this.gridColumn18.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn18.Visible = true;
			this.gridColumn18.VisibleIndex = 1;
			this.gridColumn18.Width = 188;
			// 
			// gridColumn19
			// 
			this.gridColumn19.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn19.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn19.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn19.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn19.Caption = "适用年级";
			this.gridColumn19.FieldName = "FoodArr_SuitAge";
			this.gridColumn19.Name = "gridColumn19";
			this.gridColumn19.OptionsColumn.AllowEdit = false;
			this.gridColumn19.OptionsColumn.AllowFocus = false;
			this.gridColumn19.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn19.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn19.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn19.OptionsColumn.AllowMove = false;
			this.gridColumn19.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn19.OptionsColumn.ReadOnly = true;
			this.gridColumn19.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn19.Visible = true;
			this.gridColumn19.VisibleIndex = 2;
			this.gridColumn19.Width = 163;
			// 
			// gridColumn20
			// 
			this.gridColumn20.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn20.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn20.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn20.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn20.Caption = "是否起用";
			this.gridColumn20.FieldName = "FoodArr_ISUsed";
			this.gridColumn20.Name = "gridColumn20";
			this.gridColumn20.OptionsColumn.AllowEdit = false;
			this.gridColumn20.OptionsColumn.AllowFocus = false;
			this.gridColumn20.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn20.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn20.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn20.OptionsColumn.AllowMove = false;
			this.gridColumn20.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn20.OptionsColumn.ReadOnly = true;
			this.gridColumn20.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn20.Visible = true;
			this.gridColumn20.VisibleIndex = 3;
			this.gridColumn20.Width = 55;
			// 
			// notePanel3
			// 
			this.notePanel3.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel3.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel3.Location = new System.Drawing.Point(3, 18);
			this.notePanel3.MaxRows = 5;
			this.notePanel3.Name = "notePanel3";
			this.notePanel3.ParentAutoHeight = true;
			this.notePanel3.Size = new System.Drawing.Size(513, 23);
			this.notePanel3.TabIndex = 35;
			this.notePanel3.TabStop = false;
			this.notePanel3.Text = "双击进行幼儿餐适用年级登记";
			// 
			// panelControl3
			// 
			this.panelControl3.Controls.Add(this.simpleButton_MealBack);
			this.panelControl3.Controls.Add(this.simpleButton_MealAppend);
			this.panelControl3.Controls.Add(this.simpleButton_MealDelete);
			this.panelControl3.Controls.Add(this.simpleButton_MealSave);
			this.panelControl3.Controls.Add(this.simpleButton_MealAdd);
			this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl3.Location = new System.Drawing.Point(0, 0);
			this.panelControl3.Name = "panelControl3";
			this.panelControl3.Size = new System.Drawing.Size(519, 48);
			this.panelControl3.TabIndex = 0;
			this.panelControl3.Text = "panelControl3";
			// 
			// simpleButton_MealBack
			// 
			this.simpleButton_MealBack.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_MealBack.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_MealBack.Appearance.Options.UseFont = true;
			this.simpleButton_MealBack.Appearance.Options.UseForeColor = true;
			this.simpleButton_MealBack.Location = new System.Drawing.Point(8, 8);
			this.simpleButton_MealBack.Name = "simpleButton_MealBack";
			this.simpleButton_MealBack.Size = new System.Drawing.Size(72, 26);
			this.simpleButton_MealBack.TabIndex = 47;
			this.simpleButton_MealBack.Tag = 4;
			this.simpleButton_MealBack.Text = "返回";
			this.simpleButton_MealBack.Click += new System.EventHandler(this.simpleButton_MealBack_Click);
			// 
			// simpleButton_MealAppend
			// 
			this.simpleButton_MealAppend.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_MealAppend.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_MealAppend.Appearance.Options.UseFont = true;
			this.simpleButton_MealAppend.Appearance.Options.UseForeColor = true;
			this.simpleButton_MealAppend.Location = new System.Drawing.Point(88, 8);
			this.simpleButton_MealAppend.Name = "simpleButton_MealAppend";
			this.simpleButton_MealAppend.Size = new System.Drawing.Size(72, 26);
			this.simpleButton_MealAppend.TabIndex = 46;
			this.simpleButton_MealAppend.Tag = 4;
			this.simpleButton_MealAppend.Text = "新建膳食";
			this.simpleButton_MealAppend.Click += new System.EventHandler(this.simpleButton_MealAppend_Click);
			// 
			// simpleButton_MealDelete
			// 
			this.simpleButton_MealDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_MealDelete.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_MealDelete.Appearance.Options.UseFont = true;
			this.simpleButton_MealDelete.Appearance.Options.UseForeColor = true;
			this.simpleButton_MealDelete.Location = new System.Drawing.Point(248, 8);
			this.simpleButton_MealDelete.Name = "simpleButton_MealDelete";
			this.simpleButton_MealDelete.Size = new System.Drawing.Size(72, 26);
			this.simpleButton_MealDelete.TabIndex = 45;
			this.simpleButton_MealDelete.Tag = 4;
			this.simpleButton_MealDelete.Text = "膳食删除";
			this.simpleButton_MealDelete.Click += new System.EventHandler(this.simpleButton_MealDelete_Click);
			// 
			// simpleButton_MealSave
			// 
			this.simpleButton_MealSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_MealSave.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_MealSave.Appearance.Options.UseFont = true;
			this.simpleButton_MealSave.Appearance.Options.UseForeColor = true;
			this.simpleButton_MealSave.Enabled = false;
			this.simpleButton_MealSave.Location = new System.Drawing.Point(328, 8);
			this.simpleButton_MealSave.Name = "simpleButton_MealSave";
			this.simpleButton_MealSave.Size = new System.Drawing.Size(80, 26);
			this.simpleButton_MealSave.TabIndex = 43;
			this.simpleButton_MealSave.Tag = 4;
			this.simpleButton_MealSave.Text = "幼儿餐保存";
			this.simpleButton_MealSave.Click += new System.EventHandler(this.simpleButton_MealSave_Click);
			// 
			// simpleButton_MealAdd
			// 
			this.simpleButton_MealAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_MealAdd.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_MealAdd.Appearance.Options.UseFont = true;
			this.simpleButton_MealAdd.Appearance.Options.UseForeColor = true;
			this.simpleButton_MealAdd.Location = new System.Drawing.Point(168, 8);
			this.simpleButton_MealAdd.Name = "simpleButton_MealAdd";
			this.simpleButton_MealAdd.Size = new System.Drawing.Size(72, 26);
			this.simpleButton_MealAdd.TabIndex = 41;
			this.simpleButton_MealAdd.Tag = 4;
			this.simpleButton_MealAdd.Text = "膳食保存";
			this.simpleButton_MealAdd.Click += new System.EventHandler(this.simpleButton_MealAdd_Click);
			// 
			// xtraTabPage4
			// 
			this.xtraTabPage4.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
			this.xtraTabPage4.Appearance.PageClient.Options.UseBackColor = true;
			this.xtraTabPage4.Controls.Add(this.splitContainerControl5);
			this.xtraTabPage4.Name = "xtraTabPage4";
			this.xtraTabPage4.PageVisible = false;
			this.xtraTabPage4.Size = new System.Drawing.Size(768, 515);
			this.xtraTabPage4.Text = "膳食营养综合统计表";
			// 
			// splitContainerControl5
			// 
			this.splitContainerControl5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl5.Location = new System.Drawing.Point(0, 0);
			this.splitContainerControl5.Name = "splitContainerControl5";
			this.splitContainerControl5.Panel1.Controls.Add(this.groupControl_Meal_Search);
			this.splitContainerControl5.Panel1.Text = "splitContainerControl5_Panel1";
			this.splitContainerControl5.Panel2.Controls.Add(this.groupControl_Meal_ReportPreview);
			this.splitContainerControl5.Panel2.Controls.Add(this.panelControl4);
			this.splitContainerControl5.Panel2.Text = "splitContainerControl5_Panel2";
			this.splitContainerControl5.Size = new System.Drawing.Size(768, 515);
			this.splitContainerControl5.SplitterPosition = 241;
			this.splitContainerControl5.TabIndex = 0;
			this.splitContainerControl5.Text = "splitContainerControl5";
			// 
			// groupControl_Meal_Search
			// 
			this.groupControl_Meal_Search.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_Meal_Search.AppearanceCaption.Options.UseFont = true;
			this.groupControl_Meal_Search.Controls.Add(this.dateEdit_Meal_EndDate);
			this.groupControl_Meal_Search.Controls.Add(this.notePanel_Meal_EndDate);
			this.groupControl_Meal_Search.Controls.Add(this.dateEdit_Meal_BegDate);
			this.groupControl_Meal_Search.Controls.Add(this.notePanel_Meal_BegDate);
			this.groupControl_Meal_Search.Controls.Add(this.notePanel_Meal_Search);
			this.groupControl_Meal_Search.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_Meal_Search.Location = new System.Drawing.Point(0, 0);
			this.groupControl_Meal_Search.Name = "groupControl_Meal_Search";
			this.groupControl_Meal_Search.Size = new System.Drawing.Size(235, 176);
			this.groupControl_Meal_Search.TabIndex = 0;
			this.groupControl_Meal_Search.Text = "统计条件";
			// 
			// dateEdit_Meal_EndDate
			// 
			this.dateEdit_Meal_EndDate.EditValue = new System.DateTime(2005, 11, 24, 0, 0, 0, 0);
			this.dateEdit_Meal_EndDate.Location = new System.Drawing.Point(112, 104);
			this.dateEdit_Meal_EndDate.Name = "dateEdit_Meal_EndDate";
			// 
			// dateEdit_Meal_EndDate.Properties
			// 
			this.dateEdit_Meal_EndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																														  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit_Meal_EndDate.Properties.Mask.EditMask = "d";
			this.dateEdit_Meal_EndDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
			this.dateEdit_Meal_EndDate.Size = new System.Drawing.Size(88, 23);
			this.dateEdit_Meal_EndDate.TabIndex = 38;
			// 
			// notePanel_Meal_EndDate
			// 
			this.notePanel_Meal_EndDate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_Meal_EndDate.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_Meal_EndDate.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_Meal_EndDate.ForeColor = System.Drawing.Color.Black;
			this.notePanel_Meal_EndDate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Meal_EndDate.Location = new System.Drawing.Point(24, 104);
			this.notePanel_Meal_EndDate.MaxRows = 5;
			this.notePanel_Meal_EndDate.Name = "notePanel_Meal_EndDate";
			this.notePanel_Meal_EndDate.ParentAutoHeight = true;
			this.notePanel_Meal_EndDate.Size = new System.Drawing.Size(80, 22);
			this.notePanel_Meal_EndDate.TabIndex = 37;
			this.notePanel_Meal_EndDate.TabStop = false;
			this.notePanel_Meal_EndDate.Text = "截止日期:";
			// 
			// dateEdit_Meal_BegDate
			// 
			this.dateEdit_Meal_BegDate.EditValue = new System.DateTime(2005, 11, 24, 0, 0, 0, 0);
			this.dateEdit_Meal_BegDate.Location = new System.Drawing.Point(112, 64);
			this.dateEdit_Meal_BegDate.Name = "dateEdit_Meal_BegDate";
			// 
			// dateEdit_Meal_BegDate.Properties
			// 
			this.dateEdit_Meal_BegDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																														  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit_Meal_BegDate.Properties.Mask.EditMask = "d";
			this.dateEdit_Meal_BegDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
			this.dateEdit_Meal_BegDate.Size = new System.Drawing.Size(88, 23);
			this.dateEdit_Meal_BegDate.TabIndex = 36;
			// 
			// notePanel_Meal_BegDate
			// 
			this.notePanel_Meal_BegDate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_Meal_BegDate.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_Meal_BegDate.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_Meal_BegDate.ForeColor = System.Drawing.Color.Black;
			this.notePanel_Meal_BegDate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Meal_BegDate.Location = new System.Drawing.Point(24, 64);
			this.notePanel_Meal_BegDate.MaxRows = 5;
			this.notePanel_Meal_BegDate.Name = "notePanel_Meal_BegDate";
			this.notePanel_Meal_BegDate.ParentAutoHeight = true;
			this.notePanel_Meal_BegDate.Size = new System.Drawing.Size(80, 22);
			this.notePanel_Meal_BegDate.TabIndex = 35;
			this.notePanel_Meal_BegDate.TabStop = false;
			this.notePanel_Meal_BegDate.Text = "起始日期:";
			// 
			// notePanel_Meal_Search
			// 
			this.notePanel_Meal_Search.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel_Meal_Search.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel_Meal_Search.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel_Meal_Search.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_Meal_Search.Location = new System.Drawing.Point(3, 18);
			this.notePanel_Meal_Search.MaxRows = 5;
			this.notePanel_Meal_Search.Name = "notePanel_Meal_Search";
			this.notePanel_Meal_Search.ParentAutoHeight = true;
			this.notePanel_Meal_Search.Size = new System.Drawing.Size(229, 23);
			this.notePanel_Meal_Search.TabIndex = 34;
			this.notePanel_Meal_Search.TabStop = false;
			this.notePanel_Meal_Search.Text = "指定统计的时间范围";
			// 
			// groupControl_Meal_ReportPreview
			// 
			this.groupControl_Meal_ReportPreview.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_Meal_ReportPreview.AppearanceCaption.Options.UseFont = true;
			this.groupControl_Meal_ReportPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl_Meal_ReportPreview.Location = new System.Drawing.Point(0, 48);
			this.groupControl_Meal_ReportPreview.Name = "groupControl_Meal_ReportPreview";
			this.groupControl_Meal_ReportPreview.Size = new System.Drawing.Size(517, 461);
			this.groupControl_Meal_ReportPreview.TabIndex = 1;
			this.groupControl_Meal_ReportPreview.Text = "图形报表预览";
			// 
			// panelControl4
			// 
			this.panelControl4.Controls.Add(this.simpleButton_Meal_PrintReport);
			this.panelControl4.Controls.Add(this.simpleButton_Meal_PreviewReport);
			this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl4.Location = new System.Drawing.Point(0, 0);
			this.panelControl4.Name = "panelControl4";
			this.panelControl4.Size = new System.Drawing.Size(517, 48);
			this.panelControl4.TabIndex = 0;
			this.panelControl4.Text = "panelControl4";
			// 
			// simpleButton_Meal_PrintReport
			// 
			this.simpleButton_Meal_PrintReport.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_Meal_PrintReport.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_Meal_PrintReport.Appearance.Options.UseFont = true;
			this.simpleButton_Meal_PrintReport.Appearance.Options.UseForeColor = true;
			this.simpleButton_Meal_PrintReport.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_Meal_PrintReport.Image")));
			this.simpleButton_Meal_PrintReport.Location = new System.Drawing.Point(128, 11);
			this.simpleButton_Meal_PrintReport.Name = "simpleButton_Meal_PrintReport";
			this.simpleButton_Meal_PrintReport.Size = new System.Drawing.Size(96, 26);
			this.simpleButton_Meal_PrintReport.TabIndex = 7;
			this.simpleButton_Meal_PrintReport.Tag = 4;
			this.simpleButton_Meal_PrintReport.Text = "图形打印";
			// 
			// simpleButton_Meal_PreviewReport
			// 
			this.simpleButton_Meal_PreviewReport.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_Meal_PreviewReport.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_Meal_PreviewReport.Appearance.Options.UseFont = true;
			this.simpleButton_Meal_PreviewReport.Appearance.Options.UseForeColor = true;
			this.simpleButton_Meal_PreviewReport.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_Meal_PreviewReport.Image")));
			this.simpleButton_Meal_PreviewReport.Location = new System.Drawing.Point(16, 11);
			this.simpleButton_Meal_PreviewReport.Name = "simpleButton_Meal_PreviewReport";
			this.simpleButton_Meal_PreviewReport.Size = new System.Drawing.Size(92, 26);
			this.simpleButton_Meal_PreviewReport.TabIndex = 6;
			this.simpleButton_Meal_PreviewReport.Tag = 4;
			this.simpleButton_Meal_PreviewReport.Text = "报  表";
			this.simpleButton_Meal_PreviewReport.Click += new System.EventHandler(this.simpleButton_Meal_PreviewReport_Click);
			// 
			// xtraTabPage5
			// 
			this.xtraTabPage5.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
			this.xtraTabPage5.Appearance.PageClient.Options.UseBackColor = true;
			this.xtraTabPage5.Controls.Add(this.splitContainerControl6);
			this.xtraTabPage5.Name = "xtraTabPage5";
			this.xtraTabPage5.Size = new System.Drawing.Size(768, 515);
			this.xtraTabPage5.Text = "幼儿身体评测登记";
			// 
			// splitContainerControl6
			// 
			this.splitContainerControl6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl6.Location = new System.Drawing.Point(0, 0);
			this.splitContainerControl6.Name = "splitContainerControl6";
			this.splitContainerControl6.Panel1.Controls.Add(this.gridControl_HInputStu);
			this.splitContainerControl6.Panel1.Controls.Add(this.groupControl_HInputSer);
			this.splitContainerControl6.Panel1.Text = "splitContainerControl6_Panel1";
			this.splitContainerControl6.Panel2.Controls.Add(this.groupControl_HInputDiagInfo);
			this.splitContainerControl6.Panel2.Controls.Add(this.panelControl5);
			this.splitContainerControl6.Panel2.Text = "splitContainerControl6_Panel2";
			this.splitContainerControl6.Size = new System.Drawing.Size(768, 515);
			this.splitContainerControl6.SplitterPosition = 204;
			this.splitContainerControl6.TabIndex = 0;
			this.splitContainerControl6.Text = "splitContainerControl6";
			// 
			// gridControl_HInputStu
			// 
			this.gridControl_HInputStu.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl_HInputStu.EmbeddedNavigator
			// 
			this.gridControl_HInputStu.EmbeddedNavigator.Name = "";
			this.gridControl_HInputStu.Location = new System.Drawing.Point(0, 256);
			this.gridControl_HInputStu.MainView = this.gridView6;
			this.gridControl_HInputStu.Name = "gridControl_HInputStu";
			this.gridControl_HInputStu.Size = new System.Drawing.Size(198, 253);
			this.gridControl_HInputStu.TabIndex = 1;
			this.gridControl_HInputStu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																												 this.gridView6});
			this.gridControl_HInputStu.DoubleClick += new System.EventHandler(this.gridControl_HInputStu_DoubleClick);
			// 
			// gridView6
			// 
			this.gridView6.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn21,
																							 this.gridColumn22,
																							 this.gridColumn23});
			this.gridView6.GridControl = this.gridControl_HInputStu;
			this.gridView6.Name = "gridView6";
			this.gridView6.OptionsCustomization.AllowFilter = false;
			this.gridView6.OptionsView.ShowFilterPanel = false;
			this.gridView6.OptionsView.ShowGroupPanel = false;
			this.gridView6.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView6_FocusedRowChanged);
			// 
			// gridColumn21
			// 
			this.gridColumn21.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn21.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn21.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn21.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn21.Caption = "学号";
			this.gridColumn21.FieldName = "info_stuNumber";
			this.gridColumn21.Name = "gridColumn21";
			this.gridColumn21.OptionsColumn.AllowEdit = false;
			this.gridColumn21.OptionsColumn.AllowFocus = false;
			this.gridColumn21.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn21.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn21.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn21.OptionsColumn.AllowMove = false;
			this.gridColumn21.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn21.OptionsColumn.ReadOnly = true;
			this.gridColumn21.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn21.Visible = true;
			this.gridColumn21.VisibleIndex = 0;
			this.gridColumn21.Width = 62;
			// 
			// gridColumn22
			// 
			this.gridColumn22.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn22.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn22.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn22.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn22.Caption = "姓名";
			this.gridColumn22.FieldName = "info_stuName";
			this.gridColumn22.Name = "gridColumn22";
			this.gridColumn22.OptionsColumn.AllowEdit = false;
			this.gridColumn22.OptionsColumn.AllowFocus = false;
			this.gridColumn22.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn22.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn22.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn22.OptionsColumn.AllowMove = false;
			this.gridColumn22.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn22.OptionsColumn.ReadOnly = true;
			this.gridColumn22.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn22.Visible = true;
			this.gridColumn22.VisibleIndex = 1;
			this.gridColumn22.Width = 58;
			// 
			// gridColumn23
			// 
			this.gridColumn23.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn23.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn23.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn23.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn23.Caption = "班级";
			this.gridColumn23.FieldName = "info_className";
			this.gridColumn23.Name = "gridColumn23";
			this.gridColumn23.OptionsColumn.AllowEdit = false;
			this.gridColumn23.OptionsColumn.AllowFocus = false;
			this.gridColumn23.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn23.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn23.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn23.OptionsColumn.AllowMove = false;
			this.gridColumn23.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn23.OptionsColumn.ReadOnly = true;
			this.gridColumn23.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn23.Visible = true;
			this.gridColumn23.VisibleIndex = 2;
			this.gridColumn23.Width = 61;
			// 
			// groupControl_HInputSer
			// 
			this.groupControl_HInputSer.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_HInputSer.AppearanceCaption.Options.UseFont = true;
			this.groupControl_HInputSer.Controls.Add(this.comboBoxEdit_HInputGender);
			this.groupControl_HInputSer.Controls.Add(this.notePanel_HInputGender);
			this.groupControl_HInputSer.Controls.Add(this.dataNavigator_HInputNav);
			this.groupControl_HInputSer.Controls.Add(this.textEdit_HInputNumber);
			this.groupControl_HInputSer.Controls.Add(this.textEdit_HInputName);
			this.groupControl_HInputSer.Controls.Add(this.comboBoxEdit_HInputClass);
			this.groupControl_HInputSer.Controls.Add(this.notePanel_HInputClass);
			this.groupControl_HInputSer.Controls.Add(this.comboBoxEdit_HInputGrade);
			this.groupControl_HInputSer.Controls.Add(this.notePanel_HInputGrade);
			this.groupControl_HInputSer.Controls.Add(this.notePanel_HInputSer);
			this.groupControl_HInputSer.Controls.Add(this.notePanel_HInputNumber);
			this.groupControl_HInputSer.Controls.Add(this.notePanel_HInputName);
			this.groupControl_HInputSer.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_HInputSer.Location = new System.Drawing.Point(0, 0);
			this.groupControl_HInputSer.Name = "groupControl_HInputSer";
			this.groupControl_HInputSer.Size = new System.Drawing.Size(198, 256);
			this.groupControl_HInputSer.TabIndex = 0;
			this.groupControl_HInputSer.Text = "信息查询";
			// 
			// comboBoxEdit_HInputGender
			// 
			this.comboBoxEdit_HInputGender.EditValue = "全部";
			this.comboBoxEdit_HInputGender.Location = new System.Drawing.Point(88, 184);
			this.comboBoxEdit_HInputGender.Name = "comboBoxEdit_HInputGender";
			// 
			// comboBoxEdit_HInputGender.Properties
			// 
			this.comboBoxEdit_HInputGender.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_HInputGender.Properties.Items.AddRange(new object[] {
																					  "全部",
																					  "男",
																					  "女"});
			this.comboBoxEdit_HInputGender.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_HInputGender.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_HInputGender.TabIndex = 45;
			this.comboBoxEdit_HInputGender.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_HInputGender_SelectedIndexChanged);
			// 
			// notePanel_HInputGender
			// 
			this.notePanel_HInputGender.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_HInputGender.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_HInputGender.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_HInputGender.ForeColor = System.Drawing.Color.Black;
			this.notePanel_HInputGender.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_HInputGender.Location = new System.Drawing.Point(16, 184);
			this.notePanel_HInputGender.MaxRows = 5;
			this.notePanel_HInputGender.Name = "notePanel_HInputGender";
			this.notePanel_HInputGender.ParentAutoHeight = true;
			this.notePanel_HInputGender.Size = new System.Drawing.Size(64, 22);
			this.notePanel_HInputGender.TabIndex = 43;
			this.notePanel_HInputGender.TabStop = false;
			this.notePanel_HInputGender.Text = "性  别:";
			// 
			// dataNavigator_HInputNav
			// 
			this.dataNavigator_HInputNav.Buttons.Append.Hint = "新建卡";
			this.dataNavigator_HInputNav.Buttons.Append.Visible = false;
			this.dataNavigator_HInputNav.Buttons.CancelEdit.Visible = false;
			this.dataNavigator_HInputNav.Buttons.EndEdit.Visible = false;
			this.dataNavigator_HInputNav.Buttons.First.Hint = "第一条记录";
			this.dataNavigator_HInputNav.Buttons.Last.Hint = "最后一条记录";
			this.dataNavigator_HInputNav.Buttons.Next.Hint = "下一条记录";
			this.dataNavigator_HInputNav.Buttons.NextPage.Visible = false;
			this.dataNavigator_HInputNav.Buttons.Prev.Hint = "上一条记录";
			this.dataNavigator_HInputNav.Buttons.PrevPage.Visible = false;
			this.dataNavigator_HInputNav.Buttons.Remove.Visible = false;
			this.dataNavigator_HInputNav.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dataNavigator_HInputNav.Location = new System.Drawing.Point(3, 225);
			this.dataNavigator_HInputNav.Name = "dataNavigator_HInputNav";
			this.dataNavigator_HInputNav.ShowToolTips = true;
			this.dataNavigator_HInputNav.Size = new System.Drawing.Size(192, 28);
			this.dataNavigator_HInputNav.TabIndex = 41;
			this.dataNavigator_HInputNav.Text = "dataNavigator1";
			this.dataNavigator_HInputNav.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.End;
			// 
			// textEdit_HInputNumber
			// 
			this.textEdit_HInputNumber.EditValue = "";
			this.textEdit_HInputNumber.Location = new System.Drawing.Point(88, 152);
			this.textEdit_HInputNumber.Name = "textEdit_HInputNumber";
			this.textEdit_HInputNumber.Size = new System.Drawing.Size(88, 23);
			this.textEdit_HInputNumber.TabIndex = 40;
			this.textEdit_HInputNumber.EditValueChanged += new System.EventHandler(this.textEdit_HInputNumber_EditValueChanged);
			// 
			// textEdit_HInputName
			// 
			this.textEdit_HInputName.EditValue = "";
			this.textEdit_HInputName.Location = new System.Drawing.Point(88, 120);
			this.textEdit_HInputName.Name = "textEdit_HInputName";
			this.textEdit_HInputName.Size = new System.Drawing.Size(88, 23);
			this.textEdit_HInputName.TabIndex = 39;
			this.textEdit_HInputName.EditValueChanged += new System.EventHandler(this.textEdit_HInputName_EditValueChanged);
			// 
			// comboBoxEdit_HInputClass
			// 
			this.comboBoxEdit_HInputClass.EditValue = "全部";
			this.comboBoxEdit_HInputClass.Location = new System.Drawing.Point(88, 88);
			this.comboBoxEdit_HInputClass.Name = "comboBoxEdit_HInputClass";
			// 
			// comboBoxEdit_HInputClass.Properties
			// 
			this.comboBoxEdit_HInputClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_HInputClass.Properties.Items.AddRange(new object[] {
																					 "全部"});
			this.comboBoxEdit_HInputClass.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_HInputClass.TabIndex = 38;
			this.comboBoxEdit_HInputClass.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_HInputClass_SelectedIndexChanged);
			// 
			// notePanel_HInputClass
			// 
			this.notePanel_HInputClass.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_HInputClass.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_HInputClass.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_HInputClass.ForeColor = System.Drawing.Color.Black;
			this.notePanel_HInputClass.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_HInputClass.Location = new System.Drawing.Point(16, 88);
			this.notePanel_HInputClass.MaxRows = 5;
			this.notePanel_HInputClass.Name = "notePanel_HInputClass";
			this.notePanel_HInputClass.ParentAutoHeight = true;
			this.notePanel_HInputClass.Size = new System.Drawing.Size(64, 22);
			this.notePanel_HInputClass.TabIndex = 37;
			this.notePanel_HInputClass.TabStop = false;
			this.notePanel_HInputClass.Text = "班  级:";
			// 
			// comboBoxEdit_HInputGrade
			// 
			this.comboBoxEdit_HInputGrade.EditValue = "全部";
			this.comboBoxEdit_HInputGrade.Location = new System.Drawing.Point(88, 56);
			this.comboBoxEdit_HInputGrade.Name = "comboBoxEdit_HInputGrade";
			// 
			// comboBoxEdit_HInputGrade.Properties
			// 
			this.comboBoxEdit_HInputGrade.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_HInputGrade.Properties.Items.AddRange(new object[] {
																					 "全部"});
			this.comboBoxEdit_HInputGrade.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_HInputGrade.TabIndex = 36;
			this.comboBoxEdit_HInputGrade.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_HInputGrade_SelectedIndexChanged);
			// 
			// notePanel_HInputGrade
			// 
			this.notePanel_HInputGrade.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_HInputGrade.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_HInputGrade.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_HInputGrade.ForeColor = System.Drawing.Color.Black;
			this.notePanel_HInputGrade.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_HInputGrade.Location = new System.Drawing.Point(16, 56);
			this.notePanel_HInputGrade.MaxRows = 5;
			this.notePanel_HInputGrade.Name = "notePanel_HInputGrade";
			this.notePanel_HInputGrade.ParentAutoHeight = true;
			this.notePanel_HInputGrade.Size = new System.Drawing.Size(64, 22);
			this.notePanel_HInputGrade.TabIndex = 35;
			this.notePanel_HInputGrade.TabStop = false;
			this.notePanel_HInputGrade.Text = "年  级:";
			// 
			// notePanel_HInputSer
			// 
			this.notePanel_HInputSer.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel_HInputSer.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel_HInputSer.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel_HInputSer.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_HInputSer.Location = new System.Drawing.Point(3, 18);
			this.notePanel_HInputSer.MaxRows = 5;
			this.notePanel_HInputSer.Name = "notePanel_HInputSer";
			this.notePanel_HInputSer.ParentAutoHeight = true;
			this.notePanel_HInputSer.Size = new System.Drawing.Size(192, 23);
			this.notePanel_HInputSer.TabIndex = 23;
			this.notePanel_HInputSer.TabStop = false;
			this.notePanel_HInputSer.Text = "检索您的幼儿";
			// 
			// notePanel_HInputNumber
			// 
			this.notePanel_HInputNumber.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_HInputNumber.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_HInputNumber.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_HInputNumber.ForeColor = System.Drawing.Color.Black;
			this.notePanel_HInputNumber.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_HInputNumber.Location = new System.Drawing.Point(16, 152);
			this.notePanel_HInputNumber.MaxRows = 5;
			this.notePanel_HInputNumber.Name = "notePanel_HInputNumber";
			this.notePanel_HInputNumber.ParentAutoHeight = true;
			this.notePanel_HInputNumber.Size = new System.Drawing.Size(64, 22);
			this.notePanel_HInputNumber.TabIndex = 32;
			this.notePanel_HInputNumber.TabStop = false;
			this.notePanel_HInputNumber.Text = "学  号:";
			// 
			// notePanel_HInputName
			// 
			this.notePanel_HInputName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_HInputName.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_HInputName.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_HInputName.ForeColor = System.Drawing.Color.Black;
			this.notePanel_HInputName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_HInputName.Location = new System.Drawing.Point(16, 120);
			this.notePanel_HInputName.MaxRows = 5;
			this.notePanel_HInputName.Name = "notePanel_HInputName";
			this.notePanel_HInputName.ParentAutoHeight = true;
			this.notePanel_HInputName.Size = new System.Drawing.Size(64, 22);
			this.notePanel_HInputName.TabIndex = 31;
			this.notePanel_HInputName.TabStop = false;
			this.notePanel_HInputName.Text = "姓  名:";
			// 
			// groupControl_HInputDiagInfo
			// 
			this.groupControl_HInputDiagInfo.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_HInputDiagInfo.AppearanceCaption.Options.UseFont = true;
			this.groupControl_HInputDiagInfo.Controls.Add(this.comboBoxEdit_HInputRegion);
			this.groupControl_HInputDiagInfo.Controls.Add(this.notePanel6);
			this.groupControl_HInputDiagInfo.Controls.Add(this.comboBoxEdit_HInputStd);
			this.groupControl_HInputDiagInfo.Controls.Add(this.notePanel_HInputStd);
			this.groupControl_HInputDiagInfo.Controls.Add(this.textEdit_DiagCheckName);
			this.groupControl_HInputDiagInfo.Controls.Add(this.textEdit_DiagCheckBindingID);
			this.groupControl_HInputDiagInfo.Controls.Add(this.notePanel_DiagCheckName);
			this.groupControl_HInputDiagInfo.Controls.Add(this.groupControl_HInputDiagResult);
			this.groupControl_HInputDiagInfo.Controls.Add(this.memoEdit_DiagRemark);
			this.groupControl_HInputDiagInfo.Controls.Add(this.notePanel_DiagRemark);
			this.groupControl_HInputDiagInfo.Controls.Add(this.textEdit_DiagWeight);
			this.groupControl_HInputDiagInfo.Controls.Add(this.textEdit_DiagHeight);
			this.groupControl_HInputDiagInfo.Controls.Add(this.notePanel_HInputDaigInfo);
			this.groupControl_HInputDiagInfo.Controls.Add(this.notePanel_DiagWeight);
			this.groupControl_HInputDiagInfo.Controls.Add(this.notePanel_DiagHeight);
			this.groupControl_HInputDiagInfo.Controls.Add(this.dateEdit_DiagCheckDate);
			this.groupControl_HInputDiagInfo.Controls.Add(this.notePanel_DiagCheckDate);
			this.groupControl_HInputDiagInfo.Controls.Add(this.notePanel_HInputBirthday);
			this.groupControl_HInputDiagInfo.Controls.Add(this.textEdit_HInputBirthday);
			this.groupControl_HInputDiagInfo.Controls.Add(this.notePanel_DiagCheckGender);
			this.groupControl_HInputDiagInfo.Controls.Add(this.textEdit_DiagCheckGender);
			this.groupControl_HInputDiagInfo.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_HInputDiagInfo.Location = new System.Drawing.Point(0, 48);
			this.groupControl_HInputDiagInfo.Name = "groupControl_HInputDiagInfo";
			this.groupControl_HInputDiagInfo.Size = new System.Drawing.Size(554, 432);
			this.groupControl_HInputDiagInfo.TabIndex = 1;
			this.groupControl_HInputDiagInfo.Text = "诊断信息";
			this.groupControl_HInputDiagInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl_HInputDiagInfo_Paint);
			// 
			// comboBoxEdit_HInputRegion
			// 
			this.comboBoxEdit_HInputRegion.EditValue = "上海标准";
			this.comboBoxEdit_HInputRegion.Location = new System.Drawing.Point(136, 152);
			this.comboBoxEdit_HInputRegion.Name = "comboBoxEdit_HInputRegion";
			// 
			// comboBoxEdit_HInputRegion.Properties
			// 
			this.comboBoxEdit_HInputRegion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_HInputRegion.Properties.Items.AddRange(new object[] {
																					  "上海标准",
																					  "全国标准"});
			this.comboBoxEdit_HInputRegion.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_HInputRegion.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_HInputRegion.TabIndex = 55;
			this.comboBoxEdit_HInputRegion.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_HInputRegion_SelectedIndexChanged);
			// 
			// notePanel6
			// 
			this.notePanel6.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel6.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel6.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel6.ForeColor = System.Drawing.Color.Black;
			this.notePanel6.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel6.Location = new System.Drawing.Point(40, 152);
			this.notePanel6.MaxRows = 5;
			this.notePanel6.Name = "notePanel6";
			this.notePanel6.ParentAutoHeight = true;
			this.notePanel6.Size = new System.Drawing.Size(80, 22);
			this.notePanel6.TabIndex = 54;
			this.notePanel6.TabStop = false;
			this.notePanel6.Text = "地区标准:";
			// 
			// comboBoxEdit_HInputStd
			// 
			this.comboBoxEdit_HInputStd.EditValue = "市区标准";
			this.comboBoxEdit_HInputStd.Location = new System.Drawing.Point(136, 184);
			this.comboBoxEdit_HInputStd.Name = "comboBoxEdit_HInputStd";
			// 
			// comboBoxEdit_HInputStd.Properties
			// 
			this.comboBoxEdit_HInputStd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																														   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_HInputStd.Properties.Items.AddRange(new object[] {
																				   "市区标准",
																				   "郊区标准"});
			this.comboBoxEdit_HInputStd.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_HInputStd.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_HInputStd.TabIndex = 53;
			this.comboBoxEdit_HInputStd.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_HInputStd_SelectedIndexChanged);
			// 
			// notePanel_HInputStd
			// 
			this.notePanel_HInputStd.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_HInputStd.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_HInputStd.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_HInputStd.ForeColor = System.Drawing.Color.Black;
			this.notePanel_HInputStd.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_HInputStd.Location = new System.Drawing.Point(40, 184);
			this.notePanel_HInputStd.MaxRows = 5;
			this.notePanel_HInputStd.Name = "notePanel_HInputStd";
			this.notePanel_HInputStd.ParentAutoHeight = true;
			this.notePanel_HInputStd.Size = new System.Drawing.Size(80, 22);
			this.notePanel_HInputStd.TabIndex = 52;
			this.notePanel_HInputStd.TabStop = false;
			this.notePanel_HInputStd.Text = "市郊标准:";
			// 
			// textEdit_DiagCheckName
			// 
			this.textEdit_DiagCheckName.EditValue = "";
			this.textEdit_DiagCheckName.Location = new System.Drawing.Point(136, 56);
			this.textEdit_DiagCheckName.Name = "textEdit_DiagCheckName";
			// 
			// textEdit_DiagCheckName.Properties
			// 
			this.textEdit_DiagCheckName.Properties.Enabled = false;
			this.textEdit_DiagCheckName.Size = new System.Drawing.Size(88, 23);
			this.textEdit_DiagCheckName.TabIndex = 49;
			// 
			// textEdit_DiagCheckBindingID
			// 
			this.textEdit_DiagCheckBindingID.EditValue = "";
			this.textEdit_DiagCheckBindingID.Location = new System.Drawing.Point(200, 64);
			this.textEdit_DiagCheckBindingID.Name = "textEdit_DiagCheckBindingID";
			// 
			// textEdit_DiagCheckBindingID.Properties
			// 
			this.textEdit_DiagCheckBindingID.Properties.AutoHeight = false;
			this.textEdit_DiagCheckBindingID.Properties.Enabled = false;
			this.textEdit_DiagCheckBindingID.Size = new System.Drawing.Size(16, 8);
			this.textEdit_DiagCheckBindingID.TabIndex = 48;
			// 
			// notePanel_DiagCheckName
			// 
			this.notePanel_DiagCheckName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_DiagCheckName.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_DiagCheckName.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_DiagCheckName.ForeColor = System.Drawing.Color.Black;
			this.notePanel_DiagCheckName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_DiagCheckName.Location = new System.Drawing.Point(40, 56);
			this.notePanel_DiagCheckName.MaxRows = 5;
			this.notePanel_DiagCheckName.Name = "notePanel_DiagCheckName";
			this.notePanel_DiagCheckName.ParentAutoHeight = true;
			this.notePanel_DiagCheckName.Size = new System.Drawing.Size(80, 22);
			this.notePanel_DiagCheckName.TabIndex = 47;
			this.notePanel_DiagCheckName.TabStop = false;
			this.notePanel_DiagCheckName.Text = "幼儿姓名:";
			// 
			// groupControl_HInputDiagResult
			// 
			this.groupControl_HInputDiagResult.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_HInputDiagResult.AppearanceCaption.Options.UseFont = true;
			this.groupControl_HInputDiagResult.Controls.Add(this.textEdit_DiagResultX);
			this.groupControl_HInputDiagResult.Controls.Add(this.textEdit_DiagResultWHOPer);
			this.groupControl_HInputDiagResult.Controls.Add(this.textEdit_DiagResultHeightWeight);
			this.groupControl_HInputDiagResult.Controls.Add(this.textEdit_DiagResultUnderWeight);
			this.groupControl_HInputDiagResult.Controls.Add(this.notePanel8);
			this.groupControl_HInputDiagResult.Controls.Add(this.notePanel9);
			this.groupControl_HInputDiagResult.Controls.Add(this.notePanel10);
			this.groupControl_HInputDiagResult.Controls.Add(this.textEdit_DiagResultStunting);
			this.groupControl_HInputDiagResult.Controls.Add(this.textEdit_DiagResultWasting);
			this.groupControl_HInputDiagResult.Controls.Add(this.notePanel1);
			this.groupControl_HInputDiagResult.Controls.Add(this.textEdit_DiagResultHeight);
			this.groupControl_HInputDiagResult.Controls.Add(this.textEdit_DiagResultWeight);
			this.groupControl_HInputDiagResult.Controls.Add(this.notePanel_DiagResultWeight);
			this.groupControl_HInputDiagResult.Controls.Add(this.notePanel_DiagResultNut);
			this.groupControl_HInputDiagResult.Controls.Add(this.notePanel_DiagResultWHO);
			this.groupControl_HInputDiagResult.Controls.Add(this.notePanel_DiagResultHeight);
			this.groupControl_HInputDiagResult.Controls.Add(this.notePanel_DiagResultAge);
			this.groupControl_HInputDiagResult.Controls.Add(this.textEdit_DiagResultWHO);
			this.groupControl_HInputDiagResult.Controls.Add(this.textEdit_DiagResultNut);
			this.groupControl_HInputDiagResult.Controls.Add(this.textEdit_DiagResultAge);
			this.groupControl_HInputDiagResult.Dock = System.Windows.Forms.DockStyle.Right;
			this.groupControl_HInputDiagResult.Location = new System.Drawing.Point(231, 41);
			this.groupControl_HInputDiagResult.Name = "groupControl_HInputDiagResult";
			this.groupControl_HInputDiagResult.Size = new System.Drawing.Size(320, 388);
			this.groupControl_HInputDiagResult.TabIndex = 46;
			this.groupControl_HInputDiagResult.Text = "诊断结果";
			// 
			// textEdit_DiagResultX
			// 
			this.textEdit_DiagResultX.EditValue = "";
			this.textEdit_DiagResultX.Location = new System.Drawing.Point(248, 224);
			this.textEdit_DiagResultX.Name = "textEdit_DiagResultX";
			// 
			// textEdit_DiagResultX.Properties
			// 
			this.textEdit_DiagResultX.Properties.Enabled = false;
			this.textEdit_DiagResultX.Size = new System.Drawing.Size(88, 23);
			this.textEdit_DiagResultX.TabIndex = 76;
			this.textEdit_DiagResultX.Visible = false;
			// 
			// textEdit_DiagResultWHOPer
			// 
			this.textEdit_DiagResultWHOPer.EditValue = "";
			this.textEdit_DiagResultWHOPer.Location = new System.Drawing.Point(248, 184);
			this.textEdit_DiagResultWHOPer.Name = "textEdit_DiagResultWHOPer";
			// 
			// textEdit_DiagResultWHOPer.Properties
			// 
			this.textEdit_DiagResultWHOPer.Properties.Enabled = false;
			this.textEdit_DiagResultWHOPer.Size = new System.Drawing.Size(88, 23);
			this.textEdit_DiagResultWHOPer.TabIndex = 75;
			this.textEdit_DiagResultWHOPer.Visible = false;
			// 
			// textEdit_DiagResultHeightWeight
			// 
			this.textEdit_DiagResultHeightWeight.EditValue = "";
			this.textEdit_DiagResultHeightWeight.Location = new System.Drawing.Point(248, 144);
			this.textEdit_DiagResultHeightWeight.Name = "textEdit_DiagResultHeightWeight";
			// 
			// textEdit_DiagResultHeightWeight.Properties
			// 
			this.textEdit_DiagResultHeightWeight.Properties.Enabled = false;
			this.textEdit_DiagResultHeightWeight.Size = new System.Drawing.Size(88, 23);
			this.textEdit_DiagResultHeightWeight.TabIndex = 74;
			this.textEdit_DiagResultHeightWeight.Visible = false;
			// 
			// textEdit_DiagResultUnderWeight
			// 
			this.textEdit_DiagResultUnderWeight.EditValue = "";
			this.textEdit_DiagResultUnderWeight.Location = new System.Drawing.Point(152, 264);
			this.textEdit_DiagResultUnderWeight.Name = "textEdit_DiagResultUnderWeight";
			// 
			// textEdit_DiagResultUnderWeight.Properties
			// 
			this.textEdit_DiagResultUnderWeight.Properties.Enabled = false;
			this.textEdit_DiagResultUnderWeight.Size = new System.Drawing.Size(88, 23);
			this.textEdit_DiagResultUnderWeight.TabIndex = 70;
			// 
			// notePanel8
			// 
			this.notePanel8.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel8.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel8.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel8.ForeColor = System.Drawing.Color.Black;
			this.notePanel8.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel8.Location = new System.Drawing.Point(40, 264);
			this.notePanel8.MaxRows = 5;
			this.notePanel8.Name = "notePanel8";
			this.notePanel8.ParentAutoHeight = true;
			this.notePanel8.Size = new System.Drawing.Size(96, 22);
			this.notePanel8.TabIndex = 68;
			this.notePanel8.TabStop = false;
			this.notePanel8.Text = "  体重低下:";
			// 
			// notePanel9
			// 
			this.notePanel9.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel9.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel9.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel9.ForeColor = System.Drawing.Color.Black;
			this.notePanel9.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel9.Location = new System.Drawing.Point(40, 344);
			this.notePanel9.MaxRows = 5;
			this.notePanel9.Name = "notePanel9";
			this.notePanel9.ParentAutoHeight = true;
			this.notePanel9.Size = new System.Drawing.Size(96, 22);
			this.notePanel9.TabIndex = 71;
			this.notePanel9.TabStop = false;
			this.notePanel9.Text = "  消瘦情况:";
			// 
			// notePanel10
			// 
			this.notePanel10.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel10.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel10.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel10.ForeColor = System.Drawing.Color.Black;
			this.notePanel10.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel10.Location = new System.Drawing.Point(40, 304);
			this.notePanel10.MaxRows = 5;
			this.notePanel10.Name = "notePanel10";
			this.notePanel10.ParentAutoHeight = true;
			this.notePanel10.Size = new System.Drawing.Size(96, 22);
			this.notePanel10.TabIndex = 69;
			this.notePanel10.TabStop = false;
			this.notePanel10.Text = "   生长迟缓:";
			// 
			// textEdit_DiagResultStunting
			// 
			this.textEdit_DiagResultStunting.EditValue = "";
			this.textEdit_DiagResultStunting.Location = new System.Drawing.Point(152, 304);
			this.textEdit_DiagResultStunting.Name = "textEdit_DiagResultStunting";
			// 
			// textEdit_DiagResultStunting.Properties
			// 
			this.textEdit_DiagResultStunting.Properties.Enabled = false;
			this.textEdit_DiagResultStunting.Size = new System.Drawing.Size(88, 23);
			this.textEdit_DiagResultStunting.TabIndex = 72;
			// 
			// textEdit_DiagResultWasting
			// 
			this.textEdit_DiagResultWasting.EditValue = "";
			this.textEdit_DiagResultWasting.Location = new System.Drawing.Point(152, 344);
			this.textEdit_DiagResultWasting.Name = "textEdit_DiagResultWasting";
			// 
			// textEdit_DiagResultWasting.Properties
			// 
			this.textEdit_DiagResultWasting.Properties.Enabled = false;
			this.textEdit_DiagResultWasting.Size = new System.Drawing.Size(88, 23);
			this.textEdit_DiagResultWasting.TabIndex = 73;
			// 
			// notePanel1
			// 
			this.notePanel1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel1.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel1.Location = new System.Drawing.Point(3, 18);
			this.notePanel1.MaxRows = 5;
			this.notePanel1.Name = "notePanel1";
			this.notePanel1.ParentAutoHeight = true;
			this.notePanel1.Size = new System.Drawing.Size(314, 23);
			this.notePanel1.TabIndex = 67;
			this.notePanel1.TabStop = false;
			this.notePanel1.Text = "儿童体格发育评价标准";
			// 
			// textEdit_DiagResultHeight
			// 
			this.textEdit_DiagResultHeight.EditValue = "";
			this.textEdit_DiagResultHeight.Location = new System.Drawing.Point(152, 104);
			this.textEdit_DiagResultHeight.Name = "textEdit_DiagResultHeight";
			// 
			// textEdit_DiagResultHeight.Properties
			// 
			this.textEdit_DiagResultHeight.Properties.Enabled = false;
			this.textEdit_DiagResultHeight.Size = new System.Drawing.Size(88, 23);
			this.textEdit_DiagResultHeight.TabIndex = 62;
			// 
			// textEdit_DiagResultWeight
			// 
			this.textEdit_DiagResultWeight.EditValue = "";
			this.textEdit_DiagResultWeight.Location = new System.Drawing.Point(152, 144);
			this.textEdit_DiagResultWeight.Name = "textEdit_DiagResultWeight";
			// 
			// textEdit_DiagResultWeight.Properties
			// 
			this.textEdit_DiagResultWeight.Properties.Enabled = false;
			this.textEdit_DiagResultWeight.Size = new System.Drawing.Size(88, 23);
			this.textEdit_DiagResultWeight.TabIndex = 63;
			// 
			// notePanel_DiagResultWeight
			// 
			this.notePanel_DiagResultWeight.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_DiagResultWeight.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_DiagResultWeight.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_DiagResultWeight.ForeColor = System.Drawing.Color.Black;
			this.notePanel_DiagResultWeight.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_DiagResultWeight.Location = new System.Drawing.Point(40, 144);
			this.notePanel_DiagResultWeight.MaxRows = 5;
			this.notePanel_DiagResultWeight.Name = "notePanel_DiagResultWeight";
			this.notePanel_DiagResultWeight.ParentAutoHeight = true;
			this.notePanel_DiagResultWeight.Size = new System.Drawing.Size(96, 22);
			this.notePanel_DiagResultWeight.TabIndex = 60;
			this.notePanel_DiagResultWeight.TabStop = false;
			this.notePanel_DiagResultWeight.Text = "  体重评价:";
			// 
			// notePanel_DiagResultNut
			// 
			this.notePanel_DiagResultNut.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_DiagResultNut.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_DiagResultNut.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_DiagResultNut.ForeColor = System.Drawing.Color.Black;
			this.notePanel_DiagResultNut.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_DiagResultNut.Location = new System.Drawing.Point(40, 224);
			this.notePanel_DiagResultNut.MaxRows = 5;
			this.notePanel_DiagResultNut.Name = "notePanel_DiagResultNut";
			this.notePanel_DiagResultNut.ParentAutoHeight = true;
			this.notePanel_DiagResultNut.Size = new System.Drawing.Size(96, 22);
			this.notePanel_DiagResultNut.TabIndex = 64;
			this.notePanel_DiagResultNut.TabStop = false;
			this.notePanel_DiagResultNut.Text = "  营养诊断:";
			// 
			// notePanel_DiagResultWHO
			// 
			this.notePanel_DiagResultWHO.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_DiagResultWHO.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_DiagResultWHO.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_DiagResultWHO.ForeColor = System.Drawing.Color.Black;
			this.notePanel_DiagResultWHO.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_DiagResultWHO.Location = new System.Drawing.Point(40, 184);
			this.notePanel_DiagResultWHO.MaxRows = 5;
			this.notePanel_DiagResultWHO.Name = "notePanel_DiagResultWHO";
			this.notePanel_DiagResultWHO.ParentAutoHeight = true;
			this.notePanel_DiagResultWHO.Size = new System.Drawing.Size(96, 22);
			this.notePanel_DiagResultWHO.TabIndex = 61;
			this.notePanel_DiagResultWHO.TabStop = false;
			this.notePanel_DiagResultWHO.Text = "肥胖儿诊断:";
			// 
			// notePanel_DiagResultHeight
			// 
			this.notePanel_DiagResultHeight.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_DiagResultHeight.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_DiagResultHeight.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_DiagResultHeight.ForeColor = System.Drawing.Color.Black;
			this.notePanel_DiagResultHeight.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_DiagResultHeight.Location = new System.Drawing.Point(40, 104);
			this.notePanel_DiagResultHeight.MaxRows = 5;
			this.notePanel_DiagResultHeight.Name = "notePanel_DiagResultHeight";
			this.notePanel_DiagResultHeight.ParentAutoHeight = true;
			this.notePanel_DiagResultHeight.Size = new System.Drawing.Size(96, 22);
			this.notePanel_DiagResultHeight.TabIndex = 59;
			this.notePanel_DiagResultHeight.TabStop = false;
			this.notePanel_DiagResultHeight.Text = "  身高评价:";
			// 
			// notePanel_DiagResultAge
			// 
			this.notePanel_DiagResultAge.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_DiagResultAge.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_DiagResultAge.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_DiagResultAge.ForeColor = System.Drawing.Color.Black;
			this.notePanel_DiagResultAge.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_DiagResultAge.Location = new System.Drawing.Point(40, 64);
			this.notePanel_DiagResultAge.MaxRows = 5;
			this.notePanel_DiagResultAge.Name = "notePanel_DiagResultAge";
			this.notePanel_DiagResultAge.ParentAutoHeight = true;
			this.notePanel_DiagResultAge.Size = new System.Drawing.Size(96, 22);
			this.notePanel_DiagResultAge.TabIndex = 57;
			this.notePanel_DiagResultAge.TabStop = false;
			this.notePanel_DiagResultAge.Text = "  幼儿年龄:";
			// 
			// textEdit_DiagResultWHO
			// 
			this.textEdit_DiagResultWHO.EditValue = "";
			this.textEdit_DiagResultWHO.Location = new System.Drawing.Point(152, 184);
			this.textEdit_DiagResultWHO.Name = "textEdit_DiagResultWHO";
			// 
			// textEdit_DiagResultWHO.Properties
			// 
			this.textEdit_DiagResultWHO.Properties.Enabled = false;
			this.textEdit_DiagResultWHO.Size = new System.Drawing.Size(88, 23);
			this.textEdit_DiagResultWHO.TabIndex = 65;
			// 
			// textEdit_DiagResultNut
			// 
			this.textEdit_DiagResultNut.EditValue = "";
			this.textEdit_DiagResultNut.Location = new System.Drawing.Point(152, 224);
			this.textEdit_DiagResultNut.Name = "textEdit_DiagResultNut";
			// 
			// textEdit_DiagResultNut.Properties
			// 
			this.textEdit_DiagResultNut.Properties.Enabled = false;
			this.textEdit_DiagResultNut.Size = new System.Drawing.Size(88, 23);
			this.textEdit_DiagResultNut.TabIndex = 66;
			// 
			// textEdit_DiagResultAge
			// 
			this.textEdit_DiagResultAge.EditValue = "";
			this.textEdit_DiagResultAge.Location = new System.Drawing.Point(152, 64);
			this.textEdit_DiagResultAge.Name = "textEdit_DiagResultAge";
			// 
			// textEdit_DiagResultAge.Properties
			// 
			this.textEdit_DiagResultAge.Properties.Enabled = false;
			this.textEdit_DiagResultAge.Size = new System.Drawing.Size(88, 23);
			this.textEdit_DiagResultAge.TabIndex = 58;
			// 
			// memoEdit_DiagRemark
			// 
			this.memoEdit_DiagRemark.EditValue = "";
			this.memoEdit_DiagRemark.Location = new System.Drawing.Point(40, 344);
			this.memoEdit_DiagRemark.Name = "memoEdit_DiagRemark";
			this.memoEdit_DiagRemark.Size = new System.Drawing.Size(184, 80);
			this.memoEdit_DiagRemark.TabIndex = 45;
			// 
			// notePanel_DiagRemark
			// 
			this.notePanel_DiagRemark.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_DiagRemark.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_DiagRemark.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_DiagRemark.ForeColor = System.Drawing.Color.Black;
			this.notePanel_DiagRemark.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_DiagRemark.Location = new System.Drawing.Point(40, 312);
			this.notePanel_DiagRemark.MaxRows = 5;
			this.notePanel_DiagRemark.Name = "notePanel_DiagRemark";
			this.notePanel_DiagRemark.ParentAutoHeight = true;
			this.notePanel_DiagRemark.Size = new System.Drawing.Size(184, 22);
			this.notePanel_DiagRemark.TabIndex = 44;
			this.notePanel_DiagRemark.TabStop = false;
			this.notePanel_DiagRemark.Text = "             测评备注:";
			// 
			// textEdit_DiagWeight
			// 
			this.textEdit_DiagWeight.EditValue = "";
			this.textEdit_DiagWeight.Location = new System.Drawing.Point(136, 280);
			this.textEdit_DiagWeight.Name = "textEdit_DiagWeight";
			this.textEdit_DiagWeight.Size = new System.Drawing.Size(88, 23);
			this.textEdit_DiagWeight.TabIndex = 43;
			// 
			// textEdit_DiagHeight
			// 
			this.textEdit_DiagHeight.EditValue = "";
			this.textEdit_DiagHeight.Location = new System.Drawing.Point(136, 248);
			this.textEdit_DiagHeight.Name = "textEdit_DiagHeight";
			this.textEdit_DiagHeight.Size = new System.Drawing.Size(88, 23);
			this.textEdit_DiagHeight.TabIndex = 42;
			// 
			// notePanel_HInputDaigInfo
			// 
			this.notePanel_HInputDaigInfo.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel_HInputDaigInfo.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel_HInputDaigInfo.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel_HInputDaigInfo.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_HInputDaigInfo.Location = new System.Drawing.Point(3, 18);
			this.notePanel_HInputDaigInfo.MaxRows = 5;
			this.notePanel_HInputDaigInfo.Name = "notePanel_HInputDaigInfo";
			this.notePanel_HInputDaigInfo.ParentAutoHeight = true;
			this.notePanel_HInputDaigInfo.Size = new System.Drawing.Size(548, 23);
			this.notePanel_HInputDaigInfo.TabIndex = 41;
			this.notePanel_HInputDaigInfo.TabStop = false;
			this.notePanel_HInputDaigInfo.Text = "全国标准没有市郊之分（最后3项评测属全国标准，上海地区不会对该几项做评测）";
			// 
			// notePanel_DiagWeight
			// 
			this.notePanel_DiagWeight.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_DiagWeight.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_DiagWeight.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_DiagWeight.ForeColor = System.Drawing.Color.Black;
			this.notePanel_DiagWeight.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_DiagWeight.Location = new System.Drawing.Point(40, 280);
			this.notePanel_DiagWeight.MaxRows = 5;
			this.notePanel_DiagWeight.Name = "notePanel_DiagWeight";
			this.notePanel_DiagWeight.ParentAutoHeight = true;
			this.notePanel_DiagWeight.Size = new System.Drawing.Size(80, 22);
			this.notePanel_DiagWeight.TabIndex = 40;
			this.notePanel_DiagWeight.TabStop = false;
			this.notePanel_DiagWeight.Text = "幼儿体重:";
			// 
			// notePanel_DiagHeight
			// 
			this.notePanel_DiagHeight.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_DiagHeight.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_DiagHeight.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_DiagHeight.ForeColor = System.Drawing.Color.Black;
			this.notePanel_DiagHeight.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_DiagHeight.Location = new System.Drawing.Point(40, 248);
			this.notePanel_DiagHeight.MaxRows = 5;
			this.notePanel_DiagHeight.Name = "notePanel_DiagHeight";
			this.notePanel_DiagHeight.ParentAutoHeight = true;
			this.notePanel_DiagHeight.Size = new System.Drawing.Size(80, 22);
			this.notePanel_DiagHeight.TabIndex = 39;
			this.notePanel_DiagHeight.TabStop = false;
			this.notePanel_DiagHeight.Text = "幼儿身高:";
			// 
			// dateEdit_DiagCheckDate
			// 
			this.dateEdit_DiagCheckDate.EditValue = new System.DateTime(2005, 12, 1, 0, 0, 0, 0);
			this.dateEdit_DiagCheckDate.Location = new System.Drawing.Point(136, 216);
			this.dateEdit_DiagCheckDate.Name = "dateEdit_DiagCheckDate";
			// 
			// dateEdit_DiagCheckDate.Properties
			// 
			this.dateEdit_DiagCheckDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																														   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit_DiagCheckDate.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
			this.dateEdit_DiagCheckDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dateEdit_DiagCheckDate.Properties.Mask.EditMask = "d";
			this.dateEdit_DiagCheckDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
			this.dateEdit_DiagCheckDate.Size = new System.Drawing.Size(88, 23);
			this.dateEdit_DiagCheckDate.TabIndex = 38;
			// 
			// notePanel_DiagCheckDate
			// 
			this.notePanel_DiagCheckDate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_DiagCheckDate.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_DiagCheckDate.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_DiagCheckDate.ForeColor = System.Drawing.Color.Black;
			this.notePanel_DiagCheckDate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_DiagCheckDate.Location = new System.Drawing.Point(40, 216);
			this.notePanel_DiagCheckDate.MaxRows = 5;
			this.notePanel_DiagCheckDate.Name = "notePanel_DiagCheckDate";
			this.notePanel_DiagCheckDate.ParentAutoHeight = true;
			this.notePanel_DiagCheckDate.Size = new System.Drawing.Size(80, 22);
			this.notePanel_DiagCheckDate.TabIndex = 36;
			this.notePanel_DiagCheckDate.TabStop = false;
			this.notePanel_DiagCheckDate.Text = "体检日期:";
			// 
			// notePanel_HInputBirthday
			// 
			this.notePanel_HInputBirthday.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_HInputBirthday.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_HInputBirthday.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_HInputBirthday.ForeColor = System.Drawing.Color.Black;
			this.notePanel_HInputBirthday.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_HInputBirthday.Location = new System.Drawing.Point(40, 120);
			this.notePanel_HInputBirthday.MaxRows = 5;
			this.notePanel_HInputBirthday.Name = "notePanel_HInputBirthday";
			this.notePanel_HInputBirthday.ParentAutoHeight = true;
			this.notePanel_HInputBirthday.Size = new System.Drawing.Size(80, 22);
			this.notePanel_HInputBirthday.TabIndex = 46;
			this.notePanel_HInputBirthday.TabStop = false;
			this.notePanel_HInputBirthday.Text = "幼儿生日:";
			// 
			// textEdit_HInputBirthday
			// 
			this.textEdit_HInputBirthday.EditValue = "";
			this.textEdit_HInputBirthday.Location = new System.Drawing.Point(136, 120);
			this.textEdit_HInputBirthday.Name = "textEdit_HInputBirthday";
			// 
			// textEdit_HInputBirthday.Properties
			// 
			this.textEdit_HInputBirthday.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
			this.textEdit_HInputBirthday.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.textEdit_HInputBirthday.Properties.Enabled = false;
			this.textEdit_HInputBirthday.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
			this.textEdit_HInputBirthday.Properties.ReadOnly = true;
			this.textEdit_HInputBirthday.Size = new System.Drawing.Size(88, 23);
			this.textEdit_HInputBirthday.TabIndex = 47;
			// 
			// notePanel_DiagCheckGender
			// 
			this.notePanel_DiagCheckGender.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_DiagCheckGender.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_DiagCheckGender.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_DiagCheckGender.ForeColor = System.Drawing.Color.Black;
			this.notePanel_DiagCheckGender.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_DiagCheckGender.Location = new System.Drawing.Point(40, 88);
			this.notePanel_DiagCheckGender.MaxRows = 5;
			this.notePanel_DiagCheckGender.Name = "notePanel_DiagCheckGender";
			this.notePanel_DiagCheckGender.ParentAutoHeight = true;
			this.notePanel_DiagCheckGender.Size = new System.Drawing.Size(80, 22);
			this.notePanel_DiagCheckGender.TabIndex = 50;
			this.notePanel_DiagCheckGender.TabStop = false;
			this.notePanel_DiagCheckGender.Text = "幼儿性别:";
			// 
			// textEdit_DiagCheckGender
			// 
			this.textEdit_DiagCheckGender.EditValue = "";
			this.textEdit_DiagCheckGender.Location = new System.Drawing.Point(136, 88);
			this.textEdit_DiagCheckGender.Name = "textEdit_DiagCheckGender";
			// 
			// textEdit_DiagCheckGender.Properties
			// 
			this.textEdit_DiagCheckGender.Properties.Enabled = false;
			this.textEdit_DiagCheckGender.Size = new System.Drawing.Size(88, 23);
			this.textEdit_DiagCheckGender.TabIndex = 51;
			// 
			// panelControl5
			// 
			this.panelControl5.Controls.Add(this.simpleButton_HInputModify);
			this.panelControl5.Controls.Add(this.simpleButton_HInputDelete);
			this.panelControl5.Controls.Add(this.simpleButton_HInputSave);
			this.panelControl5.Controls.Add(this.simpleButton_HInputDiag);
			this.panelControl5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl5.Location = new System.Drawing.Point(0, 0);
			this.panelControl5.Name = "panelControl5";
			this.panelControl5.Size = new System.Drawing.Size(554, 48);
			this.panelControl5.TabIndex = 0;
			this.panelControl5.Text = "panelControl5";
			// 
			// simpleButton_HInputModify
			// 
			this.simpleButton_HInputModify.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_HInputModify.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_HInputModify.Appearance.Options.UseFont = true;
			this.simpleButton_HInputModify.Appearance.Options.UseForeColor = true;
			this.simpleButton_HInputModify.Enabled = false;
			this.simpleButton_HInputModify.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_HInputModify.Image")));
			this.simpleButton_HInputModify.Location = new System.Drawing.Point(136, 8);
			this.simpleButton_HInputModify.Name = "simpleButton_HInputModify";
			this.simpleButton_HInputModify.Size = new System.Drawing.Size(92, 26);
			this.simpleButton_HInputModify.TabIndex = 12;
			this.simpleButton_HInputModify.Tag = 4;
			this.simpleButton_HInputModify.Text = "修  改";
			this.simpleButton_HInputModify.Click += new System.EventHandler(this.simpleButton_HInputModify_Click);
			// 
			// simpleButton_HInputDelete
			// 
			this.simpleButton_HInputDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_HInputDelete.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_HInputDelete.Appearance.Options.UseFont = true;
			this.simpleButton_HInputDelete.Appearance.Options.UseForeColor = true;
			this.simpleButton_HInputDelete.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_HInputDelete.Image")));
			this.simpleButton_HInputDelete.Location = new System.Drawing.Point(240, 8);
			this.simpleButton_HInputDelete.Name = "simpleButton_HInputDelete";
			this.simpleButton_HInputDelete.Size = new System.Drawing.Size(92, 26);
			this.simpleButton_HInputDelete.TabIndex = 11;
			this.simpleButton_HInputDelete.Tag = 4;
			this.simpleButton_HInputDelete.Text = "删  除";
			this.simpleButton_HInputDelete.Click += new System.EventHandler(this.simpleButton_HInputDelete_Click);
			// 
			// simpleButton_HInputSave
			// 
			this.simpleButton_HInputSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_HInputSave.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_HInputSave.Appearance.Options.UseFont = true;
			this.simpleButton_HInputSave.Appearance.Options.UseForeColor = true;
			this.simpleButton_HInputSave.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_HInputSave.Image")));
			this.simpleButton_HInputSave.Location = new System.Drawing.Point(240, 24);
			this.simpleButton_HInputSave.Name = "simpleButton_HInputSave";
			this.simpleButton_HInputSave.Size = new System.Drawing.Size(8, 8);
			this.simpleButton_HInputSave.TabIndex = 9;
			this.simpleButton_HInputSave.Tag = 4;
			this.simpleButton_HInputSave.Text = "保  存";
			this.simpleButton_HInputSave.Click += new System.EventHandler(this.simpleButton_HInputSave_Click);
			// 
			// simpleButton_HInputDiag
			// 
			this.simpleButton_HInputDiag.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_HInputDiag.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_HInputDiag.Appearance.Options.UseFont = true;
			this.simpleButton_HInputDiag.Appearance.Options.UseForeColor = true;
			this.simpleButton_HInputDiag.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_HInputDiag.Image")));
			this.simpleButton_HInputDiag.Location = new System.Drawing.Point(8, 8);
			this.simpleButton_HInputDiag.Name = "simpleButton_HInputDiag";
			this.simpleButton_HInputDiag.Size = new System.Drawing.Size(112, 26);
			this.simpleButton_HInputDiag.TabIndex = 8;
			this.simpleButton_HInputDiag.Tag = 4;
			this.simpleButton_HInputDiag.Text = "诊断并保存";
			this.simpleButton_HInputDiag.Click += new System.EventHandler(this.simpleButton_HInputDiag_Click);
			// 
			// xtraTabPage6
			// 
			this.xtraTabPage6.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
			this.xtraTabPage6.Appearance.PageClient.Options.UseBackColor = true;
			this.xtraTabPage6.Controls.Add(this.splitContainerControl7);
			this.xtraTabPage6.Name = "xtraTabPage6";
			this.xtraTabPage6.Size = new System.Drawing.Size(768, 515);
			this.xtraTabPage6.Text = "幼儿评测结果浏览及打印";
			// 
			// splitContainerControl7
			// 
			this.splitContainerControl7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl7.Location = new System.Drawing.Point(0, 0);
			this.splitContainerControl7.Name = "splitContainerControl7";
			this.splitContainerControl7.Panel1.Controls.Add(this.groupControl_HOutputPrintType);
			this.splitContainerControl7.Panel1.Controls.Add(this.groupControl_HOutputSer);
			this.splitContainerControl7.Panel1.Text = "splitContainerControl7_Panel1";
			this.splitContainerControl7.Panel2.Controls.Add(this.gridControl_HOutputNchsGrid);
			this.splitContainerControl7.Panel2.Controls.Add(this.gridControl_HOutputGridShow);
			this.splitContainerControl7.Panel2.Controls.Add(this.panelControl6);
			this.splitContainerControl7.Panel2.Text = "splitContainerControl7_Panel2";
			this.splitContainerControl7.Size = new System.Drawing.Size(768, 515);
			this.splitContainerControl7.SplitterPosition = 250;
			this.splitContainerControl7.TabIndex = 0;
			this.splitContainerControl7.Text = "splitContainerControl7";
			// 
			// groupControl_HOutputPrintType
			// 
			this.groupControl_HOutputPrintType.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_HOutputPrintType.AppearanceCaption.Options.UseFont = true;
			this.groupControl_HOutputPrintType.Controls.Add(this.checkEdit_HOutputPrintType4th);
			this.groupControl_HOutputPrintType.Controls.Add(this.checkEdit_HOutputPrintType3rd);
			this.groupControl_HOutputPrintType.Controls.Add(this.checkEdit_HOutputPrintType2nd);
			this.groupControl_HOutputPrintType.Controls.Add(this.checkEdit_HOutputPrintType1st);
			this.groupControl_HOutputPrintType.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl_HOutputPrintType.Location = new System.Drawing.Point(0, 376);
			this.groupControl_HOutputPrintType.Name = "groupControl_HOutputPrintType";
			this.groupControl_HOutputPrintType.Size = new System.Drawing.Size(244, 133);
			this.groupControl_HOutputPrintType.TabIndex = 1;
			this.groupControl_HOutputPrintType.Text = "报表格式及选项目";
			// 
			// checkEdit_HOutputPrintType4th
			// 
			this.checkEdit_HOutputPrintType4th.Location = new System.Drawing.Point(8, 96);
			this.checkEdit_HOutputPrintType4th.Name = "checkEdit_HOutputPrintType4th";
			// 
			// checkEdit_HOutputPrintType4th.Properties
			// 
			this.checkEdit_HOutputPrintType4th.Properties.Caption = "是否生成个人体格评价详细表(限全国)";
			this.checkEdit_HOutputPrintType4th.Size = new System.Drawing.Size(224, 19);
			this.checkEdit_HOutputPrintType4th.TabIndex = 59;
			// 
			// checkEdit_HOutputPrintType3rd
			// 
			this.checkEdit_HOutputPrintType3rd.Location = new System.Drawing.Point(8, 72);
			this.checkEdit_HOutputPrintType3rd.Name = "checkEdit_HOutputPrintType3rd";
			// 
			// checkEdit_HOutputPrintType3rd.Properties
			// 
			this.checkEdit_HOutputPrintType3rd.Properties.Caption = "是否生成身高体重超均值统计(限上海)";
			this.checkEdit_HOutputPrintType3rd.Size = new System.Drawing.Size(224, 19);
			this.checkEdit_HOutputPrintType3rd.TabIndex = 57;
			// 
			// checkEdit_HOutputPrintType2nd
			// 
			this.checkEdit_HOutputPrintType2nd.Location = new System.Drawing.Point(8, 48);
			this.checkEdit_HOutputPrintType2nd.Name = "checkEdit_HOutputPrintType2nd";
			// 
			// checkEdit_HOutputPrintType2nd.Properties
			// 
			this.checkEdit_HOutputPrintType2nd.Properties.Caption = "是否生成身高体重均值统计";
			this.checkEdit_HOutputPrintType2nd.Size = new System.Drawing.Size(224, 19);
			this.checkEdit_HOutputPrintType2nd.TabIndex = 56;
			// 
			// checkEdit_HOutputPrintType1st
			// 
			this.checkEdit_HOutputPrintType1st.Location = new System.Drawing.Point(8, 24);
			this.checkEdit_HOutputPrintType1st.Name = "checkEdit_HOutputPrintType1st";
			// 
			// checkEdit_HOutputPrintType1st.Properties
			// 
			this.checkEdit_HOutputPrintType1st.Properties.Caption = "是否按幼儿所在班级划分";
			this.checkEdit_HOutputPrintType1st.Size = new System.Drawing.Size(224, 19);
			this.checkEdit_HOutputPrintType1st.TabIndex = 55;
			// 
			// groupControl_HOutputSer
			// 
			this.groupControl_HOutputSer.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_HOutputSer.AppearanceCaption.Options.UseFont = true;
			this.groupControl_HOutputSer.Controls.Add(this.comboBoxEdit_HOutputRegion);
			this.groupControl_HOutputSer.Controls.Add(this.notePanel11);
			this.groupControl_HOutputSer.Controls.Add(this.dateEdit_HOutputEndDate);
			this.groupControl_HOutputSer.Controls.Add(this.dateEdit_HOutputBegDate);
			this.groupControl_HOutputSer.Controls.Add(this.notePanel_HOutputEndDate);
			this.groupControl_HOutputSer.Controls.Add(this.notePanel_HOutputBegDate);
			this.groupControl_HOutputSer.Controls.Add(this.comboBoxEdit_HOutputGender);
			this.groupControl_HOutputSer.Controls.Add(this.comboBoxEdit_HOutputResult);
			this.groupControl_HOutputSer.Controls.Add(this.notePanel_HOutputResult);
			this.groupControl_HOutputSer.Controls.Add(this.comboBoxEdit_HOutputType);
			this.groupControl_HOutputSer.Controls.Add(this.comboBoxEdit_HOutputAge);
			this.groupControl_HOutputSer.Controls.Add(this.notePanel_HOutputType);
			this.groupControl_HOutputSer.Controls.Add(this.notePanel_HOutputAge);
			this.groupControl_HOutputSer.Controls.Add(this.textEdit_HOutputNumber);
			this.groupControl_HOutputSer.Controls.Add(this.textEdit_HOutputName);
			this.groupControl_HOutputSer.Controls.Add(this.comboBoxEdit_HOutputClass);
			this.groupControl_HOutputSer.Controls.Add(this.notePanel_HOutputClass);
			this.groupControl_HOutputSer.Controls.Add(this.comboBoxEdit_HOutputGrade);
			this.groupControl_HOutputSer.Controls.Add(this.notePanel_HOutputGrade);
			this.groupControl_HOutputSer.Controls.Add(this.notePanel_HOutputNumber);
			this.groupControl_HOutputSer.Controls.Add(this.notePanel_HOutputName);
			this.groupControl_HOutputSer.Controls.Add(this.notePanel_HOutputGender);
			this.groupControl_HOutputSer.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_HOutputSer.Location = new System.Drawing.Point(0, 0);
			this.groupControl_HOutputSer.Name = "groupControl_HOutputSer";
			this.groupControl_HOutputSer.Size = new System.Drawing.Size(244, 376);
			this.groupControl_HOutputSer.TabIndex = 0;
			this.groupControl_HOutputSer.Text = "信息查询";
			// 
			// comboBoxEdit_HOutputRegion
			// 
			this.comboBoxEdit_HOutputRegion.EditValue = "上海标准";
			this.comboBoxEdit_HOutputRegion.Location = new System.Drawing.Point(136, 184);
			this.comboBoxEdit_HOutputRegion.Name = "comboBoxEdit_HOutputRegion";
			// 
			// comboBoxEdit_HOutputRegion.Properties
			// 
			this.comboBoxEdit_HOutputRegion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_HOutputRegion.Properties.Items.AddRange(new object[] {
																					   "上海标准",
																					   "全国标准"});
			this.comboBoxEdit_HOutputRegion.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_HOutputRegion.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_HOutputRegion.TabIndex = 61;
			this.comboBoxEdit_HOutputRegion.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_HOutputRegion_SelectedIndexChanged);
			// 
			// notePanel11
			// 
			this.notePanel11.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel11.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel11.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel11.ForeColor = System.Drawing.Color.Black;
			this.notePanel11.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel11.Location = new System.Drawing.Point(24, 184);
			this.notePanel11.MaxRows = 5;
			this.notePanel11.Name = "notePanel11";
			this.notePanel11.ParentAutoHeight = true;
			this.notePanel11.Size = new System.Drawing.Size(83, 22);
			this.notePanel11.TabIndex = 60;
			this.notePanel11.TabStop = false;
			this.notePanel11.Text = "地区标准:";
			// 
			// dateEdit_HOutputEndDate
			// 
			this.dateEdit_HOutputEndDate.EditValue = new System.DateTime(2005, 12, 1, 0, 0, 0, 0);
			this.dateEdit_HOutputEndDate.Location = new System.Drawing.Point(136, 344);
			this.dateEdit_HOutputEndDate.Name = "dateEdit_HOutputEndDate";
			// 
			// dateEdit_HOutputEndDate.Properties
			// 
			this.dateEdit_HOutputEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit_HOutputEndDate.Properties.Mask.EditMask = "d";
			this.dateEdit_HOutputEndDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
			this.dateEdit_HOutputEndDate.Size = new System.Drawing.Size(88, 23);
			this.dateEdit_HOutputEndDate.TabIndex = 59;
			// 
			// dateEdit_HOutputBegDate
			// 
			this.dateEdit_HOutputBegDate.EditValue = new System.DateTime(2005, 12, 1, 0, 0, 0, 0);
			this.dateEdit_HOutputBegDate.Location = new System.Drawing.Point(136, 312);
			this.dateEdit_HOutputBegDate.Name = "dateEdit_HOutputBegDate";
			// 
			// dateEdit_HOutputBegDate.Properties
			// 
			this.dateEdit_HOutputBegDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit_HOutputBegDate.Properties.Mask.EditMask = "d";
			this.dateEdit_HOutputBegDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
			this.dateEdit_HOutputBegDate.Size = new System.Drawing.Size(88, 23);
			this.dateEdit_HOutputBegDate.TabIndex = 58;
			// 
			// notePanel_HOutputEndDate
			// 
			this.notePanel_HOutputEndDate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_HOutputEndDate.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_HOutputEndDate.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_HOutputEndDate.ForeColor = System.Drawing.Color.Black;
			this.notePanel_HOutputEndDate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_HOutputEndDate.Location = new System.Drawing.Point(24, 344);
			this.notePanel_HOutputEndDate.MaxRows = 5;
			this.notePanel_HOutputEndDate.Name = "notePanel_HOutputEndDate";
			this.notePanel_HOutputEndDate.ParentAutoHeight = true;
			this.notePanel_HOutputEndDate.Size = new System.Drawing.Size(83, 22);
			this.notePanel_HOutputEndDate.TabIndex = 57;
			this.notePanel_HOutputEndDate.TabStop = false;
			this.notePanel_HOutputEndDate.Text = "截止时间:";
			// 
			// notePanel_HOutputBegDate
			// 
			this.notePanel_HOutputBegDate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_HOutputBegDate.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_HOutputBegDate.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_HOutputBegDate.ForeColor = System.Drawing.Color.Black;
			this.notePanel_HOutputBegDate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_HOutputBegDate.Location = new System.Drawing.Point(24, 312);
			this.notePanel_HOutputBegDate.MaxRows = 5;
			this.notePanel_HOutputBegDate.Name = "notePanel_HOutputBegDate";
			this.notePanel_HOutputBegDate.ParentAutoHeight = true;
			this.notePanel_HOutputBegDate.Size = new System.Drawing.Size(83, 22);
			this.notePanel_HOutputBegDate.TabIndex = 56;
			this.notePanel_HOutputBegDate.TabStop = false;
			this.notePanel_HOutputBegDate.Text = "起始时间:";
			// 
			// comboBoxEdit_HOutputGender
			// 
			this.comboBoxEdit_HOutputGender.EditValue = "全部";
			this.comboBoxEdit_HOutputGender.Location = new System.Drawing.Point(136, 152);
			this.comboBoxEdit_HOutputGender.Name = "comboBoxEdit_HOutputGender";
			// 
			// comboBoxEdit_HOutputGender.Properties
			// 
			this.comboBoxEdit_HOutputGender.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_HOutputGender.Properties.Items.AddRange(new object[] {
																					   "全部",
																					   "男",
																					   "女"});
			this.comboBoxEdit_HOutputGender.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_HOutputGender.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_HOutputGender.TabIndex = 55;
			this.comboBoxEdit_HOutputGender.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_HOutputGender_SelectedIndexChanged);
			// 
			// comboBoxEdit_HOutputResult
			// 
			this.comboBoxEdit_HOutputResult.EditValue = "全部";
			this.comboBoxEdit_HOutputResult.Location = new System.Drawing.Point(136, 280);
			this.comboBoxEdit_HOutputResult.Name = "comboBoxEdit_HOutputResult";
			// 
			// comboBoxEdit_HOutputResult.Properties
			// 
			this.comboBoxEdit_HOutputResult.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_HOutputResult.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_HOutputResult.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_HOutputResult.TabIndex = 54;
			this.comboBoxEdit_HOutputResult.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_HOutputResult_SelectedIndexChanged);
			// 
			// notePanel_HOutputResult
			// 
			this.notePanel_HOutputResult.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_HOutputResult.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_HOutputResult.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_HOutputResult.ForeColor = System.Drawing.Color.Black;
			this.notePanel_HOutputResult.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_HOutputResult.Location = new System.Drawing.Point(24, 280);
			this.notePanel_HOutputResult.MaxRows = 5;
			this.notePanel_HOutputResult.Name = "notePanel_HOutputResult";
			this.notePanel_HOutputResult.ParentAutoHeight = true;
			this.notePanel_HOutputResult.Size = new System.Drawing.Size(83, 22);
			this.notePanel_HOutputResult.TabIndex = 53;
			this.notePanel_HOutputResult.TabStop = false;
			this.notePanel_HOutputResult.Text = "诊断结果:";
			// 
			// comboBoxEdit_HOutputType
			// 
			this.comboBoxEdit_HOutputType.EditValue = "全部";
			this.comboBoxEdit_HOutputType.Location = new System.Drawing.Point(136, 248);
			this.comboBoxEdit_HOutputType.Name = "comboBoxEdit_HOutputType";
			// 
			// comboBoxEdit_HOutputType.Properties
			// 
			this.comboBoxEdit_HOutputType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_HOutputType.Properties.Items.AddRange(new object[] {
																					 "全部",
																					 "身高评价",
																					 "体重评价",
																					 "肥胖评价",
																					 "营养评价"});
			this.comboBoxEdit_HOutputType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_HOutputType.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_HOutputType.TabIndex = 52;
			this.comboBoxEdit_HOutputType.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_HOutputType_SelectedIndexChanged);
			// 
			// comboBoxEdit_HOutputAge
			// 
			this.comboBoxEdit_HOutputAge.EditValue = "全部";
			this.comboBoxEdit_HOutputAge.Location = new System.Drawing.Point(136, 216);
			this.comboBoxEdit_HOutputAge.Name = "comboBoxEdit_HOutputAge";
			// 
			// comboBoxEdit_HOutputAge.Properties
			// 
			this.comboBoxEdit_HOutputAge.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_HOutputAge.Properties.Items.AddRange(new object[] {
																					"全部",
																					"0-1岁组",
																					"1岁组",
																					"2岁组",
																					"3岁组",
																					"4岁组",
																					"5岁组",
																					"6-7岁组"});
			this.comboBoxEdit_HOutputAge.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_HOutputAge.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_HOutputAge.TabIndex = 51;
			this.comboBoxEdit_HOutputAge.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_HOutputAge_SelectedIndexChanged);
			// 
			// notePanel_HOutputType
			// 
			this.notePanel_HOutputType.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_HOutputType.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_HOutputType.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_HOutputType.ForeColor = System.Drawing.Color.Black;
			this.notePanel_HOutputType.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_HOutputType.Location = new System.Drawing.Point(24, 248);
			this.notePanel_HOutputType.MaxRows = 5;
			this.notePanel_HOutputType.Name = "notePanel_HOutputType";
			this.notePanel_HOutputType.ParentAutoHeight = true;
			this.notePanel_HOutputType.Size = new System.Drawing.Size(83, 22);
			this.notePanel_HOutputType.TabIndex = 50;
			this.notePanel_HOutputType.TabStop = false;
			this.notePanel_HOutputType.Text = "诊断项目:";
			// 
			// notePanel_HOutputAge
			// 
			this.notePanel_HOutputAge.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_HOutputAge.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_HOutputAge.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_HOutputAge.ForeColor = System.Drawing.Color.Black;
			this.notePanel_HOutputAge.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_HOutputAge.Location = new System.Drawing.Point(24, 216);
			this.notePanel_HOutputAge.MaxRows = 5;
			this.notePanel_HOutputAge.Name = "notePanel_HOutputAge";
			this.notePanel_HOutputAge.ParentAutoHeight = true;
			this.notePanel_HOutputAge.Size = new System.Drawing.Size(83, 22);
			this.notePanel_HOutputAge.TabIndex = 49;
			this.notePanel_HOutputAge.TabStop = false;
			this.notePanel_HOutputAge.Text = "幼儿年龄:";
			// 
			// textEdit_HOutputNumber
			// 
			this.textEdit_HOutputNumber.EditValue = "";
			this.textEdit_HOutputNumber.Location = new System.Drawing.Point(136, 120);
			this.textEdit_HOutputNumber.Name = "textEdit_HOutputNumber";
			this.textEdit_HOutputNumber.Size = new System.Drawing.Size(88, 23);
			this.textEdit_HOutputNumber.TabIndex = 48;
			this.textEdit_HOutputNumber.EditValueChanged += new System.EventHandler(this.textEdit_HOutputNumber_EditValueChanged);
			// 
			// textEdit_HOutputName
			// 
			this.textEdit_HOutputName.EditValue = "";
			this.textEdit_HOutputName.Location = new System.Drawing.Point(136, 88);
			this.textEdit_HOutputName.Name = "textEdit_HOutputName";
			this.textEdit_HOutputName.Size = new System.Drawing.Size(88, 23);
			this.textEdit_HOutputName.TabIndex = 47;
			this.textEdit_HOutputName.EditValueChanged += new System.EventHandler(this.textEdit_HOutputName_EditValueChanged);
			// 
			// comboBoxEdit_HOutputClass
			// 
			this.comboBoxEdit_HOutputClass.EditValue = "全部";
			this.comboBoxEdit_HOutputClass.Location = new System.Drawing.Point(136, 56);
			this.comboBoxEdit_HOutputClass.Name = "comboBoxEdit_HOutputClass";
			// 
			// comboBoxEdit_HOutputClass.Properties
			// 
			this.comboBoxEdit_HOutputClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_HOutputClass.Properties.Items.AddRange(new object[] {
																					  "全部"});
			this.comboBoxEdit_HOutputClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_HOutputClass.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_HOutputClass.TabIndex = 46;
			this.comboBoxEdit_HOutputClass.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_HOutputClass_SelectedIndexChanged);
			// 
			// notePanel_HOutputClass
			// 
			this.notePanel_HOutputClass.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_HOutputClass.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_HOutputClass.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_HOutputClass.ForeColor = System.Drawing.Color.Black;
			this.notePanel_HOutputClass.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_HOutputClass.Location = new System.Drawing.Point(24, 56);
			this.notePanel_HOutputClass.MaxRows = 5;
			this.notePanel_HOutputClass.Name = "notePanel_HOutputClass";
			this.notePanel_HOutputClass.ParentAutoHeight = true;
			this.notePanel_HOutputClass.Size = new System.Drawing.Size(83, 22);
			this.notePanel_HOutputClass.TabIndex = 45;
			this.notePanel_HOutputClass.TabStop = false;
			this.notePanel_HOutputClass.Text = "  班  级:";
			// 
			// comboBoxEdit_HOutputGrade
			// 
			this.comboBoxEdit_HOutputGrade.EditValue = "全部";
			this.comboBoxEdit_HOutputGrade.Location = new System.Drawing.Point(136, 24);
			this.comboBoxEdit_HOutputGrade.Name = "comboBoxEdit_HOutputGrade";
			// 
			// comboBoxEdit_HOutputGrade.Properties
			// 
			this.comboBoxEdit_HOutputGrade.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_HOutputGrade.Properties.Items.AddRange(new object[] {
																					  "全部"});
			this.comboBoxEdit_HOutputGrade.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_HOutputGrade.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_HOutputGrade.TabIndex = 44;
			this.comboBoxEdit_HOutputGrade.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_HOutputGrade_SelectedIndexChanged);
			// 
			// notePanel_HOutputGrade
			// 
			this.notePanel_HOutputGrade.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_HOutputGrade.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_HOutputGrade.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_HOutputGrade.ForeColor = System.Drawing.Color.Black;
			this.notePanel_HOutputGrade.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_HOutputGrade.Location = new System.Drawing.Point(24, 24);
			this.notePanel_HOutputGrade.MaxRows = 5;
			this.notePanel_HOutputGrade.Name = "notePanel_HOutputGrade";
			this.notePanel_HOutputGrade.ParentAutoHeight = true;
			this.notePanel_HOutputGrade.Size = new System.Drawing.Size(83, 22);
			this.notePanel_HOutputGrade.TabIndex = 43;
			this.notePanel_HOutputGrade.TabStop = false;
			this.notePanel_HOutputGrade.Text = "  年  级:";
			// 
			// notePanel_HOutputNumber
			// 
			this.notePanel_HOutputNumber.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_HOutputNumber.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_HOutputNumber.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_HOutputNumber.ForeColor = System.Drawing.Color.Black;
			this.notePanel_HOutputNumber.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_HOutputNumber.Location = new System.Drawing.Point(24, 120);
			this.notePanel_HOutputNumber.MaxRows = 5;
			this.notePanel_HOutputNumber.Name = "notePanel_HOutputNumber";
			this.notePanel_HOutputNumber.ParentAutoHeight = true;
			this.notePanel_HOutputNumber.Size = new System.Drawing.Size(83, 22);
			this.notePanel_HOutputNumber.TabIndex = 42;
			this.notePanel_HOutputNumber.TabStop = false;
			this.notePanel_HOutputNumber.Text = "  学  号:";
			// 
			// notePanel_HOutputName
			// 
			this.notePanel_HOutputName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_HOutputName.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_HOutputName.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_HOutputName.ForeColor = System.Drawing.Color.Black;
			this.notePanel_HOutputName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_HOutputName.Location = new System.Drawing.Point(24, 88);
			this.notePanel_HOutputName.MaxRows = 5;
			this.notePanel_HOutputName.Name = "notePanel_HOutputName";
			this.notePanel_HOutputName.ParentAutoHeight = true;
			this.notePanel_HOutputName.Size = new System.Drawing.Size(83, 22);
			this.notePanel_HOutputName.TabIndex = 41;
			this.notePanel_HOutputName.TabStop = false;
			this.notePanel_HOutputName.Text = "  姓  名:";
			// 
			// notePanel_HOutputGender
			// 
			this.notePanel_HOutputGender.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_HOutputGender.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_HOutputGender.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_HOutputGender.ForeColor = System.Drawing.Color.Black;
			this.notePanel_HOutputGender.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_HOutputGender.Location = new System.Drawing.Point(24, 152);
			this.notePanel_HOutputGender.MaxRows = 5;
			this.notePanel_HOutputGender.Name = "notePanel_HOutputGender";
			this.notePanel_HOutputGender.ParentAutoHeight = true;
			this.notePanel_HOutputGender.Size = new System.Drawing.Size(83, 22);
			this.notePanel_HOutputGender.TabIndex = 42;
			this.notePanel_HOutputGender.TabStop = false;
			this.notePanel_HOutputGender.Text = "  性  别:";
			// 
			// gridControl_HOutputNchsGrid
			// 
			this.gridControl_HOutputNchsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl_HOutputNchsGrid.EmbeddedNavigator
			// 
			this.gridControl_HOutputNchsGrid.EmbeddedNavigator.Name = "";
			this.gridControl_HOutputNchsGrid.Location = new System.Drawing.Point(0, 48);
			this.gridControl_HOutputNchsGrid.MainView = this.advBandedGridView2;
			this.gridControl_HOutputNchsGrid.Name = "gridControl_HOutputNchsGrid";
			this.gridControl_HOutputNchsGrid.Size = new System.Drawing.Size(508, 461);
			this.gridControl_HOutputNchsGrid.TabIndex = 2;
			this.gridControl_HOutputNchsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																													   this.advBandedGridView2});
			// 
			// advBandedGridView2
			// 
			this.advBandedGridView2.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
																										   this.gridBand5,
																										   this.gridBand6,
																										   this.gridBand7});
			this.advBandedGridView2.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
																													 this.bandedGridColumn1,
																													 this.bandedGridColumn16,
																													 this.bandedGridColumn17,
																													 this.bandedGridColumn18,
																													 this.bandedGridColumn19,
																													 this.bandedGridColumn20,
																													 this.bandedGridColumn21,
																													 this.bandedGridColumn22,
																													 this.bandedGridColumn23,
																													 this.bandedGridColumn24,
																													 this.bandedGridColumn25,
																													 this.bandedGridColumn26,
																													 this.bandedGridColumn27,
																													 this.bandedGridColumn28,
																													 this.bandedGridColumn29,
																													 this.bandedGridColumn30});
			this.advBandedGridView2.GridControl = this.gridControl_HOutputNchsGrid;
			this.advBandedGridView2.Name = "advBandedGridView2";
			this.advBandedGridView2.OptionsCustomization.AllowFilter = false;
			this.advBandedGridView2.OptionsCustomization.AllowGroup = false;
			this.advBandedGridView2.OptionsView.ShowFilterPanel = false;
			this.advBandedGridView2.OptionsView.ShowGroupPanel = false;
			// 
			// gridBand5
			// 
			this.gridBand5.AppearanceHeader.Options.UseTextOptions = true;
			this.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridBand5.Caption = "基本信息";
			this.gridBand5.Columns.Add(this.bandedGridColumn1);
			this.gridBand5.Columns.Add(this.bandedGridColumn16);
			this.gridBand5.MinWidth = 20;
			this.gridBand5.Name = "gridBand5";
			this.gridBand5.Width = 63;
			// 
			// bandedGridColumn1
			// 
			this.bandedGridColumn1.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn1.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn1.Caption = "姓名";
			this.bandedGridColumn1.FieldName = "info_stuName";
			this.bandedGridColumn1.Name = "bandedGridColumn1";
			this.bandedGridColumn1.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn1.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn1.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn1.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn1.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn1.Visible = true;
			this.bandedGridColumn1.Width = 63;
			// 
			// bandedGridColumn16
			// 
			this.bandedGridColumn16.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn16.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn16.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn16.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn16.Caption = "学号";
			this.bandedGridColumn16.FieldName = "nchsanaly_stunumber";
			this.bandedGridColumn16.Name = "bandedGridColumn16";
			this.bandedGridColumn16.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn16.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn16.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn16.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn16.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn16.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn16.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn16.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn16.RowIndex = 1;
			this.bandedGridColumn16.Visible = true;
			this.bandedGridColumn16.Width = 63;
			// 
			// gridBand6
			// 
			this.gridBand6.AppearanceHeader.Options.UseTextOptions = true;
			this.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridBand6.Caption = "扩展信息";
			this.gridBand6.Columns.Add(this.bandedGridColumn19);
			this.gridBand6.Columns.Add(this.bandedGridColumn17);
			this.gridBand6.Columns.Add(this.bandedGridColumn23);
			this.gridBand6.Columns.Add(this.bandedGridColumn18);
			this.gridBand6.Name = "gridBand6";
			this.gridBand6.Width = 135;
			// 
			// bandedGridColumn19
			// 
			this.bandedGridColumn19.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn19.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn19.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn19.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn19.Caption = "出生年月";
			this.bandedGridColumn19.FieldName = "info_stuBirthday";
			this.bandedGridColumn19.Name = "bandedGridColumn19";
			this.bandedGridColumn19.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn19.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn19.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn19.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn19.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn19.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn19.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn19.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn19.Visible = true;
			this.bandedGridColumn19.Width = 60;
			// 
			// bandedGridColumn17
			// 
			this.bandedGridColumn17.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn17.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn17.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn17.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn17.Caption = "班级";
			this.bandedGridColumn17.FieldName = "info_className";
			this.bandedGridColumn17.Name = "bandedGridColumn17";
			this.bandedGridColumn17.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn17.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn17.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn17.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn17.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn17.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn17.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn17.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn17.Visible = true;
			this.bandedGridColumn17.Width = 65;
			// 
			// bandedGridColumn23
			// 
			this.bandedGridColumn23.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn23.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn23.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn23.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn23.Caption = "幼儿年龄";
			this.bandedGridColumn23.FieldName = "nchsanaly_realage";
			this.bandedGridColumn23.Name = "bandedGridColumn23";
			this.bandedGridColumn23.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn23.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn23.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn23.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn23.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn23.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn23.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn23.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn23.RowIndex = 1;
			this.bandedGridColumn23.Visible = true;
			this.bandedGridColumn23.Width = 64;
			// 
			// bandedGridColumn18
			// 
			this.bandedGridColumn18.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn18.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn18.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn18.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn18.Caption = "性别";
			this.bandedGridColumn18.FieldName = "info_stuGender";
			this.bandedGridColumn18.Name = "bandedGridColumn18";
			this.bandedGridColumn18.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn18.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn18.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn18.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn18.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn18.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn18.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn18.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn18.RowIndex = 1;
			this.bandedGridColumn18.Visible = true;
			this.bandedGridColumn18.Width = 71;
			// 
			// gridBand7
			// 
			this.gridBand7.AppearanceHeader.Options.UseTextOptions = true;
			this.gridBand7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridBand7.Caption = "评测信息";
			this.gridBand7.Columns.Add(this.bandedGridColumn20);
			this.gridBand7.Columns.Add(this.bandedGridColumn21);
			this.gridBand7.Columns.Add(this.bandedGridColumn22);
			this.gridBand7.Columns.Add(this.bandedGridColumn26);
			this.gridBand7.Columns.Add(this.bandedGridColumn29);
			this.gridBand7.Columns.Add(this.bandedGridColumn30);
			this.gridBand7.Columns.Add(this.bandedGridColumn24);
			this.gridBand7.Columns.Add(this.bandedGridColumn25);
			this.gridBand7.Columns.Add(this.bandedGridColumn27);
			this.gridBand7.Columns.Add(this.bandedGridColumn28);
			this.gridBand7.Name = "gridBand7";
			this.gridBand7.Width = 340;
			// 
			// bandedGridColumn20
			// 
			this.bandedGridColumn20.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn20.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn20.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn20.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn20.Caption = "体检日期";
			this.bandedGridColumn20.FieldName = "nchsanaly_checktime";
			this.bandedGridColumn20.Name = "bandedGridColumn20";
			this.bandedGridColumn20.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn20.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn20.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn20.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn20.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn20.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn20.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn20.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn20.Visible = true;
			this.bandedGridColumn20.Width = 80;
			// 
			// bandedGridColumn21
			// 
			this.bandedGridColumn21.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn21.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn21.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn21.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn21.Caption = "身高(cm)";
			this.bandedGridColumn21.FieldName = "nchsanaly_height";
			this.bandedGridColumn21.Name = "bandedGridColumn21";
			this.bandedGridColumn21.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn21.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn21.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn21.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn21.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn21.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn21.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn21.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn21.Visible = true;
			this.bandedGridColumn21.Width = 59;
			// 
			// bandedGridColumn22
			// 
			this.bandedGridColumn22.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn22.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn22.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn22.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn22.Caption = "体重(kg)";
			this.bandedGridColumn22.FieldName = "nchsanaly_weight";
			this.bandedGridColumn22.Name = "bandedGridColumn22";
			this.bandedGridColumn22.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn22.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn22.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn22.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn22.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn22.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn22.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn22.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn22.Visible = true;
			this.bandedGridColumn22.Width = 59;
			// 
			// bandedGridColumn26
			// 
			this.bandedGridColumn26.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn26.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn26.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn26.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn26.Caption = "肥胖";
			this.bandedGridColumn26.FieldName = "nchsanaly_obesity";
			this.bandedGridColumn26.Name = "bandedGridColumn26";
			this.bandedGridColumn26.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn26.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn26.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn26.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn26.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn26.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn26.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn26.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn26.Visible = true;
			this.bandedGridColumn26.Width = 62;
			// 
			// bandedGridColumn29
			// 
			this.bandedGridColumn29.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn29.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn29.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn29.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn29.Caption = "消瘦";
			this.bandedGridColumn29.FieldName = "nchsanaly_wasting";
			this.bandedGridColumn29.Name = "bandedGridColumn29";
			this.bandedGridColumn29.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn29.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn29.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn29.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn29.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn29.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn29.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn29.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn29.Visible = true;
			this.bandedGridColumn29.Width = 80;
			// 
			// bandedGridColumn30
			// 
			this.bandedGridColumn30.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn30.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn30.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn30.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn30.Caption = "体重低下";
			this.bandedGridColumn30.FieldName = "nchsanaly_underweight";
			this.bandedGridColumn30.MinWidth = 10;
			this.bandedGridColumn30.Name = "bandedGridColumn30";
			this.bandedGridColumn30.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn30.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn30.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn30.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn30.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn30.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn30.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn30.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn30.RowIndex = 1;
			this.bandedGridColumn30.Visible = true;
			this.bandedGridColumn30.Width = 80;
			// 
			// bandedGridColumn24
			// 
			this.bandedGridColumn24.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn24.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn24.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn24.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn24.Caption = "身高评价";
			this.bandedGridColumn24.FieldName = "nchsanaly_heightresult";
			this.bandedGridColumn24.Name = "bandedGridColumn24";
			this.bandedGridColumn24.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn24.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn24.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn24.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn24.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn24.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn24.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn24.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn24.RowIndex = 1;
			this.bandedGridColumn24.Visible = true;
			this.bandedGridColumn24.Width = 59;
			// 
			// bandedGridColumn25
			// 
			this.bandedGridColumn25.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn25.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn25.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn25.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn25.Caption = "体重评价";
			this.bandedGridColumn25.FieldName = "nchsanaly_weightresult";
			this.bandedGridColumn25.Name = "bandedGridColumn25";
			this.bandedGridColumn25.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn25.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn25.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn25.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn25.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn25.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn25.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn25.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn25.RowIndex = 1;
			this.bandedGridColumn25.Visible = true;
			this.bandedGridColumn25.Width = 59;
			// 
			// bandedGridColumn27
			// 
			this.bandedGridColumn27.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn27.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn27.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn27.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn27.Caption = "营养";
			this.bandedGridColumn27.FieldName = "nchsanaly_nut";
			this.bandedGridColumn27.Name = "bandedGridColumn27";
			this.bandedGridColumn27.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn27.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn27.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn27.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn27.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn27.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn27.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn27.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn27.RowIndex = 1;
			this.bandedGridColumn27.Visible = true;
			this.bandedGridColumn27.Width = 62;
			// 
			// bandedGridColumn28
			// 
			this.bandedGridColumn28.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn28.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn28.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn28.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn28.Caption = "发育";
			this.bandedGridColumn28.FieldName = "nchsanaly_stunting";
			this.bandedGridColumn28.Name = "bandedGridColumn28";
			this.bandedGridColumn28.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn28.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn28.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn28.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn28.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn28.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn28.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn28.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn28.RowIndex = 1;
			this.bandedGridColumn28.Visible = true;
			this.bandedGridColumn28.Width = 80;
			// 
			// gridControl_HOutputGridShow
			// 
			this.gridControl_HOutputGridShow.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl_HOutputGridShow.EmbeddedNavigator
			// 
			this.gridControl_HOutputGridShow.EmbeddedNavigator.Name = "";
			this.gridControl_HOutputGridShow.Location = new System.Drawing.Point(0, 48);
			this.gridControl_HOutputGridShow.MainView = this.advBandedGridView1;
			this.gridControl_HOutputGridShow.Name = "gridControl_HOutputGridShow";
			this.gridControl_HOutputGridShow.Size = new System.Drawing.Size(508, 461);
			this.gridControl_HOutputGridShow.TabIndex = 1;
			this.gridControl_HOutputGridShow.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																													   this.advBandedGridView1});
			// 
			// advBandedGridView1
			// 
			this.advBandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
																										   this.gridBand1,
																										   this.gridBand2,
																										   this.gridBand3,
																										   this.gridBand4});
			this.advBandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
																													 this.bandedGridColumn2,
																													 this.bandedGridColumn3,
																													 this.bandedGridColumn4,
																													 this.bandedGridColumn5,
																													 this.bandedGridColumn6,
																													 this.bandedGridColumn7,
																													 this.bandedGridColumn8,
																													 this.bandedGridColumn9,
																													 this.bandedGridColumn10,
																													 this.bandedGridColumn11,
																													 this.bandedGridColumn12,
																													 this.bandedGridColumn13,
																													 this.bandedGridColumn14,
																													 this.bandedGridColumn15});
			this.advBandedGridView1.GridControl = this.gridControl_HOutputGridShow;
			this.advBandedGridView1.Name = "advBandedGridView1";
			this.advBandedGridView1.OptionsCustomization.AllowFilter = false;
			this.advBandedGridView1.OptionsView.ShowFilterPanel = false;
			this.advBandedGridView1.OptionsView.ShowGroupPanel = false;
			// 
			// gridBand1
			// 
			this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
			this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridBand1.Caption = "基本信息";
			this.gridBand1.Columns.Add(this.bandedGridColumn4);
			this.gridBand1.Name = "gridBand1";
			this.gridBand1.Width = 59;
			// 
			// bandedGridColumn4
			// 
			this.bandedGridColumn4.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn4.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn4.AutoFillDown = true;
			this.bandedGridColumn4.Caption = "姓名";
			this.bandedGridColumn4.FieldName = "info_stuName";
			this.bandedGridColumn4.Name = "bandedGridColumn4";
			this.bandedGridColumn4.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn4.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn4.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn4.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn4.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn4.OptionsColumn.AllowMove = false;
			this.bandedGridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn4.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn4.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn4.Visible = true;
			this.bandedGridColumn4.Width = 59;
			// 
			// gridBand2
			// 
			this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
			this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridBand2.Caption = "扩展信息";
			this.gridBand2.Columns.Add(this.bandedGridColumn2);
			this.gridBand2.Columns.Add(this.bandedGridColumn5);
			this.gridBand2.Columns.Add(this.bandedGridColumn6);
			this.gridBand2.Columns.Add(this.bandedGridColumn3);
			this.gridBand2.Name = "gridBand2";
			this.gridBand2.Width = 123;
			// 
			// bandedGridColumn2
			// 
			this.bandedGridColumn2.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn2.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn2.Caption = "学号";
			this.bandedGridColumn2.FieldName = "HealthAnaly_StuID";
			this.bandedGridColumn2.MinWidth = 10;
			this.bandedGridColumn2.Name = "bandedGridColumn2";
			this.bandedGridColumn2.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn2.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn2.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn2.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn2.OptionsColumn.AllowMove = false;
			this.bandedGridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.bandedGridColumn2.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn2.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn2.Visible = true;
			this.bandedGridColumn2.Width = 58;
			// 
			// bandedGridColumn5
			// 
			this.bandedGridColumn5.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn5.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn5.Caption = "性别";
			this.bandedGridColumn5.FieldName = "info_stuGender";
			this.bandedGridColumn5.MinWidth = 10;
			this.bandedGridColumn5.Name = "bandedGridColumn5";
			this.bandedGridColumn5.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn5.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn5.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn5.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn5.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn5.OptionsColumn.AllowMove = false;
			this.bandedGridColumn5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn5.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn5.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn5.RowIndex = 1;
			this.bandedGridColumn5.Visible = true;
			this.bandedGridColumn5.Width = 58;
			// 
			// bandedGridColumn6
			// 
			this.bandedGridColumn6.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn6.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn6.Caption = "出生年月";
			this.bandedGridColumn6.FieldName = "info_stuBirthday";
			this.bandedGridColumn6.Name = "bandedGridColumn6";
			this.bandedGridColumn6.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn6.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn6.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn6.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn6.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn6.OptionsColumn.AllowMove = false;
			this.bandedGridColumn6.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn6.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn6.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn6.RowIndex = 1;
			this.bandedGridColumn6.Visible = true;
			this.bandedGridColumn6.Width = 65;
			// 
			// bandedGridColumn3
			// 
			this.bandedGridColumn3.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn3.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn3.Caption = "班级";
			this.bandedGridColumn3.FieldName = "info_className";
			this.bandedGridColumn3.MinWidth = 10;
			this.bandedGridColumn3.Name = "bandedGridColumn3";
			this.bandedGridColumn3.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn3.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn3.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn3.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn3.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn3.OptionsColumn.AllowMove = false;
			this.bandedGridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn3.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn3.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn3.Visible = true;
			this.bandedGridColumn3.Width = 65;
			// 
			// gridBand3
			// 
			this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
			this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridBand3.Caption = "评测信息";
			this.gridBand3.Columns.Add(this.bandedGridColumn7);
			this.gridBand3.Columns.Add(this.bandedGridColumn8);
			this.gridBand3.Columns.Add(this.bandedGridColumn10);
			this.gridBand3.Columns.Add(this.bandedGridColumn12);
			this.gridBand3.Columns.Add(this.bandedGridColumn15);
			this.gridBand3.Columns.Add(this.bandedGridColumn9);
			this.gridBand3.Columns.Add(this.bandedGridColumn11);
			this.gridBand3.Columns.Add(this.bandedGridColumn13);
			this.gridBand3.Name = "gridBand3";
			this.gridBand3.Width = 283;
			// 
			// bandedGridColumn7
			// 
			this.bandedGridColumn7.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn7.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn7.Caption = "体检日期";
			this.bandedGridColumn7.FieldName = "HealthAnaly_CheckTime";
			this.bandedGridColumn7.Name = "bandedGridColumn7";
			this.bandedGridColumn7.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn7.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn7.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn7.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn7.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn7.OptionsColumn.AllowMove = false;
			this.bandedGridColumn7.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn7.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn7.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn7.Visible = true;
			this.bandedGridColumn7.Width = 70;
			// 
			// bandedGridColumn8
			// 
			this.bandedGridColumn8.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn8.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn8.Caption = "身高(cm)";
			this.bandedGridColumn8.FieldName = "HealthAnaly_Height";
			this.bandedGridColumn8.Name = "bandedGridColumn8";
			this.bandedGridColumn8.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn8.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn8.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn8.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn8.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn8.OptionsColumn.AllowMove = false;
			this.bandedGridColumn8.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn8.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn8.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn8.Visible = true;
			this.bandedGridColumn8.Width = 65;
			// 
			// bandedGridColumn10
			// 
			this.bandedGridColumn10.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn10.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn10.Caption = "体重(kg)";
			this.bandedGridColumn10.FieldName = "HealthAnaly_Weight";
			this.bandedGridColumn10.MinWidth = 10;
			this.bandedGridColumn10.Name = "bandedGridColumn10";
			this.bandedGridColumn10.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn10.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn10.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn10.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn10.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn10.OptionsColumn.AllowMove = false;
			this.bandedGridColumn10.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn10.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn10.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn10.Visible = true;
			this.bandedGridColumn10.Width = 62;
			// 
			// bandedGridColumn12
			// 
			this.bandedGridColumn12.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn12.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn12.Caption = "肥胖";
			this.bandedGridColumn12.FieldName = "HealthAnaly_FatCircs";
			this.bandedGridColumn12.Name = "bandedGridColumn12";
			this.bandedGridColumn12.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn12.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn12.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn12.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn12.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn12.OptionsColumn.AllowMove = false;
			this.bandedGridColumn12.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn12.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn12.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn12.Visible = true;
			this.bandedGridColumn12.Width = 86;
			// 
			// bandedGridColumn15
			// 
			this.bandedGridColumn15.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn15.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn15.Caption = "幼儿年龄";
			this.bandedGridColumn15.FieldName = "HealthAnaly_RealAge";
			this.bandedGridColumn15.MinWidth = 10;
			this.bandedGridColumn15.Name = "bandedGridColumn15";
			this.bandedGridColumn15.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn15.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn15.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn15.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn15.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn15.OptionsColumn.AllowMove = false;
			this.bandedGridColumn15.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn15.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn15.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn15.RowIndex = 1;
			this.bandedGridColumn15.Visible = true;
			this.bandedGridColumn15.Width = 70;
			// 
			// bandedGridColumn9
			// 
			this.bandedGridColumn9.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn9.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn9.Caption = "身高评价";
			this.bandedGridColumn9.FieldName = "HealthAnaly_HeightAnaly";
			this.bandedGridColumn9.MinWidth = 10;
			this.bandedGridColumn9.Name = "bandedGridColumn9";
			this.bandedGridColumn9.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn9.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn9.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn9.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn9.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn9.OptionsColumn.AllowMove = false;
			this.bandedGridColumn9.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn9.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn9.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn9.RowIndex = 1;
			this.bandedGridColumn9.Visible = true;
			this.bandedGridColumn9.Width = 65;
			// 
			// bandedGridColumn11
			// 
			this.bandedGridColumn11.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn11.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn11.Caption = "体重评价";
			this.bandedGridColumn11.FieldName = "HealthAnaly_WeightAnaly";
			this.bandedGridColumn11.Name = "bandedGridColumn11";
			this.bandedGridColumn11.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn11.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn11.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn11.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn11.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn11.OptionsColumn.AllowMove = false;
			this.bandedGridColumn11.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn11.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn11.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn11.RowIndex = 1;
			this.bandedGridColumn11.Visible = true;
			this.bandedGridColumn11.Width = 62;
			// 
			// bandedGridColumn13
			// 
			this.bandedGridColumn13.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn13.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn13.Caption = "营养";
			this.bandedGridColumn13.FieldName = "HealthAnaly_NutCircs";
			this.bandedGridColumn13.MinWidth = 10;
			this.bandedGridColumn13.Name = "bandedGridColumn13";
			this.bandedGridColumn13.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn13.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn13.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn13.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn13.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn13.OptionsColumn.AllowMove = false;
			this.bandedGridColumn13.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn13.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn13.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn13.RowIndex = 1;
			this.bandedGridColumn13.Visible = true;
			this.bandedGridColumn13.Width = 86;
			// 
			// gridBand4
			// 
			this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
			this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridBand4.Caption = "备注信息";
			this.gridBand4.Columns.Add(this.bandedGridColumn14);
			this.gridBand4.Name = "gridBand4";
			this.gridBand4.Width = 75;
			// 
			// bandedGridColumn14
			// 
			this.bandedGridColumn14.AppearanceCell.Options.UseTextOptions = true;
			this.bandedGridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn14.AppearanceHeader.Options.UseTextOptions = true;
			this.bandedGridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.bandedGridColumn14.AutoFillDown = true;
			this.bandedGridColumn14.Caption = "备注";
			this.bandedGridColumn14.FieldName = "HealthAnaly_Remark";
			this.bandedGridColumn14.Name = "bandedGridColumn14";
			this.bandedGridColumn14.OptionsColumn.AllowEdit = false;
			this.bandedGridColumn14.OptionsColumn.AllowFocus = false;
			this.bandedGridColumn14.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn14.OptionsColumn.AllowIncrementalSearch = false;
			this.bandedGridColumn14.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn14.OptionsColumn.AllowMove = false;
			this.bandedGridColumn14.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.bandedGridColumn14.OptionsColumn.ReadOnly = true;
			this.bandedGridColumn14.OptionsColumn.ShowInCustomizationForm = false;
			this.bandedGridColumn14.Visible = true;
			// 
			// panelControl6
			// 
			this.panelControl6.Controls.Add(this.simpleButton_HOutputSearch);
			this.panelControl6.Controls.Add(this.simpleButton_HOutputPrint);
			this.panelControl6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl6.Location = new System.Drawing.Point(0, 0);
			this.panelControl6.Name = "panelControl6";
			this.panelControl6.Size = new System.Drawing.Size(508, 48);
			this.panelControl6.TabIndex = 0;
			this.panelControl6.Text = "panelControl6";
			// 
			// simpleButton_HOutputSearch
			// 
			this.simpleButton_HOutputSearch.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_HOutputSearch.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_HOutputSearch.Appearance.Options.UseFont = true;
			this.simpleButton_HOutputSearch.Appearance.Options.UseForeColor = true;
			this.simpleButton_HOutputSearch.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_HOutputSearch.Image")));
			this.simpleButton_HOutputSearch.Location = new System.Drawing.Point(16, 8);
			this.simpleButton_HOutputSearch.Name = "simpleButton_HOutputSearch";
			this.simpleButton_HOutputSearch.Size = new System.Drawing.Size(96, 26);
			this.simpleButton_HOutputSearch.TabIndex = 14;
			this.simpleButton_HOutputSearch.Tag = 4;
			this.simpleButton_HOutputSearch.Text = "检  索";
			this.simpleButton_HOutputSearch.Click += new System.EventHandler(this.simpleButton_HOutputSearch_Click);
			// 
			// simpleButton_HOutputPrint
			// 
			this.simpleButton_HOutputPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_HOutputPrint.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_HOutputPrint.Appearance.Options.UseFont = true;
			this.simpleButton_HOutputPrint.Appearance.Options.UseForeColor = true;
			this.simpleButton_HOutputPrint.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_HOutputPrint.Image")));
			this.simpleButton_HOutputPrint.Location = new System.Drawing.Point(128, 8);
			this.simpleButton_HOutputPrint.Name = "simpleButton_HOutputPrint";
			this.simpleButton_HOutputPrint.Size = new System.Drawing.Size(96, 26);
			this.simpleButton_HOutputPrint.TabIndex = 12;
			this.simpleButton_HOutputPrint.Tag = 4;
			this.simpleButton_HOutputPrint.Text = "报  表";
			this.simpleButton_HOutputPrint.Click += new System.EventHandler(this.simpleButton_HOutputPrint_Click);
			// 
			// xtraTabPage7
			// 
			this.xtraTabPage7.Controls.Add(this.splitContainerControl8);
			this.xtraTabPage7.Name = "xtraTabPage7";
			this.xtraTabPage7.Size = new System.Drawing.Size(768, 515);
			this.xtraTabPage7.Text = "晨检及全日观察";
			// 
			// splitContainerControl8
			// 
			this.splitContainerControl8.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl8.Location = new System.Drawing.Point(0, 0);
			this.splitContainerControl8.Name = "splitContainerControl8";
			this.splitContainerControl8.Panel1.Controls.Add(this.groupControl_WatchMorningRec);
			this.splitContainerControl8.Panel1.Controls.Add(this.groupControl_WatchStuList);
			this.splitContainerControl8.Panel1.Controls.Add(this.groupControl_WatchSer);
			this.splitContainerControl8.Panel1.Text = "splitContainerControl8_Panel1";
			this.splitContainerControl8.Panel2.Controls.Add(this.groupControl_WatchWholeDay);
			this.splitContainerControl8.Panel2.Controls.Add(this.groupControl_WatchRecList);
			this.splitContainerControl8.Panel2.Controls.Add(this.panelControl7);
			this.splitContainerControl8.Panel2.Text = "splitContainerControl8_Panel2";
			this.splitContainerControl8.Size = new System.Drawing.Size(768, 515);
			this.splitContainerControl8.SplitterPosition = 294;
			this.splitContainerControl8.TabIndex = 0;
			this.splitContainerControl8.Text = "splitContainerControl8";
			// 
			// groupControl_WatchMorningRec
			// 
			this.groupControl_WatchMorningRec.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_WatchMorningRec.AppearanceCaption.Options.UseFont = true;
			this.groupControl_WatchMorningRec.Controls.Add(this.textEdit_WatchMorningTreat);
			this.groupControl_WatchMorningRec.Controls.Add(this.notePanel_WatchMorningTreat);
			this.groupControl_WatchMorningRec.Controls.Add(this.textEdit_WatchMorningOState);
			this.groupControl_WatchMorningRec.Controls.Add(this.notePanel_WatchMorningOState);
			this.groupControl_WatchMorningRec.Controls.Add(this.notePanel_WatchMorningMouth);
			this.groupControl_WatchMorningRec.Controls.Add(this.comboBoxEdit_WatchMorningHeat);
			this.groupControl_WatchMorningRec.Controls.Add(this.comboBoxEdit_WatchMorningMouth);
			this.groupControl_WatchMorningRec.Controls.Add(this.comboBoxEdit_WatchMorningSpirit);
			this.groupControl_WatchMorningRec.Controls.Add(this.notePanel_WatchMorningHeat);
			this.groupControl_WatchMorningRec.Controls.Add(this.notePanel_WatchMorningSkin);
			this.groupControl_WatchMorningRec.Controls.Add(this.comboBoxEdit_WatchMorningSkin);
			this.groupControl_WatchMorningRec.Controls.Add(this.notePanel_WatchMorningSpirit);
			this.groupControl_WatchMorningRec.Controls.Add(this.textEdit_WatchMorningNumber);
			this.groupControl_WatchMorningRec.Controls.Add(this.textEdit_WatchMorningName);
			this.groupControl_WatchMorningRec.Controls.Add(this.notePanel_WatchMorningNumber);
			this.groupControl_WatchMorningRec.Controls.Add(this.notePanel_WatchMorningName);
			this.groupControl_WatchMorningRec.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_WatchMorningRec.Location = new System.Drawing.Point(0, 280);
			this.groupControl_WatchMorningRec.Name = "groupControl_WatchMorningRec";
			this.groupControl_WatchMorningRec.Size = new System.Drawing.Size(288, 248);
			this.groupControl_WatchMorningRec.TabIndex = 30;
			this.groupControl_WatchMorningRec.Text = "晨检检查情况";
			this.groupControl_WatchMorningRec.Visible = false;
			// 
			// textEdit_WatchMorningTreat
			// 
			this.textEdit_WatchMorningTreat.EditValue = "";
			this.textEdit_WatchMorningTreat.Location = new System.Drawing.Point(80, 200);
			this.textEdit_WatchMorningTreat.Name = "textEdit_WatchMorningTreat";
			this.textEdit_WatchMorningTreat.Size = new System.Drawing.Size(184, 23);
			this.textEdit_WatchMorningTreat.TabIndex = 85;
			// 
			// notePanel_WatchMorningTreat
			// 
			this.notePanel_WatchMorningTreat.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_WatchMorningTreat.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_WatchMorningTreat.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_WatchMorningTreat.ForeColor = System.Drawing.Color.Black;
			this.notePanel_WatchMorningTreat.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_WatchMorningTreat.Location = new System.Drawing.Point(16, 200);
			this.notePanel_WatchMorningTreat.MaxRows = 5;
			this.notePanel_WatchMorningTreat.Name = "notePanel_WatchMorningTreat";
			this.notePanel_WatchMorningTreat.ParentAutoHeight = true;
			this.notePanel_WatchMorningTreat.Size = new System.Drawing.Size(56, 22);
			this.notePanel_WatchMorningTreat.TabIndex = 84;
			this.notePanel_WatchMorningTreat.TabStop = false;
			this.notePanel_WatchMorningTreat.Text = "处理:";
			// 
			// textEdit_WatchMorningOState
			// 
			this.textEdit_WatchMorningOState.EditValue = "";
			this.textEdit_WatchMorningOState.Location = new System.Drawing.Point(80, 160);
			this.textEdit_WatchMorningOState.Name = "textEdit_WatchMorningOState";
			this.textEdit_WatchMorningOState.Size = new System.Drawing.Size(184, 23);
			this.textEdit_WatchMorningOState.TabIndex = 83;
			// 
			// notePanel_WatchMorningOState
			// 
			this.notePanel_WatchMorningOState.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_WatchMorningOState.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_WatchMorningOState.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_WatchMorningOState.ForeColor = System.Drawing.Color.Black;
			this.notePanel_WatchMorningOState.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_WatchMorningOState.Location = new System.Drawing.Point(16, 160);
			this.notePanel_WatchMorningOState.MaxRows = 5;
			this.notePanel_WatchMorningOState.Name = "notePanel_WatchMorningOState";
			this.notePanel_WatchMorningOState.ParentAutoHeight = true;
			this.notePanel_WatchMorningOState.Size = new System.Drawing.Size(56, 22);
			this.notePanel_WatchMorningOState.TabIndex = 82;
			this.notePanel_WatchMorningOState.TabStop = false;
			this.notePanel_WatchMorningOState.Text = "代诉:";
			// 
			// notePanel_WatchMorningMouth
			// 
			this.notePanel_WatchMorningMouth.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_WatchMorningMouth.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_WatchMorningMouth.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_WatchMorningMouth.ForeColor = System.Drawing.Color.Black;
			this.notePanel_WatchMorningMouth.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_WatchMorningMouth.Location = new System.Drawing.Point(16, 120);
			this.notePanel_WatchMorningMouth.MaxRows = 5;
			this.notePanel_WatchMorningMouth.Name = "notePanel_WatchMorningMouth";
			this.notePanel_WatchMorningMouth.ParentAutoHeight = true;
			this.notePanel_WatchMorningMouth.Size = new System.Drawing.Size(56, 22);
			this.notePanel_WatchMorningMouth.TabIndex = 78;
			this.notePanel_WatchMorningMouth.TabStop = false;
			this.notePanel_WatchMorningMouth.Text = "口腔:";
			// 
			// comboBoxEdit_WatchMorningHeat
			// 
			this.comboBoxEdit_WatchMorningHeat.EditValue = "正常";
			this.comboBoxEdit_WatchMorningHeat.Location = new System.Drawing.Point(80, 80);
			this.comboBoxEdit_WatchMorningHeat.Name = "comboBoxEdit_WatchMorningHeat";
			// 
			// comboBoxEdit_WatchMorningHeat.Properties
			// 
			this.comboBoxEdit_WatchMorningHeat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_WatchMorningHeat.Properties.Items.AddRange(new object[] {
																						  "正常",
																						  "偏高",
																						  "偏低"});
			this.comboBoxEdit_WatchMorningHeat.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_WatchMorningHeat.Size = new System.Drawing.Size(56, 23);
			this.comboBoxEdit_WatchMorningHeat.TabIndex = 76;
			// 
			// comboBoxEdit_WatchMorningMouth
			// 
			this.comboBoxEdit_WatchMorningMouth.EditValue = "好";
			this.comboBoxEdit_WatchMorningMouth.Location = new System.Drawing.Point(80, 120);
			this.comboBoxEdit_WatchMorningMouth.Name = "comboBoxEdit_WatchMorningMouth";
			// 
			// comboBoxEdit_WatchMorningMouth.Properties
			// 
			this.comboBoxEdit_WatchMorningMouth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_WatchMorningMouth.Properties.Items.AddRange(new object[] {
																						   "好",
																						   "中",
																						   "差"});
			this.comboBoxEdit_WatchMorningMouth.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_WatchMorningMouth.Size = new System.Drawing.Size(56, 23);
			this.comboBoxEdit_WatchMorningMouth.TabIndex = 81;
			// 
			// comboBoxEdit_WatchMorningSpirit
			// 
			this.comboBoxEdit_WatchMorningSpirit.EditValue = "好";
			this.comboBoxEdit_WatchMorningSpirit.Location = new System.Drawing.Point(208, 80);
			this.comboBoxEdit_WatchMorningSpirit.Name = "comboBoxEdit_WatchMorningSpirit";
			// 
			// comboBoxEdit_WatchMorningSpirit.Properties
			// 
			this.comboBoxEdit_WatchMorningSpirit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																	new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_WatchMorningSpirit.Properties.Items.AddRange(new object[] {
																							"好",
																							"中",
																							"差"});
			this.comboBoxEdit_WatchMorningSpirit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_WatchMorningSpirit.Size = new System.Drawing.Size(56, 23);
			this.comboBoxEdit_WatchMorningSpirit.TabIndex = 77;
			// 
			// notePanel_WatchMorningHeat
			// 
			this.notePanel_WatchMorningHeat.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_WatchMorningHeat.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_WatchMorningHeat.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_WatchMorningHeat.ForeColor = System.Drawing.Color.Black;
			this.notePanel_WatchMorningHeat.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_WatchMorningHeat.Location = new System.Drawing.Point(16, 80);
			this.notePanel_WatchMorningHeat.MaxRows = 5;
			this.notePanel_WatchMorningHeat.Name = "notePanel_WatchMorningHeat";
			this.notePanel_WatchMorningHeat.ParentAutoHeight = true;
			this.notePanel_WatchMorningHeat.Size = new System.Drawing.Size(56, 22);
			this.notePanel_WatchMorningHeat.TabIndex = 74;
			this.notePanel_WatchMorningHeat.TabStop = false;
			this.notePanel_WatchMorningHeat.Text = "体温:";
			// 
			// notePanel_WatchMorningSkin
			// 
			this.notePanel_WatchMorningSkin.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_WatchMorningSkin.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_WatchMorningSkin.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_WatchMorningSkin.ForeColor = System.Drawing.Color.Black;
			this.notePanel_WatchMorningSkin.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_WatchMorningSkin.Location = new System.Drawing.Point(144, 120);
			this.notePanel_WatchMorningSkin.MaxRows = 5;
			this.notePanel_WatchMorningSkin.Name = "notePanel_WatchMorningSkin";
			this.notePanel_WatchMorningSkin.ParentAutoHeight = true;
			this.notePanel_WatchMorningSkin.Size = new System.Drawing.Size(56, 22);
			this.notePanel_WatchMorningSkin.TabIndex = 79;
			this.notePanel_WatchMorningSkin.TabStop = false;
			this.notePanel_WatchMorningSkin.Text = "皮肤:";
			// 
			// comboBoxEdit_WatchMorningSkin
			// 
			this.comboBoxEdit_WatchMorningSkin.EditValue = "好";
			this.comboBoxEdit_WatchMorningSkin.Location = new System.Drawing.Point(208, 120);
			this.comboBoxEdit_WatchMorningSkin.Name = "comboBoxEdit_WatchMorningSkin";
			// 
			// comboBoxEdit_WatchMorningSkin.Properties
			// 
			this.comboBoxEdit_WatchMorningSkin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_WatchMorningSkin.Properties.Items.AddRange(new object[] {
																						  "好",
																						  "中",
																						  "差"});
			this.comboBoxEdit_WatchMorningSkin.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_WatchMorningSkin.Size = new System.Drawing.Size(56, 23);
			this.comboBoxEdit_WatchMorningSkin.TabIndex = 80;
			// 
			// notePanel_WatchMorningSpirit
			// 
			this.notePanel_WatchMorningSpirit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_WatchMorningSpirit.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_WatchMorningSpirit.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_WatchMorningSpirit.ForeColor = System.Drawing.Color.Black;
			this.notePanel_WatchMorningSpirit.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_WatchMorningSpirit.Location = new System.Drawing.Point(144, 80);
			this.notePanel_WatchMorningSpirit.MaxRows = 5;
			this.notePanel_WatchMorningSpirit.Name = "notePanel_WatchMorningSpirit";
			this.notePanel_WatchMorningSpirit.ParentAutoHeight = true;
			this.notePanel_WatchMorningSpirit.Size = new System.Drawing.Size(56, 22);
			this.notePanel_WatchMorningSpirit.TabIndex = 75;
			this.notePanel_WatchMorningSpirit.TabStop = false;
			this.notePanel_WatchMorningSpirit.Text = "精神:";
			// 
			// textEdit_WatchMorningNumber
			// 
			this.textEdit_WatchMorningNumber.EditValue = "";
			this.textEdit_WatchMorningNumber.Location = new System.Drawing.Point(208, 40);
			this.textEdit_WatchMorningNumber.Name = "textEdit_WatchMorningNumber";
			// 
			// textEdit_WatchMorningNumber.Properties
			// 
			this.textEdit_WatchMorningNumber.Properties.Enabled = false;
			this.textEdit_WatchMorningNumber.Size = new System.Drawing.Size(56, 23);
			this.textEdit_WatchMorningNumber.TabIndex = 60;
			// 
			// textEdit_WatchMorningName
			// 
			this.textEdit_WatchMorningName.EditValue = "";
			this.textEdit_WatchMorningName.Location = new System.Drawing.Point(80, 40);
			this.textEdit_WatchMorningName.Name = "textEdit_WatchMorningName";
			// 
			// textEdit_WatchMorningName.Properties
			// 
			this.textEdit_WatchMorningName.Properties.Enabled = false;
			this.textEdit_WatchMorningName.Size = new System.Drawing.Size(56, 23);
			this.textEdit_WatchMorningName.TabIndex = 59;
			// 
			// notePanel_WatchMorningNumber
			// 
			this.notePanel_WatchMorningNumber.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_WatchMorningNumber.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_WatchMorningNumber.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_WatchMorningNumber.ForeColor = System.Drawing.Color.Black;
			this.notePanel_WatchMorningNumber.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_WatchMorningNumber.Location = new System.Drawing.Point(144, 40);
			this.notePanel_WatchMorningNumber.MaxRows = 5;
			this.notePanel_WatchMorningNumber.Name = "notePanel_WatchMorningNumber";
			this.notePanel_WatchMorningNumber.ParentAutoHeight = true;
			this.notePanel_WatchMorningNumber.Size = new System.Drawing.Size(56, 22);
			this.notePanel_WatchMorningNumber.TabIndex = 58;
			this.notePanel_WatchMorningNumber.TabStop = false;
			this.notePanel_WatchMorningNumber.Text = "学号:";
			// 
			// notePanel_WatchMorningName
			// 
			this.notePanel_WatchMorningName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_WatchMorningName.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_WatchMorningName.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_WatchMorningName.ForeColor = System.Drawing.Color.Black;
			this.notePanel_WatchMorningName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_WatchMorningName.Location = new System.Drawing.Point(16, 40);
			this.notePanel_WatchMorningName.MaxRows = 5;
			this.notePanel_WatchMorningName.Name = "notePanel_WatchMorningName";
			this.notePanel_WatchMorningName.ParentAutoHeight = true;
			this.notePanel_WatchMorningName.Size = new System.Drawing.Size(56, 22);
			this.notePanel_WatchMorningName.TabIndex = 57;
			this.notePanel_WatchMorningName.TabStop = false;
			this.notePanel_WatchMorningName.Text = "姓名:";
			// 
			// groupControl_WatchStuList
			// 
			this.groupControl_WatchStuList.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_WatchStuList.AppearanceCaption.Options.UseFont = true;
			this.groupControl_WatchStuList.Controls.Add(this.gridControl_WatchStuList);
			this.groupControl_WatchStuList.Controls.Add(this.notePanel_WatchStuList);
			this.groupControl_WatchStuList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl_WatchStuList.Location = new System.Drawing.Point(0, 280);
			this.groupControl_WatchStuList.Name = "groupControl_WatchStuList";
			this.groupControl_WatchStuList.Size = new System.Drawing.Size(288, 229);
			this.groupControl_WatchStuList.TabIndex = 1;
			this.groupControl_WatchStuList.Text = "今天入园幼儿记录";
			// 
			// gridControl_WatchStuList
			// 
			this.gridControl_WatchStuList.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl_WatchStuList.EmbeddedNavigator
			// 
			this.gridControl_WatchStuList.EmbeddedNavigator.Name = "";
			this.gridControl_WatchStuList.Location = new System.Drawing.Point(3, 41);
			this.gridControl_WatchStuList.MainView = this.gridView7;
			this.gridControl_WatchStuList.Name = "gridControl_WatchStuList";
			this.gridControl_WatchStuList.Size = new System.Drawing.Size(282, 185);
			this.gridControl_WatchStuList.TabIndex = 25;
			this.gridControl_WatchStuList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																													this.gridView7});
			this.gridControl_WatchStuList.DoubleClick += new System.EventHandler(this.gridControl_WatchStuList_DoubleClick);
			// 
			// gridView7
			// 
			this.gridView7.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn24,
																							 this.gridColumn25,
																							 this.gridColumn26,
																							 this.gridColumn27,
																							 this.gridColumn28});
			this.gridView7.GridControl = this.gridControl_WatchStuList;
			this.gridView7.Name = "gridView7";
			this.gridView7.OptionsCustomization.AllowFilter = false;
			this.gridView7.OptionsView.ShowFilterPanel = false;
			this.gridView7.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn24
			// 
			this.gridColumn24.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn24.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn24.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn24.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn24.Caption = "学号";
			this.gridColumn24.FieldName = "info_stuNumber";
			this.gridColumn24.Name = "gridColumn24";
			this.gridColumn24.OptionsColumn.AllowEdit = false;
			this.gridColumn24.OptionsColumn.AllowFocus = false;
			this.gridColumn24.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn24.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn24.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn24.OptionsColumn.AllowMove = false;
			this.gridColumn24.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn24.OptionsColumn.ReadOnly = true;
			this.gridColumn24.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn24.Visible = true;
			this.gridColumn24.VisibleIndex = 0;
			// 
			// gridColumn25
			// 
			this.gridColumn25.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn25.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn25.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn25.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn25.Caption = "姓名";
			this.gridColumn25.FieldName = "info_stuName";
			this.gridColumn25.Name = "gridColumn25";
			this.gridColumn25.OptionsColumn.AllowEdit = false;
			this.gridColumn25.OptionsColumn.AllowFocus = false;
			this.gridColumn25.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn25.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn25.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn25.OptionsColumn.AllowMove = false;
			this.gridColumn25.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn25.OptionsColumn.ReadOnly = true;
			this.gridColumn25.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn25.Visible = true;
			this.gridColumn25.VisibleIndex = 1;
			// 
			// gridColumn26
			// 
			this.gridColumn26.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn26.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn26.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn26.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn26.Caption = "班级";
			this.gridColumn26.FieldName = "info_className";
			this.gridColumn26.Name = "gridColumn26";
			this.gridColumn26.OptionsColumn.AllowEdit = false;
			this.gridColumn26.OptionsColumn.AllowFocus = false;
			this.gridColumn26.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn26.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn26.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn26.OptionsColumn.AllowMove = false;
			this.gridColumn26.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn26.OptionsColumn.ReadOnly = true;
			this.gridColumn26.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn26.Visible = true;
			this.gridColumn26.VisibleIndex = 2;
			// 
			// gridColumn27
			// 
			this.gridColumn27.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn27.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn27.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn27.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn27.Caption = "晨检";
			this.gridColumn27.FieldName = "state_flowStateName";
			this.gridColumn27.Name = "gridColumn27";
			this.gridColumn27.OptionsColumn.AllowEdit = false;
			this.gridColumn27.OptionsColumn.AllowFocus = false;
			this.gridColumn27.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn27.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn27.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn27.OptionsColumn.AllowMove = false;
			this.gridColumn27.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn27.OptionsColumn.ReadOnly = true;
			this.gridColumn27.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn27.Visible = true;
			this.gridColumn27.VisibleIndex = 3;
			// 
			// gridColumn28
			// 
			this.gridColumn28.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn28.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn28.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn28.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn28.Caption = "时间";
			this.gridColumn28.FieldName = "flow_stuFlowEnterDate";
			this.gridColumn28.Name = "gridColumn28";
			this.gridColumn28.OptionsColumn.AllowEdit = false;
			this.gridColumn28.OptionsColumn.AllowFocus = false;
			this.gridColumn28.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn28.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn28.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn28.OptionsColumn.AllowMove = false;
			this.gridColumn28.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn28.OptionsColumn.ReadOnly = true;
			this.gridColumn28.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn28.Visible = true;
			this.gridColumn28.VisibleIndex = 4;
			// 
			// notePanel_WatchStuList
			// 
			this.notePanel_WatchStuList.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel_WatchStuList.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel_WatchStuList.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel_WatchStuList.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_WatchStuList.Location = new System.Drawing.Point(3, 18);
			this.notePanel_WatchStuList.MaxRows = 5;
			this.notePanel_WatchStuList.Name = "notePanel_WatchStuList";
			this.notePanel_WatchStuList.ParentAutoHeight = true;
			this.notePanel_WatchStuList.Size = new System.Drawing.Size(282, 23);
			this.notePanel_WatchStuList.TabIndex = 24;
			this.notePanel_WatchStuList.TabStop = false;
			this.notePanel_WatchStuList.Text = "双击进入晨检观察登记";
			// 
			// groupControl_WatchSer
			// 
			this.groupControl_WatchSer.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_WatchSer.AppearanceCaption.Options.UseFont = true;
			this.groupControl_WatchSer.Controls.Add(this.textEdit_WatchName);
			this.groupControl_WatchSer.Controls.Add(this.dateEdit_WatchEndDate);
			this.groupControl_WatchSer.Controls.Add(this.dateEdit_WatchBegDate);
			this.groupControl_WatchSer.Controls.Add(this.notePanel_WatchEndDate);
			this.groupControl_WatchSer.Controls.Add(this.notePanel_WatchBegDate);
			this.groupControl_WatchSer.Controls.Add(this.comboBoxEdit_WatchState);
			this.groupControl_WatchSer.Controls.Add(this.notePanel_WatchState);
			this.groupControl_WatchSer.Controls.Add(this.textEdit_WatchNumber);
			this.groupControl_WatchSer.Controls.Add(this.comboBoxEdit_WatchClass);
			this.groupControl_WatchSer.Controls.Add(this.notePanel_WatchClass);
			this.groupControl_WatchSer.Controls.Add(this.comboBoxEdit_WatchGrade);
			this.groupControl_WatchSer.Controls.Add(this.notePanel_WatchGrade);
			this.groupControl_WatchSer.Controls.Add(this.notePanel_WatchNumber);
			this.groupControl_WatchSer.Controls.Add(this.notePanel_WatchName);
			this.groupControl_WatchSer.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_WatchSer.Location = new System.Drawing.Point(0, 0);
			this.groupControl_WatchSer.Name = "groupControl_WatchSer";
			this.groupControl_WatchSer.Size = new System.Drawing.Size(288, 280);
			this.groupControl_WatchSer.TabIndex = 0;
			this.groupControl_WatchSer.Text = "信息查询";
			// 
			// textEdit_WatchName
			// 
			this.textEdit_WatchName.EditValue = "";
			this.textEdit_WatchName.Location = new System.Drawing.Point(144, 96);
			this.textEdit_WatchName.Name = "textEdit_WatchName";
			this.textEdit_WatchName.Size = new System.Drawing.Size(88, 23);
			this.textEdit_WatchName.TabIndex = 63;
			// 
			// dateEdit_WatchEndDate
			// 
			this.dateEdit_WatchEndDate.EditValue = new System.DateTime(2005, 3, 17, 0, 0, 0, 0);
			this.dateEdit_WatchEndDate.Location = new System.Drawing.Point(144, 238);
			this.dateEdit_WatchEndDate.Name = "dateEdit_WatchEndDate";
			// 
			// dateEdit_WatchEndDate.Properties
			// 
			this.dateEdit_WatchEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																														  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit_WatchEndDate.Properties.Mask.EditMask = "d";
			this.dateEdit_WatchEndDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
			this.dateEdit_WatchEndDate.Size = new System.Drawing.Size(88, 23);
			this.dateEdit_WatchEndDate.TabIndex = 62;
			// 
			// dateEdit_WatchBegDate
			// 
			this.dateEdit_WatchBegDate.EditValue = new System.DateTime(2005, 3, 17, 0, 0, 0, 0);
			this.dateEdit_WatchBegDate.Location = new System.Drawing.Point(144, 196);
			this.dateEdit_WatchBegDate.Name = "dateEdit_WatchBegDate";
			// 
			// dateEdit_WatchBegDate.Properties
			// 
			this.dateEdit_WatchBegDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																														  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit_WatchBegDate.Properties.Mask.EditMask = "d";
			this.dateEdit_WatchBegDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
			this.dateEdit_WatchBegDate.Size = new System.Drawing.Size(88, 23);
			this.dateEdit_WatchBegDate.TabIndex = 61;
			// 
			// notePanel_WatchEndDate
			// 
			this.notePanel_WatchEndDate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_WatchEndDate.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_WatchEndDate.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_WatchEndDate.ForeColor = System.Drawing.Color.Black;
			this.notePanel_WatchEndDate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_WatchEndDate.Location = new System.Drawing.Point(48, 232);
			this.notePanel_WatchEndDate.MaxRows = 5;
			this.notePanel_WatchEndDate.Name = "notePanel_WatchEndDate";
			this.notePanel_WatchEndDate.ParentAutoHeight = true;
			this.notePanel_WatchEndDate.Size = new System.Drawing.Size(80, 35);
			this.notePanel_WatchEndDate.TabIndex = 60;
			this.notePanel_WatchEndDate.TabStop = false;
			this.notePanel_WatchEndDate.Text = "全日观察  截止时间:";
			// 
			// notePanel_WatchBegDate
			// 
			this.notePanel_WatchBegDate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_WatchBegDate.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_WatchBegDate.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_WatchBegDate.ForeColor = System.Drawing.Color.Black;
			this.notePanel_WatchBegDate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_WatchBegDate.Location = new System.Drawing.Point(48, 190);
			this.notePanel_WatchBegDate.MaxRows = 5;
			this.notePanel_WatchBegDate.Name = "notePanel_WatchBegDate";
			this.notePanel_WatchBegDate.ParentAutoHeight = true;
			this.notePanel_WatchBegDate.Size = new System.Drawing.Size(80, 35);
			this.notePanel_WatchBegDate.TabIndex = 59;
			this.notePanel_WatchBegDate.TabStop = false;
			this.notePanel_WatchBegDate.Text = "全日观察  起始时间:";
			// 
			// comboBoxEdit_WatchState
			// 
			this.comboBoxEdit_WatchState.EditValue = "全部";
			this.comboBoxEdit_WatchState.Location = new System.Drawing.Point(144, 160);
			this.comboBoxEdit_WatchState.Name = "comboBoxEdit_WatchState";
			// 
			// comboBoxEdit_WatchState.Properties
			// 
			this.comboBoxEdit_WatchState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_WatchState.Properties.Items.AddRange(new object[] {
																					"全部",
																					"健康",
																					"观察",
																					"服药"});
			this.comboBoxEdit_WatchState.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_WatchState.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_WatchState.TabIndex = 58;
			this.comboBoxEdit_WatchState.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_WatchState_SelectedIndexChanged);
			// 
			// notePanel_WatchState
			// 
			this.notePanel_WatchState.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_WatchState.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_WatchState.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_WatchState.ForeColor = System.Drawing.Color.Black;
			this.notePanel_WatchState.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_WatchState.Location = new System.Drawing.Point(48, 160);
			this.notePanel_WatchState.MaxRows = 5;
			this.notePanel_WatchState.Name = "notePanel_WatchState";
			this.notePanel_WatchState.ParentAutoHeight = true;
			this.notePanel_WatchState.Size = new System.Drawing.Size(80, 22);
			this.notePanel_WatchState.TabIndex = 57;
			this.notePanel_WatchState.TabStop = false;
			this.notePanel_WatchState.Text = "  状  态:";
			// 
			// textEdit_WatchNumber
			// 
			this.textEdit_WatchNumber.EditValue = "";
			this.textEdit_WatchNumber.Location = new System.Drawing.Point(144, 128);
			this.textEdit_WatchNumber.Name = "textEdit_WatchNumber";
			this.textEdit_WatchNumber.Size = new System.Drawing.Size(88, 23);
			this.textEdit_WatchNumber.TabIndex = 56;
			this.textEdit_WatchNumber.EditValueChanged += new System.EventHandler(this.textEdit_WatchNumber_EditValueChanged);
			// 
			// comboBoxEdit_WatchClass
			// 
			this.comboBoxEdit_WatchClass.EditValue = "全部";
			this.comboBoxEdit_WatchClass.Location = new System.Drawing.Point(144, 64);
			this.comboBoxEdit_WatchClass.Name = "comboBoxEdit_WatchClass";
			// 
			// comboBoxEdit_WatchClass.Properties
			// 
			this.comboBoxEdit_WatchClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_WatchClass.Properties.Items.AddRange(new object[] {
																					"全部"});
			this.comboBoxEdit_WatchClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_WatchClass.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_WatchClass.TabIndex = 54;
			this.comboBoxEdit_WatchClass.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_WatchClass_SelectedIndexChanged);
			// 
			// notePanel_WatchClass
			// 
			this.notePanel_WatchClass.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_WatchClass.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_WatchClass.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_WatchClass.ForeColor = System.Drawing.Color.Black;
			this.notePanel_WatchClass.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_WatchClass.Location = new System.Drawing.Point(48, 64);
			this.notePanel_WatchClass.MaxRows = 5;
			this.notePanel_WatchClass.Name = "notePanel_WatchClass";
			this.notePanel_WatchClass.ParentAutoHeight = true;
			this.notePanel_WatchClass.Size = new System.Drawing.Size(80, 22);
			this.notePanel_WatchClass.TabIndex = 53;
			this.notePanel_WatchClass.TabStop = false;
			this.notePanel_WatchClass.Text = "  班  级:";
			// 
			// comboBoxEdit_WatchGrade
			// 
			this.comboBoxEdit_WatchGrade.EditValue = "全部";
			this.comboBoxEdit_WatchGrade.Location = new System.Drawing.Point(144, 32);
			this.comboBoxEdit_WatchGrade.Name = "comboBoxEdit_WatchGrade";
			// 
			// comboBoxEdit_WatchGrade.Properties
			// 
			this.comboBoxEdit_WatchGrade.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_WatchGrade.Properties.Items.AddRange(new object[] {
																					"全部"});
			this.comboBoxEdit_WatchGrade.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_WatchGrade.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_WatchGrade.TabIndex = 52;
			this.comboBoxEdit_WatchGrade.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_WatchGrade_SelectedIndexChanged);
			// 
			// notePanel_WatchGrade
			// 
			this.notePanel_WatchGrade.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_WatchGrade.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_WatchGrade.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_WatchGrade.ForeColor = System.Drawing.Color.Black;
			this.notePanel_WatchGrade.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_WatchGrade.Location = new System.Drawing.Point(48, 32);
			this.notePanel_WatchGrade.MaxRows = 5;
			this.notePanel_WatchGrade.Name = "notePanel_WatchGrade";
			this.notePanel_WatchGrade.ParentAutoHeight = true;
			this.notePanel_WatchGrade.Size = new System.Drawing.Size(80, 22);
			this.notePanel_WatchGrade.TabIndex = 51;
			this.notePanel_WatchGrade.TabStop = false;
			this.notePanel_WatchGrade.Text = "  年  级:";
			// 
			// notePanel_WatchNumber
			// 
			this.notePanel_WatchNumber.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_WatchNumber.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_WatchNumber.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_WatchNumber.ForeColor = System.Drawing.Color.Black;
			this.notePanel_WatchNumber.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_WatchNumber.Location = new System.Drawing.Point(48, 128);
			this.notePanel_WatchNumber.MaxRows = 5;
			this.notePanel_WatchNumber.Name = "notePanel_WatchNumber";
			this.notePanel_WatchNumber.ParentAutoHeight = true;
			this.notePanel_WatchNumber.Size = new System.Drawing.Size(80, 22);
			this.notePanel_WatchNumber.TabIndex = 50;
			this.notePanel_WatchNumber.TabStop = false;
			this.notePanel_WatchNumber.Text = "  学  号:";
			// 
			// notePanel_WatchName
			// 
			this.notePanel_WatchName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_WatchName.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_WatchName.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_WatchName.ForeColor = System.Drawing.Color.Black;
			this.notePanel_WatchName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_WatchName.Location = new System.Drawing.Point(48, 96);
			this.notePanel_WatchName.MaxRows = 5;
			this.notePanel_WatchName.Name = "notePanel_WatchName";
			this.notePanel_WatchName.ParentAutoHeight = true;
			this.notePanel_WatchName.Size = new System.Drawing.Size(80, 22);
			this.notePanel_WatchName.TabIndex = 49;
			this.notePanel_WatchName.TabStop = false;
			this.notePanel_WatchName.Text = "  姓  名:";
			// 
			// groupControl_WatchWholeDay
			// 
			this.groupControl_WatchWholeDay.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_WatchWholeDay.AppearanceCaption.Options.UseFont = true;
			this.groupControl_WatchWholeDay.Controls.Add(this.groupControl_WatchWholDayHandle);
			this.groupControl_WatchWholeDay.Controls.Add(this.groupControl_WatchWholeDayReg);
			this.groupControl_WatchWholeDay.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_WatchWholeDay.Location = new System.Drawing.Point(0, 509);
			this.groupControl_WatchWholeDay.Name = "groupControl_WatchWholeDay";
			this.groupControl_WatchWholeDay.Size = new System.Drawing.Size(464, 336);
			this.groupControl_WatchWholeDay.TabIndex = 2;
			this.groupControl_WatchWholeDay.Text = "全日观察登记";
			this.groupControl_WatchWholeDay.Visible = false;
			// 
			// groupControl_WatchWholDayHandle
			// 
			this.groupControl_WatchWholDayHandle.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_WatchWholDayHandle.AppearanceCaption.Options.UseFont = true;
			this.groupControl_WatchWholDayHandle.Controls.Add(this.checkEdit_WatchWholeDayHeat);
			this.groupControl_WatchWholDayHandle.Controls.Add(this.checkEdit_WatchWholeDayCtrSeafood);
			this.groupControl_WatchWholDayHandle.Controls.Add(this.checkEdit_WatchWholeDayLifeAttention);
			this.groupControl_WatchWholDayHandle.Controls.Add(this.checkEdit_WatchWholeDayCtrAct);
			this.groupControl_WatchWholDayHandle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl_WatchWholDayHandle.Location = new System.Drawing.Point(3, 192);
			this.groupControl_WatchWholDayHandle.Name = "groupControl_WatchWholDayHandle";
			this.groupControl_WatchWholDayHandle.Size = new System.Drawing.Size(458, 141);
			this.groupControl_WatchWholDayHandle.TabIndex = 1;
			this.groupControl_WatchWholDayHandle.Text = "处理情况";
			// 
			// checkEdit_WatchWholeDayHeat
			// 
			this.checkEdit_WatchWholeDayHeat.Location = new System.Drawing.Point(272, 80);
			this.checkEdit_WatchWholeDayHeat.Name = "checkEdit_WatchWholeDayHeat";
			// 
			// checkEdit_WatchWholeDayHeat.Properties
			// 
			this.checkEdit_WatchWholeDayHeat.Properties.Caption = "按时测体温";
			this.checkEdit_WatchWholeDayHeat.Size = new System.Drawing.Size(104, 19);
			this.checkEdit_WatchWholeDayHeat.TabIndex = 3;
			// 
			// checkEdit_WatchWholeDayCtrSeafood
			// 
			this.checkEdit_WatchWholeDayCtrSeafood.Location = new System.Drawing.Point(128, 80);
			this.checkEdit_WatchWholeDayCtrSeafood.Name = "checkEdit_WatchWholeDayCtrSeafood";
			// 
			// checkEdit_WatchWholeDayCtrSeafood.Properties
			// 
			this.checkEdit_WatchWholeDayCtrSeafood.Properties.Caption = "忌海鲜";
			this.checkEdit_WatchWholeDayCtrSeafood.Size = new System.Drawing.Size(104, 19);
			this.checkEdit_WatchWholeDayCtrSeafood.TabIndex = 2;
			// 
			// checkEdit_WatchWholeDayLifeAttention
			// 
			this.checkEdit_WatchWholeDayLifeAttention.Location = new System.Drawing.Point(272, 40);
			this.checkEdit_WatchWholeDayLifeAttention.Name = "checkEdit_WatchWholeDayLifeAttention";
			// 
			// checkEdit_WatchWholeDayLifeAttention.Properties
			// 
			this.checkEdit_WatchWholeDayLifeAttention.Properties.Caption = "注意生活护理";
			this.checkEdit_WatchWholeDayLifeAttention.Size = new System.Drawing.Size(104, 19);
			this.checkEdit_WatchWholeDayLifeAttention.TabIndex = 1;
			// 
			// checkEdit_WatchWholeDayCtrAct
			// 
			this.checkEdit_WatchWholeDayCtrAct.Location = new System.Drawing.Point(128, 40);
			this.checkEdit_WatchWholeDayCtrAct.Name = "checkEdit_WatchWholeDayCtrAct";
			// 
			// checkEdit_WatchWholeDayCtrAct.Properties
			// 
			this.checkEdit_WatchWholeDayCtrAct.Properties.Caption = "控制运动量";
			this.checkEdit_WatchWholeDayCtrAct.Size = new System.Drawing.Size(104, 19);
			this.checkEdit_WatchWholeDayCtrAct.TabIndex = 0;
			// 
			// groupControl_WatchWholeDayReg
			// 
			this.groupControl_WatchWholeDayReg.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_WatchWholeDayReg.AppearanceCaption.Options.UseFont = true;
			this.groupControl_WatchWholeDayReg.Controls.Add(this.textEdit_WatchWholeDayElse);
			this.groupControl_WatchWholeDayReg.Controls.Add(this.notePanel_WatchWholeDayElse);
			this.groupControl_WatchWholeDayReg.Controls.Add(this.comboBoxEdit_WatchWholeDayCough);
			this.groupControl_WatchWholeDayReg.Controls.Add(this.notePanel_WatchWholeDayCough);
			this.groupControl_WatchWholeDayReg.Controls.Add(this.comboBoxEdit_WatchWholeDaySleep);
			this.groupControl_WatchWholeDayReg.Controls.Add(this.notePanel_WatchWholeDaySleep);
			this.groupControl_WatchWholeDayReg.Controls.Add(this.comboBoxEdit_WatchWholeDayStool);
			this.groupControl_WatchWholeDayReg.Controls.Add(this.notePanel_WatchWholeDayStool);
			this.groupControl_WatchWholeDayReg.Controls.Add(this.comboBoxEdit_WatchWholeDayAppetite);
			this.groupControl_WatchWholeDayReg.Controls.Add(this.notePanel_WatchWholeDayAppetite);
			this.groupControl_WatchWholeDayReg.Controls.Add(this.comboBoxEdit_WatchWholeDaySpirit);
			this.groupControl_WatchWholeDayReg.Controls.Add(this.notePanel_WatchWholeDaySpirit);
			this.groupControl_WatchWholeDayReg.Controls.Add(this.comboBoxEdit_WatchWholeDayMovement);
			this.groupControl_WatchWholeDayReg.Controls.Add(this.notePanel_WatchWholeDayMovement);
			this.groupControl_WatchWholeDayReg.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_WatchWholeDayReg.Location = new System.Drawing.Point(3, 18);
			this.groupControl_WatchWholeDayReg.Name = "groupControl_WatchWholeDayReg";
			this.groupControl_WatchWholeDayReg.Size = new System.Drawing.Size(458, 174);
			this.groupControl_WatchWholeDayReg.TabIndex = 0;
			this.groupControl_WatchWholeDayReg.Text = "体温，精神，食欲等情况";
			// 
			// textEdit_WatchWholeDayElse
			// 
			this.textEdit_WatchWholeDayElse.EditValue = "";
			this.textEdit_WatchWholeDayElse.Location = new System.Drawing.Point(120, 120);
			this.textEdit_WatchWholeDayElse.Name = "textEdit_WatchWholeDayElse";
			this.textEdit_WatchWholeDayElse.Size = new System.Drawing.Size(336, 23);
			this.textEdit_WatchWholeDayElse.TabIndex = 89;
			// 
			// notePanel_WatchWholeDayElse
			// 
			this.notePanel_WatchWholeDayElse.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_WatchWholeDayElse.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_WatchWholeDayElse.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_WatchWholeDayElse.ForeColor = System.Drawing.Color.Black;
			this.notePanel_WatchWholeDayElse.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_WatchWholeDayElse.Location = new System.Drawing.Point(24, 120);
			this.notePanel_WatchWholeDayElse.MaxRows = 5;
			this.notePanel_WatchWholeDayElse.Name = "notePanel_WatchWholeDayElse";
			this.notePanel_WatchWholeDayElse.ParentAutoHeight = true;
			this.notePanel_WatchWholeDayElse.Size = new System.Drawing.Size(88, 22);
			this.notePanel_WatchWholeDayElse.TabIndex = 88;
			this.notePanel_WatchWholeDayElse.TabStop = false;
			this.notePanel_WatchWholeDayElse.Text = " 其他情况:";
			// 
			// comboBoxEdit_WatchWholeDayCough
			// 
			this.comboBoxEdit_WatchWholeDayCough.EditValue = "有";
			this.comboBoxEdit_WatchWholeDayCough.Location = new System.Drawing.Point(408, 80);
			this.comboBoxEdit_WatchWholeDayCough.Name = "comboBoxEdit_WatchWholeDayCough";
			// 
			// comboBoxEdit_WatchWholeDayCough.Properties
			// 
			this.comboBoxEdit_WatchWholeDayCough.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																	new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_WatchWholeDayCough.Properties.Items.AddRange(new object[] {
																							"有",
																							"无"});
			this.comboBoxEdit_WatchWholeDayCough.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_WatchWholeDayCough.Size = new System.Drawing.Size(48, 23);
			this.comboBoxEdit_WatchWholeDayCough.TabIndex = 87;
			// 
			// notePanel_WatchWholeDayCough
			// 
			this.notePanel_WatchWholeDayCough.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_WatchWholeDayCough.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_WatchWholeDayCough.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_WatchWholeDayCough.ForeColor = System.Drawing.Color.Black;
			this.notePanel_WatchWholeDayCough.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_WatchWholeDayCough.Location = new System.Drawing.Point(328, 80);
			this.notePanel_WatchWholeDayCough.MaxRows = 5;
			this.notePanel_WatchWholeDayCough.Name = "notePanel_WatchWholeDayCough";
			this.notePanel_WatchWholeDayCough.ParentAutoHeight = true;
			this.notePanel_WatchWholeDayCough.Size = new System.Drawing.Size(72, 22);
			this.notePanel_WatchWholeDayCough.TabIndex = 86;
			this.notePanel_WatchWholeDayCough.TabStop = false;
			this.notePanel_WatchWholeDayCough.Text = " 咳  嗽:";
			// 
			// comboBoxEdit_WatchWholeDaySleep
			// 
			this.comboBoxEdit_WatchWholeDaySleep.EditValue = "好";
			this.comboBoxEdit_WatchWholeDaySleep.Location = new System.Drawing.Point(272, 80);
			this.comboBoxEdit_WatchWholeDaySleep.Name = "comboBoxEdit_WatchWholeDaySleep";
			// 
			// comboBoxEdit_WatchWholeDaySleep.Properties
			// 
			this.comboBoxEdit_WatchWholeDaySleep.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																	new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_WatchWholeDaySleep.Properties.Items.AddRange(new object[] {
																							"好",
																							"中",
																							"差"});
			this.comboBoxEdit_WatchWholeDaySleep.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_WatchWholeDaySleep.Size = new System.Drawing.Size(48, 23);
			this.comboBoxEdit_WatchWholeDaySleep.TabIndex = 85;
			// 
			// notePanel_WatchWholeDaySleep
			// 
			this.notePanel_WatchWholeDaySleep.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_WatchWholeDaySleep.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_WatchWholeDaySleep.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_WatchWholeDaySleep.ForeColor = System.Drawing.Color.Black;
			this.notePanel_WatchWholeDaySleep.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_WatchWholeDaySleep.Location = new System.Drawing.Point(192, 80);
			this.notePanel_WatchWholeDaySleep.MaxRows = 5;
			this.notePanel_WatchWholeDaySleep.Name = "notePanel_WatchWholeDaySleep";
			this.notePanel_WatchWholeDaySleep.ParentAutoHeight = true;
			this.notePanel_WatchWholeDaySleep.Size = new System.Drawing.Size(72, 22);
			this.notePanel_WatchWholeDaySleep.TabIndex = 84;
			this.notePanel_WatchWholeDaySleep.TabStop = false;
			this.notePanel_WatchWholeDaySleep.Text = " 睡  眠:";
			// 
			// comboBoxEdit_WatchWholeDayStool
			// 
			this.comboBoxEdit_WatchWholeDayStool.EditValue = "好";
			this.comboBoxEdit_WatchWholeDayStool.Location = new System.Drawing.Point(120, 80);
			this.comboBoxEdit_WatchWholeDayStool.Name = "comboBoxEdit_WatchWholeDayStool";
			// 
			// comboBoxEdit_WatchWholeDayStool.Properties
			// 
			this.comboBoxEdit_WatchWholeDayStool.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																	new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_WatchWholeDayStool.Properties.Items.AddRange(new object[] {
																							"好",
																							"中",
																							"差"});
			this.comboBoxEdit_WatchWholeDayStool.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_WatchWholeDayStool.Size = new System.Drawing.Size(64, 23);
			this.comboBoxEdit_WatchWholeDayStool.TabIndex = 83;
			// 
			// notePanel_WatchWholeDayStool
			// 
			this.notePanel_WatchWholeDayStool.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_WatchWholeDayStool.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_WatchWholeDayStool.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_WatchWholeDayStool.ForeColor = System.Drawing.Color.Black;
			this.notePanel_WatchWholeDayStool.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_WatchWholeDayStool.Location = new System.Drawing.Point(24, 80);
			this.notePanel_WatchWholeDayStool.MaxRows = 5;
			this.notePanel_WatchWholeDayStool.Name = "notePanel_WatchWholeDayStool";
			this.notePanel_WatchWholeDayStool.ParentAutoHeight = true;
			this.notePanel_WatchWholeDayStool.Size = new System.Drawing.Size(88, 22);
			this.notePanel_WatchWholeDayStool.TabIndex = 82;
			this.notePanel_WatchWholeDayStool.TabStop = false;
			this.notePanel_WatchWholeDayStool.Text = "   大小便:";
			// 
			// comboBoxEdit_WatchWholeDayAppetite
			// 
			this.comboBoxEdit_WatchWholeDayAppetite.EditValue = "好";
			this.comboBoxEdit_WatchWholeDayAppetite.Location = new System.Drawing.Point(408, 40);
			this.comboBoxEdit_WatchWholeDayAppetite.Name = "comboBoxEdit_WatchWholeDayAppetite";
			// 
			// comboBoxEdit_WatchWholeDayAppetite.Properties
			// 
			this.comboBoxEdit_WatchWholeDayAppetite.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																	   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_WatchWholeDayAppetite.Properties.Items.AddRange(new object[] {
																							   "好",
																							   "中",
																							   "差"});
			this.comboBoxEdit_WatchWholeDayAppetite.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_WatchWholeDayAppetite.Size = new System.Drawing.Size(48, 23);
			this.comboBoxEdit_WatchWholeDayAppetite.TabIndex = 81;
			// 
			// notePanel_WatchWholeDayAppetite
			// 
			this.notePanel_WatchWholeDayAppetite.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_WatchWholeDayAppetite.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_WatchWholeDayAppetite.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_WatchWholeDayAppetite.ForeColor = System.Drawing.Color.Black;
			this.notePanel_WatchWholeDayAppetite.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_WatchWholeDayAppetite.Location = new System.Drawing.Point(328, 40);
			this.notePanel_WatchWholeDayAppetite.MaxRows = 5;
			this.notePanel_WatchWholeDayAppetite.Name = "notePanel_WatchWholeDayAppetite";
			this.notePanel_WatchWholeDayAppetite.ParentAutoHeight = true;
			this.notePanel_WatchWholeDayAppetite.Size = new System.Drawing.Size(72, 22);
			this.notePanel_WatchWholeDayAppetite.TabIndex = 80;
			this.notePanel_WatchWholeDayAppetite.TabStop = false;
			this.notePanel_WatchWholeDayAppetite.Text = " 食  欲:";
			// 
			// comboBoxEdit_WatchWholeDaySpirit
			// 
			this.comboBoxEdit_WatchWholeDaySpirit.EditValue = "好";
			this.comboBoxEdit_WatchWholeDaySpirit.Location = new System.Drawing.Point(272, 40);
			this.comboBoxEdit_WatchWholeDaySpirit.Name = "comboBoxEdit_WatchWholeDaySpirit";
			// 
			// comboBoxEdit_WatchWholeDaySpirit.Properties
			// 
			this.comboBoxEdit_WatchWholeDaySpirit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																	 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_WatchWholeDaySpirit.Properties.Items.AddRange(new object[] {
																							 "好",
																							 "中",
																							 "差"});
			this.comboBoxEdit_WatchWholeDaySpirit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_WatchWholeDaySpirit.Size = new System.Drawing.Size(48, 23);
			this.comboBoxEdit_WatchWholeDaySpirit.TabIndex = 79;
			// 
			// notePanel_WatchWholeDaySpirit
			// 
			this.notePanel_WatchWholeDaySpirit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_WatchWholeDaySpirit.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_WatchWholeDaySpirit.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_WatchWholeDaySpirit.ForeColor = System.Drawing.Color.Black;
			this.notePanel_WatchWholeDaySpirit.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_WatchWholeDaySpirit.Location = new System.Drawing.Point(192, 40);
			this.notePanel_WatchWholeDaySpirit.MaxRows = 5;
			this.notePanel_WatchWholeDaySpirit.Name = "notePanel_WatchWholeDaySpirit";
			this.notePanel_WatchWholeDaySpirit.ParentAutoHeight = true;
			this.notePanel_WatchWholeDaySpirit.Size = new System.Drawing.Size(72, 22);
			this.notePanel_WatchWholeDaySpirit.TabIndex = 78;
			this.notePanel_WatchWholeDaySpirit.TabStop = false;
			this.notePanel_WatchWholeDaySpirit.Text = " 精  神:";
			// 
			// comboBoxEdit_WatchWholeDayMovement
			// 
			this.comboBoxEdit_WatchWholeDayMovement.EditValue = "强";
			this.comboBoxEdit_WatchWholeDayMovement.Location = new System.Drawing.Point(120, 40);
			this.comboBoxEdit_WatchWholeDayMovement.Name = "comboBoxEdit_WatchWholeDayMovement";
			// 
			// comboBoxEdit_WatchWholeDayMovement.Properties
			// 
			this.comboBoxEdit_WatchWholeDayMovement.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																	   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_WatchWholeDayMovement.Properties.Items.AddRange(new object[] {
																							   "强",
																							   "中",
																							   "弱"});
			this.comboBoxEdit_WatchWholeDayMovement.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_WatchWholeDayMovement.Size = new System.Drawing.Size(64, 23);
			this.comboBoxEdit_WatchWholeDayMovement.TabIndex = 77;
			// 
			// notePanel_WatchWholeDayMovement
			// 
			this.notePanel_WatchWholeDayMovement.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_WatchWholeDayMovement.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_WatchWholeDayMovement.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_WatchWholeDayMovement.ForeColor = System.Drawing.Color.Black;
			this.notePanel_WatchWholeDayMovement.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_WatchWholeDayMovement.Location = new System.Drawing.Point(24, 40);
			this.notePanel_WatchWholeDayMovement.MaxRows = 5;
			this.notePanel_WatchWholeDayMovement.Name = "notePanel_WatchWholeDayMovement";
			this.notePanel_WatchWholeDayMovement.ParentAutoHeight = true;
			this.notePanel_WatchWholeDayMovement.Size = new System.Drawing.Size(88, 22);
			this.notePanel_WatchWholeDayMovement.TabIndex = 50;
			this.notePanel_WatchWholeDayMovement.TabStop = false;
			this.notePanel_WatchWholeDayMovement.Text = "一日活动:";
			// 
			// groupControl_WatchRecList
			// 
			this.groupControl_WatchRecList.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_WatchRecList.AppearanceCaption.Options.UseFont = true;
			this.groupControl_WatchRecList.Controls.Add(this.gridControl_WatchRecList);
			this.groupControl_WatchRecList.Controls.Add(this.notePanel_WatchRecList);
			this.groupControl_WatchRecList.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_WatchRecList.Location = new System.Drawing.Point(0, 40);
			this.groupControl_WatchRecList.Name = "groupControl_WatchRecList";
			this.groupControl_WatchRecList.Size = new System.Drawing.Size(464, 469);
			this.groupControl_WatchRecList.TabIndex = 1;
			this.groupControl_WatchRecList.Text = "幼儿观察列表";
			// 
			// gridControl_WatchRecList
			// 
			this.gridControl_WatchRecList.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl_WatchRecList.EmbeddedNavigator
			// 
			this.gridControl_WatchRecList.EmbeddedNavigator.Name = "";
			this.gridControl_WatchRecList.Location = new System.Drawing.Point(3, 41);
			this.gridControl_WatchRecList.MainView = this.gridView8;
			this.gridControl_WatchRecList.Name = "gridControl_WatchRecList";
			this.gridControl_WatchRecList.Size = new System.Drawing.Size(458, 425);
			this.gridControl_WatchRecList.TabIndex = 26;
			this.gridControl_WatchRecList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																													this.gridView8});
			this.gridControl_WatchRecList.DoubleClick += new System.EventHandler(this.gridControl_WatchRecList_DoubleClick);
			// 
			// gridView8
			// 
			this.gridView8.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn29,
																							 this.gridColumn30,
																							 this.gridColumn31,
																							 this.gridColumn32,
																							 this.gridColumn33,
																							 this.gridColumn34});
			this.gridView8.GridControl = this.gridControl_WatchRecList;
			this.gridView8.Name = "gridView8";
			this.gridView8.OptionsCustomization.AllowFilter = false;
			this.gridView8.OptionsView.ShowFilterPanel = false;
			this.gridView8.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn29
			// 
			this.gridColumn29.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn29.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn29.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn29.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn29.Caption = "幼儿序号";
			this.gridColumn29.FieldName = "info_stuOrderNumber";
			this.gridColumn29.Name = "gridColumn29";
			this.gridColumn29.OptionsColumn.AllowEdit = false;
			this.gridColumn29.OptionsColumn.AllowFocus = false;
			this.gridColumn29.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn29.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn29.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn29.OptionsColumn.AllowMove = false;
			this.gridColumn29.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn29.OptionsColumn.ReadOnly = true;
			this.gridColumn29.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn29.Visible = true;
			this.gridColumn29.VisibleIndex = 0;
			this.gridColumn29.Width = 60;
			// 
			// gridColumn30
			// 
			this.gridColumn30.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn30.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn30.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn30.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn30.Caption = "幼儿学号";
			this.gridColumn30.FieldName = "stu_id";
			this.gridColumn30.Name = "gridColumn30";
			this.gridColumn30.OptionsColumn.AllowEdit = false;
			this.gridColumn30.OptionsColumn.AllowFocus = false;
			this.gridColumn30.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn30.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn30.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn30.OptionsColumn.AllowMove = false;
			this.gridColumn30.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn30.OptionsColumn.ReadOnly = true;
			this.gridColumn30.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn30.Visible = true;
			this.gridColumn30.VisibleIndex = 1;
			this.gridColumn30.Width = 65;
			// 
			// gridColumn31
			// 
			this.gridColumn31.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn31.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn31.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn31.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn31.Caption = "幼儿姓名";
			this.gridColumn31.FieldName = "stu_name";
			this.gridColumn31.Name = "gridColumn31";
			this.gridColumn31.OptionsColumn.AllowEdit = false;
			this.gridColumn31.OptionsColumn.AllowFocus = false;
			this.gridColumn31.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn31.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn31.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn31.OptionsColumn.AllowMove = false;
			this.gridColumn31.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn31.OptionsColumn.ReadOnly = true;
			this.gridColumn31.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn31.Visible = true;
			this.gridColumn31.VisibleIndex = 2;
			this.gridColumn31.Width = 77;
			// 
			// gridColumn32
			// 
			this.gridColumn32.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn32.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn32.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn32.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn32.Caption = "幼儿班级";
			this.gridColumn32.FieldName = "info_className";
			this.gridColumn32.Name = "gridColumn32";
			this.gridColumn32.OptionsColumn.AllowEdit = false;
			this.gridColumn32.OptionsColumn.AllowFocus = false;
			this.gridColumn32.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn32.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn32.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn32.OptionsColumn.AllowMove = false;
			this.gridColumn32.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn32.OptionsColumn.ReadOnly = true;
			this.gridColumn32.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn32.Visible = true;
			this.gridColumn32.VisibleIndex = 3;
			this.gridColumn32.Width = 77;
			// 
			// gridColumn33
			// 
			this.gridColumn33.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn33.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn33.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn33.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn33.Caption = "观察时间";
			this.gridColumn33.FieldName = "observeTime";
			this.gridColumn33.Name = "gridColumn33";
			this.gridColumn33.OptionsColumn.AllowEdit = false;
			this.gridColumn33.OptionsColumn.AllowFocus = false;
			this.gridColumn33.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn33.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn33.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn33.OptionsColumn.AllowMove = false;
			this.gridColumn33.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn33.OptionsColumn.ReadOnly = true;
			this.gridColumn33.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn33.Visible = true;
			this.gridColumn33.VisibleIndex = 4;
			this.gridColumn33.Width = 81;
			// 
			// gridColumn34
			// 
			this.gridColumn34.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn34.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn34.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn34.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn34.Caption = "教师签名";
			this.gridColumn34.FieldName = "dailyReg_teacherSign";
			this.gridColumn34.Name = "gridColumn34";
			this.gridColumn34.OptionsColumn.AllowEdit = false;
			this.gridColumn34.OptionsColumn.AllowFocus = false;
			this.gridColumn34.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn34.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn34.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn34.OptionsColumn.AllowMove = false;
			this.gridColumn34.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn34.OptionsColumn.ReadOnly = true;
			this.gridColumn34.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn34.Visible = true;
			this.gridColumn34.VisibleIndex = 5;
			this.gridColumn34.Width = 95;
			// 
			// notePanel_WatchRecList
			// 
			this.notePanel_WatchRecList.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel_WatchRecList.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel_WatchRecList.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel_WatchRecList.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_WatchRecList.Location = new System.Drawing.Point(3, 18);
			this.notePanel_WatchRecList.MaxRows = 5;
			this.notePanel_WatchRecList.Name = "notePanel_WatchRecList";
			this.notePanel_WatchRecList.ParentAutoHeight = true;
			this.notePanel_WatchRecList.Size = new System.Drawing.Size(458, 23);
			this.notePanel_WatchRecList.TabIndex = 25;
			this.notePanel_WatchRecList.TabStop = false;
			this.notePanel_WatchRecList.Text = "双击进入幼儿全日观察";
			// 
			// panelControl7
			// 
			this.panelControl7.Controls.Add(this.simpleButton_WatchSearch);
			this.panelControl7.Controls.Add(this.simpleButton_WatchBack);
			this.panelControl7.Controls.Add(this.simpleButton_WatchDelete);
			this.panelControl7.Controls.Add(this.simpleButton_WatchReport);
			this.panelControl7.Controls.Add(this.simpleButton_WatchHandle);
			this.panelControl7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl7.Location = new System.Drawing.Point(0, 0);
			this.panelControl7.Name = "panelControl7";
			this.panelControl7.Size = new System.Drawing.Size(464, 40);
			this.panelControl7.TabIndex = 0;
			this.panelControl7.Text = "panelControl7";
			// 
			// simpleButton_WatchSearch
			// 
			this.simpleButton_WatchSearch.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_WatchSearch.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_WatchSearch.Appearance.Options.UseFont = true;
			this.simpleButton_WatchSearch.Appearance.Options.UseForeColor = true;
			this.simpleButton_WatchSearch.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_WatchSearch.Image")));
			this.simpleButton_WatchSearch.Location = new System.Drawing.Point(8, 9);
			this.simpleButton_WatchSearch.Name = "simpleButton_WatchSearch";
			this.simpleButton_WatchSearch.Size = new System.Drawing.Size(72, 26);
			this.simpleButton_WatchSearch.TabIndex = 21;
			this.simpleButton_WatchSearch.Tag = 4;
			this.simpleButton_WatchSearch.Text = "检索";
			this.simpleButton_WatchSearch.Click += new System.EventHandler(this.simpleButton_WatchSearch_Click);
			// 
			// simpleButton_WatchBack
			// 
			this.simpleButton_WatchBack.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_WatchBack.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_WatchBack.Appearance.Options.UseFont = true;
			this.simpleButton_WatchBack.Appearance.Options.UseForeColor = true;
			this.simpleButton_WatchBack.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_WatchBack.Image")));
			this.simpleButton_WatchBack.Location = new System.Drawing.Point(88, 8);
			this.simpleButton_WatchBack.Name = "simpleButton_WatchBack";
			this.simpleButton_WatchBack.Size = new System.Drawing.Size(72, 26);
			this.simpleButton_WatchBack.TabIndex = 19;
			this.simpleButton_WatchBack.Tag = 4;
			this.simpleButton_WatchBack.Text = "返回";
			this.simpleButton_WatchBack.Click += new System.EventHandler(this.simpleButton_WatchBack_Click);
			// 
			// simpleButton_WatchDelete
			// 
			this.simpleButton_WatchDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_WatchDelete.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_WatchDelete.Appearance.Options.UseFont = true;
			this.simpleButton_WatchDelete.Appearance.Options.UseForeColor = true;
			this.simpleButton_WatchDelete.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_WatchDelete.Image")));
			this.simpleButton_WatchDelete.Location = new System.Drawing.Point(248, 8);
			this.simpleButton_WatchDelete.Name = "simpleButton_WatchDelete";
			this.simpleButton_WatchDelete.Size = new System.Drawing.Size(72, 26);
			this.simpleButton_WatchDelete.TabIndex = 18;
			this.simpleButton_WatchDelete.Tag = 4;
			this.simpleButton_WatchDelete.Text = "删除";
			this.simpleButton_WatchDelete.Click += new System.EventHandler(this.simpleButton_WatchDelete_Click);
			// 
			// simpleButton_WatchReport
			// 
			this.simpleButton_WatchReport.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_WatchReport.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_WatchReport.Appearance.Options.UseFont = true;
			this.simpleButton_WatchReport.Appearance.Options.UseForeColor = true;
			this.simpleButton_WatchReport.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_WatchReport.Image")));
			this.simpleButton_WatchReport.Location = new System.Drawing.Point(328, 8);
			this.simpleButton_WatchReport.Name = "simpleButton_WatchReport";
			this.simpleButton_WatchReport.Size = new System.Drawing.Size(72, 26);
			this.simpleButton_WatchReport.TabIndex = 16;
			this.simpleButton_WatchReport.Tag = 4;
			this.simpleButton_WatchReport.Text = "报表";
			this.simpleButton_WatchReport.Click += new System.EventHandler(this.simpleButton_WatchReport_Click);
			// 
			// simpleButton_WatchHandle
			// 
			this.simpleButton_WatchHandle.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_WatchHandle.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_WatchHandle.Appearance.Options.UseFont = true;
			this.simpleButton_WatchHandle.Appearance.Options.UseForeColor = true;
			this.simpleButton_WatchHandle.Enabled = false;
			this.simpleButton_WatchHandle.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_WatchHandle.Image")));
			this.simpleButton_WatchHandle.Location = new System.Drawing.Point(168, 8);
			this.simpleButton_WatchHandle.Name = "simpleButton_WatchHandle";
			this.simpleButton_WatchHandle.Size = new System.Drawing.Size(72, 26);
			this.simpleButton_WatchHandle.TabIndex = 14;
			this.simpleButton_WatchHandle.Tag = 4;
			this.simpleButton_WatchHandle.Text = "保存";
			this.simpleButton_WatchHandle.Click += new System.EventHandler(this.simpleButton_WatchHandle_Click);
			// 
			// xtraTabPage8
			// 
			this.xtraTabPage8.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
			this.xtraTabPage8.Appearance.PageClient.Options.UseBackColor = true;
			this.xtraTabPage8.Controls.Add(this.splitContainerControl9);
			this.xtraTabPage8.Name = "xtraTabPage8";
			this.xtraTabPage8.PageVisible = false;
			this.xtraTabPage8.Size = new System.Drawing.Size(768, 515);
			this.xtraTabPage8.Text = "服药登记";
			// 
			// splitContainerControl9
			// 
			this.splitContainerControl9.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl9.Location = new System.Drawing.Point(0, 0);
			this.splitContainerControl9.Name = "splitContainerControl9";
			this.splitContainerControl9.Panel1.Controls.Add(this.groupControl_MedReg_StuList);
			this.splitContainerControl9.Panel1.Controls.Add(this.groupControl_MedReg_Ser);
			this.splitContainerControl9.Panel1.Text = "splitContainerControl9_Panel1";
			this.splitContainerControl9.Panel2.Controls.Add(this.groupControl_MedReg_MedInfo);
			this.splitContainerControl9.Panel2.Controls.Add(this.groupControl_MedReg_MedCarrInfo);
			this.splitContainerControl9.Panel2.Controls.Add(this.groupControl_MedReg_DiagInfo);
			this.splitContainerControl9.Panel2.Controls.Add(this.panelControl8);
			this.splitContainerControl9.Panel2.Text = "splitContainerControl9_Panel2";
			this.splitContainerControl9.Size = new System.Drawing.Size(768, 515);
			this.splitContainerControl9.SplitterPosition = 289;
			this.splitContainerControl9.TabIndex = 0;
			this.splitContainerControl9.Text = "splitContainerControl9";
			// 
			// groupControl_MedReg_StuList
			// 
			this.groupControl_MedReg_StuList.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_MedReg_StuList.AppearanceCaption.Options.UseFont = true;
			this.groupControl_MedReg_StuList.Controls.Add(this.gridControl_MedReg_StuList);
			this.groupControl_MedReg_StuList.Controls.Add(this.notePanel2);
			this.groupControl_MedReg_StuList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl_MedReg_StuList.Location = new System.Drawing.Point(0, 208);
			this.groupControl_MedReg_StuList.Name = "groupControl_MedReg_StuList";
			this.groupControl_MedReg_StuList.Size = new System.Drawing.Size(283, 301);
			this.groupControl_MedReg_StuList.TabIndex = 2;
			this.groupControl_MedReg_StuList.Text = "今天需要服药的幼儿";
			// 
			// gridControl_MedReg_StuList
			// 
			this.gridControl_MedReg_StuList.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl_MedReg_StuList.EmbeddedNavigator
			// 
			this.gridControl_MedReg_StuList.EmbeddedNavigator.Name = "";
			this.gridControl_MedReg_StuList.Location = new System.Drawing.Point(3, 41);
			this.gridControl_MedReg_StuList.MainView = this.gridView9;
			this.gridControl_MedReg_StuList.Name = "gridControl_MedReg_StuList";
			this.gridControl_MedReg_StuList.Size = new System.Drawing.Size(277, 257);
			this.gridControl_MedReg_StuList.TabIndex = 59;
			this.gridControl_MedReg_StuList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																													  this.gridView9});
			this.gridControl_MedReg_StuList.DoubleClick += new System.EventHandler(this.gridControl_MedReg_StuList_DoubleClick);
			// 
			// gridView9
			// 
			this.gridView9.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn35,
																							 this.gridColumn36,
																							 this.gridColumn37,
																							 this.gridColumn38});
			this.gridView9.GridControl = this.gridControl_MedReg_StuList;
			this.gridView9.Name = "gridView9";
			this.gridView9.OptionsCustomization.AllowFilter = false;
			this.gridView9.OptionsView.ShowFilterPanel = false;
			this.gridView9.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn35
			// 
			this.gridColumn35.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn35.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn35.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn35.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn35.Caption = "学号";
			this.gridColumn35.FieldName = "info_stuNumber";
			this.gridColumn35.Name = "gridColumn35";
			this.gridColumn35.OptionsColumn.AllowEdit = false;
			this.gridColumn35.OptionsColumn.AllowFocus = false;
			this.gridColumn35.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn35.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn35.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn35.OptionsColumn.AllowMove = false;
			this.gridColumn35.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn35.OptionsColumn.ReadOnly = true;
			this.gridColumn35.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn35.Visible = true;
			this.gridColumn35.VisibleIndex = 0;
			this.gridColumn35.Width = 48;
			// 
			// gridColumn36
			// 
			this.gridColumn36.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn36.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn36.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn36.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn36.Caption = "姓名";
			this.gridColumn36.FieldName = "info_stuName";
			this.gridColumn36.Name = "gridColumn36";
			this.gridColumn36.OptionsColumn.AllowEdit = false;
			this.gridColumn36.OptionsColumn.AllowFocus = false;
			this.gridColumn36.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn36.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn36.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn36.OptionsColumn.AllowMove = false;
			this.gridColumn36.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn36.OptionsColumn.ReadOnly = true;
			this.gridColumn36.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn36.Visible = true;
			this.gridColumn36.VisibleIndex = 1;
			this.gridColumn36.Width = 56;
			// 
			// gridColumn37
			// 
			this.gridColumn37.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn37.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn37.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn37.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn37.Caption = "班级";
			this.gridColumn37.FieldName = "info_className";
			this.gridColumn37.Name = "gridColumn37";
			this.gridColumn37.OptionsColumn.AllowEdit = false;
			this.gridColumn37.OptionsColumn.AllowFocus = false;
			this.gridColumn37.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn37.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn37.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn37.OptionsColumn.AllowMove = false;
			this.gridColumn37.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn37.OptionsColumn.ReadOnly = true;
			this.gridColumn37.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn37.Visible = true;
			this.gridColumn37.VisibleIndex = 2;
			this.gridColumn37.Width = 55;
			// 
			// gridColumn38
			// 
			this.gridColumn38.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn38.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn38.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn38.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn38.Caption = "晨检时间";
			this.gridColumn38.DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
			this.gridColumn38.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.gridColumn38.FieldName = "flow_stuFlowEnterDate";
			this.gridColumn38.Name = "gridColumn38";
			this.gridColumn38.OptionsColumn.AllowEdit = false;
			this.gridColumn38.OptionsColumn.AllowFocus = false;
			this.gridColumn38.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn38.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn38.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn38.OptionsColumn.AllowMove = false;
			this.gridColumn38.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn38.OptionsColumn.ReadOnly = true;
			this.gridColumn38.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn38.Visible = true;
			this.gridColumn38.VisibleIndex = 3;
			this.gridColumn38.Width = 101;
			// 
			// notePanel2
			// 
			this.notePanel2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel2.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel2.Location = new System.Drawing.Point(3, 18);
			this.notePanel2.MaxRows = 5;
			this.notePanel2.Name = "notePanel2";
			this.notePanel2.ParentAutoHeight = true;
			this.notePanel2.Size = new System.Drawing.Size(277, 23);
			this.notePanel2.TabIndex = 58;
			this.notePanel2.TabStop = false;
			this.notePanel2.Text = "双击进行晨检诊断及药品携带信息管理";
			// 
			// groupControl_MedReg_Ser
			// 
			this.groupControl_MedReg_Ser.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_MedReg_Ser.AppearanceCaption.Options.UseFont = true;
			this.groupControl_MedReg_Ser.Controls.Add(this.notePanel_MedReg_Ser);
			this.groupControl_MedReg_Ser.Controls.Add(this.textEdit_MedReg_Number);
			this.groupControl_MedReg_Ser.Controls.Add(this.textEdit_MedReg_Name);
			this.groupControl_MedReg_Ser.Controls.Add(this.comboBoxEdit_MedReg_Class);
			this.groupControl_MedReg_Ser.Controls.Add(this.notePanel_MedReg_Class);
			this.groupControl_MedReg_Ser.Controls.Add(this.comboBoxEdit_MedReg_Grade);
			this.groupControl_MedReg_Ser.Controls.Add(this.notePanel_MedReg_Grade);
			this.groupControl_MedReg_Ser.Controls.Add(this.notePanel_MedReg_Number);
			this.groupControl_MedReg_Ser.Controls.Add(this.notePanel_MedReg_Name);
			this.groupControl_MedReg_Ser.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_MedReg_Ser.Location = new System.Drawing.Point(0, 0);
			this.groupControl_MedReg_Ser.Name = "groupControl_MedReg_Ser";
			this.groupControl_MedReg_Ser.Size = new System.Drawing.Size(283, 208);
			this.groupControl_MedReg_Ser.TabIndex = 1;
			this.groupControl_MedReg_Ser.Text = "信息查询";
			// 
			// notePanel_MedReg_Ser
			// 
			this.notePanel_MedReg_Ser.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel_MedReg_Ser.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel_MedReg_Ser.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel_MedReg_Ser.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedReg_Ser.Location = new System.Drawing.Point(3, 18);
			this.notePanel_MedReg_Ser.MaxRows = 5;
			this.notePanel_MedReg_Ser.Name = "notePanel_MedReg_Ser";
			this.notePanel_MedReg_Ser.ParentAutoHeight = true;
			this.notePanel_MedReg_Ser.Size = new System.Drawing.Size(277, 23);
			this.notePanel_MedReg_Ser.TabIndex = 57;
			this.notePanel_MedReg_Ser.TabStop = false;
			this.notePanel_MedReg_Ser.Text = "检索您的幼儿";
			// 
			// textEdit_MedReg_Number
			// 
			this.textEdit_MedReg_Number.EditValue = "";
			this.textEdit_MedReg_Number.Location = new System.Drawing.Point(144, 160);
			this.textEdit_MedReg_Number.Name = "textEdit_MedReg_Number";
			this.textEdit_MedReg_Number.Size = new System.Drawing.Size(88, 23);
			this.textEdit_MedReg_Number.TabIndex = 56;
			this.textEdit_MedReg_Number.EditValueChanged += new System.EventHandler(this.textEdit_MedReg_Number_EditValueChanged);
			// 
			// textEdit_MedReg_Name
			// 
			this.textEdit_MedReg_Name.EditValue = "";
			this.textEdit_MedReg_Name.Location = new System.Drawing.Point(144, 128);
			this.textEdit_MedReg_Name.Name = "textEdit_MedReg_Name";
			this.textEdit_MedReg_Name.Size = new System.Drawing.Size(88, 23);
			this.textEdit_MedReg_Name.TabIndex = 55;
			this.textEdit_MedReg_Name.EditValueChanged += new System.EventHandler(this.textEdit_MedReg_Name_EditValueChanged);
			// 
			// comboBoxEdit_MedReg_Class
			// 
			this.comboBoxEdit_MedReg_Class.EditValue = "全部";
			this.comboBoxEdit_MedReg_Class.Location = new System.Drawing.Point(144, 96);
			this.comboBoxEdit_MedReg_Class.Name = "comboBoxEdit_MedReg_Class";
			// 
			// comboBoxEdit_MedReg_Class.Properties
			// 
			this.comboBoxEdit_MedReg_Class.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_MedReg_Class.Properties.Items.AddRange(new object[] {
																					  "全部"});
			this.comboBoxEdit_MedReg_Class.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_MedReg_Class.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_MedReg_Class.TabIndex = 54;
			this.comboBoxEdit_MedReg_Class.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_MedReg_Class_SelectedIndexChanged);
			// 
			// notePanel_MedReg_Class
			// 
			this.notePanel_MedReg_Class.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedReg_Class.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedReg_Class.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedReg_Class.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedReg_Class.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedReg_Class.Location = new System.Drawing.Point(48, 96);
			this.notePanel_MedReg_Class.MaxRows = 5;
			this.notePanel_MedReg_Class.Name = "notePanel_MedReg_Class";
			this.notePanel_MedReg_Class.ParentAutoHeight = true;
			this.notePanel_MedReg_Class.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MedReg_Class.TabIndex = 53;
			this.notePanel_MedReg_Class.TabStop = false;
			this.notePanel_MedReg_Class.Text = "  班  级:";
			// 
			// comboBoxEdit_MedReg_Grade
			// 
			this.comboBoxEdit_MedReg_Grade.EditValue = "全部";
			this.comboBoxEdit_MedReg_Grade.Location = new System.Drawing.Point(144, 64);
			this.comboBoxEdit_MedReg_Grade.Name = "comboBoxEdit_MedReg_Grade";
			// 
			// comboBoxEdit_MedReg_Grade.Properties
			// 
			this.comboBoxEdit_MedReg_Grade.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_MedReg_Grade.Properties.Items.AddRange(new object[] {
																					  "全部"});
			this.comboBoxEdit_MedReg_Grade.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_MedReg_Grade.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_MedReg_Grade.TabIndex = 52;
			this.comboBoxEdit_MedReg_Grade.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_MedReg_Grade_SelectedIndexChanged);
			// 
			// notePanel_MedReg_Grade
			// 
			this.notePanel_MedReg_Grade.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedReg_Grade.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedReg_Grade.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedReg_Grade.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedReg_Grade.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedReg_Grade.Location = new System.Drawing.Point(48, 64);
			this.notePanel_MedReg_Grade.MaxRows = 5;
			this.notePanel_MedReg_Grade.Name = "notePanel_MedReg_Grade";
			this.notePanel_MedReg_Grade.ParentAutoHeight = true;
			this.notePanel_MedReg_Grade.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MedReg_Grade.TabIndex = 51;
			this.notePanel_MedReg_Grade.TabStop = false;
			this.notePanel_MedReg_Grade.Text = "  年  级:";
			// 
			// notePanel_MedReg_Number
			// 
			this.notePanel_MedReg_Number.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedReg_Number.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedReg_Number.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedReg_Number.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedReg_Number.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedReg_Number.Location = new System.Drawing.Point(48, 160);
			this.notePanel_MedReg_Number.MaxRows = 5;
			this.notePanel_MedReg_Number.Name = "notePanel_MedReg_Number";
			this.notePanel_MedReg_Number.ParentAutoHeight = true;
			this.notePanel_MedReg_Number.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MedReg_Number.TabIndex = 50;
			this.notePanel_MedReg_Number.TabStop = false;
			this.notePanel_MedReg_Number.Text = "  学  号:";
			// 
			// notePanel_MedReg_Name
			// 
			this.notePanel_MedReg_Name.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedReg_Name.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedReg_Name.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedReg_Name.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedReg_Name.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedReg_Name.Location = new System.Drawing.Point(48, 128);
			this.notePanel_MedReg_Name.MaxRows = 5;
			this.notePanel_MedReg_Name.Name = "notePanel_MedReg_Name";
			this.notePanel_MedReg_Name.ParentAutoHeight = true;
			this.notePanel_MedReg_Name.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MedReg_Name.TabIndex = 49;
			this.notePanel_MedReg_Name.TabStop = false;
			this.notePanel_MedReg_Name.Text = "  姓  名:";
			// 
			// groupControl_MedReg_MedInfo
			// 
			this.groupControl_MedReg_MedInfo.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_MedReg_MedInfo.AppearanceCaption.Options.UseFont = true;
			this.groupControl_MedReg_MedInfo.Controls.Add(this.textEdit_MedReg_MedName);
			this.groupControl_MedReg_MedInfo.Controls.Add(this.textEdit_MedReg_Taketimes);
			this.groupControl_MedReg_MedInfo.Controls.Add(this.textEdit_MedReg_MedTake);
			this.groupControl_MedReg_MedInfo.Controls.Add(this.textEdit_MedReg_MedType);
			this.groupControl_MedReg_MedInfo.Controls.Add(this.notePanel_MedReg_Taketimes);
			this.groupControl_MedReg_MedInfo.Controls.Add(this.notePanel_MedReg_MedTake);
			this.groupControl_MedReg_MedInfo.Controls.Add(this.notePanel_MedReg_MedType);
			this.groupControl_MedReg_MedInfo.Controls.Add(this.notePanel_MedReg_MedName);
			this.groupControl_MedReg_MedInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl_MedReg_MedInfo.Location = new System.Drawing.Point(0, 520);
			this.groupControl_MedReg_MedInfo.Name = "groupControl_MedReg_MedInfo";
			this.groupControl_MedReg_MedInfo.Size = new System.Drawing.Size(469, -11);
			this.groupControl_MedReg_MedInfo.TabIndex = 3;
			this.groupControl_MedReg_MedInfo.Text = "添加药品信息";
			this.groupControl_MedReg_MedInfo.Visible = false;
			// 
			// textEdit_MedReg_MedName
			// 
			this.textEdit_MedReg_MedName.EditValue = "";
			this.textEdit_MedReg_MedName.Location = new System.Drawing.Point(232, 32);
			this.textEdit_MedReg_MedName.Name = "textEdit_MedReg_MedName";
			this.textEdit_MedReg_MedName.Size = new System.Drawing.Size(96, 23);
			this.textEdit_MedReg_MedName.TabIndex = 60;
			// 
			// textEdit_MedReg_Taketimes
			// 
			this.textEdit_MedReg_Taketimes.EditValue = "";
			this.textEdit_MedReg_Taketimes.Location = new System.Drawing.Point(232, 152);
			this.textEdit_MedReg_Taketimes.Name = "textEdit_MedReg_Taketimes";
			this.textEdit_MedReg_Taketimes.Size = new System.Drawing.Size(96, 23);
			this.textEdit_MedReg_Taketimes.TabIndex = 59;
			// 
			// textEdit_MedReg_MedTake
			// 
			this.textEdit_MedReg_MedTake.EditValue = "";
			this.textEdit_MedReg_MedTake.Location = new System.Drawing.Point(232, 112);
			this.textEdit_MedReg_MedTake.Name = "textEdit_MedReg_MedTake";
			this.textEdit_MedReg_MedTake.Size = new System.Drawing.Size(96, 23);
			this.textEdit_MedReg_MedTake.TabIndex = 58;
			// 
			// textEdit_MedReg_MedType
			// 
			this.textEdit_MedReg_MedType.EditValue = "";
			this.textEdit_MedReg_MedType.Location = new System.Drawing.Point(232, 72);
			this.textEdit_MedReg_MedType.Name = "textEdit_MedReg_MedType";
			this.textEdit_MedReg_MedType.Size = new System.Drawing.Size(96, 23);
			this.textEdit_MedReg_MedType.TabIndex = 57;
			// 
			// notePanel_MedReg_Taketimes
			// 
			this.notePanel_MedReg_Taketimes.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedReg_Taketimes.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedReg_Taketimes.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedReg_Taketimes.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedReg_Taketimes.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedReg_Taketimes.Location = new System.Drawing.Point(128, 152);
			this.notePanel_MedReg_Taketimes.MaxRows = 5;
			this.notePanel_MedReg_Taketimes.Name = "notePanel_MedReg_Taketimes";
			this.notePanel_MedReg_Taketimes.ParentAutoHeight = true;
			this.notePanel_MedReg_Taketimes.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MedReg_Taketimes.TabIndex = 55;
			this.notePanel_MedReg_Taketimes.TabStop = false;
			this.notePanel_MedReg_Taketimes.Text = "服用次数:";
			// 
			// notePanel_MedReg_MedTake
			// 
			this.notePanel_MedReg_MedTake.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedReg_MedTake.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedReg_MedTake.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedReg_MedTake.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedReg_MedTake.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedReg_MedTake.Location = new System.Drawing.Point(128, 112);
			this.notePanel_MedReg_MedTake.MaxRows = 5;
			this.notePanel_MedReg_MedTake.Name = "notePanel_MedReg_MedTake";
			this.notePanel_MedReg_MedTake.ParentAutoHeight = true;
			this.notePanel_MedReg_MedTake.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MedReg_MedTake.TabIndex = 54;
			this.notePanel_MedReg_MedTake.TabStop = false;
			this.notePanel_MedReg_MedTake.Text = "服用剂量:";
			// 
			// notePanel_MedReg_MedType
			// 
			this.notePanel_MedReg_MedType.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedReg_MedType.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedReg_MedType.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedReg_MedType.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedReg_MedType.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedReg_MedType.Location = new System.Drawing.Point(128, 72);
			this.notePanel_MedReg_MedType.MaxRows = 5;
			this.notePanel_MedReg_MedType.Name = "notePanel_MedReg_MedType";
			this.notePanel_MedReg_MedType.ParentAutoHeight = true;
			this.notePanel_MedReg_MedType.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MedReg_MedType.TabIndex = 53;
			this.notePanel_MedReg_MedType.TabStop = false;
			this.notePanel_MedReg_MedType.Text = "  种  类:";
			// 
			// notePanel_MedReg_MedName
			// 
			this.notePanel_MedReg_MedName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedReg_MedName.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedReg_MedName.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedReg_MedName.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedReg_MedName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedReg_MedName.Location = new System.Drawing.Point(128, 32);
			this.notePanel_MedReg_MedName.MaxRows = 5;
			this.notePanel_MedReg_MedName.Name = "notePanel_MedReg_MedName";
			this.notePanel_MedReg_MedName.ParentAutoHeight = true;
			this.notePanel_MedReg_MedName.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MedReg_MedName.TabIndex = 52;
			this.notePanel_MedReg_MedName.TabStop = false;
			this.notePanel_MedReg_MedName.Text = "  名  称:";
			// 
			// groupControl_MedReg_MedCarrInfo
			// 
			this.groupControl_MedReg_MedCarrInfo.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_MedReg_MedCarrInfo.AppearanceCaption.Options.UseFont = true;
			this.groupControl_MedReg_MedCarrInfo.Controls.Add(this.listBoxControl_MedReg_MedCarrInfo);
			this.groupControl_MedReg_MedCarrInfo.Controls.Add(this.simpleButton_MedReg_MedCarrDel);
			this.groupControl_MedReg_MedCarrInfo.Controls.Add(this.simpleButton_MedReg_MedCarrAdd);
			this.groupControl_MedReg_MedCarrInfo.Controls.Add(this.listBoxControl_MedReg_MedInfo);
			this.groupControl_MedReg_MedCarrInfo.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_MedReg_MedCarrInfo.Location = new System.Drawing.Point(0, 368);
			this.groupControl_MedReg_MedCarrInfo.Name = "groupControl_MedReg_MedCarrInfo";
			this.groupControl_MedReg_MedCarrInfo.Size = new System.Drawing.Size(469, 152);
			this.groupControl_MedReg_MedCarrInfo.TabIndex = 2;
			this.groupControl_MedReg_MedCarrInfo.Text = "幼儿药品携带信息";
			// 
			// listBoxControl_MedReg_MedCarrInfo
			// 
			this.listBoxControl_MedReg_MedCarrInfo.ItemHeight = 16;
			this.listBoxControl_MedReg_MedCarrInfo.Location = new System.Drawing.Point(280, 24);
			this.listBoxControl_MedReg_MedCarrInfo.Name = "listBoxControl_MedReg_MedCarrInfo";
			this.listBoxControl_MedReg_MedCarrInfo.Size = new System.Drawing.Size(200, 112);
			this.listBoxControl_MedReg_MedCarrInfo.TabIndex = 3;
			this.listBoxControl_MedReg_MedCarrInfo.Click += new System.EventHandler(this.listBoxControl_MedReg_MedCarrInfo_Click);
			this.listBoxControl_MedReg_MedCarrInfo.DoubleClick += new System.EventHandler(this.listBoxControl_MedReg_MedCarrInfo_DoubleClick);
			this.listBoxControl_MedReg_MedCarrInfo.SelectedValueChanged += new System.EventHandler(this.listBoxControl_MedReg_MedCarrInfo_SelectedValueChanged);
			// 
			// simpleButton_MedReg_MedCarrDel
			// 
			this.simpleButton_MedReg_MedCarrDel.Enabled = false;
			this.simpleButton_MedReg_MedCarrDel.Location = new System.Drawing.Point(192, 88);
			this.simpleButton_MedReg_MedCarrDel.Name = "simpleButton_MedReg_MedCarrDel";
			this.simpleButton_MedReg_MedCarrDel.Size = new System.Drawing.Size(64, 24);
			this.simpleButton_MedReg_MedCarrDel.TabIndex = 2;
			this.simpleButton_MedReg_MedCarrDel.Text = "< 删除";
			this.simpleButton_MedReg_MedCarrDel.Click += new System.EventHandler(this.simpleButton_MedReg_MedCarrDel_Click);
			// 
			// simpleButton_MedReg_MedCarrAdd
			// 
			this.simpleButton_MedReg_MedCarrAdd.Enabled = false;
			this.simpleButton_MedReg_MedCarrAdd.Location = new System.Drawing.Point(192, 48);
			this.simpleButton_MedReg_MedCarrAdd.Name = "simpleButton_MedReg_MedCarrAdd";
			this.simpleButton_MedReg_MedCarrAdd.Size = new System.Drawing.Size(64, 24);
			this.simpleButton_MedReg_MedCarrAdd.TabIndex = 1;
			this.simpleButton_MedReg_MedCarrAdd.Text = "添加 >";
			this.simpleButton_MedReg_MedCarrAdd.Click += new System.EventHandler(this.simpleButton_MedReg_MedCarrAdd_Click);
			// 
			// listBoxControl_MedReg_MedInfo
			// 
			this.listBoxControl_MedReg_MedInfo.ItemHeight = 16;
			this.listBoxControl_MedReg_MedInfo.Location = new System.Drawing.Point(24, 24);
			this.listBoxControl_MedReg_MedInfo.Name = "listBoxControl_MedReg_MedInfo";
			this.barManager1.SetPopupContextMenu(this.listBoxControl_MedReg_MedInfo, this.popupMenu2);
			this.listBoxControl_MedReg_MedInfo.Size = new System.Drawing.Size(152, 112);
			this.listBoxControl_MedReg_MedInfo.TabIndex = 0;
			this.listBoxControl_MedReg_MedInfo.Click += new System.EventHandler(this.listBoxControl_MedReg_MedInfo_Click);
			this.listBoxControl_MedReg_MedInfo.DoubleClick += new System.EventHandler(this.listBoxControl_MedReg_MedInfo_DoubleClick);
			this.listBoxControl_MedReg_MedInfo.SelectedValueChanged += new System.EventHandler(this.listBoxControl_MedReg_MedInfo_SelectedValueChanged);
			// 
			// groupControl_MedReg_DiagInfo
			// 
			this.groupControl_MedReg_DiagInfo.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_MedReg_DiagInfo.AppearanceCaption.Options.UseFont = true;
			this.groupControl_MedReg_DiagInfo.Controls.Add(this.textEdit_MedReg_Else);
			this.groupControl_MedReg_DiagInfo.Controls.Add(this.textEdit_MedReg_FacialSym);
			this.groupControl_MedReg_DiagInfo.Controls.Add(this.notePanel_MedReg_Else);
			this.groupControl_MedReg_DiagInfo.Controls.Add(this.notePanel_MedReg_FacialSym);
			this.groupControl_MedReg_DiagInfo.Controls.Add(this.notePanel_MedReg_SkinSym);
			this.groupControl_MedReg_DiagInfo.Controls.Add(this.notePanel_MedReg_AbdomenSym);
			this.groupControl_MedReg_DiagInfo.Controls.Add(this.notePanel_MedReg_EnteronSym);
			this.groupControl_MedReg_DiagInfo.Controls.Add(this.textEdit_MedReg_SkinSym);
			this.groupControl_MedReg_DiagInfo.Controls.Add(this.textEdit_MedReg_AbdomenSym);
			this.groupControl_MedReg_DiagInfo.Controls.Add(this.textEdit_MedReg_EnteronSym);
			this.groupControl_MedReg_DiagInfo.Controls.Add(this.textEdit_MedReg_ThroatSym);
			this.groupControl_MedReg_DiagInfo.Controls.Add(this.notePanel__MedReg_ThroatSym);
			this.groupControl_MedReg_DiagInfo.Controls.Add(this.textEdit_MedReg_LungSym);
			this.groupControl_MedReg_DiagInfo.Controls.Add(this.notePanel_MedReg_LungSym);
			this.groupControl_MedReg_DiagInfo.Controls.Add(this.textEdit_MedReg_UpperSym);
			this.groupControl_MedReg_DiagInfo.Controls.Add(this.notePanel_MedReg_UpperSym);
			this.groupControl_MedReg_DiagInfo.Controls.Add(this.comboBoxEdit_MedReg_Diag);
			this.groupControl_MedReg_DiagInfo.Controls.Add(this.notePanel_MedReg_Diag);
			this.groupControl_MedReg_DiagInfo.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_MedReg_DiagInfo.Location = new System.Drawing.Point(0, 48);
			this.groupControl_MedReg_DiagInfo.Name = "groupControl_MedReg_DiagInfo";
			this.groupControl_MedReg_DiagInfo.Size = new System.Drawing.Size(469, 320);
			this.groupControl_MedReg_DiagInfo.TabIndex = 1;
			this.groupControl_MedReg_DiagInfo.Text = "诊断信息";
			// 
			// textEdit_MedReg_Else
			// 
			this.textEdit_MedReg_Else.EditValue = "";
			this.textEdit_MedReg_Else.Location = new System.Drawing.Point(144, 280);
			this.textEdit_MedReg_Else.Name = "textEdit_MedReg_Else";
			this.textEdit_MedReg_Else.Size = new System.Drawing.Size(256, 23);
			this.textEdit_MedReg_Else.TabIndex = 70;
			// 
			// textEdit_MedReg_FacialSym
			// 
			this.textEdit_MedReg_FacialSym.EditValue = "";
			this.textEdit_MedReg_FacialSym.Location = new System.Drawing.Point(144, 248);
			this.textEdit_MedReg_FacialSym.Name = "textEdit_MedReg_FacialSym";
			this.textEdit_MedReg_FacialSym.Size = new System.Drawing.Size(256, 23);
			this.textEdit_MedReg_FacialSym.TabIndex = 69;
			// 
			// notePanel_MedReg_Else
			// 
			this.notePanel_MedReg_Else.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedReg_Else.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedReg_Else.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedReg_Else.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedReg_Else.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedReg_Else.Location = new System.Drawing.Point(24, 280);
			this.notePanel_MedReg_Else.MaxRows = 5;
			this.notePanel_MedReg_Else.Name = "notePanel_MedReg_Else";
			this.notePanel_MedReg_Else.ParentAutoHeight = true;
			this.notePanel_MedReg_Else.Size = new System.Drawing.Size(96, 22);
			this.notePanel_MedReg_Else.TabIndex = 68;
			this.notePanel_MedReg_Else.TabStop = false;
			this.notePanel_MedReg_Else.Text = "  其他症状:";
			// 
			// notePanel_MedReg_FacialSym
			// 
			this.notePanel_MedReg_FacialSym.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedReg_FacialSym.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedReg_FacialSym.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedReg_FacialSym.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedReg_FacialSym.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedReg_FacialSym.Location = new System.Drawing.Point(24, 248);
			this.notePanel_MedReg_FacialSym.MaxRows = 5;
			this.notePanel_MedReg_FacialSym.Name = "notePanel_MedReg_FacialSym";
			this.notePanel_MedReg_FacialSym.ParentAutoHeight = true;
			this.notePanel_MedReg_FacialSym.Size = new System.Drawing.Size(96, 22);
			this.notePanel_MedReg_FacialSym.TabIndex = 67;
			this.notePanel_MedReg_FacialSym.TabStop = false;
			this.notePanel_MedReg_FacialSym.Text = "  五官症状:";
			// 
			// notePanel_MedReg_SkinSym
			// 
			this.notePanel_MedReg_SkinSym.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedReg_SkinSym.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedReg_SkinSym.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedReg_SkinSym.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedReg_SkinSym.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedReg_SkinSym.Location = new System.Drawing.Point(24, 216);
			this.notePanel_MedReg_SkinSym.MaxRows = 5;
			this.notePanel_MedReg_SkinSym.Name = "notePanel_MedReg_SkinSym";
			this.notePanel_MedReg_SkinSym.ParentAutoHeight = true;
			this.notePanel_MedReg_SkinSym.Size = new System.Drawing.Size(96, 22);
			this.notePanel_MedReg_SkinSym.TabIndex = 66;
			this.notePanel_MedReg_SkinSym.TabStop = false;
			this.notePanel_MedReg_SkinSym.Text = "  皮肤症状:";
			// 
			// notePanel_MedReg_AbdomenSym
			// 
			this.notePanel_MedReg_AbdomenSym.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedReg_AbdomenSym.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedReg_AbdomenSym.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedReg_AbdomenSym.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedReg_AbdomenSym.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedReg_AbdomenSym.Location = new System.Drawing.Point(24, 184);
			this.notePanel_MedReg_AbdomenSym.MaxRows = 5;
			this.notePanel_MedReg_AbdomenSym.Name = "notePanel_MedReg_AbdomenSym";
			this.notePanel_MedReg_AbdomenSym.ParentAutoHeight = true;
			this.notePanel_MedReg_AbdomenSym.Size = new System.Drawing.Size(96, 22);
			this.notePanel_MedReg_AbdomenSym.TabIndex = 65;
			this.notePanel_MedReg_AbdomenSym.TabStop = false;
			this.notePanel_MedReg_AbdomenSym.Text = "  腹部症状:";
			// 
			// notePanel_MedReg_EnteronSym
			// 
			this.notePanel_MedReg_EnteronSym.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedReg_EnteronSym.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedReg_EnteronSym.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedReg_EnteronSym.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedReg_EnteronSym.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedReg_EnteronSym.Location = new System.Drawing.Point(24, 152);
			this.notePanel_MedReg_EnteronSym.MaxRows = 5;
			this.notePanel_MedReg_EnteronSym.Name = "notePanel_MedReg_EnteronSym";
			this.notePanel_MedReg_EnteronSym.ParentAutoHeight = true;
			this.notePanel_MedReg_EnteronSym.Size = new System.Drawing.Size(96, 22);
			this.notePanel_MedReg_EnteronSym.TabIndex = 64;
			this.notePanel_MedReg_EnteronSym.TabStop = false;
			this.notePanel_MedReg_EnteronSym.Text = "消化道症状:";
			// 
			// textEdit_MedReg_SkinSym
			// 
			this.textEdit_MedReg_SkinSym.EditValue = "";
			this.textEdit_MedReg_SkinSym.Location = new System.Drawing.Point(144, 216);
			this.textEdit_MedReg_SkinSym.Name = "textEdit_MedReg_SkinSym";
			this.textEdit_MedReg_SkinSym.Size = new System.Drawing.Size(256, 23);
			this.textEdit_MedReg_SkinSym.TabIndex = 63;
			// 
			// textEdit_MedReg_AbdomenSym
			// 
			this.textEdit_MedReg_AbdomenSym.EditValue = "";
			this.textEdit_MedReg_AbdomenSym.Location = new System.Drawing.Point(144, 184);
			this.textEdit_MedReg_AbdomenSym.Name = "textEdit_MedReg_AbdomenSym";
			this.textEdit_MedReg_AbdomenSym.Size = new System.Drawing.Size(256, 23);
			this.textEdit_MedReg_AbdomenSym.TabIndex = 62;
			// 
			// textEdit_MedReg_EnteronSym
			// 
			this.textEdit_MedReg_EnteronSym.EditValue = "";
			this.textEdit_MedReg_EnteronSym.Location = new System.Drawing.Point(144, 152);
			this.textEdit_MedReg_EnteronSym.Name = "textEdit_MedReg_EnteronSym";
			this.textEdit_MedReg_EnteronSym.Size = new System.Drawing.Size(256, 23);
			this.textEdit_MedReg_EnteronSym.TabIndex = 61;
			// 
			// textEdit_MedReg_ThroatSym
			// 
			this.textEdit_MedReg_ThroatSym.EditValue = "";
			this.textEdit_MedReg_ThroatSym.Location = new System.Drawing.Point(144, 120);
			this.textEdit_MedReg_ThroatSym.Name = "textEdit_MedReg_ThroatSym";
			this.textEdit_MedReg_ThroatSym.Size = new System.Drawing.Size(256, 23);
			this.textEdit_MedReg_ThroatSym.TabIndex = 60;
			// 
			// notePanel__MedReg_ThroatSym
			// 
			this.notePanel__MedReg_ThroatSym.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel__MedReg_ThroatSym.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel__MedReg_ThroatSym.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel__MedReg_ThroatSym.ForeColor = System.Drawing.Color.Black;
			this.notePanel__MedReg_ThroatSym.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel__MedReg_ThroatSym.Location = new System.Drawing.Point(24, 120);
			this.notePanel__MedReg_ThroatSym.MaxRows = 5;
			this.notePanel__MedReg_ThroatSym.Name = "notePanel__MedReg_ThroatSym";
			this.notePanel__MedReg_ThroatSym.ParentAutoHeight = true;
			this.notePanel__MedReg_ThroatSym.Size = new System.Drawing.Size(96, 22);
			this.notePanel__MedReg_ThroatSym.TabIndex = 59;
			this.notePanel__MedReg_ThroatSym.TabStop = false;
			this.notePanel__MedReg_ThroatSym.Text = "咽喉部症状:";
			// 
			// textEdit_MedReg_LungSym
			// 
			this.textEdit_MedReg_LungSym.EditValue = "";
			this.textEdit_MedReg_LungSym.Location = new System.Drawing.Point(144, 88);
			this.textEdit_MedReg_LungSym.Name = "textEdit_MedReg_LungSym";
			this.textEdit_MedReg_LungSym.Size = new System.Drawing.Size(256, 23);
			this.textEdit_MedReg_LungSym.TabIndex = 58;
			// 
			// notePanel_MedReg_LungSym
			// 
			this.notePanel_MedReg_LungSym.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedReg_LungSym.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedReg_LungSym.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedReg_LungSym.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedReg_LungSym.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedReg_LungSym.Location = new System.Drawing.Point(24, 88);
			this.notePanel_MedReg_LungSym.MaxRows = 5;
			this.notePanel_MedReg_LungSym.Name = "notePanel_MedReg_LungSym";
			this.notePanel_MedReg_LungSym.ParentAutoHeight = true;
			this.notePanel_MedReg_LungSym.Size = new System.Drawing.Size(96, 22);
			this.notePanel_MedReg_LungSym.TabIndex = 57;
			this.notePanel_MedReg_LungSym.TabStop = false;
			this.notePanel_MedReg_LungSym.Text = "  肺部症状:";
			// 
			// textEdit_MedReg_UpperSym
			// 
			this.textEdit_MedReg_UpperSym.EditValue = "";
			this.textEdit_MedReg_UpperSym.Location = new System.Drawing.Point(144, 56);
			this.textEdit_MedReg_UpperSym.Name = "textEdit_MedReg_UpperSym";
			this.textEdit_MedReg_UpperSym.Size = new System.Drawing.Size(256, 23);
			this.textEdit_MedReg_UpperSym.TabIndex = 56;
			// 
			// notePanel_MedReg_UpperSym
			// 
			this.notePanel_MedReg_UpperSym.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedReg_UpperSym.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedReg_UpperSym.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedReg_UpperSym.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedReg_UpperSym.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedReg_UpperSym.Location = new System.Drawing.Point(24, 56);
			this.notePanel_MedReg_UpperSym.MaxRows = 5;
			this.notePanel_MedReg_UpperSym.Name = "notePanel_MedReg_UpperSym";
			this.notePanel_MedReg_UpperSym.ParentAutoHeight = true;
			this.notePanel_MedReg_UpperSym.Size = new System.Drawing.Size(96, 22);
			this.notePanel_MedReg_UpperSym.TabIndex = 54;
			this.notePanel_MedReg_UpperSym.TabStop = false;
			this.notePanel_MedReg_UpperSym.Text = "  上感症状:";
			// 
			// comboBoxEdit_MedReg_Diag
			// 
			this.comboBoxEdit_MedReg_Diag.EditValue = "";
			this.comboBoxEdit_MedReg_Diag.Location = new System.Drawing.Point(144, 24);
			this.comboBoxEdit_MedReg_Diag.Name = "comboBoxEdit_MedReg_Diag";
			// 
			// comboBoxEdit_MedReg_Diag.Properties
			// 
			this.comboBoxEdit_MedReg_Diag.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_MedReg_Diag.Properties.Items.AddRange(new object[] {
																					 "上感",
																					 "预防",
																					 "保健",
																					 "肺炎",
																					 "气管炎",
																					 "胃炎",
																					 "消化不良",
																					 "皮疹",
																					 "荨麻疹",
																					 "口腔溃疡",
																					 "口角炎",
																					 "浓疱疹",
																					 "腹痛",
																					 "腹泻",
																					 "中耳炎",
																					 "牙龈炎",
																					 "牙痛",
																					 "鼻出血",
																					 "外伤"});
			this.comboBoxEdit_MedReg_Diag.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_MedReg_Diag.Size = new System.Drawing.Size(104, 23);
			this.comboBoxEdit_MedReg_Diag.TabIndex = 53;
			// 
			// notePanel_MedReg_Diag
			// 
			this.notePanel_MedReg_Diag.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedReg_Diag.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedReg_Diag.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedReg_Diag.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedReg_Diag.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedReg_Diag.Location = new System.Drawing.Point(24, 24);
			this.notePanel_MedReg_Diag.MaxRows = 5;
			this.notePanel_MedReg_Diag.Name = "notePanel_MedReg_Diag";
			this.notePanel_MedReg_Diag.ParentAutoHeight = true;
			this.notePanel_MedReg_Diag.Size = new System.Drawing.Size(96, 22);
			this.notePanel_MedReg_Diag.TabIndex = 52;
			this.notePanel_MedReg_Diag.TabStop = false;
			this.notePanel_MedReg_Diag.Text = "  症状诊断:";
			// 
			// panelControl8
			// 
			this.panelControl8.Controls.Add(this.simpleButton_MedReg_Ser);
			this.panelControl8.Controls.Add(this.simpleButton_MedReg_Modify);
			this.panelControl8.Controls.Add(this.simpleButton_MedReg_Reg);
			this.panelControl8.Controls.Add(this.simpleButton_MedReg_Save);
			this.panelControl8.Controls.Add(this.simpleButton_MedReg_Back);
			this.panelControl8.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl8.Location = new System.Drawing.Point(0, 0);
			this.panelControl8.Name = "panelControl8";
			this.panelControl8.Size = new System.Drawing.Size(469, 48);
			this.panelControl8.TabIndex = 0;
			this.panelControl8.Text = "panelControl8";
			// 
			// simpleButton_MedReg_Ser
			// 
			this.simpleButton_MedReg_Ser.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_MedReg_Ser.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_MedReg_Ser.Appearance.Options.UseFont = true;
			this.simpleButton_MedReg_Ser.Appearance.Options.UseForeColor = true;
			this.simpleButton_MedReg_Ser.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_MedReg_Ser.Image")));
			this.simpleButton_MedReg_Ser.Location = new System.Drawing.Point(8, 8);
			this.simpleButton_MedReg_Ser.Name = "simpleButton_MedReg_Ser";
			this.simpleButton_MedReg_Ser.Size = new System.Drawing.Size(80, 26);
			this.simpleButton_MedReg_Ser.TabIndex = 23;
			this.simpleButton_MedReg_Ser.Tag = 4;
			this.simpleButton_MedReg_Ser.Text = "检  索";
			this.simpleButton_MedReg_Ser.Click += new System.EventHandler(this.simpleButton_MedReg_Ser_Click);
			// 
			// simpleButton_MedReg_Modify
			// 
			this.simpleButton_MedReg_Modify.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_MedReg_Modify.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_MedReg_Modify.Appearance.Options.UseFont = true;
			this.simpleButton_MedReg_Modify.Appearance.Options.UseForeColor = true;
			this.simpleButton_MedReg_Modify.Enabled = false;
			this.simpleButton_MedReg_Modify.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_MedReg_Modify.Image")));
			this.simpleButton_MedReg_Modify.Location = new System.Drawing.Point(392, 8);
			this.simpleButton_MedReg_Modify.Name = "simpleButton_MedReg_Modify";
			this.simpleButton_MedReg_Modify.Size = new System.Drawing.Size(96, 26);
			this.simpleButton_MedReg_Modify.TabIndex = 22;
			this.simpleButton_MedReg_Modify.Tag = 4;
			this.simpleButton_MedReg_Modify.Text = "药品修改";
			this.simpleButton_MedReg_Modify.Click += new System.EventHandler(this.simpleButton_MedReg_Modify_Click);
			// 
			// simpleButton_MedReg_Reg
			// 
			this.simpleButton_MedReg_Reg.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_MedReg_Reg.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_MedReg_Reg.Appearance.Options.UseFont = true;
			this.simpleButton_MedReg_Reg.Appearance.Options.UseForeColor = true;
			this.simpleButton_MedReg_Reg.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_MedReg_Reg.Image")));
			this.simpleButton_MedReg_Reg.Location = new System.Drawing.Point(184, 8);
			this.simpleButton_MedReg_Reg.Name = "simpleButton_MedReg_Reg";
			this.simpleButton_MedReg_Reg.Size = new System.Drawing.Size(96, 26);
			this.simpleButton_MedReg_Reg.TabIndex = 20;
			this.simpleButton_MedReg_Reg.Tag = 4;
			this.simpleButton_MedReg_Reg.Text = "诊断登记";
			this.simpleButton_MedReg_Reg.Click += new System.EventHandler(this.simpleButton_MedReg_Reg_Click);
			// 
			// simpleButton_MedReg_Save
			// 
			this.simpleButton_MedReg_Save.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_MedReg_Save.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_MedReg_Save.Appearance.Options.UseFont = true;
			this.simpleButton_MedReg_Save.Appearance.Options.UseForeColor = true;
			this.simpleButton_MedReg_Save.Enabled = false;
			this.simpleButton_MedReg_Save.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_MedReg_Save.Image")));
			this.simpleButton_MedReg_Save.Location = new System.Drawing.Point(288, 8);
			this.simpleButton_MedReg_Save.Name = "simpleButton_MedReg_Save";
			this.simpleButton_MedReg_Save.Size = new System.Drawing.Size(96, 26);
			this.simpleButton_MedReg_Save.TabIndex = 20;
			this.simpleButton_MedReg_Save.Tag = 4;
			this.simpleButton_MedReg_Save.Text = "药品保存";
			this.simpleButton_MedReg_Save.Click += new System.EventHandler(this.simpleButton_MedReg_Save_Click);
			// 
			// simpleButton_MedReg_Back
			// 
			this.simpleButton_MedReg_Back.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_MedReg_Back.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_MedReg_Back.Appearance.Options.UseFont = true;
			this.simpleButton_MedReg_Back.Appearance.Options.UseForeColor = true;
			this.simpleButton_MedReg_Back.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_MedReg_Back.Image")));
			this.simpleButton_MedReg_Back.Location = new System.Drawing.Point(96, 8);
			this.simpleButton_MedReg_Back.Name = "simpleButton_MedReg_Back";
			this.simpleButton_MedReg_Back.Size = new System.Drawing.Size(80, 26);
			this.simpleButton_MedReg_Back.TabIndex = 21;
			this.simpleButton_MedReg_Back.Tag = 4;
			this.simpleButton_MedReg_Back.Text = "返  回";
			this.simpleButton_MedReg_Back.Click += new System.EventHandler(this.simpleButton_MedReg_Back_Click);
			// 
			// xtraTabPage9
			// 
			this.xtraTabPage9.Appearance.PageClient.BackColor = System.Drawing.Color.WhiteSmoke;
			this.xtraTabPage9.Appearance.PageClient.Options.UseBackColor = true;
			this.xtraTabPage9.Controls.Add(this.splitContainerControl10);
			this.xtraTabPage9.Name = "xtraTabPage9";
			this.xtraTabPage9.PageVisible = false;
			this.xtraTabPage9.Size = new System.Drawing.Size(768, 515);
			this.xtraTabPage9.Text = "服药记录";
			// 
			// splitContainerControl10
			// 
			this.splitContainerControl10.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl10.Location = new System.Drawing.Point(0, 0);
			this.splitContainerControl10.Name = "splitContainerControl10";
			this.splitContainerControl10.Panel1.Controls.Add(this.groupControl_MedRec_AbnStuList);
			this.splitContainerControl10.Panel1.Controls.Add(this.groupControl_MedRec_Ser);
			this.splitContainerControl10.Panel1.Text = "splitContainerControl10_Panel1";
			this.splitContainerControl10.Panel2.Controls.Add(this.groupControl_MedRec_DiagAndDoseAdd);
			this.splitContainerControl10.Panel2.Controls.Add(this.groupControl_MedRec_DoseRec);
			this.splitContainerControl10.Panel2.Controls.Add(this.panelControl9);
			this.splitContainerControl10.Panel2.Text = "splitContainerControl10_Panel2";
			this.splitContainerControl10.Size = new System.Drawing.Size(768, 515);
			this.splitContainerControl10.SplitterPosition = 281;
			this.splitContainerControl10.TabIndex = 0;
			this.splitContainerControl10.Text = "splitContainerControl10";
			// 
			// groupControl_MedRec_AbnStuList
			// 
			this.groupControl_MedRec_AbnStuList.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_MedRec_AbnStuList.AppearanceCaption.Options.UseFont = true;
			this.groupControl_MedRec_AbnStuList.Controls.Add(this.gridControl_MedRec_AbnStuList);
			this.groupControl_MedRec_AbnStuList.Controls.Add(this.notePanel_MedRec_AbnStuList);
			this.groupControl_MedRec_AbnStuList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl_MedRec_AbnStuList.Location = new System.Drawing.Point(0, 256);
			this.groupControl_MedRec_AbnStuList.Name = "groupControl_MedRec_AbnStuList";
			this.groupControl_MedRec_AbnStuList.Size = new System.Drawing.Size(275, 253);
			this.groupControl_MedRec_AbnStuList.TabIndex = 3;
			this.groupControl_MedRec_AbnStuList.Text = "晨检异常幼儿列表";
			// 
			// gridControl_MedRec_AbnStuList
			// 
			this.gridControl_MedRec_AbnStuList.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl_MedRec_AbnStuList.EmbeddedNavigator
			// 
			this.gridControl_MedRec_AbnStuList.EmbeddedNavigator.Name = "";
			this.gridControl_MedRec_AbnStuList.Location = new System.Drawing.Point(3, 41);
			this.gridControl_MedRec_AbnStuList.MainView = this.gridView10;
			this.gridControl_MedRec_AbnStuList.Name = "gridControl_MedRec_AbnStuList";
			this.gridControl_MedRec_AbnStuList.Size = new System.Drawing.Size(269, 209);
			this.gridControl_MedRec_AbnStuList.TabIndex = 59;
			this.gridControl_MedRec_AbnStuList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																														 this.gridView10});
			this.gridControl_MedRec_AbnStuList.DoubleClick += new System.EventHandler(this.gridControl_MedRec_AbnStuList_DoubleClick);
			// 
			// gridView10
			// 
			this.gridView10.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							  this.gridColumn39,
																							  this.gridColumn40,
																							  this.gridColumn41,
																							  this.gridColumn42,
																							  this.gridColumn43});
			this.gridView10.GridControl = this.gridControl_MedRec_AbnStuList;
			this.gridView10.Name = "gridView10";
			this.gridView10.OptionsCustomization.AllowFilter = false;
			this.gridView10.OptionsView.ShowFilterPanel = false;
			this.gridView10.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn39
			// 
			this.gridColumn39.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn39.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn39.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn39.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn39.Caption = "学号";
			this.gridColumn39.FieldName = "info_stuNumber";
			this.gridColumn39.Name = "gridColumn39";
			this.gridColumn39.OptionsColumn.AllowEdit = false;
			this.gridColumn39.OptionsColumn.AllowFocus = false;
			this.gridColumn39.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn39.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn39.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn39.OptionsColumn.AllowMove = false;
			this.gridColumn39.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn39.OptionsColumn.ReadOnly = true;
			this.gridColumn39.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn39.Visible = true;
			this.gridColumn39.VisibleIndex = 0;
			this.gridColumn39.Width = 48;
			// 
			// gridColumn40
			// 
			this.gridColumn40.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn40.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn40.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn40.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn40.Caption = "姓名";
			this.gridColumn40.FieldName = "info_stuName";
			this.gridColumn40.Name = "gridColumn40";
			this.gridColumn40.OptionsColumn.AllowEdit = false;
			this.gridColumn40.OptionsColumn.AllowFocus = false;
			this.gridColumn40.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn40.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn40.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn40.OptionsColumn.AllowMove = false;
			this.gridColumn40.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn40.OptionsColumn.ReadOnly = true;
			this.gridColumn40.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn40.Visible = true;
			this.gridColumn40.VisibleIndex = 1;
			this.gridColumn40.Width = 47;
			// 
			// gridColumn41
			// 
			this.gridColumn41.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn41.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn41.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn41.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn41.Caption = "班级";
			this.gridColumn41.FieldName = "info_className";
			this.gridColumn41.Name = "gridColumn41";
			this.gridColumn41.OptionsColumn.AllowEdit = false;
			this.gridColumn41.OptionsColumn.AllowFocus = false;
			this.gridColumn41.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn41.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn41.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn41.OptionsColumn.AllowMove = false;
			this.gridColumn41.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn41.OptionsColumn.ReadOnly = true;
			this.gridColumn41.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn41.Visible = true;
			this.gridColumn41.VisibleIndex = 2;
			this.gridColumn41.Width = 49;
			// 
			// gridColumn42
			// 
			this.gridColumn42.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn42.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn42.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn42.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn42.Caption = "登记日期";
			this.gridColumn42.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
			this.gridColumn42.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.gridColumn42.FieldName = "register_Time";
			this.gridColumn42.Name = "gridColumn42";
			this.gridColumn42.OptionsColumn.AllowEdit = false;
			this.gridColumn42.OptionsColumn.AllowFocus = false;
			this.gridColumn42.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn42.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn42.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn42.OptionsColumn.AllowMove = false;
			this.gridColumn42.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn42.OptionsColumn.ReadOnly = true;
			this.gridColumn42.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn42.Visible = true;
			this.gridColumn42.VisibleIndex = 3;
			this.gridColumn42.Width = 57;
			// 
			// gridColumn43
			// 
			this.gridColumn43.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn43.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn43.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn43.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn43.Caption = "登记教师";
			this.gridColumn43.FieldName = "teacher_Sign";
			this.gridColumn43.Name = "gridColumn43";
			this.gridColumn43.OptionsColumn.AllowEdit = false;
			this.gridColumn43.OptionsColumn.AllowFocus = false;
			this.gridColumn43.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn43.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn43.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn43.OptionsColumn.AllowMove = false;
			this.gridColumn43.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn43.OptionsColumn.ReadOnly = true;
			this.gridColumn43.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn43.Visible = true;
			this.gridColumn43.VisibleIndex = 4;
			this.gridColumn43.Width = 63;
			// 
			// notePanel_MedRec_AbnStuList
			// 
			this.notePanel_MedRec_AbnStuList.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel_MedRec_AbnStuList.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel_MedRec_AbnStuList.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel_MedRec_AbnStuList.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedRec_AbnStuList.Location = new System.Drawing.Point(3, 18);
			this.notePanel_MedRec_AbnStuList.MaxRows = 5;
			this.notePanel_MedRec_AbnStuList.Name = "notePanel_MedRec_AbnStuList";
			this.notePanel_MedRec_AbnStuList.ParentAutoHeight = true;
			this.notePanel_MedRec_AbnStuList.Size = new System.Drawing.Size(269, 23);
			this.notePanel_MedRec_AbnStuList.TabIndex = 58;
			this.notePanel_MedRec_AbnStuList.TabStop = false;
			this.notePanel_MedRec_AbnStuList.Text = "双击显示特定幼儿";
			// 
			// groupControl_MedRec_Ser
			// 
			this.groupControl_MedRec_Ser.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_MedRec_Ser.AppearanceCaption.Options.UseFont = true;
			this.groupControl_MedRec_Ser.Controls.Add(this.textEdit_MedRec_Number);
			this.groupControl_MedRec_Ser.Controls.Add(this.textEdit_MedRec_Name);
			this.groupControl_MedRec_Ser.Controls.Add(this.dateEdit_MedRec_EndDate);
			this.groupControl_MedRec_Ser.Controls.Add(this.notePanel_MedRec_EndDate);
			this.groupControl_MedRec_Ser.Controls.Add(this.dateEdit_MedRec_BegDate);
			this.groupControl_MedRec_Ser.Controls.Add(this.notePanel_MedRec_BegDate);
			this.groupControl_MedRec_Ser.Controls.Add(this.notePanel_MedRec_Ser);
			this.groupControl_MedRec_Ser.Controls.Add(this.textEdit_MedRec_DoseRecDiaID);
			this.groupControl_MedRec_Ser.Controls.Add(this.textEdit_MedRec_AbnDiaID);
			this.groupControl_MedRec_Ser.Controls.Add(this.comboBoxEdit_MedRec_Class);
			this.groupControl_MedRec_Ser.Controls.Add(this.notePanel_MedRec_Class);
			this.groupControl_MedRec_Ser.Controls.Add(this.comboBoxEdit_MedRec_Grade);
			this.groupControl_MedRec_Ser.Controls.Add(this.notePanel_MedRec_Grade);
			this.groupControl_MedRec_Ser.Controls.Add(this.notePanel_MedRec_Number);
			this.groupControl_MedRec_Ser.Controls.Add(this.notePanel_MedRec_Name);
			this.groupControl_MedRec_Ser.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_MedRec_Ser.Location = new System.Drawing.Point(0, 0);
			this.groupControl_MedRec_Ser.Name = "groupControl_MedRec_Ser";
			this.groupControl_MedRec_Ser.Size = new System.Drawing.Size(275, 256);
			this.groupControl_MedRec_Ser.TabIndex = 2;
			this.groupControl_MedRec_Ser.Text = "晨检异常幼儿查询";
			// 
			// textEdit_MedRec_Number
			// 
			this.textEdit_MedRec_Number.EditValue = "";
			this.textEdit_MedRec_Number.Location = new System.Drawing.Point(144, 152);
			this.textEdit_MedRec_Number.Name = "textEdit_MedRec_Number";
			this.textEdit_MedRec_Number.Size = new System.Drawing.Size(88, 23);
			this.textEdit_MedRec_Number.TabIndex = 63;
			this.textEdit_MedRec_Number.EditValueChanged += new System.EventHandler(this.textEdit_MedRec_Number_EditValueChanged);
			// 
			// textEdit_MedRec_Name
			// 
			this.textEdit_MedRec_Name.EditValue = "";
			this.textEdit_MedRec_Name.Location = new System.Drawing.Point(144, 120);
			this.textEdit_MedRec_Name.Name = "textEdit_MedRec_Name";
			this.textEdit_MedRec_Name.Size = new System.Drawing.Size(88, 23);
			this.textEdit_MedRec_Name.TabIndex = 62;
			this.textEdit_MedRec_Name.EditValueChanged += new System.EventHandler(this.textEdit_MedRec_Name_EditValueChanged);
			// 
			// dateEdit_MedRec_EndDate
			// 
			this.dateEdit_MedRec_EndDate.EditValue = new System.DateTime(2005, 1, 24, 0, 0, 0, 0);
			this.dateEdit_MedRec_EndDate.Location = new System.Drawing.Point(144, 216);
			this.dateEdit_MedRec_EndDate.Name = "dateEdit_MedRec_EndDate";
			// 
			// dateEdit_MedRec_EndDate.Properties
			// 
			this.dateEdit_MedRec_EndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit_MedRec_EndDate.Properties.Mask.EditMask = "d";
			this.dateEdit_MedRec_EndDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
			this.dateEdit_MedRec_EndDate.Size = new System.Drawing.Size(88, 23);
			this.dateEdit_MedRec_EndDate.TabIndex = 61;
			// 
			// notePanel_MedRec_EndDate
			// 
			this.notePanel_MedRec_EndDate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedRec_EndDate.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedRec_EndDate.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedRec_EndDate.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedRec_EndDate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedRec_EndDate.Location = new System.Drawing.Point(40, 216);
			this.notePanel_MedRec_EndDate.MaxRows = 5;
			this.notePanel_MedRec_EndDate.Name = "notePanel_MedRec_EndDate";
			this.notePanel_MedRec_EndDate.ParentAutoHeight = true;
			this.notePanel_MedRec_EndDate.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MedRec_EndDate.TabIndex = 60;
			this.notePanel_MedRec_EndDate.TabStop = false;
			this.notePanel_MedRec_EndDate.Text = "结束日期:";
			// 
			// dateEdit_MedRec_BegDate
			// 
			this.dateEdit_MedRec_BegDate.EditValue = new System.DateTime(2005, 1, 24, 0, 0, 0, 0);
			this.dateEdit_MedRec_BegDate.Location = new System.Drawing.Point(144, 184);
			this.dateEdit_MedRec_BegDate.Name = "dateEdit_MedRec_BegDate";
			// 
			// dateEdit_MedRec_BegDate.Properties
			// 
			this.dateEdit_MedRec_BegDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit_MedRec_BegDate.Properties.Mask.EditMask = "d";
			this.dateEdit_MedRec_BegDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
			this.dateEdit_MedRec_BegDate.Size = new System.Drawing.Size(88, 23);
			this.dateEdit_MedRec_BegDate.TabIndex = 59;
			// 
			// notePanel_MedRec_BegDate
			// 
			this.notePanel_MedRec_BegDate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedRec_BegDate.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedRec_BegDate.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedRec_BegDate.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedRec_BegDate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedRec_BegDate.Location = new System.Drawing.Point(40, 184);
			this.notePanel_MedRec_BegDate.MaxRows = 5;
			this.notePanel_MedRec_BegDate.Name = "notePanel_MedRec_BegDate";
			this.notePanel_MedRec_BegDate.ParentAutoHeight = true;
			this.notePanel_MedRec_BegDate.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MedRec_BegDate.TabIndex = 58;
			this.notePanel_MedRec_BegDate.TabStop = false;
			this.notePanel_MedRec_BegDate.Text = "起始日期:";
			// 
			// notePanel_MedRec_Ser
			// 
			this.notePanel_MedRec_Ser.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel_MedRec_Ser.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel_MedRec_Ser.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel_MedRec_Ser.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedRec_Ser.Location = new System.Drawing.Point(3, 18);
			this.notePanel_MedRec_Ser.MaxRows = 5;
			this.notePanel_MedRec_Ser.Name = "notePanel_MedRec_Ser";
			this.notePanel_MedRec_Ser.ParentAutoHeight = true;
			this.notePanel_MedRec_Ser.Size = new System.Drawing.Size(269, 23);
			this.notePanel_MedRec_Ser.TabIndex = 57;
			this.notePanel_MedRec_Ser.TabStop = false;
			this.notePanel_MedRec_Ser.Text = "检索您的幼儿";
			// 
			// textEdit_MedRec_DoseRecDiaID
			// 
			this.textEdit_MedRec_DoseRecDiaID.EditValue = "";
			this.textEdit_MedRec_DoseRecDiaID.Location = new System.Drawing.Point(192, 160);
			this.textEdit_MedRec_DoseRecDiaID.Name = "textEdit_MedRec_DoseRecDiaID";
			// 
			// textEdit_MedRec_DoseRecDiaID.Properties
			// 
			this.textEdit_MedRec_DoseRecDiaID.Properties.AutoHeight = false;
			this.textEdit_MedRec_DoseRecDiaID.Size = new System.Drawing.Size(8, 8);
			this.textEdit_MedRec_DoseRecDiaID.TabIndex = 56;
			// 
			// textEdit_MedRec_AbnDiaID
			// 
			this.textEdit_MedRec_AbnDiaID.EditValue = "";
			this.textEdit_MedRec_AbnDiaID.Location = new System.Drawing.Point(184, 128);
			this.textEdit_MedRec_AbnDiaID.Name = "textEdit_MedRec_AbnDiaID";
			// 
			// textEdit_MedRec_AbnDiaID.Properties
			// 
			this.textEdit_MedRec_AbnDiaID.Properties.AutoHeight = false;
			this.textEdit_MedRec_AbnDiaID.Size = new System.Drawing.Size(8, 8);
			this.textEdit_MedRec_AbnDiaID.TabIndex = 55;
			// 
			// comboBoxEdit_MedRec_Class
			// 
			this.comboBoxEdit_MedRec_Class.EditValue = "全部";
			this.comboBoxEdit_MedRec_Class.Location = new System.Drawing.Point(144, 88);
			this.comboBoxEdit_MedRec_Class.Name = "comboBoxEdit_MedRec_Class";
			// 
			// comboBoxEdit_MedRec_Class.Properties
			// 
			this.comboBoxEdit_MedRec_Class.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_MedRec_Class.Properties.Items.AddRange(new object[] {
																					  "全部"});
			this.comboBoxEdit_MedRec_Class.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_MedRec_Class.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_MedRec_Class.TabIndex = 54;
			this.comboBoxEdit_MedRec_Class.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_MedRec_Class_SelectedIndexChanged);
			// 
			// notePanel_MedRec_Class
			// 
			this.notePanel_MedRec_Class.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedRec_Class.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedRec_Class.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedRec_Class.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedRec_Class.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedRec_Class.Location = new System.Drawing.Point(40, 88);
			this.notePanel_MedRec_Class.MaxRows = 5;
			this.notePanel_MedRec_Class.Name = "notePanel_MedRec_Class";
			this.notePanel_MedRec_Class.ParentAutoHeight = true;
			this.notePanel_MedRec_Class.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MedRec_Class.TabIndex = 53;
			this.notePanel_MedRec_Class.TabStop = false;
			this.notePanel_MedRec_Class.Text = "  班  级:";
			// 
			// comboBoxEdit_MedRec_Grade
			// 
			this.comboBoxEdit_MedRec_Grade.EditValue = "全部";
			this.comboBoxEdit_MedRec_Grade.Location = new System.Drawing.Point(144, 56);
			this.comboBoxEdit_MedRec_Grade.Name = "comboBoxEdit_MedRec_Grade";
			// 
			// comboBoxEdit_MedRec_Grade.Properties
			// 
			this.comboBoxEdit_MedRec_Grade.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_MedRec_Grade.Properties.Items.AddRange(new object[] {
																					  "全部"});
			this.comboBoxEdit_MedRec_Grade.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_MedRec_Grade.Size = new System.Drawing.Size(88, 23);
			this.comboBoxEdit_MedRec_Grade.TabIndex = 52;
			this.comboBoxEdit_MedRec_Grade.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_MedRec_Grade_SelectedIndexChanged);
			// 
			// notePanel_MedRec_Grade
			// 
			this.notePanel_MedRec_Grade.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedRec_Grade.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedRec_Grade.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedRec_Grade.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedRec_Grade.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedRec_Grade.Location = new System.Drawing.Point(40, 56);
			this.notePanel_MedRec_Grade.MaxRows = 5;
			this.notePanel_MedRec_Grade.Name = "notePanel_MedRec_Grade";
			this.notePanel_MedRec_Grade.ParentAutoHeight = true;
			this.notePanel_MedRec_Grade.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MedRec_Grade.TabIndex = 51;
			this.notePanel_MedRec_Grade.TabStop = false;
			this.notePanel_MedRec_Grade.Text = "  年  级:";
			// 
			// notePanel_MedRec_Number
			// 
			this.notePanel_MedRec_Number.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedRec_Number.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedRec_Number.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedRec_Number.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedRec_Number.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedRec_Number.Location = new System.Drawing.Point(40, 152);
			this.notePanel_MedRec_Number.MaxRows = 5;
			this.notePanel_MedRec_Number.Name = "notePanel_MedRec_Number";
			this.notePanel_MedRec_Number.ParentAutoHeight = true;
			this.notePanel_MedRec_Number.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MedRec_Number.TabIndex = 50;
			this.notePanel_MedRec_Number.TabStop = false;
			this.notePanel_MedRec_Number.Text = "  学  号:";
			// 
			// notePanel_MedRec_Name
			// 
			this.notePanel_MedRec_Name.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedRec_Name.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedRec_Name.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedRec_Name.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedRec_Name.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedRec_Name.Location = new System.Drawing.Point(40, 120);
			this.notePanel_MedRec_Name.MaxRows = 5;
			this.notePanel_MedRec_Name.Name = "notePanel_MedRec_Name";
			this.notePanel_MedRec_Name.ParentAutoHeight = true;
			this.notePanel_MedRec_Name.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MedRec_Name.TabIndex = 49;
			this.notePanel_MedRec_Name.TabStop = false;
			this.notePanel_MedRec_Name.Text = "  姓  名:";
			// 
			// groupControl_MedRec_DiagAndDoseAdd
			// 
			this.groupControl_MedRec_DiagAndDoseAdd.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_MedRec_DiagAndDoseAdd.AppearanceCaption.Options.UseFont = true;
			this.groupControl_MedRec_DiagAndDoseAdd.Controls.Add(this.groupControl_MedRec_DoseAdd);
			this.groupControl_MedRec_DiagAndDoseAdd.Controls.Add(this.groupControl_MedRec_DiagInfo);
			this.groupControl_MedRec_DiagAndDoseAdd.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl_MedRec_DiagAndDoseAdd.Location = new System.Drawing.Point(0, 48);
			this.groupControl_MedRec_DiagAndDoseAdd.Name = "groupControl_MedRec_DiagAndDoseAdd";
			this.groupControl_MedRec_DiagAndDoseAdd.Size = new System.Drawing.Size(477, 461);
			this.groupControl_MedRec_DiagAndDoseAdd.TabIndex = 2;
			this.groupControl_MedRec_DiagAndDoseAdd.Text = "晨检诊断及服药添加";
			this.groupControl_MedRec_DiagAndDoseAdd.Visible = false;
			// 
			// groupControl_MedRec_DoseAdd
			// 
			this.groupControl_MedRec_DoseAdd.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_MedRec_DoseAdd.AppearanceCaption.Options.UseFont = true;
			this.groupControl_MedRec_DoseAdd.Controls.Add(this.notePanel_MedRec_TakeRule);
			this.groupControl_MedRec_DoseAdd.Controls.Add(this.listBoxControl_MedRec_MedCarrInfo);
			this.groupControl_MedRec_DoseAdd.Controls.Add(this.comboBoxEdit_MedRec_TakeRule);
			this.groupControl_MedRec_DoseAdd.Controls.Add(this.timeEdit_MedRec_TakeTime);
			this.groupControl_MedRec_DoseAdd.Controls.Add(this.notePanel_MedRec_TakeDate);
			this.groupControl_MedRec_DoseAdd.Controls.Add(this.textEdit_MedRec_MedTake);
			this.groupControl_MedRec_DoseAdd.Controls.Add(this.notePanel_MedRec_MedTake);
			this.groupControl_MedRec_DoseAdd.Controls.Add(this.textEdit_MedRec_MedName);
			this.groupControl_MedRec_DoseAdd.Controls.Add(this.notePanel_MedRec_MedName);
			this.groupControl_MedRec_DoseAdd.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl_MedRec_DoseAdd.Location = new System.Drawing.Point(3, 272);
			this.groupControl_MedRec_DoseAdd.Name = "groupControl_MedRec_DoseAdd";
			this.groupControl_MedRec_DoseAdd.Size = new System.Drawing.Size(471, 186);
			this.groupControl_MedRec_DoseAdd.TabIndex = 3;
			this.groupControl_MedRec_DoseAdd.Text = "添加服药记录";
			// 
			// notePanel_MedRec_TakeRule
			// 
			this.notePanel_MedRec_TakeRule.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedRec_TakeRule.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedRec_TakeRule.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedRec_TakeRule.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedRec_TakeRule.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedRec_TakeRule.Location = new System.Drawing.Point(224, 128);
			this.notePanel_MedRec_TakeRule.MaxRows = 5;
			this.notePanel_MedRec_TakeRule.Name = "notePanel_MedRec_TakeRule";
			this.notePanel_MedRec_TakeRule.ParentAutoHeight = true;
			this.notePanel_MedRec_TakeRule.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MedRec_TakeRule.TabIndex = 65;
			this.notePanel_MedRec_TakeRule.TabStop = false;
			this.notePanel_MedRec_TakeRule.Text = "服药规定:";
			// 
			// listBoxControl_MedRec_MedCarrInfo
			// 
			this.listBoxControl_MedRec_MedCarrInfo.ItemHeight = 16;
			this.listBoxControl_MedRec_MedCarrInfo.Location = new System.Drawing.Point(56, 32);
			this.listBoxControl_MedRec_MedCarrInfo.Name = "listBoxControl_MedRec_MedCarrInfo";
			this.listBoxControl_MedRec_MedCarrInfo.Size = new System.Drawing.Size(152, 120);
			this.listBoxControl_MedRec_MedCarrInfo.TabIndex = 64;
			this.listBoxControl_MedRec_MedCarrInfo.DoubleClick += new System.EventHandler(this.listBoxControl_MedRec_MedCarrInfo_DoubleClick);
			// 
			// comboBoxEdit_MedRec_TakeRule
			// 
			this.comboBoxEdit_MedRec_TakeRule.EditValue = "";
			this.comboBoxEdit_MedRec_TakeRule.Location = new System.Drawing.Point(312, 128);
			this.comboBoxEdit_MedRec_TakeRule.Name = "comboBoxEdit_MedRec_TakeRule";
			// 
			// comboBoxEdit_MedRec_TakeRule.Properties
			// 
			this.comboBoxEdit_MedRec_TakeRule.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit_MedRec_TakeRule.Properties.Items.AddRange(new object[] {
																						 "饭前服用",
																						 "饭后服用"});
			this.comboBoxEdit_MedRec_TakeRule.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit_MedRec_TakeRule.Size = new System.Drawing.Size(80, 23);
			this.comboBoxEdit_MedRec_TakeRule.TabIndex = 63;
			// 
			// timeEdit_MedRec_TakeTime
			// 
			this.timeEdit_MedRec_TakeTime.EditValue = new System.DateTime(2005, 1, 24, 0, 0, 0, 0);
			this.timeEdit_MedRec_TakeTime.Location = new System.Drawing.Point(312, 96);
			this.timeEdit_MedRec_TakeTime.Name = "timeEdit_MedRec_TakeTime";
			// 
			// timeEdit_MedRec_TakeTime.Properties
			// 
			this.timeEdit_MedRec_TakeTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															 new DevExpress.XtraEditors.Controls.EditorButton()});
			this.timeEdit_MedRec_TakeTime.Properties.DisplayFormat.FormatString = "HH:mm:ss";
			this.timeEdit_MedRec_TakeTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.timeEdit_MedRec_TakeTime.Properties.Mask.EditMask = "T";
			this.timeEdit_MedRec_TakeTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
			this.timeEdit_MedRec_TakeTime.Properties.UseCtrlIncrement = true;
			this.timeEdit_MedRec_TakeTime.Size = new System.Drawing.Size(80, 23);
			this.timeEdit_MedRec_TakeTime.TabIndex = 61;
			// 
			// notePanel_MedRec_TakeDate
			// 
			this.notePanel_MedRec_TakeDate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedRec_TakeDate.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedRec_TakeDate.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedRec_TakeDate.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedRec_TakeDate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedRec_TakeDate.Location = new System.Drawing.Point(224, 96);
			this.notePanel_MedRec_TakeDate.MaxRows = 5;
			this.notePanel_MedRec_TakeDate.Name = "notePanel_MedRec_TakeDate";
			this.notePanel_MedRec_TakeDate.ParentAutoHeight = true;
			this.notePanel_MedRec_TakeDate.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MedRec_TakeDate.TabIndex = 60;
			this.notePanel_MedRec_TakeDate.TabStop = false;
			this.notePanel_MedRec_TakeDate.Text = "服药时间:";
			// 
			// textEdit_MedRec_MedTake
			// 
			this.textEdit_MedRec_MedTake.EditValue = "";
			this.textEdit_MedRec_MedTake.Location = new System.Drawing.Point(312, 64);
			this.textEdit_MedRec_MedTake.Name = "textEdit_MedRec_MedTake";
			this.textEdit_MedRec_MedTake.Size = new System.Drawing.Size(80, 23);
			this.textEdit_MedRec_MedTake.TabIndex = 59;
			// 
			// notePanel_MedRec_MedTake
			// 
			this.notePanel_MedRec_MedTake.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedRec_MedTake.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedRec_MedTake.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedRec_MedTake.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedRec_MedTake.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedRec_MedTake.Location = new System.Drawing.Point(224, 64);
			this.notePanel_MedRec_MedTake.MaxRows = 5;
			this.notePanel_MedRec_MedTake.Name = "notePanel_MedRec_MedTake";
			this.notePanel_MedRec_MedTake.ParentAutoHeight = true;
			this.notePanel_MedRec_MedTake.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MedRec_MedTake.TabIndex = 58;
			this.notePanel_MedRec_MedTake.TabStop = false;
			this.notePanel_MedRec_MedTake.Text = "服药剂量:";
			// 
			// textEdit_MedRec_MedName
			// 
			this.textEdit_MedRec_MedName.EditValue = "";
			this.textEdit_MedRec_MedName.Location = new System.Drawing.Point(312, 32);
			this.textEdit_MedRec_MedName.Name = "textEdit_MedRec_MedName";
			this.textEdit_MedRec_MedName.Size = new System.Drawing.Size(80, 23);
			this.textEdit_MedRec_MedName.TabIndex = 57;
			// 
			// notePanel_MedRec_MedName
			// 
			this.notePanel_MedRec_MedName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedRec_MedName.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedRec_MedName.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedRec_MedName.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedRec_MedName.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedRec_MedName.Location = new System.Drawing.Point(224, 32);
			this.notePanel_MedRec_MedName.MaxRows = 5;
			this.notePanel_MedRec_MedName.Name = "notePanel_MedRec_MedName";
			this.notePanel_MedRec_MedName.ParentAutoHeight = true;
			this.notePanel_MedRec_MedName.Size = new System.Drawing.Size(80, 22);
			this.notePanel_MedRec_MedName.TabIndex = 53;
			this.notePanel_MedRec_MedName.TabStop = false;
			this.notePanel_MedRec_MedName.Text = "服药名称:";
			// 
			// groupControl_MedRec_DiagInfo
			// 
			this.groupControl_MedRec_DiagInfo.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_MedRec_DiagInfo.AppearanceCaption.Options.UseFont = true;
			this.groupControl_MedRec_DiagInfo.Controls.Add(this.textEdit_MedRec_Diag);
			this.groupControl_MedRec_DiagInfo.Controls.Add(this.textEdit_MedRec_Else);
			this.groupControl_MedRec_DiagInfo.Controls.Add(this.textEdit_MedRec_FacialSym);
			this.groupControl_MedRec_DiagInfo.Controls.Add(this.notePanel_MedRec_Else);
			this.groupControl_MedRec_DiagInfo.Controls.Add(this.notePanel_MedRec_FacialSym);
			this.groupControl_MedRec_DiagInfo.Controls.Add(this.notePanel_MedRec_SkinSym);
			this.groupControl_MedRec_DiagInfo.Controls.Add(this.notePanel_MedRec_AbdomenSym);
			this.groupControl_MedRec_DiagInfo.Controls.Add(this.notePanel_MedRec_EnteronSym);
			this.groupControl_MedRec_DiagInfo.Controls.Add(this.textEdit_MedRec_SkinSym);
			this.groupControl_MedRec_DiagInfo.Controls.Add(this.textEdit_MedRec_AbdomenSym);
			this.groupControl_MedRec_DiagInfo.Controls.Add(this.textEdit_MedRec_EnteronSym);
			this.groupControl_MedRec_DiagInfo.Controls.Add(this.textEdit_MedRec_ThroatSym);
			this.groupControl_MedRec_DiagInfo.Controls.Add(this.notePanel_MedRec_ThroatSym);
			this.groupControl_MedRec_DiagInfo.Controls.Add(this.textEdit_MedRec_LungSym);
			this.groupControl_MedRec_DiagInfo.Controls.Add(this.notePanel_MedRec_LungSym);
			this.groupControl_MedRec_DiagInfo.Controls.Add(this.textEdit_MedRec_UpperSym);
			this.groupControl_MedRec_DiagInfo.Controls.Add(this.notePanel_MedRec_UpperSym);
			this.groupControl_MedRec_DiagInfo.Controls.Add(this.notePanel_MedRec_Diag);
			this.groupControl_MedRec_DiagInfo.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl_MedRec_DiagInfo.Location = new System.Drawing.Point(3, 18);
			this.groupControl_MedRec_DiagInfo.Name = "groupControl_MedRec_DiagInfo";
			this.groupControl_MedRec_DiagInfo.Size = new System.Drawing.Size(471, 254);
			this.groupControl_MedRec_DiagInfo.TabIndex = 2;
			this.groupControl_MedRec_DiagInfo.Text = "诊断信息";
			// 
			// textEdit_MedRec_Diag
			// 
			this.textEdit_MedRec_Diag.EditValue = "";
			this.textEdit_MedRec_Diag.Location = new System.Drawing.Point(176, 24);
			this.textEdit_MedRec_Diag.Name = "textEdit_MedRec_Diag";
			// 
			// textEdit_MedRec_Diag.Properties
			// 
			this.textEdit_MedRec_Diag.Properties.Enabled = false;
			this.textEdit_MedRec_Diag.Size = new System.Drawing.Size(256, 23);
			this.textEdit_MedRec_Diag.TabIndex = 71;
			// 
			// textEdit_MedRec_Else
			// 
			this.textEdit_MedRec_Else.EditValue = "";
			this.textEdit_MedRec_Else.Location = new System.Drawing.Point(176, 216);
			this.textEdit_MedRec_Else.Name = "textEdit_MedRec_Else";
			// 
			// textEdit_MedRec_Else.Properties
			// 
			this.textEdit_MedRec_Else.Properties.Enabled = false;
			this.textEdit_MedRec_Else.Size = new System.Drawing.Size(256, 23);
			this.textEdit_MedRec_Else.TabIndex = 70;
			// 
			// textEdit_MedRec_FacialSym
			// 
			this.textEdit_MedRec_FacialSym.EditValue = "";
			this.textEdit_MedRec_FacialSym.Location = new System.Drawing.Point(176, 192);
			this.textEdit_MedRec_FacialSym.Name = "textEdit_MedRec_FacialSym";
			// 
			// textEdit_MedRec_FacialSym.Properties
			// 
			this.textEdit_MedRec_FacialSym.Properties.Enabled = false;
			this.textEdit_MedRec_FacialSym.Size = new System.Drawing.Size(256, 23);
			this.textEdit_MedRec_FacialSym.TabIndex = 69;
			// 
			// notePanel_MedRec_Else
			// 
			this.notePanel_MedRec_Else.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedRec_Else.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedRec_Else.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedRec_Else.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedRec_Else.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedRec_Else.Location = new System.Drawing.Point(64, 216);
			this.notePanel_MedRec_Else.MaxRows = 5;
			this.notePanel_MedRec_Else.Name = "notePanel_MedRec_Else";
			this.notePanel_MedRec_Else.ParentAutoHeight = true;
			this.notePanel_MedRec_Else.Size = new System.Drawing.Size(96, 22);
			this.notePanel_MedRec_Else.TabIndex = 68;
			this.notePanel_MedRec_Else.TabStop = false;
			this.notePanel_MedRec_Else.Text = "  其他症状:";
			// 
			// notePanel_MedRec_FacialSym
			// 
			this.notePanel_MedRec_FacialSym.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedRec_FacialSym.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedRec_FacialSym.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedRec_FacialSym.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedRec_FacialSym.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedRec_FacialSym.Location = new System.Drawing.Point(64, 192);
			this.notePanel_MedRec_FacialSym.MaxRows = 5;
			this.notePanel_MedRec_FacialSym.Name = "notePanel_MedRec_FacialSym";
			this.notePanel_MedRec_FacialSym.ParentAutoHeight = true;
			this.notePanel_MedRec_FacialSym.Size = new System.Drawing.Size(96, 22);
			this.notePanel_MedRec_FacialSym.TabIndex = 67;
			this.notePanel_MedRec_FacialSym.TabStop = false;
			this.notePanel_MedRec_FacialSym.Text = "  五官症状:";
			// 
			// notePanel_MedRec_SkinSym
			// 
			this.notePanel_MedRec_SkinSym.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedRec_SkinSym.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedRec_SkinSym.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedRec_SkinSym.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedRec_SkinSym.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedRec_SkinSym.Location = new System.Drawing.Point(64, 168);
			this.notePanel_MedRec_SkinSym.MaxRows = 5;
			this.notePanel_MedRec_SkinSym.Name = "notePanel_MedRec_SkinSym";
			this.notePanel_MedRec_SkinSym.ParentAutoHeight = true;
			this.notePanel_MedRec_SkinSym.Size = new System.Drawing.Size(96, 22);
			this.notePanel_MedRec_SkinSym.TabIndex = 66;
			this.notePanel_MedRec_SkinSym.TabStop = false;
			this.notePanel_MedRec_SkinSym.Text = "  皮肤症状:";
			// 
			// notePanel_MedRec_AbdomenSym
			// 
			this.notePanel_MedRec_AbdomenSym.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedRec_AbdomenSym.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedRec_AbdomenSym.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedRec_AbdomenSym.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedRec_AbdomenSym.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedRec_AbdomenSym.Location = new System.Drawing.Point(64, 144);
			this.notePanel_MedRec_AbdomenSym.MaxRows = 5;
			this.notePanel_MedRec_AbdomenSym.Name = "notePanel_MedRec_AbdomenSym";
			this.notePanel_MedRec_AbdomenSym.ParentAutoHeight = true;
			this.notePanel_MedRec_AbdomenSym.Size = new System.Drawing.Size(96, 22);
			this.notePanel_MedRec_AbdomenSym.TabIndex = 65;
			this.notePanel_MedRec_AbdomenSym.TabStop = false;
			this.notePanel_MedRec_AbdomenSym.Text = "  腹部症状:";
			// 
			// notePanel_MedRec_EnteronSym
			// 
			this.notePanel_MedRec_EnteronSym.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedRec_EnteronSym.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedRec_EnteronSym.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedRec_EnteronSym.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedRec_EnteronSym.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedRec_EnteronSym.Location = new System.Drawing.Point(64, 120);
			this.notePanel_MedRec_EnteronSym.MaxRows = 5;
			this.notePanel_MedRec_EnteronSym.Name = "notePanel_MedRec_EnteronSym";
			this.notePanel_MedRec_EnteronSym.ParentAutoHeight = true;
			this.notePanel_MedRec_EnteronSym.Size = new System.Drawing.Size(96, 22);
			this.notePanel_MedRec_EnteronSym.TabIndex = 64;
			this.notePanel_MedRec_EnteronSym.TabStop = false;
			this.notePanel_MedRec_EnteronSym.Text = "消化道症状:";
			// 
			// textEdit_MedRec_SkinSym
			// 
			this.textEdit_MedRec_SkinSym.EditValue = "";
			this.textEdit_MedRec_SkinSym.Location = new System.Drawing.Point(176, 168);
			this.textEdit_MedRec_SkinSym.Name = "textEdit_MedRec_SkinSym";
			// 
			// textEdit_MedRec_SkinSym.Properties
			// 
			this.textEdit_MedRec_SkinSym.Properties.Enabled = false;
			this.textEdit_MedRec_SkinSym.Size = new System.Drawing.Size(256, 23);
			this.textEdit_MedRec_SkinSym.TabIndex = 63;
			// 
			// textEdit_MedRec_AbdomenSym
			// 
			this.textEdit_MedRec_AbdomenSym.EditValue = "";
			this.textEdit_MedRec_AbdomenSym.Location = new System.Drawing.Point(176, 144);
			this.textEdit_MedRec_AbdomenSym.Name = "textEdit_MedRec_AbdomenSym";
			// 
			// textEdit_MedRec_AbdomenSym.Properties
			// 
			this.textEdit_MedRec_AbdomenSym.Properties.Enabled = false;
			this.textEdit_MedRec_AbdomenSym.Size = new System.Drawing.Size(256, 23);
			this.textEdit_MedRec_AbdomenSym.TabIndex = 62;
			// 
			// textEdit_MedRec_EnteronSym
			// 
			this.textEdit_MedRec_EnteronSym.EditValue = "";
			this.textEdit_MedRec_EnteronSym.Location = new System.Drawing.Point(176, 120);
			this.textEdit_MedRec_EnteronSym.Name = "textEdit_MedRec_EnteronSym";
			// 
			// textEdit_MedRec_EnteronSym.Properties
			// 
			this.textEdit_MedRec_EnteronSym.Properties.Enabled = false;
			this.textEdit_MedRec_EnteronSym.Size = new System.Drawing.Size(256, 23);
			this.textEdit_MedRec_EnteronSym.TabIndex = 61;
			// 
			// textEdit_MedRec_ThroatSym
			// 
			this.textEdit_MedRec_ThroatSym.EditValue = "";
			this.textEdit_MedRec_ThroatSym.Location = new System.Drawing.Point(176, 96);
			this.textEdit_MedRec_ThroatSym.Name = "textEdit_MedRec_ThroatSym";
			// 
			// textEdit_MedRec_ThroatSym.Properties
			// 
			this.textEdit_MedRec_ThroatSym.Properties.Enabled = false;
			this.textEdit_MedRec_ThroatSym.Size = new System.Drawing.Size(256, 23);
			this.textEdit_MedRec_ThroatSym.TabIndex = 60;
			// 
			// notePanel_MedRec_ThroatSym
			// 
			this.notePanel_MedRec_ThroatSym.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedRec_ThroatSym.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedRec_ThroatSym.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedRec_ThroatSym.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedRec_ThroatSym.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedRec_ThroatSym.Location = new System.Drawing.Point(64, 96);
			this.notePanel_MedRec_ThroatSym.MaxRows = 5;
			this.notePanel_MedRec_ThroatSym.Name = "notePanel_MedRec_ThroatSym";
			this.notePanel_MedRec_ThroatSym.ParentAutoHeight = true;
			this.notePanel_MedRec_ThroatSym.Size = new System.Drawing.Size(96, 22);
			this.notePanel_MedRec_ThroatSym.TabIndex = 59;
			this.notePanel_MedRec_ThroatSym.TabStop = false;
			this.notePanel_MedRec_ThroatSym.Text = "咽喉部症状:";
			// 
			// textEdit_MedRec_LungSym
			// 
			this.textEdit_MedRec_LungSym.EditValue = "";
			this.textEdit_MedRec_LungSym.Location = new System.Drawing.Point(176, 72);
			this.textEdit_MedRec_LungSym.Name = "textEdit_MedRec_LungSym";
			// 
			// textEdit_MedRec_LungSym.Properties
			// 
			this.textEdit_MedRec_LungSym.Properties.Enabled = false;
			this.textEdit_MedRec_LungSym.Size = new System.Drawing.Size(256, 23);
			this.textEdit_MedRec_LungSym.TabIndex = 58;
			// 
			// notePanel_MedRec_LungSym
			// 
			this.notePanel_MedRec_LungSym.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedRec_LungSym.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedRec_LungSym.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedRec_LungSym.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedRec_LungSym.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedRec_LungSym.Location = new System.Drawing.Point(64, 72);
			this.notePanel_MedRec_LungSym.MaxRows = 5;
			this.notePanel_MedRec_LungSym.Name = "notePanel_MedRec_LungSym";
			this.notePanel_MedRec_LungSym.ParentAutoHeight = true;
			this.notePanel_MedRec_LungSym.Size = new System.Drawing.Size(96, 22);
			this.notePanel_MedRec_LungSym.TabIndex = 57;
			this.notePanel_MedRec_LungSym.TabStop = false;
			this.notePanel_MedRec_LungSym.Text = "  肺部症状:";
			// 
			// textEdit_MedRec_UpperSym
			// 
			this.textEdit_MedRec_UpperSym.EditValue = "";
			this.textEdit_MedRec_UpperSym.Location = new System.Drawing.Point(176, 48);
			this.textEdit_MedRec_UpperSym.Name = "textEdit_MedRec_UpperSym";
			// 
			// textEdit_MedRec_UpperSym.Properties
			// 
			this.textEdit_MedRec_UpperSym.Properties.Enabled = false;
			this.textEdit_MedRec_UpperSym.Size = new System.Drawing.Size(256, 23);
			this.textEdit_MedRec_UpperSym.TabIndex = 56;
			// 
			// notePanel_MedRec_UpperSym
			// 
			this.notePanel_MedRec_UpperSym.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedRec_UpperSym.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedRec_UpperSym.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedRec_UpperSym.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedRec_UpperSym.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedRec_UpperSym.Location = new System.Drawing.Point(64, 48);
			this.notePanel_MedRec_UpperSym.MaxRows = 5;
			this.notePanel_MedRec_UpperSym.Name = "notePanel_MedRec_UpperSym";
			this.notePanel_MedRec_UpperSym.ParentAutoHeight = true;
			this.notePanel_MedRec_UpperSym.Size = new System.Drawing.Size(96, 22);
			this.notePanel_MedRec_UpperSym.TabIndex = 54;
			this.notePanel_MedRec_UpperSym.TabStop = false;
			this.notePanel_MedRec_UpperSym.Text = "  上感症状:";
			// 
			// notePanel_MedRec_Diag
			// 
			this.notePanel_MedRec_Diag.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.notePanel_MedRec_Diag.BackColor2 = System.Drawing.Color.DarkGray;
			this.notePanel_MedRec_Diag.Font = new System.Drawing.Font("Tahoma", 8F);
			this.notePanel_MedRec_Diag.ForeColor = System.Drawing.Color.Black;
			this.notePanel_MedRec_Diag.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedRec_Diag.Location = new System.Drawing.Point(64, 24);
			this.notePanel_MedRec_Diag.MaxRows = 5;
			this.notePanel_MedRec_Diag.Name = "notePanel_MedRec_Diag";
			this.notePanel_MedRec_Diag.ParentAutoHeight = true;
			this.notePanel_MedRec_Diag.Size = new System.Drawing.Size(96, 22);
			this.notePanel_MedRec_Diag.TabIndex = 52;
			this.notePanel_MedRec_Diag.TabStop = false;
			this.notePanel_MedRec_Diag.Text = "  症状诊断:";
			// 
			// groupControl_MedRec_DoseRec
			// 
			this.groupControl_MedRec_DoseRec.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl_MedRec_DoseRec.AppearanceCaption.Options.UseFont = true;
			this.groupControl_MedRec_DoseRec.Controls.Add(this.gridControl_MedRec_DoseRec);
			this.groupControl_MedRec_DoseRec.Controls.Add(this.notePanel_MedRec_DoseRec);
			this.groupControl_MedRec_DoseRec.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl_MedRec_DoseRec.Location = new System.Drawing.Point(0, 48);
			this.groupControl_MedRec_DoseRec.Name = "groupControl_MedRec_DoseRec";
			this.groupControl_MedRec_DoseRec.Size = new System.Drawing.Size(477, 461);
			this.groupControl_MedRec_DoseRec.TabIndex = 1;
			this.groupControl_MedRec_DoseRec.Text = "幼儿服药记录追踪";
			// 
			// gridControl_MedRec_DoseRec
			// 
			this.gridControl_MedRec_DoseRec.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl_MedRec_DoseRec.EmbeddedNavigator
			// 
			this.gridControl_MedRec_DoseRec.EmbeddedNavigator.Name = "";
			this.gridControl_MedRec_DoseRec.Location = new System.Drawing.Point(3, 41);
			this.gridControl_MedRec_DoseRec.MainView = this.gridView11;
			this.gridControl_MedRec_DoseRec.Name = "gridControl_MedRec_DoseRec";
			this.barManager1.SetPopupContextMenu(this.gridControl_MedRec_DoseRec, this.popupMenu3);
			this.gridControl_MedRec_DoseRec.Size = new System.Drawing.Size(471, 417);
			this.gridControl_MedRec_DoseRec.TabIndex = 59;
			this.gridControl_MedRec_DoseRec.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																													  this.gridView11,
																													  this.gridView12});
			this.gridControl_MedRec_DoseRec.DoubleClick += new System.EventHandler(this.gridControl_MedRec_DoseRec_DoubleClick);
			// 
			// gridView11
			// 
			this.gridView11.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							  this.gridColumn49,
																							  this.gridColumn48,
																							  this.gridColumn44,
																							  this.gridColumn45,
																							  this.gridColumn46,
																							  this.gridColumn47});
			this.gridView11.GridControl = this.gridControl_MedRec_DoseRec;
			this.gridView11.Name = "gridView11";
			this.gridView11.OptionsCustomization.AllowFilter = false;
			this.gridView11.OptionsView.ShowFilterPanel = false;
			this.gridView11.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn49
			// 
			this.gridColumn49.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn49.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn49.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn49.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn49.Caption = "幼儿学号";
			this.gridColumn49.FieldName = "info_stuNumber";
			this.gridColumn49.Name = "gridColumn49";
			this.gridColumn49.OptionsColumn.AllowEdit = false;
			this.gridColumn49.OptionsColumn.AllowFocus = false;
			this.gridColumn49.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn49.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn49.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn49.OptionsColumn.AllowMove = false;
			this.gridColumn49.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn49.OptionsColumn.ReadOnly = true;
			this.gridColumn49.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn49.Visible = true;
			this.gridColumn49.VisibleIndex = 0;
			this.gridColumn49.Width = 66;
			// 
			// gridColumn48
			// 
			this.gridColumn48.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn48.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn48.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn48.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn48.Caption = "幼儿姓名";
			this.gridColumn48.FieldName = "info_stuName";
			this.gridColumn48.Name = "gridColumn48";
			this.gridColumn48.OptionsColumn.AllowEdit = false;
			this.gridColumn48.OptionsColumn.AllowFocus = false;
			this.gridColumn48.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn48.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn48.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn48.OptionsColumn.AllowMove = false;
			this.gridColumn48.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn48.OptionsColumn.ReadOnly = true;
			this.gridColumn48.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn48.Visible = true;
			this.gridColumn48.VisibleIndex = 1;
			this.gridColumn48.Width = 68;
			// 
			// gridColumn44
			// 
			this.gridColumn44.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn44.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn44.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn44.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn44.Caption = "药品名称";
			this.gridColumn44.FieldName = "medicine_Name";
			this.gridColumn44.Name = "gridColumn44";
			this.gridColumn44.OptionsColumn.AllowEdit = false;
			this.gridColumn44.OptionsColumn.AllowFocus = false;
			this.gridColumn44.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn44.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn44.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn44.OptionsColumn.AllowMove = false;
			this.gridColumn44.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn44.OptionsColumn.ReadOnly = true;
			this.gridColumn44.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn44.Visible = true;
			this.gridColumn44.VisibleIndex = 2;
			this.gridColumn44.Width = 69;
			// 
			// gridColumn45
			// 
			this.gridColumn45.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn45.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn45.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn45.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn45.Caption = "服用剂量";
			this.gridColumn45.FieldName = "medicine_dose";
			this.gridColumn45.Name = "gridColumn45";
			this.gridColumn45.OptionsColumn.AllowEdit = false;
			this.gridColumn45.OptionsColumn.AllowFocus = false;
			this.gridColumn45.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn45.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn45.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn45.OptionsColumn.AllowMove = false;
			this.gridColumn45.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn45.OptionsColumn.ReadOnly = true;
			this.gridColumn45.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn45.Visible = true;
			this.gridColumn45.VisibleIndex = 3;
			this.gridColumn45.Width = 57;
			// 
			// gridColumn46
			// 
			this.gridColumn46.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn46.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn46.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn46.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn46.Caption = "服用时间";
			this.gridColumn46.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
			this.gridColumn46.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.gridColumn46.FieldName = "medicine_time";
			this.gridColumn46.Name = "gridColumn46";
			this.gridColumn46.OptionsColumn.AllowEdit = false;
			this.gridColumn46.OptionsColumn.AllowFocus = false;
			this.gridColumn46.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn46.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn46.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn46.OptionsColumn.AllowMove = false;
			this.gridColumn46.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn46.OptionsColumn.ReadOnly = true;
			this.gridColumn46.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn46.Visible = true;
			this.gridColumn46.VisibleIndex = 4;
			this.gridColumn46.Width = 124;
			// 
			// gridColumn47
			// 
			this.gridColumn47.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn47.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn47.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn47.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn47.Caption = "负责教师";
			this.gridColumn47.FieldName = "teacher_signature";
			this.gridColumn47.Name = "gridColumn47";
			this.gridColumn47.OptionsColumn.AllowEdit = false;
			this.gridColumn47.OptionsColumn.AllowFocus = false;
			this.gridColumn47.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn47.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn47.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn47.OptionsColumn.AllowMove = false;
			this.gridColumn47.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn47.OptionsColumn.ReadOnly = true;
			this.gridColumn47.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn47.Visible = true;
			this.gridColumn47.VisibleIndex = 5;
			this.gridColumn47.Width = 70;
			// 
			// gridView12
			// 
			this.gridView12.GridControl = this.gridControl_MedRec_DoseRec;
			this.gridView12.Name = "gridView12";
			// 
			// notePanel_MedRec_DoseRec
			// 
			this.notePanel_MedRec_DoseRec.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.notePanel_MedRec_DoseRec.Dock = System.Windows.Forms.DockStyle.Top;
			this.notePanel_MedRec_DoseRec.ForeColor = System.Drawing.Color.OrangeRed;
			this.notePanel_MedRec_DoseRec.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.notePanel_MedRec_DoseRec.Location = new System.Drawing.Point(3, 18);
			this.notePanel_MedRec_DoseRec.MaxRows = 5;
			this.notePanel_MedRec_DoseRec.Name = "notePanel_MedRec_DoseRec";
			this.notePanel_MedRec_DoseRec.ParentAutoHeight = true;
			this.notePanel_MedRec_DoseRec.Size = new System.Drawing.Size(471, 23);
			this.notePanel_MedRec_DoseRec.TabIndex = 58;
			this.notePanel_MedRec_DoseRec.TabStop = false;
			this.notePanel_MedRec_DoseRec.Text = "双击进行服药记录添加";
			// 
			// panelControl9
			// 
			this.panelControl9.Controls.Add(this.simpleButton_AbnormalSer);
			this.panelControl9.Controls.Add(this.simpleButton_MedRec_Report);
			this.panelControl9.Controls.Add(this.simpleButton_MedRec_Add);
			this.panelControl9.Controls.Add(this.simpleButton_MedRec_Back);
			this.panelControl9.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl9.Location = new System.Drawing.Point(0, 0);
			this.panelControl9.Name = "panelControl9";
			this.panelControl9.Size = new System.Drawing.Size(477, 48);
			this.panelControl9.TabIndex = 0;
			this.panelControl9.Text = "panelControl9";
			// 
			// simpleButton_AbnormalSer
			// 
			this.simpleButton_AbnormalSer.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_AbnormalSer.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_AbnormalSer.Appearance.Options.UseFont = true;
			this.simpleButton_AbnormalSer.Appearance.Options.UseForeColor = true;
			this.simpleButton_AbnormalSer.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_AbnormalSer.Image")));
			this.simpleButton_AbnormalSer.Location = new System.Drawing.Point(16, 8);
			this.simpleButton_AbnormalSer.Name = "simpleButton_AbnormalSer";
			this.simpleButton_AbnormalSer.Size = new System.Drawing.Size(80, 26);
			this.simpleButton_AbnormalSer.TabIndex = 26;
			this.simpleButton_AbnormalSer.Tag = 4;
			this.simpleButton_AbnormalSer.Text = "检  索";
			this.simpleButton_AbnormalSer.Click += new System.EventHandler(this.simpleButton_AbnormalSer_Click);
			// 
			// simpleButton_MedRec_Report
			// 
			this.simpleButton_MedRec_Report.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_MedRec_Report.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_MedRec_Report.Appearance.Options.UseFont = true;
			this.simpleButton_MedRec_Report.Appearance.Options.UseForeColor = true;
			this.simpleButton_MedRec_Report.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_MedRec_Report.Image")));
			this.simpleButton_MedRec_Report.Location = new System.Drawing.Point(296, 8);
			this.simpleButton_MedRec_Report.Name = "simpleButton_MedRec_Report";
			this.simpleButton_MedRec_Report.Size = new System.Drawing.Size(80, 26);
			this.simpleButton_MedRec_Report.TabIndex = 25;
			this.simpleButton_MedRec_Report.Tag = 4;
			this.simpleButton_MedRec_Report.Text = "报  表";
			this.simpleButton_MedRec_Report.Click += new System.EventHandler(this.simpleButton_MedRec_Report_Click);
			// 
			// simpleButton_MedRec_Add
			// 
			this.simpleButton_MedRec_Add.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_MedRec_Add.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_MedRec_Add.Appearance.Options.UseFont = true;
			this.simpleButton_MedRec_Add.Appearance.Options.UseForeColor = true;
			this.simpleButton_MedRec_Add.Enabled = false;
			this.simpleButton_MedRec_Add.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_MedRec_Add.Image")));
			this.simpleButton_MedRec_Add.Location = new System.Drawing.Point(192, 8);
			this.simpleButton_MedRec_Add.Name = "simpleButton_MedRec_Add";
			this.simpleButton_MedRec_Add.Size = new System.Drawing.Size(96, 26);
			this.simpleButton_MedRec_Add.TabIndex = 23;
			this.simpleButton_MedRec_Add.Tag = 4;
			this.simpleButton_MedRec_Add.Text = "服药添加";
			this.simpleButton_MedRec_Add.Click += new System.EventHandler(this.simpleButton_MedRec_Add_Click);
			// 
			// simpleButton_MedRec_Back
			// 
			this.simpleButton_MedRec_Back.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.simpleButton_MedRec_Back.Appearance.ForeColor = System.Drawing.Color.DarkMagenta;
			this.simpleButton_MedRec_Back.Appearance.Options.UseFont = true;
			this.simpleButton_MedRec_Back.Appearance.Options.UseForeColor = true;
			this.simpleButton_MedRec_Back.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_MedRec_Back.Image")));
			this.simpleButton_MedRec_Back.Location = new System.Drawing.Point(104, 8);
			this.simpleButton_MedRec_Back.Name = "simpleButton_MedRec_Back";
			this.simpleButton_MedRec_Back.Size = new System.Drawing.Size(80, 26);
			this.simpleButton_MedRec_Back.TabIndex = 22;
			this.simpleButton_MedRec_Back.Tag = 4;
			this.simpleButton_MedRec_Back.Text = "返  回";
			this.simpleButton_MedRec_Back.Click += new System.EventHandler(this.simpleButton_MedRec_Back_Click);
			// 
			// barManager1
			// 
			this.barManager1.DockControls.Add(this.barDockControlTop);
			this.barManager1.DockControls.Add(this.barDockControlBottom);
			this.barManager1.DockControls.Add(this.barDockControlLeft);
			this.barManager1.DockControls.Add(this.barDockControlRight);
			this.barManager1.Form = this;
			this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
																				  this.barButtonItem_MealRefresh,
																				  this.barButtonItem_MedReg_MedAdd,
																				  this.barButtonItem_MedReg_MedModify,
																				  this.barButtonItem_MedReg_MedDel,
																				  this.barButtonItem_MedRec_MultiSer,
																				  this.barButtonItem_MedRec_MedDel,
																				  this.barButtonItem_RecipeRefresh,
																				  this.barButtonItem_RecipeDelete});
			this.barManager1.MaxItemId = 8;
			// 
			// popupMenu4
			// 
			this.popupMenu4.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
																									new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_RecipeRefresh),
																									new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_RecipeDelete)});
			this.popupMenu4.Manager = this.barManager1;
			this.popupMenu4.Name = "popupMenu4";
			// 
			// barButtonItem_RecipeRefresh
			// 
			this.barButtonItem_RecipeRefresh.Caption = "刷新";
			this.barButtonItem_RecipeRefresh.Id = 6;
			this.barButtonItem_RecipeRefresh.Name = "barButtonItem_RecipeRefresh";
			this.barButtonItem_RecipeRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_RecipeRefresh_ItemClick);
			// 
			// barButtonItem_RecipeDelete
			// 
			this.barButtonItem_RecipeDelete.Caption = "删除";
			this.barButtonItem_RecipeDelete.Id = 7;
			this.barButtonItem_RecipeDelete.Name = "barButtonItem_RecipeDelete";
			this.barButtonItem_RecipeDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_RecipeDelete_ItemClick);
			// 
			// popupMenu1
			// 
			this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
																									new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_MealRefresh)});
			this.popupMenu1.Manager = this.barManager1;
			this.popupMenu1.Name = "popupMenu1";
			// 
			// barButtonItem_MealRefresh
			// 
			this.barButtonItem_MealRefresh.Caption = "刷新";
			this.barButtonItem_MealRefresh.Id = 0;
			this.barButtonItem_MealRefresh.Name = "barButtonItem_MealRefresh";
			this.barButtonItem_MealRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_MealRefresh_ItemClick);
			// 
			// popupMenu2
			// 
			this.popupMenu2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
																									new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_MedReg_MedAdd),
																									new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_MedReg_MedModify),
																									new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_MedReg_MedDel)});
			this.popupMenu2.Manager = this.barManager1;
			this.popupMenu2.Name = "popupMenu2";
			// 
			// barButtonItem_MedReg_MedAdd
			// 
			this.barButtonItem_MedReg_MedAdd.Caption = "添加药品信息";
			this.barButtonItem_MedReg_MedAdd.Id = 1;
			this.barButtonItem_MedReg_MedAdd.Name = "barButtonItem_MedReg_MedAdd";
			this.barButtonItem_MedReg_MedAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_MedReg_MedAdd_ItemClick);
			// 
			// barButtonItem_MedReg_MedModify
			// 
			this.barButtonItem_MedReg_MedModify.Caption = "修改药品信息";
			this.barButtonItem_MedReg_MedModify.Id = 2;
			this.barButtonItem_MedReg_MedModify.Name = "barButtonItem_MedReg_MedModify";
			this.barButtonItem_MedReg_MedModify.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_MedReg_MedModify_ItemClick);
			// 
			// barButtonItem_MedReg_MedDel
			// 
			this.barButtonItem_MedReg_MedDel.Caption = "删除药品信息";
			this.barButtonItem_MedReg_MedDel.Id = 3;
			this.barButtonItem_MedReg_MedDel.Name = "barButtonItem_MedReg_MedDel";
			this.barButtonItem_MedReg_MedDel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_MedReg_MedDel_ItemClick);
			// 
			// popupMenu3
			// 
			this.popupMenu3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
																									new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_MedRec_MultiSer),
																									new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_MedRec_MedDel)});
			this.popupMenu3.Manager = this.barManager1;
			this.popupMenu3.Name = "popupMenu3";
			// 
			// barButtonItem_MedRec_MultiSer
			// 
			this.barButtonItem_MedRec_MultiSer.Caption = "返回多人查询模式";
			this.barButtonItem_MedRec_MultiSer.Id = 4;
			this.barButtonItem_MedRec_MultiSer.Name = "barButtonItem_MedRec_MultiSer";
			this.barButtonItem_MedRec_MultiSer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_MedRec_MultiSer_ItemClick);
			// 
			// barButtonItem_MedRec_MedDel
			// 
			this.barButtonItem_MedRec_MedDel.Caption = "删除幼儿服药记录";
			this.barButtonItem_MedRec_MedDel.Id = 5;
			this.barButtonItem_MedRec_MedDel.Name = "barButtonItem_MedRec_MedDel";
			this.barButtonItem_MedRec_MedDel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_MedRec_MedDel_ItemClick);
			// 
			// gridView14
			// 
			this.gridView14.GridControl = null;
			this.gridView14.Name = "gridView14";
			// 
			// gridColumn15
			// 
			this.gridColumn15.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn15.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn15.Caption = "菜谱名称";
			this.gridColumn15.FieldName = "ACCFood_Remark";
			this.gridColumn15.Name = "gridColumn15";
			this.gridColumn15.OptionsColumn.AllowEdit = false;
			this.gridColumn15.OptionsColumn.AllowFocus = false;
			this.gridColumn15.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn15.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn15.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn15.OptionsColumn.AllowMove = false;
			this.gridColumn15.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn15.OptionsColumn.FixedWidth = true;
			this.gridColumn15.OptionsColumn.ReadOnly = true;
			this.gridColumn15.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn15.Visible = true;
			this.gridColumn15.VisibleIndex = 3;
			// 
			// gridColumn14
			// 
			this.gridColumn14.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn14.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn14.Caption = "摄入量";
			this.gridColumn14.FieldName = "ACCFood_TakeAmount";
			this.gridColumn14.Name = "gridColumn14";
			this.gridColumn14.OptionsColumn.AllowEdit = false;
			this.gridColumn14.OptionsColumn.AllowFocus = false;
			this.gridColumn14.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn14.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn14.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn14.OptionsColumn.AllowMove = false;
			this.gridColumn14.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn14.OptionsColumn.FixedWidth = true;
			this.gridColumn14.OptionsColumn.ReadOnly = true;
			this.gridColumn14.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn14.Visible = true;
			this.gridColumn14.VisibleIndex = 2;
			// 
			// gridColumn13
			// 
			this.gridColumn13.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn13.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn13.Caption = "登记日期";
			this.gridColumn13.FieldName = "ACCFood_AddTime";
			this.gridColumn13.Name = "gridColumn13";
			this.gridColumn13.OptionsColumn.AllowEdit = false;
			this.gridColumn13.OptionsColumn.AllowFocus = false;
			this.gridColumn13.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn13.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn13.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn13.OptionsColumn.AllowMove = false;
			this.gridColumn13.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn13.OptionsColumn.FixedWidth = true;
			this.gridColumn13.OptionsColumn.ReadOnly = true;
			this.gridColumn13.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn13.Visible = true;
			this.gridColumn13.VisibleIndex = 1;
			// 
			// gridColumn12
			// 
			this.gridColumn12.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn12.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn12.Caption = "食物名称";
			this.gridColumn12.FieldName = "FoodNut_FoodName";
			this.gridColumn12.Name = "gridColumn12";
			this.gridColumn12.OptionsColumn.AllowEdit = false;
			this.gridColumn12.OptionsColumn.AllowFocus = false;
			this.gridColumn12.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn12.OptionsColumn.AllowIncrementalSearch = false;
			this.gridColumn12.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
			this.gridColumn12.OptionsColumn.AllowMove = false;
			this.gridColumn12.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn12.OptionsColumn.FixedWidth = true;
			this.gridColumn12.OptionsColumn.ReadOnly = true;
			this.gridColumn12.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn12.Visible = true;
			this.gridColumn12.VisibleIndex = 0;
			// 
			// gridView3
			// 
			this.gridView3.GridControl = null;
			this.gridView3.Name = "gridView3";
			this.gridView3.OptionsCustomization.AllowFilter = false;
			this.gridView3.OptionsView.ShowFilterPanel = false;
			this.gridView3.OptionsView.ShowGroupPanel = false;
			// 
			// NutritionManagement
			// 
			this.Controls.Add(this.xtraTabControl1);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlTop);
			this.Name = "NutritionManagement";
			this.Size = new System.Drawing.Size(772, 540);
			this.Load += new System.EventHandler(this.NutritionManagement_Load);
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
			this.xtraTabControl1.ResumeLayout(false);
			this.xtraTabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
			this.splitContainerControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl_FoodCategory)).EndInit();
			this.groupControl_FoodCategory.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.treeList_FoodStock)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_FoodNutModify)).EndInit();
			this.groupControl_FoodNutModify.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.textEdit_FoodName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit_FoodRemark.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_Energy.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_Carbohydrate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_Fat.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_Protein.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_FoodCategory.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_FoodNutrition)).EndInit();
			this.groupControl_FoodNutrition.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl_FoodNutrition)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.textEdit_FoodSearch.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_BindingID.Properties)).EndInit();
			this.xtraTabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
			this.splitContainerControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.panelControl10)).EndInit();
			this.panelControl10.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl_Recipe_FoodNutrition)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_RecipeLogin)).EndInit();
			this.groupControl_RecipeLogin.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.textEdit_RecipeLogin_FoodName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_RecipeLogin_Name.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_RecipeLogin_Date.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_RecipeLogin_FoodTake.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_RecipeLogin_BindingID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_RecipeSer)).EndInit();
			this.groupControl_RecipeSer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_RecipeSer_FoodCategory.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_RecipeSer_FoodName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_RecipeOpr)).EndInit();
			this.groupControl_RecipeOpr.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.panelControl11)).EndInit();
			this.panelControl11.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl_RecipeLogin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView13)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
			this.panelControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.textEdit_Recipe_FoodName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Recipe_RecipeCategory.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_Recipe_EndDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_Recipe_BegDate.Properties)).EndInit();
			this.xtraTabPage3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).EndInit();
			this.splitContainerControl3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MealLogin)).EndInit();
			this.groupControl_MealLogin.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_Snack.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_Dinner.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_Lunch.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_Breakfast.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MealAdd)).EndInit();
			this.groupControl_MealAdd.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MealName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MealRemark.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MealID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MealArr)).EndInit();
			this.groupControl_MealArr.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl4)).EndInit();
			this.splitContainerControl4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_MealArr_gThree.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_MealArr_gTwo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_MealArr_gOne.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_MealArr_Name.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_MealArr_gFour.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_MealArr_gFive.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_MealArr_IsUsed.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MealPreview)).EndInit();
			this.groupControl_MealPreview.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl_MealPreview)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
			this.panelControl3.ResumeLayout(false);
			this.xtraTabPage4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl5)).EndInit();
			this.splitContainerControl5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl_Meal_Search)).EndInit();
			this.groupControl_Meal_Search.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_Meal_EndDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_Meal_BegDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_Meal_ReportPreview)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
			this.panelControl4.ResumeLayout(false);
			this.xtraTabPage5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl6)).EndInit();
			this.splitContainerControl6.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl_HInputStu)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_HInputSer)).EndInit();
			this.groupControl_HInputSer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_HInputGender.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_HInputNumber.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_HInputName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_HInputClass.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_HInputGrade.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_HInputDiagInfo)).EndInit();
			this.groupControl_HInputDiagInfo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_HInputRegion.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_HInputStd.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_DiagCheckName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_DiagCheckBindingID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_HInputDiagResult)).EndInit();
			this.groupControl_HInputDiagResult.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.textEdit_DiagResultX.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_DiagResultWHOPer.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_DiagResultHeightWeight.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_DiagResultUnderWeight.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_DiagResultStunting.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_DiagResultWasting.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_DiagResultHeight.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_DiagResultWeight.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_DiagResultWHO.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_DiagResultNut.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_DiagResultAge.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit_DiagRemark.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_DiagWeight.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_DiagHeight.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_DiagCheckDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_HInputBirthday.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_DiagCheckGender.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
			this.panelControl5.ResumeLayout(false);
			this.xtraTabPage6.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl7)).EndInit();
			this.splitContainerControl7.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl_HOutputPrintType)).EndInit();
			this.groupControl_HOutputPrintType.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_HOutputPrintType4th.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_HOutputPrintType3rd.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_HOutputPrintType2nd.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_HOutputPrintType1st.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_HOutputSer)).EndInit();
			this.groupControl_HOutputSer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_HOutputRegion.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_HOutputEndDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_HOutputBegDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_HOutputGender.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_HOutputResult.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_HOutputType.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_HOutputAge.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_HOutputNumber.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_HOutputName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_HOutputClass.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_HOutputGrade.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_HOutputNchsGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.advBandedGridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl_HOutputGridShow)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
			this.panelControl6.ResumeLayout(false);
			this.xtraTabPage7.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl8)).EndInit();
			this.splitContainerControl8.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl_WatchMorningRec)).EndInit();
			this.groupControl_WatchMorningRec.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.textEdit_WatchMorningTreat.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_WatchMorningOState.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_WatchMorningHeat.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_WatchMorningMouth.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_WatchMorningSpirit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_WatchMorningSkin.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_WatchMorningNumber.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_WatchMorningName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_WatchStuList)).EndInit();
			this.groupControl_WatchStuList.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl_WatchStuList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_WatchSer)).EndInit();
			this.groupControl_WatchSer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.textEdit_WatchName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_WatchEndDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_WatchBegDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_WatchState.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_WatchNumber.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_WatchClass.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_WatchGrade.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_WatchWholeDay)).EndInit();
			this.groupControl_WatchWholeDay.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl_WatchWholDayHandle)).EndInit();
			this.groupControl_WatchWholDayHandle.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_WatchWholeDayHeat.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_WatchWholeDayCtrSeafood.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_WatchWholeDayLifeAttention.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit_WatchWholeDayCtrAct.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_WatchWholeDayReg)).EndInit();
			this.groupControl_WatchWholeDayReg.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.textEdit_WatchWholeDayElse.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_WatchWholeDayCough.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_WatchWholeDaySleep.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_WatchWholeDayStool.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_WatchWholeDayAppetite.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_WatchWholeDaySpirit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_WatchWholeDayMovement.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_WatchRecList)).EndInit();
			this.groupControl_WatchRecList.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl_WatchRecList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView8)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl7)).EndInit();
			this.panelControl7.ResumeLayout(false);
			this.xtraTabPage8.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl9)).EndInit();
			this.splitContainerControl9.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MedReg_StuList)).EndInit();
			this.groupControl_MedReg_StuList.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl_MedReg_StuList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView9)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MedReg_Ser)).EndInit();
			this.groupControl_MedReg_Ser.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedReg_Number.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedReg_Name.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_MedReg_Class.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_MedReg_Grade.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MedReg_MedInfo)).EndInit();
			this.groupControl_MedReg_MedInfo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedReg_MedName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedReg_Taketimes.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedReg_MedTake.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedReg_MedType.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MedReg_MedCarrInfo)).EndInit();
			this.groupControl_MedReg_MedCarrInfo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.listBoxControl_MedReg_MedCarrInfo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.listBoxControl_MedReg_MedInfo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MedReg_DiagInfo)).EndInit();
			this.groupControl_MedReg_DiagInfo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedReg_Else.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedReg_FacialSym.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedReg_SkinSym.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedReg_AbdomenSym.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedReg_EnteronSym.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedReg_ThroatSym.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedReg_LungSym.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedReg_UpperSym.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_MedReg_Diag.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl8)).EndInit();
			this.panelControl8.ResumeLayout(false);
			this.xtraTabPage9.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl10)).EndInit();
			this.splitContainerControl10.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MedRec_AbnStuList)).EndInit();
			this.groupControl_MedRec_AbnStuList.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl_MedRec_AbnStuList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView10)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MedRec_Ser)).EndInit();
			this.groupControl_MedRec_Ser.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedRec_Number.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedRec_Name.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_MedRec_EndDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit_MedRec_BegDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedRec_DoseRecDiaID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedRec_AbnDiaID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_MedRec_Class.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_MedRec_Grade.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MedRec_DiagAndDoseAdd)).EndInit();
			this.groupControl_MedRec_DiagAndDoseAdd.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MedRec_DoseAdd)).EndInit();
			this.groupControl_MedRec_DoseAdd.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.listBoxControl_MedRec_MedCarrInfo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_MedRec_TakeRule.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.timeEdit_MedRec_TakeTime.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedRec_MedTake.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedRec_MedName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MedRec_DiagInfo)).EndInit();
			this.groupControl_MedRec_DiagInfo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedRec_Diag.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedRec_Else.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedRec_FacialSym.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedRec_SkinSym.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedRec_AbdomenSym.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedRec_EnteronSym.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedRec_ThroatSym.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedRec_LungSym.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit_MedRec_UpperSym.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl_MedRec_DoseRec)).EndInit();
			this.groupControl_MedRec_DoseRec.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl_MedRec_DoseRec)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView11)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView12)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl9)).EndInit();
			this.panelControl9.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView14)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void NutritionManagement_Load(object sender, System.EventArgs e)
		{	
			#region 初始权限设置
			if ( Thread.CurrentPrincipal.IsInRole("班主任") )
			{
				xtraTabPage1.PageVisible = false;
				xtraTabPage2.PageVisible = false;
				xtraTabPage3.PageVisible = false;
				xtraTabPage4.PageVisible = false;
				xtraTabPage5.PageVisible = false;
				xtraTabPage6.PageVisible = false;
				xtraTabPage8.PageVisible = false;
				xtraTabPage9.PageVisible = false;
			}
			
			if ( Thread.CurrentPrincipal.Identity.Name.ToLower() == "admin" )
			{
				simpleButton_FoodAdd.Enabled = false;
				simpleButton_FoodBack.Enabled = false;
				simpleButton_FoodDelete.Enabled = false;
				simpleButton_FoodModify.Enabled = false;
				simpleButton_FoodSave.Enabled = false;
				simpleButton_RecipeSave.Enabled = false;
				simpleButton_RecipeModify.Enabled = false;
				barButtonItem_RecipeDelete.Enabled = false;
				simpleButton_MealAdd.Enabled = false;
				simpleButton_MealAppend.Enabled = false;
				simpleButton_MealBack.Enabled = false;
				simpleButton_MealDelete.Enabled = false;
				simpleButton_MealSave.Enabled = false;
				simpleButton_Meal_PreviewReport.Enabled = false;
				simpleButton_Meal_PrintReport.Enabled = false;
				simpleButton_HInputDelete.Enabled = false;
				simpleButton_HInputDiag.Enabled = false;
				simpleButton_HInputModify.Enabled = false;
				simpleButton_HInputSave.Enabled = false;
				simpleButton_HOutputPrint.Enabled = false;
				simpleButton_WatchBack.Enabled = false;
				simpleButton_WatchDelete.Enabled = false;
				simpleButton_WatchHandle.Enabled = false;
				simpleButton_WatchReport.Enabled = false;
				simpleButton_MedReg_Back.Enabled = false;
				simpleButton_MedReg_Reg.Enabled = false;
				barButtonItem_MedReg_MedDel.Enabled = false;
				barButtonItem_MedReg_MedAdd.Enabled = false;
				barButtonItem_MedReg_MedModify.Enabled = false;
				simpleButton_MedRec_Add.Enabled = false;
				simpleButton_MedRec_Back.Enabled = false;
				simpleButton_MedRec_Report.Enabled = false;
				barButtonItem_MedRec_MedDel.Enabled = false;

			}
			#endregion

			#region 时间初始化
			dateEdit_DiagCheckDate.EditValue = DateTime.Now.Date;
			dateEdit_HOutputBegDate.EditValue = DateTime.Now.Date;
			dateEdit_HOutputEndDate.EditValue = DateTime.Now.Date;
			dateEdit_Meal_BegDate.EditValue = DateTime.Now.Date;
			dateEdit_Meal_EndDate.EditValue = DateTime.Now.Date;
			dateEdit_MedRec_BegDate.EditValue = DateTime.Now.Date;
			dateEdit_MedRec_EndDate.EditValue = DateTime.Now.Date;
			dateEdit_Recipe_BegDate.EditValue = DateTime.Now.Date;
			dateEdit_Recipe_EndDate.EditValue = DateTime.Now.Date;
			dateEdit_RecipeLogin_Date.EditValue = DateTime.Now.Date;
			dateEdit_WatchBegDate.EditValue = DateTime.Now.Date;
			dateEdit_WatchEndDate.EditValue = DateTime.Now.Date;
			#endregion

			#region 库存加载
			TreeListNode parentNode = null;
			TreeListNode childNode = null;
			parentNode = treeList_FoodStock.AppendNode(new object[]{ "食物分类" },null);
			parentNode.StateImageIndex = 0;
			parentNode.Tag = "";

			foreach(DataRow nodeMemb in foodManagementSystem.GetFoodCategory().Tables[0].Rows)
			{
				childNode = treeList_FoodStock.AppendNode(new object[]{ nodeMemb[1].ToString() },parentNode);
				childNode.StateImageIndex = 1;
				childNode.Tag = nodeMemb[1].ToString();
			}	

			treeList_FoodStock.ExpandAll();
			treeList_FoodStock.BestFitColumns();


			#endregion

			#region 食谱安排加载
			comboBoxEdit_RecipeSer_FoodCategory.SelectedIndex = 0;
			
			RecipeLoginUnTextBinding();
			RecipeLoginTextBinding(getRecFoodCateName,textEdit_Recipe_FoodName.Text.Replace(" ",""));
			#endregion

			#region 膳食安排加载
			MealUnTextBinding();
			MealTextBinding();
			#endregion

			#region 健康检测加载
			comboBoxEdit_HInputGrade.SelectedItem = "全部";
			foreach(DataRow getGradeList in getStuInfoByCondition.getGradeInfo("","").Tables[0].Rows)
			{
				comboBoxEdit_HInputGrade.Properties.Items.AddRange(
					new object[]{getGradeList[1].ToString()});

				

			}

			if ( useVersion.Equals("全国版") )
			{
				comboBoxEdit_HInputRegion.SelectedItem = "全国标准";
				comboBoxEdit_HInputRegion.Enabled = false;
			}
			else
			{
				comboBoxEdit_HInputRegion.SelectedItem = "上海标准";
				comboBoxEdit_HInputRegion.Enabled = false;
			}

			#endregion

			#region 健康检测输出加载
			comboBoxEdit_HOutputGrade.SelectedItem = "全部";
			foreach(DataRow getGradeList in getStuInfoByCondition.getGradeInfo("","").Tables[0].Rows)
			{
				comboBoxEdit_HOutputGrade.Properties.Items.AddRange(
					new object[]{getGradeList[1].ToString()});
			}

			if ( useVersion.Equals("全国版") )
			{
				comboBoxEdit_HOutputRegion.SelectedItem = "全国标准";
				comboBoxEdit_HOutputRegion.Enabled = false;
				outputNationalRegion = true;
			}
			else
			{
				comboBoxEdit_HOutputRegion.SelectedItem = "上海标准";
				comboBoxEdit_HOutputRegion.Enabled = false;
				outputNationalRegion = false;
				HealthAnalysisStandard(false);
			}


			UnHealthTextDataBinding();
			HealthTextDataBinding("","","","","");

			HOutputTextDataBinding();

//			gridControl_HOutputNchsGrid.Visible = false;

			#endregion 
			
			#region 晨检及全日观察加载
			comboBoxEdit_WatchGrade.SelectedItem = "全部";
			foreach(DataRow getGradeList in getStuInfoByCondition.getGradeInfo("","").Tables[0].Rows)
			{
				comboBoxEdit_WatchGrade.Properties.Items.AddRange(
					new object[]{getGradeList[1].ToString()});
			}

			if ( Thread.CurrentPrincipal.IsInRole("班主任") )
			{
				DataSet dsRolesDuty = rolesSystem.GetRolesDuty(Convert.ToInt32(Thread.CurrentPrincipal.Identity.Name));
				string gradeName = dsRolesDuty.Tables[0].Rows[0][0].ToString();
				string className = dsRolesDuty.Tables[0].Rows[0][1].ToString();

				comboBoxEdit_WatchGrade.Properties.Items.Clear();
				comboBoxEdit_WatchGrade.Properties.Items.AddRange(new object[]{gradeName});
				comboBoxEdit_WatchGrade.SelectedItem = gradeName;
				comboBoxEdit_WatchClass.Properties.Items.Clear();
				comboBoxEdit_WatchClass.Properties.Items.AddRange(new object[]{className});
				comboBoxEdit_WatchClass.SelectedItem = className;
			}

//			MedInfoShow();
			WatchTextDataBinding();
			WholeDayWatchTextUnDataBinding();
			WholeDayWatchTextDataBinding();

			#endregion

			#region 服药登记加载
			comboBoxEdit_MedReg_Grade.SelectedItem = "全部";
			foreach(DataRow getGradeList in getStuInfoByCondition.getGradeInfo("","").Tables[0].Rows)
			{
				comboBoxEdit_MedReg_Grade.Properties.Items.AddRange(
					new object[]{getGradeList[1].ToString()});
			}
			MedRegGridShow();
			#endregion

			#region 服药记录加载
			comboBoxEdit_MedRec_Grade.SelectedItem = "全部";
			foreach(DataRow getGradeList in getStuInfoByCondition.getGradeInfo("","").Tables[0].Rows)
			{
				comboBoxEdit_MedRec_Grade.Properties.Items.AddRange(
					new object[]{getGradeList[1].ToString()});
			}

			if ( Thread.CurrentPrincipal.IsInRole("园长") )
				teaAuthority = string.Empty;
			else
				teaAuthority = healthManagementSystem.GetTeaName(Thread.CurrentPrincipal.Identity.Name);
			textEdit_MedRec_AbnDiaID.DataBindings.Clear();
			AbnGridShow();
			textEdit_MedRec_DoseRecDiaID.DataBindings.Clear();
			DoseInfoGridShow(getMedRecGrade,getMedRecClass,getMedRecStuName,getMedRecStuNumber,dateEdit_MedRec_BegDate.DateTime.Date,dateEdit_MedRec_EndDate.DateTime.Date,teaAuthority);
			#endregion
		}

		#region 食物库存处理
		#region 库存返回
		private void simpleButton_FoodBack_Click(object sender, System.EventArgs e)
		{
			UnTextBindings();
			TextBindings(getFoodCateName,textEdit_FoodSearch.Text.Replace(" ",""));
			groupControl_FoodNutModify.Visible = false;
			groupControl_FoodNutrition.Visible = true;
			simpleButton_FoodSave.Enabled = false;
			simpleButton_FoodModify.Enabled = false;
			simpleButton_FoodDelete.Enabled = true;
			simpleButton_FoodAdd.Enabled = true;
		}
		#endregion

		#region 库存增加
		private void simpleButton_FoodAdd_Click(object sender, System.EventArgs e)
		{
			groupControl_FoodNutModify.Visible = true;
			groupControl_FoodNutrition.Visible = false;
			simpleButton_FoodSave.Enabled = true;
			simpleButton_FoodDelete.Enabled = false;
			TextClear();
		}
		#endregion

		#region 库存保存
		private void simpleButton_FoodSave_Click(object sender, System.EventArgs e)
		{
			string message = "是否确认保存这些数据？";
			string caption = "消息提示框!";
			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult == DialogResult.Yes )
			{
				if ( !foodManagementSystem.isValidProtein(textEdit_Protein.Text.Replace(" ","")) )
					MessageBox.Show("蛋白质含量输入不正确，请重试！");
				else
				{
					if ( !foodManagementSystem.isValidFat(textEdit_Fat.Text.Replace(" ","")) )
						MessageBox.Show("脂肪含量输入不正确，请重试！");
					else
					{
						if ( !foodManagementSystem.isValidCarbohydrate(textEdit_Carbohydrate.Text.Replace(" ","")) )
							MessageBox.Show("碳水化合物含量输入不正确，请重试！");
						else
						{
							if ( !foodManagementSystem.isValidEnery(textEdit_Energy.Text.Replace(" ","")))
								MessageBox.Show("热量输入不正确，请重试！");
							else
							{
								if ( textEdit_FoodName.Text.Equals("") )
									MessageBox.Show("食物名字不能为空！");
								else
								{
									foodManagementSystem.GetFoodName(textEdit_FoodName.Text.Replace(" ",""));
									foodManagementSystem.GetFoodCategory(comboBoxEdit_FoodCategory.SelectedItem.ToString());
									foodManagementSystem.GetFoodRemark(memoEdit_FoodRemark.Text);
									if ( foodManagementSystem.InsertNutrition() == -1 )
										MessageBox.Show("保存中出现错误，请重试！");
									else
										MessageBox.Show("保存完毕！");
								}
							}
						}
					}
				}
				simpleButton_FoodBack.PerformClick();
			}
		}
		#endregion

		#region 库存修改
		private void simpleButton_FoodModify_Click(object sender, System.EventArgs e)
		{
			string message = "是否确认修改这些数据？";
			string caption = "消息提示框!";
			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult == DialogResult.Yes )
			{
				if ( !foodManagementSystem.isValidProtein(textEdit_Protein.Text.Replace(" ","")) )
					MessageBox.Show("蛋白质含量输入不正确，请重试！");
				else
				{
					if ( !foodManagementSystem.isValidFat(textEdit_Fat.Text.Replace(" ","")) )
						MessageBox.Show("脂肪含量输入不正确，请重试！");
					else
					{
						if ( !foodManagementSystem.isValidCarbohydrate(textEdit_Carbohydrate.Text.Replace(" ","")) )
							MessageBox.Show("碳水化合物含量输入不正确，请重试！");
						else
						{
							if ( !foodManagementSystem.isValidEnery(textEdit_Energy.Text.Replace(" ","")))
								MessageBox.Show("热量输入不正确，请重试！");
							else
							{
								if ( textEdit_FoodName.Text.Equals("") )
									MessageBox.Show("食物名字不能为空！");
								else
								{
									foodManagementSystem.GetFoodName(textEdit_FoodName.Text.Replace(" ",""));
									foodManagementSystem.GetFoodCategory(comboBoxEdit_FoodCategory.SelectedItem.ToString());
									foodManagementSystem.GetFoodRemark(memoEdit_FoodRemark.Text);
									foodManagementSystem.GetFoodID(Convert.ToInt32(textEdit_BindingID.Text));
									if ( foodManagementSystem.UpdateNutrition() == -1 )
										MessageBox.Show("修改数据中出现错误，请重试！");
									else
										MessageBox.Show("修改完毕！");
								}
							}
						}
					}
				}
				simpleButton_FoodBack.PerformClick();
			}
		}
		#endregion

		#region 库存删除
		private void simpleButton_FoodDelete_Click(object sender, System.EventArgs e)
		{
			string message = "是否确认删除这些数据？";
			string caption = "消息提示框!";
			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult == DialogResult.Yes )
			{
				if ( gridView1.RowCount == 0 )
					MessageBox.Show("删除数据前请先选中！");
				else
				{
					foodManagementSystem.GetFoodID(Convert.ToInt32(textEdit_BindingID.Text));
					if ( foodManagementSystem.DeleteNutrition() == -1 )
						MessageBox.Show("删除数据中发生错误，请重试");
					else
						MessageBox.Show("删除完毕！");
					UnTextBindings();
					TextBindings(getFoodCateName,textEdit_FoodSearch.Text.Replace(" ",""));
				}
				simpleButton_FoodBack.PerformClick();
			}

		}
		#endregion

		#region 库存树选择
		private void treeList_FoodStock_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
		{
			if ( treeList_FoodStock.FocusedNode.Tag != null )
				getFoodCateName = treeList_FoodStock.FocusedNode.Tag.ToString();
			UnTextBindings();
			TextBindings(getFoodCateName,textEdit_FoodSearch.Text.Replace(" ",""));
			groupControl_FoodNutModify.Visible = false;
			groupControl_FoodNutrition.Visible = true;
			
		}
		#endregion

		#region 库存快速搜索览
		private void textEdit_FoodSearch_EditValueChanged(object sender, System.EventArgs e)
		{
			UnTextBindings();
			TextBindings(getFoodCateName,textEdit_FoodSearch.Text.Replace(" ",""));
		}
		#endregion

		#region 库存数据绑定
		private void TextBindings(string getFoodCateName,string getFoodNutName)
		{
			DataSet dsFoodMgmt = foodManagementSystem.GetFoodNutrition(getFoodCateName,getFoodNutName);
			gridControl_FoodNutrition.DataSource = dsFoodMgmt.Tables[0];
			
			textEdit_FoodName.DataBindings.Add("EditValue",dsFoodMgmt.Tables[0],"FoodNut_FoodName");
			comboBoxEdit_FoodCategory.DataBindings.Add("EditValue",dsFoodMgmt.Tables[0],"FoodCate_Name");
			textEdit_Protein.DataBindings.Add("EditValue",dsFoodMgmt.Tables[0],"FoodNut_Protein");
			textEdit_Fat.DataBindings.Add("EditValue",dsFoodMgmt.Tables[0],"FoodNut_Fat");
			textEdit_Carbohydrate.DataBindings.Add("EditValue",dsFoodMgmt.Tables[0],"FoodNut_Carbohydrate");
			textEdit_Energy.DataBindings.Add("EditValue",dsFoodMgmt.Tables[0],"FoodNut_Energy");
			memoEdit_FoodRemark.DataBindings.Add("EditValue",dsFoodMgmt.Tables[0],"FoodNut_Remark");
			textEdit_BindingID.DataBindings.Add("EditValue",dsFoodMgmt.Tables[0],"FoodNut_FoodID");
		}
		#endregion

		#region 库存撤消绑定
		private void UnTextBindings()
		{
			textEdit_FoodName.DataBindings.Clear();
			comboBoxEdit_FoodCategory.DataBindings.Clear();
			textEdit_Protein.DataBindings.Clear();
			textEdit_Fat.DataBindings.Clear();
			textEdit_Carbohydrate.DataBindings.Clear();
			textEdit_Energy.DataBindings.Clear();
			memoEdit_FoodRemark.DataBindings.Clear();
			textEdit_BindingID.DataBindings.Clear();
		}
		#endregion

		#region 库存grid双击事件
		private void gridControl_FoodNutrition_DoubleClick(object sender, System.EventArgs e)
		{
			if ( Thread.CurrentPrincipal.Identity.Name.ToLower() != "admin" )
			{
				groupControl_FoodNutrition.Visible = false;
				groupControl_FoodNutModify.Visible = true;

				simpleButton_FoodModify.Enabled = true;
				simpleButton_FoodAdd.Enabled = false;

				UnTextBindings();
			}
		}
		#endregion

		#region 库存控件清空
		private void TextClear()
		{
			textEdit_FoodName.EditValue = null;
			textEdit_Protein.EditValue = null;
			textEdit_Fat.EditValue = null;
			textEdit_Carbohydrate.EditValue = null;
			textEdit_Energy.EditValue = null;
			memoEdit_FoodRemark.EditValue = null;
			textEdit_BindingID.EditValue = null;
		}
		#endregion 

		#endregion

		#region 食谱安排

		#region 每日摄入保存
		private void simpleButton_RecipeSave_Click(object sender, System.EventArgs e)
		{
			string message = "是否确认保存这些数据？";
			string caption = "消息提示框!";
			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult == DialogResult.Yes )
			{
				int resMsg = foodManagementSystem.InsertAccFood(textEdit_RecipeLogin_BindingID.Text,textEdit_RecipeLogin_FoodTake.Text.Replace(" ",""),
					dateEdit_RecipeLogin_Date.DateTime.Date.ToString("yyyy-MM-dd"),textEdit_RecipeLogin_Name.Text);
				if ( resMsg != -1 )
				{
					if ( resMsg == -2 )
					{
						MessageBox.Show("今天的菜谱中已经存在该食物，无需重复添加！");
					}
					else
					{
						comboBoxEdit_Recipe_RecipeCategory.SelectedItem = getRecFoodCateName;
						MessageBox.Show("保存完毕！");
					}
				}
				else
					MessageBox.Show("保存中出现错误，请在正确填写后重试！");
			}
			RecipeLoginUnTextBinding();
			RecipeLoginTextBinding(getRecFoodCateName,textEdit_Recipe_FoodName.Text);
			textEdit_RecipeLogin_FoodTake.EditValue = null;
			textEdit_RecipeLogin_Name.EditValue = null;
			simpleButton_RecipeSave.Enabled = false;
		}

		#endregion
		
		#region 每日摄入修改
		private void simpleButton_RecipeModify_Click(object sender, System.EventArgs e)
		{
			string message = "是否确认修改这些数据？";
			string caption = "消息提示框!";
			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult == DialogResult.Yes )
			{
				if ( foodManagementSystem.UpdateAccFood(textEdit_RecipeLogin_BindingID.Text,textEdit_RecipeLogin_FoodTake.Text.Replace(" ",""),
							dateEdit_RecipeLogin_Date.DateTime.Date.ToString("yyyy-MM-dd"),textEdit_RecipeLogin_Name.Text) != -1 )
					MessageBox.Show("修改完毕！");
				else
					MessageBox.Show("修改中出现错误，请在正确填写后重试！");
			}
			RecipeLoginUnTextBinding();
			RecipeLoginTextBinding(getRecFoodCateName,textEdit_Recipe_FoodName.Text);

			simpleButton_RecipeModify.Enabled = false;
		}
		#endregion

		#region 每日摄入刷新
		private void barButtonItem_RecipeRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			RecipeLoginUnTextBinding();
			RecipeLoginTextBinding(getRecFoodCateName,textEdit_Recipe_FoodName.Text);
		}
		#endregion

		#region 每日摄入删除
		private void barButtonItem_RecipeDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			string message = "是否确认删除这些数据？";
			string caption = "消息提示框!";
			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult == DialogResult.Yes )
			{
				if ( gridView13.DataRowCount != 0 )
				{
					if ( foodManagementSystem.DeleteAccFood(gridView13.GetDataRow(gridView13.GetSelectedRows()[0])[0].ToString(),
						gridView13.GetDataRow(gridView13.GetSelectedRows()[0])[1].ToString()) != -1 )
						MessageBox.Show("删除完毕！");
					else
						MessageBox.Show("删除中出现错误，请检查网络后重试！");
				}
				else
					MessageBox.Show("请先选择数据再删除！");
			}
			RecipeLoginUnTextBinding();
			RecipeLoginTextBinding(getRecFoodCateName,textEdit_Recipe_FoodName.Text);
		}
		#endregion

		#region 食物名查询
		private void textEdit_RecipeSer_FoodName_EditValueChanged(object sender, System.EventArgs e)
		{
			RecipeGridShow(getRecFoodCateName,textEdit_RecipeSer_FoodName.Text.Replace(" ",""));
		}
		#endregion

		#region 食物分类事件
		private void comboBoxEdit_RecipeSer_FoodCategory_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			getRecFoodCateName = comboBoxEdit_RecipeSer_FoodCategory.SelectedItem.ToString();
			RecipeGridShow(getRecFoodCateName,textEdit_RecipeSer_FoodName.Text.Replace(" ",""));
		}
		#endregion

		#region 每日摄入浏览双击事件
		private void gridControl_Recipe_FoodNutrition_DoubleClick(object sender, System.EventArgs e)
		{
			if ( Thread.CurrentPrincipal.Identity.Name.ToLower() != "admin" )
			{
				simpleButton_RecipeSave.Enabled = true;
				dateEdit_RecipeLogin_Date.Enabled = true;
				RecipeLoginUnTextBinding();
				textEdit_RecipeLogin_FoodTake.EditValue = null;
				textEdit_RecipeLogin_Name.EditValue = null;
				textEdit_RecipeLogin_FoodName.Text = gridView4.GetDataRow(gridView4.GetSelectedRows()[0])[1].ToString();
				textEdit_RecipeLogin_BindingID.Text = gridView4.GetDataRow(gridView4.GetSelectedRows()[0])[0].ToString();
			
				clickPerformedOnce = true;
			}
		}
		#endregion

		#region 食谱分类事件
		private void comboBoxEdit_Recipe_RecipeCategory_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			getRecFoodCateName = comboBoxEdit_Recipe_RecipeCategory.SelectedItem.ToString();
			if ( getRecFoodCateName.Equals("全部") )
				getRecFoodCateName = "";
			RecipeLoginUnTextBinding();
			RecipeLoginTextBinding(getRecFoodCateName,textEdit_Recipe_FoodName.Text.Replace(" ",""));
		}
		#endregion

		#region 每日摄入搜索
		private void textEdit_Recipe_FoodName_EditValueChanged(object sender, System.EventArgs e)
		{
			RecipeLoginUnTextBinding();
			RecipeLoginTextBinding(getRecFoodCateName,textEdit_Recipe_FoodName.Text.Replace(" ",""));
		}
		#endregion

		#region ToolTip控制，显示grid具体数据
		private void toolTipController1_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
		{
			if ( e.SelectedControl != gridControl_Recipe_FoodNutrition ) 
				return;
			ToolTipControlInfo info = null;
			try 
			{
				GridView view = gridControl_Recipe_FoodNutrition.GetViewAt(e.ControlMousePosition) as GridView;
				if(view == null) 
					return;
				GridHitInfo hi = view.CalcHitInfo(e.ControlMousePosition);
				if ( hi.InRowCell ) 
				{
					info = new ToolTipControlInfo(new CellToolTipInfo(hi.RowHandle, hi.Column, "cell"), GetCellHintText(view, hi.RowHandle, hi.Column));
					return;
				}
				if ( hi.Column != null ) 
				{
					info = new ToolTipControlInfo(hi.Column, GetColumnHintText(hi.Column));
					return;
				}
				if ( hi.HitTest == GridHitTest.GroupPanel ) 
				{
					info = new ToolTipControlInfo(hi.HitTest, "Group panel");
					return;
				}
				
				if ( hi.HitTest == GridHitTest.RowIndicator ) 
				{
					info = new ToolTipControlInfo(GridHitTest.RowIndicator.ToString() + hi.RowHandle.ToString(),  "Row Handle: " + hi.RowHandle.ToString());
					return;
				}
			}
			finally 
			{
				e.Info = info;
			}
		}
		#endregion

		#region 显示grid的单元格内容
		private string GetCellHintText(DevExpress.XtraGrid.Views.Grid.GridView view, int rowHandle, DevExpress.XtraGrid.Columns.GridColumn column) 
		{
			string ret = view.GetRowCellDisplayText(rowHandle, column);
			foreach(DevExpress.XtraGrid.Columns.GridColumn col in view.Columns)
				if ( col.VisibleIndex < 0 )
					ret += string.Format("\r\n {0}: {1}", col.Caption, view.GetRowCellDisplayText(rowHandle, col)); 
			return ret;
		}
		#endregion

		#region 显示列名
		private string GetColumnHintText(DevExpress.XtraGrid.Columns.GridColumn column) 
		{
			string ret = ColumnHints[gridView4.Columns.IndexOf(column)];
			if ( ret == "" )
				ret = column.Caption;
			return ret;
		}
		#endregion

		#region 食物营养成份显示
		private void RecipeGridShow(string getFoodCateName,string getFoodNutName)
		{
			DataSet dsRecipeFoodNut = foodManagementSystem.GetFoodNutrition(getFoodCateName,getFoodNutName);
			gridControl_Recipe_FoodNutrition.DataSource = dsRecipeFoodNut.Tables[0];
		}
		#endregion

		#region 每日摄入绑定
		private void RecipeLoginTextBinding(string getFoodCateName,string getFoodNutName)
		{
			DataSet dsRecipeLoginFood = foodManagementSystem.GetAccFood(getFoodCateName,getFoodNutName,
				dateEdit_Recipe_BegDate.DateTime.Date.ToString("yyyy-MM-dd"),
				dateEdit_Recipe_EndDate.DateTime.Date.ToString("yyyy-MM-dd"));
			gridControl_RecipeLogin.DataSource = dsRecipeLoginFood.Tables[0];

			textEdit_RecipeLogin_BindingID.DataBindings.Add("EditValue",dsRecipeLoginFood.Tables[0],"ACCFood_ID");
			textEdit_RecipeLogin_FoodName.DataBindings.Add("EditValue",dsRecipeLoginFood.Tables[0],"FoodNut_FoodName");
			textEdit_RecipeLogin_FoodTake.DataBindings.Add("EditValue",dsRecipeLoginFood.Tables[0],"ACCFood_TakeAmount");
			dateEdit_RecipeLogin_Date.DataBindings.Add("EditValue",dsRecipeLoginFood.Tables[0],"ACCFood_AddTime");
			textEdit_RecipeLogin_Name.DataBindings.Add("EditValue",dsRecipeLoginFood.Tables[0],"ACCFood_Remark");
		}
		#endregion

		private void gridControl_RecipeLogin_Click(object sender, System.EventArgs e)
		{
			if ( gridView13.RowCount > 0 )
			{
				simpleButton_RecipeSave.Enabled = false;
				simpleButton_RecipeModify.Enabled = true;
				if ( clickPerformedOnce )
				{
					RecipeLoginUnTextBinding();
					RecipeLoginTextBinding(getRecFoodCateName,textEdit_Recipe_FoodName.Text.Replace(" ",""));
					clickPerformedOnce = false;
				}
			}
		}

		#region 撤消绑定
		private void RecipeLoginUnTextBinding()
		{
			textEdit_RecipeLogin_BindingID.DataBindings.Clear();
			textEdit_RecipeLogin_FoodName.DataBindings.Clear();
			textEdit_RecipeLogin_FoodTake.DataBindings.Clear();
			dateEdit_RecipeLogin_Date.DataBindings.Clear();
			textEdit_RecipeLogin_Name.DataBindings.Clear();

		}
		#endregion
		#endregion

		#region  膳食安排
		#region  grid双击
		private void gridControl_MealPreview_DoubleClick(object sender, System.EventArgs e)
		{
			if ( Thread.CurrentPrincipal.Identity.Name.ToLower() != "admin" )
			{
				foreach ( DataRow arrName in foodManagementSystem.GetFoodArrName().Tables[0].Rows )
					comboBoxEdit_MealArr_Name.Properties.Items.AddRange(new object[]{ arrName[0].ToString() });
		
				foodManagementSystem.GetFoodArrID(textEdit_MealID.Text);
				DataSet dsFoodArrGradeInfo = foodManagementSystem.GetFoodArrGrade(false);
				comboBoxEdit_MealArr_Name.SelectedItem = dsFoodArrGradeInfo.Tables[0].Rows[0][0].ToString();
				GradeTextBinding(dsFoodArrGradeInfo);

				groupControl_MealPreview.Visible = false;
				groupControl_MealArr.Visible = true;

				simpleButton_MealAppend.Enabled = false;
				simpleButton_MealAdd.Enabled = false;
				simpleButton_MealDelete.Enabled = false;
				simpleButton_MealSave.Enabled = true;
			}
		}
		#endregion

		#region 膳食选择事件
		private void comboBoxEdit_MealArr_Name_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			foodManagementSystem.GetFoodArrName(comboBoxEdit_MealArr_Name.SelectedItem.ToString());
			DataSet dsFoodArrGradeInfo = foodManagementSystem.GetFoodArrGrade(true);
			GradeTextBinding(dsFoodArrGradeInfo);
			
			checkEdit_Breakfast.EditValue = false;
			checkEdit_Dinner.EditValue = false;
			checkEdit_Lunch.EditValue = false;
			checkEdit_Snack.EditValue = false;

			if ( Convert.ToBoolean(dsFoodArrGradeInfo.Tables[0].Rows[0][3]) )
				checkEdit_Breakfast.EditValue = true;
			if ( Convert.ToBoolean(dsFoodArrGradeInfo.Tables[0].Rows[0][4]) )
				checkEdit_Lunch.EditValue = true;
			if ( Convert.ToBoolean(dsFoodArrGradeInfo.Tables[0].Rows[0][5]) )
				checkEdit_Snack.EditValue = true;
			if ( Convert.ToBoolean(dsFoodArrGradeInfo.Tables[0].Rows[0][6]) )
				checkEdit_Dinner.EditValue = true;

			textEdit_MealName.Text = dsFoodArrGradeInfo.Tables[0].Rows[0][0].ToString();
			textEdit_MealRemark.Text = dsFoodArrGradeInfo.Tables[0].Rows[0][7].ToString();

		}
		#endregion

		#region grid刷新
		private void barButtonItem_MealRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			MealUnTextBinding();
			MealTextBinding();
		}
		#endregion

		#region 返回
		private void simpleButton_MealBack_Click(object sender, System.EventArgs e)
		{
			groupControl_MealPreview.Visible = true;
			groupControl_MealArr.Visible = false;
			simpleButton_MealAdd.Enabled = true;
			simpleButton_MealAppend.Enabled = true;
			simpleButton_MealDelete.Enabled = true;
			simpleButton_MealSave.Enabled = false;
			MealUnTextBinding();
			MealTextBinding();
		}
		#endregion
		
		#region 膳食添加
		private void simpleButton_MealAdd_Click(object sender, System.EventArgs e)
		{
			string message = "是否确认保存这些数据？";
			string caption = "消息提示框!";
			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult == DialogResult.Yes )
			{
				if ( textEdit_MealName.Text.Equals("") )
					MessageBox.Show("膳食名不能为空！");
				else
				{
					if ( !textEdit_MealID.Text.Equals("") )
						foodManagementSystem.GetFoodArrID(textEdit_MealID.Text);
					else
						foodManagementSystem.GetFoodArrID("0");
					foodManagementSystem.GetMealName(textEdit_MealName.Text.Replace(" ",""));
					foodManagementSystem.GetMealRemark(textEdit_MealRemark.Text);
					foodManagementSystem.HasBreakFast((bool)checkEdit_Breakfast.EditValue);
					foodManagementSystem.HasLunch((bool)checkEdit_Lunch.EditValue);
					foodManagementSystem.HasSnack((bool)checkEdit_Snack.EditValue);
					foodManagementSystem.HasDinner((bool)checkEdit_Dinner.EditValue);
					if ( foodManagementSystem.InsertFoodArrMeal() == -1 )
						MessageBox.Show("保存中出现错误，请确认数据输入是否正确，是否重命名，网络连接是否正常后重试！");
					else
						MessageBox.Show("保存完毕！");
				}
			}
			MealUnTextBinding();
			MealTextBinding();
		}
		#endregion
		
		#region 膳食修改
		private void simpleButton_MealModify_Click(object sender, System.EventArgs e)
		{
			string message = "是否确认修改这些数据？";
			string caption = "消息提示框!";
			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult == DialogResult.Yes )
			{
				if ( textEdit_MealName.Text.Equals("") )
					MessageBox.Show("膳食名不能为空！");
				else
				{
					foodManagementSystem.GetMealName(textEdit_MealName.Text.Replace(" ",""));
					foodManagementSystem.GetMealRemark(textEdit_MealRemark.Text);
					foodManagementSystem.HasBreakFast((bool)checkEdit_Breakfast.EditValue);
					foodManagementSystem.HasLunch((bool)checkEdit_Lunch.EditValue);
					foodManagementSystem.HasSnack((bool)checkEdit_Snack.EditValue);
					foodManagementSystem.HasDinner((bool)checkEdit_Dinner.EditValue);
					foodManagementSystem.GetFoodArrID(textEdit_MealID.Text);
					if ( foodManagementSystem.UpdateFoodArrMeal() <= 0 )
						MessageBox.Show("修改中出现错误，请确认数据输入是否正确，是否重命名，网络连接是否正常后重试！");
					else
						MessageBox.Show("修改完毕！");
				}
			}
			MealUnTextBinding();
			MealTextBinding();
		}
		#endregion
		
		#region 膳食删除
		private void simpleButton_MealDelete_Click(object sender, System.EventArgs e)
		{
			string message = "是否确认删除这些数据？";
			string caption = "消息提示框!";
			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult == DialogResult.Yes )
			{
				if ( textEdit_MealID.Text.Equals("") )
				{
					MessageBox.Show("该数据还未进行保存，无发删除，请重试！");
					return;
				}
				foodManagementSystem.GetFoodArrID(textEdit_MealID.Text);
				if ( foodManagementSystem.DeleteFoodArrMeal() <= 0 )
					MessageBox.Show("删除中出现错误，请确认网络连接是否正确后重试！");
				else
					MessageBox.Show("删除完毕！");
			}
			MealUnTextBinding();
			MealTextBinding();
		}
		#endregion 

		#region 幼儿餐保存
		private void simpleButton_MealSave_Click(object sender, System.EventArgs e)
		{
			string message = "是否确认保存这些数据？";
			string caption = "消息提示框!";
			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult == DialogResult.Yes )
			{
				string suitAgeUpdate = "";
				string isUsed = string.Empty;
				if ( (bool)checkEdit_MealArr_gOne.EditValue )
					suitAgeUpdate += checkEdit_MealArr_gOne.Text+",";
				if ( (bool)checkEdit_MealArr_gTwo.EditValue )
					suitAgeUpdate += checkEdit_MealArr_gTwo.Text+",";
				if ( (bool)checkEdit_MealArr_gThree.EditValue )
					suitAgeUpdate += checkEdit_MealArr_gThree.Text+",";
				if ( (bool)checkEdit_MealArr_gFour.EditValue )
					suitAgeUpdate += checkEdit_MealArr_gFour.Text+",";
				if ( (bool)checkEdit_MealArr_gFive.EditValue )
					suitAgeUpdate += checkEdit_MealArr_gFive.Text+",";
				if ( (bool)checkEdit_MealArr_IsUsed.EditValue )
					isUsed = "是";
				else
					isUsed = "否";

				foodManagementSystem.GetFoodArrID(textEdit_MealID.Text);
				foodManagementSystem.GetSuitAge(suitAgeUpdate);
				foodManagementSystem.IsUsed(isUsed);
				
				if ( foodManagementSystem.UpdateFoodArrGrade() <= 0 )
					MessageBox.Show("保存中出现错误，请检查网络连接是否正常后重试！");
				else
					MessageBox.Show("保存完毕！");

				simpleButton_MealAppend.Enabled = true;
				simpleButton_MealAdd.Enabled = true;
				simpleButton_MealDelete.Enabled = true;
				simpleButton_MealSave.Enabled = false;
				simpleButton_MealBack.PerformClick();
			}
		}
		#endregion

		#region 新建膳食
		private void simpleButton_MealAppend_Click(object sender, System.EventArgs e)
		{
			//gridControl_MealPreview.EmbeddedNavigator.Buttons.Append.DoClick();
            gridControl_MealPreview.EmbeddedNavigator.Buttons.DoClick(gridControl_MealPreview.EmbeddedNavigator.Buttons.Append);
			checkEdit_Breakfast.EditValue = false;
			checkEdit_Dinner.EditValue = false;
			checkEdit_Lunch.EditValue = false;
			checkEdit_Snack.EditValue = false;
		}
		#endregion 

		#region 膳食登记信息绑定
		public void MealTextBinding()
		{
			DataSet dsMealGridShow = foodManagementSystem.GetFoodArrangement();
			gridControl_MealPreview.DataSource = dsMealGridShow.Tables[0];

			textEdit_MealID.DataBindings.Add("EditValue",dsMealGridShow.Tables[0],"FoodArr_ArrID");
			textEdit_MealName.DataBindings.Add("EditValue",dsMealGridShow.Tables[0],"FoodArr_Name");
			textEdit_MealRemark.DataBindings.Add("EditValue",dsMealGridShow.Tables[0],"FoodArr_Remark");
			checkEdit_Breakfast.DataBindings.Add("EditValue",dsMealGridShow.Tables[0],"FoodArr_HasBreakfast");
			checkEdit_Lunch.DataBindings.Add("EditValue",dsMealGridShow.Tables[0],"FoodArr_HasLunch");
			checkEdit_Snack.DataBindings.Add("EditValue",dsMealGridShow.Tables[0],"FoodArr_HasSnack");
			checkEdit_Dinner.DataBindings.Add("EditValue",dsMealGridShow.Tables[0],"FoodArr_HasDinner");
		}
		#endregion 

		#region 撤消绑定
		public void MealUnTextBinding()
		{
			textEdit_MealID.DataBindings.Clear();
			textEdit_MealName.DataBindings.Clear();
			textEdit_MealRemark.DataBindings.Clear();
			checkEdit_Breakfast.DataBindings.Clear();
			checkEdit_Lunch.DataBindings.Clear();
			checkEdit_Snack.DataBindings.Clear();
			checkEdit_Dinner.DataBindings.Clear();
		}
		#endregion

		#region 膳食年级信息处理
		private void GradeTextBinding(DataSet dsFoodArrGradeInfo)
		{
			checkEdit_MealArr_gOne.EditValue = false;
			checkEdit_MealArr_gTwo.EditValue = false;
			checkEdit_MealArr_gThree.EditValue = false;
			checkEdit_MealArr_gFour.EditValue = false;
			checkEdit_MealArr_gFive.EditValue = false;
			checkEdit_MealArr_IsUsed.EditValue = false;

			string suitAge = string.Empty;
			string delimStr = ",";
			char [] delimiter = delimStr.ToCharArray();
			string[] spilt=null;
			int count=0;
			int j=0;
			if(!dsFoodArrGradeInfo.Tables[0].Rows[0][0].Equals(""))
			{
				suitAge = dsFoodArrGradeInfo.Tables[0].Rows[0][1].ToString();
				for( int k=0; k<suitAge.Length; k++ )
					if ( suitAge.Substring(k,1).Equals(",") )
						count ++;

				//确定指定标识切割符数量
				for(int i=1;i<=count+1;i++)   
				{
					spilt = suitAge.Split(delimiter,i+1);   
					if ( checkEdit_MealArr_gOne.Text.Equals(spilt[j]) )
						checkEdit_MealArr_gOne.EditValue = true;
					else if ( checkEdit_MealArr_gTwo.Text.Equals(spilt[j]) )
						checkEdit_MealArr_gTwo.EditValue = true;
					else if ( checkEdit_MealArr_gThree.Text.Equals(spilt[j]) )
						checkEdit_MealArr_gThree.EditValue = true;
					else if ( checkEdit_MealArr_gFour.Text.Equals(spilt[j]) )
						checkEdit_MealArr_gFour.Checked=true;
					else if( checkEdit_MealArr_gFive.Text.Equals(spilt[j]) )
						checkEdit_MealArr_gFive.EditValue = true;

					//索取需要的字符串
					j += 1;					
				}  
				if ( dsFoodArrGradeInfo.Tables[0].Rows[0][2].ToString().Equals("是") )
					checkEdit_MealArr_IsUsed.EditValue = true;
			}
		}
		#endregion

		#endregion

		#region 膳食报表打印
		private void simpleButton_Meal_PreviewReport_Click(object sender, System.EventArgs e)
		{
			if ( dateEdit_Meal_EndDate.DateTime.Date < dateEdit_Meal_BegDate.DateTime.Date )
				MessageBox.Show("结束日期不能在起始日期之前！");
			else
			{
				string savePath;
				saveFileDialog_Report.Filter = "Excel文件|*.xls";

				if ( saveFileDialog_Report.ShowDialog() != DialogResult.OK )
					return;

				savePath = saveFileDialog_Report.FileName;

				MessageBox.Show("即将进行指定日期段内的数据分析，分析时间长短视电脑性能而定，按“确定”之后请稍候！");

				foodManagementPrintSystem.NutritionPrint(dateEdit_Meal_BegDate.DateTime.Date,dateEdit_Meal_EndDate.DateTime.Date,savePath);

				MessageBox.Show("报表生成完毕，如果发现指定位置没有生成报表请确认打印日期内是否含有数据！");
			}

		}
		#endregion

		#region 健康检测

		#region 选择年级事件
		private void comboBoxEdit_HInputGrade_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			comboBoxEdit_HInputClass.Properties.Items.Clear();
			comboBoxEdit_HInputClass.Properties.Items.AddRange(new object[]{"全部"});
			comboBoxEdit_HInputClass.SelectedItem = "全部";
			if(getStuInfoByCondition.getGradeInfo(comboBoxEdit_HInputGrade.SelectedItem.ToString(),"").Tables[0].Rows.Count > 0)
			{
				//根据年级选择获取年级编号
				getGradeNumberFromCombo = getStuInfoByCondition.getGradeInfo(
					comboBoxEdit_HInputGrade.SelectedItem.ToString(),"").Tables[0].Rows[0][0].ToString();
				foreach(DataRow getClassList in getStuInfoByCondition.getClassInfo("","",
					getGradeNumberFromCombo).Tables[0].Rows)
				{
					comboBoxEdit_HInputClass.Properties.Items.AddRange(
						new object[]{getClassList[1].ToString()});
				}

				//处理指定的年级事件,如果特定姓名或学号已经存在则不进行处理
				if(textEdit_HInputName.Text.Equals("") && textEdit_HInputNumber.Text.Equals(""))
				{
					UnHealthTextDataBinding();
					HealthTextDataBinding(getGradeNumberFromCombo,"","","",getGender);
				}	
	
			}	
			else
			{
				//处理年级选定项为”全部“事件
				if(textEdit_HInputName.Text.Equals("") && textEdit_HInputNumber.Text.Equals(""))
				{
					UnHealthTextDataBinding();
					HealthTextDataBinding("","","","",getGender);
				}
			}

			if ( comboBoxEdit_HInputGrade.SelectedItem.ToString().Equals("全部") )
				getClassNumberFromCombo = "0";
		}
		#endregion

		#region 班级选择事件
		private void comboBoxEdit_HInputClass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(textEdit_HInputName.Text.Equals("") && textEdit_HInputNumber.Text.Equals(""))
			{
				if(comboBoxEdit_HInputClass.SelectedItem.ToString().Equals("全部"))
				{
					UnHealthTextDataBinding();
					HealthTextDataBinding(getGradeNumberFromCombo,"","","",getGender);
				}
				else
				{
					getClassNumberFromCombo = getStuInfoByCondition.getClassInfo(
						comboBoxEdit_HInputClass.SelectedItem.ToString(),"","").Tables[0].Rows[0][0].ToString();
					UnHealthTextDataBinding();
					HealthTextDataBinding(getGradeNumberFromCombo,getClassNumberFromCombo,"","",getGender);
					
				}
			}

			if ( comboBoxEdit_HInputClass.SelectedItem.ToString().Equals("全部") )
				getClassNumberFromCombo = "0";
		}
		#endregion

		#region 姓名查找
		private void textEdit_HInputName_EditValueChanged(object sender, System.EventArgs e)
		{
			if(textEdit_HInputNumber.Text.Equals(""))
			{
				UnHealthTextDataBinding();

				//处理当姓名为空时，其上控件是否有值选定
				if(!textEdit_HInputName.Text.Equals(""))
				{
					HealthTextDataBinding("","",textEdit_HInputName.Text.Replace(" ",""),"",getGender);
				}
				else
				{
					if(comboBoxEdit_HInputGrade.SelectedItem.ToString().Equals("全部"))
					{
						HealthTextDataBinding("","","","",getGender);
					}
					else if(comboBoxEdit_HInputClass.SelectedItem.ToString().Equals("全部"))
					{
						HealthTextDataBinding(getGradeNumberFromCombo,"","","",getGender);
					}
					else
					{
						HealthTextDataBinding(getGradeNumberFromCombo,getClassNumberFromCombo,"","",getGender);
					}
				}
			}
		}
		#endregion

		#region 学号查找
		private void textEdit_HInputNumber_EditValueChanged(object sender, System.EventArgs e)
		{
			UnHealthTextDataBinding();

			//处理当学号为空时，其上控件是否有值选定
			if(!textEdit_HInputNumber.Text.Equals(""))
			{
				
				HealthTextDataBinding("","","",textEdit_HInputNumber.Text.Replace(" ",""),getGender);
			}
			else
			{
				if(textEdit_HInputName.Text.Equals(""))
				{
					if(comboBoxEdit_HInputGrade.SelectedItem.ToString().Equals("全部"))
					{
						HealthTextDataBinding("","","","",getGender);
					}
					else if(comboBoxEdit_HInputClass.SelectedItem.ToString().Equals("全部"))
					{
						HealthTextDataBinding(getGradeNumberFromCombo,"","","",getGender);
					}
					else
					{
						HealthTextDataBinding(getGradeNumberFromCombo,getClassNumberFromCombo,"","",getGender);
					}
				}
				else
				{
					HealthTextDataBinding("","",textEdit_HInputName.Text,"",getGender);
				}
			}
		}
		#endregion

		#region 性别查找
		private void comboBoxEdit_HInputGender_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( comboBoxEdit_HInputGender.SelectedItem.ToString().Equals("全部") )
				getGender = "";
			else
				getGender = comboBoxEdit_HInputGender.SelectedItem.ToString();
			UnHealthTextDataBinding();
			if ( !textEdit_HInputNumber.Text.Equals("") )
				HealthTextDataBinding("","","",textEdit_HInputNumber.Text,getGender);
			else if ( !textEdit_HInputName.Text.Equals("") )
				HealthTextDataBinding("","",textEdit_HInputName.Text,"",getGender);
			else if ( !getClassNumberFromCombo.Equals("0"))
				HealthTextDataBinding(getGradeNumberFromCombo,getClassNumberFromCombo,"","",getGender);
			else if ( !getGradeNumberFromCombo.Equals("0") )
				HealthTextDataBinding(getGradeNumberFromCombo,"","","",getGender);
			else
				HealthTextDataBinding("","","","",getGender);

		}
		#endregion

		#region grid双击，显示评测历史信息
		private void gridControl_HInputStu_DoubleClick(object sender, System.EventArgs e)
		{
			if ( Thread.CurrentPrincipal.Identity.Name.ToLower() != "admin" )
			{
				if ( inputNationalRegion )
				{
					DataTable dtNchsHealthAnalyHistory = healthManagementSystem.GetNchsHealthAnalyHistory(textEdit_DiagCheckBindingID.Text,
						dateEdit_DiagCheckDate.DateTime.Date.ToString("yyyy-MM-dd"));

					if ( dtNchsHealthAnalyHistory != null )
					{
						if ( dtNchsHealthAnalyHistory.Rows.Count > 0 )
						{
							textEdit_DiagHeight.Text = dtNchsHealthAnalyHistory.Rows[0]["nchsanaly_height"].ToString();
							textEdit_DiagWeight.Text = dtNchsHealthAnalyHistory.Rows[0]["nchsanaly_weight"].ToString();
							memoEdit_DiagRemark.Text = dtNchsHealthAnalyHistory.Rows[0]["nchsanaly_remark"].ToString();
							textEdit_DiagResultAge.Text = dtNchsHealthAnalyHistory.Rows[0]["nchsanaly_realage"].ToString();
							textEdit_DiagResultHeight.Text = dtNchsHealthAnalyHistory.Rows[0]["nchsanaly_heightresult"].ToString();
							textEdit_DiagResultWeight.Text = dtNchsHealthAnalyHistory.Rows[0]["nchsanaly_weightresult"].ToString();
							textEdit_DiagResultWHO.Text = dtNchsHealthAnalyHistory.Rows[0]["nchsanaly_obesity"].ToString();
							textEdit_DiagResultNut.Text = dtNchsHealthAnalyHistory.Rows[0]["nchsanaly_nut"].ToString();
							textEdit_DiagResultUnderWeight.Text = dtNchsHealthAnalyHistory.Rows[0]["nchsanaly_underweight"].ToString();
							textEdit_DiagResultStunting.Text = dtNchsHealthAnalyHistory.Rows[0]["nchsanaly_stunting"].ToString();
							textEdit_DiagResultWasting.Text = dtNchsHealthAnalyHistory.Rows[0]["nchsanaly_wasting"].ToString();

						}
						else MessageBox.Show("指定的幼儿没有评测信息！");
					}
				}
				else
				{
					DataSet dsHealthAnalyHistory = healthManagementSystem.GetHealthAnalyHistory(textEdit_DiagCheckBindingID.Text,
						dateEdit_DiagCheckDate.DateTime.Date.ToString("yyyy-MM-dd"));
					if ( dsHealthAnalyHistory.Tables[0].Rows.Count > 0 )
					{
						textEdit_DiagHeight.Text = dsHealthAnalyHistory.Tables[0].Rows[0][1].ToString();
						textEdit_DiagWeight.Text = dsHealthAnalyHistory.Tables[0].Rows[0][3].ToString();
						memoEdit_DiagRemark.Text = dsHealthAnalyHistory.Tables[0].Rows[0][7].ToString();
						textEdit_DiagResultAge.Text = dsHealthAnalyHistory.Tables[0].Rows[0][0].ToString();
						textEdit_DiagResultHeight.Text = dsHealthAnalyHistory.Tables[0].Rows[0][2].ToString();
						textEdit_DiagResultWeight.Text = dsHealthAnalyHistory.Tables[0].Rows[0][4].ToString();
						textEdit_DiagResultWHO.Text = dsHealthAnalyHistory.Tables[0].Rows[0][5].ToString();
						textEdit_DiagResultNut.Text = dsHealthAnalyHistory.Tables[0].Rows[0][6].ToString();
						if ( Convert.ToBoolean(dsHealthAnalyHistory.Tables[0].Rows[0][8]) )
							comboBoxEdit_HInputStd.SelectedItem = "市区标准";
						else
							comboBoxEdit_HInputStd.SelectedItem = "郊区标准";
					}
					else MessageBox.Show("指定的幼儿没有评测信息！");
				}

				simpleButton_HInputModify.Enabled = true;
			}
		}
		#endregion

		#region 诊断
		private void simpleButton_HInputDiag_Click(object sender, System.EventArgs e)
		{
			bool getGender;
			if ( textEdit_DiagCheckGender.Text.Equals("男") )
				getGender = false;
			else 
				getGender = true;

			ClearEstimation();
			
			if ( !textEdit_DiagCheckBindingID.Text.Equals("") )
			{
				if ( inputNationalRegion )
				{
					healthManagementSystem.DoNchsHealthAnalysis(dateEdit_DiagCheckDate.DateTime.Date,
						Convert.ToDateTime(textEdit_HInputBirthday.Text),textEdit_DiagHeight.Text,textEdit_DiagWeight.Text,getGender);

					if ( healthManagementSystem.GetRtnMsg().Equals("ok") )
					{
						textEdit_DiagResultAge.Text = healthManagementSystem.GetShowAge().Trim();
						textEdit_DiagResultHeight.Text = healthManagementSystem.GetNchsHeightAnaly();
						textEdit_DiagResultWeight.Text = healthManagementSystem.GetNchsWeightAnaly();
						textEdit_DiagResultWHO.Text = healthManagementSystem.GetNchsObesity();
						if ( (textEdit_DiagResultWHO.Text = healthManagementSystem.GetNchsObesity()).Replace(" ","").Equals("") )
						{
							MessageBox.Show("该幼儿信息不准确,不适合做肥胖儿评测！");
							return;
						}
						if ( (textEdit_DiagResultNut.Text = healthManagementSystem.GetNchsNut()).Replace(" ","").Equals("") )
						{
							MessageBox.Show("该幼儿信息不准确,不适合做营养评测试！");
							return;
						}
						if ( (textEdit_DiagResultUnderWeight.Text = healthManagementSystem.GetNchsUnderWeight()).Replace(" ","").Equals("") )
						{
							MessageBox.Show("该幼儿信息不准确,不适合做体重低下评测！");
							return;
						}
						if ( (textEdit_DiagResultStunting.Text = healthManagementSystem.GetNchsStunting()).Replace(" ","").Equals("") )
						{
							MessageBox.Show("该幼儿信息不准确,不适合做生长迟缓评测！");
							return;
						}
						if ( (textEdit_DiagResultWasting.Text = healthManagementSystem.GetNchsWasting()).Replace(" ","").Equals("") )
						{
							MessageBox.Show("该幼儿信息不准确,不适合做消瘦评测！");
							return;
						}
					}
					else MessageBox.Show(healthManagementSystem.GetRtnMsg());
				}
				else
				{
					healthManagementSystem.DoHealthAnalysis(dateEdit_DiagCheckDate.DateTime.Date,
						Convert.ToDateTime(textEdit_HInputBirthday.Text),textEdit_DiagHeight.Text,textEdit_DiagWeight.Text,isCityStd,getGender);

					if ( healthManagementSystem.GetRtnMsg().Equals("ok") )
					{
						textEdit_DiagResultAge.Text = "    " + healthManagementSystem.GetShowAge();
						textEdit_DiagResultHeight.Text = "   " + healthManagementSystem.GetHeightAnaly();
						textEdit_DiagResultWeight.Text = "   " + healthManagementSystem.GetWeightAnaly();
						textEdit_DiagResultWHO.Text = "    " + healthManagementSystem.GetWHO();
						textEdit_DiagResultHeightWeight.Text = "    " + healthManagementSystem.GetHeightWeightAnaly();
						textEdit_DiagResultWHOPer.Text = "    " + healthManagementSystem.GetWHOPer();
						textEdit_DiagResultX.Text = healthManagementSystem.GetX();
						if ( textEdit_DiagResultWHO.Text.Replace(" ","").Equals("") )
							MessageBox.Show("该幼儿身高不足78cm或大于138cm,不适合做肥胖儿评测以及营养诊断！");
						textEdit_DiagResultNut.Text = "  " + healthManagementSystem.GetNut();
					}
					else
						MessageBox.Show(healthManagementSystem.GetRtnMsg());
				}
			}
			else
				MessageBox.Show("请先载入小朋友后做数据分析！");

			simpleButton_HInputSave.PerformClick();
		}
		#endregion

		#region 地区标准
		private void comboBoxEdit_HInputRegion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( comboBoxEdit_HInputRegion.SelectedItem.ToString().Equals("上海标准") )
			{
				inputNationalRegion = false;
				comboBoxEdit_HInputStd.Enabled = true;

				textEdit_DiagHeight.Text = string.Empty;
				textEdit_DiagWeight.Text = string.Empty;
				memoEdit_DiagRemark.Text = string.Empty;

				ClearEstimation();
			}
			else
			{
				inputNationalRegion = true;
				comboBoxEdit_HInputStd.Enabled = false;

				textEdit_DiagHeight.Text = string.Empty;
				textEdit_DiagWeight.Text = string.Empty;
				memoEdit_DiagRemark.Text = string.Empty;

				ClearEstimation();
			}

		}
		#endregion

		#region 保存
		private void simpleButton_HInputSave_Click(object sender, System.EventArgs e)
		{		
//			string message = "是否确认保存这些数据？";
//			string caption = "消息提示框!";
//			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
//			if ( messageResult == DialogResult.Yes )
//			{
				if ( !healthManagementSystem.SetShowAge(textEdit_DiagResultAge.Text).Equals("ok") )
				{
					MessageBox.Show(healthManagementSystem.SetShowAge(textEdit_DiagResultAge.Text));
					return;
				}

				healthManagementSystem.SetHeightAnaly(textEdit_DiagResultHeight.Text);
				healthManagementSystem.SetWeightAnaly(textEdit_DiagResultWeight.Text);
				healthManagementSystem.SetWhoAnaly(textEdit_DiagResultWHO.Text);
				healthManagementSystem.SetNutAnaly(textEdit_DiagResultNut.Text);
				healthManagementSystem.SetRemark(memoEdit_DiagRemark.Text);

				healthManagementSystem.SetDate(dateEdit_DiagCheckDate.DateTime.Date.ToString("yyyy-MM-dd"));
				healthManagementSystem.SetStuID(textEdit_DiagCheckBindingID.Text);

				if ( !healthManagementSystem.SetHeight(textEdit_DiagHeight.Text).Equals("ok") )
				{
					MessageBox.Show(healthManagementSystem.SetHeight(textEdit_DiagHeight.Text));
					return;
				}
				if ( !healthManagementSystem.SetWeight(textEdit_DiagWeight.Text).Equals("ok") )
				{
					MessageBox.Show(healthManagementSystem.SetWeight(textEdit_DiagWeight.Text));
					return;
				}

				if ( inputNationalRegion )
				{
					healthManagementSystem.SetNchsUnderWeight(textEdit_DiagResultUnderWeight.Text);
					healthManagementSystem.SetNchsStunting(textEdit_DiagResultStunting.Text);
					healthManagementSystem.SetNchsWasting(textEdit_DiagResultWasting.Text);

					int result = healthManagementSystem.InsertNchsHealthAnalysis();

					if ( result > 0 ) 
					{
						//MessageBox.Show("保存完毕！");
					}
					else if ( result <= 0 && result > -2 ) MessageBox.Show("记录存在，若本记录是有效数据，请做修改！");
					else MessageBox.Show("系统出错，请检查网络或重启后重试！！");
				}
				else
				{
					healthManagementSystem.SetStd(isCityStd);
					healthManagementSystem.SetHeightWeightAnaly(textEdit_DiagResultHeightWeight.Text.Trim());
					healthManagementSystem.SetWhoPerAnaly(textEdit_DiagResultWHOPer.Text);
					healthManagementSystem.SetX(textEdit_DiagResultX.Text);

					int result = healthManagementSystem.InsertHealthAnaly();

					if ( result > 0 ) MessageBox.Show("保存完毕！");
					else if ( result <= 0 && result > -2 ) MessageBox.Show("记录存在，若本记录是有效数据，请做修改！");
					else MessageBox.Show("系统出错，请检查网络或重启后重试！！");
				}
//			}
		}
		#endregion

		#region 修改
		private void simpleButton_HInputModify_Click(object sender, System.EventArgs e)
		{
			string message = "是否确认修改这些数据？";
			string caption = "消息提示框!";
			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult == DialogResult.Yes )
			{
				if ( !healthManagementSystem.SetShowAge(textEdit_DiagResultAge.Text).Equals("ok") )
				{
					MessageBox.Show(healthManagementSystem.SetShowAge(textEdit_DiagResultAge.Text));
					return;
				}
				healthManagementSystem.SetHeightAnaly(textEdit_DiagResultHeight.Text);
				healthManagementSystem.SetWeightAnaly(textEdit_DiagResultWeight.Text);
				healthManagementSystem.SetWhoAnaly(textEdit_DiagResultWHO.Text);
				healthManagementSystem.SetNutAnaly(textEdit_DiagResultNut.Text);
				healthManagementSystem.SetRemark(memoEdit_DiagRemark.Text);
				if ( !healthManagementSystem.SetHeight(textEdit_DiagHeight.Text).Equals("ok") )
				{
					MessageBox.Show(healthManagementSystem.SetHeight(textEdit_DiagHeight.Text));
					return;
				}
				if ( !healthManagementSystem.SetWeight(textEdit_DiagWeight.Text).Equals("ok") )
				{
					MessageBox.Show(healthManagementSystem.SetWeight(textEdit_DiagWeight.Text));
					return;
				}
				healthManagementSystem.SetDate(dateEdit_DiagCheckDate.DateTime.Date.ToString("yyyy-MM-dd"));
				healthManagementSystem.SetStuID(textEdit_DiagCheckBindingID.Text);

				if ( inputNationalRegion )
				{
					healthManagementSystem.SetNchsUnderWeight(textEdit_DiagResultUnderWeight.Text);
					healthManagementSystem.SetNchsStunting(textEdit_DiagResultStunting.Text);
					healthManagementSystem.SetNchsWasting(textEdit_DiagResultWasting.Text);
					
					int result = healthManagementSystem.UpdateNchsHealthAnalysis();

					if ( result > 0 ) MessageBox.Show("修改完毕！");
					else if ( result == 0 ) MessageBox.Show("指定记录不存在，请先保存诊断！");
					else MessageBox.Show("系统出错，请检查网络或重启后重试！！");

				}
				else
				{
					healthManagementSystem.SetStd(isCityStd);

					int result = healthManagementSystem.UpdateHealthAnaly();

					if ( result > 0 ) MessageBox.Show("修改完毕！");
					else if ( result == 0 ) MessageBox.Show("指定记录不存在，请先保存诊断！");
					else MessageBox.Show("系统出错，请检查网络或重启后重试！！");
				}

				simpleButton_HInputModify.Enabled = false;
			}
		}
		#endregion

		#region 删除
		private void simpleButton_HInputDelete_Click(object sender, System.EventArgs e)
		{
			string message = "是否确认删除这些数据？";
			string caption = "消息提示框!";
			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult == DialogResult.Yes )
			{
				healthManagementSystem.SetStuID(textEdit_DiagCheckBindingID.Text);
				healthManagementSystem.SetDate(dateEdit_DiagCheckDate.DateTime.Date.ToString("yyyy-MM-dd"));

				if ( inputNationalRegion )
				{
					int result = healthManagementSystem.DeleteNchsHealthAnalysis();
					 
					if ( result > 0 ) MessageBox.Show("删除完毕！");
					else MessageBox.Show("系统出错，请检查网络或重试！");
				}
				
				else
				{
					int result = healthManagementSystem.DeleteHealthAnaly();

					if ( result > 0 ) MessageBox.Show("删除完毕！");
					else MessageBox.Show("系统出错，请检查网络或重试！");
				}

				textEdit_DiagHeight.Text = "";
				textEdit_DiagWeight.Text = "";
				memoEdit_DiagRemark.Text = "";
				
				ClearEstimation();
			}
		}
		#endregion

		#region 区域评测标准选择
		private void comboBoxEdit_HInputStd_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( comboBoxEdit_HInputStd.SelectedItem.ToString().Equals("市区标准") )
				isCityStd = true;
			else
				isCityStd = false;
		}
		#endregion 

		#region 历史记录显示清空
		private void gridView6_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			textEdit_DiagHeight.Text = "";
			textEdit_DiagWeight.Text = "";
			memoEdit_DiagRemark.Text = "";

			ClearEstimation();
		}
		#endregion

		private void ClearEstimation()
		{
			textEdit_DiagResultHeight.Text = "";
			textEdit_DiagResultAge.Text = "";
			textEdit_DiagResultWeight.Text = "";
			textEdit_DiagResultWHO.Text = "";
			textEdit_DiagResultNut.Text = "";
			textEdit_DiagResultUnderWeight.Text = "";
			textEdit_DiagResultStunting.Text = "";
			textEdit_DiagResultWasting.Text = "";
			textEdit_DiagResultHeightWeight.Text = "";
		}

		private void HealthTextDataBinding(string getGrade,string getClass,string getName,string getNumber,string getGender)
		{
			DataSet dsStuForHealth = healthManagementSystem.GetStuForHealth(getGrade,getClass,getName,getNumber,getGender);
			gridControl_HInputStu.DataSource = dsStuForHealth.Tables[0];
			dataNavigator_HInputNav.DataSource = dsStuForHealth.Tables[0];
			
			textEdit_DiagCheckName.DataBindings.Add("EditValue",dsStuForHealth.Tables[0],"info_stuName");
			textEdit_DiagCheckGender.DataBindings.Add("EditValue",dsStuForHealth.Tables[0],"info_stuGender");
			textEdit_DiagCheckBindingID.DataBindings.Add("EditValue",dsStuForHealth.Tables[0],"info_stuID");
			textEdit_HInputBirthday.DataBindings.Add("EditValue",dsStuForHealth.Tables[0],"info_stuBirthday");
		}

		private void UnHealthTextDataBinding()
		{
			textEdit_DiagCheckName.DataBindings.Clear();
			textEdit_DiagCheckGender.DataBindings.Clear();
			textEdit_DiagCheckBindingID.DataBindings.Clear();
			textEdit_HInputBirthday.DataBindings.Clear();
		}

		#endregion

		#region 健康检测输出

		private void comboBoxEdit_HOutputGrade_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			comboBoxEdit_HOutputClass.Properties.Items.Clear();
			comboBoxEdit_HOutputClass.Properties.Items.AddRange(new object[]{"全部"});
			comboBoxEdit_HOutputClass.SelectedItem = "全部";
			if(getStuInfoByCondition.getGradeInfo(comboBoxEdit_HOutputGrade.SelectedItem.ToString(),"").Tables[0].Rows.Count > 0)
			{
				//根据年级选择获取年级编号
				getOutputGrade = getStuInfoByCondition.getGradeInfo(
					comboBoxEdit_HOutputGrade.SelectedItem.ToString(),"").Tables[0].Rows[0][0].ToString();
				foreach(DataRow getClassList in getStuInfoByCondition.getClassInfo("","",
					getOutputGrade).Tables[0].Rows)
				{
					comboBoxEdit_HOutputClass.Properties.Items.AddRange(
						new object[]{getClassList[1].ToString()});
				}
			}	

			if ( comboBoxEdit_HOutputGrade.SelectedItem.ToString().Equals("全部") )
			{
				getOutputGrade = "";
				getOutputClass = "";
			}

			HOutputTextDataBinding();
		}

		private void comboBoxEdit_HOutputClass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( comboBoxEdit_HOutputClass.SelectedItem.ToString().Equals("全部") )
				getOutputClass = "";
			else
				getOutputClass = getStuInfoByCondition.getClassInfo(
					comboBoxEdit_HOutputClass.SelectedItem.ToString(),"","").Tables[0].Rows[0][0].ToString();

			HOutputTextDataBinding();
		}

		private void textEdit_HOutputName_EditValueChanged(object sender, System.EventArgs e)
		{
			getOutputName = textEdit_HOutputName.Text;
			HOutputTextDataBinding();
		}

		private void textEdit_HOutputNumber_EditValueChanged(object sender, System.EventArgs e)
		{
			getOutputNumber = textEdit_HOutputNumber.Text;
			HOutputTextDataBinding();
		}

		private void comboBoxEdit_HOutputGender_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( comboBoxEdit_HOutputGender.SelectedItem.ToString().Equals("全部") )
			{
				getOutputGender = "";
				HOutputTextDataBinding();
			}
			else
			{
				getOutputGender = comboBoxEdit_HOutputGender.SelectedItem.ToString();
				HOutputTextDataBinding();
			}
		}

		private void comboBoxEdit_HOutputRegion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( comboBoxEdit_HOutputRegion.SelectedItem.ToString().Equals("上海标准") )
			{
				HealthAnalysisStandard(false);
			}
			else
			{
				HealthAnalysisStandard(true);
			}
		}

		private void comboBoxEdit_HOutputAge_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( comboBoxEdit_HOutputAge.SelectedItem.ToString().Equals("全部"))
			{
				getOutputAge = "";
				HOutputTextDataBinding();
			}
			else
			{
				getOutputAge = comboBoxEdit_HOutputAge.SelectedItem.ToString().Substring(0,1);
				HOutputTextDataBinding();
			}
		}

		private void comboBoxEdit_HOutputType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( comboBoxEdit_HOutputType.SelectedIndex == 0 )
			{
				getOutputType = "";
				comboBoxEdit_HOutputResult.SelectedItem = "全部";
				HOutputTextDataBinding();
			}
			else if ( comboBoxEdit_HOutputType.SelectedIndex == 1 || comboBoxEdit_HOutputType.SelectedIndex == 2 )
			{
				getOutputType = comboBoxEdit_HOutputType.SelectedItem.ToString();
				comboBoxEdit_HOutputResult.Properties.Items.Clear();
				comboBoxEdit_HOutputResult.Properties.Items.AddRange(new object[]{ "全部","<p3","p3-10","p10-20","p20-50","p50-80","p80-97",">p97" });
				comboBoxEdit_HOutputResult.SelectedItem = "全部";
				HOutputTextDataBinding();
			}
			else if ( comboBoxEdit_HOutputType.SelectedIndex == 3 )
			{
				getOutputType = comboBoxEdit_HOutputType.SelectedItem.ToString();
				comboBoxEdit_HOutputResult.Properties.Items.Clear();
				comboBoxEdit_HOutputResult.Properties.Items.AddRange(new object[]{ "全部","正常","超重","轻度肥胖","中度肥胖","重度肥胖" });
				comboBoxEdit_HOutputResult.SelectedItem = "全部";
				HOutputTextDataBinding();
			}
			else
			{
				getOutputType = comboBoxEdit_HOutputType.SelectedItem.ToString();
				comboBoxEdit_HOutputResult.Properties.Items.Clear();
				comboBoxEdit_HOutputResult.Properties.Items.AddRange(new object[]{ "全部","营养正常","轻度营养不良","中度营养不良" });
				comboBoxEdit_HOutputResult.SelectedItem = "全部";
				HOutputTextDataBinding();
			}
		}

		private void comboBoxEdit_HOutputResult_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( comboBoxEdit_HOutputResult.SelectedItem.ToString().Equals("全部"))
				getOutputResult = "";
			else
				getOutputResult = comboBoxEdit_HOutputResult.SelectedItem.ToString();

			HOutputTextDataBinding();
		}

		private void simpleButton_HOutputPrint_Click(object sender, System.EventArgs e)
		{
			if ( outputNationalRegion )
			{
				if ( advBandedGridView2.RowCount > 0 )
				{
					MessageBox.Show("您已经选择了生成个人评价表，系统将优先生成，如要生成统计表，请另外指定再生成一次！");

					string savePath;

					if ( (bool)checkEdit_HOutputPrintType4th.EditValue )
					{
						if ( getOutputGrade.Equals("") ) MessageBox.Show("个人评价表生成数量较多,最大范围只适合做班级统计!");
						else
						{
							if ( getOutputClass.Equals("") ) MessageBox.Show("个人评价表生成数量较多,最大范围只适合做班级统计!");
							else
							{
								saveFileDialog_Report.Title = "体格评价个人表";
					
								if ( saveFileDialog_Report.ShowDialog() != DialogResult.OK )
									return;

								savePath = saveFileDialog_Report.FileName;

								MessageBox.Show("即将进行指定数据分析，分析时间长短视电脑性能而定，按“确定”之后请稍候！");

								healthManagementPrintSystem.PrintNchsHealthPersonal(getOutputClass,getOutputName,getOutputNumber,dsHealthOutput,
									dateEdit_HOutputBegDate.DateTime.Date.ToString("yyyy-MM-dd"),dateEdit_HOutputEndDate.DateTime.Date.ToString("yyyy-MM-dd"),savePath,
									healthManagementSystem.GetTeaName(Thread.CurrentPrincipal.Identity.Name));

								MessageBox.Show("报表生成完毕！");
		
							}
						}
					}
					else
					{
						saveFileDialog_Report.Filter = "Excel文件|*.xls";
						saveFileDialog_Report.Title = "体格评价统计表";

						if ( saveFileDialog_Report.ShowDialog() != DialogResult.OK )
							return;

						savePath = saveFileDialog_Report.FileName;
					
						MessageBox.Show("即将进行指定数据分析，分析时间长短视电脑性能而定，按“确定”之后请稍候！");

						healthManagementPrintSystem.PrintNchsHealthSummary((bool)checkEdit_HOutputPrintType1st.EditValue,
							(bool)checkEdit_HOutputPrintType2nd.EditValue,
							getOutputGrade,getOutputClass,getOutputName,getOutputNumber,dsHealthOutput,
							dateEdit_HOutputBegDate.DateTime.Date.ToString("yyyy-MM-dd"),dateEdit_HOutputEndDate.DateTime.Date.ToString("yyyy-MM-dd"),savePath);

						MessageBox.Show("报表生成完毕！");
					}
				}
				else
					MessageBox.Show("请先生成数据！");
			}
			else
			{
				if ( advBandedGridView1.RowCount > 0 )
				{
					string savePath;
					saveFileDialog_Report.Filter = "Excel文件|*.xls";

					if ( saveFileDialog_Report.ShowDialog() != DialogResult.OK )
						return;

					savePath = saveFileDialog_Report.FileName;

					MessageBox.Show("即将进行指定数据分析，分析时间长短视电脑性能而定，按“确定”之后请稍候！");
		
					healthManagementPrintSystem.PrintHealth((bool)checkEdit_HOutputPrintType1st.EditValue,
						(bool)checkEdit_HOutputPrintType2nd.EditValue,(bool)checkEdit_HOutputPrintType3rd.EditValue,
						getOutputGrade,getOutputClass,getOutputName,getOutputNumber,dsHealthOutput,
						dateEdit_HOutputBegDate.DateTime.Date.ToString("yyyy-MM-dd"),dateEdit_HOutputEndDate.DateTime.Date.ToString("yyyy-MM-dd"),savePath);

					MessageBox.Show("生成完毕！");
				}
				else
					MessageBox.Show("请先生成数据！");
			}
		}

		private void simpleButton_HOutputSearch_Click(object sender, System.EventArgs e)
		{
			if ( dateEdit_HOutputBegDate.DateTime.Date > dateEdit_HOutputEndDate.DateTime.Date )
				MessageBox.Show("查询开始时间不应该大于查询结束时间！");
			else
				HOutputTextDataBinding();
		}

		private void HOutputTextDataBinding()
		{
			healthManagementSystem.SetGrade(getOutputGrade);
			healthManagementSystem.SetClass(getOutputClass);
			healthManagementSystem.SetName(getOutputName);
			healthManagementSystem.SetNumber(getOutputNumber);
			healthManagementSystem.SetGender(getOutputGender);
			healthManagementSystem.SetBegDate(dateEdit_HOutputBegDate.DateTime.Date.ToString("yyyy-MM-dd"));
			healthManagementSystem.SetEndDate(dateEdit_HOutputEndDate.DateTime.Date.ToString("yyyy-MM-dd"));

			if ( !outputNationalRegion )
			{
				healthManagementSystem.SetAge(getOutputAge);
				healthManagementSystem.SetType(getOutputType);
				healthManagementSystem.SetResult(getOutputResult);
				dsHealthOutput = healthManagementSystem.GetHealthOutput();
				gridControl_HOutputGridShow.DataSource = dsHealthOutput.Tables[0];
			}
			else
			{
				dsHealthOutput = healthManagementSystem.GetNchsHealthOutput();
				gridControl_HOutputNchsGrid.DataSource = dsHealthOutput.Tables[0];
			}	
		}

		private void HealthAnalysisStandard(bool isNchsStandard)
		{
			if (!isNchsStandard)
			{
				gridControl_HOutputGridShow.Visible = true;
				gridControl_HOutputNchsGrid.Visible = false;
				comboBoxEdit_HOutputAge.Enabled = true;
				comboBoxEdit_HOutputType.Enabled = true;
				comboBoxEdit_HOutputResult.Enabled = true;
				checkEdit_HOutputPrintType3rd.Enabled = true;
				checkEdit_HOutputPrintType4th.Enabled  = false;
				outputNationalRegion = false;
			}
			else
			{
				gridControl_HOutputGridShow.Visible = false;
				gridControl_HOutputNchsGrid.Visible = true;
				comboBoxEdit_HOutputAge.Enabled = false;
				comboBoxEdit_HOutputType.Enabled = false;
				comboBoxEdit_HOutputResult.Enabled = false;
				checkEdit_HOutputPrintType3rd.Enabled = false;
				checkEdit_HOutputPrintType4th.Enabled  = true;
				outputNationalRegion = true;
			}
		}

		#endregion

		#region 健康及全日观察
		private void gridControl_WatchStuList_DoubleClick(object sender, System.EventArgs e)
		{
			if ( Thread.CurrentPrincipal.Identity.Name.ToLower() != "admin" )
			{
				MorningRecEnabled();
				MorningRecClear();
				WholeDayWatchTextUnDataBinding();

				simpleButton_WatchHandle.Enabled = true;
				groupControl_WatchStuList.Visible = false;
				groupControl_WatchMorningRec.Visible = true;

				if ( gridView7.RowCount > 0 )
				{
					textEdit_WatchMorningName.Text = gridView7.GetDataRow(gridView7.GetSelectedRows()[0])[0].ToString();
					textEdit_WatchMorningNumber.Text = gridView7.GetDataRow(gridView7.GetSelectedRows()[0])[1].ToString();
				}
			}
		}

		private void gridControl_WatchRecList_DoubleClick(object sender, System.EventArgs e)
		{
			if ( Thread.CurrentPrincipal.Identity.Name.ToLower() != "admin" )
			{
				MorningRecDisabled();
		
				simpleButton_WatchHandle.Enabled = true;
				groupControl_WatchMorningRec.Visible = true;
				groupControl_WatchWholeDay.Visible = true;
				groupControl_WatchRecList.Visible = false;
				groupControl_WatchStuList.Visible = false;

				if ( gridView8.RowCount > 0 )
					healthManagementSystem.SetWatchDate(gridView8.GetDataRow(gridView8.GetSelectedRows()[0])["observeTime"].ToString());
				else
					simpleButton_WatchHandle.Enabled = true;
			}
		}		

		private void comboBoxEdit_WatchGrade_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			comboBoxEdit_WatchClass.Properties.Items.Clear();
			comboBoxEdit_WatchClass.Properties.Items.AddRange(new object[]{"全部"});
			comboBoxEdit_WatchClass.SelectedItem = "全部";
			if(getStuInfoByCondition.getGradeInfo(comboBoxEdit_WatchGrade.SelectedItem.ToString(),"").Tables[0].Rows.Count > 0)
			{
				//根据年级选择获取年级编号
				getWatchGrade = getStuInfoByCondition.getGradeInfo(
					comboBoxEdit_WatchGrade.SelectedItem.ToString(),"").Tables[0].Rows[0][0].ToString();
				foreach(DataRow getClassList in getStuInfoByCondition.getClassInfo("","",
					getWatchGrade).Tables[0].Rows)
				{
					comboBoxEdit_WatchClass.Properties.Items.AddRange(
						new object[]{getClassList[1].ToString()});
				}
			}	

			if ( comboBoxEdit_WatchGrade.SelectedItem.ToString().Equals("全部") )
			{
				getWatchGrade = "";
				getWatchClass = "";
			}

			WatchTextDataBinding();
			WholeDayWatchTextUnDataBinding();
			WholeDayWatchTextDataBinding();
		}

		private void comboBoxEdit_WatchClass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( comboBoxEdit_WatchClass.SelectedItem.ToString().Equals("全部") )
				getWatchClass = "";
			else
				getWatchClass = getStuInfoByCondition.getClassInfo(
					comboBoxEdit_WatchClass.SelectedItem.ToString(),"","").Tables[0].Rows[0][0].ToString();

			WatchTextDataBinding();
			WholeDayWatchTextUnDataBinding();
			WholeDayWatchTextDataBinding();
		}

		private void textEdit_WatchName_EditValueChanged(object sender, System.EventArgs e)
		{
			getWatchName = textEdit_WatchName.Text;
			WatchTextDataBinding();
			WholeDayWatchTextUnDataBinding();
			WholeDayWatchTextDataBinding();
		}	

		private void textEdit_WatchNumber_EditValueChanged(object sender, System.EventArgs e)
		{
			getWatchNumber = textEdit_WatchNumber.Text;
			WatchTextDataBinding();
			WholeDayWatchTextUnDataBinding();
			WholeDayWatchTextDataBinding();
		}

		private void comboBoxEdit_WatchState_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( comboBoxEdit_WatchState.SelectedItem.ToString().Equals("全部") )
				getWatchState = "";
			else
				getWatchState = comboBoxEdit_WatchState.SelectedItem.ToString();
			WatchTextDataBinding();
		}

		private void simpleButton_WatchBack_Click(object sender, System.EventArgs e)
		{
			simpleButton_WatchHandle.Enabled = false;
			groupControl_WatchStuList.Visible = true;
			groupControl_WatchMorningRec.Visible = false;
			groupControl_WatchRecList.Visible = true;
			groupControl_WatchWholeDay.Visible = false;

			WatchTextDataBinding();
			WholeDayWatchTextUnDataBinding();
			WholeDayWatchTextDataBinding();
		}

		private void simpleButton_WatchHandle_Click(object sender, System.EventArgs e)
		{
			string message = "是否确认保存这些数据？";
			string caption = "消息提示框!";
			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult == DialogResult.Yes )
			{
				if ( !groupControl_WatchWholeDay.Visible )
				{
					
					healthManagementSystem.SetWatchName(textEdit_WatchMorningName.Text);
					healthManagementSystem.SetWatchNumber(textEdit_WatchMorningNumber.Text);
					healthManagementSystem.SetWatchHeat(comboBoxEdit_WatchMorningHeat.SelectedItem.ToString());
					healthManagementSystem.SetWatchSpirit(comboBoxEdit_WatchMorningSpirit.SelectedItem.ToString());
					healthManagementSystem.SetWatchMouth(comboBoxEdit_WatchMorningMouth.SelectedItem.ToString());
					healthManagementSystem.SetWatchSkin(comboBoxEdit_WatchMorningSkin.SelectedItem.ToString());
					healthManagementSystem.SetWatchOState(textEdit_WatchMorningOState.Text);
					healthManagementSystem.SetWatchTreat(textEdit_WatchMorningTreat.Text);
					healthManagementSystem.SetWatchDate(DateTime.Now.Date.ToString("yyyy-MM-dd"));
//					healthManagementSystem.SetRecID(0);
					healthManagementSystem.SetTeacherSign(healthManagementSystem.GetTeaName(Thread.CurrentPrincipal.Identity.Name));
					int rlt = healthManagementSystem.SaveMorningWatch(true);
					if ( rlt > 0 )
						MessageBox.Show("保存完毕！");
					else if ( rlt == -2 )
						MessageBox.Show("该记录由另外一位教师添加，您无法修改该记录！");
					else
						MessageBox.Show("保存中出现错误，请检查网络或重启后重试！");
					
				}
				
				else
				{
					healthManagementSystem.SetWatchName(textEdit_WatchMorningName.Text);
					healthManagementSystem.SetWatchNumber(textEdit_WatchMorningNumber.Text);
					healthManagementSystem.SetWatchHeat(comboBoxEdit_WatchMorningHeat.SelectedItem.ToString());
					healthManagementSystem.SetWatchSpirit(comboBoxEdit_WatchMorningSpirit.SelectedItem.ToString());
					healthManagementSystem.SetWatchMouth(comboBoxEdit_WatchMorningMouth.SelectedItem.ToString());
					healthManagementSystem.SetWatchSkin(comboBoxEdit_WatchMorningSkin.SelectedItem.ToString());
					healthManagementSystem.SetWatchOState(textEdit_WatchMorningOState.Text);
					healthManagementSystem.SetWatchTreat(textEdit_WatchMorningTreat.Text);
					healthManagementSystem.SetDailyAppetite(comboBoxEdit_WatchWholeDayAppetite.SelectedItem.ToString());
					healthManagementSystem.SetDailyCough(comboBoxEdit_WatchWholeDayCough.SelectedItem.ToString());
					healthManagementSystem.SetDailyCtrlAct((bool)checkEdit_WatchWholeDayCtrAct.EditValue);
					healthManagementSystem.SetDailyElse(textEdit_WatchWholeDayElse.Text);
					healthManagementSystem.SetDailyHeat((bool)checkEdit_WatchWholeDayHeat.EditValue);
					healthManagementSystem.SetDailyLife((bool)checkEdit_WatchWholeDayLifeAttention.EditValue);
					healthManagementSystem.SetDailyMovement(comboBoxEdit_WatchWholeDayMovement.SelectedItem.ToString());
					healthManagementSystem.SetDailySeafood((bool)checkEdit_WatchWholeDayCtrSeafood.EditValue);
					healthManagementSystem.SetDailySleep(comboBoxEdit_WatchWholeDaySleep.SelectedItem.ToString());
					healthManagementSystem.SetDailySpirit(comboBoxEdit_WatchWholeDaySpirit.SelectedItem.ToString());
					healthManagementSystem.SetDailyStool(comboBoxEdit_WatchWholeDayStool.SelectedItem.ToString());

					//教师签名
					healthManagementSystem.SetTeacherSign(healthManagementSystem.GetTeaName(Thread.CurrentPrincipal.Identity.Name));

					if ( healthManagementSystem.SaveMorningWatch(false) > 0 )
						MessageBox.Show("保存完毕！");
					else 
						MessageBox.Show("保存中出现错误，请检查网络或重启后重试！");
				}
			}
			simpleButton_WatchBack.PerformClick();
		}

		private void simpleButton_WatchDelete_Click(object sender, System.EventArgs e)
		{
			string message = "是否确认删除选定的数据？";
			string caption = "消息提示框!";
			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult == DialogResult.Yes )
			{
				if ( gridView8.RowCount != 0 )
				{
					if ( healthManagementSystem.DeleteWholeDayWatch(gridView8.GetDataRow(gridView8.GetSelectedRows()[0])[0].ToString(),
						gridView8.GetDataRow(gridView8.GetSelectedRows()[0])[20].ToString()) > 0 )
						MessageBox.Show("删除完毕！");
					else
						MessageBox.Show("删除中出现错误，请检查网络或重启后重试！");
				}
				else
					MessageBox.Show("请在幼儿观察列表内选中您所要删除的小朋友的记录！");
			}
			simpleButton_WatchBack.PerformClick();
		}

		private void simpleButton_WatchReport_Click(object sender, System.EventArgs e)
		{
			if ( gridView8.RowCount > 0 )
			{
				string savePath;
				saveFileDialog_Report.Filter = "Excel文件|*.xls";

				if ( saveFileDialog_Report.ShowDialog() != DialogResult.OK )
					return;

				savePath = saveFileDialog_Report.FileName;

				MessageBox.Show("即将进行指定数据分析，分析时间长短视电脑性能而定，按“确定”之后请稍候！");

				healthManagementPrintSystem.PrintAbnormalRecord(dsWholeDayWatch,savePath);

				MessageBox.Show("报表生成完毕！");
			}
			else
				MessageBox.Show("请先生成数据后打印！");
		}

		private void simpleButton_WatchHelp_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show(gridView8.GetDataRow(gridView8.GetSelectedRows()[0])["observeTime"].ToString());
		}

		private void simpleButton_WatchSearch_Click(object sender, System.EventArgs e)
		{
			if ( dateEdit_WatchBegDate.DateTime.Date > dateEdit_WatchEndDate.DateTime.Date )
				MessageBox.Show("查询开始时间不应该大于查询结束时间");
			else
			{
				WatchTextDataBinding();
				WholeDayWatchTextUnDataBinding();
				WholeDayWatchTextDataBinding();
			}
		}

		private void WatchTextDataBinding()
		{
			DataSet dsStuEnterList = healthManagementSystem.GetStuEnterList(getWatchGrade,getWatchClass,getWatchName,
				getWatchNumber,DateTime.Now.Date,getWatchState);

			if ( Thread.CurrentPrincipal.IsInRole("班主任") )
			{
				if ( dsStuEnterList.Tables[0].Rows.Count > 0 )
				{
					foreach(DataRow matchRow in dsStuEnterList.Tables[0].Rows)
					{
						if ( !matchRow["info_className"].Equals(rolesSystem.GetRolesDuty(Convert.ToInt32(Thread.CurrentPrincipal.Identity.Name)).Tables[0].Rows[0][1].ToString()) )
							matchRow.Delete();
					}
				}
			}

			gridControl_WatchStuList.DataSource = dsStuEnterList.Tables[0];

		}

		private void WholeDayWatchTextDataBinding()
		{
			dsWholeDayWatch = healthManagementSystem.GetWholeDayWatch(getWatchGrade,getWatchClass,getWatchName,
				getWatchNumber,dateEdit_WatchBegDate.DateTime.Date.ToString("yyyy-MM-dd"),dateEdit_WatchEndDate.DateTime.Date.ToString("yyyy-MM-dd"));

			if ( Thread.CurrentPrincipal.IsInRole("班主任") )
			{
				if ( dsWholeDayWatch.Tables[0].Rows.Count > 0 )
				{
					foreach(DataRow matchRow in dsWholeDayWatch.Tables[0].Rows)
					{
						if ( !matchRow["info_className"].Equals(rolesSystem.GetRolesDuty(Convert.ToInt32(Thread.CurrentPrincipal.Identity.Name)).Tables[0].Rows[0][1].ToString()) )
							matchRow.Delete();
					}
				}
			}

			gridControl_WatchRecList.DataSource = dsWholeDayWatch.Tables[0];

			textEdit_WatchMorningName.DataBindings.Add("EditValue",dsWholeDayWatch.Tables[0],"stu_name");
			textEdit_WatchMorningNumber.DataBindings.Add("EditValue",dsWholeDayWatch.Tables[0],"stu_id");
			comboBoxEdit_WatchMorningHeat.DataBindings.Add("EditValue",dsWholeDayWatch.Tables[0],"morningReg_heat");
			comboBoxEdit_WatchMorningMouth.DataBindings.Add("EditValue",dsWholeDayWatch.Tables[0],"morningReg_mouth");
			comboBoxEdit_WatchMorningSkin.DataBindings.Add("EditValue",dsWholeDayWatch.Tables[0],"morningReg_skin");
			comboBoxEdit_WatchMorningSpirit.DataBindings.Add("EditValue",dsWholeDayWatch.Tables[0],"morningReg_spirit");
			textEdit_WatchMorningOState.DataBindings.Add("EditValue",dsWholeDayWatch.Tables[0],"morningReg_genearchTold");
			textEdit_WatchMorningTreat.DataBindings.Add("EditValue",dsWholeDayWatch.Tables[0],"morningReg_treat");
			comboBoxEdit_WatchWholeDayAppetite.DataBindings.Add("EditValue",dsWholeDayWatch.Tables[0],"dailyReg_appetite");
			comboBoxEdit_WatchWholeDayCough.DataBindings.Add("EditValue",dsWholeDayWatch.Tables[0],"dailyReg_cough");
			comboBoxEdit_WatchWholeDayMovement.DataBindings.Add("EditValue",dsWholeDayWatch.Tables[0],"dailyReg_movement");
			comboBoxEdit_WatchWholeDaySleep.DataBindings.Add("EditValue",dsWholeDayWatch.Tables[0],"dailyReg_sleep");
			comboBoxEdit_WatchWholeDaySpirit.DataBindings.Add("EditValue",dsWholeDayWatch.Tables[0],"dailyReg_spirit");
			comboBoxEdit_WatchWholeDayStool.DataBindings.Add("EditValue",dsWholeDayWatch.Tables[0],"dailyReg_stool");
			textEdit_WatchWholeDayElse.DataBindings.Add("EditValue",dsWholeDayWatch.Tables[0],"dailyReg_else");
			checkEdit_WatchWholeDayCtrAct.DataBindings.Add("EditValue",dsWholeDayWatch.Tables[0],"dailyReg_ctrlMoveTreat");
			checkEdit_WatchWholeDayCtrSeafood.DataBindings.Add("EditValue",dsWholeDayWatch.Tables[0],"dailyReg_seafoodTreat");
			checkEdit_WatchWholeDayHeat.DataBindings.Add("EditValue",dsWholeDayWatch.Tables[0],"dailyReg_measureHeat");
			checkEdit_WatchWholeDayLifeAttention.DataBindings.Add("EditValue",dsWholeDayWatch.Tables[0],"dailyReg_tendTreat");

		}

		private void WholeDayWatchTextUnDataBinding()
		{
			textEdit_WatchMorningName.DataBindings.Clear();
			textEdit_WatchMorningNumber.DataBindings.Clear();
			comboBoxEdit_WatchMorningHeat.DataBindings.Clear();
			comboBoxEdit_WatchMorningMouth.DataBindings.Clear();
			comboBoxEdit_WatchMorningSkin.DataBindings.Clear();
			comboBoxEdit_WatchMorningSpirit.DataBindings.Clear();
			textEdit_WatchMorningOState.DataBindings.Clear();
			textEdit_WatchMorningTreat.DataBindings.Clear();
			comboBoxEdit_WatchWholeDayAppetite.DataBindings.Clear();
			comboBoxEdit_WatchWholeDayCough.DataBindings.Clear();
			comboBoxEdit_WatchWholeDayMovement.DataBindings.Clear();
			comboBoxEdit_WatchWholeDaySleep.DataBindings.Clear();
			comboBoxEdit_WatchWholeDaySpirit.DataBindings.Clear();
			comboBoxEdit_WatchWholeDayStool.DataBindings.Clear();
			textEdit_WatchWholeDayElse.DataBindings.Clear();
			checkEdit_WatchWholeDayCtrAct.DataBindings.Clear();
			checkEdit_WatchWholeDayCtrSeafood.DataBindings.Clear();
			checkEdit_WatchWholeDayHeat.DataBindings.Clear();
			checkEdit_WatchWholeDayLifeAttention.DataBindings.Clear();
		}

		private void MorningRecClear()
		{
			comboBoxEdit_WatchMorningHeat.SelectedIndex = 0;
			comboBoxEdit_WatchMorningMouth.SelectedIndex = 0;
			comboBoxEdit_WatchMorningSkin.SelectedIndex = 0;
			comboBoxEdit_WatchMorningSpirit.SelectedIndex = 0;
			textEdit_WatchMorningOState.Text = "";
			textEdit_WatchMorningTreat.Text = "";
		}

		private void MorningRecEnabled()
		{
			comboBoxEdit_WatchMorningHeat.Enabled = true;
			comboBoxEdit_WatchMorningMouth.Enabled = true;
			comboBoxEdit_WatchMorningSkin.Enabled = true;
			comboBoxEdit_WatchMorningSpirit.Enabled = true;
			textEdit_WatchMorningOState.Enabled = true;
			textEdit_WatchMorningTreat.Enabled = true;
		}

		private void MorningRecDisabled()
		{
			comboBoxEdit_WatchMorningHeat.Enabled = false;
			comboBoxEdit_WatchMorningMouth.Enabled = false;
			comboBoxEdit_WatchMorningSkin.Enabled = false;
			comboBoxEdit_WatchMorningSpirit.Enabled = false;
			textEdit_WatchMorningOState.Enabled = false;
			textEdit_WatchMorningTreat.Enabled = false;
		}

		#endregion

		#region  服药登记
		private void comboBoxEdit_MedReg_Grade_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			comboBoxEdit_MedReg_Class.Properties.Items.Clear();
			comboBoxEdit_MedReg_Class.Properties.Items.AddRange(new object[]{"全部"});
			comboBoxEdit_MedReg_Class.SelectedItem = "全部";
			if(getStuInfoByCondition.getGradeInfo(comboBoxEdit_MedReg_Grade.SelectedItem.ToString(),"").Tables[0].Rows.Count > 0)
			{
				//根据年级选择获取年级编号
				getMedRegGrade = getStuInfoByCondition.getGradeInfo(
					comboBoxEdit_MedReg_Grade.SelectedItem.ToString(),"").Tables[0].Rows[0][0].ToString();
				foreach(DataRow getClassList in getStuInfoByCondition.getClassInfo("","",
					getMedRegGrade).Tables[0].Rows)
				{
					comboBoxEdit_MedReg_Class.Properties.Items.AddRange(
						new object[]{getClassList[1].ToString()});
				}
			}	

			if ( comboBoxEdit_MedReg_Grade.SelectedItem.ToString().Equals("全部") )
			{
				getMedRegGrade = "";
				getMedRegClass = "";
			}

			MedRegGridShow();
		}

		private void comboBoxEdit_MedReg_Class_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( comboBoxEdit_MedReg_Class.SelectedItem.ToString().Equals("全部") )
				getMedRegClass = "";
			else
				getMedRegClass = getStuInfoByCondition.getClassInfo(
					comboBoxEdit_MedReg_Class.SelectedItem.ToString(),"","").Tables[0].Rows[0][0].ToString();

			MedRegGridShow();
		}

		private void textEdit_MedReg_Name_EditValueChanged(object sender, System.EventArgs e)
		{
			getMedRegStuName = textEdit_MedReg_Name.Text;
			MedRegGridShow();
		}

		private void textEdit_MedReg_Number_EditValueChanged(object sender, System.EventArgs e)
		{
			getMedRegStuNumber = textEdit_MedReg_Number.Text;
			MedRegGridShow();
		}

		private void simpleButton_MedReg_Back_Click(object sender, System.EventArgs e)
		{
			groupControl_MedReg_MedCarrInfo.Visible = true;
			groupControl_MedReg_MedInfo.Visible = false;
			simpleButton_MedReg_Save.Enabled = false;
			simpleButton_MedReg_Modify.Enabled = false;
			simpleButton_MedReg_Save.Enabled = true;
			simpleButton_MedReg_Reg.Enabled = true;
		}

		private void simpleButton_MedReg_Reg_Click(object sender, System.EventArgs e)
		{
			string medInfo = string.Empty;
			string message = "是否确认保存诊断信息？";
			string caption = "消息提示框!";
			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult == DialogResult.Yes )
			{
				healthManagementSystem.SetDiagInfo(comboBoxEdit_MedReg_Diag.Text.ToString());
				healthManagementSystem.SetUpperSym(textEdit_MedReg_UpperSym.Text);
				healthManagementSystem.SetLungSym(textEdit_MedReg_LungSym.Text);
				healthManagementSystem.SetThroatSym(textEdit_MedReg_ThroatSym.Text);
				healthManagementSystem.SetEnteronSym(textEdit_MedReg_EnteronSym.Text);
				healthManagementSystem.SetAbdomenSym(textEdit_MedReg_AbdomenSym.Text);
				healthManagementSystem.SetSkinSym(textEdit_MedReg_SkinSym.Text);
				healthManagementSystem.SetFacialSym(textEdit_MedReg_FacialSym.Text);
				healthManagementSystem.SetElse(textEdit_MedReg_Else.Text);
				healthManagementSystem.SetRegDate(DateTime.Now);
				healthManagementSystem.SetStuNumber(dClickNum);

				//教师签名
				healthManagementSystem.SetTeacherSign(healthManagementSystem.GetTeaName(Thread.CurrentPrincipal.Identity.Name));
				for ( int i=0; i<listBoxControl_MedReg_MedCarrInfo.Items.Count; i++ )
					medInfo += listBoxControl_MedReg_MedCarrInfo.Items[i];
				healthManagementSystem.SetMedInfo(medInfo);

				if ( healthManagementSystem.SaveDiagResult() > 0 )
					MessageBox.Show("诊断登记完毕！");
				else
					MessageBox.Show("保存过程中出现位知错误，请检查网络或重启后重试！");
			}
		}

		private void simpleButton_MedReg_Ser_Click(object sender, System.EventArgs e)
		{
			MedRegGridShow();
		}

		private void simpleButton_MedReg_Save_Click(object sender, System.EventArgs e)
		{
			string message = "是否确认保存数据？";
			string caption = "消息提示框!";
			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult == DialogResult.Yes )
			{
				while ( true )
				{
					if ( textEdit_MedReg_MedName.Equals("")  )
					{
						MessageBox.Show("药名不应该为空！");
						break;
					}
					else
					{
						if ( textEdit_MedReg_MedName.Text.IndexOf(",") >= 0 || textEdit_MedReg_MedName.Text.IndexOf(";") >= 0
								|| textEdit_MedReg_MedName.Text.IndexOf("(") >= 0 || textEdit_MedReg_MedName.Text.IndexOf(")") >= 0)
						{
							MessageBox.Show("系统检测到您所输入的药名中包含非法字符,系统已经将字符: ,;()等视为保留字符，如有需要请更换！");
							break;
						}
						else
							healthManagementSystem.SetMedName(textEdit_MedReg_MedName.Text);
					}
					
					if ( textEdit_MedReg_MedType.Text.IndexOf(",") >= 0 || textEdit_MedReg_MedType.Text.IndexOf(";") >= 0 
							|| textEdit_MedReg_MedType.Text.IndexOf("(") >= 0 || textEdit_MedReg_MedType.Text.IndexOf(")") >= 0)
					{
						MessageBox.Show("系统检测到您所输入的药名中包含非法字符,系统已经将字符: ,;()等视为保留字符，如有需要请更换！");
						break;
					}
					else
						healthManagementSystem.SetMedType(textEdit_MedReg_MedType.Text);
					if ( textEdit_MedReg_MedTake.Text.IndexOf(",") >= 0 || textEdit_MedReg_MedTake.Text.IndexOf(";") >= 0 )
					{
						MessageBox.Show("系统检测到您所输入的药名中包含非法字符','或';'。该符号已经被系统占用，请更换符号！");
						break;
					}
					else
						healthManagementSystem.SetMedTake(textEdit_MedReg_MedTake.Text);
					try
					{
						healthManagementSystem.SetTaketimes((int)Convert.ToDouble(textEdit_MedReg_Taketimes.Text.Replace(" ","")));
					}
					catch
					{
						MessageBox.Show("服用次数应该为数字，如果输入小数系统将自动取整！");
						textEdit_MedReg_Taketimes.Text = "";
						break;
					}	

					int rtnInsert = healthManagementSystem.InsertMed();

					if ( rtnInsert > 0  )
						MessageBox.Show("保存完毕！");
					else if ( rtnInsert == 0 )
						MessageBox.Show("保存中出现未知错误，请检查网络或重启重试！");
					else
						MessageBox.Show("该药品已经存在，若服用剂量或次数不同，请修改！");
					break;
				}
			}

			groupControl_MedReg_MedInfo.Visible = false;
			groupControl_MedReg_MedCarrInfo.Visible = true;
			simpleButton_MealSave.Visible = false;
			MedInfoShow();

			simpleButton_MealSave.Enabled = false;
		}

		private void simpleButton_MedReg_Modify_Click(object sender, System.EventArgs e)
		{
			string message = "是否确认修改数据？";
			string caption = "消息提示框!";
			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult == DialogResult.Yes )
			{
				while ( true )
				{
					if ( textEdit_MedReg_MedName.Equals("") )
					{
						MessageBox.Show("药名不应该为空！");
						break;
					}
					else
						healthManagementSystem.SetMedName(textEdit_MedReg_MedName.Text);

					healthManagementSystem.SetMedType(textEdit_MedReg_MedType.Text);
					healthManagementSystem.SetMedTake(textEdit_MedReg_MedTake.Text);
					try
					{
						healthManagementSystem.SetTaketimes((int)Convert.ToDouble(textEdit_MedReg_Taketimes.Text.Replace(" ","")));
					}
					catch
					{
						MessageBox.Show("服用次数应该为数字，如果输入小数系统将自动取整！");
						textEdit_MedReg_Taketimes.Text = "";
						break;
					}	

					int rtnUpdate = healthManagementSystem.UpdateMed();

					if ( rtnUpdate > 0  )
						MessageBox.Show("修改完毕！");
					else if ( rtnUpdate == 0 )
						MessageBox.Show("修改中出现未知错误，请检查网络或重启重试！");
					else
						MessageBox.Show("该药品已经存在，若只是服用剂量或次数不同，请修改即可！");
					break;
				}
			}

			groupControl_MedReg_MedInfo.Visible = false;
			groupControl_MedReg_MedCarrInfo.Visible = true;
			simpleButton_MealSave.Visible = false;
			MedInfoShow();

			simpleButton_MedReg_Modify.Enabled = false;
		}

		private void simpleButton_MedReg_Help_Click(object sender, System.EventArgs e)
		{

		}

		private void gridControl_MedReg_StuList_DoubleClick(object sender, System.EventArgs e)
		{
			if ( Thread.CurrentPrincipal.Identity.Name.ToLower() != "admin" )
			{
				if ( gridView9.RowCount != 0 )
				{
					dClickNum = gridView9.GetDataRow(gridView9.GetSelectedRows()[0])[1].ToString();
			
					DiagInfoClear();

					DiagInfoShow();

					MedInfoShow();

					if ( listBoxControl_MedReg_MedInfo.Items.Count > 0 )
						listBoxControl_MedReg_MedInfo.SelectedIndex = 0;
				}
			}
					
		}

		private void listBoxControl_MedReg_MedInfo_DoubleClick(object sender, System.EventArgs e)
		{
			if ( Thread.CurrentPrincipal.Identity.Name.ToLower() != "admin" )
			{
				simpleButton_MedReg_MedCarrAdd.PerformClick();
			}
		}

		private void listBoxControl_MedReg_MedCarrInfo_DoubleClick(object sender, System.EventArgs e)
		{
			if ( Thread.CurrentPrincipal.Identity.Name.ToLower() != "admin" )
			{
				simpleButton_MedReg_MedCarrDel.PerformClick();
			}
		}

		private void listBoxControl_MedReg_MedInfo_SelectedValueChanged(object sender, System.EventArgs e)
		{
			if ( listBoxControl_MedReg_MedInfo.Items.Count != 0 )
			{
				if ( getMedInfoID == listBoxControl_MedReg_MedInfo.Items.Count )
					listBoxControl_MedReg_MedInfo.SelectedIndex = getMedInfoID - 1;

				listMedInfo = listBoxControl_MedReg_MedInfo.SelectedItem.ToString();
				if ( listMedInfo.IndexOf("(") != -1 )
				{
					getMedName = listMedInfo.Substring(0,listMedInfo.IndexOf("("));
					getMedCategory = listMedInfo.Substring(listMedInfo.IndexOf("(")+1,listMedInfo.Length-getMedName.Length-2);
					
				}
				else
				{
					getMedName = listBoxControl_MedReg_MedInfo.SelectedItem.ToString();
					getMedCategory = "";
				}
				getMedInfoID = listBoxControl_MedReg_MedInfo.SelectedIndex;
			}

			if ( listBoxControl_MedReg_MedInfo.Items.Count == 0 )
				simpleButton_MedReg_MedCarrAdd.Enabled = false;
		}

		private void listBoxControl_MedReg_MedCarrInfo_SelectedValueChanged(object sender, System.EventArgs e)
		{
			if ( listBoxControl_MedReg_MedCarrInfo.Items.Count != 0 )
			{
				if ( getMedCarrInfoID == listBoxControl_MedReg_MedCarrInfo.Items.Count )
					listBoxControl_MedReg_MedCarrInfo.SelectedIndex = getMedCarrInfoID - 1;

				listMedCarrInfo = listBoxControl_MedReg_MedCarrInfo.SelectedItem.ToString().Substring(0,
					listBoxControl_MedReg_MedCarrInfo.SelectedItem.ToString().IndexOf(","));

				getMedCarrInfoID = listBoxControl_MedReg_MedCarrInfo.SelectedIndex;
			}

			if ( listBoxControl_MedReg_MedCarrInfo.Items.Count == 0 )
				simpleButton_MedReg_MedCarrDel.Enabled = false;
		}

		private void listBoxControl_MedReg_MedInfo_Click(object sender, System.EventArgs e)
		{
			simpleButton_MedReg_MedCarrAdd.Enabled = true;

			if ( listBoxControl_MedReg_MedInfo.Items.Count != 0 )
			{
				if ( getMedInfoID == listBoxControl_MedReg_MedInfo.Items.Count )
					listBoxControl_MedReg_MedInfo.SelectedIndex = getMedInfoID - 1;

				listMedInfo = listBoxControl_MedReg_MedInfo.SelectedItem.ToString();
				if ( listMedInfo.IndexOf("(") != -1 )
				{
					getMedName = listMedInfo.Substring(0,listMedInfo.IndexOf("("));
					getMedCategory = listMedInfo.Substring(listMedInfo.IndexOf("(")+1,listMedInfo.Length-getMedName.Length-2);
					
				}
				else
				{
					getMedName = listBoxControl_MedReg_MedInfo.SelectedItem.ToString();
					getMedCategory = "";
				}
				getMedInfoID = listBoxControl_MedReg_MedInfo.SelectedIndex;
			}

			if ( listBoxControl_MedReg_MedInfo.Items.Count == 0 )
				simpleButton_MedReg_MedCarrAdd.Enabled = false;
		}

		private void listBoxControl_MedReg_MedCarrInfo_Click(object sender, System.EventArgs e)
		{
			simpleButton_MedReg_MedCarrDel.Enabled = true;

			if ( listBoxControl_MedReg_MedCarrInfo.Items.Count != 0 )
			{
				if ( getMedCarrInfoID == listBoxControl_MedReg_MedCarrInfo.Items.Count )
					listBoxControl_MedReg_MedCarrInfo.SelectedIndex = getMedCarrInfoID - 1;

				listMedCarrInfo = listBoxControl_MedReg_MedCarrInfo.SelectedItem.ToString().Substring(0,
					listBoxControl_MedReg_MedCarrInfo.SelectedItem.ToString().IndexOf(","));

				getMedCarrInfoID = listBoxControl_MedReg_MedCarrInfo.SelectedIndex;
			}

			if ( listBoxControl_MedReg_MedCarrInfo.Items.Count == 0 )
				simpleButton_MedReg_MedCarrDel.Enabled = false;
		}

		private void barButtonItem_MedReg_MedAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			simpleButton_MedReg_Reg.Enabled = false;

			groupControl_MedReg_MedCarrInfo.Visible = false;
			groupControl_MedReg_MedInfo.Visible = true;
				
			MedInfoClear();

			simpleButton_MedReg_Save.Enabled = true;
		}

		private void barButtonItem_MedReg_MedModify_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			simpleButton_MedReg_Reg.Enabled = false;

			if ( listBoxControl_MedReg_MedInfo.Items.Count > 0 )
			{
				DataSet dsMedCarrInfo = healthManagementSystem.GetMed(getMedName,getMedCategory);

				textEdit_MedReg_MedName.Text = getMedName;
				textEdit_MedReg_MedType.Text = getMedCategory;
				textEdit_MedReg_MedTake.Text = dsMedCarrInfo.Tables[0].Rows[0][3].ToString();
				textEdit_MedReg_Taketimes.Text = dsMedCarrInfo.Tables[0].Rows[0][4].ToString();
				healthManagementSystem.SetMedModifyID(Convert.ToInt32(dsMedCarrInfo.Tables[0].Rows[0][0]));

				groupControl_MedReg_MedCarrInfo.Visible = false;
				groupControl_MedReg_MedInfo.Visible = true;

				simpleButton_MedReg_Modify.Enabled = true;
			}
			else
				MessageBox.Show("没有药品记录，请先添加再修改！");
		}

		private void barButtonItem_MedReg_MedDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			string message = "是否确认删除数据？";
			string caption = "消息提示框!";
			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult == DialogResult.Yes )
			{
				int rtnDelete = healthManagementSystem.DeleteMed(getMedName,getMedCategory);
				if ( rtnDelete > 0 )
					MessageBox.Show("删除完毕！");
				else
					MessageBox.Show("修改中出现未知错误，请检查网络或重启重试！");
			}

			MedInfoShow();
		}

		private void simpleButton_MedReg_MedCarrAdd_Click(object sender, System.EventArgs e)
		{
			if ( Thread.CurrentPrincipal.Identity.Name.ToLower() != "admin" )
			{
				DataSet dsMedCarrInfo = healthManagementSystem.GetMed(getMedName,getMedCategory);

				listBoxControl_MedReg_MedCarrInfo.Items.AddRange(new object[]{ listMedInfo
																				 + "," + dsMedCarrInfo.Tables[0].Rows[0][3].ToString()
																				 + "," + dsMedCarrInfo.Tables[0].Rows[0][4].ToString()
																				 + ";"});
			
				listBoxControl_MedReg_MedInfo.Items.RemoveAt(getMedInfoID);
				listBoxControl_MedReg_MedCarrInfo.SelectedIndex = 0;

				simpleButton_MedReg_MedCarrAdd.Enabled = true;
			}
	
		}

		private void simpleButton_MedReg_MedCarrDel_Click(object sender, System.EventArgs e)
		{
			if ( Thread.CurrentPrincipal.Identity.Name.ToLower() != "admin" )
			{
				listBoxControl_MedReg_MedInfo.Items.AddRange(new object[]{ listMedCarrInfo });
				listBoxControl_MedReg_MedCarrInfo.Items.RemoveAt(getMedCarrInfoID);
				listBoxControl_MedReg_MedInfo.SelectedIndex = 0;
			}
			
		}

		private void MedInfoShow()
		{
			dsMedInfo = healthManagementSystem.GetMed("","");

			listBoxControl_MedReg_MedInfo.Items.Clear();
			foreach(DataRow medRow in healthManagementSystem.GetMed("","").Tables[0].Rows)
			{
				if ( listBoxControl_MedReg_MedCarrInfo.Items.Count > 0 )
				{
					
					if ( medRow[2].ToString().Equals("") )
						listBoxControl_MedReg_MedInfo.Items.AddRange(new object[] { medRow[1].ToString() });
					else
						listBoxControl_MedReg_MedInfo.Items.AddRange(new object[] { medRow[1].ToString() + "(" + medRow[2].ToString() + ")" });
					for ( int i=0; i<listBoxControl_MedReg_MedCarrInfo.Items.Count; i++ )
					{
						if ( listBoxControl_MedReg_MedInfo.Items[listBoxControl_MedReg_MedInfo.Items.Count-1].ToString().Equals(
							listBoxControl_MedReg_MedCarrInfo.Items[i].ToString().Substring(0,listBoxControl_MedReg_MedCarrInfo.Items[i].ToString().IndexOf(","))) )
						{
							listBoxControl_MedReg_MedInfo.Items.RemoveAt(listBoxControl_MedReg_MedInfo.Items.Count-1);
							break;
						}
					}
				}
				else
				{
					if ( medRow[2].ToString().Equals("") )
						listBoxControl_MedReg_MedInfo.Items.AddRange(new object[] { medRow[1].ToString() });
					else
						listBoxControl_MedReg_MedInfo.Items.AddRange(new object[] { medRow[1].ToString() + "(" + medRow[2].ToString() + ")" });
				}
			}
			
		}

		private void MedRegGridShow()
		{
			DataSet dsMedStuInfo = healthManagementSystem.GetMedStuInfo(getMedRegGrade,getMedRegClass,getMedRegStuName,
				getMedRegStuNumber,DateTime.Now);

			gridControl_MedReg_StuList.DataSource = dsMedStuInfo.Tables[0];
		}

		private void MedInfoClear()
		{
			textEdit_MedReg_MedName.Text = "";
			textEdit_MedReg_MedTake.Text = "";
			textEdit_MedReg_MedType.Text = "";
			textEdit_MedReg_Taketimes.Text = "";
		}

		private void DiagInfoShow()
		{
			healthManagementSystem.SetStuNumber(dClickNum);
			healthManagementSystem.SetRegDate(DateTime.Now);

			// 教师签名
			healthManagementSystem.SetTeacherSign(healthManagementSystem.GetTeaName(Thread.CurrentPrincipal.Identity.Name));

			DataSet dsDiagInfo = healthManagementSystem.GetDiagInfo(healthManagementSystem.GetHealthMgmt());
			
			if ( dsDiagInfo.Tables[0].Rows.Count > 0 )
			{
				comboBoxEdit_MedReg_Diag.Text = dsDiagInfo.Tables[0].Rows[0][2].ToString();
				textEdit_MedReg_UpperSym.Text = dsDiagInfo.Tables[0].Rows[0][3].ToString();
				textEdit_MedReg_LungSym.Text = dsDiagInfo.Tables[0].Rows[0][4].ToString();
				textEdit_MedReg_ThroatSym.Text = dsDiagInfo.Tables[0].Rows[0][5].ToString();
				textEdit_MedReg_EnteronSym.Text = dsDiagInfo.Tables[0].Rows[0][6].ToString();
				textEdit_MedReg_AbdomenSym.Text = dsDiagInfo.Tables[0].Rows[0][7].ToString();
				textEdit_MedReg_SkinSym.Text = dsDiagInfo.Tables[0].Rows[0][8].ToString();
				textEdit_MedReg_FacialSym.Text = dsDiagInfo.Tables[0].Rows[0][9].ToString();
				textEdit_MedReg_Else.Text = dsDiagInfo.Tables[0].Rows[0][10].ToString();
		
				string medCarrInfo = dsDiagInfo.Tables[0].Rows[0][11].ToString();
				if ( !medCarrInfo.Equals(string.Empty) )
				{
					string subField = medCarrInfo.Substring(0,medCarrInfo.IndexOf(";")+1);
					int fieldLength = subField.Length-1;
					for ( ;; )
					{	
						listBoxControl_MedReg_MedCarrInfo.Items.AddRange(new object[] { subField });
						if ( fieldLength == medCarrInfo.Length-1 )
							break;
						else
						{
							subField = medCarrInfo.Substring(fieldLength+1,medCarrInfo.IndexOf(";",fieldLength+1)-fieldLength);
							fieldLength = medCarrInfo.IndexOf(";",fieldLength+1);
						}
					}
					listBoxControl_MedReg_MedCarrInfo.SelectedIndex = 0;
				}
			}
//			else
//				MessageBox.Show("该记录添加可能是第一次，也可能是由另外一位教师保存，您无法修改,但允许添加新的服药记录！");
		}

		private void DiagInfoClear()
		{
			comboBoxEdit_MedReg_Diag.EditValue = null;
			textEdit_MedReg_UpperSym.Text = "";
			textEdit_MedReg_LungSym.Text = "";
			textEdit_MedReg_ThroatSym.Text = "";
			textEdit_MedReg_EnteronSym.Text = "";
			textEdit_MedReg_AbdomenSym.Text = "";
			textEdit_MedReg_SkinSym.Text = "";
			textEdit_MedReg_FacialSym.Text = "";
			textEdit_MedReg_Else.Text = "";
			listBoxControl_MedReg_MedCarrInfo.Items.Clear();
		}

		#endregion

		#region 服药记录	
		private void comboBoxEdit_MedRec_Grade_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			comboBoxEdit_MedRec_Class.Properties.Items.Clear();
			comboBoxEdit_MedRec_Class.Properties.Items.AddRange(new object[]{"全部"});
			comboBoxEdit_MedRec_Class.SelectedItem = "全部";
			if(getStuInfoByCondition.getGradeInfo(comboBoxEdit_MedRec_Grade.SelectedItem.ToString(),"").Tables[0].Rows.Count > 0)
			{
				//根据年级选择获取年级编号
				getMedRecGrade = getStuInfoByCondition.getGradeInfo(
					comboBoxEdit_MedRec_Grade.SelectedItem.ToString(),"").Tables[0].Rows[0][0].ToString();
				foreach(DataRow getClassList in getStuInfoByCondition.getClassInfo("","",
					getMedRecGrade).Tables[0].Rows)
				{
					comboBoxEdit_MedRec_Class.Properties.Items.AddRange(
						new object[]{getClassList[1].ToString()});
				}
			}	

			if ( comboBoxEdit_MedRec_Grade.SelectedItem.ToString().Equals("全部") )
			{
				getMedRecGrade = "";
				getMedRecClass = "";
			}
			textEdit_MedRec_AbnDiaID.DataBindings.Clear();
			AbnGridShow();
			textEdit_MedRec_DoseRecDiaID.DataBindings.Clear();
			DoseInfoGridShow(getMedRecGrade,getMedRecClass,getMedRecStuName,getMedRecStuNumber,dateEdit_MedRec_BegDate.DateTime.Date,dateEdit_MedRec_EndDate.DateTime.Date,teaAuthority);
		}

		private void comboBoxEdit_MedRec_Class_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( comboBoxEdit_MedRec_Class.SelectedItem.ToString().Equals("全部") )
				getMedRecClass = "";
			else
				getMedRecClass = getStuInfoByCondition.getClassInfo(
					comboBoxEdit_MedRec_Class.SelectedItem.ToString(),"","").Tables[0].Rows[0][0].ToString();

			textEdit_MedRec_AbnDiaID.DataBindings.Clear();
			AbnGridShow();
			textEdit_MedRec_DoseRecDiaID.DataBindings.Clear();
			DoseInfoGridShow(getMedRecGrade,getMedRecClass,getMedRecStuName,getMedRecStuNumber,dateEdit_MedRec_BegDate.DateTime.Date,dateEdit_MedRec_EndDate.DateTime.Date,teaAuthority);
		}
		
		private void textEdit_MedRec_Name_EditValueChanged(object sender, System.EventArgs e)
		{
			getMedRecStuName = textEdit_MedRec_Name.Text;

			textEdit_MedRec_AbnDiaID.DataBindings.Clear();
			AbnGridShow();
			textEdit_MedRec_DoseRecDiaID.DataBindings.Clear();
			DoseInfoGridShow(getMedRecGrade,getMedRecClass,getMedRecStuName,getMedRecStuNumber,dateEdit_MedRec_BegDate.DateTime.Date,dateEdit_MedRec_EndDate.DateTime.Date,teaAuthority);
		}

		private void textEdit_MedRec_Number_EditValueChanged(object sender, System.EventArgs e)
		{
			getMedRecStuNumber = textEdit_MedRec_Number.Text;

			textEdit_MedRec_AbnDiaID.DataBindings.Clear();
			AbnGridShow();
			textEdit_MedRec_DoseRecDiaID.DataBindings.Clear();
			DoseInfoGridShow(getMedRecGrade,getMedRecClass,getMedRecStuName,getMedRecStuNumber,dateEdit_MedRec_BegDate.DateTime.Date,dateEdit_MedRec_EndDate.DateTime.Date,teaAuthority);
		}

		private void simpleButton_MedRec_Back_Click(object sender, System.EventArgs e)
		{
			groupControl_MedRec_DoseRec.Visible = true;
			groupControl_MedRec_DiagAndDoseAdd.Visible = false;

			AbnInfoClear();
		}

		private void simpleButton_AbnormalSer_Click(object sender, System.EventArgs e)
		{
			textEdit_MedRec_AbnDiaID.DataBindings.Clear();
			AbnGridShow();
			textEdit_MedRec_DoseRecDiaID.DataBindings.Clear();
			DoseInfoGridShow(getMedRecGrade,getMedRecClass,getMedRecStuName,getMedRecStuNumber,dateEdit_MedRec_BegDate.DateTime.Date,dateEdit_MedRec_EndDate.DateTime.Date,teaAuthority);
		}

		private void simpleButton_MedRec_Add_Click(object sender, System.EventArgs e)
		{	
			string message = "是否保存服药记录？";
			string caption = "消息提示框!";
			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult == DialogResult.Yes )
			{
				if ( isInserDoseRec )
				{
					if ( textEdit_MedRec_MedName.Text.Equals("") )
						MessageBox.Show("服用药名不应该为空！");
					else
					{
						string takeTime = getTakeDate + " " + timeEdit_MedRec_TakeTime.Time.ToLongTimeString(); 
						int rtnInsertDoseRec = healthManagementSystem.InsertDoseRec(Convert.ToInt32(textEdit_MedRec_AbnDiaID.Text),
							textEdit_MedRec_MedName.Text,textEdit_MedRec_MedTake.Text,takeTime,comboBoxEdit_MedRec_TakeRule.Text,healthManagementSystem.GetTeaName(Thread.CurrentPrincipal.Identity.Name));
						if ( rtnInsertDoseRec > 0 )
							MessageBox.Show("服药记录保存完毕！");
						else
							MessageBox.Show("在保存中出现未知错误，请检查网络或重启后重试！");
					}
				}
				else
				{
					if ( textEdit_MedRec_MedName.Text.Equals("") )
						MessageBox.Show("服用药名不应该为空！");
					else
					{
						string takeTime = getTakeDate + " " + timeEdit_MedRec_TakeTime.Time.ToLongTimeString(); 
						int rtnInsertDoseRec = healthManagementSystem.InsertDoseRec(Convert.ToInt32(textEdit_MedRec_DoseRecDiaID.Text),
							textEdit_MedRec_MedName.Text,textEdit_MedRec_MedTake.Text,takeTime,comboBoxEdit_MedRec_TakeRule.Text,healthManagementSystem.GetTeaName(Thread.CurrentPrincipal.Identity.Name));
						if ( rtnInsertDoseRec > 0 )
							MessageBox.Show("服药记录保存完毕！");
						else
							MessageBox.Show("在保存中出现未知错误，请检查网络或重启后重试！");
					}
				}
			}

			textEdit_MedRec_DoseRecDiaID.DataBindings.Clear();
			DoseInfoGridShow("","","",stuNumber,dateEdit_MedRec_BegDate.DateTime.Date,dateEdit_MedRec_EndDate.DateTime.Date,teaAuthority);

			groupControl_MedRec_DoseRec.Visible = true;
			groupControl_MedRec_DiagAndDoseAdd.Visible = false;

			simpleButton_MedRec_Add.Enabled = false;
		}

		private void simpleButton_MedRec_Report_Click(object sender, System.EventArgs e)
		{
			if ( gridView11.RowCount > 0  )
			{
				string savePath;
				saveFileDialog_Report.Filter = "Excel文件|*.xls";

				if ( saveFileDialog_Report.ShowDialog() != DialogResult.OK )
					return;

				savePath = saveFileDialog_Report.FileName;

				MessageBox.Show("即将进行指定数据分析，分析时间长短视电脑性能而定，按“确定”之后请稍候！");

				healthManagementPrintSystem.PrintDoseInfo(dsDoseInfo,savePath);

				MessageBox.Show("保存完毕！");
			}
			else
				MessageBox.Show("请先生成数据后打印！");
		}

		private void gridControl_MedRec_AbnStuList_DoubleClick(object sender, System.EventArgs e)
		{
			if (Thread.CurrentPrincipal.Identity.Name.ToLower() != "admin")
			{
				if ( gridView10.RowCount != 0 )
				{
					stuNumber = gridView10.GetDataRow(gridView10.GetSelectedRows()[0])[0].ToString();
					textEdit_MedRec_DoseRecDiaID.DataBindings.Clear();
					DoseInfoGridShow("","","",stuNumber,dateEdit_MedRec_BegDate.DateTime.Date,dateEdit_MedRec_EndDate.DateTime.Date,teaAuthority);
					if ( gridView11.RowCount == 0 )
					{
						string message = "该幼儿在指定日期内没有服药记录，是否添加？";
						string caption = "消息提示框!";
						DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
						if ( messageResult == DialogResult.Yes )
						{
							AbnInfoClear();
							AbnInfoShow(stuNumber,Convert.ToDateTime(gridView10.GetDataRow(gridView10.GetSelectedRows()[0])[3]),gridView10.GetDataRow(gridView10.GetSelectedRows()[0])["teacher_Sign"].ToString());

							if ( isThisTeacher )
							{
								groupControl_MedRec_DoseRec.Visible = false;
								groupControl_MedRec_DiagAndDoseAdd.Visible = true;
							}
							else
							{
								groupControl_MedRec_DoseRec.Visible = true;
								groupControl_MedRec_DiagAndDoseAdd.Visible = false;
							}

							isInserDoseRec = true;

							simpleButton_MedRec_Add.Enabled = true;
						}
						getTakeDate = Convert.ToDateTime(gridView10.GetDataRow(gridView10.GetSelectedRows()[0])[3]).ToString("yyyy-MM-dd");
					
					}
				}
			}
		}

		private void gridControl_MedRec_DoseRec_DoubleClick(object sender, System.EventArgs e)
		{	
			if ( Thread.CurrentPrincipal.Identity.Name.ToLower() != "admin" )
			{
				//教师签名
				DataSet dsDoseRecInfo = healthManagementSystem.GetDoseRecInfo(Convert.ToInt32(textEdit_MedRec_DoseRecDiaID.Text),
					gridView11.GetDataRow(gridView11.GetSelectedRows()[0])[4].ToString(),healthManagementSystem.GetTeaName(Thread.CurrentPrincipal.Identity.Name));

				if ( dsDoseRecInfo.Tables[0].Rows.Count > 0 )
				{
					AbnInfoClear();

					getTakeDate = Convert.ToDateTime(gridView11.GetDataRow(gridView11.GetSelectedRows()[0])[4]).ToString("yyyy-MM-dd");
					stuNumber = gridView11.GetDataRow(gridView11.GetSelectedRows()[0])[6].ToString();

					textEdit_MedRec_MedName.Text = dsDoseRecInfo.Tables[0].Rows[0][0].ToString();
					textEdit_MedRec_MedTake.Text = dsDoseRecInfo.Tables[0].Rows[0][1].ToString();
					comboBoxEdit_MedRec_TakeRule.SelectedItem = dsDoseRecInfo.Tables[0].Rows[0][3].ToString();
					timeEdit_MedRec_TakeTime.EditValue = Convert.ToDateTime(dsDoseRecInfo.Tables[0].Rows[0][2]).ToLongTimeString();
				
					AbnInfoShow(stuNumber,Convert.ToDateTime(gridView11.GetDataRow(gridView11.GetSelectedRows()[0])[4]),gridView11.GetDataRow(gridView11.GetSelectedRows()[0])["teacher_signature"].ToString());

					if ( !isThisTeacher )
						return;

					isInserDoseRec = false;

					groupControl_MedRec_DoseRec.Visible = false;
					groupControl_MedRec_DiagAndDoseAdd.Visible = true;

					simpleButton_MedRec_Add.Enabled = true;

					isThisTeacher = true;
				}
				else
					MessageBox.Show("该幼儿当前时刻还未有服药记录，请先在左边的列表处进行添加！");
			}
		}

		private void listBoxControl_MedRec_MedCarrInfo_DoubleClick(object sender, System.EventArgs e)
		{
			if ( listBoxControl_MedRec_MedCarrInfo.Items.Count != 0 )
			{
				string medCarrInfo = listBoxControl_MedRec_MedCarrInfo.SelectedItem.ToString();
				if ( textEdit_MedRec_MedName.Text.Equals("") )
				{
					if ( medCarrInfo.IndexOf("(") > 0  )
					{
						string medName = medCarrInfo.Substring(0,medCarrInfo.IndexOf("("));
						string medTake = medCarrInfo.Substring(medCarrInfo.IndexOf(",")+1,medCarrInfo.LastIndexOf(",")-medCarrInfo.IndexOf(",")-1);

						textEdit_MedRec_MedName.Text = medName;
						textEdit_MedRec_MedTake.Text = medTake;
					}
					else
					{
						string medName = medCarrInfo.Substring(0,medCarrInfo.IndexOf(","));
						string medTake = medCarrInfo.Substring(medCarrInfo.IndexOf(",")+1,medCarrInfo.LastIndexOf(",")-medCarrInfo.IndexOf(",")-1);
						textEdit_MedRec_MedName.Text = medName;
						textEdit_MedRec_MedTake.Text = medTake;
					}
				}
				else
				{
					string message = "是否累积添加？";
					string caption = "消息提示框!";
					DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
					if ( messageResult == DialogResult.Yes )
					{
						string medName = medCarrInfo.Substring(0,medCarrInfo.IndexOf("("));
						string medTake = medCarrInfo.Substring(medCarrInfo.IndexOf(",")+1,medCarrInfo.LastIndexOf(",")-medCarrInfo.IndexOf(",")-1);

						textEdit_MedRec_MedName.Text += "," + medName;
						textEdit_MedRec_MedTake.Text += "," + medTake;
					}
					else
					{
						string medName = medCarrInfo.Substring(0,medCarrInfo.IndexOf("("));
						string medTake = medCarrInfo.Substring(medCarrInfo.IndexOf(",")+1,medCarrInfo.LastIndexOf(",")-medCarrInfo.IndexOf(",")-1);

						textEdit_MedRec_MedName.Text = medName;
						textEdit_MedRec_MedTake.Text = medTake;
					}
				}
			}
		}

		private void barButtonItem_MedRec_MultiSer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			textEdit_MedRec_DoseRecDiaID.DataBindings.Clear();
			DoseInfoGridShow(getMedRecGrade,getMedRecClass,getMedRecStuName,getMedRecStuNumber,dateEdit_MedRec_BegDate.DateTime.Date,dateEdit_MedRec_EndDate.DateTime.Date,teaAuthority);
		}

		private void barButtonItem_MedRec_MedDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			string message = "是否删除指定的幼儿记录？";
			string caption = "消息提示框!";
			DialogResult messageResult = MessageBox.Show(message,caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if ( messageResult == DialogResult.Yes )
			{
				int getRecID = Convert.ToInt32(gridView11.GetDataRow(gridView11.GetSelectedRows()[0])[0]);
//				string getTeaSign = gridView11.GetDataRow(gridView11.GetSelectedRows()[0])[5].ToString();
				string getTeaSign = teaAuthority;
				
				if ( healthManagementSystem.DeleteDoseRec(getRecID,getTeaSign) > 0 )
					MessageBox.Show("指定服药记录删除完毕！");
				else
					MessageBox.Show("删除中出现未知错误，请检查网络或重启后重试！");
			}
			
			textEdit_MedRec_DoseRecDiaID.DataBindings.Clear();
			DoseInfoGridShow(getMedRecGrade,getMedRecClass,getMedRecStuName,getMedRecStuNumber,dateEdit_MedRec_BegDate.DateTime.Date,dateEdit_MedRec_EndDate.DateTime.Date,teaAuthority);

		}

		private void AbnGridShow()
		{
			DataSet dsAbnRec = healthManagementSystem.GetAbnRec(getMedRecGrade,getMedRecClass,getMedRecStuName,
				getMedRecStuNumber,dateEdit_MedRec_BegDate.DateTime.Date,dateEdit_MedRec_EndDate.DateTime.Date);

			gridControl_MedRec_AbnStuList.DataSource = dsAbnRec.Tables[0];

			textEdit_MedRec_AbnDiaID.DataBindings.Add("EditValue",dsAbnRec.Tables[0],"dia_ID");
		}

		private void DoseInfoGridShow(string getGrade,string getClass,string getName,string getNumber,DateTime getBegDate,DateTime getEndDate,string getTeaSign)
		{
			dsDoseInfo = healthManagementSystem.GetDoseInfo(getGrade,getClass,getName,getNumber,getBegDate,getEndDate,getTeaSign);
			
			gridControl_MedRec_DoseRec.DataSource = dsDoseInfo.Tables[0];
			
			if ( dsDoseInfo.Tables[0].Rows.Count != 0 )
			{
				textEdit_MedRec_DoseRecDiaID.DataBindings.Add("EditValue",dsDoseInfo.Tables[0],"dia_ID");
			}
		}

		private void AbnInfoShow(string getNumber,DateTime getDate,string getTeaSign)
		{
			
			if ( !Thread.CurrentPrincipal.IsInRole("园长") && !healthManagementSystem.GetTeaName(Thread.CurrentPrincipal.Identity.Name).Equals(getTeaSign) ) 
			{
				MessageBox.Show("该记录由另外一位教师填加，您无法修改该记录！");
				isThisTeacher = false;
				return;
			}
			else
			{
				healthManagementSystem.SetStuNumber(getNumber);
				healthManagementSystem.SetRegDate(getDate);
				healthManagementSystem.SetTeacherSign(getTeaSign);

				DataSet dsDiagInfo = healthManagementSystem.GetDiagInfo(healthManagementSystem.GetHealthMgmt());

				if ( dsDiagInfo.Tables[0].Rows.Count > 0 )
				{
					textEdit_MedRec_Diag.Text = dsDiagInfo.Tables[0].Rows[0][2].ToString();
					textEdit_MedRec_UpperSym.Text = dsDiagInfo.Tables[0].Rows[0][3].ToString();
					textEdit_MedRec_LungSym.Text = dsDiagInfo.Tables[0].Rows[0][4].ToString();
					textEdit_MedRec_ThroatSym.Text = dsDiagInfo.Tables[0].Rows[0][5].ToString();
					textEdit_MedRec_EnteronSym.Text = dsDiagInfo.Tables[0].Rows[0][6].ToString();
					textEdit_MedRec_AbdomenSym.Text = dsDiagInfo.Tables[0].Rows[0][7].ToString();
					textEdit_MedRec_SkinSym.Text = dsDiagInfo.Tables[0].Rows[0][8].ToString();
					textEdit_MedRec_FacialSym.Text = dsDiagInfo.Tables[0].Rows[0][9].ToString();
					textEdit_MedRec_Else.Text = dsDiagInfo.Tables[0].Rows[0][10].ToString();
					string medCarrInfo = dsDiagInfo.Tables[0].Rows[0][11].ToString();
					if ( !medCarrInfo.Equals(string.Empty) )
					{
						string subField = medCarrInfo.Substring(0,medCarrInfo.IndexOf(";")+1);
						int fieldLength = subField.Length-1;
						for ( ;; )
						{	
							listBoxControl_MedRec_MedCarrInfo.Items.AddRange(new object[] { subField });
							if ( fieldLength == medCarrInfo.Length-1 )

								break;
							else
							{
								subField = medCarrInfo.Substring(fieldLength+1,medCarrInfo.IndexOf(";",fieldLength+1)-fieldLength);
								fieldLength = medCarrInfo.IndexOf(";",fieldLength+1);
							}
						}
						listBoxControl_MedRec_MedCarrInfo.SelectedIndex = 0;
					}
				}		

				isThisTeacher = true;
			}
		}

		private void AbnInfoClear()
		{
			textEdit_MedRec_Diag.Text = "";
			textEdit_MedRec_UpperSym.Text = "";
			textEdit_MedRec_LungSym.Text = "";
			textEdit_MedRec_ThroatSym.Text = "";
			textEdit_MedRec_EnteronSym.Text = "";
			textEdit_MedRec_AbdomenSym.Text = "";
			textEdit_MedRec_SkinSym.Text = "";
			textEdit_MedRec_FacialSym.Text = "";
			textEdit_MedRec_Else.Text = "";
			listBoxControl_MedRec_MedCarrInfo.Items.Clear();
			textEdit_MedRec_MedName.Text = "";
			textEdit_MedRec_MedTake.Text = "";
			timeEdit_MedRec_TakeTime.EditValue = "12:00:00";
			comboBoxEdit_MedRec_TakeRule.EditValue = null;
		}

		#endregion

		private void groupControl_HInputDiagInfo_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}
	}
}

