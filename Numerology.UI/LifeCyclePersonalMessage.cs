using Numerology.BL;
using System;
using System.Windows.Forms;

namespace Numerology.UI
{
    public partial class LifeCyclePersonalMessage : Form
    {
        private readonly LifeCycleTagObject tagObject = null;
        public LifeCyclePersonalMessage()
        {
            InitializeComponent();
        }
        public LifeCyclePersonalMessage(LifeCycleTagObject tag)
        {
            InitializeComponent();
            tagObject = tag;
            ShowPersonalData(tagObject);
        }
        private void ShowPersonalData(LifeCycleTagObject tag)
        {
            if (tag == null) return;

            txbCycle.Text = GetCycleString(tag);
            txbFloor.Text = tag.PeriodFloor.ToString();
            txbCeiling.Text = tag.PeriodCeiling.ToString();
            txbPersonalData.Text = GetPersonalText(tag);
        }
        private string GetCycleString(LifeCycleTagObject tag)
        {
            if (tag == null) return null;

            var cycle = String.Empty;
            switch (tag.Cycle)
            {
                case 1: { cycle = "Первый"; break; }
                case 2: { cycle = "Второй"; break; }
                case 3: { cycle = "Третий"; break; }
            }
            return cycle;
        }
        private string GetPersonalText(LifeCycleTagObject tag)
        {
            if (tag == null) return null;

            string text = String.Empty;
            if (tag.IsMaster)
            {
                switch (tag.LifeWayNumber)
                {
                    case 2: { text = LifeCycleText.Master2; break; }
                    case 4: { text = LifeCycleText.Master4; break; }
                    case 6: { text = LifeCycleText.Master6; break; }
                }
            }
            else
            {
                switch (tag.Cycle)
                {
                    case 1:
                        {
                            switch (tag.Number)
                            {
                                case 1: { text = LifeCycleText.N1C1; break; }
                                case 2: { text = LifeCycleText.N2C1; break; }
                                case 3: { text = LifeCycleText.N3C1; break; }
                                case 4: { text = LifeCycleText.N4C1; break; }
                                case 5: { text = LifeCycleText.N5C1; break; }
                                case 6: { text = LifeCycleText.N6C1; break; }
                                case 7: { text = LifeCycleText.N7C1; break; }
                                case 8: { text = LifeCycleText.N8C1; break; }
                                case 9: { text = LifeCycleText.N9C1; break; }
                            }
                            break;
                        }
                    case 2:
                        {
                            switch (tag.Number)
                            {
                                case 1: { text = LifeCycleText.N1C2; break; }
                                case 2: { text = LifeCycleText.N2C2; break; }
                                case 3: { text = LifeCycleText.N3C2; break; }
                                case 4: { text = LifeCycleText.N4C2; break; }
                                case 5: { text = LifeCycleText.N5C2; break; }
                                case 6: { text = LifeCycleText.N6C2; break; }
                                case 7: { text = LifeCycleText.N7C2; break; }
                                case 8: { text = LifeCycleText.N8C2; break; }
                                case 9: { text = LifeCycleText.N9C2; break; }
                            }
                            break;
                        }
                    case 3:
                        {
                            switch (tag.Number)
                            {
                                case 1: { text = LifeCycleText.N1C3; break; }
                                case 2: { text = LifeCycleText.N2C3; break; }
                                case 3: { text = LifeCycleText.N3C3; break; }
                                case 4: { text = LifeCycleText.N4C3; break; }
                                case 5: { text = LifeCycleText.N5C3; break; }
                                case 6: { text = LifeCycleText.N6C3; break; }
                                case 7: { text = LifeCycleText.N7C3; break; }
                                case 8: { text = LifeCycleText.N8C3; break; }
                                case 9: { text = LifeCycleText.N9C3; break; }
                            }
                            break;
                        }
                }
            }
            return text;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
