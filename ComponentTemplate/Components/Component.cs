namespace ComponentTemplate.Components
{
  public abstract class Component
  {
    public override string ToString() => GetType().Name.Replace("Component", "");
  }
}
