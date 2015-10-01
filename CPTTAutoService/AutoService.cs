//==================================================================================
// �������ܳ����������ϵͳ4.0
//==================================================================================
// Copyright @2005 Shanghai Chuangzhi Toy&Technology Corporation All rights reserved.
//������������ܰ�Ȩ���͹�����Լ����.
// ��δ����Ȩ�����Ը��ƻ򴫲�������(�������κβ���),���ܵ����������¼������Ʋ�,
//�����ڷ�����ɵķ�Χ���ܵ����̶ȵ�����!
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
			// �õ����� Windows.Forms ��������������ġ�
			InitializeComponent();

			// TODO: �� InitComponent ���ú�����κγ�ʼ��

			_alAuthenticatedHardWare = HardWareAuthentication.GetAuthorizedHardWare();
		}

		// ���̵�����ڵ�
		static void Main()
		{
			System.ServiceProcess.ServiceBase[] ServicesToRun;
	
			// ͬһ�����п������ж���û�������Ҫ��
			//��һ��������ӵ��˽��̣����������
			// �Դ�����һ������������磬
			//
			//   ServicesToRun = New System.ServiceProcess.ServiceBase[] {new Service1(), new MySecondUserService()};
			//
			ServicesToRun = new System.ServiceProcess.ServiceBase[] { new AutoService()};

			System.ServiceProcess.ServiceBase.Run(ServicesToRun);
		}

		/// <summary> 
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭�� 
		/// �޸Ĵ˷��������ݡ�
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
			timerTimeSynch.Interval = CPTT.SystemFramework.Util.TIMESYNCH_TIMER_INTERVAL;//����ʱ��ͬ��timer
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
		/// ������������ʹ�õ���Դ��
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
		/// ���þ���Ĳ������Ա�������ִ�����Ĺ�����
		/// </summary>
		protected override void OnStart(string[] args)
		{
			// TODO: �ڴ˴���Ӵ�������������
			comPortIsBusy = false;
			timerTimeSynch.Enabled = true;

			queryThread = new Thread(new ThreadStart(SendQuery));
			queryThread.IsBackground = true;
			queryThread.Priority = ThreadPriority.Normal;
			queryThread.Start();

			machineAddrList = machineSystem.GetMachineAddrList();
		}
 
		/// <summary>
		/// ֹͣ�˷���
		/// </summary>
		protected override void OnStop()
		{
			// TODO: �ڴ˴���Ӵ�����ִ��ֹͣ��������Ĺرղ�����
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
		//��ѯָ��
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
								handleComClass.WriteSerialCmd(CPTT.SystemFramework.Util.CONTROL_FRAME_LENGTH,controlFrame.convertToBytes());//������ѯ֡
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
//							handleComClass.WriteSerialCmd(CPTT.SystemFramework.Util.CONTROL_FRAME_LENGTH,controlFrame.convertToBytes());//������ѯ֡
//							Monitor.Exit(handleComClass);
//
//							Thread.Sleep(CPTT.SystemFramework.Util.QUERY_TIMER_INTERVAL);
//						}
//					}
//					else Thread.Sleep(CPTT.SystemFramework.Util.QUERY_NULL_INTERVAL);
				}
			}
		}

		//�������ݵ���ʱ����
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

				if(ReceiveData[5] == 0x08&&ReceiveData[2]==0)//�����ˢ��ͨѶ֡����
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

		//����ί�д���������
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

		//ʱ��ͬ��
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
//			timeSynchFrame.frameData[0] = (byte)(DateTime.Now.Year%100);//2λ����
//			timeSynchFrame.frameData[1] = (byte)DateTime.Now.Month;//��
//			timeSynchFrame.frameData[2] = (byte)DateTime.Now.Day;//��
//			timeSynchFrame.frameData[3] = (byte)(DateTime.Now.DayOfWeek+1);//����
//			timeSynchFrame.frameData[4] = (byte)DateTime.Now.Hour;//ʱ
//			timeSynchFrame.frameData[5] = (byte)DateTime.Now.Minute;//��
//			timeSynchFrame.frameData[6] = (byte)DateTime.Now.Second;//��
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
					WriteLog(DateTime.Now.ToString()+" "+ex.Message,"�����쳣");
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
					WriteLog(DateTime.Now.ToString()+" "+ex.Message,"�����쳣");
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
					// �ֻ�����|?|����|?|ʱ��|?|<#>�ֻ�����|?|����|?|ʱ��|?|
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
					// �ֻ�����|?|����|?|ʱ��|?|<#>�ֻ�����|?|����|?|ʱ��|?|
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
				WriteLog(DateTime.Now.ToString()+" "+ex.Message,"�����쳣");
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
							WriteLog(log,"�����쳣");

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
							WriteLog(log,"�����쳣");
						}
					}
				}

				db.ExecuteNonQuery(dbComDelete);

			}
			catch(Exception ex)
			{
				WriteLog(DateTime.Now.ToString()+" "+ex.Message,"�����쳣");
			}
		}
		#endregion

		#region �Զ�ʱ��ͬ��
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
				handleComClass.WriteSerialCmd(controlFrame.comFrameLen,controlFrame.frameToBytes());//������ѯ֡
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
