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
        // reference to the mind ID
        protected String _mindID;
        // list of the colliders in the mind
        protected List<ICreateCollider> _colliders;
        // this entities collider
        protected String _collidedThis;
        // enitity that collided with this entities collider
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
        /// Updates entity texture
        /// </summary>
        public void SetCollider(List<ICreateCollider> pColliders)
        {
            _colliders = pColliders;
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

        public virtual bool OnNewCollision(ICollisionInput args,int pUID)
        {
            if (pUID == args.GetUID()[0] || pUID == args.GetUID()[1])
            {
                if (_colliders != null)
                {
                    foreach (ICreateCollider i in _colliders)
                    {
                        if (i.GetTag() == args.GetCollided()[0])
                        {
                            _collidedThis = args.GetCollided()[0];
                            _collidedWith = args.GetCollided()[1];
                        }
                        else
                        {
                            _collidedThis = args.GetCollided()[1];
                            _collidedWith = args.GetCollided()[0];
                        }
                    }
                } 
            }
            //return whether the entity should kill itself
            return false;
        }

        /// <summary>
        /// Updates mind, called by AIComponentManager
        /// </summary>
        public virtual void Update()
        {
        }
    }
}