using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace COMP2351_Game_Engine
{
    class Player : RelicHunterEntity, IPlayer
    {
        IInput _input;
        float gravity;
        public Player()
        {
            _input = new Input();
            gravity = 8;
        }
        /// <summary>
        /// Overides Update() with unique entity behaviour.
        /// </summary>
        public override void Update()
        {       
            if (location.Y <= 900 - texture.Height)
            {
                location.Y += gravity;
            }
            location += _input.GetKeyboardInputDirection();
        }
    }
}