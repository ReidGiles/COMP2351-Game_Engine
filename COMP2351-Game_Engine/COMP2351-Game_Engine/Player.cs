﻿using System;
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
        public Player()
        {
        }
        public void SetTexture (Texture2D pTexture)
        {
            texture = pTexture;
        }
        public void setLocation(float pX, float pY)
        {
            location.X = pX;
            location.Y = pY;
            _input = new Input();
        }
        public override void Update()
        {       
            if (location.Y <= 900 - texture.Height)
            {
                location.Y += 8;
            }
            location += _input.GetKeyboardInputDirection();
        }
    }
}