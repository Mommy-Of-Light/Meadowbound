using Microsoft.Xna.Framework;

namespace MeadowBound.Components;

public class TransformComponent
{
    public Vector2 Position { get; set; }

    public TransformComponent(Vector2 position)
    {
        Position = position;
    }
}