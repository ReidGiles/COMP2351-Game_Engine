using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace COMP2351_Game_Engine
{
    interface ISceneGraph
    {
        void Spawn(IEntity pEntity, float pX, float pY);
        void Remove(IEntity pEntity);
        IList<IEntity> GetEntity();
    }
}
