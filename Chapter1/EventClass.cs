using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter1
{
    public class EventClass
    {
        private event EventHandler<MyArgs> onChange = delegate { };

        public event EventHandler<MyArgs> OnChange
        {
            add
            {
                lock (onChange)
                {
                    onChange += value;
                }
            }
            remove
            {
                lock (onChange)
                {
                    onChange -= value;
                }
            }
        }

        public void Raise()
        {
            var exceptions = new List<Exception>();

            foreach (Delegate handler in onChange.GetInvocationList())
            {
                try
                {
                    handler.DynamicInvoke(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }
            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            onChange(this, new MyArgs(42));
        }

        public void CreateAndRaise()
        {
            EventClass eventClass = new EventClass();

            p.OnChange += (sender, e)
                => Console.WriteLine("Subscriber 1 called");
            p.OnChange += (sender, e)
                => { throw new Exception(); };
            p.OnChange += (sender, e)
                => Console.WriteLine("Subscriber 3 called");
            try
            {
                p.Raise();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.InnerExceptions.Count);
            }
        }
    }

    public class MyArgs : EventArgs
    {
        public MyArgs(int value)
        {
            Value = value;
        }
        public int Value { get; set; }
    }
}
