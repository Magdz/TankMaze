using System;
using System.Windows.Media.Imaging;

namespace TankMaze.Models
{
    class StoneWall : Wall
    {
        //int ID = 3;
        private BitmapImage Block = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/BlockWall.png", UriKind.Absolute));
        private BitmapImage Horizontal = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/HorizontalWall.png", UriKind.Absolute));
        private BitmapImage Vertical = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/VerticalWall.png", UriKind.Absolute));

        public StoneWall(int Row, int Column, Direction direction) : base(Row, Column)
        {
            Source(direction);
        }

        public override void Source(Direction direction)
        {
            if (direction == Direction.Up || direction == Direction.Down) theComponent.Source = Vertical;
            else if (direction == Direction.Left || direction == Direction.Right) theComponent.Source = Horizontal;
            else theComponent.Source = Block;
        }
    }
}
