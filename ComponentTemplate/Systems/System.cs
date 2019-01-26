using Microsoft.Xna.Framework;

namespace ComponentTemplate
{
  public enum SystemTypes
  {
    Update,
    Draw,
  }

  public abstract class System
  {
    protected Game1 _game;

    public System(Game1 game)
    {
      _game = game;
    }

    public virtual SystemTypes SystemType { get; } = SystemTypes.Update;

    public abstract void Update(GameObject go, GameTime gameTime);

    public void Update(GameTime gameTime)
    {
      foreach (var go in _game.gameObjects)
        Update(go, gameTime);
    }
  }
}
