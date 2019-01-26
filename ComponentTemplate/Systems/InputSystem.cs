using ComponentTemplate.Components;
using ComponentTemplate.Factories;
using ComponentTemplate.HelperMethods;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ComponentTemplate.Systems
{
  public class InputSystem : System
  {
    public InputSystem(Game1 game)
      : base(game)
    {
    }

    bool canShoot = false;

    public override void Update(GameObject go, GameTime gameTime)
    {
      var posComp = go.Components.Get<TransformComponent>();
      var inpComp = go.Components.Get<PlayerInputComponent>();
      var velComp = go.Components.Get<VelocityComponent>();
      var proComp = go.Components.Get<ParentComponent>();

      if (Helpers.AnyNull(posComp, inpComp, velComp, proComp))
        return;

      var currentKey = Keyboard.GetState();

      Vector2 tempVelocity = velComp.Velocity;

      if (currentKey.IsKeyDown(inpComp.Up) && posComp.OnFloor)
        tempVelocity.Y = -velComp.JumpSpeed;

      if (currentKey.IsKeyDown(inpComp.Left))
        tempVelocity.X = -velComp.Speed;
      else if (currentKey.IsKeyDown(inpComp.Right))
        tempVelocity.X = velComp.Speed;

      MouseState mouse = Mouse.GetState();

      if (mouse.LeftButton == ButtonState.Released)
        canShoot = true;

      // TODO: Add in Controller support
      //if (currentKey.IsKeyDown(inpComp.Shoot))
      if (mouse.LeftButton == ButtonState.Pressed && canShoot)
      {
        Vector2 direction = new Vector2(mouse.X, mouse.Y) - posComp.Position;
        direction.Normalize();

        var bullet = EntityFactory.CreateBullet(proComp.Texture, posComp.Position);
        var bVelComp = bullet.Components.Get<VelocityComponent>();
        bVelComp.Velocity = direction * bVelComp.Speed;
        go.Children.Add(bullet);
        canShoot = false;
      }

      velComp.Velocity = tempVelocity;
    }
  }
}
