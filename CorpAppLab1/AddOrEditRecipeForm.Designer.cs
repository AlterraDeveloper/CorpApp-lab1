namespace CorpAppLab1
{
    partial class AddOrEditRecipeForm
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
            this.comboBoxDishes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddIngredient = new System.Windows.Forms.Button();
            this.listBoxIngredients = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxDishes
            // 
            this.comboBoxDishes.FormattingEnabled = true;
            this.comboBoxDishes.Location = new System.Drawing.Point(81, 34);
            this.comboBoxDishes.Name = "comboBoxDishes";
            this.comboBoxDishes.Size = new System.Drawing.Size(280, 21);
            this.comboBoxDishes.TabIndex = 0;
            this.comboBoxDishes.SelectedValueChanged += new System.EventHandler(this.comboBoxDishes_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Блюдо";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ингредиенты";
            // 
            // btnAddIngredient
            // 
            this.btnAddIngredient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddIngredient.Location = new System.Drawing.Point(131, 82);
            this.btnAddIngredient.Name = "btnAddIngredient";
            this.btnAddIngredient.Size = new System.Drawing.Size(212, 32);
            this.btnAddIngredient.TabIndex = 4;
            this.btnAddIngredient.Text = "Добавить ингредиент";
            this.btnAddIngredient.UseVisualStyleBackColor = true;
            this.btnAddIngredient.Click += new System.EventHandler(this.btnAddIngredient_Click);
            // 
            // listBoxIngredients
            // 
            this.listBoxIngredients.FormattingEnabled = true;
            this.listBoxIngredients.Location = new System.Drawing.Point(17, 133);
            this.listBoxIngredients.Name = "listBoxIngredients";
            this.listBoxIngredients.Size = new System.Drawing.Size(344, 160);
            this.listBoxIngredients.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(17, 315);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(344, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AddOrEditRecipeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 361);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.listBoxIngredients);
            this.Controls.Add(this.btnAddIngredient);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxDishes);
            this.Name = "AddOrEditRecipeForm";
            this.Text = "AddOrEditRecipeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDishes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddIngredient;
        private System.Windows.Forms.ListBox listBoxIngredients;
        private System.Windows.Forms.Button btnSave;
    }
}