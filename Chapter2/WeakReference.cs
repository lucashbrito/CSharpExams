using System;

namespace Chapter2
{
    public class WeakReference
    {
        private static WeakReference data;

        public void UsingWeakReference()
        {
            object result = GetData();
            // GC.Collect(); Uncommenting this line will make data.Target null
            result = GetData();
            Console.WriteLine(result);
        }

        private static object GetData()
        {
            if (data == null)
            {
                data = new WeakReference();
            }

            //if (data.Target == null)
            //{
            //    //data.Target = // big process
            //}

            return data;
        }
    }
}
