using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace CorpAppLab1.Forms
{
    public partial class AddIngredientToRecipeForm : Form
    {
        private Recipe _recipe;
        private List<Ingredient> _ingredients;

        public AddIngredientToRecipeForm(ref Recipe recipe,string connectionString)
        {
            InitializeComponent();

            inputQuantity.Maximum = Decimal.MaxValue;
            _recipe = recipe;
            _ingredients = _recipe.Ingredients;

            comboBoxIngredients.DisplayMember = "IngredientName";
            comboBoxIngredients.ValueMember = "IngredientID";
            comboBoxIngredients.DataSource = _ingredients.OrderBy(x => x.IngredientName).ToList();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            try
            {
                var ingredientId = ((Ingredient) comboBoxIngredients.SelectedItem)?.IngredientID;
                if (ingredientId != null)
                {
                    if (_recipe.IngredientIdsAndQuantities.ContainsKey((int) ingredientId))
                    {
                        _recipe.IngredientIdsAndQuantities[(int) ingredientId] = (int) inputQuantity.Value;
                    }
                    else
                    {
                        _recipe.IngredientIdsAndQuantities.Add((int)ingredientId,(int)inputQuantity.Value);
                    }
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

        private void comboBoxIngredients_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIngredient = (Ingredient)comboBoxIngredients.SelectedItem;
            labelUnitName.Text = _ingredients.FirstOrDefault(x => x.IngredientName == selectedIngredient.IngredientName).auxUnitName;
        }
    }
}
