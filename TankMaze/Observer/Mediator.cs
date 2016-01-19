using System.Collections;
using System.Collections.Generic;
using TankMaze.Object_Pool;

namespace TankMaze.Observer
{
    static class Mediator
    {
        public static List<Observer> CrashObservers = new List<Observer>();
        public static List<Observer> WallObservsers  = new List<Observer>();
        public static List<Observer> BulletsObservers = new List<Observer>();
        public static List<Observer> EnemyTankObservers = new List<Observer>();
        public static Observer PlayerTankObserver;
        public static Observer EnemyBaseObserver;
        public static void addObserver(ObjectPool.Type type, Subject subject)
        {
            Observer observer = new Observer(subject);
            if(type==ObjectPool.Type.PlayerTank)
            {
                PlayerTankObserver = observer;
            }
            else if(type==ObjectPool.Type.EnemyBase)
            {
                EnemyBaseObserver = observer;
            }
            else if(type ==ObjectPool.Type.Bomb|| type == ObjectPool.Type.Gold|| type == ObjectPool.Type.Ammo)
            {
                CrashObservers.Add(observer);
            }
            else if (type == ObjectPool.Type.Bullet)
            {
                BulletsObservers.Add(observer);
            }
            else if(type == ObjectPool.Type.BagsWall|| type == ObjectPool.Type.StoneWall)
            {
                WallObservsers.Add(observer);
            }
            else if(type==ObjectPool.Type.EnemyTank)
            {
                EnemyTankObservers.Add(observer);
            }
            
        }

        public static void removeObserver(ObjectPool.Type type ,Subject subject)
        {
            if (type == ObjectPool.Type.PlayerTank)
            {
                PlayerTankObserver = null;
            }
            else if (type==ObjectPool.Type.EnemyBase)
            {
                EnemyBaseObserver = null;
            }
            else if (type == ObjectPool.Type.Bomb || type == ObjectPool.Type.Gold || type == ObjectPool.Type.Ammo)
            {
                CrashObservers.Remove(subject.getObserver());
            }
            else if (type == ObjectPool.Type.Bullet)
            {
                BulletsObservers.Remove(subject.getObserver());
            }
            else if (type == ObjectPool.Type.BagsWall || type == ObjectPool.Type.StoneWall)
            {
                WallObservsers.Remove(subject.getObserver());
            }
            else if (type==ObjectPool.Type.EnemyTank)
            {
                EnemyTankObservers.Remove(subject.getObserver());
            }

            subject.RemoveObserver();
        }
    }
}
