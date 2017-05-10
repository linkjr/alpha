using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public class Singleton
    {
        private static Singleton _instance;
        private static readonly object obj = new object();

        public Singleton Instance
        {
            get
            {
                if (_instance == null)
                    lock (obj)
                        if (_instance == null)
                            _instance = new Singleton();
                return _instance;
            }
        }
    }
}
