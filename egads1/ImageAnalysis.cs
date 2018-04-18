using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using System.Drawing;

namespace egads1
{
    class ImageAnalysis
    {
        private VectorOfVectorOfPoint mContours;
        private int mLargestContourIndex;
        private VectorOfPoint mLargestContour;
        private MCvPoint2D64f mCenter;
        private double mArea;
        private RotatedRect mBoundingBox;
        private float mLength;
        private float mWidth;
        private double mRatio;
        private Bitmap result;

        public ImageAnalysis()
        {

        }

        public ImageAnalysis(VectorOfVectorOfPoint contours,
            int largestContourIndex,
            VectorOfPoint largestContour,
            MCvPoint2D64f center,
            double area,
            RotatedRect boundingBox,
            float length,
            float width,
            double ratio)
        {
            mContours = contours;
            mLargestContourIndex = largestContourIndex;
            mLargestContour = largestContour;
            mCenter = center;
            mArea = area;
            mBoundingBox = boundingBox;
            mLength = length;
            mWidth = width;
            mRatio = ratio;
        }

        public VectorOfVectorOfPoint Contours { get => mContours; set => mContours = value; }
        public int LargestContourIndex { get => mLargestContourIndex; set => mLargestContourIndex = value; }
        public VectorOfPoint LargestContour { get => mLargestContour; set => mLargestContour = value; }
        public MCvPoint2D64f Center { get => mCenter; set => mCenter = value; }
        public double Area { get => mArea; set => mArea = value; }
        public RotatedRect BoundingBox { get => mBoundingBox; set => mBoundingBox = value; }
        public float Length { get => mLength; set => mLength = value; }
        public float Width { get => mWidth; set => mWidth = value; }
        public double Ratio { get => mRatio; set => mRatio = value; }
        public Bitmap Result { get => result; set => result = value; }
    }
}
