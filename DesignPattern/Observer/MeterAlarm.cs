using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Observer
{
    public class MeterAlarm : Observer<Meter>
    {
        public override void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public override void OnError(Exception error)
        {
            Console.WriteLine("Alarm：数据异常。");
        }

        public override void OnNext(Meter value)
        {
            if (value.KWH == 5)
                Console.WriteLine("Alarm：您的电量只有{0}度了，停电警告一次。", value.KWH);
        }
    }
}
