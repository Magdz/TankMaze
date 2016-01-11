using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using TankMaze.Controllers;
using TankMaze.Models;
using TankMaze.Object_Pool;

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
            ObjectPool.addObject(ObjectPool.Type.PlayGround, this);
            playerTank = new PlayerTank(theTank);
            ObjectPool.addObject(ObjectPool.Type.PlayerTank, playerTank);
            playerController = new PlayerTankController();
            ObjectPool.addObject(ObjectPool.Type.PlayerTankController, playerController);
        }

        private void TheGround_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            playerController.Move(e.Key);
        }
    }
}
