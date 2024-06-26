﻿using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Console;

namespace AsyncstreamBazi
{
    public class Program
    {   

        static async IAsyncEnumerable<int> GetNumbers()
        {
            var r = new Random();

            System.Threading.Thread.Sleep(r.Next(1000, 2000));
            yield return r.Next(0, 101);

            System.Threading.Thread.Sleep(r.Next(1000, 2000));
            yield return r.Next(0, 101);

            System.Threading.Thread.Sleep(r.Next(1000, 2000));
            yield return r.Next(0, 101);
        }
        static async Task Main(string[] args)
        {
            await foreach (int number in GetNumbers())
            {
                WriteLine($"Adad: {number}");
            }
        }
    }
}