namespace Horience
{
    class Program
    {
        private Logger.Logger Logger = new Logger.Logger("Horience");

        static void Main(string[] args)
        {
            new Program(args);
        }

        public Program(string[] args)
        {
            GetLogger().Info("Starting Horience...");
        }

        public Logger.Logger GetLogger()
        {
            return Logger;
        }
    }
}
