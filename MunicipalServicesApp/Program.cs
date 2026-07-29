using System;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    /// <summary>
    /// Application entry point for the Municipal Services Application.
    /// Part 1 of the AAPD7112 PoE - only the "Report Issues" feature is enabled.
    /// </summary>
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.MainMenuForm());
        }
    }
}
