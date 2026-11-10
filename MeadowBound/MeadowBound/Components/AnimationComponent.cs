using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Meadowbound.Components;

public enum FacingDirection
{
    Up = 8,
    Left = 9,
    Down = 10,
    Right = 11
}

public enum AnimationState
{
    Idle,
    Walk,
    Run,
    WateringCan,
    Hoe,
    Plant,
    Harvest
}

public class AnimationComponent
{
    public Dictionary<(AnimationState, FacingDirection), AnimationClip> Animations { get; } = new();

    public AnimationState State { get; private set; }
    public FacingDirection Direction { get; set; }

    public int CurrentFrame { get; private set; }

    public float Timer { get; private set; }

    public AnimationClip? CurrentClip { get; private set; }

    public bool IsFinished => CurrentClip != null && !CurrentClip.IsLooping && CurrentFrame == CurrentClip.Frames.Length - 1 && Timer == 0f;

    public Rectangle? CurrentSourceRectangle => CurrentClip == null ? null : CurrentClip.Frames[CurrentFrame];

    public AnimationComponent()
    {
        State = AnimationState.Idle;
        Direction = FacingDirection.Down;
        CurrentFrame = 0;
        Timer = 0f;
    }

    public void AddAnimation(AnimationState state, FacingDirection direction, AnimationClip clip)
    {
        Animations[(state, direction)] = clip;
    }

    public void SetAnimation(AnimationState state, FacingDirection direction)
    {
        if (State == state && Direction == direction && CurrentClip != null)
            return;

        if (!Animations.TryGetValue((state, direction), out AnimationClip? clip))
        {
            throw new InvalidOperationException($"Animation {state} facing {direction} has not been registered.");
        }

        State = state;
        Direction = direction;
        CurrentClip = clip;

        CurrentFrame = 0;
        Timer = 0f;
    }

    public void Advance(float deltaTime)
    {
        if (CurrentClip == null || CurrentClip.Frames.Length <= 1)
            return;

        Timer += deltaTime;

        while (Timer >= CurrentClip.FrameDuration)
        {
            Timer -= CurrentClip.FrameDuration;

            if (CurrentFrame < CurrentClip.Frames.Length - 1)
            {
                CurrentFrame++;
            }
            else if (CurrentClip.IsLooping)
            {
                CurrentFrame = 0;
            }
            else
            {
                Timer = 0f;
                break;
            }
        }
    }
}