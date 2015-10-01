using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace CPTT.DataAccess
{
	/// <summary>
	/// MorningCheckPrintDataAccess ��ժҪ˵����
	/// </summary>
	public class MorningCheckPrintDataAccess :IDisposable
	{
		private Database dbInfoStat = DatabaseFactory.CreateDatabase();
		private DBCommandWrapper dbCommandWrapper;
		private string getMorningCheckInfoCommand = string.Empty;
		public MorningCheckPrintDataAccess()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		public DataSet SetMorningCheckInfoStat(DateTime getBegDate,DateTime getEndDate,string getGrade,
			string getClass,int getState,int needSum)
		{
			return	FillMorningCheckInfoStat(getBegDate,getEndDate,getGrade,getClass,getState,needSum);
		}

		private DataSet FillMorningCheckInfoStat(DateTime getBegDate,DateTime getEndDate,string getGrade,
			string getClass,int getState,int needSum)
		{
			getMorningCheckInfoCommand = "GetInfoStat";
			dbCommandWrapper = dbInfoStat.GetStoredProcCommandWrapper(getMorningCheckInfoCommand);
			dbCommandWrapper.AddInParameter("@getBegDate",DbType.DateTime,getBegDate);
			dbCommandWrapper.AddInParameter("@getEndDate",DbType.DateTime,getEndDate);
			dbCommandWrapper.AddInParameter("@getGrade",DbType.String,getGrade);
			dbCommandWrapper.AddInParameter("@getClass",DbType.String,getClass);
			dbCommandWrapper.AddInParameter("@getState",DbType.Int32,getState);
			dbCommandWrapper.AddInParameter("@needSum",DbType.Int32,needSum);
			return dbInfoStat.ExecuteDataSet(dbCommandWrapper);
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
				if ( dbInfoStat != null )
					dbInfoStat = null;
			}
		}
	}
}
