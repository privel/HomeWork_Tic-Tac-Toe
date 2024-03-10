using System;

class Program
{
    public static char[,] board = {
        { '1', '2', '3' },
        { '4', '5', '6' },
        { '7', '8', '9' }
    };

    static int turns = 0;

    static void Main(string[] args)
    {
        int player = 1;
        int choice;
        char mark;
        bool inputCorrect = true;

        do
        {
            if (player % 2 == 1) player = 1;
            else player = 2;

            Console.Clear();
            Console.WriteLine("Player 1: X and Player 2: O");
            Console.WriteLine("\n");
            if (player == 1) Console.WriteLine("Player 1 turn");
            else Console.WriteLine("Player 2 turn");
            Board();

            
            string input = Console.ReadLine();
            inputCorrect = int.TryParse(input, out choice) && choice >= 1 && choice <= 9 && board[(choice - 1) / 3, (choice - 1) % 3] != 'X' && board[(choice - 1) / 3, (choice - 1) % 3] != 'O';

            if (inputCorrect)
            {
                mark = (player == 1) ? 'X' : 'O';

                
                board[(choice - 1) / 3, (choice - 1) % 3] = mark;
                player++;
                turns++;
            }
            else
            {
                Console.WriteLine("Invalid input; please enter a number between 1 and 9 that has not been marked yet.");
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
            }
        } while (!CheckWin() && turns < 9);

        Console.Clear();
        Board();
        if (CheckWin())
        {
            Console.WriteLine("Player {0} has won!", (player % 2) + 1);
        }
        else
        {
            Console.WriteLine("Draw!");
        }
        Console.ReadLine();
    }

    public static void Board()
    {
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[i, 0], board[i, 1], board[i, 2]);
            if (i != 2)
            {
                Console.WriteLine("_____|_____|_____");
            }
            else
            {
                Console.WriteLine("     |     |     ");
            }
        }
    }

    public static bool CheckWin()
    {
        
        for (int i = 0; i < 3; i++)
        {
            if ((board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2]) ||
                (board[0, i] == board[1, i] && board[1, i] == board[2, i]))
            {
                return true;
            }
        }

        if ((board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2]) || 
            (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0]))
        {
            return true;
        }

        return false;
    }
}