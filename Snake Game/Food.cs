using System.Drawing;
using System;

namespace Snake_Game
{
    class Food : SnakePart
    {
        public int ScoreIncrement { set; get; }

        public Food(int x, int y):base(x,y)
        {
            ScoreIncrement = 1;
            X = x;
            Y = y;
            Part = new Rectangle(X, Y, Settings.SnakeWidth, Settings.SnakeHeight);
        }

        public static Food GenFood()
        {
            int MaxXPos = Settings.MainFormSize.Width / Settings.SnakeWidth;
            int MaxYPos = Settings.MainFormSize.Height / Settings.SnakeHeight;

            Random random = new Random();

            Food temp = new Food(random.Next(0, MaxXPos), random.Next(0, MaxYPos));
            return temp;

        }

    }
}
