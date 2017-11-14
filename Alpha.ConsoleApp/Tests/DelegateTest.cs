using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.ConsoleApp.Tests
{
    public class DelegateTest : BaseTest
    {
        public delegate void GreetingDelegate(string name);

        public override void Init()
        {
            GreetingDelegate d1 = ChineseGreeting;
            d1 += EnglisthGreeting;
            d1("123");
        }

        private void EnglisthGreeting(string name)
        {
            Console.WriteLine("English:" + name);
        }

        private void ChineseGreeting(string name)
        {
            Console.WriteLine("Chinese:" + name);
        }
    }
}
