using System;
using kEngine.Core.Events;

namespace kEngine.Events
{
    public class KeyboardEventListener : kListener
    {
        [kListen(typeof(KeyboardEvent))]
        public void ev(KeyboardEventArgs args)
        {
            Console.WriteLine(args.Key);
        }
    }
}