using Microsoft.Data.ConnectionUI;
using Project;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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

        #region actions on Settings page

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

        #region actions on Recipes page

        private void FillOrRefreshGridOfRecipes()
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

                foreach (var ingredient in recipe.IngredientsAsString)
                {
                    dishNode.Nodes.Add(ingredient);
                }
            }
        }

        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            var repo = new Repository(_connectionString);
            var recipe = new Recipe();
            recipe.Dishes = repo.GetAllDishes();
            recipe.Ingredients = repo.GetAllIngredients();
            var dialogResult = new AddOrEditRecipeForm(recipe, _connectionString).ShowDialog(this);
            if (dialogResult == DialogResult.Cancel) FillOrRefreshGridOfRecipes();
        }

        private void recipesTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                var repo = new Repository(_connectionString);
                var dishName = e.Node.Text;
                var recipe = repo.GetRecipeByDishName(dishName);
                recipe.Dishes = repo.GetAllDishes();
                recipe.Ingredients = repo.GetAllIngredients();
                var dialogResult = new AddOrEditRecipeForm(recipe, _connectionString).ShowDialog(this);
                if (dialogResult == DialogResult.Cancel) FillOrRefreshGridOfRecipes();
            }
        }
        #endregion

        #region actions on Ingredients page

        private void ingredientsDataGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseOverRow = ingredientsDataGrid.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow >= 0)
                {
                    ingredientsDataGrid.Rows[currentMouseOverRow].Selected = true;
                }

                contextMenuStripIngredients.Show(ingredientsDataGrid, new Point(e.X, e.Y));

            }
        }

        private void FillOrRefreshGridOfIngredients()
        {
            var ingredients = new Repository(_connectionString).GetAllIngredients();

            ingredientsDataGrid.DataSource = ingredients;

            ingredientsDataGrid.Columns[0].Visible = false;
            ingredientsDataGrid.Columns[1].HeaderText = "Наименование";
            ingredientsDataGrid.Columns[2].Visible = false;
            ingredientsDataGrid.Columns[3].HeaderText = "Цена за ед.изм.";
            ingredientsDataGrid.Columns[4].HeaderText = "Единица измерения";
        }

        private void addIngredient_Click(object sender, EventArgs e)
        {
            var ingredient = new Ingredient();
            ingredient.Units = new Repository(_connectionString).GetAllUnits();

            var dialogResult = new AddOrEditIngredientForm(ingredient, _connectionString).ShowDialog(this);
            if (dialogResult == DialogResult.OK) FillOrRefreshGridOfIngredients();
        }

        private void editIngredient_Click(object sender, EventArgs e)
        {
            var selectedIngredientRow = ingredientsDataGrid.SelectedRows[0];
            var selectedIngredient = ((Ingredient)selectedIngredientRow.DataBoundItem);
            selectedIngredient.Units = new Repository(_connectionString).GetAllUnits();
            var dialogResult = new AddOrEditIngredientForm(selectedIngredient, _connectionString).ShowDialog(this);
            if (dialogResult == DialogResult.OK) FillOrRefreshGridOfIngredients();
        }

        private void deleteIngredient_Click(object sender, EventArgs e)
        {
            var selectedIngredientRow = ingredientsDataGrid.SelectedRows[0];
            var selectedIngredient = ((Ingredient)selectedIngredientRow.DataBoundItem);
            var dialogResult = MessageBox.Show($"Вы действительно хотите удалить ингредиент : {selectedIngredient.IngredientName} ?", "Предупреждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                new Repository(_connectionString).DeleteIngredient(selectedIngredient.IngredientID);
                FillOrRefreshGridOfIngredients();
            }
        }


        #endregion

        #region actions on AuxReference page

        private void FillOrRefreshGridOfDishes()
        {
            var dishes = new Repository(_connectionString).GetAllDishes();

            dataGridViewDishes.DataSource = dishes;

            dataGridViewDishes.Columns[0].Visible = false;
            dataGridViewDishes.Columns[1].HeaderText = "Наименование";
        }

        private void dataGridViewDishes_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseOverRow = dataGridViewDishes.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow >= 0)
                {
                    dataGridViewDishes.Rows[currentMouseOverRow].Selected = true;
                }

                contextMenuStripDishes.Show(dataGridViewDishes, new Point(e.X, e.Y));

            }
        }

        private void addDish_Click(object sender, EventArgs e)
        {
            var dialogResult = new AddOrEditSimpleEntity(new Dish(), _connectionString).ShowDialog(this);
            if (dialogResult == DialogResult.OK) FillOrRefreshGridOfDishes();
        }

        private void editDish_Click(object sender, EventArgs e)
        {
            var selectedDishRow = dataGridViewDishes.SelectedRows[0];
            var selectedDish = ((Dish)selectedDishRow.DataBoundItem);
            var dialogResult = new AddOrEditSimpleEntity(selectedDish, _connectionString).ShowDialog(this);
            if (dialogResult == DialogResult.OK) FillOrRefreshGridOfDishes();
        }

        private void deleteDish_Click(object sender, EventArgs e)
        {
            var selectedDishRow = dataGridViewDishes.SelectedRows[0];
            var selectedDish = ((Dish)selectedDishRow.DataBoundItem);
            var dialogResult = MessageBox.Show($"Вы действительно хотите удалить блюдо : {selectedDish.DishName} ?", "Предупреждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                new Repository(_connectionString).DeleteDish(selectedDish.DishID);
                FillOrRefreshGridOfDishes();
            }
        }

        private void FillOrRefreshGridOfUnits()
        {
            var units = new Repository(_connectionString).GetAllUnits();

            dataGridViewUnits.DataSource = units;

            dataGridViewUnits.Columns[0].Visible = false;
            dataGridViewUnits.Columns[1].HeaderText = "Наименование";
        }

        private void dataGridViewUnits_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseOverRow = dataGridViewUnits.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow >= 0)
                {
                    dataGridViewUnits.Rows[currentMouseOverRow].Selected = true;
                }

                contextMenuStripUnits.Show(dataGridViewUnits, new Point(e.X, e.Y));

            }
        }

        private void addUnit_Click(object sender, EventArgs e)
        {
            var dialogResult = new AddOrEditSimpleEntity(new Unit(), _connectionString).ShowDialog(this);
            if(dialogResult == DialogResult.OK) FillOrRefreshGridOfUnits();
        }

        private void editUnit_Click(object sender, EventArgs e)
        {
            var selectedUnitRow = dataGridViewUnits.SelectedRows[0];
            var selectedUnit = ((Unit)selectedUnitRow.DataBoundItem);
            var dialogResult = new AddOrEditSimpleEntity(selectedUnit, _connectionString).ShowDialog(this);
            if (dialogResult == DialogResult.OK) FillOrRefreshGridOfUnits();
        }

        private void deleteUnit_Click(object sender, EventArgs e)
        {
            var selectedUnitRow = dataGridViewUnits.SelectedRows[0];
            var selectedUnit = ((Unit)selectedUnitRow.DataBoundItem);
            var dialogResult = MessageBox.Show($"Вы действительно хотите удалить единицу измерения : {selectedUnit.UnitName} ?", "Предупреждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                new Repository(_connectionString).DeleteUnit(selectedUnit.UnitID);
                FillOrRefreshGridOfUnits();
            }
        }

        #endregion

        private void tabPane_Selected(object sender, TabControlEventArgs e)
        {
            var tab = e.TabPage;
            if (tab != null && tab.Enabled)
            {
                switch (tab.Name)
                {
                    case "ingredientsTabPage":
                        FillOrRefreshGridOfIngredients();
                        break;
                    case "recipesTabPage":
                        FillOrRefreshGridOfRecipes();
                        break;
                    case "auxReferencesTabPane":
                        FillOrRefreshGridOfDishes();
                        FillOrRefreshGridOfUnits();
                        break;
                }
            }
        }
    }
}
