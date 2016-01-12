using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankMaze.Models;

namespace TankMaze.Factory
{
    class BombFactory
    {
        public Bomb createBomb(int ID)
        {
            if(ID == 5) return new Bomb();
            return null;
        }
    }
}
