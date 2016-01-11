using TankMaze.Controllers;
using TankMaze.Models;
using TankMaze.Views;

namespace TankMaze.Object_Pool
{
    static class ObjectPool
    {
        private static PlayGround ground;
        private static PlayerTank playerTank;
        private static PlayerTankController playerController;

        public enum Type
        {
            PlayGround,
            PlayerTank,PlayerTankController,
        }
        public static object getObject(Type type,int index)
        {
            if (type == Type.PlayGround) return ground;
            else if (type == Type.PlayerTank) return playerTank;
            else if (type == Type.PlayerTankController) return playerController;
            return null;
        }

        public static void addObject(Type type, object Obj)
        {
            if (type == Type.PlayGround) ground = (PlayGround)Obj;
            else if (type == Type.PlayerTank) playerTank = (PlayerTank)Obj;
            else if (type == Type.PlayerTankController) playerController = (PlayerTankController)Obj;
        }
    }
}
