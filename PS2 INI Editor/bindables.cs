/*
 * Created by SharpDevelop.
 * User: Devahlin
 * Date: 01/26/2015
 * Time: 05:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;

namespace PS2_INI_Editor
{
	/// <summary>
	/// Description of bindables.
	/// </summary>
	public class bindableString : INotifyPropertyChanged
	{

		private string _text = "";
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		private void NotifyPropertyChanged(String propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		public string text
		{
			get
			{
				return _text;
			}
			set
			{
				_text = value;
				NotifyPropertyChanged("text");
			}
		}
	}
}
