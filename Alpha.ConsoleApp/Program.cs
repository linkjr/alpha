using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Alpha.ConsoleApp.Jobs;

namespace Alpha.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var types = Assembly.GetExecutingAssembly()
                  .GetTypes()
                  .Where(m => m.GetInterfaces().Contains(typeof(IJob)));
            foreach (var type in types)
            {
                var job = Activator.CreateInstance(type) as IJob;
                job.Init();
            }
        }
    }
}
