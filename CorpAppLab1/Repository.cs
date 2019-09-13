using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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
                    recipe.Ingredients.Add(reader[2] + " : " + reader[3]);
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
            }

            return recipesList;
        }
    }
}
