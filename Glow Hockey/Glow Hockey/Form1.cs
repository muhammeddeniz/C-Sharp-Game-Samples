using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Glow_Hockey
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int positionX = 5, positionY = 5, score = 0;
        private void impactEvents()
        {
            computerPlayer.Location = new Point(ball.Location.X, computerPlayer.Location.Y);

            if (ball.Top <= computerPlayer.Bottom)
            {
                positionY = positionY * -1;
                score += 10;
                pointLabel.Text = score.ToString();
            }

            if (ball.Bottom >= myPlayer.Top && ball.Left >= myPlayer.Left && ball.Right <= myPlayer.Right)
            {
                positionY *= -1;
            }
            else if (ball.Right >= label3.Left)
            {
                positionX *= -1;
            }
            else if (ball.Left <= label7.Right)
            {
                positionX *= -1;
            }
            else if (ball.Bottom >=label8.Top && ball.Left <=label8.Right)
            {
                positionY *= -1;
            }
            else if (ball.Bottom >= label4.Top && ball.Right >= label4.Left)
            {
                positionY *= -1;
            }
            else if (ball.Bottom >= label4.Top && ball.Right >= label4.Left)
            {
                positionY *= -1;
            }



        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            myPlayer.Left = e.X;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
       
        }

        int health = 0, highScore=0;
        private void timer1_Tick(object sender, EventArgs e)
        {

            ball.Location = new Point(ball.Location.X + positionX, ball.Location.Y + positionY);
            impactEvents();

            if (ball.Location.Y >=680)
            {
                timer1.Stop();

                health = int.Parse(healthPoint.Text);
                health--;
                if (health == 0)
                {
                    timer1.Stop();
                    MessageBox.Show("GAME OVER\n Top Score: " + toppointLabel.Text);

                }
                else
                {
                    MessageBox.Show(health + " Live You Have!");

                    score = 0;
                    pointLabel.Text = "0";

                    toppointLabel.Text = pointLabel.Text;

                    if (highScore < int.Parse(toppointLabel.Text)) 
                    {
                        highScore = int.Parse(toppointLabel.Text);
                    }

                    toppointLabel.Text = highScore.ToString();
                    this.Refresh();
                    ball.Location = new Point(317, 313);
                    timer1.Start();
                    healthPoint.Text = health.ToString();

                }
            }
            if (score>= 100 && score <= 500)
            {
                timer1.Interval = 20;
            }
            else if (score >= 500 && score<=700)
            {
                timer1.Interval = 10;
            }
            else if (score >= 700 && score <= 1000)
            {
                timer1.Interval = 6;
            }
            else if (score >= 1000 && score <= 1500)
            {
                timer1.Interval = 4;
            }
            else if (score >= 1500)
            {
                timer1.Interval = 1;
            }
            
        
        }
    }
}
