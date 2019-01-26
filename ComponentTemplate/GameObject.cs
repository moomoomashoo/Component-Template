using System.Collections.Generic;
using ComponentTemplate.Components;

namespace ComponentTemplate
{
  public class GameObject
  {
    public string ID { get; }
    public bool IsRemoved { get; set; } = false;
    public List<GameObject> Children { get; set; } = new List<GameObject>();

    public List<Component> Components { get; set; }

    public GameObject(string id)
    {
      ID = id;
      Components = new List<Component>();
    }

    public void Add(Component component)
    {
      Components.Add(component);
    }

    /// <summary>
    /// Override the ToString to make it easy to see what game object you're looking at
    /// </summary>
    /// <returns>Object ID plus list of components</returns>
    public override string ToString() => $"{ID}: {string.Join(", ", Components)}";
  }
}
