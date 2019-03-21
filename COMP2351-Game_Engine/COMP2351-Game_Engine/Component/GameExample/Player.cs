using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace COMP2351_Game_Engine
{
    class Player : RelicHunterEntity, IPlayer, ICollisionListener
    {
        public Player()
        {
        }

        /// <summary>
        /// Initialisation logic
        /// </summary>
        public override void Initialise()
        {
            // Set initial entity mind:
            _mind = _aiComponentManager.RequestMind<PlayerMind>();
        }

        public void OnNewCollision(object sender, ICollisionHandler args)
        {
            Console.WriteLine("Collide");
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
            //else Console.WriteLine("Error: Mind is null");
        }
    }
}