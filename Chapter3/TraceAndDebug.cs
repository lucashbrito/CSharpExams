using System;
using System.Diagnostics;
using System.IO;

namespace Chapter3
{
    public class TraceAndDebug
    {
        public void UsingDebug()
        {
            Debug.WriteLine("Starting application");

            Debug.Indent();

            int i = 1 + 2;

            Debug.Assert(i == 3);

            Debug.WriteLineIf(i > 0, "i is greater than 0");
        }

        public void UsingTrace()
        {
            TraceSource traceSource = new TraceSource("myTraceSource", SourceLevels.All);

            traceSource.TraceInformation("Tracing application..");

            traceSource.TraceEvent(TraceEventType.Critical, 0, "Critical trace");

            traceSource.TraceData(TraceEventType.Information, 1, new object[] { "a", "b", "c" });

            traceSource.Flush();

            traceSource.Close();
        }

        public void UsingTraceListener()
        {
            Stream outputFile = File.Create("tracefile.txt");

            TextWriterTraceListener textListener = new TextWriterTraceListener(outputFile);


            TraceSource traceSource = new TraceSource("myTraceSource", SourceLevels.All);

            traceSource.Listeners.Clear();

            traceSource.Listeners.Add(textListener);

            traceSource.TraceInformation("Trace output");

            traceSource.Flush();

            traceSource.Close();
        }

        public void WritingDataInEventLog()
        {
            if (!EventLog.SourceExists("MySource"))
            {

                EventLog.CreateEventSource("MySource", "MyNewLog");

                Console.WriteLine("CreatedEventSource");

                Console.WriteLine("Please restart application");

                Console.ReadKey();

                return;
            }

            EventLog myLog = new EventLog();

            myLog.Source = "MySource";

            myLog.WriteEntry("Log event!");
        }

        public void UsingReadingEventLog()
        {

            EventLog log = new EventLog("MyNewLog");

            Console.WriteLine("Total entries: " + log.Entries.Count);

            EventLogEntry last = log.Entries[log.Entries.Count - 1];

            Console.WriteLine("Index: " + last.Index);

            Console.WriteLine("Source: " + last.Source);

            Console.WriteLine("Type: " + last.EntryType);

            Console.WriteLine("Time: " + last.TimeWritten);

            Console.WriteLine("Message: " + last.Message);
        }

        public void UsingWritingEventLog()
        {
            EventLog applicationLog = new EventLog("Application", ".", "testEventLogEvent");

            applicationLog.EntryWritten += (sender, e) =>
            {
                Console.WriteLine(e.Entry.Message);
            };

            applicationLog.EnableRaisingEvents = true;

            applicationLog.WriteEntry("Test message", EventLogEntryType.Information);

            Console.ReadKey();
        }


    }
}
