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

        private double mCrossSectionArea;
        private float mLength;
        private float mWidth;
        private float mDepth;
        private double mVolume;

        public double CrossSectionArea { get => mCrossSectionArea; set => mCrossSectionArea = value; }
        public float Length { get => mLength; set => mLength = value; }
        public float Width { get => mWidth; set => mWidth = value; }
        public float Depth { get => mDepth; set => mDepth = value; }
        public double Volume { get => mVolume; set => mVolume = value; }

        public GrainAnalysis()
        {

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
            mLength = (mainImage.Length >= sideImage.Length) ? mainImage.Length : sideImage.Length;

            if (mainImage.Width >= sideImage.Width)
            {
                mWidth = mainImage.Width;
                mDepth = sideImage.Width;
            }
            else
            {
                mWidth = sideImage.Width;
                mDepth = mainImage.Width;
            }

            mCrossSectionArea = (mainImage.Area >= sideImage.Area) ? mainImage.Area : sideImage.Area;

            // TODO: make this better. grain kernels arent rectangular solids.
            //mVolume = mLength * mWidth * mDepth;

            //Volume of an ellipsoid = 4/3 * pi * radii a*b*c
            mVolume = (4 / 3) * Math.PI * (mLength / 2) * (mWidth / 2) * (mDepth / 2);
        }


    }
}
