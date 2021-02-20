using SFML.Window;

namespace kEngine.Events
{
    public struct KeyboardEventArgs
    {
        public Keyboard.Key Key { get; }
        public KeyboardEventArgs(Keyboard.Key key)
        {
            Key = key;
        }
    }
}