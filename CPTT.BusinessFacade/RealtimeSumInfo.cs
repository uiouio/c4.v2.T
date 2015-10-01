using System;
using System.Data;
using CPTT.BusinessRule;
using CPTT.DataAccess;
using CPTT.SystemFramework;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// RealtimeSumInfo ��ժҪ˵����
	/// </summary>
	public class RealtimeSumInfo
	{
		private RealtimeInfoRules realTimeInfo;
		public RealtimeSumInfo()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
			realTimeInfo = new RealtimeInfoRules();
		}

		public DataSet getRealtimeMorningInfo(DateTime getDate,string getGrade,string getClass)
		{
			try
			{
				return realTimeInfo.BuildRealtimeMorningInfo(getDate,getGrade,getClass);
			}
			catch(Exception e)
			{
				Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
				return null;
			}
		}

		public DataSet getRealtimeBackInfo(DateTime getDate,string getGrade,string getClass)
		{
			try
			{
				return realTimeInfo.BuildRealtimeBackInfo(getDate,getGrade,getClass);
			}
			catch(Exception e)
			{
				Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
				return null;
			}
		}
	}

}
