using System.Linq;
using ComponentTemplate.Components;
using ComponentTemplate.HelperMethods;
using Microsoft.Xna.Framework;

namespace ComponentTemplate.Systems
{
  public class CollisionSystem : System
  {
    public CollisionSystem(Game1 game)
      : base(game)
    {
    }

    public override void Update(GameObject go, GameTime gameTime)
    {
      var transComp = go.Components.Get<TransformComponent>();
      var rendComp = go.Components.Get<RenderComponent>();
      var velComp = go.Components.Get<VelocityComponent>();
      var colComp = go.Components.Get<CollidableComponent>();

      if (Helpers.AnyNull(transComp, rendComp, velComp, colComp))
        return;

      transComp.OnFloor = false;

      // None of the below is 100% perfect but it seems to work for now.
      foreach (var collidable in _game.gameObjects.Where(col => col.Components.Get<CollidableComponent>() != null).Select(col => col.Components.Get<TransformComponent>()))
      {
        if (transComp.Equals(collidable))
          continue;

        if (CollideRight(transComp.Rectangle, collidable.Rectangle))
        {
          transComp.Position = new Vector2(collidable.Position.X - transComp.Rectangle.Width, transComp.Position.Y);
          velComp.Velocity = new Vector2(0, velComp.Velocity.Y);
        }

        if (CollideLeft(transComp.Rectangle, collidable.Rectangle))
        {
          transComp.Position = new Vector2(collidable.Position.X + collidable.Rectangle.Width, transComp.Position.Y);
          velComp.Velocity = new Vector2(0, velComp.Velocity.Y);
        }

        if (CollideUp(transComp.Rectangle, collidable.Rectangle))
        {
          transComp.Position = new Vector2(transComp.Position.X, collidable.Position.Y + collidable.Rectangle.Height);
          velComp.Velocity = new Vector2(velComp.Velocity.X, 0);
        }

        if (CollideDown(transComp.Rectangle, collidable.Rectangle))
        {
          transComp.OnFloor = true;
          transComp.Position = new Vector2(transComp.Position.X, collidable.Position.Y - transComp.Rectangle.Height);
          velComp.Velocity = new Vector2(velComp.Velocity.X, 0);
        }
      }
    }

    private bool CollideRight(Rectangle sprite, Rectangle collisionSprite)
    {
      return (sprite.Bottom > collisionSprite.Top &&
          sprite.Top < collisionSprite.Bottom &&
          sprite.Left < collisionSprite.Left &&
          sprite.Right >= collisionSprite.Left);
    }

    private bool CollideLeft(Rectangle sprite, Rectangle collisionSprite)
    {
      return (sprite.Bottom > collisionSprite.Top &&
          sprite.Top < collisionSprite.Bottom &&
          sprite.Right > collisionSprite.Right &&
          sprite.Left <= collisionSprite.Right);
    }

    private bool CollideDown(Rectangle sprite, Rectangle collisionSprite)
    {
      return (sprite.Right > collisionSprite.Left &&
          sprite.Left < collisionSprite.Right &&
          sprite.Top < collisionSprite.Top &&
          sprite.Bottom >= collisionSprite.Top);
    }

    private bool CollideUp(Rectangle sprite, Rectangle collisionSprite)
    {
      return (sprite.Right > collisionSprite.Left &&
          sprite.Left < collisionSprite.Right &&
          sprite.Bottom > collisionSprite.Bottom &&
          sprite.Top <= collisionSprite.Bottom);
    }
  }
}
