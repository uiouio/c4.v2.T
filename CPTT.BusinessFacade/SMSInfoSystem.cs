using System;
using CPTT.DataAccess;
using System.Data;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// SMSInfoSystem 的摘要说明。
	/// </summary>
	public class SMSInfoSystem
	{
		public SMSInfoSystem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public int InsertSMSPhoneNum(string stuID,
			string familialName,string mobilePhoneNum,
			string stuGrade,string stuClass)
		{
			using(SMSInfoDA smsInfoDA = new SMSInfoDA())
			{
				return smsInfoDA.InsertSMSPhoneNum(stuID,
					familialName,mobilePhoneNum,stuGrade,stuClass);
			}
		}

		public int DeleteSMSTemp(int templetID)
		{
			using(SMSInfoDA smsInfoDA = new SMSInfoDA())
			{
				return smsInfoDA.DeleteSMSTemp(templetID);
			}
		}

		public DataSet GetStuPhoneNum(string stuID)
		{
			using(SMSInfoDA smsInfoDA = new SMSInfoDA())
			{
				return smsInfoDA.GetStuPhoneNum(stuID);
			}
		}

		public DataSet GetAllSMSReply()
		{
			using(SMSInfoDA smsInfoDA = new SMSInfoDA())
			{
				return smsInfoDA.GetAllSMSReply();
			}
		}

		public DataSet GetAllSMSTemp()
		{
			using(SMSInfoDA smsInfoDA = new SMSInfoDA())
			{
				return smsInfoDA.GetAllSMSTemp();
			}
		}

		public DataSet GetAllStuPhoneNum()
		{
			using(SMSInfoDA smsInfoDA = new SMSInfoDA())
			{
				return smsInfoDA.GetAllStuPhoneNum();
			}
		}

		public int DeleteSMSPhoneNum(int smsInfo_id)
		{
			using(SMSInfoDA smsInfoDA = new SMSInfoDA())
			{
				return smsInfoDA.DeleteSMSPhoneNum(smsInfo_id);
			}
		}
		public int DeleteSMSReply(int templetID)
		{
			using(SMSInfoDA smsInfoDA = new SMSInfoDA())
			{
				return smsInfoDA.DeleteSMSReply(templetID);
			}
		}

		public int InsertSMSTemplate(string name,string content)
		{
			using(SMSInfoDA smsInfoDA = new SMSInfoDA())
			{
				return smsInfoDA.InsertSMSTemplate(name,content);
			}
		}
	}
}
