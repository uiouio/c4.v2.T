//==================================================================================
// 创智智能晨检网络管理系统4.0
//==================================================================================
// Copyright @2005 Shanghai Chuangzhi Toy&Technology Corporation All rights reserved.
//本计算机程序受版权法和国际条约保护.
// 如未经授权而擅自复制或传播本程序(或其中任何部分),将受到严厉的民事及刑事制裁,
//并将在法律许可的范围内受到最大程度的起诉!
//==================================================================================

using System;

using CPTT.DataAccess;
using CPTT.SystemFramework;

namespace CPTT.BusinessRule
{
	/// <summary>
	/// GradeRules 的摘要说明。
	/// </summary>
	public class GradeRules
	{
		public GradeRules()
		{
			//
			// TODO: 在此处添加构造函数逻辑
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
