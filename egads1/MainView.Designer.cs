namespace egads1
{
    partial class MainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.icMain = new TIS.Imaging.ICImagingControl();
            this.icSide = new TIS.Imaging.ICImagingControl();
            this.pbMain = new System.Windows.Forms.PictureBox();
            this.pbSide = new System.Windows.Forms.PictureBox();
            this.tcTabControl = new System.Windows.Forms.TabControl();
            this.tpConfigPage = new System.Windows.Forms.TabPage();
            this.gbCamSettings = new System.Windows.Forms.GroupBox();
            this.btTriggerToggle = new System.Windows.Forms.Button();
            this.btConnectCamSide = new System.Windows.Forms.Button();
            this.btCamSettingsSide = new System.Windows.Forms.Button();
            this.btConnectCamTop = new System.Windows.Forms.Button();
            this.btCamSettingsTop = new System.Windows.Forms.Button();
            this.tpRunPage = new System.Windows.Forms.TabPage();
            this.gbRecord = new System.Windows.Forms.GroupBox();
            this.lbRecordFilename = new System.Windows.Forms.Label();
            this.btRecordStop = new System.Windows.Forms.Button();
            this.btRecordStart = new System.Windows.Forms.Button();
            this.tbRecordFilename = new System.Windows.Forms.TextBox();
            this.gbCalibrationCreate = new System.Windows.Forms.GroupBox();
            this.button8 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btCalibrationA = new System.Windows.Forms.Button();
            this.gbCalibrationLoad = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.icMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icSide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSide)).BeginInit();
            this.tcTabControl.SuspendLayout();
            this.tpConfigPage.SuspendLayout();
            this.gbCamSettings.SuspendLayout();
            this.tpRunPage.SuspendLayout();
            this.gbRecord.SuspendLayout();
            this.gbCalibrationCreate.SuspendLayout();
            this.gbCalibrationLoad.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbOutput
            // 
            this.tbOutput.Location = new System.Drawing.Point(13, 13);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ReadOnly = true;
            this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbOutput.Size = new System.Drawing.Size(485, 80);
            this.tbOutput.TabIndex = 0;
            // 
            // icMain
            // 
            this.icMain.BackColor = System.Drawing.Color.White;
            this.icMain.DeviceListChangedExecutionMode = TIS.Imaging.EventExecutionMode.Invoke;
            this.icMain.DeviceLostExecutionMode = TIS.Imaging.EventExecutionMode.AsyncInvoke;
            this.icMain.ImageAvailableExecutionMode = TIS.Imaging.EventExecutionMode.MultiThreaded;
            this.icMain.LiveDisplayPosition = new System.Drawing.Point(0, 0);
            this.icMain.Location = new System.Drawing.Point(12, 99);
            this.icMain.Name = "icMain";
            this.icMain.Size = new System.Drawing.Size(240, 180);
            this.icMain.TabIndex = 1;
            this.icMain.ImageAvailable += new System.EventHandler<TIS.Imaging.ICImagingControl.ImageAvailableEventArgs>(this.icMain_ImageAvailable);
            // 
            // icSide
            // 
            this.icSide.BackColor = System.Drawing.Color.White;
            this.icSide.DeviceListChangedExecutionMode = TIS.Imaging.EventExecutionMode.Invoke;
            this.icSide.DeviceLostExecutionMode = TIS.Imaging.EventExecutionMode.AsyncInvoke;
            this.icSide.ImageAvailableExecutionMode = TIS.Imaging.EventExecutionMode.MultiThreaded;
            this.icSide.LiveDisplayPosition = new System.Drawing.Point(0, 0);
            this.icSide.Location = new System.Drawing.Point(258, 99);
            this.icSide.Name = "icSide";
            this.icSide.Size = new System.Drawing.Size(240, 180);
            this.icSide.TabIndex = 2;
            this.icSide.ImageAvailable += new System.EventHandler<TIS.Imaging.ICImagingControl.ImageAvailableEventArgs>(this.icSide_ImageAvailable);
            // 
            // pbMain
            // 
            this.pbMain.Location = new System.Drawing.Point(12, 285);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(240, 180);
            this.pbMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMain.TabIndex = 3;
            this.pbMain.TabStop = false;
            // 
            // pbSide
            // 
            this.pbSide.Location = new System.Drawing.Point(258, 285);
            this.pbSide.Name = "pbSide";
            this.pbSide.Size = new System.Drawing.Size(240, 180);
            this.pbSide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSide.TabIndex = 4;
            this.pbSide.TabStop = false;
            // 
            // tcTabControl
            // 
            this.tcTabControl.Controls.Add(this.tpConfigPage);
            this.tcTabControl.Controls.Add(this.tpRunPage);
            this.tcTabControl.Location = new System.Drawing.Point(505, 13);
            this.tcTabControl.Name = "tcTabControl";
            this.tcTabControl.SelectedIndex = 0;
            this.tcTabControl.Size = new System.Drawing.Size(441, 452);
            this.tcTabControl.TabIndex = 5;
            // 
            // tpConfigPage
            // 
            this.tpConfigPage.Controls.Add(this.gbCalibrationLoad);
            this.tpConfigPage.Controls.Add(this.gbCalibrationCreate);
            this.tpConfigPage.Controls.Add(this.gbCamSettings);
            this.tpConfigPage.Location = new System.Drawing.Point(4, 22);
            this.tpConfigPage.Name = "tpConfigPage";
            this.tpConfigPage.Padding = new System.Windows.Forms.Padding(3);
            this.tpConfigPage.Size = new System.Drawing.Size(433, 426);
            this.tpConfigPage.TabIndex = 0;
            this.tpConfigPage.Text = "Config";
            this.tpConfigPage.UseVisualStyleBackColor = true;
            // 
            // gbCamSettings
            // 
            this.gbCamSettings.Controls.Add(this.btTriggerToggle);
            this.gbCamSettings.Controls.Add(this.btConnectCamSide);
            this.gbCamSettings.Controls.Add(this.btCamSettingsSide);
            this.gbCamSettings.Controls.Add(this.btConnectCamTop);
            this.gbCamSettings.Controls.Add(this.btCamSettingsTop);
            this.gbCamSettings.Location = new System.Drawing.Point(6, 6);
            this.gbCamSettings.Name = "gbCamSettings";
            this.gbCamSettings.Size = new System.Drawing.Size(143, 169);
            this.gbCamSettings.TabIndex = 32;
            this.gbCamSettings.TabStop = false;
            this.gbCamSettings.Text = "Camera Settings";
            // 
            // btTriggerToggle
            // 
            this.btTriggerToggle.Location = new System.Drawing.Point(6, 135);
            this.btTriggerToggle.Name = "btTriggerToggle";
            this.btTriggerToggle.Size = new System.Drawing.Size(131, 23);
            this.btTriggerToggle.TabIndex = 13;
            this.btTriggerToggle.Text = "Trigger/Live Mode";
            this.btTriggerToggle.UseVisualStyleBackColor = true;
            this.btTriggerToggle.Click += new System.EventHandler(this.btTriggerToggle_Click);
            // 
            // btConnectCamSide
            // 
            this.btConnectCamSide.Location = new System.Drawing.Point(6, 77);
            this.btConnectCamSide.Name = "btConnectCamSide";
            this.btConnectCamSide.Size = new System.Drawing.Size(131, 23);
            this.btConnectCamSide.TabIndex = 11;
            this.btConnectCamSide.Text = "Connect to Side Camera";
            this.btConnectCamSide.UseVisualStyleBackColor = true;
            this.btConnectCamSide.Click += new System.EventHandler(this.btConnectCamSide_Click);
            // 
            // btCamSettingsSide
            // 
            this.btCamSettingsSide.Location = new System.Drawing.Point(6, 106);
            this.btCamSettingsSide.Name = "btCamSettingsSide";
            this.btCamSettingsSide.Size = new System.Drawing.Size(131, 23);
            this.btCamSettingsSide.TabIndex = 12;
            this.btCamSettingsSide.Text = "Side Camera Settings";
            this.btCamSettingsSide.UseVisualStyleBackColor = true;
            this.btCamSettingsSide.Click += new System.EventHandler(this.btCamSettingsSide_Click);
            // 
            // btConnectCamTop
            // 
            this.btConnectCamTop.Location = new System.Drawing.Point(6, 19);
            this.btConnectCamTop.Name = "btConnectCamTop";
            this.btConnectCamTop.Size = new System.Drawing.Size(131, 23);
            this.btConnectCamTop.TabIndex = 2;
            this.btConnectCamTop.Text = "Connect to Top Camera";
            this.btConnectCamTop.UseVisualStyleBackColor = true;
            this.btConnectCamTop.Click += new System.EventHandler(this.btConnectCamTop_Click);
            // 
            // btCamSettingsTop
            // 
            this.btCamSettingsTop.Location = new System.Drawing.Point(6, 48);
            this.btCamSettingsTop.Name = "btCamSettingsTop";
            this.btCamSettingsTop.Size = new System.Drawing.Size(131, 23);
            this.btCamSettingsTop.TabIndex = 10;
            this.btCamSettingsTop.Text = "Top Camera Settings";
            this.btCamSettingsTop.UseVisualStyleBackColor = true;
            this.btCamSettingsTop.Click += new System.EventHandler(this.btCamSettingsTop_Click);
            // 
            // tpRunPage
            // 
            this.tpRunPage.Controls.Add(this.groupBox1);
            this.tpRunPage.Controls.Add(this.gbRecord);
            this.tpRunPage.Location = new System.Drawing.Point(4, 22);
            this.tpRunPage.Name = "tpRunPage";
            this.tpRunPage.Padding = new System.Windows.Forms.Padding(3);
            this.tpRunPage.Size = new System.Drawing.Size(433, 426);
            this.tpRunPage.TabIndex = 1;
            this.tpRunPage.Text = "Run ";
            this.tpRunPage.UseVisualStyleBackColor = true;
            // 
            // gbRecord
            // 
            this.gbRecord.Controls.Add(this.lbRecordFilename);
            this.gbRecord.Controls.Add(this.btRecordStop);
            this.gbRecord.Controls.Add(this.btRecordStart);
            this.gbRecord.Controls.Add(this.tbRecordFilename);
            this.gbRecord.Location = new System.Drawing.Point(6, 6);
            this.gbRecord.Name = "gbRecord";
            this.gbRecord.Size = new System.Drawing.Size(143, 91);
            this.gbRecord.TabIndex = 6;
            this.gbRecord.TabStop = false;
            this.gbRecord.Text = "Record to Data File";
            // 
            // lbRecordFilename
            // 
            this.lbRecordFilename.AutoSize = true;
            this.lbRecordFilename.Location = new System.Drawing.Point(7, 20);
            this.lbRecordFilename.Name = "lbRecordFilename";
            this.lbRecordFilename.Size = new System.Drawing.Size(54, 13);
            this.lbRecordFilename.TabIndex = 3;
            this.lbRecordFilename.Text = "File Name";
            // 
            // btRecordStop
            // 
            this.btRecordStop.Location = new System.Drawing.Point(80, 62);
            this.btRecordStop.Name = "btRecordStop";
            this.btRecordStop.Size = new System.Drawing.Size(57, 23);
            this.btRecordStop.TabIndex = 2;
            this.btRecordStop.Text = "Stop";
            this.btRecordStop.UseVisualStyleBackColor = true;
            this.btRecordStop.Click += new System.EventHandler(this.btRecordStop_Click);
            // 
            // btRecordStart
            // 
            this.btRecordStart.Location = new System.Drawing.Point(6, 62);
            this.btRecordStart.Name = "btRecordStart";
            this.btRecordStart.Size = new System.Drawing.Size(57, 23);
            this.btRecordStart.TabIndex = 1;
            this.btRecordStart.Text = "Start";
            this.btRecordStart.UseVisualStyleBackColor = true;
            this.btRecordStart.Click += new System.EventHandler(this.btRecordStart_Click);
            // 
            // tbRecordFilename
            // 
            this.tbRecordFilename.Location = new System.Drawing.Point(6, 36);
            this.tbRecordFilename.Name = "tbRecordFilename";
            this.tbRecordFilename.Size = new System.Drawing.Size(131, 20);
            this.tbRecordFilename.TabIndex = 0;
            this.tbRecordFilename.Text = "data.csv";
            // 
            // gbCalibrationCreate
            // 
            this.gbCalibrationCreate.Controls.Add(this.label5);
            this.gbCalibrationCreate.Controls.Add(this.label4);
            this.gbCalibrationCreate.Controls.Add(this.label1);
            this.gbCalibrationCreate.Controls.Add(this.button8);
            this.gbCalibrationCreate.Controls.Add(this.label2);
            this.gbCalibrationCreate.Controls.Add(this.textBox3);
            this.gbCalibrationCreate.Controls.Add(this.button5);
            this.gbCalibrationCreate.Controls.Add(this.button4);
            this.gbCalibrationCreate.Controls.Add(this.button3);
            this.gbCalibrationCreate.Controls.Add(this.btCalibrationA);
            this.gbCalibrationCreate.Location = new System.Drawing.Point(155, 6);
            this.gbCalibrationCreate.Name = "gbCalibrationCreate";
            this.gbCalibrationCreate.Size = new System.Drawing.Size(143, 240);
            this.gbCalibrationCreate.TabIndex = 33;
            this.gbCalibrationCreate.TabStop = false;
            this.gbCalibrationCreate.Text = "Create Calibration";
            this.gbCalibrationCreate.Visible = false;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(7, 205);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(130, 23);
            this.button8.TabIndex = 6;
            this.button8.Text = "Save Calibration";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Save Calibration";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(7, 178);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(130, 20);
            this.textBox3.TabIndex = 4;
            this.textBox3.Text = "calibration.cal";
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(76, 80);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(59, 23);
            this.button5.TabIndex = 3;
            this.button5.Text = "Stop";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(7, 80);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(59, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "Start";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(76, 35);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Stop";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btCalibrationA
            // 
            this.btCalibrationA.Location = new System.Drawing.Point(6, 35);
            this.btCalibrationA.Name = "btCalibrationA";
            this.btCalibrationA.Size = new System.Drawing.Size(60, 23);
            this.btCalibrationA.TabIndex = 0;
            this.btCalibrationA.Text = "Start";
            this.btCalibrationA.UseVisualStyleBackColor = true;
            // 
            // gbCalibrationLoad
            // 
            this.gbCalibrationLoad.Controls.Add(this.label3);
            this.gbCalibrationLoad.Controls.Add(this.button9);
            this.gbCalibrationLoad.Location = new System.Drawing.Point(155, 252);
            this.gbCalibrationLoad.Name = "gbCalibrationLoad";
            this.gbCalibrationLoad.Size = new System.Drawing.Size(143, 73);
            this.gbCalibrationLoad.TabIndex = 34;
            this.gbCalibrationLoad.TabStop = false;
            this.gbCalibrationLoad.Text = "Load Calibration";
            this.gbCalibrationLoad.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "2018-02-10-a.cal";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(6, 19);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(130, 23);
            this.button9.TabIndex = 7;
            this.button9.Text = "Load Calibration";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(155, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(143, 90);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mode";
            this.groupBox1.Visible = false;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(7, 68);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(44, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "Sort";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(7, 44);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(48, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Data";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(74, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Calibration";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Record Sample A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Record Sample B";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "label5";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 476);
            this.Controls.Add(this.tcTabControl);
            this.Controls.Add(this.pbSide);
            this.Controls.Add(this.pbMain);
            this.Controls.Add(this.icSide);
            this.Controls.Add(this.icMain);
            this.Controls.Add(this.tbOutput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainView";
            this.Text = "EGADS!";
            ((System.ComponentModel.ISupportInitialize)(this.icMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icSide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSide)).EndInit();
            this.tcTabControl.ResumeLayout(false);
            this.tpConfigPage.ResumeLayout(false);
            this.gbCamSettings.ResumeLayout(false);
            this.tpRunPage.ResumeLayout(false);
            this.gbRecord.ResumeLayout(false);
            this.gbRecord.PerformLayout();
            this.gbCalibrationCreate.ResumeLayout(false);
            this.gbCalibrationCreate.PerformLayout();
            this.gbCalibrationLoad.ResumeLayout(false);
            this.gbCalibrationLoad.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbOutput;
        private TIS.Imaging.ICImagingControl icMain;
        private TIS.Imaging.ICImagingControl icSide;
        private System.Windows.Forms.PictureBox pbMain;
        private System.Windows.Forms.PictureBox pbSide;
        private System.Windows.Forms.TabControl tcTabControl;
        private System.Windows.Forms.TabPage tpConfigPage;
        private System.Windows.Forms.GroupBox gbCamSettings;
        private System.Windows.Forms.Button btTriggerToggle;
        private System.Windows.Forms.Button btConnectCamSide;
        private System.Windows.Forms.Button btCamSettingsSide;
        private System.Windows.Forms.Button btConnectCamTop;
        private System.Windows.Forms.Button btCamSettingsTop;
        private System.Windows.Forms.TabPage tpRunPage;
        private System.Windows.Forms.GroupBox gbRecord;
        private System.Windows.Forms.Label lbRecordFilename;
        private System.Windows.Forms.Button btRecordStop;
        private System.Windows.Forms.Button btRecordStart;
        private System.Windows.Forms.TextBox tbRecordFilename;
        private System.Windows.Forms.GroupBox gbCalibrationLoad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.GroupBox gbCalibrationCreate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btCalibrationA;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}

