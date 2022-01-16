using System;

namespace TicTacToe
{
    internal class Program
    {
        public static bool win = false;
        public static string inputString;
        public static int input;
        public static int counter = -1;
        public static int n;
        public static string char1;
        public static string char2;
        private static int inARowWins = 5;
        private static string rowWins;

        private static void Main(string[] args)
        {
            Initialize();
            Console.Clear();
            string[,] matrix2D = new string[n, n];
            Enumerate(matrix2D);

            do
            {
                DrawGrid(matrix2D, inARowWins);
                GetInput(matrix2D, char1, char2);
                /*Console.WriteLine("Debug (counter): " + counter); Console.ReadLine();*/
                win = CheckForWinner(matrix2D, inARowWins);
                if (!win) { Console.Clear(); }
            } while (!win);

            Console.ReadLine();
        }

        private static void Initialize()
        {
            // choose size of the table (n x n) and player chars
            do
            {
                Console.Write("Please choose the size of the table! \n(The entered number (n) draws a n*n grid.\n" +
                 "E.g. 3-> 3*3, 4-> 4*4, etc.)\nEnter number: ");
                n = Convert.ToInt32(Console.ReadLine());
                Console.Write("Choose how many symbols you need to collect to win! (3/4/5 or leave empty for default settings):");
                rowWins = Console.ReadLine();

                if (rowWins == "" || rowWins == " ")
                {
                    if (n == 3 || n == 4) { inARowWins = 3; }
                    if (n == 5 || n == 6) { inARowWins = 4; }
                }
                else { inARowWins = Convert.ToInt32(rowWins); }

                Console.Write("Player 1, please enter the character you would like to play with (default set to 'X'): ");
                string input1 = Console.ReadLine();
                bool isNum1 = int.TryParse(input1, out int res);
                if (input1 == "" || input1 == " " || isNum1) { char1 = "X"; } else { char1 = input1; }
                Console.Write("Player 2, please enter the character you would like to play with (default set to 'O'): ");
                string input2 = Console.ReadLine();
                bool isNum2 = int.TryParse(input2, out int res2);
                if (input2 == "" || input2 == " " || isNum2) { char2 = "O"; } else { char2 = input2; }

                if (n < 3 || n > 9) { Console.WriteLine("Please choose a table size between 3 and 9!"); Console.ReadLine(); Console.Clear(); }
                if (inARowWins > n /*|| inARowWins > 5*/ || inARowWins < 3) { Console.WriteLine("\n\nIvalid settings, please try again!"); Console.ReadLine(); Console.Clear(); }
            } while (n < 3 || n > 9 || inARowWins > n /*|| inARowWins > 5*/ || inARowWins < 3);
        }

        public static void Enumerate(string[,] matrix2D)
        {
            int printCount = 0;
            //enumerate matrix
            for (int i = 0; i < matrix2D.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2D.GetLength(1); j++)
                {
                    printCount++;
                    matrix2D[i, j] = Convert.ToString(printCount);
                }
            }
        }

