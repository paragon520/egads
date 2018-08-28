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

using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;

namespace egads1
{
    public partial class MainView : Form
    {
        public const string TEMPIMAGEMAIN = "tmpMain.bmp";
        public const string TEMPIMAGEMAIN2 = "tmpMain2.bmp";
        public const string TEMPIMAGESIDE = "tmpSide.bmp";
        public const string TEMPIMAGESIDE2 = "tmpSide2.bmp";




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

        private int framecountMain = 0;
        private void icMain_ImageAvailable(object sender, TIS.Imaging.ICImagingControl.ImageAvailableEventArgs e)
        {
            if (icMain.InvokeRequired)
            {
                framecountMain++;
                if (framecountMain > 9)
                {
                    icMain.Invoke(new icMain_ImageAvailable_delegate(icMain_ImageAvailable), sender, e);
                    framecountMain = 0;
                }
            }
            else
            {
                Bitmap frame = (Bitmap)icMain.ImageActiveBuffer.Bitmap.Clone();
                processFrameMain(frame);
                frame.Dispose();
                //processFrame(icMain.ImageActiveBuffer.Bitmap);
                //icMain.ImageActiveBuffer.Bitmap.Dispose();
                try
                {
                    //icMain.ImageActiveBuffer.SaveAsBitmap(TEMPIMAGEMAIN);
                    //controller.imageAvailableMain(TEMPIMAGEMAIN);


                }
                catch (Exception ex)
                {
                    //icMain.ImageActiveBuffer.SaveAsBitmap(TEMPIMAGEMAIN2);
                    //controller.imageAvailableMain(TEMPIMAGEMAIN2);
                }
            }
        }
        private delegate void icMain_ImageAvailable_delegate(object sender, TIS.Imaging.ICImagingControl.ImageAvailableEventArgs e);

