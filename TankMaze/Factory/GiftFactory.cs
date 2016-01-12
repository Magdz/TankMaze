using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankMaze.Models;

namespace TankMaze.Factory
{
    class GiftFactory
    {
        public Gift createGift (int ID)
        {
            if (ID == 8) return new Gold();
            if (ID == 7) return new Ammo();
            return null;
        }
    }
}
