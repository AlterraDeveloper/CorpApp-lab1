using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CorpAppLab1.DataAccessLayer;

namespace CorpAppLab1
{
    public partial class AddOrEditIngredientForm : Form
    {
        private string _connectionString;
        private Ingredient _ingredient;

        public AddOrEditIngredientForm(Ingredient ingredient, string connString)
        {
            InitializeComponent();

            _connectionString = connString;

            _ingredient = ingredient;

            cmbBoxUnit.DataSource = _ingredient.Units.Select(u => u.UnitName).OrderBy(u => u).ToList();

            if (_ingredient.IngredientID == 0)
            {
                Text = "Добавить ингредиент";
            }
            else
            {
                Text = "Редактировать ингредиент";
                txtBoxIngrName.Text = _ingredient.IngredientName;
                cmbBoxUnit.SelectedItem = _ingredient.Units.First(u => u.UnitID == _ingredient.UnitID).UnitName;
                numInputUnitPrice.Value = _ingredient.UnitPrice;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _ingredient.IngredientName = txtBoxIngrName.Text;
            _ingredient.UnitID = _ingredient.Units.First(u => u.UnitName == cmbBoxUnit.Text).UnitID;
            _ingredient.UnitPrice = (int) numInputUnitPrice.Value;

            try
            {
                if (_ingredient.IngredientID == 0)
                {
                    new IngredientRepository(_connectionString).Create(_ingredient);
                }
                else
                {
                    new IngredientRepository(_connectionString).Update(_ingredient);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (SqlException sqlException)
            {
                if (sqlException.Number == 2627)
                {
                    MessageBox.Show("Наименование ингредиента должно быть уникальным", "Предупреждение", MessageBoxButtons.OK);
                }
            }
        }
    }
}
