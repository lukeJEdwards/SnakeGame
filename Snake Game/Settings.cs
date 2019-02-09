using System.Drawing;
using System.Windows.Forms;

namespace Snake_Game
{
    class Settings
    {

        public enum Direction
        {
            Right, 
            Left,
            Up,
            Down
        };

        public static Size MainFormSize;
        public static Size ScoreFormSize;
        public static Point MainFormLocation;
        public static Point ScoreFormLocaiton;

        public static int SnakeWidth;
        public static int SnakeHeight;
        public static bool GameOver;
        public static int Speed;
        public static Direction SDirection;

        public Settings()
        {
            MainFormSize = new Size(800, 800);
            //MainFormSize = new Size(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height);
            ScoreFormSize = new Size(MainFormSize.Width/2, MainFormSize.Height/2);
            MainFormLocation = new Point(MainFormSize.Width,200);
            ScoreFormLocaiton = new Point(MainFormSize.Width, 0);

            SnakeWidth = 20;
            SnakeHeight = 20;
            GameOver = false;
            Speed = 5;
            SDirection = Direction.Up;
        }
    }
}
