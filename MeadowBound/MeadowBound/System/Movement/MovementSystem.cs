using Meadowbound.Entities;
using Meadowbound.Core;
using System;
using Microsoft.Xna.Framework;

namespace Meadowbound.Systems.Movement;

public class MovementSystem
{
    public void Update(Entity entity, float deltaTime)
    {
        entity.Transform.Position += entity.Movement.Direction * entity.Movement.Speed * deltaTime;

        // Clamp the position to the screen bounds
        entity.Transform.Position = Vector2.Clamp(entity.Transform.Position, Vector2.Zero, new Vector2(Constants.ScreenWidth - 64, Constants.ScreenHeight - 64));

    }
}