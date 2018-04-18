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
            this.tpRunPage = new System.Windows.Forms.TabPage();
            this.gbCamSettings = new System.Windows.Forms.GroupBox();
            this.btTriggerToggle = new System.Windows.Forms.Button();
            this.btConnectCamSide = new System.Windows.Forms.Button();
            this.btCamSettingsSide = new System.Windows.Forms.Button();
            this.btConnectCamTop = new System.Windows.Forms.Button();
            this.btCamSettingsTop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.icMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icSide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSide)).BeginInit();
            this.tcTabControl.SuspendLayout();
            this.tpConfigPage.SuspendLayout();
            this.gbCamSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbOutput
            // 
            this.tbOutput.Location = new System.Drawing.Point(13, 13);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ReadOnly = true;
            this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbOutput.Size = new System.Drawing.Size(933, 80);
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
            this.tcTabControl.Location = new System.Drawing.Point(505, 99);
            this.tcTabControl.Name = "tcTabControl";
            this.tcTabControl.SelectedIndex = 0;
            this.tcTabControl.Size = new System.Drawing.Size(441, 366);
            this.tcTabControl.TabIndex = 5;
            // 
            // tpConfigPage
            // 
            this.tpConfigPage.Controls.Add(this.gbCamSettings);
            this.tpConfigPage.Location = new System.Drawing.Point(4, 22);
            this.tpConfigPage.Name = "tpConfigPage";
            this.tpConfigPage.Padding = new System.Windows.Forms.Padding(3);
            this.tpConfigPage.Size = new System.Drawing.Size(433, 340);
            this.tpConfigPage.TabIndex = 0;
            this.tpConfigPage.Text = "Config";
            this.tpConfigPage.UseVisualStyleBackColor = true;
            // 
            // tpRunPage
            // 
            this.tpRunPage.Location = new System.Drawing.Point(4, 22);
            this.tpRunPage.Name = "tpRunPage";
            this.tpRunPage.Padding = new System.Windows.Forms.Padding(3);
            this.tpRunPage.Size = new System.Drawing.Size(433, 340);
            this.tpRunPage.TabIndex = 1;
            this.tpRunPage.Text = "Run ";
            this.tpRunPage.UseVisualStyleBackColor = true;
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
    }
}

