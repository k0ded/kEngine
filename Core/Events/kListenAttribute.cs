using System;

namespace kEngine.Core.Events
{
    [AttributeUsage(AttributeTargets.Method)]
    public class kListenAttribute : Attribute
    {
        public kListenAttribute(Type kEvent)
        {
            this.kEvent = kEvent;
        }
        public Type kEvent { get; }
    }
}