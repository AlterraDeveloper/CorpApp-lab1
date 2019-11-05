using CorpAppLab1.DataAccessLayer;
using CorpAppLab1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace CorpAppLab1.Forms
{
    public partial class CreateOrderForm : Form
    {
        private Order _order;
        private readonly string _connectionString;

        public CreateOrderForm(Order order,string connectionString)
        {
            InitializeComponent();

            _order = order;
            _connectionString = connectionString;

            orderDateTimePicker.Value = order.OrderDate;
            txtBoxOrderTotal.Text = order.Total.ToString();


            if (dishesListBox != null)
                dishesListBox.DataSource =
                    _order.DishesAndCounts.Select(x => _order.Dishes.Find(d => d.DishID == x.Key).DishName + " " + x.Value.ToString()).ToList();

            //dishesGrid.Columns[0].HeaderText = "Блюдо";
            //dishesGrid.Columns[1].HeaderText = "Кол-во порций";
        }

        private void btnAddDish_Click(object sender, EventArgs e)
        {
            if (new AddDishToOrderForm(ref _order,_connectionString).ShowDialog() == DialogResult.OK)
            {
                txtBoxOrderTotal.Text = _order.Total.ToString();
                dishesListBox.DataSource =
                    _order.DishesAndCounts.Select(x => _order.Dishes.Find(d => d.DishID == x.Key).DishName + " " + x.Value.ToString()).ToList();
            }
        }

        private void CreateOrderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            new OrderRepository(_connectionString).Create(_order);
        }
    }
}
