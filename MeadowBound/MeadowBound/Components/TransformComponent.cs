using Microsoft.Xna.Framework;

namespace Meadowbound.Components;

public class TransformComponent
{
    public Vector2 Position { get; set; }

    public TransformComponent(Vector2 position)
    {
        Position = position;
    }
}