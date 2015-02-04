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
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Collections.ObjectModel;
using Binding = System.Windows.Data.Binding;

namespace PS2_INI_Editor
{
	/// <summary>
	/// Interaction logic for ValueCatalogueEditor.xaml
	/// </summary>
	public partial class ValueCatalogueEditor : Window
	{
		MainWindow main;
		
		private ValueCatalogue _treeBinding = new ValueCatalogue();
		
		public ValueCatalogue treeBinding {
			get { return _treeBinding; }
			set { _treeBinding = value; _treeBinding.changesMade = true; }
		}
		
		int activeSection = -1, activeValue = -1;
		
		public ValueCatalogueEditor()
		{
			InitializeComponent();
			
			
			main = App.Current.MainWindow as MainWindow;
			
			bool tempChangesMade = main.head.ValuesCatalogue.changesMade;
			
			treeBinding = main.head.ValuesCatalogue;
			
			treeBinding.changesMade = tempChangesMade;
			
			CatalogueTreeViewer.ItemsSource = treeBinding.sectionList;
			
			//ValueTypeDropDown.ItemsSource = TreeBinding.ValueTypeCatalogue.ValueTypes;
			
			foreach(KeyValuePair<string, ValueTypeCatalogue.ValueType> entry in treeBinding.ValueTypeCatalogue.ValueTypes)
			{
				ValueTypeDropDown.Items.Add(entry.Key);
			}
			
			/*
			TreeBinding.AddSection("Graphics");
			TreeBinding.AddSection("Sounds");
			
			TreeBinding.sectionList[0].AddValue("Effects");
			TreeBinding.sectionList[0].AddValue("Graphics");
			TreeBinding.sectionList[0].AddValue("Particles");
			TreeBinding.sectionList[0].AddValue("Stuff");
			TreeBinding.sectionList[1].AddValue("Channels");
			TreeBinding.sectionList[1].AddValue("Voices");
			TreeBinding.sectionList[1].AddValue("Cookies");
			TreeBinding.sectionList[1].AddValue("Kittens");
			 */
			

			
		}
		
