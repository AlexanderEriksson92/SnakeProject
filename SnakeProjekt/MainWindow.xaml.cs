using SnakeProjekt;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Automation;
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
		private bool GameIsRunning = false;
		private bool isGamePaused = false;

		private readonly Dictionary<Direction, int> dirToRotation = new()
		{
			{ Direction.Up, 0 },
			{ Direction.Right, 90 },
			{ Direction.Down, 180 },
			{ Direction.Left, 270 }
		};

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
				if (isGamePaused)
				{
					await Task.Delay(100);
					continue;
				}
				await Task.Delay(100);
				gameState.Move();
				Draw();
			}
		}

		// Key events and button events
		private async void StartButton_Click(object sender, RoutedEventArgs e)
		{
			GameIsRunning = false;
			StartOrResumegame();
		}
		private async void Window_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (Overlay.Visibility == Visibility.Visible && e.Key == Key.Space)
			{
					StartOrResumegame();
					e.Handled = true;
				}
			else if (GameIsRunning && e.Key == Key.P)
			{
				TogglePause();
				e.Handled = true;
			}
		}
		private async void StartOrResumegame()
		{
			if (!GameIsRunning)
			{
				Overlay.Visibility = Visibility.Hidden;
				await CountDown(3);
				GameIsRunning = true;
				gameState = new GameState(rows, cols);
				_ = RunGame();
			}
			else if (isGamePaused)
			{
				await CountDown(3);
				TogglePause();
			}
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
		// Game running methods
		private async Task RunGame()
		{
			Overlay.Visibility = Visibility.Hidden;
				await Loop();
				await GameOver();
				GameIsRunning = false;
				isGamePaused = false;
		}
		private async Task GameOver()
		{
			await Task.Delay(1000);
			Overlay.Visibility = Visibility.Visible;
			OverLayText.Text = "Game Over. Press space to start.";
			DrawSnakeDead();
			GameIsRunning = false;
			isGamePaused = false;
		}
		
		private void TogglePause()
		{
			isGamePaused = !isGamePaused;
			Overlay.Visibility = isGamePaused ? Visibility.Visible : Visibility.Hidden;
			OverLayText.Text = isGamePaused ? "Game Paused. Press P to resume.": "";
		}
		private async Task CountDown(int seconds)
		{
			for (int i = 3; i > 0; i--)
			{
				OverLayText.Text = i.ToString();
				await Task.Delay(1000);
			}
			OverLayText.Text = "";
		}
		// Setup and draw methods
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
						Source = Images.Empty,
						RenderTransformOrigin = new Point(0.5, 0.5)
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
			DrawSnakeHead();
			TextScore.Text = gameState.Score.ToString();
		}
		private void DrawSnakeHead()
		{ 
			Position headPos = gameState.HeadPosition();
			Image image = GridImages[headPos.X, headPos.Y];
			image.Source = Images.SnakeHead;
			int rotation = dirToRotation[gameState.Dir];
			image.RenderTransform = new RotateTransform(rotation);
		}
		private async void DrawSnakeDead()
		{
			List<Position> positions = new List<Position>(gameState.SnakePositions());
		for (int i = 0; i < positions.Count; i++)
			{
				Position pos = positions[i];
				ImageSource source = i == 0 ? Images.SnakeHeadDead : Images.SnakeBodyDead;
				GridImages[pos.X, pos.Y].Source = source;
				await Task.Delay(100);
			}
		}
		private void CreateGrid()
		{
			for (int r = 0; r < rows; r++)
			{
				for (int c = 0; c < cols; c++)
				{
					GridValue gridVal = gameState.grid[r, c];
					GridImages[r, c].Source = gridValToImage[gridVal];
					GridImages[r, c].RenderTransform = Transform.Identity;
				}
			}
		}
	}
}
	

