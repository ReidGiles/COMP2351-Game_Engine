using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace COMP2351_Game_Engine
{
    interface IEntityManager
    {
        IRelicHunterEntity GetEntity(string pEntity, Texture2D pTexture);
    }
}
