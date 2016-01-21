using System;
using TankMaze.Models;
using TankMaze.State;

namespace TankMaze.Observer
{
    class Observer
    {
        private Subject subject { get; }
        public int Row { get; private set; }
        public int Column { get; private set; }
        public State.State state { get; private set; }
        public MazeComponent.Direction direction { get; private set; }

        public Observer(Subject subject)
        {
            this.subject = subject;
            subject.AddObserver(this);
            subject.Notify();
        }
        public void Update(int Row, int Column, MazeComponent.Direction direction, State.State state)
        {
            this.Row = Row;
            this.Column = Column;
            this.state = state;
            this.direction = direction;
        }

        internal void Update(int v1, int v2, object direction, State.State state)
        {
            throw new NotImplementedException();
        }
    }
}
