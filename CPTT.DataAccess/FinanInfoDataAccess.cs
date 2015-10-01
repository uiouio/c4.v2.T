using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;


namespace CPTT.DataAccess
{
	/// <summary>
	/// FinanInfoDataAccess 的摘要说明。
	/// </summary>
	public class FinanInfoDataAccess :IDisposable
	{
		private Database dbContiAbs = DatabaseFactory.CreateDatabase();
		private DBCommandWrapper dbCommandWrapper;
		private string getContiAbsForMessCommand = string.Empty;
		private string getFinanStuInfoCommand = string.Empty;
		private string insertFinanInfoCommand = string.Empty;
		private string getFinanHistoryInfoCommand = string.Empty;
		private string deleteFinanInfoCommand = string.Empty;
		public FinanInfoDataAccess()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public DataSet SetContiAbsForMess(bool getState,string getGrade,string getClass,string getName,
			string getNumber,DateTime balanceMonth,int getNeedRestoreDays)
		{
			return FillContiAbsForMess(getState,getGrade,getClass,getName,getNumber,balanceMonth,
				getNeedRestoreDays);
		}

		public DataSet SetFinanStuInfo(string getGrade,string getClass,string getName,string getNumber)
		{
			return FillFinanStuInfo(getGrade,getClass,getName,getNumber);
		}

		public DataSet GetFinanHistoryInfo(string getGrade,string getClass,string getName,string getNumber,DateTime getDate)
		{
			return FillFinanHistoryInfo(getGrade,getClass,getName,getNumber,getDate);
		}

