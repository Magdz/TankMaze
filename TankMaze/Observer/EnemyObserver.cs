using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankMaze.Observer
{
    class EnemyObserver : Observer
    {
        private int Rowenemy;
        private int Columnenemy;
        private bool Stateenemy;
        public EnemyObserver(Subject s)
        {
            s.Add(this);
        }
        public override void Update(int Row, int Column, bool State)
        {
            setRowenemy(Row);
            setColumnenemy(Column);
            setStateenemy(State);
        }

        public int getRowenemy()
        {
            return Rowenemy;
        }

        public void setRowenemy(int Rowenemy)
        {
            this.Rowenemy = Rowenemy;
        }

        public int getColumnenemy()
        {
            return Columnenemy;
        }

        public void setColumnenemy(int Columnobs)
        {
            this.Columnenemy = Columnobs;
        }

        public bool isStateenemy()
        {
            return Stateenemy;
        }

        public void setStateenemy(bool Stateenemy)
        {
            this.Stateenemy = Stateenemy;
        }

    }
}
}
