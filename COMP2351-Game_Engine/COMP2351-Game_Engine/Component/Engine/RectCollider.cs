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
        private Vector2 _origin;

        //width of the collider
        private float _width;

        //height of the collider
        private float _height;

        //Tag used to identigy type of collider
        private String _colliderTag;


        public RectCollider(Vector2 pOrigin, float pWidth, float pHeight, String pColliderTag)
        {
            //set origin
            _origin = pOrigin;

            //set width
            _width = pWidth;

            //set height
            _height = pHeight;

            //set collider tag
            _colliderTag = pColliderTag;
        }

        //Translate the position of the Collider
        public void Translate(float dx, float dy)
        {
            //move x
            _origin.X = dx;
            //move y
            _origin.Y = dy;
        }


        //Create the corners of the collider
        public float[] CreateCollider()
        {
            float[] retVal = { _origin.X, _origin.Y, _width, _height };

            return retVal;
        }

        public String GetTag()
        {
            return _colliderTag;
        }
    }
}
