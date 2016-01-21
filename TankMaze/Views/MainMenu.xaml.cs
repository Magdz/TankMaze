using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TankMaze.Controllers;

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
            InstructionsButton.IsReadOnly = true;
            InstructionsButton.IsReadOnlyCaretVisible = false;
            InstructionsButton.AcceptsTab = true;
            InstructionsButton.Opacity = 0.5;
            ExitButton.IsReadOnly = true;
            ExitButton.IsReadOnlyCaretVisible = false;
            ExitButton.AcceptsTab = true;
            ExitButton.Opacity = 0.5;
        }

        private void StartButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AudioController.startAudio();
                PlayGroundWindow._NavigationFrame.Navigate(new PlayGround());
            }
            else if(e.Key == Key.S)
            {
                InstructionsButton.Opacity = 1;
                InstructionsButton.Focus();
                StartButton.Opacity = 0.5;
            }
            else if(e.Key == Key.Tab)
            {
                StartButton.Focus();
            }
            
        }
       

       

        private void InstructionsButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                InstructionFrame.Visibility = Visibility.Visible;
                InstructionFrame.Focus();
            }
            else if (e.Key == Key.W)
            {
                StartButton.Opacity = 1;
                StartButton.Focus();
                InstructionsButton.Opacity = 0.5;
            }
            else if(e.Key == Key.S)
            {
                ExitButton.Opacity = 1;
                ExitButton.Focus();
                InstructionsButton.Opacity = 0.5;
            }
            else if(e.Key == Key.Tab)
            {
                InstructionsButton.Focus();
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
                InstructionsButton.Opacity = 1;
                InstructionsButton.Focus();
                ExitButton.Opacity = 0.5;
            }
            else if (e.Key == Key.Tab)
            {
                ExitButton.Focus();
            }
        }

        private void InstructionFrame_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
            {
                InstructionsButton.Focus();
                InstructionFrame.Visibility = Visibility.Hidden;
            }
        }
    }
}
