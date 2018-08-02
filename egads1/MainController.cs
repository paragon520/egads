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
        RecordStart, RecordStop, RecordAStart, RecordAStop, RecordBStart, RecordBStop, MakeCalibration, SortMode, DataMode, ManualCapture }

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
        private bool sort;
        double threshold;
        bool rejectAboveThreshold;

        public MainController(MainView m_mainView)
        {
            mainView = m_mainView;
            mainAnalyser = new ImageAnalyser();
            sideAnalyser = new ImageAnalyser();
            currentRun = new RunData();
            currentState = State.Idle;
            sort = false;
        }

        public void setCameraControllers(TIS.Imaging.ICImagingControl mainIC, TIS.Imaging.ICImagingControl sideIC)
        {
            mainCamera = new CameraController(mainIC, "cam1Config.xml");
            sideCamera = new CameraController(sideIC, "cam2Config.xml");
        }

        public void command(Command c, string filename = "data.csv", bool isTrue = true)
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
                        currentRun = new RunData();
                        mainView.displayData("Data recording started.");
                        break;
                    }
                case Command.RecordStop:
                    {
                        currentState = State.Idle;
                        currentRun.setOutputFile(filename);
                        currentRun.close();
                        mainView.displayData("Data recording stopped.");
                        break;
                    }
                case Command.RecordAStart:
                    {
                        currentState = State.SampleARecord;
                        runSampleA = new RunData();
                        mainView.displayData("Sample A recording started.");
                        break;
                    }
                case Command.RecordAStop:
                    {
                        currentState = State.Idle;
                        runSampleA.setOutputFile("sampleA.csv");
                        runSampleA.close();
                        mainView.displayData("Sample A recording stopped and saved.");
                        break;
                    }
                case Command.RecordBStart:
                    {
                        currentState = State.SampleBRecord;
                        runSampleB = new RunData();
                        mainView.displayData("Sample B recording started.");
                        break;
                    }
                case Command.RecordBStop:
                    {
                        currentState = State.Idle;
                        runSampleB.setOutputFile("sampleB.csv");
                        runSampleB.close();
                        mainView.displayData("Sample B recording stopped and saved.");
                        break;
                    }
                case Command.MakeCalibration:
                    {
                        calibration(filename, isTrue, out threshold, out rejectAboveThreshold);
                        break;
                    }
                case Command.SortMode:
                    {
                        //currentState = State.Sort;
                        sort = true;
                        break;
                    }
                case Command.DataMode:
                    {
                        currentState = State.Idle;
                        sort = false;
                        break;
                    }
                case Command.ManualCapture:
                    {
                        manualCapture(filename, isTrue);
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


                output = "Grain| L=" + currentGrain.Length + ", W=" + currentGrain.Width + ", D=" + currentGrain.Depth + ", V=" + currentGrain.Volume;
                mainView.displayData(output);

                if (sort)
                {
                    if (rejectAboveThreshold)
                    {
                        if (currentGrain.Volume > threshold)
                        {
                            //reject
                            mainView.displayData("Reject!");
                            System.Media.SystemSounds.Asterisk.Play();
                        }
                    }
                    else
                    {
                        if (currentGrain.Volume < threshold)
                        {
                            //reject
                            mainView.displayData("Reject!");
                            System.Media.SystemSounds.Asterisk.Play();

                        }
                    }

                }

                currentGrain = null;
            }
            
        }

        private void manualCapture(string outputFile, bool recordThis)
        {
            string mainFile = "temp-Main.bmp";
            string sideFile = "temp-Side.bmp";

            mainCamera.manualCapture(mainFile);
            sideCamera.manualCapture(sideFile);

            ImageAnalysis mainAnalysis = mainAnalyser.analyse(mainFile); //Move to thread task?
            mainView.postImageMain(mainAnalysis.Result);
            string output = "Main| C=(" + (int)mainAnalysis.Center.X + "px," + (int)mainAnalysis.Center.Y + "px), "
            + "A=" + (int)mainAnalysis.Area + ", W=" + (int)mainAnalysis.Width + ", L=" + (int)mainAnalysis.Length + ", R=1:" + mainAnalysis.Ratio;
            mainView.displayData(output);
            
            ImageAnalysis sideAnalysis = sideAnalyser.analyse(sideFile, 105, 255, 0, 255, 120, 255);
            mainView.postImageSide(sideAnalysis.Result);
            output = "Side| C=(" + (int)sideAnalysis.Center.X + "px," + (int)sideAnalysis.Center.Y + "px), "
            + "A=" + (int)sideAnalysis.Area + ", W=" + (int)sideAnalysis.Width + ", L=" + (int)sideAnalysis.Length + ", R=1:" + sideAnalysis.Ratio;
            mainView.displayData(output);
            
            currentGrain = new GrainAnalysis();
            currentGrain.setMain(mainAnalysis);
            currentGrain.setSide(sideAnalysis);
            currentGrain.analyse();

            output = "Grain| L=" + currentGrain.Length + ", W=" + currentGrain.Width + ", D=" + currentGrain.Depth + ", V=" + currentGrain.Volume;
            mainView.displayData(output);
            

            if (recordThis)
            {
                string header = "Length(mm),Width(mm),Depth(mm),Area(mm^2),Volume(mm^3)\n";
                string line = currentGrain.Length + "," + currentGrain.Width + "," + currentGrain.Depth + "," 
                    + currentGrain.CrossSectionArea + "," + currentGrain.Volume+ "\n";

                //check if file exists, if not create with header
                if (!File.Exists(outputFile))
                {
                    File.AppendAllText(outputFile, header);
                }

                //append line on file
                try
                {
                    File.AppendAllText(outputFile, line);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("File error. The file may be open or inaccessable. Try closing the file or changing the file name and trying again. \n\n" + ex.Message);
                }

            }

            currentGrain = null;
        }

        private bool calibration(string filename, bool rejectB, out double m_threshold, out bool m_rejectAbove)
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
                m_rejectAbove = false;

                if (meanVolumeA < meanVolumeB)
                {
                    m_threshold = ((meanVolumeA + stddevSetA) + (meanVolumeB - stddevSetB)) / 2;
                    m_rejectAbove = (rejectB);
                }
                else if (meanVolumeA > meanVolumeB)
                {
                    m_threshold = ((meanVolumeA - stddevSetA) + (meanVolumeB + stddevSetB)) / 2;
                    m_rejectAbove = !rejectB;
                }
                else
                {
                    //we have a problem. Samples have same average.
                    mainView.displayData("Samples have the same volume. Unable to distinguish.");
                }

                mainView.displayData("Threshold: " + m_threshold);
                mainView.displayData((m_rejectAbove ? "Reject above threshold" : "Reject below threshold"));


                //if stddev overlap, this will have low accuracy on sorting.

                string calText =
                    "Variable=Volume\n" +
                    "Value="+m_threshold +"\n"+
                    "RejectAbove="+m_rejectAbove.ToString();

                File.AppendAllText(filename, calText);

                return (m_threshold > 0);
            }
            else
            {
                m_threshold = 0;
                m_rejectAbove = false;
                return false;
            }
        }
    }
}
