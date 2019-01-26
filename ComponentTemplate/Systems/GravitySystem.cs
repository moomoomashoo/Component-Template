using ComponentTemplate.Components;
using ComponentTemplate.HelperMethods;
using Microsoft.Xna.Framework;

namespace ComponentTemplate.Systems
{
  public class GravitySystem : System
  {
    public GravitySystem(Game1 game)
      : base(game)
    {
    }

    public override void Update(GameObject go, GameTime gameTime)
    {
      var transComp = go.Components.Get<TransformComponent>();
      var gravComp = go.Components.Get<GravityComponent>();
      var veloComp = go.Components.Get<VelocityComponent>();

      if (Helpers.AnyNull(transComp, gravComp, veloComp))
        return;

      if (transComp.OnFloor)
        return;

      veloComp.Velocity += gravComp.GravityStrength;
    }
  }
}
