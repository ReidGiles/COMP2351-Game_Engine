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
        protected Texture2D _texture;
        // Entity location:
        protected Vector2 _location;
        protected String _mindID;
        protected String _collidedWith;

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

        public virtual void OnNewCollision(String[] collided)
        {
            if ((collided[0] == _mindID) && (collided[1] == _mindID))
            {
                _collidedWith = collided[0];
            }
            else if (collided[0] != collided[1])
            {
                if (collided[0] != _mindID)
                {
                    _collidedWith = collided[0];
                }
                else _collidedWith = collided[1];
            }
        }

        /// <summary>
        /// Updates mind, called by AIComponentManager
        /// </summary>
        public virtual void Update()
        {
        }
    }
}