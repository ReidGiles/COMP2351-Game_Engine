using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace COMP2351_Game_Engine
{
    class HostileMind : Mind
    {
        private float _gravity;
        private float _speed;
        private Vector2 _velocity;
        private float _facingDirectionX;
        private bool _floorCollide;
        public HostileMind()
        {
            _gravity = 10;
            _speed = 5;
            _velocity.X = 1;
            _velocity.Y = 1;
            _facingDirectionX = 1;
            _mindID = "Hostile";
            _floorCollide = false;
        }

        public override float TranslateX()
        {
            if (_location.Y <= Game1.ScreenHeight - _texture.Height && !_floorCollide)
            {
                return 0;
            }
            if (_location.X >= Game1.ScreenWidth || _location.X <= 0)
            {
                _facingDirectionX *= -1;
            }
            return (_speed * _facingDirectionX) * _velocity.X;
        }

        public override bool OnNewCollision(ICollisionInput args)
        {
            bool rtnValue = base.OnNewCollision(args);
            if (_collidedWith == "Boundary" && _collidedThis == "HostileB")
            {
                _facingDirectionX *= -1;
            }
            if (_collidedWith == "HostileB" && _collidedThis == "HostileB")
            {
                _facingDirectionX *= -1;
            }
            if (_collidedWith == "Floor" && _collidedThis == "HostileB")
            {
                _floorCollide = true;
            }
            if (_collidedWith == "PlayerB" && _collidedThis == "HostileT")
            {
                rtnValue = true;
            }
            return rtnValue;
        }

        public override float TranslateY()
        {
            // Gravity, always active
            if (_location.Y <= 900 - _texture.Height && _floorCollide == false)
            {
                _gravity = 10;
            }
            else
            {
                _gravity = 0;
            }

            return _gravity * _velocity.Y;
        }
    }
}