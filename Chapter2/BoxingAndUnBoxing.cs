using System;

namespace Chapter2
{
    public class BoxingAndUnBoxing
    {

        public void Boxing()
        {
            int x = 43;
            object obj = x;
            Console.WriteLine($"x is {x}, obj is {obj}");
        }

        public void Unboxing()
        {
            int x = 43;
            object obj = x;
            int xObj = (int)obj;

            Console.WriteLine($"x is {x}, obj is {obj} and xobj is {xObj}");
        }
    }
}
