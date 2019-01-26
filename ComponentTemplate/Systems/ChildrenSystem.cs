using ComponentTemplate.Components;
using ComponentTemplate.HelperMethods;
using Microsoft.Xna.Framework;

namespace ComponentTemplate.Systems
{
  public class ChildrenSystem : System
  {
    public ChildrenSystem(Game1 game)
      : base(game)
    {
    }

    public override void Update(GameObject go, GameTime gameTime)
    {
      var chilComp = go.Components.Get<ChildComponent>();

      if (Helpers.AnyNull(chilComp))
        return;

      // Remove child after set amount of time
      chilComp.Timer += gameTime.ElapsedGameTime.Seconds;

      if (chilComp.Timer > chilComp.Lifespan)
        go.IsRemoved = true;
    }
  }
}
