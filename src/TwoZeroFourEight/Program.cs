using System;
using System.Linq;

namespace TwoZeroFourEight
{
    public class Program
    {
        public const int BoardSize = 4;

        private static readonly Random rand = new Random(Environment.TickCount);

        public static void Main(string[] args)
        {
            var key = default(ConsoleKey);
            var previous = InitalizeArray();
            var newNumPos = Position.Empty;
            var colStates = new bool[BoardSize]; // remember modified cols
            var rowStates = new bool[BoardSize]; // remember modified rows

            do
            {
                Console.Clear();

                var current = Helper.Clone(previous); // create a copy

                Move(key, current, colStates, rowStates);

                if (colStates.Contains(true) || rowStates.Contains(true)) // if any col/row is modified.
                    newNumPos = PutNumberOnArray(current);

                Print(current, previous, newNumPos);

                if (newNumPos.IsEmpty) // if no new number is added
                {
                    var copied = Helper.Clone(current); // create a copy

                    for (var i = (int)ConsoleKey.LeftArrow; i <= (int)ConsoleKey.DownArrow; i++) // try to move
                        Move((ConsoleKey)i, copied, colStates, rowStates);

                    if (colStates.All(s => !s) && rowStates.All(s => !s)) // no more move
                    {
                        Console.WriteLine("Game over!");
                        break;
                    }
                }
                previous = current;
            }
            while ((key = Console.ReadKey(true).Key) != ConsoleKey.X);
        }

        private static void Move(ConsoleKey key, int[][] array, bool[] colStates, bool[] rowStates)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    for (var col = 0; col < BoardSize; col++)
                        rowStates[col] = Helper.MoveUp(array, col);
                    break;

                case ConsoleKey.DownArrow:
                    for (var col = 0; col < BoardSize; col++)
                        rowStates[col] = Helper.MoveDown(array, col);
                    break;

                case ConsoleKey.LeftArrow:
                    for (var row = 0; row < BoardSize; row++)
                        colStates[row] = Helper.MoveLeft(array[row]);
                    break;

                case ConsoleKey.RightArrow:
                    for (var row = 0; row < BoardSize; row++)
                        colStates[row] = Helper.MoveRight(array[row]);
                    break;
            }
        }

        private static int[][] InitalizeArray()
        {
            var board = Enumerable.Repeat(BoardSize, BoardSize).Select(size => new int[size]).ToArray();

            PutNumberOnArray(board, 2);
            PutNumberOnArray(board, 2);

            return board;
        }

        private static Position PutNumberOnArray(int[][] board, int? number = null)
        {
            if (Helper.CountPlaces(board) == BoardSize * BoardSize) // no empty place to put new number
                return Position.Empty;

            var pos = new Position(rand.Next(BoardSize), rand.Next(BoardSize));

            while (board[pos.Row][pos.Col] != 0)
                pos = new Position(rand.Next(BoardSize), rand.Next(BoardSize));

            if (number == null)
                number = rand.Next(4) != 1 ? 2 : 4; // 3/4 chance to get 2, 1/4 chance to get 4

            board[pos.Row][pos.Col] = number.Value;

            return pos;
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
