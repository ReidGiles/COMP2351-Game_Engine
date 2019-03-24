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
        private IEntityManager entityManager;
        private ISceneManager sceneManager;
        private ICollisionManager collisionManager;
        private IAIComponentManager aiComponentManager;
        private IInputManager inputManager;
        private ISceneGraph sceneGraph;
        private Texture2D[] textures;

        private int[] mouseVal;

        bool disableSpawn = false;

        public EngineDemo()
        {
        }
        
        public void Initialise(IEntityManager pEntityManager, ISceneManager pSceneManager, ICollisionManager pCollisionManager, IAIComponentManager pAiComponentManager, IInputManager pInputManager, ISceneGraph pSceneGraph)
        {
            sceneGraph = pSceneGraph;
            collisionManager = pCollisionManager;
            entityManager = pEntityManager;
            sceneManager = pSceneManager;
            inputManager = pInputManager;
            aiComponentManager = pAiComponentManager;
        }

        public void LoadTextures(Texture2D[] pTextures)
        {
            textures = pTextures;
        }

        public void OnNewKeyboardInput(object sender, IKeyboardInput args)
        {
            foreach (Keys k in args.GetInputKey())
            {
                switch(k)
                {
                    case Keys.NumPad1:
                        if (!disableSpawn)
                        {
                            // Request entity from entity manager
                            IEntity entity = entityManager.RequestInstance<Player>("Player", textures[0], aiComponentManager);
                            // Scene manager places entity on the scene
                            sceneManager.Spawn(entity, 0, 0);
                        }
                        disableSpawn = true;
                        break;
                    case Keys.NumPad2:
                        if (!disableSpawn)
                        {
                            // Request entity from entity manager
                            IEntity entity = entityManager.RequestInstance<Hostile>("Hostile1", textures[1], aiComponentManager);
                            // Scene manager places entity on the scene
                            sceneManager.Spawn(entity, 200, 600);
                        }
                        disableSpawn = true;
                        break;
                    case Keys.NumPad3:
                        if (!disableSpawn)
                        {
                            // Request entity from entity manager
                            IEntity entity = entityManager.RequestInstance<Hostile>("Hostile2", textures[1], aiComponentManager);
                            // Scene manager places entity on the scene
                            sceneManager.Spawn(entity, 1200, 600);
                        }
                        disableSpawn = true;
                        break;
                    case Keys.NumPad5:
                        if (!disableSpawn)
                        {
                            sceneManager.Remove("Hostile1");
                        }
                        disableSpawn = true;
                        break;
                    case Keys.NumPad6:
                        if (!disableSpawn)
                        {
                            sceneManager.Remove("Hostile2");
                        }
                        disableSpawn = true;
                        break;
                    case Keys.Z:
                        disableSpawn = false;
                        break;
                    case Keys.NumPad9:
                        if (!disableSpawn)
                        {
                            IEntity entity = entityManager.RequestInstance("Player");
                            if (entity != null)
                            {
                                sceneManager.Spawn(entity, 500, 500);
                            }
                        }
                        disableSpawn = true;
                        break;
                }
            }
        }

        public void OnNewMouseInput(object sender, IMouseInput args)
        {
            if (!disableSpawn)
            {
                mouseVal = new int[] { args.GetMouseVal()[0], args.GetMouseVal()[1] };
                // Request entity from entity manager
                IEntity entity = entityManager.RequestInstance<Hostile>("Hostile1", textures[1], aiComponentManager);
                // Scene manager places entity on the scene
                sceneManager.Spawn(entity, mouseVal[0], mouseVal[1]);
            }
            disableSpawn = true;
        }

        public void Update()
        {

        }
    }
}
