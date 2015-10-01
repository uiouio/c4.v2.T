using System;
using System.Data;
using System.Collections;
using CPTT.SystemFramework;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Configuration;
using Microsoft.ApplicationBlocks.Data;

namespace CPTT.DataAccess
{
	/// <summary>
	/// OptionDataAccess 的摘要说明。
	/// </summary>
	public class OptionDataAccess: IDisposable
	{
		private Database dbForBatchCreate = DatabaseFactory.CreateDatabase();
		private DBCommandWrapper dbCommandWrapper;
		private string getGradeInfoCommand = string.Empty;
		private string getClassInfoCommand = string.Empty;
		private string getStuBasicInfoCommand = string.Empty;
		private string getStuCardCommand = string.Empty;
		private string getTeaBasicInfoCommand = string.Empty;
		private string getTeaCardCommand = string.Empty;
		private string getMachineCommand = string.Empty;
		private string updateGradeInfoCommand = string.Empty;
		private string deleteGradeInfoCommand = string.Empty;
		private string updateClassInfoCommand = string.Empty;
		private string deleteClassInfoCommand = string.Empty;
		private string updateStudentInfoCommand = string.Empty;
		private string deleteStudentInfoCommand = string.Empty;
		private string updateStuCardInfoCommand = string.Empty;
		private string deleteStuCardInfoCommand = string.Empty;
		private string updateTeaInfoCommand = string.Empty;
		private string deleteTeaInfoCommand = string.Empty;
		private string updateTeaCardInfoCommand = string.Empty;
		private string deleteTeaCardInfoCommand = string.Empty;
		private string updateMachineInfoCommand = string.Empty;
		private string deleteMachineInfoCommand = string.Empty;
		private string insertStuInfoCommand = string.Empty;
		private string insertStuCardInfoCommand = string.Empty;
		private string insertMachineCommand = string.Empty;
		private string insertTeaInfoCommand = string.Empty;
		private string insertTeaCardInfoCommand = string.Empty;
		private string getStuInfoCommand = string.Empty;
		private string insertNewAddCardInfoCommand = string.Empty;
		private string getGradeNumberListCommand = string.Empty;
		private string getGradeNameByNumberCommand = string.Empty;
		private string updateGradeNameByNumberCommand = string.Empty;
		private string getClassNumberListCommand = string.Empty;
		private string getClassNameByNumberCommand = string.Empty;
		private string updateClassNameByNumberCommand = string.Empty;
		private string updateStudentForGradeChangeCommand = string.Empty;
		private string getIsExistGradeCommand = string.Empty;
		private string getIsExistClassCommand = string.Empty;
		private string insertNewStudentForGradeChangeCommand = string.Empty;
		private string getStuNameByNumberCommand = string.Empty;
		private string backupFllyCommand = string.Empty;
		private string backupDiffCommand = string.Empty;
		private string addBackupJobCommand = string.Empty;
		private Option option;

		public OptionDataAccess()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			option = new Option();
		}

		public DataSet GetGradeList(string gradeName,string gradeNumber,bool isForStu)
		{
			return FillGradeData(gradeName,gradeNumber,isForStu);
		}

		public DataSet GetClassList(string className,string classNumber,string gradeNumber,bool isForStu)
		{
			return FillClassData(className,classNumber,gradeNumber,isForStu);
		}

		public DataSet GetStuBasicInfo(string getGrade,string getClass,string getName,string getNumber)
		{
			return FillStuBasicInfo(getGrade,getClass,getName,getNumber);
		}

		public DataSet GetStuCard(string getGrade,string getClass,string getName,string getNumber,string getCardNumber)
		{
			return FillStuCard(getGrade,getClass,getName,getNumber,getCardNumber);
		}

		public DataSet GetTeaBasicInfo(string getDept,string getDuty,string getName,string getNumber)
		{
			return FillTeaBasicInfo(getDept,getDuty,getName,getNumber);
		}

		public DataSet GetTeaCard(string getDept,string getDuty,string getName,string getNumber,string getCardNumber)
		{
			return FillTeaCard(getDept,getDuty,getName,getNumber,getCardNumber);
		}

		public DataTable GetGradeNameByNumber(string getGradeNumber)
		{
			return InternalGetGradeNameByNumber(getGradeNumber);
		}

		public int UpdateGradeNameByNumber(string getGradeNumber,string getGradeName)
		{
			return InternalUpdateGradeNameByNumber(getGradeNumber,getGradeName);
		}

