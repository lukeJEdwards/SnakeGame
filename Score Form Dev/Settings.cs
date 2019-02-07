using System.Drawing;
using System.Windows.Forms;

namespace Score_Form_Dev
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

        public static string ScoreFileLocation;

        public static int SnakeWidth;
        public static int SnakeHeight;
        public static int Length;
        public static bool GameOver;
        public static int Speed;
        public static Direction SDirection;

        public Settings()
        {

            MainFormSize = new Size(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height);
            ScoreFormSize = new Size(MainFormSize.Width/2, MainFormSize.Height/2);
            MainFormLocation = new Point(0,0);
            ScoreFormLocaiton = new Point(MainFormSize.Width + 10, 0);

            ScoreFileLocation = "HighScore.json";

            SnakeWidth = 20;
            SnakeHeight = 20;
            Length = 0;
            GameOver = false;
            Speed = 1000;
            SDirection = Direction.Down;
        }
    }
}
