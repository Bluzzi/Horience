using System;

namespace Horience.Logger
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
            DateTime DateTime = DateTime.Now;
            Console.WriteLine(LoggerColors.Aqua + "[" + DateTime.Hour + ":" + DateTime.Minute + ":" + DateTime.Second + "] [" + GetPrefix() + "/INFO] " + LoggerColors.White + message);
        }

        public void Error(string message)
        {
            DateTime DateTime = DateTime.Now;
            Console.WriteLine(LoggerColors.Red + "[" + DateTime.Hour + ":" + DateTime.Minute + ":" + DateTime.Second + "] [" + GetPrefix() + "/ERROR] " + message);
        }

        public void Debug(string message)
        {
            DateTime DateTime = DateTime.Now;
            Console.WriteLine(LoggerColors.Purple + "[" + DateTime.Hour + ":" + DateTime.Minute + ":" + DateTime.Second + "] [" + GetPrefix() + "/DEBUG] " + message);
        }

        public string GetPrefix()
        {
            return Prefix;
        }
    }
}