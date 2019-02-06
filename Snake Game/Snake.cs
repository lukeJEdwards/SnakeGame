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
            Length = 5;
            SetUpBody();
        }

        private void SetUpBody()
        {
            Body = new List<SnakePart>();
            for(int i = 0; i < Length; i++)
            {
                if (i == 0)
                {
                    this.Body.Add(new SnakePart() { Name = "Head" });
                }
                else
                {
                    this.Body.Add(new SnakePart() { Name = Convert.ToString(i)});
                }
            }
        }

        public void AddBodyPart()
        {
            Length++;
            this.Body.Add(new SnakePart() { Name = Convert.ToString(Length) });
        }

    }
}
