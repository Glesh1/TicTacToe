using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            bool win = false;
            string inputString;
            int input;
            string[,] matrix2D =
            {
            {"1", "2", "3"},
            {"4", "5", "6"},
            {"7", "8", "9"}
            };

            int counter = -1;
            int[] numTakenArray = new int[9];
            int[] numArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };


            do
            {


                //draw matrix and grid
                for (int i = 0; i < matrix2D.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix2D.GetLength(1); j++)
                    {
                        Console.Write(" " + matrix2D[i, j] + " ");
                        if (j < (matrix2D.GetLength(1) - 1)) { Console.Write("|"); };
                    }
                    if (i < (matrix2D.GetLength(1) - 1)) { Console.WriteLine("\n-----------"); }

                }
                //decide whos next, receive input
                counter++;
                if (counter == 9) { Console.WriteLine("\n\nGAME OVER"); Console.ReadLine(); break; }
                if (counter % 2 == 0) { Console.Write("\n\nPlayer1 chooses: "); }
                else { Console.Write("\n\nPlayer2 chooses:"); }
                inputString = Console.ReadLine();



                if (int.TryParse(inputString, out input))
                {
                    // detect number already taken
                    //if (numTakenArray.Contains(input)){ }

                    numTakenArray[counter] = input;
                    // check input and replace array value with X/O depending on PlayerNum & counter
                    for (int i = 0; i < matrix2D.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix2D.GetLength(1); j++)
                        {
                            if (matrix2D[i, j] == inputString)
                            {
                                if (counter % 2 == 0) { matrix2D[i, j] = "X"; }
                                else { matrix2D[i, j] = "O"; }
                                //check if anyone has won

                                //diagonal win
                                if (matrix2D[0, 2] == "X" && matrix2D[1, 1] == "X" && matrix2D[2, 0] == "X") { Console.WriteLine("Player1 wins!"); Console.ReadLine(); win = true; break; }
                                if (matrix2D[0, 2] == "O" && matrix2D[1, 1] == "O" && matrix2D[2, 0] == "O") { Console.WriteLine("Player2 wins!"); Console.ReadLine(); win = true; break; }
                                //other diagonal win
                                if (matrix2D[0, 0] == "X" && matrix2D[1, 1] == "X" && matrix2D[2, 2] == "X") { Console.WriteLine("Player1 wins!"); Console.ReadLine(); win = true; break; }
                                if (matrix2D[0, 0] == "O" && matrix2D[1, 1] == "O" && matrix2D[2, 2] == "O") { Console.WriteLine("Player2 wins!"); Console.ReadLine(); win = true; break; }
                                //horizontal win
                                if (matrix2D[0, 0] == "X" && matrix2D[0, 1] == "X" && matrix2D[0, 2] == "X") { Console.WriteLine("Player1 wins!"); Console.ReadLine(); win = true; break; }
                                if (matrix2D[0, 0] == "O" && matrix2D[0, 1] == "O" && matrix2D[0, 2] == "O") { Console.WriteLine("Player2 wins!"); Console.ReadLine(); win = true; break; }
                                if (matrix2D[1, 0] == "X" && matrix2D[1, 1] == "X" && matrix2D[1, 2] == "X") { Console.WriteLine("Player1 wins!"); Console.ReadLine(); win = true; break; }
                                if (matrix2D[1, 0] == "O" && matrix2D[1, 1] == "O" && matrix2D[1, 2] == "O") { Console.WriteLine("Player2 wins!"); Console.ReadLine(); win = true; break; }
                                if (matrix2D[2, 0] == "X" && matrix2D[2, 1] == "X" && matrix2D[2, 2] == "X") { Console.WriteLine("Player1 wins!"); Console.ReadLine(); win = true; break; }
                                if (matrix2D[2, 0] == "O" && matrix2D[2, 1] == "O" && matrix2D[2, 2] == "O") { Console.WriteLine("Player2 wins!"); Console.ReadLine(); win = true; break; }

                                //vertical win
                                if (matrix2D[0, 0] == "X" && matrix2D[1, 0] == "X" && matrix2D[2, 0] == "X") { Console.WriteLine("Player1 wins!"); Console.ReadLine(); win = true; break; }
                                if (matrix2D[0, 0] == "O" && matrix2D[1, 0] == "O" && matrix2D[2, 0] == "O") { Console.WriteLine("Player2 wins!"); Console.ReadLine(); win = true; break; }
                                if (matrix2D[0, 1] == "X" && matrix2D[1, 1] == "X" && matrix2D[2, 1] == "X") { Console.WriteLine("Player1 wins!"); Console.ReadLine(); win = true; break; }
                                if (matrix2D[0, 1] == "O" && matrix2D[1, 1] == "O" && matrix2D[2, 1] == "O") { Console.WriteLine("Player2 wins!"); Console.ReadLine(); win = true; break; }
                                if (matrix2D[0, 2] == "X" && matrix2D[1, 2] == "X" && matrix2D[2, 2] == "X") { Console.WriteLine("Player1 wins!"); Console.ReadLine(); win = true; break; }
                                if (matrix2D[0, 2] == "O" && matrix2D[1, 2] == "O" && matrix2D[2, 2] == "O") { Console.WriteLine("Player2 wins!"); Console.ReadLine(); win = true; break; }
                            }
                            else { continue; }
                        }


                    }
                }
                else { Console.WriteLine("Invalid enrty."); Console.ReadLine(); Console.Clear(); counter--; continue; }
                
                
                Console.WriteLine("Debug (counter): "+counter); Console.ReadLine(); Console.Clear();


            } while (!win);


            Console.ReadLine();
        }

    }
}
