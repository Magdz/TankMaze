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
            _NavigationFrame.Navigate(new MainMenu(this));
        }
        
    }
}
