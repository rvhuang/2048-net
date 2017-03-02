using System;
using System.Collections.Generic;
using System.Linq;

namespace TwoZeroFourEight
{
    public class Program
    {
        public static readonly IReadOnlyList<ConsoleKey> AllArrows = new[] { ConsoleKey.LeftArrow, ConsoleKey.RightArrow, ConsoleKey.UpArrow, ConsoleKey.DownArrow };

        public static void Main(string[] args)
        {
            var key = default(ConsoleKey);
            var previous = Helper.InitalizeArray();
            var newNumPos = Position.Empty;
            var colStates = new bool[Helper.BoardSize]; // remember modified cols
            var rowStates = new bool[Helper.BoardSize]; // remember modified rows

            do
            {
                Console.Clear();

                Array.Clear(colStates, 0, Helper.BoardSize);
                Array.Clear(rowStates, 0, Helper.BoardSize);

                var current = Helper.Clone(previous); // create a copy

                Move(key, current, colStates, rowStates);

                if (colStates.Contains(true) || rowStates.Contains(true)) // if any col/row is modified.
                    newNumPos = Helper.PutNumberOnArray(current);
                else
                    newNumPos = Position.Empty;

                Print(current, previous, newNumPos);

                // if no new number is added
                if (newNumPos.IsEmpty && !Helper.GetNextAvailableMoves(current).Any())
                {
                    Console.WriteLine("Game Over");
                    break;
                }
                previous = current;
            }
            while ((key = Console.ReadKey(true).Key) != ConsoleKey.X);
            Console.ReadKey(true);
        }

        private static void Move(ConsoleKey key, int[][] array, bool[] colStates, bool[] rowStates)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Helper.MoveUp(array, rowStates);
                    break;

                case ConsoleKey.DownArrow:
                    Helper.MoveDown(array, rowStates);
                    break;

                case ConsoleKey.LeftArrow:
                    Helper.MoveLeft(array, colStates);
                    break;

                case ConsoleKey.RightArrow:
                    Helper.MoveRight(array, colStates);
                    break;
            }
        }

        public static void Print(int[][] current, int[][] previous, Position newNumPos)
        {
            for (var row = 0; row < current.Length; row++)
            {
                for (var col = 0; col < current[row].Length; col++)
                {
                    if (current[row][col] == 0)
                    {
                        Console.Write(" _ ");
                    }
                    else if (row == newNumPos.Row && col == newNumPos.Col)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("[{0}]", current[row][col]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (current[row][col] != previous[row][col])
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" {0} ", current[row][col]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.Write(" {0} ", current[row][col]);
                    }
                    Console.Write("\t");
                }
                Console.WriteLine();
            }
        }
    }
}