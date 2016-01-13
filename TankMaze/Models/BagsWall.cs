using System;
using System.Windows.Media.Imaging;

namespace TankMaze.Models
{
    class BagsWall : Wall
    {
        //int ID = 4;
        private BitmapImage Circular = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/CircularBags.png", UriKind.Absolute));
        private BitmapImage Horizontal = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/HorizontalBags.png", UriKind.Absolute));
        private BitmapImage Vertical = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/VerticalBags.png", UriKind.Absolute));

        public BagsWall(int Row, int Column, Direction direction) : base(Row, Column)
        {
            Source(direction);
        }

        public override void Source(Direction direction)
        {
            if (direction == Direction.Up || direction == Direction.Down) theComponent.Source = Vertical;
            else if (direction == Direction.Left || direction == Direction.Right) theComponent.Source = Horizontal;
            else theComponent.Source = Circular;
        }
    }
}
