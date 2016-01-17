using System;
using System.Windows.Controls;
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
        public PlayGround()
        {
            InitializeComponent();
            FocusButton.Focus();
            ObjectPool.addObject(ObjectPool.Type.PlayGround, this);
            MazeFactory.createObject(ObjectPool.Type.PlayerTank, 2, 2, MazeComponent.Direction.Right);
            MazeFactory.createObject(ObjectPool.Type.EnemyBase, 6, 6, MazeComponent.Direction.Left);
            MazeFactory.createObject(ObjectPool.Type.Bomb, 5, 5, MazeComponent.Direction.Up);
        }

        private void TheGround_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            PlayerTankController playerController = (PlayerTankController)ObjectPool.getObject(ObjectPool.Type.PlayerTankController, 0);
            playerController.Move(e.Key);
        }
    }
}
