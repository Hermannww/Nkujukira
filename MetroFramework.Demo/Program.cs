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
                SplashScreen.ShowSplashScreen();
                Application.DoEvents();
                SplashScreen.SetStatus("Loading Login component");
                System.Threading.Thread.Sleep(500);
                SplashScreen.SetStatus("Loading Face Detection component");
                System.Threading.Thread.Sleep(300);
                SplashScreen.SetStatus("Loading Face Recogintion Component");
                System.Threading.Thread.Sleep(900);
                SplashScreen.SetStatus("Loading All User Information");
                System.Threading.Thread.Sleep(100);
                SplashScreen.SetStatus("Connecting to Student Registration Database");
                System.Threading.Thread.Sleep(400);
                SplashScreen.SetStatus("Loading Student Face Database");
                System.Threading.Thread.Sleep(50);
                SplashScreen.SetStatus("Loading Perpetrator list");
                System.Threading.Thread.Sleep(240);
                SplashScreen.SetStatus("Loading Alert Component");
                System.Threading.Thread.Sleep(900);
                SplashScreen.SetStatus("Loading .");
                System.Threading.Thread.Sleep(240);
                SplashScreen.SetStatus("Loading ..");
                System.Threading.Thread.Sleep(90);
                SplashScreen.SetStatus("Loading ...");
                System.Threading.Thread.Sleep(1000);
                SplashScreen.SetStatus("Loading ....");
                System.Threading.Thread.Sleep(100);
                SplashScreen.SetStatus("Loading .....");
                System.Threading.Thread.Sleep(500);
                SplashScreen.SetStatus("Loading ......", false);
                System.Threading.Thread.Sleep(1000);
                SplashScreen.SetStatus("Loading .......", false);
                System.Threading.Thread.Sleep(1000);
                SplashScreen.SetStatus("Loading ........", false);
                System.Threading.Thread.Sleep(1000);
                SplashScreen.SetStatus("Loading .........", false);
                System.Threading.Thread.Sleep(1000);
                SplashScreen.SetStatus("Loading ..........");
                System.Threading.Thread.Sleep(20);
                SplashScreen.SetStatus("Loading ...........");
                System.Threading.Thread.Sleep(450);
                SplashScreen.SetStatus("Loading ............");
                System.Threading.Thread.Sleep(240);
                SplashScreen.SetStatus("Loading .............");
                System.Threading.Thread.Sleep(90);
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
