using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace COMP2351_Game_Engine
{
    class EngineDemo : IKeyboardListener, IMouseListener
    {
        // reference to the entity manager
        private IEntityManager entityManager;
        // refernce to the scene manager
        private ISceneManager sceneManager;
        // reference to the collision manager
        private ICollisionManager collisionManager;
        // reference to the AI component manager
        private IAIComponentManager aiComponentManager;
        // reference to the input manager
        private IInputManager inputManager;
        // reference to teh scene graph
        private ISceneGraph sceneGraph;
        // reference to the textures used
        private Texture2D[] textures;
        // reference to the muse position on the display
        private int[] mouseVal;
        // bool used to reset spawn buttons
        bool disableSpawn = false;
        // int used to count key presses for manual removal of enitities
        int f = 0;

        // constructor for the class
        public EngineDemo()
        {
        }
        
        // method to initialise the class
        public void Initialise(IEntityManager pEntityManager, ISceneManager pSceneManager, ICollisionManager pCollisionManager, IAIComponentManager pAiComponentManager, IInputManager pInputManager, ISceneGraph pSceneGraph)
        {
            sceneGraph = pSceneGraph;
            collisionManager = pCollisionManager;
            entityManager = pEntityManager;
            sceneManager = pSceneManager;
            inputManager = pInputManager;
            aiComponentManager = pAiComponentManager;
        }

        // method to set the value of textures
        public void LoadTextures(Texture2D[] pTextures)
        {
            textures = pTextures;
        }

        // keyboard event to listen for keyboard inputs
        public void OnNewKeyboardInput(object sender, IKeyboardInput args)
        {
            foreach (Keys k in args.GetInputKey())
            {
                switch(k)
                {
                    case Keys.D1:
                        if (!disableSpawn)
                        {
                            // Request player entity from entity manager
                            IEntity entity = entityManager.RequestInstance<Player>("Player", textures[0], aiComponentManager);
                            // Scene manager places entity on the scene
                            sceneManager.Spawn(entity, 0, 0);
                        }
                        disableSpawn = true;
                        break;
                    case Keys.D2:
                        if (!disableSpawn)
                        {
                            // Request Hostile entity from entity manager
                            IEntity entity = entityManager.RequestInstance<Hostile>("Hostile1", textures[1], aiComponentManager);
                            // Scene manager places entity on the scene
                            sceneManager.Spawn(entity, 200, 600);
                        }
                        disableSpawn = true;
                        break;
                    case Keys.D3:
                        if (!disableSpawn)
                        {
                            // Request Floor entity from entity manager
                            IEntity entity = entityManager.RequestInstance<Floor>("Floor", textures[2], aiComponentManager);
                            // Scene manager places entity on the scene
                            sceneManager.Spawn(entity, 800, 600);
                        }
                        disableSpawn = true;
                        break;
                    case Keys.D5:
                        if (!disableSpawn)
                        {
                            // remove entity from the display with the name Hostile1 
                            sceneManager.Remove("Hostile1");
                        }
                        disableSpawn = true;
                        break;
                    case Keys.D6:
                        if (!disableSpawn)
                        {
                            // remove entity from the display with the name Player 
                            sceneManager.Remove("Player");
                        }
                        disableSpawn = true;
                        break;
                    case Keys.Z:
                        // reset the disable spawn bool
                        disableSpawn = false;
                        break;
                    case Keys.D9:
                        if (!disableSpawn)
                        {
                            // request an existing instance of a entity by its uName
                            IEntity entity = entityManager.RequestInstance("Player");
                            if (entity != null)
                            {
                                // place the entity on the scene
                                sceneManager.Spawn(entity, 500, 500);
                            }
                        }
                        disableSpawn = true;
                        break;
                    case Keys.F:
                        if (!disableSpawn)
                        {
                            // increment the int f
                            f++;
                            // remove teh entity with the uID = to f
                            entityManager.Terminate(f);
                        }
                        disableSpawn = true;
                        break;
                    case Keys.Q:
                        if (!disableSpawn)
                        {
                            // request an existing instance of a entity by its uName
                            IEntity entity = entityManager.RequestInstance("Player");
                            if (entity != null)
                            {
                                // swap out the min in the entity to a HostileMind
                                entity.SetMind(aiComponentManager.RequestMind<HostileMind>());
                            }
                        }
                        disableSpawn = true;
                        break;
                }
            }
        }

        // Mouse event to listen for Mouse inputs
        public void OnNewMouseInput(object sender, IMouseInput args)
        {
            if (!disableSpawn)
            {
                // set mouse vale to the position of the mouse at the event time
                mouseVal = new int[] { args.GetMouseVal()[0], args.GetMouseVal()[1] };
                // Request entity from entity manager
                IEntity entity = entityManager.RequestInstance<Hostile>("Hostile1", textures[1], aiComponentManager);
                // Scene manager places entity on the scene
                sceneManager.Spawn(entity, mouseVal[0], mouseVal[1]);
            }
            disableSpawn = true;
        }

        // update the class 
        public void Update()
        {

        }
    }
}
