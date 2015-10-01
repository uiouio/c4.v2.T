/* File: jsonSerializer.cs
 * Author: Peter Zorbas
 * Date: March 20, 2010
 * 
 * This program is free software: you can redistribute it 
 * and/or modify it under the terms of the jsonSerializer licence. 
 * The full text of the licence can be found at:
 * http://jsonserializer.codeplex.com/license
 * 
 * All files are provided as is without warranty or support.
 * The user must follow the guidelines oulined in the GNU license and
 * agrees the Author will not be held liable for any damages caused.
 * 
 * Please leave feedback and comments at: http://jsonserializer.codeplex.com
 * 
 */

using System;
using System.Collections;
using System.Reflection;
using System.Text;
using System.Data;

namespace json
{
	/// <summary>
	/// Summary description for JSON.
	/// </summary>
	public class jsonSerializer
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static string jsonSerialize(object obj)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			parseObject(obj, sb);
			return sb.ToString();
		}


		/// <summary>
		/// Serializes a data table to a json string.
		/// </summary>
		/// <param name="table"></param>
		/// <returns></returns>
		public static string jsonSerialize(DataTable table)
		{
			StringBuilder sb = new StringBuilder();
			if(table!=null)
			{
				foreach(DataRow row in table.Rows)
				{
					if(row.Table!=null && row.Table.Columns!=null && row.Table.Columns.Count>0)
					{
						foreach(DataColumn column in row.Table.Columns)
						{
							parseMember(row[column], column.ColumnName, sb);
						}
					}
				}
			}
			return sb.ToString();
		}


		/// <summary>
		/// Method appends string to the string builder object.
		/// We assume that we either are passing primitive object members,
		/// array of objects or primitive, and arraylists of the former mentioned.
		/// You'll find recursive calls to the parseObject() function for child classes
		/// within an object.
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="sb"></param>
		private static void parseObject(object obj, StringBuilder sb)
		{
			if(obj!=null)
			{
				int i=0;
				Type objType = obj.GetType();
				PropertyInfo [] properties = objType.GetProperties();
				sb.AppendFormat("'{0}':{1}", objType.Name, character.LEFTPARENTHESE);
				//Loop through each property and call Parse method.
				foreach(PropertyInfo pi in properties)
				{
					bool process = true;
					object [] attrib = pi.GetCustomAttributes(typeof(json.attributes.jsonSerializable), false);
					if(attrib!=null && attrib.Length>0)
						//We assume only the first received decorated member attribute.
						process = (attrib[0] as json.attributes.jsonSerializable).IsSerializable;
					if(process)
					{
						//Get the method so we can know what ReturnType we need to process.
						MethodInfo methodInfo = pi.GetGetMethod(false);
						if(methodInfo.ReturnType.IsPrimitive || isOfReturnType(methodInfo.ReturnType))
							parseMember(pi.GetValue(obj, null), pi.Name, sb);
							//ArrayLists are considered objects, let's be explicit here.
						else if(methodInfo.ReturnType == typeof(ArrayList))
							parseArrayList(pi.GetValue(obj, null) as ArrayList, pi.Name, sb);
						else if(methodInfo.ReturnType.IsArray)
							parseArray(pi.GetValue(obj, null), pi.Name, sb);
						else if(methodInfo.ReturnType.IsClass)
							parseObject(pi.GetValue(obj,  null), sb);
						if(++i<properties.Length)
							sb.Append(character.COMMA);
					}
				}
				sb.Append(character.RIGHTPARENTHESE);
			}
		}


		/// <summary>
		/// Appends object member data, most presumably a string or primitive number type.
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="memberName"></param>
		/// <param name="sb"></param>
		private static void parseMember(object val, string memberName, StringBuilder sb)
		{
			Type t = val.GetType();
		
			if(memberName!=null && memberName.Trim().Length>0)
				sb.AppendFormat("'{0}':'", memberName);
			if(typeof(string)==t || typeof(char)==t)
				sb.AppendFormat("'{0}'", val.ToString());
			else
				sb.AppendFormat("{0}", val.ToString());
		}


		/// <summary>
		/// Calls parseArray to further process data.
		/// </summary>
		/// <param name="array"></param>
		/// <param name="memberName"></param>
		/// <param name="sb"></param>
		private static void parseArrayList(ArrayList array, string memberName, StringBuilder sb)
		{
			parseArray(array.ToArray(), memberName, sb);
		}


		/// <summary>
		/// Parses primitive array members, or objects.
		/// </summary>
		/// <param name="array"></param>
		/// <param name="memberName"></param>
		/// <param name="sb"></param>
		private static void parseArray(object array, string memberName, StringBuilder sb)
		{
			Array tempArray = array as Array;
			if(tempArray!=null && tempArray.Length>0)
			{
				sb.AppendFormat("'{0}': [", memberName);
				foreach(object item in tempArray)
				{
					Type t = item.GetType();
					if(t.IsPrimitive || isOfReturnType(item.GetType()))
						sb.AppendFormat("'{0}'", item.ToString());
					else if(t.IsClass)
						parseObject(item, sb);
				}
				sb.AppendFormat("]");
			}
		}


		/// <summary>
		/// Method is used to tell us whether the type of of a member type.  Reason is that
		/// strings are really objects in the CLR.  We'll need to handle these and any other types
		/// we assume to be primitive types - such as strings.
		/// </summary>
		/// <param name="t"></param>
		/// <returns></returns>
		private static bool isOfReturnType(Type t)
		{
			if(t == typeof(string))
				return true;
			return false;
		}
	}

	/// <summary>
	/// Summary description for Char.
	/// </summary>
	public class character
	{
		public static char NULL = '\x0000';//Null isOfReturnType
		public static char BELL = '\x0007';//Bell
		public static char BACKSPACE = '\x0008';//Backspace[t 4][t 5]
		public static char TAB = '\x0009';//Horizontal Tab
		public static char LINEFEED = '\x000A';//Line feed
		public static char VTAB = '\x000B';//Vertical Tab
		public static char CR = '\x000D';//Carriage return
		public static char LEFTPARENTHESE = '\x007B';//{
		public static char RIGHTPARENTHESE = '\x007D';//}
		public static char COMMA = '\x002C';//,
		
		/*public static char SPACE = '\x0020';//[space]
		public static char EXCLAMATION = '\x0021';//!
		public static char DOUBLEQUOTE = '\x0022';//"
		public static char NUMBER = '\x0023';//#
		public static char DOLLAR = '\x0024';//$
		public static char PERCENT = '\x0025';//%
		public static char AMPERSAND = '\x0026';//&
		public static char SINGLEQUOTE = '\x0027';//'
		public static char LEFTBRACKET = '\x0028';//(
		public static char RIGHTBRACKET = '\x0029';//)
		public static char ASTERIK = '\x002A';//*
		public static char PLUS = '\x002B';//+
		public static char SUBTRACT = '\x002D';//-
		public static char PERIOD = '\x002E';//.
		public static char FORWARDSLASH = '\x002F';///
		public static char LEFTSQUAREBRACKET = '\x005B';//[
		public static char BACKSLASH = '\x005C';//\
		public static char RIGHTSQUAREBRACKET = '\x005D';//]
		public static char UNDERSCORE = '\x005F';//_
		public static char LEFTPARENTHESES = '\x007B';//{
		public static char RIGHTPARENTHESES = '\x007D';//}
		*/
	}

}
