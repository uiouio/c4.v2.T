//==================================================================================
// 创智智能晨检网络管理系统4.0
//==================================================================================
// Copyright @2005 Shanghai Chuangzhi Toy&Technology Corporation All rights reserved.
//本计算机程序受版权法和国际条约保护.
// 如未经授权而擅自复制或传播本程序(或其中任何部分),将受到严厉的民事及刑事制裁,
//并将在法律许可的范围内受到最大程度的起诉!
//==================================================================================

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Xml;
using System.Diagnostics;
using System.ServiceProcess;
using System.Threading;

using CPTT.BusinessFacade;
using CPTT.SystemFramework;
using CTRLSERIALLib;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Configuration;

using CPTTAutoService.UploadDataService;

namespace CPTTAutoService
{
	public class AutoService : System.ServiceProcess.ServiceBase
	{
		private HandleComClass handleComClass;
		private bool comPortIsBusy;
		private HandleComData handleComData;
		private System.Timers.Timer timerTimeSynch;
		private ControlFrame responseFrame;
		private MachineSystem machineSystem;
		private DataSet machineAddrList;
		private Thread queryThread;
		private System.ComponentModel.IContainer components = null;
		private System.Timers.Timer timer_ReceiveReply;
		private ArrayList _alAuthenticatedHardWare;
		private static DateTime _lastSyncDate = DateTime.Now;
		private Thread _upLoadDataThread;
		private DataSet _dsUpload;
		private bool isAllowedToResponse = false;

		public AutoService()
		{
			// 该调用是 Windows.Forms 组件设计器所必需的。
			InitializeComponent();

			// TODO: 在 InitComponent 调用后添加任何初始化

			_alAuthenticatedHardWare = HardWareAuthentication.GetAuthorizedHardWare();
		}

		// 进程的主入口点
		static void Main()
		{
			System.ServiceProcess.ServiceBase[] ServicesToRun;
	
			// 同一进程中可以运行多个用户服务。若要将
			//另一个服务添加到此进程，请更改下行
			// 以创建另一个服务对象。例如，
			//
			//   ServicesToRun = New System.ServiceProcess.ServiceBase[] {new Service1(), new MySecondUserService()};
			//
			ServicesToRun = new System.ServiceProcess.ServiceBase[] { new AutoService()};

			System.ServiceProcess.ServiceBase.Run(ServicesToRun);
		}

		/// <summary> 
		/// 设计器支持所需的方法 - 不要使用代码编辑器 
		/// 修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.timerTimeSynch = new System.Timers.Timer();
			this.timer_ReceiveReply = new System.Timers.Timer();
			((System.ComponentModel.ISupportInitialize)(this.timerTimeSynch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.timer_ReceiveReply)).BeginInit();
			// 
			// timerTimeSynch
			//
			timerTimeSynch.Interval = CPTT.SystemFramework.Util.TIMESYNCH_TIMER_INTERVAL;//设置时间同步timer
			this.timerTimeSynch.Elapsed += new System.Timers.ElapsedEventHandler(this.timerTimeSynch_Elapsed);
			// 
			// timer_ReceiveReply
			// 
			this.timer_ReceiveReply.Enabled = false;
			this.timer_ReceiveReply.Interval = 40000;
			this.timer_ReceiveReply.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_ReceiveReply_Elapsed);
			// 
			// AutoService
			// 
			this.CanPauseAndContinue = true;
			this.CanShutdown = true;
			this.ServiceName = "CPTT4.0AutoService";
			((System.ComponentModel.ISupportInitialize)(this.timerTimeSynch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.timer_ReceiveReply)).EndInit();

			handleComClass = new HandleComClass();
			handleComClass.Start(CPTT.SystemFramework.Util.COM1_PORT_NUMBER,CPTT.SystemFramework.Util.COM_BAUD_RATE,1);
			handleComClass.DataArrived += new _IHandleComEvents_DataArrivedEventHandler(handleComClass_DataArrived);

			machineSystem = new MachineSystem();
		
			responseFrame = new ControlFrame();

			responseFrame.sym = new byte[]{(byte)'*',(byte)'*'};
			responseFrame.srcAddr = 0;
			responseFrame.response = CPTT.SystemFramework.Util.RECEIVE_SUCCESS_TOKEN;
			responseFrame.seq = CPTT.SystemFramework.Util.FRAME_SEQUENCE_VALUE;

