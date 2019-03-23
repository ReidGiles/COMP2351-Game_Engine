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
    class PlayerMind : Mind, IKeyboardListener
    {
        IKeyboardInput _args;
        private float _gravity;
        private float _speed;
        public PlayerMind()
        {
            _args = new KeyboardHandler();
            _gravity = 10;
            _speed = 12;
            _mindID = "Player";
        }

        /// <summary>
        /// Required for Input management of the keyboard
        /// </summary>
        public void OnNewKeyboardInput(object sender, IKeyboardInput args)
        {
            _args = args;
        }

        public override float TranslateX()
        {
            // Player input controlling movement, only active on key down
            foreach (Keys k in _args.GetInputKey())
            {
                if (k == Keys.Right)
                {
                    return _speed;
                }
                if (k == Keys.Left)
                {
                    return -_speed;
                }
            }
            return 0;
        }

        public override float TranslateY()
        {
            // Player input controlling movement, only active on key down
            foreach (Keys k in _args.GetInputKey())
            {
                if (k == Keys.Up)
                {
                    return -_speed + _gravity;
                }
                if (k == Keys.Down)
                {
                    return _speed;
                }
            }

            // Gravity, always active
            if (_location.Y <= 900 - _texture.Height)
            {
                return _gravity;
            }

            return 0;
        }

        public override void OnNewCollision(String[] collided)
        {
            base.OnNewCollision(collided);
            if (_collidedWith == "Hostile")
            {
                _speed += 1;
            }

            _collidedWith = null;
        }

        public override void Update()
        {
            // Add switch that prevents Translate methods from running
        }
    }
}