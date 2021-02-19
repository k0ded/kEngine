using System.Collections.Generic;
using SFML.Graphics;
using SFML.Window;

namespace kEngine.Core
{
    public class kEngine
    {
        private kWindow _window;
        private bool _isPlaying = true;
        private List<Shape> _renderList;
        
        private void Initialize()
        {
            var desktopMode = VideoMode.DesktopMode;
            var width = desktopMode.Width;
            var height = desktopMode.Height;
            var title = "kEngine - DEFAULT TITLE";
            //TODO: LOAD SETTING SCRIPTS THAT ALLOWS YOU TO CHANGE THESE SETTINGS
            
            
            _window = new kWindow(width, height, title);
        }

        public void Run()
        {
            Initialize();
            while (_isPlaying)
            {
                Tick();
                _window.Render(_renderList);
            }
            _window.Close();
            // TODO: ADD ON APP QUIT EVENT
        }

        private void Tick()
        {
            
        }
    }
}