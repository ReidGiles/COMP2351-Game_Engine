using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace COMP2351_Game_Engine
{
    class SceneManager : ISceneManager
    {
        IList<IEntity> _entityList;
        public SceneManager()
        {
            _entityList = new List<IEntity>();
        }
        public void Spawn(IRelicHunterEntity pEntity, float pX, float pY)
        {
            // Initial translation
            IPlayer player = (IPlayer)pEntity;
            player.setLocation(pX, pY);
            _entityList.Add( (IEntity)player );
        }
        public void Update()
        {
            // Update all entities
            foreach (IEntity e in _entityList)
            {
                e.Update();
            }
        }
    }
}