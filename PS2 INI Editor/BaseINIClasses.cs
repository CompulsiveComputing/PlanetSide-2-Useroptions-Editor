/*
 * Created by SharpDevelop.
 * User: Devahlin
 * Date: 02/04/2015
 * Time: 10:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PS2_INI_Editor
{
	/// <summary>
	/// Description of BaseINIClasses.
	/// </summary>
	public abstract class BaseINI :  customObservable1
	{
		private bool _changesMade = false; // someday this will be true... someday
		
		public override bool changesMade
		{
			get
			{
				if(!_changesMade)
				{
					for(int i = 0; i < sectionList.Count;i++)
					{
						if(sectionList[i].changesMade)
						{
							_changesMade = true;
							break;
						}
					}
				}
				//System.Windows.MessageBox.Show("vc get " + _changesMade.ToString());
				return _changesMade;
			}
			set
			{
				_changesMade = value;
				
				if(!value)
				{
					for(int i = 0; i < sectionList.Count;i++)
					{
						sectionList[i].changesMade = value;
					}
				}
				
				//System.Windows.MessageBox.Show("vc set " + value.ToString());
			}
		}
		
		private ObservableCollection<BaseSection> _sectionList = new ObservableCollection<BaseSection>();
		
		public ObservableCollection<BaseSection> sectionList {
			get { return _sectionList; }
			set
			{
				if(_sectionList != value)
				{
					_sectionList = value;
					NotifyPropertyChanged("sectionList");
				}
			}
		}
		
		public bool AddValue(string nameOfSection, string _nameOfNewValue)
		{
			if (_nameOfNewValue != "" && nameOfSection != "")
			{
				for (int _currentSection = 0;_currentSection<sectionList.Count;_currentSection++)
				{
					if (sectionList[_currentSection].name == nameOfSection)
					{
						BaseValue _newValue = new BaseValue();
						_newValue.name = _nameOfNewValue;
						sectionList[_currentSection].valueList.Add(_newValue);
						return true;
					}
				}
				if (AddSection(nameOfSection))
					return AddValue(nameOfSection,_nameOfNewValue);
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
			if (nameOfSection != "")
			{
				if (FindSection(nameOfSection) == -1)
				{

					BaseSection _newSection = new BaseSection();
					_newSection.name = nameOfSection;
					sectionList.Add(_newSection);
					return true;

				}
				else
				{
					System.Windows.MessageBox.Show("Section with the name '" + nameOfSection + "' already exists.");
					return false;
				}
			}
			else
			{
				System.Windows.MessageBox.Show("Cannot create a section with no name.");
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
		
		public int FindParentSection(string _inputValueName)
		{
			if (_inputValueName != "")
			{
				_inputValueName = _inputValueName.Trim(' ','[',']');
				
				for (int _currentSection = 0;_currentSection<sectionList.Count;_currentSection++)
				{
					if (sectionList[_currentSection].FindValue(_inputValueName) != -1)
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
	}
	
	public class BaseSection : customObservable1
	{
		private string _name="";
		public string name
		{
			get
			{
				return _name;
			}
			set
			{
				if(_name == value)
					return;
				
				_name = value;
				NotifyPropertyChanged("name");
				
			}
		}
		
		private bool _changesMade = false;
		
		public override bool changesMade
		{
			get
			{
				if(!_changesMade)
				{
					for(int i = 0; i < valueList.Count;i++)
					{
						if(valueList[i].changesMade)
						{
							_changesMade = true;
							break;
						}
					}
				}
				//System.Windows.MessageBox.Show("cs get " + _changesMade.ToString());
				return _changesMade;
			}
			set
			{
				_changesMade = value;
				
				if(!value)
				{
					for(int i = 0; i < valueList.Count;i++)
					{
						valueList[i].changesMade = value;
					}
				}
				//System.Windows.MessageBox.Show("cs set " + _changesMade.ToString());
			}
		}
		
		ObservableCollection<BaseValue> _valueList = new ObservableCollection<BaseValue>();
		
		public ObservableCollection<BaseValue> valueList {
			get { return _valueList; }
			set
			{
				if(_valueList != value)
				{
					_valueList = value;
					NotifyPropertyChanged("valueList");
				}
			}
		}
		
		public int FindValue(string inputValueName)
		{
			if(inputValueName != "")
			{
				for(int currentValue = 0;currentValue < valueList.Count;currentValue++)
				{
					if(valueList[currentValue].name == inputValueName)
						return currentValue;
				}
			}
			return -1;
		}
		
	}
	
	public class BaseValue :  customObservable1
	{
		private bool _changesMade = false;
		
		public override bool changesMade {
			get { return _changesMade; }
			set { _changesMade = value; }
		}
		
		private string _name = "";
		
		public string name {
			get { return _name; }
			set
			{
				if(_name == value)
					return;
				
				_name = value;
				NotifyPropertyChanged("name");
			}
		}
	}
}
