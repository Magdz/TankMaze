using System;
using System.Windows.Media.Imaging;

namespace TankMaze.Models
{
    class Bomb : MazeComponent
    {
        //int ID = 5;
        private BitmapImage Barrels = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/Barrels.png", UriKind.Absolute));

        public Bomb(int Row, int Column, Direction direction) : base(Row, Column)
        {
            Source(direction);
        }

        public override void Source(Direction direction)
        {
            theComponent.Source = Barrels;
        }
    }
}
