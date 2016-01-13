using System.Windows.Controls;
using TankMaze.Object_Pool;
using TankMaze.Views;

namespace TankMaze.Models
{
    abstract class MazeComponent
    {
        protected Image theComponent { get; }

        public enum Direction
        {
            Up, Down, Left, Right
        }

        public MazeComponent(int Row, int Column)
        {
            PlayGround Ground = (PlayGround)ObjectPool.getObject(ObjectPool.Type.PlayGround, 0);
            theComponent = new Image();
            SetColumn(Column);
            SetRow(Row);
            Ground.TheGround.Children.Add(theComponent);
        }

        public int GetRow()
        {
            return Grid.GetRow(theComponent);
        }

        public void SetRow(int newRow)
        {
            theComponent.SetValue(Grid.RowProperty, newRow);
        }

        public int GetColumn()
        {
            return Grid.GetColumn(theComponent);
        }

        public void SetColumn(int newColumn)
        {
            theComponent.SetValue(Grid.ColumnProperty, newColumn);
        }

        public abstract void Source(Direction direction);
    }
}
