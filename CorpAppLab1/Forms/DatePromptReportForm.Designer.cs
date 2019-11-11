namespace CorpAppLab1.Forms
{
    partial class DatePromptReportForm
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
            this.fromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.toDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnExportToPdf = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fromDatePicker
            // 
            this.fromDatePicker.Location = new System.Drawing.Point(107, 32);
            this.fromDatePicker.Name = "fromDatePicker";
            this.fromDatePicker.Size = new System.Drawing.Size(200, 20);
            this.fromDatePicker.TabIndex = 0;
            // 
            // toDatePicker
            // 
            this.toDatePicker.Location = new System.Drawing.Point(107, 70);
            this.toDatePicker.Name = "toDatePicker";
            this.toDatePicker.Size = new System.Drawing.Size(200, 20);
            this.toDatePicker.TabIndex = 1;
            this.toDatePicker.Value = new System.DateTime(2019, 11, 11, 22, 50, 33, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Дата от:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Дата до:";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Location = new System.Drawing.Point(53, 116);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(115, 23);
            this.btnExportExcel.TabIndex = 4;
            this.btnExportExcel.Text = "Экспорт в Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // btnExportToPdf
            // 
            this.btnExportToPdf.Location = new System.Drawing.Point(192, 116);
            this.btnExportToPdf.Name = "btnExportToPdf";
            this.btnExportToPdf.Size = new System.Drawing.Size(115, 23);
            this.btnExportToPdf.TabIndex = 5;
            this.btnExportToPdf.Text = "Экспорт в PDF";
            this.btnExportToPdf.UseVisualStyleBackColor = true;
            this.btnExportToPdf.Click += new System.EventHandler(this.btnExportToPdf_Click);
            // 
            // DatePromptReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 161);
            this.Controls.Add(this.btnExportToPdf);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toDatePicker);
            this.Controls.Add(this.fromDatePicker);
            this.Name = "DatePromptReportForm";
            this.Text = "DatePromptReportForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker fromDatePicker;
        private System.Windows.Forms.DateTimePicker toDatePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnExportToPdf;
    }
}