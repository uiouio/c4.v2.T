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
	/// TeacherBaseRule ��ժҪ˵����
	/// </summary>
	public class TeacherBaseRule
	{
		DataSet ds = new DataSet();
		public TeacherBaseRule()
		{			
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		public int InsertTcBaseInfo(TeacherBase tcBase)
		{
			int rowsAffected = 0;

			using(TeacherBaseDataAccess tcBaseDA = new TeacherBaseDataAccess())
			{
				rowsAffected = tcBaseDA.InsertTcBaseInfo(tcBase);
			}
			
			return rowsAffected;
		}

		public int UpdateTcBaseInfo(TeacherBase tcBase)
		{
			int rowsAffected = 0;

			using(TeacherBaseDataAccess tcBaseDA = new TeacherBaseDataAccess())
			{
				rowsAffected = tcBaseDA.UpdateTcBaseInfo(tcBase);
			}

			return rowsAffected;
		}

		public int DeleteTcBaseInfo(string tID)
		{
			int rowsAffected = 0;

			using(TeacherBaseDataAccess tcBaseDA = new TeacherBaseDataAccess())
			{
				rowsAffected = tcBaseDA.DeleteTcBaseInfo(tID);
			}

			return rowsAffected;
		}

		public DataSet SearchTcBaseInfoByCondition(string gradeName,string className,string tcName,string tcNumber)
		{
			DataSet tcBaseList = null;
			if(gradeName.Equals("ȫ��")){gradeName = "";}
			if(className.Equals("ȫ��")){className = "";}

			if(tcNumber == "")
			{
				if(tcName == "")
				{
					tcBaseList = new TeacherBaseDataAccess().GetTcBaseInfo(gradeName,className,"","");
				}
				else
				{
					tcBaseList = new TeacherBaseDataAccess().GetTcBaseInfo("","",tcName,"");
				}
			}
			else
			{
				tcBaseList = new TeacherBaseDataAccess().GetTcBaseInfo("","","",tcNumber);
			}

			return tcBaseList;
		}
	}
}
