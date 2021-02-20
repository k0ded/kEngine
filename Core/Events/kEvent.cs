using System.Collections.Generic;
using System.Reflection;

namespace kEngine.Core.Events
{
    public abstract class kEvent
    {
        protected List<MethodInfo> _listeners = new List<MethodInfo>();
        protected List<object> _listenerTarget = new List<object>();

        public void RegisterListener(MethodInfo info, object target)
        {
            _listeners.Add(info);
            _listenerTarget.Add(target);
        }

        public abstract void Tick();

        public void Invoke<T>(T args)
        {
            for (var i = 0; i < _listeners.Count; i++)
            {
                object[] objects = {args};
                _listeners[i].Invoke(_listenerTarget[i], objects);
            }
        }
    }

    public interface kEventArguments {}
}