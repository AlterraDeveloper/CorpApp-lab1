using Microsoft.Data.ConnectionUI;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //var connectionString = GetConnectionString(string.Empty);

            using (SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-KBE43N8\SQLEXPRESS;Initial Catalog=Task1Cookbook_Kiselev;User ID=sa;Password=2411;MultipleActiveResultSets=True"))
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
                    TreeNode dishNode = new TreeNode();

                    if (recipesTreeView.Nodes.ContainsKey(reader[0].ToString()))
                    {
                        dishNode = recipesTreeView.Nodes.Find(reader[0].ToString(), false).First();
                    }
                    else
                    {
                        dishNode = recipesTreeView.Nodes.Add(reader[0].ToString(), reader[1].ToString());
                    }
                    
                    dishNode.Nodes.Add(reader[2] + " : " + reader[3]);
                }
            }
        }

        private string GetConnectionString(string supposedValue)
        {
            DataConnectionDialog connectionDialog =
               new DataConnectionDialog { TopMost = true };
            connectionDialog.DataSources.Add(DataSource.SqlDataSource);
            connectionDialog.SelectedDataSource = DataSource.SqlDataSource;
            connectionDialog.SelectedDataProvider = DataProvider.SqlDataProvider;

            SqlConnectionStringBuilder connectionBuilder =
               new SqlConnectionStringBuilder(supposedValue ?? string.Empty)
               { MultipleActiveResultSets = true };

            connectionDialog.ConnectionString = connectionBuilder.ToString();

            if (DataConnectionDialog.Show(connectionDialog) != DialogResult.OK)
                return null;

            return connectionDialog.ConnectionString;
        }
    }
}
