using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace COMP2351_Game_Engine
{
    class KeyboardInput : EventArgs
    {
        Vector2 _direction;
        public KeyboardInput()
        {
        }
        public Vector2 GetKeyboardInputDirection()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyUp(Keys.Right) || keyboardState.IsKeyUp(Keys.Left))
            {
                _direction.X = 0;
            }
            if (keyboardState.IsKeyUp(Keys.Up))
            {
                _direction.Y = 0;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                _direction.X = 15;
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                _direction.X = -15;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                _direction.Y = 15;
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                _direction.Y = -15;
            }
            return _direction;
        }

        //add what the keyboardInput event does
    }
}