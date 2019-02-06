using System.Drawing;
using System;

namespace Snake_Game
{
    class Food : SnakePart
    {
        public int ScoreIncrement { set; get; }

        public Food()
        {
            ScoreIncrement = 1;
            X = 0;
            Y = 0;
            PartSize = new Size(Settings.SnakeWidth, Settings.SnakeHeight);
            Part = new Rectangle(Location, PartSize);
        }

        public static Food GenFood()
        {
            int MaxXPos = Settings.MainFormSize.Width / Settings.SnakeWidth;
            int MaxYPos = Settings.MainFormSize.Height / Settings.SnakeHeight;

            Random random = new Random();

            Food temp = new Food()
            {
                X = random.Next(0, MaxXPos),
                Y = random.Next(0, MaxYPos)
            };
            return temp;

        }

    }
}
