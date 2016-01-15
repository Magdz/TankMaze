using System.Collections;
using TankMaze.Controllers;
using TankMaze.Models;
using TankMaze.Views;

namespace TankMaze.Object_Pool
{
    static class ObjectPool
    {

        private static PlayGround ground;
        private static PlayerTank playerTank;
        private static PlayerTankController playerController;
        private static EnemyBase enemyBase;
        private static ArrayList ammos = new ArrayList();
        private static ArrayList bagWalls = new ArrayList();
        private static ArrayList bombs = new ArrayList();
        private static ArrayList bullets = new ArrayList();
        private static ArrayList enemyTanks = new ArrayList();
        private static ArrayList gold = new ArrayList();
        private static ArrayList stoneWalls = new ArrayList();

        public enum Type
        {
            PlayGround,
            PlayerTank, PlayerTankController,
            Ammo, BagsWall, Bomb, Bullet, EnemyBase, EnemyTank, Gold, StoneWall
        }
        public static object getObject(Type type,int index)
        {
            if (type == Type.PlayGround) return ground;
            else if (type == Type.PlayerTank) return playerTank;
            else if (type == Type.PlayerTankController) return playerController;
            else if (type == Type.EnemyBase) return enemyBase;
            else if (type == Type.Ammo) return ammos[index];
            else if (type == Type.BagsWall) return bagWalls[index];
            else if (type == Type.Bomb) return bombs[index];
            else if (type == Type.Bullet) return bullets[index];
            else if (type == Type.EnemyTank) return enemyTanks[index];
            else if (type == Type.Gold) return gold[index];
            else if (type == Type.StoneWall) return stoneWalls[index];
            return null;
        }

        public static void addObject(Type type, object Obj)
        {
            if (type == Type.PlayGround) ground = (PlayGround)Obj;
            else if (type == Type.PlayerTank) playerTank = (PlayerTank)Obj;
            else if (type == Type.PlayerTankController) playerController = (PlayerTankController)Obj;
            else if (type == Type.EnemyBase) enemyBase = (EnemyBase)Obj;
            else if (type == Type.Ammo) ammos.Add(Obj);
            else if (type == Type.BagsWall) bagWalls.Add(Obj);
            else if (type == Type.Bomb) bombs.Add(Obj);
            else if (type == Type.Bullet) bullets.Add(Obj);
            else if (type == Type.EnemyTank) enemyTanks.Add(Obj);
            else if (type == Type.Gold) gold.Add(Obj);
            else if (type == Type.StoneWall) stoneWalls.Add(Obj);
        }
    }
}