		public DataTable GetClassNumberList(string getGradeNumber)
		{
			return InternalGetClassNumberList(getGradeNumber);
		}

		public DataTable GetClassNameByNumber(string getGradeNumber,string getClassNumber)
		{
			return InternalGetClassNameByNumber(getGradeNumber,getClassNumber);
		}

		public int UpdateClassNameByNumber(string getGradeNumber,string getClassNumber,string getClassName)
		{
			return InternalUpdateClassNameByNumber(getGradeNumber,getClassNumber,getClassName);
		}

		public int UpdateStudentForGradeChange(string stuName,int stuGrade,int stuClass,string type)
		{
			return InternalUpdateStudentForGradeChange(stuName,stuGrade,stuClass,type);
		}

		public DataTable IsExistGrade(int getGradeNumber)
		{
			return InternalIsExistGrade(getGradeNumber);
		}

		public DataTable IsExistClass(int getGradeNumber,int getClassNumber)
		{
			return InternalIsExistClass(getGradeNumber,getClassNumber);
		}

		public int InsertNewStudentForGradeChange(string stuName,int stuGrade,int stuClass,string stuType)
		{
			return InternalInsertNewStudentForGradeChange(stuName,stuGrade,stuClass,stuType);
		}

		public DataTable GetStuNameByNumber(string stuNumber)
		{
			return InternalGetStuNameByNumber(stuNumber);
		}

