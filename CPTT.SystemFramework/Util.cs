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
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Management;
using RexDataProtector;
using System.IO;
using System.Data;
using System.Net;
using System.Text;
using System.Reflection;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Configuration;
using System.Security.Cryptography;
using AjaxPro;

namespace CPTT.SystemFramework
{
	/// <summary>
	/// Util 的摘要说明。
	/// </summary>
	public class Util
	{
		#region window service name
		public const string AUTO_SERVICE_NAME = "CPTT4.0AutoService";
		#endregion

		public const string HELP_FILE_NAME = @"\\创智智能晨检网络管理系统（第四代）联机丛书.chm";
		private static int maxClients = 0;

		#region AutoUpdate Address Set
		public static string AUTO_UPDATE_ADDRESS = ((
			ConfigurationManager.GetConfiguration("CustomizeSettings") 
			as ArrayList)[6] as XmlNode[])[1].InnerText;
		#endregion

		#region timer参数设置
		public const double SEND_CARD_TIMER_OVERTIME = 5000;//10000;//发卡超时时间
		public static int QUERY_TIMER_INTERVAL = Convert.ToInt32(((
			ConfigurationManager.GetConfiguration("CustomizeSettings") 
			as ArrayList)[0] as XmlNode[])[1].InnerText);//问询帧发送时间间隔
		public const double TIMESYNCH_TIMER_INTERVAL = 5*60*1000;//时间同步间隔设置
		public const int QUERY_AUTHENTICATION_INTERVAL = 2000;
		public const int QUERY_NULL_INTERVAL = 4000;
		#endregion

		#region Protocol参数设置
		public const byte ASSIGN_DOOR_ADDRESS = 0x00;
		public const byte QUERY_TOKEN = 0x02;
		public const byte TIME_SYNCH_TOKEN = 0x04;
		public const byte SEND_CARD_TOKEN = 0x05;
		public const byte LOGOUT_CARD_TOKEN = 0x06;
		public const byte LEAVE_SCHOOL_TOKEN = 0x07;
		public const byte SET_CLASSROOM_VOLUME = 0x09;
		public const byte SET_DOOR_VOLUME = 0x0a;
		public const byte VALIDATE_CARD_RETURN_TOKEN = 0x0b;
		public const byte VALIDATE_CARD_TOKEN = 0x0c;
		public const byte BATCH_SEND_CARD_TOKEN = 0x0d;
		public const byte HARDWARE_AUTHENTICATION = 0x0e;
		public const byte SEND_USERNAME_TOKEN = 0x11;
		public const byte SEND_CUSTOMBUTTON_TOKEN = 0x12;
		public const byte SEND_CUSTOMBUTTON_TEACHER_TOKEN = 0x13;
		public const byte SEND_CLASSNAME_TOKEN = 0x14;
		#endregion

		#region Response参数设置
		public const byte SEND_CARD_SUCCESS_TOKEN = 0x05;
		public const byte RECEIVE_SUCCESS_TOKEN = 0x0b;
	
		#endregion

		#region 通讯帧参数设置
		public const int CONTROL_FRAME_LENGTH = 7;
		public const byte FRAME_SEQUENCE_VALUE = 0;
		#endregion

		#region 日志参数设置
		public const string EXCEPTION_LOG_TITLE = "异常信息";
		#endregion

		#region 串口参数设置
		public static short COM1_PORT_NUMBER = Convert.ToInt16(
			((ConfigurationManager.GetConfiguration("CustomizeSettings") 
			as ArrayList)[1] as XmlNode[])[1].InnerText);
		public const int COM_BAUD_RATE = 9600;
		#endregion

		#region 用户信息
		public const string PROVINCE_INFO = "021";
		public const string IS_AGENT_INFO = "00000000";
		#endregion

		#region 版本信息  
        //对应4.32.8.2u
		public const string PROJECT_VERSION = "4.33.2.1u";
		public static string useVersion = string.Empty;
		#endregion

		#region 本地网络信息
		private static string macAddr = string.Empty;
		private static string ipAddr = string.Empty;
		#endregion

		#region webservice信息
		private static string WSDL = ((ConfigurationManager.GetConfiguration("CustomizeSettings") 
			as ArrayList)[8] as XmlNode[])[1].InnerText;
		#endregion

        #region 是否上传版本
        public static bool IsUploadVersion = ((ConfigurationManager.GetConfiguration("CustomizeSettings")
            as ArrayList)[10] as XmlNode[])[1].InnerText == "1";
        #endregion

		private Util()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//

			
		}

