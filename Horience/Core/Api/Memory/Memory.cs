using System;
using System.Diagnostics;

namespace Horience.Core.Api.Memory
{
    class Memory : MemoryBase
    {
        private readonly string ProcessName;
        private readonly Process ProcessInstance;

        public Memory(string ProcessName)
        {
            this.ProcessName = ProcessName;
            this.ProcessInstance = GetProcessFromName(ProcessName);
        }

        private Process GetProcessFromName(string name)
        {
            if (Process.GetProcessesByName(name).Length > 0)
            {
                return Process.GetProcessesByName(name)[0];
            }
            else
            {
                throw new Exception("Process " + name + " does not exist.");
            }
        }
    }
}
