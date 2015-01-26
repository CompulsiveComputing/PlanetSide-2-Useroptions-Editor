using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace PS2_INI_Editor
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public PS2ConfigurationHead head = new PS2ConfigurationHead();
		
		//public ObservableCollection<String> discoveredGameInstallations = new ObservableCollection<string>();
		
		public MainWindow()
		{
			
			InitializeComponent();
			
			this.Title = head._applicationName + "  |  " + head._versionString;
			
			
			head.InitializeHead();
			UpdateControlCenterBindings();
		}

		private void RefreshTab(object sender, SelectionChangedEventArgs e)
		{
			RefreshTab();
		}
		
		private void RefreshTab()
		{
				if(TabControlCenter.IsSelected)
				{
					//UpdateControlCenter();
				}
				else if (TabValueEditor.IsSelected)
				{
				}
				else if(TabRawINI.IsSelected)
				{
					RawINITextBox.Text = head._currentUserOptionsINI.toString();
					//MessageBox.Show(RawINITextBoxBinding,"t");
				}
		}
		
		
		void Button_Click_Exit(object sender, RoutedEventArgs e)
		{
			head.CloseApplication();
		}
		
		void UpdateControlCenterBindings()
		{
			//this.PS2Installations.Items.Clear();
			if (head.discoveredGameInstallations.Count > 1)
			{
				PS2Installations.ItemsSource = head.discoveredGameInstallations;
				PS2Installations.Text = "Please select your intended PlanetSide 2 installation";
				//PS2Installations
			}
			else
			{
				this.PS2Installations.Items.Add("No Planetside 2 installations found.");
				this.PS2Installations.SelectedIndex = 0;
			}
		}
		

		
		void PS2Installation_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if(head.selectedGameInstallation != PS2Installations.SelectedIndex)
			{
				head.selectedGameInstallation = PS2Installations.SelectedIndex;
				PS2Installations.SelectedIndex = head.selectedGameInstallation; // done incase for some reason we could not load said installation
			}
		}
		
		void test_button_click(object sender, RoutedEventArgs e)
		{
			head.changesPending = true;
			
			/*ValueCatalogue test = new ValueCatalogue();
			
			test.addSection("teehee");
			test.sections[0].addValue("woowoo");
			
			MessageBox.Show(XMLSerialize.SerializeToString(test), "test");*/
		}
		
		void enable_Troubleshooting_Button_Click(object sender, RoutedEventArgs e)
		{
			//troubleshootingButton1.IsEnabled = !troubleshootingButton1.IsEnabled;
			//troubleshootingButton2.IsEnabled = !troubleshootingButton2.IsEnabled;
		}
		
		void RawINITextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			head._currentUserOptionsINI.SafelyLoadINIFromString(RawINITextBox.Text);	
		}
		
		void Reload_button_Click(object sender, RoutedEventArgs e)
		{
			head.SwitchToInstallation(head.selectedGameInstallation);
			RefreshTab();
		}
		
		void open_troubleshooting_Button_Click(object sender, RoutedEventArgs e)
		{
			TroubleshootingWindow trouble = new TroubleshootingWindow();
			trouble.Topmost = true;
			trouble.ShowDialog();
		}
		
		void Settings_Button_Click(object sender, RoutedEventArgs e)
		{
			SettingsWindow settings = new SettingsWindow();
			settings.Topmost = true;
			settings.ShowDialog();
		}
	}
}
