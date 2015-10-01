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

using CPTT.BusinessRule;
using CPTT.DataAccess;
using CPTT.SystemFramework;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// StuCheckInfoSystem ��ժҪ˵����
	/// </summary>
	public class MorningCheckInfoSystem
	{
		public MorningCheckInfoSystem()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
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
