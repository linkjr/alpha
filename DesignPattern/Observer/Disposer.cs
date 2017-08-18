using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Observer
{
    public class Disposer : IDisposable
    {
        private Action action;

        public Disposer(Action action)
        {
            this.action = action;
        }

        public void Dispose()
        {
            this.action();
        }
    }
}
