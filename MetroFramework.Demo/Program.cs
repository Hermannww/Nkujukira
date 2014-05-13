using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace MetroFramework.Demo
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                new Login().Show();
                Application.Run();

            }
            catch (SystemException e)
            {
                Debug.WriteLine(e.Message);

            }
            
        }
    }
}
