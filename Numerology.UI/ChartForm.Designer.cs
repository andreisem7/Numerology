namespace Numerology.UI
{
    partial class ChartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.grbSelectedPerson = new System.Windows.Forms.GroupBox();
            this.chrPeaks = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txbFile = new System.Windows.Forms.TextBox();
            this.btnSelectPerson = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.grbSelectedPerson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrPeaks)).BeginInit();
            this.SuspendLayout();
            // 
            // grbSelectedPerson
            // 
            this.grbSelectedPerson.Controls.Add(this.chrPeaks);
            this.grbSelectedPerson.Controls.Add(this.txbFile);
            this.grbSelectedPerson.Controls.Add(this.btnSelectPerson);
            this.grbSelectedPerson.Controls.Add(this.lblFileName);
            this.grbSelectedPerson.Location = new System.Drawing.Point(13, 13);
            this.grbSelectedPerson.Name = "grbSelectedPerson";
            this.grbSelectedPerson.Size = new System.Drawing.Size(775, 425);
            this.grbSelectedPerson.TabIndex = 0;
            this.grbSelectedPerson.TabStop = false;
            this.grbSelectedPerson.Text = "Выбранный объект";
            // 
            // chrPeaks
            // 
            this.chrPeaks.BorderlineWidth = 5;
            chartArea1.AxisX.Interval = 5D;
            chartArea1.AxisX.IntervalOffset = 5D;
            chartArea1.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisX.Maximum = 100D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisY.Interval = 1D;
            chartArea1.AxisY.Maximum = 10D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.Name = "ChartArea1";
            this.chrPeaks.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chrPeaks.Legends.Add(legend1);
            this.chrPeaks.Location = new System.Drawing.Point(22, 76);
            this.chrPeaks.Name = "chrPeaks";
            this.chrPeaks.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.CustomProperties = "IsXAxisQuantitative=True";
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Peaks";
            series1.XValueMember = "X";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series1.YValueMembers = "Y";
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chrPeaks.Series.Add(series1);
            this.chrPeaks.Size = new System.Drawing.Size(747, 343);
            this.chrPeaks.TabIndex = 3;
            this.chrPeaks.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "График 5-ти летних циклов";
            this.chrPeaks.Titles.Add(title1);
            // 
            // txbFile
            // 
            this.txbFile.Location = new System.Drawing.Point(22, 50);
            this.txbFile.Name = "txbFile";
            this.txbFile.ReadOnly = true;
            this.txbFile.Size = new System.Drawing.Size(277, 20);
            this.txbFile.TabIndex = 2;
            // 
            // btnSelectPerson
            // 
            this.btnSelectPerson.Location = new System.Drawing.Point(224, 21);
            this.btnSelectPerson.Name = "btnSelectPerson";
            this.btnSelectPerson.Size = new System.Drawing.Size(75, 23);
            this.btnSelectPerson.TabIndex = 1;
            this.btnSelectPerson.Text = "Выбрать";
            this.btnSelectPerson.UseVisualStyleBackColor = true;
            this.btnSelectPerson.Click += new System.EventHandler(this.btnSelectPerson_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(19, 26);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(67, 13);
            this.lblFileName.TabIndex = 0;
            this.lblFileName.Text = "Имя файла:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grbSelectedPerson);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChartForm";
            this.Text = "График";
            this.grbSelectedPerson.ResumeLayout(false);
            this.grbSelectedPerson.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrPeaks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbSelectedPerson;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnSelectPerson;
        private System.Windows.Forms.TextBox txbFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrPeaks;
    }
}