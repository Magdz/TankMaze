using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankMaze.Models;

namespace TankMaze.Factory
{
    class BulletFactory
    {
        public Bullet createBullet (int ID)
        {
            if (ID == 6) return new Bullet();
            return null;
        }
    }
}
