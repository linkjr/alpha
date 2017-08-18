using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Observer
{
    /// <summary>
    /// 表示警报器的对象。
    /// </summary>
    public class AlarmObserver
    {
        public void Alert(Object sender, BoiledEventArgs e)
        {
            Console.WriteLine("Alarm：嘀嘀嘀，水已经 {0} 度了：", e.Temperature);
        }
    }
}
