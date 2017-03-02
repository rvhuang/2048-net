using System;

namespace TwoZeroFourEight
{
    public struct Position : IEquatable<Position>
    {
        public static readonly Position Empty = new Position(int.MinValue, int.MinValue);

        public int Col { get; private set; }
        public int Row { get; private set; } 
        public bool IsEmpty { get; private set; }

        public Position(int col, int row)
        {
            this.Col = col;
            this.Row = row;
            this.IsEmpty = col == int.MinValue && row == int.MinValue;
        }

        public bool Equals(Position other)
        {
            return this.Col == other.Col && this.Row == other.Row;
        }

        public override int GetHashCode()
        {
            return this.Col ^ (0 - this.Row);
        }
    }
}
