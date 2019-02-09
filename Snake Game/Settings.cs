using System.Drawing;

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
            MainFormSize = new Size(895, 895);
            ScoreFormSize = new Size(MainFormSize.Width/2, MainFormSize.Height/2);
            MainFormLocation = new Point(100,100);
            ScoreFormLocaiton = new Point(MainFormSize.Width, 0);

            SnakeWidth = 10;
            SnakeHeight = 10;
            GameOver = false;
            Speed = 5;
            SDirection = Direction.Down;
        }
    }
}
