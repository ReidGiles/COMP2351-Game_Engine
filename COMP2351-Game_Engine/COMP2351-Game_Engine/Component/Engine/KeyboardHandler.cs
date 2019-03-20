using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace COMP2351_Game_Engine
{
    class KeyboardHandler : EventArgs, IKeyboardInput
    {
        Keys[] _inputKey;
        public KeyboardHandler()
        {
        }
        /// <summary>
        /// Returns keys pressed on keyboard
        /// </summary>
        public Keys[] GetInputKey()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            _inputKey = keyboardState.GetPressedKeys();
            return _inputKey;
        }
    }
}