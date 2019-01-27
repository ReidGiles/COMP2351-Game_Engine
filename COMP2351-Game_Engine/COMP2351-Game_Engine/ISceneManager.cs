using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace COMP2351_Game_Engine
{
    interface ISceneManager
    {
        void Spawn(IEntity pEntity, Vector2 pLocation);
    }
}