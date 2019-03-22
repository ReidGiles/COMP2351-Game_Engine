using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace COMP2351_Game_Engine
{
    class EntityManager : IEntityManager
    {
        private int _increment;
        private IList<IEntity> _entityList;
        private ICollisionManager _collisionManager;
        public EntityManager(ICollisionManager pCollisionManager)
        {
            _entityList = new List<IEntity>();
            _collisionManager = pCollisionManager;
        }
        /// <summary>
        /// Returns an instance of requested entity.
        /// </summary>
        public IEntity RequestInstance<T>(Texture2D pTexture, IAIComponentManager pAIComponentManager) where T : IEntity, new()
        {
            IEntity entity = new T();
            if (entity is ICollisionListener)
            {
                _collisionManager.AddListener(((ICollisionListener)entity).OnNewCollision);
            }
            entity.SetAIComponentManager(pAIComponentManager);
            entity.SetTexture(pTexture);
            entity.Initialise();
            GenerateUID(entity);
            _entityList.Add(entity);
            
            return entity;
        }

        /// <summary>
        /// Generates entity unique identification number
        /// </summary>
        public void GenerateUID(IEntity pEntity)
        {
            _increment++;
            pEntity.SetUp(_increment);
        }
    }
}