using System;
using System.IO;

namespace AuroraGSI_GTAV
{
    public static class Logger
    {
        public static void Log(object message)
        {
            try
            {
                File.AppendAllText("AuroraGSI.log", DateTime.Now + " : " + message + Environment.NewLine);
            }
            catch
            {
                //ignore
            }
        }
    }
}
