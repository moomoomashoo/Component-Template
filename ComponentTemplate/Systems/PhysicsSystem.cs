using ComponentTemplate.Components;
using ComponentTemplate.HelperMethods;
using Microsoft.Xna.Framework;

namespace ComponentTemplate.Systems
{
  public class PhysicsSystem : System
  {
    public PhysicsSystem(Game1 game)
      : base(game)
    {
    }

    public override void Update(GameObject go, GameTime gameTime)
    {
      var velComp = go.Components.Get<VelocityComponent>();

      if (Helpers.AnyNull(velComp))
        return;

      // All this does is set a max speed
      var tempVelX = velComp.Velocity.X > velComp.MaxSpeed ? velComp.MaxSpeed : velComp.Velocity.X;
      var tempVelY = velComp.Velocity.Y > velComp.MaxSpeed ? velComp.MaxSpeed : velComp.Velocity.Y;

      velComp.Velocity = new Vector2(tempVelX, tempVelY);
    }
  }
}
