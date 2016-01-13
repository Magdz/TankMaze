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
            Ammo test = new Ammo(2, 2, MazeComponent.Direction.Up);
            EnemyBase Eb = new EnemyBase(8, 8);
            playerTank = new PlayerTank(5,0);
            ObjectPool.addObject(ObjectPool.Type.PlayerTank, playerTank);
            playerController = new PlayerTankController();
            ObjectPool.addObject(ObjectPool.Type.PlayerTankController, playerController);
            playerController.Move(System.Windows.Input.Key.Right);
        }

        private void TheGround_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            PlayerTankController playerController = (PlayerTankController)ObjectPool.getObject(ObjectPool.Type.PlayerTankController, 0);
            playerController.Move(e.Key);
        }
    }
}
