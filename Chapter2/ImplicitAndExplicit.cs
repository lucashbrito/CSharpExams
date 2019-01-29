using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter2
{
    class ImplicitAndExplicit
    {
        public void Main()
        {
            var miles = new Miles(100);
            Kilometers kilometers = miles;//implicity convert miles to km. 
            Console.Write($"kilometers:{kilometers.Distances}");

            int intMiles = (int)miles;
            Console.WriteLine($"Int Miles: {intMiles}");
        }
    }


    public class Kilometers
    {
        public double Distances { get; set; }
        public Kilometers(double distance)
        {
            Distances = distance;
        }
    }

    public class Miles
    {
        public double Distances { get; set; }
        public Miles(double distance)
        {
            Distances = distance;
        }

        public static implicit operator Kilometers(Miles t)
        {
            Console.Write("implicit conversion from miles to kilometers");
            return new Kilometers(t.Distance * 1.6);
        }

        public static explicit operator int(Miles t)
        {
            Console.Write("Explicit conversion from miles to int");
            return (int)(t.Distance + 0.5);
        }
    }
}
