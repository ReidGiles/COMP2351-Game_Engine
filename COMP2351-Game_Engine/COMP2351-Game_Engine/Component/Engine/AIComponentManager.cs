using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace COMP2351_Game_Engine
{
    class AIComponentManager : IUpdatable, IAIComponentManager
    {
        private IList<IMind> _mindList;
        private IInputManager _inputManager;
        public AIComponentManager(IInputManager pInputManager)
        {
            _mindList = new List<IMind>();
            _inputManager = pInputManager;
        }
        /// <summary>
        /// Returns an instance of requested entity.
        /// </summary>
        public IMind RequestMind<T>() where T : IMind, new()
        {
            IMind mind = new T();
            if (mind is IKeyboardListener)
            {
                _inputManager.AddListener(((IKeyboardListener)mind).OnNewKeyboardInput);
            }
            _mindList.Add(mind);

            return mind;
        }

        /// <summary>
        /// Updates all minds
        /// </summary>
        public void Update()
        {
            foreach (IMind m in _mindList)
            {
                ( (IUpdatable)m).Update();
            }
        }
    }
}