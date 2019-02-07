using System.Drawing;

namespace Snake_Game
{
    class SnakePart
    {
        public int X;
        public int Y;
        public Rectangle Part { set; get; }

        public SnakePart(int x, int y)
        {
            X = x;
            Y = y;
            Part = new Rectangle(X, Y, Settings.SnakeWidth, Settings.SnakeHeight);
        }

        public void ChangeRectangle(int x, int y, int width, int height)
        {
            Part = new Rectangle()
            {
                X = x,
                Y = y, 
                Width = width,
                Height = height
            };
        }
    }
}
