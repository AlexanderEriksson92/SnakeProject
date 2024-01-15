using System;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace SnakeProjekt
{
	public static class Images
	{
		private static string currentColor = "Blue";
		public static ImageSource GetSnakeHead() => LoadImage($"{currentColor}SnakeHead.png");
		public static ImageSource GetSnakeBody() => LoadImage($"{currentColor}SnakeBody.png");
		public static ImageSource GetSnakeHeadDead() =>LoadImage($"{currentColor}SnakeHeadDead.png");
		public static ImageSource GetSnakeBodyDead() => LoadImage($"{currentColor}SnakeBodyDead.png");
		public static ImageSource GetFood() => LoadImage($"{currentColor}Food.png");
		public static ImageSource GetEmpty() => LoadImage($"{currentColor}EmptySpace.png");

		public static void SetColor(string color)
		{
			currentColor = color;
		}

		private static ImageSource LoadImage(string fileName)
		{
			return new BitmapImage(new Uri($"pack://application:,,,/Assets/{fileName}", UriKind.Absolute));
		}

	}
}