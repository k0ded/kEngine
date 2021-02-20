using System;
using System.Collections.Generic;

namespace kEngine.Core.Events
{
    public static class EventHolder
    {
        private static Dictionary<Type, kEvent> _events = new Dictionary<Type, kEvent>();
        
        public static void RegisterEvent<T>(T kEvent) where T : kEvent
        {
            var type = kEvent.GetType();
            if (!_events.ContainsKey(type))
            {
                _events.Add(type, kEvent);
            }
            else
            {
                throw new ArgumentException("Event: " + kEvent + " is already registered");
            }
        }

        public static void RegisterListener<T>(T kListener) where T : kListener
        {
            for (int i = 0; i < kListener.Events.Count; i++)
            {
                kListener.Events[i].RegisterListener(kListener.Info[i], kListener);
            }
        }

        public static kEvent GetEvent(Type attributeKEvent)
        {
            return _events[attributeKEvent];
        }

        public static void TickEvents()
        {
            foreach (var events in _events.Values)
            {
                events.Tick();
            }
        }
    }
}