

namespace SnakeProjekt
{
    public class Direction
    {

		public readonly static Direction Left = new Direction(0, -1);
		public readonly static Direction Right = new Direction(0, 1);
		public readonly static Direction Up = new Direction(-1, 0);
		public readonly static Direction Down = new Direction(1, 0);

        public int X { get; set; }
		public int Y { get; set; }

		public Direction(int x, int y)
        {
			X = x;
			Y = y;
		}
		public Direction Opposite()
		{
			return new Direction(-X, -Y);
		}

		public override bool Equals(object obj)
		{
			return obj is Direction direction &&
				   X == direction.X &&
				   Y == direction.Y;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(X, Y);
		}

		public static bool operator ==(Direction left, Direction right)
		{
			return EqualityComparer<Direction>.Default.Equals(left, right);
		}

		public static bool operator !=(Direction left, Direction right)
		{
			return !(left == right);
		}
	}
}
