using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankMaze.Object_Pool;

namespace TankMaze.State
{
    class Existent : State
    {
        //Defines whether an object is destroyable or not
        bool destroyableState;
        public Existent(ObjectPool.Type type)
        {
            //Handling StoneWall destroyable state on instantiation
            if (type == ObjectPool.Type.StoneWall) {
                destroyableState = false;
            }
            else {
                destroyableState = true;
            }
        }
        public bool getState()
        {
            return destroyableState;
        }
    }
}
