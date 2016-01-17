using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankMaze.Models;
using TankMaze.Object_Pool;

namespace TankMaze.Factory
{
    static class MazeFactory
    {
        public static void createObject (ObjectPool.Type type, int Row, int Column, MazeComponent.Direction direction)
        {
            if (type == ObjectPool.Type.Ammo) ObjectPool.addObject(type, new Ammo(Row, Column, direction));
            else if (type == ObjectPool.Type.BagsWall) ObjectPool.addObject(type, new BagsWall(Row, Column, direction));
            else if (type == ObjectPool.Type.Bomb) ObjectPool.addObject(type, new Bomb(Row, Column, direction));
            else if (type == ObjectPool.Type.EnemyTank) ObjectPool.addObject(type, new EnemyTank(Row, Column, direction));
            else if (type == ObjectPool.Type.Gold) ObjectPool.addObject(type, new Gold(Row, Column, direction));
            else if (type == ObjectPool.Type.StoneWall) ObjectPool.addObject(type, new StoneWall(Row, Column, direction));
            else if (type == ObjectPool.Type.Bullet) ObjectPool.addObject(type, new Bullet(Row, Column, direction));
            else if (type == ObjectPool.Type.PlayerTank) ObjectPool.addObject(type, new PlayerTank(Row, Column, (SingeltonComponent.Direction) direction));
            else if (type == ObjectPool.Type.EnemyBase) ObjectPool.addObject(type, new EnemyBase(Row, Column, (SingeltonComponent.Direction)direction));
        }
    }
}
