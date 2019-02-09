using System.Drawing;
using System;

namespace Snake_Game
{
    class Food : SnakePart
    {

        public Food(int x = 0, int y = 0):base(x,y)
        {
            X = x;
            Y = y;
            Part = new Rectangle(X, Y, Settings.SnakeWidth, Settings.SnakeHeight);
            GenFood();
        }

        public void GenFood()
        {
            int MaxXPos = ((Settings.MainFormSize.Width - 10) / (Settings.SnakeWidth + 5));
            int MaxYPos = ((Settings.MainFormSize.Height - 10) / (Settings.SnakeHeight + 5));

            Random random = new Random();
            X = random.Next(0, MaxXPos) * 15;
            Y = random.Next(0, MaxYPos) * 15;

            Part = new Rectangle(X, Y, Settings.SnakeWidth, Settings.SnakeHeight);

        }

    }
}
