using Numerology.BL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Numerology.UI
{
    public partial class PersonalYearForm : Form
    {
        private readonly bool local = false;
        private const int YEARS_BACK = 10;
        private const int YEARS_FORWARD = 10;
        private NumerologyObject numerologyObject = null;
        public PersonalYearForm()
        {
            InitializeComponent();
            InitUI();
            numerologyObject = InitNumerologyObject();
        }
        public PersonalYearForm(bool isLocal) : base()
        {
            local = isLocal;
            InitializeComponent();
            InitUI();
            numerologyObject = InitNumerologyObject();
            if (!local) saveForPrint.Visible = false;
        }

        #region Form events

        private void cmbDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearMonths();
        }
        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearMonths();
        }
        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearMonths();
        }
        private void Panel_Click(object sender, EventArgs e)
        {
            TagObject tag = null;
            var panel = sender as Panel;
            var label = sender as Label;
            if (panel != null) tag = panel.Tag as TagObject;
            else if (label != null) tag = label.Tag as TagObject;
            else { MessageBox.Show("Sender is not a Panel or Label."); }

            if (tag != null)
            {
                using (PersonalMonthForm personalMonth = new PersonalMonthForm(tag, this.local))
                {
                    personalMonth.WindowState = FormWindowState.Normal;
                    personalMonth.StartPosition = FormStartPosition.CenterParent;

                    if (personalMonth.ShowDialog() == DialogResult.OK) { }
                }
            }
            else
            {
                MessageBox.Show("Tag object is missing.");
            }
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
        #endregion Form events

        private string GetNameForScreenshot()
        {

            var day = DateOfBirthObject.GetString(GetCmbSelectedValue(cmbDate), 2);
            var month = DateOfBirthObject.GetString(GetCmbSelectedValue(cmbMonth), 2);
            var year = DateOfBirthObject.GetString(GetCmbSelectedValue(cmbYear), 4);

            var dateString = day + "_" + month + "_" + year;

            return "PersonalYear_" + dateString;
        }
        private void btnGo_Click(object sender, EventArgs e)
        {
            var day = GetCmbSelectedValue(cmbDate);
            var month = GetCmbSelectedValue(cmbMonth);
            var year = GetCmbSelectedValue(cmbYear);
            if (day > 0 && month > 0 && year > 0)
            {
                if (!CheckDate(day, month, year))
                {
                    MessageBox.Show("Несуществующая комбинация дня,месяца и года.");
                    return;
                }
                numerologyObject.DOBObject.SetDate(day, month, year);

                SetYearValueToUI();
                AllocateMonths(numerologyObject.DOBObject.GetLifeWayNumber, numerologyObject.DOBObject.GetLifeWayNumberExtended, year);
            }
        }
        private void InitUI()
        {
            // DOB
            // Days
            cmbDate.DataSource = null;
            cmbDate.DataSource = GetDays();

            // Months
            cmbMonth.DataSource = null;
            cmbMonth.DisplayMember = "Name";
            cmbMonth.ValueMember = "Id";
            cmbMonth.DataSource = GetMonths();

            // Years
            cmbYear.DataSource = null;
            cmbYear.DataSource = GetYears();
            cmbYear.SelectedItem = (object)DateTime.Now.Year;

            lblPersonalYearSimple.Text = "";
            lblPersonalYearExtended.Text = "";
        }
        private void ClearMonths()
        {
            pnlPersonalMonthBase.Controls.Clear();
        }
        private List<int> GetDays()
        {
            var days = new List<int>();
            for (int i = 1; i < 32; i++)
            {
                days.Add(i);
            }
            return days;
        }
        private List<Month> GetMonths()
        {
            var months = new List<Month>();

            months.Add(new Month() { Id = 1, Name = "Январь" });
            months.Add(new Month() { Id = 2, Name = "Февраль" });
            months.Add(new Month() { Id = 3, Name = "Март" });
            months.Add(new Month() { Id = 4, Name = "Апрель" });
            months.Add(new Month() { Id = 5, Name = "Май" });
            months.Add(new Month() { Id = 6, Name = "Июнь" });
            months.Add(new Month() { Id = 7, Name = "Июль" });
            months.Add(new Month() { Id = 8, Name = "Август" });
            months.Add(new Month() { Id = 9, Name = "Сентябрь" });
            months.Add(new Month() { Id = 10, Name = "Октябрь" });
            months.Add(new Month() { Id = 11, Name = "Ноябрь" });
            months.Add(new Month() { Id = 12, Name = "Декабрь" });

            return months;
        }
        private List<int> GetYears()
        {
            var startingYear = DateTime.Now.Year - YEARS_BACK;
            var years = new List<int>();
            for (int i = startingYear; i <= DateTime.Now.Year + YEARS_FORWARD; i++)
            {
                years.Add(i);
            }
            return years;
        }
        private int GetCmbSelectedValue(ComboBox cmb)
        {
            if (cmb != null && cmb.SelectedValue != null)
            {
                return (int)cmb.SelectedValue;
            }
            return -1;
        }
        private bool CheckDate(int day, int month, int year)
        {
            try { var date = new DateTime(year, month, day); }
            catch { return false; }
            return true;
        }
        private NumerologyObject InitNumerologyObject()
        {
            return Manager.InitNumerologyObject();
        }
        private void SetYearValueToUI()
        {
            if (local)
            {
                lblPersonalYearSimple.Text = numerologyObject.DOBObject.GetLifeWayNumberString;

                lblPersonalYearExtended.Visible = true;
                lblPersonalYearExtended.Text = numerologyObject.DOBObject.GetLifeWayNumberExtendedString;
            }
            else
            {
                lblPersonalYearExtended.Visible = false;
                lblPersonalYearSimple.Text = numerologyObject.DOBObject.GetLifeWayNumberString;
            }
        }
        private void AllocateMonths(int yearSimple, int yearExtended, int targetYear)
        {
            var firstPanelBorderWidth = 1;
            var firstPanelSize = GetMonthFirstPanelSize(pnlPersonalMonthBase.Size, firstPanelBorderWidth);
            var secondTopPanelSize = GetMonthSecondTopPanelSize(firstPanelSize);
            var secondBottomPanelSize = GetMonthSecondBottomPanelSize(firstPanelSize);

            var fontFamilyName = "";
            float secondTopPanelFontSize = 14;

            var sourceDay = GetCmbSelectedValue(cmbDate);
            var sourceMonth = GetCmbSelectedValue(cmbMonth);

            var monthes = GetMonths();
            for (int i = 1; i <= monthes.Count; i++)
            {
                // 3 x 4
                var row = GetRow(i);// y
                var col = GetColumn(i);// x
                var simpleMonth = Int32.Parse(NarrowToOneNumber((Int32.Parse(NarrowToOneNumber(monthes[i - 1].Id.ToString())) + yearSimple).ToString()));
                var extendedMonth = monthes[i - 1].Id + yearExtended;

                var secondTopPanel = new Label();
                secondTopPanel.Size = secondTopPanelSize;
                secondTopPanel.Location = new Point(0, 0);
                secondTopPanel.BackColor = Color.White;
                secondTopPanel.ForeColor = Color.Black;
                secondTopPanel.TextAlign = ContentAlignment.MiddleCenter;
                secondTopPanel.Font = new Font(fontFamilyName, secondTopPanelFontSize, FontStyle.Bold);
                secondTopPanel.Text = monthes[i - 1].Name;
                secondTopPanel.Tag = new TagObject(sourceDay, sourceMonth, monthes[sourceMonth - 1].Name, i, monthes[i - 1].Name, targetYear, simpleMonth, extendedMonth);
                secondTopPanel.Click += Panel_Click;

                var secondBottomSimplePanel = new Label();
                secondBottomSimplePanel.Size = secondBottomPanelSize;
                secondBottomSimplePanel.Location = GetSecondBottomSimpleLocation(firstPanelSize, secondBottomPanelSize, local);
                secondBottomSimplePanel.BackColor = Color.White;
                secondBottomSimplePanel.ForeColor = Color.Black;
                secondBottomSimplePanel.TextAlign = ContentAlignment.MiddleCenter;
                secondBottomSimplePanel.Font = new Font(fontFamilyName, secondTopPanelFontSize, FontStyle.Bold);
                secondBottomSimplePanel.Text = simpleMonth.ToString();
                secondBottomSimplePanel.Tag = new TagObject(sourceDay, sourceMonth, monthes[sourceMonth - 1].Name, i, monthes[i - 1].Name, targetYear, simpleMonth, extendedMonth);
                secondBottomSimplePanel.Click += Panel_Click;

                var secondBottomExtendedPanel = new Label();
                secondBottomExtendedPanel.Size = secondBottomPanelSize;
                secondBottomExtendedPanel.Location = GetSecondBottomExtendedLocation(firstPanelSize);
                secondBottomExtendedPanel.BackColor = Color.White;
                secondBottomExtendedPanel.ForeColor = Color.Red;
                secondBottomExtendedPanel.TextAlign = ContentAlignment.MiddleCenter;
                secondBottomExtendedPanel.Font = new Font(fontFamilyName, secondTopPanelFontSize, FontStyle.Bold);
                secondBottomExtendedPanel.Text = extendedMonth.ToString();
                secondBottomExtendedPanel.Tag = new TagObject(sourceDay, sourceMonth, monthes[sourceMonth - 1].Name, i, monthes[i - 1].Name, targetYear, simpleMonth, extendedMonth);
                secondBottomExtendedPanel.Click += Panel_Click;

                var firstPanelLocation = GetMonthFirstPanelLocation(col, row, firstPanelSize, firstPanelBorderWidth);

                var firstPanel = new Panel();
                firstPanel.Size = firstPanelSize;
                firstPanel.Location = firstPanelLocation;
                firstPanel.BackColor = Color.White;
                firstPanel.Tag = new TagObject(sourceDay, sourceMonth, monthes[sourceMonth - 1].Name, i, monthes[i - 1].Name, targetYear, simpleMonth, extendedMonth);
                firstPanel.Click += Panel_Click;
                firstPanel.Controls.Add(secondTopPanel);
                firstPanel.Controls.Add(secondBottomSimplePanel);
                if (local) firstPanel.Controls.Add(secondBottomExtendedPanel);

                pnlPersonalMonthBase.Controls.Add(firstPanel);
            }
        }
        private int GetRow(int index)
        {
            var row = 0;
            if (index >= 1 && index <= 4) row = 1;
            else if (index >= 5 && index <= 8) row = 2;
            else if (index >= 9 && index <= 12) row = 3;

            return row;
        }
        private int GetColumn(int index)
        {
            var col = 0;
            if (index == 1 || index == 5 || index == 9) col = 1;
            else if (index == 2 || index == 6 || index == 10) col = 2;
            else if (index == 3 || index == 7 || index == 11) col = 3;
            else if (index == 4 || index == 8 || index == 12) col = 4;

            return col;
        }
        private Size GetMonthFirstPanelSize(Size size, int firstPanelBorderWidth)
        {
            return new Size(
                (size.Width - (4 * 2 * firstPanelBorderWidth)) / 4,
                (size.Height - (3 * 2 * firstPanelBorderWidth)) / 3);
        }
        private Point GetMonthFirstPanelLocation(int x, int y, Size size, int firstPanelBorderWidth)
        {
            return new Point(
                ((size.Width + firstPanelBorderWidth * 2) * (x - 1)) + firstPanelBorderWidth,
                ((size.Height + firstPanelBorderWidth * 2) * (y - 1)) + firstPanelBorderWidth);
        }
        private Size GetMonthSecondTopPanelSize(Size size)
        {
            return new Size(size.Width, size.Height / 2);
        }
        private Size GetMonthSecondBottomPanelSize(Size size)
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