		public void UILogic()
		{
			string text = "";
			Binding binding;
			
			//bool valueControlsDisabled = true;
			
			if(activeSection != -1)
			{
				NameTextBox.IsEnabled = true;
				
				if(activeValue !=-1)
				{
					CatalogueValue SelectedValue = CatalogueTreeViewer.SelectedItem as CatalogueValue;
					ValueTypeDropDown.IsEnabled = true;
					DescriptionTextBox.IsEnabled = true;
					
					for(int i = 0;i<ValueTypeDropDown.Items.Count;i++)
					{
						if(ValueTypeDropDown.Items[i].ToString() == treeBinding.sectionList[activeSection].valueList[activeValue].valuetype)
						{
							ValueTypeDropDown.SelectedIndex = i;
							break;
						}
					}
					
					if(SelectedValue.valuetype == null || !treeBinding.ValueTypeCatalogue.ValueTypes.ContainsKey(SelectedValue.valuetype))
						SelectedValue.valuetype = "Empty";
					
					EnableControlsOnValueType(treeBinding.ValueTypeCatalogue.ValueTypes[SelectedValue.valuetype]);
					
					
					binding = new Binding() { Source = SelectedValue, Path = new PropertyPath("description"), Mode = BindingMode.TwoWay};
					BindingOperations.SetBinding(DescriptionTextBox, System.Windows.Controls.TextBox.TextProperty, binding);
					
					binding = new Binding() { Source = SelectedValue, Path = new PropertyPath("name"), Mode = BindingMode.TwoWay, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged};
					BindingOperations.SetBinding(NameTextBox, System.Windows.Controls.TextBox.TextProperty, binding);
					
					
					
					
					if(UpperBoundsTextBox.IsEnabled)
					{
						binding = new Binding() { Source = SelectedValue, Path = new PropertyPath("upperBounds"), Mode = BindingMode.TwoWay};
						BindingOperations.SetBinding(UpperBoundsTextBox, System.Windows.Controls.TextBox.TextProperty, binding);
						
						binding = new Binding() { Source = SelectedValue, Path = new PropertyPath("lowerBounds"), Mode = BindingMode.TwoWay};
						BindingOperations.SetBinding(LowerBoundsTextBox, System.Windows.Controls.TextBox.TextProperty, binding);
						
						
						//UpperBoundsTextBox.Text = SelectedValue.upperBounds.ToString();
						//LowerBoundsTextBox.Text = SelectedValue.lowerBounds.ToString();
					}
					else
					{
						
					}
					
					if(PossibleValuesListView.IsEnabled)
					{
						PossibleValuesListView.ItemsSource = SelectedValue.possibleValues;
						
						int index = PossibleValuesListView.SelectedIndex;
						
						//System.Windows.MessageBox.Show(index.ToString());
						
						if(index != -1)
						{
							//System.Windows.MessageBox.Show(index.ToString());
							
							//PossibleValueNameTextBox.Text = SelectedValue.possibleValues[index].name;
							//PossibleValueValueTextBox.Text = SelectedValue.possibleValues[index].contents;
							
							binding = new Binding() { Source = SelectedValue.possibleValues[index], Path = new PropertyPath("name"), UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged };
							BindingOperations.SetBinding(PossibleValueNameTextBox, System.Windows.Controls.TextBox.TextProperty, binding);
							
							//binding = null;
							
							binding = new Binding() { Source = SelectedValue.possibleValues[index], Path = new PropertyPath("contents"), UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged };
							BindingOperations.SetBinding(PossibleValueValueTextBox, System.Windows.Controls.TextBox.TextProperty, binding);
						}
						else
						{
							PossibleValueNameTextBox.BindingGroup = null;
							PossibleValueValueTextBox.BindingGroup = null;
						}
						
						
						
						//MyData myDataObject = new MyData(DateTime.Now);
						
						//using System.Windows.Forms.Binding;
						
						/*System.Windows.Data.Binding myBinding = new System.Windows.Data.Binding("name.text");
						myBinding.Source = SelectedValue.possibleValues;
						BindingOperations.SetBinding(PossibleValuesListView, System.Windows.Controls.ListView.ItemsSourceProperty, myBinding);*/
					}
					else
					{
						PossibleValuesListView.ItemsSource = null;
						PossibleValueNameTextBox.DataContext = null;
						PossibleValueValueTextBox.DataContext = null;
						PossibleValueNameTextBox.BindingGroup = null;
						PossibleValueValueTextBox.BindingGroup = null;
					}
					text = treeBinding.sectionList[activeSection].valueList[activeValue].name;
				}
				else
				{
					
					//text = TreeBinding.sectionList[activeSection].name;
					
					binding = new Binding() { Source = treeBinding.sectionList[activeSection], Path = new PropertyPath("name"), UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged};
					BindingOperations.SetBinding(NameTextBox, System.Windows.Controls.TextBox.TextProperty, binding);
					
					
					
					DescriptionTextBox.IsEnabled = false;
					ValueTypeDropDown.IsEnabled = false;
					EnableControlsOnValueType(treeBinding.ValueTypeCatalogue.ValueTypes["Empty"]);
				}
			}
			else
				NameTextBox.IsEnabled = false;
			
			/*if(NameTextBox.Text != text)
			{
				NameTextBox.Text = text;
			}*/
		}
		
		public void EnableControlsOnValueType(ValueTypeCatalogue.ValueType ValueType)
		{
			UpperBoundsTextBox.IsEnabled = ValueType.upperLowerBoundsUsed;
			LowerBoundsTextBox.IsEnabled = ValueType.upperLowerBoundsUsed;
			PossibleValueNameTextBox.IsEnabled = ValueType.possibleValuesUsed;
			PossibleValueValueTextBox.IsEnabled = ValueType.possibleValuesUsed;
			PossibleValuesListView.IsEnabled = ValueType.possibleValuesUsed;
			PossibleValuesAddButton.IsEnabled = ValueType.possibleValuesUsed;
			PossibleValuesRemoveButton.IsEnabled = ValueType.possibleValuesUsed;
		}
		
		void Button_Click(object sender, RoutedEventArgs e)
		{
			
		}
		
		void Catalogue_Add_Section_Button_click(object sender, RoutedEventArgs e)
		{
			treeBinding.AddSection("New Section");
			
			int sectionInt = treeBinding.FindSection("New Section");
			
			(CatalogueTreeViewer.ItemContainerGenerator.ContainerFromIndex(sectionInt) as TreeViewItem).IsSelected = true;
		}
		
