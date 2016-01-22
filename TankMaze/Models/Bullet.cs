using System;
using System.Windows.Media.Imaging;
using TankMaze.Controllers;

namespace TankMaze.Models
{
    class Bullet : MazeComponent
    {
        //int ID = 6;
        private BitmapImage Up = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/FireUp.png", UriKind.Absolute));
        private BitmapImage Down = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/FireDown.png", UriKind.Absolute));
        private BitmapImage Left = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/FireLeft.png", UriKind.Absolute));
        private BitmapImage Right = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/FireRight.png", UriKind.Absolute));

        public BulletController bulletController { get; private set; }

        public Bullet(int Row, int Column, Direction direction) : base(Row, Column)
        {
            Source(direction);
            bulletController = new BulletController(this, direction);
        }

        public override void Source(Direction direction)
        {
            if (direction == Direction.Up) theComponent.Source = Up;
            else if (direction == Direction.Down) theComponent.Source = Down;
            else if (direction == Direction.Left) theComponent.Source = Left;
            else if (direction == Direction.Right) theComponent.Source = Right;
        }
    }
}
