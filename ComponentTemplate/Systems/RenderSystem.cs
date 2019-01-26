using ComponentTemplate.Components;
using ComponentTemplate.HelperMethods;
using Microsoft.Xna.Framework;

namespace ComponentTemplate.Systems
{
  public class RenderSystem : System
  {
    public RenderSystem(Game1 game)
      : base(game)
    {
    }

    public override SystemTypes SystemType => SystemTypes.Draw;

    public override void Update(GameObject go, GameTime gameTime)
    {
      var transComp = go.Components.Get<TransformComponent>();
      var rendComp = go.Components.Get<RenderComponent>();

      if (Helpers.AnyNull(transComp, rendComp))
        return;

      rendComp.Rectangle = new Rectangle((int)transComp.Position.X, (int)transComp.Position.Y,
                           rendComp.Texture.Width * (int)transComp.Scale.X, rendComp.Texture.Height * (int)transComp.Scale.Y);

      _game.spriteBatch.Draw(rendComp.Texture, rendComp.Rectangle, null, rendComp.Color, transComp.Rotation, new Vector2(0, 0), rendComp.SpriteEffect, 0f);
    }
  }
}
