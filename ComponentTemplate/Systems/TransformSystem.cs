using ComponentTemplate.Components;
using ComponentTemplate.HelperMethods;
using Microsoft.Xna.Framework;

namespace ComponentTemplate.Systems
{
  public class TransformSystem : System
  {
    public TransformSystem(Game1 game)
      : base(game)
    {
    }

    public override void Update(GameObject go, GameTime gameTime)
    {
      var transComp = go.Components.Get<TransformComponent>();
      var velComp = go.Components.Get<VelocityComponent>();
      var rendComp = go.Components.Get<RenderComponent>();

      if (Helpers.AnyNull(transComp, rendComp))
        return;

      if (velComp != null)
        transComp.Position += velComp.Velocity;

      transComp.Rectangle = new Rectangle((int)transComp.Position.X, (int)transComp.Position.Y,
                            rendComp.Texture.Width * (int)transComp.Scale.X, rendComp.Texture.Height * (int)transComp.Scale.Y);
    }
  }
}
