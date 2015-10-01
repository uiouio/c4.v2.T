//==================================================================================
// 创智智能晨检网络管理系统4.0
//==================================================================================
// Copyright @2005 Shanghai Chuangzhi Toy&Technology Corporation All rights reserved.
//本计算机程序受版权法和国际条约保护.
// 如未经授权而擅自复制或传播本程序(或其中任何部分),将受到严厉的民事及刑事制裁,
//并将在法律许可的范围内受到最大程度的起诉!
//==================================================================================

using System;
using System.Data;

using CPTT.BusinessRule;
using CPTT.DataAccess;
using CPTT.SystemFramework;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// StuCheckInfoSystem 的摘要说明。
	/// </summary>
	public class MorningCheckInfoSystem
	{
		public MorningCheckInfoSystem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public DataSet GetStuRealTimeWindowsInfo(out int sumTotal,DateTime currentDate)
		{
			using(MorningCheckInfoDataAccess da = new MorningCheckInfoDataAccess())
			{
				return da.GetStuRealTimeWindowsInfo(out sumTotal,currentDate);
			}
		}

		public DataSet GetTeaRealTimeWindowsInfo(out int sumTotal,DateTime currentDate)
		{
			using(MorningCheckInfoDataAccess da = new MorningCheckInfoDataAccess())
			{
				return da.GetTeaRealTimeWindowsInfo(out sumTotal,currentDate);
			}
		}

		public DataSet GetTranRealTimeWindowsInfo(DateTime currentDate)
		{
			using(MorningCheckInfoDataAccess da = new MorningCheckInfoDataAccess())
			{
				return da.GetTranRealTimeWindowsInfo(currentDate);
			}
		}

		public int InsertMorningCheckInfo(DataFrame dataFrame)
		{
			return new MorningCheckInfoRules().InsertMorningCheckInfo(dataFrame);
		}
	}
}
