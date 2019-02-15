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
        
        public EntityManager()
        {
        }
        public IRelicHunterEntity RequestInstance<T>(Texture2D pTexture) where T : IRelicHunterEntity, new()
        {
            IRelicHunterEntity _entity = new T();
            _entity.SetTexture(pTexture);
            
            
            return _entity;
        }
    }
}