using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TankMaze.Views
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        private MainWindow PlayGroundWindow;
        public MainMenu(MainWindow Window)
        {
            InitializeComponent();
            PlayGroundWindow = Window;
            StartButton.Focus();
            StartButton.IsReadOnly = true;
            StartButton.IsReadOnlyCaretVisible = false;
            StartButton.AcceptsTab = true;
            ExitButton.IsReadOnly = true;
            ExitButton.IsReadOnlyCaretVisible = false;
            ExitButton.AcceptsTab = true;
            ExitButton.Opacity = 0.5;
        }

        private void StartButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                PlayGroundWindow._NavigationFrame.Navigate(new PlayGround());
            }
            else if(e.Key == Key.S)
            {
                ExitButton.Opacity = 1;
                ExitButton.Focus();
                StartButton.Opacity = 0.5;
            }
            else if(e.Key == Key.Tab)
            {
                StartButton.Focus();
            }
            
        }
       

        private void ExitButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Application.Current.Shutdown();
            }
            else if (e.Key == Key.W)
            {
                StartButton.Opacity = 1;
                StartButton.Focus();
                ExitButton.Opacity = 0.5;
            }
            else if (e.Key == Key.Tab)
            {
                ExitButton.Focus();
            }
        }

      
    }
}
