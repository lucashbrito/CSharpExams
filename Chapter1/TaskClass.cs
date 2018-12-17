using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
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
    }
}