		void Catalogue_Add_Value_Button_click(object sender, RoutedEventArgs e)
		{
			if(activeSection != -1)
			{
				treeBinding.sectionList[activeSection].AddValue("New Value");
				int valueInt = treeBinding.sectionList[activeSection].FindValue("New Value");
				
				//System.Windows.MessageBox.Show("hi"); // with this enabled... things work right... damn time delay
				
				//CatalogueTreeViewer.ItemContainerGenerator.
				//
				//CatalogueTreeViewer.ItemsSource = null;
				//CatalogueTreeViewer.ItemsSource = TreeBinding.sectionList;
				
				//BindingExpression be = CatalogueTreeViewer.GetBindingExpression(DependencyProperty);
				//if(be != null)
				//	be.UpdateTarget();
				
				
				
				TreeViewItem sectionContainer = CatalogueTreeViewer.ItemContainerGenerator.ContainerFromIndex(activeSection) as TreeViewItem;
				sectionContainer.IsSelected = true;
				
				//CatalogueTreeViewer.DataContext = TreeBinding.sectionList;
				
				//valueContainer = sectionContainer.ItemContainerGenerator.ContainerFromIndex(valueInt) as TreeViewItem;
				
				//sectionContainer
				
				sectionContainer.Focus();
				sectionContainer.IsExpanded = true;
				
				//TreeBinding.forcePropertyChanged();
				
				//if(valueContainer != null)
				//	valueContainer.Focus();
				
				
				//System.Windows.MessageBox.Show(sectionContainer.Items[valueInt].GetType().ToString()); // with this enabled... things work right... damn time delay
				
				//Monitor
				
				
				//System.Threading.Thread.Sleep(1000);
				//forceUIUpdate();
				
				
				
				////NameTextBox.Focus();
				//NameTextBox.SelectAll();
				
				
				sectionContainer.IsSelected = true;
				
				if (sectionContainer != null)
				{
					TreeViewItem valueContainer = sectionContainer.ItemContainerGenerator.ContainerFromIndex(valueInt) as TreeViewItem;
					if(valueContainer != null)
						valueContainer.IsSelected = true;
					//else
					//System.Windows.MessageBox.Show("Null value unexpected; Error code: diamond cookies expired", "Error"); // known issue, how in the world do we get the second tier TreeViewItem container?!
				}
			}
			
			else
				System.Windows.MessageBox.Show("Select a section to add a new value to before attempting again.", "Error");
		}
		
		void CatalogueTreeViewer_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			if(CatalogueTreeViewer.SelectedItem != null)
			{
				if(CatalogueTreeViewer.SelectedItem.GetType() == typeof(CatalogueSection))
				{
					activeSection = treeBinding.FindSection((CatalogueTreeViewer.SelectedItem as CatalogueSection).name);
					activeValue = -1;
				}
				else
				{
					activeSection = treeBinding.FindParentSection((CatalogueTreeViewer.SelectedItem as CatalogueValue).name);
					activeValue = treeBinding.FindValue(treeBinding.sectionList[activeSection].name,(CatalogueTreeViewer.SelectedItem as CatalogueValue).name);
				}
			}
			else
			{
				activeSection = -1;
				activeValue = -1;
			}

			UILogic();
		}
		
		void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if(NameTextBox.Text == "" && CatalogueTreeViewer.SelectedItem != null)
			{
				NameTextBox.Text = "cookies and cream";
			}
		}
		
		void ValueTypeDropDown_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			treeBinding.sectionList[activeSection].valueList[activeValue].valuetype = ValueTypeDropDown.SelectedItem.ToString();
			UILogic();
		}
		
		void PossibleValuesAddButton_Click(object sender, RoutedEventArgs e)
		{
			if (activeValue != -1)
			{
				treeBinding.sectionList[activeSection].valueList[activeValue].possibleValues.Add(new possibleValue("New Value", "0"));
				PossibleValuesListView.SelectedIndex = PossibleValuesListView.Items.Count - 1;
				PossibleValueNameTextBox.Focus();
				PossibleValueNameTextBox.SelectAll();
				//(PossibleValuesListView.ItemContainerGenerator.ContainerFromIndex[PossibleValuesListView.Items.Count -1] as ListViewItem).IsSelected = true;
			}
			
			UILogic();
		}
		
		void PossibleValuesRemoveButton_Click(object sender, RoutedEventArgs e)
		{
			treeBinding.sectionList[activeSection].valueList[activeValue].possibleValues.RemoveAt(PossibleValuesListView.SelectedIndex);
		}
		
		void DescriptionTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
		}
		
		void ValueCatalogueEditor_Window_Closing(object sender, CancelEventArgs e)
		{
			//System.Windows.Forms.MessageBox.Show(main.head.ValuesCatalogue.changesMade.ToString());
			
			if(main.head.ValuesCatalogue.changesMade) // somehow this isn't working
				
				treeBinding.changesMade = !main.head.saveValueCatalogue();
		}
		
		void PossibleValuesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UILogic();
		}
		
		void PossibleValueValueTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
		}
		
		void PossibleValueNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if(PossibleValueNameTextBox.Text == "" && CatalogueTreeViewer.SelectedItem != null && PossibleValuesListView.SelectedIndex != -1)
			{
				PossibleValueNameTextBox.Text = "kittens";
			}
		}
	}
}