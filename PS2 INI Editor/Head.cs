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
using System.Globalization;

using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace PS2_INI_Editor
{
	/// <summary>
	/// Description of Head.
	/// </summary>
	public class PS2ConfigurationHead
	{
		
		[DllImport("kernel32.dll",
		           EntryPoint = "GetStdHandle",
		           SetLastError = true,
		           CharSet = CharSet.Auto,
		           CallingConvention = CallingConvention.StdCall)]
		private static extern IntPtr GetStdHandle(int nStdHandle);
		[DllImport("kernel32.dll",
		           EntryPoint = "AllocConsole",
		           SetLastError = true,
		           CharSet = CharSet.Auto,
		           CallingConvention = CallingConvention.StdCall)]
		private static extern int AllocConsole();
		private const int STD_OUTPUT_HANDLE = -11;
		private const int MY_CODE_PAGE = 437;
		
		public string _applicationName = "PlanetSide 2 Configurations Editor ALPHA";
		public string _applicationShortName = "PS2 Config Editer ALPHA";
		public string _versionString = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
		
		public INIinterfacer _currentUserOptionsINI;
		
		public backupManager _backupINIList;
		
		private bool _changesPending = false;
		
		public bool changesPending
		{
			get
			{
				return _changesPending || ValuesCatalogue.changesMade || _currentUserOptionsINI.changesMade;
			}
			set
			{
				_changesPending = value;
			}
		}
		
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
		
		public void InitializeHead()
		{
			
			//openConsole();
			string settingsFolder = "";
			Microsoft.Win32.RegistryKey regAccess;
			
			/* Load settings if available, else create em*/
			while(currentConfiguration.isInitialized != true)
			{
				/* Get folder path from registry if available*/
				regAccess = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\PlanetSide 2 Configuration Editor");
				
				if(regAccess != null)
					settingsFolder = regAccess.GetValue("Settings Folder Path") as string;
				
				/* if registry contained had a path, valid or not, attempt to load the settings file*/
				if (settingsFolder != "")
				{
					if(fileOps.folderExists(settingsFolder) && fileOps.fileExists(settingsFolder + "settings.xml"))
					{
						string settingsXML = fileOps.readFile(settingsFolder + "settings.xml");
						settingsBank settings = XMLSerialize.ReadXMLSettingsBank(settingsXML);
						currentConfiguration = settings;
					}
					else
					{
						MessageBoxResult msgBxRst = MessageBox.Show("The settings files for this utility apear to be missing, please indicate if you would like to place a new settings file in the following folder.", "Settings file not found", MessageBoxButton.YesNo);
						if(msgBxRst == MessageBoxResult.Yes)
						{
							currentConfiguration.settingsFolder = settingsFolder;
						}
					}
				}
				
				/*  Request user input to setup a proper folder location */
				if(currentConfiguration.settingsFolder == null)
				{
					Setup setupWindows = new Setup();
					setupWindows.ShowDialog();
					if(currentConfiguration.settingsFolder == null)
						CloseApplication();
					else
					{
						regAccess = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\PlanetSide 2 Configuration Editor");
						regAccess.SetValue("Settings Folder Path", currentConfiguration.settingsFolder);
						regAccess.Close();
					}
				}
				
				if(currentConfiguration.settingsFolder != null && fileOps.folderExists(currentConfiguration.settingsFolder) && currentConfiguration.isInitialized != true)
				{
					currentConfiguration.initializeSettings();
					saveSettings();
				}
				
			}
			
			loadValueCatalogue();
			populateFoundInstallations();
			
			_backupINIList = new backupManager();
			_backupINIList.populateBackups();
			
			/*Switch to last loaded install if available*/
			if(currentConfiguration._lastActiveInstall != null && discoveredGameInstallations.Contains(currentConfiguration._lastActiveInstall))
			{
				selectedGameInstallation = discoveredGameInstallations.IndexOf(currentConfiguration._lastActiveInstall);
			}
		}
		
		public bool saveFiles()
		{
			bool returnBool = saveCurrentINI();
			returnBool = saveSettings() && returnBool;
			return returnBool;
		}
		
		public void openConsole()
		{
			AllocConsole();
			IntPtr stdHandle=GetStdHandle(STD_OUTPUT_HANDLE);
			SafeFileHandle safeFileHandle = new SafeFileHandle(stdHandle, true);
			FileStream fileStream = new FileStream(safeFileHandle, FileAccess.Write);
			Encoding encoding = System.Text.Encoding.GetEncoding(MY_CODE_PAGE);
			StreamWriter standardOutput = new StreamWriter(fileStream, encoding);
			standardOutput.AutoFlush = true;
			Console.SetOut(standardOutput);
		}
		
		public bool saveCurrentINI()
		{
			if(_currentUserOptionsINI.changesMade)
			{
				MessageBoxResult result = MessageBox.Show("Do you want to overwrite your UserOptions.INI?", "Changes Pending", MessageBoxButton.YesNo, MessageBoxImage.Warning);
				if(result == MessageBoxResult.Yes)
				{
					if(!backupCurrentINI())
						annoy("Error backing up INI file.");
					
					bool returnVal = fileOps.writeFile(_currentUserOptionsINI.location, _currentUserOptionsINI.toWritableString());
					if (returnVal)
						_currentUserOptionsINI.changesMade = false;
					return returnVal;
				}
				else
					return false;
			}
			else
			{
				return true;
			}
		}
		
		public bool saveINI(INIinterfacer toSave)
		{
			if(toSave.location != null)
			{
				return fileOps.writeFile(toSave.location, toSave.toWritableString());
			}
			else
				return false;
		}
		
		/* this needs to be fixed, currently ssumes all files in folder are backed up files with valid names, also somewhat inefficient on the file processing*/
		public bool backupCurrentINI() 
		{
			if(currentConfiguration._backupsToKeep > 0)
			{
				var uri = new Uri(_currentUserOptionsINI.location);
				
				if (uri.IsFile)
				{
					DirectoryInfo di = new DirectoryInfo(uri.LocalPath);
					var driveName = di.Root.Name[0].ToString();
					List<string> invertedSubFolders = new List<string>();
					int sanityCheck1 = 0;
					int sanityCheck2 = 0;
					int maxSanityCheck = 2000;
					
					while(di.Parent != null)
					{
						invertedSubFolders.Add(di.Parent.Name);
						di = di.Parent;
					}
					
					string currentPath = currentConfiguration._backupFolderLocation.text + driveName + "\\";
					
					for (int i = invertedSubFolders.Count - 2; i >= 0; i--)
					{
						currentPath +=  invertedSubFolders[i] + "\\";
					}
					
					//annoy(currentPath);
					
					fileOps.createFolder(currentPath);
					
					INIinterfacer tempINI = new INIinterfacer();
					tempINI.location = currentPath + "UserOptions~" + DateTime.Now.ToString(currentConfiguration._timeDateFormat) + ".ini";
					tempINI.SafelyLoadINIFromString(_currentUserOptionsINI.toWritableString());
					
					bool returnBool = saveINI(tempINI);
					
					di = new DirectoryInfo(currentPath);
					
					FileInfo[] fileInfos = di.GetFiles();
					
					while(fileInfos.Length > currentConfiguration._backupsToKeep)
					{
						DateTime oldestFileDate = new DateTime();
						oldestFileDate= DateTime.Now;
						
						DateTime tempFileDate = new DateTime();
						
						string oldestFileName = "";
						string currentFileName = "";
						string [] removeStrings = {"UserOptions~", ".ini"};
						
						for (int i = 0; i < fileInfos.Length; i++)
						{
							currentFileName = fileInfos[i].Name;
							
							foreach(string removeString in removeStrings)
							{
								currentFileName = currentFileName.Replace(removeString, string.Empty);
							}
							
							tempFileDate = DateTime.ParseExact(currentFileName, currentConfiguration._timeDateFormat, CultureInfo.InvariantCulture);
							
							if(DateTime.Compare(tempFileDate, oldestFileDate) < 0)
							{
								oldestFileDate = DateTime.FromBinary(tempFileDate.ToBinary());
								oldestFileName = fileInfos[i].Name;
							}
							sanityCheck2++;
							if(sanityCheck2 > maxSanityCheck)
								throw new Exception("Violated sanity check while determining old backup files to cull.");
						}
						sanityCheck2 = 0;
						
						//PS2ConfigurationHead.annoy(currentPath + oldestFileName);
						
						fileOps.deleteFile(currentPath + oldestFileName);
						fileInfos = di.GetFiles();
						sanityCheck1++;
						
						if(sanityCheck1 > maxSanityCheck)
							throw new Exception("Violated sanity check while culling old backup files.");
					}
					
					return returnBool;
				}
				else
					return false;
			}
			else
				return true;
		}
		
		public bool saveSettings()
		{
			string filePath = currentConfiguration.settingsFolder + "settings.xml";
			
			
			return fileOps.writeFile(filePath, XMLSerialize.SerializeToString(currentConfiguration)); // just do it lol
			
			/*
			 bool settingsFileExists = fileOps.fileExists(filePath);
			 MessageBoxResult result = MessageBoxResult.None;
			
			if(settingsFileExists)
				result = MessageBox.Show("Do you want to overwrite your settings files?", "Changes Pending", MessageBoxButton.YesNo, MessageBoxImage.Warning);
			
			if(!settingsFileExists || result == MessageBoxResult.Yes)
				return fileOps.writeFile(currentConfiguration.settingsFolder + "settings.xml", XMLSerialize.SerializeToString(currentConfiguration));
			else
				return false;*/
		}
		
		public bool loadValueCatalogue()
		{
			string catLocation = currentConfiguration.settingsFolder + currentConfiguration._valueCatalogueName;
			
			if(fileOps.fileExists(catLocation))
			{
				ValuesCatalogue = XMLSerialize.ReadXMLValueCatalogue(fileOps.readFile(catLocation));
				ValuesCatalogue.changesMade = false;
				return true;
			}
			else
				return false;
		}
		
		public bool saveValueCatalogue()
		{
			MessageBoxResult result = MessageBox.Show("Do you want to overwrite your value catalogue file?", "Changes Pending", MessageBoxButton.YesNo, MessageBoxImage.Warning);
			if(result == MessageBoxResult.Yes)
				return fileOps.writeFile(currentConfiguration._valueCatalogueLocation + currentConfiguration._valueCatalogueName, XMLSerialize.SerializeToString(ValuesCatalogue));
			else
				return false;
		}
		
		public bool SwitchToInstallation(int installIndex)
		{
			if(installIndex == -1)
				return false;
			
			if (_currentUserOptionsINI.changesMade)
			{
				MessageBoxResult result = MessageBox.Show("Do you want to save changes before continuing?", "Changes Pending", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
				if (result == MessageBoxResult.Yes)
				{
					// save ini and other files
					saveFiles();
				}
				else if (result == MessageBoxResult.Cancel)
				{
					return false;
				}
				
			}
			
			//MessageBox.Show(_discoveredGameInstallations[installIndex], "boop");
			_currentUserOptionsINI.location = discoveredGameInstallations[installIndex] + "UserOptions.ini";
			
			currentConfiguration._lastActiveInstall = discoveredGameInstallations[installIndex];
			
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
		
		/*Returns true if closing app*/
		public bool CloseApplication()
		{
			if(changesPending)
			{
				MessageBoxResult result = MessageBox.Show("Do you want to exit without saving?", "Changes Pending", MessageBoxButton.YesNo, MessageBoxImage.Question);
				if (result == MessageBoxResult.Yes)
				{
					saveSettings();
					Application.Current.Shutdown();
					return true;
				}
				else
					return false;
			}
			else
			{
				saveSettings();
				Application.Current.Shutdown();
				return true;
			}
		}
		
		public void populateFoundInstallations()
		{
			List<String> logicalDriveLetters = new List<string>(System.IO.Directory.GetLogicalDrives());
			
			String checkingDirectory = "";
			
			Console.WriteLine("Found " + logicalDriveLetters.Count.ToString() + " drives to check.");
			
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
		
		public static void annoy(string presentThisToUser)
		{
			System.Windows.MessageBox.Show(presentThisToUser);
		}
	}
}
