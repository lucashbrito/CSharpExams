using System;
using System.Diagnostics;
using System.Text;

namespace Chapter3
{
    public class StopWatchClass
    {
        const int numberOfIterations = 100000;

        public void UsingStopWath()
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();
            Algorithm1();
            sw.Stop();

            Console.WriteLine(sw.Elapsed);

            sw.Reset();
            sw.Start();
            Algorithm2();
            sw.Stop();

            Console.WriteLine(sw.Elapsed);
        }

        private static void Algorithm2()
        {
            string result = "";

            for (int x = 0; x < numberOfIterations; x++)
            {
                result += 'a';
            }
        }
        private static void Algorithm1()
        {
            StringBuilder sb = new StringBuilder();

            for (int x = 0; x < numberOfIterations; x++)
            {
                sb.Append('a');
            }
            string result = sb.ToString();
        }
    }
}
