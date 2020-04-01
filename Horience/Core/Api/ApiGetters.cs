using Horience.Core.Api.Colors;

namespace Horience.Core.Api
{
    class ApiGetters
    {
        public ColorHelper GetColor()
        {
            return new ColorHelper();
        }

        public Memory.Memory GetMemory(string ProcessName)
        {
            return new Memory.Memory(ProcessName);
        }
    }
}
