using System;
using System.Diagnostics;
using static System.Console;
using static System.Diagnostics.Process;



namespace Packed.Shared
{
    public static class Recorder
    {
        static Stopwatch timer = new Stopwatch();
        static long bytesPhysicalBefore = 0;
        static long bytesVirtualBefore = 0;

        public static void Start()
        {
            // دو ذباله جمع کن رو مجبور میکنه تا حافظه رو آزاد کنند
            // اونایی که مورد استفاده نیستند ولی هنوز آزاد نشدن
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            // استفاده از حافظه مجازی و حقیقی را ذخیره میکند
            bytesPhysicalBefore = GetCurrentProcess().WorkingSet64;
            bytesVirtualBefore = GetCurrentProcess().
                VirtualMemorySize64;
            timer.Restart();
        }

        public static void Stop()
        {
            timer.Stop();
            long bytesPhysicalAfter = GetCurrentProcess().WorkingSet64;
            long bytesVirtualAfter = GetCurrentProcess().VirtualMemorySize64;

            WriteLine("{0:N0} Hafezeie haghighi masraf shod.",
                bytesPhysicalAfter - bytesPhysicalBefore);

            WriteLine("{0:N0} Hafezeie majazi sarf shod.",
                bytesVirtualAfter - bytesVirtualBefore);

            WriteLine("{0} time span separi shod.", timer.Elapsed);

            WriteLine("{0:N0} total mili sanieh gozasht.",
                timer.ElapsedMilliseconds);
        }
    }
}