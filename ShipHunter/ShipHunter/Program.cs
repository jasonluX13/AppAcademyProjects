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
            //int[,] board =
            //{
            //    { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
            //    { 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 },
            //    { 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 },
            //    { 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 },
            //    { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
            //    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //    { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
            //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //    { 0, 1, 1, 0, 0, 0, 0, 0, 1, 0 },
            //    { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
            //};
            
            int[,] board =
            {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            };

            const int MaxMisses = 25;
            int misses = 0;
            int hits = 0;
            int numDestroyed = 0;

            /*
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
            */
            string[][] locations = new string[7][];
            
            
            
            randomPlacement(locations, board);
            Ship[] ships =
            {
                new Ship("Aircraft Carrier", 5, locations[0]),
                new Ship("Battleship", 4, locations[1]),
                new Ship("Cruiser", 3, locations[2]),
                new Ship("Destroyer", 2, locations[3]),
                new Ship("Destroyer", 2, locations[4]),
                new Ship("Submarine", 1, locations[5]),
                new Ship("Submarine", 1, locations[6]),
            };
            AddShips(board, ships);
            while (misses < MaxMisses)
            {
                DisplayGrid(board);
                Console.WriteLine($"Number of Misses: {misses}");
                Console.WriteLine($"Number of tries left: {MaxMisses - misses}");
              
                Console.WriteLine($"Number of ships destroyed: {numDestroyed}");

                Move guess = GetMove(board, "Enter your guess (like C8 or I10)");
                string result = attack(board, locations, ships, guess.row, guess.col);
                switch (result)
                {
                    case "Hit":
                        hits++;
                        break;
                    case "Miss":
                        misses++;
                        break;
                    case "Destroyed":
                        hits++;
                        numDestroyed++;
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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You Won");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You Lost");
            }
           


            Console.Read();
        }

        private static void AddShips(int[,] board, Ship[] ships)
        {
            foreach (Ship ship in ships)
            {
                foreach (var location in ship.Location)
                {
                    char rowChar = location[0];
                    int col;
                    int.TryParse(location.Substring(1), out col);
                    int row = rowChar - 'A';
                    col--;
                    board[row, col] = 1;
                }
            }
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
                            DisplayBlock(2, ConsoleColor.Green); //set to another color to see ships
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

        private static string attack(int[,] board, string[][] locations, Ship[] ships,  char rowChar, int col)
        {
            string attack = "";
            attack += rowChar;
            attack += col;

            col--;
            int row = (int)(rowChar - 'A');
            if (board[row, col] == 0)
            {
                //Empty so it's a miss
                board[row, col] = 3;
                Console.Clear();
                return "Miss";
            } else if (board[row,col] == 1)
            {
                Console.Clear();
                //Occupied so it's a hit
                board[row, col] = 2;
                for(int count=0; count<locations.Length;count++)
                {
                    foreach (string loc in locations[count])
                    {
                        if (loc == attack)
                        {
                            ships[count].Health--;
                            if (ships[count].Health == 0)
                            {
                                
                                ConsoleColor foreground = Console.ForegroundColor;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ships[count].Type} was destroyed.");
                                Console.ForegroundColor = foreground;
                                return "Destroyed";
                            }
                        }
                    }
                }
                return "Hit";
            }
            else
            {
                Console.Clear();
                return "Repeat";
            }
        }

        private static void randomPlacement(string[][] locations, int[,] board)
        {
        
            locations[0] = randomShip(locations, board, 5);
         
            locations[1] = randomShip(locations, board, 4);     
            locations[2] = randomShip(locations, board, 3);
            locations[3] = randomShip(locations, board, 2);
            locations[4] = randomShip(locations, board, 2);
            locations[5] = randomShip(locations, board, 1);
            locations[6] = randomShip(locations, board, 1);
       

        }

        private static string[] randomShip(string[][] locations, int[,] board, int length)
        {
            
            int size = length - 1;
            if (length == 5)
            {
                Random rand = new Random();
                int row = rand.Next(5);
                int col = rand.Next(5);
                col++;
                string[] positions = new string[length];
                bool right = false;
                if (rand.Next(1) == 1)
                {
                    right = true;
                }
                for (int count = 0; count < length; count++)
                {
                    if (right)
                    {
                        positions[count] += (char)('A' + row);
                        positions[count] += (col + count);
                    }
                    else
                    {
                        //Down
                        positions[count] += (char)('A' + row + count);
                        positions[count] += (col);
                    }
                }
                
                return positions;
                    
            }
            while (true)
            {
                Random rand = new Random();
                int row = rand.Next(9);
                int col = rand.Next(9);
                col++;
                string[] positions = new string[length];
                if (row+size > 10 || col+size>10)
                {
                    continue; //pick another random starting point
                }
                
                bool right = true; //false means down
                if (rand.Next(1) == 1)
                {
                    right = false;
                }
                for (int count=0; count<length; count++)
                {
                    if (right)
                    {
                        positions[count] += (char) ('A' + row);
                        positions[count] += (col+count);
                    }
                    else
                    {
                        //Down
                        positions[count] += (char)('A' + row + count);
                        positions[count] += (col);
                    }
                }
                
                if(Collision(locations, positions))
                {
                    continue; 
                }
                
                return positions;
            }
            
        }

        private static bool Collision(string[][] locations, string[] positions)
        {
            for (int count = 0; count < positions.Length; count++)
            {
                foreach (string[] shipData in locations)
                {
                    if (shipData == null)
                    {
                        return false;
                    }
                    foreach(string loc in shipData)
                    {
                        if (positions[count] == loc)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}

