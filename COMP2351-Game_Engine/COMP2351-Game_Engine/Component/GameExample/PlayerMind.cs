using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace COMP2351_Game_Engine
{
    class PlayerMind : Mind, IKeyboardListener
    {
        KeyboardInput _args;
        private float _gravity;
        public PlayerMind()
        {
            _args = new KeyboardInput();
            _gravity = 10;
        }

        /// <summary>
        /// Required for Input management of the keyboard
        /// </summary>
        public void OnNewKeyboardInput(object sender, KeyboardInput args)
        {
            _args = args;
        }

        public override float TranslateX()
        {
            return _args.GetKeyboardInputDirection().X;
        }

        public override float TranslateY()
        {
            if (_location.Y <= 900 - _texture.Height)
            {
                return _args.GetKeyboardInputDirection().Y + _gravity;
            }
            return _args.GetKeyboardInputDirection().Y;
        }

        public override void Update()
        {
        }
    }
}