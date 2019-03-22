﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2351_Game_Engine
{
    class KeyboardInputManager : IInputManager, IUpdatable
    {
        // create a variable to store all the subscribers to the event
        private event EventHandler<IKeyboardInput> NewKeyboardInput;

        public KeyboardInputManager()
        {
        }

        /// <summary>
        /// Publisher method, contacts all listeners
        /// </summary>
        protected virtual void OnNewKeyboardInput()
        {
            // pass the parameters into the new keybaord input then add to NewKeyboardInput
            IKeyboardInput args = new KeyboardHandler();
            NewKeyboardInput(this, args);
        }

        /// <summary>
        /// Subscription method, used to store reference to listeners
        /// </summary>
        public void AddListener(EventHandler<IKeyboardInput> handler)
        {
            // ADD event handler
            NewKeyboardInput += handler;
        }

        /// <summary>
        /// Runs publisher methods when input is detected
        /// </summary>
        public void Update()
        {
            // look for changes in the input

            if (NewKeyboardInput!= null)
            {
                // update listeners
                OnNewKeyboardInput();
            }
        }
    }
}