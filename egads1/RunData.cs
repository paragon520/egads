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

        List<ImageAnalysis> store;
        string outputFile;
        decimal pxPerCm;


        public RunData()
        {
            store = new List<ImageAnalysis>();
            outputFile = "data.csv";
            pxPerCm = 296.3M;
        }

        public void setOutputFile(string file)
        {
            outputFile = file;
        }

        public void add(ImageAnalysis ia)
        {
            store.Add(ia);
        }

        public void close()
        {
            string data = "Width(mm),Length(mm),Area(mm2),Ratio\n";
            foreach (ImageAnalysis ia in store)
            {
                data += convertPxToMm(ia.Width) + "," + convertPxToMm(ia.Length) + "," + convertSqPxToSqMm(ia.Area) + "," + ia.Ratio + "\n";
            }

            try
            {
                File.AppendAllText(outputFile, data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("File error. Try changing the file name and clicking Stop again \n\n" + ex.Message);
            }
        }

        private decimal convertPxToMm(float pixels)
        {
            return Math.Round((decimal)pixels / pxPerCm * 100, 3);

        }

        private decimal convertSqPxToSqMm(double pixels)
        {
            decimal sqPxPerSqCm = pxPerCm * pxPerCm;

            return Math.Round((decimal)pixels / sqPxPerSqCm * 10000, 3);
        }

    }
}
