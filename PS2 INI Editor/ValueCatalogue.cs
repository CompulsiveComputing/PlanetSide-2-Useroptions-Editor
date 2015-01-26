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

namespace PS2_INI_Editor
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class ValueCatalogue
	{
		public string location = "";
		
		private ObservableCollection<CatalogueSection> _sections = new ObservableCollection<CatalogueSection>();
		
		//private Dictionary<string, CatalogueSection> _sections = new Dictionary<string, CatalogueSection>();
		
		public  ObservableCollection<CatalogueSection> sections
		{
			get
			{
				return _sections;
			}
			set
			{
				_sections = value;
			}
		}
		
		public ValueCatalogue()
		{
			
		}
		
		public void addSection(string Name)
		{
			//_sections[Name] = new CatalogueSection();
			CatalogueSection newSection = new CatalogueSection();
			newSection.name = Name;
			_sections.Add(newSection);
		}
	}
	
	public class CatalogueSection
	{
		public string name = "";
		
		private ObservableCollection<CatalogueValue> _values = new ObservableCollection<CatalogueValue>();
		
		//private Dictionary<string, CatalogueValue> _values = new Dictionary<string, CatalogueValue>();
		
		public  ObservableCollection<CatalogueValue> values
		{
			get
			{
				return _values;
			}
			set
			{
				_values = value;
			}
		}
		
		public void addValue(string Name)
		{
			CatalogueValue newValue = new CatalogueValue();
			newValue.name = Name;
			_values.Add(newValue);
		}

	}
	
	public class CatalogueValue
	{
		public string name = "";
		public string valuetype = "";
		public List<string> possibleValues = new List<string>();
		public float _upperBounds = 0;
		public float _lowerBounds = 0;
		public string defaultValue;
	}
}
