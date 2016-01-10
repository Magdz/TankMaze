using System.Windows;
using TankMaze.Views;

namespace TankMaze
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            this._NavigationFrame.Navigate(new PlayGround());
            Start.Visibility = Visibility.Hidden;
        }
    }
}
