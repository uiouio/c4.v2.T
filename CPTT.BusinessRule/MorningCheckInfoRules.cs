//==================================================================================
// 创智智能晨检网络管理系统4.0
//==================================================================================
// Copyright @2005 Shanghai Chuangzhi Toy&Technology Corporation All rights reserved.
//本计算机程序受版权法和国际条约保护.
// 如未经授权而擅自复制或传播本程序(或其中任何部分),将受到严厉的民事及刑事制裁,
//并将在法律许可的范围内受到最大程度的起诉!
//==================================================================================

using System;

using CPTT.SystemFramework;
using CPTT.DataAccess;

namespace CPTT.BusinessRule
{
	/// <summary>
	/// StuCheckInfoRules 的摘要说明。
	/// </summary>
	public class MorningCheckInfoRules
	{
		public MorningCheckInfoRules()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public int InsertMorningCheckInfo(DataFrame dataFrame)
		{
			int rowsAffected = 0;
			
			using(MorningCheckInfoDataAccess morningCheckInfoDataAccess = new MorningCheckInfoDataAccess())
			{
				rowsAffected = morningCheckInfoDataAccess.InsertMorningCheckInfo(dataFrame);
			}

			return rowsAffected;
		}
	}
}
