using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            if (TextInputIsValid())
            {
                ip_adress = textBox1.Text + textBox2.Text + "." + textBox3.Text + "." + textBox4.Text + "." + textBox_5.Text + ":" + textBox6.Text;
                Debug.WriteLine("IP ADDRESS=" + ip_adress);
                this.Close();
            }

            
        }

        private bool TextInputIsValid()
        {
            try
            {
                
                Convert.ToInt32(textBox2.Text);
                Convert.ToInt32(textBox3.Text);
                Convert.ToInt32(textBox4.Text);
                Convert.ToInt32(textBox_5.Text);
                Convert.ToInt32(textBox6.Text);
                return true;
            }
            catch(Exception)
            {
                MessageBox.Show("Please Enter A Valid Ip Address.Thank You");
                return false;
            }
            
        }
    }
}
