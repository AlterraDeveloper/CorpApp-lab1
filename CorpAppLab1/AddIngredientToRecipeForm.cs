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
    public partial class AddIngredientToRecipeForm : Form
    {
        private Recipe _recipe;
        private List<Ingredient> _ingredients;

        public AddIngredientToRecipeForm(ref Recipe recipe)
        {
            InitializeComponent();

            inputQuantity.Maximum = Decimal.MaxValue;
            _recipe = recipe;
            _ingredients = _recipe.Ingredients;

            comboBoxIngredients.DataSource = _ingredients.Select(x => x.IngredientName).ToList();
            
        }

        private void comboBoxIngredients_TextChanged(object sender, EventArgs e)
        {
            labelUnitName.Text = _ingredients.FirstOrDefault(x => x.IngredientName == comboBoxIngredients.Text).auxUnitName;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var ingredientString = comboBoxIngredients.Text + " : " + inputQuantity.Text + " " + labelUnitName.Text;
            _recipe.IngredientsAsString.Add(ingredientString);
            Close();
        }
    }
}
