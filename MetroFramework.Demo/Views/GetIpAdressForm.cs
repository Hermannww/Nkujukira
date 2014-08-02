using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace Nkujukira.Demo.Views
{
    public partial class GetIpAdressForm : MetroForm
    {
        public string ip_adress { get; set; }

        public GetIpAdressForm()
        {
            InitializeComponent();
        }

        private void done_button_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(maskedTextBox2.Text)) 
            {
                ip_adress = maskedTextBox2.Text+"//video?x.mpeg";
            }
            this.Close();
        }
    }
}
