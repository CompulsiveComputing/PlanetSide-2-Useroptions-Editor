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
using System.Xml.Serialization;

namespace PS2_INI_Editor
{
	/// <summary>
	/// Description of settingsBank.
	/// </summary>
	public class settingsBank
	{
		//public string _activeFileName = "";
		public string settingsFolder;
		public int _defaultBackupsToKeep = 10;
		public string _userOptionsLocation;
		public bindableString _backupFolderLocation = new bindableString();
		public string _valueCatalogueLocation;
		public int _backupsToKeep;
		public string _valueCatalogueName;
		public List<String> _savedInstallLocations;
		public string _lastActiveInstall;
		public string _timeDateFormat;
		public bool _wasMaximized;
		public bool _rememberMaximized;
		
		public bool isInitialized = false;
		
		[XmlIgnoreAttribute]
		public string _currentWorkDirectory;
		
		[XmlIgnoreAttribute]
		public string _currentRootDirectory;
		
		public settingsBank initializeSettings()
		{
			_wasMaximized = false;
			_rememberMaximized = true;
			_userOptionsLocation = "";
			_backupFolderLocation.text = settingsFolder + "Backups\\";
			_valueCatalogueLocation = settingsFolder;
			_backupsToKeep = _defaultBackupsToKeep;
			_valueCatalogueName = "PS2UserOptionsCatalogue.xml";
			_timeDateFormat = "yyyy-MM-dd_HH_mm_ss";
			
			isInitialized = true;
			
			return this;
		}
		
		public settingsBank()
		{
			_currentWorkDirectory = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
			_currentRootDirectory = Directory.GetDirectoryRoot(_currentWorkDirectory).ToString();
		}
	}
}
