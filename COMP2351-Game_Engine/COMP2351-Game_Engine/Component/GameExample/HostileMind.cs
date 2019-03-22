using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2351_Game_Engine
{
    class HostileMind : Mind
    {
        private float _gravity;
        private float _speed;
        public HostileMind()
        {
            _gravity = 10;
            _speed = 15;
        }

        public override float TranslateX()
        {
            if (_location.Y <= Game1.ScreenHeight - _texture.Height)
            {
                return 0;
            }
            if (_location.X >= Game1.ScreenWidth || _location.X <= 0)
            {
                _speed = -_speed;
            }
            return _speed;
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