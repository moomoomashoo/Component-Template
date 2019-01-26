using System.Collections.Generic;
using System.Linq;
using ComponentTemplate.Components;

namespace ComponentTemplate.HelperMethods
{
  public static class Helpers
  {
    public static T Get<T>(this IEnumerable<Component> b) where T : Component
    {
      return b.OfType<T>().SingleOrDefault() as T;
    }

    public static IEnumerable<GameObject> GetGameObjectsByID(this IEnumerable<GameObject> gameObjects, string id)
    {
      return gameObjects.Where(i => i.ID == id);
    }

    public static bool AnyNull(params Component[] components)
    {
      return components.Any(c => c == null);
    }
  }
}
