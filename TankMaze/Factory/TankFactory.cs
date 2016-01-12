using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TankMaze.Models;

namespace TankMaze.Factory
{
    class TankFactory
    {
        private Image tank;
        public Tank createTank (int ID)
        {
            if (ID == 1) return new PlayerTank(tank);
            if (ID == 9) return new EnemyTank();
            return null;
        }
    }
}
