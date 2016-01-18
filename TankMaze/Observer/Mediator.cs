using System.Collections;
using TankMaze.Object_Pool;

namespace TankMaze.Observer
{
    static class Mediator
    {
        private static ArrayList CrashObservers = new ArrayList();
        private static ArrayList WallObservsers  = new ArrayList();
        private static ArrayList BulletsObservers = new ArrayList();
        private static Observer PlayerTankObserver;
        public static void addObserver(ObjectPool.Type type, Subject subject)
        {
            Observer observer = new Observer(subject);
            if(type==ObjectPool.Type.PlayerTank)
            {
                PlayerTankObserver = observer;
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

            
        }

        public static void removeObserver(ObjectPool.Type type ,Subject subject)
        {
            if (type == ObjectPool.Type.PlayerTank)
            {
                PlayerTankObserver = null;
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

            subject.RemoveObserver();
        }
    }
}
