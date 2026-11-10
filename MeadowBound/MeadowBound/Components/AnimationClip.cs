using Microsoft.Xna.Framework;

namespace MeadowBound.Components;

public class AnimationClip
{
    public Rectangle[] Frames { get; }
    public float FrameDuration { get; }
    public bool IsLooping { get; }

    public AnimationClip(int row, int frameCount, int frameWidth, int frameHeight, float framesPerSecond, int startColumn = 0, bool isLooping = true)
    {
        Frames = new Rectangle[frameCount];

        for (int i = 0; i < frameCount; i++)
        {
            Frames[i] = new Rectangle((startColumn + i) * frameWidth, row * frameHeight, frameWidth, frameHeight);
        }

        FrameDuration = 1f / framesPerSecond;
        IsLooping = isLooping;
    }

    public AnimationClip(int row, int[] frameIndices, int frameWidth, int frameHeight, float framesPerSecond, bool isLooping = true)
    {
        Frames = new Rectangle[frameIndices.Length];

        for (int i = 0; i < frameIndices.Length; i++)
        {
            Frames[i] = new Rectangle(frameIndices[i] * frameWidth, row * frameHeight, frameWidth, frameHeight);
        }

        FrameDuration = 1f / framesPerSecond;
        IsLooping = isLooping;
    }
}