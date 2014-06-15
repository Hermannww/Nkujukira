using System;
using System.Windows.Forms;
using System.Diagnostics;
using MetroFramework.Demo.Singletons;

namespace MetroFramework.Demo
{
    static class Program
    {
        private static bool login_is_enabled = true;
        public static bool running { get; set; }
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            running = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //run splash screen



            while (running)
            {
                //initialize forms
                LoginForm login_form = new LoginForm();
                MainWindow main_window = new MainWindow();


                //run the login form 
                Application.Run(login_form);

                //if the users session has been started
                if (Singleton.ADMIN != null)
                {
                    //if user has been validated then show main window
                    Application.Run(main_window);
                }
                //user is not a valid user
                else
                {
                    //set running to false and allow program to exit
                    running = false;
                }
            }



        }
    }
}
