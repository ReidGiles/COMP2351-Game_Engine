using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace COMP2351_Game_Engine
{
    class Entity : IEntity, IUpdatable
    {
        // Entity texture:
        public Texture2D texture;
        // Entity location:
        public Vector2 location;
        // Entity unique identification number:
        public int _uid;
        // Entity AI Component Manager:
        public IAIComponentManager _aiComponentManager;
        // Entity mind:
        public IMind _mind;
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
        /// Sets entity AI Component Manager
        /// </summary>
        public virtual void SetAIComponentManager(IAIComponentManager pAIComponentManger)
        {
            _aiComponentManager = pAIComponentManger;
        }
        /// <summary>
        /// Sets entity mind
        /// </summary>
        public virtual void SetMind(IMind pMind)
        {
            _mind = pMind;
        }
        /// <summary>
        /// Sets the unique identification number and unique name of the entity.
        /// </summary>
        public virtual void SetUp(int pUID)
        {
            _uid = pUID;
        }
        /// <summary>
        /// Runs on entity creation
        /// </summary>
        public virtual void Initialise()
        {
        }
        /// <summary>
        /// Updates entity location.
        /// </summary>
        public virtual void Translate(float dX, float dY)
        {
            location.X += dX;
            location.Y += dY;
        }

        public int GetUID()
        {
            return _uid;
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