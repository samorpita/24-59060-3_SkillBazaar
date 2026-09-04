using System.Data.SqlClient;

namespace SkillBazaar.SuperAdminModule
{
    /// <summary>
    /// Lightweight placeholder for Samorpita's shared "Database Connection class"
    /// from Core/Shared — now targeting Microsoft SQL Server (managed via SSMS)
    /// instead of MySQL. Included here only so the Super Admin forms compile and
    /// run on their own branch.
    ///
    /// When merging with main: delete this file and point the "using
    /// SkillBazaar.SuperAdminModule;" lines in the Forms/ files to the team's
    /// real DatabaseConnection class instead — keep the same GetConnection()
    /// method name/signature so nothing else needs to change.
    /// </summary>
    public static class DatabaseConnection
    {
        // Confirmed from SSMS on Sadia's laptop — LocalDB instance that ships
        // with Visual Studio.
        private const string ConnectionString =
            "Server=(localdb)\\MSSQLLocalDB;Database=SkillBazaar;Trusted_Connection=True;";

        // Option A (fallback): a full local SQL Server / SQL Server Express
        // instance managed through SSMS.
        // private const string ConnectionString =
        //     "Server=localhost;Database=SkillBazaar;Trusted_Connection=True;TrustServerCertificate=True;";

        // Option B: SQL Server Authentication — use this instead if your SSMS
        // login is a SQL login (sa / a custom user) rather than Windows Auth.
        // private const string ConnectionString =
        //     "Server=localhost;Database=SkillBazaar;User Id=sa;Password=YourPassword;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
