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

        // Determine facing direction
        if (direction.LengthSquared() > 0)
        {
            if (Math.Abs(direction.X) > Math.Abs(direction.Y))
            {
                animation.Direction = direction.X > 0
                    ? FacingDirection.Right
                    : FacingDirection.Left;
            }
            else
            {
                animation.Direction = direction.Y > 0
                    ? FacingDirection.Down
                    : FacingDirection.Up;
            }

            // Select walking animation when appropriate
            if (animation.State == AnimationState.Idle ||
                animation.State == AnimationState.Walk)
            {
                animation.SetAnimation(
                    AnimationState.Walk,
                    animation.Direction);
            }
        }
        else
        {
            // Return to idle when appropriate
            if (animation.State == AnimationState.Walk)
            {
                animation.SetAnimation(
                    AnimationState.Idle,
                    animation.Direction);
            }
        }

        // Advance current animation
        AnimationClip clip = animation.CurrentClip;

        if (clip == null)
            return;

        animation.Timer += deltaTime;

        while (animation.Timer >= clip.FrameDuration)
        {
            animation.Timer -= clip.FrameDuration;

            if (animation.CurrentFrame < clip.Frames.Length - 1)
            {
                animation.CurrentFrame++;
            }
            else if (clip.IsLooping)
            {
                animation.CurrentFrame = 0;
            }
            else
            {
                animation.Timer = 0f;
                break;
            }
        }
    }
}