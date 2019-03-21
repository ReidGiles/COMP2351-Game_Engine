
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
        public event EventHandler<ICollisionHandler> NewCollisionHandler;
        bool collision;
        ISceneGraph _sceneGraph;
        public CollisionManager(ISceneGraph pSceneGraph)
        {
            _sceneGraph = pSceneGraph;
        }

        /// <summary>
        /// Publisher method, contacts all listeners
        /// </summary>
        protected virtual void OnNewCollision()
        {
            // pass the parameters into the new keybaord input then add to NewKeyboardInput
            ICollisionHandler args = new CollisionHandler();
            NewCollisionHandler(this, args);
        }

        /// <summary>
        /// Subscription method, used to store reference to listeners
        /// </summary>
        public void AddListener(EventHandler<ICollisionHandler> handler)
        {
            // ADD event handler
            NewCollisionHandler += handler;
        }

        /// <summary>
        /// Checks for collision, result is stored in a boolean
        /// </summary>
        public bool CheckCollision()
        {
            collision = false;

            for(int i = 0; i < _sceneGraph.GetEntity().Count -1; i++)
            {
                for (int j=i+1; i < _sceneGraph.GetEntity().Count; j++)
                {
                    if(_sceneGraph.GetEntity()[i] is ICollisionListener && _sceneGraph.GetEntity()[j] is ICollisionListener)
                    {
                        if (_sceneGraph.GetEntity()[i].CheckCollider() && _sceneGraph.GetEntity()[j].CheckCollider())
                        {
                            //get a reference to the entities collider for I and J
                            ICreateCollider colliderI= _sceneGraph.GetEntity()[i].GetCollider();
                            ICreateCollider colliderJ = _sceneGraph.GetEntity()[j].GetCollider();

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
                                collision = true;
                            }
                        }
                    }
                }
            }

            return collision;
        }

        /// <summary>
        /// Runs publisher methods when input is detected
        /// </summary>
        public void Update()
        {
            CheckCollision();

            if (collision == true && NewCollisionHandler != null)
            {
                // update listeners
                OnNewCollision();
            }
        }
    }
}