﻿using Microsoft.Data.ConnectionUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project;

namespace CorpAppLab1
{
    public partial class MainForm : Form
    {
        private string _connectionString;

        public MainForm()
        {
            InitializeComponent();

            foreach (var tabPage in tabPane.TabPages)
            {
                if (((TabPage)tabPage).Text != "Настройки")
                    ((TabPage)tabPage).Enabled = false;
            }
        }

        private string GetConnectionString(string supposedValue)
        {
            DataConnectionDialog connectionDialog =
               new DataConnectionDialog { TopMost = true };
            connectionDialog.DataSources.Add(DataSource.SqlDataSource);
            connectionDialog.SelectedDataSource = DataSource.SqlDataSource;
            connectionDialog.SelectedDataProvider = DataProvider.SqlDataProvider;

            SqlConnectionStringBuilder connectionBuilder =
               new SqlConnectionStringBuilder(supposedValue ?? string.Empty)
               { MultipleActiveResultSets = true };

            connectionDialog.ConnectionString = connectionBuilder.ToString();

            if (DataConnectionDialog.Show(connectionDialog) != DialogResult.OK)
                return null;

            return connectionDialog.ConnectionString;
        }

        #region actionsOnSettingsPage

        private void txtBoxConnectionString_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxConnectionString.Text))
            {
                btnSaveConnectionStringToFile.Enabled = true;
                _connectionString = CaesarEncoder.Encrypt(txtBoxConnectionString.Text, true);

                var connectionSuccessfully = new Repository(_connectionString).CheckConnection();
                if (connectionSuccessfully)
                {
                    lblConnectionStatus.Text = "Подключение к БД успешно установлено";
                    lblConnectionStatus.ForeColor = Color.ForestGreen;

                    foreach (var tabPage in tabPane.TabPages)
                    {
                        ((TabPage)tabPage).Enabled = true;
                    }

                }
                else
                {
                    lblConnectionStatus.Text = "Подключение к БД отсутствует";
                    lblConnectionStatus.ForeColor = Color.Red;

                    foreach (var tabPage in tabPane.TabPages)
                    {
                        if (((TabPage)tabPage).Text != "Настройки")
                            ((TabPage)tabPage).Enabled = false;
                    }
                }
            }
        }

        private void btnGenerateConnectionString_Click(object sender, EventArgs e)
        {
            var connectionString = GetConnectionString(string.Empty);
            if (connectionString != null)
            {
                txtBoxConnectionString.Text = CaesarEncoder.Encrypt(connectionString);
            }

        }

        private void btnLoadSettingsFromFile_Click(object sender, EventArgs e)
        {
            var explorer = new OpenFileDialog();

            if (explorer.ShowDialog() == DialogResult.OK)
            {
                var textFromFile = File.ReadAllText(explorer.FileName);

                txtBoxConnectionString.Text = textFromFile;

                _connectionString = CaesarEncoder.Encrypt(textFromFile, true);
            }

        }

        private void btnSaveConnectionStringToFile_Click(object sender, EventArgs e)
        {
            var explorer = new OpenFileDialog();

            if (explorer.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(explorer.FileName, txtBoxConnectionString.Text);

                MessageBox.Show($"Файл с настройками {explorer.FileName} успешно сохранен", "Успешно", MessageBoxButtons.OK);
            }
        }
        #endregion

        #region actionsOnRecipesPage

        private void btnShowRecipes_Click(object sender, EventArgs e)
        {
            recipesTreeView.Nodes.Clear();

            var recipes = new Repository(_connectionString).GetAllRecipes();

            foreach (var recipe in recipes)
            {
                TreeNode dishNode = new TreeNode();

                if (recipesTreeView.Nodes.ContainsKey(recipe.DishID.ToString()))
                {
                    dishNode = recipesTreeView.Nodes.Find(recipe.DishID.ToString(), false).First();
                }
                else
                {
                    dishNode = recipesTreeView.Nodes.Add(recipe.DishID.ToString(), recipe.DishName);
                }

                foreach (var ingredient in recipe.Ingredients)
                {
                    dishNode.Nodes.Add(ingredient);
                }
            }
        }
        #endregion

        private void btnShowIngredients_Click(object sender, EventArgs e)
        {
            var ingredients = new Repository(_connectionString).GetAllIngredients();

            ingredientsDataGrid.DataSource = ingredients;

            ingredientsDataGrid.Columns[0].Visible = false;
            ingredientsDataGrid.Columns[1].HeaderText = "Наименование";
            ingredientsDataGrid.Columns[2].Visible = false;
            ingredientsDataGrid.Columns[3].HeaderText = "Цена за ед.изм.";
            ingredientsDataGrid.Columns[4].HeaderText = "Единица измерения";
        }

        private void btnAddIngredient_Click(object sender, EventArgs e)
        {
            var ingredient = new Ingredient();
            ingredient.Units = new Repository(_connectionString).GetAllUnits();

            new AddOrEditIngredientForm(ingredient, _connectionString).ShowDialog(this);
        }

        private void ingredientsDataGrid_DoubleClick(object sender, EventArgs e)
        {
            var selectedIngredientRow = ingredientsDataGrid.SelectedRows[0];
            var selectedIngredient = ((Ingredient)selectedIngredientRow.DataBoundItem);
            selectedIngredient.Units = new Repository(_connectionString).GetAllUnits();
            new AddOrEditIngredientForm(selectedIngredient, _connectionString).ShowDialog(this);
        }
    }
}