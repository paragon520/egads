using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace egads1
{
    public enum State { Idle, DataRecord, SampleARecord, SampleBRecord, Sort}
    public enum Command {MainCamConnect, MainCamSettings, SideCamConnect, SideCamSettings, ToggleCamTrigger,
        RecordStart, RecordStop, RecordAStart, RecordAStop, RecordBStart, RecordBStop, MakeCalibration }

    class MainController
    {
        MainView mainView;
        CameraController mainCamera;
        CameraController sideCamera;
        ImageAnalyser mainAnalyser;
        ImageAnalyser sideAnalyser;
        RunData currentRun;
        RunData runSampleA;
        RunData runSampleB;
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
                    {
                        mainCamera.OpenVideoCaptureDevice();
                        mainCamera.restart();
                        break;
                    }
                case Command.MainCamSettings:
                    {
                        mainCamera.ShowDeviceProperties();
                        break;
                    }
                case Command.SideCamConnect:
                    {
                        sideCamera.OpenVideoCaptureDevice();
                        sideCamera.restart();
                        break;
                    }
                case Command.SideCamSettings:
                    {
                        sideCamera.ShowDeviceProperties();
                        break;
                    }
                case Command.ToggleCamTrigger:
                    {
                        mainCamera.toggleTriggerMode();
                        sideCamera.toggleTriggerMode();
                        break;
                    }
                case Command.RecordStart:
                    {
                        currentState = State.DataRecord;
                        break;
                    }
                case Command.RecordStop:
                    {
                        currentState = State.Idle;
                        currentRun.setOutputFile(filename);
                        currentRun.close();
                        break;
                    }
                case Command.RecordAStart:
                    {
                        currentState = State.SampleARecord;
                        runSampleA = new RunData();
                        runSampleA.setOutputFile("sampleA.csv");
                        break;
                    }
                case Command.RecordAStop:
                    {
                        currentState = State.Idle;
                        break;
                    }
                case Command.RecordBStart:
                    {
                        currentState = State.SampleBRecord;
                        runSampleA.setOutputFile("sampleB.csv");
                        runSampleB = new RunData();
                        break;
                    }
                case Command.RecordBStop:
                    {
                        currentState = State.Idle;
                        break;
                    }
                case Command.MakeCalibration:
                    {
                        break;
                    }
            }
        }

        public void imageAvailableMain(string filename)
        {
            //Bitmap temp = new Bitmap(filename);
            //mainView.postImageMain(temp);

            ImageAnalysis tempAnalysis = mainAnalyser.analyse(filename); //Move to thread task?
            mainView.postImageMain(tempAnalysis.Result);
            
            string output = "";
            switch(currentState)
            {
                case State.SampleARecord:
                    runSampleA.add(tempAnalysis);
                    output += "Main| C=(" + (int)tempAnalysis.Center.X + "px," + (int)tempAnalysis.Center.Y + "px), ";
                    output += "A=" + (int)tempAnalysis.Area + ", W=" + (int)tempAnalysis.Width + ", L=" + (int)tempAnalysis.Length + ", R=1:" + tempAnalysis.Ratio;
                    break;
                case State.SampleBRecord:
                    runSampleB.add(tempAnalysis);
                    output += "Main| C=(" + (int)tempAnalysis.Center.X + "px," + (int)tempAnalysis.Center.Y + "px), ";
                    output += "A=" + (int)tempAnalysis.Area + ", W=" + (int)tempAnalysis.Width + ", L=" + (int)tempAnalysis.Length + ", R=1:" + tempAnalysis.Ratio;
                    break;
                case State.DataRecord:
                    currentRun.add(tempAnalysis);
                    output += "Main| C=(" + (int)tempAnalysis.Center.X + "px," + (int)tempAnalysis.Center.Y + "px), ";
                    output += "A=" + (int)tempAnalysis.Area + ", W=" + (int)tempAnalysis.Width + ", L=" + (int)tempAnalysis.Length + ", R=1:" + tempAnalysis.Ratio;
                    break;
                case State.Idle:
                    output += "Main| C=(" + (int)tempAnalysis.Center.X + "px," + (int)tempAnalysis.Center.Y + "px), ";
                    output += "A=" + (int)tempAnalysis.Area + ", W=" + (int)tempAnalysis.Width + ", L=" + (int)tempAnalysis.Length + ", R=1:" + tempAnalysis.Ratio;
                    break;
            }
            
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
