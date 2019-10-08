using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            
            if (_recipe.DishID == 0)
            {
                Text = "Добавить рецепт";
            }
            else
            {
                Text = "Редактировать рецепт";
                //comboBoxDishes.SelectedItem = _recipe.DishName;
                comboBoxDishes.Enabled = false;
                //listBoxIngredients.DataSource = _recipe.IngredientsAsString;
            }

            var existingRecipes = new Repository(_connectionString).GetAllRecipes().Select(x => x.DishID);
           
            comboBoxDishes.DataSource = _recipe.Dishes.Where(x => !existingRecipes.Contains(x.DishID)).Select(d => d.DishName).OrderBy(x => x).ToList();
        }

        private void btnAddIngredient_Click(object sender, EventArgs e)
        {
            new AddIngredientToRecipeForm(ref _recipe,_connectionString).ShowDialog(this);
            listBoxIngredients.DataSource = null;
            //listBoxIngredients.DataSource = _recipe.IngredientsAsString;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //_recipe.IngredientsAsString = (List<string>)listBoxIngredients.DataSource;

            //if (_recipe.IngredientsAsString != null && _recipe.IngredientsAsString.Count > 0)
            //{
            //    Close();
            //}
            //else
            //{
            //    MessageBox.Show("Добавьте ингредиенты", "Предупреждение", MessageBoxButtons.OK);
            //}
        }

        private void comboBoxDishes_SelectedValueChanged(object sender, EventArgs e)
        {
            var repo = new Repository(_connectionString);
            var dishID = repo.GetDishIDbyName(comboBoxDishes.Text);
            if (dishID > 0)
            {
                _recipe = repo.GetAllRecipes().FirstOrDefault(x => x.DishID == dishID);
                if (_recipe != null)
                {
                    listBoxIngredients.DataSource = null;
                    //listBoxIngredients.DataSource = _recipe.IngredientsAsString;
                }
                else
                {
                    _recipe = new Recipe();
                    _recipe.DishID = dishID;
                    _recipe.Ingredients = repo.GetAllIngredients();
                }
            }
            else
            {
                MessageBox.Show($"Блюда {comboBoxDishes.Text} нет в справочнике", "Предупреждение", MessageBoxButtons.OK);
            }
            
        }
    }
}
