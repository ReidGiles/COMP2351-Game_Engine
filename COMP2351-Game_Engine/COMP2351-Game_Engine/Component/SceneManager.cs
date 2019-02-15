using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace COMP2351_Game_Engine
{
    class SceneManager : ISceneManager
    {
        ISceneGraph _sceneGraph;
        public SceneManager()
        {
            _sceneGraph = new SceneGraph();
        }
        public void Spawn(IRelicHunterEntity pEntity, float pX, float pY)
        {
            // Spawn entity
            _sceneGraph.Spawn( (IEntity)pEntity, pX, pY);
            // Set entity location
            ( (IPlayer)pEntity ).setLocation(pX, pY);
        }
        public void Update()
        {
            // Update all entities inside the scene graph
            foreach (IEntity e in _sceneGraph.GetEntity())
            {
                e.Update();
            }
        }
    }
}