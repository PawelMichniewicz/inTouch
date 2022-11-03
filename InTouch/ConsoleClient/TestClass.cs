using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleClient
{
    internal class TestClass
    {
        Task<int> myTask;
        ValueTask<int> myValueTask;

        public TestClass()
        {
            myTask = new Task<int>(() =>
            {
                Task.Delay(3000).Wait();
                return 5;
            });

            myValueTask = new ValueTask<int>(5);
        }

        public async Task go()
        {
            Enumerable.Range(1, 3).Select(id =>
            {;
                new Thread(async () =>
                {
                    Console.WriteLine($"thread {id} woke up");
                    var x = await myTask;
                    Console.WriteLine($"thread {id} got awaited result: {x}");

                }).Start();
                return true;
            }).ToArray();

            myTask.Start();

            await myTask;
        }
    }
}
