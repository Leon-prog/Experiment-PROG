using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shake_game
{
    class Snake
    {
        public List<vec2> body { get; set; }
        private int xSpeed { get; set; }
        private int ySpeed { get; set; }
        private int dir { get; set; }

        public Snake()
        {
            body = new List<vec2>();      
            this.xSpeed = 1;
            this.ySpeed = 0;
            this.dir = 20;
            for (int i = Setting.bodyCount + 1; i > 1 ; i--)
            {
                this.body.Add(new vec2(i * Setting.speed, 0));
            }
        }

        public void GoUp()
        {
            if (this.xSpeed != 0 && this.ySpeed != 1) {
                this.xSpeed = 0;
                this.ySpeed = -1;
            }
        }
        public void GoDown()
        {
            if (this.xSpeed != 0 && this.ySpeed != -1)
            {
                this.xSpeed = 0;
                this.ySpeed = 1;
            }
        }
        public void GoLeft()
        {
            if (this.xSpeed != 1 && this.ySpeed != 0)
            {
                this.xSpeed = -1;
                this.ySpeed = 0;
            }
        }
        public void GoRight()
        {
            if (this.xSpeed != -1 && this.ySpeed != 0)
            {
                this.xSpeed = 1;
                this.ySpeed = 0;
            }
        }

        public int Update(vec2 food)
        {
            int state = 0;
            this.body[0].x += this.xSpeed * this.dir;
            this.body[0].y += this.ySpeed * this.dir;

            if (this.body[0].x == food.x && this.body[0].y == food.y)
            {
                this.body.Add(new vec2());
                state = 1;
            }
            for (int j = 1; j < body.Count; ++j)
            {
                if (this.body[0].x == this.body[j].x && this.body[0].y == this.body[j].y)
                {
                    state = 2;
                }
            }
            if (this.body[0].x < 0 || this.body[0].y < 0 || this.body[0].x > Setting.w || this.body[0].y > Setting.h)
            {
                state = 2;
            }

            this.body[0].x -= this.xSpeed * this.dir;
            this.body[0].y -= this.ySpeed * this.dir;

            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            this.body[0].x += this.xSpeed * this.dir;
            this.body[0].y += this.ySpeed * this.dir;

            return state;
        }

        SolidBrush brush1;
        public void Draw(Graphics g, vec2 food)
        {            
            for (int i = 0; i < body.Count; i++)
            {
                brush1 = new SolidBrush(Color.FromArgb(255, (int)(((double)(i + 1) / (double)body.Count) * 200), 0, 0));
                g.FillRectangle(brush1, this.body[i].x, this.body[i].y, 20, 20);
            }
            brush1 = new SolidBrush(Color.FromArgb(100, 0, 255, 0));
            g.FillRectangle(brush1, food.x, food.y, 20, 20);
        }

    }
}
