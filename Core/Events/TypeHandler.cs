using System;
using System.Collections.Generic;
using System.Linq;

namespace kEngine.Core.Events
{
    public class TypeHandler
    {
        public static IEnumerable<Type> GetSubTypes(Type type)
        {
            var assembly = type.Assembly;
            return assembly.GetTypes().Where(t => t.BaseType == type);
        }

        public static void InstantiateSubTypes<T>()
        {
            var types = GetSubTypes(typeof(T));
            
            foreach (var e in types)
            {
                if (!e.IsClass) continue;
                var typeClass = (T)Activator.CreateInstance(e);
                
                if(typeof(T) == typeof(kEvent))
                    EventHolder.RegisterEvent(typeClass as kEvent);
                else if(typeof(T) == typeof(kListener))
                    EventHolder.RegisterListener(typeClass as kListener);
            }
        }
    }
}