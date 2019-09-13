﻿namespace CorpAppLab1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.settingsTabPage = new System.Windows.Forms.TabPage();
            this.ingredientsTabPage = new System.Windows.Forms.TabPage();
            this.btnAddIngredient = new System.Windows.Forms.Button();
            this.btnEditIngredient = new System.Windows.Forms.Button();
            this.ingredientsDataGrid = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.recipesTabPage = new System.Windows.Forms.TabPage();
            this.btnAddRecipe = new System.Windows.Forms.Button();
            this.btnEditRecipe = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.recipesTreeView = new System.Windows.Forms.TreeView();
            this.tabPane = new System.Windows.Forms.TabControl();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLoadSettingsFromFile = new System.Windows.Forms.Button();
            this.btnGenerateConnectionString = new System.Windows.Forms.Button();
            this.txtBoxConnectionString = new System.Windows.Forms.TextBox();
            this.btnSaveConnectionStringToFile = new System.Windows.Forms.Button();
            this.btnShowRecipes = new System.Windows.Forms.Button();
            this.settingsTabPage.SuspendLayout();
            this.ingredientsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsDataGrid)).BeginInit();
            this.recipesTabPage.SuspendLayout();
            this.tabPane.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingsTabPage
            // 
            this.settingsTabPage.Controls.Add(this.btnSaveConnectionStringToFile);
            this.settingsTabPage.Controls.Add(this.txtBoxConnectionString);
            this.settingsTabPage.Controls.Add(this.btnGenerateConnectionString);
            this.settingsTabPage.Controls.Add(this.btnLoadSettingsFromFile);
            this.settingsTabPage.Controls.Add(this.label3);
            this.settingsTabPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.settingsTabPage.Name = "settingsTabPage";
            this.settingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.settingsTabPage.Size = new System.Drawing.Size(752, 492);
            this.settingsTabPage.TabIndex = 2;
            this.settingsTabPage.Text = "Настройки";
            this.settingsTabPage.UseVisualStyleBackColor = true;
            // 
            // ingredientsTabPage
            // 
            this.ingredientsTabPage.Controls.Add(this.label2);
            this.ingredientsTabPage.Controls.Add(this.ingredientsDataGrid);
            this.ingredientsTabPage.Controls.Add(this.btnEditIngredient);
            this.ingredientsTabPage.Controls.Add(this.btnAddIngredient);
            this.ingredientsTabPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ingredientsTabPage.Location = new System.Drawing.Point(4, 22);
            this.ingredientsTabPage.Name = "ingredientsTabPage";
            this.ingredientsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ingredientsTabPage.Size = new System.Drawing.Size(752, 492);
            this.ingredientsTabPage.TabIndex = 1;
            this.ingredientsTabPage.Text = "Ингредиенты";
            this.ingredientsTabPage.UseVisualStyleBackColor = true;
            // 
            // btnAddIngredient
            // 
            this.btnAddIngredient.Location = new System.Drawing.Point(527, 6);
            this.btnAddIngredient.Name = "btnAddIngredient";
            this.btnAddIngredient.Size = new System.Drawing.Size(112, 38);
            this.btnAddIngredient.TabIndex = 0;
            this.btnAddIngredient.Text = "Добавить";
            this.btnAddIngredient.UseVisualStyleBackColor = true;
            // 
            // btnEditIngredient
            // 
            this.btnEditIngredient.Location = new System.Drawing.Point(645, 6);
            this.btnEditIngredient.Name = "btnEditIngredient";
            this.btnEditIngredient.Size = new System.Drawing.Size(101, 38);
            this.btnEditIngredient.TabIndex = 1;
            this.btnEditIngredient.Text = "Изменить";
            this.btnEditIngredient.UseVisualStyleBackColor = true;
            // 
            // ingredientsDataGrid
            // 
            this.ingredientsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ingredientsDataGrid.Location = new System.Drawing.Point(6, 62);
            this.ingredientsDataGrid.Name = "ingredientsDataGrid";
            this.ingredientsDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ingredientsDataGrid.Size = new System.Drawing.Size(740, 424);
            this.ingredientsDataGrid.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Справочник ингредиентов";
            // 
            // recipesTabPage
            // 
            this.recipesTabPage.Controls.Add(this.btnShowRecipes);
            this.recipesTabPage.Controls.Add(this.recipesTreeView);
            this.recipesTabPage.Controls.Add(this.label1);
            this.recipesTabPage.Controls.Add(this.btnEditRecipe);
            this.recipesTabPage.Controls.Add(this.btnAddRecipe);
            this.recipesTabPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recipesTabPage.Location = new System.Drawing.Point(4, 22);
            this.recipesTabPage.Name = "recipesTabPage";
            this.recipesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.recipesTabPage.Size = new System.Drawing.Size(752, 492);
            this.recipesTabPage.TabIndex = 0;
            this.recipesTabPage.Text = "Рецепты";
            this.recipesTabPage.UseVisualStyleBackColor = true;
            // 
            // btnAddRecipe
            // 
            this.btnAddRecipe.BackColor = System.Drawing.Color.Transparent;
            this.btnAddRecipe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddRecipe.Location = new System.Drawing.Point(530, 6);
            this.btnAddRecipe.Name = "btnAddRecipe";
            this.btnAddRecipe.Size = new System.Drawing.Size(103, 34);
            this.btnAddRecipe.TabIndex = 1;
            this.btnAddRecipe.Text = "Добавить";
            this.btnAddRecipe.UseVisualStyleBackColor = true;
            // 
            // btnEditRecipe
            // 
            this.btnEditRecipe.Location = new System.Drawing.Point(639, 6);
            this.btnEditRecipe.Name = "btnEditRecipe";
            this.btnEditRecipe.Size = new System.Drawing.Size(107, 34);
            this.btnEditRecipe.TabIndex = 2;
            this.btnEditRecipe.Text = "Изменить";
            this.btnEditRecipe.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Справочник рецептов";
            // 
            // recipesTreeView
            // 
            this.recipesTreeView.Location = new System.Drawing.Point(11, 50);
            this.recipesTreeView.Name = "recipesTreeView";
            this.recipesTreeView.Size = new System.Drawing.Size(735, 436);
            this.recipesTreeView.TabIndex = 4;
            // 
            // tabPane
            // 
            this.tabPane.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPane.Controls.Add(this.recipesTabPage);
            this.tabPane.Controls.Add(this.ingredientsTabPage);
            this.tabPane.Controls.Add(this.settingsTabPage);
            this.tabPane.Location = new System.Drawing.Point(13, 13);
            this.tabPane.Name = "tabPane";
            this.tabPane.SelectedIndex = 0;
            this.tabPane.Size = new System.Drawing.Size(760, 518);
            this.tabPane.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(274, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Подключение к БД";
            // 
            // btnLoadSettingsFromFile
            // 
            this.btnLoadSettingsFromFile.Location = new System.Drawing.Point(21, 53);
            this.btnLoadSettingsFromFile.Name = "btnLoadSettingsFromFile";
            this.btnLoadSettingsFromFile.Size = new System.Drawing.Size(347, 37);
            this.btnLoadSettingsFromFile.TabIndex = 1;
            this.btnLoadSettingsFromFile.Text = "Загрузить настройки из файла";
            this.btnLoadSettingsFromFile.UseVisualStyleBackColor = true;
            this.btnLoadSettingsFromFile.Click += new System.EventHandler(this.btnLoadSettingsFromFile_Click);
            // 
            // btnGenerateConnectionString
            // 
            this.btnGenerateConnectionString.Location = new System.Drawing.Point(411, 53);
            this.btnGenerateConnectionString.Name = "btnGenerateConnectionString";
            this.btnGenerateConnectionString.Size = new System.Drawing.Size(335, 37);
            this.btnGenerateConnectionString.TabIndex = 2;
            this.btnGenerateConnectionString.Text = "Сгенерировать строку подключения";
            this.btnGenerateConnectionString.UseVisualStyleBackColor = true;
            this.btnGenerateConnectionString.Click += new System.EventHandler(this.btnGenerateConnectionString_Click);
            // 
            // txtBoxConnectionString
            // 
            this.txtBoxConnectionString.Location = new System.Drawing.Point(21, 118);
            this.txtBoxConnectionString.Multiline = true;
            this.txtBoxConnectionString.Name = "txtBoxConnectionString";
            this.txtBoxConnectionString.Size = new System.Drawing.Size(597, 223);
            this.txtBoxConnectionString.TabIndex = 3;
            this.txtBoxConnectionString.TextChanged += new System.EventHandler(this.txtBoxConnectionString_TextChanged);
            // 
            // btnSaveConnectionStringToFile
            // 
            this.btnSaveConnectionStringToFile.Enabled = false;
            this.btnSaveConnectionStringToFile.Location = new System.Drawing.Point(624, 118);
            this.btnSaveConnectionStringToFile.Name = "btnSaveConnectionStringToFile";
            this.btnSaveConnectionStringToFile.Size = new System.Drawing.Size(122, 223);
            this.btnSaveConnectionStringToFile.TabIndex = 4;
            this.btnSaveConnectionStringToFile.Text = "Cохранить строку подключения в файл";
            this.btnSaveConnectionStringToFile.UseVisualStyleBackColor = true;
            this.btnSaveConnectionStringToFile.Click += new System.EventHandler(this.btnSaveConnectionStringToFile_Click);
            // 
            // btnShowRecipes
            // 
            this.btnShowRecipes.Location = new System.Drawing.Point(427, 6);
            this.btnShowRecipes.Name = "btnShowRecipes";
            this.btnShowRecipes.Size = new System.Drawing.Size(97, 34);
            this.btnShowRecipes.TabIndex = 5;
            this.btnShowRecipes.Text = "Показать";
            this.btnShowRecipes.UseVisualStyleBackColor = true;
            this.btnShowRecipes.Click += new System.EventHandler(this.btnShowRecipes_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 543);
            this.Controls.Add(this.tabPane);
            this.Name = "Form1";
            this.Text = "Form1";
            this.settingsTabPage.ResumeLayout(false);
            this.settingsTabPage.PerformLayout();
            this.ingredientsTabPage.ResumeLayout(false);
            this.ingredientsTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsDataGrid)).EndInit();
            this.recipesTabPage.ResumeLayout(false);
            this.recipesTabPage.PerformLayout();
            this.tabPane.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage settingsTabPage;
        private System.Windows.Forms.TabPage ingredientsTabPage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView ingredientsDataGrid;
        private System.Windows.Forms.Button btnEditIngredient;
        private System.Windows.Forms.Button btnAddIngredient;
        private System.Windows.Forms.TabPage recipesTabPage;
        private System.Windows.Forms.TreeView recipesTreeView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEditRecipe;
        private System.Windows.Forms.Button btnAddRecipe;
        private System.Windows.Forms.TabControl tabPane;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSaveConnectionStringToFile;
        private System.Windows.Forms.TextBox txtBoxConnectionString;
        private System.Windows.Forms.Button btnGenerateConnectionString;
        private System.Windows.Forms.Button btnLoadSettingsFromFile;
        private System.Windows.Forms.Button btnShowRecipes;
    }
}

