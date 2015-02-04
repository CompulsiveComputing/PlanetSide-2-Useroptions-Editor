/*
 * Created by SharpDevelop.
 * User: Devahlin
 * Date: 02/04/2015
 * Time: 08:55
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
	/// Description of INIcomposite.
	/// </summary>
	public class compositeINI 
	{
		private INIinterfacer _userOptionsINI = new INIinterfacer();
		
		public INIinterfacer userOptionsINI
		{
			get
			{
				return _userOptionsINI;
			}
			set
			{
				if(value != _userOptionsINI)
				{
					_userOptionsINI = value;
				}
			}
		}
		
		private ValueCatalogue _valuesCatalogue = new ValueCatalogue();
		
		public ValueCatalogue valuesCatalogue
		{
			get
			{
				return _valuesCatalogue;
			}
			set
			{
				if(value != _valuesCatalogue)
				{
					_valuesCatalogue = value;
				}
			}
		}
		
		public compositeINI()
		{
		}
	}
	
	public class compositeSection
	{
		private ObservableCollection<Value> _valueList = new ObservableCollection<Value>();
		
		public  ObservableCollection<Value> valueList
		{
			get
			{
				return _valueList;
			}
			set
			{
				if(value != _valueList)
				{
					_valueList = value;
				}
			}
		}
		
	}
	
	public class compositeValue : PS2_INI_Editor.Value
	{
		
	}
}
