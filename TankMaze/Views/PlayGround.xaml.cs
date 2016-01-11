using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using TankMaze.Controllers;
using TankMaze.Models;

namespace TankMaze.Views
{
    /// <summary>
    /// Interaction logic for PlayGround.xaml
    /// </summary>
    public partial class PlayGround : Page
    {
        PlayerTank playerTank;
        PlayerTankController playerController;
        public PlayGround()
        {
            InitializeComponent();
            FocusButton.Focus();
            playerTank = new PlayerTank(theTank, this);
            playerController = new PlayerTankController(playerTank, this);
        }

        private void TheGround_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            playerController.Move(e.Key);
        }
    }
}
