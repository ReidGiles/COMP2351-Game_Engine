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
        static Vector2 direction;
        public Input()
        {
        }
        public Vector2 GetKeyboardInputDirection()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                direction.X += 5;
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                direction.X -= 5;
            }
            return direction;
        }
    }
}
