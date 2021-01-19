using Numerology.BL;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Numerology.UI
{
    public partial class PersonalMonthForm : Form
    {
        private readonly bool local = false;
        private readonly TagObject tag = null;
        public PersonalMonthForm()
        {
            InitializeComponent();
        }
        public PersonalMonthForm(TagObject tagObject, bool isLocal)
        {
            tag = tagObject;
            local = isLocal;

            InitializeComponent();
            this.Text = "Отображён расчет для: " + "Год: " + tag.TargetYear + ". Месяц: " + tag.TargetMonthName;
            this.DialogResult = DialogResult.OK;
            ShowDateToUI(tag);
            AllocateDays(tag);
            if (!local) saveForPrint.Visible = false;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void saveForPrint_Click(object sender, EventArgs e)
        {
            var defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var defaultFilename = GetNameForScreenshot();

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
        private string GetNameForScreenshot()
        {
            var sourceDay = DateOfBirthObject.GetString(tag.SourceDayNumber, 2);
            var year = DateOfBirthObject.GetString(tag.TargetYear, 4);

            return sourceDay + "." + tag.SourceMonthName + "." + year + "-" + tag.TargetMonthName + "." + year;
        }
        private void ShowDateToUI(TagObject tag)
        {
            lblDateValue.Text = DateOfBirthObject.GetString(tag.SourceDayNumber, 2);
            lblMonthValue.Text = tag.SourceMonthName;
            lblYearValue.Text = DateOfBirthObject.GetString(tag.TargetYear, 4);
        }
        private void AllocateDays(TagObject tag)
        {
            var firstPanelBorderWidth = 1;
            var firstPanelSize = GetDaysFirstPanelSize(pnlPersonalDayBase.Size, firstPanelBorderWidth);
            var secondTopPanelSize = GetDaysSecondTopPanelSize(firstPanelSize);
            var secondBottomPanelSize = GetDaysSecondBottomPanelSize(firstPanelSize);

            var fontFamilyName = "";
            float secondTopPanelFontSize = 14;

            var days = DateTime.DaysInMonth(tag.TargetYear, tag.TargetMonthNumber);
            for (int i = 1; i <= days; i++)
            {
                // 5 x 7
                var row = GetRow(i);// y
                var col = GetColumn(i);// x
                var simpleDay = Int32.Parse(NarrowToOneNumber((int.Parse(NarrowToOneNumber(i.ToString())) + tag.MonthSimple).ToString()));
                var extendedDay = i + tag.MonthExtended;

                var secondTopPanel = new Label();
                secondTopPanel.Size = secondTopPanelSize;
                secondTopPanel.Location = new Point(0, 0);
                secondTopPanel.BackColor = Color.White;
                secondTopPanel.ForeColor = Color.Black;
                secondTopPanel.TextAlign = ContentAlignment.MiddleCenter;
                secondTopPanel.Font = new Font(fontFamilyName, secondTopPanelFontSize, FontStyle.Bold);
                secondTopPanel.Text = i.ToString();

                var secondBottomSimplePanel = new Label();
                secondBottomSimplePanel.Size = secondBottomPanelSize;
                secondBottomSimplePanel.Location = GetSecondBottomSimpleLocation(firstPanelSize, secondBottomPanelSize, local);
                secondBottomSimplePanel.BackColor = Color.White;
                secondBottomSimplePanel.ForeColor = Color.Black;
                secondBottomSimplePanel.TextAlign = ContentAlignment.MiddleCenter;
                secondBottomSimplePanel.Font = new Font(fontFamilyName, secondTopPanelFontSize, FontStyle.Bold);
                secondBottomSimplePanel.Text = simpleDay.ToString();

                var secondBottomExtendedPanel = new Label();
                secondBottomExtendedPanel.Size = secondBottomPanelSize;
                secondBottomExtendedPanel.Location = GetSecondBottomExtendedLocation(firstPanelSize);
                secondBottomExtendedPanel.BackColor = Color.White;
                secondBottomExtendedPanel.ForeColor = Color.Red;
                secondBottomExtendedPanel.TextAlign = ContentAlignment.MiddleCenter;
                secondBottomExtendedPanel.Font = new Font(fontFamilyName, secondTopPanelFontSize, FontStyle.Bold);
                secondBottomExtendedPanel.Text = extendedDay.ToString();

                var firstPanelLocation = GetDaysFirstPanelLocation(col, row, firstPanelSize, firstPanelBorderWidth);

                var firstPanel = new Panel();
                firstPanel.Size = firstPanelSize;
                firstPanel.Location = firstPanelLocation;
                firstPanel.BackColor = Color.White;
                firstPanel.Controls.Add(secondTopPanel);
                firstPanel.Controls.Add(secondBottomSimplePanel);
                if (local) firstPanel.Controls.Add(secondBottomExtendedPanel);

                pnlPersonalDayBase.Controls.Add(firstPanel);
            }
        }
        private int GetRow(int index)
        {
            var row = 0;
            if (index >= 1 && index <= 5) row = 1;
            else if (index >= 6 && index <= 10) row = 2;
            else if (index >= 11 && index <= 15) row = 3;
            else if (index >= 16 && index <= 20) row = 4;
            else if (index >= 21 && index <= 25) row = 5;
            else if (index >= 26 && index <= 30) row = 6;
            else if (index >= 31 && index <= 35) row = 7;

            return row;
        }
        private int GetColumn(int index)
        {
            var col = 0;
            if (index == 1 || index == 6 || index == 11 || index == 16 || index == 21 || index == 26 || index == 31) col = 1;
            else if (index == 2 || index == 7 || index == 12 || index == 17 || index == 22 || index == 27) col = 2;
            else if (index == 3 || index == 8 || index == 13 || index == 18 || index == 23 || index == 28) col = 3;
            else if (index == 4 || index == 9 || index == 14 || index == 19 || index == 24 || index == 29) col = 4;
            else if (index == 5 || index == 10 || index == 15 || index == 20 || index == 25 || index == 30) col = 5;

            return col;
        }
        private Size GetDaysFirstPanelSize(Size size, int firstPanelBorderWidth)
        {
            return new Size(
                (size.Width - (5 * 2 * firstPanelBorderWidth)) / 5,
                (size.Height - (7 * 2 * firstPanelBorderWidth)) / 7);
        }
        private Point GetDaysFirstPanelLocation(int x, int y, Size size, int firstPanelBorderWidth)
        {
            return new Point(
                ((size.Width + firstPanelBorderWidth * 2) * (x - 1)) + firstPanelBorderWidth,
                ((size.Height + firstPanelBorderWidth * 2) * (y - 1)) + firstPanelBorderWidth);
        }
        private Size GetDaysSecondTopPanelSize(Size size)
        {
            return new Size(size.Width, size.Height / 2);
        }
        private Size GetDaysSecondBottomPanelSize(Size size)
        {
            return new Size(size.Width / 2, size.Height / 2);
        }
        private Point GetSecondBottomSimpleLocation(Size parentSize, Size childSize, bool local)
        {
            if (local) return new Point((parentSize.Width / 2 - childSize.Width), parentSize.Height / 2);
            else return new Point((parentSize.Width - childSize.Width) / 2, parentSize.Height / 2);
        }
        private Point GetSecondBottomExtendedLocation(Size parentSize)
        {
            return new Point(parentSize.Width / 2, parentSize.Height / 2);
        }
        private string NarrowToOneNumber(string input)
        {
            string result = input;
            while (result.Length > 1)
            {
                result = SimplifyString(result);
            }
            return result;
        }
        private string SimplifyString(string input)
        {
            if (input.Length == 1) return input;

            int result = 0;
            char[] splitted = input.ToCharArray();
            for (int i = 0; i < splitted.Length; i++)
            {
                result += int.Parse(splitted[i].ToString());
            }
            return result.ToString();
        }
    }
}
