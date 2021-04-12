using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shake_game
{
    class Fluid
    {
        private int nowTime { get; set; }
        private int x { get; set; }
        private int y { get; set; }


        public Fluid(int t, int x, int y)
        {
            this.nowTime = t; 
            this.x = x;
            this.y = y;
        }

        private double d = 90;
        private int res = 20;

        public bool DrawFluid(Graphics g, PictureBox screen, int t)
        {
            if (t - this.nowTime > 1500)
            {
                return true;
            }
            SolidBrush brush1 = new SolidBrush(Color.FromArgb(200, 10, 10, 10));

            int X = this.x; 
            int Y = this.y;
            double r;
            float len;

            for (int x = 0; x < screen.Width; x += res)
            {
                for (int y = 0; y < screen.Height; y += res)
                {
                    r = Math.Sqrt((x - X) * (x - X) + (y - Y) * (y - Y));
                    if (r < d + (t - this.nowTime) && r > (t - this.nowTime))
                    {
                        len = (float)((r - (t - this.nowTime) + 30) / d * 15);
                        g.FillRectangle(brush1, x, y, len, len);
                    }
                    else if (r < 2 * d + (t - this.nowTime) && r > (t - this.nowTime) + d)
                    {
                        len = (float)((1 - (r - ((t - this.nowTime) + d)) / (d + 30)) * 20);
                        g.FillRectangle(brush1, x, y, len, len);
                    }
                }
            }

            return false;
        }
    }
}
