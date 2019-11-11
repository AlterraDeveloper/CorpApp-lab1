using System;
using CorpAppLab1.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CorpAppLab1.DataAccessLayer
{
    internal class OrderRepository : IRepository<Order>
    {
        public OrderRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; }

        public List<Order> GetAll()
        {
            var orders = new List<Order>();

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand($@"SELECT OrderID,OrderDate,Total FROM Orders;",sqlConnection);

                sqlConnection.Open();

                var orderReader = cmd.ExecuteReader();

                while (orderReader.Read())
                {
                    var order = new Order
                    {
                        OrderID = orderReader.GetInt32(0),
                        OrderDate = orderReader.GetDateTime(1),
                        Total = orderReader.GetInt32(2)
                    };

                    cmd = new SqlCommand($@"select DishID,DishCount from OrdersDetails where OrderID = {order.OrderID}",sqlConnection);

                    var orderDetailsReader = cmd.ExecuteReader();

                    while (orderDetailsReader.Read())
                    {
                        order.DishesAndCounts.Add(orderDetailsReader.GetInt32(0),orderDetailsReader.GetInt32(1));
                    }

                    orders.Add(order);
                }

                sqlConnection.Close();
            }

            return orders;
        }

        public Order GetById(int orderId)
        {
            var order = new Order();

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand($@"SELECT OrderID,OrderDate,Total FROM Orders where OrderID = {orderId};", sqlConnection);

                sqlConnection.Open();

                var orderReader = cmd.ExecuteReader();

                while (orderReader.Read())
                {
                    order = new Order
                    {
                        OrderID = orderReader.GetInt32(0),
                        OrderDate = orderReader.GetDateTime(1),
                        Total = orderReader.GetInt32(2)
                    };

                    cmd = new SqlCommand($@"select DishID,DishCount from OrdersDetails where OrderID = {order.OrderID}",sqlConnection);

                    var orderDetailsReader = cmd.ExecuteReader();

                    while (orderDetailsReader.Read())
                    {
                        order.DishesAndCounts.Add(orderDetailsReader.GetInt32(0), orderDetailsReader.GetInt32(1));
                    }
                }

                sqlConnection.Close();
            }

            return order;
        }

        public void Create(Order order)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand($@"INSERT INTO dbo.Orders (OrderDate,Total) VALUES('{order.OrderDate:MM/dd/yyyy}',{order.Total});
                                            select SCOPE_IDENTITY();", sqlConnection);

                sqlConnection.Open();

                var orderID = Convert.ToInt32(cmd.ExecuteScalar());
                
                foreach (var pair in order.DishesAndCounts)
                {
                    cmd = new SqlCommand($@"INSERT INTO OrdersDetails (OrderID,DishID,DishCount)VALUES({orderID},{pair.Key},{pair.Value});",sqlConnection);
                    cmd.ExecuteNonQuery();
                }

                sqlConnection.Close();
            }
        }

        public void Update(Order entity)
        {
        }

        public void Delete(int id)
        {
        }

        public List<Order> GetReport(DateTime from, DateTime to)
        {
            var orders = new List<Order>();

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand($"EXEC GetOrdersReport @dateFrom = '{@from.Date:MM/dd/yyyy}' , @dateTo = '{to.Date:MM/dd/yyyy}'", sqlConnection);

                sqlConnection.Open();

                var orderReader = cmd.ExecuteReader();

                while (orderReader.Read())
                {
                    var order = new Order
                    {
                        OrderID = orderReader.GetInt32(0),
                        OrderDate = orderReader.GetDateTime(1),
                        Total = orderReader.GetInt32(2)
                    };

                    cmd = new SqlCommand($@"select DishID,DishCount from OrdersDetails where OrderID = {order.OrderID}", sqlConnection);

                    var orderDetailsReader = cmd.ExecuteReader();

                    while (orderDetailsReader.Read())
                    {
                        order.DishesAndCounts.Add(orderDetailsReader.GetInt32(0), orderDetailsReader.GetInt32(1));
                    }

                    orders.Add(order);
                }

                sqlConnection.Close();
            }

            return orders;
        }
    }
}
