﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace COMP2351_Game_Engine
{
    interface IEntity
    {
        void Update();
        void SetTexture(Texture2D pTexture);
        void Draw(SpriteBatch spriteBatch);
    }
}
