using System;
using System.Collections;
using TankMaze.Factory;
using TankMaze.Models;
using TankMaze.Object_Pool;
using TankMaze.Views;

namespace TankMaze.Controllers
{
    static class MazeGenerator
    {
        private static Random random;
        private static PlayGround Ground = (PlayGround)ObjectPool.getObject(ObjectPool.Type.PlayGround, 0);
        public static int[,] Maze { get; set; }

        public static void Generate()
        {
            InitializeMaze();
            GeneratePlayer();
            GenerateEnemyBase();
            GenerateStoneWalls();
            console();
            Build();
        }

        private static void InitializeMaze()
        {
            random = new Random();
            Maze = new int[Ground.TheGround.RowDefinitions.Count, Ground.TheGround.ColumnDefinitions.Count];
            for (int row = 0; row < Ground.TheGround.RowDefinitions.Count; ++row)
            {
                for (int column = 0; column < Ground.TheGround.ColumnDefinitions.Count; ++column)
                {
                    Maze[row, column] = -1;
                }
            }
        }

        private static void GeneratePlayer()
        {
            // PlayerTank ID = 1
            Maze[3, 2] = 1;
        }

        private static void GenerateEnemyBase()
        {
            // EnemyBase ID = 2
            int Row = 28;
            int Column = 60;
            for(int i=0; i < 5; ++i)
            {
                for(int j=0; j < 5; ++j)
                {
                    Maze[Row + i, Column + j] = 2;
                }
            }
        }

        private static void GenerateStoneWalls()
        {
            // StoneWall ID = 3
            int length = random.Next(500, 1500);
            ArrayList Rows = RandomNumbers(length, Ground.TheGround.RowDefinitions.Count);
            ArrayList Columns = RandomNumbers(length, Ground.TheGround.ColumnDefinitions.Count);
            for (int i = 0; i < length; ++i)
            {
                if (Maze[(int)Rows[i], (int)Columns[i]] == -1) Maze[(int)Rows[i], (int)Columns[i]] = 3;
            } 
        }

        private static void Build()
        {
            for(int row = 0; row < Ground.TheGround.RowDefinitions.Count; ++row)
            {
                for(int column = 0; column < Ground.TheGround.ColumnDefinitions.Count; ++column)
                {
                    switch(Maze[row, column])
                    {
                        case 1:
                            try
                            {
                                if (Maze[row, column + 1] == 1) MazeFactory.createObject(ObjectPool.Type.PlayerTank, row, column, MazeComponent.Direction.Right);
                                else MazeFactory.createObject(ObjectPool.Type.PlayerTank, row, column, MazeComponent.Direction.Down);
                            }catch(Exception e) { }
                            break;
                        case 2:
                            try
                            {
                                MazeFactory.createObject(ObjectPool.Type.EnemyBase, row, column, MazeComponent.Direction.Special);
                            }catch(Exception e) { }
                            column += 4;
                            break;
                        case 3:
                            if (row != 0 && row != Ground.TheGround.RowDefinitions.Count - 1 && Maze[row + 1, column] == 3 && Maze[row - 1, column] == 3)
                            {
                                if (column != 0 && column != Ground.TheGround.ColumnDefinitions.Count - 1 && (Maze[row, column + 1] == 3 || Maze[row, column - 1] == 3)) MazeFactory.createObject(ObjectPool.Type.StoneWall, row, column, MazeComponent.Direction.Special);
                                else MazeFactory.createObject(ObjectPool.Type.StoneWall, row, column, MazeComponent.Direction.Up);
                            }
                            else if (column != 0 && column != Ground.TheGround.ColumnDefinitions.Count - 1 && Maze[row, column + 1] == 3 && Maze[row, column - 1] == 3)
                            {
                                if (row != 0 && row != Ground.TheGround.RowDefinitions.Count - 1 && (Maze[row + 1, column] == 3 || Maze[row - 1, column] == 3)) MazeFactory.createObject(ObjectPool.Type.StoneWall, row, column, MazeComponent.Direction.Special);
                                else MazeFactory.createObject(ObjectPool.Type.StoneWall, row, column, MazeComponent.Direction.Left);
                            }
                            else MazeFactory.createObject(ObjectPool.Type.StoneWall, row, column, MazeComponent.Direction.Special);
                            break;
                        case 4:
                            MazeFactory.createObject(ObjectPool.Type.BagsWall, row, column, MazeComponent.Direction.Left);
                            break;
                        case 5:
                            MazeFactory.createObject(ObjectPool.Type.Bomb, row, column, MazeComponent.Direction.Left);
                            break;
                        case 7:
                            MazeFactory.createObject(ObjectPool.Type.Ammo, row, column, MazeComponent.Direction.Left);
                            break;
                        case 8:
                            MazeFactory.createObject(ObjectPool.Type.Gold, row, column, MazeComponent.Direction.Left);
                            break;
                        case 9:
                            MazeFactory.createObject(ObjectPool.Type.EnemyTank, row, column, MazeComponent.Direction.Left);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private static ArrayList RandomNumbers(int length, int max)
        {
            ArrayList Numbers = new ArrayList();
            int count = 0;
            do
            {
                int number = random.Next(0, max);
                Numbers.Add(number);
                count++;
            } while (count < length);
            return Numbers;
        }

        private static void console()
        {
            for (int row = 0; row < Ground.TheGround.RowDefinitions.Count; ++row)
            {
                for (int column = 0; column < Ground.TheGround.ColumnDefinitions.Count; ++column)
                {
                    Console.Write(Maze[row, column]+" ");
                }
                Console.WriteLine();
            }
        }

    }
}
