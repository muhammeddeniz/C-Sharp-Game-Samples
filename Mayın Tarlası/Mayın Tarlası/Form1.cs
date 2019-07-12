using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mayın_Tarlası
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Button[] bombalar = new Button[29];
        Button[,] tarla = new Button[20, 20];
        bool kontrol = false;
        bool oyunBitti = false;
        int puan = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    tarla[i, j] = new Button();
                    tarla[i, j].Location = new Point(i * 25, j * 25);
                    tarla[i, j].Width = 25;
                    tarla[i, j].Height = 25;
                    this.Controls.Add(tarla[i, j]);

                    tarla[i, j].Click += new EventHandler(TıklananButon);
                }
            }

            for (int i = 0; i < 29; i++)
            {
                int bombaX = rnd.Next(0, 20);
                int bombaY = rnd.Next(0, 20);

                bombalar[i] = tarla[bombaX, bombaY];    
            }

            void TıklananButon(object tıkladı, EventArgs r)
            {
                if (!oyunBitti)
                {
                    foreach (var item in bombalar)
                    {
                        if (((Button)tıkladı) == item)
                        {
                            foreach (var item2 in bombalar)
                            {
                                item2.BackColor = Color.Red;
                                item2.Enabled = false;
                                kontrol = true;
                                oyunBitti = true;
                            }
                        }
                    }
                    if (kontrol == false)
                    {
                        ((Button)tıkladı).BackColor = Color.Green;
                        ((Button)tıkladı).Enabled = false;
                        puan += 10;
                    }
                }
                else
                {
                    MessageBox.Show("Oyun Bitti!!! \nPUAN : " + puan);
                }
            }
        }
    }
}
