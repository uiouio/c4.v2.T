/* File: jsonSerializable.cs
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

namespace json.attributes
{
	/// <summary>
	/// Summary description for JSONSerializable.
	/// </summary>
	[AttributeUsage(System.AttributeTargets.Property)]
	public class jsonSerializable : Attribute
	{
		private bool _isSerializable = true;

		public jsonSerializable(){this._isSerializable = true;}
		
		public jsonSerializable(bool isSerializable){this._isSerializable = isSerializable;}

		public bool IsSerializable
		{
			get{return this._isSerializable;}
			set{this._isSerializable = value;}
		}
	}
}
