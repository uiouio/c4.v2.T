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

using CPTT.DataAccess;
using CPTT.SystemFramework;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace CPTT.DataAccess
{
	/// <summary>
	/// GradesDataAccess ��ժҪ˵����
	/// </summary>
	public class GradesDataAccess : IDisposable
	{
		private Database db = null;
		public GradesDataAccess()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
			db = DatabaseFactory.CreateDatabase();
		}

		public DataSet GetGradeInfoList(int index)
		{
			DataSet gradeInfoList;

			try
			{
				DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("GetGrade_InfoList");
				dbCommandWrapper.AddInParameter("@type",DbType.Int32,index);

				gradeInfoList = db.ExecuteDataSet(dbCommandWrapper);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return gradeInfoList;
		}

		public DataSet GetGradeInfo(int gradeID)
		{
			DataSet gradeInfo;

			try
			{
				DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("GetGrade_Info");
				dbCommandWrapper.AddInParameter("@info_gradeNumber",DbType.Int32,gradeID);

				gradeInfo = db.ExecuteDataSet(dbCommandWrapper);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return gradeInfo;
		}

		public DataSet GetGradeNumber()
		{
			try
			{
				DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("gar_getgradenumber");
				return db.ExecuteDataSet(dbCommandWrapper);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public DataSet GetClassNumber(string gradeName)
		{
			try
			{
				DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("gar_getclassnumber");
				dbCommandWrapper.AddInParameter("@gradeName",DbType.String,gradeName);
				return db.ExecuteDataSet(dbCommandWrapper);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public int InsertGradeInfo(Grade grade)
		{
			int rowsAffected = 0;

			try
			{
				DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("InsertGrade_Info");
				dbCommandWrapper.AddInParameter("@info_gradeName",DbType.String,grade.GradeName);
				dbCommandWrapper.AddInParameter("@info_gradeRemark",DbType.String,grade.GradeRemark);
				dbCommandWrapper.AddInParameter("@info_gradeNumber",DbType.Int32,grade.GradeID);
				dbCommandWrapper.AddInParameter("@gradeType",DbType.String,grade.GradeType);
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

		public int UpdateGradeInfo(Grade grade)
		{
			int rowsAffected = 0;

			try
			{
				DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("UpdateGrade_Info");
				dbCommandWrapper.AddInParameter("@info_gradeNumber",DbType.Int32,grade.GradeID);
				dbCommandWrapper.AddInParameter("@info_gradeName",DbType.String,grade.GradeName);
				dbCommandWrapper.AddInParameter("@info_gradeRemark",DbType.String,grade.GradeRemark);
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

		public int DeleteGradeInfo(int gradeID)
		{
			int rowsAffected = 0;
			
			try
			{
				DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("DeleteGrade_Info");
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

		public DataSet GetGradeNumber(string getGradeName,string getGradeNumber)
		{
			DataSet dsGradeNumber;

			try
			{
				DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper("GetGradeList");
				dbCommandWrapper.AddInParameter("@GradeName",DbType.String,getGradeName);
				dbCommandWrapper.AddInParameter("@GradeNumber",DbType.String,getGradeNumber);
				dsGradeNumber = db.ExecuteDataSet(dbCommandWrapper);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return dsGradeNumber;
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
