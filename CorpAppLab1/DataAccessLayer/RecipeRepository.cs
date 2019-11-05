using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CorpAppLab1.DataAccessLayer
{
    class RecipeRepository : IRepository<Recipe>
    {
        public string ConnectionString { get; }

        public RecipeRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public List<Recipe> GetAll()
        {
            var recipesList = new List<Recipe>();

            using (var sqlConnection = new SqlConnection(ConnectionString))
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
                    Recipe recipe;

                    if (recipesList.Count == 0)
                    {
                        recipe = new Recipe();
                    }
                    else
                    {
                        recipe = recipesList.FirstOrDefault(r => r.DishID == reader.GetInt32(0));

                        recipe = recipe ?? new Recipe();
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

        public Recipe GetById(int dishId)
        {
            Recipe recipe = null;

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand(
                    $@"SELECT 
                        DishID,
						IngredientID,
						Quantity
                        FROM dbo.IngredientsInDishes WHERE DishID = {dishId}; ", sqlConnection);

                sqlConnection.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    recipe = new Recipe();

                    while (reader.Read())
                    {
                        recipe.DishID = reader.GetInt32(0);
                        recipe.IngredientIdsAndQuantities.Add(reader.GetInt32(1), reader.GetInt32(2));
                    }
                }
                sqlConnection.Close();
            }
            return recipe;
        }

        public void Create(Recipe recipe)
        {
            Update(recipe);
        }

        public void Update(Recipe recipe)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                foreach (var ingredientId in recipe.IngredientIdsAndQuantities.Keys)
                {
                    var cmd = new SqlCommand($@"select * from dbo.IngredientsInDishes where DishID = {recipe.DishID} and IngredientID = {ingredientId}; ", sqlConnection);

                    sqlConnection.Open();

                    var reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        cmd = new SqlCommand($@"update dbo.IngredientsInDishes set Quantity = {recipe.IngredientIdsAndQuantities[ingredientId]} where DishID = {recipe.DishID} and IngredientID = {ingredientId};", sqlConnection);
                    }
                    else
                    {
                        cmd = new SqlCommand($@"insert into dbo.IngredientsInDishes(DishID,IngredientID,Quantity) VALUES({recipe.DishID},{ingredientId},{recipe.IngredientIdsAndQuantities[ingredientId]});", sqlConnection);
                    }

                    cmd.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
        }

        public void Delete(int dishId)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand($@"delete from dbo.IngredientsInDishes where DishID = {dishId};",sqlConnection);

                sqlConnection.Open();

                cmd.ExecuteNonQuery();

                sqlConnection.Close();

            }
        }

        public void Delete(int dishId,int ingredientID)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand($@"delete from dbo.IngredientsInDishes where DishID = {dishId} AND IngredientID = {ingredientID};", sqlConnection);

                sqlConnection.Open();

                cmd.ExecuteNonQuery();

                sqlConnection.Close();

            }
        }
    }
}
