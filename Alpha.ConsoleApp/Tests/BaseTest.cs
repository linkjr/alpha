using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.ConsoleApp.Tests
{
    public abstract class BaseTest : ITest
    {
        public Task Execute()
        {
            Console.WriteLine(string.Format("-----{0}-----", this.ToString()));
            return Task.Run(() =>
            {
                this.Init();
                Console.WriteLine("\t\t\t");
            });
        }

        public abstract void Init();
    }
}
