using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace CorpAppLab1
{
    public partial class AddIngredientToRecipeForm : Form
    {
        private Recipe _recipe;
        private List<Ingredient> _ingredients;
        private string _connectionString;

        public AddIngredientToRecipeForm(ref Recipe recipe,string connectionString)
        {
            InitializeComponent();

            inputQuantity.Maximum = Decimal.MaxValue;
            _recipe = recipe;
            _ingredients = _recipe.Ingredients;
            _connectionString = connectionString;

            comboBoxIngredients.DataSource = _ingredients.Select(x => x.IngredientName).OrderBy(x => x).ToList();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var repo = new Repository(_connectionString);
            try
            {
                var ingredientId = repo.GetIngredientIDByName(comboBoxIngredients.Text);
                if (ingredientId > 0)
                {
                    repo.UpdateRecipe(_recipe.DishID,ingredientId,(int) inputQuantity.Value);
                    _recipe.IngredientsAsString.Add(comboBoxIngredients.Text + " " +  inputQuantity.Value + " " + labelUnitName.Text);
                    Close();
                }
                else
                {
                    MessageBox.Show($"Ингредиента {comboBoxIngredients.Text} нет в справочнике", "Предупреждение", MessageBoxButtons.OK);
                }
            }
            catch (SqlException sqlException)
            {
                if (sqlException.Number == 2627)
                {
                    MessageBox.Show("Такой ингредиент уже присутствует в рецепте", "Предупреждение", MessageBoxButtons.OK);
                }
            }
        }

        private void comboBoxIngredients_SelectedValueChanged(object sender, EventArgs e)
        {
            labelUnitName.Text = _ingredients.FirstOrDefault(x => x.IngredientName == comboBoxIngredients.Text).auxUnitName;
        }
    }
}
