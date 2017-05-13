using System;
using System.Collections.Generic;
using System.Linq;
using Alpha.ConsoleApp.Jobs;

namespace Alpha.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Execute();
        }

        public static void Execute()
        {
            foreach (var type in Instance.FindInstancesByInterface<IJob>())
            {
                var job = Activator.CreateInstance(type) as IJob;
                job.Init();
            }
        }
    }
}
