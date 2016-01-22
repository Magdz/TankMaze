using System;
using System.Windows.Media.Imaging;

namespace TankMaze.Models
{
    class StoneWall : Wall
    {
        //int ID = 3;
        private BitmapImage Wall = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/Wall.png", UriKind.Absolute));
       
        public StoneWall(int Row, int Column, Direction direction) : base(Row, Column)
        {
            Source(direction);
        }

        public override void Source(Direction direction)
        {
            theComponent.Source = Wall;
        }
    }
}
