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
        private float _jump;
        private Vector2 _velocity;
        private float _facingDirectionX;
        private bool _floorCollide;
        private bool _movingFloor;

        public PlayerMind()
        {
            _args = new KeyboardHandler();
            _gravity = 5;
            _speed = 12;
            _jump = 0;
            _velocity.X = 1;
            _velocity.Y = -1;
            _facingDirectionX = 1;
            _mindID = "Player";
            _floorCollide = false;
            _movingFloor = false;
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
            if (_movingFloor)
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
            else
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
        }

        public override float TranslateY()
        {
            if (_jump == 0)
            {
                // Player input controlling movement, only active on key down
                foreach (Keys k in _args.GetInputKey())
                {
                    if (k == Keys.Up || k == Keys.Space)
                    {
                        _jump = 25;
                    }
                }
            }

            // Gravity, always active
            if (_location.Y <= 900 - _texture.Height && _floorCollide == false)
            {
                _gravity = 10;
            }
            else
            {
                _gravity = 0;
            }

            return (_jump - _gravity) * _velocity.Y;
        }

        public override bool OnNewCollision(ICollisionInput args)
        {
            bool rtnValue = base.OnNewCollision(args);

            if (_collidedWith == "Floor" && _collidedThis == "Player")
            {
                _floorCollide = true;

            }

            if (_collidedWith == "MovingFloor" && _collidedThis == "Player")
            {
                _floorCollide = true;
                _movingFloor = true;
            }


            if (_collidedWith == "Hostile" && _collidedThis == "Player")
            {
                rtnValue = true;
            }

            _collidedWith = null;
            _collidedThis = null;

            return rtnValue;
        }

        public override void Update()
        {
            if (_collidedWith == null && _floorCollide)
            {
                _floorCollide = false;
                _movingFloor = false;
            }

            if (_jump > 0)
            {
                _jump -= 0.4f;
            }
            else if (_jump < 0)
            {
                _jump = 0;
            }

        }
    }
}