using Numerology.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numerology.UI
{
    public partial class ChartForm : Form
    {
        private const string CUSTOMER_FOLDER_NAME = "Customers";
        private NumerologyObject numerologyObject = null;
        private Comparison comparison = null;
        private const int CUSTOMER_ESTIMATED_LIFE_EXPECTATION = 100;

        public ChartForm()
        {
            InitializeComponent();
            numerologyObject = InitNumerologyObject();
            openFileDialog1.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, CUSTOMER_FOLDER_NAME);
        }
        private NumerologyObject InitNumerologyObject()
        {
            return Manager.InitNumerologyObject();
        }

        private void btnSelectPerson_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fullPath = openFileDialog1.FileName;
                txbFile.Text = Path.GetFileName(fullPath);

                comparison = numerologyObject.ReadPersonalData(fullPath);
                var peaks = CalculateLifePeaks(comparison.DOB, CUSTOMER_ESTIMATED_LIFE_EXPECTATION);
                ShowComparison(peaks);
            }
        }
        private List<Peak> CalculateLifePeaks(DateTime birthDate, int lifeExpectation)
        {
            List<Peak> peaks = new List<Peak>();

            Func<DateTime, int> MultiplyValues = delegate (DateTime dob)
            {
                return (dob.Day * dob.Month * dob.Year);
            };

            int calculatedYears = 0;
            int index = 0;
            var step = 5;
            int year = birthDate.Year;

            var peak = new Peak() { Index = index, X = 0, Y = 0 };
            peaks.Add(peak);

            while (calculatedYears < lifeExpectation)
            {
                var multiplied = MultiplyValues(new DateTime(year, birthDate.Month, birthDate.Day));
                var multipliedString = multiplied.ToString();
                char[] parts = multipliedString.ToCharArray();

                for (int i = 0; i < parts.Length; i++)
                {
                    index++;
                    calculatedYears = index * step;
                    peak = new Peak() { Index = index, X = calculatedYears, Y = Int32.Parse(parts[i].ToString()) };
                    peaks.Add(peak);
                }
                year = birthDate.AddYears(calculatedYears).Year;
            }

            return peaks;
        }
        private void ShowComparison(List<Peak> peaks)
        {            
            chrPeaks.Series["Peaks"].Points.Clear();
            foreach (var item in peaks) chrPeaks.Series["Peaks"].Points.AddXY(item.X, item.Y);
        }
    }

    public struct Peak
    {
        public int Index;
        public int X;
        public int Y;
    }
}
