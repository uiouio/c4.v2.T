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
	/// ClassSyste ��ժҪ˵����
	/// </summary>
	public class ClassSystem
	{
		public ClassSystem()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

        public DataTable GetGetClassAndGrade()
        {
            DataTable dt = null;
            try
            {
                dt = new ClassesDataAccess().GetClassAndGrade();
            }
            catch (Exception ex)
            {
                Util.WriteLog(ex.Message, Util.EXCEPTION_LOG_TITLE);
            }
            return dt;
        }

		public DataSet GetClassInfoList()
		{
			DataSet classInfoList;

			using (ClassesDataAccess classDataAccess = new ClassesDataAccess())
			{
				classInfoList = classDataAccess.GetClassInfoList();
			}
			
			return classInfoList;
		}

		public DataSet GetClassInfo(int classID,int gradeID)
		{
			DataSet classInfo;

			using (ClassesDataAccess classDataAccess = new ClassesDataAccess())
			{
				classInfo = classDataAccess.GetClassInfo(classID,gradeID);
			}
			
			return classInfo;
		}

		public int InsertClassInfo(Classes classes,string gradeName)
		{
			return new ClassRules().InsertClassInfo(classes,gradeName);
		}

		public int UpdateClassInfo(Classes classes)
		{
			return new ClassRules().UpdateClassInfo(classes);
		}

		public int DeleteClassInfo(int classID,int gradeID)
		{
			return new ClassRules().DeleteClassInfo(classID,gradeID);
		}
	}
}
