

namespace SnakeProjekt
{
    class Posistion
    {
        public int X { get;}
		public int Y { get;}

		public Posistion(int x, int y)
        {
			X = x;
			Y = y;
		}

		public override bool Equals(object obj)
		{
			return obj is Posistion posistion &&
				   X == posistion.X &&
				   Y == posistion.Y;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(X, Y);
		}

		public static bool operator ==(Posistion left, Posistion right)
		{
			return EqualityComparer<Posistion>.Default.Equals(left, right);
		}

		public static bool operator !=(Posistion left, Posistion right)
		{
			return !(left == right);
		}	
    }
}
