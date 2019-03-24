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
        private Vector2 _velocity;
        private float _facingDirectionX;
        private float _facingDirectionY;
        private bool testBool;
        public PlayerMind()
        {
            _args = new KeyboardHandler();
            _gravity = 5;
            _speed = 7;
            _velocity.X = 1;
            _velocity.Y = 1;
            _facingDirectionX = 1;
            _facingDirectionY = 1;
            _mindID = "Player";
            testBool = false;
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
                    _facingDirectionX = 1;
                    return (_speed * _facingDirectionX) * _velocity.X;
                }
                if (k == Keys.Left)
                {
                    _facingDirectionX = -1;
                    return (_speed * _facingDirectionX) * _velocity.X;
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
                    _facingDirectionY = -1;
                    return (_speed * _facingDirectionY) * _velocity.Y;
                }
            }

            // Gravity, always active
            if (_location.Y <= 900 - _texture.Height && testBool == false)
            {
                return _gravity;
            }

            return 0;
        }

        public override void OnNewCollision(String[] collided)
        {
            base.OnNewCollision(collided);
            if (_collidedWith == "Floor")
            {
                //testBool = true;
            }

            _collidedWith = null;
        }

        public override void Update() 
        {
            if (_collidedWith == null)
            {
                _gravity = 5;
                testBool = false;
            }
            // Add switch that prevents Translate methods from running
        }
    }
}