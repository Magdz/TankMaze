using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankMaze.Observer
{
    class Observer
    {
        private int Row { get; set; }
        private int Column { get; set; }

        public Observer(Subject subject)
        {
            subject.AddObserver(this);
        }
        public void Update(int Row, int Column)
        {
            this.Row = Row;
            this.Column = Column;
        }
    }
}
