using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankMaze.State
{
    public interface State
    {
        //Return the implementer's state
        bool getState();
    }
}
