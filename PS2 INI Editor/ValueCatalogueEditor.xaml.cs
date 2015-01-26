/*
 * Created by SharpDevelop.
 * User: Devahlin
 * Date: 01/26/2015
 * Time: 08:44
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
	/// Interaction logic for ValueCatalogueEditor.xaml
	/// </summary>
	public partial class ValueCatalogueEditor : Window
	{
		MainWindow main;
		
		public string AskForNameResult = ""; 
		
		public ValueCatalogueEditor()
		{
			InitializeComponent();
			main = App.Current.MainWindow as MainWindow;
			
			CatalogueTreeViewer.ItemsSource = main.head.ValuesCatalogue.sections;
		}
		
		void Button_Click(object sender, RoutedEventArgs e)
		{
			
		}
		
		void Catalogue_Add_Section_Button_click(object sender, RoutedEventArgs e)
		{
			AskForNameResult = "";
			
			AskForName newask = new AskForName();
			newask.Topmost = true;
			newask.ShowDialog();
			
			if (AskForNameResult != "")
				main.head.ValuesCatalogue.addSection(AskForNameResult);
		}
		
		void Catalogue_Add_Value_Button_click(object sender, RoutedEventArgs e)
		{
			
		}
		
		
	}
}