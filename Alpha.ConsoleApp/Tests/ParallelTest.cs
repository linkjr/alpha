using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.ConsoleApp.Tests
{
    public class ParallelTest : BaseTest
    {
        public override void Init()
        {
            var nums = new List<int>();
            for (int i = 0; i < 500; i++)
            {
                nums.Add(i);
                Console.WriteLine("CurrentId:{0}, item:{1}, date:{2}", Task.CurrentId, i, DateTime.Now.Millisecond);
            }
            Parallel.ForEach(nums, item =>
            {
                Console.WriteLine("CurrentId:{0}, item:{1}, date:{2}", Task.CurrentId, item, DateTime.Now.Millisecond);
            });
        }
    }
}
