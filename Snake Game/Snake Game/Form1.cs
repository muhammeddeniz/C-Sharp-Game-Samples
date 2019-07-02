using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PictureBox[] snakePiece = new PictureBox[4];

        int trail = 0, snakeHead = 0;
        char previousCommand;
        bool gameCase = false;
        bool SnakeCrashed = false;
        int leftMove = 0, topMove = 0;

        private void newPiece()
        {
            snakePiece = new PictureBox[4];
            for (int i = 0; i < snakePiece.Length; i++)
            {
                snakePiece[i] = new PictureBox();
                snakePiece[i].Width = 15;
                snakePiece[i].Height = 15;
                snakePiece[i].Top = 0;
                snakePiece[i].Left = i * 16;
                snakePiece[i].BackColor = Color.Aqua;
                gameScreen.Controls.Add(snakePiece[i]);
            }

            snakeHead = snakePiece.Length - 1;
        }

        private void DeleteSnake()
        {
            for (int i = 0; i < snakePiece.Length; i++)
            {
                gameScreen.Controls.Remove(snakePiece[i]);
            }
        }

        private void addNewPiece()
        {
            Array.Resize(ref snakePiece, snakePiece.Length + 1);
            snakePiece[snakePiece.Length - 1] = new PictureBox();
            snakePiece[snakePiece.Length - 1].Width = 15;
            snakePiece[snakePiece.Length - 1].Height = 15;
            snakePiece[snakePiece.Length - 1].Top = -20;
            snakePiece[snakePiece.Length - 1].Left = -20;
            snakePiece[snakePiece.Length - 1].BackColor = Color.Aqua;
            gameScreen.Controls.Add(snakePiece[snakePiece.Length - 1]);
        }

        private void SnakeMoveEvent()
        {
            for (int i = 0; i < snakePiece.Length; i++)
            {
                float farkX = Math.Abs(snakePiece[snakeHead].Left - snakePiece[i].Left);
                float farkY = Math.Abs(snakePiece[snakeHead].Top - snakePiece[i].Top);

                if ((farkX < 15) && (farkY < 15) && i != snakeHead)
                {
                    SnakeCrashed = true;
                    break;
                }
            }

            if (snakePiece[snakeHead].Left >= gameScreen.Width - snakePiece[snakeHead].Width)
            { snakePiece[snakeHead].Left = 0; }

            else if (snakePiece[snakeHead].Top >= gameScreen.Height - snakePiece[snakeHead].Height)
            { snakePiece[snakeHead].Top = 0; }

            else if (snakePiece[snakeHead].Top <= -1)
            { snakePiece[snakeHead].Top = gameScreen.Height; }

            else if (snakePiece[snakeHead].Left <= -1)
            { snakePiece[snakeHead].Left = gameScreen.Width; }

            if (SnakeCrashed)
            {
                gameCase = false;
                timer.Enabled = false;
                MessageBox.Show("WASTED !!!. \nScore : " + score.ToString());
            }
        }

        private void SnakeMove(int top, int left)
        {
            snakePiece[trail].Left = snakePiece[snakeHead].Left + left;
            snakePiece[trail].Top = snakePiece[snakeHead].Top + top;

            if (trail == snakePiece.Length - 1)
            {
                trail = 0;
                snakeHead = snakePiece.Length - 1;
            }
            else
            {
                trail++;
                snakeHead = trail - 1;
            }
        }

        Random rnd = new Random();
        PictureBox food;
        int score = 0;

        private void CreateFood()
        {
            int rastgeleX = rnd.Next(30, 700);
            int rastgeleY = rnd.Next(30, 580);

            rastgeleX = rastgeleX - (rastgeleX % 16);
            rastgeleY = rastgeleY - (rastgeleY % 16);

            food = new PictureBox();
            food.Width = 15;
            food.Height = 15;
            food.BackColor = Color.Red;
            food.Location = new Point(rastgeleX, rastgeleY);
            gameScreen.Controls.Add(food);
        }

        private void SnakeEatFood()
        {
            float farkX = Math.Abs(snakePiece[snakeHead].Left - food.Left);
            float farkY = Math.Abs(snakePiece[snakeHead].Top - food.Top);

            if ((15 > farkX) && (15 > farkY))
            {
                gameScreen.Controls.Remove(food);

                addNewPiece();
                score += 10;
                labelScore.Text = "Score : " + score.ToString();
                CreateFood();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameCase)
            {
                if (e.KeyCode == Keys.Right && previousCommand != 'L')
                {
                    leftMove = 0; topMove = 0;
                    leftMove = 16;
                    previousCommand = 'R';
                }
                else if (e.KeyCode == Keys.Left && previousCommand != 'R')
                {
                    leftMove = 0; topMove = 0;
                    leftMove = -16;
                    previousCommand = 'L';
                }
                else if (e.KeyCode == Keys.Up && previousCommand != 'D')
                {
                    leftMove = 0; topMove = 0;
                    topMove = -16;
                    previousCommand = 'U';
                }
                else if (e.KeyCode == Keys.Down && previousCommand != 'U')
                {
                    leftMove = 0; topMove = 0;
                    topMove = 16;
                    previousCommand = 'D';
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelScore.Text = "Score : 0";
            previousCommand = 'R';
            score = 0;
            
            timer.Enabled = true;
            SnakeCrashed = false;
            gameCase = true;

            leftMove = 16;
            trail = 0;
            topMove = 0;

            DeleteSnake();
            newPiece();
            CreateFood();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (gameCase)
            {
                SnakeMove(topMove, leftMove);
                SnakeMoveEvent();
                SnakeEatFood();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
       
    }
}
