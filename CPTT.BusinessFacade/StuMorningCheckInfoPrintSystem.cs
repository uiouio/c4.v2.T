using System;
using System.Data;
using System.Drawing;
using DevExpress.XtraEditors;
using CPTT.BusinessRule;
using CPTT.SystemFramework;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// StuMorningCheckInfoPrintSystem 的摘要说明。
	/// </summary>
	public class StuMorningCheckInfoPrintSystem
	{
		private StuMorningCheckInfoPrintRules stuMorningCheckInfoPrintRules;
		private string getPath = string.Empty;
		private string getDestPath = string.Empty;
		public StuMorningCheckInfoPrintSystem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			stuMorningCheckInfoPrintRules = new StuMorningCheckInfoPrintRules();
		}

		public string GetPath
		{
			get { return this.getPath; }
			set { this.getPath = value; }
		}

		public string GetDestPath
		{
			get { return this.getDestPath; }
			set { this.getDestPath = value; }
		}

		

		public Bitmap MorningCheckInfoStatPrint(DateTime getBegDate,DateTime getEndDate,string getGrade,
			string getClass,string getName,string getNumber,int getPrintType,GroupControl gControl,string savePath)
		{
			stuMorningCheckInfoPrintRules.BegDate = getBegDate;
			stuMorningCheckInfoPrintRules.EndDate = getEndDate;

			if ( getPrintType == 0 )
			{
				stuMorningCheckInfoPrintRules.Excel_InfoStat(getGrade,getClass,savePath);
				return null;
			}

			else if ( getPrintType == 1 )
				return stuMorningCheckInfoPrintRules.Bar_InfoStat(getGrade,getClass,gControl);
				
			else if ( getPrintType == 2 )
				return stuMorningCheckInfoPrintRules.Pie_InfoStat(getGrade,getClass,gControl);

			else if ( getPrintType == 3 )
			{
				stuMorningCheckInfoPrintRules.PrintKidStatInfo(getGrade,getClass,getName,getNumber,savePath);
				return null;
			}
			else
			{
				stuMorningCheckInfoPrintRules.PrintKidDetailInfo(getGrade,getClass,getName,getNumber,savePath);
				return null;
			}

		}

		public void PrintMorningCheckInfo(DataSet dsMorningCheckInfo,string getBegDate,string getEndDate,string savePath)
		{
			stuMorningCheckInfoPrintRules.PrintMorningCheckInfo(dsMorningCheckInfo,getBegDate,getEndDate,savePath);
		}

		public void PrintBackCheckInfo(DataSet dsBackCheckInfo,string getBegDate,string getEndDate,string savePath)
		{
			stuMorningCheckInfoPrintRules.PrintBackCheckInfo(dsBackCheckInfo,getBegDate,getEndDate,savePath);
		}

	}
}
