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
        public SceneGraph()
        {
            _entityList = new List<IEntity>();
        }
        public void Spawn(IEntity pEntity, float pX, float pY)
        {
            // Record entity has been spawned
            _entityList.Add(pEntity);
        }
        public IList<IEntity> GetEntity()
        {
            return _entityList;
        }
    }
}