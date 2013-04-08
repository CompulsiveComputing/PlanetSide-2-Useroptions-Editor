/*
 * Created by SharpDevelop.
 * User: Gamer
 * Date: 23/03/2013
 * Time: 12:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 using System.Windows.Forms;
 using System.Collections.Generic;
 
 
namespace PlanetSide_2_Useroptions_Editor
{
	
	partial class MainForm
	{
		

		
		
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.DeleteINIButton = new System.Windows.Forms.Button();
			this.SaveINIButton = new System.Windows.Forms.Button();
			this.ReloadINIButton = new System.Windows.Forms.Button();
			this.RegenINIButton = new System.Windows.Forms.Button();
			this.DeleteSectionButton = new System.Windows.Forms.Button();
			this.AddSectionButton = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.ValueEnabledCheckbox = new System.Windows.Forms.CheckBox();
			this.label15 = new System.Windows.Forms.Label();
			this.ResetValueButton = new System.Windows.Forms.Button();
			this.ValEditLowerBoundsTextbox = new System.Windows.Forms.TextBox();
			this.ValEditNameTextbox = new System.Windows.Forms.TextBox();
			this.BackupSectionButton = new System.Windows.Forms.Button();
			this.ValEditUpperBoundsTextbox = new System.Windows.Forms.TextBox();
			this.ValEditValueTextbox = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.ValueEditorTree = new System.Windows.Forms.TreeView();
			this.label16 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.DeleteValueButton = new System.Windows.Forms.Button();
			this.AddValueButton = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.RawINITextBox = new System.Windows.Forms.RichTextBox();
			this.performanceCheatsTabPage4 = new System.Windows.Forms.TabPage();
			this.panel5 = new System.Windows.Forms.Panel();
			this.SetTDRecommendedHighButton = new System.Windows.Forms.Button();
			this.SetTDRecommendedUltraButton = new System.Windows.Forms.Button();
			this.panel4 = new System.Windows.Forms.Panel();
			this.FSAATextBox = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.RenderQualityTextBox = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.RenderQualityTrackbar = new System.Windows.Forms.TrackBar();
			this.label20 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.SetUltraGpuSettingsButton = new System.Windows.Forms.Button();
			this.SetHighCPUSoundButton = new System.Windows.Forms.Button();
			this.SetLowCPUSoundButton = new System.Windows.Forms.Button();
			this.SetLowCPUGraphicsSettingsButton = new System.Windows.Forms.Button();
			this.SetUltraCPUGrapgicalSettingsButton = new System.Windows.Forms.Button();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.button11 = new System.Windows.Forms.Button();
			this.vScrollBar3 = new System.Windows.Forms.VScrollBar();
			this.button7 = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.richTextBox2 = new System.Windows.Forms.RichTextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.hScrollBar2 = new System.Windows.Forms.HScrollBar();
			this.vScrollBar2 = new System.Windows.Forms.VScrollBar();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label17 = new System.Windows.Forms.Label();
			this.ReadOnlyCheckbox = new System.Windows.Forms.CheckBox();
			this.label21 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label19 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.KeepBackupsCheckbox = new System.Windows.Forms.CheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.IncrimentalBackupsToKeepTextbox = new System.Windows.Forms.TextBox();
			this.ValueCatalogueBrowseButton = new System.Windows.Forms.Button();
			this.BackupLocationBrowseButton = new System.Windows.Forms.Button();
			this.ValueCatalogueLcationTextbox = new System.Windows.Forms.TextBox();
			this.UserOptionsINIBrowseButton = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.BackupLocationTextbox = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.UseroptionsLocationTextbox = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.button2 = new System.Windows.Forms.Button();
			this.BackupINIButton = new System.Windows.Forms.Button();
			this.VersionStringLabel1 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.performanceCheatsTabPage4.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.RenderQualityTrackbar)).BeginInit();
			this.tabPage3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.SuspendLayout();
			// 
			// DeleteINIButton
			// 
			this.DeleteINIButton.Location = new System.Drawing.Point(64, 46);
			this.DeleteINIButton.Name = "DeleteINIButton";
			this.DeleteINIButton.Size = new System.Drawing.Size(75, 23);
			this.DeleteINIButton.TabIndex = 1;
			this.DeleteINIButton.Text = "Delete INI";
			this.DeleteINIButton.UseVisualStyleBackColor = true;
			this.DeleteINIButton.Click += new System.EventHandler(this.DeleteINIButtonClick);
			// 
			// SaveINIButton
			// 
			this.SaveINIButton.Location = new System.Drawing.Point(403, 408);
			this.SaveINIButton.Name = "SaveINIButton";
			this.SaveINIButton.Size = new System.Drawing.Size(75, 23);
			this.SaveINIButton.TabIndex = 2;
			this.SaveINIButton.Text = "Save INI";
			this.SaveINIButton.UseVisualStyleBackColor = true;
			this.SaveINIButton.Click += new System.EventHandler(this.SaveINIButtonClick);
			// 
			// ReloadINIButton
			// 
			this.ReloadINIButton.Location = new System.Drawing.Point(322, 408);
			this.ReloadINIButton.Name = "ReloadINIButton";
			this.ReloadINIButton.Size = new System.Drawing.Size(75, 23);
			this.ReloadINIButton.TabIndex = 3;
			this.ReloadINIButton.Text = "Reload INI";
			this.ReloadINIButton.UseVisualStyleBackColor = true;
			this.ReloadINIButton.Click += new System.EventHandler(this.ReloadINIButtonClick);
			// 
			// RegenINIButton
			// 
			this.RegenINIButton.Enabled = false;
			this.RegenINIButton.Location = new System.Drawing.Point(64, 75);
			this.RegenINIButton.Name = "RegenINIButton";
			this.RegenINIButton.Size = new System.Drawing.Size(75, 23);
			this.RegenINIButton.TabIndex = 4;
			this.RegenINIButton.Text = "Regen INI";
			this.RegenINIButton.UseVisualStyleBackColor = true;
			// 
			// DeleteSectionButton
			// 
			this.DeleteSectionButton.Enabled = false;
			this.DeleteSectionButton.Location = new System.Drawing.Point(331, 324);
			this.DeleteSectionButton.Name = "DeleteSectionButton";
			this.DeleteSectionButton.Size = new System.Drawing.Size(75, 34);
			this.DeleteSectionButton.TabIndex = 2;
			this.DeleteSectionButton.Text = "Delete Section";
			this.DeleteSectionButton.UseVisualStyleBackColor = true;
			// 
			// AddSectionButton
			// 
			this.AddSectionButton.Enabled = false;
			this.AddSectionButton.Location = new System.Drawing.Point(331, 295);
			this.AddSectionButton.Name = "AddSectionButton";
			this.AddSectionButton.Size = new System.Drawing.Size(75, 23);
			this.AddSectionButton.TabIndex = 1;
			this.AddSectionButton.Text = "Add Section";
			this.AddSectionButton.UseVisualStyleBackColor = true;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(346, 22);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(172, 75);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.PictureBox1Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(348, 5);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(103, 14);
			this.label2.TabIndex = 7;
			this.label2.Text = "Courtesy of";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(415, 100);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(103, 23);
			this.label3.TabIndex = 8;
			this.label3.Text = "By TheDeveloper";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.performanceCheatsTabPage4);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage5);
			this.tabControl1.Controls.Add(this.tabPage6);
			this.tabControl1.Location = new System.Drawing.Point(12, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(551, 390);
			this.tabControl1.TabIndex = 9;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.ValueEnabledCheckbox);
			this.tabPage1.Controls.Add(this.label15);
			this.tabPage1.Controls.Add(this.ResetValueButton);
			this.tabPage1.Controls.Add(this.ValEditLowerBoundsTextbox);
			this.tabPage1.Controls.Add(this.ValEditNameTextbox);
			this.tabPage1.Controls.Add(this.BackupSectionButton);
			this.tabPage1.Controls.Add(this.ValEditUpperBoundsTextbox);
			this.tabPage1.Controls.Add(this.ValEditValueTextbox);
			this.tabPage1.Controls.Add(this.label8);
			this.tabPage1.Controls.Add(this.ValueEditorTree);
			this.tabPage1.Controls.Add(this.label16);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.pictureBox1);
			this.tabPage1.Controls.Add(this.DeleteValueButton);
			this.tabPage1.Controls.Add(this.AddValueButton);
			this.tabPage1.Controls.Add(this.DeleteSectionButton);
			this.tabPage1.Controls.Add(this.AddSectionButton);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(543, 364);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Value Editor";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// ValueEnabledCheckbox
			// 
			this.ValueEnabledCheckbox.Location = new System.Drawing.Point(408, 227);
			this.ValueEnabledCheckbox.Name = "ValueEnabledCheckbox";
			this.ValueEnabledCheckbox.Size = new System.Drawing.Size(97, 15);
			this.ValueEnabledCheckbox.TabIndex = 17;
			this.ValueEnabledCheckbox.UseVisualStyleBackColor = true;
			this.ValueEnabledCheckbox.CheckedChanged += new System.EventHandler(this.ValueEnabledCheckboxCheckedChanged);
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(328, 227);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(78, 22);
			this.label15.TabIndex = 19;
			this.label15.Text = "Enabled in INI:";
			// 
			// ResetValueButton
			// 
			this.ResetValueButton.Enabled = false;
			this.ResetValueButton.Location = new System.Drawing.Point(463, 250);
			this.ResetValueButton.Name = "ResetValueButton";
			this.ResetValueButton.Size = new System.Drawing.Size(75, 40);
			this.ResetValueButton.TabIndex = 18;
			this.ResetValueButton.Text = "Reset Value to Original";
			this.ResetValueButton.UseVisualStyleBackColor = true;
			// 
			// ValEditLowerBoundsTextbox
			// 
			this.ValEditLowerBoundsTextbox.Enabled = false;
			this.ValEditLowerBoundsTextbox.Location = new System.Drawing.Point(408, 175);
			this.ValEditLowerBoundsTextbox.Name = "ValEditLowerBoundsTextbox";
			this.ValEditLowerBoundsTextbox.Size = new System.Drawing.Size(107, 20);
			this.ValEditLowerBoundsTextbox.TabIndex = 16;
			// 
			// ValEditNameTextbox
			// 
			this.ValEditNameTextbox.Location = new System.Drawing.Point(408, 126);
			this.ValEditNameTextbox.Name = "ValEditNameTextbox";
			this.ValEditNameTextbox.Size = new System.Drawing.Size(107, 20);
			this.ValEditNameTextbox.TabIndex = 16;
			this.ValEditNameTextbox.TextChanged += new System.EventHandler(this.ValEditNameTextboxTextChanged);
			// 
			// BackupSectionButton
			// 
			this.BackupSectionButton.Enabled = false;
			this.BackupSectionButton.Location = new System.Drawing.Point(331, 252);
			this.BackupSectionButton.Name = "BackupSectionButton";
			this.BackupSectionButton.Size = new System.Drawing.Size(75, 37);
			this.BackupSectionButton.TabIndex = 2;
			this.BackupSectionButton.Text = "Backup Section";
			this.BackupSectionButton.UseVisualStyleBackColor = true;
			// 
			// ValEditUpperBoundsTextbox
			// 
			this.ValEditUpperBoundsTextbox.Enabled = false;
			this.ValEditUpperBoundsTextbox.Location = new System.Drawing.Point(408, 201);
			this.ValEditUpperBoundsTextbox.Name = "ValEditUpperBoundsTextbox";
			this.ValEditUpperBoundsTextbox.Size = new System.Drawing.Size(107, 20);
			this.ValEditUpperBoundsTextbox.TabIndex = 16;
			// 
			// ValEditValueTextbox
			// 
			this.ValEditValueTextbox.Location = new System.Drawing.Point(408, 152);
			this.ValEditValueTextbox.Name = "ValEditValueTextbox";
			this.ValEditValueTextbox.Size = new System.Drawing.Size(107, 20);
			this.ValEditValueTextbox.TabIndex = 16;
			this.ValEditValueTextbox.TextChanged += new System.EventHandler(this.ValEditValueTextboxTextChanged);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(327, 129);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(75, 23);
			this.label8.TabIndex = 14;
			this.label8.Text = "Name";
			// 
			// ValueEditorTree
			// 
			this.ValueEditorTree.Location = new System.Drawing.Point(6, 6);
			this.ValueEditorTree.Name = "ValueEditorTree";
			this.ValueEditorTree.Size = new System.Drawing.Size(319, 352);
			this.ValueEditorTree.TabIndex = 15;
			this.ValueEditorTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ValueEditorTreeAfterSelect);
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(328, 204);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(75, 23);
			this.label16.TabIndex = 14;
			this.label16.Text = "Upper Bounds";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(328, 178);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(75, 23);
			this.label5.TabIndex = 14;
			this.label5.Text = "Lower Bounds";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(327, 155);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(75, 23);
			this.label1.TabIndex = 14;
			this.label1.Text = "Value";
			this.label1.Click += new System.EventHandler(this.Label1Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(506, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(33, 14);
			this.label4.TabIndex = 9;
			this.label4.Text = ".com";
			// 
			// DeleteValueButton
			// 
			this.DeleteValueButton.Enabled = false;
			this.DeleteValueButton.Location = new System.Drawing.Point(462, 324);
			this.DeleteValueButton.Name = "DeleteValueButton";
			this.DeleteValueButton.Size = new System.Drawing.Size(75, 34);
			this.DeleteValueButton.TabIndex = 2;
			this.DeleteValueButton.Text = "Delete Value";
			this.DeleteValueButton.UseVisualStyleBackColor = true;
			// 
			// AddValueButton
			// 
			this.AddValueButton.Enabled = false;
			this.AddValueButton.Location = new System.Drawing.Point(462, 295);
			this.AddValueButton.Name = "AddValueButton";
			this.AddValueButton.Size = new System.Drawing.Size(75, 23);
			this.AddValueButton.TabIndex = 1;
			this.AddValueButton.Text = "Add Value";
			this.AddValueButton.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.RawINITextBox);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(543, 364);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Raw INI";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// RawINITextBox
			// 
			this.RawINITextBox.Location = new System.Drawing.Point(6, 6);
			this.RawINITextBox.Name = "RawINITextBox";
			this.RawINITextBox.Size = new System.Drawing.Size(531, 352);
			this.RawINITextBox.TabIndex = 0;
			this.RawINITextBox.Text = "";
			this.RawINITextBox.TextChanged += new System.EventHandler(this.RawINITextBoxTextChanged);
			// 
			// performanceCheatsTabPage4
			// 
			this.performanceCheatsTabPage4.Controls.Add(this.panel5);
			this.performanceCheatsTabPage4.Controls.Add(this.panel4);
			this.performanceCheatsTabPage4.Controls.Add(this.label14);
			this.performanceCheatsTabPage4.Controls.Add(this.label13);
			this.performanceCheatsTabPage4.Controls.Add(this.label12);
			this.performanceCheatsTabPage4.Controls.Add(this.SetUltraGpuSettingsButton);
			this.performanceCheatsTabPage4.Controls.Add(this.SetHighCPUSoundButton);
			this.performanceCheatsTabPage4.Controls.Add(this.SetLowCPUSoundButton);
			this.performanceCheatsTabPage4.Controls.Add(this.SetLowCPUGraphicsSettingsButton);
			this.performanceCheatsTabPage4.Controls.Add(this.SetUltraCPUGrapgicalSettingsButton);
			this.performanceCheatsTabPage4.Location = new System.Drawing.Point(4, 22);
			this.performanceCheatsTabPage4.Name = "performanceCheatsTabPage4";
			this.performanceCheatsTabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.performanceCheatsTabPage4.Size = new System.Drawing.Size(543, 364);
			this.performanceCheatsTabPage4.TabIndex = 3;
			this.performanceCheatsTabPage4.Text = "Performance Cheats";
			this.performanceCheatsTabPage4.UseVisualStyleBackColor = true;
			// 
			// panel5
			// 
			this.panel5.BackColor = System.Drawing.Color.LightGray;
			this.panel5.Controls.Add(this.SetTDRecommendedHighButton);
			this.panel5.Controls.Add(this.SetTDRecommendedUltraButton);
			this.panel5.Location = new System.Drawing.Point(6, 6);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(281, 64);
			this.panel5.TabIndex = 5;
			// 
			// SetTDRecommendedHighButton
			// 
			this.SetTDRecommendedHighButton.Location = new System.Drawing.Point(15, 9);
			this.SetTDRecommendedHighButton.Name = "SetTDRecommendedHighButton";
			this.SetTDRecommendedHighButton.Size = new System.Drawing.Size(123, 47);
			this.SetTDRecommendedHighButton.TabIndex = 0;
			this.SetTDRecommendedHighButton.Text = "TheDevelopers recommended high settings";
			this.SetTDRecommendedHighButton.UseVisualStyleBackColor = true;
			this.SetTDRecommendedHighButton.Click += new System.EventHandler(this.SetTDRecommendedHighButtonClick);
			// 
			// SetTDRecommendedUltraButton
			// 
			this.SetTDRecommendedUltraButton.Location = new System.Drawing.Point(144, 9);
			this.SetTDRecommendedUltraButton.Name = "SetTDRecommendedUltraButton";
			this.SetTDRecommendedUltraButton.Size = new System.Drawing.Size(123, 47);
			this.SetTDRecommendedUltraButton.TabIndex = 0;
			this.SetTDRecommendedUltraButton.Text = "TheDevelopers recommended \'Ultra\' settings";
			this.SetTDRecommendedUltraButton.UseVisualStyleBackColor = true;
			this.SetTDRecommendedUltraButton.Click += new System.EventHandler(this.SetTDRecommendedUltraButtonClick);
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.Color.LightGray;
			this.panel4.Controls.Add(this.FSAATextBox);
			this.panel4.Controls.Add(this.label24);
			this.panel4.Controls.Add(this.RenderQualityTextBox);
			this.panel4.Controls.Add(this.label23);
			this.panel4.Controls.Add(this.label22);
			this.panel4.Controls.Add(this.RenderQualityTrackbar);
			this.panel4.Controls.Add(this.label20);
			this.panel4.Location = new System.Drawing.Point(343, 3);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(197, 231);
			this.panel4.TabIndex = 4;
			// 
			// FSAATextBox
			// 
			this.FSAATextBox.Location = new System.Drawing.Point(81, 202);
			this.FSAATextBox.Name = "FSAATextBox";
			this.FSAATextBox.Size = new System.Drawing.Size(100, 20);
			this.FSAATextBox.TabIndex = 6;
			this.FSAATextBox.Text = "1.0";
			this.FSAATextBox.TextChanged += new System.EventHandler(this.FSAATextBoxTextChanged);
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(3, 199);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(100, 23);
			this.label24.TabIndex = 7;
			this.label24.Text = "FSAA:";
			// 
			// RenderQualityTextBox
			// 
			this.RenderQualityTextBox.Location = new System.Drawing.Point(81, 173);
			this.RenderQualityTextBox.Name = "RenderQualityTextBox";
			this.RenderQualityTextBox.Size = new System.Drawing.Size(100, 20);
			this.RenderQualityTextBox.TabIndex = 6;
			this.RenderQualityTextBox.Text = "1.0";
			this.RenderQualityTextBox.TextChanged += new System.EventHandler(this.RenderQualityTextBoxTextChanged);
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(3, 176);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(100, 23);
			this.label23.TabIndex = 5;
			this.label23.Text = "Current R.Q.:";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(3, 56);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(197, 82);
			this.label22.TabIndex = 4;
			this.label22.Text = resources.GetString("label22.Text");
			// 
			// RenderQualityTrackbar
			// 
			this.RenderQualityTrackbar.Location = new System.Drawing.Point(0, 148);
			this.RenderQualityTrackbar.Maximum = 20;
			this.RenderQualityTrackbar.Minimum = 3;
			this.RenderQualityTrackbar.Name = "RenderQualityTrackbar";
			this.RenderQualityTrackbar.Size = new System.Drawing.Size(197, 45);
			this.RenderQualityTrackbar.TabIndex = 2;
			this.RenderQualityTrackbar.Value = 3;
			this.RenderQualityTrackbar.Scroll += new System.EventHandler(this.RenderQualityTrackbarScroll);
			// 
			// label20
			// 
			this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label20.Location = new System.Drawing.Point(3, 0);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(197, 54);
			this.label20.TabIndex = 3;
			this.label20.Text = "RenderQuality Slider:";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(135, 88);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(189, 34);
			this.label14.TabIndex = 1;
			this.label14.Text = "Sets all GPU dependant options to \'Ultra\' (4)";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(135, 128);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(189, 31);
			this.label13.TabIndex = 1;
			this.label13.Text = "Sets CPU dependant graphics options to ultra, currently only shadows";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(135, 179);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(156, 31);
			this.label12.TabIndex = 1;
			this.label12.Text = "Turns Shadows Off";
			// 
			// SetUltraGpuSettingsButton
			// 
			this.SetUltraGpuSettingsButton.Location = new System.Drawing.Point(6, 88);
			this.SetUltraGpuSettingsButton.Name = "SetUltraGpuSettingsButton";
			this.SetUltraGpuSettingsButton.Size = new System.Drawing.Size(123, 34);
			this.SetUltraGpuSettingsButton.TabIndex = 0;
			this.SetUltraGpuSettingsButton.Text = "I have an \'Ultra\' Capable Video Card!";
			this.SetUltraGpuSettingsButton.UseVisualStyleBackColor = true;
			this.SetUltraGpuSettingsButton.Click += new System.EventHandler(this.SetUltraGpuSettingsButtonClick);
			// 
			// SetHighCPUSoundButton
			// 
			this.SetHighCPUSoundButton.Location = new System.Drawing.Point(6, 248);
			this.SetHighCPUSoundButton.Name = "SetHighCPUSoundButton";
			this.SetHighCPUSoundButton.Size = new System.Drawing.Size(123, 34);
			this.SetHighCPUSoundButton.TabIndex = 0;
			this.SetHighCPUSoundButton.Text = "Set High CPU Sound";
			this.SetHighCPUSoundButton.UseVisualStyleBackColor = true;
			this.SetHighCPUSoundButton.Click += new System.EventHandler(this.SetHighCPUSoundButtonClick);
			// 
			// SetLowCPUSoundButton
			// 
			this.SetLowCPUSoundButton.Location = new System.Drawing.Point(6, 208);
			this.SetLowCPUSoundButton.Name = "SetLowCPUSoundButton";
			this.SetLowCPUSoundButton.Size = new System.Drawing.Size(123, 34);
			this.SetLowCPUSoundButton.TabIndex = 0;
			this.SetLowCPUSoundButton.Text = "Set Low CPU Sound";
			this.SetLowCPUSoundButton.UseVisualStyleBackColor = true;
			this.SetLowCPUSoundButton.Click += new System.EventHandler(this.SetLowCPUSoundButtonClick);
			// 
			// SetLowCPUGraphicsSettingsButton
			// 
			this.SetLowCPUGraphicsSettingsButton.Location = new System.Drawing.Point(6, 168);
			this.SetLowCPUGraphicsSettingsButton.Name = "SetLowCPUGraphicsSettingsButton";
			this.SetLowCPUGraphicsSettingsButton.Size = new System.Drawing.Size(123, 34);
			this.SetLowCPUGraphicsSettingsButton.TabIndex = 0;
			this.SetLowCPUGraphicsSettingsButton.Text = "I have a Slow CPU, so I hate shadows.";
			this.SetLowCPUGraphicsSettingsButton.UseVisualStyleBackColor = true;
			this.SetLowCPUGraphicsSettingsButton.Click += new System.EventHandler(this.SetLowCPUGraphicsSettingsButtonClick);
			// 
			// SetUltraCPUGrapgicalSettingsButton
			// 
			this.SetUltraCPUGrapgicalSettingsButton.Location = new System.Drawing.Point(6, 128);
			this.SetUltraCPUGrapgicalSettingsButton.Name = "SetUltraCPUGrapgicalSettingsButton";
			this.SetUltraCPUGrapgicalSettingsButton.Size = new System.Drawing.Size(123, 34);
			this.SetUltraCPUGrapgicalSettingsButton.TabIndex = 0;
			this.SetUltraCPUGrapgicalSettingsButton.Text = "I have an \'Ultra\' Capable CPU!!";
			this.SetUltraCPUGrapgicalSettingsButton.UseVisualStyleBackColor = true;
			this.SetUltraCPUGrapgicalSettingsButton.Click += new System.EventHandler(this.SetCPUGraphicsSettingButtonClick);
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.button11);
			this.tabPage3.Controls.Add(this.vScrollBar3);
			this.tabPage3.Controls.Add(this.button7);
			this.tabPage3.Controls.Add(this.textBox2);
			this.tabPage3.Controls.Add(this.label7);
			this.tabPage3.Controls.Add(this.richTextBox2);
			this.tabPage3.Controls.Add(this.panel2);
			this.tabPage3.Enabled = false;
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(543, 364);
			this.tabPage3.TabIndex = 4;
			this.tabPage3.Text = "Backup Manager";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(282, 321);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(93, 23);
			this.button11.TabIndex = 20;
			this.button11.Text = "Restore Backup";
			this.button11.UseVisualStyleBackColor = true;
			// 
			// vScrollBar3
			// 
			this.vScrollBar3.Location = new System.Drawing.Point(520, 32);
			this.vScrollBar3.Name = "vScrollBar3";
			this.vScrollBar3.Size = new System.Drawing.Size(17, 283);
			this.vScrollBar3.TabIndex = 19;
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(476, 4);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(61, 23);
			this.button7.TabIndex = 18;
			this.button7.Text = "Delete";
			this.button7.UseVisualStyleBackColor = true;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(318, 6);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(144, 20);
			this.textBox2.TabIndex = 16;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(282, 9);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(38, 17);
			this.label7.TabIndex = 15;
			this.label7.Text = "Name:";
			// 
			// richTextBox2
			// 
			this.richTextBox2.Location = new System.Drawing.Point(282, 32);
			this.richTextBox2.Name = "richTextBox2";
			this.richTextBox2.Size = new System.Drawing.Size(255, 283);
			this.richTextBox2.TabIndex = 14;
			this.richTextBox2.Text = "";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.hScrollBar2);
			this.panel2.Controls.Add(this.vScrollBar2);
			this.panel2.Location = new System.Drawing.Point(6, 6);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(256, 355);
			this.panel2.TabIndex = 13;
			// 
			// hScrollBar2
			// 
			this.hScrollBar2.Location = new System.Drawing.Point(17, 338);
			this.hScrollBar2.Name = "hScrollBar2";
			this.hScrollBar2.Size = new System.Drawing.Size(239, 17);
			this.hScrollBar2.TabIndex = 2;
			// 
			// vScrollBar2
			// 
			this.vScrollBar2.Location = new System.Drawing.Point(0, 0);
			this.vScrollBar2.Name = "vScrollBar2";
			this.vScrollBar2.Size = new System.Drawing.Size(17, 338);
			this.vScrollBar2.TabIndex = 1;
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.panel3);
			this.tabPage5.Controls.Add(this.panel1);
			this.tabPage5.Controls.Add(this.ValueCatalogueBrowseButton);
			this.tabPage5.Controls.Add(this.BackupLocationBrowseButton);
			this.tabPage5.Controls.Add(this.ValueCatalogueLcationTextbox);
			this.tabPage5.Controls.Add(this.UserOptionsINIBrowseButton);
			this.tabPage5.Controls.Add(this.label11);
			this.tabPage5.Controls.Add(this.BackupLocationTextbox);
			this.tabPage5.Controls.Add(this.label10);
			this.tabPage5.Controls.Add(this.UseroptionsLocationTextbox);
			this.tabPage5.Controls.Add(this.label9);
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage5.Size = new System.Drawing.Size(543, 364);
			this.tabPage5.TabIndex = 5;
			this.tabPage5.Text = "Config";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.Gainsboro;
			this.panel3.Controls.Add(this.label17);
			this.panel3.Controls.Add(this.ReadOnlyCheckbox);
			this.panel3.Controls.Add(this.label21);
			this.panel3.Location = new System.Drawing.Point(287, 96);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(200, 237);
			this.panel3.TabIndex = 27;
			// 
			// label17
			// 
			this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label17.Location = new System.Drawing.Point(36, 4);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(139, 27);
			this.label17.TabIndex = 22;
			this.label17.Text = "Compatability";
			// 
			// ReadOnlyCheckbox
			// 
			this.ReadOnlyCheckbox.Location = new System.Drawing.Point(180, 42);
			this.ReadOnlyCheckbox.Name = "ReadOnlyCheckbox";
			this.ReadOnlyCheckbox.Size = new System.Drawing.Size(17, 15);
			this.ReadOnlyCheckbox.TabIndex = 20;
			this.ReadOnlyCheckbox.UseVisualStyleBackColor = true;
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(3, 42);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(172, 38);
			this.label21.TabIndex = 21;
			this.label21.Text = "Set to READ ONLY after saving:";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Gainsboro;
			this.panel1.Controls.Add(this.label19);
			this.panel1.Controls.Add(this.label18);
			this.panel1.Controls.Add(this.KeepBackupsCheckbox);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.IncrimentalBackupsToKeepTextbox);
			this.panel1.Controls.Add(this.RegenINIButton);
			this.panel1.Controls.Add(this.DeleteINIButton);
			this.panel1.Location = new System.Drawing.Point(48, 96);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(200, 237);
			this.panel1.TabIndex = 22;
			// 
			// label19
			// 
			this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label19.Location = new System.Drawing.Point(27, 4);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(148, 23);
			this.label19.TabIndex = 27;
			this.label19.Text = "INI Operations";
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(0, 125);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(146, 19);
			this.label18.TabIndex = 26;
			this.label18.Text = "Keep INI backups?";
			this.label18.Click += new System.EventHandler(this.Label18Click);
			// 
			// KeepBackupsCheckbox
			// 
			this.KeepBackupsCheckbox.Checked = true;
			this.KeepBackupsCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.KeepBackupsCheckbox.Location = new System.Drawing.Point(177, 125);
			this.KeepBackupsCheckbox.Name = "KeepBackupsCheckbox";
			this.KeepBackupsCheckbox.Size = new System.Drawing.Size(17, 15);
			this.KeepBackupsCheckbox.TabIndex = 25;
			this.KeepBackupsCheckbox.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(0, 144);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(146, 19);
			this.label6.TabIndex = 24;
			this.label6.Text = "Incrimental Backups to Keep:";
			// 
			// IncrimentalBackupsToKeepTextbox
			// 
			this.IncrimentalBackupsToKeepTextbox.Location = new System.Drawing.Point(158, 141);
			this.IncrimentalBackupsToKeepTextbox.Name = "IncrimentalBackupsToKeepTextbox";
			this.IncrimentalBackupsToKeepTextbox.Size = new System.Drawing.Size(36, 20);
			this.IncrimentalBackupsToKeepTextbox.TabIndex = 23;
			this.IncrimentalBackupsToKeepTextbox.Text = "10";
			// 
			// ValueCatalogueBrowseButton
			// 
			this.ValueCatalogueBrowseButton.Location = new System.Drawing.Point(483, 59);
			this.ValueCatalogueBrowseButton.Name = "ValueCatalogueBrowseButton";
			this.ValueCatalogueBrowseButton.Size = new System.Drawing.Size(54, 23);
			this.ValueCatalogueBrowseButton.TabIndex = 2;
			this.ValueCatalogueBrowseButton.Text = "Browse";
			this.ValueCatalogueBrowseButton.UseVisualStyleBackColor = true;
			this.ValueCatalogueBrowseButton.Click += new System.EventHandler(this.ValueCatalogueBrowseButtonClick);
			// 
			// BackupLocationBrowseButton
			// 
			this.BackupLocationBrowseButton.Location = new System.Drawing.Point(483, 30);
			this.BackupLocationBrowseButton.Name = "BackupLocationBrowseButton";
			this.BackupLocationBrowseButton.Size = new System.Drawing.Size(54, 23);
			this.BackupLocationBrowseButton.TabIndex = 2;
			this.BackupLocationBrowseButton.Text = "Browse";
			this.BackupLocationBrowseButton.UseVisualStyleBackColor = true;
			this.BackupLocationBrowseButton.Click += new System.EventHandler(this.BackupLocationBrowseButtonClick);
			// 
			// ValueCatalogueLcationTextbox
			// 
			this.ValueCatalogueLcationTextbox.Location = new System.Drawing.Point(138, 58);
			this.ValueCatalogueLcationTextbox.Name = "ValueCatalogueLcationTextbox";
			this.ValueCatalogueLcationTextbox.Size = new System.Drawing.Size(339, 20);
			this.ValueCatalogueLcationTextbox.TabIndex = 1;
			// 
			// UserOptionsINIBrowseButton
			// 
			this.UserOptionsINIBrowseButton.Location = new System.Drawing.Point(483, 1);
			this.UserOptionsINIBrowseButton.Name = "UserOptionsINIBrowseButton";
			this.UserOptionsINIBrowseButton.Size = new System.Drawing.Size(54, 23);
			this.UserOptionsINIBrowseButton.TabIndex = 2;
			this.UserOptionsINIBrowseButton.Text = "Browse";
			this.UserOptionsINIBrowseButton.UseVisualStyleBackColor = true;
			this.UserOptionsINIBrowseButton.Click += new System.EventHandler(this.UserOptionsINIBrowseButtonClick);
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(6, 58);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(132, 24);
			this.label11.TabIndex = 0;
			this.label11.Text = "Value Catalogue Location:";
			// 
			// BackupLocationTextbox
			// 
			this.BackupLocationTextbox.Location = new System.Drawing.Point(138, 29);
			this.BackupLocationTextbox.Name = "BackupLocationTextbox";
			this.BackupLocationTextbox.Size = new System.Drawing.Size(339, 20);
			this.BackupLocationTextbox.TabIndex = 1;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(6, 29);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(126, 23);
			this.label10.TabIndex = 0;
			this.label10.Text = "Backup Location:";
			// 
			// UseroptionsLocationTextbox
			// 
			this.UseroptionsLocationTextbox.Location = new System.Drawing.Point(138, 3);
			this.UseroptionsLocationTextbox.Name = "UseroptionsLocationTextbox";
			this.UseroptionsLocationTextbox.Size = new System.Drawing.Size(339, 20);
			this.UseroptionsLocationTextbox.TabIndex = 1;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(6, 3);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(126, 23);
			this.label9.TabIndex = 0;
			this.label9.Text = "UserOptions.ini Location:";
			// 
			// tabPage6
			// 
			this.tabPage6.Controls.Add(this.button2);
			this.tabPage6.Location = new System.Drawing.Point(4, 22);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage6.Size = new System.Drawing.Size(543, 364);
			this.tabPage6.TabIndex = 6;
			this.tabPage6.Text = "Controls";
			this.tabPage6.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(6, 6);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(115, 23);
			this.button2.TabIndex = 0;
			this.button2.Text = "Backup KeyBindings";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// BackupINIButton
			// 
			this.BackupINIButton.Location = new System.Drawing.Point(484, 408);
			this.BackupINIButton.Name = "BackupINIButton";
			this.BackupINIButton.Size = new System.Drawing.Size(75, 23);
			this.BackupINIButton.TabIndex = 2;
			this.BackupINIButton.Text = "Backup INI";
			this.BackupINIButton.UseVisualStyleBackColor = true;
			this.BackupINIButton.Click += new System.EventHandler(this.BackupINIButtonClick);
			// 
			// VersionStringLabel1
			// 
			this.VersionStringLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.VersionStringLabel1.Location = new System.Drawing.Point(470, 18);
			this.VersionStringLabel1.Name = "VersionStringLabel1";
			this.VersionStringLabel1.Size = new System.Drawing.Size(100, 13);
			this.VersionStringLabel1.TabIndex = 10;
			this.VersionStringLabel1.Text = "4.0.0.0";
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(12, 413);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(258, 23);
			this.label25.TabIndex = 11;
			this.label25.Text = "Not affiliated with Sony or SOE, use at your own risk.";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(575, 437);
			this.Controls.Add(this.label25);
			this.Controls.Add(this.VersionStringLabel1);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.ReloadINIButton);
			this.Controls.Add(this.BackupINIButton);
			this.Controls.Add(this.SaveINIButton);
			this.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "PlanetSide 2 Useroptions Editor";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.performanceCheatsTabPage4.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.RenderQualityTrackbar)).EndInit();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.tabPage5.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tabPage6.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button SetTDRecommendedUltraButton;
		private System.Windows.Forms.Button SetTDRecommendedHighButton;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.TextBox FSAATextBox;
		private System.Windows.Forms.Label VersionStringLabel1;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TextBox RenderQualityTextBox;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.TrackBar RenderQualityTrackbar;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.CheckBox ReadOnlyCheckbox;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.CheckBox KeepBackupsCheckbox;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox ValEditUpperBoundsTextbox;
		private System.Windows.Forms.TextBox ValEditLowerBoundsTextbox;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button SetHighCPUSoundButton;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Button SetLowCPUSoundButton;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TabPage tabPage6;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox ValueCatalogueLcationTextbox;
		private System.Windows.Forms.Button ValueCatalogueBrowseButton;
		private System.Windows.Forms.VScrollBar vScrollBar3;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Button BackupSectionButton;
		private System.Windows.Forms.Button UserOptionsINIBrowseButton;
		private System.Windows.Forms.Button BackupLocationBrowseButton;
		private System.Windows.Forms.Button ResetValueButton;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox UseroptionsLocationTextbox;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox BackupLocationTextbox;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.Button SetLowCPUGraphicsSettingsButton;
		private System.Windows.Forms.Button SetUltraGpuSettingsButton;
		private System.Windows.Forms.Button SetUltraCPUGrapgicalSettingsButton;
		private System.Windows.Forms.TreeView ValueEditorTree;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox ValEditValueTextbox;
		private System.Windows.Forms.TextBox ValEditNameTextbox;
		private System.Windows.Forms.CheckBox ValueEnabledCheckbox;
		private System.Windows.Forms.Button BackupINIButton;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox IncrimentalBackupsToKeepTextbox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.VScrollBar vScrollBar2;
		private System.Windows.Forms.HScrollBar hScrollBar2;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.RichTextBox richTextBox2;
		private System.Windows.Forms.TabPage performanceCheatsTabPage4;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.RichTextBox RawINITextBox;
		private System.Windows.Forms.Button AddValueButton;
		private System.Windows.Forms.Button DeleteValueButton;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button AddSectionButton;
		private System.Windows.Forms.Button DeleteSectionButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button RegenINIButton;
		private System.Windows.Forms.Button ReloadINIButton;
		private System.Windows.Forms.Button SaveINIButton;
		private System.Windows.Forms.Button DeleteINIButton;
		
		
		
		

		
		
		
		
	}
	

}