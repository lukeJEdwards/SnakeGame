using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;

namespace Score_Form_Dev
{
    partial class Score
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        SaveWriteScores FileHandling;
        PrivateFontCollection pfc;
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            new Settings();
            FileHandling = new SaveWriteScores();

            pfc = new PrivateFontCollection();
            pfc.AddFontFile("8-BIT WONDER.ttf");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = Settings.ScoreFormSize;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = Settings.ScoreFormLocaiton;
            this.Name = "Score";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Score";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Exit);
            this.ResumeLayout(false);
        }

        #endregion
    }
}

