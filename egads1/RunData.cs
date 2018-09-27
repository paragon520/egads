using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace egads1
{
    class RunData
    {
        //make this thing hold pairs of imagaAnalysises with timestamps
        // merge the analysis pairs into bigger sets with volume, and stuff
        // will likely need a new data holder class for it.

        //List<ImageAnalysis> store;
        private List<Tuple<double, double, double, double, double>> store;
        //List<Tuple<ImageAnalysis, ImageAnalysis>> newStore;
        //Tuple<ImageAnalysis, ImageAnalysis> currentSet;
        string outputFile;
        decimal pxPerCm;

        public int Length { get => store.Count; }
        public List<Tuple<double, double, double, double, double>> toList { get => store; }

        public RunData()
        {
            //store = new List<ImageAnalysis>();
            store = new List<Tuple<double, double, double, double, double>>();

            outputFile = "data.csv";
            pxPerCm = 239M;
        }

        public void setOutputFile(string file)
        {
            outputFile = file;
        }

        public void add(Tuple<double, double, double, double, double> ia)
        {
            store.Add(ia);
        }

        public bool close()
        {
            //string data = "Width(mm),Length(mm),Area(mm2),Ratio\n"
            string data = "Length(mm),Width(mm),Depth(mm),Area(mm^2),Volume(mm^3)\n";
            foreach (Tuple<double, double, double, double, double> ga in store)
            {
                //data += convertPxToMm(ia.Width) + "," + convertPxToMm(ia.Length) + "," + convertSqPxToSqMm(ia.Area) + "," + ia.Ratio + "\n";
                data += ga.Item1 + "," + ga.Item2 + "," + ga.Item3 + "," + ga.Item4 + ","
                    + ga.Item5 + "\n";
            }

            try
            {
                File.WriteAllText(outputFile, data);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("File error. Try changing the file name and clicking Stop again \n\n" + ex.Message);
                return false;
            }
        }

        private decimal convertPxToMm(float pixels)
        {
            return Math.Round((decimal)pixels / pxPerCm * 10, 3);

        }

        private decimal convertSquarePxToSquareMm(double pixels)
        {
            decimal sqPxPerSqCm = pxPerCm * pxPerCm;

            return Math.Round((decimal)pixels / sqPxPerSqCm * 100, 3);
        }

        private decimal convertCubicPxToCubicMm(double pixels)
        {
            decimal cbPxPerCbCm = pxPerCm * pxPerCm * pxPerCm;

            return Math.Round((decimal)pixels / cbPxPerCbCm * 1000, 3);
        }

    }
}
