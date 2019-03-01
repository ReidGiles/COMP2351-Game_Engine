﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2351_Game_Engine.Component
{
    class KeyboardInputManager
    {
        // create a variable to store all the subscribers to the event
        public event EventHandler<KeyboardInput> NewKeyboardInput;

        public KeyboardInputManager()
        {

        }

        protected virtual void OnNewKeyboardInput()
        {
            // pass the parameters into the new keybaord input then add to NewKeyboardInput 
            KeyboardInput args = new KeyboardInput();
            NewKeyboardInput(this, args);
        }

        public void AddListener(EventHandler<KeyboardInput> handler)
        {
            // ADD event handler
            NewKeyboardInput += handler;
        }

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
