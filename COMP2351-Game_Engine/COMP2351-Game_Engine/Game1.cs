using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace COMP2351_Game_Engine
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static int ScreenWidth;
        public static int ScreenHeight;
        private IEntityManager entityManager;
        private ISceneManager sceneManager;
        private ICollisionManager collisionManager;
        private IAIComponentManager aiComponentManager;
        private IInputManager inputManager;
        private ISceneGraph sceneGraph;
        private Texture2D[] textures;
        private EngineDemo engineDemo;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 900;
            graphics.PreferredBackBufferWidth = 1600;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ScreenHeight = GraphicsDevice.Viewport.Height;
            ScreenWidth = GraphicsDevice.Viewport.Width;
            sceneGraph = new SceneGraph();
            collisionManager = new CollisionManager(sceneGraph);
            entityManager = new EntityManager(collisionManager, sceneGraph);
            sceneManager = new SceneManager(sceneGraph);
            inputManager = new InputManager();
            aiComponentManager = new AIComponentManager(inputManager);
            engineDemo = new EngineDemo();
            engineDemo.Initialise(entityManager, sceneManager, collisionManager, aiComponentManager, inputManager, sceneGraph);
            inputManager.AddListener(((IKeyboardListener)engineDemo).OnNewKeyboardInput);
            inputManager.AddListener(((IMouseListener)engineDemo).OnNewMouseInput);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            textures = new Texture2D[] { Content.Load<Texture2D>("square"), Content.Load<Texture2D>("paddle"), Content.Load<Texture2D>("Floor") };
            engineDemo.LoadTextures(textures);

            /*

            // Load entity texture
            texture = Content.Load<Texture2D>("square");
            // Request entity from entity manager
            entity = entityManager.RequestInstance<Player>("Player", texture, aiComponentManager);
            // Scene manager places entity on the scene
            sceneManager.Spawn(entity, 0, 0);

            // Request entity from entity manager
            entity = entityManager.RequestInstance<Hostile>("Hostile1", texture, aiComponentManager);
            // Scene manager places entity on the scene
            sceneManager.Spawn(entity, 400, 600);

            //Add a Floor to jump onto
            texture = Content.Load<Texture2D>("Floor");
            entity = entityManager.RequestInstance<Floor>("Floor", texture, aiComponentManager);
            sceneManager.Spawn(entity, 800, ScreenHeight - texture.Height - 100);

            entity = entityManager.RequestInstance<Floor>("Floor", texture, aiComponentManager);
            sceneManager.Spawn(entity, 400, 300);

            // Load entity texture
            texture = Content.Load<Texture2D>("paddle");
            entity = entityManager.RequestInstance<Hostile>("Hostile2", texture, aiComponentManager);
            sceneManager.Spawn(entity, 650, 300);

            */
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            ((IUpdatable)collisionManager).Update();
            ( (IUpdatable)sceneManager).Update();
            ( (IUpdatable)aiComponentManager).Update();
            ((IUpdatable)inputManager).Update();
            engineDemo.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            // Draw all entities from list
            foreach (IEntity e in sceneGraph.GetEntity())
            {
                e.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}