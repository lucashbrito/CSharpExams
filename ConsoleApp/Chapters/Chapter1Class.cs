using Chapter1;

namespace ConsoleApp.Chapters
{
    public class Chapter1Class
    {
        public void MultiThreads()
        {
            MultiThreadClass.RunThread();
            MultiThreadClass.RunThreadUsingBackGround();
            MultiThreadClass.RunThreadUsingForeground();
            MultiThreadClass.RunThreadUsingParameterized(34);
            MultiThreadClass.RuntThreadUsingStopThread();
            MultiThreadClass.RunThreadUsingThreadStaticAttribute();
            MultiThreadClass.RunThreadUsingPools();

        }

        public void Task()
        {
            TaskClass.StartingTask();
            TaskClass.StartingTaskAndReturnValue();
            TaskClass.StartingTaskAddingContinuation();
            TaskClass.StartingTaskAttachingChildTaskToParentTaks();
        }
    }
}
