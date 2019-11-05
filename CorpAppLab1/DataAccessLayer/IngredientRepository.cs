using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpAppLab1.DataAccessLayer
{
    class IngredientRepository : IRepository<Ingredient>
    {
        public string ConnectionString { get; }

        public IngredientRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public List<Ingredient> GetAll()
        {
            var ingredientsList = new List<Ingredient>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand(
                    @"select 
	                    i.IngredientID,
	                    i.IngredientName,
                        i.UnitID,
	                    u.UnitName,
	                    i.UnitPrice
                      from dbo.Ingredients[i]
                      inner join dbo.Units[u] on u.UnitID = i.UnitID;", sqlConnection);

                sqlConnection.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var ingredient = new Ingredient
                    {
                        IngredientID = int.Parse(reader[0].ToString()),
                        IngredientName = reader[1].ToString(),
                        UnitID = int.Parse(reader[2].ToString()),
                        auxUnitName = reader[3].ToString(),
                        UnitPrice = int.Parse(reader[4].ToString())
                    };

                    ingredientsList.Add(ingredient);
                }

                sqlConnection.Close();
            }
            return ingredientsList;
        }

        public Ingredient GetById(int id)
        {
            Ingredient ingredient = new Ingredient();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand(
                    $@"select 
	                    i.IngredientID,
	                    i.IngredientName,
                        i.UnitID,
	                    u.UnitName,
	                    i.UnitPrice
                      from dbo.Ingredients[i]
                      inner join dbo.Units[u] on u.UnitID = i.UnitID WHERE i.IngredientID = {id};", sqlConnection);

                sqlConnection.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    ingredient = new Ingredient
                    {
                        IngredientID = int.Parse(reader[0].ToString()),
                        IngredientName = reader[1].ToString(),
                        UnitID = int.Parse(reader[2].ToString()),
                        auxUnitName = reader[3].ToString(),
                        UnitPrice = int.Parse(reader[4].ToString())
                    };
                }
                else
                {
                    ingredient = null;
                }

                sqlConnection.Close();
            }
            return ingredient;
        }

        public void Create(Ingredient ingredient)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand(
                    $"insert into dbo.Ingredients (IngredientName,UnitID,UnitPrice) Values(N'{ingredient.IngredientName}',{ingredient.UnitID},{ingredient.UnitPrice});", sqlConnection);

                sqlConnection.Open();

                cmd.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        public void Update(Ingredient ingredient)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand(
                    $"UPDATE dbo.Ingredients SET IngredientName = N'{ingredient.IngredientName}',UnitID = {ingredient.UnitID},UnitPrice = {ingredient.UnitPrice} WHERE IngredientID  = {ingredient.IngredientID};", sqlConnection);

                sqlConnection.Open();

                cmd.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        public void Delete(int IngredientId)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                var queryString = $@"BEGIN TRANSACTION;
                DELETE FROM dbo.IngredientsInDishes WHERE IngredientID = {IngredientId};
                DELETE FROM dbo.Ingredients WHERE IngredientID = {IngredientId};
                COMMIT; ";

                var cmd = new SqlCommand(queryString, sqlConnection);

                sqlConnection.Open();

                cmd.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }
    }
}
