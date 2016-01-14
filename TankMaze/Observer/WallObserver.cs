using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankMaze.Observer
{
    class WallObserver : Observer
    {
        private int RowWall;
        private int ColumnWall;
        private bool StateWall;
        public WallObserver(Subject s)
        {
            s.Add(this);
        }


        public override void Update(int Row, int Column, bool State)

        {
            setRowWall(Row);
            setColumnWall(Column);
            setStateWall(State);
        }
        public int getRowWall()
        {
            return RowWall;
        }

        public void setRowWall(int RowWall)
        {
            this.RowWall = RowWall;
        }

        public int getColumnWall()
        {
            return ColumnWall;
        }

        public void setColumnWall(int Columnobs)
        {
            this.ColumnWall = Columnobs;
        }

        public bool isStateWall()
        {
            return StateWall;
        }

        public void setStateWall(bool StateWall)
        {
            this.StateWall = StateWall;
        }
       
    }
}