			handleComData = new HandleComData(this.InsertMorningCheckData);


		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		/// <summary>
		/// 设置具体的操作，以便服务可以执行它的工作。
		/// </summary>
		protected override void OnStart(string[] args)
		{
			// TODO: 在此处添加代码以启动服务。
			comPortIsBusy = false;
			timerTimeSynch.Enabled = true;

			queryThread = new Thread(new ThreadStart(SendQuery));
			queryThread.IsBackground = true;
			queryThread.Priority = ThreadPriority.Normal;
			queryThread.Start();

			machineAddrList = machineSystem.GetMachineAddrList();
		}
 
		/// <summary>
		/// 停止此服务。
		/// </summary>
		protected override void OnStop()
		{
			// TODO: 在此处添加代码以执行停止服务所需的关闭操作。
			comPortIsBusy = false;

			timerTimeSynch.Enabled = false;

			if(queryThread!=null)
			{
				try
				{
					queryThread.Abort();
				}
				catch
				{

				}
			}

			if (_upLoadDataThread != null)
			{
				try
				{
					_upLoadDataThread.Abort();
				}
				catch
				{}
			}
		}

//		private void UploadData()
//		{
//			while (true)
//			{
//				_dsUpload = new UtilSystem().GetUploadData();
//				if (_dsUpload != null && _dsUpload.Tables.Count == 2)
//				{
//					UploadDataService.UploadDataService service = new UploadDataService.UploadDataService();
//					AsyncCallback asy = new AsyncCallback(WebSerivceCallBack);
//					service.BeginUploadData(_dsUpload, asy, service);
//				}
//
//				Thread.Sleep(300000);
//			}
//		}

		private void UploadData()
		{
			while (true)
			{
				int uploadVersion = 1;
				//				_dsUpload = new UtilSystem().GetUploadData();
				//				if (_dsUpload != null && _dsUpload.Tables.Count == 2)
				//				{
				//					UploadDataService.UploadDataService service = new UploadDataService.UploadDataService();
				//					AsyncCallback asy = new AsyncCallback(WebSerivceCallBack);
				//					service.BeginUploadData(_dsUpload, asy, service);
				//				}

				try
				{
					
					_dsUpload = new UtilSystem().GetUploadData();
					if (_dsUpload != null && _dsUpload.Tables.Count >= 2)
					{
						CPTT.SystemFramework.Util.WriteLog(string.Format("Try to upload records  {0} on time:{1}", _dsUpload.Tables[1].Rows.Count, DateTime.Now), 
							CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);


						//proc GetUploadData2
						//if (_dsUpload != null && _dsUpload.Tables[0].Rows.Count > 0 && _dsUpload.Tables[0].Columns.Count > 1)

						//						object o = SystemFramework.Util.UploadData(SystemFramework.Util.WebserviceURL, "Upload", 
						//							SystemFramework.Util.WebserviceClassName, SystemFramework.Util.WebServiceMethod,
						//							new object[]{"Gmis", "Sunlightr00m", DateTime.Now.ToString(), 
						//											_dsUpload.Tables[0].Rows[0]["gardenName"].ToString(), _dsUpload, 3, 
						//											uploadVersion, new DataSet()}, new ArrayList());

						object o = CPTT.SystemFramework.Util.UploadData(CPTT.SystemFramework.Util.WebserviceURL,
							"DataCenterWebService", CPTT.SystemFramework.Util.WebserviceClassName,
							CPTT.SystemFramework.Util.WebServiceMethod, new object[]{_dsUpload}, new ArrayList());

						if (_dsUpload.Tables.Count > 2)
						{
							foreach(DataRow dr in _dsUpload.Tables[2].Rows)
							{
								new UtilSystem().UpdateUploadState(dr["studentId"].ToString());
							}
						}

						//						if (o == null)
						//						{
						//							throw new Exception(string.Format("upload failed on {0}", DateTime.Now));
						//						}
					
						CPTT.SystemFramework.Util.WriteLog("Upload succeed", CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);
					}
				}
				catch(Exception ex)
				{
					CPTT.SystemFramework.Util.WriteLog(ex.Message, CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);
				}
				finally
				{
					uploadVersion++;
					
				}

				Thread.Sleep(300000);
			}
		}

		private void WebSerivceCallBack(IAsyncResult ar)
		{
			try
			{
				CPTT.SystemFramework.Util.WriteLog(string.Format("Count Uploaded {0} on time:{1}",_dsUpload.Tables[1].Rows.Count, DateTime.Now), 
					CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);
			}
			catch
			{
				CPTT.SystemFramework.Util.WriteLog(string.Format("Count Uploaded {0} on time:{1}", 0, DateTime.Now), 
					CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);
			}
		}

