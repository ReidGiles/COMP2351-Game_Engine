using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2351_Game_Engine
{
    interface ICreateCollider
    {
        //get the origin point of the collider
        Vector2 GetOrgin();

        //get the width and height of the collider
        float[] GetSize();

    }
}