		private DataSet FillGradeData(string gradeName,string gradeNumber,bool isForStu)
		{
			getGradeInfoCommand = "GetGradeList_BatchCreate";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(getGradeInfoCommand);
			dbCommandWrapper.AddInParameter("@GradeName",DbType.String,gradeName);
			dbCommandWrapper.AddInParameter("@GradeNumber",DbType.String,gradeNumber);
			dbCommandWrapper.AddInParameter("@isForStu",DbType.Boolean,isForStu);
			return dbForBatchCreate.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillClassData(string className,string classNumber,string gradeNumber,bool isForStu)
		{
			getClassInfoCommand = "GetClassList_BatchCreate";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(getClassInfoCommand);
			dbCommandWrapper.AddInParameter("@ClassName",DbType.String,className);
			dbCommandWrapper.AddInParameter("@ClassNumber",DbType.String,classNumber);
			dbCommandWrapper.AddInParameter("@GradeNumber",DbType.String,gradeNumber);
			dbCommandWrapper.AddInParameter("@isForStu",DbType.Boolean,isForStu);
			return dbForBatchCreate.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillStuBasicInfo(string getGrade,string getClass,string getName,string getNumber)
		{
			getStuBasicInfoCommand = "GetStudentInfo_BatchCreate";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(getStuBasicInfoCommand);
			dbCommandWrapper.AddInParameter("@StuGrade",DbType.String,getGrade);
			dbCommandWrapper.AddInParameter("@StuClass",DbType.String,getClass);
			dbCommandWrapper.AddInParameter("@StuName",DbType.String,getName);
			dbCommandWrapper.AddInParameter("@StuNumber",DbType.String,getNumber);
			return dbForBatchCreate.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillStuCard(string getGrade,string getClass,string getName,string getNumber,string getCardNumber)
		{
			getStuCardCommand = "GetStuCard_BatchCreate";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(getStuCardCommand);
			dbCommandWrapper.AddInParameter("@getGrade",DbType.String,getGrade);
			dbCommandWrapper.AddInParameter("@getClass",DbType.String,getClass);
			dbCommandWrapper.AddInParameter("@getName",DbType.String,getName);
			dbCommandWrapper.AddInParameter("@getNumber",DbType.String,getNumber);
			dbCommandWrapper.AddInParameter("@getCard",DbType.String,getCardNumber);
			return dbForBatchCreate.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillTeaBasicInfo(string getDept,string getDuty,string getName,string getNumber)
		{
			getTeaBasicInfoCommand = "GetTeaBasicInfo_BatchCreate";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(getTeaBasicInfoCommand);
			dbCommandWrapper.AddInParameter("@getDept",DbType.String,getDept);
			dbCommandWrapper.AddInParameter("@getDuty",DbType.String,getDuty);
			dbCommandWrapper.AddInParameter("@getName",DbType.String,getName);
			dbCommandWrapper.AddInParameter("@getNumber",DbType.String,getNumber);
			return dbForBatchCreate.ExecuteDataSet(dbCommandWrapper);
		}

		private DataSet FillTeaCard(string getDept,string getDuty,string getName,string getNumber,string getCardNumber)
		{
			getTeaCardCommand = "GetTeaCard_BatchCreate";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(getTeaCardCommand);
			dbCommandWrapper.AddInParameter("@getDept",DbType.String,getDept);
			dbCommandWrapper.AddInParameter("@getDuty",DbType.String,getDuty);
			dbCommandWrapper.AddInParameter("@getName",DbType.String,getName);
			dbCommandWrapper.AddInParameter("@getNumber",DbType.String,getNumber);
			dbCommandWrapper.AddInParameter("@getCard",DbType.String,getCardNumber);
			return dbForBatchCreate.ExecuteDataSet(dbCommandWrapper);
		}	

		public DataSet GetMachine()
		{
			getMachineCommand = "GetMachineInfo_BatchCreate";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(getMachineCommand);
			return dbForBatchCreate.ExecuteDataSet(dbCommandWrapper);
		}

		public int UpdateGradeInfo(string getOriNumber,string getChNumber,string getChName,string getChRemark)
		{
			updateGradeInfoCommand = "UpdateGradeInfo_BatchCreate";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(updateGradeInfoCommand);
			dbCommandWrapper.AddInParameter("@getOriNumber",DbType.String,getOriNumber);
			dbCommandWrapper.AddInParameter("@getChName",DbType.String,getChName);
			dbCommandWrapper.AddInParameter("@getChNumber",DbType.String,getChNumber);
			dbCommandWrapper.AddInParameter("@getChRemark",DbType.String,getChRemark);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);
			dbForBatchCreate.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public int DeleteGradeInfo(string getOriNumber)
		{
			deleteGradeInfoCommand = "DeleteGradeInfo_BatchCreate";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(deleteGradeInfoCommand);
			dbCommandWrapper.AddInParameter("@getOriNumber",DbType.String,getOriNumber);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);
			dbForBatchCreate.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public int UpdateClassInfo(string getOriClassNumber,string getOriGradeNumber,string getChClassNumber,
			string getChGradeNumber,string getChClassName,string getChRemark)
		{
			updateClassInfoCommand = "UpdateClassInfo_BatchCreate";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(updateClassInfoCommand);
			dbCommandWrapper.AddInParameter("@getOriClassNumber",DbType.String,getOriClassNumber);
			dbCommandWrapper.AddInParameter("@getOriGradeNumber",DbType.String,getOriGradeNumber);
			dbCommandWrapper.AddInParameter("@getChClassNumber",DbType.String,getChClassNumber);
			dbCommandWrapper.AddInParameter("@getChGradeNumber",DbType.String,getChGradeNumber);
			dbCommandWrapper.AddInParameter("@getChClassName",DbType.String,getChClassName);
			dbCommandWrapper.AddInParameter("@getChRemark",DbType.String,getChRemark);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);
			dbForBatchCreate.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public int DeleteClassInfo(string getOriClassNumber,string getOriGradeNumber)
		{
			deleteClassInfoCommand = "DeleteClassInfo_BatchCreate";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(deleteClassInfoCommand);
			dbCommandWrapper.AddInParameter("@getOriClassNumber",DbType.String,getOriClassNumber);
			dbCommandWrapper.AddInParameter("@getOriGradeNumber",DbType.String,getOriGradeNumber);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);
			dbForBatchCreate.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public int UpdateStudentInfo(Option option)
		{
			updateStudentInfoCommand = "UpdateStudentInfo_BatchCreate";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(updateStudentInfoCommand);
			dbCommandWrapper.AddInParameter("@getID",DbType.String,option.StuID);
			dbCommandWrapper.AddInParameter("@getNumber",DbType.String,option.StuNumber);
			dbCommandWrapper.AddInParameter("@getName",DbType.String,option.StuName);
			dbCommandWrapper.AddInParameter("@getGrade",DbType.String,option.StuGrade);
			dbCommandWrapper.AddInParameter("@getClass",DbType.String,option.StuClass);
			dbCommandWrapper.AddInParameter("@getPhone",DbType.String,option.StuPhone);
			dbCommandWrapper.AddInParameter("@getFamilyAddr",DbType.String,option.StuFamilyAddr);
			dbCommandWrapper.AddInParameter("@getBirthday",DbType.DateTime,option.StuBirthday);
			dbCommandWrapper.AddInParameter("@getEnterDate",DbType.DateTime,option.StuEnterDate);
			dbCommandWrapper.AddInParameter("@getEmail",DbType.String,option.StuEmail);
			dbCommandWrapper.AddInParameter("@getZipCode",DbType.String,option.StuZipCode);
			dbCommandWrapper.AddInParameter("@getGender",DbType.String,option.StuGender);
			dbCommandWrapper.AddInParameter("@getEntry",DbType.String,option.StuEntryStatus);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);
			dbForBatchCreate.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public int DeleteStudentInfo(string getID)
		{
			deleteStudentInfoCommand = "DeleteStuInfo_BatchCreate";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(deleteStudentInfoCommand);
			dbCommandWrapper.AddInParameter("@getID",DbType.String,getID);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);
			dbForBatchCreate.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public int UpdateStuCardInfo(string getID,string getNumber,string getHolder,int getSeq,DateTime getDate)
		{
			updateStuCardInfoCommand = "UpdateStuCardInfo_BatchCreate";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(updateStuCardInfoCommand);
			dbCommandWrapper.AddInParameter("@getID",DbType.String,getID);
			dbCommandWrapper.AddInParameter("@getNumber",DbType.String,getNumber);
			dbCommandWrapper.AddInParameter("@getHolder",DbType.String,getHolder);
			dbCommandWrapper.AddInParameter("@getSeq",DbType.Int32,getSeq);
			dbCommandWrapper.AddInParameter("@getDate",DbType.DateTime,getDate);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);
			dbForBatchCreate.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public int DeleteStuCardInfo(string getID,int getSeq)
		{
			deleteStuCardInfoCommand = "DeleteStuCardInfo_BatchCreate";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(deleteStuCardInfoCommand);
			dbCommandWrapper.AddInParameter("@getID",DbType.String,getID);
			dbCommandWrapper.AddInParameter("@getSeq",DbType.Int32,getSeq);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);
			dbForBatchCreate.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public int UpdateTeaInfo(string getID,string getName,string getNumber,string getDept,string getDuty,string getGender)
		{
			updateTeaInfoCommand = "UpdateTeaInfo_BatchCreate";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(updateTeaInfoCommand);
			dbCommandWrapper.AddInParameter("@getID",DbType.String,getID);
			dbCommandWrapper.AddInParameter("@getNumber",DbType.String,getNumber);
			dbCommandWrapper.AddInParameter("@getName",DbType.String,getName);
			dbCommandWrapper.AddInParameter("@getDept",DbType.String,getDept);
			dbCommandWrapper.AddInParameter("@getDuty",DbType.String,@getDuty);
			dbCommandWrapper.AddInParameter("@getGender",DbType.String,@getGender);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);
			dbForBatchCreate.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public int DeleteTeaInfo(string getID,string getNumber)
		{
			deleteTeaInfoCommand = "DeleteTeaInfo_BatchCreate";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(deleteTeaInfoCommand);
			dbCommandWrapper.AddInParameter("@getID",DbType.String,getID);
			dbCommandWrapper.AddInParameter("@getNumber",DbType.String,getNumber);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);
			dbForBatchCreate.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public int UpdateTeaCardInfo(string getID,string getNumber,int getSeq,DateTime getDate)
		{
			updateTeaCardInfoCommand = "UpdateTeaCardInfo_BatchCreate";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(updateTeaCardInfoCommand);
			dbCommandWrapper.AddInParameter("@getID",DbType.String,getID);
			dbCommandWrapper.AddInParameter("@getNumber",DbType.String,getNumber);
			dbCommandWrapper.AddInParameter("@getSeq",DbType.Int32,getSeq);
			dbCommandWrapper.AddInParameter("@getDate",DbType.DateTime,getDate);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);
			dbForBatchCreate.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public int DeleteTeaCardInfo(string getID,int getSeq)
		{
			deleteTeaCardInfoCommand = "DeleteTeaCardInfo_BatchCreate";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(deleteTeaCardInfoCommand);
			dbCommandWrapper.AddInParameter("@getID",DbType.String,getID);
			dbCommandWrapper.AddInParameter("@getSeq",DbType.Int32,getSeq);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);
			dbForBatchCreate.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		
		public int UpdateMachineInfo(int getOriMachineAddr,int getOriMachineType,int getChMachineAddr,int getChMachineType,int getChMachineVol)
		{
			updateMachineInfoCommand = "UpdateMachine_BatchCreate";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(updateMachineInfoCommand);
			dbCommandWrapper.AddInParameter("@getOriMachineAddr",DbType.Int32,getOriMachineAddr);
			dbCommandWrapper.AddInParameter("@getOriMachineType",DbType.Int32,getOriMachineType);
			dbCommandWrapper.AddInParameter("@getChMachineAddr",DbType.Int32,getChMachineAddr);
			dbCommandWrapper.AddInParameter("@getChMachineType",DbType.Int32,getChMachineType);
			dbCommandWrapper.AddInParameter("@getChMachineVol",DbType.Int32,getChMachineVol);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);
			dbForBatchCreate.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public int DeleteMachineInfo(int getMachineAddr,int getMachineType)
		{
			deleteMachineInfoCommand = "DeleteMachineInfo_BatchCreate";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(deleteMachineInfoCommand);
			dbCommandWrapper.AddInParameter("@getMachineAddr",DbType.Int32,getMachineAddr);
			dbCommandWrapper.AddInParameter("@getMachineType",DbType.Int32,getMachineType);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);
			dbForBatchCreate.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public int InsertStuInfo(Option option)
		{
			insertStuInfoCommand = "InsertStuInfo_BatchCreate";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(insertStuInfoCommand);
			dbCommandWrapper.AddInParameter("@getID",DbType.String,option.StuID);
			dbCommandWrapper.AddInParameter("@getGrade",DbType.String,option.StuGrade);
			dbCommandWrapper.AddInParameter("@getGradeName",DbType.String,option.GradeName);
			dbCommandWrapper.AddInParameter("@getGradeRemark",DbType.String,option.GradeRemark);
			dbCommandWrapper.AddInParameter("@getClass",DbType.String,option.StuClass);
			dbCommandWrapper.AddInParameter("@getClassName",DbType.String,option.ClassName);
			dbCommandWrapper.AddInParameter("@getName",DbType.String,option.StuName);
			dbCommandWrapper.AddInParameter("@getNumber",DbType.String,option.StuNumber);
			dbCommandWrapper.AddInParameter("@getBirthday",DbType.DateTime,option.StuBirthday);
			dbCommandWrapper.AddInParameter("@getGender",DbType.String,option.StuGender);
			dbCommandWrapper.AddInParameter("@getType",DbType.String,option.StuEntryStatus);
			dbCommandWrapper.AddInParameter("@getEmail",DbType.String,option.StuEmail);
			dbCommandWrapper.AddInParameter("@getPhone",DbType.String,option.StuPhone);
			dbCommandWrapper.AddInParameter("@getAddr",DbType.String,option.StuFamilyAddr);
			dbCommandWrapper.AddInParameter("@getZipCode",DbType.String,option.StuZipCode);
			dbCommandWrapper.AddInParameter("@getEnterDate",DbType.DateTime,option.StuEnterDate);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);
			dbForBatchCreate.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

        public void InsertStuParentInfo(Option option)
        {
            insertStuInfoCommand = "InsertStuParentInfo";
            dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(insertStuInfoCommand);
            dbCommandWrapper.AddInParameter("@info_stuBasicID", DbType.String, option.StuID);
            dbCommandWrapper.AddInParameter("@info_stuFatherName", DbType.String, option.StuParent1);
            dbCommandWrapper.AddInParameter("@info_stuFatherLinkPhone", DbType.String, option.StuParent1_Phone);
            dbCommandWrapper.AddInParameter("@info_stuFatherWorkPlace", DbType.String, string.Empty);
            dbCommandWrapper.AddInParameter("@info_stuMotherName", DbType.String, option.StuParent2);
            dbCommandWrapper.AddInParameter("@info_stuMotherLinkPhone", DbType.String, option.StuParent2_Phone);
            dbCommandWrapper.AddInParameter("@info_stuMotherWorkPlace", DbType.String, string.Empty);
            dbForBatchCreate.ExecuteNonQuery(dbCommandWrapper);
        }

		public int InsertStuCardInfo(string getID,string getCardNumber,string getHolder,DateTime getDate,int getSeq)
		{
			insertStuCardInfoCommand = "InsertStuCardInfo_BatchCreate";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(insertStuCardInfoCommand);
			dbCommandWrapper.AddInParameter("@getID",DbType.String,getID);
			dbCommandWrapper.AddInParameter("@cardNumber",DbType.String,getCardNumber);
			dbCommandWrapper.AddInParameter("@cardHolder",DbType.String,getHolder);
			dbCommandWrapper.AddInParameter("@sendDate",DbType.DateTime,getDate);
			dbCommandWrapper.AddInParameter("@cardSeq",DbType.Int32,getSeq);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);
			dbForBatchCreate.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public void InsertMachine(string terminalNumbers,string machineVol)
		{
			insertMachineCommand = "InsertMachine_BatchCreate";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(insertMachineCommand);
			dbCommandWrapper.AddInParameter("@terminalNumbers",DbType.String,terminalNumbers);
			dbCommandWrapper.AddInParameter("@machineVol",DbType.String,machineVol);
			dbForBatchCreate.ExecuteNonQuery(dbCommandWrapper);	
		}

		public int InsertMachine(string getAddr,string getType,string getVol)
		{
			insertMachineCommand = "InsertMachine_ForAdmin";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(insertMachineCommand);
			dbCommandWrapper.AddInParameter("@getAddr",DbType.Int32,Convert.ToInt32(getAddr));
			dbCommandWrapper.AddInParameter("@getType",DbType.Int32,Convert.ToInt32(getType));
			dbCommandWrapper.AddInParameter("@getVol",DbType.Int32,Convert.ToInt32(getVol));
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);
			dbForBatchCreate.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public void InsertTeaInfo(Option option)
		{
			insertTeaInfoCommand = "InsertTeaInfo_BatchCreate";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(insertTeaInfoCommand);
			dbCommandWrapper.AddInParameter("@getID",DbType.String,option.TeaID);
			dbCommandWrapper.AddInParameter("@getNumber",DbType.String,option.TeaNumber);
			dbCommandWrapper.AddInParameter("@getName",DbType.String,option.TeaName);
			dbCommandWrapper.AddInParameter("@getGender",DbType.String,option.TeaGender);
			dbCommandWrapper.AddInParameter("@getPhone",DbType.String,option.TeaOfficePhone);
			dbCommandWrapper.AddInParameter("@getDept",DbType.String,option.TeaDept);
			dbCommandWrapper.AddInParameter("@getDuty",DbType.String,option.TeaDuty);
			dbCommandWrapper.AddInParameter("@getAuthority",DbType.String,option.TeaAuthority);
			dbForBatchCreate.ExecuteNonQuery(dbCommandWrapper);
		}

		public int InsertTeaCardInfo(string getID,string getCardNumber,DateTime getCardSendDate,int getCardSeq)
		{
			insertTeaCardInfoCommand = "InsertTeaCardInfo_BatchCreate";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(insertTeaCardInfoCommand);
			dbCommandWrapper.AddInParameter("@getID",DbType.String,getID);
			dbCommandWrapper.AddInParameter("@getCardNumber",DbType.String,getCardNumber);
			dbCommandWrapper.AddInParameter("@getCardSendDate",DbType.DateTime,getCardSendDate);
			dbCommandWrapper.AddInParameter("@getCardSeq",DbType.Int32,getCardSeq);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);
			dbForBatchCreate.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public DataSet GetStuInfo()
		{
			getStuInfoCommand = "GetStuCardInfo_BatchCreate";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(getStuInfoCommand);
			return dbForBatchCreate.ExecuteDataSet(dbCommandWrapper);
		}

		public int InsertNewAddCardInfo(string getNumber,string getCardNumber,string getHolder,DateTime getSendDate)
		{
			insertNewAddCardInfoCommand = "InsertNewAddCard_BatchCreate";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(insertNewAddCardInfoCommand);
			dbCommandWrapper.AddInParameter("@getNumber",DbType.String,getNumber);
			dbCommandWrapper.AddInParameter("@getCardNumber",DbType.String,getCardNumber);
			dbCommandWrapper.AddInParameter("@getHolder",DbType.String,getHolder);
			dbCommandWrapper.AddInParameter("@getSendDate",DbType.DateTime,getSendDate);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);
			dbForBatchCreate.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		public DataTable GetGradeNumberList()
		{
			getGradeNumberListCommand = "GetGradeNumberList";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(getGradeNumberListCommand);
			return dbForBatchCreate.ExecuteDataSet(dbCommandWrapper).Tables[0];
		}

		public void ExecuteBackupFully(string root)
		{
			backupFllyCommand = "bk_createfullystep";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(backupFllyCommand);
			dbCommandWrapper.AddInParameter("@root",DbType.String,root);
			dbForBatchCreate.ExecuteNonQuery(dbCommandWrapper);
		}

		public void ExecuteBackupDiff(string root)
		{
			backupDiffCommand = "bk_creatediffentialstep";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(backupDiffCommand);
			dbCommandWrapper.AddInParameter("@root",DbType.String,root);
			dbForBatchCreate.ExecuteNonQuery(dbCommandWrapper);
		}

        public void AddOrUpdateBackupPath(string path)
        {
            dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper("dbo.AddOrUpdateBackupPath");
            dbCommandWrapper.AddInParameter("@path", DbType.String, path);
            dbForBatchCreate.ExecuteNonQuery(dbCommandWrapper);
        }

        public string GetBackupPath()
        {
            dbCommandWrapper = dbForBatchCreate.GetSqlStringCommandWrapper("select top 1 path from BackupPath");
            var val = dbForBatchCreate.ExecuteScalar(dbCommandWrapper);
            if (val != null)
                return val.ToString();
            else
                return string.Empty;
        }

		public void AddBackupJob(int type,string root)
		{
			addBackupJobCommand = "jp_addbackupschedule";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(addBackupJobCommand);
			dbCommandWrapper.AddInParameter("@root",DbType.String,root);
			dbCommandWrapper.AddInParameter("@type",DbType.Int16,type);
			dbForBatchCreate.ExecuteNonQuery(dbCommandWrapper);
		}

		public void ExecuteRestoreFully(string root)
		{
			string connectionString = @"Data Source="+ConfigInfo["server"]+";Persist Security Info=false;User ID="
				+ConfigInfo["user"]+";Password="+ConfigInfo["password"]+";Initial Catalog=master";
			SqlHelper.ExecuteNonQuery(connectionString,CommandType.Text,"RESTORE DATABASE CTPPDB FROM DISK = '"+root+"' WITH NORECOVERY,REPLACE");
		}

		public void ExecuteRestoreDiff(string root)
		{
			string rootExtension = root.Substring(0,root.IndexOf(".scb")) + ".sdib";
			string connectionString = @"Data Source="+ConfigInfo["server"]+";Persist Security Info=false;User ID="
				+ConfigInfo["user"]+";Password="+ConfigInfo["password"]+";Initial Catalog=master";
			SqlHelper.ExecuteNonQuery(connectionString,CommandType.Text,"RESTORE DATABASE CTPPDB FROM DISK = '"+rootExtension+"' WITH RECOVERY");
		}

		public void KillSysdbProcesses()
		{
			string connectionString = @"Data Source="+ConfigInfo["server"]+";Persist Security Info=false;User ID="
				+ConfigInfo["user"]+";Password="+ConfigInfo["password"]+";Initial Catalog=master";

			DataTable dtSysdbProcesses = SqlHelper.ExecuteDataset(connectionString,CommandType.Text,
				"SELECT sp.spid FROM SYSDATABASES sd INNER JOIN SYSPROCESSES sp ON sd.dbid = sp.dbid WHERE name = 'CTPPDB'").Tables[0];

			if (dtSysdbProcesses != null)
			{
				if (dtSysdbProcesses.Rows.Count > 0)
				{
					for (int i=0; i<dtSysdbProcesses.Rows.Count; i++)
					{
						SqlHelper.ExecuteNonQuery(connectionString,CommandType.Text,"KILL " + Convert.ToInt16(dtSysdbProcesses.Rows[i][0]));
					}
				}
			}
		}

		private DataTable InternalGetGradeNameByNumber(string getGradeNumber)
		{
			getGradeNameByNumberCommand = "GetGradeNameByNumber";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(getGradeNameByNumberCommand);
			dbCommandWrapper.AddInParameter("@gradeNumber",DbType.String,getGradeNumber);
			return dbForBatchCreate.ExecuteDataSet(dbCommandWrapper).Tables[0];
		}

		private int InternalUpdateGradeNameByNumber(string getGradeNumber,string getGradeName)
		{
			updateGradeNameByNumberCommand = "UpdateGradeNameByNumber";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(updateGradeNameByNumberCommand);
			dbCommandWrapper.AddInParameter("@gradeNumber",DbType.String,getGradeNumber);
			dbCommandWrapper.AddInParameter("@gradeName",DbType.String,getGradeName);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);
			dbForBatchCreate.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		private DataTable InternalGetClassNumberList(string getGradeNumber)
		{
			getClassNumberListCommand = "GetClassNumberList";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(getClassNumberListCommand);
			dbCommandWrapper.AddInParameter("@gradeNumber",DbType.String,getGradeNumber);
			return dbForBatchCreate.ExecuteDataSet(dbCommandWrapper).Tables[0];
		}

		private DataTable InternalGetClassNameByNumber(string getGradeNumber,string getClassNumber)
		{
			getClassNameByNumberCommand = "GetClassNameByNumber";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(getClassNameByNumberCommand);
			dbCommandWrapper.AddInParameter("@gradeNumber",DbType.String,getGradeNumber);
			dbCommandWrapper.AddInParameter("@classNumber",DbType.String,getClassNumber);
			return dbForBatchCreate.ExecuteDataSet(dbCommandWrapper).Tables[0];
		}

		private int InternalUpdateClassNameByNumber(string getGradeNumber,string getClassNumber,string getClassName)
		{
			updateClassNameByNumberCommand = "UpdateClassNameByNumber";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(updateClassNameByNumberCommand);
			dbCommandWrapper.AddInParameter("@gradeNumber",DbType.String,getGradeNumber);
			dbCommandWrapper.AddInParameter("@classNumber",DbType.String,getClassNumber);
			dbCommandWrapper.AddInParameter("@className",DbType.String,getClassName);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);
			dbForBatchCreate.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		private int InternalUpdateStudentForGradeChange(string stuName,int stuGrade,int stuClass,string type)
		{
			updateStudentForGradeChangeCommand = "UpdateStudentForGradeChange";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(updateStudentForGradeChangeCommand);
			dbCommandWrapper.AddInParameter("@stuName",DbType.String,stuName);
			dbCommandWrapper.AddInParameter("@gradeNumber",DbType.Int32,stuGrade);
			dbCommandWrapper.AddInParameter("@classNumber",DbType.Int32,stuClass);
			dbCommandWrapper.AddInParameter("@type",DbType.String,type);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);
			dbForBatchCreate.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		private DataTable InternalIsExistGrade(int getGradeNumber)
		{
			getIsExistGradeCommand = "CheckIsExistsGrade";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(getIsExistGradeCommand);
			dbCommandWrapper.AddInParameter("@gradeNumber",DbType.Int32,getGradeNumber);
			return dbForBatchCreate.ExecuteDataSet(dbCommandWrapper).Tables[0];
		}

		private DataTable InternalIsExistClass(int getGradeNumber,int getClassNumber)
		{
			getIsExistClassCommand = "CheckIsExistsClass";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(getIsExistClassCommand);
			dbCommandWrapper.AddInParameter("@gradeNumber",DbType.Int32,getGradeNumber);
			dbCommandWrapper.AddInParameter("@classNumber",DbType.Int32,getClassNumber);
			return dbForBatchCreate.ExecuteDataSet(dbCommandWrapper).Tables[0];
		}

		private int InternalInsertNewStudentForGradeChange(string stuName,int stuGrade,int stuClass,string stuType)
		{
			insertNewStudentForGradeChangeCommand = "InsertNewStudentForGradeChange";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(insertNewStudentForGradeChangeCommand);
			dbCommandWrapper.AddInParameter("@stuId",DbType.String,Guid.NewGuid().ToString());
			dbCommandWrapper.AddInParameter("@stuName",DbType.String,stuName);
			dbCommandWrapper.AddInParameter("@stuGrade",DbType.Int32,stuGrade);
			dbCommandWrapper.AddInParameter("@stuClass",DbType.Int32,stuClass);
			dbCommandWrapper.AddInParameter("@stuType",DbType.String,stuType);
			dbCommandWrapper.AddOutParameter("@rowsAffected",DbType.Int32,4);
			dbForBatchCreate.ExecuteNonQuery(dbCommandWrapper);
			return Convert.ToInt32(dbCommandWrapper.GetParameterValue("@rowsAffected"));
		}

		private DataTable InternalGetStuNameByNumber(string stuNumber)
		{
			getStuNameByNumberCommand = "GetStuNameByNumber";
			dbCommandWrapper = dbForBatchCreate.GetStoredProcCommandWrapper(getStuNameByNumberCommand);
			dbCommandWrapper.AddInParameter("@stuNumber",DbType.String,stuNumber);
			return dbForBatchCreate.ExecuteDataSet(dbCommandWrapper).Tables[0];
		}

		private Hashtable ConfigInfo
		{
			get
			{
				DatabaseSettings dbSettings = (DatabaseSettings)ConfigurationManager.GetConfiguration("dataConfiguration");

				Hashtable configInfo = new Hashtable();
				configInfo["server"] = dbSettings.ConnectionStrings[0].Parameters["server"].Value;
				configInfo["user"] = dbSettings.ConnectionStrings[0].Parameters["User ID"].Value;
				configInfo["password"] = dbSettings.ConnectionStrings[0].Parameters["Password"].Value;

				return configInfo;
			}
		}

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
				if ( dbForBatchCreate != null )
					dbForBatchCreate = null;
			}
		}

	}
}
