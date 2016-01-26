using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using TankMaze.Controllers;

namespace TankMaze.Models
{
    class EnemyTank : MazeComponent
    {
        //int ID = 9; // the tank takes two cells
        private BitmapImage UpImage = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/EnemyUp.png", UriKind.Absolute));
        private BitmapImage DownImage = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/EnemyDown.png", UriKind.Absolute));
        private BitmapImage RightImage = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/EnemyRight.png", UriKind.Absolute));
        private BitmapImage LeftImage = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/EnemyLeft.png", UriKind.Absolute));
        public Direction direction { get; private set; }
        private EnemyTankAI enemyTankAI;

        public EnemyTank(int Row, int Column, Direction direction) : base(Row, Column)
        {
            Source(direction);
            enemyTankAI = new EnemyTankAI(this);
        }
        
        public override void Source(Direction direction)
        {
            if (direction == Direction.Up) theComponent.Source = UpImage;
            else if (direction == Direction.Down) theComponent.Source = DownImage;
            else if (direction == Direction.Left) theComponent.Source = LeftImage;
            else if (direction == Direction.Right) theComponent.Source = RightImage;
            this.direction = direction;
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

        public new void Notify()
        {
            if (observer == null) return;
            observer.Update(GetRow(), GetColumn(), direction, state);
        }
    }
}
