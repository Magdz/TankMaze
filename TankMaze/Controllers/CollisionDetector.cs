using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankMaze.Models;
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

        public static bool CrashCheck(int Row, int Column)
        {
            for(int i=0; i<Mediator.CrashObservers.Count; i++)
            {
                if(Row == Mediator.CrashObservers[i].Row && Column == Mediator.CrashObservers[i].Column)
                {
                    return true;
                }
                
            }
            return false;
        }

        public static bool EnemyBaseCheck(int Row ,int Column)
        {
            for (int i = Mediator.EnemyBaseObserver.Row; i <= Mediator.EnemyBaseObserver.Row + 5; i++) 
            {
                for (int j = Mediator.EnemyBaseObserver.Column; j <= Mediator.EnemyBaseObserver.Column + 5; j++) 
                {
                    if (Row == i && Column == j) 
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        public static bool EnemyTankCheck(int Row, int Column)
        {
            for (int i = 0; i < Mediator.EnemyTankObservers.Count; i++)
            {
                if (Row == Mediator.EnemyTankObservers[i].Row && Column == Mediator.EnemyTankObservers[i].Column)
                {
                    return true;
                }
                if (Mediator.EnemyTankObservers[i].direction == MazeComponent.Direction.Up || (Mediator.EnemyTankObservers[i].direction == MazeComponent.Direction.Down))
                {
                    if (Row == Mediator.EnemyTankObservers[i].Row + 1)
                    {
                        return true;
                    }
                }
                else if (Mediator.EnemyTankObservers[i].direction == MazeComponent.Direction.Right || (Mediator.EnemyTankObservers[i].direction == MazeComponent.Direction.Left))
                {
                    if (Column == Mediator.EnemyTankObservers[i].Column + 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    
    public static bool PlayerTankCheck(int Row, int Column)
        {
            if (Row == Mediator.PlayerTankObserver.Row && Column == Mediator.PlayerTankObserver.Column)
            {
                return true;
            }
            if (Mediator.PlayerTankObserver.direction == MazeComponent.Direction.Up || (Mediator.PlayerTankObserver.direction == MazeComponent.Direction.Down))
            {
                if (Row == Mediator.PlayerTankObserver.Row + 1)
                {
                    return true;
                }
            }
            else if (Mediator.PlayerTankObserver.direction == MazeComponent.Direction.Right || (Mediator.PlayerTankObserver.direction == MazeComponent.Direction.Left))
            {
                if (Column == Mediator.PlayerTankObserver.Column + 1)
                {
                    return true;
                }
            }
        return false;
    }
       
    }
}
}
