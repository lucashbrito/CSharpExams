using Chapter1;

namespace ConsoleApp.Chapters
{
    public class Chapter1Class
    {
        private CustomException _customException;
        private DelegateClass _delegateClass;
        private EventClass _eventClass;
        private ExceptionsClass _exceptionsClass;
        private LambdaExpressions _lambdaExpressions;
        private Loops _loops;

        public Chapter1Class()
        {
            _customException = new CustomException(1);
            _delegateClass = new DelegateClass();
            _eventClass = new EventClass();
            _exceptionsClass = new ExceptionsClass();
            _lambdaExpressions = new LambdaExpressions();
            _loops = new Loops();
        }

        public void UsingMultiThreads()
        {
            MultiThreadClass.RunThread();
            MultiThreadClass.RunThreadUsingBackGround();
            MultiThreadClass.RunThreadUsingForeground();
            MultiThreadClass.RunThreadUsingParameterized(34);
            MultiThreadClass.RuntThreadUsingStopThread();
            MultiThreadClass.RunThreadUsingThreadStaticAttribute();
            MultiThreadClass.RunThreadUsingPools();

        }

        public void UsingTask()
        {
            TaskClass.StartingTask();
            TaskClass.StartingTaskAndReturnValue();
            TaskClass.StartingTaskAddingContinuation();
            TaskClass.StartingTaskAttachingChildTaskToParentTaks();
        }

        public void UsingCustomException()
        {

        }

        public void UsingDelegate()
        {
            _delegateClass.UsingContravariance();
            _delegateClass.UsingCovariance();
            _delegateClass.UsingDelegate();
            _delegateClass.MulticastDelegate();
        }

        public void UsingEvent()
        {
            _eventClass.CreateAndRaise();
            _eventClass.Raise();
        }

        public void UsingLambda()
        {
            _lambdaExpressions.UsingActionDelegate();
            _lambdaExpressions.UsingLambdaExpression();
        }

        public void UsingLoop()
        {
            _loops.UsingMultiplesLoops();
        }
    }
}
