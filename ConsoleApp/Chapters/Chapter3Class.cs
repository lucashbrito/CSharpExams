using Chapter3;

namespace ConsoleApp.Chapters
{
    public class Chapter3Class
    {

        private CAS _cas;
        private Certificate _certificate;
        private Customer _customer;
        private DebugSymbol _debugSymbol;
        private EncrypterClass _encrypterClass;
        private HasingClass<string> _hasingClass;
        private PerfomanceMonitor _perfomanceMonitor;
        private RegularExpressionsClass _regularExpressionsClass;
        private SecureStringClass _secureStringClass;
        private StopWatchClass _stopWatchClass;
        private TraceAndDebug _traceAndDebug;



        public Chapter3Class()
        {
            _cas = new CAS();
            _certificate = new Certificate();
            _customer = new Customer();
            _debugSymbol = new DebugSymbol();
            _encrypterClass = new EncrypterClass();
            _hasingClass = new HasingClass<string>();
            _perfomanceMonitor = new PerfomanceMonitor();
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

        public void UsingCertificate()
        {

        }

        public void UsingDebugSymbol()
        {
            _debugSymbol.DebugDirective();
            _debugSymbol.UseCustomSymbol();
        }

        public void UsingEncrypter()
        {
            _encrypterClass.ExportingAPublicKey();
            _encrypterClass.UsingKeyContainer();
            _encrypterClass.UsingPublicAndPrivateKey();
        }

        public void UsingHasing() { }

        public void UsingRegularExpression() { }

        public void UsingSecureString() { }

        public void UsingStopWatch() { }

        public void UsingTraceAndDebug() { }

        public void UsingPerfomanceMonitor()
        {
            _perfomanceMonitor.ReadingDataPerformanceCounter();
            _perfomanceMonitor.UsingPerfomanceMonitor();
        }
    }
}
