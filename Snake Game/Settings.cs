﻿using System.Drawing;

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

        public static string ScoreFileLocation;
        public static string FontFile;

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
            ScoreFormLocaiton = new Point(MainFormLocation.X + MainFormSize.Width + 10, MainFormLocation.Y);

            ScoreFileLocation = "HighScores.json";
            FontFile = "8-BIT WONDER.ttf";

            SnakeWidth = 10;
            SnakeHeight = 10;
            GameOver = false;
            Speed = 8;
            SDirection = Direction.Down;
        }
    }
}
