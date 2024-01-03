using System;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace SnakeProjekt
{
	public static class Images
	{
	 public static readonly string SnakeHead = "SnakeHead.png";
		public static readonly string SnakeBody = "SnakeBody.png";
			
		public static readonly string SnakeDeadHead = "SnakeDeadHead.png";
		public static readonly string SnakeDeadBody = "SnakeDeadBody.png";

		public static readonly string Food = "Food.png";
		public static readonly string Empty = "EmptySpace.png";
		


		private static ImageSource LoadImage(string fileName)
		{
			return new BitmapImage(new Uri($"Assets/{fileName}", UriKind.Relative));
		}

	}
}
