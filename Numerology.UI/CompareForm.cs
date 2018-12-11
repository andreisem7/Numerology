using Numerology.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Numerology.UI
{
    public partial class CompareForm : Form
    {
        private class LifeCycles
        {
            public int BeforeBirthDay;
            public int AfterBirthDay;
        }
        private const string CUSTOMER_FOLDER_NAME = "Customers";
        private const int YEARS_BACK = 50;
        private const int YEARS_FORWARD = 50;

        private NumerologyObject numerologyObject = null;
        private Comparison comparison1 = null;
        private Comparison comparison2 = null;

        private LifeCycles cycles1 = null;
        private LifeCycles cycles2 = null;

        private int ellipsePenWidth = 2;        
        private int topBottomLinePenWidth = 1;
        private System.Drawing.Color topBottomLineColor = System.Drawing.Color.Black;
        private string evaryDayGraphErrorMsg = "График бытовой и духовной совместимости невозможно построить.";

        public CompareForm()
        {
            InitializeComponent();
            InitYears();
            InitYearsRelationsStart();
            InitRelationsPeriod();
            numerologyObject = InitNumerologyObject();

            openFileDialog1.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, CUSTOMER_FOLDER_NAME);
            openFileDialog2.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, CUSTOMER_FOLDER_NAME);
        }
        private void btnSelectPersonOne_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fullPath = openFileDialog1.FileName;
                txbFile1.Text = Path.GetFileName(fullPath);

                comparison1 = numerologyObject.ReadPersonalData(fullPath);
                ShowComparison1(comparison1);

                var year = GetCmbSelectedValue(cmbYears);
                GetPeakBottom1Values(year, out var peak1, out var bottom1);
                SetPeakBottom1ValuesOnUI(peak1, bottom1);

                if (comparison1 != null && comparison2 != null)
                {
                    // Show working and personal compatibility
                    ShowWorkingPersonalCompatibility(comparison1, comparison2, year);

                    var yearsRelationsStart = GetCmbSelectedValue(cmbYearsRelationsStart);
                    var period = GetCmbSelectedValue(cmbRelationPeriod);
                    if (!ShowEveryDayAndSpiritualityCompatibility(comparison1, comparison2, yearsRelationsStart, period))
                    {
                        MessageBox.Show(evaryDayGraphErrorMsg);                        
                    }
                }
            }
        }
        private void btnSelectPersonTwo_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                var fullPath = openFileDialog2.FileName;
                txbFile2.Text = Path.GetFileName(fullPath);

                comparison2 = numerologyObject.ReadPersonalData(fullPath);
                ShowComparison2(comparison2);

                var year = GetCmbSelectedValue(cmbYears);
                GetPeakBottom2Values(year, out var peak2, out var bottom2);
                SetPeakBottom2ValuesOnUI(peak2, bottom2);

                if (comparison1 != null && comparison2 != null)
                {
                    // Show working and personal compatibility
                    ShowWorkingPersonalCompatibility(comparison1, comparison2, year);

                    var yearsRelationsStart = GetCmbSelectedValue(cmbYearsRelationsStart);
                    var period = GetCmbSelectedValue(cmbRelationPeriod);
                    if (!ShowEveryDayAndSpiritualityCompatibility(comparison1, comparison2, yearsRelationsStart, period))
                    {
                        MessageBox.Show(evaryDayGraphErrorMsg);
                    }
                }
            }
        }

        /// <summary>
        /// Inits new NumerologyObject
        /// </summary>
        private NumerologyObject InitNumerologyObject()
        {
            return Manager.InitNumerologyObject();
        }

        private void ShowComparison1(Comparison comparison)
        {
            txbName1.Text = comparison.Name;
            txbSurname1.Text = comparison.Surname;
            txbDOB1.Text = comparison.DOB.ToString("dd.MM.yyyy");

            lblWayOfLifeValue1.Text = comparison.LifeWayNumber.ToString();
            lblSoulNumberValue1.Text = comparison.SoulNumber.ToString();
            lblPersonalityNumberValue1.Text = comparison.PersonalityNumber.ToString();
            lblDestinyNumberValue1.Text = comparison.DestinyNumber.ToString();
            lblPowerNumberValue1.Text = comparison.PowerNumber.ToString();

            var year = GetCmbSelectedValue(cmbYears);
            ShowCycles1(comparison, year);
        }
        private void ShowComparison2(Comparison comparison)
        {
            txbName2.Text = comparison.Name;
            txbSurname2.Text = comparison.Surname;
            txbDOB2.Text = comparison.DOB.ToString("dd.MM.yyyy");

            lblWayOfLifeValue2.Text = comparison.LifeWayNumber.ToString();
            lblSoulNumberValue2.Text = comparison.SoulNumber.ToString();
            lblPersonalityNumberValue2.Text = comparison.PersonalityNumber.ToString();
            lblDestinyNumberValue2.Text = comparison.DestinyNumber.ToString();
            lblPowerNumberValue2.Text = comparison.PowerNumber.ToString();

            var year = GetCmbSelectedValue(cmbYears);
            ShowCycles2(comparison, year);
        }

        private void ShowCycles1(Comparison comparison, int year)
        {
            cycles1 = GetLifeCycleValue(comparison.DOB, comparison.LifeWayNumber, year);

            if (cycles1.BeforeBirthDay != cycles1.AfterBirthDay)
            {
                lblLifeCycleValueBefore1.Visible = true;
                lblLifeCycleValueBefore1.Text = cycles1.BeforeBirthDay.ToString();
                lblLifeCycleValue1Slash.Visible = true;
                lblLifeCycleValueAfter1.Text = cycles1.AfterBirthDay.ToString();
            }
            else
            {
                lblLifeCycleValueBefore1.Visible = false;
                lblLifeCycleValue1Slash.Visible = false;
                lblLifeCycleValueAfter1.Text = cycles1.AfterBirthDay.ToString();
            }
        }
        private void ShowCycles2(Comparison comparison, int year)
        {
            cycles2 = GetLifeCycleValue(comparison.DOB, comparison.LifeWayNumber, year);

            if (cycles2.BeforeBirthDay != cycles2.AfterBirthDay)
            {
                lblLifeCycleValueBefore2.Text = cycles2.BeforeBirthDay.ToString();
                lblLifeCycleValue2Slash.Visible = true;
                lblLifeCycleValueAfter2.Visible = true;
                lblLifeCycleValueAfter2.Text = cycles2.AfterBirthDay.ToString();
            }
            else
            {
                lblLifeCycleValueBefore2.Text = cycles2.BeforeBirthDay.ToString();
                lblLifeCycleValue2Slash.Visible = false;
                lblLifeCycleValueAfter2.Visible = false;
            }
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
        private List<int> GetRelationPeriod()
        {            
            var years = new List<int>();
            for (int i = 20; i <= 60; i += 20)
            {
                years.Add(i);
            }
            return years;
        }
        private LifeCycles GetLifeCycleValue(DateTime dob, int wayOfLife, int year)
        {
            var age1 = year - dob.Year - 1;
            var age2 = age1 + 1;

            var lifeCycles = new LifeCycles();
            lifeCycles.BeforeBirthDay = GetMeaningfullLifeCycleValue(dob, LifeCycleHelper.GetLifeCycleValuePart(wayOfLife, age1));
            lifeCycles.AfterBirthDay = GetMeaningfullLifeCycleValue(dob, LifeCycleHelper.GetLifeCycleValuePart(wayOfLife, age2));

            return lifeCycles;
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
        private string NarrowToOneNumber(string input)
        {
            string result = input;
            while (result.Length > 1)
            {
                result = SimplifyString(result);
            }
            return result;
        }

        private int GetMeaningfullLifeCycleValue(DateTime dob, LifeCycleHelper.LifeCycleElement.LifeCyclePartElement.LifeCycleValuePart part)
        {
            switch (part)
            {
                case LifeCycleHelper.LifeCycleElement.LifeCyclePartElement.LifeCycleValuePart.Day: { return int.Parse(NarrowToOneNumber(dob.Day.ToString())); }
                case LifeCycleHelper.LifeCycleElement.LifeCyclePartElement.LifeCycleValuePart.Month: { return int.Parse(NarrowToOneNumber(dob.Month.ToString())); }
                case LifeCycleHelper.LifeCycleElement.LifeCyclePartElement.LifeCycleValuePart.Year: { return int.Parse(NarrowToOneNumber(dob.Year.ToString())); }
                default: return 0;
            }
        }
        private void InitYears()
        {
            cmbYears.DataSource = null;
            cmbYears.DataSource = GetYears();
            cmbYears.SelectedItem = (object)DateTime.Now.Year;
        }
        private void InitYearsRelationsStart()
        {
            cmbYearsRelationsStart.DataSource = null;
            cmbYearsRelationsStart.DataSource = GetYears();
            cmbYearsRelationsStart.SelectedItem = (object)DateTime.Now.Year;
        }
        private void InitRelationsPeriod()
        {
            cmbRelationPeriod.DataSource = null;
            cmbRelationPeriod.DataSource = GetRelationPeriod();
            cmbRelationPeriod.SelectedItem = (object)40;
        }

        private void cmbYearsRelationsStart_SelectedIndexChanged(object sender, EventArgs e)
        {
            var yearsRelationsStart = GetCmbSelectedValue(sender as ComboBox);
            var period = GetCmbSelectedValue(cmbRelationPeriod);
            if (comparison1 != null && comparison2 != null)
            {
                if (!ShowEveryDayAndSpiritualityCompatibility(comparison1, comparison2, yearsRelationsStart, period))
                {
                    MessageBox.Show(evaryDayGraphErrorMsg);
                }
            }
        }

        private void cmbRelationPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            var yearsRelationsStart = GetCmbSelectedValue(cmbYearsRelationsStart);
            var period = GetCmbSelectedValue(sender as ComboBox);
            if (comparison1 != null && comparison2 != null)
            {
                if (!ShowEveryDayAndSpiritualityCompatibility(comparison1, comparison2, yearsRelationsStart, period))
                {
                    MessageBox.Show(evaryDayGraphErrorMsg);
                }
            }
        }

        private void cmbYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cmb = sender as ComboBox;
            if (cmb != null)
            {
                var year = GetCmbSelectedValue(cmb);
                if (year > 0)
                {
                    GetPeakBottom1Values(year, out var peak1, out var bottom1);
                    GetPeakBottom2Values(year, out var peak2, out var bottom2);
                    SetPeakBottom1ValuesOnUI(peak1, bottom1);
                    SetPeakBottom2ValuesOnUI(peak2, bottom2);

                    if (comparison1 != null) ShowCycles1(comparison1, year);
                    if (comparison2 != null) ShowCycles2(comparison2, year);

                    if (comparison1 != null && comparison2 != null)
                    {                        
                        ShowWorkingPersonalCompatibility(comparison1, comparison2, year);                        
                    }
                }
            }
        }
        private void ShowWorkingPersonalCompatibility(Comparison comparison1, Comparison comparison2, int year)
        {
            PersonalWorkingRelationshipManager.GetPersonalWorkingValues(comparison1.LifeWayNumber, comparison2.LifeWayNumber,
                out var workLifeWay,
                out var personalLifeWay,
                out var personalAlterLifeWay);

            PersonalWorkingRelationshipManager.GetPersonalWorkingValues(comparison1.SoulNumber, comparison2.SoulNumber,
                out var workSoulNumber,
                out var personalSoulNumber,
                out var personalAlterSoulNumber);

            PersonalWorkingRelationshipManager.GetPersonalWorkingValues(comparison1.PersonalityNumber, comparison2.PersonalityNumber,
                out var workPersonalityNumber,
                out var personalPersonalityNumber,
                out var personalAlterPersonalityNumber);

            PersonalWorkingRelationshipManager.GetPersonalWorkingValues(comparison1.DestinyNumber, comparison2.DestinyNumber,
                out var workDestinyNumber,
                out var personalDestinyNumber,
                out var personalAlterDestinyNumber);

            PersonalWorkingRelationshipManager.GetPersonalWorkingValues(comparison1.PowerNumber, comparison2.PowerNumber,
                out var workPowerNumber,
                out var personalPowerNumber,
                out var personalAlterPowerNumber);

            GetPeakBottom1Values(year, out var peak1, out var bottom1);
            GetPeakBottom2Values(year, out var peak2, out var bottom2);

            PersonalWorkingRelationshipManager.GetPersonalWorkingValues(peak1, peak2,
                out var workPeakNumber,
                out var personalPeakNumber,
                out var personalAlterPeakNumber);

            PersonalWorkingRelationshipManager.GetPersonalWorkingValues(bottom1, bottom2,
                out var workProblemNumber,
                out var personalProblemNumber,
                out var personalAlterProblemNumber);

            var lifeCycle1 = GetLifeCycleValue(comparison1.DOB, comparison1.LifeWayNumber, year);
            var lifeCycle2 = GetLifeCycleValue(comparison2.DOB, comparison2.LifeWayNumber, year);

            PersonalWorkingRelationshipManager.GetPersonalWorkingValues(lifeCycle1.BeforeBirthDay, lifeCycle2.BeforeBirthDay,
                out var workLifeCycleBefore,
                out var personalLifeCycleBefore,
                out var personalAlterLifeCycleBefore);

            PersonalWorkingRelationshipManager.GetPersonalWorkingValues(lifeCycle1.AfterBirthDay, lifeCycle2.AfterBirthDay,
                out var workLifeCycleAfter,
                out var personalLifeCycleAfter,
                out var personalAlterLifeCycleAfter);

            var workSum = 0;
            var personalSum = 0;

            // UI portion
            lblWorkWayOfLife.Text = workLifeWay.ToString();
            lblPersonalWayOfLife.Text = personalLifeWay.ToString();
            workSum += workLifeWay;
            personalSum += personalLifeWay;

            lblWorkSoul.Text = workSoulNumber.ToString();
            lblPersonalSoul.Text = personalSoulNumber.ToString();
            workSum += workSoulNumber;
            personalSum += personalSoulNumber;

            lblWorkPersonality.Text = workPersonalityNumber.ToString();
            lblPersonalPersonality.Text = personalPersonalityNumber.ToString();
            workSum += workPersonalityNumber;
            personalSum += personalPersonalityNumber;

            lblWorkDestiny.Text = workDestinyNumber.ToString();
            lblPersonalDestiny.Text = personalDestinyNumber.ToString();
            workSum += workDestinyNumber;
            personalSum += personalDestinyNumber;

            lblWorkPower.Text = workPowerNumber.ToString();
            lblPersonalPower.Text = personalPowerNumber.ToString();
            workSum += workPowerNumber;
            personalSum += personalPowerNumber;

            lblWorkPeak.Text = workPeakNumber.ToString();
            lblPersonalPeak.Text = personalPeakNumber.ToString();
            workSum += workPeakNumber;
            personalSum += personalPeakNumber;

            lblWorkProblem.Text = workProblemNumber.ToString();
            lblPersonalProblem.Text = personalProblemNumber.ToString();
            workSum += workProblemNumber;
            personalSum += personalProblemNumber;

            var workSumBefore = workSum;
            var workSumAfter = workSum;
            if (workLifeCycleBefore != workLifeCycleAfter)
            {
                workSumBefore += workLifeCycleBefore;
                workSumAfter += workLifeCycleAfter;

                lblWorkCycleBefore.Visible = true;
                lblWorkCycleBefore.Text = workLifeCycleBefore.ToString();
                lblWorkCycleSlash.Visible = true;
                lblWorkCycleAfter.Text = workLifeCycleAfter.ToString();
            }
            else
            {
                workSumBefore += workLifeCycleAfter;
                workSumAfter += workLifeCycleAfter;

                lblWorkCycleBefore.Visible = false;
                lblWorkCycleSlash.Visible = false;
                lblWorkCycleAfter.Text = workLifeCycleAfter.ToString();
            }

            var personalSumBefore = personalSum;
            var personalSumAfter = personalSum;
            if (personalLifeCycleBefore != personalLifeCycleAfter)
            {
                personalSumBefore += personalLifeCycleBefore;
                personalSumAfter += personalLifeCycleAfter;

                lblPersonalCycleBefore.Text = personalLifeCycleBefore.ToString();
                lblPersonalCycleSlash.Visible = true;
                lblPersonalCycleAfter.Visible = true;
                lblPersonalCycleAfter.Text = personalLifeCycleAfter.ToString();
            }
            else
            {
                personalSumBefore += personalLifeCycleBefore;
                personalSumAfter += personalLifeCycleBefore;

                lblPersonalCycleBefore.Text = personalLifeCycleBefore.ToString();
                lblPersonalCycleSlash.Visible = false;
                lblPersonalCycleAfter.Visible = false;
            }

            // Calculate coefficients
            if (workSumBefore != workSumAfter)
            {
                lblWorkCoeffBefore.Visible = true;
                lblWorkCoeffBefore.Text = GetFormattedDecimal(workSumBefore, 9);
                lblWorkCoeffSlash.Visible = true;
                lblWorkCoeffAfter.Text = GetFormattedDecimal(workSumAfter, 9);
            }
            else
            {
                lblWorkCoeffBefore.Visible = false;
                lblWorkCoeffSlash.Visible = false;
                lblWorkCoeffAfter.Text = GetFormattedDecimal(workSumAfter, 9);
            }

            if (personalSumBefore != personalSumAfter)
            {
                lblPersonalCoeffBefore.Text = GetFormattedDecimal(personalSumBefore, 9);
                lblPersonalCoeffSlash.Visible = true;
                lblpersonalCoeffAfter.Visible = true;
                lblpersonalCoeffAfter.Text = GetFormattedDecimal(personalSumAfter, 9);
            }
            else
            {
                lblPersonalCoeffBefore.Text = GetFormattedDecimal(personalSumBefore, 9);
                lblPersonalCoeffSlash.Visible = false;
                lblpersonalCoeffAfter.Visible = false;
            }
        }

        private string GetFormattedDecimal(decimal input, int divide)
        {
            return String.Format("{0:0.0}", input / divide);
        }
        private string GetFormattedDecimal(decimal input)
        {
            if ((int)input == input) return String.Format("{0}", (int)input);
            return String.Format("{0:0.0}", input);
        }
        private bool ShowEveryDayAndSpiritualityCompatibility(Comparison comparison1, Comparison comparison2, int yearsRelationsStart, int period)
        {
            CleanCompatibilityBase();

            var daysInYear = new DateTime(yearsRelationsStart, 12, 31).Subtract(new DateTime(yearsRelationsStart, 1, 1)).Days + 1;

            if (comparison1.EveryDayStabilityNumber == 0 || comparison2.EveryDayStabilityNumber == 0 ||
                comparison1.SpiritualStabilityNumber == 0 || comparison2.SpiritualStabilityNumber == 0)
                return false;

            decimal everyDay = (comparison1.EveryDayStabilityNumber * comparison2.EveryDayStabilityNumber) / (decimal)daysInYear;
            decimal spirituality = (comparison1.SpiritualStabilityNumber * comparison2.SpiritualStabilityNumber) / (decimal)daysInYear;

            var everyDayRounded = Round(everyDay);//1
            var spiritualityRounded = Round(spirituality);//2
            
            int firstRowPanelTop = 0;
            int panelRowHeight = 50;            
            int regularLabelHeight = 15;            
            int spaceBetweenLabels = 2;            
            int leftElementLeft = 0;

            int secondRowPanelTop = firstRowPanelTop + panelRowHeight + (2 * regularLabelHeight) + (3 * spaceBetweenLabels);            
            var biggestYear = yearsRelationsStart + period;            
            var baseWidth = pnlCompatibilityBase.Width;
            int pxForOneYear = baseWidth / period;

            var firstRowElementsCount = (int)decimal.Ceiling(baseWidth / (everyDayRounded * pxForOneYear));
            var secondRowElementsCount = (int)decimal.Ceiling(baseWidth / (spiritualityRounded * pxForOneYear));

            List<CompatibilityHelper> firstRowElements = new List<CompatibilityHelper>(firstRowElementsCount);
            List<CompatibilityHelper> secondRowElements = new List<CompatibilityHelper>(secondRowElementsCount);

            for (int i = 0; i < firstRowElementsCount; i++)
            {
                var element = new CompatibilityHelper();

                element.Top = firstRowPanelTop;
                element.Height = panelRowHeight;
                element.Bottom = element.Top + element.Height;
                element.EllipseColor = System.Drawing.Color.Blue;

                if (i == 0)
                {
                    element.IsFirstElement = true;
                    element.StartYear = yearsRelationsStart;
                    element.EndYear = element.StartYear + everyDayRounded;
                    element.Left = leftElementLeft;
                    element.Width = (int)(everyDayRounded * pxForOneYear);
                    element.Right = (int)(everyDayRounded * pxForOneYear);
                }
                else
                {
                    element.StartYear = firstRowElements[i - 1].EndYear;
                    element.EndYear = element.StartYear + everyDayRounded;
                    element.Width = ((int)(everyDayRounded * pxForOneYear)) - 1;
                    element.Left = firstRowElements[i - 1].Left + firstRowElements[i - 1].Width + 1;                    
                    element.Right = ((int)(everyDayRounded * pxForOneYear)) - 1;
                }

                if (i == (firstRowElementsCount - 1))
                {
                    element.IsLastElement = true;
                    element.Width = baseWidth - element.Left;
                    element.Right = ((int)(everyDayRounded * pxForOneYear)) - 1;
                }
                firstRowElements.Add(element);
            }

            for (int i = 0; i < secondRowElementsCount; i++)
            {
                var element = new CompatibilityHelper();

                element.Top = secondRowPanelTop;
                element.Height = panelRowHeight;
                element.Bottom = element.Top + element.Height;
                element.EllipseColor = System.Drawing.Color.Green;

                if (i == 0)
                {
                    element.IsFirstElement = true;
                    element.StartYear = yearsRelationsStart;
                    element.EndYear = element.StartYear + spiritualityRounded;
                    element.Left = leftElementLeft;
                    element.Width = (int)(spiritualityRounded * pxForOneYear);
                    element.Right = (int)(spiritualityRounded * pxForOneYear);
                }
                else
                {
                    element.StartYear = secondRowElements[i - 1].EndYear;
                    element.EndYear = element.StartYear + spiritualityRounded;                                        
                    element.Width = ((int)(spiritualityRounded * pxForOneYear)) - 1;
                    element.Left = secondRowElements[i - 1].Left + secondRowElements[i - 1].Width + 1;                    
                    element.Right = ((int)(spiritualityRounded * pxForOneYear)) - 1;
                }

                if (i == (secondRowElementsCount - 1))
                {
                    element.IsLastElement = true;
                    element.Width = baseWidth - element.Left;
                    element.Right = ((int)(spiritualityRounded * pxForOneYear)) - 1;
                }
                secondRowElements.Add(element);
            }
            
            DrawCompatibilityObjects(firstRowElements, true);
            DrawCompatibilityObjects(secondRowElements, false);

            DrawCompatibilityLabels(firstRowElements, secondRowElements);
            return true;
        }

        private void CleanCompatibilityBase()
        {
            pnlCompatibilityBase.Controls.Clear();
        }

        private void DrawCompatibilityLabels(List<CompatibilityHelper> topElements, List<CompatibilityHelper> bottomElements)
        {            
            foreach (var topElement in topElements.Where(x => !x.IsFirstElement))
            {
                foreach (var bottomElement in bottomElements.Where(x => !x.IsFirstElement))
                {
                    if (topElement.EndYear == bottomElement.EndYear)
                    {
                        topElement.IsSharedYear = true;
                        bottomElement.IsSharedYear = true;
                    }
                }
            }
            
            int regularLabelHeight = 15;
            int regularLabelWidth = 45;
            int spaceBetweenLabels = 2;
            int extraSpaceBetweenLabels = 5;
            int extraLabelHeight = 26;
            int extraLabelWidth = 60;
            
            Color regularColor = Color.Black;
            Font regularFont = new Font("Microsoft Sans Serif", (float)8.25);

            Color sharedColor = Color.Red;
            Font sharedFont = new Font("Microsoft Sans Serif", (float)12);

            // Top elements
            var te = topElements.First(x => x.IsFirstElement);
            
            var tlb = CreateLabel(te, regularLabelHeight, regularLabelWidth, te.Left, te.Bottom + spaceBetweenLabels, GetFormattedDecimal(te.StartYear), regularFont, regularColor);
            pnlCompatibilityBase.Controls.Add(tlb);

            foreach (var topElement in topElements.Where(x => !x.IsSharedYear && !x.IsLastElement))
            {                
                tlb = CreateLabel(topElement, regularLabelHeight, regularLabelWidth, topElement.Left + topElement.Width - (regularLabelWidth / 2), topElement.Bottom + spaceBetweenLabels, GetFormattedDecimal(topElement.EndYear), regularFont, regularColor);
                pnlCompatibilityBase.Controls.Add(tlb);
            }

            // Bottom elements
            var be = bottomElements.First(x => x.IsFirstElement);
            var blb = CreateLabel(be, regularLabelHeight, regularLabelWidth, be.Left, be.Top - spaceBetweenLabels - regularLabelHeight, GetFormattedDecimal(be.StartYear), regularFont, regularColor);
            pnlCompatibilityBase.Controls.Add(blb);

            foreach (var bottomElement in bottomElements.Where(x => !x.IsSharedYear && !x.IsLastElement))
            {                
                blb = CreateLabel(bottomElement, regularLabelHeight, regularLabelWidth, bottomElement.Left + bottomElement.Width - (regularLabelWidth / 2), be.Top - spaceBetweenLabels - regularLabelHeight, GetFormattedDecimal(bottomElement.EndYear), regularFont, regularColor);
                pnlCompatibilityBase.Controls.Add(blb);
            }

            // Shared elements            
            foreach (var sharedElement in topElements.Where(x => x.IsSharedYear))
            {
                var slb = CreateLabel(sharedElement, extraLabelHeight, extraLabelWidth, sharedElement.Left + sharedElement.Width - (regularLabelWidth / 2), sharedElement.Bottom + extraSpaceBetweenLabels, GetFormattedDecimal(sharedElement.EndYear), sharedFont, sharedColor);
                pnlCompatibilityBase.Controls.Add(slb);
            }

            pnlCompatibilityBase.Invalidate();
        }

        private Label CreateLabel(CompatibilityHelper element, int height, int width, int left, int top, string text, Font font, Color foreColor)
        {
            var label = new Label();

            label.Height = height;
            label.Width = width;
            label.Top = top;
            label.Left = left;
            label.Text = text;
            label.Font = font;
            label.ForeColor = foreColor;
            label.TextAlign = ContentAlignment.MiddleCenter;

            return label;
        }

        private void DrawCompatibilityObjects(List<CompatibilityHelper> elements, bool top)
        {
            foreach (var element in elements)
            {
                var panel = new Panel();

                panel.Height = element.Height;
                panel.Width = element.Width;
                panel.Top = element.Top;
                panel.Left = element.Left;
                panel.Tag = element;

                if (top) panel.Paint += CompatibilityPaintTop;
                else panel.Paint += CompatibilityPaintBottom;

                pnlCompatibilityBase.Controls.Add(panel);
            }

            pnlCompatibilityBase.Invalidate();
        }

        private void CompatibilityPaintTop(object sender, PaintEventArgs e)
        {
            var panel = sender as Panel;
            if (panel == null) return;

            var element = panel.Tag as CompatibilityHelper;

            DrawTopEllipse(e, element, ellipsePenWidth);
            DrawBottomLineForTop(e, element, topBottomLineColor, topBottomLinePenWidth);
        }
        private void CompatibilityPaintBottom(object sender, PaintEventArgs e)
        {
            var panel = sender as Panel;
            if (panel == null) return;

            var element = panel.Tag as CompatibilityHelper;

            DrawBottomEllipse(e, element, ellipsePenWidth);
            DrawTopLineForBottom(e, element, topBottomLineColor, topBottomLinePenWidth);
        }
        private void DrawTopEllipse(PaintEventArgs e, CompatibilityHelper element, int penWidth)
        {
            Pen pen = new Pen(element.EllipseColor, penWidth);
            var width = element.Right;
            var height = element.Height;
            Rectangle rect = new Rectangle(0, 0, width - 2, (height * 2) - 2);
            e.Graphics.DrawEllipse(pen, rect);
        }
        private void DrawBottomEllipse(PaintEventArgs e, CompatibilityHelper element, int penWidth)
        {
            Pen pen = new Pen(element.EllipseColor, penWidth);
            var width = element.Right;
            var height = element.Height;
            Rectangle rect = new Rectangle(0, height * -1, width - 2, (height * 2) - 2);
            e.Graphics.DrawEllipse(pen, rect);
        }
        private void DrawBottomLineForTop(PaintEventArgs e, CompatibilityHelper element, System.Drawing.Color color, int penWidth)
        {
            Pen pen = new Pen(color, penWidth);
            var width = element.Width;
            var height = element.Height;
            e.Graphics.DrawLine(pen, new Point(0, height - penWidth), new Point(width, height - penWidth));
        }
        private void DrawTopLineForBottom(PaintEventArgs e, CompatibilityHelper element, System.Drawing.Color color, int penWidth)
        {
            Pen pen = new Pen(color, penWidth);
            var width = element.Width;            
            e.Graphics.DrawLine(pen, new Point(0, 0), new Point(width, 0));
        }        
        private decimal Round(decimal input)
        {
            decimal output = 0.0M;
            decimal full = decimal.Floor(input);

            if ((input - full) <= 0.6M && (input - full) >= 0.4M) return full + 0.5M;
            if ((input - full) < 0.4M) return full;
            if ((input - full) > 0.6M) return decimal.Ceiling(input);
            return output;
        }
        private int GetCmbSelectedValue(ComboBox cmb)
        {
            if (cmb != null && cmb.SelectedValue != null)
            {
                return (int)cmb.SelectedValue;
            }
            return -1;
        }
        private void GetPeakBottom1Values(int year, out int peak1, out int bottom1)
        {
            peak1 = -1;
            bottom1 = -1;
            if (comparison1 != null)
            {
                peak1 = comparison1.GetPeakByYear(year);
                bottom1 = comparison1.GetBottomByYear(year);
            }
        }
        private void GetPeakBottom2Values(int year, out int peak2, out int bottom2)
        {
            peak2 = -1;
            bottom2 = -1;
            if (comparison2 != null)
            {
                peak2 = comparison2.GetPeakByYear(year);
                bottom2 = comparison2.GetBottomByYear(year);
            }
        }
        private void SetPeakBottom1ValuesOnUI(int peak1, int bottom1)
        {
            lblPeakNumberValue1.Text = (peak1 == -1) ? " " : "+" + peak1.ToString();
            lblProblemNumberValue1.Text = (bottom1 == -1) ? " " : ((bottom1 == 0) ? " " : "-") + bottom1.ToString();
        }
        private void SetPeakBottom2ValuesOnUI(int peak2, int bottom2)
        {
            lblPeakNumberValue2.Text = (peak2 == -1) ? " " : "+" + peak2.ToString();
            lblProblemNumberValue2.Text = (bottom2 == -1) ? " " : ((bottom2 == 0) ? " " : "-") + bottom2.ToString();
        }        
    }
    public class CompatibilityHelper
    {
        public decimal StartYear { get; set; }
        public decimal EndYear { get; set; }
        public bool IsFirstElement { get; set; }
        public bool IsLastElement { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Top { get; set; }
        public int Bottom { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }
        public System.Drawing.Color EllipseColor { get; set; }
        public bool IsSharedYear { get; set; }
    }
}
