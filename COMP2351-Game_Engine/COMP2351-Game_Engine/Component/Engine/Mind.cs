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

        public void UpdateLocation(Vector2 pLocation)
        {
            _location = pLocation;
        }

        public void UpdateTexture(Texture2D pTexture)
        {
            _texture = pTexture;
        }

        public virtual float TranslateX()
        {
            return 0;
        }

        public virtual float TranslateY()
        {
            return 0;
        }

        public virtual void Update()
        {
        }
    }
}