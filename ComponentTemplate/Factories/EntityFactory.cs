using ComponentTemplate.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ComponentTemplate.Factories
{
  public static class EntityFactory
  {
    public static GameObject CreatePlayer(Texture2D[] textures, Vector2 position)
    {
      var player = new GameObject("Player");

      player.Add(new TransformComponent(position));
      player.Add(new VelocityComponent(2, 10));
      player.Add(new PlayerInputComponent()
      {
        Up = Keys.Up,
        Down = Keys.Down,
        Left = Keys.Left,
        Right = Keys.Right,
        Shoot = Keys.Space,
      });

      player.Add(new GravityComponent(new Vector2(0, 0.2f)));
      player.Add(new CollidableComponent());
      player.Add(new RenderComponent(textures[0]));
      player.Add(new ParentComponent(textures[1]));

      return player;
    }

    public static GameObject CreateEnemy(Texture2D texture, Vector2 position)
    {
      var enemy = new GameObject("Enemy");

      //TODO Redo this

      return enemy;
    }

    public static GameObject CreatePlatform(Texture2D texture, Vector2 position)
    {
      var platform = new GameObject("Platform");

      platform.Add(new TransformComponent(position));
      platform.Add(new RenderComponent(texture));
      platform.Add(new CollidableComponent());

      return platform;
    }

    public static GameObject CreateBullet(Texture2D texture, Vector2 position)
    {
      var bullet = new GameObject("Bullet");

      bullet.Add(new TransformComponent(position));
      bullet.Add(new VelocityComponent(10));

      bullet.Add(new RenderComponent(texture));
      bullet.Add(new GravityComponent(new Vector2(0, 0.2f)));
      bullet.Add(new ChildComponent());

      return bullet;
    }

  }
}
