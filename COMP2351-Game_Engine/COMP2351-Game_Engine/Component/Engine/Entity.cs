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
        protected Texture2D texture;
        // Entity location:
        protected Vector2 location;
        // Entity unique identification number:
        protected int _uid;
        // Entity unique name:
        protected String _uName;
        // Entity AI Component Manager:
        protected IAIComponentManager _aiComponentManager;
        // Entity collider:
        protected List<ICollider> _collider;
        // Entity mind:
        protected IMind _mind;
        protected bool hasCollider = false;
        protected bool _killSelf = false;
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

        public virtual bool KillSelf()
        {
            return _killSelf;
        }

        public virtual void SetCollider()
        {
            
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
        public virtual void SetUp(int pUID, String pUName)
        {
            _uid = pUID;
            _uName = pUName;
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
        /// <summary>
        /// Returns entity unique identification.
        /// </summary>
        public int GetUID()
        {
            return _uid;
        }
        // <summary>
        /// Returns entity unique name.
        /// </summary>
        public String GetUname()
        {
            return _uName;
        }
        /// <summary>
        /// Draws entity on the scene.
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, location, Color.AntiqueWhite);
        }

        public bool CheckCollider()
        {
            return hasCollider;
        }

        public List<ICreateCollider> GetCollider()
        {
            List<ICreateCollider> L = _collider.Cast<ICreateCollider>().ToList();
            return L;
        }
    }
}