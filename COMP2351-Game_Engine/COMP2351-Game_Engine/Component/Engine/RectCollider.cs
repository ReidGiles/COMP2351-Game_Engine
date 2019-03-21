using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2351_Game_Engine
{
    class RectCollider : ICollider,ICreateCollider
    {
        //origin point of the rectangle collider
        private Vector2 origin;

        //width of the collider
        private float width;

        //height of the collider
        private float height;


        public RectCollider(Vector2 pOrigin, float pWidth, float pHeight)
        {
            //set origin
            origin = pOrigin;

            //set width
            width = pWidth;

            //set height
            height = pHeight;
        }

        //Translate the position of the Collider
        public void Translate(float dx, float dy)
        {
            //move x
            origin.X += dx;
            //move y
            origin.Y += dy;
        }

        //get the origin point of the collider
        public Vector2 GetOrgin()
        {
            return origin;
        }

        //get the width and height of the collider
        public float[] GetSize()
        {
            float[] retVal = { width, height};
            return retVal;
        }
    }
}
