using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace COMP2351_Game_Engine
{
    class MouseHandler : IMouseInput
    {
        private int[] mouseVal;
        public MouseHandler()
        {
        }

        public int[] GetMouseVal()
        {
            MouseState mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                mouseVal = new int[] {mouseState.X, mouseState.Y};
            }
            return mouseVal;
        }
    }
}
