using Microsoft.Xna.Framework;
using System;

namespace Meadowbound.Components;

public class AnimationClip
{
    public Rectangle[] Frames { get; }
    public float FrameDuration { get; }
    public bool IsLooping { get; }

    public AnimationClip(
        Rectangle[] frames,
        float frameDuration,
        bool isLooping = true)
    {
        if (frames == null || frames.Length == 0)
            throw new ArgumentException("An animation must contain at least one frame.");

        if (frameDuration <= 0)
            throw new ArgumentOutOfRangeException(nameof(frameDuration));

        Frames = frames;
        FrameDuration = frameDuration;
        IsLooping = isLooping;
    }
}