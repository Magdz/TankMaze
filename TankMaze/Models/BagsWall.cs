using System;
using System.Windows.Media.Imaging;

namespace TankMaze.Models
{
    class BagsWall : Wall
    {
        //int ID = 4;
        private BitmapImage Bags = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/Bags.png", UriKind.Absolute));
        public BagsWall(int Row, int Column, Direction direction) : base(Row, Column)
        {
            Source(direction);
        }

        public override void Source(Direction direction)
        {
            theComponent.Source = Bags;
        }
    }}
