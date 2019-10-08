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
                        ds.DishID,
                        ds.DishName,
                        ings.IngredientName,
                        CONCAT(CAST(ingInD.Quantity as nvarchar(10)), ' ', u.UnitName),
                        ingInD.Quantity * ings.UnitPrice
                      FROM dbo.IngredientsInDishes[ingInD]

                        inner join dbo.Dishes[ds] on ingInD.DishID = ds.DishID

                        inner join dbo.Ingredients[ings] on ings.IngredientID = ingInD.IngredientID

                        inner join dbo.Units[u] on u.UnitID = ings.UnitID; ", sqlConnection);

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

                    recipe.DishID = int.Parse(reader[0].ToString());
                    recipe.DishName = reader[1].ToString();
                    recipe.IngredientsAsString.Add(reader[2] + " : " + reader[3]);
                    recipe.DishPrice = int.Parse(reader[4].ToString());

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

        public Recipe GetRecipeByDishName(string recipeDishName)
        {
            return GetAllRecipes().FirstOrDefault(x => x.DishName == recipeDishName);
        }

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

        #region actions with dishes

        public List<Dish> GetAllDishes()
        {
            var dishesList = new List<Dish>();

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
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

        public int GetDishIDbyName(string dishName)
        {
            var dish = GetAllDishes().FirstOrDefault(x => x.DishName == dishName);
            return dish == null ? -1 : dish.DishID;
        }

        public void AddDish(Dish dish)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(
                    $"insert into dbo.Dishes (DishName) Values(N'{dish.DishName}');", sqlConnection);

                sqlConnection.Open();

                cmd.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        public void UpdateDish(Dish dish)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(
                    $"UPDATE dbo.Dishes SET DishName = N'{dish.DishName}' WHERE DishID  = {dish.DishID};", sqlConnection);

                sqlConnection.Open();

                cmd.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        public void DeleteDish(int DishId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var queryString = $@"BEGIN TRANSACTION;
                DELETE FROM dbo.IngredientsInDishes WHERE DishID = {DishId};
                DELETE FROM dbo.Dishes WHERE DishID = {DishId};
                COMMIT; ";

                var cmd = new SqlCommand(queryString, sqlConnection);

                sqlConnection.Open();

                cmd.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }
        #endregion

        #region actions with units
        public List<Unit> GetAllUnits()
        {
            var unitsList = new List<Unit>();

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(
                    @"SELECT 
	                    UnitID,
                        UnitName
                      FROM dbo.Units;", sqlConnection);

                sqlConnection.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    unitsList.Add(new Unit
                    {
                        UnitID = int.Parse(reader[0].ToString()),
                        UnitName = reader[1].ToString()
                    });
                }

                sqlConnection.Close();
            }
            return unitsList;
        }

        public void AddUnit(Unit unit)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(
                    $"insert into dbo.Units (UnitName) Values(N'{unit.UnitName}');", sqlConnection);

                sqlConnection.Open();

                cmd.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        public void UpdateUnit(Unit unit)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(
                    $"UPDATE dbo.Units SET UnitName = N'{unit.UnitName}' WHERE UnitID  = {unit.UnitID};", sqlConnection);

                sqlConnection.Open();

                cmd.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        public void DeleteUnit(int UnitId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var queryString = $@"BEGIN TRANSACTION;
				DELETE FROM dbo.IngredientsInDishes WHERE IngredientID in 
				(SELECT IngredientID FROM dbo.Ingredients WHERE UnitID = {UnitId})
                DELETE FROM dbo.Ingredients WHERE UnitID = {UnitId};
                DELETE FROM dbo.Units WHERE UnitID = {UnitId};
                COMMIT;";

                var cmd = new SqlCommand(queryString, sqlConnection);

                sqlConnection.Open();

                cmd.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }
        #endregion
    }
}
