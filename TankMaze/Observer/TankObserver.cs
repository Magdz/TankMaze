using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankMaze.Observer
{
    class TankObserver : Observer
    {
        private int Rowtank;
        private int Columntank;
        private bool Statetank;
        public TankObserver(Subject s)
        {
            s.Add(this);
        }


        public override void Update(int Row, int Column, bool State)

        {
            setRowtank(Row);
            setColumntank(Column);
            setStatetank(State);
        }
        public double getRowtank()
        {
            return Rowtank;
        }

        public void setRowtank(int Rowtank)
        {
            this.Rowtank = Rowtank;
        }

        public double getColumntank()
        {
            return Columntank;
        }

        public void setColumntank(int Columnobs)
        {
            this.Columntank = Columnobs;
        }

        public bool isStatetank()
        {
            return Statetank;
        }

        public void setStatetank(bool Statetank)
        {
            this.Statetank = Statetank;
        }
    }
}
