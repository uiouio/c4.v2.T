using System;
using System.Data;
using System.Drawing;
using DevExpress.XtraEditors;
using CPTT.BusinessRule;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// RealtimeInfoPrintSystem ��ժҪ˵����
	/// </summary>
	public class RealtimeInfoPrintSystem
	{
		private RealtimeInfoPrintRules realTimeInfoPrintRules;
		public RealtimeInfoPrintSystem()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
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
			if ( getState.Equals("����") )
				return realTimeInfoPrintRules.Pie_MorningInfoStat(getGrade,getClass,DateTime.Now.Date,pControl);
			else
				return realTimeInfoPrintRules.Pie_BackInfoStat(getGrade,getClass,DateTime.Now.Date,pControl);
		}
	}
}
