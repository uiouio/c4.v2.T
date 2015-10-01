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
	/// GradeSystem ��ժҪ˵����
	/// </summary>
	public class GradeSystem
	{
		public GradeSystem()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		public DataSet GetGradeInfoList(int index)
		{
			DataSet gradeInfoList;

			using (GradesDataAccess gradesDataAccess = new GradesDataAccess())
			{
				gradeInfoList = gradesDataAccess.GetGradeInfoList(index);
			}
			
			return gradeInfoList;
		}

		public DataSet GetGradeInfo(int gradeID)
		{
			DataSet gradeInfo;

			using (GradesDataAccess gradesDataAccess = new GradesDataAccess())
			{
				gradeInfo = gradesDataAccess.GetGradeInfo(gradeID);
			}
			
			return gradeInfo;
		}

		public DataSet GetGradeNumber()
		{
			DataSet dsGradeNumber = null;
			using (GradesDataAccess gradesDataAccess = new GradesDataAccess())
			{
				dsGradeNumber = gradesDataAccess.GetGradeNumber();
			}

			return dsGradeNumber;
		}

		public DataSet GetClassNumber(string gradeName)
		{
			DataSet dsClassNumber = null;
			
			using (GradesDataAccess gradesDataAccess = new GradesDataAccess())
			{
				dsClassNumber = gradesDataAccess.GetClassNumber(gradeName);
			}

			return dsClassNumber;
		}

		public int InsertGradeInfo(Grade grade)
		{
			return new GradeRules().InsertGradeInfo(grade);
		}

		public int UpdateGradeInfo(Grade grade)
		{
			return new GradeRules().UpdateGradeInfo(grade);
		}

		public int DeleteGradeInfo(int gradeID)
		{
			return new GradeRules().DeleteGradeInfo(gradeID);
		}
	}
}
