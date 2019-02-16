using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace COMP2351_Game_Engine
{
    abstract class RelicHunterEntity: Entity, IRelicHunterEntity
    {
        /// <summary>
        /// Basic collision behaviour using rectangle.
        /// Needs updating.
        /// </summary>
        public Rectangle HitBox
        {
            get
            {
                Rectangle hitBox = new Rectangle((int)this.location.X, (int)this.location.Y, texture.Width, texture.Height);
                return hitBox;
            }
        }
        public RelicHunterEntity()
        {
        }
    }
}