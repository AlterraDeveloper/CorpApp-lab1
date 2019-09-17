namespace CorpAppLab1
{
    partial class AddOrEditIngredientForm
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
            this.txtBoxIngrName = new System.Windows.Forms.TextBox();
            this.cmbBoxUnit = new System.Windows.Forms.ComboBox();
            this.numInputUnitPrice = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numInputUnitPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBoxIngrName
            // 
            this.txtBoxIngrName.Location = new System.Drawing.Point(180, 18);
            this.txtBoxIngrName.Name = "txtBoxIngrName";
            this.txtBoxIngrName.Size = new System.Drawing.Size(174, 20);
            this.txtBoxIngrName.TabIndex = 0;
            // 
            // cmbBoxUnit
            // 
            this.cmbBoxUnit.FormattingEnabled = true;
            this.cmbBoxUnit.Location = new System.Drawing.Point(180, 55);
            this.cmbBoxUnit.Name = "cmbBoxUnit";
            this.cmbBoxUnit.Size = new System.Drawing.Size(174, 21);
            this.cmbBoxUnit.TabIndex = 1;
            // 
            // numInputUnitPrice
            // 
            this.numInputUnitPrice.Location = new System.Drawing.Point(180, 94);
            this.numInputUnitPrice.Name = "numInputUnitPrice";
            this.numInputUnitPrice.Size = new System.Drawing.Size(174, 20);
            this.numInputUnitPrice.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Наименование";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ед.изм.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Цена за ед.изм.";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(44, 144);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(310, 35);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AddOrEditIngredientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 198);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numInputUnitPrice);
            this.Controls.Add(this.cmbBoxUnit);
            this.Controls.Add(this.txtBoxIngrName);
            this.Name = "AddOrEditIngredientForm";
            ((System.ComponentModel.ISupportInitialize)(this.numInputUnitPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxIngrName;
        private System.Windows.Forms.ComboBox cmbBoxUnit;
        private System.Windows.Forms.NumericUpDown numInputUnitPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
    }
}