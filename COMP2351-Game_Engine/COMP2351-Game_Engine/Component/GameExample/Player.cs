using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace COMP2351_Game_Engine
{
    class Player : RelicHunterEntity, IPlayer
    {
        public Player()
        {
        }

        /// <summary>
        /// Required for Input management of the keyboard
        /// </summary>
        public virtual void OnNewKeyboardInput()
        {
            //code in here
        }

        /// <summary>
        /// Initialisation logic
        /// </summary>
        public override void Initialise()
        {
            // Set initial entity mind:
            _mind = _aiComponentManager.RequestMind<PlayerMind>();
        }

        /// <summary>
        /// Overides Update() with unique entity behaviour.
        /// </summary>
        public override void Update()
        {       
            /*if (location.Y <= 900 - texture.Height)
            {
                Translate(0, gravity);
            }*/

            if (_mind != null)
            {
                _mind.UpdateLocation(location);
                _mind.UpdateTexture(texture);
                Translate(_mind.TranslateX(), _mind.TranslateY());
            }
            else Console.WriteLine("Error: Mind is null");
        }
    }
}