/*
 * Created by SharpDevelop.
 * User: Devahlin
 * Date: 01/13/2015
 * Time: 20:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Collections.ObjectModel;

namespace PS2_INI_Editor
{
	/// <summary>
	/// Description of useroptionsini.
	/// </summary>
	public class INIinterfacer
	{
		private string _location = "";
		
		public string location {
			get { return _location; }
			set { _location = value; }
		}
		
		public string fileName
		{
			get
			{
				return (new FileInfo(_location).Name);
			}
		}
		//public string _rawText = "";
		
		public bool changesMade = false;
		
		private ObservableCollection<Section> _sectionList = new ObservableCollection<Section>();
		
		public ObservableCollection<Section> sectionList {
			get { return _sectionList; }
			set { _sectionList = value; changesMade = true;}
		}
		
		public INIinterfacer(string fileToLoadFrom)
		{
			location = fileToLoadFrom;
		}
		
		public INIinterfacer()
		{
			
		}
		
		public string GetValue(string nameOfValue, string _nameOfSection)
		{
			if (nameOfValue != "" && _nameOfSection != "")
			{
				for (int _currentSection = 0;_currentSection<sectionList.Count;_currentSection++)
				{
					if (sectionList[_currentSection].name == _nameOfSection)
					{
						for(int _currentValue=0;_currentValue<sectionList[_currentSection].valueList.Count;_currentValue++)
						{
							if(sectionList[_currentSection].valueList[_currentValue].name == nameOfValue)
							{
								return sectionList[_currentSection].valueList[_currentValue].value;
							}
						}
					}
				}
			}
			return "";
		}
		
		public bool AddValue(string nameOfSection, string _nameOfNewValue, string _ValueofNewValue)
		{
			if (_nameOfNewValue != "" && nameOfSection != "")
			{
				for (int _currentSection = 0;_currentSection<sectionList.Count;_currentSection++)
				{
					if (sectionList[_currentSection].name == nameOfSection)
					{
						Value _newValue = new Value();
						_newValue.SetValue(_nameOfNewValue,_ValueofNewValue);
						sectionList[_currentSection].valueList.Add(_newValue);
						return true;
					}
				}
				if (AddSection(nameOfSection))
					return AddValue(nameOfSection,_nameOfNewValue,_ValueofNewValue);
				return false;
			}
			else
			{
				System.Windows.MessageBox.Show("The Cookies Sploded. Gummy bears en route. Please report!");
				return false;
			}
		}
		
		public bool AddSection(string nameOfSection)
		{
			if (nameOfSection != "" )
			{
				if (FindSection(nameOfSection) == -1)
				{

					Section _newSection = new Section();
					_newSection.name = nameOfSection;
					sectionList.Add(_newSection);
					return true;

				}
				else
				{
					
					
					return true;
				}
			}
			else
				System.Windows.MessageBox.Show("The TR Successfully invaded the Crown!");
			return false;
		}
		
		public bool FindAndChangeValue( string _nameOfSection, string _nameOfValue, string _newValue)
		{
			if (_nameOfValue != "" && _nameOfSection != "")
			{
				for (int _currentSection = 0;_currentSection<sectionList.Count;_currentSection++)
				{
					if (sectionList[_currentSection].name == _nameOfSection)
					{
						for(int _currentValue=0;_currentValue<sectionList[_currentSection].valueList.Count;_currentValue++)
						{
							if(sectionList[_currentSection].valueList[_currentValue].name == _nameOfValue)
							{
								sectionList[_currentSection].valueList[_currentValue].value = _newValue;
								return true;
							}
						}
					}
					
				}
				return AddValue(_nameOfSection,_nameOfValue,_newValue);
			}
			else
			{
				System.Windows.MessageBox.Show("The Cookies Sploded. Gummy bears en route. Please report!");
				return false;
			}
		}
		
		public string toWritableString()
		{
			string _tempstring = "";
			
			for (var i=0;i<sectionList.Count;i++)
			{
				if(sectionList[i]._isEnabled == true)
					_tempstring += sectionList[i].toString() + Environment.NewLine;
			}
			return _tempstring;
		}
		
		public bool SafelyLoadINIFromString(string _stringToLoadFrom)
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
			if (File.Exists(location))
			{
				string[] _lines = System.IO.File.ReadAllLines(@location); // each line of the ini file in turn
				bool returnBool = LoadINIFromStringArray(_lines);
				if(returnBool)
				{
					changesMade = false;
					return true;
				}
				else
					return false;
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
		
		ObservableCollection<Section> AddDisabled(ObservableCollection<Section> _inputSectionList)
		{
			bool _missingSection, _missingValue;
			
			ObservableCollection<Section> _combinedSectionList = _inputSectionList;
			
			try
			{
				for(int _workingSection=0;_workingSection<sectionList.Count;_workingSection++)
				{
					_missingSection = true;
					
					for(int _inputSection=0;_inputSection<_combinedSectionList.Count;_inputSection++)
					{
						if (sectionList[_inputSection].name == sectionList[_workingSection].name)
						{
							_missingSection = false;
						}
					}
					
					if (_missingSection)
						_combinedSectionList.Add(sectionList[_workingSection]);
					
					for(int _workingValue=0;_workingValue<sectionList.Count;_workingValue++)
					{
						_missingValue = true;
						
						for(int _inputSection=0;_inputSection<_combinedSectionList.Count;_inputSection++)
						{
							if (sectionList[_workingSection].name == _combinedSectionList[_inputSection].name)
							{
								for(int _inputValue=0;_inputValue<_combinedSectionList[_inputSection].valueList.Count;_inputValue++)
								{
									if (sectionList[_workingSection].valueList[_workingValue].name == _combinedSectionList[_inputSection].valueList[_inputValue].name)
									{
										_missingValue = false;
									}
									
								}
								if (_missingValue)
								{
									_combinedSectionList[_inputSection].valueList.Add(sectionList[_workingSection].valueList[_workingValue]);
									_combinedSectionList[_inputSection].valueList[_combinedSectionList[_inputSection].valueList.Count-1].isEnabled = false;
								}
							}
						}
					}
					
					
				}
				//if (_combinedSectionList.Count<15)
				//	System.Windows.MessageBox.Show(_combinedSectionList.Count.ToString());
				return _combinedSectionList;
			}
			catch
			{
				return _inputSectionList;
			}
		}
		
		private bool LoadINIFromStringArray(string[] _stringArrayToLoadFrom)
		{
			
			
			INIinterfacer _tempINI = new INIinterfacer();
			
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
									_tempINI.sectionList.Add(new Section());// we need a new section object to put the found section into
									_tempINI.sectionList[_tempINI.sectionList.Count-1].fromStringArray(_sectionStringArray);// throw our found section into our new section object
								}
								else
								{
									_tempINI.sectionList[_tempINI.FindSection(_sectionStringArray[0])].fromStringArray(_sectionStringArray);
								}
								
								
								_sectionStringArray = null;// uninitialize the string array, it's been used and now discarded
								break;// end current for loop
							}
							
							if (_startOfNextSectionPosition>=1000)
								System.Windows.MessageBox.Show("Sanity Check, _sectionEndPosition length exceeded 1000");
							if (_foruses>=1000)
								System.Windows.MessageBox.Show("Sanity Check, _forUses length exceeded 1000");
							
							//if (_sectionEndPosition >= 110)
							//System.Diagnostics.Debug.WriteLine(_lines[116]);
							//System.Windows.MessageBox.Show("Problem in cookies ville!" + isThisASectionHeader(_lines[_sectionEndPosition]).ToString());
							//Console.
						}
						_currentLine = _sectionEnd;// move our first loop interater to just before the next section
					}
					if (_currentLine>=10000)
						System.Windows.MessageBox.Show("Sanity Check, INI length exceeded 10000");
				}
				_tempINI.sectionList = AddDisabled(_tempINI.sectionList);
				sectionList = _tempINI.sectionList;
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
				
				for (int _currentSection = 0;_currentSection<sectionList.Count;_currentSection++)
				{
					if (sectionList[_currentSection].name == _inputSectionName)
					{
						return _currentSection;
					}
					
				}
				return -1;
			}
			else
			{
				//System.Windows.MessageBox.Show("The Cookies Sploded. Gummy bears en route. Please report!");
				return -1;
			}
		}
		
		public int FindValue(string _inputSectionName,string _inputValueName)
		{
			int _inputSectionNumber = FindSection(_inputSectionName);
			int _foundValueNumber = -1;
			
			
			if (_inputSectionNumber!=-1  && _inputValueName!="")
			{
				for (int _currentValue = 0;_currentValue<sectionList[_inputSectionNumber].valueList.Count;_currentValue++)
				{
					if (sectionList[_inputSectionNumber].valueList[_currentValue].name == _inputValueName) // we found our value!
					{
						_foundValueNumber = _currentValue;
					}
				}
			}
			
			return _foundValueNumber;
		}
		
	}
	
	public class Section
	{
		private string _name="unitialized";
		public string name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}
		
		private ObservableCollection<Value> _valueList = new ObservableCollection<Value>();
		
		public ObservableCollection<Value> valueList
		{
			get
			{
				return _valueList;
			}
			set
			{
				if(_valueList != value)
				{
					_valueList = value;
				}
			}
		}
		
		public bool _isEnabled = true;
		
		bool isThisASectionHeader(string _subjectInQuestion)
		{
			return (_subjectInQuestion.IndexOf("[")!=-1 && _subjectInQuestion.IndexOf("]")!=-1);
		}
		
		public string toString()
		{
			string _tempstring = "["+_name+"]" + Environment.NewLine;
			for(var i=0;i<valueList.Count;i++)
			{
				if(valueList[i].toString().Length>3 && valueList[i].isEnabled==true)
					_tempstring += valueList[i].toString() + Environment.NewLine;
			}
			return _tempstring;
		}
		
		public bool fromStringArray(string[] _stringArray)
		{
			int _arrayPosition=0;
			if(isThisASectionHeader(_stringArray[_arrayPosition]))
			{
				_name = _stringArray[_arrayPosition].Trim(' ','[',']');
				//System.Windows.MessageBox.Show(_stringArray.Length.ToString());
				for (var _forlooper=1;_forlooper<_stringArray.Length;_forlooper++)
				{
					if (_stringArray[_forlooper].Length>3)
					{
						valueList.Add(new Value());
						valueList[valueList.Count-1].fromString(_stringArray[_forlooper]);
						//System.Windows.MessageBox.Show((_valueList[_valueList.Count-1].toString()));
					}
				}
				//System.Windows.MessageBox.Show(_name);
				_isEnabled=true;
				return true;
			}
			else
				return false;
		}
		
		public bool AddValue(string Name)
		{
			Value newValue = new Value();
			newValue.name = Name;
			valueList.Add(newValue);
			return true;
		}
	}
	
	public class Value
	{
		public string name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}
		
		
		//public ValueType valuetype = ;
		private string _name = null;
		public string value=null;
		//public float _upperBounds = 0;
		//public float _lowerBounds = 0;
		public bool isEnabled=false;
		
		public void SetValue(string _newName, string _newValue)
		{
			name = _newName;
			value = _newValue;
			isEnabled = true;
		}
		
		public string toString()
		{
			return name + "=" + value;
		}
		
		public bool fromString(string _inputString)
		{
			//System.Windows.MessageBox.Show(_inputString);
			string[] _inputStringSplitArray = _inputString.Split('=');
			name = _inputStringSplitArray[0];
			value = _inputStringSplitArray[1];
			isEnabled = true;
			return false;
		}
	}
}
