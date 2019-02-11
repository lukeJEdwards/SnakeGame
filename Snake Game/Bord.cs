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
    public partial class Bord : Form
    {

        public Bord()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            LeaderBoardSetup();
            LeaderBoard.Show();
            GameStartUp();
            //GameTimer.Start();
        }

        //start of the game
        private void GameStartUp()
        {
            Label Namelabel = new Label()
            {
                Name = "NameLabel",
                AutoSize = true,
                Text = "Enter Name",
                Font = new Font(pfc.Families[0], 16, FontStyle.Bold),
                BackColor = this.BackColor,
                ForeColor = Color.Black
            };
            Namelabel.Location = new Point(this.Width / 2 - Namelabel.Width, this.Height / 4);
            this.Controls.Add(Namelabel);

            TextBox PlayerName = new TextBox()
            {
                Name = "Players Name",
                AcceptsTab = true,
                Multiline = false,
                AcceptsReturn = false,
                WordWrap = true,
                Text = "Joe Doe",
                TextAlign = HorizontalAlignment.Center,
                Font = new Font(pfc.Families[0], 16, FontStyle.Bold),
                BorderStyle = BorderStyle.None,
            };
            PlayerName.Location = new Point(this.Width / 2 - PlayerName.Width/2, this.Height / 2 - PlayerName.Height);
            PlayerName.TextChanged += new EventHandler(TextBoxTextChanged);
            PlayerName.KeyDown += new KeyEventHandler(this.Exit);
            PlayerName.KeyDown += new KeyEventHandler(this.SetName);
            this.Controls.Add(PlayerName);
        }

        private void SetName(object sender, KeyEventArgs e)
        {
            TextBox playername = sender as TextBox;
            if(e.KeyCode == Keys.Enter)
            {
                PlayerScore.name = playername.Text;
                Console.WriteLine(playername.Text);
            }
        }

        private void TextBoxTextChanged(object sender, EventArgs e)
        {
            TextBox playername = sender as TextBox;
            Size size = TextRenderer.MeasureText(playername.Text, playername.Font);
            playername.Width = size.Width;
            playername.Height = size.Height;
            playername.Location = new Point(this.Width / 2 - playername.Width/2, this.Height / 2 - playername.Height);
        }

        //Force Exit
        private void Exit(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
                LeaderBoard.Close();
            }
        }

        //GameTick
        private void GameTimerTick(object sender, EventArgs e)
        {
            if (!Settings.GameOver)
            {
                MovingControls();
            }
            DrawPlayer();
            MainSnake.CheckForCollisons();
            GameOverCheck();
        }

        //cheack everyframe for the game over bool
        private void GameOverCheck()
        {
            if (Settings.GameOver)
            {
                GameTimer.Stop();
                Console.WriteLine("Game Over");
                Console.WriteLine(MainSnake.Score);
            }
        }

        //sendes the increment of the snake every frame
        private void MovingControls()
        {
            const int inc = 15;
            //Console.WriteLine(Settings.SDirection);
            if (Settings.SDirection == Settings.Direction.Up)
            {
                MoveSnake(0, -inc);
            }
            if (Settings.SDirection == Settings.Direction.Down)
            {
                MoveSnake(0, inc);
            }
            if (Settings.SDirection == Settings.Direction.Right)
            {
                MoveSnake(inc, 0);
            }
            if (Settings.SDirection == Settings.Direction.Left)
            {
                MoveSnake(-inc, 0);
            }
        }

        //goes through the whole snake and updates body part location
        private void MoveSnake(int x, int y)
        {
            for (int i = MainSnake.Length - 1; i > -1; i--)
            {
                if (i == 0)
                {
                    MainSnake.Body[0].Part = new Rectangle(MainSnake.Body[0].Part.X + x, MainSnake.Body[0].Part.Y + y, Settings.SnakeWidth, Settings.SnakeHeight);
                    MainSnake.Body[0].X += x;
                    MainSnake.Body[0].Y += y;
                }
                else
                {
                    MainSnake.Body[i].Part = new Rectangle(MainSnake.Body[i - 1].Part.X, MainSnake.Body[i - 1].Part.Y, Settings.SnakeWidth, Settings.SnakeHeight);
                    MainSnake.Body[i].X = MainSnake.Body[i - 1].X;
                    MainSnake.Body[i].Y = MainSnake.Body[i - 1].Y;
                }
               //Console.WriteLine("X: {0}, Y: {1}", MainSnake.Body[i].Part.X, MainSnake.Body[i].Part.Y);
            }
        }

        //makes sure you cann't go back on yourself
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

        //draws everything to the screen
        private void DrawPlayer()
        {
            List<SnakePart> Body = MainSnake.Body;
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);

            for (int i = 0; i<Body.Count; i++)
            {
                g.FillRectangle(Brushes.Black, Body[i].Part);
            }
            g.FillRectangle(Brushes.Black, MainFood.Part);
        }


        //LeaderBoard

        private void LeaderBoardSetup()
        {
            LeaderBoard.KeyDown += new KeyEventHandler(this.Exit);
            LeaderBoard.StartPosition = FormStartPosition.Manual;
            LeaderBoard.FormBorderStyle = FormBorderStyle.None;
            LeaderBoard.Size = Settings.ScoreFormSize;
            LeaderBoard.Location = Settings.ScoreFormLocaiton;
            LeaderBoard.ShowInTaskbar = false;
            ScoreLabels();
        }

        private void ScoreLabels()
        {
            Label temp;
            Label ScoreLabel = new Label()
            {
                Name = "ScoreLabel",
                AutoSize = true,
                Font = new Font(pfc.Families[0], 16, FontStyle.Bold),
                Text = "Score: 00",
                Visible = true,
                BorderStyle = BorderStyle.None,
                BackColor = this.BackColor,
                ForeColor = Color.Black,
                Location = new Point(0, 0)
            };
            LeaderBoard.Controls.Add(ScoreLabel);

            int j = 1;
            for(int i = 0; i < FileHandling.HighScores.Length; i++)
            {
                temp = new Label()
                {
                    Name = Convert.ToString(i),
                    AutoSize = true,
                    Font = new Font(pfc.Families[0], 16, FontStyle.Regular),
                    Text = FileHandling.HighScores[i].name + ": " + Convert.ToString(FileHandling.HighScores[i].playerscore),
                    Visible = true,
                    BorderStyle = BorderStyle.None,
                    BackColor = this.BackColor,
                    ForeColor = Color.Black,
                    Location = new Point(0, j * (Settings.ScoreFormSize.Height / 6))
                };
                j++;
                LeaderBoard.Controls.Add(temp);
            }
        }

    }
}
