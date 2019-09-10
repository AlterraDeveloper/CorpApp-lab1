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

            var connectionString = GetConnectionString(string.Empty);

            using(SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("select * from dbo.Dishes;", sqlConnection);

                sqlConnection.Open();

                var reader = cmd.ExecuteReader();

                var dict = new Dictionary<string, string>();

                while (reader.Read())
                {
                    dict[reader[0].ToString()] = reader[1].ToString();
                }

                dataGridForDishes.DataSource = (from row in dict select new { ID = row.Key, DishName = row.Value }).ToList();
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
