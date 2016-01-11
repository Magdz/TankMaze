
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using TankMaze.Object_Pool;
using TankMaze.Views;

namespace TankMaze.Models
{
    class PlayerTank : Tank
    {
        //int ID = 1; // the tank takes two cells 

        private BitmapImage UpImage = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/RedTankUp.png", UriKind.Absolute));
        private BitmapImage DownImage = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/RedTankDown.png", UriKind.Absolute));
        private BitmapImage RightImage = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/RedTankRight.png", UriKind.Absolute));
        private BitmapImage LeftImage = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/RedTankLeft.png", UriKind.Absolute));
        private Image theTank { get; }
        private PlayGround Ground;

        public enum Direction
        {
            Up,Down,Left,Right
        }

        public PlayerTank(Image theTank)
        {
            this.theTank = theTank;
            Ground = (PlayGround)ObjectPool.getObject(ObjectPool.Type.PlayGround, 0);
        }

        public void Source(Direction direction)
        {
            if (direction == Direction.Up) theTank.Source = UpImage;
            else if (direction == Direction.Down) theTank.Source = DownImage;
            else if (direction == Direction.Left) theTank.Source = LeftImage;
            else if (direction == Direction.Right) theTank.Source = RightImage;
        }

        public int GetRow()
        {
            return Grid.GetRow(theTank);
        }

        public void SetRow(int newRow)
        {
            theTank.SetValue(Grid.RowProperty, newRow);
            theTank.SetValue(Grid.ColumnSpanProperty, 1);
            theTank.SetValue(Grid.RowSpanProperty, 2);
        }

        public int GetColumn()
        {
            return Grid.GetColumn(theTank);
        }

        public void SetColumn(int newColumn)
        {
            theTank.SetValue(Grid.ColumnProperty, newColumn);
            theTank.SetValue(Grid.ColumnSpanProperty, 2);
            theTank.SetValue(Grid.RowSpanProperty, 1);
        }

    }
}
