using System;
using System.Data;
using CPTT.DataAccess;
using CPTT.SystemFramework;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// ������������ָ��ѧ����Ϣ���ݼ�
	/// </summary>
	public class GetStuInfoByCondition
	{
		public GetStuInfoByCondition()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		public DataSet GetStuInfo(string stuGrade,string stuClass,
			string stuName,string stuNumber)
		{
			using (StuInfoDataAccess stuInfoDataAccess = new StuInfoDataAccess())
			{
				try
				{
					return stuInfoDataAccess.GetStuInfoByCondition(stuGrade,stuClass,
						stuName,stuNumber);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public DataSet getGradeInfo(string gradeName,string gradeNumber)
		{
			using (StuInfoDataAccess stuInfoDataAccess = new StuInfoDataAccess())
			{
				try
				{
					return stuInfoDataAccess.GetGradeList(gradeName,gradeNumber);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public DataSet getClassInfo(string className,string classNumber,string gradeNumber)
		{
			using (StuInfoDataAccess stuInfoDataAccess = new StuInfoDataAccess())
			{
				try
				{
					return stuInfoDataAccess.GetClassList(className,classNumber,gradeNumber);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public DataSet GetExportData(string gradeNumber,string classNumber,string stuNumber,string stuName)
		{
			using (StuInfoDataAccess stuInfoDataAccess = new StuInfoDataAccess())
			{
				try
				{
					return stuInfoDataAccess.GetExportData(gradeNumber,classNumber,stuNumber,stuName);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
			
		}
	}
}
