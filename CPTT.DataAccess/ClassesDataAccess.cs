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

using CPTT.SystemFramework;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace CPTT.DataAccess
{
	/// <summary>
	/// ClassesDataAccess ��ժҪ˵����
	/// </summary>
	public class ClassesDataAccess : IDisposable		
	{
		private Database db = null;
		public ClassesDataAccess()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
			db = DatabaseFactory.CreateDatabase();
		}

        public DataTable GetClassAndGrade()
        {
            DBCommandWrapper dbCommandWrapper = db.GetSqlStringCommandWrapper(@"
SELECT info_gradeName, info_className FROM class_info c INNER JOIN grade_info d ON c.info_gradeNumber = d.info_gradeNumber
WHERE d.info_gradeNumber > 0
ORDER BY d.info_gradeNumber");
            return db.ExecuteDataSet(dbCommandWrapper).Tables[0];
        }

		public DataSet GetClassInfoList()
		{
			DataSet classInfoList;

			try
			{
				DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("GetClass_InfoList");
				
				classInfoList = db.ExecuteDataSet(dbCommandWrapper);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return classInfoList;
		}

		public DataSet GetClassInfo(int classID,int gradeID)
		{
			DataSet classInfo;

			try
			{
				DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("GetClass_Info");
				dbCommandWrapper.AddInParameter("@info_classNumber",DbType.Int32,classID);
				dbCommandWrapper.AddInParameter("@info_gradeNumber",DbType.Int32,gradeID);

				classInfo = db.ExecuteDataSet(dbCommandWrapper);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return classInfo;
		}

		public int InsertClassInfo(Classes classes,string gradeName)
		{
			int rowsAffected = 0;
			DataSet numberList = new DataSet();
			
			try
			{
				DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("InsertClass_Info");
				DBCommandWrapper dbCommand = db.GetStoredProcCommandWrapper("SelectGradeNumber");
				dbCommand.AddInParameter("@info_gradeName",DbType.String,gradeName);
				numberList = db.ExecuteDataSet(dbCommand);
				classes.ClassInfoGradeNumber = Convert.ToInt32(numberList.Tables[0].Rows[0][0]);
				dbCommandWrapper.AddInParameter("@info_classNumber",DbType.Int32,classes.InfoClassNumber);
				dbCommandWrapper.AddInParameter("@info_className",DbType.String,classes.InfoClassName);
				dbCommandWrapper.AddInParameter("@info_gradeNumber",DbType.Int32,classes.ClassInfoGradeNumber);
				dbCommandWrapper.AddInParameter("@info_machineAddr",DbType.Int32,classes.InfoMachineAddr);
				dbCommandWrapper.AddInParameter("@info_classRemark",DbType.String,classes.InfoClassRemark);
				dbCommandWrapper.AddInParameter("@type",DbType.String,classes.ClassType);

				dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);

				db.ExecuteNonQuery(dbCommandWrapper);
				
				rowsAffected = Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
			}
			catch(Exception ex)
			{
				throw ex;
			}
			
			return rowsAffected;
		}

		public int UpdateClassInfo(Classes classes)
		{
			int rowsAffected = 0;

			try
			{
				DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("UpdateClass_Info");
				dbCommandWrapper.AddInParameter("@info_classNumber",DbType.Int32,classes.InfoClassNumber);
				dbCommandWrapper.AddInParameter("@info_className",DbType.String,classes.InfoClassName);
				dbCommandWrapper.AddInParameter("@info_gradeNumber",DbType.Int32,classes.ClassInfoGradeNumber);
				dbCommandWrapper.AddInParameter("@info_machineAddr",DbType.Int32,classes.InfoMachineAddr);
				dbCommandWrapper.AddInParameter("@info_classRemark",DbType.String,classes.InfoClassRemark);
				dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);

				db.ExecuteNonQuery(dbCommandWrapper);
				
				rowsAffected = Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return rowsAffected;
		}

		public int DeleteClassInfo(int classID,int gradeID)
		{
			int rowsAffected = 0;
			
			try
			{
				DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("DeleteClass_Info");
				dbCommandWrapper.AddInParameter("@info_classNumber",DbType.Int32,classID);
				dbCommandWrapper.AddInParameter("@info_gradeNumber",DbType.Int32,gradeID);
				dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);

				db.ExecuteNonQuery(dbCommandWrapper);

				rowsAffected = Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return rowsAffected;
		}
		#region IDisposable ��Ա

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(true); 
		}

		protected virtual void Dispose(bool disposing)
		{
			if (! disposing)
				return; 

			if (db != null)
			{
				db = null;
			}
		}

		#endregion
	}
}
