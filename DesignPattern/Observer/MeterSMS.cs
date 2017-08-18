using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Observer
{
    public class MeterSMS : Observer<Meter>
    {
        public override void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public override void OnError(Exception error)
        {
            Console.WriteLine("SMS：数据异常。");
        }

        public override void OnNext(Meter value)
        {
            if (value.KWH <= 5)
                Console.WriteLine("SMS：您的电量还有{0}度，请你及时续费以免停电。", value.KWH);
        }
    }
}
