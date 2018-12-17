using Chapter3;

namespace ConsoleApp.Chapters
{
    public class Chapter3Class
    {
        private PerfomanceMonitor _perfomanceMonitor;
        private CAS _cas;
        private Certificate _certificate;
        private Customer _customer;
        private DebugSymbol _debugSymbol;
        private EncrypterClass _encrypterClass;
        private RegularExpressionsClass _regularExpressionsClass;
        private SecureStringClass _secureStringClass;
        private StopWatchClass _stopWatchClass;
        private TraceAndDebug _traceAndDebug;

        public Chapter3Class()
        {
            _perfomanceMonitor = new PerfomanceMonitor();
            _cas = new CAS();
            _certificate = new Certificate();
            _customer = new Customer();
            _customer = new Customer();
            _debugSymbol = new DebugSymbol();
            _encrypterClass = new EncrypterClass();
            _regularExpressionsClass = new RegularExpressionsClass();
            _secureStringClass = new SecureStringClass();
            _stopWatchClass = new StopWatchClass();
            _traceAndDebug = new TraceAndDebug();
        }

        public void UsingCas()
        {
            _cas.DeclarativeCAS();
            _cas.UsingImperativeCAS();
        }

        public void UsingPerfomanceMonitor()
        {
            _perfomanceMonitor.ReadingDataPerformanceCounter();
            _perfomanceMonitor.UsingPerfomanceMonitor();
        }
    }
}
