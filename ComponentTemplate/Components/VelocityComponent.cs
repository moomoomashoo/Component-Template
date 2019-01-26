using Microsoft.Xna.Framework;

namespace ComponentTemplate.Components
{
  public class VelocityComponent : Component
  {
    public Vector2 Velocity { get; set; }
    public int Speed { get; }
    public int JumpSpeed { get; set; }
    public float MaxSpeed { get; set; } = 10f;

    public VelocityComponent(int speed = 0, int jumpSpeed = 0)
    {
      Speed = speed;
      JumpSpeed = jumpSpeed;
    }
  }
}
