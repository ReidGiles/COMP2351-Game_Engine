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
        /// <summary>
        /// This is called when a new entity needs to be spawned.
        /// </summary>
        public void Spawn(IRelicHunterEntity pEntity, float pX, float pY)
        {
            // Spawn entity
            _sceneGraph.Spawn( (IEntity)pEntity, pX, pY);
            // Set entity location
            ( (IPlayer)pEntity ).setLocation(pX, pY);
        }
        /// <summary>
        /// This is called when an existing entity needs to be spawned.
        /// </summary>
        public void Spawn(string UID, string UName)
        {
        }
        /// <summary>
        /// This is called when an entity needs to be removed.
        /// </summary>
        public void Remove(string UID, string UName)
        {
        }
        /// <summary>
        /// Updated all entities inside the scene graph.
        /// </summary>
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