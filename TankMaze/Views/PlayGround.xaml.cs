using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TankMaze.Controllers;
using TankMaze.Object_Pool;

namespace TankMaze.Views
{
    /// <summary>
    /// Interaction logic for PlayGround.xaml
    /// </summary>
    public partial class PlayGround : Page
    {
        PlayerTankController playerController;
        bool gamePaused = false;
        int scorePanelTemp;
        public PlayGround()
        {
            InitializeComponent();
            PauseMenu.Visibility = Visibility.Hidden;
            TheGround.Focus();
            ObjectPool.addObject(ObjectPool.Type.PlayGround, this);
            MazeGenerator.Generate();
            playerController = (PlayerTankController)ObjectPool.getObject(ObjectPool.Type.PlayerTankController, 0);
            ScoreValue.Content = "0";
            LevelValue.Content = "1";
        }

        private void TheGround_KeyDown(object sender, KeyEventArgs e1)
        {
            if (e1.Key == Key.P) pauseGame();
            else if (!gamePaused)
            {
                if (e1.Key == Key.X) playerController.Fire();
                else playerController.Move(e1.Key);
            }
        }
        public void nextLevelScreen()
        {
            increaseLevel();
            TheGround.Opacity = 0.3;
            LevelUpGrid.Visibility = Visibility.Visible;
            NextLevelContinueButton.IsReadOnly = true;
            NextLevelContinueButton.Focus();
            NextLevelExitButton.Opacity = 0.5;
            NextLevelExitButton.IsReadOnly = true;
        }
        private void pauseGame()
        {
            gamePaused = !gamePaused;
            TheGround.Opacity = 0.3;
            PauseMenu.Visibility = Visibility.Visible;
            ContinueButton.IsReadOnly = true;
            ContinueButton.Focus();
            OptionsButton.Opacity = 0.5;
            OptionsButton.IsReadOnly = true;
            ExitButton.Opacity = 0.5;
            ExitButton.IsReadOnly = true;

        }

        private void resumeGame()
        {
            TheGround.Focus();
            TheGround.Opacity = 1;
            PauseMenu.Visibility = Visibility.Hidden;
            gamePaused = !gamePaused;
            
        }

        public void increaseScore(int increaseStep)
        {
            scorePanelTemp = Int32.Parse(ScoreValue.Content.ToString());
            scorePanelTemp+= increaseStep;
            ScoreValue.Content = scorePanelTemp;
        }

        public void increaseLevel()
        {
            scorePanelTemp = Int32.Parse(LevelValue.Content.ToString());
            scorePanelTemp++;
            LevelValue.Content = scorePanelTemp;
            NewLevelValue.Content = scorePanelTemp;
        }

        private void ContinueButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.P)
            {
                resumeGame();
            }
            else if (e.Key == Key.S)
            {
                OptionsButton.Opacity = 1;
                OptionsButton.Focus();
                ContinueButton.Opacity = 0.5;
            }
            else if (e.Key == Key.Tab)
            {
                ContinueButton.Focus();
            }
        }

        private void OptionsButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                //To be implemented
            }
            else if (e.Key == Key.W)
            {
                ContinueButton.Opacity = 1;
                ContinueButton.Focus();
                OptionsButton.Opacity = 0.5;
            }
            else if (e.Key == Key.S)
            {
                ExitButton.Opacity = 1;
                ExitButton.Focus();
                OptionsButton.Opacity = 0.5;
            }
            else if (e.Key == Key.Tab)
            {
                OptionsButton.Focus();
            }
            else if (e.Key == Key.P)
            {
                resumeGame();
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
                OptionsButton.Opacity = 1;
                OptionsButton.Focus();
                ExitButton.Opacity = 0.5;
            }
            else if (e.Key == Key.Tab)
            {
                ExitButton.Focus();
            }
            else if (e.Key == Key.P)
            {
                resumeGame();
            }
        }

        private void NextLevelContinueButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                //To be implemented
            }
            else if (e.Key == Key.S)
            {
                NextLevelExitButton.Opacity = 1;
                NextLevelExitButton.Focus();
                NextLevelContinueButton.Opacity = 0.5;
            }
            else if (e.Key == Key.Tab)
            {
                NextLevelContinueButton.Focus();
            }
        }

        private void NextLevelExitButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Application.Current.Shutdown();
            }
            else if (e.Key == Key.W)
            {
                NextLevelContinueButton.Opacity = 1;
                NextLevelContinueButton.Focus();
                NextLevelExitButton.Opacity = 0.5;
            }
            else if (e.Key == Key.Tab)
            {
                NextLevelExitButton.Focus();
            }
        }
    }
}
