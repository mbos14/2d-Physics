using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class DebugMouseEvent:GameObject
    {
        private GameObject _gameObject = null;
        private MouseHandler _ballHandler = null;

        public DebugMouseEvent(GameObject gameObject)
        {
            _gameObject = gameObject;
            _ballHandler = new MouseHandler(_gameObject);
            _ballHandler.OnMouseClick += OnMouseEvent;
            _ballHandler.OnMouseDown += OnMouseEvent;
            _ballHandler.OnMouseDownOnTarget += OnMouseEvent;
            //_ballHandler.OnMouseMove += OnMouseEvent;
            //_ballHandler.OnMouseMoveOnTarget += OnMouseEvent;
            _ballHandler.OnMouseOffTarget += OnMouseEvent;
            _ballHandler.OnMouseOverTarget += OnMouseEvent;
            _ballHandler.OnMouseUp += OnMouseEvent;
            _ballHandler.OnMouseUpOnTarget += OnMouseEvent;
        }
        private void OnMouseEvent(GameObject target,MouseEventType type)
        {
            Console.WriteLine("Event: " + type + " triggered on " + target);

        }
    }   
}
