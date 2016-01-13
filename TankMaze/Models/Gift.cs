using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankMaze.Models
{
    abstract class Gift : MazeComponent
    {
        public Gift(int Row, int Column) : base(Row, Column)
        {
        }
    }
}
