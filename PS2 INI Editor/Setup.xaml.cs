/*
 * Created by SharpDevelop.
 * User: Devahlin
 * Date: 01/29/2015
 * Time: 05:12
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
	/// Interaction logic for Setup.xaml
	/// </summary>
	public partial class Setup : Window
	{
		MainWindow main;
		
		public bindableString chosenFolder = new bindableString();
		
		
		
		public Setup()
		{
			main = App.Current.MainWindow as MainWindow;
			
			InitializeComponent();
			
			chosenFolder.text = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\PlanetSide 2 Config Editor\\";
			
			FolderPathTextBox.DataContext = this;
			
			Binding binding = new Binding() { Source = chosenFolder, Path = new PropertyPath("text") };
			BindingOperations.SetBinding(FolderPathTextBox, TextBox.TextProperty, binding);
		}
		
		void Exit_App_Button_Click(object sender, RoutedEventArgs e)
		{
			this.Close(); // application exit is handled elsewhere
		}
		
		void Finish_Button_Click(object sender, RoutedEventArgs e)
		{
			string message = "You have read and agree to the terms listed, and would like this utility to use the following folder?" + Environment.NewLine + chosenFolder.text;
			
			if(System.Windows.MessageBox.Show( message,"Verification",MessageBoxButton.OKCancel) == MessageBoxResult.OK)
			{
				main.head.currentConfiguration.settingsFolder = chosenFolder.text;
				this.Close();
			}
			
		}
		
		void BrowseToDirectoryButton_Click(object sender, RoutedEventArgs e)
		{
			System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			folderBrowserDialog1.SelectedPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			folderBrowserDialog1.ShowNewFolderButton = true;
			//folderBrowserDialog1.
			folderBrowserDialog1.Description = "Please selected the destination folder you would like this utility to save its settings files and backups to.";
				
			if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				chosenFolder.text = folderBrowserDialog1.SelectedPath + "\\PlanetSide 2 Config Editor\\";
			}
		}
	}
}