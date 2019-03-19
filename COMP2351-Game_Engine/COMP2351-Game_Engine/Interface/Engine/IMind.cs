﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace COMP2351_Game_Engine
{
    interface IMind
    {
        void UpdateLocation(Vector2 pLocation);
        void UpdateTexture(Texture2D pTexture);
        float TranslateX();
        float TranslateY();
    }
}
