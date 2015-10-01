using System;
using System.Data;

using CPTT.DataAccess;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// TransactionSystem 的摘要说明。
	/// </summary>
	public class TransactionSystem
	{
		public TransactionSystem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public void DeleteTransaction(int tranID)
		{
			using(TransactionDataAccess transactionDA = new TransactionDataAccess())
			{
				transactionDA.DeleteTransaction(tranID);
			}
		}

		public DataSet GetTransactionByTNumber(string TNumber)
		{
			using(TransactionDataAccess transactionDA = new TransactionDataAccess())
			{
				return transactionDA.GetTransactionByTNumber(TNumber);
			}
		}

		public int InsertTransaction(string sendFrom,string sendTo,
			DateTime sendDate,string content,string sendTitle)
		{
			using(TransactionDataAccess transactionDA = new TransactionDataAccess())
			{
				return transactionDA.InsertTransaction(sendFrom,sendTo,
					sendDate,content,sendTitle);
			}
		}

		public DataSet GetTeaInfoListForTran(string getDept,string getDuty,string getName,string getNumber)
		{
			using(TransactionDataAccess transactionDA = new TransactionDataAccess())
			{
				return transactionDA.GetTeaInfoListForTran(getDept,getDuty,getName,getNumber);
			}
		}

		public int GetMsgNumbers(string getTeaNumber)
		{
			using ( TransactionDataAccess transactionDA = new TransactionDataAccess() )
			{
				return transactionDA.GetMsgNumbers(getTeaNumber);
			}
		}

		public DataSet TranSearch(string getNumber,string sendFrom,string content,string title,string timeType,string readType)
		{
			using ( TransactionDataAccess transactionDA = new TransactionDataAccess() )
			{
				return transactionDA.TranSearch(getNumber,sendFrom,content,title,timeType,readType);
			}
		}

		public string GetMsgContent(int transactionID)
		{
			using ( TransactionDataAccess transactionDA = new TransactionDataAccess() )
			{
				return transactionDA.GetMsgContent(transactionID);
			}
		}
	}
}
