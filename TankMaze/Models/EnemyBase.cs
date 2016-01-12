using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using TankMaze.Object_Pool;
using TankMaze.Views;

namespace TankMaze.Models
{
    class EnemyBase
    {
        //int ID = 2;
        private BitmapImage BaseUp = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/BaseUp.png", UriKind.Absolute));
        private BitmapImage BaseDown = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/BaseDown.png", UriKind.Absolute));
        private BitmapImage BaseLeft = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/BaseLeft.png", UriKind.Absolute));
        private BitmapImage BaseRight = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/BaseRight.png", UriKind.Absolute));
        private Image theBase { get; }

        public enum Direction
        {
            Up, Down, Left, Right
        }

        public EnemyBase(int Row, int Column)
        {
            PlayGround Ground = (PlayGround)ObjectPool.getObject(ObjectPool.Type.PlayGround, 0);
            theBase = new Image();
            Source(Direction.Left);
            SetColumn(Column);
            SetRow(Row);
            Ground.TheGround.Children.Add(theBase);
        }

        public void Source(Direction direction)
        {
            if (direction == Direction.Up) theBase.Source = BaseUp;
            else if (direction == Direction.Down) theBase.Source = BaseDown;
            else if (direction == Direction.Left) theBase.Source = BaseLeft;
            else if (direction == Direction.Right) theBase.Source = BaseRight;
        }

        public int GetRow()
        {
            return Grid.GetRow(theBase);
        }

        public void SetRow(int newRow)
        {
            theBase.SetValue(Grid.RowProperty, newRow);
        }

        public int GetColumn()
        {
            return Grid.GetColumn(theBase);
        }

        public void SetColumn(int newColumn)
        {
            theBase.SetValue(Grid.ColumnProperty, newColumn);
        }
    }
}
