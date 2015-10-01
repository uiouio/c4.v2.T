//==================================================================================
// �������ܳ����������ϵͳ4.0
//==================================================================================
// Copyright @2005 Shanghai Chuangzhi Toy&Technology Corporation All rights reserved.
//������������ܰ�Ȩ���͹�����Լ����.
// ��δ����Ȩ�����Ը��ƻ򴫲�������(�������κβ���),���ܵ����������¼������Ʋ�,
//�����ڷ�����ɵķ�Χ���ܵ����̶ȵ�����!
//==================================================================================

using System;

using CPTT.SystemFramework;
using CPTT.DataAccess;

namespace CPTT.BusinessRule
{
	/// <summary>
	/// StuCheckInfoRules ��ժҪ˵����
	/// </summary>
	public class MorningCheckInfoRules
	{
		public MorningCheckInfoRules()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
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