		public static int CardVersion
		{
			get
			{
				string cardVersionStr = "5";

				ArrayList configList = ConfigurationManager.GetConfiguration("CustomizeSettings") as ArrayList;
				if (configList.Count >= 9)
				{
					cardVersionStr =  (configList[9] as XmlNode[])[1].InnerText;
				}

				int cardVersion = Convert.ToInt32(cardVersionStr);
				cardVersion = cardVersion >= 5 ? 5 : cardVersion;
				return cardVersion;
			}
		}

		public static int MaxClients
		{
			get
			{
				return maxClients;
			}
			set
			{
				maxClients = value;
			}
		}
	
		public static string UseVersion
		{
			get
			{
				try
				{
					string root = AppDomain.CurrentDomain.BaseDirectory;
					FileInfo fi = new FileInfo(root + @"\Version.config");
					XmlDocument myDoc = new XmlDocument();
					myDoc.Load(fi.FullName);

					XmlNodeList nodeList = myDoc.SelectSingleNode("configuration").ChildNodes;
					foreach (XmlNode node in nodeList)
					{
						XmlElement xm = (XmlElement)node;
						if (xm.Name == "version")
						{
							useVersion = new DataProtector().InitInfoDecryp(xm.InnerText);
						}
					}

					return useVersion;
				}
				catch(Exception ex)
				{
					Util.WriteLog(ex.Message,Util.EXCEPTION_LOG_TITLE);
					return string.Empty;
				}
			}
		}

		public static void WriteLog(string message,string logTitle)
		{
			LogEntry log = new LogEntry();
			log.EventId = 1;
			log.Message = message;
			log.Category = "Trace";
			log.Priority = 0;
			log.Title = logTitle;
			Logger.Write(log);
		}

		public static void FillCard(DataFrame cardFrame,int cardNumber,int cardIndex)
		{
			cardFrame.frameData[2+cardIndex] = (byte)((cardNumber & 0xff000000) >> 24);
			cardFrame.frameData[3+cardIndex] = (byte)((cardNumber & 0x00ff0000) >> 16);
			cardFrame.frameData[4+cardIndex] = (byte)((cardNumber & 0x0000ff00) >> 8);
			cardFrame.frameData[5+cardIndex] = (byte)(cardNumber & 0x000000ff);
		}

		//compute checksum to ensure de integrity of one frame
		public static bool ComputeCheckSum(byte[] frame)
		{
			byte checkSum = 0;

			for(int i=0;i<frame.Length-1;i++)
			{
				checkSum += (byte)(frame[i]);
			}

			if(checkSum==frame[frame.Length-1])
				return true;
			else
				return false;
		}

		public static bool IsValidFrame(byte[] frame,ref byte sym,ref byte[] rebuiltData)
		{
			for ( int i=0; i<frame.Length; i++ )
			{
				if ( frame[i] == '*'&& frame[i+1] == '*' )
				{
					sym = frame[i];

					if ( IsCompleteFrame(0,i,frame,ref rebuiltData) ) return true;
				}
				else if ( frame[i] == '@' && frame[i+1] == '@' )
				{
					sym = frame[i];

					if ( IsCompleteFrame(1,i,frame,ref rebuiltData) ) return true;
				}
			}

			return false;
		}

		private static bool IsCompleteFrame(int type,int startIndex,byte[] frame,ref byte[] rebuiltData)
		{
			byte checkSum = 0;

			if ( type == 0 )
			{
				for ( int i=startIndex; i<startIndex+6; i++ )
				{
					checkSum += (byte)(frame[i]);
				}

				if ( checkSum == frame[startIndex+6] )
				{
					rebuiltData = new byte[7];
					for ( int i=0; i<=6; i++ )
					{
						rebuiltData[i] = frame[startIndex+i];
					}

					return true;
				}
			}
			else
			{
				int comFrameLength = Convert.ToInt32(frame[startIndex+3]);

				for ( int i=startIndex; i<startIndex+comFrameLength-1; i++ )
				{
					checkSum += (byte)(frame[i]);
				}

				if ( checkSum == frame[startIndex+comFrameLength-1] )
				{
					rebuiltData = new byte[comFrameLength];
					for ( int i=0; i<comFrameLength; i++ )
					{
						rebuiltData[i] = frame[startIndex+i];
					}

					return true;
				}

//				for ( int i=startIndex; i<startIndex+5; i++ )
//				{
//					checkSum += (byte)(frame[i]);
//				}
//
//				for ( int i=startIndex+5; i<frame.Length-1; i++ )
//				{
//					checkSum += (byte)(frame[i]);
//
//					if ( checkSum == frame[i+1] )
//					{
//						rebuiltData = new byte[i+2];
//						for ( int j=0; j<=i+1; j++ )
//						{
//							rebuiltData[j] = frame[startIndex+j];
//						}
//
//						return true;
//					}
//				}
			}

			return false;
		}

