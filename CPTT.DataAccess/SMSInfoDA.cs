using System;
using System.Data;
using CPTT.SystemFramework;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace CPTT.DataAccess
{
	/// <summary>
	/// SMSInfoDA 的摘要说明。
	/// </summary>
	public class SMSInfoDA : IDisposable
	{
		private Database db;

		public SMSInfoDA()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			db = DatabaseFactory.CreateDatabase();
		}

		public DataSet GetStuPhoneNum(string stuID)
		{
			DataSet StuPhoneNumList;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("GetSMS_Register_Info");
				dbCom.AddInParameter("@studInfo_stuid ",DbType.String,stuID);

				StuPhoneNumList = db.ExecuteDataSet(dbCom);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return StuPhoneNumList;
		}

		public DataSet GetAllStuPhoneNum()
		{
			DataSet AllStuPhoneNumList;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("GetSMS_Register_InfoList");

				AllStuPhoneNumList = db.ExecuteDataSet(dbCom);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return AllStuPhoneNumList;
		}

		public DataSet GetAllSMSReply()
		{
			DataSet AllSMSReplyList;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("GetSMS_Reply_ContentList");

				AllSMSReplyList = db.ExecuteDataSet(dbCom);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return AllSMSReplyList;
		}

		public DataSet GetAllSMSTemp()
		{
			DataSet AllStuPhoneNumList;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("GetSMS_TempletList");

				AllStuPhoneNumList = db.ExecuteDataSet(dbCom);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return AllStuPhoneNumList;
		}

		public int InsertSMSPhoneNum(string stuID,
			string familialName,string mobilePhoneNum,
			string stuGrade,string stuClass)
		{
			
			int rowsAffected = 0;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("InsertSMS_Register_Info");
				dbCom.AddInParameter("@studInfo_stuid ",DbType.String,stuID);
				dbCom.AddInParameter("@familial_name ",DbType.String,familialName);
				dbCom.AddInParameter("@mobilePhone_number ",DbType.String,mobilePhoneNum);
				dbCom.AddInParameter("@stu_grade ",DbType.String,stuGrade);
				dbCom.AddInParameter("@stu_class ",DbType.String,stuClass);
				dbCom.AddOutParameter("@smsInfo_id",DbType.Int32,4);

				db.ExecuteNonQuery(dbCom);

				rowsAffected = Convert.ToInt32(dbCom.GetParameterValue("@smsInfo_id"));
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return rowsAffected;
		}

		public int InsertSMSTemplate(string name,string content)
		{
			
			int rowsAffected = 0;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("InsertSMS_Templet");
				dbCom.AddInParameter("@templet_name ",DbType.String,name);
				dbCom.AddInParameter("@templet_content ",DbType.String,content);
				dbCom.AddOutParameter("@templet_id",DbType.Int32,4);

				db.ExecuteNonQuery(dbCom);

				rowsAffected = Convert.ToInt32(dbCom.GetParameterValue("@templet_id"));
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return rowsAffected;
		}

		public int DeleteSMSPhoneNum(int smsInfo_id)
		{
			
			int rowsAffected = 0;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("DeleteSMS_Register_Info");
				dbCom.AddInParameter("@smsInfo_id ",DbType.Int32,smsInfo_id);
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

		public int DeleteSMSTemp(int templetID)
		{
			
			int rowsAffected = 0;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("DeleteSMS_Templet");
				dbCom.AddInParameter("@templet_id",DbType.Int32,templetID);
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

		public int DeleteSMSReply(int templetID)
		{
			
			int rowsAffected = 0;

			try
			{
				DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("DeleteSMS_Reply_Content");
				dbCom.AddInParameter("@replyContent_id",DbType.Int32,templetID);
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

		#region IDisposable 成员

		public void Dispose()
		{
			// TODO:  添加 MachinesDA.Dispose 实现
			if(db != null)
			{
				db = null;
			}

			GC.SuppressFinalize(true);
		}

		#endregion
	}
}
