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
        public EntityManager()
        {
            _entityList = new List<IEntity>();
        }
        /// <summary>
        /// Returns an instance of requested entity.
        /// </summary>
        public IEntity RequestInstance<T>(Texture2D pTexture) where T : IEntity, new()
        {
            IEntity _entity = new T();
            _entity.SetTexture(pTexture);
            GenerateUID(_entity);
            _entityList.Add(_entity);
            
            return _entity;
        }
        public void GenerateUID(IEntity pEntity)
        {
            _increment++;
            pEntity.SetUp(_increment);
        }
    }
}