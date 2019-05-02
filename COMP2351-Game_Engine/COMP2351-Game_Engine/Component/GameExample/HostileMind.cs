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
        private float _counterForce;
        private Vector2 _velocity;
        private bool _floorCollide;
        private bool _inAir;
        private bool _onFloor;
        public HostileMind()
        {
            _gravity = 10;
            _speed = 2;
            _counterForce = 0;
            _velocity.X = 1;
            _velocity.Y = 1;
            _facingDirectionX = 1;
            _mindID = "Hostile";
            _floorCollide = false;
            _inAir = true;
            _onFloor = false;
        }

        public override float TranslateX()
        {
            return (_speed * _facingDirectionX) * _velocity.X;
        }

        public override bool OnNewCollision(ICollisionInput args)
        {
            bool rtnValue = base.OnNewCollision(args);

            if (_collidedWith == "HBoundary" && _collidedThis == "HostileB" ||  _collidedWith == "HBoundary" && _collidedThis == "HostileT")
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
            if (!_floorCollide && _inAir)
            {
                _gravity = 10;
            }
            else
            {
                _inAir = false;
                _gravity = 0;
            }

            if (!_onFloor && _floorCollide && !_inAir)
            {
                _gravity = 0;
                _counterForce = 1;
            }

            if (!_onFloor && !_floorCollide && !_inAir)
            {
                _onFloor = true;
                _counterForce = -1;
            }

            if (_onFloor && _floorCollide)
            {
                _counterForce = 0;
            }

            if (_onFloor && !_floorCollide && _counterForce == 0)
            {
                _inAir = true;
                _onFloor = false;
            }

            return _gravity * _velocity.Y;
        }
    }
}