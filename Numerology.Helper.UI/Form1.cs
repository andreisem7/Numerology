using Numerology.Hash;
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

namespace Numerology.Helper.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();           
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (CheckClose()) base.OnClosing(e);
            else e.Cancel = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool CheckClose()
        {
            if (MessageBox.Show("Sure, you want to quit?", "Quit helper...", MessageBoxButtons.YesNo) == DialogResult.Yes) return true;
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var start = new DateTime( dtpStart.Value.Year, dtpStart.Value.Month, dtpStart.Value.Day, 0, 0, 0);
                var end = new DateTime(dtpEnd.Value.Year, dtpEnd.Value.Month, dtpEnd.Value.Day, 23, 59, 59);

                var hash = new HashHandler();
                var stringToSave = hash.ConvertFromStartEnd(start, end);

                var defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var defaultFilename = "Numerolog." + start.ToString("dd.MM.yyyy") + "-" + end.ToString("dd.MM.yyyy") + ".ins";

                saveFileDialog1.InitialDirectory = defaultPath;
                saveFileDialog1.FileName = defaultFilename;
                saveFileDialog1.Filter = "Installation file|*.ins";
                saveFileDialog1.Title = "Save hash file";
                saveFileDialog1.OverwritePrompt = true;
                saveFileDialog1.CheckPathExists = true;
                saveFileDialog1.AddExtension = true;
                saveFileDialog1.SupportMultiDottedExtensions = true;
                saveFileDialog1.DefaultExt = ".ins";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (string.IsNullOrEmpty(saveFileDialog1.FileName))
                    {
                        MessageBox.Show("No filename was provided.");
                        return;
                    }

                    defaultFilename = Path.Combine(saveFileDialog1.InitialDirectory, saveFileDialog1.FileName);
                    System.IO.File.WriteAllText(defaultFilename, stringToSave, Encoding.ASCII);

                    MessageBox.Show("Successfully saved.", "Confirmation", MessageBoxButtons.OK);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc != null ? exc.Message : "Failed to save.", "Oops...", MessageBoxButtons.OK);
            }
        }        

        private void btnCheckValue_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fullPath = openFileDialog1.FileName;
                var text = System.IO.File.ReadAllText(fullPath, Encoding.ASCII);

                var hash = new HashHandler();
                var result = hash.ConvertFromHash(text);
                MessageBox.Show("Start : " + result.Start.ToString ("dd.MM.yyyy") + " - End : " + result.End.ToString("dd.MM.yyyy HH.mm.ss"));
            }
        }
    }
}
