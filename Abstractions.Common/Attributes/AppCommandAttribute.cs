using System;
namespace Abstractions.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AppCommandAttribute : Attribute
    {
        public string Name { get; }
        public AppCommandAttribute(string name)
        {
            Name = name;
        }
    }
}
