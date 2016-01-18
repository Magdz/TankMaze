using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankMaze.Observer
{
    class Observer
    {
        private Subject subject { get; }
        public int Row { get; private set; }
        public int Column { get; private set; }

        public Observer(Subject subject)
        {
            this.subject = subject;
            subject.AddObserver(this);
            subject.Notify();
        }
        public void Update(int Row, int Column)
        {
            this.Row = Row;
            this.Column = Column;
        }
    }
}
