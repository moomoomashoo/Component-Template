using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ComponentTemplate.Components
{
  public class RenderComponent : Component
  {
    public Texture2D Texture { get; }
    public Color Color { get; set; } = Color.White;
    public SpriteEffects SpriteEffect { get; set; }
    public Rectangle Rectangle { get; set; }

    public RenderComponent(Texture2D texture) => Texture = texture;
  }
}
