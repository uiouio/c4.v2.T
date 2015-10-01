using System;
using System.Data;
using CPTT.SystemFramework;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace CPTT.DataAccess
{
	/// <summary>
	/// 学生信息数据表连接
	/// </summary>
	public class StuInfoDataAccess : IDisposable
	{
		private string getStuInfoCommand = string.Empty;
		private string getGradeInfoCommand = string.Empty;
		private string getClassInfoCommand = string.Empty;
		private string getStuForSelectionCommand = string.Empty;
		private string insertStuBasicInfoCommand = string.Empty;
		private string insertStuDetailInfoCommand = string.Empty;
		private string insertStuParentInfoCommand = string.Empty;
		private string updateStuBasicInfoCommand = string.Empty;
		private string updateStuDetailInfoCommand = string.Empty;
		private string updateStuParentInfoCommand = string.Empty;
		private string deleteStuBasicInfoCommand = string.Empty;
		private string deleteStuDetailInfoCommand = string.Empty;
		private string deleteStuParentInfoCommand = string.Empty;
		private string getExportDataCommand = string.Empty;
		private string hasCardCommand = string.Empty;
		private DBCommandWrapper dbCommandWrapper;
		private Database dbAccess = DatabaseFactory.CreateDatabase();
		public StuInfoDataAccess()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		//获取所有的年级信息
		public DataSet GetGradeList(string gradeName,string gradeNumber)
		{
			return FillGradeData(gradeName,gradeNumber);
		}

		//获取所有班级信息
		public DataSet GetClassList(string className,string classNumber,string gradeNumber)
		{
			return FillClassData(className,classNumber,gradeNumber);
		}

		//根据条件获取学生信息
		public DataSet GetStuInfoByCondition(string stuGrade,string stuClass,
			string stuName,string stuNumber)
		{
			return FillStuInfoData(stuGrade,stuClass,stuName,stuNumber);
		}

		public DataSet GetExportData(string gradeNumber,string classNumber,string stuNumber,string stuName)
		{
			return FillExportData(gradeNumber,classNumber,stuNumber,stuName);
		}

		//查询学生信息表，返回数据集
		private DataSet FillStuInfoData(string stuGrade,string stuClass,
			string stuName,string stuNumber)
		{
			getStuInfoCommand = "GetStudentInfo";
			dbCommandWrapper = dbAccess.GetStoredProcCommandWrapper(getStuInfoCommand);
			dbCommandWrapper.AddInParameter("@StuGrade",DbType.String,stuGrade);
			dbCommandWrapper.AddInParameter("@StuClass",DbType.String,stuClass);
			dbCommandWrapper.AddInParameter("@StuName",DbType.String,stuName);
			dbCommandWrapper.AddInParameter("@StuNumber",DbType.String,stuNumber);
			return dbAccess.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillGradeData(string gradeName,string gradeNumber)
		{
			getGradeInfoCommand = "GetGradeList";
			dbCommandWrapper = dbAccess.GetStoredProcCommandWrapper(getGradeInfoCommand);
			dbCommandWrapper.AddInParameter("@GradeName",DbType.String,gradeName);
			dbCommandWrapper.AddInParameter("@GradeNumber",DbType.String,gradeNumber);
			return dbAccess.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillClassData(string className,string classNumber,string gradeNumber)
		{
			getClassInfoCommand = "GetClassList";
			dbCommandWrapper = dbAccess.GetStoredProcCommandWrapper(getClassInfoCommand);
			dbCommandWrapper.AddInParameter("@ClassName",DbType.String,className);
			dbCommandWrapper.AddInParameter("@ClassNumber",DbType.String,classNumber);
			dbCommandWrapper.AddInParameter("@GradeNumber",DbType.String,gradeNumber);
			return dbAccess.ExecuteDataSet(dbCommandWrapper);
		}

		public void InsertStuBasicInfo(Students students)
		{
			insertStuBasicInfoCommand = "InsertStuBasicInfo";
			dbCommandWrapper = dbAccess.GetStoredProcCommandWrapper(insertStuBasicInfoCommand);
			dbCommandWrapper.AddInParameter("@info_stuID",DbType.String,students.StuGuid);
			dbCommandWrapper.AddInParameter("@info_stuName",DbType.String,students.Name);
			dbCommandWrapper.AddInParameter("@info_stuGrade",DbType.String,students.Grade);
			dbCommandWrapper.AddInParameter("@info_stuClass",DbType.String,students.Class);
			dbCommandWrapper.AddInParameter("@info_stuNumber",DbType.String,students.Number);
			dbCommandWrapper.AddInParameter("@info_stuGender",DbType.String,students.Gender);
			dbCommandWrapper.AddInParameter("@info_stuBirthday",DbType.DateTime,students.Birthday);
			dbCommandWrapper.AddInParameter("@info_stuEntryStatus",DbType.String,students.EntryStatus);
			dbCommandWrapper.AddInParameter("@info_stuEntryDate",DbType.DateTime,students.EntryDate);
			dbAccess.ExecuteNonQuery(dbCommandWrapper);
		}

		public void InsertStuDetailInfo(Students students)
		{
			insertStuDetailInfoCommand = "InsertStuDetailInfo";
			dbCommandWrapper = dbAccess.GetStoredProcCommandWrapper(insertStuDetailInfoCommand);
			dbCommandWrapper.AddInParameter("@info_stuBasicID",DbType.String,students.StuGuid);
			dbCommandWrapper.AddInParameter("@info_stuRegNote",DbType.String,students.RegNote);
			dbCommandWrapper.AddInParameter("@info_stuOrigin",DbType.String,students.Origin);
			dbCommandWrapper.AddInParameter("@info_stuNationality",DbType.String,students.Nationality);
			dbCommandWrapper.AddInParameter("@info_stuNative",DbType.String,students.Native);
			dbCommandWrapper.AddInParameter("@info_stuJieDao",DbType.String,students.JieDao);
			dbCommandWrapper.AddInParameter("@info_stuLiWei",DbType.String,students.LiWei);
			dbCommandWrapper.AddInParameter("@info_stuFamilyAddr",DbType.String,students.FamilyAddr);
			dbCommandWrapper.AddInParameter("@info_stuHuKouAddr",DbType.String,students.HuKouAddr);
			dbCommandWrapper.AddInParameter("@info_stuZipCode",DbType.String,students.ZipCode);
			dbCommandWrapper.AddInParameter("@info_stuSickHistory",DbType.String,students.SickHistory);
			dbCommandWrapper.AddInParameter("@info_stuEMailAddr",DbType.String,students.EMail);
			dbCommandWrapper.AddInParameter("@info_stuBankID",DbType.String,students.BankID);
			dbCommandWrapper.AddInParameter("@info_stuGraphLocation",DbType.Binary,students.GraphLocation);
			dbAccess.ExecuteNonQuery(dbCommandWrapper);
		}

		public void InsertStuParentInfo(Students students)
		{
			insertStuParentInfoCommand = "InsertStuParentInfo";
			dbCommandWrapper = dbAccess.GetStoredProcCommandWrapper(insertStuParentInfoCommand);
			dbCommandWrapper.AddInParameter("@info_stuBasicID",DbType.String,students.StuGuid);
			dbCommandWrapper.AddInParameter("@info_stuFatherName",DbType.String,students.FatherName);
			dbCommandWrapper.AddInParameter("@info_stuFatherLinkPhone",DbType.String,students.FatherPhone);
			dbCommandWrapper.AddInParameter("@info_stuFatherWorkPlace",DbType.String,students.FatherWorkPlace);
			dbCommandWrapper.AddInParameter("@info_stuMotherName",DbType.String,students.MotherName);
			dbCommandWrapper.AddInParameter("@info_stuMotherLinkPhone",DbType.String,students.MotherPhone);
			dbCommandWrapper.AddInParameter("@info_stuMotherWorkPlace",DbType.String,students.MotherWorkPlace);
			dbAccess.ExecuteNonQuery(dbCommandWrapper);
		}

		public void UpdateStuBasicInfo(Students students)
		{
			updateStuBasicInfoCommand = "UpdateStudent_BasicInfo";
			dbCommandWrapper = dbAccess.GetStoredProcCommandWrapper(updateStuBasicInfoCommand);
			dbCommandWrapper.AddInParameter("@info_stuID",DbType.String,students.StuGuid);
			dbCommandWrapper.AddInParameter("@info_stuNumber",DbType.String,students.Number);
			dbCommandWrapper.AddInParameter("@info_stuName",DbType.String,students.Name);
			dbCommandWrapper.AddInParameter("@info_stuGender",DbType.String,students.Gender);
			dbCommandWrapper.AddInParameter("@info_stuBirthday",DbType.DateTime,students.Birthday);
			dbCommandWrapper.AddInParameter("@info_stuEntryStatus",DbType.String,students.EntryStatus);
			dbCommandWrapper.AddInParameter("@info_stuEntryDate",DbType.DateTime,students.EntryDate);
			dbAccess.ExecuteNonQuery(dbCommandWrapper);
		}

		public void UpdateStuDetailInfo(Students students)
		{
			updateStuDetailInfoCommand = "UpdateStudent_DetailInfo";
			dbCommandWrapper = dbAccess.GetStoredProcCommandWrapper(updateStuDetailInfoCommand);
			dbCommandWrapper.AddInParameter("@info_stuBasicID",DbType.String,students.StuGuid);
			dbCommandWrapper.AddInParameter("@info_stuRegNote",DbType.String,students.RegNote);
			dbCommandWrapper.AddInParameter("@info_stuOrigin",DbType.String,students.Origin);
			dbCommandWrapper.AddInParameter("@info_stuNationality",DbType.String,students.Nationality);
			dbCommandWrapper.AddInParameter("@info_stuNative",DbType.String,students.Native);
			dbCommandWrapper.AddInParameter("@info_stuJieDao",DbType.String,students.JieDao);
			dbCommandWrapper.AddInParameter("@info_stuLiWei",DbType.String,students.LiWei);
			dbCommandWrapper.AddInParameter("@info_stuFamilyAddr",DbType.String,students.FamilyAddr);
			dbCommandWrapper.AddInParameter("@info_stuHuKouAddr",DbType.String,students.HuKouAddr);
			dbCommandWrapper.AddInParameter("@info_stuZipCode",DbType.String,students.ZipCode);
			dbCommandWrapper.AddInParameter("@info_stuSickHistory",DbType.String,students.SickHistory);
			dbCommandWrapper.AddInParameter("@info_stuEMailAddr",DbType.String,students.EMail);
			dbCommandWrapper.AddInParameter("@info_stuBankID",DbType.String,students.BankID);
			dbCommandWrapper.AddInParameter("@info_stuGraphLocation",DbType.Binary,students.GraphLocation);
			dbAccess.ExecuteNonQuery(dbCommandWrapper);
		}

		public void UpdateStuParentInfo(Students students)
		{
			updateStuParentInfoCommand = "UpdateStudent_ParentInfo";
			dbCommandWrapper = dbAccess.GetStoredProcCommandWrapper(updateStuParentInfoCommand);
			dbCommandWrapper.AddInParameter("@info_stuBasicID",DbType.String,students.StuGuid);
			dbCommandWrapper.AddInParameter("@info_stuFatherName",DbType.String,students.FatherName);
			dbCommandWrapper.AddInParameter("@info_stuFatherLinkPhone",DbType.String,students.FatherPhone);
			dbCommandWrapper.AddInParameter("@info_stuFatherWorkPlace",DbType.String,students.FatherWorkPlace);
			dbCommandWrapper.AddInParameter("@info_stuMotherName",DbType.String,students.MotherName);
			dbCommandWrapper.AddInParameter("@info_stuMotherLinkPhone",DbType.String,students.MotherPhone);
			dbCommandWrapper.AddInParameter("@info_stuMotherWorkPlace",DbType.String,students.MotherWorkPlace);
			dbAccess.ExecuteNonQuery(dbCommandWrapper);
		}

		public void DeleteStuBasicInfo(Students students)
		{
			deleteStuBasicInfoCommand = "DeleteStudent_BasicInfo";
			dbCommandWrapper = dbAccess.GetStoredProcCommandWrapper(deleteStuBasicInfoCommand);
			dbCommandWrapper.AddInParameter("@info_stuID",DbType.String,students.StuGuid);
			dbAccess.ExecuteNonQuery(dbCommandWrapper);
		}

		public void DeleteStuDetailInfo(Students students)
		{
			deleteStuDetailInfoCommand = "DeleteStudent_DetailInfo";
			dbCommandWrapper = dbAccess.GetStoredProcCommandWrapper(deleteStuDetailInfoCommand);
			dbCommandWrapper.AddInParameter("@info_stuBasicID",DbType.String,students.StuGuid);
			dbAccess.ExecuteNonQuery(dbCommandWrapper);
		}

		public void DeleteStuParentInfo(Students students)
		{
			deleteStuParentInfoCommand = "DeleteStudent_ParentInfo";
			dbCommandWrapper = dbAccess.GetStoredProcCommandWrapper(deleteStuParentInfoCommand);
			dbCommandWrapper.AddInParameter("@info_stuBasicID",DbType.String,students.StuGuid);
			dbAccess.ExecuteNonQuery(dbCommandWrapper);
		}

		public bool HasCard(string stuID,string stuNumber)
		{
			hasCardCommand = "HasCard_Student";
			dbCommandWrapper = dbAccess.GetStoredProcCommandWrapper(hasCardCommand);
			dbCommandWrapper.AddInParameter("@stuID",DbType.String,stuID);
			dbCommandWrapper.AddInParameter("@stuNumber",DbType.String,stuNumber);
			dbCommandWrapper.AddOutParameter("@hasCard",DbType.Boolean,1);
			dbAccess.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToBoolean(dbCommandWrapper.GetParameterValue("@hasCard"));
		}

		public DataSet FillExportData(string gradeNumber,string classNumber,string stuNumber,string stuName)
		{
			getExportDataCommand = "si_getstuexportdata";
			dbCommandWrapper = dbAccess.GetStoredProcCommandWrapper(getExportDataCommand);
			dbCommandWrapper.AddInParameter("@grade",DbType.String,gradeNumber);
			dbCommandWrapper.AddInParameter("@class",DbType.String,classNumber);
			dbCommandWrapper.AddInParameter("@number",DbType.String,stuNumber);
			dbCommandWrapper.AddInParameter("@name",DbType.String,stuName);
			return dbAccess.ExecuteDataSet(dbCommandWrapper);
		}


		//回收调用对象
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(true);
		}

		protected virtual void Dispose(bool disposing)
		{
			if ( !disposing )
				return;
			else
			{
				if ( dbAccess != null )
					dbAccess = null;
			}
		}
	}
}
