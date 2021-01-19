namespace Numerology.UI
{
    partial class PersonalYearForm
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
            this.grbLifeway = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlPersonalMonthBase = new System.Windows.Forms.Panel();
            this.lblPersonalYearExtended = new System.Windows.Forms.Label();
            this.lblPersonalYearSimple = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.cmbDate = new System.Windows.Forms.ComboBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.saveForPrint = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.grbLifeway.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbLifeway
            // 
            this.grbLifeway.Controls.Add(this.saveForPrint);
            this.grbLifeway.Controls.Add(this.btnClose);
            this.grbLifeway.Controls.Add(this.label2);
            this.grbLifeway.Controls.Add(this.pnlPersonalMonthBase);
            this.grbLifeway.Controls.Add(this.lblPersonalYearExtended);
            this.grbLifeway.Controls.Add(this.lblPersonalYearSimple);
            this.grbLifeway.Controls.Add(this.label1);
            this.grbLifeway.Controls.Add(this.btnGo);
            this.grbLifeway.Controls.Add(this.cmbYear);
            this.grbLifeway.Controls.Add(this.cmbMonth);
            this.grbLifeway.Controls.Add(this.cmbDate);
            this.grbLifeway.Controls.Add(this.lblYear);
            this.grbLifeway.Controls.Add(this.lblMonth);
            this.grbLifeway.Controls.Add(this.lblDate);
            this.grbLifeway.Location = new System.Drawing.Point(10, 12);
            this.grbLifeway.Name = "grbLifeway";
            this.grbLifeway.Size = new System.Drawing.Size(525, 363);
            this.grbLifeway.TabIndex = 0;
            this.grbLifeway.TabStop = false;
            this.grbLifeway.Text = "Личный год";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(331, 330);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(175, 23);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Личный месяц:";
            // 
            // pnlPersonalMonthBase
            // 
            this.pnlPersonalMonthBase.BackColor = System.Drawing.Color.Black;
            this.pnlPersonalMonthBase.Location = new System.Drawing.Point(18, 138);
            this.pnlPersonalMonthBase.Name = "pnlPersonalMonthBase";
            this.pnlPersonalMonthBase.Size = new System.Drawing.Size(488, 186);
            this.pnlPersonalMonthBase.TabIndex = 10;
            // 
            // lblPersonalYearExtended
            // 
            this.lblPersonalYearExtended.AutoSize = true;
            this.lblPersonalYearExtended.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonalYearExtended.ForeColor = System.Drawing.Color.Red;
            this.lblPersonalYearExtended.Location = new System.Drawing.Point(137, 91);
            this.lblPersonalYearExtended.Name = "lblPersonalYearExtended";
            this.lblPersonalYearExtended.Size = new System.Drawing.Size(30, 24);
            this.lblPersonalYearExtended.TabIndex = 9;
            this.lblPersonalYearExtended.Text = "00";
            // 
            // lblPersonalYearSimple
            // 
            this.lblPersonalYearSimple.AutoSize = true;
            this.lblPersonalYearSimple.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonalYearSimple.ForeColor = System.Drawing.Color.Black;
            this.lblPersonalYearSimple.Location = new System.Drawing.Point(101, 91);
            this.lblPersonalYearSimple.Name = "lblPersonalYearSimple";
            this.lblPersonalYearSimple.Size = new System.Drawing.Size(30, 24);
            this.lblPersonalYearSimple.TabIndex = 8;
            this.lblPersonalYearSimple.Text = "00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Личный год:";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(331, 56);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(175, 23);
            this.btnGo.TabIndex = 6;
            this.btnGo.Text = "Рассчитать";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // cmbYear
            // 
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(239, 58);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(86, 21);
            this.cmbYear.TabIndex = 5;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // cmbMonth
            // 
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(105, 58);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(121, 21);
            this.cmbMonth.TabIndex = 4;
            this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.cmbMonth_SelectedIndexChanged);
            // 
            // cmbDate
            // 
            this.cmbDate.FormattingEnabled = true;
            this.cmbDate.Location = new System.Drawing.Point(18, 58);
            this.cmbDate.Name = "cmbDate";
            this.cmbDate.Size = new System.Drawing.Size(72, 21);
            this.cmbDate.TabIndex = 3;
            this.cmbDate.SelectedIndexChanged += new System.EventHandler(this.cmbDate_SelectedIndexChanged);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(236, 34);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(25, 13);
            this.lblYear.TabIndex = 2;
            this.lblYear.Text = "Год";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(102, 34);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(40, 13);
            this.lblMonth.TabIndex = 1;
            this.lblMonth.Text = "Месяц";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(15, 34);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(33, 13);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Дата";
            // 
            // saveForPrint
            // 
            this.saveForPrint.Location = new System.Drawing.Point(331, 91);
            this.saveForPrint.Name = "saveForPrint";
            this.saveForPrint.Size = new System.Drawing.Size(175, 23);
            this.saveForPrint.TabIndex = 13;
            this.saveForPrint.Text = "Сохранить для печати";
            this.saveForPrint.UseVisualStyleBackColor = true;
            this.saveForPrint.Click += new System.EventHandler(this.saveForPrint_Click);
            // 
            // PersonalYearForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 384);
            this.Controls.Add(this.grbLifeway);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PersonalYearForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Личный год";
            this.grbLifeway.ResumeLayout(false);
            this.grbLifeway.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbLifeway;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.ComboBox cmbDate;
        private System.Windows.Forms.Label lblPersonalYearExtended;
        private System.Windows.Forms.Label lblPersonalYearSimple;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlPersonalMonthBase;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button saveForPrint;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}