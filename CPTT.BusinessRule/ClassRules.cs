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
using System.Data.SqlClient;

using CPTT.DataAccess;
using CPTT.SystemFramework;

namespace CPTT.BusinessRule
{
	/// <summary>
	/// ClassRules 的摘要说明。
	/// </summary>
	public class ClassRules
	{
		DataSet ds = new DataSet();
		public ClassRules()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public int InsertClassInfo(Classes classes,string gradeName)
		{
			int rowsAffected = 0;

			using(ClassesDataAccess classDataAccess = new ClassesDataAccess())
			{
				rowsAffected = classDataAccess.InsertClassInfo(classes,gradeName);
			}
			
			return rowsAffected;
		}

		public int UpdateClassInfo(Classes classes)
		{
			int rowsAffected = 0;

			using(ClassesDataAccess classDataAccess = new ClassesDataAccess())
			{
				rowsAffected = classDataAccess.UpdateClassInfo(classes);
			}

			return rowsAffected;
		}

		public int DeleteClassInfo(int classID,int gradeID)
		{
			int rowsAffected = 0;

			using(ClassesDataAccess classesDataAccess = new ClassesDataAccess())
			{
				rowsAffected = classesDataAccess.DeleteClassInfo(classID,gradeID);
			}

			return rowsAffected;
		}
	}
}
