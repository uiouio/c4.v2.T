using System;

namespace CPTT.SystemFramework
{
	/// <summary>
	/// HealthMgmt 的摘要说明。
	/// </summary>
	public class HealthMgmt
	{
		private string getStuID;
		private string getDate;
		private double getHeight;
		private double getWeight;
		private string getRemark;
		private string getAge;
		private string getHeightAnaly;
		private string getWeightAnaly;
		private string getHeightWeightAnaly;
		private string getWHOPer;
		private string getWHO;
		private string getX;
		private string getNut;
		private string getNchsUnderWeight;
		private string getNchsStunting;
		private string getNchsWasting;
		private bool getStd;

		private string getOutGrade;
		private string getOutClass;
		private string getOutName;
		private string getOutNumber;
		private string getOutGender;
		private string getOutAge;
		private string getOutType;
		private string getOutResult;
		private string getOutBegDate;
		private string getOutEndDate;

		private string getWatchName;
		private string getWatchNumber;
		private string getWatchHeat;
		private string getWatchSpirit;
		private string getWatchMouth;
		private string getWatchSkin;
		private string getWatchOState;
		private string getWatchTreat;
		private string getWatchDate;
		private int getRecID;

		private string getDailyMovement;
		private string getDailySpirit;
		private string getDailyAppetite;
		private string getDailySleep;		
		private string getDailyStool;		
		private string getDailyCough;	
		private string getDailyElse;		
		private bool getDailyCtrlAct;	
		private bool getDailyLife;		
		private bool getDailySeafood;	
		private bool getDailyHeat;		
		private string getTeacherSign;	

		private string getUpperSym;
		private string getLungSym;
		private string getThroatSym;
		private string getEnteronSym;
		private string getAbdomenSym;
		private string getSkinSym;
		private string getFacialSym;
		private string getElse;
		private int getMedModifyID;
		private string getMedName;
		private string getMedType;
		private string getMedTake;
		private int getTaketimes;
		private	string getStuNumber;
		private DateTime getRegisterDate;
		private string getDiagInfo;
		private string getMedInfo;


		public HealthMgmt()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public string StuID
		{
			get { return this.getStuID; }
			set { this.getStuID = value; }
		}

		public string Date
		{
			get { return this.getDate; }
			set { this.getDate = value; }
		}

		public double Height
		{
			get { return this.getHeight; }
			set { this.getHeight = value; }
		}

		public double Weight
		{
			get { return this.getWeight; }
			set { this.getWeight = value; }
		}

		public string Remark
		{
			get { return this.getRemark; }
			set { this.getRemark = value; }
		}

		public string Age
		{
			get { return this.getAge; }
			set { this.getAge = value; }
		}

		public string HeightAnaly
		{
			get { return this.getHeightAnaly; }
			set { this.getHeightAnaly = value; }
		}

		public string WeightAnaly
		{
			get { return this.getWeightAnaly; }
			set { this.getWeightAnaly = value; }
		}

		public string HeightWeightAnaly
		{
			get { return  this.getHeightWeightAnaly;}
			set { this.getHeightWeightAnaly = value;} 
		}

		public string WHO
		{
			get { return this.getWHO; }
			set { this.getWHO = value; }
		}

		public string WHOPer
		{
			get { return this.getWHOPer; }
			set { this.getWHOPer = value; }
		}

		public string X
		{
			get { return this.getX; }
			set { this.getX = value;}
		}

		public string Nut
		{
			get { return this.getNut; }
			set { this.getNut = value; }
		}

		public string NchsUnderWeight
		{
			get { return this.getNchsUnderWeight; }
			set { this.getNchsUnderWeight = value; }
		}

		public string NchsStunting
		{
			get { return this.getNchsStunting; }
			set { this.getNchsStunting = value; }
		}

		public string NchsWasting
		{
			get { return this.getNchsWasting; }
			set { this.getNchsWasting = value; }
		}

		public bool Std
		{
			get { return this.getStd; }
			set { this.getStd = value; }
		}

		public string OutGrade
		{
			get { return this.getOutGrade; }
			set { this.getOutGrade = value; }
		}

		public string OutClass
		{
			get { return this.getOutClass; }
			set { this.getOutClass = value; }
		}

		public string OutName
		{
			get { return this.getOutName;}
			set { this.getOutName = value; }
		}

		public string OutNumber
		{
			get { return this.getOutNumber;}
			set { this.getOutNumber = value; }  
		}

		public string OutGender
		{
			get { return this.getOutGender; }
			set { this.getOutGender = value; } 
		}

		public string OutAge
		{
			get { return this.getOutAge; }
			set { this.getOutAge = value; }
		}

		public string OutType
		{
			get { return this.getOutType; }
			set { this.getOutType = value; }
		}

		public string OutResult
		{
			get { return this.getOutResult; }
			set { this.getOutResult = value; }
		}

