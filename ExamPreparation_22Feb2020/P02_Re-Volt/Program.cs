using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_Re_Volt
{
    class Program
    {
        class Player
        {
            public Player(int row, int col)
            {
                Row = row;
                Col = col;
            }
            public int Row { get; set; }
            public int Col { get; set; }
        }
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int commandsCount = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            Player player = new Player(-1, -1);
                      
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == 'f')
                    {
                        player.Col = col;
                        player.Row = row;
                    }
                }
            }

            matrix[player.Row, player.Col] = '-';
            //PrintMatrix(matrix);
            for (int i = 0; i < commandsCount; i++)
            {
                string command = Console.ReadLine();
                
                MovePlayer(player, command);
                //check coordinates
                ValidateCoordinates(matrix, player);

                //check for the finishline
                if (matrix[player.Row, player.Col] == 'F')
                {
                    matrix[player.Row, player.Col] = 'f';
                    Console.WriteLine("Player won!");
                    PrintMatrix(matrix);
                    return;
                }
                //check for traps and bonuses
                if (matrix[player.Row, player.Col] == 'B')
                {
                    MovePlayer(player, command);
                }
                else if (matrix[player.Row, player.Col] == 'T')
                {
                    StepBack(player, command);
                }
            }

            matrix[player.Row, player.Col] = 'f';
            Console.WriteLine("Player lost!");
            PrintMatrix(matrix);
        }

        private static void StepBack(Player player, string command)
        {
            if (command == "up")
            {
                MovePlayer(player, "down");
            }
            else if (command == "down")
            {
                MovePlayer(player, "up");
            }
            else if (command == "left")
            {
                MovePlayer(player, "right");
            }
            else if (command == "right")
            {
                MovePlayer(player, "left");
            }
        }

        //Validate coodinates and if the player is outside the field,
        //bring him back from the other side
        private static void ValidateCoordinates(char[,] matrix, Player player)
        {
            if (player.Row < 0)
            {
                player.Row = matrix.GetLength(0) - 1;
            }
            else if (player.Row >= matrix.GetLength(0))
            {
                player.Row = 0;
            }
            if (player.Col < 0 )
            {
                player.Col = matrix.GetLength(0) - 1;
            }
            else if (player.Col >= matrix.GetLength(0) )
            {
                player.Col = 0;
            }
        }

        private static void MovePlayer(Player player, string command)
        {
            if (command == "up")
            {
                player.Row--;
            }
            else if (command == "down")
            {
                player.Row++;
            }
            else if (command == "left")
            {
                player.Col--;
            }
            else if(command == "right")
            {
                player.Col++;
            }
        }
        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    Console.Write(matrix[row, column]);
                }

                Console.WriteLine();
            }
        }
    }
}
