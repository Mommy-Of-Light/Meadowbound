using Meadowbound.Components;
using Meadowbound.Entities.Player;
using Microsoft.Xna.Framework;
using System;

namespace Meadowbound.Systems.Animation;

public class AnimationSystem
{
    public void Update(Player player, float deltaTime)
    {
        AnimationComponent animation = player.Animation;
        Vector2 direction = player.Movement.Direction;

        FacingDirection facing = animation.Direction;

        if (direction.LengthSquared() > 0)
        {
            if (Math.Abs(direction.X) > Math.Abs(direction.Y))
            {
                facing = direction.X > 0? FacingDirection.Right: FacingDirection.Left;
            }
            else
            {
                facing = direction.Y > 0? FacingDirection.Down: FacingDirection.Up;
            }
        }

        if (player.IsToolUsed && player.IsToolEquipped)
        {
            animation.SetAnimation(AnimationState.Hoe, facing);
        }

        animation.Advance(deltaTime);

        if (animation.State == AnimationState.Hoe && animation.IsFinished)
        {
            AnimationState desiredState =direction.LengthSquared() > 0? AnimationState.Walk: AnimationState.Idle;

            animation.SetAnimation(desiredState, facing);
        }
        if (animation.State == AnimationState.WateringCan && animation.IsFinished)
        {
            AnimationState desiredState = direction.LengthSquared() > 0 ? AnimationState.Walk : AnimationState.Idle;
            animation.SetAnimation(desiredState, facing);
        }
        else if (player.IsToolUsed && player.IsToolEquipped && player.EquippedTool == ToolType.WateringCan)
        {
            animation.SetAnimation(AnimationState.WateringCan, facing);
        }
        else if (animation.State != AnimationState.Hoe && animation.State != AnimationState.WateringCan && !player.IsToolUsed)
        {
            AnimationState desiredState =direction.LengthSquared() > 0? AnimationState.Walk: AnimationState.Idle;

            animation.SetAnimation(desiredState, facing);
        }
    }
}