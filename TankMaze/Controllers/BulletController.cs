using System;
using System.Threading;
using TankMaze.Models;
using TankMaze.Object_Pool;
using TankMaze.Views;
using TankMaze.State;

namespace TankMaze.Controllers
{
    class BulletController
    {
        // Controller theBullet on another Thread

        private Bullet theBullet;
        private MazeComponent.Direction direction;

        public BulletController(Bullet theBullet, MazeComponent.Direction direction)
        {
            this.theBullet = theBullet;
            this.direction = direction;
            Thread bulletThread = new Thread(Move);
            bulletThread.Start();
        }

        public void Move()
        {
            PlayGround Ground = (PlayGround)ObjectPool.getObject(ObjectPool.Type.PlayGround, 0);
            bool run = true;
            theBullet.Dispatcher.Invoke(() =>
            {
                while (run)
                {
                    try
                    {
                        if (CollisionDetector.WallCheck(theBullet.GetRow(), theBullet.GetColumn()))
                        {
                            BagsWall bagWall = (BagsWall)ObjectPool.getObject(ObjectPool.Type.BagsWall, theBullet.GetRow(), theBullet.GetColumn());
                            if (bagWall.state.getState()) bagWall.RemoveComponent(ObjectPool.Type.BagsWall);
                            throw new Exception();
                        }
                        if (theBullet.GetColumn() > Ground.TheGround.ColumnDefinitions.Count || theBullet.GetRow() > Ground.TheGround.RowDefinitions.Count) throw new Exception();
                        if (direction == MazeComponent.Direction.Up) theBullet.SetRow(theBullet.GetRow() - 1);
                        else if (direction == MazeComponent.Direction.Down) theBullet.SetRow(theBullet.GetRow() + 1);
                        else if (direction == MazeComponent.Direction.Left) theBullet.SetColumn(theBullet.GetColumn() - 1);
                        else if (direction == MazeComponent.Direction.Right) theBullet.SetColumn(theBullet.GetColumn() + 1);
                    }
                    catch (Exception e)
                    {
                        run = false;
                    }
                }
                theBullet.RemoveComponent(ObjectPool.Type.Bullet);
            });
        }

    }
}
