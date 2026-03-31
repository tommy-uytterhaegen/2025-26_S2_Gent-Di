using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.Core
{
    public static class KeyboardFacade
    {
        private static KeyboardState _previousState;
        private static KeyboardState _state;

        static KeyboardFacade()
        {
            _previousState = new KeyboardState();
            _state = new KeyboardState();
        }

        public static void Update()
        {
            _previousState = _state;
            _state = Keyboard.GetState();
        }

        public static bool IsKeyDown(Keys key)
            => _state.IsKeyDown(key);

        public static bool IsKeyDown(Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (IsKeyDown(key))
                    return true;
            }

            return false;
        }

        public static bool WasKeyJustPressed(Keys key)
        {
            return _previousState.IsKeyUp(key) && _state.IsKeyDown(key);
        }
    }
}
