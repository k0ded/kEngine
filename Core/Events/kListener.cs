using System;
using System.Collections.Generic;
using System.Reflection;

namespace kEngine.Core.Events
{
    public abstract class kListener
    {
        public List<MethodInfo> Info = new List<MethodInfo>();
        public List<kEvent> Events = new List<kEvent>();
        
        protected kListener()
        {
            foreach (var mInfo in GetType().GetMethods())
            {
                if (!TryGetAttribute(mInfo, out kListenAttribute attribute)) continue;
                
                
                Events.Add(EventHolder.GetEvent(attribute.kEvent));
                Info.Add(mInfo);
            }
        }

        private bool TryGetAttribute<T>(MethodInfo info, out T attribute) where T : Attribute
        {
            attribute = info.GetCustomAttribute<T>();
            return attribute != null;
        }
    }
}