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
    Water,
    Hoe,
    Plant,
    Harvest
}

public class AnimationComponent
{
    public Dictionary<(AnimationState, FacingDirection), AnimationClip> Animations
    { get; } = new();

    public AnimationState State { get; private set; }
    public FacingDirection Direction { get; set; }

    public int CurrentFrame { get; private set; }

    public float Timer { get; set; }

    public AnimationClip CurrentClip { get; private set; }

    public Rectangle CurrentSourceRectangle =>
        CurrentClip.Frames[CurrentFrame];

    public AnimationComponent()
    {
        State = AnimationState.Idle;
        Direction = FacingDirection.Down;
        CurrentFrame = 0;
        Timer = 0f;
    }

    public void AddAnimation(
        AnimationState state,
        FacingDirection direction,
        AnimationClip clip)
    {
        Animations[(state, direction)] = clip;
    }

    public void SetAnimation(
        AnimationState state,
        FacingDirection direction)
    {
        if (State == state && Direction == direction)
            return;

        State = state;
        Direction = direction;

        CurrentFrame = 0;
        Timer = 0f;

        CurrentClip = Animations[(state, direction)];
    }
}