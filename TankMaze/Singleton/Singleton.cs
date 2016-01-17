using System;
using System.Reflection;

namespace TankMaze.Singleton
{
   public abstract class Singleton<T> where T : class
   {
        private static T singletonInstance;
        private static object threadLock = new object();

        public static T Instance
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
                            Type childClass = typeof(T);

                            //Public constructors check
                            ConstructorInfo[] singletonChildConstructors = childClass.GetConstructors();
                            if (singletonChildConstructors.Length > 0)
                            {
                                throw new InvalidOperationException(String.Format("Child class has a public contrcutor.", childClass.Name));
                            }

                            //Sole instance creation
                            singletonInstance = (T)Activator.CreateInstance(childClass, true);
                        }
                    }
                }
                //Return sole instance
                return singletonInstance;
            }
        }

    }
}