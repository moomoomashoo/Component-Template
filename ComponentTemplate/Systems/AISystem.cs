using System.Linq;
using ComponentTemplate.Components;
using ComponentTemplate.HelperMethods;
using Microsoft.Xna.Framework;

namespace ComponentTemplate.Systems
{
  public class AISystem : System
  {
    public AISystem(Game1 game)
      : base(game)
    {
    }

    public override void Update(GameObject go, GameTime gameTime)
    {
      var aiComp = go.Components.Get<AIComponent>();
      var velComp = go.Components.Get<VelocityComponent>();

      if (Helpers.AnyNull(aiComp, velComp))
        return;

      // Honestly this does nothing useful
      // Just making sure it works
      velComp.Velocity = new Vector2(velComp.Speed, 0);
    }
  }
}
