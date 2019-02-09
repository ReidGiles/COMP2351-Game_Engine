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
        public Player()
        {
            _input = new Input();
        }
        public void SetTexture (Texture2D pTexture)
        {
            texture = pTexture;
        }
        public void setLocation(float pX, float pY)
        {
            location.X = pX;
            location.Y = pY;
        }
        public override void Update()
        {
            /*if (location.X <= 1600 - texture.Width)
            {
                location.X += 5;
            }            
            if (location.Y <= 900 - texture.Height)
            {
                location.Y += 8;
                Console.WriteLine(location.Y);
            }*/
            location = _input.GetKeyboardInputDirection();
        }
    }
}