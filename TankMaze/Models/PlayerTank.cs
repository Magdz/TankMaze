using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using TankMaze.Controllers;
using TankMaze.Object_Pool;
using TankMaze.Views;

namespace TankMaze.Models
{
    class PlayerTank : SingeltonComponent
    {
        //int ID = 1; // the tank takes two cells 

        private BitmapImage UpImage = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/RedTankUp.png", UriKind.Absolute));
        private BitmapImage DownImage = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/RedTankDown.png", UriKind.Absolute));
        private BitmapImage RightImage = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/RedTankRight.png", UriKind.Absolute));
        private BitmapImage LeftImage = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/RedTankLeft.png", UriKind.Absolute));

        public PlayerTank(int Row, int Column, Direction direction) : base(Row, Column)
        {
            Source(direction);
            PlayerTankController playerController = new PlayerTankController(this);
            ObjectPool.addObject(ObjectPool.Type.PlayerTankController, playerController);
            playerController.Move(System.Windows.Input.Key.Right);
        }

        public override void Source(Direction direction)
        {
            if (direction == Direction.Up) theComponent.Source = UpImage;
            else if (direction == Direction.Down) theComponent.Source = DownImage;
            else if (direction == Direction.Left) theComponent.Source = LeftImage;
            else if (direction == Direction.Right) theComponent.Source = RightImage;
        }

        public new void SetRow(int newRow)
        {
            theComponent.SetValue(Grid.ColumnSpanProperty, 1);
            theComponent.SetValue(Grid.RowSpanProperty, 2);
            base.SetRow(newRow);
        }

        public new void SetColumn(int newColumn)
        {
            theComponent.SetValue(Grid.ColumnSpanProperty, 2);
            theComponent.SetValue(Grid.RowSpanProperty, 1);
            base.SetColumn(newColumn);
        }

    }
}
