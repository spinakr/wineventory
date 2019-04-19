using System;

namespace Wineventory.Domain.Decorators
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class LoggingAttribute : Attribute
    {
        public LoggingAttribute()
        {
        }
    }
}