		#region send query token every 300 millisecond
		//问询指令
		private void SendQuery()
		{
			while(true)
			{
				if(!comPortIsBusy)
				{
					if (machineAddrList != null)
					{
						if ( machineAddrList.Tables[0].Rows.Count > 0 )
						{
							foreach(DataRow machineAddr in machineAddrList.Tables[0].Rows)
							{
								ControlFrame controlFrame = new ControlFrame();
								controlFrame.sym = new byte[]{(byte)'*',(byte)'*'};
								controlFrame.desAddr = Convert.ToByte(machineAddr["machine_address"]);
								controlFrame.srcAddr = 0;
								controlFrame.response = CPTT.SystemFramework.Util.QUERY_TOKEN;
								controlFrame.seq = CPTT.SystemFramework.Util.FRAME_SEQUENCE_VALUE;
								controlFrame.computeCheckSum();

								Monitor.Enter(handleComClass);
								handleComClass.WriteSerialCmd(CPTT.SystemFramework.Util.CONTROL_FRAME_LENGTH,controlFrame.convertToBytes());//发送问询帧
								Monitor.Exit(handleComClass);

//								Thread.Sleep(3000);
								Thread.Sleep(CPTT.SystemFramework.Util.QUERY_TIMER_INTERVAL);
							}

							if (_lastSyncDate.AddMinutes(10) <= DateTime.Now)
							{
								foreach(DataRow machineAddr in machineAddrList.Tables[0].Rows)
								{
									SynchDate(machineAddr["machine_address"]);
								}

								_lastSyncDate = DateTime.Now;
							}
						}
						else Thread.Sleep(CPTT.SystemFramework.Util.QUERY_NULL_INTERVAL);
					}
					else Thread.Sleep(1000);

//					if ( _alAuthenticatedHardWare.Count > 0 )
//					{
//						foreach(object o in _alAuthenticatedHardWare)
//						{
//							ControlFrame controlFrame = new ControlFrame();
//							controlFrame.sym = new byte[]{(byte)'*',(byte)'*'};
//							controlFrame.desAddr = Convert.ToByte(o.ToString());
//							controlFrame.srcAddr = 0;
//							controlFrame.response = CPTT.SystemFramework.Util.QUERY_TOKEN;
//							controlFrame.seq = CPTT.SystemFramework.Util.FRAME_SEQUENCE_VALUE;
//							controlFrame.computeCheckSum();
//
//							Monitor.Enter(handleComClass);
//							handleComClass.WriteSerialCmd(CPTT.SystemFramework.Util.CONTROL_FRAME_LENGTH,controlFrame.convertToBytes());//发送问询帧
//							Monitor.Exit(handleComClass);
//
//							Thread.Sleep(CPTT.SystemFramework.Util.QUERY_TIMER_INTERVAL);
//						}
//					}
//					else Thread.Sleep(CPTT.SystemFramework.Util.QUERY_NULL_INTERVAL);
				}
			}
		}

		//串口数据到达时处理
		private void handleComClass_DataArrived(int size, ref object vBuf)
		{
			try
			{
				Monitor.Enter(handleComClass);
				byte[] ReceiveData = (byte[])vBuf;
				byte sym = ReceiveData[0];

				//			if(!CPTT.SystemFramework.Util.ComputeCheckSum(ReceiveData))
				//				return;

				if ( !CPTT.SystemFramework.Util.IsValidFrame(ReceiveData,ref sym,ref ReceiveData) ) return;

				if(ReceiveData[5] == 0x08&&ReceiveData[2]==0)//如果是刷卡通讯帧则处理
				{
					handleComData(ReceiveData);
				}
			}
			catch(Exception ex)
			{
				CPTT.SystemFramework.Util.WriteLog(ex.Message,CPTT.SystemFramework.Util.EXCEPTION_LOG_TITLE);
			}
			finally
			{
				Monitor.Exit(handleComClass);
			}
		}

		//利用委托处理串口数据
		private delegate void HandleComData(byte[] morningCheckData);

