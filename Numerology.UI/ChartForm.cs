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

        private void button1_Click(object sender, EventArgs e)
        {
            var defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var defaultFilename = GetNameForScreenshot(comparison) + "_chart";

            saveFileDialog1.InitialDirectory = defaultPath;
            saveFileDialog1.FileName = defaultFilename;
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "Сохранить изображение для печати";
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.SupportMultiDottedExtensions = true;
            saveFileDialog1.DefaultExt = ".jpg";
            var defaultImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(saveFileDialog1.FileName))
                {
                    MessageBox.Show("Имя файла не указано.");
                    return;
                }

                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        defaultImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                        break;

                    case 2:
                        defaultImageFormat = System.Drawing.Imaging.ImageFormat.Bmp;
                        break;

                    case 3:
                        defaultImageFormat = System.Drawing.Imaging.ImageFormat.Gif;
                        break;
                }

                Rectangle bounds = this.Bounds;
                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        System.Threading.Thread.Sleep(1500);
                        g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                    }
                    defaultFilename = Path.Combine(saveFileDialog1.InitialDirectory, saveFileDialog1.FileName);
                    bitmap.Save(defaultFilename, defaultImageFormat);

                    MessageBox.Show("Успешно сохранено.", "Подтверждение", MessageBoxButtons.OK);
                }
            }
        }

        private string GetNameForScreenshot(Comparison comparison)
        {
            var name = "EmptyName";
            var dateString = "";
            if (comparison != null)
            {
                var firstname = comparison.Name;
                var lastname = comparison.Surname;
                name = firstname + "_" + lastname;

                var day = DateOfBirthObject.GetString(comparison.DOB.Day, 2);
                var month = DateOfBirthObject.GetString(comparison.DOB.Month, 2);
                var year = DateOfBirthObject.GetString(comparison.DOB.Year, 4);

                dateString = day + "_" + month + "_" + year;
            }

            return name + "_" + dateString;
        }
    }

    public struct Peak
    {
        public int Index;
        public int X;
        public int Y;
    }
}
