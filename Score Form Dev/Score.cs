using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Score_Form_Dev
{
    public partial class Score : Form
    {
        public Score()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadHighScores();
            
        }


        private void Exit(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }


        private void LoadHighScores()
        {
            Label[] Labels = new Label[5];
            Label temp;
            Label ScoreLabel = new Label()
            {
                Name = "ScoreLabel",
                AutoSize = true,
                Font = new Font(pfc.Families[0], 24, FontStyle.Bold),
                Text = "Score: 00",
                Visible = true,
                BorderStyle = BorderStyle.None,
                BackColor = this.BackColor,
                ForeColor = Color.Black,
                Location = new Point(0, 0)
            };
            this.Controls.Add(ScoreLabel);
            int j = 1;
            for (int i = 0; i < Labels.Length; i++)
            {
                temp = new Label()
                {
                    Name = Convert.ToString(i),
                    AutoSize = true,
                    Font = new Font(pfc.Families[0], 24, FontStyle.Regular),
                    Text = FileHandling.HighScores[i].name + ": " + Convert.ToString(FileHandling.HighScores[i].playerscore),
                    Visible = true,
                    BorderStyle = BorderStyle.None,
                    BackColor = this.BackColor,
                    ForeColor = Color.Black,
                    Location = new Point(0, j * (Settings.ScoreFormSize.Height / 6))
                };
                j++;
                this.Controls.Add(temp);
                this.Controls.Add(Labels[i]);
            }
        }
    }
}
