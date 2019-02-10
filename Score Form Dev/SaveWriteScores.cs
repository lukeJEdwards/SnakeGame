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

        public ScoreItem[] HighScores;
        public SaveWriteScores()
        {
            HighScores = ReadHightScores();
        }

        public ScoreItem[] ReadHightScores()
        {
            this.HighScores = new ScoreItem[5];
            try
            {
                string line = "";
                using(StreamReader file = new StreamReader(Settings.ScoreFileLocation))
                {
                    line = file.ReadToEnd();
                }
                Console.WriteLine(line);
                this.HighScores = JsonConvert.DeserializeObject<ScoreItem[]>(line); 
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

        public void CheckIfHigher(ScoreItem Current)
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

    class ScoreItem
    {
        public string name { set; get; }
        public int playerscore { set; get; }


        [JsonConstructor]
        public ScoreItem(string Name, int PlayerScore)
        {
            name = Name;
            playerscore = PlayerScore;
        }
    }
}
