using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CorpAppLab1
{
    public class Repository
    {
        private string _connectionString;

        public Repository(string connStr)
        {
            _connectionString = connStr;
        }

        public bool CheckConnection()
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                try
                {
                    sqlConnection.Open();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        public List<Recipe> GetAllRecipes()
        {
            var recipesList = new List<Recipe>();
            Recipe recipe;

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(
                    @"SELECT 
                        DishID,
						IngredientID,
						Quantity
                        FROM dbo.IngredientsInDishes[ingInD]; ", sqlConnection);

                sqlConnection.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (recipesList.Count == 0)
                    {
                        recipe = new Recipe();
                    }
                    else
                    {
                        recipe = recipesList.FirstOrDefault(r => r.DishID == reader.GetInt32(0));

                        recipe = recipe == null ? new Recipe() : recipe;
                    }

                    recipe.DishID = reader.GetInt32(0);
                    recipe.IngredientIdsAndQuantities.Add(reader.GetInt32(1), reader.GetInt32(2));

                    if (recipesList.Contains(recipe))
                    {
                        recipesList[recipesList.IndexOf(recipe)] = recipe;
                    }
                    else
                    {
                        recipesList.Add(recipe);
                    }
                }
                sqlConnection.Close();
            }
            return recipesList;
        }

        //public Recipe GetRecipeByDishName(string recipeDishName)
        //{
        //    return GetAllRecipes().FirstOrDefault(x => x.DishName == recipeDishName);
        //}

        public void UpdateRecipe(int dishID, int ingredientID,int quantitity)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(
                $"insert dbo.IngredientsInDishes(DishID, IngredientID, Quantity)values({dishID}, {ingredientID}, {quantitity}); ", sqlConnection);

                sqlConnection.Open();

                cmd.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        #region actions with ingredients

        public List<Ingredient> GetAllIngredients()
        {
            var ingredientsList = new List<Ingredient>();

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
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

        public int GetIngredientIDByName(string ingredientName)
        {
            var ingredient = GetAllIngredients().FirstOrDefault(x => x.IngredientName == ingredientName);
            return ingredient == null ? -1 : ingredient.IngredientID;
        }

        public void AddIngredient(Ingredient ingredient)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(
                    $"insert into dbo.Ingredients (IngredientName,UnitID,UnitPrice) Values(N'{ingredient.IngredientName}',{ingredient.UnitID},{ingredient.UnitPrice});", sqlConnection);

                sqlConnection.Open();

                cmd.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        public void UpdateIngredient(Ingredient ingredient)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(
                    $"UPDATE dbo.Ingredients SET IngredientName = N'{ingredient.IngredientName}',UnitID = {ingredient.UnitID},UnitPrice = {ingredient.UnitPrice} WHERE IngredientID  = {ingredient.IngredientID};", sqlConnection);

                sqlConnection.Open();

                cmd.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        public void DeleteIngredient(int IngredientId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
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

        #endregion

    }
}
