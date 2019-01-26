using System.Collections.Generic;
using System.Linq;
using ComponentTemplate.Factories;
using ComponentTemplate.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ComponentTemplate
{
  /// <summary>
  /// This is the main type for your game.
  /// </summary>
  public class Game1 : Game
  {
    readonly GraphicsDeviceManager graphics;
    public SpriteBatch spriteBatch;

    public List<GameObject> gameObjects;
    public List<System> systems;

    public Game1()
    {
      graphics = new GraphicsDeviceManager(this);
      graphics.SynchronizeWithVerticalRetrace = false;
      IsFixedTimeStep = false;
      IsMouseVisible = true;
      Content.RootDirectory = "Content";
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
      systems = new List<System>
      {
        new GravitySystem(this),
        new PhysicsSystem(this),
        new InputSystem(this),
        new AISystem(this),
        new TransformSystem(this),
        new CollisionSystem(this),
        new ChildrenSystem(this),
        new RenderSystem(this),
      };

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

      var characterTexture = Content.Load<Texture2D>("Character");
      var bulletTexture = Content.Load<Texture2D>("Bullet");
      var platformTexture = Content.Load<Texture2D>("Platform");


      gameObjects = new List<GameObject>
      {
        EntityFactory.CreatePlayer(new[] { characterTexture, bulletTexture}, new Vector2(100, 300)),
        EntityFactory.CreatePlatform(platformTexture, new Vector2(100, 400)),
        //EntityFactory.CreateEnemy(characterTexture, new Vector2(200, 100)), 
      };
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

      // Add all children to game object list
      for (int i = 0; i < gameObjects.Count; i++)
      {
        GameObject go = gameObjects[i];
        foreach (var child in go.Children)
          gameObjects.Add(child);
        go.Children = new List<GameObject>();
      }

      // Loop through systems (except Draw)
      foreach (var sys in systems.Where(s => s.SystemType == SystemTypes.Update))
        sys.Update(gameTime);

      // remove game objects that are flagged to be removed
      for (int i = 0; i < gameObjects.Count; i++)
      {
        if (gameObjects[i].IsRemoved)
        {
          gameObjects.RemoveAt(i);
          i--;
        }
      }

      base.Update(gameTime);
    }

    /// <summary>
    /// This is called when the game should draw itself.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Draw(GameTime gameTime)
    {
      GraphicsDevice.Clear(Color.CornflowerBlue);

      spriteBatch.Begin();

      foreach (var sys in systems.Where(s => s.SystemType == SystemTypes.Draw))
        sys.Update(gameTime);

      spriteBatch.End();

      base.Draw(gameTime);
    }
  }
}
