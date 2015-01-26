/*
 * Created by SharpDevelop.
 * User: Devahlin
 * Date: 16/01/2015
 * Time: 1:41 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Collections.ObjectModel;

namespace PS2_INI_Editor
{
	/// <summary>
	/// Description of Head.
	/// </summary>
	public class PS2ConfigurationHead
	{
		
		public string _applicationName = "PlanetSide 2 Configurations Editor";
		public string _applicationShortName = "PS2 Config Editer";
		public string _versionString = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
		
		public INIinterfacer _currentUserOptionsINI;
		
		public List<INIinterfacer> _backupINIlist = new List<INIinterfacer>();
		
		public bool changesPending = false;
		
		public settingsBank currentConfiguration = new settingsBank();
		
		public ObservableCollection<String> discoveredGameInstallations { get; set; }
		
		public ValueCatalogue ValuesCatalogue = new ValueCatalogue();
		
		private int _selectedGameInstallation;
			
		public int selectedGameInstallation
		{
			get
			{
				return _selectedGameInstallation;
			}
			set
			{
				if(value >= 0 && value < discoveredGameInstallations.Count && SwitchToInstallation(value))
					_selectedGameInstallation = value;
			}
		}
		
		public bool SwitchToInstallation(int installIndex)
		{
			if(installIndex == -1)
				return false;
				
			if (changesPending)
			{
				MessageBoxResult result = MessageBox.Show("Do you want to save changes before continuing?", "Changes Pending", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
				if (result == MessageBoxResult.Yes)
				{
					// save ini and other files
					throw new NotImplementedException();
				}
				else if (result == MessageBoxResult.Cancel)
				{
					return false;
				}
				
			}
			
			//MessageBox.Show(_discoveredGameInstallations[installIndex], "boop");
			_currentUserOptionsINI._location = discoveredGameInstallations[installIndex] + "UserOptions.ini";
				
			return _currentUserOptionsINI.loadINI();
		}
		
		public string[] _defaultGamePaths =
		{
			"Program Files (x86)\\Steam\\steamapps\\common\\PlanetSide 2\\",
			"Program Files\\Steam\\steamapps\\common\\PlanetSide 2\\",
			"Program Files (x86)\\PlanetSide 2\\",
			"Program Files\\PlanetSide 2\\",
			"Users\\Public\\Sony Online Entertainment\\Installed Games\\PlanetSide 2\\",
			"Planetside 2\\"
		};
		
		public void CloseApplication()
		{
			if(changesPending)
			{
				MessageBoxResult result = MessageBox.Show("Do you want to exit without saving?", "Changes Pending", MessageBoxButton.YesNo, MessageBoxImage.Question);
				if (result == MessageBoxResult.Yes)
				{
					Application.Current.Shutdown();
				}
			}
			else
			{
				Application.Current.Shutdown();
			}
		}
		
		public void InitializeHead()
		{
			populateFoundInstallations();
		}
		
		public void populateFoundInstallations()
		{
			List<String> logicalDriveLetters = new List<string>(System.IO.Directory.GetLogicalDrives());
			
			String checkingDirectory = "";
			
			Console.WriteLine("Found " + logicalDriveLetters.Count.ToString() + "drives to check.");
			
			for (int currentDrive = 0; currentDrive < logicalDriveLetters.Count; currentDrive++)
			{
				for(int currentPath=0;currentPath<_defaultGamePaths.Length;currentPath++)
				{
					checkingDirectory = logicalDriveLetters[currentDrive]+_defaultGamePaths[currentPath];
					
					Console.WriteLine("Checking for: " + checkingDirectory +"PlanetSide2.exe");
					
					if (File.Exists(checkingDirectory+"PlanetSide2.exe"))
					{
						Console.WriteLine("Found installation: " + checkingDirectory);
						discoveredGameInstallations.Add(checkingDirectory);
						break;
					}
				}
			}
		}
		
		
		public PS2ConfigurationHead()
		{
			discoveredGameInstallations = new ObservableCollection<string>();
			_currentUserOptionsINI = new INIinterfacer();
			_selectedGameInstallation = -1;
		}
	}
}
