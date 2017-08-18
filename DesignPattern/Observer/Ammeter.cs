using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Observer
{
    /// <summary>
    /// 表示电流表的对象。
    /// </summary>
    public class Ammeter : Subject<Meter>
    {
        public void Publish()
        {
            for (int i = 100; i >= 0; i--)
            {
                var meter = new Nullable<Meter>(new Meter(i));
                if (i == 0)
                    meter = null;
                foreach (var observer in base.observers)
                {
                    if (!meter.HasValue)
                        observer.OnError(new ArgumentNullException("meter"));
                    else
                        observer.OnNext(meter.Value);
                }
            }
        }
    }
}