		public string OutBegDate
		{
			get { return this.getOutBegDate; }
			set { this.getOutBegDate = value; }
		}

		public string OutEndDate
		{
			get { return this.getOutEndDate; }
			set { this.getOutEndDate = value; }
		}
		
		public int RecID
		{
			get { return this.getRecID; }
			set { this.getRecID = value; }
		}

		public string WatchName
		{
			get { return this.getWatchName; }
			set { this.getWatchName = value; }
		}

		public string WatchNumber
		{
			get { return this.getWatchNumber; }
			set { this.getWatchNumber = value; }
		}

		public string WatchHeat
		{
			get { return this.getWatchHeat; }
			set { this.getWatchHeat = value; }
		}

		public string WatchSpirit
		{
			get { return this.getWatchSpirit; }
			set { this.getWatchSpirit = value; }
		}

		public string WatchMouth
		{
			get { return this.getWatchMouth; }
			set { this.getWatchMouth = value; }
		}

		public string WatchSkin
		{
			get { return this.getWatchSkin; }
			set { this.getWatchSkin = value; }
		}

		public string WatchOState
		{
			get { return this.getWatchOState; }
			set { this.getWatchOState = value; }
		}

		public string WatchTreat
		{
			get { return this.getWatchTreat; }
			set { this.getWatchTreat = value; }
		}

		public string WatchDate
		{
			get { return this.getWatchDate; }
			set { this.getWatchDate = value; }
		}

		public string DailyMovement
		{
			get { return this.getDailyMovement; }
			set { this.getDailyMovement = value; }
		}

		public string DailySpirit
		{
			get { return this.getDailySpirit; }
			set { this.getDailySpirit = value; }
		}

		public string DailyAppetite
		{
			get { return this.getDailyAppetite; }
			set { this.getDailyAppetite = value;  }
		}

		public string DailySleep
		{
			get { return this.getDailySleep; }
			set { this.getDailySleep = value; }
		}

		public string DailyStool
		{
			get { return this.getDailyStool; }
			set { this.getDailyStool = value; }
		}

		public string DailyCough
		{
			get { return this.getDailyCough; }
			set { this.getDailyCough = value; }
		}

		public string DailyElse
		{
			get { return this.getDailyElse; }
			set { this.getDailyElse = value; }
		}

		public bool DailyCtrlAct
		{
			get { return this.getDailyCtrlAct; }
			set { this.getDailyCtrlAct = value; } 
		}

		public bool DailyLife
		{
			get { return this.getDailyLife; }
			set { this.getDailyLife = value; }
		}

		public bool DailySeafood
		{
			get { return this.getDailySeafood; }
			set { this.getDailySeafood = value; }
		}

		public bool DailyHeat
		{
			get { return this.getDailyHeat; }
			set { this.getDailyHeat = value; }
		}

		public string TeacherSign
		{
			get { return this.getTeacherSign; }
			set { this.getTeacherSign = value; }
		}

		public string UpperSym
		{
			get { return this.getUpperSym; }
			set { this.getUpperSym = value; }
		}

		public string LungSym
		{
			get { return this.getLungSym;}
			set { this.getLungSym = value; }  
		}

		public string ThroatSym
		{
			get { return this.getThroatSym; }
			set { this.getThroatSym = value; }
		}

		public string EnteronSym
		{
			get { return this.getEnteronSym; }
			set { this.getEnteronSym = value; }
		}

		public string AbdomenSym
		{
			get { return this.getAbdomenSym; }
			set { this.getAbdomenSym = value; }
		}
		
		public string SkinSym
		{
			get { return this.getSkinSym; }
			set { this.getSkinSym = value; }
		}

		public string FacialSym
		{
			get { return this.getFacialSym; }
			set { this.getFacialSym = value; }
		}

		public string Else
		{
			get { return this.getElse; }
			set { this.getElse = value; }
		}

		public int MedModifyID
		{
			get { return this.getMedModifyID; }
			set { this.getMedModifyID = value; }
		}

		public string MedName
		{
			get { return this.getMedName; }
			set { this.getMedName = value; }
		}

		public string MedType
		{
			get { return this.getMedType; }
			set { this.getMedType = value; }
		}

		public string MedTake
		{
			get { return this.getMedTake; }
			set { this.getMedTake = value; }
		}

		public int Taketimes
		{
			get { return this.getTaketimes; }
			set { this.getTaketimes = value; }
		}

		public string StuNumber
		{
			get { return this.getStuNumber; }
			set { this.getStuNumber = value; }
		}

		public DateTime RegisterDate
		{
			get { return this.getRegisterDate; }
			set { this.getRegisterDate = value; }
		}

		public string DiagInfo
		{
			get { return this.getDiagInfo; }
			set { this.getDiagInfo = value; }
		}

		public string MedInfo
		{
			get { return this.getMedInfo; }
			set { this.getMedInfo = value; }
		}
	}
}
