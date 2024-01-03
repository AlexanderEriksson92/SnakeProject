using System;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace SnakeProjekt
{
	public static class Images
	{
		public static readonly ImageSource SnakeHead = LoadImage("SnakeHead.png");
		public static readonly ImageSource SnakeBody = LoadImage("SnakeBody.png");
		public static readonly ImageSource SnakeDeadHead = LoadImage("SnakeHeadDead.png");
		public static readonly ImageSource SnakeDeadBody = LoadImage("SnakeBodyDead.png");
		public static readonly ImageSource Food = LoadImage("Food.png");
		public static readonly ImageSource Empty = LoadImage("EmptySpace.png");

		private static ImageSource LoadImage(string fileName)
		{
			return new BitmapImage(new Uri($"pack://application:,,,/Assets/{fileName}", UriKind.Absolute));
		}
	}
}