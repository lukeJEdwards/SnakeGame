using System;
using System.Collections.Generic;

namespace Snake_Game
{
    public class Snake
    {
        public int Score { set; get; }
        public int Length { set; get; }
        private int Start = 0;
        internal List<SnakePart> Body { get; set; }

        public Snake()
        {
            Score = 0;
            Length = 1;
            SetUpBody();
        }

        private void SetUpBody()
        {
            Body = new List<SnakePart>();
            SnakePart temp;
            for(int i = 0; i < Length; i++)
            {
                if (i == 0)
                {
                    this.Body.Add(new SnakePart(Start,Start));
                }
                if(i > 0)
                {
                    temp = new SnakePart(Body[i - 1].X, Body[i - 1].Y + 15);
                    Body.Add(temp);
                }
            }
        }

        public void AddBodyPart()
        {
            Length++;
            this.Body.Add(new SnakePart(Body[Length-2].X, Body[Length-2].Y + 30));
        }

        public void CheckForCollisons()
        {
            FoodCollision();
            CheckWallCollisons();
            for(int i = 1; i < Length; i++)
            {
                if (Body[0].Part.IntersectsWith(Body[i].Part))
                {
                    Settings.GameOver = true;
                    Console.WriteLine("Collided with its self");
                }
            }
        }

        private void CheckWallCollisons()
        {
            if(Body[0].X < 0 || Body[0].X > Settings.MainFormSize.Width - Settings.SnakeWidth)
            {
                Settings.GameOver = true;
                Console.WriteLine("Out of bounds (Width)");
            }
            if (Body[0].Y < 0 || Body[0].Y > Settings.MainFormSize.Height - Settings.SnakeHeight)
            {
                Settings.GameOver = true;
                Console.WriteLine("Out of bounds (Height)");
            }
        }

        private void FoodCollision()
        {
            if (Body[0].Part.IntersectsWith(Bord.MainFood.Part))
            {
                Score++;
                Bord.MainFood.GenFood();
                AddBodyPart();
            }
        }

    }
}
