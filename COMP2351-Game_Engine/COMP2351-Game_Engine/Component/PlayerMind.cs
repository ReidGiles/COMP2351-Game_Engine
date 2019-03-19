using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace COMP2351_Game_Engine
{
    class PlayerMind : Mind
    {
        IInput _input;
        public PlayerMind()
        {
            _input = new Input();
        }

        public override float TranslateX()
        {
            return _input.GetKeyboardInputDirection().X;
        }

        public override float TranslateY()
        {
            return _input.GetKeyboardInputDirection().Y;
        }

        public override void Update()
        {
            _location += _input.GetKeyboardInputDirection();
        }
    }
}