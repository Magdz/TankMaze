using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankMaze.Models;
using TankMaze.Object_Pool;
using TankMaze.Observer;

namespace TankMaze.Factory
{
    static class MazeFactory
    {
        public static void createObject (ObjectPool.Type type, int Row, int Column, MazeComponent.Direction direction)
        {
            if (type == ObjectPool.Type.Ammo)
            {
                Ammo ammo = new Ammo(Row, Column, direction);
                ObjectPool.addObject(type, ammo);
                Mediator.addObserver(type, ammo);
            }
            else if (type == ObjectPool.Type.BagsWall)
            {
                BagsWall bagWall = new BagsWall(Row, Column, direction);
                ObjectPool.addObject(type, bagWall);
                Mediator.addObserver(type, bagWall);
            }
            else if (type == ObjectPool.Type.Bomb)
            {
                Bomb bomb = new Bomb(Row, Column, direction);
                ObjectPool.addObject(type, bomb);
                Mediator.addObserver(type, bomb);
            }
            else if (type == ObjectPool.Type.EnemyTank)
            {
                EnemyTank enemyTank = new EnemyTank(Row, Column, direction);
                ObjectPool.addObject(type, enemyTank);
                Mediator.addObserver(type, enemyTank);
            }
            else if (type == ObjectPool.Type.Gold)
            {
                Gold gold = new Gold(Row, Column, direction);
                ObjectPool.addObject(type, gold);
                Mediator.addObserver(type, gold);

            }
            else if (type == ObjectPool.Type.StoneWall)
            {
                StoneWall stoneWall = new StoneWall(Row, Column, direction);
                ObjectPool.addObject(type, stoneWall);
                Mediator.addObserver(type, stoneWall);
            }
            else if (type == ObjectPool.Type.Bullet)
            {
                Bullet bullet = new Bullet(Row, Column, direction);
                ObjectPool.addObject(type, bullet);
                Mediator.addObserver(type, bullet);
            }
            else if (type == ObjectPool.Type.PlayerTank)
            {
                PlayerTank playerTank = new PlayerTank(Row, Column, (SingeltonComponent.Direction) direction);
                ObjectPool.addObject(type, playerTank);
                Mediator.addObserver(type, playerTank);
            }
            else if (type == ObjectPool.Type.EnemyBase)
            {
                EnemyBase enemyBase = new EnemyBase(Row, Column, (SingeltonComponent.Direction)direction);
                ObjectPool.addObject(type, enemyBase);
                Mediator.addObserver(type, enemyBase);
            }
        }
    }
}
