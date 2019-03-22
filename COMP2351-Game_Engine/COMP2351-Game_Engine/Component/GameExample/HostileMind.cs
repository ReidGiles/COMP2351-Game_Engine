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
            _speed = 1;
        }

        public override float TranslateX()
        {
            if (_location.Y <= 900 - _texture.Height)
            {
                return 0;
            }
            return _speed;
        }

        public override float TranslateY()
        {
            // Gravity, always active
            if (_location.Y <= 900 - _texture.Height)
            {
                return _gravity;
            }
            return 0;
        }
    }
}