using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankMaze.Observer;


namespace TankMaze.Controllers
{
    static class CollisionDetector
    {

       public static bool WallCheck(int Row,int Column)
       {
            for(int i=0;i< Mediator.WallObservsers.Count;i++)
            {
                if (Row == Mediator.WallObservsers[i].Row && Column == Mediator.WallObservsers[i].Column)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CrashCheck()
        {
            for(int i=0; i<Mediator.CrashObservers.Count; i++)
            {
                if(Mediator.PlayerTankObserver.Row == Mediator.CrashObservers[i].Row && Mediator.PlayerTankObserver.Column == Mediator.CrashObservers[i].Column)
                {
                    return true;
                }
                
            }
            return false;
        }
    }
}
