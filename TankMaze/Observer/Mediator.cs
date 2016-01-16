using System.Collections;

namespace TankMaze.Observer
{
    static class Mediator
    {
        private static ArrayList observsers = new ArrayList();

        public static void addObserver(Subject subject)
        {
            Observer observer = new Observer(subject);
            observsers.Add(observer);
        }

        public static void removeObserver(Subject subject)
        {
            observsers.Remove(subject.getObserver());
            subject.RemoveObserver();
        }
    }
}
