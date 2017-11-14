using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern;

namespace Alpha.ConsoleApp.Tests
{
    public class SingletonTest : BaseTest
    {
        public override void Init()
        {
            Console.WriteLine("\tLock实现单例模式");
            Parallel.For(0, 5, item =>
            {
                Console.WriteLine("TaskID:{0}, Instance HashCode:{1}", Task.CurrentId, LockSingleton.Instance.GetHashCode());

            });

            Console.WriteLine("\n");
            Console.WriteLine("\t静态字段赋值方式");
            Parallel.For(0, 5, item =>
            {
                Console.WriteLine("TaskID:{0}, Instance HashCode:{1}", Task.CurrentId, Singleton.Instance.GetHashCode());
            });
            Task.WaitAll();
        }
    }
}
