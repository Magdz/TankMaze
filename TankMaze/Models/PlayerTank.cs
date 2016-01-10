
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace TankMaze.Models
{
    class PlayerTank : Tank
    {
        //int ID = 1; // the tank takes two cells 

        private static BitmapImage UpImage = new BitmapImage(new Uri("ms-appx:///Assets/RedTankUp.png"));
        private static BitmapImage DownImage = new BitmapImage(new Uri("ms-appx:///Assets/RedTankDown.png"));
        private static BitmapImage RightImage = new BitmapImage(new Uri("ms-appx:///Assets/RedTankRight.png"));
        private static BitmapImage LeftImage = new BitmapImage(new Uri("ms-appx:///Assets/RedTankLeft.png"));
        private Image theTank;

        public PlayerTank(Image theTank)
        {
            this.theTank = theTank;
        }

    }
}
