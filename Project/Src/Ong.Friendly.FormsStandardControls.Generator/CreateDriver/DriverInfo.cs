using System.Collections.Generic;

namespace Ong.Friendly.FormsStandardControls.Generator.CreateDriver
{
    internal class DriverInfo<T>
    {
        public T Target { get; }
        public List<string> Usings { get; } = new List<string>();
        public List<string> Members { get; } = new List<string>();

        public DriverInfo(T target)
        {
            Target = target;
        }
    }
}
