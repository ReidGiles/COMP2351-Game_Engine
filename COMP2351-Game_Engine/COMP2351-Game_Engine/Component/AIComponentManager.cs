﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace COMP2351_Game_Engine
{
    class AIComponentManager : IUpdatable
    {
        private IList<IMind> _mindList;
        public AIComponentManager()
        {
            _mindList = new List<IMind>();
        }
        /// <summary>
        /// Returns an instance of requested entity.
        /// </summary>
        public IMind RequestMind<T>(Texture2D pTexture) where T : IMind, new()
        {
            IMind mind = new T();
            _mindList.Add(mind);

            return mind;
        }

        public void Update()
        {
            foreach (IMind mind in _mindList)
            {
                ( (IUpdatable)mind).Update();
            }
        }
    }
}