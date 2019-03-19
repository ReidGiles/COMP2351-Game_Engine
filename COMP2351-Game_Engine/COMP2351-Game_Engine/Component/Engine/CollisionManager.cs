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
        public void Update()
        {
            /*foreach (IEntity e in _sceneGraph.GetEntity())
            {
            }*/
        }
    }
}