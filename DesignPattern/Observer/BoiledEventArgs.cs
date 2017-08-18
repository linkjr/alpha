using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Observer
{
    public class BoiledEventArgs : EventArgs
    {
        public int Temperature { get; private set; }

        public BoiledEventArgs(int temperature)
        {
            this.Temperature = temperature;
        }
    }
}
