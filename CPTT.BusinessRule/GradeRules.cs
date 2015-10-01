//==================================================================================
// �������ܳ����������ϵͳ4.0
//==================================================================================
// Copyright @2005 Shanghai Chuangzhi Toy&Technology Corporation All rights reserved.
//������������ܰ�Ȩ���͹�����Լ����.
// ��δ����Ȩ�����Ը��ƻ򴫲�������(�������κβ���),���ܵ����������¼������Ʋ�,
//�����ڷ�����ɵķ�Χ���ܵ����̶ȵ�����!
//==================================================================================

using System;

using CPTT.DataAccess;
using CPTT.SystemFramework;

namespace CPTT.BusinessRule
{
	/// <summary>
	/// GradeRules ��ժҪ˵����
	/// </summary>
	public class GradeRules
	{
		public GradeRules()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		public int InsertGradeInfo(Grade grade)
		{
			int rowsAffected = 0;

			using(GradesDataAccess gradesDataAccess = new GradesDataAccess())
			{
				rowsAffected = gradesDataAccess.InsertGradeInfo(grade);
			}

			return rowsAffected;
		}

		public int UpdateGradeInfo(Grade grade)
		{
			int rowsAffected = 0;

			using(GradesDataAccess gradesDataAccess = new GradesDataAccess())
			{
				rowsAffected = gradesDataAccess.UpdateGradeInfo(grade);
			}

			return rowsAffected;
		}

		public int DeleteGradeInfo(int gradeID)
		{
			int rowsAffected = 0;

			using(GradesDataAccess gradesDataAccess = new GradesDataAccess())
			{
				rowsAffected = gradesDataAccess.DeleteGradeInfo(gradeID);
			}

			return rowsAffected;
		}
	}
}
