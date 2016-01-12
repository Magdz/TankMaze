using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankMaze.Models;

namespace TankMaze.Factory
{
    class EnemyBaseFactory
    {
        public EnemyBase createEnemyBase (int ID)
        {
            if (ID == 2) return new EnemyBase();
            return null;
        }
    }
}
