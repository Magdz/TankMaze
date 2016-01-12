using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankMaze.Singleton
{
    class Singleton
    {
        Singleton()
        {
        }

        //Shared object for thread safety
        private static readonly object threadLock = new object();

        //Sole instance initialization
        private static Singleton singletonInstance = null;

        public static Singleton Instance
        {
            get
            {
                //Double checking
                if (singletonInstance == null)
                {
                    //Shared object lock on instantiation
                    lock (threadLock)
                    {
                        if (singletonInstance == null)
                        {
                            //Sole instance instantiation 
                            singletonInstance = new Singleton();
                        }
                    }
                }

                //Return sole instance
                return singletonInstance;
            }
        }
    }
}