		private DataSet FillContiAbsForMess(bool getState,string getGrade,string getClass,string getName,
			string getNumber,DateTime balanceMonth,int getNeedRestoreDays)
		{
			getContiAbsForMessCommand = "GetMessRestoreDays";
			dbCommandWrapper = dbContiAbs.GetStoredProcCommandWrapper(getContiAbsForMessCommand);
			dbCommandWrapper.AddInParameter("@getState",DbType.Boolean,getState);
			dbCommandWrapper.AddInParameter("@stuGrade",DbType.String,getGrade);
			dbCommandWrapper.AddInParameter("@stuClass",DbType.String,getClass);
			dbCommandWrapper.AddInParameter("@stuName",DbType.String,getName);
			dbCommandWrapper.AddInParameter("@stuNumber",DbType.String,getNumber);
			dbCommandWrapper.AddInParameter("@balanceMonth",DbType.DateTime,balanceMonth);
			dbCommandWrapper.AddInParameter("@getNeedRestoreDays",DbType.Int16,getNeedRestoreDays);
			return dbContiAbs.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillFinanStuInfo(string getGrade,string getClass,string getName,string getNumber)
		{
			getFinanStuInfoCommand = "GetFinanStuInfo";
			dbCommandWrapper = dbContiAbs.GetStoredProcCommandWrapper(getFinanStuInfoCommand);
			dbCommandWrapper.AddInParameter("@stuGrade",DbType.String,getGrade);
			dbCommandWrapper.AddInParameter("@stuClass",DbType.String,getClass);
			dbCommandWrapper.AddInParameter("@stuName",DbType.String,getName);
			dbCommandWrapper.AddInParameter("@stuNumber",DbType.String,getNumber);
			return dbContiAbs.ExecuteDataSet(dbCommandWrapper);
		}

		public void InsertFinanInfo(DataRow finanInfoRow,DateTime getDate,int getMessRestoreDays,int getAdmRestoreDays)
		{	
			insertFinanInfoCommand = "InsertFinanInfo";
			dbCommandWrapper = dbContiAbs.GetStoredProcCommandWrapper(insertFinanInfoCommand);
			dbCommandWrapper.AddInParameter("@stuNumber",DbType.Int32,Convert.ToInt32(finanInfoRow[0]));
			dbCommandWrapper.AddInParameter("@balanceDate",DbType.DateTime,getDate);
			dbCommandWrapper.AddInParameter("@needHandDays",DbType.Int32,Convert.ToInt32(finanInfoRow[3]));
			dbCommandWrapper.AddInParameter("@messStopDays",DbType.Int32,Convert.ToInt32(finanInfoRow[4]));
			dbCommandWrapper.AddInParameter("@admCharge",DbType.String,finanInfoRow[5].ToString());
			dbCommandWrapper.AddInParameter("@messCharge",DbType.String,finanInfoRow[6].ToString());
			dbCommandWrapper.AddInParameter("@nightCharge",DbType.String,finanInfoRow[7].ToString());
			dbCommandWrapper.AddInParameter("@commCharge",DbType.String,finanInfoRow[8].ToString());
			dbCommandWrapper.AddInParameter("@milkCharge",DbType.String,finanInfoRow[9].ToString());
			dbCommandWrapper.AddInParameter("@extraCharge",DbType.String,finanInfoRow[10].ToString());
			dbCommandWrapper.AddInParameter("@admRestoreCharge",DbType.String,finanInfoRow[11].ToString());
			dbCommandWrapper.AddInParameter("@messRestoreCharge",DbType.String,finanInfoRow[12].ToString());
			dbCommandWrapper.AddInParameter("@currency",DbType.String,finanInfoRow[13].ToString());
			dbCommandWrapper.AddInParameter("@remark",DbType.String,finanInfoRow[14].ToString());
			dbCommandWrapper.AddInParameter("@messRestoreDays",DbType.Int32,getMessRestoreDays);
			dbCommandWrapper.AddInParameter("@admRestoreDays",DbType.Int32,getAdmRestoreDays);
			dbContiAbs.ExecuteNonQuery(dbCommandWrapper);
		}

		public void DeleteFinanInfo(DateTime getDate)
		{
			deleteFinanInfoCommand = "DeleteFinanInfo";
			dbCommandWrapper = dbContiAbs.GetStoredProcCommandWrapper(deleteFinanInfoCommand);
			dbCommandWrapper.AddInParameter("@searchMonth",DbType.DateTime,getDate);
			dbContiAbs.ExecuteNonQuery(dbCommandWrapper);
		}

		private DataSet FillFinanHistoryInfo(string getGrade,string getClass,string getName,string getNumber,DateTime getDate)
		{
			getFinanHistoryInfoCommand = "GetFinanHistoryInfo";
			dbCommandWrapper = dbContiAbs.GetStoredProcCommandWrapper(getFinanHistoryInfoCommand);
			dbCommandWrapper.AddInParameter("@stuGrade",DbType.String,getGrade);
			dbCommandWrapper.AddInParameter("@stuClass",DbType.String,getClass);
			dbCommandWrapper.AddInParameter("@stuName",DbType.String,getName);
			dbCommandWrapper.AddInParameter("@stuNumber",DbType.String,getNumber);
			dbCommandWrapper.AddInParameter("@searchMonth",DbType.String,getDate);
			return dbContiAbs.ExecuteDataSet(dbCommandWrapper);
		}

		public DataTable GetTemplate(string templateName)
		{
			DBCommandWrapper dbComm = dbContiAbs.GetStoredProcCommandWrapper("GetTemplate");
			dbComm.AddInParameter("@templateName", DbType.String, templateName);
			return dbContiAbs.ExecuteDataSet(dbComm).Tables[0];
		}

		public DataTable GetTemplateContents(string templateName)
		{
			DBCommandWrapper dbComm = dbContiAbs.GetStoredProcCommandWrapper("GetTemplateContents");
			dbComm.AddInParameter("@templateName", DbType.String, templateName);
			return dbContiAbs.ExecuteDataSet(dbComm).Tables[0];
		}

		public void AddTemplateContents(int templateId, string templateName, DataRow drTemplateContents, DateTime date)
		{
			DBCommandWrapper dbComm = dbContiAbs.GetStoredProcCommandWrapper("InsertTemplateContents");
			dbComm.AddInParameter("@templateID", DbType.Int32, templateId);
			dbComm.AddInParameter("@templateName", DbType.String, templateName);
			dbComm.AddInParameter("@name", DbType.String, drTemplateContents["费用名"]);
			dbComm.AddInParameter("@fullDays", DbType.String, drTemplateContents["fullDays"]);
			dbComm.AddInParameter("@fullDaysSpend", DbType.String, drTemplateContents["fullDaysSpend"]);
			dbComm.AddInParameter("@halfDaysSpend", DbType.String, drTemplateContents["halfDaysSpend"]);
			dbComm.AddInParameter("@perDaySpend", DbType.String, drTemplateContents["perDaySpend"]);
			dbComm.AddInParameter("@noSpendMonth", DbType.String, drTemplateContents["noSpendMonth"]);
			dbComm.AddInParameter("@halfSpendMonth", DbType.String, drTemplateContents["halfSpendMonth"]);
			dbComm.AddInParameter("@gradeName", DbType.String, drTemplateContents["指定年级"]);
			dbComm.AddInParameter("@className", DbType.String, drTemplateContents["指定班级"]);
			dbComm.AddInParameter("@date", DbType.DateTime, date);
			dbContiAbs.ExecuteNonQuery(dbComm);
		}

		public void DeleteTemplateContents(string name, string grade, string className, int templateId, DateTime date)
		{
			DBCommandWrapper dbComm = dbContiAbs.GetStoredProcCommandWrapper("DeleteTemplateContents");
			dbComm.AddInParameter("@name", DbType.String, name);
			dbComm.AddInParameter("@grade", DbType.String, grade);
			dbComm.AddInParameter("@class", DbType.String, className);
			if (templateId == int.MinValue)
			{	
				dbComm.AddInParameter("@templateId", DbType.Int32, null);
			}
			else
			{
				dbComm.AddInParameter("@templateId", DbType.Int32, templateId);
			}
			if (date == DateTime.MinValue)
			{
				dbComm.AddInParameter("@getDate", DbType.DateTime, null);
			}
			else
			{
				dbComm.AddInParameter("@getDate", DbType.DateTime, date);
			}
			dbContiAbs.ExecuteNonQuery(dbComm);
		}

		public void DeleteTemplate(string templateName)
		{
			DBCommandWrapper dbComm = dbContiAbs.GetStoredProcCommandWrapper("DeleteTemplate");
			dbComm.AddInParameter("@templateName", DbType.String, templateName);
			dbContiAbs.ExecuteNonQuery(dbComm);

			string sql = string.Format("if exists (select * from dbo.sysobjects where id = " +
				"object_id(N'[dbo].[{0}]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) " +
				"drop table [dbo].[{0}]", "FinanceStat_" + templateName);
			dbComm = dbContiAbs.GetStoredProcCommandWrapper("ExecuteDynamicScript");
			dbComm.AddInParameter("@sql", DbType.String, sql);
			dbContiAbs.ExecuteNonQuery(dbComm);
		}

		public DataTable GetStudentPresents(DateTime date, string className)
		{
			DBCommandWrapper dbComm = dbContiAbs.GetStoredProcCommandWrapper("GetStudentPresentsByMonth");
			dbComm.AddInParameter("@date", DbType.DateTime, date);
			dbComm.AddInParameter("@class", DbType.String, className);
			return dbContiAbs.ExecuteDataSet(dbComm).Tables[0];
		}

		public void AddFinanceStatTable(string templateName, DataColumnCollection columns)
		{
			string columnText = string.Empty;
			if (columns.Count >= 4)
			{
				for(int i = 3; i < columns.Count; i++)
				{
					columnText += string.Format("[{0}] [float] NOT NULL ,", columns[i].ColumnName);
				}
			}
			string sql = string.Format("if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[{0}]') " + 
				"and OBJECTPROPERTY(id, N'IsUserTable') = 1) begin " +
				"CREATE TABLE [dbo].[{0}] ([id] [int] IDENTITY (1, 1) NOT NULL ,[stuNumber] [int] NOT NULL ," +
				"[stuName] [char] (10) COLLATE Chinese_PRC_CI_AS NOT NULL ," +
				"[className] [char] (20) COLLATE Chinese_PRC_CI_AS NOT NULL ,{1}" +
				"[logDate] [datetime] NOT NULL ) ON [PRIMARY]" +
				"CREATE  INDEX [IX_{0}] ON [dbo].[{0}]([className], [logDate] DESC ) " +
				"WITH  STATISTICS_NORECOMPUTE  ON [PRIMARY] " +
				"CREATE  INDEX [IX_{0}_1] ON [dbo].[{0}]([stuNumber], [logDate] DESC ) ON [PRIMARY] end", "FinanceStat_" + templateName, columnText);
			DBCommandWrapper dbComm = dbContiAbs.GetStoredProcCommandWrapper("ExecuteDynamicScript");
			dbComm.AddInParameter("@sql", DbType.String, sql);
			dbContiAbs.ExecuteNonQuery(dbComm);
		}

		public void AddFinanceStatHistory(DataTable dtStat, string templateName, DateTime date)
		{
			DataColumnCollection columns = dtStat.Columns;
			
			foreach (DataRow dr in dtStat.Rows)
			{
				string updateColumn = string.Empty;
				string insertColumn = string.Empty;

				if (columns.Count >= 4)
				{
					for(int i = 3; i < columns.Count; i++)
					{
						updateColumn += string.Format("[{0}] = {1},", columns[i].ColumnName, Convert.ToDouble(dr[i]));
						insertColumn += string.Format("{0},", Convert.ToDouble(dr[i]));
					}
				}

				string sql = string.Format("IF EXISTS(SELECT TOP 1 * FROM {0} WHERE stuNumber = {1} AND DATEDIFF(mm, logDate, '{2}') = 0)" +
					"BEGIN UPDATE {0} SET {5} stuName = '{3}', className = '{4}' WHERE stuNumber = {1} " + 
					"AND DATEDIFF(mm, logDate, '{2}') = 0 END ELSE BEGIN INSERT INTO {0} " +
					"VALUES({1}, '{3}', '{4}', {6} CONVERT(VARCHAR(10), '{2}', 120)) END", "FinanceStat_" + templateName,
					Convert.ToInt32(dr["学号"]), date.ToString("yyyy-MM-dd"), dr["姓名"].ToString(), dr["班级"].ToString(),
					updateColumn, insertColumn);

				DBCommandWrapper dbComm = dbContiAbs.GetStoredProcCommandWrapper("ExecuteDynamicScript");
				dbComm.AddInParameter("@sql", DbType.String, sql);
				dbContiAbs.ExecuteNonQuery(dbComm);
			}
		}
		
		public DataTable IsFinanceStatExisted(string templateName)
		{
			string sql = string.Format("if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[{0}]') " + 
				"and OBJECTPROPERTY(id, N'IsUserTable') = 1) begin select 1 as result end else begin select 0 as result end",
				"FinanceStat_" + templateName);
			DBCommandWrapper dbComm = dbContiAbs.GetStoredProcCommandWrapper("ExecuteDynamicScript");
			dbComm.AddInParameter("@sql", DbType.String, sql);
			return dbContiAbs.ExecuteDataSet(dbComm).Tables[0];
		}

		public DataTable GetFinanceStatHistory(string templateName, string className, DateTime date)
		{
			string findSql = string.Format("select * from syscolumns where id=" +
				"(select max(id) from sysobjects where xtype='u' and name='{0}') order by colorder",
				"FinanceStat_" + templateName);
			DBCommandWrapper dbComm = dbContiAbs.GetStoredProcCommandWrapper("ExecuteDynamicScript");
			dbComm.AddInParameter("@sql", DbType.String, findSql);
			DataTable dtColumn = dbContiAbs.ExecuteDataSet(dbComm).Tables[0];
			if (dtColumn == null || dtColumn.Rows.Count == 0)
			{
				throw new Exception(string.Format("table {0} not found", "FinanceStat_" + templateName));
			}
			else
			{
				string columnText = string.Empty;
				string total = string.Empty;
				for (int i = 4; i < dtColumn.Rows.Count - 1; i++)
				{
					columnText += string.Format("[{0}], ", dtColumn.Rows[i]["name"].ToString());
					total += string.Format("ISNULL([{0}], 0) + ", dtColumn.Rows[i]["name"].ToString());
				}

				columnText += total.Substring(0, total.LastIndexOf("+")) + " AS '总计'";	
				string sql = string.Format("SELECT stuNumber AS '学号', stuName AS '姓名', className AS '班级', {3} " +
					"FROM {0} WHERE className = '{1}' AND DATEDIFF(mm, logDate, '{2}') = 0",
					"FinanceStat_" + templateName, className, date, columnText);
				dbComm = dbContiAbs.GetStoredProcCommandWrapper("ExecuteDynamicScript");
				dbComm.AddInParameter("@sql", DbType.String, sql);
				return dbContiAbs.ExecuteDataSet(dbComm).Tables[0];
			}
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
				if ( dbContiAbs != null )
					dbContiAbs = null;
			}
		}
	}
}
