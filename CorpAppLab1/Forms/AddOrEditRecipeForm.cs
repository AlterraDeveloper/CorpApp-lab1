using CorpAppLab1.DataAccessLayer;
using CorpAppLab1.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DishRepository = CorpAppLab1.DataAccessLayer.DishRepository;
using RecipeRepository = CorpAppLab1.DataAccessLayer.RecipeRepository;

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

                var existingRecipes = new RecipeRepository(_connectionString).GetAll().Select(x => x.DishID);

                comboBoxDishes.DataSource = _recipe.Dishes.Where(x => !existingRecipes.Contains(x.DishID)).Select(d => d.DishName).OrderBy(x => x).ToList();
            }
            else
            {
                Text = "Редактировать рецепт";
                comboBoxDishes.Enabled = false;
                comboBoxDishes.Text = new DishRepository(_connectionString).GetById(recipe.DishID).DishName;
                FillListBox();
            }
        }

        private void btnAddIngredient_Click(object sender, EventArgs e)
        {
            new AddIngredientToRecipeForm(ref _recipe,_connectionString).ShowDialog(this);
            FillListBox();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (listBoxIngredients.Items.Count > 0)
            {
                new RecipeRepository(_connectionString).Update(_recipe);
                Close();
            }
            else
            {
                MessageBox.Show("Добавьте ингредиенты", "Предупреждение", MessageBoxButtons.OK);
            }
        }

        private void comboBoxDishes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dish = new DishRepository(_connectionString).GetByName(comboBoxDishes.Text);

            if (dish != null)
            {
                _recipe = new RecipeRepository(_connectionString).GetAll().FirstOrDefault(x => x.DishID == dish.DishID);

                if (_recipe != null)
                {
                    FillListBox();
                }
                else
                {
                    _recipe = new Recipe
                    {
                        DishID = dish.DishID,
                        Ingredients = new IngredientRepository(_connectionString).GetAll()
                    };
                }
            }
            else
            {
                MessageBox.Show($"Блюда {comboBoxDishes.Text} нет в справочнике", "Предупреждение", MessageBoxButtons.OK);
            }
        }

        private void FillListBox()
        {
            var listBoxDataSource = new List<string>();

            foreach (var pair in _recipe.IngredientIdsAndQuantities)
            {
                var ingr = _recipe.Ingredients.FirstOrDefault(x => x.IngredientID == pair.Key);
                var unitName = new UnitRepository(_connectionString).GetAll().FirstOrDefault(x => x.UnitID == ingr.UnitID).UnitName;
                listBoxDataSource.Add(ingr.IngredientName + " " + pair.Value + " " + unitName);
            }

            listBoxIngredients.DataSource = listBoxDataSource;
        }

        private void deleteIngredientFromRecipe_Click(object sender, EventArgs e)
        {
            var ingredientRecord = (string)listBoxIngredients.SelectedItem;
            var ingredientName = ingredientRecord.Remove(Regex.Match(ingredientRecord, "\\d").Index).Trim();
            var ingredientId = _recipe.Ingredients.First(x => x.IngredientName == ingredientName).IngredientID;
            new RecipeRepository(_connectionString).Delete(_recipe.DishID,ingredientId);
            _recipe.IngredientIdsAndQuantities.Remove(ingredientId);
            FillListBox();
        }

        private void listBoxIngredients_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                listBoxIngredients.SetSelected(listBoxIngredients.IndexFromPoint(new Point(e.X, e.Y)), true);

                contextMenuStripIngredients.Show(listBoxIngredients,new Point(e.X,e.Y));
            }
        }

        private void listBoxIngredients_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                listBoxIngredients.SetSelected(listBoxIngredients.IndexFromPoint(new Point(e.X, e.Y)), true);

                contextMenuStripIngredients.Show(listBoxIngredients, new Point(e.X, e.Y));
            }
        }
    }
}
