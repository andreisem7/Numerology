namespace Numerology.UI
{
    partial class PersonalMonthForm
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
            this.pnlPersonalDayBase = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.saveForPrint = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblDateValue = new System.Windows.Forms.Label();
            this.lblMonthValue = new System.Windows.Forms.Label();
            this.lblYearValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlPersonalDayBase
            // 
            this.pnlPersonalDayBase.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlPersonalDayBase.Location = new System.Drawing.Point(12, 42);
            this.pnlPersonalDayBase.Name = "pnlPersonalDayBase";
            this.pnlPersonalDayBase.Size = new System.Drawing.Size(510, 434);
            this.pnlPersonalDayBase.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(347, 482);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(175, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // saveForPrint
            // 
            this.saveForPrint.Location = new System.Drawing.Point(12, 482);
            this.saveForPrint.Name = "saveForPrint";
            this.saveForPrint.Size = new System.Drawing.Size(175, 23);
            this.saveForPrint.TabIndex = 2;
            this.saveForPrint.Text = "Сохранить для печати";
            this.saveForPrint.UseVisualStyleBackColor = true;
            this.saveForPrint.Click += new System.EventHandler(this.saveForPrint_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(19, 15);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(36, 13);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "Дата:";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(109, 15);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(43, 13);
            this.lblMonth.TabIndex = 4;
            this.lblMonth.Text = "Месяц:";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(263, 15);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(28, 13);
            this.lblYear.TabIndex = 5;
            this.lblYear.Text = "Год:";
            // 
            // lblDateValue
            // 
            this.lblDateValue.AutoSize = true;
            this.lblDateValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateValue.Location = new System.Drawing.Point(61, 9);
            this.lblDateValue.Name = "lblDateValue";
            this.lblDateValue.Size = new System.Drawing.Size(32, 24);
            this.lblDateValue.TabIndex = 6;
            this.lblDateValue.Text = "00";
            // 
            // lblMonthValue
            // 
            this.lblMonthValue.AutoSize = true;
            this.lblMonthValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonthValue.Location = new System.Drawing.Point(155, 9);
            this.lblMonthValue.Name = "lblMonthValue";
            this.lblMonthValue.Size = new System.Drawing.Size(98, 24);
            this.lblMonthValue.TabIndex = 7;
            this.lblMonthValue.Text = "00000000";
            // 
            // lblYearValue
            // 
            this.lblYearValue.AutoSize = true;
            this.lblYearValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYearValue.Location = new System.Drawing.Point(297, 9);
            this.lblYearValue.Name = "lblYearValue";
            this.lblYearValue.Size = new System.Drawing.Size(54, 24);
            this.lblYearValue.TabIndex = 8;
            this.lblYearValue.Text = "0000";
            // 
            // PersonalMonthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 513);
            this.Controls.Add(this.lblYearValue);
            this.Controls.Add(this.lblMonthValue);
            this.Controls.Add(this.lblDateValue);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.saveForPrint);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlPersonalDayBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PersonalMonthForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlPersonalDayBase;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button saveForPrint;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblDateValue;
        private System.Windows.Forms.Label lblMonthValue;
        private System.Windows.Forms.Label lblYearValue;
    }
}