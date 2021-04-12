using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shake_game
{
    class Setting
    {
        public static int w { get; set; }
        public static int h { get; set; }
        public static int speed { get; set; }
        public static int bodyCount { get; set; }
        public static int score { get; set; }


        public Setting(PictureBox screen)
        {
            w = screen.Width;
            h = screen.Height;
            speed = 20;
            bodyCount = 4;
            score = 0;
        }

    }
}
