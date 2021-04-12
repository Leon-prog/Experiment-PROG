using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shake_game
{
    public partial class mainWindow : Form
    {
        public mainWindow()
        {
            InitializeComponent();
        }
        private void mainWindow_Load(object sender, EventArgs e)
        {
            startGame();
        }

        private Snake snake = new Snake();
        private vec2 food = new vec2();
        private void startGame()
        {
            new Setting(screen);

            resetGame.Visible = false;
            resetGame.Enabled = false;

            mainTimer.Interval = 1;
            mainTimer.Tick += updateScreen;
            mainTimer.Start();

            gameTimer.Interval = 100;
            gameTimer.Tick += updateGame;
            gameTimer.Start();

            fluids.Clear();
            snake = new Snake();

            generateFood();
        }

        Random r = new Random();
        private void generateFood()
        {
            vec2 posFood;
            do
            {
                posFood = new vec2(r.Next(0, screen.Width / 20) * 20, r.Next(0, screen.Height / 20) * 20);
            } while (snake.body.Find(x => x.x == posFood.x && x.y == posFood.y) != null);

            food = posFood;
        }

        int state;
        private void updateGame(object sender, EventArgs e)
        {
            state = snake.Update(food);
            if (state == 1)
            {
                fluids.Add(new Fluid(t, food.x, food.y));
                Setting.score++;
                score.Text = Convert.ToString(Setting.score);
                generateFood();                
            }
            if (state == 2 )
            {
                gameTimer.Tick -= updateGame;
                gameTimer.Stop();
                resetGame.Visible = true;
                resetGame.Enabled = true;
            }
        }

        SolidBrush brush1 = new SolidBrush(Color.FromArgb(100, 0, 0, 0));
        private int res = 20;
        List<Fluid> fluids = new List<Fluid>();

        private void screen_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;            

            for (int x = -2; x < screen.Width; x += res)
            {
                for (int y = -2; y < screen.Height; y += res)
                {
                    g.FillRectangle(brush1, x, y, 5, 5);
                }
            }

            Fluid fluid1 = null;
            foreach (Fluid fluid in fluids)
            {
                if(fluid.DrawFluid(g, screen, t))
                {
                    fluid1 = fluid;
                }
            }

            if (fluid1 != null) {
                fluids.Remove(fluid1);
            }

            snake.Draw(g, food);
        }
       
        int t = 0;
        private void updateScreen(object sender, EventArgs e)
        {
            t+=2;
            screen.Refresh();
        }

        private void resetGame_Click(object sender, EventArgs e)
        {
            mainWindow_Load(sender, e);
        }

        private void mainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                //MessageBox.Show("Shift");
                snake.GoUp();
            }
            else if (e.KeyCode == Keys.S)
            {
                snake.GoDown();
            }
            else if (e.KeyCode == Keys.A)
            {
                snake.GoLeft();
            }
            else if (e.KeyCode == Keys.D)
            {
                snake.GoRight();
            }
        }
    }
}
