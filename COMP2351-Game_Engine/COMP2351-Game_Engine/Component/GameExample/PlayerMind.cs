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
        private bool _inAir;

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
            _inAir = false;
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
                    if (k == Keys.Right || k == Keys.D)
                    {
                        _facingDirectionX = 1;
                        return (_speed * _facingDirectionX) * _velocity.X;
                    }
                    if (k == Keys.Left || k == Keys.A)
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
                    if (k == Keys.Right || k == Keys.D)
                    {
                        _facingDirectionX = 1;
                        return (_speed * _facingDirectionX) * _velocity.X;
                    }
                    if (k == Keys.Left || k == Keys.A)
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
            if (!_inAir)
            {
                // Player input controlling movement, only active on key down
                foreach (Keys k in _args.GetInputKey())
                {
                    if (k == Keys.Up || k == Keys.Space || k == Keys.W)
                    {
                        _jump = 25;
                        _inAir = true;
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
                _inAir = false;
                _gravity = 0;
            }

            return (_jump - _gravity) * _velocity.Y;
        }

        public override bool OnNewCollision(ICollisionInput args)
        {
            bool rtnValue = base.OnNewCollision(args);

            if (_collidedWith == "Floor" && _collidedThis == "PlayerB")
            {
                _floorCollide = true;
                _inAir = false;

            }

            if (_collidedWith == "MovingFloor" && _collidedThis == "PlayerB")
            {
                _floorCollide = true;
                _movingFloor = true;
                _inAir = false;
            }


            if (_collidedWith == "HostileB" && _collidedThis == "PlayerT")
            {
                rtnValue = true;
            }

            if (_collidedWith == "HostileB" && _collidedThis == "PlayerB")
            {
                rtnValue = true;
            }

            if (_collidedWith == "Ceiling" && _collidedThis == "PlayerT")
            {
                _jump = 0;
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