using System;
using System.Data;
using CPTT.BusinessRule;
using CPTT.DataAccess;
using CPTT.SystemFramework;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// RealtimeSumInfo 的摘要说明。
	/// </summary>
	public class RealtimeSumInfo
	{
		private RealtimeInfoRules realTimeInfo;
		public RealtimeSumInfo()
		{
			//
			// TODO: 在此处添加构造函数逻辑
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
