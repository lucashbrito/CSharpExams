using System;

namespace Chapter2
{
    public class Reflections
    {
        public void UsingReflection()
        {
            int i = 43;
            Type type = i.GetType();
        }
    }
}
