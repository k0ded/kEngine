using System.Collections.Generic;
using SFML.Graphics;
using SFML.Window;

namespace kEngine.Core
{
    public class kWindow
    {
        private RenderWindow _window;
        private bool _windowChange = false;
        
        public kWindow(uint width, uint height, string title, uint framerateCap)
        {
            var window = new RenderWindow(new VideoMode(width, height), title);
            window.SetFramerateLimit(framerateCap);
            window.SetActive();
            _window = window;
            _window.Closed += (sender, args) => Close();
        }

        public void SetTitle(string title)
        {
            _window.SetTitle(title);
        }

        public void SetSize(uint width, uint height, string title)
        {
            _windowChange = true;
            _window.Close();
            var window = new RenderWindow(new VideoMode(width, height), title);
            _window = window;
            _windowChange = false;
        }

        public void Render(IEnumerable<Shape> shapes)
        {
            if (_windowChange) return;
            _window.Clear(Color.Red);
            
            foreach (var shape in shapes)
            {
                _window.Draw(shape);
            }
            _window.Display();
        }

        public void Close()
        {
            _window.Close();
        }
    }
}