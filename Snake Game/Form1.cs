using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Game
{
    public partial class Form1 : Form
    {
        public Form ScoreForm;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            for(int i = 0; i <MainSnake.Length; i++)
            {
                Console.WriteLine("Number: {2}, X: {0}, Y: {1}", MainSnake.Body[i].Part.X, MainSnake.Body[i].Part.Y, i);
            }
            Console.WriteLine("------------------");
            GameTimer.Start();
        }

        private void Exit(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
                //ScoreForm.Close();
            }
        }


        private void GameTimerTick(object sender, EventArgs e)
        {
            DrawPlayer();
            Console.WriteLine(Settings.SDirection);
            if(Settings.SDirection == Settings.Direction.Up)
            {
                MoveSnake(0, -30);
            }
            if(Settings.SDirection == Settings.Direction.Down)
            {
                MoveSnake(0, 30);
            }
            if(Settings.SDirection == Settings.Direction.Right)
            {
                MoveSnake(30, 0);
            }
            if(Settings.SDirection == Settings.Direction.Left)
            {
                MoveSnake(-30, 0);
            }
        }

        private void MoveSnake(int x, int y)
        {
            for (int i = MainSnake.Length - 1; i > -1; i--)
            {
                if (i == 0)
                {
                    Console.WriteLine("X: {0}, Y: {1}", MainSnake.Body[i].Part.X, MainSnake.Body[i].Part.Y);
                    MainSnake.Body[0].Part = new Rectangle(MainSnake.Body[0].Part.X + x, MainSnake.Body[i].Part.Y + y, Settings.SnakeWidth, Settings.SnakeHeight);
                    Console.WriteLine("X: {0}, Y: {1}", MainSnake.Body[i].Part.X, MainSnake.Body[i].Part.Y);
                }
                else
                {
                    MainSnake.Body[i].Part = new Rectangle(MainSnake.Body[i - 1].Part.X, MainSnake.Body[i - 1].Part.Y, Settings.SnakeWidth, Settings.SnakeHeight);
                }
            }
        }

        

        private void GameControls(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Right && Settings.SDirection != Settings.Direction.Left)
            {
                Settings.SDirection = Settings.Direction.Right;
            }

            if(e.KeyCode == Keys.Left && Settings.SDirection != Settings.Direction.Right)
            {
                Settings.SDirection = Settings.Direction.Left;
            }

            if(e.KeyCode == Keys.Up && Settings.SDirection != Settings.Direction.Down)
            {
                Settings.SDirection = Settings.Direction.Up;
            }

            if(e.KeyCode == Keys.Down && Settings.SDirection != Settings.Direction.Up)
            {
                Settings.SDirection = Settings.Direction.Down;
            }
        }

        private void DrawPlayer()
        {
            List<SnakePart> Body = MainSnake.Body;
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);
            
            for(int i = 0; i<Body.Count; i++)
            {
                g.FillRectangle(Brushes.Black, Body[i].Part);
            }
        }

    }
}
