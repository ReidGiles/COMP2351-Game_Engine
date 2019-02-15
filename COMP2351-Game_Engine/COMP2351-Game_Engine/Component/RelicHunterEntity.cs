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
        public Texture2D texture;
        public Vector2 location;
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

        public virtual void SetTexture(Texture2D pTexture)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, location, Color.AntiqueWhite);
        }
    }
}