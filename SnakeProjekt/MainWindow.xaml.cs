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

		private readonly Dictionary<GridValue, Func<ImageSource>> gridValToImage = new()
		{
			{ GridValue.Empty, Images.GetEmpty },
			{ GridValue.Snake, Images.GetSnakeBody },
			{ GridValue.Food, Images.GetFood }
		};
		// Håller koll på spelets tillstånd
		private readonly int rows = 20, cols = 20;
		private readonly Image[,] GridImages;
		private GameState gameState;
		private int CurrentGameSpeed = 100;
		private bool GameIsRunning = false;
		private bool isGamePaused = false;
		private bool isCountDown = false;

		private readonly Dictionary<Direction, int> dirToRotation = new()	// Håller koll på vilket håll ormen ska roteras
		{
			{ Direction.Up, 0 },
			{ Direction.Right, 90 },
			{ Direction.Down, 180 },
			{ Direction.Left, 270 }
		};

		public MainWindow()
		{
			InitializeComponent();
			GridImages = SetupGrid();
			gameState = new GameState(rows, cols);
			StartButton.Visibility = Visibility.Visible;
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
				await Task.Delay(gameState.GameSpeed);      // Uppdaterar spelet med en delay som är beroende på spelets hastighet
				gameState.Move();
				Draw();
			}
		}
		// Settings methods
		private void SettingsButton_Click(object sender, RoutedEventArgs e)
		{
			OpenSettings();
		}
		private void OpenSettings()
		{
			var settingsWindow = new SettingsWindow();
			var dialogResult = settingsWindow.ShowDialog();
			if (dialogResult == true)
			{
				ApplySettings(settingsWindow.ColorSelected, settingsWindow.SpeedSelected, settingsWindow.LevelSelected);
			}
		}
		private void ApplySettings(string color, int speed, string level)
		{
			Images.SetColor(color);
			gameState.GameSpeed = ConvertSpeedToInterval(speed);
			gameState.GameSpeed = CurrentGameSpeed;
			CreateGrid();
		}
		private int ConvertSpeedToInterval(int speed)
		{
			return Math.Max(10, 200 - speed * 50);
		}

		// Key events and button events
		private async void StartButton_Click(object sender, RoutedEventArgs e)
		{
			await StartOrResumegame();
		}
		private async void Window_PreviewKeyDown(object sender, KeyEventArgs e)
		{

			if (NameInputTextBox.IsFocused)     // Om användaren skriver in namn ska inte spelet startas
			{
				return;
			}

			if (Overlay.Visibility == Visibility.Visible && e.Key == Key.Space)
			{
				if (!isGamePaused && !isCountDown)
				{
					await StartOrResumegame();
					e.Handled = true;
				}
			}
			else if (GameIsRunning && e.Key == Key.P)
			{
				if (!isCountDown)
				{
					await TogglePause();
					e.Handled = true;
				}

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
		private async Task StartOrResumegame()
		{
			if (!GameIsRunning && !isCountDown)     // Om spelet inte redan körs och inte är påväg att startas så göms overlayen och spelet startas
			{
				isCountDown = true;
				NameInputTextBox.Visibility = Visibility.Collapsed;
				HighscoreButton.Visibility = Visibility.Collapsed;
				StartButton.Visibility = Visibility.Collapsed;
				HighscoreList.Visibility = Visibility.Collapsed;
				HighscoreText.Visibility = Visibility.Collapsed;
				Overlay.Visibility = Visibility.Hidden;
				await CountDown(3);
				isCountDown = false;
				GameIsRunning = true;
				gameState = new GameState(rows, cols);
				gameState.GameSpeed = this.CurrentGameSpeed;
				await RunGame();
			}
			else if (isGamePaused && !isCountDown)      // Om spelet är pausat och inte redan är påväg att startas så startas spelet
			{
				isCountDown = true;
				await CountDown(3);
				isCountDown = false;
				await TogglePause();
			}
		}
		private async Task TogglePause()
		{
			if (!isCountDown)
			{
				if (isGamePaused)
				{
					isCountDown = true;
					await CountDown(3);
					isCountDown = false;
				}
				isGamePaused = !isGamePaused;
				Overlay.Visibility = isGamePaused ? Visibility.Visible : Visibility.Hidden;
				SettingsButton.Visibility = isGamePaused ? Visibility.Visible : Visibility.Hidden;
				OverLayText.Text = isGamePaused ? "Game Paused. Press P to resume." : "";
			}
		}
		private async Task CountDown(int seconds)       // Countdown innan spelet startar eller återupptas
		{
			for (int i = 3; i > 0; i--)
			{
				Overlay.Visibility = Visibility.Visible;
				OverLayText.Text = "Get ready in: " + i.ToString();
				await Task.Delay(1000);
			}
			OverLayText.Text = "GO";
			await Task.Delay(200);
		}
		private async Task GameOver()               // Startar dödorm animation samt laddar in highscores
		{
			await DrawSnakeDead();
			await Task.Delay(1000);
			Overlay.Visibility = Visibility.Visible;
			StartButton.Visibility = Visibility.Visible;

			Players players = new Players();
			var highscores = players.LoadPlayersScore();
			// Kontrollerar om spelaren har en highscore som är högre än den lägsta highscoren på listan
			if (highscores.Count < 10 || (highscores.Any() && gameState.Score > highscores.Min(player => player.Score)))
			{
				HighscoreButton.Visibility = Visibility.Visible;
				NameInputTextBox.Visibility = Visibility.Visible;
				OverLayText.Text = "Game Over. Submit score or press space to start.";
			}
			else
			{
				HighscoreText.Visibility = Visibility.Collapsed;
				NameInputTextBox.Visibility = Visibility.Collapsed;
				HighscoreButton.Visibility = Visibility.Collapsed;
				OverLayText.Text = "Game Over.";
			}
			GameIsRunning = false;
			isGamePaused = false;
		}

		// Highscore methods
		private void SaveHighscoreButton(object sender, RoutedEventArgs e)
		{
			string playerName = NameInputTextBox.Text;
			if (playerName.Length > 3 && playerName.Length < 10)
			{
				SavePlayerScore(playerName, gameState.Score);
				NameInputTextBox.Visibility = Visibility.Collapsed;
				HighscoreButton.Visibility = Visibility.Collapsed;
				DisplayHighscores();
			}
			else
			{
				OverLayText.Text = "Name must be between 3 and 10 characters.";
			}

		}
		private void SavePlayerScore(string playerName, int score)
		{
			Players players = new Players();
			players.LoadPlayersScore();
			players.AddPlayerScore(playerName, score);
			players.SavePlayersScore();
			playerName = "";
		}

		private void DisplayHighscores()
		{
			Players players = new Players();
			var highscores = players.LoadPlayersScore();
			var highscoresSorted = highscores.OrderByDescending(player => player.Score).ToList();
			HighscoreList.ItemsSource = highscores;
			HighscoreList.Visibility = Visibility.Visible;
			HighscoreText.Visibility = Visibility.Visible;
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
						Source = Images.GetEmpty(),
						RenderTransformOrigin = new Point(0.5, 0.5)     // Sätter pivot för rotation till mitten av bilden
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
			image.Source = Images.GetSnakeHead();
			int rotation = dirToRotation[gameState.Dir];
			image.RenderTransform = new RotateTransform(rotation);
		}
		private async Task DrawSnakeDead()
		{
			List<Position> positions = new List<Position>(gameState.SnakePositions());  // Byter ut ormens bilder till dödormens bilder
			for (int i = 0; i < positions.Count; i++)
			{
				Position pos = positions[i];
				ImageSource source = i == 0 ? Images.GetSnakeHeadDead() : Images.GetSnakeBodyDead();
				GridImages[pos.X, pos.Y].Source = source;
				await Task.Delay(50);
			}
		}
		private void CreateGrid()
		{
			for (int r = 0; r < rows; r++)
			{
				for (int c = 0; c < cols; c++)
				{
					GridValue gridVal = gameState.grid[r, c];
					GridImages[r, c].Source = gridValToImage[gridVal](); 
					GridImages[r, c].RenderTransform = Transform.Identity;
				}
			}
		}
	}
}


