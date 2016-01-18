using System.Windows.Controls;
using System.Windows.Input;
using TankMaze.Models;
using TankMaze.Object_Pool;
using TankMaze.Views;

namespace TankMaze.Controllers
{
    static class CameraController
    {
        private static int Top = 0;
        private static int Left = 0;
        private static PlayGround Ground = (PlayGround)ObjectPool.getObject(ObjectPool.Type.PlayGround, 0);
        private static PlayerTank playerTank = (PlayerTank)ObjectPool.getObject(ObjectPool.Type.PlayerTank, 0);
        public static void Move(Key key)
        {
            if (!(playerTank.GetColumn() > 15 && playerTank.GetColumn() < 40))
                if (!(playerTank.GetRow() > 10 && playerTank.GetRow() < 25)) return;
            if(key == Key.Up)
            {
                if (Top == 0) return;
                Top += 30;
            }
            else if(key == Key.Down)
            {
                if (Top == ((24 - Ground.TheGround.RowDefinitions.Count) * 30)) return;
                Top -= 30;
            }
            if(key == Key.Left)
            {
                if (Left == 0) return;
                Left += 30;
            }
            else if(key == Key.Right)
            {
                if (Left == ((45 - Ground.TheGround.ColumnDefinitions.Count) * 30)) return;
                Left -= 30;
            }
            Canvas.SetTop(Ground.TheGround, Top);
            Canvas.SetLeft(Ground.TheGround, Left);
        }
    }
}
