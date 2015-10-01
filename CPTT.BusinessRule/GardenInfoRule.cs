//==================================================================================
// �������ܳ����������ϵͳ4.0
//==================================================================================
// Copyright @2005 Shanghai Chuangzhi Toy&Technology Corporation All rights reserved.
//������������ܰ�Ȩ���͹�����Լ����.
// ��δ����Ȩ�����Ը��ƻ򴫲�������(�������κβ���),���ܵ����������¼������Ʋ�,
//�����ڷ�����ɵķ�Χ���ܵ����̶ȵ�����!
//==================================================================================

using System;
using System.Data;
using CPTT.SystemFramework;
using CPTT.DataAccess;

namespace CPTT.BusinessRule
{
	/// <summary>
	/// GardenInfoRule ��ժҪ˵����
	/// </summary>
	public class GardenInfoRule
	{
		public GardenInfoRule()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		/// <summary>
		/// ����DataAccess������׶�԰��Ϣ
		/// </summary>
		/// <param name="gardenInfo">Ҫ�����GardenInfo</param>
		/// <returns>����Ӱ�������</returns>
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
		/// ����DataAccess������׶�԰��Ϣ
		/// </summary>
		/// <param name="gardenInfo">Ҫ���ĵ�GardenInfo</param>
		/// <returns>����Ӱ�������</returns>
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
		/// ����DataAccess��ɾ���׶�԰��Ϣ
		/// </summary>
		/// <param name="gardenID">Ҫɾ����GardenInfo</param>
		/// <returns>����Ӱ�������</returns>
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
