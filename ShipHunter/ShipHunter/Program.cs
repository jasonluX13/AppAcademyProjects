using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipHunter
{
    class Program
    {
        enum status
        {
            EMPTY,
            OCCUPIED,
            HIT,
            MISS
        }
        static void Main(string[] args)
        {
            int[,] board =
            {
                { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 },
                { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 1, 1, 0, 0, 0, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
            };
            /*
            status[,] grid = new status[10, 10];
            for(int row=0; row < grid.Length; row++)
            {
                for(int col=0; col < grid.Length; col++)
                {
                    grid[row, col] = status.EMPTY;
                }
            }
            */

            DisplayGrid(board);
            attack(board, 'C', 5);
            DisplayGrid(board);

            attack(board, 'C', 7);
            DisplayGrid(board);

            attack(board, 'F', 5);
            DisplayGrid(board);


            attack(board, 'C', 3);
            DisplayGrid(board);

            Console.ReadKey();

        }

        private static void DisplayGrid(int[,] board)
        {
            int[] columns = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            char[] rows = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };

            Console.Write(" ");
            foreach(int col in columns)
            {
                Console.Write($" {col}");
            }
            Console.WriteLine("");
            for(int row=0; row < board.GetLength(1); row++)
            {
                Console.Write($"{rows[row]} ");
                for (int col=0; col < board.GetLength(0); col++)
                {
                    switch (board[row, col])
                    {
                        case 0:
                            DisplayBlock(2, ConsoleColor.Blue);
                            break;
                        case 1:
                            DisplayBlock(2, ConsoleColor.Green);
                            break;
                        case 2:
                            DisplayBlock(2, ConsoleColor.Red);
                            break;
                        case 3:
                            DisplayBlock(2, ConsoleColor.Gray);
                            break;
                    }
                    
                }
                Console.WriteLine("");
               
            }
           
        }


        private static void DisplayBlock(int width, ConsoleColor color)
        {
            ConsoleColor backgroundColor = Console.BackgroundColor;
            Console.BackgroundColor = color;
            while(width > 0)
            {
                Console.Write(" ");
                width--;
            }
            Console.BackgroundColor = backgroundColor;
        }

        private static string attack(int[,] board,  char column, int row)
        {
            row--;
            int col = (int)(column - 'A');
            if (board[col, row] == 0)
            {
                //Empty so it's a miss
                board[col, row] = 3;
                return "Hit";
            } else
            {
                //OCcupied so it's a hit
                board[col, row] = 2;
                return "Miss";
            }
        }
    }
}
