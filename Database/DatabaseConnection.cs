using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SkillBazaar.Database
{
    // Handles all SQL Server connectivity for the whole application.
    // Every form (Login, Instructor Dashboard, Customer Catalog, etc.)
    // should use this class instead of creating its own connection.
    public class DatabaseConnection
    {
        private readonly string connectionString;

        public DatabaseConnection()
        {
            // Reads the connection string from App.config
            connectionString = ConfigurationManager
                .ConnectionStrings["SkillBazaarDB"].ConnectionString;
        }

        // Returns a new, unopened connection. Caller is responsible for closing/disposing it
        // (use a "using" block).
        public SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }

        // For SELECT queries. Pass parameters to avoid SQL injection.
        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable table = new DataTable();

            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }
                }
            }
            return table;
        }

        // For INSERT / UPDATE / DELETE. Returns number of rows affected.
        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        // For queries that return a single value, e.g. COUNT(*), or the new IDENTITY id.
        public object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}
