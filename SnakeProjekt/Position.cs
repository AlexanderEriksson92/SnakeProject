

namespace SnakeProjekt
{
    class Position
    {
        public int X { get;}
		public int Y { get;}

		public Position(int x, int y)
        {
			X = x;
			Y = y;
		}

		public override bool Equals(object obj)
		{
			return obj is Position posistion &&
				   X == posistion.X &&
				   Y == posistion.Y;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(X, Y);
		}

		public static bool operator ==(Position left, Position right)
		{
			return EqualityComparer<Position>.Default.Equals(left, right);
		}

		public static bool operator !=(Position left, Position right)
		{
			return !(left == right);
		}	
    }
}
