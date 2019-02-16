﻿using System;
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
        public int UID;
        public string UName;
        /// <summary>
        /// Called by scene manager, updates entities on the scene.
        /// </summary>
        public virtual void Update()
        {
        }
        /// <summary>
        /// Sets entity texture.
        /// </summary>
        public virtual void SetTexture(Texture2D pTexture)
        {
            texture = pTexture;
        }
        /// <summary>
        /// Sets entity location
        /// </summary>
        public virtual void SetLocation(float pX, float pY)
        {
            location.X = pX;
            location.Y = pY;
        }
        /// <summary>
        /// Sets the unique identification number and unique name of the entity.
        /// </summary>
        public virtual void Setup(int pUID, string pUName)
        {
            UID = pUID;
            UName = pUName;
        }
        /// <summary>
        /// Draws entity on the scene.
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, location, Color.AntiqueWhite);
        }
    }
}