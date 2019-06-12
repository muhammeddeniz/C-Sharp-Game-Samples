using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Convert;

namespace othelloGame
{
    class Program
    {
        public static void yellow()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        public static void cyan()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        public static void white()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Main(string[] args)
        {

            char[,] mainArray = new char[8, 8];
            int number1, number2, counter = 0, counter2 = 0;
            string answer;
            int allBlackPiece = 0, allWhitePiece = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    mainArray[i, j] = '_';
                }
            }

            mainArray[3, 3] = 'B';
            mainArray[3, 4] = 'W';
            mainArray[4, 3] = 'W';
            mainArray[4, 4] = 'B';


            cyan();
            Console.WriteLine("***************************** OTHELLO GAME *****************************");
            yellow();
            Console.WriteLine("0 1 2 3 4 5 6 7");
            white();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(mainArray[i, j]);
                    Console.Write(" ");
                }
                yellow();
                Console.Write(i);
                white();
                Console.WriteLine();
            }


            Console.WriteLine("Do you want to see the game rools?");
            answer = Console.ReadLine();

            answer.ToUpper();
            bool answer1 = answer.Contains("yes");
            bool answer2 = answer.StartsWith("y");

            if (answer1 == true || answer2 == true)
            {
                Console.WriteLine("******************************************************************************");
                Console.WriteLine("* 1- The First Player is White Piece.                                        *");
                Console.WriteLine("* 2- If You put The Piece In Empty Place You Are Lose.                       *");
                Console.WriteLine("* 3-if you don't put the new piece next the other piece's side you are lose. *");
                Console.WriteLine("******************************************************************************");
            }

            while (counter <= 100)
            {

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (mainArray[i, j] != '_')
                            counter2++;
                    }
                }

                if (counter2 == 64)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (mainArray[i, j] == 'B')
                                allBlackPiece++;

                            if (mainArray[i, j] == 'W')
                                allWhitePiece++;
                        }
                    }
                }

                int ItemCounter = 0;

                foreach (var item in mainArray)
                {
                    if (item != '_')
                        ItemCounter++;                 
                }

                if (allBlackPiece > allWhitePiece && ItemCounter==64)
                {
                    Console.WriteLine("BLACK PİECE WİN THE GAME");
                }
                else if(allBlackPiece > allWhitePiece && ItemCounter == 64)
                {
                    Console.WriteLine("WHİTE PİECE WİN THE GAME");
                }

                Console.Write("X Side: ");
                number1 = ToInt32(ReadLine());
                Console.Write("Y Side: ");
                number2 = ToInt32(ReadLine());

                if (counter % 2 == 0)
                {
                    mainArray[number1, number2] = 'W';
                }
                else if (counter % 2 == 1)
                {
                    mainArray[number1, number2] = 'B';
                }

                counter++;

                if (number1 - 2 >= 0 && mainArray[number1 - 2, number2] == mainArray[number1, number2] && mainArray[number1 - 1, number2] != mainArray[number1, number2] && mainArray[number1 - 1, number2] != '_')
                {
                    mainArray[number1 - 1, number2] = mainArray[number1, number2];
                }
                if (number2 - 2 >= 0 && mainArray[number1, number2 - 2] == mainArray[number1, number2] && mainArray[number1, number2 - 1] != mainArray[number1, number2] && mainArray[number1, number2 - 1] != '_')
                {
                    mainArray[number1, number2 - 1] = mainArray[number1, number2];
                }
                if (number1 - 2 >= 0 && number2 - 2 >= 0 && mainArray[number1 - 2, number2 - 2] == mainArray[number1, number2] && mainArray[number1 - 1, number2 - 1] != mainArray[number1, number2] && mainArray[number1 - 1, number2 - 1] != '_')
                {
                    mainArray[number1 - 1, number2 - 1] = mainArray[number1, number2];
                }
                if (number1 - 3 >= 0 && mainArray[number1 - 3, number2] == mainArray[number1, number2] && mainArray[number1 - 1, number2] != mainArray[number1, number2] && mainArray[number1 - 2, number2] != mainArray[number1, number2] && mainArray[number1 - 1, number2] != '_' && mainArray[number1 - 2, number2] != '_')
                {
                    mainArray[number1 - 1, number2] = mainArray[number1, number2];
                    mainArray[number1 - 2, number2] = mainArray[number1, number2];
                }
                if (number2 - 3 >= 0 && mainArray[number1, number2 - 3] == mainArray[number1, number2] && mainArray[number1, number2 - 1] != mainArray[number1, number2] && mainArray[number1, number2 - 2] != mainArray[number1, number2] && mainArray[number1, number2 - 1] != '_' && mainArray[number1, number2 - 2] != '_')
                {
                    mainArray[number1, number2 - 1] = mainArray[number1, number2];
                    mainArray[number1, number2 - 2] = mainArray[number1, number2];
                }
                if (number1 - 3 >= 0 && number2 - 3 >= 0 && mainArray[number1 - 3, number2 - 3] == mainArray[number1, number2] && mainArray[number1 - 1, number2 - 1] != mainArray[number1, number2] && mainArray[number1 - 1, number2 - 1] != '_' && mainArray[number1 - 2, number2 - 2] != mainArray[number1, number2] && mainArray[number1 - 2, number2 - 2] != '_')
                {
                    mainArray[number1 - 1, number2 - 1] = mainArray[number1, number2];
                    mainArray[number1 - 2, number2 - 2] = mainArray[number1, number2];
                }
                if (number1 - 4 >= 0 && mainArray[number1 - 4, number2] == mainArray[number1, number2] && mainArray[number1 - 1, number2] != mainArray[number1, number2] && mainArray[number1 - 2, number2] != mainArray[number1, number2] && mainArray[number1 - 1, number2] != '_' && mainArray[number1 - 2, number2] != '_')
                {
                    mainArray[number1 - 1, number2] = mainArray[number1, number2];
                    mainArray[number1 - 2, number2] = mainArray[number1, number2];
                    mainArray[number1 - 3, number2] = mainArray[number1, number2];
                }
                if (number2 - 4 >= 0 && mainArray[number1, number2 - 4] == mainArray[number1, number2] && mainArray[number1, number2 - 1] != mainArray[number1, number2] && mainArray[number1, number2 - 2] != mainArray[number1, number2] && mainArray[number1, number2 - 1] != '_' && mainArray[number1, number2 - 2] != '_')
                {
                    mainArray[number1, number2 - 1] = mainArray[number1, number2];
                    mainArray[number1, number2 - 2] = mainArray[number1, number2];
                    mainArray[number1, number2 - 3] = mainArray[number1, number2];
                }
                if (number1 - 4 >= 0 && number2 - 4 >= 0 && mainArray[number1 - 4, number2 - 4] == mainArray[number1, number2] && mainArray[number1 - 1, number2 - 1] != mainArray[number1, number2] && mainArray[number1 - 1, number2 - 1] != '_' && mainArray[number1 - 2, number2 - 2] != mainArray[number1, number2] && mainArray[number1 - 2, number2 - 2] != '_')
                {
                    mainArray[number1 - 1, number2 - 1] = mainArray[number1, number2];
                    mainArray[number1 - 2, number2 - 2] = mainArray[number1, number2];
                    mainArray[number1 - 3, number2 - 3] = mainArray[number1, number2];
                }
                if (number1 - 5 >= 0 && mainArray[number1 - 5, number2] == mainArray[number1, number2] && mainArray[number1 - 1, number2] != mainArray[number1, number2] && mainArray[number1 - 2, number2] != mainArray[number1, number2] && mainArray[number1 - 1, number2] != '_' && mainArray[number1 - 2, number2] != '_')
                {
                    mainArray[number1 - 1, number2] = mainArray[number1, number2];
                    mainArray[number1 - 2, number2] = mainArray[number1, number2];
                    mainArray[number1 - 3, number2] = mainArray[number1, number2];
                    mainArray[number1 - 4, number2] = mainArray[number1, number2];
                }
                if (number2 - 5 >= 0 && mainArray[number1, number2 - 5] == mainArray[number1, number2] && mainArray[number1, number2 - 1] != mainArray[number1, number2] && mainArray[number1, number2 - 2] != mainArray[number1, number2] && mainArray[number1, number2 - 1] != '_' && mainArray[number1, number2 - 2] != '_')
                {
                    mainArray[number1, number2 - 1] = mainArray[number1, number2];
                    mainArray[number1, number2 - 2] = mainArray[number1, number2];
                    mainArray[number1, number2 - 3] = mainArray[number1, number2];
                    mainArray[number1, number2 - 4] = mainArray[number1, number2];
                }
                if (number1 - 5 >= 0 && number2 - 5 >= 0 && mainArray[number1 - 5, number2 - 5] == mainArray[number1, number2] && mainArray[number1 - 1, number2 - 1] != mainArray[number1, number2] && mainArray[number1 - 1, number2 - 1] != '_' && mainArray[number1 - 2, number2 - 2] != mainArray[number1, number2] && mainArray[number1 - 2, number2 - 2] != '_')
                {
                    mainArray[number1 - 1, number2 - 1] = mainArray[number1, number2];
                    mainArray[number1 - 2, number2 - 2] = mainArray[number1, number2];
                    mainArray[number1 - 3, number2 - 3] = mainArray[number1, number2];
                    mainArray[number1 - 4, number2 - 4] = mainArray[number1, number2];
                }
                if (number1 + 2 <= 7 && mainArray[number1 + 2, number2] == mainArray[number1, number2] && mainArray[number1 + 1, number2] != mainArray[number1, number2] && mainArray[number1 + 1, number2] != '_')
                {
                    mainArray[number1 + 1, number2] = mainArray[number1, number2];
                }
                if (number2 + 2 <= 7 && mainArray[number1, number2 + 2] == mainArray[number1, number2] && mainArray[number1, number2 + 1] != mainArray[number1, number2] && mainArray[number1, number2 + 1] != '_')
                {
                    mainArray[number1, number2 + 1] = mainArray[number1, number2];
                }
                if (number1 + 2 <= 7 && number2 + 2 <= 7 && mainArray[number1 + 2, number2 + 2] == mainArray[number1, number2] && mainArray[number1 + 1, number2 + 1] != mainArray[number1, number2] && mainArray[number1 + 1, number2 + 1] != '_')
                {
                    mainArray[number1 + 1, number2 + 1] = mainArray[number1, number2];
                }
                if (number1 + 3 <= 7 && mainArray[number1 + 3, number2] == mainArray[number1, number2] && mainArray[number1 + 1, number2] != mainArray[number1, number2] && mainArray[number1 + 2, number2] != mainArray[number1, number2] && mainArray[number1 + 1, number2] != '_' && mainArray[number1 + 2, number2] != '_')
                {
                    mainArray[number1 + 1, number2] = mainArray[number1, number2];
                    mainArray[number1 + 2, number2] = mainArray[number1, number2];
                }
                if (number2 + 3 <= 7 && mainArray[number1, number2 + 3] == mainArray[number1, number2] && mainArray[number1, number2 + 1] != mainArray[number1, number2] && mainArray[number1, number2 + 2] != mainArray[number1, number2] && mainArray[number1, number2 + 1] != '_' && mainArray[number1, number2 + 2] != '_')
                {
                    mainArray[number1, number2 + 1] = mainArray[number1, number2];
                    mainArray[number1, number2 + 2] = mainArray[number1, number2];
                }
                if (number1 + 3 <= 7 && number2 + 3 <= 7 && mainArray[number1 + 3, number2 + 3] == mainArray[number1, number2] && mainArray[number1 + 1, number2 + 1] != mainArray[number1, number2] && mainArray[number1 + 1, number2 + 1] != '_' && mainArray[number1 + 2, number2 + 2] != mainArray[number1, number2] && mainArray[number1 + 2, number2 + 2] != '_')
                {
                    mainArray[number1 + 1, number2 + 1] = mainArray[number1, number2];
                    mainArray[number1 + 2, number2 + 2] = mainArray[number1, number2];
                }
                if (number1 + 4 <= 7 && mainArray[number1 + 4, number2] == mainArray[number1, number2] && mainArray[number1 + 1, number2] != mainArray[number1, number2] && mainArray[number1 + 2, number2] != mainArray[number1, number2] && mainArray[number1 + 1, number2] != '_' && mainArray[number1 + 2, number2] != '_' && mainArray[number1 + 3, number2] != mainArray[number1, number2] && mainArray[number1 + 3, number2] != '_')
                {
                    mainArray[number1 + 1, number2] = mainArray[number1, number2];
                    mainArray[number1 + 2, number2] = mainArray[number1, number2];
                    mainArray[number1 + 3, number2] = mainArray[number1, number2];
                }
                if (number2 + 4 <= 7 && mainArray[number1, number2 + 4] == mainArray[number1, number2] && mainArray[number1, number2 + 1] != mainArray[number1, number2] && mainArray[number1, number2 + 2] != mainArray[number1, number2] && mainArray[number1, number2 + 1] != '_' && mainArray[number1, number2 + 2] != '_' && mainArray[number1, number2 + 3] != mainArray[number1, number2] && mainArray[number1, number2 + 3] != '_')
                {
                    mainArray[number1, number2 + 1] = mainArray[number1, number2];
                    mainArray[number1, number2 + 2] = mainArray[number1, number2];
                    mainArray[number1, number2 + 3] = mainArray[number1, number2];
                }
                if (number1 + 4 <= 7 && number2 + 4 <= 7 && mainArray[number1 + 4, number2 + 4] == mainArray[number1, number2] && mainArray[number1 + 1, number2 + 1] != mainArray[number1, number2] && mainArray[number1 + 2, number2 + 2] != mainArray[number1, number2] && mainArray[number1 + 1, number2 + 1] != '_' && mainArray[number1 + 2, number2 + 2] != '_' && mainArray[number1 + 3, number2 + 3] != mainArray[number1, number2] && mainArray[number1 + 3, number2 + 3] != '_')
                {
                    mainArray[number1 + 1, number2 + 1] = mainArray[number1, number2];
                    mainArray[number1 + 2, number2 + 2] = mainArray[number1, number2];
                    mainArray[number1 + 3, number2 + 3] = mainArray[number1, number2];
                }
                if (number1 + 5 <= 7 && mainArray[number1 + 5, number2] == mainArray[number1, number2] && mainArray[number1 + 1, number2] != mainArray[number1, number2] && mainArray[number1 + 2, number2] != mainArray[number1, number2] && mainArray[number1 + 1, number2] != '_' && mainArray[number1 + 2, number2] != '_' && mainArray[number1 + 3, number2] != mainArray[number1, number2] && mainArray[number1 + 3, number2] != '_')
                {
                    mainArray[number1 + 1, number2] = mainArray[number1, number2];
                    mainArray[number1 + 2, number2] = mainArray[number1, number2];
                    mainArray[number1 + 3, number2] = mainArray[number1, number2];
                    mainArray[number1 + 4, number2] = mainArray[number1, number2];
                }
                if (number2 + 5 <= 7 && mainArray[number1, number2 + 5] == mainArray[number1, number2] && mainArray[number1, number2 + 1] != mainArray[number1, number2] && mainArray[number1, number2 + 2] != mainArray[number1, number2] && mainArray[number1, number2 + 1] != '_' && mainArray[number1, number2 + 2] != '_' && mainArray[number1, number2 + 3] != mainArray[number1, number2] && mainArray[number1, number2 + 3] != '_')
                {
                    mainArray[number1, number2 + 1] = mainArray[number1, number2];
                    mainArray[number1, number2 + 2] = mainArray[number1, number2];
                    mainArray[number1, number2 + 3] = mainArray[number1, number2];
                    mainArray[number1, number2 + 4] = mainArray[number1, number2];
                }
                if (number1 + 5 <= 7 && number2 + 5 <= 7 && mainArray[number1 + 5, number2 + 5] == mainArray[number1, number2] && mainArray[number1 + 1, number2 + 1] != mainArray[number1, number2] && mainArray[number1 + 2, number2 + 2] != mainArray[number1, number2] && mainArray[number1 + 1, number2 + 1] != '_' && mainArray[number1 + 2, number2 + 2] != '_' && mainArray[number1 + 3, number2 + 3] != mainArray[number1, number2] && mainArray[number1 + 3, number2 + 3] != '_')
                {
                    mainArray[number1 + 1, number2 + 1] = mainArray[number1, number2];
                    mainArray[number1 + 2, number2 + 2] = mainArray[number1, number2];
                    mainArray[number1 + 3, number2 + 3] = mainArray[number1, number2];
                    mainArray[number1 + 4, number2 + 4] = mainArray[number1, number2];
                }

                if (number1 + 2 <= 7 && number2 - 2 >= 0 && mainArray[number1 + 2, number2 - 2] == mainArray[number1, number2] && mainArray[number1 + 1, number2 - 1] != mainArray[number1, number2] && mainArray[number1 + 1, number2 - 1] != '_')
                {
                    mainArray[number1 + 1, number2 - 1] = mainArray[number1, number2];
                }

                if (number1 - 2 >= 0 && number2 + 2 <= 7 && mainArray[number1 - 2, number2 + 2] == mainArray[number1, number2] && mainArray[number1 - 1, number2 + 1] != mainArray[number1, number2] && mainArray[number1 - 1, number2 + 1] != '_')
                {
                    mainArray[number1 - 1, number2 + 1] = mainArray[number1, number2];
                }

                if (number1 + 3 <= 7 && number2 - 3 >= 0 && mainArray[number1 + 3, number2 - 3] == mainArray[number1, number2] && mainArray[number1 + 1, number2 - 1] != mainArray[number1, number2] && mainArray[number1 + 1, number2 - 1] != '_' && mainArray[number1 + 2, number2 - 2] != mainArray[number1, number2] && mainArray[number1 + 2, number2 - 2] != '_')
                {
                    if (mainArray[number1 + 2, number2 - 2] != mainArray[number1, number2] && mainArray[number1 + 2, number2 - 2] != '_')
                    {
                        mainArray[number1 + 1, number2 - 1] = mainArray[number1, number2];
                        mainArray[number1 + 2, number2 - 2] = mainArray[number1, number2];
                    }
                }

                if (number1 - 3 >= 0 && number2 + 3 <= 7 && mainArray[number1 - 3, number2 + 3] == mainArray[number1, number2] && mainArray[number1 - 1, number2 + 1] != mainArray[number1, number2] && mainArray[number1 - 1, number2 + 1] != '_' && mainArray[number1 - 2, number2 + 2] != mainArray[number1, number2] && mainArray[number1 - 2, number2 + 2] != '_')
                {
                    if (mainArray[number1 - 2, number2 + 2] != mainArray[number1, number2] && mainArray[number1 - 2, number2 + 2] != '_')
                    {
                        mainArray[number1, number2] = mainArray[number1, number2];
                        mainArray[number1 - 1, number2 + 1] = mainArray[number1, number2];
                        mainArray[number1 - 2, number2 + 2] = mainArray[number1, number2];
                    }
                }

                if (number1 + 4 <= 7 && number2 - 4 >= 0 && mainArray[number1 + 4, number2 - 4] == mainArray[number1, number2] && mainArray[number1 + 1, number2 - 1] != mainArray[number1, number2] && mainArray[number1 + 1, number2 - 1] != '_' && mainArray[number1 + 2, number2 - 2] != mainArray[number1, number2] && mainArray[number1 + 2, number2 - 2] != '_' && mainArray[number1 + 3, number2 - 3] != mainArray[number1, number2] && mainArray[number1 + 3, number2 - 3] != '_')
                {
                    mainArray[number1 + 1, number2 - 1] = mainArray[number1, number2];
                    mainArray[number1 + 2, number2 - 2] = mainArray[number1, number2];
                    mainArray[number1 + 3, number2 - 3] = mainArray[number1, number2];
                }

                if (number1 - 4 >= 0 && number2 + 4 <= 7 && mainArray[number1 - 4, number2 + 4] == mainArray[number1, number2] && mainArray[number1 - 1, number2 + 1] != mainArray[number1, number2] && mainArray[number1 - 1, number2 + 1] != '_' && mainArray[number1 - 2, number2 + 2] != mainArray[number1, number2] && mainArray[number1 - 2, number2 + 2] != '_' && mainArray[number1 - 3, number2 + 3] != mainArray[number1, number2] && mainArray[number1 - 3, number2 + 3] != '_')
                {
                    mainArray[number1 - 1, number2 + 1] = mainArray[number1, number2];
                    mainArray[number1 - 2, number2 + 2] = mainArray[number1, number2];
                    mainArray[number1 - 3, number2 + 3] = mainArray[number1, number2];
                }

                if (number1 + 5 <= 7 && number2 - 5 >= 0 && mainArray[number1 + 5, number2 - 5] == mainArray[number1, number2] && mainArray[number1 + 1, number2 - 1] != mainArray[number1, number2] && mainArray[number1 + 1, number2 - 1] != '_' && mainArray[number1 + 2, number2 - 2] != mainArray[number1, number2] && mainArray[number1 + 2, number2 - 2] != '_' && mainArray[number1 + 3, number2 - 3] != mainArray[number1, number2] && mainArray[number1 + 3, number2 - 3] != '_' && mainArray[number1 + 4, number2 - 4] != mainArray[number1, number2] && mainArray[number1 + 4, number2 - 4] != '_')
                {
                    mainArray[number1 + 1, number2 - 1] = mainArray[number1, number2];
                    mainArray[number1 + 2, number2 - 2] = mainArray[number1, number2];
                    mainArray[number1 + 3, number2 - 3] = mainArray[number1, number2];
                    mainArray[number1 + 4, number2 - 4] = mainArray[number1, number2];
                }

                if (number1 - 5 >= 0 && number2 + 5 <= 7 && mainArray[number1 - 5, number2 + 5] == mainArray[number1, number2] && mainArray[number1 - 1, number2 + 1] != mainArray[number1, number2] && mainArray[number1 - 1, number2 + 1] != '_' && mainArray[number1 - 2, number2 + 2] != mainArray[number1, number2] && mainArray[number1 - 2, number2 + 2] != '_' && mainArray[number1 - 3, number2 + 3] != mainArray[number1, number2] && mainArray[number1 - 3, number2 + 3] != '_' && mainArray[number1 - 4, number2 + 4] != mainArray[number1, number2] && mainArray[number1 - 4, number2 + 4] != '_')
                {
                    mainArray[number1 - 1, number2 + 1] = mainArray[number1, number2];
                    mainArray[number1 - 2, number2 + 2] = mainArray[number1, number2];
                    mainArray[number1 - 3, number2 + 3] = mainArray[number1, number2];
                    mainArray[number1 - 4, number2 + 4] = mainArray[number1, number2];
                }


                Console.Clear();
                cyan();
                Console.WriteLine("***************************** OTHELLO GAME *****************************");
                yellow();
                Console.WriteLine("0 1 2 3 4 5 6 7");
                white();
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        Console.Write(mainArray[i, j]);
                        Console.Write(" ");
                    }
                    yellow();
                    Console.Write(i);
                    white();
                    Console.WriteLine();
                }


            }
        }
    }
}
