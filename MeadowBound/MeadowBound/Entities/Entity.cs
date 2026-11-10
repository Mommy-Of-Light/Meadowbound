using MeadowBound.Components;

namespace MeadowBound.Entities;

public abstract class Entity
{
    public TransformComponent Transform { get; }
    public MovementComponent Movement { get; }

    protected Entity(TransformComponent transform, MovementComponent movement)
    {
        Transform = transform;
        Movement = movement;
    }
}