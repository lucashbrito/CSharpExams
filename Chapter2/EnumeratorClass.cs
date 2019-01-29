using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter2
{
    class EnumeratorClass
    {
        public void UsingEnumerator()
        {
            var stringEnumerator = "Hello world".GetEnumerator();
            while (stringEnumerator.MoveNext())
            {
                Console.Write(stringEnumerator.Current);
            }
            Console.ReadKey();
        }
    }
}
