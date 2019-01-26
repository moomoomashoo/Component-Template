using Microsoft.Xna.Framework;

namespace ComponentTemplate.Components
{
  public class GravityComponent : Component
  {
    public Vector2 GravityStrength { get; }

    public GravityComponent(Vector2 gravityStrength) => GravityStrength = gravityStrength;
  }
}
