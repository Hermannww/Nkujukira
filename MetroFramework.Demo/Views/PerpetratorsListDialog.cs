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
    public partial class PerpetratorsListDialog : MetroForm
    {
        public PerpetratorsListDialog()
        {
            InitializeComponent();
            this.Style = MetroColorStyle.Red;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
        }

        private void PerpetratorsListDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
