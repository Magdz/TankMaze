using System;
using System.Collections.Generic;
using System.Threading;
using TankMaze.Models;
using TankMaze.Object_Pool;
using TankMaze.Views;

namespace TankMaze.Controllers
{
    class EnemyTankAI
    {
        private EnemyTank theEnemyTank;
        private List<MazeComponent.Direction> directions;
        private System.Timers.Timer timer;
        private static bool alive = true;
        private static bool done = false;

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
            directions = new List<MazeComponent.Direction>();
            directions.Add(MazeComponent.Direction.Down); directions.Add(MazeComponent.Direction.Left); directions.Add(MazeComponent.Direction.Right); directions.Add(MazeComponent.Direction.Up);
            Random randomDirection = new Random();
            MazeComponent.Direction goDirection;
            MazeComponent.Direction CurrentDirection = theEnemyTank.direction;
            directions.Add(CurrentDirection);
            bool run = true;

            theEnemyTank.Dispatcher.Invoke(() =>
            {
                while (run)
                {
                    int goRow = theEnemyTank.GetRow();
                    int goColumn = theEnemyTank.GetColumn();
                    try
                    {
                        goDirection = directions[randomDirection.Next(0, directions.Count - 1)];
                    }
                    catch (Exception) { break; }
                    try
                    {
                        if (goDirection == MazeComponent.Direction.Up)
                        {
                            if (goRow == 0) throw new OperationCanceledException();
                            goRow--;
                            if (CurrentDirection == MazeComponent.Direction.Down) goRow++;
                            else if (CurrentDirection == MazeComponent.Direction.Right) goColumn++;
                        }
                        else if (goDirection == MazeComponent.Direction.Down)
                        {
                            if (goRow == Ground.TheGround.RowDefinitions.Count - 2 && goDirection == MazeComponent.Direction.Down) throw new OperationCanceledException();
                            else if (goRow == Ground.TheGround.RowDefinitions.Count - 1) throw new OperationCanceledException();
                            goRow++;
                            if (CurrentDirection != MazeComponent.Direction.Down) goRow--;
                            if (CurrentDirection == MazeComponent.Direction.Right) goColumn++;
                        }
                        else if (goDirection == MazeComponent.Direction.Left)
                        {
                            if (goColumn == 0) throw new OperationCanceledException();
                            goColumn--;
                            if (CurrentDirection == MazeComponent.Direction.Down) goRow++;
                            else if (CurrentDirection == MazeComponent.Direction.Right) goColumn++;
                        }
                        else if (goDirection == MazeComponent.Direction.Right)
                        {
                            if (goColumn == Ground.TheGround.ColumnDefinitions.Count - 2 && goDirection == MazeComponent.Direction.Right) throw new OperationCanceledException();
                            else if (goColumn == Ground.TheGround.ColumnDefinitions.Count - 1) throw new OperationCanceledException();
                            goColumn++;
                            if (CurrentDirection != MazeComponent.Direction.Right) goColumn--;
                            if (CurrentDirection == MazeComponent.Direction.Down) goRow++;
                        }
                        if (CollisionDetector.WallCheck(goRow, goColumn)) throw new OperationCanceledException();
                        if (CollisionDetector.PlayerTankCheck(goRow, goColumn)) alive = false;
                        if (goDirection == MazeComponent.Direction.Down || goDirection == MazeComponent.Direction.Up)
                        {
                            if (CollisionDetector.WallCheck(goRow + 1, goColumn)) throw new OperationCanceledException();
                            if (CollisionDetector.PlayerTankCheck(goRow + 1, goColumn)) alive = false;
                            theEnemyTank.SetRow(goRow + 1);
                            theEnemyTank.SetColumn(goColumn);
                            theEnemyTank.SetRow(goRow);
                        }
                        else if (goDirection == MazeComponent.Direction.Left || goDirection == MazeComponent.Direction.Right)
                        {
                            if (CollisionDetector.WallCheck(goRow, goColumn + 1)) throw new OperationCanceledException();
                            if (CollisionDetector.PlayerTankCheck(goRow, goColumn + 1)) alive = false;
                            theEnemyTank.SetColumn(goColumn + 1);
                            theEnemyTank.SetRow(goRow);
                            theEnemyTank.SetColumn(goColumn);
                        }
                        theEnemyTank.Source(goDirection);
                        if (!alive && !done)
                        {
                            Ground.deathMenu();
                            done = true;
                        }
                        throw new Exception();
                    }
                    catch (OperationCanceledException)
                    {
                        directions.Remove(goDirection);
                        continue;
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
            try
            {
                Thread enemyTankThread = new Thread(Move);
                enemyTankThread.Start();
            }
            catch (Exception) { }
        }
    }
}
