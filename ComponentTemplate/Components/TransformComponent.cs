using Microsoft.Xna.Framework;

namespace ComponentTemplate.Components
{
  public class TransformComponent : Component
  {
    public Vector2 Position { get; set; }
    public Vector2 Scale { get; set; } = Vector2.One;
    public float Rotation { get; set; }
    public Rectangle Rectangle { get; set; }
    public bool OnFloor { get; set; }

    public TransformComponent(Vector2 pos) => Position = pos;
  }
}
