using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Media;

namespace TankMaze.Controllers
{
    static class AudioController
    {
        private static SoundPlayer bulletSound = new SoundPlayer(Properties.Resources.BulletFire);
        private static SoundPlayer coinSound = new SoundPlayer(Properties.Resources.CoinPick);
        private static SoundPlayer ammoSound = new SoundPlayer(Properties.Resources.AmmoPick);
        
        public static void menuNavigationSound()
        {
            //To be implemented
        }
        public static void menuSelectionSound()
        {
            //To be implemented
        }
        public static void playBulletSound()
        {
            bulletSound.Play();
        }

        public static void playCoinSound()
        {
           coinSound.Play();
        }
        
        public static void playAmmoSound()
        {
            ammoSound.Play();
        }

        public static void playBombSound()
        {
            //To be implemented
        }


    }
}
