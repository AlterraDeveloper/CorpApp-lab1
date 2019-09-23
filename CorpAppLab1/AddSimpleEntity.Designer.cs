namespace CorpAppLab1
{
    partial class AddSimpleEntity
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.btnSaveEntity = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Наименование";
            // 
            // txtBoxName
            // 
            this.txtBoxName.Location = new System.Drawing.Point(101, 36);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(303, 20);
            this.txtBoxName.TabIndex = 1;
            // 
            // btnSaveEntity
            // 
            this.btnSaveEntity.Location = new System.Drawing.Point(15, 75);
            this.btnSaveEntity.Name = "btnSaveEntity";
            this.btnSaveEntity.Size = new System.Drawing.Size(389, 23);
            this.btnSaveEntity.TabIndex = 2;
            this.btnSaveEntity.Text = "Сохранить";
            this.btnSaveEntity.UseVisualStyleBackColor = true;
            this.btnSaveEntity.Click += new System.EventHandler(this.btnSaveEntity_Click);
            // 
            // AddSimpleEntity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 136);
            this.Controls.Add(this.btnSaveEntity);
            this.Controls.Add(this.txtBoxName);
            this.Controls.Add(this.label1);
            this.Name = "AddSimpleEntity";
            this.Text = "AddSimpleEntity";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.Button btnSaveEntity;
    }
}