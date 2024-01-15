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
	public partial class SettingsWindow : Window
	{
		public string ColorSelected { get; private set; }
		public int SpeedSelected { get; private set; }
		public string LevelSelected { get; private set; }

		public string CurrentSelectedColor { get; set; }
		public SettingsWindow(string currentColor)
		{
			InitializeComponent();
			
			
			if (CurrentSelectedColor == "Blue")
			{
				ColorComboBox.SelectedIndex = 0;
			}
			else if (CurrentSelectedColor == "Red")
			{
				ColorComboBox.SelectedIndex = 1;
			}
		}
		private void ApplyButton_Click(object sender, RoutedEventArgs e)
		{
			var selectedColor = ColorComboBox.SelectedItem as ComboBoxItem;
			ColorSelected = selectedColor.Content.ToString();

			if (SpeedSlow.IsChecked == true)
				SpeedSelected = 50;
			else if (SpeedNormal.IsChecked == true)
				SpeedSelected = 100;
			else if (SpeedFast.IsChecked == true)
				SpeedSelected = 200;
			else
				SpeedSelected = 100;

			DialogResult = true;
			Close();
		}
	}
}