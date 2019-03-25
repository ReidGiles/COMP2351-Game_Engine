using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace COMP2351_Game_Engine
{
    class EntityManager : IEntityManager, IUpdatable
    {
        private int _increment;
        private IList<IEntity> _entityList;
        private ICollisionManager _collisionManager;
        private ISceneGraph _sceneGraph;
        private IEntity _removeEntity;
        public EntityManager(ICollisionManager pCollisionManager, ISceneGraph pSceneGraph)
        {
            _entityList = new List<IEntity>();
            _collisionManager = pCollisionManager;
            _sceneGraph = pSceneGraph;
        }
        /// <summary>
        /// Returns an instance of requested entity.
        /// </summary>
        public IEntity RequestInstance<T>(String pUName, Texture2D pTexture, IAIComponentManager pAIComponentManager) where T : IEntity, new()
        {
            IEntity entity = new T();
            if (entity is ICollisionListener)
            {
                _collisionManager.AddListener(((ICollisionListener)entity).OnNewCollision);
            }
            entity.SetAIComponentManager(pAIComponentManager);
            entity.SetTexture(pTexture);
            entity.Initialise();
            GenerateUID(entity, pUName);
            _entityList.Add(entity);
            
            return entity;
        }

        public IEntity RequestInstance(String pUName)
        {
            foreach (IEntity e in _entityList)
            {
                if (e.GetUname() == pUName)
                {
                    return e;
                }
            }
            return null;
        }

        public void Terminate(int pUID)
        {
            foreach (IEntity e in _entityList)
            {
                if (e.GetUID() == pUID)
                {
                    _removeEntity = e;
                }
            }
            if (_removeEntity != null)
            {
                _sceneGraph.Remove(_removeEntity.GetUID());
                _entityList.Remove(_removeEntity);
                _removeEntity = null;
            }
        }

        public void Terminate(String pUName)
        {
            foreach (IEntity e in _entityList)
            {
                if (e.GetUname() == pUName)
                {
                    _removeEntity = e;
                }
            }
            if (_removeEntity != null)
            {
                _sceneGraph.Remove(_removeEntity.GetUID());
                _entityList.Remove(_removeEntity);
                _removeEntity = null;
            }
        }

        /// <summary>
        /// Generates entity unique identification number
        /// </summary>
        private void GenerateUID(IEntity pEntity, String pUName)
        {
            _increment++;
            Console.WriteLine(_increment);
            pEntity.SetUp(_increment, pUName);
        }

        public void Update()
        {
            foreach (IEntity e in _entityList)
            {
                if (e.KillSelf())
                {
                    _removeEntity = e;
                }
            }
            if (_removeEntity != null)
            {
                Terminate(_removeEntity.GetUID());
                _entityList.Remove(_removeEntity);
                _removeEntity = null;
            }
        }
    }
}