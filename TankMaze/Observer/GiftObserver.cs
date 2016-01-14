using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankMaze.Observer
{
    class GiftObserver : Observer
    {
        private int Rowgift;
        private int Columngift;
        private bool Stategift;
        public GiftObserver(Subject s)
        {
            s.Add(this);
        }
        public override void Update(int Row, int Column, bool State)
        {
            setRowgift(Row);
            setColumngift(Column);
            setStategift(State);
        }

        public int getRowgift()
        {
            return Rowgift;
        }

        public void setRowgift(int Rowgift)
        {
            this.Rowgift = Rowgift;
        }

        public int getColumngift()
        {
            return Columngift;
        }

        public void setColumngift(int Columnobs)
        {
            this.Columngift= Columnobs;
        }

        public bool isStategift()
        {
            return Stategift;
        }

        public void setStategift(bool Stategift)
        {
            this.Stategift = Stategift;
        }

    }
}
