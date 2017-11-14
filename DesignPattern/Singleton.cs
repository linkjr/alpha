using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public sealed class LockSingleton
    {
        private static LockSingleton _instance;
        private static readonly object _syncObject;

        //init.
        static LockSingleton()
        {
            _syncObject = new object();
        }

        private LockSingleton() { }

        public static LockSingleton Instance
        {
            get
            {
                if (_instance == null)
                    lock (_syncObject)
                        if (_instance == null)
                            _instance = new LockSingleton();
                return _instance;
            }
        }
    }

    //Use sealed ensure not be inherited by other class which can be inherited.
    public sealed class Singleton
    {
        private static Singleton _instance;

        //init.
        static Singleton()
        {
            _instance = new Singleton();
        }

        //private ensure can't not be initialized by external object.
        private Singleton() { }

        public static Singleton Instance
        {
            get { return _instance; }
        }
    }
}
