using System.Drawing;

namespace Snake_Game
{
    class SnakePart
    {
        public string Name { get; set; }
        public int X { set; get; }
        public int Y { set; get; }
        public Rectangle Part { set; get; }
        public Size PartSize { set; get; }
        public Point Location { set; get; }

        public SnakePart()
        {
            X = 0;
            Y = 0;
            PartSize = new Size(Settings.SnakeWidth, Settings.SnakeHeight);
            Part = new Rectangle(Location, PartSize);
        }
    }
}
