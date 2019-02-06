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
        public Timer GameTimer;
        public Form ScoreForm;
        public Snake MainSnake;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            MainSnake = new Snake();
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
            Console.WriteLine(Settings.SDirection);
        }

        private void DrawPlayer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            



        }

    }
}
