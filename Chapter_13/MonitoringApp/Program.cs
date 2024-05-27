using System.Linq;
using Packed.Shared;
using static System.Console;

namespace MonitoringApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            WriteLine("Dar hale pardazesh, sabr konid...");
            Recorder.Start();

            // روندی را شبیه سازی میکند که نیاز به مقداری منابع دارد
            int[] largeArrayOfInts = 
                Enumerable.Range(1, 10_000).ToArray();

            //....یکم زمان میبره تا کامل بشه
            System.Threading.Thread.Sleep(
                new Random().Next(5, 10) * 1000);

            Recorder.Stop();
            */

            int[] numbers = Enumerable.Range(1, 50_000).ToArray();

            Recorder.Start();
            WriteLine("Estefade az string ba +");
            string s = "";
            for (int i = 0; i < numbers.Length; i++)
            {
                s += numbers[i] + ", ";
            }
            Recorder.Stop();

            Recorder.Start();
            WriteLine("Estefadeh az StringBuilder");
            var builder = new System.Text.StringBuilder();
            for (int i = 0; i < numbers.Length; i++)
            {
                builder.Append(numbers[i]) ; builder.Append(", ");
            }
            Recorder.Stop();
        }
    }
}