using System;
using System.Windows.Media.Imaging;

namespace TankMaze.Models
{
    class Ammo : Gift
    {
        //int ID = 7;
        private BitmapImage LargeAmmo = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/LargeAmmo.png", UriKind.Absolute));

        public Ammo(int Row, int Column, Direction direction) : base(Row, Column)
        {
            Source(direction);
        }

        public override void Source(Direction direction)
        {
            theComponent.Source = LargeAmmo;
        }
    }
}
