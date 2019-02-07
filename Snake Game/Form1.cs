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
            
            for(int i = 0; i<Body.Count; i++)
            {
                g.FillRectangle(Brushes.Black, Body[i].Part);
            }
        }

    }
}
