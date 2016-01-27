using System;
using System.Collections.Generic;
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
            PathFinder.GeneratePath();
            //PathFinder.TestPath(Ground);
            GeneratePlayer();
            GenerateEnemyBase();
            GenerateStoneWalls();
            OnPathGeneration(300, 600, 4); // BagWalls ID = 4
            OnPathGeneration(300, 400, 5); // Bombs ID = 5
            OnPathGeneration(300, 400, 7); // Ammo ID = 7
            OnPathGeneration(300, 600, 8); // Gold ID = 8
            GenerateEnemyTanks(1, 20);
            //console();
            Maze[4, 2] = 0;
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
            int Row = 3;
            int Column = 2;
            Maze[Row, Column] = 1;
            if (Maze[Row + 1, Column] == 0) Maze[Row + 1, Column] = 1;
            else Maze[Row, Column + 1] = 1;
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
            List<int> Rows = RandomNumbers(length, Ground.TheGround.RowDefinitions.Count);
            List<int> Columns = RandomNumbers(length, Ground.TheGround.ColumnDefinitions.Count);
            for (int i = 0; i < length; ++i)
            {
                if (Maze[Rows[i], Columns[i]] == -1) Maze[Rows[i], Columns[i]] = 3;
            } 
        }

        private static void OnPathGeneration(int range1, int range2, int ID)
        {
            int length = random.Next(range1, range2);
            List<int> Rows = RandomNumbers(length, Ground.TheGround.RowDefinitions.Count);
            List<int> Columns = RandomNumbers(length, Ground.TheGround.ColumnDefinitions.Count);
            for (int i = 0; i < length; ++i)
            {
                if (Maze[Rows[i], Columns[i]] == -1 || Maze[Rows[i], Columns[i]] == 0)
                {
                    if (Maze[Rows[i], Columns[i]] == 0)
                    {
                        try
                        {
                            if (random.Next(0, 1) == 0)
                            {
                                for (int j = 1; j < 3; ++j)
                                    if(Maze[Rows[i] - j, Columns[i]] != 0)
                                        Maze[Rows[i] - j, Columns[i]] = -ID;
                            }
                            else
                            {
                                for (int j = 1; j < 3; ++j)
                                    if (Maze[Rows[i], Columns[i] - j] != 0)
                                        Maze[Rows[i], Columns[i] - j] = -ID;
                            }
                        }
                        catch (Exception) { }
                    }
                    Maze[Rows[i], Columns[i]] = ID;
                }
            }
        }

        private static void GenerateEnemyTanks(int range1, int range2)
        {
            int length = random.Next(range1, range2);
            List<int> Rows = RandomNumbers(length, Ground.TheGround.RowDefinitions.Count - 1);
            List<int> Columns = RandomNumbers(length, Ground.TheGround.ColumnDefinitions.Count - 1);
            for (int i = 0; i < length; ++i)
            {
                if (Maze[Rows[i], Columns[i]] == -1 || Maze[Rows[i], Columns[i]] == 0)
                {
                    Maze[Rows[i], Columns[i]] = 9;
                    if (random.Next(0, 1) == 0) Maze[Rows[i] + 1, Columns[i]] = -9;
                    else Maze[Rows[i], Columns[i] + 1] = -9;
                }
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
                                MazeFactory.createObject(ObjectPool.Type.PlayerTank, row, column, MazeComponent.Direction.Down);
                                PlayerTankController playerController = (PlayerTankController)ObjectPool.getObject(ObjectPool.Type.PlayerTankController, 0);
                                PlayerTank playerTank = (PlayerTank)ObjectPool.getObject(ObjectPool.Type.PlayerTank, 0);
                                if (Maze[row, column + 1] == 1)
                                {
                                    playerTank.SetRow(playerTank.GetRow() - 1);
                                    playerController.Move(System.Windows.Input.Key.D);
                                }
                                else playerController.Move(System.Windows.Input.Key.S);
                            }
                            catch(Exception) { }
                            break;
                        case 2:
                            try
                            {
                                MazeFactory.createObject(ObjectPool.Type.EnemyBase, row, column, MazeComponent.Direction.Left);
                            }catch(Exception) { }
                            column += 4;
                            break;
                        case 3:
                            BuildWalls(row, column, ObjectPool.Type.StoneWall, 3);
                            break;
                        case 4:
                            BuildWalls(row, column, ObjectPool.Type.BagsWall, 4);
                            break;
                        case 5:
                            MazeFactory.createObject(ObjectPool.Type.Bomb, row, column, MazeComponent.Direction.Special);
                            break;
                        case 7:
                            MazeFactory.createObject(ObjectPool.Type.Ammo, row, column, MazeComponent.Direction.Special);
                            break;
                        case 8:
                            MazeFactory.createObject(ObjectPool.Type.Gold, row, column, MazeComponent.Direction.Special);
                            break;
                        case 9:
                            if (Maze[row + 1, column] == -9) MazeFactory.createObject(ObjectPool.Type.EnemyTank, row, column, MazeComponent.Direction.Down);
                            else MazeFactory.createObject(ObjectPool.Type.EnemyTank, row, column, MazeComponent.Direction.Left);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private static void BuildWalls(int row, int column, ObjectPool.Type type, int ID)
        {
            if (row != 0 && row != Ground.TheGround.RowDefinitions.Count - 1 && Maze[row + 1, column] == ID && Maze[row - 1, column] == ID)
            {
                if (column != 0 && column != Ground.TheGround.ColumnDefinitions.Count - 1 && (Maze[row, column + 1] == ID || Maze[row, column - 1] == ID)) MazeFactory.createObject(type, row, column, MazeComponent.Direction.Special);
                else MazeFactory.createObject(type, row, column, MazeComponent.Direction.Up);
            }
            else if (column != 0 && column != Ground.TheGround.ColumnDefinitions.Count - 1 && Maze[row, column + 1] == ID && Maze[row, column - 1] == ID)
            {
                if (row != 0 && row != Ground.TheGround.RowDefinitions.Count - 1 && (Maze[row + 1, column] == ID || Maze[row - 1, column] == ID)) MazeFactory.createObject(type, row, column, MazeComponent.Direction.Special);
                else MazeFactory.createObject(type, row, column, MazeComponent.Direction.Left);
            }
            else MazeFactory.createObject(type, row, column, MazeComponent.Direction.Special);
        }

        private static List<int> RandomNumbers(int length, int max)
        {
            List<int> Numbers = new List<int>();
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
