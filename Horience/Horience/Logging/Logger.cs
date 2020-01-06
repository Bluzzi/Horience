using System;

namespace Horience.Logging
{
    class Logger
    {
        private string Prefix;

        public Logger(string prefix)
        {
            Prefix = prefix;
        }

        public void Info(string message)
        {
            DateTime dateTime = DateTime.Now;
            Console.WriteLine(LoggerColors.Aqua + "[" + dateTime.Hour + ":" + dateTime.Minute + ":" + dateTime.Second + "] [" + GetPrefix() + "/INFO] " + LoggerColors.White + message);
        }

        public void Error(string message)
        {
            DateTime dateTime = DateTime.Now;
            Console.WriteLine(LoggerColors.Red + "[" + dateTime.Hour + ":" + dateTime.Minute + ":" + dateTime.Second + "] [" + GetPrefix() + "/ERROR] " + message);
        }

        public void Debug(string message)
        {
            DateTime dateTime = DateTime.Now;
            Console.WriteLine(LoggerColors.Purple + "[" + dateTime.Hour + ":" + dateTime.Minute + ":" + dateTime.Second + "] [" + GetPrefix() + "/DEBUG] " + message);
        }

        public string GetPrefix()
        {
            return Prefix;
        }
    }
}