		public static string MacAddress
		{
			get
			{
				string macAddress = string.Empty;
				ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration"); 
				ManagementObjectCollection moc = mc.GetInstances();

				foreach( ManagementObject mo in moc ) 
				{
					if( (bool)mo["IPEnabled"] )
					{
						macAddress = mo["MacAddress"].ToString();
					}
				}

				return macAddress;
			}
		}

		public static string IPAddress
		{
			get
			{
				string ipAddress = string.Empty;
				ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration"); 
				ManagementObjectCollection moc = mc.GetInstances();

				foreach( ManagementObject mo in moc ) 
				{
					if( (bool)mo["IPEnabled"] )
					{
						string[] IPAddress = (string[])mo["IPAddress"]; 
						if( IPAddress.Length > 0 ) 
						{
							ipAddress = IPAddress[0];
						}	
					}
				}

				return ipAddress;
			}
		}

		public static string WebserviceURL
		{
			get
			{
				return (WSDL.Split('$'))[0];
			}
		}

		public static string WebserviceClassName
		{
			get
			{
				return (WSDL.Split('$'))[1];
			}
		}

		public static string WebServiceMethod
		{
			get
			{
				return (WSDL.Split('$'))[2];
			}
		}

		public static object UploadData(string url, string @namespace, string classname, 
			string methodname, object[] args, ArrayList al)
		{
			try
			{
				System.Net.WebClient wc = new System.Net.WebClient();
				//System.IO.Stream stream = wc.OpenRead(url + "?WSDL");
				System.IO.Stream stream = wc.OpenRead(url);
				System.Web.Services.Description.ServiceDescription sd = System.Web.Services.Description.ServiceDescription.Read(stream);
				System.Web.Services.Description.ServiceDescriptionImporter sdi = new System.Web.Services.Description.ServiceDescriptionImporter();
				sdi.AddServiceDescription(sd, string.Empty, string.Empty); //将sd描述导入到sdi中
				System.CodeDom.CodeNamespace cn = new System.CodeDom.CodeNamespace(@namespace);
				System.CodeDom.CodeCompileUnit ccu = new System.CodeDom.CodeCompileUnit();
				ccu.Namespaces.Add(cn);
				sdi.Import(cn, ccu);

				Microsoft.CSharp.CSharpCodeProvider csc = new Microsoft.CSharp.CSharpCodeProvider();
				System.CodeDom.Compiler.ICodeCompiler icc = csc.CreateCompiler();

				System.CodeDom.Compiler.CompilerParameters cplist = new System.CodeDom.Compiler.CompilerParameters();
				cplist.GenerateExecutable = false;
				cplist.GenerateInMemory = true;
				cplist.ReferencedAssemblies.Add("System.dll");
				cplist.ReferencedAssemblies.Add("System.XML.dll");
				cplist.ReferencedAssemblies.Add("System.Web.Services.dll");
				cplist.ReferencedAssemblies.Add("System.Data.dll");

				System.CodeDom.Compiler.CompilerResults cr = icc.CompileAssemblyFromDom(cplist, ccu);
				if (cr.Errors.HasErrors)
				{
					System.Text.StringBuilder sb = new System.Text.StringBuilder();
					foreach (System.CodeDom.Compiler.CompilerError ce in cr.Errors)
					{
						sb.Append(ce.ToString());
						sb.Append(System.Environment.NewLine);
					}
					throw new Exception(sb.ToString());
				}

				System.Reflection.Assembly assembly = cr.CompiledAssembly;
				Type t = assembly.GetType(@namespace + "." + classname, true, true);
				object obj = Activator.CreateInstance(t);

				ParameterModifier[] paramsModifer = new ParameterModifier[1];
				paramsModifer[0] = new ParameterModifier(args.Length);
				//paramsModifer[0][7] = true;

				object result = t.InvokeMember(methodname, BindingFlags.Default | BindingFlags.InvokeMethod, null,
					obj, args, paramsModifer, null, null);

				//al.Add(args[7]);
				return result;
			}
			catch (Exception ex)
			{
				WriteLog(ex.Message, EXCEPTION_LOG_TITLE);
				return null;
			}
		}