		private void InsertMorningCheckData(byte[] morningCheckData)
		{
			DataFrame dataFrame = DataFrame.convertToFrame(morningCheckData);
			int rowsAffected = new MorningCheckInfoSystem().InsertMorningCheckInfo(dataFrame);

			if(rowsAffected > 0)
			{
				responseFrame.desAddr = dataFrame.srcAddr;
				responseFrame.computeCheckSum();
				queryThread.Suspend();
	
				handleComClass.WriteSerialCmd(CPTT.SystemFramework.Util.CONTROL_FRAME_LENGTH,responseFrame.convertToBytes());
	
				queryThread.Resume();
			}
		}

		//时间同步
		private void timerTimeSynch_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
//			DataFrame timeSynchFrame = new DataFrame();
//			timeSynchFrame.sym = new byte[]{(byte)'@',(byte)'@'};
//			timeSynchFrame.comFrameLen = 15;
//			timeSynchFrame.srcAddr = 0;
//			timeSynchFrame.protocol = CPTT.SystemFramework.Util.TIME_SYNCH_TOKEN;
//			timeSynchFrame.seq = CPTT.SystemFramework.Util.FRAME_SEQUENCE_VALUE;
//			
//			timeSynchFrame.frameData = new byte[7];
//			timeSynchFrame.frameData[0] = (byte)(DateTime.Now.Year%100);//2位年数
//			timeSynchFrame.frameData[1] = (byte)DateTime.Now.Month;//月
//			timeSynchFrame.frameData[2] = (byte)DateTime.Now.Day;//日
//			timeSynchFrame.frameData[3] = (byte)(DateTime.Now.DayOfWeek+1);//星期
//			timeSynchFrame.frameData[4] = (byte)DateTime.Now.Hour;//时
//			timeSynchFrame.frameData[5] = (byte)DateTime.Now.Minute;//分
//			timeSynchFrame.frameData[6] = (byte)DateTime.Now.Second;//秒
//
//			machineAddrList = machineSystem.GetMachineAddrList();
//
//			foreach(DataRow machineAddr in machineAddrList.Tables[0].Rows)
//			{
//				timeSynchFrame.desAddr = Convert.ToByte(machineAddr["machine_address"]);
//				timeSynchFrame.computeCheckSum();
//
////				comPortIsBusy = true;
//				queryThread.Suspend();
//				handleComClass.WriteSerialCmd(timeSynchFrame.comFrameLen,timeSynchFrame.frameToBytes());
////				comPortIsBusy = false;
//				queryThread.Resume();
//			}
		}
		#endregion

		#region SMS function
		private void timer_ReceiveReply_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
