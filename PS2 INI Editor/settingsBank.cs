/*
 * Created by SharpDevelop.
 * User: Devahlin
 * Date: 16/01/2015
 * Time: 1:49 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Windows;
using System.Collections.Generic;

namespace PS2_INI_Editor
{
	/// <summary>
	/// Description of settingsBank.
	/// </summary>
	public class settingsBank
	{
		
		public int _defaultIncrimentalBackupsToKeep;
		public string _userOptionsLocation;
		public string _backupFolderLocation;
		public string _valueCatalogueLocation;
		public int _incrimentalBackupsToKeep;
		
		//public string _activeFileName = "";
		
		public string _currentWorkDirectory;
		public string _currentRootDirectory;
		public string _valueCatalogueName;
		public List<String> _savedInstallLocations;
		
		
		
		public settingsBank()
		{
			_defaultIncrimentalBackupsToKeep = 0;
			_userOptionsLocation = "";
			_backupFolderLocation = "";
			_valueCatalogueLocation = "";
			_incrimentalBackupsToKeep = 0;
			
			
			_currentWorkDirectory = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
			_currentRootDirectory = Directory.GetDirectoryRoot(_currentWorkDirectory).ToString();
			_valueCatalogueName = "ps2useroptionscatalogue.xml";
		}
	}
}
