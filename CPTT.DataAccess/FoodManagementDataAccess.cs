using System;
using System.Data;
using CPTT.SystemFramework;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace CPTT.DataAccess
{
	/// <summary>
	/// FoodManagementDataAccess 的摘要说明。
	/// </summary>
	public class FoodManagementDataAccess :IDisposable
	{
		private Database dbFoodMgmt = DatabaseFactory.CreateDatabase();
		private DBCommandWrapper dbCommandWrapper;
		private string getFoodCategoryCommand = string.Empty;
		private string getFoodNutritionCommand = string.Empty;
		private string insertNutritionCommand = string.Empty;
		private string deleteNutritionCommand = string.Empty;
		private string updateNutritionCommand = string.Empty;
		private string getAccFoodCommand = string.Empty;
		private string insertAccFoodCommand = string.Empty;
		private string updateAccFoodCommand = string.Empty;
		private string deleteAccFoodCommand = string.Empty;
		private string getFoodArrCommand = string.Empty;
		private string inertFoodArrMealCommand = string.Empty;
		private string updateFoodArrMealCommand = string.Empty;
		private string deleteFoodArrMealCommand = string.Empty;
		private string getFoodArrNameCommand = string.Empty;
		private string getFoodArrGradeCommand = string.Empty;
		private string updateFoodArrGradeCommand = string.Empty;
		private string getStuAmountForNutCommand = string.Empty;
		private string getMealForGradeCommand = string.Empty;
		private string getAllStuAmountForNutCommnad = string.Empty;
		private string getAcc1Command = string.Empty;
		private string getAcc1FoodNameCommand = string.Empty;
		private string getAcc2Command = string.Empty;
		private string getAcc2EachDayCommand = string.Empty;
		private string getFoodNutCommand = string.Empty;
		private string getDairyCommand = string.Empty;

		public FoodManagementDataAccess() 
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public DataSet DoGetFoodCategory()
		{
			return FillFoodCategory();	
		}

		public DataSet DoGetFoodNutrition(string getFoodCateName,string getFoodNutName)
		{
			return FillFoodNutrition(getFoodCateName,getFoodNutName);
		}

		public DataSet DoGetAccFood(string getFoodCateName,string getFoodName,string getBegDate,string getEndDate)
		{
			return FillAccFood(getFoodCateName,getFoodName,getBegDate,getEndDate);
		}

		public DataSet GetFoodArrangement()
		{
			getFoodArrCommand = "GetFoodArrangement";
			dbCommandWrapper = dbFoodMgmt.GetStoredProcCommandWrapper(getFoodArrCommand);
			return dbFoodMgmt.ExecuteDataSet(dbCommandWrapper);
		}

		public DataSet GetFoodArrName()
		{
			getFoodArrNameCommand = "GetFoodArrName";
			dbCommandWrapper = dbFoodMgmt.GetStoredProcCommandWrapper(getFoodArrNameCommand);
			return dbFoodMgmt.ExecuteDataSet(dbCommandWrapper);
		}

		public DataSet GetFoodArrGrade(FoodMgmt foodMgmt,bool selStyle)
		{
			return FillFoodArrGrade(foodMgmt,selStyle);
		}

		public int InsertNutrition(FoodMgmt foodMgmt)
		{
			insertNutritionCommand = "InsertNutrition";
			dbCommandWrapper = dbFoodMgmt.GetStoredProcCommandWrapper(insertNutritionCommand);
			dbCommandWrapper.AddInParameter("@foodCateName",DbType.String,foodMgmt.FoodCategory);
			dbCommandWrapper.AddInParameter("@foodName",DbType.String,foodMgmt.FoodName);
			dbCommandWrapper.AddInParameter("@foodProtein",DbType.Double,foodMgmt.Protein);
			dbCommandWrapper.AddInParameter("@foodFat",DbType.Double,foodMgmt.Fat);
			dbCommandWrapper.AddInParameter("@foodCarbohydrate",DbType.Double,foodMgmt.Carbohydrate);
			dbCommandWrapper.AddInParameter("@foodEnergy",DbType.Double,foodMgmt.Energy);
			dbCommandWrapper.AddInParameter("@foodRemark",DbType.String,foodMgmt.FoodRemark);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int16,16);
			dbFoodMgmt.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public int DeleteNutrition(FoodMgmt foodMgmt)
		{
			deleteNutritionCommand = "DeleteNutrition";
			dbCommandWrapper = dbFoodMgmt.GetStoredProcCommandWrapper(deleteNutritionCommand);
			dbCommandWrapper.AddInParameter("@foodID",DbType.Int32,foodMgmt.FoodID);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int16,16);
			dbFoodMgmt.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public int UpdateNutrition(FoodMgmt foodMgmt)
		{
			updateNutritionCommand = "UpdateNutrition";
			dbCommandWrapper = dbFoodMgmt.GetStoredProcCommandWrapper(updateNutritionCommand);
			dbCommandWrapper.AddInParameter("@foodID",DbType.Int32,foodMgmt.FoodID);
			dbCommandWrapper.AddInParameter("@foodCategory",DbType.String,foodMgmt.FoodCategory);
			dbCommandWrapper.AddInParameter("@foodName",DbType.String,foodMgmt.FoodName);
			dbCommandWrapper.AddInParameter("@foodProtein",DbType.Double,foodMgmt.Protein);
			dbCommandWrapper.AddInParameter("@foodFat",DbType.Double,foodMgmt.Fat);
			dbCommandWrapper.AddInParameter("@foodCarbohydrate",DbType.Double,foodMgmt.Carbohydrate);
			dbCommandWrapper.AddInParameter("@foodEnergy",DbType.Double,foodMgmt.Energy);
			dbCommandWrapper.AddInParameter("@foodRemark",DbType.String,foodMgmt.FoodRemark);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int16,16);
			dbFoodMgmt.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public int InsertAccFood(string getFoodID,double getTakeAmount,string getDate,string getRemark)
		{
			insertAccFoodCommand = "InsertAccFood";
			dbCommandWrapper = dbFoodMgmt.GetStoredProcCommandWrapper(insertAccFoodCommand);
			dbCommandWrapper.AddInParameter("@getFoodID",DbType.Int32,Convert.ToInt32(getFoodID));
			dbCommandWrapper.AddInParameter("@getTakeAmount",DbType.Double,getTakeAmount);
			dbCommandWrapper.AddInParameter("@getDate",DbType.String,getDate);
			dbCommandWrapper.AddInParameter("@getRemark",DbType.String,getRemark);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int16,16);
			dbFoodMgmt.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public int UpdateAccFood(string getFoodID,double getTakeAmount,string getDate,string getRemark)
		{
			updateAccFoodCommand = "UpdateAccFood";
			dbCommandWrapper = dbFoodMgmt.GetStoredProcCommandWrapper(updateAccFoodCommand);
			dbCommandWrapper.AddInParameter("@getFoodID",DbType.Int32,Convert.ToInt32(getFoodID));
			dbCommandWrapper.AddInParameter("@getTakeAmount",DbType.Double,getTakeAmount);
			dbCommandWrapper.AddInParameter("@getDate",DbType.String,getDate);
			dbCommandWrapper.AddInParameter("@getRemark",DbType.String,getRemark);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int16,16);
			dbFoodMgmt.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public int DeleteAccFood(string getFoodID,string getDate)
		{
			deleteAccFoodCommand = "DeleteAccFood";
			dbCommandWrapper = dbFoodMgmt.GetStoredProcCommandWrapper(deleteAccFoodCommand);
			dbCommandWrapper.AddInParameter("@getFoodID",DbType.Int32,Convert.ToInt32(getFoodID));
			dbCommandWrapper.AddInParameter("@getDate",DbType.String,getDate);
			dbCommandWrapper.AddOutParameter("rowsAffected",DbType.Int16,16);
			dbFoodMgmt.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("rowsAffected"));
		}

		public int InsertFoodArrMeal(FoodMgmt foodMgmt)
		{
			inertFoodArrMealCommand = "InsertFoodArrMeal";
			dbCommandWrapper = dbFoodMgmt.GetStoredProcCommandWrapper(inertFoodArrMealCommand);
			dbCommandWrapper.AddInParameter("@foodArrID",DbType.Int32,foodMgmt.FoodArrID);
			dbCommandWrapper.AddInParameter("@foodArrName",DbType.String,foodMgmt.MealName);
			dbCommandWrapper.AddInParameter("@foodArrRemark",DbType.String,foodMgmt.MealRemark);
			dbCommandWrapper.AddInParameter("@foodArrBreakFast",DbType.Boolean,foodMgmt.BreakFast);
			dbCommandWrapper.AddInParameter("@foodArrLunch",DbType.Boolean,foodMgmt.Lunch);
			dbCommandWrapper.AddInParameter("@foodArrSnack",DbType.Boolean,foodMgmt.Snack);
			dbCommandWrapper.AddInParameter("@foodArrDinner",DbType.Boolean,foodMgmt.Dinner);
			dbCommandWrapper.AddOutParameter("rowsAffected",DbType.Int16,16);
			dbFoodMgmt.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("rowsAffected"));
		}

		public int UpdateFoodArrMeal(FoodMgmt foodMgmt)
		{
			updateFoodArrMealCommand = "UpdateFoodArrMeal";
			dbCommandWrapper = dbFoodMgmt.GetStoredProcCommandWrapper(updateFoodArrMealCommand);
			dbCommandWrapper.AddInParameter("@foodArrID",DbType.Int32,foodMgmt.FoodArrID);
			dbCommandWrapper.AddInParameter("@foodArrName",DbType.String,foodMgmt.MealName);
			dbCommandWrapper.AddInParameter("@foodArrRemark",DbType.String,foodMgmt.MealRemark);
			dbCommandWrapper.AddInParameter("@foodArrBreakFast",DbType.Boolean,foodMgmt.BreakFast);
			dbCommandWrapper.AddInParameter("@foodArrLunch",DbType.Boolean,foodMgmt.Lunch);
			dbCommandWrapper.AddInParameter("@foodArrSnack",DbType.Boolean,foodMgmt.Snack);
			dbCommandWrapper.AddInParameter("@foodArrDinner",DbType.Boolean,foodMgmt.Dinner);
			dbCommandWrapper.AddOutParameter("rowsAffected",DbType.Int16,16);
			dbFoodMgmt.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("rowsAffected"));
		}

		public int DeleteFoodArrMeal(FoodMgmt foodMgmt)
		{
			deleteFoodArrMealCommand = "DeleteFoodArrMeal";
			dbCommandWrapper = dbFoodMgmt.GetStoredProcCommandWrapper(deleteFoodArrMealCommand);
			dbCommandWrapper.AddInParameter("@foodArrID",DbType.Int32,foodMgmt.FoodArrID);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int16,16);
			dbFoodMgmt.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("rowsAffected"));
		}

		public int UpdateFoodArrGrade(FoodMgmt foodMgmt)
		{
			updateFoodArrGradeCommand = "UpdateFoodArrGrade";
			dbCommandWrapper = dbFoodMgmt.GetStoredProcCommandWrapper(updateFoodArrGradeCommand);
			dbCommandWrapper.AddInParameter("@foodArrID",DbType.Int32,foodMgmt.FoodArrID);
			dbCommandWrapper.AddInParameter("@suitAge",DbType.String,foodMgmt.SuitAge);
			dbCommandWrapper.AddInParameter("@isUsed",DbType.String,foodMgmt.IsUsed);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int16,16);
			dbFoodMgmt.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public int GetStuAmountForNut(DateTime getBegDate,DateTime getEndDate,int getMonth,int getEachDay,int getGrade)
		{
			return FillStuAmountForNut(getBegDate,getEndDate,getMonth,getEachDay,getGrade);
		}

		public int GetAllStuAmountForNut(DateTime getBegDate,DateTime getEndDate,int getMonth,int getGrade)
		{
			return FillAllStuAmountForNut(getBegDate,getEndDate,getMonth,getGrade);
		}

		public DataSet GetMealForGrade()
		{
			getMealForGradeCommand = "GetMealForGrade";
			dbCommandWrapper = dbFoodMgmt.GetStoredProcCommandWrapper(getMealForGradeCommand);
			return dbFoodMgmt.ExecuteDataSet(dbCommandWrapper);
		}

		public DataSet GetAcc1(string getBegDate,string getEndDate,int getMonth,int getCateID)
		{
			return FillAcc1(getBegDate,getEndDate,getMonth,getCateID);
		}

		public string GetAcc1FoodName(int getFoodID)
		{
			return FillAcc1FoodName(getFoodID);
		}

		public DataSet GetAcc2(string getBegDate, string getEndDate,int getMonth)
		{
			return FillAcc2(getBegDate,getEndDate,getMonth);
		}

		public DataSet GetAcc2EachDay(string getBegDate,string getEndDate,int getMonth,int getDay,int getFoodID)
		{
			return FillAcc2EachDay(getBegDate,getEndDate,getMonth,getDay,getFoodID);
		}

		public DataSet GetFoodNut(string getBegDate,string getEndDate,int getMonth,int getFoodCateID)
		{
			return FillFoodNut(getBegDate,getEndDate,getMonth,getFoodCateID);
		}

		public DataSet GetDairy(string getBegDate,string getEndDate,int getMonth)
		{
			return FillDairy(getBegDate,getEndDate,getMonth);
		}

		private DataSet FillFoodCategory()
		{
			getFoodCategoryCommand = "GetFoodCategory";
			dbCommandWrapper = dbFoodMgmt.GetStoredProcCommandWrapper(getFoodCategoryCommand);
			return dbFoodMgmt.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillFoodNutrition(string getFoodCateName,string getFoodNutName)
		{
			getFoodNutritionCommand = "GetFoodNutrition";
			dbCommandWrapper = dbFoodMgmt.GetStoredProcCommandWrapper(getFoodNutritionCommand);
			dbCommandWrapper.AddInParameter("@foodCateName",DbType.String,getFoodCateName);
			dbCommandWrapper.AddInParameter("@foodNutName",DbType.String,getFoodNutName);
			return dbFoodMgmt.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillAccFood(string getFoodCateName,string getFoodName,string getBegDate,string getEndDate)
		{
			getAccFoodCommand = "GetAccFood";
			dbCommandWrapper = dbFoodMgmt.GetStoredProcCommandWrapper(getAccFoodCommand);
			dbCommandWrapper.AddInParameter("@foodCateName",DbType.String,getFoodCateName);
			dbCommandWrapper.AddInParameter("@foodName",DbType.String,getFoodName);
			dbCommandWrapper.AddInParameter("@begDate",DbType.String,getBegDate);
			dbCommandWrapper.AddInParameter("@endDate",DbType.String,getEndDate);
			return dbFoodMgmt.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillFoodArrGrade(FoodMgmt foodMgmt,bool selStyle)
		{
			getFoodArrGradeCommand = "GetFoodArrGrade";
			dbCommandWrapper = dbFoodMgmt.GetStoredProcCommandWrapper(getFoodArrGradeCommand);
			dbCommandWrapper.AddInParameter("@foodArrID",DbType.Int32,foodMgmt.FoodArrID);
			dbCommandWrapper.AddInParameter("@foodArrName",DbType.String,foodMgmt.FoodArrName);
			dbCommandWrapper.AddInParameter("@selStyle",DbType.Boolean,selStyle);
			return dbFoodMgmt.ExecuteDataSet(dbCommandWrapper);
		}

		private int FillStuAmountForNut(DateTime getBegDate,DateTime getEndDate,int getMonth,int getEachDay,int getGrade)
		{
			getStuAmountForNutCommand = "GetStuAmountForNut";
			dbCommandWrapper = dbFoodMgmt.GetStoredProcCommandWrapper(getStuAmountForNutCommand);
			dbCommandWrapper.AddInParameter("@begDate",DbType.DateTime,getBegDate);
			dbCommandWrapper.AddInParameter("@endDate",DbType.DateTime,getEndDate);
			dbCommandWrapper.AddInParameter("@getMonth",DbType.Int32,getMonth);
			dbCommandWrapper.AddInParameter("@getEachDay",DbType.Int32,getEachDay);
			dbCommandWrapper.AddInParameter("@getGrade",DbType.Int32,getGrade);
			dbCommandWrapper.AddOutParameter("@getAmount",DbType.Int32,32);
			dbFoodMgmt.ExecuteDataSet(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@getAmount"));
		}

		private int FillAllStuAmountForNut(DateTime getBegDate,DateTime getEndDate,int getMonth,int getGrade)
		{
			getAllStuAmountForNutCommnad = "GetAllStuAmountForNut";
			dbCommandWrapper = dbFoodMgmt.GetStoredProcCommandWrapper(getAllStuAmountForNutCommnad);
			dbCommandWrapper.AddInParameter("@begDate",DbType.DateTime,getBegDate);
			dbCommandWrapper.AddInParameter("@endDate",DbType.DateTime,getEndDate);
			dbCommandWrapper.AddInParameter("@getMonth",DbType.Int32,getMonth);
			dbCommandWrapper.AddInParameter("@getGrade",DbType.Int32,getGrade);
			dbCommandWrapper.AddOutParameter("@getAmount",DbType.Int32,32);
			dbFoodMgmt.ExecuteDataSet(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@getAmount"));
		}

		private DataSet FillAcc1(string getBegDate,string getEndDate,int getMonth,int getCateID)
		{
			getAcc1Command = "GetAcc1";
			dbCommandWrapper = dbFoodMgmt.GetStoredProcCommandWrapper(getAcc1Command);
			dbCommandWrapper.AddInParameter("@getBegDate",DbType.String,getBegDate);
			dbCommandWrapper.AddInParameter("@getEndDate",DbType.String,getEndDate);
			dbCommandWrapper.AddInParameter("@getMonth",DbType.Int32,getMonth);
			dbCommandWrapper.AddInParameter("@getCateID",DbType.Int32,getCateID);
			return dbFoodMgmt.ExecuteDataSet(dbCommandWrapper);
		}

		private string FillAcc1FoodName(int getFoodID)
		{
			getAcc1FoodNameCommand = "GetAcc1FoodName";
			dbCommandWrapper = dbFoodMgmt.GetStoredProcCommandWrapper(getAcc1FoodNameCommand);
			dbCommandWrapper.AddInParameter("@getFoodID",DbType.Int32,getFoodID);
			dbCommandWrapper.AddOutParameter("@getFoodName",DbType.String,50);
			dbFoodMgmt.ExecuteNonQuery(dbCommandWrapper);
			return dbCommandWrapper.GetParameterValue("@getFoodName").ToString();
		}

		private DataSet FillAcc2(string getBegDate, string getEndDate,int getMonth)
		{
			getAcc2Command = "GetAcc2";
			dbCommandWrapper = dbFoodMgmt.GetStoredProcCommandWrapper(getAcc2Command);
			dbCommandWrapper.AddInParameter("@getBegDate",DbType.String,getBegDate);
			dbCommandWrapper.AddInParameter("@getEndDate",DbType.String,getEndDate);
			dbCommandWrapper.AddInParameter("@getMonth",DbType.Int32,getMonth);
			return dbFoodMgmt.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillAcc2EachDay(string getBegDate,string getEndDate,int getMonth,int getDay,int getFoodID)
		{
			getAcc2EachDayCommand = "GetAcc2_EachDay";
			dbCommandWrapper = dbFoodMgmt.GetStoredProcCommandWrapper(getAcc2EachDayCommand);
			dbCommandWrapper.AddInParameter("@getBegDate",DbType.String,getBegDate);
			dbCommandWrapper.AddInParameter("@getEndDate",DbType.String,getEndDate);
			dbCommandWrapper.AddInParameter("@getMonth",DbType.Int32,getMonth);
			dbCommandWrapper.AddInParameter("@getDay",DbType.Int32,getDay);
			dbCommandWrapper.AddInParameter("@getFoodID",DbType.Int32,getFoodID);
			return dbFoodMgmt.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillFoodNut(string getBegDate,string getEndDate,int getMonth,int getFoodCateID)
		{
			getFoodNutCommand = "GetFoodNut";
			dbCommandWrapper = dbFoodMgmt.GetStoredProcCommandWrapper(getFoodNutCommand);
			dbCommandWrapper.AddInParameter("@getBegDate",DbType.String,getBegDate);
			dbCommandWrapper.AddInParameter("@getEndDate",DbType.String,getEndDate);
			dbCommandWrapper.AddInParameter("@getMonth",DbType.Int32,getMonth);
			dbCommandWrapper.AddInParameter("@getFoodCateID",DbType.Int32,getFoodCateID);
			return dbFoodMgmt.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillDairy(string getBegDate,string getEndDate,int getMonth)
		{
			getDairyCommand = "GetDairy";
			dbCommandWrapper = dbFoodMgmt.GetStoredProcCommandWrapper(getDairyCommand);
			dbCommandWrapper.AddInParameter("@getBegDate",DbType.String,getBegDate);
			dbCommandWrapper.AddInParameter("@getEndDate",DbType.String,getEndDate);
			dbCommandWrapper.AddInParameter("@getMonth",DbType.Int32,getMonth);
			return dbFoodMgmt.ExecuteDataSet(dbCommandWrapper);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(true);
		}

		protected virtual void Dispose(bool disposing)
		{
			if ( !disposing )
				return;
			else
			{
				if ( dbFoodMgmt != null )
					dbFoodMgmt = null;
			}
		}
	}
}
