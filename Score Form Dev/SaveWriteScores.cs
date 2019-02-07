using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Score_Form_Dev
{
    class SaveWriteScores
    {

        public Score[] HighScores;
        public SaveWriteScores()
        {
            HighScores = ReadHightScores();
        }

        public Score[] ReadHightScores()
        {
            this.HighScores = new Score[5];
            try
            {
                string line = "";
                using(StreamReader file = new StreamReader(Settings.ScoreFileLocation))
                {
                    line = file.ReadToEnd();
                }
                this.HighScores = JsonConvert.DeserializeObject<Score[]>(line); 
            }catch(Exception e)
            {
                Console.Write("File could not be read: ");
                Console.WriteLine(e.Message);
            }
            return HighScores;
        }

        public void WriteScore()
        {
            string NewHeighScores = JsonConvert.SerializeObject(this.HighScores, Formatting.Indented);
            using (StreamWriter file = new StreamWriter(Settings.ScoreFileLocation))
            {
                file.Write(NewHeighScores);
            }
        }

        public void CheckIfHigher(Score Current)
        {
            for(int i = 0; i < HighScores.Length; i++)
            {
                if(this.HighScores[i].playerscore < Current.playerscore)
                {
                    this.HighScores[i] = Current;
                }
            }
        }

    }

    class Score
    {
        public int place { set; get; }
        public string name { set; get; }
        public int playerscore { set; get; }


        [JsonConstructor]
        public Score(int Place, string Name, int PlayerScore)
        {
            place = Place;
            name = Name;
            playerscore = playerscore;
        }
    }
}
