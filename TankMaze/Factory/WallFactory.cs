using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankMaze.Models;

namespace TankMaze.Factory
{
    class WallFactory
    {
        public Wall createWall (int ID)
        {
            if (ID == 4) return new BagsWall();
            if (ID == 3) return new StoneWall();
            return null;
        }
    }
}