		//新豆豆上传
		public static void UploadDataToXDD(DataTable data)
		{
			string url = "http://xdd.xindoudou.cn/2/partner/check";
			if (data.Rows.Count > 0)
			{
				//注意，SP把日期写死了
				string key = "76e8e4411055443c9def688b969c9ac6";
				foreach(DataRow dr in data.Rows)
				{
					HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
					request.Method = "POST";
					request.ContentType = "application/x-www-form-urlencoded";
					request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";

					StringBuilder sb = new StringBuilder();
					sb.Append(key);
					sb.Append(string.Format("check_type={0}", dr["flow_stuFlowBackState"].ToString() != "-2" ? 1 : 0));
					sb.Append(string.Format("&class_id={0}", dr["info_machineAddr"].ToString()));
					sb.Append(string.Format("&school_id={0}", dr["gardenID"].ToString()));
					sb.Append(string.Format("&student_id={0}", dr["stuID"].ToString()));

					byte[] hash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(sb.ToString()));
					sb = new StringBuilder();
					foreach(byte b in hash)
					{
						sb.Append(b.ToString("x2"));
					}


					byte[] val = Encoding.UTF8.GetBytes(string.Format("key={0}&school_id={1}&class_id={2}&student_id={3}&check_type={4}&md5={5}",
						key, dr["gardenID"].ToString(), dr["info_machineAddr"].ToString(), dr["stuID"].ToString(), dr["flow_stuFlowBackState"].ToString() != "-2" ? 1 : 0, sb.ToString()));


					using (Stream stream = request.GetRequestStream())  
					{
						stream.Write(val, 0, val.Length);  
					}

					WebResponse response = request.GetResponse();
					using(StreamReader reader = new StreamReader(response.GetResponseStream()))
					{
						string s = reader.ReadToEnd();
					}
				}
			}
		}

		public static void UploadInfoToXDD(string gardenID, string gardenName, DataTable data)
		{
			string url = "http://xdd.xindoudou.cn/2/partner/sync";
			if (data.Rows.Count > 0)
			{
				string key = "76e8e4411055443c9def688b969c9ac6";
				Hashtable ht = new Hashtable();
				foreach(DataRow dr in data.Rows)
				{
					string classNumber = dr["info_machineAddr"].ToString();
					if (classNumber != null && classNumber != string.Empty)
					{
						Class @class = null;
						if (!ht.ContainsKey(classNumber))
						{
							@class = new Class();
							@class.id = dr["info_machineAddr"].ToString();
							@class.name = dr["info_className"].ToString();
							@class.students = new ArrayList();
							ht[classNumber] = @class;
						}
						else
						{
							@class = ht[classNumber] as Class;
						}
						student stu = new student();
						stu.id = dr["info_stuID"].ToString();
						stu.name = dr["info_stuName"].ToString();
						@class.students.Add(stu);
					}
				}

				ClassList list = new ClassList();
				list.List = new ArrayList();
				foreach(Class @class in ht.Values)
				{
					list.List.Add(@class);
				}
				
				HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
				request.Method = "POST";
				request.ContentType = "application/x-www-form-urlencoded";
				request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";

				StringBuilder sb = new StringBuilder();
				sb.Append(key);
				sb.Append("city=");
				sb.Append("&province=");
				sb.Append(string.Format("&school_id={0}", gardenID));
				sb.Append(string.Format("&school_name={0}", gardenName));

				byte[] hash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(sb.ToString()));
				sb = new StringBuilder();
				foreach(byte b in hash)
				{
					sb.Append(b.ToString("x2"));
				}

				string json = AjaxPro.JavaScriptSerializer.Serialize(list);
				json = json.Substring(8, json.Length - 9);
				byte[] val = Encoding.UTF8.GetBytes(string.Format("key={0}&school_id={1}&school_name={2}&province={3}&city={4}&md5={5}&classes={6}",
					key, gardenID, gardenName, string.Empty, string.Empty, sb.ToString(), json));


				using (Stream stream = request.GetRequestStream())  
				{
					stream.Write(val, 0, val.Length);  
				}

				WebResponse response = request.GetResponse();
				using(StreamReader reader = new StreamReader(response.GetResponseStream()))
				{
					string s = reader.ReadToEnd();
				}
			}
		}

        public class HexStringConverter
        {
            public virtual string ToString(byte[] bytes)
            {
                return bytes
                    .Select(c => c.ToString("X2"))
                    .Aggregate((p, n) => p + n)
                    .ToLower();
            }

            public virtual byte[] FromString(string text)
            {
                byte[] bytes = new byte[text.Length / 2];
                for (int i = 0; i < bytes.Length; i++)
                {
                    bytes[i] = Convert.ToByte(text.Substring(i * 2, 2), 16);
                }

                return bytes;
            }
        }

		public class ClassList
		{
			private ArrayList _list;
			public ArrayList List
			{
				get { return _list; }
				set { _list = value; }
			}
		
		}

		public class Class
		{
			private string _id;
			public string id
			{
				get { return _id; }
				set { _id = value; }
			}

			private string _name;
			public string name
			{
				get { return _name; }
				set { _name = value; }
			}

			private ArrayList _students;
			public ArrayList students
			{
				get { return _students; }
				set { _students = value; }
			}
		}

		public class student
		{
			private string _id;
			public string id 
			{
				get { return _id; }
				set { _id = value; }
			}

			private string _name;
			public string name
			{
				get { return _name; }
				set { _name = value; }
			}
		}
	}
}
