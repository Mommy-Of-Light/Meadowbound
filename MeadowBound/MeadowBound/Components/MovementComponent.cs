using Microsoft.Xna.Framework;

namespace Meadowbound.Components;

public class MovementComponent
{
    public float Speed { get; set; }
    public Vector2 Direction { get; set; }

    public MovementComponent(float speed)
    {
        Speed = speed;
        Direction = Vector2.Zero;
    }
}