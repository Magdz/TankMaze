using System;
using System.Threading;
using TankMaze.Models;
using TankMaze.Object_Pool;
using TankMaze.Views;

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

        private void Move()
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
                        else if(CollisionDetector.CrashCheck(theBullet.GetRow(), theBullet.GetColumn()))
                        {
                            Bomb bomb = (Bomb)ObjectPool.getObject(ObjectPool.Type.Bomb, theBullet.GetRow(), theBullet.GetColumn());
                            if (bomb.state.getState()) bomb.RemoveComponent(ObjectPool.Type.Bomb);
                            throw new Exception();
                        }
                        else if(CollisionDetector.EnemyTankCheck(theBullet.GetRow(), theBullet.GetColumn()))
                        {
                            EnemyTank enemyTank = (EnemyTank)ObjectPool.getObject(ObjectPool.Type.EnemyTank, theBullet.GetRow(), theBullet.GetColumn());
                            if (enemyTank == null) enemyTank = (EnemyTank)ObjectPool.getObject(ObjectPool.Type.EnemyTank, theBullet.GetRow() - 1, theBullet.GetColumn());
                            if (enemyTank == null) enemyTank = (EnemyTank)ObjectPool.getObject(ObjectPool.Type.EnemyTank, theBullet.GetRow(), theBullet.GetColumn() - 1);
                            if (enemyTank.state.getState()) enemyTank.RemoveComponent(ObjectPool.Type.EnemyTank);
                            throw new Exception();
                        }
                        else if(CollisionDetector.EnemyBaseCheck(theBullet.GetRow(), theBullet.GetColumn()))
                        {
                            EnemyBase enemyBase = (EnemyBase)ObjectPool.getObject(ObjectPool.Type.EnemyBase, 0);
                            if (enemyBase.state.getState())
                            {
                                enemyBase.Source(SingeltonComponent.Direction.Special);
                                //enemyBase.RemoveComponent(ObjectPool.Type.EnemyBase);
                                Thread.Sleep(1000);
                                Ground.nextLevelScreen();
                            }
                            throw new Exception();
                        }
                        if (theBullet.GetColumn() > Ground.TheGround.ColumnDefinitions.Count || theBullet.GetRow() > Ground.TheGround.RowDefinitions.Count) throw new Exception();
                        if (direction == MazeComponent.Direction.Up) theBullet.SetRow(theBullet.GetRow() - 1);
                        else if (direction == MazeComponent.Direction.Down) theBullet.SetRow(theBullet.GetRow() + 1);
                        else if (direction == MazeComponent.Direction.Left) theBullet.SetColumn(theBullet.GetColumn() - 1);
                        else if (direction == MazeComponent.Direction.Right) theBullet.SetColumn(theBullet.GetColumn() + 1);
                    }
                    catch (Exception)
                    {
                        run = false;
                    }
                }
                theBullet.RemoveComponent(ObjectPool.Type.Bullet);
            });
        }

    }
}
