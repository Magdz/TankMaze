using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankMaze.Observer
{
    interface Subject
    {
        void AddObserver(Observer observer);
        void RemoveObserver();
        void Notify();
        Observer getObserver();
    }
}
