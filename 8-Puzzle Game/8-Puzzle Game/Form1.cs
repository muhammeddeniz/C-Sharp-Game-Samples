using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_Puzzle_Game
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        Button number;
        int temporaryX, temporaryY;
        int score = 1000;
        int counter = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void click_all(object sender, MouseEventArgs e)
        {
            if (counter % 2 == 0)
            {
                number = ((Button)sender);

                counter++;
            }
            else
            {
                int locationButonX = ((Button)sender).Location.X;
                int locationButonY = ((Button)sender).Location.Y;
                int locationNumberX = number.Location.X;
                int locationNumberY = number.Location.Y;

                if (locationButonX-locationNumberX != 0 && locationButonY - locationNumberY != 0)
                {
                    MessageBox.Show("Hata!!! \nÇapraz Gidilemez.");
                    counter++;
                }
                else if (((Button)sender).Text == "")
                {
                    temporaryX = number.Location.X;
                    temporaryY = number.Location.Y;
                    number.Location = ((Button)sender).Location;
                    ((Button)sender).Location = new Point(temporaryX, temporaryY);

                    counter++;
                }
                else
                {
                    MessageBox.Show("Hata!!!");
                    counter++;
                }
                score -= 20;
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            konum1.Text = "5";
            konum2.Text = "8";
            konum3.Text = "2";
            konum4.Text = "6";
            konum8.Text = "1";
            konum6.Text = "4";
            konum7.Text = "3";
            konum9.Text = "7";
        }

    }
}

