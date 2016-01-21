using System.Threading;
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
            if (key == Key.W)
            {
                if (playerTank.GetRow() == 0) return;
                if (CollisionDetector.WallCheck(playerTank.GetRow() - 1, playerTank.GetColumn())) return;
                if (playerTank.direction == SingeltonComponent.Direction.Right) playerTank.SetColumn(playerTank.GetColumn() + 1);
                playerTank.SetRow(playerTank.GetRow() - 1);
                playerTank.Source(SingeltonComponent.Direction.Up);
            }
            else if (key == Key.S)
            {
                if (playerTank.GetRow() == Ground.TheGround.RowDefinitions.Count - 2 || playerTank.GetRow() == Ground.TheGround.RowDefinitions.Count - 1) return;
                if (playerTank.direction == SingeltonComponent.Direction.Right || playerTank.direction == SingeltonComponent.Direction.Left)
                {
                    if (playerTank.direction == SingeltonComponent.Direction.Right) playerTank.SetColumn(playerTank.GetColumn() + 1);
                    playerTank.SetRow(playerTank.GetRow() - 1);
                    playerTank.Source(SingeltonComponent.Direction.Down);
                }
                if (CollisionDetector.WallCheck(playerTank.GetRow() + 2, playerTank.GetColumn())) return;
                playerTank.SetRow(playerTank.GetRow() + 1);
                playerTank.Source(SingeltonComponent.Direction.Down);
            }
            else if (key == Key.A)
            {
                if (playerTank.GetColumn() == 0) return;
                if (CollisionDetector.WallCheck(playerTank.GetRow(), playerTank.GetColumn() - 1)) return;
                if (playerTank.direction == SingeltonComponent.Direction.Down) playerTank.SetRow(playerTank.GetRow() + 1);
                playerTank.SetColumn(playerTank.GetColumn() - 1);
                playerTank.Source(SingeltonComponent.Direction.Left);
            }
            else if (key == Key.D)
            {
                if (playerTank.GetColumn() == Ground.TheGround.ColumnDefinitions.Count - 2 || playerTank.GetColumn() == Ground.TheGround.ColumnDefinitions.Count - 1) return;
                if (playerTank.direction == SingeltonComponent.Direction.Up || playerTank.direction == SingeltonComponent.Direction.Down)
                {
                    if (playerTank.direction == SingeltonComponent.Direction.Down) playerTank.SetRow(playerTank.GetRow() + 1);
                    playerTank.SetColumn(playerTank.GetColumn() - 1);
                    playerTank.Source(SingeltonComponent.Direction.Right);
                }
                if (CollisionDetector.WallCheck(playerTank.GetRow(), playerTank.GetColumn() + 2)) return;
                playerTank.SetColumn(playerTank.GetColumn() + 1);
                playerTank.Source(SingeltonComponent.Direction.Right);
            }
            CameraController.Move(key);
            return;
        }

        public void Fire()
        {
            int fireRow = playerTank.GetRow();
            int fireColumn = playerTank.GetColumn();
            MazeComponent.Direction direction = (MazeComponent.Direction)playerTank.direction;

            if (playerTank.direction == SingeltonComponent.Direction.Up || playerTank.direction == SingeltonComponent.Direction.Down)
            {
                if (playerTank.GetRow() == 0 || playerTank.GetRow() == Ground.TheGround.RowDefinitions.Count - 2 || playerTank.GetRow() == Ground.TheGround.RowDefinitions.Count - 1) return;
                if (playerTank.direction == SingeltonComponent.Direction.Up) fireRow = playerTank.GetRow() - 1;
                else if (playerTank.direction == SingeltonComponent.Direction.Down) fireRow = playerTank.GetRow() + 2;
            }
            else if (playerTank.direction == SingeltonComponent.Direction.Left || playerTank.direction == SingeltonComponent.Direction.Right)
            {
                if (playerTank.GetColumn() == 0 || playerTank.GetColumn() == Ground.TheGround.ColumnDefinitions.Count - 2 || playerTank.GetColumn() == Ground.TheGround.ColumnDefinitions.Count - 1) return;
                if (playerTank.direction == SingeltonComponent.Direction.Left) fireColumn = playerTank.GetColumn() - 1;
                else if (playerTank.direction == SingeltonComponent.Direction.Right) fireColumn = playerTank.GetColumn() + 2;
            }
            if (CollisionDetector.WallCheck(fireRow, fireColumn)) return;
            MazeFactory.createObject(ObjectPool.Type.Bullet, fireRow, fireColumn, direction);
        }
    }
}