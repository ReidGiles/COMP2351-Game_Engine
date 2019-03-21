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


        //Create the corners of the collider
        public float[] CreateCollider()
        {
            //Vector for the Top left of the rectangle collider
            float Top = origin.Y + 0.5f * height;

            //Vector for the Top Right of teh rectangle collider
            float Btm = origin.Y - 0.5f * height;

            //Vector for the Top Right of teh rectangle collider
            float Left = origin.X - 0.5f * width;

            //Vector for the Top left of the rectangle collider
            float Right = origin.X + 0.5f * width;

            float[] retVal = { Top, Btm, Left, Right };

            return retVal;
        }
    }
}
