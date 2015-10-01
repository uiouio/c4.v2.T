using System;
using System.Data;
using CPTT.DataAccess;
using CPTT.SystemFramework;
using CPTT.BusinessRule;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// GardenInfoSystem ��ժҪ˵����
	/// </summary>
	public class GardenInfoSystem
	{
		public GardenInfoSystem()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		/// <summary>
		/// ����BusinessRule������׶�԰��Ϣ
		/// </summary>
		/// <param name="gardenInfo">Ҫ�����GardenInfo</param>
		/// <returns>����Ӱ�������</returns>
		public int InsertGardenInfo(GardenInfo gardenInfo)
		{
			return new GardenInfoRule().InsertGardenInfo(gardenInfo);
		}

		/// <summary>
		/// ����BusinessRule������׶�԰��Ϣ
		/// </summary>
		/// <param name="gardenInfo">Ҫ���ĵ�GardenInfo</param>
		/// <returns>����Ӱ�������</returns>
		public int UpdateGardenInfo(GardenInfo gardenInfo)
		{
			return new GardenInfoRule().UpdateGardenInfo(gardenInfo);
		}

		/// <summary>
		/// ����BusinessRule��ɾ���׶�԰��Ϣ
		/// </summary>
		/// <param name="gardenID">Ҫɾ����GardenInfo</param>
		/// <returns>����Ӱ�������</returns>
		public int DeleteGardenInfo(string gardenID)
		{
			return new GardenInfoRule().DeleteGardenInfo(gardenID);
		}

		/// <summary>
		/// ����DataAccess������׶�԰��Ϣ
		/// </summary>
		/// <returns>����GardenInfo������Ϣ��DataSet</returns>
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
