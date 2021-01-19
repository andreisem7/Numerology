namespace Numerology.UI
{
    partial class LifeCyclePersonalMessage
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbFloor = new System.Windows.Forms.TextBox();
            this.txbCeiling = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txbCycle = new System.Windows.Forms.TextBox();
            this.txbPersonalData = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.txbPersonalData);
            this.groupBox1.Controls.Add(this.txbCycle);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txbFloor);
            this.groupBox1.Controls.Add(this.txbCeiling);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 312);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Возраст:";
            // 
            // txbFloor
            // 
            this.txbFloor.Location = new System.Drawing.Point(218, 19);
            this.txbFloor.Name = "txbFloor";
            this.txbFloor.ReadOnly = true;
            this.txbFloor.Size = new System.Drawing.Size(50, 20);
            this.txbFloor.TabIndex = 2;
            // 
            // txbCeiling
            // 
            this.txbCeiling.Location = new System.Drawing.Point(290, 19);
            this.txbCeiling.Name = "txbCeiling";
            this.txbCeiling.ReadOnly = true;
            this.txbCeiling.Size = new System.Drawing.Size(50, 20);
            this.txbCeiling.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Цикл:";
            // 
            // txbCycle
            // 
            this.txbCycle.Location = new System.Drawing.Point(59, 19);
            this.txbCycle.Name = "txbCycle";
            this.txbCycle.ReadOnly = true;
            this.txbCycle.Size = new System.Drawing.Size(95, 20);
            this.txbCycle.TabIndex = 6;
            // 
            // txbPersonalData
            // 
            this.txbPersonalData.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPersonalData.Location = new System.Drawing.Point(21, 45);
            this.txbPersonalData.Multiline = true;
            this.txbPersonalData.Name = "txbPersonalData";
            this.txbPersonalData.Size = new System.Drawing.Size(448, 225);
            this.txbPersonalData.TabIndex = 8;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(349, 276);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 24);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // LifeCyclePersonalMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 334);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LifeCyclePersonalMessage";
            this.Text = "Персональная информация";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbFloor;
        private System.Windows.Forms.TextBox txbCeiling;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbPersonalData;
        private System.Windows.Forms.TextBox txbCycle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
    }
}