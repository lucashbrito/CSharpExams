using System;
using System.IO;

namespace Chapter2
{
    public class DisposableAndFinalizer : IDisposable
    {
        public FileStream Stream { get; set; }

        public DisposableAndFinalizer()
        {
            Stream = File.Open("", FileMode.Create);
        }

        ~DisposableAndFinalizer()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Stream != null)
                {
                    Stream.Close();
                }
            }
        }
    }
}
