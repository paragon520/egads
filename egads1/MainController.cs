using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace egads1
{
    public enum State { Idle, DataRecord, }
    public enum Command {MainCamConnect, MainCamSettings, SideCamConnect, SideCamSettings, ToggleCamTrigger, RecordStart, RecordStop }

    class MainController
    {
        MainView mainView;
        CameraController mainCamera;
        CameraController sideCamera;
        ImageAnalyser mainAnalyser;
        ImageAnalyser sideAnalyser;
        RunData currentRun;
        State currentState;


        public MainController(MainView m_mainView)
        {
            mainView = m_mainView;
            mainAnalyser = new ImageAnalyser();
            sideAnalyser = new ImageAnalyser();
            currentRun = new RunData();
            currentState = State.Idle;
        }

        public void setCameraControllers(TIS.Imaging.ICImagingControl mainIC, TIS.Imaging.ICImagingControl sideIC)
        {
            mainCamera = new CameraController(mainIC, "cam1Config.xml");
            sideCamera = new CameraController(sideIC, "cam2Config.xml");
        }

        public void command(Command c, string filename = "data.csv")
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
                case Command.RecordStart:
                    currentState = State.DataRecord;
                    break;
                case Command.RecordStop:
                    currentState = State.Idle;
                    currentRun.setOutputFile(filename);
                    currentRun.close();
                    break;
            }
        }

        public void imageAvailableMain(string filename)
        {
            //Bitmap temp = new Bitmap(filename);
            //mainView.postImageMain(temp);

            ImageAnalysis tempAnalysis = mainAnalyser.analyse(filename); //Move to thread task?
            mainView.postImageMain(tempAnalysis.Result);

            if(currentState == State.DataRecord)
                currentRun.add(tempAnalysis);

            string output = "Main| C=(" + (int)tempAnalysis.Center.X + "px," + (int)tempAnalysis.Center.Y + "px), ";
            output += "A=" + (int)tempAnalysis.Area + ", W=" + (int)tempAnalysis.Width + ", L=" + (int)tempAnalysis.Length + ", R=1:" + tempAnalysis.Ratio;

            mainView.displayData(output);

        }

        public void imageAvailableSide(string filename)
        {
            //Bitmap temp = new Bitmap(filename);
            //mainView.postImageSide(temp);

            ImageAnalysis tempAnalysis2 = sideAnalyser.analyse(filename);
            mainView.postImageSide(tempAnalysis2.Result);


            string output = "Side| C=(" + (int)tempAnalysis2.Center.X + "px," + (int)tempAnalysis2.Center.Y + "px), ";
            output += "A=" + (int)tempAnalysis2.Area + ", W=" + (int)tempAnalysis2.Width + ", L=" + (int)tempAnalysis2.Length + ", R=1:" + tempAnalysis2.Ratio;

            mainView.displayData(output);
        }

    }
}
