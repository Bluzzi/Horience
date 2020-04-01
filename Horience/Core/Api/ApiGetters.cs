using Horience.Core.Api.Colors;
using Horience.Core.Api.Memory;

namespace Horience.Core.Api
{
    class ApiGetters
    {
        public ColorHelper GetColor()
        {
            return new ColorHelper();
        }

        public MemoryEditor GetMemoryEditor()
        {
            return new MemoryEditor();
        }
    }
}
