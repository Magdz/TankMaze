using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using TankMaze.Controllers;
using TankMaze.Factory;
using TankMaze.Models;
using TankMaze.Object_Pool;

namespace TankMaze.Views
{
    /// <summary>
    /// Interaction logic for PlayGround.xaml
    /// </summary>
    public partial class PlayGround : Page
    {
        PlayerTankController playerController;
        public PlayGround()
        {
            InitializeComponent();
            FocusButton.Focus();
            ObjectPool.addObject(ObjectPool.Type.PlayGround, this);
            MazeFactory.createObject(ObjectPool.Type.PlayerTank, 2, 2, MazeComponent.Direction.Down);
            MazeFactory.createObject(ObjectPool.Type.EnemyBase, 33, 20, MazeComponent.Direction.Left);
            MazeFactory.createObject(ObjectPool.Type.Bomb, 5, 5, MazeComponent.Direction.Up);
            playerController = (PlayerTankController)ObjectPool.getObject(ObjectPool.Type.PlayerTankController, 0);

        }

        private void TheGround_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space) playerController.Fire();
            else playerController.Move(e.Key);
            return;
        }

    }
}
