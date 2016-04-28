using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf_BouncyBall
{
    public partial class Form1 : Form
    {

        public int vSpeed = 2;     //speed of going up or down
        public int hSpeed = 2;     //speed of left or right
        public int score = 0;

        Random dice = new Random();


        public Form1()
        {
            InitializeComponent();
            this.Bounds = Screen.PrimaryScreen.Bounds; // make it full screen
            racket.Top = playground.Bottom - (playground.Bottom / 20); // set racket position
            score_lbl.Text = score.ToString();
            gameOver.Visible = false;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            helpWindow.Visible = false;

            racket.Left = Cursor.Position.X - (racket.Width / 2);

            ball.Left += hSpeed;
            ball.Top += vSpeed;
            
            if(ball.Bottom >= racket.Top && ball.Bottom <= racket.Bottom && ball.Left+(ball.Width/1.5) >= racket.Left && ball.Right-(ball.Width /1.5) <= racket.Right)
            {
                if (hSpeed < 0)
                    hSpeed -= 1;
                else
                    hSpeed += 1;

                vSpeed += 1;
                vSpeed = -vSpeed;
                if((ball.Left <= (racket.Left+(racket.Width/4))))
                {
                    if (hSpeed > 0)
                        hSpeed = -hSpeed;
                    else
                        hSpeed +=1;
                }
                else if((ball.Right >= (racket.Right - (racket.Width / 4))))
                {
                    if (hSpeed < 0)
                        hSpeed = -hSpeed;
                    else
                        hSpeed -= 1;
                }
                
                score++;
                score_lbl.Text = score.ToString();
            }
            if (ball.Left <= playground.Left)
                hSpeed = -hSpeed;
            if (ball.Right >= playground.Right)
                hSpeed = -hSpeed;
            if (ball.Top <= playground.Top)
                vSpeed = -vSpeed;
            if (ball.Bottom >= playground.Bottom)
            {
                timer1.Enabled = false;              // when the ball hits the ground.
                gameOver.Visible = true;
                helpWindow.Visible = true;
            }

        }// end of timer 1 method

        private void playground_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Hide();
        }

        private void playground_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Show();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
            if(e.KeyCode == Keys.P && gameOver.Visible == false)
            {
                if (timer1.Enabled == false)
                    timer1.Enabled = true;
                else
                    timer1.Enabled = false;
                helpWindow.Visible = true;
            }
            if(e.KeyCode == Keys.F1)
            {
                ball.Left = playground.Right / 2;
                ball.Top = (playground.Bottom / 3);
                vSpeed = 2;
                int val = dice.Next(0, 2);
                if(val == 1)
                {
                    hSpeed = 2;
                }
                else
                {
                    hSpeed = -2;
                }
                score = 0;
                score_lbl.Text = "0";
                helpWindow.Visible = false;
                gameOver.Visible = false;

                timer1.Enabled = true;
            }
        }
        
    }
}
