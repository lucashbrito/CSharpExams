using System;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    public static class TaskClass
    {

        public static void StartingTask()
        {
            var task = Task.Run(() =>
                {
                    for (int i = 0; i < 100; i++)
                    {
                        Console.WriteLine("*");
                    }
                }
            );

            task.Wait();
        }

        public static void StartingTaskAndReturnValue()
        {
            var task = Task.Run(() => { return 43; });
            Task<int> taskDefault = Task.Run(() => { return 43; });

            Console.WriteLine(task.Result);
            Console.WriteLine(taskDefault.Result);
        }

        public static void StartingTaskAddingContinuation()
        {
            var task = Task.Run(() =>
            {
                return 42;
            });

            task.ContinueWith((i) => { return i.Result * 2; });

            task.ContinueWith((i) => { Console.WriteLine("Canceled"); }, TaskContinuationOptions.OnlyOnCanceled);

            var completedTask = task.ContinueWith((i) => { Console.WriteLine("Completed"); }, TaskContinuationOptions.OnlyOnRanToCompletion);

            completedTask.Wait();

            Console.WriteLine(task.Result);
        }

        public static void StartingTaskAttachingChildTaskToParentTaks()
        {
            var parent = Task.Run(() =>
            {
                var results = new Int32[3];
                new Task(() => results[0] = 0, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[1] = 1, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[2] = 2, TaskCreationOptions.AttachedToParent).Start();

                return results;
            });

            var finalTask = parent.ContinueWith(parentTask =>
            {
                foreach (var result in parentTask.Result)
                {
                    Console.WriteLine(result);
                }
            });
        }

        public static void StartingTaskFactory()
        {
            var parent = Task.Run(() =>
            {
                var results = new Int32[3];

                var taskFactory = new TaskFactory(TaskCreationOptions.AttachedToParent,
                    TaskContinuationOptions.ExecuteSynchronously);

                taskFactory.StartNew(() => results[0] = 0);
                taskFactory.StartNew(() => results[1] = 1);
                taskFactory.StartNew(() => results[2] = 2);

                return results;
            });

            var finalTask = parent.ContinueWith(parentTask =>
            {
                foreach (var child in parentTask.Result)
                {
                    Console.WriteLine(child);
                }
            });
            // page39

        }

        public static void CreatingTask()
        {
            Action<object> action = (object obj) =>
            {
                Console.WriteLine("Task={0}, obj={1}, Thread={2}", Task.CurrentId, obj, Thread.CurrentThread.ManagedThreadId);
            };

            // Create a task but do not start it.
            Task t1 = new Task(action, "alpha");

            // Construct a started task
            Task t2 = Task.Factory.StartNew(action, "beta");
            // Block the main thread to demonstrate that t2 is executing
            t2.Wait();

            // Launch t1 
            t1.Start();
            Console.WriteLine("t1 has been launched. (Main Thread={0})", Thread.CurrentThread.ManagedThreadId);
            // Wait for the task to finish.
            t1.Wait();

            // Construct a started task using Task.Run.
            String taskData = "delta";
            Task t3 = Task.Run(() =>
            {
                Console.WriteLine("Task={0}, obj={1}, Thread={2}", Task.CurrentId, taskData, Thread.CurrentThread.ManagedThreadId);
            });
            // Wait for the task to finish.
            t3.Wait();

            // Construct an unstarted task
            Task t4 = new Task(action, "gamma");
            // Run it synchronously
            t4.RunSynchronously();
            // Although the task was run synchronously, it is a good practice
            // to wait for it in the event exceptions were thrown by the task.
            t4.Wait();
        }

        public static async Task RunningTheLoop()
        {
            await Task.Run(() =>
            {
                int ctr = 0;
                for (ctr = 0; ctr < 10000000; ctr++)
                {
                    Console.WriteLine($"Finished {ctr} loop iteractions");
                }
            });
        }
    }
}
