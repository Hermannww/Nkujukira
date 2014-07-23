using System;
using System.Windows.Forms;
using System.Diagnostics;
using Nkujukira.Demo.Singletons;
using Nkujukira.Demo.Views;

namespace Nkujukira.Demo
{
    static class Program
    {
        public static bool Running { get; set; }
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Running = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //run splash screen
            ShowSplashScreen();


            while (Running)
            {
                //INITIALIZE FORM
                LoginForm login_form = new LoginForm();
                MainWindow main_window = new MainWindow();

                //CLOSE SPLASH SCREEN
                CloseSplashScreen();

                //RUN LOGIN FORM 
                Application.Run(login_form);

                //IF USER IS A VALID ADMIN
                if (Singleton.ADMIN != null)
                {
                    Singleton.InitializeStuff();
                   
                    //SHOW MAIN WINDOW
                    Application.Run(main_window);
                }

                //USER HAS CLOSED LOGIN WINDOW : DOESNT WANT TO BE VALIDATED
                else
                {
                    //TERMINATE PROGRAM
                    Running = false;
                }
            }



        }

        private static void CloseSplashScreen()
        {
            SplashScreen.CloseForm();
        }

        private static void ShowSplashScreen()
        {
            SplashScreen.ShowSplashScreen();
            SplashScreen.SetStatus("Loading module 1");
            System.Threading.Thread.Sleep(500);
            SplashScreen.SetStatus("Loading module 2");
            System.Threading.Thread.Sleep(300);
            SplashScreen.SetStatus("Loading module 3");
            System.Threading.Thread.Sleep(900);
            SplashScreen.SetStatus("Loading module 4");
            System.Threading.Thread.Sleep(100);
            SplashScreen.SetStatus("Loading module 5");
            System.Threading.Thread.Sleep(400);
            SplashScreen.SetStatus("Loading module 6");
            System.Threading.Thread.Sleep(50);
            SplashScreen.SetStatus("Loading module 7");
            System.Threading.Thread.Sleep(240);
            SplashScreen.SetStatus("Loading module 8");
            System.Threading.Thread.Sleep(900);
            SplashScreen.SetStatus("Loading module 9");
            System.Threading.Thread.Sleep(240);
            SplashScreen.SetStatus("Loading module 10");
            System.Threading.Thread.Sleep(90);
            SplashScreen.SetStatus("Loading module 11");
            System.Threading.Thread.Sleep(1000);
            SplashScreen.SetStatus("Loading module 12");
            System.Threading.Thread.Sleep(100);
            SplashScreen.SetStatus("Loading module 13");
            System.Threading.Thread.Sleep(500);
            SplashScreen.SetStatus("Loading module 14", false);
            System.Threading.Thread.Sleep(1000);
            SplashScreen.SetStatus("Loading module 14a", false);
            System.Threading.Thread.Sleep(1000);
            SplashScreen.SetStatus("Loading module 14b", false);
            System.Threading.Thread.Sleep(1000);
            SplashScreen.SetStatus("Loading module 14c", false);
            System.Threading.Thread.Sleep(1000);
            SplashScreen.SetStatus("Loading module 15");
            System.Threading.Thread.Sleep(20);
            SplashScreen.SetStatus("Loading module 16");
            System.Threading.Thread.Sleep(450);
            SplashScreen.SetStatus("Loading module 17");
            System.Threading.Thread.Sleep(240);
            SplashScreen.SetStatus("Loading module 18");
            System.Threading.Thread.Sleep(90);

        }
    }
}