//			autoSendSMS();
//			sendSMS();
//			receiveSMS();
		}

		public void WriteLog(string message,string logTitle)
		{
			LogEntry log = new LogEntry();
			log.EventId = 1;
			log.Message = message;
			log.Category = "Trace";
			log.Priority = 0;
			log.Title = logTitle;
			Logger.Write(log);
		}

		private void autoSendSMS()
		{
			ArrayList settings = ConfigurationManager.GetConfiguration("CustomizeSettings") as ArrayList;

			DateTime SMSMorningTime = Convert.ToDateTime((settings[4] as XmlNode[])[1].InnerText);
			DateTime SMSNightTime = Convert.ToDateTime((settings[5] as XmlNode[])[1].InnerText);

			string timeNow = DateTime.Now.ToString("HH:mm");
			string SMSMorningTimeString = SMSMorningTime.ToString("HH:mm");
			string SMSNightTimeString = SMSNightTime.ToString("HH:mm");

			Database db = DatabaseFactory.CreateDatabase();

			if(timeNow.Equals(SMSMorningTime))
			{
				try
				{
					DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("SendSMSForAbsentStu");
					db.ExecuteNonQuery(dbCom);
				}
				catch(Exception ex)
				{
					WriteLog(DateTime.Now.ToString()+" "+ex.Message,"短信异常");
				}
			}

			if(timeNow.Equals(SMSNightTime))
			{
				try
				{
					DBCommandWrapper dbCom = db.GetStoredProcCommandWrapper("SendSMSForNotLeaveStu");
					db.ExecuteNonQuery(dbCom);
				}
				catch(Exception ex)
				{
					WriteLog(DateTime.Now.ToString()+" "+ex.Message,"短信异常");
				}
			}
		}

		private void receiveSMS()
		{
			try
			{
				string urlMobile = "http://202.96.236.81:7783/shcomm/getUpMsg.asp?"
					+"UID=sap&psd=0F3E419C71C500FA1FC8&source=8002733&mo_type=0";
				string urlUnion = "http://202.96.236.81:7783/shcomm/getUpMsg.asp?"
					+"UID=sap&psd=0F3E419C71C500FA1FC8&source=9002733&mo_type=0";

				//receive reply from mobile
				MSXML2.XMLHTTPClass xmlHttp = new MSXML2.XMLHTTPClass();
				xmlHttp.open("POST" , urlMobile , false , null , null  );          
				xmlHttp.setRequestHeader( "CharSet" , "GB2312" );    

				xmlHttp.send( null );

				if(xmlHttp.status == 200)
				{
					System.Text.Encoding gb=System.Text.Encoding.GetEncoding("GB2312");
					string replys = gb.GetString((byte[])xmlHttp.responseBody);
					replys = replys.Substring(0,replys.Length-2);
					// 手机号码|?|内容|?|时间|?|<#>手机号码|?|内容|?|时间|?|
					if(replys.Length>11)
					{
						string[] reply = replys.Split(new char[]{'#'});

						foreach(string replyContents in reply)
						{
							string[] replyContent = (replyContents.Substring(0,replyContents.Length-2)).
								Split(new char[]{'?'});

							string phoneNum = replyContent[0].Replace("|","");
							phoneNum = phoneNum.Replace(">","");
							string contentText = replyContent[1].Replace("|","");
							string replyTime = replyContent[2].Replace("|","");

							string selectSql = "select count(*) from sms_reply_content where "
								+"replycontent_phonenum='"+phoneNum+"' and replycontent_date"
								+"='"+replyTime+"'";

							Database db = DatabaseFactory.CreateDatabase();
							DBCommandWrapper dbCom = db.GetSqlStringCommandWrapper(selectSql);

							int count = (int)db.ExecuteScalar(dbCom);

							if(count==0)
							{
								string insertSql = "insert into sms_reply_content(replycontent_phonenum,"
									+"replycontent_text,replycontent_date) values('"+phoneNum+"',"
									+"'"+contentText+"','"+replyTime+"')";

								DBCommandWrapper dbComInsert = db.GetSqlStringCommandWrapper(insertSql);
								db.ExecuteNonQuery(insertSql);
							}
						}
					}

				}

				//receive reply from union
				xmlHttp.open("POST" , urlUnion , false , null , null  );          
				xmlHttp.setRequestHeader( "CharSet" , "GB2312" );    

				xmlHttp.send( null );

				if(xmlHttp.status == 200)
				{
					System.Text.Encoding gb=System.Text.Encoding.GetEncoding("GB2312");
					string replys = gb.GetString((byte[])xmlHttp.responseBody);
					replys = replys.Substring(0,replys.Length-2);
					// 手机号码|?|内容|?|时间|?|<#>手机号码|?|内容|?|时间|?|
					if(replys.Length>11)
					{
						string[] reply = replys.Split(new char[]{'#'});

						foreach(string replyContents in reply)
						{
							string[] replyContent = (replyContents.Substring(0,replyContents.Length-3)).
								Split(new char[]{'?'});

							string phoneNum = replyContent[0].Replace("|","");
							phoneNum = phoneNum.Replace(">","");
							string contentText = replyContent[1].Replace("|","");
							string replyTime = replyContent[2].Replace("|","");

							string selectSql = "select count(*) from sms_reply_content where "
								+"replycontent_phonenum='"+phoneNum+"' and replycontent_date"
								+"='"+replyTime+"'";

							Database db = DatabaseFactory.CreateDatabase();
							DBCommandWrapper dbCom = db.GetSqlStringCommandWrapper(selectSql);
							
							int count = (int)db.ExecuteScalar(dbCom);

							if(count==0)
							{
								string insertSql = "insert into sms_reply_content(replycontent_phonenum,"
									+"replycontent_text,replycontent_date) values('"+phoneNum+"',"
									+"'"+contentText+"','"+replyTime+"')";

								DBCommandWrapper dbComInsert = db.GetSqlStringCommandWrapper(insertSql);
								db.ExecuteNonQuery(insertSql);
							}
						}
					}

				}
			}
			catch(Exception ex)
			{
				WriteLog(DateTime.Now.ToString()+" "+ex.Message,"短信异常");
			}
		}

		private void sendSMS()
		{
			string selectSql = "select sendcontent_id,sendcontent_phonenum,"
				+"sendcontent_text from sms_send_content";
			string deleteSql = "delete from sms_send_content where sendContent_sucStatus=1";

			Database db = DatabaseFactory.CreateDatabase();
			DBCommandWrapper dbComSelect = db.GetSqlStringCommandWrapper(selectSql);
			DBCommandWrapper dbComDelete = db.GetSqlStringCommandWrapper(deleteSql);

			IDataReader reder;
			
			try
			{
				reder = db.ExecuteReader(dbComSelect);

				while(reder.Read())
				{
					string spNumber = string.Empty;
					string sendMobilePhone = reder[1].ToString();

					switch(sendMobilePhone.Substring(2,1))
					{
						case "0":
							spNumber = "9002733";
							break;
						case "1":
							spNumber = "9002733";
							break;
						case "2":
							spNumber = "9002733";
							break;
						case "3":
							spNumber = "9002733";
							break;
						case "4":
							spNumber = "9002733";
							break;
						case "5":
							spNumber = "8002733";
							break;
						case "6":
							spNumber = "8002733";
							break;
						case "7":
							spNumber = "8002733";
							break;
						case "8":
							spNumber = "8002733";
							break;
						case "9":
							spNumber = "8002733";
							break;
					}

					string url = "http://202.96.236.81:7783/testDownMsg.asp?"
						+"UID=sap&psd=0F3E419C71C500FA1FC8&source="+spNumber+"&mobile="
						+sendMobilePhone+"&message="+reder[2].ToString();

					MSXML2.XMLHTTPClass xmlHttp = new MSXML2.XMLHTTPClass();
					xmlHttp.open("POST" , url , false , null , null  );          
					xmlHttp.setRequestHeader( "Accept-Lauguage" , "zh-cn" );    

					xmlHttp.send( null );          
                                    
					if(xmlHttp.status == 200)
					{
						if(xmlHttp.responseText == "0")
						{
							string log = DateTime.Now.ToString() + " Successed to Send " 
								+" One Message!";
							WriteLog(log,"短信异常");

							string updateSql = "update sms_send_content set sendContent_sucStatus=1 where sendcontent_id="
								+ reder[0].ToString();

							DBCommandWrapper dbComUpdate = db.GetSqlStringCommandWrapper(updateSql);

							db.ExecuteNonQuery(dbComUpdate);

						}
						else
						{
							string log = DateTime.Now.ToString() + " Failed to Send " 
								+" One Message!Please check the net connection or contact the "
								+"SP Provider to fix the problem";
							WriteLog(log,"短信异常");
						}
					}
				}

				db.ExecuteNonQuery(dbComDelete);

			}
			catch(Exception ex)
			{
				WriteLog(DateTime.Now.ToString()+" "+ex.Message,"短信异常");
			}
		}
		#endregion

		#region 自动时间同步
		private void SynchDate(object machineAddr)
		{
			try
			{
				DataFrame controlFrame = new DataFrame();
				controlFrame.sym = new byte[]{(byte)'@',(byte)'@'};
				controlFrame.desAddr = Convert.ToByte(machineAddr);
				controlFrame.comFrameLen = 15;
				controlFrame.srcAddr = 0;
				controlFrame.protocol = CPTT.SystemFramework.Util.TIME_SYNCH_TOKEN;
				controlFrame.seq = CPTT.SystemFramework.Util.FRAME_SEQUENCE_VALUE;
				controlFrame.frameData = new byte[7];

				controlFrame.frameData[0] = Convert.ToByte(DateTime.Now.Year%100);
				controlFrame.frameData[1] = Convert.ToByte((byte)DateTime.Now.Month);
				controlFrame.frameData[2] = Convert.ToByte((byte)DateTime.Now.Day);                            
				controlFrame.frameData[3] = Convert.ToByte((byte)(DateTime.Now.DayOfWeek+1));
				controlFrame.frameData[4] = Convert.ToByte((byte)DateTime.Now.Hour);
				controlFrame.frameData[5] = Convert.ToByte((byte)DateTime.Now.Minute);
				controlFrame.frameData[6] = Convert.ToByte((byte)DateTime.Now.Second);

				controlFrame.computeCheckSum();

				//Monitor.Enter(Login.handleComClass);
				handleComClass.WriteSerialCmd(controlFrame.comFrameLen,controlFrame.frameToBytes());//发送问询帧
				//			Login.handleComClass.WriteSerialCmd(15,new byte[]{(byte)'@',(byte)'@',1,15,0,4,0,
				//				06,10,5,1,22,22,22,236});
				//Monitor.Exit(Login.handleComClass);

				Thread.Sleep((int)CPTT.SystemFramework.Util.SEND_CARD_TIMER_OVERTIME);
			}
			catch
			{
			}
		}

		#endregion
	}
}
