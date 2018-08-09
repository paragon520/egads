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

        private Image<Bgr, Byte> blankFrame;
        private Bitmap currentFrame;



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
                    processFrame(icMain.ImageActiveBuffer.Bitmap);
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

        private void icSide_ImageAvailable(object sender, TIS.Imaging.ICImagingControl.ImageAvailableEventArgs e)
        {
            if (icSide.InvokeRequired)
                icSide.Invoke(new icSide_ImageAvailable_delegate(icSide_ImageAvailable), sender, e);
            else
            {
                try
                {
                    icSide.ImageActiveBuffer.SaveAsBitmap(TEMPIMAGESIDE);
                    controller.imageAvailableSide(TEMPIMAGESIDE);
                }
                catch (Exception ex)
                {
                    icSide.ImageActiveBuffer.SaveAsBitmap(TEMPIMAGESIDE2);
                    controller.imageAvailableSide(TEMPIMAGESIDE2);
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



        private void processFrame(Bitmap i)
        {
            Bitmap temp0 = (Bitmap)i.Clone();
            Image<Gray, Byte> temp = new Image<Gray, Byte>(temp0);
            temp0.Dispose();

            //if (blankFrame == null) blankFrame = temp.Clone();
            //else
            //{
            //    CvInvoke.AbsDiff(blankFrame, temp, output);
            //}


            double average = temp.GetAverage().Intensity;
            //displayData(average.ToString());

            if (average > 30.0)
            {
                CvInvoke.Threshold(temp, temp, 62, 255, ThresholdType.Binary);

                temp0 = temp.ToBitmap();
                pictureBox1.Image = temp0;


                //find largest contour
                Mat result = new Mat(540, 720, 0, 1);
                int largest_contour_index = 0;
                double largest_area = 0;
                VectorOfPoint largestContour;

                VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                Mat hierachy = new Mat();
                CvInvoke.FindContours(temp, contours, hierachy, RetrType.Tree, ChainApproxMethod.ChainApproxNone);

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

                        //CvInvoke.DrawContours(result, contours, largest_contour_index, new MCvScalar(255, 0, 0));
                    }


                    //draw largest contour
                    CvInvoke.DrawContours(result, contours, largest_contour_index, new MCvScalar(255, 255, 255), 1, LineType.EightConnected, hierachy);
                    largestContour = new VectorOfPoint(contours[largest_contour_index].ToArray());


                    Image<Bgr, Byte> tempImg = result.ToImage<Bgr, Byte>();

                    //Find center point
                    MCvMoments m = CvInvoke.Moments(largestContour, true);
                    MCvPoint2D64f center = m.GravityCenter;
                    //textBox1.AppendText("Center point: " + Math.Round(center.X, 3) + "px, " + Math.Round(center.Y, 3) + "px\n");
                    tempImg.Draw(new Cross2DF(new PointF((float)center.X, (float)center.Y), 3, 3), new Bgr(0, 0, 255), 2);

                    //Find Area
                    //double area = CvInvoke.ContourArea(largestContour);
                    //textBox1.AppendText("Area: " + area + "px,     " + convertSqPxToSqMm(area) + "sq mm\n");

                    //Find Bounding Rectangle
                    RotatedRect rect = CvInvoke.MinAreaRect(largestContour);
                    //float width0 = rect.Size.Width;
                    // height0 = rect.Size.Height;

                    //float length = (height0 >= width0 ? height0 : width0);
                    //float width = (height0 < width0 ? height0 : width0);

                    tempImg.Draw(rect, new Bgr(255, 0, 0), 2);
                    //textBox1.AppendText("Width: " + width + "px  Length: " + length + "px\n");
                    //textBox1.AppendText("Width: " + convertPxToMm(width) + "mm  Length: " + convertPxToMm(length) + "mm\n");

                    //double ratio = Math.Round((length / width), 3);
                    //textBox1.AppendText("Ratio (width:length): 1:" + ratio + "\n");

                    //save and display
                    Bitmap temp1 = tempImg.ToBitmap();
                    pictureBox2.Image = temp1;
                }
            
            }

        }

    }
}
