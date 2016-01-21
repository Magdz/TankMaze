using System.Windows.Controls;
using TankMaze.Object_Pool;
using TankMaze.Views;
using TankMaze.Observer;
using TankMaze.State;

namespace TankMaze.Models
{
    class SingeltonComponent : Singleton.Singleton<SingeltonComponent>,Subject
    {
        protected Observer.Observer observer;
        protected Image theComponent { get; }
        private State.State state { get; set; }
        protected static SingeltonComponent thePlayer = null;
        protected static SingeltonComponent theEnemyBase = null;

        public enum Direction
        {
            Up, Down, Left, Right, Special
        }
        protected SingeltonComponent() { }
        protected SingeltonComponent(int Row, int Column)
        {
            if (thePlayer != null && theEnemyBase != null) return;
            PlayGround Ground = (PlayGround)ObjectPool.getObject(ObjectPool.Type.PlayGround, 0);
            theComponent = new Image();
            SetColumn(Column);
            SetRow(Row);
            state = new Existent(ObjectPool.Type.PlayerTank);
            Ground.TheGround.Children.Add(theComponent);
        }

        public void RemoveComponent(ObjectPool.Type type)
        {
            if (type == ObjectPool.Type.PlayerTank) thePlayer = null;
            else if (type == ObjectPool.Type.EnemyBase) theEnemyBase = null;
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

        public void Source(Direction direction) { }

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
            observer.Update(GetRow(), GetColumn(), MazeComponent.Direction.Special, state);
        }

        public Observer.Observer getObserver()
        {
            return observer;
        }
    }
}
