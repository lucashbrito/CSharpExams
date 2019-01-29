using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter2
{
    class Constructors
    {
        static Constructors()
        {
            var message = "When the program runs, the message is printed once, before the first alien is created.The static constructor is not called when the second alien is created.";
            Console.Write(message);
        }
    }
}
