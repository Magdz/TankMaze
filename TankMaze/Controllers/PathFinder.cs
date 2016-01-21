using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using TankMaze.Views;

namespace TankMaze.Controllers
{
    static class PathFinder
    {
        private static Random random = new Random();
        public static void GeneratePath()
        {
            int[,] Maze = MazeGenerator.Maze;
            List<int> rRows = new List<int>();
            List<int> rColumns = new List<int>();
            int Row = 3;
            int Column = 3;
            for (int i = 0; i < 15; i++)
            {
                rRows.Add(Row);
                rColumns.Add(Column);
                bool loop;
                do
                {
                    loop = false;
                    Row = random.Next(3, 28);
                    Column = random.Next(3, 60);
                    for (int j = 0; j < rColumns.Count; j++)
                    {
                        if (Column == rColumns[j] || Column == rColumns[j] + 1 || Column == rColumns[j] - 1)
                            loop = true;
                    }
                } while (loop);
            }
            rRows.Add(30);
            rColumns.Add(60);
            rColumns.Sort();
            for (int i = 0; i < rRows.Count - 1; i++)
            {
                if (rRows[i] < rRows[i + 1])
                    for (int j = rRows[i]; j <= rRows[i + 1]; j++)
                        Maze[j, rColumns[i]] = 0;
                else
                    for (int j = rRows[i]; j >= rRows[i + 1]; j--)
                        Maze[j, rColumns[i]] = 0;
                for (int j = rColumns[i]; j <= rColumns[i + 1]; j++)
                    Maze[rRows[i + 1], j] = 0;
            }
        }

        public static void TestPath (PlayGround Ground)
        {
            BitmapImage redBlock = new BitmapImage(new Uri("pack://application:,,,/TankMaze;component/Assets/RedBlock.png", UriKind.Absolute));
            for (int row = 0; row < Ground.TheGround.RowDefinitions.Count; row++)
            {
                for (int column = 0; column < Ground.TheGround.ColumnDefinitions.Count; column++)
                {
                    if (MazeGenerator.Maze[row, column] == 0)
                    {
                        Image Path = new Image();
                        Path.Source = redBlock;
                        Path.SetValue(Grid.RowProperty, row);
                        Path.SetValue(Grid.ColumnProperty, column);
                        Ground.TheGround.Children.Add(Path);
                    }
                }
            }
        }
    }
}
