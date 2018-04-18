// Icon was orginally Alert by Alain LOUBET from the Noun Project https://thenounproject.com/term/alert/14055/
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
    }
}
