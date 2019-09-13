using Microsoft.Data.ConnectionUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project;

namespace CorpAppLab1
{
    public partial class Form1 : Form
    {
        private string _connectionString;

        public Form1()
        {
            InitializeComponent();

            

           
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

        private void txtBoxConnectionString_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.Text))
            {
                btnSaveConnectionStringToFile.Enabled = true;
                _connectionString = CaesarEncoder.Encrypt(txtBoxConnectionString.Text,true);
            }
        }

        private void btnGenerateConnectionString_Click(object sender, EventArgs e)
        {
            var connectionString = GetConnectionString(string.Empty);
            if (connectionString != null)
            {
                txtBoxConnectionString.Text = CaesarEncoder.Encrypt(connectionString);
            }
            
        }

        private void btnLoadSettingsFromFile_Click(object sender, EventArgs e)
        {
            var explorer = new OpenFileDialog();

            if (explorer.ShowDialog() == DialogResult.OK)
            {
                var textFromFile = File.ReadAllText(explorer.FileName);

                txtBoxConnectionString.Text = textFromFile;

                _connectionString = CaesarEncoder.Encrypt(textFromFile,true);
            }

        }

        private void btnSaveConnectionStringToFile_Click(object sender, EventArgs e)
        {
            var explorer = new OpenFileDialog();

            if (explorer.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(explorer.FileName,txtBoxConnectionString.Text);

                MessageBox.Show($"Файл с настройками {explorer.FileName} успешно сохранен","Успешно", MessageBoxButtons.OK);
            }

        }

        private void btnShowRecipes_Click(object sender, EventArgs e)
        {
            var recipes = new Repository(_connectionString).GetAllRecipes();
            foreach (var recipe in recipes)
            {
                TreeNode dishNode = new TreeNode();

                if (recipesTreeView.Nodes.ContainsKey(recipe.DishID.ToString()))
                {
                    dishNode = recipesTreeView.Nodes.Find(recipe.DishID.ToString(), false).First();
                }
                else
                {
                    dishNode = recipesTreeView.Nodes.Add(recipe.DishID.ToString(), recipe.DishName);
                }

                foreach (var ingredient in recipe.Ingredients)
                {
                    dishNode.Nodes.Add(ingredient);
                }
                
            }
            
        }
    }
}
