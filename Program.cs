// Program.cs
using System;
using System.Windows.Forms;
using SkillBazaar.Forms;

namespace SkillBazaar
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmInstructorDashboard());
        }
    }
}