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


        /*
        // THIS CODE IS TO BE MOVED INTO THE MANAGER
        If(Entity is ICollisionListener)
        {
            // bool to flag if colliding
            bool Colliding = false;

            if (_sceneGraph[i].CheckCollider() && _sceneGraph[j].CheckCollider())
            {
                //get a reference to the entities collider for I and J
                ICreateCollider colliderI= _sceneGraph[i].GetCollider();
                ICreateCollider colliderJ = _sceneGraph[j].GetCollider();

                //get the co-odinate points needed to check collision for I and J
                float[] CheckColliderI = colliderI.CreateCollider();
                float[] CheckColliderJ = colliderJ.CreateCollider();

                // Top collide for entity i
                bool TopCollideI = false;
                // Bottom collide for entity i
                bool BtmCollideI = false;
                // Left collide for entity i
                bool LeftCollideI = false;
                // Right collide for entity i
                bool RightCollideI = false;
                // Top collide for entity j
                bool TopCollideJ = false;
                // Bottom collide for entity j
                bool BtmCollideJ = false;
                // Left collide for entity j
                bool LeftCollideJ = false;
                // Right collide for entity j
                bool RightCollideJ = false;

                //Check for collision with Top of I being inbetween Top and Bottom of J
                if (CheckColliderI[0] <= CheckColliderJ[0] && CheckColliderI[0] >= CheckColliderJ[1])
                {
                    TopCollideI = true;
                }

                //Check for collision with Bottom of I being inbetween Top and Bottom of J
                if (CheckColliderI[1] <= CheckColliderJ[0] && CheckColliderI[1] >= CheckColliderJ[1])
                {
                    BtmCollideI = true;
                }

                //Check for collision with Left of I being inbetween Left and Right of J
                if (CheckColliderI[2] <= CheckColliderJ[3] && CheckColliderI[2] >= CheckColliderJ[2])
                {
                    LeftCollideI = true;
                }

                //Check for collision with Right of I being inbetween Left and Right of J
                if (CheckColliderI[3] <= CheckColliderJ[3] && CheckColliderI[3] >= CheckColliderJ[2])
                {
                    LeftCollideI = true;
                }

                //Check for collision with Top of J being inbetween Top and Bottom of I
                if (CheckColliderJ[0] <= CheckColliderI[0] && CheckColliderJ[0] >= CheckColliderI[1])
                {
                    TopCollideJ = true;
                }

                //Check for collision with Bottom of J being inbetween Top and Bottom of I
                if (CheckColliderJ[1] <= CheckColliderI[0] && CheckColliderJ[1] >= CheckColliderI[1])
                {
                    BtmCollideJ = true;
                }

                //Check for collision with Left of J being inbetween Left and Right of I
                if (CheckColliderJ[2] <= CheckColliderI[3] && CheckColliderJ[2] >= CheckColliderI[2])
                {
                    LeftCollideJ = true;
                }

                //Check for collision with Right of J being inbetween Left and Right of I
                if (CheckColliderJ[3] <= CheckColliderI[3] && CheckColliderJ[3] >= CheckColliderI[2])
                {
                    LeftCollideJ = true;
                }

                //Check for intersection of areas by checking if vertical and horizontal points are intersecting simultaneously 
                if ((TopCollideI || BtmCollideI || TopCollideJ || BtmCollideJ) && (LeftCollideI || RightCollideI || LeftCollideJ || RightCollideJ))
                {
                    Colliding = true;
                }
            }

            if (Colliding)
            {
                //code if colliding is true publish to listner (true, "Collision Lable e.g. Player, Environment, Collectible, Hazard....")
            }
        }*/
    }
}
