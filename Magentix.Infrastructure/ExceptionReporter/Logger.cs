using System;
using System.IO;
using Magentix.Infrastructure.Settings;

namespace Magentix.Infrastructure.ExceptionReporter
{
    public static class Logger
    {
        private static readonly Object LockObj = new Object();

        public static void Log(string message)
        {
            lock (LockObj)
            {
                message += "######################### E N D #########################\r\n";
                File.AppendAllText(LocalSettings.DocumentPath + "\\log.txt", message);
            }
        }

        public static void Log(params Exception[] exception)
        {
            var ri = new ExceptionReportInfo();
            ri.SetExceptions(exception);
            var rg = new ExceptionReportGenerator(ri);
            Log(rg.CreateExceptionReport());
        }
    }
}
