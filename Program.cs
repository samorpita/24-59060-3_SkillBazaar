using System;
using System.Windows.Forms;
using SkillBazaar.Forms;
using SkillBazaar.Database;

namespace SkillBazaar
{
    /// <summary>SkillBazaar application entry point and first run database setup.</summary>
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                DatabaseInitializer.EnsureCreated();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "SkillBazaar could not prepare its LocalDB database automatically.\n\n" +
                    "Make sure the Visual Studio .NET desktop development workload and SQL Server Express LocalDB are installed. " +
                    "You can also execute Database\\schema_sqlserver.sql manually in SSMS.\n\nDetails: " + ex.Message,
                    "Database Setup Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Application.Run(new LoginForm());
        }
    }
}
