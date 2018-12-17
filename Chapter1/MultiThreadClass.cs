using System;
using System.Threading;

namespace Chapter1
{
    public static class MultiThreadClass
    {
        [ThreadStatic]
        public static int _specificThreadVariable;

        public static ThreadLocal<int> _ThreadLocal = new ThreadLocal<int>(() =>
            {
                return Thread.CurrentThread.ManagedThreadId;
            });

        public static void RunThread()
        {
            var thread = new Thread(new ThreadStart(OutPutThread));

            thread.Start();

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main thread: Do some work");
                Thread.Sleep(0);
            }

            thread.Join();
        }

        public static void RunThreadUsingBackGround()
        {
            var thread = new Thread(new ThreadStart(OutPutThread));
            thread.IsBackground = true;
            thread.Start();
        }

        public static void RunThreadUsingForeground()
        {
            var thread = new Thread(new ThreadStart(OutPutThread));
            thread.IsBackground = false;
            thread.Start();
        }

        public static void RunThreadUsingParameterized(int number)
        {
            var thread = new Thread(new ParameterizedThreadStart(OutPutThread));
            thread.Start(number);
            thread.Join();
        }

        public static void RuntThreadUsingStopThread()
        {
            var stooped = false;

            var thread = new Thread(new ThreadStart(() =>
            {
                while (!stooped)
                {
                    Console.WriteLine("Running ...");
                    Thread.Sleep(1000);
                }
            }));

            thread.Start();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            stooped = true;
            thread.Join();
        }

        public static void RunThreadUsingThreadStaticAttribute()
        {
            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    _specificThreadVariable++;
                    Console.WriteLine($"Thread A spefic variable: {_specificThreadVariable}");
                }

                for (int i = 0; i < _ThreadLocal.Value; i++)
                {
                    Console.WriteLine($"Thread A local variable: {_ThreadLocal.Value}");
                }

            }).Start();

            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    _specificThreadVariable++;
                    Console.WriteLine($"Thread B spefic variable: {_specificThreadVariable}");
                }

                for (int i = 0; i < _ThreadLocal.Value; i++)
                {
                    Console.WriteLine($"Thread B local variable: {_ThreadLocal.Value}");
                }
            }).Start();
        }

        public static void RunThreadUsingPools()
        {
            ThreadPool.QueueUserWorkItem((s) => { Console.WriteLine("Working on a thread from threadpool"); });
            Console.ReadLine();
        }

        public static void OutPutThread()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"ThreadProcess is: {i}");
                Thread.Sleep(10);
            }
        }

        public static void OutPutThread(object o)
        {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine($"Thread process is:{0}");
                Thread.Sleep(0);
            }
        }

    }
}
