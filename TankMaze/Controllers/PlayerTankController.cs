using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using TankMaze.Models;

namespace TankMaze.Controllers
{
    class PlayerTankController
    {
        private Grid Ground;
        private PlayerTank theTank;

        public PlayerTankController(PlayerTank theTank, Grid Ground)
        {
            this.Ground = Ground;
            this.theTank = theTank;
        }

        public void Move(Windows.System.VirtualKey Key)
        {
            if (Key == SysteVirtualKey.Up)
            {
                if (Ground.GetRow(theTank) == 0) return;
                RedTank.SetValue(Grid.RowProperty, Grid.GetRow(RedTank) - 1);
                RedTank.SetValue(Grid.ColumnSpanProperty, 1);
                RedTank.SetValue(Grid.RowSpanProperty, 2);
                RedTank.Source = new BitmapImage(new Uri("ms-appx:///Assets/RedTankUp.png"));
            }
            else if (Key == Windows.System.VirtualKey.Down)
            {
                RedTank.SetValue(Grid.RowProperty, Grid.GetRow(RedTank) + 1);
                RedTank.SetValue(Grid.ColumnSpanProperty, 1);
                RedTank.SetValue(Grid.RowSpanProperty, 2);
                RedTank.Source = new BitmapImage(new Uri("ms-appx:///Assets/RedTankDown.png"));
            }
            else if (Key == Windows.System.VirtualKey.Right)
            {
                RedTank.SetValue(Grid.ColumnProperty, Grid.GetColumn(RedTank) + 1);
                RedTank.SetValue(Grid.ColumnSpanProperty, 2);
                RedTank.SetValue(Grid.RowSpanProperty, 1);
                RedTank.Source = new BitmapImage(new Uri("ms-appx:///Assets/RedTankRight.png"));
            }
            else if (Key == Windows.System.VirtualKey.Left)
            {
                if (Grid.GetColumn(RedTank) == 0) return;
                RedTank.SetValue(Grid.ColumnProperty, Grid.GetColumn(RedTank) - 1);
                RedTank.SetValue(Grid.ColumnSpanProperty, 2);
                RedTank.SetValue(Grid.RowSpanProperty, 1);
                RedTank.Source = new BitmapImage(new Uri("ms-appx:///Assets/RedTankLeft.png"));
            }
        }
    }
}
