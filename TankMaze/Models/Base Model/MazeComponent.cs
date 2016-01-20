using System.Windows.Controls;
using TankMaze.Object_Pool;
using TankMaze.Views;
using TankMaze.Observer;
using System.Windows.Threading;
using TankMaze.State;

namespace TankMaze.Models
{
    abstract class MazeComponent : DispatcherObject,Subject
    {
        protected Observer.Observer observer;
        protected Image theComponent { get; }
        private State.State state { get; set; }

        public enum Direction
        {
            Up, Down, Left, Right, Special
        }

        public MazeComponent(int Row, int Column)
        {
            PlayGround Ground = (PlayGround)ObjectPool.getObject(ObjectPool.Type.PlayGround, 0);
            theComponent = new Image();
            SetColumn(Column);
            SetRow(Row);
            if (this is StoneWall) state = new Existent(ObjectPool.Type.StoneWall);
            else state = new Existent(ObjectPool.Type.PlayGround);
            Ground.TheGround.Children.Add(theComponent);
        }

        public void RemoveComponent(ObjectPool.Type type)
        {
            state = new Nonexistent();
            PlayGround Ground = (PlayGround)ObjectPool.getObject(ObjectPool.Type.PlayGround, 0);
            Ground.TheGround.Children.Remove(theComponent);
            ObjectPool.removeObject(type, this);
        }

        public int GetRow()
        {
            return Grid.GetRow(theComponent);
        }

        public void SetRow(int newRow)
        {
            theComponent.SetValue(Grid.RowProperty, newRow);
            Notify();
        }

        public int GetColumn()
        {
            return Grid.GetColumn(theComponent);
        }

        public void SetColumn(int newColumn)
        {
            theComponent.SetValue(Grid.ColumnProperty, newColumn);
            Notify();
        }

        public abstract void Source(Direction direction);

        public void AddObserver(Observer.Observer observer)
        {
            this.observer = observer;
        }

        public void RemoveObserver()
        {
            observer = null;
        }

        public void Notify()
        {
            if (observer == null) return;
            observer.Update(GetRow(), GetColumn(), state);
        }

        public Observer.Observer getObserver()
        {
            return observer;
        }
    }
}
