
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
                for (int j=i+1; j < _sceneGraph.GetEntity().Count; j++)
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

                            //Distance between x axis values for I and J
                            float Dx = CheckColliderI[0] - CheckColliderJ[0];

                            //Distance between y axis values for I and J
                            float Dy = CheckColliderI[1] - CheckColliderJ[1];

                            //Check collision
                            if ((Dx < (CheckColliderI[2]+ CheckColliderJ[2])*0.5) && (Dy < (CheckColliderI[3] + CheckColliderJ[3]) * 0.5))
                            {
                                // colliding
                                // get the collider tag
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