using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace egads1
{
    class GrainAnalysis
    {
        private ImageAnalysis mainImage;
        private ImageAnalysis sideImage;
        double pxPerCm;

        private double mCrossSectionArea;
        private double mLength;
        private double mWidth;
        private double mDepth;
        private double mVolume;

        public double CrossSectionArea { get => mCrossSectionArea; set => mCrossSectionArea = value; }
        public double Length { get => mLength; set => mLength = value; }
        public double Width { get => mWidth; set => mWidth = value; }
        public double Depth { get => mDepth; set => mDepth = value; }
        public double Volume { get => mVolume; set => mVolume = value; }

        public GrainAnalysis()
        {
            pxPerCm = 239;

        }

        public Boolean MainIsSet()
        {
            return (mainImage != null);
        }

        public Boolean SideIsSet()
        {
            return (sideImage != null);
        }

        public void setMain(ImageAnalysis ia)
        {
            mainImage = ia;
        }

        public void setSide(ImageAnalysis ia)
        {
            sideImage = ia;
        }

        public void analyse()
        {
            mLength = convertPxToMm((mainImage.Length >= sideImage.Length) ? mainImage.Length : sideImage.Length);

            if (mainImage.Width >= sideImage.Width)
            {
                mWidth = convertPxToMm(mainImage.Width);
                mDepth = convertPxToMm(sideImage.Width);
            }
            else
            {
                mWidth = convertPxToMm(sideImage.Width);
                mDepth = convertPxToMm(mainImage.Width);
            }

            mCrossSectionArea = convertSquarePxToSquareMm((mainImage.Area >= sideImage.Area) ? mainImage.Area : sideImage.Area);

            // TODO: make this better. grain kernels arent rectangular solids.
            //mVolume = mLength * mWidth * mDepth;

            //Volume of an ellipsoid = 4/3 * pi * radii a*b*c
            mVolume = (4D / 3D) * Math.PI * (mLength / 2D) * (mWidth / 2D) * (mDepth / 2D);
        }


        private double convertPxToMm(float pixels)
        {
            return Math.Round((double)pixels / pxPerCm * 10, 3);

        }

        private double convertSquarePxToSquareMm(double pixels)
        {
            double sqPxPerSqCm = pxPerCm * pxPerCm;

            return Math.Round((double)pixels / sqPxPerSqCm * 100, 3);
        }

        private double convertCubicPxToCubicMm(double pixels)
        {
            double cbPxPerCbCm = pxPerCm * pxPerCm * pxPerCm;

            return Math.Round((double)pixels / cbPxPerCbCm * 1000, 3);
        }

    }
}
