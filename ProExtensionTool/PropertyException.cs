using System;

namespace ProExtensionTool
{
    public abstract class ExtensionPropertyException : Exception
    {
        protected ExtensionPropertyException(string message)
            : base(message)
        {
        }
    }

    public class UndefinedPropertyException : ExtensionPropertyException
    {
        public UndefinedPropertyException(IExtensionProperty property)
            : base($"Undefined {property.Name}.")
        {
        }
    }

    public class RedefinedPropertyException : ExtensionPropertyException
    {
        public RedefinedPropertyException(IExtensionProperty property)
            : base($"Redefined {property.Name}.")
        {
        }
    }
}
