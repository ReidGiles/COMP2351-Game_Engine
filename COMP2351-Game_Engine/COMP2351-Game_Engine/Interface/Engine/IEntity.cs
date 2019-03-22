using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace COMP2351_Game_Engine
{
    interface IEntity
    {
        void SetTexture(Texture2D pTexture);
        void SetLocation(float pX, float pY);
        Vector2 GetLocation();

        void SetAIComponentManager(IAIComponentManager pAIComponentManger);
        void SetUp(int pUID, String pUName);
        int GetUID();
        String GetUname();
        void Draw(SpriteBatch spriteBatch);
        void Initialise();

        bool CheckCollider();

        ICreateCollider GetCollider();

    }
}
