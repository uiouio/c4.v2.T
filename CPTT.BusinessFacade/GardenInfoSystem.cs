using System;
using System.Data;
using CPTT.DataAccess;
using CPTT.SystemFramework;
using CPTT.BusinessRule;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// GardenInfoSystem 的摘要说明。
	/// </summary>
	public class GardenInfoSystem
	{
		public GardenInfoSystem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 调用BusinessRule层插入幼儿园信息
		/// </summary>
		/// <param name="gardenInfo">要插入的GardenInfo</param>
		/// <returns>返回影响的行数</returns>
		public int InsertGardenInfo(GardenInfo gardenInfo)
		{
			return new GardenInfoRule().InsertGardenInfo(gardenInfo);
		}

		/// <summary>
		/// 调用BusinessRule层更新幼儿园信息
		/// </summary>
		/// <param name="gardenInfo">要更改的GardenInfo</param>
		/// <returns>返回影响的行数</returns>
		public int UpdateGardenInfo(GardenInfo gardenInfo)
		{
			return new GardenInfoRule().UpdateGardenInfo(gardenInfo);
		}

		/// <summary>
		/// 调用BusinessRule层删除幼儿园信息
		/// </summary>
		/// <param name="gardenID">要删除的GardenInfo</param>
		/// <returns>返回影响的行数</returns>
		public int DeleteGardenInfo(string gardenID)
		{
			return new GardenInfoRule().DeleteGardenInfo(gardenID);
		}

		/// <summary>
		/// 调用DataAccess层检索幼儿园信息
		/// </summary>
		/// <returns>返回GardenInfo所有信息的DataSet</returns>
		public DataSet GetGardenInfo()
		{
			DataSet gardenInfo = null;
			
			using(GardenInfoDataAccess gardenInfoDataAccess = new GardenInfoDataAccess())
			{
				gardenInfo = gardenInfoDataAccess.GetGardenInfo();
			}

			return gardenInfo;
		}

		public DataSet GetMachineInfo()
		{
			DataSet dsMachineInfo = null;
			
			using(GardenInfoDataAccess gardenInfoDataAccess = new GardenInfoDataAccess())
			{
				dsMachineInfo = gardenInfoDataAccess.GetMachineInfo();
			}

			return dsMachineInfo;
		}

		public int AddNewMachine(int machineAddr)
		{
			using(GardenInfoDataAccess gardenInfoDataAccess = new GardenInfoDataAccess())
			{
				return gardenInfoDataAccess.AddNewMachine(machineAddr);
			}
		}

		public int DeleteMachine(int machineAddr)
		{
			using(GardenInfoDataAccess gardenInfoDataAccess = new GardenInfoDataAccess())
			{
				return gardenInfoDataAccess.DeleteMachine(machineAddr);
			}
		}
	}

}
