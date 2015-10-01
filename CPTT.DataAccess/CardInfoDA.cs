using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using CPTT.SystemFramework;

namespace CPTT.DataAccess
{
	/// <summary>
	/// CardInfoDA 的摘要说明。
	/// </summary>
	public class CardInfoDA : IDisposable
	{
		private Database db;

		public CardInfoDA()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			db = DatabaseFactory.CreateDatabase();
		}

		public DataSet GetStuCardInfoList()
		{
			DataSet CardInfoList = null;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("GetStudent_CardInfoList");

				CardInfoList = db.ExecuteDataSet(dbCom);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return CardInfoList;
		}

		public DataSet GetTeaCardInfoList()
		{
			DataSet CardInfoList = null;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("GetTeacher_CardInfoList");

				CardInfoList = db.ExecuteDataSet(dbCom);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return CardInfoList;
		}

		public DataSet GetStuCardNumberForExcel(string id,string name,string grade,
			string atClass)
		{
			DataSet CardInfoList = null;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("GeStudentCardForExcel");
				dbCom.AddInParameter("@stuID",DbType.String,id);
				dbCom.AddInParameter("@name",DbType.String,name);
				dbCom.AddInParameter("@grade",DbType.String,grade);
				dbCom.AddInParameter("@class",DbType.String,atClass);

				CardInfoList = db.ExecuteDataSet(dbCom);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return CardInfoList;
		}

		public DataSet GetTeaCardNumberForExcel(string id,string name,string grade,
			string atClass)
		{
			DataSet CardInfoList = null;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("GeTeacherCardForExcel");
				dbCom.AddInParameter("@tID",DbType.String,id);
				dbCom.AddInParameter("@name",DbType.String,name);
				dbCom.AddInParameter("@grade",DbType.String,grade);
				dbCom.AddInParameter("@class",DbType.String,atClass);

				CardInfoList = db.ExecuteDataSet(dbCom);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return CardInfoList;
		}

		public DataSet GetStuCardByID(string stuID)
		{
			DataSet cardInfo = null;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("GetStudent_CardInfo");
				dbCom.AddInParameter("@info_stuBasicID",DbType.String,stuID);

				cardInfo = db.ExecuteDataSet(dbCom);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return cardInfo;
		}

		public DataSet GetTeaCardByID(string teaID)
		{
			DataSet cardInfo = null;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("GetTeacher_CardInfo");
				dbCom.AddInParameter("@info_teaBasicID",DbType.String,teaID);

				cardInfo = db.ExecuteDataSet(dbCom);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return cardInfo;
		}

		public DataSet GetBatchCardInfo()
		{
			DataSet batchCardInfoList = null;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("GetStudent_BatchCardInfoList");

				batchCardInfoList = db.ExecuteDataSet(dbCom);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return batchCardInfoList;
		}

		public DataSet GetNoCardStudents()
		{
			DataSet noCardStudents = null;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("GetNoCardStudents");
				
				noCardStudents = db.ExecuteDataSet(dbCom);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return noCardStudents;
		}

		public DataSet GetNoCardTeachers()
		{
			DataSet noCardTeachers = null;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("GetNoCardTeachers");
				
				noCardTeachers = db.ExecuteDataSet(dbCom);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return noCardTeachers;
		}

		public DataSet GetTeaBatchCardInfo()
		{
			DataSet batchCardInfoList = null;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("GetStudent_BatchTeaCardInfoList");

				batchCardInfoList = db.ExecuteDataSet(dbCom);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return batchCardInfoList;
		}

		public int GetCardCount(string cardNumber)
		{
			int rowsAffected = 0;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("GetCardCount");
				dbCom.AddInParameter("@info_stuCardNumber",DbType.String,cardNumber);
				dbCom.AddOutParameter("@rowsAffected",DbType.Int32,4);

				db.ExecuteNonQuery(dbCom);

				rowsAffected = Convert.ToInt32(dbCom.GetParameterValue("@rowsAffected"));
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return rowsAffected;
		}

		public int DeleteCardInfo(string cardNumber)
		{
			int rowsAffected = 0;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("DeleteStudent_CardInfo");

				dbCom.AddInParameter("@info_stuCardNumber",DbType.String,cardNumber);
				dbCom.AddOutParameter("@rowsAffected",DbType.Int32,4);

				db.ExecuteNonQuery(dbCom);

				rowsAffected = Convert.ToInt32(dbCom.GetParameterValue("@rowsAffected"));
				
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return rowsAffected;
		}

		public int DeleteTeaCardInfo(string cardNumber)
		{
			int rowsAffected = 0;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("DeleteTeacher_CardInfo");

				dbCom.AddInParameter("@info_teaCardNumber",DbType.String,cardNumber);
				dbCom.AddOutParameter("@rowsAffected",DbType.Int32,4);

				db.ExecuteNonQuery(dbCom);

				rowsAffected = Convert.ToInt32(dbCom.GetParameterValue("@rowsAffected"));
				
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return rowsAffected;
		}

