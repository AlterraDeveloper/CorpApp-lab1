using CorpAppLab1.Models;
using System.Windows.Forms;
using CorpAppLab1.DataAccessLayer;

namespace CorpAppLab1.Forms
{
    public partial class AddDishToOrderForm : Form
    {
        private readonly Order _order;
        private readonly string _connectionString;

        public AddDishToOrderForm(ref Order order,string connectionString)
        {
            InitializeComponent();

            _order = order;
            _connectionString = connectionString;

            cmbBoxDishes.DataSource = _order.Dishes;
            cmbBoxDishes.ValueMember = "DishID";
            cmbBoxDishes.DisplayMember = "DishName";

            numInputPortion.Minimum = 1;
        }

        private void btnAddDish_Click(object sender, System.EventArgs e)
        {
            var dishId = _order.Dishes.Find(x => x.DishName == cmbBoxDishes.Text).DishID;

            var recipe = new RecipeRepository(_connectionString).GetById(dishId);

            if (recipe != null)
            {
                _order.DishesAndCounts.Add(dishId, (int)numInputPortion.Value);

                var ingrRep = new IngredientRepository(_connectionString);

                foreach (var ingrId in recipe.IngredientIdsAndQuantities.Keys)
                {

                    _order.Total += recipe.IngredientIdsAndQuantities[ingrId] * ingrRep.GetById(ingrId).UnitPrice * (int)numInputPortion.Value;
                }
            }
            else
            {
                MessageBox.Show("Добавьте рецепт для этого блюда");
            }
            

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
