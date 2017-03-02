using System;
using System.Collections.Generic;
using System.Linq;

namespace TwoZeroFourEight
{
    public static class Helper
    {
        public const int BoardSize = 4;
     
        private static readonly Random rand = new Random(Environment.TickCount);

        #region Main

        public static int[][] InitalizeArray()
        {
            var board = Enumerable.Repeat(BoardSize, BoardSize).Select(size => new int[size]).ToArray();

            PutNumberOnArray(board, 2);
            PutNumberOnArray(board, 2);

            return board;
        }

        public static Position PutNumberOnArray(int[][] board, int? number = null)
        {
            if (CountPlaces(board) == BoardSize * BoardSize) // no empty place to put new number
                return Position.Empty;

            var pos = new Position(rand.Next(BoardSize), rand.Next(BoardSize));

            while (board[pos.Row][pos.Col] != 0)
                pos = new Position(rand.Next(BoardSize), rand.Next(BoardSize));

            if (number == null)
                number = rand.Next(4) != 1 ? 2 : 4; // 3/4 chance to get 2, 1/4 chance to get 4

            board[pos.Row][pos.Col] = number.Value;

            return pos;
        }

        #endregion

        #region Moves

        public static IEnumerable<MoveDirection> GetNextAvailableMoves(int[][] current)
        {
            var copied = Clone(current); // create a copy
            var states = new bool[BoardSize];

            MoveUp(copied, states);

            if (states.Contains(true)) // if any col/row is modified.
                yield return MoveDirection.Up;

            MoveDown(copied, states);

            if (states.Contains(true)) // if any col/row is modified.
                yield return MoveDirection.Down;

            MoveLeft(copied, states);

            if (states.Contains(true)) // if any col/row is modified.
                yield return MoveDirection.Up;

            MoveRight(copied, states);

            if (states.Contains(true)) // if any col/row is modified.
                yield return MoveDirection.Up;
        }

        public static void MoveUp(int[][] array, bool[] rowStates)
        {
            for (var col = 0; col < BoardSize; col++)
                rowStates[col] = MoveUp(array, col);
        }

        public static void MoveDown(int[][] array, bool[] rowStates)
        {
            for (var col = 0; col < BoardSize; col++)
                rowStates[col] = MoveDown(array, col);
        }

        public static void MoveLeft(int[][] array, bool[] colStates)
        {
            for (var row = 0; row < BoardSize; row++)
                colStates[row] = MoveLeft(array[row]);
        }

        public static void MoveRight(int[][] array, bool[] colStates)
        {
            for (var row = 0; row < BoardSize; row++)
                colStates[row] = MoveRight(array[row]);
        }

        public static bool MoveUp(int[][] array, int col)
        {
            return MoveLeft(new ColumnWrapper<int>(array, col));
        }

        public static bool MoveDown(int[][] array, int col)
        {
            return MoveRight(new ColumnWrapper<int>(array, col));
        }

        public static bool MoveLeft(IList<int> row)
        {
            // Phase 1: merge numbers
            var col = -1;
            var length = row.Count;
            var modified = false;

            for (var y = 0; y < length; y++)
            {
                if (row[y] == 0)
                    continue;

                if (col == -1)
                {
                    col = y; // remember current col
                    continue;
                }
                if (row[col] != row[y])
                {
                    col = y; // update
                    continue;
                }
                if (row[col] == row[y])
                {
                    row[col] += row[y]; // merge same numbers
                    row[y] = 0;
                    col = -1; // reset
                    modified = true;
                }
            }
            // Phase 2: move numbers
            for (var i = 0; i < length * length; i++)
            {
                var y = i % length;

                if (y == length - 1) continue;
                if (row[y] == 0 && row[y + 1] != 0) // current is empty and next is not 
                {
                    row[y] = row[y + 1]; // move next to current
                    row[y + 1] = 0;
                    modified = true;
                }
            }
            return modified;
        }

        public static bool MoveRight(IList<int> row)
        {
            // Phase 1: merge numbers
            var col = -1;
            var length = row.Count;
            var modified = false;

            for (var y = length - 1; y >= 0; y--)
            {
                if (row[y] == 0)
                    continue;
                if (col == -1)
                {
                    col = y; // remember current col
                    continue;
                }
                if (row[col] != row[y])
                {
                    col = y; // update
                    continue;
                }
                if (row[col] == row[y])
                {
                    row[col] += row[y]; // merge same numbers
                    row[y] = 0;
                    col = -1; // reset
                    modified = true;
                }
            }
            // Phase 2: move numbers
            for (var i = length * length - 1; i >= 0; i--)
            {
                var y = i % length;

                if (y == 0) continue;
                if (row[y] == 0 && row[y - 1] != 0) // current is empty and next is not 
                {
                    row[y] = row[y - 1]; // move next to current
                    row[y - 1] = 0;
                    modified = true;
                }
            }
            return modified;
        }

        #endregion

        #region Others

        public static int CountPlaces(int[][] array)
        {
            return array.SelectMany(row => row).Count(num => num != 0);
        }

        public static int GetLargestNumber(int[][] array)
        {
            return array.SelectMany(row => row).Max();
        }

        public static bool HasEmptyPlace(int[][] array)
        {
            return array.SelectMany(row => row).Contains(0);
        }

        public static int[][] Clone(int[][] array)
        {
            return array.Select(row => row.ToArray()).ToArray();
        }

        #endregion
    }

    public enum MoveDirection
    {
        Up,

        Down,

        Left,

        Right,
    }
}