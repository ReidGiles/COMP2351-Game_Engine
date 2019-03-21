using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace COMP2351_Game_Engine
{
    abstract class Mind : IMind, IUpdatable
    {
        // Entity texture:
        public Texture2D _texture;
        // Entity location:
        public Vector2 _location;

        /// <summary>
        /// Updates entity location
        /// </summary>
        public void UpdateLocation(Vector2 pLocation)
        {
            _location = pLocation;
        }

        /// <summary>
        /// Updates entity texture
        /// </summary>
        public void UpdateTexture(Texture2D pTexture)
        {
            _texture = pTexture;
        }

        /// <summary>
        /// Translates x position
        /// </summary>
        public virtual float TranslateX()
        {
            return 0;
        }

        /// <summary>
        /// Translates y position
        /// </summary>
        public virtual float TranslateY()
        {
            return 0;
        }

        /// <summary>
        /// Updates mind, called by AIComponentManager
        /// </summary>
        public virtual void Update()
        {
        }
    }
}