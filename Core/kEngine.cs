using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using kEngine.Core.Events;
using SFML.Graphics;
using SFML.Window;

namespace kEngine.Core
{
    public class kEngine
    {
        private kWindow _window;
        private bool _isPlaying = true;
        private List<Shape> _renderList = new List<Shape>();
        
        private void Initialize()
        {
            var desktopMode = VideoMode.DesktopMode;
            var width = desktopMode.Width;
            var height = desktopMode.Height;
            var title = "kEngine - DEFAULT TITLE";
            uint framerateCap = 1000;

            //TODO: LOAD SETTING SCRIPTS THAT ALLOWS YOU TO CHANGE WINDOW SETTINGS
            
            
            //REGISTER EVENTS AND LISTENERS
            TypeHandler.InstantiateSubTypes<kEvent>();
            TypeHandler.InstantiateSubTypes<kListener>();

            _window = new kWindow(width, height, title, framerateCap);
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
            EventHolder.TickEvents();
        }
    }
}