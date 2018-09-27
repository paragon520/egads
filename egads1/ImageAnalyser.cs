using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;

namespace egads1
{
    class ImageAnalyser
    {
        private int maskHueUpper = 10;
        private int maskHueLower = 55;
        private int maskSatUpper = 60;
        private int maskSatLower = 250;
        private int maskLumUpper = 95;
        private int maskLumLower = 255;

        private double triggerThresh = 30.0;
        private double areaThresh = 3000.0;
        private int grayThresh = 62;
        private int maskLightLower = 85;
        private int maskLightUpper = 255;
        private int maskALower = 0;
        private int maskAUpper = 255;
        private int maskBLower = 120;
        private int maskBUpper = 255;


        public ImageAnalyser()
        {

        }

        public ImageAnalysis analyse(Bitmap frame)
        {
            return analyse(frame, triggerThresh, grayThresh, maskLightLower, maskLightUpper, maskALower, maskAUpper, maskBLower, maskBUpper);
        }
        
        public ImageAnalysis analyse(Bitmap frame, double triggerThresh, int grayThresh, int lLow, int lHigh, int aLow, int aHigh, int bLow, int bHigh)
        {
            ImageAnalysis analysis = new ImageAnalysis();

            Image<Gray, Byte> grayFrame = new Image<Gray, Byte>(frame);
            double trigger = grayFrame.GetAverage().Intensity;

            if (trigger > triggerThresh)
            {
                CvInvoke.Threshold(grayFrame, grayFrame, grayThresh, 255, ThresholdType.Binary);

                Bitmap outputBmp = grayFrame.ToBitmap();
                //pbMain.Image = outputBmp;


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
                        
                        if (largest_area > areaThresh)
                        {
                            //draw largest contour
                            CvInvoke.DrawContours(resultMatrix, contours, largest_contour_index, new MCvScalar(255, 255, 255), 1, LineType.EightConnected, hierachy);
                            largestContour = new VectorOfPoint(contours[largest_contour_index].ToArray());

                            //Find center point
                            MCvMoments m = CvInvoke.Moments(largestContour, true);
                            MCvPoint2D64f center = m.GravityCenter;
                            //textBox1.AppendText("Center point: " + Math.Round(center.X, 3) + "px, " + Math.Round(center.Y, 3) + "px\n");
                            resultMatrix.Draw(new Cross2DF(new PointF((float)center.X, (float)center.Y), 3, 3), new Bgr(0, 0, 255), 2);

                            //Find Bounding Rectangle
                            RotatedRect rect = CvInvoke.MinAreaRect(largestContour);
                            resultMatrix.Draw(rect, new Bgr(255, 0, 0), 2);

                            //save and display


                            double area = CvInvoke.ContourArea(largestContour);
                            float width0 = rect.Size.Width;
                            float height0 = rect.Size.Height;
                            float length = (height0 >= width0 ? height0 : width0);
                            float width = (height0 < width0 ? height0 : width0);
                            double ratio = Math.Round((length / width), 3);
                            if (length > 132)
                            {
                                //resultMatrix.Save(fileName + "_after.bmp");
                                analysis.Contours = contours;
                                analysis.LargestContourIndex = largest_contour_index;
                                analysis.LargestContour = largestContour;
                                analysis.Center = center;
                                analysis.Area = area;
                                analysis.BoundingBox = rect;
                                analysis.Length = length;
                                analysis.Width = width;
                                analysis.Ratio = ratio;

                                outputBmp = resultMatrix.ToBitmap();
                                analysis.Result = outputBmp;
                            }

                            //pbMain2.Image = outputBmp;
                        }
                    }
                }
            }
            return analysis;
        }

        public ImageAnalysis analyse1(string frame)
        {
            return analyse1(frame, maskLightLower, maskLightUpper, maskALower, maskAUpper, maskBLower, maskBUpper);
        }

        public ImageAnalysis analyse1(string fileName, int lLow, int lHigh, int aLow, int aHigh, int bLow, int bHigh)
        {
            ImageAnalysis analysis = new ImageAnalysis();

            Mat tempMat = new Mat(fileName);

            // pixel mask, erode x2, dilate x2
            //CvInvoke.GaussianBlur(mat, mat, new Size(5, 5), 1.5, 1.5);
            //CvInvoke.GaussianBlur(mat, mat, new Size(5, 5), 1.5, 1.5);
            //GetColorPixelMask(tempMat, tempMat, maskHueUpper, maskHueLower, maskSatUpper, maskSatLower, maskLumUpper, maskLumLower);
            GetLabColorPixelMask(tempMat, tempMat, lLow, lHigh, aLow, aHigh, bLow, bHigh);
            //tempMat.Save(fileName + "temp.jpg");

            CvInvoke.Erode(tempMat, tempMat, null, new Point(-1, -1), 2, BorderType.Constant, CvInvoke.MorphologyDefaultBorderValue);
            Mat temp = new Mat();
            CvInvoke.Dilate(tempMat, temp, null, new Point(-1, -1), 2, BorderType.Constant, CvInvoke.MorphologyDefaultBorderValue);
            tempMat = temp;

            //find largest contour
            Mat result = new Mat(540, 720, 0, 1);
            int largest_contour_index = 0;
            double largest_area = 0;
            VectorOfPoint largestContour;

            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat hierachy = new Mat();
            CvInvoke.FindContours(tempMat, contours, hierachy, RetrType.Tree, ChainApproxMethod.ChainApproxNone);

            if (contours.Size > 0)
            {
                for (int i = 0; i < contours.Size; i++)
                {
                    MCvScalar color = new MCvScalar(0, 0, 255);

                    double a = CvInvoke.ContourArea(contours[i], false);  //  Find the area of contour
                    if (a > largest_area)
                    {
                        largest_area = a;
                        largest_contour_index = i;                //Store the index of largest contour
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
                double area = CvInvoke.ContourArea(largestContour);
                //textBox1.AppendText("Area: " + area + "px,     " + convertSqPxToSqMm(area) + "sq mm\n");

                //Find Bounding Rectangle
                RotatedRect rect = CvInvoke.MinAreaRect(largestContour);
                float width0 = rect.Size.Width;
                float height0 = rect.Size.Height;

                float length = (height0 >= width0 ? height0 : width0);
                float width = (height0 < width0 ? height0 : width0);

                tempImg.Draw(rect, new Bgr(255, 0, 0), 2);
                //textBox1.AppendText("Width: " + width + "px  Length: " + length + "px\n");
                //textBox1.AppendText("Width: " + convertPxToMm(width) + "mm  Length: " + convertPxToMm(length) + "mm\n");

                double ratio = Math.Round((length / width), 3);
                //textBox1.AppendText("Ratio (width:length): 1:" + ratio + "\n");

                //save and display
                tempImg.Save(fileName + "_after.bmp");
                tempMat = tempImg.Mat;

                analysis.Contours = contours;
                analysis.LargestContourIndex = largest_contour_index;
                analysis.LargestContour = largestContour;
                analysis.Center = center;
                analysis.Area = area;
                analysis.BoundingBox = rect;
                analysis.Length = length;
                analysis.Width = width;
                analysis.Ratio = ratio;
                analysis.Result = tempImg.ToBitmap();

            }


            return analysis;
        }

        /// <summary>
        /// Compute the red pixel mask for the given image. 
        /// A red pixel is a pixel where:  20 &lt; hue &lt; 160 AND saturation &gt; 10
        /// </summary>
        /// <param name="image">The color image to find red mask from</param>
        /// <param name="mask">The red pixel mask</param>
        private static void GetColorPixelMask(IInputArray image, IInputOutputArray mask, int hueLower, int hueUpper, int satLower, int satUpper, int lumLower, int lumUpper)
        {
            bool useUMat;
            using (InputOutputArray ia = mask.GetInputOutputArray())
                useUMat = ia.IsUMat;

            using (IImage hsv = useUMat ? (IImage)new UMat() : (IImage)new Mat())
            using (IImage s = useUMat ? (IImage)new UMat() : (IImage)new Mat())
            using (IImage lum = useUMat ? (IImage)new UMat() : (IImage)new Mat())
            {
                CvInvoke.CvtColor(image, hsv, ColorConversion.Bgr2Hsv);
                CvInvoke.ExtractChannel(hsv, mask, 0);
                CvInvoke.ExtractChannel(hsv, s, 1);
                CvInvoke.ExtractChannel(hsv, lum, 2);

                //the mask for hue less than 20 or larger than 160
                using (ScalarArray lower = new ScalarArray(hueLower))
                using (ScalarArray upper = new ScalarArray(hueUpper))
                    CvInvoke.InRange(mask, lower, upper, mask);
                //CvInvoke.BitwiseNot(mask, mask); //invert results to "round the corner" of the hue scale

                //s is the mask for saturation of at least 10, this is mainly used to filter out white pixels
                CvInvoke.Threshold(s, s, satLower, satUpper, ThresholdType.Binary);
                CvInvoke.BitwiseAnd(mask, s, mask, null);

                // mask luminosity
                CvInvoke.Threshold(lum, lum, lumLower, lumUpper, ThresholdType.Binary);
                CvInvoke.BitwiseAnd(mask, lum, mask, null);

            }
        }


        private static void GetLabColorPixelMask(IInputArray image, IInputOutputArray mask, int lightLower, int lightUpper, int aLower, int aUpper, int bLower, int bUpper)
        {
            bool useUMat;
            using (InputOutputArray ia = mask.GetInputOutputArray())
                useUMat = ia.IsUMat;

            using (IImage lab = useUMat ? (IImage)new UMat() : (IImage)new Mat())
            using (IImage l = useUMat ? (IImage)new UMat() : (IImage)new Mat())
            using (IImage a = useUMat ? (IImage)new UMat() : (IImage)new Mat())
            using (IImage b = useUMat ? (IImage)new UMat() : (IImage)new Mat())
            {
                CvInvoke.CvtColor(image, lab, ColorConversion.Bgr2Lab);
                CvInvoke.ExtractChannel(lab, mask, 0);
                CvInvoke.ExtractChannel(lab, a, 1);
                CvInvoke.ExtractChannel(lab, b, 2);

                //threshold on lightness
                //CvInvoke.Threshold(lab, l, lightLower, lightUpper, ThresholdType.Binary);
                //CvInvoke.BitwiseAnd(mask, s, mask, null);

                using (ScalarArray lower = new ScalarArray(lightLower))
                using (ScalarArray upper = new ScalarArray(lightUpper))
                    CvInvoke.InRange(mask, lower, upper, mask);

                //threshold on A colorspace and merge L and A into Mask
                CvInvoke.Threshold(a, a, aLower, aUpper, ThresholdType.Binary);
                CvInvoke.BitwiseAnd(mask, a, mask, null);

                //threshold on B colorspace and merge B into previous Mask
                CvInvoke.Threshold(b, b, bLower, bUpper, ThresholdType.Binary);
                CvInvoke.BitwiseAnd(mask, b, mask, null);

            }
        }

    }
}
