using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankMaze.Observer
{
    interface Observer
    {
        void Update(double Row, double Column , bool State);
    }
}
