using System;
using System.Diagnostics;

namespace Chapter3
{
    public class PerfomanceMonitor
    {
        public void UsingPerfomanceMonitor()
        {
            Console.WriteLine("Press escape key to stop");
            using (PerformanceCounter performanceCounter = new PerformanceCounter("Memory", "Available bytes"))
            {
                string text = "Available memory:";
                Console.WriteLine(text);
                do
                {
                    while (!Console.KeyAvailable)
                    {
                        Console.WriteLine(performanceCounter.RawValue);
                        Console.SetCursorPosition(text.Length, Console.CursorTop);
                    }
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            }
        }

        public void ReadingDataPerformanceCounter()
        {
            if (CreatePerformanceCounters())
            {
                Console.WriteLine("Created performance counters");
                Console.WriteLine("Please restart application");
                Console.ReadKey();
                return;
            }

            var totalOperationsCounter = new PerformanceCounter(
                "MyCategory", "# operations executed", "", false);

            var operationsPerSecondCounter = new PerformanceCounter(
                "MyCategory", "# operations / sec", "", false);

            totalOperationsCounter.Increment();

            operationsPerSecondCounter.Increment();
        }

        private static bool CreatePerformanceCounters()
        {
            if (!PerformanceCounterCategory.Exists("MyCategory"))
            {
                CounterCreationDataCollection counters =
                    new CounterCreationDataCollection
                    {
                        new CounterCreationData("# operations executed", "Total number of operations executed",
                            PerformanceCounterType.NumberOfItems32),
                        new CounterCreationData("# operations / sec", "Number of operations executed per second",
                            PerformanceCounterType.RateOfCountsPerSecond32)
                    };
                PerformanceCounterCategory.Create("MyCategory", "Sample category for Codeproject", counters);
                return true;
            }

            return false;
        }
    }
}
