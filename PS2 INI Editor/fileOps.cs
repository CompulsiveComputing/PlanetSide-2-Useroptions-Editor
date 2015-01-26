/*
 * Created by SharpDevelop.
 * User: Devahlin
 * Date: 16/01/2015
 * Time: 1:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Windows;

namespace PS2_INI_Editor
{
	/// <summary>
	/// Description of fileOps.
	/// </summary>
	public class fileOps
	{
		public static bool checkWritable()
		{
			throw new NotImplementedException();
		}
		
		public static bool checkReadable()
		{
			throw new NotImplementedException();
		}
		
		public static bool setReadOnly()
		{
			throw new NotImplementedException();
		}
		
		public static bool removeReadOnly()
		{
			throw new NotImplementedException();
		}
		
		public static string[] readFile(string filePath)
		{
			if (File.Exists(filePath))
			{
				string[] _lines = System.IO.File.ReadAllLines(@filePath);
				return _lines;
			}
			else
			{
				MessageBox.Show("File could not be read from:" + filePath, "File related error");
				return null;
			}
		}
	}
}
