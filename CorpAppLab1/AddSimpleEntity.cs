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
    public partial class AddSimpleEntity : Form
    {
        private object _entity;
        private string _connectionString;

        public AddSimpleEntity(object entity, string connString)
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
            var repo = new Repository(_connectionString);

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

            Close();
        }
    }
}
