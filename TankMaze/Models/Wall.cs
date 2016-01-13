namespace TankMaze.Models
{
    abstract class Wall : MazeComponent
    {
        public Wall(int Row, int Column) : base(Row, Column)
        {
        }
    }
}
