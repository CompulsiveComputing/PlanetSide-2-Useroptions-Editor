/*
 * Created by SharpDevelop.
 * User: Gamer
 * Date: 23/03/2013
 * Time: 12:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace PlanetSide_2_Useroptions_Editor
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	/// 
	
	public partial class MainForm : Form
	{
		private string _applicationName = "PlanetSide 2 Useroptions Editor";
		private string _applicationShortName = "PS2 INI Editer";
		private string _versionString = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
		
		
		
		
		//private int _defaultIncrimentalBackupsToKeep = 10;
		private List<Section> _sectionList = new List<Section>();
		//private string _userOptionsLocation = "";
		//private string _backupFolderLocation = "";
		//private string _valueCatalogueLocation = "";
		//private int _incrimentalBackupsToKeep;
		
		//private string _activeFileName = "";
		
		private static string _currentWorkDirectory = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
		private static string _currentRootDirectory = Directory.GetDirectoryRoot(_currentWorkDirectory).ToString();
		private string _valueCatalogueName = "ps2useroptionscatalogue.xml";
		
		private UserOptionsINI _currentUserOptionsINI;
		
		private List<UserOptionsINI> _backupINIlist = new List<UserOptionsINI>();
		
		private string _activeSection = "",_activeValue = "";
		int _activeSectionNumber = -1, _activeValueNumber = -1;
		
		
		//private UserOptionsINI
		
		
		void CloseAndSave()
		{
			SaveINI();
			Close();
		}
		
		
		private string[] _defaultGamePaths =
		{
			"Program Files (x86)\\Steam\\steamapps\\common\\PlanetSide 2\\",
			"Program Files\\Steam\\steamapps\\common\\PlanetSide 2\\",
			"Program Files (x86)\\PlanetSide 2\\" +
				"Users\\Public\\Sony Online Entertainment\\Installed Games\\PlanetSide 2\\"
		};
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			InitializePlanetside2Editor();
			
		}
		
		void InitializePlanetside2Editor()
		{
			this.Text = _applicationName + " " + _versionString;
			
			this.VersionStringLabel1.Text = _versionString;
			
			_currentUserOptionsINI = new UserOptionsINI();
			
			
			/// <summary>
			/// Initialize UserOptions.INI location information
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			if (UseroptionsLocationTextbox.Text == "")
			{
				for(int i=0;i<_defaultGamePaths.Length;i++)
				{
					if (File.Exists(_currentRootDirectory+_defaultGamePaths[i]+"UserOptions.ini"))
					{
						UseroptionsLocationTextbox.Text = _currentRootDirectory+_defaultGamePaths[i]+"UserOptions.ini";
						break;
					}
				}
			}
			
			/// <summary>
			/// Initialize Backup location information
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			if (BackupLocationTextbox.Text == "")
			{
				if (Directory.Exists(_currentWorkDirectory+"Backups\\"))
					BackupLocationTextbox.Text = _currentWorkDirectory+"Backups\\";
			}
			
			/// <summary>
			/// Initialize Value Catalogue Location Information
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			///
			if (ValueCatalogueLcationTextbox.Text == "")
			{
				if (File.Exists(_currentWorkDirectory+"PS2ValueCatalogue.INI"))
					ValueCatalogueLcationTextbox.Text = _currentWorkDirectory+"PS2ValueCatalogue.INI";
			}
			
			/// <summary>
			/// LoadINI if current location information is correct
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			if (UseroptionsLocationTextbox.Text != "")
			{
				_currentUserOptionsINI._location= UseroptionsLocationTextbox.Text;
				LoadINI();
				PopulateValueTree();
				RawINITextBox.Text = _currentUserOptionsINI.toString();
			}
			SomethingUpdated();
		}
		
		void CloseButtonClick(object sender, System.EventArgs e)
		{
			CloseAndSave();
		}
		
		void CancelEditsButtonClick(object sender, System.EventArgs e)
		{
			
		}
		
		void SaveINIButtonClick(object sender, System.EventArgs e)
		{
			SaveINI();
		}
		
		void ValueCatalogueBrowseButtonClick(object sender, System.EventArgs e)
		{
			OpenFileDialog openfileDialog = new OpenFileDialog();
			openfileDialog.Filter = "XML|*.XML";
			openfileDialog.CheckFileExists = true;
			openfileDialog.Multiselect = false;
			DialogResult openfiledialogResult = openfileDialog.ShowDialog();
			
			if(openfileDialog.FileName.Length >= 8)
			{
				ValueCatalogueLcationTextbox.Text = openfileDialog.FileName;
				//this.Text = _applicationShortName + " | " + UseroptionsLocationTextbox.Text;
			}
			
			//_valueCatalogueLocation = openfileDialog.FileName;
		}
		
		void BackupLocationBrowseButtonClick(object sender, System.EventArgs e)
		{
			FolderBrowserDialog filebrowserdialog = new FolderBrowserDialog();
			DialogResult result = filebrowserdialog.ShowDialog();
			//_backupFolderLocation = filebrowserdialog.SelectedPath;
			
			if(filebrowserdialog.SelectedPath.Length >= 3)
			{
				BackupLocationTextbox.Text = filebrowserdialog.SelectedPath;
				//this.Text = _applicationShortName + " | " + UseroptionsLocationTextbox.Text;
			}
		}
		
		void UserOptionsINIBrowseButtonClick(object sender, System.EventArgs e)
		{
			
			//this.Text = _applicationShortName + " | " + _currentWorkDirectory;
			//MessageBox.Show( _userOptionsLocation );
			//this.Text -= _currentWorkDirectory;
			OpenFileDialog openfileDialog = new OpenFileDialog();
			openfileDialog.Filter = "UserOptions|UserOptions.ini";
			openfileDialog.CheckFileExists = true;
			openfileDialog.Multiselect = false;
			DialogResult openfiledialogResult = openfileDialog.ShowDialog();
			
			if(openfileDialog.FileName.Length >= 8)
			{
				//_currentUserOptionsINI = new UserOptionsINI();
				UseroptionsLocationTextbox.Text = openfileDialog.FileName;
				//LoadINI();
				InitializePlanetside2Editor();
				
			}
			
			
			

		}
		
		void LoadINI()
		{
			_currentUserOptionsINI.loadINI();
			this.Text = _applicationShortName + " | " + UseroptionsLocationTextbox.Text;
		}
		
		void PopulateRaw()
		{
			
		}
		
		void PopulateValueTree()
		{
			this.ValueEditorTree.Nodes.Clear();
			System.Windows.Forms.TreeNode[] _newSectionsTreeNodeArray = new System.Windows.Forms.TreeNode[_currentUserOptionsINI._sectionList.Count];
			System.Windows.Forms.TreeNode[] _newValuesTreeNodeArray;
			
			
			
			for (var _currentSection=0;_currentSection<_currentUserOptionsINI._sectionList.Count;_currentSection++)
			{
				//_newSectionsTreeNodeArray[_currentSection] = new TreeNode();
				_newValuesTreeNodeArray = new System.Windows.Forms.TreeNode[_currentUserOptionsINI._sectionList[_currentSection]._valueList.Count] ;
				
				for (var _currentValue=0;_currentValue<_currentUserOptionsINI._sectionList[_currentSection]._valueList.Count;_currentValue++)
				{
					
					_newValuesTreeNodeArray[_currentValue] = new TreeNode();
					_newValuesTreeNodeArray[_currentValue].Name = "Value"+_currentUserOptionsINI._sectionList[_currentSection]._valueList[_currentValue]._name.ToString();
					_newValuesTreeNodeArray[_currentValue].Text = _currentUserOptionsINI._sectionList[_currentSection]._valueList[_currentValue]._name + "=" + _currentUserOptionsINI._sectionList[_currentSection]._valueList[_currentValue]._value;
				}
				
				_newSectionsTreeNodeArray[_currentSection] = new System.Windows.Forms.TreeNode(_currentUserOptionsINI._sectionList[_currentSection]._name.ToString(), _newValuesTreeNodeArray);
				_newSectionsTreeNodeArray[_currentSection].Name = "Section"+_currentSection.ToString();
				_newSectionsTreeNodeArray[_currentSection].Text = _currentUserOptionsINI._sectionList[_currentSection]._name;
				
				//_newSectionsTreeNodeArray[_currentSection].AddRange(_newValuesTreeNodeArray);
				
			}
			this.ValueEditorTree.Nodes.AddRange( _newSectionsTreeNodeArray);
		}
		
		void UpdateValueTree()
		{
			PopulateValueTree();
			
			//int _checkValueNum,_checkSectionNum;
			
			//_checkSectionNum = _currentUserOptionsINI.FindSection(_activeSection);
			//_checkValueNum = _currentUserOptionsINI.FindValue(_activeSection,_activeValue);
			
			if (_currentUserOptionsINI.FindSection(_activeSection) == -1)
			{
				
			}
			
			
			
			
			
			
			
			
			
			if (_activeSectionNumber != -1)
			{
				if (_activeValueNumber==-1)
					this.ValueEditorTree.SelectedNode= this.ValueEditorTree.Nodes[_activeSectionNumber];
				else
					this.ValueEditorTree.SelectedNode= this.ValueEditorTree.Nodes[_activeSectionNumber].Nodes[_activeValueNumber];
			}
		}
		
		void DepopulateValueTree()
		{
			
		}
		
		
		
		
		void Label1Click(object sender, EventArgs e)
		{
			
		}
		
		void PictureBox1Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("http://www.jaegersunited.com");
		}
		
		void Label18Click(object sender, EventArgs e)
		{
			
		}
		
		void ValueEditorTreeAfterSelect(object sender, TreeViewEventArgs e)
		{
			if (e.Node.Parent!=null)
			{
				SetActiveValue(e.Node.Parent.Index,e.Node.Index);
			}
			else
			{
				SetActiveSection(e.Node.Index);
			}
			
		}
		
		void SetActiveValue(int _sectionIndex,int _valueIndex)
		{
			_activeSection = _currentUserOptionsINI._sectionList[_sectionIndex]._name;
			_activeSectionNumber = _sectionIndex;
			
			_activeValue = _currentUserOptionsINI._sectionList[_sectionIndex]._valueList[_valueIndex]._name;
			_activeValueNumber = _valueIndex;
			
			
			ValEditNameTextbox.Text = _currentUserOptionsINI._sectionList[_sectionIndex]._valueList[_valueIndex]._name.ToString();
			ValEditValueTextbox.Enabled = true;
			ValEditValueTextbox.Text = _currentUserOptionsINI._sectionList[_sectionIndex]._valueList[_valueIndex]._value.ToString();
			ValueEnabledCheckbox.Checked = _currentUserOptionsINI._sectionList[_sectionIndex]._valueList[_valueIndex]._isEnabled;
		}
		
		void SetActiveSection(int _sectionIndex)
		{
			_activeValue = "";
			_activeValueNumber = -1;
			_activeSection = _currentUserOptionsINI._sectionList[_sectionIndex]._name;
			_activeSectionNumber = _sectionIndex;
			
			ValEditNameTextbox.Text = _activeSection;
			ValEditValueTextbox.Text = "";
			ValEditValueTextbox.Enabled = false;
			ValueEnabledCheckbox.Checked = _currentUserOptionsINI._sectionList[_sectionIndex]._isEnabled;
		}
		
		void ValEditNameTextboxTextChanged(object sender, EventArgs e)
		{
			//int _activeValueNumber = _currentUserOptionsINI.FindValue(_activeSection,_activeValue);
			//int _activeSectionNumber = _currentUserOptionsINI.FindSection(_activeSection);
			
			if (_activeValueNumber != -1)
			{
				//SetActiveValue();
				_currentUserOptionsINI._sectionList[_activeSectionNumber]._valueList[_activeValueNumber]._name = ValEditNameTextbox.Text;
				_activeValue = ValEditNameTextbox.Text;
			}
			else if (_activeSectionNumber != -1)
			{
				//SetActiveSection();
				_currentUserOptionsINI._sectionList[_activeSectionNumber]._name = ValEditNameTextbox.Text;
				
				_activeSection = ValEditNameTextbox.Text;
			}
			
			SomethingUpdated();
			
		}
		
		void ValEditValueTextboxTextChanged(object sender, EventArgs e)
		{
			if (_activeValue != "")
			{
				_currentUserOptionsINI._sectionList[_currentUserOptionsINI.FindSection(_activeSection)]._valueList[_currentUserOptionsINI.FindValue(_activeSection,_activeValue)]._value = ValEditValueTextbox.Text;
			}
			SomethingUpdated();
		}
		
		void SaveINI()
		{
			if (File.Exists(_currentUserOptionsINI._location))
			{
				
				File.SetAttributes(_currentUserOptionsINI._location,File.GetAttributes(_currentUserOptionsINI._location) & ~FileAttributes.ReadOnly);
				System.IO.File.Delete(_currentUserOptionsINI._location);
				using (System.IO.StreamWriter file = new System.IO.StreamWriter(@_currentUserOptionsINI._location, true))
				{
					//System.IO.File.Delete(_currentUserOptionsINI._location);
					file.WriteLine(_currentUserOptionsINI.toString());
				}
				
				if (ReadOnlyCheckbox.Checked == true)
				{
					File.SetAttributes(_currentUserOptionsINI._location, FileAttributes.ReadOnly);
				}
			}
			
		}
		
		void SetUltraGpuSettingsButtonClick(object sender, EventArgs e)
		{
			bool i;
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","OverallQuality","-1");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","TextureQuality","0");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","LightingQuality","5");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","EffectsQuality","4");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","TerrainQuality","4");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","FloraQuality","4");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","ModelQuality","4");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","AO","1");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","MotionBlur","1");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","TerrainLOD","4");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","MotionBlurQuality","4");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","BlurQuality","4");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","AOQuality","4");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","FogShadowsEnable","1");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","ParticleQuality","4");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","AmbientOcclusionQuality","4");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","ParticleQuality","4");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","FloralLOD","5");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","EffectsLOD","5");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","GraphicsQuality","5");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","RenderDistance","9999");
			
			SomethingUpdated();
			
		}
		
		void RenderQualityTrackbarScroll(object sender, EventArgs e)
		{
			RenderQualityTextBox.Text = ((double)RenderQualityTrackbar.Value / 10).ToString() ;
		}
		
		void RawINITextBoxTextChanged(object sender, EventArgs e)
		{
			if (_currentUserOptionsINI._location.Length>3)
			{
				bool _successfullyLoadedINI = _currentUserOptionsINI.SafelyLoadINI(RawINITextBox.Text);
				if (!_successfullyLoadedINI)
				{
					MessageBox.Show("The cookie has crumbled! Flooding the antechamber with nanites.");
					RawINITextBox.Text = _currentUserOptionsINI.toString();
				}
				//_currentUserOptionsINI.;
				SomethingUpdated();
			}
		}
		
		void SomethingUpdated()
		{
			
			if (!RawINITextBox.Focused) // update RawINITextbox
				RawINITextBox.Text = _currentUserOptionsINI.toString();
			if (_currentUserOptionsINI._location.Length>3) // update performance cheats tab forms
			{
				string _renderQuality = _currentUserOptionsINI.GetValue("RenderQuality","Display");
				
				if (!FSAATextBox.Focused && _renderQuality != "" && _renderQuality != ".")
					FSAATextBox.Text = Math.Pow(((float)System.Convert.ToSingle(_renderQuality)),2).ToString();
				
				if (!RenderQualityTextBox.Focused)
					RenderQualityTextBox.Text = _currentUserOptionsINI.GetValue("RenderQuality","Display");
				
				if (!RenderQualityTrackbar.Focused && _renderQuality != "" && _renderQuality != ".")
					if(0.3 <= System.Convert.ToSingle(_renderQuality) && System.Convert.ToSingle(_renderQuality) <= 2)
						RenderQualityTrackbar.Value = (int)Math.Round(System.Convert.ToSingle(_renderQuality) * 10,0);
			}
			
			
			if(_currentUserOptionsINI.FindValue(_activeSection,_activeValue) == -1) // check if our section was deleted or has changed number
			{
				_activeSection = "";
				_activeValue = "";
			}
			else
				if (_currentUserOptionsINI.FindSection(_activeSection) == -1)
					_activeValue = "";
			
			UpdateValueTree();
		}
		
		void RenderQualityTextBoxTextChanged(object sender, EventArgs e)
		{
			try{
				if (_currentUserOptionsINI._location.Length>3)
				{
					
					_currentUserOptionsINI.FindAndChangeValue("Display","RenderQuality",RenderQualityTextBox.Text.ToString());
					SomethingUpdated();
				}
			}
			catch
			{
				
			}
		}
		
		void FSAATextBoxTextChanged(object sender, EventArgs e)
		{
			try
			{
				if (_currentUserOptionsINI._location.Length>3)
				{
					
					_currentUserOptionsINI.FindAndChangeValue("Display","RenderQuality",Math.Round(Math.Sqrt(System.Convert.ToSingle(FSAATextBox.Text)),6).ToString());
					SomethingUpdated();
				}
			}
			catch
			{
				
			}
		}
		
		void SetLowCPUGraphicsSettingsButtonClick(object sender, EventArgs e)
		{
			_currentUserOptionsINI.FindAndChangeValue("Rendering","ShadowQuality","0");
			SomethingUpdated();
		}
		
		void SetCPUGraphicsSettingButtonClick(object sender, EventArgs e)
		{
			_currentUserOptionsINI.FindAndChangeValue("Rendering","ShadowQuality","4");
			SomethingUpdated();
		}
		
		void SetLowCPUSoundButtonClick(object sender, EventArgs e)
		{
			_currentUserOptionsINI.FindAndChangeValue("Sound","MaxVoices","80");
			SomethingUpdated();
		}
		
		void SetHighCPUSoundButtonClick(object sender, EventArgs e)
		{
			_currentUserOptionsINI.FindAndChangeValue("Sound","MaxVoices","196");
			SomethingUpdated();
		}
		
		void ValueEnabledCheckboxCheckedChanged(object sender, EventArgs e)
		{
			if(_activeSection != "" && _activeValue != "")
				_currentUserOptionsINI._sectionList[_currentUserOptionsINI.FindSection(_activeSection)]._valueList[_currentUserOptionsINI.FindValue(_activeSection,_activeValue)]._isEnabled = ValueEnabledCheckbox.Checked;
			else if (_activeSection != "")
				_currentUserOptionsINI._sectionList[_currentUserOptionsINI.FindSection(_activeSection)]._isEnabled = ValueEnabledCheckbox.Checked;
			SomethingUpdated();
		}
		
		void SetTDRecommendedHighButtonClick(object sender, EventArgs e)
		{
			bool i;
			i = _currentUserOptionsINI.FindAndChangeValue("Display","RenderQuality","1");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","OverallQuality","-1");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","TextureQuality","0");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","LightingQuality","2");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","EffectsQuality","3");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","TerrainQuality","3");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","FloraQuality","3");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","ModelQuality","3");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","AO","1");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","MotionBlur","1");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","FogShadowsEnable","1");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","GraphicsQuality","3");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","RenderDistance","9999");
			
			SomethingUpdated();
		}
		
		void ReloadINIButtonClick(object sender, EventArgs e)
		{
			InitializePlanetside2Editor();
		}
		
		void DeleteINIButtonClick(object sender, EventArgs e)
		{
			DialogResult _areWeSure = MessageBox.Show("Are you sure you want to delete your UserOptions.INI?",
			                                  "Delete UserOptions.INI", MessageBoxButtons.YesNo);
			switch(_areWeSure){
					case DialogResult.Yes: 
					{
						File.Delete(_currentUserOptionsINI._location);
						MessageBox.Show("You will now need to restart PlanetSide 2 to make a new UserOptions.INI.","Information");
						_currentUserOptionsINI = new UserOptionsINI();
						InitializePlanetside2Editor();
						break;
						
					};
					
					case DialogResult.No: break;
			}
		}
		
		void PlaceHolder()
		{
			MessageBox.Show("This doesn't do anythign quite yet.", "Work in Progress");
		}
		
		void BackupINIButtonClick(object sender, EventArgs e)
		{
			PlaceHolder();
		}
		
		void SetTDRecommendedUltraButtonClick(object sender, EventArgs e)
		{
						bool i;
			i = _currentUserOptionsINI.FindAndChangeValue("Display","RenderQuality","1.414214");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","OverallQuality","-1");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","TextureQuality","0");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","LightingQuality","3");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","EffectsQuality","4");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","TerrainQuality","4");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","FloraQuality","4");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","ModelQuality","4");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","AO","1");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","MotionBlur","1");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","TerrainLOD","4");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","MotionBlurQuality","4");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","FogShadowsEnable","1");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","ParticleQuality","4");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","FloralLOD","5");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","EffectsLOD","5");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","GraphicsQuality","4");
			i = _currentUserOptionsINI.FindAndChangeValue("Rendering","RenderDistance","9999");
			
			SomethingUpdated();
		}
	}


	public class Value
	{
		//public ValueType valuetype = ;
		public string _name = null;
		public string _value=null;
		//public float _upperBounds = 0;
		//public float _lowerBounds = 0;
		
		public bool _isEnabled=false;
		
		public void SetValue(string _newName, string _newValue)
		{
			_name = _newName;
			_value = _newValue;
			_isEnabled = true;

		}
		
		public string toString()
		{
			return _name + "=" + _value;
		}
		
		public bool fromString(string _inputString)
		{
			//MessageBox.Show(_inputString);
			
			string[] _inputStringSplitArray = _inputString.Split('=');
			_name = _inputStringSplitArray[0];
			
			_value = _inputStringSplitArray[1];
			_isEnabled = true;
			return false;
		}
	}

	public class Section
	{
		public string _name="unitialized";
		public List<Value> _valueList = new List<Value>();
		public bool _isEnabled = true;
		
		bool isThisASectionHeaden(string _subjectInQuestion)
		{
			return (_subjectInQuestion.IndexOf("[")!=-1 && _subjectInQuestion.IndexOf("]")!=-1);
		}
		
		public string toString()
		{
			string _tempstring = "["+_name+"]" + Environment.NewLine;
			for(var i=0;i<_valueList.Count;i++)
			{
				if(_valueList[i].toString().Length>3 && _valueList[i]._isEnabled==true)
					_tempstring += _valueList[i].toString() + Environment.NewLine;
			}
			return _tempstring;
		}
		
		public bool fromStringArray(string[] _stringArray)
		{
			int _arrayPosition=0;
			
			if(isThisASectionHeaden(_stringArray[_arrayPosition]))
			{
				_name = _stringArray[_arrayPosition].Trim(' ','[',']');
				//MessageBox.Show(_stringArray.Length.ToString());
				for (var _forlooper=1;_forlooper<_stringArray.Length;_forlooper++)
				{
					if (_stringArray[_forlooper].Length>3)
					{
						_valueList.Add(new Value());
						_valueList[_valueList.Count-1].fromString(_stringArray[_forlooper]);
						//MessageBox.Show((_valueList[_valueList.Count-1].toString()));
						
					}
					
				}
				//MessageBox.Show(_name);
				_isEnabled=true;
				return true;
			}
			else
				return false;
		}
		
	}

	public class UserOptionsINI
	{
		public string _location = "";
		//public string _rawText = "";
		public List<Section> _sectionList = new List<Section>();
		
		public string GetValue(string _nameOfValue, string _nameOfSection)
		{
			if (_nameOfValue != "" && _nameOfSection != "")
			{
				for (int _currentSection = 0;_currentSection<_sectionList.Count;_currentSection++)
				{
					if (_sectionList[_currentSection]._name == _nameOfSection)
					{
						for(int _currentValue=0;_currentValue<_sectionList[_currentSection]._valueList.Count;_currentValue++)
						{
							if(_sectionList[_currentSection]._valueList[_currentValue]._name == _nameOfValue)
							{
								return _sectionList[_currentSection]._valueList[_currentValue]._value;
							}
						}
					}
				}
			}
			return "";
		}
		
		public bool AddValue(string _nameOfSection, string _nameOfNewValue, string _ValueofNewValue)
		{
			if (_nameOfNewValue != "" && _nameOfSection != "")
			{
				for (int _currentSection = 0;_currentSection<_sectionList.Count;_currentSection++)
				{
					if (_sectionList[_currentSection]._name == _nameOfSection)
					{
						Value _newValue = new Value();
						_newValue.SetValue(_nameOfNewValue,_ValueofNewValue);
						_sectionList[_currentSection]._valueList.Add(_newValue);
						return true;
					}
				}
				if (AddSection(_nameOfSection))
					return AddValue(_nameOfSection,_nameOfNewValue,_ValueofNewValue);
				return false;
			}
			else
			{
				MessageBox.Show("The Cookies Sploded. Gummy bears en route. Please report!");
				return false;
			}
		}
		
		public bool AddSection(string _nameOfSection)
		{
			if (_nameOfSection != "" )
			{
				if (FindSection(_nameOfSection) == -1)
				{

					Section _newSection = new Section();
					_newSection._name = _nameOfSection;
					_sectionList.Add(_newSection);
					return true;

				}
				else
				{
					
					
					return true;
				}
			}
			else
				MessageBox.Show("The TR Successfully invaded the Crown!");
			return false;
		}
		
		public bool FindAndChangeValue( string _nameOfSection, string _nameOfValue, string _newValue)
		{
			if (_nameOfValue != "" && _nameOfSection != "")
			{
				for (int _currentSection = 0;_currentSection<_sectionList.Count;_currentSection++)
				{
					if (_sectionList[_currentSection]._name == _nameOfSection)
					{
						for(int _currentValue=0;_currentValue<_sectionList[_currentSection]._valueList.Count;_currentValue++)
						{
							if(_sectionList[_currentSection]._valueList[_currentValue]._name == _nameOfValue)
							{
								_sectionList[_currentSection]._valueList[_currentValue]._value = _newValue;
								return true;
							}
						}
					}
					
				}
				return AddValue(_nameOfSection,_nameOfValue,_newValue);
			}
			else
			{
				MessageBox.Show("The Cookies Sploded. Gummy bears en route. Please report!");
				return false;
			}
		}
		
		public string toString()
		{
			string _tempstring = "";
			
			for (var i=0;i<_sectionList.Count;i++)
			{
				if(_sectionList[i]._isEnabled == true)
					_tempstring += _sectionList[i].toString() + Environment.NewLine;
			}
			return _tempstring;
		}
		
		public bool SafelyLoadINI(string _stringToLoadFrom)
		{
			try
			{
				return LoadINIFromStringArray(_stringToLoadFrom.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None));

			}
			catch
			{
				return false;
			}
		}
		
		public bool loadINI()
		{
			if (File.Exists(_location))
			{
				string[] _lines = System.IO.File.ReadAllLines(@_location); // each line of the ini file in turn
				return LoadINIFromStringArray(_lines);
			}
			else
			{
				return false;
			}
		}
		
		private bool isThisASectionHeader(string _subjectInQuestion)
		{
			//System.Diagnostics.Debug.WriteLine(_subjectInQuestion);
			return (_subjectInQuestion.IndexOf("[")!=-1 && _subjectInQuestion.IndexOf("]")!=-1);
		}
		
		List<Section> AddDisabled(List<Section> _inputSectionList)
		{
			bool _missingSection, _missingValue;
			
			List<Section> _combinedSectionList = _inputSectionList;
			
			try
			{
				for(int _workingSection=0;_workingSection<_sectionList.Count;_workingSection++)
				{
					_missingSection = true;
					
					for(int _inputSection=0;_inputSection<_combinedSectionList.Count;_inputSection++)
					{
						if (_sectionList[_inputSection]._name == _sectionList[_workingSection]._name)
						{
							_missingSection = false;
						}
					}
					
					if (_missingSection)
						_combinedSectionList.Add(_sectionList[_workingSection]);
					
					for(int _workingValue=0;_workingValue<_sectionList.Count;_workingValue++)
					{
						_missingValue = true;
						
						for(int _inputSection=0;_inputSection<_combinedSectionList.Count;_inputSection++)
						{
							if (_sectionList[_workingSection]._name == _combinedSectionList[_inputSection]._name)
							{
								for(int _inputValue=0;_inputValue<_combinedSectionList[_inputSection]._valueList.Count;_inputValue++)
								{
									if (_sectionList[_workingSection]._valueList[_workingValue]._name == _combinedSectionList[_inputSection]._valueList[_inputValue]._name)
									{
										_missingValue = false;
									}
									
								}
								if (_missingValue)
								{
									_combinedSectionList[_inputSection]._valueList.Add(_sectionList[_workingSection]._valueList[_workingValue]);
									_combinedSectionList[_inputSection]._valueList[_combinedSectionList[_inputSection]._valueList.Count-1]._isEnabled = false;
								}
							}
						}
					}
					
					
				}
				//if (_combinedSectionList.Count<15)
				//	MessageBox.Show(_combinedSectionList.Count.ToString());
				return _combinedSectionList;
			}
			catch
			{
				return _inputSectionList;
			}
		}
		
		private bool LoadINIFromStringArray(string[] _stringArrayToLoadFrom)
		{
			
			
			UserOptionsINI _tempINI = new UserOptionsINI();
			
			string[] _sectionStringArray; //second level data set, a section chopped out of the ini file
			int _sectionStart=0; // to be set to the start of each section, used respectively
			int _sectionEnd=0; // to be set to the end of each section, used respectively
			
			int _foruses = 0;
			try
			{
				for(var _currentLine=0;_currentLine<_stringArrayToLoadFrom.Length;_currentLine++)  // loop running through each individual line, will skip to later lines with controls inside another loop
				{
					_foruses++;
					
					
					
					if (isThisASectionHeader(_stringArrayToLoadFrom[_currentLine]))
					{
						_sectionStart = _currentLine;// we've found a section! the temp is set to the current line
						
						
						
						for(var _startOfNextSectionPosition=_currentLine+1;_startOfNextSectionPosition<_stringArrayToLoadFrom.Length;_startOfNextSectionPosition++)// loop running through the next set of lines to find the start of the next section
						{
							_foruses++;
							//if (_currentLine>=116)
							//	System.Diagnostics.Debug.WriteLine(isThisASectionHeader(_lines[_startOfNextSectionPosition]).ToString());
							
							if (isThisASectionHeader(_stringArrayToLoadFrom[_startOfNextSectionPosition]) || _startOfNextSectionPosition == (_stringArrayToLoadFrom.Length-1))// we have found the start of the next section!
							{
								int _sectionLength;
								
								
								//if (_currentLine>=116) System.Diagnostics.Debug.WriteLine(isThisASectionHeader(_lines[_currentLine]).ToString());
								
								if (_stringArrayToLoadFrom[_startOfNextSectionPosition-1].Length>3)//is this large enough to actually be meaningful? a=1 makes 3 chars
								{
									_sectionEnd = _startOfNextSectionPosition - 1; // we have found the end of the current section!
									_sectionLength = _startOfNextSectionPosition-_currentLine;
								}
								else if (_startOfNextSectionPosition != (_stringArrayToLoadFrom.Length-1))
								{
									_sectionEnd = _startOfNextSectionPosition - 2; // we have found the end of the current section!
									_sectionLength = _startOfNextSectionPosition-_currentLine;
								}
								else
								{
									_sectionEnd = _startOfNextSectionPosition; // we have found the end of the current section!
									_sectionLength = _startOfNextSectionPosition-_currentLine;
								}
								
								
								_sectionStringArray = new string[_sectionLength];// initialize dat string array
								
								
								
								for (var _currentLineOfCurrentSection = 0;_currentLineOfCurrentSection<_sectionLength;_currentLineOfCurrentSection++)// loop running through each line of the section
								{
									_foruses++;
									_sectionStringArray[_currentLineOfCurrentSection] = _stringArrayToLoadFrom[_currentLine + _currentLineOfCurrentSection];// copy all lines in the found section to the string array
									
								}
								
								//if(_lines[_startOfNextSectionPosition]=="[Rendering]")
								//	System.Diagnostics.Debug.WriteLine(isThisASectionHeader(_lines[_startOfNextSectionPosition]));
								
								
								if (_tempINI.FindSection(_sectionStringArray[0]) == -1) // combine sections of same name
								{
									_tempINI._sectionList.Add(new Section());// we need a new section object to put the found section into
									_tempINI._sectionList[_tempINI._sectionList.Count-1].fromStringArray(_sectionStringArray);// throw our found section into our new section object
								}
								else
								{
									_tempINI._sectionList[_tempINI.FindSection(_sectionStringArray[0])].fromStringArray(_sectionStringArray);
								}
								
								
								_sectionStringArray = null;// uninitialize the string array, it's been used and now discarded
								break;// end current for loop
							}
							
							if (_startOfNextSectionPosition>=1000)
								MessageBox.Show("Sanity Check, _sectionEndPosition length exceeded 1000");
							if (_foruses>=1000)
								MessageBox.Show("Sanity Check, _forUses length exceeded 1000");
							
							//if (_sectionEndPosition >= 110)
							//System.Diagnostics.Debug.WriteLine(_lines[116]);
							//MessageBox.Show("Problem in cookies ville!" + isThisASectionHeader(_lines[_sectionEndPosition]).ToString());
							//Console.
						}
						_currentLine = _sectionEnd;// move our first loop interater to just before the next section
					}
					if (_currentLine>=10000)
						MessageBox.Show("Sanity Check, INI length exceeded 10000");
				}
				_tempINI._sectionList = AddDisabled(_tempINI._sectionList);
				_sectionList = _tempINI._sectionList;
				return true;
			}
			catch
			{
				
				return false;
			}
			
			
			
		}
		
		public int FindSection(string _inputSectionName)
		{
			if (_inputSectionName != "")
			{
				_inputSectionName = _inputSectionName.Trim(' ','[',']');
				
				for (int _currentSection = 0;_currentSection<_sectionList.Count;_currentSection++)
				{
					if (_sectionList[_currentSection]._name == _inputSectionName)
					{
						return _currentSection;
					}
					
				}
				return -1;
			}
			else
			{
				//MessageBox.Show("The Cookies Sploded. Gummy bears en route. Please report!");
				return -1;
			}
		}
		
		public int FindValue(string _inputSectionName,string _inputValueName)
		{
			int _inputSectionNumber = FindSection(_inputSectionName);
			int _foundValueNumber = -1;
			
			
			if (_inputSectionNumber!=-1  && _inputValueName!="")
			{
				for (int _currentValue = 0;_currentValue<_sectionList[_inputSectionNumber]._valueList.Count;_currentValue++)
				{
					if (_sectionList[_inputSectionNumber]._valueList[_currentValue]._name == _inputValueName) // we found our value!
					{
						_foundValueNumber = _currentValue;
					}
				}
			}
			
			return _foundValueNumber;
		}
		
	}

	public class UserOptionsCatalogue
	{
		public List<Section> _sectionList = new List<Section>();
		//_sectionList.Add =
	}

	public class ValueType
	{
		public string _valueType = "uninitialized";
		
		
	}

}
