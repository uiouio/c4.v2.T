using System;
using System.Data;
using System.Drawing;
using CPTT.BusinessRule;
using DevExpress.XtraEditors;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// RealtimeInfoStat_TeacherPrintSystem 的摘要说明。
	/// </summary>
	public class RealtimeInfoStat_TeacherPrintSystem
	{
		public RealtimeInfoStat_TeacherPrintSystem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public void PrintRealtimeInfoStat_Teacher(DataSet dsRealTimeInfoStat_Teacher,string savePath,string getState)
		{
			if ( getState.Equals("上班情况") ) 
				new RealtimeInfoStat_TeacherPrintRules().RealtimeMorningPrint(dsRealTimeInfoStat_Teacher,savePath);
			else
				new RealtimeInfoStat_TeacherPrintRules().RealtimeBackPrint(dsRealTimeInfoStat_Teacher,savePath);
		}

		public Bitmap PrintRealtimeInfoStat_Teacher_Graphic(string getDept,PanelControl pControl,string getState)
		{
			if ( getState.Equals("上班情况") )
				return new RealtimeInfoStat_TeacherPrintRules().RealtimeMorningInfoStat_TeacherGraphPrint(getDept,pControl);
			else
				return new RealtimeInfoStat_TeacherPrintRules().RealtimeBackInfoStat_TeacherGraphPrint(getDept,pControl);
		}

	}
}
