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
        IEntity _entity;
        public EntityManager()
        {
        }
        public IEntity GetEntity(string pEntity, Texture2D pTexture)
        {
            if (pEntity == "player")
            {
                IPlayer player = new Player();
                player.SetTexture(pTexture);
                player.setLocation(5,5);
                _entity = (IEntity)player;
            }
            return _entity;
        }
    }
}