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
        private float _facingDirectionY;
        public HostileMind()
        {
            _gravity = 10;
            _speed = 15;
            _velocity.X = 1;
            _velocity.Y = 1;
            _facingDirectionX = 1;
            _facingDirectionY = 1;
            _mindID = "Hostile";
        }

        public override float TranslateX()
        {
            if (_location.Y <= Game1.ScreenHeight - _texture.Height)
            {
                return 0;
            }
            if (_location.X >= Game1.ScreenWidth || _location.X <= 0)
            {
                _facingDirectionX *= -1;
            }
            return (_speed * _facingDirectionX) * _velocity.X; ;
        }

        public override void OnNewCollision(String[] collided)
        {
            base.OnNewCollision(collided);
            if (_collidedWith == "Hostile")
            {
            }
        }

        public override float TranslateY()
        {
            // Gravity, always active
            if (_location.Y <= Game1.ScreenHeight - _texture.Height)
            {
                return _gravity;
            }
            return 0;
        }
    }
}