        public static void DrawGrid(string[,] matrix2D, int inARowWins)
        {
            Console.WriteLine("The first to have " + inARowWins + " in a row wins! \n");
            //draw matrix and grid
            for (int i = 0; i < matrix2D.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2D.GetLength(1); j++)
                {
                    //if char printed is X/O change color
                    if (matrix2D[i, j] == char1) { Console.ForegroundColor = ConsoleColor.Cyan; }
                    else if (matrix2D[i, j] == char2) { Console.ForegroundColor = ConsoleColor.Yellow; }
                    //if string length is less than 2 add an extra space
                    if (matrix2D[i, j].Length < 2) { Console.Write("  " + matrix2D[i, j] + " "); }
                    else { Console.Write(" " + matrix2D[i, j] + " "); }
                    Console.ResetColor();
                    if (j < (matrix2D.GetLength(1) - 1)) { Console.Write("|"); };
                }

                if (i < (matrix2D.GetLength(1) - 1))
                {
                    Console.Write("\n");
                    for (int k = 0; k < matrix2D.GetLength(0); k++)
                    { Console.Write("-----"); }
                    Console.Write("\n");
                }
            }
        }

        public static void GetInput(string[,] matrix2D, string char1, string char2)
        {
            bool inputSucceded = false;
            do
            {
                //decide whos next, receive input

                counter++;

                if (counter == matrix2D.Length)
                {
                    Console.WriteLine("\n\nGAME OVER"); Console.ReadLine(); break;
                }

                if (counter % 2 == 0)
                {
                    Console.Write("\n\nPlayer1 chooses: ");
                }
                else
                {
                    Console.Write("\n\nPlayer2 chooses: ");
                }

                inputString = Console.ReadLine();

                if (int.TryParse(inputString, out input))
                {
                    // detect number already taken/out of range TBD
                    //if (numTakenArray.Contains(input)){ }
                    //numTakenArray[counter] = input;

                    // check input and replace array value with X/O depending on PlayerNum & counter
                    for (int i = 0; i < matrix2D.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix2D.GetLength(1); j++)
                        {
                            if (matrix2D[i, j] == inputString)
                            {
                                if (counter % 2 == 0)
                                {
                                    matrix2D[i, j] = char1; inputSucceded = true; break;
                                }
                                else
                                {
                                    matrix2D[i, j] = char2; inputSucceded = true; break;
                                }
                            }
                            else { continue; }
                        }
                    }
                    break;
                }
                else { Console.WriteLine("Invalid enrty."); Console.ReadLine(); Console.Clear(); counter--; continue; }
            } while (inputSucceded);
        }

        public static bool CheckForWinner(string[,] matrix2D, int inARowWins)
        {
            for (int i = 0; i < matrix2D.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2D.GetLength(1); j++)
                {
                    try
                    {   //if matrix item and next in row is equal check it with next in row,
                        //repeat for inARowWins times

                        //diagonal win /
                        for (int k = 1; k <= inARowWins;)
                        {
                            if (matrix2D[i, j] == matrix2D[i + k, j - k])
                            {
                                k++;

                                if (k == inARowWins)
                                {
                                    if (matrix2D[i, j] == char1)
                                    {
                                        Console.WriteLine("Player1 WINS(/)");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Player2 WINS(/)");
                                    }
                                    Console.ReadLine();
                                    return true;
                                }
                            }
                            else { break; }
                        }
                    }
                    catch (IndexOutOfRangeException)
                    { }

                    try
                    {   //if matrix item and next in row is equal check it with next in row,
                        //repeat for inARowWins times

                        //other diagonal win
                        for (int k = 1; k <= inARowWins;)
                        {
                            if (matrix2D[i, j] == matrix2D[i + k, j + k])
                            {
                                k++;

                                if (k == inARowWins)
                                {
                                    if (matrix2D[i, j] == char1)
                                    {
                                        Console.WriteLine("Player1 WINS(dia)");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Player2 WINS(dia)");
                                    }
                                    Console.ReadLine();
                                    return true;
                                }
                            }
                            else { break; }
                        }
                    }
                    catch (IndexOutOfRangeException)
                    { }

                    try
                    {   //if matrix item and next in row is equal check it with next in row,
                        //repeat for inARowWins times

                        //horizontal win
                        for (int k = 1; k <= inARowWins;)
                        {
                            if (matrix2D[i, j] == matrix2D[i, j + k])
                            {
                                k++;

                                if (k == inARowWins)
                                {
                                    if (matrix2D[i, j] == char1)
                                    {
                                        Console.WriteLine("Player1 WINS(-)");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Player2 WINS(-)");
                                    }
                                    Console.ReadLine();
                                    return true;
                                }
                            }
                            else { break; }
                        }
                    }
                    catch (IndexOutOfRangeException)
                    { }
                    try
                    {   //if matrix item and next in row is equal check it with next in row,
                        //repeat for inARowWins times

                        //vertical win
                        for (int k = 1; k <= inARowWins;)
                        {
                            if (matrix2D[i, j] == matrix2D[i + k, j])
                            {
                                k++;

                                if (k == inARowWins)
                                {
                                    if (matrix2D[i, j] == char1)
                                    {
                                        Console.WriteLine("Player1 WINS(|)");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Player2 WINS(|)");
                                    }
                                    Console.ReadLine();
                                    return true;
                                }
                            }
                            else { break; }
                        }
                    }
                    catch (IndexOutOfRangeException)
                    { }


                }
            }
            return false;
        }
    }
}