/*
 * Created by SharpDevelop.
 * User: Devahlin
 * Date: 01/26/2015
 * Time: 08:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace PS2_INI_Editor
{
	/// <summary>
	/// Interaction logic for SettingsWindow.xaml
	/// </summary>
	public partial class SettingsWindow : Window
	{
		public SettingsWindow()
		{
			InitializeComponent();
		}
		
		void Value_Catalogue_Editor_Button_Click(object sender, RoutedEventArgs e)
		{
			ValueCatalogueEditor catalogueEditor = new ValueCatalogueEditor();
			catalogueEditor.Topmost = true;
			catalogueEditor.ShowDialog();
		}
	}
}