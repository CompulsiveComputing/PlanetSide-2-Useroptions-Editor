/*
 * Created by SharpDevelop.
 * User: Devahlin
 * Date: 01/26/2015
 * Time: 00:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Xml.Serialization;


namespace PS2_INI_Editor
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class ValueCatalogue : customObservable1
	{
		
		//private Dictionary<string, CatalogueSection> _sections = new Dictionary<string, CatalogueSection>();
		
		[XmlIgnoreAttribute]
		public ValueTypeCatalogue ValueTypeCatalogue = new ValueTypeCatalogue();
		
		[XmlIgnoreAttribute]
		private bool _changesMade = false; // someday this will be true... someday
		
		[XmlIgnoreAttribute]
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
		
		private ObservableCollection<CatalogueSection> _sectionList = new ObservableCollection<CatalogueSection>();
		
		public ObservableCollection<CatalogueSection> sectionList {
			get { return _sectionList; }
			set
			{
				if(_sectionList == value)
					return;
				
				_sectionList = value;
				//changesMade = true; // not sure why this isn't being called
				NotifyPropertyChanged("sectionList");
			}
		}
		
		public bool forcePropertyChanged()
		{
			NotifyPropertyChanged("sectionList");
			
			for(var i = 0; i < sectionList.Count; i++)
				sectionList[i].forcePropertyChanged();
			
			return true;
		}

		public bool AddValue(string nameOfSection, string _nameOfNewValue)
		{
			if (_nameOfNewValue != "" && nameOfSection != "")
			{
				for (int _currentSection = 0;_currentSection<sectionList.Count;_currentSection++)
				{
					if (sectionList[_currentSection].name == nameOfSection)
					{
						CatalogueValue _newValue = new CatalogueValue();
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

					CatalogueSection _newSection = new CatalogueSection();
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
	
	public class CatalogueSection : customObservable1
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
		
		[XmlIgnoreAttribute]
		private bool _changesMade = false;
		
		[XmlIgnoreAttribute]
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
		
		
		//private Dictionary<string, CatalogueValue> _values = new Dictionary<string, CatalogueValue>();
		
		
		ObservableCollection<CatalogueValue> _valueList = new ObservableCollection<CatalogueValue>();
		
		public ObservableCollection<CatalogueValue> valueList {
			get { return _valueList; }
			set
			{
				if(_valueList == value)
					return;
				
				
				_valueList = value;
				NotifyPropertyChanged("valueList");
			}
		}
		
		public CatalogueSection()
		{
		}
		
		public bool forcePropertyChanged()
		{
			NotifyPropertyChanged("valueList");
			NotifyPropertyChanged("name");
			
			for(var i = 0; i < valueList.Count;i++)
				valueList[i].forcePropertyChanged();
			
			return true;
		}
		
		public bool AddValue(string Name)
		{
			if(Name != "")
			{
				if(this.FindValue(Name) == -1)
				{
					CatalogueValue newValue = new CatalogueValue();
					newValue.name = Name;
					valueList.Add(newValue);
					return true;
				}
				else
				{
					System.Windows.MessageBox.Show("Value with the name '" + Name + "' already exists.");
					return false;
				}
			}
			else
			{
				System.Windows.MessageBox.Show("Cannot create a value with no name.");
				return false;
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
	
	public class CatalogueValue : customObservable1
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
				changesMade = true;
				NotifyPropertyChanged("name");
			}
		}
		
		[XmlIgnoreAttribute]
		private bool _changesMade = false;
		
		[XmlIgnoreAttribute]
		public override bool changesMade
		{
			get
			{
				if(!_changesMade)
				{
					for(int i = 0; i < possibleValues.Count;i++)
					{
						if(possibleValues[i].changesMade)
						{
							_changesMade = true;
							break;
						}
					}
				}
				
				return _changesMade;
			}
			set
			{
				_changesMade = value;
				
				if(!value)
				{
					for(int i = 0; i < possibleValues.Count;i++)
					{
						possibleValues[i].changesMade = value;
					}
				}
			}
		}
		
		private string _valuetype = "";
		
		public string valuetype {
			get { return _valuetype; }
			set 
			{ 
				if(_valuetype == value)
					return;
				
				_valuetype = value;
				changesMade = true;
			}
		}
		
		private ObservableCollection<possibleValue> _possibleValues = new ObservableCollection<possibleValue>();
		
		public ObservableCollection<possibleValue> possibleValues {
			get { return _possibleValues; }
			set
			{
				if(_possibleValues == value)
					return;
				
				_possibleValues = value;
				NotifyPropertyChanged("possibleValues");
			}
		}
		
		private float _upperBounds = 0;
		
		public float upperBounds {
			get { return _upperBounds; }
			set 
			{ 
				if(_upperBounds == value)
					return;
				
				_upperBounds = value; 
				NotifyPropertyChanged("upperBounds");
			}
		}
		
		private float _lowerBounds = 0;
		
		public float lowerBounds {
			get { return _lowerBounds; }
			set 
			{
				if(_lowerBounds == value)
					return;
				
				_lowerBounds = value; 
				NotifyPropertyChanged("lowerBounds");
			}
		}
		
		public string _defaultValue;
		
		public string defaultValue {
			get { return _defaultValue; }
			set 
			{ 
				if(_defaultValue == value)
					return;
				
				_defaultValue = value;
			}
		}
		
		private string _description = "";
		
		public string description {
			get { return _description; }
			set
			{
				if(_description == value)
					return;
				
				_description = value;
				NotifyPropertyChanged( "description");
			}
		}
		
		public bool forcePropertyChanged()
		{
			NotifyPropertyChanged("name");
			NotifyPropertyChanged("description");
			NotifyPropertyChanged("lowerBounds");
			NotifyPropertyChanged("upperBounds");
			NotifyPropertyChanged("possibleValues");
			NotifyPropertyChanged("valuetype");
			return true;
		}
	}
	
	public class possibleValue : customObservable1
	{
		[XmlIgnoreAttribute]
		public bool _changesMade = false;
		
		public override bool changesMade {
			get { return _changesMade; }
			set 
			{ 
				_changesMade = value; 
			}
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
		
		private string _contents = "";
		
		public string contents {
			get { return _contents; }
			set 
			{
				if(_contents == value)
					return;
				
				_contents = value; 
				NotifyPropertyChanged("contents");
			}
		}
		
		public possibleValue()
		{
		}
		
		public possibleValue(string _name, string _contents)
		{
			name = _name;
			contents = _contents;
		}
	}
	
	public abstract class customObservable1 : INotifyPropertyChanged
	{
		[XmlIgnoreAttribute]
		public abstract bool changesMade {get; set;}
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected void NotifyPropertyChanged(String propertyName = "")
		{
			if (PropertyChanged != null)
			{
				changesMade = true;
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
