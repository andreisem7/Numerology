using Numerology.BL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Numerology.UI
{
    public partial class LifeCycles : Form
    {
        private const string CUSTOMER_FOLDER_NAME = "Customers";
        private NumerologyObject numerologyObject = null;
        private LifeCycleManager manager = null;
        private const int YEARS_BACK = 5;
        private const int YEARS_FORWARD = 60;
        private Comparison personalData = null;

        public LifeCycles()
        {
            InitializeComponent();
            InitYears();
            numerologyObject = InitNumerologyObject();
            openFileDialog1.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, CUSTOMER_FOLDER_NAME);
            manager = new LifeCycleManager();
            manager.Init();
        }
        private NumerologyObject InitNumerologyObject()
        {
            return Manager.InitNumerologyObject();
        }

        private void lblCycleValue_Click(object sender, EventArgs e)
        {
            LifeCycleTagObject tag = null;
            var label = sender as Label;
            if (label != null) tag = label.Tag as LifeCycleTagObject;

            if (tag != null && tag.IsSelected)
            {
                using (LifeCyclePersonalMessage personalMessage = new LifeCyclePersonalMessage(tag))
                {
                    personalMessage.WindowState = FormWindowState.Normal;
                    personalMessage.StartPosition = FormStartPosition.CenterParent;

                    personalMessage.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Tag object is missing.");
            }
        }

        private void btnCleanData_Click(object sender, EventArgs e)
        {
            numerologyObject = null;
            personalData = null;
            InitUI(true);
            numerologyObject = InitNumerologyObject();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectPerson_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                InitUI(false);

                var fullPath = openFileDialog1.FileName;
                txbFile.Text = Path.GetFileName(fullPath);

                personalData = numerologyObject.ReadPersonalData(fullPath);
                txbDOB.Text = personalData.DOB.ToString("dd.MM.yyyy");
                var year = GetCmbSelectedValue(cmbYears);

                numerologyObject.DOBObject.SetDate(personalData.DOB.Day, personalData.DOB.Month, personalData.DOB.Year);
                var viewModel = manager.GetFinalized(numerologyObject.DOBObject.DOB, numerologyObject.DOBObject.GetLifeWayNumber, numerologyObject.DOBObject.IsMasterNumberDOB, year);

                SetAge(GetAgeObject(numerologyObject.DOBObject.DOB, year));
                SetViewModelToUI(viewModel);
            }
        }
        private void cmbYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitUI(false);

            if (personalData != null && numerologyObject != null)
            {
                txbDOB.Text = personalData.DOB.ToString("dd.MM.yyyy");
                var year = GetCmbSelectedValue(cmbYears);

                numerologyObject.DOBObject.SetDate(personalData.DOB.Day, personalData.DOB.Month, personalData.DOB.Year);
                var viewModel = manager.GetFinalized(numerologyObject.DOBObject.DOB, numerologyObject.DOBObject.GetLifeWayNumber, numerologyObject.DOBObject.IsMasterNumberDOB, year);

                SetAge(GetAgeObject(numerologyObject.DOBObject.DOB, year));
                SetViewModelToUI(viewModel);
            }
        }
        private void SetAge(AgeObject age)
        {
            lblDate1.Text = age.UpperLine;
            lblDate1Value.Text = age.UpperAge;

            lblDate2.Text = age.BottomLine;
            lblDate2Value.Text = age.BottomAge;
        }
        private AgeObject GetAgeObject(DateTime dob, int year)
        {
            AgeObject result = new AgeObject();
            var day = dob.Day;
            if (dob.Month == 2 && dob.Day == 29)
            {
                if (!DateTime.IsLeapYear(year)) day = 28;
            }

            var newDate = new DateTime(year, dob.Month, day);
            var prevDay = newDate.AddDays(-1);

            var prev = newDate.Year - dob.Year - 1;
            result.UpperLine = "(до " + prevDay.ToString("dd.MM.yyyy") + ")";
            result.UpperAge = prev.ToString();
            result.BottomLine = "(после " + newDate.ToString("dd.MM.yyyy") + ")";
            var current = newDate.Year - dob.Year;
            result.BottomAge = current.ToString();

            return result;
        }
        private string GetLifeWayNumberValue(LifeCycleViewModel viewModel)
        {
            return viewModel.LifeWayNumber + (viewModel.IsMaster ? " - " + viewModel.MasterLifeWayNumber + "/" + viewModel.LifeWayNumber : "");
        }
        private string GetCycleInterval(LifeCycleViewModel viewModel, int cycle)
        {
            var result = viewModel.Cycles.FirstOrDefault(x => x.Cycle == cycle);
            if (result == null) return "";
            if (cycle == 3) return result.PeriodFloor + " - ...";
            else return result.PeriodFloor + " - " + result.PeriodCeiling;
        }
        private LifeCycleTagObject GetCycle(LifeCycleViewModel viewModel, int cycle)
        {
            return viewModel.Cycles.FirstOrDefault(x => x.Cycle == cycle && x.IsMaster == viewModel.IsMaster);
        }
        private void SetViewModelToUI(LifeCycleViewModel viewModel)
        {
            lblLifeWayNumberValue.Text = GetLifeWayNumberValue(viewModel);
            var cycle1 = GetCycle(viewModel, 1);
            if (cycle1.IsSelected)
            {
                lblCycleOne.ForeColor = Color.Red;
                lblCycleOneInterval.ForeColor = Color.Red;
                lblCycleOneMonthValue.Text = cycle1.Number.ToString();
                lblCycleOneMonthValue.ForeColor = Color.Red;
                lblCycleOneMonthValue.Tag = cycle1;//??
            }
            else
            {
                lblCycleOne.ForeColor = Color.Black;
                lblCycleOneInterval.ForeColor = Color.Black;
                lblCycleOneMonthValue.Text = "";
                lblCycleOneMonthValue.ForeColor = Color.Black;
                lblCycleOneMonthValue.Tag = null;
            }
            lblCycleOneInterval.Text = GetCycleInterval(viewModel, 1);

            var cycle2 = GetCycle(viewModel, 2);
            if (cycle2.IsSelected)
            {
                lblCycleTwo.ForeColor = Color.Red;
                lblCycleTwoInterval.ForeColor = Color.Red;
                lblCycleTwoDateValue.Text = cycle2.Number.ToString();
                lblCycleTwoDateValue.ForeColor = Color.Red;
                lblCycleTwoDateValue.Tag = cycle2;
            }
            else
            {
                lblCycleTwo.ForeColor = Color.Black;
                lblCycleTwoInterval.ForeColor = Color.Black;
                lblCycleTwoDateValue.Text = "";
                lblCycleTwoDateValue.ForeColor = Color.Black;
                lblCycleTwoDateValue.Tag = null;
            }
            lblCycleTwoInterval.Text = GetCycleInterval(viewModel, 2);

            var cycle3 = GetCycle(viewModel, 3);
            if (cycle3.IsSelected)
            {
                lblCycleThree.ForeColor = Color.Red;
                lblCycleThreeInterval.ForeColor = Color.Red;
                lblCycleThreeYearValue.Text = cycle3.Number.ToString();
                lblCycleThreeYearValue.ForeColor = Color.Red;
                lblCycleThreeYearValue.Tag = cycle3;
            }
            else
            {
                lblCycleThree.ForeColor = Color.Black;
                lblCycleThreeInterval.ForeColor = Color.Black;
                lblCycleThreeYearValue.Text = "";
                lblCycleThreeYearValue.ForeColor = Color.Black;
                lblCycleThreeYearValue.Tag = null;
            }
            lblCycleThreeInterval.Text = GetCycleInterval(viewModel, 3);
        }
        private void InitUI(bool fullRefresh)
        {
            if (fullRefresh)
            {
                txbFile.Text = "";
                txbDOB.Text = "";

                InitYears();
            }

            lblDate1.Text = "";
            lblDate2.Text = "";

            lblDate1Value.Text = "";
            lblDate2Value.Text = "";

            lblLifeWayNumberValue.Text = "";

            lblCycleOne.ForeColor = Color.Black;
            lblCycleOneInterval.Text = "";
            lblCycleOneInterval.ForeColor = Color.Black;
            lblCycleOneMonthValue.Text = "";
            lblCycleOneMonthValue.ForeColor = Color.Black;
            lblCycleOneMonthValue.Tag = null;

            lblCycleTwo.ForeColor = Color.Black;
            lblCycleTwoInterval.Text = "";
            lblCycleTwoInterval.ForeColor = Color.Black;
            lblCycleTwoDateValue.Text = "";
            lblCycleTwoDateValue.ForeColor = Color.Black;
            lblCycleTwoDateValue.Tag = null;

            lblCycleThree.ForeColor = Color.Black;
            lblCycleThreeInterval.Text = "";
            lblCycleThreeInterval.ForeColor = Color.Black;
            lblCycleThreeYearValue.Text = "";
            lblCycleThreeYearValue.ForeColor = Color.Black;
            lblCycleThreeYearValue.Tag = null;
        }
        private void InitYears()
        {
            cmbYears.DataSource = null;
            cmbYears.DataSource = GetYears();
            cmbYears.SelectedItem = (object)DateTime.Now.Year;
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

        internal class AgeObject
        {
            public string UpperLine { get; set; }
            public string UpperAge { get; set; }
            public string BottomLine { get; set; }
            public string BottomAge { get; set; }
        }
    }
}
