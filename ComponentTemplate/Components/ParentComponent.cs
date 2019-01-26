using Microsoft.Xna.Framework.Graphics;

namespace ComponentTemplate.Components
{
  // A game object will need this object if they have the capacity to have children
  // i.e. They can shoot
  public class ParentComponent : Component
  {
    public Texture2D Texture { get; set; }

    // This is the texture of the child e.g. bullet
    public ParentComponent(Texture2D texture) => Texture = texture;
  }
}
