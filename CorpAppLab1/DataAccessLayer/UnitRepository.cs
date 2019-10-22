using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpAppLab1
{
    internal class UnitRepository : IRepository<Unit>
    {
        private string _connectionString;

        public string ConnectionString => _connectionString;

        public UnitRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Create(Unit unit)
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

        public void Delete(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var queryString = $@"BEGIN TRANSACTION;
				DELETE FROM dbo.IngredientsInDishes WHERE IngredientID in 
				(SELECT IngredientID FROM dbo.Ingredients WHERE UnitID = {id})
                DELETE FROM dbo.Ingredients WHERE UnitID = {id};
                DELETE FROM dbo.Units WHERE UnitID = {id};
                COMMIT;";

                var cmd = new SqlCommand(queryString, sqlConnection);

                sqlConnection.Open();

                cmd.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        public List<Unit> GetAll()
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

        public Unit GetById(int id)
        {
            var unit = new Unit();

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(
                    string.Format(@"SELECT 
	                    UnitID,
                        UnitName
                      FROM dbo.Units WHERE UnitID = {0};",id), sqlConnection);

                sqlConnection.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    unit = new Unit
                    {
                        UnitID = int.Parse(reader[0].ToString()),
                        UnitName = reader[1].ToString()
                    };
                }

                sqlConnection.Close();
            }
            return unit;
        }

        public void Update(Unit unit)
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
    }
}
