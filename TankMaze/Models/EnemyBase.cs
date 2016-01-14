using System;
using System.Windows.Media.Imaging;

namespace TankMaze.Models
{
    class EnemyBase : SingeltonComponent
    {
        //int ID = 2;
        private BitmapImage BaseUp = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/BaseUp.png", UriKind.Absolute));
        private BitmapImage BaseDown = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/BaseDown.png", UriKind.Absolute));
        private BitmapImage BaseLeft = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/BaseLeft.png", UriKind.Absolute));
        private BitmapImage BaseRight = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/BaseRight.png", UriKind.Absolute));

        public EnemyBase(int Row, int Column, Direction direction) : base(Row, Column)
        {
            Source(direction);
        }

        public override void Source(Direction direction)
        {
            if (direction == Direction.Up) theComponent.Source = BaseUp;
            else if (direction == Direction.Down) theComponent.Source = BaseDown;
            else if (direction == Direction.Left) theComponent.Source = BaseLeft;
            else if (direction == Direction.Right) theComponent.Source = BaseRight;
        }

    }
}
