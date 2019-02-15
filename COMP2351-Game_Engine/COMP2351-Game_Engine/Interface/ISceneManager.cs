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
        void Spawn(IRelicHunterEntity pEntity, float pX, float pY);
        void Spawn(string UID, string UName);
        void Remove(string UID, string UName);
        void Update();
    }
}