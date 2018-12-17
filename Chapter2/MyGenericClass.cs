using System;

namespace Chapter2
{
    public class MyGenericClass<T> where T : class, new()
    {
        private T MyProperty { get; set; }

        public MyGenericClass()
        {
            MyProperty = new T();
        }

        public void MyGenericMethod<T>()
        {
            T defaultValue = default(T);
            Console.WriteLine(defaultValue);
        }
    }
}
