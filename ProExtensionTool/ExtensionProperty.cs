using System.Runtime.CompilerServices;

namespace ProExtensionTool
{
    public class ExtensionProperty<T> : IExtensionProperty
    {
        public ExtensionProperty([CallerMemberName] string name = null)
        {
            Name = name ?? "UnknownProperty";
        }

        public string Name { get; }
        public override string ToString() => Name;
    }
}
