using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace Chapter1
{
    public class LambdaExpressions
    {
        public delegate int Calculate(int x, int y);
        public void UsingLambdaExpression()
        {
            Calculate calc = (x, y) =>
            {
                Console.WriteLine("adding numbers");
                return x + y;
            };
            Console.WriteLine(calc(3, 4)); // Displays 7

            calc = (x, y) => x * y;
            Console.WriteLine(calc(3, 4)); // Displays 12
        }

        public void UsingActionDelegate()
        {
            Action<int, int> doenstReturnValue = (x, y) =>
            {
                Console.WriteLine(x + y);
            };

            doenstReturnValue(2, 3);

            Func<int, int, int> returnValue = (x, y) => x + y;

            Console.WriteLine(returnValue(2,3));

        }
    }
}
