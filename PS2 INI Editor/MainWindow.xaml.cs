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
using System.Runtime.InteropServices;


namespace PS2_INI_Editor
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public PS2ConfigurationHead head = new PS2ConfigurationHead();
		
		public Window childWindow;
		[DllImportAttribute("User32.dll")]
		static extern bool SetForegroundWindow(IntPtr hWnd);
		[DllImportAttribute("User32.dll")]
		private static extern int FindWindow(String ClassName, String WindowName);
		
		
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
			if(!this.IsLoaded)
				return;
			if(PS2InstallationsCombobox.SelectedIndex<0)
				TabRawINI.IsEnabled = false;
			else
				TabRawINI.IsEnabled = true;
			
			if(TabControlCenter.IsSelected)
			{
				//UpdateControlCenter();
				
				if(PS2InstallationsCombobox.SelectedIndex<0)
					System.Windows.MessageBox.Show("Please select a Planetside 2 install directory.","Notification",MessageBoxButton.OK);
			}
			else if (TabValueEditor.IsSelected)
			{
				Binding binding = new Binding() { Source = head._currentUserOptionsINI, Path = new PropertyPath("sectionList"), Mode= BindingMode.TwoWay};
				BindingOperations.SetBinding(ValueEditorItemsControl, System.Windows.Controls.ItemsControl.ItemsSourceProperty, binding);
			}
			else if(TabRawINI.IsSelected)
			{
				RawINITextBox.Text = head._currentUserOptionsINI.toWritableString();
				
				//MessageBox.Show(RawINITextBoxBinding,"t");
			}
			else if(TabBackups.IsSelected)
			{
				// PS2ConfigurationHead.annoy(head._backupINIList.allBackups.Count.ToString());
				
				Binding binding = new Binding() { Source = head._backupINIList, Path = new PropertyPath("allBackups"), Mode= BindingMode.OneWay};
				BindingOperations.SetBinding(BackupsTreeView, System.Windows.Controls.TreeView.ItemsSourceProperty, binding);
			}
			else if(TabKeybindings.IsSelected)
			{
				
			}
		}
		
		
		void Button_Click_Exit(object sender, RoutedEventArgs e)
		{
			head.currentConfiguration._wasMaximized = (WindowState == WindowState.Maximized);
			head.CloseApplication();
		}
		
		void UpdateControlCenterBindings()
		{
			//this.PS2Installations.Items.Clear();
			if (head.discoveredGameInstallations.Count > 1)
			{
				PS2InstallationsCombobox.ItemsSource = head.discoveredGameInstallations;
			}
			else
			{
				this.PS2InstallationsCombobox.Items.Add("No Planetside 2 installations found.");
				this.PS2InstallationsCombobox.SelectedIndex = 0;
			}
			
			Binding binding = new Binding() { Source = head.currentConfiguration._backupFolderLocation, Path = new PropertyPath("text"), Mode= BindingMode.TwoWay};
			BindingOperations.SetBinding(BackupFolderTextBox, System.Windows.Controls.TextBox.TextProperty, binding);
			
			binding = new Binding() { Source = head, Path = new PropertyPath("selectedGameInstallation"), Mode= BindingMode.TwoWay};
			BindingOperations.SetBinding(PS2InstallationsCombobox, System.Windows.Controls.ComboBox.SelectedIndexProperty, binding);
		}
		

		
		void PS2Installation_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			/*if(head.selectedGameInstallation != PS2InstallationsCombobox.SelectedIndex)
			{
				head.selectedGameInstallation = PS2InstallationsCombobox.SelectedIndex;
				PS2InstallationsCombobox.SelectedIndex = head.selectedGameInstallation; // done incase for some reason we could not load said installation
			}*/
		}
		
		void test_button_click(object sender, RoutedEventArgs e)
		{
			head.changesPending = true;
			
			//ValueCatalogue test = new ValueCatalogue();
			
			//test.AddSection("Test1");
			
			//MessageBox.Show(XMLSerialize.SerializeToString(test),"woohoo");
			
			/*ValueCatalogue test = new ValueCatalogue();
			
			test.addSection("teehee");
			test.sections[0].addValue("woowoo");
			
			MessageBox.Show(XMLSerialize.SerializeToString(test), "test");*/
		}
		
		void RawINITextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if(RawINITextBox.Text != head._currentUserOptionsINI.toWritableString())
				head._currentUserOptionsINI.SafelyLoadINIFromString(RawINITextBox.Text);
		}
		
		void Reload_button_Click(object sender, RoutedEventArgs e)
		{
			head.SwitchToInstallation(head.selectedGameInstallation);
			RefreshTab();
		}
		
		void open_troubleshooting_Button_Click(object sender, RoutedEventArgs e)
		{
			childWindow = new TroubleshootingWindow();
			//trouble.Topmost = true;
			childWindow.ShowDialog();
			childWindow = null;
		}
		
		void Settings_Button_Click(object sender, RoutedEventArgs e)
		{
			SettingsWindow settings = new SettingsWindow();
			//settings.Topmost = true;
			settings.Show();
		}
		
		void Window_GotFocus(object sender, RoutedEventArgs e) // supposed to switch to any opened windows to prevent them being thrown behind while holding priority, doesn't work yet
		{
			//MessageBox.Show("g");
			/*
			if(childWindow != null)
			{
				int hWnd = FindWindow(null, this.Title);
				
				System.Diagnostics.Process[] p = System.Diagnostics.Process.GetProcessesByName(head._applicationName);
				
				if (p.Length > 0) //If found
				{
					SetForegroundWindow(p[0].MainWindowHandle); //Activate it
					childWindow.BringIntoView();
				}
				else
				{
					//MessageBox.Show("Window Not Found!");
				}
			}*/
		}
		
		void BrowseBackupFolderButton_Click(object sender, RoutedEventArgs e)
		{
			System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			folderBrowserDialog1.SelectedPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			folderBrowserDialog1.ShowNewFolderButton = true;
			//folderBrowserDialog1.
			folderBrowserDialog1.Description = "Please selected the destination folder you would like this utility to save its backups to.";
			
			if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				head.currentConfiguration._backupFolderLocation.text = folderBrowserDialog1.SelectedPath + "\\Backups\\";
			}
		}
		
		void BackupFolderTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			/*
			var text = BackupFolderTextBox.Text;
			
			if(fileOps.folderExists(text) && !fileOps.fileExists(text))
			{
				head.currentConfiguration._backupFolderLocation = text;
			}*/
		}
		
		void Window_Closing(object sender, CancelEventArgs e)
		{
			head.currentConfiguration._wasMaximized = (WindowState == WindowState.Maximized);
			e.Cancel = !head.CloseApplication();
		}
		
		void SaveButton_Click(object sender, RoutedEventArgs e)
		{
			head.saveFiles();
		}
		
		void Window_Activated(object sender, EventArgs e)
		{
		}
		
		void Window_ContentRendered(object sender, EventArgs e)
		{
			if(head.currentConfiguration._wasMaximized && head.currentConfiguration._rememberMaximized)
			{
				//WindowState = WindowState.Maximized;
			}
			RefreshTab();
		}
		
		void BackupsTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			if(BackupsTreeView.SelectedItem != null && BackupsTreeView.SelectedItem.GetType() == typeof(INIBackup))
			{
				
				BackupsTabNameTextBox.Text = (BackupsTreeView.SelectedItem as INIBackup).backup.fileName;
				BackupsTabDateTextBlock.Text = (BackupsTreeView.SelectedItem as INIBackup).backupTime.ToString();
				BackupsTextBox.Text = (BackupsTreeView.SelectedItem as INIBackup).backup.toWritableString();
			}
			else
			{
				BackupsTabNameTextBox.Text = string.Empty;
				BackupsTabDateTextBlock.Text = string.Empty;
				BackupsTextBox.Text =  string.Empty;
			}
		}
	}
}
