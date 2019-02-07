using Numerology.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Numerology.UI
{
    public partial class frmNumerology : Form
    {
        private const int YEARS_BACK = 100;
        private const int YEARS_FORWARD = 1;
        private const string CUSTOMER_FOLDER_NAME = "Customers";

        private System.Drawing.Color ellipseColor = System.Drawing.Color.Red;
        private int ellipsePenWidth = 2;
        private System.Drawing.Color peakBottomLineColor = System.Drawing.Color.Black;
        private int peakBottomLinePenWidth = 1;

        private NumerologyObject numerologyObject = null;
        private bool openSaved = false;

        private bool isUserInitiatedExit = false;
        private readonly bool local = false;
        public frmNumerology()
        {
#if (YANAONLY)
            local = true;
#endif
            InitializeComponent();
            openFileDialog1.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, CUSTOMER_FOLDER_NAME);

            pnlPeak_1.Paint += PnlPeak_1_Paint;
            pnlPeak_2.Paint += PnlPeak_2_Paint;
            pnlPeak_3.Paint += PnlPeak_3_Paint;
            pnlPeak_4.Paint += PnlPeak_4_Paint;
        }

        #region Form events 
        private void PnlPeak_1_Paint(object sender, PaintEventArgs e)
        {
            DrawPeak1Ellipse(e, ellipseColor, ellipsePenWidth);
            DrawPeak1BottomLine(e, peakBottomLineColor, peakBottomLinePenWidth);
        }
        private void PnlPeak_2_Paint(object sender, PaintEventArgs e)
        {
            DrawPeak2Ellipse(e, ellipseColor, ellipsePenWidth);
            DrawPeak2BottomLine(e, peakBottomLineColor, peakBottomLinePenWidth);
        }
        private void PnlPeak_3_Paint(object sender, PaintEventArgs e)
        {
            DrawPeak3Ellipse(e, ellipseColor, ellipsePenWidth);
            DrawPeak3BottomLine(e, peakBottomLineColor, peakBottomLinePenWidth);
        }
        private void PnlPeak_4_Paint(object sender, PaintEventArgs e)
        {
            DrawPeak4Ellipse(e, ellipseColor, ellipsePenWidth);
            DrawPeak4BottomLine(e, peakBottomLineColor, peakBottomLinePenWidth);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitUI();
            numerologyObject = InitNumerologyObject();

            var customersFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, CUSTOMER_FOLDER_NAME);
            if (!Directory.Exists(customersFolderPath))
            {
                Directory.CreateDirectory(customersFolderPath);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (isUserInitiatedExit || MessageBox.Show("Хотите выйти из программы?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                base.OnClosing(e);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void cmbDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (numerologyObject == null || openSaved) return;
            var cmb = sender as ComboBox;
            if (cmb != null)
            {
                var day = GetCmbSelectedValue(cmbDate);
                var month = GetCmbSelectedValue(cmbMonth);
                var year = GetCmbSelectedValue(cmbYear);
                if (day > 0 && month > 0 && year > 0)
                {
                    if (!CheckDateOfBirth(day, month, year))
                    {
                        MessageBox.Show("Несуществующая комбинация дня,месяца и года.");
                        return;
                    }
                    numerologyObject.DOBObject.SetDateOfBirth(day, month, year);
                    //numerologyObject.NameObject.SetName((Language)Enum.Parse(typeof(Language), cmbLang.SelectedItem.ToString()), txbName.Text.Trim(), txbSurname.Text.Trim(), numerologyObject.DOBObject.GetLifeWayNumber);
                    numerologyObject.NameObject.SetName((Language)Enum.Parse(typeof(Language), cmbLang.SelectedItem.ToString()), txbName.Text.Trim(), txbSurname.Text.Trim(), (Language)Enum.Parse(typeof(Language), cmbLang.SelectedItem.ToString()) == Language.RUS ? txbFathersName.Text.Trim() : null, numerologyObject.DOBObject.GetLifeWayNumber);

                    SetDOBValuesToUI();
                    SetNameValuesToUI();
                    SetMatrixIntersection(Matrix.TwoMatrixAnalisys(numerologyObject.DOBObject.DOBMatrix, numerologyObject.NameObject.NameMatrix));
                }
            }
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (numerologyObject == null || openSaved) return;
            var cmb = sender as ComboBox;
            if (cmb != null)
            {
                var day = GetCmbSelectedValue(cmbDate);
                var month = GetCmbSelectedValue(cmbMonth);
                var year = GetCmbSelectedValue(cmbYear);
                if (day > 0 && month > 0 && year > 0)
                {
                    if (!CheckDateOfBirth(day, month, year))
                    {
                        MessageBox.Show("Несуществующая комбинация дня,месяца и года.");
                        return;
                    }
                    numerologyObject.DOBObject.SetDateOfBirth(day, month, year);
                    //numerologyObject.NameObject.SetName((Language)Enum.Parse(typeof(Language), cmbLang.SelectedItem.ToString()), txbName.Text.Trim(), txbSurname.Text.Trim(), numerologyObject.DOBObject.GetLifeWayNumber);
                    numerologyObject.NameObject.SetName((Language)Enum.Parse(typeof(Language), cmbLang.SelectedItem.ToString()), txbName.Text.Trim(), txbSurname.Text.Trim(), (Language)Enum.Parse(typeof(Language), cmbLang.SelectedItem.ToString()) == Language.RUS ? txbFathersName.Text.Trim() : null, numerologyObject.DOBObject.GetLifeWayNumber);

                    SetDOBValuesToUI();
                    SetNameValuesToUI();
                    SetMatrixIntersection(Matrix.TwoMatrixAnalisys(numerologyObject.DOBObject.DOBMatrix, numerologyObject.NameObject.NameMatrix));
                }
            }
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (numerologyObject == null || openSaved) return;
            var cmb = sender as ComboBox;
            if (cmb != null)
            {
                var day = GetCmbSelectedValue(cmbDate);
                var month = GetCmbSelectedValue(cmbMonth);
                var year = GetCmbSelectedValue(cmbYear);
                if (day > 0 && month > 0 && year > 0)
                {
                    if (!CheckDateOfBirth(day, month, year))
                    {
                        MessageBox.Show("Несуществующая комбинация дня,месяца и года.");
                        return;
                    }
                    numerologyObject.DOBObject.SetDateOfBirth(day, month, year);
                    //numerologyObject.NameObject.SetName((Language)Enum.Parse(typeof(Language), cmbLang.SelectedItem.ToString()), txbName.Text.Trim(), txbSurname.Text.Trim(), numerologyObject.DOBObject.GetLifeWayNumber);
                    numerologyObject.NameObject.SetName((Language)Enum.Parse(typeof(Language), cmbLang.SelectedItem.ToString()), txbName.Text.Trim(), txbSurname.Text.Trim(), (Language)Enum.Parse(typeof(Language), cmbLang.SelectedItem.ToString()) == Language.RUS ? txbFathersName.Text.Trim() : null, numerologyObject.DOBObject.GetLifeWayNumber);

                    SetDOBValuesToUI();
                    SetNameValuesToUI();
                    SetMatrixIntersection(Matrix.TwoMatrixAnalisys(numerologyObject.DOBObject.DOBMatrix, numerologyObject.NameObject.NameMatrix));
                }
            }
        }

        private void btnNameShow_Click(object sender, EventArgs e)
        {
            if (cmbLang.SelectedItem != null && ((Language)Enum.Parse(typeof(Language), cmbLang.SelectedItem.ToString()) == Language.RUS))
            {
                if (string.IsNullOrEmpty(txbName.Text) || string.IsNullOrEmpty(txbSurname.Text) || string.IsNullOrEmpty(txbFathersName.Text))
                {
                    MessageBox.Show("Не введено имя, фамилия или отчество.");
                    return;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(txbName.Text) || string.IsNullOrEmpty(txbSurname.Text))
                {
                    MessageBox.Show("Не введено имя или фамилия.");
                    return;
                }
            }

            var day = GetCmbSelectedValue(cmbDate);
            var month = GetCmbSelectedValue(cmbMonth);
            var year = GetCmbSelectedValue(cmbYear);
            if (day > 0 && month > 0 && year > 0)
            {
                numerologyObject.DOBObject.SetDateOfBirth(day, month, year);
                //numerologyObject.NameObject.SetName((Language)Enum.Parse(typeof(Language), cmbLang.SelectedItem.ToString()), txbName.Text.Trim(), txbSurname.Text.Trim(), numerologyObject.DOBObject.GetLifeWayNumber);
                numerologyObject.NameObject.SetName((Language)Enum.Parse(typeof(Language), cmbLang.SelectedItem.ToString()), txbName.Text.Trim(), txbSurname.Text.Trim(), (Language)Enum.Parse(typeof(Language), cmbLang.SelectedItem.ToString()) == Language.RUS ? txbFathersName.Text.Trim() : null, numerologyObject.DOBObject.GetLifeWayNumber);
                SetNameValuesToUI();
                SetMatrixIntersection(Matrix.TwoMatrixAnalisys(numerologyObject.DOBObject.DOBMatrix, numerologyObject.NameObject.NameMatrix));
            }
        }

        private void cmbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (numerologyObject == null || openSaved) return;

            var selectedLang = (Language)Enum.Parse(typeof(Language), cmbLang.SelectedItem.ToString());
            HandleLanguagesDifference(selectedLang == Language.RUS);
            if (selectedLang != Language.RUS) { txbFathersName.Text = ""; }

            if (string.IsNullOrEmpty(txbName.Text) || string.IsNullOrEmpty(txbSurname.Text) || (selectedLang == Language.RUS && string.IsNullOrEmpty(txbFathersName.Text))) return;

            var day = GetCmbSelectedValue(cmbDate);
            var month = GetCmbSelectedValue(cmbMonth);
            var year = GetCmbSelectedValue(cmbYear);
            if (day > 0 && month > 0 && year > 0)
            {
                numerologyObject.DOBObject.SetDateOfBirth(day, month, year);
                numerologyObject.NameObject.SetName((Language)Enum.Parse(typeof(Language), cmbLang.SelectedItem.ToString()), txbName.Text.Trim(), txbSurname.Text.Trim(), selectedLang == Language.RUS ? txbFathersName.Text.Trim() : null, numerologyObject.DOBObject.GetLifeWayNumber);
                SetNameValuesToUI();
                SetMatrixIntersection(Matrix.TwoMatrixAnalisys(numerologyObject.DOBObject.DOBMatrix, numerologyObject.NameObject.NameMatrix));
            }
        }

        #endregion /Form events 

        #region Menu events
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            numerologyObject = null;
            InitUI();
            numerologyObject = InitNumerologyObject();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (numerologyObject == null) return;

            var customersFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, CUSTOMER_FOLDER_NAME);
            string message;
            if (!numerologyObject.SavePersonalData(customersFolderPath, out message))
            {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK);
            }
            else { MessageBox.Show("Успешно сохранено.", "Подтверждение", MessageBoxButtons.OK); }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Хотите выйти из программы?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                isUserInitiatedExit = true;
                this.Close();
            }
        }

        private void compareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompareForm compare = new CompareForm();
            compare.WindowState = FormWindowState.Normal;
            compare.StartPosition = FormStartPosition.CenterParent;

            compare.ShowDialog();
        }

        private void chart5yearsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChartForm chartFiveYears = new ChartForm();
            chartFiveYears.WindowState = FormWindowState.Normal;
            chartFiveYears.StartPosition = FormStartPosition.CenterParent;

            chartFiveYears.ShowDialog();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    openSaved = true;
                    numerologyObject = null;
                    InitUI();
                    numerologyObject = InitNumerologyObject();

                    var fullPath = openFileDialog1.FileName;
                    var loaded = numerologyObject.ReadPersonalData(fullPath);

                    var day = loaded.DOB.Day;
                    var month = loaded.DOB.Month;
                    var year = loaded.DOB.Year;

                    cmbDate.SelectedItem = day;
                    cmbMonth.SelectedValue = month;
                    cmbYear.SelectedItem = year;

                    var lang = Language.ENG.ToString();
                    if (!string.IsNullOrEmpty(loaded.Language)) lang = loaded.Language;

                    cmbLang.SelectedItem = lang;
                    txbName.Text = loaded.Name;
                    txbSurname.Text = loaded.Surname;

                    HandleLanguagesDifference((Language)Enum.Parse(typeof(Language), lang) == Language.RUS);
                    txbFathersName.Text = loaded.Fathername;

                    if (!CheckDateOfBirth(day, month, year))
                    {
                        MessageBox.Show("Несуществующая комбинация дня,месяца и года.");
                        openSaved = false;
                        return;
                    }
                    numerologyObject.DOBObject.SetDateOfBirth(day, month, year);
                    //numerologyObject.NameObject.SetName((Language)Enum.Parse(typeof(Language), cmbLang.SelectedItem.ToString()), txbName.Text.Trim(), txbSurname.Text.Trim(), numerologyObject.DOBObject.GetLifeWayNumber);
                    numerologyObject.NameObject.SetName((Language)Enum.Parse(typeof(Language), cmbLang.SelectedItem.ToString()), txbName.Text.Trim(), txbSurname.Text.Trim(), (Language)Enum.Parse(typeof(Language), cmbLang.SelectedItem.ToString()) == Language.RUS ? txbFathersName.Text.Trim() : null, numerologyObject.DOBObject.GetLifeWayNumber);

                    SetDOBValuesToUI();
                    SetNameValuesToUI();
                    SetMatrixIntersection(Matrix.TwoMatrixAnalisys(numerologyObject.DOBObject.DOBMatrix, numerologyObject.NameObject.NameMatrix));
                }
                finally { openSaved = false; }
            }
        }

        private void SaveForPrint_ToolStripMenuItem_Click(object sender, EventArgs e)
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

        #endregion /Menu events 
        
        private string GetNameForScreenshot()
        {
            var name = "EmptyName";
            var dateString = "";
            if (numerologyObject != null)
            {
                if (numerologyObject.NameObject != null)
                {
                    var firstname = numerologyObject.NameObject.GetNameRaw.Trim();
                    var lastname = numerologyObject.NameObject.GetSurnameRaw.Trim();
                    name = firstname + "_" + lastname;
                }
                if (numerologyObject.DOBObject != null)
                {
                    var day = numerologyObject.DOBObject.GetDayString;
                    var month = numerologyObject.DOBObject.GetMonthString;
                    var year = numerologyObject.DOBObject.GetYearString;
                    
                    dateString = day + "_" + month + "_" + year;
                }
            }

            return name + "_" + dateString;
        }

        private void SetMatrixIntersection(List<MatrixCell> matrix)
        {
            if (matrix == null) return;
            var targetZero = matrix.Where(x => x.CountOfNumber == 0).OrderBy(z => z.Number).ToList();
            var targetOne = matrix.Where(x => x.CountOfNumber == 1).OrderBy(z => z.Number).ToList();
            targetZero.AddRange(targetOne);

            if (targetZero.Count == 0) return;

            var parentWidth = pnlMatrixDiffer.Width;
            var parentHeight = pnlMatrixDiffer.Height;

            var minHeight = 20;
            float minFontSize = 15;
            var height = 40;
            float fontSize = 25;
            var between = 5;
            var heightSum = (targetZero.Count * height) + ((targetZero.Count - 1) * between);
            if (heightSum > parentHeight)
            {
                height = minHeight;
                fontSize = minFontSize;
            }

            var width = 60;
            var startX = (pnlMatrixDiffer.Width - width) / 2;
            var startY = (pnlMatrixDiffer.Height - ((height * targetZero.Count) + (between * (targetZero.Count - 1)))) / 2;

            ClearDiffer();

            for (int i = 0; i < targetZero.Count; i++)
            {
                CreateLabel(pnlMatrixDiffer, startX, startY + (i * height) + (i * between), width, height, fontSize, GetMatrixDifferSymbol(targetZero[i]) + targetZero[i].Number.ToString());
            }
        }
        private string GetMatrixDifferSymbol(MatrixCell cell)
        {
            if (cell == null) return "";
            if (cell.CountOfNumber == 0) return "-";
            if (cell.CountOfNumber == 1) return "~";
            return "";
        }
        private void CreateLabel(Panel parent, int x, int y, int width, int height, float fontSize, string value)
        {
            Label label = new Label();
            label.Width = width;
            label.Height = height;
            label.Location = new Point(x, y);
            label.Font = new Font("Microsoft Sans Serif", fontSize);
            label.Text = value;

            parent.Controls.Add(label);
        }

        private void SetDOBValuesToUI()
        {
            lblDateString.Text = numerologyObject.DOBObject.GetDayString;
            lblMonthString.Text = numerologyObject.DOBObject.GetMonthString;
            lblYearString.Text = numerologyObject.DOBObject.GetYearString;

            if (local) lblLifeWay.Text = numerologyObject.DOBObject.GetLifeWayNumberFullCalculationString;
            else lblLifeWay.Text = numerologyObject.DOBObject.GetLifeWayNumberString;

            lblMasterNumberHeader.Visible = numerologyObject.DOBObject.IsMasterNumberDOB;
            lblMaster.Visible = numerologyObject.DOBObject.IsMasterNumberDOB;
            lblMaster.Text = numerologyObject.DOBObject.GetMasterNumberDOBString;

            lblSecondRowFirst.Text = numerologyObject.DOBObject.GetDOBSumString;
            lblSecondRowSecond.Text = numerologyObject.DOBObject.GetLifeWayNumberString;
            lblSecondRowThird.Text = numerologyObject.DOBObject.GetDOBSumSubstructedString;
            lblSecondRowForth.Text = numerologyObject.DOBObject.GetDOBSumSubstructedSimplifiedString;

            lblDOBMatrix_1.Text = AdjustVisibleResult(numerologyObject.DOBObject.DOBMatrix.GetCellValue(1), 8);
            lblDOBMatrix_2.Text = AdjustVisibleResult(numerologyObject.DOBObject.DOBMatrix.GetCellValue(2), 8);
            lblDOBMatrix_3.Text = AdjustVisibleResult(numerologyObject.DOBObject.DOBMatrix.GetCellValue(3), 8);
            lblDOBMatrix_4.Text = AdjustVisibleResult(numerologyObject.DOBObject.DOBMatrix.GetCellValue(4), 8);
            lblDOBMatrix_5.Text = AdjustVisibleResult(numerologyObject.DOBObject.DOBMatrix.GetCellValue(5), 8);
            lblDOBMatrix_6.Text = AdjustVisibleResult(numerologyObject.DOBObject.DOBMatrix.GetCellValue(6), 8);
            lblDOBMatrix_7.Text = AdjustVisibleResult(numerologyObject.DOBObject.DOBMatrix.GetCellValue(7), 8);
            lblDOBMatrix_8.Text = AdjustVisibleResult(numerologyObject.DOBObject.DOBMatrix.GetCellValue(8), 8);
            lblDOBMatrix_9.Text = AdjustVisibleResult(numerologyObject.DOBObject.DOBMatrix.GetCellValue(9), 8);

            lblEgoValue1.Text = numerologyObject.DOBObject.DOBMatrix.GetEdgeValue(Matrix.Edge.Vertical1).ToString();
            lblFinancesValue1.Text = numerologyObject.DOBObject.DOBMatrix.GetEdgeValue(Matrix.Edge.Vertical2).ToString();
            lblTalentValue1.Text = numerologyObject.DOBObject.DOBMatrix.GetEdgeValue(Matrix.Edge.Vertical3).ToString();
            lblAimValue1.Text = numerologyObject.DOBObject.DOBMatrix.GetEdgeValue(Matrix.Edge.Horizontal1).ToString();
            lblFamilyValue1.Text = numerologyObject.DOBObject.DOBMatrix.GetEdgeValue(Matrix.Edge.Horizontal2).ToString();
            lblStabilityValue1.Text = numerologyObject.DOBObject.DOBMatrix.GetEdgeValue(Matrix.Edge.Horizontal3).ToString();
            lblSpiritualityValue1.Text = numerologyObject.DOBObject.DOBMatrix.GetEdgeValue(Matrix.Edge.DiagonalLeftTopToRightBottom).ToString();
            lblSexValue1.Text = numerologyObject.DOBObject.DOBMatrix.GetEdgeValue(Matrix.Edge.DiagonalLeftBottomToRightTop).ToString();

            lblPlusPeak1.Text = GetPlusPeakString(numerologyObject.DOBObject.Peaks[0].IsPeakMaster,
                numerologyObject.DOBObject.Peaks[0].PeakMaster.ToString(),
                numerologyObject.DOBObject.Peaks[0].Peak.ToString());

            lblPlusPeak2.Text = GetPlusPeakString(numerologyObject.DOBObject.Peaks[1].IsPeakMaster,
                numerologyObject.DOBObject.Peaks[1].PeakMaster.ToString(),
                numerologyObject.DOBObject.Peaks[1].Peak.ToString());

            lblPlusPeak3.Text = GetPlusPeakString(numerologyObject.DOBObject.Peaks[2].IsPeakMaster,
                numerologyObject.DOBObject.Peaks[2].PeakMaster.ToString(),
                numerologyObject.DOBObject.Peaks[2].Peak.ToString());

            lblPlusPeak4.Text = GetPlusPeakString(numerologyObject.DOBObject.Peaks[3].IsPeakMaster,
                numerologyObject.DOBObject.Peaks[3].PeakMaster.ToString(),
                numerologyObject.DOBObject.Peaks[3].Peak.ToString());

            lblMinusPeak1.Text = ((numerologyObject.DOBObject.Peaks[0].Bottom == 0) ? "" : "-") + AdjustVisibleResult(numerologyObject.DOBObject.Peaks[0].Bottom.ToString(), 3);
            lblMinusPeak2.Text = ((numerologyObject.DOBObject.Peaks[1].Bottom == 0) ? "" : "-") + AdjustVisibleResult(numerologyObject.DOBObject.Peaks[1].Bottom.ToString(), 3);
            lblMinusPeak3.Text = ((numerologyObject.DOBObject.Peaks[2].Bottom == 0) ? "" : "-") + AdjustVisibleResult(numerologyObject.DOBObject.Peaks[2].Bottom.ToString(), 3);
            lblMinusPeak4.Text = ((numerologyObject.DOBObject.Peaks[3].Bottom == 0) ? "" : "-") + AdjustVisibleResult(numerologyObject.DOBObject.Peaks[3].Bottom.ToString(), 3);

            lblPeakYear1.Text = AdjustVisibleResult(numerologyObject.DOBObject.Peaks[0].EndYear.Year.ToString(), 4);
            lblPeakYear2.Text = AdjustVisibleResult(numerologyObject.DOBObject.Peaks[1].EndYear.Year.ToString(), 4);
            lblPeakYear3.Text = AdjustVisibleResult(numerologyObject.DOBObject.Peaks[2].EndYear.Year.ToString(), 4);
            lblPeakAge1.Text = AdjustVisibleResult(numerologyObject.DOBObject.Peaks[0].Age.ToString(), 2);
            lblPeakAge2.Text = AdjustVisibleResult(numerologyObject.DOBObject.Peaks[1].Age.ToString(), 2);
            lblPeakAge3.Text = AdjustVisibleResult(numerologyObject.DOBObject.Peaks[2].Age.ToString(), 2);
        }

        private string GetPlusPeakString(bool isMaster, string masterNumber, string peakPlusNumber)
        {
            if (isMaster) return "+" + AdjustVisibleResult(masterNumber + "/" + peakPlusNumber, 5);
            else return "+" + AdjustVisibleResult(peakPlusNumber, 3);
        }

        private void SetNameValuesToUI()
        {
            lblNameMatrix_1.Text = AdjustVisibleResult(numerologyObject.NameObject.NameMatrix.GetCellValue(1), 8);
            lblNameMatrix_2.Text = AdjustVisibleResult(numerologyObject.NameObject.NameMatrix.GetCellValue(2), 8);
            lblNameMatrix_3.Text = AdjustVisibleResult(numerologyObject.NameObject.NameMatrix.GetCellValue(3), 8);
            lblNameMatrix_4.Text = AdjustVisibleResult(numerologyObject.NameObject.NameMatrix.GetCellValue(4), 8);
            lblNameMatrix_5.Text = AdjustVisibleResult(numerologyObject.NameObject.NameMatrix.GetCellValue(5), 8);
            lblNameMatrix_6.Text = AdjustVisibleResult(numerologyObject.NameObject.NameMatrix.GetCellValue(6), 8);
            lblNameMatrix_7.Text = AdjustVisibleResult(numerologyObject.NameObject.NameMatrix.GetCellValue(7), 8);
            lblNameMatrix_8.Text = AdjustVisibleResult(numerologyObject.NameObject.NameMatrix.GetCellValue(8), 8);
            lblNameMatrix_9.Text = AdjustVisibleResult(numerologyObject.NameObject.NameMatrix.GetCellValue(9), 8);

            lblLuckyNumber_1.Text = AdjustVisibleResult(numerologyObject.NameObject.GetLifeWayNumberString, 1);
            lblLuckyNumber_2.Text = AdjustVisibleResult(numerologyObject.NameObject.GetVowelsOfNameAndSurnameString, 1);
            lblLuckyNumber_3.Text = AdjustVisibleResult(numerologyObject.NameObject.GetConsonantsOfNameAndSurnameString, 1);
            lblLuckyNumber_4.Text = AdjustVisibleResult(numerologyObject.NameObject.GetVowelsAndConsonantsOfNameAndSurnameString, 1);
            lblLuckyNumber_5.Text = AdjustVisibleResult(numerologyObject.NameObject.GetVowelsAndConsonantsOfNameAndSurnameAndlifeWayNumberString, 1);

            lblLifeWayNumberValue.Text = AdjustVisibleResult(numerologyObject.DOBObject.IsMasterNumberDOB
                ? numerologyObject.DOBObject.GetMasterNumberDOBString + "/" + numerologyObject.NameObject.GetLifeWayNumberString
                : numerologyObject.NameObject.GetLifeWayNumberString, 4);

            lblSoulNumberValue.Text = AdjustVisibleResult(numerologyObject.NameObject.IsVowelsOfNameAndSurnameMaster
                ? numerologyObject.NameObject.GetVowelsOfNameAndSurnameMasterString + "/" + numerologyObject.NameObject.GetVowelsOfNameAndSurnameString
                : numerologyObject.NameObject.GetVowelsOfNameAndSurnameString, 4);

            lblPersonalityNumberValue.Text = AdjustVisibleResult(numerologyObject.NameObject.IsConsonantsOfNameAndSurnameMaster
                ? numerologyObject.NameObject.GetConsonantsOfNameAndSurnameMasterString + "/" + numerologyObject.NameObject.GetConsonantsOfNameAndSurnameString
                : numerologyObject.NameObject.GetConsonantsOfNameAndSurnameString, 4);

            lblDestinyNumberValue.Text = AdjustVisibleResult(numerologyObject.NameObject.IsVowelsAndConsonantsOfNameAndSurnameMaster
                ? numerologyObject.NameObject.GetVowelsAndConsonantsOfNameAndSurnameMaster + "/" + numerologyObject.NameObject.GetVowelsAndConsonantsOfNameAndSurnameString
                : numerologyObject.NameObject.GetVowelsAndConsonantsOfNameAndSurnameString, 4);

            lblPowerNumberValue.Text = AdjustVisibleResult(numerologyObject.NameObject.IsVowelsAndConsonantsOfNameAndSurnameAndlifeWayNumberMaster
                ? numerologyObject.NameObject.GetVowelsAndConsonantsOfNameAndSurnameAndlifeWayNumberMasterString + "/" + numerologyObject.NameObject.GetVowelsAndConsonantsOfNameAndSurnameAndlifeWayNumberString
                : numerologyObject.NameObject.GetVowelsAndConsonantsOfNameAndSurnameAndlifeWayNumberString, 4);
        }

        private string AdjustVisibleResult(string input, int symbols)
        {
            if (string.IsNullOrEmpty(input)) return Spaces(CountNumberOfSpaces("-", symbols)) + "-";
            return Spaces(CountNumberOfSpaces(input, symbols)) + input;
        }

        private int CountNumberOfSpaces(string input, int baseLength)
        {
            if (baseLength <= input.Length) return 0;
            return (int)((baseLength - input.Length) / 2) + 2;
        }
        private string Spaces(int count)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++) sb.Append(" ");

            return sb.ToString();
        }

        private int GetCmbSelectedValue(ComboBox cmb)
        {
            if (cmb != null && cmb.SelectedValue != null)
            {
                return (int)cmb.SelectedValue;
            }
            return -1;
        }

        private bool CheckDateOfBirth(int day, int month, int year)
        {
            try { var date = new DateTime(year, month, day); }
            catch { return false; }
            return true;
        }

        /// <summary>
        /// Inits and clears everithing on UI
        /// </summary>
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

            lblLifeWay.Text = "";

            ClearDOBTwoRows();
            ClearDOBMatrix();
            ClearPeakLabels();

            // Name
            ClearNameArea();
            ClearNameMatrix();
            ClearLuckyArea();

            // Differ panel
            ClearDiffer();
        }

        private void DrawPeak1Ellipse(PaintEventArgs e, System.Drawing.Color color, int penWidth)
        {
            Pen pen = new Pen(color, penWidth);
            var width = pnlPeak_1.Width;
            var height = pnlPeak_1.Height;
            Rectangle rect = new Rectangle(width * -1, 0, (width * 2) - 2, (height * 2) - 2);
            e.Graphics.DrawEllipse(pen, rect);
        }
        private void DrawPeak1BottomLine(PaintEventArgs e, System.Drawing.Color color, int penWidth)
        {
            Pen pen = new Pen(color, penWidth);
            var width = pnlPeak_1.Width;
            var height = pnlPeak_1.Height;
            e.Graphics.DrawLine(pen, new Point(0, height - penWidth), new Point(width, height - penWidth));
        }
        private void DrawPeak2Ellipse(PaintEventArgs e, System.Drawing.Color color, int penWidth)
        {
            Pen pen = new Pen(color, penWidth);
            var width = pnlPeak_2.Width;
            var height = pnlPeak_2.Height;
            Rectangle rect = new Rectangle(0, 0, width - 2, (height * 2) - 2);
            e.Graphics.DrawEllipse(pen, rect);
        }
        private void DrawPeak2BottomLine(PaintEventArgs e, System.Drawing.Color color, int penWidth)
        {
            Pen pen = new Pen(color, penWidth);
            var width = pnlPeak_2.Width;
            var height = pnlPeak_2.Height;
            e.Graphics.DrawLine(pen, new Point(0, height - penWidth), new Point(width, height - penWidth));
        }
        private void DrawPeak3Ellipse(PaintEventArgs e, System.Drawing.Color color, int penWidth)
        {
            Pen pen = new Pen(color, penWidth);
            var width = pnlPeak_3.Width;
            var height = pnlPeak_3.Height;
            Rectangle rect = new Rectangle(0, 0, width - 2, (height * 2) - 2);
            e.Graphics.DrawEllipse(pen, rect);
        }
        private void DrawPeak3BottomLine(PaintEventArgs e, System.Drawing.Color color, int penWidth)
        {
            Pen pen = new Pen(color, penWidth);
            var width = pnlPeak_3.Width;
            var height = pnlPeak_3.Height;
            e.Graphics.DrawLine(pen, new Point(0, height - penWidth), new Point(width, height - penWidth));
        }
        private void DrawPeak4Ellipse(PaintEventArgs e, System.Drawing.Color color, int penWidth)
        {
            Pen pen = new Pen(color, penWidth);
            var width = pnlPeak_4.Width;
            var height = pnlPeak_4.Height;
            Rectangle rect = new Rectangle(0, 0, (width * 2) - 2, (height * 2) - 2);
            e.Graphics.DrawEllipse(pen, rect);
        }
        private void DrawPeak4BottomLine(PaintEventArgs e, System.Drawing.Color color, int penWidth)
        {
            Pen pen = new Pen(color, penWidth);
            var width = pnlPeak_4.Width;
            var height = pnlPeak_4.Height;
            e.Graphics.DrawLine(pen, new Point(0, height - penWidth), new Point(width, height - penWidth));
        }

        private void ClearPeakLabels()
        {
            lblPlusPeak1.Text = "";
            lblPlusPeak2.Text = "";
            lblPlusPeak3.Text = "";
            lblPlusPeak4.Text = "";

            lblMinusPeak1.Text = "";
            lblMinusPeak2.Text = "";
            lblMinusPeak3.Text = "";
            lblMinusPeak4.Text = "";

            lblPeakYear1.Text = "";
            lblPeakYear2.Text = "";
            lblPeakYear3.Text = "";

            lblPeakAge1.Text = "";
            lblPeakAge2.Text = "";
            lblPeakAge3.Text = "";
        }

        private void ClearDOBTwoRows()
        {
            lblDateString.Text = "";
            lblMonthString.Text = "";
            lblYearString.Text = "";
            lblSecondRowFirst.Text = "";
            lblSecondRowSecond.Text = "";
            lblSecondRowThird.Text = "";
            lblSecondRowForth.Text = "";
            lblMaster.Text = "";
            lblMasterNumberHeader.Visible = false;
        }

        private void ClearDOBMatrix()
        {
            lblDOBMatrix_1.Text = "";
            lblDOBMatrix_2.Text = "";
            lblDOBMatrix_3.Text = "";
            lblDOBMatrix_4.Text = "";
            lblDOBMatrix_5.Text = "";
            lblDOBMatrix_6.Text = "";
            lblDOBMatrix_7.Text = "";
            lblDOBMatrix_8.Text = "";
            lblDOBMatrix_9.Text = "";

            ClearMatrixEdges();
        }

        private void ClearMatrixEdges()
        {
            lblEgoValue1.Text = "";
            lblFinancesValue1.Text = "";
            lblTalentValue1.Text = "";
            lblAimValue1.Text = "";
            lblFamilyValue1.Text = "";
            lblStabilityValue1.Text = "";
            lblSpiritualityValue1.Text = "";
            lblSexValue1.Text = "";
        }
        private void ClearNameArea()
        {
            cmbLang.DataSource = null;
            cmbLang.DataSource = GetLanguages();
            cmbLang.SelectedItem = Language.ENG.ToString();

            txbName.Text = "";
            txbSurname.Text = "";
            txbFathersName.Text = "";

            HandleLanguagesDifference((Language)Enum.Parse(typeof(Language), cmbLang.SelectedItem.ToString()) == Language.RUS);
        }
        private void HandleLanguagesDifference(bool full)
        {
            if (full)
            {
                lblFathersName.Visible = true;
                txbFathersName.Visible = true;
                btnNameShow.Location = new Point(btnNameShow.Location.X, 112);
            }
            else
            {
                lblFathersName.Visible = false;
                txbFathersName.Visible = false;
                btnNameShow.Location = new Point(btnNameShow.Location.X, 83);
            }
        }
        private void ClearDiffer()
        {
            pnlMatrixDiffer.Controls.Clear();
        }
        private void ClearLuckyArea()
        {
            lblLuckyNumber_1.Text = "";
            lblLuckyNumber_2.Text = "";
            lblLuckyNumber_3.Text = "";
            lblLuckyNumber_4.Text = "";
            lblLuckyNumber_5.Text = "";

            lblLifeWayNumberValue.Text = "";
            lblSoulNumberValue.Text = "";
            lblPersonalityNumberValue.Text = "";
            lblDestinyNumberValue.Text = "";
            lblPowerNumberValue.Text = "";
        }
        private void ClearNameMatrix()
        {
            lblNameMatrix_1.Text = "";
            lblNameMatrix_2.Text = "";
            lblNameMatrix_3.Text = "";
            lblNameMatrix_4.Text = "";
            lblNameMatrix_5.Text = "";
            lblNameMatrix_6.Text = "";
            lblNameMatrix_7.Text = "";
            lblNameMatrix_8.Text = "";
            lblNameMatrix_9.Text = "";
        }

        private List<string> GetLanguages()
        {
            var langs = new List<string>();
            foreach (Language lang in Enum.GetValues(typeof(Language)))
            {
                langs.Add(lang.ToString());
            }
            return langs;
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
            for (int i = 0; i < 12; i++)
            {
                var name = CultureInfo.CurrentUICulture.DateTimeFormat.MonthNames[i];
                var month = new Month() { Id = (i + 1), Name = name };
                months.Add(month);
            }
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

        /// <summary>
        /// Inits new NumerologyObject
        /// </summary>
        private NumerologyObject InitNumerologyObject()
        {
            return Manager.InitNumerologyObject();
        }        
    }
}
