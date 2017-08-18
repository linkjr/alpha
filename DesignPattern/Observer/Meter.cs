using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Observer
{
    public struct Meter
    {
        public Meter(double kwh)
            : this()
        {
            this.KWH = kwh;
        }

        public decimal Balance { get; private set; }

        public double KWH { get; private set; }
    }
}
