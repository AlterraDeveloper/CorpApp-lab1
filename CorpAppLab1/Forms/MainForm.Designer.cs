namespace CorpAppLab1
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.settingsTabPage = new System.Windows.Forms.TabPage();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.btnSaveConnectionStringToFile = new System.Windows.Forms.Button();
            this.txtBoxConnectionString = new System.Windows.Forms.TextBox();
            this.btnGenerateConnectionString = new System.Windows.Forms.Button();
            this.btnLoadSettingsFromFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ingredientsTabPage = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.ingredientsDataGrid = new System.Windows.Forms.DataGridView();
            this.recipesTabPage = new System.Windows.Forms.TabPage();
            this.recipesTreeView = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddRecipe = new System.Windows.Forms.Button();
            this.tabPane = new System.Windows.Forms.TabControl();
            this.auxReferencesTabPane = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewUnits = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewDishes = new System.Windows.Forms.DataGridView();
            this.contextMenuStripIngredients = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addIngredient = new System.Windows.Forms.ToolStripMenuItem();
            this.editIngredient = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteIngredient = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripDishes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addDish = new System.Windows.Forms.ToolStripMenuItem();
            this.editDish = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDish = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripUnits = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addUnit = new System.Windows.Forms.ToolStripMenuItem();
            this.editUnit = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteUnit = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsTabPage.SuspendLayout();
            this.ingredientsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsDataGrid)).BeginInit();
            this.recipesTabPage.SuspendLayout();
            this.tabPane.SuspendLayout();
            this.auxReferencesTabPane.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUnits)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDishes)).BeginInit();
            this.contextMenuStripIngredients.SuspendLayout();
            this.contextMenuStripDishes.SuspendLayout();
            this.contextMenuStripUnits.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingsTabPage
            // 
            this.settingsTabPage.Controls.Add(this.lblConnectionStatus);
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
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectionStatus.ForeColor = System.Drawing.Color.Red;
            this.lblConnectionStatus.Location = new System.Drawing.Point(21, 348);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(280, 20);
            this.lblConnectionStatus.TabIndex = 5;
            this.lblConnectionStatus.Text = "Подключение к БД отсутствует";
            // 
            // btnSaveConnectionStringToFile
            // 
            this.btnSaveConnectionStringToFile.Enabled = false;
            this.btnSaveConnectionStringToFile.Location = new System.Drawing.Point(606, 118);
            this.btnSaveConnectionStringToFile.Name = "btnSaveConnectionStringToFile";
            this.btnSaveConnectionStringToFile.Size = new System.Drawing.Size(122, 223);
            this.btnSaveConnectionStringToFile.TabIndex = 4;
            this.btnSaveConnectionStringToFile.Text = "Cохранить строку подключения в файл";
            this.btnSaveConnectionStringToFile.UseVisualStyleBackColor = true;
            this.btnSaveConnectionStringToFile.Click += new System.EventHandler(this.btnSaveConnectionStringToFile_Click);
            // 
            // txtBoxConnectionString
            // 
            this.txtBoxConnectionString.Location = new System.Drawing.Point(21, 118);
            this.txtBoxConnectionString.Multiline = true;
            this.txtBoxConnectionString.Name = "txtBoxConnectionString";
            this.txtBoxConnectionString.ReadOnly = true;
            this.txtBoxConnectionString.Size = new System.Drawing.Size(566, 223);
            this.txtBoxConnectionString.TabIndex = 3;
            this.txtBoxConnectionString.TextChanged += new System.EventHandler(this.txtBoxConnectionString_TextChanged);
            // 
            // btnGenerateConnectionString
            // 
            this.btnGenerateConnectionString.Location = new System.Drawing.Point(411, 53);
            this.btnGenerateConnectionString.Name = "btnGenerateConnectionString";
            this.btnGenerateConnectionString.Size = new System.Drawing.Size(317, 37);
            this.btnGenerateConnectionString.TabIndex = 2;
            this.btnGenerateConnectionString.Text = "Сгенерировать строку подключения";
            this.btnGenerateConnectionString.UseVisualStyleBackColor = true;
            this.btnGenerateConnectionString.Click += new System.EventHandler(this.btnGenerateConnectionString_Click);
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
            // ingredientsTabPage
            // 
            this.ingredientsTabPage.Controls.Add(this.label2);
            this.ingredientsTabPage.Controls.Add(this.ingredientsDataGrid);
            this.ingredientsTabPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ingredientsTabPage.Location = new System.Drawing.Point(4, 22);
            this.ingredientsTabPage.Name = "ingredientsTabPage";
            this.ingredientsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ingredientsTabPage.Size = new System.Drawing.Size(752, 492);
            this.ingredientsTabPage.TabIndex = 1;
            this.ingredientsTabPage.Text = "Ингредиенты";
            this.ingredientsTabPage.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(257, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Справочник ингредиентов";
            // 
            // ingredientsDataGrid
            // 
            this.ingredientsDataGrid.AllowUserToAddRows = false;
            this.ingredientsDataGrid.AllowUserToDeleteRows = false;
            this.ingredientsDataGrid.AllowUserToResizeRows = false;
            this.ingredientsDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ingredientsDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ingredientsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ingredientsDataGrid.Location = new System.Drawing.Point(6, 62);
            this.ingredientsDataGrid.MultiSelect = false;
            this.ingredientsDataGrid.Name = "ingredientsDataGrid";
            this.ingredientsDataGrid.ReadOnly = true;
            this.ingredientsDataGrid.RowHeadersVisible = false;
            this.ingredientsDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ingredientsDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ingredientsDataGrid.Size = new System.Drawing.Size(740, 424);
            this.ingredientsDataGrid.TabIndex = 2;
            this.ingredientsDataGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ingredientsDataGrid_MouseClick);
            // 
            // recipesTabPage
            // 
            this.recipesTabPage.Controls.Add(this.recipesTreeView);
            this.recipesTabPage.Controls.Add(this.label1);
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
            // recipesTreeView
            // 
            this.recipesTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recipesTreeView.Location = new System.Drawing.Point(11, 50);
            this.recipesTreeView.Name = "recipesTreeView";
            this.recipesTreeView.Size = new System.Drawing.Size(735, 436);
            this.recipesTreeView.TabIndex = 4;
            this.recipesTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.recipesTreeView_NodeMouseDoubleClick);
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
            // btnAddRecipe
            // 
            this.btnAddRecipe.BackColor = System.Drawing.Color.Transparent;
            this.btnAddRecipe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddRecipe.Location = new System.Drawing.Point(643, 10);
            this.btnAddRecipe.Name = "btnAddRecipe";
            this.btnAddRecipe.Size = new System.Drawing.Size(103, 34);
            this.btnAddRecipe.TabIndex = 1;
            this.btnAddRecipe.Text = "Добавить";
            this.btnAddRecipe.UseVisualStyleBackColor = true;
            this.btnAddRecipe.Click += new System.EventHandler(this.btnAddRecipe_Click);
            // 
            // tabPane
            // 
            this.tabPane.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPane.Controls.Add(this.settingsTabPage);
            this.tabPane.Controls.Add(this.recipesTabPage);
            this.tabPane.Controls.Add(this.ingredientsTabPage);
            this.tabPane.Controls.Add(this.auxReferencesTabPane);
            this.tabPane.Location = new System.Drawing.Point(13, 13);
            this.tabPane.Name = "tabPane";
            this.tabPane.SelectedIndex = 0;
            this.tabPane.Size = new System.Drawing.Size(760, 518);
            this.tabPane.TabIndex = 0;
            this.tabPane.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabPane_Selected);
            // 
            // auxReferencesTabPane
            // 
            this.auxReferencesTabPane.Controls.Add(this.groupBox2);
            this.auxReferencesTabPane.Controls.Add(this.groupBox1);
            this.auxReferencesTabPane.Location = new System.Drawing.Point(4, 22);
            this.auxReferencesTabPane.Name = "auxReferencesTabPane";
            this.auxReferencesTabPane.Padding = new System.Windows.Forms.Padding(3);
            this.auxReferencesTabPane.Size = new System.Drawing.Size(752, 492);
            this.auxReferencesTabPane.TabIndex = 3;
            this.auxReferencesTabPane.Text = "Доп.справочники";
            this.auxReferencesTabPane.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridViewUnits);
            this.groupBox2.Location = new System.Drawing.Point(386, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(356, 467);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Единицы измерения";
            // 
            // dataGridViewUnits
            // 
            this.dataGridViewUnits.AllowUserToAddRows = false;
            this.dataGridViewUnits.AllowUserToDeleteRows = false;
            this.dataGridViewUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewUnits.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUnits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUnits.Location = new System.Drawing.Point(7, 19);
            this.dataGridViewUnits.MultiSelect = false;
            this.dataGridViewUnits.Name = "dataGridViewUnits";
            this.dataGridViewUnits.ReadOnly = true;
            this.dataGridViewUnits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUnits.Size = new System.Drawing.Size(343, 442);
            this.dataGridViewUnits.TabIndex = 6;
            this.dataGridViewUnits.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewUnits_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.dataGridViewDishes);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 467);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Блюда";
            // 
            // dataGridViewDishes
            // 
            this.dataGridViewDishes.AllowUserToAddRows = false;
            this.dataGridViewDishes.AllowUserToDeleteRows = false;
            this.dataGridViewDishes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewDishes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDishes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDishes.Location = new System.Drawing.Point(7, 19);
            this.dataGridViewDishes.MultiSelect = false;
            this.dataGridViewDishes.Name = "dataGridViewDishes";
            this.dataGridViewDishes.ReadOnly = true;
            this.dataGridViewDishes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDishes.Size = new System.Drawing.Size(343, 442);
            this.dataGridViewDishes.TabIndex = 3;
            this.dataGridViewDishes.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewDishes_MouseClick);
            // 
            // contextMenuStripIngredients
            // 
            this.contextMenuStripIngredients.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addIngredient,
            this.editIngredient,
            this.deleteIngredient});
            this.contextMenuStripIngredients.Name = "contextMenuStripIngredients";
            this.contextMenuStripIngredients.Size = new System.Drawing.Size(155, 70);
            // 
            // addIngredient
            // 
            this.addIngredient.Name = "addIngredient";
            this.addIngredient.Size = new System.Drawing.Size(154, 22);
            this.addIngredient.Text = "Добавить";
            this.addIngredient.Click += new System.EventHandler(this.addIngredient_Click);
            // 
            // editIngredient
            // 
            this.editIngredient.Name = "editIngredient";
            this.editIngredient.Size = new System.Drawing.Size(154, 22);
            this.editIngredient.Text = "Редактировать";
            this.editIngredient.Click += new System.EventHandler(this.editIngredient_Click);
            // 
            // deleteIngredient
            // 
            this.deleteIngredient.Name = "deleteIngredient";
            this.deleteIngredient.Size = new System.Drawing.Size(154, 22);
            this.deleteIngredient.Text = "Удалить";
            this.deleteIngredient.Click += new System.EventHandler(this.deleteIngredient_Click);
            // 
            // contextMenuStripDishes
            // 
            this.contextMenuStripDishes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDish,
            this.editDish,
            this.deleteDish});
            this.contextMenuStripDishes.Name = "contextMenuStripDishes";
            this.contextMenuStripDishes.Size = new System.Drawing.Size(155, 70);
            // 
            // addDish
            // 
            this.addDish.Name = "addDish";
            this.addDish.Size = new System.Drawing.Size(154, 22);
            this.addDish.Text = "Добавить";
            this.addDish.Click += new System.EventHandler(this.addDish_Click);
            // 
            // editDish
            // 
            this.editDish.Name = "editDish";
            this.editDish.Size = new System.Drawing.Size(154, 22);
            this.editDish.Text = "Редактировать";
            this.editDish.Click += new System.EventHandler(this.editDish_Click);
            // 
            // deleteDish
            // 
            this.deleteDish.Name = "deleteDish";
            this.deleteDish.Size = new System.Drawing.Size(154, 22);
            this.deleteDish.Text = "Удалить";
            this.deleteDish.Click += new System.EventHandler(this.deleteDish_Click);
            // 
            // contextMenuStripUnits
            // 
            this.contextMenuStripUnits.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addUnit,
            this.editUnit,
            this.deleteUnit});
            this.contextMenuStripUnits.Name = "contextMenuStripUnits";
            this.contextMenuStripUnits.Size = new System.Drawing.Size(155, 70);
            // 
            // addUnit
            // 
            this.addUnit.Name = "addUnit";
            this.addUnit.Size = new System.Drawing.Size(154, 22);
            this.addUnit.Text = "Добавить";
            this.addUnit.Click += new System.EventHandler(this.addUnit_Click);
            // 
            // editUnit
            // 
            this.editUnit.Name = "editUnit";
            this.editUnit.Size = new System.Drawing.Size(154, 22);
            this.editUnit.Text = "Редактировать";
            this.editUnit.Click += new System.EventHandler(this.editUnit_Click);
            // 
            // deleteUnit
            // 
            this.deleteUnit.Name = "deleteUnit";
            this.deleteUnit.Size = new System.Drawing.Size(154, 22);
            this.deleteUnit.Text = "Удалить";
            this.deleteUnit.Click += new System.EventHandler(this.deleteUnit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 543);
            this.Controls.Add(this.tabPane);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.settingsTabPage.ResumeLayout(false);
            this.settingsTabPage.PerformLayout();
            this.ingredientsTabPage.ResumeLayout(false);
            this.ingredientsTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsDataGrid)).EndInit();
            this.recipesTabPage.ResumeLayout(false);
            this.recipesTabPage.PerformLayout();
            this.tabPane.ResumeLayout(false);
            this.auxReferencesTabPane.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUnits)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDishes)).EndInit();
            this.contextMenuStripIngredients.ResumeLayout(false);
            this.contextMenuStripDishes.ResumeLayout(false);
            this.contextMenuStripUnits.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage settingsTabPage;
        private System.Windows.Forms.TabPage ingredientsTabPage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView ingredientsDataGrid;
        private System.Windows.Forms.TabPage recipesTabPage;
        private System.Windows.Forms.TreeView recipesTreeView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddRecipe;
        private System.Windows.Forms.TabControl tabPane;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSaveConnectionStringToFile;
        private System.Windows.Forms.TextBox txtBoxConnectionString;
        private System.Windows.Forms.Button btnGenerateConnectionString;
        private System.Windows.Forms.Button btnLoadSettingsFromFile;
        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.TabPage auxReferencesTabPane;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewUnits;
        private System.Windows.Forms.DataGridView dataGridViewDishes;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripIngredients;
        private System.Windows.Forms.ToolStripMenuItem editIngredient;
        private System.Windows.Forms.ToolStripMenuItem deleteIngredient;
        private System.Windows.Forms.ToolStripMenuItem addIngredient;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDishes;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripUnits;
        private System.Windows.Forms.ToolStripMenuItem addDish;
        private System.Windows.Forms.ToolStripMenuItem editDish;
        private System.Windows.Forms.ToolStripMenuItem deleteDish;
        private System.Windows.Forms.ToolStripMenuItem addUnit;
        private System.Windows.Forms.ToolStripMenuItem editUnit;
        private System.Windows.Forms.ToolStripMenuItem deleteUnit;
    }
}

