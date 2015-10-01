using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace CPTT.DataAccess
{
	/// <summary>
	/// StudentCheckInfoDataAccess 的摘要说明。
	/// </summary>
	public class StudentCheckInfoDataAccess : IDisposable
	{
		private Database dbCheckInfo = DatabaseFactory.CreateDatabase();
		private DBCommandWrapper dbCommandWrapper;
		private string getMorningCheckInfoCommand = string.Empty;
		private string getBackHomeCheckInfoCommand = string.Empty;
		private string getCustomStatusListCommand = string.Empty;
		private string getCustomCheckInfoCommand = string.Empty;
		private string updateMorningStateCommand = string.Empty;
		private string getStuList_GradeClassCommand = string.Empty;
		private string getStuList_NameNumberCommand = string.Empty;
		private string getStuCheckInfo_DetailCommand = string.Empty;
		private string getStuCheckInfo_StatCommand = string.Empty;
		private string getClassNameCommand = string.Empty;
		public StudentCheckInfoDataAccess()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public DataSet GetMorningCheckInfo(string getStuGrade,string getStuClass,string getStuName,string getStuNumber,
			string getBegDate,string getEndDate,string getState)
		{
			return FillMorningCheckInfo(getStuGrade,getStuClass,getStuName,getStuNumber,getBegDate,getEndDate,getState);
		}

		public DataSet GetBackHomeCheckInfo(string getStuGrade,string getStuClass,string getStuName,string getStuNumber,
			string getBegDate,string getEndDate,string getState)
		{
			return FillBackHomeCheckInfo(getStuGrade,getStuClass,getStuName,getStuNumber,getBegDate,getEndDate,getState);
		}

		public DataSet GetCustomStatusList()
		{
			return FillCustomStatusList();
		}

		public DataSet GetCustomCheckInfo(string getStuGrade,string getStuClass,string getStuName,string getStuNumber,
			string getBegDate,string getEndDate,string getState)
		{
			return FillCustomCheckInfo(getStuGrade,getStuClass,getStuName,getStuNumber,getBegDate,getEndDate,getState);
		}

		public DataSet GetStuList_GradeClass(string getGrade,string getClass)
		{
			return FillStuList_GradeClass(getGrade,getClass);
		}

		public DataSet GetStuList_NameNumber(string getName,string getNumber)
		{
			return FillStuList_NameNumber(getName,getNumber);
		}

		public DataSet GetStuCheckInfo_Detail(string getNumber,DateTime getBegDate,DateTime getEndDate)
		{
			
			return FillStuCheckInfo_Detail(getNumber,getBegDate,getEndDate);
		}

		public DataSet GetStuCheckInfo_Stat(string getNumber,DateTime getBegDate,DateTime getEndDate,ref int times)
		{
			return FillStuCheckInfo_Stat(getNumber,getBegDate,getEndDate,ref times);
		}

		public DataSet GetClassName(string getName,string getNumber)
		{
			return FillClassName(getName,getNumber);
		}

		private DataSet FillMorningCheckInfo(string getStuGrade,string getStuClass,string getStuName,string getStuNumber,
			string getBegDate,string getEndDate,string getState)
		{
			getMorningCheckInfoCommand = "GetStuMorningCheckInfo";
			dbCommandWrapper = dbCheckInfo.GetStoredProcCommandWrapper(getMorningCheckInfoCommand);
			dbCommandWrapper.AddInParameter("@getStuGrade",DbType.String,getStuGrade);
			dbCommandWrapper.AddInParameter("@getStuClass",DbType.String,getStuClass);
			dbCommandWrapper.AddInParameter("@getStuName",DbType.String,getStuName);
			dbCommandWrapper.AddInParameter("@getStuNumber",DbType.String,getStuNumber);
			dbCommandWrapper.AddInParameter("@getBegDate",DbType.String,getBegDate);
			dbCommandWrapper.AddInParameter("@getEndDate",DbType.String,getEndDate);
			dbCommandWrapper.AddInParameter("@getState",DbType.String,getState);
			DataSet morningCheckInfoDS = dbCheckInfo.ExecuteDataSet(dbCommandWrapper);
			DataColumn orderNumberColumn = new DataColumn("info_stuOrderNumber");
			orderNumberColumn.DataType = System.Type.GetType("System.Int32");
			morningCheckInfoDS.Tables[0].Columns.Add(orderNumberColumn);
			for(int i=0;i<morningCheckInfoDS.Tables[0].Rows.Count;i++)
				morningCheckInfoDS.Tables[0].Rows[i][7] = i+1;
			return morningCheckInfoDS;
		}

		private DataSet FillBackHomeCheckInfo(string getStuGrade,string getStuClass,string getStuName,string getStuNumber,
			string getBegDate,string getEndDate,string getState)
		{
			getBackHomeCheckInfoCommand = "GetStuBackHomeCheckInfo";
			dbCommandWrapper = dbCheckInfo.GetStoredProcCommandWrapper(getBackHomeCheckInfoCommand);
			dbCommandWrapper.AddInParameter("@getStuGrade",DbType.String,getStuGrade);
			dbCommandWrapper.AddInParameter("@getStuClass",DbType.String,getStuClass);
			dbCommandWrapper.AddInParameter("@getStuName",DbType.String,getStuName);
			dbCommandWrapper.AddInParameter("@getStuNumber",DbType.String,getStuNumber);
			dbCommandWrapper.AddInParameter("@getBegDate",DbType.String,getBegDate);
			dbCommandWrapper.AddInParameter("@getEndDate",DbType.String,getEndDate);
			dbCommandWrapper.AddInParameter("@getState",DbType.String,getState);
			DataSet backHomeCheckInfoDS = dbCheckInfo.ExecuteDataSet(dbCommandWrapper);
			DataColumn orderNumberColumn = new DataColumn("info_stuOrderNumber");
			orderNumberColumn.DataType = System.Type.GetType("System.Int32");
			backHomeCheckInfoDS.Tables[0].Columns.Add(orderNumberColumn);
			for(int i=0;i<backHomeCheckInfoDS.Tables[0].Rows.Count;i++)
				backHomeCheckInfoDS.Tables[0].Rows[i][6] = i+1;
			return backHomeCheckInfoDS;
		}

		private DataSet FillCustomStatusList()
		{
			getCustomStatusListCommand = "GetCustomStatusList";
			dbCommandWrapper = dbCheckInfo.GetStoredProcCommandWrapper(getCustomStatusListCommand);
			return dbCheckInfo.ExecuteDataSet(dbCommandWrapper);
		}

		public DataSet FillCustomCheckInfo(string getStuGrade,string getStuClass,string getStuName,string getStuNumber,
			string getBegDate,string getEndDate,string getState)
		{
			getCustomCheckInfoCommand = "GetStuCustomCheckInfo";
			dbCommandWrapper = dbCheckInfo.GetStoredProcCommandWrapper(getCustomCheckInfoCommand);
			dbCommandWrapper.AddInParameter("@getStuGrade",DbType.String,getStuGrade);
			dbCommandWrapper.AddInParameter("@getStuClass",DbType.String,getStuClass);
			dbCommandWrapper.AddInParameter("@getStuName",DbType.String,getStuName);
			dbCommandWrapper.AddInParameter("@getStuNumber",DbType.String,getStuNumber);
			dbCommandWrapper.AddInParameter("@getBegDate",DbType.String,getBegDate);
			dbCommandWrapper.AddInParameter("@getEndDate",DbType.String,getEndDate);
			dbCommandWrapper.AddInParameter("@getState",DbType.String,getState);
			DataSet customCheckInfoDS = dbCheckInfo.ExecuteDataSet(dbCommandWrapper);
			DataColumn orderNumberColumn = new DataColumn("info_stuOrderNumber");
			orderNumberColumn.DataType = System.Type.GetType("System.Int32");
			customCheckInfoDS.Tables[0].Columns.Add(orderNumberColumn);
			for(int i=0;i<customCheckInfoDS.Tables[0].Rows.Count;i++)
				customCheckInfoDS.Tables[0].Rows[i][6] = i+1;
			return customCheckInfoDS;
		}

		public void DoUpdateState(string getStuNumber,string getStuEnterDate,string getStuState,string getCurRecTime,string getOrigState)
		{
			updateMorningStateCommand = "UpdateState";
			dbCommandWrapper = dbCheckInfo.GetStoredProcCommandWrapper(updateMorningStateCommand);
			dbCommandWrapper.AddInParameter("@stuNumber",DbType.String,getStuNumber);
			dbCommandWrapper.AddInParameter("@stuEnterDate",DbType.String,getStuEnterDate);
			dbCommandWrapper.AddInParameter("@getState",DbType.String,getStuState);
			dbCommandWrapper.AddInParameter("@getOrigState",DbType.String,getOrigState);
			dbCommandWrapper.AddInParameter("@getCurRecTime",DbType.String,getCurRecTime);
			dbCheckInfo.ExecuteNonQuery(dbCommandWrapper);
		}

		private DataSet FillStuList_GradeClass(string getGrade,string getClass)
		{
			getStuList_GradeClassCommand = "GetStuList_GradeClass";
			dbCommandWrapper = dbCheckInfo.GetStoredProcCommandWrapper(getStuList_GradeClassCommand);
			dbCommandWrapper.AddInParameter("@getGrade",DbType.String,getGrade);
			dbCommandWrapper.AddInParameter("@getClass",DbType.String,getClass);
			return dbCheckInfo.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillStuList_NameNumber(string getName,string getNumber)
		{
			getStuList_NameNumberCommand = "GetStuList_NameNumber";
			dbCommandWrapper = dbCheckInfo.GetStoredProcCommandWrapper(getStuList_NameNumberCommand);
			dbCommandWrapper.AddInParameter("@getName",DbType.String,getName);
			dbCommandWrapper.AddInParameter("@getNumber",DbType.String,getNumber);
			return dbCheckInfo.ExecuteDataSet(dbCommandWrapper);
		}
		
		private DataSet FillStuCheckInfo_Detail(string getNumber,DateTime getBegDate,DateTime getEndDate)
		{
			getStuCheckInfo_DetailCommand = "GetStuCheckInfo_Detail";
			dbCommandWrapper = dbCheckInfo.GetStoredProcCommandWrapper(getStuCheckInfo_DetailCommand);
			dbCommandWrapper.AddInParameter("@getNumber",DbType.String,getNumber);
			dbCommandWrapper.AddInParameter("@getBegDate",DbType.DateTime,getBegDate);
			dbCommandWrapper.AddInParameter("@getEndDate",DbType.DateTime,getEndDate);
			return dbCheckInfo.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillStuCheckInfo_Stat(string getNumber,DateTime getBegDate,DateTime getEndDate,ref int times)
		{
			getStuCheckInfo_StatCommand = "GetStuCheckInfo_Stat";
			DataSet dsStuCheckInfo_Stat = null;
			dbCommandWrapper = dbCheckInfo.GetStoredProcCommandWrapper(getStuCheckInfo_StatCommand);
			dbCommandWrapper.AddInParameter("@getNumber",DbType.String,getNumber);
			dbCommandWrapper.AddInParameter("@getBegDate",DbType.DateTime,getBegDate);
			dbCommandWrapper.AddInParameter("@getEndDate",DbType.DateTime,getEndDate);
			dbCommandWrapper.AddOutParameter("@getTimes",DbType.Int32,4);
			dsStuCheckInfo_Stat = dbCheckInfo.ExecuteDataSet(dbCommandWrapper);
			times = Convert.ToInt32(dbCommandWrapper.GetParameterValue("@getTimes"));
			return dsStuCheckInfo_Stat;
		}

		private DataSet FillClassName(string getName,string getNumber)
		{
			getClassNameCommand = "GetClassName";
			dbCommandWrapper = dbCheckInfo.GetStoredProcCommandWrapper(getClassNameCommand);
			dbCommandWrapper.AddInParameter("@getName",DbType.String,getName);
			dbCommandWrapper.AddInParameter("@getNumber",DbType.String,getNumber);
			return dbCheckInfo.ExecuteDataSet(dbCommandWrapper);
		}

		public bool HasCheckInfoOneDay(DateTime date)
		{
			dbCommandWrapper = dbCheckInfo.GetStoredProcCommandWrapper("HasCheckInfo");
			dbCommandWrapper.AddInParameter("@datetime", DbType.DateTime, date);
			dbCommandWrapper.AddOutParameter("@total", DbType.Int32, 4);
			dbCheckInfo.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@total")) > 0;
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
				if ( dbCheckInfo != null )
					dbCheckInfo = null;
			}

		}
	}
}
