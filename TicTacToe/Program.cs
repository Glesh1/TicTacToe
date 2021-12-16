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

            // choosing the size of the table (n x n)
            Console.Write("Please choose the size of the table! \n(The entered number (n) draws a n*n grid.\n" +
                "E.g. 3-> 3*3, 4-> 4*4, etc.)\nEnter number: ");
            int n = Convert.ToInt32(Console.ReadLine()); //+ try catch TBD
            Console.Clear();
            string[,] matrix2D = new string[n, n];

            //enumerate matrix
            int printCount = 0;
            for (int i = 0; i < matrix2D.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2D.GetLength(1); j++)
                {
                    printCount++;
                    matrix2D[i, j] = Convert.ToString(printCount);
                }

            }


            int counter = -1;

            do
            {
                //draw matrix and grid
                for (int i = 0; i < matrix2D.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix2D.GetLength(1); j++)
                    {
                        //if stringlength is less than 2 add an extra space
                        if (matrix2D[i, j].Length < 2) { Console.Write("  " + matrix2D[i, j] + " "); }
                        else { Console.Write(" " + matrix2D[i, j] + " "); }
                        if (j < (matrix2D.GetLength(1) - 1)) { Console.Write("|"); };
                    }

                    if (i < (matrix2D.GetLength(1) - 1)) { Console.Write("\n"); for (int k = 0; k < matrix2D.GetLength(0); k++) { Console.Write("-----"); } Console.Write("\n"); }
                }




                //decide whos next, receive input
                counter++;
                if (counter == n * n) { Console.WriteLine("\n\nGAME OVER"); Console.ReadLine(); break; }
                if (counter % 2 == 0) { Console.Write("\n\nPlayer1 chooses: "); }
                else { Console.Write("\n\nPlayer2 chooses: "); }
                inputString = Console.ReadLine();



                if (int.TryParse(inputString, out input))
                {
                    // detect number already taken TBD
                    //if (numTakenArray.Contains(input)){ }
                    //numTakenArray[counter] = input;

                    // check input and replace array value with X/O depending on PlayerNum & counter
                    for (int i = 0; i < matrix2D.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix2D.GetLength(1); j++)
                        {
                            if (matrix2D[i, j] == inputString)
                            {
                                if (counter % 2 == 0) { matrix2D[i, j] = "X"; }
                                else { matrix2D[i, j] = "O"; }
                                //check if anyone has won //TBD

                                //diagonal win /
                                try
                                {
                                    if (matrix2D[i, j] == matrix2D[i + 1, j - 1] && matrix2D[i, j] == matrix2D[i + 2, j - 2])
                                    { if (matrix2D[i, j] == "X") { Console.WriteLine("Player1 WINS(/)"); } else { Console.WriteLine("Player2 WINS(/)"); } win = true; break; }
                                }
                                catch (IndexOutOfRangeException)
                                { }
                                try
                                {
                                    if (matrix2D[i, j] == matrix2D[i - 1, j + 1] && matrix2D[i, j] == matrix2D[i + 1, j - 1])
                                    { if (matrix2D[i, j] == "X") { Console.WriteLine("Player1 WINS(/)"); } else { Console.WriteLine("Player2 WINS(/)"); } win = true; break; }
                                }
                                catch (IndexOutOfRangeException)
                                { }
                                try
                                {
                                    if (matrix2D[i, j] == matrix2D[i - 1, j + 1] && matrix2D[i, j] == matrix2D[i - 2, j + 2])
                                    { if (matrix2D[i, j] == "X") { Console.WriteLine("Player1 WINS(/)"); } else { Console.WriteLine("Player2 WINS(/)"); } win = true; break; }
                                }
                                catch (IndexOutOfRangeException)
                                { }

                                /*if (matrix2D[0, 2] == "X" && matrix2D[1, 1] == "X" && matrix2D[2, 0] == "X") { Console.WriteLine("Player1 wins!"); Console.ReadLine(); win = true; break; }
                                if (matrix2D[0, 2] == "O" && matrix2D[1, 1] == "O" && matrix2D[2, 0] == "O") { Console.WriteLine("Player2 wins!"); Console.ReadLine(); win = true; break; }*/

                                //other diagonal win \
                                try
                                {
                                    if (matrix2D[i, j] == matrix2D[i + 1, j + 1] && matrix2D[i, j] == matrix2D[i + 2, j + 2])
                                    { if (matrix2D[i, j] == "X") { Console.WriteLine("Player1 WINS(dia)"); } else { Console.WriteLine("Player2 WINS(dia)"); } win = true; break; }
                                }
                                catch (IndexOutOfRangeException)
                                { }
                                try
                                {
                                    if (matrix2D[i, j] == matrix2D[i - 1, j - 1] && matrix2D[i, j] == matrix2D[i - 2, j - 2])
                                    { if (matrix2D[i, j] == "X") { Console.WriteLine("Player1 WINS(dia)"); } else { Console.WriteLine("Player2 WINS(dia)"); } win = true; break; }
                                }
                                catch (IndexOutOfRangeException)
                                { }
                                try
                                {
                                    if (matrix2D[i, j] == matrix2D[i - 1, j - 1] && matrix2D[i, j] == matrix2D[i + 1, j + 1])
                                    { if (matrix2D[i, j] == "X") { Console.WriteLine("Player1 WINS(dia)"); } else { Console.WriteLine("Player2 WINS(dia)"); } win = true; break; }
                                }
                                catch (IndexOutOfRangeException)
                                { }

                                /*if (matrix2D[0, 0] == "X" && matrix2D[1, 1] == "X" && matrix2D[2, 2] == "X") { Console.WriteLine("Player1 wins!"); Console.ReadLine(); win = true; break; }
                                if (matrix2D[0, 0] == "O" && matrix2D[1, 1] == "O" && matrix2D[2, 2] == "O") { Console.WriteLine("Player2 wins!"); Console.ReadLine(); win = true; break; }*/

                                //horizontal win
                                try
                                {
                                    if (matrix2D[i, j] == matrix2D[i, j + 1] && matrix2D[i, j] == matrix2D[i, j + 2])
                                    { if (matrix2D[i, j] == "X") { Console.WriteLine("Player1 WINS(-)"); } else { Console.WriteLine("Player2 WINS(-)"); } win = true; break; }
                                }
                                catch (IndexOutOfRangeException)
                                { }
                                try
                                {
                                    if (matrix2D[i, j] == matrix2D[i, j - 1] && matrix2D[i, j] == matrix2D[i, j - 2])
                                    { if (matrix2D[i, j] == "X") { Console.WriteLine("Player1 WINS(-)"); } else { Console.WriteLine("Player2 WINS(-)"); } win = true; break; }
                                }
                                catch (IndexOutOfRangeException)
                                { }
                                try
                                {
                                    if (matrix2D[i, j] == matrix2D[i, j - 1] && matrix2D[i, j] == matrix2D[i, j + 1])
                                    { if (matrix2D[i, j] == "X") { Console.WriteLine("Player1 WINS(-)"); } else { Console.WriteLine("Player2 WINS(-)"); } win = true; break; }
                                }
                                catch (IndexOutOfRangeException)
                                { }

                                /*if (matrix2D[0, 0] == "X" && matrix2D[0, 1] == "X" && matrix2D[0, 2] == "X") { Console.WriteLine("Player1 wins!"); Console.ReadLine(); win = true; break; }
                                if (matrix2D[0, 0] == "O" && matrix2D[0, 1] == "O" && matrix2D[0, 2] == "O") { Console.WriteLine("Player2 wins!"); Console.ReadLine(); win = true; break; }
                                if (matrix2D[1, 0] == "X" && matrix2D[1, 1] == "X" && matrix2D[1, 2] == "X") { Console.WriteLine("Player1 wins!"); Console.ReadLine(); win = true; break; }
                                if (matrix2D[1, 0] == "O" && matrix2D[1, 1] == "O" && matrix2D[1, 2] == "O") { Console.WriteLine("Player2 wins!"); Console.ReadLine(); win = true; break; }
                                if (matrix2D[2, 0] == "X" && matrix2D[2, 1] == "X" && matrix2D[2, 2] == "X") { Console.WriteLine("Player1 wins!"); Console.ReadLine(); win = true; break; }
                                if (matrix2D[2, 0] == "O" && matrix2D[2, 1] == "O" && matrix2D[2, 2] == "O") { Console.WriteLine("Player2 wins!"); Console.ReadLine(); win = true; break; }*/

                                //vertical win
                                try
                                {
                                    if (matrix2D[i, j] == matrix2D[i + 1, j] && matrix2D[i, j] == matrix2D[i + 2, j])
                                    { if (matrix2D[i, j] == "X") { Console.WriteLine("Player1 WINS(|)"); } else { Console.WriteLine("Player2 WINS(|)"); } win = true; break; }
                                }
                                catch (IndexOutOfRangeException)
                                { }
                                try
                                {
                                    if (matrix2D[i, j] == matrix2D[i - 1, j] && matrix2D[i, j] == matrix2D[i - 2, j])
                                    { if (matrix2D[i, j] == "X") { Console.WriteLine("Player1 WINS(|)"); } else { Console.WriteLine("Player2 WINS(|)"); } win = true; break; }
                                }
                                catch (IndexOutOfRangeException)
                                { }
                                try
                                {
                                    if (matrix2D[i, j] == matrix2D[i - 1, j] && matrix2D[i, j] == matrix2D[i + 1, j])
                                    { if (matrix2D[i, j] == "X") { Console.WriteLine("Player1 WINS(|)"); } else { Console.WriteLine("Player2 WINS(|)"); } win = true; break; }
                                }
                                catch (IndexOutOfRangeException)
                                { }


                                /*if (matrix2D[0, 0] == "X" && matrix2D[1, 0] == "X" && matrix2D[2, 0] == "X") { Console.WriteLine("Player1 wins!"); Console.ReadLine(); win = true; break; }
                                if (matrix2D[0, 0] == "O" && matrix2D[1, 0] == "O" && matrix2D[2, 0] == "O") { Console.WriteLine("Player2 wins!"); Console.ReadLine(); win = true; break; }
                                if (matrix2D[0, 1] == "X" && matrix2D[1, 1] == "X" && matrix2D[2, 1] == "X") { Console.WriteLine("Player1 wins!"); Console.ReadLine(); win = true; break; }
                                if (matrix2D[0, 1] == "O" && matrix2D[1, 1] == "O" && matrix2D[2, 1] == "O") { Console.WriteLine("Player2 wins!"); Console.ReadLine(); win = true; break; }
                                if (matrix2D[0, 2] == "X" && matrix2D[1, 2] == "X" && matrix2D[2, 2] == "X") { Console.WriteLine("Player1 wins!"); Console.ReadLine(); win = true; break; }
                                if (matrix2D[0, 2] == "O" && matrix2D[1, 2] == "O" && matrix2D[2, 2] == "O") { Console.WriteLine("Player2 wins!"); Console.ReadLine(); win = true; break; }*/
                            }
                            else { continue; }
                        }


                    }
                }
                else { Console.WriteLine("Invalid enrty."); Console.ReadLine(); Console.Clear(); counter--; continue; }


                Console.WriteLine("Debug (counter): " + counter); Console.ReadLine(); Console.Clear();


            } while (!win);


            Console.ReadLine();
        }

    }
}
