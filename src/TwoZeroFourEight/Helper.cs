using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwoZeroFourEight
{
    public static class Helper
    {
        #region Moves

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
                if (col != -1 && row[col] != row[y])
                {
                    col = y; // update
                    continue;
                }
                if (col != -1 && row[col] == row[y])
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
                if (col != -1 && row[col] != row[y])
                {
                    col = y; // update
                    continue;
                }
                if (col != -1 && row[col] == row[y])
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
}
