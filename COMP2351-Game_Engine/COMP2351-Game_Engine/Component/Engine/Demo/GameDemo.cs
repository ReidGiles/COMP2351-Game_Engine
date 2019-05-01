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
    class GameDemo : IKeyboardListener, IMouseListener
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
        // Vector2 list for spawning platforms
        private List<Vector2> _platformSpawm;

        // constructor for the class
        public GameDemo()
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
            _platformSpawm = new List<Vector2>();
            LoadLevel();
        }

        // method to set the value of textures
        public void LoadTextures(Texture2D[] pTextures)
        {
            textures = pTextures;
        }

        // method to load the content for the gameDemo
        public void LoadContent()
        {
            // // Request floor entity from entity manager
            for (int i = 0; i < 8; i++)
            {
                IEntity entity = entityManager.RequestInstance<Floor>("Floor", textures[7]);
                // Scene manager places entity on the scene
                sceneManager.Spawn(entity, i*1000 - 800, 900 - textures[7].Height);
            }

            foreach (Vector2 v in _platformSpawm)
            {
                // Request Floor entity from entity manager
                IEntity entity = entityManager.RequestInstance<Platform>("Platform", textures[3]);
                // Scene manager places entity on the scene
                sceneManager.Spawn(entity, v.X, v.Y);
            }

            // Request Hostile entity from entity manager
            IEntity hostile = entityManager.RequestInstance<Hostile>("Hostile1", textures[2]);
            // Scene manager places entity on the scene
            sceneManager.Spawn(hostile, 1100, -450);

        }

        private void LoadLevel()
        {
            // Distance between platforms
            int platformIncrement = 50;

            // Populate the level
            Populate(1350, 550, 3, platformIncrement);
            Populate(1150, 300, 3, platformIncrement);
            Populate(950, 50, 3, platformIncrement);
            Populate(650, -200, 4, platformIncrement);
            Populate(950, -350, 13, platformIncrement);
            Populate(700, -600, 3, platformIncrement);
            Populate(900, -850, 41, platformIncrement);
            Populate(1650, -150, 4, platformIncrement);
        }

        private void Populate(int pXpos, int pYpos, int pLimit, int pIncrement)
        {
            int platformXPosition = pXpos;
            int platformYPosition = pYpos;
            for (int i = 0; i < pLimit; i++)
            {
                _platformSpawm.Add(new Vector2(platformXPosition, platformYPosition));
                platformXPosition += pIncrement;
            }
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
                            IEntity entity = entityManager.RequestInstance<Player>("Player", textures[1]);
                            // Scene manager places entity on the scene
                            sceneManager.Spawn(entity, 0, 300);
                        }
                        disableSpawn = true;
                        break;
                    case Keys.D2:
                        if (!disableSpawn)
                        {
                            // Request Hostile entity from entity manager
                            IEntity entity = entityManager.RequestInstance<Hostile>("Hostile1", textures[2]);
                            // Scene manager places entity on the scene
                            sceneManager.Spawn(entity, 200, 600);
                        }
                        disableSpawn = true;
                        break;
                    case Keys.D3:
                        if (!disableSpawn)
                        {
                            // Request Floor entity from entity manager
                            IEntity entity = entityManager.RequestInstance<Platform>("Platform", textures[3]);
                            // Scene manager places entity on the scene
                            sceneManager.Spawn(entity, 800, 650);
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
                IEntity entity = entityManager.RequestInstance<Hostile>("Hostile1", textures[0]);
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
