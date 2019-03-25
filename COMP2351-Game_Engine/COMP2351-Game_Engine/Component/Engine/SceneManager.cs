﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace COMP2351_Game_Engine
{
    class SceneManager : ISceneManager, IUpdatable
    {
        // reference to the sceneGraph
        ISceneGraph _sceneGraph;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="pSceneGraph"></param>
        public SceneManager(ISceneGraph pSceneGraph)
        {
            // set _sceneGraph
            _sceneGraph = pSceneGraph;
        }

        /// <summary>
        /// This is called when a new entity needs to be spawned.
        /// </summary>
        /// <param name="pEntity"></param>
        /// <param name="pX"></param>
        /// <param name="pY"></param>
        public void Spawn(IEntity pEntity, float pX, float pY)
        {
            // Spawn entity
            _sceneGraph.Spawn(pEntity, pX, pY);
        }

        /// <summary>
        /// This is called when an existing entity needs to be spawned.
        /// </summary>
        /// <param name="pUID"></param>
        /// <param name="pX"></param>
        /// <param name="pY"></param>
        public void Spawn(int pUID, int pX, int pY)
        {
            _sceneGraph.Spawn(pUID, pX, pY);
        }

        /// <summary>
        /// This is called when an entity needs to be removed.
        /// </summary>
        /// <param name="pUID"></param>
        public void Remove(int pUID)
        {
            _sceneGraph.Remove(pUID);
        }

        /// <summary>
        /// This is called when an entity needs to be removed.
        /// </summary>
        /// <param name="pUName"></param>
        public void Remove(String pUName)
        {
            _sceneGraph.Remove(pUName);
        }

        /// <summary>
        ///  Returns a reference of an entity.
        /// </summary>
        /// <param name="pUID"></param>
        /// <returns></returns>
        public IEntity GetEntity(int pUID)
        {
            // Find the entity in the _scenGraph that where UID = pUID
            foreach (IEntity e in _sceneGraph.GetEntity())
            {
                if (e.GetUID() == pUID)
                {
                    // return the entity
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