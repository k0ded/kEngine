using kEngine.Core.Events;
using SFML.Window;

namespace kEngine.Events
{
    public class KeyboardEvent : kEvent
    {
        public override void Tick()
        {
            for (int i = 0; i < (int)Keyboard.Key.KeyCount; i++)
            {
                if(Keyboard.IsKeyPressed((Keyboard.Key)i))
                    Invoke(new KeyboardEventArgs((Keyboard.Key)i));
            }
        }
    }
}