﻿using Microsoft.Xna.Framework.Input;

namespace ComponentTemplate.Components
{
  public class PlayerInputComponent : Component
  {
    public Keys Up { get; set; }
    public Keys Down { get; set; }
    public Keys Left { get; set; }
    public Keys Right { get; set; }
    public Keys Shoot { get; set; }
  }
}
