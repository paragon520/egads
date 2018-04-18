using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace egads1
{
    public enum State { }
    public enum Command {MainCamConnect, MainCamSettings, SideCamConnect, SideCamSettings, ToggleCamTrigger }

    class MainController
    {
        MainView mainView;
        CameraController mainCamera;
        CameraController sideCamera;
        ImageAnalyser mainAnalyser;
        ImageAnalyser sideAnalyser;
        RunData currentRun;



        public MainController(MainView m_mainView)
        {
            mainView = m_mainView;
            mainAnalyser = new ImageAnalyser();
            sideAnalyser = new ImageAnalyser();
        }

        public void setCameraControllers(TIS.Imaging.ICImagingControl mainIC, TIS.Imaging.ICImagingControl sideIC)
        {
            mainCamera = new CameraController(mainIC, "cam1Config.xml");
            sideCamera = new CameraController(sideIC, "cam2Config.xml");
        }

        public void command(Command c)
        {
            switch (c)
            {
                case Command.MainCamConnect:
                    mainCamera.OpenVideoCaptureDevice();
                    mainCamera.restart();
                    break;
                case Command.MainCamSettings:
                    mainCamera.ShowDeviceProperties();
                    break;
                case Command.SideCamConnect:
                    sideCamera.OpenVideoCaptureDevice();
                    sideCamera.restart();
                    break;
                case Command.SideCamSettings:
                    sideCamera.ShowDeviceProperties();
                    break;
                case Command.ToggleCamTrigger:
                    mainCamera.toggleTriggerMode();
                    sideCamera.toggleTriggerMode();
                    break;
            }
        }

        public void imageAvailableMain(string filename)
        {
            //Bitmap temp = new Bitmap(filename);
            //mainView.postImageMain(temp);

            ImageAnalysis temp = mainAnalyser.analyse(filename);

            mainView.postImageMain(temp.Result);

        }

        public void imageAvailableSide(string filename)
        {
            //Bitmap temp = new Bitmap(filename);
            //mainView.postImageSide(temp);

            ImageAnalysis temp = sideAnalyser.analyse(filename);
            mainView.postImageSide(temp.Result);
        }

    }
}
