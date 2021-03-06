﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alpha.ConsoleApp.Tests;

namespace Alpha.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Execute();
            Console.ReadLine();
        }

        public static async void Execute()
        {
            var instances = Instance.FindInstancesByInterface<ITest>();
            //Parallel.ForEach(instances, async m =>
            //{
            //    var job = Activator.CreateInstance(m) as ITask;
            //    await job.Execute();
            //});
            foreach (var type in instances)
            {
                var job = Activator.CreateInstance(type) as ITest;
                await job.Execute();
            }
        }
    }
}
