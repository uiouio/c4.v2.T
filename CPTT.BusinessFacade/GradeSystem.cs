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
	/// GradeSystem 的摘要说明。
	/// </summary>
	public class GradeSystem
	{
		public GradeSystem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
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
