using System;
using System.Data;
using System.Drawing;
using CPTT.BusinessRule;
using DevExpress.XtraEditors;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// RealtimeInfoStat_TeacherPrintSystem ��ժҪ˵����
	/// </summary>
	public class RealtimeInfoStat_TeacherPrintSystem
	{
		public RealtimeInfoStat_TeacherPrintSystem()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		public void PrintRealtimeInfoStat_Teacher(DataSet dsRealTimeInfoStat_Teacher,string savePath,string getState)
		{
			if ( getState.Equals("�ϰ����") ) 
				new RealtimeInfoStat_TeacherPrintRules().RealtimeMorningPrint(dsRealTimeInfoStat_Teacher,savePath);
			else
				new RealtimeInfoStat_TeacherPrintRules().RealtimeBackPrint(dsRealTimeInfoStat_Teacher,savePath);
		}

		public Bitmap PrintRealtimeInfoStat_Teacher_Graphic(string getDept,PanelControl pControl,string getState)
		{
			if ( getState.Equals("�ϰ����") )
				return new RealtimeInfoStat_TeacherPrintRules().RealtimeMorningInfoStat_TeacherGraphPrint(getDept,pControl);
			else
				return new RealtimeInfoStat_TeacherPrintRules().RealtimeBackInfoStat_TeacherGraphPrint(getDept,pControl);
		}

	}
}
