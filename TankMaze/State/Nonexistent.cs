using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankMaze.Object_Pool;

namespace TankMaze.State
{
    class Nonexistent : State
    {
        //Defines whether an object is destroyable or not
        bool destroyableState;
        public Nonexistent()
        {
            //Sets the state to false and self destructs itself
            destroyableState = false;
            selfDestruct();
        }
        public bool getState()
        {
            return destroyableState;
        }

        private void selfDestruct()
        {
            //Self destruct on being set as nonexistent
        }
    }
}
