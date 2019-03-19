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
        IInput _input;
        float gravity;
        public Player()
        {
            _input = new Input();
            gravity = 10;
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
            if (location.Y <= 900 - texture.Height)
            {
                Translate(0, gravity);
            }
            location += _input.GetKeyboardInputDirection();

            if (_mind != null)
            {
                _mind.UpdateLocation(location);
            }
            else Console.WriteLine("Error: Mind is null");
        }
    }
}