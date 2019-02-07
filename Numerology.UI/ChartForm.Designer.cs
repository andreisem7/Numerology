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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.grbSelectedPerson = new System.Windows.Forms.GroupBox();
            this.txbDescription = new System.Windows.Forms.TextBox();
            this.chrPeaks = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txbFile = new System.Windows.Forms.TextBox();
            this.btnSelectPerson = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.grbSelectedPerson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrPeaks)).BeginInit();
            this.SuspendLayout();
            // 
            // grbSelectedPerson
            // 
            this.grbSelectedPerson.Controls.Add(this.button1);
            this.grbSelectedPerson.Controls.Add(this.txbDescription);
            this.grbSelectedPerson.Controls.Add(this.chrPeaks);
            this.grbSelectedPerson.Controls.Add(this.txbFile);
            this.grbSelectedPerson.Controls.Add(this.btnSelectPerson);
            this.grbSelectedPerson.Controls.Add(this.lblFileName);
            this.grbSelectedPerson.Location = new System.Drawing.Point(13, 13);
            this.grbSelectedPerson.Name = "grbSelectedPerson";
            this.grbSelectedPerson.Size = new System.Drawing.Size(775, 681);
            this.grbSelectedPerson.TabIndex = 0;
            this.grbSelectedPerson.TabStop = false;
            this.grbSelectedPerson.Text = "Выбранный объект";
            // 
            // txbDescription
            // 
            this.txbDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDescription.Location = new System.Drawing.Point(22, 400);
            this.txbDescription.Multiline = true;
            this.txbDescription.Name = "txbDescription";
            this.txbDescription.Size = new System.Drawing.Size(742, 273);
            this.txbDescription.TabIndex = 4;
            this.txbDescription.Text = resources.GetString("txbDescription.Text");
            // 
            // chrPeaks
            // 
            this.chrPeaks.BorderlineWidth = 5;
            chartArea4.AxisX.Interval = 5D;
            chartArea4.AxisX.IntervalOffset = 5D;
            chartArea4.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea4.AxisX.Maximum = 100D;
            chartArea4.AxisX.Minimum = 0D;
            chartArea4.AxisY.Interval = 1D;
            chartArea4.AxisY.Maximum = 9D;
            chartArea4.AxisY.Minimum = 0D;
            chartArea4.Name = "ChartArea1";
            this.chrPeaks.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chrPeaks.Legends.Add(legend4);
            this.chrPeaks.Location = new System.Drawing.Point(22, 76);
            this.chrPeaks.Name = "chrPeaks";
            this.chrPeaks.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.CustomProperties = "IsXAxisQuantitative=True";
            series4.IsVisibleInLegend = false;
            series4.Legend = "Legend1";
            series4.Name = "Peaks";
            series4.XValueMember = "X";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series4.YValueMembers = "Y";
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chrPeaks.Series.Add(series4);
            this.chrPeaks.Size = new System.Drawing.Size(747, 311);
            this.chrPeaks.TabIndex = 3;
            this.chrPeaks.Text = "chart1";
            title4.Name = "Title1";
            title4.Text = "График 5-ти летних циклов";
            this.chrPeaks.Titles.Add(title4);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(621, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Сохранить для печати";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 701);
            this.Controls.Add(this.grbSelectedPerson);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(816, 740);
            this.MinimumSize = new System.Drawing.Size(816, 740);
            this.Name = "ChartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.TextBox txbDescription;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}