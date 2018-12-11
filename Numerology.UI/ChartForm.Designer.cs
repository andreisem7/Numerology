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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartForm));
            this.grbSelectedPerson = new System.Windows.Forms.GroupBox();
            this.chrPeaks = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txbFile = new System.Windows.Forms.TextBox();
            this.btnSelectPerson = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.grbSelectedPerson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrPeaks)).BeginInit();
            this.SuspendLayout();
            // 
            // grbSelectedPerson
            // 
            this.grbSelectedPerson.Controls.Add(this.textBox1);
            this.grbSelectedPerson.Controls.Add(this.chrPeaks);
            this.grbSelectedPerson.Controls.Add(this.txbFile);
            this.grbSelectedPerson.Controls.Add(this.btnSelectPerson);
            this.grbSelectedPerson.Controls.Add(this.lblFileName);
            this.grbSelectedPerson.Location = new System.Drawing.Point(13, 13);
            this.grbSelectedPerson.Name = "grbSelectedPerson";
            this.grbSelectedPerson.Size = new System.Drawing.Size(775, 712);
            this.grbSelectedPerson.TabIndex = 0;
            this.grbSelectedPerson.TabStop = false;
            this.grbSelectedPerson.Text = "Выбранный объект";
            // 
            // chrPeaks
            // 
            this.chrPeaks.BorderlineWidth = 5;
            chartArea2.AxisX.Interval = 5D;
            chartArea2.AxisX.IntervalOffset = 5D;
            chartArea2.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisX.Maximum = 100D;
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.AxisY.Interval = 1D;
            chartArea2.AxisY.Maximum = 9D;
            chartArea2.AxisY.Minimum = 0D;
            chartArea2.Name = "ChartArea1";
            this.chrPeaks.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chrPeaks.Legends.Add(legend2);
            this.chrPeaks.Location = new System.Drawing.Point(22, 76);
            this.chrPeaks.Name = "chrPeaks";
            this.chrPeaks.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.CustomProperties = "IsXAxisQuantitative=True";
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "Peaks";
            series2.XValueMember = "X";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series2.YValueMembers = "Y";
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chrPeaks.Series.Add(series2);
            this.chrPeaks.Size = new System.Drawing.Size(747, 343);
            this.chrPeaks.TabIndex = 3;
            this.chrPeaks.Text = "chart1";
            title2.Name = "Title1";
            title2.Text = "График 5-ти летних циклов";
            this.chrPeaks.Titles.Add(title2);
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
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(26, 438);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(742, 273);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 729);
            this.Controls.Add(this.grbSelectedPerson);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(816, 768);
            this.MinimumSize = new System.Drawing.Size(816, 768);
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
        private System.Windows.Forms.TextBox textBox1;
    }
}