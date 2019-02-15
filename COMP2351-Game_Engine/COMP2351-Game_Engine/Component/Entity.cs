using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace COMP2351_Game_Engine
{
    class Entity : IEntity
    {
        public Texture2D texture;
        public Vector2 location;
        public virtual void Update()
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