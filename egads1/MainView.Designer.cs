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
            this.gbCalibrationLoad = new System.Windows.Forms.GroupBox();
            this.lbCalibrationLoaded = new System.Windows.Forms.Label();
            this.btCalibrationLoad = new System.Windows.Forms.Button();
            this.gbCalibrationCreate = new System.Windows.Forms.GroupBox();
            this.rbRejectA = new System.Windows.Forms.RadioButton();
            this.rbRejectB = new System.Windows.Forms.RadioButton();
            this.lbRejectOptions = new System.Windows.Forms.Label();
            this.lbRecordSampleB = new System.Windows.Forms.Label();
            this.lbRecordSampleA = new System.Windows.Forms.Label();
            this.btCalibrationSave = new System.Windows.Forms.Button();
            this.lbCalibrationSaveFile = new System.Windows.Forms.Label();
            this.tbCalibrationSaveFile = new System.Windows.Forms.TextBox();
            this.btCalibrationBStop = new System.Windows.Forms.Button();
            this.btCalibrationBStart = new System.Windows.Forms.Button();
            this.btCalibrationAStop = new System.Windows.Forms.Button();
            this.btCalibrationAStart = new System.Windows.Forms.Button();
            this.gbCamSettings = new System.Windows.Forms.GroupBox();
            this.btTriggerToggle = new System.Windows.Forms.Button();
            this.btConnectCamSide = new System.Windows.Forms.Button();
            this.btCamSettingsSide = new System.Windows.Forms.Button();
            this.btConnectCamTop = new System.Windows.Forms.Button();
            this.btCamSettingsTop = new System.Windows.Forms.Button();
            this.tpRunPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSortMode = new System.Windows.Forms.RadioButton();
            this.rbDataMode = new System.Windows.Forms.RadioButton();
            this.gbRecord = new System.Windows.Forms.GroupBox();
            this.lbRecordFilename = new System.Windows.Forms.Label();
            this.btRecordStop = new System.Windows.Forms.Button();
            this.btRecordStart = new System.Windows.Forms.Button();
            this.tbRecordFilename = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.icMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icSide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSide)).BeginInit();
            this.tcTabControl.SuspendLayout();
            this.tpConfigPage.SuspendLayout();
            this.gbCalibrationLoad.SuspendLayout();
            this.gbCalibrationCreate.SuspendLayout();
            this.gbCamSettings.SuspendLayout();
            this.tpRunPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbRecord.SuspendLayout();
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
            // gbCalibrationLoad
            // 
            this.gbCalibrationLoad.Controls.Add(this.lbCalibrationLoaded);
            this.gbCalibrationLoad.Controls.Add(this.btCalibrationLoad);
            this.gbCalibrationLoad.Location = new System.Drawing.Point(155, 222);
            this.gbCalibrationLoad.Name = "gbCalibrationLoad";
            this.gbCalibrationLoad.Size = new System.Drawing.Size(143, 73);
            this.gbCalibrationLoad.TabIndex = 34;
            this.gbCalibrationLoad.TabStop = false;
            this.gbCalibrationLoad.Text = "Load Calibration";
            // 
            // lbCalibrationLoaded
            // 
            this.lbCalibrationLoaded.AutoSize = true;
            this.lbCalibrationLoaded.Location = new System.Drawing.Point(6, 50);
            this.lbCalibrationLoaded.Name = "lbCalibrationLoaded";
            this.lbCalibrationLoaded.Size = new System.Drawing.Size(72, 13);
            this.lbCalibrationLoaded.TabIndex = 8;
            this.lbCalibrationLoaded.Text = "calibration.cal";
            // 
            // btCalibrationLoad
            // 
            this.btCalibrationLoad.Location = new System.Drawing.Point(6, 19);
            this.btCalibrationLoad.Name = "btCalibrationLoad";
            this.btCalibrationLoad.Size = new System.Drawing.Size(130, 23);
            this.btCalibrationLoad.TabIndex = 7;
            this.btCalibrationLoad.Text = "Load Calibration";
            this.btCalibrationLoad.UseVisualStyleBackColor = true;
            // 
            // gbCalibrationCreate
            // 
            this.gbCalibrationCreate.Controls.Add(this.rbRejectA);
            this.gbCalibrationCreate.Controls.Add(this.rbRejectB);
            this.gbCalibrationCreate.Controls.Add(this.lbRejectOptions);
            this.gbCalibrationCreate.Controls.Add(this.lbRecordSampleB);
            this.gbCalibrationCreate.Controls.Add(this.lbRecordSampleA);
            this.gbCalibrationCreate.Controls.Add(this.btCalibrationSave);
            this.gbCalibrationCreate.Controls.Add(this.lbCalibrationSaveFile);
            this.gbCalibrationCreate.Controls.Add(this.tbCalibrationSaveFile);
            this.gbCalibrationCreate.Controls.Add(this.btCalibrationBStop);
            this.gbCalibrationCreate.Controls.Add(this.btCalibrationBStart);
            this.gbCalibrationCreate.Controls.Add(this.btCalibrationAStop);
            this.gbCalibrationCreate.Controls.Add(this.btCalibrationAStart);
            this.gbCalibrationCreate.Location = new System.Drawing.Point(155, 6);
            this.gbCalibrationCreate.Name = "gbCalibrationCreate";
            this.gbCalibrationCreate.Size = new System.Drawing.Size(143, 210);
            this.gbCalibrationCreate.TabIndex = 33;
            this.gbCalibrationCreate.TabStop = false;
            this.gbCalibrationCreate.Text = "Create Calibration";
            // 
            // rbRejectA
            // 
            this.rbRejectA.AutoSize = true;
            this.rbRejectA.Location = new System.Drawing.Point(96, 109);
            this.rbRejectA.Name = "rbRejectA";
            this.rbRejectA.Size = new System.Drawing.Size(32, 17);
            this.rbRejectA.TabIndex = 11;
            this.rbRejectA.Text = "A";
            this.rbRejectA.UseVisualStyleBackColor = true;
            // 
            // rbRejectB
            // 
            this.rbRejectB.AutoSize = true;
            this.rbRejectB.Checked = true;
            this.rbRejectB.Location = new System.Drawing.Point(58, 109);
            this.rbRejectB.Name = "rbRejectB";
            this.rbRejectB.Size = new System.Drawing.Size(32, 17);
            this.rbRejectB.TabIndex = 10;
            this.rbRejectB.TabStop = true;
            this.rbRejectB.Text = "B";
            this.rbRejectB.UseVisualStyleBackColor = true;
            // 
            // lbRejectOptions
            // 
            this.lbRejectOptions.AutoSize = true;
            this.lbRejectOptions.Location = new System.Drawing.Point(9, 111);
            this.lbRejectOptions.Name = "lbRejectOptions";
            this.lbRejectOptions.Size = new System.Drawing.Size(44, 13);
            this.lbRejectOptions.TabIndex = 9;
            this.lbRejectOptions.Text = "Reject: ";
            // 
            // lbRecordSampleB
            // 
            this.lbRecordSampleB.AutoSize = true;
            this.lbRecordSampleB.Location = new System.Drawing.Point(9, 64);
            this.lbRecordSampleB.Name = "lbRecordSampleB";
            this.lbRecordSampleB.Size = new System.Drawing.Size(90, 13);
            this.lbRecordSampleB.TabIndex = 8;
            this.lbRecordSampleB.Text = "Record Sample B";
            // 
            // lbRecordSampleA
            // 
            this.lbRecordSampleA.AutoSize = true;
            this.lbRecordSampleA.Location = new System.Drawing.Point(9, 19);
            this.lbRecordSampleA.Name = "lbRecordSampleA";
            this.lbRecordSampleA.Size = new System.Drawing.Size(90, 13);
            this.lbRecordSampleA.TabIndex = 7;
            this.lbRecordSampleA.Text = "Record Sample A";
            // 
            // btCalibrationSave
            // 
            this.btCalibrationSave.Location = new System.Drawing.Point(6, 177);
            this.btCalibrationSave.Name = "btCalibrationSave";
            this.btCalibrationSave.Size = new System.Drawing.Size(130, 23);
            this.btCalibrationSave.TabIndex = 6;
            this.btCalibrationSave.Text = "Save Calibration";
            this.btCalibrationSave.UseVisualStyleBackColor = true;
            this.btCalibrationSave.Click += new System.EventHandler(this.btCalibrationSave_Click);
            // 
            // lbCalibrationSaveFile
            // 
            this.lbCalibrationSaveFile.AutoSize = true;
            this.lbCalibrationSaveFile.Location = new System.Drawing.Point(9, 135);
            this.lbCalibrationSaveFile.Name = "lbCalibrationSaveFile";
            this.lbCalibrationSaveFile.Size = new System.Drawing.Size(84, 13);
            this.lbCalibrationSaveFile.TabIndex = 5;
            this.lbCalibrationSaveFile.Text = "Save Calibration";
            // 
            // tbCalibrationSaveFile
            // 
            this.tbCalibrationSaveFile.Location = new System.Drawing.Point(7, 151);
            this.tbCalibrationSaveFile.Name = "tbCalibrationSaveFile";
            this.tbCalibrationSaveFile.Size = new System.Drawing.Size(130, 20);
            this.tbCalibrationSaveFile.TabIndex = 4;
            this.tbCalibrationSaveFile.Text = "calibration.cal";
            // 
            // btCalibrationBStop
            // 
            this.btCalibrationBStop.Location = new System.Drawing.Point(76, 80);
            this.btCalibrationBStop.Name = "btCalibrationBStop";
            this.btCalibrationBStop.Size = new System.Drawing.Size(59, 23);
            this.btCalibrationBStop.TabIndex = 3;
            this.btCalibrationBStop.Text = "Stop";
            this.btCalibrationBStop.UseVisualStyleBackColor = true;
            this.btCalibrationBStop.Click += new System.EventHandler(this.btCalibrationBStop_Click);
            // 
            // btCalibrationBStart
            // 
            this.btCalibrationBStart.Location = new System.Drawing.Point(7, 80);
            this.btCalibrationBStart.Name = "btCalibrationBStart";
            this.btCalibrationBStart.Size = new System.Drawing.Size(59, 23);
            this.btCalibrationBStart.TabIndex = 2;
            this.btCalibrationBStart.Text = "Start";
            this.btCalibrationBStart.UseVisualStyleBackColor = true;
            this.btCalibrationBStart.Click += new System.EventHandler(this.btCalibrationBStart_Click);
            // 
            // btCalibrationAStop
            // 
            this.btCalibrationAStop.Location = new System.Drawing.Point(76, 35);
            this.btCalibrationAStop.Name = "btCalibrationAStop";
            this.btCalibrationAStop.Size = new System.Drawing.Size(60, 23);
            this.btCalibrationAStop.TabIndex = 1;
            this.btCalibrationAStop.Text = "Stop";
            this.btCalibrationAStop.UseVisualStyleBackColor = true;
            this.btCalibrationAStop.Click += new System.EventHandler(this.btCalibrationAStop_Click);
            // 
            // btCalibrationAStart
            // 
            this.btCalibrationAStart.Location = new System.Drawing.Point(6, 35);
            this.btCalibrationAStart.Name = "btCalibrationAStart";
            this.btCalibrationAStart.Size = new System.Drawing.Size(60, 23);
            this.btCalibrationAStart.TabIndex = 0;
            this.btCalibrationAStart.Text = "Start";
            this.btCalibrationAStart.UseVisualStyleBackColor = true;
            this.btCalibrationAStart.Click += new System.EventHandler(this.btCalibrationAStart_Click);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSortMode);
            this.groupBox1.Controls.Add(this.rbDataMode);
            this.groupBox1.Location = new System.Drawing.Point(155, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(143, 90);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mode";
            // 
            // rbSortMode
            // 
            this.rbSortMode.AutoSize = true;
            this.rbSortMode.Location = new System.Drawing.Point(6, 39);
            this.rbSortMode.Name = "rbSortMode";
            this.rbSortMode.Size = new System.Drawing.Size(44, 17);
            this.rbSortMode.TabIndex = 2;
            this.rbSortMode.Text = "Sort";
            this.rbSortMode.UseVisualStyleBackColor = true;
            this.rbSortMode.CheckedChanged += new System.EventHandler(this.rbSortMode_CheckedChanged);
            // 
            // rbDataMode
            // 
            this.rbDataMode.AutoSize = true;
            this.rbDataMode.Checked = true;
            this.rbDataMode.Location = new System.Drawing.Point(6, 16);
            this.rbDataMode.Name = "rbDataMode";
            this.rbDataMode.Size = new System.Drawing.Size(48, 17);
            this.rbDataMode.TabIndex = 1;
            this.rbDataMode.TabStop = true;
            this.rbDataMode.Text = "Data";
            this.rbDataMode.UseVisualStyleBackColor = true;
            this.rbDataMode.CheckedChanged += new System.EventHandler(this.rbDataMode_CheckedChanged);
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
            this.gbCalibrationLoad.ResumeLayout(false);
            this.gbCalibrationLoad.PerformLayout();
            this.gbCalibrationCreate.ResumeLayout(false);
            this.gbCalibrationCreate.PerformLayout();
            this.gbCamSettings.ResumeLayout(false);
            this.tpRunPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbRecord.ResumeLayout(false);
            this.gbRecord.PerformLayout();
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
        private System.Windows.Forms.Label lbCalibrationLoaded;
        private System.Windows.Forms.Button btCalibrationLoad;
        private System.Windows.Forms.GroupBox gbCalibrationCreate;
        private System.Windows.Forms.Label lbRejectOptions;
        private System.Windows.Forms.Label lbRecordSampleB;
        private System.Windows.Forms.Label lbRecordSampleA;
        private System.Windows.Forms.Button btCalibrationSave;
        private System.Windows.Forms.Label lbCalibrationSaveFile;
        private System.Windows.Forms.TextBox tbCalibrationSaveFile;
        private System.Windows.Forms.Button btCalibrationBStop;
        private System.Windows.Forms.Button btCalibrationBStart;
        private System.Windows.Forms.Button btCalibrationAStop;
        private System.Windows.Forms.Button btCalibrationAStart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbSortMode;
        private System.Windows.Forms.RadioButton rbDataMode;
        private System.Windows.Forms.RadioButton rbRejectA;
        private System.Windows.Forms.RadioButton rbRejectB;
    }
}

