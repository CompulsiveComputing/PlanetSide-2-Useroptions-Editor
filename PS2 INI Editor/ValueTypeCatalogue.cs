/*
 * Created by SharpDevelop.
 * User: Devahlin
 * Date: 01/29/2015
 * Time: 09:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PS2_INI_Editor
{
	/// <summary>
	/// Description of ValueTypeCatalogue.
	/// </summary>
	public class ValueTypeCatalogue
	{
		public IDictionary<string, ValueType> ValueTypes = new Dictionary<string, ValueType>();
		
		public ValueTypeCatalogue()
		{
			ValueTypes.Add("Numeric", new ValueType());
			ValueTypes["Numeric"].upperLowerBoundsUsed = true;
			ValueTypes["Numeric"].possibleValuesUsed = false;
			
			ValueTypes.Add("Textual", new ValueType());
			ValueTypes["Textual"].upperLowerBoundsUsed = false;
			ValueTypes["Textual"].possibleValuesUsed = true;
			
			ValueTypes.Add("Empty", new ValueType());
			ValueTypes["Empty"].upperLowerBoundsUsed = false;
			ValueTypes["Empty"].possibleValuesUsed = false;
			
			
		}
		
		public class ValueType
		{
			public bool upperLowerBoundsUsed;
			public bool possibleValuesUsed;
		}
	}
}
