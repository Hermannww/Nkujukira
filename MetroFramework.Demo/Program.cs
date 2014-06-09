using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace MetroFramework.Demo
{
    static class Program
    {
        static bool login_is_enabled = false;
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //run splash screen

            //initialize forms
            LoginForm login_form   = new LoginForm();
            MainWindow main_window = new MainWindow();
            Debug.WriteLine("\n\n Login component =" + MainWindow.REMOVE_LOGIN_COMPONENT);
            if (MainWindow.REMOVE_LOGIN_COMPONENT == true)
            {
                login_is_enabled = true;

            }
            else
            {
                login_is_enabled = false;
            }
            //disable splash screen

            if (login_is_enabled)
            {
                //run the login form 
                Application.Run(login_form);
            }
           
            //if user has been validated then show main window
            Application.Run(main_window);
            


        }
    }
}
