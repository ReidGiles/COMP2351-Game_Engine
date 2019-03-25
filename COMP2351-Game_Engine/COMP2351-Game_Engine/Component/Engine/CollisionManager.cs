﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2351_Game_Engine
{
    class CollisionManager : IUpdatable, ICollisionManager
    {
        // create a variable to store all the subscribers to the event
        public event EventHandler<ICollisionInput> NewCollisionHandler;

        // refernce to the sceneGraph
        ISceneGraph _sceneGraph;

        /// <summary>
        /// contructor for the Collision Manager
        /// </summary>
        /// <param name="pSceneGraph"></param>
        public CollisionManager(ISceneGraph pSceneGraph)
        {
            // initialise _sceneGraph
            _sceneGraph = pSceneGraph;
        }

        /// <summary>
        /// Publisher method, contacts all listeners
        /// </summary>
        /// <param name="pCollided"></param>
        /// <param name="pUID"></param>
        protected virtual void OnNewCollision(String[] pCollided, int[] pUID)
        {
            // pass the parameters into the new keybaord input then add to NewKeyboardInput
            ICollisionInput args = new CollisionHandler(pCollided, pUID);
            NewCollisionHandler(this, args);
            
        }

        /// <summary>
        /// Subscription method, used to store reference to listeners
        /// </summary>
        /// <param name="handler"></param>
        public void AddListener(EventHandler<ICollisionInput> handler)
        {
            // ADD event handler
            NewCollisionHandler += handler;
        }

        /// <summary>
        /// Checks for collision
        /// </summary>
        private void CheckCollision()
        {
            for(int i = 0; i < _sceneGraph.GetEntity().Count -1; i++)
            {
                for (int j=i+1; j < _sceneGraph.GetEntity().Count; j++)
                {
                    // check entity has a collision listener
                    if (_sceneGraph.GetEntity()[i] is ICollisionListener && _sceneGraph.GetEntity()[j] is ICollisionListener)
                    {
                        // check the entity has a collider set up
                        if (_sceneGraph.GetEntity()[i].CheckCollider() && _sceneGraph.GetEntity()[j].CheckCollider())
                        {
                            // get a reference to the entities colliders for I and J
                            
                            List<ICreateCollider> colliderI = _sceneGraph.GetEntity()[i].GetCollider();
                            List<ICreateCollider> colliderJ = _sceneGraph.GetEntity()[j].GetCollider();

                            // each collider in I
                            foreach (ICreateCollider k in colliderI)
                            {
                                // each collider in j
                                foreach (ICreateCollider l in colliderJ)
                                {
                                    // get the co-odinate points needed to check collision for I and J
                                    float[] CheckColliderI = k.CreateCollider();
                                    float[] CheckColliderJ = l.CreateCollider();

                                    // Distance between x axis values for I and J
                                    float Dx = Math.Abs(CheckColliderI[0] - CheckColliderJ[0]);

                                    // Distance between y axis values for I and J
                                    float Dy = Math.Abs(CheckColliderI[1] - CheckColliderJ[1]);

                                    // Check collision
                                    if ((Dx < (CheckColliderI[2] + CheckColliderJ[2]) * 0.5) && (Dy < (CheckColliderI[3] + CheckColliderJ[3]) * 0.5))
                                    {
                                        // colliding
                                        // get the collider tag
                                        String[] collided = { k.GetTag(), l.GetTag() };
                                        // get the colliding entity ID
                                        int[] uID = { _sceneGraph.GetEntity()[i].GetUID(), _sceneGraph.GetEntity()[j].GetUID() };
                                        // publish collision
                                        OnNewCollision(collided, uID);

                                        /*
                                        //post the collision tag ,xPos ,yPos ,width ,height
                                        Console.WriteLine(k.GetTag() + " " + CheckColliderI[0] + " " + CheckColliderI[1] + " " + CheckColliderI[2] + " " + CheckColliderI[3]);
                                        Console.WriteLine(l.GetTag() + " " + CheckColliderJ[0] + " " + CheckColliderJ[1] + " " + CheckColliderJ[2] + " " + CheckColliderJ[3]);
                                        // post the distance between the origin points of the collision in x and y
                                        Console.WriteLine(Dx + " " + Dy);*/
                                    }
                                }
                            }                          
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Runs publisher methods when input is detected
        /// </summary>
        public void Update()
        {
            CheckCollision();
        }
    }
}