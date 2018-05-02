using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace egads1
{
    public enum State { Idle, DataRecord, SampleARecord, SampleBRecord, Sort}
    public enum Command {MainCamConnect, MainCamSettings, SideCamConnect, SideCamSettings, ToggleCamTrigger,
        RecordStart, RecordStop, RecordAStart, RecordAStop, RecordBStart, RecordBStop, MakeCalibration, SortMode, DataMode }

    class MainController
    {
        private MainView mainView;
        private CameraController mainCamera;
        private CameraController sideCamera;
        private ImageAnalyser mainAnalyser;
        private ImageAnalyser sideAnalyser;
        private GrainAnalysis currentGrain;
        private RunData currentRun;
        private RunData runSampleA;
        private RunData runSampleB;
        private State currentState;
        double threshold;


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

        public void command(Command c, string filename = "data.csv", bool rejectB = true)
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
                        break;
                    }
                case Command.RecordAStop:
                    {
                        currentState = State.Idle;
                        runSampleA.setOutputFile("sampleA.csv");
                        runSampleA.close();
                        break;
                    }
                case Command.RecordBStart:
                    {
                        currentState = State.SampleBRecord;
                        runSampleB = new RunData();
                        break;
                    }
                case Command.RecordBStop:
                    {
                        currentState = State.Idle;
                        runSampleB.setOutputFile("sampleB.csv");
                        runSampleB.close();
                        break;
                    }
                case Command.MakeCalibration:
                    {
                        calibration(filename, rejectB, out threshold);
                        break;
                    }
                case Command.SortMode:
                    {
                        currentState = State.Sort;
                        break;
                    }
                case Command.DataMode:
                    {
                        currentState = State.Idle;
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

            currentGrain = new GrainAnalysis();
            currentGrain.setMain(tempAnalysis);
            
            string output = "";
            switch(currentState)
            {
                case State.SampleARecord:
                    //runSampleA.add(tempAnalysis);
                    break;
                case State.SampleBRecord:
                    //runSampleB.add(tempAnalysis);
                    break;
                case State.DataRecord:
                    //currentRun.add(tempAnalysis);
                    break;
                case State.Idle:
                    break;
            }


            output += "Main| C=(" + (int)tempAnalysis.Center.X + "px," + (int)tempAnalysis.Center.Y + "px), ";
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

            if (currentGrain != null)
            {
                currentGrain.setSide(tempAnalysis2);
                currentGrain.analyse();

                switch (currentState)
                {
                    case State.SampleARecord:
                        //runSampleA.add(tempAnalysis);
                        runSampleA.add(currentGrain);
                        break;
                    case State.SampleBRecord:
                        //runSampleB.add(tempAnalysis);
                        runSampleB.add(currentGrain);
                        break;
                    case State.DataRecord:
                        //currentRun.add(tempAnalysis);
                        currentRun.add(currentGrain);
                        break;
                    case State.Idle:
                        break;
                }

                output = "Grain| L=" + (int)currentGrain.Length + ", W=" + (int)currentGrain.Width + ", D=" + (int)currentGrain.Depth + ", V=" + (int)currentGrain.Volume;
                mainView.displayData(output);

                currentGrain = null;
            }
            
        }


        private bool calibration(string filename, bool rejectB, out double m_threshold)
        {
            if (runSampleA.Length > 1 && runSampleB.Length > 1)
            {
                //calculate average volume of each sample set
                List<double> volumeSetA = new List<double>();
                double meanVolumeA = 0;
                foreach(GrainAnalysis ga in runSampleA.toList)
                {
                    meanVolumeA += ga.Volume;
                    volumeSetA.Add(ga.Volume);
                }
                meanVolumeA = meanVolumeA / runSampleA.Length;
                mainView.displayData("Set A mean: " + meanVolumeA);

                List<double> volumeSetB = new List<double>();
                double meanVolumeB = 0;
                foreach (GrainAnalysis ga in runSampleB.toList)
                {
                    meanVolumeB += ga.Volume;
                    volumeSetB.Add(ga.Volume);
                }
                meanVolumeB = meanVolumeB / runSampleB.Length;
                mainView.displayData("Set B mean: " + meanVolumeB);

                //calculate stddev of volume of each sample set
                double stddevSetA = 0;
                foreach (double volume in volumeSetA)
                {
                    stddevSetA += Math.Pow(volume - meanVolumeA, 2);
                }

                stddevSetA = Math.Sqrt(stddevSetA / runSampleA.Length);
                mainView.displayData("Set A standard deviation: " + stddevSetA);

                double stddevSetB = 0;
                foreach (double volume in volumeSetB)
                {
                    stddevSetB += Math.Pow(volume - meanVolumeB, 2);
                }

                stddevSetB = Math.Sqrt(stddevSetB / runSampleB.Length);
                mainView.displayData("Set B standard deviation: " + stddevSetB);

                //calculate volume threshold to (halfway between averages)
                m_threshold = 0;

                if (meanVolumeA < meanVolumeB)
                {
                    m_threshold = ((meanVolumeA + stddevSetA) + (meanVolumeB - stddevSetB)) / 2;
                }
                else if (meanVolumeA > meanVolumeB)
                {
                    m_threshold = ((meanVolumeA - stddevSetA) + (meanVolumeB + stddevSetB)) / 2;
                }
                else
                {
                    //we have a problem. Samples have same average.
                    mainView.displayData("Samples have the same volume. Unable to distinguish.");
                }

                mainView.displayData("Threshold: " + m_threshold);

                //if stddev overlap, this will have low accuracy on sorting.

                string calText =
                    "Variable=Volume\n" +
                    "Value="+m_threshold;

                File.AppendAllText(filename, calText);

                return (m_threshold > 0);
            }
            else
            {
                m_threshold = 0;
                return false;
            }
        }
    }
}
