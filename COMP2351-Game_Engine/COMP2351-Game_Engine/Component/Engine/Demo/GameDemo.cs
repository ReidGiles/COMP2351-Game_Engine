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
        private List<Vector2> _platformSpawn;
        // Vector2 list for spawning platformsEndL
        private List<Vector2> _platformEndLSpawn;
        // Vector2 list for spawning platformsEndR
        private List<Vector2> _platformEndRSpawn;
        // Vector2 list for spawning platformSingle
        private List<Vector2> _platformSingleSpawn;
        // Vector2 list for spawning hostiles
        private List<Vector2> _hostileSpawn;

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
            _platformSpawn = new List<Vector2>();
            _platformEndLSpawn = new List<Vector2>();
            _platformEndRSpawn = new List<Vector2>();
            _platformSingleSpawn = new List<Vector2>();
            _hostileSpawn = new List<Vector2>();
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

            foreach (Vector2 v in _platformEndLSpawn)
            {
                // Request Floor entity from entity manager
                IEntity entity = entityManager.RequestInstance<PlatformEndL>("PlatformEndL", textures[3]);
                // Scene manager places entity on the scene
                sceneManager.Spawn(entity, v.X, v.Y);
            }

            foreach (Vector2 v in _platformSpawn)
            {
                // Request Floor entity from entity manager
                IEntity entity = entityManager.RequestInstance<Platform>("Platform", textures[3]);
                // Scene manager places entity on the scene
                sceneManager.Spawn(entity, v.X, v.Y);
            }

            foreach (Vector2 v in _platformEndRSpawn)
            {
                // Request Floor entity from entity manager
                IEntity entity = entityManager.RequestInstance<PlatformEndR>("PlatformEndR", textures[3]);
                // Scene manager places entity on the scene
                sceneManager.Spawn(entity, v.X, v.Y);
            }

            foreach (Vector2 v in _platformSingleSpawn)
            {
                // Request Floor entity from entity manager
                IEntity entity = entityManager.RequestInstance<PlatformSingle>("PlatformSingle", textures[3]);
                // Scene manager places entity on the scene
                sceneManager.Spawn(entity, v.X, v.Y);
            }

            foreach (Vector2 v in _hostileSpawn)
            {
                // Request Floor entity from entity manager
                IEntity entity = entityManager.RequestInstance<Hostile>("Hostile", textures[2]);
                // Scene manager places entity on the scene
                sceneManager.Spawn(entity, v.X, v.Y);
            }

        }

        private void LoadLevel()
        {
            // Distance between platforms
            int platformXIncrement = 50;
            int platformYIncrement = 50;

            // Populate the level with the Start point for Platforms
            Populate(1350, 550, 1, platformXIncrement, 0, _platformEndLSpawn);
            Populate(1150, 300, 1, platformXIncrement, 0, _platformEndLSpawn);
            Populate(950, 50, 1, platformXIncrement, 0, _platformEndLSpawn);
            Populate(650, -200, 1, platformXIncrement, 0, _platformEndLSpawn);
            Populate(950, -350, 1, platformXIncrement, 0, _platformEndLSpawn);
            Populate(700, -600, 1, platformXIncrement, 0, _platformEndLSpawn);
            Populate(900, -850, 1, platformXIncrement, 0, _platformEndLSpawn);
            Populate(1650, -150, 1, platformXIncrement, 0, _platformEndLSpawn);
            Populate(1850, 100, 1, platformXIncrement, 0, _platformEndLSpawn);
            Populate(2050, 350, 1, platformXIncrement, 0, _platformEndLSpawn);
            Populate(2900, 650, 1, platformXIncrement, 0, _platformEndLSpawn);
            Populate(3000, 550, 1, platformXIncrement, 0, _platformEndLSpawn);
            Populate(3100, 450, 1, platformXIncrement, 0, _platformEndLSpawn);
            Populate(3200, 350, 1, platformXIncrement, 0, _platformEndLSpawn);
            Populate(3300, 250, 1, platformXIncrement, 0, _platformEndLSpawn);
            Populate(3400, 150, 1, platformXIncrement, 0, _platformEndLSpawn);
            Populate(3500, 50, 1, platformXIncrement, 0, _platformEndLSpawn);
            Populate(3600, -50, 1, platformXIncrement, 0, _platformEndLSpawn);
            Populate(3700, -150, 1, platformXIncrement, 0, _platformEndLSpawn);
            Populate(3800, -250, 1, platformXIncrement, 0, _platformEndLSpawn);
            Populate(3900, -350, 1, platformXIncrement, 0, _platformEndLSpawn);

            // Populate the level with the middle fo the Platforms
            Populate(1400, 550, 1, platformXIncrement, 0, _platformSpawn);
            Populate(1200, 300, 1, platformXIncrement, 0, _platformSpawn);
            Populate(1000, 50, 1, platformXIncrement, 0, _platformSpawn);
            Populate(700, -200, 1, platformXIncrement, 0, _platformSpawn);
            Populate(1000, -350, 11, platformXIncrement, 0, _platformSpawn);
            Populate(750, -600, 1, platformXIncrement, 0, _platformSpawn);
            Populate(950, -850, 40, platformXIncrement, 0, _platformSpawn);
            Populate(1700, -150, 2, platformXIncrement, 0, _platformSpawn);
            Populate(1900, 100, 2, platformXIncrement, 0, _platformSpawn);
            Populate(2100, 350, 2, platformXIncrement, 0, _platformSpawn);
            Populate(2950, 650, 1, platformXIncrement, 0, _platformSpawn);
            Populate(3050, 550, 1, platformXIncrement, 0, _platformSpawn);
            Populate(3150, 450, 1, platformXIncrement, 0, _platformSpawn);
            Populate(3250, 350, 1, platformXIncrement, 0, _platformSpawn);
            Populate(3350, 250, 1, platformXIncrement, 0, _platformSpawn);
            Populate(3450, 150, 1, platformXIncrement, 0, _platformSpawn);
            Populate(3550, 50, 1, platformXIncrement, 0, _platformSpawn);
            Populate(3650, -50, 1, platformXIncrement, 0, _platformSpawn);
            Populate(3750, -150, 1, platformXIncrement, 0, _platformSpawn);
            Populate(3850, -250, 1, platformXIncrement, 0, _platformSpawn);
            Populate(3950, -350, 1, platformXIncrement, 0, _platformSpawn);

            // Populate the level with End point for the Platforms
            Populate(1450, 550, 1, platformXIncrement, 0, _platformEndRSpawn);
            Populate(1250, 300, 1, platformXIncrement, 0, _platformEndRSpawn);
            Populate(1050, 50, 1, platformXIncrement, 0, _platformEndRSpawn);
            Populate(750, -200, 1, platformXIncrement, 0, _platformEndRSpawn);
            Populate(1550, -350, 1, platformXIncrement, 0, _platformEndRSpawn);
            Populate(800, -600, 1, platformXIncrement, 0, _platformEndRSpawn);
            Populate(2950, -850, 1, platformXIncrement, 0, _platformEndRSpawn);
            Populate(1800, -150, 1, platformXIncrement, 0, _platformEndRSpawn);
            Populate(2000, 100, 1, platformXIncrement, 0, _platformEndRSpawn);
            Populate(2200, 350, 1, platformXIncrement, 0, _platformEndRSpawn);
            Populate(3000, 650, 1, platformXIncrement, 0, _platformEndRSpawn);
            Populate(3100, 550, 1, platformXIncrement, 0, _platformEndRSpawn);
            Populate(3200, 450, 1, platformXIncrement, 0, _platformEndRSpawn);
            Populate(3300, 350, 1, platformXIncrement, 0, _platformEndRSpawn);
            Populate(3400, 250, 1, platformXIncrement, 0, _platformEndRSpawn);
            Populate(3500, 150, 1, platformXIncrement, 0, _platformEndRSpawn);
            Populate(3600, 50, 1, platformXIncrement, 0, _platformEndRSpawn);
            Populate(3700, -50, 1, platformXIncrement, 0, _platformEndRSpawn);
            Populate(3800, -150, 1, platformXIncrement, 0, _platformEndRSpawn);
            Populate(3900, -250, 1, platformXIncrement, 0, _platformEndRSpawn);
            Populate(4000, -350, 1, platformXIncrement, 0, _platformEndRSpawn);

            // Populate the level with single platforms
            //Populate(2700, 650, 15, 0, platformYIncrement, _platformSingleSpawn);

            // Populate the level with hostiles
            Populate(1100, -400, 1, 0, 0, _hostileSpawn);
        }

        private void Populate(int pXpos, int pYpos, int pLimit, int pIncrement, int yIncrement, List<Vector2> pList)
        {
            int XPosition = pXpos;
            int YPosition = pYpos;
            for (int i = 0; i < pLimit; i++)
            {
                pList.Add(new Vector2(XPosition, YPosition));
                XPosition += pIncrement;
                YPosition -= yIncrement;
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
