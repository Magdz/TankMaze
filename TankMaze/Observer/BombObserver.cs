using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankMaze.Observer
{
    class BombObserver : Observer
    {
        private int Rowbomb;
        private int Columnbomb;
        private bool Statebomb;
        public BombObserver(Subject s)
        {
            s.Add(this);
        }
     
        public override void Update(int Row, int Column, bool State)
        {
            setStatebomb(State);
            setRowbomb(Row);
            setColumnbomb(Column);
        }
        public double getRowbomb()
        {
            return Rowbomb;
        }


        public void setRowbomb(int Rowbomb)
        {
            this.Rowbomb = Rowbomb;
        }


        public int getColumnbomb()
        {
            return Columnbomb;
        }


        public void setColumnbomb(int Columnbomb)
        {
            this.Columnbomb = Columnbomb;
        }


        public bool isStatebomb()
        {
            return Statebomb;
        }


        public void setStatebomb(bool Statebomb)
        {
            this.Statebomb = Statebomb;
        }


    }
}
