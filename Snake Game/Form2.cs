using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Snake_Game
{
    public partial class Form2 : Form
    {
        public Label[] ScoreBoard;
        private List<string> Names;
        private List<int> Score;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            new Settings();
            FormBorderStyle = FormBorderStyle.None;
            Size = Settings.ScoreFormSize;
            Location = Settings.ScoreFormLocaiton;
        }

        private void ScoreBorderLoad()
        {
            ScoreBoard = new Label[10];
        }

        private void OpenFile(string FileName)
        {
            Names = new List<string>();
            Score = new List<int>();
            try
            {
                string line;
                using(StreamReader file = new StreamReader(FileName))
                {
                    line = file.ReadLine();
                    string[] Info = line.Split(',');
                    Names.Add(Info[0]);
                    Score.Add(Convert.ToInt32(Info[1]));
                }
            }catch(Exception e)
            {
                Console.WriteLine("File couldn't be read :");
                Console.WriteLine(e.Message);
            }
        }
    }
}
