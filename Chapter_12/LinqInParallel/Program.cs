using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace LinqParallel
{
    public class Program
    {
        static void Main(string[] args)
        {
            var watch = Stopwatch.StartNew();
            Write("Starto vazeity ta shoro dar kone:");
            ReadLine();
            watch.Start();

            IEnumerable<int> numbers = Enumerable.Range(1 , 200_000_000);

            var squares = numbers.AsParallel()
                        .Select(numbers => numbers * numbers)
                        .ToArray();

            watch.Stop();
            WriteLine("{0:#,##0} mili sanieh tool keshid",
                    watch.ElapsedMilliseconds);
        }
    }
}