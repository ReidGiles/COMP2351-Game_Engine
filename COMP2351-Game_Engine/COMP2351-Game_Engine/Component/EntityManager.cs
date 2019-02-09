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
        IRelicHunterEntity _entity;
        public EntityManager()
        {
        }
        public IRelicHunterEntity GetEntity(string pEntity, Texture2D pTexture)
        {
            if (pEntity == "player")
            {
                IPlayer player = new Player();
                player.SetTexture(pTexture);
                _entity = (IRelicHunterEntity)player;
            }
            return _entity;
        }
    }
}