using System;
using System.Data;
using System.Drawing;
using DevExpress.XtraEditors;
using CPTT.BusinessRule;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// RealtimeInfoPrintSystem 的摘要说明。
	/// </summary>
	public class RealtimeInfoPrintSystem
	{
		private RealtimeInfoPrintRules realTimeInfoPrintRules;
		public RealtimeInfoPrintSystem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			realTimeInfoPrintRules = new RealtimeInfoPrintRules();
		}

		public void RealtimeMorningInfoPrint(DataSet dsRealtimeMorning,string savePath)
		{
			realTimeInfoPrintRules.RealtimeMorningPrint(dsRealtimeMorning,savePath);
		}

		public void RealtimeBackInfoPrint(DataSet dsRealtimeBack,string savePath)
		{
			realTimeInfoPrintRules.RealtimeBackPrint(dsRealtimeBack,savePath);
		}

		public Bitmap RealtimeInfoPrint_Graphic(string getGrade,string getClass,PanelControl pControl,string getState)
		{
			if ( getState.Equals("晨检") )
				return realTimeInfoPrintRules.Pie_MorningInfoStat(getGrade,getClass,DateTime.Now.Date,pControl);
			else
				return realTimeInfoPrintRules.Pie_BackInfoStat(getGrade,getClass,DateTime.Now.Date,pControl);
		}
	}
}
