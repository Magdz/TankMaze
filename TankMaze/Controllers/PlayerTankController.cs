using System.Threading;
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
            Ground.setAmmo(playerTank.AmmoAmount);
        }

        public void Move(Key key)
        {
            int goRow = playerTank.GetRow();
            int goColumn = playerTank.GetColumn();
            SingeltonComponent.Direction goDirection = playerTank.direction;

            if (key == Key.W)
            {
                if (goRow == 0) return;
                goRow--;
                if (goDirection == SingeltonComponent.Direction.Down) goRow++;
                else if (goDirection == SingeltonComponent.Direction.Right) goColumn++;
                goDirection = SingeltonComponent.Direction.Up;
            }
            else if (key == Key.S)
            {
                if (goRow == Ground.TheGround.RowDefinitions.Count - 2 && goDirection == SingeltonComponent.Direction.Down) return;
                else if (goRow == Ground.TheGround.RowDefinitions.Count - 1) return;
                goRow++;
                if (goDirection != SingeltonComponent.Direction.Down) goRow--;
                if (goDirection == SingeltonComponent.Direction.Right) goColumn++;
                goDirection = SingeltonComponent.Direction.Down;
            }
            else if (key == Key.A)
            {
                if (goColumn == 0) return;
                goColumn--;
                if (goDirection == SingeltonComponent.Direction.Down) goRow++;
                else if (goDirection == SingeltonComponent.Direction.Right) goColumn++;
                goDirection = SingeltonComponent.Direction.Left;
            }
            else if (key == Key.D)
            {
                if (goColumn == Ground.TheGround.ColumnDefinitions.Count - 2 && goDirection == SingeltonComponent.Direction.Right) return;
                else if (goColumn == Ground.TheGround.ColumnDefinitions.Count - 1) return;
                goColumn++;
                if (goDirection != SingeltonComponent.Direction.Right) goColumn--;
                if (goDirection == SingeltonComponent.Direction.Down) goRow++;
                goDirection = SingeltonComponent.Direction.Right;
            }
            if (CollisionDetector.WallCheck(goRow, goColumn)) return;
            if (goDirection == SingeltonComponent.Direction.Down || goDirection == SingeltonComponent.Direction.Up)
            {
                if (CollisionDetector.WallCheck(goRow + 1, goColumn)) return;
                playerTank.SetRow(goRow + 1);
                playerTank.SetColumn(goColumn);
                playerTank.SetRow(goRow);
            }
            else if(goDirection == SingeltonComponent.Direction.Left || goDirection == SingeltonComponent.Direction.Right)
            {
                if (CollisionDetector.WallCheck(goRow, goColumn + 1)) return;
                playerTank.SetColumn(goColumn + 1);
                playerTank.SetRow(goRow);
                playerTank.SetColumn(goColumn);
            }
            playerTank.Source(goDirection);
            for (int checkRow = goRow; checkRow <= goRow + 1; ++checkRow) 
            {
                for(int checkColumn = goColumn; checkColumn <= goColumn+1; ++checkColumn)
                {
                    if (CollisionDetector.CrashCheck(checkRow, checkColumn))
                    {
                        Bomb bomb = (Bomb)ObjectPool.getObject(ObjectPool.Type.Bomb, checkRow, checkColumn);
                        if (bomb != null && bomb.state.getState())
                        {
                            Ground.deathMenu();
                        }
                        Gold gold = (Gold)ObjectPool.getObject(ObjectPool.Type.Gold, checkRow, checkColumn);
                        if (gold != null && gold.state.getState())
                        {
                            AudioController.playCoinSound();
                            Ground.increaseScore(Gold.Value);
                            gold.RemoveComponent(ObjectPool.Type.Gold);
                        }
                        Ammo ammo = (Ammo)ObjectPool.getObject(ObjectPool.Type.Ammo, checkRow, checkColumn);
                        if (ammo != null && ammo.state.getState()) 
                        {
                            playerTank.AmmoAmount += Ammo.Value;
                            Ground.setAmmo(playerTank.AmmoAmount);
                            ammo.RemoveComponent(ObjectPool.Type.Ammo);
                            AudioController.playAmmoSound();
                        }
                    }
                    else if (CollisionDetector.EnemyTankCheck(checkRow, checkColumn))
                    {
                        Ground.deathMenu();
                    }
                    if (goDirection == SingeltonComponent.Direction.Up || goDirection == SingeltonComponent.Direction.Down) break;
                }
                if (goDirection == SingeltonComponent.Direction.Left || goDirection == SingeltonComponent.Direction.Right) break;
            }
            CameraController.Move(key);
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
            if (playerTank.AmmoAmount > 0) 
            {
                MazeFactory.createObject(ObjectPool.Type.Bullet, fireRow, fireColumn, direction);
                playerTank.AmmoAmount--;
                Ground.setAmmo(playerTank.AmmoAmount);
                AudioController.playBulletSound();
            }
        }
    }
}