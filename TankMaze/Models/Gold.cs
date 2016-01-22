using System;
using System.Windows.Media.Imaging;

namespace TankMaze.Models
{
    class Gold : Gift
    {
        //int ID = 8;
        private BitmapImage GoldDouble = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/GoldDouble.png", UriKind.Absolute));
        public static int Value = 10;

        public Gold(int Row, int Column, Direction direction) : base(Row, Column)
        {
            Source(direction);
        }

        public override void Source(Direction direction)
        {
            theComponent.Source = GoldDouble;
        }
    }
}
