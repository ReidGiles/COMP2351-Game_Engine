using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace COMP2351_Game_Engine
{
    class Input : IInput
    {
        Vector2 _direction;
        public Input()
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
                _direction.X = 5;
            }            
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                _direction.X = -5;
            }           
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                //_direction.Y = 5;
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                _direction.Y = -30;
            }
            return _direction;
        }
    }
}
