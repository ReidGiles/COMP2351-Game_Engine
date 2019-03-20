
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2351_Game_Engine
{
    class CollisionManager : IUpdatable
    {
        ISceneGraph _sceneGraph;
        public CollisionManager(ISceneGraph pSceneGraph)
        {
            _sceneGraph = pSceneGraph;
        }

        public bool CheckCollision()
        {
            bool collision = false;

            for(int i = 0; i < _sceneGraph.GetEntity().Count -1; i++)
            {
                for (int j=i+1; i < _sceneGraph.GetEntity().Count; j++)
                {
                    //Check collision
                }
            }

            return collision;
        }
        public void Update()
        {
        }
    }
}