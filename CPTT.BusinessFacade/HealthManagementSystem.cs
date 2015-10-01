using System;
using System.Data;
using CPTT.DataAccess;
using CPTT.SystemFramework;
using CPTT.BusinessRule;

namespace CPTT.BusinessFacade
{
	/// <summary>
	/// HealthManagementSystem 的摘要说明。
	/// </summary>
	public class HealthManagementSystem
	{
		HealthManagementRules healthManagementRules;
		HealthMgmt healthMgmt;
		public HealthManagementSystem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			healthManagementRules = new HealthManagementRules();
			healthMgmt = new HealthMgmt();
		}

		public DataTable GetNchsHealthAnalyHistory(string getStuID, string getDate)
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					return healthManagementDataAccess.GetNchsHealthAnalyHistory(getStuID,getDate);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public DataSet GetHealthAnalyHistory(string getStuID, string getDate)
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					return healthManagementDataAccess.GetHealthAnalyHistory(getStuID,getDate);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public int InsertNchsHealthAnalysis()
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					return healthManagementDataAccess.InsertNchsHealthAnalysis(healthMgmt);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return -2;
				}
			}
		}

		public int InsertHealthAnaly()
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					return healthManagementDataAccess.InsertHealthAnaly(healthMgmt);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return -2;
				}
			}
		}

		public int UpdateNchsHealthAnalysis()
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					return healthManagementDataAccess.UpdateNchsHealthAnalysis(healthMgmt);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return -1;
				}
			}
		}

		public int UpdateHealthAnaly()
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					return healthManagementDataAccess.UpdateHealthAnaly(healthMgmt);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return -1;
				}
			}
		}

		public int DeleteNchsHealthAnalysis()
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					return healthManagementDataAccess.DeleteNchsHealthAnalysis(healthMgmt);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return -1;
				}
			}
		}

		public int DeleteHealthAnaly()
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					return healthManagementDataAccess.DeleteHealthAnaly(healthMgmt);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return -1;
				}
			}
		}

		public DataSet GetStuForHealth(string getGrade,string getClass,string getName,string getNumber,string getGender)
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					return healthManagementDataAccess.GetStuForHealth(getGrade,getClass,getName,getNumber,getGender);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public DataSet GetNchsHealthOutput()
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					return healthManagementDataAccess.GetNchsHealthOutput(healthMgmt);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public DataSet GetHealthOutput()
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					return healthManagementDataAccess.GetHealthOutput(healthMgmt);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public DataSet GetStuEnterList(string getGrade,string getClass,string getName,string getNumber,DateTime getDate,string getState)
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					return healthManagementDataAccess.GetStuEnterList(getGrade,getClass,getName,getNumber,getDate,getState);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public int SaveMorningWatch(bool isWatchState)
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					return healthManagementDataAccess.SaveMorningWatch(healthMgmt,isWatchState);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return -1;
				}
			}
		}

		public DataSet GetWholeDayWatch(string getGrade,string getClass,string getName,string getNumber,string getBegDate,string getEndDate)
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					return healthManagementDataAccess.GetWholeDayWatch(getGrade,getClass,getName,getNumber,getBegDate,getEndDate);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public int DeleteWholeDayWatch(string getNumber,string getDate)
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					return healthManagementDataAccess.DeleteWholeDayWatch(getNumber,getDate);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return -1;
				}
			}
		}

		public DataSet GetMedStuInfo(string getGrade,string getClass,string getName,string getNumber,DateTime getDate)
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					return healthManagementDataAccess.GetMedStuInfo(getGrade,getClass,getName,getNumber,getDate);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public int InsertMed()
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					return healthManagementDataAccess.InsertMed(healthMgmt);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return 0;
				}
			}
		}

		public DataSet GetMed(string getMedName,string getMedCategory)
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					return healthManagementDataAccess.GetMed(getMedName,getMedCategory);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public int UpdateMed()
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					return healthManagementDataAccess.UpdateMed(healthMgmt);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return 0;
				}
			}
		}

		public int DeleteMed(string getMedName,string getMedCategory)
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					return healthManagementDataAccess.DeleteMed(getMedName,getMedCategory);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return 0;
				}
			}
		}

		public int SaveDiagResult()
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					return healthManagementDataAccess.SaveDiagResult(healthMgmt);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return 0;
				}
			}
		}

		public DataSet GetDiagInfo(HealthMgmt healthMgmt)
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					return healthManagementDataAccess.GetDiagInfo(healthMgmt);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public DataSet GetAbnRec(string getGrade,string getClass,string getName,string getNumber,DateTime getBegDate,DateTime getEndDate)
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					return healthManagementDataAccess.GetAbnRec(getGrade,getClass,getName,getNumber,getBegDate,getEndDate);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public DataSet GetDoseInfo(string getGrade,string getClass,string getName,string getNumber,DateTime getBegDate,DateTime getEndDate,string getTeaSign)
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					return healthManagementDataAccess.GetDoseInfo(getGrade,getClass,getName,getNumber,getBegDate,getEndDate,getTeaSign);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public int InsertDoseRec(int getDiaID,string getMedName,string getMedTake,string takeDate,string medRule,string teaSign)
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					return healthManagementDataAccess.insertDoseRec(getDiaID,getMedName,getMedTake,takeDate,medRule,teaSign);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return 0;
				}
			}
		}

		public DataSet GetDoseRecInfo(int getDiaID,string takeDate,string teaSign)
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					return healthManagementDataAccess.GetDoseRecInfo(getDiaID,takeDate,teaSign);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		public int DeleteDoseRec(int getRecID,string teaSign)
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					return healthManagementDataAccess.DeleteDoseRec(getRecID,teaSign);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return 0;
				}
			}
		}

		public void DoHealthAnalysis(DateTime getDate,DateTime getBirth,string getHeight,string getWeight,bool isCityStd,bool getGender)
		{
			healthManagementRules.DoHealthAnalysis(getDate,getBirth,getHeight,getWeight,isCityStd,getGender);
		}

		public void DoNchsHealthAnalysis(DateTime getDate,DateTime getBirth,string getHeight,string getWeight,bool getGender)
		{
			healthManagementRules.DoNchsHealthAnalysis(getDate,getBirth,getHeight,getWeight,getGender);
		}

		public string GetTeaName(string getNumber)
		{
			using ( HealthManagementDataAccess healthManagementDataAccess = new HealthManagementDataAccess() )
			{
				try
				{
					return healthManagementDataAccess.getTeaName(getNumber);
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return null;
				}
			}
		}

		//健康评测结果
		public String GetShowAge()
		{
			return healthManagementRules.GetShowAge();
		}

		public string GetNchsHeightAnaly()
		{
			return healthManagementRules.GetNchsHeight();
		}

		public string GetHeightAnaly()
		{
			return healthManagementRules.GetHeightAnaly();
		}

		public string GetNchsWeightAnaly()
		{
			return healthManagementRules.GetNchsWeight();
		}

		public string GetWeightAnaly()
		{
			return healthManagementRules.GetWeightAnaly();
		}

		public string GetNchsObesity()
		{
			return healthManagementRules.GetNchsObesity();
		}

		public string GetHeightWeightAnaly()
		{
			return healthManagementRules.GetHeightWeightAnaly();
		}

		public string GetWHO()
		{
			return healthManagementRules.GetWHO();
		}

		public string GetWHOPer()
		{
			return healthManagementRules.GetWHOPer();
		}

		public string GetX()
		{
			return healthManagementRules.GetX();
		}

		public string GetNchsNut()
		{
			return healthManagementRules.GetNut();
		}

		public string GetNut()
		{
			return healthManagementRules.GetNut();
		}

		public string GetNchsUnderWeight()
		{
			return healthManagementRules.GetNchsUnderWeight();
		}

		public string GetNchsStunting()
		{
			return healthManagementRules.GetNchsStunting();
		}

		public string GetNchsWasting()
		{
			return healthManagementRules.GetNchsWasting();
		}

		public string GetRtnMsg()
		{
			return healthManagementRules.GetRtnMsg();
		}

		//健康评测保存变量
		public string SetShowAge(string getShowAge)
		{
			if ( getShowAge.Equals("") )
				return "请先做健康分析，后保存！";
			else
			{
				healthMgmt.Age = getShowAge.Trim();
				return "ok";
			}
		}

		public void SetHeightAnaly(string getHeightAnaly)
		{
			healthMgmt.HeightAnaly = getHeightAnaly;
		}

		public void SetWeightAnaly(string getWeightAnaly)
		{
			healthMgmt.WeightAnaly = getWeightAnaly;
		}

		public void SetHeightWeightAnaly(string getHeightWeightAnaly)
		{
			healthMgmt.HeightWeightAnaly = getHeightWeightAnaly;
		}

		public void SetWhoAnaly(string getWhoAnaly)
		{
			healthMgmt.WHO = getWhoAnaly;
		}

		public void SetWhoPerAnaly(string getWhoPerAnaly)
		{
			healthMgmt.WHOPer = getWhoPerAnaly;
		}

		public void SetX(string getX)
		{
			healthMgmt.X = getX;
		}

		public void SetNutAnaly(string getNutAnaly)
		{
			healthMgmt.Nut = getNutAnaly;
		}

		public void SetNchsUnderWeight(string getNchsUnderWeight)
		{
			healthMgmt.NchsUnderWeight = getNchsUnderWeight;
		}

		public void SetNchsStunting(string getNchsStunting)
		{
			healthMgmt.NchsStunting = getNchsStunting;
		}

		public void SetNchsWasting(string getNchsWasting)
		{
			healthMgmt.NchsWasting = getNchsWasting;
		}

		public void SetRemark(string getRemark)
		{
			healthMgmt.Remark = getRemark;
		}

		public string SetHeight(string getHeight)
		{
			if ( getHeight.Equals("") )
				return "请不要删除身高后保存！";
			else
			{
				try
				{
					healthMgmt.Height = Convert.ToDouble(getHeight.Trim());
					return "ok";
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return "身高必须是数字！";
				}
			}
		}

		public string SetWeight(string getWeight)
		{
			if ( getWeight.Equals("") )
				return "请不要删除体重后保存！";
			else
			{
				try
				{
					healthMgmt.Weight = Convert.ToDouble(getWeight.Trim());
					return "ok";
				}
				catch(Exception e)
				{
					Util.WriteLog(e.Message,Util.EXCEPTION_LOG_TITLE);
					return "体重必须是数字！";
				}
			}
		}
		
		public void SetDate(string getDate)
		{
			healthMgmt.Date = getDate;
		}

		public void SetStuID(string getStuID)
		{
			healthMgmt.StuID = getStuID;
		}

		public void SetStd(bool isCityStd)
		{
			healthMgmt.Std = isCityStd;
		}

		//健康评测输出查询变量
		public void SetGrade(string getGrade)
		{
			healthMgmt.OutGrade = getGrade;
		}

		public void SetClass(string getClass)
		{
			healthMgmt.OutClass = getClass;
		}

		public void SetName(string getName)
		{
			healthMgmt.OutName = getName;
		}

		public void SetNumber(string getNumber)
		{
			healthMgmt.OutNumber = getNumber;
		}

		public void SetGender(string getGender)
		{
			healthMgmt.OutGender = getGender;
		}

		public void SetAge(string getAge)
		{
			healthMgmt.OutAge = getAge;
		}

		public void SetType(string getType)
		{
			healthMgmt.OutType = getType;
		}

		public void SetResult(string getResult)
		{
			healthMgmt.OutResult = getResult;
		}

		public void SetBegDate(string getBegDate)
		{
			healthMgmt.OutBegDate = getBegDate;
		}

		public void SetEndDate(string getEndDate)
		{
			healthMgmt.OutEndDate = getEndDate;
		}
		
		//全日观察晨检登记变量
		public void SetWatchNumber(string getWatchNumber)
		{
			healthMgmt.WatchNumber = getWatchNumber;
		}

		public void SetWatchName(string getWatchName)
		{
			healthMgmt.WatchName = getWatchName;
		}

		public void SetWatchHeat(string getWatchHeat)
		{
			healthMgmt.WatchHeat = getWatchHeat;
		}

		public void SetWatchSpirit(string getWatchSpirit)
		{
			healthMgmt.WatchSpirit = getWatchSpirit;
		}

		public void SetWatchMouth(string getWatchMouth)
		{
			healthMgmt.WatchMouth = getWatchMouth;
		}

		public void SetWatchSkin(string getWatchSkin)
		{
			healthMgmt.WatchSkin = getWatchSkin;
		}

		public void SetWatchOState(string getWatchOState)
		{
			healthMgmt.WatchOState = getWatchOState;
		}

		public void SetWatchTreat(string getWatchTreat)
		{
			healthMgmt.WatchTreat = getWatchTreat;
		}

		public void SetWatchDate(string getWatchDate)
		{
			healthMgmt.WatchDate = getWatchDate;
		}

		//全日观察变量

		public void SetRecID(int getRecID)
		{
			healthMgmt.RecID = getRecID;
		}

		public void SetDailyMovement(string getDailyMovement)
		{
			healthMgmt.DailyMovement = getDailyMovement;
		}

		public void SetDailySpirit(string getDailySpirit)
		{
			healthMgmt.DailySpirit = getDailySpirit;
		}

		public void SetDailyAppetite(string getDailyAppetite)
		{
			healthMgmt.DailyAppetite = getDailyAppetite;
		}

		public void SetDailySleep(string getDailySleep)
		{
			healthMgmt.DailySleep = getDailySleep;
		}

		public void SetDailyStool(string getDailyStool)
		{
			healthMgmt.DailyStool = getDailyStool;
		}

		public void SetDailyCough(string getDailyCough)
		{
			healthMgmt.DailyCough = getDailyCough;
		}

		public void SetDailyElse(string getDailyElse)
		{
			healthMgmt.DailyElse = getDailyElse;
		}

		public void SetDailyCtrlAct(bool getDailyCtrlAct)
		{
			healthMgmt.DailyCtrlAct = getDailyCtrlAct;
		}

		public void SetDailyLife(bool getDailyLife)
		{
			healthMgmt.DailyLife = getDailyLife;
		}

		public void SetDailySeafood(bool getDailySeafood)
		{
			healthMgmt.DailySeafood = getDailySeafood;
		}

		public void SetDailyHeat(bool getDailyHeat)
		{
			healthMgmt.DailyHeat = getDailyHeat;
		}

		public void  SetTeacherSign(string getTeacherSign)
		{
			healthMgmt.TeacherSign = getTeacherSign;
		}

		public HealthMgmt GetHealthMgmt()
		{
			return this.healthMgmt;
		}

		//服药管理症状变量

		public void SetDiagInfo(string getDiagInfo)
		{
			healthMgmt.DiagInfo = getDiagInfo;
		}

		public void SetUpperSym(string getUpperSym)
		{
			healthMgmt.UpperSym = getUpperSym;
		}

		public void SetLungSym(string getLungSym)
		{
			healthMgmt.LungSym = getLungSym;
		}

		public void SetThroatSym(string getThroatSym)
		{
			healthMgmt.ThroatSym = getThroatSym;
		}

		public void SetEnteronSym(string getEnteronSym)
		{
			healthMgmt.EnteronSym = getEnteronSym;
		}

		public void SetAbdomenSym(string getAbdomenSym)
		{
			healthMgmt.AbdomenSym = getAbdomenSym;
		}

		public void SetSkinSym(string getSkinSym)
		{
			healthMgmt.SkinSym = getSkinSym;
		}

		public void SetFacialSym(string getFacialySym)
		{
			healthMgmt.FacialSym = getFacialySym;
		}

		public void SetElse(string getElse)
		{
			healthMgmt.Else = getElse;
		}

		public void SetStuNumber(string getStuNumber)
		{
			healthMgmt.StuNumber = getStuNumber;
		}

		public void SetRegDate(DateTime getRegDate)
		{
			healthMgmt.RegisterDate = getRegDate;
		}

		public void SetMedInfo(string getMedInfo)
		{
			healthMgmt.MedInfo = getMedInfo;
		}

		public void SetMedModifyID(int getMedModifyID)
		{
			healthMgmt.MedModifyID = getMedModifyID;
		}

		public void SetMedName(string getMedName)
		{
			healthMgmt.MedName = getMedName;
		}

		public void SetMedType(string getMedType)
		{
			 healthMgmt.MedType = getMedType;
		}

		public void SetMedTake(string getMedTake)
		{
			healthMgmt.MedTake = getMedTake;
		}

		public void SetTaketimes(int getTaketimes)
		{
			healthMgmt.Taketimes = getTaketimes;
		}

	}
}
