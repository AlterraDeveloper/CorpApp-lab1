using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CorpAppLab1
{
    public partial class AddOrEditRecipeForm : Form
    {
        private string _connectionString;
        private Recipe _recipe;

        public AddOrEditRecipeForm(Recipe recipe, string connString)
        {
            InitializeComponent();

            _connectionString = connString;
            _recipe = recipe;

            comboBoxDishes.DataSource = _recipe.Dishes.Select(d => d.DishName).ToList();

            if (_recipe.DishID == 0)
            {
                Text = "Добавить рецепт";
            }
            else
            {
                Text = "Редактировать рецепт";
                comboBoxDishes.SelectedItem = _recipe.DishName;
                comboBoxDishes.Enabled = false;
                listBoxIngredients.DataSource = _recipe.IngredientsAsString;
            }
        }

        private void btnAddIngredient_Click(object sender, EventArgs e)
        {
            new AddIngredientToRecipeForm(ref _recipe).ShowDialog(this);
            listBoxIngredients.DataSource = null;
            listBoxIngredients.DataSource = _recipe.IngredientsAsString;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _recipe.IngredientsAsString = (List<string>)listBoxIngredients.DataSource;
            new Repository(_connectionString).UpdateRecipe(_recipe);
            Close();

        }
    }
}
