using System.Windows.Controls;
using System.Windows.Input;
using TankMaze.Factory;
using TankMaze.Models;
using TankMaze.Object_Pool;
using TankMaze.Views;

namespace TankMaze.Controllers
{
    class PlayerTankController
    {
        private PlayerTank playerTank;
        private PlayGround Ground;

        public PlayerTankController(PlayerTank playerTank)
        {
            this.playerTank = playerTank;
            Ground = (PlayGround)ObjectPool.getObject(ObjectPool.Type.PlayGround, 0);
        }

        public void Move(Key key)
        {
            if (key == Key.Up)
            {
                if (playerTank.GetRow() == 0) return;
                if (CollisionDetector.WallCheck(playerTank.GetRow() - 1, playerTank.GetColumn())) return;
                playerTank.SetRow(playerTank.GetRow() - 1);
                playerTank.Source(SingeltonComponent.Direction.Up);
            }
            else if (key == Key.Down)
            {
                if (playerTank.GetRow() == Ground.TheGround.RowDefinitions.Count - 1) return;
                if (CollisionDetector.WallCheck(playerTank.GetRow() + 2, playerTank.GetColumn())) return;
                playerTank.SetRow(playerTank.GetRow() + 1);
                playerTank.Source(SingeltonComponent.Direction.Down);
            }
            else if (key == Key.Left)
            {
                if (playerTank.GetColumn() == 0) return;
                if (CollisionDetector.WallCheck(playerTank.GetRow(), playerTank.GetColumn() - 1)) return;
                playerTank.SetColumn(playerTank.GetColumn() - 1);
                playerTank.Source(SingeltonComponent.Direction.Left);
            }
            else if (key == Key.Right)
            {
                if (playerTank.GetColumn() == Ground.TheGround.ColumnDefinitions.Count - 1) return;
                if (CollisionDetector.WallCheck(playerTank.GetRow(), playerTank.GetColumn() + 2)) return;
                playerTank.SetColumn(playerTank.GetColumn() + 1);
                playerTank.Source(SingeltonComponent.Direction.Right);
            }
            CameraController.Move(key);
            return;
        }

        public void Fire()
          {
            if (playerTank.direction == SingeltonComponent.Direction.Up) MazeFactory.createObject(ObjectPool.Type.Bullet, playerTank.GetRow() - 2, playerTank.GetColumn(), MazeComponent.Direction.Up);
            else if (playerTank.direction == SingeltonComponent.Direction.Down) MazeFactory.createObject(ObjectPool.Type.Bullet, playerTank.GetRow() + 2, playerTank.GetColumn(), MazeComponent.Direction.Down);
            else if (playerTank.direction == SingeltonComponent.Direction.Left) MazeFactory.createObject(ObjectPool.Type.Bullet, playerTank.GetRow(), playerTank.GetColumn() - 2, MazeComponent.Direction.Left);
            else if (playerTank.direction == SingeltonComponent.Direction.Right) MazeFactory.createObject(ObjectPool.Type.Bullet, playerTank.GetRow(), playerTank.GetColumn() + 2, MazeComponent.Direction.Right);
            return;
        }
    }
}
