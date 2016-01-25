using System;
using System.Threading;
using TankMaze.Models;
using TankMaze.Object_Pool;
using TankMaze.Views;

namespace TankMaze.Controllers
{
    class EnemyTankAI
    {
        private EnemyTank theEnemyTank;
        private MazeComponent.Direction[] directions = { MazeComponent.Direction.Down, MazeComponent.Direction.Left, MazeComponent.Direction.Right, MazeComponent.Direction.Up };
        private System.Timers.Timer timer;

        public EnemyTankAI(EnemyTank theEnemyTank)
        {
            this.theEnemyTank = theEnemyTank;
            timer = new System.Timers.Timer();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Step);
            timer.Interval = 1000;
            timer.Enabled = true;
        }

        private void Move()
        {
            PlayGround Ground = (PlayGround)ObjectPool.getObject(ObjectPool.Type.PlayGround, 0);
            Random randomDirection = new Random();
            bool run = true;

            theEnemyTank.Dispatcher.Invoke(() =>
            {
                while (run)
                {
                    int goRow = theEnemyTank.GetRow();
                    int goColumn = theEnemyTank.GetColumn();
                    MazeComponent.Direction goDirection = directions[randomDirection.Next(0, 3)];
                    try
                    {
                        if (goDirection == MazeComponent.Direction.Up)
                        {
                            if (goRow == 0) continue;
                            goRow--;
                            if (goDirection == MazeComponent.Direction.Down) goRow++;
                            else if (goDirection == MazeComponent.Direction.Right) goColumn++;
                        }
                        else if (goDirection == MazeComponent.Direction.Down)
                        {
                            if (goRow == Ground.TheGround.RowDefinitions.Count - 2 && goDirection == MazeComponent.Direction.Down) continue;
                            else if (goRow == Ground.TheGround.RowDefinitions.Count - 1) continue;
                            goRow++;
                            if (goDirection != MazeComponent.Direction.Down) goRow--;
                            if (goDirection == MazeComponent.Direction.Right) goColumn++;
                        }
                        else if (goDirection == MazeComponent.Direction.Left)
                        {
                            if (goColumn == 0) continue;
                            goColumn--;
                            if (goDirection == MazeComponent.Direction.Down) goRow++;
                            else if (goDirection == MazeComponent.Direction.Right) goColumn++;
                        }
                        else if (goDirection == MazeComponent.Direction.Right)
                        {
                            if (goColumn == Ground.TheGround.ColumnDefinitions.Count - 2 && goDirection == MazeComponent.Direction.Right) continue;
                            else if (goColumn == Ground.TheGround.ColumnDefinitions.Count - 1) continue;
                            goColumn++;
                            if (goDirection != MazeComponent.Direction.Right) goColumn--;
                            if (goDirection == MazeComponent.Direction.Down) goRow++;
                        }
                        if (CollisionDetector.WallCheck(goRow, goColumn)) continue;
                        if (goDirection == MazeComponent.Direction.Down || goDirection == MazeComponent.Direction.Up)
                        {
                            if (CollisionDetector.WallCheck(goRow + 1, goColumn)) continue;
                            theEnemyTank.SetRow(goRow + 1);
                            theEnemyTank.SetColumn(goColumn);
                            theEnemyTank.SetRow(goRow);
                        }
                        else if (goDirection == MazeComponent.Direction.Left || goDirection == MazeComponent.Direction.Right)
                        {
                            if (CollisionDetector.WallCheck(goRow, goColumn + 1)) continue;
                            theEnemyTank.SetColumn(goColumn + 1);
                            theEnemyTank.SetRow(goRow);
                            theEnemyTank.SetColumn(goColumn);
                        }
                        theEnemyTank.Source(goDirection);
                        throw new Exception();
                    }
                    catch (Exception)
                    {
                        run = false;
                    }
                }
            });
        }

        private void Step(object sender, System.Timers.ElapsedEventArgs e)
        {
            Thread enemyTankThread = new Thread(Move);
            enemyTankThread.Start();
        }
    }
}
