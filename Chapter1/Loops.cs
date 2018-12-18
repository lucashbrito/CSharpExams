using System;

namespace Chapter1
{
    public class Loops
    {

        public void UsingMultiplesLoops()
        {
            int[] values = { 1, 2, 3, 4, 5, 6 };

            for (int x = 0, y = values.Length - 1; x < values.Length; x++, y--)
            {
                Console.WriteLine(values[x]);
                Console.WriteLine(values[y]);
            }

            for (int index = 0; index < values.Length; index++)
            {
                if (values[index] == 4) break;
                Console.Write(values[index]);
            }

            for (int index = 0; index < values.Length; index++)
            {
                if (values[index] == 4) continue;
                Console.Write(values[index]);
            }

        }
    }
}
