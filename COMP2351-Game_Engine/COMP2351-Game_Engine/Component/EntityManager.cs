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
        Random rndGen;
        public EntityManager()
        {
            rndGen = new Random();
        }
        /// <summary>
        /// Returns an instance of requested entity.
        /// </summary>
        public IEntity RequestInstance<T>(Texture2D pTexture) where T : IEntity, new()
        {
            IEntity _entity = new T();
            _entity.SetTexture(pTexture);
            
            
            return _entity;
        }
        public int RequestUID()
        {
            int UID = rndGen.Next(1, 10000);
            return UID;
        }
        public string RequestUName(IEntity pEntity)
        {
            return "";
        }
    }
}