using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Chapter1
{
    public class DelegateClass
    {
        public delegate int Calculate(int x, int y);
        public delegate TextWriter CovarianceDel();
        public delegate void ContravarianceDel(StreamWriter tw);

        public StreamWriter MethodStream() { return null; }
        public StringWriter MethodString() { return null; }
        public int Add(int x, int y) { return x + y; }
        void DoSomething(TextWriter tw) { }
        public int Multiply(int x, int y) { return x * y; }

        public void UsingDelegate()
        {
            Calculate cal = Add;
            Console.WriteLine(cal(2, 3));

            cal = Multiply;
            Console.WriteLine(cal(2, 3));
        }

        public void MulticastDelegate()
        {
            Calculate calculate = Add;
            calculate += Multiply;

            Console.WriteLine(calculate(2, 4));

            int invocationCount = calculate.GetInvocationList().GetLength(0);

            Console.WriteLine($"Number of methods called is {invocationCount}");

        }

        public void UsingCovariance()
        {
            //Because both StreamWriter and StringWriter inherit from TextWriter, you can use the CovarianceDel with both methods
            CovarianceDel conv = MethodStream;
            conv += MethodString;


        }

        public void UsingContravariance()
        {
            //Because the method DoSomething can work with a TextWriter, it surely can also work with a StreamWriter. Because of contravariance, you can call the delegate and pass an instance of StreamWriter to the DoSomething method.
            ContravarianceDel contravariance = DoSomething;
        }
    }
}
