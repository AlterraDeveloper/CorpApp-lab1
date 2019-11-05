using CorpAppLab1.DataAccessLayer;
using Microsoft.Data.ConnectionUI;
using Project;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CorpAppLab1.Forms;
using CorpAppLab1.Models;
using RecipeRepository = CorpAppLab1.DataAccessLayer.RecipeRepository;

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

        private void FillOrRefreshTreeOfRecipes()
        {
            recipesTreeView.Nodes.Clear();

            var recipes = new RecipeRepository(_connectionString).GetAll();

            foreach (var recipe in recipes)
            {
                TreeNode dishNode = new TreeNode();

                if (recipesTreeView.Nodes.ContainsKey(recipe.DishID.ToString()))
                {
                    dishNode = recipesTreeView.Nodes.Find(recipe.DishID.ToString(), false).First();
                }
                else
                {
                    var dishName = new DishRepository(_connectionString).GetById(recipe.DishID)?.DishName;
                    dishNode = recipesTreeView.Nodes.Add(recipe.DishID.ToString(), dishName);
                }

                foreach (var pair in recipe.IngredientIdsAndQuantities)
                {
                    var ingr = new IngredientRepository(_connectionString).GetById(pair.Key);
                    var unitName = new UnitRepository(_connectionString).GetAll().FirstOrDefault(x => x.UnitID == ingr.UnitID).UnitName;
                    dishNode.Nodes.Add(ingr.IngredientName + " " + pair.Value + " " + unitName);
                }
            }
        }

        private void addRecipe_Click(object sender, EventArgs e)
        {
            var recipe = new Recipe
            {
                Dishes = new DishRepository(_connectionString).GetAll(),
                Ingredients = new IngredientRepository(_connectionString).GetAll(),
                Units = new UnitRepository(_connectionString).GetAll(),
            };
            var dialogResult = new AddOrEditRecipeForm(recipe, _connectionString).ShowDialog(this);
            if (dialogResult == DialogResult.Cancel) FillOrRefreshTreeOfRecipes();
        }

        private void editRecipe_Click(object sender, EventArgs e)
        {
            var dishName = recipesTreeView.SelectedNode.Text;

            var dishID = new DishRepository(_connectionString).GetAll().First(x => x.DishName == dishName).DishID;

            var recipe = new RecipeRepository(_connectionString).GetById(dishID);
            recipe.Dishes = new DishRepository(_connectionString).GetAll();
            recipe.Ingredients = new IngredientRepository(_connectionString).GetAll();
            recipe.Units = new UnitRepository(_connectionString).GetAll();

            var dialogResult = new AddOrEditRecipeForm(recipe, _connectionString).ShowDialog(this);
            if (dialogResult == DialogResult.Cancel) FillOrRefreshTreeOfRecipes();
        }

        private void deleteRecipe_Click(object sender, EventArgs e)
        {
            var dishName = recipesTreeView.SelectedNode.Text;

            var dishID = new DishRepository(_connectionString).GetAll().First(x => x.DishName == dishName).DishID;

            var dialogResult = MessageBox.Show($"Вы действительно хотите удалить рецепт : {dishName} ?", "Предупреждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                new RecipeRepository(_connectionString).Delete(dishID);
                FillOrRefreshTreeOfRecipes();
            }
        }

        private void recipesTreeView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var node = recipesTreeView.HitTest(e.X, e.Y).Node;

                if (node != null && node.Parent == null)
                {
                    recipesTreeView.SelectedNode = node;
                    foreach (ToolStripItem item in contextMenuStripRecipes.Items)
                    {
                        item.Enabled = true;
                    }
                }
                else
                {
                    foreach (ToolStripItem item in contextMenuStripRecipes.Items)
                    {
                        item.Enabled = item.Text == "Добавить";
                    }
                }

                contextMenuStripRecipes.Show(recipesTreeView, new Point(e.X, e.Y));
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
            var ingredients = new IngredientRepository(_connectionString).GetAll();

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
            ingredient.Units = new UnitRepository(_connectionString).GetAll();

            var dialogResult = new AddOrEditIngredientForm(ingredient, _connectionString).ShowDialog(this);
            if (dialogResult == DialogResult.OK) FillOrRefreshGridOfIngredients();
        }

        private void editIngredient_Click(object sender, EventArgs e)
        {
            var selectedIngredientRow = ingredientsDataGrid.SelectedRows[0];
            var selectedIngredient = ((Ingredient)selectedIngredientRow.DataBoundItem);
            selectedIngredient.Units = new UnitRepository(_connectionString).GetAll();
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
                new IngredientRepository(_connectionString).Delete(selectedIngredient.IngredientID);
                FillOrRefreshGridOfIngredients();
            }
        }


        #endregion

        #region actions on AuxReference page

        private void FillOrRefreshGridOfDishes()
        {
            var dishes = new DishRepository(_connectionString).GetAll();

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
                new DishRepository(_connectionString).Delete(selectedDish.DishID);
                FillOrRefreshGridOfDishes();
            }
        }

        private void FillOrRefreshGridOfUnits()
        {
            var units = new UnitRepository(_connectionString).GetAll();

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
            if (dialogResult == DialogResult.OK) FillOrRefreshGridOfUnits();
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
                new UnitRepository(_connectionString).Delete(selectedUnit.UnitID);
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
                        FillOrRefreshTreeOfRecipes();
                        break;
                    case "auxReferencesTabPane":
                        FillOrRefreshGridOfDishes();
                        FillOrRefreshGridOfUnits();
                        break;
                    case "ordersTabPane":
                        FillOrRefreshGridOfOrders();
                        break;
                }
            }
        }

        #region actions on Orders page

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStripOrders.Show(ordersDataGridView, new Point(e.X, e.Y));
            }
        }

        private void FillOrRefreshGridOfOrders()
        {
            var orders = new OrderRepository(_connectionString).GetAll();

            ordersDataGridView.DataSource = orders;

            ordersDataGridView.Columns[0].HeaderText = "Номер заказа";

            ordersDataGridView.Columns[1].HeaderText = "Дата заказа";
            ordersDataGridView.Columns[1].DefaultCellStyle.Format = "dddd, dd MMMM yyyy HH:mm:ss";

            ordersDataGridView.Columns[2].HeaderText = "Сумма заказа";

            ordersDataGridView.Columns[3].Visible = false;
        }

        private void addOrder_Click(object sender, EventArgs e)
        {
            var order = new Order
            {
                Dishes = new DishRepository(_connectionString).GetAll(),
            };

            new CreateOrderForm(order,_connectionString).ShowDialog(this);
        }

        private void createReport_Click(object sender, EventArgs e)
        {

        }

        private void showDetails_Click(object sender, EventArgs e)
        {

        }

        #endregion


    }
}
