namespace CorpAppLab1.Forms
{
    partial class AddDishToOrderForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBoxDishes = new System.Windows.Forms.ComboBox();
            this.numInputPortion = new System.Windows.Forms.NumericUpDown();
            this.btnAddDish = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numInputPortion)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(25, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Блюдо";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(25, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Кол-во порций";
            // 
            // cmbBoxDishes
            // 
            this.cmbBoxDishes.FormattingEnabled = true;
            this.cmbBoxDishes.Location = new System.Drawing.Point(178, 24);
            this.cmbBoxDishes.Name = "cmbBoxDishes";
            this.cmbBoxDishes.Size = new System.Drawing.Size(196, 21);
            this.cmbBoxDishes.TabIndex = 2;
            // 
            // numInputPortion
            // 
            this.numInputPortion.Location = new System.Drawing.Point(178, 70);
            this.numInputPortion.Name = "numInputPortion";
            this.numInputPortion.Size = new System.Drawing.Size(196, 20);
            this.numInputPortion.TabIndex = 3;
            // 
            // btnAddDish
            // 
            this.btnAddDish.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAddDish.Location = new System.Drawing.Point(103, 122);
            this.btnAddDish.Name = "btnAddDish";
            this.btnAddDish.Size = new System.Drawing.Size(222, 34);
            this.btnAddDish.TabIndex = 4;
            this.btnAddDish.Text = "Добавить";
            this.btnAddDish.UseVisualStyleBackColor = true;
            this.btnAddDish.Click += new System.EventHandler(this.btnAddDish_Click);
            // 
            // AddDishToOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 168);
            this.Controls.Add(this.btnAddDish);
            this.Controls.Add(this.numInputPortion);
            this.Controls.Add(this.cmbBoxDishes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddDishToOrderForm";
            this.Text = "AddDishToOrderForm";
            ((System.ComponentModel.ISupportInitialize)(this.numInputPortion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBoxDishes;
        private System.Windows.Forms.NumericUpDown numInputPortion;
        private System.Windows.Forms.Button btnAddDish;
    }
}