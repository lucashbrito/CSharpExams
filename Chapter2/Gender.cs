using System;

namespace Chapter2
{
    [Flags]
    public enum Gender
    {
        Male = 0x1, Female = 0x2, None = 0x0, Unknown = 0x3
    }

    public enum Days : byte { Sat = 1, Sun, Mon, Tue, Wed, Thu, Fri }
}
