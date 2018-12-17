using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Chapter3
{
    public class SecureStringClass
    {
        public void UsingSecureString()
        {
            var ss = new SecureString();

            Console.Write("Please enter password: ");

            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);

                if (cki.Key == ConsoleKey.Enter) break;

                ss.AppendChar(cki.KeyChar);

                Console.Write("*");
            }
            ss.MakeReadOnly();

        }

        public static void ConvertToUnsecureString(SecureString securePassword)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                Console.WriteLine(Marshal.PtrToStringUni(unmanagedString));
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
