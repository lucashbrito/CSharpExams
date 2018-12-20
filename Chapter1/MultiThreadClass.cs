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

            //Background threads finish the thread when the specific thread finishs.
            thread.IsBackground = true;
            thread.Start();
        }

        public static void RunThreadUsingForeground()
        {
            var thread = new Thread(new ThreadStart(OutPutThread));

            //Foreground threads can be used to keep an application alive. Only when all foreground threads end does the common language runtime (CLR) shut down your application
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

        public static void RunGetPropertiesOfThreads()
        {
            var thread = new Thread(() => { OutPutThread(); });

            var currentCulture = thread.CurrentCulture;// Gets or sets the culture for the current thread.

            var executionContext = thread.ExecutionContext;//Gets an ExecutionContext object that contains information about the various contexts of the current thread.

            var isAlive = thread.IsAlive; // Gets a value indicating the execution status of the current thread.

            var isBackground = thread.IsBackground; // Gets or sets a value indicating whether or not a thread is a background thread.

            var isThreadPoll = thread.IsThreadPoolThread; // Gets a value indicating whether or not a thread belongs to the managed thread pool.

            var managedThreadId = thread.ManagedThreadId; //Gets a unique identifier for the current managed thread.

            var priority = thread.Priority = ThreadPriority.Highest; // Gets or sets a value indicating the scheduling priority of a thread.

            var threadState = thread.ThreadState; // Gets a value containing the states of the current thread.

            thread.Start();

            Console.WriteLine($"Culture: {currentCulture}, Context: {executionContext}, Alive: {isAlive}, Background: {isBackground}, thread pool: {isThreadPoll}, Id: {managedThreadId}, Priority: {priority}, State: {threadState}");
        }

        public static void RunGetMethodOfThreads()
        {
            var thread = new Thread(() => { OutPutThread(); });

            thread.Start();//Starts a thread.

            thread.Abort();//Raises a ThreadAbortException in the thread on which it is invoked, to begin the process of terminating the thread. Calling this method usually terminates the thread.

            Thread.AllocateDataSlot(); //Allocates an unnamed data slot on all the threads. For better performance, use fields that are marked with the ThreadStaticAttribute attribute instead.

            Thread.AllocateNamedDataSlot("name"); // Allocates a named data slot on all threads. For better performance, use fields that are marked with the ThreadStaticAttribute attribute instead.

            Thread.BeginCriticalRegion(); //Notifies a host that managed code is about to execute instructions that depend on the identity of the current physical operating system thread.

            Thread.EndCriticalRegion();//Notifies a host that managed code has finished executing instructions that depend on the identity of the current physical operating system thread.

            //Thread.FreeNamedDataSlot();//Eliminates the association between a name and a slot, for all threads in the process. For better performance, use fields that are marked with the ThreadStaticAttribute attribute instead.

            // Thread.GetData(); //Retrieves the value from the specified slot on the current thread, within the current thread's current domain. For better performance, use fields that are marked with the ThreadStaticAttribute attribute instead.

            var domain = Thread.GetDomain(); // Returns the current domain in which the current thread is running.

            var id = Thread.GetDomainID(); // Returns a unique application domain identifier

            var namedDataSlot = Thread.GetNamedDataSlot("name");// Looks up a named data slot. For better performance, use fields that are marked with the ThreadStaticAttribute attribute instead.

            thread.Interrupt();//Interrupts a thread that is in the WaitSleepJoin thread state.

            thread.Join();//Blocks the calling thread until a thread terminates, while continuing to perform standard COM and SendMessage pumping. 

            Thread.MemoryBarrier(); //Synchronizes memory access as follows: The processor executing the current thread cannot reorder instructions in such a way that memory accesses prior to the call to MemoryBarrier execute after memory accesses that follow the call to MemoryBarrier.

            Thread.ResetAbort();//Cancels an Abort requested for the current thread.

            //Thread.SetData(slot, i);// Sets the data in the specified slot on the currently running thread, for that thread's current domain. For better performance, use fields marked with the ThreadStaticAttribute attribute instead.

            var milliseconds = 1234;
            Thread.Sleep(milliseconds); //Makes the thread pause for a period of time.

            Thread.SpinWait(3); //Causes a thread to wait the number of times defined by the iterations parameter

            int address = 99;

            Thread.VolatileRead(ref address);// Reads the value of a field. The value is the latest written by any processor in a computer, regardless of the number of processors or the state of processor cache. This method has different overloaded forms. Only some are given above.

            Thread.VolatileWrite(ref address, 12); //Writes a value to a field immediately, so that the value is visible to all processors in the computer. This method has different overloaded forms. Only some are given above.

            var yield = Thread.Yield(); // Causes the calling thread to yield execution to another thread that is ready to run on the current processor. The operating system selects the thread to yield to.
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
