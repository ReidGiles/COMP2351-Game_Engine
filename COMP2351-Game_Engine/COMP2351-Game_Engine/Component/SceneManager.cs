using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace COMP2351_Game_Engine
{
    class SceneManager : ISceneManager, IUpdatable
    {
        ISceneGraph _sceneGraph;
        public SceneManager(ISceneGraph pSceneGraph)
        {
            _sceneGraph = pSceneGraph;
        }
        /// <summary>
        /// This is called when a new entity needs to be spawned.
        /// </summary>
        public void Spawn(IEntity pEntity, float pX, float pY)
        {
            // Spawn entity
            _sceneGraph.Spawn(pEntity, pX, pY);
            // Set entity location
            pEntity.SetLocation(pX, pY);
        }
        /// <summary>
        /// This is called when an existing entity needs to be spawned.
        /// </summary>
        public void Spawn(int pUID, int pX, int pY)
        {
            _sceneGraph.Spawn(pUID, pX, pY);
        }
        /// <summary>
        /// This is called when an entity needs to be removed.
        /// </summary>
        public void Remove(int pUID)
        {
            _sceneGraph.Remove(pUID);
        }
        /// <summary>
        /// Returns a reference of an entity.
        /// </summary>
        public IEntity GetEntity(int pUID)
        {
            foreach (IEntity e in _sceneGraph.GetEntity())
            {
                if (e.GetUID() == pUID)
                {
                    return e;
                }
            }
            return null;
        }
        /// <summary>
        /// Updated all entities inside the scene graph.
        /// </summary>
        public void Update()
        {
            // Update all entities inside the scene graph
            foreach (IEntity e in _sceneGraph.GetEntity())
            {
                ( (IUpdatable)e).Update();
            }
        }
    }
}