/*
 * Created by SharpDevelop.
 * User: Devahlin
 * Date: 01/26/2015
 * Time: 06:28
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
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class TroubleshootingWindow : Window
	{
		public TroubleshootingWindow()
		{
			InitializeComponent();
		}
		
		void Enable_Troubleshooting_Button_Click(object sender, RoutedEventArgs e)
		{
			DeleteINIButton.IsEnabled = !DeleteINIButton.IsEnabled;
			DeleteConfigButton.IsEnabled = !DeleteConfigButton.IsEnabled;
			JesseRefreshButton.IsEnabled = !JesseRefreshButton.IsEnabled;
		}
	}
}