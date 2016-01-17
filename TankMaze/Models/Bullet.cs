using System;
using System.Windows.Media.Imaging;

namespace TankMaze.Models
{
    class Bullet : MazeComponent
    {
        //int ID = 6;
        private BitmapImage Horizontal = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/LaserHorizontal.png", UriKind.Absolute));
        private BitmapImage Vertical = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/LaserVertical.png", UriKind.Absolute));

        public Bullet(int Row, int Column, Direction direction) : base(Row, Column)
        {
            Source(direction);
        }

        public override void Source(Direction direction)
        {
            if (direction == Direction.Up || direction == Direction.Down) theComponent.Source = Vertical;
            else if (direction == Direction.Left || direction == Direction.Right) theComponent.Source = Horizontal;
        }
    }
}
