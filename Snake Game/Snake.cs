using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    public class Snake
    {
        public int Score { set; get; }
        public int Length { set; get; }
        internal List<SnakePart> Body { get; set; }

        public Snake()
        {
            Score = 0;
            Length = 10;
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
                    this.Body.Add(new SnakePart(400,400));
                }
                if(i > 0)
                {
                    temp = new SnakePart(Body[i - 1].X, Body[i - 1].Y + 30);
                    Body.Add(temp);
                }
            }
        }

        public void AddBodyPart()
        {
            Length++;
            this.Body.Add(new SnakePart(Body[Length-2].X, Body[Length-2].Y + 30));
        }

    }
}
