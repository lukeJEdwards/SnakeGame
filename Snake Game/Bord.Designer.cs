using System.Windows.Forms;

namespace Snake_Game
{
    partial class Bord
    {

        public Timer GameTimer;
        public Snake MainSnake;
        private static Food mainFood;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        internal static Food MainFood { get => mainFood; set => mainFood = value; }

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
            MainFood = new Food();
            GameTimer = new Timer() { Interval = 1000 / Settings.Speed };
            GameTimer.Tick += new System.EventHandler(this.GameTimerTick);
            MainSnake = new Snake();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = Settings.MainFormSize;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Location = Settings.MainFormLocation;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameControls);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Exit);
            this.ResumeLayout(false);
        }

        #endregion
    }
}

