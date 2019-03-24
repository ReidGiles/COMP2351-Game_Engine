using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace COMP2351_Game_Engine
{
    class SceneGraph : ISceneGraph
    {
        IList<IEntity> _entityList;
        IEntity removeEntity;
        public SceneGraph()
        {
            _entityList = new List<IEntity>();
        }
        /// <summary>
        /// This is called from scene manager when a new entity is spawned.
        /// </summary>
        public void Spawn(IEntity pEntity, float pX, float pY)
        {
            Boolean found = false;
            foreach (IEntity e in _entityList)
            {
                if (e == pEntity)
                {
                    // Set entity location
                    pEntity.SetLocation(pX, pY);
                    found = true;
                }
            }
            if (!found)
            {
                // Record entity has been spawned
                _entityList.Add(pEntity);
                pEntity.SetLocation(pX, pY);
            }
            //_entityList.Add(pEntity);
            // Set entity location
            //pEntity.SetLocation(pX, pY);
        }
        /// <summary>
        /// This is called from scene manager when an existing entity is spawned.
        /// </summary>
        public void Spawn(int pUID, int pX, int pY)
        {
            foreach (IEntity e in _entityList)
            {
                if (e.GetUID() == pUID)
                {
                    // Set entity location
                    e.SetLocation(pX, pY);
                }
            }
        }
        /// <summary>
        /// This is called from scene manager when an entity needs to be removed.
        /// </summary>
        public void Remove(int pUID)
        {
            foreach (IEntity e in _entityList)
            {
                if (e.GetUID() == pUID)
                {
                    removeEntity = e;
                }
            }
            if (removeEntity != null)
            {
                _entityList.Remove(removeEntity);
                //removeEntity.SetLocation(-50, -50);
                removeEntity = null;
            }            
        }
        /// <summary>
        /// This is called from scene manager when an entity needs to be removed.
        /// </summary>
        public void Remove(String pUName)
        {
            foreach (IEntity e in _entityList)
            {
                if (e.GetUname() == pUName)
                {
                    removeEntity = e;
                }
            }
            if (removeEntity != null)
            {
                _entityList.Remove(removeEntity);
                //removeEntity.SetLocation(-50, -50);
                removeEntity = null;
            }
        }
        /// <summary>
        /// Returns a list of entities on the scene.
        /// </summary>
        public IList<IEntity> GetEntity()
        {
            return _entityList;
        }
    }
}