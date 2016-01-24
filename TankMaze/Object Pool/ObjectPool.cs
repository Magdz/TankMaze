using System;
using System.Collections;
using System.Collections.Generic;
using TankMaze.Controllers;
using TankMaze.Models;
using TankMaze.Observer;
using TankMaze.Views;

namespace TankMaze.Object_Pool
{
    static class ObjectPool
    {

        private static PlayGround ground;
        private static PlayerTank playerTank;
        private static PlayerTankController playerController;
        private static EnemyBase enemyBase;
        private static List<Ammo> ammos = new List<Ammo>();
        private static List<BagsWall> bagWalls = new List<BagsWall>();
        private static List<Bomb> bombs = new List<Bomb>();
        private static List<Bullet> bullets = new List<Bullet>();
        private static List<EnemyTank> enemyTanks = new List<EnemyTank>();
        private static List<Gold> golds = new List<Gold>();
        private static List<StoneWall> stoneWalls = new List<StoneWall>();

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
            else if (type == Type.Gold) return golds[index];
            else if (type == Type.StoneWall) return stoneWalls[index];
            return null;
        }

        public static object getObject(Type type, int row, int column)
        {
            if (type == Type.Ammo)
            {
                foreach (Ammo ammo in ammos)
                    if (row == ammo.GetRow() && column == ammo.GetColumn()) return ammo;
            }
            else if (type == Type.BagsWall)
            {
                foreach (BagsWall bagWall in bagWalls)
                    if (row == bagWall.GetRow() && column == bagWall.GetColumn()) return bagWall;
            }
            else if (type == Type.Bomb)
            {
                foreach (Bomb bomb in bombs)
                    if (row == bomb.GetRow() && column == bomb.GetColumn()) return bomb;
            }
            else if (type == Type.Gold)
            {
                foreach (Gold gold in golds)
                    if (row == gold.GetRow() && column == gold.GetColumn()) return gold;
            }
            else if (type == Type.StoneWall)
            {
                foreach (StoneWall stoneWall in stoneWalls)
                    if (row == stoneWall.GetRow() && column == stoneWall.GetColumn()) return stoneWall;
            }
            else if (type == Type.EnemyTank)
            {
                foreach (EnemyTank enemyTank in enemyTanks)
                    if (row == enemyTank.GetRow() && column == enemyTank.GetColumn()) return enemyTank;
            }
            return null;
        }

        public static void addObject(Type type, object Obj)
        {
            if (type == Type.PlayGround) ground = (PlayGround)Obj;
            else if (type == Type.PlayerTank && playerTank == null) playerTank = (PlayerTank)Obj;
            else if (type == Type.PlayerTankController && playerController == null) playerController = (PlayerTankController)Obj;
            else if (type == Type.EnemyBase && enemyBase == null) enemyBase = (EnemyBase)Obj;
            else if (type == Type.Ammo) ammos.Add((Ammo)Obj);
            else if (type == Type.BagsWall) bagWalls.Add((BagsWall)Obj);
            else if (type == Type.Bomb) bombs.Add((Bomb)Obj);
            else if (type == Type.Bullet) bullets.Add((Bullet)Obj);
            else if (type == Type.EnemyTank) enemyTanks.Add((EnemyTank)Obj);
            else if (type == Type.Gold) golds.Add((Gold)Obj);
            else if (type == Type.StoneWall) stoneWalls.Add((StoneWall)Obj);
        }

        public static void removeObject(Type type, object Obj)
        {
            Mediator.removeObserver(type, (Subject)Obj);
            if (type == Type.PlayerTank)
            {
                playerTank = null;
                playerController = null;
            }
            else if (type == Type.EnemyBase) enemyBase = null;
            else if (type == Type.Ammo) ammos.Remove((Ammo)Obj);
            else if (type == Type.BagsWall) bagWalls.Remove((BagsWall)Obj);
            else if (type == Type.StoneWall) stoneWalls.Remove((StoneWall)Obj);
            else if (type == Type.Bomb) bombs.Remove((Bomb)Obj);
            else if (type == Type.Bullet) bullets.Remove((Bullet)Obj);
            else if (type == Type.EnemyTank) enemyTanks.Remove((EnemyTank)Obj);
            else if (type == Type.Gold) golds.Remove((Gold)Obj);
        }

        public static void Clear()
        {
            if (playerTank != null) playerTank.RemoveComponent(Type.PlayerTank);
            if (enemyBase != null) enemyBase.RemoveComponent(Type.EnemyBase);
            while(ammos.Count > 0) ammos[0].RemoveComponent(Type.Ammo);
            while(golds.Count > 0) golds[0].RemoveComponent(Type.Gold);
            while(bagWalls.Count > 0) bagWalls[0].RemoveComponent(Type.BagsWall);
            while(stoneWalls.Count > 0) stoneWalls[0].RemoveComponent(Type.StoneWall);
            while(bombs.Count > 0) bombs[0].RemoveComponent(Type.Bomb);
            while(bullets.Count > 0) bullets[0].RemoveComponent(Type.Bullet);
            while(enemyTanks.Count > 0) enemyTanks[0].RemoveComponent(Type.EnemyTank);
        }
    }
}
