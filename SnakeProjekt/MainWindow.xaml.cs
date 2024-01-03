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

namespace SnakeProjekt
{
	public partial class MainWindow : Window
	{

		private readonly int rows = 20, cols = 20;
		private readonly Image[,] GridImages;

		public MainWindow()
		{
			InitializeComponent();
			GridImages = SetupGrid();
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
	}
}