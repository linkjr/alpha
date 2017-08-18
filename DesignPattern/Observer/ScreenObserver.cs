using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Observer
{
    /// <summary>
    /// 表示显示器的对象。
    /// </summary>
    public class ScreenObserver
    {
        // 显示水温
        public void Show(Object sender, BoiledEventArgs e)
        {
            Console.WriteLine("Display：水快开了，当前温度：{0}度。", e.Temperature);
        }
    }
}
