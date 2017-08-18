using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Observer
{
    public class Heater
    {
        private int temperature;
        public delegate void BoilEventHandler(object sender, BoiledEventArgs e);
        public event BoilEventHandler OnBoiled;

        protected virtual void Boil(BoiledEventArgs e)
        {
            if (this.OnBoiled != null)
                this.OnBoiled(this, e);
        }

        public void BoilWater()
        {
            for (int i = 0; i < 100; i++)
            {
                temperature = i;

                if (temperature > 95)
                {
                    var e = new BoiledEventArgs(temperature);
                    this.Boil(e);
                }
            }
        }
    }
}
