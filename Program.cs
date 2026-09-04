using System;
using System.Windows.Forms;
using SkillBazaar.SuperAdminModule.Forms;

namespace SkillBazaar.SuperAdminModule
{
    /// <summary>
    /// Standalone launcher so this module can be run/tested on its own branch
    /// before it's merged with Samorpita's Login form and role-routing logic.
    /// Once merged, delete this and let the real Login form call
    /// new SuperAdmin(...).OpenDashboard() instead (see Models/SuperAdmin.cs).
    /// </summary>
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SuperAdminDashboardForm());
        }
    }
}
