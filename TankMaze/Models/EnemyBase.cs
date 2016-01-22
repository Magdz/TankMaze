using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace TankMaze.Models
{
    class EnemyBase : SingeltonComponent
    {
        //int ID = 2;

        private BitmapImage Base = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/EnemyBase.png", UriKind.Absolute));
        private BitmapImage DestroyedBase = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/EnemyBaseDestroyed.png", UriKind.Absolute));

        public EnemyBase(int Row, int Column, Direction direction) : base(Row, Column)
        {
            if (theEnemyBase != null) return;
            Source(direction);
            theEnemyBase = Instance;
            theComponent.SetValue(Grid.ColumnSpanProperty, 5);
            theComponent.SetValue(Grid.RowSpanProperty, 5);
        }

        public new void Source(Direction direction)
        {
            if (direction != Direction.Special) theComponent.Source = Base;
            else theComponent.Source = DestroyedBase;
        }

    }
}
