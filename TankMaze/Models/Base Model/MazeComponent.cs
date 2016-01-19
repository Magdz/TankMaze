using System.Windows.Controls;
using TankMaze.Object_Pool;
using TankMaze.Views;
using TankMaze.Observer;
using System;
using TankMaze.State;

namespace TankMaze.Models
{
    abstract class MazeComponent : Subject
    {
        protected Observer.Observer observer;
        protected Image theComponent { get; }
        public State.State state { get; set; }

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
