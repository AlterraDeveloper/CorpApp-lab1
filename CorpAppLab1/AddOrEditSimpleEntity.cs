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

namespace CorpAppLab1
{
    public partial class AddOrEditSimpleEntity : Form
    {
        private object _entity;
        private string _connectionString;

        public AddOrEditSimpleEntity(object entity, string connString)
        {
            InitializeComponent();

            _entity = entity;
            _connectionString = connString;

            if (_entity is Dish)
            {
                txtBoxName.Text = ((Dish) _entity).DishName;
            }
            if (_entity is Unit)
            {
                txtBoxName.Text = ((Unit)_entity).UnitName;
            }
        }

        private void btnSaveEntity_Click(object sender, EventArgs e)
        {
            if (txtBoxName.Text.Length == 0)
            {
                txtBoxName.Focus();
                return;
            }

            var repo = new Repository(_connectionString);

            try
            {
                if (_entity != null && _entity.GetType() == typeof(Dish))
                {
                    var dish = _entity as Dish;
                    dish.DishName = txtBoxName.Text;

                    if (dish.DishID == 0)
                    {
                        repo.AddDish(dish);
                    }
                    else
                    {
                        repo.UpdateDish(dish);
                    }
                }
            }
            catch (SqlException sqlException)
            {
                if (sqlException.Number == 2627)
                {
                    MessageBox.Show("Наименование блюда должно быть уникальным", "Предупреждение", MessageBoxButtons.OK);
                }
            }

            try
            {
                if (_entity != null && _entity.GetType() == typeof(Unit))
                {
                    var unit = _entity as Unit;
                    unit.UnitName = txtBoxName.Text;

                    if (unit.UnitID == 0)
                    {
                        repo.AddUnit(unit);
                    }
                    else
                    {
                        repo.UpdateUnit(unit);
                    }
                }
            }
            catch (SqlException sqlException)
            {

                if (sqlException.Number == 2627)
                {
                    MessageBox.Show("Наименование единицы измерения должно быть уникальным", "Предупреждение", MessageBoxButtons.OK);
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
