using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipHunter
{
    class Program
    {
      
        struct Move
        {
            public char row;
            public int col;
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
            
            const int MaxMisses = 25;
            int misses = 0;
            int hits = 0;

            string[][] locations =
            {
                new string[] {"A2", "A3", "A4", "A5", "A6"},
                new string[] {"C3", "D3", "E3", "F3"},
                new string[] {"H2", "H3", "H4"},
                new string[] {"J7", "J8"},
                new string[] {"I3", "I4"},
                new string[] {"G8"},
                new string[] {"C8"},

            };

            Ship[] ships =
            {
                new Ship("Aircraft Carrier", 5, locations[0] ,5),
                new Ship("Battleship", 4, locations[1],4),
                new Ship("Cruiser", 3, locations[2],3),
                new Ship("Destroyer", 2, locations[3], 2),
                new Ship("Destroyer", 2, locations[4], 2),
                new Ship("Submarine", 5, locations[5],5),
                new Ship("Submarine", 5, locations[6],5),
            };
            while (misses < MaxMisses)
            {
                DisplayGrid(board);
                Console.WriteLine($"Number of Misses: {misses}");
                Console.WriteLine($"Number of tries left: {MaxMisses - misses}");
                Console.WriteLine($"Number of hits: {hits}");

                Move guess = GetMove(board, "Enter your guess (like C8 or I10)");
                string result = attack(board, guess.row, guess.col);
                switch (result)
                {
                    case "Hit":
                        hits++;
                        break;
                    case "Miss":
                        misses++;
                        break;
                }
                if (hits == 18)
                {
                    break;
                }
            }
            if (hits == 18)
            {
                DisplayGrid(board);
                Console.WriteLine("You Won");
            }
            else
            {
                Console.WriteLine("You Lost");
            }
           


            Console.Read();
        }

        private static Move GetMove(int[,] board, string message)
        {
            Move newMove;
            string attack;
            
            while (true)
            {
                Console.WriteLine(message);
                attack = Console.ReadLine();
                int col;
                char row;
                if (char.IsLetter(attack[0]) && int.TryParse(attack.Substring(1), out col))
                {
                    row = char.ToUpper(attack[0]);
                    if (col >= 1 && col <= 10 &&  row >= 'A' && row <= 'J')
                    {
                        newMove.row = row;
                        newMove.col = col;
                        return newMove;
                    }
                    
                }
            }
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
                            DisplayBlock(2, ConsoleColor.Green); //
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

        private static string attack(int[,] board,  char rowChar, int col)
        {
            
            col--;
            int row = (int)(rowChar - 'A');
            if (board[row, col] == 0)
            {
                //Empty so it's a miss
                board[row, col] = 3;
                return "Miss";
            } else
            {
                //Occupied so it's a hit
                board[row, col] = 2;
                return "Hit";
            }
        }
    }
}


/*
    Class Ship {
     

*/