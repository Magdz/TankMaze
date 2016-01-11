using System.Windows.Controls;
using System.Windows.Input;
using TankMaze.Models;
using TankMaze.Object_Pool;
using TankMaze.Views;

namespace TankMaze.Controllers
{
    class PlayerTankController
    {
        private PlayGround Ground;
        private PlayerTank playerTank;

        public PlayerTankController()
        {
            Ground = (PlayGround)ObjectPool.getObject(ObjectPool.Type.PlayGround, 0);
            playerTank = (PlayerTank)ObjectPool.getObject(ObjectPool.Type.PlayerTank, 0);
        }

        public void Move(Key key)
        {
            if (key == Key.Up)
            {
                playerTank.Source(PlayerTank.Direction.Up);
                if (playerTank.GetRow() == 0) return;
                playerTank.SetRow(playerTank.GetRow() - 1);
            }
            else if (key == Key.Down)
            {
                playerTank.Source(PlayerTank.Direction.Down);
                if (playerTank.GetRow() == 33) return;
                playerTank.SetRow(playerTank.GetRow() + 1);
            }
            else if (key == Key.Left)
            {
                playerTank.Source(PlayerTank.Direction.Left);
                if (playerTank.GetColumn() == 0) return;
                playerTank.SetColumn(playerTank.GetColumn() - 1);
            }
            else if (key == Key.Right)
            {
                playerTank.Source(PlayerTank.Direction.Right);
                if (playerTank.GetColumn() == 63) return;
                playerTank.SetColumn(playerTank.GetColumn() + 1);
            }
        }
    }
}
