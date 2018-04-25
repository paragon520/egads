﻿// Icon was orginally Alert by Alain LOUBET from the Noun Project https://thenounproject.com/term/alert/14055/
// Wheat icon from Wheat by Andrea Caldarelli from the Noun Project https://thenounproject.com/term/wheat/17766/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace egads1
{
    public partial class MainView : Form
    {
        public const string TEMPIMAGEMAIN = "tmpMain.bmp";
        public const string TEMPIMAGESIDE = "tmpSide.bmp";


        private MainController controller;

        public MainView()
        {
            InitializeComponent();
        }

        internal MainController Controller
        {
            get => controller;
            set
            {
                controller = value;
                controller.setCameraControllers(icMain, icSide);
            }
        }

        private void btConnectCamTop_Click(object sender, EventArgs e)
        {
            controller.command(Command.MainCamConnect);
        }

        private void btCamSettingsTop_Click(object sender, EventArgs e)
        {
            controller.command(Command.MainCamSettings);
        }

        private void btConnectCamSide_Click(object sender, EventArgs e)
        {
            controller.command(Command.SideCamConnect);
        }

        private void btCamSettingsSide_Click(object sender, EventArgs e)
        {
            controller.command(Command.SideCamSettings);
        }

        private void btTriggerToggle_Click(object sender, EventArgs e)
        {
            controller.command(Command.ToggleCamTrigger);
        }

        private void icMain_ImageAvailable(object sender, TIS.Imaging.ICImagingControl.ImageAvailableEventArgs e)
        {
            if (icMain.InvokeRequired)
                icMain.Invoke(new icMain_ImageAvailable_delegate(icMain_ImageAvailable), sender, e);
            else
            {
                icMain.ImageActiveBuffer.SaveAsBitmap(TEMPIMAGEMAIN);
                controller.imageAvailableMain(TEMPIMAGEMAIN);
            }
        }
        private delegate void icMain_ImageAvailable_delegate(object sender, TIS.Imaging.ICImagingControl.ImageAvailableEventArgs e);

        private void icSide_ImageAvailable(object sender, TIS.Imaging.ICImagingControl.ImageAvailableEventArgs e)
        {
            if (icSide.InvokeRequired)
                icSide.Invoke(new icSide_ImageAvailable_delegate(icSide_ImageAvailable), sender, e);
            else
            {
                icSide.ImageActiveBuffer.SaveAsBitmap(TEMPIMAGESIDE);
                controller.imageAvailableSide(TEMPIMAGESIDE);
            }
        }
        private delegate void icSide_ImageAvailable_delegate(object sender, TIS.Imaging.ICImagingControl.ImageAvailableEventArgs e);

        public void postImageMain(Bitmap image)
        {
            if (pbMain.InvokeRequired)
                pbMain.Invoke(new postImageMainDelegate(postImageMain), image);
            else
                pbMain.Image = image;
        }
        private delegate void postImageMainDelegate(Bitmap image);

        public void postImageSide(Bitmap image)
        {
            if (pbSide.InvokeRequired)
                pbSide.Invoke(new postImageMainDelegate(postImageSide), image);
            else
                pbSide.Image = image;
        }
        private delegate void postImageSideDelegate(Bitmap image);

        private void btRecordStart_Click(object sender, EventArgs e)
        {
            controller.command(Command.RecordStart, tbRecordFilename.Text);

        }

        private void btRecordStop_Click(object sender, EventArgs e)
        {
            controller.command(Command.RecordStop, tbRecordFilename.Text);
        }

        public void displayData(string s)
        {
            if (tbOutput.InvokeRequired)
            {
                tbOutput.Invoke(new displayDataDelegate(displayData), s);
            }
            else
            {
                tbOutput.AppendText(s + "\n");
            }
        }
        private delegate void displayDataDelegate(string s);
    }
}
