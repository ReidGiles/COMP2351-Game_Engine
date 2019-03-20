using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2351_Game_Engine
{
    class KeyboardInputManager : IInputManager, IUpdatable
    {
        // create a variable to store all the subscribers to the event
        public event EventHandler<IKeyboardInput> NewKeyboardInput;

        public KeyboardInputManager()
        {
        }

        protected virtual void OnNewKeyboardInput()
        {
            // pass the parameters into the new keybaord input then add to NewKeyboardInput
            IKeyboardInput args = new KeyboardHandler();
            NewKeyboardInput(this, args);
        }

        public void AddListener(EventHandler<IKeyboardInput> handler)
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

    /*class Game
    {
        public void someMethod()
        {
            // Create player.
            IEntity entity = new Player();

            // Keyboard inp manager.
            KeyboardInputManager inputManager = new KeyboardInputManager();

            if (entity is IKeyboardListener)
            {
                inputManager.AddListener(((IKeyboardListener)entity).OnNewKeyboardInput);
            }
        }
    }*/
}