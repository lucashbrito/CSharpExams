using ConsoleApp.Chapters;

namespace ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            Chapter4();
        }

        static void Chapter1()
        {
            var chapter = new Chapter1Class();
            chapter.MultiThreads();
            chapter.Task();
        }

        static void Chapter2()
        {
            var chapter = new Chapter2Class();
            chapter.UsingBoxinAndUnBoxing();
            chapter.UsingCodeDom();
            chapter.UsingConversions();
            chapter.UsingDisposableAndFinalizer();
            chapter.UsingDynamic();
            chapter.UsingExplicity();
            chapter.UsingExtensionMethods();
            chapter.UsingGenericClass();
            chapter.UsingLambda();
            chapter.UsingNullable();
            chapter.UsingStrings();
            chapter.UsingYields();
            chapter.UsingWeakReference();
            chapter.UsingWorkWithEnum();
        }

        static void Chapter3()
        {
            var chapter = new Chapter3Class();
            chapter.UsingPerfomanceMonitor();
        }

        static void Chapter4()
        {
            var chapter = new Chapter4Class();

            chapter.UsingAsynchronous();
            chapter.UsingDirectoryClass();
            chapter.UsingDriveInformation();
            chapter.UsingFileStream();
            chapter.UsingWebRequestAndWebResponse();

        }
    }
}
