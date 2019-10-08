namespace CorpAppLab1
{
    partial class AddIngredientToRecipeForm
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
            this.comboBoxIngredients = new System.Windows.Forms.ComboBox();
            this.inputQuantity = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.labelUnitName = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.inputQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxIngredients
            // 
            this.comboBoxIngredients.Location = new System.Drawing.Point(102, 15);
            this.comboBoxIngredients.Name = "comboBoxIngredients";
            this.comboBoxIngredients.Size = new System.Drawing.Size(284, 21);
            this.comboBoxIngredients.TabIndex = 0;
            this.comboBoxIngredients.SelectedValueChanged += new System.EventHandler(this.comboBoxIngredients_SelectedValueChanged);
            // 
            // inputQuantity
            // 
            this.inputQuantity.Location = new System.Drawing.Point(13, 52);
            this.inputQuantity.Name = "inputQuantity";
            this.inputQuantity.Size = new System.Drawing.Size(120, 20);
            this.inputQuantity.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ингредиент";
            // 
            // labelUnitName
            // 
            this.labelUnitName.AutoSize = true;
            this.labelUnitName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUnitName.Location = new System.Drawing.Point(139, 52);
            this.labelUnitName.Name = "labelUnitName";
            this.labelUnitName.Size = new System.Drawing.Size(0, 17);
            this.labelUnitName.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(13, 88);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(373, 32);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // AddIngredientToRecipeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 149);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.labelUnitName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputQuantity);
            this.Controls.Add(this.comboBoxIngredients);
            this.Name = "AddIngredientToRecipeForm";
            this.Text = "AddIngredientToRecipeForm";
            ((System.ComponentModel.ISupportInitialize)(this.inputQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxIngredients;
        private System.Windows.Forms.NumericUpDown inputQuantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelUnitName;
        private System.Windows.Forms.Button btnAdd;
    }
}