		//退学
		public int StuLeaveSchool(string id)
		{
			int rowsAffected = 0;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("StuLeaveSchool");

				dbCom.AddInParameter("@info_stuID",DbType.String,id);
				dbCom.AddInParameter("@getDate",DbType.DateTime,DateTime.Now);
				dbCom.AddOutParameter("@rowsAffected",DbType.Int32,4);

				db.ExecuteNonQuery(dbCom);

				rowsAffected = Convert.ToInt32(dbCom.GetParameterValue("@rowsAffected"));
				
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return rowsAffected;
		}

		public int TeaLeaveSchool(string id)
		{
			int rowsAffected = 0;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("TeaLeaveSchool");

				dbCom.AddInParameter("@T_ID",DbType.String,id);
				dbCom.AddOutParameter("@rowsAffected",DbType.Int32,4);

				db.ExecuteNonQuery(dbCom);

				rowsAffected = Convert.ToInt32(dbCom.GetParameterValue("@rowsAffected"));
				
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return rowsAffected;
		}

		public int UpdateCardState(string cardNumber)
		{
			int rowsAffected = 0;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("UpdateCardState");

				dbCom.AddInParameter("@info_stuCardNumber",DbType.String,cardNumber);
				dbCom.AddOutParameter("@rowsAffected",DbType.Int32,4);

				db.ExecuteNonQuery(dbCom);

				rowsAffected = Convert.ToInt32(dbCom.GetParameterValue("@rowsAffected"));
				
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return rowsAffected;
		}

		public int UpdateTeaCardState(string cardNumber)
		{
			int rowsAffected = 0;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("UpdateTeaCardState");

				dbCom.AddInParameter("@info_teaCardNumber",DbType.String,cardNumber);
				dbCom.AddOutParameter("@rowsAffected",DbType.Int32,4);

				db.ExecuteNonQuery(dbCom);

				rowsAffected = Convert.ToInt32(dbCom.GetParameterValue("@rowsAffected"));
				
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return rowsAffected;
		}

		public int InsertCardInfo(CardInfo card)
		{
			int rowsAffected = 0;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("InsertStudent_CardInfo");

				dbCom.AddInParameter("@info_stuBasicID",DbType.String,card.StuID);
				dbCom.AddInParameter("@info_stuCardNumber",DbType.String,card.CardNumber);
				dbCom.AddInParameter("@info_stuCardHolder",DbType.String,card.CardHolder);
				dbCom.AddInParameter("@info_stuCardSendDate",DbType.DateTime,card.CardSendDate);
				dbCom.AddInParameter("@info_stuCardState",DbType.Boolean,card.CardState);
				dbCom.AddInParameter("@info_stuCardSeq",DbType.Int16,card.CardSequence);
				dbCom.AddOutParameter("@rowsAffected",DbType.Int32,4);

				db.ExecuteNonQuery(dbCom);

				rowsAffected = Convert.ToInt32(dbCom.GetParameterValue("@rowsAffected"));
				
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return rowsAffected;
		}

		public int InsertTeaCardInfo(CardInfo card)
		{
			int rowsAffected = 0;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("InsertTeacher_CardInfo");

				dbCom.AddInParameter("@info_teaBasicID",DbType.String,card.StuID);
				dbCom.AddInParameter("@info_teaCardNumber",DbType.String,card.CardNumber);
				dbCom.AddInParameter("@info_teaCardSendDate",DbType.DateTime,card.CardSendDate);
				dbCom.AddInParameter("@info_teaCardState",DbType.Boolean,card.CardState);
				dbCom.AddInParameter("@info_teaCardSeq",DbType.Int16,card.CardSequence);
				dbCom.AddOutParameter("@rowsAffected",DbType.Int32,4);

				db.ExecuteNonQuery(dbCom);

				rowsAffected = Convert.ToInt32(dbCom.GetParameterValue("@rowsAffected"));
				
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return rowsAffected;
		}

		public void DeleteCardInfo(bool isForStudent,string id)
		{
			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("DeleteCardInfo");
				dbCom.AddInParameter("@isForStudent",DbType.Boolean,isForStudent);
				dbCom.AddInParameter("@id",DbType.String,id);
				db.ExecuteNonQuery(dbCom);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public string GetNumberByCard(string card)
		{
			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("GetNumberByCard");
				dbCom.AddInParameter("@card",DbType.String, card);
				dbCom.AddOutParameter("@retval", DbType.Int32, 4);
				db.ExecuteNonQuery(dbCom);
				return dbCom.GetParameterValue("@retval").ToString();
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

//		public DataSet GetAllCardInfo()
//		{
//			DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("GetAllCardInfo");
//			return db.ExecuteDataSet(dbCom);
//		}

		public DataSet GetExportCard()
		{
			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("ExportCardNumber");
				DataSet dsSourceData = db.ExecuteDataSet(dbCom);

				if (dsSourceData.Tables.Count != 6)
				{
					throw new Exception("db error");
				}
				
				return dsSourceData;
			}
			catch(Exception ex)
			{
				throw ex;
			}
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