        private int framecountSide = 0;
        private void icSide_ImageAvailable(object sender, TIS.Imaging.ICImagingControl.ImageAvailableEventArgs e)
        {
            if (icSide.InvokeRequired)
            {
                framecountSide++;
                if (framecountSide > 9)
                {
                    icSide.Invoke(new icSide_ImageAvailable_delegate(icSide_ImageAvailable), sender, e);
                    framecountSide = 0;
                }
            }
            else
            {
                try
                {
                    Bitmap frame = (Bitmap)icSide.ImageActiveBuffer.Bitmap.Clone();
                    processFrameSide(frame);
                    frame.Dispose();
                    //icSide.ImageActiveBuffer.SaveAsBitmap(TEMPIMAGESIDE);
                    //controller.imageAvailableSide(TEMPIMAGESIDE);
                }
                catch (Exception ex)
                {
                    //icSide.ImageActiveBuffer.SaveAsBitmap(TEMPIMAGESIDE2);
                    //controller.imageAvailableSide(TEMPIMAGESIDE2);
                }
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

        private void btCalibrationAStart_Click(object sender, EventArgs e)
        {
            controller.command(Command.RecordAStart);
        }

        private void btCalibrationAStop_Click(object sender, EventArgs e)
        {
            controller.command(Command.RecordAStop);
        }

        private void btCalibrationBStart_Click(object sender, EventArgs e)
        {
            controller.command(Command.RecordBStart);
        }

        private void btCalibrationBStop_Click(object sender, EventArgs e)
        {
            controller.command(Command.RecordBStop);
        }

        private void btCalibrationSave_Click(object sender, EventArgs e)
        {
            controller.command(Command.MakeCalibration, tbCalibrationSaveFile.Text, rbRejectB.Checked);
        }

        private void rbSortMode_CheckedChanged(object sender, EventArgs e)
        {
            controller.command(Command.SortMode);
        }

        private void rbDataMode_CheckedChanged(object sender, EventArgs e)
        {
            controller.command(Command.DataMode);
        }

        private void btnManualCapture_Click(object sender, EventArgs e)
        {
            controller.command(Command.ManualCapture, tbManualOutputFile.Text, cbxManualRecordThis.Checked);
        }



        private void processFrameMain(Bitmap currentFrame)
        {
            Image<Gray, Byte> grayFrame = new Image<Gray, Byte>(currentFrame);
            currentFrame.Dispose();

            //if (blankFrame == null) blankFrame = temp.Clone();
            //else
            //{
            //    CvInvoke.AbsDiff(blankFrame, temp, output);
            //}


            double trigger = grayFrame.GetAverage().Intensity;
            //displayData(trigger.ToString());
            

            if (trigger > 30.0)
            {
                CvInvoke.Threshold(grayFrame, grayFrame, 62, 255, ThresholdType.Binary);

                Bitmap outputBmp = grayFrame.ToBitmap();
                pbMain.Image = outputBmp;
                //outputBmp.Dispose();


                //find largest contour
                using (Image<Bgr, Byte> resultMatrix = new Image<Bgr, byte>(720, 540)) //new Mat(540, 720, 0, 1))
                {
                    int largest_contour_index = 0;
                    double largest_area = 0;
                    VectorOfPoint largestContour;

                    VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                    Mat hierachy = new Mat();
                    CvInvoke.FindContours(grayFrame, contours, hierachy, RetrType.Tree, ChainApproxMethod.ChainApproxNone);

                    if (contours.Size > 0)
                    {
                        for (int ii = 0; ii < contours.Size; ii++)
                        {
                            MCvScalar color = new MCvScalar(0, 0, 255);

                            double a = CvInvoke.ContourArea(contours[ii], false);  //  Find the area of contour
                            if (a > largest_area)
                            {
                                largest_area = a;
                                largest_contour_index = ii;                //Store the index of largest contour
                            }

                        }


                        //draw largest contour
                        CvInvoke.DrawContours(resultMatrix, contours, largest_contour_index, new MCvScalar(255, 255, 255), 1, LineType.EightConnected, hierachy);
                        largestContour = new VectorOfPoint(contours[largest_contour_index].ToArray());


                        //Image<Bgr, Byte> colorOutput = resultMatrix.ToImage<Bgr, Byte>();
                        

                        //Find center point
                        MCvMoments m = CvInvoke.Moments(largestContour, true);
                        MCvPoint2D64f center = m.GravityCenter;
                        //textBox1.AppendText("Center point: " + Math.Round(center.X, 3) + "px, " + Math.Round(center.Y, 3) + "px\n");
                        resultMatrix.Draw(new Cross2DF(new PointF((float)center.X, (float)center.Y), 3, 3), new Bgr(0, 0, 255), 2);

                        //Find Bounding Rectangle
                        RotatedRect rect = CvInvoke.MinAreaRect(largestContour);
                        resultMatrix.Draw(rect, new Bgr(255, 0, 0), 2);

                        //save and display
                        outputBmp = resultMatrix.ToBitmap();
                        pbMain2.Image = outputBmp;
                        //outputBmp.Dispose();

                    }
                }
                    


            }
        }


        private void processFrameSide(Bitmap currentFrame)
        {
            Image<Gray, Byte> grayFrame = new Image<Gray, Byte>(currentFrame);
            currentFrame.Dispose();

            //if (blankFrame == null) blankFrame = temp.Clone();
            //else
            //{
            //    CvInvoke.AbsDiff(blankFrame, temp, output);
            //}


            double trigger = grayFrame.GetAverage().Intensity;
            //displayData(trigger.ToString());


            if (trigger > 35.0)
            {

                //grayFrame.ROI = new Rectangle(0, 0, 720, 260);
                //CvInvoke.Rectangle(grayFrame, new Rectangle(0, 260, 720, 280), new MCvScalar(0,0,0), -1);
                CvInvoke.Threshold(grayFrame, grayFrame, 100, 255, ThresholdType.Binary);
                //grayFrame.ROI = Rectangle.Empty;

                Bitmap outputBmp = grayFrame.ToBitmap();
                pbSide.Image = outputBmp;
                //outputBmp.Dispose();


                //find largest contour
                using (Image<Bgr, Byte> resultMatrix = new Image<Bgr, byte>(720, 540))
                {
                    int largest_contour_index = 0;
                    double largest_area = 0;
                    VectorOfPoint largestContour;

                    VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                    Mat hierachy = new Mat();
                    CvInvoke.FindContours(grayFrame, contours, hierachy, RetrType.Tree, ChainApproxMethod.ChainApproxNone);

                    if (contours.Size > 0)
                    {
                        for (int ii = 0; ii < contours.Size; ii++)
                        {
                            MCvScalar color = new MCvScalar(0, 0, 255);

                            double a = CvInvoke.ContourArea(contours[ii], false);  //  Find the area of contour
                            if (a > largest_area)
                            {
                                largest_area = a;
                                largest_contour_index = ii;                //Store the index of largest contour
                            }
                        }


                        //draw largest contour
                        CvInvoke.DrawContours(resultMatrix, contours, largest_contour_index, new MCvScalar(255, 255, 255), 1, LineType.EightConnected, hierachy);
                        largestContour = new VectorOfPoint(contours[largest_contour_index].ToArray());


                        //Image<Bgr, Byte> colorOutput = resultMatrix.ToImage<Bgr, Byte>();

                        //Find center point
                        MCvMoments m = CvInvoke.Moments(largestContour, true);
                        MCvPoint2D64f center = m.GravityCenter;
                        resultMatrix.Draw(new Cross2DF(new PointF((float)center.X, (float)center.Y), 3, 3), new Bgr(0, 0, 255), 2);
                        
                        //Find Bounding Rectangle
                        RotatedRect rect = CvInvoke.MinAreaRect(largestContour);
                        resultMatrix.Draw(rect, new Bgr(255, 0, 0), 2);
                        

                        //save and display
                        outputBmp = resultMatrix.ToBitmap();
                        pbSide2.Image = outputBmp;
                        //outputBmp.Dispose();
                    }


                }


            }
        }

    }
}
