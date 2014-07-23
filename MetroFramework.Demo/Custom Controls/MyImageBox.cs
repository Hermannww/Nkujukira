using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nkujukira.Demo.Custom_Controls
{
    public class MyImageBox : ImageBox
    {
        private const int INTERVAL    = 200;
        private const int BORDER_SIZE = 4;
        private Color BORDER_COLOR    = Color.Red;
        private System.Timers.Timer my_timer;
        private bool draw_border;


        public MyImageBox()
            : base()
        {
            draw_border               = false;
            my_timer                  = new System.Timers.Timer(INTERVAL);
            my_timer.Elapsed += TimerIntervalElapsed;
        }

        public void EnableAlertMode()
        {
            my_timer.Start();
        }

        public void DisableAlertMode()
        {
            my_timer.Stop();
            draw_border = false;
            base.Invalidate();
        }

        private void TimerIntervalElapsed(object sender, EventArgs e)
        {
            draw_border               = !draw_border;
            base.Invalidate();
        }

       

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (draw_border)
            {
                ControlPaint.DrawBorder(
                                             e.Graphics, ClientRectangle,
                                             BORDER_COLOR, BORDER_SIZE, ButtonBorderStyle.Solid,
                                             BORDER_COLOR, BORDER_SIZE, ButtonBorderStyle.Solid,
                                             BORDER_COLOR, BORDER_SIZE, ButtonBorderStyle.Solid,
                                             BORDER_COLOR, BORDER_SIZE, ButtonBorderStyle.Solid
                                        );
            }
        }
    }
}

