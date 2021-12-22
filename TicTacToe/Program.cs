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
            int counter = -1;
            int printCount = 0;
            int n;
            string char1;
            string char2;
            int inARowWins = 5;
            string rowWins;


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
                if (inARowWins > n || inARowWins > 5 || inARowWins < 3) { Console.WriteLine("\n\nIvalid settings, please try again!"); Console.ReadLine(); Console.Clear(); }
            } while (n < 3 || n > 9 || inARowWins > n || inARowWins > 5 || inARowWins < 3);

            Console.Clear();

            string[,] matrix2D = new string[n, n];

            //enumerate matrix
            for (int i = 0; i < matrix2D.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2D.GetLength(1); j++)
                {
                    printCount++;
                    matrix2D[i, j] = Convert.ToString(printCount);
                }
            }

            do
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

                    if (i < (matrix2D.GetLength(1) - 1)) { Console.Write("\n"); for (int k = 0; k < matrix2D.GetLength(0); k++) { Console.Write("-----"); } Console.Write("\n"); }
                }




                //decide whos next, receive input
                counter++;
                if (counter == matrix2D.Length) { Console.WriteLine("\n\nGAME OVER"); Console.ReadLine(); break; }
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
                                if (counter % 2 == 0) { matrix2D[i, j] = char1; }
                                else { matrix2D[i, j] = char2; }
                                //check if anyone has won

                                switch (inARowWins)
                                {
                                    case 3: //diagonal win /
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i + 1, j - 1] && matrix2D[i, j] == matrix2D[i + 2, j - 2])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(/)"); } else { Console.WriteLine("Player2 WINS(/)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i - 1, j + 1] && matrix2D[i, j] == matrix2D[i + 1, j - 1])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(/)"); } else { Console.WriteLine("Player2 WINS(/)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i - 1, j + 1] && matrix2D[i, j] == matrix2D[i - 2, j + 2])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(/)"); } else { Console.WriteLine("Player2 WINS(/)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }



                                        //other diagonal win \
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i + 1, j + 1] && matrix2D[i, j] == matrix2D[i + 2, j + 2])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(dia)"); } else { Console.WriteLine("Player2 WINS(dia)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i - 1, j - 1] && matrix2D[i, j] == matrix2D[i - 2, j - 2])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(dia)"); } else { Console.WriteLine("Player2 WINS(dia)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i - 1, j - 1] && matrix2D[i, j] == matrix2D[i + 1, j + 1])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(dia)"); } else { Console.WriteLine("Player2 WINS(dia)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }



                                        //horizontal win
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i, j + 1] && matrix2D[i, j] == matrix2D[i, j + 2])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(-)"); } else { Console.WriteLine("Player2 WINS(-)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i, j - 1] && matrix2D[i, j] == matrix2D[i, j - 2])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(-)"); } else { Console.WriteLine("Player2 WINS(-)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i, j - 1] && matrix2D[i, j] == matrix2D[i, j + 1])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(-)"); } else { Console.WriteLine("Player2 WINS(-)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }



                                        //vertical win
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i + 1, j] && matrix2D[i, j] == matrix2D[i + 2, j])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(|)"); } else { Console.WriteLine("Player2 WINS(|)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i - 1, j] && matrix2D[i, j] == matrix2D[i - 2, j])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(|)"); } else { Console.WriteLine("Player2 WINS(|)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i - 1, j] && matrix2D[i, j] == matrix2D[i + 1, j])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(|)"); } else { Console.WriteLine("Player2 WINS(|)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        break;
                                    case 4:
                                        //diagonal win /
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i + 1, j - 1] && matrix2D[i, j] == matrix2D[i + 2, j - 2] && matrix2D[i, j] == matrix2D[i + 3, j - 3])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(/)"); } else { Console.WriteLine("Player2 WINS(/)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i - 1, j + 1] && matrix2D[i, j] == matrix2D[i + 1, j - 1] && matrix2D[i, j] == matrix2D[i + 2, j - 2])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(/)"); } else { Console.WriteLine("Player2 WINS(/)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i - 1, j + 1] && matrix2D[i, j] == matrix2D[i - 2, j + 2] && matrix2D[i, j] == matrix2D[i + 1, j - 1])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(/)"); } else { Console.WriteLine("Player2 WINS(/)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i - 1, j + 1] && matrix2D[i, j] == matrix2D[i - 2, j + 2] && matrix2D[i, j] == matrix2D[i - 3, j + 3])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(/)"); } else { Console.WriteLine("Player2 WINS(/)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }



                                        //other diagonal win \
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i + 1, j + 1] && matrix2D[i, j] == matrix2D[i + 2, j + 2] && matrix2D[i, j] == matrix2D[i + 3, j + 3])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(dia)"); } else { Console.WriteLine("Player2 WINS(dia)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i - 1, j - 1] && matrix2D[i, j] == matrix2D[i - 2, j - 2] && matrix2D[i, j] == matrix2D[i + 1, j + 1])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(dia)"); } else { Console.WriteLine("Player2 WINS(dia)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i - 1, j - 1] && matrix2D[i, j] == matrix2D[i + 1, j + 1] && matrix2D[i, j] == matrix2D[i + 2, j + 2])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(dia)"); } else { Console.WriteLine("Player2 WINS(dia)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i - 1, j - 1] && matrix2D[i, j] == matrix2D[i - 2, j - 2] && matrix2D[i, j] == matrix2D[i - 3, j - 3])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(dia)"); } else { Console.WriteLine("Player2 WINS(dia)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }



                                        //horizontal win
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i, j + 1] && matrix2D[i, j] == matrix2D[i, j + 2] && matrix2D[i, j] == matrix2D[i, j + 3])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(-)"); } else { Console.WriteLine("Player2 WINS(-)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i, j - 1] && matrix2D[i, j] == matrix2D[i, j - 2] && matrix2D[i, j] == matrix2D[i, j + 1])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(-)"); } else { Console.WriteLine("Player2 WINS(-)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i, j - 1] && matrix2D[i, j] == matrix2D[i, j + 1] && matrix2D[i, j] == matrix2D[i, j + 2])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(-)"); } else { Console.WriteLine("Player2 WINS(-)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i, j - 1] && matrix2D[i, j] == matrix2D[i, j - 2] && matrix2D[i, j] == matrix2D[i, j - 3])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(-)"); } else { Console.WriteLine("Player2 WINS(-)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }



                                        //vertical win
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i + 1, j] && matrix2D[i, j] == matrix2D[i + 2, j] && matrix2D[i, j] == matrix2D[i + 3, j])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(|)"); } else { Console.WriteLine("Player2 WINS(|)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i - 1, j] && matrix2D[i, j] == matrix2D[i - 2, j] && matrix2D[i, j] == matrix2D[i + 1, j])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(|)"); } else { Console.WriteLine("Player2 WINS(|)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i - 1, j] && matrix2D[i, j] == matrix2D[i + 1, j] && matrix2D[i, j] == matrix2D[i + 2, j])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(|)"); } else { Console.WriteLine("Player2 WINS(|)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i - 1, j] && matrix2D[i, j] == matrix2D[i - 2, j] && matrix2D[i, j] == matrix2D[i - 3, j])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(|)"); } else { Console.WriteLine("Player2 WINS(|)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        break;
                                    default:
                                        //diagonal win /
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i + 1, j - 1] && matrix2D[i, j] == matrix2D[i + 2, j - 2] && matrix2D[i, j] == matrix2D[i + 3, j - 3] && matrix2D[i, j] == matrix2D[i + 4, j - 4])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(/)"); } else { Console.WriteLine("Player2 WINS(/)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i - 1, j + 1] && matrix2D[i, j] == matrix2D[i + 1, j - 1] && matrix2D[i, j] == matrix2D[i + 2, j - 2] && matrix2D[i, j] == matrix2D[i + 3, j - 3])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(/)"); } else { Console.WriteLine("Player2 WINS(/)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i - 1, j + 1] && matrix2D[i, j] == matrix2D[i - 2, j + 2] && matrix2D[i, j] == matrix2D[i + 1, j - 1] && matrix2D[i, j] == matrix2D[i + 2, j - 2])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(/)"); } else { Console.WriteLine("Player2 WINS(/)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i - 1, j + 1] && matrix2D[i, j] == matrix2D[i - 2, j + 2] && matrix2D[i, j] == matrix2D[i - 3, j + 3] && matrix2D[i, j] == matrix2D[i + 1, j - 1])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(/)"); } else { Console.WriteLine("Player2 WINS(/)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i - 1, j + 1] && matrix2D[i, j] == matrix2D[i - 2, j + 2] && matrix2D[i, j] == matrix2D[i - 3, j + 3] && matrix2D[i, j] == matrix2D[i - 4, j + 4])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(/)"); } else { Console.WriteLine("Player2 WINS(/)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }



                                        //other diagonal win \
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i + 1, j + 1] && matrix2D[i, j] == matrix2D[i + 2, j + 2] && matrix2D[i, j] == matrix2D[i + 3, j + 3] && matrix2D[i, j] == matrix2D[i + 4, j + 4])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(dia)"); } else { Console.WriteLine("Player2 WINS(dia)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i - 1, j - 1] && matrix2D[i, j] == matrix2D[i - 2, j - 2] && matrix2D[i, j] == matrix2D[i + 1, j + 1] && matrix2D[i, j] == matrix2D[i + 2, j + 2])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(dia)"); } else { Console.WriteLine("Player2 WINS(dia)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i - 1, j - 1] && matrix2D[i, j] == matrix2D[i + 1, j + 1] && matrix2D[i, j] == matrix2D[i + 2, j + 2] && matrix2D[i, j] == matrix2D[i + 3, j + 3])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(dia)"); } else { Console.WriteLine("Player2 WINS(dia)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i - 1, j - 1] && matrix2D[i, j] == matrix2D[i - 2, j - 2] && matrix2D[i, j] == matrix2D[i - 3, j - 3] && matrix2D[i, j] == matrix2D[i + 1, j + 1])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(dia)"); } else { Console.WriteLine("Player2 WINS(dia)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i - 1, j - 1] && matrix2D[i, j] == matrix2D[i - 2, j - 2] && matrix2D[i, j] == matrix2D[i - 3, j - 3] && matrix2D[i, j] == matrix2D[i - 4, j - 4])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(dia)"); } else { Console.WriteLine("Player2 WINS(dia)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }



                                        //horizontal win
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i, j + 1] && matrix2D[i, j] == matrix2D[i, j + 2] && matrix2D[i, j] == matrix2D[i, j + 3] && matrix2D[i, j] == matrix2D[i, j + 4])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(-)"); } else { Console.WriteLine("Player2 WINS(-)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i, j - 1] && matrix2D[i, j] == matrix2D[i, j - 2] && matrix2D[i, j] == matrix2D[i, j + 1] && matrix2D[i, j] == matrix2D[i, j + 2])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(-)"); } else { Console.WriteLine("Player2 WINS(-)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i, j - 1] && matrix2D[i, j] == matrix2D[i, j + 1] && matrix2D[i, j] == matrix2D[i, j + 2] && matrix2D[i, j] == matrix2D[i, j + 3])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(-)"); } else { Console.WriteLine("Player2 WINS(-)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i, j - 1] && matrix2D[i, j] == matrix2D[i, j - 2] && matrix2D[i, j] == matrix2D[i, j - 3] && matrix2D[i, j] == matrix2D[i, j + 1])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(-)"); } else { Console.WriteLine("Player2 WINS(-)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i, j - 1] && matrix2D[i, j] == matrix2D[i, j - 2] && matrix2D[i, j] == matrix2D[i, j - 3] && matrix2D[i, j] == matrix2D[i, j - 4])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(-)"); } else { Console.WriteLine("Player2 WINS(-)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }



                                        //vertical win
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i + 1, j] && matrix2D[i, j] == matrix2D[i + 2, j] && matrix2D[i, j] == matrix2D[i + 3, j] && matrix2D[i, j] == matrix2D[i + 4, j])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(|)"); } else { Console.WriteLine("Player2 WINS(|)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i - 1, j] && matrix2D[i, j] == matrix2D[i - 2, j] && matrix2D[i, j] == matrix2D[i + 1, j] && matrix2D[i, j] == matrix2D[i + 2, j])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(|)"); } else { Console.WriteLine("Player2 WINS(|)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i - 1, j] && matrix2D[i, j] == matrix2D[i + 1, j] && matrix2D[i, j] == matrix2D[i + 2, j] && matrix2D[i, j] == matrix2D[i + 3, j])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(|)"); } else { Console.WriteLine("Player2 WINS(|)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i - 1, j] && matrix2D[i, j] == matrix2D[i - 2, j] && matrix2D[i, j] == matrix2D[i - 3, j] && matrix2D[i, j] == matrix2D[i + 1, j])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(|)"); } else { Console.WriteLine("Player2 WINS(|)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        try
                                        {
                                            if (matrix2D[i, j] == matrix2D[i - 1, j] && matrix2D[i, j] == matrix2D[i - 2, j] && matrix2D[i, j] == matrix2D[i - 3, j] && matrix2D[i, j] == matrix2D[i - 4, j])
                                            { if (matrix2D[i, j] == char1) { Console.WriteLine("Player1 WINS(|)"); } else { Console.WriteLine("Player2 WINS(|)"); } Console.ReadLine(); win = true; break; }
                                        }
                                        catch (IndexOutOfRangeException)
                                        { }
                                        break;
                                }
                            }
                            else { continue; }
                        }
                    }

                }
                else { Console.WriteLine("Invalid enrty."); Console.ReadLine(); Console.Clear(); counter--; continue; }
                /*Console.WriteLine("Debug (counter): " + counter); Console.ReadLine();*/
                Console.Clear();
            } while (!win);
            Console.ReadLine();
        }
    }
}
