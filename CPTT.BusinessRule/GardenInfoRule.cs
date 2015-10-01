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
using CPTT.SystemFramework;
using CPTT.DataAccess;

namespace CPTT.BusinessRule
{
	/// <summary>
	/// GardenInfoRule 的摘要说明。
	/// </summary>
	public class GardenInfoRule
	{
		public GardenInfoRule()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 调用DataAccess层插入幼儿园信息
		/// </summary>
		/// <param name="gardenInfo">要插入的GardenInfo</param>
		/// <returns>返回影响的行数</returns>
		public int InsertGardenInfo(GardenInfo gardenInfo)
		{
			int rowsAffected = 0;
			
			using(GardenInfoDataAccess gardenInfoDataAccess = new GardenInfoDataAccess())
			{
				rowsAffected = gardenInfoDataAccess.InsertGardenInfo(gardenInfo);
			}

			return rowsAffected;
		}

		/// <summary>
		/// 调用DataAccess层更新幼儿园信息
		/// </summary>
		/// <param name="gardenInfo">要更改的GardenInfo</param>
		/// <returns>返回影响的行数</returns>
		public int UpdateGardenInfo(GardenInfo gardenInfo)
		{
			int rowsAffected = 0;
			
			using(GardenInfoDataAccess gardenInfoDataAccess = new GardenInfoDataAccess())
			{
				rowsAffected = gardenInfoDataAccess.UpdateGardenInfo(gardenInfo);
			}

			return rowsAffected;
		}

		/// <summary>
		/// 调用DataAccess层删除幼儿园信息
		/// </summary>
		/// <param name="gardenID">要删除的GardenInfo</param>
		/// <returns>返回影响的行数</returns>
		public int DeleteGardenInfo(string gardenID)
		{
			int rowsAffected = 0;
			
			using(GardenInfoDataAccess gardenInfoDataAccess = new GardenInfoDataAccess())
			{
				rowsAffected = gardenInfoDataAccess.DeleteGardenInfo(gardenID);
			}

			return rowsAffected;
		}
	}
}
