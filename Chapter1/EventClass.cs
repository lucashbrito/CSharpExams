using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter1
{
    public class EventClass
    {
        private event EventHandler<EventArgsCustom> onChange = delegate { };

        public event EventHandler<EventArgsCustom> OnChange
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

            onChange(this, new EventArgsCustom(42));
        }

        public void CreateAndRaise()
        {
            EventClass eventClass = new EventClass();

            eventClass.OnChange += (sender, e)
                => Console.WriteLine("Subscriber 1 called");
            eventClass.OnChange += (sender, e)
                =>
            {
                throw new Exception();
            };
            eventClass.OnChange += (sender, e)
                => Console.WriteLine("Subscriber 3 called");
            try
            {
                eventClass.Raise();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.InnerExceptions.Count);
            }
        }
    }


    public class Publisher
    {
        public delegate void del(string x);

        public event del evt;

        public EventHandler EventHandler;

        public EventHandler<EventArgsCustom> EventHandlerCustom;

        public void CheckBalance(int x)
        {
            if (x > 250)
            {
                evt("Attention! The current balance exceds 250...");
                EventHandler(this, EventArgs.Empty);
                EventHandlerCustom(this, new EventArgsCustom("balance exceds 250... "));
            }
        }
    }

    public class Subscriber
    {
        public void HandleTheEvent(string a)
        {
            Console.WriteLine(a);
        }

        public void HandleTheEvent(object sender, EventArgs e)
        {
            Console.WriteLine($"Attention {sender} is advising that the balance is over 250 ");
        }

        public void HandleTheEvent(object sender, EventArgsCustom e)
        {
            Console.WriteLine($"Attention from {sender} {e.Message}");
        }
    }

    public class EventArgsCustom : EventArgs
    {
        public EventArgsCustom(int value)
        {
            Value = value;
        }

        public EventArgsCustom(string value)
        {
            msg = value;
        }

        public int Value { get; set; }

        private string msg;

        public string Message
        {
            get { return msg; }
            set { }
        }
    }
}
