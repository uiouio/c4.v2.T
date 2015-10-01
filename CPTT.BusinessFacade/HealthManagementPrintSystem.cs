using System;
using System.Data;
using CPTT.BusinessRule;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// HealthManagementPrintSystem ��ժҪ˵����
	/// </summary>
	public class HealthManagementPrintSystem
	{
		private HealthManagementPrintRules healthManagementPrintRules;
		public HealthManagementPrintSystem()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
			healthManagementPrintRules = new HealthManagementPrintRules();
		}

		public void PrintHealth(bool printType1st,bool printType2nd,bool printType3rd,
			string getOutputGrade,string getOutputClass,string getOutputName,string getOutputNumber,DataSet dsHealthOutput,
			string getBegDate,string getEndDate,string savePath)
		{
			healthManagementPrintRules.PrintHealth(printType1st,printType2nd,printType3rd,getOutputGrade,getOutputClass,
				getOutputName,getOutputNumber,dsHealthOutput,getBegDate,getEndDate,savePath);
		}

		public void PrintNchsHealthSummary(bool printType1st,bool printType2nd,
			string getOutputGrade,string getOutputClass,string getOutputName,string getOutputNumber,DataSet dsHealthOutput,
			string getBegDate,string getEndDate,string savePath)
		{
			healthManagementPrintRules.PrintNchsHealthSummary(printType1st,printType2nd,getOutputGrade,getOutputClass,
				getOutputName,getOutputNumber,dsHealthOutput,getBegDate,getEndDate,savePath);
		}

		public void PrintNchsHealthPersonal(string getOutputClass,string getOutputName,string getOutputNumber,DataSet dsHealthOutput,
			string getBegDate,string getEndDate,string savePath,string getTeacher)
		{
			healthManagementPrintRules.PrintNchsHealthPersonal(getOutputClass,getOutputName,getOutputNumber,dsHealthOutput,
				getBegDate,getEndDate,savePath,getTeacher);
		}

		public void PrintAbnormalRecord(DataSet dsDailyWatch,string savePath)
		{
			healthManagementPrintRules.PrintAbnormalRecord(dsDailyWatch,savePath);
		}

		public void PrintDoseInfo(DataSet dsDoseInfo,string savePath)
		{
			healthManagementPrintRules.PrintDoseInfo(dsDoseInfo,savePath);
		}
	}
}
