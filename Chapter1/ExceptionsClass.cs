using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;

namespace Chapter1
{
    public class ExceptionsClass
    {

        //This method can be used to throw an exception and preserve the original stack trace. You can use this method even outside of a catch block
        //This feature can be used when you want to catch an exception in one thread and throw it on another thread.By using the ExceptionDispatchInfo class, you can move the exception data between threads and throw it.The.NET Framework uses this when dealing with the async/await feature added in C# 5. An exception that’s thrown on an async thread will be captured and rethrown on the executing thread.
        public void UsingExeptionDispatchInfo()
        {
            ExceptionDispatchInfo possibleException = null;

            try
            {
                string s = Console.ReadLine();
                int.Parse(s);
            }
            catch (FormatException ex)
            {
                possibleException = ExceptionDispatchInfo.Capture(ex);
            }
            if (possibleException != null)
            {
                possibleException.Throw();
            }
        }

    }
}
