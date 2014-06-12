using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace MetroFramework.Demo.Views
{
    public partial class WindowDecorator:MetroForm
    {
        MetroForm mainwindow;

        public WindowDecorator()
        {
            InitializeComponent();
        }
        public WindowDecorator(MetroForm mainwindow)
        {
            this.mainwindow = mainwindow;
            addLogin();
        }
        private void addLogin() 
        {
            LoginForm login_form = new LoginForm();
        }
       
    }
}
