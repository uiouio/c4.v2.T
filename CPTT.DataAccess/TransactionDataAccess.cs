using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace CPTT.DataAccess
{
	/// <summary>
	/// TransactionDataAccess 的摘要说明。
	/// </summary>
	public class TransactionDataAccess : IDisposable
	{
		private Database db;

		public TransactionDataAccess()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			db = DatabaseFactory.CreateDatabase();
		}
	
		public void DeleteTransaction(int tranID)
		{
			try
			{
				DBCommandWrapper deleteComm = db.GetStoredProcCommandWrapper("DeleteTransactionMessage");
				deleteComm.AddInParameter("@TransactionID",DbType.Int32,tranID);

				db.ExecuteNonQuery(deleteComm);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public DataSet GetTransactionByTNumber(string TNumber)
		{
			DataSet teaTransaction = null;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("GetTransactionMessage");
				dbCom.AddInParameter("@sendTo",DbType.String,TNumber);

				teaTransaction = db.ExecuteDataSet(dbCom);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return teaTransaction;
		}

		public int InsertTransaction(string sendFrom,string sendTo,
			DateTime sendDate,string content,string sendTitle)
		{
			int rowsAffected = 0;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("InsertTransactionMessage");
				dbCom.AddInParameter("@SendFrom",DbType.String,sendFrom);
				dbCom.AddInParameter("@SendTo",DbType.String,sendTo);
				dbCom.AddInParameter("@SendDate ",DbType.DateTime,sendDate);
				dbCom.AddInParameter("@Content",DbType.String,content);
				dbCom.AddInParameter("@Title",DbType.String,sendTitle);
				dbCom.AddInParameter("@HasRead",DbType.String,"○");
				dbCom.AddOutParameter("@TransactionID",DbType.Int32,4);

				db.ExecuteNonQuery(dbCom);

				rowsAffected = Convert.ToInt32(dbCom.GetParameterValue("@TransactionID"));
			}
			catch(Exception ex)
			{
				throw ex;
			}
			
			return rowsAffected;
		}

		public DataSet GetTeaInfoListForTran(string getDept,string getDuty,string getName,string getNumber)
		{
			DataSet dsGetTeaInfoListForTran;
			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("GetTeaInfoListForTran");
				dbCom.AddInParameter("@getTeaDept",DbType.String,getDept);
				dbCom.AddInParameter("@getTeaDuty",DbType.String,getDuty);
				dbCom.AddInParameter("@getTeaName",DbType.String,getName);
				dbCom.AddInParameter("@getTeaNumber",DbType.String,getNumber);

				dsGetTeaInfoListForTran = db.ExecuteDataSet(dbCom); 
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return dsGetTeaInfoListForTran;
		}

		public int GetMsgNumbers(string getTeaNumber)
		{
			int getMsgNumbers = 0;
			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("GetMsgNumbers");
				dbCom.AddInParameter("@getTeaNumber",DbType.String,getTeaNumber);
				dbCom.AddOutParameter("@getMsgNumbers",DbType.Int32,4);
				db.ExecuteNonQuery(dbCom);
				getMsgNumbers = Convert.ToInt32(dbCom.GetParameterValue("@getMsgNumbers"));
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return getMsgNumbers;
		}

		public DataSet TranSearch(string getNumber,string sendFrom,string content,string title,string timeType,string readType)
		{
			DataSet dsTranSearch;
			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("TranSearch");
				dbCom.AddInParameter("@sendFrom",DbType.String,sendFrom);
				dbCom.AddInParameter("@content",DbType.String,content);
				dbCom.AddInParameter("@title",DbType.String,title);
				dbCom.AddInParameter("@timeType",DbType.String,timeType);
				dbCom.AddInParameter("@readType",DbType.String,readType);
				dbCom.AddInParameter("@getDate",DbType.DateTime,DateTime.Now);
				dbCom.AddInParameter("@getNumber",DbType.String,getNumber);
				dsTranSearch = db.ExecuteDataSet(dbCom);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return dsTranSearch;
		}

		public string GetMsgContent(int transactionID)
		{
			string getMsgContent;
			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("GetMsgContent");
				dbCom.AddInParameter("@TransactionID",DbType.Int32,transactionID);
				dbCom.AddOutParameter("@getMsgContent",DbType.String,256);
				db.ExecuteNonQuery(dbCom);
				getMsgContent = dbCom.GetParameterValue("@getMsgContent").ToString();
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return getMsgContent;
		}

		#region IDisposable 成员
		public void Dispose()
		{
			// TODO:  添加 CardInfoDA.Dispose 实现
			if(db != null)
			{
				db = null;
			}

			GC.SuppressFinalize(true);
		}

		#endregion
	}
}
