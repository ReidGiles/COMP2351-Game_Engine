﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace COMP2351_Game_Engine
{
    interface IEntityManager
    {
        IEntity RequestInstance<T>(Texture2D pTexture, IAIComponentManager pAIComponentManager) where T : IEntity, new();
    }
}