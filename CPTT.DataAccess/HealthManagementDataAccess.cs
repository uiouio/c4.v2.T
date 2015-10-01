using System;
using System.Data;
using CPTT.SystemFramework;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace CPTT.DataAccess
{
	/// <summary>
	/// HealthManagementDataAccess 的摘要说明。
	/// </summary>
	public class HealthManagementDataAccess : IDisposable
	{
		private Database dbHealth = DatabaseFactory.CreateDatabase();
		private DBCommandWrapper dbCommandWrapper;
		private string getStuForHealthCommand = string.Empty;
		private string getNchsHealthAnalyHistoryCommand = string.Empty;
		private string getHealthAnalyHistoryCommand = string.Empty;
		private string getHeightAnalyCommand = string.Empty;
		private string getNchsAgeHeightMiddleValueCommand = string.Empty;
		private string getNchsAgeHeightCutOffPointCommand = string.Empty;
		private string getWeightAnalyCommand = string.Empty;
		private string getNchsAgeWeightMiddleValueCommand = string.Empty;
		private string getNchsAgeWeightCutOffPointCommand = string.Empty;
		private string getHeightWeightAnalyCommand = string.Empty;
		private string getWhoAnalyCommand = string.Empty;
		private string getNchsHeightWeightMiddleValueCommand = string.Empty;
		private string getNchsHeightWeightCutOffPointCommand = string.Empty;
		private string getNutAnalyCommand = string.Empty;
		private string insertNchsHealthAnalysisCommand = string.Empty;
		private string insertHealthAnalyCommand = string.Empty;
		private string updateNchsHealthAnalysisCommand = string.Empty;
		private string updateHealthAnalyCommand = string.Empty;
		private string deleteNchsHealthAnalysisCommand = string.Empty;
		private string deleteHealthAnalyCommand = string.Empty;
		private string getNchsHealthOutputCommand = string.Empty;
		private string getHealthOutputCommand = string.Empty;
		private string getNchsStudentsOnSummaryCommand = string.Empty ;
		private string getNchsHeightOnSummaryCommand = string.Empty;
		private string getNchsHeightUpMiddleOnSummaryCommand = string.Empty;
		private string getHeightAnalyStatCommand = string.Empty;
		private string getHeightAnalyTotalCommand = string.Empty;
		private string getNchsWeightOnSummaryCommand = string.Empty;
		private string getNchsWeightUpMiddleOnSummaryCommand = string.Empty;
		private string getWeightAnalyStatCommand = string.Empty;
		private string getWeightAnalyTotalCommand = string.Empty;
		private string getHeightOverCommand = string.Empty;
		private string getWeightOverCommand = string.Empty;
		private string getHealthAllCommand = string.Empty;
		//肥胖儿总数
		private string getWhoTotalCommmand = string.Empty;    
		private string getStuEnterListCommand = string.Empty;
		private string saveMorningWatchCommand = string.Empty;
		private string getWholeDayWatchCommand = string.Empty;
		private string deleteWholeDayWatchCommand = string.Empty;
		private string getMedStuInfoCommand = string.Empty;
		private string insertMedCommand = string.Empty;
		private string getMedCommand = string.Empty;
		private string updateMedCommand = string.Empty;
		private string deleteMedCommand = string.Empty;
		private string saveDiagResultCommand = string.Empty;
		private string getDiagInfoCommand = string.Empty;
		private string getAbnRecCommand = string.Empty;
		private string getDoseInfoCommand = string.Empty;
		private string insertDoseRecCommad = string.Empty;
		private string getDoseRecInfoCommand = string.Empty;
		private string deleteDoseRecCommand = string.Empty;

		private string getTeaNameCommand = string.Empty;
		public HealthManagementDataAccess()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public DataSet GetStuForHealth(string getGrade,string getClass,string getName,string getNumber,string getGender)
		{
			return FillStuForHealth(getGrade,getClass,getName,getNumber,getGender);
		}

		public DataTable GetNchsHealthAnalyHistory(string getStuID, string getDate)
		{
			return FillNchsHealthAnalyHistory(getStuID,getDate).Tables[0];
		}

		public DataSet GetHealthAnalyHistory(string getStuID, string getDate)
		{
			return FillHealthAnalyHistory(getStuID,getDate);
		}

		public DataSet GetHeightAnaly(int getMonth,bool getGender,bool getRegion)
		{
			return FillHeightAnaly(getMonth,getGender,getRegion);
		}

		public DataTable GetNchsAgeHeightCutOffPoint(int getTotalMonth,bool getGender)
		{
			int getAge = getTotalMonth / 12;
			int getMonth = getTotalMonth % 12;
			return FillNchsAgeHeightCutOffPoint(getAge,getMonth,getGender).Tables[0];
		}

		public DataTable GetNchsAgeHeightMiddleValue(string getRealAge,int getGender)
		{
			return FillNchsAgeHeightMiddleValue(getRealAge,getGender).Tables[0];
		}	

		public DataSet GetWeightAnaly(int getMonth,bool getGender,bool getRegion)
		{
			return FillWeightAnaly(getMonth,getGender,getRegion);
		}

		public DataTable GetNchsAgeWeightCutOffPoint(int getTotalMonth,bool getGender)
		{
			int getAge = getTotalMonth / 12;
			int getMonth = getTotalMonth % 12;
			return FillNchsAgeWeightCutOffPoint(getAge,getMonth,getGender).Tables[0];
		}

		public DataTable GetNchsAgeWeightMiddleValue(string getRealAge,int getGender)
		{
			return FillNchsAgeWeightMiddleValue(getRealAge,getGender).Tables[0];
		}

		public DataSet GetHeightWeightAnaly(int getHeight, bool getGender)
		{
			return FillHeightWeightAnaly(getHeight, getGender);
		}

		public DataSet GetWhoAnaly(int getHeight,bool getGender)
		{
			return FillWhoAnaly(getHeight,getGender);
		}

		public DataTable GetNchsHeightWeightCutOffPoint(double getHeight,bool getGender)
		{
			return FillNchsHeightWeightCutOffPoint(getHeight,getGender).Tables[0];
		}

		public DataTable GetNchsHeightWeightMiddleValue(double getHeight,int getGender)
		{
			return FillNchsHeightWeightMiddleValue(getHeight,getGender).Tables[0];
		}

		public DataSet GetNutAnaly(double getHeight,bool getGender)
		{
			return FillNutAnaly(getHeight,getGender);
		}

		public int InsertNchsHealthAnalysis(HealthMgmt healthMgmt)
		{
			insertNchsHealthAnalysisCommand = "hm_nchs_insertHealthAnalysis";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(insertNchsHealthAnalysisCommand);
			dbCommandWrapper.AddInParameter("@getStuID",DbType.String,healthMgmt.StuID);
			dbCommandWrapper.AddInParameter("@getDate",DbType.String,healthMgmt.Date);
			dbCommandWrapper.AddInParameter("@getAge",DbType.String,healthMgmt.Age);
			dbCommandWrapper.AddInParameter("@getHeight",DbType.Double,healthMgmt.Height);
			dbCommandWrapper.AddInParameter("@getNchsHeight",DbType.String,healthMgmt.HeightAnaly.Trim());
			dbCommandWrapper.AddInParameter("@getWeight",DbType.Double,healthMgmt.Weight);
			dbCommandWrapper.AddInParameter("@getNchsWeight",DbType.String,healthMgmt.WeightAnaly.Trim());
			dbCommandWrapper.AddInParameter("@getNchsObesity",DbType.String,healthMgmt.WHO.Trim());
			dbCommandWrapper.AddInParameter("@getNchsNut",DbType.String,healthMgmt.Nut.Trim());
			dbCommandWrapper.AddInParameter("@getNchsUnderWeight",DbType.String,healthMgmt.NchsUnderWeight.Trim());
			dbCommandWrapper.AddInParameter("@getNchsStunting",DbType.String,healthMgmt.NchsStunting.Trim());
			dbCommandWrapper.AddInParameter("@getNchsWasting",DbType.String,healthMgmt.NchsWasting.Trim());
			dbCommandWrapper.AddInParameter("@getRemark",DbType.String,healthMgmt.Remark);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,16);
			dbHealth.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public int InsertHealthAnaly(HealthMgmt healthMgmt)
		{
			insertHealthAnalyCommand = "InsertHealthAnaly";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(insertHealthAnalyCommand);
			dbCommandWrapper.AddInParameter("@getStuID",DbType.String,healthMgmt.StuID);
			dbCommandWrapper.AddInParameter("@getDate",DbType.String,healthMgmt.Date);
			dbCommandWrapper.AddInParameter("@getAge",DbType.String,healthMgmt.Age);
			dbCommandWrapper.AddInParameter("@getHeight",DbType.Double,healthMgmt.Height);
			dbCommandWrapper.AddInParameter("@getHeightAnaly",DbType.String,healthMgmt.HeightAnaly.Trim());
			dbCommandWrapper.AddInParameter("@getWeight",DbType.Double,healthMgmt.Weight);
			dbCommandWrapper.AddInParameter("@getWeightAnaly",DbType.String,healthMgmt.WeightAnaly.Trim());
			dbCommandWrapper.AddInParameter("@getHeightWeightAnaly",DbType.String,healthMgmt.HeightWeightAnaly.Trim());
			dbCommandWrapper.AddInParameter("@getWHO",DbType.String,healthMgmt.WHO.Trim());
			dbCommandWrapper.AddInParameter("@getWHOPer",DbType.String,healthMgmt.WHOPer.Trim());
			dbCommandWrapper.AddInParameter("@getX",DbType.String,healthMgmt.X.Trim());
			dbCommandWrapper.AddInParameter("@getNut",DbType.String,healthMgmt.Nut.Trim());
			dbCommandWrapper.AddInParameter("@getRemark",DbType.String,healthMgmt.Remark);
			dbCommandWrapper.AddInParameter("@getStd",DbType.Boolean,healthMgmt.Std);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,16);
			dbHealth.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public int UpdateNchsHealthAnalysis(HealthMgmt healthMgmt)
		{
			updateNchsHealthAnalysisCommand = "hm_nchs_updateHealthAnalysis";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(updateNchsHealthAnalysisCommand);
			dbCommandWrapper.AddInParameter("@getStuID",DbType.String,healthMgmt.StuID);
			dbCommandWrapper.AddInParameter("@getDate",DbType.String,healthMgmt.Date);
			dbCommandWrapper.AddInParameter("@getAge",DbType.String,healthMgmt.Age);
			dbCommandWrapper.AddInParameter("@getHeight",DbType.Double,healthMgmt.Height);
			dbCommandWrapper.AddInParameter("@getNchsHeight",DbType.String,healthMgmt.HeightAnaly.Trim());
			dbCommandWrapper.AddInParameter("@getWeight",DbType.Double,healthMgmt.Weight);
			dbCommandWrapper.AddInParameter("@getNchsWeight",DbType.String,healthMgmt.WeightAnaly.Trim());
			dbCommandWrapper.AddInParameter("@getNchsObesity",DbType.String,healthMgmt.WHO.Trim());
			dbCommandWrapper.AddInParameter("@getNchsNut",DbType.String,healthMgmt.Nut.Trim());
			dbCommandWrapper.AddInParameter("@getNchsUnderWeight",DbType.String,healthMgmt.NchsUnderWeight.Trim());
			dbCommandWrapper.AddInParameter("@getNchsStunting",DbType.String,healthMgmt.NchsStunting.Trim());
			dbCommandWrapper.AddInParameter("@getNchsWasting",DbType.String,healthMgmt.NchsWasting.Trim());
			dbCommandWrapper.AddInParameter("@getRemark",DbType.String,healthMgmt.Remark);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,16);
			dbHealth.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public int UpdateHealthAnaly(HealthMgmt healthMgmt)
		{
			updateHealthAnalyCommand = "UpdateHealthAnaly";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(updateHealthAnalyCommand);
			dbCommandWrapper.AddInParameter("@getStuID",DbType.String,healthMgmt.StuID);
			dbCommandWrapper.AddInParameter("@getDate",DbType.String,healthMgmt.Date);
			dbCommandWrapper.AddInParameter("@getAge",DbType.String,healthMgmt.Age);
			dbCommandWrapper.AddInParameter("@getHeight",DbType.Double,healthMgmt.Height);
			dbCommandWrapper.AddInParameter("@getHeightAnaly",DbType.String,healthMgmt.HeightAnaly.Trim());
			dbCommandWrapper.AddInParameter("@getWeight",DbType.Double,healthMgmt.Weight);
			dbCommandWrapper.AddInParameter("@getWeightAnaly",DbType.String,healthMgmt.WeightAnaly.Trim());
			dbCommandWrapper.AddInParameter("@getWHO",DbType.String,healthMgmt.WHO.Trim());
			dbCommandWrapper.AddInParameter("@getNut",DbType.String,healthMgmt.Nut.Trim());
			dbCommandWrapper.AddInParameter("@getRemark",DbType.String,healthMgmt.Remark);
			dbCommandWrapper.AddInParameter("@getX", DbType.String, healthMgmt.X);
			dbCommandWrapper.AddInParameter("@getStd",DbType.Boolean,healthMgmt.Std);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,16);
			dbHealth.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public int DeleteNchsHealthAnalysis(HealthMgmt healthMgmt)
		{
			deleteNchsHealthAnalysisCommand = "hm_nchs_deleteHealthAnalysis";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(deleteNchsHealthAnalysisCommand);
			dbCommandWrapper.AddInParameter("@getStuID",DbType.String,healthMgmt.StuID);
			dbCommandWrapper.AddInParameter("@getDate",DbType.String,healthMgmt.Date);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,16);
			dbHealth.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public int DeleteHealthAnaly(HealthMgmt healthMgmt)
		{
			deleteHealthAnalyCommand = "DeleteHealthAnaly";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(deleteHealthAnalyCommand);
			dbCommandWrapper.AddInParameter("@getStuID",DbType.String,healthMgmt.StuID);
			dbCommandWrapper.AddInParameter("@getDate",DbType.String,healthMgmt.Date);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,16);
			dbHealth.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));

		}

		public DataSet GetNchsHealthOutput(HealthMgmt healthMgmt)
		{
			return FillNchsHealthOutput(healthMgmt);
		}

		public DataSet GetHealthOutput(HealthMgmt healthMgmt)
		{
			return FillHealthOutput(healthMgmt);
		}

		public DataSet GetNchsStudentsOnSummary(string getBegDate,string getEndDate,string getAddr)
		{
			return FillNchsStudentsOnSummary(getBegDate,getEndDate,getAddr);
		}

		public DataTable GetNchsHeightOnSummary(string getBegDate,string getEndDate,string getValue,string getAddr)
		{
			return FillNchsHeightOnSummary(getBegDate,getEndDate,getValue,getAddr).Tables[0];
		}

		public DataTable GetNchsHeightUpMiddleOnSummary(string getBegDate,string getEndDate,string getAddr)
		{
			return FillNchsHeightUpMiddleOnSummary(getBegDate,getEndDate,getAddr).Tables[0];	
		}

		public DataSet GetHeightAnalyStat(string getBegDate,string getEndDate,string getHeightAnaly,string getClassName)
		{
			return FillHeightStat(getBegDate,getEndDate,getHeightAnaly,getClassName);
		}

		public DataSet GetHeightAnalyTotal(string getBegDate,string getEndDate,string getHeightAnaly)
		{
			return FillHeightTotal(getBegDate,getEndDate,getHeightAnaly);
		}

		public DataTable GetNchsWeightOnSummary(string getBegDate,string getEndDate,string getValue,string getAddr)
		{
			return FilleNchsWeightOnSummary(getBegDate,getEndDate,getValue,getAddr).Tables[0];
		}

		public DataTable GetNchsWeightUpMiddleOnSummary(string getBegDate,string getEndDate,string getAddr)
		{
			return FillNchsWeightUpMiddleOnSummary(getBegDate,getEndDate,getAddr).Tables[0];
		}

		public DataSet GetWeightAnalyStat(string getBegDate,string getEndDate,string getWeightAnaly,string getClassName)
		{
			return FillWeightStat(getBegDate,getEndDate,getWeightAnaly,getClassName);
		}

		public DataSet GetWeightAnalyTotal(string getBegDate,string getEndDate,string getWeightAnaly)
		{
			return FillWeightTotal(getBegDate,getEndDate,getWeightAnaly);
		}

		public DataSet GetHeightOver(string getBegDate,string getEndDate,int getGradeNumber)
		{
			return FillHeightOver(getBegDate,getEndDate,getGradeNumber);
		}

		public DataSet GetWeightOver(string getBegDate,string getEndDate,int getGradeNumber)
		{
			return FillWeightOver(getBegDate,getEndDate,getGradeNumber);
		}

		public DataSet GetHealthAll(string getBegDate,string getEndDate,int getGradeNumber)
		{
			return FillHealthAll(getBegDate,getEndDate,getGradeNumber);
		}

		public DataSet GetWhoTotal(string getBegDate,string getEndDate)
		{
			return FillWhoTotal(getBegDate,getEndDate);
		}

		public DataSet GetStuEnterList(string getGrade,string getClass,string getName,string getNumber,DateTime getDate,string getState)
		{
			return FillStuEnterList(getGrade,getClass,getName,getNumber,getDate,getState);
		}

		public int SaveMorningWatch(HealthMgmt healthMgmt,bool isWatchState )
		{
			saveMorningWatchCommand = "SaveMorningWatch";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(saveMorningWatchCommand);
			dbCommandWrapper.AddInParameter("@getNumber",DbType.String,healthMgmt.WatchNumber);
			dbCommandWrapper.AddInParameter("@getName",DbType.String,healthMgmt.WatchName);
			dbCommandWrapper.AddInParameter("@getHeat",DbType.String,healthMgmt.WatchHeat);
			dbCommandWrapper.AddInParameter("@getSpirit",DbType.String,healthMgmt.WatchSpirit);
			dbCommandWrapper.AddInParameter("@getMouth",DbType.String,healthMgmt.WatchMouth);
			dbCommandWrapper.AddInParameter("@getSkin",DbType.String,healthMgmt.WatchSkin);
			dbCommandWrapper.AddInParameter("@getOState",DbType.String,healthMgmt.WatchOState);
			dbCommandWrapper.AddInParameter("@getTreat",DbType.String,healthMgmt.WatchTreat);
			dbCommandWrapper.AddInParameter("@getDate",DbType.String,healthMgmt.WatchDate);
			dbCommandWrapper.AddInParameter("@getDailyMovement",DbType.String,healthMgmt.DailyMovement);
			dbCommandWrapper.AddInParameter("@getDailySpirit",DbType.String,healthMgmt.DailySpirit);
			dbCommandWrapper.AddInParameter("@getDailyAppetite",DbType.String,healthMgmt.DailyAppetite);
			dbCommandWrapper.AddInParameter("@getDailySleep",DbType.String,healthMgmt.DailySleep);
			dbCommandWrapper.AddInParameter("@getDailyStool",DbType.String,healthMgmt.DailyStool);
			dbCommandWrapper.AddInParameter("@getDailyCough",DbType.String,healthMgmt.DailyCough);
			dbCommandWrapper.AddInParameter("@getDailyElse",DbType.String,healthMgmt.DailyElse);
			dbCommandWrapper.AddInParameter("@getDailyCtrlAct",DbType.Boolean,healthMgmt.DailyCtrlAct);
			dbCommandWrapper.AddInParameter("@getDailyLife",DbType.Boolean,healthMgmt.DailyLife);
			dbCommandWrapper.AddInParameter("@getDailySeafood",DbType.Boolean,healthMgmt.DailySeafood);
			dbCommandWrapper.AddInParameter("@getDailyHeat",DbType.Boolean,healthMgmt.DailyHeat);
			dbCommandWrapper.AddInParameter("@getTeacherSign",DbType.String,healthMgmt.TeacherSign);
			dbCommandWrapper.AddInParameter("@isWatchState",DbType.Boolean,isWatchState);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,32);
			dbHealth.ExecuteNonQuery(dbCommandWrapper);	
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));												  
		}

		public DataSet GetWholeDayWatch(string getGrade,string getClass,string getName,string getNumber,string getBegDate,string getEndDate)
		{
			return FillWholeDayWatch(getGrade,getClass,getName,getNumber,getBegDate,getEndDate);
		}

		public int DeleteWholeDayWatch(string getNumber,string getDate)
		{
			deleteWholeDayWatchCommand = "DeleteWholeDayWatch";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(deleteWholeDayWatchCommand);
			dbCommandWrapper.AddInParameter("@getNumber",DbType.String,getNumber);
			dbCommandWrapper.AddInParameter("@getDate",DbType.String,getDate);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,32);
			dbHealth.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public DataSet GetMedStuInfo(string getGrade,string getClass,string getName,string getNumber,DateTime getDate)
		{
			return FillMedStuInfo(getGrade,getClass,getName,getNumber,getDate);
		}

		public int InsertMed(HealthMgmt healthMgmt)
		{
			insertMedCommand = "InsertMed";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(insertMedCommand);
			dbCommandWrapper.AddInParameter("@getMedName",DbType.String,healthMgmt.MedName);
			dbCommandWrapper.AddInParameter("@getMedType",DbType.String,healthMgmt.MedType);
			dbCommandWrapper.AddInParameter("@getMedTake",DbType.String,healthMgmt.MedTake);
			dbCommandWrapper.AddInParameter("@getMedTaketimes",DbType.Int32,healthMgmt.Taketimes);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,32);
			dbHealth.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public DataSet GetMed(string getMedName,string getMedCategory)
		{	
			return FillMed(getMedName,getMedCategory);
		}

		public int UpdateMed(HealthMgmt healthMgmt)
		{
			updateMedCommand = "UpdateMed";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(updateMedCommand);
			dbCommandWrapper.AddInParameter("@getMedName",DbType.String,healthMgmt.MedName);
			dbCommandWrapper.AddInParameter("@getMedType",DbType.String,healthMgmt.MedType);
			dbCommandWrapper.AddInParameter("@getMedTake",DbType.String,healthMgmt.MedTake);
			dbCommandWrapper.AddInParameter("@getTaketimes",DbType.Int32,healthMgmt.Taketimes);
			dbCommandWrapper.AddInParameter("@getMedModifyID",DbType.Int32,healthMgmt.MedModifyID);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,32);
			dbHealth.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public int DeleteMed(string getMedName,string getMedCategory)
		{
			deleteMedCommand = "DeleteMed";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(deleteMedCommand);
			dbCommandWrapper.AddInParameter("@getMedName",DbType.String,getMedName);
			dbCommandWrapper.AddInParameter("@getMedCategory",DbType.String,getMedCategory);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,32);
			dbHealth.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public int SaveDiagResult(HealthMgmt healthMgmt)
		{
			return FillDiagResult(healthMgmt);
		}

		public DataSet GetDiagInfo(HealthMgmt healthMgmt)
		{
			return FillDiagInfo(healthMgmt);
		}

		public DataSet GetAbnRec(string getGrade,string getClass,string getName,string getNumber,DateTime getBegDate,DateTime getEndDate)
		{
			return FillAbnRec(getGrade,getClass,getName,getNumber,getBegDate,getEndDate);
		}

		public DataSet GetDoseInfo(string getGrade,string getClass,string getName,string getNumber,DateTime getBegDate,DateTime getEndDate,string getTeaSign)
		{
			return FillDoseInfo(getGrade,getClass,getName,getNumber,getBegDate,getEndDate,getTeaSign);
		}

		public DataSet GetDoseRecInfo(int getDiaID,string takeDate,string teaSign)
		{
			return FillDoseRecInfo(getDiaID,takeDate,teaSign);
		}

		public int insertDoseRec(int getDiaID,string getMedName,string getMedTake,string takeDate,string medRule,string teaSign)
		{
			insertDoseRecCommad = "InsertDoseRec";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(insertDoseRecCommad);
			dbCommandWrapper.AddInParameter("@getDiaID",DbType.Int32,getDiaID);
			dbCommandWrapper.AddInParameter("@medName",DbType.String,getMedName);
			dbCommandWrapper.AddInParameter("@medTake",DbType.String,getMedTake);
			dbCommandWrapper.AddInParameter("@takeDate",DbType.String,takeDate);
			dbCommandWrapper.AddInParameter("@medRule",DbType.String,medRule);
			dbCommandWrapper.AddInParameter("@teaSign",DbType.String,teaSign);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,32);
			dbHealth.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public int DeleteDoseRec(int getRecID,string teaSign)
		{
			deleteDoseRecCommand = "DeleteDoseRec";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(deleteDoseRecCommand);
			dbCommandWrapper.AddInParameter("@getRecID",DbType.Int32,getRecID);
			dbCommandWrapper.AddInParameter("@teaSign",DbType.String,teaSign);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,32);
			dbHealth.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public string getTeaName(string getNumber)
		{
			getTeaNameCommand = "GetTeacherName";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getTeaNameCommand);
			dbCommandWrapper.AddInParameter("@getNumber",DbType.String,getNumber);
			return dbHealth.ExecuteDataSet(dbCommandWrapper).Tables[0].Rows[0][0].ToString();
		}

		private DataSet FillStuForHealth(string getGrade,string getClass,string getName,string getNumber,string getGender)
		{
			getStuForHealthCommand = "GetStuForHealth";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getStuForHealthCommand);
			dbCommandWrapper.AddInParameter("@getGrade",DbType.String,getGrade);
			dbCommandWrapper.AddInParameter("@getClass",DbType.String,getClass);
			dbCommandWrapper.AddInParameter("@getName",DbType.String,getName);
			dbCommandWrapper.AddInParameter("@getNumber",DbType.String,getNumber);
			dbCommandWrapper.AddInParameter("@getGender",DbType.String,getGender);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		public DataSet FillNchsHealthAnalyHistory(string getStuID,string getDate)
		{
			getNchsHealthAnalyHistoryCommand = "hm_nchs_gethealthanalyhistory";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getNchsHealthAnalyHistoryCommand);
			dbCommandWrapper.AddInParameter("@getStuID",DbType.String,getStuID);
			dbCommandWrapper.AddInParameter("@getDate",DbType.String,getDate);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillHealthAnalyHistory(string getStuID,string getDate)
		{
			getHealthAnalyHistoryCommand = "GetHealthAnalyHistory";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getHealthAnalyHistoryCommand);
			dbCommandWrapper.AddInParameter("@getStuID",DbType.String,getStuID);
			dbCommandWrapper.AddInParameter("@getDate",DbType.String,getDate);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillHeightAnaly(int getMonth,bool getGender,bool getRegion)
		{
			getHeightAnalyCommand = "GetHeightAnaly";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getHeightAnalyCommand);
			dbCommandWrapper.AddInParameter("@getMonth",DbType.Int32,getMonth);
			dbCommandWrapper.AddInParameter("@getGender",DbType.Boolean,getGender);
			dbCommandWrapper.AddInParameter("@getRegion",DbType.Boolean,getRegion);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillNchsAgeHeightMiddleValue(string getRealAge,int getGender)
		{
			getNchsAgeHeightMiddleValueCommand = "hm_nchs_getageheightmiddlevalue";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getNchsAgeHeightMiddleValueCommand);
			dbCommandWrapper.AddInParameter("@getRealAge",DbType.String,getRealAge);
			dbCommandWrapper.AddInParameter("@getGender",DbType.Int16,getGender);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillNchsAgeHeightCutOffPoint(int getAge,int getMonth,bool getGender)
		{
			getNchsAgeHeightCutOffPointCommand = "hm_nchs_ageheight_cutoffpoint";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getNchsAgeHeightCutOffPointCommand);
			dbCommandWrapper.AddInParameter("@getAge",DbType.Int32,getAge);
			dbCommandWrapper.AddInParameter("@getMonth",DbType.Int32,getMonth);
			dbCommandWrapper.AddInParameter("@getGender",DbType.Boolean,getGender);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillWeightAnaly(int getMonth,bool getGender,bool getRegion)
		{
			getWeightAnalyCommand = "GetWeightAnaly";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getWeightAnalyCommand);
			dbCommandWrapper.AddInParameter("@getMonth",DbType.Int32,getMonth);
			dbCommandWrapper.AddInParameter("@getGender",DbType.Boolean,getGender);
			dbCommandWrapper.AddInParameter("@getRegion",DbType.Boolean,getRegion);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillNchsAgeWeightMiddleValue(string getRealAge,int getGender)
		{
			getNchsAgeWeightMiddleValueCommand = "hm_nchs_getageweightmiddlevalue";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getNchsAgeWeightMiddleValueCommand);
			dbCommandWrapper.AddInParameter("@getRealAge",DbType.String,getRealAge);
			dbCommandWrapper.AddInParameter("@getGender",DbType.Int16,getGender);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillNchsAgeWeightCutOffPoint(int getAge,int getMonth,bool getGender)
		{
			getNchsAgeWeightCutOffPointCommand = "hm_nchs_ageweight_cutoffpoint";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getNchsAgeWeightCutOffPointCommand);
			dbCommandWrapper.AddInParameter("@getAge",DbType.Int32,getAge);
			dbCommandWrapper.AddInParameter("@getMonth",DbType.Int32,getMonth);
			dbCommandWrapper.AddInParameter("@getGender",DbType.Boolean,getGender);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillWhoAnaly(int getHeight,bool getGender)
		{
			getWhoAnalyCommand = "GetWhoAnaly";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getWhoAnalyCommand);
			dbCommandWrapper.AddInParameter("@getHeight",DbType.Int32,getHeight);
			dbCommandWrapper.AddInParameter("@getGender",DbType.Boolean,getGender);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillHeightWeightAnaly(int getHeight, bool getGender)
		{
			getHeightWeightAnalyCommand = "GetHeightWeightAnaly";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getHeightWeightAnalyCommand);
			dbCommandWrapper.AddInParameter("@getHeight",DbType.Int32,getHeight);
			dbCommandWrapper.AddInParameter("@getGender",DbType.Boolean,getGender);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillNchsHeightWeightMiddleValue(double getHeight,int getGender)
		{
			getNchsHeightWeightMiddleValueCommand = "hm_nchs_getheightweightmiddlevalue";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getNchsHeightWeightMiddleValueCommand);
			dbCommandWrapper.AddInParameter("@getHeight",DbType.Double,getHeight);
			dbCommandWrapper.AddInParameter("@getGender",DbType.Int16,getGender);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillNchsHeightWeightCutOffPoint(double getHeight,bool getGender)
		{
			getNchsHeightWeightCutOffPointCommand = "hm_nchs_heightweight_cutoffpoint";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getNchsHeightWeightCutOffPointCommand);
			dbCommandWrapper.AddInParameter("@getHeight",DbType.Double,getHeight);
			dbCommandWrapper.AddInParameter("@getGender",DbType.Boolean,getGender);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillNutAnaly(double getHeight,bool getGender)
		{
			getNutAnalyCommand = "GetNutAnaly";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getNutAnalyCommand);
			dbCommandWrapper.AddInParameter("@getHeight",DbType.Double,getHeight);
			dbCommandWrapper.AddInParameter("@getGender",DbType.Boolean,getGender);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillNchsHealthOutput(HealthMgmt healthMgmt)
		{
			getNchsHealthOutputCommand = "hm_nchs_gethealthoutput";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getNchsHealthOutputCommand);
			dbCommandWrapper.AddInParameter("@getGrade",DbType.String,healthMgmt.OutGrade);
			dbCommandWrapper.AddInParameter("@getClass",DbType.String,healthMgmt.OutClass);
			dbCommandWrapper.AddInParameter("@getName",DbType.String,healthMgmt.OutName);
			dbCommandWrapper.AddInParameter("@getNumber",DbType.String,healthMgmt.OutNumber);
			dbCommandWrapper.AddInParameter("@getGender",DbType.String,healthMgmt.OutGender);
			dbCommandWrapper.AddInParameter("@getBegDate",DbType.String,healthMgmt.OutBegDate);
			dbCommandWrapper.AddInParameter("@getEndDate",DbType.String,healthMgmt.OutEndDate);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillHealthOutput(HealthMgmt healthMgmt)
		{
			getHealthOutputCommand = "GetHealthOutput";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getHealthOutputCommand);
			dbCommandWrapper.AddInParameter("@getGrade",DbType.String,healthMgmt.OutGrade);
			dbCommandWrapper.AddInParameter("@getClass",DbType.String,healthMgmt.OutClass);
			dbCommandWrapper.AddInParameter("@getName",DbType.String,healthMgmt.OutName);
			dbCommandWrapper.AddInParameter("@getNumber",DbType.String,healthMgmt.OutNumber);
			dbCommandWrapper.AddInParameter("@getGender",DbType.String,healthMgmt.OutGender);
			dbCommandWrapper.AddInParameter("@getAge",DbType.String,healthMgmt.OutAge);
			dbCommandWrapper.AddInParameter("@getType",DbType.String,healthMgmt.OutType);
			dbCommandWrapper.AddInParameter("@getResult",DbType.String,healthMgmt.OutResult);
			dbCommandWrapper.AddInParameter("@getBegDate",DbType.String,healthMgmt.OutBegDate);
			dbCommandWrapper.AddInParameter("@getEndDate",DbType.String,healthMgmt.OutEndDate);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		public DataSet FillNchsStudentsOnSummary(string getBegDate,string getEndDate,string getAddr)
		{
			getNchsStudentsOnSummaryCommand = "hm_nchs_onstudentssummary";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getNchsStudentsOnSummaryCommand);
			dbCommandWrapper.AddInParameter("@getBegDate",DbType.String,getBegDate);
			dbCommandWrapper.AddInParameter("@getEndDate",DbType.String,getEndDate);
			dbCommandWrapper.AddInParameter("@getAddr",DbType.String,getAddr);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillNchsHeightOnSummary(string getBegDate,string getEndDate,string getValue,string getAddr)
		{
			getNchsHeightOnSummaryCommand = "hm_nchs_onheightsummary";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getNchsHeightOnSummaryCommand);
			dbCommandWrapper.AddInParameter("@getBegDate",DbType.String,getBegDate);
			dbCommandWrapper.AddInParameter("@getEndDate",DbType.String,getEndDate);
			dbCommandWrapper.AddInParameter("@getValue",DbType.String,getValue);
			dbCommandWrapper.AddInParameter("@getAddr",DbType.String,getAddr);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillNchsHeightUpMiddleOnSummary(string getBegDate,string getEndDate,string getAddr)
		{
			getNchsHeightUpMiddleOnSummaryCommand = "hm_nchs_onheightupmiddlesumary";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getNchsHeightUpMiddleOnSummaryCommand);
			dbCommandWrapper.AddInParameter("@getBegDate",DbType.String,getBegDate);
			dbCommandWrapper.AddInParameter("@getEndDate",DbType.String,getEndDate);
			dbCommandWrapper.AddInParameter("@getAddr",DbType.String,getAddr);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillHeightStat(string getBegDate,string getEndDate,string getHeightAnaly,string getClassName)
		{
			getHeightAnalyStatCommand = "GetHeightStat";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getHeightAnalyStatCommand);
			dbCommandWrapper.AddInParameter("@getBegDate",DbType.String,getBegDate);
			dbCommandWrapper.AddInParameter("@getEndDate",DbType.String,getEndDate);
			dbCommandWrapper.AddInParameter("@getHeightAnaly",DbType.String,getHeightAnaly);
			dbCommandWrapper.AddInParameter("@getClassName",DbType.String,getClassName);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillHeightTotal(string getBegDate,string getEndDate,string getHeightAnaly)
		{
			getHeightAnalyTotalCommand = "GetHeightTotal";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getHeightAnalyTotalCommand);
			dbCommandWrapper.AddInParameter("@getBegDate",DbType.String,getBegDate);
			dbCommandWrapper.AddInParameter("@getEndDate",DbType.String,getEndDate);
			dbCommandWrapper.AddInParameter("@getHeightAnaly",DbType.String,getHeightAnaly);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FilleNchsWeightOnSummary(string getBegDate,string getEndDate,string getValue,string getAddr)
		{
			getNchsWeightOnSummaryCommand = "hm_nchs_onweightsummary";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getNchsWeightOnSummaryCommand);
			dbCommandWrapper.AddInParameter("@getBegDate",DbType.String,getBegDate);
			dbCommandWrapper.AddInParameter("@getEndDate",DbType.String,getEndDate);
			dbCommandWrapper.AddInParameter("@getValue",DbType.String,getValue);
			dbCommandWrapper.AddInParameter("@getAddr",DbType.String,getAddr);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillNchsWeightUpMiddleOnSummary(string getBegDate,string getEndDate,string getAddr)
		{
			getNchsHeightUpMiddleOnSummaryCommand = "hm_nchs_onweightupmiddlesummary";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getNchsHeightUpMiddleOnSummaryCommand);
			dbCommandWrapper.AddInParameter("@getBegDate",DbType.String,getBegDate);
			dbCommandWrapper.AddInParameter("@getEndDate",DbType.String,getEndDate);
			dbCommandWrapper.AddInParameter("@getAddr",DbType.String,getAddr);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillWeightStat(string getBegDate,string getEndDate,string getWeightAnaly,string getClassName)
		{
			getWeightAnalyStatCommand = "GetWeightStat";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getWeightAnalyStatCommand);
			dbCommandWrapper.AddInParameter("@getBegDate",DbType.String,getBegDate);
			dbCommandWrapper.AddInParameter("@getEndDate",DbType.String,getEndDate);
			dbCommandWrapper.AddInParameter("@getWeightAnaly",DbType.String,getWeightAnaly);
			dbCommandWrapper.AddInParameter("@getClassName",DbType.String,getClassName);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillWeightTotal(string getBegDate,string getEndDate,string getWeightAnaly)
		{
			getWeightAnalyTotalCommand = "GetWeightTotal";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getWeightAnalyTotalCommand);
			dbCommandWrapper.AddInParameter("@getBegDate",DbType.String,getBegDate);
			dbCommandWrapper.AddInParameter("@getEndDate",DbType.String,getEndDate);
			dbCommandWrapper.AddInParameter("@getWeightAnaly",DbType.String,getWeightAnaly);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillHeightOver(string getBegDate,string getEndDate,int getGradeNumber)
		{
			getHeightOverCommand = "GetHeightOver";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getHeightOverCommand);
			dbCommandWrapper.AddInParameter("@getBegDate",DbType.String,getBegDate);
			dbCommandWrapper.AddInParameter("@getEndDate",DbType.String,getEndDate);
			dbCommandWrapper.AddInParameter("@getGradeNumber",DbType.Int32,getGradeNumber);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillWeightOver(string getBegDate,string getEndDate,int getGradeNumber)
		{
			getWeightOverCommand = "GetWeightOver";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getWeightOverCommand);
			dbCommandWrapper.AddInParameter("@getBegDate",DbType.String,getBegDate);
			dbCommandWrapper.AddInParameter("@getEndDate",DbType.String,getEndDate);
			dbCommandWrapper.AddInParameter("@getGradeNumber",DbType.Int32,getGradeNumber);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillHealthAll(string getBegDate,string getEndDate,int getGradeNumber)
		{
			getHealthAllCommand = "GetHealthAll";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getHealthAllCommand);
			dbCommandWrapper.AddInParameter("@getBegDate",DbType.String,getBegDate);
			dbCommandWrapper.AddInParameter("@getEndDate",DbType.String,getEndDate);
			dbCommandWrapper.AddInParameter("@getGradeNumber",DbType.Int32,getGradeNumber);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		public DataSet GetFatStat(string beginDate, string endDate)
		{
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper("GetFatStat");
			dbCommandWrapper.AddInParameter("@beginDate",DbType.String,beginDate);
			dbCommandWrapper.AddInParameter("@endDate",DbType.String,endDate);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillWhoTotal(string getBegDate,string getEndDate)
		{
			getWhoTotalCommmand = "GetWhoTotal";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getWhoTotalCommmand);
			dbCommandWrapper.AddInParameter("@getBegDate",DbType.String,getBegDate);
			dbCommandWrapper.AddInParameter("@getEndDate",DbType.String,getEndDate);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillStuEnterList(string getGrade,string getClass,string getName,string getNumber,DateTime getDate,string getState)
		{
			getStuEnterListCommand = "GetStuEnterList";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getStuEnterListCommand);
			dbCommandWrapper.AddInParameter("@getStuGrade",DbType.String,getGrade);
			dbCommandWrapper.AddInParameter("@getStuClass",DbType.String,getClass);
			dbCommandWrapper.AddInParameter("@getStuName",DbType.String,getName);
			dbCommandWrapper.AddInParameter("@getStuNumber",DbType.String,getNumber);
			dbCommandWrapper.AddInParameter("@getDate",DbType.DateTime,getDate);
			dbCommandWrapper.AddInParameter("@getState",DbType.String,getState);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillWholeDayWatch(string getGrade,string getClass,string getName,string getNumber,string getBegDate,string getEndDate )
		{
			getWholeDayWatchCommand = "GetWholeDayWatch";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getWholeDayWatchCommand);
			dbCommandWrapper.AddInParameter("@getGrade",DbType.String,getGrade);
			dbCommandWrapper.AddInParameter("@getClass",DbType.String,getClass);
			dbCommandWrapper.AddInParameter("@getName",DbType.String,getName);
			dbCommandWrapper.AddInParameter("@getNumber",DbType.String,getNumber);
			dbCommandWrapper.AddInParameter("@getBegDate",DbType.String,getBegDate);
			dbCommandWrapper.AddInParameter("@getEndDate",DbType.String,getEndDate);
			DataSet dsWholeDayWatch = dbHealth.ExecuteDataSet(dbCommandWrapper);
			DataColumn orderNumberColumn = new DataColumn("info_stuOrderNumber");
			orderNumberColumn.DataType = System.Type.GetType("System.Int32");
			dsWholeDayWatch.Tables[0].Columns.Add(orderNumberColumn);
			for ( int i=0; i<dsWholeDayWatch.Tables[0].Rows.Count; i++ )
				dsWholeDayWatch.Tables[0].Rows[i][22] = i+1;
			return dsWholeDayWatch;
		}

		private DataSet FillMedStuInfo(string getGrade,string getClass,string getName,string getNumber,DateTime getDate)
		{
			getMedStuInfoCommand = "GetMedStuInfo";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getMedStuInfoCommand);
			dbCommandWrapper.AddInParameter("@getGrade",DbType.String,getGrade);
			dbCommandWrapper.AddInParameter("@getClass",DbType.String,getClass);
			dbCommandWrapper.AddInParameter("@getName",DbType.String,getName);
			dbCommandWrapper.AddInParameter("@getNumber",DbType.String,getNumber);
			dbCommandWrapper.AddInParameter("@getDate",DbType.DateTime,getDate);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillMed(string getMedName,string getMedCategory)
		{
			getMedCommand = "GetMed";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getMedCommand);
			dbCommandWrapper.AddInParameter("@getMedName",DbType.String,getMedName);
			dbCommandWrapper.AddInParameter("@getMedCategory",DbType.String,getMedCategory);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		private int FillDiagResult(HealthMgmt healthMgmt)
		{
			saveDiagResultCommand = "SaveDiagResult";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(saveDiagResultCommand);
			dbCommandWrapper.AddInParameter("@getNumber",DbType.String,healthMgmt.StuNumber);
			dbCommandWrapper.AddInParameter("@getDiagInfo",DbType.String,healthMgmt.DiagInfo);
			dbCommandWrapper.AddInParameter("@getUpperSym",DbType.String,healthMgmt.UpperSym);
			dbCommandWrapper.AddInParameter("@getLungSym",DbType.String,healthMgmt.LungSym);
			dbCommandWrapper.AddInParameter("@getThroatSym",DbType.String,healthMgmt.ThroatSym);
			dbCommandWrapper.AddInParameter("@getEnteronSym",DbType.String,healthMgmt.EnteronSym);
			dbCommandWrapper.AddInParameter("@getAbdomenSym",DbType.String,healthMgmt.AbdomenSym);
			dbCommandWrapper.AddInParameter("@getSkinSym",DbType.String,healthMgmt.SkinSym);
			dbCommandWrapper.AddInParameter("@getFacialSym",DbType.String,healthMgmt.FacialSym);
			dbCommandWrapper.AddInParameter("@getElse",DbType.String,healthMgmt.Else);
			dbCommandWrapper.AddInParameter("@getMedInfo",DbType.String,healthMgmt.MedInfo);
			dbCommandWrapper.AddInParameter("@getTeaSign",DbType.String,healthMgmt.TeacherSign);
			dbCommandWrapper.AddInParameter("@getDate",DbType.DateTime,healthMgmt.RegisterDate);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,32);
			dbHealth.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}
 
		private DataSet FillDiagInfo(HealthMgmt healthMgmt)
		{
			getDiagInfoCommand = "GetDaigInfo";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getDiagInfoCommand);
			dbCommandWrapper.AddInParameter("@getNumber",DbType.String,healthMgmt.StuNumber);
			dbCommandWrapper.AddInParameter("@getDate",DbType.DateTime,healthMgmt.RegisterDate);
			dbCommandWrapper.AddInParameter("@getTeaSign",DbType.String,healthMgmt.TeacherSign);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillAbnRec(string getGrade,string getClass,string getName,string getNumber,DateTime getBegDate,DateTime getEndDate)
		{
			getAbnRecCommand = "GetAbnRec";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getAbnRecCommand);
			dbCommandWrapper.AddInParameter("@getGrade",DbType.String,getGrade);
			dbCommandWrapper.AddInParameter("@getClass",DbType.String,getClass);
			dbCommandWrapper.AddInParameter("@getName",DbType.String,getName);
			dbCommandWrapper.AddInParameter("@getNumber",DbType.String,getNumber);
			dbCommandWrapper.AddInParameter("@getBegDate",DbType.DateTime,getBegDate);
			dbCommandWrapper.AddInParameter("@getEndDate",DbType.DateTime,getEndDate);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillDoseInfo(string getGrade,string getClass,string getName,string getNumber,DateTime getBegDate,DateTime getEndDate,string getTeaSign)
		{
			getDoseInfoCommand = "GetDoseInfo";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getDoseInfoCommand);
			dbCommandWrapper.AddInParameter("@getGrade",DbType.String,getGrade);
			dbCommandWrapper.AddInParameter("@getClass",DbType.String,getClass);
			dbCommandWrapper.AddInParameter("@getName",DbType.String,getName);
			dbCommandWrapper.AddInParameter("@getNumber",DbType.String,getNumber);
			dbCommandWrapper.AddInParameter("@getBegDate",DbType.DateTime,getBegDate);
			dbCommandWrapper.AddInParameter("@getEndDate",DbType.DateTime,getEndDate);
			dbCommandWrapper.AddInParameter("@getTeaSign",DbType.String,getTeaSign);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		public DataSet FillDoseRecInfo(int getDiaID,string takeDate,string teaSign)
		{
			getDoseRecInfoCommand = "GetDoseRecInfo";
			dbCommandWrapper = dbHealth.GetStoredProcCommandWrapper(getDoseRecInfoCommand);
			dbCommandWrapper.AddInParameter("@getDiaID",DbType.Int32,getDiaID);
			dbCommandWrapper.AddInParameter("@takeDate",DbType.String,takeDate);
			dbCommandWrapper.AddInParameter("@teaSign",DbType.String,teaSign);
			return dbHealth.ExecuteDataSet(dbCommandWrapper);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(true);
		}

		protected virtual void Dispose(bool disposing)
		{
			if ( !disposing )
				return ;
			else
			{
				if ( dbHealth != null )
					dbHealth = null;
			}
		}
	}
}
