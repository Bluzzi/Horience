namespace Horience.Core.Modules
{
    class Module
    {
        public string Name 
        { get; }

        public ModeType Mode
        { get; }

        public string Category
        { get; }

        public Module(string Name, ModeType Mode, string Category)
        {
            this.Name = Name;
            this.Mode = Mode;
            this.Category = Category;
        }
    }
}
