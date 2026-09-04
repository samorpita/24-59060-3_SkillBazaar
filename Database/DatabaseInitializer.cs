using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

namespace SkillBazaar.Database
{
    public static class DatabaseInitializer
    {
        public static void EnsureCreated()
        {
            string configured = ConfigurationManager.ConnectionStrings["SkillBazaarDB"].ConnectionString;
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(configured);
            builder.InitialCatalog = "master";

            string scriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database", "schema_sqlserver.sql");
            if (!File.Exists(scriptPath))
                scriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "schema_sqlserver.sql");
            if (!File.Exists(scriptPath))
                throw new FileNotFoundException("Database setup file was not found.", scriptPath);

            string script = File.ReadAllText(scriptPath);
            string[] batches = Regex.Split(script, @"^\s*GO\s*(?:--.*)?$", RegexOptions.Multiline | RegexOptions.IgnoreCase);

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                foreach (string batch in batches)
                {
                    if (string.IsNullOrWhiteSpace(batch)) continue;
                    using (SqlCommand command = new SqlCommand(batch, connection))
                    {
                        command.CommandTimeout = 120;
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
