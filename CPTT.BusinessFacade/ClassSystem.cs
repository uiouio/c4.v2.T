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
	/// ClassSyste 的摘要说明。
	/// </summary>
	public class ClassSystem
	{
		public ClassSystem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
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
