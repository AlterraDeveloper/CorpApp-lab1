using System;
using System.Data.SqlClient;

namespace CorpAppLab1
{
    public class Repository
    {
        private readonly string _connectionString;

        public Repository(string connStr)
        {
            _connectionString = connStr;
        }

        public bool CheckConnection()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
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
    }
}
