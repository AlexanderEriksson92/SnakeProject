using SnakeProjekt;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static SnakeProjekt.StateOfGame;




namespace SnakeProjekt
{
	public partial class MainWindow : Window
	{
		private readonly Dictionary<GridValue, ImageSource> gridValToImage = new()
		{
			{ GridValue.Empty, Images.Empty },
			{ GridValue.Snake, Images.SnakeBody },
			{ GridValue.Food, Images.Food }
		};

		private readonly int rows = 20, cols = 20;
		private readonly Image[,] GridImages;
		private GameState gameState;

		public MainWindow()
		{
			Debug.WriteLine("MainWindow startar");
			InitializeComponent();
			GridImages = SetupGrid();
			gameState = new GameState(rows, cols);
		}
		private async Task Loop()
		{
			while (gameState.GameOver == 0)
			{
				await Task.Delay(100);
				gameState.Move();
				Draw();
			}
		}
		private async void Window_Loaded(object sender, RoutedEventArgs e)
		{
			Draw();
			await Loop();
		}
		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
			if (gameState.GameOver != 0)
			{

				return;
			}
			switch (e.Key)
			{
				case Key.Left:
					gameState.ChangeDirection(Direction.Left);
					break;
				case Key.Right:
					gameState.ChangeDirection(Direction.Right);
					break;
				case Key.Up:
					gameState.ChangeDirection(Direction.Up);
					break;
				case Key.Down:
					gameState.ChangeDirection(Direction.Down);
					break;
			}
		}
		private Image[,] SetupGrid()
		{
			Image[,] images = new Image[rows, cols];
			GameGrid.Rows = rows;
			GameGrid.Columns = cols;

			for (int r = 0; r < rows; r++)
			{
				for (int c = 0; c < cols; c++)
				{
					Image image = new Image
					{
						Source = Images.Empty
					};
					images[r, c] = image;
					GameGrid.Children.Add(image);
				}
			}
			return images;
		}
		private void Draw()
		{
			CreateGrid();
		}
		private void CreateGrid()
		{
			for (int r = 0; r < rows; r++)
			{
				for (int c = 0; c < cols; c++)
				{
					GridValue gridVal = gameState.grid[r, c];
					GridImages[r, c].Source = gridValToImage[gridVal];
				}
			}
		}
	}
}
	

