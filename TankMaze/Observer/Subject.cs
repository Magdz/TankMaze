using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankMaze.Observer
{
    interface Subject
    {
        void Add(Observer o);
        void Remove(Observer o);
        void Notify();
    }
}
