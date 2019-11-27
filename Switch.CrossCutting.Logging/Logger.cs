using System;
using Microsoft.Extensions.Logging;

namespace Switch.CrossCutting.Logging
{
    public class Logger : ILoggerProvider
    {
        public void Dispose()
        {
            
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new InternalLogger();
        }
        
        private class InternalLogger : ILogger
        {
            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                //System.IO.File.AppendAllText(@"c:\temp\log.txt", formatter(state, exception));
                Console.WriteLine(formatter(state,exception));
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }
        }
    }
}