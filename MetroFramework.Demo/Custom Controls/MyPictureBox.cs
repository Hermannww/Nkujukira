using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nkujukira.Demo.Custom_Controls
{
    public class MyPictureBox:PictureBox
    {
        private int BORDER_SIZE = 4;
        private Color BORDER_COLOR = Color.ForestGreen;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                                         BORDER_COLOR, BORDER_SIZE, ButtonBorderStyle.Solid,
                                         BORDER_COLOR, BORDER_SIZE, ButtonBorderStyle.Solid,
                                         BORDER_COLOR, BORDER_SIZE, ButtonBorderStyle.Solid,
                                         BORDER_COLOR, BORDER_SIZE, ButtonBorderStyle.Solid);
        } 
    }
}
