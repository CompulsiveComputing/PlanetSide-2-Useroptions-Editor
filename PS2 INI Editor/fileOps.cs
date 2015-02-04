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
		public static void deleteFile(string filePath)
		{
			if(fileExists(filePath))
			{
				File.Delete(filePath);
			}
		}
		
		public static bool folderExists(string folderPath)
		{
			return Directory.Exists(folderPath);
		}
		
		public static bool fileExists(string filePath)
		{
			return File.Exists(filePath);
		}
		
		public static bool createFolder(string folderPath) // really need to put a try/catch in here; Urgent
		{
			if(!folderExists(folderPath))
			{
				var dir = Directory.CreateDirectory(folderPath);
				return true;
			}
			else
				return true;
		}
		
		public static bool checkWritable(string filePath)
		{
			throw new NotImplementedException();
		}
		
		public static bool checkReadable(string filePath)
		{
			throw new NotImplementedException();
		}
		
		public static bool setReadOnly(string filePath)
		{
			throw new NotImplementedException();
		}
		
		public static bool removeReadOnly(string filePath)
		{
			throw new NotImplementedException();
		}
		
		public static bool writeFile(string filePath, string fileContents) // really need to put a try/catch in here; Urgent
		{
			if (!Directory.Exists(Path.GetDirectoryName(filePath)))
			{
				MessageBoxResult result = MessageBox.Show("Folder not found, would you like to create it?", "Folder not found", MessageBoxButton.YesNo);
				if(result == MessageBoxResult.Yes)
					createFolder(Path.GetDirectoryName(filePath));
				else
					return false;
			}
			
			if(true) // needs to have checkWritable(filePath)
			{
				System.IO.File.WriteAllText(@filePath, fileContents);
				return true;
			}
			else
				return false;
		}
		
		public static string[] readFileAsArray(string filePath)
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
		
		public static string readFile(string filePath)
		{
			string[] returnedArray = readFileAsArray(filePath);
			return string.Join("",returnedArray);
		}
	}
}
