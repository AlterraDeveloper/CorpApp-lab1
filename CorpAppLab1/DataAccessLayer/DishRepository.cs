using System.Collections.Generic;
using System.Data.SqlClient;

namespace CorpAppLab1.DataAccessLayer
{
    internal class DishRepository : IRepository<Dish>
    {
        public string ConnectionString { get; }

        public DishRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void Create(Dish dish)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand(
                    $"insert into dbo.Dishes (DishName) Values(N'{dish.DishName}');", sqlConnection);

                sqlConnection.Open();

                cmd.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                var queryString = $@"BEGIN TRANSACTION;
                DELETE FROM dbo.IngredientsInDishes WHERE DishID = {id};
                DELETE FROM dbo.Dishes WHERE DishID = {id};
                COMMIT; ";

                var cmd = new SqlCommand(queryString, sqlConnection);

                sqlConnection.Open();

                cmd.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        public List<Dish> GetAll()
        {
            var dishesList = new List<Dish>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand(
                    @"SELECT 
	                    DishID,
                        DishName
                      FROM dbo.Dishes;", sqlConnection);

                sqlConnection.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dishesList.Add(new Dish
                    {
                        DishID = int.Parse(reader[0].ToString()),
                        DishName = reader[1].ToString()
                    });
                }

                sqlConnection.Close();
            }
            return dishesList;
        }

        public Dish GetById(int id)
        {
            var dish = new Dish();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand(
                    string.Format(@"SELECT 
	                    DishID,
                        DishName
                      FROM dbo.Dishes WHERE DishID = {0};",id), sqlConnection);

                sqlConnection.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dish = new Dish
                    {
                        DishID = int.Parse(reader[0].ToString()),
                        DishName = reader[1].ToString()
                    };
                }

                sqlConnection.Close();
            }
            return dish;
        }

        public void Update(Dish dish)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand(
                    $"UPDATE dbo.Dishes SET DishName = N'{dish.DishName}' WHERE DishID  = {dish.DishID};", sqlConnection);

                sqlConnection.Open();

                cmd.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        public Dish GetByName(string name)
        {
            var dish = new Dish();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand(
                    string.Format(@"SELECT 
	                    DishID,
                        DishName
                      FROM dbo.Dishes WHERE DishName = N'{0}';", name), sqlConnection);

                sqlConnection.Open();

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dish = new Dish
                        {
                            DishID = int.Parse(reader[0].ToString()),
                            DishName = reader[1].ToString()
                        };
                    }
                }
                else
                {
                    dish = null;
                }
                

                sqlConnection.Close();
            }
            return dish;
        }
    }
}
