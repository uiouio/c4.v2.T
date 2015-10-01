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
using System.Data.SqlClient;

using CPTT.DataAccess;
using CPTT.SystemFramework;

namespace CPTT.BusinessRule
{
	/// <summary>
	/// ClassRules ��ժҪ˵����
	/// </summary>
	public class ClassRules
	{
		DataSet ds = new DataSet();
		public ClassRules()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
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
