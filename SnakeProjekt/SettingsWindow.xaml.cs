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
		public SettingsWindow()
		{
			InitializeComponent();
		}
		private void ApplyButton_Click(object sender, RoutedEventArgs e)
		{
			ColorSelected = (ColorComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
			SpeedSelected = ConvertSliderToInt((int)SpeedSlider.Value);
			LevelSelected = (LevelComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

			DialogResult = true;
			Close();
		}
		private int ConvertSliderToInt(int sliderValue)
		{
			switch (sliderValue)
			{
				case 1:
					return 50;  // Långsam
				case 2:
					return 100; // Normal
				case 3:
					return 200; // Snabb
				default:
					return 100; // Standard
			}
		}
	}
}