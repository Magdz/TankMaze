using System.Windows.Controls;
using TankMaze.Models;

namespace TankMaze.Controllers
{
    class PlayerTankController
    {
        private Grid Ground;
        private PlayerTank theTank;

        public PlayerTankController(PlayerTank theTank, Grid Ground)
        {
            this.Ground = Ground;
            this.theTank = theTank;
        }
    }
}
